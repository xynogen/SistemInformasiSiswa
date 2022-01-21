Imports System.Data.Odbc
Public Class uploadSiswa
    Private ktpFilename, ktmFilename, perpusFilename As String



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Not (Session.idAdmin Is Nothing) Then
            Session.idSiswa = Nothing
            Me.Hide()
            homeadmin.Show()
        Else
            Session.idSiswa = Nothing
            Me.Hide()
            homesiswa.Show()
        End If
    End Sub

    Private Sub btnKTP_Click(sender As Object, e As EventArgs) Handles btnKTP.Click
        OpenFileDialog1.Filter = "PDF Files (pdf)|*.pdf"
        OpenFileDialog1.FileName = ""
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            ktpFilename = OpenFileDialog1.FileName()
            Dim filepath As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(ktpFilename)
            lbKTP.Text = filepath.Name
        End If
    End Sub



    Private Sub btnKTM_Click(sender As Object, e As EventArgs) Handles btnKTM.Click
        OpenFileDialog1.Filter = "PDF Files (pdf)|*.pdf"
        OpenFileDialog1.FileName = ""
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            ktmFilename = OpenFileDialog1.FileName()
            Dim filepath As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(ktmFilename)
            lbKTM.Text = filepath.Name
        End If
    End Sub

    Private Sub uploadSiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundButton(btnKTM)
        RoundButton(btnKTP)
        RoundButton(btnPerpus)
        RoundButton(viewKTM)
        RoundButton(viewKTP)
        RoundButton(viewPerpus)
        RoundButton(btnUpload)

        connection()
        Dim tipe As String = "KTP"
        Dim sqlString As String = "SELECT namaFile FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
        sqlString = sqlString.Replace("@id", Session.idSiswa)
        sqlString = sqlString.Replace("@tipe", tipe)
        Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
        Dim Rd As OdbcDataReader = Cmd.ExecuteReader()
        Rd.Read()
        If Rd.HasRows Then
            lbKTP.Text = Rd.GetValue(Rd.GetOrdinal("namaFile"))
        End If
        Rd.Close()
        Conn.Close()

        connection()
        tipe = "KTM"
        sqlString = "SELECT namaFile FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
        sqlString = sqlString.Replace("@id", Session.idSiswa)
        sqlString = sqlString.Replace("@tipe", tipe)
        Cmd = New OdbcCommand(sqlString, Conn)
        Rd = Cmd.ExecuteReader()
        Rd.Read()
        If Rd.HasRows Then
            lbKTM.Text = Rd.GetValue(Rd.GetOrdinal("namaFile"))
        End If
        Rd.Close()
        Conn.Close()

        connection()
        tipe = "PERPUS"
        sqlString = "SELECT namaFile FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
        sqlString = sqlString.Replace("@id", Session.idSiswa)
        sqlString = sqlString.Replace("@tipe", tipe)
        Cmd = New OdbcCommand(sqlString, Conn)
        Rd = Cmd.ExecuteReader()
        Rd.Read()
        If Rd.HasRows Then
            lbPerpus.Text = Rd.GetValue(Rd.GetOrdinal("namaFile"))
        End If
        Rd.Close()
        Conn.Close()


    End Sub

    Private Sub viewKTP_Click(sender As Object, e As EventArgs) Handles viewKTP.Click
        Dim tipe As String = "KTP"
        connection()
        Dim sqlString As String = "SELECT file FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
        sqlString = sqlString.Replace("@id", Session.idSiswa)
        sqlString = sqlString.Replace("@tipe", tipe)
        Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
        Dim Rd As OdbcDataReader = Cmd.ExecuteReader()
        If Rd.HasRows Then
            Dim path As String = Application.StartupPath + "\tmp"
            Dim rawData() As Byte = Rd.GetValue(Rd.GetOrdinal("file"))
            My.Computer.FileSystem.DeleteDirectory(path, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(path)

            Dim fs As System.IO.FileStream = New IO.FileStream(path + "\ktp.pdf", IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim fileSize As UInt32 = rawData.Length
            fs.Write(rawData, 0, fileSize)
            fs.Close()
            Process.Start(path + "\ktp.pdf")
        Else
            MsgBox("File Belum di Upload")
        End If

        Rd.Close()
        Conn.Close()

    End Sub

    Private Sub viewKTM_Click(sender As Object, e As EventArgs) Handles viewKTM.Click
        Dim tipe As String = "KTM"
        connection()
        Dim sqlString As String = "SELECT file FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
        sqlString = sqlString.Replace("@id", Session.idSiswa)
        sqlString = sqlString.Replace("@tipe", tipe)
        Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
        Dim Rd As OdbcDataReader = Cmd.ExecuteReader()
        Rd.Read()

        If Rd.HasRows Then
            Dim path As String = Application.StartupPath + "\tmp"
            Dim rawData() As Byte = Rd.GetValue(Rd.GetOrdinal("file"))

            My.Computer.FileSystem.CreateDirectory(path)

            Dim fs As System.IO.FileStream = New IO.FileStream(path + "\ktm.pdf", IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim fileSize As UInt32 = rawData.Length
            fs.Write(rawData, 0, fileSize)
            fs.Close()
            Process.Start(path + "\ktm.pdf")
        Else
            MsgBox("File Belum di Upload")
        End If

        Rd.Close()
        Conn.Close()
    End Sub

    Private Sub viewPerpus_Click(sender As Object, e As EventArgs) Handles viewPerpus.Click
        Dim tipe As String = "PERPUS"
        connection()
        Dim sqlString As String = "SELECT file FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
        sqlString = sqlString.Replace("@id", Session.idSiswa)
        sqlString = sqlString.Replace("@tipe", tipe)
        Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
        Dim Rd As OdbcDataReader = Cmd.ExecuteReader()
        If Rd.HasRows Then
            Dim path As String = Application.StartupPath + "\tmp"
            Dim rawData() As Byte = Rd.GetValue(Rd.GetOrdinal("file"))

            My.Computer.FileSystem.CreateDirectory(path)

            Dim fs As System.IO.FileStream = New IO.FileStream(path + "\perpus.pdf", IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim fileSize As UInt32 = rawData.Length
            fs.Write(rawData, 0, fileSize)
            fs.Close()
            Process.Start(path + "\perpus.pdf")
        Else
            MsgBox("File Belum di Upload")
        End If

        Rd.Close()
        Conn.Close()
    End Sub

    Private Sub btnPerpus_Click(sender As Object, e As EventArgs) Handles btnPerpus.Click
        OpenFileDialog1.Filter = "PDF Files (pdf)|*.pdf"
        OpenFileDialog1.FileName = ""
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            perpusFilename = OpenFileDialog1.FileName()
            Dim filepath As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(perpusFilename)
            lbPerpus.Text = filepath.Name




        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If Not (ktpFilename Is Nothing) Then
            If ktpFilename.Length > 0 Then
                Dim tipe As String = "KTP"
                connection()
                Dim sqlString As String = "SELECT * FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
                sqlString = sqlString.Replace("@id", Session.idSiswa)
                sqlString = sqlString.Replace("@tipe", tipe)

                Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
                Dim Rd As OdbcDataReader = Cmd.ExecuteReader()

                If Rd.HasRows Then
                    sqlString = "UPDATE `file` SET `namaFile` = ?, `pemilikFile` = ? , `tanggalFile` = ?, `tipeFile` = ?, `file` = ? WHERE `file`.`idFile`=?"
                    Cmd = New OdbcCommand(sqlString, Conn)
                    Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                    Cmd.Parameters.Add("@pemilik", OdbcType.Int)
                    Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                    Cmd.Parameters.Add("@tipefile", OdbcType.VarChar)
                    Cmd.Parameters.Add("@file", OdbcType.Binary)
                    Cmd.Parameters.Add("@idfile", OdbcType.VarChar)
                    Cmd.Parameters("@nama").Value = lbKTP.Text
                    Cmd.Parameters("@pemilik").Value = Session.idSiswa
                    Cmd.Parameters("@tanggal").Value = Date.Now
                    Cmd.Parameters("@tipefile").Value = tipe


                    Dim fs As System.IO.FileStream = New IO.FileStream(ktpFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim fileSize As UInt32 = fs.Length
                    Dim rawdata(fileSize) As Byte
                    fs.Read(rawdata, 0, fileSize)
                    fs.Close()
                    Cmd.Parameters("@file").Value = rawdata
                    Cmd.Parameters("@idfile").Value = Rd.GetValue(Rd.GetOrdinal("idFile"))
                    Cmd.ExecuteNonQuery()
                    Conn.Close()
                Else
                    sqlString = "INSERT INTO `file` (`namaFile`, `pemilikFile`, `tanggalFile`, `tipeFile`, `file`) VALUES (?,?,?,?,?)"
                    Cmd = New OdbcCommand(sqlString, Conn)
                    Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                    Cmd.Parameters.Add("@pemilik", OdbcType.Int)
                    Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                    Cmd.Parameters.Add("@tipefile", OdbcType.VarChar)
                    Cmd.Parameters.Add("@file", OdbcType.Binary)
                    Cmd.Parameters("@nama").Value = lbKTP.Text
                    Cmd.Parameters("@pemilik").Value = Session.idSiswa
                    Cmd.Parameters("@tanggal").Value = Date.Now
                    Cmd.Parameters("@tipefile").Value = tipe

                    Dim fs As System.IO.FileStream = New IO.FileStream(ktpFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim fileSize As UInt32 = fs.Length
                    Dim rawdata(fileSize) As Byte
                    fs.Read(rawdata, 0, fileSize)
                    fs.Close()
                    Cmd.Parameters("@file").Value = rawdata
                    Cmd.ExecuteNonQuery()
                    Conn.Close()
                End If
            End If
        End If

        If Not (ktmFilename Is Nothing) Then
            If ktmFilename.Length > 0 Then
                Dim tipe As String = "KTM"
                connection()
                Dim sqlString As String = "SELECT * FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
                sqlString = sqlString.Replace("@id", Session.idSiswa)
                sqlString = sqlString.Replace("@tipe", tipe)

                Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
                Dim Rd As OdbcDataReader = Cmd.ExecuteReader()

                If Rd.HasRows Then
                    sqlString = "UPDATE `file` SET `namaFile` = ?, `pemilikFile` = ? , `tanggalFile` = ?, `tipeFile` = ?, `file` = ? WHERE `file`.`idFile`=?"
                    Cmd = New OdbcCommand(sqlString, Conn)
                    Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                    Cmd.Parameters.Add("@pemilik", OdbcType.Int)
                    Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                    Cmd.Parameters.Add("@tipefile", OdbcType.VarChar)
                    Cmd.Parameters.Add("@file", OdbcType.Binary)
                    Cmd.Parameters.Add("@idfile", OdbcType.VarChar)
                    Cmd.Parameters("@nama").Value = lbKTM.Text
                    Cmd.Parameters("@pemilik").Value = Session.idSiswa
                    Cmd.Parameters("@tanggal").Value = Date.Now
                    Cmd.Parameters("@tipefile").Value = tipe


                    Dim fs As System.IO.FileStream = New IO.FileStream(ktmFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim fileSize As UInt32 = fs.Length
                    Dim rawdata(fileSize) As Byte
                    fs.Read(rawdata, 0, fileSize)
                    fs.Close()
                    Cmd.Parameters("@file").Value = rawdata
                    Cmd.Parameters("@idfile").Value = Rd.GetValue(Rd.GetOrdinal("idFile"))
                    Cmd.ExecuteNonQuery()
                    Conn.Close()
                Else
                    sqlString = "INSERT INTO `file` (`namaFile`, `pemilikFile`, `tanggalFile`, `tipeFile`, `file`) VALUES (?,?,?,?,?)"
                    Cmd = New OdbcCommand(sqlString, Conn)
                    Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                    Cmd.Parameters.Add("@pemilik", OdbcType.Int)
                    Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                    Cmd.Parameters.Add("@tipefile", OdbcType.VarChar)
                    Cmd.Parameters.Add("@file", OdbcType.Binary)
                    Cmd.Parameters("@nama").Value = lbKTM.Text
                    Cmd.Parameters("@pemilik").Value = Session.idSiswa
                    Cmd.Parameters("@tanggal").Value = Date.Now
                    Cmd.Parameters("@tipefile").Value = tipe

                    Dim fs As System.IO.FileStream = New IO.FileStream(ktmFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim fileSize As UInt32 = fs.Length
                    Dim rawdata(fileSize) As Byte
                    fs.Read(rawdata, 0, fileSize)
                    fs.Close()
                    Cmd.Parameters("@file").Value = rawdata
                    Cmd.ExecuteNonQuery()
                    Conn.Close()
                End If
            End If
        End If

        If Not (perpusFilename Is Nothing) Then
            If perpusFilename.Length > 0 Then
                Dim tipe As String = "PERPUS"
                connection()
                Dim sqlString As String = "SELECT * FROM `file` WHERE pemilikFile = '@id' and tipeFile = '@tipe'"
                sqlString = sqlString.Replace("@id", Session.idSiswa)
                sqlString = sqlString.Replace("@tipe", tipe)

                Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
                Dim Rd As OdbcDataReader = Cmd.ExecuteReader()

                If Rd.HasRows Then
                    sqlString = "UPDATE `file` SET `namaFile` = ?, `pemilikFile` = ? , `tanggalFile` = ?, `tipeFile` = ?, `file` = ? WHERE `file`.`idFile`=?"
                    Cmd = New OdbcCommand(sqlString, Conn)
                    Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                    Cmd.Parameters.Add("@pemilik", OdbcType.Int)
                    Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                    Cmd.Parameters.Add("@tipefile", OdbcType.VarChar)
                    Cmd.Parameters.Add("@file", OdbcType.Binary)
                    Cmd.Parameters.Add("@idfile", OdbcType.VarChar)
                    Cmd.Parameters("@nama").Value = lbPerpus.Text
                    Cmd.Parameters("@pemilik").Value = Session.idSiswa
                    Cmd.Parameters("@tanggal").Value = Date.Now
                    Cmd.Parameters("@tipefile").Value = tipe


                    Dim fs As System.IO.FileStream = New IO.FileStream(perpusFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim fileSize As UInt32 = fs.Length
                    Dim rawdata(fileSize) As Byte
                    fs.Read(rawdata, 0, fileSize)
                    fs.Close()
                    Cmd.Parameters("@file").Value = rawdata
                    Cmd.Parameters("@idfile").Value = Rd.GetValue(Rd.GetOrdinal("idFile"))
                    Cmd.ExecuteNonQuery()
                    Conn.Close()
                Else
                    sqlString = "INSERT INTO `file` (`namaFile`, `pemilikFile`, `tanggalFile`, `tipeFile`, `file`) VALUES (?,?,?,?,?)"
                    Cmd = New OdbcCommand(sqlString, Conn)
                    Cmd.Parameters.Add("@nama", OdbcType.VarChar)
                    Cmd.Parameters.Add("@pemilik", OdbcType.Int)
                    Cmd.Parameters.Add("@tanggal", OdbcType.Date)
                    Cmd.Parameters.Add("@tipefile", OdbcType.VarChar)
                    Cmd.Parameters.Add("@file", OdbcType.Binary)
                    Cmd.Parameters("@nama").Value = lbPerpus.Text
                    Cmd.Parameters("@pemilik").Value = Session.idSiswa
                    Cmd.Parameters("@tanggal").Value = Date.Now
                    Cmd.Parameters("@tipefile").Value = tipe

                    Dim fs As System.IO.FileStream = New IO.FileStream(perpusFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim fileSize As UInt32 = fs.Length
                    Dim rawdata(fileSize) As Byte
                    fs.Read(rawdata, 0, fileSize)
                    fs.Close()
                    Cmd.Parameters("@file").Value = rawdata
                    Cmd.ExecuteNonQuery()
                    Conn.Close()
                End If
            End If
        End If


    End Sub

End Class