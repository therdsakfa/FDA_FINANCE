Imports System.Threading
Imports System.Globalization
Public Class UC_Report_SelectDate_Between1
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' Property วันที่เริ่ม
    ''' </summary>
    ''' <remarks></remarks>
    Private _dateBegin As Date
    Public Property dateBegin() As Date
        Get
            Return _dateBegin
        End Get
        Set(ByVal value As Date)
            _dateBegin = value
        End Set
    End Property
    ''' <summary>
    ''' Property วันที่สิ้นสุด
    ''' </summary>
    ''' <remarks></remarks>
    Private _dateEnd As Date
    Public Property dateEnd() As Date
        Get
            Return _dateEnd
        End Get
        Set(ByVal value As Date)
            _dateEnd = value
        End Set
    End Property
    Private _is_early As Boolean
    Public Property is_early() As Boolean
        Get
            Return _is_early
        End Get
        Set(ByVal value As Boolean)
            _is_early = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
            ' Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) 'เดือน ณ ขณะนั้น
            txt_DateEnd.Text = System.DateTime.Now.ToShortDateString() 'วันที่ ที่ใช้งาน ณ ขนะนั้น
            'txt_DateBegin.Text = thisMonth.AddMonths(0).ToShortDateString() 'วันที่ 1 ของเดือนที่ใช้งาน ณ ขนะนั้น
            'Dim uti_month As New Report_Utility

            '' Dim month_num As Integer = uti_month.get_budget_month(DateTime.Now.Month)
            'Dim month_num As Integer = DateTime.Now.Month
            'Dim str_year As String
            'If month_num >= 9 Then
            '    str_year = (DateTime.Now.Year + 1)
            'Else
            '    str_year = DateTime.Now.Year
            'End If

            Dim bgyear As Integer = 0
            If _is_early = False Then
                If Month(System.DateTime.Now) <= 9 Then
                    txt_DateBegin.Text = "01/10/" & CInt(System.DateTime.Today.ToString("yyyy")) - 1
                Else
                    txt_DateBegin.Text = "01/10/" & CInt(System.DateTime.Today.ToString("yyyy"))
                End If
            Else
               txt_DateBegin.Text = System.DateTime.Now.ToShortDateString()
            End If
            

            'txt_DateBegin.Text = System.DateTime.Now.ToShortDateString()
            'txt_DateBegin.Text = "01/10/" & System.DateTime.Today.ToString("yyyy")

        End If
    End Sub

    Public Sub set_date()
        Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
        txt_DateEnd.Text = System.DateTime.Now.ToShortDateString()
        Dim bgyear As Integer = 0
        If Month(System.DateTime.Now) <= 9 Then
            txt_DateBegin.Text = "01/10/" & CInt(System.DateTime.Today.ToString("yyyy")) - 1
        Else
            txt_DateBegin.Text = "01/10/" & CInt(System.DateTime.Today.ToString("yyyy"))
        End If
    End Sub
    ''' <summary>
    ''' Add Property วันที่เริ่ม, วันที่สิ้นสุด
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getDateSelect()
        dateBegin = CDate(txt_DateBegin.Text) 'ใส่ค่าวันที่เริ่ม
        dateEnd = CDate(txt_DateEnd.Text) 'ใส่ค่าวันที่สิ้นสุด
    End Sub
    Public Sub BindData()

    End Sub
End Class