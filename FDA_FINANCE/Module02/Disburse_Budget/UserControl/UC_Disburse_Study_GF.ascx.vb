Imports Telerik.Web.UI
Public Class UC_Disburse_Study_GF
    Inherits System.Web.UI.UserControl
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAddKNumber_Init(sender As Object, e As EventArgs) Handles rgAddKNumber.Init
        Dim rg_Approve As RadGrid = rgAddKNumber
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAddKNumber
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "CUSTOMER_NAME", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=45)
        Rad_Utility.addColumnDate("DOC_RECEIVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ", width:=120)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินเบิก", width:=120, is_money:=True)

        Rad_Utility.addColumnButton("A", "บันทึกเลขขบ.", "A", 0, "คุณต้องการเพิ่มเลขขบ. หรือไม่")
    End Sub

    Private Sub rgAddKNumber_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgAddKNumber.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As String = ""
            id = "Frm_Disburse_Study_KNumber_Add.aspx?bid=" & item("CURE_STUDY_ID").Text & "&stat=" & stat & "&g=" & g & "&bt=" & bt
            Dim h2 As LinkButton = DirectCast(item("A").Controls(0), LinkButton)
            'h2.Attributes.Add("OnClick", "return k('" & id & "');")
            h2.Attributes.Add("OnClick", "Popups2('" & id & "'); return false;")

        End If
    End Sub

    Private Sub rgAddKNumber_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgAddKNumber.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = bao.getGF_study(Budgetyear)
        rgAddKNumber.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgAddKNumber, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgAddKNumber)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rgRebind()
        rgAddKNumber.Rebind()
    End Sub
End Class