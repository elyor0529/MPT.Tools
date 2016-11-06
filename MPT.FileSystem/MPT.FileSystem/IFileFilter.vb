Option Strict On
Option Explicit On

Public Interface IFileFilter
    Function MatchingFiles(ByVal p_searchedFiles As List(Of cPath)) As List(Of cPath)

End Interface
