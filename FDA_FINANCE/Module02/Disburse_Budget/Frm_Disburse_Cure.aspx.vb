Imports Telerik.Web.UI
Public Class Frm_Disburse_Cure
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
        UC_Disburse_Welfare1.BillType = 1
        UC_Disburse_Welfare1.BudgetYear = Request.QueryString("myear")

        Dim dept_id As Integer = Request.QueryString("dept")
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)
        If Not IsPostBack Then
            Dim bao_adjust As New BAO_BUDGET.Budget
            Dim dt As DataTable = bao_adjust.get_bg_adjust_by_dept_year(dept_id, Request.QueryString("myear"))
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim dao_head As New DAO_MAS.TB_BUDGET_PLAN
                    dao_head.Getdata_by_BUDGET_PLAN_ID(dr("BUDGET_CHILD_ID"))
                    If dao_head.fields.BUDGET_CODE <> "" Then
                        dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_CODE & "-" & dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                    Else
                        dr("BUDGET_DESCRIPTION") = dao_head.fields.BUDGET_DESCRIPTION & " -> " & dr("BUDGET_DESCRIPTION")
                    End If

                Next

                'dd_BudgetAdjust.DataSource = dt
                'dd_BudgetAdjust.DataBind()

            End If
        End If
        set_uc()
    End Sub

    Public Sub set_uc()
        Try
            UC_Disburse_Welfare1.bt = 2
            UC_Disburse_Welfare1.g = 8
            UC_Disburse_Welfare1.stat = 1

        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามรถใช้งานได้ เนื่องจากไม่ได้จัดสรรงบประมาณไว้ในปีที่เลือก') ; window.location='../../Frm_Main.aspx';", True)
        End Try
        'window.location= "index.php"

    End Sub
    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        'Response.Redirect("Frm_Disburse_Cure_Insert.aspx")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_From_Cure_Study1.getSearchMsg()
        UC_Disburse_Welfare1.rgFilter(str)
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Welfare1.bindseq()
    End Sub
    Public Sub del_item(ByVal id As Integer)

    End Sub

    Protected Sub btn_approve_Click(sender As Object, e As EventArgs) Handles btn_approve.Click
        If rd_APPROVE_DATE.IsEmpty = False Then
            If UC_Disburse_Welfare1.chk_selected = True Then
                If ddl_approve.SelectedValue = "1" Then
                    UC_Disburse_Welfare1.insert_approve(rd_APPROVE_DATE.SelectedDate, _CLS.CITIZEN_ID_AUTHORIZE)
                Else
                    If UC_Disburse_Welfare1.chk_selected_count <= 1 Then
                        UC_Disburse_Welfare1.open_reject_note()
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                    End If
                End If
                set_uc()
                UC_Disburse_Welfare1.rg_rebind()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่ต้องการ') ;", True)
            End If
        Else
            If ddl_approve.SelectedValue <> "2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกวันที่') ;", True)
            Else
                If UC_Disburse_Welfare1.chk_selected_count <= 1 Then
                    UC_Disburse_Welfare1.open_reject_note()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('การกรอกเหตุผลการไม่อนุมัติ สามารถทำได้เพียงครั้งละ 1 รายการ') ;", True)
                End If
            End If

        End If
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Disburse_Welfare1.rg_rebind()
    End Sub
End Class