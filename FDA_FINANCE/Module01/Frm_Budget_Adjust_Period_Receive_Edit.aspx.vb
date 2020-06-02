Public Class Frm_Budget_Adjust_Period_Receive_Edit
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
            If Request.QueryString("ba_id") IsNot Nothing Then
                Dim dao_ad As New DAO_BUDGET.TB_BUDGET_ADJUST
                Dim dao_ad_detail As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
                dao_ad.Getdata_by_BUDGET_ADJUST_ID(Request.QueryString("ba_id"))
                If dao_ad.fields.BUDGET_ADJUST_ID <> 0 Then
                    dao_ad_detail.Getdata_by_BG_Adjust_ID(dao_ad.fields.BUDGET_ADJUST_ID)
                    UC_Budget_Period_Receive_Detail1.getdata(dao_ad_detail)
                End If

            End If
        End If

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("ba_id") IsNot Nothing Then
            Dim dao_ad As New DAO_BUDGET.TB_BUDGET_ADJUST
            Dim dao_ad_detail As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
            dao_ad.Getdata_by_BUDGET_ADJUST_ID(Request.QueryString("ba_id"))
            dao_ad_detail.Getdata_by_BG_Adjust_ID(Request.QueryString("ba_id"))

            If dao_ad_detail.fields.BUDGET_ADJUST_ID <> 0 Then
                Dim dao_detail As New DAO_BUDGET.TB_BUDGET_ADJUST_DETAIL
                dao_detail.Getdata_by_BG_Adjust_ID(dao_ad.fields.BUDGET_ADJUST_ID)
                UC_Budget_Period_Receive_Detail1.insert(dao_detail)
                dao_detail.update()

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "แก้ไขการรับงวดเลขหนังสือ " & _
                               dao_ad_detail.fields.DOC_NUMBER, "BUDGET_ADJUST_DETAIL", dao_ad_detail.fields.BUDGET_ADJUST_ID)
            Else
                'dao_ad_detail.Getdata_by_BG_Adjust_ID(Request.QueryString("ba_id"))
                UC_Budget_Period_Receive_Detail1.insert(dao_ad_detail)
                dao_ad_detail.insert()
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "บันทึกการรับงวดเลขหนังสือ " & _
                               dao_ad_detail.fields.DOC_NUMBER, "BUDGET_ADJUST_DETAIL", dao_ad_detail.fields.BUDGET_ADJUST_ID)
            End If

      
        End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class