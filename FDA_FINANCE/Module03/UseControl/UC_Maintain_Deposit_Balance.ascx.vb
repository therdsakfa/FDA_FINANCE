Imports Telerik.Web.UI
Public Class UC_Maintain_Deposit_Balance
    Inherits System.Web.UI.UserControl
    Private _date_select As Date
    Public Property date_select() As Date
        Get
            Return _date_select
        End Get
        Set(ByVal value As Date)
            _date_select = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDepositBalance_Init(sender As Object, e As EventArgs) Handles rgDepositBalance.Init
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgDepositBalance
        Rad_Utility.addColumnBound("DEPOSIT_ID", "DEPOSIT_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("ACCOUNT_NUMBER", "เลขบัญชีเงินทดรอง")
        Rad_Utility.addColumnBound("ACCOUNT_BALANCE_AMOUNT", "เงินคงเหลือบัญชีเงินฝาก", is_money:=True)
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnBound("CHECK_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("INTEREST_AMOUNT", "ดอกเบี้ย", is_money:=True)
        Rad_Utility.addColumnIMG("D", "ลบ", "D", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgDepositBalance_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgDepositBalance.ItemCommand

        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "D" Then
                Dim dao As New DAO_MAINTAIN.TB_DEPOSIT_BALANCE
                dao.Getdata_by_ID(item("DEPOSIT_ID").Text)
                dao.delete()
                rgDepositBalance.Rebind()
            End If
        End If
    End Sub

    Private Sub rgDepositBalance_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgDepositBalance.NeedDataSource
        Try
            Dim bao As New BAO_BUDGET.Maintain
            Dim dt As DataTable = bao.get_deposit_balance(date_select)

            rgDepositBalance.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDepositBalance)
    End Sub
    Public Sub rebind_grid()
        rgDepositBalance.Rebind()
    End Sub
End Class