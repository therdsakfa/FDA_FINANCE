Imports Microsoft.Reporting.WebForms
Public Class Frm_Report_R3_016_2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim dt As New DataTable
        If Request.QueryString("t") = "1" Then
            'scarlar = get_sum_amount_all_type_by_income
            dt = bao.get_Report_R3_016_3(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
        Else
            dt = bao.get_Report_R3_016_2(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
        End If

        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_016_2.rdlc", "Fields_Report_R3_016", getReportData())
    End Sub
End Class