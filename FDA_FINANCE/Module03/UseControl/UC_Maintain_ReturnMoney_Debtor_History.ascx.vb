Imports Telerik.Web.UI
Public Class UC_Maintain_ReturnMoney_Debtor_History
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

    Private Sub rgDebtorHistory_Init(sender As Object, e As EventArgs) Handles rgDebtorHistory.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtorHistory
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=70)
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("DEBTOR_TYPE_ID", "DEBTOR_TYPE_ID", False)
        Rad_Utility.addColumnBound("Fullname", "ชื่อ-นามสกุล", width:=200)
        'Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        'Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันที่ครบกำหนดคืน")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่บย.")
        Rad_Utility.addColumnDate("Return_Date", "วันที่คืนเงิน")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่ยืม", is_money:=True)
        Rad_Utility.addColumnBound("RETURN_AMOUNT", "จำนวนเงินที่คืน", is_money:=True)
        Rad_Utility.addColumnBound("MONEY_TYPE", "ประเภทเงิน")
        Rad_Utility.addColumnBound("return_status", "สถานะการคืนเงิน")
        Rad_Utility.addColumnButton("I", "คืนเงิน", "I", 0, "")
        ' Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnBound("sorting", "sorting", sort:="sorting", Display:=False)
    End Sub

    Private Sub rgDebtorHistory_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rgDebtorHistory.ItemDataBound
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '    Dim item As GridDataItem

        '    item = e.Item
        '    Dim a As ImageButton = DirectCast(item("I").Controls(0), ImageButton)
        '    Dim edit As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
        '    Dim url_edit As String = "../Module03/Frm_Maintain_ReturnMoney_Debtor_Edit.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text
        '    a.Style.Add("display", "none")
        '    edit.Style.Add("display", "none")
        '    edit.Attributes.Add("OnClick", "return k('" & url_edit & "');")
        '    If CInt(item("RETURN_AMOUNT").Text) = 0 Then
        '        item("return_status").Text = "ยังไม่คืนเงิน"
        '        item("sorting").Text = "1"
        '        ' a.Text = "คืนเงิน"
        '        'a.PostBackUrl = "../Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & item("DEBTOR_BILL_ID").Text

        '        Dim id As Integer = item("DEBTOR_BILL_ID").Text
        '        Dim url As String = "../Module03/Frm_Maintain_ReturnMoney_Debtor_Insert.aspx?DEBTOR_BILL_ID=" & id
        '        a.Attributes.Add("OnClick", "return insert_return('" & url & "');")
        '        'a.Enabled = True
        '        a.Style.Add("display", "block")
        '        edit.Style.Add("display", "none")
        '    ElseIf CInt(item("RETURN_AMOUNT").Text) > 0 And CInt(item("RETURN_AMOUNT").Text) < CInt(item("AMOUNT").Text) Then
        '        item("return_status").Text = "คืนเงินยังไม่ครบ"
        '        item("sorting").Text = "2"
        '        a.Style.Add("display", "none")
        '        edit.Style.Add("display", "block")
        '        'a.Text = ""
        '        'a.Enabled = False
        '    ElseIf CInt(item("RETURN_AMOUNT").Text) = CInt(item("AMOUNT").Text) Then
        '        item("return_status").Text = "คืนเงินครบแล้ว"
        '        item("sorting").Text = "4"
        '        a.Style.Add("display", "none")
        '        edit.Style.Add("display", "block")
        '        'a.Text = ""
        '        'a.Enabled = False
        '    ElseIf CInt(item("RETURN_AMOUNT").Text) > CInt(item("AMOUNT").Text) Then
        '        item("return_status").Text = "คืนเงินเกิน"
        '        item("sorting").Text = "3"
        '        a.Style.Add("display", "none")
        '        edit.Style.Add("display", "block")
        '        'a.Text = ""
        '        'a.Enabled = False
        '        'Else
        '        '    item("return_status").Text = "ไม่พบสถานะ"


        '    End If
        'End If

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
                ' item.Display = False
                item("return_status").Text = "คืนเงินเกิน"
                item("sorting").Text = "3"

            End If
        End If
    End Sub

    Private Sub rgDebtorHistory_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtorHistory.NeedDataSource
        Dim bao As New BAO_BUDGET.Maintain
        Dim dt As DataTable = bao.get_DEBTOR_BILL_history(bgyear)


        ''Check เงินคืน ที่มาเป็น Null เปลี่ยนเป็น 0
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
            If CDbl(dr2("RETURN_AMOUNT")) <> CDbl(dr2("AMOUNT")) Then
                dr2.Delete()
            End If
        Next



        rgDebtorHistory.DataSource = dt
    End Sub
    Public Sub rebind_rg()
        rgDebtorHistory.Rebind()
    End Sub

    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDebtorHistory)
    End Sub

    Public Sub rgFilter(ByVal str As String) 'ค้นหาข้อมูล
        Dim util As New Utility_other
        util.filter_rg(rgDebtorHistory, str)
    End Sub
End Class