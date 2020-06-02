Public Partial Class UC_Budget_Project_Disburse
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDeptDisburse_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgDeptDisburse.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDeptDisburse
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("IS_APPROVE", "อนุมัติ")
        Rad_Utility.addColumnBound("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("PAYLIST_DESCRIPTION", "ค่าใช้จ่าย")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("fullname", "ชื่อผู้ยืม")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgDeptDisburse_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDeptDisburse.NeedDataSource
        Dim bao_DeptDisburse As New BAO_BUDGET.Budget
        rgDeptDisburse.DataSource = bao_DeptDisburse.get_Disburse_dept(1, 1)
    End Sub
End Class