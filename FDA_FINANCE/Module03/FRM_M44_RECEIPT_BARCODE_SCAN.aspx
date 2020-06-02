<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node2.Master" CodeBehind="FRM_M44_RECEIPT_BARCODE_SCAN.aspx.vb" Inherits="FDA_FINANCE.FRM_M44_RECEIPT_BARCODE_SCAN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="txt_barcode" runat="server" Width="50%" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Sent" runat="server" Text="ส่งข้อมูล" CssClass="btn-lg" />
            </td>
        </tr>
    </table>
</asp:Content>
