Public Class Frm_Disburse_Cure_Approve_OK
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
        UC_Disburse_Cure_Approve_Ok1.BillType = 1
        UC_Disburse_Cure_Approve_Ok1.bgyear = Request.QueryString("myear")
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_From_Cure_Study1.getSearchMsg()
        UC_Disburse_Cure_Approve_Ok1.rgFilter(str)
    End Sub

    Private Sub Frm_Disburse_Cure_Approve_OK_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Cure_Approve_Ok1.BillType = 1
        UC_Disburse_Cure_Approve_Ok1.bindseq()
    End Sub

    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        UC_Disburse_Cure_Approve_Ok1.update_true()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)
        UC_Disburse_Cure_Approve_Ok1.rg_rebind()
    End Sub
    Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
        UC_Disburse_Cure_Approve_Ok1.update_false()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
        UC_Disburse_Cure_Approve_Ok1.rg_rebind()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Cure_Approve_Ok1.rg_rebind()
    End Sub
End Class