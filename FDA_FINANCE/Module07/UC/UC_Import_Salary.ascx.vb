Imports Telerik.Web.UI
Public Class UC_Import_Salary
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
        Rad_Utility.addColumnBound("COOPERATE_NUMBER", "เลขสหกรณ์")
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
        dt = bao.get_salary(BudgetYear, month_nm, 2)
        dt.Columns.Add("1", Type.GetType("System.Double"))
        dt.Columns.Add("2", Type.GetType("System.Double"))
        dt.Columns.Add("3", Type.GetType("System.Double"))
        dt.Columns.Add("4", Type.GetType("System.Double"))
        dt.Columns.Add("sumprofit", Type.GetType("System.Double"))
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
        dt.Columns.Add("month_txt")
        dt.Columns.Add("sumpay", Type.GetType("System.Double"))
        dt.Columns.Add("total", Type.GetType("System.Double"))
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
            Dim bao_uti As New Report_Utility
            Try
                dr("month_txt") = bao_uti.get_Long_month_BY_Number(dr("Month_number"))
            Catch ex As Exception

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