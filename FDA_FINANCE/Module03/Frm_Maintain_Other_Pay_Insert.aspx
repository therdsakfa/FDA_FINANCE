<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_Other_Pay_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Other_Pay_Insert" %>
<%@ Register src="UseControl/UC_Maintain_Other_Pay_Detail.ascx" tagname="UC_Maintain_Other_Pay_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/Jsdatemain.js"></script>

       <script type="text/javascript">
           $(document).ready(function () {
               showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_Other_Pay_Detail1_txt_DO_DATE"));
               showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_Other_Pay_Detail1_txt_CHECK_DATE"));
               showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_Other_Pay_Detail1_txt_CHECK_APPROVE_DATE"));
               showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_Other_Pay_Detail1_txt_CHECK_READY_DATE"));
               showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_Other_Pay_Detail1_txt_CHECK_RECEIVE_DATE"));
           });

        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกรับ/จ่ายเงินอื่นๆ">
    <table>
    <tr>
            <td>
                
                
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                
                <uc1:UC_Maintain_Other_Pay_Detail ID="UC_Maintain_Other_Pay_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
        <td align="center">
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึก" Width="60px" />
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
