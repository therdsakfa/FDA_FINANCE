Imports Telerik.Web.UI
Partial Public Class UC_Budget_Expand_Money
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

    Private Sub rgExpandMoney_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgExpandMoney.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgExpandMoney
        Rad_Utility.addColumnBound("OVERLAP_HEAD_ID", "OVERLAP_HEAD_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        'Rad_Utility.addColumnCheckbox("OVERLAP_APPROVE", "การอนุมัติ")
        Rad_Utility.addColumnDate("DOC_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("PAYLIST_DESCRIPTION", "ค่าใช้จ่าย")
        Rad_Utility.addColumnDate("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินกัน", is_money:=True)
        Rad_Utility.addColumnCheckbox("IS_OVERLAP_EXPAND", "เงินขยายเงินกัน")
        Rad_Utility.addColumnBound("EXPAND_AMOUNT", "จำนวนเงินขยายเงินกัน", is_money:=True)
        Rad_Utility.addColumnBound("EXPAND_DATE", "ขยายถึงวันที่")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")




    End Sub

    Private Sub rgExpandMoney_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgExpandMoney.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "E" Then

                Response.Redirect("/Module01/Frm_Budget_Expand_Money_Edit.aspx?oid=" & item("OVERLAP_HEAD_ID").Text)

            End If
        End If
    End Sub

    Private Sub rgExpandMoney_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgExpandMoney.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.getOverlap(BudgetYear, dept_id, _bgid)
        rgExpandMoney.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgExpandMoney)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgExpandMoney, str)
    End Sub
    Public Sub rebind_grid()
        rgExpandMoney.Rebind()
    End Sub
End Class