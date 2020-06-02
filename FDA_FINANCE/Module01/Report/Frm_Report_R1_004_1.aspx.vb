Public Class Frm_Report_R1_004_1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()
            Try
               Dim depid As Integer = 0
                depid = Request.QueryString("dept")
                Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
                dao_dep.Getdata_by_DEPARTMENT_ID(depid)
                'If dao.fields.PERMISSION_ID = 2 Then
                '    Label1.Text = "หน่วยงาน  " & dao_dep.fields.DEPARTMENT_DESCRIPTION
                '    Panel1.Style.Add("Display", "none")
                'Else

                'End If

            Catch ex As Exception

            End Try

            UC_Report_SelectDate_Between1.set_date()
            UC_Report_SelectDate_Between1.getDateSelect()
            UC_Report_Dept1.bind_ddl_dept()
            UC_Report_Dept1.get_dept_select()

            run_report()
        End If
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
    Public Sub BindData()
        UC_Report_Dept1.get_dept_select()
        UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
    Public Function getReportData() As DataTable
        Dim dt_return As New DataTable
        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept1.get_dept_select()
        'Dim bg_id As Integer = UC_Report_Dept_Plan1.bg_id
        Dim bao As New BAO_BUDGET.Report
        Dim bao_transfer As New BAO_BUDGET.Report
        Dim bao_diff As New BAO_BUDGET.Report
        Dim bao_po As New BAO_BUDGET.Report
        Dim bao_no_po As New BAO_BUDGET.Report
        Dim bao_moneyborrow As New BAO_BUDGET.Report
        Dim bao_burse As New BAO_BUDGET.Report




        'Dim dao As New DAO_USER.TB_tbl_USER
        'Dim strUserName As String = Session("AD")
        'dao.Getdata_by_AD_NAME(strUserName)
        Dim depid As Integer = 0
        'If dao.fields.PERMISSION_ID = 2 Then
        '    depid = dao.fields.DEPARTMENT_ID
        'Else
        depid = UC_Report_Dept1.dept
        'End If

        Dim dt As DataTable = bao.getReportData_R1_004(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, depid)
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
        Dim no_po As Double = 0
        Dim moneyborrow As Double = 0
        Dim burse As Double = 0
        For Each dr As DataRow In dt.Rows

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

            po = bao_po.getReportData_R1_004_po(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            no_po = bao_no_po.get_Report_R1_004_no_po(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            moneyborrow = bao_moneyborrow.getReportData_R1_004_moneyborrow(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            burse = bao_burse.getReportData_R1_004_burse(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, dr("BUDGET_PLAN_ID"))
            dr("transfer") = transfer
            dr("diff") = diff
            dr("moneyborrow") = moneyborrow
            dr("burse") = burse
            dr("po") = po
            dr("no_po") = no_po
            'If po > 5000 Then
            '    dr("po") = po
            '    dr("no_po") = 0.0
            'ElseIf po < 5000 Then
            '    dr("po") = 0.0
            '    dr("no_po") = po
            'End If

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
    Public Function getReportDate_New() As DataTable

        UC_Report_SelectDate_Between1.getDateSelect()
        UC_Report_Dept1.get_dept_select()
        Dim bao_report As New BAO_BUDGET.Report
        'Dim dao As New DAO_USER.TB_tbl_USER
        'Dim strUserName As String = Session("AD")
        'dao.Getdata_by_AD_NAME(strUserName)
        Dim depid As Integer = 0
        'If dao.fields.PERMISSION_ID = 2 Then
        'depid = dao.fields.DEPARTMENT_ID
        'Else
        depid = UC_Report_Dept1.dept
        'End If
        Dim dt As DataTable = bao_report.get_Report_R1_004_1(UC_Report_SelectDate_Between1.dateBegin, UC_Report_SelectDate_Between1.dateEnd, depid, dd_BudgetYear.SelectedValue)
        dt.Columns.Add("department")
        For Each dr As DataRow In dt.Rows
            Dim bao_node As New BAO_BUDGET.DISBURSE_BUDGET
            Dim dt_node As New DataTable
            dt_node.Columns.Add("seq")
            dt_node.Columns.Add("BUDGET_DESCRIPTION")
            dt_node.Columns.Add("BUDGET_AMOUNT")
            dt_node = bao_node.getNodeBack(dt_node, dr("BUDGET_PLAN_ID"))
            Dim dv As DataView = dt_node.DefaultView
            dv.Sort = "seq desc"
            dt_node = dv.ToTable

            For Each dr_node As DataRow In dt_node.Rows
                If CInt(dr_node("seq")) = 2 Then
                    dr("department") = dr_node("BUDGET_DESCRIPTION")
                End If

            Next
        Next

        Return dt
    End Function
    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        run_report()
    End Sub
    Public Sub run_report()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module01\Report_R1_004_1.rdlc", "Fields_Report_R1_004", getReportDate_New())
    End Sub

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        UC_Report_Dept1.get_dept_select()
        UC_Report_SelectDate_Between1.getDateSelect()
        run_report()
    End Sub
End Class