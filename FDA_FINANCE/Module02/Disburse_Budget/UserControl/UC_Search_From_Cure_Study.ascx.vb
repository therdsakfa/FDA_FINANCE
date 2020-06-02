Public Class UC_Search_From_Cure_Study
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "

        Dim docdate As String = ""
        Dim billdate As String = ""

        Try
            docdate = CDate(rdp_DOC_DATE.SelectedDate).ToShortDateString()
        Catch ex As Exception

        End Try

        Try
            billdate = CDate(rdp_BILL_DATE.SelectedDate).ToShortDateString()
        Catch ex As Exception

        End Try

        strMsg = "([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%')" & _
            " and ([GFMIS_NUMBER] LIKE '%" & txt_GFMIS.Text & "%')" & _
            " and ([BILL_NUMBER] LIKE '%" & txt_BILL_NUMBER.Text & "%')" & _
            " and ([CUSTOMER_NAME] LIKE '%" & txt_name.Text & "%')"

        If docdate <> "" Then
            strMsg &= " and ([DOC_DATE] ='" & docdate & "') "
        End If
        If billdate <> "" Then
            strMsg &= " and ([BILL_DATE] ='" & billdate & "') "
        End If
        '   End If

        Return strMsg
    End Function
End Class