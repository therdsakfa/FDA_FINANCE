Imports Telerik.Web.UI
Public Class Frm_Disburse_OutsideDebtor_Overview
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
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_Department()
            dd_Department.DataSource = dt
            dd_Department.DataBind()

            'Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            'Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
            ''dao_node.Getdata_Head(0, bgYear)
            'dao_node.Getdata_Head_no_Year(0)
            'Dim rtv_money_type As New RadTreeView
            'rtv_money_type = DirectCast(rcb_Moneytype.Items(0).FindControl("rtv_money_type"), RadTreeView)
            'For Each dao_node.fields In dao_node.datas
            '    Dim node As New RadTreeNode
            '    dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            '    node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
            '    node.Value = dao_node.fields.MONEY_TYPE_ID
            '    rtv_money_type.Nodes.Add(node)
            '    bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
            'Next
        End If
       
        set_uc()
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        'UC_Disburse_Debtor1.rebind_grid()
        UC_Disburse_OutsideDebtor_With_Approve1.rgFilter(str)
    End Sub
    Public Sub set_uc()
        'Dim bgid As Integer = 0
        'If rcb_Moneytype.SelectedValue <> "" Then
        '    bgid = rcb_Moneytype.SelectedValue
        'End If
        Dim dept_id As Integer = 0
        Try
            dept_id = dd_Department.SelectedValue
        Catch ex As Exception
            dept_id = 0
        End Try

        Try
            UC_Disburse_OutsideDebtor_With_Approve1.BudgetID = _bgid
            UC_Disburse_OutsideDebtor_With_Approve1.dept_id = dept_id
            UC_Disburse_OutsideDebtor_With_Approve1.BudgetYear = bgYear
            UC_Disburse_OutsideDebtor_With_Approve1.BudgetUseID = 3
            UC_OutsideBudget_Amount_Detail1.getBGOutside_detail(_bgid, bgYear)
            UC_Disburse_OutsideDebtor_With_Approve1.g = 0
            UC_Disburse_OutsideDebtor_With_Approve1.bt = 3
            UC_Disburse_OutsideDebtor_With_Approve1.stat = 3
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_OutsideDebtor_With_Approve1.rebind_grid()
    End Sub

    'Private Sub rcb_Moneytype_TextChanged(sender As Object, e As EventArgs) Handles rcb_Moneytype.TextChanged
    '    UC_Disburse_OutsideDebtor_With_Approve1.rebind_grid()
    'End Sub
    'Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
    '    If rd_APPROVE_DATE.IsEmpty = False Then
    '        UC_Disburse_OutsideDebtor_With_Approve1.update_true(rd_APPROVE_DATE.SelectedDate)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)
    '        set_uc()
    '        UC_Disburse_OutsideDebtor_With_Approve1.rebind_grid()
    '    Else
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
    '    End If

    'End Sub

    'Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
    '    UC_Disburse_OutsideDebtor_With_Approve1.update_false()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
    '    set_uc()
    '    UC_Disburse_OutsideDebtor_With_Approve1.rebind_grid()
    'End Sub

    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_OutsideDebtor_With_Approve1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_OutsideDebtor_With_Approve1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)


                Else
                    If UC_Disburse_OutsideDebtor_With_Approve1.chk_selected_count <= 1 Then
                        UC_Disburse_OutsideDebtor_With_Approve1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                set_uc()
                UC_Disburse_OutsideDebtor_With_Approve1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_OutsideDebtor_With_Approve1.chk_selected_count <= 1 Then
                    UC_Disburse_OutsideDebtor_With_Approve1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub
End Class