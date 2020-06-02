<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Customer_Add_Cer.aspx.vb" Inherits="FDA_FINANCE.Frm_Customer_Add_Cer" %>
<%@ Register Src="~/Module06/UserControl/UC_Customer_Add_Cer.ascx" TagName="UC_Customer_Add_Cer" TagPrefix="uc1" %>
<%--<%@ Register Src="~/Module06/UserControl/UC_Customer_Add_Cer_Show.ascx" TagName="UC_Customer_Add_Cer_Show" TagPrefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker.js" type="text/javascript"></script>
    <script src="../Jsdate/ui.datepicker-th.js" type="text/javascript"></script>
    <script src="../Jsdate/Jsdatemain.js" type="text/javascript"></script>
    <script src="../Script/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$("#UC_Person_In_MasterBill_KB1_ddl_Name").searchable();
            showdate($("#ctl00_ContentPlaceHolder1_UC_Customer_Add_Cer1_txt_dateCer"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Customer_Add_Cer1_txt_dateCerEnd"));
          
            
        });


         </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <uc1:UC_Customer_Add_Cer ID="UC_Customer_Add_Cer1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
