Public Class Frm_Send_Queue_Error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_queue()
    End Sub
    Sub Get_queue()
        'Dim dao As New DAO_MAS.TB_LOG_WAIT_RECEIPT
        'dao.GetDataby_All_NO()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.Get_Queue_Error()

        For Each dr As DataRow In dt.Rows
            Dim bao_mass As New BAO_BUDGET.MASS
            Try
                bao_mass.INSERT_WAIT_QUEUE_LIST(dr("ref01"), dr("ref02"))
            Catch ex As Exception
                bao_mass.INSERT_WAIT_QUEUE_LIST(dr("ref01"), dr("ref02"))
            End Try
        Next

    End Sub
End Class