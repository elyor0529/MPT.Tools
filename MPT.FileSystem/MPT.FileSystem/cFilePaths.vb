Option Strict On
Option Explicit On

Imports MPT.FileSystem.PathLibrary

''' <summary>
''' Class representing a paths to files.
''' </summary>
''' <remarks></remarks>
Public Class cFilePaths

#Region "Properties"
    ''' <summary>
    ''' The source folder from which the file paths are generated.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property folderSource As String

    ''' <summary>
    ''' File paths to all files within a specified directory and all subdirectories.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pathsAll As New List(Of cPath)

    ''' <summary>
    ''' File extension used to filter the list of paths to all files within a source folder and all sub-folders.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property fileExtensionFilter As String

    ''' <summary>
    ''' File paths to all files in the pathsAll collection that are filtered by file extension.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pathsFiltered As New List(Of cPath)

    ''' <summary>
    ''' File paths to all files in the pathsAll collection that are selected to have XML files and examples generated for them.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pathsSelected As New List(Of cPath)

#End Region

#Region "Initialization"
    Friend Sub New()

    End Sub

    ''' <summary>
    ''' Autogenerates a list of file paths with the list of file paths.
    ''' </summary>
    ''' <param name="filePathsTemp">List of file paths to add to the class.</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal filePathsTemp As List(Of String))
        InitializeFilePaths(filePathsTemp)
    End Sub

    ''' <summary>
    ''' Autogenerates a list of all of the file paths contained within the directory path provided.
    ''' </summary>
    ''' <param name="myFolderSource">Directory path from which a list of file paths is to be generated.</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal myFolderSource As String)
        InitializeFolderSource(myFolderSource)
    End Sub


    ''' <summary>
    ''' Autogenerates a list of file paths with the list of file paths.
    ''' </summary>
    ''' <param name="filePathsTemp">List of file paths to add to the class.</param>
    ''' <remarks></remarks>
    Private Sub InitializeFilePaths(ByVal filePathsTemp As List(Of String))
        createPathObjects(filePathsTemp)
    End Sub

    ''' <summary>
    ''' Autogenerates a list of all of the file paths contained within the directory path provided.
    ''' </summary>
    ''' <param name="myFolderSource">Directory path from which a list of file paths is to be generated.</param>
    ''' <remarks></remarks>
    Private Sub InitializeFolderSource(ByVal myFolderSource As String)
        Dim filePaths As New List(Of String)

        folderSource = myFolderSource
        filePaths = ListFilePathsInDirectory(myFolderSource, True, , , False)

        If filePaths IsNot Nothing Then
            filePaths.Sort()
            createPathObjects(filePaths)
        End If
    End Sub

#End Region

#Region "Methods: Friend"
    ''' <summary>
    ''' Removes the supplied example path object from the list of selected paths.
    ''' </summary>
    ''' <param name="p_pathSelectedToRemove">Example path object to remove from the list.</param>
    ''' <remarks></remarks>
    Public Sub RemovePathSelected(ByVal p_pathSelectedToRemove As cPath)
        Dim newPathsSelected As New List(Of cPath)

        For Each pathSelected As cPath In pathsSelected
            If Not pathSelected.fileName = p_pathSelectedToRemove.fileName Then
                newPathsSelected.Add(pathSelected)
            End If
        Next

        pathsSelected = newPathsSelected
    End Sub

    ''' <summary>
    ''' Removes the corresponding example path object from the list of selected paths.
    ''' </summary>
    ''' <param name="p_fileNameSelectedToRemove">File name of the example path object to remove.</param>
    ''' <remarks></remarks>
    Public Sub RemovePathSelectedByFileName(ByVal p_fileNameSelectedToRemove As String)
        Dim newPathsSelected As New List(Of cPath)

        For Each pathSelected As cPath In pathsSelected
            If Not pathSelected.fileName = p_fileNameSelectedToRemove Then
                newPathsSelected.Add(pathSelected)
            End If
        Next

        pathsSelected = newPathsSelected
    End Sub

    ''' <summary>
    ''' Removes the corresponding example path object from the list of selected paths.
    ''' </summary>
    ''' <param name="p_pathSelectedToRemove">Path of the example path object to remove.</param>
    ''' <remarks></remarks>
    Public Sub RemovePathSelectedByPath(ByVal p_pathSelectedToRemove As String)
        Dim newPathsSelected As New List(Of cPath)

        For Each pathSelected As cPath In pathsSelected
            If Not pathSelected.path = p_pathSelectedToRemove Then
                newPathsSelected.Add(pathSelected)
            End If
        Next

        pathsSelected = newPathsSelected
    End Sub

    ''' <summary>
    ''' Updates the paths list with the filtered list of files. Also updates the relative paths list, for indicating files in subfolders.
    ''' </summary>
    ''' <param name="p_fileExtension">File extension used to filter the file paths.</param>
    ''' <param name="p_removeFilesWithMCxml">Optional: If true, paths will be searched for XMl files that have corresponding model files. Those files will be removed.</param>
    ''' <remarks></remarks>
    Public Sub SetPathsFiltered(ByVal p_fileExtension As String,
                                Optional ByVal p_filesFilter As IFileFilter = Nothing,
                                Optional ByVal p_removeFilesWithMCxml As Boolean = False)
        Dim matchingFiles As New List(Of cPath)
        Dim filematch As Boolean

        If String.IsNullOrEmpty(p_fileExtension) Then Exit Sub

        fileExtensionFilter = p_fileExtension
        pathsFiltered = New List(Of cPath)

        'Generate list of files to ignore
        If p_filesFilter IsNot Nothing Then
            matchingFiles = p_filesFilter.MatchingFiles(pathsAll)
        End If

        'Update filtered list of path objects based on the file extension
        For Each myPathObject As cPath In pathsAll
            If myPathObject.fileExtension IsNot Nothing Then
                If StringsMatch(myPathObject.fileExtension, p_fileExtension) Then
                    filematch = False

                    'Check against list of ignored files
                    If p_removeFilesWithMCxml Then
                        For Each file As cPath In matchingFiles
                            If file.path = myPathObject.path Then
                                filematch = True
                                Exit For
                            End If
                        Next
                    End If
                    If Not filematch Then pathsFiltered.Add(myPathObject)
                End If
            End If
        Next

        'Get path stubs for any files in the parent folder that lie in different sub folders
        If pathsFiltered.Count > 0 Then
            GetSourceFolder()

            'Update relative paths, which indicates files that are in subfolders
            If Not String.IsNullOrEmpty(folderSource) Then
                For Each pathFiltered As cPath In pathsFiltered
                    pathFiltered.SetPathChildStub(folderSource)
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Creates a list of the path objects that are selected to be turned into examples.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPathsSelected()
        pathsSelected = New List(Of cPath)

        'Update filtered list of path objects based on the file extension
        For Each pathFiltered As cPath In pathsFiltered
            If pathFiltered.isSelected Then pathsSelected.Add(pathFiltered)
        Next

    End Sub


    ''' <summary>
    ''' Determine the shared parent directory of all filtered path objects. 
    ''' Checks all paths in the list of path objects and returns the longest path that is shared among all of the paths.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetSourceFolder()
        If pathsFiltered.Count = 1 Then
            folderSource = pathsFiltered(0).directory
        ElseIf pathsFiltered.Count > 1 Then
            Dim directories As New List(Of String)
            For Each pathFiltered As cPath In pathsFiltered
                directories.Add(pathFiltered.directory)
            Next
            If directories.Count > 0 Then
                'Get longest path
                Dim maxCount As Integer
                Dim maxPath As String = ""
                For Each pathDir As String In directories
                    If maxCount < Len(pathDir) Then
                        maxCount = Len(pathDir)
                        maxPath = pathDir
                    End If
                Next

                Dim sharedPath As Boolean = True
                Dim currentCharacter As String = ""
                For i = 1 To maxCount
                    currentCharacter = Mid(maxPath, i, 1)
                    For Each pathDir As String In directories
                        If Not currentCharacter = Mid(pathDir, i, 1) Then
                            sharedPath = False
                            Exit For
                        End If
                    Next
                    If Not sharedPath Then
                        folderSource = Left(maxPath, i - 1)
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Returns a list of all of the paths of the files filtered by file extension.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPathsFiltered() As List(Of String)
        Dim newPathsFiltered As New List(Of String)

        For Each pathFiltered As cPath In pathsFiltered
            newPathsFiltered.Add(pathFiltered.path)
        Next

        Return newPathsFiltered
    End Function

    ''' <summary>
    ''' Returns a list of all of the relative paths of the files filtered by file extension.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPathStubsFiltered() As List(Of String)
        Dim pathStubsFiltered As New List(Of String)

        For Each pathFiltered As cPath In pathsFiltered
            pathStubsFiltered.Add(pathFiltered.pathChildStub)
        Next

        Return pathStubsFiltered
    End Function

    ''' <summary>
    ''' Returns a list of all of the paths of the files selected to be turned into examples.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPathsSelected() As List(Of String)
        Dim newPathsSelected As New List(Of String)

        For Each pathSelected As cPath In pathsSelected
            newPathsSelected.Add(pathSelected.path)
        Next

        Return newPathsSelected
    End Function

    ''' <summary>
    ''' Returns a list of all of the relative paths of the files selected.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPathStubsSelected() As List(Of String)
        Dim pathStubsSelected As New List(Of String)

        For Each pathSelected As cPath In pathsSelected
            pathStubsSelected.Add(pathSelected.pathChildStub)
        Next

        Return pathStubsSelected
    End Function

    ''' <summary>
    ''' Returns a list of all of the file names of the files filtered by file extension.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileNamesFiltered() As List(Of String)
        Dim fileNamesFiltered As New List(Of String)

        For Each pathFiltered As cPath In pathsFiltered
            fileNamesFiltered.Add(pathFiltered.fileName)
        Next

        Return fileNamesFiltered
    End Function

    ''' <summary>
    ''' Returns a list of all of the relative paths of the files filtered by file extension.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRelativePathsFiltered() As List(Of String)
        Dim relativePathsFiltered As New List(Of String)

        If pathsFiltered.Count = 1 Then
            relativePathsFiltered.Add(pathsFiltered(0).fileName)
        Else
            For Each pathFiltered As cPath In pathsFiltered
                If String.IsNullOrEmpty(pathFiltered.pathChildStub) Then
                    relativePathsFiltered.Add(pathFiltered.fileName)
                Else
                    relativePathsFiltered.Add(pathFiltered.pathChildStub & "\" & pathFiltered.fileName)
                End If
            Next

        End If
        Return relativePathsFiltered
    End Function


    ''' <summary>
    ''' Checks if the current example path object contains a valid file path.
    ''' </summary>
    ''' <param name="p_path">Example path object to check.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function IsValidFilePath(ByVal p_path As cPath) As Boolean
        Return p_path.isValidPath
    End Function

#End Region

#Region "Methods: Private"
    ''' <summary>
    ''' Creates the class objects associated with each path in a list.
    ''' </summary>
    ''' <param name="p_filePaths">List of file paths to create file objects from.</param>
    ''' <remarks></remarks>
    Protected Sub createPathObjects(ByVal p_filePaths As List(Of String))
        For Each path As String In p_filePaths
            Dim myPathObject As New cPath(path)
            pathsAll.Add(myPathObject)
        Next
    End Sub
#End Region

End Class
