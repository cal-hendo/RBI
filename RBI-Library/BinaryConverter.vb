Public Class BinaryConverter
    Public Shared Function ToBitArray(ByVal value As Integer, ByVal max As Integer)
        Dim binaryAsString = Convert.ToString(value, 2)

        Dim bitArray = New BitArray(CInt(Math.Sqrt(max)))

        Dim index = 0
        For Each bit In binaryAsString
            bitArray.Set(index, IIf(bit = "0", False, True))
            index += 1
        Next

        Console.WriteLine(binaryAsString)

        Return bitArray
    End Function
End Class
