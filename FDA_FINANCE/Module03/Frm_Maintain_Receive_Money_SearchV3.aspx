<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_Receive_Money_SearchV3.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Receive_Money_SearchV3" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <td align="right">เลขที่ใบสั่งชำระ :
                </td>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY1" runat="server" Width="90px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY2" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;*(10001/59)</td>
                        </tr>
                    </table>
                </td>
                <td align="right">เลขที่ใบเสร็จ :
                </td>
                <td>

                    <asp:TextBox ID="txt_FULL_RECEIVE_NUMBER" runat="server" Width="120px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td align="right">ประเภทบัญชี :</td>
                <td>
                    <asp:DropDownList ID="ddl_money_type" runat="server" Width="200px" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID">
                    </asp:DropDownList>
                </td>
                <td align="right">ประเภทรายได้ :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddl_Income" runat="server" DataValueField="IDA" DataTextField="INCOME_NAME">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:CheckBox ID="cb_sinbon" runat="server" Text="เงินสินบน" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>ไม่มีข้อมูล</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">ได้รับเงินจาก :</td>
                <td >
                    <asp:Label ID="lbl_customer" runat="server" Text="-"></asp:Label>
                    <%--<asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="lcnsid" DataTextField="fullname" Width="200px" CssClass="input-sm">
                    </asp:DropDownList>--%>
                </td>
                <td align="right">ประเภทรับ :</td>
                <td colspan="3">
                    <asp:RadioButtonList ID="rbl_RECEIVE_MONEY_TYPE" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
                <asp:ListItem Value="3">โอน</asp:ListItem>
            </asp:RadioButtonList>
                </td>
                <td>
                    <asp:CheckBox ID="cb_IS_CHECK_OUT_PROVINCE" runat="server" Text="เช็คต่างจังหวัด" />
                </td>
            </tr>
            <tr>
                <td align="right">หน่วยงาน :</td>
                <td colspan="5">
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
                <td colspan="5">
                    <asp:TextBox ID="txt_description" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_refresh" runat="server" Text="Button"  style="display:none;"/>
                </td>
                <td colspan="2" align="right">
                    <asp:Button ID="btn_save" runat="server" Text="บันทึกใบเสร็จ"  />
                </td>
                <td>
                    <asp:Button ID="btn_print" runat="server" Text="พิมพ์ใบเสร็จ" style="display:none;" />
                    <asp:Button ID="btn_reset" runat="server" Text="รายการใหม่" style="display:none;"/>
                </td>
                <td align="right">&nbsp;</td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">
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

                    
                        <telerik:RadGrid ID="rg_receipt_det" runat="server" ShowFooter="true" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">
                    </telerik:RadGrid>
                    </asp:Panel>
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>