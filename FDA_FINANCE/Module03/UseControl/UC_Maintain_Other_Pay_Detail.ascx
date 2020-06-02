<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_Other_Pay_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_Other_Pay_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style1
    {
        height: 26px;
    }
</style>
<table style="border:1px solid black;" width="900px">
    <tr>
        <td align="right">วันที่ทำรายการ : </td>
        <td>
            <asp:TextBox ID="txt_DO_DATE" runat="server"></asp:TextBox>
        </td>
       
    </tr>
    <tr>
         <td align="right">ประเภท : </td>
        <td>
            <asp:RadioButtonList ID="rdl_Type" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">รับ</asp:ListItem>
                <asp:ListItem Value="2">จ่าย</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียด : </td>
        <td>
            
            <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine" Width="300px" Height="70px"></asp:TextBox>
            
        </td>
        
    </tr>
       <tr>
        <td align="right">จำนวนเงิน :&nbsp;</td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_Amount" Runat="server">
            </telerik:RadNumericTextBox>
        </td>
        
    </tr>

       <tr>
       <td align="right">ชื่อผู้รับเงิน:</td>
        <td>
            <asp:TextBox ID="txt_NAME_IN_CHECK" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่เช็ค :</td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td align="right">วันที่ทำเช็ค:</td>
        <td>
            <asp:TextBox ID="txt_CHECK_DATE" runat="server"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td align="right">รับเช็ค :</td>
        <td>
            <asp:CheckBox ID="cb_CHECK_APPROVE" runat="server" />
        </td>

    </tr>
    <tr>
        <td align="right">วันที่รับเช็ค :</td>
        <td>
            <asp:TextBox ID="txt_CHECK_APPROVE_DATE" runat="server"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td align="right">เช็คพร้อมจ่าย :</td>
        <td>
            <asp:CheckBox ID="cb_IS_CHECK_READY" runat="server" />
        </td>

    </tr>
    <tr>
        <td align="right">วันที่พร้อมจ่าย : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_READY_DATE" runat="server"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td align="right" class="auto-style1">จ่ายเช็ค :</td>
        <td class="auto-style1">
            <asp:CheckBox ID="cb_IS_CHECK_RECEIVE" runat="server" />
        </td>

    </tr>
    <tr>
        <td align="right">วันที่จ่ายเช็ค :</td>
        <td>
            <asp:TextBox ID="txt_CHECK_RECEIVE_DATE" runat="server"></asp:TextBox>
        </td>

    </tr>
    </table>