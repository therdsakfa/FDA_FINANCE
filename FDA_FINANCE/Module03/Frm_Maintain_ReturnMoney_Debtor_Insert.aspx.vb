Public Class Frm_Maintain_ReturnMoney_Debtor_Insert
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
        Dim type_id As Integer = 0
        If rdl_Paytype_main.SelectedValue <> "" Then
            type_id = rdl_Paytype_main.SelectedValue
        End If
        Try
            UC_Maintain_ReturnMoney_Detail1.bgyear = Request.QueryString("myear")
        Catch ex As Exception

        End Try


        If Not IsPostBack Then
            UC_Maintain_ReturnMoney_Detail1.set_date()
            UC_Maintain_ReturnMoney_Detail1.bind_r_type()
            UC_Maintain_ReturnMoney_Detail1.set_textbox()
            Dim bao As New BAO_BUDGET.Maintain
            Dim dt As DataTable = bao.get_DEBTOR_BILL_in_BUDGET_by_DEBTOR_BILL_ID(Request.QueryString("DEBTOR_BILL_ID"))
            UC_Maintain_ReturnMoney_Debtor_Information1.getdata(dt)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt(0)("MONEYTYPE")) = False Then
                    If dt(0)("MONEYTYPE") = "เงินงบประมาณ" Then
                        rdl_Paytype_main.SelectedValue = 1
                    ElseIf dt(0)("MONEYTYPE") = "เงินทดรอง" Then
                        rdl_Paytype_main.SelectedValue = 2
                    Else
                        rdl_Paytype_main.SelectedValue = 3
                    End If
                End If
            End If

        End If
        'btn_Add.Attributes.Add("onclick", "insert_k('Frm_Maintain_ReturnMoney_Debtor_Insert_Detail.aspx?DEBTOR_BILL_ID=" & Request.QueryString("DEBTOR_BILL_ID") & "&maintype=" & type_id & " &bgyear=" & Master.get_Year() & "'); return false;")
    End Sub

    'Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
    '    Dim dao_maintain_return_money_deptor As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
    '    UC_Maintain_ReturnMoney_Detail.insert(dao_maintain_return_money_deptor)
    '    dao_maintain_return_money_deptor.fields.PAY_TYPE = rdl_Paytype_main.SelectedValue

    '    dao_maintain_return_money_deptor.insert()
    '    ' Response.Redirect("Frm_Maintain_ReturnMoney_Debtor.aspx")
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    'End Sub

    'Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
    '    'Response.Redirect("Frm_Maintain_ReturnMoney_Debtor.aspx")
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    'End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        UC_Maintain_ReturnMoney_Debtor_Show_Grid1.rg_rebind()
    End Sub

    Protected Sub btn_previous_Click(sender As Object, e As EventArgs) Handles btn_previous.Click
        Response.Redirect("Frm_Maintain_ReturnMoney_Debtor.aspx")
    End Sub


    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Maintain_ReturnMoney_Debtor_Show_Grid1.bindseq()
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        ' Dim maintype As Integer = Request.QueryString("maintype")
        Dim dao_maintain_return_money_deptor As New DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR
        Dim id As Integer = 0
        If Request.QueryString("flag") <> "" Then
            UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
            'dao_maintain_return_money_deptor.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID = Request.QueryString("DEBTOR_BILL_ID")
            dao_maintain_return_money_deptor.fields.HEAD_ID = Request.QueryString("id")
            dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
            dao_maintain_return_money_deptor.insert()
            UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
            Response.Redirect(Request.Url.AbsoluteUri)
        Else
            Dim is_return_over As Boolean = False
            is_return_over = UC_Maintain_ReturnMoney_Detail1.chk_money_over(Request.QueryString("DEBTOR_BILL_ID"))
            Dim re_type As Integer = UC_Maintain_ReturnMoney_Detail1.get_return_type()
            'If is_return_over = True Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('จำนวนเงินไม่ถูกต้อง');", True)

            'Else
            If UC_Maintain_ReturnMoney_Detail1.Check_overlap() = False Then
                If UC_Maintain_ReturnMoney_Detail1.Check_ddl_MAS_RETURN_TYPE() = False Then

                    If is_return_over = True Then
                        If re_type = 1 Or re_type = 2 Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('จำนวนเงินไม่ถูกต้อง');", True)

                        Else
                            UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
                            dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
                            dao_maintain_return_money_deptor.insert()
                            id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID

                            UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
                            Response.Redirect(Request.Url.AbsoluteUri)

                        End If
                    Else
                        UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
                        dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
                        dao_maintain_return_money_deptor.insert()
                        id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID

                        UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
                        Response.Redirect(Request.Url.AbsoluteUri)

                    End If

                Else

                    If UC_Maintain_ReturnMoney_Detail1.Check_rdl_sub_pay_type = True Then
                        UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
                        dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
                        dao_maintain_return_money_deptor.insert()
                        id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID

                        UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
                        Response.Redirect(Request.Url.AbsoluteUri)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภทเงินเบิกเพิ่ม');", True)
                    End If

                End If


            Else
                If UC_Maintain_ReturnMoney_Detail1.Check_txt_reason = False Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเหตุผลการคืนเงินสดเกิน 25%');", True)
                Else
                    If UC_Maintain_ReturnMoney_Detail1.Check_ddl_MAS_RETURN_TYPE() = False Then
                        If is_return_over = True Then
                            If re_type = 1 Or re_type = 2 Then
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('จำนวนเงินไม่ถูกต้อง');", True)

                            Else
                                UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
                                dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
                                dao_maintain_return_money_deptor.insert()
                                id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID

                                UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
                                Response.Redirect(Request.Url.AbsoluteUri)

                            End If

                        Else
                            UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
                            dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
                            dao_maintain_return_money_deptor.insert()
                            id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID

                            UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
                            Response.Redirect(Request.Url.AbsoluteUri)
                        End If
                    Else
                        If UC_Maintain_ReturnMoney_Detail1.Check_rdl_sub_pay_type = True Then
                            UC_Maintain_ReturnMoney_Detail1.insert(dao_maintain_return_money_deptor)
                            dao_maintain_return_money_deptor.fields.MAIN_TYPE = rdl_Paytype_main.SelectedValue
                            dao_maintain_return_money_deptor.insert()
                            id = dao_maintain_return_money_deptor.fields.RETURN_MONEY_DEBTOR_ID

                            UC_Maintain_ReturnMoney_Detail1.insert_bill(id)
                            Response.Redirect(Request.Url.AbsoluteUri)
                        Else
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภทเงินเบิกเพิ่ม');", True)
                        End If

                    End If


                End If

            End If

        End If

        Dim log As New log_event.log
        log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                       Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลการคืนเงินลูกหนี้เงินยืม", _
                       "RETURN_MONEY_DEBTOR", id)

        ' End If



    End Sub
End Class