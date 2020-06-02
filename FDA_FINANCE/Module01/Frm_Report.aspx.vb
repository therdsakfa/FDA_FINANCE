Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowReport()
    End Sub

    Public Sub ShowReport()
        ReportViewer1.LocalReport.ReportPath = "D:\Report\Module09\Report_R9_002.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource(namereport, _
        'getdatatable(Instance, CInt(TextBox2.Text)))) 'parameter (ชื่อ dataset ใน report,datatable)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.DataBind()
        'ReportViewer1.LocalReport.Render("word")
    End Sub

End Class