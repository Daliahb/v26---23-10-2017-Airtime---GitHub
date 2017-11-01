Public Class frmHoldOldSlots

    Dim enumHoldOldCut As Enumerators.HoldOldCut
    Dim lDeviceID, lOperatorID As Integer
    Public lDeviceSlotID As Integer = -1
    Public strSlot As String = ""

#Region "Controls Events"

    Public Sub New(enumHoldOldCut As Enumerators.HoldOldCut, lDeviceID As Integer, lOperatorID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumHoldOldCut = enumHoldOldCut
        Me.lDeviceID = lDeviceID
        Me.lOperatorID = lOperatorID
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lLocationID As Integer = 0
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            If enumHoldOldCut = Enumerators.HoldOldCut.Old Then
                Me.Text = "Old Slots"
                Me.DataGridView1.Columns(8).Visible = True
            End If
            ds = odbaccess.getHoldOldSlots(lDeviceID, Me.enumHoldOldCut, lOperatorID)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = dr.Item("Device")
                            .Cells(3).Value = dr.Item("Operator")
                            .Cells(4).Value = dr.Item("Slot")
                            .Cells(5).Value = dr.Item("NoofSims")
                            .Cells(6).Value = CDate(dr.Item("Created_Time")).ToString("yyyy-MM-dd HH:mmm")
                            .Cells(7).Value = dr.Item("CreatedBy")
                            If Not dr.Item("Start_Time") Is DBNull.Value Then
                                .Cells(8).Value = CDate(dr.Item("Start_Time")).ToString("yyyy-MM-dd HH:mmm")
                            End If

                            .Cells(9).Value = "Select"
                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(1).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.strSlot = "None"
        Me.lDeviceSlotID = 0
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            'TODO - Button Clicked - Execute Code Here
            Me.lDeviceSlotID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            strSlot = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value)
            Me.Close()
        End If
    End Sub

End Class
