<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Approve_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Approve_Detail" %>
<style type="text/css">
    .auto-style1
    {
        height: 23px;
    }
</style>
<table>
     <tr>
        <td align="right">ประเภทการเบิก :</td>
        <td>
            <%--<asp:DropDownList ID="dd_type" runat="server">
                <asp:ListItem Value="1">ด่วน</asp:ListItem>
                <asp:ListItem Value="2">ไม่ด่วน</asp:ListItem>
            </asp:DropDownList>--%>
            <asp:RadioButtonList ID="rd_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Value="2">เงินงบประมาณ</asp:ListItem>
                <asp:ListItem Value="1">เงินทดรอง</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        
    </tr>
    <tr>
         <td align="right" >
             <asp:Label ID="lb_pay_type" runat="server" Text="ประเภทการจ่าย :" style="display:none;"></asp:Label>
         </td>
            <td class="auto-style1">
                <asp:RadioButtonList ID="rd_express_type" runat="server" RepeatDirection="Horizontal" style="display:none;">
                     <asp:ListItem Value="1">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
                </asp:RadioButtonList>
            </td>
    </tr>
    <tr>
         <td align="right"> 
             <asp:Label ID="lb_rebill" runat="server" Text="การวางเบิก : " style="display:none;"></asp:Label>
         </td>
            <td>
                <asp:RadioButtonList ID="rd_Rebill" runat="server" RepeatDirection="Horizontal" style="display:none;">
                     <asp:ListItem Value="1">วางเบิก</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">ไม่วางเบิก</asp:ListItem>
                </asp:RadioButtonList>
            </td>
    </tr>
</table>