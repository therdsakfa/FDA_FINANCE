Public Class UC_Disburse_Budget_DetailV2
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
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Dim _checkDate As String = ""

    Public Sub run_Query()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
        _checkDate = Request.QueryString("Chk")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        run_Query()

        If Not IsPostBack Then

            Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
            dao_dept.Getdata_by_DEPARTMENT_ID(Request.QueryString("dept"))

            If _bid = "" Then
                getdata_dept(dao_dept)
            End If

        End If

        If _checkDate = "" Then
            txt_dodate.Text = Date.Now.ToShortDateString
        End If

    End Sub

    Public Sub getdata_dept(ByRef dao As DAO_MAS.TB_MAS_DEPARTMENT)
        txt_DOC_NUMBER.Text = "สธ." + dao.fields.DEPARTMENT_CODE & "/"
    End Sub

    Public Sub set_data(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)

        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        Else
            dao.fields.DOC_DATE = Nothing
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        'dao.fields.BUDGET_ID = _bgid
        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text
        dao.fields.IS_APPROVE = False
        If txt_dodate.Text <> "" Then
            dao.fields.BILL_DATE = CDate(txt_dodate.Text)
        Else
            dao.fields.BILL_DATE = Nothing
        End If
        dao.fields.BUDGET_PLAN_ID = 0


    End Sub

    Public Sub set_data_re(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        dao.fields.IS_RECEIVE = True
    End Sub

    Public Sub get_data(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString()
        End If
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        If dao.fields.BILL_DATE IsNot Nothing Then
            txt_dodate.Text = CDate(dao.fields.BILL_DATE).ToShortDateString()
        End If

        'Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
        'txt_DOC_NUMBER.Text = dao_dept.fields.DEPARTMENT_CODE

    End Sub

    Public Sub set_amount()
        Dim dao_dpt As New DAO_MAS.TB_MAS_DEPARTMENT
        If Request.QueryString("dept") IsNot Nothing Then
            dao_dpt.Getdata_by_DEPARTMENT_ID(Request.QueryString("dept"))
        Else
            If _bid <> "" Then
                'Dim dao As New DAO_DISBURSE.TB_CERTIFICATE_ALL
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(_bid)
                dao_dpt.Getdata_by_DEPARTMENT_ID(dao.fields.DEPARTMENT_ID)
            End If

        End If
        Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        If Request.QueryString("bgid") IsNot Nothing Then
            dao_bg.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
            dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
        End If

        Dim uti_adjust As New BAO_BUDGET.Budget
        Dim adjust_amount As Double = uti_adjust.get_bg_adjust_detail_amount2(_bgyear, _bgid, _dept)
        Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App2(_bgid, _bgyear, _dept)

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

    'Private Sub txt_DOC_NUMBER_TextChanged(sender As Object, e As EventArgs) Handles txt_DOC_NUMBER.TextChanged
    '    Dim txt_DocNum As String = ""
    '    txt_DocNum = txt_DOC_NUMBER.Text

    '    Dim WS As New WS_BOOKING.Service1
    '    Dim dt As New DataTable

    '    dt = WS.GETDATA_BY_BOOKID(txt_DocNum).Tables(0)

    '    If dt.Rows.Count <> 0 Then
    '        For Each dr As DataRow In dt.Rows
    '            txt_DESCRIPTION.Text = dr("book_subject")
    '        Next
    '    Else
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูลในระบบสารบรรณ') ;", True)
    '        txt_DESCRIPTION.Text = ""
    '    End If

    'End Sub

End Class