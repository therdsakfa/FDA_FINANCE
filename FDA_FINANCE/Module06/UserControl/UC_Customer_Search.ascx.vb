Public Class UC_Customer_Search
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function get_strSearch() As String
        Dim str As String = ""
        str = "([PERSONAL_ID] LIKE '%" & txt_PERSONAL_ID.Text & "%')" & _
            " and ([CUSTOMER_NAME] LIKE '%" & txt_Customername.Text & "%')" & _
            " and ([TAX_NUMBER] LIKE '%" & txt_TAX_NUMBER.Text & "%')" & _
            " and ([TEL_NUMBER] LIKE '%" & txt_TEL_NUMBER.Text & "%')"
        If txt_PERSONAL_ID.Text <> "" Then
            str = "([PERSONAL_ID] LIKE '%" & txt_PERSONAL_ID.Text & "%')"
        ElseIf txt_Customername.Text <> "" Then
            str = "([CUSTOMER_NAME] LIKE '%" & txt_Customername.Text & "%')"
        ElseIf txt_TAX_NUMBER.Text <> "" Then
            str = "([TAX_NUMBER] LIKE '%" & txt_TAX_NUMBER.Text & "%')"
        ElseIf txt_TEL_NUMBER.Text <> "" Then
            str = "([TEL_NUMBER] LIKE '%" & txt_TEL_NUMBER.Text & "%')"
        End If

        Return str
    End Function
End Class