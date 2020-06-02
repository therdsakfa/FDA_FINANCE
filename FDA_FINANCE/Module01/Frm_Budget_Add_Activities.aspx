<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Budget_Add_Activities.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Add_Activities" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>

  <%--  <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>--%>
    <link href="../../css/css_main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body" style="width: 100%;">
        <h3>เพิ่มกิจกรรมย่อย</h3>
    </div>
     <div class="panel panel-body"  style="width:100%;">
         <table width="100%">
            <tr>
                <td width="30%">
                    ชื่อโครงการ :
                </td>
                <td>
                    <asp:Label ID="lbl_proj_name" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    ชื่อกิจกรรมย่อย :</td>
                <td>
                    <asp:TextBox ID="txt_activity_name" runat="server" Width="80%" CssClass="input-sm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    วันที่เริ่มกิจกรรม :</td>
                <td>
                    <asp:TextBox ID="txt_startdate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    วันที่สิ้นสุด :</td>
                <td>
                    <asp:TextBox ID="txt_end_date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_save" runat="server" Text="เพิ่มโครงการ/กิจกรรม" />
                </td>
            </tr>
        </table>
         <br />
         <table width="100%">
             <tr>
                 <td>
                     <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                    </telerik:RadGrid>
                 </td>
             </tr>
         </table>
    </div>
</asp:Content>
