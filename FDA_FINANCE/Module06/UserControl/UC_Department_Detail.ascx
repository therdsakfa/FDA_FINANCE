<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Department_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Department_Detail1" %>
<table>
    <tr>
        <td align="right">
            รหัสหน่วยงาน : 
        </td>
        <td>
            <asp:TextBox ID="txt_dept_code" runat="server" ></asp:TextBox>
        </td>
    </tr>
<tr>
    <td align="right">
        ชื่อหน่วยงาน : </td>
    <td>
        <asp:TextBox ID="txt_dept_description" runat="server" class="validate[required] text-input"></asp:TextBox>
    </td>
</tr>

</table>