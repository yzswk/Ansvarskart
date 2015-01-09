<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ansvarskart
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMMdoc = New System.Windows.Forms.TextBox()
        Me.lbNames = New System.Windows.Forms.CheckedListBox()
        Me.btnNameList = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnNone = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnExportPNG = New System.Windows.Forms.Button()
        Me.btnNotes = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tankekart:"
        '
        'txtMMdoc
        '
        Me.txtMMdoc.Enabled = False
        Me.txtMMdoc.Location = New System.Drawing.Point(107, 13)
        Me.txtMMdoc.Name = "txtMMdoc"
        Me.txtMMdoc.Size = New System.Drawing.Size(778, 22)
        Me.txtMMdoc.TabIndex = 1
        '
        'lbNames
        '
        Me.lbNames.FormattingEnabled = True
        Me.lbNames.Location = New System.Drawing.Point(16, 65)
        Me.lbNames.Name = "lbNames"
        Me.lbNames.Size = New System.Drawing.Size(228, 361)
        Me.lbNames.TabIndex = 2
        '
        'btnNameList
        '
        Me.btnNameList.Location = New System.Drawing.Point(314, 68)
        Me.btnNameList.Name = "btnNameList"
        Me.btnNameList.Size = New System.Drawing.Size(126, 38)
        Me.btnNameList.TabIndex = 3
        Me.btnNameList.Text = "Fyll navneliste"
        Me.btnNameList.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(314, 112)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(126, 40)
        Me.btnSelectAll.TabIndex = 4
        Me.btnSelectAll.Text = "Alle"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnNone
        '
        Me.btnNone.Location = New System.Drawing.Point(446, 112)
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(126, 40)
        Me.btnNone.TabIndex = 5
        Me.btnNone.Text = "Ingen"
        Me.btnNone.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(299, 403)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(639, 22)
        Me.txtStatus.TabIndex = 6
        '
        'btnExportPNG
        '
        Me.btnExportPNG.Enabled = False
        Me.btnExportPNG.Location = New System.Drawing.Point(314, 158)
        Me.btnExportPNG.Name = "btnExportPNG"
        Me.btnExportPNG.Size = New System.Drawing.Size(255, 37)
        Me.btnExportPNG.TabIndex = 7
        Me.btnExportPNG.Text = "Individuelle planer (png)"
        Me.btnExportPNG.UseVisualStyleBackColor = True
        '
        'btnNotes
        '
        Me.btnNotes.Location = New System.Drawing.Point(314, 314)
        Me.btnNotes.Name = "btnNotes"
        Me.btnNotes.Size = New System.Drawing.Size(126, 40)
        Me.btnNotes.TabIndex = 8
        Me.btnNotes.Text = "Notater"
        Me.btnNotes.UseVisualStyleBackColor = True
        '
        'Ansvarskart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 448)
        Me.Controls.Add(Me.btnNotes)
        Me.Controls.Add(Me.btnExportPNG)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnNone)
        Me.Controls.Add(Me.btnNameList)
        Me.Controls.Add(Me.lbNames)
        Me.Controls.Add(Me.txtMMdoc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Ansvarskart"
        Me.Text = "Ansvarskart"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMMdoc As System.Windows.Forms.TextBox
    Friend WithEvents lbNames As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnNameList As System.Windows.Forms.Button
    Private WithEvents btnSelectAll As System.Windows.Forms.Button
    Private WithEvents btnNone As System.Windows.Forms.Button
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnExportPNG As System.Windows.Forms.Button
    Friend WithEvents btnNotes As System.Windows.Forms.Button

End Class
