Public Class UC_Disburse_Budget_PayType_Direct_Invoice_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            dao.fields.INVOICES_DATE = CDate(txt_INVOICE_DATE.Text)
        Catch ex As Exception
            dao.fields.INVOICES_DATE = Nothing
        End Try
        Try
            dao.fields.INVOICES_DATE_SAVE = CDate(txt_INVOICES_DATE_SAVE.Text)
        Catch ex As Exception
            dao.fields.INVOICES_DATE_SAVE = Nothing
        End Try
        dao.fields.INVOICES_NUMBER = txt_INVOICE_NUMBER.Text

        dao.fields.IS_RECEIVE_TAX = cb_IS_RECEIVE_TAX.Checked
        dao.fields.RECEIVER_TAX_NAME = txt_RECEIVER_TAX_NAME.Text
        Try
            dao.fields.RECEIVE_TAX_DATE = CDate(txt_RECEIVE_TAX_DATE.Text)
        Catch ex As Exception
            dao.fields.RECEIVE_TAX_DATE = Nothing
        End Try

    End Sub

    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            txt_INVOICE_DATE.Text = CDate(dao.fields.INVOICES_DATE).ToShortDateString()
        Catch ex As Exception
            txt_INVOICE_DATE.Text = ""
        End Try
        Try
            txt_INVOICES_DATE_SAVE.Text = CDate(dao.fields.INVOICES_DATE_SAVE).ToShortDateString()
        Catch ex As Exception
            txt_INVOICES_DATE_SAVE.Text = ""
        End Try
        txt_INVOICE_NUMBER.Text = dao.fields.INVOICES_NUMBER

        Try
            cb_IS_RECEIVE_TAX.Checked = dao.fields.IS_RECEIVE_TAX
        Catch ex As Exception

        End Try

        txt_RECEIVER_TAX_NAME.Text = dao.fields.RECEIVER_TAX_NAME
        Try
            txt_RECEIVE_TAX_DATE.Text = CDate(dao.fields.RECEIVE_TAX_DATE).ToShortDateString()
        Catch ex As Exception
            txt_RECEIVE_TAX_DATE.Text = ""
        End Try

    End Sub
    Public Sub insert_stat(ByVal bid As Integer, ByVal bt As Integer, ByVal iden As String, ByVal stat As Integer)
        If cb_IS_RECEIVE_TAX.Checked Then
            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao_app.fields.BILL_TYPE = bt
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = bid
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = Date.Now
            dao_app.fields.STATUS_ID = stat
            dao_app.fields.GROUP_ID = Request.QueryString("g")

            dao_app.insert()

        End If
        
    End Sub
End Class