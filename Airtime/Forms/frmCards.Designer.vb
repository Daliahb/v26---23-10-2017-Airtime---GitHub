<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCards
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCards))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbDeviceSet = New System.Windows.Forms.GroupBox()
        Me.rbYes = New System.Windows.Forms.RadioButton()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.chkDeviceSet = New System.Windows.Forms.CheckBox()
        Me.PanelSetDevices = New System.Windows.Forms.Panel()
        Me.cmbDevices = New System.Windows.Forms.ComboBox()
        Me.rbDevice = New System.Windows.Forms.RadioButton()
        Me.rbNoDevice = New System.Windows.Forms.RadioButton()
        Me.btnSelect2 = New System.Windows.Forms.Button()
        Me.txtSelectNo2 = New System.Windows.Forms.TextBox()
        Me.chkClearAll2 = New System.Windows.Forms.CheckBox()
        Me.btnSetDevice = New System.Windows.Forms.Button()
        Me.chkSelectAll2 = New System.Windows.Forms.CheckBox()
        Me.txtCardNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbOperators = New System.Windows.Forms.ComboBox()
        Me.cmbProviders = New System.Windows.Forms.ComboBox()
        Me.cmbCountries = New System.Windows.Forms.ComboBox()
        Me.chkLocation = New System.Windows.Forms.CheckBox()
        Me.chkCard = New System.Windows.Forms.CheckBox()
        Me.chkCategory = New System.Windows.Forms.CheckBox()
        Me.chkOperator = New System.Windows.Forms.CheckBox()
        Me.chkCountry = New System.Windows.Forms.CheckBox()
        Me.chkProvider = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operatorww = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.Panel1.SuspendLayout()
        Me.gbDeviceSet.SuspendLayout()
        Me.PanelSetDevices.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripHideColumn.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.gbDeviceSet)
        Me.Panel1.Controls.Add(Me.chkDeviceSet)
        Me.Panel1.Controls.Add(Me.PanelSetDevices)
        Me.Panel1.Controls.Add(Me.txtCardNumber)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpToDate)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.chkDate)
        Me.Panel1.Controls.Add(Me.cmbLocation)
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Controls.Add(Me.cmbOperators)
        Me.Panel1.Controls.Add(Me.cmbProviders)
        Me.Panel1.Controls.Add(Me.cmbCountries)
        Me.Panel1.Controls.Add(Me.chkLocation)
        Me.Panel1.Controls.Add(Me.chkCard)
        Me.Panel1.Controls.Add(Me.chkCategory)
        Me.Panel1.Controls.Add(Me.chkOperator)
        Me.Panel1.Controls.Add(Me.chkCountry)
        Me.Panel1.Controls.Add(Me.chkProvider)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1290, 472)
        Me.Panel1.TabIndex = 2
        '
        'gbDeviceSet
        '
        Me.gbDeviceSet.Controls.Add(Me.rbYes)
        Me.gbDeviceSet.Controls.Add(Me.rbNo)
        Me.gbDeviceSet.Enabled = False
        Me.gbDeviceSet.Location = New System.Drawing.Point(415, 116)
        Me.gbDeviceSet.Name = "gbDeviceSet"
        Me.gbDeviceSet.Size = New System.Drawing.Size(150, 38)
        Me.gbDeviceSet.TabIndex = 109
        Me.gbDeviceSet.TabStop = False
        Me.gbDeviceSet.Visible = False
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Location = New System.Drawing.Point(6, 13)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(50, 20)
        Me.rbYes.TabIndex = 0
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(80, 13)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(42, 20)
        Me.rbNo.TabIndex = 1
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'chkDeviceSet
        '
        Me.chkDeviceSet.AutoSize = True
        Me.chkDeviceSet.Location = New System.Drawing.Point(316, 129)
        Me.chkDeviceSet.Name = "chkDeviceSet"
        Me.chkDeviceSet.Size = New System.Drawing.Size(96, 20)
        Me.chkDeviceSet.TabIndex = 110
        Me.chkDeviceSet.Text = "Device Set"
        Me.chkDeviceSet.UseVisualStyleBackColor = True
        Me.chkDeviceSet.Visible = False
        '
        'PanelSetDevices
        '
        Me.PanelSetDevices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSetDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSetDevices.Controls.Add(Me.cmbDevices)
        Me.PanelSetDevices.Controls.Add(Me.rbDevice)
        Me.PanelSetDevices.Controls.Add(Me.rbNoDevice)
        Me.PanelSetDevices.Controls.Add(Me.btnSelect2)
        Me.PanelSetDevices.Controls.Add(Me.txtSelectNo2)
        Me.PanelSetDevices.Controls.Add(Me.chkClearAll2)
        Me.PanelSetDevices.Controls.Add(Me.btnSetDevice)
        Me.PanelSetDevices.Controls.Add(Me.chkSelectAll2)
        Me.PanelSetDevices.Location = New System.Drawing.Point(916, 48)
        Me.PanelSetDevices.Name = "PanelSetDevices"
        Me.PanelSetDevices.Size = New System.Drawing.Size(357, 101)
        Me.PanelSetDevices.TabIndex = 108
        Me.PanelSetDevices.Visible = False
        '
        'cmbDevices
        '
        Me.cmbDevices.DisplayMember = "Name"
        Me.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevices.FormattingEnabled = True
        Me.cmbDevices.Location = New System.Drawing.Point(78, 51)
        Me.cmbDevices.Name = "cmbDevices"
        Me.cmbDevices.Size = New System.Drawing.Size(141, 24)
        Me.cmbDevices.TabIndex = 102
        Me.cmbDevices.ValueMember = "ID"
        '
        'rbDevice
        '
        Me.rbDevice.AutoSize = True
        Me.rbDevice.Checked = True
        Me.rbDevice.Location = New System.Drawing.Point(3, 52)
        Me.rbDevice.Name = "rbDevice"
        Me.rbDevice.Size = New System.Drawing.Size(74, 20)
        Me.rbDevice.TabIndex = 103
        Me.rbDevice.TabStop = True
        Me.rbDevice.Text = "Device:"
        Me.rbDevice.UseVisualStyleBackColor = True
        '
        'rbNoDevice
        '
        Me.rbNoDevice.AutoSize = True
        Me.rbNoDevice.Location = New System.Drawing.Point(3, 78)
        Me.rbNoDevice.Name = "rbNoDevice"
        Me.rbNoDevice.Size = New System.Drawing.Size(92, 20)
        Me.rbNoDevice.TabIndex = 111
        Me.rbNoDevice.Text = "No device."
        Me.rbNoDevice.UseVisualStyleBackColor = True
        '
        'btnSelect2
        '
        Me.btnSelect2.Location = New System.Drawing.Point(8, 12)
        Me.btnSelect2.Name = "btnSelect2"
        Me.btnSelect2.Size = New System.Drawing.Size(77, 23)
        Me.btnSelect2.TabIndex = 102
        Me.btnSelect2.Text = "Select"
        Me.btnSelect2.UseVisualStyleBackColor = True
        '
        'txtSelectNo2
        '
        Me.txtSelectNo2.Location = New System.Drawing.Point(91, 12)
        Me.txtSelectNo2.Name = "txtSelectNo2"
        Me.txtSelectNo2.Size = New System.Drawing.Size(39, 23)
        Me.txtSelectNo2.TabIndex = 61
        Me.txtSelectNo2.Text = "0"
        '
        'chkClearAll2
        '
        Me.chkClearAll2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkClearAll2.AutoSize = True
        Me.chkClearAll2.BackColor = System.Drawing.Color.Transparent
        Me.chkClearAll2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearAll2.Location = New System.Drawing.Point(276, 15)
        Me.chkClearAll2.Name = "chkClearAll2"
        Me.chkClearAll2.Size = New System.Drawing.Size(72, 17)
        Me.chkClearAll2.TabIndex = 59
        Me.chkClearAll2.Text = "Clear All"
        Me.chkClearAll2.UseVisualStyleBackColor = False
        '
        'btnSetDevice
        '
        Me.btnSetDevice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetDevice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetDevice.Location = New System.Drawing.Point(242, 63)
        Me.btnSetDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetDevice.Name = "btnSetDevice"
        Me.btnSetDevice.Size = New System.Drawing.Size(109, 31)
        Me.btnSetDevice.TabIndex = 60
        Me.btnSetDevice.Tag = ""
        Me.btnSetDevice.Text = "Set Device"
        Me.btnSetDevice.UseVisualStyleBackColor = True
        '
        'chkSelectAll2
        '
        Me.chkSelectAll2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSelectAll2.AutoSize = True
        Me.chkSelectAll2.BackColor = System.Drawing.Color.Transparent
        Me.chkSelectAll2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAll2.Location = New System.Drawing.Point(182, 15)
        Me.chkSelectAll2.Name = "chkSelectAll2"
        Me.chkSelectAll2.Size = New System.Drawing.Size(78, 17)
        Me.chkSelectAll2.TabIndex = 58
        Me.chkSelectAll2.Text = "Select All"
        Me.chkSelectAll2.UseVisualStyleBackColor = False
        '
        'txtCardNumber
        '
        Me.txtCardNumber.Enabled = False
        Me.txtCardNumber.Location = New System.Drawing.Point(415, 69)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.Size = New System.Drawing.Size(200, 23)
        Me.txtCardNumber.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(384, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(415, 40)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(200, 23)
        Me.dtpToDate.TabIndex = 102
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Enabled = False
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(415, 11)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(200, 23)
        Me.dtpFromDate.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(368, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "From"
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(316, 12)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(58, 20)
        Me.chkDate.TabIndex = 106
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'cmbLocation
        '
        Me.cmbLocation.DisplayMember = "ID"
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocation.Enabled = False
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(90, 127)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(215, 24)
        Me.cmbLocation.TabIndex = 96
        Me.cmbLocation.ValueMember = "ID"
        '
        'cmbCategory
        '
        Me.cmbCategory.DisplayMember = "Name"
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.Enabled = False
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(90, 97)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(215, 24)
        Me.cmbCategory.TabIndex = 96
        Me.cmbCategory.ValueMember = "ID"
        '
        'cmbOperators
        '
        Me.cmbOperators.DisplayMember = "Name"
        Me.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperators.Enabled = False
        Me.cmbOperators.FormattingEnabled = True
        Me.cmbOperators.Location = New System.Drawing.Point(90, 68)
        Me.cmbOperators.Name = "cmbOperators"
        Me.cmbOperators.Size = New System.Drawing.Size(215, 24)
        Me.cmbOperators.TabIndex = 95
        Me.cmbOperators.ValueMember = "ID"
        '
        'cmbProviders
        '
        Me.cmbProviders.DisplayMember = "Name"
        Me.cmbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProviders.Enabled = False
        Me.cmbProviders.FormattingEnabled = True
        Me.cmbProviders.Location = New System.Drawing.Point(89, 39)
        Me.cmbProviders.Name = "cmbProviders"
        Me.cmbProviders.Size = New System.Drawing.Size(216, 24)
        Me.cmbProviders.TabIndex = 91
        Me.cmbProviders.ValueMember = "ID"
        '
        'cmbCountries
        '
        Me.cmbCountries.DisplayMember = "Name"
        Me.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountries.Enabled = False
        Me.cmbCountries.FormattingEnabled = True
        Me.cmbCountries.Location = New System.Drawing.Point(89, 10)
        Me.cmbCountries.Name = "cmbCountries"
        Me.cmbCountries.Size = New System.Drawing.Size(216, 24)
        Me.cmbCountries.TabIndex = 92
        Me.cmbCountries.ValueMember = "ID"
        '
        'chkLocation
        '
        Me.chkLocation.AutoSize = True
        Me.chkLocation.Location = New System.Drawing.Point(8, 129)
        Me.chkLocation.Name = "chkLocation"
        Me.chkLocation.Size = New System.Drawing.Size(82, 20)
        Me.chkLocation.TabIndex = 98
        Me.chkLocation.Text = "Location"
        Me.chkLocation.UseVisualStyleBackColor = True
        '
        'chkCard
        '
        Me.chkCard.AutoSize = True
        Me.chkCard.Location = New System.Drawing.Point(316, 70)
        Me.chkCard.Name = "chkCard"
        Me.chkCard.Size = New System.Drawing.Size(101, 20)
        Me.chkCard.TabIndex = 98
        Me.chkCard.Text = "Scratch No."
        Me.chkCard.UseVisualStyleBackColor = True
        '
        'chkCategory
        '
        Me.chkCategory.AutoSize = True
        Me.chkCategory.Location = New System.Drawing.Point(8, 99)
        Me.chkCategory.Name = "chkCategory"
        Me.chkCategory.Size = New System.Drawing.Size(87, 20)
        Me.chkCategory.TabIndex = 98
        Me.chkCategory.Text = "Category"
        Me.chkCategory.UseVisualStyleBackColor = True
        '
        'chkOperator
        '
        Me.chkOperator.AutoSize = True
        Me.chkOperator.Location = New System.Drawing.Point(8, 70)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(86, 20)
        Me.chkOperator.TabIndex = 98
        Me.chkOperator.Text = "Operator"
        Me.chkOperator.UseVisualStyleBackColor = True
        '
        'chkCountry
        '
        Me.chkCountry.AutoSize = True
        Me.chkCountry.Location = New System.Drawing.Point(8, 12)
        Me.chkCountry.Name = "chkCountry"
        Me.chkCountry.Size = New System.Drawing.Size(79, 20)
        Me.chkCountry.TabIndex = 98
        Me.chkCountry.Text = "Country"
        Me.chkCountry.UseVisualStyleBackColor = True
        '
        'chkProvider
        '
        Me.chkProvider.AutoSize = True
        Me.chkProvider.Location = New System.Drawing.Point(8, 41)
        Me.chkProvider.Name = "chkProvider"
        Me.chkProvider.Size = New System.Drawing.Size(82, 20)
        Me.chkProvider.TabIndex = 98
        Me.chkProvider.Text = "Provider"
        Me.chkProvider.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1044, 8)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 33)
        Me.Button1.TabIndex = 88
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.Column8, Me.clNo, Me.Column1, Me.Category, Me.Column3, Me.Operatorww, Me.Column2, Me.Column4, Me.Column7, Me.Column5, Me.Column6, Me.Column9})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.Location = New System.Drawing.Point(8, 159)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1265, 309)
        Me.DataGridView1.TabIndex = 37
        '
        'clID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clID.DefaultCellStyle = DataGridViewCellStyle2
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        Me.clID.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "Send"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 55
        '
        'clNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.clNo.HeaderText = "No."
        Me.clNo.Name = "clNo"
        Me.clNo.ReadOnly = True
        Me.clNo.Width = 40
        '
        'Column1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column1.HeaderText = "Scratch No."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 220
        '
        'Category
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle5
        Me.Category.HeaderText = "Country"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 120
        '
        'Column3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column3.HeaderText = "Provider"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Operatorww
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Operatorww.DefaultCellStyle = DataGridViewCellStyle7
        Me.Operatorww.HeaderText = "Operator"
        Me.Operatorww.Name = "Operatorww"
        Me.Operatorww.ReadOnly = True
        Me.Operatorww.Width = 150
        '
        'Column2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column2.HeaderText = "Category"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Insert Date"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column7.HeaderText = "Insert Time"
        Me.Column7.Name = "Column7"
        '
        'Column5
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column5.HeaderText = "Inserted By"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column6.HeaderText = "Recieved Using"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Device"
        Me.Column9.Name = "Column9"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1137, 7)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHistoryToolStripMenuItem, Me.DeleteCardToolStripMenuItem, Me.EditCardsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 98)
        '
        'ShowHistoryToolStripMenuItem
        '
        Me.ShowHistoryToolStripMenuItem.Name = "ShowHistoryToolStripMenuItem"
        Me.ShowHistoryToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ShowHistoryToolStripMenuItem.Text = "Show Card History"
        '
        'DeleteCardToolStripMenuItem
        '
        Me.DeleteCardToolStripMenuItem.Name = "DeleteCardToolStripMenuItem"
        Me.DeleteCardToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.DeleteCardToolStripMenuItem.Text = "Delete Cards"
        Me.DeleteCardToolStripMenuItem.Visible = False
        '
        'EditCardsToolStripMenuItem
        '
        Me.EditCardsToolStripMenuItem.Name = "EditCardsToolStripMenuItem"
        Me.EditCardsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EditCardsToolStripMenuItem.Text = "Edit Cards"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'ContextMenuStripHideColumn
        '
        Me.ContextMenuStripHideColumn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideColumnToolStripMenuItem, Me.ShowAllColumnsToolStripMenuItem})
        Me.ContextMenuStripHideColumn.Name = "ContextMenuStripHideColumn"
        Me.ContextMenuStripHideColumn.Size = New System.Drawing.Size(172, 48)
        '
        'HideColumnToolStripMenuItem
        '
        Me.HideColumnToolStripMenuItem.Name = "HideColumnToolStripMenuItem"
        Me.HideColumnToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.HideColumnToolStripMenuItem.Text = "Hide Column"
        '
        'ShowAllColumnsToolStripMenuItem
        '
        Me.ShowAllColumnsToolStripMenuItem.Name = "ShowAllColumnsToolStripMenuItem"
        Me.ShowAllColumnsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ShowAllColumnsToolStripMenuItem.Text = "Show All Columns"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'frmCards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1278, 477)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Cards"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbDeviceSet.ResumeLayout(False)
        Me.gbDeviceSet.PerformLayout()
        Me.PanelSetDevices.ResumeLayout(False)
        Me.PanelSetDevices.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripHideColumn.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperators As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProviders As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCountries As System.Windows.Forms.ComboBox
    Friend WithEvents chkCard As System.Windows.Forms.CheckBox
    Friend WithEvents chkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents chkOperator As System.Windows.Forms.CheckBox
    Friend WithEvents chkCountry As System.Windows.Forms.CheckBox
    Friend WithEvents chkProvider As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripHideColumn As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents chkLocation As System.Windows.Forms.CheckBox
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operatorww As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditCardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelSetDevices As System.Windows.Forms.Panel
    Friend WithEvents cmbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelect2 As System.Windows.Forms.Button
    Friend WithEvents txtSelectNo2 As System.Windows.Forms.TextBox
    Friend WithEvents chkClearAll2 As System.Windows.Forms.CheckBox
    Friend WithEvents btnSetDevice As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll2 As System.Windows.Forms.CheckBox
    Friend WithEvents gbDeviceSet As System.Windows.Forms.GroupBox
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents chkDeviceSet As System.Windows.Forms.CheckBox
    Friend WithEvents rbDevice As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoDevice As System.Windows.Forms.RadioButton
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm

End Class
