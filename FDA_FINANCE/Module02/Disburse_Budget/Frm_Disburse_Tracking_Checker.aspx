<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Tracking_Checker.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Tracking_Checker" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ctl00_ContentPlaceHolder1_btnAdd').click(function () {
                Popups('Frm_Checker_Insert.aspx');
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

        });

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f2'); // ID ของ iframe   
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
                <h3>เพิ่มงานผู้ตรวจสอบ</h3>
    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
</div>
<div class="panel panel-body"  style="width:100%;">
<table width="100%">
<tr>
<td align="right">
    <%--<asp:DropDownList ID="ddl_checker" runat="server" Width="200px">
    </asp:DropDownList>--%>
    <asp:Button ID="btnAdd" runat="server" Text="บันทึก" CssClass="btn-lg" />
</td>
</tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
        <tr>
            <td>

                  <%--<telerik:RadGrid ID="rg_checker" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" AllowFilteringByColumn="true"
                    Width="100%" AllowMultiRowSelection="true">
                    <ClientSettings EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="true" />
                    </ClientSettings>
                      </telerik:RadGrid>--%>

                <telerik:RadGrid ID="rg_checker" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30" AllowFilteringByColumn="true"
                    Width="100%" AllowMultiRowSelection="true">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="chkColumn"></telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn Display="false" DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn Display="false" DataField="type" DataType="System.Int32" FilterControlAltText="Filter type column" HeaderText="type" SortExpression="type" UniqueName="type">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOC_NUMBER" FilterControlAltText="Filter DOC_NUMBER column" HeaderText="เลขหนังสือ" SortExpression="DOC_NUMBER" UniqueName="DOC_NUMBER">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOC_DATE" FilterControlAltText="Filter DOC_DATE column" HeaderText="วันที่" SortExpression="DOC_DATE" UniqueName="DOC_DATE" DataFormatString="{0: d/MM/yyyy}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DESCRIPTION" FilterControlAltText="Filter DESCRIPTION column" HeaderText="รายการ" SortExpression="DESCRIPTION" UniqueName="DESCRIPTION">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sum_amount" DataType="System.Decimal" FilterControlAltText="Filter sum_amount column" HeaderText="จำนวนเงิน" SortExpression="sum_amount" UniqueName="sum_amount" DataFormatString="{0:###,##0.00}">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="FULLNAME" HeaderText="ชื่อผู้ตรวจสอบ">
                                <ItemTemplate>
                                    <center>
                                   <%--     <asp:DropDownList ID="ddl_checker" runat="server" Width="200px">
                                        </asp:DropDownList>--%>
                                          <telerik:RadComboBox ID="ddl_checker" runat="server" filter="Contains"></telerik:RadComboBox>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Selecting AllowRowSelect="true"></Selecting>
                    </ClientSettings>
                </telerik:RadGrid>
             

                <%--<telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="10" AllowMultiRowSelection="true">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                    <Columns>
                                                        <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1">
                                                        </telerik:GridClientSelectColumn>
                                                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                                            HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                         <telerik:GridBoundColumn DataField="iowa" FilterControlAltText="Filter iowa column"
                                                            HeaderText="iowa" SortExpression="iowa" UniqueName="iowa">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="cas_number" FilterControlAltText="Filter cas_number column"
                                                            HeaderText="CAS NO." SortExpression="cas_number" UniqueName="cas_number">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                                                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column"
                                                            HeaderText="iowacd" SortExpression="iowacd" UniqueName="iowacd">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="runno" FilterControlAltText="Filter runno column"
                                                            HeaderText="runno" SortExpression="runno" UniqueName="runno">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="salt" FilterControlAltText="Filter salt column"
                                                            HeaderText="salt" SortExpression="salt" UniqueName="salt">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="syn" FilterControlAltText="Filter syn column"
                                                            HeaderText="syn" SortExpression="syn" UniqueName="syn">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="aori" FilterControlAltText="Filter aori column"
                                                            HeaderText="aori" SortExpression="aori" UniqueName="aori">
                                                        </telerik:GridBoundColumn>
<telerik:GridTemplateColumn UniqueName="skill" HeaderText="ประเมินด้าน">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="rcb_skill" runat="server" filter="Contains"></telerik:RadComboBox>
                                        <asp:Label ID="lbl_skill" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="true"></Selecting>
                                                </ClientSettings>
                                            </telerik:RadGrid>--%>
            </td>
        </tr>
    </table>
    </div>
     <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เพิ่มข้อมูล<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
     <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    แก้ไขข้อมูล
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
