Imports Telerik.Web.UI
Public Class UC_Person_In_Report
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_Person_Init(sender As Object, e As EventArgs) Handles rg_Person.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_Person
        Rad_Utility.addColumnBound("R_ID", "R_ID", False, width:=10)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=15)
        Rad_Utility.addColumnBound("R_NAME", "ชื่อผู้ตรวจสอบ", width:=250)
        Rad_Utility.addColumnBound("R_TYPE_PERSON_NAME", "ประเภทผู้ตรวจสอบ")
        Rad_Utility.addColumnCheckbox("IS_USE", "การใช้งาน")
        Rad_Utility.addColumnCheckbox("IS_NORMAL", "ใช้ในรายงานทะเบียนคุมอื่นๆ")
        Rad_Utility.addColumnCheckbox("IS_FOUNDATION", "ใช้ในรายงานมูลนิธิ")
        Rad_Utility.addColumnCheckbox("IS_SPSC", "ใช้ในเงินสปสช.")
        Rad_Utility.addColumnCheckbox("IS_SSS", "ใช้ในเงินสสส.")
        Rad_Utility.addColumnCheckbox("IS_BENEFITS", "ใช้ในสวัสดิการ")
        Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")
    End Sub

    Private Sub rg_Person_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_Person.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Delete" Then
                Dim dao_person As New DAO_MAS.TB_TBL_PERSON_IN_REPORT
                dao_person.Getdata_by_ID(item("R_ID").Text)
                'Dim log As New log_event.log
                'log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), "ลบข้อมูลธนาคารชื่อ " & dao_bank.fields.BANK_NAME, "MAS_BANK", item("BANK_ID").Text)

                dao_person.delete()
                rg_Person.Rebind()

            End If
        End If
    End Sub

    Private Sub rg_Person_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_Person.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("R_ID").Text
            Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Person_In_Report_Edit.aspx?id=" & id
            h2.Attributes.Add("OnClick", "return k('" & url & "');")

        End If
    End Sub

    Private Sub rg_Person_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_Person.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_person_in_report()

        rg_Person.DataSource = dt
    End Sub
    Public Sub rg_rebind()
        rg_Person.Rebind()
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rg_Person)

    End Sub
End Class