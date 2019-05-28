<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSponsors = New System.Windows.Forms.Button()
        Me.btnGolfers = New System.Windows.Forms.Button()
        Me.btnEvents = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSponsors)
        Me.GroupBox1.Controls.Add(Me.btnGolfers)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 89)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Golfer/Sponsors"
        '
        'btnSponsors
        '
        Me.btnSponsors.Location = New System.Drawing.Point(146, 19)
        Me.btnSponsors.Name = "btnSponsors"
        Me.btnSponsors.Size = New System.Drawing.Size(100, 56)
        Me.btnSponsors.TabIndex = 1
        Me.btnSponsors.Text = "Manage Sponsors"
        Me.btnSponsors.UseVisualStyleBackColor = True
        '
        'btnGolfers
        '
        Me.btnGolfers.Location = New System.Drawing.Point(23, 19)
        Me.btnGolfers.Name = "btnGolfers"
        Me.btnGolfers.Size = New System.Drawing.Size(100, 56)
        Me.btnGolfers.TabIndex = 0
        Me.btnGolfers.Text = "Manage Golfers"
        Me.btnGolfers.UseVisualStyleBackColor = True
        '
        'btnEvents
        '
        Me.btnEvents.Location = New System.Drawing.Point(87, 19)
        Me.btnEvents.Name = "btnEvents"
        Me.btnEvents.Size = New System.Drawing.Size(90, 41)
        Me.btnEvents.TabIndex = 0
        Me.btnEvents.Tag = "Manage Event"
        Me.btnEvents.Text = "Manage Events"
        Me.btnEvents.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(114, 231)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(90, 60)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnEvents)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 75)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Event"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 303)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSponsors As Button
    Friend WithEvents btnGolfers As Button
    Friend WithEvents btnEvents As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox2 As GroupBox
End Class
