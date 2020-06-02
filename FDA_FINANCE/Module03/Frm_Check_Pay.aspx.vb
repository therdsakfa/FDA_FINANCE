Public Class Frm_Check_Pay
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dao As New DAO_FEE.TB_fee
        Dim feeno As String = ""
        feeno = feeno_format()

        If feeno <> "" Then
            dao.Getdata_by_feeno_and_feeabbr(feeno, txt_feeabbr.Text)
            If dao.fields.IDA <> 0 Then
                If dao.fields.rcptst = 1 Then
                    lbl_result.Text = "ชำระเงินแล้ว"
                    lbl_result.Style.Add("color", "black")
                ElseIf dao.fields.rcptst = 0 Then
                    lbl_result.Text = "รอการชำระเงิน"
                    lbl_result.Style.Add("color", "red")
                ElseIf dao.fields.rcptst = 2 Then
                    lbl_result.Text = "ใบสั่งชำระถูกยกเลิก"
                    lbl_result.Style.Add("color", "red")
                End If
            Else
                lbl_result.Text = "ไม่พบข้อมูล"
                lbl_result.Style.Add("color", "red")
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรอกข้อมูลไม่ถูกต้อง');", True)
        End If

    End Sub
    Private Function feeno_format()
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing
        Try
            arr_feeno = txt_feeno.Text.Split("/")
            If Len(arr_feeno(0)) < 5 Then
                Try
                    arr_feeno(0) = String.Format("{0:00000}", CInt(arr_feeno(0)))
                Catch ex As Exception

                End Try
            End If

            If Len(arr_feeno(1)) = 4 Then
                fee_format = Right(arr_feeno(1), 2) & arr_feeno(0)
            End If

        Catch ex As Exception

        End Try
        Return fee_format
    End Function
End Class