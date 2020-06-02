Imports Telerik.Web.UI

Public Class UC_Maintain_ReturnMony_OutsideBudget
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgReturnMoneyDebtorOutsideBudget_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgReturnMoneyOutsideBudget.Init
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgReturnMoneyOutsideBudget
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("PAY_TYPE", "ประเภทการจ่าย ")
        Rad_Utility.addColumnBound("FULLNAME", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnBound("DOC_DATE", "วันที่เอกสารส่งใช้หนี้ ")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสารส่งใช้หนี้ ")
        Rad_Utility.addColumnBound("DISBURSE_VOLUME", "บ. เล่มที่ ")
        Rad_Utility.addColumnBound("DISBURSE_NUMBER", "บ. เลขที่ ")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียดการคืน ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่ยืม ")
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินที่คืน ")
        'Rad_Utility.addColumnBound("RETURN_STATUS", "สถานะการคืนเงิน")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgReturnMoneyDebtorOutsideBudget_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgReturnMoneyOutsideBudget.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "D" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao_return_money.Getdata_by_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                dao_return_money.delete()
                Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_OutsideBudget.aspx")
            ElseIf e.CommandName = "E" Then
                Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Edit.aspx?DEBTOR_BILL_ID=" & item("RETURN_MONEY_DEBTOR_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgReturnMoneyDebtorOutsideBudget_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgReturnMoneyOutsideBudget.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim debtorbillID As String = Request.QueryString("DEBTOR_BILL_ID")
        Dim dt As DataTable = bao.get_RETURN_MONEY_DEBTOR_OUTSIDEBUDGET(debtorbillID)
        rgReturnMoneyOutsideBudget.DataSource = dt
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgReturnMoneyOutsideBudget)
    End Sub

    Private Sub rgReturnMoneyOutsideBudget_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgReturnMoneyOutsideBudget.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            If item("PAY_TYPE").Text = "1" Then
                item("PAY_TYPE").Text = "เงินสด"
            ElseIf item("PAY_TYPE").Text = "2" Then
                item("PAY_TYPE").Text = "เช็ค"
            End If
        End If
    End Sub
End Class