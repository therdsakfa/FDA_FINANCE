<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Salary_List.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_List" %>
<%@ Register src="UC/UC_Salary_Paylist.ascx" tagname="UC_Salary_Paylist" tagprefix="uc1" %>
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

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <table>
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
                <table>
    <tr>
        <td align="right">รายรับ/รายจ่าย :</td>
        <td>
            <asp:DropDownList ID="ddlSALARY_PAYLIST" runat="server" DataTextField="SALARY_PAYLIST_NAME"
                DataValueField="SALARY_PAYLIST_ID"></asp:DropDownList></td>

        <td align="right">จำนวนเงิน :</td>
        <td>
            <telerik:radnumerictextbox ID="rntAmount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:radnumerictextbox> &nbsp; บาท
        </td>
        <td>
<asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg"/>
        </td>
        <td>
 <asp:Button ID="btn_close" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"/>
        </td>
    </tr>   
</table>
                <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" style="display:none;" />
                
               
            </td>
        </tr>
        <tr>
            <td>

                <uc1:UC_Salary_Paylist ID="UC_Salary_Paylist1" runat="server" />

            </td>
        </tr>
        </table>
    
    <%--<div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>--%>
</asp:Content>