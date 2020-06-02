Partial Public Class UC_Budgetplan_Detail
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
    Private _ddl As Integer
    Public Property ddl() As Integer
        Get
            Return _ddl
        End Get
        Set(ByVal value As Integer)
            _ddl = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("typeid") IsNot Nothing Then
                lb_budget.Text = getBudgetTypeName(Request.QueryString("typeid"))
            End If
            'Dim bao As New BAO_BUDGET.Budget
            'Dim dt As DataTable = bao.getBudgetTypeData(bgyear)
            'dd_BUDGET_TYPE.DataSource = dt
            'dd_BUDGET_TYPE.DataBind()

            If Request.QueryString("typeid") = 6 Then
                txt_BUDGET_DESCRIPTION.Style.Add("display", "none")
                dd_type_6.Style.Add("display", "block")
            Else
                txt_BUDGET_DESCRIPTION.Style.Add("display", "block")
                dd_type_6.Style.Add("display", "none")
            End If
        End If
       
      
    End Sub
    Public Sub insert_headBG(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If
        If type_id = 6 Then
            dao.fields.BUDGET_MAIN_TYPE = 1
            dao.fields.BUDGET_DESCRIPTION = dd_type_6.Text
        Else
            dao.fields.BUDGET_MAIN_TYPE = 0
            dao.fields.BUDGET_DESCRIPTION = txt_BUDGET_DESCRIPTION.Text
        End If
        'dao.fields.BUDGET_DESCRIPTION = txt_BUDGET_DESCRIPTION.Text
        dao.fields.BUDGET_AMOUNT = 0
        dao.fields.BUDGET_CHILD_ID = 0
        dao.fields.BUDGET_TYPE_ID = type_id
        dao.fields.BUDGET_YEAR = bgyear
        dao.fields.BUDGET_IS_SUPPORT_DEPT = False
        '      dao.fields.BUDGET_CODE = 
    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If

        If type_id = 6 Then
            dao.fields.BUDGET_MAIN_TYPE = 1
            dao.fields.BUDGET_DESCRIPTION = dd_type_6.SelectedItem.Text
        Else
            dao.fields.BUDGET_MAIN_TYPE = 0
            dao.fields.BUDGET_DESCRIPTION = txt_BUDGET_DESCRIPTION.Text
        End If

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
    Public Sub update(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
        Dim type_id As Integer
        Dim bg_type As Integer
        If type_id = 6 Then
            dao.fields.BUDGET_MAIN_TYPE = 1
            dao.fields.BUDGET_DESCRIPTION = dd_type_6.Text
        Else
            dao.fields.BUDGET_MAIN_TYPE = 0
            dao.fields.BUDGET_DESCRIPTION = txt_BUDGET_DESCRIPTION.Text
        End If
        dao.fields.BUDGET_MAIN_TYPE = bg_type
        'dao.fields.BUDGET_DESCRIPTION = txt_BUDGET_DESCRIPTION.Text
        If txt_budget_code.Text <> "" Then
            dao.fields.BUDGET_CODE = txt_budget_code.Text
        Else
            dao.fields.BUDGET_CODE = Nothing
        End If

    End Sub
    'Public Sub update_support(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
    '    dao.fields.BUDGET_IS_SUPPORT_DEPT = True
    'End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_BUDGET_PLAN)
        txt_BUDGET_DESCRIPTION.Text = dao.fields.BUDGET_DESCRIPTION
        txt_budget_code.Text = dao.fields.BUDGET_CODE

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
                'lb_BudgetType.Visible = True
                'dd_BUDGET_TYPE.Visible = True
            Case 7
                strBudget = "ชื่องบรายจ่าย : "
            Case 8
                strBudget = "ชื่องบรายจ่ายย่อย : "
                lb_budget_code.Visible = True
                txt_budget_code.Visible = True
        End Select

        Return strBudget
    End Function
    Public Sub get_ddl_select()
        ddl = dd_type_6.SelectedValue
    End Sub
End Class