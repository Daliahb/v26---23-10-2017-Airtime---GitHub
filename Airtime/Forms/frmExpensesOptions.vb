Public Class frmExpensesOptions
    Dim boolSaved As Boolean

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Validate()
            Me.DataGridView1.EndEdit()
            Me.Expenses_categoriesTableAdapter.Update(Me.DsExpensesOptions.expenses_categories)

            odbaccess.InsertHistory("Managed Countries")
            MsgBox("Data saved successfully")
            boolSaved = True
            ' Me.Close()
        Catch ex As Exception
            MsgBox("Update failed")
        End Try
    End Sub

    Private Sub FrmCountries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsExpensesOptions.expenses_categories' table. You can move, or remove it, as needed.
        Me.Expenses_categoriesTableAdapter.Fill(Me.DsExpensesOptions.expenses_categories)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No
                    Me.Close()
                Case MsgBoxResult.Cancel
                    Return
            End Select
        Else
            Me.Close()
        End If

    End Sub

    Public Sub CenterButtons()
        Me.Panel2.Left = CInt((Me.ClientSize.Width / 2) - (Panel2.Width / 2))
    End Sub

    Private Sub FrmCountries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub





End Class
