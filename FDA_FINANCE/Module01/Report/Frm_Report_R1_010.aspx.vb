Public Class Frm_Report_R1_010
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
            UC_Report_SelectDate_Between1.set_date()
            UC_Report_SelectDate_Between1.getDateSelect()

            run_report()
        End If
    End Sub

    Public Sub BindData()
        UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
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
    Public Function getReportData() As DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.get_Report_R1_009_1(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dd_BudgetYear.SelectedValue)
        dt.Columns.Add("plan")
        dt.Columns.Add("paybudget")
        For Each dr As DataRow In dt.Rows
            dr("plan") = get_group(dr("BUDGET_PLAN_ID"))
            Dim digit As Integer = 0
            digit = get_group(dr("BUDGET_PLAN_ID"))

            If digit = 1 Then
                dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID")) & " NON"
            ElseIf digit = 2 Then
                dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID")) & " CS1"
            ElseIf digit = 3 Then
                dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID")) & " CS2"
            Else
                dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID"))
            End If


        Next

        'UC_Report_SelectDate_Between1.getDateSelect()
        'Dim bao As New BAO_BUDGET.Report
        'Dim bao_transfer As New BAO_BUDGET.Report
        'Dim bao_diff As New BAO_BUDGET.Report
        'Dim bao_po As New BAO_BUDGET.Report
        'Dim bao_burse As New BAO_BUDGET.Report
        'Dim dt As DataTable = bao.getReportData_R1_010(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
        'dt.Columns.Add("plan")
        'dt.Columns.Add("paybudget")
        'dt.Columns.Add("transfermoney")
        'dt.Columns.Add("transferdiff")
        'dt.Columns.Add("procuremoney")
        'dt.Columns.Add("no_po")
        'dt.Columns.Add("bursemoney")

        'Dim transfer As Double = 0
        'Dim diff As Double = 0
        'Dim po As Double = 0
        'Dim burse As Double = 0
        'Dim borrowmoney As Double = 0
        'For Each dr As DataRow In dt.Rows
        '    dr("plan") = get_group(dr("BUDGET_PLAN_ID"))
        '    dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID")) & " (แผนที่ " & get_group(dr("BUDGET_PLAN_ID")) & ")"
        '    transfer = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
        '    diff = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
        '    po = bao_po.getReportData_R1_009_po(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
        '    burse = bao_burse.getReportData_R1_009_burse(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
        '    borrowmoney = bao.getReportData_R1_009_moneyborrow(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
        '    dr("transfermoney") = transfer
        '    dr("transferdiff") = diff
        '    dr("bursemoney") = burse + borrowmoney
        '    dr("procuremoney") = po

        'Next


        


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
        run_report()
    End Sub
    Public Sub run_report()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_010.rdlc", "Fields_Report_R1_010", getReportData())
    End Sub

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
End Class