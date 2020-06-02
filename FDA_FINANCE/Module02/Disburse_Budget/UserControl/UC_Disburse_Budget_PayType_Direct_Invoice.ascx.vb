Imports Telerik.Web.UI

Public Class UC_Disburse_Budget_PayType_Direct_Invoice
    Inherits System.Web.UI.UserControl
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _digit As Integer
    Public Property digit() As Integer
        Get
            Return _digit
        End Get
        Set(ByVal value As Integer)
            _digit = value
        End Set
    End Property
    Private _select_digit As String
    Public Property select_digit() As String
        Get
            Return _select_digit
        End Get
        Set(ByVal value As String)
            _select_digit = value
        End Set
    End Property
    Private _bg_use As String
    Public Property bg_use() As String
        Get
            Return _bg_use
        End Get
        Set(ByVal value As String)
            _bg_use = value
        End Set
    End Property
    Private _strFilter As String
    Public Property strFilter() As String
        Get
            Return _strFilter
        End Get
        Set(ByVal value As String)
            _strFilter = value
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
    Private _ispo As Boolean
    Public Property ispo() As Boolean
        Get
            Return _ispo
        End Get
        Set(ByVal value As Boolean)
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
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub rgPayDirect_Init(sender As Object, e As EventArgs) Handles rgPayDirect.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgPayDirect
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        Rad_Utility.addColumnBound("INVOICES_NUMBER", "เลขที่ใบแจ้งหนี้")
        Rad_Utility.addColumnDate("INVOICES_DATE", "วันที่บันทึกเลขที่ใบแจ้งหนี้")
        Rad_Utility.addColumnCheckbox("IS_RECEIVE_TAX", "รับใบหักภาษี")
        Rad_Utility.addColumnBound("RECEIVER_TAX_NAME", "ชื่อผู้รับใบหักภาษี")
        Rad_Utility.addColumnDate("RECEIVE_TAX_DATE", "วันที่รับใบหักภาษี")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("S", "เพิ่ม/แก้ไขข้อมูล", "S", 0, "", headertext:="")
    End Sub

    Private Sub rgPayDirect_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgPayDirect.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim url As String = "Frm_Disburse_Budget_PayType_Direct_Invoice_Edit.aspx?bid=" & id & "&bt=" & bt & "&stat=" & stat & "&g=" & g
            h2.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
        End If
    End Sub

    Private Sub rgPayDirect_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgPayDirect.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        If ispo = True Then
            dt = bao.get_bill_paydirect_invoice_po_V2(bg_use, bgyear, stat - 1, g)
        Else
            dt = bao.get_bill_paydirect_invoice_V2(bg_use, bgyear, stat - 1, g)
        End If
        rgPayDirect.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgPayDirect, str)
    End Sub
    Public Sub rg_rebind()
        rgPayDirect.Rebind()
    End Sub
End Class