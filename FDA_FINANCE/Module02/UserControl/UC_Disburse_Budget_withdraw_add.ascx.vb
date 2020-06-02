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

    Public bgyear As String
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Public Sub run_Query()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        run_Query()
        'bind_dd_debtor()
        bg_year.Text = _bgyear
        Dim dao_dep As New DAO_MAS.TB_MAS_DEPARTMENT
        dao_dep.Getdata_by_DEPARTMENT_ID(_dept)
        lb_dep.Text = dao_dep.fields.DEPARTMENT_DESCRIPTION

        'rnt_amount.Value = 0.0
        'rnt_vat.Value = 0.0
        'txt_wd_date.Text = ""
        'txt_wd_date.Text = DateTime.Now
    End Sub

    'Public Sub bind_dd_debtor()
    '    Dim bao As New BAO_BUDGET.MASS
    '    Dim dt As DataTable = bao.get_debtor_vat()

    '    dd_type_deb.DataSource = dt
    '    dd_type_deb.DataBind()
    'End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        'If Request.QueryString("bid") <> "" Then

        'End If
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        'dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao.fields.BUDGET_DISBURSE_BILL_ID)
        dt = bao.get_budgetWithdraw_detail(withdraw_bill.Value)
        RadGrid1.DataSource = dt
    End Sub
    Public Sub rebind_grid()
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
                dao.Getdata_by_ida(item("ID").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub
    Protected Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click
        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
        If rnt_amount.Value > 0 And rnt_vat.Value > 0 Then
            insert(dao)
            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
            RadGrid1.Rebind()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
        End If

       

        

    End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_WITHDRAW)
        'If deeka_date.Text <> "" Then
        '    dao.fields.Date_deka = CDate(deeka_date.Text)
        'Else
        '    dao.fields.Date_deka = Nothing
        'End If
        dao.fields.BudgetYear = bg_year.Text

        dao.fields.FK_ID = withdraw_bill.Value

        If txt_wd_date.Text <> "" Then
            dao.fields.DateRecive = CDate(txt_wd_date.Text)
        Else
            dao.fields.DateRecive = Nothing
        End If

        dao.fields.Type_pay = dd_payS.SelectedValue
        dao.fields.Type_money = dd_typeMoney.SelectedValue
        dao.fields.Type_NameMoney = dd_typeMoney.SelectedItem.Text
        dao.fields.Type_payName = dd_payS.SelectedItem.Text
        dao.fields.Type_pay_withdraw = dd_payW.SelectedValue
        dao.fields.Type_payName_withdraw = dd_payW.SelectedItem.Text
        dao.fields.Type_Deb = dd_type_deb.SelectedValue
        dao.fields.Type_DebName = dd_type_deb.SelectedItem.Text
        Try
            dao.fields.Amount = rnt_amount.Value
        Catch ex As Exception
            dao.fields.Amount = 0
        End Try
        Try
            dao.fields.Vat = rnt_vat.Value
        Catch ex As Exception
            dao.fields.Vat = 0
        End Try
        


        

    End Sub

    Public Sub get_data(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)

        'Dim bill As Integer = 0
        'bill = dao.fields.BUDGET_DISBURSE_BILL_ID
        'bill = withdraw_bill.Text

        withdraw_bill.Value = dao.fields.BUDGET_DISBURSE_BILL_ID
        If dao.fields.DOC_DATE IsNot Nothing Then
            txt_DOC_DATE.Text = CDate(dao.fields.DOC_DATE).ToShortDateString()
        End If
        txt_DOC_NUMBER.Text = dao.fields.DOC_NUMBER
        txt_DESCRIPTION.Text = dao.fields.DESCRIPTION

       
        'lb_Allamount.Text = dao.fields.
        'bg_year.Text = Request.QueryString("myear")
        'If dao.fields.BILL_DATE IsNot Nothing Then
        '    txt_dodate.Text = CDate(dao.fields.BILL_DATE).ToShortDateString()
        'End If

    End Sub
    Public Sub set_amount()
        Dim dao_dpt As New DAO_MAS.TB_MAS_DEPARTMENT
        If Request.QueryString("dept") IsNot Nothing Then
            dao_dpt.Getdata_by_DEPARTMENT_ID(Request.QueryString("dept"))
        Else
            If _bid <> "" Then
                'Dim dao As New DAO_DISBURSE.TB_CERTIFICATE_ALL
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(_bid)
                dao_dpt.Getdata_by_DEPARTMENT_ID(dao.fields.DEPARTMENT_ID)
            End If

        End If
        Dim dao_head_bg As New DAO_MAS.TB_BUDGET_PLAN
        Dim dao_bg As New DAO_MAS.TB_BUDGET_PLAN
        If Request.QueryString("bgid") IsNot Nothing Then
            dao_bg.Getdata_by_BUDGET_PLAN_ID(Request.QueryString("bgid"))
            dao_head_bg.Getdata_by_BUDGET_PLAN_ID(dao_bg.fields.BUDGET_CHILD_ID)
        End If

        Dim uti_adjust As New BAO_BUDGET.Budget
        Dim adjust_amount As Double = uti_adjust.get_bg_adjust_detail_amount2(_bgyear, _bgid, _dept)
        Dim bao_dis_app As New BAO_BUDGET.DISBURSE_BUDGET
        Dim disburse_app As Double = bao_dis_app.get_Amount_Disburse_App2(_bgid, _bgyear, _dept)

    End Sub
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

    
End Class