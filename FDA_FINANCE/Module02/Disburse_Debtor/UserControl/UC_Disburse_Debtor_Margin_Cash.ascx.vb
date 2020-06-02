Imports Telerik.Web.UI
Public Class UC_Disburse_Debtor_Margin_Cash
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

    Private Sub rg_Disburse_Debtor_Margin_Cash_Init(sender As Object, e As EventArgs) Handles rg_Disburse_Debtor_Margin_Cash.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Disburse_Debtor_Margin_Cash
        Rad_Utility.addColumnIMG("img", "")
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        'Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnDate("CHECK_READY_DATE", "วันอนุมัติพร้อมจ่าย")
        Rad_Utility.addColumnDate("PAY_DATE", "วันที่จ่าย")
        Rad_Utility.addColumnDate("DEADLINE_DATE", "วันครบกำหนดชำระเงินคืน")
        Rad_Utility.addColumnBound("rebill", "การวางเบิก")
        'Rad_Utility.addColumnBound("digit", "สถานะ")
        Rad_Utility.addColumnButton("E", "เพิ่มข้อมูลสถานะ", "E", 0, "")
    End Sub

    Private Sub rg_Disburse_Debtor_Margin_Cash_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_Disburse_Debtor_Margin_Cash.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim uti_digit As New Utility_other
            Dim digit As Integer = uti_digit.getDebtorstatusMargin_cash(id)
            Dim linktype1 As String = ""
            Dim linktype3 As String = ""
            linktype1 = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Margin_Cash_Status_Add.aspx?bid=" & id
            linktype3 = "../../Module05/Disburse_OutsideDebtor/Frm_Disburse_OutsideDebtor_Margin_Cash_Status_Add.aspx?bid=" & id
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            If bguse = 1 Or bguse = 2 Then
                'h2.PostBackUrl = linktype1
                h2.Attributes.Add("OnClick", "Popups2('" & linktype1 & "'); return false;")
            ElseIf bguse = 3 Then
                'h2.PostBackUrl = linktype3
                h2.Attributes.Add("OnClick", "Popups2('" & linktype3 & "'); return false;")
            End If
            Select Case digit
                Case 2
                    h2.Text = "เสร็จสิ้น"
                    img.ImageUrl = "~/images/f3.png"
                Case 1
                    h2.Text = "รอบันทึกการจ่าย"
                    img.ImageUrl = "~/images/f2.png"
                Case 0
                    h2.Text = "รออนุมัติพร้อมจ่าย"
                    img.ImageUrl = "~/images/f1.png"

            End Select
        End If
    End Sub

    Private Sub rg_Disburse_Debtor_Margin_Cash_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_Disburse_Debtor_Margin_Cash.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable = BudgetBill.get_debtor_margin_Cash_all(BudgetYear, bguse)
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
                ElseIf dao.fields.REBILL_ID = 1 Then
                    str = "วางเบิก"
                End If
            Else
                str = ""
            End If
            Select Case uti_digit.getDebtorstatusMargin_cash(dt(i).Item("DEBTOR_BILL_ID"))
                Case 2
                    dt(i).Item("digit") = "เสร็จสิ้น"
                    dt(i).Item("rebill") = str
                Case 1
                    dt(i).Item("digit") = "รอบันทึกการจ่าย"
                    dt(i).Item("rebill") = str
                Case 0
                    dt(i).Item("digit") = "รออนุมัติพร้อมจ่าย"
                    dt(i).Item("rebill") = str

            End Select

        Next

        rg_Disburse_Debtor_Margin_Cash.DataSource = dt
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_Disburse_Debtor_Margin_Cash, str)
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Disburse_Debtor_Margin_Cash)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Sub rg_rebind()
        rg_Disburse_Debtor_Margin_Cash.Rebind()
    End Sub
End Class