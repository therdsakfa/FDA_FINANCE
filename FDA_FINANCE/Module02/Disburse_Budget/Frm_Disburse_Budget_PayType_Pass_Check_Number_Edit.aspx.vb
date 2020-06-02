Public Class Frm_Disburse_Budget_PayType_Pass_Check_Number_Edit
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _bt As Integer
    Private _stat As Integer
    Private _bid As Integer
    Private _g As Integer
    Private _id_det As String
    Sub runQuery()
        _bt = Request.QueryString("bt")
        _stat = Request.QueryString("stat")
        _bid = Request.QueryString("bid")
        _g = Request.QueryString("g")
        _id_det = Request.QueryString("id_det")
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
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL()
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Budget_PayType_Pass_Check_Number_Detail1.getdata(dao)
            End If
        End If
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL()
        dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
        'UC_Disburse_Budget_PayType_Pass_Check_Number_Detail1.insert(dao)
        dao.fields.STATUS_ID = _stat
        dao.fields.GROUP_ID = _g
        dao.update()

        
        If _id_det <> "" Then
            Dim arr_det As String() = _id_det.Split(",")
            For i As Integer = 0 To arr_det.Length - 1
                Try
                    Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                    dao_det.Getdata_by_DETAIL_ID(arr_det(i))
                    UC_Disburse_Budget_PayType_Pass_Check_Number_Detail1.insert_det(dao_det)
                    dao_det.update()
                Catch ex As Exception

                End Try

            Next
        End If

        Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao_app.fields.BILL_TYPE = _bt
        dao_app.fields.DATE_ADD = Date.Now
        dao_app.fields.FK_IDA = _bid
        dao_app.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
        dao_app.fields.REASON_DATE = Date.Now
        dao_app.fields.STATUS_ID = _stat
        dao_app.fields.GROUP_ID = _g

        dao_app.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class