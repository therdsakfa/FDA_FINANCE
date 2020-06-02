Public Partial Class UC_Disburse_OutsideDebtor_Approve_Ok
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgAppOK_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgAppOK.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgAppOK
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ")
        Rad_Utility.addColumnBound("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("GFMIS", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่")
        Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rgAppOK_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAppOK.NeedDataSource
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao.getdata_Approve(3)
        Dim dt As DataTable = dao.dt
        rgAppOK.DataSource = dt
    End Sub
End Class