Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Deployment.Application

Public Class FrmMain
    Dim dsUserCards As DataSet
    Dim lUsersCardsNo As Integer
    Dim lCurrentCardIndex As Integer = 0
    Dim lCardId, lShiftID As Integer

    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.UserName = gUser.UserName
        odbaccess.LogOut()
        Application.Exit()
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'DsShifts.shifts' table. You can move, or remove it, as needed.
        Me.ShiftsTableAdapter.Fill(Me.DsShifts.shifts)
        CheckPermission()
        Me.Text += gUser.UserName

        If gUser.type = Enumerators.UsersTypes.CardsUser Then
            Me.PanelDistributor.Visible = False
            Me.PanelCardsUser.Location = New Point(0, 108)
            Me.SettingToolStripMenuItem.Visible = False
            Me.ReportsToolStripMenuItem.Visible = False
            Me.IiiToolStripMenuItem.Visible = True
            Me.AddSimCardsOrdersToolStripMenuItem.Enabled = True
            ViewSimCardsOrdersToolStripMenuItem.Enabled = True
            Me.ReportsToolStripMenuItem.Visible = False
            '  FillDataSets()

        ElseIf gUser.type = Enumerators.UsersTypes.Supervisor Then
            Me.PanelDistributor.Visible = False
            Me.PanelCardsUser.Location = New Point(0, 108)
            Me.SettingToolStripMenuItem.Visible = False
            Me.btnShiftEndUsersDevices2.Visible = True
            Me.ProvidersBalancesToolStripMenuItem.Visible = True
            Me.ProvidersBalancesToolStripMenuItem.Enabled = True
            Me.IiiToolStripMenuItem.Visible = True
            Me.AddSimCardsOrdersToolStripMenuItem.Enabled = True
            ViewSimCardsOrdersToolStripMenuItem.Enabled = True
            Me.ReportsToolStripMenuItem.Visible = True
            ToolStripMenuItem1.Enabled = True
            SlotDetailsReportToolStripMenuItem.Enabled = True

        ElseIf gUser.type = Enumerators.UsersTypes.Audit Then
            Me.PanelCardsUser.Visible = False
            Me.PanelDistributor.Location = New Point(0, 108)
            Me.btnShiftEndUsers.Location = New Point(175, 155)
            Me.btnShiftEndUsers.Visible = True
            Me.ProvidersBalancesToolStripMenuItem.Visible = True
            Me.ShiftReportToolStripMenuItem.Visible = True
            ShiftReportsFolderToolStripMenuItem.Visible = True
            Me.IiiToolStripMenuItem.Visible = True
            AddExpensesAirtimeCardsToolStripMenuItem.Enabled = True
            AddExpensesOthersToolStripMenuItem.Enabled = True
            AddSimCardsOrdersToolStripMenuItem.Enabled = True
            AddProviderPaymentsToolStripMenuItem.Enabled = True
            ViewExpensesToolStripMenuItem.Enabled = True
            ViewSimCardsOrdersToolStripMenuItem.Enabled = True
            ViewProviderPayementsToolStripMenuItem.Enabled = True
            Me.CardsStatusToolStripMenuItem.Visible = True
            Me.ReportsToolStripMenuItem.Visible = True
            ToolStripMenuItem1.Enabled = True
            SlotDetailsReportToolStripMenuItem.Enabled = True

        ElseIf gUser.type = Enumerators.UsersTypes.Provider Then
            Me.PanelCardsUser.Visible = False
            Me.PanelDistributor.Location = New Point(0, 108)
            Me.SettingToolStripMenuItem.Visible = False
            Me.btnDistributedCards.Visible = False
            Me.btnAddNewCards.Location = New Point(85, 46)
            Me.btnNewCards.Location = New Point(264, 46)
            Me.btnWrongCards.Location = New Point(85, 127)
            Me.btnCorrectedCards.Location = New Point(264, 127)
            Me.btnSendCards.Visible = False
            Me.ReportsToolStripMenuItem.Visible = False
            IiiToolStripMenuItem.Visible = False

        ElseIf gUser.type = Enumerators.UsersTypes.Admin Then
            Me.PanelCardsUser.Visible = False
            Me.ToolStripSeparator1.Visible = True
            Me.ManageUsersToolStripMenuItem.Visible = True
            Me.ReportsToolStripMenuItem.Visible = True
            Me.btnShiftEndUsersDevices.Visible = True
            Me.btnShiftEndUsersDevices.Location = New Point(255, 155)
            Me.btnShiftEndUsers.Location = New Point(94, 155)
            Me.btnShiftEndUsers.Visible = True
            Me.ProvidersBalancesToolStripMenuItem.Visible = True
            Me.CardsLessThanLimitToolStripMenuItem.Visible = True
            Me.ProviderCardsReportToolStripMenuItem.Visible = True
            Me.InsertedByProviderReportToolStripMenuItem.Visible = True
            Me.ShiftReportToolStripMenuItem.Visible = True
            Me.IiiToolStripMenuItem.Visible = True
            AddExpensesAirtimeCardsToolStripMenuItem.Enabled = True
            AddExpensesOthersToolStripMenuItem.Enabled = True
            AddSimCardsOrdersToolStripMenuItem.Enabled = True
            AddProviderPaymentsToolStripMenuItem.Enabled = True
            ViewExpensesToolStripMenuItem.Enabled = True
            ViewSimCardsOrdersToolStripMenuItem.Enabled = True
            ViewProviderPayementsToolStripMenuItem.Enabled = True
            ShiftReportsFolderToolStripMenuItem.Visible = True
            Me.CardsStatusToolStripMenuItem.Visible = True
            Me.ReportsToolStripMenuItem.Visible = True
            ToolStripMenuItem1.Enabled = True
            SlotDetailsReportToolStripMenuItem.Enabled = True
            InsertedByProviderReportToolStripMenuItem.Enabled = True
            ProviderCardsReportToolStripMenuItem.Enabled = True
            CardsLessThanLimitToolStripMenuItem.Enabled = True
            ProvidersBalancesToolStripMenuItem.Enabled = True
            ShiftReportToolStripMenuItem.Enabled = True
            CardsStatusToolStripMenuItem.Enabled = True

        End If
    End Sub

    Public Sub CheckPermission()


    End Sub

    Private Sub btnAddNewCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewCards.Click
        If Application.OpenForms().OfType(Of frmAddCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddCards(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub btnNewCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCards.Click
        If Application.OpenForms().OfType(Of frmCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCards
            frm.Show()
        End If
    End Sub

    Private Sub btnDistributedCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDistributedCards.Click
        If Application.OpenForms().OfType(Of frmDistributedCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmDistributedCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmDistributedCards
            frm.Show()
        End If
    End Sub

    Private Sub btnWrongCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrongCards.Click
        If Application.OpenForms().OfType(Of frmWrongCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmWrongCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmWrongCards
            frm.Show()
        End If
    End Sub

    Private Sub btnCorrectedCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrectedCards.Click
        If Application.OpenForms().OfType(Of frmCorrectedCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCorrectedCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCorrectedCards
            frm.Show()
        End If
    End Sub

    Private Sub CountriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountriesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmCountries).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("FrmCountries") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmCountries
            frm.Show()
        End If
    End Sub

    Private Sub OperatorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperatorsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmOperators).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmOperators") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmOperators
            frm.Show()
        End If
    End Sub

    Private Sub ProvidersAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvidersAccountsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmProviders).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmProviders") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmProviders
            frm.Show()
        End If
    End Sub

    Private Sub CategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCategories).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCategories") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCategories
            frm.Show()
        End If
    End Sub

    Private Sub CardsResourcesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardsResourcesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmCardsResources).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("FrmCardsResources") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmCardsResources
            frm.Show()
        End If
    End Sub

    Private Sub ResetPasswordToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetPasswordToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmChangePassword).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmChangePassword") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmChangePassword
            frm.Show()
        End If
    End Sub

    Private Sub btnUseCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseCards.Click
        If Application.OpenForms().OfType(Of frmUseCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmUseCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmUseCards(lShiftID)
            frm.Show()
        End If
    End Sub

    Private Sub btnReturnCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCards.Click
        If MsgBox("Are you sure you want to return all unused cards?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
            If odbaccess.ReturnCardsFromCardUser() Then
                MsgBox("All cards returned successfully.")
            Else
                MsgBox("An error occured!")
            End If
        End If
    End Sub

    Private Sub ManageUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageUsersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmUser).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmUser") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmUser
            frm.Show()
        End If
    End Sub

    Private Sub ProviderCardsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProviderCardsReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCardsReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCardsReport") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCardsReport
            frm.Show()
        End If
    End Sub

    Private Sub InsertedByProviderReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertedByProviderReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCardsInsertedByProviderReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCardsInsertedByProviderReport") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCardsInsertedByProviderReport
            frm.Show()
        End If
    End Sub

    Private Sub CardsLessThanLimitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardsLessThanLimitToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCardsLessThanOperatorLimit).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCardsLessThanOperatorLimit") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCardsLessThanOperatorLimit
            frm.Show()
        End If
    End Sub

    Private Sub LocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLocations).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmLocations") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmLocations
            frm.Show()
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftEndUsers.Click
        If Application.OpenForms().OfType(Of frmChooseShiftEndUsers).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmChooseShiftEndUsers") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmChooseShiftEndUsers()
            frm.Show()
        End If
    End Sub

    Private Sub DevicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevicesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmDevices).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmDevices") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmDevices()
            frm.Show()
        End If
    End Sub

    Private Sub btnShiftEndUsersDevices2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftEndUsersDevices2.Click, btnShiftEndUsersDevices.Click
        If Application.OpenForms().OfType(Of frmShiftEndUsers_Devices).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmShiftEndUsers_Devices") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmShiftEndUsers_Devices()
            frm.Show()
        End If
    End Sub

    Private Sub btnSendCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendCards.Click
        If Application.OpenForms().OfType(Of frmSendCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmSendCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmSendCards()
            frm.Show()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.btnUseCards.Enabled = False
        Try
            Dim ds As New DataSet
            ds = odbaccess.getShiftID(Me.DateTimePicker1.Value, CInt(Me.cmbShifts.SelectedValue))
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)

                If CInt(dr.Item("ShiftID")) = 0 Then
                    Me.lblError.Text = "There is no information about this shift."
                Else
                    If CBool(dr.Item("isEndUserFound")) = False Then
                        Me.lblError.Text = "You are not listed in the selected shift."
                    End If
                    If CBool(dr.Item("isLastShift")) = False Then
                        Me.lblError.Text = "The shift chosen is from the past."
                    End If

                    If CBool(dr.Item("isEndUserFound")) And CBool(dr.Item("isLastShift")) Then
                        Me.lShiftID = CInt(dr.Item("ShiftID"))
                        Me.btnUseCards.Enabled = True
                        Me.lblError.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExpensesOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesOptionsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmExpensesOptions).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmExpensesOptions") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmExpensesOptions()
            frm.Show()
        End If
    End Sub

    Private Sub AddExpensesAirtimeCardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddExpensesAirtimeCardsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddExpense_Cards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddExpense_Cards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddExpense_Cards(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub AddExpensesOthersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddExpensesOthersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddExpense_Others).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddExpense_Others") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddExpense_Others(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub AddSimCardsOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSimCardsOrdersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddSimCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddSimCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddSimCards(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub ViewExpensesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewExpensesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmExpenses).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmExpenses") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmExpenses
            frm.Show()
        End If
    End Sub

    Private Sub SimCardsTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimCardsTypesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSimCardsType).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmSimCardsType") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmSimCardsType()
            frm.Show()
        End If
    End Sub

    Private Sub ViewSimCardsOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewSimCardsOrdersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSimCardsOrders).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmSimCardsOrders") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmSimCardsOrders()
            frm.Show()
        End If
    End Sub


    Private Sub AddProviderPaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddProviderPaymentsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddProviderPayment).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddProviderPayment") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddProviderPayment(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub ViewProviderPayementsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewProviderPayementsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmProviderPayments).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmProviderPayments") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmProviderPayments()
            frm.Show()
        End If
    End Sub

    Private Sub ProvidersBalancesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvidersBalancesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmProvidersBalancesReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmProvidersBalancesReport") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmProvidersBalancesReport()
            frm.Show()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        Me.PrintForm1.Print()
    End Sub


    Private Sub btnDeviceConsumption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceConsumption.Click
        If Application.OpenForms().OfType(Of frmDeviceConsumptionReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmDeviceConsumptionReport") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmDeviceConsumptionReport()
            frm.Show()
        End If
    End Sub

    Private Sub ShiftReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShiftReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmShiftReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmShiftReport") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmShiftReport()
            frm.Show()
        End If
    End Sub

    Private Sub ShiftReportsFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShiftReportsFolderToolStripMenuItem.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.SelectedPath = My.Settings.RootDirectory
        folderDlg.ShowNewFolderButton = True
        folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
        If (folderDlg.ShowDialog() = DialogResult.OK) Then

            '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
            My.Settings.RootDirectory = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub CardsStatusToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CardsStatusToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCardStatus).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCardStatus") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCardStatus()
            frm.Show()
        End If
    End Sub

   
    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmSlotsInfoReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmSlotsInfoReport") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmSlotsInfoReport()
            frm.Show()
        End If
    End Sub

    Private Sub SlotDetailsReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SlotDetailsReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSlotDetailsReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmSlotDetailsReport") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmSlotDetailsReport()
            frm.Show()
        End If
    End Sub
End Class
