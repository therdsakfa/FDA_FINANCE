Public Class Frm_Report_R2_014
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dt As DataTable = bao.getReportData_R2_014(UC_Report_SelectDate_Single.dateSelect) 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป

        Return dt
    End Function

    Public Function getdata() As DataTable
        Dim dt As New DataTable
        Dim a As New Object
        dt = a
        dt.Columns.Add("deposit_amount")
        dt.Columns.Add("debtor_amount")
        dt.Columns.Add("receipt_amount")
        dt.Columns.Add("balance")


        Return dt
    End Function


    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module02\Report_R2_014.rdlc", "Fields_Report_R2_014", getReportData())
    End Sub
End Class