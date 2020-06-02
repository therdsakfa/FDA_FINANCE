<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Empty.Master" CodeBehind="FRM_RE_UPDATE.aspx.vb" Inherits="FDA_FINANCE.FRM_RE_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.blockUI.js"></script>
    
<%--
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>--%>
    <link href="../css/css_main.css" rel="stylesheet" />

    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ctl00_ContentPlaceHolder1_btn_Insert').click(function () {
                var bgid = getQuerystring('bgid');
                var bgYear = getQuerystring('myear');
                var select_dept = getQuerystring('dept');
                Popups('Frm_Maintain_ReceiveMoney_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&t=2');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }

            function getQuerystring(key, default_) {
                if (default_ == null) default_ = "";
                key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
                var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
                var qs = regex.exec(window.location.href);
                if (qs == null)
                    return default_;
                else
                    return qs[1];
            }

            showdate($("#ctl00_ContentPlaceHolder1_txt_date"));
        });

        $(function () {
            $('#<%= btn_search.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังส่งข้อมูลกรุณารอสักครู่....' });
            });
        });

        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f3'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f3'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }

        function refresh() {
            document.getElementById("ContentPlaceHolder1_btnRedirect").click();
        }
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;"> 
        <h3>ระบบส่งย้ำใบสั่งชำระ</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>
    <table width="100%">
        <tr>
            <td align="right" width="30%">
                Ref01 หรือเลขใบสั่งชำระ
            </td>
            <td>
                <asp:TextBox ID="txt_ref01" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
                &nbsp; &nbsp;&nbsp;(ตัวอย่างการกรอกเลขใบสั่งชำระ 79555/60)</td>
        </tr>
        <tr>
            <td align="right">
                Ref02</td>
            <td>
                <asp:TextBox ID="txt_ref02" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_search111" runat="server" Text="ค้นหาตาม Ref" CssClass="btn-lg" />
                <asp:Button ID="btn_search222" runat="server" Text="ค้นหาตามเลขใบสั่ง" CssClass="btn-lg" />
                </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_search" runat="server" Text="ส่งข้อมูล Ref" CssClass="btn-lg" OnClientClick="return confirm('ต้องการส่งข้อมูลหรือไม่?');" />
                <asp:Button ID="btn_search2" runat="server" Text="ส่งข้อมูลเลขใบสั่ง" CssClass="btn-lg" OnClientClick="return confirm('ต้องการส่งข้อมูลหรือไม่?');"/>
            
            </td>
        </tr>
        <tr>

            <td colspan="2">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="true" AllowMultiRowSelection="true" AllowPaging="true" AutoGenerateColumns="False" PageSize="20">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="feeno_format" HeaderText="เลขใบสั่งชำระ" UniqueName="feeno_format">
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="DATA_DATE" DataFormatString="{0:d}" DataType="System.DateTime" HeaderText="วันที่ใบสั่ง" UniqueName="DATA_DATE">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="ref01" HeaderText="REF01" UniqueName="ref01">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ref02" HeaderText="REF02" UniqueName="ref02">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="company_name" HeaderText="ชื่อผปก." UniqueName="company_name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="amt" DataFormatString="{0:###,###.##}" DataType="System.Double" HeaderText="จำนวนเงิน" UniqueName="amt">
                            </telerik:GridBoundColumn>
             
                            
                            <%--<telerik:GridButtonColumn ButtonType="LinkButton" CommandName="_import" ConfirmText="คุณต้องออกใบเสร็จ?" Text="ออกใบเสร็จ" UniqueName="btn_import">
                            </telerik:GridButtonColumn>--%>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <p>
                    *หมายเหตุ กรุณาตรวจสอบข้อมูลให้ถี่ถ้วนก่อนกดส่งทุกครั้ง<br />
                </p></td>
        </tr>
    </table>

    <br />
    <table width="100%">
        <tr>
            <td width="30%">
               
                
                
                
               
            </td>
        </tr>
    </table>
</asp:Content>