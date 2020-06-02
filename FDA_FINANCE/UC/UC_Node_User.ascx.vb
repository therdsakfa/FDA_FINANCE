Public Class UC_Node_User
    Inherits System.Web.UI.UserControl
    Private _dept As String
    Private _bgid As String
    Private _myear As Integer = 0
    Sub rubQuery()
        Try
            _dept = Request.QueryString("dept")
        Catch ex As Exception

        End Try
        Try
            _bgid = Request.QueryString("bgid")
        Catch ex As Exception

        End Try
        Try
            _myear = Request.QueryString("myear")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rubQuery()
    End Sub
    Protected Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged

        If TreeView1.SelectedValue = TreeView1.SelectedNode.ValuePath Then
            If TreeView1.Nodes(0).Selected = True Then
                'Response.Redirect("../Module01/Frm_Plan_Select.aspx?process=1&head=500002")
            ElseIf TreeView1.Nodes(1).Selected = True Then
                'Frm_Disburse_Relate_Head_Approve
            ElseIf TreeView1.Nodes(2).Selected = True Then
                'Response.Redirect("../Module01/Frm_Plan_Select.aspx?process=3&head=500004")
            End If
        Else

            If TreeView1.Nodes(0).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module01/Frm_Transfer_Inside_User.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module01/Frm_Budget_Transfer_Receive_User.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(2).Selected = True Then
                Response.Redirect("~/Module01/Frm_Transfer_Outside_User.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)

            ElseIf TreeView1.Nodes(1).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Relate.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)

            ElseIf TreeView1.Nodes(4).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_PO.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)

            End If
        End If

    End Sub
End Class