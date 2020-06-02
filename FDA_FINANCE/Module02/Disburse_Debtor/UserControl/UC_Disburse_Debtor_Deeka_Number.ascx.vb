Imports Telerik.Web.UI

Public Class UC_Disburse_Debtor_Deeka_Number
    Inherits System.Web.UI.UserControl
    Private _BudgetUseID As Integer
    Public Property BudgetUseID() As Integer
        Get
            Return _BudgetUseID
        End Get
        Set(ByVal value As Integer)
            _BudgetUseID = value
        End Set
    End Property
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
    Private _bt As Integer
    Public Property bt() As Integer
        Get
            Return _bt
        End Get
        Set(ByVal value As Integer)
            _bt = value
        End Set
    End Property
    Private _stat As Integer
    Public Property stat() As Integer
        Get
            Return _stat
        End Get
        Set(ByVal value As Integer)
            _stat = value
        End Set
    End Property
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDeeka_Init(sender As Object, e As EventArgs) Handles rgDeeka.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDeeka
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")

        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnDate("GFMIS_DATE", "วันที่ขบ.")
        Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        ' Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("id_det", "id_det", False)
        Rad_Utility.addColumnButton("E", "เพิ่มเลขฎีกา", "E", 0, "คุณต้องการเพิ่มเลขฎีกาหรือไม่")
    End Sub

    Private Sub rgDeeka_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgDeeka.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As String = ""
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim debt As Integer = Nothing
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            'If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
            '    debt = dao.fields.DEBTOR_TYPE_ID
            id = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Deeka_Number_Insert.aspx?bid=" & item("DEBTOR_BILL_ID").Text & "&debt=" & debt & "&bt=" & bt & "&stat=" & stat & "&g=" & _g
            'End If


            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            'h2.Attributes.Add("OnClick", "return k('" & id & "');")
            h2.Attributes.Add("OnClick", "Popups('" & id & "'); return false;")
        End If
    End Sub

    Private Sub rgDeeka_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgDeeka.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable
        Try
            dt = bao.get_Debtor_Deeka_Number_bt_group(Budgetyear, BudgetUseID, stat - 1, g)
        Catch ex As Exception

        End Try

        rgDeeka.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDeeka, str)
    End Sub
    'Public Sub bindseq()
    '    Dim ut_seq As New Radgrid_Utility
    '    ut_seq.addSeqRG(rgDeeka)
    '    'rg_Disburse_Budget.Rebind()
    'End Sub
    Public Sub rg_rebind()
        rgDeeka.Rebind()
    End Sub
End Class