Imports System.Data.Odbc

Public Class AdminPanel
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim username, password, nama, email As String
        Dim leng As Integer

        username = tbUsername.Text.Trim
        nama = tbNama.Text.Trim
        password = Hash(tbPassword.Text.Trim)
        email = tbEmail.Text.Trim

        leng = username.Length * nama.Length * password.Length * email.Length


        If leng > 0 Then
            connection()
            Dim sqlString As String = "INSERT INTO `admin` (`usernameAdmin`, `PasswordAdmin`, `namaAdmin`, `emailAdmin`) VALUES (?, ?, ?, ?)"
            Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
            Cmd.Parameters.Add("@username", OdbcType.VarChar)
            Cmd.Parameters.Add("@password", OdbcType.VarChar)
            Cmd.Parameters.Add("@nama", OdbcType.VarChar)
            Cmd.Parameters.Add("@email", OdbcType.VarChar)

            Cmd.Parameters("@username").Value = username
            Cmd.Parameters("@password").Value = password
            Cmd.Parameters("@nama").Value = nama
            Cmd.Parameters("@email").Value = email
            Cmd.ExecuteNonQuery()
            Conn.Close()
            MsgBox("Admin berhasil ditambahkan")
        Else
            MsgBox("Tolong isi semua kolom yang ada")
        End If



    End Sub

    Private Sub AdminPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        homeadmin.Show()
    End Sub
End Class