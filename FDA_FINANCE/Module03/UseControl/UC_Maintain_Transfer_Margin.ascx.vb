Imports Telerik.Web.UI
Public Class UC_Maintain_Transfer_Margin
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgTransferMargin_Init(sender As Object, e As EventArgs) Handles rgTransferMargin.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgTransferMargin
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=70)
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("Fullname", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่บย.")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่ยืม", is_money:=True)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินที่คืน", is_money:=True)
        Rad_Utility.addColumnBound("stat", "สถานะการโอนเงิน")
        Rad_Utility.addColumnButton("I", "โอนคืน", "I", 0, "")
    End Sub

    Private Sub rgTransferMargin_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgTransferMargin.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim dao_return_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            dao_return_money.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
            dao_return_money.fields.IS_TRANSFER = True
            dao_return_money.update()
            rgTransferMargin.Rebind()
        End If
    End Sub

    Private Sub rgTransferMargin_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgTransferMargin.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_transfer_margin()
        dt.Columns.Add("stat")
        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("IS_TRANSFER")) = False Then
                If CBool(dr("IS_TRANSFER")) = True Then
                    dr("stat") = "โอนคืนแล้ว"
                End If
            End If
        Next

        rgTransferMargin.DataSource = dt
    End Sub
    Public Sub rebind_rg()
        rgTransferMargin.Rebind()
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgTransferMargin)
    End Sub

    Public Sub rgFilter(ByVal str As String) 'ค้นหาข้อมูล
        Dim util As New Utility_other
        util.filter_rg(rgTransferMargin, str)
    End Sub
End Class