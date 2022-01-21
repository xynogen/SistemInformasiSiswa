Imports System.Data.Odbc

Public Class login
    Public Cmd As OdbcCommand
    Public Ds As DataSet
    Public Da As OdbcDataAdapter
    Public Rd As OdbcDataReader
    Private PasswordHash, sqlString As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If TBUsername.Text.Length > 0 And TBPassword.Text.Length > 0 Then
            If CBLevel.Text.Equals("Admin") Or CBLevel.Text.Equals("Siswa") Then

                If CBLevel.Text.Equals("Admin") Then
                    Call connection()
                    PasswordHash = Hash(TBPassword.Text.Trim)

                    sqlString = "SELECT * FROM admin WHERE usernameAdmin = '@username' and passwordAdmin = '@password'"
                    sqlString = sqlString.Replace("@username", TBUsername.Text.Trim)
                    sqlString = sqlString.Replace("@password", PasswordHash)

                    Cmd = New OdbcCommand(sqlString, Conn)
                    Rd = Cmd.ExecuteReader()

                    Rd.Read()
                    If Rd.HasRows Then
                        Session.idAdmin = Rd.GetValue(Rd.GetOrdinal("idAdmin"))
                        Me.Hide()
                        homeadmin.Show()
                    Else
                        MsgBox("Login Gagal")
                    End If
                    Conn.Close()
                End If

                If CBLevel.Text.Equals("Siswa") Then
                    Call connection()
                    PasswordHash = Hash(TBPassword.Text.Trim)
                    sqlString = "SELECT * FROM siswa WHERE usernameSiswa = '@username' and passwordSiswa = '@password'"
                    sqlString = sqlString.Replace("@username", TBUsername.Text.Trim)
                    sqlString = sqlString.Replace("@password", PasswordHash)

                    Cmd = New OdbcCommand(sqlString, Conn)
                    Rd = Cmd.ExecuteReader()

                    If Rd.HasRows Then
                        Session.idSiswa = Rd.GetValue(Rd.GetOrdinal("idSiswa"))
                        Me.Hide()
                        homesiswa.Show()
                    Else
                        MsgBox("Login Gagal")
                    End If
                    Conn.Close()
                End If
            Else
                MsgBox("Pilih Admin atau Siswa")
            End If
        Else
            MsgBox("Isi data terlebih dahulu")
        End If


    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Me.Hide()
        registrasi.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundButton(btnLogin)
        RoundButton(btnRegister)
    End Sub

End Class
