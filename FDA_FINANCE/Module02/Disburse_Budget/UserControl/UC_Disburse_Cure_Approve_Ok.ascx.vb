Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Approve_Ok
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

    Private Sub rgApprove_Init(sender As Object, e As EventArgs) Handles rgApprove.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgApprove
        'Rad_Utility.addColumnCheckbox_client("chkColumn", "การอนุมัติ")
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnIMG("img", "การอนุมัติ")
        ' Rad_Utility.addColumnButton("A", "อนุมัติ", "A", 0, "คุณต้องการอนุมัติหรือไม่", headertext:="การอนุมัติ")
        Rad_Utility.addColumnDate("DOC_RECEIVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("MONTH_DIGIT", "เดือนที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "ชื่อเจ้าหนี้")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        'CUSTOMER_NAME
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่เบิก", is_money:=True)
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
    End Sub

    Private Sub rgApprove_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgApprove.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    If e.CommandName = "A" Then
        '        Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
        '        dao.Getdata_by_CURE_STUDY_ID(CInt(item("CURE_STUDY_ID").Text))
        '        dao.fields.IS_APPROVE = True
        '        dao.fields.APPROVE_DATE = System.DateTime.Now
        '        dao.update()
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ทำการอนุมัติใบเบิกเลขที่ " & dao.fields.BILL_NUMBER & " เรียบร้อยแล้ว');", True) 'window.location.href = 'Frm_Disburse_Budget_Approve_Ok.aspx';
        '        ' Response.Redirect("../Disburse_Budget/Frm_Disburse_Budget_Approve_Ok.aspx")
        '    End If
        'End If
    End Sub

    Private Sub rgApprove_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgApprove.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)

            Dim h1 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Disburse_Cure_Edit.aspx?bid=" & item("CURE_STUDY_ID").Text & "&bgyear=" & bgyear
            h1.Attributes.Add("OnClick", "return k('" & url & "');")

            If dao.fields.IS_APPROVE IsNot Nothing Then
                If dao.fields.IS_APPROVE = True Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Else
                img.ImageUrl = "~/images/emp_cb.png"
            End If
        End If
    End Sub

    Private Sub rgApprove_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgApprove.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        rgApprove.DataSource = bao.getApprove_cure_study_bill_ok(BillType, bgyear)
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgApprove, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgApprove)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rgApprove.Rebind()
    End Sub

    'Public Sub update()
    '    For Each item As GridDataItem In rgApprove.Items
    '        Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
    '        dao.Getdata_by_CURE_STUDY_ID(CInt(item("CURE_STUDY_ID").Text))
    '        If item.Selected = True Then
    '            dao.fields.IS_APPROVE = True

    '        Else
    '            dao.fields.IS_APPROVE = False
    '        End If

    '        dao.update()

    '    Next
    'End Sub
    Public Sub update_true()
        For Each item As GridDataItem In rgApprove.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            'If item.Selected = True Then
            If dao.fields.BILL_TYPE_ID = 3 Then
                Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_BILL_ID)
                dao_bill.fields.IS_APPROVE = True
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "อนุมัติใบเบิกจ่ายค่ารักษา/ค่าเล่าเรียนเลขที่หนังสือ " & dao_bill.fields.DOC_NUMBER & " เลขบ." & dao_bill.fields.BILL_NUMBER, "BUDGET_BILL", dao.fields.BUDGET_BILL_ID)
                dao_bill.update()
            End If

            dao.fields.IS_APPROVE = True
            dao.update()
            Dim log2 As New log_event.log
            log2.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "อนุมัติใบเบิกจ่ายค่ารักษา/ค่าเล่าเรียนเลขที่หนังสือ " & dao.fields.DOC_NUMBER & " เลขบ." & dao.fields.BILL_NUMBER, "CURE_STUDY", item("CURE_STUDY_ID").Text)

        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rgApprove.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
            dao.Getdata_by_CURE_STUDY_ID(item("CURE_STUDY_ID").Text)
            'If item.Selected = True Then
            dao.fields.IS_APPROVE = False
            'Else
            '    dao.fields.IS_APPROVE = False
            'End If
            If dao.fields.BILL_TYPE_ID = 3 Then
                Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_BILL_ID)
                dao_bill.fields.IS_APPROVE = False
                dao_bill.update()
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ยกเลิกอนุมัติใบเบิกจ่ายค่ารักษา/ค่าเล่าเรียนเลขที่หนังสือ " & dao_bill.fields.DOC_NUMBER & " เลขบ." & dao_bill.fields.BILL_NUMBER, "BUDGET_BILL", dao.fields.BUDGET_BILL_ID)
            End If
            dao.update()

            Dim log2 As New log_event.log
            log2.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ยกเลิกอนุมัติใบเบิกจ่ายค่ารักษา/ค่าเล่าเรียนเลขที่หนังสือ " & dao.fields.DOC_NUMBER & " เลขบ." & dao.fields.BILL_NUMBER, "CURE_STUDY", item("CURE_STUDY_ID").Text)
        Next
    End Sub
End Class