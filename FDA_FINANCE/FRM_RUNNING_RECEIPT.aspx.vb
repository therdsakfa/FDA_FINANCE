Public Class FRM_RUNNING_RECEIPT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Gen_Receipt()
    End Sub

    Sub Gen_Receipt()
        'Dim dao As New DAO_MAS.TB_LOG_WAIT_RECEIPT
        'dao.GetDataby_All_NO()
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.Get_LOG_WAIT_RECEIPT()

        For Each dr As DataRow In dt.Rows
            Dim str As String = ""
            Dim ws_rc As New WS_RECEIPT_AUTO
            str = ws_rc.Gen_Receipt_Wait(dr("REF01"), dr("REF02"))
            If str = "success" Then
                Dim dao_w As New DAO_MAS.TB_LOG_WAIT_RECEIPT
                dao_w.Getdata_by_ref01_ref02(dr("REF01"), dr("REF02"))
                dao_w.fields.STATUS_RECEIPT = 1
                dao_w.update()
            End If
        Next

    End Sub
End Class