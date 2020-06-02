Public Class Frm_Disburse_OutsideDebtor_Bill_Edit
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
        If Not IsPostBack Then
            Dim dao_head As New DAO_DISBURSE.TB_DEBTOR_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
            UC_Disburse_Debtor_Detail1.is_insert = True
            If Request.QueryString("bid") IsNot Nothing Then
                If Request.QueryString("bid") <> "sup" Then
                    dao_head.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                    UC_Disburse_Debtor_Detail1.getdata(dao_head)
                    dao_detail.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                End If

            End If
        End If
    End Sub

    Protected Sub btn_bill_edit_Click(sender As Object, e As EventArgs) Handles btn_bill_edit.Click
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_DEBTOR_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_DEBTOR_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Or Request.QueryString("bid") <> "out" Then
                dao_disburse_bill.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Debtor_Detail1.insert(dao_disburse_bill, NameUserAD())
                dao_disburse_bill.update()
                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "แก้ไขสัญญาเงินยืมเลขที่หนังสือ " & _
                               dao_disburse_bill.fields.DOC_NUMBER, "DEBTOR_BILL", Request.QueryString("bid"))
                dao_detail.Getdata_by_DEBTOR_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Debtor_Detail1.insert_detail(dao_detail, dao_disburse_bill.fields.DEBTOR_BILL_ID)
                dao_detail.update()
            End If
            'Response.Redirect("Frm_Disburse_Budget.aspx")
        End If
    End Sub
End Class