<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Welfare_Rebill.aspx.vb" Inherits="FDA_FINANCE.Frm_Welfare_Rebill" %>

<%@ Register Src="~/Module04/UseControl/UC_Welfare_Rebill.ascx" TagPrefix="uc1" TagName="UC_Welfare_Rebill" %>
<%@ Register Src="~/Module04/UseControl/UC_Welfare_Rebill_Search.ascx" TagPrefix="uc1" TagName="UC_Welfare_Rebill_Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <uc1:UC_Welfare_Rebill_Search runat="server" id="UC_Welfare_Rebill_Search" />
            </td>
            <td>
                <asp:Button ID="btn_Search" runat="server" Text="ค้นหา" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:UC_Welfare_Rebill runat="server" id="UC_Welfare_Rebill" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_Insert" runat="server" Text="บันทึก" />
            </td>
        </tr>
    </table>
</asp:Content>
