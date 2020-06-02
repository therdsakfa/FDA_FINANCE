Public Class Frm_Disburse_Debtor_Add_Status_Detail
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
            ' UC_Disburse_Debtor_Add_Status_Detail1.set_date()
            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL()
                dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Debtor_Add_Status_Detail1.getdata(dao)
                'UC_Disburse_Debtor_Add_Status_Detail1.set_cancel()
            End If
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL()
        dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
        UC_Disburse_Debtor_Add_Status_Detail1.insert(dao)
        dao.update()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "เพิ่มสถานะสัญญาเงินยืมเลขที่หนังสือ " & _
                       dao.fields.DOC_NUMBER, "DEBTOR_BILL", Request.QueryString("bid"))
        UC_Disburse_Debtor_Add_Status_Detail1.insert_cancel()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class