Public Class Frm_Maintain_ReturnMoney_Debtor_Change_List
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_ReturnMoney_Debtor_Change_List1.rg_rebind()
    End Sub

    Private Sub Frm_Maintain_ReturnMoney_Debtor_Change_List_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_ReturnMoney_Debtor_Change_List1.bindseq()
    End Sub
End Class