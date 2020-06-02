Imports Telerik.Web.UI
Public Class UC_Report_Dept_Budget_Adjust
    Inherits System.Web.UI.UserControl
    Private _bg_id As Integer
    Public Property bg_id() As Integer
        Get
            Return _bg_id
        End Get
        Set(ByVal value As Integer)
            _bg_id = value
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
    Public depid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Try
                'Dim dao As New DAO_USER.TB_tbl_USER
                'Dim strUserName As String = Session("AD")
                ''dao.Getdata_by_AD_NAME(strUserName)
                'dao.Get_dept_select_by_AD_NAME(strUserName)
                depid = Request.QueryString("dept")

                Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
                dao_dep.Getdata_by_DEPARTMENT_ID(depid)
                'If dao.fields.PERMISSION_ID = 2 Then
                '    Label2.Text = dao_dep.fields.DEPARTMENT_DESCRIPTION
                '    dd_Department.Style.Add("Display", "none")
                '    'BindAdjust(depid)
                '    bind_dl_bg(depid)
                'Else
                Label2.Text = ""
                dd_Department.Style.Add("Display", "block")
                bind_ddl_dept()
                'BindAdjust(dd_Department.SelectedValue)
                bind_dl_bg(dd_Department.SelectedValue)
                'End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub bind_ddl_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_Department()
        dd_Department.DataSource = dt
        dd_Department.DataBind()
    End Sub
    Public Sub bind_dl_bg(ByVal dept As Integer)
        Dim bao_adjust As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dept, 2557)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                If dao_head.fields.BUDGET_CODE <> "" Then
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                Else
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                End If

            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()


        End If
        ' UC_Disburse_Budget1.rebind_grid()
    End Sub
    Public Sub bind_dl_bg_auto()
        get_dataselect()
        bind_dl_bg(dept)
        'Dim bao_adjust As New BAO_BUDGET.Budget
        'Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dd_Department.SelectedValue, 2557)

        'If dt.Rows.Count > 0 Then
        '    For Each dr As DataRow In dt.Rows
        '        Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
        '        dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
        '        If dao_head.fields.BUDGET_CODE <> "" Then
        '            dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
        '        Else
        '            dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
        '        End If

        '    Next

        '    dd_BudgetAdjust.DataSource = dt
        '    dd_BudgetAdjust.DataBind()


        'End If

    End Sub
    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        bind_dl_bg(dd_Department.SelectedValue)
        Try
            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try
        
        ' BindAdjust(dd_Department.SelectedValue)
    End Sub

    'Private Sub BindAdjust(ByVal DepId As Integer)
    '    Dim bao_adjust As New BAO_BUDGET.MASS
    '    Dim dt As DataTable = bao_adjust.get_adjust_by_dept(DepId, 2557)

    '    Dim rtv_budget_node As New RadTreeView
    '    rtv_budget_node = DirectCast(rcb_budget.Items(0).FindControl("rtv_budget_node"), RadTreeView)
    '    rtv_budget_node.Nodes.Clear()
    '    rcb_budget.Text = ""
    '    For Each dr As DataRow In dt.Rows
    '        Dim node As New RadTreeNode
    '        ' dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
    '        node.Text = getDatatextfield(dr("BUDGET_CHILD_ID"))
    '        node.Value = dr("BUDGET_CHILD_ID")
    '        rtv_budget_node.Nodes.Add(node)
    '        bindnode(node.Nodes, dr("BUDGET_CHILD_ID"))
    '    Next
    'End Sub

    'Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
    '    Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
    '    Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
    '    dao_plan.Getdata_by_BUDGET_PLAN_ID(ParentID)
    '    dao_node.Getdata_by_Head_ID(ParentID, 2557)
    '    If dao_plan.fields.BUDGET_TYPE_ID < 6 Then
    '        For Each dao_node.fields In dao_node.datas
    '            Dim node As New RadTreeNode
    '            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
    '            node.Value = dao_node.fields.CHILD_ID
    '            rt.Add(node)
    '            bindnode(node.Nodes, dao_node.fields.CHILD_ID)
    '        Next
    '    End If

    'End Sub
    'Public Function getDatatextfield(ByVal child_id As Integer) As String
    '    Dim strTextfield As String = ""
    '    Dim dao As New DAO_MAS.TB_BUDGET_PLAN
    '    Dim sup_boolean As Boolean = False
    '    Dim Strsupport As String = ""
    '    dao.Getdata_by_BUDGET_PLAN_ID(child_id)
    '    If dao.fields.BUDGET_IS_SUPPORT_DEPT IsNot Nothing Then
    '        sup_boolean = dao.fields.BUDGET_IS_SUPPORT_DEPT
    '    End If
    '    If sup_boolean <> False Then
    '        Strsupport = "(งบสนับสนุนกรม)"
    '    End If

    '    strTextfield = dao.fields.BUDGET_CODE & " " & dao.fields.BUDGET_DESCRIPTION & " " & Strsupport
    '    Return strTextfield
    'End Function
    Public Sub get_dataselect()


        'dept = dd_Department.SelectedValue

        'Dim dao As New DAO_USER.TB_tbl_USER
        'Dim strUserName As String = Session("AD")
        'dao.Getdata_by_AD_NAME(strUserName)
        'depid = dao.fields.DEPARTMENT_ID
        'Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
        'dao_dep.Getdata_by_DEPARTMENT_ID(depid)
        'If dao.fields.PERMISSION_ID = 2 Then
        '    dept = dao.fields.DEPARTMENT_ID
        'Else
        '    ' bind_ddl_dept()
        dept = dd_Department.SelectedValue
        'End If
        If dd_BudgetAdjust.SelectedValue = "" Then
            bg_id = 0
        Else
            bg_id = dd_BudgetAdjust.SelectedValue
        End If
    End Sub


    'Private Sub rcb_budget_TextChanged(sender As Object, e As EventArgs) Handles rcb_budget.TextChanged
    '    Label1.Text = rcb_budget.SelectedValue
    'End Sub

    Public Function get_dept_value() As Integer
        Dim dept_ids As Integer = 0
        Try
            dept_ids = dd_Department.SelectedValue
        Catch ex As Exception

        End Try
        Return dept_ids
    End Function

    Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
        Try
            Dim p As Object = Me.Page
            p.BindData()
        Catch ex As Exception

        End Try
        
    End Sub
End Class