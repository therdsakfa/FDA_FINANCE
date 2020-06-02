<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Salary_List2.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_List2" %>
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

          //$(document).ready(function () {
          //    // ชื่อ iframe
          //    $('#ctl00_ContentPlaceHolder1_btn_copy').click(function () {
          //        var d_insert = $("#dialog_insert"); // ชื่อ iframe      
          //        //กำหนดขนาด iframe
          //        d_insert.dialog({
          //            autoOpen: true,
          //            height: 700,
          //            width: 1000,
          //            modal: true
          //        });
          //        var bgYear = getQuerystring('myear');
          //        Popups('Frm_Import_Salary.aspx?bgYear=' + bgYear.toString());

          //        return false;
          //    });
          //});
          function Popups2(url) { // สำหรับทำ Div Popup

              $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f2'); // ID ของ iframe   
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
              //document.getElementById("ContentPlaceHolder1_btnRedirect").click();
              $('#ctl00_ContentPlaceHolder1_btnRedirect').click();
          }
        </script> 

    
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .btn-lg {}
    </style>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <table width="60%" align="center">
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbinformation" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">

                <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" style="display:none;" />
                
               
            </td>
        </tr>
        <tr>
            <td>


                <telerik:RadGrid ID="rg_salary_list" runat="server" AutoGenerateColumns="false" GridLines="None">
                    <MasterTableView>
                        <Columns>

                            <telerik:GridBoundColumn DataField="SALARY_PAYLIST_ID" Display="false" HeaderText="SALARY_PAYLIST_ID" UniqueName="SALARY_PAYLIST_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SALARY_PAYLIST_NAME" HeaderText="ชื่อรายรับรายจ่าย" UniqueName="SALARY_PAYLIST_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REVENUE_TYPE2" HeaderText="ประเภท" UniqueName="REVENUE_TYPE2">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="จำนวนเงิน" UniqueName="rnt_money">
                                <ItemTemplate>
                                    <telerik:RadNumericTextBox ID="rnt_money" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>


            </td>
        </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
        <tr>
            <td class="auto-style1" align="center">


<asp:Button ID="btn_Add" runat="server" Text="บันทึก" CssClass="btn-lg"  Height="30px" Width="80px"/>
 &nbsp;
 <asp:Button ID="btn_close" runat="server" Text="ย้อนกลับ" CssClass="btn-lg" Height="30px" Width="80px"/>


            </td>
        </tr>
        </table>

</asp:Content>