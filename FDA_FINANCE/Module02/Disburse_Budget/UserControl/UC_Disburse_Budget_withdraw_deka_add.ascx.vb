Imports Telerik.Web.UI

Public Class UC_Disburse_Budget_withdraw_deka_add
    Inherits System.Web.UI.UserControl

    Private _Citizen As String
    Public Property Citizen() As String
        Get
            Return _Citizen
        End Get
        Set(ByVal value As String)
            _Citizen = value
        End Set
    End Property

    Private _Budgetyear As Integer
    Public Property Budgetyear() As Integer
        Get
            Return _Budgetyear
        End Get
        Set(ByVal value As Integer)
            _Budgetyear = value
        End Set
    End Property
  
    Private _id_deka As Integer
    Public Property id_deka() As Integer
        Get
            Return _id_deka
        End Get
        Set(ByVal value As Integer)
            _id_deka = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub getDekaNumber()

        Dim dao As New DAO_MAS.TB_MAS_ACCOUNT_BANK
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable

        Dim baoNum As New BAO_BUDGET.DISBURSE_BUDGET
        Dim MaxNum As Integer = 0

        Dim MaxRuning As Integer = 0
        Dim MinRuning As Integer = 0

        If dd_typeDeka.SelectedValue <> 0 Or dd_typeDeka.SelectedValue <> "" Then

            dt = bao.get_Deka_Number_ByType(dd_typeDeka.SelectedValue)

            If dt.Rows.Count > 0 Then

                MaxRuning = dt(0)("EndRunning")
                MinRuning = dt(0)("StartRunning")

                MaxNum = baoNum.get_MaxDeka_Number_ByType(_Budgetyear, dd_typeDeka.SelectedValue)

                If MaxNum > 0 Then
                    If MaxNum < MaxRuning Then
                        txt_DekaNum.Text = MaxNum + 1
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('หมายเลขฏีกาเกินกำหนด กรุณาติดต่อเจ้าหน้าที่ เพื่อขยายช่วงตัวเลข') ;", True)
                    End If

                Else
                    txt_DekaNum.Text = MinRuning
                End If

            Else
                MaxRuning = 0
                MinRuning = 0
            End If

        Else
            txt_DekaNum.Text = ""
        End If

    End Sub

    Public Sub getBankAccount()

        Dim dao As New DAO_MAS.TB_MAS_ACCOUNT_BANK

        If dd_Account.SelectedValue <> 0 Then
            dao.Getdata_by_BANK_ID(dd_Account.SelectedValue)
            txt_BankAccount.Text = dao.fields.ACCOUNT_NUMBER
        Else

            txt_BankAccount.Text = ""
        End If

    End Sub

    Public Sub bind_dd_typeDeka()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_PAYTYPE_DEKA()

        dd_typeDeka.DataSource = dt
        dd_typeDeka.DataBind()
    End Sub

    Public Sub bind_dd_NameDisburse()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_NameDisburse_ByYear(_Budgetyear)

        dd_disburse_Name.DataSource = dt
        dd_disburse_Name.DataBind()
        dd_disburse_Name.DropDownInsertDataFirstRow("---เลือก---", 0)
    End Sub

    Public Sub bind_dd_bank()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_BANK_DEKA()

        dd_bank.DataSource = dt
        dd_bank.DataBind()
    End Sub

    Public Sub bind_dd_bank_Account(ByVal BankId As Integer)
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_AccoutBank_ByBankId(dd_Bank.SelectedValue)

        dd_Account.DataSource = dt
        dd_Account.DataBind()
    End Sub

    Public Sub bind_dd_month()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_All_month()

        dd_month.DataSource = dt
        dd_month.DataBind()
    End Sub

    Public Sub bind_dd_payW()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_TYPE_MONEY_W()

        dd_payW.DataSource = dt
        dd_payW.DataBind()
    End Sub

    Public Sub bind_dd_pay()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_BG_PAYTYPE()

        dd_pay.DataSource = dt
        dd_pay.DataBind()
    End Sub

    Public Sub bind_ddl_bg()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        dao.Getdata_by_BG_YEAR(_Budgetyear)
        ddl_year.DataSource = dao.datas
        ddl_year.DataTextField = "BUDGET_YEAR"
        ddl_year.DataValueField = "BUDGET_PLAN_ID"
        ddl_year.DataBind()
    End Sub

    Public Sub bind_Amount()

        Dim baoVat As New BAO_BUDGET.DISBURSE_BUDGET() 'บุคคล
        Dim Vat As Double = 0

        Vat = baoVat.get_sum_deka_nVat(_id_deka)

        '-----------------------------
        Dim baoTax As New BAO_BUDGET.DISBURSE_BUDGET() 'นิติ
        Dim Tax As Double = 0

        Tax = baoTax.get_sum_deka_nTax_Type(_id_deka)

        '-------------------------
        Dim baoInsurance As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim Insurance As Double = 0

        Insurance = baoInsurance.get_sum_deka_nInsurance(_id_deka)

        '-------------------------
        Dim baoMulct As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim Mulct As Double = 0

        Mulct = baoMulct.get_sum_deka_nMulct(_id_deka)

        '-------------------------
        Dim baoAmount As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim Amount As Double = 0

        Amount = baoAmount.get_sum_deka_AMOUNT(_id_deka)

        '-------------------------
        Dim baoAmountMoney As New BAO_BUDGET.DISBURSE_BUDGET()
        Dim AmountMoney As Double = 0

        AmountMoney = baoAmountMoney.get_sum_deka_AMOUNT_MONEY(_id_deka)


        txt_Amount.Text = String.Format("{0:###,###.00}", Amount) 'ขอเบิก
        txt_Vat.Text = String.Format("{0:###,###.00}", Vat) 'เงินได้บุคคล
        txt_Tax.Text = String.Format("{0:###,###.00}", Tax) 'นิติ
        txt_RecAmount.Text = String.Format("{0:###,###.00}", AmountMoney) 'ขอรับ
        txt_Mulct.Text = String.Format("{0:###,###.00}", Mulct) 'ค่าปรับ


    End Sub

    Public Sub bind_ddl_plan()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao.Getdata_by_head(ddl_year.SelectedValue)
            ddl_plan.DataSource = dao.datas
        Catch ex As Exception

        End Try

        ddl_plan.DataTextField = "BUDGET_DESCRIPTION"
        ddl_plan.DataValueField = "BUDGET_PLAN_ID"
        ddl_plan.DataBind()

    End Sub

    Public Sub bind_ddl_product()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao.Getdata_by_head(ddl_plan.SelectedValue)
            ddl_product.DataSource = dao.datas
        Catch ex As Exception

        End Try

        ddl_product.DataTextField = "BUDGET_DESCRIPTION"
        ddl_product.DataValueField = "BUDGET_PLAN_ID"
        ddl_product.DataBind()

    End Sub

    Public Sub bind_ddl_act()
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        Try
            dao.Getdata_by_head(ddl_product.SelectedValue)
            ddl_act.DataSource = dao.datas
        Catch ex As Exception

        End Try

        ddl_act.DataTextField = "BUDGET_DESCRIPTION"
        ddl_act.DataValueField = "BUDGET_PLAN_ID"
        ddl_act.DataBind()

    End Sub

    Public Sub get_data(ByRef dao As DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA)

        'วันที่ฏีกา

        If dao.fields.DateDeka IsNot Nothing Then
            txt_deka_date.Text = CDate(dao.fields.DateDeka)
        Else
            txt_deka_date.Text = CDate(Date.Now).ToShortDateString()
        End If

        'ประเภทฏีกา
        dd_typeDeka.SelectedValue = dao.fields.DakaType

        'ปี
        ddl_year.SelectedItem.Text = dao.fields.BudgetYear

        'เลขฏีกา
        txt_DekaNum.Text = dao.fields.DekaBillNumber

        'ชื่อผู้เบิก
        dd_disburse_Name.SelectedValue = dao.fields.disburse_Name

        'ประเภทการเบิก
        dd_payW.SelectedValue = dao.fields.Type_payWithdraw

        'ที่คลังรับใบกันเงิน
        txt_treasury.Text = dao.fields.treasury

        'ประจำเดือน
        dd_month.SelectedValue = dao.fields.MonthId

        'หมวดงบ
        ddl_BudgetGroup.SelectedValue = dao.fields.BudgetGroup

        'แผนงาน
        ddl_plan.SelectedValue = dao.fields.PlanId

        ' ผลผลิต
        ddl_product.SelectedValue = dao.fields.ProductId

        'กิจกรรม
        ddl_act.SelectedValue = dao.fields.ActivityId

        ' ประเภทการจ่าย
        dd_pay.SelectedValue = dao.fields.Type_pay

        'ชื่อธนาคาร
        dd_Bank.SelectedValue = dao.fields.BankType

        'ชื่อบัญชี
        dd_Account.SelectedValue = dao.fields.NameAccBank

        'เลขที่บัญชี 
        txt_BankAccount.Text = dao.fields.NumBank

    End Sub

    'Private Sub ddl_plan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_plan.SelectedIndexChanged
    '    bind_ddl_product()
    '    bind_ddl_act()
    'End Sub

    'Private Sub ddl_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_product.SelectedIndexChanged
    '    bind_ddl_act()
    'End Sub

    'Private Sub dd_Account_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Account.SelectedIndexChanged
    '    getBankAccount()
    'End Sub

    'Private Sub dd_Bank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Bank.SelectedIndexChanged
    '    bind_dd_bank_Account(dd_Bank.SelectedValue)
    'End Sub

    'Private Sub dd_typeDeka_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_typeDeka.SelectedIndexChanged
    '    getDekaNumber()
    'End Sub

End Class