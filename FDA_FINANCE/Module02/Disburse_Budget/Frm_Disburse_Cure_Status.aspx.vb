Public Class Frm_Disburse_Cure_Status
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
        Dim bgYear As Integer = Master.get_Year()
        UC_Disburse_Cure_Study_Status1.BudgetYear = bgYear
        UC_Disburse_Cure_Study_Status1.BillType = 1
        UC_Disburse_Cure_Study_Status1.salary_include = 2
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Cure_Study_Status1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Cure_Study_Status1.rg_rebind()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg_2()
        UC_Disburse_Cure_Study_Status1.rgFilter(str)
    End Sub

    Private Sub dd_status_TextChanged(sender As Object, e As EventArgs) Handles dd_status.TextChanged
        Dim str As String = UC_Search_Form1.getSearchMsg()
        If str <> "" Then
            str = str & " and ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
            UC_Disburse_Cure_Study_Status1.rgFilter(str)
        Else
            str = " ([digit] like '%" & dd_status.SelectedValue.ToString & "%')"
            UC_Disburse_Cure_Study_Status1.rgFilter(str)
        End If
    End Sub
End Class