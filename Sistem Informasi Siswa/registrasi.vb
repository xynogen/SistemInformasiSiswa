Imports System.Data.Odbc


Public Class registrasi
    Public Cmd As OdbcCommand
    Public Ds As DataSet
    Public Da As OdbcDataAdapter
    Public Rd As OdbcDataReader
    Private len As Integer
    Private fs As System.IO.FileStream
    Private fileSize As UInt32
    Private tanggal As Date
    Private PasswordHash, sqlString, filename, namaFile As String
    Private filepath As System.IO.FileInfo
    Private username, password, nama, email, kota, kelas, absen, NIM, tanggalStr As String

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        login.Show()
    End Sub


    Private Sub registrasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundButton(btnSelect)
        RoundButton(btnRegister)
    End Sub



    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        OpenFileDialog1.Filter = "Image Files (jpg, jpeg)|*.jpg;*.jpeg"
        OpenFileDialog1.FileName = ""
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            filename = OpenFileDialog1.FileName()
            filepath = My.Computer.FileSystem.GetFileInfo(filename)
            namaFile = filepath.Name
            lbFilename.Text = namaFile

            fs = New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
            fileSize = fs.Length
            Dim rawImage(fileSize) As Byte
            fs.Read(rawImage, 0, fileSize)
            fs.Close()
            showImage(rawImage, PictureBox2)
        End If

    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        sqlString = "INSERT INTO `siswa` (`usernameSiswa`, `passwordSiswa`, `namaSiswa`, `emailSiswa`, `tanggalLahirSiswa`, `kotaLahirSiswa`, `kelasSiswa`, `noAbsenSiswa`, `NIMSiswa`, `fotoSiswa`) VALUES (?,?,?,?,?,?,?,?,?,?)"

        username = tbUsername.Text.Trim
        password = tbPassword.Text.Trim
        PasswordHash = Hash(password)
        nama = tbNama.Text.Trim
        email = tbEmail.Text.Trim
        kota = tbKota.Text.Trim
        kelas = tbKelas.Text.Trim
        absen = tbAbsen.Text.Trim
        NIM = tbNIM.Text.Trim


        len = username.Length * password.Length * nama.Length * email.Length * kota.Length * kelas.Length * absen.Length * NIM.Length * namaFile.Length

        If len > 0 Then
            fs = New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
            fileSize = fs.Length
            Dim rawImage(fileSize) As Byte
            fs.Read(rawImage, 0, fileSize)
            fs.Close()

            connection()
            Cmd = New OdbcCommand(sqlString, Conn)
            Cmd.Parameters.Add("@username", OdbcType.VarChar)
            Cmd.Parameters.Add("@password", OdbcType.VarChar)
            Cmd.Parameters.Add("@nama", OdbcType.VarChar)
            Cmd.Parameters.Add("@email", OdbcType.VarChar)
            Cmd.Parameters.Add("@tanggal", OdbcType.Date)
            Cmd.Parameters.Add("@kota", OdbcType.VarChar)
            Cmd.Parameters.Add("@kelas", OdbcType.VarChar)
            Cmd.Parameters.Add("@absen", OdbcType.VarChar)
            Cmd.Parameters.Add("@NIM", OdbcType.VarChar)
            Cmd.Parameters.Add("@foto", OdbcType.Binary)

            Cmd.Parameters("@username").Value = username
            Cmd.Parameters("@password").Value = PasswordHash
            Cmd.Parameters("@nama").Value = nama
            Cmd.Parameters("@email").Value = email
            Cmd.Parameters("@tanggal").Value = DateTimePicker1.Value
            Cmd.Parameters("@kota").Value = kota
            Cmd.Parameters("@kelas").Value = kelas
            Cmd.Parameters("@absen").Value = absen
            Cmd.Parameters("@NIM").Value = NIM
            Cmd.Parameters("@foto").Value = rawImage
            Cmd.ExecuteNonQuery()
            Conn.Close()
            Me.Hide()
            login.Show()
        End If

    End Sub
End Class