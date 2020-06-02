Public Class Check_Token_Receipt
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _TOKEN As String
    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        '_TOKEN = "iiRa3OCPUyb40lhChTyDiAUU" 'test
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
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If
        xml = ws.Authen_Login(token)
        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        _CLS.TOKEN = _TOKEN

        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")

        Dim bao As New BAO.information
        _CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)

        Session("CLS") = _CLS

        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            Response.Redirect("Module03/FRM_RECEIPT_LIST.aspx?lcnsid=" & _CLS.LCNSID_CUSTOMER)
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If



    End Sub
End Class