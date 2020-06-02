Public Class Frm_Disburse_OutsideDebtor_Approve_Detail
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
        UC_Disburse_OutsideDebtor_Approve_Detail1.insert(dao)
        dao.fields.GROUP_ID = Request.QueryString("g")
        dao.fields.STATUS_ID = Request.QueryString("stat")
        dao.update()
        Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao2.fields.STATUS_ID = Request.QueryString("stat")
        dao2.fields.GROUP_ID = Request.QueryString("g")
        dao2.fields.BILL_TYPE = Request.QueryString("bt")
        dao2.fields.REASON_DATE = Date.Now
        dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
        dao2.fields.DATE_ADD = Date.Now
        dao2.fields.FK_IDA = Request.QueryString("bid")
        dao2.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)

    End Sub
End Class