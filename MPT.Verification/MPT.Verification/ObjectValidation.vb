Option Strict On
Option Explicit On

Imports System.Windows

Imports MPT.Reporting
Imports MPT.Reflections.ReflectionLibrary

''' <summary>
''' Verifies various aspects of objects.
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class ObjectValidation
    Shared Event Log(exception As LoggerEventArgs)

    Private Sub New()
        'Contains only shared members.
        'Private constructor means the class cannot be instantiated.
    End Sub

#Region "Methods"
    ''' <summary>
    ''' Returns 'True' if object is not nothing.
    ''' </summary>
    ''' <param name="p_object">Any object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidObject(ByVal p_object As Object) As Boolean
        IsValidObject = False
        Try
            If p_object IsNot Nothing Then
                IsValidObject = True
            End If
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_object), p_object))
        End Try
    End Function

    ''' <summary>
    ''' Returns 'True' if object is not empty or DB Null.
    ''' </summary>
    ''' <param name="p_object">Any object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidObjectDB(ByVal p_object As Object) As Boolean
        IsValidObjectDB = False
        Try
            If Not IsDBNull(p_object) Then
                If p_object IsNot Nothing Then
                    IsValidObjectDB = True
                End If
            End If
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_object), p_object))
        End Try
    End Function

    ''' <summary>
    ''' Returns 'True' if object is not empty or DB Null, and the value is not blank.
    ''' </summary>
    ''' <param name="p_object">Any object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidObjectDBStringFilled(ByVal p_object As Object) As Boolean
        IsValidObjectDBStringFilled = False
        Try
            If Not IsDBNull(p_object) Then
                If p_object IsNot Nothing Then
                    If Not String.IsNullOrEmpty(p_object.ToString) Then
                        IsValidObjectDBStringFilled = True
                    End If
                End If
            End If
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_object), p_object))
        End Try
    End Function

    ''' <summary>
    ''' Returns 'True' if object is not empty or DB Null, and the value is blank.
    ''' </summary>
    ''' <param name="p_object">Any object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidObjectDBStringEmpty(ByVal p_object As Object) As Boolean
        IsValidObjectDBStringEmpty = False
        Try
            If Not IsDBNull(p_object) Then
                If p_object IsNot Nothing Then
                    If String.IsNullOrEmpty(p_object.ToString) Then
                        IsValidObjectDBStringEmpty = True
                    End If
                End If
            End If
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_object), p_object))
        End Try
    End Function
#End Region
End Class
