<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="FDA_FINANCE.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function MoneyToWord() {
            
        }

        MoneyToWord.execute = function (money) {
            var result = '';
            var minus = '';

            if (money < 0) {
                minus = 'ติดลบ';
                money = money * -1;
            }

            money = parseFloat(Math.round(money * 100) / 100).toFixed(2);

            if (money == '0.00') {
                result = 'ศูนย์บาทถ้วน';
                return result;
            }

            var numbers = ['', 'หนึ่ง', 'สอง', 'สาม', 'สี่', 'ห้า', 'หก', 'เจ็ด', 'แปด', 'เก้า'];
            var positions = ['', 'สิบ', 'ร้อย', 'พัน', 'หมื่น', 'แสน'];

            var digit = money.length;
            var inputs = [];

            if (digit <= 15) {
                if (digit > 9) {
                    inputs[0] = money.substr(0, digit - 9);
                    inputs[1] = money.substr(inputs[0].length, 6);
                } else {
                    inputs[0] = '00';
                    inputs[1] = money.substr(0, money.length - 3);
                }
                inputs[2] = money.substr(money.indexOf('.') + 1, 2);
            } else {
                result = 'Error: ไม่สามารถรองรับจำนวนเงินที่เกินหลักแสนล้าน';
                return result;
            }

            for (i = 0; i < 3; i++) {
                var input = inputs[i];

                if (input != '0' && input != '00') {
                    var digit = input.length;

                    for (j = 0; j < digit; j++) {
                        var s = input.substr(j, 1);
                        var number = numbers[s];
                        var position = '';

                        if (number != '') {
                            position = positions[digit - (j + 1)];
                        }

                        if ((digit - j) == 2) {
                            if (s == '1') {
                                number = '';
                            } else if (s == '2') {
                                number = 'ยี่';
                            }
                        } else if ((digit - j) == 1 && (digit != 1)) {
                            var pre_s = '0';
                            if (j > 0) {
                                pre_s = input.substr(j - 1, 1);
                            }

                            if (i == 0) {
                                if (pre_s != '0') {
                                    if (s == '1') {
                                        number = 'เอ็ด';
                                    }
                                }
                            } else {
                                if (s == '1') {
                                    number = 'เอ็ด';
                                }
                            }
                        }

                        result = result + number + position;
                    }
                }

                if (i == 0) {
                    if (input != '00') {
                        result = result + 'ล้าน';
                    }
                } else if (i == 1) {
                    if (input != '0' && input != '00') {
                        result = result + 'บาท';
                        if (inputs[2] == '00') {
                            result = result + 'ถ้วน';
                        }
                    }
                } else {
                    if (input != '00') {
                        result = result + 'สตางค์';
                    }
                }
            }
            alert(minus + result);
            //return minus + result;
        }

        function get_text() {
            var txt = document.getElementById("TextBox1").value;
            alert(ThaiBaht(txt));
        }

        function roundToTwo(num) {
            return +(Math.round(num + "e+2") + "e-2");
        }

        function ThaiBaht(Number) {
            for (var i = 0; i < Number.length; i++) {
                Number = Number.replace(",", ""); //ไม่ต้องการเครื่องหมายคอมมาร์
                Number = Number.replace(" ", ""); //ไม่ต้องการช่องว่าง
                Number = Number.replace("บาท", ""); //ไม่ต้องการตัวหนังสือ บาท
                Number = Number.replace("฿", ""); //ไม่ต้องการสัญลักษณ์สกุลเงินบาท
            }
            //สร้างอะเรย์เก็บค่าที่ต้องการใช้เอาไว้
            var TxtNumArr = new Array("ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ");
            var TxtDigitArr = new Array("", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน");
            var BahtText = "";
            //ตรวจสอบดูซะหน่อยว่าใช่ตัวเลขที่ถูกต้องหรือเปล่า ด้วย isNaN == true ถ้าเป็นข้อความ == false ถ้าเป็นตัวเลข
            if (isNaN(Number)) {
                return "ข้อมูลนำเข้าไม่ถูกต้อง";
            } else {
                //ตรวสอบอีกสักครั้งว่าตัวเลขมากเกินความต้องการหรือเปล่า
                if ((Number - 0) > 9999999.99) {
                    return "ข้อมูลนำเข้าเกินขอบเขตที่ตั้งไว้";
                } else {
                    //พรากทศนิยม กับจำนวนเต็มออกจากกัน (บาปหรือเปล่าหนอเรา พรากคู่เขา)
                    Number = Number.split(".");

                    //นับ array ถ้ามีเกิน 1 ช่อง แสดงว่ามีหลักทศนิยม
                    var i;
                    var j = 0;
                    for (i = 0 ; i < Number.length ; i++) {
                        if (Number[i].length > 0) {
                            j = j + 1;
                        }
                    }


                    //ตรวจว่ามีทศนิยมมั้ย
                    if (j == 1) {
                        //หลักเลข
                        var NumberLen = Number[0].length - 0;
                        //                    
                        for (var i = 0; i < NumberLen; i++) {
                            var tmp = Number[0].substring(i, i + 1) - 0;
                            if (tmp != 0) {
                                if ((i == (NumberLen - 1)) && (tmp == 1)) {
                                    BahtText += "เอ็ด";
                                } else
                                    if ((i == (NumberLen - 2)) && (tmp == 2)) {
                                        BahtText += "ยี่";
                                    } else
                                        if ((i == (NumberLen - 2)) && (tmp == 1)) {
                                            BahtText += "";
                                        } else {
                                            BahtText += TxtNumArr[tmp];
                                        }
                                BahtText += TxtDigitArr[NumberLen - i - 1];
                            }
                        }
                        BahtText += "บาทถ้วน";
                        return BahtText;

                    } else {
                        //ขั้นตอนต่อไปนี้เป็นการประมวลผลดูกันเอาเองครับ แบบว่าขี้เกียจจะจิ้มดีดแล้ว อิอิอิ
                        if (Number[1].length > 0) {
                            Number[1] = Number[1].substring(0, 2);
                        }
                        //หลักเลข
                        var NumberLen = Number[0].length - 0;
                        //                    
                        for (var i = 0; i < NumberLen; i++) {
                            var tmp = Number[0].substring(i, i + 1) - 0;
                            if (tmp != 0) {
                                if ((i == (NumberLen - 1)) && (tmp == 1)) {
                                    BahtText += "เอ็ด";
                                } else
                                    if ((i == (NumberLen - 2)) && (tmp == 2)) {
                                        BahtText += "ยี่";
                                    } else
                                        if ((i == (NumberLen - 2)) && (tmp == 1)) {
                                            BahtText += "";
                                        } else {
                                            BahtText += TxtNumArr[tmp];
                                        }
                                BahtText += TxtDigitArr[NumberLen - i - 1];
                            }
                        }
                        BahtText += "บาท";

                        if ((Number[1] == "0") || (Number[1] == "00")) {
                            BahtText += "ถ้วน";
                        } else {
                            DecimalLen = Number[1].length - 0;
                            for (var i = 0; i < DecimalLen; i++) {
                                var tmp = Number[1].substring(i, i + 1) - 0;
                                if (tmp != 0) {
                                    if ((i == (DecimalLen - 1)) && (tmp == 1)) {
                                        BahtText += "เอ็ด";
                                    } else
                                        if ((i == (DecimalLen - 2)) && (tmp == 2)) {
                                            BahtText += "ยี่";
                                        } else
                                            if ((i == (DecimalLen - 2)) && (tmp == 1)) {
                                                BahtText += "";
                                            } else {
                                                BahtText += TxtNumArr[tmp];
                                            }
                                    BahtText += TxtDigitArr[DecimalLen - i - 1];
                                }
                            }
                            BahtText += "สตางค์";
                        }

                        return BahtText;
                    }
                }
            }
            
        }
function display(){
    var result;
    result = num2text(document.getElementById('TextBox1').value);
    document.getElementById('Label1').innerHTML = result;
}

        function num2text(num){
            var nlength = num.length;
            var text='';
            //ตัวเลข
            var text_array = new Array();
            text_array['1'] = 'หนึ่ง';
            text_array['2'] = 'สอง';
            text_array['3'] = 'สาม';
            text_array['4'] ='สี่';
            text_array['5'] = 'ห้า';
            text_array['6'] = 'หก';
            text_array['7'] = 'เจ็ด'
            text_array['8'] = 'แปด';
            text_array['9'] = 'เก้า';
            text_array['0'] = 'ศูนย์';

            //หลักพิเศษ
            stext_array = new Array();
            stext_array['1'] = 'เอ็ด';
            stext_array['2'] = 'ยี่';

            // หน่วย
            unit = new Array();
            unit['1'] = '';
            unit['2'] = 'สิบ';
            unit['3'] = 'ร้อย';
            unit['4'] = 'พัน';
            unit['5'] = 'หมื่น';
            unit['6'] = 'แสน';
            unit['7'] = 'ล้าน';

            // วนลูปตามความยาวตัวเลข
            for (i=1,j=nlength ; i <= nlength ; i++,j--){

                // ถ้าเป็น 0 ไม่นับ ให้ข้ามไปเลย
                if (num.charAt(i-1) == 0) continue;

                // เช็ค ยี่ กับเช็ค เอ็ด ถ้าไม่ใช่ ให้ไปธรรมดาปกติ
                if ( (j == 2 && num.charAt(i-1) == 2) || (j == 1 && num.charAt(i-1) == 1) ){
                    text += stext_array[num.charAt(i-1)]+unit[j];
                }

                    //ธรรมดา ปกติ
                else{

                    //เช็คว่าถ้าหลักสิบเป็นเลข 1 ก็ไม่ต้องบอกว่า หนึ่งสิบ ให้กลายเป็น สิบ ด้วน ๆ
                    if (j == 2 && num.charAt(i-1) == 1)
                        text += unit[j];
                    else

                        // อันนี้ปกติ
                        text += text_array[num.charAt(i-1)]+unit[j];
                }
      
            }

            text += 'บาทถ้วน';
            return text;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="get_text(); return false;"/>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
    </form>
</body>
</html>
