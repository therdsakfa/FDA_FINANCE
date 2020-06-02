Public Class FRM_M44_RECEIPT_BARCODE_SCAN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_Sent_Click(sender As Object, e As EventArgs) Handles btn_Sent.Click
        Dim str As String = txt_barcode.Text.Replace(" ", "|")
        Response.Redirect("Frm_Maintain_Receive_Money_Auto.aspx?fee=" & str & "&law=1")
    End Sub
End Class