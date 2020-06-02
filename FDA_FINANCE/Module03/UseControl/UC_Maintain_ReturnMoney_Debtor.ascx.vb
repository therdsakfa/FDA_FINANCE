Imports Telerik.Web.UI

Public Class UC_Maintain_ReturnMoney_Debtor
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

    Private Sub rgReturnMoneyDebtor_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgDebtor.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        'Rad_Utility.addColumnBound("DEBTOR_TYPE_ID", "DEBTOR_TYPE_ID", False)
        Rad_Utility.addColumnBound("Fullname", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันที่ครบกำหนดคืน")
        'Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่บย.")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่ยืม", is_money:=True)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินที่คืน", is_money:=True)
        Rad_Utility.addColumnBound("return_status", "สถานะการคืนเงิน")
        'Rad_Utility.addColumnButton("I", "คืนเงิน", "I", 0, "คุณต้องการเพิ่มข้อมูลหรือไม่", )
        'Rad_Utility.addColumnButton("E", "แก้ไข", "E", 0, "คุณต้องการแก้ไขข้อมูลหรือไม่")
        'Rad_Utility.addColumnButton("D", "ลบ", "D", 0, "คุณต้องการลบข้อมูลหรือไม่")
        Rad_Utility.addColumnBound("MONEYTYPE", "ประเภทเงิน")
        Rad_Utility.addColumnButton("I", "คืนเงิน", "I", 0, "")
        '' Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
        Rad_Utility.addColumnBound("sorting", "sorting", sort:="sorting", Display:=False)
    End Sub

    Private Sub rgReceiveMoney_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgDebtor.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'If e.CommandName = "I" Then
            '    Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text)
            'Else
            If e.CommandName = "E" Then
                ' Response.Redirect("Frm_Maintain_ReturnMoney_Debtor_Edit.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text)
            ElseIf e.CommandName = "D" Then
                Dim dao_return_money As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                dao_return_money.Getdata_by_DEBTOR_ID(item("DEBTOR_BILL_ID").Text)
                dao_return_money.delete()
                'Response.Redirect("Frm_Maintain_ReturnMoney_Debtor.aspx")
            End If
        End If
    End Sub

    Private Sub rgDebtor_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtor.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_DEBTOR_BILL_in_BUDGET_V2(bgyear)


        'Check เงินคืน ที่มาเป็น Null เปลี่ยนเป็น 0
        'For Each dr As DataRow In dt.Rows
        '    If IsDBNull(dr("RETURN_AMOUNT")) Then
        '        dr("RETURN_AMOUNT") = "0.0000"
        '    End If
        'Next

        dt.Columns.Add("sorting", Type.GetType("System.Int32"))
        dt.Columns.Add("RETURN_AMOUNT", Type.GetType("System.Double"))

        For Each dr As DataRow In dt.Rows
            Dim bao_return_Amount As New BAO_BUDGET.MASS
            Dim return_Amount As Double = bao_return_Amount.get_debtor_return_amount(dr("DEBTOR_BILL_ID"))
            dr("RETURN_AMOUNT") = return_Amount
        Next

        For Each dr2 As DataRow In dt.Rows
            If CDbl(dr2("RETURN_AMOUNT")) = CDbl(dr2("AMOUNT")) Then
                dr2.Delete()
            End If
        Next

        rgDebtor.DataSource = dt
    End Sub
    Public Sub rebind_rg()
        rgDebtor.Rebind()
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDebtor)
    End Sub

    Public Sub rgFilter(ByVal str As String) 'ค้นหาข้อมูล
        Dim util As New Utility_other
        util.filter_rg(rgDebtor, str)
    End Sub

    Private Sub rgReturnMoneyDebtor_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgDebtor.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem

            item = e.Item
            Dim a As LinkButton = DirectCast(item("I").Controls(0), LinkButton)
            ' Dim edit As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url_edit As String = "../Module03/Frm_Maintain_ReturnMoney_Debtor_Edit.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim url As String = "../../Module03/Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & id
            'a.Attributes.Add("OnClick", "return insert_return('" & url & "');")
            a.PostBackUrl = url
            Dim Return_amount As Integer = 0
            Dim Amount As Integer = 0
            Try
                Return_amount = CInt(item("RETURN_AMOUNT").Text)
            Catch ex As Exception

            End Try

            Try
                Amount = CInt(item("AMOUNT").Text)
            Catch ex As Exception

            End Try
            'MONEYTYPE
            Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL()
            dao_debtor.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            If dao_debtor.fields.DEBTOR_BILL_ID <> 0 Then
                If dao_debtor.fields.REBILL_ID = 1 Then
                    If dao_debtor.fields.MOVEDATE IsNot Nothing Then
                        item("MONEYTYPE").Text = "เงินงบประมาณ"
                    End If
                End If
            End If

            If Return_amount = 0 Then
                item("return_status").Text = "ยังไม่คืนเงิน"
                item("sorting").Text = "1"

            ElseIf Return_amount > 0 And Return_amount < Amount Then
                item("return_status").Text = "คืนเงินยังไม่ครบ"
                item("sorting").Text = "2"

            ElseIf Return_amount = Amount Then
                'item.Attributes.Add("Display", "none") ' = False
                item("return_status").Text = "คืนเงินครบแล้ว"
                item("sorting").Text = "4"

            ElseIf Return_amount > Amount Then
                'item.Display = False
                'item.Attributes.Add("Display", "none")
                item("return_status").Text = "คืนเงินเกิน"
                item("sorting").Text = "3"

            End If
        End If
    End Sub
    'Public Sub sort_grid()
    '        Dim sortExpr As New GridSortExpression()
    '    sortExpr.FieldName = "sorting"
    '    sortExpr.SortOrder = GridSortOrder.Descending
    '        'Add sort expression, which will sort against first column
    '    rgDebtor.MasterTableView.SortExpressions.AddSortExpression(sortExpr)
    '    rgDebtor.Rebind()
    'End Sub
End Class