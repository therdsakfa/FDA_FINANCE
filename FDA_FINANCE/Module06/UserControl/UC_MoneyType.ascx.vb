Imports Telerik.Web.UI
Public Class UC_MoneyType
    Inherits System.Web.UI.UserControl
    Private _nodeId As Integer
    Public Property nodeId() As Integer
        Get
            Return _nodeId
        End Get
        Set(ByVal value As Integer)
            _nodeId = value
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
        If Not IsPostBack Then
            Dim dao_node As New DAO_MAS.TB_MONEY_TYPE_NODE
            dao_node.Getdata_by_Head_ID_no_year(0)
            For Each dao_node.fields In dao_node.datas
                Dim node As New RadTreeNode
                node.ContextMenuID = "rtcSubList"
                node.ImageUrl = "~/images/n1.png"
                node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
                node.Value = dao_node.fields.CHILD_ID
                rtMoneyType.Nodes.Add(node)
                bindnode(node.Nodes, dao_node.fields.CHILD_ID)

            Next

            'rtMoneyType.ExpandAllNodes()
        End If

       
    End Sub
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MONEY_TYPE_NODE
        dao_node.Getdata_by_Head_ID_no_year(ParentID)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            Dim caseType As Integer = getTypemenu(dao_node.fields.CHILD_ID)

            Select Case caseType
                Case 2
                    node.ContextMenuID = "rtcSub1"
                    node.ImageUrl = "~/images/n2.png"
                Case 3
                    node.ContextMenuID = "rtcSub2"
                    node.ImageUrl = "~/images/n3.png"
                Case 4
                    node.ContextMenuID = "rtcFinished"
                    node.ImageUrl = "~/images/n4.png"
                    'Case 5
                    '    node.ContextMenuID = "rtcbudget_last"
                    '    node.ImageUrl = "~/images/n5.png"
                    'Case 6
                    '    node.ContextMenuID = "RadTreeViewContextMenu1"
                    '    node.ImageUrl = "~/images/n6.png"
                    'Case 7
                    '    node.ContextMenuID = "RadTreeViewContextMenu2"
                    '    node.ImageUrl = "~/images/n7.png"
                    'Case 8
                    '    node.ContextMenuID = "RadTreeViewContextMenu3"
                    '    node.ImageUrl = "~/images/n8.png"

            End Select

            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            node.Value = dao_node.fields.CHILD_ID
            'If caseType = 2 Or caseType = 7 Then
            '    bindnode(rt, dao_node.fields.CHILD_ID)
            'Else
            rt.Add(node)
            bindnode(node.Nodes, dao_node.fields.CHILD_ID)

            'End If
            ''If is_Adjust = True Then
            ''    If caseType = 7 Or caseType = 8 Then
            ''        bindnode(rt, dao_node.fields.CHILD_ID)
            ''    Else
            ''        rt.Add(node)
            ''        bindnode(node.Nodes, dao_node.fields.CHILD_ID)
            ''    End If
            ''Else
            ''    rt.Add(node)
            ''    bindnode(node.Nodes, dao_node.fields.CHILD_ID)
            ''End If


        Next

        '  Return rt
    End Sub
    Public Function getPlanBack() As DataTable
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        dt.Columns.Add("seq")
        dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
        dt.Columns.Add("MONEY_AMOUNT")
        dt.Columns.Add("TYPE_ID")
        dt = baobudget.getMoneyTypeNodeBack(dt, nodeId)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "seq desc"
        dt = dv.ToTable
        Return dt
    End Function
    Public Function getChild() As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.get_Moneytype_child(nodeId)
        Return dt
    End Function
    Public Function getbg_id() As Integer
        Dim digit As Integer = 0
        digit = nodeId
        Return digit
    End Function
    Public Function getDatatextfield(ByVal child_id As Integer) As String
        Dim strTextfield As String = ""
        Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
        dao.Getdata_by_MONEY_TYPE_ID(child_id)
        strTextfield = dao.fields.MONEY_TYPE_DESCRIPTION
        Return strTextfield
    End Function
    Public Function getTypemenu(ByVal child_id As Integer) As Integer
        Dim type_id As String = ""
        Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
        dao.Getdata_by_MONEY_TYPE_ID(child_id)
        type_id = dao.fields.TYPE_ID
        Return type_id
    End Function

    Private Sub rtMoneyType_ContextMenuItemClick(sender As Object, e As RadTreeViewContextMenuEventArgs) Handles rtMoneyType.ContextMenuItemClick
        Dim clickedNode As RadTreeNode = e.Node
        Dim type_id As Integer = 0

        Select Case e.Node.ContextMenuID
            Case "rtcSubList"
                type_id = 2
            Case "rtcSub1"
                type_id = 3
            Case "rtcSub2"
                type_id = 4
            Case "rtcFinished"
                type_id = 0


        End Select

        Dim url As String
        Select Case e.MenuItem.Value
            Case "insert"
                url = "Frm_MoneyType_Insert.aspx?id=" & e.Node.Value & "&typeid=" & type_id & "&bgyear=" & bgyear
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "insert_sub('" & url & "');", True)
            Case "update"
                url = "Frm_MoneyType_Edit.aspx?id=" & e.Node.Value & "&typeid=" & getTypemenu(e.Node.Value) & "&bgyear=" & bgyear
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
            Case "delete"
                Dim dao_dept As New DAO_MAS.TB_MAS_MONEY_TYPE
                Dim dao_node As New DAO_MAS.TB_MONEY_TYPE_NODE
                dao_dept.Getdata_by_MONEY_TYPE_ID(e.Node.Value)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลประเภทเงิน " & dao_dept.fields.MONEY_TYPE_DESCRIPTION, "MAS_MONEY_TYPE", e.Node.Value)
                dao_dept.delete()
                dao_node.Getdata_by_Child_ID(e.Node.Value)
                dao_node.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            Case Else
        End Select

    End Sub

    Private Sub rtMoneyType_NodeClick(sender As Object, e As RadTreeNodeEventArgs) Handles rtMoneyType.NodeClick
        Dim clickedNode As RadTreeNode = e.Node
        nodeId = e.Node.Value

        Dim p As Object = Me.Page
        p.bind_inf()

    End Sub
    Public Sub rt_rebind()
        rtMoneyType.Nodes.Clear()
        Dim dao_node As New DAO_MAS.TB_MONEY_TYPE_NODE
        dao_node.Getdata_by_Head_ID_no_year(0)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            node.ContextMenuID = "rtcSubList"
            node.ImageUrl = "~/images/n1.png"
            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            node.Value = dao_node.fields.CHILD_ID
            rtMoneyType.Nodes.Add(node)
            bindnode(node.Nodes, dao_node.fields.CHILD_ID)

        Next
        rtMoneyType.DataBind()
        rtMoneyType.ExpandAllNodes()
    End Sub
End Class