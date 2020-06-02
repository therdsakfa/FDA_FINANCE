Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Margin
    Inherits System.Web.UI.UserControl
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _bguse As Integer
    Public Property bguse() As Integer
        Get
            Return _bguse
        End Get
        Set(ByVal value As Integer)
            _bguse = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_Debtor_Margin_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Debtor_Margin.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Debtor_Margin
        Rad_Utility.addColumnIMG("img", "")
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnDate("CHECK_DATE", "วันที่ของเช็ค")
        Rad_Utility.addColumnCheckbox("CHECK_APPROVE", "สถานะเช็คลงนาม")
        Rad_Utility.addColumnDate("CHECK_APPROVE_DATE", "วันที่ลงนามเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_READY", "เช็คพร้อมจ่าย")
        Rad_Utility.addColumnDate("CHECK_READY_DATE", "วันที่พร้อมจ่ายเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_RECEIVE", "สถานะการจ่าย")
        Rad_Utility.addColumnDate("CHECK_RECEIVE_DATE", "วันที่จ่าย")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันครบกำหนดชำระเงินคืน")
        'Rad_Utility.addColumnBound("rebill", "การวางเบิก")
        Rad_Utility.addColumnBound("digit", "สถานะ", False)
        Rad_Utility.addColumnButton("E", "เพิ่มข้อมูลสถานะ", "E", 0, "")
        'Rad_Utility.addColumnIMG("C", "พิมพ์เช็ค", "C", 0, "", img:=True, type_img:="report")
    End Sub

    Private Sub rg_Disburse_Debtor_Margin_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Disburse_Debtor_Margin.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    Select Case bguse
        '        Case 1
        '            Response.Redirect("../Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & item("DEBTOR_BILL_ID").Text)
        '        Case 3
        '            Response.Redirect("/Module05/Disburse_OutsideDebtor/Frm_Disburse_OutsideDebtor_Margin_Status_Add.aspx?bid=" & item("DEBTOR_BILL_ID").Text)
        '    End Select
        '    'If e.CommandName = "E" Then

        '    '   End If
        'End If
    End Sub

    Private Sub rg_Disburse_Debtor_Margin_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Debtor_Margin.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            'Dim btn_chk As ImageButton = DirectCast(item("C").Controls(0), ImageButton)
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getDebtorstatusMargin(id)
            Dim linktype1 As String
            Dim linktype3 As String
            linktype1 = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Status_Add.aspx?bid=" & id & "&dept=" & Request.QueryString("dept")
            linktype3 = "../../Module02/Disburse_Debtor/Frm_Disburse_OutsideDebtor_Margin_Status_Add.aspx?bid=" & id & "&dept=" & Request.QueryString("dept")
            Dim url_chk As String = "../../../Module09/Report/Frm_Report_R9_001.aspx?id=" & id & "&flag=debtor"
            'btn_chk.Attributes.Add("Target", "_blank")
            'btn_chk.PostBackUrl = url_chk
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            If bguse = 1 Or bguse = 2 Then
                'h2.PostBackUrl = linktype1
                h2.Attributes.Add("OnClick", "Popups('" & linktype1 & "'); return false;")
            ElseIf bguse = 3 Then
                'h2.PostBackUrl = linktype3
                h2.Attributes.Add("OnClick", "Popups('" & linktype3 & "'); return false;")
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
            'ElseIf bguse = 3 Then
            '    h2.PostBackUrl = linktype3
            '    Select Case digit
            '        Case 4
            '            h2.Text = "เสร็จสิ้น"

            '        Case 3
            '            h2.Text = "รอการพิจารณาวางเบิก"

            '        Case 2
            '            h2.Text = "รอรับเช็ค"

            '        Case 1
            '            h2.Text = "รออนุมัติเช็ค"

            '        Case 0
            '            h2.Text = "รอบันทึกเลขที่เช็ค"

            '    End Select

            'End If


        End If
    End Sub

    Private Sub rg_Disburse_Debtor_Margin_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Disburse_Debtor_Margin.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = BudgetBill.get_debtor_margin_all(BudgetYear, bguse)
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim uti_digit As New Utility_other
        dt.Columns.Add("digit")
        dt.Columns.Add("rebill")

        For i As Integer = 0 To dt.Rows.Count - 1
            dao.Getdata_by_DEBTOR_BILL_ID(dt(i).Item("DEBTOR_BILL_ID"))
            Dim str As String = ""
            If dao.fields.REBILL_ID IsNot Nothing Then
                If dao.fields.REBILL_ID = 2 Then
                    str = "ไม่วางเบิก"
                Else
                    str = "วางเบิก"
                End If
            Else
                str = ""
            End If
            Select Case uti_digit.getDebtorstatusMargin(dt(i).Item("DEBTOR_BILL_ID"))
                Case "4"
                    dt(i).Item("digit") = "เสร็จสิ้น"
                    dt(i).Item("rebill") = str
                Case "3"
                    dt(i).Item("digit") = "รอบันทึกการจ่าย"
                    dt(i).Item("rebill") = str
                    dt(i).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(i).Item("DEADLINE_DATE") = DBNull.Value
                Case "2"
                    dt(i).Item("digit") = "รออนุมัติพร้อมจ่าย"
                    dt(i).Item("rebill") = str
                    dt(i).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(i).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(i).Item("DEADLINE_DATE") = DBNull.Value
                Case "1"
                    dt(i).Item("digit") = "รอการรับเช็ค"
                    dt(i).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(i).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(i).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(i).Item("DEADLINE_DATE") = DBNull.Value
                    dt(i).Item("rebill") = str
                Case "0"
                    dt(i).Item("digit") = "รอบันทึกเลขที่เช็ค"
                    dt(i).Item("CHECK_DATE") = DBNull.Value
                    dt(i).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(i).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(i).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                    dt(i).Item("DEADLINE_DATE") = DBNull.Value
                    dt(i).Item("rebill") = str
            End Select

        Next

        rg_Disburse_Debtor_Margin.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Debtor_Margin, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Debtor_Margin)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rg_Disburse_Debtor_Margin.Rebind()
    End Sub
End Class