Public Class Frm_Disburse_Budget_Deeka_withdraw_Insert_v2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            UC_deeka_withdraw_add_V21.bind_ddl_BudgetYear()
            UC_deeka_withdraw_add_V21.bind_dd_gl()
            UC_deeka_withdraw_add_V21.bind_dd_name()


        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click

        Dim dao As New DAO_DISBURSE.TB_Deeka_Withdraw

        UC_deeka_withdraw_add_V21.insert(dao)
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.$('#ctl00_ContentPlaceHolder1_btn_Redirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)


    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        'If Request.QueryString("bid") <> "" Then
        '    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        '    dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
        '    UC_Disburse_Budget_DetailV21.set_data(dao)
        '    dao.update()
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย');", True)
        '    UC_Disburse_Budget_DetailV4_Table1.bind_dd_gl()
        'End If
    End Sub

End Class