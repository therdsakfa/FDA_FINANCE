Namespace CLS_SV_UPDATE_SYS
    Class SV_UPDATE
        Sub Update_Sys(ByVal dvcd As Integer, ByVal ref02 As String, Optional ByVal ref01 As String = "", Optional is_repeat As Boolean = False)

            Dim resMesg As String = ""
            Dim resCode As String = ""
            Dim check As Boolean = True

            Dim feeno As String = ""
            Dim _lcnsid As Integer = 0
            Dim _pvncd As Integer = 0
            Dim process_id As Integer = 0
            Dim acc_type As Integer = 0
            Dim feeabbr As String = ""

            Dim dao_fee As New DAO_FEE.TB_fee

            If ref01 = "" Then
                Dim dao_fees As New DAO_FEE.TB_fee
                dao_fees.GetDataby_ref2(ref02)
                Try
                    ref01 = dao_fees.fields.ref01
                Catch ex As Exception

                End Try
            End If

            '------------------เช็คว่ามีรายการนี้มั้ย----------------
            Dim count_fee As Integer = 0
            count_fee = dao_fee.Countby_ref1_ref2(ref01, ref02)
            'count_fee = dao_fee.Countby_ref1(ref1)
            '-----------------------------------------------

            Dim dao_fee2 As New DAO_FEE.TB_fee
            'dao_fee2.GetDataby_ref1(ref1)
            dao_fee2.GetDataby_ref1_ref2(ref01, ref02)
            Try
                acc_type = dao_fee2.fields.acc_type
            Catch ex As Exception

            End Try
            Dim id_fee As Integer = 0
            Try
                id_fee = dao_fee2.fields.IDA
            Catch ex As Exception

            End Try
            Try
                dvcd = dao_fee2.fields.dvcd
            Catch ex As Exception

            End Try
            Try
                _lcnsid = dao_fee2.fields.lcnsid
            Catch ex As Exception

            End Try
            Try
                _pvncd = dao_fee2.fields.pvncd
            Catch ex As Exception

            End Try
            Try
                feeno = dao_fee2.fields.feeno
            Catch ex As Exception

            End Try
            Dim bao_f As New BAO_FEE.FEE
            Dim dt_f As New DataTable
            'dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF(ref1,ref2)
            dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF01(ref01)
            If dt_f.Rows.Count > 0 Then
                Dim bao_dtl As New BAO_FEE.FEE
                Dim dt_dtl As New DataTable
                For Each dr As DataRow In dt_f.Rows
                    dt_dtl = bao_dtl.SP_FEEDTL(dr("feeno"), dr("pvncd"), dr("feetpcd"), dr("dvcd"))
                Next

                resCode = "0000"
                resMesg = "Success"
                check = True

                '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
                'ดึง process id
                Dim dao_type As New DAO_FEE.TB_feetype
                Try
                    dao_type.GetDataby_feeabbr(feeabbr)
                Catch ex As Exception

                End Try
                'Try

                '    'update สถานะ
                '    If dvcd = 1 Then
                '        Dim bao As New BAO_FEE.FEE
                '        bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, dao_type.fields.process_id, dvcd)
                '    ElseIf dvcd = 2 Then
                '        Dim bao As New BAO_FEE.LGT_NCT2_128
                '        bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, dao_type.fields.process_id, dvcd)
                '    ElseIf dvcd = 3 Then

                '    ElseIf dvcd = 4 Then

                '    ElseIf dvcd = 5 Then

                '    ElseIf dvcd = 6 Then
                '        Try
                '            Dim bao_txt As New BAO_FEE.FEE
                '            bao_txt.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXT_EXTEND_DATE(feeno)
                '        Catch ex As Exception

                '        End Try

                '    End If

                'Catch ex As Exception

                'End Try
            Else
                '-------------กรณีมี ต้องเช็คด้วยว่าจ่ายหรือยัง
                Dim dao_amt As New DAO_FEE.TB_feedtl
                Dim amt As Double = 0
                Try
                    amt = dao_amt.GetDataby_fk_fee(id_fee)
                Catch ex As Exception

                End Try

                Dim dao As New DAO_FEE.TB_fee_bank
                dao.GetDataby_ref1_ref2(ref01, ref02)
                'dao.GetDataby_ref1(ref1)

                Dim rcptst As Integer = 0
                Try
                    rcptst = dao_fee2.fields.rcptst
                Catch ex As Exception

                End Try

                'กรณีถ้าเป็น false คือ จ่ายปกติ แต่ถ้า true แสดงว่ามีการยิงย้ำมา
                If dvcd = 4 Or dvcd = 3 Or dvcd = 5 Then
                    If is_repeat = False Then
                        If rcptst = 1 Then 'เคยจ่ายตังแล้ว
                            resCode = "2001"
                            resMesg = "Duplicate transaction"
                            check = False
                        End If
                    End If
                Else
                    If rcptst = 1 Then 'เคยจ่ายตังแล้ว
                        resCode = "2001"
                        resMesg = "Duplicate transaction"
                        check = False
                    End If
                End If


                If rcptst = 2 Or rcptst = 3 Then 'เคยจ่ายตังแล้ว
                    resCode = "1000"
                    resMesg = "Invalid data"
                    check = False
                End If

                If check = True Then 'กรณีผ่านหมด
                    dao.fields.fee_pay = 1
                    dao.update()
                    Try
                        feeabbr = dao_fee2.fields.feeabbr

                    Catch ex As Exception

                    End Try
                    dao_fee2.fields.rcptst = 1
                    dao_fee2.update()

                    resCode = "0000"
                    resMesg = "Success"

                    '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
                    'ดึง process id
                    Dim dao_type As New DAO_FEE.TB_feetype
                    Try
                        dao_type.GetDataby_feeabbr(feeabbr)
                    Catch ex As Exception

                    End Try

                    Dim dao_log_h2h As New DAO_MAS.TB_LOG_PAY_HOST_TO_HOST
                    With dao_log_h2h.fields
                        Try
                            .pay_amount = amt
                        Catch ex As Exception

                        End Try
                        .pay_date = Date.Now
                        .ref01 = ref01
                        .ref02 = ref02
                    End With
                    dao_log_h2h.insert()

                    'Try
                    '    If dao_type.fields.process_id <> 14 Or dao_type.fields.process_id <> 15 Then
                    '        '------------------ดึงไประบบเก่า----------------------
                    '        Dim ws As New WS_BANK_INSERT.Service1
                    '        ws.insert_to_informix(feeno, dvcd, _lcnsid, feeabbr, _pvncd)
                    '    End If

                    'Catch ex As Exception

                    'End Try

                    '-------------------------------------------------------update สถานะ----------------------------------------
                    'update สถานะ
                    If dvcd = 1 Then
                        Try
                            Dim dao_fee_u As New DAO_FEE.TB_fee
                            Dim dao_feedtl As New DAO_FEE.TB_feedtl
                            Try
                                dao_fee_u.GetDataby_ref1_ref2(ref01, ref02)
                                dao_feedtl.GetDataby_fk_fee(dao_fee_u.fields.IDA)
                            Catch ex As Exception

                            End Try

                            Dim process_da As Integer = 0
                            Dim _IDA As Integer = 0
                            Dim bao As New BAO_FEE.FEE

                            Try
                                process_da = dao_feedtl.fields.process_id
                            Catch ex As Exception

                            End Try

                            If process_da = 14 Or process_da = 15 Then
                                Dim ws_dh As New WS_GEN_DH_NUMBER.WS_GEN_DH_NO
                                Dim bao_ida As New BAO_FEE.FDA_DRUG
                                Dim dt_ida As New DataTable
                                dt_ida = bao_ida.SP_GET_IDA_DA_FROM_FEE_MULTI_ROW(ref01, ref02)

                                For Each dr As DataRow In dt_ida.Rows
                                    ws_dh.GEN_DH_NO(dr("fk_id"))
                                Next
                            ElseIf process_da = "1007411" Or process_da = "1007412" Or process_da = "1007442" Or process_da = "1007443" Or process_da = "1007491" Or process_da = "1007492" Or process_da = "1007493" _
                                 Or process_da = "1007494" Or process_da = "1007471" Or process_da = "1007451" Or process_da = "1007495" Or process_da = "1007461" Or process_da = "1007481" Or process_da = "102730" Or process_da = "102780" _
                                  Or process_da = "102720" Or process_da = "102721" Or process_da = "102722" Or process_da = "102723" Or process_da = "102725" Or process_da = "102726" Or process_da = "102727" _
                                Or process_da = "102729" Or process_da = "102728" Then
                                Dim dao_fees As New DAO_FEE.TB_fee
                                dao_fees.GetDataby_ref1_ref2(ref01, ref02)
                                Dim dao_dets As New DAO_FEE.TB_feedtl
                                Try
                                    dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)
                                    For Each dao_dets.fields In dao_dets.datas
                                        Dim dao_lcn_extend As New DAO_DRUG.TB_LCN_EXTEND_LITE
                                        dao_lcn_extend.GetDataby_IDA(dao_dets.fields.fk_id)
                                        Dim stat_lcn As Integer = 0
                                        Try
                                            stat_lcn = dao_lcn_extend.fields.STATUS_ID
                                        Catch ex As Exception

                                        End Try
                                        If stat_lcn <> 8 Then
                                            If acc_type = "1" Then
                                                If stat_lcn = "1" Then
                                                    dao_lcn_extend.fields.STATUS_ID = 2
                                                    dao_lcn_extend.update()
                                                ElseIf stat_lcn = "3" Then
                                                    dao_lcn_extend.fields.STATUS_ID = 4
                                                    dao_lcn_extend.update()
                                                End If
                                            ElseIf acc_type = "2" Then
                                                If stat_lcn = "1" Then
                                                    dao_lcn_extend.fields.STATUS_ID = 3
                                                    dao_lcn_extend.update()
                                                ElseIf stat_lcn = "2" Then
                                                    dao_lcn_extend.fields.STATUS_ID = 4
                                                    dao_lcn_extend.update()
                                                End If
                                            End If
                                        End If
                                        'If acc_type = "1" Then
                                        '    If stat_lcn = "1" Then
                                        '        dao_lcn_extend.fields.STATUS_ID = 2
                                        '        dao_lcn_extend.update()
                                        '    ElseIf stat_lcn = "3" Then
                                        '        dao_lcn_extend.fields.STATUS_ID = 8
                                        '        dao_lcn_extend.update()
                                        '    End If
                                        'ElseIf acc_type = "2" Then
                                        '    If stat_lcn = "1" Then
                                        '        dao_lcn_extend.fields.STATUS_ID = 3
                                        '        dao_lcn_extend.update()
                                        '    ElseIf stat_lcn = "2" Then
                                        '        dao_lcn_extend.fields.STATUS_ID = 8
                                        '        dao_lcn_extend.update()
                                        '    End If
                                        'End If
                                    Next

                                Catch ex As Exception

                                End Try
                            ElseIf process_da = "950001" Or process_da = "950003" Or process_da = "950004" Or process_da = "950005" Or process_da = "950002" Or process_da = "950006" Or process_da = "950007" _
                                                        Or process_da = "950008" Or process_da = "950009" Or process_da = "950010" Then
                                For Each dao_feedtl.fields In dao_feedtl.datas
                                    Dim bao_cer As New BAO_FDA_CFS_CENTER.FDA_CFS_CENTER
                                    bao_cer.SP_SET_UPDATE_PAYMENT_CER_DRUG(dao_feedtl.fields.fk_id)
                                Next


                            Else
                                If process_da <> 0 Then
                                    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, process_da, dvcd)
                                End If

                            End If
                        Catch ex As Exception
                            resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                            Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                        End Try

                    ElseIf dvcd = 2 Then
                        Try
                            Dim dao_fees As New DAO_FEE.TB_fee
                            dao_fees.GetDataby_ref1_ref2(ref01, ref02)
                            Dim dao_dets As New DAO_FEE.TB_feedtl

                            dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)

                            For Each dao_dets.fields In dao_dets.datas
                                Try
                                    process_id = dao_dets.fields.process_id
                                Catch ex As Exception

                                End Try
                                If process_id = 940001 Or process_id = 940002 Or process_id = 940003 Or process_id = 940004 Then
                                    Dim ws_cer As New WS_UPDATE_PAYMENT_CERS.WS_UPDATE_PAYMENT_CER
                                    ws_cer.CER_NCT_SERVICE(process_id, dao_dets.fields.fk_id)
                                Else
                                    Dim bao As New BAO_NCT2.LGT_NCT2_128
                                    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, dao_dets.fields.process_id, dvcd)
                                    Dim _IDA As Integer = 0
                                    Dim bao22 As New BAO_NCT2.LGT_NCT2_128
                                    Try
                                        _IDA = dao_dets.fields.fk_id 'bao22.SP_GET_IDA_NCT_FROM_FEE(ref1, ref2)
                                    Catch ex As Exception

                                    End Try


                                    '----------------------------ส่ง xml ให้ห้องยา-------------------------------------

                                    Dim ws_insert As New WS_NCT_INSERT.WS_NCT_INSERT
                                    Dim ws_gen_xml As New NCT_INSERT_XML.NCT_INSERT_XML

                                    Dim IDA_NEW As String = String.Empty
                                    Dim string_xml As String = String.Empty
                                    Dim CC As String = String.Empty
                                    Dim email As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim content As String = String.Empty
                                    Dim filename As String = String.Empty


                                    If process_id <> 29100001 And process_id <> 29100002 And process_id <> 29200001 And process_id <> 29200002 _
                                        And process_id <> 29200003 And process_id <> 29200005 And process_id <> 29200004 _
                                        And process_id <> 29300001 And process_id <> 29300002 And process_id <> 29300003 And process_id <> 29300005 _
                                        And process_id <> 29300004 And process_id <> 29300011 And process_id <> 29300012 And process_id <> 29300013 _
                                        And process_id <> 29300014 And process_id <> 29300015 And process_id <> 29100003 And process_id <> 29100004 _
                                        Then
                                        IDA_NEW = ws_insert.NCT_INSERT(_IDA)
                                    Else
                                        IDA_NEW = ws_insert.NCT_INSERT_YORSOR_4(_IDA)
                                    End If

                                    string_xml = ws_gen_xml.NCT_INSERT(IDA_NEW, filename)

                                    ' ------------------ส่ง xml ที่ server------------------
                                    Try
                                        Dim ws_send_xml As New WS_NCT_INSERT_XML_LCN.NCT_INSERT_XML_LCN
                                        Dim txt As String = String.Empty
                                        'txt = ws_send_xml.NCT_INSERT_LCN_FOLDER(string_xml, filename, CONVERT_THAI_YEAR(CDec(Date.Now.Year)))
                                        ws_send_xml.NCT_INSERT_LCN_FOLDER_NO_RETURN(string_xml, filename, CONVERT_THAI_YEAR(CDec(Date.Now.Year)))
                                    Catch ex As Exception

                                    End Try

                                    ' ------------------ส่ง xml ที่ email------------------
                                    email = "saree@systemsthai.com"
                                    CC = "watchara@fusionsol.com"
                                    title = "XML_" & filename
                                    content = ""
                                    SendMail_CC_ATTACH(content, email, title, CC, string_xml, filename)
                                    '-------------------------------------------------
                                End If


                            Next
                        Catch ex As Exception
                            resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                            Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                        End Try

                    ElseIf dvcd = 3 Then
                        Try
                            ''โฆษณาอาหาร
                            Dim bao_adv As New BAO_ADV.FDA_TXC
                            Dim dt_adv As New DataTable
                            dt_adv = bao_adv.SP_GET_FEE_BY_REF01_AND_REF02(ref01, ref02)
                            Dim dao_fees As New DAO_FEE.TB_fee
                            dao_fees.GetDataby_ref1_ref2(ref01, ref02)
                            Dim dao_dets As New DAO_FEE.TB_feedtl
                            Try
                                dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)
                                For Each dao_dets.fields In dao_dets.datas
                                    If dao_dets.fields.process_id <> "9910" And dao_dets.fields.process_id <> "9911" Then
                                        Dim ws_foods As New WS_FOOD.WS_FOOD_JOB
                                        ws_foods.FOOD_SERVICE(dao_dets.fields.process_id, dao_dets.fields.fk_id)
                                    Else
                                        Dim dao_ad As New DAO_ADV.TB_FDATransaction
                                        dao_ad.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        Dim bao_u_adv As New BAO_ADV.FDA_TXC
                                        If dao_ad.fields.AccountStatusId = 22 Then
                                            bao_u_adv.SP_ADV_Bill(dao_dets.fields.fk_id, 25)
                                        ElseIf dao_ad.fields.AccountStatusId = 23 Then
                                            bao_u_adv.SP_ADV_Bill(dao_dets.fields.fk_id, 26)
                                        End If
                                    End If


                                Next
                            Catch ex As Exception
                                resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                                Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                            End Try
                        Catch ex As Exception
                            resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                            Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                        End Try
                    ElseIf dvcd = 4 Then
                        Try
                            'Dim _IDA As Integer = 0
                            'Dim bao22 As New BAO_CMT.FDA_CMT
                            'Try
                            '    _IDA = bao22.SP_GET_IDA_CMT_FROM_FEE(ref1, ref2)
                            'Catch ex As Exception

                            'End Try
                            Dim dao_fcmt As New DAO_FEE.TB_fee
                            dao_fcmt.GetDataby_ref1_ref2(ref01, ref02)
                            Dim dao_dcmt As New DAO_FEE.TB_feedtl
                            dao_dcmt.Getdata_by_fee_id(dao_fcmt.fields.IDA)


                            For Each dao_dcmt.fields In dao_dcmt.datas
                                Dim process_cmt As String = "0"
                                Dim dk_id_cmt As Integer = 0
                                Dim bao As New BAO_CMT.FDA_CMT
                                Try
                                    process_cmt = dao_dcmt.fields.process_id
                                Catch ex As Exception

                                End Try
                                Try
                                    dk_id_cmt = dao_dcmt.fields.fk_id
                                Catch ex As Exception

                                End Try

                                'If process_cmt = "200001" Then
                                '    bao.SP_Update_payment_req(dk_id_cmt)
                                'ElseIf process_cmt = "200002" Then
                                '    bao.SP_Update_payment_regnos(dk_id_cmt)
                                'Else
                                If process_cmt = "410001" Or process_cmt = "410002" Or process_cmt = "410003" Or process_cmt = "410004" Then
                                    Dim ws_cmt As New WS_Update_Payment_CER_LOCATION.WS_Update_Payment_CER_LOCATION
                                    ws_cmt.cer_location_update(process_cmt, dk_id_cmt, dao_dcmt.fields.fk_refstatus)
                                ElseIf process_cmt = "910001" Or process_cmt = "910002" Or process_cmt = "910003" Or process_cmt = "910004" _
                                   Or process_cmt = "910005" Or process_cmt = "910006" Or process_cmt = "910011" Then
                                    Dim ws_cmt As New WS_CER_CMT.WS_Update_Payment_Cer
                                    ws_cmt.cer_cmt_update(process_cmt, dk_id_cmt, dao_dcmt.fields.fk_refstatus)
                                End If
                                Try
                                    Dim ws_cmt_pay As New WS_CMT_PAYS.WS_CMT_PAY
                                    ws_cmt_pay.CMT_PAY(dk_id_cmt, process_cmt, ref01, ref02)
                                Catch ex As Exception

                                End Try

                            Next

                        Catch ex As Exception
                            resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                            Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                        End Try
                    ElseIf dvcd = 5 Then
                        Try
                            Dim dao_fees As New DAO_FEE.TB_fee
                            dao_fees.GetDataby_ref1_ref2(ref01, ref02)
                            Dim dao_dets As New DAO_FEE.TB_feedtl
                            Dim process_mdc As String = ""

                            dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)


                            For Each dao_dets.fields In dao_dets.datas
                                Try
                                    process_mdc = dao_dets.fields.process_id
                                Catch ex As Exception

                                End Try
                                Dim ws_rcv As New WS_UPDATE_RCVNO.UPDATE_RCVNO
                                If process_mdc <> "555555" Then
                                    If process_mdc = "501000" Then

                                        Dim dao_mdc As New DAO_MDC.TB_irgt
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS = 1 Or dao_mdc.fields.STATUS = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS, process_mdc)
                                        End If
                                    ElseIf process_mdc = "501002" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_EXPORT
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 3 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "502005" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_MC
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "504001" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_MN
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "505001" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_MR
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "508000" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_DIAGNOSED
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "509000" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_CER
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "501020" Then
                                        'Dim dao_mdc As New DAO_MDC.TB_MDC_DIAGNOSED
                                        'dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        'If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                        Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                        Try
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_dets.fields.appabbr, process_mdc)
                                        Catch ex As Exception

                                        End Try

                                    ElseIf process_mdc = "501010" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_EDIT
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "501030" Then
                                        Dim dao_mdc As New DAO_MDC.TB_MDC_SUBSTITUTE
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 1 Or dao_mdc.fields.STATUS_ID = 10 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                    ElseIf process_mdc = "506001" Then
                                        Dim dao_mdc As New DAO_MDC.TB_IMPORT_OT
                                        dao_mdc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        If dao_mdc.fields.STATUS_ID = 3 Then
                                            Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                            ws_update_date.WS_UPDATE_STATUS(dao_dets.fields.fk_id, dao_mdc.fields.STATUS_ID, process_mdc)
                                        End If
                                        'End If
                                    End If


                                Else
                                    Try
                                        Dim dao_ossc As New DAO_MDC.TB_ONESTOP_REQUEST
                                        dao_ossc.GETDATA_BY_IDA(dao_dets.fields.fk_id)
                                        Dim bao_pay As New BAO_MDC.FDA_MDC

                                        bao_pay.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC_ONESTOP(dao_ossc.fields.IDA)
                                    Catch ex As Exception

                                    End Try
                                End If
                            Next
                        Catch ex As Exception
                            resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                            Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                        End Try
                    ElseIf dvcd = 6 Then
                        Try
                            Dim bao_txc As New BAO_TXC.FDA_TXC
                            Dim dt As New DataTable
                            dt = bao_txc.SP_GET_FEE_BY_REF01_AND_REF02(ref01, ref02)
                            For Each dr As DataRow In dt.Rows
                                Dim bao_txc2 As New BAO_TXC.FDA_TXC
                                bao_txc2.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXC(dr("fk_id"), dr("process_id"))
                            Next

                            Try
                                Dim bao_txt As New BAO_FEE.FEE
                                bao_txt.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXT_EXTEND_DATE(feeno)
                            Catch ex As Exception

                            End Try
                        Catch ex As Exception
                            resMesg = "ส่วนของ UPDATE : System error = " & ex.Message
                            Insert_log_error(ref01, ref02, "", resMesg, "", 0)
                        End Try
                    ElseIf dvcd = 7 Then

                        Dim dao_fees As New DAO_FEE.TB_fee
                        dao_fees.GetDataby_ref1_ref2(ref01, ref02)
                        Dim dao_dets As New DAO_FEE.TB_feedtl
                        Dim process_mdc As String = ""

                        dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)
                        Try
                            process_mdc = dao_dets.fields.process_id
                        Catch ex As Exception

                        End Try
                        For Each dao_dets.fields In dao_dets.datas
                            Dim bao_mul As New BAO_FDA_MULCT.FDA_MULCT
                            Try
                                bao_mul.SP_MULCT_FOR_PDF_MAIN(dao_dets.fields.fk_id)
                            Catch ex As Exception

                            End Try

                        Next
                        '
                    ElseIf dvcd = 0 Then
                        'Dim feeabbr_u As String = ""
                        'Try
                        '    Dim dao_fee5 As New DAO.TB_FEE
                        '    dao_fee5.GetDataby_ref1_ref2(ref1, ref2)
                        '    Try
                        '        feeabbr_u = dao_fee5.fields.feeabbr
                        '    Catch ex As Exception

                        '    End Try
                        '    Dim dao_fee_det As New DAO.TB_FEEDTL
                        '    dao_fee_det.Getdata_by_fee_id(dao_fee5.fields.IDA)

                        '    For Each dao_fee_det.fields In dao_fee_det.datas
                        '        If feeabbr_u = "9005" Or feeabbr_u = "9006" Then
                        '            Dim bao_pay As New BAO_SPECIAL_PAYMENT.FDA_SPECIAL_PAYMENT
                        '            bao_pay.SP_UPDATE_STATUS_PAY_COMPLETE(dao_fee_det.fields.process_id, dao_fee_det.fields.fk_id)
                        '        End If
                        '    Next


                        'Catch ex As Exception

                        'End Try


                    End If

                    'If acc_type = 2 Then
                    'Try
                    '    Dim dao_fee6 As New DAO_FEE.TB_fee
                    '    dao_fee6.GetDataby_ref1_ref2(ref01, ref02)
                    '    Dim dao_fee_det As New DAO_FEE.TB_feedtl
                    '    dao_fee_det.Getdata_by_fee_id(dao_fee6.fields.IDA)
                    '    For Each dao_fee_det.fields In dao_fee_det.datas
                    '        Dim bao_pay As New BAO_SPECIAL_PAYMENT.FDA_SPECIAL_PAYMENT
                    '        bao_pay.SP_UPDATE_STATUS_PAY_COMPLETE(dao_fee_det.fields.process_id, dao_fee_det.fields.fk_id, 2)
                    '    Next
                    'Catch ex As Exception

                    'End Try
                    Try
                        Dim dao_fee6 As New DAO_FEE.TB_fee
                        dao_fee6.GetDataby_ref1_ref2(ref01, ref02)
                        Dim dao_fee_det As New DAO_FEE.TB_feedtl
                        dao_fee_det.Getdata_by_fee_id(dao_fee6.fields.IDA)
                        Dim feeabbr_u As String = ""
                        Try
                            feeabbr_u = dao_fee6.fields.feeabbr
                        Catch ex As Exception

                        End Try
                        For Each dao_fee_det.fields In dao_fee_det.datas
                            If feeabbr_u = "9005" Or feeabbr_u = "9006" Then
                                Dim bao_pay As New BAO_SPECIAL_PAYMENT.FDA_SPECIAL_PAYMENT
                                bao_pay.SP_UPDATE_STATUS_PAY_COMPLETE(dao_fee_det.fields.process_id, dao_fee_det.fields.fk_id, 2)
                            End If

                        Next
                    Catch ex As Exception

                    End Try
                    'End If

                    '-------------------------------------------

                End If

            End If

            'Try
            '    Dim dao_logs As New DAO.TB_FEE_LOGS
            '    dao_logs.fields.CREATEDATE = Date.Now
            '    dao_logs.fields.ref1 = ref01
            '    dao_logs.fields.ref2 = ref02
            '    dao_logs.fields.STEP = 1
            '    dao_logs.fields.RESULT = "ส่วนจบ UPDATE สถานะ resMesg=" & resMesg & " resCode=" & resCode
            '    dao_logs.fields.XML_PATH = ""
            '    dao_logs.insert()
            'Catch ex As Exception

            'End Try


            Try
                Dim iii As Integer = 0
                Dim dao_con As New DAO_FEE.TB_FEE_LOGS
                iii = dao_con.Count_Verify_by_ref1_ref2(ref01, ref02)
                Dim is_ossc As String = ""
                If iii = 0 Then
                    is_ossc = "ออกที่คลัง"
                End If

                Dim dao_logs As New DAO_FEE.TB_FEE_LOGS
                dao_logs.fields.CREATEDATE = Date.Now
                dao_logs.fields.ref1 = ref01
                dao_logs.fields.ref2 = ref02
                If is_ossc = "" Then
                    dao_logs.fields.STEP = 99
                Else
                    dao_logs.fields.STEP = 98
                End If

                dao_logs.fields.STATUS_ID = 8
                dao_logs.fields.RESULT = "ส่วนจบ Update --> Confirm by Service Update : resMesg=" & resMesg & " resCode=" & resCode
                dao_logs.fields.XML_PATH = is_ossc
                dao_logs.insert()


            Catch ex As Exception

            End Try
        End Sub
        Private Sub Update_food(ByVal process_id As String, ByVal fk_id As Integer, ByVal ref01 As String, ByVal ref02 As String)
            Try
                Dim ws_foods As New WS_FOOD.WS_FOOD_JOB
                ws_foods.FOOD_SERVICE(process_id, fk_id)
            Catch ex As Exception
                Dim resMesg As String = ""
                resMesg = "ส่วนของ SERVICE FOOD UPDATE (คลังตรวจ) : System error = " & ex.Message & " dvcd = 3"
                Insert_log_error(ref01, ref02, "", resMesg, "", 0)
            End Try
        End Sub
        Sub Insert_log_error(ByVal ref01 As String, ByVal ref02 As String, ByVal xmlname As String, ByVal error_str As String, _
                         ByVal account_id As String, ByVal status_id As Integer)
            Dim dao_logs As New DAO_FEE.TB_FEE_LOGS
            dao_logs.fields.CREATEDATE = Date.Now
            dao_logs.fields.ref1 = ref01
            dao_logs.fields.ref2 = ref02
            dao_logs.fields.STEP = 0
            dao_logs.fields.RESULT = error_str
            dao_logs.fields.XML_PATH = xmlname
            dao_logs.fields.ACCOUNT_ID = account_id
            dao_logs.fields.STATUS_ID = status_id
            dao_logs.insert()
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
        ''' <summary>
        ''' เช็ค ค.ศ. เปลี่ยนเป็น พ.ศ. ตามที่ใส่
        ''' </summary>
        ''' <param name="YEAR"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CONVERT_THAI_YEAR(ByVal YEAR As Integer) As String

            If YEAR <= 2500 Then
                YEAR += 543
            End If
            Return YEAR.ToString()
        End Function
    End Class

End Namespace
