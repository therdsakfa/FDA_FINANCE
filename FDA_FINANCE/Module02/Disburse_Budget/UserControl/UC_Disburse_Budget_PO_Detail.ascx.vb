Public Class UC_Disburse_Budget_PO_Detail
    Inherits System.Web.UI.UserControl
    Public bgYear As Integer
    'Public dept As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    If Request.QueryString("dept") <> "" Then

        '    End If

        'End If

        bgYear = 2557
        If Not IsPostBack Then
            txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
            txt_Bill_RECIEVE_DATE.Text = System.DateTime.Now.ToShortDateString()
            txt_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_Department()
            dd_dept.DataSource = dt
            dd_dept.DataBind()

            'Dim dao_customer As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
            'dao_customer.Getdata()
            'Dim dt_cus As DataTable = dao_customer.dt
            'dd_CUSTOMER_TYPE.DataSource = dt_cus
            'dd_CUSTOMER_TYPE.DataBind()

        End If
        'dept = dd_dept.SelectedValue


    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        dao.fields.USER_AD = NameUserAD()
        dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
        dao.fields.Bill_RECIEVE_DATE = CDate(txt_Bill_RECIEVE_DATE.Text)
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = 0
        dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        dao.fields.CUSTOMER_TYPE_ID = Nothing
        dao.fields.BUDGET_USE_ID = 1
        dao.fields.GFMIS_NUMBER = ""
        dao.fields.GFMIS_DATE = Nothing
        dao.fields.INVOICES_DATE = Nothing
        dao.fields.INVOICES_NUMBER = ""
        dao.fields.RECEIPT_NUMBER = ""
        dao.fields.RECEIPT_DATE = Nothing
        dao.fields.RETURN_APPROVE_DATE = Nothing
        dao.fields.RETURN_APPROVE_NUMBER = ""
        dao.fields.PAY_TYPE_ID = 4
        dao.fields.DEPARTMENT_ID = dd_dept.SelectedValue
        dao.fields.DEBTOR_ID = 0
        dao.fields.CHECK_APPROVE = False
        dao.fields.IS_CHECK_RECEIVE = False
        dao.fields.IS_PO = True
    End Sub
    Public Sub insert_detail(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL, ByVal id As Integer)

        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.TAX_AMOUNT = 0
        dao.fields.IS_ENABLE = True
        dao.fields.BUDGET_DISBURSE_BILL_ID = id
        dao.fields.APPROVE_AMOUNT = 0
    End Sub
    Private Sub dd_dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_dept.SelectedIndexChanged
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_dept.SelectedValue, bgYear)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & " - " & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()

        End If

    End Sub


End Class