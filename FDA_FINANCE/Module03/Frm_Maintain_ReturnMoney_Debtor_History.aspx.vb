Public Class Frm_Maintain_ReturnMoney_Debtor_History
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        Try
            _dept = Request.QueryString("dept")
            _bgid = Request.QueryString("bgid")
            bgYear = Request.QueryString("myear")
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        UC_Maintain_ReturnMoney_Debtor_History1.bgyear = bgYear
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim str_uc As String = UC_Maintain_ReturnMoney_Search1.getSearchMsg()
        UC_Maintain_ReturnMoney_Debtor_History1.rgFilter(str_uc)
    End Sub

    Private Sub Frm_Maintain_ReturnMoney_Debtor_History_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_ReturnMoney_Debtor_History1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_ReturnMoney_Debtor_History1.rebind_rg()
    End Sub
End Class