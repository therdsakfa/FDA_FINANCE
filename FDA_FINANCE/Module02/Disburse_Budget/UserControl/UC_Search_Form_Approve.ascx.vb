Public Class UC_Search_Form_Approve
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "
        'strMsg = "([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%') and ([Bill_RECIEVE_DATE]='" & rdp_Bill_RECIEVE_DATE.SelectedDate & "')and ([DOC_DATE] ='" & rdp_DOC_DATE.SelectedDate & "') "
        'strMsg &= " and ([BILL_NUMBER]LIKE '%" & txt_BILL_NUMBER.Text & "%') and ([BILL_DATE]='" & rdp_BILL_DATE.SelectedDate & "') and ([GFMIS]='%" & txt_GFMIS.Text & "%')"
        'Dim receivedate As String = ""
        'Dim docdate As String = ""
        'Dim billdate As String = ""

        'Try
        '    receivedate = CDate(rdp_Bill_RECIEVE_DATE.SelectedDate).ToShortDateString()
        'Catch ex As Exception

        'End Try

        'Try
        '    docdate = CDate(rdp_DOC_DATE.SelectedDate).ToShortDateString()
        'Catch ex As Exception

        'End Try

        'Try
        '    billdate = CDate(rdp_BILL_DATE.SelectedDate).ToShortDateString()
        'Catch ex As Exception

        'End Try

        'strMsg = "([App] LIKE '%" & rd_approve.SelectedValue & "%') and ([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%')" & _
        '    " and ([GFMIS_NUMBER] LIKE '%" & txt_GFMIS.Text & "%')" & _
        '    " and ([BILL_NUMBER] LIKE '%" & txt_BILL_NUMBER.Text & "%')"

        'If receivedate <> "" Then
        '    strMsg &= " and ([Bill_RECIEVE_DATE] = '" & receivedate & "')"
        'End If
        'If docdate <> "" Then
        '    strMsg &= " and ([DOC_DATE] ='" & docdate & "') "
        'End If
        'If billdate <> "" Then
        '    strMsg &= " and ([BILL_DATE] ='" & billdate & "') "
        'End If

        If rdp_Bill_RECIEVE_DATE.IsEmpty = False Then
            strMsg &= " and ([Bill_RECIEVE_DATE]= '" & rdp_Bill_RECIEVE_DATE.SelectedDate & "')"
        ElseIf rdp_DOC_DATE.IsEmpty = False Then
            strMsg &= " and ([DOC_DATE] ='" & rdp_DOC_DATE.SelectedDate & "') "

        ElseIf rdp_BILL_DATE.IsEmpty = False Then
            strMsg &= " and ([BILL_DATE] ='" & rdp_BILL_DATE.SelectedDate & "') "
        End If
        strMsg = "([App] like '%" & rd_approve.SelectedValue & "%') "
        If txt_BILL_NUMBER.Text <> "" Then
            strMsg = strMsg & "and ([BILL_NUMBER] LIKE '%" & txt_BILL_NUMBER.Text & "%') "
        End If
        If txt_DOC_NUMBER.Text <> "" Then
            strMsg = strMsg & " and ([DOC_NUMBER] LIKE '%" & txt_DOC_NUMBER.Text & "%') "
        End If
        If txt_GFMIS.Text <> "" Then
            strMsg = strMsg & " and ([GFMIS_NUMBER] LIKE '%" & txt_GFMIS.Text & "%')"
        End If

        Return strMsg
    End Function
End Class