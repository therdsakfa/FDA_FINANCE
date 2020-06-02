Public Class Frm_Report_R2_028
    Inherits System.Web.UI.Page

    Private _BgYear As Integer
    Private _dept As Integer = 0
    Public _Id As Integer = 0
    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Public Sub runQuery()
        _BgYear = Request.QueryString("bgyear")
        _dept = Request.QueryString("dept")
        _Id = Request.QueryString("id")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()

        If Not IsPostBack Then
            run_report()
        End If
    End Sub

    Public Sub run_report()
        ShowReport()
    End Sub

    Public Sub ShowReport()
        ReportViewer1.LocalReport.ReportPath = "Module02/Report/Frm_Report_R2_028.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()

        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA_DateTime", GetYearReport()))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA_DataHead", GetDataReport_Head()))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA_DataDeptHead", GetDataReport_HeadDept()))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_GetFDA_Detail", GetDataReport_Detail()))
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

    Public Function GetDataReport_Head() As DataTable

        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim dt As New DataTable
        Dim bao2 As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim dt2 As New DataTable

        dt = bao.get_data_deka_bill(_Id)

        dt.Columns.Add("New_BgGroup", GetType(String))
        dt.Columns.Add("New_BgGroupCode", GetType(String))

        For Each dr As DataRow In dt.Rows

            dt2 = bao2.get_data_deka_bill_group_bg(dr("ID"))

            For Each dr2 As DataRow In dt2.Rows
                dr("New_BgGroup") = dr2("Code")
                dr("New_BgGroupCode") = dr2("Name")
            Next

        Next

        Return dt

    End Function

    Public Function GetDataReport_HeadDept() As DataTable

        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim dt As New DataTable
        Dim bao2 As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim dt2 As New DataTable

        dt = bao.get_data_deka_bill(_Id)

        dt.Columns.Add("New_BgCodeDept", GetType(String))
        dt.Columns.Add("New_BgShortDept", GetType(String))

        For Each dr As DataRow In dt.Rows

            dt2 = bao2.get_data_deka_head_shortName(dr("ID"))

            For Each dr2 As DataRow In dt2.Rows
                dr("New_BgCodeDept") = dr2("DeptCode")
                dr("New_BgShortDept") = dr2("DeptName")
            Next

        Next

        Return dt

    End Function

    Public Function GetDataReport_Detail() As DataTable

        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim dt As New DataTable

        dt = bao.get_data_deka_bill_list(_Id)

        dt.Columns.Add("New_AMOUNT", GetType(Double))
        dt.Columns.Add("New_nVat", GetType(Double))
        dt.Columns.Add("New_AMOUNT_MONEY", GetType(Double))

        For Each dr As DataRow In dt.Rows

            If IsDBNull(dr("AMOUNT")) = False Then
                If dr("AMOUNT") <> 0 Then
                    dr("New_AMOUNT") = dr("AMOUNT")
                Else
                    dr("New_AMOUNT") = 0
                End If
            Else
                dr("New_AMOUNT") = 0
            End If

            If IsDBNull(dr("nVat")) = False Then
                If dr("nVat") <> 0 Then
                    dr("New_nVat") = dr("nVat")
                Else
                    dr("New_nVat") = 0
                End If
            Else
                dr("New_nVat") = 0
            End If

            If IsDBNull(dr("AMOUNT_MONEY")) = False Then
                If dr("AMOUNT_MONEY") <> 0 Then
                    dr("New_AMOUNT_MONEY") = dr("AMOUNT_MONEY")
                Else
                    dr("New_AMOUNT_MONEY") = 0
                End If
            Else
                dr("New_AMOUNT_MONEY") = 0
            End If

        Next

        Return dt

    End Function

End Class