Imports Telerik.Web.UI

Public Class UC_Disburse_Budget_PayType_Pass_Pay_Unlock
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
    Private _is_rebill As Boolean
    Public Property is_rebill() As Boolean
        Get
            Return _is_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_rebill = value
        End Set
    End Property
    Private _is_no_rebill As Boolean
    Public Property is_no_rebill() As Boolean
        Get
            Return _is_no_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_no_rebill = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgUnlock_pay_Init(sender As Object, e As EventArgs) Handles rgUnlock_pay.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgUnlock_pay
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("id_det", "id_det", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่หนังสือ")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnBound("RETURN_APPROVE_NUMBER", "เลขปลดจ่าย")
        Rad_Utility.addColumnDate("RETURN_APPROVE_DATE", "วันที่เลขปลดจ่าย")
        Rad_Utility.addColumnButton("E", "เพิ่มเลขปลดจ่าย", "E", 0, "")
    End Sub

    Private Sub rgUnlock_pay_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgUnlock_pay.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim lnk_ist As String = ""
            lnk_ist = "../../Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_PM_Unlock_Insert.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text & "&stat=" & _stat & "&g=" & _g & "&bt=" & _bt
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "Popups('" & lnk_ist & "'); return false;")

        End If
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgUnlock_pay, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgUnlock_pay)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rgRebind()
        rgUnlock_pay.Rebind()
    End Sub

    Private Sub rgUnlock_pay_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgUnlock_pay.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()

        If is_rebill = True Then
            dt = bao.get_rebill_PM_Unlock_V2(bg_use, bgyear, stat - 1, g)
        ElseIf is_no_rebill = True Then
            dt = bao.get_no_rebill_PM_Unlock(bg_use, bgyear, stat - 1, g)
        Else
            dt = bao.get_bill_PM_Unlock_V2(bg_use, bgyear, stat - 1, g)
        End If

        rgUnlock_pay.DataSource = dt
    End Sub
End Class