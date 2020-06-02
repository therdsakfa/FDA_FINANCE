<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Department_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Department_Insert" %>
<%@ Register src="UserControl/UC_Department_Detail.ascx" tagname="UC_Department_Detail" tagprefix="uc1" %>
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
<td>
    บันทึกข้อมูลหน่วยงาน</td>
</tr>
<tr>
<td>

   

    <uc1:UC_Department_Detail ID="UC_Department_Detail1" runat="server" />

   

</td>
</tr>
<tr>
<td align = "center"> 
    <asp:Button ID="btnSave" runat="server" Text="บันทึก" class="submit"/> &nbsp;
    </td>
</tr>
</table>
</asp:Content>
