Public Class FRM_FIX_RECEIPT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_send_Click(sender As Object, e As EventArgs) Handles btn_send.Click
        Dim i As Integer = 0
        Dim dao_fee2 As New DAO_FEE.TB_fee
        i = dao_fee2.Countby_ref1_ref2(txt_ref01.Text, txt_ref02.Text)
        If i > 0 Then
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(txt_ref01.Text, txt_ref02.Text)

            Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_re.Getdata_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
            Dim QR As New QR_CODE.GEN_QR_CODE
            Dim feeno As String = ""
            Dim dvcd As String = ""
            Dim feeabbr As String = ""
            Dim bgyear As String = ""
            Try
                feeno = dao_fee.fields.feeno
            Catch ex As Exception

            End Try
            Try
                dvcd = dao_fee.fields.dvcd
            Catch ex As Exception

            End Try
            Try
                feeabbr = dao_fee.fields.feeabbr
            Catch ex As Exception

            End Try
            Try
                bgyear = dao_re.fields.BUDGET_YEAR
            Catch ex As Exception

            End Try
            Dim query As String = feeno & "|" & dvcd & "|" & feeabbr & "|" & bgyear
            Dim aa As String = "http://helpb.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & query.EncodeBase64
            Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            Dim img_byte As String = Cls_qr.QR_CODE(aa)

            Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
            dao_det.Getdata_by_RECEIVE_MONEY_ID(dao_re.fields.RECEIVE_MONEY_ID)
            For Each dao_det.fields In dao_det.datas
                Dim dao_det2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                dao_det2.Getdata_by_IDA(dao_det.fields.IDA)
                dao_det2.delete()
            Next

            '----insert new
            Dim bao As New BAO_BUDGET.Maintain
            bao.Fix_Insert_RECEIVE_MONEY_DETAIL2(txt_ref01.Text, txt_ref02.Text)

            '---- update qr
            dao_re.fields.QR_IMAGE_BYTE = img_byte
            dao_re.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งค่าเรียบร้อยแล้ว');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
    End Sub
End Class