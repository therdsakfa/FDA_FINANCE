Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Microsoft.Reporting.WebForms

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_RUN_PDF_RECEIPT
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String, ByVal ref02 As String)
        Dim rsw As New LocalReport
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

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)

        Dim clsds As New ClassDataset
        'If ref02 = "" Then
        '    ref02 = Request.QueryString("id_feeno")
        'End If

        clsds.bynaryToobject(Server.MapPath("../PDF/") & ref02 & ".pdf", renderedbytes)
    End Sub

End Class