Imports System.Data.SqlClient

Namespace BAO_TXC
    Public Class ConnectDatabass
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_TXCConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function

    End Class
    Public Class FDA_TXC
        Inherits ConnectDatabass
        Public Function SP_GET_FEE_BY_REF01_AND_REF02(ByVal ref01 As String, ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEE_BY_REF01_AND_REF02] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)

            Return dt
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXC(ByVal IDA As Integer, ByVal process_id As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXC] @IDA=" & IDA & " , @process_id='" & process_id & "'"
            dt = Queryds(command)
        End Sub
     
    End Class
End Namespace
