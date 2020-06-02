Public Class Frm_Main_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "หน้าหลัก"
        UC_Maintain_ReturnMoney_Status.bgyear = Master.get_Year()
        'Dim dao_user As New DAO_USER.TB_tbl_USER
        'dao_user.Getdata_by_AD_NAME(NameUserAD())
        'If dao_user.fields.PERMISSION_ID = "1" Or dao_user.fields.PERMISSION_ID = "3" Or dao_user.fields.PERMISSION_ID = "4" Then
        '    Panel1.Style.Add("Display", "block")
        '    Panel3.Style.Add("Display", "block")
        'ElseIf dao_user.fields.PERMISSION_ID = "2" Then
        '    Panel2.Style.Add("Display", "block")

        '    If dao_user.fields.DEPARTMENT_ID IsNot Nothing Or CStr(dao_user.fields.DEPARTMENT_ID) <> "" Then
        '        dept_information(dao_user.fields.DEPARTMENT_ID)
        '    End If

        'End If
        'Dim byear As Integer = Master.get_Year()

        'If Not IsPostBack Then
        '    set_style_grid()
        '    Dim dao_count_bill As New DAO_DISBURSE.TB_BUDGET_BILL()
        '    Dim dao_bill_app As New DAO_DISBURSE.TB_BUDGET_BILL()
        '    Dim dao_bill_no_app As New DAO_DISBURSE.TB_BUDGET_BILL()
        '    Dim dao_k As New DAO_DISBURSE.TB_BUDGET_BILL()

        '    Dim dao_count_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL()
        '    Dim dao_debtor_app As New DAO_DISBURSE.TB_DEBTOR_BILL()
        '    Dim dao_debtor_no_app As New DAO_DISBURSE.TB_DEBTOR_BILL()
        '    Dim dao_debtor_k As New DAO_DISBURSE.TB_DEBTOR_BILL()
        '    'Dim dao_deadline As New DAO_DISBURSE.TB_DEBTOR_BILL()
        '    Dim bao_deadline As New BAO_BUDGET.DISBURSE_BUDGET
        '    Dim bao_margin_deadline As New BAO_BUDGET.DISBURSE_BUDGET()
        '    Dim bao_debtor_no_app As New BAO_BUDGET.DISBURSE_BUDGET()
        '    Dim bao_debtor_app As New BAO_BUDGET.DISBURSE_BUDGET()
        '    Dim bao_debtor_all As New BAO_BUDGET.DISBURSE_BUDGET()
        '    Dim bao_bill_all_count As New BAO_BUDGET.DISBURSE_BUDGET()
        '    Dim bao_bill_app As New BAO_BUDGET.DISBURSE_BUDGET()
        '    Dim bao_bill_no_app As New BAO_BUDGET.DISBURSE_BUDGET

        '    Dim bill_count As Integer = bao_bill_all_count.get_bill_all_count_mainpage(byear)
        '    Dim bill_app As Integer = bao_bill_app.get_bill_app_count_mainpage(byear)
        '    Dim bill_no_app As Integer = bao_bill_no_app.get_bill_no_app_count_mainpage(byear)
        '    Dim bill_k As Integer = dao_k.get_bill_K(byear)

        '    Dim debtor_count As Integer = bao_debtor_all.get_debtor_all_count(byear)
        '    Dim debtor_app As Integer = bao_debtor_app.get_debtor_app_count(byear)
        '    'Dim debtor_no_app As Integer = dao_debtor_no_app.get_bill_No_app(byear)
        '    Dim debtor_no_app As Integer = bao_debtor_no_app.get_debtor_No_app_count(byear)
        '    Dim debtor_k As Integer = dao_debtor_k.get_bill_K(byear)
        '    Dim debtor_deadline As Integer = bao_deadline.get_debt_deadline(byear)
        '    Dim debtor_margin_deadline As Integer = bao_margin_deadline.get_debt_deadline_margin(byear)

        '    h_dis_bg.Text = bill_count
        '    h_dis_app_bg.Text = bill_app
        '    h_dis_no_app_bg.Text = bill_no_app
        '    h_add_k.Text = bill_k

        '    'h_dis_bg
        '    h_debtor.Text = debtor_count
        '    h_app_debtor.Text = debtor_app
        '    h_no_app_debtor.Text = debtor_no_app
        '    h_add_k_debtor.Text = debtor_k
        '    h_debtor_deadline.Text = debtor_deadline + debtor_margin_deadline
        '    h_no_app_debtor.NavigateUrl = "~/Module09/Frm_MainPage_Debtor_No_App_List.aspx?bgyear=" & Master.get_Year()
        '    h_add_k_debtor.NavigateUrl = "~/Frm_MainPage_Debtor_Add_K_List.aspx?bgyear=" & Master.get_Year()
        '    h_app_debtor.NavigateUrl = "~/Module09/Frm_MainPage_Debtor_App_List.aspx?bgyear=" & Master.get_Year()
        '    h_debtor.NavigateUrl = "~/Module09/Frm_MainPage_Debtor_All_List.aspx?bgyear=" & Master.get_Year()
        '    h_dis_bg.NavigateUrl = "~/Module09/Frm_MainPage_Bill_All_List.aspx?bgyear=" & Master.get_Year()
        '    h_dis_app_bg.NavigateUrl = "~/Module09/Frm_MainPage_Bill_App_List.aspx?bgyear=" & Master.get_Year()
        '    h_dis_no_app_bg.NavigateUrl = "~/Module09/Frm_MainPage_Bill_No_App_List.aspx?bgyear=" & Master.get_Year()

        'End If
    End Sub

    Public Sub dept_information(dept As Integer)
        Dim byear As Integer = Master.get_Year()
        Dim dao_count_bill As New DAO_DISBURSE.TB_BUDGET_BILL()
        Dim dao_bill_app As New DAO_DISBURSE.TB_BUDGET_BILL()
        Dim dao_bill_no_app As New DAO_DISBURSE.TB_BUDGET_BILL()
        Dim dao_k As New DAO_DISBURSE.TB_BUDGET_BILL()

        Dim dao_count_debtor As New DAO_DISBURSE.TB_DEBTOR_BILL()
        Dim dao_debtor_app As New DAO_DISBURSE.TB_DEBTOR_BILL()
        Dim dao_debtor_no_app As New DAO_DISBURSE.TB_DEBTOR_BILL()
        Dim dao_debtor_k As New DAO_DISBURSE.TB_DEBTOR_BILL()
        Dim dao_deadline As New DAO_DISBURSE.TB_DEBTOR_BILL()
        Dim dao_margin_deadline As New DAO_DISBURSE.TB_DEBTOR_BILL()

        Dim bill_count As Integer = dao_count_bill.get_bill_count_by_dept(dept, byear)
        Dim bill_app As Integer = dao_bill_app.get_bill_app_by_dept(dept, byear)
        Dim bill_no_app As Integer '= dao_bill_no_app.get_bill_No_app_by_dept(dept)
        Dim bill_k As Integer = dao_k.get_bill_K_by_dept(dept, byear)

        Dim debtor_count As Integer = dao_count_debtor.get_bill_count_by_dept(dept, byear)
        Dim debtor_app As Integer = dao_debtor_app.get_bill_app_by_dept(dept, byear)
        Dim debtor_no_app As Integer = dao_debtor_no_app.get_bill_No_app_by_dept(dept, byear)
        Dim debtor_k As Integer = dao_debtor_k.get_bill_K_by_dept(dept, byear)
        Dim debtor_deadline As Integer = dao_deadline.get_debt_deadline_by_dept(dept, byear)
        Dim debtor_margin_deadline As Integer = dao_margin_deadline.get_debt_margin_deadline_by_dept(dept, byear)


        hl_dept_bill_request.Text = bill_count
        hl_dept_approve.Text = bill_app
        hl_dept_no_approve.Text = bill_count - bill_app
        hl_dept_K_add.Text = bill_k

        hl_dept_debtor.Text = debtor_count
        hl_approve_debtor.Text = debtor_app
        hl_no_approve_debtor.Text = debtor_no_app
        ' h_add_k_debtor.Text = debtor_k
        hl_deadline_dept.Text = debtor_deadline + debtor_margin_deadline
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        search_bill()
    End Sub

    Public Sub search_bill()
        Dim str_search As String = ""
        str_search = txt_search.Text
        set_style_grid()
        If rdl_bill_type.SelectedValue = "2" Then
            UC_Debtor_Status1.bgyear = Master.get_Year()
            If rd_search_type.SelectedValue = "1" Then
                If str_search <> "" Then
                    UC_Debtor_Status1.bill_number = str_search
                    UC_Debtor_Status1.search_type = 1
                End If

            ElseIf rd_search_type.SelectedValue = "2" Then
                If str_search <> "" Then
                    UC_Debtor_Status1.doc_number = str_search
                    UC_Debtor_Status1.search_type = 2
                End If
            ElseIf rd_search_type.SelectedValue = "3" Then
                If str_search <> "" Then
                    UC_Debtor_Status1.cus_name = str_search
                    UC_Debtor_Status1.search_type = 3
                End If
            ElseIf rd_search_type.SelectedValue = "4" Then
                If str_search <> "" Then
                    UC_Debtor_Status1.cus_name = str_search
                    UC_Debtor_Status1.search_type = 4
                    UC_Debtor_Status1.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "5" Then
                If str_search <> "" Then
                    UC_Debtor_Status1.K_nymber = str_search
                    UC_Debtor_Status1.search_type = 5
                    UC_Debtor_Status1.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "6" Then
                If str_search <> "" Then
                    UC_Debtor_Status1.K_nymber = str_search
                    UC_Debtor_Status1.search_type = 6
                    UC_Debtor_Status1.equal_t = dd_equal.SelectedValue
                End If
            End If
            UC_Debtor_Status1.rg_rebind()

        ElseIf rdl_bill_type.SelectedValue = "1" Then
            UC_Disburse_Bill_Status1.bgyear = Master.get_Year()
            If rd_search_type.SelectedValue = "1" Then
                If str_search <> "" Then
                    UC_Disburse_Bill_Status1.bill_number = str_search
                    UC_Disburse_Bill_Status1.search_type = 1
                End If
            ElseIf rd_search_type.SelectedValue = "2" Then
                If str_search <> "" Then
                    UC_Disburse_Bill_Status1.doc_number = str_search
                    UC_Disburse_Bill_Status1.search_type = 2
                End If
            ElseIf rd_search_type.SelectedValue = "3" Then
                If str_search <> "" Then
                    UC_Disburse_Bill_Status1.cus_name = str_search
                    UC_Disburse_Bill_Status1.search_type = 3
                End If
            ElseIf rd_search_type.SelectedValue = "4" Then
                If str_search <> "" Then
                    UC_Disburse_Bill_Status1.cus_name = str_search
                    UC_Disburse_Bill_Status1.search_type = 4
                    UC_Disburse_Bill_Status1.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "5" Then
                If str_search <> "" Then
                    UC_Disburse_Bill_Status1.K_nymber = str_search
                    UC_Disburse_Bill_Status1.search_type = 5
                    UC_Disburse_Bill_Status1.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "6" Then
                If str_search <> "" Then
                    UC_Disburse_Bill_Status1.K_nymber = str_search
                    UC_Disburse_Bill_Status1.search_type = 6
                    UC_Disburse_Bill_Status1.equal_t = dd_equal.SelectedValue
                End If
            End If
            UC_Disburse_Bill_Status1.rg_rebind()
        ElseIf rdl_bill_type.SelectedValue = "3" Then
            UC_Disburse_PO_Bill_Status1.bgyear = Master.get_Year()
            If rd_search_type.SelectedValue = "1" Then
                If str_search <> "" Then
                    UC_Disburse_PO_Bill_Status1.bill_number = str_search
                    UC_Disburse_PO_Bill_Status1.search_type = 1
                End If
            ElseIf rd_search_type.SelectedValue = "2" Then
                If str_search <> "" Then
                    UC_Disburse_PO_Bill_Status1.doc_number = str_search
                    UC_Disburse_PO_Bill_Status1.search_type = 2
                End If
            ElseIf rd_search_type.SelectedValue = "3" Then
                If str_search <> "" Then
                    UC_Disburse_PO_Bill_Status1.cus_name = str_search
                    UC_Disburse_PO_Bill_Status1.search_type = 3
                End If
            ElseIf rd_search_type.SelectedValue = "4" Then
                If str_search <> "" Then
                    UC_Disburse_PO_Bill_Status1.cus_name = str_search
                    UC_Disburse_PO_Bill_Status1.search_type = 4
                    UC_Disburse_PO_Bill_Status1.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "5" Then
                If str_search <> "" Then
                    UC_Disburse_PO_Bill_Status1.K_nymber = str_search
                    UC_Disburse_PO_Bill_Status1.search_type = 5
                    UC_Disburse_PO_Bill_Status1.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "6" Then
                If str_search <> "" Then
                    UC_Disburse_PO_Bill_Status1.K_nymber = str_search
                    UC_Disburse_PO_Bill_Status1.search_type = 6
                    UC_Disburse_PO_Bill_Status1.equal_t = dd_equal.SelectedValue
                End If
            End If
            UC_Disburse_PO_Bill_Status1.rg_rebind()
        ElseIf rdl_bill_type.SelectedValue = "4" Then
            UC_Maintain_ReturnMoney_Status.bgyear = Master.get_Year()
            If rd_search_type.SelectedValue = "1" Then
                If str_search <> "" Then
                    UC_Maintain_ReturnMoney_Status.bill_number = str_search
                    UC_Maintain_ReturnMoney_Status.search_type = 1
                End If
            ElseIf rd_search_type.SelectedValue = "2" Then
                If str_search <> "" Then
                    UC_Maintain_ReturnMoney_Status.doc_number = str_search
                    UC_Maintain_ReturnMoney_Status.search_type = 2
                End If
            ElseIf rd_search_type.SelectedValue = "3" Then
                If str_search <> "" Then
                    UC_Maintain_ReturnMoney_Status.cus_name = str_search
                    UC_Maintain_ReturnMoney_Status.search_type = 3
                End If
            ElseIf rd_search_type.SelectedValue = "4" Then
                If str_search <> "" Then
                    UC_Maintain_ReturnMoney_Status.cus_name = str_search
                    UC_Maintain_ReturnMoney_Status.search_type = 4
                    UC_Maintain_ReturnMoney_Status.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "5" Then
                If str_search <> "" Then
                    UC_Maintain_ReturnMoney_Status.cus_name = str_search
                    UC_Maintain_ReturnMoney_Status.search_type = 5
                    UC_Maintain_ReturnMoney_Status.equal_t = dd_equal.SelectedValue
                End If
            ElseIf rd_search_type.SelectedValue = "6" Then
                If str_search <> "" Then
                    UC_Maintain_ReturnMoney_Status.cus_name = str_search
                    UC_Maintain_ReturnMoney_Status.search_type = 6
                    UC_Maintain_ReturnMoney_Status.equal_t = dd_equal.SelectedValue
                End If
            End If
            UC_Maintain_ReturnMoney_Status.rg_rebind()
        End If
    End Sub
    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        search_bill()
        UC_Debtor_Status1.rg_rebind()
        UC_Disburse_Bill_Status1.rg_rebind()
    End Sub

    Private Sub rdl_bill_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_bill_type.SelectedIndexChanged
        'set_style_grid()
    End Sub
    Public Sub set_style_grid()
        If rdl_bill_type.SelectedValue = "2" Then
            pn_debtor.Style.Add("Display", "block")
            pn_bill.Style.Add("Display", "none")
            pn_PO.Style.Add("Display", "none")
            pn_return.Style.Add("Display", "none")
        ElseIf rdl_bill_type.SelectedValue = "1" Then
            pn_debtor.Style.Add("Display", "none")
            pn_bill.Style.Add("Display", "block")
            pn_PO.Style.Add("Display", "none")
            pn_return.Style.Add("Display", "none")
        ElseIf rdl_bill_type.SelectedValue = "3" Then
            pn_debtor.Style.Add("Display", "none")
            pn_bill.Style.Add("Display", "none")
            pn_PO.Style.Add("Display", "block")
            pn_return.Style.Add("Display", "none")
        ElseIf rdl_bill_type.SelectedValue = "4" Then
            pn_debtor.Style.Add("Display", "none")
            pn_bill.Style.Add("Display", "none")
            pn_PO.Style.Add("Display", "none")
            pn_return.Style.Add("Display", "block")
        Else
            pn_debtor.Style.Add("Display", "none")
            pn_bill.Style.Add("Display", "none")
            pn_PO.Style.Add("Display", "none")
            pn_return.Style.Add("Display", "none")
        End If
    End Sub

    Private Sub rd_search_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rd_search_type.SelectedIndexChanged
        If rd_search_type.SelectedValue = "4" Then
            dd_equal.Style.Add("display", "block")
        Else
            dd_equal.Style.Add("display", "none")
        End If
    End Sub
End Class