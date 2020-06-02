Imports Telerik.Web.UI
Public Class Frm_Maintain_ReceiveMoney_Receipt_Search_For_Transfer2
    Inherits System.Web.UI.Page

    Private dt_ddl As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_dept()
        End If
    End Sub
    Private Function feeno_format() As String
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing
        Try
            arr_feeno = txt_ORDER_PAY2.Text.Split("/")
            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
    Sub bind_ddl_lcn()
        ddl_lcn.DataSource = dt_ddl
        ddl_lcn.DataBind()
    End Sub
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim dt As New DataTable

        Dim bao As New BAO_BUDGET.FDA_FEE
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(txt_ORDER_PAY2.Text, txt_ORDER_PAY1.Text)
        Dim feeno As String = feeno_format()
        Dim dept As Integer = 0
        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try
        If dept = 2 Then
            Dim bao2 As New BAO_NCT2.LGT_NCT2
            dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
        Else
            dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
        End If

        Dim str_fullname As String = ""
        Try
            Dim bao_name As New BAO_BUDGET.FDA_FEE
            If dt(0)("prnfeest") = "1" Then
                str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
            Else
                str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
            End If
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            dt.Columns("fullname").MaxLength = 9000
            For Each dr As DataRow In dt.Rows
                dr("fullname") = str_fullname
            Next
        Catch ex As Exception

        End Try

        Dim bao_in As New BAO_INFORMIX.INFORMIX
        Try
            'dt_ddl = bao_in.QUERY_GET_DDL_LCNSNM(dt(0)("dvcd"), dt(0)("lcnsid"))
            'dt_ddl = bao_in.QUERY_GET_DDL_LCNSNM_BY_LCNSID(dt(0)("lcnsid"))
            dt_ddl = bao_in.get_lcn_name_type(dt(0)("lcnsid"), dt(0)("lcnscd"))
        Catch ex As Exception

        End Try
        bind_ddl_lcn()

        'Try
        '    If dt(0)("rcptst") = "0" Then
        rg_receive.DataSource = dt
        '    ElseIf dt(0)("rcptst") = "2" Then
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิก');", True)
        '    ElseIf dt(0)("rcptst") = "1" Then
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('รายการนี้ชำระเงินไปแล้ว');", True)
        '    Else
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        '    End If
        'Catch ex As Exception
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        'End Try

        rg_receive.Rebind()
    End Sub

    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("lcnsid", "lcnsid", False)
        Rad_Utility.addColumnBound("dvcd", "dvcd", False)
        Rad_Utility.addColumnBound("feeno", "feeno", False)
        Rad_Utility.addColumnBound("feeabbr", "feeabbr", False)
        Rad_Utility.addColumnBound("pvncd", "pvncd", False)
        Rad_Utility.addColumnBound("fullname", "ได้รับเงินจาก", width:=250)
        Rad_Utility.addColumnBound("feetpnm", "รายการ", width:=300)
        Rad_Utility.addColumnBound("amt", "จำนวนเงิน", is_money:=True, width:=70)
        Rad_Utility.addColumnBound("ref01", "ref.01")
        Rad_Utility.addColumnBound("ref02", "ref.02")
        Rad_Utility.addColumnButton("P", "ดึงข้อมูล", "P", 0, "คุณต้องการดึงข้อมูลนี้หรือไม่", width:=120)
        Rad_Utility.addColumnButton("pay", "ชำระเงิน", "pay", 0, "คุณต้องการชำระเงินหรือไม่", width:=120)
        Rad_Utility.addColumnButton("PP", "พิมพ์ใบเสร็จ", "PP", 0, "", width:=120, _display:=False)
    End Sub

    Private Sub rg_receive_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_receive.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "pay" Then
                Dim dao_fee As New DAO_FEE.TB_fee
                dao_fee.Getdata_by_feeno_and_dvcd(item("feeno").Text, item("dvcd").Text)
                dao_fee.fields.rcptst = 1

                Dim dao_t As New DAO_FEE.TB_feetype
                dao_t.GetDataby_feeabbr_dvcd(item("feeabbr").Text, item("dvcd").Text)

                If item("dvcd").Text = "6" Then
                    Try
                        Dim bao_txt As New BAO_FEE.FEE
                        bao_txt.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXT_EXTEND_DATE(item("feeno").Text)
                    Catch ex As Exception

                    End Try
                ElseIf item("dvcd").Text = "2" Then
                    Dim bao As New BAO_NCT2.LGT_NCT2
                    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE2(item("ref01").Text, item("ref02").Text, item("dvcd").Text)
                ElseIf item("dvcd").Text = "1" Then

                End If

                dao_fee.update()

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            ElseIf e.CommandName = "P" Then
                Dim bao_rep As New BAO_INFORMIX.INFORMIX
                Dim bool As Boolean
                bool = bao_rep.Count_Repeat_Old(item("feeno").Text, item("dvcd").Text)
                Dim bao_in As New BAO_INFORMIX.INFORMIX
                Dim dt_aa As New DataTable
                Try
                    dt_aa = bao_in.QUERY_GET_DDL_LCNSNM_BY_LCNSID(item("lcnsid").Text)
                Catch ex As Exception

                End Try
                'If bool = False Then
                Dim i As Integer = 0
                Dim runno As Integer = 0

                Dim dao_fee As New DAO_FEE.TB_fee
                dao_fee.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(item("feeno").Text, item("dvcd").Text, item("feeabbr").Text, item("pvncd").Text)
                Dim dao_bank As New DAO_FEE.TB_fee_bank
                dao_bank.Getdata_by_ref01_and_ref02(dao_fee.fields.ref01, dao_fee.fields.ref02)

                Dim bao_informix As New BAO_INFORMIX.INFORMIX
                Dim _year As Integer = 0
                Try
                    _year = Year(Date.Now)
                Catch ex As Exception

                End Try
                If _year < 2500 Then
                    _year += 543
                End If
                Dim max_no As Integer = bao_informix.SP_GET_MAX_RCPTNO_BY_YEAR(_year)
                runno = max_no + 1
                Try
                    Dim pvncd_1 As Integer = 0
                    pvncd_1 = dao_bank.fields.pvncd
                    If pvncd_1 <> 10 Then
                        pvncd_1 = 10
                    End If

                    Dim ds_bank As New DS_FEETableAdapters.feebankTableAdapter
                    ds_bank.InsertQuery(pvncd_1, dao_bank.fields.dvcd, dao_bank.fields.ref01, dao_bank.fields.ref02, IIf(IsDBNull(dao_bank.fields.feedate), Nothing, CDate(dao_bank.fields.feedate)), _
                                        IIf(IsDBNull(dao_bank.fields.enddate), Nothing, CDate(dao_bank.fields.enddate)), dao_bank.fields.lcnprnst, dao_bank.fields.lstfcd, IIf(IsDBNull(dao_bank.fields.lmdfdate), Nothing, CDate(dao_bank.fields.lmdfdate)))
                Catch ex As Exception
                    i += 1
                End Try
                'Dim pvncd = 0, dvcd = 0, feetpcd As Integer = 0
                'Dim feeabbr As String = ""
                '
                Dim feedate, rcptdate, expdate, enddate, cncdate, lmdfdate As New Object
                Try
                    feedate = CDate(dao_fee.fields.feedate)
                Catch ex As Exception

                End Try
                Try
                    rcptdate = CDate(dao_fee.fields.rcptdate)
                Catch ex As Exception
                    rcptdate = Nothing
                End Try
                Try
                    expdate = CDate(dao_fee.fields.expdate)
                Catch ex As Exception
                    expdate = Nothing
                End Try
                Try
                    enddate = CDate(dao_fee.fields.enddate)
                Catch ex As Exception
                    enddate = Nothing
                End Try
                Try
                    cncdate = CDate(dao_fee.fields.cncdate)
                Catch ex As Exception
                    cncdate = Nothing
                End Try
                Try
                    lmdfdate = CDate(dao_fee.fields.lmdfdate)
                Catch ex As Exception
                    lmdfdate = Nothing
                End Try
                Dim pvncd = 0, dvcd = 0, feetpcd = 0, feeno = 0, lcnsid = 0, lctnmcd = 0, lcnscd = 0, lctcd = 0, prnfeest = 0, rcptst = 0, rcptyear = 0, feestfcd = 0, cncstfcd = 0, feest = 0, lstfcd As Integer = 0
                Dim feeabbr = "", ref01 = "", ref02 = "", remark = "", pvnbookno = "", pvnrcptno As String = ""

                With dao_fee.fields
                    Try
                        feeabbr = .feeabbr
                    Catch ex As Exception

                    End Try
                    Try
                        pvncd = .pvncd
                    Catch ex As Exception

                    End Try
                    Try
                        dvcd = .dvcd
                    Catch ex As Exception

                    End Try
                    Try
                        feetpcd = .feetpcd
                    Catch ex As Exception

                    End Try
                    Try
                        feeno = .feeno
                    Catch ex As Exception

                    End Try
                    Try
                        ref01 = .ref01
                    Catch ex As Exception

                    End Try
                    Try
                        ref02 = .ref02
                    Catch ex As Exception

                    End Try
                    Try
                        lcnsid = .lcnsid
                    Catch ex As Exception

                    End Try
                    Try
                        Dim ii As Integer = 0
                        For Each dr As DataRow In dt_aa.Select("lctnmcd=" & ddl_lcn.SelectedValue)
                            lctnmcd = dr("lctnmcd")
                            ii += 1
                        Next
                        If ii = 0 Then
                            lctnmcd = .lctnmcd
                        End If

                    Catch ex As Exception
                        lctnmcd = .lctnmcd
                    End Try
                    Try
                        Dim ii As Integer = 0
                        For Each dr As DataRow In dt_aa.Select("lctnmcd=" & ddl_lcn.SelectedValue)
                            lcnscd = dr("lcnscd")
                        Next
                        If ii = 0 Then
                            lcnscd = .lcnscd
                        End If
                    Catch ex As Exception
                        lcnscd = .lcnscd
                    End Try
                    Try
                        Dim ii As Integer = 0
                        For Each dr As DataRow In dt_aa.Select("lctnmcd=" & ddl_lcn.SelectedValue)
                            lctcd = dr("lctcd")
                        Next
                        If ii = 0 Then
                            lctcd = .lctcd
                        End If
                    Catch ex As Exception
                        lctcd = .lctcd
                    End Try
                    Try
                        prnfeest = .prnfeest
                    Catch ex As Exception

                    End Try
                    Try
                        rcptst = .rcptst
                    Catch ex As Exception

                    End Try
                    Try
                        rcptyear = .rcptyear
                    Catch ex As Exception
                        rcptyear = _year
                    End Try
                    Try
                        feestfcd = .feestfcd
                    Catch ex As Exception

                    End Try
                    Try
                        remark = .remark
                    Catch ex As Exception

                    End Try
                    Try
                        cncstfcd = .cncstfcd
                    Catch ex As Exception

                    End Try
                    Try
                        pvnbookno = .pvnbookno
                    Catch ex As Exception

                    End Try
                    Try
                        pvnrcptno = .pvnrcptno
                    Catch ex As Exception

                    End Try
                    Try
                        feest = .feest
                    Catch ex As Exception

                    End Try
                    Try
                        lstfcd = .lstfcd
                    Catch ex As Exception

                    End Try
                End With

                If lcnscd = 0 Then
                    lcnscd = 1
                End If
                If lctnmcd = 0 Then
                    lctnmcd = 1
                End If
                If lctcd = 0 Then
                    lctcd = 1
                End If
                Try
                    If pvncd <> 10 Then
                        pvncd = 10
                    End If

                    Dim ds As New DS_FEETableAdapters.feeTableAdapter

                    ds.InsertQuery(pvncd, dvcd, feetpcd, feeno, feeabbr, feedate, ref01, lcnsid, lctnmcd, lcnscd, lctcd, _
                    prnfeest, rcptst, rcptyear, runno, rcptdate, feestfcd, remark, _
                    expdate, enddate, cncstfcd, cncdate, pvnbookno, pvnrcptno, _
                    feest, lstfcd, lmdfdate)


                    'ds.InsertQuery(dao_fee.fields.pvncd, dao_fee.fields.dvcd, dao_fee.fields.feetpcd, dao_fee.fields.feeno, dao_fee.fields.feeabbr, IIf(IsDBNull(dao_fee.fields.feedate), Date.Now, CDate(dao_fee.fields.feedate)), _
                    '               dao_fee.fields.ref01, dao_fee.fields.lcnsid, IIf(IsDBNull(dao_fee.fields.lctnmcd), 0, dao_fee.fields.lctnmcd), IIf(IsDBNull(dao_fee.fields.lcnscd), 0, dao_fee.fields.lcnscd), IIf(IsDBNull(dao_fee.fields.lctcd), 0, dao_fee.fields.lctcd), _
                    '               IIf(IsDBNull(dao_fee.fields.prnfeest), 0, dao_fee.fields.prnfeest), IIf(IsDBNull(dao_fee.fields.rcptst), 0, dao_fee.fields.rcptst), IIf(IsDBNull(dao_fee.fields.rcptyear), IIf(IsDBNull(dao_fee.fields.rcptyear), _year, dao_fee.fields.rcptyear), dao_fee.fields.rcptyear), runno, _
                    '               IIf(IsDBNull(dao_fee.fields.rcptdate), Nothing, CDate(dao_fee.fields.rcptdate)), IIf(IsDBNull(dao_fee.fields.feestfcd), 0, dao_fee.fields.feestfcd), IIf(IsDBNull(dao_fee.fields.remark), "", dao_fee.fields.remark), IIf(IsDBNull(dao_fee.fields.expdate), Date.Now, CDate(dao_fee.fields.expdate)), _
                    '                IIf(IsDBNull(dao_fee.fields.enddate), Nothing, CDate(dao_fee.fields.enddate)), IIf(IsDBNull(dao_fee.fields.cncstfcd), 0, dao_fee.fields.cncstfcd), IIf(IsDBNull(dao_fee.fields.cncdate), Date.Now, CDate(dao_fee.fields.cncdate)), _
                    '                IIf(IsDBNull(dao_fee.fields.pvnbookno), "", dao_fee.fields.pvnbookno), IIf(IsDBNull(dao_fee.fields.pvnrcptno), "", dao_fee.fields.pvnrcptno), IIf(IsDBNull(dao_fee.fields.feest), 0, dao_fee.fields.feest), IIf(IsDBNull(dao_fee.fields.lstfcd), 0, dao_fee.fields.lstfcd), IIf(IsDBNull(dao_fee.fields.lmdfdate), Date.Now, CDate(dao_fee.fields.lmdfdate)))

                Catch ex As Exception
                    i += 1
                End Try



                Dim dao_dtl As New DAO_FEE.TB_feedtl
                dao_dtl.Getdata_by_fee_id(dao_fee.fields.IDA)

                For Each dao_dtl.fields In dao_dtl.datas
                    Dim rcvabbr = "", rcvcd = "", appabbr = "", appvcd As String = ""
                    Dim rcvno = 0, apppvncd = 0, timeno = 0, finevalue As Integer = 0
                    Dim appvno = 0, amt As Double = 0
                    With dao_dtl.fields
                        Try
                            rcvabbr = .rcvabbr
                        Catch ex As Exception

                        End Try
                        Try
                            rcvcd = .rcvcd
                        Catch ex As Exception

                        End Try
                        Try
                            appabbr = .appabbr
                        Catch ex As Exception

                        End Try
                        Try
                            appvcd = .appvcd
                        Catch ex As Exception

                        End Try
                        Try
                            rcvno = .rcvno
                        Catch ex As Exception

                        End Try
                        Try
                            apppvncd = .apppvncd
                        Catch ex As Exception

                        End Try
                        Try
                            timeno = .timeno
                        Catch ex As Exception

                        End Try
                        Try
                            finevalue = .finevalue
                        Catch ex As Exception

                        End Try
                        Try
                            appvno = .appvno
                        Catch ex As Exception

                        End Try
                        Try
                            amt = .amt
                        Catch ex As Exception

                        End Try
                        Try
                            finevalue = .finevalue
                        Catch ex As Exception

                        End Try
                    End With

                    Try
                        If pvncd <> 10 Then
                            pvncd = 10
                        End If
                        Dim ds_dtl As New DS_FEETableAdapters.feedtlTableAdapter
                        ds_dtl.InsertQuery(pvncd, dvcd, feetpcd, feeno, dao_dtl.fields.rid, rcvabbr, rcvcd, _
                                           rcvno, apppvncd, appabbr, appvcd, _
                                           appvno, timeno, amt, finevalue)
                    Catch ex As Exception
                        i += 1
                    End Try
                Next

                If i = 0 Then
                    Dim dao_type As New DAO_FEE.TB_feetype
                    Try
                        dao_type.Getdata_by_feeabbr(dao_fee.fields.feeabbr)
                    Catch ex As Exception

                    End Try
                    Dim bao_fee As New BAO_FEE.FEE
                    bao_fee.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, dao_type.fields.process_id, dao_fee.fields.dvcd)

                    'dao_fee.fields.rcptst = 1
                    dao_fee.update()

                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('หมายเลขใบเสร็จคือ " & runno & "');", True)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาดจำนวน " & i & " รายการ');", True)
                End If
                'Else
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เคยดึงรายการนี้แล้ว');", True)
                'End If


            End If
        End If
    End Sub

    Private Sub rg_receive_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim PP As LinkButton = DirectCast(item("PP").Controls(0), LinkButton)
            Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?aa=1&feeno=" & item("feeno").Text & "&feeabbr=" & item("feeabbr").Text & "&lcnsid=" & item("lcnsid").Text & "&dvcd=" & item("dvcd").Text & "&staff=1&myear=" & Request.QueryString("myear")
            PP.Attributes.Add("OnClick", "Popups('" & url_p & "'); return false;")
            Dim btn_Pay As LinkButton = DirectCast(item("pay").Controls(0), LinkButton)
            Dim btn_P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)


            Dim bao_rep As New BAO_INFORMIX.INFORMIX
            Dim bool As Boolean
            bool = bao_rep.Count_Repeat_Old(item("feeno").Text, item("dvcd").Text)
            Dim dao As New DAO_FEE.TB_fee
            dao.Getdata_by_feeno_and_dvcd(item("feeno").Text, item("dvcd").Text)
            'If bool = False Then
            '    btn_Pay.Style.Add("display", "none")
            '    btn_P.Style.Add("display", "block")
            'Else
            '    btn_Pay.Style.Add("display", "block")
            '    btn_P.Style.Add("display", "none")
            'End If

            'Try
            '    If dao.fields.rcptst = 1 Then
            '        btn_Pay.Style.Add("display", "none")
            '        btn_P.Style.Add("display", "none")
            '    End If
            'Catch ex As Exception

            'End Try
        End If
    End Sub
    Sub bind_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.SP_MAS_RECEIPT_DEPARTMENT

        ddl_department.DataSource = dt
        ddl_department.DataBind()
    End Sub
    Private Sub rg_receive_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_receive.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno(txt_ORDER_PAY2.Text, txt_ORDER_PAY1.Text)
        'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno_format, ddl_department.SelectedValue)

        Dim dept As Integer = 0
        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try
        If dept = 2 Then
            Dim bao2 As New BAO_NCT2.LGT_NCT2
            dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno_format(), dept)
        Else
            dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno_format(), dept)
        End If

        Dim count_row As Integer = 0
        Dim dt_count As Integer = 0
        Try
            count_row = dt.Rows.Count
        Catch ex As Exception

        End Try
        'If dt.Rows.Count > 0 Then
        Try
            If dt(0)("rcptst") = "0" Then
                rg_receive.DataSource = dt
            End If
        Catch ex As Exception

        End Try

        'For i As Integer = 0 To dt.Rows.Count - 1
        '    dt_count += 1
        'Next
        'If count_row = dt_count Then
        '    rg_receive.DataSource = dt
        'End If
        'Else
        'End If

    End Sub
End Class