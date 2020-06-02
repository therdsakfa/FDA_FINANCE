Public Class Frm_Disburse_Study_KNumber
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
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Disburse_Study_GF1.Budgetyear = Request.QueryString("myear")
        UC_Disburse_Study_GF1.bt = 2
        UC_Disburse_Study_GF1.stat = 6
        UC_Disburse_Study_GF1.g = 9
    End Sub

    Private Sub Frm_Disburse_Study_KNumber_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Study_GF1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Study_GF1.rgRebind()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_From_Cure_Study1.getSearchMsg()
        UC_Disburse_Study_GF1.rgFilter(str)
    End Sub
End Class