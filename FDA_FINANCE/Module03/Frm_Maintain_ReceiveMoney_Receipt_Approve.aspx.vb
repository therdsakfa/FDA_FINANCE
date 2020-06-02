Public Class Frm_Maintain_ReceiveMoney_Receipt_Approve
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
        Page.Title = "อนุมัติใบเสร็จ"
        If Not IsPostBack Then
            rd_APPROVE_DATE.SelectedDate = Date.Now
        End If
    End Sub
    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Maintain_ReturnMoney_Receipt_Approve1.chk_selected_count > 0 Then
                UC_Maintain_ReturnMoney_Receipt_Approve1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID)
                UC_Maintain_ReturnMoney_Receipt_Approve1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล') ;", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If
    End Sub

    'Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
    '    Dim strMsg As String = " "
    '    strMsg = "([feeno] LIKE '%" & txt_feeno.Text & "%')"
    '    UC_Maintain_ReturnMoney_Receipt_Approve1.rgFilter(strMsg)
    'End Sub
End Class