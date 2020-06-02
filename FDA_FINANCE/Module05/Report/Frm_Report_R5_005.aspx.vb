Public Class Frm_Report_R5_005
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
        UC_Report_SelectDate_Between.getDateSelect()
        UC_Money_Type_Node1.getDateSelect()
        Dim id As Integer = UC_Money_Type_Node1.money_id
        Dim dt As DataTable = bao.getReportData_R5_005(UC_Report_SelectDate_Between.dateBegin, UC_Report_SelectDate_Between.dateEnd, id) 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป

        dt.Columns.Add("money_type_des")
        For Each dr As DataRow In dt.Rows
            dr("money_type_des") = bindTxtbox(ID)
        Next

        Dim balance As Double = 0
        For Each dr As DataRow In dt.Rows
            'If CDbl(dr("moneyincome")) = 0 Then
            '    balance = balance + dr("moneydeposite")
            'ElseIf CDbl(dr("moneydeposite")) = 0 Then
            '    balance = balance + dr("moneyincome")
            'Else
            '    balance = balance + 0
            'End If
            balance = balance + dr("moneyincome")
            dr("balance") = balance
        Next
        Return dt
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
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module05\Report_R5_005.rdlc", "Fields_Report_R5_005", getReportData())
    End Sub
End Class