<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_PO_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_PO_Insert" %>
<%@ Register src="UserControl/UC_Disburse_Budget_PO_Detail.ascx" tagname="UC_Disburse_Budget_PO_Detail" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_PO_Add_List.ascx" tagname="UC_PO_Add_List" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../validate/jquery.validationEngine.js"></script>
    <script src="../../validate/jquery.validationEngine-en.js"></script>
    

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PO_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PO_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PO_Detail1_txt_BILL_DATE"));

           // jQuery("#aspnetForm").validationEngine();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

        });

        
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Panel ID="Panel1" runat="server" GroupingText="เพิ่มใบเบิกโครงการ">

    <table>
        <tr><td colspan="2" >
     หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true" Font-Names="TH SarabunPSK" Font-Size="14">

            </asp:DropDownList> <br/>

งบประมาณที่ได้รับการจัดสรร&nbsp;
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" AutoPostBack="true" 
                    DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Font-Names="TH SarabunPSK" Font-Size="14">
                </asp:DropDownList>
                </td></tr>
        <tr>
        <td align="right">
        <asp:Button ID="btn_bill_edit" runat="server" Text="บันทึกข้อมูล" />
        </td>
            
        </tr>
    <tr>
            <td>
               <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <%--<uc1:UC_Disburse_Budget_PO_Detail ID="UC_Disburse_Budget_PO_Detail1" runat="server" />--%>
               
                <uc2:UC_PO_Add_List ID="UC_PO_Add_List1" runat="server" />
               
            </td>
        </tr>
        
    </table>
    </asp:Panel>
</asp:Content>
