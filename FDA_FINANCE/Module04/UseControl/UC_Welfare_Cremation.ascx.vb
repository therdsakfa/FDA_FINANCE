Imports Telerik.Web.UI

Partial Public Class UC_Welfare_Cremation
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

    Private Sub rgCremation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgCremation.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgCremation
        Rad_Utility.addColumnBound("ALL_WELFARE_ID", "ALL_WELFARE_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("PERSONAL_ID", "เลขบัตรประชาชน")
        Rad_Utility.addColumnBound("NAME", "ชื่อ-นามสกุล", width:=300)
        'Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", footer_txt:="จำนวนเงินรวม : ", width:=250)
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("MONTH_LIVE", "เดือนที่เบิก")
        'Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", footer_txt:="จำนวนเงินรวม : ", width:=250)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgCremation_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgCremation.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "D" Then
                Dim dao_welfare_home As New DAO_WELFARE.TB_ALL_WELFARE_BILL
                dao_welfare_home.Getdata_by_BUDGET_WELFARE_ID(item("ALL_WELFARE_ID").Text)
                dao_welfare_home.delete()
                'Response.Redirect("Frm_Welfare_Cremation.aspx")
                rgCremation.Rebind()
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("Frm_Welfare_Cremation_Edit.aspx?ALL_WELFARE_ID=" & item("ALL_WELFARE_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgCremation_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgCremation.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("ALL_WELFARE_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            h2.Attributes.Add("OnClick", "return k(" & id & ");")

        End If
    End Sub

    Private Sub rgCremation_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgCremation.NeedDataSource
        Dim bao As New BAO_BUDGET.Welfare
        rgCremation.DataSource = bao.get_WELFARE(3, BudgetYear, month_nm)
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgCremation)
    End Sub

    Public Sub rebindRg()
        rgCremation.Rebind()
    End Sub
End Class