Imports System.IO
Module viewImage
    Public Sub showImage(myImage As Object, p As PictureBox)
        Dim imageData As Byte() = DirectCast(myImage, Byte())
        Dim newImage As Image = Nothing
        If Not imageData Is Nothing Then
            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                ms.Write(imageData, 0, imageData.Length)
                newImage = Image.FromStream(ms, True)
            End Using
            p.BackgroundImage = newImage
            p.BackgroundImageLayout = ImageLayout.Stretch
            RoundPicture(p)
        End If
    End Sub
End Module
