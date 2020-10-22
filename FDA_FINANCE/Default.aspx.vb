Public Class _Default
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _TOKEN As String
    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        '_TOKEN = "KdZXSBr9LN3/AbxbmhVvgAUU" 'test
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim strAD As String = NameUserAD()
        'Dim dao As New DAO_USER.TB_tbl_USER
        'dao.Getdata_by_AD_NAME(strAD)
        'If checkAD() = True Then
        '    ' Response.Redirect("Frm_Main.aspx")
        '    If dao.fields.PERMISSION_ID = 1 Then
        'Response.Redirect("HOME/FRM_PROJECT_SELECT.aspx?dept=" & dao.fields.DEPARTMENT_ID)
        '    Else
        '        Response.Redirect("HOME/FRM_PROJECT_SELECT.aspx?dept=" & dao.fields.DEPARTMENT_ID)
        '    End If
        'Else
        '    'Response.Redirect("HOME/FRM_PROJECT_SELECT.aspx?dept=" & dao.fields.DEPARTMENT_ID)
        'End If
        RunQuery()
        Try
            token()
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End Try

    End Sub
    Sub token()

        Dim token As String = _TOKEN

        Dim ws As New WS_AUTHENTICATION.Authentication
        Dim xml As String = ""


        If token = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token'); window.location.href = 'http://privus.fda.moph.go.th';", True)
            'Response.Redirect("http://privus.fda.moph.go.th")
        End If
        'xml = ws.Authen_Login(token)

        Dim ws_118 As New Authentication_118.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New Authentication_104.Authentication
        'Dim xml As String = ""
        Try
            ws_118.Timeout = 10000
            xml = ws_118.Authen_Login(_TOKEN)

            If xml = "" Then
                ws_66.Timeout = 10000
                xml = ws_66.Authen_Login(_TOKEN)
                If xml = "" Then
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                End If
            End If
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                xml = ws_66.Authen_Login(_TOKEN)
                If xml = "" Then
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                End If
            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try




        'Dim cls_xml As New Cls_XML
        'cls_xml.ReadData(xml)

        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        _CLS.TOKEN = _TOKEN
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")

        _CLS.ID_MENU = "80000"
        Dim bao As New BAO_PERMISSION.PERMISSION
        Dim dt As DataTable = bao.SP_PERMISSION_BUDJET(_CLS.CITIZEN_ID, _CLS.GROUPS)
        Session("CLS") = _CLS
        Dim dao_dept As New DAO_MAS.TB_MAS_DEPARTMENT
        Dim str_code As String = ""
        Try
            str_code = CStr(dt(0)("DEPARTMENT_CODE")).Replace(vbCr, "").Replace(vbLf, "")
        Catch ex As Exception

        End Try

        dao_dept.Getdata_by_Dept_Code(str_code)
        If dt.Rows.Count > 0 Then
            Dim code As String = clsxml.Get_Value_XML("CODE")
            If code = "900" Then
                Response.Redirect("HOME/FRM_PROJECT_SELECT.aspx?dept=" & dao_dept.fields.DEPARTMENT_ID)
            ElseIf code = "100" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
            ElseIf code = "101" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If
       

    End Sub
End Class