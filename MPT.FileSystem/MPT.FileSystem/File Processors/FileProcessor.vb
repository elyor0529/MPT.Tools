Option Strict On
Option Explicit On

Imports MPT.Reflections.ReflectionLibrary
Imports MPT.Reporting

Namespace FileProcessor
    ''' <summary>
    ''' Abstract class that forms the basis for processing a file based on provided criterie via the Strategy Pattern.
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class FileProcessor
        Implements IProcessFile

        Shared Event Logger(message As MessengerEventArgs)

        ''' <summary>
        ''' Processes the file according to criteria.
        ''' </summary>
        ''' <param name="path">Path to the file to process.</param>
        ''' <remarks></remarks>
        Public Overridable Sub ProcessFile(path As String) Implements IProcessFile.ProcessFile
            RaiseEvent Logger(New MessengerEventArgs("Processed file '{0}'.", path))
        End Sub
    End Class
End Namespace
