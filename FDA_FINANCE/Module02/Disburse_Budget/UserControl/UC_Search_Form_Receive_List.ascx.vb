Public Class UC_Search_Form_Receive_List
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "

        If txt_BILL_NUMBER.Text = "" And txt_DOC_NUMBER.Text = "" And rd_receive_type.SelectedValue = "" And txt_amount.Text = "" Then

            strMsg = ""
        Else
            If rd_receive_type.SelectedValue <> "" Then
                strMsg = "([status] = '" & rd_receive_type.SelectedValue & "')"
            End If
            'strMsg = "([status] LIKE '%" & rd_receive_type.SelectedValue & "%') and ([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%') and ([BILL_NUMBER] LIKE '%" & txt_BILL_NUMBER.Text & "%')"
            If txt_DOC_NUMBER.Text <> "" Then
                strMsg = "([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%')"
            End If
            If txt_BILL_NUMBER.Text <> "" Then
                strMsg = "([BILL_NUMBER] LIKE '%" & txt_BILL_NUMBER.Text & "%')"
            End If
            If txt_amount.Text <> "" Then
                strMsg = "([AMOUNT] " & dd_equal.SelectedItem.Text & " '" & txt_amount.Text & "')"
            End If


        End If

        Return strMsg
    End Function
End Class