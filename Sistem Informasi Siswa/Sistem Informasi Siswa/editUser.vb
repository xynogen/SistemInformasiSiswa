Imports System.Data.Odbc
Imports System.IO
Public Class editUser
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

    Private Sub tbPassword_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Session.idSiswa = Nothing
        Me.Hide()
        homeadmin.Show()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        username = tbUsername.Text.Trim
        nama = tbNama.Text.Trim
        email = tbEmail.Text.Trim
        kota = tbKota.Text.Trim
        kelas = tbKelas.Text.Trim
        absen = tbAbsen.Text.Trim
        NIM = tbNIM.Text.Trim


        len = username.Length * nama.Length * email.Length * kota.Length * kelas.Length * absen.Length * NIM.Length

        If len > 0 Then

            If namaFile Is Nothing Then
                connection()
                sqlString = "UPDATE `siswa` SET `usernameSiswa` = ?, namaSiswa = ?, `emailSiswa` = ?, `tanggalLahirSiswa` = ?, `kotaLahirSiswa` = ?, `kelasSiswa` = ?, `noAbsenSiswa` = ?, `NIMSiswa` = ? WHERE `siswa`.`idSiswa` = ?"
                Cmd = New OdbcCommand(sqlString, Conn)
                Cmd.Parameters.Add("@username", OdbcType.VarChar)
                Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                Cmd.Parameters.Add("@email", OdbcType.VarChar)
                Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                Cmd.Parameters.Add("@kota", OdbcType.VarChar)
                Cmd.Parameters.Add("@kelas", OdbcType.VarChar)
                Cmd.Parameters.Add("@absen", OdbcType.VarChar)
                Cmd.Parameters.Add("@NIM", OdbcType.VarChar)
                Cmd.Parameters.Add("@id", OdbcType.Int)

            Else
                sqlString = "UPDATE `siswa` SET `usernameSiswa` = ?, namaSiswa = ?, `emailSiswa` = ?, `tanggalLahirSiswa` = ?, `kotaLahirSiswa` = ?, `kelasSiswa` = ?, `noAbsenSiswa` = ?, `NIMSiswa` = ?, `fotoSiswa` = ? WHERE `siswa`.`idSiswa` = ?"
                Cmd = New OdbcCommand(sqlString, Conn)
                Cmd.Parameters.Add("@username", OdbcType.VarChar)
                Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                Cmd.Parameters.Add("@email", OdbcType.VarChar)
                Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                Cmd.Parameters.Add("@kota", OdbcType.VarChar)
                Cmd.Parameters.Add("@kelas", OdbcType.VarChar)
                Cmd.Parameters.Add("@absen", OdbcType.VarChar)
                Cmd.Parameters.Add("@NIM", OdbcType.VarChar)
                Cmd.Parameters.Add("@foto", OdbcType.Binary)
                Cmd.Parameters.Add("@id", OdbcType.Int)
                fs = New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
                fileSize = fs.Length
                Dim rawImage(fileSize) As Byte
                fs.Read(rawImage, 0, fileSize)
                fs.Close()
                Cmd.Parameters("@foto").Value = rawImage

            End If

            Cmd.Parameters("@username").Value = username
            Cmd.Parameters("@nama").Value = nama
            Cmd.Parameters("@email").Value = email
            Cmd.Parameters("@tanggal").Value = DateTimePicker1.Value
            Cmd.Parameters("@kota").Value = kota
            Cmd.Parameters("@kelas").Value = kelas
            Cmd.Parameters("@absen").Value = absen
            Cmd.Parameters("@NIM").Value = NIM
            Cmd.Parameters("@id").Value = Session.idSiswa
            Cmd.ExecuteNonQuery()
            Conn.Close()
        End If

    End Sub

    Private Sub homesiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refresh(Session.idSiswa)
        RoundButton(btnSelect)
        RoundButton(btnUpdate)
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
            showImage(rawImage, PictureBox1)
        End If

    End Sub

    Private Sub refresh(id As String)
        sqlString = "SELECT * FROM siswa WHERE idSiswa=@id"
        sqlString = sqlString.Replace("@id", id)
        connection()
        Cmd = New OdbcCommand(sqlString, Conn)
        Rd = Cmd.ExecuteReader()
        Rd.Read()

        tbUsername.Text = Rd.GetValue(Rd.GetOrdinal("usernameSiswa"))
        tbNama.Text = Rd.GetValue(Rd.GetOrdinal("namaSiswa"))
        tbEmail.Text = Rd.GetValue(Rd.GetOrdinal("EmailSiswa"))
        DateTimePicker1.Value = Rd.GetValue(Rd.GetOrdinal("tanggalLahirSiswa"))
        tbKota.Text = Rd.GetValue(Rd.GetOrdinal("kotaLahirSiswa"))
        tbKelas.Text = Rd.GetValue(Rd.GetOrdinal("kelasSiswa"))
        tbAbsen.Text = Rd.GetValue(Rd.GetOrdinal("noAbsenSiswa"))
        tbNIM.Text = Rd.GetValue(Rd.GetOrdinal("NIMSiswa"))
        viewImage.showImage(Rd.GetValue(Rd.GetOrdinal("fotoSiswa")), PictureBox1)
        Rd.Close()
        Conn.Close()
    End Sub

End Class