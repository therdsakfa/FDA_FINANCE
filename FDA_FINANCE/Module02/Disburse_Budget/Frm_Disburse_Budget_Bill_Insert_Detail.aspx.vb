Public Partial Class Frm_Disburse_Budget_Bill_Edit_Detail
    Inherits System.Web.UI.Page


    Private _bid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Public Sub runQuery()
        _bid = Request.QueryString("bid")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        If Not IsPostBack Then
            Dim aa As String = Request.Url.AbsoluteUri.ToString()
            Try
                'Dim daoMain As New DAO_DISBURSE.TB_BUDGET_BILL
                'daoMain.Getdata_by_BUDGET_DISBURSE_BILL_ID(_bid)
                'daoMain.get_bill_by_MasinKey(daoMain.fields.MAIN_KEY)
                'If daoMain.c_count = 0 Then
                '    RadNumericTextBox1.Value = 1
                'Else
                '    RadNumericTextBox1.Value = daoMain.c_count
                'End If

            Catch ex As Exception

            End Try
            Dim dao_bill As New DAO_DISBURSE.TB_BUDGET_BILL
            dao_bill.Getdata_by_BUDGET_DISBURSE_BILL_ID(_bid)
            UC_Disburse_Budget_Bill_Detail1.bind_ddl_k()
            UC_Disburse_Budget_Bill_Detail1.getdata(dao_bill)
            UC_Disburse_Budget_Bill_Detail1.ddl_split()
            UC_Disburse_Budget_Bill_Detail1.sub_k()

            'Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            'dao.Getdata_by_Disburse_id(_bid)
            'UC_Disburse_Budget_Bill_Detail1.Get_Detail(dao)
            If Request.QueryString("det") <> "" Then
                Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao_det.Getdata_by_DETAIL_ID(Request.QueryString("det"))
                UC_Disburse_Budget_Bill_Detail1.getdata_det(dao_det)
            End If
        End If
    End Sub


    Private Sub DulpicateBudget()
        Dim bid As Integer = Request.QueryString("bid")
        Dim dao_disburse As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_disburse.Getdata_by_BUDGET_DISBURSE_BILL_ID(bid)
        dao_disburse.fields.MAIN_KEY = bid
        dao_disburse.update()

        Dim dao_disbursed As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao_disbursed.Getdata_by_Disburse_id(bid)
        dao_disbursed.fields.AMOUNT = 0
        dao_disbursed.update()

        'For i As Integer = 1 To RadNumericTextBox1.Value - 1
        Dim dao_disburse_insert As New DAO_DISBURSE.TB_BUDGET_BILL
        dao_disburse_insert.Getdata_by_BUDGET_DISBURSE_BILL_ID(bid)
        dao_disburse_insert.fields.MAIN_KEY = bid

        Dim dd As New DAO_DISBURSE.TB_BUDGET_BILL
        dd.fields = dao_disburse_insert.fields
        dd.insert()



        Dim dao_disbursed_D_insert As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dao_disbursed_D_insert.Getdata_by_Disburse_id(bid)
        dao_disbursed_D_insert.fields.BUDGET_DISBURSE_BILL_ID = dd.fields.BUDGET_DISBURSE_BILL_ID
        dao_disbursed_D_insert.fields.AMOUNT = 0

        Dim dd2 As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
        dd2.fields = dao_disbursed_D_insert.fields
        dd2.insert()
        'Next


    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
      


        Dim dao_disburse As New DAO_DISBURSE.TB_BUDGET_BILL
        If Request.QueryString("bid") IsNot Nothing Then
            Dim dao_chk As New DAO_DISBURSE.TB_BUDGET_BILL
            'Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
            If UC_Disburse_Budget_Bill_Detail1.chk_len_k = True Then
                UC_Disburse_Budget_Bill_Detail1.TypeId = 1
                dao_disburse.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Budget_Bill_Detail1.insert(dao_disburse)
                If Request.QueryString("po") IsNot Nothing Then
                    'dao_disburse.fields.PAY_TYPE_ID = 1
                End If
                dao_disburse.fields.STATUS_ID = Request.QueryString("stat")
                dao_disburse.fields.GROUP_ID = Request.QueryString("g")
                dao_disburse.update()

                If Request.QueryString("det") <> "" Then
                    Dim dao_det As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                    dao_det.Getdata_by_DETAIL_ID(Request.QueryString("det"))
                    UC_Disburse_Budget_Bill_Detail1.update_det(dao_det)
                    dao_det.update()
                End If


                Dim dao2 As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
                dao2.fields.STATUS_ID = Request.QueryString("stat")
                dao2.fields.REASON_DATE = Date.Now
                dao2.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
                dao2.fields.DATE_ADD = Date.Now
                dao2.fields.FK_IDA = Request.QueryString("bid")
                dao2.fields.GROUP_ID = Request.QueryString("g")
                dao2.fields.BILL_TYPE = Request.QueryString("bt")
                dao2.insert()


                Dim log As New log_event.log
                log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                               Request.Url.AbsoluteUri.ToString(), "บันทึกข้อมูลขบ.ใบเบิกจ่ายเลขที่หนังสือ " & dao_disburse.fields.DOC_NUMBER & " และขบ.เลขที่ " & dao_disburse.fields.GFMIS_NUMBER, "BUDGET_BILL", Request.QueryString("bid"))
                'dao.Getdata_by_Disburse_id(_bid)
                'dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click(); ", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรอกเลข K ไม่ถูกต้อง');", True)
            End If
            
        End If

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    DulpicateBudget()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเพิ่มจำนวน GFMIS เรียบร้อยแล้ว') ;parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    'End Sub
End Class