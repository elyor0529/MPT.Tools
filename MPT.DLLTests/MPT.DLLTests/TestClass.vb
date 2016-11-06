Option Strict On
Option Explicit On

Imports MPT.Reporting
Imports MPT.Reflections.ReflectionLibrary

Public Class TestClass
    Public Event Log(exception As LoggerEventArgs)

    'Private WithEvents _child As TestClass

    Sub Test(ByVal p_string As String)
        Dim logMessage As New LoggerEventArgs(New Exception(),
                                                NameOfParam(Function() p_string), p_string)

        RaiseEvent Log(logMessage)
    End Sub

    Sub TestMulti(ByVal p_string As String,
                  ByVal p_name As String,
                  ByVal p_number As Integer)

        RaiseEvent Log(New LoggerEventArgs(New Exception(),
                                            NameOfParam(Function() p_string), p_string,
                                            NameOfParam(Function() p_name), p_name,
                                            NameOfParam(Function() p_number), p_number))

    End Sub
    Sub TestList(ByVal p_list As List(Of String))
        RaiseEvent Log(New LoggerEventArgs(New Exception(),
                                            NameOfParam(Function() p_list), p_list))
    End Sub
    Sub TestAll(ByVal p_string As String,
                  ByVal p_name As String,
                  ByVal p_number As Integer,
                  ByVal p_list As List(Of String),
                  ByVal p_double As Double,
                  ByVal p_toBeOrNotToBe As Boolean)
        RaiseEvent Log(New LoggerEventArgs(New Exception(),
                                            NameOfParam(Function() p_string), p_string,
                                            NameOfParam(Function() p_name), p_name,
                                            NameOfParam(Function() p_number), p_number,
                                            NameOfParam(Function() p_list), p_list,
                                            NameOfParam(Function() p_double), p_double,
                                            NameOfParam(Function() p_toBeOrNotToBe), p_toBeOrNotToBe))
    End Sub
    Sub TestException(ByVal p_string As String,
                  ByVal p_name As String,
                  ByVal p_number As Integer,
                  ByVal p_list As List(Of String),
                  ByVal p_double As Double,
                  ByVal p_toBeOrNotToBe As Boolean)
        Try
            Throw New Exception("FUBAR")
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                            NameOfParam(Function() p_string), p_string,
                                            NameOfParam(Function() p_name), p_name,
                                            NameOfParam(Function() p_number), p_number,
                                            NameOfParam(Function() p_list), p_list,
                                            NameOfParam(Function() p_double), p_double,
                                            NameOfParam(Function() p_toBeOrNotToBe), p_toBeOrNotToBe))
        End Try
    End Sub
End Class
