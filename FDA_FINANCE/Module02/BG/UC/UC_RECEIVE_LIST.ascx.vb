Public Class UC_RECEIVE_LIST
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_Budget_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Budget.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Budget
        Rad_Utility.Rad_css_setting(rg_Disburse_Budget)
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("product", "งาน/โครงการ", False)
        Rad_Utility.addColumnBound("operation", "หมวดรายจ่าย", False)
        Rad_Utility.addColumnBound("DEPARTMENT_ID", "กอง", False)
        Rad_Utility.addColumnBound("bguse_id", "ประเภทเงิน", False)
        Rad_Utility.addColumnBound("BILL_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BUDGET_YEAR", "ปีงบประมาณ")
        Rad_Utility.addColumnBound("bguse", "ประเภทเงิน")
        Rad_Utility.addColumnButton("sel", "เลือก", "sel", 0, "")

    End Sub

    Private Sub rg_Disburse_Budget_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_Disburse_Budget.ItemDataBound

    End Sub

    Private Sub rg_Disburse_Budget_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_Budget.NeedDataSource

    End Sub
End Class