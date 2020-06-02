Imports Microsoft.Reporting.WebForms

Public Class Frm_Report_All_Plan
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            set_dd_bgyear()
            bind_dl_department()
            run_report()
        End If
        '  getReportDate_New()

    End Sub

    Public Sub bind_dl_department()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.get_Department_Select()

        dd_department.DataSource = dt
        dd_department.DataBind()
    End Sub

    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If

        For i As Integer = 2555 To byearMax
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
    End Sub

    'Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
    '    run_report()
    'End Sub

    Public Sub run_report()
        ShowReport()
    End Sub

    Public Sub ShowReport()
        ReportViewer1.Height = 1000
        ReportViewer1.Width = 1300
        ReportViewer1.LocalReport.ReportPath = "Module02/Report/Frm_Report_All_Plan.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()

        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA", getReportDate_New()))

        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.DataBind()
    End Sub

    Public Function getReportDate_New() As DataTable

        Dim bao_report As New BAO_BUDGET.Report
        Dim years As Integer = 0
        years = dd_BudgetYear.SelectedValue

        Dim depid As Integer = 0
        depid = dd_department.SelectedValue

        Dim dt As New DataTable
        dt = bao_report.get_Report_All_Plan(years, depid)
        dt.Columns.Add("Amount", GetType(Double))

        For Each dr As DataRow In dt.Rows

            If IsDBNull(dr("BUDGET_DEPARTMENT_MONEY")) = False Then
                If dr("BUDGET_DEPARTMENT_MONEY") <> 0 Then
                    dr("Amount") = dr("BUDGET_DEPARTMENT_MONEY")
                Else
                    dr("Amount") = 0
                End If
            Else
                dr("Amount") = 0
            End If
        Next

        Return dt
    End Function

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        run_report()
    End Sub

    Private Sub dd_department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_department.SelectedIndexChanged
        run_report()
    End Sub
End Class