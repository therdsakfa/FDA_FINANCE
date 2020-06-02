Imports Telerik.Web.UI
Public Class UC_Report_Dept_Plan
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_Department()
            dd_Department.DataSource = dt
            dd_Department.DataBind()
        End If
    End Sub

    Private Sub dd_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Department.SelectedIndexChanged
        Dim bao_adjust As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_adjust.get_adjust_by_dept(dd_Department.SelectedValue, 2557)

        Dim rtv_budget_node As New RadTreeView
        rtv_budget_node = DirectCast(rcb_budget.Items(0).FindControl("rtv_budget_node"), RadTreeView)
        rtv_budget_node.Nodes.Clear()
        rcb_budget.Text = ""
        For Each dr As DataRow In dt.Rows
            Dim node As New RadTreeNode
            ' dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            node.Text = getDatatextfield(dr("BUDGET_CHILD_ID"))
            node.Value = dr("BUDGET_CHILD_ID")
            rtv_budget_node.Nodes.Add(node)
            bindnode(node.Nodes, dr("BUDGET_CHILD_ID"))
        Next
    End Sub

    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
        dao_plan.Getdata_by_BUDGET_PLAN_ID(ParentID)
        dao_node.Getdata_by_Head_ID(ParentID, 2557)
        If dao_plan.fields.BUDGET_TYPE_ID < 6 Then
            For Each dao_node.fields In dao_node.datas
                Dim node As New RadTreeNode
                node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
                node.Value = dao_node.fields.CHILD_ID
                rt.Add(node)
                bindnode(node.Nodes, dao_node.fields.CHILD_ID)
            Next
        End If
    End Sub

    Public Function getDatatextfield(ByVal child_id As Integer) As String
        Dim strTextfield As String = ""
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Dim sup_boolean As Boolean = False
        Dim Strsupport As String = ""
        dao.Getdata_by_BUDGET_PLAN_ID(child_id)

        If dao.fields.BUDGET_IS_SUPPORT_DEPT IsNot Nothing Then
            sup_boolean = dao.fields.BUDGET_IS_SUPPORT_DEPT
        End If
        If sup_boolean <> False Then
            Strsupport = "(งบสนับสนุนกรม)"
        End If

        strTextfield = dao.fields.BUDGET_CODE & " " & dao.fields.BUDGET_DESCRIPTION & " " & Strsupport
        Return strTextfield
    End Function

    Public Sub get_dataselect()
        bg_id = 0 'rcb_budget.SelectedValue
        dept = dd_Department.SelectedValue
    End Sub
    Public Sub get_dept_select()
        dept = dd_Department.SelectedValue
    End Sub
End Class