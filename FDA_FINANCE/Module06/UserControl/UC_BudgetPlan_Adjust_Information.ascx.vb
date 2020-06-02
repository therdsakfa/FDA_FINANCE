Public Class UC_BudgetPlan_Adjust_Information
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub BindData(ByVal bg As Integer)
        Dim dao_bg_type As New DAO_BUDGET.TB_MAS_BUDGET_TYPE
        Dim dao_bg_plan As New DAO_MAS.TB_BUDGET_PLAN
        'Dim bao_adjust As New BAO_BUDGET.Budget
        Dim bao_bg_use As New BAO_BUDGET.MASS
        dao_bg_plan.Getdata_by_BUDGET_PLAN_ID(bg)
        Dim main_type As Integer = 0
        Dim bg_amount As Double = 0
        If dao_bg_plan.fields.BUDGET_MAIN_TYPE IsNot Nothing Or dao_bg_plan.fields.BUDGET_MAIN_TYPE <> 0 Then
            main_type = dao_bg_plan.fields.BUDGET_MAIN_TYPE
            dao_bg_type.Getdata_by_BUDGET_TYPE_ID(main_type)
            'If dao_bg_type.fields.BUDGET_TYPE_AMOUNT IsNot Nothing Or dao_bg_type.fields.BUDGET_TYPE_AMOUNT <> "" Then
            '    bg_amount = dao_bg_type.fields.BUDGET_TYPE_AMOUNT
            'End If

        End If

        Dim adjust_amount As Double
        adjust_amount = bao_bg_use.get_Budget_use_Amount(bg)

        'lb_BudgetAmount.Text = bg_amount.ToString("N")
        lb_AdjustAmount.Text = adjust_amount.ToString("N")
        ' lb_BG_Balance.Text = (bg_amount - adjust_amount).ToString("N")
    End Sub
End Class