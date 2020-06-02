Imports Telerik.Web.UI
Public Class UC_Budget_Overlap_Approve_Cancel
    Inherits System.Web.UI.UserControl
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
        End Set
    End Property
    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgApproveCancel_Init(sender As Object, e As EventArgs) Handles rgApproveCancel.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgApproveCancel
        Rad_Utility.addColumnBound("OVERLAP_HEAD_ID", "OVERLAP_HEAD_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnButton("A", "ยกเลิกอนุมัติ", "A", 0, "คุณต้องการยกเลิกอนุมัติหรือไม่", headertext:="การอนุมัติ")
        Rad_Utility.addColumnDate("DOC_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("PAYLIST_DESCRIPTION", "ค่าใช้จ่าย")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน ง.ป.ม.", is_money:=True)
    End Sub

    Private Sub rgApproveCancel_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgApproveCancel.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "A" Then
                Dim dao As New DAO_MAS.TB_OVERLAP_HEAD
                dao.Getdata_by_OVERLAP_HEAD_ID(CInt(item("OVERLAP_HEAD_ID").Text))
                dao.fields.OVERLAP_APPROVE = False
                'dao.fields. = System.DateTime.Now
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ทำการยกเลิกการอนุมัติเรียบร้อยแล้ว');", True) 'window.location.href = 'Frm_Disburse_Budget_Approve_Ok.aspx';
                ' Response.Redirect("../Disburse_Budget/Frm_Disburse_Budget_Approve_Ok.aspx")
            End If
        End If
    End Sub

    Private Sub rgApproveCancel_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgApproveCancel.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.get_Overlap_approve_Cancel(Budgetyear, BudgetID)
        rgApproveCancel.DataSource = dt
    End Sub
End Class