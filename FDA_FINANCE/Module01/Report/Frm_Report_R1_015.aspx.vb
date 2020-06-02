Public Class Frm_Report_R1_015
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function getReportData() As DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept_Budget_Adjust1.get_dataselect()
        Dim bao As New BAO_BUDGET.Report
        Dim bao_transfer As New BAO_BUDGET.Report
        Dim bao_diff As New BAO_BUDGET.Report
        Dim bao_po As New BAO_BUDGET.Report
        Dim bao_burse As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R1_015(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust1.dept)
        dt.Columns.Add("projectactivity")
        For Each dr As DataRow In dt.Rows
            dr("projectactivity") = get_bg(dr("BUDGET_PLAN_ID"), 5)
        Next


        Return dt
    End Function
    Public Function get_bg(bg_id As Integer, floor As Integer) As String
        Dim str As String = ""
        Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt_node As New DataTable
        dt_node.Columns.Add("seq")
        dt_node.Columns.Add("BUDGET_DESCRIPTION")
        dt_node.Columns.Add("BUDGET_AMOUNT")
        dt_node.Columns.Add("BUDGET_MAIN_TYPE")
        dt_node.Columns.Add("BUDGET_TYPE_ID")
        dt_node = bao_node.getNodeBack_report(dt_node, bg_id)
        Dim dv As DataView = dt_node.DefaultView
        dv.Sort = "seq desc"
        dt_node = dv.ToTable

        Dim str_node As String = ""
        For Each dr_node As DataRow In dt_node.Rows
            If IsDBNull(dr_node("BUDGET_TYPE_ID")) = False Then
                If CInt(dr_node("BUDGET_TYPE_ID")) = floor Then
                    str = dr_node("BUDGET_DESCRIPTION")
                End If
            End If
        Next

        Return str
    End Function

    Protected Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_015.rdlc", "Fields_Report_R1_015", getReportData())
    End Sub
End Class