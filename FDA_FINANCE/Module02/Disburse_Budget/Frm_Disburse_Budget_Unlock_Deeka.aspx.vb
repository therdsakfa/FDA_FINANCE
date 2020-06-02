Public Class Frm_Disburse_Budget_Unlock_Deeka
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
        set_uc()
    End Sub
    Public Sub set_uc()
        Try
            UC_Disburse_Budget_Deeka_Unlock1.bt = 2
            UC_Disburse_Budget_Deeka_Unlock1.BudgetID = _bgid
            UC_Disburse_Budget_Deeka_Unlock1.BudgetUseID = 1
            UC_Disburse_Budget_Deeka_Unlock1.g = 0
            UC_Disburse_Budget_Deeka_Unlock1.stat = 8

            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Budget_Amount_Detail1.dept = _dept
            UC_Budget_Amount_Detail1.Budgetyear = Request.QueryString("myear")

            UC_Disburse_Budget_Deeka_Unlock1.BudgetYear = bgYear

        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
        'window.location= "index.php"
        Try
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, Request.QueryString("myear"))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        set_uc()
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Budget_Deeka_Unlock1.rgFilter(str)
    End Sub
  
    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            UC_Disburse_Budget_Deeka_Unlock1.update_true(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อนุมัติเรียบร้อยแล้ว') ;", True)
            set_uc()
            UC_Disburse_Budget_Deeka_Unlock1.rebind_grid()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
        End If

    End Sub

    Private Sub btn_no_approve_Click(sender As Object, e As EventArgs) Handles btn_no_approve.Click
        UC_Disburse_Budget_Deeka_Unlock1.update_false(11)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกอนุมัติเรียบร้อยแล้ว') ;", True)
        set_uc()
        UC_Disburse_Budget_Deeka_Unlock1.rebind_grid()
    End Sub
End Class