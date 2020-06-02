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
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_QR
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_QRSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_QR
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private QR_CODE_B64OperationCompleted As System.Threading.SendOrPostCallback
        
        Private QR_CODE_BYTESOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_QR_WS_QR
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
        Public Event QR_CODE_B64Completed As QR_CODE_B64CompletedEventHandler
        
        '''<remarks/>
        Public Event QR_CODE_BYTESCompleted As QR_CODE_BYTESCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/QR_CODE_B64", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function QR_CODE_B64(ByVal URLs As String) As String
            Dim results() As Object = Me.Invoke("QR_CODE_B64", New Object() {URLs})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub QR_CODE_B64Async(ByVal URLs As String)
            Me.QR_CODE_B64Async(URLs, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub QR_CODE_B64Async(ByVal URLs As String, ByVal userState As Object)
            If (Me.QR_CODE_B64OperationCompleted Is Nothing) Then
                Me.QR_CODE_B64OperationCompleted = AddressOf Me.OnQR_CODE_B64OperationCompleted
            End If
            Me.InvokeAsync("QR_CODE_B64", New Object() {URLs}, Me.QR_CODE_B64OperationCompleted, userState)
        End Sub
        
        Private Sub OnQR_CODE_B64OperationCompleted(ByVal arg As Object)
            If (Not (Me.QR_CODE_B64CompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent QR_CODE_B64Completed(Me, New QR_CODE_B64CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/QR_CODE_BYTES", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function QR_CODE_BYTES(ByVal URLS As String) As <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> Byte()
            Dim results() As Object = Me.Invoke("QR_CODE_BYTES", New Object() {URLS})
            Return CType(results(0),Byte())
        End Function
        
        '''<remarks/>
        Public Overloads Sub QR_CODE_BYTESAsync(ByVal URLS As String)
            Me.QR_CODE_BYTESAsync(URLS, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub QR_CODE_BYTESAsync(ByVal URLS As String, ByVal userState As Object)
            If (Me.QR_CODE_BYTESOperationCompleted Is Nothing) Then
                Me.QR_CODE_BYTESOperationCompleted = AddressOf Me.OnQR_CODE_BYTESOperationCompleted
            End If
            Me.InvokeAsync("QR_CODE_BYTES", New Object() {URLS}, Me.QR_CODE_BYTESOperationCompleted, userState)
        End Sub
        
        Private Sub OnQR_CODE_BYTESOperationCompleted(ByVal arg As Object)
            If (Not (Me.QR_CODE_BYTESCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent QR_CODE_BYTESCompleted(Me, New QR_CODE_BYTESCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub QR_CODE_B64CompletedEventHandler(ByVal sender As Object, ByVal e As QR_CODE_B64CompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class QR_CODE_B64CompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub QR_CODE_BYTESCompletedEventHandler(ByVal sender As Object, ByVal e As QR_CODE_BYTESCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class QR_CODE_BYTESCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Byte()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Byte())
            End Get
        End Property
    End Class
End Namespace
