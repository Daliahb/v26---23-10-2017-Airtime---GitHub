Public Class frmCardsLessThanOperatorLimit
#Region "Controls Events"

    Dim ds As DataSet
    Public Sub New(Optional ByVal dsData As DataSet = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not ds Is Nothing Then
            ds = ds
        Else
            ds = New DataSet
            ds = odbaccess.CheckNotDistributedCardsLimit()
        End If
    End Sub


    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnSearch_Click(Me, New System.EventArgs)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lCountryID As Long = 0

        Try
            Me.DataGridView1.Rows.Clear()

            '   ds = odbaccess.CheckNotDistributedCardsLimit()
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Me.DataGridView1.Location = New Point(4, 68)
                Me.DataGridView1.Size = New Size(490, 164)
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("Country")
                            .Cells(1).Value = dr.Item("Operator")
                            .Cells(2).Value = dr.Item("Limit")
                            .Cells(3).Value = dr.Item("Count")
                            .Cells(3).Style.ForeColor = Color.DarkRed

                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            Else  'no data
                Me.DataGridView1.Location = New Point(4, 10)
                Me.DataGridView1.Size = New Size(490, 222)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

End Class
