Imports Telerik.Web.UI
Public Class UC_RELATE_BILL_DETAIL2
    Inherits System.Web.UI.UserControl
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Public Sub run_Query()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
    End Sub
    Public Sub set_panel_confirm()
        Panel2.Style.Add("display", "block")
        Panel1.Style.Add("display", "none")
        Try
            lb_amount1.Text = String.Format("{0:###,###.##}", rnt_AMOUNT.Value)
        Catch ex As Exception

        End Try
        'lb_max_period.Text = rnt_period_max.Value
        lb_doc_date1.Text = txt_DOC_DATE.Text
        lb_docnumber.Text = txt_DOC_NUMBER.Text
        Try
            lb_customer1.Text = dd_CUSTOMER.SelectedItem.Text
        Catch ex As Exception

        End Try

        lb_description1.Text = txt_DESCRIPTION.Text
        lb_do_date1.Text = txt_dodate.Text
        lb_paylist1.Text = ddl_GL.SelectedItem.Text 'rcb_budget.Text
        'lb_palce1.Text = txt_place.Text
        'lb_travel_date1.Text = txt_travel_date.Text
        'lb_travel_dateend1.Text = txt_travel_date_end.Text
        'lb_henchop1.Text = txt_henchop.Text
        'lb_henchop_date1.Text = txt_henchop_date.Text
        'lb_ko1.Text = txt_ko.Text
        'lb_ko_date1.Text = txt_ko_date.Text
        'lb_project_number1.Text = txt_PROJECT_NUMBER.Text
        'lb_PO_CONTRACT_NUMBER1.Text = txt_PO_CONTRACT_NUMBER.Text
        'lb_PO_CONTRACT_date1.Text = txt_PO_CONTRACT_DATE.Text
        'lb_egp1.Text = txt_EGP.Text
        'lb_PO_GFMIS_NUMBER1.Text = txt_PO_GFMIS_NUMBER.Text
        'lb_PO_GFMIS_DATE1.Text = txt_PO_GFMIS_DATE.Text
        lb_type1.Text = rdl_type.SelectedItem.Text

    End Sub
    Public Sub set_panel_cancel()
        Panel2.Style.Add("display", "none")
        Panel1.Style.Add("display", "block")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        run_Query()
        If _bid <> "" Then
            Dim dao_cer As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao_cer.Getdata_by_ID(_bid)
            _dept = dao_cer.fields.DEPARTMENT_ID


            If Not IsPostBack Then
                'Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
                'dao_node.Getdata_by_Head_ID(_bgid, _bgyear)
                'Dim rtv_bg_plan As New RadTreeView
                'rtv_bg_plan = DirectCast(rcb_budget.Items(0).FindControl("rtv_bg_plan"), RadTreeView)
                'For Each dao_node.fields In dao_node.datas
                '    Dim node As New RadTreeNode

                '    node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
                '    node.Value = dao_node.fields.CHILD_ID
                '    rtv_bg_plan.Nodes.Add(node)
                '    bindnode_bg(node.Nodes, dao_node.fields.CHILD_ID)

                'Next

                set_amount()

                If Request.QueryString("bguse") <> "3" Then

                End If
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(_bid)

                If dao.fields.BUDGET_USE_ID IsNot Nothing Or dao.fields.BUDGET_USE_ID <> 3 Then
                    'Dim dao_moneytype As New DAO_MAS.TB_BUDGET_PLAN
                    'dao_moneytype.Getdata_by_BUDGET_PLAN_ID(dao.fields.PAYLIST_ID)
                    'rcb_budget.Text = dao_moneytype.fields.BUDGET_DESCRIPTION

                    'Dim tree As RadTreeView = rcb_budget.Items(0).FindControl("rtv_bg_plan")
                    'Dim node_sel = tree.FindNodeByValue(dao.fields.PAYLIST_ID)
                    'node_sel.Selected = True
                    'rcb_budget.SelectedValue = node_sel.Value
                End If
            End If
        Else
            If Not IsPostBack Then
                'Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
                'dao_node.Getdata_by_Head_ID(_bgid, _bgyear)
                'Dim rtv_bg_plan As New RadTreeView
                'rtv_bg_plan = DirectCast(rcb_budget.Items(0).FindControl("rtv_bg_plan"), RadTreeView)
                'For Each dao_node.fields In dao_node.datas
                '    Dim node As New RadTreeNode

                '    node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
                '    node.Value = dao_node.fields.CHILD_ID
                '    rtv_bg_plan.Nodes.Add(node)
                '    bindnode_bg(node.Nodes, dao_node.fields.CHILD_ID)
                'Next
                set_amount()

            End If
        End If
    End Sub
    Public Sub set_data(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_ALL)
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        Else
            dao.fields.DOC_DATE = Nothing
        End If
        'dao.fields.PERIOD_MAX = rnt_period_max.Value
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.BUDGET_ID = _bgid
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        Try
            dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        Catch ex As Exception
            dao.fields.CUSTOMER_ID = 0
        End Try

        'dao.fields.DEPARTMENT_ID = _dept
        dao.fields.IS_APPROVE = False
        If txt_dodate.Text <> "" Then
            dao.fields.DO_DATE = CDate(txt_dodate.Text)
        Else
            dao.fields.DO_DATE = Nothing
        End If
        Try
            dao.fields.PAYLIST_ID = ddl_GL.SelectedValue 'rcb_budget.SelectedValue
        Catch ex As Exception
            dao.fields.PAYLIST_ID = 0
        End Try

        Try
            dao.fields.RELATE_TYPE = rdl_type.SelectedValue
        Catch ex As Exception

        End Try

    End Sub
    Public Sub insert_det(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_DETAIL)

        Try
            dao.fields.GL_ID = ddl_GL.SelectedValue
        Catch ex As Exception
            dao.fields.GL_ID = 0
        End Try
        Try
            dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        Catch ex As Exception
            dao.fields.CUSTOMER_ID = 0
        End Try
        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.APPROVE_AMOUNT = rnt_AMOUNT.Value
        dao.fields.APPROVE_AMOUNT = rnt_AMOUNT.Value

    End Sub
    Public Sub get_data_det(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_DETAIL)
        Try
            ddl_GL.DropDownSelectData(dao.fields.GL_ID)
        Catch ex As Exception
        End Try
        Try
            dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
        Catch ex As Exception

        End Try
        Try
            rnt_AMOUNT.Value = dao.fields.AMOUNT
        Catch ex As Exception

        End Try
        Try
            rnt_AMOUNT.Value = dao.fields.APPROVE_AMOUNT
        Catch ex As Exception

        End Try

    End Sub
    Public Sub get_data(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_ALL)
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString()
        End If

        'Try
        '    rnt_period_max.Value = dao.fields.PERIOD_MAX
        'Catch ex As Exception
        '    rnt_period_max.Value = 0
        'End Try
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        rnt_AMOUNT.Value = dao.fields.AMOUNT
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
        If dao.fields.DO_DATE IsNot Nothing Then
            txt_dodate.Text = CDate(dao.fields.DO_DATE).ToShortDateString()
        End If
        
        Try
            rdl_type.SelectedValue = dao.fields.RELATE_TYPE
        Catch ex As Exception

        End Try

        'ddl_GL.DropDownSelectData(dao.fields.
    End Sub
    Public Sub set_amount()
        Dim dao_dpt As New DAO_MAS.TB_MAS_DEPARTMENT
        If Request.QueryString("dept") IsNot Nothing Then
            dao_dpt.Getdata_by_DEPARTMENT_ID(Request.QueryString("dept"))
            lb_dept.Text = dao_dpt.fields.DEPARTMENT_DESCRIPTION
        Else
            If _bid <> "" Then
                'Dim dao As New DAO_DISBURSE.TB_CERTIFICATE_ALL
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(_bid)
                dao_dpt.Getdata_by_DEPARTMENT_ID(dao.fields.DEPARTMENT_ID)
                lb_dept.Text = dao_dpt.fields.DEPARTMENT_DESCRIPTION
            End If

        End If
        Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        If Request.QueryString("bgid") IsNot Nothing Then
            dao_bg.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
            dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
            lb_project_name.Text = dao_head_bg.fields.BUDGET_DESCRIPTION
        End If

        Dim uti_adjust As New BAO_BUDGET.Budget
        Dim adjust_amount As Double = uti_adjust.get_bg_adjust_detail_amount2(_bgyear, _bgid, _dept)
        lb_adjust_amount.Text = adjust_amount.ToString("N")

        Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App2(_bgid, _bgyear, _dept)
        lb_Amount.Text = (adjust_amount - disburse_app).ToString("N")

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
    Public Sub bindnode_bg(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
        dao_node.Getdata_by_Head_ID(ParentID, _bgyear)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            node.Value = dao_node.fields.CHILD_ID
            rt.Add(node)
            bindnode_bg(node.Nodes, dao_node.fields.CHILD_ID)
        Next

    End Sub
    Public Sub bind_dd_cus()
        Dim bao_cus As New BAO_BUDGET.MASS
        Dim dt_cus As DataTable = bao_cus.get_customer()

        dd_CUSTOMER.DataSource = dt_cus
        dd_CUSTOMER.DataBind()
    End Sub
    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_gl.get_GL()

        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub
End Class