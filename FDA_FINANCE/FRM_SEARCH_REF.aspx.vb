Public Class FRM_SEARCH_REF
    Inherits System.Web.UI.Page
    Private Sub rg_log_Init(sender As Object, e As EventArgs) Handles rg_log.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_log
        Rad_Utility.addColumnBound("IDA", "IDA", False)

        Rad_Utility.addColumnBound("ref1", "ref1")
        Rad_Utility.addColumnBound("ref2", "ref2")
        Rad_Utility.addColumnDate("CREATEDATE", "CREATEDATE")
        Rad_Utility.addColumnBound("RESULT", "RESULT", width:=500)
    End Sub
    Sub Search_Data()
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO_FEE.FEE
        command = "select * from dbo.fee_logs "

        If TextBox1.Text <> "" Then
            command &= " where ref1='" & TextBox1.Text & "' "
            If TextBox2.Text <> "" Then
                command &= " and ref2 ='" & TextBox2.Text & "'"
            End If
            dt = bao_aa.Queryds(command)
        Else
            If TextBox2.Text <> "" Then
                command &= " where ref2 ='" & TextBox2.Text & "'"
                dt = bao_aa.Queryds(command)
            End If
        End If

        rg_log.DataSource = dt
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'If TextBox1.Text <> "" And TextBox2.Text <> "" Then
        Search_Data()
        'End If
        rg_log.Rebind()
    End Sub

    Private Sub rg_log_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_log.NeedDataSource
        'If TextBox1.Text <> "" And TextBox2.Text <> "" Then
        Search_Data()
        'End If
    End Sub
End Class