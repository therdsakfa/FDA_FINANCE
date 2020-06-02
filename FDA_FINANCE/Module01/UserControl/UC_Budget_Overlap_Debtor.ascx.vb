Imports Telerik.Web.UI
Public Class UC_Budget_Overlap_Debtor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddOverlapDebtor_Init(sender As Object, e As EventArgs) Handles rgAddOverlapDebtor.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddOverlapDebtor
        Rad_Utility.addColumnCheckbox_client("chkColumn", "")
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", width:=120)
    End Sub

    Private Sub rgAddOverlapDebtor_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAddOverlapDebtor.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.get_Overlap_debtor()
        rgAddOverlapDebtor.DataSource = dt
    End Sub
    Public Sub insert()

        For Each item As GridDataItem In rgAddOverlapDebtor.SelectedItems
            Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            Dim dao_overlap As New DAO_MAS.TB_OVERLAP_HEAD
            dao_head.Getdata_by_DEBTOR_BILL_ID(CInt(item("DEBTOR_BILL_ID").Text))
            dao_detail.Getdata_by_DEBTOR_BILL_ID(CInt(item("DEBTOR_BILL_ID").Text))
            dao_overlap.fields.AMOUNT = dao_detail.fields.AMOUNT
            dao_overlap.fields.BILL_AND_DEBTOR_ID = CInt(item("DEBTOR_BILL_ID").Text)
            dao_overlap.fields.BUDGET_PLAN_ID = dao_head.fields.BUDGET_PLAN_ID
            dao_overlap.fields.BUDGET_YEAR = dao_head.fields.BUDGET_YEAR
            dao_overlap.fields.DEPARTMENT_ID = dao_head.fields.DEPARTMENT_ID
            dao_overlap.fields.DESCRIPTION = dao_head.fields.DESCRIPTION
            dao_overlap.fields.DOC_DATE = dao_head.fields.DOC_DATE
            dao_overlap.fields.DOC_NUMBER = dao_head.fields.DOC_NUMBER
            dao_overlap.fields.DOC_RECIEVE_DATE = dao_head.fields.Bill_RECIEVE_DATE
            dao_overlap.fields.IS_OVERLAP_EXPAND = False
            dao_overlap.fields.PATLIST_ID = dao_head.fields.PAYLIST_ID
            dao_overlap.fields.SUB_ACTIVITY_ID = 0
            dao_overlap.fields.OVERLAP_TYPE_ID = 3
            dao_overlap.insert()

        Next
    End Sub
End Class