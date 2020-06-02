Imports Telerik.Web.UI
Public Class UC_Disburse_Budget_withdraw_add
    Inherits System.Web.UI.UserControl
    Private _BudgetYear As Integer
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property

    Private _BID As Integer = 0
    Public Property BID() As Integer
        Get
            Return _BID
        End Get
        Set(ByVal value As Integer)
            _BID = value
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
    Private _dept_id As Integer
    Public Property dept_id() As Integer
        Get
            Return _dept_id
        End Get
        Set(ByVal value As Integer)
            _dept_id = value
        End Set
    End Property
    Private _Budget_Use_id As Integer
    Public Property Budget_Use_id() As Integer
        Get
            Return _Budget_Use_id
        End Get
        Set(ByVal value As Integer)
            _Budget_Use_id = value
        End Set
    End Property
    Private _is_insert As Boolean
    Public Property is_insert() As Boolean
        Get
            Return _is_insert
        End Get
        Set(ByVal value As Boolean)
            _is_insert = value
        End Set
    End Property
    Private _egp As Boolean
    Public Property egp() As Boolean
        Get
            Return _egp
        End Get
        Set(ByVal value As Boolean)
            _egp = value
        End Set
    End Property
    Private _stat_egp As Integer
    Public Property stat_egp() As Integer
        Get
            Return _stat_egp
        End Get
        Set(ByVal value As Integer)
            _stat_egp = value
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
    Private _bguse As Integer
    Public Property bguse() As Integer
        Get
            Return _bguse
        End Get
        Set(ByVal value As Integer)
            _bguse = value
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

    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim get_id As Integer = 0
            get_id = _BID

            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
            dao.Getdata_by_Fk_id(get_id)

            If dao.fields.ID <> 0 Then
                txt_wd_date.Text = CDate(dao.fields.DateRecive).ToShortDateString()
                ' panel_2.Style.Add("display", "block")
            Else
                txt_wd_date.Text = CDate(Date.Now).ToShortDateString()
                ' panel_2.Style.Add("display", "none")
            End If

            bindData()

            Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
            dao2.Getdata_by_Fk_id(get_id)

            If dao2.fields.ID <> 0 Then
                get_data(dao2)

            End If
        End If


    End Sub

    Public Sub bindData()

        txt_year.Text = _BudgetYear

        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_bill.Getdata_by_BillId(_bid)

        txt_Descript.Text = dao_bill.fields.DESCRIPTION
        txt_DocNumber.Text = dao_bill.fields.DOC_NUMBER
        txt_DocDate.Text = dao_bill.fields.DOC_DATE

        Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
        dao2.Getdata_by_Fk_id(_BID)

        If dao2.fields.ID <> 0 Then
            txt_withdraw_bill.Text = dao2.fields.BillCode
        Else
            Dim Max As Integer = 0
            Dim baoMax As New BAO_BUDGET.DISBURSE_BUDGET
            Max = baoMax.get_max_billcode_budget_withdraw()

            txt_withdraw_bill.Text = Max + 1
        End If

        Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
        dao_dep.Getdata_by_DEPARTMENT_ID(dao_bill.fields.DEPARTMENT_ID)
        txt_Dept.Text = dao_dep.fields.DEPARTMENT_DESCRIPTION

        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim dao_gl As New DAO_MAS.TBL_MAS_GL_1
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
        Dim dao_bg2 As New DAO_MAS.TB_BUDGET_PLAN

        Dim bg_child1 As Integer = 0
        Dim bg_child2 As Integer = 0
        Dim bg_child3 As Integer = 0
        Dim bg_child4 As Integer = 0

        dao_detail.Getdata_by_Disburse_id(dao_bill.fields.BUDGET_DISBURSE_BILL_ID)
        dao_gl.Getdata_by_ID(dao_detail.fields.GL_ID)
        dao_cus.Getdata_by_CUSTOMER_ID(dao_detail.fields.CUSTOMER_ID)

        'งาน/โครงการ
        dao_bg.Getdata_by_BUDGET_PLAN_ID(dao_detail.fields.BUDGET_PLAN_ID)
        txt_bg_group.Text = dao_bg.fields.BUDGET_DESCRIPTION

        bg_child4 = dao_bg.fields.BUDGET_CHILD_ID
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child4)
        txt_bg_project.Text = dao_bg.fields.BUDGET_DESCRIPTION

        'กิจกรรม
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child4)
        bg_child3 = dao_bg.fields.BUDGET_CHILD_ID
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child3)
        txt_bg_act.Text = dao_bg.fields.BUDGET_DESCRIPTION

        'ผลผลิต
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child3)
        bg_child2 = dao_bg.fields.BUDGET_CHILD_ID
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child2)
        txt_bg_product.Text = dao_bg.fields.BUDGET_DESCRIPTION
        'แผนงาน
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child2)
        bg_child1 = dao_bg.fields.BUDGET_CHILD_ID
        dao_bg.Getdata_by_BUDGET_PLAN_ID(bg_child1)
        txt_bg_plan.Text = dao_bg.fields.BUDGET_DESCRIPTION

        Dim baoSum As New BAO_BUDGET.Budget
        Dim sum As Double = baoSum.get_relate_summoney_byFKId(_BID)

        txt_amount.Text = String.Format("{0:###,###.00}", sum)

    End Sub

    Public Sub bind_dd_pay()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_PAYTYPE()

        dd_pay.DataSource = dt
        dd_pay.DataBind()
    End Sub

    Public Sub bind_dd_payW()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_TYPE_MONEY_W()

        dd_payW.DataSource = dt
        dd_payW.DataBind()
    End Sub

    'Private Sub rg_list_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_list.ItemDataBound

    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

    '        Dim item As GridDataItem
    '        item = e.Item

    '        Dim id As Integer = item("DETAIL_ID").Text

    '        Dim valueVat As Double = 0
    '        Dim valueMulct As Double = 0
    '        Dim valueInsurance As Double = 0

    '        'Dim txtVat As RadTextBox = DirectCast(item("nVat").FindControl("txtVat"), RadTextBox)
    '        'Dim txtMulct As RadTextBox = DirectCast(item("nMulct").FindControl("txtMulct"), RadTextBox)
    '        'Dim txtInsurance As RadTextBox = DirectCast(item("nInsurance").FindControl("txtInsurance"), RadTextBox)

    '        Dim nVat As RadNumericTextBox = item.FindControl("nVat")
    '        Dim nMulct As RadNumericTextBox = item.FindControl("nMulct")
    '        Dim nInsurance As RadNumericTextBox = item.FindControl("nInsurance")

    '        Dim Amount As Double = 0
    '        Dim Before_Vat As Double = 0
    '        Dim After_Vat As Double = 0

    '        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
    '        dao.Getdata_by_fk_and_DETAIL_ID(_BID, id)

    '        If item("TAX_TYPE").Text <> 0 Then

    '            '-----เพิ่มเงื่อนไขภาษี-------
    '            'บุคคลธรรมดา เบิกไม่เกิน 10,000 ไม่เก็บ 1% ถ้าเกินเก็บ 1%
    '            'นิติบุคคล เงินรับสุทธิ มากกว่าเท่ากับ 500 คิด 1%
    '            'สูตร xx * 1/107

    '            If item("TAX_TYPE").Text = 1 Or item("TAX_TYPE").Text = 5 Then 'นิติ vat 7%

    '                If item("AMOUNT").Text <> 0 Then

    '                    'คิด 1% ยังไม่คิด 7%
    '                    Amount = item("AMOUNT").Text
    '                    Before_Vat = (Amount * 1) / 107

    '                    After_Vat = Amount - Before_Vat

    '                    If After_Vat >= 500 Then
    '                        valueVat = Before_Vat
    '                    Else
    '                        valueVat = 0
    '                    End If
    '                Else
    '                    valueVat = 0
    '                End If

    '            ElseIf item("TAX_TYPE").Text = 2 Or item("TAX_TYPE").Text = 3 Then 'บุคคล

    '                'If item("AMOUNT").Text <> 0 Then
    '                '    valueVat = (item("AMOUNT").Text * 7) / 107
    '                'Else
    '                '    valueVat = 0
    '                'End If
    '                If item("AMOUNT").Text <> 0 Then
    '                    'คิด 1% 
    '                    Amount = item("AMOUNT").Text
    '                    Before_Vat = (Amount * 1) / 107
    '                    After_Vat = Amount - Before_Vat

    '                    If Amount >= 10000 Then
    '                        valueVat = Before_Vat
    '                    Else
    '                        valueVat = 0
    '                    End If
    '                Else
    '                    valueVat = 0
    '                End If            

    '            ElseIf item("TAX_TYPE").Text = 6 Then 'นิติ ไม่ vat 7%

    '                If item("AMOUNT").Text <> 0 Then
    '                    'คิด 1% 
    '                    Amount = item("AMOUNT").Text
    '                    Before_Vat = (Amount * 1) / 107

    '                    After_Vat = Amount - Before_Vat

    '                    If After_Vat >= 500 Then
    '                        valueVat = Before_Vat
    '                    Else
    '                        valueVat = 0
    '                    End If
    '                Else
    '                    valueVat = 0
    '                End If

    '            ElseIf item("TAX_TYPE").Text = 4 Then 'รัฐ
    '                valueVat = 0
    '            Else
    '                valueVat = 0
    '            End If

    '        Else
    '            valueVat = 0
    '        End If

    '        '------------ค่าปรับ----------------
    '        If IsDBNull(item("nMulct").Text) = False Then
    '            If item("nMulct").Text <> "" Then
    '                valueMulct = item("nMulct").Text
    '            Else
    '                valueMulct = 0
    '            End If
    '        Else
    '            valueMulct = 0
    '        End If

    '        If valueMulct <> 0 Then
    '            nMulct.Text = String.Format("{0:###,###.00}", valueMulct)
    '        Else
    '            nMulct.Text = 0
    '        End If

    '        '--------------ประกันผลงาน--------------
    '        If IsDBNull(item("nInsurance").Text) = False Then
    '            If item("nInsurance").Text <> "" Then
    '                valueInsurance = item("nInsurance").Text
    '            Else
    '                valueInsurance = 0
    '            End If
    '        Else
    '            valueInsurance = 0
    '        End If

    '        If valueInsurance <> 0 Then
    '            nInsurance.Text = String.Format("{0:###,###.00}", valueInsurance)
    '        Else
    '            nInsurance.Text = 0
    '        End If

    '        '------------ภาษี----------------
    '        If valueVat <> 0 Then
    '            nVat.Text = String.Format("{0:###,###.00}", valueVat)
    '        Else
    '            nVat.Text = 0
    '        End If


    '    End If
    'End Sub

    'Private Sub rg_list_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_list.NeedDataSource

    '    Dim dt As New DataTable
    '    Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
    '    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL

    '    ' dt = bao.get_budgetWithdraw_detail(withdraw_bill.Value)
    '    dt = bao.get_relate_det_by_fkid(_BID)
    '    'dt.Columns.Add("nVat", GetType(Double))
    '    'dt.Columns.Add("nMulct", GetType(Double))
    '    'dt.Columns.Add("nInsurance", GetType(Double))
    '    dt.Columns.Add("nAmountMoney", GetType(Double))

    '    'Dim vat As Double = 0
    '    Dim Amount As Double = 0
    '    Dim Before_Vat As Double = 0
    '    Dim After_Vat As Double = 0

    '    For Each dr As DataRow In dt.Rows

    '        '------------ภาษี------------
    '        If IsDBNull(dr("TAX_TYPE")) = False Then
    '            If dr("TAX_TYPE") <> 0 Then
    '                If dr("TAX_TYPE") = 1 Or dr("TAX_TYPE") = 5 Then 'นิติบุคคล

    '                    'คิด 1% ยังไม่คิด 7%
    '                    If IsDBNull(dr("AMOUNT")) = False Then
    '                        If dr("AMOUNT") <> 0 Then

    '                            Amount = dr("AMOUNT")
    '                            Before_Vat = (Amount * 1) / 107
    '                            After_Vat = Amount - Before_Vat

    '                            If After_Vat >= 500 Then
    '                                dr("nVat") = Before_Vat
    '                            Else
    '                                dr("nVat") = 0
    '                            End If
    '                        Else
    '                            dr("nVat") = 0
    '                        End If
    '                    Else
    '                        dr("nVat") = 0
    '                    End If

    '                ElseIf dr("TAX_TYPE") = 2 Or dr("TAX_TYPE") = 3 Then 'บุคคล

    '                    'If IsDBNull(dr("AMOUNT")) = False Then
    '                    '    If dr("AMOUNT") <> 0 Then
    '                    '        dr("VAT") = (dr("AMOUNT") * 7) / 107
    '                    '    Else
    '                    '        dr("VAT") = 0
    '                    '    End If
    '                    'Else
    '                    '    dr("VAT") = 0
    '                    'End If
    '                    If IsDBNull(dr("AMOUNT")) = False Then '1%
    '                        If dr("AMOUNT") <> 0 Then

    '                            Amount = dr("AMOUNT")
    '                            Before_Vat = (Amount * 1) / 107
    '                            After_Vat = Amount - Before_Vat

    '                            If After_Vat >= 10000 Then
    '                                dr("nVat") = Before_Vat
    '                            Else
    '                                dr("nVat") = 0
    '                            End If

    '                        Else
    '                            dr("nVat") = 0
    '                        End If

    '                    Else
    '                        dr("nVat") = 0
    '                    End If

    '                ElseIf dr("TAX_TYPE") = 6 Then 'นิติ ไม่ vat 7%
    '                    'คิด 1% ยังไม่คิด 7%
    '                    If IsDBNull(dr("AMOUNT")) = False Then
    '                        If dr("AMOUNT") <> 0 Then

    '                            Amount = dr("AMOUNT")
    '                            Before_Vat = (Amount * 1) / 107
    '                            After_Vat = Amount - Before_Vat

    '                            If After_Vat >= 500 Then
    '                                dr("nVat") = Before_Vat
    '                            Else
    '                                dr("nVat") = 0
    '                            End If
    '                        Else
    '                            dr("nVat") = 0
    '                        End If
    '                    Else
    '                        dr("nVat") = 0
    '                    End If

    '                ElseIf dr("TAX_TYPE") = 4 Then
    '                    dr("nVat") = 0
    '                End If
    '            Else
    '                dr("nVat") = 0
    '            End If
    '        Else
    '            dr("nVat") = 0
    '        End If

    '        '----------------------------------
    '        'If IsDBNull(dr("nVat")) = False Then
    '        '    dr("nVat") = dr("nVat")
    '        'Else
    '        '    dr("nVat") = 0
    '        'End If

    '        If IsDBNull(dr("nInsurance")) = False Then
    '            dr("nInsurance") = dr("nInsurance")
    '        Else
    '            dr("nInsurance") = 0
    '        End If

    '        If IsDBNull(dr("nMulct")) = False Then
    '            dr("nMulct") = dr("nMulct")
    '        Else
    '            dr("nMulct") = 0
    '        End If

    '        '--------------------------------
    '        If IsDBNull(dr("AMOUNT")) = False Then
    '            If dr("AMOUNT") <> 0 Then
    '                If IsDBNull(dr("AMOUNT_MONEY")) = True Then
    '                    dr("AMOUNT_MONEY") = CDbl(dr("AMOUNT") - (dr("nVat") + dr("nMulct") + dr("nInsurance")))
    '                End If

    '            End If
    '        End If

    '        If IsDBNull(dr("AMOUNT_MONEY")) = False Then
    '            dr("nAmountMoney") = dr("AMOUNT_MONEY")
    '        Else
    '            dr("nAmountMoney") = 0
    '        End If

    '    Next

    '    rg_list.DataSource = dt

    'End Sub

    'Public Sub rebind_grid()
    '    rg_list.Rebind()
    'End Sub

    'Protected Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click

    '    Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW

    '    insert(dao)
    '    dao.insert()

    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกรับเรื่องเบิกเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
    '    'panel_2.Style.Add("Display", "block")
    '    'rg_list.Rebind()

    '    Dim daoBill As New DAO_DISBURSE.TB_BUDGET_BILL
    '    daoBill.Getdata_by_BillId(_BID)

    '    daoBill.fields.STATUS_ID = 10
    '    daoBill.update()

    '    '  panel_2.Style.Add("Display", "block")

    'End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_WITHDRAW)

        dao.fields.BudgetYear = txt_year.Text
        dao.fields.FK_ID = _BID

        If txt_amount.Text <> 0 Then
            dao.fields.Amount = txt_amount.Text
        Else
            dao.fields.Amount = 0
        End If

        If txt_wd_date.Text <> "" Then
            dao.fields.DateRecive = CDate(txt_wd_date.Text)
        Else
            dao.fields.DateRecive = Nothing
        End If

        If txt_withdraw_bill.Text <> 0 Then
            dao.fields.BillCode = txt_withdraw_bill.Text
        Else
            dao.fields.BillCode = ""
        End If

        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL

        dao_bill.Getdata_by_BillId(_BID)
        dao_detail.Getdata_by_Disburse_id(dao_bill.fields.BUDGET_DISBURSE_BILL_ID)

        If dao_detail.fields.BUDGET_PLAN_ID IsNot Nothing Then
            dao.fields.BudgetGroup = dao_detail.fields.BUDGET_PLAN_ID
        Else
            dao.fields.BudgetGroup = 0
        End If

        dao.fields.CITIZEN_ADD = _Citizen
        dao.fields.DATE_ADD = DateTime.Now

        dao.fields.Type_pay = dd_pay.SelectedValue
        dao.fields.Type_payName = dd_pay.SelectedItem.Text
        dao.fields.Type_pay_withdraw = dd_payW.SelectedValue
        dao.fields.Type_payName_withdraw = dd_payW.SelectedItem.Text

    End Sub

    Public Sub get_data(ByRef dao As DAO_DISBURSE.TB_BUDGET_WITHDRAW)
        dd_pay.SelectedValue = dao.fields.Type_pay
        dd_payW.SelectedValue = dao.fields.Type_pay_withdraw
    End Sub

    'Public Sub set_amount()
    '    Dim dao_dpt As New DAO_MAS.TB_MAS_DEPARTMENT
    '    If Request.QueryString("dept") IsNot Nothing Then
    '        dao_dpt.Getdata_by_DEPARTMENT_ID(Request.QueryString("dept"))
    '    Else
    '        If _bid <> "" Then
    '            'Dim dao As New DAO_DISBURSE.TB_CERTIFICATE_ALL
    '            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
    '            dao.Getdata_by_ID(_bid)
    '            dao_dpt.Getdata_by_DEPARTMENT_ID(dao.fields.DEPARTMENT_ID)
    '        End If

    '    End If
    '    Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
    '    Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
    '    If Request.QueryString("bgid") IsNot Nothing Then
    '        dao_bg.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
    '        dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
    '    End If

    '    Dim uti_adjust As New BAO_BUDGET.Budget
    '    Dim adjust_amount As Double = uti_adjust.get_bg_adjust_detail_amount2(_bgyear, _bgid, _dept)
    '    Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
    '    Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App2(_bgid, _bgyear, _dept)

    'End Sub

    'Public Function getDatatextfield(ByVal child_id As Integer) As String
    '    Dim strTextfield As String = ""
    '    Dim dao As New DAO_MAS.TB_BUDGET_PLAN
    '    Dim sup_boolean As Boolean = False
    '    Dim Strsupport As String = ""
    '    dao.Getdata_by_BUDGET_PLAN_ID(child_id)
    '    If dao.fields.BUDGET_IS_SUPPORT_DEPT IsNot Nothing Then
    '        sup_boolean = dao.fields.BUDGET_IS_SUPPORT_DEPT
    '    End If
    '    If sup_boolean <> False Then
    '        Strsupport = "(งบสนับสนุนกรม)"
    '    End If

    '    strTextfield = dao.fields.BUDGET_CODE & " " & dao.fields.BUDGET_DESCRIPTION & " " & Strsupport
    '    Return strTextfield
    'End Function

    'Protected Sub btn_CusSave_Click(sender As Object, e As EventArgs) Handles btn_CusSave.Click

    '    Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
    '    Dim dt As New DataTable

    '    dt = bao.get_relate_det_by_fkid(_BID)

    '    If dt.Rows.Count > 0 Then

    '        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL

    '        insert_detail()

    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเจ้าหนี้เรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
    '        rg_list.Rebind()

    '    End If

    'End Sub

    'Public Sub insert_detail()

    '    Dim date_time As New DateTime
    '    date_time = DateTime.Now

    '    Dim valueVat As Double = 0
    '    Dim valueMulct As Double = 0
    '    Dim valueInsurance As Double = 0

    '    For Each item As GridDataItem In rg_list.Items

    '        Dim dao_c As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL
    '        Dim i As Integer = 0

    '        i = dao_c.count_by_id(item("DETAIL_ID").Text)

    '        Dim id_detail As Integer = item("DETAIL_ID").Text

    '        Dim nVat As RadNumericTextBox = item.FindControl("nVat")
    '        Dim nMulct As RadNumericTextBox = item.FindControl("nMulct")
    '        Dim nInsurance As RadNumericTextBox = item.FindControl("nInsurance")

    '        valueVat = nVat.Value
    '        valueMulct = nMulct.Value
    '        valueInsurance = nInsurance.Value

    '        If i = 0 Then

    '            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL

    '            'Dim txtVat As RadTextBox = DirectCast(item("nVat").FindControl("txtVat"), RadTextBox)
    '            'Dim txtMulct As RadTextBox = DirectCast(item("nMulct").FindControl("txtMulct"), RadTextBox)
    '            'valueVat = txtVat.Text
    '            'valueMulct = txtMulct.Text
    '            Dim dao_with As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
    '            dao_with.Getdata_by_Fk_id(_BID)

    '            dao.fields.FK_WITH_ID = dao_with.fields.ID
    '            dao.fields.CITIZEN_ADD = _Citizen
    '            dao.fields.DATE_ADD = date_time
    '            dao.fields.FK_DETAIL_ID = id_detail

    '            Dim bg_child1 As Integer = 0
    '            Dim bg_child2 As Integer = 0
    '            Dim bg_child3 As Integer = 0
    '            Dim bg_child4 As Integer = 0

    '            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
    '            Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
    '            Dim dao_cus_type As New DAO_MAS.TB_MAS_CUSTOMER_TYPE

    '            dao_detail.Getdata_by_Disburse_id(_BID)
    '            dao_cus.Getdata_by_CUSTOMER_ID(dao_detail.fields.CUSTOMER_ID)
    '            dao_cus_type.Getdata_by_CUSTOMER_TYPE_ID(dao_cus.fields.CUSTOMER_TYPE_ID)

    '            dao.fields.CUS_ID = dao_cus.fields.CUSTOMER_ID
    '            dao.fields.CUS_NAME = dao_cus.fields.CUSTOMER_NAME

    '            dao.fields.CUS_TYPE = dao_cus_type.fields.CUSTOMER_TYPE
    '            dao.fields.CUS_TYPE_ID = dao_cus_type.fields.CUSTOMER_TYPE_ID

    '            dao.fields.AMOUNT = item("AMOUNT").Text
    '            dao.fields.nVat = valueVat
    '            dao.fields.nMulct = valueMulct
    '            dao.fields.nInsurance = valueInsurance
    '            dao.fields.AMOUNT_MONEY = ((item("AMOUNT").Text) - (valueVat + valueMulct + valueInsurance))

    '            dao.insert()

    '        Else

    '            Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL
    '            dao.Getdata_by_FK_DETAIL_ID(id_detail)

    '            Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL
    '            dao2.Getdata_by_ida(dao.fields.IDA)

    '            dao2.fields.AMOUNT = item("AMOUNT").Text
    '            dao2.fields.nVat = valueVat
    '            dao2.fields.nMulct = valueMulct
    '            dao2.fields.nInsurance = valueInsurance
    '            dao2.fields.AMOUNT_MONEY = ((item("AMOUNT").Text) - (valueVat + valueMulct + valueInsurance))

    '            dao2.update()

    '        End If

    '    Next

    'End Sub


End Class