Imports Telerik.Web.UI
Public Class UC_BudgetPlan_Detail_Type5
    Inherits System.Web.UI.UserControl
    Private _bgid As Integer
    Public Property bgid() As Integer
        Get
            Return _bgid
        End Get
        Set(ByVal value As Integer)
            _bgid = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_BG_Init(sender As Object, e As EventArgs) Handles rg_BG.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_BG
        Rad_Utility.Rad_css_setting(rg_BG)
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False)
        Rad_Utility.addColumnBound("BUDGET_CODE", "รหัสงบประมาณ")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "รายละเอียด", width:=250)
        Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_BG_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_BG.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
                Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
                dao_plan.Getdata_by_BUDGET_PLAN_ID(item("BUDGET_PLAN_ID").Text)
                dao_plan.delete()
                dao_node.getdata_by_Child_id(item("BUDGET_PLAN_ID").Text)
                dao_node.delete()
            End If
        End If
    End Sub

    Private Sub rg_BG_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_BG.ItemDataBound

    End Sub

    Private Sub rg_BG_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_BG.NeedDataSource
        Dim dt As New DataTable
        If bgid <> 0 Then
            Dim bao As New BAO_BUDGET.MASS
            dt = bao.get_bg_child(bgid)
        End If

        rg_BG.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rg_BG.Rebind()
    End Sub
End Class