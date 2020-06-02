Imports Telerik.Web.UI
Public Class UC_Disburse_PO_With_Approve
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Private _bg_id As Integer
    Public Property bg_id() As Integer
        Get
            Return _bg_id
        End Get
        Set(ByVal value As Integer)
            _bg_id = value
        End Set
    End Property
    Private _bguse As Integer
    Public Property bguse() As Integer
        Get
            Return _bguse
        End Get
        Set(ByVal value As Integer)
            _bguse = value
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
    Private _is_support As Boolean
    Public Property is_support() As Boolean
        Get
            Return _is_support
        End Get
        Set(ByVal value As Boolean)
            _is_support = value
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
    Private Sub rg_Disburse_PO_Init(sender As Object, e As EventArgs) Handles rg_Disburse_PO.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_PO
        Rad_Utility.Rad_css_setting(rg_Disburse_PO)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        'Rad_Utility.addColumnBound("DEPARTMENT_ID", "DEPARTMENT_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
        Rad_Utility.addColumnBound("balance", "จำนวนเงินคงเหลือเบิก", is_money:=True)
        'Rad_Utility.addColumnBound("EGP_NUMBER", "เลขคุมสัญญา")
        'Rad_Utility.addColumnBound("PO_No", "เลข PO")
        Rad_Utility.addColumnBound("stat", "สถานะ")
        Rad_Utility.addColumnButton("I", "เบิก/ดูรายการที่เบิกแล้ว", "I", 0, "")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnButton("cancel", "ยกเลิก", "cancel", 0, "คุณต้องการยกเลิก PO หรือไม่", _display:=False)
    End Sub

    Private Sub rg_Disburse_PO_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_Disburse_PO.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                ' del_item(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.delete()
                dao_head.delete()

                rg_Disburse_PO.Rebind()
                ' Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx")
            ElseIf e.CommandName = "cancel" Then
                Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                Dim dao_head_in As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail_in As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)

                Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                Dim bao_sub As New BAO_BUDGET.DISBURSE_BUDGET
                Dim po_head_amount As Double = 0
                Dim disburse_amount As Double = 0
                Dim balance As Double = 0
                dao_po.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim head_amount As Double = 0
                For Each dao_po.fields In dao_po.datas
                    head_amount += dao_po.fields.AMOUNT
                Next

                'If dao_po.fields.AMOUNT IsNot Nothing Then
                '    po_head_amount = dao_po.fields.AMOUNT
                'End If
                disburse_amount = bao_sub.get_sub_po_amount(item("BUDGET_DISBURSE_BILL_ID").Text)
                balance = head_amount - disburse_amount

                dao_head.fields.IS_CANCEL_PO = True
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
                dao_head_in.fields.IS_PO = True
                dao_head_in.insert()

                dao_detail_in.fields.AMOUNT = balance * -1
                dao_detail_in.fields.TAX_AMOUNT = 0
                dao_detail_in.fields.IS_ENABLE = True
                dao_detail_in.fields.BUDGET_DISBURSE_BILL_ID = dao_head_in.fields.BUDGET_DISBURSE_BILL_ID
                dao_detail_in.fields.APPROVE_AMOUNT = 0
                dao_detail_in.insert()

                rg_Disburse_PO.Rebind()
            End If
        End If
    End Sub

    Private Sub rg_Disburse_PO_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_PO.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim btn_insert As LinkButton = DirectCast(item("I").Controls(0), LinkButton)
            Dim btn_cancel As LinkButton = DirectCast(item("cancel").Controls(0), LinkButton)
            Dim btn_del As LinkButton = DirectCast(item("DeleteColumn").Controls(0), LinkButton)

            dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            'openform("Frm_Disburse_PO_edit.aspx?bid=" + id + "&bgid=" + bgid + "&bgYear=" + bgYear, "#1234");
            Dim url1 As String = "Frm_Disburse_PO_edit.aspx?bid=" & id & "&bgid=" & bg_id & "&bgYear=" & bgyear & "&dept=" & Request.QueryString("dept")
            h2.Attributes.Add("OnClick", "Popups2('" & url1 & "'); return false;")
            Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            dao_det.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim url As String
            If dao_head.fields.BUDGET_USE_ID = 3 Then
                url = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_List.aspx?id=" & id & "&bguse=3" & "&dept=" & _
                    dao_head.fields.DEPARTMENT_ID & "&bgid=" & dao_head.fields.BUDGET_PLAN_ID & "&bgYear=" & dao_head.fields.BUDGET_YEAR & "&myear=" & dao_head.fields.BUDGET_YEAR
            Else
                url = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_List.aspx?id=" & id & "&dept=" & _
                    dao_head.fields.DEPARTMENT_ID & "&bgid=" & dao_head.fields.BUDGET_PLAN_ID & "&bgYear=" & dao_head.fields.BUDGET_YEAR & "&myear=" & dao_head.fields.BUDGET_YEAR
            End If

            ' Dim url2 As String = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_Edit.aspx?bid=" & id & "&bguse=1" & "&bgid=" & dao_head.fields.BUDGET_PLAN_ID
            btn_insert.PostBackUrl = url
            Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)

            If dao_bill.fields.IS_APPROVE Then
                h2.Visible = False
                btn_del.Visible = False
            Else
                btn_insert.Visible = False
            End If
            If dao_head.fields.IS_CANCEL_PO IsNot Nothing Then
                btn_cancel.Visible = False
                h2.Visible = False
            End If

            'Dim dao_pro As New DAO_PROCURE.TB_PROCUREMENT_GUARANTEE_HEAD
            'dao_pro.Getdata_by_G_NO(dao_head.fields.EGP_NUMBER)

            'If dao_bill.fields.IS_APPROVE Then
            '    If dao_det.fields.AMOUNT <= 5000 Then
            '        h2.Visible = False
            '        btn_del.Visible = False
            '    Else
            '        If dao_pro.fields.PO_No IsNot Nothing And dao_pro.fields.PO_No <> "" Then
            '            h2.Visible = False
            '            btn_del.Visible = False
            '        Else
            '            btn_insert.Visible = False
            '        End If

            '    End If

            'Else
            '    btn_insert.Visible = False
            'End If

            If item("balance").Text <> "" And item("balance").Text <> "&nbsp;" Then
                If CDbl(item("balance").Text) = 0 Then
                    item("balance").ForeColor = Drawing.Color.Crimson
                    btn_cancel.Visible = False
                    h2.Visible = False
                ElseIf CDbl(item("balance").Text) < 0 Then
                    item("balance").ForeColor = Drawing.Color.Crimson
                    btn_cancel.Visible = False
                    h2.Visible = False
                Else
                    item("balance").ForeColor = Drawing.Color.Green
                End If
            End If
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            Try
                If dao.fields.STATUS_ID >= 3 Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Catch ex As Exception

            End Try
            'If dao_bill.fields.IS_APPROVE IsNot Nothing Then
            '    If dao_bill.fields.IS_APPROVE = True Then
            '        img.ImageUrl = "~/images/cb.png"
            '    Else
            '        img.ImageUrl = "~/images/emp_cb.png"
            '    End If
            'Else
            '    img.ImageUrl = "~/images/emp_cb.png"
            'End If
        End If
    End Sub


    Private Sub rg_Disburse_PO_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_PO.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        'If is_support <> True Then
        '    dt = bao.get_PO_from_bg_bill(bgyear, bg_id, bguse)
        'Else
        'dt = bao.get_Support_PO_from_bg_bill(bgyear, bg_id, bguse, sub_BudgetID)
        dt = bao.get_Support_PO_from_bg_bill_V2(bgyear, bguse, stat, g, bt, dept)
        'End If

        dt.Columns.Add("stat")
        dt.Columns.Add("balance")
        dt.Columns.Add("sort_col")

        For Each dr As DataRow In dt.Rows
            Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim bao_sub As New BAO_BUDGET.DISBURSE_BUDGET
            Dim po_head_amount As Double = 0
            Dim disburse_amount As Double = 0
            dao_po.Getdata_by_Disburse_id(dr("BUDGET_DISBURSE_BILL_ID"))
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(dr("BUDGET_DISBURSE_BILL_ID"))
            'If dao_po.fields.AMOUNT IsNot Nothing Then
            '    po_head_amount = dao_po.fields.AMOUNT
            'End If
            Dim head_amount As Double = 0
            For Each dao_po.fields In dao_po.datas
                head_amount += dao_po.fields.AMOUNT
            Next
            disburse_amount = bao_sub.get_sub_po_amount(dr("BUDGET_DISBURSE_BILL_ID"))
            dr("balance") = (head_amount - disburse_amount).ToString("N")
            If dao.fields.IS_CANCEL_PO Is Nothing Then
                If CDbl(dr("balance")) = 0 Then
                    dr("stat") = "เบิกเงินครบแล้ว"
                    dr("sort_col") = "2"
                ElseIf CDbl(dr("balance")) < 0 Then
                    dr("stat") = "ยกเลิก"
                    dr("sort_col") = "3"
                Else
                    dr("stat") = "สามารถเบิกได้"
                    dr("sort_col") = "1"
                End If
            Else
                dr("balance") = 0
                dr("stat") = "ยกเลิก"
                dr("sort_col") = "3"
            End If
        Next
        Dim dv As DataView = dt.DefaultView
        dv.Sort = "sort_col ASC , IS_APPROVE ,BUDGET_DISBURSE_BILL_ID DESC"

        dt = dv.ToTable()

        rg_Disburse_PO.DataSource = dt
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_PO)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_PO, str)
    End Sub
    Public Sub rebind_grid()
        rg_Disburse_PO.Rebind()
    End Sub
    Public Sub set_color_rg()
        If rg_Disburse_PO.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rg_Disburse_PO.Items
                If i = 0 Then
                    item.BackColor = Drawing.Color.Crimson

                End If
                i = i + 1
            Next
        End If
    End Sub
    Public Sub update_true(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Disburse_PO.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input
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
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "อนุมัติใบจัดซื้อจัดจ้างเลขที่หนังสือ " _
                           & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)
        Next
    End Sub

    Public Sub update_false()
        For Each item As GridDataItem In rg_Disburse_PO.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = False

            dao.update()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ยกเลิกอนุมัติใบจัดซื้อจัดจ้างเลขที่หนังสือ " _
                           & dao.fields.DOC_NUMBER, "BUDGET_BILL", item("BUDGET_DISBURSE_BILL_ID").Text)
        Next
    End Sub
End Class