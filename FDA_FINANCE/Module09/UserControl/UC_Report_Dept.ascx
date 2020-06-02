<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Report_Dept.ascx.vb" Inherits="FDA_FINANCE.UC_Report_Dept" %>
<table>
    <tr>
        <td>หน่วยงาน :</td>
        <td>
            <asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList>

            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>

</table>