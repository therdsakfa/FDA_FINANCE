Public Class Frm_Send_Mail_Receipt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email

        Try
            mm.SendMail(mcontent)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn_main_Click(sender As Object, e As EventArgs) Handles btn_main.Click
        Dim email As String = ""
        Dim Title As String = ""
        Dim Content As String = ""
        Dim dao_mail As New DAO_CPN.TB_sysemail
        Dim ref01 As String = ""
        Dim ref02 As String = ""

        email = Trim(txt_mail.Text)
        ref01 = Trim(txt_ref1.Text)
        ref02 = Trim(txt_ref2.Text)

        If email <> "" Then
            email = email
            Title = "ใบเสร็จอิเล็กทรอนิกส์ชำระเงิน"
            Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://helpb.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & ref01 & "&ref02=" & ref02
            SendMail(Content, email, Title, email, "", "")
        End If
    End Sub

    Private Sub btn_mail_Click(sender As Object, e As EventArgs) Handles btn_mail.Click
       
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.FDA_FEE
        Dim command As String = " "
        command = "select * from dbo.fee where feedate >= '2018-05-16' and rcptst = 1 "
        dt = bao.Queryds(command)
        For Each dr As DataRow In dt.Rows
            Dim email As String = ""
            Dim Title As String = ""
            Dim Content As String = ""
            Dim ref01 As String = ""
            Dim ref02 As String = ""
            Dim citizen_fee As String = ""
            Dim dao_mail As New DAO_CPN.TB_sysemail
            Try
                citizen_fee = dr("create_identify")
            Catch ex As Exception

            End Try

            Try
                dao_mail.GetDataby_identify(citizen_fee)
                email = dao_mail.fields.EMAIL_EGA
            Catch ex As Exception

            End Try
            Try
                ref01 = dr("ref01")
            Catch ex As Exception

            End Try
            Try
                ref02 = dr("ref02")
            Catch ex As Exception

            End Try

            If email <> "" Then
                email = email
                Title = "ใบเสร็จอิเล็กทรอนิกส์ชำระเงิน_" & TimeStampNow()
                Content = "ลิ้งค์สำหรับใบเสร็จอิเล็กทรอนิกส์ http://helpb.fda.moph.go.th/fda_budget/Module09/Report/Frm_Report_R9_003.aspx?ref01=" & ref01 & "&ref02=" & ref02
                SendMail(Content, email, Title, email, "", "")
            End If
        Next
        
    End Sub
End Class