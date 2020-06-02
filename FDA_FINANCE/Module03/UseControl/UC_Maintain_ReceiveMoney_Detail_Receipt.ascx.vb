Public Class UC_Maintain_ReceiveMoney_Detail_Receipt
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
    Public Sub set_date()
        txt_MONEY_RECEIVE_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        dao.fields.RECEIPT_NUMBER = txt_RECEIPT_NUMBER.Text
        dao.fields.RECEIPT_VOLUME = txt_RECEIPT_VOLUME.Text
        If txt_MONEY_RECEIVE_DATE.Text <> "" Then
            dao.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
        Else
            dao.fields.MONEY_RECEIVE_DATE = Nothing
        End If

    End Sub

    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        txt_RECEIPT_NUMBER.Text = dao.fields.RECEIPT_NUMBER
        txt_RECEIPT_VOLUME.Text = dao.fields.RECEIPT_VOLUME
        If dao.fields.MONEY_RECEIVE_DATE IsNot Nothing Then
            txt_MONEY_RECEIVE_DATE.Text = CDate(dao.fields.MONEY_RECEIVE_DATE).ToShortDateString
        End If

    End Sub

End Class