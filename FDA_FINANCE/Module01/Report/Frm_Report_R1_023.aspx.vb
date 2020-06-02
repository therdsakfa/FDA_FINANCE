Public Class Frm_Report_R1_023
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear(dd_BudgetYear)
        End If
    End Sub
    Public Function getReportData() As DataTable
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between2.getDateSelect()
        UC_Report_Dept_Budget_Adjust1.get_dataselect()

        Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt_node As New DataTable
        dt_node.Columns.Add("seq")
        dt_node.Columns.Add("BUDGET_DESCRIPTION")
        dt_node.Columns.Add("BUDGET_AMOUNT")
        dt_node = bao_node.getNodeBack(dt_node, UC_Report_Dept_Budget_Adjust1.bg_id)
        Dim dv As DataView = dt_node.DefaultView
        dv.Sort = "seq desc"
        dt_node = dv.ToTable

        Dim str_node As String = ""
        For Each dr_node As DataRow In dt_node.Rows
            If CInt(dr_node("seq")) < 6 Then
                str_node = str_node & "|" & dr_node("BUDGET_DESCRIPTION")
            End If

        Next
        Dim bao_period As New BAO_BUDGET.Report
        Dim bao_transfer As New BAO_BUDGET.Report
        Dim bao_diff As New BAO_BUDGET.Report
        Dim dt_period As DataTable = bao_period.get_Report_R1_Period(UC_Report_SelectDate_Between2.dateBegin, UC_Report_SelectDate_Between2.dateEnd, UC_Report_Dept_Budget_Adjust1.bg_id, dd_BudgetYear.SelectedValue)
        For Each dr_period As DataRow In dt_period.Rows
            dr_period("transfer_amount") = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between2.dateBegin, UC_Report_SelectDate_Between2.dateEnd, dr_period("BUDGET_PLAN_ID"))
            dr_period("change_amount") = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between2.dateBegin, UC_Report_SelectDate_Between2.dateEnd, dr_period("BUDGET_PLAN_ID"))
        Next
        dt_period.Columns.Add("balance", Type.GetType("System.Double"))
        dt_period.Columns.Add("parambudgetplan")
        dt_period.Columns.Add("billdate")


        Dim dt As New DataTable
        dt = bao.getReportData_R1_023(UC_Report_SelectDate_Between2.dateBegin, UC_Report_SelectDate_Between2.dateEnd, UC_Report_Dept_Budget_Adjust1.bg_id)
        dt.Columns.Add("balance", Type.GetType("System.Double"))
        dt.Columns.Add("parambudgetplan")
        dt.Columns.Add("billdate")
        dt_period.Merge(dt)
        If dt_period.Rows.Count > 0 Then
            For Each drPO As DataRow In dt_period.Rows
                If IsDBNull(drPO("PO")) = False Then
                    If CDbl(drPO("PO")) < 5000 Then
                        drPO("no_PO") = drPO("PO")
                        drPO("PO") = "0.0"
                    End If

                End If
            Next

            Dim adjust As Double = 0.0
            Dim balance As Double = 0.0
            If IsDBNull(dt_period(0)("adjust_amount")) = False Then
                adjust = dt_period(0)("adjust_amount")
            End If
            balance = adjust
            Dim uti As New Report_Utility
            For Each dr As DataRow In dt_period.Rows
                If CDbl(dr("PO")) > 0 Then
                    balance = balance - CDbl(dr("PO"))
                ElseIf CDbl(dr("no_PO")) > 0 Then
                    balance = balance - CDbl(dr("no_PO"))
                ElseIf CDbl(dr("debtor_amount")) > 0 Then
                    balance = balance - CDbl(dr("debtor_amount"))
                ElseIf CDbl(dr("disburse_amount")) > 0 Then
                    balance = balance - CDbl(dr("disburse_amount"))
                End If

                dr("billdate") = uti.get_short_month(CDate(dr("DOC_DATE")))
                dr("balance") = balance
                dr("parambudgetplan") = str_node

            Next
        End If

        Return dt_period
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_023.rdlc", "Fields_Report_R1_023", getReportData())
    End Sub
End Class