<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_Withdraw.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_Withdraw" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor_Withdraw.ascx" tagname="UC_Maintain_ReturnMoney_Debtor_Withdraw" tagprefix="uc1" %>
<%@ Register src="UseControl/UC_Filter_Movedate.ascx" tagname="UC_Filter_Movedate" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/Jsdatemain.js"></script>
    
      <script type="text/javascript">
          $(document).ready(function () {
              showdate($("#ctl00_ContentPlaceHolder1_txt_date"));
          });
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="900px">
        <tr>
            <td align="center">

                <uc2:uc_filter_movedate ID="UC_Filter_Movedate1" runat="server" />
            </td>
            <td>

                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" Width="60px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">

                &nbsp;</td>
        </tr>
        <tr>
            <td>

                บันทึกนำฝากเงิน</td>
        </tr>
        <tr>
            <td align="center">

                <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" />

            </td>
        </tr>
        <tr>
            <td>

               
                

               
                <uc1:UC_Maintain_ReturnMoney_Debtor_Withdraw ID="UC_Maintain_ReturnMoney_Debtor_Withdraw1" runat="server" />

               
                

               
            </td>
        </tr>
    </table>
</asp:Content>
