Public Class UC_Search_Form_with_description
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "

        strMsg = "([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%')" & _
                 " and ([BILL_NUMBER] LIKE '%" & txt_BILL_NUMBER.Text & "%')" & _
                 " and ([DESCRIPTION] LIKE '%" & txt_des.Text & "%')"

        If txt_amount.Text <> "" Then
            strMsg &= " and ([AMOUNT] = '" & txt_amount.Text & "' )"
        End If


        '' " and ([GFMIS_NUMBER] LIKE '%" & txt_GFMIS.Text & "%')" & _

        Return strMsg
    End Function
End Class