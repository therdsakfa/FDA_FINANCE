Public Class UC_Budget_Search_Form
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "
        If txt_Doc_number.Text = "" And txt_Money.Text = "" and txt_count.Text = "" Then

            strMsg = ""
        Else

            If txt_count.Text <> "" Then
                strMsg = " ([BUDGET_TRANSFER_COUNT] = '" & txt_count.Text & "')"
            End If

            If txt_Money.Text <> "" Then
                strMsg = "([BUDGET_TRANSFER_AMOUNT] " & dd_eual.SelectedItem.Text & " '" & txt_Money.Text & "')"
            End If
            If txt_Doc_number.Text <> "" Then
                strMsg = "([BUDGET_TRANSFER_DOC_NUMBER] LIKE '%" & txt_Doc_number.Text & "%')"
            End If

        End If
        Return strMsg
    End Function
End Class