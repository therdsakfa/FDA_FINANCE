﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Budget_Type_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Type_Edit" %>
<%@ Register src="UserControl/UC_Budget_Type_Detail.ascx" tagname="UC_Budget_Type_Detail" tagprefix="uc1" %>
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
            <td>บันทึกข้อมูลประเภทงบประมาณ</td>
        </tr>
        
        <tr>
            <td>
               
                <uc1:UC_Budget_Type_Detail ID="UC_Budget_Type_Detail1" runat="server" />
               
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" class="submit"/>
                &nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
