Public Class Frm_Disburse_Budget_Receive_Edit_Bill
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

        'Dim dept_id As Integer = bao_user.get_dept(NameUserAD())
        'If Request.QueryString("bid") IsNot Nothing Then
        '    UC_Disburse_Budget_Multi_Bill1.group_id = Request.QueryString("bid")
        'End If
        UC_Disburse_Budget_Detail1.dept_id = Request.QueryString("dept")
        If Not IsPostBack Then
            UC_Disburse_Budget_Detail1.bind_dd_gl()
            UC_Disburse_Budget_Detail1.set_date_receive()
            UC_Disburse_Budget_Detail1.bind_cus()
            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If Request.QueryString("bid") IsNot Nothing Then
                If Request.QueryString("bid") <> "sup" Or Request.QueryString("bid") <> "out" Then
                    'UC_Disburse_Budget_Multi_Bill1.group_id = Request.QueryString("bid")
                    dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                    UC_Disburse_Budget_Detail1.getdata_head(dao_head)
                    dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                    UC_Disburse_Budget_Detail1.getdata_detaimulti(dao_detail)
                End If

            End If
        End If
    End Sub
    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        'Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        'Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        'Dim bao As New BAO_BUDGET.Budget
        'If Request.QueryString("bid") IsNot Nothing Then
        '    If Request.QueryString("bid") <> "sup" Then
        '        dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
        '        UC_Disburse_Budget_Receive_List_detail1.update_head(dao_disburse_bill)
        '        dao_disburse_bill.update()
        '        dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
        '        UC_Disburse_Budget_Receive_List_detail1.update_detail(dao_detail)
        '        dao_detail.update()
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        '    End If
        '    'Response.Redirect("Frm_Disburse_Budget.aspx")
        'End If

        Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Then
                dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.update_bill(dao_disburse_bill)
                dao_disburse_bill.update()
                dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                UC_Disburse_Budget_Detail1.update_detail(dao_detail)
                dao_detail.update()

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "แก้ไขการรับเรื่องใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER, "BUDGET_BILL", Request.QueryString("bid"))
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If
            'Response.Redirect("Frm_Disburse_Budget.aspx")
        End If

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click(); parent.$('#dialog_edit').dialog('close'); ", True)
    End Sub
End Class