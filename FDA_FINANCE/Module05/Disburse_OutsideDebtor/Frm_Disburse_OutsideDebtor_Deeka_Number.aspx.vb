Public Class Frm_Disburse_OutsideDebtor_Deeka_Number
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
        UC_Disburse_Debtor_Deeka_Number1.Budgetyear = bgYear
        UC_Disburse_Debtor_Deeka_Number1.BudgetUseID = 3
        UC_Disburse_Debtor_Deeka_Number1.stat = 4
        UC_Disburse_Debtor_Deeka_Number1.bt = 3
        UC_Disburse_Debtor_Deeka_Number1.g = 7
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor_Deeka_Number1.rgFilter(str)
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Deeka_Number1.rg_rebind()
    End Sub
End Class