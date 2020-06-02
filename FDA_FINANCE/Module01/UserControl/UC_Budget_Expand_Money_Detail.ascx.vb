Public Partial Class UC_Budget_Expand_Money_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_OVERLAP_HEAD)
        dao.fields.EXPAND_AMOUNT = rnt_EXPAND_AMOUNT.Value
        dao.fields.EXPAND_DATE = rdp_OVERLAP_EXPAND_DATE.SelectedDate

        If rd_IS_OVERLAP_EXPAND.SelectedValue = "True" Then
            dao.fields.IS_OVERLAP_EXPAND = True
        Else
            dao.fields.IS_OVERLAP_EXPAND = True
        End If

    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_OVERLAP_HEAD)
        rnt_EXPAND_AMOUNT.Value = dao.fields.EXPAND_AMOUNT
        rdp_OVERLAP_EXPAND_DATE.SelectedDate = dao.fields.EXPAND_DATE
        If dao.fields.IS_OVERLAP_EXPAND = True Then
            rd_IS_OVERLAP_EXPAND.SelectedValue = "True"
        ElseIf dao.fields.IS_OVERLAP_EXPAND = False Then
            rd_IS_OVERLAP_EXPAND.SelectedValue = "False"
        End If

    End Sub
End Class