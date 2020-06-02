Imports Telerik.Web.UI
Public Class UC_Disburse_OutsideDebtor_Add_Status
    Inherits System.Web.UI.UserControl
    Private _digit As Integer
    Public Property digit() As Integer
        Get
            Return _digit
        End Get
        Set(ByVal value As Integer)
            _digit = value
        End Set
    End Property
    Private _bg_use As Integer
    Public Property bg_use() As Integer
        Get
            Return _bg_use
        End Get
        Set(ByVal value As Integer)
            _bg_use = value
        End Set
    End Property
    Private _debtor_type As Integer
    Public Property debtor_type() As Integer
        Get
            Return _debtor_type
        End Get
        Set(ByVal value As Integer)
            _debtor_type = value
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

    Private Sub rgStatusAdd_Init(sender As Object, e As EventArgs) Handles rgStatusAdd.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgStatusAdd
        Rad_Utility.addColumnIMG("img", "")
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnDate("CHECK_DATE", "วันที่เช็ค")
        Rad_Utility.addColumnCheckbox("CHECK_APPROVE", "สถานะเช็คลงนาม")
        Rad_Utility.addColumnDate("CHECK_APPROVE_DATE", "วันที่ลงนามเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_READY", "การอนุมัติเช็ค")
        Rad_Utility.addColumnDate("CHECK_READY_DATE", "วันที่อนุมัติเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_RECEIVE", "สถานะการจ่าย")
        Rad_Utility.addColumnDate("CHECK_RECEIVE_DATE", "วันที่จ่าย")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันครบกำหนดชำระเงินคืน")
        Rad_Utility.addColumnBound("digit", "สถานะ", False)
        Rad_Utility.addColumnButton("S", "เพิ่ม/แก้ไขข้อมูล", "S", 0, "", headertext:="สถานะ")
    End Sub

    Private Sub rgStatusAdd_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgStatusAdd.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    If e.CommandName = "S" Then
        '        Select Case bg_use
        '            Case 1
        '                Response.Redirect("../Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & item("DEBTOR_BILL_ID").Text)
        '            Case 3
        '                Response.Redirect("../Disburse_OutsideDebtor/Frm_Disburse_OutsideDebtor_Add_Status_Detail.aspx?bid=" & item("DEBTOR_BILL_ID").Text)
        '        End Select

        '    End If
        'End If
    End Sub

    Private Sub rgStatusAdd_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgStatusAdd.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)


            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getBillstatusOutsideDebtor_Express(id)
            Dim linktype1 As String
            Dim linktype2 As String
            linktype1 = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & id
            linktype2 = "Frm_Disburse_OutsideDebtor_Add_Status_Detail.aspx?bid=" & id
            If bg_use = 1 Then
                ' h2.PostBackUrl = linktype1
                h2.Attributes.Add("OnClick", "Popups('" & linktype1 & "'); return false;")
            ElseIf bg_use = 3 Then
                ' h2.PostBackUrl = linktype2
                h2.Attributes.Add("OnClick", "Popups('" & linktype2 & "'); return false;")
            End If

            Select Case digit
                Case 4
                    h2.Text = "เสร็จสิ้น"
                    img.ImageUrl = "~/images/f5.png"
                Case 3
                    h2.Text = "รอบันทึกการจ่าย"
                    img.ImageUrl = "~/images/f4.png"
                Case 2
                    h2.Text = "รออนุมัติพร้อมจ่าย"
                    img.ImageUrl = "~/images/f3.png"
                Case 1
                    h2.Text = "รอการรับเช็ค"
                    img.ImageUrl = "~/images/f2.png"
                Case 0
                    h2.Text = "รอบันทึกเลขที่เช็ค"
                    img.ImageUrl = "~/images/f1.png"
            End Select
            'ElseIf bg_use = 3 Then
            '    h2.PostBackUrl = linktype2
            'Select Case digit
            '    Case 4
            '        h2.Text = "เสร็จสิ้น"

            '    Case 3
            '        h2.Text = "รอการบันทึกบก. อนุมัติ"

            '    Case 2
            '        h2.Text = "รอรับเช็ค"

            '    Case 1
            '        h2.Text = "รอการอนุมัติเช็ค"

            '    Case 0
            '        h2.Text = "รอบันทึกเลขที่เช็ค"

            'End Select

            'End If
        End If
    End Sub

    Private Sub rgStatusAdd_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgStatusAdd.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As DataTable = bao.get_bill_debtor_all(bgyear, bg_use, debtor_type)
        Dim uti_digit As New Utility_other
        dt.Columns.Add("digit")
        For i As Integer = 0 To dt.Rows.Count - 1
            dt(i).Item("digit") = uti_digit.getBillstatusDebtor_Express(dt(i).Item("DEBTOR_BILL_ID"))
        Next
        ' select_digit = "0"
        dt.Select("digit='" & digit & "'")

        Dim dv As New DataView(dt)
        dv.Sort = "digit ASC"
        dt = dv.ToTable
        For j As Integer = 0 To dt.Rows.Count - 1

            Select Case dt(j).Item("digit")
                Case "0"
                    dt(j).Item("digit") = "รอบันทึกเลขที่เช็ค"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_DATE") = DBNull.Value
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                Case "1"
                    dt(j).Item("digit") = "รอการรับเช็ค"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                Case "2"
                    dt(j).Item("digit") = "รออนุมัติพร้อมจ่าย"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                Case "3"
                    dt(j).Item("digit") = "รอบันทึกการจ่าย"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                Case "4"
                    dt(j).Item("digit") = "เสร็จสิ้น"
            End Select
        Next


        rgStatusAdd.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rgStatusAdd.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgStatusAdd)
        'rg_Disburse_Budget.Rebind()
    End Sub
End Class