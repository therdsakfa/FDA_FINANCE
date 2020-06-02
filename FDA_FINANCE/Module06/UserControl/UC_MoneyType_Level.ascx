<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_MoneyType_Level.ascx.vb" Inherits="FDA_FINANCE.UC_MoneyType_Level" %>
<table width="100%">
    <tr>
        <td align="right">
            ประเภทเภทเงิน :
        </td>
        <td>
            <asp:TextBox ID="txt_level1" runat="server" Width="350px" Enabled="false" BorderStyle="Solid"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right">
            รายการย่อย :
        </td>
        <td>
            <asp:TextBox ID="txt_level2" runat="server" Width="350px" Enabled="false" BorderStyle="Solid"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
  
            ย่อยตัวแรก :</td>
        <td>
            <asp:TextBox ID="txt_level3" runat="server" Width="350px" Enabled="false" BorderStyle="Solid"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right">
            ย่อยตัวที่สอง :
        </td>
        <td>
            <asp:TextBox ID="txt_level4" runat="server" Width="350px" Enabled="false" BorderStyle="Solid"></asp:TextBox>
        </td>
    </tr>
</table>