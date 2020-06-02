Public Class FRM_CHANGE_NAME
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("ida"))
                txt_full_name.Text = dao.fields.FULLNAME
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("ida") <> "" Then
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("ida"))
            dao.fields.FULLNAME = txt_full_name.Text
            dao.update()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        End If
    End Sub
End Class