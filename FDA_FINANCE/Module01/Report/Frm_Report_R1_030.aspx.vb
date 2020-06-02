Public Class Frm_Report_R1_030
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
        Dim bao_transfer As New BAO_BUDGET.Report
        Dim bao_diff As New BAO_BUDGET.Report
        Dim bao_po As New BAO_BUDGET.Report
        Dim bao_burse As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R1_009(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd)
        dt.Columns.Add("plan")
        dt.Columns.Add("paybudget")
        dt.Columns.Add("transfermoney")
        dt.Columns.Add("transferdiff")
        dt.Columns.Add("procuremoney")
        dt.Columns.Add("no_po")
        dt.Columns.Add("bursemoney")

        Dim transfer As Double = 0
        Dim diff As Double = 0
        Dim po As Double = 0
        Dim burse As Double = 0
        Dim borrowmoney As Double = 0
        For Each dr As DataRow In dt.Rows
            'dr("plan") = get_group(dr("BUDGET_PLAN_ID"))
            'dr("paybudget") = get_bg(dr("BUDGET_PLAN_ID")) & " (แผนที่ " & get_group(dr("BUDGET_PLAN_ID")) & ")"
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

            'transfer = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            'Dim bao_plan_sub_7 As New BAO_BUDGET.Report
            'Dim dt_sub7 As DataTable = bao_plan_sub_7.get_sub_plan_7(dr("BUDGET_PLAN_ID"))
            'diff = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            'For Each dr_sub As DataRow In dt_sub7.Rows
            '    diff = diff + bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_sub("BUDGET_PLAN_ID"))
            'Next

            If IsDBNull(dr("BUDGET_PLAN_ID")) = False Then
                Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
                dao_plan.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_PLAN_ID"))
                If dao_plan.fields.BUDGET_IS_SUPPORT_DEPT = True Then

                    Dim bao_sup_key As New BAO_BUDGET.Report
                    Dim dt_sup_bg_key As DataTable = bao_sup_key.get_support_bg_key(dr("BUDGET_PLAN_ID"))
                    Dim cal_transfer As Double = 0
                    Dim cal_diff As Double = 0
                    For Each dr_sub As DataRow In dt_sup_bg_key.Rows
                        cal_transfer = cal_transfer + bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_sub("BUDGET_PLAN_ID"))
                        cal_diff = cal_diff + bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_sub("BUDGET_PLAN_ID"))
                    Next
                    transfer = cal_transfer
                    diff = cal_diff
                Else
                    transfer = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
                    diff = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))

                End If
            End If



            po = bao_po.getReportData_R1_009_po(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            burse = bao_burse.getReportData_R1_009_burse(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            borrowmoney = bao.getReportData_R1_009_moneyborrow(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            dr("transfermoney") = transfer
            dr("transferdiff") = diff
            dr("bursemoney") = burse + borrowmoney
            dr("procuremoney") = po
            'If po > 5000 Then
            '    dr("procuremoney") = po
            '    dr("no_po") = 0
            'Else
            '    dr("procuremoney") = 0
            '    dr("no_po") = po
            'End If
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

        Return dt
    End Function

    Public Function getReportData_New() As DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.get_Report_R1_009_1_no_app(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dd_BudgetYear.SelectedValue)
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
    Protected Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        run_report()
    End Sub
    Public Sub run_report()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_030.rdlc", "Fields_Report_R1_009", getReportData_New())
    End Sub

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
End Class