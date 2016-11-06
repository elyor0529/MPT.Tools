Option Strict On
Option Explicit On

Imports System.IO

Imports System.Windows

Imports MPT.Cursors
Imports MPT.FileSystem.PathLibrary
Imports MPT.Reflections.ReflectionLibrary
Imports MPT.Reporting

''' <summary>
''' Contains routines for working with folders and file locations within folders. 
''' Used for folder/file renaming, deleting, locating, relocating, etc.
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class FoldersLibrary
    Shared Event Log(exception As LoggerEventArgs)
    Shared Event Messenger(message As MessengerEventArgs)

    Private Sub New()
        'Contains only shared members.
        'Private constructor means the class cannot be instantiated.
    End Sub

#Region "Querying"
    ''' <summary>
    ''' Performs a variety of folder and file creation and deletion tests to see if the program has read/write access to a folder.
    ''' </summary>
    ''' <param name="p_pathDir">Path of the directory that is being checked.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadableWriteableDeletableDirectory(ByVal p_pathDir As String) As Boolean
        If Not Directory.Exists(p_pathDir) Then Return False

        Try
            Dim pathTemp As String = p_pathDir & "\ReadableWriteableDeletableDirectory"

            'Test Folder Creation
            ComponentCreateDirectory(pathTemp)
            If Not Directory.Exists(pathTemp) Then Return False

            'Test Folder Deletion
            ComponentDeleteDirectoryAction(pathTemp, True)
            If Directory.Exists(pathTemp) Then Return False

            'Test File Creation
            pathTemp = p_pathDir & "\ReadableWriteableDeletableDirectory.ini"
            Using objWriter As New System.IO.StreamWriter(pathTemp)
                objWriter.WriteLine("$ " & "C:\Verification")
            End Using
            If Not File.Exists(pathTemp) Then Return False

            'Test File Delete
            ComponentDeleteFileAction(pathTemp)
            If File.Exists(pathTemp) Then Return False
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_pathDir), p_pathDir))
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Gets all sub-directory folders and adds them to a supplied list of paths.
    ''' </summary>
    ''' <param name="p_startPath">Path to the parent directory to begin the check.</param>
    ''' <param name="p_directoryList">List of paths to populate with directory names.</param>
    ''' <param name="p_listSubDirectories">True: All subdirectories will be listed. 
    ''' False: Only the highest level of subdirectories will be listed.</param>
    ''' <remarks></remarks>
    Public Shared Sub GetDirectories(ByVal p_startPath As String,
                                     ByRef p_directoryList As List(Of String),
                                     Optional ByVal p_listSubDirectories As Boolean = True)
        Try
            Dim directories() As String = Directory.GetDirectories(p_startPath)

            For Each Dir As String In directories
                p_directoryList.Add(Dir)
            Next

            If p_listSubDirectories Then
                For Each Dir As String In directories
                    GetDirectories(Dir, p_directoryList)
                Next
            End If
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_startPath), p_startPath,
                                               NameOfParam(Function() p_listSubDirectories), p_listSubDirectories))
        End Try
    End Sub

    ''' <summary>
    ''' Lists the paths of all of the folders and subfolders within the specified directory.
    ''' </summary>
    ''' <param name="p_path">Path to the directory to check.</param>
    ''' <param name="p_folderName">Only paths for the specified folder name will be returned.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ListFoldersInFolder(ByVal p_path As String,
                                               Optional p_folderName As String = "") As List(Of String)

        Dim DirList As New List(Of String)
        GetDirectories(p_path, DirList)

        'If a Folder name is specified, trim the list to only include these names
        If Not String.IsNullOrEmpty(p_folderName) Then
            Dim DirListFolder As String
            Dim DirListTemp As New List(Of String)

            For Each myFolder As String In DirList
                DirListFolder = GetSuffix(myFolder, "\")
                If DirListFolder = p_folderName Then
                    DirListTemp.Add(myFolder)
                End If
            Next

            'Clears the first list of folders and assigns it to the reduced list
            DirList.Clear()
            DirList = DirListTemp
        End If

        Return DirList

    End Function

    ''' <summary>
    ''' Returns 'true' if a directory contains files.
    ''' </summary>
    ''' <param name="p_pathDir">Path to the directory to check.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DirContainsFiles(ByVal p_pathDir As String) As Boolean
        Dim myDir As DirectoryInfo = New DirectoryInfo(p_pathDir)

        Return myDir.EnumerateFiles().Any()
    End Function

    ''' <summary>
    ''' True if a directory contains directories.
    ''' </summary>
    ''' <param name="p_pathDir">Path to the directory to check.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DirContainsDirs(ByVal p_pathDir As String) As Boolean
        Dim myDir As DirectoryInfo = New DirectoryInfo(p_pathDir)

        Return myDir.EnumerateFiles().Any()
    End Function
#End Region

#Region "Naming"
    ''' <summary>
    ''' Renames a file.
    ''' </summary>
    ''' <param name="p_path">Path to file to renamed, including the file name and extension.</param>
    ''' <param name="p_newName">New file name and extension.</param>
    ''' <remarks></remarks>
    Public Shared Sub RenameFile(ByVal p_path As String,
                                 ByVal p_newName As String)
        'Exits sub if name already exists
        If GetSuffix(p_path, "\") = p_newName Then Exit Sub

        Try
            My.Computer.FileSystem.RenameFile(p_path, p_newName)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_path), p_path,
                                               NameOfParam(Function() p_newName), p_newName))
        End Try
    End Sub

    ''' <summary>
    ''' Renames a folder.
    ''' </summary>
    ''' <param name="p_path">Path to folder to renamed, including the folder name.</param>
    ''' <param name="p_newName">New folder name.</param>
    ''' <remarks></remarks>
    Public Shared Sub RenameFolder(ByVal p_path As String,
                                   ByVal p_newName As String)
        Try
            My.Computer.FileSystem.RenameDirectory(p_path, p_newName)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_path), p_path,
                                               NameOfParam(Function() p_newName), p_newName))
        End Try
    End Sub
#End Region

#Region "Read Only Attributes"
    ''' <summary>
    ''' Sets all files in a folder and subfolders to not be read only.
    ''' </summary>
    ''' <param name="p_sourceFolderName">Path to the highest level folder to apply the readable overwrite to.</param>
    ''' <remarks>'Modified from Leith Ross http://www.excelforum.com/excel-programming/645683-list-files-in-folder.html </remarks>
    Public Shared Sub SetDirectoryFilesNotReadOnly(ByVal p_sourceFolderName As String)
        Dim files As List(Of String) = ListFilePathsInDirectory(p_sourceFolderName, p_includeSubFolders:=True)

        'Sets each file to not be read only
        For Each file As String In files
            ComponentSetAttributeAction(file, FileAttributes.Normal)
        Next
    End Sub

    ''' <summary>
    ''' Sets a specified file to not be read only.
    ''' </summary>
    ''' <param name="p_path">File path, including the filename</param>
    ''' <remarks></remarks>
    Public Shared Sub SetFileNotReadOnly(ByVal p_path As String)
        ComponentSetAttributeAction(p_path, FileAttributes.Normal)
    End Sub

    ''' <summary>
    ''' Checks if a file has any of the Read Only attributes assigned.
    ''' </summary>
    ''' <param name="p_path">Path to the file to check.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function IsFileReadOnly(ByVal p_path As String) As Boolean
        If Not File.Exists(p_path) Then Return False

        Return (File.GetAttributes(p_path) = FileAttributes.ReadOnly OrElse
                File.GetAttributes(p_path) = 33 OrElse
                File.GetAttributes(p_path) = 8225)
    End Function
#End Region

#Region "Deleting"
    ''' <summary>
    ''' Deletes a single file of a specified path. 
    ''' Returns true if this results in the file no longer existing.
    ''' </summary>
    ''' <param name="p_path">Path to the file to be deleted.</param>
    ''' <param name="p_includeReadOnly">True: Removes read-only protection. 
    ''' False: Read-only files will not be deleted. 
    ''' Function will return False for read-only files.</param>
    ''' <remarks></remarks>
    Public Shared Function DeleteFile(ByVal p_path As String,
                                      Optional ByVal p_includeReadOnly As Boolean = False) As Boolean
        Try
            If Not File.Exists(p_path) Then Return True
            If (Not p_includeReadOnly AndAlso IsFileReadOnly(p_path)) Then Return False

            'Remove read-only attributes & delete file
            ComponentSetAttributeAction(p_path, FileAttributes.Normal)
            ComponentDeleteFileAction(p_path)

            If Not File.Exists(p_path) Then Return True
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_path), p_path,
                                               NameOfParam(Function() p_includeReadOnly), p_includeReadOnly))
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Deletes all files fitting the specified criteria. 
    ''' If no file name or extension is given, then all files will be deleted.
    ''' </summary>
    ''' <param name="p_path">Path to the parent folder containing files to be deleted.</param>
    ''' <param name="p_includeSubFolders">True: Files will be deleted in all subfolders. 
    ''' False: Files will only be deleted in the specified folder.</param>
    ''' <param name="p_fileName">All files of this name will be deleted. 
    ''' Combine with myFileExtension to limit this to files of a particular name and type.</param>
    ''' <param name="p_fileExtension">All files of this extension will be deleted.</param>
    ''' <param name="p_includeReadOnly">True: Read only files will also be deleted. 
    ''' False: Read only files will be skipped.</param>
    ''' <param name="p_fileNamesExclude">List of filenames to preserve during the delete process.</param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteFiles(ByVal p_path As String,
                                  ByVal p_includeSubFolders As Boolean,
                                  Optional ByVal p_fileName As String = "",
                                  Optional ByVal p_fileExtension As String = "",
                                  Optional ByVal p_includeReadOnly As Boolean = False,
                                  Optional ByVal p_fileNamesExclude As List(Of String) = Nothing)
        'Get list of files to delete
        Dim deleteList As New List(Of String)
        Dim cursorWait As New WaitCursor

        deleteList = ListFilePathsInDirectory(p_path, p_includeSubFolders, p_fileName, p_fileExtension)
        If deleteList Is Nothing Then Exit Sub

        'Filter out files to save from the delete list
        If p_fileNamesExclude IsNot Nothing Then
            Dim deleteListTemp As New List(Of String)
            Dim deleteFile As Boolean = True

            For Each fileToDelete As String In deleteList
                deleteFile = True
                For Each saveFile As String In p_fileNamesExclude
                    If GetPathFileName(fileToDelete) = saveFile Then
                        deleteFile = False
                        Exit For
                    End If
                Next

                If deleteFile Then deleteListTemp.Add(fileToDelete)
            Next

            deleteList = deleteListTemp
        End If

        'Delete all files in the list
        For Each myFileDelete In deleteList
            If p_includeReadOnly Then
                ComponentSetAttributeAction(myFileDelete, FileAttributes.Normal)
                ComponentDeleteFileAction(myFileDelete)
            ElseIf (File.Exists(myFileDelete) AndAlso
                    Not File.GetAttributes(myFileDelete) = FileAttributes.ReadOnly AndAlso
                    Not File.GetAttributes(myFileDelete) = 33) Then
                'Check if file is read only, and if so, skip it
                ComponentDeleteFileAction(myFileDelete)
            End If
        Next

        cursorWait.EndCursor()
    End Sub

    ''' <summary>
    ''' Deletes all files fitting the specified criteria lists. 
    ''' If no file name or extension is given, then all files will be deleted.
    ''' </summary>
    ''' <param name="p_path">Path to the parent folder containing files to be deleted.</param>
    ''' <param name="p_includeSubFolders">True: Files will be deleted in all subfolders. 
    ''' False: Files will only be deleted in the specified folder.</param>
    ''' <param name="p_fileNames">All files of the names in this list will be deleted. 
    ''' Combine with myFileExtensions to limit this to files of a particular name and type.</param>
    ''' <param name="p_fileExtensions">All files of the extensions in this list will be deleted.</param>
    ''' <param name="p_includeReadOnly">True: Read only files will also be deleted. 
    ''' False: Read only files will be skipped.</param>
    ''' <param name="p_partialNameMatch">True: A file will be considered a match for deletion by filename if the name is at least present in the overall filename. 
    ''' False: Only exact matches will be considered.</param>
    ''' <param name="p_waitCursor">True: Cursor changes to a wait cursor while the function runs.</param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteFilesBulk(ByVal p_path As String,
                                      ByVal p_includeSubFolders As Boolean,
                                      Optional ByVal p_fileNames As List(Of String) = Nothing,
                                      Optional ByVal p_fileExtensions As List(Of String) = Nothing,
                                      Optional ByVal p_includeReadOnly As Boolean = False,
                                      Optional ByVal p_partialNameMatch As Boolean = False,
                                      Optional ByVal p_waitCursor As Boolean = False)
        'Get list of files to delete
        Dim deleteList As New List(Of String)
        Dim cursorWait As New WaitCursor(p_waitCursor)

        If p_fileNames Is Nothing Then
            p_fileNames = New List(Of String)
            p_fileNames.Add("")
        End If
        If p_fileExtensions Is Nothing Then
            p_fileExtensions = New List(Of String)
            p_fileExtensions.Add("")
        End If

        'Get list of all files in the folders & subfolders (if specified)
        deleteList = ListFilePathsInDirectory(p_path, p_includeSubFolders)

        'Delete all files in the list
        For Each myFileDelete In deleteList
            If p_includeReadOnly Then
                For Each myFileName As String In p_fileNames
                    For Each myFileExtension As String In p_fileExtensions
                        If FileNameExtensionMatch(myFileDelete, myFileName, myFileExtension, p_partialNameMatch) Then
                            ComponentSetAttributeAction(myFileDelete, FileAttributes.Normal)
                            ComponentDeleteFileAction(myFileDelete)
                        End If
                    Next
                Next
            Else
                'Check if file is read only, and if so, skip it
                For Each myFileName As String In p_fileNames
                    For Each myFileExtension As String In p_fileExtensions
                        If (FileNameExtensionMatch(myFileDelete, myFileName, myFileExtension, p_partialNameMatch) AndAlso
                            File.Exists(myFileDelete) AndAlso
                            Not File.GetAttributes(myFileDelete) = FileAttributes.ReadOnly AndAlso
                            Not File.GetAttributes(myFileDelete) = 33) Then

                            ComponentDeleteFileAction(myFileDelete)
                        End If
                    Next
                Next
            End If
        Next
        cursorWait.EndCursor()
    End Sub

    ''' <summary>
    ''' Deletes all files and folders.
    ''' Specifications allow the root folder to be preserved. 
    ''' </summary>
    ''' <param name="p_path">Path to the root folder.</param>
    ''' <param name="p_deleteRootFolder">True: The root folder and all files and folders within will be deleted. 
    ''' False: Root folder is preserved but will be empty.</param>
    ''' <param name="p_folderName">Name of a specific folder to delete.</param>
    ''' <param name="p_includeReadOnly">True: Read only files and folders will also be deleted. 
    ''' False: Read only files and folders will be skipped.</param>
    ''' <param name="p_foldersPreserve">List of folder paths to preserve during the deleting process. 
    ''' Only works if not deleting the root folder.</param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteAllFilesFolders(ByVal p_path As String,
                                            ByVal p_deleteRootFolder As Boolean,
                                            Optional ByVal p_folderName As String = "",
                                            Optional ByVal p_includeReadOnly As Boolean = False,
                                            Optional ByVal p_foldersPreserve As List(Of String) = Nothing)
        Dim deleteList As New List(Of String)
        Dim cursorWait As New WaitCursor

        'Delete folders & subdirectories
        If p_deleteRootFolder Then
            deleteList.Add(p_path)
        Else
            'Delete files in root directory first
            DeleteFiles(p_path, False)

            'Create list of subdirectories to delete
            If p_foldersPreserve Is Nothing Then
                deleteList = ListFoldersInFolder(p_path, p_folderName)
            Else
                Dim deleteListTemp = ListFoldersInFolder(p_path, p_folderName)

                For Each folderPreserve As String In p_foldersPreserve
                    For Each folderDelete As String In deleteListTemp
                        If Not folderDelete = folderPreserve Then deleteList.Add(folderDelete)
                    Next
                Next
            End If

        End If

        'If any folders are specified for deleting, delete folders
        SetDirectoryFilesNotReadOnly(p_path)     'Currently function cannot skip 'read-only' portions

        If deleteList.Count > 0 Then
            For Each myFolderDelete In deleteList
                Try
                    ComponentDeleteDirectoryAction(myFolderDelete, True)
                Catch ex As Exception
                    'This is to skip the subfolders, which have been deleted by deleting the parent folders
                End Try
            Next
        End If
        cursorWait.EndCursor()
    End Sub

#End Region

#Region "Copying/Moving"
    ''' <summary>
    ''' Copies a file from one directory to another. 
    ''' If directory does not exist, directory will be created. 
    ''' Returns true if it is confirmed that a new file exists at the destination.
    ''' </summary>
    ''' <param name="p_pathSource">File path source, including the file name.</param>
    ''' <param name="p_pathDestination">File path destination, including the file name. 
    ''' If filename is different, file will be renamed.</param>
    ''' <param name="p_overWriteFile">True: If file already exists at destination, file will be overwritten.</param>
    ''' <param name="p_includeReadOnly">True: Removes read-only protection. 
    ''' False: Read-only files will not be copied.</param>
    ''' <param name="p_promptMessage">Message to display to the user if a file exists.</param>
    ''' <param name="p_waitNewFileExist">True: Code will loop within this routine until the copy action has completed. 
    ''' Recommended if reading the copied file during same process as copying the file.</param>
    ''' <param name="p_noSourceExistPrompt">True: If a source file does not exist for copying, the user is notified of this and that the copy action will not take place.</param>
    ''' <remarks></remarks>
    Public Shared Function CopyFile(ByVal p_pathSource As String,
                                    ByVal p_pathDestination As String,
                                    ByVal p_overWriteFile As Boolean,
                                    Optional ByVal p_includeReadOnly As Boolean = False,
                                    Optional ByVal p_promptMessage As String = "",
                                    Optional ByVal p_waitNewFileExist As Boolean = False,
                                    Optional ByVal p_noSourceExistPrompt As Boolean = False) As Boolean

        'Check that source file exists
        If Not File.Exists(p_pathSource) Then
            If p_noSourceExistPrompt Then
                RaiseEvent Messenger(New MessengerEventArgs("Original file does not exist. File will not be copied: {0}{1}",
                                                            Environment.NewLine, p_pathSource))
            End If
            Return False
        End If

        Try
            'Remove read-only attributes if specified
            If p_includeReadOnly Then
                ComponentSetAttributeAction(p_pathSource, FileAttributes.Normal)
                If File.Exists(p_pathDestination) Then ComponentSetAttributeAction(p_pathDestination, FileAttributes.Normal)
            End If

            'Copy if appropriate
            If (Not p_includeReadOnly AndAlso
                (IsFileReadOnly(p_pathSource) OrElse
                 IsFileReadOnly(p_pathDestination))) Then Return False
            ComponentCopyFileAction(p_pathSource, p_pathDestination, p_overWriteFile, p_promptMessage)

            'Check that a file exists at the destination
            Dim newFileExist As Boolean = False
            If p_waitNewFileExist Then
                Dim counter As Integer = 0
                'Wait until file copy action has been completed
                While Not newFileExist
                    counter += 1
                    If counter > 20 Then Exit While

                    If File.Exists(p_pathDestination) Then newFileExist = True

                    System.Threading.Thread.Sleep(500)
                End While
            Else
                Return File.Exists(p_pathDestination)
            End If

            Return True
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_pathDestination), p_pathDestination,
                                               NameOfParam(Function() p_overWriteFile), p_overWriteFile,
                                               NameOfParam(Function() p_includeReadOnly), p_includeReadOnly,
                                               NameOfParam(Function() p_promptMessage), p_promptMessage,
                                               NameOfParam(Function() p_waitNewFileExist), p_waitNewFileExist,
                                               NameOfParam(Function() p_noSourceExistPrompt), p_noSourceExistPrompt))
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Makes a duplicate folder,including sub-folders.
    ''' If the destination already exists it will overwrite existing files in this folder. 
    ''' If the destination does not exist, it will be made for you.
    ''' Returns true if all desired operations were successful.
    ''' </summary>
    ''' <param name="p_pathSource">Source directory path.</param>
    ''' <param name="p_pathDestination">Destination directory path.</param>
    ''' <param name="p_overWriteExisting">True: Destination directory and files will be overwritten if they already exist.</param>
    ''' <remarks></remarks>
    Public Shared Function CopyFolder(ByVal p_pathSource As String,
                                     ByVal p_pathDestination As String,
                                     Optional ByVal p_overWriteExisting As Boolean = False) As Boolean
        'Check that source is valid
        If Not Directory.Exists(p_pathSource) Then
            RaiseEvent Messenger(New MessengerEventArgs("{0} doesn't exist. Directory will not be copied.", p_pathSource))
            Return False
        End If

        'Check if destination already exists
        If (Directory.Exists(p_pathDestination) AndAlso Not p_overWriteExisting) Then
            Select Case MessengerPrompt.Prompt(New MessageDetails(eMessageActionSets.YesNo, eMessageType.Warning),
                                            "Directory already exists and is set to not be overwritten. Do you wish to overwrite?",
                                            "Directory Location Already Exists")
                Case eMessageActions.Yes
                    'Function will continue and overwrite the existing directory
                Case eMessageActions.No
                    Return False
            End Select
        End If

        Dim cursorWait As New WaitCursor
        ComponentCopyDirectory(p_pathSource, p_pathDestination)
        cursorWait.EndCursor()

        If Directory.Exists(p_pathDestination) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Moves a file from a specified source to destination. 
    ''' May or may not remove the original file depending on parameter inputs.
    ''' Returns true if all desired operations were successful.
    ''' </summary>
    ''' <param name="p_pathSource">Path to the original file.</param>
    ''' <param name="p_pathDestination">Path to where the original file is to be moved.</param>
    ''' <param name="p_deleteOriginal">True: Original file will be deleted after copy action. 
    ''' False: Original file will be left as is.</param>
    ''' <remarks></remarks>
    Public Shared Function MoveFile(ByVal p_pathSource As String,
                                    ByVal p_pathDestination As String,
                                    ByVal p_deleteOriginal As Boolean) As Boolean
        If File.Exists(p_pathSource) Then
            CopyFile(p_pathSource, p_pathDestination, p_overWriteFile:=True, p_includeReadOnly:=True)
            If p_deleteOriginal AndAlso File.Exists(p_pathDestination) Then DeleteFile(p_pathSource, p_includeReadOnly:=True)
        End If

        If (p_deleteOriginal AndAlso File.Exists(p_pathSource)) Then Return False
        If File.Exists(p_pathDestination) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Moves a file from a specified source to destination. 
    ''' May or may not remove the original file depending on parameter inputs.
    ''' Returns true if all desired operations were successful.
    ''' </summary>
    ''' <param name="p_pathSource">Path to the original folder.</param>
    ''' <param name="p_pathDestination">Path to where the original folder is to be moved.</param>
    ''' <param name="p_deleteOriginal">True: Original folder will be deleted after copy action. 
    ''' False: Original folder will be left as is.</param>
    ''' <remarks></remarks>
    Public Shared Function MoveFolder(ByVal p_pathSource As String,
                                     ByVal p_pathDestination As String,
                                     ByVal p_deleteOriginal As Boolean) As Boolean
        If Directory.Exists(p_pathSource) Then
            CopyFolder(p_pathSource, p_pathDestination, p_overWriteExisting:=True)
            If p_deleteOriginal Then DeleteAllFilesFolders(p_pathSource, p_deleteRootFolder:=True)
        End If

        If (p_deleteOriginal AndAlso Directory.Exists(p_pathSource)) Then Return False
        If Directory.Exists(p_pathDestination) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Misc"
    ''' <summary>
    ''' Opens Windows Explorer at the specified directory.
    ''' </summary>
    ''' <param name="p_folderPath">Path to the folder to be opened.</param>
    ''' <param name="p_errorMessage">Error message if the folder does not exist at the specified location.</param>
    ''' <remarks></remarks>
    Public Shared Sub OpenExplorerAtFolder(ByVal p_folderPath As String,
                                           Optional ByVal p_errorMessage As String = "Folder Does Not Exist")
        'Similar for files. See: http://msdn.microsoft.com/en-us/library/system.io.directory.exists.aspx
        If Directory.Exists(p_folderPath) Then
            Try
                Process.Start("explorer.exe", p_folderPath)
            Catch ex As Exception
                RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_folderPath), p_folderPath))
            End Try
        Else
            RaiseEvent Messenger(New MessengerEventArgs(p_errorMessage))
        End If
    End Sub

    ''' <summary>
    ''' Creates a temprorary directory of the specified path &amp; name. 
    ''' If a current directory exists, the name will either have an incremented number, or if at the max allowed, the highest numbered folder will be deleted first. 
    ''' The function returns the resulting path of the created folder.
    ''' </summary>
    ''' <param name="p_pathTemp">Initial path to use to create the temporary folder.</param>
    ''' <param name="p_numTempDirsMax">If creating a new temporary destination, more than one can exist if specified. 
    ''' If a current directory exists, the last directory (i.e. the highest number permitted) will be deleted and replaced by a new, blank directory.</param>
    ''' <returns>The resulting path of the created folder.</returns>
    ''' <remarks></remarks>
    Public Shared Function CreateTempDirectory(ByVal p_pathTemp As String,
                                               Optional ByVal p_numTempDirsMax As Integer = 1) As String
        For i As Integer = 1 To p_numTempDirsMax
            'Adjust new temp folder name if greater than 1
            If Not i = 1 Then
                p_pathTemp = p_pathTemp & "i"
            End If
            If Not Directory.Exists(p_pathTemp) Then
                'Exit loop & create new folder
                Exit For
            Else
                'If the max folder number, delete the latest temp folder
                If i = p_numTempDirsMax Then DeleteAllFilesFolders(p_pathTemp, True, , True)
            End If
        Next

        ComponentCreateDirectory(p_pathTemp)
        Return p_pathTemp
    End Function
#End Region

#Region "Component Functions"
    ''' <summary>
    ''' Component function. Copies a file. Includes error messages.
    ''' </summary>
    ''' <param name="p_pathSource">File path source, including the file name.</param>
    ''' <param name="p_pathDestination">File path destination, including the file name. 
    ''' If filename is different, file will be renamed.</param>
    ''' <param name="p_overWriteFile">True: If file already exists at destination, file will be overwritten.</param>
    ''' <param name="p_promptMessage">Message to display to the user if a file exists.</param>
    ''' <remarks></remarks>
    Public Shared Sub ComponentCopyFileAction(ByVal p_pathSource As String,
                                              ByVal p_pathDestination As String,
                                              ByVal p_overWriteFile As Boolean,
                                              Optional ByVal p_promptMessage As String = "")
        Try
            If StringsMatch(p_pathSource, p_pathDestination) Then Exit Sub

            If (Not p_overWriteFile AndAlso
                File.Exists(p_pathDestination) AndAlso
                Not String.IsNullOrEmpty(p_promptMessage)) Then
                RaiseEvent Messenger(New MessengerEventArgs(p_promptMessage))
                Exit Sub
            End If

            If File.Exists(p_pathSource) Then My.Computer.FileSystem.CopyFile(p_pathSource, p_pathDestination, p_overWriteFile)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_pathSource), p_pathSource,
                                               NameOfParam(Function() p_pathDestination), p_pathDestination,
                                               NameOfParam(Function() p_overWriteFile), p_overWriteFile))
        End Try
    End Sub

    ''' <summary>
    ''' Component function. Deletes a file. Includes error messages.
    ''' </summary>
    ''' <param name="p_path">Path of the file to be deleted.</param>
    ''' <remarks></remarks>
    Public Shared Sub ComponentDeleteFileAction(ByVal p_path As String)
        Try
            If File.Exists(p_path) Then File.Delete(p_path)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_path), p_path))
        End Try
    End Sub

    ''' <summary>
    ''' Component function. Deletes a directory. Includes error messages.
    ''' </summary>
    ''' <param name="p_path">Path of the file to be deleted.</param>
    ''' <param name="p_removeOtherFilesDirectoriesInPath">If 'true', other files, directories, and subdirectories below this path will be deleted. 
    ''' Default is 'false'.</param>
    ''' <remarks></remarks>
    Public Shared Sub ComponentDeleteDirectoryAction(ByVal p_path As String,
                                                     Optional p_removeOtherFilesDirectoriesInPath As Boolean = False)
        Try
            If Directory.Exists(p_path) Then Directory.Delete(p_path, p_removeOtherFilesDirectoriesInPath)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_path), p_path,
                                               NameOfParam(Function() p_removeOtherFilesDirectoriesInPath), p_removeOtherFilesDirectoriesInPath))
        End Try
    End Sub

    ''' <summary>
    ''' Component function. Sets the attribute of a file. Includes error messages.
    ''' </summary>
    ''' <param name="p_path">Path to the file to set the attributes of.</param>
    ''' <param name="p_attribute">Attribute to set the file to.</param>
    ''' <remarks></remarks>
    Public Shared Sub ComponentSetAttributeAction(ByVal p_path As String,
                                                  ByVal p_attribute As FileAttributes)
        Try
            If File.Exists(p_path) Then File.SetAttributes(p_path, p_attribute)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                               NameOfParam(Function() p_path), p_path,
                                               NameOfParam(Function() p_attribute), p_attribute))
        End Try
    End Sub

    ''' <summary>
    ''' Component function. Creates a new directory. Includes error messages.
    ''' </summary>
    ''' <param name="p_path">Path of the directory to be created.</param>
    ''' <remarks></remarks>
    Public Shared Sub ComponentCreateDirectory(ByVal p_path As String)
        Try
            Directory.CreateDirectory(p_path)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex, NameOfParam(Function() p_path), p_path))
        End Try
    End Sub

    ''' <summary>
    ''' Component function. Copies a direcotry, or creates a new one if it does not exist at the destination. Includes error messages.
    ''' </summary>
    ''' <param name="p_pathSource">Source directory path.</param>
    ''' <param name="p_pathDestination">Destination directory path.</param>
    ''' <remarks></remarks>
    Public Shared Sub ComponentCopyDirectory(ByVal p_pathSource As String,
                                             ByVal p_pathDestination As String)
        Try
            If Directory.Exists(p_pathSource) Then My.Computer.FileSystem.CopyDirectory(p_pathSource, p_pathDestination, True)
        Catch ex As Exception
            RaiseEvent Log(New LoggerEventArgs(ex,
                                              NameOfParam(Function() p_pathSource), p_pathSource,
                                              NameOfParam(Function() p_pathDestination), p_pathDestination))
        End Try
    End Sub

#End Region

End Class
