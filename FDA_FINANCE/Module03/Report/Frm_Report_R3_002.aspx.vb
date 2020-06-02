Public Class Frm_Report_R3_002
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dt As DataTable = bao.getReportData_R3_002(UC_Report_SelectDate_Single.dateSelect)

        Return dt
    End Function
    Public Function bind_data(ByVal datef As Date) As DataTable
        Dim dao_money As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim dt_money As New DataTable
        dt_money.Columns.Add("ID")
        dt_money.Columns.Add("description")
        dt_money.Columns.Add("descriptiontype")
        dt_money.Columns.Add("amount_t_cash")
        dt_money.Columns.Add("money_type_t_cash")
        dt_money.Columns.Add("group_t_cash")
        dt_money.Columns.Add("amount_t_check")
        dt_money.Columns.Add("money_type_t_check")
        dt_money.Columns.Add("group_t_check")
        dt_money.Columns.Add("amount_r_cash")
        dt_money.Columns.Add("money_type_r_cash")
        dt_money.Columns.Add("group_r_cash")
        dt_money.Columns.Add("amount_r_check")
        dt_money.Columns.Add("money_type_r_check")
        dt_money.Columns.Add("group_r_check")
        dt_money.Columns.Add("amount_m_cash")
        dt_money.Columns.Add("money_type_m_cash")
        dt_money.Columns.Add("group_m_cash")
        dt_money.Columns.Add("amount_m_check")
        dt_money.Columns.Add("money_type_m_check")
        dt_money.Columns.Add("group_m_check")
        dt_money.Columns.Add("removecash")
        dao_money.Getdata_Head_non_year(0)

        For Each dao_money.fields In dao_money.datas
            Dim dr As DataRow = dt_money.NewRow()
            dr("ID") = dao_money.fields.MONEY_TYPE_ID
            dr("description") = dao_money.fields.MONEY_TYPE_DESCRIPTION
            dr("descriptiontype") = dao_money.fields.TYPE_ID
            dt_money.Rows.Add(dr)
            getnode(dt_money, dao_money.fields.MONEY_TYPE_ID)
        Next

        Dim bao_trasfer_cash As New BAO_BUDGET.Report
        Dim bao_trasfer_check As New BAO_BUDGET.Report
        Dim bao_re_cash As New BAO_BUDGET.Report
        Dim bao_re_check As New BAO_BUDGET.Report
        Dim bao_m_cash As New BAO_BUDGET.Report
        Dim bao_m_check As New BAO_BUDGET.Report
        Dim bao_removecash As New BAO_BUDGET.Report
        For Each dr_trasfer As DataRow In dt_money.Rows
            Dim dt_t_cash As DataTable = bao_trasfer_cash.get_Report_R3_transfer_cash(datef, dr_trasfer("ID"))
            Dim dt_t_check As DataTable = bao_trasfer_check.get_Report_R3_transfer_check(datef, dr_trasfer("ID"))
            Dim dt_r_cash As DataTable = bao_re_cash.get_Report_R3_receive_cash(datef, dr_trasfer("ID"))
            Dim dt_r_check As DataTable = bao_re_check.get_Report_R3_receive_check(datef, dr_trasfer("ID"))
            Dim dt_m_cash As DataTable = bao_m_cash.get_Report_R3_maintain_cash(datef, dr_trasfer("ID"))
            Dim dt_m_check As DataTable = bao_m_check.get_Report_R3_maintain_check(datef, dr_trasfer("ID"))
            Dim dt_removecash As DataTable = bao_removecash.get_Report_R3_removecash(datef, dr_trasfer("ID"))

            Dim moneyyesterday As Double = 0
            moneyyesterday = GetTotalmoneyyesterday(DateAdd(DateInterval.Day, -1, datef), dr_trasfer("ID"))
            Dim moneyCheckyesterday As Double = 0
            moneyCheckyesterday = GetTotalCheckyesterday(DateAdd(DateInterval.Day, -1, datef), dr_trasfer("ID"))

            'dr_trasfer("amount_t_cash") = Math.Round(dt_t_cash(0)("amount"), 2)
            dr_trasfer("amount_t_cash") = moneyyesterday
            dr_trasfer("money_type_t_cash") = dt_t_cash(0)("money_type")
            dr_trasfer("group_t_cash") = dt_t_cash(0)("group")
            dr_trasfer("amount_t_check") = Math.Round(dt_t_check(0)("amount"), 2)
            dr_trasfer("money_type_t_check") = dt_t_check(0)("money_type")
            dr_trasfer("group_t_check") = dt_t_check(0)("group")

            dr_trasfer("amount_r_cash") = Math.Round(dt_r_cash(0)("amount"), 2)
            dr_trasfer("money_type_r_cash") = dt_r_cash(0)("money_type")
            dr_trasfer("group_r_cash") = dt_r_cash(0)("group")
            dr_trasfer("amount_r_check") = Math.Round(dt_r_check(0)("amount"), 2)
            dr_trasfer("money_type_r_check") = dt_r_check(0)("money_type")
            dr_trasfer("group_r_check") = dt_r_check(0)("group")
            dr_trasfer("amount_m_cash") = Math.Round(dt_m_cash(0)("amount"), 2)
            dr_trasfer("money_type_m_cash") = dt_m_cash(0)("money_type")
            dr_trasfer("group_m_cash") = dt_m_cash(0)("group")
            dr_trasfer("amount_m_check") = Math.Round(dt_m_check(0)("amount"), 2)
            dr_trasfer("money_type_m_check") = dt_m_check(0)("money_type")
            dr_trasfer("group_m_check") = dt_m_check(0)("group")
            dr_trasfer("removecash") = Math.Round(dt_removecash(0)("removecash"), 2)
            'removecash
        Next

        Return dt_money
    End Function


    Private Function GetTotalmoneyyesterday(ByVal datec As Date, ByVal tranferid As Integer) As Double
        Dim moneytotal As Double = 0
        Dim t_cash_sum As Double = 0
        Dim m_cash_sum As Double = 0
        Dim removecash As Double = 0
        Dim r_cash_sum As Double = 0
        'Dim t_check_sum As Double = 0
        Dim bao_m_cash As New BAO_BUDGET.Report
        Dim bao As New BAO_BUDGET.Report
        Dim bao_removecash As New BAO_BUDGET.Report
        Dim bao_re_cash As New BAO_BUDGET.Report
        ' Dim bao_t_check As New BAO_BUDGET.Report
        Dim dt_t_cash As DataTable = bao.get_Report_R3_transfer_cash(datec, tranferid)
        ' Dim dt_t_check As DataTable = bao_t_check.get_Report_R3_transfer_check_sum(datec, tranferid)
        Dim dt_m_cash As DataTable = bao_m_cash.get_Report_R3_maintain_cash_sum(datec, tranferid)
        Dim dt_removecash As DataTable = bao_removecash.get_Report_R3_removecash(datec, tranferid)
        Dim dt_r_cash As DataTable = bao_re_cash.get_Report_R3_receive_cash_sum(datec, tranferid)
        If IsDBNull(dt_t_cash(0)("amount")) = False Then
            t_cash_sum = dt_t_cash(0)("amount")
        End If
        If IsDBNull(dt_m_cash(0)("amount")) = False Then
            m_cash_sum = dt_m_cash(0)("amount")
        End If
        If IsDBNull(dt_removecash(0)("removecash")) = False Then
            removecash = dt_removecash(0)("removecash")
        End If
        If IsDBNull(dt_r_cash(0)("amount")) = False Then
            r_cash_sum = dt_r_cash(0)("amount")
        End If

        moneytotal = (t_cash_sum + r_cash_sum) - m_cash_sum - removecash
        Return moneytotal
    End Function
    Private Function GetTotalCheckyesterday(ByVal datec As Date, ByVal tranferid As Integer) As Double
        Dim moneytotal As Double = 0
        Dim t_check As Double = 0
        Dim r_check As Double = 0
        Dim m_check As Double = 0
        Dim bao_trasfer_check As New BAO_BUDGET.Report
        Dim bao_re_check As New BAO_BUDGET.Report
        Dim bao_m_check As New BAO_BUDGET.Report
        Dim dt_t_check As DataTable = bao_trasfer_check.get_Report_R3_transfer_check(datec, tranferid)
        Dim dt_r_check As DataTable = bao_re_check.get_Report_R3_receive_check_sum(datec, tranferid)
        Dim dt_m_check As DataTable = bao_m_check.get_Report_R3_maintain_check_sum(datec, tranferid)
        If IsDBNull(dt_t_check(0)("amount")) = False Then
            t_check = dt_t_check(0)("amount")
        End If
        If IsDBNull(dt_r_check(0)("amount")) = False Then
            r_check = dt_r_check(0)("amount")
        End If
        If IsDBNull(dt_m_check(0)("amount")) = False Then
            m_check = dt_m_check(0)("amount")
        End If
        moneytotal = (t_check + r_check) - m_check

    End Function


    Public Function getnode(dt As DataTable, Optional id As Integer = 0)
        Dim dao_money As New DAO_MAS.TB_MAS_MONEY_TYPE
        dao_money.Getdata_Head_non_year(id)
        For Each dao_money.fields In dao_money.datas
            Dim dr As DataRow = dt.NewRow()
            dr("ID") = dao_money.fields.MONEY_TYPE_ID
            dr("description") = dao_money.fields.MONEY_TYPE_DESCRIPTION
            dr("descriptiontype") = dao_money.fields.TYPE_ID
            dt.Rows.Add(dr)
            getnode(dt, dao_money.fields.MONEY_TYPE_ID)
        Next
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        ' bind_data(rdp_dateReportSelect.SelectedDate)
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        UC_Report_SelectDate_Single.getDateSelect()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_002.rdlc", "Fields_Report_R3_002", bind_data(UC_Report_SelectDate_Single.dateSelect))
    End Sub
End Class