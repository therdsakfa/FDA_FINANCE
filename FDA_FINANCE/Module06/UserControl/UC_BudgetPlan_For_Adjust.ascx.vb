Imports Telerik.Web.UI
Public Class UC_BudgetPlan_For_Adjust
    Inherits System.Web.UI.UserControl
    Private _Type_Budget As Integer
    Public Property Type_Budget() As Integer
        Get
            Return _Type_Budget
        End Get
        Set(ByVal value As Integer)
            _Type_Budget = value
        End Set
    End Property
    Private _nodeId As Integer
    Public Property nodeId() As Integer
        Get
            Return _nodeId
        End Get
        Set(ByVal value As Integer)
            _nodeId = value
        End Set
    End Property
    Private _is_Adjust As Boolean
    Public Property is_Adjust() As Boolean
        Get
            Return _is_Adjust
        End Get
        Set(ByVal value As Boolean)
            _is_Adjust = value
        End Set
    End Property
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ดึงหัวข้อโหนดงบประมาณ
        If Not IsPostBack Then
            Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN
            dao_node.Getdata_by_Head_ID(0, bgyear)
            For Each dao_node.fields In dao_node.datas
                Dim node As New RadTreeNode
                If is_Adjust = False Then
                    Select Case getTypemenu(dao_node.fields.BUDGET_PLAN_ID)
                        Case 1
                            node.ContextMenuID = "rtcOperation"
                            node.ImageUrl = "~/images/n1.png"

                    End Select
                Else
                    Select Case getTypemenu(dao_node.fields.BUDGET_PLAN_ID)
                        Case 1
                            node.ImageUrl = "~/images/n1.png"
                            node.EnableContextMenu = False
                    End Select
                End If


                ' node.Text = dao_node.fields.CHILD_ID & " " & getDatatextfield(dao_node.fields.CHILD_ID)
                node.Text = getDatatextfield(dao_node.fields.BUDGET_PLAN_ID)
                node.Value = dao_node.fields.BUDGET_PLAN_ID
                node.ExpandMode = TreeNodeExpandMode.ServerSide
                rtBudgetPlan.Nodes.Add(node)
                ' bindnode(node.Nodes, dao_node.fields.CHILD_ID)

            Next
            ' rtBudgetPlan.DataBind()
            'rtBudgetPlan.ExpandAllNodes()
        End If
    End Sub
    ''' <summary>
    ''' ดึงโหนดลูกมาใส่ radtreeview
    ''' </summary>
    ''' <param name="rt"></param>
    ''' <param name="ParentID"></param>
    ''' <remarks></remarks>
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN
        dao_node.Getdata_by_Head_ID(ParentID, bgyear)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            Dim caseType As Integer = getTypemenu(dao_node.fields.BUDGET_PLAN_ID)
            If is_Adjust = False Then
                Select Case caseType
                    Case 2
                        node.ContextMenuID = "rtcActivity"
                        node.ImageUrl = "~/images/n2.png"
                        'node.ForeColor = Drawing.Color.Aqua
                    Case 3
                        node.ContextMenuID = "rtcProject"
                        node.ImageUrl = "~/images/n3.png"
                        'node.ForeColor = Drawing.Color.Brown
                    Case 4
                        node.ContextMenuID = "rtcbudget"
                        node.ImageUrl = "~/images/n4.png"
                        'node.ForeColor = Drawing.Color.Coral
                    Case 5
                        node.ContextMenuID = "rtcbudget_last"
                        node.ImageUrl = "~/images/n5.png"
                        'node.ForeColor = Drawing.Color.Crimson
                    Case 6
                        node.ContextMenuID = "RadTreeViewContextMenu1"
                        node.ImageUrl = "~/images/n6.png"
                        'node.ForeColor = Drawing.Color.DarkSalmon
                    Case 7
                        node.ContextMenuID = "RadTreeViewContextMenu2"
                        node.ImageUrl = "~/images/n7.png"
                        'node.ForeColor = Drawing.Color.ForestGreen
                    Case 8
                        node.ContextMenuID = "RadTreeViewContextMenu3"
                        node.ImageUrl = "~/images/n8.png"
                        'node.ForeColor = Drawing.Color.HotPink


                End Select
            Else
                Select Case caseType
                    Case 2
                        node.ImageUrl = "~/images/n2.png"
                        node.EnableContextMenu = False
                    Case 3
                        node.ImageUrl = "~/images/n3.png"
                        node.EnableContextMenu = False
                    Case 4
                        node.ImageUrl = "~/images/n4.png"
                        node.EnableContextMenu = False
                    Case 5
                        node.ImageUrl = "~/images/n5.png"
                        node.EnableContextMenu = False
                    Case 6
                        node.ImageUrl = "~/images/n6.png"
                        node.EnableContextMenu = False
                        node.ForeColor = Drawing.Color.Blue
                    Case 7
                        node.ImageUrl = "~/images/n7.png"
                        node.EnableContextMenu = False
                    Case 8
                        node.ImageUrl = "~/images/n8.png"
                        node.EnableContextMenu = False
                        'Case 0
                        '    node.ContextMenuID = "RadTreeViewContextMenu3"
                        '    node.ImageUrl = "~/images/n8.png"
                End Select
            End If
            node.ExpandMode = TreeNodeExpandMode.ServerSide
            'node.Text = dao_node.fields.CHILD_ID & " " & getDatatextfield(dao_node.fields.CHILD_ID)
            node.Text = getDatatextfield(dao_node.fields.BUDGET_PLAN_ID)
            node.Value = dao_node.fields.BUDGET_PLAN_ID
            'If caseType = 2 Or caseType = 7 Then
            '    bindnode(rt, dao_node.fields.CHILD_ID)
            'Else
            ''rt.Add(node)
            ''bindnode(node.Nodes, dao_node.fields.CHILD_ID)

            'End If
            If is_Adjust = True Then
                'If caseType = 7 Or caseType = 8 Then
                If caseType = 8 Then
                    '     bindnode(rt, dao_node.fields.CHILD_ID)
                Else
                    rt.Add(node)
                    '  node.ExpandMode = TreeNodeExpandMode.ServerSide
                    '   bindnode(node.Nodes, dao_node.fields.CHILD_ID)
                End If
            Else
                '    node.ExpandMode = TreeNodeExpandMode.ServerSide
                rt.Add(node)

                '  bindnode(node.Nodes, dao_node.fields.CHILD_ID)
            End If


        Next

        '  Return rt
    End Sub
    ''' <summary>
    ''' ดึง description ของงบประมาณ
    ''' </summary>
    ''' <param name="child_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    Public Function getTypemenu(ByVal child_id As Integer) As Integer
        Dim type_id As String = ""
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        dao.Getdata_by_BUDGET_PLAN_ID(child_id)
        type_id = dao.fields.BUDGET_TYPE_ID
        Return type_id
    End Function
    Private Sub rtvBudgetTree_ContextMenuItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTreeViewContextMenuEventArgs) Handles rtBudgetPlan.ContextMenuItemClick
        Dim clickedNode As RadTreeNode = e.Node
        Dim type_id As Integer = 0
        If is_Adjust = False Then
            Select Case e.Node.ContextMenuID
                Case "rtcOperation"
                    type_id = 2
                Case "rtcActivity"
                    type_id = 3
                Case "rtcProject"
                    type_id = 4
                Case "rtcbudget"
                    type_id = 5
                Case "rtcbudget_last"
                    type_id = 6
                Case "RadTreeViewContextMenu1"
                    type_id = 7
                Case "RadTreeViewContextMenu2"
                    type_id = 8
                Case "RadTreeViewContextMenu3"
                    type_id = 0

            End Select
            Dim url As String

            Select Case e.MenuItem.Value
                Case "insert"
                    'Response.Redirect("../Module06/Frm_BudgetPlan_Insert.aspx?id=" & e.Node.Value & "&typeid=" & type_id)
                    url = "Frm_BudgetPlan_Insert.aspx?id=" & e.Node.Value & "&typeid=" & type_id & "&bgyear=" & bgyear
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "insert_sub('" & url & "');", True)
                Case "update"
                    'Response.Redirect("../Module06/Frm_BudgetPlan_Edit.aspx?id=" & e.Node.Value & "&typeid=" & getTypemenu(e.Node.Value))
                    url = "Frm_BudgetPlan_Edit.aspx?id=" & e.Node.Value & "&typeid=" & getTypemenu(e.Node.Value) & "&bgyear=" & bgyear
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "k('" & url & "');", True)
                Case "delete"
                    Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
                    'Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
                    dao_plan.Getdata_by_BUDGET_PLAN_ID(e.Node.Value)
                    Dim log As New log_event.log
                    log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลขางบ " & dao_plan.fields.BUDGET_DESCRIPTION, "BUDGET_PLAN", e.Node.Value)
                    dao_plan.delete()
                    'dao_node.getdata_by_Child_id(e.Node.Value)
                    'dao_node.delete()

                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                    ' Response.Redirect("Frm_BudgetPlan.aspx")
                Case "set_sup"
                    Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
                    dao_plan.Getdata_by_BUDGET_PLAN_ID(e.Node.Value)
                    dao_plan.fields.BUDGET_IS_SUPPORT_DEPT = True
                    dao_plan.update()
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                    'Response.Redirect("/Module06/Frm_BudgetPlan.aspx")
                Case "cancel_sup"
                    Dim dao_plan As New DAO_MAS.TB_BUDGET_PLAN
                    dao_plan.Getdata_by_BUDGET_PLAN_ID(e.Node.Value)
                    dao_plan.fields.BUDGET_IS_SUPPORT_DEPT = False
                    dao_plan.update()
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                    ' Response.Redirect("/Module06/Frm_BudgetPlan.aspx")
            End Select
        End If



    End Sub

    '  Private nodeid As Integer
    Private Sub rtBudgetPlan_NodeClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles rtBudgetPlan.NodeClick
        Dim clickedNode As RadTreeNode = e.Node
        nodeId = e.Node.Value

        Dim p As Object = Me.Page
        p.BindData()
        ' p.set_bg_id()

    End Sub
    Public Function return_nodeid() As Integer
        Dim id_n As Integer = 0
        For Each node As RadTreeNode In rtBudgetPlan.SelectedNodes
            id_n = node.Value
        Next
        'Dim tvMajor As node = DirectCast(rdCboMajor.Items(0).FindControl("TreeView1"), RadTreeView)


        Return id_n
    End Function

    Public Function getPlanBack() As DataTable
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        dt.Columns.Add("seq")
        dt.Columns.Add("BUDGET_DESCRIPTION")
        dt.Columns.Add("BUDGET_AMOUNT")
        dt = baobudget.getNodeBack(dt, nodeId)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "seq desc"
        dt = dv.ToTable
        Return dt
    End Function
    Public Function getbg_id() As Integer
        Dim digit As Integer = 0
        digit = nodeId
        Return digit
    End Function
    Public Sub rt_rebind()
        rtBudgetPlan.Nodes.Clear()
        Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN
        dao_node.Getdata_by_Head_ID(0, bgyear)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            If is_Adjust = False Then
                Select Case getTypemenu(dao_node.fields.BUDGET_PLAN_ID)
                    Case 1
                        node.ContextMenuID = "rtcOperation"
                        node.ImageUrl = "~/images/n1.png"

                End Select
            Else
                Select Case getTypemenu(dao_node.fields.BUDGET_PLAN_ID)
                    Case 1
                        node.ImageUrl = "~/images/n1.png"
                        node.EnableContextMenu = False
                End Select
            End If


            node.Text = getDatatextfield(dao_node.fields.BUDGET_PLAN_ID)
            node.Value = dao_node.fields.BUDGET_PLAN_ID
            rtBudgetPlan.Nodes.Add(node)
            bindnode(node.Nodes, dao_node.fields.BUDGET_PLAN_ID)

        Next
        rtBudgetPlan.DataBind()
        rtBudgetPlan.ExpandAllNodes()
    End Sub

    Private Sub rtBudgetPlan_NodeExpand(sender As Object, e As RadTreeNodeEventArgs) Handles rtBudgetPlan.NodeExpand
        If e.Node.Nodes.Count = 0 Then
            bindnode(e.Node.Nodes, e.Node.Value)
            '  bindnode(e.Node.Nodes, dao_node.fields.CHILD_ID)
        End If
    End Sub

End Class