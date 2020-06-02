Public Class Frm_Budget_Overlap_Insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("dept") = 1
        Dim dept As Integer = Session("dept")
        UC_Overlap_Detail1.dept_id = dept
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao_over As New DAO_MAS.TB_OVERLAP_HEAD
        UC_Overlap_Detail1.insert(dao_over)
        dao_over.insert()
    End Sub
End Class