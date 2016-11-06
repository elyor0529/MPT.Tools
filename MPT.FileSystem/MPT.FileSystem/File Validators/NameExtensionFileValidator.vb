Option Strict On
Option Explicit On

Imports MPT.FileSystem.PathLibrary

Namespace FileValidator
    ''' <summary>
    ''' Determines whether or not a file is valid based on matching file name and/or extension.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NameExtensionFileValidator
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

        Private _extension As String
        ''' <summary>
        ''' File extension.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Extension As String
            Get
                Return _extension
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
        ''' <param name="extension">File extension.</param>
        ''' <param name="excludeFile">True: Matching criteria will exclude the file.
        ''' False: Matching criteria will include the file.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal name As String,
                       ByVal extension As String,
                       Optional ByVal excludeFile As Boolean = False)
            _name = name
            _extension = extension
            _excludeFile = excludeFile
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nameWithExtension">File name, with extension.</param>
        ''' <param name="excludeFile">True: Matching criteria will exclude the file.
        ''' False: Matching criteria will include the file.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal nameWithExtension As String,
                       Optional ByVal excludeFile As Boolean = False)
            _name = FileNameWithoutExtension(Name)
            _extension = GetSuffix(Extension, ".")
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
                Return FileNameExtensionMatch(path, _name, _extension)
            Else
                'Add any file path to the list so long as it does not match the specified criteria
                Return Not FileNameExtensionMatch(path, _name, _extension)
            End If
        End Function
    End Class
End Namespace

