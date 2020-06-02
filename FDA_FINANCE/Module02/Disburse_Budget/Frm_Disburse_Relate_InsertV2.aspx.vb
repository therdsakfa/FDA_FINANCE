Public Class Frm_Disburse_Relate_InsertV2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Public _bid_ As Integer
    Public Sub runQuery()
        _bid_ = Request.QueryString("bid")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()

        UC_RELATE_BILL_DETAILV2_Table1.run_Query()

        If Not IsPostBack Then
            If Request.QueryString("bid") <> "" Then
                btn_bill_save.Style.Add("display", "none")
                btn_Edit.Style.Add("display", "block")
                Panel2.Style.Add("display", "block")
            Else
                btn_bill_save.Style.Add("display", "block")
                btn_Edit.Style.Add("display", "none")
                Panel2.Style.Add("display", "none")
            End If

            UC_RELATE_BILL_DETAILV2_Table1.bind_dd_cus()
            UC_RELATE_BILL_DETAILV2_Table1.bind_dl_bg()
            UC_RELATE_BILL_DETAILV2_Table1.bind_dd_gl()

            If Request.QueryString("bid") <> "" Then
                Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                dao.Getdata_by_ID(Request.QueryString("bid"))
                UC_RELATE_BILL_DETAILV21.get_data(dao)

                Dim dao2 As New DAO_DISBURSE.TB_RELATE_BG_DETAIL
                dao2.Getdata_by_Relate_id(_bid_)

                If dao2.fields.RELATE_DETAIL_ID <> 0 Then
                    UC_RELATE_BILL_DETAILV2_Table1.get_date(dao2)
                End If

            End If

            'UC_RELATE_BILL_DETAILV2_Table1.show_img_tooltip()
            UC_RELATE_BILL_DETAILV2_Table1.bind_data_projectName()
            'เพิ่มหน่วยงาน
            

        End If
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
        UC_RELATE_BILL_DETAILV21.set_data(dao)
        Dim bao As New BAO_BUDGET.DISBURSE_BUDGET
        Dim re_number As String = ""
        re_number = bao.get_relate_receive_number_max(Request.QueryString("bgYear"))
        dao.fields.DEPARTMENT_ID = Request.QueryString("dept")
        dao.fields.BUDGET_YEAR = Request.QueryString("bgYear")
        dao.fields.BUDGET_USE_ID = 1
        dao.fields.RECEIVE_NUMBER = CDbl(re_number) + 1
        dao.fields.STATUS_ID = 0
        Try
            dao.fields.RECEIVE_DATE = Date.Now()
        Catch ex As Exception

        End Try
        dao.fields.RECEIVE_FULL_NUMBER = CDbl(re_number) + 1 & "/" & Request.QueryString("bgYear")
        dao.insert()

        Dim dao_app As New DAO_MAS.TB_MAS_REASON_REJECT_BILL
        dao_app.fields.BILL_TYPE = 1
        dao_app.fields.DATE_ADD = Date.Now
        dao_app.fields.FK_IDA = dao.fields.RELATE_ID
        dao_app.fields.IDENTITY_NUMBER = _CLS.CITIZEN_ID_AUTHORIZE
        dao_app.fields.REASON_DATE = Date.Now
        dao_app.fields.STATUS_ID = 0
        dao_app.fields.GROUP_ID = 0

        dao_app.insert()

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&bid=" & dao.fields.RELATE_ID & "&Chk=1"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        If Request.QueryString("bid") <> "" Then
            Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
            dao.Getdata_by_ID(Request.QueryString("bid"))
            UC_RELATE_BILL_DETAILV21.set_data(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย');", True)

            ' UC_RELATE_BILL_DETAILV2_Table1.show_img_tooltip()
            UC_RELATE_BILL_DETAILV2_Table1.bind_dd_gl()
            UC_RELATE_BILL_DETAILV2_Table1.bind_data_projectName()
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub
End Class