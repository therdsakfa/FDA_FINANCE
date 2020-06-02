<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_BudgetPlan_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_BudgetPlan_Insert" %>
<%@ Register src="UserControl/UC_Budgetplan_Detail.ascx" tagname="UC_Budgetplan_Detail" tagprefix="uc1" %>

<%@ Register src="UserControl/UC_Budgetplan_Detail_Sub_BG.ascx" tagname="UC_Budgetplan_Detail_Sub_BG" tagprefix="uc2" %>

<%@ Register src="UserControl/UC_Budgetplan_Detail_Type7.ascx" tagname="UC_Budgetplan_Detail_Type7" tagprefix="uc3" %>

<%@ Register src="UserControl/UC_BudgetPlan_Detail_Type5.ascx" tagname="UC_BudgetPlan_Detail_Type5" tagprefix="uc4" %>

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
บันทึกข้อมูลงบประมาณ
</td>
</tr>
<tr>
<td>

    <uc1:UC_Budgetplan_Detail ID="UC_Budgetplan_Detail1" runat="server" />

    <uc2:UC_Budgetplan_Detail_Sub_BG ID="UC_Budgetplan_Detail_Sub_BG1" runat="server" Visible="false" />

    <uc3:UC_Budgetplan_Detail_Type7 ID="UC_Budgetplan_Detail_Type71" runat="server" />

    <uc4:UC_BudgetPlan_Detail_Type5 ID="UC_BudgetPlan_Detail_Type51" runat="server" />

</td>
</tr>
<tr>
<td align = "center"> 
    <asp:Button ID="btnSave" runat="server" Text="บันทึก" Width="70px" /> 
    <asp:Button ID="btnFinish" runat="server" Text="เสร็จสิ้น" style="display:none" />
    </td>
</tr>
</table>
</asp:Content>
