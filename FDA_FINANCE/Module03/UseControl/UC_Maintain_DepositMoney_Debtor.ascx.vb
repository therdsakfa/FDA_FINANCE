Imports Telerik.Web.UI
Public Class UC_Maintain_DepositMoney_Debtor
    Inherits System.Web.UI.UserControl
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDepositMoney_Init(sender As Object, e As EventArgs) Handles rgDepositMoney.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDepositMoney
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "DOC_NUMBER", False)
        Rad_Utility.addColumnBound("BILL_NUMBER", "BILL_NUMBER", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DISBURSE_VOLUME", "บร เล่มที่")
        Rad_Utility.addColumnBound("DISBURSE_NUMBER", "บร เลขที่")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายการย่อยนำเงินเข้า")
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("I", "เพิ่มเลข GF", "I", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่")
    End Sub

    Private Sub rgDepositMoney_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgDepositMoney.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'If item("RECEIVE_MONEY_TYPE").Text = "1" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "เงินสด"
            'ElseIf item("RECEIVE_MONEY_TYPE").Text = "2" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "เช็ค"
            'ElseIf item("RECEIVE_MONEY_TYPE").Text = "3" Then
            '    item("RECEIVE_MONEY_TYPE").Text = "โอน"
            'End If

            Dim id As Integer = item("RETURN_MONEY_DEBTOR_ID").Text
            Dim h2 As LinkButton = DirectCast(item("I").Controls(0), LinkButton)
            Dim url As String = "Frm_Maintain_DepositMoney_Debtor_Insert.aspx?DEPOSIT_MONEY_ID=" & id
            h2.Attributes.Add("OnClick", "return insert_k('" & url & "');")

        End If
    End Sub

    Private Sub rgDepositMoney_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDepositMoney.NeedDataSource
        Dim bao_deposit As New BAO_BUDGET.Maintain
        rgDepositMoney.DataSource = bao_deposit.get_DEPOSIT_debtor(BudgetYear)
    End Sub
    Public Sub rebindRg()
        rgDepositMoney.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDepositMoney)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDepositMoney, str)
    End Sub
End Class