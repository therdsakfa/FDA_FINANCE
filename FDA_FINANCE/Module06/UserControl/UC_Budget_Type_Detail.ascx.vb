Public Class UC_Budget_Type_Detail
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
    Public Sub insert(ByRef dao As DAO_BUDGET.TB_MAS_BUDGET_TYPE)
        dao.fields.BUDGET_YEAR = BudgetYear
        dao.fields.BUDGET_TYPE_NAME = txt_BUDGET_TYPE_NAME.Text
        dao.fields.BUDGET_TYPE_AMOUNT = rnt_BUDGET_TYPE_AMOUNT.Value
    End Sub
    Public Sub getdata(ByRef dao As DAO_BUDGET.TB_MAS_BUDGET_TYPE)
        txt_BUDGET_TYPE_NAME.Text = dao.fields.BUDGET_TYPE_NAME
        rnt_BUDGET_TYPE_AMOUNT.Value = dao.fields.BUDGET_TYPE_AMOUNT
    End Sub
    Public Sub update(ByRef dao As DAO_BUDGET.TB_MAS_BUDGET_TYPE)

        dao.fields.BUDGET_TYPE_NAME = txt_BUDGET_TYPE_NAME.Text
        dao.fields.BUDGET_TYPE_AMOUNT = rnt_BUDGET_TYPE_AMOUNT.Value
    End Sub
End Class