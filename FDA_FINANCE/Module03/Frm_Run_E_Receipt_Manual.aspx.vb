Public Class Frm_Run_E_Receipt_Manual
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
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString()
        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
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
        count_fee_new = dao_chk_fee.Countby_ref1_ref2(txt_ref01.Text, txt_ref02.Text)
        dao_fee_m44.GetDataby_ref1_ref2(txt_ref01.Text, txt_ref02.Text)

        'dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
        'dt_d = bao_d.SP_get_receipt_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
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
            If count_fee_new > 0 Then
                Dim dao_fee_new As New DAO_FEE.TB_fee
                dao_fee_new.GetDataby_ref1_ref2(txt_ref01.Text, txt_ref02.Text)
                dvcd = dao_fee_new.fields.dvcd
                feeno = dao_fee_new.fields.feeno
                feeabbr = dao_fee_new.fields.feeabbr
            Else
                Dim dt_c As New DataTable
                Dim bao_fo As New BAO_BUDGET.FDA_FEE
                dt_c = bao_fo.SP_get_receipt_by_ref01_ref02(txt_ref01.Text, txt_ref02.Text)
                For Each dr As DataRow In dt_c.Rows
                    dvcd = dr("dvcd")
                    feeno = dr("feeno")
                    feeabbr = dr("feeabbr")
                Next
            End If
            Try

                If dt_d.Rows.Count > 0 Then
                    is_old = True
                End If
            Catch ex As Exception

            End Try
            If dt_d.Rows.Count = 0 Then
                If l44 = False Then
                    If dvcd = 2 Then
                        Dim bao2 As New BAO_NCT2.LGT_NCT2
                        dt_d = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, dvcd)
                    Else
                        dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, dvcd)
                    End If
                Else
                    dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44(feeno, dvcd)
                End If

            End If

            Try
                dao_fee_m44.fields.rcptst = 1
                dao_fee_m44.update()
            Catch ex As Exception

            End Try
            Dim bool As Boolean = False
            insert_e_bill(dvcd, feeno, feeabbr, l44, txt_ref01.Text, txt_ref02.Text)
            Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?ref01=" & txt_ref01.Text & "&ref02=" & txt_ref02.Text
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)
        Else
            If dt_d.Rows.Count > 0 Then
                insert_e_bill(dt_d(0)("dvcd"), dt_d(0)("feeno"), dt_d(0)("feeabbr"), l44, txt_ref01.Text, txt_ref02.Text, is_old)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End If
        End If

    End Sub

    Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String, ByVal is_m44 As Boolean _
                      , Optional ref01 As String = "", Optional ref02 As String = "", Optional isold As Boolean = False)
        Dim dt As New DataTable
        Dim bao As New BAO_FEE.FEE
        Dim bao_d As New BAO_BUDGET.FDA_FEE
        Dim receipt_num As String = ""

        Dim fk_fee As Integer = 0
        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum3(feeno, dvcd, feeabbr)
        If isold = True Then
            Try
                dt = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)
            Catch ex As Exception

            End Try
        End If

        Dim str_fullname As String = ""

        If dt.Rows.Count = 0 Then
            Try
                dt = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, dvcd, feeabbr)

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
                        str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    Else
                        str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

        Dim count_bg As Integer = 0
        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'If is_m44 = True Then
        count_bg = dao.count_receipt_by_ref_E(ref01, ref02)
        Dim citizen As String = ""
        'If is_m44 = True Then
        '    citizen = "3149700030524"
        'Else
        '    citizen = "3120100826052"
        'End If
        If count_bg = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 5
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = str_fullname
            dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
            dao_i.fields.RECEIPT_VOLUME = "Manual"
            Try
                dao_i.fields.STAFF_IDEN = _CLS.CITIZEN_ID
            Catch ex As Exception

            End Try
            Try
                dao_i.fields.RECEIVER_MONEY_ID = Get_Checker_ID(_CLS.CITIZEN_ID)
            Catch ex As Exception

            End Try

            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = feeabbr
            dao_i.fields.ORDER_PAY2 = feeno
            dao_i.fields.MONEY_RECEIVE_DATE = CDate(txt_date.Text)
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


            Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            Dim img_byte As String = Cls_qr.QR_CODE(url2) 'Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

            'Dim dao_i2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao_i2.Getdata_by_RECEIVE_MONEY_ID(re_id)
            'dao_i2.fields.QR_IMAGE_BYTE = img_byte
            'dao_i2.update()

            Dim dt_det As New DataTable
            Dim bao_dett As New BAO_FEE.FEE
            Dim dao_fee3 As New DAO_FEE.TB_fee
            dao_fee3.Getdata_by_feeno_and_dvcd(feeno, dvcd)
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
                dt_det = bao_det.SP_GET_FEEDTL_OLD(feeno, dvcd, dt(0)("pvncd"), feeabbr)
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