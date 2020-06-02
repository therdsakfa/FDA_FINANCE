Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace BAO_SPECIAL_PAYMENT
    Public Class FDA_SPECIAL_PAYMENT
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_SPECIAL_PAYMENTConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_active(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_SPECIAL_PAYMENTConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub SP_UPDATE_STATUS_PAY_COMPLETE(ByVal process As String, ByVal IDA As Integer, ByVal _type As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_UPDATE_STATUS_PAY_COMPLETE] @process='" & process & "' ,@IDA=" & IDA & " ,@type=" & _type
            dt = Queryds(command)

        End Sub
        Function SP_TEMP_UPDATE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_TEMP_UPDATE]"
            dt = Queryds(command)

            Return dt
        End Function
    End Class
End Namespace

