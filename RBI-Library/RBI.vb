Public Class RBI
    Private Property ColorDepth As UShort
    Private Property Width As Integer
    Private Property Height As Integer
    Private Property Data As Dictionary(Of Integer(), BitArray) = New Dictionary(Of Integer(), BitArray)

    Public Function GetDataAt(ByVal x As Integer, ByVal y As Integer)
        Return Data.GetValueOrDefault(New Integer() {x, y}, Nothing)
    End Function

    Public Function GetWidth()
        Return Width
    End Function

    Public Function GetHeight()
        Return Height
    End Function

    Public Function GetColorDepth()
        Return GetColorDepth
    End Function

    Public Sub SetColorDepth(ByVal value As UShort)
        ColorDepth = value
    End Sub

    Public Sub SetColorRaw(ByVal x As Integer, ByVal y As Integer, ByVal bitArray As BitArray)
        Dim pos As Integer() = {x, y}
        Data.Remove(pos)
        Data.Add(pos, bitArray)
    End Sub

    Public Sub SetColor(ByVal x As Integer, ByVal y As Integer, ByVal colorID As Integer)
        ' If the ID is not in the color depth range.
        If colorID > 2 ^ ColorDepth Or colorID < 0 Then
            Throw New Exception("colorID is out of range of RBI's color depth - max id: " + 2 ^ ColorDepth)
        End If

        Dim pos As Integer() = {x, y}
        Dim bitArray As BitArray = BinaryConverter.ToBitArray(colorID, ColorDepth)
        Data.Remove(pos)
        Data.Add(pos, bitArray)
    End Sub

    Public Sub New(ByVal width As Integer, ByVal height As Integer, ByVal colorDepth As Integer)
        Me.Width = width
        Me.Height = height
        Me.ColorDepth = colorDepth

        Dim templateBitArray As BitArray = New BitArray(colorDepth)

        For x As Integer = 0 To width
            For y As Integer = 0 To height
                Data.Add(New Integer() {x, y}, templateBitArray)
            Next
        Next
    End Sub
End Class
