﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_RUN_PDF_RECEIPTS
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_RUN_PDF_RECEIPTSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_RUN_PDF_RECEIPT
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private runpdfOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_RUN_PDF_RECEIPT_WS_RUN_PDF_RECEIPT
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event runpdfCompleted As runpdfCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/runpdf", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub runpdf(ByVal dt1 As System.Data.DataTable, ByVal path As String, ByVal report_datasource As String, ByVal ref02 As String)
            Me.Invoke("runpdf", New Object() {dt1, path, report_datasource, ref02})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub runpdfAsync(ByVal dt1 As System.Data.DataTable, ByVal path As String, ByVal report_datasource As String, ByVal ref02 As String)
            Me.runpdfAsync(dt1, path, report_datasource, ref02, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub runpdfAsync(ByVal dt1 As System.Data.DataTable, ByVal path As String, ByVal report_datasource As String, ByVal ref02 As String, ByVal userState As Object)
            If (Me.runpdfOperationCompleted Is Nothing) Then
                Me.runpdfOperationCompleted = AddressOf Me.OnrunpdfOperationCompleted
            End If
            Me.InvokeAsync("runpdf", New Object() {dt1, path, report_datasource, ref02}, Me.runpdfOperationCompleted, userState)
        End Sub
        
        Private Sub OnrunpdfOperationCompleted(ByVal arg As Object)
            If (Not (Me.runpdfCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent runpdfCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub runpdfCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
End Namespace