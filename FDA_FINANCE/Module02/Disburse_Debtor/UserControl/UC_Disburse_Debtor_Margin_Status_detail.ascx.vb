Public Class UC_Disburse_Debtor_Margin_Status_detail
    Inherits System.Web.UI.UserControl
    'Private _return_visible As Boolean
    'Public Property return_visible() As Boolean
    '    Get
    '        Return _return_visible
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _return_visible = value
    '    End Set
    'End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
            'setPanel()
            'If return_visible = True Then
            '    lb_RETURN.Visible = True
            '    txt_RETURN_BUDGET_DATE.Visible = True
            'End If
            Dim uti As New Utility_other
            Dim strQuery As Integer
            Dim digit As Integer
            If Request.QueryString("bid") IsNot Nothing Then
                strQuery = Request.QueryString("bid")
                digit = uti.getDebtorstatusMargin(strQuery)
                Select Case digit
                    Case 5
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        ' Panel5.Enabled = True
                    Case 4
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        ' Panel5.Enabled = True
                    Case 3
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        'Panel5.Enabled = False
                    Case 2
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = False
                        ' Panel5.Enabled = False
                    Case 1
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        ' Panel5.Enabled = False

                    Case 0
                        Panel1.Enabled = True
                        Panel2.Enabled = False
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        ' Panel5.Enabled = False

                End Select
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                Dim dao_margin As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
                dao.Getdata_by_DEBTOR_BILL_ID(strQuery)
                dao_detail.Getdata_by_DEBTOR_BILL_ID(strQuery)
                dao_margin.Getdata_by_DEBTOR_BILL_ID(strQuery)
                Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
                Dim amount As Double = 0
                If dao.fields.USER_ID IsNot Nothing Then
                    If dao.fields.USER_ID <> 0 Then
                        Try
                            dao_cus.Getdata_by_CUSTOMER_ID(dao.fields.USER_ID)
                        Catch ex As Exception

                        End Try

                        lb_customer_name.Text = dao_cus.fields.CUSTOMER_NAME 'dao_cus.fields.PREFIX & " " & dao_cus.fields.NAME & " " & dao_cus.fields.SURNAME
                    Else
                        lb_customer_name.Text = "-"
                    End If
                End If
                lb_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
                lb_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
                lb_GFMIS_NUMBER.Text = dao.fields.GFMIS_NUMBER
                If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                    If dao.fields.DEBTOR_TYPE_ID = 2 Then
                        If dao_detail.fields.AMOUNT IsNot Nothing Then
                            amount = dao_detail.fields.AMOUNT
                            lb_Amount.Text = amount.ToString("N")
                        End If
                    Else
                        amount = dao_margin.fields.AMOUNT
                        lb_Amount.Text = amount.ToString("N")
                    End If

                End If

            End If
        End If
    End Sub
    Public Sub insert_cancel()
        If Request.QueryString("bid") IsNot Nothing Then
            If cb_IS_CANCEL.Checked = True Then
                Dim dao_copy As New DAO_DISBURSE.TB_DEBTOR_BILL
                dao_copy.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                Dim dao_chk_repeat As New DAO_DISBURSE.TB_DEBTOR_BILL
                Dim bill_count As Integer = dao_chk_repeat.get_data_by_invoice(Request.QueryString("bid"))
                If bill_count = 0 Then
                    Dim dao_insert As New DAO_DISBURSE.TB_DEBTOR_BILL
                    Dim dao_copy_det As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                    Dim dao_copy_det_mar As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
                    Dim dao_insert_det As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                    dao_copy_det.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                    dao_insert.fields.APPROVE_DATE = dao_copy.fields.APPROVE_DATE
                    dao_insert.fields.BILL_DATE = dao_copy.fields.BILL_DATE
                    dao_insert.fields.BILL_NUMBER = dao_copy.fields.BILL_NUMBER
                    dao_insert.fields.Bill_RECIEVE_DATE = dao_copy.fields.Bill_RECIEVE_DATE
                    dao_insert.fields.BUDGET_PLAN_ID = dao_copy.fields.BUDGET_PLAN_ID
                    dao_insert.fields.BUDGET_USE_ID = dao_copy.fields.BUDGET_USE_ID
                    dao_insert.fields.BUDGET_YEAR = dao_copy.fields.BUDGET_YEAR
                    dao_insert.fields.DEPARTMENT_ID = dao_copy.fields.DEPARTMENT_ID
                    dao_insert.fields.DESCRIPTION = "ปรับปรุง ยกเลิก " & dao_copy.fields.DESCRIPTION
                    dao_insert.fields.DOC_DATE = dao_copy.fields.DOC_DATE
                    dao_insert.fields.DOC_NUMBER = dao_copy.fields.DOC_NUMBER
                    dao_insert.fields.USER_ID = dao_copy.fields.USER_ID
                    dao_insert.fields.INVOICES_NUMBER = Request.QueryString("bid")
                    dao_insert.insert()

                    'If dao_copy.fields.DEBTOR_TYPE_ID IsNot Nothing Then
                    '    If dao_copy.fields.DEBTOR_TYPE_ID <> 0 Then
                    '        If dao_copy.fields.DEBTOR_TYPE_ID = 2 Then
                    dao_copy_det.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                    If dao_copy_det.fields.AMOUNT IsNot Nothing Then
                        dao_insert_det.fields.AMOUNT = dao_copy_det.fields.AMOUNT * -1
                    End If

                    dao_insert_det.fields.DEBTOR_BILL_ID = dao_insert.fields.DEBTOR_BILL_ID
                    dao_insert_det.insert()
                    'ElseIf dao_copy.fields.DEBTOR_TYPE_ID = 1 Then
                    '    dao_copy_det_mar.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                    '    If dao_copy_det_mar.fields.AMOUNT IsNot Nothing Then
                    '        dao_insert_det.fields.AMOUNT = dao_copy_det_mar.fields.AMOUNT * -1
                    '    End If

                    '    dao_insert_det.fields.DEBTOR_BILL_ID = dao_insert.fields.DEBTOR_BILL_ID
                    '    dao_insert_det.insert()
                    'End If
                End If
            End If
        End If


        ' End If


        'End If

    End Sub
    Public Sub set_date()
        txt_CHECK_APPROVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_CHECK_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_CHECK_RECEIVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_RETURN_BUDGET_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_Return_date.Text = System.DateTime.Now.ToShortDateString()
        txt_Check_ready_date.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)

        dao.fields.CHECK_APPROVE = cb_CHECK_APPROVE.Checked
        If txt_CHECK_APPROVE_DATE.Text <> "" Then
            dao.fields.CHECK_APPROVE_DATE = CDate(txt_CHECK_APPROVE_DATE.Text)
        Else
            dao.fields.CHECK_APPROVE_DATE = Nothing
        End If
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        Else
            dao.fields.CHECK_DATE = Nothing
        End If

        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        dao.fields.IS_CHECK_RECEIVE = cb_IS_CHECK_RECEIVE.Checked
        If txt_CHECK_RECEIVE_DATE.Text <> "" Then
            dao.fields.CHECK_RECEIVE_DATE = CDate(txt_CHECK_RECEIVE_DATE.Text)
        Else
            dao.fields.CHECK_RECEIVE_DATE = Nothing
        End If
        If txt_RETURN_BUDGET_DATE.Text <> "" Then
            dao.fields.RETURN_BUDGET_DATE = CDate(txt_RETURN_BUDGET_DATE.Text)
        Else
            dao.fields.RETURN_BUDGET_DATE = Nothing
        End If

        If txt_Return_date.Text = "" Then
            dao.fields.DEADLINE_DATE = Nothing
        Else
            dao.fields.DEADLINE_DATE = CDate(txt_Return_date.Text)
        End If
        'If Panel5.Enabled = True Then
        '    If rd_Rebill.SelectedValue <> "" Then
        '        dao.fields.REBILL_ID = rd_Rebill.SelectedValue
        '    Else
        '        dao.fields.REBILL_ID = Nothing
        '    End If

        'Else
        '    dao.fields.REBILL_ID = Nothing
        'End If


        'If return_visible = True Then
        '    dao.fields.r()
        'End If
        If txt_Check_ready_date.Text <> "" Then
            dao.fields.CHECK_READY_DATE = CDate(txt_Check_ready_date.Text)
        Else
            dao.fields.CHECK_READY_DATE = Nothing
        End If
        dao.fields.IS_CHECK_READY = cb_is_check_ready.Checked
    End Sub

    Public Sub insert_head(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        'If rdl_IS_Cancel.SelectedValue = "1" Then
        dao.fields.IS_CANCEL = cb_IS_CANCEL.Checked
        'Else
        'dao.fields.IS_CHECK_RECEIVE = Nothing
        'dao.fields.IS_CANCEL = True
        'End If


    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)


        'cb_CHECK_APPROVE.Checked = dao.fields.CHECK_APPROVE
        'txt_CHECK_APPROVE_DATE.Text = dao.fields.CHECK_APPROVE_DATE.ToString
        'txt_CHECK_DATE.Text = dao.fields.CHECK_DATE.ToString
        'txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
        'cb_IS_CHECK_RECEIVE.Checked = dao.fields.IS_CHECK_RECEIVE
        'txt_return_date.Text = dao.fields.DEADLINE_DATE.ToString
        'If dao.fields.REBILL_ID Is Nothing Then

        'Else
        '    rd_Rebill.SelectedValue = dao.fields.REBILL_ID

        'End If
        If dao.fields.CHECK_APPROVE = True Then
            cb_CHECK_APPROVE.Checked = True
        Else
            cb_CHECK_APPROVE.Checked = False
        End If

        If dao.fields.IS_CHECK_RECEIVE = True Then
            cb_IS_CHECK_RECEIVE.Checked = True
        Else
            cb_IS_CHECK_RECEIVE.Checked = False
        End If

        If dao.fields.CHECK_APPROVE_DATE IsNot Nothing Then
            txt_CHECK_APPROVE_DATE.Text = CDate(dao.fields.CHECK_APPROVE_DATE).ToShortDateString()
        End If
        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString()
        End If
        If dao.fields.CHECK_NUMBER IsNot Nothing Then
            txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
        End If

        If dao.fields.DEADLINE_DATE IsNot Nothing Then
            txt_Return_date.Text = CDate(dao.fields.DEADLINE_DATE).ToShortDateString()
        End If

        If dao.fields.CHECK_RECEIVE_DATE IsNot Nothing Then
            txt_CHECK_RECEIVE_DATE.Text = CDate(dao.fields.CHECK_RECEIVE_DATE).ToShortDateString()
        End If

        If dao.fields.RETURN_BUDGET_DATE IsNot Nothing Then
            txt_RETURN_BUDGET_DATE.Text = CDate(dao.fields.RETURN_BUDGET_DATE).ToShortDateString()
        End If
        If dao.fields.CHECK_READY_DATE IsNot Nothing Then
            txt_Check_ready_date.Text = CDate(dao.fields.CHECK_READY_DATE).ToShortDateString()
        End If
        If dao.fields.IS_CHECK_READY = True Then
            cb_is_check_ready.Checked = True
        Else
            cb_is_check_ready.Checked = False
        End If
    End Sub

    Public Sub getdata_head(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        If dao.fields.IS_CANCEL IsNot Nothing Then
            If dao.fields.IS_CANCEL = True Then
                cb_IS_CANCEL.Checked = True
            Else
                cb_IS_CANCEL.Checked = False
            End If
        Else
            cb_IS_CANCEL.Checked = False
        End If
    End Sub
    'Private Sub txt_returnday_TextChanged(sender As Object, e As EventArgs) Handles txt_returnday.TextChanged
    '    Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
    '    dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
    '    Dim days As Double = 0
    '    If txt_returnday.Text <> "" Then
    '        days = txt_returnday.Text
    '    End If
    '    txt_return_date.Text = DateAdd(DateInterval.Day, days, CDate(dao.fields.BILL_DATE))
    'End Sub
    'Private Sub rdl_IS_Cancel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_IS_Cancel.SelectedIndexChanged
    '    set_cancel()
    'End Sub

    'Public Sub set_cancel()
    '    If rdl_IS_Cancel.SelectedValue = "1" Then
    '        pn_pay.Enabled = True
    '    Else
    '        pn_pay.Enabled = False
    '    End If
    'End Sub
End Class