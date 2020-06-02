function load_tollbar() {
    $('table[title="Print"]').hide();
    $('#<%=ReportViewer1.ClientID%>_ctl05:last-child').children().append('<div class=" " style="display:inline-block;font-family:Verdana;font-size:8pt;vertical-align:top;"><table cellpadding="0" cellspacing="0" style="display:inline;"><tbody><tr><td height="28px"><select name="ddlClientPrinters" id="ddlClientPrinters" style="font-family:Verdana;font-size:8pt;" title="Select Printer"><option>Loading printers...</option></select></td><td width="4px"></td><td height="28px"><div><div id="<%=ReportViewer1.ClientID%>_Custom_Print_Button" style="border: 1px solid transparent; background-color: transparent; cursor: default;"><table title="Print"><tbody><tr><td><input type="image" title="Print" src="Reserved.ReportViewerWebControl.axd?OpType=Resource&Name=Microsoft.Reporting.WebForms.Icons.Print.gif" alt="Refresh" style="border-style:None;height:16px;width:16px;border-width:0px;"></td></tr></tbody></table></div></div></td></tr></tbody></table></div>');
    $('#<%=ReportViewer1.ClientID%>_Custom_Print_Button').hover(function () { //hover style
        $(this).css({ 'border': '1px solid #336699', 'background-color': '#DDEEF7', 'cursor': 'pointer' });
    }, function () { //normal style
        $(this).css({ 'border': '1px solid transparent', 'background-color': 'transparent', 'cursor': 'default' })
    });
   
    var wcppGetPrintersDelay_ms = 5000; //5 sec

    function wcpGetPrintersOnSuccess() {
        if (arguments[0].length > 0) {
            var p = arguments[0].split("|");
            var options = '<option>Default Printer</option>';
            for (var i = 0; i < p.length; i++) {
                options += '<option>' + p[i] + '</option>';
            }
            $('#ddlClientPrinters').html(options);
        } else {
            alert("No printers are installed in your system.");
        }
    }

    function wcpGetPrintersOnFailure() {
        alert("No printers are installed in your system.");
    }
}