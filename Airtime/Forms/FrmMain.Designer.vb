<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProvidersAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperatorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardsResourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExpensesOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimCardsTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ManageUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetPasswordToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShiftReportsFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertedByProviderReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProviderCardsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardsLessThanLimitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProvidersBalancesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShiftReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CardsStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevicePerformanceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SlotDetailsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardsValuesUsedPerSlotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IiiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddExpensesAirtimeCardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddExpensesOthersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddSimCardsOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddProviderPaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewExpensesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSimCardsOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewProviderPayementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelCardsUser = New System.Windows.Forms.Panel()
        Me.btnDeviceConsumption = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnShiftEndUsersDevices2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cmbShifts = New System.Windows.Forms.ComboBox()
        Me.ShiftsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsShifts = New WindowsApplication1.dsShifts()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnReturnCards = New System.Windows.Forms.Button()
        Me.btnUseCards = New System.Windows.Forms.Button()
        Me.PanelDistributor = New System.Windows.Forms.Panel()
        Me.btnReturnShiftCards = New System.Windows.Forms.Button()
        Me.btnShiftEndUsersDevices = New System.Windows.Forms.Button()
        Me.btnDistributedCards = New System.Windows.Forms.Button()
        Me.btnShiftEndUsers = New System.Windows.Forms.Button()
        Me.btnCorrectedCards = New System.Windows.Forms.Button()
        Me.btnWrongCards = New System.Windows.Forms.Button()
        Me.btnSendCards = New System.Windows.Forms.Button()
        Me.btnNewCards = New System.Windows.Forms.Button()
        Me.btnAddNewCards = New System.Windows.Forms.Button()
        Me.ShiftsTableAdapter = New WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.PanelCardsUser.SuspendLayout()
        CType(Me.ShiftsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDistributor.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CountriesToolStripMenuItem, Me.ProvidersAccountsToolStripMenuItem, Me.OperatorsToolStripMenuItem, Me.CategoriesToolStripMenuItem, Me.CardsResourcesToolStripMenuItem, Me.LocationsToolStripMenuItem, Me.DevicesToolStripMenuItem, Me.ToolStripSeparator2, Me.ExpensesOptionsToolStripMenuItem, Me.SimCardsTypesToolStripMenuItem, Me.ToolStripSeparator1, Me.ManageUsersToolStripMenuItem})
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'CountriesToolStripMenuItem
        '
        Me.CountriesToolStripMenuItem.Name = "CountriesToolStripMenuItem"
        Me.CountriesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CountriesToolStripMenuItem.Text = "Countries"
        '
        'ProvidersAccountsToolStripMenuItem
        '
        Me.ProvidersAccountsToolStripMenuItem.Name = "ProvidersAccountsToolStripMenuItem"
        Me.ProvidersAccountsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ProvidersAccountsToolStripMenuItem.Text = "Providers"
        '
        'OperatorsToolStripMenuItem
        '
        Me.OperatorsToolStripMenuItem.Name = "OperatorsToolStripMenuItem"
        Me.OperatorsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OperatorsToolStripMenuItem.Text = "Operators"
        '
        'CategoriesToolStripMenuItem
        '
        Me.CategoriesToolStripMenuItem.Name = "CategoriesToolStripMenuItem"
        Me.CategoriesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CategoriesToolStripMenuItem.Text = "Categories"
        '
        'CardsResourcesToolStripMenuItem
        '
        Me.CardsResourcesToolStripMenuItem.Name = "CardsResourcesToolStripMenuItem"
        Me.CardsResourcesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CardsResourcesToolStripMenuItem.Text = "Cards Resources"
        '
        'LocationsToolStripMenuItem
        '
        Me.LocationsToolStripMenuItem.Name = "LocationsToolStripMenuItem"
        Me.LocationsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LocationsToolStripMenuItem.Text = "Locations"
        '
        'DevicesToolStripMenuItem
        '
        Me.DevicesToolStripMenuItem.Name = "DevicesToolStripMenuItem"
        Me.DevicesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DevicesToolStripMenuItem.Text = "Devices"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'ExpensesOptionsToolStripMenuItem
        '
        Me.ExpensesOptionsToolStripMenuItem.Name = "ExpensesOptionsToolStripMenuItem"
        Me.ExpensesOptionsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExpensesOptionsToolStripMenuItem.Text = "Expenses Categories"
        '
        'SimCardsTypesToolStripMenuItem
        '
        Me.SimCardsTypesToolStripMenuItem.Name = "SimCardsTypesToolStripMenuItem"
        Me.SimCardsTypesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SimCardsTypesToolStripMenuItem.Text = "Sim Cards Types"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'ManageUsersToolStripMenuItem
        '
        Me.ManageUsersToolStripMenuItem.Name = "ManageUsersToolStripMenuItem"
        Me.ManageUsersToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ManageUsersToolStripMenuItem.Text = "Manage Users"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.SettingToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.IiiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(505, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetPasswordToolStripMenuItem1, Me.ShiftReportsFolderToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ResetPasswordToolStripMenuItem1
        '
        Me.ResetPasswordToolStripMenuItem1.Name = "ResetPasswordToolStripMenuItem1"
        Me.ResetPasswordToolStripMenuItem1.Size = New System.Drawing.Size(196, 22)
        Me.ResetPasswordToolStripMenuItem1.Text = "Reset Password"
        '
        'ShiftReportsFolderToolStripMenuItem
        '
        Me.ShiftReportsFolderToolStripMenuItem.Name = "ShiftReportsFolderToolStripMenuItem"
        Me.ShiftReportsFolderToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ShiftReportsFolderToolStripMenuItem.Text = "Set Shift Reports Folder"
        Me.ShiftReportsFolderToolStripMenuItem.Visible = False
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertedByProviderReportToolStripMenuItem, Me.ProviderCardsReportToolStripMenuItem, Me.CardsLessThanLimitToolStripMenuItem, Me.ProvidersBalancesToolStripMenuItem, Me.ShiftReportToolStripMenuItem, Me.ToolStripSeparator6, Me.CardsStatusToolStripMenuItem, Me.DevicePerformanceToolStripMenuItem1, Me.SlotDetailsReportToolStripMenuItem, Me.CardsValuesUsedPerSlotToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'InsertedByProviderReportToolStripMenuItem
        '
        Me.InsertedByProviderReportToolStripMenuItem.Enabled = False
        Me.InsertedByProviderReportToolStripMenuItem.Name = "InsertedByProviderReportToolStripMenuItem"
        Me.InsertedByProviderReportToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.InsertedByProviderReportToolStripMenuItem.Text = "Inserted by Provider Report"
        Me.InsertedByProviderReportToolStripMenuItem.Visible = False
        '
        'ProviderCardsReportToolStripMenuItem
        '
        Me.ProviderCardsReportToolStripMenuItem.Enabled = False
        Me.ProviderCardsReportToolStripMenuItem.Name = "ProviderCardsReportToolStripMenuItem"
        Me.ProviderCardsReportToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ProviderCardsReportToolStripMenuItem.Text = "Providers-Cards Report"
        Me.ProviderCardsReportToolStripMenuItem.Visible = False
        '
        'CardsLessThanLimitToolStripMenuItem
        '
        Me.CardsLessThanLimitToolStripMenuItem.Enabled = False
        Me.CardsLessThanLimitToolStripMenuItem.Name = "CardsLessThanLimitToolStripMenuItem"
        Me.CardsLessThanLimitToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CardsLessThanLimitToolStripMenuItem.Text = "Cards less than limit"
        Me.CardsLessThanLimitToolStripMenuItem.Visible = False
        '
        'ProvidersBalancesToolStripMenuItem
        '
        Me.ProvidersBalancesToolStripMenuItem.Enabled = False
        Me.ProvidersBalancesToolStripMenuItem.Name = "ProvidersBalancesToolStripMenuItem"
        Me.ProvidersBalancesToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ProvidersBalancesToolStripMenuItem.Text = "Providers Balances"
        Me.ProvidersBalancesToolStripMenuItem.Visible = False
        '
        'ShiftReportToolStripMenuItem
        '
        Me.ShiftReportToolStripMenuItem.Enabled = False
        Me.ShiftReportToolStripMenuItem.Name = "ShiftReportToolStripMenuItem"
        Me.ShiftReportToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ShiftReportToolStripMenuItem.Text = "Shift Report"
        Me.ShiftReportToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(246, 6)
        '
        'CardsStatusToolStripMenuItem
        '
        Me.CardsStatusToolStripMenuItem.Enabled = False
        Me.CardsStatusToolStripMenuItem.Name = "CardsStatusToolStripMenuItem"
        Me.CardsStatusToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CardsStatusToolStripMenuItem.Text = "Cards Status"
        Me.CardsStatusToolStripMenuItem.Visible = False
        '
        'DevicePerformanceToolStripMenuItem1
        '
        Me.DevicePerformanceToolStripMenuItem1.Enabled = False
        Me.DevicePerformanceToolStripMenuItem1.Name = "DevicePerformanceToolStripMenuItem1"
        Me.DevicePerformanceToolStripMenuItem1.Size = New System.Drawing.Size(249, 22)
        Me.DevicePerformanceToolStripMenuItem1.Text = "Device Performance Report"
        '
        'SlotDetailsReportToolStripMenuItem
        '
        Me.SlotDetailsReportToolStripMenuItem.Enabled = False
        Me.SlotDetailsReportToolStripMenuItem.Name = "SlotDetailsReportToolStripMenuItem"
        Me.SlotDetailsReportToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.SlotDetailsReportToolStripMenuItem.Text = "Slot Details Report"
        '
        'CardsValuesUsedPerSlotToolStripMenuItem
        '
        Me.CardsValuesUsedPerSlotToolStripMenuItem.Enabled = False
        Me.CardsValuesUsedPerSlotToolStripMenuItem.Name = "CardsValuesUsedPerSlotToolStripMenuItem"
        Me.CardsValuesUsedPerSlotToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CardsValuesUsedPerSlotToolStripMenuItem.Text = "Cards Values used per Slot Report"
        '
        'IiiToolStripMenuItem
        '
        Me.IiiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddExpensesAirtimeCardsToolStripMenuItem, Me.AddExpensesOthersToolStripMenuItem, Me.ToolStripSeparator3, Me.AddSimCardsOrdersToolStripMenuItem, Me.ToolStripSeparator4, Me.AddProviderPaymentsToolStripMenuItem, Me.ToolStripSeparator5, Me.ViewExpensesToolStripMenuItem, Me.ViewSimCardsOrdersToolStripMenuItem, Me.ViewProviderPayementsToolStripMenuItem})
        Me.IiiToolStripMenuItem.Name = "IiiToolStripMenuItem"
        Me.IiiToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.IiiToolStripMenuItem.Text = "Expenses/Transfers"
        '
        'AddExpensesAirtimeCardsToolStripMenuItem
        '
        Me.AddExpensesAirtimeCardsToolStripMenuItem.Enabled = False
        Me.AddExpensesAirtimeCardsToolStripMenuItem.Name = "AddExpensesAirtimeCardsToolStripMenuItem"
        Me.AddExpensesAirtimeCardsToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AddExpensesAirtimeCardsToolStripMenuItem.Text = "Add Expenses - Airtime Cards"
        '
        'AddExpensesOthersToolStripMenuItem
        '
        Me.AddExpensesOthersToolStripMenuItem.Enabled = False
        Me.AddExpensesOthersToolStripMenuItem.Name = "AddExpensesOthersToolStripMenuItem"
        Me.AddExpensesOthersToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AddExpensesOthersToolStripMenuItem.Text = "Add Expenses - Others"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(226, 6)
        '
        'AddSimCardsOrdersToolStripMenuItem
        '
        Me.AddSimCardsOrdersToolStripMenuItem.Enabled = False
        Me.AddSimCardsOrdersToolStripMenuItem.Name = "AddSimCardsOrdersToolStripMenuItem"
        Me.AddSimCardsOrdersToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AddSimCardsOrdersToolStripMenuItem.Text = "Add Sim Cards Orders"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(226, 6)
        '
        'AddProviderPaymentsToolStripMenuItem
        '
        Me.AddProviderPaymentsToolStripMenuItem.Enabled = False
        Me.AddProviderPaymentsToolStripMenuItem.Name = "AddProviderPaymentsToolStripMenuItem"
        Me.AddProviderPaymentsToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AddProviderPaymentsToolStripMenuItem.Text = "Add Money Transfers"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(226, 6)
        '
        'ViewExpensesToolStripMenuItem
        '
        Me.ViewExpensesToolStripMenuItem.Enabled = False
        Me.ViewExpensesToolStripMenuItem.Name = "ViewExpensesToolStripMenuItem"
        Me.ViewExpensesToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ViewExpensesToolStripMenuItem.Text = "View Expenses"
        '
        'ViewSimCardsOrdersToolStripMenuItem
        '
        Me.ViewSimCardsOrdersToolStripMenuItem.Enabled = False
        Me.ViewSimCardsOrdersToolStripMenuItem.Name = "ViewSimCardsOrdersToolStripMenuItem"
        Me.ViewSimCardsOrdersToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ViewSimCardsOrdersToolStripMenuItem.Text = "View Sim Cards Orders"
        '
        'ViewProviderPayementsToolStripMenuItem
        '
        Me.ViewProviderPayementsToolStripMenuItem.Enabled = False
        Me.ViewProviderPayementsToolStripMenuItem.Name = "ViewProviderPayementsToolStripMenuItem"
        Me.ViewProviderPayementsToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ViewProviderPayementsToolStripMenuItem.Text = "View Money Transfers"
        '
        'PanelCardsUser
        '
        Me.PanelCardsUser.Controls.Add(Me.btnDeviceConsumption)
        Me.PanelCardsUser.Controls.Add(Me.lblError)
        Me.PanelCardsUser.Controls.Add(Me.btnShiftEndUsersDevices2)
        Me.PanelCardsUser.Controls.Add(Me.Button3)
        Me.PanelCardsUser.Controls.Add(Me.DateTimePicker1)
        Me.PanelCardsUser.Controls.Add(Me.cmbShifts)
        Me.PanelCardsUser.Controls.Add(Me.Label1)
        Me.PanelCardsUser.Controls.Add(Me.Label9)
        Me.PanelCardsUser.Controls.Add(Me.btnReturnCards)
        Me.PanelCardsUser.Controls.Add(Me.btnUseCards)
        Me.PanelCardsUser.Location = New System.Drawing.Point(511, 108)
        Me.PanelCardsUser.Name = "PanelCardsUser"
        Me.PanelCardsUser.Size = New System.Drawing.Size(504, 217)
        Me.PanelCardsUser.TabIndex = 20
        '
        'btnDeviceConsumption
        '
        Me.btnDeviceConsumption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeviceConsumption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnDeviceConsumption.Image = CType(resources.GetObject("btnDeviceConsumption.Image"), System.Drawing.Image)
        Me.btnDeviceConsumption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeviceConsumption.Location = New System.Drawing.Point(60, 155)
        Me.btnDeviceConsumption.Name = "btnDeviceConsumption"
        Me.btnDeviceConsumption.Size = New System.Drawing.Size(185, 43)
        Me.btnDeviceConsumption.TabIndex = 114
        Me.btnDeviceConsumption.Text = "      Devices Consumption"
        Me.btnDeviceConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeviceConsumption.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.DarkRed
        Me.lblError.Location = New System.Drawing.Point(19, 76)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 113
        '
        'btnShiftEndUsersDevices2
        '
        Me.btnShiftEndUsersDevices2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftEndUsersDevices2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnShiftEndUsersDevices2.Image = CType(resources.GetObject("btnShiftEndUsersDevices2.Image"), System.Drawing.Image)
        Me.btnShiftEndUsersDevices2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShiftEndUsersDevices2.Location = New System.Drawing.Point(263, 155)
        Me.btnShiftEndUsersDevices2.Name = "btnShiftEndUsersDevices2"
        Me.btnShiftEndUsersDevices2.Size = New System.Drawing.Size(185, 43)
        Me.btnShiftEndUsersDevices2.TabIndex = 21
        Me.btnShiftEndUsersDevices2.Text = "    Shift End Users' Devices"
        Me.btnShiftEndUsersDevices2.UseVisualStyleBackColor = True
        Me.btnShiftEndUsersDevices2.Visible = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(407, 34)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(59, 23)
        Me.Button3.TabIndex = 111
        Me.Button3.Text = "Check"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dddd d/MM/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(63, 35)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 23)
        Me.DateTimePicker1.TabIndex = 112
        '
        'cmbShifts
        '
        Me.cmbShifts.DataSource = Me.ShiftsBindingSource
        Me.cmbShifts.DisplayMember = "Shift"
        Me.cmbShifts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShifts.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShifts.FormattingEnabled = True
        Me.cmbShifts.Location = New System.Drawing.Point(321, 34)
        Me.cmbShifts.Name = "cmbShifts"
        Me.cmbShifts.Size = New System.Drawing.Size(80, 24)
        Me.cmbShifts.TabIndex = 111
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(280, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Shift"
        '
        'btnReturnCards
        '
        Me.btnReturnCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturnCards.Image = CType(resources.GetObject("btnReturnCards.Image"), System.Drawing.Image)
        Me.btnReturnCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturnCards.Location = New System.Drawing.Point(263, 92)
        Me.btnReturnCards.Name = "btnReturnCards"
        Me.btnReturnCards.Size = New System.Drawing.Size(185, 43)
        Me.btnReturnCards.TabIndex = 108
        Me.btnReturnCards.Text = "   Return not used cards"
        Me.btnReturnCards.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReturnCards.UseVisualStyleBackColor = True
        '
        'btnUseCards
        '
        Me.btnUseCards.Enabled = False
        Me.btnUseCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUseCards.Image = CType(resources.GetObject("btnUseCards.Image"), System.Drawing.Image)
        Me.btnUseCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUseCards.Location = New System.Drawing.Point(60, 92)
        Me.btnUseCards.Name = "btnUseCards"
        Me.btnUseCards.Size = New System.Drawing.Size(186, 43)
        Me.btnUseCards.TabIndex = 107
        Me.btnUseCards.Text = "Get my cards"
        Me.btnUseCards.UseVisualStyleBackColor = True
        '
        'PanelDistributor
        '
        Me.PanelDistributor.Controls.Add(Me.btnReturnShiftCards)
        Me.PanelDistributor.Controls.Add(Me.btnShiftEndUsersDevices)
        Me.PanelDistributor.Controls.Add(Me.btnDistributedCards)
        Me.PanelDistributor.Controls.Add(Me.btnShiftEndUsers)
        Me.PanelDistributor.Controls.Add(Me.btnCorrectedCards)
        Me.PanelDistributor.Controls.Add(Me.btnWrongCards)
        Me.PanelDistributor.Controls.Add(Me.btnSendCards)
        Me.PanelDistributor.Controls.Add(Me.btnNewCards)
        Me.PanelDistributor.Controls.Add(Me.btnAddNewCards)
        Me.PanelDistributor.Location = New System.Drawing.Point(0, 108)
        Me.PanelDistributor.Name = "PanelDistributor"
        Me.PanelDistributor.Size = New System.Drawing.Size(504, 217)
        Me.PanelDistributor.TabIndex = 109
        '
        'btnReturnShiftCards
        '
        Me.btnReturnShiftCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturnShiftCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnReturnShiftCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturnShiftCards.Location = New System.Drawing.Point(336, 153)
        Me.btnReturnShiftCards.Name = "btnReturnShiftCards"
        Me.btnReturnShiftCards.Size = New System.Drawing.Size(155, 43)
        Me.btnReturnShiftCards.TabIndex = 115
        Me.btnReturnShiftCards.Text = "Return Shift Cards"
        Me.btnReturnShiftCards.UseVisualStyleBackColor = True
        Me.btnReturnShiftCards.Visible = False
        '
        'btnShiftEndUsersDevices
        '
        Me.btnShiftEndUsersDevices.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftEndUsersDevices.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnShiftEndUsersDevices.Image = CType(resources.GetObject("btnShiftEndUsersDevices.Image"), System.Drawing.Image)
        Me.btnShiftEndUsersDevices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShiftEndUsersDevices.Location = New System.Drawing.Point(174, 153)
        Me.btnShiftEndUsersDevices.Name = "btnShiftEndUsersDevices"
        Me.btnShiftEndUsersDevices.Size = New System.Drawing.Size(155, 43)
        Me.btnShiftEndUsersDevices.TabIndex = 114
        Me.btnShiftEndUsersDevices.Text = "    Shift End Users' Devices"
        Me.btnShiftEndUsersDevices.UseVisualStyleBackColor = True
        Me.btnShiftEndUsersDevices.Visible = False
        '
        'btnDistributedCards
        '
        Me.btnDistributedCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDistributedCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnDistributedCards.Image = CType(resources.GetObject("btnDistributedCards.Image"), System.Drawing.Image)
        Me.btnDistributedCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDistributedCards.Location = New System.Drawing.Point(14, 88)
        Me.btnDistributedCards.Name = "btnDistributedCards"
        Me.btnDistributedCards.Size = New System.Drawing.Size(155, 43)
        Me.btnDistributedCards.TabIndex = 18
        Me.btnDistributedCards.Text = "Distributed Cards"
        Me.btnDistributedCards.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDistributedCards.UseVisualStyleBackColor = True
        '
        'btnShiftEndUsers
        '
        Me.btnShiftEndUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftEndUsers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnShiftEndUsers.Image = CType(resources.GetObject("btnShiftEndUsers.Image"), System.Drawing.Image)
        Me.btnShiftEndUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShiftEndUsers.Location = New System.Drawing.Point(12, 153)
        Me.btnShiftEndUsers.Name = "btnShiftEndUsers"
        Me.btnShiftEndUsers.Size = New System.Drawing.Size(155, 43)
        Me.btnShiftEndUsers.TabIndex = 21
        Me.btnShiftEndUsers.Text = "    Shift - End Users"
        Me.btnShiftEndUsers.UseVisualStyleBackColor = True
        Me.btnShiftEndUsers.Visible = False
        '
        'btnCorrectedCards
        '
        Me.btnCorrectedCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorrectedCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnCorrectedCards.Image = CType(resources.GetObject("btnCorrectedCards.Image"), System.Drawing.Image)
        Me.btnCorrectedCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCorrectedCards.Location = New System.Drawing.Point(336, 88)
        Me.btnCorrectedCards.Name = "btnCorrectedCards"
        Me.btnCorrectedCards.Size = New System.Drawing.Size(155, 43)
        Me.btnCorrectedCards.TabIndex = 20
        Me.btnCorrectedCards.Text = "     Corrected Cards"
        Me.btnCorrectedCards.UseVisualStyleBackColor = True
        '
        'btnWrongCards
        '
        Me.btnWrongCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWrongCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnWrongCards.Image = CType(resources.GetObject("btnWrongCards.Image"), System.Drawing.Image)
        Me.btnWrongCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWrongCards.Location = New System.Drawing.Point(175, 88)
        Me.btnWrongCards.Name = "btnWrongCards"
        Me.btnWrongCards.Size = New System.Drawing.Size(155, 43)
        Me.btnWrongCards.TabIndex = 19
        Me.btnWrongCards.Text = "      Wrong Cards"
        Me.btnWrongCards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWrongCards.UseVisualStyleBackColor = True
        '
        'btnSendCards
        '
        Me.btnSendCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnSendCards.Image = CType(resources.GetObject("btnSendCards.Image"), System.Drawing.Image)
        Me.btnSendCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSendCards.Location = New System.Drawing.Point(336, 23)
        Me.btnSendCards.Name = "btnSendCards"
        Me.btnSendCards.Size = New System.Drawing.Size(155, 43)
        Me.btnSendCards.TabIndex = 17
        Me.btnSendCards.Text = "       Send Cards"
        Me.btnSendCards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSendCards.UseVisualStyleBackColor = True
        '
        'btnNewCards
        '
        Me.btnNewCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnNewCards.Image = CType(resources.GetObject("btnNewCards.Image"), System.Drawing.Image)
        Me.btnNewCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewCards.Location = New System.Drawing.Point(175, 23)
        Me.btnNewCards.Name = "btnNewCards"
        Me.btnNewCards.Size = New System.Drawing.Size(155, 43)
        Me.btnNewCards.TabIndex = 17
        Me.btnNewCards.Text = "       New Cards        "
        Me.btnNewCards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewCards.UseVisualStyleBackColor = True
        '
        'btnAddNewCards
        '
        Me.btnAddNewCards.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewCards.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnAddNewCards.Image = CType(resources.GetObject("btnAddNewCards.Image"), System.Drawing.Image)
        Me.btnAddNewCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddNewCards.Location = New System.Drawing.Point(14, 23)
        Me.btnAddNewCards.Name = "btnAddNewCards"
        Me.btnAddNewCards.Size = New System.Drawing.Size(155, 43)
        Me.btnAddNewCards.TabIndex = 16
        Me.btnAddNewCards.Text = " Add New Cards"
        Me.btnAddNewCards.UseVisualStyleBackColor = True
        '
        'ShiftsTableAdapter
        '
        Me.ShiftsTableAdapter.ClearBeforeFill = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(505, 79)
        Me.PictureBox1.TabIndex = 110
        Me.PictureBox1.TabStop = False
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(505, 328)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PanelDistributor)
        Me.Controls.Add(Me.PanelCardsUser)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Airtime System - "
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelCardsUser.ResumeLayout(False)
        Me.PanelCardsUser.PerformLayout()
        CType(Me.ShiftsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsShifts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDistributor.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PanelCardsUser As System.Windows.Forms.Panel
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProvidersAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CountriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperatorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetPasswordToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUseCards As System.Windows.Forms.Button
    Friend WithEvents CardsResourcesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReturnCards As System.Windows.Forms.Button
    Friend WithEvents PanelDistributor As System.Windows.Forms.Panel
    Friend WithEvents ManageUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProviderCardsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertedByProviderReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CardsLessThanLimitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LocationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnDistributedCards As System.Windows.Forms.Button
    Friend WithEvents btnShiftEndUsers As System.Windows.Forms.Button
    Friend WithEvents btnCorrectedCards As System.Windows.Forms.Button
    Friend WithEvents btnWrongCards As System.Windows.Forms.Button
    Friend WithEvents btnNewCards As System.Windows.Forms.Button
    Friend WithEvents btnAddNewCards As System.Windows.Forms.Button
    Friend WithEvents DevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnShiftEndUsersDevices2 As System.Windows.Forms.Button
    Friend WithEvents btnSendCards As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbShifts As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DsShifts As WindowsApplication1.dsShifts
    Friend WithEvents ShiftsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShiftsTableAdapter As WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnShiftEndUsersDevices As System.Windows.Forms.Button
    Friend WithEvents ExpensesOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IiiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddExpensesAirtimeCardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddExpensesOthersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSimCardsOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewExpensesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSimCardsOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SimCardsTypesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddProviderPaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewProviderPayementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProvidersBalancesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents btnDeviceConsumption As System.Windows.Forms.Button
    Friend WithEvents ShiftReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShiftReportsFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CardsStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DevicePerformanceToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SlotDetailsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CardsValuesUsedPerSlotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReturnShiftCards As System.Windows.Forms.Button
End Class
