Imports Telerik.Web.UI
Public Class UC_Budget_Overlap_Bill
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddOverlapBill_Init(sender As Object, e As EventArgs) Handles rgAddOverlapBill.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddOverlapBill
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", width:=120, is_money:=True)
    End Sub

    Private Sub rgAddOverlapBill_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAddOverlapBill.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.get_po_prepare_overlap(Request.QueryString("bgyear"), Request.QueryString("bgid"), Request.QueryString("dept"))
        rgAddOverlapBill.DataSource = dt

    End Sub
    'Public Sub insert()

    '    For Each item As GridDataItem In rgAddOverlapBill.SelectedItems
    '        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
    '        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
    '        Dim dao_overlap As New DAO_MAS.TB_OVERLAP_HEAD
    '        Dim dao_overlap_det As New DAO_MAS.TB_OVERLAP_DETAIL
    '        dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(item("BUDGET_DISBURSE_BILL_ID").Text))
    '        dao_detail.Getdata_by_Disburse_id(CInt(item("BUDGET_DISBURSE_BILL_ID").Text))
    '        dao_overlap.fields.AMOUNT = dao_detail.fields.AMOUNT
    '        dao_overlap.fields.BILL_AND_DEBTOR_ID = CInt(item("BUDGET_DISBURSE_BILL_ID").Text)
    '        dao_overlap.fields.BUDGET_PLAN_ID = dao_head.fields.BUDGET_PLAN_ID
    '        dao_overlap.fields.BUDGET_YEAR = dao_head.fields.BUDGET_YEAR
    '        dao_overlap.fields.DEPARTMENT_ID = dao_head.fields.DEPARTMENT_ID
    '        dao_overlap.fields.DESCRIPTION = dao_head.fields.DESCRIPTION
    '        dao_overlap.fields.DOC_DATE = dao_head.fields.DOC_DATE
    '        dao_overlap.fields.DOC_NUMBER = dao_head.fields.DOC_NUMBER
    '        dao_overlap.fields.DOC_RECIEVE_DATE = dao_head.fields.Bill_RECIEVE_DATE
    '        dao_overlap.fields.IS_OVERLAP_EXPAND = False
    '        dao_overlap.fields.PATLIST_ID = dao_head.fields.PATLIST_ID
    '        dao_overlap.fields.SUB_ACTIVITY_ID = 0
    '        dao_overlap.fields.OVERLAP_TYPE_ID = 2

    '        dao_overlap.insert()
    '        Dim id_head As Integer
    '        id_head = dao_overlap.fields.OVERLAP_HEAD_ID
    '        dao_overlap_det.fields.OVERLAP_HEAD_ID = id_head
    '        dao_overlap_det.fields.OVERLAP_DETAIL_AMOUNT = dao_detail.fields.AMOUNT

    '        dao_overlap_det.insert()

    '    Next
    'End Sub
    Public Sub insert()
        For Each item As GridDataItem In rgAddOverlapBill.SelectedItems

        Next
    End Sub
End Class