Imports Telerik.Web.UI
Public Class Frm_Maintain_Receive_Money_V2_Insert
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        If Not IsPostBack Then
            bind_income()
            'bind_customer()
            'bind_ddl_receipt_type()
            bind_ddl_money_type()
            bind_dept()
            'set_amount()
            txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()

            Dim bao As New BAO_BUDGET.Maintain
            Dim max_id As Integer = 0
            Try
                max_id = bao.get_max_receipt_normal(bgYear, 1)
                txt_FULL_RECEIVE_NUMBER.Text = max_id + 1 & "/" & Right(bgYear, 2)
            Catch ex As Exception

            End Try


            If Request.QueryString("ida") <> "" Then
                btn_save.Style.Add("display", "none")
                btn_print.Style.Add("display", "block")
                btn_reset.Style.Add("display", "block")
                Panel1.Style.Add("display", "block")
            Else
                btn_save.Style.Add("display", "block")
                btn_print.Style.Add("display", "none")
                btn_reset.Style.Add("display", "none")
                Panel1.Style.Add("display", "none")
            End If
        End If
    End Sub
    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("IDA", "IDA", False)
        Rad_Utility.addColumnBound("FEEABBR", "รายการ", width:=350)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=100)
    End Sub

    Public Sub bind_ddl_money_type()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.get_money_type_list

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
            fee_format = arr_feeno(1) & arr_feeno(0)
        Catch ex As Exception

        End Try
        Return fee_format
    End Function
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao_rec.get_receiver()
        Dim a As Integer = dao_rec.fields.RECEIVER_MONEY_ID
        'dao.fields.RECEIVE_MONEY_TYPE = rbl_RECEIVE_MONEY_TYPE.SelectedItem.Value
        dao.fields.RECEIVE_MONEY_DESCRIPTION = txt_description.Text 'ddl_abbr_type.SelectedItem.Text 'txt_RECEIVE_MONEY_DESCRIPTION.Text
        dao.fields.FULLNAME = lbl_customer.Text 'dd_CUSTOMER.SelectedItem.Text
        dao.fields.CUSTOMER_ID = 0 'dd_CUSTOMER.SelectedValue
        dao.fields.RECEIVER_MONEY_ID = a
        dao.fields.RECEIVE_AMOUNT = 0 'txt_RECEIVE_AMOUNT.Text
        'dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
        dao.fields.BUDGET_YEAR = bgYear
        Try
            dao.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
        Catch ex As Exception

        End Try
        dao.fields.RECEIVE_MONEY_TYPE = rbl_RECEIVE_MONEY_TYPE.SelectedValue
        dao.fields.MONEY_TYPE_ID = ddl_money_type.SelectedValue


        dao.fields.ORDER_PAY1 = txt_ORDER_PAY1.Text
        'dao.fields.ORDER_PAY2 = txt_ORDER_PAY2.Text
        dao.fields.FULL_RECEIVE_NUMBER = txt_FULL_RECEIVE_NUMBER.Text
        dao.fields.INCOME_IDA = ddl_Income.SelectedValue
        dao.fields.IS_SINBON = cb_sinbon.Checked
        dao.fields.IS_CHECK_OUT_PROVINCE = cb_IS_CHECK_OUT_PROVINCE.Checked
        dao.fields.IS_SEND_TO_BANK = cb_IS_SEND_TO_BANK.Checked
        dao.fields.SINBON_AMOUNT = 0 'txt_SINBON_AMOUNT.Value
        'dao.fields.LCNSID = dd_CUSTOMER.SelectedValue
        'dao.fields.FEEABBR = ddl_abbr_type.SelectedValue
        'dao.fields.FEENO = txt_ORDER_PAY2.Text
        dao.fields.RECEIPT_TYPE = 2 'กรอกเอง

    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim count_row As Integer = 0
        'Dim dao_abbr As New DAO_FEE.TB_feetype
        'dao_abbr.Getdata_by_feeabbr(ddl_abbr_type.SelectedValue)
        Dim dao_fee As New DAO_FEE.TB_fee

        Dim fee_format As String = feeno_format()

        count_row = dao_fee.count_row_fee(fee_format, ddl_department.SelectedValue)
        Dim dao_fee3 As New DAO_FEE.TB_fee
        dao_fee3.Getdata_by_feeno_and_dvcd(fee_format, ddl_department.SelectedValue)
        Dim ida_fee As Integer = 0
        Dim feeabbr_head As String = ""
        Try
            ida_fee = dao_fee3.fields.IDA
        Catch ex As Exception

        End Try
        Try
            feeabbr_head = dao_fee3.fields.feeabbr
        Catch ex As Exception

        End Try
        If count_row > 0 Then
            Dim count_bg As Integer = 0
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            count_bg = dao.count_receipt3(ddl_department.SelectedValue, fee_format)
            If count_bg = 0 Then
                dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY
                Dim bao As New BAO_BUDGET.Maintain
                Dim max_id As Integer = 0
                Try
                    max_id = bao.get_max_receipt_normal(bgYear, 1)
                Catch ex As Exception

                End Try
                insert(dao)
                dao.fields.FEENO = fee_format
                dao.fields.ORDER_PAY2 = fee_format
                dao.fields.RUNNING_RECEIPT = max_id + 1
                dao.fields.LCNSID = dao_fee3.fields.lcnsid
                dao.fields.FEEABBR = dao_fee3.fields.feeabbr
                dao.fields.REF01 = dao_fee3.fields.ref01
                dao.fields.REF02 = dao_fee3.fields.ref02
                dao.fields.STAFF_IDEN = _CLS.CITIZEN_ID
                dao.fields.DVCD = ddl_department.SelectedValue
                dao.fields.CUSTOMER_ID = dao_fee3.fields.lcnsid
                Try
                    Dim dao_lcn As New DAO_CPN.TB_syslcnsid
                    dao_lcn.Getdata_by_Disburse_lcnsid(dao_fee3.fields.lcnsid)
                    'Dim dao_lcnnm As New DAO_CPN.TB_syslcnsnm
                    'dao_lcnnm.Getdata_by_Disburse_identify(dao_lcn.fields.identify)

                    Dim dt As New DataTable
                    Dim bao_nm As New BAO_BUDGET.LGTCPN
                    dt = bao_nm.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_fee3.fields.lcnsid, dao_lcn.fields.identify)
                    lbl_customer.Text = dt(0)("thanm")
                    dao.fields.FULLNAME = dt(0)("thanm")
                    dao.fields.CUSTOMER_IDENTIFY = dao_lcn.fields.identify
                Catch ex As Exception
                    lbl_customer.Text = "-"
                End Try

                dao.insert()

                Dim dao_fd As New DAO_FEE.TB_feedtl
                dao_fd.Getdata_by_fee_id(ida_fee)

                For Each dao_fd.fields In dao_fd.datas
                    Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
                    dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
                    Try
                        dao_det.fields.AMOUNT = dao_fd.fields.amt
                    Catch ex As Exception
                        dao_det.fields.AMOUNT = 0
                    End Try
                    dao_det.fields.FEEABBR = feeabbr_head 'ddl_abbr_type.SelectedValue
                    dao_det.fields.TABEAN_NUMBER = ""
                    dao_det.insert()
                Next


                Dim dao_fee2 As New DAO_FEE.TB_fee
                dao_fee2.Getdata_by_feeno_and_dvcd(fee_format, ddl_department.SelectedValue)
                dao_fee2.fields.rcptst = 1
                dao_fee2.update()


                '---------------- update status ใบขออนุญาตระบบต่างๆ ----------------------
                'ดึง process id
                Dim dao_type As New DAO_FEE.TB_feetype
                Try
                    dao_type.Getdata_by_feeabbr(feeabbr_head)
                Catch ex As Exception

                End Try
                Dim dao_feex As New DAO_FEE.TB_fee
                dao_feex.GetDataby_ref1_ref2(dao_fee3.fields.ref01, dao_fee3.fields.ref02)

                Try
                    'update สถานะ
                    Dim bao2 As New BAO_FEE.FEE
                    bao2.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(dao_fee3.fields.ref01, dao_fee3.fields.ref02, dao_type.fields.process_id, dao_fee.fields.dvcd)
                Catch ex As Exception

                End Try
                '------------------------------------------

                Dim uri As String = ""
                uri = Request.Url.AbsoluteUri & "&ida=" & dao.fields.RECEIVE_MONEY_ID
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกรายการซ้ำ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
                '    dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY
                '    dao.Getdata_by_receipt3(fee_format, dao_abbr.fields.dvcd)
            End If

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เพราะยังไม่ได้ออกใบสั่งชำระ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
        End If

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

    'Private Sub ddl_abbr_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_abbr_type.SelectedIndexChanged
    '    set_amount()
    'End Sub
    'Public Sub set_amount()
    '    Dim amount As Double = 0
    '    Try
    '        Dim dao As New DAO_FEE.TB_feetype
    '        dao.Getdata_by_feeabbr(ddl_abbr_type.SelectedValue)
    '        For Each dao.fields In dao.datas
    '            amount = dao.fields.value
    '        Next
    '        txt_RECEIVE_AMOUNT.Text = amount
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub rg_receive_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_receive.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        If Request.QueryString("ida") <> "" Then
            dt = bao.SP_RECEIVE_MONEY_DETAIL2_BY_FK_IDA(Request.QueryString("ida"))
        End If
        rg_receive.DataSource = dt
    End Sub

    'Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
    '    Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
    '    dao.fields.AMOUNT = txt_RECEIVE_AMOUNT.Value
    '    dao.fields.FEEABBR = ddl_abbr_type.SelectedValue
    '    dao.fields.FK_IDA = Request.QueryString("ida")
    '    dao.fields.TABEAN_NUMBER = ""
    '    dao.insert()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
    '    rg_receive.Rebind()

    'End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        btn_save.Style.Add("display", "block")
        btn_print.Style.Add("display", "none")
        btn_reset.Style.Add("display", "none")
        Panel1.Style.Add("display", "none")
        rg_receive.Rebind()
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        'Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?id_rec=" & Request.QueryString("ida"))
        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("ida"))
        Dim url As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & Request.QueryString("ida") & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)
    End Sub
End Class