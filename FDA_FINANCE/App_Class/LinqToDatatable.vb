Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports System.Reflection
Public Module DataSetLinqOperators


    Public Function NameUserAD() As String
        Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
        Dim strWindowName As String = p.Identity.Name
        Dim strScript As String = ""
        Dim ADNAME As String = ""
        If strWindowName.Trim() <> "" Then
            Dim arrWindowName As String() = strWindowName.Split("\")
            '   strDomainName = arrWindowName(0).ToString()
            ADNAME = arrWindowName(1).ToString()
        End If
        'Dim dao_user As New DAO_USER.TB_tbl_USER
        'dao_user.Getdata_by_AD_NAME(ADNAME)
        'If dao_user.fields.PERMISSION_ID Is Nothing Or dao_user.fields.PERMISSION_ID = 0 Then
        '    HttpContext.Current.Response.Write("<script language=javascript>")
        '    HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
        '    HttpContext.Current.Response.Write("window.location='www.google.co.th';")
        '    HttpContext.Current.Response.Write("</script>")
        'Else
        '    Return ADNAME
        'End If
        Return ADNAME

    End Function
    <System.Runtime.CompilerServices.Extension> _
    Sub Insert_log_error(ByVal ref01 As String, ByVal ref02 As String, ByVal error_str As String, ByVal IDA As Integer)
        Dim dao_logs As New DAO_MAS.TB_LOG_RECEIPT_ERROR
        dao_logs.fields.CREATEDATE = Date.Now
        dao_logs.fields.REF01 = ref01
        dao_logs.fields.REF02 = ref02
        dao_logs.fields.ERROR_MSG = error_str
        dao_logs.fields.FK_IDA = IDA
        dao_logs.insert()
    End Sub
    <System.Runtime.CompilerServices.Extension> _
    Sub Insert_H2H_Error(ByVal ref01 As String, ByVal ref02 As String, ByVal xmlname As String, ByVal error_str As String, _
                        ByVal account_id As String, ByVal status_id As Integer)
        Dim dao_logs As New DAO_FEE.TB_FEE_LOGS
        dao_logs.fields.CREATEDATE = Date.Now
        dao_logs.fields.ref1 = ref01
        dao_logs.fields.ref2 = ref02
        dao_logs.fields.STEP = 0
        dao_logs.fields.RESULT = error_str & " (ออกที่คลัง)"
        dao_logs.fields.XML_PATH = xmlname
        dao_logs.fields.ACCOUNT_ID = account_id
        dao_logs.fields.STATUS_ID = status_id
        dao_logs.insert()

        Dim dao_log_h2h As New DAO_MAS.TB_LOG_H2H_ERROR
        dao_log_h2h.fields.create_date = Date.Now
        dao_log_h2h.fields.error_msg = error_str & " (ออกที่คลัง)"
        dao_log_h2h.fields.ref01 = ref01
        dao_log_h2h.fields.ref02 = ref02
        dao_log_h2h.insert()
    End Sub
    'Public Function checkAD() As Boolean
    '    Dim bool As Boolean = False
    '    Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    '    Dim strWindowName As String = p.Identity.Name
    '    Dim strScript As String = ""
    '    Dim ADNAME As String = ""
    '    If strWindowName.Trim() <> "" Then
    '        Dim arrWindowName As String() = strWindowName.Split("\")
    '        '   strDomainName = arrWindowName(0).ToString()
    '        ADNAME = arrWindowName(1).ToString()
    '    Else
    '        bool = False
    '    End If
    '    Dim dao_user As New DAO_USER.TB_tbl_USER
    '    dao_user.Getdata_by_AD_NAME(ADNAME)
    '    If dao_user.fields.PERMISSION_ID Is Nothing Then
    '        'HttpContext.Current.Response.Write("<script language=javascript>")
    '        'HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
    '        'HttpContext.Current.Response.Write("window.location='/budget/Frm_No_Permission.aspx';")
    '        'HttpContext.Current.Response.Write("</script>")
    '        bool = False
    '    Else
    '        bool = True

    '    End If

    '    Return bool
    'End Function
    Function TimeStampNow() As String
        Dim StrTimeStamp As String = ""
        Dim bao As New BAO_BUDGET.MASS
        StrTimeStamp = bao.GET_TIMESTAMP()
        Return StrTimeStamp
    End Function
    <System.Runtime.CompilerServices.Extension> _
    Function con_year(year) As String
        Dim int_year As Integer = Integer.Parse(year)
        If int_year <= 2500 Then
            int_year += 543
        End If
        Return int_year.ToString()
    End Function
    <System.Runtime.CompilerServices.Extension> _
    Function EncodeBase64(ByVal original_txt As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(original_txt)
        Dim strModified As String = ""
        strModified = Convert.ToBase64String(byt)

        Return strModified
    End Function
    <System.Runtime.CompilerServices.Extension> _
    Function DecodeBase64(ByVal Base64Text As String) As String
        Dim ede_byte As Byte() = System.Convert.FromBase64String(Base64Text)
        Dim txt As String = ""
        txt = System.Text.Encoding.UTF8.GetString(ede_byte)
        Return txt
    End Function
    <System.Runtime.CompilerServices.Extension> _
    Public Sub set_dd_bgyear(ByRef ddl As DropDownList)
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        Dim aa As Date = CDate("1/10/" & Year(System.DateTime.Now))
        If CDate(System.DateTime.Now) >= CDate("1/10/" & Year(System.DateTime.Now)) Then
            byearMax = byearMax + 1
        End If

        For i As Integer = 2551 To byearMax
            Dim drNew As DataRow = dt.NewRow()
            drNew("byear") = i

            dt.Rows.Add(drNew)
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "byear desc"
        dt = dv.ToTable()

        ddl.DataSource = dt
        ddl.DataBind()
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable

        Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)

    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As Nullable(Of LoadOption)) As DataTable

        Return New ObjectShredder(Of T)().Shred(source, table, options)

    End Function



    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToCsv(Of T)(ByVal source As IEnumerable(Of T)) As String
        If source Is Nothing Then
            Throw New ArgumentNullException("source")
        End If
        Return String.Join(",", source.[Select](Function(s) s.ToString()).ToArray())
    End Function
    '<System.Runtime.CompilerServices.Extension()> _
    'Public Function ObjectToCsv(Of T)(ByVal source As Object) As String
    '    If source Is Nothing Then
    '        Throw New ArgumentNullException("source")
    '    End If
    '    Return String.Join(",", source.[Select](Function(s) s.ToString()).ToArray())
    'End Function
    
    <System.Runtime.CompilerServices.Extension> _
    Public Function ObjecttoCSV(table As DataTable) As String
        Dim result = New StringBuilder()
        For i As Integer = 0 To table.Columns.Count - 1
            result.Append(table.Columns(i).ColumnName)
            result.Append(If(i = table.Columns.Count - 1, vbLf, ","))
        Next

        For Each row As DataRow In table.Rows
            For i As Integer = 0 To table.Columns.Count - 1
                result.Append(row(i).ToString())
                result.Append(If(i = table.Columns.Count - 1, vbLf, ","))
            Next
        Next

        Return result.ToString()
    End Function



    <System.Runtime.CompilerServices.Extension()> _
    Public Function CreateCSVFromGenericList(Of T)(ByVal list As IEnumerable(Of T)) As String
        If list Is Nothing OrElse list.Count = 0 Then
            Return ""
        End If
        Dim temp As String = ""

        Dim newLine As String = Environment.NewLine
        Dim sw As New StringBuilder()
        Dim props As PropertyInfo() = GetType(T).GetProperties()
        For Each pi As PropertyInfo In props
            sw.Append(pi.Name.ToUpper() & ",")
        Next
        sw.Append(newLine)
        'this acts as datarow
        For Each item As T In list
            'this acts as datacolumn
            Dim Clear As String = ""
            For Each pi As PropertyInfo In props

                'this is the row+col intersection (the value)
                Dim whatToWrite As String = Convert.ToString(item.[GetType]().GetProperty(pi.Name).GetValue(item, Nothing)).Replace(","c, " "c) + ","c

                sw.Append(whatToWrite)
            Next
            sw.Append(newLine)
        Next
        Return sw.ToString()
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDeciemal(ByVal i As Integer) As String
        Return i & ".00"
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Alert(ByRef s As HttpResponse, ByVal MSG As String)
        s.Write("<script language=javascript>")
        s.Write("alert('" & MSG & "');")
        s.Write("</script>")
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ConfirmAlert(ByRef s As Page, ByVal MSG As String)
        System.Web.UI.ScriptManager.RegisterStartupScript(s, GetType(Page), "ใส่ไรก็ได้", "alert('" & MSG & "');", True)
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ResponseConfirm(ByRef s As Page, ByVal MSG As String, ByVal Url As String)
        System.Web.UI.ScriptManager.RegisterStartupScript(s, GetType(Page), "ใส่ไรก็ได้", "window.location='" & Url & "';alert('" & MSG & "');", True)

    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DateJava(ByRef s As Literal, ByVal T As TextBox)
        Dim Sql As String = "<script type='text/javascript'>" & vbNewLine & _
        "    $(document).ready(function() {" & vbNewLine & _
        "    var targetobject = $('#" & T.ClientID & "');" & vbNewLine & _
        "" & vbNewLine & _
        "        $(targetobject).datepicker({ showOn: 'button'," & vbNewLine & _
        "" & vbNewLine & _
        "            buttonImage: '../Script/calendar.gif'," & vbNewLine & _
        "" & vbNewLine & _
        "            buttonImageOnly: true" & vbNewLine & _
        "        });" & vbNewLine & _
        "" & vbNewLine & _
        "    });      " & vbNewLine & _
        "</script> "
        Dim Decode As String = """"
        s.Text = Sql.Replace("'", Decode)
    End Sub


    <System.Runtime.CompilerServices.Extension()> _
    Public Function get_Year(ByVal Mas As MasterPage) As String
        Dim bgYear As String = 0
        If Mas.Request.QueryString("myear") Is Nothing Then
            Dim dd_BudgetYear As DropDownList
            dd_BudgetYear = CType(Mas.FindControl("dd_BudgetYear"), DropDownList)
            bgYear = dd_BudgetYear.SelectedValue
        Else
            bgYear = Mas.Request.QueryString("myear")
        End If
       
        Return bgYear
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function get_dept(ByVal Mas As MasterPage) As String
        Dim dept_id As String = 0
        
        If Mas.Request.QueryString("dept") = "" Then
            Dim ddl_Department As DropDownList
            ddl_Department = CType(Mas.FindControl("ddl_Department"), DropDownList)
            dept_id = ddl_Department.SelectedValue
        Else
            dept_id = Mas.Request.QueryString("dept")
        End If




        Return dept_id

    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function b64encode(ByVal StrEncode As String)

        Dim encodedString As String

        encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(StrEncode)))

        Return (encodedString)

    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function b64decode(ByVal StrDecode As String)
        Try
            Dim decodedString As String

            decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode))

            Return decodedString
        Catch ex As Exception
            Return ""
        End Try


    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function DropDownGetValue(ByRef Dropdown As DropDownList) As String
        Dim Value As String = ""
        For Each LT As ListItem In Dropdown.Items
            If LT.Selected = True Then
                Value = LT.Value
                Exit For
            End If
        Next
        Return Value
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function DropDownGetText(ByRef Dropdown As DropDownList) As String
        Dim Value As String = ""
        For Each LT As ListItem In Dropdown.Items
            If LT.Selected = True Then
                Value = LT.Text
                Exit For
            End If
        Next
        Return Value
    End Function

    '<System.Runtime.CompilerServices.Extension()> _
    'Public Sub DropdownBindDataSqlDatasource(ByRef Dropdown As DropDownList, ByVal Datasource As SqlDataSource, ByVal Textfield As String, ByVal Valuefield As String)
    '    Dim clsds As New ClassDataset
    '    Dim dt As DataTable = clsds.dsQueryselect(Datasource.SelectCommand, Datasource.ConnectionString).Tables(0)
    '    For Each dr As DataRow In dt.Rows
    '        Dropdown.Items.Insert(Dropdown.Items.Count, New ListItem(dr(Textfield), dr(Valuefield)))
    '    Next
    'End Sub


    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropdownBindDataTable(ByRef Dropdown As DropDownList, ByVal dt As DataTable, ByVal Textfield As String, ByVal Valuefield As String)
        For Each dr As DataRow In dt.Rows
            Dropdown.Items.Insert(Dropdown.Items.Count, New ListItem(dr(Textfield), dr(Valuefield)))
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Radiobuttonlist_SelectValue(ByRef Radiolist As RadioButtonList, ByVal value As String)

        For Each LT As ListItem In Radiolist.Items
            LT.Selected = False
        Next

        For Each LT As ListItem In Radiolist.Items
            If LT.Value = value Then
                LT.Selected = True
            End If
        Next

    End Sub


    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Radiobuttonlist_SelectText(ByRef Radiolist As RadioButtonList, ByVal Text As String)

        For Each LT As ListItem In Radiolist.Items
            LT.Selected = False
        Next

        For Each LT As ListItem In Radiolist.Items
            If LT.Text = Text Then
                LT.Selected = True
            End If
        Next

    End Sub


    <System.Runtime.CompilerServices.Extension()> _
    Public Function CheckString_Date(ByVal Text As String) As String

        Dim TempDate As String = ""
        Try
            TempDate = CDate(Text).ToShortDateString
        Catch ex As Exception

        End Try
        Return TempDate
    End Function



    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetPageName(ByVal ThisPage As Page) As String
        Dim StrPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo = New FileInfo(StrPath)
        GetPageName = oInfo.Name
        Return GetPageName
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToShortThaiDate(ByVal D As String) As String
        Dim ThaiCulture As New System.Globalization.CultureInfo("th-TH")
        If D <> "" Then
            Return CDate(D).ToString("dd MMM yy", ThaiCulture.DateTimeFormat)
        Else
            Return String.Empty
        End If
    End Function



    <System.Runtime.CompilerServices.Extension()> _
    Public Sub RadiolistSelectData(ByRef radio As RadioButtonList, ByVal Value As String)
        For Each LT As ListItem In radio.Items
            If LT.Value = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next

    End Sub


    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownSelectData(ByRef Dropdown As DropDownList, ByVal Value As String)
        '   Dropdown.DataBind()
        For Each LT As ListItem In Dropdown.Items
            If LT.Value = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownSelectText(ByRef Dropdown As DropDownList, ByVal Value As String)
        '   Dropdown.DataBind()
        For Each LT As ListItem In Dropdown.Items
            If LT.Text = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Function CheckString_integer(ByVal Value As String) As Integer
        Dim Data As Integer = 0
        Try
            Data = CInt(Value)
        Catch ex As Exception
        End Try
        Return Data
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function CheckString_Decimal(ByVal Value As String) As Decimal
        Dim Data As Decimal = 0
        Try
            Data = CDec(Value)
        Catch ex As Exception
        End Try
        Return Data
    End Function


    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownInsertData(ByRef Dropdown As DropDownList, ByVal Text As String, ByVal Value As String)
        Dropdown.DataBind()
        Dropdown.Items.Insert(0, New ListItem(Text, Value))
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownInsertDataFirstRow(ByRef Dropdown As DropDownList, ByVal Text As String, ByVal Value As String)
        Dropdown.Items.Insert(0, New ListItem(Text, Value))
        Dropdown.SelectedIndex = 0
    End Sub



End Module
Public Class ObjectShredder(Of T)

    Private _fi() As FieldInfo

    Private _pi() As PropertyInfo

    Private _ordinalMap As Dictionary(Of String, Integer)

    Private _type As Type

    Public Sub New()

        _type = GetType(T)

        _fi = _type.GetFields()

        _pi = _type.GetProperties()

        _ordinalMap = New Dictionary(Of String, Integer)()

    End Sub

    Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As Nullable(Of LoadOption)) As DataTable

        If GetType(T).IsPrimitive Then

            Return ShredPrimitive(source, table, options)

        End If

        If table Is Nothing Then

            table = New DataTable(GetType(T).Name)

        End If

        ' now see if need to extend datatable base on the type T + build ordinal map

        table = ExtendTable(table, GetType(T))

        table.BeginLoadData()

        Using e As IEnumerator(Of T) = source.GetEnumerator()

            Do While e.MoveNext()

                If options.HasValue Then

                    table.LoadDataRow(ShredObject(table, e.Current), CType(options, LoadOption))

                Else

                    table.LoadDataRow(ShredObject(table, e.Current), True)

                End If

            Loop

        End Using

        table.EndLoadData()

        Return table

    End Function

    Public Function ShredPrimitive(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As Nullable(Of LoadOption)) As DataTable

        If table Is Nothing Then

            table = New DataTable(GetType(T).Name)

        End If

        If (Not table.Columns.Contains("Value")) Then

            table.Columns.Add("Value", GetType(T))

        End If

        table.BeginLoadData()

        Using e As IEnumerator(Of T) = source.GetEnumerator()

            Dim values() As Object = New Object(table.Columns.Count - 1) {}

            Do While e.MoveNext()

                values(table.Columns("Value").Ordinal) = e.Current

                If options.HasValue Then

                    table.LoadDataRow(values, CType(options, LoadOption))

                Else

                    table.LoadDataRow(values, True)

                End If

            Loop

        End Using

        table.EndLoadData()

        Return table

    End Function

    Public Function ExtendTable(ByVal table As DataTable, ByVal type As Type) As DataTable

        ' value is type derived from T, may need to extend table.

        For Each f As FieldInfo In type.GetFields()

            If (Not _ordinalMap.ContainsKey(f.Name)) Then

                Dim dc As DataColumn

                dc = If(table.Columns.Contains(f.Name), table.Columns(f.Name), table.Columns.Add(f.Name, f.FieldType))

                _ordinalMap.Add(f.Name, dc.Ordinal)

            End If

        Next f

        For Each p As PropertyInfo In type.GetProperties()

            If (Not _ordinalMap.ContainsKey(p.Name)) Then

                Dim dc As DataColumn
                Try
                    dc = If(table.Columns.Contains(p.Name), table.Columns(p.Name), table.Columns.Add(p.Name, p.PropertyType))
                Catch ex As Exception
                    dc = table.Columns(p.Name)
                End Try


                _ordinalMap.Add(p.Name, dc.Ordinal)

            End If

        Next p

        Return table

    End Function

    Public Function ShredObject(ByVal table As DataTable, ByVal instance As T) As Object()

        Dim fi() As FieldInfo = _fi

        Dim pi() As PropertyInfo = _pi

        If instance.GetType() IsNot GetType(T) Then

            ExtendTable(table, instance.GetType())

            fi = instance.GetType().GetFields()

            pi = instance.GetType().GetProperties()

        End If

        Dim values() As Object = New Object(table.Columns.Count - 1) {}

        For Each f As FieldInfo In fi

            values(_ordinalMap(f.Name)) = f.GetValue(instance)

        Next f

        For Each p As PropertyInfo In pi

            values(_ordinalMap(p.Name)) = p.GetValue(instance, Nothing)

        Next p

        Return values

    End Function

End Class
