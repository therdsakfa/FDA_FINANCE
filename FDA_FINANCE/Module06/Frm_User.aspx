<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_User.aspx.vb" Inherits="FDA_FINANCE.Frm_User" %>
<%@ Register src="UserControl/UC_User.ascx" tagname="UC_User" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
<tr>
<td>รายการบุคลากร</td>
</tr>
<tr>
<td>

    <uc1:UC_User ID="UC_User1" runat="server" />

</td>
</tr>
</table>
</asp:Content>
