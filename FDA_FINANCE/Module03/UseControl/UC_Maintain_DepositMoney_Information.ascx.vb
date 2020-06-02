Public Class UC_Maintain_Deposit_Money_Information
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
        Dim bao As New BAO_CALCULATE_BUDGET.CALCULATE_MAINTAIN_NonSQL
        lbl_CashHave.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 1)).ToString("N")
        lbl_CheckHave.Text = (bao.cal_RECEIVE_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 2)).ToString("N")
        lbl_CashDeposit.Text = (bao.cal_DEPOSIT_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 1)).ToString("N")
        lbl_CheckDeposit.Text = (bao.cal_DEPOSIT_AMOUNT_by_BUDGET_YEAR_and_RECEIVE_MONEY_TYPE(BudgetYear, 2)).ToString("N")
        lb_level1.Text = "-"
        lb_level2.Text = "-"
        lb_level3.Text = "-"
        lb_level4.Text = "-"
    End Sub
    Public Sub bindTxtbox()
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        dt.Columns.Add("seq")
        dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
        dt.Columns.Add("MONEY_AMOUNT")
        dt.Columns.Add("TYPE_ID")
        If nodeID = "" Then
            nodeID = 0
        End If
        dt = baobudget.getMoneyTypeNodeBack(dt, nodeID)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "seq desc"
        dt = dv.ToTable


        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                If IsDBNull(dt(i)("MONEY_TYPE_DESCRIPTION")) = False And IsDBNull(dt(i)("TYPE_ID")) = False Then
                    Select Case dt(i)("TYPE_ID")
                        Case "1"
                            lb_level1.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "2"
                            lb_level2.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "3"
                            lb_level3.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "4"
                            lb_level4.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    End Select

                End If

            Next
        End If
    End Sub
End Class