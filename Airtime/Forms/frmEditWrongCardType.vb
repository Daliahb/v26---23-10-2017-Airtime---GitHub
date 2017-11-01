Public Class frmEditWrongCardType

    Public boolSaved As Boolean
    Public oWrongCard As WrongCard
    Public NewWrongType As Enumerators.WrongCardTypes


    Public Sub New(ByRef oWrongCard As WrongCard)
        ' This call is required by the designer.
        InitializeComponent()

        Me.oWrongCard = oWrongCard

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        boolSaved = True

        Me.lblScratchNo.Text = oWrongCard.ScratchNo

        Dim dsCategories As DataSet
        dsCategories = odbaccess.GetCategories(oWrongCard.Country, oWrongCard.OperatorID)
        If Not dsCategories Is Nothing AndAlso Not dsCategories.Tables.Count = 0 AndAlso Not dsCategories.Tables(0).Rows.Count = 0 Then
            Me.cmbCategory.DataSource = dsCategories.Tables(0)
            Me.cmbCategory.ValueMember = "ID"
            Me.cmbCategory.DisplayMember = "Category"
        End If

        Select Case oWrongCard.WrongType
            Case Enumerators.WrongCardTypes.AlreadyUsedCard
                Me.rbAlreadyUsedCard.Checked = True
            Case Enumerators.WrongCardTypes.WrongScratchNo
                Me.rbWrongName.Checked = True
            Case Enumerators.WrongCardTypes.WrongValue
                Me.rbWrongValue.Checked = True
                Me.cmbCategory.Text = oWrongCard.NewCategory.ToString
        End Select
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            '  boolError = odbaccess.EditWrongCard(Me.txtName.Text, lCardID)
            Dim lCategoryID As Integer = 0
            '   Dim enumWrongType As New Enumerators.WrongCardTypes
            Me.oWrongCard.NewCategory = ""
            If Me.rbWrongValue.Checked Then
                Me.oWrongCard.WrongType = Enumerators.WrongCardTypes.WrongValue
                lCategoryID = CInt(Me.cmbCategory.SelectedValue)
                Me.oWrongCard.NewCategory = Me.cmbCategory.Text
            ElseIf rbWrongName.Checked Then
                Me.oWrongCard.WrongType = Enumerators.WrongCardTypes.WrongScratchNo
            ElseIf Me.rbAlreadyUsedCard.Checked Then
                Me.oWrongCard.WrongType = Enumerators.WrongCardTypes.AlreadyUsedCard
            End If

            boolError = odbaccess.EditWrongCardType(Me.oWrongCard.ID, Me.oWrongCard.WrongType, lCategoryID)

            If boolError Then
                MsgBox("Operation done successfully.", , "Airtime System")

                Me.Close()

            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
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

    Private Sub rbWrongName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWrongName.CheckedChanged
        Me.lblNote.Visible = False
        NewWrongType = Enumerators.WrongCardTypes.WrongScratchNo
        If oWrongCard.WrongType = Enumerators.WrongCardTypes.WrongValue Then
            Me.lblNote.Text = "*This card will be considered as not used."
            Me.lblNote.Visible = True
        End If
        Me.Panel3.Enabled = False
    End Sub

    Private Sub rbWrongValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWrongValue.CheckedChanged
        Me.lblNote.Visible = False
        NewWrongType = Enumerators.WrongCardTypes.WrongValue
        If Not NewWrongType = oWrongCard.WrongType Then
            Me.lblNote.Text = "*This card will be considered as used."
            Me.lblNote.Visible = True
        End If
        Me.Panel3.Enabled = True
    End Sub

    Private Sub rbAlreadyUsedCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAlreadyUsedCard.CheckedChanged
        Me.lblNote.Visible = False
        NewWrongType = Enumerators.WrongCardTypes.AlreadyUsedCard
        Me.Panel3.Enabled = False
    End Sub
End Class