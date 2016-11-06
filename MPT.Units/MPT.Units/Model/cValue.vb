Option Strict On
Option Explicit On

''' <summary>
''' Value object that contains a magnitude and associated units. 
''' This value can convert the value and units to a new set of units.
''' </summary>
''' <remarks></remarks>
Public Class cValue
#Region "Properties: Public"
    Private _magnitude As String
    ''' <summary>
    ''' Magnitude of the value.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Magnitude As String
        Get
            Return _magnitude
        End Get
    End Property


    Private _units As New cUnitsController
    ''' <summary>
    ''' Units of the value.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Units As String
        Get
            Dim unitLabel As String = _units.units.shorthandLabel
            If String.IsNullOrEmpty(unitLabel) Then unitLabel = _units.units.GetUnitsLabel

            Return unitLabel
        End Get
    End Property
#End Region

#Region "Initialization"
    ''' <summary>
    ''' Create new value.
    ''' </summary>
    ''' <param name="p_value">Magnitude of the value. 
    ''' Must be numeric if unit features are to be used.</param>
    ''' <param name="p_units">Units of the value (e.g. kN*m/sec).</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal p_value As String,
                   ByVal p_units As String)
        _magnitude = p_value

        ' Units are only set if the value is numeric and units are not a list
        If (IsNumeric(p_value) OrElse Not _units.isConsistent(p_units)) Then _units.ParseStringToUnits(p_units)
    End Sub

#End Region

#Region "Methods: Public"
    ''' <summary>
    ''' Converts the value according to the provided set of units.
    ''' </summary>
    ''' <param name="p_units">Units to convert the value to. These can be provided in two formats: 
    ''' 1. A new set of units. Must be in the same schema as the existing units (e.g. kN*m/sec).
    ''' 2. A list of units, if the value is to be converted to a consistent set of units for a given unit type (e.g. N, mm, hr).</param>
    ''' <remarks></remarks>
    Public Sub ConvertTo(ByVal p_units As String)
        If Not IsNumeric(_magnitude) Then Exit Sub

        ' Convert the value
        Dim conversionValue As Double = _units.ConvertTo(p_units)
        Dim valueNewNumeric As Double = CDbl(_magnitude) * conversionValue
        _magnitude = CStr(valueNewNumeric)

        ' Update the units
        If _units.isConsistent(p_units) Then
            _units.MakeUnitsConsistent(p_units)
        Else
            _units.ParseStringToUnits(p_units)
        End If
    End Sub
#End Region

End Class
