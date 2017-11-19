<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSlotDetailsReport
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSlotDetailsReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbUsersCharged = New System.Windows.Forms.ComboBox()
        Me.cmbUsersCreate = New System.Windows.Forms.ComboBox()
        Me.chkUsersCharged = New System.Windows.Forms.CheckBox()
        Me.chkUserCreated = New System.Windows.Forms.CheckBox()
        Me.cmbOperators = New System.Windows.Forms.ComboBox()
        Me.chkOperator = New System.Windows.Forms.CheckBox()
        Me.chkSlot = New System.Windows.Forms.CheckBox()
        Me.cmbSlot = New System.Windows.Forms.ComboBox()
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSlots = New WindowsApplication1.dsSlots()
        Me.cmbDevices = New System.Windows.Forms.ComboBox()
        Me.chkDevice = New System.Windows.Forms.CheckBox()
        Me.cmbCountries = New System.Windows.Forms.ComboBox()
        Me.chkCountry = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dgCountry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDevice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgOperator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSlot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgStartedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCutTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgRechargedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCutBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditCategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ShiftsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsShifts = New WindowsApplication1.dsShifts()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ShiftsTableAdapter = New WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.DataTable1TableAdapter = New WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSlots, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ShiftsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripHideColumn.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmbUsersCharged)
        Me.Panel1.Controls.Add(Me.cmbUsersCreate)
        Me.Panel1.Controls.Add(Me.chkUsersCharged)
        Me.Panel1.Controls.Add(Me.chkUserCreated)
        Me.Panel1.Controls.Add(Me.cmbOperators)
        Me.Panel1.Controls.Add(Me.chkOperator)
        Me.Panel1.Controls.Add(Me.chkSlot)
        Me.Panel1.Controls.Add(Me.cmbSlot)
        Me.Panel1.Controls.Add(Me.cmbDevices)
        Me.Panel1.Controls.Add(Me.chkDevice)
        Me.Panel1.Controls.Add(Me.cmbCountries)
        Me.Panel1.Controls.Add(Me.chkCountry)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpToDate)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.chkDate)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1241, 580)
        Me.Panel1.TabIndex = 0
        '
        'cmbUsersCharged
        '
        Me.cmbUsersCharged.DisplayMember = "Name"
        Me.cmbUsersCharged.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsersCharged.Enabled = False
        Me.cmbUsersCharged.FormattingEnabled = True
        Me.cmbUsersCharged.Location = New System.Drawing.Point(761, 39)
        Me.cmbUsersCharged.Name = "cmbUsersCharged"
        Me.cmbUsersCharged.Size = New System.Drawing.Size(170, 24)
        Me.cmbUsersCharged.TabIndex = 159
        Me.cmbUsersCharged.ValueMember = "ID"
        '
        'cmbUsersCreate
        '
        Me.cmbUsersCreate.DisplayMember = "Name"
        Me.cmbUsersCreate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsersCreate.Enabled = False
        Me.cmbUsersCreate.FormattingEnabled = True
        Me.cmbUsersCreate.Location = New System.Drawing.Point(761, 7)
        Me.cmbUsersCreate.Name = "cmbUsersCreate"
        Me.cmbUsersCreate.Size = New System.Drawing.Size(170, 24)
        Me.cmbUsersCreate.TabIndex = 159
        Me.cmbUsersCreate.ValueMember = "ID"
        '
        'chkUsersCharged
        '
        Me.chkUsersCharged.AutoSize = True
        Me.chkUsersCharged.Location = New System.Drawing.Point(661, 41)
        Me.chkUsersCharged.Name = "chkUsersCharged"
        Me.chkUsersCharged.Size = New System.Drawing.Size(101, 20)
        Me.chkUsersCharged.TabIndex = 160
        Me.chkUsersCharged.Text = "Charged by"
        Me.chkUsersCharged.UseVisualStyleBackColor = True
        '
        'chkUserCreated
        '
        Me.chkUserCreated.AutoSize = True
        Me.chkUserCreated.Location = New System.Drawing.Point(661, 9)
        Me.chkUserCreated.Name = "chkUserCreated"
        Me.chkUserCreated.Size = New System.Drawing.Size(99, 20)
        Me.chkUserCreated.TabIndex = 160
        Me.chkUserCreated.Text = "Created by"
        Me.chkUserCreated.UseVisualStyleBackColor = True
        '
        'cmbOperators
        '
        Me.cmbOperators.DisplayMember = "Name"
        Me.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperators.Enabled = False
        Me.cmbOperators.FormattingEnabled = True
        Me.cmbOperators.Location = New System.Drawing.Point(443, 39)
        Me.cmbOperators.Name = "cmbOperators"
        Me.cmbOperators.Size = New System.Drawing.Size(182, 24)
        Me.cmbOperators.TabIndex = 157
        Me.cmbOperators.ValueMember = "ID"
        '
        'chkOperator
        '
        Me.chkOperator.AutoSize = True
        Me.chkOperator.Location = New System.Drawing.Point(352, 41)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(86, 20)
        Me.chkOperator.TabIndex = 158
        Me.chkOperator.Text = "Operator"
        Me.chkOperator.UseVisualStyleBackColor = True
        '
        'chkSlot
        '
        Me.chkSlot.AutoSize = True
        Me.chkSlot.Location = New System.Drawing.Point(352, 9)
        Me.chkSlot.Name = "chkSlot"
        Me.chkSlot.Size = New System.Drawing.Size(52, 20)
        Me.chkSlot.TabIndex = 156
        Me.chkSlot.Text = "Slot"
        Me.chkSlot.UseVisualStyleBackColor = True
        '
        'cmbSlot
        '
        Me.cmbSlot.DataSource = Me.DataTable1BindingSource
        Me.cmbSlot.DisplayMember = "Slot"
        Me.cmbSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSlot.Enabled = False
        Me.cmbSlot.FormattingEnabled = True
        Me.cmbSlot.Location = New System.Drawing.Point(443, 7)
        Me.cmbSlot.Name = "cmbSlot"
        Me.cmbSlot.Size = New System.Drawing.Size(182, 24)
        Me.cmbSlot.TabIndex = 155
        Me.cmbSlot.ValueMember = "ID"
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        Me.DataTable1BindingSource.DataSource = Me.DsSlots
        '
        'DsSlots
        '
        Me.DsSlots.DataSetName = "dsSlots"
        Me.DsSlots.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbDevices
        '
        Me.cmbDevices.DisplayMember = "Name"
        Me.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevices.Enabled = False
        Me.cmbDevices.FormattingEnabled = True
        Me.cmbDevices.Location = New System.Drawing.Point(96, 39)
        Me.cmbDevices.Name = "cmbDevices"
        Me.cmbDevices.Size = New System.Drawing.Size(216, 24)
        Me.cmbDevices.TabIndex = 153
        Me.cmbDevices.ValueMember = "ID"
        '
        'chkDevice
        '
        Me.chkDevice.AutoSize = True
        Me.chkDevice.Location = New System.Drawing.Point(12, 41)
        Me.chkDevice.Name = "chkDevice"
        Me.chkDevice.Size = New System.Drawing.Size(70, 20)
        Me.chkDevice.TabIndex = 154
        Me.chkDevice.Text = "Device"
        Me.chkDevice.UseVisualStyleBackColor = True
        '
        'cmbCountries
        '
        Me.cmbCountries.DisplayMember = "Name"
        Me.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountries.Enabled = False
        Me.cmbCountries.FormattingEnabled = True
        Me.cmbCountries.Location = New System.Drawing.Point(96, 7)
        Me.cmbCountries.Name = "cmbCountries"
        Me.cmbCountries.Size = New System.Drawing.Size(216, 24)
        Me.cmbCountries.TabIndex = 151
        Me.cmbCountries.ValueMember = "ID"
        '
        'chkCountry
        '
        Me.chkCountry.AutoSize = True
        Me.chkCountry.Location = New System.Drawing.Point(12, 9)
        Me.chkCountry.Name = "chkCountry"
        Me.chkCountry.Size = New System.Drawing.Size(79, 20)
        Me.chkCountry.TabIndex = 152
        Me.chkCountry.Text = "Country"
        Me.chkCountry.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 16)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(376, 73)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(201, 23)
        Me.dtpToDate.TabIndex = 147
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Enabled = False
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(140, 73)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(201, 23)
        Me.dtpFromDate.TabIndex = 148
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(12, 74)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(131, 20)
        Me.chkDate.TabIndex = 150
        Me.chkDate.Text = "Start Date From"
        Me.chkDate.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgCountry, Me.dgDevice, Me.dgOperator, Me.dgSlot, Me.dgCreateTime, Me.dgCreatedBy, Me.dgStartTime, Me.dgStartedBy, Me.dgCutTime, Me.dgRechargedBy, Me.dgCutBy})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Location = New System.Drawing.Point(4, 105)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1233, 471)
        Me.DataGridView1.TabIndex = 37
        '
        'dgCountry
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgCountry.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCountry.HeaderText = "Country"
        Me.dgCountry.Name = "dgCountry"
        Me.dgCountry.ReadOnly = True
        Me.dgCountry.Width = 120
        '
        'dgDevice
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgDevice.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDevice.HeaderText = "Device"
        Me.dgDevice.Name = "dgDevice"
        Me.dgDevice.ReadOnly = True
        '
        'dgOperator
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgOperator.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgOperator.HeaderText = "Operator"
        Me.dgOperator.Name = "dgOperator"
        Me.dgOperator.ReadOnly = True
        Me.dgOperator.Width = 120
        '
        'dgSlot
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgSlot.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgSlot.HeaderText = "Slot"
        Me.dgSlot.Name = "dgSlot"
        Me.dgSlot.ReadOnly = True
        '
        'dgCreateTime
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgCreateTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgCreateTime.HeaderText = "Create Time"
        Me.dgCreateTime.Name = "dgCreateTime"
        Me.dgCreateTime.ReadOnly = True
        Me.dgCreateTime.Width = 150
        '
        'dgCreatedBy
        '
        Me.dgCreatedBy.HeaderText = "Created By"
        Me.dgCreatedBy.Name = "dgCreatedBy"
        Me.dgCreatedBy.ReadOnly = True
        '
        'dgStartTime
        '
        Me.dgStartTime.HeaderText = "Start Time"
        Me.dgStartTime.Name = "dgStartTime"
        Me.dgStartTime.ReadOnly = True
        Me.dgStartTime.Width = 150
        '
        'dgStartedBy
        '
        Me.dgStartedBy.HeaderText = "Started By"
        Me.dgStartedBy.Name = "dgStartedBy"
        Me.dgStartedBy.ReadOnly = True
        '
        'dgCutTime
        '
        Me.dgCutTime.HeaderText = "Cut Time"
        Me.dgCutTime.Name = "dgCutTime"
        Me.dgCutTime.ReadOnly = True
        Me.dgCutTime.Width = 150
        '
        'dgRechargedBy
        '
        Me.dgRechargedBy.HeaderText = "Recharged By"
        Me.dgRechargedBy.Name = "dgRechargedBy"
        Me.dgRechargedBy.ReadOnly = True
        Me.dgRechargedBy.Width = 200
        '
        'dgCutBy
        '
        Me.dgCutBy.HeaderText = "Cut By"
        Me.dgCutBy.Name = "dgCutBy"
        Me.dgCutBy.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditCategoryToolStripMenuItem, Me.DeleteCategoryToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(134, 76)
        '
        'EditCategoryToolStripMenuItem
        '
        Me.EditCategoryToolStripMenuItem.Name = "EditCategoryToolStripMenuItem"
        Me.EditCategoryToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.EditCategoryToolStripMenuItem.Text = "Edit Category"
        '
        'DeleteCategoryToolStripMenuItem
        '
        Me.DeleteCategoryToolStripMenuItem.Name = "DeleteCategoryToolStripMenuItem"
        Me.DeleteCategoryToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DeleteCategoryToolStripMenuItem.Text = "Delete Category"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(130, 6)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1101, 7)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
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
        '
        'ShiftsTableAdapter
        '
        Me.ShiftsTableAdapter.ClearBeforeFill = True
        '
        'DataTable1TableAdapter
        '
        Me.DataTable1TableAdapter.ClearBeforeFill = True
        '
        'frmSlotDetailsReport
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1245, 585)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSlotDetailsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Slot Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSlots, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ShiftsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsShifts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripHideColumn.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripHideColumn As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents EditCategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteCategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DsShifts As WindowsApplication1.dsShifts
    Friend WithEvents ShiftsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShiftsTableAdapter As WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents dgCountry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgDevice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSlot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgStartedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgRechargedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCutBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkSlot As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSlot As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents chkDevice As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCountries As System.Windows.Forms.ComboBox
    Friend WithEvents chkCountry As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOperators As System.Windows.Forms.ComboBox
    Friend WithEvents chkOperator As System.Windows.Forms.CheckBox
    Friend WithEvents DsSlots As WindowsApplication1.dsSlots
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataTable1TableAdapter As WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter
    Friend WithEvents cmbUsersCharged As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUsersCreate As System.Windows.Forms.ComboBox
    Friend WithEvents chkUsersCharged As System.Windows.Forms.CheckBox
    Friend WithEvents chkUserCreated As System.Windows.Forms.CheckBox

End Class
