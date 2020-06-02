<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Relate_Berg_Period.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Relate_Berg_Period" %>
<%@ Register src="UserControl/UC_RELATE_BILL_USER_BERG.ascx" tagname="UC_RELATE_BILL_USER_BERG" tagprefix="uc1" %>
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

    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#<%= btn_bill_save.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
    <tr>
            <td>
              
           
                <uc1:UC_RELATE_BILL_USER_BERG ID="UC_RELATE_BILL_USER_BERG1" runat="server" />
              
           
            </td>
        </tr>
        <tr>
            <td>

                <asp:Button ID="btn_bill_save" runat="server" style="width: 132px" Text="บันทึก" />
                <asp:Button ID="btn_Edit" runat="server" style="width: 132px;display:none;" Text="แก้ไข" />
            </td>
        </tr>
       <%-- <tr>
        <td align="center">
            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td><asp:Button ID="btn_bill_save" runat="server" Text="บันทึก" style="display:none;"/></td>
                    <td><asp:Button ID="btn_cancel" runat="server" Text="ย้อนกลับ" style="display:none;" /></td>
                </tr>
               
            </table>
        </td>
            
        </tr>--%>
        </table>
</asp:Content>
