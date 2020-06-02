Public Partial Class UC_Disburse_OutsideDebtor_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        dao.fields.BUDGET_YEAR = dd_BUDGET_YEAR.SelectedValue
        dao.fields.BUDGET_PLAN_ID = dd_Budget_Plan.SelectedValue
        dao.fields.Bill_RECIEVE_DATE = rdp_Bill_RECIEVE_DATE.SelectedDate
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.DOC_DATE = rdp_DOC_DATE.SelectedDate
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PAYLIST_DESCRIPTION = txt_PAYLIST_DESCRIPTION.Text
        dao.fields.IS_DEPARTMENT = False
        dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
    End Sub


    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        dd_BUDGET_YEAR.SelectedValue = dao.fields.BUDGET_YEAR
        dd_Budget_Plan.SelectedValue = dao.fields.BUDGET_PLAN_ID
        rdp_Bill_RECIEVE_DATE.SelectedDate = dao.fields.Bill_RECIEVE_DATE
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        rdp_DOC_DATE.SelectedDate = rdp_DOC_DATE.SelectedDate
        txt_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
        txt_PAYLIST_DESCRIPTION.Text = dao.fields.PAYLIST_DESCRIPTION
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        dd_CUSTOMER_TYPE.SelectedValue = dao.fields.CUSTOMER_TYPE_ID

    End Sub
End Class