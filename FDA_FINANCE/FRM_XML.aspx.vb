Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_XML
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filename As String = "Debtor"
        Dim BG_ID As Integer = 781
        Dim cls As New CLASS_GEN_XML.DEBTOR(BG_ID) 'DALCN(cityzen_id, lcnsid, "1", pvncd)


        Dim cls_xml As New CLASS_DEBTOR
        cls_xml = cls.gen_xml(3)

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filename As String = "Study"
        Dim welfare_type As Integer = 1
        Dim cls As New CLASS_GEN_XML.STUDY(welfare_type) 'DALCN(cityzen_id, lcnsid, "1", pvncd)


        Dim cls_xml As New CLASS_CURE_STUDY
        cls_xml = cls.gen_xml(2)

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim filename As String = "Cure"
        Dim welfare_type As Integer = 2
        Dim cls As New CLASS_GEN_XML.CURE(0, welfare_type) 'DALCN(cityzen_id, lcnsid, "1", pvncd)


        Dim cls_xml As New CLASS_CURE_STUDY
        cls_xml = cls.gen_xml(2)

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub
End Class