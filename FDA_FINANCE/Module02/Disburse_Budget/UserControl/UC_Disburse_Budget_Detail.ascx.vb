Imports System.Web.UI
Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Budget_Detail
    Inherits System.Web.UI.UserControl
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Private _Budget_Use_id As Integer
    Public Property Budget_Use_id() As Integer
        Get
            Return _Budget_Use_id
        End Get
        Set(ByVal value As Integer)
            _Budget_Use_id = value
        End Set
    End Property
    Private _is_insert As Boolean
    Public Property is_insert() As Boolean
        Get
            Return _is_insert
        End Get
        Set(ByVal value As Boolean)
            _is_insert = value
        End Set
    End Property
    Private _egp As Boolean
    Public Property egp() As Boolean
        Get
            Return _egp
        End Get
        Set(ByVal value As Boolean)
            _egp = value
        End Set
    End Property
    Private _stat_egp As Integer
    Public Property stat_egp() As Integer
        Get
            Return _stat_egp
        End Get
        Set(ByVal value As Integer)
            _stat_egp = value
        End Set
    End Property

    Public bgyear As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim dao_user As New DAO_USER.TB_tbl_USER
        'dao_user.Getdata_by_AD_NAME(NameUserAD())
        If is_insert = False Then
            'If dept_id = 12 Then
            Panel2.Style.Add("Display", "block")
            'Else
            '    Panel2.Style.Add("Display", "none")
            'End If
            'If dao_user.fields.PERMISSION_ID = "1" Then
            '    Panel2.Style.Add("Display", "block")
            'ElseIf dao_user.fields.PERMISSION_ID = "2" Then
            '    Panel2.Style.Add("Display", "none")
            'End If
        Else
            Panel2.Style.Add("Display", "none")
        End If

        If Not IsPostBack Then

            'If Request.QueryString("id") IsNot Nothing Then
            '    run_get_data(Request.QueryString("id"))
            'End If



            Dim dao_paylist As New DAO_MAS.TB_MAS_PAYLIST
            ' Dim dao_customer As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
            Dim bao_adjust As New BAO_BUDGET.Budget
            'dao_customer.Getdata()
            dao_paylist.Getdata()


            'Dim dr_cus As DataRow = dt_cus.NewRow()
            'dr_cus("CUSTOMER_ID") = "0"
            'dr_cus("CUSTOMER_NAME") = "ไม่ทราบเจ้าหนี้"
            'dt_cus.Rows.Add(dr_cus)

            'Dim dv As DataView = dt_cus.DefaultView
            'dv.Sort = "CUSTOMER_ID ASC"
            'dt_cus = dv.ToTable()


            'dd_CUSTOMER_2.DataSource = dt_cus
            'dd_CUSTOMER_2.DataBind()

            Dim bao_mass As New BAO_BUDGET.MASS
            Dim dt_mass As DataTable = bao_mass.get_customer_type
            'Dim dt_cus_type As DataTable = dao_customer.dt

            'dd_CUSTOMER_TYPE.DataSource = dt_mass
            'dd_CUSTOMER_TYPE.DataBind()
            Dim dao_c As New DAO_MAS.TB_MAS_CUSTOMER
            Try
                dao_c.Getdata_by_CUSTOMER_ID(dd_CUSTOMER.SelectedValue)
            Catch ex As Exception

            End Try


            If Request.QueryString("bguse") IsNot Nothing Then
                If Request.QueryString("bguse") <> "3" Then
                    cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                    cal_net()
                End If
            Else
                cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                cal_net()
            End If

            'Dim dao_pl_receive As New DAO_MAS.TB_MAS_PAYLIST
            'dao_pl_receive.Getdata()
            Dim bao_paylist As New BAO_BUDGET.MASS
            Dim dt_pl As DataTable = bao_paylist.get_paylist()

            'dd_sub_paylist.DataSource = dt_pl
            'dd_sub_paylist.DataBind()

            Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
            Dim dao_out As New DAO_MAS.TB_MAS_MONEY_TYPE

            bgyear = Request.QueryString("bgYear")
            Dim bgid As String = ""
            bgid = Request.QueryString("bgid")
            Dim bguse As String = ""
            If Request.QueryString("bguse") <> "" Then
                bguse = Request.QueryString("bguse")
            End If
            If bgid <> "" Then
                If bguse <> "3" Or bguse = "" Then
                    'rcb_budget.Style.Add("display", "block")
                    lb_paylist.Style.Add("display", "block")
                    dao_bg.Getdata_by_BUDGET_PLAN_ID(bgid)
                    lb_budget.Text = dao_bg.fields.BUDGET_DESCRIPTION

                    Try
                        Dim dao_act As New DAO_MAS.TB_BUDGET_PLAN
                        dao_act.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
                        Dim dao_act2 As New DAO_MAS.TB_BUDGET_PLAN
                        dao_act2.Getdata_by_BUDGET_PLAN_ID(dao_act.fields.BUDGET_CHILD_ID)

                        lb_activity.Text = dao_act2.fields.BUDGET_DESCRIPTION
                    Catch ex As Exception

                    End Try



                    Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
                    Try
                        dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
                    Catch ex As Exception

                    End Try
                    Try
                        lb_project_name.Text = dao_head_bg.fields.BUDGET_DESCRIPTION
                    Catch ex As Exception
                        lb_project_name.Text = "-"
                    End Try


                    'If Request.QueryString("po") Is Nothing Then
                    Dim uti_adjust As New Utility_other()
                    Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
                    Dim bao_debt_app As New BAO_BUDGET.Budget
                    Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bgid, bgyear)
                    ' Dim disburse_app As Double = uti_adjust.getAdjust_Appr_Amount(bgid, dept_id, bgyear, "True")
                    Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(bgid, bgyear, dept_id)
                    Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App(bgid, bgyear)
                    'lb_Amount.Text = (adjust_amount - (disburse_app + debtor_app)).ToString("N")
                    lb_Amount.Text = (adjust_amount - disburse_app).ToString("N")
                    lb_adjust_amount.Text = adjust_amount.ToString("N")
                    'Else
                    '    get_pobalance(Request.QueryString("bid"))
                    '    If lb_Amount.Text <> "" Then
                    '        Dim dao_sub As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                    '        dao_sub.Getdata_by_Disburse_id(Request.QueryString("bid"))
                    '        lb_Amount.Text = CDbl(lb_Amount.Text) + dao_sub.fields.AMOUNT
                    '    End If
                    'End If
                    If Request.QueryString("flag") = "sup" Then
                        If Request.QueryString("pl") IsNot Nothing Then
                            Dim dao_pl As New DAO_MAS.TB_BUDGET_PLAN
                            dao_pl.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("pl"))

                            lb_paylist.Style.Add("Display", "block")
                            ddl_GL.Style.Add("Display", "none")
                            If dao_pl.fields.BUDGET_DESCRIPTION IsNot Nothing Then
                                lb_paylist_des.Text = dao_pl.fields.BUDGET_DESCRIPTION
                            End If

                        End If

                    End If
                    Dim dao_adjust As New DAO_BUDGET.TB_BUDGET_ADJUST
                    dao_adjust.Getdata_by_BUDGET_PLAN_ID(bgid)

                    If dao_adjust.fields.DEPARTMENT_ID IsNot Nothing Then
                        Dim dao_dpt As New DAO_MAS.TB_MAS_DEPARTMENT
                        dao_dpt.Getdata_by_DEPARTMENT_ID(dao_adjust.fields.DEPARTMENT_ID)
                        lb_dept.Text = dao_dpt.fields.DEPARTMENT_DESCRIPTION
                    End If




                    Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
                    dao_node.Getdata_by_Head_ID(bgid, bgyear)
                    Dim rtv_bg_plan As New RadTreeView
                    'rtv_bg_plan = DirectCast(rcb_budget.Items(0).FindControl("rtv_bg_plan"), RadTreeView)
                    For Each dao_node.fields In dao_node.datas
                        Dim node As New RadTreeNode

                        node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
                        node.Value = dao_node.fields.CHILD_ID
                        rtv_bg_plan.Nodes.Add(node)
                        bindnode_bg(node.Nodes, dao_node.fields.CHILD_ID)

                    Next

                    'ElseIf Request.QueryString("bgid") = "sup" Then
                    '    lb_Budget_Plan.Text = "งบสนับสนุนกรม"
                    '    rcb_budget.Style.Add("display", "none")
                    '    lb_paylist.Style.Add("display", "none")
                ElseIf Request.QueryString("bguse") = "3" Then
                    'lb_Budget_Plan.Text = "เงินนอกงบประมาณ"
                    dao_out.Getdata_by_MONEY_TYPE_ID(bgid)
                    lb_budget.Text = dao_out.fields.MONEY_TYPE_DESCRIPTION
                    ddl_GL.Style.Add("display", "none")
                    lb_paylist.Style.Add("display", "none")

                    Dim bao_old_balancec As New BAO_BUDGET.DISBURSE_BUDGET
                    Dim bao_no_app As New BAO_BUDGET.DISBURSE_BUDGET
                    Dim bao_app As New BAO_BUDGET.DISBURSE_BUDGET
                    Dim bao_receive As New BAO_BUDGET.DISBURSE_BUDGET
                    Dim old_balance As Double = 0
                    Dim dis_no_app As Double = 0
                    Dim dis_app As Double = 0
                    Dim receive As Double = 0
                    Dim bao_head_text As New BAO_BUDGET.MASS
                    Dim bao_dept As New BAO_BUDGET.MASS
                    Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
                    dao_dept.Getdata_by_DEPARTMENT_ID(dept_id)
                    old_balance = bao_old_balancec.get_old_balance_no_app(bgid, bgyear)
                    dis_no_app = bao_no_app.get_dis_outbudget_no_app(bgid, bgyear)
                    dis_app = bao_app.get_dis_outbudget_app(bgid, bgyear)
                    receive = bao_app.get_receive_all(bgid, bgyear)


                    lb_dept.Text = dao_dept.fields.DEPARTMENT_DESCRIPTION
                    lb_project_name.Text = bao_head_text.get_moneytype_head_text(bgid)
                    lb_adjust_amount.Text = (old_balance + receive).ToString("N")
                    lb_Amount.Text = ((old_balance + receive) - Math.Abs(dis_no_app)).ToString("N")
                End If



            End If
            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
                dao_dept.Getdata_by_DEPARTMENT_ID(dao_bill.fields.DEPARTMENT_ID)
                lb_dept.Text = dao_dept.fields.DEPARTMENT_DESCRIPTION


                dao_detail.Getdata_by_Disburse_id(Request.QueryString("bid"))
                Dim playlist As Integer = 0
                If dao_bill.fields.PATLIST_ID IsNot Nothing Then
                    playlist = dao_bill.fields.PATLIST_ID
                End If
                If Request.QueryString("flag") = "sup" Then
                    If dao_bill.fields.PATLIST_ID IsNot Nothing Then
                        Dim dao_pl As New DAO_MAS.TB_BUDGET_PLAN
                        dao_pl.Getdata_by_BUDGET_PLAN_ID(dao_bill.fields.PATLIST_ID)

                        lb_paylist.Style.Add("Display", "block")
                        ' rcb_budget.Style.Add("Display", "none")
                        If dao_pl.fields.BUDGET_DESCRIPTION IsNot Nothing Then
                            lb_paylist_des.Text = dao_pl.fields.BUDGET_DESCRIPTION
                        End If

                    End If
                End If

                If dao_detail.fields.BUDGET_DISBURSE_BILL_ID IsNot Nothing Then
                    If Request.QueryString("po") Is Nothing Then
                        Dim uti_adjust As New Utility_other()
                        Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
                        Dim bao_debt_app As New BAO_BUDGET.Budget
                        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bgid, bgyear)
                        ' Dim disburse_app As Double = uti_adjust.getAdjust_Appr_Amount(bgid, dept_id, bgyear, "True")
                        Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App(bgid, bgyear)
                        Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(bgid, bgyear, dept_id)
                        lb_Amount.Text = ((adjust_amount + CDbl(dao_detail.fields.AMOUNT)) - disburse_app).ToString("N")
                    Else
                        'Dim dao_detail_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                        'dao_detail_po.Getdata_by_Disburse_id(Request.QueryString("bid"))
                        get_pobalance(Request.QueryString("bid"))
                        'If lb_Amount.Text <> "" Then
                        '    lb_Amount.Text = CDbl(lb_Amount.Text) + dao_detail_po.fields.AMOUNT
                        'End If

                    End If

                End If

                Try
                    Dim dao_cus1 As New DAO_MAS.TB_MAS_CUSTOMER
                    dao_cus1.Getdata_by_CUSTOMER_ID(dao_bill.fields.CUSTOMER_ID)
                    dd_CUSTOMER.Items.Insert(0, New ListItem(dao_cus1.fields.CUSTOMER_NAME, dao_cus1.fields.CUSTOMER_ID))
                Catch ex As Exception

                End Try

                If dao_bill.fields.CUSTOMER_TYPE_ID IsNot Nothing Then
                    If dao_bill.fields.CUSTOMER_TYPE_ID <> 0 Then
                        Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
                        dao_cus.Getdata_by_CUSTOMER_TYPE_ID(dao_bill.fields.CUSTOMER_TYPE_ID)
                        'dd_CUSTOMER_TYPE.Items.Insert(0, New ListItem(dao_cus.fields.CUSTOMER_TYPE, dao_cus.fields.CUSTOMER_TYPE_ID))


                        'dd_CUSTOMER_TYPE.DropDownSelectData(dao_bill.fields.CUSTOMER_TYPE_ID)
                        If Request.QueryString("bguse") IsNot Nothing Then
                            If Request.QueryString("bguse") <> "3" Then
                                cal_tax_by_customer_type(dao_bill.fields.CUSTOMER_TYPE_ID)
                                cal_net()
                            End If
                        Else
                            cal_tax_by_customer_type(dao_bill.fields.CUSTOMER_TYPE_ID)
                            cal_net()
                        End If
                    Else
                        'dd_CUSTOMER_TYPE.Items.Insert(0, New ListItem("ไม่ทราบ", 7))
                    End If
                Else
                    'dd_CUSTOMER_TYPE.Items.Insert(0, New ListItem("ไม่ทราบ", 7))
                End If
                If dao_bill.fields.RECEIVE_PAYLIST IsNot Nothing Then
                    If dao_bill.fields.RECEIVE_PAYLIST <> 0 Then
                        'dd_sub_paylist.DropDownSelectData(dao_bill.fields.RECEIVE_PAYLIST)

                    End If
                End If

            End If

            ' get_vat()
        End If

    End Sub
    Public Sub disable_detail()
        txt_DOC_NUMBER.Enabled = False
        txt_DOC_DATE.Enabled = False
        dd_CUSTOMER.Enabled = False
        ddl_GL.Enabled = False
        txt_DESCRIPTION.Enabled = False
        rnt_AMOUNT.Enabled = False
    End Sub
    Public Sub bind_cus()
        Dim bao_cus As New BAO_BUDGET.MASS
        Dim dt_cus As DataTable = bao_cus.get_customer()
        dd_CUSTOMER.DataSource = dt_cus
        dd_CUSTOMER.DataBind()
    End Sub
    Public Function chk_amount_less_5k() As Boolean
        Dim bool As Boolean = False
        If CStr(rnt_AMOUNT.Value) <> "" Then
            If rnt_AMOUNT.Value < 5000 Then
                bool = True
            Else
                bool = False
            End If
        End If
        Return bool
    End Function

    Public Function chk_remain() As Boolean
        Dim bool As Boolean = True
        If rnt_Amount2.Value <> "" Then
            Dim balance As Double = 0
            Dim max_price As Double = 0
            Dim disburse_amount As Double = 0
            Dim result As Double = 0
            Dim dao_max As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_max.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

            If dao_max.fields.MAIN_BILL IsNot Nothing Then
                disburse_amount = bao.get_dis_amount_all_multi_bill(dao_max.fields.MAIN_BILL)
            End If
            If dao_max.fields.MAX_PRIZE IsNot Nothing Then
                max_price = dao_max.fields.MAX_PRIZE
            End If
            balance = max_price - disburse_amount

            result = balance - rnt_Amount2.Value
            If result < 0 Then
                bool = False
            End If
        End If
       
        Return bool
    End Function
    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_gl.get_GL()

        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub
    Public Sub set_date()
        ' txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
        'txt_Bill_RECIEVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    Public Sub set_date_receive()
        'txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
        'txt_Bill_RECIEVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    Public Sub get_vat()
        If rnt_AMOUNT.Value <> 0 Then
            rnt_TAX_AMOUNT.Value = rnt_AMOUNT.Value * 0.01
        End If
    End Sub
    Public Sub get_pobalance(ByVal po_id As Integer)
        Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim po_head_amount As Double = 0
        Dim disburse_amount As Double = 0
        dao_po.Getdata_by_Disburse_id(po_id)
        If dao_po.fields.AMOUNT IsNot Nothing Then
            po_head_amount = dao_po.fields.AMOUNT
        End If
        disburse_amount = bao.get_sub_po_amount(po_id)

        lb_Amount.Text = (po_head_amount - disburse_amount).ToString("N")

    End Sub
    Public Sub run_get_data(id As Integer)
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
        Dim playlist As Integer = 0
        playlist = dao_bill.fields.PATLIST_ID
        '-----
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        If dao_bill.fields.BUDGET_PLAN_ID IsNot Nothing Then
            dao_bg.Getdata_by_BUDGET_PLAN_ID(dao_bill.fields.BUDGET_PLAN_ID)
            'lb_Budget_Plan.Text = dao_bg.fields.BUDGET_DESCRIPTION
            lb_budget.Text = dao_bg.fields.BUDGET_DESCRIPTION
            'runnode(dao_bill.fields.BUDGET_PLAN_ID, dao_bill.fields.BUDGET_YEAR)
            Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
            dao_node.Getdata_by_Head_ID(dao_bill.fields.BUDGET_PLAN_ID, dao_bill.fields.BUDGET_YEAR)
        End If
        '----
        If dao_bill.fields.CUSTOMER_ID <> 0 Or dao_bill.fields.CUSTOMER_ID IsNot Nothing Then
            Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
            dao_cus.Getdata_by_CUSTOMER_ID(dao_bill.fields.CUSTOMER_ID)
            dd_CUSTOMER.Items.Insert(0, New ListItem(dao_cus.fields.CUSTOMER_NAME, dao_cus.fields.CUSTOMER_ID))

        End If

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
        dao_node.Getdata_by_Head_ID(ParentID, bgyear)
        For Each dao_node.fields In dao_node.datas
            Dim node As New RadTreeNode
            node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            node.Value = dao_node.fields.CHILD_ID
            rt.Add(node)
            bindnode_bg(node.Nodes, dao_node.fields.CHILD_ID)
        Next

    End Sub
    Public Sub insert_master(ByRef dao As DAO_DISBURSE.TB_BUDGET_MASTER_BILL)
        Dim pay_type As Integer = Nothing
        Dim bg As Integer
        Dim bgYear As Integer
        Dim bg_use As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bgid") <> "sup" And Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 1
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If


            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 3
                pay_type = 2
                paylist = "0"
            End If


            If Request.QueryString("flag") = "sup" Then
                bg = Request.QueryString("bgid")
                bg_use = 2
                If Request.QueryString("pl") IsNot Nothing Then
                    paylist = Request.QueryString("pl")
                Else
                    paylist = 0
                End If

            End If
        Else
            bg = 0
        End If

        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If

        dao.fields.USER_AD = NameUserAD()
        dao.fields.BUDGET_YEAR = bgyear
        dao.fields.BUDGET_PLAN_ID = bg
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If

        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'If txt_BILL_DATE.Text <> "" Then
        '    dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        'Else
        dao.fields.BILL_DATE = System.DateTime.Now
        ' End If

        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = paylist
        dao.fields.IS_APPROVE = False
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.BUDGET_USE_ID = bg_use
        dao.fields.PAY_TYPE_ID = pay_type
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        dao.fields.DEBTOR_ID = 0

    End Sub

    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลเบิดจ่ายงบประมาณ
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)


        'Dim dd_bg_year As DropDownList = Page.Master.FindControl("dd_BudgetYear")
        Dim pay_type As Integer = Nothing
        Dim bg As Integer
        Dim bgYear As Integer
        Dim bg_use As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bgid") <> "sup" And Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 1
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If

           
            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 3
                pay_type = 2
                paylist = "0"

            End If


            If Request.QueryString("flag") = "sup" Then
                bg = Request.QueryString("bgid")
                bg_use = 2
                If Request.QueryString("pl") IsNot Nothing Then
                    paylist = Request.QueryString("pl")
                Else
                    paylist = 0
                End If

                'If rcb_budget.SelectedValue <> "" Then
                '    paylist = rcb_budget.SelectedValue
                'Else
                '    paylist = 0
                'End If


            End If
        Else
            bg = 0
        End If
       
        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If

        dao.fields.USER_AD = NameUserAD()
        dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = bg
        'dao.fields.PAY_NAME = txt_PAY_NAME.Text
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now ' CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If

        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'If txt_BILL_DATE.Text <> "" Then
        '    dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        'Else
        '    dao.fields.BILL_DATE = Nothing
        'End If
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = paylist
        dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        'dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.BUDGET_USE_ID = bg_use
        dao.fields.GFMIS_NUMBER = ""
        dao.fields.GFMIS_DATE = Nothing
        dao.fields.INVOICES_DATE = Nothing
        dao.fields.INVOICES_NUMBER = ""
        dao.fields.RECEIPT_NUMBER = ""
        dao.fields.RECEIPT_DATE = Nothing
        dao.fields.RETURN_APPROVE_DATE = Nothing
        dao.fields.RETURN_APPROVE_NUMBER = ""
        dao.fields.PAY_TYPE_ID = pay_type
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.DEBTOR_ID = 0
        dao.fields.CHECK_APPROVE = False
        dao.fields.IS_CHECK_RECEIVE = False
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        'If dd_sub_paylist.SelectedValue <> "" Then
        dao.fields.RECEIVE_PAYLIST = ddl_GL.SelectedValue 'dd_sub_paylist.SelectedValue
        ' End If
    End Sub
    Public Sub insert_multi(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)


        'Dim dd_bg_year As DropDownList = Page.Master.FindControl("dd_BudgetYear")
        Dim pay_type As Integer = Nothing
        Dim bg As Integer
        Dim bgYear As Integer
        Dim bg_use As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bgid") <> "sup" And Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 1
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If
            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 3
                pay_type = 2
                paylist = "0"
            End If
            If Request.QueryString("flag") = "sup" Then
                bg = Request.QueryString("bgid")
                bg_use = 2
                If Request.QueryString("pl") IsNot Nothing Then
                    paylist = Request.QueryString("pl")
                Else
                    paylist = 0
                End If

            End If
        Else
            bg = 0
        End If

        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If
        'dao.fields.PAY_NAME = txt_PAY_NAME.Text
        dao.fields.USER_AD = NameUserAD()
        dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = bg
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'If txt_BILL_DATE.Text <> "" Then
        '    dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        'Else
        '    dao.fields.BILL_DATE = Nothing
        'End If
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = paylist
        dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        'dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.BUDGET_USE_ID = bg_use
        dao.fields.GFMIS_NUMBER = ""
        dao.fields.GFMIS_DATE = Nothing
        dao.fields.INVOICES_DATE = Nothing
        dao.fields.INVOICES_NUMBER = ""
        dao.fields.RECEIPT_NUMBER = ""
        dao.fields.RECEIPT_DATE = Nothing
        dao.fields.RETURN_APPROVE_DATE = Nothing
        dao.fields.RETURN_APPROVE_NUMBER = ""
        dao.fields.PAY_TYPE_ID = pay_type
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.DEBTOR_ID = 0
        dao.fields.CHECK_APPROVE = False
        dao.fields.IS_CHECK_RECEIVE = False
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        'dao.fields.EGP_NUMBER = txt_EGP.Text
        'If dd_sub_paylist.SelectedValue <> "" Then
        dao.fields.RECEIVE_PAYLIST = ddl_GL.SelectedValue 'dd_sub_paylist.SelectedValue
        'End If
       
    End Sub

    Public Sub update(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)


        'Dim dd_bg_year As DropDownList = Page.Master.FindControl("dd_BudgetYear")
        Dim pay_type As Integer = Nothing
        Dim bg As Integer
        Dim bgYear As Integer
        Dim bg_use As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bgid") <> "sup" And Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 1
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If


            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 3
                pay_type = 2
                paylist = "0"
            End If


            If Request.QueryString("flag") = "sup" Then
                bg = Request.QueryString("bgid")
                bg_use = 2
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If
            End If
        Else
            bg = 0
        End If

        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If

        Try
            dao.fields.USER_AD = NameUserAD()
        Catch ex As Exception

        End Try
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'dao.fields.PAY_NAME = txt_PAY_NAME.Text
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = paylist
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        dao.fields.IS_DEPARTMENT = False
        'dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        'If dd_sub_paylist.SelectedValue <> "" Then
        dao.fields.RECEIVE_PAYLIST = ddl_GL.SelectedValue ' dd_sub_paylist.SelectedValue
        'End If
        ' dao.fields.BUDGET_USE_ID = bg_use
        'dao.fields.GFMIS_NUMBER = ""
        'dao.fields.GFMIS_DATE = Nothing
        'dao.fields.INVOICES_DATE = Nothing
        'dao.fields.INVOICES_NUMBER = ""
        'dao.fields.RECEIPT_NUMBER = ""
        'dao.fields.RECEIPT_DATE = Nothing
        'dao.fields.RETURN_APPROVE_DATE = Nothing
        'dao.fields.RETURN_APPROVE_NUMBER = ""
        'dao.fields.PAY_TYPE_ID = pay_type
        'dao.fields.DEPARTMENT_ID = dept_id
        'dao.fields.DEBTOR_ID = 0
        'dao.fields.CHECK_APPROVE = False
        'dao.fields.IS_CHECK_RECEIVE = False
        'dao.fields.EGP_NUMBER = txt_EGP.Text
        'dao.fields.PO_CHECKER_NUM = txt_PO.Text
        'dao.fields.PO_DOC_NUMBER = txt_PO_DOC_NUMBER.Text
        'dao.fields.PO_SYSTEM_NUMBER = txt_PO_SYSTEM_NUMBER.Text
        'Try
        '    dao.fields.OUT_RECEIPT_NUMBER = txt_OUT_RECEIPT_NUMBER.Text
        'Catch ex As Exception

        'End Try
        'Try
        '    dao.fields.OUT_RECEIPT_VOLLUME = txt_OUT_RECEIPT_VOLLUME.Text
        'Catch ex As Exception

        'End Try
        'Try
        '    dao.fields.CUSTOMER_ID2 = ddl_customer2.SelectedValue
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub update_master(ByRef dao As DAO_DISBURSE.TB_BUDGET_MASTER_BILL)
        Dim pay_type As Integer = Nothing
        Dim bg As Integer
        Dim bgYear As Integer
        Dim bg_use As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bgid") <> "sup" And Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 1
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If


            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 3
                pay_type = 2
                paylist = "0"
            End If


            If Request.QueryString("flag") = "sup" Then
                bg = Request.QueryString("bgid")
                bg_use = 2
                If Request.QueryString("pl") IsNot Nothing Then
                    paylist = Request.QueryString("pl")
                Else
                    paylist = 0
                End If

            End If
        Else
            bg = 0
        End If

        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If

        dao.fields.USER_AD = NameUserAD()
        dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = bg
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If

        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = paylist
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value

    End Sub


    Public Sub update_bill(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)


        'Dim dd_bg_year As DropDownList = Page.Master.FindControl("dd_BudgetYear")
        Dim pay_type As Integer = Nothing
        Dim bg As Integer
        Dim bgYear As Integer
        Dim bg_use As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bgid") <> "sup" And Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 1
                'If rcb_budget.SelectedValue <> "" Then
                paylist = ddl_GL.SelectedValue
                'Else
                '    paylist = 0
                'End If

            ElseIf Request.QueryString("bgid") = "sup" Then
                bg = 0
                bg_use = 2
                paylist = "0"
            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bg_use = 3
                pay_type = 2
                paylist = "0"
            End If
        Else
            bg = 0
        End If
        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If

        'dao.fields.USER_AD = NameUserAD()
        'dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = bg
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'If txt_BILL_DATE.Text <> "" Then
        '    dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        'Else
        '    dao.fields.BILL_DATE = Nothing
        'End If
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        'If rcb_budget.SelectedValue <> "" Then
        dao.fields.PATLIST_ID = ddl_GL.SelectedValue
        'End If
        'dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        'dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        'dao.fields.PAY_NAME = txt_PAY_NAME.Text
        'If dd_sub_paylist.SelectedValue <> "" Then
        dao.fields.RECEIVE_PAYLIST = ddl_GL.SelectedValue
        'End If
        'dao.fields.BUDGET_USE_ID = bg_use
        'dao.fields.GFMIS_NUMBER = ""
        'dao.fields.GFMIS_DATE = Nothing
        'dao.fields.INVOICES_DATE = Nothing
        'dao.fields.INVOICES_NUMBER = ""
        'dao.fields.RECEIPT_NUMBER = ""
        'dao.fields.RECEIPT_DATE = Nothing
        'dao.fields.RETURN_APPROVE_DATE = Nothing
        'dao.fields.RETURN_APPROVE_NUMBER = ""
        'dao.fields.PAY_TYPE_ID = pay_type
        'dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        dao.fields.DEBTOR_ID = 0
        dao.fields.CHECK_APPROVE = False
        dao.fields.IS_CHECK_RECEIVE = False
        Try
            dao.fields.RECEIVER_AD = NameUserAD()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub insert_rebill(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)


        'Dim dd_bg_year As DropDownList = Page.Master.FindControl("dd_BudgetYear")
        Dim bg As Integer
        Dim bgYear As Integer
        Dim debtor_id As Integer
        Dim paylist As String = "0"
        'If rcb_budget.SelectedValue <> "" Then
        paylist = ddl_GL.SelectedValue
        'Else
        '    paylist = 0
        'End If

        If Request.QueryString("bgid") IsNot Nothing Then
            bg = Request.QueryString("bgid")
        Else
            bg = 0
        End If

        If Request.QueryString("dbid") IsNot Nothing Then
            debtor_id = Request.QueryString("dbid")
        End If

        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If
        dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = bg
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'If txt_BILL_DATE.Text <> "" Then
        '    dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        'Else
        '    dao.fields.BILL_DATE = Nothing
        'End If
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = paylist
        dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        'dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.BUDGET_USE_ID = 1
        dao.fields.GFMIS_NUMBER = ""
        dao.fields.GFMIS_DATE = Nothing
        dao.fields.INVOICES_DATE = Nothing
        dao.fields.INVOICES_NUMBER = ""
        dao.fields.RECEIPT_NUMBER = ""
        dao.fields.RECEIPT_DATE = Nothing
        dao.fields.RETURN_APPROVE_DATE = Nothing
        dao.fields.RETURN_APPROVE_NUMBER = ""
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        'dao.fields.PAY_NAME = txt_PAY_NAME.Text
        ' dao.fields.PAY_TYPE_ID = Nothing
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.DEBTOR_ID = debtor_id
        dao.fields.CHECK_APPROVE = False
        dao.fields.IS_CHECK_RECEIVE = False
        dao.fields.PAY_TYPE_ID = 2
        'dao.fields.EGP_NUMBER = txt_EGP.Text
    End Sub
    Public Sub insert_rebill_out(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        'Dim dd_bg_year As DropDownList = Page.Master.FindControl("dd_BudgetYear")
        Dim bg As Integer
        Dim bgYear As Integer
        Dim debtor_id As Integer
        Dim paylist As Integer

        If Request.QueryString("dbid") IsNot Nothing Then
            debtor_id = Request.QueryString("dbid")
        End If
        If Request.QueryString("bgYear") IsNot Nothing Then
            bgYear = Request.QueryString("bgYear")
        End If
        dao.fields.BUDGET_YEAR = bgYear
        dao.fields.BUDGET_PLAN_ID = Request.QueryString("bgid")
        'If txt_Bill_RECIEVE_DATE.Text <> "" Then
        dao.fields.Bill_RECIEVE_DATE = Date.Now 'CDate(txt_Bill_RECIEVE_DATE.Text)
        'End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        'dao.fields.PAY_NAME = txt_PAY_NAME.Text
        dao.fields.BILL_DATE = System.DateTime.Now
        dao.fields.MAX_PRIZE = rnt_AMOUNT.Value
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PATLIST_ID = 0
        dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        'dao.fields.CUSTOMER_TYPE_ID = dd_CUSTOMER_TYPE.SelectedValue
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.BUDGET_USE_ID = 3
        dao.fields.GFMIS_NUMBER = ""
        dao.fields.GFMIS_DATE = Nothing
        dao.fields.INVOICES_DATE = Nothing
        dao.fields.INVOICES_NUMBER = ""
        dao.fields.RECEIPT_NUMBER = ""
        dao.fields.RECEIPT_DATE = Nothing
        dao.fields.RETURN_APPROVE_DATE = Nothing
        dao.fields.RETURN_APPROVE_NUMBER = ""
        ' dao.fields.PAY_TYPE_ID = Nothing
        dao.fields.DEPARTMENT_ID = dept_id
        dao.fields.DEBTOR_ID = debtor_id
        dao.fields.CHECK_APPROVE = False
        dao.fields.IS_CHECK_RECEIVE = False
        dao.fields.PAY_TYPE_ID = 2
        
    End Sub

    Public Sub insert_detail(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL, ByVal id As Integer)
        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.TAX_AMOUNT = rnt_TAX_AMOUNT.Value
        dao.fields.IS_ENABLE = True
        dao.fields.BUDGET_DISBURSE_BILL_ID = id
        dao.fields.APPROVE_AMOUNT = rnt_Approve.Value
    End Sub
    Public Sub insert_detail_multi(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL, ByVal id As Integer)
        dao.fields.AMOUNT = rnt_Amount2.Value
        dao.fields.TAX_AMOUNT = rnt_TAX_AMOUNT.Value
        dao.fields.IS_ENABLE = True
        dao.fields.BUDGET_DISBURSE_BILL_ID = id
        dao.fields.APPROVE_AMOUNT = rnt_Approve.Value
    End Sub

    Public Sub update_detail(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.TAX_AMOUNT = rnt_TAX_AMOUNT.Value
        dao.fields.APPROVE_AMOUNT = rnt_Approve.Value
    End Sub
    Public Sub update_detail_multi(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        dao.fields.AMOUNT = rnt_Amount2.Value
        dao.fields.TAX_AMOUNT = rnt_TAX_AMOUNT.Value
        dao.fields.APPROVE_AMOUNT = rnt_Approve.Value
    End Sub
    Public Sub getdata_detail(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        rnt_AMOUNT.Value = dao.fields.AMOUNT
        If dao.fields.TAX_AMOUNT IsNot Nothing Then
            rnt_TAX_AMOUNT.Value = dao.fields.TAX_AMOUNT
        Else
            rnt_TAX_AMOUNT.Value = 0
        End If

        If dao.fields.APPROVE_AMOUNT IsNot Nothing Then
            rnt_Approve.Value = dao.fields.APPROVE_AMOUNT
        Else
            rnt_Approve.Value = 0
        End If

        rnt_Amount2.Value = dao.fields.AMOUNT
    End Sub
    Public Sub getdata_detaimulti(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        rnt_AMOUNT.Value = dao.fields.AMOUNT
        'If dao.fields.TAX_AMOUNT IsNot Nothing Then
        '    rnt_TAX_AMOUNT.Value = dao.fields.TAX_AMOUNT
        'Else
        '    rnt_TAX_AMOUNT.Value = 0
        'End If

        'If dao.fields.APPROVE_AMOUNT IsNot Nothing Then
        '    rnt_Approve.Value = dao.fields.APPROVE_AMOUNT
        'Else
        '    rnt_Approve.Value = 0
        'End If
        rnt_Amount2.Value = dao.fields.AMOUNT
        rnt_Approve.Value = dao.fields.APPROVE_AMOUNT
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลเบิกจ่ายงบประมาณ
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata_head(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
        Catch ex As Exception

        End Try
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = dao.fields.DOC_DATE
        End If
        If dao.fields.BILL_NUMBER IsNot Nothing Then
            txt_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
        End If
        If dao.fields.DESCRIPTION IsNot Nothing Then
            txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        End If
        If dao.fields.MAX_PRIZE IsNot Nothing Then
            rnt_AMOUNT.Value = dao.fields.MAX_PRIZE
        Else
            rnt_AMOUNT.Value = 0
        End If
        
    End Sub

    Private Sub rnt_AMOUNT_TextChanged(sender As Object, e As EventArgs) Handles rnt_AMOUNT.TextChanged
        'If rnt_AMOUNT.Value <> 0 Then
        '    rnt_TAX_AMOUNT.Value = rnt_AMOUNT.Value * 0.01
        'End If
    End Sub

    Public Function chk_document() As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim digit As Integer = dao.Getdata_by_doc(txt_DOC_NUMBER.Text)
        If digit > 0 Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function

    Private Sub rnt_Amount2_TextChanged(sender As Object, e As EventArgs) Handles rnt_Amount2.TextChanged
        Dim dao_c As New DAO_MAS.TB_MAS_CUSTOMER
        dao_c.Getdata_by_CUSTOMER_ID(dd_CUSTOMER.SelectedValue)
        If Request.QueryString("bguse") IsNot Nothing Then
            If Request.QueryString("bguse") <> "3" Then
                cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                cal_net()
            End If
        Else
            cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
            cal_net()
        End If
    End Sub

    Private Sub rnt_Approve_TextChanged(sender As Object, e As EventArgs) Handles rnt_Approve.TextChanged
        Dim dao_c As New DAO_MAS.TB_MAS_CUSTOMER
        dao_c.Getdata_by_CUSTOMER_ID(dd_CUSTOMER.SelectedValue)

        If Request.QueryString("bguse") IsNot Nothing Then
            If Request.QueryString("bguse") <> "3" Then
                cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                cal_net()
            End If
        Else
            cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
            cal_net()
        End If
    End Sub

    Private Sub rnt_TAX_AMOUNT_TextChanged(sender As Object, e As EventArgs) Handles rnt_TAX_AMOUNT.TextChanged
        Dim dao_c As New DAO_MAS.TB_MAS_CUSTOMER
        dao_c.Getdata_by_CUSTOMER_ID(dd_CUSTOMER.SelectedValue)

        If Request.QueryString("bguse") IsNot Nothing Then
            If Request.QueryString("bguse") <> "3" Then
                cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                cal_net()
            End If
        Else
            cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
            cal_net()
        End If
    End Sub
    'Public Function get_cus_type() As Integer
    '    Dim cus_id As Integer = 0
    '    If dd_CUSTOMER_TYPE.SelectedValue <> "" Then
    '        cus_id = dd_CUSTOMER_TYPE.SelectedValue
    '    End If
    '    Return cus_id
    'End Function
    Public Sub cal_net()
        Dim amount As Double = 0
        Dim approve As Double = 0
        Dim tax As Double = 0
        Dim vat As Double = 0



        If rnt_Amount2.Value <> 0 Then
            amount = rnt_Amount2.Value
        End If
        If rnt_Approve.Value <> 0 Then
            approve = rnt_Approve.Value
        End If
        If rnt_TAX_AMOUNT.Value <> 0 Then
            tax = rnt_TAX_AMOUNT.Value
        End If
        If rnt_vat.Value <> 0 Then
            vat = rnt_vat.Value
        End If
        rnt_net_amount.Value = amount - (approve + tax)
    End Sub
    Public Sub cal_tax_by_customer_type(ByVal cus_type_id As Integer)
        Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
        dao.Getdata_by_CUSTOMER_TYPE_ID(cus_type_id)
        Dim amount_without_vat As Double = 0
        Dim vat As Double = 0
        Dim tax As Double = 0

        'If dao.fields.VAT IsNot Nothing Then


        'End If
        If dao.fields.VAT = 0.07 Then
            vat = rnt_Amount2.Value * (7 / 107)
            rnt_vat.Value = vat
            amount_without_vat = rnt_Amount2.Value - vat
        Else
            rnt_vat.Value = 0
            amount_without_vat = rnt_Amount2.Value
        End If

        If dao.fields.CAL_FLAG = 1 Then
           
            If rnt_Amount2.Value > 500 Then
                If dao.fields.TAX IsNot Nothing Then

                    tax = (amount_without_vat * CDec(dao.fields.TAX))
                    ' rnt_Approve.Value = tax
                    rnt_TAX_AMOUNT.Value = tax
                End If
            Else
                If dao.fields.TAX IsNot Nothing Then
                    ' tax = (amount_without_vat * CDec(dao.fields.TAX))
                    rnt_TAX_AMOUNT.Value = 0
                End If
            End If

        Else
            If dao.fields.TAX_TYPE = 5 Then
                If cus_type_id = 7 Then

                Else
                    If rnt_Amount2.Value > 10000 Then
                        If dao.fields.TAX IsNot Nothing Then

                            tax = (amount_without_vat * CDec(dao.fields.TAX))
                            ' rnt_Approve.Value = tax
                            rnt_TAX_AMOUNT.Value = tax
                        End If
                    Else
                        If dao.fields.TAX IsNot Nothing Then
                            rnt_TAX_AMOUNT.Value = 0
                        End If
                    End If
                End If

            ElseIf dao.fields.TAX_TYPE = 4 Then
                rnt_TAX_AMOUNT.Value = 0

            ElseIf dao.fields.TAX_TYPE = 1 Then
                If rnt_Amount2.Value > 500 Then
                    tax = (amount_without_vat * CDec(dao.fields.TAX))
                    rnt_TAX_AMOUNT.Value = tax
                Else
                    rnt_TAX_AMOUNT.Value = 0
                End If
            End If
            
        End If


        ' rnt_TAX_AMOUNT.Value = rnt_Amount2.Value * 0.01
    End Sub

    'Private Sub dd_CUSTOMER_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_CUSTOMER_TYPE.SelectedIndexChanged
    '    If Request.QueryString("bguse") IsNot Nothing Then
    '        If Request.QueryString("bguse") <> "3" Then
    '            cal_tax_by_customer_type(dd_CUSTOMER_TYPE.SelectedValue)
    '            cal_net()
    '        End If
    '    Else
    '        cal_tax_by_customer_type(dd_CUSTOMER_TYPE.SelectedValue)
    '        cal_net()
    '    End If

    '    'cal_tax_by_customer_type(dd_CUSTOMER_TYPE.SelectedValue)
    '    'cal_net()
    'End Sub

    Private Sub dd_CUSTOMER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_CUSTOMER.SelectedIndexChanged
        Dim dao_c As New DAO_MAS.TB_MAS_CUSTOMER
        dao_c.Getdata_by_CUSTOMER_ID(dd_CUSTOMER.SelectedValue)

        If Request.QueryString("bguse") IsNot Nothing Then
            If Request.QueryString("bguse") <> "3" Then
                cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                cal_net()
            End If
        Else
            cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
            cal_net()
        End If
    End Sub

    Public Function cal_balance(ByVal idhead As Integer) As Boolean
        Dim bool As Boolean = False
        Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao_sub As New BAO_BUDGET.DISBURSE_BUDGET
        Dim po_head_amount As Double = 0
        Dim disburse_amount As Double = 0
        Dim balance As Double = 0
        dao_po.Getdata_by_Disburse_id(idhead)
        If dao_po.fields.AMOUNT IsNot Nothing Then
            po_head_amount = dao_po.fields.AMOUNT
        End If
        disburse_amount = bao_sub.get_sub_po_amount(idhead)
        'balance = po_head_amount - disburse_amount
        'balance = balance + rnt_AMOUNT.Value
        Dim burse_sum As Double = 0
        burse_sum = disburse_amount + rnt_AMOUNT.Value

        If Math.Round(burse_sum, 2) <= Math.Round(po_head_amount, 2) Then
            bool = True
        Else
            bool = False
        End If

        Return bool
    End Function
End Class