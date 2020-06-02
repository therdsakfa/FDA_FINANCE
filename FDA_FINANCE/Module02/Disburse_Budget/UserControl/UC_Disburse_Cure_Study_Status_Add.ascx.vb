Public Class UC_Disburse_Cure_Study_Status_Add
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'txt_CHECK_APPROVE_DATE.Text = System.DateTime.Now.ToShortDateString()
            'txt_CHECK_DATE.Text = System.DateTime.Now.ToShortDateString()
            'txt_CHECK_RECEIVE_DATE.Text = System.DateTime.Now.ToShortDateString()
            'txt_Return_Appr_date.Text = System.DateTime.Now.ToShortDateString()
            Dim uti As New Utility_other
            Dim strQuery As Integer
            Dim digit As Integer
            If Request.QueryString("bid") IsNot Nothing Then
                strQuery = Request.QueryString("bid")
                digit = uti.getCure_Study_Status(strQuery)
                Select Case digit
                    Case 5
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel5.Enabled = True

                    Case 4
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel5.Enabled = True
                    Case 3
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = True
                        Panel5.Enabled = False
                    Case 2
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = True
                        Panel4.Enabled = False
                        Panel5.Enabled = False
                    Case 1
                        Panel1.Enabled = True
                        Panel2.Enabled = True
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        Panel5.Enabled = False

                    Case 0
                        Panel1.Enabled = True
                        Panel2.Enabled = False
                        Panel3.Enabled = False
                        Panel4.Enabled = False
                        Panel5.Enabled = False


                End Select


            End If
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)

        dao.fields.IS_CHECK_RECEIVE = cb_IS_CHECK_RECEIVE.Checked
        dao.fields.CHECK_APPROVE = cb_CHECK_APPROVE.Checked
        If txt_CHECK_APPROVE_DATE.Text <> "" Then
            dao.fields.CHECK_APPROVE_DATE = CDate(txt_CHECK_APPROVE_DATE.Text)
        Else
            dao.fields.CHECK_APPROVE_DATE = Nothing
        End If
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        Else
            dao.fields.CHECK_DATE = Nothing
        End If
        If txt_RETURN_BUDGET_DATE.Text <> "" Then
            dao.fields.RETURN_BUDGET_DATE = CDate(txt_RETURN_BUDGET_DATE.Text)
        Else
            dao.fields.RETURN_BUDGET_DATE = Nothing
        End If

        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        dao.fields.RETURN_APPROVE_NUMBER = txt_Return_appr.Text
        If txt_CHECK_RECEIVE_DATE.Text <> "" Then
            dao.fields.CHECK_RECEIVE_DATE = CDate(txt_CHECK_RECEIVE_DATE.Text)
        Else
            dao.fields.CHECK_RECEIVE_DATE = Nothing
        End If
        If txt_Return_Appr_date.Text <> "" Then
            dao.fields.RETURN_APPROVE_DATE = CDate(txt_Return_Appr_date.Text)
        Else
            dao.fields.RETURN_APPROVE_DATE = Nothing
        End If
        If txt_Check_ready_date.Text <> "" Then
            dao.fields.CHECK_READY_DATE = CDate(txt_Check_ready_date.Text)
        Else
            dao.fields.CHECK_READY_DATE = Nothing
        End If
        dao.fields.IS_CHECK_READY = cb_is_check_ready.Checked
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)
        If dao.fields.CHECK_APPROVE = True Then
            cb_CHECK_APPROVE.Checked = True
        Else
            cb_CHECK_APPROVE.Checked = False
        End If

        If dao.fields.IS_CHECK_RECEIVE = True Then
            cb_IS_CHECK_RECEIVE.Checked = True
        Else
            cb_IS_CHECK_RECEIVE.Checked = False
        End If

        If dao.fields.CHECK_APPROVE_DATE IsNot Nothing Then
            txt_CHECK_APPROVE_DATE.Text = dao.fields.CHECK_APPROVE_DATE
        End If

        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = dao.fields.CHECK_DATE
        End If
        If dao.fields.CHECK_NUMBER IsNot Nothing Then
            txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
        End If
        If dao.fields.RETURN_APPROVE_NUMBER IsNot Nothing Then
            txt_Return_appr.Text = dao.fields.RETURN_APPROVE_NUMBER
        End If
        If dao.fields.RETURN_APPROVE_DATE IsNot Nothing Then
            txt_Return_Appr_date.Text = dao.fields.RETURN_APPROVE_DATE
        End If
        If dao.fields.CHECK_RECEIVE_DATE IsNot Nothing Then
            txt_CHECK_RECEIVE_DATE.Text = dao.fields.CHECK_RECEIVE_DATE
        End If

        If dao.fields.RETURN_BUDGET_DATE IsNot Nothing Then
            txt_RETURN_BUDGET_DATE.Text = dao.fields.RETURN_BUDGET_DATE
        End If
        If dao.fields.CHECK_READY_DATE IsNot Nothing Then
            txt_Check_ready_date.Text = dao.fields.CHECK_READY_DATE
        End If
        If dao.fields.IS_CHECK_READY Is Nothing Then
            cb_is_check_ready.Checked = False
        Else
            cb_is_check_ready.Checked = dao.fields.IS_CHECK_READY
        End If


    End Sub
End Class