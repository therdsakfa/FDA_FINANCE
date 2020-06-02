Public Class UC_Maintain_Other_Pay_Detail
    Inherits System.Web.UI.UserControl
    Public bgyear As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("bgYear") IsNot Nothing Then
            bgyear = Request.QueryString("bgYear")
        End If
    End Sub
    Public Sub set_date()
        txt_DO_DATE.Text = System.DateTime.Now.ToShortDateString()
    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_OTHER_PAY)
        dao.fields.AMOUNT = rnt_Amount.Value
        If rdl_Type.SelectedItem.Value <> "" Then
            dao.fields.DO_TYPE = rdl_Type.SelectedItem.Value
        Else
            dao.fields.DO_TYPE = Nothing
        End If
        If txt_DO_DATE.Text <> "" Then
            dao.fields.DO_DATE = CDate(txt_DO_DATE.Text)
        Else
            dao.fields.DO_DATE = Nothing
        End If

        dao.fields.DESCRIPTION = txt_Description.Text
        dao.fields.BUDGET_YEAR = bgyear
        dao.fields.NAME_IN_CHECK = txt_NAME_IN_CHECK.Text
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
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
        
        dao.fields.IS_CHECK_READY = cb_IS_CHECK_READY.Checked
        If txt_CHECK_READY_DATE.Text <> "" Then
            dao.fields.CHECK_READY_DATE = CDate(txt_CHECK_READY_DATE.Text)
        Else
            dao.fields.CHECK_RECEIVE_DATE = Nothing
        End If
        dao.fields.IS_CHECK_RECEIVE = cb_IS_CHECK_RECEIVE.Checked
        If txt_CHECK_RECEIVE_DATE.Text <> "" Then
            dao.fields.CHECK_RECEIVE_DATE = CDate(txt_CHECK_RECEIVE_DATE.Text)
        Else
            dao.fields.CHECK_RECEIVE_DATE = Nothing
        End If


    End Sub
    Public Sub update(ByRef dao As DAO_MAINTAIN.TB_OTHER_PAY)
        dao.fields.AMOUNT = rnt_Amount.Value
        If rdl_Type.SelectedItem.Value <> "" Then
            dao.fields.DO_TYPE = rdl_Type.SelectedItem.Value
        Else
            dao.fields.DO_TYPE = Nothing
        End If
        If txt_DO_DATE.Text <> "" Then
            dao.fields.DO_DATE = CDate(txt_DO_DATE.Text)
        Else
            dao.fields.DO_DATE = Nothing
        End If

        dao.fields.DESCRIPTION = txt_Description.Text
        dao.fields.NAME_IN_CHECK = txt_NAME_IN_CHECK.Text
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
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text

        dao.fields.IS_CHECK_READY = cb_IS_CHECK_READY.Checked
        If txt_CHECK_READY_DATE.Text <> "" Then
            dao.fields.CHECK_READY_DATE = CDate(txt_CHECK_READY_DATE.Text)
        Else
            dao.fields.CHECK_READY_DATE = Nothing
        End If
        dao.fields.IS_CHECK_RECEIVE = cb_IS_CHECK_RECEIVE.Checked
        If txt_CHECK_RECEIVE_DATE.Text <> "" Then
            dao.fields.CHECK_RECEIVE_DATE = CDate(txt_CHECK_RECEIVE_DATE.Text)
        Else
            dao.fields.CHECK_RECEIVE_DATE = Nothing
        End If
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_OTHER_PAY)
        rnt_Amount.Value = dao.fields.AMOUNT
        If dao.fields.DO_TYPE IsNot Nothing Then
            rdl_Type.SelectedItem.Value = dao.fields.DO_TYPE
        Else
            rdl_Type.SelectedItem.Value = ""
        End If
        If dao.fields.DO_DATE IsNot Nothing Then
            txt_DO_DATE.Text = CDate(dao.fields.DO_DATE).ToShortDateString()
        End If

        txt_Description.Text = dao.fields.DESCRIPTION
        txt_NAME_IN_CHECK.Text = dao.fields.NAME_IN_CHECK
        If dao.fields.CHECK_APPROVE IsNot Nothing Then
            If dao.fields.CHECK_APPROVE = True Then
                cb_CHECK_APPROVE.Checked = True
            Else
                cb_CHECK_APPROVE.Checked = False
            End If
        Else
            cb_CHECK_APPROVE.Checked = False
        End If

        If dao.fields.CHECK_APPROVE_DATE IsNot Nothing Then
            txt_CHECK_APPROVE_DATE.Text = CDate(dao.fields.CHECK_APPROVE_DATE).ToShortDateString()
        End If
       
        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString()
        End If

        txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER

        If dao.fields.IS_CHECK_READY IsNot Nothing Then
            If dao.fields.IS_CHECK_READY = True Then
                cb_IS_CHECK_READY.Checked = True
            Else
                cb_IS_CHECK_READY.Checked = False
            End If
        Else
            cb_IS_CHECK_READY.Checked = False
        End If

        If dao.fields.CHECK_READY_DATE IsNot Nothing Then
            txt_CHECK_READY_DATE.Text = CDate(dao.fields.CHECK_READY_DATE).ToShortDateString()
        End If
        If dao.fields.IS_CHECK_RECEIVE IsNot Nothing Then
            If dao.fields.IS_CHECK_RECEIVE = True Then
                cb_IS_CHECK_RECEIVE.Checked = True
            Else
                cb_IS_CHECK_RECEIVE.Checked = False
            End If
        Else
            cb_IS_CHECK_RECEIVE.Checked = False
        End If

        If dao.fields.CHECK_RECEIVE_DATE IsNot Nothing Then
            txt_CHECK_RECEIVE_DATE.Text = CDate(dao.fields.CHECK_RECEIVE_DATE).ToShortDateString()
        End If

    End Sub
End Class