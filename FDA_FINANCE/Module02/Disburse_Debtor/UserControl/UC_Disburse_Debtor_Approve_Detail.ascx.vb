Public Class UC_Disburse_Debtor_Approve_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)

        dao.fields.DEBTOR_TYPE_ID = rd_type.SelectedValue
        If rd_type.SelectedValue = "1" Then
            If rd_express_type.SelectedValue <> "" Then
                dao.fields.EXPRESS_TYPE_ID = 2 'rd_express_type.SelectedValue
            End If

            Try
                dao.fields.REBILL_ID = rd_Rebill.SelectedValue
            Catch ex As Exception
                dao.fields.REBILL_ID = 0
            End Try
        Else
            dao.fields.EXPRESS_TYPE_ID = 0
            dao.fields.REBILL_ID = Nothing
        End If
        Dim g As Integer = 0
        If rd_type.SelectedValue = "2" Then
            g = 1
        ElseIf rd_type.SelectedValue = "1" Then
            If rd_Rebill.SelectedValue = "1" Then
                g = 2
            Else
                g = 4
            End If
            'g = 2
        Else
            g = 0
        End If
        dao.fields.GROUP_ID = g
    End Sub
    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_DEBTOR_BILL)
        If dao.fields.DEBTOR_TYPE_ID IsNot Nothing Then
            rd_type.SelectedValue = dao.fields.DEBTOR_TYPE_ID
        End If
        If dao.fields.EXPRESS_TYPE_ID IsNot Nothing Then
            rd_express_type.SelectedValue = dao.fields.EXPRESS_TYPE_ID

        End If

        Try
            rd_Rebill.SelectedValue = dao.fields.REBILL_ID
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rd_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rd_type.SelectedIndexChanged
        set_rdl()
    End Sub
    Public Sub set_rdl()
        If rd_type.SelectedValue = "1" Then
            rd_express_type.Style.Add("display", "block")
            lb_pay_type.Style.Add("display", "block")
            lb_rebill.Style.Add("display", "block")
            rd_Rebill.Style.Add("display", "block")
        Else
            rd_express_type.Style.Add("display", "none")
            lb_pay_type.Style.Add("display", "none")
            lb_rebill.Style.Add("display", "none")
            rd_Rebill.Style.Add("display", "none")
        End If
    End Sub

    Public Function chk_app() As Boolean
        Dim bool As Boolean = False
        If rd_type.SelectedValue = "" Then
            bool = False
        ElseIf rd_type.SelectedValue = 2 Then
            bool = True
        ElseIf rd_type.SelectedValue = 1 Then
            Dim sub_bool1 As Boolean = False
            Dim sub_bool2 As Boolean = False

            If rd_express_type.SelectedValue = "" Then
                sub_bool1 = False
            ElseIf rd_express_type.SelectedValue = 1 Or rd_express_type.SelectedValue = 2 Then
                sub_bool1 = True
            End If

            If sub_bool1 = True Then
                bool = True
            Else
                bool = False
            End If
        End If
        Return bool
    End Function
End Class