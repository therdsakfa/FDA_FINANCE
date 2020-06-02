Imports Telerik.Web.UI
Imports Telerik.Web.UI.Barcode
Imports System.IO

Public Class Frm_Maintain_Receive_Money_Auto
    Inherits System.Web.UI.Page

    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _process As String
    Private dt_rg As DataTable
    Dim date_str As Date
    Private _receiver_id As Integer = 0
    Dim _url_qr As String
    Sub runQuery()
        bgYear = Request.QueryString("myear")
        _receiver_id = Request.QueryString("r")
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
            'date_str = Date.Now 'CDate(Request.QueryString("date"))
            bind_income()
            'bind_customer()
            'bind_ddl_receipt_type()
            bind_ddl_money_type()
            bind_dept()
            'set_amount()
            'txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()
            Try
                txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()
            Catch ex As Exception

            End Try

            bind_bank()

            bind_search()
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
    Sub bind_search()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        Dim query_str As String = Request.QueryString("fee")
        Dim arr As String() = query_str.Split("|")
        Dim feeno As String = arr(0)
        Dim feeabbr As String = arr(1)
        Dim dept As Integer = 0
        Dim str_fullname As String = ""
        Dim count_bg As Integer = 0


        txt_ORDER_PAY1.Text = feeabbr
        Try
            txt_ORDER_PAY2.Text = CStr(Convert.ToDouble(Right(feeno, 5))) & "/" & Left(feeno, 2)
        Catch ex As Exception

        End Try

        Dim bao_dvcd As New BAO_BUDGET.FDA_FEE
        Dim str_dvcd_old As String = ""
        Try
            str_dvcd_old = bao_dvcd.get_dvcd_auto(feeno, feeabbr)
        Catch ex As Exception

        End Try
        Try
            Dim dao_fee2 As New DAO_FEE.TB_fee
            dao_fee2.Getdata_by_feeno_and_feeabbr(feeno, feeabbr)
            str_dvcd_old = dao_fee2.fields.dvcd
        Catch ex As Exception

        End Try

        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        count_bg = dao.count_receipt4(str_dvcd_old, feeno, feeabbr)

        If count_bg = 0 Then

            Try
                If str_dvcd_old <> "" Then
                    ddl_department.SelectedValue = str_dvcd_old
                End If

            Catch ex As Exception

            End Try

            Try
                dept = ddl_department.SelectedValue
            Catch ex As Exception

            End Try


            Dim ref1 As String = ""
            Dim ref2 As String = ""
            Dim old_pvncd As Integer = 0
            If Request.QueryString("law") = "" Then
                Try
                    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, ddl_department.SelectedValue, feeabbr)
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
                dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
            End If



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
                dao_fee_nm.Getdata_by_feeno_dvcd_feeabbr_and_pvncd(feeno, ddl_department.SelectedValue, feeabbr, dt(0)("pvncd"))
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
                        str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    Else
                        str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    End If
                Catch ex As Exception

                End Try
            End If

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
                    txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty)
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
                    Dim bao_det As New BAO_BUDGET.FDA_FEE
                    dt_rg = bao_det.SP_GET_FEEDTL_OLD(feeno, dt(0)("dvcd"), pvncd, dt(0)("feeabbr"))
                Catch ex As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                End Try


            Else
                If Request.QueryString("law") = "" Then
                    If dept = 2 Then
                        Dim bao2 As New BAO_NCT2.LGT_NCT2
                        dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
                    Else
                        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
                    End If
                Else
                    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
                End If

                If dt.Rows.Count > 0 Then
                    txt_FullNAME.Text = str_fullname 'dt(0)("fullname")
                    txt_customer.Text = dt(0)("lcnsid")
                    ddl_department.DataBind()
                    ddl_department.DropDownSelectData(dt(0)("dvcd"))
                    txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty) '

                    Dim bao_det As New BAO_BUDGET.FDA_FEE
                    dt_rg = bao_det.SP_GET_FEEDTL_V2(feeno, dt(0)("dvcd"), dt(0)("pvncd"), dt(0)("feeabbr"))
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                End If
            End If


            rg_receive.Rebind()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('รายการนี้ออกใบเสร็จไปแล้ว');", True)
        End If
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
        count_bg = dao.count_receipt4(ddl_department.SelectedValue, feeno, txt_ORDER_PAY1.Text)
        Dim bao_dvcd As New BAO_BUDGET.FDA_FEE
        Dim str_dvcd_old As String = ""
        Try
            str_dvcd_old = bao_dvcd.get_dvcd_auto(feeno, txt_ORDER_PAY1.Text)
        Catch ex As Exception

        End Try
        Try
            Dim dao_fee2 As New DAO_FEE.TB_fee
            dao_fee2.Getdata_by_feeno_and_feeabbr(feeno, txt_ORDER_PAY1.Text)
            str_dvcd_old = dao_fee2.fields.dvcd
        Catch ex As Exception

        End Try


        If count_bg = 0 Then

            Try
                If str_dvcd_old <> "" Then
                    ddl_department.SelectedValue = str_dvcd_old
                End If

            Catch ex As Exception

            End Try

            Try
                dept = ddl_department.SelectedValue
            Catch ex As Exception

            End Try


            Dim ref1 As String = ""
            Dim ref2 As String = ""
            Dim old_pvncd As Integer = 0
            If Request.QueryString("law") = "" Then
                Try
                    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(feeno, ddl_department.SelectedValue, txt_ORDER_PAY1.Text)
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
                dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
            End If



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
                        str_fullname = bao_name.get_lcn_name_type1(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    Else
                        str_fullname = bao_name.get_lcn_name_type2(dt(0)("lcnsid"), dt(0)("lcnscd"))
                    End If
                Catch ex As Exception

                End Try
            End If

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
                    txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty)
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
                    Dim bao_det As New BAO_BUDGET.FDA_FEE
                    dt_rg = bao_det.SP_GET_FEEDTL_OLD(feeno, dt(0)("dvcd"), pvncd, dt(0)("feeabbr"))
                Catch ex As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                End Try


            Else
                If Request.QueryString("law") = "" Then
                    If dept = 2 Then
                        Dim bao2 As New BAO_NCT2.LGT_NCT2
                        dt = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum(feeno, ddl_department.SelectedValue)
                    Else
                        dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
                    End If
                Else
                    dt = bao.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(feeno, ddl_department.SelectedValue)
                End If

                If dt.Rows.Count > 0 Then
                    txt_FullNAME.Text = str_fullname 'dt(0)("fullname")
                    txt_customer.Text = dt(0)("lcnsid")
                    ddl_department.DataBind()
                    ddl_department.DropDownSelectData(dt(0)("dvcd"))
                    txt_description.Text = Regex.Replace(dt(0)("feetpnm"), "<.*?>", String.Empty) '

                    Dim bao_det As New BAO_BUDGET.FDA_FEE
                    dt_rg = bao_det.SP_GET_FEEDTL_V2(feeno, dt(0)("dvcd"), dt(0)("pvncd"), dt(0)("feeabbr"))
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                End If
            End If


            rg_receive.Rebind()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('รายการนี้ออกใบเสร็จไปแล้ว');", True)
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
        Dim dept As Integer = 0
        Dim fk_fee As Integer = 0
        Dim ref01 As String = ""
        Dim ref02 As String = ""
        Dim feeabbr As String = ""
        Dim process_id As Integer = 0
        Try
            dept = ddl_department.SelectedValue
        Catch ex As Exception

        End Try
        Dim count_row As Integer = 0

        Dim dao_fee As New DAO_FEE.TB_fee

        Dim fee_format As String = feeno_format()

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
        Try
            dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum_old2(fee_format, ddl_department.SelectedValue, txt_ORDER_PAY1.Text)
            If dt_d.Rows.Count > 0 Then
                is_old = True
            End If
        Catch ex As Exception

        End Try
        If dt_d.Rows.Count = 0 Then
            If Request.QueryString("law") = "" Then
                If dept = 2 Then
                    Dim bao2 As New BAO_NCT2.LGT_NCT2
                    dt_d = bao2.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(fee_format, ddl_department.SelectedValue)
                Else
                    dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(fee_format, ddl_department.SelectedValue)
                End If
            Else
                dt_d = bao_d.SP_get_receipt_by_feeabbr_and_feeno_group_sum2(fee_format, ddl_department.SelectedValue)
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

                FULL_RECEIVE_NUMBER = Right(bgYear, 2) & "/" & max_id + 1
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
        count_bg = dao.count_receipt4(ddl_department.SelectedValue, fee_format, txt_ORDER_PAY1.Text)
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
                dao.fields.RUNNING_RECEIPT = max_id + 1
            Else
                dao.fields.RUNNING_RECEIPT = RECEIVE_NUMBER
            End If

            dao.fields.FULL_RECEIVE_NUMBER = FULL_RECEIVE_NUMBER
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

                Dim dt As New DataTable
                Dim bao_nm As New BAO_BUDGET.LGTCPN
                dt = bao_nm.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_fee3.fields.lcnsid, dao_lcn.fields.identify)
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
                dao.insert()
                Dim dao_fd As New DAO_FEE.TB_feedtl
                dao_fd.Getdata_by_fee_id(fk_fee)
                Dim dt_det As New DataTable
                Dim bao_dett As New BAO_FEE.FEE
                Try
                    dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE(fk_fee)
                Catch ex As Exception

                End Try
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
                                dao_det.fields.LCNNO = Nothing
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
                'For Each dao_fd.fields In dao_fd.datas
                '    Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                '    dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
                '    Try
                '        dao_det.fields.AMOUNT = dao_fd.fields.amt
                '    Catch ex As Exception
                '        dao_det.fields.AMOUNT = 0
                '    End Try
                '    Try
                '        dao_det.fields.FEEABBR = dao_fee3.fields.feeabbr 'ddl_abbr_type.SelectedValue
                '    Catch ex As Exception

                '    End Try

                '    dao_det.fields.TABEAN_NUMBER = ""
                '    Try
                '        dao_det.fields.LCNNO = dao_fd.fields.appvno
                '    Catch ex As Exception

                '    End Try

                '    dao_det.insert()
                'Next

                'For Each dao_fd.fields In dao_fd.datas
                '    Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                '    dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
                '    Try
                '        dao_det.fields.AMOUNT = dao_fd.fields.amt
                '    Catch ex As Exception
                '        dao_det.fields.AMOUNT = 0
                '    End Try
                '    Try
                '        dao_det.fields.FEEABBR = dao_fee3.fields.feeabbr 'ddl_abbr_type.SelectedValue
                '    Catch ex As Exception

                '    End Try

                '    dao_det.fields.TABEAN_NUMBER = ""
                '    Try
                '        dao_det.fields.LCNNO = dao_fd.fields.appvno
                '    Catch ex As Exception

                '    End Try

                '    dao_det.insert()
                'Next


                Dim dao_fee2 As New DAO_FEE.TB_fee
                dao_fee2.Getdata_by_feeno_and_dvcd(fee_format, dvcd_new)
                dao_fee2.fields.rcptst = 1
                dao_fee2.update()
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
                dt_rg = bao_det.SP_GET_FEEDTL_OLD(feeno_format, dt_d(0)("dvcd"), old_pvncd, dt_d(0)("feeabbr"))

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
                dao.insert()
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
                        dao_det.fields.DESCRIPTIONS = dr("fee_description")
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

                Try
                    Dim dao_fee2 As New DAO_FEE.TB_fee
                    dao_fee2.Getdata_by_feeno_and_dvcd(fee_format, dvcd_old)
                    dao_fee2.fields.rcptst = 1
                    dao_fee2.update()
                Catch ex As Exception

                End Try
            End If



            '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
            'ดึง process id
            Dim dao_type As New DAO_FEE.TB_feetype

            Try
                dao_type.Getdata_by_feeabbr(feeabbr)
                process_id = dao_type.fields.process_id
            Catch ex As Exception

            End Try
            If Request.QueryString("law") = "" Then
                Try
                    If ddl_department.SelectedValue = 1 Then
                        Dim bao As New BAO_FEE.FEE
                        bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, process_id, ddl_department.SelectedValue)
                    ElseIf ddl_department.SelectedValue = 2 Then
                        Dim bao As New BAO_NCT2.LGT_NCT2
                        bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ref01, ref02, process_id, ddl_department.SelectedValue)

                        Dim _IDA As Integer = 0
                        Dim bao22 As New BAO_NCT2.LGT_NCT2
                        Try
                            _IDA = bao22.SP_GET_IDA_NCT_FROM_FEE(ref01, ref02)
                        Catch ex As Exception

                        End Try

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
                            And process_id <> 29200003 And process_id <> 29200005 And process_id <> 29200004 Then
                            IDA_NEW = ws_insert.NCT_INSERT(_IDA)
                        Else
                            IDA_NEW = ws_insert.NCT_INSERT_YORSOR_4(_IDA)
                        End If

                        string_xml = ws_gen_xml.NCT_INSERT(IDA_NEW, filename)

                        email = "saree@systemsthai.com"
                        CC = "watchara@fusionsol.com"
                        title = "XML_" & filename
                        content = ""
                        SendMail_CC_ATTACH(content, email, title, CC, string_xml, filename)


                    ElseIf ddl_department.SelectedValue = 3 Then
                        'โฆษณาอาหาร
                        Dim bao_adv As New BAO_ADV.FDA_ADV
                        Dim dt_adv As New DataTable
                        dt_adv = bao_adv.SP_GET_FEE_BY_REF01_AND_REF02(ref01, ref02)
                        Try
                            For Each dr As DataRow In dt_adv.Rows
                                If dr("process_id") = 9910 Or dr("process_id") = 9911 Then
                                    Dim dao_ad As New DAO_ADV.TB_FDATransaction
                                    dao_ad.GETDATA_BY_IDA(dr("fk_id"))
                                    Dim bao_u_adv As New BAO_ADV.FDA_ADV
                                    If dao_ad.fields.AccountStatusId = 22 Then
                                        bao_u_adv.SP_ADV_Bill(dr("fk_id"), 25)
                                    ElseIf dao_ad.fields.AccountStatusId = 23 Then
                                        bao_u_adv.SP_ADV_Bill(dr("fk_id"), 26)
                                    End If
                                End If
                            Next

                        Catch ex As Exception

                        End Try
                    ElseIf ddl_department.SelectedValue = 4 Then

                    ElseIf ddl_department.SelectedValue = 5 Then
                        Dim bao_mdc As New BAO_MDC.FDA_MDC
                        Dim dt As New DataTable
                        dt = bao_mdc.SP_GET_FEE_BY_REF01_AND_REF02(ref01, ref02)
                        For Each dr As DataRow In dt.Rows
                            Dim ws_rcv As New WS_UPDATE_RCVNO.UPDATE_RCVNO
                            If dr("process_id") <> "555555" Then
                                'If dr("process_id") = "501000" Then
                                '    Try

                                '        Dim dao_mdc As New DAO_MDC.TB_irgt
                                '        dao_mdc.GETDATA_BY_IDA(dr("fk_id"))
                                '        Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                '        If dao_mdc.fields.STATUS = 3 Or dao_mdc.fields.STATUS = 8 Then
                                '            ws_update_date.SERVICE_CAL_DATE(dr("fk_id"), dao_mdc.fields.STATUS)
                                '        End If

                                '    Catch ex As Exception

                                '    End Try
                                'Else
                                Try
                                    'Dim dao_mdc As New DAO_MDC.TB_irgt
                                    'dao_mdc.GETDATA_BY_IDA(dr("fk_id"))
                                    'Dim bao_pay As New BAO_MDC.FDA_MDC
                                    'Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                    Try
                                        Dim dao_mdc As New DAO_MDC.TB_irgt
                                        dao_mdc.GETDATA_BY_IDA(dr("fk_id"))
                                        Dim bao_pay As New BAO_MDC.FDA_MDC
                                        Dim ws_update_date As New WS_UPDATE_DATE_MDC.SV_UPDATE_DATE
                                        'If dao_mdc.fields.STATUS = 1 Then
                                        'bao_pay.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC(dao_mdc.fields.IDA, dao_mdc.fields.STATUS)
                                        'ws_rcv.SERVICE_RCVNO(dr("fk_id"), 1)

                                        ws_update_date.WS_UPDATE_STATUS(dr("fk_id"), dao_mdc.fields.STATUS, dr("process_id"))
                                        'ElseIf dao_mdc.fields.STATUS = 10 Then
                                        ''ws_update_date.SERVICE_CAL_DATE(dr("fk_id"), 8)
                                        'End If
                                    Catch ex As Exception

                                    End Try


                                    'If dao_mdc.fields.STATUS = 3 Then
                                    '    'bao_pay.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC(dao_mdc.fields.IDA, dao_mdc.fields.STATUS)
                                    '    'ws_rcv.SERVICE_RCVNO(dr("fk_id"), 1)
                                    '    ws_update_date.SERVICE_CAL_DATE(dr("fk_id"), dao_mdc.fields.STATUS, )
                                    'ElseIf dao_mdc.fields.STATUS = 10 Then
                                    '    ws_update_date.SERVICE_CAL_DATE(dr("fk_id"), 8)
                                    'End If
                                Catch ex As Exception

                                End Try


                                'End If

                            Else
                                Try
                                    Dim dao_ossc As New DAO_MDC.TB_ONESTOP_REQUEST
                                    dao_ossc.GETDATA_BY_IDA(dr("fk_id"))
                                    Dim bao_pay As New BAO_MDC.FDA_MDC

                                    bao_pay.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_MDC_ONESTOP(dao_ossc.fields.IDA)
                                Catch ex As Exception

                                End Try
                            End If
                        Next

                    ElseIf ddl_department.SelectedValue = 6 Then

                        '
                        Dim bao_txc As New BAO_TXC.FDA_TXC
                        Dim dt As New DataTable
                        dt = bao_txc.SP_GET_FEE_BY_REF01_AND_REF02(ref01, ref02)
                        For Each dr As DataRow In dt.Rows
                            Dim bao_txc2 As New BAO_TXC.FDA_TXC
                            bao_txc2.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXC(dr("fk_id"), dr("process_id"))

                        Next

                        Try
                            Dim bao_txt As New BAO_FEE.FEE
                            bao_txt.SP_FEE_UPDATE_STATUS_PAY_COMPLETE_TXT_EXTEND_DATE(fee_format)
                        Catch ex As Exception

                        End Try
                    End If
                Catch ex As Exception

                End Try
            Else
                Try
                    Dim dao_fee5 As New DAO_FEE.TB_fee
                    dao_fee5.GetDataby_ref1_ref2(ref01, ref02)
                    Dim dao_fee_det As New DAO_FEE.TB_feedtl
                    dao_fee_det.Getdata_by_fee_id(dao_fee5.fields.IDA)
                    Dim bao_pay As New BAO_SPECIAL_PAYMENT.FDA_SPECIAL_PAYMENT
                    bao_pay.SP_UPDATE_STATUS_PAY_COMPLETE(dao_fee_det.fields.process_id, dao_fee_det.fields.fk_id, 1)
                Catch ex As Exception

                End Try

            End If


            'Try
            '    'update สถานะ
            '    Dim bao2 As New BAO_FEE.FEE
            '    bao2.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(dao_fee3.fields.ref01, dao_fee3.fields.ref02, dao_type.fields.process_id, dao_fee.fields.dvcd)
            'Catch ex As Exception

            'End Try
            '------------------------------------------

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri & "&ida=" & dao.fields.RECEIVE_MONEY_ID


            Dim dao22 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao22.Getdata_by_RECEIVE_MONEY_ID(dao.fields.RECEIVE_MONEY_ID)

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

            Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & dao.fields.RECEIVE_MONEY_ID & "&dvcd=" & dao22.fields.DVCD & "&feeno=" & dao22.fields.FEENO & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR
            Dim url2 As String = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'dao22.fields.FEENO & "&dvcd=" & dao22.fields.DVCD & "&feeabbr=" & dao22.fields.FEEABBR & "&myear=" & dao22.fields.BUDGET_YEAR
            If Request.QueryString("law") <> "" Then
                insert_e_bill(dvcd_re, feeno_re, feebbr_re)
            End If

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)

            If Request.QueryString("pre") = "" Then
                If Request.QueryString("law") = "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

                Else

                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank'); window.open('" & url2 & "', '_blank');", True)
                    Response.Redirect("FRM_M44_RECEIPT_BARCODE_SCAN.aspx?law=1")

                End If
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
            End If
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)


            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)


            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกรายการซ้ำ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
            '    dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY
            '    dao.Getdata_by_receipt3(fee_format, dao_abbr.fields.dvcd)
        End If

        'Else
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เพราะยังไม่ได้ออกใบสั่งชำระ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
        'End If

    End Sub

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


        mm.SendMail(mcontent)

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

    Sub insert_e_bill(ByVal dvcd As Integer, ByVal feeno As String, ByVal feeabbr As String)
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
        If Request.QueryString("law") <> "" Then
            count_bg = dao.count_receipt_M44_E(dvcd, feeno, feeabbr)
        Else
            count_bg = dao.count_receipt4(dvcd, feeno, feeabbr)
        End If
        If count_bg = 0 Then
            Dim dao_i As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i.fields.RECEIVE_MONEY_TYPE = 1
            dao_i.fields.RECEIVE_MONEY_DESCRIPTION = dt(0)("feetpnm")
            dao_i.fields.FULLNAME = str_fullname
            dao_i.fields.CUSTOMER_ID = dt(0)("lcnsid")
            dao_i.fields.RECEIVER_MONEY_ID = Request.QueryString("r")
            dao_i.fields.RECEIVE_AMOUNT = dt(0)("amt")
            dao_i.fields.DEPARTMENT_ID = 0
            dao_i.fields.ORDER_PAY1 = feeabbr
            dao_i.fields.ORDER_PAY2 = feeno
            dao_i.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
            dao_i.fields.FEEABBR = feeabbr
            dao_i.fields.FEENO = feeno
            dao_i.fields.LCNSID = dt(0)("lcnsid")
            dao_i.fields.BUDGET_YEAR = Get_BUDGET_YEAR()
            dao_i.fields.IS_APPROVE = True
            Try
                dao_i.fields.APPROVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
            Catch ex As Exception
                dao_i.fields.APPROVE_DATE = Date.Now
            End Try
            dao_i.fields.REF01 = dt(0)("ref01")
            dao_i.fields.REF02 = dt(0)("ref02")
            dao_i.fields.MONEY_TYPE_ID = 1
            dao_i.fields.DVCD = dvcd
            If Request.QueryString("law") <> "" Then
                dao_i.fields.IS_L44 = 1
                dao_i.fields.RECEIPT_TYPE = 5
            Else
                dao_i.fields.RECEIPT_TYPE = 1
            End If

            Dim bao2 As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Dim str_num As String = ""
            Try
                If Request.QueryString("law") = "" Then
                    max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 2)
                Else
                    max_id = bao2.get_max_receipt_normal(Get_BUDGET_YEAR(), 4)
                End If
                max_id += 1
                str_num = String.Format("{0:0000000000}", max_id.ToString("0000000000"))
            Catch ex As Exception

            End Try
            dao_i.fields.E_RUNNING_RECEIPT = max_id
            If Request.QueryString("law") = "" Then
                dao_i.fields.FULL_RECEIVE_NUMBER = "1-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
            Else
                dao_i.fields.FULL_RECEIVE_NUMBER = "2-E-" & Right(Get_BUDGET_YEAR(), 2) & "-" & str_num
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

            Dim url2 As String = ""
            If Request.QueryString("law") = "" Then
                url2 = "http://164.115.28.103/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'feeno=" & feeno_re & "&dvcd=" & dvcd_re & "&feeabbr=" & feebbr_re & "&myear=" & bgYear_re
            Else
                url2 = "http://164.115.28.103/fda_budget_test/Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64 'feeno=" & feeno_re & "&dvcd=" & dvcd_re & "&feeabbr=" & feebbr_re & "&myear=" & bgYear_re
            End If


            'RadBarcode1.DataBind()
            'Dim image As System.Drawing.Image = RadBarcode1.GetImage()
            'Dim data As Byte()
            'data = ImageToByteArray(image)


            Dim Cls_qr As New QR_CODE.GEN_QR_CODE
            Dim img_byte As String = Cls_qr.QR_CODE(url2) 'Cls_qr.GenerateQR_TO_BASE64(200, 200, url2)

            Dim dao_i2 As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_i2.Getdata_by_RECEIVE_MONEY_ID(re_id)
            dao_i2.fields.QR_IMAGE_BYTE = img_byte
            dao_i2.update()

            Dim dt_det As New DataTable
            Dim bao_dett As New BAO_FEE.FEE
            Dim dao_fee3 As New DAO_FEE.TB_fee
            dao_fee3.Getdata_by_feeno_and_dvcd(feeno, dvcd)
            Try
                fk_fee = dao_fee3.fields.IDA
            Catch ex As Exception

            End Try
            Try
                dt_det = bao_dett.SP_GET_FEEDTL_BY_FK_FEE(fk_fee)
            Catch ex As Exception

            End Try
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
End Class