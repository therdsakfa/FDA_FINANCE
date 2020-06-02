Public Class UC_Search_User_Debtor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = ""
        If strMsg = "" Then
            If txt_Department.Text <> "" Then
                strMsg = "([DEPARTMENT_DESCRIPTION] LIKE '%" & txt_Department.Text & "%') "
            End If
            If txt_fullname.Text <> "" Then
                strMsg = "([fullname] Like '%" & txt_fullname.Text & "%')"
            End If

            If txt_Personal_id.Text <> "" Then
                strMsg = " ([IDENTITY_NUMBER] LIKE '%" & txt_Personal_id.Text & "%') "
            End If
            If txt_Position.Text <> "" Then
                strMsg = " ([POSITION] like '%" & txt_Position.Text & "%') "
            End If
          
        End If

        Return strMsg
    End Function
End Class