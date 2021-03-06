﻿Imports Telerik.Web.UI
Public Class Frm_Disburse_OutsideDebtor
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
        
        If Not IsPostBack Then
            'Dim bao_adjust As New BAO_BUDGET.Budget
            'Dim dt As DataTable = bao_adjust.get_money_type_name(bgYear)
            'If dt.Rows.Count > 0 Then
            '    dd_BudgetAdjust.DataSource = dt
            '    dd_BudgetAdjust.DataBind()

            'End If

            Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
            'dao_node.Getdata_Head(0, bgYear)
            dao_node.Getdata_Head_no_Year(0)
            Dim rtv_money_type As New RadTreeView
            rtv_money_type = DirectCast(rcb_Moneytype.Items(0).FindControl("rtv_money_type"), RadTreeView)
            For Each dao_node.fields In dao_node.datas
                Dim node As New RadTreeNode
                dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
                node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
                node.Value = dao_node.fields.MONEY_TYPE_ID
                rtv_money_type.Nodes.Add(node)
                bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
            Next
        End If
        set_uc()
        
    End Sub
    Public Sub set_uc()
        Dim bgid As Integer = 0
        If rcb_Moneytype.SelectedValue <> "" Then
            bgid = rcb_Moneytype.SelectedValue
        End If
        Try
            UC_Disburse_Debtor1.BudgetID = bgid
            UC_Disburse_Debtor1.dept_id = _dept
            UC_Disburse_Debtor1.BudgetYear = bgYear
            UC_Disburse_Debtor1.BudgetUseID = 3
            UC_OutsideBudget_Amount_Detail1.getBGOutside_detail(bgid, bgYear)
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
    End Sub
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
        ' dao_node.Getdata_Head(ParentID, Master.get_Year())
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
    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        '  Response.Redirect("Frm_Disburse_OutsideDebtor_Bill_Insert.aspx?bguse=3&bgid=" & dd_BudgetAdjust.SelectedValue & "&bgyear=" & getbgYear())
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        'UC_Disburse_Debtor1.rebind_grid()
        UC_Disburse_Debtor1.rgFilter(str)
    End Sub

    'Private Sub dd_BudgetAdjust_TextChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.TextChanged
    '    UC_Disburse_Debtor1.rebind_grid()
    'End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Debtor1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor1.rebind_grid()
    End Sub

    Private Sub rcb_Moneytype_TextChanged(sender As Object, e As EventArgs) Handles rcb_Moneytype.TextChanged
        UC_Disburse_Debtor1.rebind_grid()
    End Sub
    
End Class