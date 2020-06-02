Imports Telerik.Web.UI
Partial Public Class UC_Budget_CarryMoney
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgBGOverlap_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgBGOverlap.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgBGOverlap
        Rad_Utility.addColumnBound("OVERLAP_HEAD_ID", "OVERLAP_HEAD_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("STATUS_DESCRIPTION", "สถานะ")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "งบประมาณ")
        Rad_Utility.addColumnBound("OVERLAP_AMOUNT", "จำนวนเงินกันไว้เหลื่อมปี")
        Rad_Utility.addColumnBound("OVERLAP_HEAD_DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgBGOverlap_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgBGOverlap.ItemCommand

    End Sub

    Private Sub rgBGOverlap_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgBGOverlap.NeedDataSource
        Dim bao_overlap As New BAO_BUDGET.Budget
        rgBGOverlap.DataSource = bao_overlap.get_OVERLAP()
    End Sub
End Class