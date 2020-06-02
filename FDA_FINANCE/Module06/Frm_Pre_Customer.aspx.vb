Imports Telerik.Web.UI

Public Class Frm_Pre_Customer
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim arrLink As String() = Request.Url.Segments
        Dim apsx_name As String = arrLink(Request.Url.Segments.Length - 1)
        Dim uti As New Utility_other
        Page.Title = uti.get_title_name(apsx_name)

        btnAdd.Visible = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Frm_Pre_Customer_Insert.aspx")
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Customers1.bindseq()
        UC_Pre_Customers1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        'UC_Customers1.rg_rebind()
        UC_Pre_Customers1.rg_rebind()
    End Sub

    Protected Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Dim str As String
        'str = UC_Customer_Search1.get_strSearch()
        'UC_Pre_Customers1.rgFilter(str)


        Dim dao As New DAO_MAS.TB_MAS_CUSTOMER
        If txtS_personID.Text <> "" Then
            dao.Getdata_by_personalID(txtS_personID.Text.Trim)
        ElseIf txtS_name.Text <> "" Then
            dao.Getdata_by_CusName(txtS_name.Text.Trim)
        End If

        If dao.fields.PERSONAL_ID <> "" Then
            str = get_strSearch()
            UC_Pre_Customers1.rgFilter(str)
        ElseIf dao.fields.CUSTOMER_NAME <> "" Then
            str = get_strSearch()
            UC_Pre_Customers1.rgFilter(str)
        Else
            btnAdd.Visible = True
            Response.Alert("ไม่มีข้อมูลในระบบ กรุณาเพิ่มข้อมูลใหม่")
        End If

    End Sub

    Public Function get_strSearch() As String
        Dim str As String = ""
        str = "([PERSONAL_ID] LIKE '%" & txtS_personID.Text & "%')" & _
            " and ([CUSTOMER_NAME] LIKE '%" & txtS_name.Text & "%')"

        If txtS_personID.Text <> "" Then
            str = "([PERSONAL_ID] LIKE '%" & txtS_personID.Text & "%')"
        ElseIf txtS_name.Text <> "" Then
            str = "([CUSTOMER_NAME] LIKE '%" & txtS_name.Text & "%')"
        End If

        Return str
    End Function
End Class