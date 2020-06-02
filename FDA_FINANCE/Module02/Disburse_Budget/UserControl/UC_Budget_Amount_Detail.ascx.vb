Public Class UC_Budget_Amount_Detail
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

    Private _ProId As String
    Public Property ProId() As String
        Get
            Return _ProId
        End Get
        Set(ByVal value As String)
            _ProId = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'getData_detail(BudgetplanId, dept, Budgetyear)

    End Sub

    Public Sub getData_detail(ByVal bg_id As Integer, ByVal dept_id As Integer, ByVal bgyear As Integer)
        Dim uti_adjust As New Utility_other()
        Dim bao As New BAO_BUDGET.Budget
        Dim bao_debt_app As New BAO_BUDGET.Budget
        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, bgyear)
        'Dim disburse_before_app As Double = uti_adjust.getAdjust_Appr_Amount(bg_id, dept_id, bgyear, "False")
        ' get_Amount_before_App
        Dim bao_dis_before_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_transfer_out As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_transfer_diff As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_po_before_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_po_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_dis_po_before_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_dis_po_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_debt_return_receipt As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_debt_return_cash As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_app As New BAO_BUDGET.DISBURSE_BUDGET

        'Dim disburse_before_app As Double = bao_dis_before_app.get_Amount_before_App(bg_id, bgyear)
        Dim transfer_out_amount As Double = bao_transfer_out.get_transfer_outside_amount(bg_id, bgyear)
        Dim transfer_diff As Double = bao_transfer_diff.get_transfer_diff(bg_id)

        'Dim debtor_before_app As Double = bao_debt_app.get_Adjust_debt_before_App_Amount(bg_id, bgyear, dept_id)
        '' Dim disburse_app As Double = uti_adjust.getAdjust_Appr_Amount(bg_id, dept_id, bgyear, "True")
        'Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App(bg_id, bgyear)
        'Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(bg_id, bgyear, dept_id)

        'Dim PO_before_App_Amount As Double = bao_po_before_app.get_PO_before_App_Amount(bg_id, bgyear, dept_id)
        'Dim po_app_amount As Double = bao_po_app.get_PO_App_Amount(bg_id, bgyear, dept_id)
        'Dim po_dis_before_app As Double = bao_dis_po_before_app.get_disburse_PO_before_App_Amount(bg_id, bgyear, dept_id)
        'Dim po_dis_app As Double = bao_dis_po_before_app.get_disburse_PO_App_Amount(bg_id, bgyear, dept_id)
        'Dim debt_return_money_receipt As Double = bao_debt_return_receipt.get_debt_return_money_receipt_app(bg_id, bgyear)
        'Dim debt_return_money_cash As Double = bao_debt_return_cash.get_debt_return_money_cash(bg_id, bgyear)


        txt_Amount.Text = adjust_amount.ToString("N")
        'txt_disburse_before_app.Text = (((disburse_before_app + po_dis_before_app + debt_return_money_receipt) + (debtor_before_app - debt_return_money_receipt - debt_return_money_cash) + (PO_before_App_Amount - po_dis_before_app))).ToString("N")
        txt_disburse_before_app.Text = bao_no_app.get_disburse_no_approve_amount(bg_id, bgyear).ToString("N")
        txt_transfer_out.Text = transfer_out_amount.ToString("N")
        txt_transfer_diff.Text = transfer_diff.ToString("N")
        'txt_disburse_app.Text = (((disburse_app + po_dis_app + debt_return_money_receipt) + (debtor_app - debt_return_money_receipt - debt_return_money_cash) + (po_app_amount - po_dis_app))).ToString("N")
        txt_disburse_app.Text = bao_app.get_disburse_approve_amount(bg_id, bgyear).ToString("N")
        txt_balance_before_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_no_app.get_disburse_no_approve_amount(bg_id, bgyear)).ToString("N")
        txt_balance_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_app.get_disburse_approve_amount(bg_id, bgyear)).ToString("N")

        If CDec(txt_balance_before_app.Text) <= 0 Then
            txt_balance_before_app.Style.Add("color", "red")
        Else
            txt_balance_before_app.Style.Add("color", "black")
        End If
        If CDec(txt_balance_app.Text) <= 0 Then
            txt_balance_app.Style.Add("color", "red")
        Else
            txt_balance_app.Style.Add("color", "black")
        End If

        ' txt_balance_before_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - ((disburse_before_app + po_dis_before_app + debt_return_money_receipt) + (debtor_before_app - debt_return_money_receipt - debt_return_money_cash) + (PO_before_App_Amount - po_dis_before_app))).ToString("N")
        'txt_balance_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - ((disburse_app + po_dis_app + debt_return_money_receipt) + (debtor_app - debt_return_money_receipt - debt_return_money_cash) + (po_app_amount - po_dis_app))).ToString("N")

    End Sub
    Public Sub gethead_detail(ByVal bg_id As Integer, ByVal dept_id As Integer, ByVal bgyear As Integer)
        Dim uti_adjust As New Utility_other()
        Dim bao As New BAO_BUDGET.Budget
        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, bgyear)
        Dim disburse_before_app As Double = uti_adjust.getAdjust_Appr_Amount(bg_id, dept, bgyear, "False")
        Dim disburse_app As Double = uti_adjust.getAdjust_Appr_Amount(bg_id, dept, bgyear, "True")
        txt_Amount.Text = adjust_amount.ToString("N")
        txt_disburse_before_app.Text = disburse_before_app.ToString("N")
        txt_disburse_app.Text = disburse_app.ToString("N")
        txt_balance_before_app.Text = (adjust_amount - disburse_before_app).ToString("N")
        txt_balance_app.Text = (adjust_amount - disburse_app).ToString("N")

    End Sub

    Public Sub get_all_bg_amount(ByVal bgyear As Integer)
        Dim uti_adjust As New Utility_other()
        Dim bao_adjust As New BAO_BUDGET.MASS
        Dim bao As New BAO_BUDGET.Budget
        Dim bao_bill_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim bao_debt_app As New BAO_BUDGET.DISBURSE_BUDGET

        Dim adjust_amount As Double = bao_adjust.get_bg_adjust_amount_all(bgyear)
        Dim disburse_before_app As Double = bao_bill_app.get_Adjust_App_Amount_All(bgyear, "False")
        Dim debtor_before_app As Double = bao_debt_app.get_Adjust_debt_App_Amount_All(bgyear, "False")
        Dim disburse_app As Double = bao_bill_app.get_Adjust_App_Amount_All(bgyear, "True")
        Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount_All(bgyear, "True")
        txt_Amount.Text = adjust_amount.ToString("N")
        txt_disburse_before_app.Text = disburse_before_app.ToString("N")
        'txt_debt_before_app.Text = debtor_before_app.ToString("N")
        txt_disburse_app.Text = disburse_app.ToString("N")
        'txt_debt_after_app.Text = debtor_app.ToString("N")
        txt_balance_before_app.Text = (adjust_amount - (disburse_before_app + debtor_before_app + disburse_app + debtor_app)).ToString("N")
        txt_balance_app.Text = (adjust_amount - (disburse_app + debtor_app)).ToString("N")
    End Sub

    Public Sub getData_detail_sup(ByVal bg_id As Integer, ByVal dept_id As Integer, ByVal bgyear As Integer)

        Dim bao2 As New BAO_BUDGET.MASS
        Dim bool2 As Boolean = bao2.get_support_dept_type(bg_id)
        If bool2 = True Then
            Dim uti_adjust As New Utility_other()
            Dim bao As New BAO_BUDGET.Budget
            Dim bao_debt_app As New BAO_BUDGET.Budget
            Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, bgyear)
            Dim bao_dis_before_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_transfer_out As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_transfer_diff As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_po_before_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_po_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_dis_po_before_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_dis_po_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_debt_return_receipt As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_debt_return_cash As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_app As New BAO_BUDGET.DISBURSE_BUDGET


            Dim disburse_before_app As Double = bao_dis_before_app.get_Amount_before_App_sup(bg_id, bgyear)
            Dim transfer_out_amount As Double = bao_transfer_out.get_transfer_outside_amount(bg_id, bgyear)
            Dim transfer_diff As Double = bao_transfer_diff.get_transfer_diff(bg_id)

            Dim debtor_before_app As Double = bao_debt_app.get_Adjust_debt_before_App_Amount_sup(bg_id, bgyear, dept_id)
            Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App_sup(bg_id, bgyear)
            Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount_sup(bg_id, bgyear, dept_id)

            Dim PO_before_App_Amount As Double = bao_po_before_app.get_PO_before_App_Amount_sup(bg_id, bgyear, dept_id)
            Dim po_app_amount As Double = bao_po_app.get_PO_App_Amount_sup(bg_id, bgyear, dept_id)
            Dim po_dis_before_app As Double = bao_dis_po_before_app.get_disburse_PO_before_App_Amount_sup(bg_id, bgyear, dept_id)
            Dim po_dis_app As Double = bao_dis_po_before_app.get_disburse_PO_App_Amount_sup(bg_id, bgyear, dept_id)
            Dim debt_return_money_receipt As Double = bao_debt_return_receipt.get_debt_return_money_receipt_app_sup(bg_id, bgyear)
            Dim debt_return_money_cash As Double = bao_debt_return_cash.get_debt_return_money_cash_sup(bg_id, bgyear)


            'txt_Amount.Text = adjust_amount.ToString("N")
            'txt_disburse_before_app.Text = (((disburse_before_app + po_dis_before_app + debt_return_money_receipt) + (debtor_before_app - debt_return_money_receipt - debt_return_money_cash) + (PO_before_App_Amount - po_dis_before_app))).ToString("N")
            'txt_transfer_out.Text = transfer_out_amount.ToString("N")
            'txt_transfer_diff.Text = transfer_diff.ToString("N")
            'txt_disburse_app.Text = (((disburse_app + po_dis_app + debt_return_money_receipt) + (debtor_app - debt_return_money_receipt - debt_return_money_cash) + (po_app_amount - po_dis_app))).ToString("N")
            'txt_balance_before_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - ((disburse_before_app + po_dis_before_app + debt_return_money_receipt) + (debtor_before_app - debt_return_money_receipt - debt_return_money_cash) + (PO_before_App_Amount - po_dis_before_app))).ToString("N")
            'txt_balance_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - ((disburse_app + po_dis_app + debt_return_money_receipt) + (debtor_app - debt_return_money_receipt - debt_return_money_cash) + (po_app_amount - po_dis_app))).ToString("N")


            txt_Amount.Text = adjust_amount.ToString("N")
            txt_disburse_before_app.Text = bao_no_app.get_disburse_support_no_approve_amount(bg_id, bgyear).ToString("N")
            txt_transfer_out.Text = transfer_out_amount.ToString("N")
            txt_transfer_diff.Text = transfer_diff.ToString("N")
            txt_disburse_app.Text = bao_app.get_disburse_support_approve_amount(bg_id, bgyear).ToString("N")
            txt_balance_before_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_no_app.get_disburse_support_no_approve_amount(bg_id, bgyear)).ToString("N")
            txt_balance_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_app.get_disburse_support_approve_amount(bg_id, bgyear)).ToString("N")

        Else
            Dim bao_ad As New BAO_BUDGET.MASS
            bg_id = bao_ad.get_bg_head_id(bg_id)

            Dim uti_adjust As New Utility_other()
            Dim bao As New BAO_BUDGET.Budget
            Dim bao_debt_app As New BAO_BUDGET.Budget
            Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, bgyear)
            'Dim disburse_before_app As Double = uti_adjust.getAdjust_Appr_Amount(bg_id, dept_id, bgyear, "False")
            ' get_Amount_before_App
            Dim bao_dis_before_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_transfer_out As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_transfer_diff As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_po_before_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_po_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_dis_po_before_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_dis_po_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_debt_return_receipt As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_debt_return_cash As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
            Dim bao_app As New BAO_BUDGET.DISBURSE_BUDGET

            'Dim disburse_before_app As Double = bao_dis_before_app.get_Amount_before_App(bg_id, bgyear)
            Dim transfer_out_amount As Double = bao_transfer_out.get_transfer_outside_amount(bg_id, bgyear)
            Dim transfer_diff As Double = bao_transfer_diff.get_transfer_diff(bg_id)

            'Dim debtor_before_app As Double = bao_debt_app.get_Adjust_debt_before_App_Amount(bg_id, bgyear, dept_id)
            '' Dim disburse_app As Double = uti_adjust.getAdjust_Appr_Amount(bg_id, dept_id, bgyear, "True")
            'Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App(bg_id, bgyear)
            'Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(bg_id, bgyear, dept_id)

            'Dim PO_before_App_Amount As Double = bao_po_before_app.get_PO_before_App_Amount(bg_id, bgyear, dept_id)
            'Dim po_app_amount As Double = bao_po_app.get_PO_App_Amount(bg_id, bgyear, dept_id)
            'Dim po_dis_before_app As Double = bao_dis_po_before_app.get_disburse_PO_before_App_Amount(bg_id, bgyear, dept_id)
            'Dim po_dis_app As Double = bao_dis_po_before_app.get_disburse_PO_App_Amount(bg_id, bgyear, dept_id)
            'Dim debt_return_money_receipt As Double = bao_debt_return_receipt.get_debt_return_money_receipt_app(bg_id, bgyear)
            'Dim debt_return_money_cash As Double = bao_debt_return_cash.get_debt_return_money_cash(bg_id, bgyear)


            txt_Amount.Text = adjust_amount.ToString("N")
            'txt_disburse_before_app.Text = (((disburse_before_app + po_dis_before_app + debt_return_money_receipt) + (debtor_before_app - debt_return_money_receipt - debt_return_money_cash) + (PO_before_App_Amount - po_dis_before_app))).ToString("N")
            txt_disburse_before_app.Text = bao_no_app.get_disburse_no_approve_amount(bg_id, bgyear).ToString("N")
            txt_transfer_out.Text = transfer_out_amount.ToString("N")
            txt_transfer_diff.Text = transfer_diff.ToString("N")
            'txt_disburse_app.Text = (((disburse_app + po_dis_app + debt_return_money_receipt) + (debtor_app - debt_return_money_receipt - debt_return_money_cash) + (po_app_amount - po_dis_app))).ToString("N")
            txt_disburse_app.Text = bao_app.get_disburse_approve_amount(bg_id, bgyear).ToString("N")
            txt_balance_before_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_no_app.get_disburse_no_approve_amount(bg_id, bgyear)).ToString("N")
            txt_balance_app.Text = ((adjust_amount + transfer_out_amount + transfer_diff) - bao_app.get_disburse_approve_amount(bg_id, bgyear)).ToString("N")


        End If

       

        If CDec(txt_balance_before_app.Text) <= 0 Then
            txt_balance_before_app.Style.Add("color", "red")
        Else
            txt_balance_before_app.Style.Add("color", "black")
        End If
        If CDec(txt_balance_app.Text) <= 0 Then
            txt_balance_app.Style.Add("color", "red")
        Else
            txt_balance_app.Style.Add("color", "black")
        End If




        'get_disburse_support_no_approve_amount  get_disburse_support_approve_amount
    End Sub


End Class