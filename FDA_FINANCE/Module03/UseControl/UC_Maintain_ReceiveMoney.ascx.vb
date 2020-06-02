Imports Telerik.Web.UI

Public Class UC_Maintain_ReceiveMoney
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'BudgetYear = Request.QueryString("bgyear")
    End Sub

    Private Sub rgReceiveMoney_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgReceiveMoney.Init
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgReceiveMoney
        Rad_Utility.addColumnBound("Row_num", "ลำดับที่", width:=70)
        Rad_Utility.addColumnBound("RECEIVE_MONEY_ID", "RECEIVE_MONEY_ID", False)
        Rad_Utility.addColumnBound("FULLNAME", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnBound("RECEIVE_MONEY_TYPE", "ประเภทเงินที่รับ")
        Rad_Utility.addColumnBound("RECEIVE_MONEY_DESCRIPTION", "รายการ", width:=300)
        Rad_Utility.addColumnBound("RECEIVE_AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("RECEIVER_NAME", "ผู้นำส่งเงิน")
        Rad_Utility.addColumnButton("P", "พิมพ์ใบเสร็จ", "P", 0, "", width:=120)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)



        'Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgReceiveMoney_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgReceiveMoney.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Delete" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao_return_money.Getdata_by_RECEIVE_MONEY_ID(item("RECEIVE_MONEY_ID").Text)
                dao_return_money.delete()
                Response.Redirect("Frm_Maintain_ReceiveMoney.aspx")
                'ElseIf e.CommandName = "E" Then
                '    Response.Redirect("Frm_Maintain_ReceiveMoney_Edit.aspx?RECEIVE_MONEY_ID=" & item("RECEIVE_MONEY_ID").Text)
            End If
        End If
    End Sub

    Private Sub rgReturnMoney_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgReceiveMoney.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_RECEIVE_MONEY_by_BUDGET_YEAR(BudgetYear)
        rgReceiveMoney.DataSource = dt
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgReceiveMoney)
    End Sub

    Private Sub rgReturnMoney_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgReceiveMoney.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            If item("RECEIVE_MONEY_TYPE").Text = "1" Then
                item("RECEIVE_MONEY_TYPE").Text = "เงินสด"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "2" Then
                item("RECEIVE_MONEY_TYPE").Text = "เช็ค"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "3" Then
                item("RECEIVE_MONEY_TYPE").Text = "โอน"
            ElseIf item("RECEIVE_MONEY_TYPE").Text = "4" Then
                item("RECEIVE_MONEY_TYPE").Text = "ยกเลิก"
            End If

            'Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?ID=" & dao_maintain_receive_money.fields.RECEIVE_MONEY_ID)
            Dim id As Integer = item("RECEIVE_MONEY_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim P As LinkButton = DirectCast(item("P").Controls(0), LinkButton)
            Dim url As String = "Frm_Maintain_ReceiveMoney_Edit.aspx?RECEIVE_MONEY_ID=" & id & "&bgyear=" & BudgetYear
            Dim url_p As String = "../Module09/Report/Frm_Report_R9_003.aspx?ID=" & id
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            P.Attributes.Add("OnClick", "Popups3('" & url_p & "'); return false;")

        End If
    End Sub

    Public Sub rebindRg()
        rgReceiveMoney.Rebind()
    End Sub
End Class