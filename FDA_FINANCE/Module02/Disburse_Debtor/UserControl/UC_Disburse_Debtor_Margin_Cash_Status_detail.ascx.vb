Public Class UC_Disburse_Debtor_Margin_Cash_Status_detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
            'txt_RETURN_BUDGET_DATE.Text = System.DateTime.Now.ToShortDateString
            'setPanel()
            Dim uti As New Utility_other
            Dim strQuery As Integer
            Dim digit As Integer
            If Request.QueryString("bid") IsNot Nothing Then
                strQuery = Request.QueryString("bid")
                digit = uti.getDebtorstatusMargin_cash(strQuery)
                Select Case digit

                    Case 2
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                    Case 1
                        Panel2.Enabled = True
                        Panel1.Enabled = True
                    Case 0
                        Panel2.Enabled = True
                        Panel1.Enabled = False


                End Select


            End If
        End If
    End Sub
    Public Sub set_date()
        txt_return_date.Text = System.DateTime.Now.ToShortDateString
        txt_PAY_DATE.Text = System.DateTime.Now.ToShortDateString
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)


        If txt_return_date.Text = "" Then
            dao.fields.DEADLINE_DATE = Nothing
        Else
            dao.fields.DEADLINE_DATE = CDate(txt_return_date.Text)
        End If

        dao.fields.IS_PAY = cb_pay.Checked
        If txt_PAY_DATE.Text <> "" Then
            dao.fields.PAY_DATE = CDate(txt_PAY_DATE.Text)
            dao.fields.CHECK_RECEIVE_DATE = CDate(txt_PAY_DATE.Text)
        Else
            dao.fields.PAY_DATE = Nothing
            dao.fields.CHECK_RECEIVE_DATE = Nothing
        End If

        dao.fields.IS_CHECK_READY = cb_is_check_ready.Checked

        If txt_Check_ready_date.Text = "" Then
            dao.fields.CHECK_READY_DATE = Nothing
        Else
            dao.fields.CHECK_READY_DATE = CDate(txt_Check_ready_date.Text)
        End If

        'If Panel2.Enabled = True Then
        '    '     dao.fields.REBILL_ID = rd_Rebill.SelectedValue

        '    If rd_Rebill.SelectedValue <> "" Then
        '        dao.fields.REBILL_ID = rd_Rebill.SelectedValue
        '    Else
        '        dao.fields.REBILL_ID = Nothing
        '    End If
        'Else
        '    dao.fields.REBILL_ID = Nothing
        'End If
        'If txt_RETURN_BUDGET_DATE.Text = "" Then
        '    dao.fields.RETURN_BUDGET_DATE
        'End If

    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL)

        If dao.fields.DEADLINE_DATE IsNot Nothing Then
            txt_return_date.Text = dao.fields.DEADLINE_DATE
        Else
            txt_return_date.Text = ""
        End If
        If dao.fields.IS_PAY = True Then
            cb_pay.Checked = True
        End If
        If dao.fields.PAY_DATE IsNot Nothing Then
            txt_PAY_DATE.Text = dao.fields.PAY_DATE
        End If
        If dao.fields.CHECK_READY_DATE IsNot Nothing Then
            txt_Check_ready_date.Text = dao.fields.CHECK_READY_DATE
        End If

        If dao.fields.IS_CHECK_READY IsNot Nothing Then
            If dao.fields.IS_CHECK_READY = True Then
                cb_is_check_ready.Checked = True
            Else
                cb_is_check_ready.Checked = False
            End If
        Else
            cb_is_check_ready.Checked = False
        End If

        'If dao.fields.REBILL_ID Is Nothing Then

        'Else
        '    rd_Rebill.SelectedValue = dao.fields.REBILL_ID

        'End If

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
End Class