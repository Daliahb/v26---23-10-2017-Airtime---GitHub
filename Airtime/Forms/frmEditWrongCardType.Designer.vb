<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditWrongCardType
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditWrongCardType))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.lblScratchNo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbAlreadyUsedCard = New System.Windows.Forms.RadioButton()
        Me.rbWrongValue = New System.Windows.Forms.RadioButton()
        Me.rbWrongName = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.lblScratchNo)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 259)
        Me.Panel1.TabIndex = 0
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNote.Location = New System.Drawing.Point(29, 134)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(50, 16)
        Me.lblNote.TabIndex = 120
        Me.lblNote.Text = "Label1"
        Me.lblNote.Visible = False
        '
        'lblScratchNo
        '
        Me.lblScratchNo.AutoSize = True
        Me.lblScratchNo.Location = New System.Drawing.Point(147, 18)
        Me.lblScratchNo.Name = "lblScratchNo"
        Me.lblScratchNo.Size = New System.Drawing.Size(50, 16)
        Me.lblScratchNo.TabIndex = 119
        Me.lblScratchNo.Text = "Label1"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmbCategory)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(29, 58)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(216, 35)
        Me.Panel3.TabIndex = 118
        '
        'cmbCategory
        '
        Me.cmbCategory.DisplayMember = "Name"
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(128, 5)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(82, 24)
        Me.cmbCategory.TabIndex = 110
        Me.cmbCategory.ValueMember = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-2, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 16)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "*Right category is:"
        '
        'rbAlreadyUsedCard
        '
        Me.rbAlreadyUsedCard.AutoSize = True
        Me.rbAlreadyUsedCard.Location = New System.Drawing.Point(12, 104)
        Me.rbAlreadyUsedCard.Name = "rbAlreadyUsedCard"
        Me.rbAlreadyUsedCard.Size = New System.Drawing.Size(149, 20)
        Me.rbAlreadyUsedCard.TabIndex = 117
        Me.rbAlreadyUsedCard.Text = "Already used card."
        Me.rbAlreadyUsedCard.UseVisualStyleBackColor = True
        '
        'rbWrongValue
        '
        Me.rbWrongValue.AutoSize = True
        Me.rbWrongValue.Location = New System.Drawing.Point(12, 32)
        Me.rbWrongValue.Name = "rbWrongValue"
        Me.rbWrongValue.Size = New System.Drawing.Size(112, 20)
        Me.rbWrongValue.TabIndex = 116
        Me.rbWrongValue.Text = "Wrong value."
        Me.rbWrongValue.UseVisualStyleBackColor = True
        '
        'rbWrongName
        '
        Me.rbWrongName.AutoSize = True
        Me.rbWrongName.Location = New System.Drawing.Point(12, 7)
        Me.rbWrongName.Name = "rbWrongName"
        Me.rbWrongName.Size = New System.Drawing.Size(179, 20)
        Me.rbWrongName.TabIndex = 115
        Me.rbWrongName.Text = "Wrong scratch number."
        Me.rbWrongName.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Location = New System.Drawing.Point(36, 217)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(254, 35)
        Me.Panel2.TabIndex = 78
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(136, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(44, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 31)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(44, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 31)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 16)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "New wrong type for "
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblNote)
        Me.Panel4.Controls.Add(Me.rbWrongName)
        Me.Panel4.Controls.Add(Me.rbWrongValue)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.rbAlreadyUsedCard)
        Me.Panel4.Location = New System.Drawing.Point(4, 47)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(319, 161)
        Me.Panel4.TabIndex = 121
        '
        'frmEditWrongCardType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(333, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmEditWrongCardType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Wrong Type Card"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbAlreadyUsedCard As System.Windows.Forms.RadioButton
    Friend WithEvents rbWrongValue As System.Windows.Forms.RadioButton
    Friend WithEvents rbWrongName As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblScratchNo As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
End Class
