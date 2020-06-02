Imports System.Data.SqlClient

Public Class BAO_USER
    Public Class ConnectDatabase
        Public Function Queryds_User(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DTAM_USERConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class USER
        Inherits ConnectDatabase
        Public Function get_user_debtor() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.get_user_debtor"
            dt = Queryds_User(command)
            Return dt
        End Function
        Public Function GetUser() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_USER] "
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function GetUserManage() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_UserManage] "
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function GetUserGroup() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_UserGroup] "
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function GetUserCheck(ByVal ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_UserCheck] @ID = " & ID
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function GetUserManageGroup_User() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_UserManageGroupUser] "
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function GetUserManageGroup_Group(ByVal Group_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_UserManageGroupGroup] @GroupID = " & Group_id
            dt = Queryds_User(command)
            Return dt
        End Function

        Public Function GetUserDetail(ByVal AD_NAME As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[get_UserDetail] @AD_Name = '" & AD_NAME & "'"
            dt = Queryds_User(command)
            Return dt
        End Function
        'Public Function get_dept(ad As String) As Integer
        '    Dim dao_user As New DAO_USER.TB_tbl_USER
        '    dao_user.Getdata_by_AD_NAME(ad)
        '    Dim dept_id As Integer = 0
        '    dept_id = dao_user.fields.DEPARTMENT_ID

        '    Return dept_id
        'End Function
        Public Function get_dept(ad As String) As Integer
            Dim dao_user As New DAO_USER.TB_tbl_USER
            dao_user.Get_dept_select_by_AD_NAME(ad)
            Dim dept_id As Integer = 0
            dept_id = dao_user.fields.DEPARTMENT_ID

            Return dept_id
        End Function
        Public Function get_NAME_AD_NAME() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [get_USER_NAME_AD_NAME] "
            dt = Queryds_User(command)
            Return dt
        End Function
    End Class
End Class
