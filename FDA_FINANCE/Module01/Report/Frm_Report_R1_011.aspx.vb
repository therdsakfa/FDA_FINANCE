Public Class Frm_Report_R1_011
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getReportData() As DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R1_011(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
        Return dt
    End Function
    
    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_011.rdlc", "Fields_Report_R1_011", getReportData())
    End Sub
End Class