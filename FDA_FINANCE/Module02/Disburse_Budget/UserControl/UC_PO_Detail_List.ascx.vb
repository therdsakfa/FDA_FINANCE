Imports Telerik.Web.UI
Public Class UC_PO_Detail_List
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_PO_Detail_List_Init(sender As Object, e As EventArgs) Handles rg_PO_Detail_List.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_PO_Detail_List
        Rad_Utility.Rad_css_setting(rg_PO_Detail_List)
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        'Rad_Utility.addColumnDate("Bill_RECIEVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        'Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", _display:=False)
        Rad_Utility.addColumnButton("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่")
    End Sub

    Private Sub rg_PO_Detail_List_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_PO_Detail_List.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                ' del_item(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)

                dao_detail.Getdata_by_Disburse_id(item("BUDGET_DISBURSE_BILL_ID").Text)
                Dim period As Integer = 0
                For Each dao_detail.fields In dao_detail.datas
                    period = dao_detail.fields.PERIOD
                    Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                    dao_det.Getdata_by_DETAIL_ID(dao_detail.fields.DETAIL_ID)
                    dao_det.delete()
                Next

                dao_head.delete()


                Dim dao_head2 As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_head2.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao_head.fields.PO_HEAD_ID)
                Dim dao_re As New DAO_DISBURSE.TB_RELATE_DETAIL_PO
                dao_re.Getdata_by_Relate_id_and_period(dao_head2.fields.RELATE_ID, period)
                For Each dao_re.fields In dao_re.datas
                    dao_re.fields.IS_BERG = Nothing
                Next
                dao_re.update()

                rg_PO_Detail_List.Rebind()
                ' Response.Redirect("/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx")
            End If
        End If
    End Sub

    Private Sub rg_PO_Detail_List_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_PO_Detail_List.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim del As LinkButton = DirectCast(item("DeleteColumn").Controls(0), LinkButton)
            Dim url As String = "Frm_Disburse_PO_edit.aspx?bid=" & id & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bgYear=" & dao.fields.BUDGET_YEAR & "&po=1&d=1"
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")

            Dim dao_app As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_app.Getdata_by_BUDGET_DISBURSE_BILL_ID(item("BUDGET_DISBURSE_BILL_ID").Text)
            If dao_app.fields.BUDGET_DISBURSE_BILL_ID <> Nothing Then
                If dao_app.fields.IS_APPROVE = True Then
                    h2.Visible = False
                    del.Visible = False
                End If
            End If


        End If
    End Sub

    Private Sub rg_PO_Detail_List_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_PO_Detail_List.NeedDataSource
        Dim po_detail As New BAO_BUDGET.DISBURSE_BUDGET
        Dim id As String = "0"
        If Request.QueryString("id") <> "" Then
            id = Request.QueryString("id")
        End If
        Dim dt As DataTable = po_detail.get_PO_Detail(id)
        rg_PO_Detail_List.DataSource = dt
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_PO_Detail_List)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rebind_grid()
        rg_PO_Detail_List.Rebind()
    End Sub
End Class