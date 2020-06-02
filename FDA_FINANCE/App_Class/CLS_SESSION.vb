Public Class CLS_SESSION
    ''' <summary>
    ''' TOKEN ที่ได้จาก openID
    ''' </summary>
    ''' <remarks></remarks>
    Private _TOKEN As String
    Public Property TOKEN() As String
        Get
            Return _TOKEN
        End Get
        Set(ByVal value As String)
            _TOKEN = value
        End Set
    End Property
    ''' <summary>
    ''' SYSTEN_ID ที่ได้จาก TOKEN
    ''' </summary>
    ''' <remarks></remarks>
    Private _SYSTEN_ID As String
    Public Property SYSTEM_ID() As String
        Get
            Return _SYSTEN_ID
        End Get
        Set(ByVal value As String)
            _SYSTEN_ID = value
        End Set
    End Property
    ''' <summary>
    ''' CITIZEN_ID คนlogin ที่ได้จาก TOKEN
    ''' </summary>
    ''' <remarks></remarks>
    Private _CITIZEN_ID As String
    Public Property CITIZEN_ID() As String
        Get
            Return _CITIZEN_ID
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID = value
        End Set
    End Property
    ''' <summary>
    ''' CITIZEN_ID ผู้ประกอบการ ที่ได้จาก TOKEN
    ''' </summary>
    ''' <remarks></remarks>
    Private _CITIZEN_ID_AUTHORIZE As String
    Public Property CITIZEN_ID_AUTHORIZE() As String
        Get
            Return _CITIZEN_ID_AUTHORIZE
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID_AUTHORIZE = value
        End Set
    End Property

    ''' <summary>
    ''' LCNSID ผู้ประกอบการ  ที่ได้จาก CITIZEN_ID_AUTHORIZE
    ''' </summary>
    ''' <remarks></remarks>
    Private _LCNSID_CUSTOMER As Integer
    Public Property LCNSID_CUSTOMER() As Integer
        Get
            Return _LCNSID_CUSTOMER
        End Get
        Set(ByVal value As Integer)
            _LCNSID_CUSTOMER = value
        End Set
    End Property
    ''' <summary>
    '''  THANM ผู้ประกอบการ  ที่ได้จาก CITIZEN_ID_AUTHORIZE
    ''' </summary>
    ''' <remarks></remarks>
    Private _THANM_CUSTOMER As String
    Public Property THANM_CUSTOMER() As String
        Get
            Return _THANM_CUSTOMER
        End Get
        Set(ByVal value As String)
            _THANM_CUSTOMER = value
        End Set
    End Property
    ''' <summary>
    ''' LCNSID ผู้คนlogin   ที่ได้จาก CITIZEN_ID
    ''' </summary>
    ''' <remarks></remarks>
    Private _LCNSID As Integer
    Public Property LCNSID() As Integer
        Get
            Return _LCNSID
        End Get
        Set(ByVal value As Integer)
            _LCNSID = value
        End Set
    End Property
    ''' <summary>
    ''' THANM ผู้คนlogin   ที่ได้จาก CITIZEN_ID
    ''' </summary>
    ''' <remarks></remarks>
    Private _THANM As String
    Public Property THANM() As String
        Get
            Return _THANM
        End Get
        Set(ByVal value As String)
            _THANM = value
        End Set
    End Property

    ''' <summary>
    ''' GROUPS ที่ได้จาก TOKEN
    ''' </summary>
    ''' <remarks></remarks>
    Private _GROUPS As String
    Public Property GROUPS() As String
        Get
            Return _GROUPS
        End Get
        Set(ByVal value As String)
            _GROUPS = value
        End Set
    End Property
    ''' <summary>
    ''' PVCODE ที่ได้จาก TOKEN
    ''' </summary>
    ''' <remarks></remarks>
    Private _PVCODE As String
    Public Property PVCODE() As String
        Get
            Return _PVCODE
        End Get
        Set(ByVal value As String)
            _PVCODE = value
        End Set
    End Property

    Private _PDFNAME As String
    Public Property PDFNAME() As String
        Get
            Return _PDFNAME
        End Get
        Set(ByVal value As String)
            _PDFNAME = value
        End Set
    End Property

    Private _TRANSECTION_UP_ID As String
    Public Property TRANSECTION_UP_ID() As String
        Get
            Return _TRANSECTION_UP_ID
        End Get
        Set(ByVal value As String)
            _TRANSECTION_UP_ID = value
        End Set
    End Property


    Private _IDA As String
    Public Property IDA() As String
        Get
            Return _IDA
        End Get
        Set(ByVal value As String)
            _IDA = value
        End Set
    End Property

    Private _FILENAME_PDF As String
    Public Property FILENAME_PDF() As String
        Get
            Return _FILENAME_PDF
        End Get
        Set(ByVal value As String)
            _FILENAME_PDF = value
        End Set
    End Property

    Private _LCNNO As String
    Public Property LCNNO() As String
        Get
            Return _LCNNO
        End Get
        Set(ByVal value As String)
            _LCNNO = value
        End Set
    End Property

    Private _STAFFTYPE As String
    Public Property STAFFTYPE() As String
        Get
            Return _STAFFTYPE
        End Get
        Set(ByVal value As String)
            _STAFFTYPE = value
        End Set
    End Property
    Private _ID_MENU As String
    Public Property ID_MENU() As String
        Get
            Return _ID_MENU
        End Get
        Set(ByVal value As String)
            _ID_MENU = value
        End Set
    End Property


End Class
