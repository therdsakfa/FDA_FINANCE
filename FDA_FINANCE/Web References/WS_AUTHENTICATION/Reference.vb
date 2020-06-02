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
Namespace WS_AUTHENTICATION
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="AuthenticationSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class Authentication
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private Authen_LoginOperationCompleted As System.Threading.SendOrPostCallback
        
        Private Authen_Login_CancelOperationCompleted As System.Threading.SendOrPostCallback
        
        Private Authen_Login_MENUOperationCompleted As System.Threading.SendOrPostCallback
        
        Private Authen_MENU_DOCOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_AUTHENTICATION_Authentication
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
        Public Event Authen_LoginCompleted As Authen_LoginCompletedEventHandler
        
        '''<remarks/>
        Public Event Authen_Login_CancelCompleted As Authen_Login_CancelCompletedEventHandler
        
        '''<remarks/>
        Public Event Authen_Login_MENUCompleted As Authen_Login_MENUCompletedEventHandler
        
        '''<remarks/>
        Public Event Authen_MENU_DOCCompleted As Authen_MENU_DOCCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ระบบทั่วไป", RequestElementName:="ระบบทั่วไป", RequestNamespace:="http://tempuri.org/", ResponseElementName:="ระบบทั่วไปResponse", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Authen_Login(ByVal Token As String) As <System.Xml.Serialization.XmlElementAttribute("ระบบทั่วไปResult")> String
            Dim results() As Object = Me.Invoke("Authen_Login", New Object() {Token})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub Authen_LoginAsync(ByVal Token As String)
            Me.Authen_LoginAsync(Token, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Authen_LoginAsync(ByVal Token As String, ByVal userState As Object)
            If (Me.Authen_LoginOperationCompleted Is Nothing) Then
                Me.Authen_LoginOperationCompleted = AddressOf Me.OnAuthen_LoginOperationCompleted
            End If
            Me.InvokeAsync("Authen_Login", New Object() {Token}, Me.Authen_LoginOperationCompleted, userState)
        End Sub
        
        Private Sub OnAuthen_LoginOperationCompleted(ByVal arg As Object)
            If (Not (Me.Authen_LoginCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Authen_LoginCompleted(Me, New Authen_LoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Authen_Login_Cancel", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Authen_Login_Cancel(ByVal Token As String, ByVal Citizen_ID As String) As String
            Dim results() As Object = Me.Invoke("Authen_Login_Cancel", New Object() {Token, Citizen_ID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub Authen_Login_CancelAsync(ByVal Token As String, ByVal Citizen_ID As String)
            Me.Authen_Login_CancelAsync(Token, Citizen_ID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Authen_Login_CancelAsync(ByVal Token As String, ByVal Citizen_ID As String, ByVal userState As Object)
            If (Me.Authen_Login_CancelOperationCompleted Is Nothing) Then
                Me.Authen_Login_CancelOperationCompleted = AddressOf Me.OnAuthen_Login_CancelOperationCompleted
            End If
            Me.InvokeAsync("Authen_Login_Cancel", New Object() {Token, Citizen_ID}, Me.Authen_Login_CancelOperationCompleted, userState)
        End Sub
        
        Private Sub OnAuthen_Login_CancelOperationCompleted(ByVal arg As Object)
            If (Not (Me.Authen_Login_CancelCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Authen_Login_CancelCompleted(Me, New Authen_Login_CancelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Authen_Login_MENU", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Authen_Login_MENU(ByVal Token As String, ByVal Citizen_ID As String, ByVal system_id As String, ByVal GROUP As String, ByVal MENU_ID As String) As String
            Dim results() As Object = Me.Invoke("Authen_Login_MENU", New Object() {Token, Citizen_ID, system_id, GROUP, MENU_ID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub Authen_Login_MENUAsync(ByVal Token As String, ByVal Citizen_ID As String, ByVal system_id As String, ByVal GROUP As String, ByVal MENU_ID As String)
            Me.Authen_Login_MENUAsync(Token, Citizen_ID, system_id, GROUP, MENU_ID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Authen_Login_MENUAsync(ByVal Token As String, ByVal Citizen_ID As String, ByVal system_id As String, ByVal GROUP As String, ByVal MENU_ID As String, ByVal userState As Object)
            If (Me.Authen_Login_MENUOperationCompleted Is Nothing) Then
                Me.Authen_Login_MENUOperationCompleted = AddressOf Me.OnAuthen_Login_MENUOperationCompleted
            End If
            Me.InvokeAsync("Authen_Login_MENU", New Object() {Token, Citizen_ID, system_id, GROUP, MENU_ID}, Me.Authen_Login_MENUOperationCompleted, userState)
        End Sub
        
        Private Sub OnAuthen_Login_MENUOperationCompleted(ByVal arg As Object)
            If (Not (Me.Authen_Login_MENUCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Authen_Login_MENUCompleted(Me, New Authen_Login_MENUCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Authen_MENU_DOC", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Authen_MENU_DOC(ByVal Citizen_ID As String, ByVal system_id As String, ByVal GROUP As String, ByVal MENU_ID As String) As String
            Dim results() As Object = Me.Invoke("Authen_MENU_DOC", New Object() {Citizen_ID, system_id, GROUP, MENU_ID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub Authen_MENU_DOCAsync(ByVal Citizen_ID As String, ByVal system_id As String, ByVal GROUP As String, ByVal MENU_ID As String)
            Me.Authen_MENU_DOCAsync(Citizen_ID, system_id, GROUP, MENU_ID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Authen_MENU_DOCAsync(ByVal Citizen_ID As String, ByVal system_id As String, ByVal GROUP As String, ByVal MENU_ID As String, ByVal userState As Object)
            If (Me.Authen_MENU_DOCOperationCompleted Is Nothing) Then
                Me.Authen_MENU_DOCOperationCompleted = AddressOf Me.OnAuthen_MENU_DOCOperationCompleted
            End If
            Me.InvokeAsync("Authen_MENU_DOC", New Object() {Citizen_ID, system_id, GROUP, MENU_ID}, Me.Authen_MENU_DOCOperationCompleted, userState)
        End Sub
        
        Private Sub OnAuthen_MENU_DOCOperationCompleted(ByVal arg As Object)
            If (Not (Me.Authen_MENU_DOCCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Authen_MENU_DOCCompleted(Me, New Authen_MENU_DOCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Authen_LoginCompletedEventHandler(ByVal sender As Object, ByVal e As Authen_LoginCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class Authen_LoginCompletedEventArgs
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Authen_Login_CancelCompletedEventHandler(ByVal sender As Object, ByVal e As Authen_Login_CancelCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class Authen_Login_CancelCompletedEventArgs
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Authen_Login_MENUCompletedEventHandler(ByVal sender As Object, ByVal e As Authen_Login_MENUCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class Authen_Login_MENUCompletedEventArgs
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Authen_MENU_DOCCompletedEventHandler(ByVal sender As Object, ByVal e As Authen_MENU_DOCCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class Authen_MENU_DOCCompletedEventArgs
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
End Namespace
