Public Class UC_Welfare_Rebill_Search
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function getSearchMsg_DocNumber() As String
        Dim strMsg As String = ""
        If txt_SearchDocNumber.Text <> "" Then
            strMsg = "[DOC_NUMBER] like '%" & txt_SearchDocNumber.Text & "%'"
        End If

        Return strMsg
    End Function

    Public Function getSearchMsg_Name() As String
        Dim strMsg As String = ""
        If txt_SearchName.Text <> "" Then
            strMsg = "[USER_AD] like '%" & txt_SearchName.Text & "%'"
        End If
        Return strMsg
    End Function

    Public Function getSearchMsg_Amount() As String
        Dim strMsg As String = ""
        If txt_SearchAmount.Text <> "" Then
            strMsg = "[AMOUNT] " & dl_HighOrLow.SelectedItem.Text & " " & CInt(txt_SearchAmount.Text)
        End If

        Return strMsg
    End Function

End Class