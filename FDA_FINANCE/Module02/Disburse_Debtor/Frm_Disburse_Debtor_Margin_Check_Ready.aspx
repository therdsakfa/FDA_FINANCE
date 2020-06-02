<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Debtor_Margin_Check_Ready.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_Margin_Check_Ready" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc3" %>
<%@ Register src="UserControl/UC_Disburse_Debtor_Check_Ready.ascx" tagname="UC_Disburse_Debtor_Check_Ready" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../../css/css_main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel panel-body"  style="width:100%;">
       <h3>เช็คพร้อมจ่าย</h3>
       </div> 
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%"><tr><td>   <uc3:UC_Search_Form ID="UC_Search_Form1" runat="server" /></td>
        <td> 
            <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" />
            <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg" /></td></tr></table>
    </div>     

<div class="panel panel-body"  style="width:100%;">           
<table width="100%">
    <tr>
        <td>
            
            <table width="100%">
                <tr>
                    <td align="right">
                        <table>
                        <tr>
                            <td align="right">วันที่ &nbsp;</td>
                            <td>
                                <telerik:raddatepicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH" Skin="Office2010Blue">
                                    <Calendar skin="Office2010Blue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:raddatepicker>
                            </td>
                            <td>
                                <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="พร้อมจ่าย" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
                <tr>
                    <td>
               
                        <uc1:UC_Disburse_Debtor_Check_Ready ID="UC_Disburse_Debtor_Check_Ready1" runat="server" />
               
                    </td>
                </tr>
             
            </table>

        </td>
    </tr>

        </table>

  
    </div>

</asp:Content>