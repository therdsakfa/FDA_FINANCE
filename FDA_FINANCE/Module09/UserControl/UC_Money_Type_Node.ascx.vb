Imports Telerik.Web.UI
Public Class UC_Money_Type_Node
    Inherits System.Web.UI.UserControl
    Private _money_id As Integer
    Public Property money_id() As Integer
        Get
            Return _money_id
        End Get
        Set(ByVal value As Integer)
            _money_id = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setnode()
        End If

    End Sub
    Public Sub setnode()
        Dim rtv_money_type_node As New RadTreeView
        rtv_money_type_node = DirectCast(rcb_money_type.Items(0).FindControl("rtv_money_type_node"), RadTreeView)
        rtv_money_type_node.Nodes.Clear()
        rcb_money_type.Text = ""
        Dim dao_node As New DAO_MAS.TB_MONEY_TYPE_NODE
        dao_node.Getdata_by_Head_ID_no_year(0)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            node.Value = dao_node.fields.CHILD_ID
            rtv_money_type_node.Nodes.Add(node)
            bindnode(node.Nodes, dao_node.fields.CHILD_ID)

        Next

    End Sub

    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MONEY_TYPE_NODE
        dao_node.Getdata_by_Head_ID_no_year(ParentID)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            node.Value = dao_node.fields.CHILD_ID
            rt.Add(node)
            bindnode(node.Nodes, dao_node.fields.CHILD_ID)
        Next

    End Sub
    Public Function getDatatextfield(ByVal child_id As Integer) As String
        Dim strTextfield As String = ""
        Dim dao As New DAO_MAS.TB_MAS_MONEY_TYPE
        dao.Getdata_by_MONEY_TYPE_ID(child_id)
        strTextfield = dao.fields.MONEY_TYPE_DESCRIPTION
        Return strTextfield
    End Function

    Public Sub getDateSelect()
        If rcb_money_type.SelectedValue <> "" Then
            money_id = rcb_money_type.SelectedValue
        Else
            money_id = 0
        End If


    End Sub
End Class