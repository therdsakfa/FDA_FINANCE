Imports Telerik.Web.UI
Partial Public Class UC_Disburse_Debtor
    Inherits System.Web.UI.UserControl
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Private _BudgetUseID As Integer
    Public Property BudgetUseID() As Integer
        Get
            Return _BudgetUseID
        End Get
        Set(ByVal value As Integer)
            _BudgetUseID = value
        End Set
    End Property
    Private _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value
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
    Private _PAY_TYPE_ID As Integer
    Public Property PAY_TYPE_ID() As Integer
        Get
            Return _PAY_TYPE_ID
        End Get
        Set(ByVal value As Integer)
            _PAY_TYPE_ID = value
        End Set
    End Property
    Private _is_support As Boolean
    Public Property is_support() As Boolean
        Get
            Return _is_support
        End Get
        Set(ByVal value As Boolean)
            _is_support = value
        End Set
    End Property
    Private _sub_BudgetID As Integer
    Public Property sub_BudgetID() As Integer
        Get
            Return _sub_BudgetID
        End Get
        Set(ByVal value As Integer)
            _sub_BudgetID = value
        End Set
    End Property
    Private _bt As Integer
    Public Property bt() As Integer
        Get
            Return _bt
        End Get
        Set(ByVal value As Integer)
            _bt = value
        End Set
    End Property
    Private _stat As Integer
    Public Property stat() As Integer
        Get
            Return _stat
        End Get
        Set(ByVal value As Integer)
            _stat = value
        End Set
    End Property
    Private _g As Integer
    Public Property g() As Integer
        Get
            Return _g
        End Get
        Set(ByVal value As Integer)
            _g = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' rgDebtor.Rebind()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgDebtor_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgDebtor.Init
        Dim rg_Debtor As RadGrid = rgDebtor
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgDebtor
        Rad_Utility.addColumnBound("DEBTOR_BILL_ID", "DEBTOR_BILL_ID", False)
        Rad_Utility.addColumnBound("DEBTOR_TYPE_ID", "DEBTOR_TYPE_ID", False)
        'Rad_Utility.addColumnBound("id", "ลำดับที่")
        Rad_Utility.addColumnCheckbox("IS_APPROVE", "การอนุมัติ", display:=False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ", Display:=False)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("FullName", "ชื่อ-นามสกุลผู้ยืม")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnBound("BILL_NUMBER", "เลขบย.")
        Rad_Utility.addColumnDate("BILL_DATE", "วันที่เลขบย.")
        Rad_Utility.addColumnBound("GFMIS_NUMBER", "เลข ขบ.")
        Rad_Utility.addColumnBound("DESCRIPTION", "รายการ")
        Rad_Utility.addColumnBound("AMOUNT", "จำนวนเงินยืม", is_money:=True)
        ' Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        'Rad_Utility.addColumnBound("status_bill", "สถานะ")
        Rad_Utility.addColumnBound("stat_name", "สถานะ")
        Rad_Utility.addColumnDate("RETURN_BUDGET_DATE", "วันครบกำหนดคืนคลัง")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120, _display:=False)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120, _display:=False)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rgDebtor_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgDebtor.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
                dao_detail.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "ลบสัญญาเงินยืมเลขที่หนังสือ " & _
                               dao.fields.DOC_NUMBER, "DEBTOR_BILL", item("DEBTOR_BILL_ID").Text)

                dao.delete()
                dao_detail.delete()
                rgDebtor.Rebind()
                'Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Budget_Bill.aspx")
                'ElseIf e.CommandName = "E" Then
                ' Response.Redirect("/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" & item("DEBTOR_BILL_ID").Text & "&dept=" & dept_id)
            End If

        End If
    End Sub

    Private Sub rgDebtor_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgDebtor.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("DEBTOR_BILL_ID").Text
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(id)
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            'Dim h3 As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
            Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim h3 As LinkButton = DirectCast(item("DeleteColumn").Controls(0), LinkButton)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim url As String = ""
            If BudgetUseID = 3 Then
                url = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" & id & "&dept=" & dept_id & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bguse=3"
            Else
                url = "../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" & id & "&dept=" & dept_id & "&bgid=" & dao.fields.BUDGET_PLAN_ID & "&bguse=1"
            End If

            'h2.Attributes.Add("OnClick", "return k(" & id & "," & dept_id & "," & dao.fields.BUDGET_PLAN_ID & ");")
            h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            'If item("status_bill").Text = "" Then
            '    item("RETURN_BUDGET_DATE").Text = ""
            'End If
            If item("GFMIS_NUMBER").Text <> "&nbsp;" Then

                h2.Visible = False
                h3.Visible = False
            End If
            If item("app").Text = "1" Then
                h2.Visible = False
                h3.Visible = False
            End If

            Try
                If dao.fields.STATUS_ID >= 3 Then
                    img.ImageUrl = "~/images/cb.png"
                Else
                    img.ImageUrl = "~/images/emp_cb.png"
                End If
            Catch ex As Exception

            End Try

            'If dao.fields.IS_APPROVE IsNot Nothing Then
            '    If dao.fields.IS_APPROVE = True Then
            '        img.ImageUrl = "~/images/cb.png"
            '    Else
            '        img.ImageUrl = "~/images/emp_cb.png"
            '    End If
            'Else
            '    img.ImageUrl = "~/images/emp_cb.png"
            'End If
        End If
    End Sub

    Private Sub rgDebtor_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgDebtor.NeedDataSource
        Dim DebtorBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As DataTable
        If is_support <> True Then
            If BudgetUseID = 3 Then
                dt = DebtorBill.get_DEBTOR_BILL(BudgetYear, BudgetUseID, BudgetID)
            Else
                dt = DebtorBill.get_DEBTOR_BILL_NEW_dept(BudgetYear, BudgetUseID, dept_id)
                '
            End If


        Else
            dt = DebtorBill.get_DEBTOR_BILL_support_dept(BudgetYear, sub_BudgetID, BudgetID)
        End If



        dt.Columns.Add("status_bill")
        dt.Columns.Add("app")
        For Each dr As DataRow In dt.Rows
            dr("status_bill") = status_debt(dr("DEBTOR_BILL_ID"))
            If status_debt(dr("DEBTOR_BILL_ID")) <> "" Then
                If dr("DEBTOR_TYPE_ID") = "2" Then
                    dr("RETURN_BUDGET_DATE") = check_return_date(dr("DEBTOR_BILL_ID"))
                ElseIf dr("DEBTOR_TYPE_ID") = "1" Then
                    Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                    dao.Getdata_by_DEBTOR_BILL_ID(dr("DEBTOR_BILL_ID"))
                    If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
                        If dao.fields.EXPRESS_TYPE_ID = 2 Then
                            dr("RETURN_BUDGET_DATE") = check_return_date(dr("DEBTOR_BILL_ID"))
                        ElseIf dao.fields.EXPRESS_TYPE_ID = 1 Then
                            dr("RETURN_BUDGET_DATE") = DBNull.Value
                        End If
                    End If

                End If

            End If

        Next

        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("IS_APPROVE")) = False Then
                If CBool(dr("IS_APPROVE")) = True Then
                    dr("app") = "1"
                Else
                    dr("app") = "2"
                End If
            Else
                dr("app") = "2"
            End If

        Next

        rgDebtor.DataSource = dt
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgDebtor, str)
    End Sub
    Public Sub rebind_grid()
        'rgDebtor.EnableLinqExpressions = True
        rgDebtor.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgDebtor)
        'rg_Disburse_Budget.Rebind()
    End Sub
    Public Function status_debt(ByVal bill_id As Integer) As String
        Dim str_stat As String = ""
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_margin As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        dao.Getdata_by_DEBTOR_BILL_ID(bill_id)
        dao_margin.Getdata_by_DEBTOR_BILL_ID(bill_id)
        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
            If dao.fields.DEBTOR_TYPE_ID = 2 Then
                If (dao.fields.RETURN_APPROVE_NUMBER <> "" Or dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing) _
                    And (dao.fields.IS_CHECK_RECEIVE = False Or dao.fields.IS_CHECK_RECEIVE Is Nothing) Then
                    str_stat = "เช็คพร้อมจ่าย"
                ElseIf (dao.fields.RETURN_APPROVE_NUMBER <> "" Or dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing) _
                And (dao.fields.IS_CHECK_RECEIVE = True) Then
                    str_stat = "รับเช็คแล้ว"
                End If
            ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
                If dao.fields.EXPRESS_TYPE_ID = 1 Then
                    If dao.fields.IS_APPROVE = True And (dao_margin.fields.IS_PAY = False Or dao_margin.fields.IS_PAY Is Nothing) Then
                        str_stat = "เงินสดพร้อมจ่าย"
                    ElseIf dao.fields.IS_APPROVE = True And dao_margin.fields.IS_PAY = True Then
                        str_stat = "รับเงินสดแล้ว"
                    End If
                ElseIf dao.fields.EXPRESS_TYPE_ID = 2 Then
                    If dao_margin.fields.CHECK_APPROVE = True And (dao_margin.fields.IS_CHECK_RECEIVE = False Or dao_margin.fields.IS_CHECK_RECEIVE Is Nothing) Then
                        str_stat = "เช็คพร้อมจ่าย"
                    ElseIf dao_margin.fields.CHECK_APPROVE = True And dao_margin.fields.IS_CHECK_RECEIVE = True Then
                        str_stat = "รับเช็คแล้ว"
                    End If
                End If
            End If
        End If

        If dao.fields.IS_CANCEL IsNot Nothing Then
            If dao.fields.IS_CANCEL = True Then
                str_stat = "ยกเลิก"
            End If
        End If

        ' End If

        Return str_stat
    End Function
    Public Function check_return_date(ByVal bill_id As Integer) As Date
        Dim re_date As New Date
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_margin As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
        dao.Getdata_by_DEBTOR_BILL_ID(bill_id)
        dao_margin.Getdata_by_DEBTOR_BILL_ID(bill_id)

        If dao.fields.DEBTOR_TYPE_ID = 2 Then
            If dao.fields.RETURN_BUDGET_DATE IsNot Nothing Then
                re_date = dao.fields.RETURN_BUDGET_DATE
            Else
                re_date = Nothing
            End If
        ElseIf dao.fields.DEBTOR_TYPE_ID = 1 Then
            If dao_margin.fields.RETURN_BUDGET_DATE IsNot Nothing Then
                re_date = dao_margin.fields.RETURN_BUDGET_DATE
            Else
                re_date = Nothing
            End If
        End If

        Return re_date
    End Function
    Public Sub set_color_rg()
        If rgDebtor.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In rgDebtor.Items
                If i = 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                i = i + 1
            Next
        End If
    End Sub
    Public Sub update_true(ByVal date_input As Date)
        For Each item As GridDataItem In rgDebtor.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            dao.fields.IS_APPROVE = True
            dao.fields.APPROVE_DATE = date_input

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "อนุมัติลูกหนี้เลขที่หนังสือ " & dao.fields.DOC_NUMBER, "DEBTOR_BILL", item("DEBTOR_BILL_ID").Text)

            dao.update()
        Next
    End Sub
    Public Sub update_false()
        For Each item As GridDataItem In rgDebtor.SelectedItems
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(item("DEBTOR_BILL_ID").Text)
            dao.fields.IS_APPROVE = False
            dao.fields.APPROVE_DATE = Nothing
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "ยกเลิกอนุมัติลูกหนี้เลขที่หนังสือ " & dao.fields.DOC_NUMBER, "DEBTOR_BILL", item("DEBTOR_BILL_ID").Text)

            dao.update()
        Next
    End Sub
End Class