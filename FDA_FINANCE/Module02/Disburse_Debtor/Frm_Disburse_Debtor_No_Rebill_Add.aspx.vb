Public Class Frm_Disburse_Debtor_No_Rebill_Add
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bgyear As Integer
        If Request.QueryString("bgyear") IsNot Nothing Then
            bgyear = Request.QueryString("bgyear")
            UC_Disburse_Debtor_No_Rebill_Add1.bgyear = bgyear
            UC_Disburse_Debtor_No_Rebill_Add1.bt = 2
            UC_Disburse_Debtor_No_Rebill_Add1.g = 4
            UC_Disburse_Debtor_No_Rebill_Add1.stat = 1
        End If
    End Sub

    Protected Sub btn_bill_add_Click(sender As Object, e As EventArgs) Handles btn_bill_add.Click
        UC_Disburse_Debtor_No_Rebill_Add1.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();" & "parent.$('#dialog_insert').dialog('close'); ", True)
    End Sub
End Class