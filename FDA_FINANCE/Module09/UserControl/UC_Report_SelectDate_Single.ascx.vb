Public Class UC_Report_SelectDate_Single
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' Property วันที่เลือก
    ''' </summary>
    ''' <remarks></remarks>
    Private _dateSelect As Date
    Public Property dateSelect() As Date
        Get
            Return _dateSelect
        End Get
        Set(ByVal value As Date)
            _dateSelect = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_DateSelect.Text = System.DateTime.Now.ToShortDateString() 'วันที่ ที่ใช้งาน ณ ขนะนั้น
        End If
    End Sub
    ''' <summary>
    ''' Add Property วันที่เลือก
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getDateSelect()
        If txt_DateSelect.Text <> "" Then
            dateSelect = txt_DateSelect.Text 'ใส่ค่าวันที่เริ่ม
        Else
            dateSelect = System.DateTime.Now.ToShortDateString()
        End If

    End Sub
    Public Sub set_date()
        txt_DateSelect.Text = System.DateTime.Now.ToShortDateString() 'วันที่ ที่ใช้งาน ณ ขนะนั้น
    End Sub
End Class