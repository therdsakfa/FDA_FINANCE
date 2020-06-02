Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports xi = Telerik.Web.UI.ExportInfrastructure
Imports System.Web.UI
Imports System.Web
Imports Telerik.Web.UI.GridExcelBuilder
Imports System.Drawing
Public Class UC_Salary_ALL
    Inherits System.Web.UI.UserControl
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _month_num As Integer
    Public Property month_num() As Integer
        Get
            Return _month_num
        End Get
        Set(ByVal value As Integer)
            _month_num = value
        End Set
    End Property

    Private _per_type As Integer
    Public Property per_type() As Integer
        Get
            Return _per_type
        End Get
        Set(ByVal value As Integer)
            _per_type = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_salary_Init(sender As Object, e As EventArgs) Handles rg_salary.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_salary
        Rad_Utility.addColumnBound("IDRUN", "IDRUN", False)
        Rad_Utility.addColumnBound("Row_num", "ลำดับที่")
        Rad_Utility.addColumnBound("DEPARTMENT_ID", "DEPARTMENT_ID", False)
        Rad_Utility.addColumnBound("idp", "idp", False)
        Rad_Utility.addColumnBound("fullname", "fullname", False)
        Rad_Utility.addColumnBound("STATUS_PERSON", "STATUS_PERSON", False)
        'dept_long
        Rad_Utility.addColumnBound("dept_long", "dept_long", False)
        Rad_Utility.addColumnBound("PREFIX_NAME", "คำนำหน้า")
        Rad_Utility.addColumnBound("NAME", "ชื่อ")
        Rad_Utility.addColumnBound("SURNAME", "สกุล")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "สังกัด")
        Rad_Utility.addColumnBound("1", "เงินเดือน", is_money:=True)
        'Rad_Utility.addColumnBound("2", "ค่าตอบแทน(ตกเบิก)", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("3", "ค่าครองชีพ", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("4", "ค่าครองชีพตกเบิก", is_money:=True, is_footer:=True)
        Rad_Utility.addColumnBound("sumprofit", "รวมรายรับ", is_money:=True)
        'Rad_Utility.addColumnBound("5", "ปกส. 5%", is_money:=True, is_footer:=True)
        Rad_Utility.addColumnBound("9", "สอ.วว.", is_money:=True)
        'Rad_Utility.addColumnBound("10", "สอ.กรมป่าไม้", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("11", "ประกันชีวิต AIA.", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("12", "ธอส.", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("13", "ออมสิน", is_money:=True)
        Rad_Utility.addColumnBound("sumpay", "รวมรายจ่าย", is_money:=True)
        Rad_Utility.addColumnBound("total", "คงเหลือเงินรับ", is_money:=True)
        Rad_Utility.addColumnBound("COOPERATE_NUMBER", "เลขสหกรณ์")
        Rad_Utility.addColumnButton("I", "เพิ่ม/ดูค่าใช้จ่าย", "I", 0, "", width:=130)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
        Rad_Utility.addColumnButton("print", "พิมพ์สลิป", "print", 0, "", width:=120)
    End Sub

    Private Sub rg_salary_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_salary.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_SALARY.TB_SALARY
                dao.Getdata_by_ID(item("IDRUN").Text)
                dao.delete()
                rg_salary.Rebind()
            ElseIf e.CommandName = "print" Then
                Dim url As String = ""
                url = "../Module07/Report/Frm_Report_R7_Slip.aspx?idrun=" & item("IDRUN").Text
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "'); ", True)
            End If
        End If
    End Sub

    Private Sub rg_salary_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_salary.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("IDRUN").Text
            Dim h1 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim btn_insert As LinkButton = DirectCast(item("I").Controls(0), LinkButton)
            Dim url As String = "Frm_Salary_Personal_Edit.aspx?id=" & item("IDRUN").Text & "&bgyear=" & BudgetYear & "&t=2"
            'h1.Attributes.Add("OnClick", "return k('" & url & "');")
            h1.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            Dim url_in As String = "Frm_Salary_List2.aspx?id=" & id & "&m=" & month_num
            ' btn_insert.PostBackUrl = "../Frm_Salary_List.aspx?id=" & id & "&m=" & month_num
            btn_insert.Attributes.Add("OnClick", "Popups3('" & url_in & "'); return false;")
        End If
    End Sub

    Private Sub rg_salary_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_salary.NeedDataSource
        Dim bao As New BAO_BUDGET.Salary()
        Dim dt As New DataTable
        'If Request.QueryString("m") <> "" Then
        '    dt = bao.get_salary(BudgetYear, Request.QueryString("m"), per_type)
        'Else
        '    dt = bao.get_salary(BudgetYear, month_num, per_type)
        'End If
        dt = bao.get_salary(BudgetYear, month_num, per_type)

        dt.Columns.Add("1", Type.GetType("System.Double"))
        dt.Columns.Add("2", Type.GetType("System.Double"))
        dt.Columns.Add("3", Type.GetType("System.Double"))
        dt.Columns.Add("4", Type.GetType("System.Double"))
        'dt.Columns.Add("sumprofit", Type.GetType("System.Double"))
        dt.Columns.Add("sumprofit", Type.GetType("System.Decimal"))
        dt.Columns.Add("5", Type.GetType("System.Double"))
        dt.Columns.Add("6", Type.GetType("System.Double"))
        dt.Columns.Add("7", Type.GetType("System.Double"))
        dt.Columns.Add("8", Type.GetType("System.Double"))
        dt.Columns.Add("9", Type.GetType("System.Double"))
        dt.Columns.Add("10", Type.GetType("System.Double"))
        dt.Columns.Add("11", Type.GetType("System.Double"))
        dt.Columns.Add("12", Type.GetType("System.Double"))
        dt.Columns.Add("13", Type.GetType("System.Double"))
        dt.Columns.Add("14", Type.GetType("System.Double"))
        dt.Columns.Add("sumpay", Type.GetType("System.Decimal"))
        dt.Columns.Add("total", Type.GetType("System.Decimal"))
        For Each dr As DataRow In dt.Rows
            Dim sum_profit As Double = 0
            Dim sum_pay As Double = 0
            Dim bao1 As New BAO_BUDGET.Salary()
            Dim bao2 As New BAO_BUDGET.Salary()
            Dim bao3 As New BAO_BUDGET.Salary()
            Dim bao4 As New BAO_BUDGET.Salary()
            Dim bao5 As New BAO_BUDGET.Salary()
            Dim bao6 As New BAO_BUDGET.Salary()
            Dim bao7 As New BAO_BUDGET.Salary()
            Dim bao8 As New BAO_BUDGET.Salary()
            Dim bao9 As New BAO_BUDGET.Salary()
            Dim bao10 As New BAO_BUDGET.Salary()
            Dim bao11 As New BAO_BUDGET.Salary()
            Dim bao12 As New BAO_BUDGET.Salary()
            Dim bao13 As New BAO_BUDGET.Salary()
            Dim bao14 As New BAO_BUDGET.Salary()

            Try
                dr("1") = bao1.get_salary_paylist_amount(dr("IDRUN"), 1)
                sum_profit = sum_profit + bao1.get_salary_paylist_amount(dr("IDRUN"), 1)
            Catch ex As Exception
                dr("1") = 0
            End Try

            Try
                dr("2") = bao2.get_salary_paylist_amount(dr("IDRUN"), 2)
                sum_profit = sum_profit + bao2.get_salary_paylist_amount(dr("IDRUN"), 2)
            Catch ex As Exception
                dr("2") = 0
            End Try
            Try
                dr("3") = bao3.get_salary_paylist_amount(dr("IDRUN"), 3)
                sum_profit = sum_profit + bao3.get_salary_paylist_amount(dr("IDRUN"), 3)
            Catch ex As Exception
                dr("3") = 0
            End Try
            Try
                dr("4") = bao4.get_salary_paylist_amount(dr("IDRUN"), 4)
                sum_profit = sum_profit + bao4.get_salary_paylist_amount(dr("IDRUN"), 4)
            Catch ex As Exception
                dr("4") = 0
            End Try
            dr("sumprofit") = sum_profit

            Try
                dr("5") = bao5.get_salary_paylist_amount(dr("IDRUN"), 5)
                sum_pay = sum_pay + bao5.get_salary_paylist_amount(dr("IDRUN"), 5)
            Catch ex As Exception
                dr("5") = 0
            End Try
            Try
                dr("6") = bao6.get_salary_paylist_amount(dr("IDRUN"), 6)
                sum_pay = sum_pay + bao6.get_salary_paylist_amount(dr("IDRUN"), 6)
            Catch ex As Exception
                dr("6") = 0
            End Try
            Try
                dr("7") = bao7.get_salary_paylist_amount(dr("IDRUN"), 7)
                sum_pay = sum_pay + bao7.get_salary_paylist_amount(dr("IDRUN"), 7)
            Catch ex As Exception
                dr("7") = 0
            End Try
            Try
                dr("8") = bao8.get_salary_paylist_amount(dr("IDRUN"), 8)
                sum_pay = sum_pay + bao8.get_salary_paylist_amount(dr("IDRUN"), 8)
            Catch ex As Exception
                dr("8") = 0
            End Try
            Try
                dr("9") = bao9.get_salary_paylist_amount(dr("IDRUN"), 9)
                sum_pay = sum_pay + bao9.get_salary_paylist_amount(dr("IDRUN"), 9)
            Catch ex As Exception
                dr("9") = 0
            End Try
            Try
                dr("10") = bao10.get_salary_paylist_amount(dr("IDRUN"), 10)
                sum_pay = sum_pay + bao10.get_salary_paylist_amount(dr("IDRUN"), 10)
            Catch ex As Exception
                dr("10") = 0
            End Try
            Try
                dr("11") = bao11.get_salary_paylist_amount(dr("IDRUN"), 11)
                sum_pay = sum_pay + bao11.get_salary_paylist_amount(dr("IDRUN"), 11)
            Catch ex As Exception
                dr("11") = 0
            End Try
            Try
                dr("12") = bao12.get_salary_paylist_amount(dr("IDRUN"), 12)
                sum_pay = sum_pay + bao12.get_salary_paylist_amount(dr("IDRUN"), 12)
            Catch ex As Exception
                dr("12") = 0
            End Try
            Try
                dr("13") = bao13.get_salary_paylist_amount(dr("IDRUN"), 13)
                sum_pay = sum_pay + bao13.get_salary_paylist_amount(dr("IDRUN"), 13)
            Catch ex As Exception
                dr("13") = 0
            End Try
            Try
                dr("14") = bao14.get_salary_paylist_amount(dr("IDRUN"), 14)
                sum_pay = sum_pay + bao14.get_salary_paylist_amount(dr("IDRUN"), 14)
            Catch ex As Exception
                dr("14") = 0
            End Try

            dr("sumpay") = sum_pay
            dr("total") = sum_profit - sum_pay
        Next

        rg_salary.DataSource = dt
    End Sub
    ' For Each dr As DataRow In dt.Rows
    'Dim sum_profit As Double = 0
    'Dim sum_pay As Double = 0
    'Dim dao1 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao2 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao3 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao4 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao5 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao6 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao7 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao8 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao9 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao10 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao11 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao12 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao13 As New DAO_SALARY.TB_SALARY_DETAIL()
    'Dim dao14 As New DAO_SALARY.TB_SALARY_DETAIL()
    '    dao1.Getdata_by_sp_idrun(dr("IDRUN"), 1)
    '    dao2.Getdata_by_sp_idrun(dr("IDRUN"), 2)
    '    dao3.Getdata_by_sp_idrun(dr("IDRUN"), 3)
    '    dao4.Getdata_by_sp_idrun(dr("IDRUN"), 4)
    '    dao5.Getdata_by_sp_idrun(dr("IDRUN"), 5)
    '    dao5.Getdata_by_sp_idrun(dr("IDRUN"), 6)
    '    dao5.Getdata_by_sp_idrun(dr("IDRUN"), 7)
    '    dao5.Getdata_by_sp_idrun(dr("IDRUN"), 8)
    '    dao9.Getdata_by_sp_idrun(dr("IDRUN"), 9)
    '    dao10.Getdata_by_sp_idrun(dr("IDRUN"), 10)
    '    dao11.Getdata_by_sp_idrun(dr("IDRUN"), 11)
    '    dao12.Getdata_by_sp_idrun(dr("IDRUN"), 12)
    '    dao13.Getdata_by_sp_idrun(dr("IDRUN"), 13)
    '    dao5.Getdata_by_sp_idrun(dr("IDRUN"), 14)

    '    Try
    '        dr("1") = dao1.fields.AMOUNT
    '        sum_profit = sum_profit + dao1.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("1") = 0
    '    End Try

    '    Try
    '        dr("2") = dao2.fields.AMOUNT
    '        sum_profit = sum_profit + dao2.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("2") = 0
    '    End Try
    '    Try
    '        dr("3") = dao3.fields.AMOUNT
    '        sum_profit = sum_profit + dao3.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("3") = 0
    '    End Try
    '    Try
    '        dr("4") = dao4.fields.AMOUNT
    '        sum_profit = sum_profit + dao4.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("4") = 0
    '    End Try
    '    dr("sumprofit") = sum_profit

    '    Try
    '        dr("5") = dao5.fields.AMOUNT
    '        sum_pay = sum_pay + dao5.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("5") = 0
    '    End Try
    '    Try
    '        dr("6") = dao6.fields.AMOUNT
    '        sum_pay = sum_pay + dao6.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("6") = 0
    '    End Try
    '    Try
    '        dr("7") = dao7.fields.AMOUNT
    '        sum_pay = sum_pay + dao7.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("7") = 0
    '    End Try
    '    Try
    '        dr("8") = dao8.fields.AMOUNT
    '        sum_pay = sum_pay + dao8.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("8") = 0
    '    End Try
    '    Try
    '        dr("9") = dao9.fields.AMOUNT
    '        sum_pay = sum_pay + dao9.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("9") = 0
    '    End Try
    '    Try
    '        dr("10") = dao10.fields.AMOUNT
    '        sum_pay = sum_pay + dao10.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("10") = 0
    '    End Try
    '    Try
    '        dr("11") = dao11.fields.AMOUNT
    '        sum_pay = sum_pay + dao11.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("11") = 0
    '    End Try
    '    Try
    '        dr("12") = dao12.fields.AMOUNT
    '        sum_pay = sum_pay + dao12.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("12") = 0
    '    End Try
    '    Try
    '        dr("13") = dao13.fields.AMOUNT
    '        sum_pay = sum_pay + dao13.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("13") = 0
    '    End Try
    '    Try
    '        dr("14") = dao14.fields.AMOUNT
    '        sum_pay = sum_pay + dao14.fields.AMOUNT
    '    Catch ex As Exception
    '        dr("14") = 0
    '    End Try

    '    dr("sumpay") = sum_pay
    '    dr("total") = sum_profit - sum_pay
    'Next
    Public Sub rg_rebind()
        rg_salary.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_salary, str)
    End Sub
    Public Sub export()
        'rg_salary.MasterTableView.GetColumn("EmployeeID").HeaderStyle.BackColor = Color.LightGray
        'rg_salary.MasterTableView.GetColumn("EmployeeID").ItemStyle.BackColor = Color.LightGray

        'rg_salary.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML
        rg_salary.ExportSettings.IgnorePaging = True
        rg_salary.ExportSettings.ExportOnlyData = True
        rg_salary.ExportSettings.OpenInNewWindow = True
        rg_salary.MasterTableView.ExportToExcel()
    End Sub
End Class