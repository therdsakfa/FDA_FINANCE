Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_RECEIPT_DETAIL
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Get_Detail(ByVal ref01 As String, ByVal ref02 As String) As CLS_RETURN_MONEY
        Dim ws As New CLS_RETURN_MONEY
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.GET_DETAIL_RECEIPT(ref01, ref02)
        For Each dr As DataRow In dt.Rows
            Try
                ws.Pay_Date = CDate(dr("MONEY_RECEIVE_DATE"))
            Catch ex As Exception

            End Try
            ws.Receive_Type = dr("RECEIVE_TYPE")
            ws.Amount = dr("AMOUNT")
            Try
                ws.RECEIVE_MONEY_ID = dr("RECEIVE_MONEY_TYPE")
            Catch ex As Exception

            End Try
        Next

        Return ws
    End Function

End Class