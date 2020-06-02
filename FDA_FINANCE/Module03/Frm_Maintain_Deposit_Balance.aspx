<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_Deposit_Balance.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Deposit_Balance" %>
<%@ Register src="UseControl/UC_Maintain_Deposit_Balance_Detail.ascx" tagname="UC_Maintain_Deposit_Balance_Detail" tagprefix="uc1" %>
<%@ Register src="UseControl/UC_Maintain_Deposit_Balance.ascx" tagname="UC_Maintain_Deposit_Balance" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../Scripts/jquery-1.7.1.js"></script>
     <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_txt_date_save"));
        });

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table>
    <tr>
        <td align="right">วันที่บันทึก : </td>
        <td>
            <asp:TextBox ID="txt_date_save" runat="server" AutoPostBack="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่บัญชีเงินทดรอง : </td>
        <td>
            <asp:TextBox ID="txt_ACCOUNT_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงินคงเหลือตามบัญชีเงินฝาก : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_ACCOUNT_BALANCE_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox> &nbsp; บาท</td>
    </tr>
    <tr>
        <td align="right">เลขที่เช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
           
            <telerik:RadNumericTextBox ID="rnt_CHECK_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox> &nbsp; บาท
        </td>
    </tr>
    <tr>
        <td align="right">ดอกเบี้ย : </td>
        <td>
    <telerik:RadNumericTextBox ID="rnt_INTEREST_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox> &nbsp; บาท
        </td>
    </tr>
    <tr>
        <td ></td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Width="80px" />
                <asp:Button ID="btnRedirect" runat="server" Style="display:none;" Text="Button" />
            </td>
        </tr>
</table>
    <table width="900px">
        <tr>
            <td align="right">
                <asp:Button ID="btn_report" runat="server" Text="ดูรายงาน" Width="80px" />
            </td>
        </tr>
        <tr>
            
            <td>

                <uc2:UC_Maintain_Deposit_Balance ID="UC_Maintain_Deposit_Balance1" runat="server" />

            </td>
        </tr>
    </table>
</asp:Content>
