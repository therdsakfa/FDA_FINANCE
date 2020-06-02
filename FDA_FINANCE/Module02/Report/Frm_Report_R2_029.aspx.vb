Public Class Frm_Report_R2_029
    Inherits System.Web.UI.Page

    Private _BgYear As Integer
    Private _id As Integer = 0
    Private _bgid As Integer = 0
    Private _dept As Integer = 0
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
        _id = Request.QueryString("id")
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
        ReportViewer1.LocalReport.ReportPath = "Module02/Report/Frm_Report_R2_029.rdlc"
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
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET()


        dt = bao.get_relate_det_by_year_id(_id)
        'If _ispo = True Then
        '    dt = bao.getGF_bg_bill_sub_PO_bt_group_v2_Report(_BudgetUseID, _BgYear, _stat - 1, _g, _bt)
        'Else
        '    If _is_rebill = True Then
        '        dt = bao.getGF_bg_bill_sub_PO_bt_group_v2_report2(_BudgetUseID, _BgYear, _stat - 1, _g, _bt)
        '    ElseIf _is_no_rebill = True Then
        '        dt = bao.getGF_bg_bill_bt_group_no_rebill_report(_BudgetUseID, _BgYear, _stat - 1, _g, _bt)
        '    Else
        '        dt = bao.getGF_bg_bill_bt_group_V2_report(_BudgetUseID, _BgYear, _ispo, _stat - 1, _g, _bt)
        '    End If

        'End If

        dt.Columns.Add("DEKA_DATE", GetType(String))
        dt.Columns.Add("GF_DATE", GetType(String))
        dt.Columns.Add("BILL_NUMBER_YEAR", GetType(String))
        dt.Columns.Add("NUMBER_STRING", GetType(String))

        For Each dr As DataRow In dt.Rows

            dr("BILL_NUMBER_YEAR") = dr("BillCode") & "/" & dr("BUDGET_YEAR")

            Dim BgDate As String = ""

            Dim _day As Integer = 0
            Dim _month As Integer = 0
            Dim _year As Integer = 0
            Dim _yyear As Integer = 0

            Dim monthstring As String = ""

            Dim baoNum As New BAO_BUDGET.MoneyExt
            Dim Num As String = ""
            Num = baoNum.NumberToThaiWord(dr("AMOUNT_MONEY"))

            If Num <> "" Then
                dr("NUMBER_STRING") = Num
            End If

            If IsDBNull(dr("DateRecive")) = False Then
                'If dr("DateRecive") <> "" Then
                _day = Day(dr("DateRecive"))
                _month = Month(dr("DateRecive"))
                _year = Year(dr("DateRecive"))

            Else
                _day = 0
                _month = 0
                _year = 0
                'End If

            End If


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

            BgDate = _day & " " & " เดือน " & monthstring & " พ.ศ. " & _yyear

            If IsDBNull(dr("DateRecive")) = False Then
                dr("DEKA_DATE") = BgDate
            Else
                dr("DEKA_DATE") = ""
            End If


            '------------------------
            Dim BgDate2 As String = ""

            Dim _day2 As Integer = 0
            Dim _month2 As Integer = 0
            Dim _year2 As Integer = 0
            Dim _yyear2 As Integer = 0

            Dim monthstring2 As String = ""


            If IsDBNull(dr("GFMIS_DATE")) = False Then
                If dr("GFMIS_DATE") <> "" Then
                    _day2 = Day(dr("GFMIS_DATE"))
                    _month2 = Month(dr("GFMIS_DATE"))
                    _year2 = Year(dr("GFMIS_DATE"))

                Else
                    _day2 = 0
                    _month2 = 0
                    _year2 = 0
                End If

            End If


            If _year2 < 2500 Then
                _yyear2 = _year2 + 543
            Else
                _yyear2 = _year2
            End If

            If _month2 = 1 Then
                monthstring2 = "มกราคม"
            ElseIf _month2 = 2 Then
                monthstring2 = "กุุมภาพันธ์"
            ElseIf _month2 = 3 Then
                monthstring2 = "มีนาคม"
            ElseIf _month2 = 4 Then
                monthstring2 = "เมษายน"
            ElseIf _month2 = 5 Then
                monthstring2 = "พฤษภาคม"
            ElseIf _month2 = 6 Then
                monthstring2 = "มิถุนายน"
            ElseIf _month2 = 7 Then
                monthstring2 = "กรกฎาคม"
            ElseIf _month2 = 8 Then
                monthstring2 = "สิงหาคม"
            ElseIf _month2 = 9 Then
                monthstring2 = "กันยายน"
            ElseIf _month2 = 10 Then
                monthstring2 = "ตุลาคม"
            ElseIf _month2 = 11 Then
                monthstring2 = "พฤศจิกายน"
            ElseIf _month2 = 12 Then
                monthstring2 = "ธันวาคม"
            End If

            BgDate2 = _day2 & " " & " เดือน " & monthstring2 & " พ.ศ. " & _yyear2

            If IsDBNull(dr("GFMIS_DATE")) = False Then
                dr("GF_DATE") = BgDate2
            Else
                dr("GF_DATE") = ""
            End If


        Next

        Return dt
    End Function

End Class