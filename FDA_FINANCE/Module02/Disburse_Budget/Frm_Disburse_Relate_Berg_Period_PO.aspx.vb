Public Class Frm_Disburse_Relate_Berg_Period_PO
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
        UC_RELATE_BILL_USER_BERG_PO1.runQuery()
        If Not IsPostBack Then
            If Request.QueryString("bid") <> "" Then
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(Request.QueryString("bid"))
                UC_RELATE_BILL_USER_BERG_PO1.get_data(dao)
            End If
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        UC_RELATE_BILL_USER_BERG_PO1.insert_det()
        'UC_RELATE_BILL_USER_BERG_PO1.save_period_data()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class