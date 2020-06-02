Public Class UC_Overlap_Detail
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
    Private _bgid As Integer
    Public Property bdig() As Integer
        Get
            Return _bgid
        End Get
        Set(ByVal value As Integer)
            _bgid = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            rdp_OVERLAP_DATE.SelectedDate = System.DateTime.Now
            rdp_RECIEVE_DATE.SelectedDate = System.DateTime.Now
            rdp_DOC_DATE.SelectedDate = System.DateTime.Now
            Dim dao_paylist As New DAO_MAS.TB_MAS_PAYLIST
            Dim dao_customer As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
            Dim bao_adjust As New BAO_BUDGET.Budget
            dao_customer.Getdata()
            dao_paylist.Getdata()

            Dim dt As DataTable = dao_paylist.dt
            Dim dt_cus As DataTable = dao_customer.dt
            dd_Paylist.DataSource = dt
            dd_Paylist.DataBind()

            Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
            Dim dao_out As New DAO_MAS.TB_MAS_MONEY_TYPE
            If Request.QueryString("bgid") IsNot Nothing Then
                If Request.QueryString("bgid") <> "" And Request.QueryString("bgid") <> "0" Then
                    dao_bg.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
                    lb_Budget_Plan.Text = dao_bg.fields.BUDGET_DESCRIPTION

                End If

            End If

        End If
    End Sub

    Public Sub insert(ByRef dao As DAO_MAS.TB_OVERLAP_HEAD)
        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.BUDGET_PLAN_ID = Request.QueryString("bgid")
        dao.fields.BUDGET_YEAR = Request.QueryString("bgYear")
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.DOC_DATE = rdp_DOC_DATE.SelectedDate
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.DOC_RECIEVE_DATE = rdp_RECIEVE_DATE.SelectedDate
        dao.fields.IS_ENABLE = True
        dao.fields.IS_OVERLAP_EXPAND = False
        dao.fields.OVERLAP_APPROVE = False
        dao.fields.OVERLAP_DATE = rdp_OVERLAP_DATE.SelectedDate
        dao.fields.PATLIST_ID = dd_Paylist.SelectedValue
        dao.fields.SUB_ACTIVITY_ID = 0
        If Request.QueryString("oid") = "" Then
            dao.fields.OVERLAP_TYPE_ID = Request.QueryString("type")
        End If

    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_OVERLAP_HEAD)
        rnt_AMOUNT.Value = dao.fields.AMOUNT
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        rdp_DOC_DATE.SelectedDate = dao.fields.DOC_DATE
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        rdp_RECIEVE_DATE.SelectedDate = dao.fields.DOC_RECIEVE_DATE
        rdp_OVERLAP_DATE.SelectedDate = dao.fields.OVERLAP_DATE
    End Sub
End Class