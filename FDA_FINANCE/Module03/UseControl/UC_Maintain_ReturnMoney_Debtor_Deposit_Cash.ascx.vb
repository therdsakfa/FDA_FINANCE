Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Deposit_Cash
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtor_deposit_cash_Init(sender As Object, e As EventArgs) Handles rgDebtor_deposit_cash.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor_deposit_cash
        'Rad_Utility.addColumnCheckbox_client("chkColumn", "chkColumn")
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")
        Rad_Utility.addColumnBound("BILL_NUMBER", "BILL_NUMBER", False)
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียด", width:=250)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินคืน", is_money:=True)
        Rad_Utility.addColumnDate("MONEY_RETURN_DATE", "วันที่คืนเงิน")
        Rad_Utility.addColumnDate("DEPOSIT_DATE", "วันที่นำฝากเงิน")

    End Sub

    Private Sub rgDebtor_deposit_cash_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtor_deposit_cash.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable
        dt = bao.get_debtor_return_deposit_cash(bgyear)
        rgDebtor_deposit_cash.DataSource = dt
    End Sub
    Public Sub update(ByVal strDate As String)

        For Each item As GridDataItem In rgDebtor_deposit_cash.SelectedItems
            Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            dao.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
            If strDate <> "" Then
                dao.fields.DEPOSIT_DATE = CDate(strDate)
            Else
                dao.fields.DEPOSIT_DATE = Nothing
            End If
            dao.update()
        Next


    End Sub

    Public Sub rg_rebind()
        rgDebtor_deposit_cash.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDebtor_deposit_cash, str)
    End Sub
End Class