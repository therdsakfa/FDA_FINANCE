Public Partial Class UC_Disburse_Budget_PayType_Pass_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'setPanel()
            Dim uti As New Utility_other
            Dim strQuery As Integer
            Dim digit As Integer
            If Request.QueryString("bid") IsNot Nothing Then
                strQuery = Request.QueryString("bid")
                digit = uti.getBillstatusPay_Pass(strQuery)
                Select Case digit
                    Case 5
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel5.Enabled = True
                    Case 4
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel5.Enabled = True
                    Case 3
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel5.Enabled = False
                    Case 2

                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = False
                        Panel5.Enabled = False
                    Case 1
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        Panel5.Enabled = False
                    Case 0
                        Panel1.Enabled = True
                        Panel2.Enabled = False
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        Panel5.Enabled = False
                End Select

                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(strQuery)
                dao_detail.Getdata_by_Disburse_id(strQuery)
                Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
                If dao.fields.CUSTOMER_ID IsNot Nothing Then
                    If dao.fields.CUSTOMER_ID <> 0 Then
                        dao_cus.Getdata_by_CUSTOMER_ID(dao.fields.CUSTOMER_ID)
                        lb_customer_name.Text = dao_cus.fields.CUSTOMER_NAME
                    Else
                        lb_customer_name.Text = "ไม่ทราบเจ้าหนี้"
                    End If
                End If
                
                lb_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
                lb_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
                lb_GFMIS_NUMBER.Text = dao.fields.GFMIS_NUMBER
                Dim amount As Double = 0
                If dao_detail.fields.AMOUNT IsNot Nothing Then
                    amount = dao_detail.fields.AMOUNT
                    lb_Amount.Text = amount.ToString("N")
                End If

            End If
        End If
    End Sub

    Public Sub set_date()
        txt_RETURN_APPROVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        'txt_INVOICE_DATE.Text = System.DateTime.Now.ToShortDateString()
        'txt_TAX_RECEIPT_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_CHECK_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_CHECK_APPROVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_CHECK_RECEIVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_RETURN_BUDGET_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_Check_ready_date.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลจ่ายผ่าน
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)

        'dao.fields.INVOICES_DATE = CDate(txt_INVOICE_DATE.Text)
        'dao.fields.INVOICES_NUMBER = txt_INVOICE_NUMBER.Text
        If txt_RETURN_APPROVE_DATE.Text <> "" Then
            dao.fields.RETURN_APPROVE_DATE = CDate(txt_RETURN_APPROVE_DATE.Text)
        Else
            dao.fields.RETURN_APPROVE_DATE = Nothing
        End If
        dao.fields.RETURN_APPROVE_NUMBER = txt_RETURN_APPROVE_NUMBER.Text
        'dao.fields.TAX_DATE = CDate(txt_TAX_RECEIPT_DATE.Text)
        'dao.fields.TAX_NUMBER = txt_TAX_RECEIPT_NUMBER.Text
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        Else
            dao.fields.CHECK_DATE = Nothing
        End If
        dao.fields.CHECK_APPROVE = cb_CHECK_APPROVE.Checked
        If txt_CHECK_APPROVE_DATE.Text <> "" Then
            dao.fields.CHECK_APPROVE_DATE = CDate(txt_CHECK_APPROVE_DATE.Text)
        Else
            dao.fields.CHECK_APPROVE_DATE = Nothing
        End If

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

        If txt_Check_ready_date.Text <> "" Then
            dao.fields.CHECK_READY_DATE = CDate(txt_Check_ready_date.Text)
        Else
            dao.fields.CHECK_READY_DATE = Nothing
        End If
        dao.fields.IS_CHECK_READY = cb_is_check_ready.Checked
    End Sub
    Public Sub insert_pass(ByRef dao As DAO_DISBURSE.TB_PAY_PASS)

        'dao.fields.INVOICES_DATE = CDate(txt_INVOICE_DATE.Text)
        'dao.fields.INVOICES_NUMBER = txt_INVOICE_NUMBER.Text
        If txt_RETURN_APPROVE_DATE.Text <> "" Then
            dao.fields.RETURN_APPROVE_DATE = CDate(txt_RETURN_APPROVE_DATE.Text)
        End If
        dao.fields.RETURN_APPROVE_NUMBER = txt_RETURN_APPROVE_NUMBER.Text
        'dao.fields.TAX_DATE = CDate(txt_TAX_RECEIPT_DATE.Text)
        'dao.fields.TAX_NUMBER = txt_TAX_RECEIPT_NUMBER.Text
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        End If
        dao.fields.CHECK_APPROVE = cb_CHECK_APPROVE.Checked
        If txt_CHECK_APPROVE_DATE.Text <> "" Then
            dao.fields.CHECK_APPROVE_DATE = CDate(txt_CHECK_APPROVE_DATE.Text)
        End If
        dao.fields.IS_CHECK_RECEIVE = cb_IS_CHECK_RECEIVE.Checked
        If txt_CHECK_RECEIVE_DATE.Text <> "" Then
            dao.fields.CHECK_RECEIVE_DATE = CDate(txt_CHECK_RECEIVE_DATE.Text)
        End If
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลจ่ายผ่าน
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        If dao.fields.RETURN_APPROVE_DATE IsNot Nothing Then
            txt_RETURN_APPROVE_DATE.Text = CDate(dao.fields.RETURN_APPROVE_DATE).ToShortDateString()
        End If
        txt_RETURN_APPROVE_NUMBER.Text = dao.fields.RETURN_APPROVE_NUMBER
        txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString()
        End If
        cb_CHECK_APPROVE.Checked = dao.fields.CHECK_APPROVE
        If dao.fields.CHECK_APPROVE_DATE IsNot Nothing Then
            txt_CHECK_APPROVE_DATE.Text = CDate(dao.fields.CHECK_APPROVE_DATE).ToShortDateString()
        End If

        cb_IS_CHECK_RECEIVE.Checked = dao.fields.IS_CHECK_RECEIVE
        If dao.fields.CHECK_RECEIVE_DATE IsNot Nothing Then
            txt_CHECK_RECEIVE_DATE.Text = CDate(dao.fields.CHECK_RECEIVE_DATE).ToShortDateString()
        End If
        If dao.fields.RETURN_BUDGET_DATE IsNot Nothing Then
            txt_RETURN_BUDGET_DATE.Text = dao.fields.RETURN_BUDGET_DATE
        End If
        If dao.fields.CHECK_READY_DATE IsNot Nothing Then
            txt_Check_ready_date.Text = dao.fields.CHECK_READY_DATE
        End If
        If dao.fields.IS_CHECK_READY = True Then
            cb_is_check_ready.Checked = True
        Else
            cb_is_check_ready.Checked = False
        End If
    End Sub


End Class