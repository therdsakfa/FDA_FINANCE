Public Class UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_Changedate.Text = System.DateTime.Now.ToShortDateString
        End If
    End Sub
    Public Sub update_return(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        dao.fields.BT_NUMBER = txt_bt_number.Text
        If txt_Changedate.Text <> "" Then
            dao.fields.CHANGE_DATE = CDate(txt_Changedate.Text)
        End If
        dao.fields.CHANGE_DESCRIPTION = txt_CHANGE_DESCRIPTION.Text
    End Sub
End Class