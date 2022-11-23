Imports System.IO

Public Class RBI

    Structure Point
        Dim x As Integer
        Dim y As Integer
    End Structure

    Private Property Width As Integer
    Private Property Height As Integer
    Private Property Data As Dictionary(Of Point, Boolean) = New Dictionary(Of Point, Boolean)

    Public Function GetDataAt(ByVal x As Integer, ByVal y As Integer)
        Dim pnt = New Point()
        pnt.x = x
        pnt.y = y
        Return Data.GetValueOrDefault(pnt, Nothing)
    End Function

    Public Function GetWidth()
        Return Width
    End Function

    Public Function GetHeight()
        Return Height
    End Function

    Public Sub SetColor(ByVal x As Integer, ByVal y As Integer, ByVal state As Boolean)
        Dim pos = New Point()
        pos.x = x
        pos.y = y
        Data.Remove(pos)
        Data.Add(pos, state)
    End Sub

    Public Sub WriteContentToFile(ByVal path As String)
        Dim writer = File.Open(path, FileMode.Create)
        Dim binaryWriter = New BinaryWriter(writer)

        binaryWriter.Write(Me.Width)
        binaryWriter.Write(Me.Height)

        ' For Each Pair in Data 
        '     Dim bits = Pair.value
        '     Dim bytes(bits.Length / 8 + (IIf(bits.Length MOD 8 = 0, 0, 1))) As Byte
        '     bits.CopyTo(bytes, 0)
        '     binaryWriter.Write(bytes)
        ' Next

        For i = 0 To width - 1
            For e = 0 To height - 1
                Dim pnt = New Point()
                pnt.x = i
                pnt.y = e
                binaryWriter.Write(Data(pnt))
            Next
        Next  

        binaryWriter.Flush()
        writer.Close()
    End Sub

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        Me.Width = width
        Me.Height = height
        For x As Integer = 0 To width - 1
            For y As Integer = 0 To height - 1
                Dim pnt = New Point()
                pnt.x = x
                pnt.y = y
                Data.Add(pnt, False)
            Next
        Next
    End Sub
End Class
