<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_Study_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_Study_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style1
    {
        height: 26px;
    }
</style>


<asp:Panel ID="Panel1" runat="server" GroupingText="เบิกค่าใช้จ่าย">
    <table>
    <tr>
    <td align="right" class="auto-style1">วันที่รับเอกสาร :</td>
        <td class="auto-style1">
            <asp:TextBox ID="txt_Bill_RECIEVE_DATE" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
           <%-- <telerik:RadDatePicker ID="rdp_DOC_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_DOC_DATE" runat="server" ></asp:TextBox>
        </td>
    </tr>
   
<%--  <tr>
        <td align="right" >&nbsp;<asp:Label ID="lb_paylist" runat="server" Text="ค่าใช้จ่าย :" ></asp:Label>
        </td>
        <td >

           <telerik:RadComboBox ID="rcb_budget" Runat="server" Width="300px" Height="300px" 
                    EmptyMessage="เลือกงบประมาณ" AllowCustomText="true" >
                        <Items>
                            <telerik:RadComboBoxItem Text="" />
                        </Items>
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView ID="rtv_bg_plan" runat="server" 
                                 OnClientNodeClicking="OnClientNodeClickingHandler">
                             </telerik:RadTreeView>
                        </div>
                    </ItemTemplate>
                </telerik:RadComboBox>

             
        </td>
    </tr>--%>
       <%-- <tr>
            <td align="right">เดือนที่เบิก : </td>
            <td>
                <asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="1">มกราคม</asp:ListItem>
                    <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                    <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                    <asp:ListItem Value="4">เมษายน</asp:ListItem>
                    <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                    <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                    <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                    <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                    <asp:ListItem Value="9">กันยายน</asp:ListItem>
                    <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                    <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                    <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                </asp:DropDownList>
                &nbsp;</td>
        </tr>--%>
        <tr>
            <td align="right">ชื่อ - นามสกุล :</td>
            <td><%--<asp:DropDownList ID="dl_User" runat="server" AutoPostBack="True">
                </asp:DropDownList>--%>
                <asp:DropDownList ID="dd_CUSTOMER" Width="80%" runat="server" DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">เบิกเพื่อใคร :</td>
            <td> 
                     <asp:TextBox ID="txt_For" runat="server"  Width="200px" ></asp:TextBox>

            </td>
        </tr>
            <tr>
            <td align="right">ภาคเรียนที่ :</td>
            <td> 
                     <asp:TextBox ID="txt_Semester" runat="server"  Width="80px" ></asp:TextBox>

            </td>
        </tr>
              <tr>
            <td align="right">ปีการศึกษาที่ :</td>
            <td> 
                     <asp:TextBox ID="txt_YearStudy" runat="server"  Width="80px" ></asp:TextBox>

            </td>
        </tr>
    <tr>
        <td align="right">รายการ : </td>
        <td>
                <asp:DropDownList ID="ddl_GL" runat="server"  Width="80%" DataTextField="GL_NAME" DataValueField="IDA">
                </asp:DropDownList>
       <%--     <asp:TextBox ID="txt_DESCRIPTION" runat="server" Height="40px" Width="200px" ></asp:TextBox>--%>

        </td>
    </tr>
       <tr>
        <td align="right">จำนวนเงินที่เบิก : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
  
</table>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server" GroupingText="บันทึกรับเรื่อง" style="display:none">
    <table >
    <tr>
        <td align="right">เลขที่เบิก : </td>
        <td><asp:TextBox ID="txt_BILL_NUMBER" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เบิก : </td>
        <td>
          <%--  <telerik:RadDatePicker ID="rdp_BILL_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_BILL_DATE" runat="server" ></asp:TextBox>

        </td>
    </tr>
</table>

</asp:Panel>

