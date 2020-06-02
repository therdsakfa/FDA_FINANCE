Public Class Frm_Disburse_Debtor_Rebill
    Inherits System.Web.UI.Page
    Public bgYear As Integer
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
        Dim dept_id As Integer = 0
        Try
            dept_id = Request.QueryString("dept")
        Catch ex As Exception

        End Try

        bgYear = Master.get_Year()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        set_uc()
    End Sub
    Public Sub set_uc()
        Try
            UC_Disburse_Debtor_Rebill1.BudgetID = Request.QueryString("bgid")
            UC_Disburse_Debtor_Rebill1.BudgetUseID = 1
            UC_Disburse_Debtor_Rebill1.BudgetYear = bgYear
            UC_Disburse_Debtor_Rebill1.g = 3
            UC_Disburse_Debtor_Rebill1.bt = 2
            UC_Disburse_Debtor_Rebill1.stat = 1
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String = ""

        UC_Search_Form_Approve1.getSearchMsg()
        UC_Disburse_Debtor_Rebill1.rgFilter(str)
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Rebill1.rg_rebind()
    End Sub
End Class