Imports Telerik.Web.UI

Public Class UC_Maintain_ReturnMoney_OutsideBudget_Debtor
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtorOutsideBudget_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgDebtorOutsideBudget.Init
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgDebtorOutsideBudget
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("DEBTOR_TYPE_ID", "DEBTOR_TYPE_ID", False)
        Rad_Utility.addColumnBound("Fullname", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่บย.")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่ยืม", is_money:=True)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินที่คืน", is_money:=True)
        Rad_Utility.addColumnBound("return_status", "สถานะการคืนเงิน")
        Rad_Utility.addColumnBound("MONEYTYPE", "ประเภทเงิน")
        Rad_Utility.addColumnIMG("I", "คืนเงิน", "I", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่", img:=True, type_img:="pig")
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        Rad_Utility.addColumnBound("sorting", "sorting", sort:="sorting", Display:=False)
    End Sub

    Private Sub rgDebtorOutsideBudget_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgDebtorOutsideBudget.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'If e.CommandName = "I" Then
            '    Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text)
            'Else
            If e.CommandName = "E" Then
                ' Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Edit.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text)
            ElseIf e.CommandName = "D" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao_return_money.Getdata_by_DEBTOR_ID(item("DEBTOR_BILL_ID").Text)
                dao_return_money.delete()
                'Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_OutsideBudget.aspx")
            End If
        End If
    End Sub

    Private Sub rgDebtorOutsideBudget_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtorOutsideBudget.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_DEBTOR_BILL_out_BUDGET(bgyear)
        rgDebtorOutsideBudget.DataSource = dt

        'Check เงินคืน ที่มาเป็น Null เปลี่ยนเป็น 0
        
        dt.Columns.Add("sorting", Type.GetType("System.Int32"))
        dt.Columns.Add("RETURN_AMOUNT", Type.GetType("System.Double"))

        For Each dr As DataRow In dt.Rows
            Dim bao_return_Amount As New BAO_BUDGET.MASS
            Dim return_Amount As Double = bao_return_Amount.get_debtor_return_amount(dr("DEBTOR_BILL_ID"))
            dr("RETURN_AMOUNT") = return_Amount
        Next
        'For Each dr2 As DataRow In dt.Rows
        '    If CDbl(dr2("RETURN_AMOUNT")) = CDbl(dr2("AMOUNT")) Then
        '        dr2.Delete()
        '    End If
        'Next

        rgDebtorOutsideBudget.DataSource = dt
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDebtorOutsideBudget)
    End Sub

    Public Sub rgFilter(ByVal str As String) 'ค้นหาข้อมูล
        Dim util As New Utility_other
        util.filter_rg(rgDebtorOutsideBudget, str)
    End Sub

    Private Sub rgReturnMoneyDebtorOutsideBudget_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgDebtorOutsideBudget.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem

            item = e.Item
            Dim a As ImageButton = DirectCast(item("I").Controls(0), ImageButton)
             Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim url As String = "../../Module03/Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Insert.aspx?DEBTOR_BILL_ID=" & id
            a.PostBackUrl = url
            If item("RETURN_AMOUNT").Text.Contains("&nbsp") Then
                item("RETURN_AMOUNT").Text = 0
            End If
            If CInt(item("RETURN_AMOUNT").Text) = 0 Then
                item("return_status").Text = "ยังไม่คืนเงิน"
                item("sorting").Text = "1"
               
            ElseIf CInt(item("RETURN_AMOUNT").Text) > 0 And CInt(item("RETURN_AMOUNT").Text) < CInt(item("AMOUNT").Text) Then
                item("return_status").Text = "คืนเงินยังไม่ครบ"
                item("sorting").Text = "2"
               
            ElseIf CInt(item("RETURN_AMOUNT").Text) = CInt(item("AMOUNT").Text) Then
                'item.Display = False
                item("return_status").Text = "คืนเงินครบแล้ว"
                item("sorting").Text = "4"
            
            ElseIf CInt(item("RETURN_AMOUNT").Text) > CInt(item("AMOUNT").Text) Then
                'item.Display = False
                item("return_status").Text = "คืนเงินเกิน"
                item("sorting").Text = "3"
               
            End If
        End If
    End Sub
    Public Sub rg_rebind()
        rgDebtorOutsideBudget.Rebind()
    End Sub
End Class