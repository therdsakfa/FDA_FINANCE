Public Class Frm_Report_R3_015_4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dt As New DataTable
        If Request.QueryString("law") = "" Then
            dt = bao.get_Report_R3_015_4(UC_Report_SelectDate_Single.dateSelect)
        Else
            dt = bao.get_Report_R3_015_4_law(UC_Report_SelectDate_Single.dateSelect)
        End If


        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_015_4.rdlc", "Fields_Report_R3_015", getReportData())
    End Sub
End Class