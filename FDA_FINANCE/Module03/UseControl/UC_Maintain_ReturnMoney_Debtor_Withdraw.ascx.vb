Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Withdraw
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

    Private Sub rgDebtor_Withdraw_Init(sender As Object, e As EventArgs) Handles rgDebtor_Withdraw.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor_Withdraw
        Rad_Utility.addColumnCheckbox_client("chkColumn", "chkColumn")
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่หนังสือ")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียด", width:=250)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินคืน", is_money:=True)
        Rad_Utility.addColumnDate("MONEY_RETURN_DATE", "วันที่คืนเงิน")
        Rad_Utility.addColumnDate("WITHDRAW_DATE", "วันที่เบิกเพิ่ม")
    End Sub
    Public Sub update(ByVal strDate As String)
        If strDate <> "" Then
            For Each item As GridDataItem In rgDebtor_Withdraw.SelectedItems
                Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                dao.fields.WITHDRAW_DATE = CDate(strDate)
                dao.update()
            Next
        End If

    End Sub

    Public Sub rg_rebind()
        rgDebtor_Withdraw.Rebind()
    End Sub

    Private Sub rgDebtor_Withdraw_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgDebtor_Withdraw.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_return_money_withdraw(bgyear)

        rgDebtor_Withdraw.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDebtor_Withdraw, str)
    End Sub
End Class