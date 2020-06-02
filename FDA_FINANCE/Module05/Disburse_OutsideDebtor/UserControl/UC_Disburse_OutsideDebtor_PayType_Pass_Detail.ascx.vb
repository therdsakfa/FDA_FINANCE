Public Partial Class UC_Disburse_OutsideDebtor_PayType_Pass_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_PAY_PASS)
        ' dao.fields.BUDGET_DISBURSE_BILL_ID = 
        'dao.fields.CONTACT_NUMBER = txt_CONTACT_NUMBER.Text
        'dao.fields.GF_NUMBER = txt_GF_NUMBER.Text
        'dao.fields.INVOICE_DATE = rdp_INVOICE_DATE.SelectedDate
        'dao.fields.INVOICE_NUMBER = txt_INVOICE_NUMBER.Text
        'dao.fields.REFERENCE_DATE = rdp_REFERENCE_DATE.SelectedDate
        'dao.fields.REFERENCE_NUMBER = txt_REFERENCE_NUMBER.Text
        'dao.fields.RETURN_APPROVE_DATE = rdp_RETURN_APPROVE_DATE.SelectedDate
        'dao.fields.RETURN_APPROVE_NUMBER = txt_RETURN_APPROVE_NUMBER.Text
        'dao.fields.TAX_RECEIPT_DATE = rdp_TAX_RECEIPT_DATE.SelectedDate
        'dao.fields.TAX_RECEIPT_NUMBER = txt_TAX_RECEIPT_NUMBER.Text
        'dao.fields.TRANSFER_DATE = rdp_TRANSFER_DATE.SelectedDate
        'dao.fields.TRANSFER_DESCRIPTION = txt_TRANSFER_DESCRIPTION.Text
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_PAY_PASS)
        ' dao.fields.BUDGET_DISBURSE_BILL_ID = 
        'txt_CONTACT_NUMBER.Text = dao.fields.CONTACT_NUMBER
        'txt_GF_NUMBER.Text = dao.fields.GF_NUMBER
        'rdp_INVOICE_DATE.SelectedDate = dao.fields.INVOICE_DATE
        'txt_INVOICE_NUMBER.Text = dao.fields.INVOICE_NUMBER
        'rdp_REFERENCE_DATE.SelectedDate = dao.fields.REFERENCE_DATE
        'txt_REFERENCE_NUMBER.Text = dao.fields.REFERENCE_NUMBER
        'rdp_RETURN_APPROVE_DATE.SelectedDate = dao.fields.RETURN_APPROVE_DATE
        'txt_RETURN_APPROVE_NUMBER.Text = dao.fields.RETURN_APPROVE_NUMBER
        'rdp_TAX_RECEIPT_DATE.SelectedDate = dao.fields.TAX_RECEIPT_DATE
        'txt_TAX_RECEIPT_NUMBER.Text = dao.fields.TAX_RECEIPT_NUMBER
        'rdp_TRANSFER_DATE.SelectedDate = dao.fields.TRANSFER_DATE
        'txt_TRANSFER_DESCRIPTION.Text = dao.fields.TRANSFER_DESCRIPTION
    End Sub
End Class