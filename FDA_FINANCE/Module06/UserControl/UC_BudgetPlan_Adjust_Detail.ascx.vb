Public Partial Class UC_BudgetPlan_Adjust_Insert
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If Request.QueryString("dept") <> "" Then
            '    Dim dao As New DAO_MAS.TB_MAS_DEPARTMENT
            '    dao.Getdata_by_DEPARTMENT_ID(CInt(Request.QueryString("dept")))
            '    'lb_Department.Text = dao.fields.DEPARTMENT_DESCRIPTION

            'End If
            'bind_ddl_dept()
            If Request.QueryString("bgid") <> "" And Request.QueryString("bgid") <> "0" Then
                Dim dao As New DAO_MAS.TB_BUDGET_PLAN
                Dim dao_proj As New DAO_MAS.TB_BUDGET_PLAN
                dao.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
                dao_proj.Getdata_by_BUDGET_PLAN_ID(dao.fields.BUDGET_CHILD_ID)
                lbBudget.Text = dao.fields.BUDGET_DESCRIPTION
                lb_Project.Text = dao_proj.fields.BUDGET_DESCRIPTION
            End If
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_BUDGET.TB_BUDGET_ADJUST)
        dao.fields.BUDGET_DEPARTMENT_MONEY = rnt_BUDGET_AMOUNT.Value
        dao.fields.BUDGET_PLAN_ID = CInt(Request.QueryString("bgid"))
        ' dao.fields.DEPARTMENT_ID = CInt(Request.QueryString("dept"))
        dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
    End Sub
    Public Sub getdata(ByRef dao As DAO_BUDGET.TB_BUDGET_ADJUST)
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        rnt_BUDGET_AMOUNT.Value = dao.fields.BUDGET_DEPARTMENT_MONEY
        dao_bg.Getdata_by_BUDGET_PLAN_ID(dao.fields.BUDGET_PLAN_ID)
        lbBudget.Text = dao_bg.fields.BUDGET_DESCRIPTION

        dd_Department.DropDownSelectData(dao.fields.DEPARTMENT_ID)
    End Sub
    Public Sub set_date()
        Dim str_date As String = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = str_date
        txt_EXPORT_DATE.Text = str_date
    End Sub
    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    Public Sub insert_period(ByRef dao As DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL)
        If txt_EXPORT_DATE.Text <> "" Then
            dao.fields.ACTIVE_DATE = CDate(txt_EXPORT_DATE.Text)
            dao.fields.EXPORT_DATE = CDate(txt_EXPORT_DATE.Text)
        Else
            dao.fields.ACTIVE_DATE = Nothing
        End If
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        Else
            dao.fields.DOC_DATE = Nothing
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
    End Sub

    Public Sub getdata_period(ByRef dao As DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL)
        If dao.fields.ACTIVE_DATE IsNot Nothing Then
            txt_EXPORT_DATE.Text = CDate(dao.fields.ACTIVE_DATE).ToShortDateString()
        End If
        If dao.fields.DESCRIPTION IsNot Nothing Then
            txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        End If
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString()
        End If
        If dao.fields.DOC_NUMBER IsNot Nothing Then
            txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        End If
    End Sub
End Class