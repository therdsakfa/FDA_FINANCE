Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_CheckList
    Inherits System.Web.UI.UserControl
    Private _chk_number As String
    Public Property chk_number() As String
        Get
            Return _chk_number
        End Get
        Set(ByVal value As String)
            _chk_number = value
        End Set
    End Property
    'Public rg As RadGrid

    Private _drtable As DataRow
    Public Property drtable() As DataRow
        Get
            Return _drtable
        End Get
        Set(ByVal value As DataRow)
            _drtable = value
        End Set
    End Property

    Private _select_type As Integer
    Public Property select_type() As Integer
        Get
            Return _select_type
        End Get
        Set(ByVal value As Integer)
            _select_type = value
        End Set
    End Property
    Private _bguse As Integer
    Public Property bguse() As Integer
        Get
            Return _bguse
        End Get
        Set(ByVal value As Integer)
            _bguse = value
        End Set
    End Property
    Private _txt_date As DateTime
    Public Property txt_date() As DateTime
        Get
            Return _txt_date
        End Get
        Set(ByVal value As DateTime)
            _txt_date = value
        End Set
    End Property
    Private _p_count As Integer
    Public Property p_count() As Integer
        Get
            Return _p_count
        End Get
        Set(ByVal value As Integer)
            _p_count = value
        End Set
    End Property

    Public dt_grid As DataTable

    Public Sub Set_CheckList(ByVal Checklist As String)
        If L_check.Text = "" Then
            L_check.Text = Checklist
        Else
            L_check.Text = L_check.Text & "," & Checklist
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddBudgetCheck_Init(sender As Object, e As EventArgs) Handles rgAddBudgetCheck.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddBudgetCheck
        'Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        ' Rad_Utility.addColumnBound("id_table", "id_table", False)
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขเช็ค")
        Rad_Utility.addColumnBound("bill_type", "bill_type", False)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        'Rad_Utility.addColumnDate("PRINT_DATE", "วันที่พิมพ์")
        Rad_Utility.addColumnButton("E", "เพิ่มข้อมูล", "E", 0, "")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "")
    End Sub

    Public Function get_Report_R9_001_bill(ByVal id_where As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Budget
        Dim str As String = " "

        str &= " select * from  dbo.Tb_AllCheckTest()"
        str &= " where CHECK_NUMBER in (" & id_where & ")"
        str &= " order by CHECK_NUMBER	 "
        dt = bao.Queryds(str)

        Return dt
    End Function


    Private Sub rgAddBudgetCheck_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgAddBudgetCheck.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "E" Then
                Dim dao As New DAO_MAS.TB_PRINT_CHECK_HISTORY
                'dr("id_table") = item("id_table").Text
                Dim checknumber As String = item("CHECK_NUMBER").Text

                dao.fields.CHECK_NUMBER = checknumber
                dao.fields.BILL_TYPE = item("BILL_TYPE").Text
                dao.fields.PRINT_COUNT = p_count
                dao.fields.PRINT_DATE = DateTime.Parse(txt_date & " " & Format(DateTime.Now, "HH:mm:ss"))
                'dao.fields.PRINT_DATE_STR = txt_date.ToString()
                dao.fields.PRINT_DATE_STR = DateTime.Parse(txt_date & " " & Format(DateTime.Now, "HH:mm:ss")).ToString()
                dao.insert()

                ReplaceListCheck(checknumber)
                rgAddBudgetCheck.Rebind()

                Dim p As Object = Me.Page
                p.BindData()
                '    End If
                'BindData()
            ElseIf e.CommandName = "D" Then
                Dim checknumber As String = item("CHECK_NUMBER").Text
                ReplaceListCheck(checknumber)
                rgAddBudgetCheck.Rebind()
            End If

        End If
    End Sub


    Private Sub ReplaceListCheck(ByVal CheckName As String)
        Dim splitcheck() As String = L_check.Text.Split(",")
        Dim temp As String = ""
        For Each ch As String In splitcheck
            If CheckName <> ch.Replace("'", "") Then
                If temp = "" Then
                    temp = ch
                Else
                    temp = temp & "," & ch
                End If
            End If
        Next
        L_check.Text = temp

    End Sub





    Private Sub rgAddDebtorCheck_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgAddBudgetCheck.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS()
        Dim dt As New DataTable
        If select_type = 1 Then
            If L_check.Text <> "" Then
                dt = get_Report_R9_001_bill(L_check.Text)
            End If

        ElseIf select_type = 2 Then
            'dt = bao.get_check_number_by_name_bill(chk_number, bguse)
            If L_check.Text <> "" Then
                dt = get_Report_R9_001_bill(L_check.Text)
            End If
        ElseIf select_type = 3 Then
            'dt = bao.get_check_number_by_money_bill(chk_number, bguse)
            If L_check.Text <> "" Then
                dt = get_Report_R9_001_bill(L_check.Text)
            End If
        ElseIf select_type = 4 Then
            ' dt = bao.get_check_number_by_bill_num_bill(chk_number, bguse)
            If L_check.Text <> "" Then
                dt = get_Report_R9_001_bill(L_check.Text)
            End If
        End If

        rgAddBudgetCheck.DataSource = dt
    End Sub

    Public Sub rg_rebind()
        rgAddBudgetCheck.Rebind()
    End Sub


    'Private Sub BindData()
    '    Dim Frm_print As New Frm_Disburse_Budget_Print_Check
    '    Frm_print = Me.Page
    '    Frm_print.bind()
    'End Sub
End Class