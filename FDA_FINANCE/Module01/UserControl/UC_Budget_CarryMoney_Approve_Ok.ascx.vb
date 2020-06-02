Public Partial Class UC_Budget_CarryMoney_Approve
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAppOverlap_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgAppOverlap.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAppOverlap
        Rad_Utility.addColumnBound("OVERLAP_HEAD_ID", "OVERLAP_HEAD_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("OVERLAP_HEAD_APPROVE", "อนุมัติ")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "งบประมาณ")
        Rad_Utility.addColumnBound("OVERLAP_AMOUNT", "จำนวนเงินกันไว้เหลื่อมปี")
        Rad_Utility.addColumnBound("OVERLAP_HEAD_DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnButton("A", "อนุมัติ", "A", 0, "คุณต้องการอนุมัติหรือไม่")
        'Rad_Utility.addColumnButton("NA", "ไม่อนุมัติ", "NA", 0, "คุณต้องการไม่อนุมัติหรือไม่")
    End Sub

    Private Sub rgAppOverlap_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAppOverlap.ItemCommand

    End Sub

    Private Sub rgAppOverlap_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAppOverlap.NeedDataSource
        Dim bao_overlap As New BAO_BUDGET.Budget
        rgAppOverlap.DataSource = bao_overlap.get_OVERLAP()
    End Sub
End Class