Public Class UC_Maintain_ReceiveMoney_Detail_Bank
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' bind_dl_Bank()
        'If Not IsPostBack Then
        '    txt_CHECK_DATE.Text = System.DateTime.Now.ToShortDateString()
        'End If
    End Sub

    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        dao.fields.BANK_BRANCH_NAME = txt_BANK_BRANCH_NAME.Text
        dao.fields.BANK_NAME = txt_BANK_NAME.Text
        If txt_CHECK_DATE.Text <> "" Then
            dao.fields.CHECK_DATE = CDate(txt_CHECK_DATE.Text)
        End If
        dao.fields.CHECK_NUMBER = txt_CHECK_NUMBER.Text
    End Sub

    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        txt_BANK_BRANCH_NAME.Text = dao.fields.BANK_BRANCH_NAME
        'dl_BANK_NAME.SelectedItem.Text = dao.fields.BANK_NAME
        txt_BANK_NAME.Text = dao.fields.BANK_NAME
        If dao.fields.CHECK_DATE IsNot Nothing Then
            txt_CHECK_DATE.Text = CDate(dao.fields.CHECK_DATE).ToShortDateString()
        End If
        txt_CHECK_NUMBER.Text = dao.fields.CHECK_NUMBER
    End Sub

    'Public Sub bind_dl_Bank()
    '    If Not IsPostBack Then
    '        Dim bao As New BAO_BUDGET.Maintain
    '        Dim dt As DataTable = bao.get_BANK_NAME()
    '        dl_BANK_NAME.DataSource = dt
    '        dl_BANK_NAME.DataTextField = "BANK_NAME"
    '        dl_BANK_NAME.DataValueField = "BANK_ID"
    '        dl_BANK_NAME.DataBind()
    '    End If
    'End Sub

End Class