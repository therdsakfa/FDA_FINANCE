Public Class Frm_Disburse_Budget_Bill_Insert_V2
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
        UC_Disburse_Budget_DetailV3_Table1.run_Query()
        If Not IsPostBack Then
            If Request.QueryString("bid") <> "" Then
                btn_bill_save.Style.Add("display", "none")
                btn_Edit.Style.Add("display", "block")
                Panel2.Style.Add("display", "block")
            Else
                btn_bill_save.Style.Add("display", "block")
                btn_Edit.Style.Add("display", "none")
                Panel2.Style.Add("display", "none")
            End If
            UC_Disburse_Budget_DetailV3_Table1.bind_dl_account()
            UC_Disburse_Budget_DetailV3_Table1.bind_dd_cus()
            UC_Disburse_Budget_DetailV3_Table1.bind_dd_gl()

            If Request.QueryString("bid") <> "" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Budget_DetailV21.get_data(dao)
            End If
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
        UC_Disburse_Budget_DetailV21.set_data(dao)
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim re_number As String = ""
        re_number = bao.get_max_bill(Request.QueryString("bgYear"), Request.QueryString("bguse"))
        dao.fields.DEPARTMENT_ID = Request.QueryString("dept")
        dao.fields.BUDGET_YEAR = Request.QueryString("bgYear")
        dao.fields.BUDGET_USE_ID = Request.QueryString("bguse")
        dao.fields.GROUP_ID = 0
        'dao.fields.BILL_NUMBER = CDbl(re_number) + 1
        dao.fields.STATUS_ID = 1
        Try
            dao.fields.RECEIVE_DATE = Date.Now()
        Catch ex As Exception

        End Try
        ' dao.fields.rece = CDbl(re_number) + 1 & "/" & Request.QueryString("bgYear")
        dao.insert()

        Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao_app.fields.BILL_TYPE = 1
        dao_app.fields.DATE_ADD = Date.Now
        If Request.QueryString("own") = "" Then
            dao_app.fields.FK_IDA = dao.fields.RELATE_ID
        Else
            dao_app.fields.FK_IDA = dao.fields.BUDGET_DISBURSE_BILL_ID
        End If
        dao_app.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
        dao_app.fields.REASON_DATE = Date.Now
        dao_app.fields.STATUS_ID = 1
        dao_app.fields.GROUP_ID = 0
        dao_app.insert()

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&bid=" & dao.fields.BUDGET_DISBURSE_BILL_ID
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        If Request.QueryString("bid") <> "" Then
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
            UC_Disburse_Budget_DetailV21.set_data(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย');", True)
            UC_Disburse_Budget_DetailV3_Table1.bind_dd_gl()
        End If
    End Sub
End Class