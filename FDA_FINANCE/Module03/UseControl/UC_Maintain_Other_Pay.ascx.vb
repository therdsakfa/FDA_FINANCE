Imports Telerik.Web.UI
Public Class UC_Maintain_Other_Pay
    Inherits System.Web.UI.UserControl
    Private _bgYear As Integer
    Public Property bgYear() As Integer
        Get
            Return _bgYear
        End Get
        Set(ByVal value As Integer)
            _bgYear = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgOtherPay_Init(sender As Object, e As EventArgs) Handles rgOtherPay.Init
        Dim rg_Debtor As RadGrid = rgOtherPay
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgOtherPay
        Rad_Utility.addColumnBound("ID_RUN", "ID_RUN", False)
        Rad_Utility.addColumnBound("BUDGET_YEAR", "ปีงบประมาณ")
        Rad_Utility.addColumnDate("DO_DATE", "วันที่บันทึก")
        Rad_Utility.addColumnBound("DO_TYPE", "ประเภท")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายละเอียด")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        'Rad_Utility.addColumnIMG("R", "แบบขอถอนเงินทดรองราชการเพื่อสำรองจ่าย", "R", 0, "", img:=True, type_img:="report")
        Rad_Utility.addColumnIMG("C", "พิมพ์เช็ค", "C", 0, "", img:=True, type_img:="check")
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgOtherPay, str)
    End Sub
    Public Sub rebind_grid()
        rgOtherPay.Rebind()
    End Sub

    Private Sub rgOtherPay_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgOtherPay.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_MAINTAIN.TB_OTHER_PAY
                dao.Getdata_by_ID(item("ID_RUN").Text)
                dao.delete()
                rgOtherPay.Rebind()             
            End If
        End If
    End Sub

    Private Sub rgOtherPay_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgOtherPay.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("ID_RUN").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            h2.Attributes.Add("OnClick", "return k(" & id & ");")
            'Dim btn_report As ImageButton = DirectCast(item("R").Controls(0), ImageButton)
            Dim btn_chk As ImageButton = DirectCast(item("C").Controls(0), ImageButton)
            Dim pay_date As Date = item("DO_DATE").Text
            Dim url_retport As String = "../Module03/Report/Frm_Report_R3_010.aspx?date=" & pay_date
            Dim url_chk As String = "../Module09/Report/Frm_Report_R9_001.aspx?bid=" & id & "&flag=ot"
            'btn_report.Attributes.Add("OnClick", "window.open('" & url_retport & "');")
            btn_chk.Attributes.Add("OnClick", "window.open('" & url_chk & "');")
        End If
    End Sub

    Private Sub rgOtherPay_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgOtherPay.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_pay_other(bgYear)
        rgOtherPay.DataSource = dt
    End Sub
End Class