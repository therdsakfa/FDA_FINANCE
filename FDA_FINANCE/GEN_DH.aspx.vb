Public Class GEN_DH
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        If TextBox1.Text <> "" Then
            Dim ws_dh As New WS_GEN_DH_NUMBER.WS_GEN_DH_NO
            ws_dh.GEN_DH_NO(TextBox1.Text)
        End If
    End Sub
End Class