Public Class Frm_Report_R2_010
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function getReportData()
    '    Dim bao As New BAO_BUDGET.Report
    '    Dim dt As DataTable = bao.getReportData_R2_010(rdp_dateReportSelect.SelectedDate)

    '    Return dt
    'End Function

    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report

        'chk_rebill
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dt As DataTable = bao.getReportData_R2_010(UC_Report_SelectDate_Single.dateSelect)

        'Dim dt_new As New DataTable
        'dt_new.Columns.Add("contractnum")
        'dt_new.Columns.Add("contractdate")
        'dt_new.Columns.Add("docnum")
        'dt_new.Columns.Add("customername")
        'dt_new.Columns.Add("customerdescription")
        'dt_new.Columns.Add("moneyamount")
        'dt_new.Columns.Add("moneyreturnfinaldate")
        'dt_new.Columns.Add("CHECK_RECEIVE_DATE")
        ''dt_new.Columns.Add("DEBTOR_BILL_ID")

        'For Each dr As DataRow In dt.Rows
        '    Dim bao_chk As New BAO_BUDGET.Report
        '    Dim bool As Boolean = bao_chk.chk_rebill(rdp_dateReportSelect.SelectedDate, dr("DEBTOR_BILL_ID"))
        '    If bool = False Then
        '        Dim drnew As DataRow = dt_new.NewRow()
        '        drnew("contractnum") = dr("contractnum")
        '        If IsDBNull(dr("contractdate")) = False Then
        '            drnew("contractdate") = CDate(dr("contractdate")).ToShortDateString()
        '        Else
        '            drnew("contractdate") = DBNull.Value
        '        End If

        '        drnew("docnum") = dr("docnum")
        '        drnew("customername") = dr("customername")
        '        drnew("customerdescription") = dr("customerdescription")
        '        drnew("moneyamount") = dr("moneyamount")
        '        If IsDBNull(dr("moneyreturnfinaldate")) = False Then
        '            drnew("moneyreturnfinaldate") = CDate(dr("moneyreturnfinaldate")).ToShortDateString()
        '        Else
        '            drnew("moneyreturnfinaldate") = DBNull.Value
        '        End If
        '        If IsDBNull(dr("CHECK_RECEIVE_DATE")) = False Then
        '            drnew("CHECK_RECEIVE_DATE") = CDate(dr("CHECK_RECEIVE_DATE")).ToShortDateString()
        '        Else
        '            drnew("CHECK_RECEIVE_DATE") = DBNull.Value
        '        End If
        '        dt_new.Rows.Add(drnew)
        '    End If

        'Next

        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module02\Report_R2_010.rdlc", "Fields_Report_R2_010", getReportData())
    End Sub
End Class