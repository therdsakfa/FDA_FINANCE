Public Class UC_Node
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
                Response.Redirect("~/Module06/Frm_BudgetPlan.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module06/Frm_BudgetPlan_Adjust.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(2).Selected = True Then
                Response.Redirect("~/Module01/Frm_Transfer_Inside.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(3).Selected = True Then
                Response.Redirect("~/Module01/Frm_Budget_Transfer_Receive.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(4).Selected = True Then
                Response.Redirect("~/Module01/Frm_Transfer_Outside.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(0).ChildNodes(5).Selected = True Then
                Response.Redirect("~/Module01/Frm_Approve_Transfer.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(1).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Relate_Overview.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(1).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Relate_Head_Approve.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Overview.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_List.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(2).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Unlock_Deeka.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(3).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Bill.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(4).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Deeka_Number.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(5).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Direct.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(2).ChildNodes(6).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_PayType_Pass.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Overview.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Receive_List.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(2).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Unlock_Deeka.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(3).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(4).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Deeka_Number.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(5).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Ok.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)

            ElseIf TreeView1.Nodes(3).ChildNodes(6).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Add_Status.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(7).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Margin.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(3).ChildNodes(8).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Margin_Cash.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
                '
            ElseIf TreeView1.Nodes(4).ChildNodes(0).Selected = True Then
                'ทะเบียนประวัติพนักงานราชการ
                Response.Redirect("~/Module07/Frm_Gov_Personel_All.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(4).ChildNodes(1).Selected = True Then
                'รายการจ่ายค่าตอบแทนพนักงานราชการ
                Response.Redirect("~/Module07/Frm_Salary_All.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(4).ChildNodes(2).Selected = True Then
                'ทะเบียนประวัติลูกจ้างเหมา
                Response.Redirect("~/Module07/Frm_Employee_All.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(4).ChildNodes(3).Selected = True Then
                'รายการจ่ายค่าตอบแทนลูกจ้างเหมา
                Response.Redirect("~/Module07/Frm_Salary_Employee.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(5).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module03/Frm_Maintain_ReceiveMoney.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(5).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module03/Frm_Maintain_ReturnMoney_Debtor.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(5).ChildNodes(2).Selected = True Then
                Response.Redirect("~/Module03/Frm_Maintain_ReturnMoney_Debtor_History.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(5).ChildNodes(3).Selected = True Then
                Response.Redirect("~/Module03/Frm_Maintain_DepositMoney.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(5).ChildNodes(4).Selected = True Then
                Response.Redirect("~/Module03/Frm_Maintain_DepositMoney_Debtor.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(6).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module04/Frm_Welfare_Cure.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(6).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module04/Frm_Welfare_Study.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(7).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module05/Disburse_OutsideBudget/Frm_Disburse_OutsideBudget_Overview.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(7).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module05/Disburse_OutsideDebtor/Frm_Disburse_OutsideDebtor_Overview.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(8).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_PO_Overview.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(8).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Receive_PO_List.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(8).ChildNodes(2).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Unlock_Deeka_PO.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(8).ChildNodes(3).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_PO_Bill.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(8).ChildNodes(4).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Deeka_Number_PO.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)
            ElseIf TreeView1.Nodes(8).ChildNodes(5).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_PO_PayType_Direct.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear)

            ElseIf TreeView1.Nodes(9).ChildNodes(0).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Print_Check.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear & "&btype=1")
            ElseIf TreeView1.Nodes(9).ChildNodes(1).Selected = True Then
                Response.Redirect("~/Module02/Disburse_Budget/Frm_Disburse_Budget_Print_Check.aspx?dept=" & _dept & "&bgid=" & _bgid & "&myear=" & _myear & "&btype=2")

            ElseIf TreeView1.Nodes(10).ChildNodes(0).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_001_1.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(1).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_002.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(2).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_003.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(3).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_004.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(4).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_005.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(5).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_006.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(6).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_007.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(7).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_008.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(8).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_009.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(9).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_010.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(10).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_011.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(11).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_012.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(12).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_013.aspx');", True)

            ElseIf TreeView1.Nodes(10).ChildNodes(13).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_014.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(14).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_015.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(15).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_016.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(16).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module01/Report/Frm_Report_R1_017.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(17).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_001.aspx');", True)

            ElseIf TreeView1.Nodes(10).ChildNodes(18).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_002.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(19).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_003.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(20).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_004.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(21).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_005.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(22).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_006.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(23).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_007.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(24).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_008.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(25).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_009.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(26).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_010.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(27).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_011.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(28).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_012.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(29).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_013.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(30).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_014.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(31).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_015.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(32).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_016.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(33).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_017.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(34).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_018.aspx?t=1');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(35).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_019.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(36).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_020.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(37).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_021.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(38).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_022.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(39).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_023.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(40).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_024.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(41).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module02/Report/Frm_Report_R2_025.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(42).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_001.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(43).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_002.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(44).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_003.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(45).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_004.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(46).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_005.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(47).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_006.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(48).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_007.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(49).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_008.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(50).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module03/Report/Frm_Report_R3_009.aspx');", True)

            ElseIf TreeView1.Nodes(10).ChildNodes(51).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_001.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(52).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_002.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(53).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_003.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(54).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_004.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(55).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_005.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(56).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_006.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(57).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_007.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(58).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module04/Report/Frm_Report_R4_008.aspx');", True)

            ElseIf TreeView1.Nodes(10).ChildNodes(59).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_001.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(60).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_002.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(61).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_003.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(62).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_004.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(63).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_005.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(64).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_006.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(65).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_007.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(66).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_008.aspx');", True)
            ElseIf TreeView1.Nodes(10).ChildNodes(67).Selected = True Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../Module05/Report/Frm_Report_R5_009.aspx');", True)
            End If
        End If

    End Sub
End Class