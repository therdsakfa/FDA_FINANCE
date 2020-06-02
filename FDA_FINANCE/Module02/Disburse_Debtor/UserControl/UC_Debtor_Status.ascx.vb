Imports Telerik.Web.UI
Public Class UC_Debtor_Status
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
    Private _cus_name As String
    Public Property cus_name() As String
        Get
            Return _cus_name
        End Get
        Set(ByVal value As String)
            _cus_name = value
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
    Private _search_type As Integer
    Public Property search_type() As Integer
        Get
            Return _search_type
        End Get
        Set(ByVal value As Integer)
            _search_type = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rgDebtor_status_Init(sender As Object, e As EventArgs) Handles rgDebtor_status.Init
        Dim rg_Debtor As RadGrid = rgDebtor_status
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor_status
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลขขบ.")
        Rad_Utility.addColumnDate("GFMIS_DATE", "วันที่ขบ.")
        Rad_Utility.addColumnBound("CUSTOMER_NAME", "เจ้าหนี้")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงิน", is_money:=True)
        Rad_Utility.addColumnBound("b_type", "ประเภท")
        Rad_Utility.addColumnBound("status", "สถานะ")
    End Sub

    Private Sub rgDebtor_status_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgDebtor_status.NeedDataSource
        If search_type = 1 Then
            If bill_number <> "" Then
                Dim dt As DataTable
                Dim bao_billnum As New BAO_BUDGET.DISBURSE_BUDGET
                dt = bao_billnum.get_debtor_by_bill_number(bill_number, bgyear)
                dt.Columns.Add("status")
                dt.Columns.Add("b_type")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                        dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                        uti_stat.return_status_debtor(dr("DEBTOR_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                                dr("b_type") = "ลูกหนี้เงินงบประมาณ"
                            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                                If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                                    If dao.fields.EXPRESS_TYPE_ID = 1 Then
                                        dr("b_type") = "ลูกหนี้เงินทดรองเงินสด"
                                        If dao.fields.REBILL_ID IsNot Nothing Then
                                            If dao.fields.REBILL_ID = 1 Then
                                                dr("b_type") = "ลูกหนี้เงินทดรองเงินสดวางเบิก"
                                            Else
                                                dr("b_type") = "ลูกหนี้เงินทดรองเงินสดไม่วางเบิก"
                                            End If
                                        End If
                                      
                                    Else
                                        dr("b_type") = "ลูกหนี้เงินทดรอง(เช็ค)"
                                        If dao.fields.REBILL_ID IsNot Nothing Then
                                            If dao.fields.REBILL_ID = 1 Then
                                                dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) วางเบิก"
                                            Else
                                                dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) ไม่วางเบิก"
                                            End If
                                        End If
                                      
                                    End If

                                End If
                            End If
                        End If
                       
                    Next
                End If
                rgDebtor_status.DataSource = dt
            End If
        ElseIf search_type = 2 Then
            If doc_number <> "" Then
                Dim dt As DataTable
                Dim bao_docnum As New BAO_BUDGET.DISBURSE_BUDGET
                dt = bao_docnum.get_debtor_by_doc_number(doc_number, bgyear)
                dt.Columns.Add("status")
                dt.Columns.Add("b_type")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                        dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                        uti_stat.return_status_debtor(dr("DEBTOR_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                                dr("b_type") = "ลูกหนี้เงินงบประมาณ"
                            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                                If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                                    If dao.fields.EXPRESS_TYPE_ID = 1 Then
                                        dr("b_type") = "ลูกหนี้เงินทดรองเงินสด"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดวางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดไม่วางเบิก"
                                        End If
                                    Else
                                        dr("b_type") = "ลูกหนี้เงินทดรอง(เช็ค)"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) วางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) ไม่วางเบิก"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Next
                End If
                rgDebtor_status.DataSource = dt
            End If

        ElseIf search_type = 3 Then
            If cus_name <> "" Then
                Dim dt As DataTable
                Dim bao_docnum As New BAO_BUDGET.DISBURSE_BUDGET
                dt = bao_docnum.get_debtor_by_cus_name(cus_name, bgyear)
                dt.Columns.Add("status")
                dt.Columns.Add("b_type")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                        dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                        uti_stat.return_status_debtor(dr("DEBTOR_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                                dr("b_type") = "ลูกหนี้เงินงบประมาณ"
                            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                                If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                                    If dao.fields.EXPRESS_TYPE_ID = 1 Then
                                        dr("b_type") = "ลูกหนี้เงินทดรองเงินสด"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดวางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดไม่วางเบิก"
                                        End If
                                    Else
                                        dr("b_type") = "ลูกหนี้เงินทดรอง(เช็ค)"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) วางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) ไม่วางเบิก"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Next
                End If
                rgDebtor_status.DataSource = dt
            End If

        ElseIf search_type = 4 Then
            If cus_name <> "" Then
                Dim dt As New DataTable
                Dim bao_equal As New BAO_BUDGET.DISBURSE_BUDGET
                If equal_t = "=" Then
                    dt = bao_equal.get_debtor_by_Amount_Equal(cus_name, bgyear)
                ElseIf equal_t = ">" Then
                    dt = bao_equal.get_debtor_by_Amount_More_than(cus_name, bgyear)
                ElseIf equal_t = "<" Then
                    dt = bao_equal.get_debtor_by_Amount_Less_than(cus_name, bgyear)
                End If

                dt.Columns.Add("status")
                dt.Columns.Add("b_type")
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                        dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                        uti_stat.return_status_debtor(dr("DEBTOR_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                                dr("b_type") = "ลูกหนี้เงินงบประมาณ"
                            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                                If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                                    If dao.fields.EXPRESS_TYPE_ID = 1 Then
                                        dr("b_type") = "ลูกหนี้เงินทดรองเงินสด"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดวางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดไม่วางเบิก"
                                        End If
                                    Else
                                        dr("b_type") = "ลูกหนี้เงินทดรอง(เช็ค)"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) วางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) ไม่วางเบิก"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Next
                End If
                rgDebtor_status.DataSource = dt
            End If

        ElseIf search_type = 5 Then
            If K_nymber <> "" Then
                Dim dt As DataTable
                Dim bao_docnum As New BAO_BUDGET.DISBURSE_BUDGET
                dt = bao_docnum.get_debtor_by_k_number(K_nymber, bgyear)
                dt.Columns.Add("status")
                dt.Columns.Add("b_type")

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                        dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                        uti_stat.return_status_debtor(dr("DEBTOR_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                                dr("b_type") = "ลูกหนี้เงินงบประมาณ"
                            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                                If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                                    If dao.fields.EXPRESS_TYPE_ID = 1 Then
                                        dr("b_type") = "ลูกหนี้เงินทดรองเงินสด"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดวางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดไม่วางเบิก"
                                        End If
                                    Else
                                        dr("b_type") = "ลูกหนี้เงินทดรอง(เช็ค)"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) วางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) ไม่วางเบิก"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Next
                End If
                rgDebtor_status.DataSource = dt
            End If
        ElseIf search_type = 6 Then
            If K_nymber <> "" Then
                Dim dt As DataTable
                Dim bao_docnum As New BAO_BUDGET.DISBURSE_BUDGET
                dt = bao_docnum.get_debtor_by_c_num(K_nymber, bgyear)
                dt.Columns.Add("status")
                dt.Columns.Add("b_type")

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim uti_stat As New Utility_other
                        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                        dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                        uti_stat.return_status_debtor(dr("DEBTOR_BILL_ID"))
                        dr("status") = uti_stat.TextStatus
                        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                                dr("b_type") = "ลูกหนี้เงินงบประมาณ"
                            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                                If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                                    If dao.fields.EXPRESS_TYPE_ID = 1 Then
                                        dr("b_type") = "ลูกหนี้เงินทดรองเงินสด"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดวางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรองเงินสดไม่วางเบิก"
                                        End If
                                    Else
                                        dr("b_type") = "ลูกหนี้เงินทดรอง(เช็ค)"
                                        If dao.fields.REBILL_ID = 1 Then
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) วางเบิก"
                                        Else
                                            dr("b_type") = "ลูกหนี้เงินทดรอง (เช็ค) ไม่วางเบิก"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Next
                End If
                rgDebtor_status.DataSource = dt
            End If
        End If

        'get_debtor_by_c_num
    End Sub

    Public Sub rg_rebind()
        rgDebtor_status.Rebind()
    End Sub
    
    Private Sub rgDebtor_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgDebtor_status.SelectedIndexChanged
        Dim item As GridDataItem = DirectCast(rgDebtor_status.SelectedItems(0), GridDataItem)
        Dim id As String = item("DEBTOR_BILL_ID").Text
        Dim uti_stat As New Utility_other
        Dim id_stat As Integer = 0
        id_stat = uti_stat.return_status_debtor(id)
        Dim uti_get_url As New Utility_other
        Dim url As String = uti_get_url.get_url_debtor(id_stat, id)
        '   System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "');", True)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "k('" & url & "');", True)
        'item.Attributes.Add("Onclick", "k(" & url & "');")

    End Sub
End Class