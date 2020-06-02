Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Deposit_Receipt
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtor_deposit_Init(sender As Object, e As EventArgs) Handles rgDebtor_deposit.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor_deposit
        Rad_Utility.addColumnCheckbox_client("chkColumn", "chkColumn")
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")
        Rad_Utility.addColumnBound("BILL_NUMBER", "BILL_NUMBER", False)
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียด", width:=250)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินคืน", is_money:=True)
        Rad_Utility.addColumnDate("MONEY_RETURN_DATE", "วันที่คืนเงิน")
        Rad_Utility.addColumnDate("DEPOSIT_DATE", "วันที่นำฝากเงิน")
    End Sub

    Private Sub rgDebtor_deposit_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtor_deposit.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable
        dt = bao.get_debtor_return_deposit()
        rgDebtor_deposit.DataSource = dt
    End Sub
    Public Sub update(ByVal strDate As String)
        If strDate <> "" Then
            For Each item As GridDataItem In rgDebtor_deposit.SelectedItems
                Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                dao.fields.DEPOSIT_DATE = CDate(strDate)
                dao.update()
            Next
        End If

    End Sub

    Public Sub rg_rebind()
        rgDebtor_deposit.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDebtor_deposit, str)
    End Sub
End Class