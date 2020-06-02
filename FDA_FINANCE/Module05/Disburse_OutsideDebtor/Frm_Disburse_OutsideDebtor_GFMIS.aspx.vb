Public Class Frm_Disburse_OutsideDebtor_GFMIS
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
        Dim bgYear As Integer = Request.QueryString("myear")
        UC_Disburse_Debtor_Bill1.Budgetyear = bgYear
        UC_Disburse_Debtor_Bill1.BudgetUseID = 3
        UC_Disburse_Debtor_Bill1.bt = 3
        UC_Disburse_Debtor_Bill1.stat = 1
        UC_Disburse_Debtor_Bill1.g = 0
        UC_Disburse_Debtor_Bill1.stat2 = 7
        UC_Disburse_Debtor_Bill1.g2 = 0
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor_Bill1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor_Bill1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Bill1.rg_rebind()
    End Sub
End Class