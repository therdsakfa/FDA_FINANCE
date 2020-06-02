<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Node_Auto.ascx.vb" Inherits="FDA_FINANCE.UC_Node_Auto" %>
 <div style=" vertical-align: top;">
    
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" Font-Size="Medium" NodeWrap="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="Medium" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    
    </div>