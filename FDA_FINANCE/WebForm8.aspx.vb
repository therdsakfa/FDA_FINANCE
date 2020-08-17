Public Class WebForm8
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_runmail_Click(sender As Object, e As EventArgs) Handles btn_runmail.Click
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dt = bao.get_email_all(677011)

        For Each dr As DataRow In dt.Rows

            Dim email As String = ""
            Dim Title As String = ""
            Dim Content As String = ""
            Dim dao_mail As New DAO_CPN.TB_sysemail

            'Dim dao_spay As New DAO_FDA_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
            'Dim dao_pay As New DAO_FDA_SPECIAL_PAYMENT.TB_PAYMENT_DETAIL

            Try
                email = dr("email")
            Catch ex As Exception

            End Try

            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_RECEIVE_MONEY_ID(677011)

            Dim querystr As String = ""
            Dim feeno_re As String = ""
            feeno_re = dao22.fields.FEENO
            Dim dvcd_re As String = ""
            dvcd_re = CStr(dao22.fields.DVCD)
            Dim feebbr_re As String = ""
            feebbr_re = dao22.fields.FEEABBR
            Dim bgYear_re As String = ""
            bgYear_re = CStr(dao22.fields.BUDGET_YEAR)
            querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re

            Dim url2 As String = "http://buisead.fda.moph.go.th/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'feeno=" & feeno_re & "&dvcd=" & dvcd_re & "&feeabbr=" & feebbr_re & "&myear=" & bgYear_re

            'Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            'Dim img_byte As String = Cls_qr.QR_CODE(url2) 'Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

            'Dim dao_i2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao_i2.Getdata_by_RECEIVE_MONEY_ID(dr("RECEIVE_MONEY_ID"))
            'dao_i2.fields.QR_IMAGE_BYTE = img_byte
            'dao_i2.update()





            If email <> "" Then
                If email <> "ไม่ระบุ@hotmail.com" Then
                    email = email
                    Title = "ใบเสร็จอิเล็กทรอนิกส์ชำระเงิน"
                    Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & dao22.fields.REF01 & "&ref02=" & dao22.fields.REF02 & _
                        " *หมายเหตุ ลิ้งค์จะสามารถดูข้อมูลได้หลังจากชำระเงิน 1 ถึง 2 วันทำการ"

                    SendMail(Content, email, Title, email, "", "")
                End If

            End If

            'End If

        Next

    End Sub
    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email

        Try
            mm.SendMail(mcontent)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn_RUN_MAIN_ONLY_Click(sender As Object, e As EventArgs) Handles btn_RUN_MAIN_ONLY.Click
        'Dim email As String = ""
        'Dim Title As String = ""
        'Dim Content As String = ""
        'Dim dao_mail As New DAO_CPN.TB_sysemail
        'Dim ref01 As String = ""
        'Dim ref02 As String = ""

        'email = Trim(txt_mail.Text)
        'ref01 = Trim(txt_ref1.Text)
        'ref02 = Trim(txt_ref2.Text)

        'If email <> "" Then
        '    email = email
        '    Title = "ใบเสร็จอิเล็กทรอนิกส์ชำระเงิน"
        '    Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://164.115.28.103/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & ref01 & "&ref02=" & ref02 & vbCrLf & _
        '        " *หมายเหตุ ลิ้งค์จะสามารถดูข้อมูลได้หลังจากชำระเงิน 1 ถึง 2 วันทำการ"
        '    SendMail(Content, email, Title, email, "", "")
        'End If

    End Sub


    Private Sub btn_runfee_Click(sender As Object, e As EventArgs) Handles btn_runfee.Click
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dt = bao.ERROR_BAISANG
        'Dim bao As New BAO_SPECIAL_PAYMENT.FDA_SPECIAL_PAYMENT
        'dt = bao.SP_TEMP_UPDATE()

        For Each dr As DataRow In dt.Rows
            '    Dim bao_pay As New BAO_SPECIAL_PAYMENT.FDA_SPECIAL_PAYMENT
            '    bao_pay.SP_UPDATE_STATUS_PAY_COMPLETE(dr("process_id"), dr("fk_id"))

            'Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
            'ws_updates.Update_Status_Pay(dr("ref01"), dr("ref02"))

            Try
                Dim ws_receipt As New WS_RECEIPT_AUTO
                ws_receipt.Gen_Receipt(dr("ref01"), dr("ref02"))
            Catch ex As Exception

                'Insert_log_error(ref1, ref2, xml_name, "vc=System error : " & vc.resMesg & " ส่วนออกใบเสร็จอัตโนมัติ", Request.account, 0)
            End Try
        Next




    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ws_dh As New WS_GEN_DH_NUMBER.WS_GEN_DH_NO
        'Dim bao_ida As New BAO_FEE.FDA_DRUG
        'Dim dt_ida As New DataTable
        'dt_ida = bao_ida.SP_GET_IDA_DA_FROM_FEE_MULTI_ROW("610001026525610127", "600201101213000063")
        'For Each dr As DataRow In dt_ida.Rows
        ws_dh.GEN_DH_NO(50880)
        'Next
    End Sub

    Private Sub btn_run_ref_Click(sender As Object, e As EventArgs) Handles btn_run_ref.Click
        'Dim str As String = "SELECT  [ref1],[ref2] FROM [FDA_FEE].[dbo].[fee_logs] where cast([CREATEDATE] as date) = cast(getdate() as date) and CREATEDATE < '2019-06-05 14:37:28.193' group by [ref1],[ref2]"
        'Dim bao As New BAO_FEE.FEE

        'Dim dt As New DataTable
        'dt = bao.Queryds(str)
        'For Each dr As DataRow In dt.Rows
        Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
        ws_updates.Update_Status_Pay(txt_ref1.Text, txt_ref2.Text)
        'Next

    End Sub
End Class