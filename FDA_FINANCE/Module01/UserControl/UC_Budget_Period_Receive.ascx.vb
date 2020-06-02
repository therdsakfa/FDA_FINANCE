Imports Telerik.Web.UI
Public Class UC_Budget_Period_Receive
    Inherits System.Web.UI.UserControl
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
        End Set
    End Property
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_period_receive_Init(sender As Object, e As EventArgs) Handles rg_period_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_period_receive
        Rad_Utility.Rad_css_setting(rg_period_receive)
        Rad_Utility.addColumnBound("BUDGET_ADJUST_ID", "BUDGET_ADJUST_ID", False)
        Rad_Utility.addColumnBound("ADJUST_DETAIL_ID", "ADJUST_DETAIL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เลขที่เอกสาร")
        Rad_Utility.addColumnBound("Head_BG", "โครงการ")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "ชื่องบ")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายละเอียด")
        Rad_Utility.addColumnBound("BUDGET_DEPARTMENT_MONEY", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("DEPARTMENT_ID", "DEPARTMENT_ID", False)
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False)
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        ' Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_period_receive_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_period_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_ADJUST_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "../Module01/Frm_Budget_Adjust_Period_Receive_Edit.aspx?ba_id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")
        End If
    End Sub

    Private Sub rg_period_receive_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_period_receive.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        ' Dim dt As DataTable = bao.get_period_receive(BudgetYear, BudgetID)
        Dim dt As DataTable
        dt = bao.get_bg_adjust_receive_period(BudgetYear)
        rg_period_receive.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_period_receive, str)
    End Sub
    Public Sub rebind_grid()
        rg_period_receive.Rebind()
    End Sub
End Class