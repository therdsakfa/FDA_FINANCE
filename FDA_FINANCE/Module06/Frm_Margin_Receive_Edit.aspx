<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Margin_Receive_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Margin_Receive_Edit" %>
<%@ Register src="UserControl/UC_Margin_Detail.ascx" tagname="UC_Margin_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             showdate($("#ctl00_ContentPlaceHolder1_UC_Margin_Detail1_txt_DO_DATE"));
         });
     </script>
    <table>
        <tr>
            <td>แก้ไขข้อมูล</td>
        </tr>
        
        <tr>
            <td>
               
                <uc1:UC_Margin_Detail ID="UC_Margin_Detail1" runat="server" />
               
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="แก้ไขข้อมูล" class="submit" />
                &nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
