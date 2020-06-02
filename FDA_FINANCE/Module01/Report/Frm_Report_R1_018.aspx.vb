Public Class Frm_Report_R1_018
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getReportData() As DataTable
        Dim dt_return As New DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept_Plan1.get_dataselect()
        Dim bao As New BAO_BUDGET.Report
        Dim bao_transfer As New BAO_BUDGET.Report
        Dim bao_diff As New BAO_BUDGET.Report
        Dim bao_po As New BAO_BUDGET.Report
        Dim bao_moneyborrow As New BAO_BUDGET.Report
        Dim bao_burse As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R1_018(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Plan1.dept)
        dt.Columns.Add("department")
        dt.Columns.Add("transfer")
        dt.Columns.Add("diff")
        dt.Columns.Add("po")
        dt.Columns.Add("no_po")
        dt.Columns.Add("moneyborrow")
        dt.Columns.Add("burse")
        dt.Columns.Add("maintain")
        dt.Columns.Add("balance")

        Dim transfer As Double = 0
        Dim diff As Double = 0
        Dim po As Double = 0
        Dim moneyborrow As Double = 0
        Dim burse As Double = 0
        For Each dr As DataRow In dt.Rows
            transfer = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            diff = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            po = bao_po.getReportData_R1_004_po(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            moneyborrow = bao_moneyborrow.getReportData_R1_004_moneyborrow(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            burse = bao_burse.getReportData_R1_004_burse(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            dr("transfer") = transfer
            dr("diff") = diff
            dr("moneyborrow") = moneyborrow
            dr("burse") = burse
            If po > 5000 Then
                dr("po") = po
                dr("no_po") = 0.0
            Else
                dr("po") = 0.0
                dr("no_po") = po
            End If

            Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
            Dim dt_node As New DataTable
            dt_node.Columns.Add("seq")
            dt_node.Columns.Add("BUDGET_DESCRIPTION")
            dt_node.Columns.Add("BUDGET_AMOUNT")
            dt_node = bao_node.getNodeBack(dt_node, dr("BUDGET_PLAN_ID"))
            Dim dv As DataView = dt_node.DefaultView
            dv.Sort = "seq desc"
            dt_node = dv.ToTable

            'Dim str_node As String = ""
            For Each dr_node As DataRow In dt_node.Rows
                If CInt(dr_node("seq")) = 2 Then
                    dr("department") = dr_node("BUDGET_DESCRIPTION")
                End If

            Next


        Next

        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_018.rdlc", "Fields_Report_R1_018", getReportData())
    End Sub
End Class