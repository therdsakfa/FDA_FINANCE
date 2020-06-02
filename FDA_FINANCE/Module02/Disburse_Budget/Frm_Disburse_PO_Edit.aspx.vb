Public Class Frm_Disburse_PO_Edit
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
 
        UC_Disburse_Budget_DetailV21.is_insert = True
        UC_Disburse_Budget_DetailV21.dept_id = Request.QueryString("dept")
        If Not IsPostBack Then
            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If Request.QueryString("bid") IsNot Nothing Then
                Dim bid As String = ""
                bid = Request.QueryString("bid")
                If bid <> "sup" Or bid <> "out" Then
                    dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(bid)
                    UC_Disburse_Budget_DetailV21.get_data(dao_head)
                End If

            End If
        End If
    End Sub

    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Then
                dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_DetailV21.set_data(dao_disburse_bill)
                dao_disburse_bill.fields.IS_PO = True
                dao_disburse_bill.update()

                dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                UC_Disburse_PO_Detail_Table_Edit1.update(CInt(Request.QueryString("bid")))

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "แก้ไขข้อมูลใบจัดซื้อจัดจ้างเลขที่หนังสือ " _
                               & dao_disburse_bill.fields.DOC_NUMBER, "BUDGET_BILL", Request.QueryString("bid"))
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If
        End If
    End Sub


    Private Sub Frm_Disburse_PO_Edit_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'If Request.QueryString("d") IsNot Nothing Then
        '    UC_Disburse_Budget_Detail1.stat_egp = 2
        'Else
        '    UC_Disburse_Budget_Detail1.stat_egp = 1
        'End If
        'UC_Disburse_Budget_Detail1.set_egp_txt()
    End Sub
End Class