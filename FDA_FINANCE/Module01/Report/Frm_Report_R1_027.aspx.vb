Public Class Frm_Report_R1_027
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
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

    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim dt As New DataTable
        If dd_BudgetYear.SelectedValue = 2557 Then
            dt = bao.get_Report_R1_027(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dd_BudgetYear.SelectedValue)

        Else
            dt = bao.get_Report_R1_027_2(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dd_BudgetYear.SelectedValue)

        End If


        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        UC_Report_SelectDate_Between1.getDateSelect()
        If dd_BudgetYear.SelectedValue = 2557 Then
            util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_027.rdlc", "Fields_Report_R1_027", getReportData())
        Else
            util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_027_2.rdlc", "Fields_Report_R1_027", getReportData())
        End If

    End Sub
End Class