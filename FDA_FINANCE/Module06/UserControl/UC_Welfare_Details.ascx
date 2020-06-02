<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfare_Details.ascx.vb" Inherits="FDA_FINANCE.UC_Welfare_Details" %>
<table>
    <tr>
        <td align="right">รหัสสวัสดิการ : </td>
        <td>
            <asp:TextBox ID="txt_WELFARE_TYPE_CODE" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อสวัสดิการ : </td>
        <td>
            <asp:TextBox ID="txt_WELFARE_TYPE_DESCRIPTION" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อย่อ : </td>
        <td>
            <asp:TextBox ID="txt_WELFARE_TYPE_SHORT_DESCRIPTION" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
</table>