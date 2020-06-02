<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_User_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_User_Insert" %>
<table>
    <tr>
        <td align="right">เลขประจำตัวประชาชน : </td>
        <td>
            <asp:TextBox ID="txt_PERSONAL_ID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ : </td>
        <td>
            <asp:TextBox ID="txt_PREFIX_NAME" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อ : </td>
        <td>
            <asp:TextBox ID="txt_NAME" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุล : </td>
        <td>
            <asp:TextBox ID="txt_SURNAME" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ประเภทเจ้าหน้าที่ : </td>
        <td>
            <asp:DropDownList ID="dd_USER_TYPE" runat="server" Height="22px" Width="128px">
                <asp:ListItem Value="1">TEST</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">หน่วยงาน : </td>
        <td>
            <asp:TextBox ID="txt_DEPARTMENT_DESCRIPTION" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>