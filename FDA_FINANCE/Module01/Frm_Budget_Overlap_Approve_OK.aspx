<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master.Master" CodeBehind="Frm_Budget_Overlap_Approve_OK.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Overlap_Approve_OK" %>
<%@ Register src="../Module02/Disburse_Budget/UserControl/UC_Budget_Amount_Detail.ascx" tagname="UC_Budget_Amount_Detail" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Budget_Overlap_Approve_OK.ascx" tagname="UC_Budget_Overlap_Approve_OK" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" /> 
    <table>

        <tr><td colspan="2" bgcolor="#FFFFCC" style="border: thin ridge #000000">

            งบประมาณ
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
                </asp:DropDownList>
                </td></tr>
        <tr bgcolor="#CCFFCC">
            <td colspan="2">
                <uc1:UC_Budget_Amount_Detail ID="UC_Budget_Amount_Detail1" runat="server" />
            </td>
        </tr>
         <tr>
            <td>การอนุมัติเงินกันไว้เหลื่อมปี</td>
        </tr>
        <tr>
            <td>
                
                <uc2:UC_Budget_Overlap_Approve_OK ID="UC_Budget_Overlap_Approve_OK1" runat="server" />
                
            </td>
        </tr>
    </table>
</asp:Content>
