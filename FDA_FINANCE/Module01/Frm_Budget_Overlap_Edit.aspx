<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master.Master" CodeBehind="Frm_Budget_Overlap_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Overlap_Edit" %>
<%@ Register src="UserControl/UC_Overlap_Detail.ascx" tagname="UC_Overlap_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="แก้ไขเงินกันไว้เหลื่อมปี">
    <table>
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                
                <uc1:UC_Overlap_Detail ID="UC_Overlap_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btn_bill_save" runat="server" Text="แก้ไข" />
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
