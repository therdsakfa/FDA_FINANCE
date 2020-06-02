Public Class Frm_Maintain_Transfer_Out_Budget
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub Frm_Maintain_Transfer_Out_Budget_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_Transfer_Out_BG1.bindseq()
    End Sub
End Class