Public Class Frm_Report_R2_018
    Inherits System.Web.UI.Page
    Public _type As String
    Public Sub runquery()
        _type = Request.QueryString("t")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runquery()
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
        UC_Report_SelectDate_Between.getDateSelect()
        Dim date1 As Date = UC_Report_SelectDate_Between.dateBegin
        Dim date2 As Date = UC_Report_SelectDate_Between.dateEnd
        Dim dt As New DataTable

        'เบิกจ่าย
        If _type = "1" Then
            dt = bao.get_Report_R2_018(date1, date2)
            dt.Columns.Add("rep_type") 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(จ่ายตรง)"
            Next
        ElseIf _type = "2" Then 'ลูกหนี้
            dt = bao.get_Report_R2_018_2(date1, date2)
            dt.Columns.Add("rep_type")
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(ลูกหนี้)"
            Next
        ElseIf _type = "3" Then
            dt = bao.get_Report_R2_018_3(date1, date2)
            dt.Columns.Add("rep_type")
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(ค่ารักษาพยาบาลและค่าเล่าเรียนบุตร)"
            Next
        ElseIf _type = "4" Then
            dt = bao.get_Report_R2_018_4(date1, date2)
            dt.Columns.Add("rep_type")
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(เงินนอก)"
            Next
        ElseIf _type = "5" Then
            dt = bao.get_Report_R2_018_5(date1, date2)
            dt.Columns.Add("rep_type")
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(ลูกหนี้เงินนอก)"
            Next
        ElseIf _type = "6" Then
            dt = bao.get_Report_R2_018_7(date1, date2)
            dt.Columns.Add("rep_type")
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(รัฐวิสาหกิจ)"
            Next
        ElseIf _type = "7" Then
            dt = bao.get_Report_R2_018_8(date1, date2)
            dt.Columns.Add("rep_type")
            For Each dr As DataRow In dt.Rows
                dr("rep_type") = "(จ่ายผ่าน)"
            Next
        End If

        Return dt
    End Function
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
    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module02\Report_R2_018.rdlc", "Fields_Report_R2_018", getReportData())
    End Sub
End Class