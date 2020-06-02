Public Class Frm_Report_R5_001_Benefit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_dd_bgyear()

        End If
    End Sub
    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        
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
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
       
        Dim head_id As Integer = 79
        Dim dt_merge As New DataTable
        dt_merge.Columns.Add("bill_date")
        dt_merge.Columns.Add("billnum")
        dt_merge.Columns.Add("description")
        dt_merge.Columns.Add("moneyincome")
        dt_merge.Columns.Add("moneydeposite")
        dt_merge.Columns.Add("balance")
        dt_merge.Columns.Add("payburse")
        dt_merge.Columns.Add("payborrow")
        dt_merge.Columns.Add("MONEY_TYPE_ID")
        dt_merge.Columns.Add("pay")
        dt_merge.Columns.Add("approve", Type.GetType("System.Boolean"))
        dt_merge.Columns.Add("parammoneytype")
        dt_merge.Columns.Add("parammoneysubtype")
        dt_merge.Columns.Add("BUDGET_YEAR")
        dt_merge.Columns.Add("po")
        dt_merge.Columns.Add("no_po")
        dt_merge.Columns.Add("paramdatebegin")
        dt_merge.Columns.Add("paramdateend")
        dt_merge.Columns.Add("checknumber")
        dt_merge.Columns.Add("CUSTOMER_NAME")
        'CUSTOMER_NAME
        dt_merge = get_old_val(dt_merge, head_id)
        Dim first_bal As Double = 0
        If dt_merge.Rows.Count > 0 Then
            first_bal = dt_merge(0)("balance")
        End If
        Dim dt_head As DataTable = bao.get_money_type_2_by_head_id(head_id)
        Dim dt_all As New DataTable
        Dim dt_center As New DataTable
        dt_all = set_dt(dt_all)
        Dim balance As Double = first_bal
        For Each drhead As DataRow In dt_head.Rows
            'Dim id As Integer = 1
            Dim bao_date As New BAO_BUDGET.Report
            Dim strDateBegin As String = "" ' bao_date.convertDateToString(UC_Report_SelectDate_Between.dateBegin)
            Dim strDateEnd As String = "" ' bao_date.convertDateToString(UC_Report_SelectDate_Between.dateEnd)
            Dim dt As DataTable = bao.get_Report_R5_001_year(drhead("MONEY_TYPE_ID"), dd_BudgetYear.SelectedValue) 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป
            dt.Columns.Add("money_type_des")
            For Each dr As DataRow In dt.Rows
                dr("money_type_des") = bindTxtbox(drhead("MONEY_TYPE_ID"))
            Next

            For Each dr_center As DataRow In dt.Rows
                Dim dr_m As DataRow = dt_all.NewRow()
                Try
                    dr_m("bill_date") = CDate(dr_center("bill_date"))
                Catch ex As Exception

                End Try
                dr_m("billnum") = dr_center("billnum")
                dr_m("moneyincome") = dr_center("moneyincome")
                dr_m("moneydeposite") = dr_center("moneydeposite")
                dr_m("payburse") = dr_center("payburse")
                dr_m("payborrow") = dr_center("payborrow")
                dr_m("MONEY_TYPE_ID") = dr_center("MONEY_TYPE_ID")
                dr_m("pay") = dr_center("pay")
                dr_m("description") = dr_center("description")
                dr_m("balance") = dr_center("balance")
                dr_m("approve") = dr_center("approve")
                dr_m("parammoneytype") = dr_center("parammoneytype")
                dr_m("parammoneysubtype") = dr_center("parammoneysubtype")
                dr_m("BUDGET_YEAR") = dr_center("BUDGET_YEAR")
                dr_m("po") = dr_center("po")
                dr_m("no_po") = dr_center("no_po")
                dr_m("paramdatebegin") = dr_center("paramdatebegin")
                dr_m("paramdateend") = dr_center("paramdateend")
                dr_m("checknumber") = dr_center("checknumber")
                dr_m("CUSTOMER_NAME") = dr_center("CUSTOMER_NAME")

                dt_all.Rows.Add(dr_m)
                ' dt_merge.Merge(dt, True, MissingSchemaAction.Ignore)
            Next


        Next
        Dim dv As DataView = dt_all.DefaultView
        dv.Sort = "bill_date ASC"
        dt_all = dv.ToTable

        dt_merge.Merge(dt_all, True, MissingSchemaAction.Ignore)

        For Each dr As DataRow In dt_merge.Rows
            If dr("moneyincome") <> 0 Then
                balance = balance + dr("moneyincome")
            End If
            If dr("payburse") <> 0 Then
                balance = balance - dr("payburse")
            End If
            If dr("payborrow") <> 0 Then
                balance = balance - dr("payborrow")
            End If
            If IsDBNull(dr("po")) = False Then
                If CDbl(dr("po")) <> 0 Then
                    balance = balance - CDbl(dr("po"))
                End If
            End If
            If IsDBNull(dr("no_po")) = False Then
                If CDbl(dr("no_po")) <> 0 Then
                    balance = balance - CDbl(dr("no_po"))
                End If
            End If

            'If CDbl(dr("payborrow")) < 0 Then
            '    'If dr("pay") = "1" Then
            '    '    dr("payburse") = CDbl(dr("payborrow")) * -1
            '    balance = balance - dr("payborrow")
            '    'End If
            'End If
            dr("balance") = balance
        Next

        Return dt_merge

    End Function
    Public Function get_old_val(ByRef dt_merge As DataTable, ByVal head_id As Integer) As DataTable
        'Dim dt_merge As New DataTable
        Dim bao As New BAO_BUDGET.Report
        Dim dt_head As DataTable = bao.get_money_type_2_by_head_id(head_id)
        Dim old_val As Double = 0.0
        For Each drhead As DataRow In dt_head.Rows
            Dim bao_old_balancec As New BAO_BUDGET.DISBURSE_BUDGET
            old_val = old_val + bao_old_balancec.get_old_balance_no_app_year(drhead("MONEY_TYPE_ID"), dd_BudgetYear.SelectedValue)

        Next
        Dim bao_date As New BAO_BUDGET.Report
        'Dim strDateBegin As String = bao_date.convertDateToString(UC_Report_SelectDate_Between.dateBegin)
        'Dim strDateEnd As String = bao_date.convertDateToString(UC_Report_SelectDate_Between.dateEnd)
        
        Dim dr_m As DataRow = dt_merge.NewRow()
        dr_m("bill_date") = DBNull.Value
        dr_m("billnum") = DBNull.Value
        dr_m("moneyincome") = old_val
        dr_m("moneydeposite") = 0
        dr_m("payburse") = 0
        dr_m("payborrow") = 0
        dr_m("MONEY_TYPE_ID") = 0
        dr_m("pay") = 0
        dr_m("description") = "ยอดยกมา :"
        dr_m("balance") = 0
        dr_m("approve") = DBNull.Value
        dr_m("parammoneytype") = ""
        dr_m("parammoneysubtype") = ""
        dr_m("BUDGET_YEAR") = DBNull.Value
        dr_m("po") = 0
        dr_m("no_po") = 0
        dr_m("paramdatebegin") = ""
        dr_m("paramdateend") = ""
        dr_m("checknumber") = ""
        dr_m("CUSTOMER_NAME") = ""
        dt_merge.Rows.Add(dr_m)

        Return dt_merge
    End Function
    Public Function set_dt(ByRef dt_merge As DataTable) As DataTable
        dt_merge.Columns.Add("bill_date", GetType(DateTime))
        dt_merge.Columns.Add("billnum")
        dt_merge.Columns.Add("description")
        dt_merge.Columns.Add("moneyincome")
        dt_merge.Columns.Add("moneydeposite")
        dt_merge.Columns.Add("balance")
        dt_merge.Columns.Add("payburse")
        dt_merge.Columns.Add("payborrow")
        dt_merge.Columns.Add("MONEY_TYPE_ID")
        dt_merge.Columns.Add("pay")
        dt_merge.Columns.Add("approve", Type.GetType("System.Boolean"))
        dt_merge.Columns.Add("parammoneytype")
        dt_merge.Columns.Add("parammoneysubtype")
        dt_merge.Columns.Add("BUDGET_YEAR")
        dt_merge.Columns.Add("po")
        dt_merge.Columns.Add("no_po")
        dt_merge.Columns.Add("paramdatebegin")
        dt_merge.Columns.Add("paramdateend")
        dt_merge.Columns.Add("checknumber")
        dt_merge.Columns.Add("CUSTOMER_NAME")
        Return dt_merge
    End Function

    Public Function bindTxtbox(money_type As Integer) As String
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        dt.Columns.Add("seq")
        dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
        dt.Columns.Add("MONEY_AMOUNT")
        dt.Columns.Add("TYPE_ID")

        dt = baobudget.getMoneyTypeNodeBack(dt, money_type)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "seq desc"
        dt = dv.ToTable
        Dim str As String = ""

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                If IsDBNull(dt(i)("MONEY_TYPE_DESCRIPTION")) = False And IsDBNull(dt(i)("TYPE_ID")) = False Then
                    'Select Case dt(i)("TYPE_ID")
                    '    Case "1"
                    '        lb_level1.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    '    Case "2"
                    '        lb_level2.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    '    Case "3"
                    '        lb_level3.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    '    Case "4"
                    '        lb_level4.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    'End Select
                    str = str & "|" & dt(i)("MONEY_TYPE_DESCRIPTION")


                End If

            Next
        End If
        Return str
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        ' Dim dt As DataTable = getReportData()
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module05\Report_R5_001.rdlc", "Fields_Report_R5_001", getReportData())
    End Sub
End Class