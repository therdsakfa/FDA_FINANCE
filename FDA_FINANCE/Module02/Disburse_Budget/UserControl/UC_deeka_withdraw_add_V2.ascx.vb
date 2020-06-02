Imports System.Web.UI
Imports Telerik.Web.UI

Public Class UC_deeka_withdraw_add_V2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        'dd_BudgetYear.DataSource = bao.get_BudgetYear()
        'dd_BudgetYear.DataBind()

    End Sub
    Public Sub bind_ddl_BudgetYear()
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.get_BudgetYear()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
    End Sub
    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_gl.get_GL()

        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub
    Public Sub bind_dd_name()
        Dim bao_cus As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_cus.get_customer()

        dd_cus.DataSource = dt
        dd_cus.DataBind()
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_Deeka_Withdraw)
        If deeka_date.Text <> "" Then
            dao.fields.Date_deka = CDate(deeka_date.Text)
        Else
            dao.fields.Date_deka = Nothing
        End If
        dao.fields.NameCUS = dd_cus.SelectedValue
        dao.fields.Description = txt_description.Text
        dao.fields.Type_Money = list_money.SelectedValue
        dao.fields.Month = dd_month.SelectedValue
        dao.fields.Budget_Year = dd_BudgetYear.SelectedValue
        dao.fields.GL = ddl_GL.SelectedValue
        dao.fields.Amount = rnt_amount.Value
        dao.fields.Tax = rnt_amount.Value

    End Sub
    Public Sub update(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        'dao.fields.NAME = ddl_Name.SelectedValue
        'dao.fields.AMOUNT = rnt_Amount.Value

    End Sub
    'Public Sub getdata(ByRef dao As DAO_BUDGET.TB_MasterBill_Area)
    '    ddl_Name.DropDownSelectData(dao.fields.Company)
    '    rnt_Amount.Value = dao.fields.SumAmount

    '    lb_amoutMax.Text = dao.fields.SumAmount
    'End Sub


End Class