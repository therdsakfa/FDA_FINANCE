Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_RECEIPT_AUTO
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Sub Gen_Receipt(ByVal ref01 As String, ByVal ref02 As String)
        Try
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(ref01, ref02)
            Dim acc_type As Boolean
            If dao_fee.fields.acc_type = "1" Then
                acc_type = False
            Else
                acc_type = True
            End If

            'Dim StartTime As Date = #11:00:00 PM#
            'Dim EndTime As Date = #11:59:59 PM#
            'Dim CurrentTime As Date = Date.Now

            'If EndTime.Ticks < StartTime.Ticks Then
            '    If (CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks >= EndTime.Ticks) Or _
            '        (CurrentTime.Ticks <= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks) Then

            '        insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '        send_mail_mini(ref01, ref02)
            '    Else
            '        INSERT_LOG(ref01, ref02)
            '    End If
            'Else
            'If CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks Then
            '    INSERT_LOG(ref01, ref02)
            'Else
            '    insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '    send_mail_mini(ref01, ref02)

            'End If
            'End If

            Dim CurrentTime As DateTime = Convert.ToDateTime(DateTime.Now)

            'If CurrentTime.Ticks >= t1.Ticks And CurrentTime.Ticks <= t2.Ticks Then



            If CurrentTime.Hour = 23 Then
                'INSERT_LOG(ref01, ref02)
            Else
                insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
                send_mail_mini(ref01, ref02)

                Dim dao_log As New DAO_MAS.TB_LOG_CONFIRM
                With dao_log.fields
                    .CREATEDATE = Date.Now
                    .REF01 = ref01
                    .REF02 = ref02
                    .STATUS_ID = 999
                End With
                dao_log.insert()
            End If

        Catch ex As Exception
            Insert_log_error(ref01, ref02, "ส่วน ดึงข้อมูลออกใบเสร็จ : " & ex.Message, 0)
        End Try
    End Sub

    Public Function Gen_Receipt_Wait(ByVal ref01 As String, ByVal ref02 As String) As String
        Dim Str_Return As String = ""
        Try
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(ref01, ref02)
            Dim acc_type As Boolean
            If dao_fee.fields.acc_type = "1" Then
                acc_type = False
            Else
                acc_type = True
            End If

            'Dim StartTime As Date = #11:00:00 PM#
            'Dim EndTime As Date = #11:59:59 PM#
            'Dim CurrentTime As Date = Date.Now

            'If EndTime.Ticks < StartTime.Ticks Then
            '    If (CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks >= EndTime.Ticks) Or _
            '        (CurrentTime.Ticks <= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks) Then

            '        insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '        send_mail_mini(ref01, ref02)
            '    Else
            '        INSERT_LOG(ref01, ref02)
            '    End If
            'Else
            'If CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks Then
            '    INSERT_LOG(ref01, ref02)
            'Else
            '    insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '    send_mail_mini(ref01, ref02)

            'End If
            'End If

            Dim CurrentTime As DateTime = Convert.ToDateTime(DateTime.Now)

            'If CurrentTime.Ticks >= t1.Ticks And CurrentTime.Ticks <= t2.Ticks Then
            'If CurrentTime.Hour = 23 Then
            '    INSERT_LOG(ref01, ref02)
            'Else
            insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
                send_mail_mini(ref01, ref02)

                Dim dao_log As New DAO_MAS.TB_LOG_CONFIRM
                With dao_log.fields
                    .CREATEDATE = Date.Now
                    .REF01 = ref01
                    .REF02 = ref02
                    .STATUS_ID = 999
                End With
                dao_log.insert()
                Str_Return = "success"
            'End If

        Catch ex As Exception
            Str_Return = "fail"
            Insert_log_error(ref01, ref02, "ออกใบเสร็จเจนตามเวลา : " & ex.Message, 0)
        End Try
        Return Str_Return
    End Function
    Private Sub INSERT_LOG(ByVal ref01 As String, ByVal ref02 As String)
        Dim dao As New DAO_MAS.TB_LOG_11PM
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.REF01 = ref01
        dao.fields.REF02 = ref02
        dao.insert()
    End Sub
    <WebMethod()> _
    Public Sub Gen_Receipt_By_Ref02(ByVal ref02 As String)
        Dim ref01 As String = ""
        Try
            Dim dao_fee1 As New DAO_FEE.TB_fee
            dao_fee1.GetDataby_ref2(ref02)
            ref01 = dao_fee1.fields.ref01
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(ref01, ref02)
            Dim acc_type As Boolean
            If dao_fee.fields.acc_type = "1" Then
                acc_type = False
            Else
                acc_type = True
            End If

            'Dim StartTime As Date = #11:00:00 PM#
            'Dim EndTime As Date = #11:59:59 PM#
            'Dim CurrentTime As Date = Date.Now

            'If EndTime.Ticks < StartTime.Ticks Then
            '    If (CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks >= EndTime.Ticks) Or _
            '        (CurrentTime.Ticks <= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks) Then

            '        insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '        send_mail_mini(ref01, ref02)
            '    Else
            '        INSERT_LOG(ref01, ref02)
            '    End If
            'Else
            'If CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks Then
            '    INSERT_LOG(ref01, ref02)
            'Else
            '    insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '    send_mail_mini(ref01, ref02)

            'End If
            'End If
            Dim CurrentTime As DateTime = Convert.ToDateTime(DateTime.Now)
            If CurrentTime.Hour = 23 Then
                INSERT_LOG(ref01, ref02)
            Else
                insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
                send_mail_mini(ref01, ref02)

                Dim dao_log As New DAO_MAS.TB_LOG_CONFIRM
                With dao_log.fields
                    .CREATEDATE = Date.Now
                    .REF01 = ref01
                    .REF02 = ref02
                    .STATUS_ID = 999
                End With
                dao_log.insert()
            End If
        Catch ex As Exception
            Insert_log_error(ref01, ref02, "ส่วน ดึงข้อมูลออกใบเสร็จ : " & ex.Message, 0)
        End Try
    End Sub
    <WebMethod()> _
    Public Sub Gen_Receipt_By_Ref01(ByVal ref01 As String)
        Dim ref02 As String = ""
        Try
            Dim dao_fee1 As New DAO_FEE.TB_fee
            dao_fee1.GetDataby_ref1(ref01)
            ref02 = dao_fee1.fields.ref02
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(ref01, ref02)
            Dim acc_type As Boolean
            If dao_fee.fields.acc_type = "1" Then
                acc_type = False
            Else
                acc_type = True
            End If

            'Dim StartTime As Date = #11:00:00 PM#
            'Dim EndTime As Date = #11:59:59 PM#
            'Dim CurrentTime As Date = Date.Now

            'If EndTime.Ticks < StartTime.Ticks Then
            '    If (CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks >= EndTime.Ticks) Or _
            '        (CurrentTime.Ticks <= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks) Then

            '        insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '        send_mail_mini(ref01, ref02)
            '    Else
            '        INSERT_LOG(ref01, ref02)
            '    End If
            'Else
            'If CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks Then
            '    INSERT_LOG(ref01, ref02)
            'Else
            '    insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
            '    send_mail_mini(ref01, ref02)

            'End If
            'End If
            Dim CurrentTime As DateTime = Convert.ToDateTime(DateTime.Now)
            If CurrentTime.Hour = 23 Then
                INSERT_LOG(ref01, ref02)
            Else
                insert_e_bill(dao_fee.fields.dvcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, acc_type, ref01, ref02, "")
                send_mail_mini(ref01, ref02)

                Dim dao_log As New DAO_MAS.TB_LOG_CONFIRM
                With dao_log.fields
                    .CREATEDATE = Date.Now
                    .REF01 = ref01
                    .REF02 = ref02
                    .STATUS_ID = 999
                End With
                dao_log.insert()
            End If
        Catch ex As Exception
            Insert_log_error(ref01, ref02, "ส่วน ดึงข้อมูลออกใบเสร็จ : " & ex.Message, 0)
        End Try
    End Sub
    Private Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String, ByVal is_m44 As Boolean _
                      , Optional ref01 As String = "", Optional ref02 As String = "", Optional is_new_chk As String = "")
        Dim ws_dt As New WS_OLD_DT
        Dim dt As New DataTable
        Dim bao As New BAO_FEE.FEE
        Dim bao_d As New BAO_BUDGET.FDA_FEE
        Dim receipt_num As String = ""
        Dim CITIZEN_ID As String = ""
        If is_m44 = True Then
            CITIZEN_ID = "3149700030524"
        Else
            CITIZEN_ID = "3120100826052"
        End If
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
                        '-------------------------------------------
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
        count_bg = dao.count_receipt_by_ref_E(ref01, ref02)
        'Else
        '    Dim dao_feeee As New DAO_FEE.TB_fee
        '    count_bg = dao.count_receipt_by_ref_E(ref01, ref02)
        'End If
        If count_bg = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 5
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = str_fullname
            dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
            Try
                dao_i.fields.RECEIVER_MONEY_ID = Get_Checker_ID(CITIZEN_ID)
            Catch ex As Exception

            End Try

            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = feeabbr
            dao_i.fields.ORDER_PAY2 = feeno
            dao_i.fields.DISBURSE_BUDGET_BILL_ID = 1
            'If is_new_chk <> "" Then
            '    Dim dao_scb As New DAO_MAS.TB_LOG_PAY_FROM_SCB
            '   dao_scb.Get_data_by_ref01_ref02(ref01, ref02)
            '    Try
            '        dao_i.fields.MONEY_RECEIVE_DATE = CDate(dao_scb.fields.CHECK_DATE)
            '    Catch ex As Exception

            '    End Try
            'Else
            dao_i.fields.MONEY_RECEIVE_DATE = CDate(Date.Now)
            'End If

            dao_i.fields.FEEABBR = feeabbr
            dao_i.fields.FEENO = feeno
            dao_i.fields.LCNSID = dt(0)("lcnsid")
            dao_i.fields.BUDGET_YEAR = Get_BUDGET_YEAR()

            dao_i.fields.IS_APPROVE = True
            Try
                dao_i.fields.APPROVE_DATE = CDate(Date.Now)
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
            Dim max_id_new As Integer = 0

            max_id_new = Get_Max_NO(is_m44, Get_BUDGET_YEAR())
            'If max_id = max_id_new Then

            'Else

            max_id_new = max_id_new + 1


            Dim str_num As String = ""
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
            Dim FULL_RECEIVE_NUMBER As String
            If is_m44 = False Then
                FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            Else
                FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            End If

            Dim bools As Boolean = False
            bools = CHK_MAX_NO_INSERT(FULL_RECEIVE_NUMBER)

            If bools = True Then

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

                    End If

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

            ElseIf bools = False Then 'กรณีซ้ำ รันใหม่
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

                ElseIf bools = False Then
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

                    ElseIf bools = False Then
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
            End If

            dao_i.insert()
            'If is_m44 = False Then
            '    dao_i.fields.FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            'Else
            '    dao_i.fields.FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            'End If


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
            'Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

            Dim ws_qrs As New WS_QR.WS_QR
            Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2) ' ws_qrs.QR_CODE_B64(url2) '


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
                '------------------------------------
                'dt_det = bao_det.SP_GET_FEEDTL_OLD(feeno, dvcd, dt(0)("pvncd"), feeabbr)
                '-------------เอาออกนะ
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
    Private Sub send_mail_mini(ByVal ref01 As String, ByVal ref02 As String)
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
    Private Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email


        mm.SendMail_ASY(mcontent)

    End Sub
    Private Function Get_Checker_ID(ByVal citizen As String) As Integer
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


    Private Function Get_BUDGET_YEAR() As Integer
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

    <WebMethod()>
    Public Sub INSERT_WAIT_REF(ByVal ref01 As String, ByVal ref02 As String)
        Dim CurrentTime As DateTime = Convert.ToDateTime(DateTime.Now)

        'If CurrentTime.Ticks >= t1.Ticks And CurrentTime.Ticks <= t2.Ticks Then
        If CurrentTime.Hour = 23 Then
            INSERT_LOG(ref01, ref02)
        Else
            Dim dao As New DAO_MAS.TB_LOG_WAIT_RECEIPT
            dao.fields.REF01 = ref01
            dao.fields.REF02 = ref02
            dao.fields.CREATE_DATE = Date.Now
            dao.insert()
        End If

    End Sub

    Public Sub UPDATE_STATUS_REF(ByVal ref01 As String, ByVal ref02 As String)
        Dim dao As New DAO_MAS.TB_LOG_WAIT_RECEIPT
        dao.Getdata_by_ref01_ref02(ref01, ref02)
        dao.fields.STATUS_RECEIPT = 1
        dao.update()
    End Sub
End Class