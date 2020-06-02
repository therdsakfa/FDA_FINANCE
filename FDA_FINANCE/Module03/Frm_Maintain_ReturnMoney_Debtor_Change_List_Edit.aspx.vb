Public Class Frm_Maintain_ReturnMoney_Debtor_Change_List_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        Dim id As Integer = Request.QueryString("id")
        dao.Getdata_by_RETURN_MONEY_DEBTOR_ID(id)
        UC_Maintain_ReturnMoney_Debtor_Change_List_Detail1.update(dao)
        UC_Maintain_ReturnMoney_Debtor_Change_List_Detail1.insert_bill(id)
        dao.update()
        Dim dao_get_id_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        dao_get_id_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(id)
        UC_Maintain_ReturnMoney_Debtor_Change_List_Detail1.update_detail_margin(dao_get_id_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)
        UC_Maintain_ReturnMoney_Debtor_Change_List_Detail1.update_deb_detail(id)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
    'Public Sub insert_bill(ByVal )

    '    'Dim id As Integer = item("RETURN_MONEY_DEBTOR_ID").Text
    '    Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
    '    Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
    '    Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
    '    Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
    '    dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(ID)
    '    dao_debtor.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

    '    dao_head.fields.RETURN_MONEY_ID = ID
    '    dao_head.fields.DESCRIPTION = "วางเบิก" & dao_return.fields.RETURN_DESCRIPTION
    '    dao_head.fields.BUDGET_PLAN_ID = dao_debtor.fields.BUDGET_PLAN_ID
    '    dao_head.fields.BUDGET_YEAR = dao_debtor.fields.BUDGET_YEAR
    '    dao_head.fields.DEPARTMENT_ID = dao_debtor.fields.DEPARTMENT_ID
    '    dao_head.fields.IS_PO = False
    '    dao_head.fields.PATLIST_ID = dao_debtor.fields.PAYLIST_ID
    '    'dao_head.fields.PAY_TYPE_ID = 

    '    dao_head.insert()

    '    dao_detail.fields.BUDGET_DISBURSE_BILL_ID = dao_head.fields.BUDGET_DISBURSE_BILL_ID
    '    dao_detail.fields.AMOUNT = dao_return.fields.RETURN_AMOUNT

    '    dao_detail.insert()

    '    rgReceiptList.Rebind()
    'End Sub
End Class