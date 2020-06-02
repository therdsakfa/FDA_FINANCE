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
    End Sub

    Sub Search_fee(ByVal ref01 As String, ByVal ref02 As String)
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        dt = bao.Get_FEE_BY_REF01_AND_REF02(ref01, ref02)
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
            Dim dao As New DAO_FEE.TB_fee
            dao.GetDataby_feeno(feeno)
            send_data(dao.fields.ref01, dao.fields.ref02)
        Catch ex As Exception

        End Try
    End Sub
End Class