Option Explicit On
Option Strict On

Public NotInheritable Class MessengerPrompt
    Shared Event Message(messenger As MessengerEventArgs)

    Private Sub New()
        ' Class only has shared methods
    End Sub

    Public Shared Function Prompt(ByVal messageDetails As MessageDetails,
                                  ByVal message As String,
                                  ByVal title As String,
                                  ParamArray arg() As Object) As eMessageActions
        Dim e As New MessengerEventArgs(messageDetails,
                                        message,
                                        title,
                                        arg)
        RaiseEvent Message(e)
        Return e.Action
    End Function
End Class
