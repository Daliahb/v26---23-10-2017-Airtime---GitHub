﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddExpense_Cards
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddExpense_Cards))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbOperators = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbCountries = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbProviders = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtNoOfCards = New System.Windows.Forms.TextBox()
        Me.txtCardValue = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Controls.Add(Me.cmbOperators)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.cmbCountries)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbProviders)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.txtNoOfCards)
        Me.Panel1.Controls.Add(Me.txtCardValue)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 298)
        Me.Panel1.TabIndex = 0
        '
        'cmbCategory
        '
        Me.cmbCategory.DisplayMember = "Name"
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(111, 96)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(245, 24)
        Me.cmbCategory.TabIndex = 3
        Me.cmbCategory.ValueMember = "ID"
        '
        'cmbOperators
        '
        Me.cmbOperators.DisplayMember = "Name"
        Me.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperators.FormattingEnabled = True
        Me.cmbOperators.Location = New System.Drawing.Point(111, 67)
        Me.cmbOperators.Name = "cmbOperators"
        Me.cmbOperators.Size = New System.Drawing.Size(245, 24)
        Me.cmbOperators.TabIndex = 2
        Me.cmbOperators.ValueMember = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Operator"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Order Date"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(111, 125)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(245, 23)
        Me.dtpFromDate.TabIndex = 4
        '
        'cmbCountries
        '
        Me.cmbCountries.DisplayMember = "Name"
        Me.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountries.FormattingEnabled = True
        Me.cmbCountries.Location = New System.Drawing.Point(111, 9)
        Me.cmbCountries.Name = "cmbCountries"
        Me.cmbCountries.Size = New System.Drawing.Size(245, 24)
        Me.cmbCountries.TabIndex = 0
        Me.cmbCountries.ValueMember = "ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Country"
        '
        'cmbProviders
        '
        Me.cmbProviders.DisplayMember = "Name"
        Me.cmbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProviders.FormattingEnabled = True
        Me.cmbProviders.Location = New System.Drawing.Point(111, 38)
        Me.cmbProviders.Name = "cmbProviders"
        Me.cmbProviders.Size = New System.Drawing.Size(245, 24)
        Me.cmbProviders.TabIndex = 1
        Me.cmbProviders.ValueMember = "ID"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Location = New System.Drawing.Point(61, 256)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Total Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "No. of cards"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Card Value"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Provider"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(111, 209)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(245, 23)
        Me.txtTotal.TabIndex = 7
        Me.txtTotal.Text = "0.0"
        '
        'txtNoOfCards
        '
        Me.txtNoOfCards.Location = New System.Drawing.Point(111, 153)
        Me.txtNoOfCards.Name = "txtNoOfCards"
        Me.txtNoOfCards.Size = New System.Drawing.Size(245, 23)
        Me.txtNoOfCards.TabIndex = 5
        Me.txtNoOfCards.Text = "0"
        '
        'txtCardValue
        '
        Me.txtCardValue.Location = New System.Drawing.Point(111, 181)
        Me.txtCardValue.Name = "txtCardValue"
        Me.txtCardValue.Size = New System.Drawing.Size(245, 23)
        Me.txtCardValue.TabIndex = 6
        Me.txtCardValue.Text = "0.0"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmAddExpense_Cards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(383, 300)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAddExpense_Cards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Expenses"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCardValue As System.Windows.Forms.TextBox
    Friend WithEvents cmbProviders As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfCards As System.Windows.Forms.TextBox
    Friend WithEvents cmbCountries As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperators As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
