Public Class Frm_Welfare_Home_Insert
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
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim dao_welfare_home_insert As New DAO_WELFARE.TB_ALL_WELFARE_BILL
        UC_Welfare_Home_Detail.insert(dao_welfare_home_insert)
        dao_welfare_home_insert.insert()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกรายการค่าเช่าบ้าน", _
                       "ALL_WELFARE_BILL", dao_welfare_home_insert.fields.ALL_WELFARE_ID)
        Response.Redirect("Frm_Welfare_Home.aspx")
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Response.Redirect("Frm_Welfare_Home.aspx")
    End Sub
End Class