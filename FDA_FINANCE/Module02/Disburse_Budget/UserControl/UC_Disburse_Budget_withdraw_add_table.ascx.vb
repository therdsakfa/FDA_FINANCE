Imports Telerik.Web.UI

Public Class UC_Disburse_Budget_withdraw_add_table
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
        'run_Query()
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
        Dim dt As New DataTable
        'If Request.QueryString("bid") <> "" Then
        '    Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
        '    dao.Getdata_by_ID(Request.QueryString("bid"))
        '    If dao.fields.RELATE_TYPE <> 2 Then
        '        dt = bao_gl.get_GL()
        '    Else
        '        dt = bao_gl.get_GL_debtor()
        '    End If

        'Else
        dt = bao_gl.get_GL()
        'End If
        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_DETAIL)
        Try
            dao.fields.AMOUNT = rnt_AMOUNT.Value
        Catch ex As Exception
            dao.fields.AMOUNT = 0
        End Try
        Try
            dao.fields.BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
        Catch ex As Exception
            dao.fields.BUDGET_PLAN_ID = 0
        End Try
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.GL_ID = ddl_GL.SelectedValue

    End Sub
    Public Sub get_date(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_DETAIL)
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
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                dao.Getdata_by_ID(item("RELATE_DETAIL_ID").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("bid") <> "" Then
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.SC_get_relate_det_by_id(Request.QueryString("bid"))
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
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                insert(dao)
                dao.fields.RELATE_ID = _bid
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
        show_img_tooltip()
    End Sub
    Public Sub show_img_tooltip()
        Dim str As String = ""
        Dim bg_id As Integer = 0

        Try
            bg_id = dd_BudgetAdjust.SelectedValue
        Catch ex As Exception

        End Try
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_id)
        str = "งบรายจ่าย : " & dao_bg.fields.BUDGET_DESCRIPTION & vbCrLf

        Try
            Dim dao_act As New DAO_MAS.TB_BUDGET_PLAN
            dao_act.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
            Dim dao_act2 As New DAO_MAS.TB_BUDGET_PLAN
            dao_act2.Getdata_by_BUDGET_PLAN_ID(dao_act.fields.BUDGET_CHILD_ID)

            str &= "กิจกรรมหลัก : " & dao_act2.fields.BUDGET_DESCRIPTION & vbCrLf
        Catch ex As Exception

        End Try


        Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
        Catch ex As Exception

        End Try
        Try
            str &= "ชื่อโครงการ/กิจกรรม : " & dao_head_bg.fields.BUDGET_CODE & " - " & dao_head_bg.fields.BUDGET_DESCRIPTION & vbCrLf
        Catch ex As Exception
        End Try

        Dim uti_adjust As New Utility_other()
        Dim bao_relate As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_debt_app As New BAO_BUDGET.Budget
        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, _bgyear)
        'Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(bg_id, _bgyear, _dept)
        'Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App(bg_id, _bgyear)
        Dim Relate_Amount As Double = bao_relate.get_Amount_Relate_App(bg_id, _bgyear)
        Try
            str &= "จำนวนเงินงบประมาณ : " & adjust_amount.ToString("N") & " บาท " & vbCrLf
        Catch ex As Exception

        End Try

        Try
            str &= "จำนวนเงินคงเหลือ : " & (adjust_amount - Relate_Amount).ToString("N") & " บาท "
        Catch ex As Exception

        End Try

        img_bg_balance.ToolTip = str
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
        show_img_tooltip()
    End Sub
End Class