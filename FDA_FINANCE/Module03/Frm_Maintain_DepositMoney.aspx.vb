Imports Telerik.Web.UI
Public Class Frm_Maintain_DepositMoney
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        bgYear = Request.QueryString("myear")
        UC_Maintain_DepositMoney.BudgetYear = bgYear
        UC_Maintain_DepositMoney_SelectDeposit1.BudgetYear = bgYear
        If Not IsPostBack Then
            UC_Maintain_DepositMoney_SelectDeposit1.bindseq()
            'Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            'Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
            'dao_node.Getdata_Head_no_Year(0)
            'Dim rtv_money_type As New RadTreeView
            'For Each dao_node.fields In dao_node.datas
            '    Dim node As New RadTreeNode
            '    dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            '    node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
            '    node.Value = dao_node.fields.MONEY_TYPE_ID
            '    rtv_money_type.Nodes.Add(node)
            '    bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
            'Next
        End If
    End Sub
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
        dao_node.Getdata_Head_no_Year(ParentID)
        For Each dao_node.fields In dao_node.datas
            dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            Dim node As New RadTreeNode
            node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
            node.Value = dao_node.fields.MONEY_TYPE_ID
            rt.Add(node)
            bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
        Next
    End Sub
    Private Sub Frm_Maintain_DepositMoney_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        UC_Maintain_DepositMoney.bindseq()
        UC_Maintain_DepositMoney_SelectDeposit1.bindseq()
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_DepositMoney.rebindRg()
        UC_Maintain_DepositMoney_SelectDeposit1.rebindRg()
    End Sub
End Class