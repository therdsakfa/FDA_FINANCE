<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Report_R3_0009-1.ascx.vb" Inherits="FDA_FINANCE.UC_Report_R3_0009_1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="900" style="border:1px solid black;">
    <tr>
        <td align="center" colspan="3">
            รายงานเงินคงเหลือประจำวัน<br />
            ส่วนราชการ กลุ่มคลังและพัสดุ กรมพัฒนาการแพทย์แผนไทยและการแพทย์ทางเลือก จังหวัดนนทบุรี<br />
            ประจำวันที่
            <asp:Label ID="lbl_dateselect" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:300px" align="center">รายการ</td>
        <td style="width:300px" align="center">จำนวนเงิน</td>
        <td style="width:300px" align="center">หมายเหตุ</td>
    </tr>
    
    <tr>
        <td>ธนบัตร</td>
        <td align="right">
            <asp:TextBox ID="moneybank" runat="server"></asp:TextBox> บาท
        </td>
        <td></td>
    </tr>
    <tr>
        <td>เหรียญกษาปณ์</td>
        <td align="right">
            <asp:TextBox ID="moneycoin" runat="server"></asp:TextBox> บาท
        </td>
        <td>เงินทดรอง 
            <asp:Label ID="lbl_marginamount" runat="server" Text=""></asp:Label> บาท
        </td>
    </tr>
    <tr>
        <td>เช็ค <asp:TextBox ID="checkcount" runat="server"></asp:TextBox> ฉบับ </td>
        <td align="right">
            <asp:TextBox ID="moneycheck" runat="server"></asp:TextBox> บาท
        </td>
        <td></td>
    </tr>
    <tr>
        <td>รวมทั้งสิ้น</td>
        <td align="right"><asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label></td>
        <td align="left"> บาท</td>
    </tr>

    <tr>
        <td>ธนาคาร <asp:TextBox ID="bank1" runat="server"></asp:TextBox></td>
        <td>จำนวนเงิน <asp:Label ID="lbl_moneytext" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>ธนาคาร <asp:TextBox ID="bank2" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>ธนาคาร <asp:TextBox ID="bank3" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td></td>
        <td colspan="2">ลงชื่อ......................................................เจ้าหน้าที่การเงิน</td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2">
            <%--<asp:DropDownList ID="dl_usermoney" runat="server" DataTextField="name" DataValueField="ID" AutoPostBack="true"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_usermoney" runat="server" Width="280px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2">
            <asp:TextBox ID="usermoneyposition" runat="server" Width="280px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td></td>
        <td colspan="2">ลงชื่อ......................................................หัวหน้ากลุ่มงานคลังและพัสดุ</td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2">            
            <%--<asp:DropDownList ID="dl_userstore" runat="server" DataTextField="name" DataValueField="ID" AutoPostBack="true"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_userstore" runat="server" Width="280px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2">
            <asp:TextBox ID="userstoreposition" runat="server" Width="280px"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td colspan="3" align="center">คณะกรรมการการเก็บรักษาเงินได้ตรวจนับเงินและหลักฐานแทนตัวเงินถูกต้องตามรายการข้างต้นแล้ว จึงได้นำเงินเข้าเก็บรักษาในตู้นิรภัย</td>
    </tr>

    <tr>
        <td colspan="3"></td>
    </tr>

    <tr>
        <td>.............................................. กรรมการ</td>
        <td>.............................................. กรรมการ</td>
        <td>.............................................. กรรมการ</td>
    </tr>

    <tr>
        <td>
            <%--<asp:DropDownList ID="dl_boardname1" runat="server" DataTextField="name" DataValueField="ID" AutoPostBack="true"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_boardname1" runat="server" Width="280px"></asp:TextBox>
        </td>
        <td>
            <%--<asp:DropDownList ID="dl_boardname2" runat="server" DataTextField="name" DataValueField="ID" AutoPostBack="true"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_boardname2" runat="server" Width="280px"></asp:TextBox>
        </td>
        <td>
            <%--<asp:DropDownList ID="dl_boardname3" runat="server" DataTextField="name" DataValueField="ID" AutoPostBack="true"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_boardname3" runat="server" Width="280px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID="boardposition1" runat="server" Width="280px"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="boardposition2" runat="server" Width="280px"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="boardposition3" runat="server" Width="280px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td colspan="3"></td>
    </tr>

    <tr>
        <td colspan="3">เรียน อธิบดีกรมพัฒนาการแพทย์แผนไทยและการแพทย์ทางเลือก</td>
    </tr>

    <tr>
        <td colspan="3">เพื่อโปรดทราบตามที่คณะกรรมการเสนอ จะเป็นพระคุณ</td>
    </tr>

    <tr>
        <td></td>
        <td colspan="2" align="center">ทราบ</td>
    </tr>

    <tr>
        <td></td>
        <td colspan="2" align="center">อธิบดีกรมพัฒนาการแพทย์แผนไทยและการแพทย์ทางเลือก</td>
    </tr>

    <tr>
        <td></td>
    </tr>

    <tr>
        <td>ข้าพเจ้าได้รับเงินและเอกสารแทนตัวเงิน ตามรายละเอียดข้างต้นนี้ไปแล้ว</td>
    </tr>

    <tr>
        <td>เมื่อวันที่ <asp:Label ID="lbl_dateselect_2" runat="server" Text=""></asp:Label>
        </td>
    </tr>

    <tr>
        <td colspan="3" align="right">ลงชื่อ ................................................................................ เจ้าหน้าที่การเงิน</td>
    </tr>

</table>