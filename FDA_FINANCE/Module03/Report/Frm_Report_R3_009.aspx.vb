Public Class Frm_Report_R3_009
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'btn_ShowReport_2.Attributes.Add("Onclick", "window.open('Frm_Report_R3_009-1.aspx?DateSelect=" & UC_Report_SelectDate_Single.dateSelect & "')")
    End Sub

    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dt As DataTable = bao.getReportData_R3_009(UC_Report_SelectDate_Single.dateSelect)

        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        UC_Report_SelectDate_Single.getDateSelect()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_009_1.rdlc", "Fields_Report_R3_009_1", getReportData())
    End Sub

    'Public Function getReportData() As DataTable

    '    Dim date_select As Date = CDate(UC_Report_SelectDate_Single.dateSelect).ToShortDateString()
    '    '-------แถวที่1-------
    '    Dim dt As New DataTable
    '    dt.Columns.Add("list")
    '    dt.Columns.Add("bg_amount")
    '    dt.Columns.Add("out_bg")
    '    dt.Columns.Add("out_bg_bank")
    '    dt.Columns.Add("nation_amount")
    '    dt.Columns.Add("margin_cash")
    '    dt.Columns.Add("margin_bank")
    '    dt.Columns.Add("balance")

    '    Dim dao_margin As New DAO_DISBURSE.TB_MAS_MARGIN
    '    dao_margin.Getdata_by_year(2557)
    '    Dim margin_cash As Double = 0 'dao_margin.fields.CASH_AMOUNT
    '    margin_cash = Getbgamountyesterday(date_select) + Getbgoutamountyesterday(date_select) + Getbgoutbankamountyesterday(date_select) + Getbgnationamountyesterday(date_select)
    '    Dim dr1 As DataRow = dt.NewRow()
    '    dr1("list") = "1.ยอดยกมา"
    '    dr1("bg_amount") = Getbgamountyesterday(date_select)
    '    dr1("out_bg") = Getbgoutamountyesterday(date_select)
    '    dr1("out_bg_bank") = Getbgoutbankamountyesterday(date_select)
    '    dr1("nation_amount") = Getbgnationamountyesterday(date_select)
    '    dr1("margin_cash") = margin_cash 'Getmargincashamountyesterday(date_select) 'dao_margin.fields.CASH_AMOUNT
    '    dr1("margin_bank") = Getmarginbankamountyesterday(date_select) ' dao_margin.fields.BANK_AMOUNT

    '    dr1("balance") = margin_cash
    '    dt.Rows.Add(dr1)

    '    '-----แถวที่ 2 ------
    '    Dim bao_bg_amount2 As New BAO_BUDGET.Report
    '    Dim bao_out_bg_amount2 As New BAO_BUDGET.Report
    '    Dim bao_nation_amount2 As New BAO_BUDGET.Report
    '    Dim bao_margin_cash2 As New BAO_BUDGET.Report
    '    Dim bao_margin_bank2 As New BAO_BUDGET.Report
    '    Dim bao_out_bg_bank_amount2 As New BAO_BUDGET.Report
    '    Dim dr2 As DataRow = dt.NewRow()
    '    dr2("list") = "2.รับเพิ่ม"
    '    dr2("bg_amount") = bao_bg_amount2.get_R3_2_bg_amount(date_select)
    '    dr2("out_bg") = bao_out_bg_amount2.get_R3_2_Out_bg_amount(date_select)
    '    dr2("out_bg_bank") = bao_out_bg_bank_amount2.get_R3_2_Out_bg_bank_amount(date_select)
    '    dr2("nation_amount") = bao_nation_amount2.get_R3_2_nation_amount(date_select)
    '    dr2("margin_cash") = 0 'bao_margin_cash2.get_R3_2_margin_cash
    '    dr2("margin_bank") = bao_margin_bank2.get_R3_2_margin_bank(date_select)
    '    margin_cash = margin_cash + (bao_bg_amount2.get_R3_2_bg_amount(date_select) + bao_nation_amount2.get_R3_2_nation_amount(date_select))
    '    dr2("balance") = margin_cash
    '    dt.Rows.Add(dr2)

    '    '------แถว3------
    '    Dim dr3 As DataRow = dt.NewRow()
    '    Dim bao_bg3 As New BAO_BUDGET.Report
    '    Dim bao_out_bg3 As New BAO_BUDGET.Report
    '    Dim bao_out_bg_bank3 As New BAO_BUDGET.Report
    '    Dim bao_nation3 As New BAO_BUDGET.Report
    '    dr3("list") = "3.ถอนจ่าย"
    '    dr3("bg_amount") = bao_bg3.get_R3_3_bg_amount(date_select)
    '    dr3("out_bg") = bao_out_bg3.get_R3_3_out_bg_amount(date_select)
    '    dr3("out_bg_bank") = bao_out_bg_bank3.get_R3_3_out_bg_bank_amount(date_select)
    '    dr3("nation_amount") = bao_nation3.get_R3_3_nation_amount(date_select)
    '    dr3("margin_cash") = 0
    '    dr3("margin_bank") = 0
    '    margin_cash = margin_cash - (bao_bg3.get_R3_3_bg_amount(date_select) + bao_out_bg3.get_R3_3_out_bg_amount(date_select) + bao_out_bg_bank3.get_R3_3_out_bg_bank_amount(date_select) + bao_nation3.get_R3_3_nation_amount(date_select))
    '    dr3("balance") = margin_cash
    '    dt.Rows.Add(dr3)

    '    Dim bao_bg_amount4 As New BAO_BUDGET.Report
    '    Dim bao_nation_amount4 As New BAO_BUDGET.Report
    '    Dim bao_margin_cash4 As New BAO_BUDGET.Report
    '    Dim bao_margin_bank4 As New BAO_BUDGET.Report
    '    Dim dr4 As DataRow = dt.NewRow()
    '    dr4("list") = "4.จ่าย"
    '    dr4("bg_amount") = 0
    '    dr4("out_bg") = 0
    '    dr4("out_bg_bank") = 0
    '    dr4("nation_amount") = 0
    '    dr4("margin_cash") = bao_margin_cash4.get_R3_4_margin_cash(date_select)
    '    dr4("margin_bank") = bao_margin_bank4.get_R3_4_margin_bank(date_select)
    '    margin_cash = margin_cash + bao_margin_cash4.get_R3_4_margin_cash(date_select)
    '    dr4("balance") = margin_cash
    '    dt.Rows.Add(dr4)

    '    Dim bao_bg_amount5 As New BAO_BUDGET.Report
    '    Dim bao_nation_amount5 As New BAO_BUDGET.Report
    '    Dim bao_out_bg_amount5 As New BAO_BUDGET.Report
    '    Dim bao_out_bg_bank_amount5 As New BAO_BUDGET.Report
    '    'Dim bao_margin_cash5 As New BAO_BUDGET.Report
    '    'Dim bao_margin_bank5 As New BAO_BUDGET.Report
    '    Dim dr5 As DataRow = dt.NewRow()
    '    dr5("list") = "5.นำฝาก"
    '    dr5("bg_amount") = bao_bg_amount5.get_R3_5_bg_amount(date_select)
    '    dr5("out_bg") = bao_out_bg_amount5.get_R3_5_out_bg_amount(date_select)
    '    dr5("out_bg_bank") = bao_out_bg_amount5.get_R3_5_out_bg_bank_amount(date_select)
    '    dr5("nation_amount") = bao_nation_amount5.get_R3_5_nation_amount(date_select)
    '    dr5("margin_cash") = 0
    '    dr5("margin_bank") = 0
    '    margin_cash = margin_cash + (bao_bg_amount5.get_R3_5_bg_amount(date_select) + bao_nation_amount5.get_R3_5_nation_amount(date_select) + bao_out_bg_amount5.get_R3_5_out_bg_amount(date_select) + bao_out_bg_amount5.get_R3_5_out_bg_bank_amount(date_select))
    '    dr5("balance") = margin_cash
    '    dt.Rows.Add(dr5)

    '    Dim bg_amount As Double = 0
    '    Dim out_bg As Double = 0
    '    Dim out_bg_bank As Double = 0
    '    Dim nation_amount As Double = 0
    '    Dim margin_cash_col As Double = 0
    '    Dim margin_bank_col As Double = 0

    '    For Each dr As DataRow In dt.Rows
    '        bg_amount = bg_amount + CDbl(dr("bg_amount"))
    '        out_bg = out_bg + CDbl(dr("out_bg"))
    '        out_bg_bank = out_bg_bank + CDbl(dr("out_bg_bank"))
    '        nation_amount = nation_amount + CDbl(dr("nation_amount"))
    '        margin_cash_col = margin_cash_col + CDbl(dr("margin_cash"))
    '        margin_bank_col = margin_bank_col + CDbl(dr("margin_bank"))
    '    Next


    '    Dim dr6 As DataRow = dt.NewRow()
    '    dr6("list") = "6.คงเหลือเก็บตู้นิรภัย"
    '    dr6("bg_amount") = bg_amount
    '    dr6("out_bg") = out_bg
    '    dr6("out_bg_bank") = out_bg_bank
    '    dr6("nation_amount") = nation_amount
    '    dr6("margin_cash") = margin_cash_col
    '    dr6("margin_bank") = margin_bank_col
    '    dr6("balance") = margin_cash
    '    dt.Rows.Add(dr6)
    '    Return dt
    'End Function

    'Private Function Getbgamountyesterday(date_select As Date) As Double
    '    Dim total_bg As Double = 0
    '    Dim bao_bg2 As New BAO_BUDGET.Report
    '    Dim bao_bg3 As New BAO_BUDGET.Report
    '    Dim bao_bg5 As New BAO_BUDGET.Report
    '    Dim amount2 As Double = 0
    '    Dim amount3 As Double = 0
    '    Dim amount5 As Double = 0
    '    amount2 = bao_bg2.get_R3_2_bg_amount_sum(date_select)
    '    amount3 = bao_bg3.get_R3_3_bg_amount_sum(date_select)
    '    amount5 = bao_bg5.get_R3_5_bg_amount_sum(date_select)
    '    total_bg = amount2 + amount3 + amount5

    '    Return total_bg
    'End Function
    'Private Function Getbgoutamountyesterday(date_select As Date) As Double
    '    Dim total As Double = 0
    '    Dim bao_out2 As New BAO_BUDGET.Report
    '    Dim bao_out3 As New BAO_BUDGET.Report
    '    Dim bao_out5 As New BAO_BUDGET.Report
    '    Dim amount2 As Double = 0
    '    Dim amount3 As Double = 0
    '    Dim amount5 As Double = 0

    '    amount2 = bao_out2.get_R3_2_Out_bg_amount_sum(date_select)
    '    amount3 = bao_out3.get_R3_3_out_bg_amount_sum(date_select)
    '    amount5 = bao_out5.get_R3_5_out_bg_amount_sum(date_select)

    '    total = amount2 + amount3 + amount5
    '    Return total
    'End Function
    ''get_R3_2_Out_bg_bank_amount_sum
    'Private Function Getbgoutbankamountyesterday(date_select As Date) As Double
    '    Dim total As Double = 0
    '    Dim bao_out_bank2 As New BAO_BUDGET.Report
    '    Dim bao_out_bank3 As New BAO_BUDGET.Report
    '    Dim bao_out_bank5 As New BAO_BUDGET.Report
    '    Dim amount2 As Double = 0
    '    Dim amount3 As Double = 0
    '    Dim amount5 As Double = 0
    '    amount2 = bao_out_bank2.get_R3_2_Out_bg_bank_amount_sum(date_select)
    '    amount3 = bao_out_bank3.get_R3_3_out_bg_bank_amount_sum(date_select)
    '    amount5 = bao_out_bank5.get_R3_5_out_bg_bank_amount_sum(date_select)

    '    total = amount2 + amount3 + amount5
    '    Return total
    'End Function
    'Private Function Getbgnationamountyesterday(date_select As Date) As Double
    '    Dim total As Double = 0
    '    Dim bao_nation2 As New BAO_BUDGET.Report
    '    Dim bao_nation3 As New BAO_BUDGET.Report
    '    Dim bao_nation5 As New BAO_BUDGET.Report
    '    Dim amount2 As Double = 0
    '    Dim amount3 As Double = 0
    '    Dim amount5 As Double = 0
    '    amount2 = bao_nation2.get_R3_2_nation_amount_sum(date_select)
    '    amount3 = bao_nation3.get_R3_3_nation_amount_sum(date_select)
    '    amount5 = bao_nation5.get_R3_5_nation_amount_sum(date_select)

    '    total = amount2 + amount3 + amount5
    '    Return total
    'End Function
    ''get_R3_2_margin_bank_sum
    'Private Function Getmarginbankamountyesterday(date_select As Date) As Double
    '    Dim total As Double = 0
    '    Dim bao_margin_bank2 As New BAO_BUDGET.Report
    '    Dim bao_margin_bank4 As New BAO_BUDGET.Report
    '    Dim amount2 As Double = 0
    '    Dim amount4 As Double = 0

    '    amount2 = bao_margin_bank2.get_R3_2_margin_bank_sum(date_select)
    '    amount4 = bao_margin_bank4.get_R3_4_margin_bank_sum(date_select)

    '    total = amount2 + amount4
    '    Return total
    'End Function
    'Private Function Getmargincashamountyesterday(date_select As Date) As Double
    '    Dim total As Double = 0
    '    Dim bao_margin_cash2 As New BAO_BUDGET.Report
    '    Dim bao_margin_cash4 As New BAO_BUDGET.Report
    '    Dim amount2 As Double = 0
    '    Dim amount4 As Double = 0
    '    amount2 = bao_margin_cash2.get_R3_2_margin_cash_sum(date_select)
    '    amount4 = bao_margin_cash4.get_R3_4_margin_cash_sum(date_select)
    '    total = amount2 + amount4
    '    Return total
    'End Function

    Private Sub btn_ShowReport_2_Click(sender As Object, e As EventArgs) Handles btn_ShowReport_2.Click
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dt As DataTable = bao.getReportData_R3_009_Amount(UC_Report_SelectDate_Single.dateSelect)
        Dim dt_margin As DataTable = bao.getReportData_R3_009_Amount_Margin(UC_Report_SelectDate_Single.dateSelect)

        Dim a As Double
        If IsDBNull(dt.Rows(0)("Amount")) = False Then
            a = dt.Rows(0)("Amount")
        End If

        Dim b As Double
        If IsDBNull(dt_margin.Rows(0)("Amount")) = False Then
            b = dt_margin.Rows(0)("Amount")
        End If
        If b < 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ผิดพลาด จำนวนตัวเลขไม่ถูกต้อง');", True)
        Else
            Response.Redirect("Frm_Report_R3_009-1.aspx?Amount=" & a & "&Amount2=" & b & "&Date=" & UC_Report_SelectDate_Single.dateSelect)
        End If

        'btn_ShowReport_2.Attributes.Add("Onclick", "window.open('Frm_Report_R3_009-1.aspx?Amount=" & a & "')")
    End Sub
End Class