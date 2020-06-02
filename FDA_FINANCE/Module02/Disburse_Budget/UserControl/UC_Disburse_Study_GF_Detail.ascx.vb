Public Class UC_Disburse_Study_GF_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            rdp_GFMIS_DATE.Text = System.DateTime.Now.ToShortDateString()
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)
        dao.fields.GFMIS_NUMBER = "KL" & txt_GFMIS.Text
        dao.fields.GFMIS_DATE = rdp_GFMIS_DATE.Text
        dao.fields.INCLUDE_SALARY_DIGIT = 0
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)
        rdp_GFMIS_DATE.Text = dao.fields.GFMIS_DATE
    End Sub
End Class