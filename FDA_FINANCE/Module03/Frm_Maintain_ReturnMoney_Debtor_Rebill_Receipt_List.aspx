<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List_ascx" %><%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List.ascx" tagname="UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>

                <uc1:UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List ID="UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_List1" runat="server" />

            </td>
        </tr>
    </table>
</asp:Content>
