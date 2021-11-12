Imports Telerik.Web.UI
Public Class Frm_Maintain_Receive_Money_L44
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
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        If Not IsPostBack Then
            txt_check_date.Text = Date.Now.ToShortDateString()
            set_dd_bgyear()
            bind_ddl_receiver()
            Dim url As String = "Frm_Maintain_ReceiveMoney_Search_Receipt.aspx?myear=" & bgYear & "&dept=" & _dept

            'If Request.QueryString("law") <> "" Then
            url &= "&law=1"
            'End If
            HyperLink1.NavigateUrl = url
            'bind_income()
            'bind_customer()
            ' bind_ddl_receipt_type()
            'bind_ddl_money_type()
            ' set_amount()
            'txt_MONEY_RECEIVE_DATE.Text = Date.Now.ToShortDateString()
            'Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            'Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
            'dao_node.Getdata_Head_no_Year(0)
            'Dim rtv_money_type As New RadTreeView
            'rtv_money_type = DirectCast(rcb_Moneytype.Items(0).FindControl("rtv_money_type"), RadTreeView)
            'For Each dao_node.fields In dao_node.datas
            '    Dim node As New RadTreeNode
            '    dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            '    node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
            '    node.Value = dao_node.fields.MONEY_TYPE_ID
            '    rtv_money_type.Nodes.Add(node)
            '    bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
            'Next
        End If
    End Sub
    Sub bind_ddl_receiver()
        Dim dao As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao.Get_ONLY_USE_RECEIVER()

        ddl_receiver.DataSource = dao.datas
        ddl_receiver.DataTextField = "RECEIVER_NAME"
        ddl_receiver.DataValueField = "RECEIVER_MONEY_ID"
        ddl_receiver.DataBind()
    End Sub
    'Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
    '    Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
    '    Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
    '    'dao_node.Getdata_Head(ParentID, bgyear)
    '    dao_node.Getdata_Head_no_Year(ParentID)
    '    For Each dao_node.fields In dao_node.datas
    '        dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
    '        Dim node As New RadTreeNode
    '        node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
    '        node.Value = dao_node.fields.MONEY_TYPE_ID
    '        rt.Add(node)
    '        bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
    '    Next
    'End Sub
    'Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
    '    Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
    '    dao_rec.get_receiver()
    '    Dim a As Integer = dao_rec.fields.RECEIVER_MONEY_ID
    '    'dao.fields.RECEIVE_MONEY_TYPE = rbl_RECEIVE_MONEY_TYPE.SelectedItem.Value
    '    dao.fields.RECEIVE_MONEY_DESCRIPTION = ddl_abbr_type.SelectedItem.Text 'txt_RECEIVE_MONEY_DESCRIPTION.Text
    '    dao.fields.FULLNAME = dd_CUSTOMER.SelectedItem.Text
    '    dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
    '    dao.fields.RECEIVER_MONEY_ID = a
    '    dao.fields.RECEIVE_AMOUNT = txt_RECEIVE_AMOUNT.Text
    '    'dao.fields.DEPARTMENT_ID = dd_Department.SelectedValue
    '    dao.fields.BUDGET_YEAR = bgYear
    '    Try
    '        dao.fields.MONEY_RECEIVE_DATE = CDate(txt_MONEY_RECEIVE_DATE.Text)
    '    Catch ex As Exception

    '    End Try
    '    dao.fields.RECEIVE_MONEY_TYPE = rbl_RECEIVE_MONEY_TYPE.SelectedValue
    '    dao.fields.MONEY_TYPE_ID = ddl_money_type.SelectedValue


    '    dao.fields.ORDER_PAY1 = txt_ORDER_PAY1.Text
    '    'dao.fields.ORDER_PAY2 = txt_ORDER_PAY2.Text
    '    dao.fields.FULL_RECEIVE_NUMBER = txt_FULL_RECEIVE_NUMBER.Text
    '    dao.fields.INCOME_IDA = ddl_Income.SelectedValue
    '    dao.fields.IS_SINBON = cb_sinbon.Checked
    '    dao.fields.IS_CHECK_OUT_PROVINCE = cb_IS_CHECK_OUT_PROVINCE.Checked
    '    dao.fields.IS_SEND_TO_BANK = cb_IS_SEND_TO_BANK.Checked
    '    dao.fields.SINBON_AMOUNT = txt_SINBON_AMOUNT.Value
    '    dao.fields.LCNSID = dd_CUSTOMER.SelectedValue
    '    dao.fields.FEEABBR = ddl_abbr_type.SelectedValue
    '    'dao.fields.FEENO = txt_ORDER_PAY2.Text
    '    dao.fields.RECEIPT_TYPE = 2 'กรอกเอง

    'End Sub
    Public Sub set_dd_bgyear()
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If byearMax < 2500 Then
            byearMax = byearMax + 543
        End If
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If
        Dim curent_year As Integer = 2565 '= byearMax


        For i As Integer = 2555 To curent_year '+ 3
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        dd_BudgetYear.DataSource = dt
        dd_BudgetYear.DataBind()
        'dd_BudgetYear.DropDownSelectData(curent_year)
        'dd_BudgetYear.Items.Insert(0, New ListItem(2558, 2558)) 'เพิ่มใหม่

        'dd_BudgetYear.SelectedValue = 2557
        'dd_BudgetYear.DropDownSelectData(2557)
    End Sub
    Private Sub rg_receive_Init(sender As Object, e As EventArgs) Handles rg_receive.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_receive
        Rad_Utility.addColumnBound("RECEIVE_MONEY_ID", "RECEIVE_MONEY_ID", False)
        Rad_Utility.addColumnBound("RECEIPT_TYPE", "RECEIPT_TYPE", False)

        Rad_Utility.addColumnBound("receipt_no", "เลขที่ใบเสร็จ", width:=150)
        Rad_Utility.addColumnDate("MONEY_RECEIVE_DATE", "วันที่ออกใบเสร็จ")
        Rad_Utility.addColumnBound("FEENO", "เลขที่ชำระ", width:=250)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_DESCRIPTION", "รายการ", width:=350)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_TYPE", "ประเภทเงินที่รับ")
        Rad_Utility.addColumnBound("RECEIVE_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120)
        Rad_Utility.addColumnButton("EDT", "แก้ไข", "EDT", 0, "", width:=120)
        Rad_Utility.addColumnButton("cancel", "ยกเลิก", "cancel", 0, "คุณต้องการยกเลิกหรือไม่", width:=100)
        'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=100)


    End Sub

    Private Sub rg_receive_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_receive.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Delete" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_return_money.Getdata_by_RECEIVE_MONEY_ID(item("RECEIVE_MONEY_ID").Text)
                dao_return_money.delete()
                rg_receive.Rebind()
            ElseIf e.CommandName = "cancel" Then
                'Dim dao_return_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                'dao_return_money.Getdata_by_RECEIVE_MONEY_ID(item("RECEIVE_MONEY_ID").Text)
                'dao_return_money.fields.IS_CANCEL = True
                'dao_return_money.fields.CANCEL_DATE = Date.Now
                'dao_return_money.update()
                'rg_receive.Rebind()
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อยแล้ว');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('../Module03/Frm_Maintain_Remark.aspx?IDA=" & item("RECEIVE_MONEY_ID").Text & "&receive=" & ddl_receiver.SelectedValue & "');", True)
            ElseIf e.CommandName = "P" Then
                Dim id As Integer = item("RECEIVE_MONEY_ID").Text
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao.Getdata_by_RECEIVE_MONEY_ID(id)

                'Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&copy=1" & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR
                Dim url_p As String = ""
                'If item("RECEIPT_TYPE").Text <> "6" Then
                url_p = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & ID & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR & "&law=1"

                'Else
                '    url_p = "../Module09/Report/Frm_Report_R9_003.aspx?id_feeno=" & id & "&dvcd=" & dao.fields.DVCD & "&feeno=" & dao.fields.FEENO & "&feeabbr=" & dao.fields.FEEABBR & "&myear=" & dao.fields.BUDGET_YEAR & "&rt=3&law=1"

                'End If

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
                Dim url2 As String = "../Module09/Report/Frm_Report_R9_003.aspx?feeno=" & querystr.EncodeBase64

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", " Popups('" & url_p & "'); return false;", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", " window.open('" & url2 & "', '_blank');", True)

            End If
        End If
    End Sub

    Private Sub rg_receive_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_receive.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            If item("RECEIVE_MONEY_TYPE").Text = "1" Then
                item("RECEIVE_MONEY_TYPE").Text = "เงินสด"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "2" Then
                item("RECEIVE_MONEY_TYPE").Text = "เช็ค"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "3" Then
                item("RECEIVE_MONEY_TYPE").Text = "ดราฟ"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "4" Then
                item("RECEIVE_MONEY_TYPE").Text = "แคชเชียร์เช็ค"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "5" Then
                item("RECEIVE_MONEY_TYPE").Text = "เงินฝากธนาคาร"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "6" Then
                item("RECEIVE_MONEY_TYPE").Text = "บัตรเครดิต"
            End If

            'Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?ID=" & dao_maintain_receive_money.fields.RECEIVE_MONEY_ID)
            Dim id As Integer = item("RECEIVE_MONEY_ID").Text
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_RECEIVE_MONEY_ID(id)
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            Dim EDT As LinkButton = DirectCast(item("EDT").Controls(0), LinkButton)
            Dim url As String = ""
            url = "Frm_Maintain_Receive_Money_V2_Edit.aspx?ida=" & id
            EDT.Attributes.Add("OnClick", "Popups4('" & url & "'); return false;")
            


        End If
    End Sub

    Private Sub rg_receive_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_receive.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As New DataTable
        Try
            dt = bao.get_RECEPT_by_BUDGET_YEAR_AND_DATE_L44(dd_BudgetYear.SelectedValue, CDate(txt_check_date.Text))


            dt.DefaultView.Sort = "RUNNING_RECEIPT DESC"

            dt = dt.DefaultView.ToTable()
        Catch ex As Exception

        End Try

        rg_receive.DataSource = dt
    End Sub
    'Public Sub bind_ddl_money_type()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO_BUDGET.MASS
    '    dt = bao.get_money_type_list

    '    ddl_money_type.DataSource = dt
    '    ddl_money_type.DataBind()
    'End Sub
    'Sub bind_income()
    '    Dim bao As New BAO_BUDGET.MASS
    '    Dim dt As New DataTable
    '    dt = bao.get_income_tb()

    '    ddl_Income.DataSource = dt
    '    ddl_Income.DataBind()
    'End Sub
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
    'Private Function feeno_format()
    '    Dim fee_format As String = ""
    '    Dim arr_feeno As String() = Nothing
    '    Try
    '        arr_feeno = txt_ORDER_PAY2.Text.Split("/")
    '        fee_format = arr_feeno(1) & arr_feeno(0)
    '    Catch ex As Exception

    '    End Try
    '    Return fee_format
    'End Function

    'Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
    '    Dim count_row As Integer = 0
    '    Dim dao_abbr As New DAO_FEE.TB_feetype
    '    dao_abbr.Getdata_by_feeabbr(ddl_abbr_type.SelectedValue)
    '    Dim dao_fee As New DAO_FEE.TB_fee

    '    Dim fee_format As String = feeno_format()

    '    count_row = dao_fee.count_row_fee(fee_format, dao_abbr.fields.dvcd)
    '    Dim dao_fee3 As New DAO_FEE.TB_fee
    '    dao_fee3.Getdata_by_feeno_and_dvcd(fee_format, dao_abbr.fields.dvcd)

    '    If count_row > 0 Then
    '        Dim count_bg As Integer = 0
    '        Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '        count_bg = dao.count_receipt3(dao_abbr.fields.dvcd, fee_format)
    '        If count_bg = 0 Then
    '            dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '            Dim bao As New BAO_BUDGET.Maintain
    '            Dim max_id As Integer = 0
    '            Try
    '                max_id = bao.get_max_receipt_normal(Request.QueryString("myear"), 1)
    '            Catch ex As Exception

    '            End Try
    '            insert(dao)
    '            dao.fields.FEENO = fee_format
    '            dao.fields.ORDER_PAY2 = fee_format
    '            dao.fields.RUNNING_RECEIPT = max_id + 1
    '            dao.insert()

    '            Dim dao_fd As New DAO_FEE.TB_feedtl
    '            dao_fd.Getdata_by_fee_id(dao_fee3.fields.IDA)

    '            For Each dao_fd.fields In dao_fd.datas
    '                Dim dao_det As New DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL2
    '                dao_det.fields.FK_IDA = dao.fields.RECEIVE_MONEY_ID
    '                Try
    '                    dao_det.fields.AMOUNT = dao_fd.fields.amt
    '                Catch ex As Exception
    '                    dao_det.fields.AMOUNT = 0
    '                End Try
    '                dao_det.fields.FEEABBR = ddl_abbr_type.SelectedValue
    '                dao_det.fields.TABEAN_NUMBER = ""
    '                dao_det.insert()
    '            Next

    '            Dim dao_fee2 As New DAO_FEE.TB_fee
    '            dao_fee2.Getdata_by_feeno_and_dvcd(fee_format, dao_abbr.fields.dvcd)
    '            dao_fee2.fields.rcptst = 1
    '            dao_fee2.update()
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
    '        Else
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกซ้ำ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
    '            '    dao = New DAO_MAINTAIN.TB_RECEIVE_MONEY
    '            '    dao.Getdata_by_receipt3(fee_format, dao_abbr.fields.dvcd)
    '        End If

    '    Else
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เพราะยังไม่ได้ออกใบสั่งชำระ'); $('#ctl00_ContentPlaceHolder1_btn_refresh').click();", True)
    '    End If

    'End Sub

    'Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
    '    rg_receive.Rebind()
    'End Sub

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

    Private Sub dd_BudgetYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetYear.SelectedIndexChanged
        rg_receive.Rebind()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        rg_receive.Rebind()
    End Sub

    Private Sub txt_check_date_TextChanged(sender As Object, e As EventArgs) Handles txt_check_date.TextChanged
        rg_receive.Rebind()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        rg_receive.Rebind()
    End Sub
End Class