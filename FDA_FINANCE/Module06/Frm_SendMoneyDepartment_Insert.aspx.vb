Public Partial Class Frm_SendMoneyDepartment_Insert
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        'Try
        '    _CLS = Session("CLS")
        'Catch ex As Exception
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dao_send_money_insert As New DAO_MAS.TB_MAS_SEND_MONEY_DEPARTMENT
        Dim txt_BANK_ACCOUNT As TextBox = UC_SendMoneyDepartment_Details1.FindControl("txt_BANK_ACCOUNT")
        Dim txt_DEPARTMENT_OR_BANK_NAME As TextBox = UC_SendMoneyDepartment_Details1.FindControl("txt_DEPARTMENT_OR_BANK_NAME")
        Dim txt_BRANCH_NAME As TextBox = UC_SendMoneyDepartment_Details1.FindControl("txt_BRANCH_NAME")
        Dim txt_SHORT_DEPARTMENT_NAME As TextBox = UC_SendMoneyDepartment_Details1.FindControl("txt_SHORT_DEPARTMENT_NAME")

        dao_send_money_insert.fields.BANK_ACCOUNT = txt_BANK_ACCOUNT.Text
        dao_send_money_insert.fields.DEPARTMENT_OR_BANK_NAME = txt_DEPARTMENT_OR_BANK_NAME.Text
        dao_send_money_insert.fields.BRANCH_NAME = txt_BRANCH_NAME.Text
        dao_send_money_insert.fields.SHORT_DEPARTMENT_NAME = txt_SHORT_DEPARTMENT_NAME.Text
        dao_send_money_insert.insert()
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เพิ่มข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_SendMoneyDepartment.aspx';", True)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class