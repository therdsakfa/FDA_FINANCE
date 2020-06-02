Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgReceiptList
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")

        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียดใบสำคัญ")
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("A", "วางเบิกใบสำคัญ", "A", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่")
        Rad_Utility.addColumnIMG("K", "แก้ไขข้อมูล", "K", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่", img:=True, type_img:="insert")
    End Sub

    Private Sub rgReceiptList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgReceiptList.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    If e.CommandName = "K" Then

        '        Dim id As Integer = item("RETURN_MONEY_DEBTOR_ID").Text
        '        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
        '        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        '        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
        '        Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        '        dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(id)
        '        dao_debtor.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

        '        dao_head.fields.RETURN_MONEY_ID = id
        '        dao_head.fields.DESCRIPTION = "วางเบิก" & dao_return.fields.RETURN_DESCRIPTION
        '        dao_head.fields.BUDGET_PLAN_ID = dao_debtor.fields.BUDGET_PLAN_ID
        '        dao_head.fields.BUDGET_YEAR = dao_debtor.fields.BUDGET_YEAR
        '        dao_head.fields.DEPARTMENT_ID = dao_debtor.fields.DEPARTMENT_ID
        '        dao_head.fields.IS_PO = False
        '        dao_head.fields.PATLIST_ID = dao_debtor.fields.PAYLIST_ID
        '        'dao_head.fields.PAY_TYPE_ID = 

        '        dao_head.insert()

        '        dao_detail.fields.BUDGET_DISBURSE_BILL_ID = dao_head.fields.BUDGET_DISBURSE_BILL_ID
        '        dao_detail.fields.AMOUNT = dao_return.fields.RETURN_AMOUNT

        '        dao_detail.insert()

        '        rgReceiptList.Rebind()
        '    End If
        'End If

    End Sub
    Public Sub insert_bill(ByVal r_id As Integer)
        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(r_id)
        dao_debtor.Getdata_by_DEBTOR_BILL_ID(dao_return.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID)

        dao_head.fields.RETURN_MONEY_ID = r_id
        dao_head.fields.DESCRIPTION = "วางเบิก" & dao_return.fields.RETURN_DESCRIPTION
        dao_head.fields.BUDGET_PLAN_ID = dao_debtor.fields.BUDGET_PLAN_ID
        dao_head.fields.BUDGET_YEAR = dao_debtor.fields.BUDGET_YEAR
        dao_head.fields.DEPARTMENT_ID = dao_debtor.fields.DEPARTMENT_ID
        dao_head.fields.IS_PO = False
        dao_head.fields.PATLIST_ID = dao_debtor.fields.PAYLIST_ID
        'dao_head.fields.PAY_TYPE_ID = 

        dao_head.insert()

        dao_detail.fields.BUDGET_DISBURSE_BILL_ID = dao_head.fields.BUDGET_DISBURSE_BILL_ID
        dao_detail.fields.AMOUNT = dao_return.fields.RETURN_AMOUNT

        dao_detail.insert()
    End Sub


    Private Sub rgReceiptList_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgReceiptList.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.bk_list()

        rgReceiptList.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgReceiptList)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgReceiptList, str)
    End Sub
    Public Sub rebind_grid()
        rgReceiptList.Rebind()
    End Sub
End Class