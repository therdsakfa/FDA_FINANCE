<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Budget_Overlap_Debtor.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Overlap_Debtor" %>
<%@ Register src="UserControl/UC_Budget_Overlap_Debtor.ascx" tagname="UC_Budget_Overlap_Debtor" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Style="display:none;" Text="Button" />
                <uc1:UC_Budget_Overlap_Debtor ID="UC_Budget_Overlap_Debtor1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_bill_save" runat="server" Text="บันทึกข้อมูล" />
            </td>
        </tr>
    </table>

</asp:Content>
