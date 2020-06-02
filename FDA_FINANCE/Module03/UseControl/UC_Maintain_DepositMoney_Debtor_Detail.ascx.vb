Public Class UC_Maintain_DepositMoney_Debtor_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub set_date()
        txt_DEPOSIT_DATE.Text = System.DateTime.Now.ToShortDateString
    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR_DEPOSIT)
        'dao.fields.DEPOSIT_DATE = rdp_DEPOSIT_DATE.SelectedDate
        'dao.fields.RECEIPT_VOLUME = txt_RECEIPT_VOLUME.Text
        'dao.fields.DEPOSIT_DESCRIPTION = txt_DEPOSIT_DESCRIPTION.Text
        'dao.fields.MONEY_TYPE_ID = rbl_MONEY_TYPE_DESCRIPTION.SelectedItem.Value
        'dao.fields.DEPOSIT_AMOUNT = txt_DEPOSIT_AMOUNT.Text
        dao.fields.RETURN_MONEY_DEBTOR_ID = Request.QueryString("DEPOSIT_MONEY_ID")
        dao.fields.GF_NUMBER = txt_GF_NUMBER.Text
        If txt_DEPOSIT_DATE.Text <> "" Then
            dao.fields.DEPOSIT_DATE = CDate(txt_DEPOSIT_DATE.Text)
        End If
        dao.fields.DEPOSIT_DETAIL = txt_Detail.Text
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        Try
            If dao.fields.MONEY_RETURN_DATE IsNot Nothing Then
                Return_Money_Date.Text = dao.fields.MONEY_RETURN_DATE
            End If

            txt_DEPOSIT_DESCRIPTION.Text = dao.fields.RETURN_DESCRIPTION
            txt_AMOUNT.Text = CDbl(dao.fields.RETURN_AMOUNT).ToString("N")
            txt_RECEIPT_VOLUME.Text = CStr(dao.fields.DISBURSE_NUMBER) & "/" & CStr(dao.fields.DISBURSE_VOLUME)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub getdataDetail(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR_DEPOSIT)
        txt_DEPOSIT_DATE.Text = dao.fields.DEPOSIT_DATE
        txt_GF_NUMBER.Text = dao.fields.GF_NUMBER
        txt_Detail.Text = dao.fields.DEPOSIT_DETAIL
    End Sub
End Class