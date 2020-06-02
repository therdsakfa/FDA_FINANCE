<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Search_User_Debtor.ascx.vb" Inherits="FDA_FINANCE.UC_Search_User_Debtor" %>
<table >
    <tr>
        <td>
            ชื่อ-นามสกุล :
        </td>
        <td>
            <asp:TextBox ID="txt_fullname" runat="server"></asp:TextBox>
        </td>
        <td>เลขบัตรประชาชน :</td>
        <td>
            <asp:TextBox ID="txt_Personal_id" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>หน่วยงาน :</td>
        <td>
            <asp:TextBox ID="txt_Department" runat="server"></asp:TextBox>
        </td>
        <td>ตำแหน่ง :</td>
        <td>
            <asp:TextBox ID="txt_Position" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>