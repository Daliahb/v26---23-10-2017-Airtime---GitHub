Imports Microsoft.Office.Interop
Imports System.Text

Module Module1

    Public odbaccess As New DBAccess
    Public gUser As New User
    Public gConnectionString As String

    Sub New()
        'Real DB
        gConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=airtime_user;Password=nahVeifuath8vu5Kai6kei8i;Persist Security Info=True;database=Airtime_system"
        'Test DB
        'gConnectionString = "User Id=airtime_dev;database=Airtime_system_dev;Password=ia8fie2Theeshohh3oneihah;Persist Security Info=True;server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337"

    End Sub

    Public Sub ExportToExcel(ByVal DataGridView1 As DataGridView)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer


        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        Dim x As Integer = 0
        'insert header
        For i = 0 To DataGridView1.Columns.Count - 1
            If DataGridView1.Columns(i).Visible Then
                xlWorkSheet.Cells(1, x + 1) = DataGridView1.Columns(i).HeaderText
                x += 1
            End If
        Next


        For i = 0 To DataGridView1.Rows.Count - 1
            x = 0
            For j = 0 To DataGridView1.ColumnCount - 1
                If DataGridView1.Columns(j).Visible Then
                    If Not DataGridView1(j, DataGridView1.Rows(i).Index).Value Is Nothing Then
                        xlWorkSheet.Cells(i + 2, x + 1) = _
                                               DataGridView1(j, DataGridView1.Rows(i).Index).Value.ToString()
                    Else
                        xlWorkSheet.Cells(i + 2, x + 1) = ""
                    End If

                    x += 1
                End If
            Next

        Next
        xlWorkSheet.Columns.AutoFit()
        xlApp.Visible = True
    End Sub

    Public Sub AutoCompleteCombo_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String

        'Allow select keys without Autocompleting
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down
                Return
        End Select

        'Get the Typed Text and Find it in the list
        sTypedText = cbo.Text
        iFoundIndex = cbo.FindString(sTypedText)

        'If we found the Typed Text in the list then Autocomplete
        If iFoundIndex >= 0 Then

            'Get the Item from the list (Return Type depends if Datasource was bound 
            ' or List Created)
            oFoundItem = cbo.Items(iFoundIndex)

            'Use the ListControl.GetItemText to resolve the Name in case the Combo 
            ' was Data bound
            sFoundText = cbo.GetItemText(oFoundItem)

            'Append then found text to the typed text to preserve case
            sAppendText = sFoundText.Substring(sTypedText.Length)
            cbo.Text = sTypedText & sAppendText

            'Select the Appended Text
            cbo.SelectionStart = sTypedText.Length
            cbo.SelectionLength = sAppendText.Length

        End If

    End Sub

    Public Sub AutoCompleteCombo_Leave(ByVal cbo As ComboBox)
        Dim iFoundIndex As Integer

        iFoundIndex = cbo.FindStringExact(cbo.Text)

        cbo.SelectedIndex = iFoundIndex

    End Sub

    Public Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure

    Public maxPagesWide As Integer
    Public maxPagesTall As Integer
    ''' dictionary to hold printed page details, with index key
    Public pages As Dictionary(Of Integer, pageDetails)

    'Public Class DataGridViewDisableButtonColumn
    '    Inherits DataGridViewButtonColumn

    '    Public Sub New()
    '        Me.CellTemplate = New DataGridViewDisableButtonCell()
    '    End Sub
    'End Class

    'Public Class DataGridViewDisableButtonCell
    '    Inherits DataGridViewButtonCell

    '    Private enabledValue As Boolean
    '    Public Property Enabled() As Boolean
    '        Get
    '            Return enabledValue
    '        End Get
    '        Set(ByVal value As Boolean)
    '            enabledValue = value
    '        End Set
    '    End Property

    '    ' Override the Clone method so that the Enabled property is copied. 
    '    Public Overrides Function Clone() As Object
    '        Dim Cell As DataGridViewDisableButtonCell = _
    '            CType(MyBase.Clone(), DataGridViewDisableButtonCell)
    '        Cell.Enabled = Me.Enabled
    '        Return Cell
    '    End Function

    '    ' By default, enable the button cell. 
    '    Public Sub New()
    '        Me.enabledValue = True
    '    End Sub

    '    Protected Overrides Sub Paint(ByVal graphics As Graphics, _
    '   ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, _
    '   ByVal rowIndex As Integer, _
    '   ByVal elementState As DataGridViewElementStates, _
    '   ByVal value As Object, ByVal formattedValue As Object, _
    '   ByVal errorText As String, _
    '   ByVal cellStyle As DataGridViewCellStyle, _
    '   ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
    '   ByVal paintParts As DataGridViewPaintParts)

    '        ' The button cell is disabled, so paint the border,   
    '        ' background, and disabled button for the cell. 
    '        If Not Me.enabledValue Then

    '            ' Draw the background of the cell, if specified. 
    '            If (paintParts And DataGridViewPaintParts.Background) = _
    '                DataGridViewPaintParts.Background Then

    '                Dim cellBackground As New SolidBrush(cellStyle.BackColor)
    '                graphics.FillRectangle(cellBackground, cellBounds)
    '                cellBackground.Dispose()
    '            End If

    '            ' Draw the cell borders, if specified. 
    '            If (paintParts And DataGridViewPaintParts.Border) = _
    '                DataGridViewPaintParts.Border Then

    '                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, _
    '                    advancedBorderStyle)
    '            End If

    '            ' Calculate the area in which to draw the button. 
    '            Dim buttonArea As Rectangle = cellBounds
    '            Dim buttonAdjustment As Rectangle = _
    '                Me.BorderWidths(advancedBorderStyle)
    '            buttonArea.X += buttonAdjustment.X
    '            buttonArea.Y += buttonAdjustment.Y
    '            buttonArea.Height -= buttonAdjustment.Height
    '            buttonArea.Width -= buttonAdjustment.Width

    '            ' Draw the disabled button.                
    '            ButtonRenderer.DrawButton(graphics, buttonArea, _
    '                PushButtonState.Disabled)

    '            ' Draw the disabled button text.  
    '            If TypeOf Me.FormattedValue Is String Then
    '                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue), _
    '                    Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
    '            End If

    '        Else
    '            ' The button cell is enabled, so let the base class  
    '            ' handle the painting. 
    '            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, _
    '                elementState, value, formattedValue, errorText, _
    '                cellStyle, advancedBorderStyle, paintParts)
    '        End If
    '    End Sub
    'End Class
End Module
