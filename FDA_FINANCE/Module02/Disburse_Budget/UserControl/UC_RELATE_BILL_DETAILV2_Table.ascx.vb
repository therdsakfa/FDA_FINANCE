Imports Telerik.Web.UI


Public Class UC_RELATE_BILL_DETAILV2_Table
    Inherits System.Web.UI.UserControl
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Dim _ProId As String = ""

    Public Sub run_Query()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
        _ProId = Request.QueryString("ProId")
        '_ProId = "17051400213"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        run_Query()

        btn_period.ToolTip = "กรุณากดเพิ่มงวดให้ครบก่อนทำการกรอกข้อมูล"

        If Not IsPostBack Then
            set_hide()
        End If
    End Sub

    Public Sub set_hide()
  
        Dim Dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
        Dao.Getdata_by_ID(_bid)

        If Dao.fields.RELATE_TYPE = 2 Then
            Panel3.Style.Add("display", "none")
        Else
            Panel3.Style.Add("display", "block")
        End If

    End Sub

    'Public Sub SelectPro()
    '    If _ProId <> "" Then
    '        txtBudgetAdjust.Text = _ProId
    '    Else
    '        txtBudgetAdjust.Text = ""
    '    End If
    'End Sub

    Public Sub bind_dl_bg()
        Dim bao_adjust As New BAO_BUDGET.Budget

        Dim dt As New DataTable
        dt = bao_adjust.get_bg_adjust_by_dept_year(22, _bgyear)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                If dao_head.fields.BUDGET_CODE <> "" Then
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION '& " -> " & dr("BUDGET_DESCRIPTION")
                Else
                    dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION '& " -> " & dr("BUDGET_DESCRIPTION")
                End If

            Next

            dd_BudgetAdjust.DataSource = dt
            dd_BudgetAdjust.DataBind()
            dd_BudgetAdjust.DropDownInsertDataFirstRow("--- กรุณาเลือก ---", "0")

        End If
    End Sub

    Public Sub bind_dd_cus()
        Dim bao_cus As New BAO_BUDGET.MASS
        Dim dt_cus As DataTable = bao_cus.get_customer()

        dd_CUSTOMER.DataSource = dt_cus
        dd_CUSTOMER.DataBind()
    End Sub

    Public Sub bind_dd_gl()
        Dim bao_gl As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        'If Request.QueryString("bid") <> "" Then
        '    Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
        '    dao.Getdata_by_ID(Request.QueryString("bid"))
        '    If dao.fields.RELATE_TYPE <> 2 Then
        '        dt = bao_gl.get_GL()
        '    Else
        '        dt = bao_gl.get_GL_debtor()
        '    End If

        'Else
        dt = bao_gl.get_GL()
        'End If
        ddl_GL.DataSource = dt
        ddl_GL.DataBind()
    End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_DETAIL)
        Try
            dao.fields.AMOUNT = rnt_AMOUNT.Value
        Catch ex As Exception
            dao.fields.AMOUNT = 0
        End Try
        Try
            If dd_BudgetAdjust.SelectedValue <> 0 Then
                dao.fields.BUDGET_PLAN_ID = dd_BudgetAdjust.SelectedValue
            Else
                dao.fields.BUDGET_PLAN_ID = 0
            End If

        Catch ex As Exception
            dao.fields.BUDGET_PLAN_ID = 0
        End Try
        dao.fields.CUSTOMER_ID = dd_CUSTOMER.SelectedValue
        dao.fields.GL_ID = ddl_GL.SelectedValue

    End Sub

    Public Sub get_date(ByRef dao As DAO_DISBURSE.TB_RELATE_BG_DETAIL)
        Try
            rnt_AMOUNT.Value = dao.fields.AMOUNT
        Catch ex As Exception
            rnt_AMOUNT.Value = 0
        End Try
        Try
            dd_BudgetAdjust.DropDownSelectData(dao.fields.BUDGET_PLAN_ID)
        Catch ex As Exception
        End Try
        dd_CUSTOMER.DropDownSelectData(dao.fields.CUSTOMER_ID)
        ddl_GL.DropDownSelectData(dao.fields.GL_ID)

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                dao.Getdata_by_ID(item("RELATE_DETAIL_ID").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("bid") <> "" Then
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
            dt = bao.SC_get_relate_det_by_id(Request.QueryString("bid"))
        End If

        RadGrid1.DataSource = dt
    End Sub

    Public Sub rebind_grid()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_add_bg_Click(sender As Object, e As EventArgs) Handles btn_add_bg.Click

        Dim bg_id As Integer = 0
        Try
            bg_id = dd_BudgetAdjust.SelectedValue
        Catch ex As Exception

        End Try
        If Request.QueryString("bid") <> "" Then
            If rnt_AMOUNT.Value > 0 And dd_CUSTOMER.SelectedValue <> 1 Then
                'If chk_amount(bg_id, rnt_AMOUNT.Value) = True Then
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                insert(dao)
                dao.fields.RELATE_ID = _bid
                dao.insert()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
                'Else
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('จำนวนเงินไม่เพียงพอ');", True)
                'End If
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครบถ้วน');", True)
            End If

        End If
        bind_data_projectName()
    End Sub

    Public Sub bind_data_projectName()

        Dim str As String = ""
        Dim bg_id As Integer = 0

        Try
            bg_id = dd_BudgetAdjust.SelectedValue
        Catch ex As Exception

        End Try

        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act2 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act3 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_act4 As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN

        If bg_id <> 0 Then

            dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_id)
            lb_budget.Text = dao_bg.fields.BUDGET_DESCRIPTION

            Try

                dao_act.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
                lb_ProjectName.Text = dao_act.fields.BUDGET_DESCRIPTION
                lb_ProjectCode.Text = dao_act.fields.BUDGET_CODE

                '---------------------------------

                dao_act2.Getdata_by_BUDGET_PLAN_ID(dao_act.fields.BUDGET_CHILD_ID)
                lb_mainAct.Text = dao_act2.fields.BUDGET_DESCRIPTION
                '---------------------------------

                dao_act3.Getdata_by_BUDGET_PLAN_ID(dao_act2.fields.BUDGET_CHILD_ID)
                lb_product.Text = dao_act3.fields.BUDGET_DESCRIPTION

                '---------------------------------
                dao_act4.Getdata_by_BUDGET_PLAN_ID(dao_act3.fields.BUDGET_CHILD_ID)
                lb_plan.Text = dao_act4.fields.BUDGET_DESCRIPTION

                ' --------------------------------

                Dim uti_adjust As New Utility_other()
                Dim bao_relate As New BAO_BUDGET.DISBURSE_BUDGET
                Dim bao_debt_app As New BAO_BUDGET.Budget

                Dim bao_rec As New BAO_BUDGET.DISBURSE_BUDGET 'รับโอน
                Dim rec As Double = 0
                Dim ad As Double = 0

                rec = bao_rec.get_All_Transfer_Money(_bgyear, bg_id) 'รับโอน
                ad = uti_adjust.getAdjust_Amount(bg_id, _bgyear) 'จัดสรร


                Dim adjust_amount As Double = (ad + rec)

                'Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bg_id, _bgyear)
                Dim Relate_Amount As Double = bao_relate.get_Amount_Relate_App(bg_id, _bgyear)

                Try
                    lb_amount.Text = adjust_amount.ToString("N") & " บาท "
                    lb_balance.Text = (adjust_amount - Relate_Amount).ToString("N") & " บาท "
                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try

        Else

            lb_plan.Text = "-"
            lb_product.Text = "-"
            lb_budget.Text = "-"
            lb_mainAct.Text = "-"
            lb_ProjectName.Text = "-"
            lb_ProjectCode.Text = "-"
            lb_amount.Text = "-"
            lb_balance.Text = "-"

        End If

    End Sub

    Public Function chk_amount(ByVal bgid As Integer, ByVal amount As Double) As Boolean
        Dim bool As Boolean = True
        Dim uti_adjust As New Utility_other()
        Dim bao_relate As New BAO_BUDGET.DISBURSE_BUDGET
        Dim adjust_amount As Double = uti_adjust.getAdjust_Amount(bgid, _bgyear)
        Dim Relate_Amount As Double = bao_relate.get_Amount_Relate_App(bgid, _bgyear)
        Dim balance As Double = 0
        balance = adjust_amount - Relate_Amount
        If balance < amount Then
            bool = False
        End If

        Return bool
    End Function

    Private Sub dd_BudgetAdjust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_BudgetAdjust.SelectedIndexChanged
        bind_data_projectName()
    End Sub

    '---------------------
    Private Sub btn_period_Click(sender As Object, e As EventArgs) Handles btn_period.Click
        Try

            For i As Integer = 1 To 1
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                dao.Getdata_by_Relate_id(Request.QueryString("bid"))
                For Each dao.fields In dao.datas
                    Dim dao_po As New DAO_DISBURSE.TB_RELATE_DETAIL_PO

                    Dim dt2 As New DataTable
                    Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
                    If Request.QueryString("bid") <> "" Then
                        dt2 = bao.SC_get_relate_det_po_by_id(Request.QueryString("bid"))
                    End If

                    Dim c As Integer = 0
                    c = dt2.Rows.Count

                    dao_po.fields.AMOUNT = 0
                    dao_po.fields.APPROVE_AMOUNT = 0
                    dao_po.fields.BUDGET_PLAN_ID = dao.fields.BUDGET_PLAN_ID
                    dao_po.fields.CUSTOMER_ID = dao.fields.CUSTOMER_ID
                    dao_po.fields.GL_ID = dao.fields.GL_ID
                    dao_po.fields.IS_ENABLE = dao.fields.IS_ENABLE
                    dao_po.fields.PERIOD_AMOUNT = 0
                    dao_po.fields.PERIOD_ID = c + 1
                    dao_po.fields.RELATE_ID = Request.QueryString("bid")
                    dao_po.insert()

                Next
            Next

            RadGrid2.Rebind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dt As New DataTable

        If Request.QueryString("bid") <> "" Then
            dt = bao.SC_get_relate_det_po_by_id(Request.QueryString("bid"))
        End If

        RadGrid2.DataSource = dt
    End Sub


    Public Sub save_period_data()
        Dim i As Integer = 0
        For Each item As GridDataItem In RadGrid2.Items
            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg")
            Dim dao As New DAO_DISBURSE.TB_RELATE_DETAIL_PO
            dao.Getdata_by_ID(item("IDA").Text)
            dao.fields.PERIOD_AMOUNT = rnt_berg.Value
            dao.update()
            i += 1
        Next
        If i > 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
        End If
    End Sub

    Private Sub rg_relate_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                If Not item("IDA").Text.Contains("&nbsp") Then
                    Dim dao As New DAO_DISBURSE.TB_RELATE_DETAIL_PO
                    dao.Getdata_by_ID(item("IDA").Text)
                    dao.delete()

                    RadGrid2.Rebind()
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                End If

            End If
        End If
    End Sub

    Private Sub rg_ProjectList_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

            Dim item As GridDataItem
            item = DirectCast(e.Item, GridDataItem)

            ' Dim check As RadNumericTextBox = DirectCast(item("berg").Controls(0), RadNumericTextBox)
            Dim rnt_berg As RadNumericTextBox = item("berg").FindControl("rnt_berg")
            Dim Amount As Double = item("PERIOD_AMOUNT").Text

            If Amount <> 0 Then
                rnt_berg.Text = Amount
            Else
                rnt_berg.Text = 0
            End If
        End If

    End Sub

    Public Sub insert_det()

        Dim dao_re As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_re.Getdata_by_ID(Request.QueryString("bid"))
        Dim dao_det_re As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
        dao_det_re.Getdata_by_Relate_id(Request.QueryString("bid"))


        Dim i As Integer = 0
        Dim dao_count As New DAO_DISBURSE.TB_BUDGET_BILL
        i = dao_count.count_relate_id(Request.QueryString("bid"))

        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_c As New DAO_DISBURSE.TB_RELATE_BG_ALL
        dao_c.Getdata_by_ID(Request.QueryString("bid"))

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
        dao.fields.DESCRIPTION = dao_c.fields.DESCRIPTION
        Try
            dao.fields.DOC_DATE = CDate(dao_c.fields.DOC_DATE) 'dao_c.fields.DOC_DATE
        Catch ex As Exception

        End Try

        dao.fields.DOC_NUMBER = dao_c.fields.DOC_NUMBER
        dao.fields.IS_APPROVE = True
        dao.fields.APPROVE_DATE = dao_c.fields.APPROVE_DATE
        dao.fields.PATLIST_ID = dao_c.fields.PAYLIST_ID
        dao.fields.USER_ID = dao_c.fields.CUSTOMER_ID
        dao.fields.MAX_PRIZE = dao_c.fields.APPROVE_AMOUNT
        dao.fields.EGP_NUMBER = dao_c.fields.EGP_NUMBER
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        dao.fields.BILL_NUMBER = "" 'bao.get_max_bill(dao_c.fields.BUDGET_YEAR) + 1
        dao.fields.PAY_TYPE_ID = 0
        dao.fields.STATUS_ID = 0 '1
        dao.fields.GROUP_ID = 0
        dao.fields.IS_PO = True
        dao.fields.RELATE_ID = Request.QueryString("bid")
        dao.insert()

        Try
            Dim dao_m As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_m.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_DISBURSE_BILL_ID)
            dao_m.fields.MAIN_BILL = dao.fields.MAIN_BILL
            dao_m.update()
        Catch ex As Exception

        End Try

        For Each dao_det_re.fields In dao_det_re.datas

            Dim dao_d As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            dao_d.fields.AMOUNT = dao_det_re.fields.AMOUNT
            dao_d.fields.MAX_PRIZE = dao_det_re.fields.APPROVE_AMOUNT
            Try
                dao_d.fields.TAX_AMOUNT = cal_tax_by_customer_type(dao_det_re.fields.CUSTOMER_ID, dao_det_re.fields.AMOUNT)
            Catch ex As Exception

            End Try
            dao_d.fields.BUDGET_DISBURSE_BILL_ID = dao.fields.BUDGET_DISBURSE_BILL_ID
            dao_d.fields.IS_ENABLE = True
            Try
                dao_d.fields.CUSTOMER_ID = dao_det_re.fields.CUSTOMER_ID
            Catch ex As Exception

            End Try
            Try
                dao_d.fields.GL_ID = dao_det_re.fields.GL_ID
            Catch ex As Exception

            End Try
            Try
                dao_d.fields.BUDGET_PLAN_ID = dao_det_re.fields.BUDGET_PLAN_ID
            Catch ex As Exception

            End Try
            dao_d.insert()
        Next


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)


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

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        insert_det()
        save_period_data()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)
    End Sub

End Class