Imports System.Data.SqlClient
Public Class Class1
    'โค้ดต่อ sql 
    Public Function Queryds(ByVal Commands As String) As DataTable
        Dim dt As New DataTable
        Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAMConnectionString").ConnectionString)
        Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
        mySqlDataAdapter.Fill(dt)
        MyConnection.Close()
        Return dt
    End Function

    'โค้ดคิวรี่ที่จะดึงข้อมูลมา
    Public Function getGF_Other() As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        'คิวรี่ที่เขียนใน sql
        command = "SELECT * FROM [FDA_FINANCE].[dbo].[MAS_BANK]"
        dt = Queryds(command)

        Return dt
    End Function
End Class
