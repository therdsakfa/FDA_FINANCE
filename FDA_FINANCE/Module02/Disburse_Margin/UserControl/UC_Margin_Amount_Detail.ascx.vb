Public Class UC_Margin_Amount_Detail
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
    Public Sub getMargin_detail(ByVal bgyear As Integer)
        Dim dao_margin As New DAO_DISBURSE.TB_MAS_MARGIN
        Dim uti_adjust As New Utility_other()
        Dim bao As New BAO_BUDGET.Budget
        dao_margin.Getdata_by_year(bgyear)

        Dim margin_amount As Double = 0
        If dao_margin.fields.BANK_AMOUNT <> 0 Then
            margin_amount = dao_margin.fields.BANK_AMOUNT + dao_margin.fields.CASH_AMOUNT
        End If
       
        txt_Amount.Text = margin_amount.ToString("N")
        'txt_disburse_before_app.Text = disburse_before_app
        'txt_disburse_app.Text = disburse_app
        'txt_balance_before_app.Text = adjust_amount - disburse_before_app
        'txt_balance_app.Text = adjust_amount - disburse_app

    End Sub
End Class