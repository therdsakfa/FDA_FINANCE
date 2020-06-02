Public Class Frm_Report_R9_002
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
        End If
    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single1.getDateSelect()
        Dim dt As DataTable
        If txt_bill_number.Text <> "" Then
            dt = bao.get_Report_R9_002_bill(txt_bill_number.Text, dd_BudgetYear.SelectedValue)
        Else
            dt = bao.getReportData_R9_002(UC_Report_SelectDate_Single1.dateSelect) 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป
        End If


        Return dt
    End Function
    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
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
        ' dd_BudgetYear.Items.Insert(0, New ListItem(2557, 2557)) 'เพิ่มใหม่

        'dd_BudgetYear.SelectedValue = 2557
        'dd_BudgetYear.DropDownSelectData(2557)
    End Sub
    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_002.rdlc", "Fields_Report_R9_002", getReportData())
    End Sub
End Class