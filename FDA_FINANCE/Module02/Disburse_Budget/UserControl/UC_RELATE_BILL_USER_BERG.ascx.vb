Imports Telerik.Web.UI
Public Class UC_RELATE_BILL_USER_BERG
    Inherits System.Web.UI.UserControl
    Private _relate_id As String
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer

    Sub runQuery()
        _relate_id = Request.QueryString("bid")
        _dept = Request.QueryString("dept")
        bgYear = Request.QueryString("myear")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub get_data(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_ALL)
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString()
        End If
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION
        'If dao.fields.DO_DATE IsNot Nothing Then
        '    txt_dodate.Text = CDate(dao.fields.DO_DATE).ToShortDateString()
        'End If
        Dim str_type As String = ""

        Try
            If dao.fields.RELATE_TYPE = 1 Then
                str_type = "เบิกจ่าย"
            ElseIf dao.fields.RELATE_TYPE = 1 Then
                str_type = "เงินยืม"
            ElseIf dao.fields.RELATE_TYPE = 1 Then
                str_type = "ก่อหนี้ผูกพัน (PO)"
            End If
        Catch ex As Exception

        End Try

        lb_type.Text = str_type
        Try
            Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
            dao_head.Getdata_by_BUDGET_PLAN_ID(dao.fields.BUDGET_ID)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        'If Request.QueryString("bid") <> "" Then
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        'dt = bao.SC_get_relate_det_by_id(Request.QueryString("bid"))
        dt = bao.SC_get_relate_det_by_id(_relate_id)
        dt.Columns.Add("balance", GetType(Double))
        'End If
        For Each dr As DataRow In dt.Rows
            Dim dao_bi As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bi.Getdata_by_RELATE_ID(_relate_id)
         
            Dim pay_amount As Double = 0 ' get_bill_det_amount()
            For Each dao_bi.fields In dao_bi.datas
                pay_amount += get_bill_det_amount(dao_bi.fields.BUDGET_DISBURSE_BILL_ID, dr("GL_ID"))
            Next
            Dim amount_all As Double = 0
            'Dim dao_det_re As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
            'dao_det_re.Getdata_by_Relate_id_gl(_relate_id, dr("GL_ID"))
            'For Each dao_det_re.fields In dao_det_re.datas
            '    amount_all += dao_det_re.fields.AMOUNT
            'Next
            Try
                amount_all = dr("AMOUNT")
            Catch ex As Exception

            End Try
            Dim balance As Double = 0
            balance = amount_all - pay_amount
            dr("balance") = balance
        Next
        
        RadGrid1.DataSource = dt
    End Sub

    Public Sub insert_det()
        If _relate_id <> "" Then
            Dim dao_re As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao_re.Getdata_by_ID(_relate_id)
            Dim dao_det_re As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
            dao_det_re.Getdata_by_Relate_id(_relate_id)

            If dao_re.fields.RELATE_TYPE = "1" Then
                Dim i As Integer = 0
                Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
                i = dao_count.count_relate_id(_relate_id)

                'Dim dao_bi As New DAO_DISBURSE.TB_BUDGET_BILL
                'dao_bi.Getdata_by_RELATE_ID(_relate_id)
                'Dim pay_amount As Double = 0 ' get_bill_det_amount()
                'For Each dao_bi.fields In dao_bi.datas
                '    pay_amount += get_bill_det_amount(dao_bi.fields.BUDGET_DISBURSE_BILL_ID, dao_det_re.fields.GL_ID)
                'Next
                'Dim amount_all As Double = 0
                'For Each dao_det_re.fields In dao_det_re.datas
                '    amount_all += dao_det_re.fields.AMOUNT
                'Next

                'Dim balance As Double = 0
                'balance = amount_all - pay_amount

                'If i = 0 Then
                If check_over() = True Then
                    If check_value() = True Then
                        Dim dao_b As New DAO_DISBURSE.TB_BUDGET_BILL

                        insert_bill(dao_b, _relate_id)
                        dao_b.fields.PAY_TYPE_ID = 0

                        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                        dao_c.Getdata_by_ID(_relate_id)
                        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                        dao_b.fields.BILL_NUMBER = "" 'bao.get_max_bill(dao_c.fields.BUDGET_YEAR) + 1
                        dao_b.fields.DEBTOR_ID = 0
                        dao_b.fields.CUSTOMER_TYPE_ID = 0
                        dao_b.fields.RETURN_MONEY_ID = 0
                        dao_b.fields.IS_PO = False
                        'dao_b.fields.IS_APPROVE = False
                        'dao_b.fields.APPROVE_DATE = Nothing
                        dao_b.fields.BUDGET_USE_ID = 1
                        dao_b.fields.IS_APPROVE = True
                        dao_b.fields.APPROVE_DATE = Date.Now
                        dao_b.fields.DEEKA_NUMBER = ""
                        dao_b.fields.STATUS_ID = 1
                        dao_b.fields.GROUP_ID = 0
                        dao_b.fields.RELATE_ID = _relate_id
                        dao_b.fields.DESCRIPTION = txt_DESCRIPTION.Text 'dao_c.fields.DESCRIPTION
                        Try
                            dao_b.fields.DOC_DATE = CDate(txt_DOC_DATE.Text) 'dao_c.fields.DOC_DATE
                        Catch ex As Exception

                        End Try

                        dao_b.fields.DOC_NUMBER = txt_DOC_NUMBER.Text 'dao_c.fields.DOC_NUMBER
                        dao_b.insert()

                        For Each item As GridDataItem In RadGrid1.Items
                            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg") 'DirectCast(item("berg").Controls(0), RadNumericTextBox)
                            Dim amount As Double = 0
                            Try
                                amount = CDbl(item("AMOUNT").Text)

                            Catch ex As Exception

                            End Try

                            Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                            dao_d.fields.AMOUNT = rnt_berg.Value
                            dao_d.fields.MAX_PRIZE = rnt_berg.Value
                            Try
                                dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(item("CUSTOMER_ID").Text, rnt_berg.Value)
                            Catch ex As Exception

                            End Try
                            dao_d.fields.BUDGET_DISBURSE_BILL_ID = dao_b.fields.BUDGET_DISBURSE_BILL_ID
                            dao_d.fields.IS_ENABLE = True
                            Try
                                dao_d.fields.CUSTOMER_ID = item("CUSTOMER_ID").Text
                            Catch ex As Exception

                            End Try
                            Try
                                dao_d.fields.GL_ID = item("GL_ID").Text
                            Catch ex As Exception

                            End Try
                            Try
                                dao_d.fields.BUDGET_PLAN_ID = item("BUDGET_PLAN_ID").Text
                            Catch ex As Exception

                            End Try
                            dao_d.insert()
                        Next

                        Dim dao3 As New DAO_DISBURSE.TB_BUDGET_BILL
                        dao3.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao_b.fields.BUDGET_DISBURSE_BILL_ID)
                        dao3.fields.MAIN_BILL = dao_b.fields.BUDGET_DISBURSE_BILL_ID
                        dao3.update()

                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ กรุณากรอกจำนวนเงิน');", True)
                    End If

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เนื่องจากกรอกจำนวนเงินไม่ถูกต้อง');", True)
                End If

                'Else
                '    Dim dao_b As New DAO_DISBURSE.TB_BUDGET_BILL
                '    Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                '    insert_bill(dao_b, _relate_id)
                '    dao_b.fields.PAY_TYPE_ID = 0

                '    Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                '    dao_c.Getdata_by_ID(_relate_id)

                '    dao_b.update()
                'End If
            ElseIf dao_re.fields.RELATE_TYPE = "2" Then
                Dim i As Integer = 0
                Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
                i = dao_count.count_relate_id(_relate_id)

                If check_over() = True Then
                    If check_value() = True Then
                        Dim dao_b As New DAO_DISBURSE.TB_DEBTOR_BILL

                        insert_debtor(dao_b, _relate_id)
                        dao_b.fields.PAY_TYPE_ID = 0

                        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                        dao_c.Getdata_by_ID(_relate_id)
                        dao_b.fields.BILL_NUMBER = ""
                        dao_b.fields.CUSTOMER_TYPE_ID = 0
                        dao_b.fields.BUDGET_USE_ID = 1
                        dao_b.fields.DEEKA_NUMBER = ""
                        dao_b.fields.DESCRIPTION = txt_DESCRIPTION.Text 'dao_c.fields.DESCRIPTION
                        Try
                            dao_b.fields.DOC_DATE = CDate(txt_DOC_DATE.Text) 'dao_c.fields.DOC_DATE
                        Catch ex As Exception

                        End Try

                        dao_b.fields.DOC_NUMBER = txt_DOC_NUMBER.Text 'dao_c.fields.DOC_NUMBER
                        dao_b.fields.STATUS_ID = 1
                        dao_b.fields.GROUP_ID = 0
                        dao_b.fields.RELATE_ID = _relate_id
                        dao_b.insert()
                        For Each item As GridDataItem In RadGrid1.Items
                            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg")
                            Dim dao_d As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL

                            dao_d.fields.AMOUNT = rnt_berg.Value
                            Try
                                dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(item("CUSTOMER_ID").Text, rnt_berg.Value)
                            Catch ex As Exception

                            End Try
                            dao_d.fields.DEBTOR_BILL_ID = dao_b.fields.DEBTOR_BILL_ID
                            dao_d.fields.IS_ENABLE = True
                            Try
                                dao_d.fields.CUSTOMER_ID = item("CUSTOMER_ID").Text
                            Catch ex As Exception

                            End Try
                            Try
                                dao_d.fields.GL_ID = item("GL_ID").Text
                            Catch ex As Exception

                            End Try
                            Try
                                dao_d.fields.BUDGET_PLAN_ID = item("BUDGET_PLAN_ID").Text
                            Catch ex As Exception

                            End Try
                            dao_d.insert()

                        Next

                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ กรุณากรอกจำนวนเงิน');", True)
                    End If

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เนื่องจากกรอกจำนวนเงินไม่ถูกต้อง');", True)
                End If
 
                    ElseIf dao_re.fields.RELATE_TYPE = "3" Then
                        Dim i As Integer = 0
                        Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
                        i = dao_count.count_relate_id(_relate_id)
                If check_over() = True Then
                    If check_value() = True Then
                        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                        dao_c.Getdata_by_ID(_relate_id)

                        dao.fields.DEBTOR_ID = 0
                        dao.fields.CUSTOMER_TYPE_ID = 0
                        dao.fields.RETURN_MONEY_ID = 0
                        dao.fields.APPROVE_DATE = dao_c.fields.APPROVE_DATE
                        dao.fields.BILL_DATE = dao_c.fields.DO_DATE
                        dao.fields.CUSTOMER_ID = dao_c.fields.CUSTOMER_ID
                        dao.fields.Bill_RECIEVE_DATE = dao_c.fields.DO_DATE
                        dao.fields.BUDGET_PLAN_ID = dao_c.fields.BUDGET_ID
                        dao.fields.BUDGET_USE_ID = 1
                        dao.fields.BUDGET_YEAR = dao_c.fields.BUDGET_YEAR
                        dao.fields.DEPARTMENT_ID = dao_c.fields.DEPARTMENT_ID
                        dao.fields.DESCRIPTION = txt_DESCRIPTION.Text 'dao_c.fields.DESCRIPTION
                        Try
                            dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text) 'dao_c.fields.DOC_DATE
                        Catch ex As Exception

                        End Try

                        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text 'dao_c.fields.DOC_NUMBER
                        dao.fields.IS_APPROVE = True
                        dao.fields.APPROVE_DATE = dao_c.fields.APPROVE_DATE
                        dao.fields.PATLIST_ID = dao_c.fields.PAYLIST_ID
                        dao.fields.USER_ID = dao_c.fields.CUSTOMER_ID
                        dao.fields.MAX_PRIZE = dao_c.fields.APPROVE_AMOUNT
                        dao.fields.EGP_NUMBER = dao_c.fields.EGP_NUMBER
                        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                        dao.fields.BILL_NUMBER = "" 'bao.get_max_bill(dao_c.fields.BUDGET_YEAR) + 1
                        dao.fields.PAY_TYPE_ID = 0
                        dao.fields.STATUS_ID = 1
                        dao.fields.GROUP_ID = 0
                        dao.fields.IS_PO = True
                        dao.fields.RELATE_ID = _relate_id
                        dao.insert()

                        Try
                            Dim dao_m As New DAO_DISBURSE.TB_BUDGET_BILL
                            dao_m.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_DISBURSE_BILL_ID)
                            dao_m.fields.MAIN_BILL = dao.fields.MAIN_BILL
                            dao_m.update()
                        Catch ex As Exception

                        End Try

                        For Each item As GridDataItem In RadGrid1.Items
                            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg") 'DirectCast(item("berg").Controls(0), RadNumericTextBox)
                            'Dim amount As Double = 0
                            'Try
                            '    amount = CDbl(item("AMOUNT").Text)

                            'Catch ex As Exception

                            'End Try

                            Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                            dao_d.fields.AMOUNT = rnt_berg.Value
                            dao_d.fields.MAX_PRIZE = rnt_berg.Value
                            Try
                                dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(item("CUSTOMER_ID").Text, rnt_berg.Value)
                            Catch ex As Exception

                            End Try
                            dao_d.fields.BUDGET_DISBURSE_BILL_ID = dao.fields.BUDGET_DISBURSE_BILL_ID
                            dao_d.fields.IS_ENABLE = True
                            Try
                                dao_d.fields.CUSTOMER_ID = item("CUSTOMER_ID").Text
                            Catch ex As Exception

                            End Try
                            Try
                                dao_d.fields.GL_ID = item("GL_ID").Text
                            Catch ex As Exception

                            End Try
                            Try
                                dao_d.fields.BUDGET_PLAN_ID = item("BUDGET_PLAN_ID").Text
                            Catch ex As Exception

                            End Try
                            dao_d.insert()
                        Next
                        'Dim dao_r_d As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                        'dao_r_d.Getdata_by_Relate_id(_relate_id)
                        'For Each dao_r_d.fields In dao_r_d.datas
                        '    Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

                        '    dao_d.fields.AMOUNT = dao_r_d.fields.AMOUNT
                        '    dao_d.fields.MAX_PRIZE = dao_r_d.fields.AMOUNT
                        '    Try
                        '        dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(dao_r_d.fields.CUSTOMER_ID, dao_r_d.fields.AMOUNT)
                        '    Catch ex As Exception

                        '    End Try
                        '    dao_d.fields.BUDGET_DISBURSE_BILL_ID = dao.fields.BUDGET_DISBURSE_BILL_ID
                        '    dao_d.fields.IS_ENABLE = True
                        '    dao_d.fields.CUSTOMER_ID = dao_r_d.fields.CUSTOMER_ID
                        '    dao_d.fields.GL_ID = dao_r_d.fields.GL_ID
                        '    dao_d.fields.BUDGET_PLAN_ID = dao_r_d.fields.BUDGET_PLAN_ID
                        '    dao_d.insert()
                        'Next

                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ กรุณากรอกจำนวนเงิน');", True)
                    End If

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกได้ เนื่องจากกรอกจำนวนเงินไม่ถูกต้อง');", True)
                End If
            End If
        End If

    End Sub
    Public Function check_over() As Boolean
        Dim bool As Boolean = True
        Dim count_false As Integer = 0
        For Each item As GridDataItem In RadGrid1.Items
            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg") 'DirectCast(item("berg").Controls(0), RadNumericTextBox)

            Try
                If rnt_berg.Value > CDbl(item("AMOUNT").Text) Then
                    count_false += 1

                End If
            Catch ex As Exception

            End Try
           
        Next
        If count_false > 0 Then
            bool = False
        End If
        Return bool
    End Function
    Public Function check_value() As Boolean
        Dim bool As Boolean = True
        Dim amount As Double = 0
        Dim count_false As Integer = 0
        For Each item As GridDataItem In RadGrid1.Items
            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg") 'DirectCast(item("berg").Controls(0), RadNumericTextBox)

            Try
                amount += rnt_berg.Value
            Catch ex As Exception

            End Try
            
        Next
        If amount = 0 Then
            bool = False
        End If
        Return bool
    End Function

    Public Function cal_tax_by_customer_type(ByVal cus_type_id As Integer, ByVal amount As Double) As Double
        Dim dao As New DAO_MAS.TB_MAS_CUSTOMER_TYPE
        dao.Getdata_by_CUSTOMER_TYPE_ID(cus_type_id)
        Dim amount_without_vat As Double = 0
        Dim vat As Double = 0
        Dim tax As Double = 0
        Dim TAX_AMOUNT As Double = 0
        If dao.fields.VAT = 0.07 Then
            vat = amount * (7 / 107)
            amount_without_vat = amount - vat
        Else
            amount_without_vat = amount
        End If
        If dao.fields.CAL_FLAG = 1 Then
            If amount > 500 Then
                If dao.fields.TAX IsNot Nothing Then
                    tax = (amount_without_vat * CDec(dao.fields.TAX))
                    TAX_AMOUNT = tax
                End If
            Else
                If dao.fields.TAX IsNot Nothing Then
                    TAX_AMOUNT = 0
                End If
            End If
        Else
            If dao.fields.TAX_TYPE = 5 Then
                If cus_type_id = 7 Then

                Else
                    If amount > 10000 Then
                        If dao.fields.TAX IsNot Nothing Then
                            tax = (amount_without_vat * CDec(dao.fields.TAX))
                            TAX_AMOUNT = tax
                        End If
                    Else
                        If dao.fields.TAX IsNot Nothing Then
                            TAX_AMOUNT = 0
                        End If
                    End If
                End If

            ElseIf dao.fields.TAX_TYPE = 4 Then
                TAX_AMOUNT = 0
            ElseIf dao.fields.TAX_TYPE = 1 Then
                If amount > 500 Then
                    tax = (amount_without_vat * CDec(dao.fields.TAX))
                    TAX_AMOUNT = tax
                Else
                    TAX_AMOUNT = 0
                End If
            End If
        End If
        Return TAX_AMOUNT
    End Function
    Private Sub insert_bill(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL, ByVal relate_id As Integer)
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(relate_id)
        dao.fields.BILL_DATE = dao_c.fields.DO_DATE
        dao.fields.BUDGET_PLAN_ID = dao_c.fields.BUDGET_ID
        dao.fields.CUSTOMER_ID = dao_c.fields.CUSTOMER_ID
        dao.fields.Bill_RECIEVE_DATE = dao_c.fields.DO_DATE
        dao.fields.BUDGET_PLAN_ID = dao_c.fields.BUDGET_ID
        dao.fields.BUDGET_YEAR = dao_c.fields.BUDGET_YEAR
        dao.fields.DEPARTMENT_ID = dao_c.fields.DEPARTMENT_ID
        dao.fields.DESCRIPTION = dao_c.fields.DESCRIPTION
        dao.fields.DOC_DATE = dao_c.fields.DOC_DATE
        dao.fields.DOC_NUMBER = dao_c.fields.DOC_NUMBER
        dao.fields.PATLIST_ID = dao_c.fields.PAYLIST_ID
        dao.fields.USER_ID = dao_c.fields.CUSTOMER_ID
        dao.fields.MAX_PRIZE = dao_c.fields.APPROVE_AMOUNT
        dao.fields.GL_ID = dao_c.fields.PAYLIST_ID

    End Sub
    Private Sub insert_debtor(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL, ByVal relate_id As Integer)
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(relate_id)
        dao.fields.BILL_DATE = dao_c.fields.DO_DATE
        dao.fields.USER_ID = dao_c.fields.CUSTOMER_ID
        dao.fields.Bill_RECIEVE_DATE = dao_c.fields.DO_DATE
        dao.fields.BUDGET_PLAN_ID = dao_c.fields.BUDGET_ID
        dao.fields.BUDGET_YEAR = dao_c.fields.BUDGET_YEAR
        dao.fields.DEPARTMENT_ID = dao_c.fields.DEPARTMENT_ID
        dao.fields.DESCRIPTION = dao_c.fields.DESCRIPTION
        dao.fields.DOC_DATE = dao_c.fields.DOC_DATE
        dao.fields.DOC_NUMBER = dao_c.fields.DOC_NUMBER
        dao.fields.PAYLIST_ID = dao_c.fields.PAYLIST_ID
        dao.fields.USER_ID = dao_c.fields.CUSTOMER_ID
        dao.fields.GL_ID = dao_c.fields.PAYLIST_ID
        dao.fields.BUDGET_PLAN_ID = dao_c.fields.BUDGET_ID
    End Sub

    Public Function get_bill_det_amount(ByVal id_bill As Integer, ByVal GL_ID As Integer) As Double
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao.Getdata_by_Disburse_id_gl(id_bill, GL_ID)
        Dim total As Double = 0
        For Each dao.fields In dao.datas
            Try
                total += dao.fields.AMOUNT
            Catch ex As Exception

            End Try
        Next

        Return total
    End Function
    Public Function get_bill_PO_det_amount(ByVal id_bill As Integer, ByVal GL_ID As Integer) As Double
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao.Getdata_by_Disburse_id_gl(id_bill, GL_ID)
        Dim total As Double = 0
        For Each dao.fields In dao.datas
            Try
                total += dao.fields.AMOUNT
            Catch ex As Exception

            End Try
        Next

        Return total
    End Function
End Class