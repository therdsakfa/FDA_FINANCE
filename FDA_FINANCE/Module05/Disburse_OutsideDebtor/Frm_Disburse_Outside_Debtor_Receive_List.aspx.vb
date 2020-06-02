Public Class Frm_Disburse_Outside_Debtor_Receive_List
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        Page.Title = "ตรวจสอบลูกหนี้"
        UC_Disburse_Debtor_Receive_List1.bgyear = bgYear
        UC_Disburse_Debtor_Receive_List1.bguse = 3
        UC_Disburse_Debtor_Receive_List1.g = 0
        UC_Disburse_Debtor_Receive_List1.bt = 3
        UC_Disburse_Debtor_Receive_List1.stat = 5
        UC_Disburse_Debtor_Receive_List1.stat2 = 3
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_Receive_List1.rebind_grid()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim str As String = ""
        str = UC_Receive_List_Filter1.getSearchMsg()
        UC_Disburse_Debtor_Receive_List1.rgFilter(str)
    End Sub

    Private Sub Frm_Disburse_Outside_Debtor_Receive_List_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor_Receive_List1.bindseq()
        If Not IsPostBack Then
            Dim str As String = ""
            str = UC_Receive_List_Filter1.getSearchMsg()
            UC_Disburse_Debtor_Receive_List1.rgFilter(str)
        End If
        UC_Disburse_Debtor_Receive_List1.set_color_rg()
    End Sub

    Private Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Debtor_Receive_List1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Debtor_Receive_List1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ตรวจสอบผ่านเรียบร้อยแล้ว') ;", True)
                Else
                    If UC_Disburse_Debtor_Receive_List1.chk_selected_count <= 1 Then
                        UC_Disburse_Debtor_Receive_List1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผล สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                UC_Disburse_Debtor_Receive_List1.rebind_grid()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Debtor_Receive_List1.chk_selected_count <= 1 Then
                    UC_Disburse_Debtor_Receive_List1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผล สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub
End Class