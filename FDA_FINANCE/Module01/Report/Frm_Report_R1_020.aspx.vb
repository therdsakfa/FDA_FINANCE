Public Class Frm_Report_R1_020
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getReportData() As DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept_Plan1.get_dataselect()
        Dim bao As New BAO_BUDGET.Report
        Dim bao_transfer As New BAO_BUDGET.Report
        Dim bao_diff As New BAO_BUDGET.Report
        Dim bao_po As New BAO_BUDGET.Report
        Dim bao_burse As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R1_020(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Plan1.dept)
        dt.Columns.Add("plan")
        dt.Columns.Add("paybudget")
        dt.Columns.Add("transfermoney", Type.GetType("System.Double"))
        dt.Columns.Add("transferdiff")
        dt.Columns.Add("procuremoney")
        dt.Columns.Add("no_po")
        dt.Columns.Add("bursemoney")

        Dim transfer As Double = 0
        Dim diff As Double = 0
        Dim po As Double = 0
        Dim burse As Double = 0
        For Each dr As DataRow In dt.Rows
            dr("plan") = get_group(dr("BUDGET_PLAN_ID"))
            dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID")) & " (แผนที่ " & get_group(dr("BUDGET_PLAN_ID")) & ")"
            transfer = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            diff = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            po = bao_po.getReportData_R1_004_po(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            burse = bao_burse.getReportData_R1_004_burse(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            dr("transfermoney") = transfer
            dr("transferdiff") = diff
            dr("bursemoney") = burse
            If po > 5000 Then
                dr("procuremoney") = po
                dr("no_po") = 0.0
            Else
                dr("procuremoney") = 0
                dr("no_po") = po
            End If
        Next

        'Dim dt_new As New DataTable
        'dt_new.Columns.Add("moneyperiod")
        'dt_new.Columns.Add("plan")
        'dt_new.Columns.Add("bg_des")
        'dt_new.Columns.Add("transfer")
        'dt_new.Columns.Add("diff")
        'dt_new.Columns.Add("po")
        'dt_new.Columns.Add("no_po")
        'dt_new.Columns.Add("burse")
        'For Each dr_new As DataRow In dt.Rows
        '    Dim dr As DataRow = dt_new.NewRow()
        '    dr("moneyperiod") = dr_new("moneyperiod")
        '    dr("plan") = dr_new("plan")
        '    dr("bg_des") = dr_new("bg_des")
        '    dr("transfer") = dr_new("transfer")
        '    dr("diff") = dr_new("diff")
        '    dr("po") = dr_new("po")
        '    dr("no_po") = dr_new("no_po")
        '    dr("burse") = dr_new("burse")

        '    dt_new.Rows.Add(dr)
        'Next


        'Dim drrr As DataTable
        Return dt
    End Function
    Public Function get_bg(bg_id As Integer) As String
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
                If CInt(dr_node("BUDGET_TYPE_ID")) = 6 Then
                    str = dr_node("BUDGET_DESCRIPTION")
                End If
            End If
        Next

        Return str
    End Function
    Public Function get_group(bg_id As Integer) As Integer
        Dim digit As Integer = 0
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
                If CInt(dr_node("BUDGET_TYPE_ID")) = 2 Then
                    digit = dr_node("BUDGET_MAIN_TYPE")
                End If
            End If
        Next

        Return digit
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_020.rdlc", "Fields_Report_R1_020", getReportData())
    End Sub
End Class