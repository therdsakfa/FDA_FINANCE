Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_WAIT_QUEQE_LIST
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Sub Insert_Queue(ByVal ref01 As String, ByVal ref02 As String)
        Dim bao_mass As New BAO_BUDGET.MASS
        Try
            bao_mass.INSERT_WAIT_QUEUE_LIST(ref01, ref02)
        Catch ex As Exception
            bao_mass.INSERT_WAIT_QUEUE_LIST(ref01, ref02)
        End Try

    End Sub

End Class