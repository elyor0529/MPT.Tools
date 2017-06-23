Option Strict On
Option Explicit On

Public Class AISC360_05_IBC_2006
    Implements IDesignOverwrite

    Public ReadOnly Property CodeName As String Implements IDesignOverwrite.CodeName
        Get
            Return "AISC 360-05/IBC 2006"
        End Get
    End Property


    Public Function GetOverwrite(nameFrame As String,
                                 ByRef overwrite As DesignOverwriteItem) As Boolean Implements IDesignOverwrite.GetOverwrite

        ' TODO: Stub
        Return False
    End Function

    Public Function GetPreference(ByRef preference As DesignPreferenceItem) As Boolean Implements IDesignOverwrite.GetPreference
        ' TODO: Stub
        Return False
    End Function

    Public Function SetOverwrite(nameFrame As String,
                                 ByRef overwrite As DesignOverwriteItem,
                                 Optional itemType As eItemType = eItemType.Object) As Boolean Implements IDesignOverwrite.SetOverwrite
        ' TODO: Stub
        Return False
    End Function

    Public Function SetPreference(ByRef preference As DesignPreferenceItem) As Boolean Implements IDesignOverwrite.SetPreference
        ' TODO: Stub
        Return False
    End Function


End Class
