<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Customer_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Customer_Insert" %>

<%@ Register src="~/Module06/UserControl/UC_CustomerDetails.ascx" tagname="UC_CustomerDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../validate/jquery.validationEngine.js"></script>
    <script src="../validate/jquery.validationEngine-en.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#ctl00_ContentPlaceHolder1_UC_CustomerDetails1_dd_Tax_Number").searchable();
             //$("#ctl00_ContentPlaceHolder1_UC_CustomerDetails1_dd_Personal_ID").searchable();
             jQuery("#aspnetForm").validationEngine();
         });
     </script>
<table>
        <tr>
            <td>บันทึกรายละเอียดเจ้าหนี้</td>
        </tr>
        
        <tr>
            <td>
                
                <uc1:UC_CustomerDetails ID="UC_CustomerDetails1" runat="server" />
                
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
