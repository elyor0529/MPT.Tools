Option Strict On
Option Explicit On

''' <summary>
''' Event argument that relays a message from the libraries to an external assembly.
''' </summary>
''' <remarks></remarks>
Public Class MessengerEventArgs
    Inherits EventArgs


    Private _title As String
    ''' <summary>
    ''' Title of the message associated with the event.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Title As String
        Get
            Return _title
        End Get
    End Property

    Private _message As String
    ''' <summary>
    ''' Message associated with the event.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Message As String
        Get
            Return _message
        End Get
    End Property

    ''' <summary>
    ''' True: The event has already been handled.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Handled As Boolean

    Private _messageDetails As New MessageDetails()
    ''' <summary>
    ''' If a console or message box prompt is used to display the message data, the choice can be recorded here.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Action As eMessageActions
        Get
            Return _messageDetails.Action
        End Get
        Set(value As eMessageActions)
            _messageDetails.Action = value
        End Set
    End Property

    ''' <summary>
    ''' Decision combination types to display with the message.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ActionSet As eMessageActionSets
        Get
            Return _messageDetails.ActionSet
        End Get
    End Property

    ''' <summary>
    ''' Type of message.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MessageType As eMessageType
        Get
            Return _messageDetails.MessageType
        End Get
    End Property

    ''' <summary>
    ''' Default action to take.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ActionDefault As eMessageActions
        Get
            Return _messageDetails.ActionDefault
        End Get
    End Property



    ''' <summary>
    ''' Initializer.
    ''' </summary>
    ''' <param name="message">Message associated with the event.</param>
    ''' <param name="arg">List of variables to insert into the message.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal message As String,
                   ParamArray arg() As Object)
        _message = String.Format(message, arg)
    End Sub

    ''' <summary>
    ''' Initializer.
    ''' </summary>
    ''' <param name="message">Message associated with the event.</param>
    ''' <param name="arg">List of variables to insert into the message.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal title As String,
                   ByVal message As String,
                   ParamArray arg() As Object)
        _title = title
        _message = String.Format(message, arg)
    End Sub

    ''' <summary>
    ''' Initializer.
    ''' </summary>
    ''' <param name="message">Message associated with the event.</param>
    ''' <param name="arg">List of variables to insert into the message.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal messageDetails As MessageDetails,
                   ByVal message As String,
                   ParamArray arg() As Object)
        _messageDetails = messageDetails
        _message = String.Format(message, arg)
    End Sub

    ''' <summary>
    ''' Initializer.
    ''' </summary>
    ''' <param name="message">Message associated with the event.</param>
    ''' <param name="arg">List of variables to insert into the message.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal messageDetails As MessageDetails,
                   ByVal message As String,
                   ByVal title As String,
                   ParamArray arg() As Object)
        _messageDetails = messageDetails
        _title = title
        _message = String.Format(message, arg)
    End Sub
End Class
