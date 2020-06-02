Public Class Frm_Disburse_Budget_add_withdraw
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    'Public bgyear As String = ""
    Dim _dept As String = ""
    Dim _bgid As String = ""
    Dim _bgyear As String = ""
    Dim _bid As String = ""
    Dim _stat As String = ""
    Dim _g As String = ""
    Dim _det As String = ""
    Dim _Citizen As String = ""

    Public Sub RunQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        _bgyear = Request.QueryString("bgyear")
        _bid = Request.QueryString("bid")
        _stat = Request.QueryString("stat")
        _g = Request.QueryString("g")
        _det = Request.QueryString("det")
        _Citizen = Request.QueryString("Citizen")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        RunQuery()

        UC_Disburse_Budget_withdraw_add1.BudgetYear = _bgyear
        UC_Disburse_Budget_withdraw_add1.dept_id = _dept
        UC_Disburse_Budget_withdraw_add1.BID = _bid
        UC_Disburse_Budget_withdraw_add1.g = _g
        UC_Disburse_Budget_withdraw_add1.stat = _stat
        UC_Disburse_Budget_withdraw_add1.Citizen = _Citizen

        UC_Disburse_Budget_withdraw_add_Part21.BudgetYear = _bgyear
        UC_Disburse_Budget_withdraw_add_Part21.dept_id = _dept
        UC_Disburse_Budget_withdraw_add_Part21.BID = _bid
        UC_Disburse_Budget_withdraw_add_Part21.g = _g
        UC_Disburse_Budget_withdraw_add_Part21.stat = _stat
        UC_Disburse_Budget_withdraw_add_Part21.Citizen = _Citizen

        'If _bid <> "" Then
        '    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        '    dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(_bid)

        '    If dao.fields.STATUS_ID = 10 Then
        '        Panel2.Style.Add("display", "block")
        '    Else
        '        Panel2.Style.Add("display", "none")
        '    End If

        'End If

        If Not IsPostBack Then

            ' UC_Disburse_Budget_withdraw_add1.bind_dd_typeMoney()
            UC_Disburse_Budget_withdraw_add1.bind_dd_pay()
            UC_Disburse_Budget_withdraw_add1.bind_dd_payW()
            'UC_Disburse_Budget_withdraw_add1.bind_dd_type_deb()
            'UC_Disburse_Budget_withdraw_add1.bind_dd_typeMoney()
            'UC_Disburse_Budget_DetailV2_Table1.show_img_tooltip()



        End If
    End Sub

    '------------รับเรื่อง------------
    Protected Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click

        Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW
        dao.Getdata_by_Fk_id(_bid)

        If dao.fields.ID <> 0 Then

            UC_Disburse_Budget_withdraw_add1.insert(dao)
            dao.update()

            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขรับเรื่องเบิกเรียบร้อย')", True)

            UC_Disburse_Budget_withdraw_add_Part21.Bind_Data()

        Else

            UC_Disburse_Budget_withdraw_add1.insert(dao)
            dao.insert()

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกรับเรื่องเบิกเรียบร้อย')", True)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเจ้าหนี้เรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Rediret').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)

            Panel2.Style.Add("Display", "block")
            'rg_list.Rebind()

            Dim daoBill As New DAO_DISBURSE.TB_BUDGET_BILL
            daoBill.Getdata_by_BillId(_bid)

            daoBill.fields.STATUS_ID = 10
            daoBill.update()

            UC_Disburse_Budget_withdraw_add_Part21.Bind_Data()

        End If

    End Sub
   
    ''------------เจ้าหนี้-------------
    'Protected Sub btn_CusSave_Click(sender As Object, e As EventArgs) Handles btn_CusSave.Click

    '    Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
    '    Dim dt As New DataTable

    '    dt = bao.get_relate_det_by_fkid(_BID)

    '    If dt.Rows.Count > 0 Then

    '        'Dim dao As New DAO_DISBURSE.TB_BUDGET_WITHDRAW_DETAIL

    '        UC_Disburse_Budget_withdraw_add_Part21.insert_detail()

    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเจ้าหนี้เรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
    '        UC_Disburse_Budget_withdraw_add_Part21.rebind_grid()

    '    End If

    'End Sub

End Class