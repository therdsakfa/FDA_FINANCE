Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_CheckList_Temp
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
    Public rg As RadGrid

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddBudgetCheck_Init(sender As Object, e As EventArgs) Handles rgAddBudgetCheck.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddBudgetCheck

        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        ' Rad_Utility.addColumnBound("id_table", "id_table", False)
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขเช็ค")
        Rad_Utility.addColumnBound("bill_type", "bill_type", False)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnIMG("A", "แก้ไขข้อมูล", "A", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnDate("PRINT_DATE", "วันที่พิมพ์")

    End Sub

    Private Sub rgAddBudgetCheck_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgAddBudgetCheck.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "E" Then
                Dim dao As New DAO_MAS.TB_PRINT_CHECK_HISTORY
                'dr("id_table") = item("id_table").Text
                dao.fields.CHECK_NUMBER = item("CHECK_NUMBER").Text
                dao.fields.BILL_TYPE = item("bill_type").Text
                dao.fields.PRINT_COUNT = p_count
                dao.fields.PRINT_DATE = txt_date
                dao.fields.PRINT_DATE_STR = txt_date.ToString()
                dao.insert()
                Dim p As Object = Me.Page
                p.BindData()
                '    End If

            End If

        End If
    End Sub

    Private Sub rgAddBudgetCheck_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgAddBudgetCheck.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim bill_type As String = item("bill_type").Text
            Dim ch_num As String = item("CHECK_NUMBER").Text
            Dim edit As ImageButton = DirectCast(item("A").Controls(0), ImageButton)
            Dim link As String = ""
            If bill_type = "1" Or bill_type = "5" Then
                link = "Frm_Disburse_Budget_Print_Check_Edit_Type1_and_Type5.aspx?ch=" & ch_num
            ElseIf bill_type = "6" Or bill_type = "7" Or bill_type = "8" Then
                link = "Frm_Disburse_Budget_Print_Check_Edit_Type6_7_8.aspx?ch=" & ch_num
            ElseIf bill_type = "2" Then
                link = "Frm_Disburse_Budget_Print_Check_Edit_Type2.aspx?ch=" & ch_num
            ElseIf bill_type = "3" Then
                link = "Frm_Disburse_Budget_Print_Check_Edit_Type3.aspx?ch=" & ch_num
            End If

            edit.Attributes.Add("OnClick", "return k('" & link & "');")
        End If
    End Sub

    'Public Function serialgrid(ByVal R As RadGrid) As DataTable
    '    Dim DT As New DataTable
    '    DT = gridaddcolumn(R)

    '    grid_reindex(DT, "ID")
    '    For Each g As GridDataItem In R.Items
    '        Dim dr As DataRow = DT.NewRow()
    '        For Each C As DataColumn In DT.Columns
    '            dr(C.ColumnName) = g(C.ColumnName).Text
    '        Next
    '        DT.Rows.Add(dr)
    '    Next
    '    Return DT
    'End Function


    'Public Sub grid_reindex(ByRef dt As DataTable, ByVal Cname As String)
    '    Dim i As Integer = 1
    '    For Each dr As DataRow In dt.Rows
    '        dr(Cname) = i
    '        i = i + 1
    '    Next
    'End Sub


    'Public Overloads Function gridaddcolumn(ByVal R As RadGrid) As DataTable
    '    Dim DT As New DataTable
    '    For Each G As GridColumn In R.Columns
    '        DT.Columns.Add(G.UniqueName)
    '    Next
    '    Return DT
    'End Function

    Private Sub rgAddDebtorCheck_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgAddBudgetCheck.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS()
        Dim dt As New DataTable
        Dim StrID As String = ""
        If Request.QueryString("btype") IsNot Nothing Then
            StrID = Request.QueryString("btype")
        End If
        If select_type = 1 Then
            '    dt = bao.get_check_number_bill(chk_number, bguse)
           
            dt = bao.get_check_number_All(chk_number, StrID)
        ElseIf select_type = 2 Then

            ' dt = bao.get_check_number_by_name_bill(chk_number, bguse)
            dt = bao.get_check_number_by_name_bill_ALL(chk_number, StrID)
        ElseIf select_type = 3 Then
            'dt = bao.get_check_number_by_money_bill(chk_number, bguse)
            dt = bao.get_check_number_by_money_bill_ALL(chk_number, StrID)
        ElseIf select_type = 4 Then
            ' dt = bao.get_check_number_by_bill_num_bill(chk_number, bguse)
            dt = bao.get_check_number_by_bill_num_bill_ALL(chk_number, StrID)
        End If

        rgAddBudgetCheck.DataSource = dt
    End Sub

    Public Sub rg_rebind()
        rgAddBudgetCheck.Rebind()
    End Sub


    ''' <summary>
    ''' ดึงรายการเช็คที่เลือก
    ''' </summary>
    Public Function rg_Bind_ListCheck()
        Dim temp As String = ""
        For Each g As GridDataItem In rgAddBudgetCheck.SelectedItems
            If temp = "" Then
                temp = "'" & g("CHECK_NUMBER").Text & "'"
            Else
                temp = temp & ",'" & g("CHECK_NUMBER").Text & "'"
            End If
        Next
        Return temp
    End Function

    Private Sub rgAddBudgetCheck_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles rgAddBudgetCheck.PageIndexChanged
        rgAddBudgetCheck.Rebind()
    End Sub
End Class