<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Gov_Personel_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Gov_Personel_Insert" %>

<%@ Register src="UC/UC_Gov_Personel_Detail.ascx" tagname="UC_Gov_Personel_Detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--        <tr>
            <td>บันทึกข้อมูล</td>
        </tr>--%>
        <tr>
            <td>
                <uc1:UC_Gov_Personel_Detail ID="UC_Gov_Personel_Detail1" runat="server" />

            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" class="submit" Height="36px" Width="108px" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
