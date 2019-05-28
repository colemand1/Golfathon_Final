<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvent
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
        Me.lstGolfers = New System.Windows.Forms.ListBox()
        Me.lstEventGolfers = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cboEventYear = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstGolfers
        '
        Me.lstGolfers.FormattingEnabled = True
        Me.lstGolfers.Location = New System.Drawing.Point(18, 19)
        Me.lstGolfers.Name = "lstGolfers"
        Me.lstGolfers.Size = New System.Drawing.Size(187, 264)
        Me.lstGolfers.TabIndex = 0
        '
        'lstEventGolfers
        '
        Me.lstEventGolfers.FormattingEnabled = True
        Me.lstEventGolfers.Location = New System.Drawing.Point(24, 60)
        Me.lstEventGolfers.Name = "lstEventGolfers"
        Me.lstEventGolfers.Size = New System.Drawing.Size(187, 225)
        Me.lstEventGolfers.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(268, 74)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(106, 51)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add Golfer -->"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(268, 151)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(106, 51)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "<-- Remove Golfer"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'cboEventYear
        '
        Me.cboEventYear.FormattingEnabled = True
        Me.cboEventYear.Location = New System.Drawing.Point(24, 19)
        Me.cboEventYear.Name = "cboEventYear"
        Me.cboEventYear.Size = New System.Drawing.Size(187, 21)
        Me.cboEventYear.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstGolfers)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 299)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Available Golfers:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEventYear)
        Me.GroupBox2.Controls.Add(Me.lstEventGolfers)
        Me.GroupBox2.Location = New System.Drawing.Point(403, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 299)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pick An Event Year:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(268, 285)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(106, 47)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 344)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "frmEvent"
        Me.Text = "frmEvent"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstGolfers As ListBox
    Friend WithEvents lstEventGolfers As ListBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents cboEventYear As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnExit As Button
End Class
