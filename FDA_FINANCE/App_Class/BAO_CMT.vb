Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace BAO_CMT
    Public Class FDA_CMT
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_CMTConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_active(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_CMTConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub SP_Update_payment_req(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_Update_payment_req] @IDA=" & IDA
            dt = Queryds(command)

        End Sub
        Public Sub SP_Update_payment_regnos(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_Update_payment_regnos] @IDA=" & IDA
            dt = Queryds(command)

        End Sub
        Public Function SP_GET_IDA_CMT_FROM_FEE(ByVal ref01 As String, ref02 As String) As Integer
            Dim dt As New DataTable
            Dim IDA As Integer = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_IDA_CMT_FROM_FEE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                IDA = dr("IDA")
            Next

            Return IDA
        End Function
    End Class
End Namespace

