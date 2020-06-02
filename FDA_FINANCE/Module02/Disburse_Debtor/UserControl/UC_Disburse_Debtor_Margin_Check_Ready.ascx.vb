Imports Telerik.Web.UI

Public Class UC_Disburse_Debtor_Margin_Check_Ready
    Inherits System.Web.UI.UserControl
    Private _bg_use As String
    Public Property bg_use() As String
        Get
            Return _bg_use
        End Get
        Set(ByVal value As String)
            _bg_use = value
        End Set
    End Property

    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
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
    Private _debtor_type As Integer
    Public Property debtor_type() As Integer
        Get
            Return _debtor_type
        End Get
        Set(ByVal value As Integer)
            _debtor_type = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rg_check_sign_Init(sender As Object, e As EventArgs) Handles rg_check_ready.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_check_ready
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่หนังสือ")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อลูกหนี้")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        'Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข GFMIS")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnBound("stat", "สถานะ")
    End Sub

    Private Sub rg_check_sign_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_check_ready.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

        dt = bao.get_debtor_bill_by_stat_group(bg_use, bgyear, stat - 1, g, debtor_type)
        dt.Columns.Add("stat")
        For Each dr As DataRow In dt.Rows
            If dr("STATUS_ID") >= stat Then
                dr("stat") = "พร้อมจ่ายเช็ค"
            Else
                dr("stat") = "-"
            End If
        Next
        rg_check_ready.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_check_ready, str)
    End Sub
    Public Sub rebind_grid()
        rg_check_ready.Rebind()
    End Sub

    Public Sub update_true(ByVal date_input As Date, ByVal iden As String)
        For Each item As GridDataItem In rg_check_ready.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            dao.fields.STATUS_ID = stat
            dao.fields.GROUP_ID = g
            dao.update()

            Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            dao2.fields.STATUS_ID = stat
            dao2.fields.GROUP_ID = g
            dao2.fields.REASON_DATE = date_input
            dao2.fields.IDENTITY_NUMBER = iden
            dao2.fields.DATE_ADD = Date.Now
            dao2.fields.FK_IDA = item("DEBTOR_BILL_ID").Text
            dao2.insert()
        Next
    End Sub
End Class