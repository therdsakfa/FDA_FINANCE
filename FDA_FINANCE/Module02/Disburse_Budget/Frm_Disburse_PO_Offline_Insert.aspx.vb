Public Class Frm_Disburse_PO_Offline_Insert
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
        UC_Disburse_Budget_Detail1.is_insert = True
      
        If Request.QueryString("dept") IsNot Nothing Then
            UC_Disburse_Budget_Detail1.dept_id = Request.QueryString("dept")
            'Else
            '    UC_Disburse_Budget_Detail1.dept_id = dept_id
        End If
        UC_Disburse_Budget_Detail1.egp = True
        If Not IsPostBack Then
            UC_Disburse_Budget_Detail1.set_date()
            UC_Disburse_Budget_Detail1.bind_cus()
        End If
        'If Request.QueryString("id") IsNot Nothing Then
        '    Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL

        'End If
    End Sub

    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        If UC_Disburse_Budget_Detail1.chk_amount_less_5k = False Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_PO_DETAIL
                Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_master As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
                ' UC_Budget_PO_Detail1.insert(dao)
                UC_Disburse_Budget_Detail1.insert(dao_po)
                UC_Disburse_Budget_Detail1.insert_master(dao_master)
                dao_po.fields.IS_PO = True
                dao_master.fields.IS_PO = True
                If Request.QueryString("flag") IsNot Nothing Then
                    dao_po.fields.BUDGET_USE_ID = 2
                    dao_po.fields.DEPARTMENT_ID = 23

                    dao_master.fields.BUDGET_USE_ID = 2
                    dao_master.fields.DEPARTMENT_ID = 23
                Else


                    dao_po.fields.BUDGET_USE_ID = 1
                    dao_master.fields.BUDGET_USE_ID = 1

                    If Request.QueryString("bguse") IsNot Nothing Then
                        If Request.QueryString("bguse") = "3" Then
                            dao_po.fields.BUDGET_USE_ID = 3
                            dao_master.fields.BUDGET_USE_ID = 3
                        End If

                    End If

                End If
                'If Request.QueryString("flag") = "sup" Then
                '    dao_po.fields.DEPARTMENT_ID = 23
                'End If
                dao_po.insert()

                Dim id As Integer = dao_po.fields.BUDGET_DISBURSE_BILL_ID
                Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_master.fields.BUDGET_DISBURSE_BILL_ID = id
                dao_master.insert()

                UC_Disburse_Budget_Detail1.insert_detail(dao_detail, id)
                dao_detail.insert()
                Dim master_id As Integer
                master_id = dao_master.fields.ID
                Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
                Dim dao_mas_main As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
                dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
                dao_bill_main.fields.MAIN_BILL = id
                dao_bill_main.update()

                dao_master.Getdata_by_ID(master_id)
                dao_master.fields.MAIN_BILL = id
                dao_master.update()

                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลใบจัดซื้อจัดจ้างเลขที่หนังสือ " _
                               & dao_po.fields.DOC_NUMBER, "BUDGET_BILL", dao_po.fields.BUDGET_DISBURSE_BILL_ID)

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        Else
            Dim dao As New DAO_DISBURSE.TB_BUDGET_PO_DETAIL
            Dim dao_po As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_master As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
            ' UC_Budget_PO_Detail1.insert(dao)
            UC_Disburse_Budget_Detail1.insert(dao_po)
            UC_Disburse_Budget_Detail1.insert_master(dao_master)
            dao_po.fields.IS_PO = True
            dao_master.fields.IS_PO = True
            If Request.QueryString("flag") IsNot Nothing Then
                dao_po.fields.BUDGET_USE_ID = 2
                dao_po.fields.DEPARTMENT_ID = 23

                dao_master.fields.BUDGET_USE_ID = 2
                dao_master.fields.DEPARTMENT_ID = 23
            Else


                dao_po.fields.BUDGET_USE_ID = 1
                dao_master.fields.BUDGET_USE_ID = 1

                If Request.QueryString("bguse") IsNot Nothing Then
                    If Request.QueryString("bguse") = "3" Then
                        dao_po.fields.BUDGET_USE_ID = 3
                        dao_master.fields.BUDGET_USE_ID = 3
                    End If

                End If

            End If
            'If Request.QueryString("flag") = "sup" Then
            '    dao_po.fields.DEPARTMENT_ID = 23
            'End If
            dao_po.insert()

            Dim id As Integer = dao_po.fields.BUDGET_DISBURSE_BILL_ID
            Dim dao_detail As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            dao_master.fields.BUDGET_DISBURSE_BILL_ID = id
            dao_master.insert()

            UC_Disburse_Budget_Detail1.insert_detail(dao_detail, id)
            dao_detail.insert()
            Dim master_id As Integer
            master_id = dao_master.fields.ID
            Dim dao_bill_main As New DAO_DISBURSE.TB_BUDGET_BILL
            Dim dao_mas_main As New DAO_DISBURSE.TB_BUDGET_MASTER_BILL
            dao_bill_main.Getdata_by_BUDGET_DISBURSE_BILL_ID(id)
            dao_bill_main.fields.MAIN_BILL = id
            dao_bill_main.update()

            dao_master.Getdata_by_ID(master_id)
            dao_master.fields.MAIN_BILL = id
            dao_master.update()

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลใบจัดซื้อจัดจ้างเลขที่หนังสือ " _
                           & dao_po.fields.DOC_NUMBER, "BUDGET_BILL", dao_po.fields.BUDGET_DISBURSE_BILL_ID)

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
        End If

    End Sub

    Private Sub Frm_Disburse_PO_Offline_Insert_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_Disburse_Budget_Detail1.stat_egp = 1
        'UC_Disburse_Budget_Detail1.set_egp_txt()
    End Sub
End Class