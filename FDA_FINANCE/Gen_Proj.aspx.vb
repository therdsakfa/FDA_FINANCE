Imports System.IO
Imports System.Xml.Serialization

Public Class Gen_Proj
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_gen_Click(sender As Object, e As EventArgs) Handles btn_gen.Click
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.gen_xml_project()

        'Dim ds As New DataSet
        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "DATA_PROJECT"
        dt.TableName = "DATA_PROJECT"
        'For Each dr As DataRow In dt.Rows
        Dim path As String = "C:\path\BG\PROJECT\" & dt(0)("BUDGET_YEAR") & ".xml" '& "-" & Replace(dr("BUDGET_CODE"), " ", "") & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim xmlSerializer As New XmlSerializer(dt.GetType)
        xmlSerializer.Serialize(objStreamWriter, dt)
        objStreamWriter.Close()
        'Next


    End Sub
End Class