<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateDeviceSlot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateDeviceSlot))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtNoOfSims = New System.Windows.Forms.TextBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.lblDevice = New System.Windows.Forms.Label()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbShifts = New System.Windows.Forms.ComboBox()
        Me.ShiftsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsShifts = New WindowsApplication1.dsShifts()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSlots = New System.Windows.Forms.ComboBox()
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSlots1 = New WindowsApplication1.dsSlots()
        Me.lblProvider = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ShiftsTableAdapter = New WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter()
        Me.DataTable1TableAdapter1 = New WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.ShiftsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSlots1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtNote)
        Me.Panel1.Controls.Add(Me.txtNoOfSims)
        Me.Panel1.Controls.Add(Me.CheckedListBox1)
        Me.Panel1.Controls.Add(Me.lblDevice)
        Me.Panel1.Controls.Add(Me.lblOperator)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.cmbShifts)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbSlots)
        Me.Panel1.Controls.Add(Me.lblProvider)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 381)
        Me.Panel1.TabIndex = 0
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(132, 245)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(245, 73)
        Me.txtNote.TabIndex = 89
        '
        'txtNoOfSims
        '
        Me.txtNoOfSims.Location = New System.Drawing.Point(132, 117)
        Me.txtNoOfSims.Name = "txtNoOfSims"
        Me.txtNoOfSims.Size = New System.Drawing.Size(245, 23)
        Me.txtNoOfSims.TabIndex = 89
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Send local calls", "Send international calls", "Recieve local calls", "Recieve international calls", "None"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(132, 145)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(245, 94)
        Me.CheckedListBox1.TabIndex = 88
        '
        'lblDevice
        '
        Me.lblDevice.AutoSize = True
        Me.lblDevice.Location = New System.Drawing.Point(189, 10)
        Me.lblDevice.Name = "lblDevice"
        Me.lblDevice.Size = New System.Drawing.Size(51, 16)
        Me.lblDevice.TabIndex = 87
        Me.lblDevice.Text = "Device"
        '
        'lblOperator
        '
        Me.lblOperator.AutoSize = True
        Me.lblOperator.Location = New System.Drawing.Point(81, 37)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(67, 16)
        Me.lblOperator.TabIndex = 86
        Me.lblOperator.Text = "Operator"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Create new slot for device: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 16)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Human behaviour:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(129, 336)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(132, 35)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbShifts
        '
        Me.cmbShifts.DataSource = Me.ShiftsBindingSource
        Me.cmbShifts.DisplayMember = "Shift"
        Me.cmbShifts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShifts.FormattingEnabled = True
        Me.cmbShifts.Location = New System.Drawing.Point(132, 59)
        Me.cmbShifts.Name = "cmbShifts"
        Me.cmbShifts.Size = New System.Drawing.Size(245, 24)
        Me.cmbShifts.TabIndex = 80
        Me.cmbShifts.ValueMember = "ID"
        '
        'ShiftsBindingSource
        '
        Me.ShiftsBindingSource.DataMember = "shifts"
        Me.ShiftsBindingSource.DataSource = Me.DsShifts
        '
        'DsShifts
        '
        Me.DsShifts.DataSetName = "dsShifts"
        Me.DsShifts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 16)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Note:"
        '
        'cmbSlots
        '
        Me.cmbSlots.DataSource = Me.DataTable1BindingSource
        Me.cmbSlots.DisplayMember = "Slot"
        Me.cmbSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSlots.FormattingEnabled = True
        Me.cmbSlots.Location = New System.Drawing.Point(132, 88)
        Me.cmbSlots.Name = "cmbSlots"
        Me.cmbSlots.Size = New System.Drawing.Size(245, 24)
        Me.cmbSlots.TabIndex = 79
        Me.cmbSlots.ValueMember = "ID"
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        Me.DataTable1BindingSource.DataSource = Me.DsSlots1
        '
        'DsSlots1
        '
        Me.DsSlots1.DataSetName = "dsSlots"
        Me.DsSlots1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblProvider
        '
        Me.lblProvider.AutoSize = True
        Me.lblProvider.Location = New System.Drawing.Point(6, 118)
        Me.lblProvider.Name = "lblProvider"
        Me.lblProvider.Size = New System.Drawing.Size(112, 16)
        Me.lblProvider.TabIndex = 76
        Me.lblProvider.Text = "Number of Sims:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Operator:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Shift:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Slot:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ShiftsTableAdapter
        '
        Me.ShiftsTableAdapter.ClearBeforeFill = True
        '
        'DataTable1TableAdapter1
        '
        Me.DataTable1TableAdapter1.ClearBeforeFill = True
        '
        'frmCreateDeviceSlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(405, 383)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmCreateDeviceSlot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Slot"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ShiftsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsShifts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSlots1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSlots As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbShifts As System.Windows.Forms.ComboBox
    Friend WithEvents lblProvider As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDevice As System.Windows.Forms.Label
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtNoOfSims As System.Windows.Forms.TextBox
    Friend WithEvents DsSlots As WindowsApplication1.dsSlots
    Friend WithEvents DataTable1TableAdapter As WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DsShifts As WindowsApplication1.dsShifts
    Friend WithEvents ShiftsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShiftsTableAdapter As WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter
    Friend WithEvents DsSlots1 As WindowsApplication1.dsSlots
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataTable1TableAdapter1 As WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter
End Class
