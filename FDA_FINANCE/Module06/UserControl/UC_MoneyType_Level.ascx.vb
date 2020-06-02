Public Class UC_MoneyType_Level
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_level1.Text = ""
        txt_level2.Text = ""
        txt_level3.Text = ""
        txt_level4.Text = ""
    End Sub
    Public Sub bindTxtbox(ByVal dt As DataTable)
        Dim strTemp As String = ""
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                If IsDBNull(dt(i)("MONEY_TYPE_DESCRIPTION")) = False And IsDBNull(dt(i)("TYPE_ID")) = False Then
                    Select Case dt(i)("TYPE_ID")
                        Case "1"
                            txt_level1.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "2"
                            txt_level2.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "3"
                            txt_level3.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "4"
                            txt_level4.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    End Select

                End If
                   
            Next
        End If
    End Sub
End Class