Public Class FRM_SEND_UPDATE_STATUS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Send_Status()
    End Sub
    Sub Send_Status()

        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.Get_LOG_QUEUE_LIST()

        For Each dr As DataRow In dt.Rows
            Dim ws_los_sai As New WS_INSERT_LOGS_SAI.WS_INSERT_LOGS
            Try
                ws_los_sai.insert_log(dr("FK_ID"), "Send_Status", dr("DVCD"))
            Catch ex As Exception

            End Try

            Dim str As String = ""
            Dim ws_update As New WS_UPDATE_PAY.WS_UPDATE_STATUS_PAY
            Try
                ws_update.Update_byID(dr("DVCD"), dr("PROCESS_ID"), dr("FK_REF_STATUS"), dr("FK_ID"), dr("REF02"), dr("REF01"), dr("FK_FDL_IDA"))

                Dim dao_log As New DAO_MAS.TB_LOG_WAIT_QUEUE_LIST
                dao_log.Getdata_by_ID(dr("IDA"))
                dao_log.fields.STATUS_SEND = "S"
                dao_log.update()
            Catch ex As Exception

            End Try

        Next

    End Sub
End Class