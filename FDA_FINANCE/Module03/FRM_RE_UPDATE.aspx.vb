Imports Microsoft.Reporting.WebForms

Public Class FRM_RE_UPDATE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        send_data(txt_ref01.Text, txt_ref02.Text)
        'Dim dt As New DataTable
        'Dim bao As New BAO_BUDGET.Budget
        'dt = bao.get_data_ref01()
        'For Each dr As DataRow In dt.Rows
        '    send_data(dr("ref01"), dr("ref02"))
        'Next
    End Sub
    Sub send_data(ByVal ref01 As String, ByVal ref02 As String)
        Dim chk_permiss As Boolean = False

        Try
            chk_permiss = CHK_PERMISSION(_CLS.CITIZEN_ID)
        Catch ex As Exception

        End Try
        If chk_permiss = True Then
            Dim dept As Integer = 0
            Dim feeno As Integer = 0
            Dim dvcd As Integer = 0
            Dim feeabbr As String = ""
            Dim bao_d As New BAO_BUDGET.FDA_FEE
            Dim dt_d As New DataTable
            Dim is_old As Boolean = False
            Dim l44 As Boolean = False

            Dim dao_chk_fee As New DAO_FEE.TB_fee
            Dim count_fee_new As Integer = 0
            Dim dao_fee_m44 As New DAO_FEE.TB_fee
            count_fee_new = dao_chk_fee.Countby_ref1_ref2(ref01, ref02)
            dao_fee_m44.GetDataby_ref1_ref2(ref01, ref02)

            'dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
            'dt_d = bao_d.SP_get_receipt_by_ref01_ref02(ref01, ref02)
            If dt_d.Rows.Count > 0 Then
                is_old = True
            End If

            Dim fee_stat As Integer = 0
            Try
                If dao_fee_m44.fields.acc_type = 2 Then
                    l44 = True
                End If
            Catch ex As Exception

            End Try
            Try
                fee_stat = dao_fee_m44.fields.rcptst
            Catch ex As Exception

            End Try

            If dao_fee_m44.fields.IDA <> 0 Then
                If fee_stat = 0 Then
                    Dim dao_fee As New DAO_FEE.TB_fee
                    dao_fee.GetDataby_ref1_ref2(ref01, ref02)
                    dao_fee.fields.rcptst = 1
                    dao_fee.update()
                End If
                Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
                ws_updates.Update_Status_Pay_Repeat(ref01, ref02, True)

                Dim ws_updates2 As New WS_UPDATE_PAY_HERB.WS_UPDATE_STATUS_PAY
                ws_updates2.Update_Status_Pay_Repeat(ref01, ref02, True)
                'ws_updates.Update_Status_Pay(ref01, ref02)
                Try
                    Dim dao_log As New DAO_MAS.TB_LOG_RE_UPDATE
                    With dao_log.fields
                        .CITIZEN_ID_RE_UPDATE = _CLS.CITIZEN_ID
                        .CREATE_DATE = Date.Now
                        .REF01 = txt_ref01.Text
                        .REF02 = txt_ref02.Text
                    End With
                    dao_log.insert()
                Catch ex As Exception
                    Dim dao_log As New DAO_MAS.TB_LOG_RE_UPDATE
                    With dao_log.fields
                        .CITIZEN_ID_RE_UPDATE = _CLS.CITIZEN_ID
                        .CREATE_DATE = Date.Now
                        .REF01 = txt_ref01.Text
                        .REF02 = txt_ref02.Text
                    End With
                    dao_log.insert()
                End Try
                Try

                Catch ex As Exception

                End Try
                Dim feeabbr_u As String = ""
                Dim acc_type As Integer = 0
                Dim citizen_fee As String = ""

                Dim dao_fee5 As New DAO_FEE.TB_fee
                dao_fee5.GetDataby_ref1_ref2(ref01, ref02)
                Try
                    feeabbr_u = dao_fee5.fields.feeabbr
                Catch ex As Exception

                End Try
                Try

                Catch ex As Exception
                    acc_type = dao_fee5.fields.acc_type
                End Try
                Try
                    citizen_fee = dao_fee5.fields.create_identify
                Catch ex As Exception

                End Try
                Dim dao_fee_det2 As New DAO_FEE.TB_feedtl
                dao_fee_det2.Getdata_by_fee_id(dao_fee5.fields.IDA)
                'For Each dao_fee_det2.fields In dao_fee_det2.datas
                'If acc_type = 2 Then

                Dim email As String = ""
                Dim Title As String = ""
                Dim Content As String = ""
                Dim dao_mail As New DAO_CPN.TB_sysemail
                'Dim dao_sp As New dao
                'Dim citizen As String = ""
                Dim dao_spay As New DAO_FDA_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
                Dim dao_pay As New DAO_FDA_SPECIAL_PAYMENT.TB_PAYMENT_DETAIL

                Try
                    dao_spay.GetDataby_IDA(dao_fee_det2.fields.fk_id)
                Catch ex As Exception

                End Try
                Try
                    dao_pay.GetDataby_IDA(dao_fee_det2.fields.fk_id)
                Catch ex As Exception

                End Try

                Try


                Catch ex As Exception

                End Try


                Try
                    dao_mail.GetDataby_identify(citizen_fee)
                    email = dao_mail.fields.EMAIL_EGA
                Catch ex As Exception

                End Try

                Try
                    If email <> "" Then
                        email = email
                        Title = "ใบเสร็จอิเล็กทรอนิกส์ชำระเงิน_" & TimeStampNow()
                        Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & txt_ref01.Text & "&ref02=" & txt_ref02.Text

                        SendMail(Content, email, Title, email, "", "")
                    End If
                Catch ex As Exception

                End Try


                'End If

                'Next

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งข้อมูลเรียบร้อย');", True)
            Else
                If dt_d.Rows.Count > 0 Then
                    'insert_e_bill(dt_d(0)("dvcd"), dt_d(0)("feeno"), dt_d(0)("feeabbr"), l44, txt_ref01.Text, txt_ref02.Text, is_old)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                End If
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คุณไม่มีสิทธิ์ในระบบนี้');", True)
        End If
    End Sub
    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email


        mm.SendMail(mcontent)

    End Sub

    Function CHK_PERMISSION(ByVal citien As String) As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_MAS.TB_MAS_RE_UPDATE_USER
        Try
            dao.Getdata_by_citizen(citien)
            If dao.fields.IDA <> 0 Then
                bool = True
            End If
        Catch ex As Exception

        End Try
        Return bool
    End Function
    Function Get_Checker_ID(ByVal citizen As String) As Integer
        Dim id As Integer = 0
        Dim dao_re As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        Try
            dao_re.Getdata_by_iden(citizen)
            id = dao_re.fields.RECEIVER_MONEY_ID
        Catch ex As Exception
            id = 0
        End Try
        Return id
    End Function
    Public Function Get_BUDGET_YEAR() As Integer
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If byearMax < 2500 Then
            byearMax = byearMax + 543
        End If
        Dim aa As Date = CDate("1/10/" & byearMax)
        Dim date_now As Date = CDate(System.DateTime.Now)
        Dim dd As String = ""
        Dim mm As String = ""
        Dim yy As String = ""
        Try
            dd = Day(date_now)
        Catch ex As Exception

        End Try
        Try
            mm = Month(date_now)
        Catch ex As Exception

        End Try
        Try
            yy = Year(date_now)
            If yy < 2500 Then
                yy += 543
            End If
        Catch ex As Exception

        End Try
        Dim fulldate As String = ""
        Try
            fulldate = dd & "/" & mm & "/" & yy
        Catch ex As Exception
            fulldate = CDate(Date.Now).ToShortDateString
        End Try
        If CDate(fulldate) >= CDate("1/10/" & byearMax) Then
            byearMax = byearMax + 1
        End If

        Return byearMax
    End Function

    Protected Sub btn_search111_Click(sender As Object, e As EventArgs) Handles btn_search111.Click
        Search_fee(txt_ref01.Text, txt_ref02.Text)
        Try
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
            txt_name.Text = dao.fields.FULLNAME
        Catch ex As Exception

        End Try
    End Sub

    Sub Search_fee(ByVal ref01 As String, ByVal ref02 As String)
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        dt = bao.Get_FEE_BY_REF01_AND_REF02(ref01, ref02)
        Try

        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
        RadGrid1.DataBind()
    End Sub

    Private Sub btn_search222_Click(sender As Object, e As EventArgs) Handles btn_search222.Click
        If txt_ref01.Text.Contains("/") Then
            Dim feeno_aray As String() = txt_ref01.Text.Split("/")
            Dim feeno As String = ""
            Try
                feeno = feeno_aray(1) & feeno_aray(0)
            Catch ex As Exception

            End Try

            Try
                Dim dao As New DAO_FEE.TB_fee
                dao.GetDataby_feeno(feeno)
                Search_fee(dao.fields.ref01, dao.fields.ref02)
            Catch ex As Exception

            End Try
        Else

        End If


    End Sub

    Protected Sub btn_search2_Click(sender As Object, e As EventArgs) Handles btn_search2.Click
        Dim feeno_aray As String() = txt_ref01.Text.Split("/")
        Dim feeno As String = ""
        Try
            feeno = feeno_aray(1) & feeno_aray(0)
        Catch ex As Exception

        End Try
        Try
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_feeno(feeno)
            txt_name.Text = dao.fields.FULLNAME
        Catch ex As Exception

        End Try
        Try
            Dim dao As New DAO_FEE.TB_fee
            dao.GetDataby_feeno(feeno)
            send_data(dao.fields.ref01, dao.fields.ref02)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim chk_permiss As Boolean = False

        Try
            chk_permiss = CHK_PERMISSION(_CLS.CITIZEN_ID)
        Catch ex As Exception

        End Try
        If chk_permiss = True Then
            Dim dao_chk_fee As New DAO_FEE.TB_fee
            Dim dao_fee_m44 As New DAO_FEE.TB_fee
            dao_fee_m44.GetDataby_ref1_ref2(txt_ref01.Text, txt_ref02.Text)

            Dim lcnname As String = ""

            Try
                'lcnname = set_name_company(dao_fee_m44.fields.identify)

                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_re.Getdata_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
                dao_re.fields.FULLNAME = txt_name.Text
                dao_re.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งข้อมูลเรียบร้อย');", True)
            Catch ex As Exception

            End Try

        Else

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่มีสิทธิใช้งานระบบ');", True)
        End If
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = ""
        End Try

        Return fullname
    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim chk_permiss As Boolean = False

        Try
            chk_permiss = CHK_PERMISSION(_CLS.CITIZEN_ID)
        Catch ex As Exception

        End Try
        If chk_permiss = True Then
            Dim feeno_aray As String() = txt_ref01.Text.Split("/")
            Dim feeno As String = ""
            Try
                feeno = feeno_aray(1) & feeno_aray(0)
            Catch ex As Exception

            End Try
            Dim dao As New DAO_FEE.TB_fee
            dao.GetDataby_feeno(feeno)
            Dim lcnname As String = ""
            Dim e_receipt As String = ""
            Try
                'lcnname = set_name_company(dao.fields.identify)

                Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_re.Getdata_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
                dao_re.fields.FULLNAME = txt_name.Text 'lcnname
                e_receipt = dao_re.fields.FULL_RECEIVE_NUMBER

                dao_re.update()
                Dim util As New Report_Utility
                If e_receipt.Contains("E") Then
                    runpdf(getReportData_reciept_fda_v2(), util.root & "Module09\Report_R9_003_V3_01.rdlc", "Fields_Report_R9_003", txt_ref01.Text, txt_ref02.Text)
                End If

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งข้อมูลเรียบร้อย');", True)
            Catch ex As Exception

            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่มีสิทธิใช้งานระบบ');", True)
        End If


    End Sub

    Public Function getReportData_reciept_fda_v2()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        Dim receipt_num As String = ""

        Dim query_str As String = Request.QueryString("feeno")
        Dim decode_str As String = Request.QueryString("feeno").DecodeBase64
        Dim arr_query As String() = decode_str.Split("|")

        Dim fee_format As String = arr_query(0)
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(Request.QueryString("feeno"), Request.QueryString("feeabbr"))
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_receipt(Request.QueryString("feeno"))
        'dt = bao.SP_get_receipt_by_dvcd_and_feeno_receipt(fee_format, Request.QueryString("dvcd"))
        Dim dvcd As String = ""
        Dim feeabbr As String = ""
        'If IsNumeric(Server.UrlDecode(Request.QueryString("dvcd"))) = False Then
        '    dvcd = Server.UrlDecode(Request.QueryString("dvcd")).DecodeBase64
        'Else
        '    dvcd = Server.UrlDecode(Request.QueryString("dvcd"))
        'End If

        'If IsNumeric(Server.UrlDecode(Request.QueryString("feeabbr"))) = False Then
        '    feeabbr = Server.UrlDecode(Request.QueryString("feeabbr")).DecodeBase64
        'Else
        '    feeabbr = Server.UrlDecode(Request.QueryString("feeabbr"))
        'End If
        Dim is_l44 As Integer = 0
        Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        Dim dao_rd As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        Dim rcvno_txt As String = ""
        Try
            dao_re.Getdata_by_feeno(fee_format)
            is_l44 = dao_re.fields.IS_L44

            dao_rd.Getdata_by_RECEIVE_MONEY_ID(dao_re.fields.RECEIVE_MONEY_ID)
            rcvno_txt = dao_rd.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            dvcd = arr_query(1)
        Catch ex As Exception

        End Try
        Try
            feeabbr = arr_query(2)
        Catch ex As Exception

        End Try
        dt = bao.SP_GET_E_RECEIPT_IDV2(fee_format, dvcd, feeabbr)
        dt.Columns.Add("days", GetType(String))
        dt.Columns.Add("months", GetType(String))
        dt.Columns.Add("years", GetType(String))
        Dim days As String = Day(Date.Now)
        Dim years As Integer = 0
        years = Year(Date.Now)
        If years < 2500 Then
            years += 543
        End If
        Dim months As Integer = Month(Date.Now)
        Dim uti As New Report_Utility
        Dim str_month As String = ""
        str_month = uti.get_Long_month_BY_Number(months)

        Dim dt2 As New DataTable
        Dim bao2 As New BAO_BUDGET.Maintain
        'dt2 = bao2.SP_get_receipt_data_det_feeno_V2(Request.QueryString("id_feeno"))
        dt2 = bao2.SP_get_receipt_data_det_feeno_dvcd_feeabbrV2(fee_format, dvcd, feeabbr)


        dt2.Columns.Add("days")
        dt2.Columns.Add("years")
        dt2.Columns.Add("months")
        dt2.Columns.Add("item_c")
        dt2.Columns.Add("row2")
        dt2.Columns.Add("row3")

        Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
        Dim ii As Integer = 0
        Dim txt As String = ""
        Dim lcnno As String = ""
        Dim amt As Double = 0
        Dim dtl As String = ""
        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        Try
            dao.Getdata_by_feeno(fee_format)
        Catch ex As Exception

        End Try

        dao_det.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)

        For Each dao_det.fields In dao_det.datas
            ii += 1
            txt = dao_det.fields.TXT_LCNNO
            Dim code_txt As String = ""
            Dim rcvno As String = ""
            Dim rcvabbr As String = ""
            Dim appabbr As String = ""
            Dim lcnno_det As String = ""
            Try
                code_txt = dao_det.fields.CODE_TXT
            Catch ex As Exception

            End Try
            Try
                rcvno = dao_det.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno_det = dao_det.fields.LCNNO
            Catch ex As Exception

            End Try
            Try
                appabbr = dao_det.fields.appabbr
            Catch ex As Exception

            End Try
            Try
                rcvabbr = dao_det.fields.rcvabbr
            Catch ex As Exception

            End Try
            Try

                'If lcnno_det <> "" And Len(lcnno_det) > 6 Then
                '    If lcnno = "" Then
                '        lcnno = appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                '    Else
                '        lcnno &= " ," & appabbr & " " & CInt(Right(dao_det.fields.LCNNO, 5)) & "/25" & Left(dao_det.fields.LCNNO, 2)
                '    End If
                'Else
                '    If lcnno = "" Then
                '        lcnno = rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                '    Else
                '        lcnno &= " ," & rcvabbr & " " & CInt(Right(dao_det.fields.rcvno, 5)) & "/25" & Left(dao_det.fields.rcvno, 2)
                '    End If
                'End If
                'For Each dr As DataRow In dt2.Rows
                '    'dr("item_c") = ii
                '    'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
                '    dr("row3") = lcnno
                'Next
            Catch ex As Exception

            End Try


            Try
                amt = dao_det.fields.AMOUNT
            Catch ex As Exception

            End Try
            Try
                dtl = dao_det.fields.TXT_LCNNO
            Catch ex As Exception

            End Try


        Next
        'If ii > 0 And ii <= 1 Then
        '    For Each dr As DataRow In dt2.Rows
        '        dr("feetpnm") &= " " & txt & " " & lcnno
        '        dr("item_c") = ii
        '    Next
        'Else
        If is_l44 = 1 Then
            If Right(rcvno_txt, 1) = "R" Then
                dtl = "เลขรับคำร้องที่"
            ElseIf Right(rcvno_txt, 1) = "C" Then
                dtl = "เลขตรวจคำขอที่"
            ElseIf Right(rcvno_txt, 1) = "A" Then
                dtl = "เลขรับประเมินคำขอที่"
            End If
        End If
        For Each dr As DataRow In dt2.Rows
            'dr("item_c") = ii
            'dr("row2") = "(จำนวน " & ii & " ฉบับ ฉบับละ " & amt.ToString("N") & " บาท)"
            If is_l44 = 1 Then
                dr("row3") = dtl & " " & rcvno_txt
            Else
                dr("row3") = dtl & " " & lcnno
            End If

        Next
        ' End If

        dt = dt2

        For Each dr As DataRow In dt.Rows
            Try
                dr("days") = Day(CDate(dr("MONEY_RECEIVE_DATE")))
                dr("years") = IIf(Year(CDate(dr("MONEY_RECEIVE_DATE"))) < 2500, Year(DateAdd(DateInterval.Year, 543, CDate(dr("MONEY_RECEIVE_DATE")))), Year(CDate(dr("MONEY_RECEIVE_DATE"))))

                Dim uti2 As New Report_Utility
                Dim str_month2 As String = ""
                str_month2 = uti2.get_Long_month_BY_Number(Month(CDate(dr("MONEY_RECEIVE_DATE"))))
                dr("months") = str_month2
            Catch ex As Exception

            End Try

            Dim dao3 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            Try
                dao3.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("id_feeno"))

                If dao3.fields.RECEIVE_MONEY_TYPE = 2 Then
                    Dim dao_b As New DAO_MAS.TB_MAS_BANK
                    Try
                        dao_b.Getdata_by_BANK_ID(dao3.fields.BANK_ID)
                        dr("row3") &= " (เช็คธนาคาร " & dao_b.fields.BANK_SHORT_NAME & " เลขที่ " & dao3.fields.CHECK_NUMBER & " )"
                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception

            End Try

            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_feeno(fee_format)

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

            Dim url2 As String = "https://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64

            Dim Cls_qr As New QR_CODE.GEN_QR_CODE

            Dim ws_qrs As New WS_QR.WS_QR
            Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2) 'ws_qrs.QR_CODE_B64(url2) ' 

            dr("QR_IMAGE_BYTE") = img_byte
        Next

        Return dt
    End Function
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String, ByVal ref01 As String, ByVal ref02 As String)
        Dim rsw As New LocalReport
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource

        reportdatasource.Value = dt1
        reportdatasource.Name = report_datasource
        rsw.DataSources.Add(reportdatasource)


        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)

        Dim clsds As New ClassDataset


        clsds.bynaryToobject(Server.MapPath("../PDF/") & ref02 & ".pdf", renderedbytes)

        ' Response.Redirect("../PDF/" & ref02 & ".pdf")

    End Sub
End Class