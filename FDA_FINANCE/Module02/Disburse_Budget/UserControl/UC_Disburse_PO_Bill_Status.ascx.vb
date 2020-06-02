Imports Telerik.Web.UI
Public Class UC_Disburse_PO_Bill_Status
    Inherits System.Web.UI.UserControl
    Private _bill_number As String
    Public Property bill_number() As String
        Get
            Return _bill_number
        End Get
        Set(ByVal value As String)
            _bill_number = value
        End Set
    End Property

    Private _doc_number As String
    Public Property doc_number() As String
        Get
            Return _doc_number
        End Get
        Set(ByVal value As String)
            _doc_number = value
        End Set
    End Property
    Private _search_type As Integer
    Public Property search_type() As Integer
        Get
            Return _search_type
        End Get
        Set(ByVal value As Integer)
            _search_type = value
        End Set
    End Property
    Private _cus_name As String
    Public Property cus_name() As String
        Get
            Return _cus_name
        End Get
        Set(ByVal value As String)
            _cus_name = value
        End Set
    End Property
    Private _equal_t As String
    Public Property equal_t() As String
        Get
            Return _equal_t
        End Get
        Set(ByVal value As String)
            _equal_t = value
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
    Private _K_nymber As String
    Public Property K_nymber() As String
        Get
            Return _K_nymber
        End Get
        Set(ByVal value As String)
            _K_nymber = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgPO_Bill_status_Init(sender As Object, e As EventArgs) Handles rgPO_Bill_status.Init
        Dim rg_Debtor As RadGrid = rgPO_Bill_status
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgPO_Bill_status
        Rad_Utility.addColumnBound("BUDGET_DISBURSE_BILL_ID", "BUDGET_DISBURSE_BILL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบ.")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "ขบ.")
        Rad_Utility.addColumnDate("GFMIS_DATE", "วันที่ขบ.")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("status", "สถานะ")
    End Sub

    Private Sub rgPO_Bill_status_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgPO_Bill_status.NeedDataSource
        If search_type = 1 Then
            If bill_number <> "" Then
                Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                Dim dt As DataTable = bao.get_bill_po_by_bill_number(bill_number, bgyear)
                dt.Columns.Add("status")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        uti_stat.return_status_PO_bill(dr("BUDGET_DISBURSE_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                    Next
                End If

                rgPO_Bill_status.DataSource = dt

            End If

        ElseIf search_type = 2 Then
            If doc_number <> "" Then
                Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                Dim dt As DataTable = bao.get_bill_po_by_doc_number(doc_number, bgyear)
                dt.Columns.Add("status")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        uti_stat.return_status_PO_bill(dr("BUDGET_DISBURSE_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                    Next
                End If

                rgPO_Bill_status.DataSource = dt
            End If
        ElseIf search_type = 3 Then
            If cus_name <> "" Then
                Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                Dim dt As DataTable = bao.get_bill_po_by_cus_name(cus_name, bgyear)
                dt.Columns.Add("status")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        uti_stat.return_status_PO_bill(dr("BUDGET_DISBURSE_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                    Next
                End If

                rgPO_Bill_status.DataSource = dt
            End If

        ElseIf search_type = 4 Then
            If cus_name <> "" Then
                Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                Dim dt As New DataTable
                If equal_t = "=" Then
                    dt = bao.get_bill_po_by_Amount_Equal(cus_name, bgyear)
                ElseIf equal_t = ">" Then
                    dt = bao.get_bill_po_by_Amount_More_Than(cus_name, bgyear)
                ElseIf equal_t = "<" Then
                    dt = bao.get_bill_po_by_Amount_Less_Than(cus_name, bgyear)
                End If
                dt.Columns.Add("status")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        uti_stat.return_status_PO_bill(dr("BUDGET_DISBURSE_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                    Next
                End If

                rgPO_Bill_status.DataSource = dt
            End If
        ElseIf search_type = 5 Then
            If K_nymber <> "" Then
                Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                Dim dt As DataTable = bao.get_bill_po_by_k_number(K_nymber, bgyear)
                dt.Columns.Add("status")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        uti_stat.return_status_PO_bill(dr("BUDGET_DISBURSE_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                    Next
                End If

                rgPO_Bill_status.DataSource = dt
            End If
        ElseIf search_type = 6 Then
            If K_nymber <> "" Then
                Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                Dim dt As DataTable = bao.get_bill_po_by_c_number(K_nymber, bgyear)
                dt.Columns.Add("status")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        uti_stat.return_status_PO_bill(dr("BUDGET_DISBURSE_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                    Next
                End If

                rgPO_Bill_status.DataSource = dt
            End If
        End If

    End Sub
    Public Sub rg_rebind()
        rgPO_Bill_status.Rebind()
    End Sub

    Private Sub rgPO_Bill_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgPO_Bill_status.SelectedIndexChanged
        Dim item As GridDataItem = DirectCast(rgPO_Bill_status.SelectedItems(0), GridDataItem)
        Dim id As String = item("BUDGET_DISBURSE_BILL_ID").Text
        Dim uti_stat As New Utility_other
        Dim id_stat As Integer = 0
        id_stat = uti_stat.return_status_PO_bill(id)
        Dim uti_get_url As New Utility_other
        Dim url As String = uti_get_url.get_url_PO_bill(id_stat, id)
        '  System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "');", True)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "k('" & url & "');", True)
    End Sub
End Class