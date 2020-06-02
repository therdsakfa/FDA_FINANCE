Public Class UC_MoneyType_Information_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByVal dao As DAO_MAS.TB_MAS_MONEY_TYPE)
        dao.fields.MONEY_AMOUNT = rnt_MONEY_AMOUNT.Value
    End Sub
    Public Sub getdata(ByVal dao As DAO_MAS.TB_MAS_MONEY_TYPE)
        rnt_MONEY_AMOUNT.Value = dao.fields.MONEY_AMOUNT
        lb_money_type_name.Text = dao.fields.MONEY_TYPE_DESCRIPTION
    End Sub
End Class