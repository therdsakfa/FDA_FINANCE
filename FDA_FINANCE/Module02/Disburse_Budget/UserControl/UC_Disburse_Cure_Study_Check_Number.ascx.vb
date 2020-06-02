Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Study_Check_Number
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
    Private _Bill_type As Integer
    Public Property Bill_type() As Integer
        Get
            Return _Bill_type
        End Get
        Set(ByVal value As Integer)
            _Bill_type = value
        End Set
    End Property
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgPayPass_chk_Init(sender As Object, e As EventArgs) Handles rgCure_Study_chk.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgCure_Study_chk
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขหนังสือ")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่หนังสือ")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("DEEKA_NUMBER", "เลขฎีกา")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnDate("CHECK_DATE", "วันที่เช็ค")
        Rad_Utility.addColumnButton("S", "เพิ่ม/แก้ไขข้อมูล", "S", 0, "", headertext:="สถานะ")
    End Sub

    Private Sub rgPayPass_chk_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgCure_Study_chk.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)

            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim url As String = "../../Module02/Disburse_Budget/Frm_Disburse_Cure_Check_Number_Insert.aspx?bid=" & id & "&bt=" & _bt & "&stat=" & _stat & "&g=" & g
            h2.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
        End If
    End Sub

    Private Sub rgPayPass_chk_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgCure_Study_chk.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dt = bao.get_cure_study_check_number(bgyear, stat - 1, g, Bill_type)
        rgCure_Study_chk.DataSource = dt
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgCure_Study_chk, str)
    End Sub
    Public Sub rebind_grid()
        rgCure_Study_chk.Rebind()
    End Sub
End Class