Option Strict On
Option Explicit On

Imports System.Windows

''' <summary>
''' Verifies aspects of various Structs.
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class StructValidation
    Private Sub New()
        'Contains only shared members.
        'Private constructor means the class cannot be instantiated.
    End Sub

    ''' <summary>
    ''' Determines whether the coordinate struct is empty.
    ''' </summary>
    ''' <param name="p_point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PointIsEmpty(ByVal p_point As Point) As Boolean
        If p_point.X = 0 AndAlso p_point.Y = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Determines if struct IntPtr is empty.
    ''' </summary>
    ''' <param name="p_intPtr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IntPtrIsEmpty(ByVal p_intPtr As IntPtr) As Boolean
        If p_intPtr.ToInt32 = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
