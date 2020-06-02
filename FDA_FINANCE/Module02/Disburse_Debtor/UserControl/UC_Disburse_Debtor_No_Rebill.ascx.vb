Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_No_Rebill
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

    Private Sub rg_Disburse_Debtor_No_Rebill_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Debtor_No_Rebill.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Debtor_No_Rebill
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        Rad_Utility.addColumnBound("app", "app", False)
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
        Rad_Utility.addColumnIMG("Delete", "แก้ไขข้อมูล", "DeleteCol", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_Disburse_Debtor_No_Rebill_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Disburse_Debtor_No_Rebill.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                dao.delete()
                dao_detail.delete()
                rg_Disburse_Debtor_No_Rebill.Rebind()
            End If

        End If
    End Sub

    Private Sub rg_Disburse_Debtor_No_Rebill_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Debtor_No_Rebill.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim dao_a As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            Dim co As Integer = 0

            Try
                co = dao_a.count_approve(item("BUDGET_DISBURSE_BILL_ID").Text, bt, stat)
            Catch ex As Exception

            End Try
            If co >= 0 Then
                img.ImageUrl = "~/images/cb.png"
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If
        End If
    End Sub

    Private Sub rg_Disburse_Debtor_No_Rebill_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Disburse_Debtor_No_Rebill.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.get_no_rebillV2(BudgetUseID, BudgetYear)
        rg_Disburse_Debtor_No_Rebill.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Debtor_No_Rebill, str)
    End Sub
    Public Sub rg_rebind()
        rg_Disburse_Debtor_No_Rebill.Rebind()
    End Sub
    Public Sub update_true(ByVal date_input As Date)
        For Each item As GridDataItem In rg_Disburse_Debtor_No_Rebill.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input
            dao.update()
        Next
    End Sub
    Public Sub insert_approve(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_Disburse_Debtor_No_Rebill.SelectedItems
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
    Public Sub update_false()
        For Each item As GridDataItem In rg_Disburse_Debtor_No_Rebill.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            dao.fields.IS_APPROVE = False

            dao.update()
        Next
    End Sub
    Public Function chk_selected() As Boolean
        Dim bool As Boolean = False
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Debtor_No_Rebill.SelectedItems
            item_c += 1
        Next
        If item_c > 0 Then
            bool = True
        End If
        Return bool
    End Function
    Public Function chk_selected_count() As Integer
        Dim item_c As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Debtor_No_Rebill.SelectedItems
            item_c += 1
        Next
        Return item_c
    End Function
    Public Sub open_reject_note()
        Dim bill_id As Integer = 0
        For Each item As GridDataItem In rg_Disburse_Debtor_No_Rebill.SelectedItems
            bill_id = item("BUDGET_DISBURSE_BILL_ID").Text
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('Frm_Reason.aspx?fk_ida=" & bill_id & "&bt=" & bt & "&stat=" & stat - 1 & "&g=" & g & "');", True)
    End Sub
End Class