Public Class Frm_Disburse_Debtor
    Inherits System.Web.UI.Page
    Public bgYear As Integer
    Private _dept As Integer
    Private _bgid As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub runQuery()
        _dept = Request.QueryString("dept")
        _bgid = Request.QueryString("bgid")
        bgYear = Request.QueryString("myear")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "รายการลูกหนี้เงินยืม"

        runQuery()
        set_uc()
        RunSession()
    End Sub

    Public Sub set_uc()
        Try
            UC_Disburse_Debtor1.dept_id = _dept
        Catch ex As Exception

        End Try
        Try
            UC_Disburse_Debtor1.BudgetYear = bgYear
        Catch ex As Exception

        End Try
        UC_Disburse_Debtor1.BudgetUseID = 1
        Try
            UC_Budget_Amount_Detail1.BudgetplanId = _bgid
            UC_Disburse_Debtor1.BudgetID = _bgid




            UC_Budget_Amount_Detail1.dept = _dept
            UC_Budget_Amount_Detail1.Budgetyear = bgYear
            UC_Budget_Amount_Detail1.getData_detail(_bgid, _dept, bgYear)

        Catch ex As Exception

        End Try
        Try
            UC_Disburse_Debtor1.dept_id = _dept
        Catch ex As Exception

        End Try

        UC_Disburse_Debtor1.g = 0
        UC_Disburse_Debtor1.bt = 3
        UC_Disburse_Debtor1.stat = 3
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim str As String
        str = UC_Search_Form1.getSearchMsg()
        UC_Disburse_Debtor1.rgFilter(str)
    End Sub


    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'UC_Disburse_Debtor1.set_color_rg()
        'UC_Disburse_Debtor1.bindseq()
    End Sub

    Private Sub btnRedirect_Click(sender As Object, e As EventArgs) Handles btnRedirect.Click
        set_uc()
        UC_Disburse_Debtor1.rebind_grid()
    End Sub

    Private Sub rdl_approve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_approve.SelectedIndexChanged
        Dim str As String = ""
        str = "([app] like '%" & rdl_approve.SelectedValue & "%')"
        UC_Disburse_Debtor1.rgFilter(str)
    End Sub
    
    Private Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click

    End Sub

    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String, ByVal process As Integer)
        'Dim bao_app As New BAO.AppSettings
        'bao_app.RunAppSettings()

        'Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'Dim down_ID As Integer



        'Dim STATUS As String = 0
        'Dim DOWNLOAD_DATE As Date = Date.Now()
        'dao_down.fields.PROCESS_ID = process
        'dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        'dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        'dao_down.fields.STATUS = STATUS
        'dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        'dao_down.insert()
        'down_ID = dao_down.fields.ID
        'dao_up.fields.DOWNLOAD_ID = down_ID
        'dao_up.insert()

        ''Dim dao As New DAO.clsDBfafdtype
        ''dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

        ''    _CLS.FATYPE = FATYPE

        'Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)



        'Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
        'Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID)

        'convert_Database_To_XML("DA-" & down_ID.ToString())
        'convert_XML_To_PDF(file_PDF, file_xml, file_template)


        '_CLS.FILENAME_PDF = file_PDF
        '_CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        'Session("CLS") = _CLS
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
End Class