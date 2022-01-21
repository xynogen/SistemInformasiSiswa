<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uploadSiswa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uploadSiswa))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnKTP = New System.Windows.Forms.Button()
        Me.btnKTM = New System.Windows.Forms.Button()
        Me.btnPerpus = New System.Windows.Forms.Button()
        Me.lbKTP = New System.Windows.Forms.Label()
        Me.lbKTM = New System.Windows.Forms.Label()
        Me.lbPerpus = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.viewKTP = New System.Windows.Forms.Button()
        Me.viewKTM = New System.Windows.Forms.Button()
        Me.viewPerpus = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(145, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "KTP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(145, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "KTM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(145, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Kartu Perpustakaan"
        '
        'btnKTP
        '
        Me.btnKTP.Location = New System.Drawing.Point(351, 79)
        Me.btnKTP.Name = "btnKTP"
        Me.btnKTP.Size = New System.Drawing.Size(144, 23)
        Me.btnKTP.TabIndex = 4
        Me.btnKTP.Text = "Select"
        Me.btnKTP.UseCompatibleTextRendering = True
        Me.btnKTP.UseVisualStyleBackColor = True
        '
        'btnKTM
        '
        Me.btnKTM.Location = New System.Drawing.Point(351, 149)
        Me.btnKTM.Name = "btnKTM"
        Me.btnKTM.Size = New System.Drawing.Size(144, 23)
        Me.btnKTM.TabIndex = 5
        Me.btnKTM.Text = "Select"
        Me.btnKTM.UseCompatibleTextRendering = True
        Me.btnKTM.UseVisualStyleBackColor = True
        '
        'btnPerpus
        '
        Me.btnPerpus.Location = New System.Drawing.Point(351, 224)
        Me.btnPerpus.Name = "btnPerpus"
        Me.btnPerpus.Size = New System.Drawing.Size(144, 23)
        Me.btnPerpus.TabIndex = 6
        Me.btnPerpus.Text = "Select"
        Me.btnPerpus.UseCompatibleTextRendering = True
        Me.btnPerpus.UseVisualStyleBackColor = True
        '
        'lbKTP
        '
        Me.lbKTP.AutoSize = True
        Me.lbKTP.Location = New System.Drawing.Point(348, 105)
        Me.lbKTP.Name = "lbKTP"
        Me.lbKTP.Size = New System.Drawing.Size(0, 13)
        Me.lbKTP.TabIndex = 7
        '
        'lbKTM
        '
        Me.lbKTM.AutoSize = True
        Me.lbKTM.Location = New System.Drawing.Point(348, 175)
        Me.lbKTM.Name = "lbKTM"
        Me.lbKTM.Size = New System.Drawing.Size(0, 13)
        Me.lbKTM.TabIndex = 8
        '
        'lbPerpus
        '
        Me.lbPerpus.AutoSize = True
        Me.lbPerpus.Location = New System.Drawing.Point(348, 250)
        Me.lbPerpus.Name = "lbPerpus"
        Me.lbPerpus.Size = New System.Drawing.Size(0, 13)
        Me.lbPerpus.TabIndex = 9
        '
        'btnUpload
        '
        Me.btnUpload.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.Location = New System.Drawing.Point(320, 323)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(131, 47)
        Me.btnUpload.TabIndex = 20
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'viewKTP
        '
        Me.viewKTP.Location = New System.Drawing.Point(520, 79)
        Me.viewKTP.Name = "viewKTP"
        Me.viewKTP.Size = New System.Drawing.Size(144, 23)
        Me.viewKTP.TabIndex = 50
        Me.viewKTP.Text = "View"
        Me.viewKTP.UseCompatibleTextRendering = True
        Me.viewKTP.UseVisualStyleBackColor = True
        '
        'viewKTM
        '
        Me.viewKTM.Location = New System.Drawing.Point(520, 149)
        Me.viewKTM.Name = "viewKTM"
        Me.viewKTM.Size = New System.Drawing.Size(144, 23)
        Me.viewKTM.TabIndex = 51
        Me.viewKTM.Text = "View"
        Me.viewKTM.UseCompatibleTextRendering = True
        Me.viewKTM.UseVisualStyleBackColor = True
        '
        'viewPerpus
        '
        Me.viewPerpus.Location = New System.Drawing.Point(520, 224)
        Me.viewPerpus.Name = "viewPerpus"
        Me.viewPerpus.Size = New System.Drawing.Size(144, 23)
        Me.viewPerpus.TabIndex = 52
        Me.viewPerpus.Text = "View"
        Me.viewPerpus.UseCompatibleTextRendering = True
        Me.viewPerpus.UseVisualStyleBackColor = True
        '
        'uploadSiswa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.viewPerpus)
        Me.Controls.Add(Me.viewKTM)
        Me.Controls.Add(Me.viewKTP)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.lbPerpus)
        Me.Controls.Add(Me.lbKTM)
        Me.Controls.Add(Me.lbKTP)
        Me.Controls.Add(Me.btnPerpus)
        Me.Controls.Add(Me.btnKTM)
        Me.Controls.Add(Me.btnKTP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "uploadSiswa"
        Me.Text = "Upload"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnKTP As Button
    Friend WithEvents btnKTM As Button
    Friend WithEvents btnPerpus As Button
    Friend WithEvents lbKTP As Label
    Friend WithEvents lbKTM As Label
    Friend WithEvents lbPerpus As Label
    Friend WithEvents btnUpload As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents viewKTP As Button
    Friend WithEvents viewKTM As Button
    Friend WithEvents viewPerpus As Button
End Class
