Public Class Frm_Disburse_PO_Insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Request.QueryString("id") IsNot Nothing Then
        '    UC_PO_Add_List1.
        'End If
         If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_Department()
            dd_Department.DataSource = dt
            dd_Department.DataBind()

            bind_dl_bg()

        End If
    End Sub
    Public Sub bind_dl_bg()
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_Department.SelectedValue, Request.QueryString("bgYear"))

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                If dao_head.fields.BUDGET_CODE <> "" Then
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                Else
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                End If

            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()


        End If
        'UC_Disburse_PO1.rebind_grid()
    End Sub
    Protected Sub btn_bill_edit_Click(sender As Object, e As EventArgs) Handles btn_bill_edit.Click
        'Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        'Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        'Dim bao As New BAO_BUDGET.Budget
        'Dim bill_id As Integer
        'UC_Disburse_Budget_PO_Detail1.insert(dao_disburse_bill)
        'dao_disburse_bill.insert()
        'bill_id = dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID
        'UC_Disburse_Budget_PO_Detail1.insert_detail(dao_detail, bill_id)
        'dao_detail.insert()

        UC_PO_Add_List1.insert(dd_BudgetAdjust.SelectedValue, dd_Department.SelectedValue)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('บันทึกเรียบร้อย');", True)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
    End Sub

    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        bind_dl_bg()
    End Sub
End Class