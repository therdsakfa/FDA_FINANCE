Public Class Frm_Disburse_Debtor_Bill_Insert_Detail
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _bid As Integer
    Private _process As String
    Public Sub runQuery()
        _bid = Request.QueryString("bid")
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
            Dim dao_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
            dao_bill.Getdata_by_DEBTOR_BILL_ID(_bid)
            UC_Disburse_Debtor_Bill_Detail1.bind_ddl_k()
            UC_Disburse_Debtor_Bill_Detail1.getdata(dao_bill)
            UC_Disburse_Debtor_Bill_Detail1.ddl_split()
            UC_Disburse_Debtor_Bill_Detail1.sub_k()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dao As New DAO_DISBURSE.TB_DEBTOR_BILL

        'Dim dao_gf As New DAO_DISBURSE.TB_MAS_GFMIS
        If Request.QueryString("bid") IsNot Nothing Then
            ' UC_Disburse_Debtor_Bill_Detail1.TypeId = 1
            If UC_Disburse_Debtor_Bill_Detail1.chk_len_k = True Then
                dao.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Debtor_Bill_Detail1.insert(dao)
                ' UC_Disburse_Debtor_Bill_Detail1.insert_GF_table(dao_gf, 1, CInt(Request.QueryString("bid")))
                dao.update()

                Dim dao2 As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
                dao2.Getdata_by_DEBTOR_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Debtor_Bill_Detail1.insert_det(dao2)
                dao2.update()

                Dim dao3 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                dao3.fields.STATUS_ID = Request.QueryString("stat")
                dao3.fields.REASON_DATE = Date.Now
                dao3.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
                dao3.fields.DATE_ADD = Date.Now
                dao3.fields.FK_IDA = Request.QueryString("bid")
                dao3.fields.GROUP_ID = Request.QueryString("g")
                dao3.fields.BILL_TYPE = Request.QueryString("bt")
                dao3.insert()

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "บันทึกขบ.สัญญาเงินยืมเลขที่หนังสือ " & _
                               dao.fields.DOC_NUMBER, "DEBTOR_BILL", Request.QueryString("bid"))
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรอกเลขไม่ถูกต้อง');", True)
            End If
            
            ' dao_gf.insert()
            ' Response.Redirect("Frm_Disburse_Debtor_Bill.aspx")
        End If
    End Sub
End Class