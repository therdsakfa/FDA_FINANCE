Imports Telerik.Web.UI
Imports Telerik.Web.UI.Barcode
Imports System.IO

Public Class Frm_Maintain_Receive_Money_V3_Insert
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _process As String
    Private dt_rg As DataTable
    Dim date_str As Date
    Private _receiver_id As Integer = 0
    Dim _url_qr As String
    Private _CLS As New CLS_SESSION
    Sub runQuery()
        bgYear = Request.QueryString("myear")

        Try
            _CLS = Session("CLS")

            _receiver_id = Get_Checker_ID(_CLS.CITIZEN_ID) 'Request.QueryString("r")
            If _receiver_id = 0 Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            Try
                Dim dao_re As New DAO_MAS.TB_MAS_MONEY_RECEIVER
                dao_re.Getdata_by_RECEIVER_MONEY_ID(_receiver_id)
                lbl_receiver.Text = "ผู้รับเงิน : " & dao_re.fields.RECEIVER_NAME
            Catch ex As Exception

            End Try
            If Request.QueryString("pre") <> "" Then
                txt_FULL_RECEIVE_NUMBER.Enabled = True
            End If
            date_str = CDate(Request.QueryString("date"))
            bind_income()
            'bind_customer()
            'bind_ddl_receipt_type()

            If Request.QueryString("law") <> "" Then
                ddl_Income.DropDownSelectData(48)
            End If
            bind_ddl_money_type()
            bind_dept()
            'set_amount()
            'txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()
            Try
                txt_MONEY_RECEIVE_DATE.Text = date_str.ToShortDateString()
            Catch ex As Exception

            End Try

            bind_bank()


            'If Request.QueryString("ida") <> "" Then
            '    btn_save.Style.Add("display", "none")
            '    'btn_print.Style.Add("display", "block")
            '    btn_reset.Style.Add("display", "block")
            '    'Panel1.Style.Add("display", "block")
            'Else
            '    btn_save.Style.Add("display", "block")
            '    'btn_print.Style.Add("display", "none")
            '    btn_reset.Style.Add("display", "none")
            '    'Panel1.Style.Add("display", "none")
            'End If
        End If
    End Sub
    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("feetpnm", "รายการ", width:=350)
        Rad_Utility.addColumnBound("amt", "จำนวนเงิน", is_money:=True, footer_txt:="รวม ")
        Rad_Utility.addColumnBound("appvno", "appvno", Display:=False)
        Rad_Utility.addColumnBound("feedtl", "feedtl", Display:=False)
        'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=100)
    End Sub
    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_search.Click

        'Dim count_bg As Integer = 0
        'Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'count_bg = dao.count_receipt4(ddl_department.SelectedValue, fee_format, txt_ORDER_PAY1.Text)


        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        Dim feeno As String = feeno_format()
        Dim dept As Integer = 0
        Dim str_fullname As String = ""
        Dim count_bg As Integer = 0
        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY

        Dim bao_dvcd As New BAO_BUDGET.FDA_FEE
        Dim str_dvcd_old As String = ""
        Dim acc_type As Integer = 0
        '--------------------------------------------------------------------------------- เก่า
        '-------------แก้ลบ elo
        'Dim ws_dt As New WS_OLD_DT
        Try
            'str_dvcd_old = bao_dvcd.get_dvcd_auto(feeno, txt_ORDER_PAY1.Text)
            '-------------แก้ลบ elo
            'str_dvcd_old = ws_dt.get_dvcd_auto(feeno, txt_ORDER_PAY1.Text)
        Catch ex As Exception

        End Try
        Dim dao_fee2 As New DAO_FEE.TB_fee
        Try
            dao.Getdata_by_feeno_feeabbr(feeno, txt_ORDER_PAY1.Text)
            ddl_department.DropDownSelectData(dao.fields.DVCD)
        Catch ex As Exception

        End Try
        Try

            dao_fee2.Getdata_by_feeno_and_feeabbr(feeno, txt_ORDER_PAY1.Text)
            str_dvcd_old = dao_fee2.fields.dvcd
        Catch ex As Exception

        End Try

        Dim dao_dl As New DAO_FEE.TB_feedtl

        Try
            dao_dl.GetDataby_fk_fee(dao_fee2.fields.IDA)
            Dim process_dl As String = ""
            process_dl = dao_dl.fields.process_id
            If process_dl = "7701" Or process_dl = "7702" Or process_dl = "7703" Or process_dl = "7704" Or _
                process_dl = "7705" Or process_dl = "7706" Or process_dl = "7707" Then
                cb_sinbon.Checked = True
                Dim persent As String = ""
                ddl_department.DropDownSelectData(7)
                persent = dao_dl.fields.REMARK
                If persent = "60" Then
                    DropDownList1.DropDownSelectData(1)
                ElseIf persent = "80" Then
                    DropDownList1.DropDownSelectData(2)
                End If
                ddl_Income.DropDownSelectData(4)
            End If


        Catch ex As Exception

        End Try
        Dim panelty_val As String = ""
        Try
            For Each dao_dl.fields In dao_dl.datas
                If dao_dl.fields.process_id = "555555" Then
                    panelty_val = Right(Left(dao_dl.fields.lcnno_convert, 14), 10)
                End If
            Next

        Catch ex As Exception

        End Try
        If panelty_val = "4990000001" Or panelty_val = "4990000002" Then
            Try
                ddl_Income.DropDownSelectData(5)
            Catch ex As Exception

            End Try
        End If

        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try

        dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY
        count_bg = dao.count_receipt5(ddl_department.SelectedValue, feeno, txt_ORDER_PAY1.Text)
        'count_bg = 0
        If count_bg = 0 Then

            Try
                If str_dvcd_old <> "" Then
                    ddl_department.SelectedValue = str_dvcd_old
                End If

            Catch ex As Exception

            End Try

            Dim ref1 As String = ""
            Dim ref2 As String = ""
            Dim old_pvncd As Integer = 0
            If Request.QueryString("law") = "" Then
                Try
                    '---------------------------------------------------------------------
                    'dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, ddl_department.SelectedValue, txt_ORDER_PAY1.Text)
                    '-------------แก้ลบ elo
                    'dt = ws_dt.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, ddl_department.SelectedValue, txt_ORDER_PAY1.Text)
                Catch ex As Exception

                End Try
                If dt.Rows.Count = 0 Then
                    If dept = 2 Then
                        Dim bao2 As New BAO_NCT2.LGT_NCT2
                        dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
                    Else
                        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
                    End If
                End If
            Else
                'Dim dao_fee_l44 As New DAO_FEE.TB_fee
                'dao_fee_l44.Getdata_by_feeno_and_dvcd(feeno, ddl_department.SelectedValue)
                'Dim dao_det_l44 As New DAO_FEE.TB_feedtl
                'dao_det_l44.Getdata_by_fee_id(dao_fee_l44.fields.IDA)
                dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44(feeno, ddl_department.SelectedValue)
            End If
            'For Each dr As DataRow In dt.Rows
            '    acc_type = dr("acc_type")
            'Next

            'If Request.QueryString("law") <> "" Then
            '    If acc_type = 2 Then

            '    Else

            '    End If

            'Else

            'End If

            Dim dao_fee As New DAO_FEE.TB_fee
            For Each dr As DataRow In dt.Rows
                ref1 = dr("ref01")
                ref2 = dr("ref02")
                Try
                    old_pvncd = dr("pvncd")
                Catch ex As Exception

                End Try
            Next


            '------------------เช็คว่ามีรายการนี้มั้ย----------------
            Dim count_fee As Integer = 0
            count_fee = dao_fee.Countby_ref1_ref2(ref1, ref2)
            '-----------------------------------------------
            'If count_fee = 0 Then
            '    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old(feeno, ddl_department.SelectedValue)
            'Else
            '    If dept = 2 Then
            '        Dim bao2 As New BAO_NCT2.LGT_NCT2
            '        dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
            '    Else
            '        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
            '    End If
            'End If

            Try
                Dim dao_fee_nm As New DAO_FEE.TB_fee
                dao_fee_nm.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(feeno, ddl_department.SelectedValue, txt_ORDER_PAY1.Text, dt(0)("pvncd"))
                Try
                    str_fullname = dao_fee_nm.fields.company_name
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try

            If str_fullname = "" Then
                Try
                    Dim bao_name As New BAO_BUDGET.FDA_FEE
                    If dt(0)("prnfeest") = "1" Then
                        '--------------------------------------------
                        'str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                        '-------------แก้ลบ elo
                        'str_fullname = ws_dt.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    Else
                        '-----------------------------------------------
                        'str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                        '-------------แก้ลบ elo
                        'str_fullname = ws_dt.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    End If
                Catch ex As Exception

                End Try
            End If
            If chk_expdate(ref1, ref2) = True Then
                If count_fee = 0 Then
                    Try
                        txt_FullNAME.Text = str_fullname

                        'txt_FullNAME.Text = dt(0)("fullname")
                    Catch ex As Exception

                    End Try
                    Try
                        txt_customer.Text = dt(0)("lcnsid")
                    Catch ex As Exception

                    End Try
                    Try

                    Catch ex As Exception

                    End Try
                    Try
                        dao_dl.GetDataby_fk_fee(dao_fee2.fields.IDA)
                        Dim process_dl As String = ""
                        process_dl = dao_dl.fields.process_id
                        If process_dl = "7701" Or process_dl = "7702" Or process_dl = "7703" Or process_dl = "7704" Or _
                        process_dl = "7705" Or process_dl = "7706" Or process_dl = "7707" Then
                            Dim dt99 As New DataTable
                            Dim bao99 As New BAO_BUDGET.Maintain
                            Try
                                'dt99 = bao99.SP_get_receipt_data_det_feeno_V2_9005(Request.QueryString("id_feeno"))
                                'txt_description.Text = dt99(0)("feetpnm")
                                Dim dao_fee_fine As New DAO_FEE.TB_FEE_FINE
                                dao_fee_fine.Getdata_by_fk_fee(dao_fee2.fields.IDA)
                                Dim first_txt As String = ""
                                Dim second_txt As String = ""
                                first_txt = dao_fee_fine.fields.process_name.Replace("ใบสั่งชำระ", "")
                                For Each dao_fee_fine.fields In dao_fee_fine.datas
                                    If second_txt = "" Then
                                        second_txt = dao_fee_fine.fields.descriptions
                                    Else
                                        second_txt &= " ," & dao_fee_fine.fields.descriptions
                                    End If
                                Next
                                txt_description.Text = first_txt & " " & second_txt ' dt99(0)("feetpnm")
                            Catch ex As Exception
                                txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty)
                            End Try

                        Else
                            txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty)
                        End If

                    Catch ex As Exception

                    End Try
                    Try

                        'ddl_department.DataBind()
                        'ddl_department.DropDownSelectData(dt(0)("dvcd"))

                        Dim pvncd As Integer = 0
                        Try
                            pvncd = dt(0)("pvncd")
                        Catch ex As Exception
                            pvncd = 10
                        End Try
                        '------------------------------------------------------------------
                        Dim bao_det As New BAO_BUDGET.FDA_FEE
                        'dt_rg = bao_det.SP_GET_FEEDTL_OLD(feeno, dt(0)("dvcd"), pvncd, dt(0)("feeabbr"))

                        '-------------แก้ลบ elo
                        'dt_rg = ws_dt.SP_GET_FEEDTL_OLD(feeno, dt(0)("dvcd"), pvncd, dt(0)("feeabbr"))
                    Catch ex As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                    End Try


                Else

                    If Request.QueryString("law") = "" Then
                        If dept = 2 Then
                            'Dim bao2 As New BAO_NCT2.LGT_NCT2
                            dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
                        Else
                            dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
                        End If
                    Else
                        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44(feeno, ddl_department.SelectedValue)
                    End If

                    If dt.Rows.Count > 0 Then
                        txt_FullNAME.Text = str_fullname 'dt(0)("fullname")
                        txt_customer.Text = dt(0)("lcnsid")
                        ddl_department.DataBind()
                        ddl_department.DropDownSelectData(dt(0)("dvcd"))
                        txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty) '

                        Dim bao_det As New BAO_BUDGET.FDA_FEE
                        Dim dao_fee222 As New DAO_FEE.TB_fee
                        dao_fee222.GetDataby_ref1_ref2(ref1, ref2)
                        Try
                            dt_rg = bao_det.SP_GET_FEEDTL_V3(dao_fee222.fields.IDA)
                        Catch ex As Exception

                        End Try

                        Try
                            dao_dl.GetDataby_fk_fee(dao_fee2.fields.IDA)
                            Dim process_dl As String = ""
                            process_dl = dao_dl.fields.process_id
                            If process_dl = "7701" Or process_dl = "7702" Or process_dl = "7703" Or process_dl = "7704" Or _
                            process_dl = "7705" Or process_dl = "7706" Or process_dl = "7707" Then
                                Dim dt99 As New DataTable
                                Dim bao99 As New BAO_BUDGET.Maintain
                                Try
                                    'dt99 = bao99.SP_get_receipt_data_det_feeno_V2_9005(Request.QueryString("id_feeno"))
                                    Dim dao_fee_fine As New DAO_FEE.TB_FEE_FINE
                                    dao_fee_fine.Getdata_by_fk_fee(dao_fee222.fields.IDA)
                                    Dim first_txt As String = ""
                                    Dim second_txt As String = ""
                                    first_txt = dao_fee_fine.fields.process_name.Replace("ใบสั่งชำระ", "")
                                    For Each dao_fee_fine.fields In dao_fee_fine.datas
                                        If second_txt = "" Then
                                            second_txt = dao_fee_fine.fields.descriptions
                                        Else
                                            second_txt &= " ," & dao_fee_fine.fields.descriptions
                                        End If
                                    Next
                                    txt_description.Text = first_txt & " " & second_txt ' dt99(0)("feetpnm")
                                Catch ex As Exception
                                    txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty)
                                End Try

                            Else
                                txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty)
                            End If

                        Catch ex As Exception

                        End Try


                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                    End If
                End If

                rg_receive.Rebind()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ใบสั่งหมดอายุ');", True)
            End If
            
        Else
            Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_re.get_dat_receive(dept, feeno, txt_ORDER_PAY1.Text)
            Dim datte_re As String = ""
            Dim txt As String = ""
            Try
                datte_re = CDate(dao_re.fields.MONEY_RECEIVE_DATE).ToShortDateString()
            Catch ex As Exception

            End Try
            Dim full_no As String = ""
            Try
                full_no = dao_re.fields.FULL_RECEIVE_NUMBER
            Catch ex As Exception

            End Try
            Try
                txt = " ในวันที่ " & datte_re & " เลขที่ใบเสร็จคือ " & full_no
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('รายการนี้ออกใบเสร็จไปแล้ว" & txt & "');", True)
        End If
    End Sub
    Public Sub bind_ddl_money_type()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        'dt = bao.get_money_type_list
        Try
            Dim dao As New DAO_MAS.TB_MAS_INCOME
            dao.GetDataby_IDA(ddl_Income.SelectedValue)
            dt = bao.get_money_type_list_by_id(dao.fields.HEAD_ID)
        Catch ex As Exception

        End Try

        ddl_money_type.DataSource = dt
        ddl_money_type.DataBind()
    End Sub
    Sub bind_income()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.get_income_tb()

        ddl_Income.DataSource = dt
        ddl_Income.DataBind()
    End Sub
    Sub bind_dept()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.SP_MAS_RECEIPT_DEPARTMENT

        ddl_department.DataSource = dt
        ddl_department.DataBind()
    End Sub
    Sub bind_bank()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_bank()

        ddl_bank.DataSource = dt
        ddl_bank.DataBind()
    End Sub

    'Sub bind_customer()
    '    'Dim bao_cus As New BAO_BUDGET.MASS
    '    'Dim dt_cus As DataTable = bao_cus.get_customer()

    '    Dim bao As New BAO_BUDGET.LGTCPN
    '    Dim dt As New DataTable
    '    dt = bao.SP_LCNSID_NM_ALL()

    '    dd_CUSTOMER.DataSource = dt
    '    dd_CUSTOMER.DataBind()
    'End Sub
    'Public Sub bind_ddl_receipt_type()
    '    Dim bao As New BAO_BUDGET.FDA_FEE
    '    Dim dt As DataTable = bao.SP_GET_RECEIPT_TYPE()

    '    ddl_abbr_type.DataSource = dt
    '    ddl_abbr_type.DataBind()
    'End Sub
    Private Function feeno_format()
        Dim fee_format As String = ""
        Dim arr_feeno As String() = Nothing
        Try
            arr_feeno = txt_ORDER_PAY2.Text.Split("/")
            If Len(arr_feeno(0)) < 5 Then
                Try
                    arr_feeno(0) = String.Format("{0:00000}", CInt(arr_feeno(0)))
                Catch ex As Exception

                End Try
            
            End If

            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
    Private Function chk_expdate(ByVal ref01 As String, ByVal ref02 As String) As Boolean
        Dim bool As Boolean = False
        Dim count_fee As Integer = 0
        Dim dao_fee As New DAO_FEE.TB_fee
        count_fee = dao_fee.Countby_ref1_ref2(ref01, ref02)
        If count_fee = 0 Then
            'Dim bao_f As New BAO_FEE.FEE
            'Dim dt_f As New DataTable
            'dt_f = bao_f.SP_COUNT_FEE_OLD_BY_REF01(ref01)
            'Dim enddate As Date
            'For Each dr As DataRow In dt_f.Rows
            '    Dim bao_extend As New BAO_FEE.FEE
            '    Try
            '        enddate = CDate(dr("enddate"))
            '        If CDate(Date.Now) <= enddate Then
            '            bool = True
            '        Else
            '            bool = False
            '        End If
            '    Catch ex As Exception
            '        bool = False
            '    End Try

            'Next
            bool = True
        Else
            Dim dao_fee2 As New DAO_FEE.TB_fee
            dao_fee2.GetDataby_ref1_ref2(ref01, ref02)
            'Dim bao_extend As New BAO_FEE.FEE
            'Dim bool_ex As Boolean = False
            Dim enddate As Date
            'bool_ex = bao_extend.Q_feetype_by_feeabbr(dao_fee2.fields.feeabbr)
            'If bool_ex = True Then
            Try
                enddate = CDate(dao_fee2.fields.enddate)
                If CDate(Date.Now) <= enddate Then
                    bool = True
                Else
                    bool = False
                End If
            Catch ex As Exception
                bool = False
            End Try
            'End If
            bool = True 'แก้ช่วยป๊อป
        End If
        Return bool
    End Function
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        'dao_rec.get_receiver()
        'Dim a As Integer = dao_rec.fields.RECEIVER_MONEY_ID
        'dao.fields.RECEIVE_MONEY_TYPE = rbl_RECEIVE_MONEY_TYPE.SelectedItem.Value
        dao.fields.RECEIVE_MONEY_DESCRIPTION = txt_description.Text 'ddl_abbr_type.SelectedItem.Text 'txt_RECEIVE_MONEY_DESCRIPTION.Text
        dao.fields.FULLNAME = txt_FullNAME.Text 'dd_CUSTOMER.SelectedItem.Text
        dao.fields.CUSTOMER_ID = 0 'dd_CUSTOMER.SelectedValue
        dao.fields.RECEIVER_MONEY_ID = _receiver_id
        dao.fields.RECEIVE_AMOUNT = 0 'txt_RECEIVE_AMOUNT.Text
        'dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
        dao.fields.BUDGET_YEAR = bgYear
        Try
            dao.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
        Catch ex As Exception

        End Try
        dao.fields.RECEIVE_MONEY_TYPE = ddl_receive_type.SelectedValue
        dao.fields.MONEY_TYPE_ID = ddl_money_type.SelectedValue


        dao.fields.ORDER_PAY1 = txt_ORDER_PAY1.Text
        'dao.fields.ORDER_PAY2 = txt_ORDER_PAY2.Text

        dao.fields.INCOME_IDA = ddl_Income.SelectedValue
        dao.fields.IS_SINBON = cb_sinbon.Checked
        dao.fields.IS_CHECK_OUT_PROVINCE = cb_IS_CHECK_OUT_PROVINCE.Checked
        dao.fields.IS_SEND_TO_BANK = cb_IS_SEND_TO_BANK.Checked
        Try
            dao.fields.SINBON_ID = DropDownList1.SelectedValue
        Catch ex As Exception
            dao.fields.SINBON_ID = 0
        End Try
        Try
            dao.fields.BANK_ID = ddl_bank.SelectedValue
        Catch ex As Exception

        End Try
  
        'dao.fields.LCNSID = dd_CUSTOMER.SelectedValue
        'dao.fields.FEEABBR = ddl_abbr_type.SelectedValue
        'dao.fields.FEENO = txt_ORDER_PAY2.Text
        If Request.QueryString("law") = "" Then
            dao.fields.RECEIPT_TYPE = 2 'ดึงมา
        Else
            dao.fields.RECEIPT_TYPE = 4 'ดึงมา
        End If


    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'Dim ws_dt As New WS_OLD_DT
        Dim r_type As Integer = 0
        Dim fee_acc As Integer = 0
        If Request.QueryString("law") <> "" Then
            r_type = 2

        Else
            r_type = 1
        End If
        Dim fee_format As String = feeno_format()
        Try
            Dim dao_fee_acc As New DAO_FEE.TB_fee
            dao_fee_acc.GetDataby_feeno(fee_format)
            fee_acc = dao_fee_acc.fields.acc_type
        Catch ex As Exception

        End Try
        If Request.QueryString("pre") = "" Then
            If r_type = fee_acc Then
                Save_Receipt()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ออกใบสั่งผิดประเภทบัญชี');", True)
            End If

        Else
            Save_Receipt()
        End If
        
        '

        'Else
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เพราะยังไม่ได้ออกใบสั่งชำระ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
        'End If

    End Sub
    Sub Save_Receipt()
        Dim fee_format As String = feeno_format()
        Try
            Dim dept As Integer = 0
            Dim fk_fee As Integer = 0
            Dim ref01 As String = ""
            Dim ref02 As String = ""
            Dim feeabbr As String = ""
            Dim process_id As String = ""
            Dim ida As Integer = 0
            Try
                dept = ddl_department.SelectedValue
            Catch ex As Exception

            End Try
            Dim count_row As Integer = 0

            Dim dao_fee As New DAO_FEE.TB_fee



            count_row = dao_fee.count_row_fee(fee_format, ddl_department.SelectedValue)
            Dim dao_fee3 As New DAO_FEE.TB_fee
            dao_fee3.Getdata_by_feeno_and_dvcd(fee_format, ddl_department.SelectedValue)
            Dim bao_d As New BAO_BUDGET.FDA_FEE
            Dim dt_d As New DataTable
            Dim is_old As Boolean = False
            Dim feeabbr_head As String = ""
            Try
                fk_fee = dao_fee3.fields.IDA
            Catch ex As Exception

            End Try
            Try
                feeabbr_head = dao_fee3.fields.feeabbr
            Catch ex As Exception

            End Try
            If dao_fee3.fields.IDA = 0 Then
                Try
                    '--------------------------------------------------------
                    'dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(fee_format, ddl_department.SelectedValue, txt_ORDER_PAY1.Text)
                    'dt_d = ws_dt.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(fee_format, ddl_department.SelectedValue, txt_ORDER_PAY1.Text)
                    If dt_d.Rows.Count > 0 Then
                        is_old = True
                    End If
                Catch ex As Exception

                End Try
            End If
            If dt_d.Rows.Count = 0 Then
                If Request.QueryString("law") = "" Then
                    'If dept = 2 Then
                    '    Dim bao2 As New BAO_NCT2.LGT_NCT2
                    '    dt_d = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(fee_format, ddl_department.SelectedValue)
                    'Else
                    dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(fee_format, ddl_department.SelectedValue)
                    'End If
                Else
                    dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2_L44(fee_format, ddl_department.SelectedValue)
                End If
            End If
            Dim bao_max As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Dim FULL_RECEIVE_NUMBER As String = ""
            Dim RECEIVE_NUMBER As String = ""
            Try
                If Request.QueryString("pre") = "" Then
                    If Request.QueryString("law") = "" Then
                        max_id = bao_max.get_max_receipt_normal(bgYear, 1)
                    Else
                        max_id = bao_max.get_max_receipt_normal_M44(bgYear, 1)
                    End If
                    'ย้าย-------------------
                    'max_id = max_id
                    'FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id + 1
                Else
                    FULL_RECEIVE_NUMBER = txt_FULL_RECEIVE_NUMBER.Text
                    Dim num As String() = Nothing
                    Try
                        num = txt_FULL_RECEIVE_NUMBER.Text.Split("/")
                        RECEIVE_NUMBER = num(1)
                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception

            End Try


            'If count_row > 0 Then
            Dim count_bg As Integer = 0
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'count_bg = dao.count_receipt4(ddl_department.SelectedValue, fee_format, txt_ORDER_PAY1.Text)
            count_bg = dao.count_receipt5(ddl_department.SelectedValue, fee_format, txt_ORDER_PAY1.Text)
            Dim dvcd_new As Integer = 0
            Try
                dvcd_new = ddl_department.SelectedValue
            Catch ex As Exception

            End Try
            If count_bg = 0 Then
                dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY

                insert(dao)
                dao.fields.FEENO = fee_format
                dao.fields.ORDER_PAY2 = fee_format
                If Request.QueryString("pre") = "" Then
                    'ย้าย-------------------
                    'dao.fields.RUNNING_RECEIPT = max_id + 1
                Else
                    dao.fields.RUNNING_RECEIPT = RECEIVE_NUMBER
                End If

                If Request.QueryString("law") <> "" Then
                    'ย้าย-------------------
                    'FULL_RECEIVE_NUMBER = "2-" & FULL_RECEIVE_NUMBER
                End If
                'ย้าย-------------------
                'dao.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER

                dao.fields.STAFF_IDEN = ""
                If Request.QueryString("pre") <> "" Then
                    dao.fields.IS_PREVIOUS = True
                End If

                Try
                    dao.fields.FULLNAME = txt_FullNAME.Text
                Catch ex As Exception

                End Try
                Try
                    Dim dao_lcn As New DAO_CPN.TB_syslcnsid
                    dao_lcn.Getdata_by_Disburse_lcnsid(dao_fee3.fields.lcnsid)
                    'Dim dao_lcnnm As New DAO_CPN.TB_syslcnsnm
                    'dao_lcnnm.Getdata_by_Disburse_identify(dao_lcn.fields.identify)

                    'Dim dt As New DataTable
                    'Dim bao_nm As New BAO_BUDGET.LGTCPN
                    'dt = bao_nm.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_fee3.fields.lcnsid, dao_lcn.fields.identify)
                    'lbl_customer.Text = dt(0)("thanm")
                    'dt(0)("thanm")
                    dao.fields.CUSTOMER_IDENTIFY = dao_lcn.fields.identify
                Catch ex As Exception
                    'txt_FullNAME.Text = "-"
                End Try

                Try
                    dao.fields.CHECK_NUMBER = txt_Checknumber.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CHECK_DATE = CDate(txt_checkdate.Text)
                Catch ex As Exception

                End Try

                If is_old = False Then
                    Try
                        dao.fields.LCNSID = dao_fee3.fields.lcnsid
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.FEEABBR = dao_fee3.fields.feeabbr
                        feeabbr = dao_fee3.fields.feeabbr
                    Catch ex As Exception

                    End Try
                    Try
                        ref01 = dao_fee3.fields.ref01
                        dao.fields.REF01 = dao_fee3.fields.ref01
                    Catch ex As Exception

                    End Try
                    Try
                        ref02 = dao_fee3.fields.ref02
                        dao.fields.REF02 = dao_fee3.fields.ref02
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.DVCD = ddl_department.SelectedValue
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.CUSTOMER_ID = dao_fee3.fields.lcnsid
                    Catch ex As Exception

                    End Try
                    If Request.QueryString("law") = "" Then
                        dao.fields.IS_L44 = 0
                    Else
                        dao.fields.IS_L44 = 1
                    End If
                    Try
                        dao.fields.PVNCD = dao_fee3.fields.pvncd
                    Catch ex As Exception

                    End Try
                    dao.insert()

                    ida = dao.fields.RECEIVE_MONEY_ID
                    'Dim dao_fd As New DAO_FEE.TB_feedtl
                    'dao_fd.Getdata_by_fee_id(fk_fee)
                    Dim dt_det As New DataTable
                    Dim bao_dett As New BAO_FEE.FEE
                    If dvcd_new <> 7 Then
                        Try
                            dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE_V2(fk_fee)
                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE_FINE(fk_fee)
                        Catch ex As Exception

                        End Try
                    End If

                    For Each dr As DataRow In dt_det.Rows
                        Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                        dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
                        Try
                            dao_det.fields.AMOUNT = dr("amt")
                        Catch ex As Exception
                            dao_det.fields.AMOUNT = 0
                        End Try
                        Try
                            dao_det.fields.FEEABBR = dr("feeabbr") 'ddl_abbr_type.SelectedValue
                        Catch ex As Exception

                        End Try
                        Try
                            If Request.QueryString("law") = "" Then
                                If dr("appvno").ToString.Contains("&nbsp;") Then
                                    If dr("lcnno_convert") <> "" Then
                                        dao_det.fields.LCNNO = dr("lcnno_convert")
                                    Else
                                        dao_det.fields.LCNNO = Nothing
                                    End If
                                Else
                                    dao_det.fields.LCNNO = dr("appvno")
                                End If
                                'dao_det.fields.LCNNO = dr("appvno")
                            Else
                                dao_det.fields.LCNNO = dr("lcnno_convert")
                                'dao_det.fields.LCNNO = dr("appvno")
                            End If


                        Catch ex As Exception

                        End Try
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
                            If dr("rcvno").ToString.Contains("&nbsp;") Then
                                dao_det.fields.rcvno = Nothing
                            Else
                                dao_det.fields.rcvno = dr("rcvno")
                            End If

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
                            dao_det.fields.DESCRIPTIONS = dr("fee_description")
                        Catch ex As Exception

                        End Try
                        dao_det.insert()
                    Next

                Else
                    Dim bao_det As New BAO_BUDGET.FDA_FEE
                    Dim old_pvncd As Integer = 0
                    Dim dvcd_old As Integer = 0

                    Try
                        If dt_d(0)("pvncd") <> "10" Then
                            old_pvncd = 10
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        dvcd_old = dt_d(0)("dvcd")
                    Catch ex As Exception

                    End Try
                    '--------------------------------------------------------------------------
                    'dt_rg = bao_det.SP_GET_FEEDTL_OLD(feeno_format, dt_d(0)("dvcd"), old_pvncd, dt_d(0)("feeabbr"))

                    'dt_rg = ws_dt.SP_GET_FEEDTL_OLD(feeno_format, dt_d(0)("dvcd"), old_pvncd, dt_d(0)("feeabbr"))


                    Try
                        dao.fields.LCNSID = dt_d(0)("lcnsid")

                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.FEEABBR = dt_d(0)("feeabbr")
                        feeabbr = dt_d(0)("feeabbr")
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.REF01 = dt_d(0)("ref01")
                        ref01 = dt_d(0)("ref01")
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.REF02 = dt_d(0)("ref02")
                        ref02 = dt_d(0)("ref02")
                    Catch ex As Exception

                    End Try
                    dao.fields.DVCD = ddl_department.SelectedValue
                    Try
                        dao.fields.CUSTOMER_ID = dt_d(0)("lcnsid")
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.CHECK_NUMBER = txt_Checknumber.Text
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.CHECK_DATE = CDate(txt_checkdate.Text)
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.PVNCD = dt_d(0)("pvncd")
                    Catch ex As Exception

                    End Try
                    dao.insert()

                    ida = dao.fields.RECEIVE_MONEY_ID
                    For Each dr As DataRow In dt_rg.Rows
                        Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                        dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
                        Try
                            dao_det.fields.AMOUNT = dr("amt")
                        Catch ex As Exception
                            dao_det.fields.AMOUNT = 0
                        End Try
                        Try
                            dao_det.fields.FEEABBR = dr("feeabbr") 'ddl_abbr_type.SelectedValue
                        Catch ex As Exception

                        End Try
                        Try
                            dao_det.fields.LCNNO = dr("appvno")
                        Catch ex As Exception

                        End Try
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
                            dao_det.fields.DESCRIPTIONS = dr("feetpnm")
                        Catch ex As Exception

                        End Try
                        Try
                            If Request.QueryString("law") = "" Then
                                dao_det.fields.LCNNO = dr("appvno")
                            Else
                                dao_det.fields.LCNNO = dr("lcnno_convert")
                            End If


                        Catch ex As Exception

                        End Try

                        dao_det.insert()
                    Next


                End If

                Try
                    Dim dao_fee2 As New DAO_FEE.TB_fee
                    dao_fee2.GetDataby_ref1_ref2(ref01, ref02)
                    dao_fee2.fields.rcptst = 1
                    dao_fee2.update()
                Catch ex As Exception

                End Try

                '----------------------เช็คเลขใบเสร็จซ้ำ--------------
                Dim max_id_new As Integer = 0
                If Request.QueryString("pre") = "" Then
                    Dim dao_re_no As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    dao_re_no.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)
                    Dim bools As Boolean

                    max_id_new = Get_Max_NO()
                    'If max_id = max_id_new Then

                    'Else

                    max_id_new = max_id_new + 1
                    'max_id_new = Get_Max_NO()
                    'If max_id = max_id_new Then
                    '    max_id_new = max_id_new + 1
                    'Else
                    'max_id_new = Get_Max_NO()
                    'max_id_new = max_id_new + 1
                    'End If
                    FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id_new
                    dao_re_no.fields.RUNNING_RECEIPT = max_id_new
                    If Request.QueryString("law") <> "" Then
                        FULL_RECEIVE_NUMBER = "2-" & FULL_RECEIVE_NUMBER
                    End If


                    ' bools = Chk_Max_No(ddl_department.SelectedValue, feeno_format(), txt_ORDER_PAY1.Text, max_id_new, bgYear)
                    bools = CHK_MAX_NO_INSERT(FULL_RECEIVE_NUMBER)
                    If bools = True Then

                        dao_re_no.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER
                        dao_re_no.update()

                        '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
                        'ดึง process id
                        Dim dao_type As New DAO_FEE.TB_feetype

                        Try
                            dao_type.Getdata_by_feeabbr(feeabbr)
                            process_id = dao_type.fields.process_id
                        Catch ex As Exception

                        End Try
                        'If Request.QueryString("law") = "" Then
                        Dim Steps As String = ""
                        Try
                            Steps = "1"
                            Dim dao_fee88 As New DAO_FEE.TB_fee
                            dao_fee88.GetDataby_ref1_ref2(ref01, ref02)
                            Steps = "2"
                            Dim dao_fee_det As New DAO_FEE.TB_feedtl
                            dao_fee_det.Getdata_by_fee_id(dao_fee88.fields.IDA)

                            If dao_fee88.fields.feeabbr = "9005" Or dao_fee88.fields.feeabbr = "9006" Then
                                Dim iii As Integer = 0
                                For Each dao_fee_det.fields In dao_fee_det.datas
                                    iii += 1
                                    Steps = "3"
                                    Dim ws As New WS_UPDATE_PAYMENT.SV_UPDATE_PAYMENT
                                    ws.UPDATE_STATUS_PAYMENT(dao_fee_det.fields.fk_id, 1)
                                Next

                            Else
                                Steps = "5"
                                Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
                                'ws_updates.Timeout = 120000
                                ws_updates.Update_Status_Pay(ref01, ref02)
                            End If

                            Dim dao_log_con As New DAO_MAS.TB_LOG_CONFIRM
                            dao_log_con.fields.REF01 = ref01
                            dao_log_con.fields.REF02 = ref02
                            dao_log_con.fields.CREATEDATE = Date.Now
                            Try
                                dao_log_con.fields.STATUS_ID = Steps
                            Catch ex As Exception

                            End Try
                            dao_log_con.insert()
                        Catch ex As Exception
                            Insert_log_error(ref01, ref02, "ส่วน update : " & ex.Message & " " & Steps, 0)
                            Insert_H2H_Error(ref01, ref02, "", ex.Message & " " & Steps, "", 0)
                        End Try

                        'Else
                        Dim feeabbr_u As String = ""
                        Dim acc_type As Integer = 0

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
                        '------------------------------------------

                        Dim uri As String = ""
                        uri = Request.Url.AbsoluteUri & "&ida=" & dao.fields.RECEIVE_MONEY_ID


                        Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                        dao22.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)

                        Dim querystr As String = ""
                        Dim is_l44 As String = ""
                        Try
                            is_l44 = dao22.fields.IS_L44
                        Catch ex As Exception
                            is_l44 = ""
                        End Try
                        Dim feeno_re As String = ""
                        feeno_re = dao22.fields.FEENO
                        Dim dvcd_re As String = ""
                        dvcd_re = CStr(dao22.fields.DVCD)
                        Dim feebbr_re As String = ""
                        feebbr_re = dao22.fields.FEEABBR
                        Dim bgYear_re As String = ""
                        bgYear_re = CStr(dao22.fields.BUDGET_YEAR)
                        querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re

                        Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & dao.fields.RECEIVE_MONEY_ID & "&dvcd=" & dao22.fields.DVCD & "&feeno=" & dao22.fields.FEENO & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR
                        Dim url2 As String = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'dao22.fields.FEENO & "&dvcd=" & dao22.fields.DVCD & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR

                        If Request.QueryString("pre") = "" Then
                            If Request.QueryString("law") = "" Then
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

                            Else
                                url &= "&law=1"
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

                            End If
                        Else
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
                        End If

                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เลขใบเสร็จซ้ำกรุณากดปุ่มบันทึกอีกครั้ง');", True)
                    End If

                End If
            Else
                Dim dao_chk As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_chk.Getdata_by_dvcd_feeno_feeabbr(ddl_department.SelectedValue, feeno_format(), txt_ORDER_PAY1.Text)
                If dao_chk.fields.RUNNING_RECEIPT Is Nothing And dao_chk.fields.E_RUNNING_RECEIPT Is Nothing Then
                    '----------------------เช็คเลขใบเสร็จซ้ำ--------------
                    Dim max_id_new As Integer = 0
                    If Request.QueryString("pre") = "" Then

                        Dim dao_re_no As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                        dao_re_no.Getdata_by_RECEIVE_MONEY_ID(dao_chk.fields.RECEIVE_MONEY_ID)
                        Dim bools As Boolean

                        max_id_new = Get_Max_NO()
                        'max_id_new = max_id_new + 1
                        'Else
                        'bools = Chk_Max_No(ddl_department.SelectedValue, feeno_format(), txt_ORDER_PAY1.Text, max_id_new, bgYear)
                        max_id_new = max_id_new + 1
                        FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id_new
                        dao_re_no.fields.RUNNING_RECEIPT = max_id_new
                        If Request.QueryString("law") <> "" Then
                            FULL_RECEIVE_NUMBER = "2-" & FULL_RECEIVE_NUMBER
                        End If
                        bools = CHK_MAX_NO_INSERT(FULL_RECEIVE_NUMBER)
                        If bools = True Then

                            dao_re_no.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER
                            dao_re_no.update()

                            Dim Steps As String = ""
                            Try
                                Steps = "1"
                                Dim dao_fee88 As New DAO_FEE.TB_fee
                                dao_fee88.GetDataby_ref1_ref2(ref01, ref02)
                                Steps = "2"
                                Dim dao_fee_det As New DAO_FEE.TB_feedtl
                                dao_fee_det.Getdata_by_fee_id(dao_fee88.fields.IDA)

                                If dao_fee88.fields.feeabbr = "9005" Or dao_fee88.fields.feeabbr = "9006" Then
                                    Dim iii As Integer = 0
                                    For Each dao_fee_det.fields In dao_fee_det.datas
                                        iii += 1
                                        Steps = "3"
                                        Dim ws As New WS_UPDATE_PAYMENT.SV_UPDATE_PAYMENT
                                        ws.UPDATE_STATUS_PAYMENT(dao_fee_det.fields.fk_id, 1)
                                    Next

                                Else
                                    Steps = "5"
                                    Dim ws_updates As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
                                    'ws_updates.Timeout = 120000
                                    ws_updates.Update_Status_Pay(ref01, ref02)
                                End If

                                Dim dao_log_con As New DAO_MAS.TB_LOG_CONFIRM
                                dao_log_con.fields.REF01 = ref01
                                dao_log_con.fields.REF02 = ref02
                                dao_log_con.fields.CREATEDATE = Date.Now
                                Try
                                    dao_log_con.fields.STATUS_ID = 999
                                Catch ex As Exception

                                End Try
                                dao_log_con.insert()
                            Catch ex As Exception
                                Insert_log_error(ref01, ref02, "ส่วน update : " & ex.Message & " " & Steps, 0)
                                Insert_H2H_Error(ref01, ref02, "", ex.Message & " " & Steps, "", 0)
                            End Try


                            Dim querystr As String = ""
                            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                            dao22.Getdata_by_RECEIVE_MONEY_ID(dao_chk.fields.RECEIVE_MONEY_ID)
                            Dim feeno_re As String = ""
                            feeno_re = dao22.fields.FEENO
                            Dim dvcd_re As String = ""
                            dvcd_re = CStr(dao22.fields.DVCD)
                            Dim feebbr_re As String = ""
                            feebbr_re = dao22.fields.FEEABBR
                            Dim bgYear_re As String = ""
                            bgYear_re = CStr(dao22.fields.BUDGET_YEAR)
                            querystr = feeno_re & "|" & dvcd_re & "|" & feebbr_re & "|" & bgYear_re

                            Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & dao_chk.fields.RECEIVE_MONEY_ID & "&dvcd=" & dao22.fields.DVCD & "&feeno=" & dao22.fields.FEENO & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR
                            If Request.QueryString("pre") = "" Then
                                If Request.QueryString("law") = "" Then
                                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                                Else
                                    url &= "&law=1"
                                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

                                End If
                            Else
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                            End If



                        Else
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เลขใบเสร็จซ้ำกรุณากดปุ่มบันทึกอีกครั้ง');", True)
                        End If

                    End If
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกรายการซ้ำ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)

                End If


            End If
        Catch ex As Exception
            'feeno_format
            Try
                Dim dao_fee As New DAO_FEE.TB_fee
                dao_fee.GetDataby_feeno(feeno_format)
                Insert_log_error(dao_fee.fields.ref01, dao_fee.fields.ref02, "ส่วน update : " & ex.Message & " popup", 0)
            Catch ex2 As Exception

            End Try


            'Insert_H2H_Error(ref01, ref02, "", ex.Message & " " & Steps, "", 0)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาด กรุณากดปุ่มบันทึกอีกครั้ง');", True)

        End Try
    End Sub

    Public Function Get_Max_NO() As Integer
        ' Dim max_no As Integer = 0
        Dim bao_max As New BAO_BUDGET.Maintain
        Dim max_id As Integer = 0
        For i As Integer = 0 To 4
            If Request.QueryString("law") = "" Then
                max_id = bao_max.get_max_receipt_normal(bgYear, 1)
            Else
                max_id = bao_max.get_max_receipt_normal_M44(bgYear, 1)
            End If
        Next

        Return max_id
    End Function
    Function Chk_Max_No(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String, ByVal running_num As Integer, ByVal BUDGET_YEAR As Integer) As Boolean
        Dim bool As Boolean = True
        Dim max_no As Integer = 0
        'Dim dao_chk As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'dao_chk.Getdata_by_dvcd_feeno_feeabbr(dvcd, feeno, feeabbr)
        If Request.QueryString("law") = "" Then
            'Dim dao_max As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'dao_max.Get_NUMBER_MAX(BUDGET_YEAR)
            Dim bao As New BAO_BUDGET.Maintain
            Try
                max_no = bao.get_max_receipt_all_by_type(BUDGET_YEAR, 1)
            Catch ex As Exception

            End Try

            If max_no = running_num Then
                bool = True
            Else
                bool = False
            End If
        Else
            Dim bao As New BAO_BUDGET.Maintain
            Try
                max_no = bao.get_max_receipt_all_by_type(BUDGET_YEAR, 2)
            Catch ex As Exception

            End Try

            If max_no = running_num Then
                bool = True
            Else
                bool = False
            End If
        End If
        Return bool
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

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        rg_receive.Rebind()
    End Sub

    Private Sub rg_receive_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_receive.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Try
                    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("ida"))
                    dao.delete()

                    Dim dao_d As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                    dao_d.Getdata_by_RECEIVE_MONEY_DETAIL_ID(item("IDA").Text)
                    dao_d.delete()
                Catch ex As Exception

                End Try

                rg_receive.Rebind()
            End If
        End If
    End Sub

    Private Sub rg_receive_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_receive.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        'If Request.QueryString("ida") <> "" Then
        '    dt = bao.SP_RECEIVE_MONEY_DETAIL2_BY_FK_IDA(Request.QueryString("ida"))
        'End If

        'Try
        '    Dim feeno As String = feeno_format()
        '    Dim count_bg As Integer = 0
        '    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        '    count_bg = dao.count_receipt4(ddl_department.SelectedValue, feeno, txt_ORDER_PAY1.Text)
        '    If count_bg = 0 Then
        '        rg_receive.DataSource = dt_rg
        '    End If

        'Catch ex As Exception
        rg_receive.DataSource = dt_rg
        'End Try

    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        'btn_save.Style.Add("display", "block")
        ''btn_print.Style.Add("display", "none")
        'btn_reset.Style.Add("display", "none")
        'Panel1.Style.Add("display", "none")
        txt_Checknumber.Text = ""
        txt_customer.Text = ""
        txt_description.Text = ""
        txt_FULL_RECEIVE_NUMBER.Text = ""
        txt_ORDER_PAY1.Text = ""
        txt_ORDER_PAY2.Text = ""
        Try
            dt_rg = Nothing
        Catch ex As Exception

        End Try

        rg_receive.Rebind()
    End Sub

    'Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
    '    'Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?id_rec=" & Request.QueryString("ida"))
    '    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '    dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("ida"))
    '    Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & Request.QueryString("ida") & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)

    'End Sub

    Private Sub ddl_Income_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Income.SelectedIndexChanged
        bind_ddl_money_type()
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


        mm.SendMail_ASY(mcontent)

    End Sub
    'Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String)
    '    Dim dt As New DataTable
    '    Dim bao As New BAO_FEE.FEE
    '    Dim receipt_num As String = ""
    '    ' Dim fee_format As String = feeno_format(feeno)
    '    Dim fk_fee As Integer = 0
    '    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum3(feeno, dvcd, feeabbr)

    '    Dim str_fullname As String = ""


    '    Try
    '        Dim dao_fee_nm As New DAO_FEE.TB_fee
    '        dao_fee_nm.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(feeno, dvcd, feeabbr, dt(0)("pvncd"))
    '        Try
    '            str_fullname = dao_fee_nm.fields.company_name
    '        Catch ex As Exception

    '        End Try
    '    Catch ex As Exception

    '    End Try

    '    'If str_fullname = "" Then
    '    '    Try
    '    '        Dim bao_name As New BAO_FEE.FEE
    '    '        If dt(0)("prnfeest") = "1" Then
    '    '            str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
    '    '        Else
    '    '            str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
    '    '        End If
    '    '    Catch ex As Exception

    '    '    End Try
    '    'End If

    '    Dim count_bg As Integer = 0
    '    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '    If Request.QueryString("law") <> "" Then
    '        count_bg = dao.count_receipt_M44_E(dvcd, feeno, feeabbr)
    '    Else
    '        count_bg = dao.count_receipt4(dvcd, feeno, feeabbr)
    '    End If

    '    If count_bg = 0 Then
    '        Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '        'If Request.QueryString("law") <> "" Then
    '        '    dao_i.fields.RECEIVE_MONEY_TYPE = 1
    '        'Else
    '        dao_i.fields.RECEIVE_MONEY_TYPE = 1
    '        'End If

    '        dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
    '        dao_i.fields.FULLNAME = str_fullname
    '        dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
    '        dao_i.fields.RECEIVER_MONEY_ID = 0
    '        dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
    '        dao_i.fields.DEPARTMENT_ID = 0
    '        dao_i.fields.ORDER_PAY1 = feeabbr
    '        dao_i.fields.ORDER_PAY2 = feeno
    '        dao_i.fields.MONEY_RECEIVE_DATE = Date.Now
    '        dao_i.fields.FEEABBR = feeabbr
    '        dao_i.fields.FEENO = feeno
    '        dao_i.fields.LCNSID = dt(0)("lcnsid")
    '        dao_i.fields.BUDGET_YEAR = Get_BUDGET_YEAR()

    '        dao_i.fields.REF01 = dt(0)("ref01")
    '        dao_i.fields.REF02 = dt(0)("ref02")
    '        dao_i.fields.MONEY_TYPE_ID = 1
    '        dao_i.fields.DVCD = dvcd
    '        If Request.QueryString("law") <> "" Then
    '            dao_i.fields.IS_L44 = 1
    '            dao_i.fields.RECEIPT_TYPE = 5
    '        Else
    '            dao_i.fields.RECEIPT_TYPE = 1
    '        End If

    '        Dim bao2 As New BAO_BUDGET.Maintain
    '        Dim max_id As Integer = 0
    '        Dim str_num As String = ""
    '        Try
    '            If Request.QueryString("law") = "" Then
    '                max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 2)
    '            Else
    '                max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 4)
    '            End If
    '            max_id += 1
    '            str_num = String.Format("{0:0000000000}", max_id.ToString("0000000000"))
    '        Catch ex As Exception

    '        End Try
    '        dao_i.fields.E_RUNNING_RECEIPT = max_id
    '        If Request.QueryString("law") = "" Then
    '            dao_i.fields.FULL_RECEIVE_NUMBER = "E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
    '        Else
    '            dao_i.fields.FULL_RECEIVE_NUMBER = "E-2-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
    '        End If


    '        dao_i.insert()


    '        Dim re_id As Integer = 0
    '        Try
    '            re_id = dao_i.fields.RECEIVE_MONEY_ID
    '        Catch ex As Exception

    '        End Try

    '        Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '        dao22.Getdata_by_RECEIVE_MONEY_ID(re_id)
    '        '_url_qr = "http://164.115.28.103/fda_budget_test/Module03/Frm_Maintain_Receive_Money_L44.aspx?id_feeno=" & re_id
    '        Dim url2 As String = "http://164.115.28.103/fda_budget_test/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & dao22.fields.FEENO & "&dvcd=" & dao22.fields.DVCD & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR


    '        'RadBarcode1.DataBind()
    '        'Dim image As System.Drawing.Image = RadBarcode1.GetImage()
    '        'Dim data As Byte()
    '        'data = ImageToByteArray(image)


    '        Dim Cls_qr As New QR_CODE.GEN_QR_CODE
    '        Dim img_byte As String = Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

    '        Dim dao_i2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '        dao_i2.Getdata_by_RECEIVE_MONEY_ID(re_id)
    '        dao_i2.fields.QR_IMAGE_BYTE = img_byte
    '        dao_i2.update()

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
    '            'Try
    '            '    dao_det.fields.LCNNO = dr("appvno")
    '            'Catch ex As Exception

    '            'End Try
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
    '            Try
    '                dao_det.fields.LCNNO = dr("lcnno_convert")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                dao_det.fields.DESCRIPTIONS = dr("feetpnm")
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
    Protected Sub applySettings(barcode As RadBarcode)
        barcode.Text = _url_qr
        barcode.QRCodeSettings.ECI = DirectCast([Enum].Parse(GetType(Modes.ECIMode), "NONE", True), Modes.ECIMode)
        barcode.QRCodeSettings.ErrorCorrectionLevel = DirectCast([Enum].Parse(GetType(Modes.ErrorCorrectionLevel), "L", True), Modes.ErrorCorrectionLevel)
        barcode.QRCodeSettings.Mode = DirectCast([Enum].Parse(GetType(Modes.CodeMode), "Byte", True), Modes.CodeMode)
        barcode.QRCodeSettings.Version = Integer.Parse(1)
        barcode.OutputType = DirectCast([Enum].Parse(GetType(BarcodeOutputType), BarcodeOutputType.EmbeddedPNG.ToString(), True), BarcodeOutputType)
        barcode.QRCodeSettings.DotSize = 8


        'barcode.QRCodeSettings.DotSize = -1 'Integer.Parse(1)
        'End If
    End Sub
    Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
        Using ms = New MemoryStream()
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function
    'Protected Sub RadBarcode1_PreRender(sender As Object, e As EventArgs)

    '    'RadBarcode1.Text = txt_url.Text
    '    applySettings(RadBarcode1)
    '    Dim image As System.Drawing.Image = RadBarcode1.GetImage()

    '    'image.Save("555", System.Drawing.Imaging.ImageFormat.Png)
    '    Dim data As Byte()
    '    'Using m As New MemoryStream()
    '    '    data = New Byte(m.Length - 1) {}
    '    '    m.Write(data, 0, data.Length)
    '    'End Using
    '    data = ImageToByteArray(image)
    '    'Dim str As String = 
    '    'RadBinaryImage1.DataValue = data

    '    Dim base64 As String = Convert.ToBase64String(data)
    '    'Dim data2 As Byte()
    '    Dim imgBin() As Byte = Convert.FromBase64String(base64)


    'End Sub
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
End Class