<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_Receive_Money_V3_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Receive_Money_V3_Insert" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.8.2.js"></script>

    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../Scripts/jquery.blockUI.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             showdate($("#ctl00_ContentPlaceHolder1_txt_MONEY_RECEIVE_DATE"));
             showdate($("#ctl00_ContentPlaceHolder1_txt_checkdate"));
             $("#ctl00_ContentPlaceHolder1_ddl_Income").searchable();
             $("#ctl00_ContentPlaceHolder1_ddl_money_type").searchable();
             $("#ctl00_ContentPlaceHolder1_ddl_bank").searchable();
             
         });

        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body" style="width: 100%;">
        <table class="table">
            <tr>
                <td align="right" width="12%">วันที่ใบเสร็จ :
                </td>
                <td>
                    <asp:TextBox ID="txt_MONEY_RECEIVE_DATE" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td align="right" colspan="2">เลขที่ใบสั่งชำระ :
                </td>
                <td colspan="3">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY1" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY2" runat="server" Width="80px"></asp:TextBox>
                                </td>
                        </tr>
                    </table>
                </td>
                <td align="right">เลขที่ใบเสร็จ :
                </td>
                <td>

                    <asp:TextBox ID="txt_FULL_RECEIVE_NUMBER" runat="server" Width="120px" Enabled="false"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td align="right">ประเภทบัญชี :</td>
                <td>
                    <asp:DropDownList ID="ddl_money_type" runat="server" Width="200px" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="2">ประเภทรายได้ :</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddl_Income" runat="server" DataValueField="IDA" DataTextField="INCOME_NAME" AutoPostBack="True" Width="150px">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:CheckBox ID="cb_sinbon" runat="server" Text="เงินสินบน" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="1">60%</asp:ListItem>
                        <asp:ListItem Value="2">80%</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">ได้รับเงินจาก :</td>
                <td colspan="3" >
                    <%--<asp:Label ID="lbl_customer" runat="server" Text="-"></asp:Label>--%>
                    <asp:TextBox ID="txt_FullNAME" runat="server" Width="100%"></asp:TextBox>
                    <%--<asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="lcnsid" DataTextField="fullname" Width="200px" CssClass="input-sm">
                    </asp:DropDownList>--%>
                    <asp:TextBox ID="txt_customer" runat="server" style="display:none;"></asp:TextBox>
                </td>
                <td colspan="4">
                 <table width="100%">
                     <tr>
                         <td>

                             <asp:Label ID="lbl_receiver" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>
                 </table>
                </td>
                <td>
                    <asp:CheckBox ID="cb_IS_CHECK_OUT_PROVINCE" runat="server" Text="เช็คต่างจังหวัด" />
                </td>
            </tr>
            <tr>
                <td align="right">หน่วยงาน :</td>
                <td colspan="7">
                    <%--<asp:TextBox ID="txt_RECEIVE_MONEY_DESCRIPTION" runat="server" Width="100%"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddl_department" runat="server" DataTextField="DEPARTMENT_NAME" DataValueField="DVCD" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CheckBox ID="cb_IS_SEND_TO_BANK" runat="server" Text="นำส่งเข้าธนาคาร" />
                </td>
            </tr>
            <%--<tr>
                <td align="right">สถานะใบเสร็จ :</td>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txt_stat" runat="server" Text="รับเงิน" Width="60px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2" align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="right">&nbsp;</td>
                <td>

                    &nbsp;</td>
            </tr>--%>
            <tr>
                <td align="right">รายการ :</td>
                <td colspan="7">
                    <asp:TextBox ID="txt_description" runat="server" Width="100%" TextMode="MultiLine" Height="150px"></asp:TextBox>
                </td>
                <td>
                    <%--<telerik:RadBarcode runat="server" ID="RadBarcode1" Type="QRCode" Width="400px" Height="405px" style="display:none;"
                OnPreRender="RadBarcode1_PreRender">
                <QRCodeSettings AutoIncreaseVersion="true" />
            </telerik:RadBarcode>--%>
                </td>
            </tr>
            <tr>
                <td align="right">ประเภทรับ :</td>
                <td colspan="2">
                    
                    <asp:DropDownList ID="ddl_receive_type" runat="server">
                        <asp:ListItem Value="1">เงินสด</asp:ListItem>
                        <asp:ListItem Value="2">เช็ค</asp:ListItem>
                        <asp:ListItem Value="3">ดราฟ</asp:ListItem>
                        <asp:ListItem Value="4">แคชเชียร์เช็ค</asp:ListItem>
                        <asp:ListItem Value="5">เงินฝากธนาคาร</asp:ListItem>
                        <asp:ListItem Value="6">บัตรเครดิต</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="3" align="right">
                    เลขที่เช็ค</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_Checknumber" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">สาขา-ธนาคาร</td>
                <td colspan="2">
                    
                    <asp:DropDownList ID="ddl_bank" runat="server" DataValueField="BANK_ID" DataTextField="BANK_NAME">
                       
                    </asp:DropDownList>
                </td>
                <td colspan="3" align="right">
                    วันที่เขียนเช็ค</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_checkdate" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_refresh" runat="server" Text="Button"  style="display:none;"/>
                </td>
                <td colspan="3" align="right">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" style="height: 26px" />
                            </td>
                            <td>
<asp:Button ID="btn_save" runat="server" Text="บันทึก/พิมพ์ใบเสร็จ" OnClientClick="return confirm('ต้องการบันทึกหรือไม่')" />
                            </td>
                        </tr>
                    </table>
                    
                    
                </td>
                <td colspan="2">
                    <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
<asp:Button ID="btn_reset" runat="server" Text="รายการใหม่"/>
                            </td>
                        </tr>
                    </table>
                   
                    
                </td>
                <td align="right">&nbsp;</td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียดใบเสร็จ">
                    <%--<table width="100%">
                        <tr>
                            <td>ประเภท </td>
                            <td>
                                <asp:DropDownList ID="ddl_abbr_type" runat="server" DataTextField ="receipt_type" DataValueField="feeabbr" Width="300px" AutoPostBack="True"></asp:DropDownList>
                </td>
                          
                        </tr>
                        <tr>
                            <td>จำนวนเงิน :</td>
                            <td>

                    <telerik:RadNumericTextBox ID="txt_RECEIVE_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>

                &nbsp;บาท</td>
                        </tr>
                        <tr>
                            <td>เงินสินบนรอการจ่าย :</td>
                            <td>
                    <telerik:RadNumericTextBox ID="txt_SINBON_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
                &nbsp;บาท</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btn_add" runat="server" Text="เพิ่มรายละเอียด" />
                            </td>
                        </tr>
                    </table>--%>

                    
                        <telerik:RadGrid ID="rg_receive" runat="server" ShowFooter="true" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">
                    </telerik:RadGrid>
                    </asp:Panel>
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>