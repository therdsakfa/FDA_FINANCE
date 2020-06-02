Public Class Frm_Disburse_Debtor_No_Rebill
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
        'Try
        '    _dept = Request.QueryString("dept")
        'Catch ex As Exception
        '    _dept = 0
        'End Try
        'Try
        '    _bgid = Request.QueryString("bgid")
        'Catch ex As Exception
        '    _bgid = 0
        'End Try

        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        set_uc()
    End Sub
   
    
    Public Sub set_uc()
        Try
            UC_Disburse_Debtor_No_Rebill1.BudgetUseID = 1
            UC_Disburse_Debtor_No_Rebill1.BudgetYear = bgYear
            UC_Disburse_Debtor_No_Rebill1.bt = 2
            UC_Disburse_Debtor_No_Rebill1.g = 4
            UC_Disburse_Debtor_No_Rebill1.stat = 2
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String = ""
        str = UC_Search_Form1.getSearchMsg()
        'UC_Search_Form_Approve1.getSearchMsg()
        UC_Disburse_Debtor_No_Rebill1.rgFilter(str)
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Debtor_No_Rebill1.rg_rebind()
    End Sub
    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Debtor_No_Rebill1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Debtor_No_Rebill1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                Else
                    If UC_Disburse_Debtor_No_Rebill1.chk_selected_count <= 1 Then
                        UC_Disburse_Debtor_No_Rebill1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                set_uc()
                UC_Disburse_Debtor_No_Rebill1.rg_rebind()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Debtor_No_Rebill1.chk_selected_count <= 1 Then
                    UC_Disburse_Debtor_No_Rebill1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub
End Class