Public Class Frm_Report_Disburse_Relate_withdraw
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
        'Uc_Report_Disburse_Relate_withdraw1.Citizen = _CLS.CITIZEN_ID
        Uc_Report_Disburse_Relate_withdraw1.BudgetYear = Request.QueryString("myear")

    End Sub

End Class