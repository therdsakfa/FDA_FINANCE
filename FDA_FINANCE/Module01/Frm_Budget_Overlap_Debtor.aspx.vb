Public Class Frm_Budget_Overlap_Debtor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        UC_Budget_Overlap_Debtor1.insert()
    End Sub
End Class