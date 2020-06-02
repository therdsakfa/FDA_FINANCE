<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table style="border:1px solid black;" width="100%">
    
<tr>
        <td align="right">ประเภทการจ่าย : </td>
        <td>
           
            <asp:DropDownList ID="ddl_MAS_RETURN_TYPE" runat="server" DataTextField="RETURN_TYPE_NAME" 
                DataValueField="RETURN_TYPE_ID" AutoPostBack="true">
            </asp:DropDownList>
           
        </td>
        <td align="right">&nbsp;</td>
        <td>
           <%-- <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>--%>
            <asp:Button ID="btn_print" runat="server" Text="พิมพ์ใบเสร็จ" style="display:none;" />
        </td>
    </tr>
    <tr>
    <td align="right">วันที่คืนเงิน : </td>
        <td>
            <asp:TextBox ID="txt_return_date" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
        <td align="right">
            <asp:Label ID="lb_pay_type_chg" runat="server" style="display:none;"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_running_number" runat="server" style="display:none;"></asp:TextBox>
            <asp:TextBox ID="txt_today_date" runat="server" style="display:none;"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td align="right">วันที่เอกสารส่งใช้หนี้ : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_DOC_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_DOC_DATE" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
        <td align="right">เลขที่เอกสารส่งใช้หนี้ : </td>
        <td>
        <asp:TextBox ID="txt_DOC_NUMBER" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">บ. เล่มที่ : </td>
        <td>
            <asp:TextBox ID="txt_DISBURSE_VOLUME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
        <td align="right">บ. เลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_DISBURSE_NUMBER" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right"> รายละเอียดการคืน :</td>
        <td colspan="3">
            <%--<telerik:RadComboBox ID="rcb_MAS_RETURN_DESCRIPTION" Runat="server" Width="300px"
                 AllowCustomText="true" DataTextField="RETURN_DESCRIPTION" DataValueField="RETURN_DESCRIPTION_ID">
            </telerik:RadComboBox>--%>

            <asp:TextBox ID="txt_RETURN_DESCRIPTION1" runat="server" Width="300px"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td align="right">&nbsp;</td>
        <td colspan="3">
            <asp:TextBox ID="txt_RETURN_DESCRIPTION" runat="server"   Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงินที่คืน : </td>
        <td>
            <%--<asp:TextBox ID="txt_RETURN_AMOUNT" runat="server"></asp:TextBox>--%>
            <telerik:RadNumericTextBox ID="txt_RETURN_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px" AutoPostBack="true"></telerik:RadNumericTextBox>
            &nbsp; บาท
        </td>
        <td align="right">ชื่อผู้รับเงิน :</td>
        <td>
            <asp:Label ID="lb_money_receiver" runat="server" ></asp:Label>
            <asp:Label ID="lb_money_receiver_id" runat="server" style="display:none;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">ใช้เงินนอกงบประมาณโอนชดใช้ :</td>
        <td>
            <asp:CheckBox ID="cb_IS_USE_OUTBUDGET" runat="server" />
        </td>
        <td align="right">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right">
            จำนวนเปอร์เซ็นการคืนเงิน :</td>
        <td colspan="3">
            <asp:Label ID="lb_percent" runat="server" Text="0.00%"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lb_reason" runat="server" Text="เหตุผลที่คืนเงินสดเกิน 25% :" ></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="txt_Reson" runat="server"   Width="300px" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lb_money_type" runat="server" Text="ประเภทเงิน" style="display:none;"></asp:Label>
           <font size="5" color="red"> <b>จำนวนเงินค้างชำระคืน :</b></font></td>
        <td colspan="3">
            <asp:RadioButtonList ID="rd_moneytype" runat="server" RepeatDirection="Horizontal" style="display:none;">
                <asp:ListItem Value="1">เงินงบประมาณ</asp:ListItem>
                <asp:ListItem Value="2">เงินทดรอง</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="lb_balance" runat="server" style="font-size:22px;color:red;font-weight:700;" ></asp:Label>
&nbsp; <font size="5" color="red"><b>บาท</b></font></td>
    </tr>
</table>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txt_RETURN_AMOUNT">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lb_percent">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
           
        </AjaxSettings>
    </telerik:RadAjaxManager>