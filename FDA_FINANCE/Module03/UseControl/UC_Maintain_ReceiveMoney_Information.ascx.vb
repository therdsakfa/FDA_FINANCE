Public Class UC_Maintain_ReceiveMoney_Information
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
        Dim bao As New BAO_CALCULATE_BUDGET.CALCULATE_MAINTAIN_SQL
        lbl_ShowMoneyReceiveAll.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR(BudgetYear)).ToString("N")
        lbl_ShowMoneyReceiveCash.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 1)).ToString("N")
        lbl_ShowMoneyReceiveCheck.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 2)).ToString("N")
        lbl_ShowMoneyReceiveTransfer.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 3)).ToString("N")
        lbl_ShowMoneyReceiveCancel.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 4)).ToString("N")
    End Sub

End Class