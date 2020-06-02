Public Class Frm_Disburse_Budget_PO_Bill
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
        UC_Disburse_Budget_Bill1.ispo = "True"
        UC_Disburse_Budget_Bill1.BudgetUseID = 1
        UC_Disburse_Budget_Bill1.PAY_TYPE_ID = 1
        UC_Disburse_Budget_Bill1.Budgetyear = Master.get_Year()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Budget_Bill1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Budget_Bill1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_Bill1.rgRebind()
    End Sub
End Class