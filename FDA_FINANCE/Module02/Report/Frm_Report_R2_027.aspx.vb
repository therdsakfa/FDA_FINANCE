Public Class Frm_Report_R2_027
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_ddl_BudgetYear()
    End Sub
    Public Sub bind_ddl_BudgetYear()
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.get_BudgetYear()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
    End Sub
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        'Dim dt As DataTable = bao.getReportData_R5_007(UC_Report_SelectDate_Single.dateSelect)
        Dim dt As DataTable = bao.getReportData_R2_027(2560, dd_month.SelectedValue)
        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module02\Report_R2_027.rdlc", "Fields_Report_R2_027", getReportData())
    End Sub
End Class