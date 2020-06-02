Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Welfare_Detail
    Inherits System.Web.UI.UserControl

    Private _BillType As Integer
    Public Property BillType() As Integer
        Get
            Return _BillType
        End Get
        Set(ByVal value As Integer)
            _BillType = value
        End Set
    End Property
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
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

        bgyear = Request.QueryString("bgYear")
        Dim bgid As String = ""
        bgid = Request.QueryString("bgid")
        'Dim dao_user As New DAO_USER.TB_tbl_USER
        'dao_user.Getdata_by_AD_NAME(NameUserAD())
        Dim dept As String = Request.QueryString("dept")

        If is_insert = False Then
            If dept = 12 Then
                Panel2.Style.Add("Display", "block")
            Else
                Panel2.Style.Add("Display", "none")
            End If
            'If dao_user.fields.PERMISSION_ID = "1" Then
            '    Panel2.Style.Add("Display", "block")
            'ElseIf dao_user.fields.PERMISSION_ID = "2" Then
            '    Panel2.Style.Add("Display", "none")
            'End If
        Else
            Panel2.Style.Add("Display", "none")
        End If

        If Not IsPostBack Then
            ' bind_dl_User()
            bind_customer()
            bind_dd_gl()
            'dl_User.Items.Insert(0, New ListItem("--ชื่อ-นามสกุล--", ""))

            dd_CUSTOMER.Items.Insert(0, New ListItem("--ชื่อ-นามสกุล--", ""))


            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao_cure As New DAO_DISBURSE.TB_CURE_STUDY
                dao_cure.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
                'If dao_cure.fields.MONTH_DIGIT IsNot Nothing Then
                '    dd_month.DropDownSelectData(dao_cure.fields.MONTH_DIGIT)
                'End If
            End If

            'Dim dao_node As New DAO_MAS.TB_BUDGET_PLAN_NODE
            'dao_node.Getdata_by_Head_ID(bgid, bgyear)
            'Dim rtv_bg_plan As New RadTreeView
            'rtv_bg_plan = DirectCast(rcb_budget.Items(0).FindControl("rtv_bg_plan"), RadTreeView)
            'For Each dao_node.fields In dao_node.datas
            '    Dim node As New RadTreeNode

            '    node.Text = getDatatextfield(dao_node.fields.CHILD_ID)
            '    node.Value = dao_node.fields.CHILD_ID
            '    rtv_bg_plan.Nodes.Add(node)
            '    bindnode_bg(node.Nodes, dao_node.fields.CHILD_ID)

            'Next

        End If
    End Sub

    Public Sub set_date()
        txt_BILL_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_Bill_RECIEVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub

    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao_gl.get_GL_Welfare()

        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub

    Public Sub bind_customer()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_customer_gov()

        dd_CUSTOMER.DataSource = dt
        dd_CUSTOMER.DataBind()
        If Request.QueryString("bid") IsNot Nothing Then
            Dim dao_cure As New DAO_DISBURSE.TB_CURE_STUDY
            dao_cure.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
            If dao_cure.fields.USER_ID IsNot Nothing Then
                dd_CUSTOMER.DropDownSelectData(dao_cure.fields.USER_ID)

            End If

        End If

    End Sub

    Public Sub bind_dl_User()
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.USER
            Dim dt As DataTable = bao.get_NAME_AD_NAME()
            'Dim dr As DataRow = dt.NewRow
            'dr("ID") = 0
            'dr("NAME") = "--ชื่อ-นามสกุล--"
            'dt.Rows.Add(dr)
            Dim dv As DataView = dt.DefaultView
            dv.Sort = " NAME ASC,ID ASC"
            dt = dv.ToTable



            'dl_User.DataSource = dt
            'dl_User.DataTextField = "NAME"
            'dl_User.DataValueField = "ID"

            'dl_User.DataBind()

            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao_cure As New DAO_DISBURSE.TB_CURE_STUDY
                dao_cure.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
                If dao_cure.fields.USER_ID IsNot Nothing Then
                    'dl_User.DropDownSelectData(dao_cure.fields.USER_ID)

                End If

            End If

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

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY, ByVal userAD As String)

        dao.fields.AMOUNT = rnt_AMOUNT.Value
        If txt_BILL_DATE.Text <> "" Then
            dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        End If
        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        dao.fields.BILL_TYPE_ID = BillType
        dao.fields.BUDGET_YEAR = BudgetYear
        dao.fields.DESCRIPTION = ddl_GL.SelectedValue 'txt_DESCRIPTION.Text
        dao.fields.AMOUNT_FOR = txt_For.Text
        'dao.fields.SEMESTER = txt_Semester.Text
        'dao.fields.YEAR_STUDY = txt_YearStudy.Text
        'If dl_User.SelectedValue <> "" Then
        '    dao.fields.USER_ID = dl_User.SelectedValue
        'End If
        If dd_CUSTOMER.SelectedValue <> "" Then
            dao.fields.USER_ID = dd_CUSTOMER.SelectedValue
        End If

        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If

        If txt_Bill_RECIEVE_DATE.Text <> "" Then
            dao.fields.DOC_RECEIVE_DATE = CDate(txt_Bill_RECIEVE_DATE.Text)
        End If

        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.IS_APPROVE = False
        dao.fields.USER_AD = userAD
        'dao.fields.MONTH_DIGIT = dd_month.SelectedValue
        dao.fields.GROUP_ID = Request.QueryString("g")
        dao.fields.STATUS_ID = Request.QueryString("stat")

    End Sub

    'Public Sub update_welfare(ByRef dao As DAO_WELFARE.TB_ALL_WELFARE_BILL)
    '    dao.fields.MONTH_LIVE = ""
    'End Sub

    Public Sub update(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY, ByVal userAD As String)

        dao.fields.AMOUNT = rnt_AMOUNT.Value

        If txt_BILL_DATE.Text <> "" Then
            dao.fields.BILL_DATE = CDate(txt_BILL_DATE.Text)
        End If

        dao.fields.BILL_NUMBER = txt_BILL_NUMBER.Text
        dao.fields.DESCRIPTION = ddl_GL.SelectedValue 'txt_DESCRIPTION.Text
        dao.fields.AMOUNT_FOR = txt_For.Text
        'dao.fields.SEMESTER = txt_Semester.Text
        'dao.fields.YEAR_STUDY = txt_YearStudy.Text

        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        If txt_Bill_RECIEVE_DATE.Text <> "" Then
            dao.fields.DOC_RECEIVE_DATE = CDate(txt_Bill_RECIEVE_DATE.Text)
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.USER_AD = userAD
        If dd_CUSTOMER.SelectedValue <> "" Then
            dao.fields.USER_ID = dd_CUSTOMER.SelectedValue
        End If
        ' dao.fields.MONTH_DIGIT = dd_month.SelectedValue
    End Sub

    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)
        rnt_AMOUNT.Value = dao.fields.AMOUNT
        If dao.fields.BILL_DATE IsNot Nothing Then
            txt_BILL_DATE.Text = CDate(dao.fields.BILL_DATE).ToShortDateString
        End If
        txt_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
        'txt_DESCRIPTION.Text = dao.fields.DESCRIPTION

        ddl_GL.SelectedValue = dao.fields.DESCRIPTION

        txt_For.Text = dao.fields.AMOUNT_FOR
        'txt_Semester.Text = dao.fields.SEMESTER
        'txt_YearStudy.Text = dao.fields.YEAR_STUDY


        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString
        End If
        If dao.fields.DOC_RECEIVE_DATE IsNot Nothing Then
            txt_Bill_RECIEVE_DATE.Text = CDate(dao.fields.DOC_RECEIVE_DATE).ToShortDateString
        End If
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER

    End Sub

End Class