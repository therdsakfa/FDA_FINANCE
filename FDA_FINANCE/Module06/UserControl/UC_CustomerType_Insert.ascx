<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CustomerType_Insert.ascx.vb" Inherits="FDA_FINANCE.UC_CustomerType_Insert" %>
<table>
<tr>
<td>ประเภทเจ้าหนี้ : </td>
<td> 
    <asp:TextBox ID="txtCustomerType" runat="server" class="validate[required] text-input"></asp:TextBox></td>
</tr>
    <tr>
        <td>ประเภทการหักภาษี :</td>
        <td>
            <asp:DropDownList ID="dd_Tax_Type" runat="server">
                <asp:ListItem Value="1">หักภาษี 1% ยอดเบิก &gt;= 500 </asp:ListItem>
                <asp:ListItem Value="2">หัก vat 7% แล้วหักภาษี 1% ยอดเบิก &gt;= 500</asp:ListItem>
                <asp:ListItem Value="3">หัก vat 7% แล้วหักภาษี 1% ยอดเบิก &gt;= 10000 </asp:ListItem>
                <asp:ListItem Value="4">ไม่คิดภาษี</asp:ListItem>
                <asp:ListItem Value="5">หักภาษี 1% ยอดเบิก &gt;= 10000</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Vat :</td>
        <td>
            <asp:TextBox ID="txt_Vat" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>ภาษี :</td>
        <td>
            <asp:TextBox ID="txt_Tax" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>