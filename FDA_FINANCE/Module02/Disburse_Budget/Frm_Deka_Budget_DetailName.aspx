<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Deka_Budget_DetailName.aspx.vb" Inherits="FDA_FINANCE.Frm_Deka_Budget_DetailName" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Deka_Budget_DetailName.ascx" TagPrefix="uc1" TagName="UC_Deka_Budget_DetailName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>

    <link href="../../css/css_main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-body" style="width: 100%; padding-left: 5%;">
        <h3><font color="black">รายการซื้อ/จ้าง</font></h3>
    </div>

    <div class="panel panel-body" style="width: 100%; display: none;">
   
    </div>
    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">

            <tr>
                <td align="right">&nbsp;</td>
            </tr>
             <tr>
                <td align="right">
                    <uc1:UC_Deka_Budget_DetailName runat="server" ID="UC_Deka_Budget_DetailName" />
                </td>
            </tr>

            <tr>

                <td align="center">

                    <asp:Button ID="btn_Add" runat="server" Text="บันทึกข้อมูล" Width="120px" CssClass="btn-lg" />
                    
                    &nbsp;&nbsp;
                    
                    <asp:Button ID="btn_Cancel" runat="server" Text="ยกเลิก" Width="100px" CssClass="btn-lg" />
                    <asp:Button ID="btnRedirect" runat="server" Style="display: none;" Text="Button" />
                    <asp:HiddenField ID="hf_Id" runat="server" />
                </td>
            </tr>
                   <tr>
                <td align="right">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rg_list" runat="server" GridLines="None" AllowPaging="true" PageSize="20"
                        AutoGenerateColumns="false" Width="100%">
                    </telerik:RadGrid>
                </td>
            </tr>
             <tr>
                <td align="right"><br /></td>
            </tr>
        </table>
    </div>



</asp:Content>
