﻿Public Partial Class Frm_Reciver_Insert
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
        Dim dao_money_receiver_insert As New DAO_MAS.TB_MAS_MONEY_RECEIVER
        UC_Reciver_Details1.insert(dao_money_receiver_insert)
        dao_money_receiver_insert.insert()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลผู้รับเงิน " & dao_money_receiver_insert.fields.RECEIVER_NAME, "MAS_MONEY_RECEIVER", dao_money_receiver_insert.fields.RECEIVER_MONEY_ID)
        '' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เพิ่มข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Reciver.aspx';", True)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class