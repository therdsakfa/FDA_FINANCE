Public Class Frm_Report_R3_003
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim dao_margin As New DAO_DISBURSE.TB_MAS_MARGIN
        dao_margin.Getdata_by_year(2557)
        Dim cash As Double = 0
        Try
            cash = dao_margin.fields.CASH_AMOUNT
        Catch ex As Exception

        End Try

        Dim bank As Double = 0
        Try
            bank = dao_margin.fields.BANK_AMOUNT
        Catch ex As Exception

        End Try
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between.getDateSelect()
        Dim dt As DataTable = bao.getReportData_R3_003(UC_Report_SelectDate_Between.dateBegin, UC_Report_SelectDate_Between.dateEnd) 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป
        dt.Columns.Add("shortdate")
        dt.Columns.Add("cash_balance")
        dt.Columns.Add("bank_balance")
        Dim uti As New Report_Utility
        For Each dr As DataRow In dt.Rows
            dr("shortdate") = uti.get_short_month(CDate(dr("DOC_DATE")))
            dr("cash_balance") = (cash + CDbl(dr("receive_amount"))) - CDbl(dr("maintain_bank"))
            dr("bank_balance") = bank + cash
        Next

        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        'Dim dt As DataTable = getReportData()

        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_003.rdlc", "Fields_Report_R3_003", getReportData())
    End Sub
End Class