Public Class UC_SEARCH_RECEIVE_LIST
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "
        strMsg = "([BUDGET_YEAR] = '" & ddl_budget_year.SelectedValue & "')"
        If txt_DOC_NUMBER.Text <> "" Then
            strMsg &= " and ([DOC_NUMBER] ='" & txt_DOC_NUMBER.Text & "')"
        End If
        If ddl_product.SelectedValue <> "" Then
            strMsg &= " and ([product] ='" & ddl_product.SelectedValue & "')"
        End If
        If ddl_operation_bg.SelectedValue <> "" Then
            strMsg &= " and ([operation] ='" & ddl_operation_bg.SelectedValue & "')"
        End If
        If ddl_department.SelectedValue <> "" Then
            strMsg &= " and ([DEPARTMENT_ID] ='" & ddl_department.SelectedValue & "')"
        End If
        If rdl_budget_type.SelectedValue <> "" Then
            strMsg &= " and ([bguse_id] ='" & rdl_budget_type.SelectedValue & "')"
        End If
        If txt_Doc_Date.Text <> "" Then
            strMsg &= " and ([DOC_DATE] ='" & txt_Doc_Date.Text & "')"
        End If
        If txt_receive_date.Text <> "" Then
            strMsg &= " and ([BILL_DATE] ='" & txt_receive_date.Text & "')"
        End If
        Return strMsg
    End Function
End Class