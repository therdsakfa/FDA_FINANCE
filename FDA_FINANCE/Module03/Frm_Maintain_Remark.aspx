<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_Remark.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Remark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เหตุผลที่ยกเลิก</h1>
            </div>
            <div class="panel-body">
                <asp:TextBox ID="TextBox1" runat="server" Width="100%" TextMode="MultiLine" Height="311px"></asp:TextBox>


            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="confirm('ต้องการบันทึกหรือไม่');" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
