Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        dt.Columns.Add("BUDGET_DISBURSE_BILL_ID", GetType(Integer))
        dt.Columns.Add("DOC_NUMBER", GetType(String))
        dt.Columns.Add("DOC_DATE", GetType(Date))
        dt.Columns.Add("CUSTOMER_NAME", GetType(String))
        dt.Columns.Add("AMOUNT", GetType(Double))

        For i As Integer = 1 To 5
            Dim dr As DataRow = dt.NewRow()
            dr("BUDGET_DISBURSE_BILL_ID") = i
            dr("DOC_NUMBER") = i
            dr("DOC_DATE") = Date.Now
            dr("CUSTOMER_NAME") = "ทดสอบ " & i
            dr("AMOUNT") = i * 2
            dt.Rows.Add(dr)
        Next


        RadGrid1.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim aa As Double = 0
        Dim bool As Boolean = False
        bool = UC_RELATE_BILL_USER_BERG1.check_over
        'If bool = False Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรอกจำนวนเงินไม่ถูกต้อง');", True)
        'Else
        '    aa = UC_RELATE_BILL_USER_BERG1.insert_det()
        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dt = bao.aaaaa()
        Dim dt_new As New DataTable
        dt_new.Columns.Add("IDA", GetType(Integer))
        dt_new.Columns.Add("ID_PROJ", GetType(Integer))
        dt_new.Columns.Add("PROJ_NAME")
        dt_new.Columns.Add("SEQ", GetType(Integer))
        dt_new.Columns.Add("FLOOR_SEQ", GetType(Integer))
        dt_new.Columns.Add("CAL_PERSENT", GetType(Integer))


       


        For Each dr As DataRow In dt.Rows
            Dim dt_a As New DataTable
            dt_a = getPlanBack(dr("BUDGET_CHILD_ID"), dr("IDA_NEW"))
            dt_new.Merge(dt_a)

            Dim dt_act As New DataTable
            dt_act.Columns.Add("IDA", GetType(Integer))
            dt_act.Columns.Add("ID_PROJ", GetType(Integer))
            dt_act.Columns.Add("PROJ_NAME")
            dt_act.Columns.Add("SEQ", GetType(Integer))
            dt_act.Columns.Add("FLOOR_SEQ", GetType(Integer))
            dt_act.Columns.Add("CAL_PERSENT", GetType(Integer))

            Dim ii As Integer = 5
            For i As Integer = 1 To 5
                Dim dr2 As DataRow = dt_act.NewRow()
                dr2("IDA") = 0
                dr2("ID_PROJ") = dr("IDA_NEW")
                dr2("PROJ_NAME") = "กิจกรรมที่ " & i
                dr2("SEQ") = 5 + i
                dr2("FLOOR_SEQ") = 5
                dr2("CAL_PERSENT") = 1
                dt_act.Rows.Add(dr2)
            Next

            dt_new.Merge(dt_act)
        Next


        For Each dr As DataRow In dt_new.Rows
            Dim dao As New DAO_DISBURSE.TB_TEMP_INSERT
            dao.fields.CAL_PERSENT = dr("CAL_PERSENT")
            dao.fields.FLOOR_SEQ = dr("FLOOR_SEQ")
            dao.fields.ID_PROJ = dr("ID_PROJ")
            dao.fields.IDA = dr("IDA")
            dao.fields.PROJ_NAME = dr("PROJ_NAME")
            dao.fields.SEQ = dr("SEQ")
            dao.insert()
        Next


    End Sub

    Public Function getPlanBack(ByVal bg_id As Integer, ByVal id_proj As Integer) As DataTable

        Dim dt_new As New DataTable
        'dt.Columns.Add("seq")
        'dt.Columns.Add("BUDGET_DESCRIPTION")
        'dt.Columns.Add("BUDGET_AMOUNT")
        'dt = getNodeBack(dt, bg_id)
        dt_new.Columns.Add("IDA", GetType(Integer))
        dt_new.Columns.Add("ID_PROJ", GetType(Integer))
        dt_new.Columns.Add("PROJ_NAME")
        dt_new.Columns.Add("SEQ", GetType(Integer))
        dt_new.Columns.Add("FLOOR_SEQ", GetType(Integer))
        dt_new.Columns.Add("CAL_PERSENT", GetType(Integer))
        dt_new = getNodeBack(dt_new, bg_id, proj:=id_proj)
        Dim dv As DataView = dt_new.DefaultView
        dv.Sort = "SEQ"
        dt_new = dv.ToTable
        Return dt_new
    End Function

    Public Function getNodeBack(ByRef dt As DataTable, ByVal bgChild_id As Integer, Optional ByVal i As Integer = 1, Optional proj As Integer = 0) As DataTable
        ' Dim dt As New DataTable

        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        dao.getdata_by_Child_id_join(bgChild_id)
        'Dim i As Integer = 1

        For Each dao.fields In dao.datas
            If dao.fields.BUDGET_TYPE_ID <> 1 Then
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("IDA") = 0
                dr("SEQ") = i
                dr("ID_PROJ") = proj
                If dao.fields.BUDGET_TYPE_ID = 5 Then
                    'If dao.fields.BUDGET_CODE IsNot Nothing Then
                    '    dr("PROJ_NAME") = dao.fields.BUDGET_CODE & " - " & dao.fields.BUDGET_DESCRIPTION
                    'Else
                    dr("PROJ_NAME") = dao.fields.BUDGET_DESCRIPTION
                    'End If


                Else
                    dr("PROJ_NAME") = dao.fields.BUDGET_DESCRIPTION
                End If
                dr("FLOOR_SEQ") = dao.fields.BUDGET_TYPE_ID - 1
                dr("SEQ") = dao.fields.BUDGET_TYPE_ID - 1
                dr("CAL_PERSENT") = 0
                i = i + 1
                dt.Rows.Add(dr)
                getNodeBack(dt, dao.fields.BUDGET_CHILD_ID, i, proj)
                If dao.fields.BUDGET_CHILD_ID = 0 Then
                    Exit For
                End If
            End If


        Next
        Return dt
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ref1 As String = "59010690225591231"
        Dim ref2 As String = "58"
        Dim check As Boolean = True
        Dim dao_amt As New DAO_FEE.TB_feedtl
        Dim amt As Double = 0
        Try
            amt = dao_amt.GetDataby_fk_fee(203679)
        Catch ex As Exception

        End Try

        Dim dao As New DAO_FEE.TB_fee_bank
        dao.GetDataby_ref1_ref2(ref1, ref2)
        'dao.GetDataby_ref1(ref1)
        Try

            If dao.fields.IDA = 0 Then 'ไม่พบข้อมูล
                'vc.resCode = "1000"
                'vc.resMesg = "Invalid data"
                'check = False
            End If

            If amt <> 2 Then 'จำนวนเงินไม่ถูก
                'vc.resCode = "1004"
                'vc.resMesg = "Invalid amount"
                'check = False
            End If

            
            If check = True Then 'กรณีผ่านหมด
                'dao.fields.fee_pay = 1
                'dao.update()
                'vc.resCode = "0000"
                'vc.resMesg = "Success"

                Dim feeabbr As String = ""


                ''ปรับสถานะตาราง fee ว่าจ่ายแล้ว
                'Dim dao_fee As New DAO.TB_FEE
                'dao_fee.GetDataby_ref1_ref2(ref1, ref2)

                'Try
                feeabbr = "9065" ' dao_fee2.fields.feeabbr
                'Catch ex As Exception

                'End Try

                'dao_fee2.fields.rcptst = 1
                'dao_fee2.update()

                '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
                'ดึง process id
                Dim dao_type As New DAO_FEE.TB_feetype
                Try
                    dao_type.GetDataby_feeabbr(feeabbr)
                Catch ex As Exception

                End Try
                'Try
                '    'update สถานะ
                '    If dao_fee2.fields.dvcd = 1 Then
                '        Dim bao As New BAO_FEE.FEE
                '        bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                '    ElseIf dao_fee2.fields.dvcd = 2 Then
                '        Dim bao As New BAO_FEE.LGT_NCT2_128
                '        bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                '    ElseIf dao_fee2.fields.dvcd = 3 Then

                '    ElseIf dao_fee2.fields.dvcd = 4 Then

                '    ElseIf dao_fee2.fields.dvcd = 5 Then

                '    ElseIf dao_fee2.fields.dvcd = 6 Then
                '        Try
                Dim dao_txc As New DAO_TXC.TB_RECIVE
                dao_txc.GetDataby_Feeno(5916900)
                For Each dao_txc.fields In dao_txc.datas
                    dao_txc.fields.PAY_BOOK = "0"
                    dao_txc.fields.PAY_NO = "0"
                    dao_txc.fields.PAY_DATE = Date.Now
                    dao_txc.fields.STATUS = 5
                Next
                '            dao_txc.update()
                '        Catch ex As Exception

                '        End Try

                '    End If

                '    'If dao_type.fields.process_id >= 101 And dao_type.fields.process_id <= 119 Then
                '    '    Dim bao As New BAO_FEE.FEE
                '    '    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                '    'ElseIf dao_type.fields.process_id >= 14200051 And dao_type.fields.process_id <= 14200055 Then
                '    '    Dim bao As New BAO_FEE.LGT_NCT2_128
                '    '    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                '    'End If

                'Catch ex As Exception

                'End Try
                '-------------------------------------------
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub aaa()
        Dim xml_name As String = ""
        
        Dim check As Boolean = True
        Dim ref1 As String = "59010690225591231"
        Dim ref2 As String = "58"
        Dim feeno As String = ""


        Dim dao_fee As New DAO_FEE.TB_fee
        '------------------เช็คว่ามีรายการนี้มั้ย----------------
        Dim count_fee As Integer = 0
        count_fee = dao_fee.Countby_ref1_ref2(ref1, ref2)
        'count_fee = dao_fee.Countby_ref1(ref1)
        '-----------------------------------------------

        Dim dao_fee2 As New DAO_FEE.TB_fee
        'dao_fee2.GetDataby_ref1(ref1)
        dao_fee2.GetDataby_ref1_ref2(ref1, ref2)
        Try
            feeno = dao_fee2.fields.feeno
        Catch ex As Exception

        End Try
        Dim feeabbr As String = ""
        If count_fee = 0 Then
            Dim bao_f As New BAO_FEE.FEE
            Dim dt_f As New DataTable
            'dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF(ref1,ref2)
            dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF01(ref1)
            If dt_f.Rows.Count > 0 Then
                'Dim dao_fee1 As New DAO.TB_FEE
                'insert_fee(dao_fee1, dt_f, ref2)
                'dao_fee1.insert()

                Try
                    Dim dao_bank As New DAO_FEE.TB_fee_bank
                    insert_feebank(dao_bank, dt_f, ref2)
                    'dao_bank.fields.fk_fee = dao_fee1.fields.IDA
                    'dao_bank.insert()
                Catch ex As Exception

                End Try


                Dim bao_dtl As New BAO_FEE.FEE
                Dim dt_dtl As New DataTable
                For Each dr As DataRow In dt_f.Rows
                    dt_dtl = bao_dtl.SP_FEEDTL(dr("feeno"), dr("pvncd"), dr("feetpcd"), dr("dvcd"))
                Next

                'Dim dao_dtl As New DAO_FEE.TB_feedtl
                'insert_feedtl(dt_dtl, dao_fee1.fields.IDA)


                'vc.resCode = "0000"
                'vc.resMesg = "Success"
                check = True
            Else
                'vc.resCode = "1000"
                'vc.resMesg = "Invalid data"
                check = False
            End If

            '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
            'ดึง process id
            Dim dao_type As New DAO_FEE.TB_feetype
            Try
                dao_type.GetDataby_feeabbr(feeabbr)
            Catch ex As Exception

            End Try
            Try

                'update สถานะ
                If dao_fee2.fields.dvcd = 1 Then
                    Dim bao As New BAO_FEE.FEE
                    'bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                ElseIf dao_fee2.fields.dvcd = 2 Then
                    'Dim bao As New BAO_FEE.LGT_NCT2_128
                    'bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                ElseIf dao_fee2.fields.dvcd = 3 Then

                ElseIf dao_fee2.fields.dvcd = 4 Then

                ElseIf dao_fee2.fields.dvcd = 5 Then

                ElseIf dao_fee2.fields.dvcd = 6 Then
                    Try
                        Dim dao_txc As New DAO_TXC.TB_RECIVE
                        dao_txc.GetDataby_Feeno(dao_fee2.fields.feeno)
                        For Each dao_txc.fields In dao_txc.datas
                            dao_txc.fields.PAY_BOOK = "0"
                            dao_txc.fields.PAY_NO = "0"
                            dao_txc.fields.PAY_DATE = Date.Now
                            dao_txc.fields.STATUS = 5
                        Next
                        'dao_txc.update()
                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception

            End Try
        Else
            '-------------กรณีมี ต้องเช็คด้วยว่าจ่ายหรือยัง
            Dim dao_amt As New DAO_FEE.TB_feedtl
            Dim amt As Double = 0
            Try
                amt = dao_amt.GetDataby_fk_fee(dao_fee2.fields.IDA)
            Catch ex As Exception

            End Try

            Dim dao As New DAO_FEE.TB_fee_bank
            dao.GetDataby_ref1_ref2(ref1, ref2)
            'dao.GetDataby_ref1(ref1)
            Try

                If dao.fields.IDA = 0 Then 'ไม่พบข้อมูล
                    'vc.resCode = "1000"
                    'vc.resMesg = "Invalid data"
                    check = False
                End If

                If amt <> 2 Then 'จำนวนเงินไม่ถูก
                    'vc.resCode = "1004"
                    'vc.resMesg = "Invalid amount"
                    check = False
                End If

                Try
                    If dao_fee2.fields.rcptst = 1 Then 'เคยจ่ายตังแล้ว
                        'vc.resCode = "2001"
                        'vc.resMesg = "Duplicate transaction"
                        check = False
                    End If
                Catch ex As Exception

                End Try


                If check = True Then 'กรณีผ่านหมด
                    dao.fields.fee_pay = 1
                    'dao.update()
                    'vc.resCode = "0000"
                    'vc.resMesg = "Success"




                    ''ปรับสถานะตาราง fee ว่าจ่ายแล้ว
                    'Dim dao_fee As New DAO.TB_FEE
                    'dao_fee.GetDataby_ref1_ref2(ref1, ref2)

                    Try
                        feeabbr = dao_fee2.fields.feeabbr
                    Catch ex As Exception

                    End Try

                    dao_fee2.fields.rcptst = 1
                    'dao_fee2.update()

                    '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
                    'ดึง process id
                    Dim dao_type As New DAO_FEE.TB_feetype
                    Try
                        dao_type.GetDataby_feeabbr(feeabbr)
                    Catch ex As Exception

                    End Try
                    Try
                        'update สถานะ
                        If dao_fee2.fields.dvcd = 1 Then
                            Dim bao As New BAO_FEE.FEE
                            ' bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                        ElseIf dao_fee2.fields.dvcd = 2 Then
                            ' Dim bao As New BAO_FEE.LGT_NCT2_128
                            'bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                        ElseIf dao_fee2.fields.dvcd = 3 Then

                        ElseIf dao_fee2.fields.dvcd = 4 Then

                        ElseIf dao_fee2.fields.dvcd = 5 Then

                        ElseIf dao_fee2.fields.dvcd = 6 Then
                            Try
                                Dim dao_txc As New DAO_TXC.TB_RECIVE
                                dao_txc.GetDataby_Feeno(feeno)
                                For Each dao_txc.fields In dao_txc.datas
                                    dao_txc.fields.PAY_BOOK = "0"
                                    dao_txc.fields.PAY_NO = "0"
                                    dao_txc.fields.PAY_DATE = Date.Now
                                    dao_txc.fields.STATUS = 5
                                Next
                                'dao_txc.update()
                            Catch ex As Exception

                            End Try

                        End If
                        'If dao_type.fields.process_id >= 101 And dao_type.fields.process_id <= 119 Then
                        '    Dim bao As New BAO_FEE.FEE
                        '    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                        'ElseIf dao_type.fields.process_id >= 14200051 And dao_type.fields.process_id <= 14200055 Then
                        '    Dim bao As New BAO_FEE.LGT_NCT2_128
                        '    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref1, ref2, dao_type.fields.process_id, dao_fee2.fields.dvcd)
                        'End If

                    Catch ex As Exception

                    End Try
                    '-------------------------------------------
                End If
            Catch ex As Exception
                'vc.resCode = "9000"
                'vc.resMesg = "System error"
            End Try

        End If
        Try
            Dim dao_logs As New DAO_FEE.TB_FEE_LOGS
            dao_logs.fields.CREATEDATE = Date.Now
            dao_logs.fields.ref1 = ref1
            dao_logs.fields.ref2 = ref2
            dao_logs.fields.STEP = 2
            'dao_logs.fields.RESULT = vc.resMesg
            dao_logs.fields.XML_PATH = xml_name
            'dao_logs.insert()
        Catch ex As Exception

        End Try
    End Sub

    Sub insert_feebank(ByRef dao As DAO_FEE.TB_fee_bank, ByVal dt As DataTable, ByVal ref02 As String)
        For Each dr As DataRow In dt.Rows
            Try
                dao.fields.dvcd = dr("dvcd")
            Catch ex As Exception

            End Try

            Try
                dao.fields.enddate = CDate(dr("enddate2"))
            Catch ex As Exception

            End Try
            dao.fields.fee_pay = 1
            Try
                dao.fields.feedate = CDate(dr("feedate2"))
            Catch ex As Exception

            End Try
            'dao.fields.fk_fee
            Try
                dao.fields.lcnprnst = dr("lcnprnst")
            Catch ex As Exception

            End Try

            Try
                dao.fields.lmdfdate = CDate(dr("lmdfdate"))
            Catch ex As Exception

            End Try
            Try
                dao.fields.lstfcd = dr("lstfcd2")
            Catch ex As Exception

            End Try
            Try
                dao.fields.pvncd = dr("pvncd")
            Catch ex As Exception

            End Try
            Try
                dao.fields.ref01 = dr("ref01")
            Catch ex As Exception

            End Try
            Try
                dao.fields.ref02 = ref02
            Catch ex As Exception

            End Try

        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        aaa()
    End Sub
End Class