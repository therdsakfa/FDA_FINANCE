Imports System.Data.SqlClient

Namespace BAO_ADV
    Public Class ConnectDatabass
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_ADVConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_ADV(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_ADVConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class FDA_ADV
        Inherits ConnectDatabass
        Public Function SP_GET_FEE_BY_REF01_AND_REF02(ByVal ref01 As String, ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEE_BY_REF01_AND_REF02] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)

            Return dt
        End Function
        Public Sub SP_ADV_Bill(ByVal IDA As String, ByVal Status_ID As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_ADV_Bill] @IDA='" & IDA & "' , @Status='" & Status_ID & "'"
            dt = Queryds(command)
        End Sub

    End Class
    Public Class FDA_TXC
        Inherits ConnectDatabass
        Public Function SP_GET_FEE_BY_REF01_AND_REF02(ByVal ref01 As String, ref02 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_FEE_BY_REF01_AND_REF02] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds_ADV(command)

            Return dt
        End Function
        Public Sub SP_ADV_Bill(ByVal IDA As String, ByVal Status_ID As String)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_ADV_Bill] @IDA='" & IDA & "' , @Status='" & Status_ID & "'"
            dt = Queryds_ADV(command)
        End Sub

    End Class
End Namespace
