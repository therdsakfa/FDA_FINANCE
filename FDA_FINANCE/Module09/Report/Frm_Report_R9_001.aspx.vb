Public Class Frm_Report_R9_001
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim flag As String = Request.QueryString("flag")
            If flag <> "" Then
                If flag = "bill" Then
                    Dim util As New Report_Utility
                    util.report = ReportViewer1
                    util.configWidthHeight()
                    util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", getReportData())
                ElseIf flag = "debtor" Then
                    Dim util As New Report_Utility
                    util.report = ReportViewer1
                    util.configWidthHeight()
                    util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", getReportData_debtor())
                ElseIf flag = "mdebtor" Then
                    Dim util As New Report_Utility
                    util.report = ReportViewer1
                    util.configWidthHeight()
                    util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", getReportData_debtor_multi())
                ElseIf flag = "mbill" Then
                    If Request.QueryString("did") IsNot Nothing Then
                        Dim util As New Report_Utility
                        util.report = ReportViewer1
                        util.configWidthHeight()
                        If Request.QueryString("t") IsNot Nothing Then
                            If Request.QueryString("t") = "2" Then
                                util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_006.rdlc", "Fields_Report_R9_001", get_Report_R9_001_bill(Request.QueryString("did")))
                            Else
                                util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", get_Report_R9_001_bill(Request.QueryString("did")))
                            End If
                        Else
                            util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", get_Report_R9_001_bill(Request.QueryString("did")))
                        End If

                    End If
                    'get_Report_R9_001_Other
                ElseIf flag = "mother" Then
                    If Request.QueryString("did") IsNot Nothing Then
                        Dim util As New Report_Utility
                        util.report = ReportViewer1
                        util.configWidthHeight()
                        util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", get_Report_R9_001_Other(Request.QueryString("did")))
                    End If
                ElseIf flag = "margin" Then
                    Dim util As New Report_Utility
                    util.report = ReportViewer1
                    util.configWidthHeight()
                    util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", get_Report_Withdraw_Margin(Request.QueryString("bid")))
                ElseIf flag = "ot" Then
                    Dim util As New Report_Utility
                    util.report = ReportViewer1
                    util.configWidthHeight()
                    util.ShowReport(ReportViewer1, util.root & "Module09\Report_R9_001.rdlc", "Fields_Report_R9_001", get_Report_Other_Pay(Request.QueryString("bid")))
                End If
            End If

            
        End If
    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bgid As String = "0"
        If Request.QueryString("id") <> "" Then
            bgid = Request.QueryString("id")
        End If
        Dim bao As New BAO_BUDGET.Report
        Dim cast_money As New BAO_BUDGET.MoneyExt
        Dim dt As DataTable = bao.getReportData_R9_001(bgid)
        For Each dr As DataRow In dt.Rows
            dr("amounttext") = cast_money.NumberToThaiWord(dr("moneyamount"))
            dr("moneyamounttext") = cast_money.NumberToThaiWord(dr("moneyamount"))
        Next

        Return dt
    End Function

    Public Function getReportData_debtor()
        Dim bgid As String = "0"
        If Request.QueryString("id") <> "" Then
            bgid = Request.QueryString("id")
        End If
        Dim bao As New BAO_BUDGET.Report
        Dim cast_money As New BAO_BUDGET.MoneyExt
        Dim dt As DataTable = bao.get_Report_R9_001_debtor(bgid)
        'For Each dr As DataRow In dt.Rows
        '    dr("amounttext") = cast_money.NumberToThaiWord(dr("moneyamount"))
        '    dr("moneyamounttext") = cast_money.NumberToThaiWord(dr("moneyamount"))
        'Next

        Return dt
    End Function

    Public Function getReportData_debtor_multi()
        Dim did As String = "0"
        If Request.QueryString("did") <> "" Then
            did = Request.QueryString("did")
        End If
        'Dim bao As New BAO_BUDGET.Report
        Dim cast_money As New BAO_BUDGET.MoneyExt
        'Dim dt As DataTable = bao.get_Report_R9_001_debtor(did)
        Dim dt As DataTable = get_Report_R9_001_debtor(did)
        'For Each dr As DataRow In dt.Rows
        '    dr("amounttext") = cast_money.NumberToThaiWord(dr("moneyamount"))
        '    dr("moneyamounttext") = cast_money.NumberToThaiWord(dr("moneyamount"))
        'Next

        Return dt
    End Function
    Public Function get_Report_R9_001_debtor(ByVal id_where As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Budget
        Dim str As String = " "

        str &= "select amounttext,receivername,receiverposition,customername"
        str &= " ,moneyamounttext,paytype,billnumber,moneytype,CHECK_NUMBER ,sum(moneyamount) as moneyamount from ( "
        str &= " Select b.DEBTOR_BILL_ID "
        str &= " ,'' as amounttext "
        str &= " , case when u.PREFIX is null then '' else u.PREFIX end + u.NAME + SPACE(1) + u.SURNAME as receivername"
        str &= " , u.POSITION as receiverposition"
        str &= "  , u.PREFIX + u.NAME + SPACE(1) + u.SURNAME as customername "
        str &= " , d.AMOUNT as moneyamount "
        str &= " , 1 as moneyamounttext "
        str &= " , p.PAYLIST_DESCRIPTION as paytype  "
        str &= "  , 'บย.' + cast(b.BILL_NUMBER as nvarchar(255)) + '/' + right(b.BUDGET_YEAR,2) as billnumber"
        str &= " , 'เงินงบประมาณ' as moneytype  "
        'str &= " , h.PRINT_DATE_STR as checkgroup"
        str &= " ,b.CHECK_NUMBER  "
        str &= " from DISBURSES.DEBTOR_BILL b"
        str &= " left join DTAM_USER.dbo.tbl_USER u on u.ID = b.USER_ID "
        str &= " join DISBURSES.DEBTOR_BILL_DETAIL d on b.DEBTOR_BILL_ID = d.DEBTOR_BILL_ID "
        str &= " left join dbo.MAS_PAYLIST p on p.PATLIST_ID = b.RECEIVE_PAYLIST "
        'str &= " join TBL_PRINT_CHECK_HISTORY h on h.BILL_ID = b.DEBTOR_BILL_ID and BILL_TYPE = 2"
        str &= "       where b.DEBTOR_TYPE_ID = 2"
        str &= "        union all"
        str &= " Select b.DEBTOR_BILL_ID"
        str &= " ,'' as amounttext "
        str &= " , case when u.PREFIX is null then '' else u.PREFIX end + u.NAME + SPACE(1) + u.SURNAME as receivername "
        str &= " , u.POSITION as receiverposition "
        str &= " , u.PREFIX + u.NAME + SPACE(1) + u.SURNAME as customername "
        str &= " , d.AMOUNT as moneyamount "
        str &= " , 1 as moneyamounttext "
        'str &= " , p.BUDGET_DESCRIPTION as paytype "
        str &= "  , p.PAYLIST_DESCRIPTION as paytype "
        str &= " , 'บย.' + cast(b.BILL_NUMBER as nvarchar(255)) + '/' + right(b.BUDGET_YEAR,2) as billnumber "
        str &= "  , 'เงินทดรอง' as moneytype   "
        'str &= " , h.PRINT_DATE_STR as checkgroup"
        str &= " ,d.CHECK_NUMBER "
        str &= " from DISBURSES.DEBTOR_BILL b"
        str &= " left join DTAM_USER.dbo.tbl_USER u on u.ID = b.USER_ID"
        str &= " join DISBURSES.DEBTOR_BILL_MARGIN_DETAIL d on b.DEBTOR_BILL_ID = d.DEBTOR_BILL_ID"
        'str &= " left join BUDGET_PLAN p on p.BUDGET_PLAN_ID = b.PAYLIST_ID"
        str &= " left join dbo.MAS_PAYLIST p on p.PATLIST_ID = b.RECEIVE_PAYLIST"
        'str &= " join TBL_PRINT_CHECK_HISTORY h on h.BILL_ID = b.DEBTOR_BILL_ID and BILL_TYPE = 2"
        str &= "     where b.DEBTOR_TYPE_ID = 1"
        'str &= "      union all"
        'str &= " select b.BUDGET_DISBURSE_BILL_ID as DEBTOR_BILL_ID"
        'str &= " ,'' as amounttext "
        'str &= " , u.CUSTOMER_NAME as receivername "
        'str &= " , '' as receiverposition "
        'str &= " , u.CUSTOMER_NAME as customername "
        'str &= " , d.AMOUNT as moneyamount "
        'str &= "  , b.BUDGET_DISBURSE_BILL_ID as moneyamounttext "
        'str &= "  , p.BUDGET_DESCRIPTION as paytype "
        'str &= " , 'บ.' + cast(b.BILL_NUMBER as nvarchar(255)) + '/' + right(b.BUDGET_YEAR,2) as billnumber "
        'str &= " , 'เงินงบประมาณ' as moneytype"
        ''str &= " , h.PRINT_DATE_STR as checkgroup"
        'str &= " from DISBURSES.BUDGET_BILL b"
        'str &= " join DISBURSES.BUDGET_BILL_DETAIL d on b.BUDGET_DISBURSE_BILL_ID = d.BUDGET_DISBURSE_BILL_ID"
        'str &= " left join BUDGET_PLAN p on p.BUDGET_PLAN_ID = b.PATLIST_ID"
        'str &= " left join dbo.MAS_CUSTOMER u on b.CUSTOMER_ID = u.CUSTOMER_ID"
        ''str &= " join TBL_PRINT_CHECK_HISTORY h on h.BILL_ID = b.BUDGET_DISBURSE_BILL_ID and BILL_TYPE = 1"
        'str &= "        where b.IS_PO <> 1 And b.PAY_TYPE_ID = 2"
        str &= " ) T"

        str &= " where t.CHECK_NUMBER in ( " & id_where & ")"
        str &= " group by amounttext,receivername,receiverposition,moneyamounttext,paytype,billnumber,moneytype,CHECK_NUMBER,customername"
        str &= " order by t.CHECK_NUMBER"

        dt = bao.Queryds(str)

        Return dt
    End Function

    Public Function get_Report_R9_001_bill(ByVal id_where As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Budget
        Dim str As String = " "

        str &= " select * from  dbo.Tb_AllCheck()"
        str &= " where CHECK_NUMBER in (" & id_where & ")"
        str &= " order by CHECK_NUMBER	 "

        'str &= " select t.CHECK_NUMBER,t.billnumber,t.amounttext,t.customername,t.moneyamounttext,t.moneytype"
        'str &= " ,t.paytype,t.receivername,t.receiverposition ,SUM( t.moneyamount) as moneyamount"
        'str &= " from (  "
        'str &= " select '' as amounttext  "
        'str &= "  , u.CUSTOMER_NAME as receivername  "
        'str &= "  , '' as receiverposition  "
        'str &= "  , u.CUSTOMER_NAME as customername  "
        'str &= "  , b.CHECK_NUMBER as moneyamounttext  "
        'str &= "  , p.PAYLIST_DESCRIPTION as paytype  "
        'str &= "  , 'บ.' + cast(b.BILL_NUMBER as nvarchar(255)) + '/' + right(b.BUDGET_YEAR,2) as billnumber  "
        'str &= "  , 'เงินงบประมาณ' as moneytype "
        'str &= " , b.CHECK_NUMBER   "
        'str &= "  , d.AMOUNT as moneyamount  "
        'str &= "  from DISBURSES.BUDGET_BILL b "
        'str &= "  join DISBURSES.BUDGET_BILL_DETAIL d on b.BUDGET_DISBURSE_BILL_ID = d.BUDGET_DISBURSE_BILL_ID "
        'str &= "  left join dbo.MAS_PAYLIST p on p.PATLIST_ID = b.RECEIVE_PAYLIST "
        'str &= "  left join dbo.MAS_CUSTOMER u on b.CUSTOMER_ID = u.CUSTOMER_ID "
        'str &= "  where b.IS_PO <> 1 And b.PAY_TYPE_ID = 2"
        'str &= "   ) T "
        'str &= " where t.CHECK_NUMBER in ( " & id_where & ")"
        'str &= " group by t.CHECK_NUMBER,t.billnumber,t.amounttext,t.customername,t.moneyamounttext,t.moneytype"
        'str &= " ,t.paytype,t.receivername,t.receiverposition "
        'str &= " order by t.CHECK_NUMBER	"




        dt = bao.Queryds(str)

        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("moneytype")) = False Then
                If IsNumeric(dr("moneytype")) = True Then
                    dr("moneytype") = getPlanBack(dr("moneytype"))
                End If
            End If
        Next

        Dim dt_chk As New DataTable
        dt_chk.Columns.Add("CHECK_NUMBER")
        dt_chk.Columns.Add("billnumber")
        dt_chk.Columns.Add("amounttext")
        dt_chk.Columns.Add("customername")
        dt_chk.Columns.Add("moneyamounttext")
        dt_chk.Columns.Add("moneytype")
        dt_chk.Columns.Add("paytype")
        dt_chk.Columns.Add("receivername")
        dt_chk.Columns.Add("receiverposition")
        dt_chk.Columns.Add("moneyamount", GetType(Double))
        For Each drr As DataRow In dt.Rows
            If dt_chk.Select("CHECK_NUMBER='" & drr("CHECK_NUMBER") & "'").Count = 0 Then
                Dim dr As DataRow = dt_chk.NewRow()
                dr("CHECK_NUMBER") = drr("CHECK_NUMBER")

                dt_chk.Rows.Add(dr)
            End If
        Next

        If dt_chk.Rows.Count > 0 Then
            Dim dv As DataView = dt_chk.DefaultView
            dv.Sort = "CHECK_NUMBER ASC"

            dt_chk = dv.ToTable
        End If

        If dt.Rows.Count > 1 Then
            For Each dr As DataRow In dt_chk.Rows

                For Each drr As DataRow In dt.Select("CHECK_NUMBER='" & dr("CHECK_NUMBER") & "'")
                    dr("billnumber") = drr("billnumber")
                    dr("amounttext") = drr("amounttext")
                    dr("customername") = drr("customername")
                    dr("moneyamounttext") = drr("moneyamounttext")
                    dr("moneytype") = drr("moneytype")
                    dr("paytype") = drr("paytype")
                    dr("receivername") = drr("receivername")
                    dr("receiverposition") = drr("receiverposition")
                    dr("moneyamount") = dt.Compute("sum(moneyamount)", "CHECK_NUMBER='" & dr("CHECK_NUMBER") & "'")
                Next

                'If dt.Select("CHECK_NUMBER='" & dr("CHECK_NUMBER") & "'").Count > 0 Then
                '    'dr("CHECK_NUMBER") = dt(0)("CHECK_NUMBER")

                'End If
            Next
            dt.Clear()
            dt = dt_chk
        End If

        Return dt
    End Function
    Public Function get_Report_Withdraw_Margin(ByVal id_where As Integer) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Budget
        Dim str As String = " "

        str &= " select * from  dbo.Tb_Withdraw_Margin()"
        str &= " where PAY_ID =" & id_where
        dt = bao.Queryds(str)

        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("moneytype")) = False Then
                If IsNumeric(dr("moneytype")) = True Then
                    dr("moneytype") = getPlanBack(dr("moneytype"))
                End If
            End If
        Next
        Return dt
    End Function
    Public Function get_Report_Other_Pay(ByVal id_where As Integer) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Budget
        Dim str As String = " "

        str &= " select * from  dbo.Tb_Other_Pay()"
        str &= " where PAY_ID =" & id_where
        dt = bao.Queryds(str)

        'For Each dr As DataRow In dt.Rows
        '    If IsDBNull(dr("moneytype")) = False Then
        '        If IsNumeric(dr("moneytype")) = True Then
        '            dr("moneytype") = getPlanBack(dr("moneytype"))
        '        End If
        '    End If
        'Next
        Return dt
    End Function
    Public Function getPlanBack(ByVal nodeId As Integer) As String
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        Dim strHeadNode As String = ""
        dt.Columns.Add("seq")
        dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
        dt.Columns.Add("MONEY_AMOUNT")
        dt.Columns.Add("TYPE_ID")
        dt = baobudget.getMoneyTypeNodeBack(dt, nodeId)

        'Dim dv As DataView = dt.DefaultView
        'dv.Sort = "seq desc"
        'dt = dv.ToTable
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                If IsDBNull(dr("TYPE_ID")) = False Then
                    If dr("TYPE_ID") = "1" Then
                        strHeadNode = dr("MONEY_TYPE_DESCRIPTION")
                        If strHeadNode = "เงินสนับสนุนสำนักงานหลักประกันสุขภาพแห่งชาติ" Then
                            strHeadNode = "เงินสนับสนุน สปสช."
                        End If
                    End If
                End If
            Next
        End If


        Return strHeadNode
    End Function

    Public Function get_Report_R9_001_Other(ByVal id_where As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Budget
        Dim str As String = " "
        str &= "select * from ( "
        str &= " select b.CURE_STUDY_ID as DEBTOR_BILL_ID"
        str &= "  ,b.CHECK_NUMBER as amounttext"
        str &= " , c.CUSTOMER_NAME as receivername"
        str &= " , b.AMOUNT as moneyamount"
        str &= " ,b.CURE_STUDY_ID as moneyamounttext"
        str &= " , case when b.BILL_TYPE_ID = 1 then 'ค่ารักษาพยาบาล' "
        str &= " when b.BILL_TYPE_ID = 2 then 'ค่าเล่าเรียนบุตร'"
        str &= " when b.BILL_TYPE_ID = 3 then 'ค่าเช่าบ้าน'"
        str &= " else '' end as paytype"
        str &= " , 'บท.' + cast(b.BILL_NUMBER as nvarchar(255)) + '/' + right(b.BUDGET_YEAR,2) as billnumber"
        str &= " , 'เงินงบประมาณ' as moneytype"
        str &= " , b.CHECK_NUMBER  "
        str &= " from DISBURSES.CURE_STUDY b"
        str &= " left join dbo.MAS_CUSTOMER c on b.USER_ID = c.CUSTOMER_ID"
        str &= " ) t"
        str &= " where t.CHECK_NUMBER in ( " & id_where & ")"

        dt = bao.Queryds(str)
        Return dt
    End Function
End Class