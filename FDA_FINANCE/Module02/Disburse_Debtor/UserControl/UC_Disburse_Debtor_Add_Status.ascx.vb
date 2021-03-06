﻿Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Add_Status
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
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.", False)
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        'Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnDate("CHECK_DATE", "วันที่เช็ค")
        Rad_Utility.addColumnCheckbox("CHECK_APPROVE", "สถานะเช็คลงนาม")
        Rad_Utility.addColumnDate("CHECK_APPROVE_DATE", "วันที่ลงนามเช็ค")
        Rad_Utility.addColumnBound("RETURN_APPROVE_NUMBER", "เลขปลดจ่าย")
        Rad_Utility.addColumnDate("RETURN_APPROVE_DATE", "วันที่เลขปลดจ่าย")
        Rad_Utility.addColumnCheckbox("IS_CHECK_READY", "การอนุมัติเช็ค")
        Rad_Utility.addColumnDate("CHECK_READY_DATE", "วันที่อนุมัติเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_RECEIVE", "สถานะการจ่าย")
        Rad_Utility.addColumnDate("CHECK_RECEIVE_DATE", "วันที่จ่าย")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันครบกำหนดชำระเงินคืน")
        Rad_Utility.addColumnBound("digit", "สถานะ", False)
        Rad_Utility.addColumnButton("S", "เพิ่ม/แก้ไขข้อมูล", "S", 0, "", headertext:="สถานะ")
        'Rad_Utility.addColumnIMG("C", "พิมพ์เช็ค", "C", 0, "", img:=True, type_img:="report")


    End Sub

    Private Sub rgStatusAdd_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgStatusAdd.ItemCommand
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
            'Dim url As String
            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            'Dim btn_chk As ImageButton = DirectCast(item("C").Controls(0), ImageButton)
            Dim url_chk As String = "../../Module09/Report/Frm_Report_R9_001.aspx?id=" & id & "&flag=debtor"
            'btn_chk.Attributes.Add("OnClick", "window.open('" & url_chk & "');")
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getBillstatusDebtor_Express(id)
            Dim linktype1 As String
            Dim linktype3 As String
            linktype1 = "Frm_Disburse_Debtor_Add_Status_Detail.aspx?bid=" & id
            linktype3 = "Frm_Disburse_OutsideDebtor_Add_Status_Detail.aspx?bid=" & id
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            If bg_use = 1 Or bg_use = 2 Then
                h2.PostBackUrl = linktype1
                h2.Attributes.Add("OnClick", "Popups('" & linktype1 & "'); return false;")
                Select Case digit
                    Case 5
                        h2.Text = "เสร็จสิ้น"
                    Case 4
                        h2.Text = "รอบันทึกการจ่าย"
                    Case 3
                        h2.Text = "รออนุมัติพร้อมจ่าย"
                    Case 2
                        h2.Text = "รอการบันทึกเลขปลดจ่าย"
                    Case 1
                        h2.Text = "รอการรับเช็ค"
                    Case 0
                        h2.Text = "รอบันทึกเลขที่เช็ค"
                End Select


                If item("digit").Text = "เสร็จสิ้น" Then
                    img.ImageUrl = "~/images/f6.png"
                ElseIf item("digit").Text = "รอบันทึกการจ่าย" Then
                    img.ImageUrl = "~/images/f5.png"
                ElseIf item("digit").Text = "รออนุมัติพร้อมจ่าย" Then
                    img.ImageUrl = "~/images/f4.png"
                ElseIf item("digit").Text = "รอการบันทึกเลขปลดจ่าย" Then
                    img.ImageUrl = "~/images/f3.png"
                ElseIf item("digit").Text = "รอการรับเช็ค" Then
                    img.ImageUrl = "~/images/f2.png"
                ElseIf item("digit").Text = "รอบันทึกเลขที่เช็ค" Then
                    img.ImageUrl = "~/images/f1.png"
                End If
            ElseIf bg_use = 3 Then
                h2.PostBackUrl = linktype3
                h2.Attributes.Add("OnClick", "Popups('" & linktype3 & "'); return false;")
                Select Case digit
                    Case 4
                        h2.Text = "เสร็จสิ้น"
                    Case 3
                        h2.Text = "รอการบันทึกเลขปลดจ่าย"
                    Case 2
                        h2.Text = "รอรับเช็ค"
                    Case 1
                        h2.Text = "รอการอนุมัติเช็ค"
                    Case 0
                        h2.Text = "รอบันทึกเลขที่เช็ค"
                End Select

                If item("digit").Text = "เสร็จสิ้น" Then
                    img.ImageUrl = "~/images/f5.png"
                    'ElseIf item("digit").Text = "รอบันทึกกำหนดคืน" Then
                    '    img.ImageUrl = "/images/f5.png"
                ElseIf item("digit").Text = "รอการบันทึกเลขปลดจ่าย" Then
                    img.ImageUrl = "~/images/f4.png"
                ElseIf item("digit").Text = "รอรับเช็ค" Then
                    img.ImageUrl = "~/images/f3.png"
                ElseIf item("digit").Text = "รออนุมัติพร้อมจ่าย" Then
                    img.ImageUrl = "~/images/f2.png"
                ElseIf item("digit").Text = "รอบันทึกเลขที่เช็ค" Then
                    img.ImageUrl = "~/images/f1.png"
                End If
            End If
           
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
                    dt(j).Item("CHECK_DATE") = DBNull.Value
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(j).Item("DEADLINE_DATE") = DBNull.Value
                Case "1"
                    dt(j).Item("digit") = "รอการรับเช็ค"
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(j).Item("DEADLINE_DATE") = DBNull.Value
                Case "2"
                    dt(j).Item("digit") = "รอการบันทึกเลขปลดจ่าย"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(j).Item("DEADLINE_DATE") = DBNull.Value
                Case "3"
                    dt(j).Item("digit") = "รออนุมัติพร้อมจ่าย"
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(j).Item("DEADLINE_DATE") = DBNull.Value
                Case "4"
                    dt(j).Item("digit") = "รอบันทึกการจ่าย"
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(j).Item("DEADLINE_DATE") = DBNull.Value
                Case "5"
                    dt(j).Item("digit") = "เสร็จสิ้น"
            End Select
        Next


        rgStatusAdd.DataSource = dt
    End Sub
    'Public Sub bindseq()
    '    Dim ut_seq As New Radgrid_Utility
    '    ut_seq.addSeqRG(rgStatusAdd)
    '    'rg_Disburse_Budget.Rebind()
    'End Sub
    Public Sub rg_rebind()
        rgStatusAdd.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgStatusAdd, str)
    End Sub
End Class