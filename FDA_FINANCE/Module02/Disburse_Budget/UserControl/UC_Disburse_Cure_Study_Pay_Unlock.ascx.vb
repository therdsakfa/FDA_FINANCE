Imports Telerik.Web.UI

Public Class UC_Disburse_Cure_Study_Pay_Unlock
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
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
    Private _Bill_type As Integer
    Public Property Bill_type() As Integer
        Get
            Return _Bill_type
        End Get
        Set(ByVal value As Integer)
            _Bill_type = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgUnlock_pay_Init(sender As Object, e As EventArgs) Handles rgUnlock_pay.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgUnlock_pay
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่หนังสือ")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
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
            lnk_ist = "../../Module02/Disburse_Budget/Frm_Disburse_Cure_Pay_Unlock_Insert.aspx?bid=" & item("CURE_STUDY_ID").Text & "&stat=" & _stat & "&g=" & _g & "&bt=" & _bt
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
        dt = bao.get_cure_study_check_number(bgyear, stat - 1, g, Bill_type)

        rgUnlock_pay.DataSource = dt
    End Sub
End Class