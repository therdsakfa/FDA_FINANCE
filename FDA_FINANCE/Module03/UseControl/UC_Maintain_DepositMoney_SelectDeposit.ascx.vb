Imports Telerik.Web.UI

Public Class UC_Maintain_DepositMoney_SelectDeposit
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
    Private _nodeID As String
    Public Property nodeID() As String
        Get
            Return _nodeID
        End Get
        Set(ByVal value As String)
            _nodeID = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDepositMoneySelectDeposit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgDepositMoneySelectDeposit.Init
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgDepositMoneySelectDeposit
        Rad_Utility.addColumnBound("RECEIVE_MONEY_ID", "RECEIVE_MONEY_ID", False)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_DETAIL_ID", "RECEIVE_MONEY_DETAIL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("RECEIPT_VOLUME", "บร เล่มที่")
        Rad_Utility.addColumnBound("RECEIPT_NUMBER", "บร เลขที่")
        Rad_Utility.addColumnBound("RECEIVE_MONEY_DESCRIPTION", "รายการย่อยนำเงินเข้า")
        Rad_Utility.addColumnBound("RECEIVE_MONEY_TYPE", "ประเภทเงินรับ")
        Rad_Utility.addColumnBound("RECEIVE_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("GF_NUMBER", "หมายเลข GF")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")

    End Sub

    Private Sub rgDepositMoneySelectDeposit_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgDepositMoneySelectDeposit.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "D" Then
                Dim dao_deposit_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL
                dao_deposit_money.Getdata_by_RECEIVE_MONEY_DETAIL_ID(item("RECEIVE_MONEY_DETAIL_ID").Text)
                dao_deposit_money.delete()
                Response.Redirect("Frm_Maintain_DepositMoney.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("Frm_Maintain_DepositMoney_Edit.aspx?DEPOSIT_MONEY_ID=" & item("RECEIVE_MONEY_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgDepositMoneySelectDeposit_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDepositMoneySelectDeposit.NeedDataSource
        Dim bao_deposit As New BAO_BUDGET.Maintain
        rgDepositMoneySelectDeposit.DataSource = bao_deposit.get_DEPOSIT_SelectDeposit(BudgetYear, nodeID)
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDepositMoneySelectDeposit)
    End Sub

    Private Sub rgDepositMoneySelectDeposit_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgDepositMoneySelectDeposit.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            If item("RECEIVE_MONEY_TYPE").Text = "1" Then
                item("RECEIVE_MONEY_TYPE").Text = "เงินสด"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "2" Then
                item("RECEIVE_MONEY_TYPE").Text = "เช็ค"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "3" Then
                item("RECEIVE_MONEY_TYPE").Text = "โอน"
            End If

            Dim id As Integer = item("RECEIVE_MONEY_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim url As String = "Frm_Maintain_DepositMoney_Edit.aspx?DEPOSIT_MONEY_ID=" & id
            h2.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")

        End If
    End Sub

    Public Sub rebindRg()
        rgDepositMoneySelectDeposit.Rebind()
    End Sub
End Class