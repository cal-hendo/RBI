Imports System.IO

Module Test
    Public Sub Main(ByVal args As String())
        Dim pathToInput = "test.txt"
        Dim lines = File.ReadAllLines(pathToInput)


        Dim text_pixels(lines.Length, lines(0).Length) As Integer
        For lineIndex = 0 To lines.Length - 1
            Dim line = lines(lineIndex)
            For charIndex = 0 To line.Length - 1
                Dim value As Integer = Val(line(charIndex))

            Next
        Next

        Dim testImage = New RBI(text_pixels.GetUpperBound(0), text_pixels.GetUpperBound(1))

        For x As Integer = text_pixels.GetLowerBound(0) To text_pixels.GetUpperBound(0)
            For y As Integer = text_pixels.GetLowerBound(1) To text_pixels.GetUpperBound(1)
                testImage.SetColor(x, y, IIf(text_pixels(x, y) = 0, False, True))
            Next
        Next
        
        testImage.WriteContentToFile("test.bin")

        ' Load Test
        Dim reader = File.Open("test.bin", FileMode.Open)
        Dim binaryReader = New BinaryReader(reader)

        Dim width = binaryReader.ReadInt32()
        Dim height = binaryReader.ReadInt32()

        Dim pixels(width, height) As Boolean
        For i = 0 To width - 1
            For e = 0 To height - 1
                pixels(i, e) = binaryReader.ReadBoolean()
            Next
        Next 

        For i = 0 To width - 1
            For e = 0 To height - 1
                Console.WriteLine(pixels(i, e))
            Next
        Next 
    End Sub
End Module
