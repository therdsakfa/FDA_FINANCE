Public Partial Class Frm_Disburse_Budget_PayType_Direct_Edit
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

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
            If Request.QueryString("bid") IsNot Nothing Then
                'UC_Disburse_Budget_PayType_Direct_Detail1.set_date()
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL()
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Budget_PayType_Direct_Detail1.getdata(dao)

            End If
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL()
        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
        UC_Disburse_Budget_PayType_Direct_Detail1.insert(dao)

        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึก/แก้ไขสถานะจ่ายตรงใบเบิกจ่ายเลขที่หนังสือ " & dao.fields.DOC_NUMBER & " เลขบ." & dao.fields.BILL_NUMBER, "BUDGET_BILL", Request.QueryString("bid"))
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        ' Response.Redirect("Frm_Disburse_Budget_PayType_Direct.aspx")
    End Sub
End Class