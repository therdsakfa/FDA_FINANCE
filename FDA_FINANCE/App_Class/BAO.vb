Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Namespace BAO
    Public Class AppSettings
        Public _PATH_PDF_TEMPLATE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")
        Public _PATH_XML_CLASS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")
        Public _PATH_PDF_XML_CLASS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")
        Public _PATH_PDF_TRADER As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")
        Public _PATH_XML_TRADER As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")
        Public _PATH_DEFAULT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT")
        Sub RunAppSettings()
            _PATH_PDF_TEMPLATE = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")
            _PATH_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")
            _PATH_PDF_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")
            _PATH_PDF_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")
            _PATH_XML_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")
        End Sub
    End Class
    Public Class information
        Public Function load_name(ByVal _CLS As CLS_SESSION) As CLS_SESSION
            Dim dao_syslcnsid As New DAO_CPN.TB_syslcnsid
            Dim dao_syslcnsnm As New DAO_CPN.TB_syslcnsnm

            dao_syslcnsid.GetDataby_identify(_CLS.CITIZEN_ID)
            dao_syslcnsnm.GetDataby_identify(_CLS.CITIZEN_ID)
            _CLS.LCNSID = dao_syslcnsid.fields.lcnsid

            If String.IsNullOrEmpty(dao_syslcnsnm.fields.thalnm) = True Or dao_syslcnsnm.fields.thalnm = Nothing Then
                _CLS.THANM = dao_syslcnsnm.fields.thanm
            Else
                _CLS.THANM = dao_syslcnsnm.fields.thanm + " " + dao_syslcnsnm.fields.thalnm
            End If
            Return _CLS
            '     Session("CLS") = _CLS
        End Function



        Public Function load_lcnsid_customer(ByVal _CLS As CLS_SESSION) As CLS_SESSION
            Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE

            Dim dao_syslcnsid As New DAO_CPN.TB_syslcnsid
            dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

            Dim dao_sysnmperson As New DAO_CPN.TB_syslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            _CLS.LCNSID_CUSTOMER = dao_syslcnsid.fields.lcnsid



            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

            Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            _CLS.THANM_CUSTOMER = fullname

            Return _CLS
        End Function
    End Class
End Namespace
