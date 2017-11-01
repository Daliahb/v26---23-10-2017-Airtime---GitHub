Public Class FrmCountries
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Validate()
            Me.DataGridView1.EndEdit()
            Me.CountriesTableAdapter.Update(Me.DsCountries.countries)

            odbaccess.InsertHistory("Managed Countries")
            MsgBox("Data saved successfully")
            ' Me.Close()
        Catch ex As Exception
            MsgBox("Update failed")
        End Try
    End Sub

    Private Sub FrmCountries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCountries.countries' table. You can move, or remove it, as needed.
        Me.CountriesTableAdapter.Fill(Me.DsCountries.countries)
        'TODO: This line of code loads data into the 'DsCountries.countries' table. You can move, or remove it, as needed.
        ' Me.CountriesTableAdapter.Fill(Me.DsCountries.countries)


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Select Case MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                btnSave_Click(Me, New System.EventArgs)
            Case MsgBoxResult.No
                Me.Close()
            Case MsgBoxResult.Cancel
                Return
        End Select
    End Sub

    Public Sub CenterButtons()
        Me.Panel2.Left = CInt((Me.ClientSize.Width / 2) - (Panel2.Width / 2))
    End Sub

    Private Sub FrmCountries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub





End Class
