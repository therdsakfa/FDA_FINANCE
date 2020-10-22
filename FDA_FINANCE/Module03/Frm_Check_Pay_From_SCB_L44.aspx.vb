Imports System.IO
Imports Telerik.Web.UI
Public Class Frm_Check_Pay_From_SCB_L44
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString()
            bind_ddl_receiver()

            Dim dao_re As New DAO_MAS.TB_MAS_MONEY_RECEIVER
            Try
                dao_re.Getdata_by_iden(_CLS.CITIZEN_ID)
                lbl_receiver.Text = dao_re.fields.RECEIVER_NAME
            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Upload_and_insert()
        RadGrid1.Rebind()
    End Sub
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
    Public Sub update_chk_receipt()
        For Each item As GridDataItem In RadGrid1.SelectedItems
            Dim ws_dt As New WS_OLD_DT
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
            count_fee_new = dao_chk_fee.Countby_ref1_ref2(item("ref01").Text, item("ref02").Text)
            dao_fee_m44.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
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
            '----เช็คว่ายังไม่จ่าย
            If fee_stat = 1 Or fee_stat = 0 Then

                If count_fee_new > 0 Then
                    Dim dao_fee_new As New DAO_FEE.TB_fee
                    dao_fee_new.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                    dvcd = dao_fee_new.fields.dvcd
                    feeno = dao_fee_new.fields.feeno
                    feeabbr = dao_fee_new.fields.feeabbr
                Else
                    Dim dt_c As New DataTable
                    Dim bao_fo As New BAO_BUDGET.FDA_FEE
                    dt_c = bao_fo.SP_get_receipt_by_ref01_ref02(item("ref01").Text, item("ref02").Text)
                    For Each dr As DataRow In dt_c.Rows
                        dvcd = dr("dvcd")
                        feeno = dr("feeno")
                        feeabbr = dr("feeabbr")
                    Next
                End If


                Try
                    'dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
                    If dao_fee_m44.fields.IDA = 0 Then
                        dt_d = ws_dt.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
                        If dt_d.Rows.Count > 0 Then
                            is_old = True
                        End If
                    End If

                Catch ex As Exception

                End Try
                If dt_d.Rows.Count = 0 Then
                    If l44 = False Then
                        If dept = 2 Then
                            Dim bao2 As New BAO_NCT2.LGT_NCT2
                            dt_d = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, dvcd)
                        Else
                            dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, dvcd)
                        End If
                    Else
                        dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44(feeno, dvcd)
                    End If

                End If
                Dim bool As Boolean = False
                insert_e_bill(dvcd, feeno, feeabbr, l44, item("ref01").Text, item("ref02").Text)
                Try
                    Dim dao As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                    dao.GetDataby_IDA(item("IDA").Text)

                    Try
                        bool = dao.fields.CHECK_STATUS
                    Catch ex As Exception

                    End Try
                    If bool = False Then
                        Try
                            dao.fields.CHECK_DATE = CDate(txt_date.Text)
                        Catch ex As Exception
                            dao.fields.CHECK_DATE = Date.Now
                        End Try
                        dao.fields.CHECK_STATUS = 1
                        dao.fields.AMOUNT = item("amount_scb").Text
                        dao.fields.CHECKER_ID = Get_Checker_ID(_CLS.CITIZEN_ID)

                        dao.update()

                        If fee_stat = 0 Then
                            Dim dao_fee As New DAO_FEE.TB_fee
                            dao_fee.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                            dao_fee.fields.rcptst = 1
                            dao_fee.update()


                            Dim cls_update As New CLS_SV_UPDATE_SYS.SV_UPDATE
                            cls_update.Update_Sys(dvcd, item("ref02").Text, item("ref01").Text, is_repeat:=True)
                        End If

                    End If

                Catch ex As Exception

                End Try

                '-----------------------ส่งค่า update สถานะ
                Dim process_da As String = "0"
                Dim fee_format As String = "0"
                Dim dao_fee1 As New DAO_FEE.TB_fee
                dao_fee1.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                Dim dao_det1 As New DAO_FEE.TB_feedtl
                Try
                    fee_format = dao_fee1.fields.feeno
                Catch ex As Exception

                End Try
                Try
                    dao_det1.GetDataby_fk_fee(dao_fee1.fields.IDA)
                    process_da = dao_det1.fields.process_id
                Catch ex As Exception

                End Try

                '--------------------------update ให้ระบบอื่นๆ กรณี key in-----------------------------------------------------
                If fee_stat = 0 Or fee_stat = 1 Then
                    Try
                        If fee_stat = 0 Then
                            Dim dao_fee As New DAO_FEE.TB_fee
                            dao_fee.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                            dao_fee.fields.rcptst = 1
                            dao_fee.update()
                        End If
                        'Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
                        'ws_updates.Update_Status_Pay(item("ref01").Text, item("ref02").Text)





                    Catch ex As Exception

                    End Try


                End If
                '----------------------------------------จบอัพเดท-

                'Else
                Dim feeabbr_u As String = ""
                Dim acc_type As Integer = 0
                Dim citizen_fee As String = ""
                Try

                    Dim dao_fee5 As New DAO_FEE.TB_fee
                    dao_fee5.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
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
                    Dim dao_fee_det As New DAO_FEE.TB_feedtl
                    dao_fee_det.Getdata_by_fee_id(dao_fee5.fields.IDA)
                    'For Each dao_fee_det.fields In dao_fee_det.datas
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
                        dao_spay.GetDataby_IDA(dao_fee_det.fields.fk_id)
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pay.GetDataby_IDA(dao_fee_det.fields.fk_id)
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
                            Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & item("ref01").Text & "&ref02=" & item("ref02").Text

                            SendMail(Content, email, Title, email, "", "")
                        End If
                    Catch ex As Exception
                        Insert_log_error(item("ref01").Text, item("ref02").Text, "SendMail " & ex.Message, 0)
                    End Try


                    'End If

                    'Next


                Catch ex As Exception

                End Try


            End If

        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ตรวจสอบข้อมูลเรียบร้อย');", True)
    End Sub

    Public Sub SendMail_CC_ATTACH(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email


        mm.SendMail_CC_ATTACH(mcontent, CC, string_xml, filename)

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
    Sub bind_ddl_receiver()
        'Dim dao As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        'dao.Get_All_RECEIVER()

        'ddl_receiver.DataSource = dao.datas
        'ddl_receiver.DataTextField = "RECEIVER_NAME"
        'ddl_receiver.DataValueField = "RECEIVER_MONEY_ID"
        'ddl_receiver.DataBind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "_receipt" Then
                Dim dao_fee As New DAO_FEE.TB_fee
                dao_fee.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                Dim l44 As Boolean = False
                If dao_fee.fields.acc_type = 2 Then
                    l44 = True
                End If
                Dim dao_scb As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                dao_scb.GetDataby_IDA(item("IDA").Text)
                dao_scb.fields.PRINT_STAMP = 1
                dao_scb.fields.PRINT_DATE = Date.Now
                dao_scb.update()
                'insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, l44, item("ref01").Text, item("ref02").Text, is_new_chk:="1")
                'send_mail_mini(item("ref01").Text, item("ref02").Text)

                Try
                    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    dao.Getdata_by_ref01_ref02(item("ref01").Text, item("ref02").Text)

                    'Dim feeno_re As String = ""
                    'feeno_re = dao.fields.FEENO.EncodeBase64()
                    'Dim dvcd_re As String = ""
                    'dvcd_re = CStr(dao.fields.DVCD).EncodeBase64()
                    'Dim feebbr_re As String = ""
                    'feebbr_re = dao.fields.FEEABBR.EncodeBase64()
                    'Dim bgYear_re As String = ""
                    'bgYear_re = CStr(dao.fields.BUDGET_YEAR).EncodeBase64()
                    'Dim lcnsid As String = ""
                    'lcnsid = CStr(dao.fields.LCNSID).EncodeBase64()
                    Dim querystr As String = ""
                    Dim feeno_re As String = ""
                    feeno_re = dao.fields.FEENO
                    Dim dvcd_re As String = ""
                    dvcd_re = CStr(dao.fields.DVCD)
                    Dim feebbr_re As String = ""
                    feebbr_re = dao.fields.FEEABBR
                    Dim bgYear_re As String = ""
                    bgYear_re = CStr(dao.fields.BUDGET_YEAR)
                    querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re



                    Dim url_p As String = ""
                    'url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64
                    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?ref01=" & item("ref01").Text & "&ref02=" & item("ref02").Text
                    'url_p = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & feeno_re & "&feeabbr=" & _
                    '               feebbr_re & "&lcnsid=" & lcnsid & "&dvcd=" & dvcd_re
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)

                Catch ex As Exception

                End Try
                
            ElseIf e.CommandName = "_cancel" Then
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao.Getdata_by_ref01_ref02(item("ref01").Text, item("ref02").Text)

                Dim dao_ck As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                dao_ck.GetDataby_IDA(item("IDA").Text)
                dao_ck.fields.CHECK_STATUS = 2
                Try
                    dao_ck.fields.CHECK_DATE = CDate(txt_date.Text)
                Catch ex As Exception

                End Try
                dao_ck.update()

                dao.fields.IS_CANCEL = True
                Try
                    dao.fields.CANCEL_DATE = CDate(txt_date.Text)
                Catch ex As Exception

                End Try
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');", True)
            End If
        End If
    End Sub
    Sub send_mail_mini(ByVal ref01 As String, ByVal ref02 As String)
        Try
            Dim citizen_fee As String = ""
            Dim dao_fee5 As New DAO_FEE.TB_fee
            dao_fee5.GetDataby_ref1_ref2(ref01, ref02)

            Dim dao_fee_det As New DAO_FEE.TB_feedtl
            dao_fee_det.Getdata_by_fee_id(dao_fee5.fields.IDA)

            Dim email As String = ""
            Dim Title As String = ""
            Dim Content As String = ""
            Dim dao_mail As New DAO_CPN.TB_sysemail
            Try
                citizen_fee = dao_fee5.fields.create_identify
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
                    Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & ref01 & "&ref02=" & ref02

                    SendMail(Content, email, Title, email, "", "")
                End If
            Catch ex As Exception
                Insert_log_error(ref01, ref02, "SendMail " & ex.Message, 0)
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim btn_review As LinkButton = DirectCast(item("btn_receipt").Controls(0), LinkButton)
            Dim IDA As String = item("IDA").Text
            Dim dao As New DAO_MAS.TB_LOG_PAY_FROM_SCB
            dao.GetDataby_IDA(IDA)
            btn_review.Style.Add("display", "none")
            Dim check_stat As String = ""
            Try
                check_stat = dao.fields.CHECK_STATUS
            Catch ex As Exception

            End Try
            If check_stat = "1" Then
                btn_review.Style.Add("display", "block")
            End If
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        dt = bao.Get_LOG_PAY_FROM_SCB_L44()
        'dt = bao.Get_LOG_PAY_FROM_SCB_V2()
        For Each dr As DataRow In dt.Rows
            If Len(dr("feeno_format").ToString()) = 0 Then
                Dim bao_2 As New BAO_BUDGET.FDA_FEE
                Dim dt2 As New DataTable
                dt2 = bao_2.Q_get_old_fee(dr("ref01"), dr("ref02"))
                Try
                    dr("feeno_format") = dt2(0)("feeno_format")
                Catch ex As Exception

                End Try

            End If
        Next

        RadGrid1.DataSource = dt
    End Sub

    'Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String)
    '    Dim dt As New DataTable
    '    Dim bao As New BAO_FEE.FEE
    '    Dim receipt_num As String = ""
    '    ' Dim fee_format As String = feeno_format(feeno)
    '    Dim fk_fee As Integer = 0
    '    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum3(feeno, dvcd, feeabbr)

    '    Dim str_fullname As String = ""
    '    'Try
    '    '    str_fullname = dt(0)("fullname")
    '    'Catch ex As Exception

    '    'End Try

    '    Try
    '        Dim dao_fee_nm As New DAO_FEE.TB_fee
    '        dao_fee_nm.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(feeno, dvcd, feeabbr, dt(0)("pvncd"))
    '        Try
    '            str_fullname = dao_fee_nm.fields.company_name
    '        Catch ex As Exception

    '        End Try
    '    Catch ex As Exception

    '    End Try

    '    If str_fullname = "" Then
    '        Try
    '            Dim bao_name As New BAO_FEE.FEE
    '            If dt(0)("prnfeest") = "1" Then
    '                str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
    '            Else
    '                str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End If

    '    Dim count_bg As Integer = 0
    '    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '    count_bg = dao.count_receipt4(dvcd, feeno, feeabbr)
    '    If count_bg = 0 Then
    '        Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '        dao_i.fields.RECEIVE_MONEY_TYPE = 1
    '        dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
    '        dao_i.fields.FULLNAME = str_fullname
    '        dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")

    '        dao_i.fields.RECEIVER_MONEY_ID = ddl_receiver.SelectedValue
    '        dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
    '        dao_i.fields.DEPARTMENT_ID = 0
    '        dao_i.fields.ORDER_PAY1 = feeabbr
    '        dao_i.fields.ORDER_PAY2 = feeno
    '        dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
    '        dao_i.fields.FEEABBR = feeabbr
    '        dao_i.fields.FEENO = feeno
    '        dao_i.fields.LCNSID = dt(0)("lcnsid")
    '        dao_i.fields.BUDGET_YEAR = Get_BUDGET_YEAR()
    '        dao_i.fields.RECEIPT_TYPE = 1
    '        dao_i.fields.REF01 = dt(0)("ref01")
    '        dao_i.fields.REF02 = dt(0)("ref02")
    '        dao_i.fields.MONEY_TYPE_ID = 1
    '        dao_i.fields.DVCD = dvcd

    '        Dim bao2 As New BAO_BUDGET.Maintain
    '        Dim max_id As Integer = 0
    '        Dim str_num As String = ""
    '        Try
    '            max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 2)
    '            max_id += 1
    '            str_num = String.Format("{0:0000000000}", max_id.ToString("0000000000"))
    '        Catch ex As Exception

    '        End Try
    '        dao_i.fields.E_RUNNING_RECEIPT = max_id
    '        dao_i.fields.FULL_RECEIVE_NUMBER = "E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
    '        dao_i.insert()

    '        Dim re_id As Integer = 0
    '        Try
    '            re_id = dao_i.fields.RECEIVE_MONEY_ID
    '        Catch ex As Exception

    '        End Try

    '        Dim dt_det As New DataTable
    '        Dim bao_dett As New BAO_FEE.FEE
    '        Dim dao_fee3 As New DAO_FEE.TB_fee
    '        dao_fee3.Getdata_by_feeno_and_dvcd(feeno, dvcd)
    '        Try
    '            fk_fee = dao_fee3.fields.IDA
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE(fk_fee)
    '        Catch ex As Exception

    '        End Try
    '        For Each dr As DataRow In dt_det.Rows
    '            Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
    '            dao_det.fields.FK_IDA = re_id
    '            Try
    '                dao_det.fields.AMOUNT = dr("amt")
    '            Catch ex As Exception
    '                dao_det.fields.AMOUNT = 0
    '            End Try
    '            Try
    '                dao_det.fields.FEEABBR = dr("feeabbr") 'ddl_abbr_type.SelectedValue
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                dao_det.fields.LCNNO = dr("appvno")
    '            Catch ex As Exception

    '            End Try
    '            dao_det.fields.TABEAN_NUMBER = ""
    '            Try
    '                dao_det.fields.TXT_LCNNO = dr("feedtl")
    '            Catch ex As Exception

    '            End Try

    '            Try
    '                dao_det.fields.rcvabbr = dr("rcvabbr")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                dao_det.fields.rcvcd = dr("rcvcd")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                dao_det.fields.rcvno = dr("rcvno")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                dao_det.fields.appabbr = dr("appabbr")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                dao_det.fields.appvcd = dr("appvcd")
    '            Catch ex As Exception

    '            End Try

    '            dao_det.insert()
    '        Next
    '    End If
    'End Sub

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

    Private Sub btn_check_Click(sender As Object, e As EventArgs) Handles btn_check.Click
        Try
            RunSession()
            Dim id_re As Integer = 0
            Try
                id_re = Get_Checker_ID(_CLS.CITIZEN_ID)
            Catch ex As Exception

            End Try
            If id_re = 0 Then
                Response.Redirect("http://privus.fda.moph.go.th/", False)
            Else
                'update_chk_receipt()
                update_chk_new()
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/", False)
        End Try
        RadGrid1.Rebind()
    End Sub

    Sub update_chk_new()
        For Each item As GridDataItem In RadGrid1.SelectedItems
            'Dim l44 As Boolean = False
            Dim dvcd As String = ""
            Dim dao_chk_fee As New DAO_FEE.TB_fee
            Dim count_fee_new As Integer = 0
            Dim dao_fee_m44 As New DAO_FEE.TB_fee
            count_fee_new = dao_chk_fee.Countby_ref1_ref2(item("ref01").Text, item("ref02").Text)
            dao_fee_m44.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
            Dim fee_stat As Integer = 0
            'Try
            '    If dao_fee_m44.fields.acc_type = 2 Then
            '        l44 = True
            '    End If
            'Catch ex As Exception

            'End Try
            Try
                dvcd = dao_fee_m44.fields.dvcd
            Catch ex As Exception

            End Try
            Try
                fee_stat = dao_fee_m44.fields.rcptst
            Catch ex As Exception

            End Try

            If fee_stat = 1 Or fee_stat = 0 Then
                Try
                    Dim dao As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                    dao.GetDataby_IDA(item("IDA").Text)
                    Dim bool As Boolean = False
                    Try
                        bool = dao.fields.CHECK_STATUS
                    Catch ex As Exception

                    End Try
                    If bool = False Then
                        Try
                            dao.fields.CHECK_DATE = CDate(txt_date.Text)
                        Catch ex As Exception
                            dao.fields.CHECK_DATE = Date.Now
                        End Try
                        dao.fields.CHECK_STATUS = 1
                        dao.fields.AMOUNT = item("amount_scb").Text
                        dao.fields.CHECKER_ID = Get_Checker_ID(_CLS.CITIZEN_ID)

                        dao.update()

                        'If fee_stat = 0 Then
                        '    Dim dao_fee As New DAO_FEE.TB_fee
                        '    dao_fee.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                        '    dao_fee.fields.rcptst = 1
                        '    dao_fee.update()
                        'End If


                        '--------------------------update ให้ระบบอื่นๆ กรณี key in-----------------------------------------------------

                        Try
                            If fee_stat = 0 Then
                                Dim dao_fee As New DAO_FEE.TB_fee
                                dao_fee.GetDataby_ref1_ref2(item("ref01").Text, item("ref02").Text)
                                dao_fee.fields.rcptst = 1
                                dao_fee.update()

                                Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
                                ws_updates.Update_Status_Pay(item("ref01").Text, item("ref02").Text)

                                Dim ws_updates2 As New WS_UPDATE_PAY_HERB.WS_UPDATE_STATUS_PAY
                                ws_updates2.Update_Status_Pay(item("ref01").Text, item("ref02").Text)
                            End If


                            'Dim cls_update As New CLS_SV_UPDATE_SYS.SV_UPDATE
                            'cls_update.Update_Sys(dvcd, item("ref02").Text, item("ref01").Text, is_repeat:=True)

                        Catch ex As Exception

                        End Try

                        '----------------------------------------จบอัพเดท-



                    End If

                Catch ex As Exception
                    Insert_log_error(item("ref01").Text, item("ref02").Text, ex.Message & " " & "กดตรวจใบสั่ง", 0)
            End Try
            End If

        Next
    End Sub

    Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String, ByVal is_m44 As Boolean _
                      , Optional ref01 As String = "", Optional ref02 As String = "", Optional is_new_chk As String = "")
        Dim ws_dt As New WS_OLD_DT
        Dim dt As New DataTable
        Dim bao As New BAO_FEE.FEE
        Dim bao_d As New BAO_BUDGET.FDA_FEE
        Dim receipt_num As String = ""
        ' Dim fee_format As String = feeno_format(feeno)
        Dim fk_fee As Integer = 0
        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum3(feeno, dvcd, feeabbr)

        Dim str_fullname As String = ""

        If dt.Rows.Count = 0 Then
            Try
                'dt = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
                'dt = ws_dt.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
            Catch ex As Exception

            End Try
        End If

        Try
            Dim dao_fee_nm As New DAO_FEE.TB_fee
            dao_fee_nm.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(feeno, dvcd, feeabbr, dt(0)("pvncd"))
            Try
                str_fullname = dao_fee_nm.fields.company_name
            Catch ex As Exception

            End Try
            If str_fullname = "" Then
                Try
                    Dim bao_name As New BAO_BUDGET.FDA_FEE
                    If dt(0)("prnfeest") = "1" Then
                        'str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                        str_fullname = ws_dt.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    Else
                        'str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                        str_fullname = ws_dt.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

        'If str_fullname = "" Then
        '    Try
        '        Dim bao_name As New BAO_FEE.FEE
        '        If dt(0)("prnfeest") = "1" Then
        '            str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
        '        Else
        '            str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
        '        End If
        '    Catch ex As Exception

        '    End Try
        'End If

        Dim count_bg As Integer = 0
        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'If is_m44 = True Then
        '    count_bg = dao.count_receipt_M44_E(dvcd, feeno, feeabbr)
        'Else
        '    count_bg = dao.count_receipt4(dvcd, feeno, feeabbr)
        'End If
        count_bg = dao.count_receipt_by_ref_E(ref01, ref02)
        If count_bg = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 5
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = str_fullname
            dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
            Try
                dao_i.fields.RECEIVER_MONEY_ID = Get_Checker_ID(_CLS.CITIZEN_ID)
            Catch ex As Exception

            End Try

            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = feeabbr
            dao_i.fields.ORDER_PAY2 = feeno
            'If is_new_chk <> "" Then
            '    Dim dao_scb As New DAO_MAS.TB_LOG_PAY_FROM_SCB
            '    dao_scb.Get_data_by_ref01_ref02(ref01, ref02)
            '    Try
            '        dao_i.fields.MONEY_RECEIVE_DATE = CDate(dao_scb.fields.CHECK_DATE)
            '    Catch ex As Exception

            '    End Try
            'Else
            dao_i.fields.MONEY_RECEIVE_DATE = CDate(txt_date.Text)
            'End If

            dao_i.fields.FEEABBR = feeabbr
            dao_i.fields.FEENO = feeno
            dao_i.fields.LCNSID = dt(0)("lcnsid")
            dao_i.fields.BUDGET_YEAR = Get_BUDGET_YEAR()

            dao_i.fields.IS_APPROVE = True
            Try
                dao_i.fields.APPROVE_DATE = CDate(txt_date.Text)
            Catch ex As Exception
                dao_i.fields.APPROVE_DATE = Date.Now
            End Try
            dao_i.fields.REF01 = dt(0)("ref01")
            dao_i.fields.REF02 = dt(0)("ref02")
            dao_i.fields.MONEY_TYPE_ID = 1
            dao_i.fields.DVCD = dvcd
            If is_m44 = True Then
                dao_i.fields.IS_L44 = 1
                dao_i.fields.RECEIPT_TYPE = 5
                dao_i.fields.INCOME_IDA = 48
            Else
                dao_i.fields.INCOME_IDA = 1
                dao_i.fields.RECEIPT_TYPE = 1
            End If

            Dim bao2 As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Dim str_num As String = ""
            Dim max_id_new As Integer = 0

            max_id_new = Get_Max_NO(is_m44, Get_BUDGET_YEAR())
            'Try
            '    If is_m44 = False Then
            '        max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 2)
            '    Else
            '        max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 4)
            '    End If
            '    max_id += 1
            str_num = String.Format("{0:0000000000}", max_id_new.ToString("0000000000"))
            'Catch ex As Exception

            'End Try
            'dao_i.fields.E_RUNNING_RECEIPT = max_id
            'If is_m44 = False Then
            '    dao_i.fields.FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            'Else
            '    dao_i.fields.FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            'End If
            Dim FULL_RECEIVE_NUMBER As String
            If is_m44 = False Then
                FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            Else
                FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            End If
            Dim bools As Boolean
            bools = CHK_MAX_NO_INSERT(FULL_RECEIVE_NUMBER)

            If bools = True Then
                dao_i.fields.E_RUNNING_RECEIPT = max_id_new
                dao_i.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER

            Else 'กรณีซ้ำ รันใหม่
                max_id_new = Get_Max_NO(is_m44, Get_BUDGET_YEAR())
                max_id_new = max_id_new + 1

                str_num = String.Format("{0:0000000000}", max_id_new.ToString("0000000000"))

                If is_m44 = False Then
                    FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
                Else
                    FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
                End If
                bools = CHK_MAX_NO_INSERT(FULL_RECEIVE_NUMBER)

                If bools = True Then
                    dao_i.fields.E_RUNNING_RECEIPT = max_id_new
                    dao_i.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER

                Else
                    max_id_new = Get_Max_NO(is_m44, Get_BUDGET_YEAR())
                    max_id_new = max_id_new + 1

                    str_num = String.Format("{0:0000000000}", max_id_new.ToString("0000000000"))

                    If is_m44 = False Then
                        FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
                    Else
                        FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
                    End If

                    dao_i.fields.E_RUNNING_RECEIPT = max_id_new
                    dao_i.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER
                End If
            End If

            dao_i.insert()


            Dim re_id As Integer = 0
            Try
                re_id = dao_i.fields.RECEIVE_MONEY_ID
            Catch ex As Exception

            End Try

            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_RECEIVE_MONEY_ID(re_id)
            '_url_qr = "http://164.115.28.103/fda_budget/Module03/Frm_Maintain_Receive_Money_L44.aspx?id_feeno=" & re_id

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

            Dim url2 As String = "https://buisead.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'feeno=" & feeno_re & "&dvcd=" & dvcd_re & "&feeabbr=" & feebbr_re & "&myear=" & bgYear_re


            'RadBarcode1.DataBind()
            'Dim image As System.Drawing.Image = RadBarcode1.GetImage()
            'Dim data As Byte()
            'data = ImageToByteArray(image)


            Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            'Dim img_byte As String = Cls_qr.QR_CODE(url2) 'Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

            Dim ws_qrs As New WS_QR.WS_QR
            Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2) 'ws_qrs.QR_CODE_B64(url2) ' 


            'Dim dao_i2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao_i2.Getdata_by_RECEIVE_MONEY_ID(re_id)
            'dao_i2.fields.QR_IMAGE_BYTE = img_byte
            'dao_i2.update()

            Dim dt_det As New DataTable
            Dim bao_dett As New BAO_FEE.FEE
            Dim dao_fee3 As New DAO_FEE.TB_fee
            'dao_fee3.Getdata_by_feeno_and_dvcd(feeno, dvcd)
            dao_fee3.GetDataby_ref1_ref2(ref01, ref02)
            Try
                fk_fee = dao_fee3.fields.IDA
            Catch ex As Exception

            End Try
            If is_m44 = True Then
                Try
                    dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE_V2(fk_fee)
                Catch ex As Exception

                End Try
            Else
                Try
                    dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE(fk_fee)
                Catch ex As Exception

                End Try
            End If

            Dim bao_det As New BAO_BUDGET.FDA_FEE
            If dt_det.Rows.Count = 0 Then
                'dt_det = bao_det.SP_GET_FEEDTL_OLD(feeno, dvcd, dt(0)("pvncd"), feeabbr)
                'dt_det = ws_dt.SP_GET_FEEDTL_OLD(feeno, dvcd, dt(0)("pvncd"), feeabbr)
            End If
            For Each dr As DataRow In dt_det.Rows
                Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                dao_det.fields.FK_IDA = re_id
                Try
                    dao_det.fields.AMOUNT = dr("amt")
                Catch ex As Exception
                    dao_det.fields.AMOUNT = 0
                End Try
                Try
                    dao_det.fields.FEEABBR = dr("feeabbr") 'ddl_abbr_type.SelectedValue
                Catch ex As Exception

                End Try
                'Try
                '    dao_det.fields.LCNNO = dr("appvno")
                'Catch ex As Exception

                'End Try
                dao_det.fields.TABEAN_NUMBER = ""
                Try
                    dao_det.fields.TXT_LCNNO = dr("feedtl")
                Catch ex As Exception

                End Try

                Try
                    dao_det.fields.rcvabbr = dr("rcvabbr")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.rcvcd = dr("rcvcd")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.rcvno = dr("rcvno")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.appabbr = dr("appabbr")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.appvcd = dr("appvcd")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.LCNNO = dr("lcnno_convert")
                Catch ex As Exception

                End Try
                Try
                    dao_det.fields.DESCRIPTIONS = dr("feetpnm")
                Catch ex As Exception

                End Try
                dao_det.insert()
            Next
        End If
    End Sub
    Private Sub Upload_and_insert()
        Dim fu As FileUpload = FileUpload1
        Dim textLine As String
        Dim dt As New DataTable
        dt.Columns.Add("col1")
        dt.Columns.Add("col2")
        dt.Columns.Add("col3")
        dt.Columns.Add("col4")
        dt.Columns.Add("col5")

        If fu.HasFile Then
            Dim reader As New StreamReader(fu.FileContent, System.Text.Encoding.ASCII)

            Do

                ' do your coding 
                'Loop trough txt file and add lines to ListBox1  
                Dim ref01 As String = ""
                Dim ref02 As String = ""
                textLine = reader.ReadLine()
                Dim dr As DataRow = dt.NewRow()
                Dim aaa As String() = Nothing
                Dim bba As String = ""
                Dim cleanedString As String = ""
                Dim col4 As String = ""
                Dim col5 As String = ""
                Try
                    bba = System.Text.RegularExpressions.Regex.Replace(textLine, "\s+", "|")
                    aaa = bba.Split("|")
                    'bba = strFixTab(textLine)
                Catch ex As Exception

                End Try
                Dim left_text As String = ""
                Try
                    left_text = Left(aaa(0), 1)
                Catch ex As Exception

                End Try
                ref01 = Trim(Right(Left(textLine, 104), 20))
                ref02 = Trim(Right(Left(textLine, 124), 20))

                'Dim initialString As String = textLine
                'Dim nonNumericCharacters As New System.Text.RegularExpressions.Regex("\D")
                'Dim numericOnlyString As String = nonNumericCharacters.Replace(initialString, String.Empty)
                col4 = Trim(Right(Left(textLine, 202), 58))
                col5 = Trim(Right(textLine, 13))
                If left_text = "D" Then
                    Dim col1 As String = "" 'aaa(0)
                    'Dim len_col1 As Integer = Len(col1)
                    col1 = Trim(textLine.Substring(0, 84))

                    Try
                        dr("col1") = col1
                    Catch ex As Exception

                    End Try
                    If col4.Contains("1810CNET") Then
                        Try
                            'ref01
                            dr("col2") = ref02

                        Catch ex As Exception

                        End Try
                        Try
                            'ref02
                            dr("col3") = ref01

                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            'ref01
                            dr("col2") = ref01

                        Catch ex As Exception

                        End Try
                        Try
                            'ref02
                            dr("col3") = ref02

                        Catch ex As Exception

                        End Try
                    End If
                    'Try
                    '    'ref01
                    '    dr("col2") = ref01

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    'ref02
                    '    dr("col3") = ref02

                    'Catch ex As Exception

                    'End Try
                    Try
                        dr("col4") = col4

                    Catch ex As Exception

                    End Try
                    Try
                        dr("col5") = col5
                    Catch ex As Exception

                    End Try

                    Dim dao As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                    Dim bool As Boolean = False
                    'If len_col1 > 34 Then
                    '    bool = dao.Count_data_by_ref01_ref02(aaa(3), aaa(4))
                    'Else
                    If col4.Contains("1810CNET") Then
                        bool = dao.Count_data_by_ref01_ref02(ref02, ref01)
                    Else
                        bool = dao.Count_data_by_ref01_ref02(ref01, ref02)
                    End If


                    'bool = dao.Count_data_by_ref01_ref02(ref01, ref02)
                    ' End If

                    If bool = False Then
                        Dim dao_log As New DAO_MAS.TB_LOG_PAY_FROM_SCB
                        With dao_log.fields
                            .AMOUNT = 0
                            .COL1 = col1
                            If col4.Contains("1810CNET") Then
                                .COL2 = ref02
                                .COL3 = ref01
                            Else
                                .COL2 = ref01
                                .COL3 = ref02
                            End If

                            .COL4 = col4
                            .COL5 = col5

                            .UPLOAD_DATE = Date.Now
                            Dim date_text As String = ""
                            Try
                                date_text = Right(Left(col1, 28), 8)
                            Catch ex As Exception

                            End Try

                            Dim date_full As String = ""
                            Try
                                date_full = Left(date_text, 2) & "/" & Right(Left(date_text, 4), 2) & "/" & (Right(Left(date_text, 8), 4) + 543)
                                .DATA_DATE = CDate(date_full)
                            Catch ex As Exception

                            End Try
                            Try
                                dao_log.fields.CITIZEN_UPLOAD = _CLS.CITIZEN_ID
                            Catch ex As Exception

                            End Try

                            Dim dao_fee As New DAO_FEE.TB_fee
                            If col4.Contains("1810CNET") Then
                                dao_fee.GetDataby_ref1_ref2(ref02, ref01)
                            Else
                                dao_fee.GetDataby_ref1_ref2(ref01, ref02)
                            End If

                            dao_fee.fields.rcptst = 3
                            'dao_fee.update()
                        End With

                        dao_log.insert()
                    End If
                    dt.Rows.Add(dr)

                End If

            Loop While reader.Peek() <> -1
            reader.Close()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดข้อมูลเรียบร้อย');", True)
        End If
    End Sub
    
    Protected Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim bao As New BAO_BUDGET.Report
        Dim dt As New DataTable
        Try
            dt = bao.GET_Check_Pay_From_SCB_L44(CDate(txt_date.Text))
        Catch ex As Exception

        End Try
        For Each dr As DataRow In dt.Rows
            Try
                Dim dao_fee As New DAO_FEE.TB_fee
                dao_fee.GetDataby_ref1_ref2(dr("COL2"), dr("COL3"))
                insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, True, dr("COL2"), dr("COL3"), "1")

                send_mail_mini(dr("COL2"), dr("COL3"))
            Catch ex As Exception
                Insert_log_error(dr("COL2"), dr("COL3"), "ส่วน ดึงข้อมูลออกใบเสร็จ : " & ex.Message, 0)
            End Try

        Next
    End Sub
    Function CHK_MAX_NO_INSERT(ByVal max_no As String) As Boolean
        Dim bool As Boolean = False
        Try
            Dim dao As New DAO_MAS.TB_genno_temp
            dao.fields.create_date = Date.Now
            dao.fields.GENNO = max_no
            dao.insert()

            bool = True
        Catch ex As Exception
            bool = False
        End Try

        Return bool
    End Function

    Public Function Get_Max_NO(ByVal is_l44 As Boolean, ByVal bgyear As Integer) As Integer
        ' Dim max_no As Integer = 0
        Dim bao_max As New BAO_BUDGET.Maintain
        Dim max_id As Integer = 0
        For i As Integer = 0 To 4
            If is_l44 = False Then
                max_id = bao_max.get_max_receipt_normal(Get_BUDGET_YEAR(), 2)
            Else
                max_id = bao_max.get_max_receipt_normal(Get_BUDGET_YEAR(), 4)
            End If
        Next

        Return max_id
    End Function
End Class