Option Strict On
Option Explicit On

Imports System.Windows.Input

''' <summary>
''' Cursor that appears over a segment of time determined by toggling the cursor on or off.
''' </summary>
''' <remarks></remarks>
Public Class cCursorWait
#Region "Variables"
    Private _waitCursor As Boolean
#End Region

#Region "Initialization"
    ''' <summary>
    ''' Class constructor.
    ''' </summary>
    ''' <param name="start">True: Wait cursor will begin upon class initialization.</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal start As Boolean = True)
        If start Then StartCursor()
    End Sub
#End Region

#Region "Methods"

    ''' <summary>
    ''' Starts the wait cursor if one is not currently set. This status is recorded in the class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartCursor()
        If Not waitCursorIsActive() Then
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait
            _waitCursor = True
        Else
            _waitCursor = False
        End If
    End Sub

    ''' <summary>
    ''' If the class has started a wait cursor, the class will then end it.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndCursor()
        If _waitCursor Then Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow
    End Sub
#End Region

#Region "Methods: Private"
    ''' <summary>
    ''' True: Wait cursor is running or set to be running in the current class.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function waitCursorIsActive() As Boolean
        Return (_waitCursor OrElse
                Mouse.OverrideCursor Is System.Windows.Input.Cursors.Wait)
    End Function
#End Region

End Class