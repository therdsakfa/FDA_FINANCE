<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_User_Debtor_Add.ascx.vb" Inherits="FDA_FINANCE.UC_User_Debtor_Add" %>
<table>
    <tr>
        <td align="right">คำนำหน้าชื่อ :</td>
        <td>
            <asp:TextBox ID="txt_Prefix" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อ :</td>
        <td>
            <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุล :</td>
        <td>
            <asp:TextBox ID="txt_Surname" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เพศ :</td>
        <td>
            <asp:DropDownList ID="dd_Gender" runat="server">
                <asp:ListItem Value="1">ชาย</asp:ListItem>
                <asp:ListItem Value="2">หญิง</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่บัตรประจำตัวประชาชน :</td>
        <td>
            <asp:TextBox ID="txt_Personal_ID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ตำแหน่ง : </td>
        <td>
            <asp:TextBox ID="txt_Position" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หน่วยงาน :</td>
        <td>
            <asp:DropDownList ID="dd_Department" runat="server" 
                 DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID">
            </asp:DropDownList>
        </td>
    </tr>
</table>