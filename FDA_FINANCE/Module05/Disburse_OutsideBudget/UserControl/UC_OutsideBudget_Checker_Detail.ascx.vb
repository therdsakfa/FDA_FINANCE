Public Class UC_OutsideBudget_Checker_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            dao.fields.APPROVE_DATE = CDate(txt_date.Text)
        Catch ex As Exception
            dao.fields.APPROVE_DATE = Nothing
        End Try
        dao.fields.IS_APPROVE = True
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL)
        Try
            txt_date.Text = CDate(dao.fields.APPROVE_DATE)
        Catch ex As Exception
            txt_date.Text = ""
        End Try

        Try
            If dao.fields.IS_APPROVE = True Then
                rdl_result.SelectedValue = "1"
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub insert_reject(ByRef dao As DAO_DISBURSE.TB_BILL_CHECKER)
        dao.fields.REJECT_DATE = CDate(txt_date.Text)
    End Sub
    Public Function chk_rdl() As Boolean
        Dim bool As Boolean = False

        If rdl_result.SelectedValue <> "" Then
            bool = True
        End If

        Return bool
    End Function

    Public Function rdl_selected() As Boolean
        Dim str As String = ""
        str = rdl_result.SelectedValue
        Return str
    End Function
End Class