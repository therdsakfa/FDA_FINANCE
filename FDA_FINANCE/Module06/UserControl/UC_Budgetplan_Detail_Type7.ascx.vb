Public Class UC_Budgetplan_Detail_Type7
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Private _show As Boolean
    Public Property show() As Boolean
        Get
            Return _show
        End Get
        Set(ByVal value As Boolean)
            _show = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("typeid") IsNot Nothing Then
                lb_budget.Text = getBudgetTypeName(Request.QueryString("typeid"))
            End If
            bind_ddl7()
        End If
    End Sub
    Public Sub bind_ddl7()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_Type7

        dd_type_7.DataSource = dt
        dd_type_7.DataBind()
    End Sub
    Public Function getBudgetTypeName(digit As Integer) As String
        Dim strBudget As String = ""
        Select Case digit
            Case 1
                strBudget = "ชื่อหัวข้องบประมาณ : "
            Case 2
                strBudget = "ชื่อแผนงาน : "
            Case 3
                strBudget = "ชื่อผลผลิต : "
            Case 4
                strBudget = "ชื่อกิจกรรม : "
            Case 5
                strBudget = "ชื่อโครงการ : "
                lb_budget_code.Visible = True
                txt_budget_code.Visible = True
            Case 6
                strBudget = "ชื่อประเภทงบรายจ่าย : "
            Case 7
                strBudget = "ชื่องบรายจ่าย : "
                lb_budget_code.Visible = True
                txt_budget_code.Visible = True
            Case 8
                strBudget = "ชื่องบรายจ่ายย่อย : "
                lb_budget_code.Visible = True
                txt_budget_code.Visible = True
        End Select

        Return strBudget
    End Function
    Public Sub insert(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If
        dao.fields.BUDGET_DESCRIPTION = dd_type_7.Text
        dao.fields.BUDGET_AMOUNT = 0
        dao.fields.BUDGET_CHILD_ID = Request.QueryString("id")
        dao.fields.BUDGET_TYPE_ID = type_id
        dao.fields.BUDGET_YEAR = bgyear
        dao.fields.BUDGET_IS_SUPPORT_DEPT = False
        If txt_budget_code.Text <> "" Then
            dao.fields.BUDGET_CODE = txt_budget_code.Text
        Else
            dao.fields.BUDGET_CODE = Nothing
        End If
    End Sub
End Class