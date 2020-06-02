Imports Telerik.Web.UI

Public Class UC_Disburse_Debtor_Detail_V3_Table
    Inherits System.Web.UI.UserControl
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Public Sub run_Query()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub hide_add_data()
        If Request.QueryString("bit") <> "" Then
            Panel1.Style.Add("display", "none")
        End If
    End Sub
    Public Sub bind_dl_account()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.SP_GET_MONEY_TYPE()
        '
        ddl_acount.DataSource = dt
        ddl_acount.DataBind()
    End Sub

    Public Sub bind_dd_cus()
        Dim bao_cus As New BAO_BUDGET.MASS
        Dim dt_cus As DataTable = bao_cus.get_customer()

        dd_CUSTOMER.DataSource = dt_cus
        dd_CUSTOMER.DataBind()
    End Sub

    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_gl.get_GL()

        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL)
        Try
            dao.fields.AMOUNT = rnt_AMOUNT.Value
        Catch ex As Exception
            dao.fields.AMOUNT = 0
        End Try
        Try
            dao.fields.BUDGET_PLAN_ID = ddl_acount.SelectedValue
        Catch ex As Exception
            dao.fields.BUDGET_PLAN_ID = 0
        End Try
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.GL_ID = ddl_GL.SelectedValue

    End Sub
    Public Sub get_date(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL)
        Try
            rnt_AMOUNT.Value = dao.fields.AMOUNT
        Catch ex As Exception
            rnt_AMOUNT.Value = 0
        End Try
        Try
            ddl_acount.DropDownSelectData(dao.fields.BUDGET_PLAN_ID)
        Catch ex As Exception
        End Try
        dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
        ddl_GL.DropDownSelectData(dao.fields.GL_ID)

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                'Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                'dao.Getdata_by_DETAIL_ID(item("DETAIL_ID").Text)
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                dao.Getdata_by_DEBTOR_BILL_DETAIL_ID(item("DEBTOR_BILL_DETAIL_ID").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim btn_review As LinkButton = DirectCast(item("del").Controls(0), LinkButton)
            If Request.QueryString("bit") <> "" Then
                btn_review.Style.Add("display", "none")
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("bid") <> "" Then
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.SC_get_debtor_out_det_by_id(Request.QueryString("bid"))

        End If

        RadGrid1.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_add_bg_Click(sender As Object, e As EventArgs) Handles btn_add_bg.Click
        Dim bg_id As Integer = 0
        Try
            bg_id = ddl_acount.SelectedValue
        Catch ex As Exception

        End Try
        If Request.QueryString("bid") <> "" Then
            If rnt_AMOUNT.Value > 0 And dd_CUSTOMER.SelectedValue <> 1 Then
                'If chk_amount(bg_id, rnt_AMOUNT.Value) = True Then
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL

                insert(dao)
                dao.fields.DEBTOR_BILL_ID = Request.QueryString("bid")
                dao.insert()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
                'Else
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('จำนวนเงินไม่เพียงพอ');", True)
                'End If
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครบถ้วน');", True)
            End If

        End If
        'show_img_tooltip()
    End Sub

    Public Function chk_amount(ByVal bgid As Integer, ByVal amount As Double) As Boolean
        Dim bool As Boolean = True
        Dim uti_adjust As New Utility_other()
        Dim bao_relate As New BAO_BUDGET.DISBURSE_BUDGET
        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bgid, _bgyear)
        Dim Relate_Amount As Double = bao_relate.get_Amount_Relate_App(bgid, _bgyear)
        Dim balance As Double = 0
        balance = adjust_amount - Relate_Amount
        If balance < amount Then
            bool = False
        End If

        Return bool
    End Function
End Class