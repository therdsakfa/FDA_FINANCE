<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="FRM_CHANGE_NAME.aspx.vb" Inherits="FDA_FINANCE.FRM_CHANGE_NAME" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>ชื่อ</td>
            <td>
                <asp:TextBox ID="txt_full_name" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="แก้ไข/บันทึก" />
            </td>
        </tr>
    </table>
</asp:Content>
