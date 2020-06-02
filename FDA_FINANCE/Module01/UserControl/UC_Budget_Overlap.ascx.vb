Imports Telerik.Web.UI
Public Class UC_Budget_Overlap
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
    Private _bgid As Integer
    Public Property bdid() As Integer
        Get
            Return _bgid
        End Get
        Set(ByVal value As Integer)
            _bgid = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgOverlap_Init(sender As Object, e As EventArgs) Handles rgOverlap.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgOverlap
        Rad_Utility.addColumnBound("OVERLAP_ID", "OVERLAP_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnDate("OVERLAP_DATE", "วันที่กันเงิน")
        Rad_Utility.addColumnDate("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("balance", "เงินคงเหลือ ณ ปัจจุบัน", is_money:=True)
        Rad_Utility.addColumnButton("C", "ยกเลิกเงินกัน", "C", 0, "คุณต้องการยกเลิกหรือไม่")
    End Sub

    Private Sub rgOverlap_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgOverlap.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
          
        End If
    End Sub


    Private Sub rgOverlap_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgOverlap.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.getOverlap(BudgetYear, dept_id, _bgid)
        rgOverlap.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgOverlap)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgOverlap, str)
    End Sub
    Public Sub rebind_grid()
        rgOverlap.Rebind()
    End Sub
End Class