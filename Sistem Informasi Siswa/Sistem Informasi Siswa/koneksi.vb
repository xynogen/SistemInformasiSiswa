Imports System.Data.Odbc

Module koneksi
    Public Conn As OdbcConnection
    Public MyDB As String

    Sub connection()
        MyDB = "DSN=dsinfo"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

End Module
