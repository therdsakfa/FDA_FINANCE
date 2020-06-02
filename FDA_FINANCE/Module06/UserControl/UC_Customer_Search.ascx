<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Customer_Search.ascx.vb" Inherits="FDA_FINANCE.UC_Customer_Search" %>
<table>
    <tr>
        <td align="right">ชื่อเจ้าหนี้ : </td>
        <td>
            <asp:TextBox ID="txt_Customername" runat="server"></asp:TextBox>
        </td>
        <td align="right">เลขประจำตัวผู้เสียภาษี :</td>
        <td>
            <asp:TextBox ID="txt_TAX_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขบัตรประจำตัวประชาชน :</td>
        <td>
            <asp:TextBox ID="txt_PERSONAL_ID" runat="server"></asp:TextBox>
        </td>
        <td align="right">เบอร์โทรศัพท์ :</td>
        <td>
            <asp:TextBox ID="txt_TEL_NUMBER" runat="server"></asp:TextBox></td>

    </tr>
</table>