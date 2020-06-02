Public Class UC_Maintain_ReturnMoney_Detail
    Inherits System.Web.UI.UserControl
    Private _is_outside As Boolean
    Public Property is_outside() As String
        Get
            Return _is_outside
        End Get
        Set(ByVal value As String)
            _is_outside = value
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


    Public rc_id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not IsPostBack Then
            Dim id As Integer = 0
            id = Request.QueryString("DEBTOR_BILL_ID")
            Dim return_money As Double = 0
            Dim debtor_money As Double = 0
            Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao_debtor.Getdata_by_DEBTOR_BILL_ID(id)

            Dim bao_debtor As New BAO_BUDGET.Maintain
            Dim bao_outside As New BAO_BUDGET.Maintain
            'Dim dt_debtor As DataTable
            Dim dao_amount As New DAO_DISBURSE.TB_DEBTOR_BILL
            If is_outside = False Then
                'dt_debtor = bao_debtor.get_DEBTOR_BILL_in_BUDGET_by_id(id)
                Dim bao_amount As New BAO_BUDGET.DISBURSE_BUDGET()
                If dao_debtor.fields.DEBTOR_TYPE_ID = 1 Then
                    debtor_money = bao_amount.get_money_debtor_in_margin(id)
                ElseIf dao_debtor.fields.DEBTOR_TYPE_ID = 2 Then
                    debtor_money = bao_amount.get_money_debtor_in(id)
                Else
                    debtor_money = 0
                End If
            Else
                Dim bao_amount As New BAO_BUDGET.DISBURSE_BUDGET()
                debtor_money = bao_amount.get_money_debtor_out(id)
            End If
            bind_r_type()



            Dim bao_return_Amount As New BAO_BUDGET.MASS
            Dim return_Amount As Double = 0
            If id <> 0 Then
                return_Amount = bao_return_Amount.get_debtor_return_amount(id)
                return_money = debtor_money - return_Amount
            Else
                If Request.QueryString("id") IsNot Nothing Then
                    Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                    'dao_return.Getdata_by_DEBTOR_ID(id)
                    dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(Request.QueryString("id"))
                    return_Amount = dao_return.fields.RETURN_AMOUNT
                    return_money = debtor_money + return_Amount
                End If

            End If

            'If dt_debtor.Rows.Count > 0 Then
            '    If IsDBNull(dt_debtor(0)("AMOUNT")) = False Then
            '        return_money = CDbl(dt_debtor(0)("AMOUNT")) - return_Amount

            '        'txt_RETURN_AMOUNT.Value = return_money
            lb_balance.Text = return_money.ToString("N")
            '    End If
            'End If

            

            'Dim bao_description As New BAO_BUDGET.MASS
            'Dim dt_descrition As DataTable = bao_description.get_RETURN_DESCRIPTION()
            'rcb_MAS_RETURN_DESCRIPTION.DataSource = dt_descrition
            'rcb_MAS_RETURN_DESCRIPTION.DataBind()


            bindcontrol()

            Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
            dao_rec.get_receiver()
            lb_money_receiver.Text = dao_rec.fields.RECEIVER_NAME
            rc_id = dao_rec.fields.RECEIVER_MONEY_ID
            ' get_debtor_return_amount


            If Request.QueryString("id") IsNot Nothing Then
                set_dropdown_edit(Request.QueryString("id"))
                bindcontrol()

            End If

        End If
    End Sub
    Public Function Check_txt_reason() As Boolean
        Dim bool As Boolean = False
        If txt_Reson.Text <> "" Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function

    Public Function Check_rdl_sub_pay_type() As Boolean
        Dim bool As Boolean = False

        If rd_moneytype.SelectedValue <> "" Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function
    'ddl_MAS_RETURN_TYPE.SelectedValue = 3
    Public Function Check_ddl_MAS_RETURN_TYPE() As Boolean
        Dim bool As Boolean = False
        If ddl_MAS_RETURN_TYPE.SelectedValue = 3 Then

            bool = True
        Else
            bool = False
        End If

        Return bool
    End Function

    Public Function chk_money_over(ByVal id As Integer) As Boolean
        Dim bool As Boolean = False
        'Dim dao As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        Dim bao_debt As New BAO_BUDGET.DISBURSE_BUDGET
        Dim debt_amount As Double = 0
        debt_amount = bao_debt.get_debtor_amount(id)
        Dim bao_return_Amount As New BAO_BUDGET.MASS
        Dim return_Amount As Double = 0
        return_Amount = bao_return_Amount.get_debtor_return_amount(id)
        Dim amount As Double = 0
        amount = return_Amount + txt_RETURN_AMOUNT.Value
        If Math.Round(amount, 2) > Math.Round(debt_amount, 2) Then
            bool = True
        End If
        Return bool
    End Function

    Public Function get_return_type() As Integer
        Dim val As Integer = 0
        If ddl_MAS_RETURN_TYPE.SelectedValue <> "" Then
            val = ddl_MAS_RETURN_TYPE.SelectedValue
        End If

        Return val
    End Function

    Public Sub bind_r_type()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_MAS_RETURN_TYPE()
        ddl_MAS_RETURN_TYPE.DataSource = dt
        ddl_MAS_RETURN_TYPE.DataBind()
    End Sub
    Public Sub set_dropdown_edit(ByVal return_id As String)
        If return_id <> "" Then
            Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
            dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(return_id)

            If dao_return.fields.PAY_TYPE IsNot Nothing Then
                ddl_MAS_RETURN_TYPE.DropDownSelectData(dao_return.fields.PAY_TYPE)
                If ddl_MAS_RETURN_TYPE.SelectedValue <> "" Then
                    If ddl_MAS_RETURN_TYPE.SelectedValue = "2" Then
                        lb_reason.Style.Add("Display", "block")
                        txt_Reson.Style.Add("Display", "block")
                    Else
                        lb_reason.Style.Add("Display", "none")
                        txt_Reson.Style.Add("Display", "none")
                    End If
                End If

            End If

        End If
    End Sub

    Public Sub set_date()
        Dim date_now As String = System.DateTime.Now.ToShortDateString()
        txt_DOC_DATE.Text = date_now
        txt_return_date.Text = date_now
        txt_today_date.Text = date_now
    End Sub
    Public Sub set_textbox()

        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL()
        Dim flag_margin As Boolean = False
        dao_debtor.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("DEBTOR_BILL_ID"))
        Dim strNumeric As String = ""
        If IsNumeric(dao_debtor.fields.BILL_NUMBER) = True Then
            strNumeric = CInt(dao_debtor.fields.BILL_NUMBER).ToString() & "/" & Right(dao_debtor.fields.BUDGET_YEAR, 2)
        Else
            strNumeric = dao_debtor.fields.BILL_NUMBER
        End If
        Dim type_debt As Integer = 0
        If dao_debtor.fields.BUDGET_USE_ID IsNot Nothing Then
            type_debt = dao_debtor.fields.BUDGET_USE_ID
        End If
        If dao_debtor.fields.DEBTOR_BILL_ID <> Nothing Then
            If dao_debtor.fields.DEBTOR_TYPE_ID = 1 Then
                flag_margin = True
            Else
                flag_margin = False
            End If
        End If
        If ddl_MAS_RETURN_TYPE.SelectedValue <> "" Then
            If ddl_MAS_RETURN_TYPE.SelectedValue = 1 Then
                If flag_margin = True Then
                    If dao_debtor.fields.DEBTOR_BILL_ID <> 0 Then
                        If dao_debtor.fields.REBILL_ID = 1 Then
                            'If dao_debtor.fields.MOVEDATE IsNot Nothing Then
                            If dao_debtor.fields.BILL_NUMBER <> Nothing Or dao_debtor.fields.BILL_NUMBER <> "" Then
                                If type_debt = 3 Then
                                    txt_RETURN_DESCRIPTION1.Text = "รับคืนใบสำคัญลูกหนี้เงินนอกงบประมาณ_บย." & strNumeric & " บค."
                                Else
                                    txt_RETURN_DESCRIPTION1.Text = "รับคืนใบสำคัญลูกหนี้เงินงบประมาณ_บย." & strNumeric & " บค."
                                End If

                            End If
                            'End If
                        Else
                            If dao_debtor.fields.BILL_NUMBER <> Nothing And dao_debtor.fields.BILL_NUMBER <> "" Then
                                txt_RETURN_DESCRIPTION1.Text = "รับคืนใบสำคัญลูกหนี้เงินทดรอง_บย." & strNumeric & " บค."
                            End If

                        End If
                    End If
                Else
                    If dao_debtor.fields.BILL_NUMBER <> Nothing Or dao_debtor.fields.BILL_NUMBER <> "" Then
                        If type_debt = 3 Then
                            txt_RETURN_DESCRIPTION1.Text = "รับคืนใบสำคัญลูกหนี้เงินนอกงบประมาณ_บย." & strNumeric & " บค."
                        Else
                            txt_RETURN_DESCRIPTION1.Text = "รับคืนใบสำคัญลูกหนี้เงินงบประมาณ_บย." & strNumeric & " บค."
                        End If

                    End If

                End If

            ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 2 Then
                If flag_margin = True Then
                    If dao_debtor.fields.REBILL_ID = 1 Then
                        'If dao_debtor.fields.MOVEDATE IsNot Nothing Then
                        If dao_debtor.fields.BILL_NUMBER <> Nothing Or dao_debtor.fields.BILL_NUMBER <> "" Then
                            If type_debt = 3 Then
                                txt_RETURN_DESCRIPTION1.Text = "รับคืนเงินลูกหนี้เงินนอกงบประมาณ_บย." & strNumeric & " บร."
                            Else
                                txt_RETURN_DESCRIPTION1.Text = "รับคืนเงินลูกหนี้เงินงบประมาณ_บย." & strNumeric & " บร."
                            End If


                        End If
                        'End If
                    Else

                        If dao_debtor.fields.BILL_NUMBER <> Nothing Or dao_debtor.fields.BILL_NUMBER <> "" Then
                            txt_RETURN_DESCRIPTION1.Text = "รับคืนเงินลูกหนี้เงินทดรอง_บย." & strNumeric & " บร."
                        End If
                    End If
            Else
                If dao_debtor.fields.BILL_NUMBER <> Nothing Or dao_debtor.fields.BILL_NUMBER <> "" Then
                    If type_debt = 3 Then
                        txt_RETURN_DESCRIPTION1.Text = "รับคืนเงินลูกหนี้เงินนอกงบประมาณ_บย." & strNumeric & " บร."
                    Else
                        txt_RETURN_DESCRIPTION1.Text = "รับคืนเงินลูกหนี้เงินงบประมาณ_บย." & strNumeric & " บร."
                    End If

                End If

            End If

                Else
                    If dao_debtor.fields.BILL_NUMBER <> Nothing Or dao_debtor.fields.BILL_NUMBER <> "" Then
                        txt_RETURN_DESCRIPTION1.Text = ddl_MAS_RETURN_TYPE.SelectedItem.Text & "_บย." & strNumeric
                    End If


                End If

        End If

    End Sub

    Public Sub update(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        Dim id As Integer = 0
        'id = Request.QueryString("DEBTOR_BILL_ID")
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.DISBURSE_VOLUME = txt_DISBURSE_VOLUME.Text
        dao.fields.DISBURSE_NUMBER = txt_DISBURSE_NUMBER.Text
        dao.fields.RETURN_DESCRIPTION = txt_RETURN_DESCRIPTION1.Text
        dao.fields.RETURN_SUB_DESCRIPTION = txt_RETURN_DESCRIPTION.Text
        dao.fields.RETURN_AMOUNT = txt_RETURN_AMOUNT.Text
        dao.fields.RECEIVER_MONEY_ID = rc_id
            'dao.fields.DEBTOR_TYPE = 1 'ใส่ 1 เป็นลูกหนี้ งบประมาณ
        'dao.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID = id
        If txt_return_date.Text <> "" Then
            dao.fields.MONEY_RETURN_DATE = CDate(txt_return_date.Text)
        End If
        dao.fields.PAY_TYPE = ddl_MAS_RETURN_TYPE.SelectedValue
        If cb_IS_USE_OUTBUDGET.Checked = True Then
            dao.fields.IS_USE_OUTBUDGET = True
        Else
            dao.fields.IS_USE_OUTBUDGET = False
        End If

        If ddl_MAS_RETURN_TYPE.SelectedValue = 1 Then
            If txt_running_number.Text <> "" Then
                dao.fields.RECEIPT_NUMBER = txt_running_number.Text
            Else
                dao.fields.RECEIPT_NUMBER = Nothing
            End If

            dao.fields.ADD_BILL_DATE = Nothing
            dao.fields.SUB_PAY_TYPE = Nothing

        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 2 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            dao.fields.ADD_BILL_DATE = Nothing

            If rd_moneytype.SelectedValue <> "" Then
                dao.fields.SUB_PAY_TYPE = rd_moneytype.SelectedValue
            Else
                dao.fields.SUB_PAY_TYPE = Nothing
            End If
            Dim bool As Boolean = False
            bool = Check_overlap()
            If bool = True Then
                dao.fields.OVERLAP_FLAG = 1
                If txt_Reson.Text <> "" Then
                    dao.fields.OVERLAP_REASON = txt_Reson.Text
                End If
            Else
                dao.fields.OVERLAP_FLAG = 0
            End If

        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 3 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            If txt_today_date.Text <> "" Then
                dao.fields.ADD_BILL_DATE = CDate(txt_today_date.Text)
                'update movedate เบิกเพิ่ม (เอาออก)
                'dao.fields.MOVEDATE = CDate(txt_today_date.Text)
            End If
            If rd_moneytype.SelectedValue <> "" Then
                dao.fields.SUB_PAY_TYPE = rd_moneytype.SelectedValue
            End If

        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue > 3 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            If txt_today_date.Text <> "" Then
                dao.fields.ADD_BILL_DATE = CDate(txt_today_date.Text)
            End If
            dao.fields.SUB_PAY_TYPE = Nothing

        End If


    End Sub

    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        'dao.fields.
        Dim id As Integer = 0
        id = Request.QueryString("DEBTOR_BILL_ID")
        If txt_DOC_DATE.Text <> "" Then
            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        End If
        If cb_IS_USE_OUTBUDGET.Checked = True Then
            dao.fields.IS_USE_OUTBUDGET = True
        Else
            dao.fields.IS_USE_OUTBUDGET = False
        End If
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.DISBURSE_VOLUME = txt_DISBURSE_VOLUME.Text
        dao.fields.DISBURSE_NUMBER = txt_DISBURSE_NUMBER.Text
        dao.fields.RETURN_DESCRIPTION = txt_RETURN_DESCRIPTION1.Text
        dao.fields.RETURN_SUB_DESCRIPTION = txt_RETURN_DESCRIPTION.Text
        dao.fields.RETURN_AMOUNT = txt_RETURN_AMOUNT.Text
        dao.fields.RECEIVER_MONEY_ID = rc_id
        'dao.fields.DEBTOR_TYPE = 1 'ใส่ 1 เป็นลูกหนี้ งบประมาณ
        dao.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID = id
        If txt_return_date.Text <> "" Then
            dao.fields.MONEY_RETURN_DATE = CDate(txt_return_date.Text)
        End If
        If ddl_MAS_RETURN_TYPE.SelectedValue <> "" Then
            dao.fields.PAY_TYPE = ddl_MAS_RETURN_TYPE.SelectedValue
        End If

        If ddl_MAS_RETURN_TYPE.SelectedValue = 1 Then
            If txt_running_number.Text <> "" Then
                dao.fields.RECEIPT_NUMBER = txt_running_number.Text
            End If
            dao.fields.ADD_BILL_DATE = Nothing
            dao.fields.SUB_PAY_TYPE = Nothing

        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 2 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            dao.fields.ADD_BILL_DATE = Nothing
            If rd_moneytype.SelectedValue <> "" Then
                dao.fields.SUB_PAY_TYPE = rd_moneytype.SelectedValue
            End If
            Dim bool As Boolean = False
            bool = Check_overlap()
            If bool = True Then
                dao.fields.OVERLAP_FLAG = 1
                dao.fields.OVERLAP_REASON = txt_Reson.Text
            Else
                dao.fields.OVERLAP_FLAG = 0
            End If
        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 3 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            If txt_today_date.Text <> "" Then
                dao.fields.ADD_BILL_DATE = CDate(txt_today_date.Text)
            End If
            ''เพิ่มโค้ดไป update movedate เมื่อเบิกเพิ่ม
            'If txt_return_date.Text <> "" Then
            '    dao.fields.MOVEDATE = CDate(txt_return_date.Text)
            'End If
            If rd_moneytype.SelectedValue <> "" Then
                dao.fields.SUB_PAY_TYPE = rd_moneytype.SelectedValue
            End If

        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue > 3 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            If txt_today_date.Text <> "" Then
                dao.fields.ADD_BILL_DATE = CDate(txt_today_date.Text)
            End If
            dao.fields.SUB_PAY_TYPE = Nothing

        End If

    End Sub
    Public Sub getdata_debtor(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        Try
            txt_DOC_DATE.Text = dao.fields.DOC_DATE
            txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
            txt_DISBURSE_VOLUME.Text = dao.fields.DISBURSE_VOLUME
            txt_DISBURSE_NUMBER.Text = dao.fields.DISBURSE_NUMBER
        Catch ex As Exception

        End Try


        'Dim strDescription As String = dao.fields.RETURN_DESCRIPTION
        'Dim arr As String() = strDescription.Split("|")
        'Try
        '    If arr(1) IsNot Nothing Then
        '        txt_RETURN_DESCRIPTION1.Text = arr(0)
        '        txt_RETURN_DESCRIPTION.Text = arr(1)
        '    End If
        'Catch ex As Exception
        '    txt_RETURN_DESCRIPTION1.Text = arr(0)
        'End Try
        txt_RETURN_DESCRIPTION1.Text = dao.fields.RETURN_DESCRIPTION
        txt_RETURN_DESCRIPTION.Text = dao.fields.RETURN_SUB_DESCRIPTION

        If dao.fields.IS_USE_OUTBUDGET IsNot Nothing Then
            If dao.fields.IS_USE_OUTBUDGET = True Then
                cb_IS_USE_OUTBUDGET.Checked = True
            Else
                cb_IS_USE_OUTBUDGET.Checked = False
            End If
        Else
            cb_IS_USE_OUTBUDGET.Checked = False
        End If

        txt_RETURN_AMOUNT.Text = dao.fields.RETURN_AMOUNT
        ''lb_money_receiver_id.Text = dao.fields.RECEIVER_MONEY_ID
        Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        dao_rec.Getdata_by_RECEIVER_MONEY_ID(dao.fields.RECEIVER_MONEY_ID)
        If dao_rec.fields.RECEIVER_NAME IsNot Nothing Then
            lb_money_receiver.Text = dao_rec.fields.RECEIVER_NAME
        End If

        If dao.fields.MONEY_RETURN_DATE IsNot Nothing Then
            txt_return_date.Text = dao.fields.MONEY_RETURN_DATE
        End If

        If dao.fields.PAY_TYPE = 1 Then
            If dao.fields.RECEIPT_NUMBER IsNot Nothing Then
                txt_running_number.Text = dao.fields.RECEIPT_NUMBER
            End If
            dao.fields.ADD_BILL_DATE = Nothing
            dao.fields.SUB_PAY_TYPE = Nothing
        ElseIf dao.fields.PAY_TYPE = 2 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            dao.fields.ADD_BILL_DATE = Nothing
            If dao.fields.SUB_PAY_TYPE IsNot Nothing Then
                rd_moneytype.SelectedValue = dao.fields.SUB_PAY_TYPE
            End If
            If dao.fields.OVERLAP_REASON IsNot Nothing Then
                txt_Reson.Text = dao.fields.OVERLAP_REASON
            End If
        ElseIf dao.fields.PAY_TYPE = 3 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            If dao.fields.ADD_BILL_DATE IsNot Nothing Then
                txt_today_date.Text = dao.fields.ADD_BILL_DATE
            End If

            dao.fields.SUB_PAY_TYPE = Nothing
        ElseIf dao.fields.PAY_TYPE > 3 Then
            dao.fields.RECEIPT_NUMBER = Nothing
            If dao.fields.ADD_BILL_DATE IsNot Nothing Then
                txt_today_date.Text = dao.fields.ADD_BILL_DATE
            End If
            dao.fields.SUB_PAY_TYPE = Nothing
        End If
    End Sub

    Public Sub insert_bill(ByVal return_id As Integer)
        If ddl_MAS_RETURN_TYPE.SelectedValue = 3 Then


            If rd_moneytype.SelectedValue <> "" Then
                
                If rd_moneytype.SelectedValue = 1 Then
                    Dim id As Integer = 0
                    id = Request.QueryString("DEBTOR_BILL_ID")
                    Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
                    Dim dao_debt_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                    dao_debtor.Getdata_by_DEBTOR_BILL_ID(id)

                    Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
                    Dim dao_bill_deail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                    Dim dao_margin As New DAO_DISBURSE.TB_BUDGET_BILL_MARGIN_DETAIL

                    Dim dao_return As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
                    dao_return.Getdata_by_RETURN_MONEY_DEBTOR_ID(return_id)

                    'If txt_today_date.Text <> "" Then
                    '    dao_bill.fields.BILL_DATE = CDate(txt_today_date.Text)
                    'End If
                    dao_bill.fields.BILL_NUMBER = ""
                    'dao_bill.fields.Bill_RECIEVE_DATE = dao_debtor.fields.Bill_RECIEVE_DATE
                    dao_bill.fields.DEPARTMENT_ID = dao_debtor.fields.DEPARTMENT_ID
                    dao_bill.fields.DESCRIPTION = dao_return.fields.RETURN_DESCRIPTION
                    dao_bill.fields.DOC_DATE = dao_return.fields.DOC_DATE
                    dao_bill.fields.DOC_NUMBER = dao_return.fields.DOC_NUMBER
                    dao_bill.fields.PATLIST_ID = dao_debtor.fields.PAYLIST_ID
                        dao_bill.fields.BUDGET_USE_ID = dao_debtor.fields.BUDGET_USE_ID
                        dao_bill.fields.BUDGET_PLAN_ID = dao_debtor.fields.BUDGET_PLAN_ID
                        dao_bill.fields.BUDGET_YEAR = dao_debtor.fields.BUDGET_YEAR
                        'dao_bill.fields.USER_AD = dao_debtor.fields.USER_AD
                        dao_bill.fields.CHECK_APPROVE = False
                        dao_bill.fields.DEBTOR_ID = 0
                        dao_bill.fields.RETURN_MONEY_ID = return_id
                        dao_bill.fields.IS_CHECK_RECEIVE = False
                        dao_bill.fields.PAY_TYPE_ID = 0
                        dao_bill.fields.IS_APPROVE = False
                        dao_bill.fields.IS_PO = False
                        dao_bill.fields.MAX_PRIZE = txt_RETURN_AMOUNT.Value
                        dao_bill.fields.CUSTOMER_ID = 0
                        dao_bill.fields.CUSTOMER_TYPE_ID = 1
                        dao_bill.fields.BILL_DATE = System.DateTime.Now()

                        dao_bill.insert()

                        Dim id_insert As Integer = dao_bill.fields.BUDGET_DISBURSE_BILL_ID

                        dao_bill_deail.fields.BUDGET_DISBURSE_BILL_ID = id_insert
                        dao_bill_deail.fields.AMOUNT = txt_RETURN_AMOUNT.Value
                        dao_bill_deail.insert()

                        Dim dao_main As New DAO_DISBURSE.TB_BUDGET_BILL
                        dao_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(id_insert)
                        dao_main.fields.MAIN_BILL = id_insert
                        dao_main.update()
                        'ElseIf rd_moneytype.SelectedValue = 2 Then
                        '    dao_bill_deail.fields.BUDGET_DISBURSE_BILL_ID = id_insert
                        '    dao_bill_deail.fields.AMOUNT = txt_RETURN_AMOUNT.Value
                        '    dao_margin.fields.BUDGET_DISBURSE_BILL_ID = id_insert
                        '    dao_margin.fields.AMOUNT = txt_RETURN_AMOUNT.Value
                        '    dao_bill_deail.insert()
                        '    dao_margin.insert()
                    End If

                End If
            End If
    End Sub

    Public Sub getdata(ByRef bao As BAO_BUDGET.Maintain)
        Dim dt As DataTable = bao.get_DEBTOR_BILL_in_BUDGET_by_DEBTOR_BILL_ID(Request.QueryString("DEBTOR_BILL_ID"))
        If dt.Rows.Count > 0 Then
            Dim doc_date As String = ""
            Dim returndate As String = ""
            If IsDBNull(dt(0).Item("DOC_DATE")) = False Then
                doc_date = dt(0)("DOC_DATE")
            End If
            If IsDBNull(dt(0)("MONEY_RETURN_DATE")) = False Then
                returndate = dt(0)("MONEY_RETURN_DATE")
            End If
            txt_DOC_DATE.Text = dt(0)("DOC_DATE")
            txt_DOC_NUMBER.Text = dt(0)("DOC_NUMBER")
            txt_DISBURSE_VOLUME.Text = dt(0)("DISBURSE_VOLUME")
            txt_DISBURSE_NUMBER.Text = dt(0)("DISBURSE_NUMBER")
            txt_RETURN_DESCRIPTION.Text = dt(0)("RETURN_DESCRIPTION")
            txt_RETURN_AMOUNT.Text = dt(0)("RETURN_AMOUNT")
            'txt_RECEIVER_NAME.Text = dt(0)("RECEIVER_NAME")
            txt_return_date.Text = returndate
        End If

    End Sub

    'Private Sub ddl_MAS_RETURN_TYPE_TextChanged(sender As Object, e As EventArgs) Handles ddl_MAS_RETURN_TYPE.TextChanged
    '    bindcontrol()
    '    set_textbox()
    'End Sub
    Public Sub bindcontrol()
        Dim id_debt As Integer
        id_debt = Request.QueryString("DEBTOR_BILL_ID")
        Dim dao_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao_debtor.Getdata_by_DEBTOR_BILL_ID(id_debt)
        ddl_MAS_RETURN_TYPE.DataBind()
        If ddl_MAS_RETURN_TYPE.SelectedValue = 1 Then
            Dim bao As New BAO_BUDGET.MASS
            'Dim bgyear As Integer = Request.QueryString("bgyear")
            'Dim bgyear As Integer = bgyear
            If dao_debtor.fields.DEBTOR_TYPE_ID = 1 Then
                If txt_running_number.Text = "" Then
                    txt_running_number.Text = (bao.get_max_num_return_debtor(dao_debtor.fields.BUDGET_YEAR) + 1)
                End If
                txt_running_number.Style.Add("display", "block")
            Else
                'txt_running_number.Text = (bao.get_max_num_return_debtor(bgyear) + 1)
                txt_running_number.Style.Add("display", "block")
            End If
            
            lb_pay_type_chg.Style.Add("display", "block")
            lb_pay_type_chg.Text = "บท.เลขที่"
            txt_today_date.Style.Add("display", "none")
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "key", "setDisableDate();", True)

            lb_money_type.Style.Add("display", "none")
            rd_moneytype.Style.Add("display", "none")
            btn_print.Style.Add("display", "none")
        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 2 Then
            txt_running_number.Style.Add("display", "none")
            lb_money_type.Style.Add("display", "block")
            rd_moneytype.Style.Add("display", "block")
            lb_pay_type_chg.Style.Add("display", "none")
            txt_today_date.Style.Add("display", "none")
            btn_print.Style.Add("display", "block")
            '  System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "key", "setDisableDate();", True)
        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue = 3 Then
            txt_running_number.Style.Add("display", "none")
            lb_pay_type_chg.Style.Add("display", "block")
            lb_pay_type_chg.Text = "เบิกเพิ่ม"
            txt_today_date.Style.Add("display", "block")

            lb_money_type.Style.Add("display", "block")
            rd_moneytype.Style.Add("display", "block")
            btn_print.Style.Add("display", "none")
        ElseIf ddl_MAS_RETURN_TYPE.SelectedValue > 3 Then
            txt_running_number.Style.Add("display", "none")
            lb_pay_type_chg.Style.Add("display", "block")
            lb_pay_type_chg.Text = "วันที่" & ddl_MAS_RETURN_TYPE.SelectedItem.Text
            txt_today_date.Style.Add("display", "block")

            lb_money_type.Style.Add("display", "none")
            rd_moneytype.Style.Add("display", "none")
            btn_print.Style.Add("display", "block")
        End If
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click

    End Sub

    Private Sub ddl_MAS_RETURN_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_MAS_RETURN_TYPE.SelectedIndexChanged
        bindcontrol()
        set_textbox()
    End Sub

    Private Sub txt_RETURN_AMOUNT_TextChanged(sender As Object, e As EventArgs) Handles txt_RETURN_AMOUNT.TextChanged
        cal_percent()
        'Dim bool As Boolean = False
        'bool = Check_overlap()
        'If bool = True Then
        '    lb_reason.Style.Add("Display", "block")
        '    txt_Reson.Style.Add("Display", "block")
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คำเตือน ท่านกำลังคืนเงินสดเกิน 25%');", True)
        'Else
        '    lb_reason.Style.Add("Display", "none")
        '    txt_Reson.Style.Add("Display", "none")
        'End If

    End Sub
    Public Sub cal_percent()
        Dim id As String = ""
        id = Request.QueryString("DEBTOR_BILL_ID")
        Dim amount As Double = 0
        If txt_RETURN_AMOUNT.Value <> 0 Then
            Dim dao_debt As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao_debt.Getdata_by_DEBTOR_BILL_ID(id)
            If dao_debt.fields.DEBTOR_BILL_ID <> Nothing Then
                'If dao_debt.fields.DEBTOR_TYPE_ID = 1 Then
                '    Dim dao_margin As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
                '    dao_margin.Getdata_by_DEBTOR_BILL_ID(dao_debt.fields.DEBTOR_BILL_ID)
                '    amount = dao_margin.fields.AMOUNT
                'Else
                Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                dao_detail.Getdata_by_DEBTOR_BILL_ID(dao_debt.fields.DEBTOR_BILL_ID)
                amount = dao_detail.fields.AMOUNT
                'End If
            End If
            Dim cal As Double = 0.0
            cal = (txt_RETURN_AMOUNT.Value / amount) '* 100
            lb_percent.Text = cal.ToString("P")
        End If
    End Sub
    Public Function Check_overlap() As Boolean
        Dim bool As Boolean = False
        Dim id As String = ""
        id = Request.QueryString("DEBTOR_BILL_ID")
        Dim amount As Double = 0
        If ddl_MAS_RETURN_TYPE.SelectedValue = 2 Then
            If txt_RETURN_AMOUNT.Value <> 0 Then
                Dim dao_debt As New DAO_DISBURSE.TB_DEBTOR_BILL
                dao_debt.Getdata_by_DEBTOR_BILL_ID(id)
                If dao_debt.fields.DEBTOR_BILL_ID <> Nothing Then
                    If dao_debt.fields.DEBTOR_TYPE_ID = 1 Then
                        Dim dao_margin As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                        dao_margin.Getdata_by_DEBTOR_BILL_ID(dao_debt.fields.DEBTOR_BILL_ID)
                        amount = dao_margin.fields.AMOUNT
                    Else
                        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                        dao_detail.Getdata_by_DEBTOR_BILL_ID(dao_debt.fields.DEBTOR_BILL_ID)
                        amount = dao_detail.fields.AMOUNT
                    End If
                End If
                Dim cal As Double = 0.0
                cal = (txt_RETURN_AMOUNT.Value / amount) * 100

                If amount > 0 Then
                    If cal > 25 Then
                        bool = True
                    Else
                        bool = False
                    End If
                End If

            End If
        End If
        Return bool
    End Function

End Class