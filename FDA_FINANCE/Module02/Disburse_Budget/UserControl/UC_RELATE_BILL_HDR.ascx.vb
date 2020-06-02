Imports Telerik.Web.UI


Public Class UC_RELATE_BILL_HDR
    Inherits System.Web.UI.UserControl
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
    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property
    Private _bg_use As Integer
    Public Property bg_use() As Integer
        Get
            Return _bg_use
        End Get
        Set(ByVal value As Integer)
            _bg_use = value
        End Set
    End Property

    Private _ProId As String
    Public Property ProId() As String
        Get
            Return _ProId
        End Get
        Set(ByVal value As String)
            _ProId = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_relate_Init(sender As Object, e As EventArgs) Handles rg_relate.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_relate
        Rad_Utility.addColumnBound("RELATE_ID", "RELATE_ID", False)
        Rad_Utility.addColumnIMG("img", "การอนุมัติ", Display:=False)
        Rad_Utility.addColumnBound("RowNumber", "ลำดับ", width:=70)
        Rad_Utility.addColumnBound("app", "app", False)
        Rad_Utility.addColumnBound("RELATE_TYPE", "RELATE_TYPE", False)
        'Rad_Utility.addColumnDate("DO_DATE", "วันที่ทำรายการ")
        'Rad_Utility.addColumnBound("RECEIVE_FULL_NUMBER", "เลขที่รับเรื่อง")
        'Rad_Utility.addColumnDate("RECEIVE_DATE", "วันที่รับเรื่อง")
        Rad_Utility.addColumnBound("DOC_NUMBER", "เลขที่เอกสาร")
        Rad_Utility.addColumnDate("DOC_DATE", "วันที่เอกสาร")
        Rad_Utility.addColumnBound("DESCRIPTION", "เรื่อง", width:=300)
        Rad_Utility.addColumnBound("CUSTOMER_NAME2", "ผู้รับเงิน/เจ้าหนี้")
        Rad_Utility.addColumnBound("RELATE_TYPE_TEXT", "ประเภทผูกพัน")
        Rad_Utility.addColumnBound("sum_amount", "จำนวนเงินผูกพัน", is_money:=True, footer_txt:="รวม ", width:=150)
        Rad_Utility.addColumnBound("balance", "จำนวนเงินคงเหลือ", is_money:=True)

        'Rad_Utility.addColumnIMG("doo", "ดูข้อมูล", "doo", 0, "", img:=True, type_img:="review")
        'Rad_Utility.addColumnIMG("sel", "เลือกข้อมูล", "sel", 0, "", img:=True, type_img:="import")
        'Rad_Utility.addColumnButton("C", "ยืนยัน", "C", 0, "คำเตือน หากยืนยันการส่งไปแล้วจะไม่สามารถแก้ไขรายการกันเงินได้")
        Rad_Utility.addColumnBound("reason", "เหตุผลการไม่อนุมัติ")
        Rad_Utility.addColumnBound("status", "สถานะ")
        Rad_Utility.addColumnButton("send", "ยืนยันส่งเรื่อง", "send", 0, "คุณต้องการส่งเรื่องหรือไม่")
        Rad_Utility.addColumnButton("B", "เบิก", "B", 0, "", headertext:="เบิก")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnIMG("Delete", "ลบ", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_relate_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_relate.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                If Not item("RELATE_ID").Text.Contains("&nbsp") Then
                    Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                    dao.Getdata_by_ID(item("RELATE_ID").Text)
                    dao.delete()

                    Dim dao_d As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                    dao_d.Getdata_by_Relate_id(item("RELATE_ID").Text)

                    For Each dao_d.fields In dao_d.datas
                        Dim dao2 As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                        dao2.Getdata_by_ID(dao_d.fields.RELATE_DETAIL_ID)
                        dao2.delete()
                    Next

                    rg_relate.Rebind()
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                End If
            ElseIf e.CommandName = "send" Then
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(item("RELATE_ID").Text)
                dao.fields.STATUS_ID = 1
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ส่งเรื่องเรียบร้อยแล้ว');", True)
                rg_relate.Rebind()
            ElseIf e.CommandName = "C" Then
                If Not item("RELATE_ID").Text.Contains("&nbsp") Then
                    Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                    dao.Getdata_by_ID(item("RELATE_ID").Text)
                    dao.fields.IS_CONFIRM = True
                    dao.fields.CONFIRM_DATE = Date.Now
                    dao.update()
                    rg_relate.Rebind()
                End If
            ElseIf e.CommandName = "B" Then
                Dim url As String = ""
                Try
                    Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                    dao.Getdata_by_ID(item("RELATE_ID").Text)

                    If dao.fields.RELATE_TYPE <> 3 Then
                        url = "Frm_Disburse_Relate_Berg_Period.aspx?bid=" & item("RELATE_ID").Text
                    Else
                        url = "Frm_Disburse_Relate_Berg_Period_PO.aspx?bid=" & item("RELATE_ID").Text
                    End If
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)


                'If Not item("RELATE_ID").Text.Contains("&nbsp") Then
                '    If item("RELATE_TYPE").Text = "1" Then
                '        Dim i As Integer = 0
                '        Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
                '        i = dao_count.count_relate_id(item("RELATE_ID").Text)

                '        If i = 0 Then
                '            Dim dao_b As New DAO_DISBURSE.TB_BUDGET_BILL

                '            insert_bill(dao_b, item("RELATE_ID").Text)
                '            dao_b.fields.PAY_TYPE_ID = 0

                '            Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                '            dao_c.Getdata_by_ID(item("RELATE_ID").Text)
                '            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                '            dao_b.fields.BILL_NUMBER = "" 'bao.get_max_bill(dao_c.fields.BUDGET_YEAR) + 1
                '            dao_b.fields.DEBTOR_ID = 0
                '            dao_b.fields.CUSTOMER_TYPE_ID = 0
                '            dao_b.fields.RETURN_MONEY_ID = 0
                '            dao_b.fields.IS_PO = False
                '            'dao_b.fields.IS_APPROVE = False
                '            'dao_b.fields.APPROVE_DATE = Nothing
                '            dao_b.fields.BUDGET_USE_ID = 1
                '            dao_b.fields.IS_APPROVE = True
                '            dao_b.fields.APPROVE_DATE = Date.Now
                '            dao_b.fields.DEEKA_NUMBER = ""
                '            dao_b.fields.STATUS_ID = 1
                '            dao_b.fields.GROUP_ID = 0
                '            dao_b.insert()

                '            Dim dao_det As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                '            dao_det.Getdata_by_Relate_id(item("RELATE_ID").Text)

                '            'insert_bill_det(dao_d, item("RELATE_ID").Text)
                '            For Each dao_det.fields In dao_det.datas
                '                Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

                '                dao_d.fields.AMOUNT = dao_det.fields.AMOUNT
                '                dao_d.fields.MAX_PRIZE = dao_det.fields.AMOUNT
                '                Try
                '                    dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(dao_det.fields.CUSTOMER_ID, dao_det.fields.AMOUNT)
                '                Catch ex As Exception

                '                End Try
                '                dao_d.fields.BUDGET_DISBURSE_BILL_ID = dao_b.fields.BUDGET_DISBURSE_BILL_ID
                '                dao_d.fields.IS_ENABLE = True
                '                dao_d.fields.CUSTOMER_ID = dao_det.fields.CUSTOMER_ID
                '                dao_d.fields.GL_ID = dao_det.fields.GL_ID
                '                dao_d.fields.BUDGET_PLAN_ID = dao_det.fields.BUDGET_PLAN_ID
                '                dao_d.insert()
                '            Next


                '            Dim dao3 As New DAO_DISBURSE.TB_BUDGET_BILL
                '            dao3.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao_b.fields.BUDGET_DISBURSE_BILL_ID)
                '            dao3.fields.MAIN_BILL = dao_b.fields.BUDGET_DISBURSE_BILL_ID
                '            dao3.update()

                '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
                '        Else
                '            Dim dao_b As New DAO_DISBURSE.TB_BUDGET_BILL
                '            Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                '            insert_bill(dao_b, item("RELATE_ID").Text)
                '            dao_b.fields.PAY_TYPE_ID = 0

                '            Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                '            dao_c.Getdata_by_ID(item("RELATE_ID").Text)

                '            dao_b.update()
                '        End If
                '    ElseIf item("RELATE_TYPE").Text = "2" Then
                '        Dim i As Integer = 0
                '        Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
                '        i = dao_count.count_relate_id(item("RELATE_ID").Text)

                '        If i = 0 Then
                '            Dim dao_b As New DAO_DISBURSE.TB_DEBTOR_BILL
                '            'Dim dao_d As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                '            'Dim dao_m As New DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL
                '            insert_debtor(dao_b, item("RELATE_ID").Text)
                '            dao_b.fields.PAY_TYPE_ID = 0

                '            Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                '            dao_c.Getdata_by_ID(item("RELATE_ID").Text)
                '            dao_b.fields.BILL_NUMBER = ""
                '            dao_b.fields.CUSTOMER_TYPE_ID = 0
                '            dao_b.fields.BUDGET_USE_ID = 1
                '            'dao_b.fields.IS_APPROVE = True
                '            'dao_b.fields.APPROVE_DATE = Date.Now
                '            dao_b.fields.DEEKA_NUMBER = ""
                '            dao_b.fields.STATUS_ID = 1
                '            dao_b.fields.GROUP_ID = 0
                '            dao_b.insert()

                '            Dim dao_det As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                '            dao_det.Getdata_by_Relate_id(item("RELATE_ID").Text)
                '            For Each dao_det.fields In dao_det.datas
                '                Dim dao_d As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL

                '                dao_d.fields.AMOUNT = dao_det.fields.AMOUNT
                '                Try
                '                    dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(dao_det.fields.CUSTOMER_ID, dao_det.fields.AMOUNT)
                '                Catch ex As Exception

                '                End Try
                '                dao_d.fields.DEBTOR_BILL_ID = dao_b.fields.DEBTOR_BILL_ID
                '                dao_d.fields.IS_ENABLE = True
                '                dao_d.fields.CUSTOMER_ID = dao_det.fields.CUSTOMER_ID
                '                dao_d.fields.GL_ID = dao_det.fields.GL_ID
                '                dao_d.fields.BUDGET_PLAN_ID = dao_det.fields.BUDGET_PLAN_ID
                '                dao_d.insert()
                '            Next

                '            'insert_debtor_det(dao_d, item("RELATE_ID").Text)
                '            'dao_d.fields.DEBTOR_BILL_ID = dao_b.fields.DEBTOR_BILL_ID
                '            'dao_d.fields.IS_ENABLE = True
                '            'dao_d.insert()

                '            'insert_debtor_det_m(dao_m, item("RELATE_ID").Text)
                '            'dao_m.fields.DEBTOR_BILL_ID = dao_b.fields.DEBTOR_BILL_ID
                '            'dao_m.fields.IS_ENABLE = True
                '            'dao_m.fields.IS_CHECK_RECEIVE = False
                '            'dao_m.fields.CHECK_APPROVE = False
                '            'dao_m.insert()

                '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)

                '        End If

                '    ElseIf item("RELATE_TYPE").Text = "3" Then
                '        Dim i As Integer = 0
                '        Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
                '        i = dao_count.count_relate_id(item("RELATE_ID").Text)

                '        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                '        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
                '        dao_c.Getdata_by_ID(item("RELATE_ID").Text)

                '        dao.fields.DEBTOR_ID = 0
                '        dao.fields.CUSTOMER_TYPE_ID = 0
                '        dao.fields.RETURN_MONEY_ID = 0
                '        dao.fields.APPROVE_DATE = dao_c.fields.APPROVE_DATE
                '        dao.fields.BILL_DATE = dao_c.fields.DO_DATE
                '        dao.fields.CUSTOMER_ID = dao_c.fields.CUSTOMER_ID
                '        dao.fields.Bill_RECIEVE_DATE = dao_c.fields.DO_DATE
                '        dao.fields.BUDGET_PLAN_ID = dao_c.fields.BUDGET_ID
                '        dao.fields.BUDGET_USE_ID = 1
                '        dao.fields.BUDGET_YEAR = dao_c.fields.BUDGET_YEAR
                '        dao.fields.DEPARTMENT_ID = dao_c.fields.DEPARTMENT_ID
                '        dao.fields.DESCRIPTION = dao_c.fields.DESCRIPTION
                '        dao.fields.DOC_DATE = dao_c.fields.DOC_DATE
                '        dao.fields.DOC_NUMBER = dao_c.fields.DOC_NUMBER
                '        dao.fields.IS_APPROVE = True
                '        dao.fields.APPROVE_DATE = dao_c.fields.APPROVE_DATE
                '        dao.fields.PATLIST_ID = dao_c.fields.PAYLIST_ID
                '        dao.fields.USER_ID = dao_c.fields.CUSTOMER_ID
                '        dao.fields.MAX_PRIZE = dao_c.fields.APPROVE_AMOUNT                       
                '        dao.fields.EGP_NUMBER = dao_c.fields.EGP_NUMBER
                '        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                '        dao.fields.BILL_NUMBER = "" 'bao.get_max_bill(dao_c.fields.BUDGET_YEAR) + 1
                '        dao.fields.PAY_TYPE_ID = 0
                '        dao.fields.STATUS_ID = 1
                '        dao.fields.GROUP_ID = 0
                '        'dao.fields.BILL_NUMBER = bao_2.get_debtor_max_bill(dao_c.fields.BUDGET_YEAR) + 1
                '        'dao.fields.CER_ID = _id
                '        dao.fields.IS_PO = True
                '        dao.insert()

                '        Try
                '            Dim dao_m As New DAO_DISBURSE.TB_BUDGET_BILL
                '            dao_m.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_DISBURSE_BILL_ID)
                '            dao_m.fields.MAIN_BILL = dao.fields.MAIN_BILL
                '            dao_m.update()
                '        Catch ex As Exception

                '        End Try

                '        Dim dao_r_d As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                '        dao_r_d.Getdata_by_Relate_id(item("RELATE_ID").Text)
                '        For Each dao_r_d.fields In dao_r_d.datas
                '            Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL

                '            dao_d.fields.AMOUNT = dao_r_d.fields.AMOUNT
                '            dao_d.fields.MAX_PRIZE = dao_r_d.fields.AMOUNT
                '            Try
                '                dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(dao_r_d.fields.CUSTOMER_ID, dao_r_d.fields.AMOUNT)
                '            Catch ex As Exception

                '            End Try
                '            dao_d.fields.BUDGET_DISBURSE_BILL_ID = dao.fields.BUDGET_DISBURSE_BILL_ID
                '            dao_d.fields.IS_ENABLE = True
                '            dao_d.fields.CUSTOMER_ID = dao_r_d.fields.CUSTOMER_ID
                '            dao_d.fields.GL_ID = dao_r_d.fields.GL_ID
                '            dao_d.fields.BUDGET_PLAN_ID = dao_r_d.fields.BUDGET_PLAN_ID
                '            dao_d.insert()
                '        Next
                '    End If

                'End If


            End If
        End If
    End Sub
    Private Sub insert_bill(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL, ByVal relate_id As Integer)
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(relate_id)
        dao.fields.BILL_DATE = dao_c.fields.DO_DATE
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

    Private Sub insert_bill_det(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL, ByVal relate_id As Integer)
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(relate_id)

        dao.fields.AMOUNT = dao_c.fields.AMOUNT
        dao.fields.MAX_PRIZE = dao_c.fields.AMOUNT
        Dim dao2 As New DAO_MAS.TB_MAS_CUSTOMER
        Try
            dao2.Getdata_by_CUSTOMER_ID(dao_c.fields.CUSTOMER_ID)
        Catch ex As Exception

        End Try

        Try
            dao.fields.TAX_AMOUNT = cal_tax_by_customer_type(dao_c.fields.CUSTOMER_ID, dao_c.fields.AMOUNT)
        Catch ex As Exception

        End Try

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
    End Sub
    Private Sub insert_debtor_det(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL, ByVal relate_id As Integer)
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(relate_id)
        dao.fields.AMOUNT = dao_c.fields.AMOUNT
        dao.fields.APPROVE_AMOUNT = dao_c.fields.AMOUNT
        dao.fields.IS_ENABLE = True

    End Sub

    Private Sub insert_debtor_det_m(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL_MARGIN_DETAIL, ByVal relate_id As Integer)
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(relate_id)
        dao.fields.AMOUNT = dao_c.fields.AMOUNT
        dao.fields.APPROVE_AMOUNT = dao_c.fields.AMOUNT
        'dao.fields.IS_ENABLE = True
        'dao.fields.IS_CHECK_RECEIVE = False
        'dao.fields.CHECK_APPROVE = False
    End Sub
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
    Private Sub rg_relate_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_relate.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim id As Integer = item("RELATE_ID").Text
            ' Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim _Edit As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
            Dim B As LinkButton = DirectCast(item("B").Controls(0), LinkButton)
            'Dim C As LinkButton = DirectCast(item("C").Controls(0), LinkButton)
            Dim del As LinkButton = DirectCast(item("DeleteColumn").Controls(0), LinkButton)
            Dim sends As LinkButton = DirectCast(item("send").Controls(0), LinkButton)
            '
            ' Dim h3 As ImageButton = DirectCast(item("DeleteColumn").Controls(0), ImageButton)
            'h2.Attributes.Add("OnClick", "return k(" & id & "," & BudgetID & "," & BudgetYear & ");")

            'h2.Attributes.Add("OnClick", "Popups2('Frm_Disburse_Relate_Edit2.aspx?bid=" & id & "&bgid=" & BudgetID & "&bgYear=" & BudgetYear & "&dept=" & Request.QueryString("dept") & "'); return false;")
            _Edit.Attributes.Add("OnClick", "Popups2('Frm_Disburse_Relate_InsertV2.aspx?bid=" & id & "&bgYear=" & BudgetYear & "&dept=" & Request.QueryString("dept") & "'); return false;")

            '& id & "&bgid=" & BudgetID & "&bgYear=" & BudgetYear & "');")
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(id)
            Dim img As Image = DirectCast(item("img").Controls(0), Image)
            Dim dao_a As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
            Dim co As Integer = 0

            Try
                co = dao_a.count_approve(item("RELATE_ID").Text, 1, 3)
            Catch ex As Exception

            End Try
            'Rad_Utility.addColumnButton("send", "ยืนยันส่งเรื่อง", "send", 0, "คุณต้องการส่งเรื่องหรือไม่")
            'Rad_Utility.addColumnButton("B", "เบิก", "B", 0, "")
            'Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
            'Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)



            If dao.fields.STATUS_ID = 0 Then
                B.Visible = False
                _Edit.Visible = True
                del.Visible = True
                sends.Visible = True
            ElseIf dao.fields.STATUS_ID > 0 And dao.fields.STATUS_ID < 3 Then
                B.Visible = False
                _Edit.Visible = False
                del.Visible = False
                sends.Visible = False
            ElseIf dao.fields.STATUS_ID >= 3 Then
                B.Visible = True
                _Edit.Visible = False
                del.Visible = False
                sends.Visible = False
            End If
            'If dao.fields.STATUS_ID >= 1 Then


            'End If

            Dim amount_all As Double = 0
            Dim berg As Double = 0
            Dim balance As Double = 0
            Try
                Dim dao_det_re As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                dao_det_re.Getdata_by_Relate_id(item("RELATE_ID").Text)
                For Each dao_det_re.fields In dao_det_re.datas
                    amount_all += dao_det_re.fields.AMOUNT
                Next
                If dao.fields.RELATE_TYPE = "1" Then
                    Dim dao_bi As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao_bi.Getdata_by_RELATE_ID(item("RELATE_ID").Text)
                    For Each dao_bi.fields In dao_bi.datas
                        berg += get_bill_det_amount(dao_bi.fields.BUDGET_DISBURSE_BILL_ID)
                    Next
                ElseIf dao.fields.RELATE_TYPE = "2" Then
                    Dim dao_bi As New DAO_DISBURSE.TB_DEBTOR_BILL
                    dao_bi.Getdata_by_RELATE_ID(item("RELATE_ID").Text)
                    For Each dao_bi.fields In dao_bi.datas
                        berg += get_debtor_det_amount(dao_bi.fields.DEBTOR_BILL_ID)
                    Next
                ElseIf dao.fields.RELATE_TYPE = "3" Then
                    Dim dao_bi As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao_bi.Getdata_by_RELATE_ID(item("RELATE_ID").Text)
                    For Each dao_bi.fields In dao_bi.datas
                        berg += get_bill_det_amount(dao_bi.fields.BUDGET_DISBURSE_BILL_ID)
                    Next
                End If
                balance = amount_all - berg
                If balance <= 0 Then
                    B.Visible = False
                End If
            Catch ex As Exception

            End Try

            'If co > 0 Then
            '    img.ImageUrl = "~/images/cb.png"
            '    h2.Visible = False
            '    h3.Visible = False
            'Else
            '    img.ImageUrl = "~/images/emp_cb.png"
            '    B.Visible = False
            'End If


            'If dao.fields.IS_APPROVE IsNot Nothing Then
            '    If dao.fields.IS_APPROVE = True Then
            '        img.ImageUrl = "~/images/cb.png"
            '    Else
            '        img.ImageUrl = "~/images/emp_cb.png"
            '    End If
            'Else
            '    img.ImageUrl = "~/images/emp_cb.png"
            'End If

            'If dao.fields.IS_APPROVE = True Then
            '    h2.Visible = False
            '    h3.Visible = False
            'Else
            '    B.Visible = False
            'End If

            'If dao.fields.IS_CONFIRM IsNot Nothing Then
            '    If CBool(dao.fields.IS_CONFIRM) = True Then
            '        h2.Visible = False
            '        h3.Visible = False
            '        'C.Visible = False
            '    End If
            'End If

            'Dim i As Integer = 0
            'Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
            'i = dao_count.count_relate_id(item("RELATE_ID").Text)
            'If i > 0 Then
            '    B.Style.Add("display", "none")
            'Else
            '    B.Style.Add("display", "block")
            'End If
        End If
    End Sub

    Private Sub rg_relate_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_relate.NeedDataSource
        Dim BudgetBill As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable
        dt = BudgetBill.get_relate_bill_HRD(BudgetYear, dept, bg_use)
        dt.Columns.Add("balance", GetType(Double))
        'dt.Columns.Add("period_conunt", GetType(Integer))
        For Each dr As DataRow In dt.Rows
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(dr("RELATE_ID"))
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            Dim amount_all As Double = 0
            Dim berg As Double = 0
            Dim balance As Double = 0

            '
            Dim period As Integer = 0
            Try
                Dim dao_po As New DAO_DISBURSE.TB_RELATE_DETAIL_PO
                period = dao_po.count_po(dr("RELATE_ID"))
                If period <> 0 Then
                    dr("DESCRIPTION") = dr("DESCRIPTION") & " (" & period & " งวด)"
                End If
            Catch ex As Exception

            End Try




            'Try
            '    If dao.fields.RELATE_TYPE = 2 And dao.fields.IS_PO_APPROVE = True Then
            '        amount_all = dao.fields.APPROVE_AMOUNT
            '    Else
            '        amount_all = dao.fields.AMOUNT
            '    End If
            'Catch ex As Exception

            'End Try
            Dim dao_det_re As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
            dao_det_re.Getdata_by_Relate_id(dr("RELATE_ID"))
            For Each dao_det_re.fields In dao_det_re.datas
                amount_all += dao_det_re.fields.AMOUNT
            Next
            If dao.fields.RELATE_TYPE = "1" Then
                Dim dao_bi As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_bi.Getdata_by_RELATE_ID(dr("RELATE_ID"))
                For Each dao_bi.fields In dao_bi.datas
                    berg += get_bill_det_amount(dao_bi.fields.BUDGET_DISBURSE_BILL_ID)
                Next
            ElseIf dao.fields.RELATE_TYPE = "2" Then
                Dim dao_bi As New DAO_DISBURSE.TB_DEBTOR_BILL
                dao_bi.Getdata_by_RELATE_ID(dr("RELATE_ID"))
                For Each dao_bi.fields In dao_bi.datas
                    berg += get_debtor_det_amount(dao_bi.fields.DEBTOR_BILL_ID)
                Next
            ElseIf dao.fields.RELATE_TYPE = "3" Then
                Dim dao_bi As New DAO_DISBURSE.TB_BUDGET_BILL
                dao_bi.Getdata_by_RELATE_ID(dr("RELATE_ID"))
                For Each dao_bi.fields In dao_bi.datas
                    berg += get_bill_det_amount(dao_bi.fields.BUDGET_DISBURSE_BILL_ID)
                Next
            End If
            balance = amount_all - berg
            dr("balance") = balance
        Next
        rg_relate.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        rg_relate.Rebind()
    End Sub

    Public Function get_bill_det_amount(ByVal id_bill As Integer) As Double
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao.Getdata_by_Disburse_id(id_bill)
        Dim total As Double = 0
        For Each dao.fields In dao.datas
            Try
                total += dao.fields.AMOUNT
            Catch ex As Exception

            End Try
        Next

        Return total
    End Function
    Public Function get_debtor_det_amount(ByVal id_bill As Integer) As Double
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        dao.Getdata_by_DEBTOR_BILL_ID(id_bill)
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