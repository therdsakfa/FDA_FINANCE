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
Namespace WS_UPDATE_PAY_HERB
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_UPDATE_STATUS_PAYSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_UPDATE_STATUS_PAY
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private Update_Status_PayOperationCompleted As System.Threading.SendOrPostCallback
        
        Private Update_Status_Pay_RepeatOperationCompleted As System.Threading.SendOrPostCallback
        
        Private Update_Status_Pay_RepeatOnlyOperationCompleted As System.Threading.SendOrPostCallback
        
        Private Update_Status_Pay_by_Ref02OperationCompleted As System.Threading.SendOrPostCallback
        
        Private Update_Status_Pay_by_Ref01OperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_UPDATE_PAY_HERB_WS_UPDATE_STATUS_PAY
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
        Public Event Update_Status_PayCompleted As Update_Status_PayCompletedEventHandler
        
        '''<remarks/>
        Public Event Update_Status_Pay_RepeatCompleted As Update_Status_Pay_RepeatCompletedEventHandler
        
        '''<remarks/>
        Public Event Update_Status_Pay_RepeatOnlyCompleted As Update_Status_Pay_RepeatOnlyCompletedEventHandler
        
        '''<remarks/>
        Public Event Update_Status_Pay_by_Ref02Completed As Update_Status_Pay_by_Ref02CompletedEventHandler
        
        '''<remarks/>
        Public Event Update_Status_Pay_by_Ref01Completed As Update_Status_Pay_by_Ref01CompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update_Status_Pay", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update_Status_Pay(ByVal ref1 As String, ByVal ref2 As String)
            Me.Invoke("Update_Status_Pay", New Object() {ref1, ref2})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_PayAsync(ByVal ref1 As String, ByVal ref2 As String)
            Me.Update_Status_PayAsync(ref1, ref2, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_PayAsync(ByVal ref1 As String, ByVal ref2 As String, ByVal userState As Object)
            If (Me.Update_Status_PayOperationCompleted Is Nothing) Then
                Me.Update_Status_PayOperationCompleted = AddressOf Me.OnUpdate_Status_PayOperationCompleted
            End If
            Me.InvokeAsync("Update_Status_Pay", New Object() {ref1, ref2}, Me.Update_Status_PayOperationCompleted, userState)
        End Sub
        
        Private Sub OnUpdate_Status_PayOperationCompleted(ByVal arg As Object)
            If (Not (Me.Update_Status_PayCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Update_Status_PayCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update_Status_Pay_Repeat", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update_Status_Pay_Repeat(ByVal ref1 As String, ByVal ref2 As String, ByVal is_repeat As Boolean)
            Me.Invoke("Update_Status_Pay_Repeat", New Object() {ref1, ref2, is_repeat})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_RepeatAsync(ByVal ref1 As String, ByVal ref2 As String, ByVal is_repeat As Boolean)
            Me.Update_Status_Pay_RepeatAsync(ref1, ref2, is_repeat, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_RepeatAsync(ByVal ref1 As String, ByVal ref2 As String, ByVal is_repeat As Boolean, ByVal userState As Object)
            If (Me.Update_Status_Pay_RepeatOperationCompleted Is Nothing) Then
                Me.Update_Status_Pay_RepeatOperationCompleted = AddressOf Me.OnUpdate_Status_Pay_RepeatOperationCompleted
            End If
            Me.InvokeAsync("Update_Status_Pay_Repeat", New Object() {ref1, ref2, is_repeat}, Me.Update_Status_Pay_RepeatOperationCompleted, userState)
        End Sub
        
        Private Sub OnUpdate_Status_Pay_RepeatOperationCompleted(ByVal arg As Object)
            If (Not (Me.Update_Status_Pay_RepeatCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Update_Status_Pay_RepeatCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update_Status_Pay_RepeatOnly", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update_Status_Pay_RepeatOnly(ByVal ref1 As String, ByVal ref2 As String)
            Me.Invoke("Update_Status_Pay_RepeatOnly", New Object() {ref1, ref2})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_RepeatOnlyAsync(ByVal ref1 As String, ByVal ref2 As String)
            Me.Update_Status_Pay_RepeatOnlyAsync(ref1, ref2, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_RepeatOnlyAsync(ByVal ref1 As String, ByVal ref2 As String, ByVal userState As Object)
            If (Me.Update_Status_Pay_RepeatOnlyOperationCompleted Is Nothing) Then
                Me.Update_Status_Pay_RepeatOnlyOperationCompleted = AddressOf Me.OnUpdate_Status_Pay_RepeatOnlyOperationCompleted
            End If
            Me.InvokeAsync("Update_Status_Pay_RepeatOnly", New Object() {ref1, ref2}, Me.Update_Status_Pay_RepeatOnlyOperationCompleted, userState)
        End Sub
        
        Private Sub OnUpdate_Status_Pay_RepeatOnlyOperationCompleted(ByVal arg As Object)
            If (Not (Me.Update_Status_Pay_RepeatOnlyCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Update_Status_Pay_RepeatOnlyCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update_Status_Pay_by_Ref02", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update_Status_Pay_by_Ref02(ByVal ref2 As String)
            Me.Invoke("Update_Status_Pay_by_Ref02", New Object() {ref2})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_by_Ref02Async(ByVal ref2 As String)
            Me.Update_Status_Pay_by_Ref02Async(ref2, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_by_Ref02Async(ByVal ref2 As String, ByVal userState As Object)
            If (Me.Update_Status_Pay_by_Ref02OperationCompleted Is Nothing) Then
                Me.Update_Status_Pay_by_Ref02OperationCompleted = AddressOf Me.OnUpdate_Status_Pay_by_Ref02OperationCompleted
            End If
            Me.InvokeAsync("Update_Status_Pay_by_Ref02", New Object() {ref2}, Me.Update_Status_Pay_by_Ref02OperationCompleted, userState)
        End Sub
        
        Private Sub OnUpdate_Status_Pay_by_Ref02OperationCompleted(ByVal arg As Object)
            If (Not (Me.Update_Status_Pay_by_Ref02CompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Update_Status_Pay_by_Ref02Completed(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update_Status_Pay_by_Ref01", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update_Status_Pay_by_Ref01(ByVal ref1 As String)
            Me.Invoke("Update_Status_Pay_by_Ref01", New Object() {ref1})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_by_Ref01Async(ByVal ref1 As String)
            Me.Update_Status_Pay_by_Ref01Async(ref1, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub Update_Status_Pay_by_Ref01Async(ByVal ref1 As String, ByVal userState As Object)
            If (Me.Update_Status_Pay_by_Ref01OperationCompleted Is Nothing) Then
                Me.Update_Status_Pay_by_Ref01OperationCompleted = AddressOf Me.OnUpdate_Status_Pay_by_Ref01OperationCompleted
            End If
            Me.InvokeAsync("Update_Status_Pay_by_Ref01", New Object() {ref1}, Me.Update_Status_Pay_by_Ref01OperationCompleted, userState)
        End Sub
        
        Private Sub OnUpdate_Status_Pay_by_Ref01OperationCompleted(ByVal arg As Object)
            If (Not (Me.Update_Status_Pay_by_Ref01CompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent Update_Status_Pay_by_Ref01Completed(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub Update_Status_PayCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Update_Status_Pay_RepeatCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Update_Status_Pay_RepeatOnlyCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Update_Status_Pay_by_Ref02CompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub Update_Status_Pay_by_Ref01CompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
End Namespace
