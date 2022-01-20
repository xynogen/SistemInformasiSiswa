Imports System.Security.Cryptography
Imports System.Data.Odbc

Public Class Login
    Public Cmd As OdbcCommand
    Public Ds As DataSet
    Public Da As OdbcDataAdapter
    Public Rd As OdbcDataReader
    Private PasswordHash As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TBUsername.Text.Length > 0 And TBPassword.Text.Length > 0 Then
            If CBLevel.Text.Equals("Admin") Or CBLevel.Text.Equals("Siswa") Then

                If CBLevel.Text.Equals("Admin") Then
                    Call connection()
                    PasswordHash = Hash(TBPassword.Text)

                    Cmd = New OdbcCommand("SELECT * FROM admin WHERE usernameAdmin='" & TBUsername.Text & "'" & "and passwordAdmin='" & PasswordHash & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        MsgBox("Login Berhasil")
                    Else
                        MsgBox("Login Gagal")
                    End If
                End If

                If CBLevel.Text.Equals("Siswa") Then
                    Call connection()
                    PasswordHash = Hash(TBPassword.Text)

                    Cmd = New OdbcCommand("SELECT * FROM siswa WHERE usernameSiswa='" & TBUsername.Text & "'" & "and passwordSiswa='" & PasswordHash & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        MsgBox("Login Berhasil")
                    Else
                        MsgBox("Login Gagal")
                    End If
                End If
            Else
                MsgBox("Pilih Admin atau Siswa")
            End If
        Else
            MsgBox("Isi data terlebih dahulu")
        End If


    End Sub

End Class



'CMD = New OdbcCommand("select * from t_admin where username='" & txt_username.Text & "' and password='" & txt_password.Text & "'", con)
'RD = CMD.ExecuteReader
'RD.Read()
'If RD.HasRows Then
'Form_master.Show()

'Else
'MsgBox("Kode Admin atau Password salah")
'End If
