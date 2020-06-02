Imports Telerik.Web.UI
Partial Public Class Frm_Disburse_Budget_Bill_Insert1
    Inherits System.Web.UI.Page
    Dim year_bg As Integer
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

        Dim dept_id As Integer = 0 ' bao_user.get_dept(NameUserAD())
        UC_Disburse_Budget_Detail1.is_insert = True
        If Request.QueryString("dept") IsNot Nothing Then
            UC_Disburse_Budget_Detail1.dept_id = Request.QueryString("dept")
      
        End If

        If Request.QueryString("flag") = "sup" Then
            UC_Disburse_Budget_Detail1.dept_id = 23
        End If

        If Not IsPostBack Then
            'UC_Disburse_Budget_Detail1.set_egp_hide(False)
            UC_Disburse_Budget_Detail1.bind_dd_gl()
            UC_Disburse_Budget_Detail1.set_date()
            UC_Disburse_Budget_Detail1.bind_cus()
        End If
    End Sub

    Private Sub btn_bill_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_bill_save.Click
        'Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        'Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        'Dim bao As New BAO_BUDGET.Budget
        'Dim bill_id As Integer

        'If Request.QueryString("rebill") IsNot Nothing Then
        '    If Request.QueryString("rebill") = "2" Then
        '        UC_Disburse_Budget_Detail1.insert_rebill(dao_disburse_bill)
        '    ElseIf Request.QueryString("rebill") = "3" Then
        '        UC_Disburse_Budget_Detail1.insert_rebill_out(dao_disburse_bill)
        '    End If
        'Else

        '    UC_Disburse_Budget_Detail1.insert(dao_disburse_bill)
        'End If

        'dao_disburse_bill.insert()
        'bill_id = dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID
        'UC_Disburse_Budget_Detail1.insert_detail(dao_detail, bill_id)
        'dao_detail.insert()

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        Dim bool As Boolean = UC_Disburse_Budget_Detail1.chk_document()
        If bool = False Then
            Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            Dim bao As New BAO_BUDGET.Budget
            Dim bill_id As Integer
            Dim master_id As Integer
            Dim dao_master As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL

            If Request.QueryString("rebill") IsNot Nothing Then
                If Request.QueryString("rebill") = "2" Then
                    UC_Disburse_Budget_Detail1.insert_rebill(dao_disburse_bill)
                ElseIf Request.QueryString("rebill") = "3" Then
                    UC_Disburse_Budget_Detail1.insert_rebill_out(dao_disburse_bill)
                End If
            Else
                UC_Disburse_Budget_Detail1.insert(dao_disburse_bill)
                UC_Disburse_Budget_Detail1.insert_master(dao_master)
            End If

            dao_master.fields.IS_PO = False
            dao_disburse_bill.fields.IS_PO = False
            If Request.QueryString("flag") IsNot Nothing Then
                dao_disburse_bill.fields.BUDGET_USE_ID = 2
                dao_disburse_bill.fields.DEPARTMENT_ID = 23

                dao_master.fields.BUDGET_USE_ID = 2
                dao_master.fields.DEPARTMENT_ID = 23
            Else

            End If
            dao_disburse_bill.insert()

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER, "BUDGET_BILL", dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID)
            bill_id = dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID
            UC_Disburse_Budget_Detail1.insert_detail(dao_detail, bill_id)
            dao_detail.insert()
            dao_master.fields.BUDGET_DISBURSE_BILL_ID = bill_id
            dao_master.insert()
            master_id = dao_master.fields.ID
            Dim dao_mas_main As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
            Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
            dao_bill_main.fields.MAIN_BILL = bill_id
            dao_bill_main.update()

            dao_master.Getdata_by_ID(master_id)
            dao_master.fields.MAIN_BILL = bill_id
            dao_master.update()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        Else
            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คำเตือน มีการบันทึกเลขเอกสารซ้ำ');", True)
            Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            Dim bao As New BAO_BUDGET.Budget
            Dim bill_id As Integer
            Dim master_id As Integer
            Dim dao_master As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
            If Request.QueryString("rebill") IsNot Nothing Then
                If Request.QueryString("rebill") = "2" Then
                    UC_Disburse_Budget_Detail1.insert_rebill(dao_disburse_bill)
                ElseIf Request.QueryString("rebill") = "3" Then
                    UC_Disburse_Budget_Detail1.insert_rebill_out(dao_disburse_bill)
                End If
            Else

                UC_Disburse_Budget_Detail1.insert(dao_disburse_bill)
                UC_Disburse_Budget_Detail1.insert_master(dao_master)
            End If

            dao_disburse_bill.fields.IS_PO = False
            If Request.QueryString("flag") IsNot Nothing Then
                dao_disburse_bill.fields.BUDGET_USE_ID = 2
                dao_disburse_bill.fields.DEPARTMENT_ID = 23

                dao_master.fields.BUDGET_USE_ID = 2
                dao_master.fields.DEPARTMENT_ID = 23
            End If
            dao_disburse_bill.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER, "BUDGET_BILL", dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID)
            bill_id = dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID
            dao_master.fields.BUDGET_DISBURSE_BILL_ID = bill_id
            dao_master.insert()
            UC_Disburse_Budget_Detail1.insert_detail(dao_detail, bill_id)
            dao_detail.insert()
            master_id = dao_master.fields.ID
            Dim dao_mas_main As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
            Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(bill_id)
            dao_bill_main.fields.MAIN_BILL = bill_id
            dao_bill_main.update()

            dao_master.Getdata_by_ID(master_id)
            dao_master.fields.MAIN_BILL = bill_id
            dao_master.update()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คำเตือน มีการกรอกเลขเอกสารซ้ำ แต่ท่านยังสามารถบันทึกข้อมูลเข้าสู่ระบบได้ตามปกติ'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เลขที่เอกสารนี้มีในระบบแล้ว กรุณาเปลี่ยนหมายเลขเอกสาร');", True)
    End Sub
    'Public Function getbgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue
    '    Return bgYear
    'End Function
    Public Sub getYearBudget(bg_year As Integer)
        UC_Disburse_Budget_Detail1.BudgetYear = bg_year
    End Sub

End Class