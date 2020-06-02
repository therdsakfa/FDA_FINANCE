Imports Telerik.Web.UI
Public Class UC_Import_Salary_Employee
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
    Private _byear_query As Integer
    Public Property byear_query() As Integer
        Get
            Return _byear_query
        End Get
        Set(ByVal value As Integer)
            _byear_query = value
        End Set
    End Property
    Private _month_nm As String
    Public Property month_nm() As String
        Get
            Return _month_nm
        End Get
        Set(ByVal value As String)
            _month_nm = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_import_Init(sender As Object, e As EventArgs) Handles rg_import.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_import
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("IDRUN", "IDRUN", False)
        Rad_Utility.addColumnBound("PREFIX_NAME", "คำนำหน้า")
        Rad_Utility.addColumnBound("NAME", "ชื่อ")
        Rad_Utility.addColumnBound("SURNAME", "สกุล")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "สังกัด")
        Rad_Utility.addColumnBound("sumprofit", "รวมรายรับ", is_money:=True)
        Rad_Utility.addColumnBound("sumpay", "รวมรายจ่าย", is_money:=True)
        Rad_Utility.addColumnBound("total", "คงเหลือเงินรับ", is_money:=True)
        ' Rad_Utility.addColumnBound("COOPERATE_NUMBER", "เลขสหกรณ์")
        'Rad_Utility.addColumnBound("month_txt", "เดือน")
    End Sub
    Public Sub insert(ByVal month_nm As String)
        For Each item As GridDataItem In rg_import.SelectedItems
            Dim dao_get As New DAO_SALARY.TB_SALARY
            Dim dao_det_get As New DAO_SALARY.TB_SALARY_DETAIL
            Dim dao_insert As New DAO_SALARY.TB_SALARY

            dao_get.Getdata_by_ID(item("IDRUN").Text)
            dao_det_get.Getdata_by_salary_id(item("IDRUN").Text)

            dao_insert.fields.BUDGET_YEAR = byear_query
            dao_insert.fields.Month_number = month_nm
            dao_insert.fields.PER_TYPE = dao_get.fields.PER_TYPE
            dao_insert.fields.PERSON_FK_ID = dao_get.fields.PERSON_FK_ID

            dao_insert.insert()
            Dim a As Integer = 0
            a = dao_insert.fields.IDRUN
            For Each dao_det_get.fields In dao_det_get.datas
                Dim dao_det_insert As New DAO_SALARY.TB_SALARY_DETAIL
                dao_det_insert.fields.AMOUNT = dao_det_get.fields.AMOUNT
                dao_det_insert.fields.SALARY_ID = a
                dao_det_insert.fields.SALARY_PAYLIST_ID = dao_det_get.fields.SALARY_PAYLIST_ID

                dao_det_insert.insert()
            Next

        Next

    End Sub

    Private Sub rg_import_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_import.NeedDataSource
       Dim bao As New BAO_BUDGET.Salary()
        Dim dt As New DataTable
        dt = bao.get_salary(BudgetYear, month_nm, 4)
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

        rg_import.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_import)
    End Sub

    Public Sub rebindRg()
        rg_import.Rebind()
    End Sub
End Class