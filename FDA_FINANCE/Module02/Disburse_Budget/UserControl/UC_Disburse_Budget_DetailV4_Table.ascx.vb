Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_DetailV4_Table
    Inherits System.Web.UI.UserControl
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Private _type As Integer
    Public Property type() As Integer
        Get
            Return _type
        End Get
        Set(ByVal value As Integer)
            _type = value
        End Set
    End Property

    Private _bt As Integer = 0
    Private _stat As Integer = 0

    Public Sub run_Query()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
        _bt = Request.QueryString("_bt")
        _stat = Request.QueryString("_stat")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        run_Query()
    End Sub

    Public Sub hide_add_data()
        If Request.QueryString("bit") <> "" Then
            'Panel1.Style.Add("display", "none")
        End If
    End Sub

    Public Sub bind_dl_bg()
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(_dept, _bgyear)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                If dao_head.fields.BUDGET_CODE <> "" Then
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION '& " -> " & dr("BUDGET_DESCRIPTION")
                Else
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION '& " -> " & dr("BUDGET_DESCRIPTION")
                End If

            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()
            dd_BudgetAdjust.DropDownInsertDataFirstRow("--- กรุณาเลือก ---", "0")

        End If
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

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)

        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.GL_ID = ddl_GL.SelectedValue

        Try
            dao.fields.AMOUNT = rnt_AMOUNT.Value
        Catch ex As Exception
            dao.fields.AMOUNT = 0
        End Try
        Try
            If dd_BudgetAdjust.SelectedValue <> 0 Then
                dao.fields.BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
            Else
                dao.fields.BUDGET_PLAN_ID = 0
            End If

        Catch ex As Exception
            dao.fields.BUDGET_PLAN_ID = 0
        End Try
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.GL_ID = ddl_GL.SelectedValue
    End Sub

    Public Sub get_date(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
       Try
            rnt_AMOUNT.Value = dao.fields.AMOUNT
        Catch ex As Exception
            rnt_AMOUNT.Value = 0
        End Try
        Try
            dd_BudgetAdjust.DropDownSelectData(dao.fields.BUDGET_PLAN_ID)
        Catch ex As Exception
        End Try
        dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
        ddl_GL.DropDownSelectData(dao.fields.GL_ID)

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao.Getdata_by_DETAIL_ID(item("DETAIL_ID").Text)
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

            Dim dao_a As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            Dim co As Integer = 0

            Try
                co = dao_a.count_approve(item("BUDGET_DISBURSE_BILL_ID").Text, _bt, _stat)
            Catch ex As Exception

            End Try

            If co > 0 Then
                btn_review.Visible = False
            Else
                btn_review.Visible = True
            End If
            'If Request.QueryString("bit") <> "" And type = 0 Then
            '    btn_review.Style.Add("display", "none")
            'Else
            '    If type <> 0 Then
            '        btn_review.Style.Add("display", "block")
            '    Else
            '        btn_review.Style.Add("display", "none")
            '    End If
            'End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("bid") <> "" Then
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.SC_get_bill_out_det_by_id(Request.QueryString("bid"))
        End If

        RadGrid1.DataSource = dt
    End Sub

    Public Sub rebind_grid()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_add_bg_Click(sender As Object, e As EventArgs) Handles btn_add_bg.Click

        Dim bg_id As Integer = 0
        Try
            bg_id = dd_BudgetAdjust.SelectedValue
        Catch ex As Exception

        End Try

        If Request.QueryString("bid") <> "" Then
            If rnt_AMOUNT.Value > 0 And dd_CUSTOMER.SelectedValue <> 1 Then
                'If chk_amount(bg_id, rnt_AMOUNT.Value) = True Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                insert(dao)
                dao.fields.BUDGET_DISBURSE_BILL_ID = _bid
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
        bind_data_projectName()
    End Sub

    Public Sub bind_data_projectName()

        Dim str As String = ""
        Dim bg_id As Integer = 0

        Try
            bg_id = dd_BudgetAdjust.SelectedValue
        Catch ex As Exception

        End Try

        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act2 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act3 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act4 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN

        If bg_id <> 0 Then

            dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_id)
            lb_budget.Text = dao_bg.fields.BUDGET_DESCRIPTION

            Try

                dao_act.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
                lb_ProjectName.Text = dao_act.fields.BUDGET_DESCRIPTION
                lb_ProjectCode.Text = dao_act.fields.BUDGET_CODE

                '---------------------------------

                dao_act2.Getdata_by_BUDGET_PLAN_ID(dao_act.fields.BUDGET_CHILD_ID)
                lb_mainAct.Text = dao_act2.fields.BUDGET_DESCRIPTION
                '---------------------------------

                dao_act3.Getdata_by_BUDGET_PLAN_ID(dao_act2.fields.BUDGET_CHILD_ID)
                lb_product.Text = dao_act3.fields.BUDGET_DESCRIPTION

                '---------------------------------
                dao_act4.Getdata_by_BUDGET_PLAN_ID(dao_act3.fields.BUDGET_CHILD_ID)
                lb_plan.Text = dao_act4.fields.BUDGET_DESCRIPTION

                ' --------------------------------

                Dim uti_adjust As New Utility_other()
                Dim bao_relate As New BAO_BUDGET.DISBURSE_BUDGET
                Dim bao_debt_app As New BAO_BUDGET.Budget

                Dim bao_rec As New BAO_BUDGET.DISBURSE_BUDGET 'รับโอน
                Dim rec As Double = 0
                Dim ad As Double = 0

                rec = bao_rec.get_All_Transfer_Money(_bgyear, bg_id)
                ad = uti_adjust.getAdjust_Amount(bg_id, _bgyear)


                Dim adjust_amount As Double = (ad + rec)

                Dim Relate_Amount As Double = bao_relate.get_Amount_Relate_App(bg_id, _bgyear)

                Try
                    lb_amount.Text = adjust_amount.ToString("N") & " บาท "
                    lb_balance.Text = (adjust_amount - Relate_Amount).ToString("N") & " บาท "
                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try

        Else

            lb_plan.Text = "-"
            lb_product.Text = "-"
            lb_budget.Text = "-"
            lb_mainAct.Text = "-"
            lb_ProjectName.Text = "-"
            lb_ProjectCode.Text = "-"
            lb_amount.Text = "-"
            lb_balance.Text = "-"

        End If

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

    Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
        bind_data_projectName()
    End Sub

End Class