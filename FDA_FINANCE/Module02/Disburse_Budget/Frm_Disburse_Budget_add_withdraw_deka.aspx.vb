Public Class Frm_Disburse_Budget_add_withdraw_deka
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Public bgyear As String
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Public _SearchId As Integer = 0
    Public _id_deka As Integer = 0

    Public Sub run_Query()
        ' _dept = Request.QueryString("dept")
        ' _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgYear")
        _id_deka = Request.QueryString("id_deka")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        run_Query()

        'Page.Title = "ฏีกาเบิกเงินงบประมาณ"
        UC_Disburse_Budget_withdraw_deka_add_insert1.ispo = "False"
        UC_Disburse_Budget_withdraw_deka_add_insert1.BudgetUseID = 1
        UC_Disburse_Budget_withdraw_deka_add_insert1.PAY_TYPE_ID = 1
        UC_Disburse_Budget_withdraw_deka_add_insert1.Budgetyear = _bgyear
        UC_Disburse_Budget_withdraw_deka_add_insert1.bt = 2
        UC_Disburse_Budget_withdraw_deka_add_insert1.stat = 10
        UC_Disburse_Budget_withdraw_deka_add_insert1.g = 0
        UC_Disburse_Budget_withdraw_deka_add_insert1.is_rebill = False
        UC_Disburse_Budget_withdraw_deka_add_insert1.type = 1
        UC_Disburse_Budget_withdraw_deka_add_insert1.bguse = 1
        UC_Disburse_Budget_withdraw_deka_add_insert1.Citizen = _CLS.CITIZEN_ID

        If Not IsPostBack Then

            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_typeDeka()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_bank()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_bank_Account(0)
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_payW()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_pay()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_month()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_dd_NameDisburse()

            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_ddl_bg()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_ddl_plan()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_ddl_product()
            UC_Disburse_Budget_withdraw_deka_add_insert1.bind_ddl_act()

            UC_Disburse_Budget_withdraw_deka_add_insert1.getBankAccount()
            UC_Disburse_Budget_withdraw_deka_add_insert1.getDekaNumber()

            If _id_deka <> 0 Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA
                dao.Getdata_by_ida(_id_deka)
                UC_Disburse_Budget_withdraw_deka_add_insert1.get_data(dao)
            End If

        End If


    End Sub

    Protected Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click ' หน้าแรก

        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA
        dao.Getdata_by_ida(_id_deka)

        If dao.fields.ID <> 0 Then
            UC_Disburse_Budget_withdraw_deka_add_insert1.insert(dao)
            dao.update()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขใบฏีกาเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)

        Else
            UC_Disburse_Budget_withdraw_deka_add_insert1.insert(dao)
            dao.insert()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกใบฏีกาเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)

        End If
    
    End Sub

End Class






