Public Class Frm_Disburse_Outside_Budget_Checker_Insert
    Inherits System.Web.UI.Page
    Dim _bid As Integer
    Public Sub runQuery()
        _bid = Request.QueryString("bid")
    End Sub
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
        runQuery()
        RunSession()
    End Sub

    Private Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        If UC_OutsideBudget_Checker_Detail1.chk_rdl = True Then
            Dim rdl_select As String = ""
            rdl_select = UC_OutsideBudget_Checker_Detail1.rdl_selected
            If rdl_select = "1" Then
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(_bid)
                UC_OutsideBudget_Checker_Detail1.insert(dao)
                dao.update()

                Dim dao_chk As New DAO_DISBURSE.TB_BILL_CHECKER
                UC_OutsideBudget_Checker_Detail1.insert_reject(dao_chk)
                dao_chk.fields.REJECT_TYPE = 1
                dao_chk.fields.BUDGET_DISBURSE_BILL_ID = _bid
                dao_chk.insert()
            Else
                Dim dao As New DAO_DISBURSE.TB_BUDGET_BILL
                dao.Getdata_by_BUDGET_DISBURSE_BILL_ID(_bid)
                dao.fields.APPROVE_DATE = Nothing
                dao.fields.IS_APPROVE = False
                dao.update()

                Dim dao_b As New DAO_DISBURSE.TB_BILL_CHECKER
                dao_b.Getdata_by_ID_type(_bid, 2)
                For Each dao_b.fields In dao_b.datas
                    dao_b.fields.REJECT_TYPE = 2
                Next
                dao_b.update()

                Dim dao_c As New DAO_DISBURSE.TB_BILL_CHECKER
                UC_OutsideBudget_Checker_Detail1.insert_reject(dao_c)
                dao_c.fields.BUDGET_DISBURSE_BILL_ID = _bid
                dao_c.fields.REJECT_TYPE = 2
                dao_c.insert()

            End If
        Else
            'alert
        End If
    End Sub
End Class