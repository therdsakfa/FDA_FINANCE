Imports Telerik.Web.UI

Partial Public Class UC_Welfare_Home
    Inherits System.Web.UI.UserControl

    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _month_nm As String
    Public Property month_nm() As String
        Get
            Return _month_nm
        End Get
        Set(ByVal value As String)
            _month_nm = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgHome_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgHome.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgHome
        Rad_Utility.addColumnBound("ALL_WELFARE_ID", "ALL_WELFARE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("bill_number", "บก.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายละเอียดการเบิก", width:=300)
        Rad_Utility.addColumnBound("MONTH_DIS", "เดือนที่เบิก")
        Rad_Utility.addColumnBound("MONTH_LIVE", "เดือนที่อยู่")
        Rad_Utility.addColumnBound("NAME", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnCheckbox("IS_PAY_HOME", "ไม่จ่ายค่าเช่าบ้าน")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgHome_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgHome.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "D" Then
                Dim dao_welfare_home As New DAO_WELFARE.TB_ALL_WELFARE_BILL
                dao_welfare_home.Getdata_by_BUDGET_WELFARE_ID(item("ALL_WELFARE_ID").Text)
                dao_welfare_home.delete()
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบรายการค่าเช่าบ้าน", _
                               "ALL_WELFARE_BILL", item("ALL_WELFARE_ID").Text)
                rgHome.Rebind()
                'Response.Redirect("Frm_Welfare_Home.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("Frm_Welfare_Home_Edit.aspx?ALL_WELFARE_ID=" & item("ALL_WELFARE_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgHome_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgHome.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("ALL_WELFARE_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "return k(" & id & ");")

        End If
    End Sub

    Private Sub rgHome_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgHome.NeedDataSource
        Dim bao As New BAO_BUDGET.Welfare
        Dim dt As DataTable = bao.get_WELFARE_Home(4, BudgetYear, month_nm)
        rgHome.DataSource = dt
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgHome)
    End Sub

    Public Sub rebindRg()
        rgHome.Rebind()
    End Sub
End Class