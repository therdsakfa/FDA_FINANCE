Public Class Frm_Reason
    Inherits System.Web.UI.Page
    Private _fk_ida As Integer
    Private _stat As Integer
    Private _bt As Integer
    Private _CLS As New CLS_SESSION
    Private _g As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _bt = Request.QueryString("bt")
        _fk_ida = Request.QueryString("fk_ida")
        _stat = Request.QueryString("stat")
        _g = Request.QueryString("g")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao.fields.BILL_TYPE = _bt
        dao.fields.DATE_ADD = Date.Now
        dao.fields.FK_IDA = _fk_ida
        dao.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.REASON = txt_Reason.Text
        dao.fields.REASON_DATE = Date.Now
        dao.fields.STATUS_ID = _stat
        dao.fields.GROUP_ID = _g

        dao.insert()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        UC_Reason_Reject1.rg_rebind()
    End Sub

End Class