Imports Microsoft.Reporting.WebForms

Public Class Frm_Report_R7_Slip
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim util As New Report_Utility
            util.report = ReportViewer1
            util.configWidthHeight()

            util.ShowReport(ReportViewer1, util.root & "Module07\Report_R7_Slip.rdlc", "Fields_Report_R7_RP", getReportData())
            ' util.ShowReport(ReportViewer1, "E:\งาน อย\FDA_FINANCE_20180228\FDA_FINANCE\FDA_FINANCE\Report\Module07\Report_R7_Slip.rdlc", "Fields_Report_R7_RP", getReportData())

        End If

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Dim exportOption1 As String = "EXCELOPENXML"
        Dim exportOption2 As String = "WORDOPENXML"
        Dim exportOption3 As String = "PDF"

        Dim extension As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption1, StringComparison.CurrentCultureIgnoreCase))
        If extension IsNot Nothing Then
            Dim fieldInfo As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            fieldInfo.SetValue(extension, False)
        End If

        'Dim extension2 As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption2, StringComparison.CurrentCultureIgnoreCase))
        'If extension2 IsNot Nothing Then
        '    Dim fieldInfo As System.Reflection.FieldInfo = extension2.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        '    fieldInfo.SetValue(extension2, False)
        'End If

        Dim extension3 As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption3, StringComparison.CurrentCultureIgnoreCase))
        If extension3 IsNot Nothing Then
            Dim fieldInfo As System.Reflection.FieldInfo = extension3.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            fieldInfo.SetValue(extension3, False)
        End If

    End Sub

    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        Dim bao_list As New BAO_BUDGET.Report
        Dim bao_pay As New BAO_BUDGET.Report
        Dim dt As New DataTable
        Dim dt_list As New DataTable
        Dim dt_paydate As New DataTable


        dt = bao.get_Report_R7_Slip(Request.QueryString("idrun"))
        dt_paydate = bao_pay.get_Report_R7_Slip_AddPayDate()

        dt_list = bao_list.get_Report_R7_Slip_list

        dt_list.Columns.Add("fullname")
        dt_list.Columns.Add("dept_long")
        dt_list.Columns.Add("bankID")
        dt_list.Columns.Add("amount", GetType(Double))
        dt_list.Columns.Add("amount2", GetType(Double))
        dt_list.Columns.Add("dept_short")
        dt_list.Columns.Add("month_Name")
        dt_list.Columns.Add("bgyear")
        dt_list.Columns.Add("month_short")
        dt_list.Columns.Add("Paydate")
        dt_list.Columns.Add("BankName")


        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt_list.Rows
                Dim bao1 As New BAO_BUDGET.Salary()
                Try
                    dr("amount") = bao1.get_salary_paylist_amount(dt(0)("IDRUN"), dr("s_paylist"))
                Catch ex As Exception
                    dr("amount") = 0
                End Try
                'เพิ่ม String

                Dim dao As New DAO_MAS.TB_MAS_BANK
                Dim bankId As String = ""

                If IsDBNull(dt(0)("FK_BANK")) = False Then
                    dao.Getdata_by_BANK_ID(dt(0)("FK_BANK"))
                    dr("BankName") = dao.fields.BANK_NAME
                Else
                    dr("BankName") = ""
                End If


                dr("fullname") = dt(0)("fullname")
                dr("dept_long") = dt(0)("dept_long")
                dr("bankID") = dt(0)("bankID")
                dr("dept_short") = dt(0)("dept_short")
                dr("month_Name") = dt(0)("month_Name")
                dr("bgyear") = dt(0)("bgyear")
                dr("month_short") = dt(0)("month_short")


                If dr("rev_type") = "รายจ่าย" Then
                    Try
                        dr("amount2") = dr("amount") * -1
                    Catch ex As Exception
                        dr("amount2") = 0
                    End Try

                Else
                    Try
                        dr("amount2") = dr("amount")
                    Catch ex As Exception
                        dr("amount2") = 0
                    End Try
                End If


            Next

        End If

        If dt_paydate.Rows.Count > 0 Then
            For Each dr As DataRow In dt_list.Rows

                'เพิ่ม String
                Dim dateNow As Date = (Date.Now).ToLongDateString

                Dim bdString As String = ""
                Dim _day As Integer = 0
                Dim _month As Integer = 0
                Dim _year As Integer = 0
                Dim _time_h As Double = 0
                Dim _time_m As Double = 0

                Dim monthstring As String = ""

                _day = Day(dateNow)
                _month = Month(dateNow)
                _year = Year(dateNow)

                If _month = 1 Then
                    monthstring = "ม.ค."
                ElseIf _month = 2 Then
                    monthstring = "ก.พ."
                ElseIf _month = 3 Then
                    monthstring = "มี.ค."
                ElseIf _month = 4 Then
                    monthstring = "เม.ย."
                ElseIf _month = 5 Then
                    monthstring = "พ.ค."
                ElseIf _month = 6 Then
                    monthstring = "มิ.ย."
                ElseIf _month = 7 Then
                    monthstring = "ก.ค."
                ElseIf _month = 8 Then
                    monthstring = "ส.ค."
                ElseIf _month = 9 Then
                    monthstring = "ก.ย."
                ElseIf _month = 10 Then
                    monthstring = "ต.ค."
                ElseIf _month = 11 Then
                    monthstring = "พ.ย."
                ElseIf _month = 12 Then
                    monthstring = "ธ.ค"
                End If


                dr("Paydate") = _day & "/" & monthstring & "/" & _year 'dt_paydate(0)("Paydate")

            Next


        End If

        Return dt_list

    End Function



End Class