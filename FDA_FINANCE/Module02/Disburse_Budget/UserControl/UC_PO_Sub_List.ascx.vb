Imports Telerik.Web.UI
Public Class UC_PO_Sub_List
    Inherits System.Web.UI.UserControl
    Private _bgid As Integer
    Public Property bgid() As Integer
        Get
            Return _bgid
        End Get
        Set(ByVal value As Integer)
            _bgid = value
        End Set
    End Property
    Private _sub_bgid As Integer
    Public Property sub_bgid() As Integer
        Get
            Return _sub_bgid
        End Get
        Set(ByVal value As Integer)
            _sub_bgid = value
        End Set
    End Property
    Private _bg_use As Integer
    Public Property bg_use() As Integer
        Get
            Return _bg_use
        End Get
        Set(ByVal value As Integer)
            _bg_use = value
        End Set
    End Property
    Private _is_support_dept As Boolean
    Public Property is_support_dept() As Boolean
        Get
            Return _is_support_dept
        End Get
        Set(ByVal value As Boolean)
            _is_support_dept = value
        End Set
    End Property
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
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
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
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
    Private _is_rebill As Boolean
    Public Property is_rebill() As Boolean
        Get
            Return _is_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_rebill = value
        End Set
    End Property

    Private _is_no_rebill As Boolean
    Public Property is_no_rebill() As Boolean
        Get
            Return _is_no_rebill
        End Get
        Set(ByVal value As Boolean)
            _is_no_rebill = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_PO_Sub_List_Init(sender As Object, e As EventArgs) Handles rg_PO_Sub_List.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_PO_Sub_List
        Rad_Utility.Rad_css_setting(rg_PO_Sub_List)
       Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DETAIL_ID", "DETAIL_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้/ผู้รับเงิน")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnDate("GFMIS_DATE", "วันที่ GFMIS")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=200)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", width:=120, is_money:=True)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_PO_Sub_List_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_PO_Sub_List.ItemCommand
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

                rg_PO_Sub_List.Rebind()
                ' Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx")
            End If
        End If
    End Sub

    Private Sub rg_PO_Sub_List_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_PO_Sub_List.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            ' Dim id_head As Integer = item("PO_HEAD_ID").Text
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            'Dim del As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
            'Dim btn_insert As ImageButton = DirectCast(item("I").Controls(0), ImageButton)
            'Dim url As String = "../../../Module02/Disburse_Budget/Frm_Disburse_PO_List.aspx?id=" & id_head
            'btn_insert.PostBackUrl = url
            'h2.Attributes.Add("OnClick", "return k(" & id & "," & dao.fields.BUDGET_PLAN_ID & "," & dao.fields.BUDGET_YEAR & ");")
            'Dim img_button As ImageButton = DirectCast(item("del").Controls(0), ImageButton)
            'img_button.Attributes.Add("onclick", "return false;")
            'Dim dao_app As New DAO_DISBURSE.TB_BUDGET_BILL
            'dao_app.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            'If dao_app.fields.BUDGET_DISBURSE_BILL_ID <> Nothing Then
            '    If dao_app.fields.IS_APPROVE = True Then
            '        h2.Visible = False
            '        del.Visible = False
            '    End If
            'End If


        End If
    End Sub

    Private Sub rg_PO_Sub_List_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_PO_Sub_List.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        dt = bao.getGF_bg_bill_sub_PO_bt_group_v2(bg_use, Budgetyear, stat - 1, g, bt)

        'If is_support_dept = False Then
        '    dt = bao.get_Sub_PO(bgid, bg_use)
        'Else
        '    dt = bao.get_Sub_PO_dept(bgid, bg_use, sub_bgid)
        'End If

        rg_PO_Sub_List.DataSource = dt
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_PO_Sub_List)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rebind_grid()
        rg_PO_Sub_List.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_PO_Sub_List, str)
    End Sub
    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_PO_Sub_List.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.STATUS_ID = stat
            dao.update()

            Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            '--------------------ผูกพัน------------------------
            dao_app.fields.BILL_TYPE = bt
            '------------------------------------------------
            dao_app.fields.DATE_ADD = Date.Now
            dao_app.fields.FK_IDA = item("BUDGET_DISBURSE_BILL_ID").Text
            dao_app.fields.IDENTITY_NUMBER = iden
            dao_app.fields.REASON_DATE = date_input
            dao_app.fields.STATUS_ID = stat
            dao_app.fields.GROUP_ID = 0

            dao_app.insert()

        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rg_PO_Sub_List.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(item("RELATE_ID").Text)
            dao.fields.IS_APPROVE = False
            dao.fields.APPROVE_DATE = Nothing

            dao.update()
        Next
    End Sub
End Class