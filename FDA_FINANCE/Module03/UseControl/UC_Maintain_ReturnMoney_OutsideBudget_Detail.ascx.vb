Public Class UC_Maintain_ReturnMoney_OutsideBudget_Detail
    Inherits System.Web.UI.UserControl
    Public rc_id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim str_date As String = ""
            str_date = System.DateTime.Now.ToShortDateString()
            txt_DOC_DATE.Text = str_date
            txt_return_date.Text = str_date

            Dim dao_rec As New DAO_MAS.TB_MAS_MONEY_RECEIVER
            dao_rec.get_receiver()
            lb_money_receiver.Text = dao_rec.fields.RECEIVER_NAME
            rc_id = dao_rec.fields.RECEIVER_MONEY_ID
        End If
    End Sub

    Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RETURN_MONEY_DEBTOR)
        dao.fields.PAY_TYPE = rbl_MONEY_TYPE_DESCRIPTION.SelectedItem.Value
        dao.fields.DOC_DATE = CDate(txt_DOC_DATE.Text)
        dao.fields.DOC_NUMBER = txt_DOC_NUMBER.Text
        dao.fields.DISBURSE_VOLUME = txt_DISBURSE_VOLUME.Text
        dao.fields.DISBURSE_NUMBER = txt_DISBURSE_NUMBER.Text
        dao.fields.RETURN_DESCRIPTION = txt_RETURN_DESCRIPTION.Text
        dao.fields.RETURN_AMOUNT = txt_RETURN_AMOUNT.Text
        'dao.fields.DEBTOR_TYPE = 2 'ใส่ 1 เป็นลูกหนี้ นอกงบประมาณ
        dao.fields.BUDGET_DISBURSE_DEBTOR_BILL_ID = Request.QueryString("DEBTOR_BILL_ID")
        dao.fields.MONEY_RETURN_DATE = CDate(txt_return_date.Text)
        dao.fields.RECEIVER_MONEY_ID = rc_id
    End Sub

    Public Sub getdata(ByRef bao As BAO_BUDGET.Maintain)

        Dim dt As DataTable = bao.get_DEBTOR_BILL_out_BUDGET_by_DEBTOR_BILL_ID(Request.QueryString("DEBTOR_BILL_ID"))
        If dt.Rows.Count > 0 Then
            Dim doc_date As String = ""
            Dim returndate As String = ""
            If IsDBNull(dt(0).Item("DOC_DATE")) = False Then
                doc_date = dt(0)("DOC_DATE")
            End If
            If IsDBNull(dt(0)("MONEY_RETURN_DATE")) = False Then
                returndate = dt(0)("MONEY_RETURN_DATE")
            End If

            txt_DOC_DATE.Text = dt(0)("DOC_DATE")
            txt_DOC_NUMBER.Text = dt(0)("DOC_NUMBER")
            txt_DISBURSE_VOLUME.Text = dt(0)("DISBURSE_VOLUME")
            txt_DISBURSE_NUMBER.Text = dt(0)("DISBURSE_NUMBER")
            txt_RETURN_DESCRIPTION.Text = dt(0)("RETURN_DESCRIPTION")
            txt_RETURN_AMOUNT.Text = dt(0)("RETURN_AMOUNT")
            ' txt_RECEIVER_NAME.Text = dt(0)("RECEIVER_NAME")
            txt_return_date.Text = returndate
        End If
       
    End Sub

End Class