Imports Telerik.Web.UI
Public Class UC_Disburse_PO
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

    Private _ReId As Integer = 0
    Public Property ReId() As Integer
        Get
            Return _ReId
        End Get
        Set(ByVal value As Integer)
            _ReId = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_PO_Init(sender As Object, e As EventArgs) Handles rg_Disburse_PO.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_PO
        Rad_Utility.Rad_css_setting(rg_Disburse_PO)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DEPARTMENT_ID", "DEPARTMENT_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ", Display:=False)
        Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=300)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
        Rad_Utility.addColumnBound("balance", "จำนวนเงินคงเหลือเบิก", is_money:=True)
        Rad_Utility.addColumnBound("EGP_NUMBER", "เลขคุมสัญญา")
        Rad_Utility.addColumnBound("PO_No", "เลข PO")
        Rad_Utility.addColumnBound("stat", "สถานะ")
        Rad_Utility.addColumnIMG("I", "เบิก/ดูรายการที่เบิกแล้ว", "I", 0, "", img:=True, type_img:="insert")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
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
            End If
        End If
    End Sub

    'Private Sub rg_Disburse_PO_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_PO.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
    '        Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
    '        Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
    '        Dim btn_insert As ImageButton = DirectCast(item("I").Controls(0), ImageButton)
    '        Dim btn_del As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
    '        dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
    '        Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
    '        dao_det.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
    '        h2.Attributes.Add("OnClick", "return k(" & id & "," & bg_id & "," & bgyear & ");")
    '        Dim img As Image = DirectCast(item("img").Controls(0), Image)

    '        Dim url As String = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_List.aspx?id=" & id
    '        ' Dim url2 As String = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_Edit.aspx?bid=" & id & "&bguse=1" & "&bgid=" & dao_head.fields.BUDGET_PLAN_ID
    '        btn_insert.PostBackUrl = url
    '        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
    '        dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
    '        'Dim dao_pro As New DAO_PROCURE.TB_PROCUREMENT_GUARANTEE_HEAD
    '        'dao_pro.Getdata_by_G_NO(dao_head.fields.EGP_NUMBER)
    '       If dao_bill.fields.IS_APPROVE Then
    '            h2.Visible = False
    '            btn_del.Visible = False
    '        Else
    '            btn_insert.Visible = False
    '        End If

    '        'If dao_bill.fields.IS_APPROVE Then
    '        '    If dao_det.fields.AMOUNT <= 5000 Then
    '        '        h2.Visible = False
    '        '        btn_del.Visible = False
    '        '    Else
    '        '        If dao_pro.fields.PO_No IsNot Nothing And dao_pro.fields.PO_No <> "" Then
    '        '            h2.Visible = False
    '        '            btn_del.Visible = False
    '        '        Else
    '        '            btn_insert.Visible = False
    '        '        End If

    '        '    End If

    '        'Else
    '        '    btn_insert.Visible = False
    '        'End If


    '        If item("balance").Text <> "" And item("balance").Text <> "&nbsp;" Then
    '            If CDbl(item("balance").Text) = 0 Then
    '                item("balance").ForeColor = Drawing.Color.Crimson
    '            ElseIf CDbl(item("balance").Text) < 0 Then
    '                item("balance").ForeColor = Drawing.Color.Crimson
    '            Else
    '                item("balance").ForeColor = Drawing.Color.Green
    '            End If
    '        End If
    '        If dao_bill.fields.IS_APPROVE IsNot Nothing Then
    '            If dao_bill.fields.IS_APPROVE = True Then
    '                img.ImageUrl = "~/images/cb.png"
    '            Else
    '                img.ImageUrl = "~/images/emp_cb.png"
    '            End If
    '        Else
    '            img.ImageUrl = "~/images/emp_cb.png"
    '        End If
    '    End If
    'End Sub
    Private Sub rg_Disburse_PO_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_PO.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text

            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim btn_insert As ImageButton = DirectCast(item("I").Controls(0), ImageButton)
            Dim btn_del As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)

            dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            h2.Attributes.Add("OnClick", "return k(" & id & "," & bg_id & "," & bgyear & ");")
            Dim img As Image = DirectCast(item("img").Controls(0), Image)

            Dim url As String = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_List.aspx?id=" & id & "&dept=" & Request.QueryString("dept") & "&myear=" & Request.QueryString("myear") & "&bgid=" & Request.QueryString("bgid")
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

            If item("balance").Text <> "" And item("balance").Text <> "&nbsp;" Then
                If CDbl(item("balance").Text) = 0 Then
                    item("balance").ForeColor = Drawing.Color.Crimson
                ElseIf CDbl(item("balance").Text) < 0 Then
                    item("balance").ForeColor = Drawing.Color.Crimson
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

        If _ReId = 0 Then
            dt = bao.get_Support_PO_from_bg_bill_V2(bgyear, bguse, stat, g, bt, dept)
        Else
            dt = bao.get_Support_PO_from_bg_bill_V2_byRelateId(bgyear, bguse, stat, g, bt, dept, _ReId)
        End If

        'If is_support <> True Then
        '    dt = bao.get_PO_from_bg_bill(bgyear, bg_id, bguse)
        'Else
        '    dt = bao.get_Support_PO_from_bg_bill(bgyear, bg_id, bguse, sub_BudgetID)
        'End If

        dt.Columns.Add("stat")
        dt.Columns.Add("balance")
        dt.Columns.Add("sort_col")

        For Each dr As DataRow In dt.Rows
            Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            Dim bao_sub As New BAO_BUDGET.DISBURSE_BUDGET
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim po_head_amount As Double = 0
            Dim disburse_amount As Double = 0
            dao_po.Getdata_by_Disburse_id(dr("BUDGET_DISBURSE_BILL_ID"))
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(dr("BUDGET_DISBURSE_BILL_ID"))
            If dao_po.fields.AMOUNT IsNot Nothing Then
                po_head_amount = dao_po.fields.AMOUNT
            End If
            disburse_amount = bao_sub.get_sub_po_amount(dr("BUDGET_DISBURSE_BILL_ID"))
            dr("balance") = (po_head_amount - disburse_amount).ToString("N")

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
            'If CDbl(dr("balance")) = 0 Then
            '    dr("stat") = "เบิกเงินครบแล้ว"
            '    dr("sort_col") = "2"
            'Else
            '    dr("stat") = "สามารถเบิกได้"
            '    dr("sort_col") = "1"
            'End If


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
End Class