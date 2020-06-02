Imports Telerik.Web.UI
Public Class UC_Budget_Type
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgBudgetType_Init(sender As Object, e As EventArgs) Handles rgBudgetType.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgBudgetType
        Rad_Utility.addColumnBound("BUDGET_TYPE_ID", "BUDGET_TYPE_ID", False, width:=10)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=15)
        Rad_Utility.addColumnBound("BUDGET_TYPE_NAME", "ชื่อประเภทงบ")
        Rad_Utility.addColumnBound("BUDGET_TYPE_AMOUNT", "ชื่อจำนวนเงิน", is_money:=True)
        'Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgBudgetType_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgBudgetType.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_BUDGET.TB_MAS_BUDGET_TYPE
                dao.Getdata_by_BUDGET_TYPE_ID(item("BUDGET_TYPE_ID").Text)
                dao.delete()
                rgBudgetType.Rebind()
                'Response.Redirect("/Module06/Frm_Budget_Type.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("/Module06/Frm_Budget_Type_Edit.aspx?id=" & item("BUDGET_TYPE_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgBudgetType_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgBudgetType.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_TYPE_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Budget_Type_Edit.aspx?id=" & id & "&bgyear=" & BudgetYear
            h2.Attributes.Add("OnClick", "return k('" & url & "');")


        End If
    End Sub

    Private Sub rgBudgetType_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgBudgetType.NeedDataSource
        'Dim dao As New DAO_BUDGET.TB_MAS_BUDGET_TYPE
        'dao.Getdata_by_budget_year(2557)
        'rgBudgetType.DataSource = dao.dt
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.getBudgetTypeData(BudgetYear)
        rgBudgetType.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgBudgetType)
    End Sub
    Public Sub rg_rebind()
        rgBudgetType.Rebind()
    End Sub
End Class