Public Partial Class UC_BudgetPlan_Member
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgBudgetmember_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgBudgetmember.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgBudgetmember
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False, width:=10)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=15)
        Rad_Utility.addColumnBound("BUDGET_CODE", "รหัส")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "รายการ")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub
End Class