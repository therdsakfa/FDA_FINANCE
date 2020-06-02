Public Class Frm_Report_R1_029
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
            UC_Report_Dept2.bind_ddl_dept()
            UC_Report_SelectDate_Single1.set_date()
            run_report()
        End If
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
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single1.getDateSelect()
        UC_Report_Dept2.get_dept_select()
        Dim dt As New DataTable
        dt = bao.get_Report_R1_029(UC_Report_SelectDate_Single1.dateSelect, UC_Report_Dept2.dept, dd_BudgetYear.SelectedValue)


        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        run_report()
    End Sub
    Public Sub BindData()

        'UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()
        'UC_Report_Dept_Budget_Adjust_Sub1.set_bg()
        'UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
    Public Sub run_report()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_029.rdlc", "Fields_Report_R1_029", getReportData())
    End Sub
End Class