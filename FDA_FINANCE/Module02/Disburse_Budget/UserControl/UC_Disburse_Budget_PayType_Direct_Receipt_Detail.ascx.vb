Public Class UC_Disburse_Budget_PayType_Direct_Receipt_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            dao.fields.RECEIPT_DATE = CDate(txt_RECEIPT_DATE.Text)
        Catch ex As Exception
            dao.fields.RECEIPT_DATE = Nothing
        End Try

        dao.fields.RECEIPT_NUMBER = txt_RECEIPT_NUMBER.Text
        Try
            dao.fields.IS_NO_RECIPT = cbIS_NO_RECIPT.Checked
        Catch ex As Exception

        End Try

    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            txt_RECEIPT_DATE.Text = CDate(dao.fields.RECEIPT_DATE).ToShortDateString
        Catch ex As Exception
            txt_RECEIPT_DATE.Text = ""
        End Try

        txt_RECEIPT_NUMBER.Text = dao.fields.RECEIPT_NUMBER
        Try
            cbIS_NO_RECIPT.Checked = dao.fields.IS_NO_RECIPT
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cb_disable()
        If cbIS_NO_RECIPT.Checked Then
            'txt_RECEIPT_DATE.Text = ""
            txt_RECEIPT_DATE.Enabled = False

            'txt_RECEIPT_NUMBER.Text = ""
            txt_RECEIPT_NUMBER.Enabled = False
        Else
            txt_RECEIPT_DATE.Enabled = True
            txt_RECEIPT_NUMBER.Enabled = True
        End If
    End Sub

    Private Sub cbIS_NO_RECIPT_CheckedChanged(sender As Object, e As EventArgs) Handles cbIS_NO_RECIPT.CheckedChanged
        cb_disable()
    End Sub
End Class