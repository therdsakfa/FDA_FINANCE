<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_SendMoneyDepartment_Details.ascx.vb" Inherits="FDA_FINANCE.UC_SendMoneyDepartment_Details" %>
<table>
    <tr>
        <td align="right">เลขที่บัญชี : </td>
        <td>
            <asp:TextBox ID="txt_BANK_ACCOUNT" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อธนาคาร/หน่วยงาน : </td>
        <td>
            <asp:TextBox ID="txt_DEPARTMENT_OR_BANK_NAME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">สาขา : </td>
        <td>
            <asp:TextBox ID="txt_BRANCH_NAME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อย่อ : </td>
        <td>
            <asp:TextBox ID="txt_SHORT_DEPARTMENT_NAME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
</table>