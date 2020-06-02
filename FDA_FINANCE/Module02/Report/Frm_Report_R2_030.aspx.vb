Public Class Frm_Report_R2_030
    Inherits System.Web.UI.Page

    Private _BgYear As Integer

    Public Sub runQuery()
        _BgYear = 2560
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()

        If Not IsPostBack Then
            run_report()
        End If
    End Sub

    Public Sub run_report()
        ShowReport()
    End Sub

    Public Sub ShowReport()
        ReportViewer1.LocalReport.ReportPath = "Module02/Report/Frm_Report_R2_030.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()

        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA_DateTime", GetYearReport()))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA_Data", GetDataReport()))

        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.DataBind()
    End Sub


    Public Function GetYearReport() As DataTable

        Dim dt As New DataTable

        dt.Columns.Add("BgDate", GetType(String))
        dt.Columns.Add("BgTime", GetType(String))

        Dim dr As DataRow = dt.NewRow

        Dim BgDate As String = ""
        Dim BgTime As String = ""

        Dim _datetime As DateTime
        _datetime = DateTime.Now

        Dim _day As Integer = 0
        Dim _month As Integer = 0
        Dim _year As Integer = 0
        Dim _yyear As Integer = 0

        Dim _Hour As Double = 0
        Dim _min As Double = 0

        Dim monthstring As String = ""

        _day = Day(_datetime)
        _month = Month(_datetime)
        _year = Year(_datetime)
        _Hour = Hour(_datetime)
        _min = Minute(_datetime)

        If _year < 2500 Then
            _yyear = _year + 543
        Else
            _yyear = _year
        End If

        If _month = 1 Then
            monthstring = "มกราคม"
        ElseIf _month = 2 Then
            monthstring = "กุุมภาพันธ์"
        ElseIf _month = 3 Then
            monthstring = "มีนาคม"
        ElseIf _month = 4 Then
            monthstring = "เมษายน"
        ElseIf _month = 5 Then
            monthstring = "พฤษภาคม"
        ElseIf _month = 6 Then
            monthstring = "มิถุนายน"
        ElseIf _month = 7 Then
            monthstring = "กรกฎาคม"
        ElseIf _month = 8 Then
            monthstring = "สิงหาคม"
        ElseIf _month = 9 Then
            monthstring = "กันยายน"
        ElseIf _month = 10 Then
            monthstring = "ตุลาคม"
        ElseIf _month = 11 Then
            monthstring = "พฤศจิกายน"
        ElseIf _month = 12 Then
            monthstring = "ธันวาคม"
        End If

        BgDate = _day & " " & monthstring & " " & _yyear
        dr("BgDate") = BgDate

        dr("BgTime") = _Hour & " : " & _min & " น."
        dt.Rows.Add(dr)

        Return dt

    End Function

    Public Function GetDataReport() As DataTable

        Dim dt As New DataTable

        Return dt
    End Function

End Class