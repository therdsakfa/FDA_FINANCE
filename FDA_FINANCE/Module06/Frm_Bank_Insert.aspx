<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Bank_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Bank_Insert1" %>
<%@ Register src="~/Module06/UserControl/UC_Bank_Insert.ascx" tagname="UC_Bank_Insert" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../validate/jquery.validationEngine.js"></script>
    <script src="../validate/jquery.validationEngine-en.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             jQuery("#aspnetForm").validationEngine();
         });
</script>   
 <table>
        <tr>
            <td>บันทึกข้อมูลธนาคาร</td>
        </tr>
        
        <tr>
            <td>
                &nbsp;<uc1:UC_Bank_Insert ID="UC_Bank_Insert1" runat="server" />
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
