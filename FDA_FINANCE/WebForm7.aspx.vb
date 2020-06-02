Imports Telerik.Web.UI
Public Class WebForm7
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gen_treeview()
        End If
    End Sub
    Public Sub gen_treeview()
        Dim dt As New DataTable

        Dim dao As New DAO_MAS.TB_MAS_MENU_AUTO
        dao.getData_by_parent_id_group2(0)
        RadMenu1.Items.Clear()    'Nodes.Clear()

        For Each dao.fields In dao.datas
            'If dt.Select("idmenu=" & dao.fields.MENU_PERMISSION_ID).Count > 0 Then
            Dim t_node As New RadMenuItem
            t_node.Value = dao.fields.MENU_ID
            t_node.Text = dao.fields.MENU_NAME
            If dao.fields.MENU_URL = "#" Then
                t_node.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri & "#"
            Else
                If dao.fields.MENU_URL.Contains("Frm_Disburse_Budget_Print_Check") Then
                    t_node.NavigateUrl = dao.fields.MENU_URL '& "&dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                Else
                    t_node.NavigateUrl = dao.fields.MENU_URL '& "?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                End If

            End If
            Try
                t_node.Target = dao.fields.MENU_TARGET
            Catch ex As Exception

            End Try


            RadMenu1.Items.Add(t_node)
            gen_child_node(t_node.Items, dao.fields.MENU_ID)
            'End If
        Next


    End Sub
    Public Sub gen_child_node(ByVal t_node As RadMenuItemCollection, Optional ByVal ParentID As Integer = 0)

        Dim dao As New DAO_MAS.TB_MAS_MENU_AUTO
        dao.getData_by_parent_id2(ParentID)
        For Each dao.fields In dao.datas
            Dim t_node2 As New RadMenuItem
            t_node2.Value = dao.fields.MENU_ID
            t_node2.Text = dao.fields.MENU_NAME
            If dao.fields.MENU_URL <> "#" Then
                If dao.fields.MENU_URL.Contains("Frm_Disburse_Budget_Print_Check") Then
                    t_node2.NavigateUrl = dao.fields.MENU_URL '& "&dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                Else
                    t_node2.NavigateUrl = dao.fields.MENU_URL '& "?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear
                End If
            Else
                t_node2.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri & "#"
            End If
            Try
                t_node2.Target = dao.fields.MENU_TARGET
            Catch ex As Exception

            End Try
            t_node.Add(t_node2)
            gen_child_node(t_node2.Items, dao.fields.MENU_ID)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ws As New WS_STATUS_PAY.Service1
        Dim str As String = ""
        str = ws.Get_Status(TextBox2.Text, TextBox3.Text)
        Label1.Text = str
        'Dim ws As New WS_PERSONAL_DEPARTMENT.DOCService
        'Dim obj As New Object
        'Dim xml As String = ""
        'obj = ws.getMemberProfile("3830100303444")
        ''Dim clsxml As New Cls_XML
        ''clsxml.ReadXml(obj)
        'Dim fullname As String = ""
        'Dim FirstName As String = ""
        'Try
        '    fullname = obj.FullName 'clsxml.Get_Value_XML("FullName")
        '    Label1.Text = fullname
        '    FirstName = obj.FirstName
        'Catch ex As Exception

        'End Try
    End Sub
End Class