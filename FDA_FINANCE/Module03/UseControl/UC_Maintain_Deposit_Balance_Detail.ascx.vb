Public Class UC_Maintain_Deposit_Balance_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_DEPOSIT_BALANCE)
        dao.fields.ACCOUNT_BALANCE_AMOUNT = rnt_ACCOUNT_BALANCE_AMOUNT.Value
        dao.fields.ACCOUNT_NUMBER = txt_ACCOUNT_NUMBER.Text
        dao.fields.CHECK_AMOUNT = rnt_CHECK_AMOUNT.Value
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        dao.fields.INTEREST_AMOUNT = rnt_INTEREST_AMOUNT.Value
        If txt_date_save.Text <> "" Then
            dao.fields.SAVE_DATE = CDate(txt_date_save.Text)
        End If
    End Sub

    Public Function get_date() As Date
        Dim _date As Date
        If txt_date_save.Text <> "" Then
            _date = CDate(txt_date_save.Text)
        End If

        Return _date
    End Function
End Class