Imports Telerik.Web.UI
Partial Public Class UC_Budget
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgBudget_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgBudget.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgBudget
        Rad_Utility.addColumnBound("BUDGET_ADJUST_ID", "BUDGET_ADJUST_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("BUDGET_DEPARTMENT_MONEY", "จำนวนเงิน")
    End Sub

    Private Sub rgBudget_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgBudget.ItemCommand

    End Sub

    Private Sub rgBudget_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgBudget.NeedDataSource
        Dim bao_adjust As New BAO_BUDGET.Budget
        ' rgBudget.DataSource = bao_adjust.get_BUDGET_ADJUST()
    End Sub

    Public Sub getdata(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
        txt_BudgetHead.Text = dao.fields.BUDGET_DESCRIPTION
        txt_Child1.Text = dao.fields.BUDGET_DESCRIPTION
        txt_Child2.Text = dao.fields.BUDGET_DESCRIPTION
        txt_Amount.Text = dao.fields.BUDGET_AMOUNT
    End Sub
End Class