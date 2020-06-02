Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Budget_PayType
    Inherits System.Web.UI.UserControl
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _digit As Integer
    Public Property digit() As Integer
        Get
            Return _digit
        End Get
        Set(ByVal value As Integer)
            _digit = value
        End Set
    End Property
    Private _select_digit As String
    Public Property select_digit() As String
        Get
            Return _select_digit
        End Get
        Set(ByVal value As String)
            _select_digit = value
        End Set
    End Property
    Private _bg_use As String
    Public Property bg_use() As String
        Get
            Return _bg_use
        End Get
        Set(ByVal value As String)
            _bg_use = value
        End Set
    End Property
    Private _strFilter As String
    Public Property strFilter() As String
        Get
            Return _strFilter
        End Get
        Set(ByVal value As String)
            _strFilter = value
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
    Private _ispo As String
    Public Property ispo() As String
        Get
            Return _ispo
        End Get
        Set(ByVal value As String)
            _ispo = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'rgPayDirect.Rebind()
    End Sub

    Private Sub rgPayDirect_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgPayDirect.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgPayDirect
        Rad_Utility.addColumnIMG("img", "")
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("Bill_RECIEVE_DATE", "Bill_RECIEVE_DATE", False)
        Rad_Utility.addColumnBound("BILL_DATE", "BILL_DATE", False)
        Rad_Utility.addColumnBound("DOC_DATE", "DOC_DATE", False)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("RETURN_APPROVE_NUMBER", "เลขปลดจ่าย")
        Rad_Utility.addColumnDate("RETURN_APPROVE_DATE", "วันที่เลขปลดจ่าย")
        Rad_Utility.addColumnBound("INVOICES_NUMBER", "เลขที่ใบแจ้งหนี้")
        Rad_Utility.addColumnDate("INVOICES_DATE", "วันที่บันทึกเลขที่ใบแจ้งหนี้")
        Rad_Utility.addColumnBound("TAX_NUMBER", "เลขที่ใบกำกับภาษี")
        Rad_Utility.addColumnDate("TAX_DATE", "วันที่บันทึกเลขที่ใบกำกับภาษี")
        Rad_Utility.addColumnBound("RECEIPT_NUMBER", "เลขที่ใบเสร็จ")
        Rad_Utility.addColumnDate("RECEIPT_DATE", "วันที่บันทึกเลขที่ใบเสร็จ")
        Rad_Utility.addColumnCheckbox("IS_RECEIVE_TAX", "รับใบหักภาษี")
        Rad_Utility.addColumnBound("RECEIVER_TAX_NAME", "ชื่อผู้รับใบหักภาษี")
        Rad_Utility.addColumnDate("RECEIVE_TAX_DATE", "วันที่รับใบหักภาษี")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("digit", "สถานะ", False)
        Rad_Utility.addColumnButton("S", "เพิ่ม/แก้ไขข้อมูล", "S", 0, "", headertext:="สถานะ")

    End Sub

    Private Sub rgPayDirect_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgPayDirect.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    Select Case PAY_TYPE_ID
        '        Case 1
        '            If e.CommandName = "S" Then
        '                Response.Redirect("../Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text)
        '            End If
        '        Case 2
        '            If e.CommandName = "S" Then
        '                Response.Redirect("../Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & item("BUDGET_DISBURSE_BILL_ID").Text)
        '            End If
        '    End Select
        'End If
    End Sub

    Private Sub rgPayDirect_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgPayDirect.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)


            Dim id As Integer = item("BUDGET_DISBURSE_BILL_ID").Text
            Dim url As String = "Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & id
            'h2.Attributes.Add("OnClick", "return k('" & url & "');")
            h2.Attributes.Add("OnClick", "Popups('" & url & "'); return false;")
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getBillstatusPay(id)
            'Dim linktype1 As String
            'Dim linktype2 As String
            'linktype1 = "/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct_Edit.aspx?bid=" & id
            'linktype2 = "/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & id

            If PAY_TYPE_ID = 1 Then
                ' h2.PostBackUrl = linktype1
                Select Case digit
                    Case 5
                        h2.Text = "บันทึกข้อมูลครบถ้วน"
                        img.ImageUrl = "~/images/f6.png"
                    Case 4
                        h2.Text = "รอบันทึกการรับใบหักภาษี"
                        img.ImageUrl = "~/images/f5.png"
                    Case 3
                        h2.Text = "รอบันทึกเลขที่ใบเสร็จ"
                        img.ImageUrl = "~/images/f4.png"
                    Case 2
                        h2.Text = "รอบันทึกใบกำกับภาษี"
                        img.ImageUrl = "~/images/f3.png"
                    Case 1
                        h2.Text = "รอบันทึกใบแจ้งหนี้"
                        img.ImageUrl = "~/images/f2.png"
                    Case 0
                        h2.Text = "รอบันทึกเลขปลดจ่าย"
                        img.ImageUrl = "~/images/f1.png"
                End Select
            End If


            'Dim img As Image = DirectCast(item("img").Controls(0), Image)
            'If item("digit").Text = "บันทึกข้อมูลครบถ้วน" Then
            '    img.ImageUrl = "~/images/f4.png"
            'ElseIf item("digit").Text = "รอบันทึกใบกำกับภาษี" Then
            '    img.ImageUrl = "~/images/f3.png"
            'ElseIf item("digit").Text = "รอบันทึกใบแจ้งหนี้" Then
            '    img.ImageUrl = "~/images/f2.png"
            'ElseIf item("digit").Text = "รอบันทึกบก. อนุมัติ" Then
            '    img.ImageUrl = "~/images/f1.png"
            'End If
        End If
    End Sub

    Private Sub rgPayDirect_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgPayDirect.NeedDataSource

        'get_bill_all_sub_po
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable
        If ispo <> "True" Then
            dt = bao.get_bill_all(PAY_TYPE_ID, bgyear, bg_use, ispo)
        Else
            dt = bao.get_bill_all_sub_po(PAY_TYPE_ID, bgyear, bg_use, ispo)
        End If
       
        Dim uti_digit As New Utility_other
        dt.Columns.Add("digit")
        For i As Integer = 0 To dt.Rows.Count - 1
            dt(i).Item("digit") = uti_digit.getBillstatusPay(dt(i).Item("BUDGET_DISBURSE_BILL_ID"))
        Next
        ' select_digit = "0"
        'dt.Select("digit='" & digit & "'")

        Dim dv As New DataView(dt)
        dv.Sort = "digit ASC"
        dt = dv.ToTable
        For j As Integer = 0 To dt.Rows.Count - 1

            Select Case dt(j).Item("digit")

                Case "0"
                    dt(j).Item("digit") = "รอบันทึกเลขปลดจ่าย"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("INVOICES_DATE") = DBNull.Value
                    dt(j).Item("TAX_DATE") = DBNull.Value
                    dt(j).Item("RECEIPT_DATE") = DBNull.Value
                    dt(j).Item("RECEIVE_TAX_DATE") = DBNull.Value
                Case "1"
                    dt(j).Item("digit") = "รอบันทึกใบแจ้งหนี้"
                    dt(j).Item("INVOICES_DATE") = DBNull.Value
                    dt(j).Item("TAX_DATE") = DBNull.Value
                    dt(j).Item("RECEIPT_DATE") = DBNull.Value
                    dt(j).Item("RECEIVE_TAX_DATE") = DBNull.Value
                Case "2"
                    dt(j).Item("digit") = "รอบันทึกใบกำกับภาษี"
                    dt(j).Item("TAX_DATE") = DBNull.Value
                    dt(j).Item("RECEIPT_DATE") = DBNull.Value
                    dt(j).Item("RECEIVE_TAX_DATE") = DBNull.Value
                Case "3"
                    dt(j).Item("digit") = "รอบันทึกเลขที่ใบเสร็จ"
                    dt(j).Item("RECEIPT_DATE") = DBNull.Value
                    dt(j).Item("RECEIVE_TAX_DATE") = DBNull.Value
                Case "4"
                    dt(j).Item("digit") = "รอบันทึกการรับใบหักภาษี"
                    dt(j).Item("RECEIVE_TAX_DATE") = DBNull.Value
                Case "5"
                    dt(j).Item("digit") = "บันทึกข้อมูลครบถ้วน"
            End Select
        Next


        rgPayDirect.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgPayDirect, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgPayDirect)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rgPayDirect.Rebind()
    End Sub
End Class