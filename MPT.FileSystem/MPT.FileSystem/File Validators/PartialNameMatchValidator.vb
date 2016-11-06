Option Strict On
Option Explicit On

Imports MPT.FileSystem.PathLibrary

Namespace FileValidator
    ''' <summary>
    ''' Determines whether or not a file is valid based on partially matching file name.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PartialNameMatchValidator
        Implements IValidateFile

        Private _name As String
        ''' <summary>
        ''' File name, with no extension.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Name As String
            Get
                Return _name
            End Get
        End Property

        Private _excludeFile As Boolean
        ''' <summary>
        ''' True: Matching criteria will exclude the file.
        ''' False: Matching criteria will include the file.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ExcludeFile As Boolean Implements IValidateFile.ExcludeFile
            Get
                Return _excludeFile
            End Get
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="name">File name, without extension.</param>
        ''' <param name="excludeFile">True: Matching criteria will exclude the file.
        ''' False: Matching criteria will include the file.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal name As String,
                       Optional ByVal excludeFile As Boolean = False)
            _name = name
            _excludeFile = excludeFile
        End Sub

        ''' <summary>
        ''' True: File is a valid file based on the selection criteria.
        ''' </summary>
        ''' <param name="path">Path to the file to validate.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValidFile(path As String) As Boolean Implements IValidateFile.IsValidFile
            If Not _excludeFile Then
                'Add the file path to the list if it matches the specified criteria
                Return StringExistInName(GetPathFileName(path, True), GetPathFileName(_name, True))
            Else
                'Add any file path to the list so long as it does not match the specified criteria
                Return Not StringExistInName(GetPathFileName(path, True), GetPathFileName(_name, True))
            End If
        End Function
    End Class
End Namespace

