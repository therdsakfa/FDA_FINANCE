Public Class Frm_Disburse_Welfare_Insert
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
        If Request.QueryString("bgyear") <> "" Then
            UC_Disburse_Cure_Welfare_Detail1.BudgetYear = Request.QueryString("bgyear")
        End If
        UC_Disburse_Cure_Welfare_Detail1.is_insert = True
        UC_Disburse_Cure_Welfare_Detail1.BillType = 1
        If Not IsPostBack Then
            UC_Disburse_Cure_Welfare_Detail1.set_date()
        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim ad As String = NameUserAD()
        Dim dao_head As New DAO_DISBURSE.TB_CURE_STUDY
        UC_Disburse_Cure_Welfare_Detail1.insert(dao_head, ad)
        dao_head.insert()
        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกใบเบิกจ่ายค่ารักษา/ค่าเล่าเรียนเลขที่หนังสือ " & dao_head.fields.DOC_NUMBER, "CURE_STUDY", dao_head.fields.CURE_STUDY_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class