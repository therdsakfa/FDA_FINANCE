
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace BAO_FDA_MULCT
    Public Class FDA_MULCT
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_MULCTConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub SP_MULCT_FOR_PDF_MAIN(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_MULCT_FOR_PDF_MAIN] @IDA=" & IDA
            dt = Queryds(command)

        End Sub
    End Class
End Namespace
