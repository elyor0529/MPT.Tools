Option Strict On
Option Explicit On

''' <summary>
''' Contains routines for working with times in numerical and string formats, such as conversions and summations.
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class TimeLibrary

    Private Sub New()
        'Contains only shared members.
        'Private constructor means the class cannot be instantiated.
    End Sub

#Region "Methods"
    ''' <summary>
    ''' Converts time from HH:MM:SS format as a string to time in seconds as a number.
    ''' </summary>
    ''' <param name="p_timeHHMMSS">Time in HH:MM:SS format.</param>
    ''' <returns>Time in seconds.</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertTimesNumber(ByVal p_timeHHMMSS As String) As Long
        Dim hourSeconds As Long = 0
        Dim minuteSeconds As Long = 0
        Dim secondSeconds As Long = 0

        'Generate numerical time in seconds
        If Len(p_timeHHMMSS) - 6 > 0 Then hourSeconds = CLng(Left(p_timeHHMMSS, Len(p_timeHHMMSS) - 6)) * 3600
        If Len(p_timeHHMMSS) - 4 > 0 Then minuteSeconds = CLng(Mid(p_timeHHMMSS, Len(p_timeHHMMSS) - 4, 2)) * 60
        If Len(p_timeHHMMSS) >= 2 Then secondSeconds = CLng(Right(p_timeHHMMSS, 2))

        Return hourSeconds + minuteSeconds + secondSeconds
    End Function

    ''' <summary>
    ''' Converts time from seconds as a number to HH:MM:SS format as a string.
    ''' </summary>
    ''' <param name="p_timeSeconds">Time in seconds.</param>
    ''' <returns>Time in HH:MM:SS format.</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertTimesString(ByVal p_timeSeconds As Double) As String
        Dim hourHour As String
        Dim minuteMinute As String
        Dim secondSeconds As String
        Dim timeNum As Double

        'Hour Conversion
        timeNum = Math.Floor(p_timeSeconds / 3600)
        hourHour = CStr(timeNum)
        If Len(hourHour) < 2 Then hourHour = "0" & hourHour 'Ensures that the hour spot has two digits

        'Minute Conversion
        timeNum = Math.Floor((p_timeSeconds - timeNum * 3600) / 60)
        minuteMinute = CStr(timeNum)
        If Len(minuteMinute) < 2 Then minuteMinute = "0" & minuteMinute 'Ensures that the minute spot has two digits

        'Seconds Conversion
        secondSeconds = CStr(p_timeSeconds - CLng(hourHour) * 3600 - CLng(minuteMinute) * 60)

        'Assemble String
        Return hourHour & ":" & minuteMinute & ":" & secondSeconds
    End Function

    ''' <summary>
    ''' Converts time from HH:MM:SS format as a string to time in minutes as a number.
    ''' </summary>
    ''' <param name="p_timeHHMMSS">Time in HH:MM:SS format.</param>
    ''' <returns>Time in seconds.</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertTimesNumberMinute(ByVal p_timeHHMMSS As String) As Double
        Dim hourSeconds As Long = 0
        Dim minuteSeconds As Long = 0
        Dim secondSeconds As Double = 0

        'Generate numerical time in seconds
        If Len(p_timeHHMMSS) - 6 > 0 Then hourSeconds = CLng(Left(p_timeHHMMSS, Len(p_timeHHMMSS) - 6)) * 60
        If Len(p_timeHHMMSS) - 4 > 0 Then minuteSeconds = CLng(Mid(p_timeHHMMSS, Len(p_timeHHMMSS) - 4, 2))
        If Len(p_timeHHMMSS) >= 2 Then secondSeconds = CDbl(Right(p_timeHHMMSS, 2)) / 60 'Math.Floor(CDbl(Right(timeHHMMSS, 2)) / 60)

        Return hourSeconds + minuteSeconds + secondSeconds
    End Function

    ''' <summary>
    ''' Converts time from minutes as a number to HH:MM:SS format as a string.
    ''' </summary>
    ''' <param name="p_timeMinutes">Time in minutes.</param>
    ''' <returns>Time in HH:MM:SS format.</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertTimesStringMinutes(ByVal p_timeMinutes As Double) As String
        Dim hourHour As String
        Dim minuteMinute As String
        Dim secondSeconds As String
        Dim timeNum As Double
        Dim timeSeconds As Double

        timeSeconds = p_timeMinutes * 60

        'Hour Conversion
        timeNum = Math.Floor(timeSeconds / 3600)
        hourHour = CStr(timeNum)

        'Ensures that the hour spot has at least two digits
        If Len(hourHour) < 2 Then hourHour = "0" & hourHour


        'Minute Conversion
        timeNum = Math.Floor((timeSeconds - CLng(hourHour) * 3600) / 60)
        minuteMinute = CStr(timeNum)

        'Ensures that the minute spot has two digits
        If Len(minuteMinute) < 2 Then minuteMinute = "0" & minuteMinute


        'Seconds Conversion
        secondSeconds = CStr(Math.Floor(timeSeconds - CLng(hourHour) * 3600 - CLng(minuteMinute) * 60))

        'Ensures that the second spot has two digits
        If Len(secondSeconds) < 2 Then secondSeconds = "0" & secondSeconds

        'Assemble String
        Return hourHour & ":" & minuteMinute & ":" & secondSeconds
    End Function
#End Region
End Class
