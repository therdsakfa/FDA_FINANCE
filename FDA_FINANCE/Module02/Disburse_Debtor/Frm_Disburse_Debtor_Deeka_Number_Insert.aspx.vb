Public Class Frm_Disburse_Debtor_Deeka_Number_Insert
    Inherits System.Web.UI.Page
    Private _bid As Integer
    Private _bt As Integer
    Private _stat As Integer
    Private _g As Integer
    Public Sub runQuery()
        _bid = Request.QueryString("bid")
        _bt = Request.QueryString("bt")
        _stat = Request.QueryString("stat")
        _g = Request.QueryString("g")
    End Sub
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
        runQuery()
        If Not IsPostBack Then
            Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao.Getdata_by_DEBTOR_BILL_ID(_bid)
            UC_Disburse_Debtor_Deeka_Number_Detail1.getdata(dao)
        End If
    End Sub
    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL
        dao.Getdata_by_DEBTOR_BILL_ID(_bid)
        UC_Disburse_Debtor_Deeka_Number_Detail1.insert(dao)
        dao.fields.STATUS_ID = _stat
        dao.fields.GROUP_ID = _g
        dao.update()

        Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao2.fields.FK_IDA = _bid
        dao2.fields.BILL_TYPE = _bt
        dao2.fields.DATE_ADD = Date.Now
        dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
        dao2.fields.REASON_DATE = Date.Now
        dao2.fields.STATUS_ID = _stat
        dao2.fields.GROUP_ID = _g
        dao2.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class