Imports System.Data.Odbc
Public Class ChangePasswordAdmin


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        homeadmin.Show()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If MsgBox("Apakah Anda Yakin", vbYesNo) = vbYes Then
            Dim sqlString As String = "SELECT * FROM admin WHERE idAdmin=@id"
            sqlString = sqlString.Replace("@id", Session.idAdmin)
            connection()

            Dim Cmd As OdbcCommand = New OdbcCommand(sqlString, Conn)
            Dim Rd As OdbcDataReader = Cmd.ExecuteReader()
            Rd.Read()

            Dim oldpass, newpass, confirm As String
            Dim leng As Integer
            oldpass = Hash(tbPasswordOld.Text)
            newpass = tbPasswordNew.Text
            confirm = tbConfirm.Text

            leng = oldpass.Length * newpass.Length * confirm.Length

            If leng > 0 Then
                If oldpass.Equals(Rd.GetValue(Rd.GetOrdinal("passwordAdmin"))) Then
                    If newpass.Equals(confirm) Then
                        newpass = Hash(newpass)
                        sqlString = "UPDATE `admin` SET passwordAdmin=? WHERE idAdmin=?"
                        Cmd = New OdbcCommand(sqlString, Conn)
                        Cmd.Parameters.Add("@password", OdbcType.VarChar)
                        Cmd.Parameters.Add("@id", OdbcType.Int)
                        Cmd.Parameters("@password").Value = newpass
                        Cmd.Parameters("@id").Value = Session.idAdmin
                        Cmd.ExecuteNonQuery()
                    Else
                        MsgBox("Tolong Konfirmasi Kembali Password Baru Anda")
                    End If
                Else
                    MsgBox("Password Lama anda salah")
                End If
            Else
                MsgBox("Isi Semua kolom yang ada")
            End If
        End If




    End Sub

    Private Sub ChangePasswordAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RoundButton(btnChange)
    End Sub
End Class