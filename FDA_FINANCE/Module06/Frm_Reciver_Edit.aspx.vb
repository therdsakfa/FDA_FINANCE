Public Partial Class Frm_Reciver_Edit
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
        If Not IsPostBack Then
            Dim dao_money_receiver_edit As New DAO_MAS.TB_MAS_MONEY_RECEIVER
            dao_money_receiver_edit.Getdata_by_RECEIVER_MONEY_ID(Request.QueryString("rc_id"))
            UC_Reciver_Details1.getdata(dao_money_receiver_edit)

        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim qstr_rc_id As Integer
        Dim dao_money_receiver_edit As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        Dim dao_clean As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        If Request.QueryString("rc_id") IsNot Nothing Then
            qstr_rc_id = Request.QueryString("rc_id").ToString()
            dao_money_receiver_edit.Getdata_by_RECEIVER_MONEY_ID(qstr_rc_id)
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลผู้รับเงิน " & dao_money_receiver_edit.fields.RECEIVER_NAME, "MAS_MONEY_RECEIVER", Request.QueryString("rc_id"))
            dao_clean.Get_All_RECEIVER()

            For Each dao_clean.fields In dao_clean.datas
                dao_clean.fields.IS_RECEIVER = False
            Next
            dao_clean.update()

            UC_Reciver_Details1.insert(dao_money_receiver_edit)
            dao_money_receiver_edit.update()
            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Reciver.aspx';", True)

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
    End Sub
End Class