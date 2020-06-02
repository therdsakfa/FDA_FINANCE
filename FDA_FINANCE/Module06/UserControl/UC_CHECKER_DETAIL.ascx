<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CHECKER_DETAIL.ascx.vb" Inherits="FDA_FINANCE.UC_CHECKER_DETAIL" %>
<table>
    <tr>
        <td align="right">หมายเลขบัตรประชาชน</td>
        <td>
            <asp:TextBox ID="txt_CTZID" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อ-นามสกุล</td>
        <td>
            <asp:TextBox ID="txt_FULLNAME" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
</table>