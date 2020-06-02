Public Class Frm_Disburse_Relate_Overview_withdraw_v3
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

    Public year As String = ""
    Public deka As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Page.Title = "ฏีกาเบิกเงินงบประมาณ"

        uc_disburse_budget_bill_withdraw_v31.Budgetyear = Request.QueryString("myear")
        uc_disburse_budget_bill_withdraw_v31.Citizen = _CLS.CITIZEN_ID

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        uc_disburse_budget_bill_withdraw_v31.rgRebind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click

        year = txt_BudgetYear.Text
        deka = txt_dekaNumber.Text

        uc_disburse_budget_bill_withdraw_v31.search(year, deka)

    End Sub
End Class