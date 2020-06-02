Public Class UC_Filter_Movedate
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function get_messege() As String
        Dim str As String = ""
        ' If txt_BILL_NUMBER.Text <> "" Then
        str = "([BILL_NUMBER] like '%" & txt_BILL_NUMBER.Text & "%') and ([DOC_NUMBER] like '%" & txt_DOC_NUMBER.Text & "%')"
        ' End If
        Return str
    End Function
    Public Function get_messege_can() As String
        Dim str As String = ""
        ' If txt_BILL_NUMBER.Text <> "" Then
        str = "([bill] like '%" & txt_BILL_NUMBER.Text & "%') and ([DOC_NUMBER] like '%" & txt_DOC_NUMBER.Text & "%')"
        ' End If
        Return str
    End Function
End Class