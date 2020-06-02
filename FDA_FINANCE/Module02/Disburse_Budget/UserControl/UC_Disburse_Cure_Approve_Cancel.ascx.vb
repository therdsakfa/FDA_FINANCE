Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Approve_Cancel
    Inherits System.Web.UI.UserControl
    Private _BillType As Integer
    Public Property BillType() As Integer
        Get
            Return _BillType
        End Get
        Set(ByVal value As Integer)
            _BillType = value
        End Set
    End Property

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

    Private Sub rgApprove_cancel_Init(sender As Object, e As EventArgs) Handles rgApprove_cancel.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgApprove_cancel
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnButton("A", "ยกเลิกการอนุมัติ", "A", 0, "คุณต้องการยกเลิกการอนุมัติหรือไม่", headertext:="การอนุมัติ")
        Rad_Utility.addColumnDate("DOC_RECEIVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่เบิก", is_money:=True)
    End Sub

    Private Sub rgApprove_cancel_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgApprove_cancel.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "A" Then
                Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
                dao.Getdata_by_CURE_STUDY_ID(CInt(item("CURE_STUDY_ID").Text))
                dao.fields.IS_APPROVE = False
                dao.fields.APPROVE_DATE = System.DateTime.Now
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ทำการอนุมัติใบเบิกเลขที่ " & dao.fields.BILL_NUMBER & " เรียบร้อยแล้ว');", True) 'window.location.href = 'Frm_Disburse_Budget_Approve_Ok.aspx';
                ' Response.Redirect("../Disburse_Budget/Frm_Disburse_Budget_Approve_Ok.aspx")
            End If
        End If
    End Sub

    Private Sub rgApprove_cancel_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgApprove_cancel.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        rgApprove_cancel.DataSource = bao.getApprove_cure_study_bill_cancel(BillType, bgyear)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgApprove_cancel, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgApprove_cancel)
        'rg_Disburse_Budget.Rebind()
    End Sub
End Class