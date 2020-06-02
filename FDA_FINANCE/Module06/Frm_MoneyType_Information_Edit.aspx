<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_MoneyType_Information_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_MoneyType_Information_Edit" %>
<%@ Register src="UserControl/UC_MoneyType_Information_Detail.ascx" tagname="UC_MoneyType_Information_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>

                <uc1:UC_MoneyType_Information_Detail ID="UC_MoneyType_Information_Detail1" runat="server" />

            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" />
            </td>
        </tr>
    </table>
</asp:Content>
