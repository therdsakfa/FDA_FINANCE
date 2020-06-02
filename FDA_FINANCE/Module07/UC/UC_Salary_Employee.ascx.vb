Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports xi = Telerik.Web.UI.ExportInfrastructure
Imports System.Web.UI
Imports System.Web
Imports Telerik.Web.UI.GridExcelBuilder
Imports System.Drawing
Public Class UC_Salary_Employee
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
        Rad_Utility.addColumnBound("STATUS_PERSON", "STATUS_PERSON", False)
        Rad_Utility.addColumnBound("idp", "idp", False)
        Rad_Utility.addColumnBound("fullname", "fullname", False)
        Rad_Utility.addColumnBound("dept_long", "dept_long", False)
        Rad_Utility.addColumnBound("PREFIX_NAME", "คำนำหน้า")
        Rad_Utility.addColumnBound("NAME", "ชื่อ")
        Rad_Utility.addColumnBound("SURNAME", "สกุล")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "สังกัด")
        'Rad_Utility.addColumnBound("1", "ค่าตอบแทนรายเดือน", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("2", "ค่าตอบแทน(ตกเบิก)", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("3", "ค่าครองชีพ", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("4", "ค่าครองชีพตกเบิก", is_money:=True, is_footer:=True)
        Rad_Utility.addColumnBound("sumprofit", "รวมรายรับ", is_money:=True)
        'Rad_Utility.addColumnBound("5", "ปกส. 5%", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("9", "สอ.วว.", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("10", "สอ.กรมป่าไม้", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("11", "ประกันชีวิต AIA.", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("12", "ธอส.", is_money:=True, is_footer:=True)
        'Rad_Utility.addColumnBound("13", "ออมสิน", is_money:=True)
        Rad_Utility.addColumnBound("sumpay", "รวมรายจ่าย", is_money:=True)
        Rad_Utility.addColumnBound("total", "คงเหลือเงินรับ", is_money:=True)
        Rad_Utility.addColumnButton("I", "เพิ่ม/ดูค่าใช้จ่าย", "I", 0, "", width:=130)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
        Rad_Utility.addColumnButton("print", "พิมพ์สลิป", "print", 0, "", width:=120)
        ''Rad_Utility.addColumnIMG("I", "เพิ่ม/ดูค่าใช้จ่าย", "I", 0, "", img:=True, type_img:="insert")
        ''Rad_Utility.addColumnIMG("E", "แก้ไข", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        ''Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
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
            Dim url As String = "Frm_Salary_Personal_Edit.aspx?id=" & item("IDRUN").Text & "&bgyear=" & BudgetYear & "&t=4"
            h1.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            Dim url_in As String = "Frm_Salary_List.aspx?id=" & id & "&m=" & month_num
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
        dt = bao.get_salary(BudgetYear, month_num, per_type)
        'End If
        dt.Columns.Add("15", Type.GetType("System.Double"))
        dt.Columns.Add("sumprofit", Type.GetType("System.Double"))
        dt.Columns.Add("16", Type.GetType("System.Double"))
        dt.Columns.Add("17", Type.GetType("System.Double"))
        dt.Columns.Add("sumpay", Type.GetType("System.Double"))
        dt.Columns.Add("total", Type.GetType("System.Double"))
        For Each dr As DataRow In dt.Rows
            Dim sum_profit As Double = 0
            Dim sum_pay As Double = 0

            Dim bao15 As New BAO_BUDGET.Salary()
            Dim bao16 As New BAO_BUDGET.Salary()
            Dim bao17 As New BAO_BUDGET.Salary()
            Try
                dr("15") = bao15.get_salary_paylist_amount(dr("IDRUN"), 15)
                sum_profit = sum_profit + bao15.get_salary_paylist_amount(dr("IDRUN"), 15)
            Catch ex As Exception
                dr("15") = 0
            End Try
            Try
                dr("16") = bao16.get_salary_paylist_amount(dr("IDRUN"), 16)
                sum_pay = sum_pay + bao16.get_salary_paylist_amount(dr("IDRUN"), 16)
            Catch ex As Exception
                dr("16") = 0
            End Try

            Try
                dr("17") = bao17.get_salary_paylist_amount(dr("IDRUN"), 17)
                sum_pay = sum_pay + bao17.get_salary_paylist_amount(dr("IDRUN"), 17)
            Catch ex As Exception
                dr("17") = 0
            End Try

            dr("sumprofit") = sum_profit
            dr("sumpay") = sum_pay
            dr("total") = sum_profit - sum_pay
        Next

        rg_salary.DataSource = dt
    End Sub
    
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