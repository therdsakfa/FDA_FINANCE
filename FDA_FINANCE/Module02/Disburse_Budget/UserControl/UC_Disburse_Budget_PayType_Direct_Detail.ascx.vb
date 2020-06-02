Public Partial Class UC_Disburse_Budget_Pay_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
            'setPanel()
            Dim strQuery As Integer
            Dim digit As Integer
            Dim uti As New Utility_other

            If Request.QueryString("bid") IsNot Nothing Then
                strQuery = Request.QueryString("bid")
                ' digit = getBillstatusPay(strQuery)
                digit = uti.getBillstatusPay(strQuery)
                Select Case digit
                    Case 5
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel6.Enabled = True
                    Case 4
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel6.Enabled = True
                    Case 3
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel6.Enabled = True
                    Case 2
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel6.Enabled = True
                    Case 1
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel6.Enabled = True
                    Case 0
                        Panel1.Enabled = True
                        Panel2.Enabled = False
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        Panel6.Enabled = False

                End Select

                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(strQuery)
                lb_BILL_NUMBER.Text = dao.fields.BILL_NUMBER
                lb_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
                lb_GFMIS_NUMBER.Text = dao.fields.GFMIS_NUMBER
                lb_deeka.Text = dao.fields.DEEKA_NUMBER
            End If


        End If
        
    End Sub

    Public Sub set_date()
        txt_RETURN_APPROVE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_INVOICE_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_TAX_RECEIPT_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_RECEIPT_DATE.Text = System.DateTime.Now.ToShortDateString()
        txt_RECEIVE_TAX_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    'Public Sub setPanel()
    '    Panel1.Visible = False
    '    Panel2.Visible = False
    '    Panel3.Visible = False
    'End Sub
    ''' <summary>
    ''' เพิ่ม/แก้ไขข้อมูลจ่ายตรง
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        ' dao.fields.BUDGET_DISBURSE_BILL_ID =

        If txt_INVOICE_DATE.Text <> "" Then
            dao.fields.INVOICES_DATE = CDate(txt_INVOICE_DATE.Text)
        Else
            dao.fields.INVOICES_DATE = Nothing
        End If
        dao.fields.INVOICES_NUMBER = txt_INVOICE_NUMBER.Text
        If txt_RETURN_APPROVE_DATE.Text <> "" Then
            dao.fields.RETURN_APPROVE_DATE = CDate(txt_RETURN_APPROVE_DATE.Text)
        Else
            dao.fields.RETURN_APPROVE_DATE = Nothing
        End If
        dao.fields.RETURN_APPROVE_NUMBER = txt_RETURN_APPROVE_NUMBER.Text
        If txt_TAX_RECEIPT_DATE.Text <> "" Then
            dao.fields.TAX_DATE = CDate(txt_TAX_RECEIPT_DATE.Text)
        Else
            dao.fields.TAX_DATE = Nothing
        End If
        dao.fields.TAX_NUMBER = txt_TAX_RECEIPT_NUMBER.Text
        If txt_RECEIPT_DATE.Text <> "" Then
            dao.fields.RECEIPT_DATE = CDate(txt_RECEIPT_DATE.Text)
        Else
            dao.fields.RECEIPT_DATE = Nothing
        End If
        dao.fields.RECEIPT_NUMBER = txt_RECEIPT_NUMBER.Text

        dao.fields.IS_RECEIVE_TAX = cb_IS_RECEIVE_TAX.Checked
        dao.fields.RECEIVER_TAX_NAME = txt_RECEIVER_TAX_NAME.Text

        If txt_RECEIVE_TAX_DATE.Text <> "" Then
            dao.fields.RECEIVE_TAX_DATE = CDate(txt_RECEIVE_TAX_DATE.Text)
        Else
            dao.fields.RECEIVE_TAX_DATE = Nothing
        End If
        If txt_INVOICES_DATE_SAVE.Text <> "" Then
            dao.fields.INVOICES_DATE_SAVE = CDate(txt_INVOICES_DATE_SAVE.Text)
        Else
            dao.fields.INVOICES_DATE_SAVE = Nothing
        End If
    End Sub
    Public Sub insert_direct(ByRef dao As DAO_DISBURSE.TB_PAY_DIRECT)
        If txt_INVOICE_DATE.Text <> "" Then
            dao.fields.INVOICES_DATE = CDate(txt_INVOICE_DATE.Text)
        End If
        dao.fields.INVOICES_NUMBER = txt_INVOICE_NUMBER.Text
        If txt_RETURN_APPROVE_DATE.Text <> "" Then
            dao.fields.RETURN_APPROVE_DATE = CDate(txt_RETURN_APPROVE_DATE.Text)
        End If
        dao.fields.RETURN_APPROVE_NUMBER = txt_RETURN_APPROVE_NUMBER.Text
        If txt_RECEIPT_DATE.Text <> "" Then
            dao.fields.RECEIPT_DATE = CDate(txt_RECEIPT_DATE.Text)
        End If
        dao.fields.TAX_NUMBER = txt_TAX_RECEIPT_NUMBER.Text
    End Sub
    ''' <summary>
    ''' ดึงข้อมูลจ่ายตรง
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        If dao.fields.INVOICES_DATE IsNot Nothing Then
            txt_INVOICE_DATE.Text = dao.fields.INVOICES_DATE
        End If
        If dao.fields.INVOICES_NUMBER IsNot Nothing Then
            txt_INVOICE_NUMBER.Text = dao.fields.INVOICES_NUMBER
        End If
        If dao.fields.RETURN_APPROVE_DATE IsNot Nothing Then
            txt_RETURN_APPROVE_DATE.Text = dao.fields.RETURN_APPROVE_DATE
        End If
        If dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing Then
            txt_RETURN_APPROVE_NUMBER.Text = dao.fields.RETURN_APPROVE_NUMBER
        End If
        If dao.fields.TAX_DATE IsNot Nothing Then
            txt_TAX_RECEIPT_DATE.Text = dao.fields.TAX_DATE
        End If
        If dao.fields.TAX_NUMBER IsNot Nothing Then
            txt_TAX_RECEIPT_NUMBER.Text = dao.fields.TAX_NUMBER
        End If
        If dao.fields.RECEIPT_DATE IsNot Nothing Then
            txt_RECEIPT_DATE.Text = dao.fields.RECEIPT_DATE
        End If
        If dao.fields.RECEIPT_NUMBER IsNot Nothing Then
            txt_RECEIPT_NUMBER.Text = dao.fields.RECEIPT_NUMBER
        End If
        If dao.fields.IS_RECEIVE_TAX IsNot Nothing Then
            If dao.fields.IS_RECEIVE_TAX = True Then
                cb_IS_RECEIVE_TAX.Checked = True
            Else
                cb_IS_RECEIVE_TAX.Checked = False
            End If
        Else
            cb_IS_RECEIVE_TAX.Checked = False
        End If
        If dao.fields.RECEIVER_TAX_NAME IsNot Nothing Then
            txt_RECEIVER_TAX_NAME.Text = dao.fields.RECEIVER_TAX_NAME
        End If

        If dao.fields.RECEIVE_TAX_DATE IsNot Nothing Then
            txt_RECEIVE_TAX_DATE.Text = CDate(dao.fields.RECEIVE_TAX_DATE)
        End If
        If dao.fields.INVOICES_DATE_SAVE IsNot Nothing Then
            txt_INVOICES_DATE_SAVE.Text = CDate(dao.fields.INVOICES_DATE_SAVE).ToShortDateString()
        End If

    End Sub
    'Public Function getBillstatusPay(ByVal bill_id As Integer) As Integer
    '    Dim digit As Integer = 0
    '    Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
    '    dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
    '    If dao_bill.fields.TAX_NUMBER <> "" Then
    '        digit = 3
    '    ElseIf dao_bill.fields.INVOICES_NUMBER <> "" Then
    '        digit = 2
    '    ElseIf dao_bill.fields.RETURN_APPROVE_NUMBER <> "" Then
    '        digit = 1
    '    Else
    '        digit = 0
    '    End If
    '    Return digit
    'End Function
End Class