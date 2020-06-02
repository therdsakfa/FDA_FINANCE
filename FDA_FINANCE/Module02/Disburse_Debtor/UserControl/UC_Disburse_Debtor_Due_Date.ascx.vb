Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Due_Date
    Inherits System.Web.UI.UserControl
    Private _bg_use As String
    Public Property bg_use() As String
        Get
            Return _bg_use
        End Get
        Set(ByVal value As String)
            _bg_use = value
        End Set
    End Property

    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
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
    Private _debtor_type As Integer
    Public Property debtor_type() As Integer
        Get
            Return _debtor_type
        End Get
        Set(ByVal value As Integer)
            _debtor_type = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_debtor_duedate_Init(sender As Object, e As EventArgs) Handles rg_debtor_duedate.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_debtor_duedate
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่หนังสือ")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อลูกหนี้")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnBound("RETURN_APPROVE_NUMBER", "เลขปลดจ่าย")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันครบกำหนดคืนเงิน")
        Rad_Utility.addColumnButton("E", "เพิ่มเลขฎีกา", "E", 0, "คุณต้องการเพิ่มเลขฎีกาหรือไม่")
    End Sub

    Private Sub rg_debtor_duedate_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_debtor_duedate.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As String = ""
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim debt As Integer = Nothing
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            id = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Unlock_Pay_Insert.aspx?bid=" & item("DEBTOR_BILL_ID").Text & "&debt=" & debt & "&bt=" & bt & "&stat=" & stat & "&g=" & _g
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "Popups('" & id & "'); return false;")
        End If
    End Sub
    Private Sub rg_debtor_duedate_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_debtor_duedate.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

        dt = bao.get_debtor_bill_by_stat_group(bg_use, bgyear, stat - 1, g, debtor_type)
        rg_debtor_duedate.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_debtor_duedate, str)
    End Sub
    Public Sub rebind_grid()
        rg_debtor_duedate.Rebind()
    End Sub
End Class