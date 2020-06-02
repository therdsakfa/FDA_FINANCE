Public Class Frm_Disburse_Budget_add_withdraw_deka1
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
        _id_deka = Request.QueryString("id_deka")
        _bgyear = Request.QueryString("bgYear")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        run_Query()

        Page.Title = "ฏีกาเบิกเงินงบประมาณ"
        UC_Disburse_Budget_withdraw_deka_add1.Budgetyear = _bgyear
        UC_Disburse_Budget_withdraw_deka_add1.Citizen = _CLS.CITIZEN_ID
        UC_Disburse_Budget_withdraw_deka_add1.id_deka = _id_deka


        '----------2------------
        UC_Disburse_Budget_withdraw_deka_add21.Budgetyear = _bgyear
        UC_Disburse_Budget_withdraw_deka_add21.Citizen = _CLS.CITIZEN_ID
        UC_Disburse_Budget_withdraw_deka_add21.id_deka = _id_deka

        '----------3------------
        UC_Disburse_Budget_withdraw_deka_add31.Budgetyear = _bgyear
        UC_Disburse_Budget_withdraw_deka_add31.Citizen = _CLS.CITIZEN_ID
        UC_Disburse_Budget_withdraw_deka_add31.id_deka = _id_deka

        '----------4-----------
        UC_Disburse_Budget_withdraw_deka_add41.Budgetyear = _bgyear
        UC_Disburse_Budget_withdraw_deka_add41.Citizen = _CLS.CITIZEN_ID
        UC_Disburse_Budget_withdraw_deka_add41.id_deka = _id_deka

        If Not IsPostBack Then

            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_typeDeka()
            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_bank()
            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_bank_Account(0)
            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_payW()
            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_pay()
            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_month()
            UC_Disburse_Budget_withdraw_deka_add1.bind_dd_NameDisburse()

            UC_Disburse_Budget_withdraw_deka_add1.bind_ddl_bg()
            UC_Disburse_Budget_withdraw_deka_add1.bind_ddl_plan()
            UC_Disburse_Budget_withdraw_deka_add1.bind_ddl_product()
            UC_Disburse_Budget_withdraw_deka_add1.bind_ddl_act()
            UC_Disburse_Budget_withdraw_deka_add1.getBankAccount()
            'getDekaNumber()

            If _id_deka <> 0 Then
                Dim daoGet As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA
                daoGet.Getdata_by_ida(_id_deka)
                UC_Disburse_Budget_withdraw_deka_add1.get_data(daoGet)
            End If

            UC_Disburse_Budget_withdraw_deka_add1.bind_Amount()

            UC_Disburse_Budget_withdraw_deka_add21.Bind_Data()
            UC_Disburse_Budget_withdraw_deka_add31.Bind_Data()

            UC_Disburse_Budget_withdraw_deka_add41.bind_dd_Budget()
            UC_Disburse_Budget_withdraw_deka_add41.Bind_Data()

            '-------------Show-----------------'
            bind_Uc()

        End If
    End Sub

    Public Sub bind_Uc()
        '-------------Show-----------------'
        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_DETAIL
        dao.Getdata_by_fk_deka(_id_deka)

        Dim dao2 As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA_BUDGET_GROUP
        dao2.Getdata_by_FK_DEKA(_id_deka)

        If dao.fields.IDA = 0 And dao2.fields.IDA = 0 Then

            Panel3.Style.Add("display", "none")
            Panel4.Style.Add("display", "none")

        ElseIf dao.fields.IDA <> 0 And dao2.fields.IDA = 0 Then

            Panel3.Style.Add("display", "block")
            Panel4.Style.Add("display", "none")

        ElseIf dao.fields.IDA <> 0 And dao2.fields.IDA <> 0 Then

            Panel3.Style.Add("display", "block")
            Panel4.Style.Add("display", "block")

        Else
            Panel3.Style.Add("display", "none")
            Panel4.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click 'หน้า2

        UC_Disburse_Budget_withdraw_deka_add21.updates()
        UC_Disburse_Budget_withdraw_deka_add21.Bind_Data()
        bind_Uc()
        UC_Disburse_Budget_withdraw_deka_add31.Bind_Data()
        UC_Disburse_Budget_withdraw_deka_add41.bind_dd_Budget()

    End Sub

    Protected Sub btn_Save2_Click(sender As Object, e As EventArgs) Handles btn_Save2.Click 'หน้า3

        UC_Disburse_Budget_withdraw_deka_add31.updates()
        UC_Disburse_Budget_withdraw_deka_add31.Bind_Data()
        bind_Uc()
        UC_Disburse_Budget_withdraw_deka_add41.bind_dd_Budget()

    End Sub

    Protected Sub btn_Save3_Click(sender As Object, e As EventArgs) Handles btn_Save3.Click 'หน้า4

        UC_Disburse_Budget_withdraw_deka_add41.updates()
        UC_Disburse_Budget_withdraw_deka_add41.Bind_Data()
        UC_Disburse_Budget_withdraw_deka_add31.Bind_Data()

        'Dim daoGet As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DEKA
        'daoGet.Getdata_by_ida(_id_deka)

        'If daoGet.fields.ID <> 0 Then
        '    UC_Disburse_Budget_withdraw_deka_add1.get_data(daoGet)
        'End If

        bind_Uc()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

    End Sub

End Class