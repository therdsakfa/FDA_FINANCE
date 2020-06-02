Public Class Frm_Disburse_Relate_Edit
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
            UC_RELATE_BILL_DETAIL1.bind_dd_cus()
            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(Request.QueryString("bid"))
                UC_RELATE_BILL_DETAIL1.get_data(dao)

            End If
        End If
    End Sub
    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        If Request.QueryString("bid") IsNot Nothing Then
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(Request.QueryString("bid"))
            UC_RELATE_BILL_DETAIL1.set_data(dao)

            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        End If
    End Sub
    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        UC_RELATE_BILL_DETAIL1.set_panel_confirm()
        btn_cancel.Style.Add("display", "block")
        btn_confirm.Style.Add("display", "none")
        btn_bill_save.Style.Add("display", "block")
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        UC_RELATE_BILL_DETAIL1.set_panel_cancel()
        btn_cancel.Style.Add("display", "none")
        btn_confirm.Style.Add("display", "block")
        btn_bill_save.Style.Add("display", "none")
    End Sub
End Class