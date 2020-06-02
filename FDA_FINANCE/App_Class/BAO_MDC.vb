Imports System.Data.SqlClient

Namespace BAO_MDC
    Public Class ConnectDatabass
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_MDCConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function

    End Class
    Public Class FDA_MDC
        Inherits ConnectDatabass
        Public Function SP_GET_FEE_BY_REF01_AND_REF02(ByVal ref01 As String, ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEE_BY_REF01_AND_REF02] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)

            Return dt
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC(ByVal IDA As Integer, stat As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC] @IDA=" & IDA & " , @status=" & stat
            dt = Queryds(command)
        End Sub
        '
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC_ONESTOP(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC_ONESTOP] @IDA=" & IDA
            dt = Queryds(command)
        End Sub
    End Class
End Namespace
