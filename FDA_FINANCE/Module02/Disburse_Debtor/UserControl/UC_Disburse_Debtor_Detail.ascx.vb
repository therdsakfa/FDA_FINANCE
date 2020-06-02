Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Debtor_Detail
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
    Private _bg_use As Integer
    Public Property bg_use() As Integer
        Get
            Return _bg_use
        End Get
        Set(ByVal value As Integer)
            _bg_use = value
        End Set
    End Property
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
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
    Public bgyear As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim dao_user As New DAO_USER.TB_tbl_USER
        'dao_user.Getdata_by_AD_NAME(NameUserAD())
        If is_insert = False Then
            ' If dept = 12 Then
            Panel2.Style.Add("Display", "block")
            'Else

            'End If
            'If dao_user.fields.PERMISSION_ID = "1" Then
            '    Panel2.Style.Add("Display", "block")
            'ElseIf dao_user.fields.PERMISSION_ID = "2" Then
            '    Panel2.Style.Add("Display", "none")
            'Else
            '    Panel2.Style.Add("Display", "none")
            'End If
        Else
            Panel2.Style.Add("Display", "none")
        End If
        If Not IsPostBack Then


            Dim bg As Integer
            Dim dao As New DAO_MAS.TB_BUDGET_PLAN
            Dim dao_out As New DAO_MAS.TB_MAS_MONEY_TYPE
            Dim bgid As String = ""

            bgid = Request.QueryString("bgid")
            bgyear = Request.QueryString("bgYear")
            If Request.QueryString("bid") <> "" Then
                Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
                dao_debtor.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                bgyear = dao_debtor.fields.BUDGET_YEAR
            End If
            If bgid <> "" Then
                If bgid <> "sup" And Request.QueryString("bguse") <> "3" Then
                    ddl_GL.Style.Add("display", "block")
                    lb_paylist.Style.Add("display", "block")
                    dao.Getdata_by_BUDGET_PLAN_ID(bgid)
                    lb_Budget_Plan.Text = dao.fields.BUDGET_DESCRIPTION

                    Dim uti_adjust As New Utility_other()
                    Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
                    Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bgid, bgyear)
                    Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App(bgid, bgyear)
                    lb_Amount.Text = (adjust_amount - disburse_app).ToString("N")

                    lb_paylist.Style.Add("display", "block")
                    dao.Getdata_by_BUDGET_PLAN_ID(bgid)
                    lb_budget.Text = dao.fields.BUDGET_DESCRIPTION

                    Dim dao_adjust As New DAO_BUDGET.TB_BUDGET_ADJUST
                    dao_adjust.Getdata_by_BUDGET_PLAN_ID(bgid)

                    If dao_adjust.fields.DEPARTMENT_ID IsNot Nothing Then
                        Dim dao_dpt As New DAO_MAS.TB_MAS_DEPARTMENT
                        dao_dpt.Getdata_by_DEPARTMENT_ID(dao_adjust.fields.DEPARTMENT_ID)
                        lb_dept.Text = dao_dpt.fields.DEPARTMENT_DESCRIPTION
                    End If



                    Try
                        Dim dao_act As New DAO_MAS.TB_BUDGET_PLAN
                        dao_act.Getdata_by_BUDGET_PLAN_ID(dao.fields.BUDGET_CHILD_ID)
                        Dim dao_act2 As New DAO_MAS.TB_BUDGET_PLAN
                        dao_act2.Getdata_by_BUDGET_PLAN_ID(dao_act.fields.BUDGET_CHILD_ID)

                        lb_activity.Text = dao_act2.fields.BUDGET_DESCRIPTION
                    Catch ex As Exception

                    End Try

                    Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
                    Try
                        dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao.fields.BUDGET_CHILD_ID)
                    Catch ex As Exception

                    End Try
                    Try
                        lb_project_name.Text = dao_head_bg.fields.BUDGET_DESCRIPTION
                    Catch ex As Exception
                        lb_project_name.Text = "-"
                    End Try

                    Dim bao_debt_app As New BAO_BUDGET.Budget
                    Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(bgid, bgyear, dept)
                    lb_Amount.Text = (adjust_amount - disburse_app).ToString("N")
                    lb_adjust_amount.Text = adjust_amount.ToString("N")

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
                ElseIf bgid = "sup" Then
                    lb_Budget_Plan.Text = "งบสนับสนุนกรม"
                    ddl_GL.Style.Add("display", "none")
                    lb_paylist.Style.Add("display", "none")
                ElseIf Request.QueryString("bguse") = "3" Then
                    dao_out.Getdata_by_MONEY_TYPE_ID(bgid)
                    lb_Budget_Plan.Text = dao_out.fields.MONEY_TYPE_DESCRIPTION
                    ddl_GL.Style.Add("display", "none")
                    lb_paylist.Style.Add("display", "none")
                End If
            End If
            'Dim bao_user As New BAO_BUDGET.MASS
            'Dim dt_user As DataTable = bao_user.get_user()
        End If

        If Request.QueryString("bid") <> "" Then
            Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            dao_bill.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
            dao_detail.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
            Dim playlist As Integer = 0
            If dao_bill.fields.PAYLIST_ID IsNot Nothing Then
                playlist = dao_bill.fields.PAYLIST_ID
            End If

            If dao_detail.fields.DEBTOR_BILL_ID IsNot Nothing Then
                Dim uti_adjust As New Utility_other()
                Dim bao_debt_app As New BAO_BUDGET.Budget
                Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(dao_bill.fields.BUDGET_PLAN_ID, dao_bill.fields.BUDGET_YEAR)
                Dim disburse_app As Double = uti_adjust.getAdjust_Appr_Amount(dao_bill.fields.BUDGET_PLAN_ID, dao_bill.fields.DEPARTMENT_ID, dao_bill.fields.BUDGET_YEAR, "True")
                Dim debtor_app As Double = bao_debt_app.get_Adjust_debt_App_Amount(dao_bill.fields.BUDGET_PLAN_ID, bgyear, dao_bill.fields.DEPARTMENT_ID)
                lb_Amount.Text = ((adjust_amount + CDbl(dao_detail.fields.AMOUNT)) - (disburse_app + debtor_app)).ToString("N")


            End If


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
    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao_gl.get_GL()

        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub


    Public Sub set_date()
        ' txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_Bill_RECIEVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    Public Sub set_date_receive()
        txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_Bill_RECIEVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
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
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL, ByVal userAD As String)
        Dim bg As Integer
        Dim bguse As Integer
        Dim bgyear As Integer
        Dim paylist As String = "0"
        If Request.QueryString("bgid") IsNot Nothing Then
            If Request.QueryString("bguse") <> "3" Then
                bg = Request.QueryString("bgid")
                bguse = bg_use
                bgyear = BudgetYear

                paylist = ddl_GL.SelectedValue
            ElseIf Request.QueryString("bguse") = "3" Then
                bg = Request.QueryString("bgid")
                bguse = 3
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
        If Request.QueryString("bgyear") IsNot Nothing Then
            bgyear = Request.QueryString("bgyear")
        End If
        ' bgid=out

        If txt_Bill_RECIEVE_DATE.Text <> "" Then
            dao.fields.Bill_RECIEVE_DATE = CDate(txt_Bill_RECIEVE_DATE.Text)
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BUDGET_PLAN_ID = bg
        dao.fields.BUDGET_USE_ID = bguse
        dao.fields.BUDGET_YEAR = bgyear
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        If txt_BILL_DATE.Text <> "" Then
            dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        Else
            dao.fields.BILL_DATE = Nothing
        End If
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PAYLIST_ID = paylist
        dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        dao.fields.USER_AD = userAD
        dao.fields.DEPARTMENT_ID = dept
        dao.fields.USER_ID = dd_CUSTOMER.SelectedValue
        
        dao.fields.GL_ID = paylist
    End Sub
    Public Sub update(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL, ByVal userAD As String)
        Dim paylist As String = "0"

        paylist = ddl_GL.SelectedValue
        If txt_Bill_RECIEVE_DATE.Text <> "" Then
            dao.fields.Bill_RECIEVE_DATE = CDate(txt_Bill_RECIEVE_DATE.Text)
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        If txt_BILL_DATE.Text <> "" Then
            dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        Else
            dao.fields.BILL_DATE = Nothing
        End If
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.PAYLIST_ID = paylist
        dao.fields.GL_ID = paylist
        'dao.fields.IS_APPROVE = False
        dao.fields.IS_DEPARTMENT = False
        dao.fields.USER_AD = userAD
        ' dao.fields.DEPARTMENT_ID = dept
        dao.fields.USER_ID = dd_CUSTOMER.SelectedValue
       
    End Sub
    Public Sub insert_detail(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL, id_head As Integer)
        dao.fields.AMOUNT = rnt_AMOUNT.Value
        dao.fields.DEBTOR_BILL_ID = id_head
    End Sub
    Public Sub insert_detail_margin(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)
        dao.fields.AMOUNT = rnt_AMOUNT.Value
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        dao_detail.Getdata_by_DEBTOR_BILL_ID(dao.fields.DEBTOR_BILL_ID)
        If dao.fields.Bill_RECIEVE_DATE IsNot Nothing Then
            txt_Bill_RECIEVE_DATE.Text = dao.fields.Bill_RECIEVE_DATE
        End If
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = dao.fields.DOC_DATE
        End If
        txt_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
        If dao.fields.BILL_DATE Is Nothing Then
            txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
        Else
            txt_BILL_DATE.Text = dao.fields.BILL_DATE
        End If
        'dd_Paylist.SelectedValue = dao.fields.PAYLIST_DESCRIPTION
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        rnt_AMOUNT.Value = dao_detail.fields.AMOUNT
        'dd_CUSTOMER_TYPE.SelectedValue = dao.fields.CUSTOMER_TYPE_ID

        Try
            dd_CUSTOMER.DropDownSelectData(dao.fields.USER_ID)
        Catch ex As Exception

        End Try
        Try
            ddl_GL.DropDownSelectData(dao.fields.GL_ID)
        Catch ex As Exception

        End Try
    End Sub
    Public Function chk_document() As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim digit As Integer = dao.Getdata_by_doc(txt_DOC_NUMBER.Text)
        If digit > 0 Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function
End Class