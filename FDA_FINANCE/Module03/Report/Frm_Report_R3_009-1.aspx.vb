Public Class Frm_Report_R3_009_1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Panel1.Visible = False
        Dim dao As New DAO_MAINTAIN.TB_REPORT_R3_009_1
        Dim bao_Report_r9_001 As New BAO_BUDGET.Report
        Dim dt As DataTable = bao_Report_r9_001.getReportData_R3_009_TEMP(Request.QueryString("Date"))

        If dt.Rows.Count > 0 Then
            dao.Getdata_by_ID(CInt(dt.Rows(0)("ID").ToString))
            UC_Report_R3_00091.insert(dao)
            dao.update()
        Else
        UC_Report_R3_00091.insert(dao)
        dao.insert()
        End If

        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_009.rdlc", "Fields_Report_R3_009", getReportData())
    End Sub

    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As DataTable = bao.getReportData_R3_009_TEMP(Request.QueryString("Date"))

        Return dt
    End Function

    'Function getReportData() As DataTable

    '    Dim dt As New DataTable
    '    dt.Columns.Add("moneybank")
    '    dt.Columns.Add("moneycoin")
    '    dt.Columns.Add("moneycheck")
    '    dt.Columns.Add("checkcount")
    '    dt.Columns.Add("totalfromsystem")

    '    dt.Columns.Add("bank1")
    '    dt.Columns.Add("bank2")
    '    dt.Columns.Add("bank3")

    '    dt.Columns.Add("usermoney")
    '    dt.Columns.Add("usermoneyposition")
    '    dt.Columns.Add("userstore")
    '    dt.Columns.Add("userstoreposition")

    '    dt.Columns.Add("boardname1")
    '    dt.Columns.Add("boardposition1")
    '    dt.Columns.Add("boardname2")
    '    dt.Columns.Add("boardposition2")
    '    dt.Columns.Add("boardname3")
    '    dt.Columns.Add("boardposition3")
    '    dt.Columns.Add("paramdate")


    '    Dim dr1 As DataRow = dt.NewRow()
    '    UC_Report_R3_00091.getdata()

    '    dr1("moneybank") = UC_Report_R3_00091.money_bank
    '    dr1("moneycoin") = UC_Report_R3_00091.money_coin
    '    dr1("moneycheck") = UC_Report_R3_00091.money_check
    '    dr1("checkcount") = UC_Report_R3_00091.check_count
    '    dr1("totalfromsystem") = UC_Report_R3_00091.totalfromsystem
    '    dr1("bank1") = UC_Report_R3_00091.bank_1
    '    dr1("bank2") = UC_Report_R3_00091.bank_2
    '    dr1("bank3") = UC_Report_R3_00091.bank_3
    '    dr1("usermoney") = UC_Report_R3_00091.usermoney
    '    dr1("usermoneyposition") = UC_Report_R3_00091.usermoney_position
    '    dr1("userstore") = UC_Report_R3_00091.userstore
    '    dr1("userstoreposition") = UC_Report_R3_00091.userstore_position
    '    dr1("boardname1") = UC_Report_R3_00091.boardname1
    '    dr1("boardposition1") = UC_Report_R3_00091.boardposition_1
    '    dr1("boardname2") = UC_Report_R3_00091.boardname2
    '    dr1("boardposition2") = UC_Report_R3_00091.boardposition_2
    '    dr1("boardname3") = UC_Report_R3_00091.boardname3
    '    dr1("boardposition3") = UC_Report_R3_00091.boardposition_3
    '    dr1("paramdate") = UC_Report_R3_00091.datesign

    '    dt.Rows.Add(dr1)

    '    Return dt
    'End Function

End Class