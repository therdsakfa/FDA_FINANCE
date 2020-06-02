Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_With_Approve
    Inherits System.Web.UI.UserControl
    Private _BudgetUseID As Integer
    Public Property BudgetUseID() As Integer
        Get
            Return _BudgetUseID
        End Get
        Set(ByVal value As Integer)
            _BudgetUseID = value
        End Set
    End Property
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
        End Set
    End Property
    Private _sub_BudgetID As Integer
    Public Property sub_BudgetID() As Integer
        Get
            Return _sub_BudgetID
        End Get
        Set(ByVal value As Integer)
            _sub_BudgetID = value
        End Set
    End Property
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _is_support As Boolean
    Public Property is_support() As Boolean
        Get
            Return _is_support
        End Get
        Set(ByVal value As Boolean)
            _is_support = value
        End Set
    End Property
    Private _is_benefit As Boolean
    Public Property is_benefit() As Boolean
        Get
            Return _is_benefit
        End Get
        Set(ByVal value As Boolean)
            _is_benefit = value
        End Set
    End Property
    Private _bt As Integer
    Public Property bt() As Integer
        Get
            Return _bt
        End Get
        Set(ByVal value As Integer)
            _bt = value
        End Set
    End Property
    Private _stat As Integer
    Public Property stat() As Integer
        Get
            Return _stat
        End Get
        Set(ByVal value As Integer)
            _stat = value
        End Set
    End Property
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
        End Set
    End Property
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_Disburse_Budget_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rg_Disburse_Budget.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Budget
        Rad_Utility.Rad_css_setting(rg_Disburse_Budget)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("PAY_TYPE_ID", "PAY_TYPE_ID", False)
        Rad_Utility.addColumnBound("RowNumber", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ", Display:=False)
        Rad_Utility.addColumnBound("app", "app", False)
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.", False)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        'Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True, footer_txt:="รวม", width:=120)
        Rad_Utility.addColumnBound("reason", "เหตุผลการไม่อนุมัติ")
        Rad_Utility.addColumnBound("stat_name", "สถานะ")
        'Rad_Utility.addColumnBound("status_bill", "สถานะ")
        'Rad_Utility.addColumnDate("RETURN_BUDGET_DATE", "วันครบกำหนดคืนคลัง")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
        'Rad_Utility.addColumnButton("cancel", "ยกเลิก", "cancel", 0, "คุณต้องการยกเลิกหรือไม่", width:=120)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        'Rad_Utility.addColumnIMG("cancel", "ยกเลิก", "cancel", 0, "คุณต้องการยกเลิกหรือไม่", img:=True, type_img:="cancel")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub
    ''' <summary>
    ''' กำหนดฟิลด์คำสั่ง radgrid เบิกจ่ายงบประมาณ
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub rg_Disburse_Budget_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Disburse_Budget.ItemCommand

        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item

        '    Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
        '    Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        '    dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
        '    dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
        '    dao_head.delete()
        '    dao_detail.delete()
        '    Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx")

        'End If

        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                ' del_item(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                For Each dao_detail.fields In dao_detail.datas
                    dao_detail.delete()
                Next

                dao_head.delete()

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลใบเบิกจ่ายเลขที่หนังสือ " & dao_head.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)
                'Response.Redirect(Request.Url.AbsoluteUri)
                rg_Disburse_Budget.Rebind()
            ElseIf e.CommandName = "cancel" Then
                Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                Dim dao_head_in As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail_in As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)

                Dim dao_a As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                'Dim bao_sub As New BAO_BUDGET.DISBURSE_BUDGET
                Dim old_amount As Double = 0
                Dim disburse_amount As Double = 0
                Dim balance As Double = 0
                dao_a.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                If dao_a.fields.AMOUNT IsNot Nothing Then
                    old_amount = dao_a.fields.AMOUNT
                End If
                ' disburse_amount = bao_sub.get_sub_po_amount(item("BUDGET_DISBURSE_BILL_ID").Text)
                balance = old_amount '- disburse_amount

                dao_head.fields.IS_CANCEL = True
                Try
                    dao_head.fields.CANCEL_DATE = Date.Now
                Catch ex As Exception

                End Try
                dao_head.update()

                dao_head_in.fields.USER_AD = NameUserAD()
                dao_head_in.fields.BUDGET_YEAR = dao_head.fields.BUDGET_YEAR
                dao_head_in.fields.BUDGET_PLAN_ID = dao_head.fields.BUDGET_PLAN_ID
                dao_head_in.fields.Bill_RECIEVE_DATE = dao_head.fields.Bill_RECIEVE_DATE
                dao_head_in.fields.DOC_NUMBER = dao_head.fields.DOC_NUMBER
                dao_head_in.fields.DOC_DATE = dao_head.fields.DOC_DATE
                dao_head_in.fields.BILL_NUMBER = dao_head.fields.BILL_NUMBER
                dao_head_in.fields.BILL_DATE = dao_head.fields.BILL_DATE
                dao_head_in.fields.DESCRIPTION = "ยกเลิก_" & dao_head.fields.DESCRIPTION
                dao_head_in.fields.PATLIST_ID = dao_head.fields.PATLIST_ID
                dao_head_in.fields.IS_APPROVE = False
                dao_head_in.fields.IS_DEPARTMENT = False
                dao_head_in.fields.CUSTOMER_TYPE_ID = dao_head.fields.CUSTOMER_TYPE_ID
                dao_head_in.fields.CUSTOMER_ID = dao_head.fields.CUSTOMER_ID
                dao_head_in.fields.BUDGET_USE_ID = dao_head.fields.BUDGET_USE_ID
                dao_head_in.fields.GFMIS_NUMBER = ""
                dao_head_in.fields.GFMIS_DATE = Nothing
                dao_head_in.fields.INVOICES_DATE = Nothing
                dao_head_in.fields.INVOICES_NUMBER = ""
                dao_head_in.fields.RECEIPT_NUMBER = ""
                dao_head_in.fields.RECEIPT_DATE = Nothing
                dao_head_in.fields.RETURN_APPROVE_DATE = Nothing
                dao_head_in.fields.RETURN_APPROVE_NUMBER = ""
                dao_head_in.fields.PAY_TYPE_ID = dao_head.fields.PAY_TYPE_ID
                dao_head_in.fields.DEPARTMENT_ID = dao_head.fields.DEPARTMENT_ID
                dao_head_in.fields.DEBTOR_ID = 0
                dao_head_in.fields.CHECK_APPROVE = False
                dao_head_in.fields.IS_CHECK_RECEIVE = False
                dao_head_in.fields.MAX_PRIZE = dao_head.fields.MAX_PRIZE
                dao_head_in.fields.RECEIVE_PAYLIST = dao_head.fields.RECEIVE_PAYLIST
                dao_head_in.fields.IS_PO = False
                dao_head_in.insert()

                dao_detail_in.fields.AMOUNT = balance * -1
                dao_detail_in.fields.TAX_AMOUNT = 0
                dao_detail_in.fields.IS_ENABLE = True
                dao_detail_in.fields.BUDGET_DISBURSE_BILL_ID = dao_head_in.fields.BUDGET_DISBURSE_BILL_ID
                dao_detail_in.fields.APPROVE_AMOUNT = 0
                dao_detail_in.insert()

                rg_Disburse_Budget.Rebind()
            End If
        End If

    End Sub
    Public Sub del_item(ByVal id As Integer)
        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
        dao_detail.Getdata_by_Disburse_id(id)
        dao_head.delete()
        dao_detail.delete()
        rg_Disburse_Budget.Rebind()
    End Sub

    ''' <summary>
    ''' ดึงข้อมูลเบิกจ่ายงบประมาณใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rg_Disburse_Budget_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_Budget.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable
        If is_support <> True Then
            If _is_benefit = True Then
                dt = BudgetBill.get_BUDGET_BILL_by_year_bg_id(BudgetUseID, BudgetYear, BudgetID)
            Else
                'dt = BudgetBill.get_BUDGET_BILL_by_bg_year_bg_id(BudgetUseID, BudgetYear, BudgetID)
                'dt = BudgetBill.get_BUDGET_BILL_by_year_bg_id_bt_group(BudgetUseID, BudgetYear, BudgetID, 1, g, bt)
                If BudgetUseID = 1 Then
                    dt = BudgetBill.get_BUDGET_BILL_by_year_bg_id_bt_group_V2(BudgetUseID, BudgetYear, dept, 1, g, bt)
                Else
                    dt = BudgetBill.get_BUDGET_BILL_by_year_bg_id_bt_group_out(BudgetYear, 1, g, bt)
                End If

            End If


        Else
        If _is_benefit = True Then
            dt = BudgetBill.get_bg_support_by_year_bg_id(BudgetUseID, BudgetYear, BudgetID, sub_BudgetID)
        Else
            dt = BudgetBill.get_bg_support_by_bg_year_bg_id(BudgetUseID, BudgetYear, BudgetID, sub_BudgetID)
        End If
        End If

        dt.Columns.Add("status_bill", Type.GetType("System.String"))
        dt.Columns.Add("app")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                dr("status_bill") = status_bill(dr("BUDGET_DISBURSE_BILL_ID"))
            Next
        End If
        'For Each dr As DataRow In dt.Rows
        '    If IsDBNull(dr("IS_APPROVE")) = False Then
        '        If CBool(dr("IS_APPROVE")) = True Then
        '            dr("app") = "1"
        '        Else
        '            dr("app") = "2"
        '        End If
        '    Else
        '        dr("app") = "2"
        '    End If

        'Next

        rg_Disburse_Budget.DataSource = dt

    End Sub


    Private Sub rg_Disburse_Budget_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rg_Disburse_Budget.ItemDataBound
        'TestPopup.aspx
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            'Dim h3 As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim h3 As LinkButton = DirectCast(item("DeleteColumn").Controls(0), LinkButton)
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            'h2.Attributes.Add("OnClick", "return k(" & id & "," & BudgetID & "," & BudgetYear & ");")

            If BudgetUseID <> 3 Then
                h2.Attributes.Add("OnClick", "Popups2('Frm_Disburse_Budget_Bill_Insert_V3.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & BudgetYear & "&dept=" & dept & "'); return false;")
            Else
                h2.Attributes.Add("OnClick", "Popups2('../../Module02/Disburse_Budget/Frm_Disburse_Budget_Bill_Insert_V2.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & BudgetYear & "&dept=" & Request.QueryString("dept") & "&bguse=3'); return false;")
            End If
            'Dim img_button As ImageButton = DirectCast(item("del").Controls(0), ImageButton)
            'img_button.Attributes.Add("onclick", "return false;")
            
            Dim img As Image = DirectCast(item("img").Controls(0), Image)

            If dao.fields.GFMIS_NUMBER IsNot Nothing Then
                If dao.fields.GFMIS_NUMBER <> "" Then
                    h2.Visible = False
                    h3.Visible = False
                End If
            End If

            Dim dao_a As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            Dim co As Integer = 0
            '
            Dim aa As Integer = 235
            Try
                co = dao_a.count_approve(item("BUDGET_DISBURSE_BILL_ID").Text, bt, stat)
            Catch ex As Exception

            End Try

            If co > 0 Then
                'ต้องเอาคืน เนื่องจากมันอัตโนมัติ
                'h2.Visible = False
                'h3.Visible = False

                h2.Visible = True
                h3.Visible = True
                img.ImageUrl = "~/images/cb.png"
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If

            'If dao.fields.IS_APPROVE IsNot Nothing Then
            '    If dao.fields.IS_APPROVE = True Then
            '        img.ImageUrl = "~/images/cb.png"
            '    Else
            '        img.ImageUrl = "~/images/emp_cb.png"
            '    End If
            'Else
            '    img.ImageUrl = "~/images/emp_cb.png"
            'End If
        End If
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Budget)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Budget, str)
    End Sub
    Public Sub rebind_grid()
        rg_Disburse_Budget.Rebind()
    End Sub
    Public Function status_bill(ByVal bill_id As Integer) As String
        Dim str_stat As String = ""
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
        If dao.fields.PAY_TYPE_ID IsNot Nothing Then
            If dao.fields.PAY_TYPE_ID = 1 Then
                If dao.fields.RETURN_APPROVE_NUMBER <> "" Or dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing Then
                    str_stat = "จ่ายตรงพร้อมจ่าย"
                End If
            Else
                If dao.fields.IS_CHECK_READY = True And (dao.fields.IS_CHECK_RECEIVE = False Or dao.fields.IS_CHECK_RECEIVE Is Nothing) Then
                    str_stat = "จ่ายผ่านเช็คพร้อมจ่าย"
                ElseIf dao.fields.IS_CHECK_READY = True And dao.fields.IS_CHECK_RECEIVE = True Then
                    str_stat = "รับเช็คแล้ว"
                End If
            End If

        End If

        Return str_stat
    End Function

    Public Sub set_color_rg()
        If rg_Disburse_Budget.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rg_Disburse_Budget.Items
                If i = 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                i = i + 1
            Next
        End If
    End Sub

    Public Sub update_true(ByVal date_input As Date)
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "อนุมัติใบเบิกจ่ายเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)

            dao.update()
        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = False
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ยกเลิกอนุมัติใบเบิกจ่ายเลขที่หนังสือ " & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)

            dao.update()
        Next
    End Sub

    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.GROUP_ID = g
            dao.fields.STATUS_ID = stat
            dao.update()

            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------เบิก------------------------
            dao_app.fields.BILL_TYPE = bt
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("BUDGET_DISBURSE_BILL_ID").Text
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = date_input
            dao_app.fields.STATUS_ID = stat
            dao_app.fields.GROUP_ID = g

            dao_app.insert()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub open_reject_note()
        Dim bill_id As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Budget.SelectedItems
            bill_id = item("BUDGET_DISBURSE_BILL_ID").Text
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('Frm_Reason.aspx?fk_ida=" & bill_id & "&bt=" & bt & "&stat=" & stat - 1 & "&g=" & g & "');", True)
    End Sub
End Class