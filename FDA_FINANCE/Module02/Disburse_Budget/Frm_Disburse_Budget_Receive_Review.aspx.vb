Public Class Frm_Disburse_Budget_Receive_Review
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Public type As Integer = 0
    Public Sub runQuery()
        type = Request.QueryString("type")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()

        If type = 1 Then
            btn_recive.Style.Add("display", "block")
            Panel2.Style.Add("display", "block")

            UC_Disburse_Budget_DetailV4_Table1.run_Query()
            UC_Disburse_Budget_DetailV4_Table1.type = 1
        Else
            btn_recive.Style.Add("display", "none")
            Panel2.Style.Add("display", "none")
        End If

        If Not IsPostBack Then

            UC_Disburse_Budget_DetailV4_Table1.bind_dl_bg()
            UC_Disburse_Budget_DetailV4_Table1.bind_dd_cus()
            UC_Disburse_Budget_DetailV4_Table1.bind_dd_gl()

            If Request.QueryString("bid") <> "" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
                UC_Disburse_Budget_DetailV21.get_data(dao)

                UC_Disburse_Budget_DetailV2_Table1.hide_add_data()
                UC_Disburse_Budget_DetailV3_Table.hide_add_data()

                Dim dao2 As New DAO_DISBURSE.TB_BUDGET_BILL_DETAIL
                dao2.Getdata_by_Disburse_id(Request.QueryString("bid"))

                If dao2.fields.DETAIL_ID <> 0 Then
                    UC_Disburse_Budget_DetailV4_Table1.get_date(dao2)
                End If

                If dao.fields.BUDGET_USE_ID = 1 Then
                    Panel2.Style.Add("display", "block")
                Else
                    Panel3.Style.Add("display", "block")
                End If
            End If


            'UC_Disburse_Budget_DetailV2_Table1.show_img_tooltip()

            UC_Disburse_Budget_DetailV4_Table1.bind_data_projectName()
        End If
    End Sub

    Private Sub btn_recive_Click(sender As Object, e As EventArgs) Handles btn_recive.Click
        If Request.QueryString("bid") <> "" Then
            Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
            dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(Request.QueryString("bid"))
            UC_Disburse_Budget_DetailV21.set_data_re(dao)
            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('รับเรื่องคืนเรียบร้อยแล้ว') ;", True)

        End If

    End Sub
End Class