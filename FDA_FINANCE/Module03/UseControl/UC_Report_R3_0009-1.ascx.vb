Public Class UC_Report_R3_0009_1
    Inherits System.Web.UI.UserControl

    Private _money_bank As Double
    Public Property money_bank() As Double
        Get
            Return _money_bank
        End Get
        Set(ByVal value As Double)
            _money_bank = value
        End Set
    End Property

    Private _money_coin As Double
    Public Property money_coin() As Double
        Get
            Return _money_coin
        End Get
        Set(ByVal value As Double)
            _money_coin = value
        End Set
    End Property

    Private _money_check As Double
    Public Property money_check() As Double
        Get
            Return _money_check
        End Get
        Set(ByVal value As Double)
            _money_check = value
        End Set
    End Property

    Private _check_count As Double
    Public Property check_count() As Double
        Get
            Return _check_count
        End Get
        Set(ByVal value As Double)
            _check_count = value
        End Set
    End Property

    Private _totalfromsystem As Double
    Public Property totalfromsystem() As Double
        Get
            Return _totalfromsystem
        End Get
        Set(ByVal value As Double)
            _totalfromsystem = value
        End Set
    End Property

    Private _bank_1 As String
    Public Property bank_1() As String
        Get
            Return _bank_1
        End Get
        Set(ByVal value As String)
            _bank_1 = value
        End Set
    End Property

    Private _bank_2 As String
    Public Property bank_2() As String
        Get
            Return _bank_2
        End Get
        Set(ByVal value As String)
            _bank_2 = value
        End Set
    End Property

    Private _bank_3 As String
    Public Property bank_3() As String
        Get
            Return _bank_3
        End Get
        Set(ByVal value As String)
            _bank_3 = value
        End Set
    End Property

    Private _usermoney As String
    Public Property usermoney() As String
        Get
            Return _usermoney
        End Get
        Set(ByVal value As String)
            _usermoney = value
        End Set
    End Property

    Private _usermoney_position As String
    Public Property usermoney_position() As String
        Get
            Return _usermoney_position
        End Get
        Set(ByVal value As String)
            _usermoney_position = value
        End Set
    End Property

    Private _userstore As String
    Public Property userstore() As String
        Get
            Return _userstore
        End Get
        Set(ByVal value As String)
            _userstore = value
        End Set
    End Property

    Private _userstore_position As String
    Public Property userstore_position() As String
        Get
            Return _userstore_position
        End Get
        Set(ByVal value As String)
            _userstore_position = value
        End Set
    End Property

    Private _boardname1 As String
    Public Property boardname1() As String
        Get
            Return _boardname1
        End Get
        Set(ByVal value As String)
            _boardname1 = value
        End Set
    End Property

    Private _boardposition_1 As String
    Public Property boardposition_1() As String
        Get
            Return _boardposition_1
        End Get
        Set(ByVal value As String)
            _boardposition_1 = value
        End Set
    End Property

    Private _boardname2 As String
    Public Property boardname2() As String
        Get
            Return _boardname2
        End Get
        Set(ByVal value As String)
            _boardname2 = value
        End Set
    End Property

    Private _boardposition_2 As String
    Public Property boardposition_2() As String
        Get
            Return _boardposition_2
        End Get
        Set(ByVal value As String)
            _boardposition_2 = value
        End Set
    End Property

    Private _boardname3 As String
    Public Property boardname3() As String
        Get
            Return _boardname3
        End Get
        Set(ByVal value As String)
            _boardname3 = value
        End Set
    End Property

    Private _boardposition_3 As String
    Public Property boardposition_3() As String
        Get
            Return _boardposition_3
        End Get
        Set(ByVal value As String)
            _boardposition_3 = value
        End Set
    End Property

    Private _datesign As String
    Public Property datesign() As String
        Get
            Return _datesign
        End Get
        Set(ByVal value As String)
            _datesign = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim amount As Double = Request.QueryString("Amount")
        Dim amount_margin As Double = Request.QueryString("Amount2")

        Dim bao As New BAO_BUDGET.Report
        Dim util As New BAO_BUDGET.MoneyExt
        lbl_dateselect.Text = Request.QueryString("Date")
        lbl_amount.Text = amount.ToString("N")
        lbl_moneytext.Text = util.NumberToThaiWord(amount)
        lbl_marginamount.Text = amount_margin.ToString("N")
        lbl_dateselect_2.Text = Request.QueryString("Date")

        If Not IsPostBack Then
            set_textbox()
        End If
    End Sub

    Public Sub set_textbox()
        txt_usermoney.Text = "(นางสาวกอบกุล ธรรมโชติกา)"
        usermoneyposition.Text = "นักวิชาการเงินและบัญชีชำนาญการ"
        txt_userstore.Text = "(นางสิริพรรณ กล่อมจิต)"
        userstoreposition.Text = "นักวิชาการเงินและบัญชีชำนาญการพิเศษ"
        txt_boardname1.Text = "(นายเบ็ญจรงค์ จำปานาค)"
        boardposition1.Text = "นักทรัพยากรบุคคลชำนาญการพิเศษ"
        txt_boardname2.Text = "(นางสาวพนิดา สุทธิประทีป)"
        boardposition2.Text = "นักจัดการงานทั่วไปชำนาญการ"
        txt_boardname3.Text = "(นางศรีวัย อินน้อย)"
        boardposition3.Text = "นักวิชาการพัสดุชำนาญการ"
    End Sub
    'Public Sub getdata()
    '    If moneybank.Text <> "" Then
    '        money_bank = moneybank.Text
    '    End If
    '    If moneycheck.Text <> "" Then
    '        money_check = moneycheck.Text
    '    End If
    '    If moneycoin.Text <> "" Then
    '        money_coin = moneycoin.Text
    '    End If
    '    If bank1.Text <> "" Then
    '        bank_1 = bank1.Text
    '    End If
    '    If bank2.Text <> "" Then
    '        bank_2 = bank1.Text
    '    End If
    '    If bank3.Text <> "" Then
    '        bank_3 = bank1.Text
    '    End If
    '    If txt_usermoney.Text <> "" Then
    '        usermoney = txt_usermoney.Text
    '    End If
    '    If usermoneyposition.Text <> "" Then
    '        usermoney_position = usermoneyposition.Text
    '    End If
    '    If txt_userstore.Text <> "" Then
    '        userstore = txt_userstore.Text
    '    End If
    '    If userstoreposition.Text <> "" Then
    '        userstore_position = userstoreposition.Text
    '    End If

    '    If txt_boardname1.Text <> "" Then
    '        boardname1 = txt_boardname1.Text
    '    End If
    '    If boardposition1.Text <> "" Then
    '        boardposition_1 = boardposition1.Text
    '    End If
    '    If txt_boardname2.Text <> "" Then
    '        boardname2 = txt_boardname2.Text
    '    End If
    '    If boardposition2.Text <> "" Then
    '        boardposition_2 = boardposition2.Text
    '    End If
    '    If txt_boardname3.Text <> "" Then
    '        boardname3 = txt_boardname3.Text
    '    End If
    '    If boardposition3.Text <> "" Then
    '        boardposition_3 = boardposition3.Text
    '    End If

    '    datesign = Request.QueryString("Date")

    '    'money_bank = moneybank.Text
    '    'money_check = moneycheck.Text
    '    'money_coin = moneycoin.Text
    '    'check_count = checkcount.Text
    '    'bank_1 = bank1.Text
    '    'bank_2 = bank2.Text
    '    'bank_3 = bank3.Text
    '    'usermoney = txt_usermoney.Text
    '    'usermoney_position = usermoneyposition.Text
    '    'userstore = txt_userstore.Text
    '    'userstore_position = userstoreposition.Text

    '    'boardname1 = txt_boardname1.Text
    '    'boardposition_1 = boardposition1.Text
    '    'boardname2 = txt_boardname2.Text
    '    'boardposition_2 = boardposition2.Text
    '    'boardname3 = txt_boardname3.Text
    '    'boardposition_3 = boardposition3.Text
    '    'datesign = Request.QueryString("Date")
    'End Sub

    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_REPORT_R3_009_1)

        If lbl_dateselect.Text <> "" Then
            dao.fields.REPORT_DATE = lbl_dateselect.Text
        End If
        If moneybank.Text <> "" Then
            dao.fields.MONEY_BANK = moneybank.Text
        End If
        If moneycoin.Text <> "" Then
            dao.fields.MONEY_COIN = moneycoin.Text
        End If
        If moneycheck.Text <> "" Then
            dao.fields.MONEY_CHECK = moneycheck.Text
        End If
        If checkcount.Text <> "" Then
            dao.fields.CHECK_COUNT = checkcount.Text
        End If
        If moneycoin.Text <> "" And moneycheck.Text <> "" And moneycheck.Text <> "" Then
            dao.fields.MONEY_TOTAL = CInt(moneybank.Text) + CInt(moneycoin.Text) + CInt(moneycheck.Text)
        End If
        If lbl_moneytext.Text <> "" Then
            dao.fields.MONEY_TOTAL_TEXT = lbl_moneytext.Text
        End If
        If bank1.Text <> "" Then
            dao.fields.BANK_1 = bank1.Text
        End If
        If bank2.Text <> "" Then
            dao.fields.BANK_2 = bank2.Text
        End If
        If bank1.Text <> "" Then
            dao.fields.BANK_3 = bank3.Text
        End If
        If txt_usermoney.Text <> "" Then
            dao.fields.USER_MONEY = txt_usermoney.Text
        End If
        If usermoneyposition.Text <> "" Then
            dao.fields.USER_MONEY_POSITION = usermoneyposition.Text
        End If
        If txt_userstore.Text <> "" Then
            dao.fields.USER_STORE = txt_userstore.Text
        End If
        If userstoreposition.Text <> "" Then
            dao.fields.USER_STORE_POSITION = userstoreposition.Text
        End If
        If txt_boardname1.Text <> "" Then
            dao.fields.BOARDNAME_1 = txt_boardname1.Text
        End If
        If boardposition1.Text <> "" Then
            dao.fields.BOARDPOSITION_1 = boardposition1.Text
        End If
        If txt_boardname1.Text <> "" Then
            dao.fields.BOARDNAME_2 = txt_boardname2.Text
        End If
        If boardposition2.Text <> "" Then
            dao.fields.BOARDPOSITION_2 = boardposition2.Text
        End If
        If txt_boardname3.Text <> "" Then
            dao.fields.BOARDNAME_3 = txt_boardname3.Text
        End If
        If boardposition3.Text <> "" Then
            dao.fields.BOARDPOSITION_3 = boardposition3.Text
        End If

        If lbl_dateselect_2.Text <> "" Then
            dao.fields.EDIT_DATE = DateValue(Now)
        End If

        dao.fields.MONEY_TOTAL = CDbl(Request.QueryString("Amount2"))
    End Sub

    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_REPORT_R3_009_1)
        lbl_dateselect.Text = dao.fields.REPORT_DATE
        moneybank.Text = dao.fields.MONEY_BANK
        moneycoin.Text = dao.fields.MONEY_COIN
        moneycheck.Text = dao.fields.MONEY_CHECK
        checkcount.Text = dao.fields.CHECK_COUNT
        dao.fields.MONEY_TOTAL = CDbl(Request.QueryString("Amount2"))
        lbl_moneytext.Text = dao.fields.MONEY_TOTAL_TEXT
        bank1.Text = dao.fields.BANK_1
        bank2.Text = dao.fields.BANK_2
        bank3.Text = dao.fields.BANK_3
        txt_usermoney.Text = dao.fields.USER_MONEY
        usermoneyposition.Text = dao.fields.USER_MONEY_POSITION
        txt_userstore.Text = dao.fields.USER_STORE
        userstoreposition.Text = dao.fields.USER_STORE_POSITION
        txt_boardname1.Text = dao.fields.BOARDNAME_1
        boardposition1.Text = dao.fields.BOARDPOSITION_1
        txt_boardname2.Text = dao.fields.BOARDNAME_2
        boardposition2.Text = dao.fields.BOARDPOSITION_2
        txt_boardname3.Text = dao.fields.BOARDNAME_3
        boardposition3.Text = dao.fields.BOARDPOSITION_3
        lbl_dateselect_2.Text = dao.fields.EDIT_DATE
    End Sub

End Class