Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Margin_Change_List
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Debtor_Margin_Init(sender As Object, e As EventArgs) Handles rg_Debtor_Margin.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Debtor_Margin
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnIMG("I", "โอนคืนเงิน", "I", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่", img:=True, type_img:="pig")
        ' Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินที่คืน", is_money:=True)
    End Sub

    Private Sub rg_Debtor_Margin_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_Debtor_Margin.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim a As ImageButton = DirectCast(item("I").Controls(0), ImageButton)
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim url As String = "../../Module03/Frm_Maintain_ReturnMoney_Debtor_Change_List.aspx?id=" & id
            a.PostBackUrl = url
        End If
    End Sub

    Private Sub rg_Debtor_Margin_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Debtor_Margin.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = BudgetBill.get_debtor_margin_all_for_Change(2557)
        dt.Columns.Add("RETURN_AMOUNT")

        Dim dt_return As New DataTable
        dt_return.Columns.Add("DEBTOR_BILL_ID")
        'dt_return.Columns.Add("id")
        dt_return.Columns.Add("BILL_NUMBER")
        dt_return.Columns.Add("BILL_DATE")
        dt_return.Columns.Add("GFMIS_NUMBER")
        dt_return.Columns.Add("DESCRIPTION")
        dt_return.Columns.Add("AMOUNT")
        'dt_return.Columns.Add("RETURN_AMOUNT")
        For Each dr As DataRow In dt.Rows
            Dim bao_return_Amount As New BAO_BUDGET.MASS
            Dim return_Amount As Double = bao_return_Amount.get_debtor_return_amount(dr("DEBTOR_BILL_ID"))
            dr("RETURN_AMOUNT") = return_Amount
        Next

        For Each dr_re As DataRow In dt.Rows
            If dr_re("AMOUNT") = dr_re("RETURN_AMOUNT") Then
                Dim dr_new As DataRow = dt_return.NewRow()
                dr_new("DEBTOR_BILL_ID") = dr_re("DEBTOR_BILL_ID")
                'dr_new("id") = dr_re("id")
                dr_new("BILL_NUMBER") = dr_re("BILL_NUMBER")
                dr_new("BILL_DATE") = dr_re("BILL_DATE")
                dr_new("GFMIS_NUMBER") = dr_re("GFMIS_NUMBER")
                dr_new("DESCRIPTION") = dr_re("DESCRIPTION")
                dr_new("AMOUNT") = dr_re("AMOUNT")

                dt_return.Rows.Add(dr_new)
            End If
        Next


        rg_Debtor_Margin.DataSource = dt_return
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Debtor_Margin)
    End Sub
End Class