Module Hashing
    Public Function Hash(ByVal content As String) As String
        Dim sha256 As New Security.Cryptography.SHA256CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(content)
        ByteString = sha256.ComputeHash(ByteString)

        Dim FinalString As String = Nothing
        For Each bt As Byte In ByteString
            FinalString &= bt.ToString("x2")
        Next
        Return FinalString
    End Function

End Module
