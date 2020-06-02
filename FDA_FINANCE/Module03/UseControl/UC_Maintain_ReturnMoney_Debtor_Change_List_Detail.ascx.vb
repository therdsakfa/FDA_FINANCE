Public Class UC_Maintain_ReturnMoney_Debtor_Change_List_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_CHANGE_DATE.Text = System.DateTime.Now.ToShortDateString

            If Request.QueryString("id") <> "" Then
                Dim r_id As Integer = Request.QueryString("id")
                Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(r_id)

                Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
                dao_debtor.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

                txt_DESCRIPTION.Text = "วางเบิกใบสำคัญ " & dao_return.fields.RETURN_DESCRIPTION
                rnt_AMOUNT.Value = dao_return.fields.RETURN_AMOUNT

            End If
        End If
    End Sub
    Public Sub update(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        dao.fields.CHANGE_DESCRIPTION = txt_CHANGE_DESCRIPTION.Text
        dao.fields.BT_NUMBER = txt_BT_NUMBER.Text
        dao.fields.IS_CHANGE = True
        If txt_CHANGE_DATE.Text <> "" Then
            dao.fields.CHANGE_DATE = txt_CHANGE_DATE.Text
        End If
    End Sub

    Public Sub insert_bill(ByVal id_return As Integer)
        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(id_return)
        dao_debtor.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

        dao_head.fields.RETURN_MONEY_ID = id_return
        dao_head.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao_head.fields.BUDGET_PLAN_ID = dao_debtor.fields.BUDGET_PLAN_ID
        dao_head.fields.BUDGET_YEAR = dao_debtor.fields.BUDGET_YEAR
        dao_head.fields.DEPARTMENT_ID = dao_debtor.fields.DEPARTMENT_ID
        dao_head.fields.IS_PO = False
        dao_head.fields.PATLIST_ID = dao_debtor.fields.PAYLIST_ID
        dao_head.fields.BUDGET_USE_ID = 1
        dao_head.fields.DOC_DATE = dao_debtor.fields.DOC_DATE
        dao_head.fields.DOC_NUMBER = dao_debtor.fields.DOC_NUMBER
        dao_head.fields.IS_APPROVE = False
        'dao_head.fields.PAY_TYPE_ID = 

        dao_head.insert()

        dao_detail.fields.BUDGET_DISBURSE_BILL_ID = dao_head.fields.BUDGET_DISBURSE_BILL_ID
        dao_detail.fields.AMOUNT = rnt_AMOUNT.Value

        dao_detail.insert()
    End Sub
    Public Sub update_detail_margin(ByVal id_debtor As Integer)
        'Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        'dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(id_return)
        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        dao_debtor.Getdata_by_DEBTOR_BILL_ID(id_debtor)
        dao_debtor.fields.REBILL_FLAG = 1
        dao_debtor.update()

        'Dim 
    End Sub

    Public Sub update_deb_detail(ByVal id_debtor As Integer)
        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        dao_debtor.Getdata_by_DEBTOR_BILL_ID(id_debtor)
        Dim dao_normal_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        dao_normal_debtor.Getdata_by_DEBTOR_BILL_ID(id_debtor)
        dao_normal_debtor.fields.MARGIN_DETAIL_ID = dao_debtor.fields.DETAIL_ID
        dao_normal_debtor.update()
    End Sub
End Class