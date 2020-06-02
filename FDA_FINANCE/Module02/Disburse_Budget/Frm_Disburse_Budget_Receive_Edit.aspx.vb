Public Class Frm_Disburse_Budget_Receive_Edit
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
        'Dim bao_user As New BAO_USER.USER
        Dim dept_id As Integer = Request.QueryString("dept") 'bao_user.get_dept(NameUserAD())
        If Request.QueryString("bid") IsNot Nothing Then
            Dim dao_getgroup As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_getgroup.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
            If dao_getgroup.fields.MAIN_BILL IsNot Nothing Then
                UC_Disburse_Budget_Multi_Bill1.group_id = dao_getgroup.fields.MAIN_BILL
            End If

        End If
        UC_Disburse_Budget_Detail1.dept_id = dept_id
        If Not IsPostBack Then
            UC_Disburse_Budget_Detail1.bind_dd_gl()
            UC_Disburse_Budget_Detail1.set_date_receive()
            UC_Disburse_Budget_Detail1.bind_cus()
            Dim dao_head As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If Request.QueryString("bid") IsNot Nothing Then
                If Request.QueryString("bid") <> "sup" Or Request.QueryString("bid") <> "out" Then
                    Dim dao_getgroup As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao_getgroup.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                    Dim dao_c As New DAO_MAS.TB_MAS_CUSTOMER
                    dao_c.Getdata_by_CUSTOMER_ID(dao_getgroup.fields.CUSTOMER_ID)
                    UC_Disburse_Budget_Detail1.cal_tax_by_customer_type(dao_c.fields.CUSTOMER_TYPE_ID)
                    UC_Disburse_Budget_Detail1.cal_net()

                    If dao_getgroup.fields.MAIN_BILL IsNot Nothing Then
                        UC_Disburse_Budget_Multi_Bill1.group_id = dao_getgroup.fields.MAIN_BILL
                    End If
                    dao_head.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                    UC_Disburse_Budget_Detail1.getdata_head(dao_head)
                    dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                    UC_Disburse_Budget_Detail1.getdata_detaimulti(dao_detail)
                End If

            End If



        End If

    End Sub

    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        'Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        'Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        'Dim bao As New BAO_BUDGET.Budget
        'If Request.QueryString("bid") IsNot Nothing Then
        '    If Request.QueryString("bid") <> "sup" Then
        '        dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
        '        UC_Disburse_Budget_Receive_List_detail1.update_head(dao_disburse_bill)
        '        dao_disburse_bill.update()
        '        dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
        '        UC_Disburse_Budget_Receive_List_detail1.update_detail(dao_detail)
        '        dao_detail.update()
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        '    End If
        '    'Response.Redirect("Frm_Disburse_Budget.aspx")
        'End If

        'Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        'Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        'Dim bao As New BAO_BUDGET.Budget
        'If Request.QueryString("bid") IsNot Nothing Then
        '    If Request.QueryString("bid") <> "sup" Then
        '        dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
        '        UC_Disburse_Budget_Detail1.update_bill(dao_disburse_bill)
        '        dao_disburse_bill.update()
        '        dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
        '        UC_Disburse_Budget_Detail1.update_detail(dao_detail)
        '        dao_detail.update()
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        '    End If
        '    'Response.Redirect("Frm_Disburse_Budget.aspx")
        'End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao_dept_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_disburse_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        Dim bao As New BAO_BUDGET.Budget
        Dim dao_chk_bill As New DAO_DISBURSE.TB_BUDGET_BILL
        If Request.QueryString("bid") IsNot Nothing Then
            If Request.QueryString("bid") <> "sup" Then
                dao_chk_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                If dao_chk_bill.fields.BILL_NUMBER <> "" Then
                    'If UC_Disburse_Budget_Detail1.chk_remain = False Then
                    Dim dao_getgroup As New DAO_DISBURSE.TB_BUDGET_BILL
                    dao_getgroup.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                    If dao_getgroup.fields.MAIN_BILL IsNot Nothing Then
                        Dim bao_dis As New BAO_BUDGET.DISBURSE_BUDGET
                        Dim dis_amount As Double = 0
                        Dim main_amount As Double = 0
                        dis_amount = bao_dis.get_dis_amount_all_multi_bill(dao_getgroup.fields.MAIN_BILL)
                        main_amount = dao_getgroup.fields.MAX_PRIZE

                        If main_amount > dis_amount Then
                            dao_dept_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(dao_getgroup.fields.MAIN_BILL)
                            UC_Disburse_Budget_Detail1.insert_multi(dao_disburse_bill)
                            dao_disburse_bill.fields.MAIN_BILL = dao_getgroup.fields.MAIN_BILL
                            'dao_disburse_bill.fields.DEPARTMENT_ID = dao_dept_bill.fields.DEPARTMENT_ID
                            dao_disburse_bill.fields.IS_PO = False
                            dao_disburse_bill.fields.IS_MULTI_CHK = True
                            If Request.QueryString("flag") IsNot Nothing Then
                                If Request.QueryString("flag") = "sup" Then
                                    dao_disburse_bill.fields.PATLIST_ID = dao_dept_bill.fields.PATLIST_ID
                                End If
                            End If
                            'test
                            Try
                                dao_disburse_bill.fields.DEPARTMENT_ID = dao_getgroup.fields.DEPARTMENT_ID
                            Catch ex As Exception

                            End Try

                            Try
                                dao_disburse_bill.fields.PATLIST_ID = dao_getgroup.fields.PATLIST_ID
                            Catch ex As Exception

                            End Try
                            dao_disburse_bill.fields.IS_APPROVE = dao_chk_bill.fields.IS_APPROVE
                            dao_disburse_bill.insert()
                            'dao_detail.Getdata_by_Disburse_id(Request.QueryString("bid"))
                            UC_Disburse_Budget_Detail1.insert_detail_multi(dao_detail, dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID)
                            dao_detail.insert()

                            Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
                            Dim cus_name As String = ""
                            If dao_disburse_bill.fields.CUSTOMER_ID IsNot Nothing Then
                                dao_cus.Getdata_by_CUSTOMER_ID(dao_disburse_bill.fields.CUSTOMER_ID)
                                cus_name = dao_cus.fields.CUSTOMER_NAME
                            End If
                            Dim log As New log_event.log
                            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                                           Request.Url.AbsoluteUri.ToString(), "รับเรื่องใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER & " เจ้าหนี้ " & cus_name, "BUDGET_BILL", dao_disburse_bill.fields.BUDGET_DISBURSE_BILL_ID)
                            UC_Disburse_Budget_Multi_Bill1.rg_rebind()
                        Else
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คำเตือน จำนวนเงินไม่เพียงพอหรือคุณอาจกรอกข้อมูลไม่ถูกต้อง');", True)
                        End If


                        'Else
                        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('คำเตือน จำนวนเงินไม่เพียงพอหรือคุณอาจกรอกข้อมูลไม่ถูกต้อง');", True)
                    End If


                    'End If

                Else
                    If Request.QueryString("bid") IsNot Nothing Then
                        If Request.QueryString("bid") <> "sup" Then

                            dao_disburse_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(CInt(Request.QueryString("bid")))
                            UC_Disburse_Budget_Detail1.update_bill(dao_disburse_bill)
                            dao_disburse_bill.update()
                            dao_detail.Getdata_by_Disburse_id(CInt(Request.QueryString("bid")))
                            UC_Disburse_Budget_Detail1.update_detail_multi(dao_detail)

                            dao_detail.update()

                            Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
                            Dim cus_name As String = ""
                            If dao_disburse_bill.fields.CUSTOMER_ID IsNot Nothing Then
                                dao_cus.Getdata_by_CUSTOMER_ID(dao_disburse_bill.fields.CUSTOMER_ID)
                                cus_name = dao_cus.fields.CUSTOMER_NAME
                            End If
                            Dim log As New log_event.log
                            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                                           Request.Url.AbsoluteUri.ToString(), "รับเรื่องใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse_bill.fields.DOC_NUMBER & " เจ้าหนี้ " & cus_name, "BUDGET_BILL", Request.QueryString("bid"))
                            UC_Disburse_Budget_Multi_Bill1.rg_rebind()


                            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
                        End If
                        'Response.Redirect("Frm_Disburse_Budget.aspx")
                    End If

                End If


                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            End If

        End If
    End Sub
    Public Sub set_remain()
        If Request.QueryString("bid") IsNot Nothing Then
            Dim balance As Double = 0
            Dim max_price As Double = 0
            Dim disburse_amount As Double = 0
            Dim dao_max As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_max.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
            Dim bao As New BAO_BUDGET.DISBURSE_BUDGET

            If dao_max.fields.MAIN_BILL IsNot Nothing Then
                disburse_amount = bao.get_dis_amount_all_multi_bill(dao_max.fields.MAIN_BILL)
            End If
            If dao_max.fields.MAX_PRIZE IsNot Nothing Then
                max_price = dao_max.fields.MAX_PRIZE
            End If
            balance = max_price - disburse_amount
            lb_remain.Text = balance.ToString("N")
        End If
    End Sub

    Private Sub Frm_Disburse_Budget_Receive_Edit_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If Request.QueryString("bid") IsNot Nothing Then
            UC_Disburse_Budget_Multi_Bill1.group_id = Request.QueryString("bid")
            UC_Disburse_Budget_Multi_Bill1.bindseq()
        End If

        set_remain()
        UC_Disburse_Budget_Detail1.disable_detail()
    End Sub
End Class