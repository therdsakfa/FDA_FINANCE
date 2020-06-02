Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_Show_Grid
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtorGrid_Init(sender As Object, e As EventArgs) Handles rgDebtorGrid.Init
        Dim Rad_Utility As New Radgrid_Utility

        Rad_Utility.Rad = rgDebtorGrid
        Rad_Utility.addColumnBound("RETURN_MONEY_DEBTOR_ID", "RETURN_MONEY_DEBTOR_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสารส่งใช้หนี้")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสารส่งใช้หนี้")
        Rad_Utility.addColumnBound("RETURN_TYPE_NAME", "ป. การจ่าย")
        Rad_Utility.addColumnBound("RECEIPT_NUMBER", "เลข บท.")
        Rad_Utility.addColumnBound("DISBURSE_VOLUME", "บ.เล่มที่")
        Rad_Utility.addColumnBound("DISBURSE_NUMBER", "บ.เลขที่")
        Rad_Utility.addColumnBound("RETURN_DESCRIPTION", "รายละเอียดการคืน", width:=400)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินคืน", is_money:=True)
        Rad_Utility.addColumnIMG("E", "แก้ไข", "E", 0, "", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("p", "ใบเสร็จ", "p", 0, "", img:=True, type_img:="report")
        'Rad_Utility.addColumnIMG("n", "แสดง/ไม่แสดงในรายงานใบสำคัญคงเหลือ", "n", 0, "จะกระทำต่อหรือไม่?", img:=True, type_img:="cancel")
        Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgDebtorGrid_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgDebtorGrid.ItemCommand
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem
        '    item = e.Item


        'End If

        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then

                Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                dao_return.delete()
                rgDebtorGrid.Rebind()
                'ElseIf e.CommandName = "n" Then
                '    Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                '    dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
                '    If dao_return.fields.IS_NO_USE_IN_REPORT Is Nothing Then
                '        dao_return.fields.IS_NO_USE_IN_REPORT = True
                '    ElseIf dao_return.fields.IS_NO_USE_IN_REPORT = True Then
                '        dao_return.fields.IS_NO_USE_IN_REPORT = False
                '    ElseIf dao_return.fields.IS_NO_USE_IN_REPORT = False Then
                '        dao_return.fields.IS_NO_USE_IN_REPORT = True
                '    End If
                '    dao_return.update()
                '    rgDebtorGrid.Rebind()
            End If
        End If
    End Sub

    Private Sub rgDebtorGrid_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgDebtorGrid.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("RETURN_MONEY_DEBTOR_ID").Text
            'Dim ins As ImageButton = DirectCast(item("d").Controls(0), ImageButton)
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            'Dim n As ImageButton = DirectCast(item("n").Controls(0), ImageButton)
            Dim btnprint As ImageButton = DirectCast(item("p").Controls(0), ImageButton)
            Dim url As String = "Frm_Maintain_ReturnMoney_Debtor_Edit_Detail.aspx?id=" & id & "&DEBTOR_BILL_ID=" & Request.QueryString("DEBTOR_BILL_ID")
            Dim url_ins As String = "Frm_Maintain_ReturnMoney_Debtor_Insert_Detail.aspx?id=" & id & "&DEBTOR_BILL_ID=" & Request.QueryString("DEBTOR_BILL_ID") & "&flag=1"
            h2.Attributes.Add("OnClick", "return k('" & url & "');")
            ' ins.Attributes.Add("OnClick", "return insert_k('" & url_ins & "');")
            btnprint.PostBackUrl = "../../Module09/Report/Frm_Report_R9_003.aspx?ID=" & id & "&flag=r"
            Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(item("RETURN_MONEY_DEBTOR_ID").Text)
            'If dao_return.fields.PAY_TYPE = 1 Or dao_return.fields.PAY_TYPE > 3 Then
            '    n.Visible = True
            'Else
            '    n.Visible = False
            'End If


            If item("RETURN_TYPE_NAME").Text = "ใบสำคัญ" Then
                Dim p As ImageButton = DirectCast(item("p").Controls(0), ImageButton)
                p.Visible = False
            End If
        End If
    End Sub

    Private Sub rgDebtorGrid_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgDebtorGrid.NeedDataSource
        Dim id As Integer = 0
        id = Request.QueryString("DEBTOR_BILL_ID")
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_debtor_return_money_by_bill_id(id)
        rgDebtorGrid.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rgDebtorGrid.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDebtorGrid)
    End Sub
End Class