Imports System.Data.SqlClient
Namespace BAO_PERMISSION
    Public Class ConnectDatabass
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_PERMISSIONConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class PERMISSION
        Inherits ConnectDatabass
        Public Function SP_PERMISSION_BUDJET(ByVal citizen_id As String, ByVal id_group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_PERMISSION_BUDJET] @identify = '" & citizen_id & "', @IDgroup=" & id_group
            dt = Queryds(command)

            dt.TableName = ""
            Return dt
        End Function

        Public Function SP_PERMISSION_MENU_BUDGET(ByVal citizen_id As String, ByVal id_group As Integer, ByVal idname_sys As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_PERMISSION_MENU_BUDGET] @identify = '" & citizen_id & "', @IDgroup=" & id_group & ",@IDnamesys=" & idname_sys
            dt = Queryds(command)

            dt.TableName = ""
            Return dt
        End Function
    End Class
    '
End Namespace
