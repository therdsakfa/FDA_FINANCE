Public Class Frm_Budget_Transfer_Share_Type
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
        'If Request.QueryString("tid") IsNot Nothing Then
        '    btn_Add.Attributes.Add("onclick", "insert_k('Frm_Disburse_PO_Detail_List_Insert.aspx?tid=" & Request.QueryString("tid") & "'); return false;")
        'End If
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Budget_Transfer_Share_Type1.rg_rebind()
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("Frm_Transfer_Outside.aspx")
    End Sub
End Class