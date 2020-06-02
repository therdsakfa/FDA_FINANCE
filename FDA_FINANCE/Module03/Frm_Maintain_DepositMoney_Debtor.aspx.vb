Public Class Frm_Maintain_DepositMoney_Debtor
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
        UC_Maintain_DepositMoney_Debtor_SelectDeposit1.BudgetYear = Request.QueryString("myear")
        UC_Maintain_DepositMoney_Debtor1.BudgetYear = Request.QueryString("myear")
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_DepositMoney_Debtor_SelectDeposit1.rebindRg()
        UC_Maintain_DepositMoney_Debtor1.rebindRg()
    End Sub

    Private Sub Frm_Maintain_DepositMoney_Debtor_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_DepositMoney_Debtor_SelectDeposit1.bindseq()
        UC_Maintain_DepositMoney_Debtor1.bindseq()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String = ""
        str = UC_Filter_Movedate1.get_messege()
        UC_Maintain_DepositMoney_Debtor1.rgFilter(str)
    End Sub
End Class