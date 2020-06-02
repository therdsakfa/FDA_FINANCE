<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Node_User.ascx.vb" Inherits="FDA_FINANCE.UC_Node_User" %>
<div style=" vertical-align: top;">
    
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" Font-Size="Medium" NodeWrap="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                <asp:TreeNode Text="งบประมาณ" Value="ระบบงบประมาณ" Expanded="false">
                     <asp:TreeNode Text="โอนภายในกรม" Value="โอนภายในกรม" />
                    <asp:TreeNode Text="รับโอนจากหน่วยงานภายนอก" Value="รับโอนจากหน่วยงานภายนอก" />
                    <asp:TreeNode Text="โอนให้หน่วยงานภายนอก" Value="โอนให้หน่วยงานภายนอก" />
                </asp:TreeNode>

                <asp:TreeNode Text="ผูกพันเงินงบประมาณ" Value="ระบบผูกพันเงินงบประมาณ" Expanded="false">
                     <asp:TreeNode Text="รายการผูกพันเงินงบประมาณ" Value="รายการผูกพันเงินงบประมาณ"/>
                </asp:TreeNode>

                <asp:TreeNode Text="เบิกจ่าย" Value="ระบบเบิกจ่าย" Expanded="false">
                    <asp:TreeNode Text="รายการใบเบิก" Value="รายการใบเบิก"/>
                </asp:TreeNode>

                <asp:TreeNode Text="ลูกหนี้เงินยืม" Value="ระบบลูกหนี้เงินยืม" Expanded="false">
                    <asp:TreeNode Text="รายการลูกหนี้" Value="รายการลูกหนี้"/>
                </asp:TreeNode>		
                <asp:TreeNode Text="จัดซื้อจัดจ้าง" Value="ระบบจัดซื้อจัดจ้าง" Expanded="false">
                    <asp:TreeNode Text="รายการจัดซื้อจัดจ้าง" Value="รายการจัดซื้อจัดจ้าง"/>
                   
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Microsoft Sans Serif" Font-Size="Medium" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    
    </div>