<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Person_In_Report_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Person_In_Report_Detail" %>
<table>
    <tr>
        <td align="right">ชื่อ-นามสกุล : </td>
        <td>
            <asp:TextBox ID="txt_R_NAME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ประเภทผู้ตรวจสอบ : </td>
        <td>
            <asp:DropDownList ID="ddl_R_TYPE" runat="server" DataTextField="R_TYPE_PERSON_NAME" DataValueField="R_TYPE_ID"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">การใช้งาน : </td>
        <td>
            <asp:CheckBox ID="cb_IS_USE" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">ใช้ในรายงานอื่น :</td>
        <td>
            <asp:CheckBox ID="cb_IS_NORMAL" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">ใช้ในรายงานมูลนิธิ :&nbsp;</td>
        <td>
            <asp:CheckBox ID="cb_IS_FOUNDATION" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">ใช้ในรายงานเงินสปสช. :&nbsp;</td>
        <td>
            <asp:CheckBox ID="cb_IS_SPSC" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">ใช้ในรายงานเงิน สสส. : </td>
        <td>
            <asp:CheckBox ID="cb_IS_SSS" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">ใช้ในรายงานสวัสดิการ :&nbsp;</td>
        <td>
            <asp:CheckBox ID="cb_is_benefit" runat="server" />
        </td>
    </tr>
</table>