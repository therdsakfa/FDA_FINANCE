Public Class UC_Node_Auto
    Inherits System.Web.UI.UserControl
    Private _citizen_id As String
    Public Property citizen_id() As String
        Get
            Return _citizen_id
        End Get
        Set(ByVal value As String)
            _citizen_id = value
        End Set
    End Property
    Private _group_id As Integer
    Public Property group_id() As Integer
        Get
            Return _group_id
        End Get
        Set(ByVal value As Integer)
            _group_id = value
        End Set
    End Property
    Private _id_namesys As Integer
    Public Property id_namesys() As Integer
        Get
            Return _id_namesys
        End Get
        Set(ByVal value As Integer)
            _id_namesys = value
        End Set
    End Property
    Private _dept As String
    Private _bgid As String
    Private _myear As Integer = 0
    Sub rubQuery()
        Try
            _dept = Request.QueryString("dept")
        Catch ex As Exception

        End Try
        Try
            _bgid = Request.QueryString("bgid")
        Catch ex As Exception

        End Try
        Try
            _myear = Request.QueryString("myear")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rubQuery()
        gen_treeview()
        'If Not IsPostBack Then
        '    TreeView1.ExpandAll()
        'End If
        TreeView1.CollapseAll()
    End Sub
    Public Sub gen_treeview()
        Dim dt As New DataTable
        Dim bao As New BAO_PERMISSION.PERMISSION
        dt = bao.SP_PERMISSION_MENU_BUDGET(citizen_id, group_id, id_namesys)

        If dt.Rows.Count > 0 Then

            If _dept <> 2 Then
                Dim dao As New DAO_MAS.TB_MAS_MENU_AUTO
                dao.getData_by_parent_id_group2(0)
                TreeView1.Nodes.Clear()
                For Each dao.fields In dao.datas
                    'If dt.Select("idmenu=" & dao.fields.MENU_PERMISSION_ID).Count > 0 Then
                    Dim t_node As New TreeNode
                    t_node.Value = dao.fields.MENU_ID
                    t_node.Text = dao.fields.MENU_NAME
                    If dao.fields.MENU_URL = "#" Then
                        t_node.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri & "#"
                    Else
                        If dao.fields.MENU_URL.Contains("Frm_Disburse_Budget_Print_Check") Or dao.fields.MENU_URL.Contains("?") Then
                            t_node.NavigateUrl = dao.fields.MENU_URL & "&dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                        Else
                            t_node.NavigateUrl = dao.fields.MENU_URL & "?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                        End If

                    End If
                    Try
                        t_node.Target = dao.fields.MENU_TARGET
                    Catch ex As Exception

                    End Try


                    TreeView1.Nodes.Add(t_node)
                    gen_child_node(t_node.ChildNodes, dao.fields.MENU_ID)
                    'End If
                Next

            Else
                Dim dao As New DAO_MAS.TB_MAS_MENU_AUTO
                dao.getData_by_parent_id2(0)
                TreeView1.Nodes.Clear()

                For Each dao.fields In dao.datas
                    If dt.Select("idmenu=" & dao.fields.MENU_PERMISSION_ID).Count > 0 Then
                        Dim t_node As New TreeNode
                        t_node.Value = dao.fields.MENU_ID
                        t_node.Text = dao.fields.MENU_NAME
                        If dao.fields.MENU_URL = "#" Then
                            t_node.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri & "#"
                        Else
                            If dao.fields.MENU_URL.Contains("Frm_Disburse_Budget_Print_Check") Or dao.fields.MENU_URL.Contains("?") Then
                                t_node.NavigateUrl = dao.fields.MENU_URL & "&dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                            Else
                                t_node.NavigateUrl = dao.fields.MENU_URL & "?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                            End If

                        End If
                        Try
                            t_node.Target = dao.fields.MENU_TARGET
                        Catch ex As Exception

                        End Try


                        TreeView1.Nodes.Add(t_node)
                        gen_child_node(t_node.ChildNodes, dao.fields.MENU_ID)
                    End If
                Next
            End If

        End If
    End Sub
    Public Sub gen_child_node(ByVal t_node As TreeNodeCollection, Optional ByVal ParentID As Integer = 0)

            Dim dao As New DAO_MAS.TB_MAS_MENU_AUTO
            dao.getData_by_parent_id2(ParentID)
            For Each dao.fields In dao.datas
                Dim t_node2 As New TreeNode
                t_node2.Value = dao.fields.MENU_ID
                t_node2.Text = dao.fields.MENU_NAME
                If dao.fields.MENU_URL <> "#" Then
                If dao.fields.MENU_URL.Contains("Frm_Disburse_Budget_Print_Check") Or dao.fields.MENU_URL.Contains("?") Then
                    t_node2.NavigateUrl = dao.fields.MENU_URL & "&dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                Else
                    t_node2.NavigateUrl = dao.fields.MENU_URL & "?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                End If
                Else
                    t_node2.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri & "#"
                End If
                Try
                    t_node2.Target = dao.fields.MENU_TARGET
                Catch ex As Exception

                End Try
                t_node.Add(t_node2)
                gen_child_node(t_node2.ChildNodes, dao.fields.MENU_ID)
            Next
    End Sub
End Class