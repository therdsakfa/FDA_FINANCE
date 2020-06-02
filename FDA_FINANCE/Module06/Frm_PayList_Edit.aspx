<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_PayList_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_PayList_Edit" %>
<%@ Register src="~/Module06/UserControl/UC_PayList_Inserts.ascx" tagname="UC_PayList_Inserts" tagprefix="uc1" %>
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
            <td>แก้ไขค่าใช้จ่าย</td>
        </tr>
        
        <tr>
            <td>

                
                <uc1:UC_PayList_Inserts ID="UC_PayList_Inserts1" runat="server" />

                
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Edit" runat="server" Text="แก้ไขข้อมูล" class="submit" />
                &nbsp;
                               
            </td>
        </tr>
    </table>
</asp:Content>
