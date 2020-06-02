Public Partial Class UC_Disburse_OutsideDebtor_Bill_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        dao.fields.GFMIS_NUMBER = txt_GFMIS.Text
        dao.fields.GFMIS_DATE = rdp_GFMIS_DATE.SelectedDate
    End Sub
    Public Sub insert_GF_table(ByVal dao As DAO_DISBURSE.TB_MAS_GFMIS)
        dao.fields.BUDGET_DISBURSE_BILL_ID = Request.QueryString("gid")
        dao.fields.GFMIS = txt_GFMIS.Text
        dao.fields.GFMIS_DATE = rdp_GFMIS_DATE.SelectedDate
        dao.fields.GFMIS_TYPE_ID = 1
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        txt_GFMIS.Text = dao.fields.GFMIS_NUMBER
    End Sub
End Class