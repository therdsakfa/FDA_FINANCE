Public Partial Class Frm_BudgetPlan_Insert
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
        Dim bgyear As Integer = Request.QueryString("bgyear")
        UC_Budgetplan_Detail1.bgyear = bgyear
        UC_Budgetplan_Detail_Sub_BG1.bgyear = bgyear
        UC_Budgetplan_Detail_Type71.bgyear = bgyear
        UC_BudgetPlan_Detail_Type51.bgid = Request.QueryString("id")
        If Request.QueryString("typeid") = "8" Then
            UC_Budgetplan_Detail1.Visible = False
            UC_Budgetplan_Detail_Sub_BG1.Visible = True
            UC_Budgetplan_Detail_Type71.Visible = False
            UC_BudgetPlan_Detail_Type51.Visible = False
        ElseIf Request.QueryString("typeid") = "7" Then
            UC_Budgetplan_Detail1.Visible = False
            UC_Budgetplan_Detail_Sub_BG1.Visible = False
            UC_Budgetplan_Detail_Type71.Visible = True
            UC_BudgetPlan_Detail_Type51.Visible = True
            btnFinish.Style.Add("display", "block")
        ElseIf Request.QueryString("typeid") = "5" Then
            UC_Budgetplan_Detail1.Visible = True
            UC_Budgetplan_Detail_Sub_BG1.Visible = False
            UC_Budgetplan_Detail_Type71.Visible = False
            UC_BudgetPlan_Detail_Type51.Visible = True
            btnFinish.Style.Add("display", "block")
        Else
            UC_Budgetplan_Detail1.Visible = True
            UC_Budgetplan_Detail_Sub_BG1.Visible = False
            UC_Budgetplan_Detail_Type71.Visible = False
            UC_BudgetPlan_Detail_Type51.Visible = False
        End If


    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim dao As New DAO_MAS.TB_BUDGET_PLAN
        If Request.QueryString("typeid") = "1" Then
            Dim bao_max As New BAO_BUDGET.MASS
            Dim id_max As Integer = 0
            Try
                id_max = bao_max.get_max_id_budget_plan()
            Catch ex As Exception

            End Try
            dao.fields.BUDGET_PLAN_ID = id_max + 1
            Dim id As Integer = Request.QueryString("id")
            UC_Budgetplan_Detail1.insert_headBG(dao)
            dao.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขางบ " & dao.fields.BUDGET_DESCRIPTION, "BUDGET_PLAN", dao.fields.BUDGET_PLAN_ID)

            Dim idinsert As Integer = dao.fields.BUDGET_PLAN_ID

            Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            Try
                dao2.fields.BUDGET_YEAR = Request.QueryString("bgyear")
            Catch ex As Exception

            End Try

            dao2.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        ElseIf Request.QueryString("typeid") = "8" Then
            Dim id As Integer = Request.QueryString("id")
            
            UC_Budgetplan_Detail_Sub_BG1.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขางบย่อย", "BUDGET_PLAN", 0)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        ElseIf Request.QueryString("typeid") = "7" Then
            Dim id As Integer = Request.QueryString("id")
            Dim bao_max As New BAO_BUDGET.MASS
            Dim id_max As Integer = 0
            Try
                id_max = bao_max.get_max_id_budget_plan()
            Catch ex As Exception

            End Try
            dao.fields.BUDGET_PLAN_ID = id_max + 1
            UC_Budgetplan_Detail_Type71.insert(dao)
            dao.insert()

            Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = dao.fields.BUDGET_PLAN_ID
            dao2.insert()
            UC_BudgetPlan_Detail_Type51.rg_rebind()
            'Dim log As New log_event.log
            'log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขางบ 7", "BUDGET_PLAN", 0)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        ElseIf Request.QueryString("typeid") = "5" Then
            Dim bao_max As New BAO_BUDGET.MASS
            Dim id_max As Integer = 0
            Try
                id_max = bao_max.get_max_id_budget_plan()
            Catch ex As Exception

            End Try
            dao.fields.BUDGET_PLAN_ID = id_max + 1
            Dim id As Integer = Request.QueryString("id")
            UC_Budgetplan_Detail1.insert(dao)
            dao.insert()
            'Dim log As New log_event.log
            'log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขางบ " & dao.fields.BUDGET_DESCRIPTION, "BUDGET_PLAN", dao.fields.BUDGET_PLAN_ID)
            Dim idinsert As Integer = dao.fields.BUDGET_PLAN_ID

            Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            Try
                dao2.fields.BUDGET_YEAR = Request.QueryString("bgyear")
            Catch ex As Exception

            End Try
            dao2.insert()
            UC_BudgetPlan_Detail_Type51.rg_rebind()
        ElseIf Request.QueryString("typeid") = "6" Then
            Dim id As Integer = Request.QueryString("id")
            Dim bao_max As New BAO_BUDGET.MASS
            Dim id_max As Integer = 0
            Try
                id_max = bao_max.get_max_id_budget_plan()
            Catch ex As Exception

            End Try
            dao.fields.BUDGET_PLAN_ID = id_max + 1
            UC_Budgetplan_Detail1.insert(dao)
            dao.insert()
            Dim idinsert As Integer = dao.fields.BUDGET_PLAN_ID

            Dim daod As New DAO_MAS.TB_BUDGET_PLAN_NODE
            daod.fields.HEAD_ID = id
            daod.fields.CHILD_ID = idinsert
            Try
                daod.fields.BUDGET_YEAR = Request.QueryString("bgyear")
            Catch ex As Exception

            End Try
            daod.insert()


            UC_Budgetplan_Detail1.get_ddl_select()
            Dim dao_t As New DAO_MAS.TB_TEMP_BG
            dao_t.Getdata_by_type(UC_Budgetplan_Detail1.ddl, 0)

            For Each dao_t.fields In dao_t.datas
                Dim bao_max2 As New BAO_BUDGET.MASS
                Dim id_max2 As Integer = 0
                Try
                    id_max2 = bao_max2.get_max_id_budget_plan()
                Catch ex As Exception

                End Try


                Dim dao_b As New DAO_MAS.TB_BUDGET_PLAN
                dao_b.fields.BUDGET_CHILD_ID = idinsert
                dao_b.fields.BUDGET_AMOUNT = 0
                dao_b.fields.BUDGET_DESCRIPTION = dao_t.fields.DES
                dao_b.fields.BUDGET_TYPE_ID = dao_t.fields.Type_ID
                dao_b.fields.BUDGET_YEAR = Request.QueryString("bgyear")
                dao_b.fields.BUDGET_IS_SUPPORT_DEPT = False
                dao_b.fields.BUDGET_PLAN_ID = id_max2 + 1
                dao_b.insert()


                Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
                dao2.fields.HEAD_ID = dao_b.fields.BUDGET_CHILD_ID
                dao2.fields.CHILD_ID = dao_b.fields.BUDGET_PLAN_ID
                Try
                    dao2.fields.BUDGET_YEAR = Request.QueryString("bgyear")
                Catch ex As Exception

                End Try
                dao2.insert()

                bindnode(UC_Budgetplan_Detail1.ddl, dao_t.fields.BG_ID, dao_b.fields.BUDGET_PLAN_ID)
            Next

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        Else
            Dim id As Integer = Request.QueryString("id")
            UC_Budgetplan_Detail1.insert(dao)
            Dim bao_max As New BAO_BUDGET.MASS
            Dim id_max As Integer = 0
            Try
                id_max = bao_max.get_max_id_budget_plan()
            Catch ex As Exception

            End Try
            dao.fields.BUDGET_PLAN_ID = id_max + 1
            dao.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขางบ " & dao.fields.BUDGET_DESCRIPTION, "BUDGET_PLAN", dao.fields.BUDGET_PLAN_ID)
            Dim idinsert As Integer = dao.fields.BUDGET_PLAN_ID

            Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
            dao2.fields.HEAD_ID = id
            dao2.fields.CHILD_ID = idinsert
            Try
                dao2.fields.BUDGET_YEAR = Request.QueryString("bgyear")
            Catch ex As Exception

            End Try
            dao2.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If



        'Response.Redirect("Frm_BudgetPlan.aspx")
    End Sub
    Public Sub bindnode(ByVal type As Integer, Optional ByVal ParentID As Integer = 0, Optional ByVal head As Integer = 0)
        Dim dao_t As New DAO_MAS.TB_TEMP_BG
        dao_t.Getdata_by_type(type, ParentID)
        For Each dao_t.fields In dao_t.datas
            Dim dao_b As New DAO_MAS.TB_BUDGET_PLAN
            Dim bao_max2 As New BAO_BUDGET.MASS
            Dim id_max2 As Integer = 0
            Try
                id_max2 = bao_max2.get_max_id_budget_plan()
            Catch ex As Exception

            End Try
            dao_b.fields.BUDGET_CHILD_ID = head
            dao_b.fields.BUDGET_AMOUNT = 0
            dao_b.fields.BUDGET_MAIN_TYPE = 0
            dao_b.fields.BUDGET_DESCRIPTION = dao_t.fields.DES
            dao_b.fields.BUDGET_TYPE_ID = dao_t.fields.Type_ID
            dao_b.fields.BUDGET_YEAR = Request.QueryString("bgyear")
            dao_b.fields.BUDGET_IS_SUPPORT_DEPT = False
            dao_b.fields.BUDGET_PLAN_ID = id_max2 + 1
            dao_b.insert()

            'Dim dao_up As New DAO_MAS.TB_BUDGET_PLAN
            'dao_up.Getdata_by_BUDGET_PLAN_ID(dao_b.fields.BUDGET_PLAN_ID)

            Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE
            dao2.fields.HEAD_ID = dao_b.fields.BUDGET_CHILD_ID
            dao2.fields.CHILD_ID = dao_b.fields.BUDGET_PLAN_ID
            Try
                dao2.fields.BUDGET_YEAR = Request.QueryString("bgyear")
            Catch ex As Exception

            End Try
            dao2.insert()
        Next
    End Sub
    'Public Function getbgYear() As Integer
    '    Dim bgYear As Integer = 0
    '    Dim dd_BudgetYear As DropDownList
    '    dd_BudgetYear = CType(Master.FindControl("dd_BudgetYear"), DropDownList)
    '    bgYear = dd_BudgetYear.SelectedValue
    '    Return bgYear
    'End Function
   
    Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class