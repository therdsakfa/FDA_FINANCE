Imports Microsoft.Reporting.WebForms
Public Class Frm_Report_R3_019
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim util As New Report_Utility
            util.report = ReportViewer1
            util.configWidthHeight()
            'If Request.QueryString("e") = "" Then
            '    runpdf(getReportData(), util.root & "Module03\Report_R3_019.rdlc", "Fields_Report_R3_019")
            'Else
            runpdf(getReportData(), util.root & "Module03\Report_R3_019_e.rdlc", "Fields_Report_R3_019")
            'End If


            'Dim util As New Report_Utility
            'util.report = ReportViewer1
            'util.configWidthHeight()
            'util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_019.rdlc", "Fields_Report_R3_019", getReportData())
        End If
    End Sub

    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        Dim dt As New DataTable
        dt = bao.get_Report_R3_019(Request.QueryString("ida"))
        'If Request.QueryString("e") <> "" Then
        Dim max_row As Integer = 14
        If dt.Rows.Count > 0 Then
            max_row = max_row - dt.Rows.Count
            For i As Integer = 1 To max_row
                Dim dr As DataRow = dt.NewRow()
                dr("cash_amount") = 0
                dr("chack_amount") = 0
                dr("draft_amount") = 0
                dr("cashier_amount") = 0
                dr("deposit_amount") = 0
                dt.Rows.Add(dr)
            Next
        End If

        'End If

        Return dt
    End Function


    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
        Dim rsw As New LocalReport
        rsw.Refresh()
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource

        reportdatasource.Value = dt1
        reportdatasource.Name = report_datasource
        rsw.DataSources.Add(reportdatasource)


        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        'ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        Response.AddHeader("Accept-Ranges", "bytes")
        Response.AddHeader("Accept-Header", "2222")
        Response.AddHeader("Cache-Control", "public")
        Response.AddHeader("Cache-Control", "must-revalidate")
        Response.AddHeader("Pragma", "public")
        'Response.AddHeader()
        'Response.AddHeader("Content-Encoding", "UTF-8")

        'Response.ContentEncoding = System.Text.Encoding.Unicode   'GetEncoding(874)
        'Response.Charset = "windows-874"
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=""" + "Report_R3_019.pdf" + """")
        Response.AddHeader("expires", "0")


        Response.BinaryWrite(renderedbytes)
        Response.Flush()
    End Sub
End Class