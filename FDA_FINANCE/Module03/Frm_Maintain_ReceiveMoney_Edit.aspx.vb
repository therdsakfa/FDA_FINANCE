Imports Telerik.Web.UI
Public Class Frm_Maintain_ReceiveMoney_Edit
    Inherits System.Web.UI.Page
    Private _bgyear As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            UC_Maintain_ReceiveMoney_Detail_Money.bind_dl_department()
            Dim dao_maintain_receive_money_edit As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_maintain_receive_money_edit.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("RECEIVE_MONEY_ID"))
            'UC_Maintain_ReceiveMoney_Detail_MoneyType.getdata(dao_maintain_receive_money_edit)
            UC_Maintain_ReceiveMoney_Detail_Money.getdata(dao_maintain_receive_money_edit)
            UC_Maintain_ReceiveMoney_Detail_Receipt.getdata(dao_maintain_receive_money_edit)
            UC_Maintain_ReceiveMoney_Detail_Bank.getdata(dao_maintain_receive_money_edit)
            bgyear = Request.QueryString("bgyear")


            Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
            'dao_node.Getdata_Head(0, bgyear)
            dao_node.Getdata_Head_no_Year(0)
            Dim rtv_money_type As New RadTreeView
            ' rtv_money_type = DirectCast(rcb_Moneytype.FindControl("rtv_money_type"), RadTreeView)
            ' Dim objCombo As RadComboBox = DirectCast(sender, RadComboBox)
            rtv_money_type = DirectCast(rcb_Moneytype.Items(0).FindControl("rtv_money_type"), RadTreeView)
            For Each dao_node.fields In dao_node.datas
                Dim node As New RadTreeNode
                dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
                node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
                node.Value = dao_node.fields.MONEY_TYPE_ID
                rtv_money_type.Nodes.Add(node)
                bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
            Next


            Dim id As Integer = Request.QueryString("RECEIVE_MONEY_ID")
            Dim dao As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao.Getdata_by_RECEIVE_MONEY_ID(id)
            Dim dao_moneytype As New DAO_MAS.TB_MAS_MONEY_TYPE
            dao_moneytype.Getdata_by_MONEY_TYPE_ID(dao.fields.MONEY_TYPE_ID)
            rcb_Moneytype.Text = dao_moneytype.fields.MONEY_TYPE_DESCRIPTION
            Dim tree As RadTreeView = rcb_Moneytype.Items(0).FindControl("rtv_money_type")
            Dim node_sel = tree.FindNodeByText(dao_moneytype.fields.MONEY_TYPE_DESCRIPTION)
            node_sel.Selected = True
            rcb_Moneytype.SelectedValue = node_sel.Value

            Dim value As Integer
            If rcb_Moneytype.SelectedValue = "" Then
                value = 0
            Else
                value = rcb_Moneytype.SelectedValue
            End If
            UC_Maintain_ReceiveMoney_Detail_MoneyType.nodeID = value
            UC_Maintain_ReceiveMoney_Detail_MoneyType.bindTxtbox()

        End If
    End Sub
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
        'dao_node.Getdata_Head(ParentID, bgyear)
        dao_node.Getdata_Head_no_Year(ParentID)
        For Each dao_node.fields In dao_node.datas
            dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            Dim node As New RadTreeNode
            node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
            node.Value = dao_node.fields.MONEY_TYPE_ID
            rt.Add(node)
            bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
        Next
    End Sub
    Protected Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim qstr_RECEIVE_MONEY_ID As Integer
        Dim dao_receive_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        If Request.QueryString("RECEIVE_MONEY_ID") IsNot Nothing Then
            qstr_RECEIVE_MONEY_ID = Request.QueryString("RECEIVE_MONEY_ID").ToString()
            dao_receive_money.Getdata_by_RECEIVE_MONEY_ID(qstr_RECEIVE_MONEY_ID)
            'UC_Maintain_ReceiveMoney_Detail_MoneyType.insert(dao_receive_money)
            UC_Maintain_ReceiveMoney_Detail_Money.insert(dao_receive_money)
            UC_Maintain_ReceiveMoney_Detail_Receipt.insert(dao_receive_money)
            UC_Maintain_ReceiveMoney_Detail_Bank.insert(dao_receive_money)
            Dim value As Integer
            If rcb_Moneytype.SelectedValue = "" Then
                value = 0
            Else
                value = rcb_Moneytype.SelectedValue
            End If
            dao_receive_money.fields.MONEY_TYPE_ID = value

            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "แก้ไขรายการบันทึกการรับเงิน", _
                           "RECEIVE_MONEY", Request.QueryString("RECEIVE_MONEY_ID"))
            dao_receive_money.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", " alert('แก้ไขเรียบร้อย'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('แก้ไขข้อมูลเรียบร้อยแล้ว');window.location.href = 'Frm_Maintain_Receive_Money.aspx';", True)
        End If
        'Response.Redirect("Frm_Maintain_ReceiveMoney.aspx")

    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        ' Response.Redirect("Frm_Maintain_ReceiveMoney.aspx")
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

    Private Sub rcb_Moneytype_TextChanged(sender As Object, e As EventArgs) Handles rcb_Moneytype.TextChanged
        Dim value As Integer
        If rcb_Moneytype.SelectedValue = "" Then
            value = 0
        Else
            value = rcb_Moneytype.SelectedValue
        End If
        UC_Maintain_ReceiveMoney_Detail_MoneyType.nodeID = value
        UC_Maintain_ReceiveMoney_Detail_MoneyType.bindTxtbox()
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
       

        'UC_Maintain_ReceiveMoney_Detail_MoneyType.nodeID = node.Value
        'UC_Maintain_ReceiveMoney_Detail_MoneyType.bindTxtbox()
    End Sub
End Class