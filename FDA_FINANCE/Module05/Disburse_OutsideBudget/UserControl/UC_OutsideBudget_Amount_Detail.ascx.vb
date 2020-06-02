Public Class UC_OutsideBudget_Amount_Detail
    Inherits System.Web.UI.UserControl
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property
    Private _BudgetplanId As Integer
    Public Property BudgetplanId() As Integer
        Get
            Return _BudgetplanId
        End Get
        Set(ByVal value As Integer)
            _BudgetplanId = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub getBGOutside_detail(ByVal bg_id As Integer, ByVal bgyear As Integer)
        Dim uti_adjust As New Utility_other()
        Dim bao_old_balancec As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_receive As New BAO_BUDGET.DISBURSE_BUDGET

        Dim old_balance As Double = 0
        Dim dis_no_app As Double = 0
        Dim dis_app As Double = 0
        Dim receive As Double = 0

        old_balance = bao_old_balancec.get_old_balance_no_app(bg_id, bgyear)
        dis_no_app = bao_no_app.get_dis_outbudget_no_app(bg_id, bgyear)
        dis_app = bao_app.get_dis_outbudget_app(bg_id, bgyear)
        receive = bao_app.get_receive_all(bg_id, bgyear)


        txt_receive.Text = receive.ToString("N")
        txt_Amount.Text = old_balance.ToString("N")
        txt_disburse_before_app.Text = dis_no_app.ToString("N")
        txt_balance_before_app.Text = ((old_balance + receive) - Math.Abs(dis_no_app)).ToString("N")
        txt_disburse_app.Text = dis_app.ToString("N")
        txt_balance_app.Text = ((old_balance + receive) - Math.Abs(dis_app)).ToString("N")
        'Dim bao_before_app As New BAO_BUDGET.Budget
        'Dim bao_app As New BAO_BUDGET.Budget
        'Dim dao_money_type As New DAO_MAS.TB_MAS_MONEY_TYPE
        'dao_money_type.Getdata_by_bgyear(bg_id, bgyear)
        'Dim dao_receive_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'Dim bao_debtor_before_app As New BAO_BUDGET.Budget
        'Dim bao_debtor_app As New BAO_BUDGET.Budget
        'Dim bao_debtor_receipt As New BAO_BUDGET.Budget
        'Dim bao_debtor_cash As New BAO_BUDGET.Budget

        'Dim money_type_Amount As Double = 0
        'Try
        '    If dao_money_type.fields.MONEY_AMOUNT IsNot Nothing Then
        '        money_type_Amount = dao_receive_money.Getdata_by_id_bgyear(bg_id, bgyear)
        '    End If
        'Catch ex As Exception

        'End Try


        'Dim disburse_before_app As Double = bao_before_app.getBeforeApproveOutsideAmount(bg_id, bgyear)
        'Dim disburse_app As Double = bao_app.getApproveOutsideAmount(bg_id, bgyear)
        'Dim debtor_brfore_app As Double = bao_debtor_before_app.get_outdebt_before_app(bg_id, bgyear)
        'Dim debtor_app As Double = bao_debtor_app.get_outdebt_app(bg_id, bgyear)
        'Dim debtor_receipt As Double = bao_debtor_receipt.get_Outdebt_return_money_receipt(bg_id, bgyear)
        'Dim debtor_cash As Double = bao_debtor_cash.get_Outdebt_return_money_cash(bg_id, bgyear)

        'txt_Amount.Text = money_type_Amount.ToString("N")
        'txt_disburse_before_app.Text = (disburse_before_app + debtor_brfore_app).ToString("N")
        'txt_disburse_app.Text = (disburse_app + debtor_app).ToString("N")
        'txt_balance_before_app.Text = (money_type_Amount - (disburse_before_app + debtor_brfore_app - debtor_receipt - debtor_cash)).ToString("N")
        'txt_balance_app.Text = (money_type_Amount - (disburse_app + (debtor_app - debtor_receipt - debtor_cash))).ToString("N")



    End Sub
    Public Sub getBGOutside_detail_benefit(ByVal bg_id As Integer, ByVal _year As Integer)
        Dim uti_adjust As New Utility_other()
        Dim bao_old_balancec As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_receive As New BAO_BUDGET.DISBURSE_BUDGET

        Dim old_balance As Double = 0
        Dim dis_no_app As Double = 0
        Dim dis_app As Double = 0
        Dim receive As Double = 0

        old_balance = bao_old_balancec.get_old_balance_no_app_year(bg_id, _year)
        dis_no_app = bao_no_app.get_dis_outbudget_no_app_year(bg_id, _year)
        dis_app = bao_app.get_dis_outbudget_app_year(bg_id, _year)
        receive = bao_app.get_receive_all_year(bg_id, _year)


        txt_receive.Text = receive.ToString("N")
        txt_Amount.Text = old_balance.ToString("N")
        txt_disburse_before_app.Text = dis_no_app.ToString("N")
        txt_balance_before_app.Text = ((old_balance + receive) - Math.Abs(dis_no_app)).ToString("N")
        txt_disburse_app.Text = dis_app.ToString("N")
        txt_balance_app.Text = ((old_balance + receive) - Math.Abs(dis_app)).ToString("N")

    End Sub
End Class