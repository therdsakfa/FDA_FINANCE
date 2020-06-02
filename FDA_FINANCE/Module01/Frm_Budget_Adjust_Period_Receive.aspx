<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Budget_Adjust_Period_Receive.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Adjust_Period_Receive" %>
<%@ Register src="UserControl/UC_Budget_Period_Receive.ascx" tagname="UC_Budget_Period_Receive" tagprefix="uc1" %>
<%--<%@ Register src="UserControl/UC_Budget_Period_Receive.ascx" tagname="UC_Budget_Period_Receive" tagprefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
    function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 600,
                width: 800,
                modal: true
            });
            openform(url, "#1234");
            return false;
        }


        function openform(urls, idiframe) {
            $.blockUI({ message: msg() });
            function msg() {
                return 'กรุณารอสักครู่ระบบกำลังทำงาน';
            }
            $.ajax({
                type: 'POST',
                data: { submit: true },
                success: function (result) {
                    var i = $(idiframe); // ID ของ iframe
                    i.attr("src", urls); //  url ของ form ที่จะเปิด
                    $.unblockUI();
                }
            });
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="900px">
        <tr>
            <td colspan="2">บันทึกรับงวดโครงการ
                <asp:Button ID="btn_del" runat="server" Text="Button" Style="display:none;" OnClientClick="confirmDelete();"/>
                <asp:TextBox ID="txt_id" runat="server" Style="display:none;" ></asp:TextBox>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </td>
        </tr>
       <%-- <tr><td colspan="2" bgcolor="#FFFFCC" style="border: thin ridge #000000">
     หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" Font-Names="TH SarabunPSK" Font-Size="14" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList> <br/>

งบประมาณที่ได้รับการจัดสรร&nbsp;
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" AutoPostBack="true" 
                    DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Font-Names="TH SarabunPSK" Font-Size="14">
                </asp:DropDownList>
                </td></tr>--%>

         <tr><td colspan="2">
                
               <%-- <uc1:UC_Budget_Period_Receive ID="UC_Budget_Period_Receive1" runat="server" />--%>
                
                <uc1:UC_Budget_Period_Receive ID="UC_Budget_Period_Receive1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="Button" Style="display:none;" />
                </td></tr>
    </table>

    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>
