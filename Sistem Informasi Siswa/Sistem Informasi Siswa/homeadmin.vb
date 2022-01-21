Imports System.Data.Odbc
Public Class homeadmin
    Private Sub homeadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refresh()
        RoundButton(btnDeleteUser)
        RoundButton(btnFileUser)
        RoundButton(btnUserData)
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click
        Session.idAdmin = Nothing
        login.Show()
        Me.Hide()


    End Sub

    Private Sub btnFileUser_Click(sender As Object, e As EventArgs) Handles btnFileUser.Click
        Session.idSiswa = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        Me.Hide()
        uploadSiswa.Show()
    End Sub

    Private Sub btnUserData_Click(sender As Object, e As EventArgs) Handles btnUserData.Click
        Session.idSiswa = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        Me.Hide()
        editUser.Show()
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        Dim id As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()

        If id.Length > 0 Then
            If MsgBox("Apakah Anda yakin ?", vbYesNo) = vbYes Then
                connection()
                Dim sqlString As String = "DELETE FROM `siswa` WHERE `siswa`.`idSiswa` = ?;"
                Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
                Cmd.Parameters.Add("@id", OdbcType.Int)
                Cmd.Parameters("@id").Value = id
                Cmd.ExecuteNonQuery()
                Conn.Close()
                refresh()
            End If
        End If
    End Sub

    Private Sub refresh()
        connection()
        Dim Da As OdbcDataAdapter = New OdbcDataAdapter("Select idSiswa, usernameSiswa, namaSiswa, emailSiswa, tanggalLahirSiswa, kotaLahirSiswa, kelasSiswa, noAbsenSiswa, NIMSiswa  From siswa", Conn)
        Dim Ds As DataSet = New DataSet()
        Da.Fill(Ds, "siswa")
        DataGridView1.DataSource = Ds.Tables("siswa")
        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        Conn.Close()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem1.Click
        Me.Hide()
        ChangePasswordAdmin.Show()
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Me.Hide()
        AdminPanel.Show()
    End Sub
End Class