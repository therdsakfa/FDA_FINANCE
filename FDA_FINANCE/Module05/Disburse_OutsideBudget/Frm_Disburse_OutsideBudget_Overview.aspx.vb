Imports Telerik.Web.UI
Public Class Frm_Disburse_OutsideBudget_Overview
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        'Dim bao_user As New BAO_USER.USER
        'Dim dept_id As Integer = dd_Department.SelectedValue
        Dim bgYear As Integer = Master.get_Year()
        Dim bgid As Integer = 0
        If rcb_Moneytype.SelectedValue <> "" Then
            bgid = rcb_Moneytype.SelectedValue
        End If
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_Department()
            dd_Department.DataSource = dt
            dd_Department.DataBind()

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
        Try
            UC_OutsideBudget_Amount_Detail1.BudgetplanId = bgid
            UC_OutsideBudget_Amount_Detail1.Budgetyear = bgYear
            UC_OutsideBudget_Amount_Detail1.getBGOutside_detail(bgid, bgYear)
            UC_Disburse_Budget_With_Approve1.BudgetUseID = 3
            UC_Disburse_Budget_With_Approve1.BudgetID = bgid
            UC_Disburse_Budget_With_Approve1.BudgetYear = bgYear
            UC_Disburse_Budget_With_Approve1.bt = 2
            UC_Disburse_Budget_With_Approve1.g = 0
            UC_Disburse_Budget_With_Approve1.stat = 1
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
    End Sub
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
        'dao_node.Getdata_Head(ParentID, Master.get_Year())
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
        UC_Disburse_Budget_With_Approve1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Budget_With_Approve1.bindseq()
    End Sub

    'Private Sub dd_BudgetAdjust_TextChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.TextChanged
    '    UC_Disburse_Budget1.rebind_grid()
    'End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Budget_With_Approve1.rebind_grid()
        'Dim ctl As Control = Me.LoadControl("UserControl/UC_OutsideBudget_Amount_Detail.ascx")
        'ctl.ID = "UC_OutsideBudget_Amount_Detail1"
        'UpdatePanel.Controls.Clear()
        'UpdatePanel.Controls.Add(ctl)
    End Sub

    Private Sub rcb_Moneytype_TextChanged(sender As Object, e As EventArgs) Handles rcb_Moneytype.TextChanged
        UC_Disburse_Budget_With_Approve1.rebind_grid()
    End Sub
    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Budget_With_Approve1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Budget_With_Approve1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                Else
                    If UC_Disburse_Budget_With_Approve1.chk_selected_count <= 1 Then
                        UC_Disburse_Budget_With_Approve1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                'set_uc()
                UC_Disburse_Budget_With_Approve1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Budget_With_Approve1.chk_selected_count <= 1 Then
                    UC_Disburse_Budget_With_Approve1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
        'If rd_APPROVE_DATE.IsEmpty = False Then
        '    UC_Disburse_Budget_With_Approve1.update_true(rd_APPROVE_DATE.SelectedDate)
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)
        '    'set_uc()
        '    UC_Disburse_Budget_With_Approve1.rebind_grid()
        'Else
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        'End If

    End Sub

    'Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
    '    UC_Disburse_Budget_With_Approve1.update_false()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
    '    'set_uc()
    '    UC_Disburse_Budget_With_Approve1.rebind_grid()
    'End Sub
End Class