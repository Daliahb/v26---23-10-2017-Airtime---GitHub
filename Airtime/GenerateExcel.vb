Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class GenerateExcel

    Public dInsertDate As Date
    Dim excel As Application = New Application
    Dim worksheet As Worksheet
    Dim oWorkBook As Workbook
    Dim RootDirectory As String

    '--- PDF Parameters---
    Dim PDFFile As String = "C:\Users\dalia\Desktop\invoices\Test.pdf"
    Dim pFormatType As XlFixedFormatType = XlFixedFormatType.xlTypePDF
    Dim pQuality As XlFixedFormatQuality = XlFixedFormatQuality.xlQualityMinimum
    Dim pIncludeDocProperties As Boolean = True
    Dim pIgnorePrintAreas As Boolean = True
    Dim pFrom As Object = Type.Missing
    Dim pTo As Object = Type.Missing
    Dim pOpenAfterPublish As Boolean = True
    Public boolEqual, isLoaded As Boolean

    Public Sub New()
        If My.Settings.RootDirectory.Length = 0 Then
            If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                Dim folderDlg As New FolderBrowserDialog
                folderDlg.SelectedPath = My.Settings.RootDirectory
                folderDlg.ShowNewFolderButton = True
                folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                If (folderDlg.ShowDialog() = DialogResult.OK) Then

                    '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                    My.Settings.RootDirectory = folderDlg.SelectedPath
                End If
            Else
                Return
            End If

        End If
        'create a folder with today's date
        RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
        If (Not System.IO.Directory.Exists(RootDirectory)) Then
            System.IO.Directory.CreateDirectory(RootDirectory)
        End If
    End Sub

    Public Sub GenerateExcelFile(ByVal ds As DataSet, strShift As String, strCountry As String)
        Try
            excel.Visible = True
            Dim i As Integer
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\ShiftReport.xlsx"
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
            worksheet = excel.Worksheets(1)
            'Dim strShift, strCountry As String
            Dim strProvider As String = ""
            Dim row As Integer = 6


            Me.worksheet.Range("a" & 1).Value = "Shift Report - " & Now().ToString("dd-MM-yyyy") & " - Shift " & strShift & " - " & strCountry

            For Each dr As DataRow In ds.Tables(0).Rows
                Try
                    With dr
                        If strProvider <> dr.Item("Provider").ToString Then
                            ' new Provider
                            '1- copy first row to add provider
                            ' - copy second row for columns details
                            ' - copy data row to start with it
                            '2- fill data
                            boolEqual = True
                            strProvider = dr.Item("Provider").ToString

                            '1-
                            ' Me.worksheet.Range("a2:j4").Select()
                            row += 1
                            Me.worksheet.Range("a3:j6").Copy(Me.worksheet.Range("a" & row))

                            'fill provider text 
                            Me.worksheet.Range("a" & row).Value = .Item("Provider")
                            row += 2


                        Else
                            Me.worksheet.Range("a" & row & ":j" & row).Copy(Me.worksheet.Range("a" & row + 1))
                            row += 1
                        End If

                        Me.worksheet.Range("a" & row).Value = .Item("Operator")
                        Me.worksheet.Range("b" & row).Value = .Item("ShiftStartStatus")
                        Me.worksheet.Range("c" & row).Value = .Item("ShiftInsertedCards")
                        Me.worksheet.Range("d" & row).Value = .Item("ShiftUsedCards")
                        Me.worksheet.Range("e" & row).Value = CDbl(dr.Item("ShiftStartStatus")) + CDbl(dr.Item("ShiftInsertedCards")) - CDbl(dr.Item("ShiftUsedCards")) ' total
                        Me.worksheet.Range("f" & row).Value = .Item("ShiftRemainingCards")
                        Me.worksheet.Range("g" & row).Value = .Item("ShiftWrongCards")
                        Me.worksheet.Range("h" & row).Value = .Item("SimsInSite")
                        Me.worksheet.Range("i" & row).Value = .Item("AirtimeCardsInSite")
                        Me.worksheet.Range("j" & row).Value = .Item("ProviderBalance")

                    End With

                Catch ex As Exception

                End Try

            Next

            Me.worksheet.Range("a3:j6").Delete()

            ' ---- Generate PDF File ------

            Dim strName As String
            strName = "Shift Report - " & Now().ToString("dd-MM-yyyy") & " - Shift " & strShift & " - " & strCountry & ".pdf"
            If My.Settings.RootDirectory.Length = 0 Then
                If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim folderDlg As New FolderBrowserDialog
                    folderDlg.SelectedPath = My.Settings.RootDirectory
                    folderDlg.ShowNewFolderButton = True
                    folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                    If (folderDlg.ShowDialog() = DialogResult.OK) Then

                        '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                        My.Settings.RootDirectory = folderDlg.SelectedPath
                    End If
                Else
                    Return
                End If

            End If
            ' worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)

            ' Dim PDFFile As String = System.Windows.Forms.Application.StartupPath & "\Shift Report - " & Now().ToString("dd-MM-yyyy") & " - Shift " & strShift & " - " & strCountry & ".pdf"
            'Me.worksheet.PageSetup.FitToPagesWide = 1
            ' Me.worksheet.PageSetup.FitToPagesTall = 1
            '   Me.worksheet.PageSetup.Zoom = False
            Dim PDFFile As String = RootDirectory & "\" & strName
            oWorkBook = excel.Workbooks(1)
            If Not oWorkBook Is Nothing Then
                oWorkBook.ExportAsFixedFormat(pFormatType, PDFFile, pQuality, _
                                              pIncludeDocProperties, _
                                              pIgnorePrintAreas, _
                                              pFrom, pTo, pOpenAfterPublish)
            End If
            oWorkBook.Close(False)
            excel.Workbooks.Close()
            excel.Quit()

            'Client&Company info
            'Me.worksheet.Range("b" & 2).Value = .Item("CompanyName")
            'If Not .Item("CompanyAddress") Is DBNull.Value Then
            '    Me.worksheet.Range("b" & 4).Value = .Item("CompanyAddress")
            'End If

            'Me.worksheet.Range("b" & 7).Value = "Invoice To: " + .Item("ClientName").ToString
            'If Not .Item("ClientAddress") Is DBNull.Value Then
            '    Me.worksheet.Range("b" & 8).Value = .Item("ClientAddress")
            'End If
            'If Not .Item("InvoiceNo") Is DBNull.Value Then
            '    Me.worksheet.Range("d" & 7).Value = .Item("InvoiceNo")
            'End If

            'Me.worksheet.Range("d" & 8).Value = dInsertDate
            'Me.worksheet.Range("d" & 9).Value = dInsertDate.AddDays(CLng(.Item("Statement")))
            'Me.worksheet.Range("d" & 10).Value = .Item("TimeZone")
            'Me.worksheet.Range("d" & 11).Value = .Item("PaymentTerms")
            'Me.worksheet.Range("b" & 10).Value = "Billing Period: " + CDate(.Item("Billing_Period_From")).ToString("dd/MM/yyyy") + " - " + CDate(.Item("Billing_Period_to")).ToString("dd/MM/yyyy")
            'Me.worksheet.Range("b" & 11).Value = "Time: " + CDate(.Item("Billing_Period_From")).ToString("dd/MM/yyyy") + " 00:00:00 TO " + CDate(.Item("Billing_Period_to")).ToString("dd/MM/yyyy") + "  23:59:59"

            ''Bank account info
            'If Not .Item("Account_Name") Is DBNull.Value Then
            '    Me.worksheet.Range("c" & 41).Value = .Item("Account_Name")
            'End If
            'If Not .Item("Account_Number") Is DBNull.Value Then
            '    Me.worksheet.Range("c" & 42).Value = .Item("Account_Number")
            'End If
            'If Not .Item("IBAN") Is DBNull.Value Then
            '    Me.worksheet.Range("c" & 43).Value = .Item("IBAN")
            'End If
            'If Not .Item("Beneficiary_Bank_Name") Is DBNull.Value Then
            '    Me.worksheet.Range("c" & 44).Value = .Item("Beneficiary_Bank_Name")
            'End If
            'If Not .Item("Beneficiary_Bank_Address") Is DBNull.Value Then
            '    Me.worksheet.Range("c" & 45).Value = .Item("Beneficiary_Bank_Address")
            'End If
            'If Not .Item("SWIFT") Is DBNull.Value Then
            '    Me.worksheet.Range("c" & 46).Value = .Item("SWIFT")
            'End If

            'If Not .Item("LogoName") Is DBNull.Value AndAlso Not .Item("LogoName").ToString.Length = 0 Then
            '    LogoPath = System.Windows.Forms.Application.StartupPath & "\" & .Item("LogoName").ToString
            'Else
            '    LogoPath = ""
            'End If


            'If ds.Tables(1).Rows.Count > 21 Then
            '    Dim x As Integer
            '    x = ds.Tables(1).Rows.Count - 20
            '    For i = 1 To x
            '        worksheet.Rows(16).Insert()
            '    Next

            'End If
            ''Details info
            'i = 15
            'For Each dr As DataRow In ds.Tables(1).Rows

            '    Me.worksheet.Range("B" & i).Value = dr.Item("Area_Name")
            '    '  Me.worksheet.Range("c" & i).Value = dr.Item("Area_Code")
            '    Me.worksheet.Range("C" & i).Value = dr.Item("Total_Duration")
            '    Me.worksheet.Range("D" & i).Value = Math.Round(dr.Item("Total_Charges"), 3)
            '    i += 1
            'Next


            'strName = "Invoice-" + .Item("CompanyCode").ToString + "-" + dInsertDate.ToString("ddMMyyyy")
            '' strName = strName + Now.ToString("mmff")
            'End With
            ''worksheet.Unprotect("111111")


            'worksheet.Protect("111111", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True)
            ''
            'worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)



            '' ---- Generate PDF File ------

            'Dim PDFFile As String = RootDirectory & "\" & strName & ".pdf"
            'Me.worksheet.PageSetup.FitToPagesWide = 1
            'Me.worksheet.PageSetup.FitToPagesTall = 1
            'Me.worksheet.PageSetup.Zoom = False
            'oWorkBook = excel.Workbooks(1)
            'If Not oWorkBook Is Nothing Then
            '    oWorkBook.ExportAsFixedFormat(pFormatType, PDFFile, pQuality, _
            '                                  pIncludeDocProperties, _
            '                                  pIgnorePrintAreas, _
            '                                  pFrom, pTo, pOpenAfterPublish)
            'End If
            'excel.Workbooks.Close()
            'excel.Quit()

        Catch ex As Exception
            'excel.Workbooks.Close()
            'excel.Quit()
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
