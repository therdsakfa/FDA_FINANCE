Imports Telerik.Web.UI
Public Class UC_Disburse_Cure_Study_Status
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
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property
    Private _salary_include As Integer
    Public Property salary_include() As Integer
        Get
            Return _salary_include
        End Get
        Set(ByVal value As Integer)
            _salary_include = value
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Disburse_Cure_Study_status_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Cure_Study_status.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Cure_Study_status
        Rad_Utility.addColumnIMG("img", "")
        Rad_Utility.addColumnBound("CURE_STUDY_ID", "CURE_STUDY_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnDate("DOC_RECEIVE_DATE", "วันที่รับเอกสาร")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขที่เบิก")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เบิก")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินที่เบิก", is_money:=True)
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("CHECK_NUMBER", "เลขที่เช็ค")
        Rad_Utility.addColumnDate("CHECK_DATE", "วันที่เช็ค")
        Rad_Utility.addColumnCheckbox("CHECK_APPROVE", "สถานะเช็คลงนาม")
        Rad_Utility.addColumnDate("CHECK_APPROVE_DATE", "วันที่ลงนามเช็ค")
        Rad_Utility.addColumnBound("RETURN_APPROVE_NUMBER", "เลขปลดจ่าย")
        Rad_Utility.addColumnDate("RETURN_APPROVE_DATE", "วันที่ปลดจ่าย")
        Rad_Utility.addColumnCheckbox("IS_CHECK_READY", "เช็คพร้อมจ่าย")
        Rad_Utility.addColumnDate("CHECK_READY_DATE", "วันที่พร้อมจ่ายเช็ค")
        Rad_Utility.addColumnCheckbox("IS_CHECK_RECEIVE", "สถานะการจ่าย")
        Rad_Utility.addColumnDate("CHECK_RECEIVE_DATE", "วันที่จ่าย")
        Rad_Utility.addColumnBound("digit", "สถานะ", False)
        'Rad_Utility.addColumnDate("CHECK_RECEIVE_DATE", "วันที่รับเช็ค")
        Rad_Utility.addColumnButton("S", "", "S", 0, "", headertext:="สถานะ")
        Rad_Utility.addColumnIMG("C", "พิมพ์เช็ค", "C", 0, "", img:=True, type_img:="report")
    End Sub

    Private Sub rg_Disburse_Cure_Study_status_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Disburse_Cure_Study_status.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim h2 As LinkButton = DirectCast(item("S").Controls(0), LinkButton)
            Dim btn_chk As ImageButton = DirectCast(item("C").Controls(0), ImageButton)

            Dim id As Integer = item("CURE_STUDY_ID").Text
            Dim url As String = "Frm_Disburse_Cure_Study_Status_Add.aspx?bid=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")
            Dim url_chk As String = "../../../Module09/Report/Frm_Report_R9_001.aspx?id=" & id
            btn_chk.Attributes.Add("Target", "_blank")
            btn_chk.PostBackUrl = url_chk
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getCure_Study_Status(id)
            'Dim linktype1 As String
            ' Dim linktype2 As String
            'linktype1 = "/Module02/Disburse_Budget/Frm_Disburse_Cure_Study_Status_Add.aspx?bid=" & id
            'linktype2 = "/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass_Edit.aspx?bid=" & id
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            'h2.PostBackUrl = linktype1
            Select Case digit
                Case 5
                    h2.Text = "เสร็จสิ้น"
                    img.ImageUrl = "~/images/f6.png"
                Case 4
                    h2.Text = "รอบันทึกการจ่าย"
                    img.ImageUrl = "~/images/f5.png"
                Case 3
                    h2.Text = "รออนุมัติพร้อมจ่าย"
                    img.ImageUrl = "~/images/f4.png"
                Case 2
                    h2.Text = "รอการบันทึกปลดจ่าย"
                    img.ImageUrl = "~/images/f3.png"
                Case 1
                    h2.Text = "รอการรับเช็ค"
                    img.ImageUrl = "~/images/f2.png"
                Case 0
                    h2.Text = "รอบันทึกเลขที่เช็ค"
                    img.ImageUrl = "~/images/f1.png"
            End Select
        
        End If
    End Sub

    Private Sub rg_Disburse_Cure_Study_status_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Disburse_Cure_Study_status.NeedDataSource
        Dim cure_study_bill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = cure_study_bill.get_cure_study_bill_status(BudgetYear, BillType, salary_include)
        dt.Columns.Add("digit")
        Dim uti_digit As New Utility_other
        For i As Integer = 0 To dt.Rows.Count - 1
            dt(i).Item("digit") = uti_digit.getCure_Study_Status(dt(i)("CURE_STUDY_ID"))
        Next
        dt.Select("digit='" & digit & "'")

        Dim dv As New DataView(dt)
        dv.Sort = "digit ASC"
        dt = dv.ToTable

        For j As Integer = 0 To dt.Rows.Count - 1

            Select Case dt(j).Item("digit")
                'RETURN_BUDGET_DATE
                'CHECK_READY_DATE

                'Case "0"
                '    dt(j).Item("digit") = "รอบันทึกเลขบก. อนุมัติ"
                '    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                '    dt(j).Item("CHECK_DATE") = DBNull.Value
                '    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                '    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                'Case "1"
                '    dt(j).Item("digit") = "รอบันทึกเลขที่เช็ค"
                '    dt(j).Item("CHECK_DATE") = DBNull.Value
                '    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                '    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                'Case "2"
                '    dt(j).Item("digit") = "รออนุมัติเช็ค"
                '    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                '    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                'Case "3"
                '    dt(j).Item("digit") = "รอรับเช็ค"
                '    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                'Case "4"
                '    dt(j).Item("digit") = "เสร็จสิ้น"

                Case "0"
                    dt(j).Item("digit") = "รอบันทึกเลขที่เช็ค"
                    dt(j).Item("CHECK_DATE") = DBNull.Value
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "1"
                    dt(j).Item("digit") = "รอการรับเช็ค"
                    dt(j).Item("CHECK_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "2"
                    dt(j).Item("digit") = "รอการบันทึกปลดจ่าย"
                    dt(j).Item("RETURN_APPROVE_DATE") = DBNull.Value
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "3"
                    dt(j).Item("digit") = "รออนุมัติพร้อมจ่าย"
                    dt(j).Item("CHECK_READY_DATE") = DBNull.Value
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "4"
                    dt(j).Item("digit") = "รอบันทึกการจ่าย"
                    dt(j).Item("CHECK_RECEIVE_DATE") = DBNull.Value
                Case "5"
                    dt(j).Item("digit") = "เสร็จสิ้น"
            End Select
        Next


        rg_Disburse_Cure_Study_status.DataSource = dt
    End Sub
    'getCure_Study_Status
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Cure_Study_status)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rg_Disburse_Cure_Study_status.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Cure_Study_status, str)
    End Sub
End Class