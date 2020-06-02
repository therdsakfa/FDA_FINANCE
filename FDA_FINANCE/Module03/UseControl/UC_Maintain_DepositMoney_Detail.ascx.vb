Public Partial Class UC_Maintain_Deposit_Money_Detail
    Inherits System.Web.UI.UserControl

    Public Validataion As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_DEPOSIT_DATE.Text = System.DateTime.Now.ToShortDateString()
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL)
        'dao.fields.DEPOSIT_DATE = rdp_DEPOSIT_DATE.SelectedDate
        'dao.fields.RECEIPT_VOLUME = txt_RECEIPT_VOLUME.Text
        'dao.fields.DEPOSIT_DESCRIPTION = txt_DEPOSIT_DESCRIPTION.Text
        'dao.fields.MONEY_TYPE_ID = rbl_MONEY_TYPE_DESCRIPTION.SelectedItem.Value
        'dao.fields.DEPOSIT_AMOUNT = txt_DEPOSIT_AMOUNT.Text
        dao.fields.RECEIVE_MONEY_ID = Request.QueryString("DEPOSIT_MONEY_ID")
        dao.fields.GF_NUMBER = txt_GF_NUMBER.Text
        dao.fields.DEPOSIT_DATE = CDate(txt_DEPOSIT_DATE.Text)
        dao.fields.DEPOSIT_DETAIL = txt_Detail.Text
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
        Try
            rdp_RECEIVE_DATE.Text = CDate(dao.fields.MONEY_RECEIVE_DATE).ToShortDateString()
        Catch ex As Exception

        End Try
        Try
            txt_RECEIPT_VOLUME.Text = dao.fields.RECEIPT_VOLUME
        Catch ex As Exception

        End Try
        Try
            txt_DEPOSIT_DESCRIPTION.Text = dao.fields.RECEIVE_MONEY_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            rbl_MONEY_TYPE_DESCRIPTION.SelectedValue = dao.fields.RECEIVE_MONEY_ID
        Catch ex As Exception

        End Try
        Try
            txt_DEPOSIT_AMOUNT.Text = dao.fields.RECEIVE_AMOUNT.ToString("N")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getdataDetail(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY_DETAIL)
        txt_DEPOSIT_DATE.Text = dao.fields.DEPOSIT_DATE
        txt_GF_NUMBER.Text = dao.fields.GF_NUMBER
    End Sub
End Class