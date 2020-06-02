Public Class Frm_Disburse_Cure_Receive_List
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
        UC_Disburse_Cure_Study_Receive_List1.BudgetYear = Request.QueryString("myear")
        UC_Disburse_Cure_Study_Receive_List1.BillType = 1
        UC_Disburse_Cure_Study_Receive_List1.stat = 5
        UC_Disburse_Cure_Study_Receive_List1.bt = 2
        UC_Disburse_Cure_Study_Receive_List1.g = 8
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
    End Sub

    Private Sub Frm_Disburse_Cure_Receive_List_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim str As String = ""
            str = UC_Search_Form_Receive_List1.getSearchMsg()
            UC_Disburse_Cure_Study_Receive_List1.rgFilter(str)
        End If
        'UC_Disburse_Cure_Study_Receive_List1.set_color_rg()
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Cure_Study_Receive_List1.rebind_grid()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String = ""
        str = UC_Search_Form_Receive_List1.getSearchMsg()
        UC_Disburse_Cure_Study_Receive_List1.rgFilter(str)
    End Sub
    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Cure_Study_Receive_List1.chk_selected = True Then
                'UC_RELATE_BILL_WITH_HEAD_APPROVE1.update_true(rd_APPROVE_DATE.SelectedDate)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)

                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Cure_Study_Receive_List1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ตรวจสอบผ่านเรียบร้อยแล้ว') ;", True)
                Else
                    If UC_Disburse_Cure_Study_Receive_List1.chk_selected_count <= 1 Then
                        UC_Disburse_Cure_Study_Receive_List1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผล สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                UC_Disburse_Cure_Study_Receive_List1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Cure_Study_Receive_List1.chk_selected_count <= 1 Then
                    UC_Disburse_Cure_Study_Receive_List1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผล สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub
End Class