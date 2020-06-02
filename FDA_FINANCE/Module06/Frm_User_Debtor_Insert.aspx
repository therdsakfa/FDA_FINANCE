<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_User_Debtor_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_User_Debtor_Insert" %>
<%@ Register src="UserControl/UC_User_Debtor_Add.ascx" tagname="UC_User_Debtor_Add" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>บันทึกข้อมูลลูกหนี้</td>
        </tr>
        
        <tr>
            <td>
               
                <uc1:UC_User_Debtor_Add ID="UC_User_Debtor_Add1" runat="server" />
               
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" class="submit" />
                &nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
