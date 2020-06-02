<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master.Master" CodeBehind="Frm_Budget_Expand_Money_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Expand_Money_Edit" %>
<%@ Register src="UserControl/UC_Budget_Expand_Money_Detail.ascx" tagname="UC_Budget_Expand_Money_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>

                <uc1:UC_Budget_Expand_Money_Detail ID="UC_Budget_Expand_Money_Detail1" runat="server" />

            </td>
        </tr>
        <tr>
            <td>

                <asp:Button ID="btnSave" runat="server" Text="บันทึก" />

            </td>
        </tr>
    </table>
</asp:Content>
