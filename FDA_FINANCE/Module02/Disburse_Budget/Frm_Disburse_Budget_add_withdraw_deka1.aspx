<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_add_withdraw_deka1.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_add_withdraw_deka1" %>


<%@ Register src="UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc3" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_deka_add.ascx" TagPrefix="uc3" TagName="UC_Disburse_Budget_withdraw_deka_add" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_deka_add2.ascx" TagPrefix="uc3" TagName="UC_Disburse_Budget_withdraw_deka_add2" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_deka_add3.ascx" TagPrefix="uc3" TagName="UC_Disburse_Budget_withdraw_deka_add3" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_deka_add4.ascx" TagPrefix="uc3" TagName="UC_Disburse_Budget_withdraw_deka_add4" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.2.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {;
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add1_txt_deka_date"));

            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl02_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl04_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl06_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl08_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl10_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl12_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl14_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl16_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl18_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl20_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl22_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl24_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl26_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl28_GFMIS_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add21_rg_list_ctl00_ctl30_GFMIS_DATE"));

        });



        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
</script> 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server">
          <div class="panel panel-body" style="width: 100%;">

        <table width="100%">
            <tr>
                <td>
                    <uc3:UC_Disburse_Budget_withdraw_deka_add runat="server" ID="UC_Disburse_Budget_withdraw_deka_add1" />

                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>

       <asp:Panel ID="Panel2" runat="server" >
          <div class="panel panel-body" style="width: 100%;">

        <table width="100%">
            <tr>
                <td>
                    <uc3:UC_Disburse_Budget_withdraw_deka_add2 runat="server" id="UC_Disburse_Budget_withdraw_deka_add21" />

                </td>
            </tr>
              <tr align="center">
            <td>
                <asp:Button ID="btn_Save" runat="server" Height="35px" Width="13%" Text="บันทึกเรื่องเบิก" />
            </td>
        </tr>
            <tr>
                <td>
                    <br />      <br />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>

       <asp:Panel ID="Panel3" runat="server" Style="display: none;">
          <div class="panel panel-body" style="width: 100%;">

        <table width="100%">
            <tr>
                <td>
                    <uc3:UC_Disburse_Budget_withdraw_deka_add3 runat="server" id="UC_Disburse_Budget_withdraw_deka_add31" />

                </td>
            </tr>
             <tr align="center">
            <td>
                <asp:Button ID="btn_Save2" runat="server" Height="35px" Width="13%" Text="บันทึกหมวดงบ" />
            </td>
        </tr>
             <tr>
                <td>
                    <br />      <br />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" Style="display: none;">
          <div class="panel panel-body" style="width: 100%;">

        <table width="100%">
            <tr>
                <td>
                    <uc3:UC_Disburse_Budget_withdraw_deka_add4 runat="server" id="UC_Disburse_Budget_withdraw_deka_add41" />

                </td>
            </tr>
             <tr>
                <td>
                    <br />
                </td>
            </tr>
               <tr align="center">
            <td>
                <asp:Button ID="btn_Save3" runat="server" Height="35px" Width="13%" Text="บันทึกหมวดรายจ่าย" />
            </td>
        </tr>
             <tr>
                <td>
                    <br />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
  
    <br />
    <br />

    
</asp:Content>

