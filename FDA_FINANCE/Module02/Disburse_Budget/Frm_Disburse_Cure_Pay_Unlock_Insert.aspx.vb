Public Class Frm_Disburse_Cure_Pay_Unlock_Insert
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _bt As Integer
    Private _stat As Integer
    Private _bid As Integer
    Private _g As Integer
    Sub runQuery()
        _bt = Request.QueryString("bt")
        _stat = Request.QueryString("stat")
        _bid = Request.QueryString("bid")
        _g = Request.QueryString("g")
    End Sub
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        If Not IsPostBack Then
            If Request.QueryString("bid") IsNot Nothing Then
                Dim dao As New DAO_DISBURSE.TB_CURE_STUDY()
                dao.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
                UC_Disburse_Cure_Study_Pay_Unlock_Detail1.getdata(dao)
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DISBURSE.TB_CURE_STUDY()
        dao.Getdata_by_CURE_STUDY_ID(Request.QueryString("bid"))
        UC_Disburse_Cure_Study_Pay_Unlock_Detail1.insert(dao)
        dao.fields.STATUS_ID = _stat
        dao.fields.GROUP_ID = _g
        dao.update()
        UC_Disburse_Cure_Study_Pay_Unlock_Detail1.insert_stat(_bid, _bt, _CLS.CITIZEN_ID_AUTHORIZE, _stat)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class