Public Class Frm_Report_R1_003
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                UC_Report_Dept_Budget_Adjust_Sub1.set_dd_bgyear()
                UC_Report_Dept_Budget_Adjust_Sub1.bind_ddl_dept()
                UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()
                UC_Report_Dept_Budget_Adjust_Sub1.bind_dl_bg_auto()
                UC_Report_Dept_Budget_Adjust_Sub1.set_bg()

                UC_Report_SelectDate_Between1.set_date()
                UC_Report_SelectDate_Between1.getDateSelect()
                run_report()
            Catch ex As Exception

            End Try
            
        End If
    End Sub
    Public Sub BindData()

        UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()
        UC_Report_Dept_Budget_Adjust_Sub1.set_bg()
        UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
    'Public Function getReportData() As DataTable
    '    Dim bao As New BAO_BUDGET.Report
    '    UC_Report_SelectDate_Between1.getDateSelect()
    '    UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()

    '    Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
    '    Dim dt_node As New DataTable
    '    dt_node.Columns.Add("seq")
    '    dt_node.Columns.Add("BUDGET_DESCRIPTION")
    '    dt_node.Columns.Add("BUDGET_AMOUNT")
    '    dt_node = bao_node.getNodeBack(dt_node, UC_Report_Dept_Budget_Adjust_Sub1.bg_id)
    '    Dim dv As DataView = dt_node.DefaultView
    '    dv.Sort = "seq desc"
    '    dt_node = dv.ToTable

    '    Dim str_node As String = ""
    '    For Each dr_node As DataRow In dt_node.Rows
    '        If CInt(dr_node("seq")) < 6 Then
    '            str_node = str_node & "|" & dr_node("BUDGET_DESCRIPTION")
    '        End If

    '    Next
    '    Dim bao_period As New BAO_BUDGET.Report
    '    Dim bao_transfer As New BAO_BUDGET.Report
    '    Dim bao_diff As New BAO_BUDGET.Report
    '    Dim dt_period As DataTable = bao_period.get_Report_R1_Period(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust1.bg_id)
    '    For Each dr_period As DataRow In dt_period.Rows
    '        dr_period("transfer_amount") = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_period("BUDGET_PLAN_ID"))
    '        dr_period("change_amount") = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_period("BUDGET_PLAN_ID"))
    '    Next
    '    dt_period.Columns.Add("balance", Type.GetType("System.Double"))
    '    dt_period.Columns.Add("parambudgetplan")
    '    dt_period.Columns.Add("billdate")

    '    Dim dt As New DataTable
    '    dt = bao.getReportData_R1_003(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust1.bg_id)
    '    dt.Columns.Add("balance", Type.GetType("System.Double"))
    '    dt.Columns.Add("parambudgetplan")
    '    dt.Columns.Add("billdate")
    '    dt_period.Merge(dt)
    '    If dt.Rows.Count > 0 Then
    '        For Each drPO As DataRow In dt_period.Rows
    '            If IsDBNull(drPO("PO")) = False Then
    '                If CDbl(drPO("PO")) < 5000 Then
    '                    drPO("no_PO") = drPO("PO")
    '                    drPO("PO") = "0.0"
    '                End If

    '            End If
    '        Next

    '        Dim adjust As Double = 0.0
    '        Dim balance As Double = 0.0
    '        If IsDBNull(dt_period(0)("adjust_amount")) = False Then
    '            adjust = dt_period(0)("adjust_amount")
    '        End If
    '        balance = adjust
    '        Dim uti As New Report_Utility
    '        For Each dr As DataRow In dt_period.Rows

    '            If CDbl(dr("PO")) <> 0 Then
    '                balance = balance - CDbl(dr("PO"))
    '            End If
    '            If CDbl(dr("no_PO")) <> 0 Then
    '                balance = balance - CDbl(dr("no_PO"))
    '            End If
    '            If CDbl(dr("debtor_amount")) <> 0 Then
    '                balance = balance - CDbl(dr("debtor_amount"))
    '            End If
    '            If CDbl(dr("disburse_amount")) <> 0 Then
    '                balance = balance - CDbl(dr("disburse_amount"))
    '            End If

    '            'If CDbl(dr("PO")) > 0 Then
    '            '    balance = balance - CDbl(dr("PO"))
    '            'ElseIf CDbl(dr("no_PO")) > 0 Then
    '            '    balance = balance - CDbl(dr("no_PO"))
    '            'ElseIf CDbl(dr("debtor_amount")) > 0 Then
    '            '    balance = balance - CDbl(dr("debtor_amount"))
    '            'ElseIf CDbl(dr("disburse_amount")) > 0 Then
    '            '    balance = balance - CDbl(dr("disburse_amount"))
    '            'End If

    '            dr("billdate") = uti.get_short_month(CDate(dr("DOC_DATE")))
    '            dr("balance") = balance
    '            dr("parambudgetplan") = str_node

    '        Next
    '    End If

    '    Return dt
    'End Function
    Public Function getReportData_NEW() As DataTable
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()

        Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt_node As New DataTable
        dt_node.Columns.Add("seq")
        dt_node.Columns.Add("BUDGET_DESCRIPTION")
        dt_node.Columns.Add("BUDGET_AMOUNT")
        dt_node = bao_node.getNodeBack(dt_node, UC_Report_Dept_Budget_Adjust_Sub1.bg_id)
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
        Dim dt_period As DataTable = bao_period.get_Report_R1_Period(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust_Sub1.bg_id, UC_Report_Dept_Budget_Adjust_Sub1.bgyear)
        'For Each dr_period As DataRow In dt_period.Rows
        '    dr_period("transfer_amount") = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_period("BUDGET_PLAN_ID"))
        '    dr_period("change_amount") = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_period("BUDGET_PLAN_ID"))
        'Next
        dt_period.Columns.Add("balance", Type.GetType("System.Double"))
        dt_period.Columns.Add("parambudgetplan")
        dt_period.Columns.Add("billdate")

        Dim dt As New DataTable
        dt = bao.get_Report_R1_003_1(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust_Sub1.bg_id, UC_Report_Dept_Budget_Adjust_Sub1.bgyear)
        dt.Columns.Add("balance", Type.GetType("System.Double"))
        dt.Columns.Add("parambudgetplan")
        dt.Columns.Add("billdate")
        dt_period.Merge(dt)
        If dt_period.Rows.Count > 0 Then
            For Each drPO As DataRow In dt_period.Rows

                If IsDBNull(drPO("PO")) = False Then
                    If CDbl(drPO("PO")) < 5000 And CDbl(drPO("PO")) > 0 Then
                        drPO("no_PO") = drPO("PO")
                        drPO("PO") = "0.0"
                    End If

                End If
            Next

            Dim adjust As Double = 0.0
            Dim transfer_amount As Double = 0.0
            Dim change_amount As Double = 0.0
            Dim balance As Double = 0.0
            If IsDBNull(dt_period(0)("adjust_amount")) = False Then
                adjust = dt_period(0)("adjust_amount")
            End If
            If IsDBNull(dt_period(0)("transfer_amount")) = False Then
                transfer_amount = dt_period(0)("transfer_amount")
            End If
            If IsDBNull(dt_period(0)("change_amount")) = False Then
                change_amount = dt_period(0)("change_amount")
            End If
            balance = adjust + transfer_amount + change_amount
            Dim uti As New Report_Utility
            For Each dr As DataRow In dt_period.Rows
                If IsDBNull(dr("PO")) = False Then
                    If CDbl(dr("PO")) <> 0 Then
                        balance = balance - CDbl(dr("PO"))
                    End If
                End If
                If IsDBNull(dr("no_PO")) = False Then
                    If CDbl(dr("no_PO")) <> 0 Then
                        balance = balance - CDbl(dr("no_PO"))
                    End If
                End If
                If IsDBNull(dr("debtor_amount")) = False Then
                    If CDbl(dr("debtor_amount")) <> 0 Then
                        balance = balance - CDbl(dr("debtor_amount"))
                    End If
                End If
                If IsDBNull(dr("disburse_amount")) = False Then
                    If CDbl(dr("disburse_amount")) <> 0 Then
                        balance = balance - CDbl(dr("disburse_amount"))
                    End If
                End If
                If IsDBNull(dr("change_amount")) = False Then
                    If CDbl(dr("change_amount")) <> 0 Then
                        balance = balance + CDbl(dr("change_amount"))
                    End If
                End If
                'If CDbl(dr("PO")) <> 0 Then
                '    balance = balance - CDbl(dr("PO"))
                'ElseIf CDbl(dr("no_PO")) <> 0 Then
                '    balance = balance - CDbl(dr("no_PO"))
                'ElseIf CDbl(dr("debtor_amount")) <> 0 Then
                '    balance = balance - CDbl(dr("debtor_amount"))
                'ElseIf CDbl(dr("disburse_amount")) <> 0 Then
                '    balance = balance - CDbl(dr("disburse_amount"))
                'End If

                dr("billdate") = uti.get_short_month(CDate(dr("DOC_DATE")))
                dr("balance") = balance
                dr("parambudgetplan") = str_node

            Next
        End If




        Return dt_period

    End Function
    Public Function getReportData_sup() As DataTable
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()
        Dim dt_temp As New DataTable
        Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt_node As New DataTable
        dt_node.Columns.Add("seq")
        dt_node.Columns.Add("BUDGET_DESCRIPTION")
        dt_node.Columns.Add("BUDGET_AMOUNT")
        dt_node = bao_node.getNodeBack(dt_node, UC_Report_Dept_Budget_Adjust_Sub1.bg_id)
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
        'Dim dt_period As DataTable = bao_period.get_Report_R1_Period_support(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust1.bg_id)
        'For Each dr_period As DataRow In dt_period.Rows
        '    dr_period("transfer_amount") = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_period("PATLIST_ID"))
        '    dr_period("change_amount") = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_period("PATLIST_ID"))
        'Next
        'dt_period.Columns.Add("balance", Type.GetType("System.Double"))
        'dt_period.Columns.Add("parambudgetplan")
        'dt_period.Columns.Add("billdate")
        Dim bao_sup_key As New BAO_BUDGET.Report
        Dim dt_sup_bg_key As DataTable = bao_sup_key.get_support_bg_key(UC_Report_Dept_Budget_Adjust_Sub1.bg_id)
        For Each dr_p As DataRow In dt_sup_bg_key.Rows
            Dim dt As New DataTable
            dt = bao.get_Report_R1_003_support(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr_p("BUDGET_PLAN_ID"), UC_Report_Dept_Budget_Adjust_Sub1.bgyear)
            dt.Columns.Add("balance", Type.GetType("System.Double"))
            dt.Columns.Add("parambudgetplan")
            dt.Columns.Add("billdate")
            ' dt_period.Merge(dt)
            If dt.Rows.Count > 0 Then
                For Each drPO As DataRow In dt.Rows

                    If IsDBNull(drPO("PO")) = False Then
                        If CDbl(drPO("PO")) < 5000 And CDbl(drPO("PO")) > 0 Then
                            drPO("no_PO") = drPO("PO")
                            drPO("PO") = "0.0"
                        End If

                    End If
                Next

                Dim adjust As Double = 0.0
                Dim balance As Double = 0.0
                'If IsDBNull(dt_period(0)("adjust_amount")) = False Then
                '    adjust = dt_period(0)("adjust_amount")
                'End If
                Dim dao_p As New DAO_BUDGET.TB_BUDGET_ADJUST
                If dr_p("BUDGET_PLAN_ID") IsNot Nothing Then
                    dao_p.Getdata_by_BUDGET_PLAN_ID(dr_p("BUDGET_PLAN_ID"))
                    balance = dao_p.fields.BUDGET_DEPARTMENT_MONEY

                End If

                Dim uti As New Report_Utility
                For Each dr As DataRow In dt.Rows
                    If IsDBNull(dr("PO")) = False Then
                        If CDbl(dr("PO")) <> 0 Then
                            balance = balance - CDbl(dr("PO"))
                        End If
                    End If
                    If IsDBNull(dr("no_PO")) = False Then
                        If CDbl(dr("no_PO")) <> 0 Then
                            balance = balance - CDbl(dr("no_PO"))
                        End If
                    End If
                    If IsDBNull(dr("debtor_amount")) = False Then
                        If CDbl(dr("debtor_amount")) <> 0 Then
                            balance = balance - CDbl(dr("debtor_amount"))
                        End If
                    End If
                    If IsDBNull(dr("disburse_amount")) = False Then
                        If CDbl(dr("disburse_amount")) <> 0 Then
                            balance = balance - CDbl(dr("disburse_amount"))
                        End If
                    End If
                    'If dr("seq") = "1" Then
                    '    dr("transfer_amount") = bao_transfer.getReportData_R1_004_transfer(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("PATLIST_ID"))
                    '    dr("change_amount") = bao_diff.getReportData_R1_004_diff(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("PATLIST_ID"))
                    'End If



                    'If CDbl(dr("PO")) <> 0 Then
                    '    balance = balance - CDbl(dr("PO"))
                    'ElseIf CDbl(dr("no_PO")) <> 0 Then
                    '    balance = balance - CDbl(dr("no_PO"))
                    'ElseIf CDbl(dr("debtor_amount")) <> 0 Then
                    '    balance = balance - CDbl(dr("debtor_amount"))
                    'ElseIf CDbl(dr("disburse_amount")) <> 0 Then
                    '    balance = balance - CDbl(dr("disburse_amount"))
                    'End If

                    dr("billdate") = uti.get_short_month(CDate(dr("DOC_DATE")))
                    dr("balance") = balance
                    dr("parambudgetplan") = str_node

                Next

                dt_temp.Merge(dt)
            End If
        Next



        Return dt_temp


    End Function
    Public Function getReportData_sup_Only() As DataTable
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()
        UC_Report_Dept_Budget_Adjust_Sub1.set_bg()
        Dim dt_temp As New DataTable
        Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_ad As New BAO_BUDGET.MASS
        Dim dt_node As New DataTable
        dt_node.Columns.Add("seq")
        dt_node.Columns.Add("BUDGET_DESCRIPTION")
        dt_node.Columns.Add("BUDGET_AMOUNT")
        dt_node = bao_node.getNodeBack(dt_node, UC_Report_Dept_Budget_Adjust_Sub1.bg_id) '
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
        Dim bao_sup_key As New BAO_BUDGET.Report

        'Dim dt_sup_bg_key As DataTable = bao_sup_key.get_support_bg_key(bao_ad.get_bg_head_id(UC_Report_Dept_Budget_Adjust_Sub1.bg_id)) '
        'For Each dr_p As DataRow In dt_sup_bg_key.Rows
        Dim dt As New DataTable
        dt = bao.get_Report_R1_003_support(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, UC_Report_Dept_Budget_Adjust_Sub1.sub_bg, UC_Report_Dept_Budget_Adjust_Sub1.bgyear)
        dt.Columns.Add("balance", Type.GetType("System.Double"))
        dt.Columns.Add("parambudgetplan")
        dt.Columns.Add("billdate")
        ' dt_period.Merge(dt)
        If dt.Rows.Count > 0 Then
            For Each drPO As DataRow In dt.Rows

                If IsDBNull(drPO("PO")) = False Then
                    If CDbl(drPO("PO")) < 5000 And CDbl(drPO("PO")) > 0 Then
                        drPO("no_PO") = drPO("PO")
                        drPO("PO") = "0.0"
                    End If

                End If
            Next

            Dim adjust As Double = 0.0
            Dim balance As Double = 0.0
            Dim transfer_amount As Double = 0.0
            Dim change_amount As Double = 0.0
            Dim chk_period As Boolean = True

            Dim dao_p As New DAO_BUDGET.TB_BUDGET_ADJUST
            ' If dr_p("BUDGET_PLAN_ID") IsNot Nothing Then
            dao_p.Getdata_by_BUDGET_PLAN_ID(UC_Report_Dept_Budget_Adjust_Sub1.sub_bg)
            balance = dao_p.fields.BUDGET_DEPARTMENT_MONEY

            'End If

            Dim uti As New Report_Utility
            For Each dr As DataRow In dt.Rows
                If IsDBNull(dr("PO")) = False Then
                    If CDbl(dr("PO")) <> 0 Then
                        balance = balance - CDbl(dr("PO"))
                    End If
                End If
                If IsDBNull(dr("no_PO")) = False Then
                    If CDbl(dr("no_PO")) <> 0 Then
                        balance = balance - CDbl(dr("no_PO"))
                    End If
                End If
                If IsDBNull(dr("debtor_amount")) = False Then
                    If CDbl(dr("debtor_amount")) <> 0 Then
                        balance = balance - CDbl(dr("debtor_amount"))
                    End If
                End If
                If IsDBNull(dr("disburse_amount")) = False Then
                    If CDbl(dr("disburse_amount")) <> 0 Then
                        balance = balance - CDbl(dr("disburse_amount"))
                    End If
                End If
                If IsDBNull(dr("change_amount")) = False Then
                    If CDbl(dr("change_amount")) <> 0 Then
                        balance = balance + CDbl(dr("change_amount"))
                    End If
                End If
                If IsDBNull(dr("transfer_amount")) = False Then
                    If CDbl(dr("transfer_amount")) <> 0 Then
                        balance = balance + CDbl(dr("transfer_amount"))
                    End If
                End If

                dr("billdate") = uti.get_short_month(CDate(dr("DOC_DATE")))
                dr("balance") = balance
                dr("parambudgetplan") = str_node

            Next

            dt_temp.Merge(dt)
        End If
        'Next



        Return dt_temp


    End Function
    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        'Dim util As New Report_Utility
        'util.report = ReportViewer1
        'util.configWidthHeight()
        'util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_003.rdlc", "Fields_Report_R1_003", getReportData())
       
        'util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_001.rdlc", "Fields_Report_R1_001", getReportData())
        run_report()

        'Dim util As New Report_Utility
        'util.report = ReportViewer1
        'util.configWidthHeight()
        'UC_Report_Dept_Budget_Adjust1.get_dataselect()
        'Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        'If UC_Report_Dept_Budget_Adjust1.bg_id <> 0 Then
        '    dao.Getdata_by_BUDGET_PLAN_ID(UC_Report_Dept_Budget_Adjust1.bg_id)
        '    If dao.fields.BUDGET_IS_SUPPORT_DEPT = True Then
        '        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_003_sup.rdlc", "Fields_Report_R1_003", getReportData_sup())
        '    Else
        '        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_003.rdlc", "Fields_Report_R1_003", getReportData_NEW())
        '    End If

        'End If
    End Sub

    Public Sub run_report()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        UC_Report_Dept_Budget_Adjust_Sub1.get_dataselect()
        UC_Report_Dept_Budget_Adjust_Sub1.set_bg()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        dao.Getdata_by_BUDGET_PLAN_ID(UC_Report_Dept_Budget_Adjust_Sub1.bg_id)
        If dao.fields.BUDGET_IS_SUPPORT_DEPT = True Then
            If UC_Report_Dept_Budget_Adjust_Sub1.sub_bg = 0 Then
                util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_003_sup.rdlc", "Fields_Report_R1_003", getReportData_sup())
            Else
                util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_003_sup.rdlc", "Fields_Report_R1_003", getReportData_sup_Only())
            End If

        Else
            util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_003.rdlc", "Fields_Report_R1_003", getReportData_NEW())
        End If

    End Sub
End Class