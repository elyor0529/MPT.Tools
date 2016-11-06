﻿Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Collections.ObjectModel

Imports MPT.Enums.EnumLibrary

''' <summary>
''' Base unit of the type 'length'. 
''' Provides a list of unit names allowed and performs unit conversions.
''' </summary>
''' <remarks></remarks>
Public Class cUnitLength
#Region "Enumerations"
    ''' <summary>
    ''' List of the unit names available for this unit type.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shadows Enum eUnit
        <Description("")> none
        <Description("in")> inch
        <Description("ft")> foot
        <Description("yd")> yard
        <Description("mile")> mile
        <Description("micron")> micron
        <Description("mm")> millimeter
        <Description("cm")> centimeter
        <Description("m")> meter
        <Description("km")> kilometer
    End Enum
#End Region

#Region "Constants"
    Private Const _MILLIMETER_TO_INCH As Double = 1 / 25.4

    'Within Imperial
    Private Const _FOOT_TO_INCH As Integer = 12
    Private Const _YARD_TO_FOOT As Integer = 3
    Private Const _MILE_TO_FOOT As Integer = 5280

    'Within SI
    Private Const _MICRON_TO_MILLIMETER As Double = 0.001
    Private Const _CENTIMETER_TO_MILLIMETER As Integer = 10
    Private Const _METER_TO_MILLIMETER As Integer = 1000
    Private Const _KILOMETER_TO_MILLIMETER As Integer = 1000000
#End Region

#Region "Properties: Friend"
    ''' <summary>
    ''' Specified unit.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property unit As eUnit

    Private _unitDefault As eUnit = eUnit.inch
    ''' <summary>
    ''' Default unit set for this unit type.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property unitDefault As eUnit
        Get
            Return _unitDefault
        End Get
    End Property

    Private _unitsList As New List(Of String)
    ''' <summary>
    '''  List of mass units.
    ''' </summary>
    ''' <remarks></remarks>
    Friend ReadOnly Property unitsList As List(Of String)
        Get
            Return _unitsList
        End Get
    End Property
#End Region

#Region "Initialization"
    Friend Sub New()
        InitializeData()
        SetToDefault()
    End Sub

    Private Sub InitializeData()
        _unitsList = GetEnumDescriptionList(eUnit.none)
    End Sub

    ''' <summary>
    ''' Sets the unit type back to the default unit type.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SetToDefault()
        unit = _unitDefault
    End Sub
#End Region

#Region "Methods: Friend"
    ''' <summary>
    ''' Converts from one unit to another and returns the conversion factor.
    ''' </summary>
    ''' <param name="p_value">Original value associated with the unit. 
    ''' Use '1' if solely obtaining the conversion factor between units. 
    ''' The result is what to multiply the 'value' by to perform the conversion.</param>
    ''' <param name="p_unit">Unit type to convert from.</param>
    ''' <param name="p_unitResult">Unit type to convert to.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Convert(ByVal p_value As Double,
                           ByVal p_unit As eUnit,
                           Optional ByVal p_unitResult As eUnit = eUnit.none) As Double
        Dim value As Double = p_value

        If Not p_unitResult = eUnit.none And p_unit = p_unitResult Then Return value

        'Convert to default unit
        value = ConvertToBase(p_value, p_unit)

        'If necessary, convert to other unit
        If (Not p_unitResult = eUnit.none AndAlso Not p_unitResult = unitDefault) Then
            value = ConvertFromBase(value, p_unitResult)
        End If

        Return value
    End Function
#End Region

#Region "Methods: Private"
    ''' <summary>
    ''' Converts the provided unit to the default unit type and returns the value for the conversion, which is multiplied by the supplied value.
    ''' </summary>
    ''' <param name="p_value">Conversion value. Typically starts as '1'.</param>
    ''' <param name="p_unit">Unit to convert to the default unit type.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertToBase(ByVal p_value As Double,
                                    ByVal p_unit As eUnit) As Double
        Select Case p_unit
            Case eUnit.inch 'Default value. No action needed.
            Case eUnit.foot
                p_value *= _FOOT_TO_INCH
            Case eUnit.yard
                p_value *= (_YARD_TO_FOOT * _FOOT_TO_INCH)
            Case eUnit.mile
                p_value *= (_MILE_TO_FOOT * _FOOT_TO_INCH)
            Case eUnit.micron
                p_value *= (_MICRON_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case eUnit.millimeter
                p_value *= _MILLIMETER_TO_INCH
            Case eUnit.centimeter
                p_value *= (_CENTIMETER_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case eUnit.meter
                p_value *= (_METER_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case eUnit.kilometer
                p_value *= (_KILOMETER_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case Else : Return 0
        End Select

        Return p_value
    End Function

    ''' <summary>
    ''' Converts the provided unit from the default unit type to the specified unit type and returns the value for the conversion, which supplied value is divided by.
    ''' </summary>
    ''' <param name="p_value">Conversion value. Typically starts as "1" if it is not passed along from a prior conversion method.</param>
    ''' <param name="p_unitTarget">Unit object to which the conversion is to take place.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertFromBase(ByVal p_value As Double,
                                      ByVal p_unitTarget As eUnit) As Double

        Select Case p_unitTarget
            Case eUnit.foot
                p_value /= _FOOT_TO_INCH
            Case eUnit.yard
                p_value /= (_YARD_TO_FOOT * _FOOT_TO_INCH)
            Case eUnit.mile
                p_value /= (_MILE_TO_FOOT * _FOOT_TO_INCH)
            Case eUnit.micron
                p_value /= (_MICRON_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case eUnit.millimeter
                p_value /= _MILLIMETER_TO_INCH
            Case eUnit.centimeter
                p_value /= (_CENTIMETER_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case eUnit.meter
                p_value /= (_METER_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case eUnit.kilometer
                p_value /= (_KILOMETER_TO_MILLIMETER * _MILLIMETER_TO_INCH)
            Case Else : Return 0
        End Select

        Return p_value
    End Function
#End Region
End Class
