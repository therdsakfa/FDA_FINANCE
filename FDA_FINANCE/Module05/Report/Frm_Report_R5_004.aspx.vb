Public Class Frm_Report_R5_004
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
        UC_Report_SelectDate_Between.getDateSelect()
        'UC_Report_SelectDate_Between.dateBegin, UC_Report_SelectDate_Between.dateEnd
        Dim dt As DataTable = bao.getReportData_R5_004() 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป
        For Each dr As DataRow In dt.Rows
            Dim bao_r_amount As New BAO_BUDGET.Report
            Dim bao_d_amount As New BAO_BUDGET.Report
            Dim r_amount As Double = 0
            Dim d_amount As Double = 0

            r_amount = bao_r_amount.get_Report_R5_004_receive_amount(UC_Report_SelectDate_Between.dateBegin, UC_Report_SelectDate_Between.dateEnd, dr("MONEY_TYPE_ID"))
            d_amount = bao_r_amount.get_Report_R5_004_deposit_amount(UC_Report_SelectDate_Between.dateBegin, UC_Report_SelectDate_Between.dateEnd, dr("MONEY_TYPE_ID"))

            dr("receivemoneyamount") = r_amount
            dr("depositeamount") = d_amount
        Next


        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim dt As DataTable = getReportData()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module05\Report_R5_004.rdlc", "Fields_Report_R5_004", getReportData())
    End Sub
End Class