Option Strict On
Option Explicit On

Imports MPT.Reporting

Module TestModule
    Public Event Log(exception As LoggerEventArgs)

    Private WithEvents _child As TestClass

    Sub Main()
        Test("Foo")
    End Sub

    Sub Test(ByVal p_string As String)
        _child = New TestClass

        Dim myList As New List(Of String)
        myList.Add("Fee")
        myList.Add("Fie")
        myList.Add("Foe")
        myList.Add("Fum")
        _child.TestException(p_string, "Mark", 13, myList, 13.568, True)
        Console.ReadKey()
    End Sub

    Sub TestListener(e As LoggerEventArgs) Handles _child.Log
        Console.WriteLine(e.Exception.Message)
        Console.WriteLine(e.Message)

        Console.WriteLine(e.Exception.InnerException)
        Console.WriteLine(e.Exception.StackTrace)
        Console.WriteLine(e.Exception.Source)

        For Each itemKey As String In e.Parameters.Keys
            Console.WriteLine(itemKey & ": " & e.Parameters.Item(itemKey))
        Next
    End Sub

End Module
