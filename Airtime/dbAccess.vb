Imports System.Data.OleDb
Imports MySql.Data.MySqlClient.MySqlConnection
Imports MySql.Data.MySqlClient.MySqlException
Imports MySql.Data.MySqlClient.MySqlParameter
Imports MySql.Data


Public Class DBAccess
    Dim oSelectCommand As New MySql.Data.MySqlClient.MySqlCommand
    Dim oParam As New MySql.Data.MySqlClient.MySqlParameter
    Dim oDataAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
    Public oConnection As New MySql.Data.MySqlClient.MySqlConnection
    ' Public oTrans As SqlClient.SqlTransaction
    Public oTrans As MySql.Data.MySqlClient.MySqlTransaction

    Public ds As DataSet
    Public sql As String

    Public Sub New()
        'Real DB
        oConnection.ConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=airtime_user;Password=nahVeifuath8vu5Kai6kei8i;Persist Security Info=True;database=Airtime_system"
        'Test DB
        'oConnection.ConnectionString = "User Id=airtime_dev;database=Airtime_system_dev;Password=ia8fie2Theeshohh3oneihah;Persist Security Info=True;server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337"
    End Sub

    Public Function CreateSlot(lDeviceID As Integer, lOperatorID As Integer, lSlotID As Integer, lShiftID As Integer, intNoOfSims As Integer, strHumanBehaiviour As String, strNote As String, ByRef lDeviceSlotID As Long) As Integer
        Dim intCount As Integer
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CreateSlot"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSlotID"
                .Value = lSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intNoOfSims"
                .Value = intNoOfSims
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strHumanBehaiviour"
                .Value = strHumanBehaiviour
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                intCount = CInt(ds.Tables(0).Rows(0).Item(0))
                If Not ds.Tables.Count = 1 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                    lDeviceSlotID = CLng(ds.Tables(1).Rows(0).Item(0))
                End If
            End If
            If intCount = 4 Then
                Return 2
            ElseIf intCount = -1 Then
                Return intCount
            Else
                Return 1
            End If

            'Return intCount
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return 0
        End Try
    End Function

    Public Function GetNoOfSims(lDeviceSlotID As Long) As Integer
        Dim intCount As Integer
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetNoOfSims"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceSlotID"
                .Value = lDeviceSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            intCount = CInt(oSelectCommand.ExecuteScalar)
            oConnection.Close()

            Return intCount
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return 0
        End Try
    End Function

    Public Function getHoldOldSlots(lDeviceID As Integer, enumHoldOldCut As Enumerators.HoldOldCut, lOperatorID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getHoldOldSlots"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lHoldOldCut"
                .Value = enumHoldOldCut
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function StartSlot(lDeviceSlotID As Long, dStartDate As DateTime, lTrafficeType As Long, strOffer As String, dblMinuteCost As Double) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "StartSlot"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceSlotID"
                .Value = lDeviceSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dStartDate"
                .Value = dStartDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lTrafficeType"
                .Value = lTrafficeType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strOffer"
                .Value = strOffer
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblMinuteCost"
                .Value = dblMinuteCost
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function CutSlot(lDeviceSlotID As Long, dCutTime As DateTime, strNote As String, dblBurnedBalance As Double, dblTalkTime As Double, dblACD As Double, dblASR As Double, intTotalCalls As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "CutSlot"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceSlotID"
                .Value = lDeviceSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dCutTime"
                .Value = dCutTime
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblBurnedBalance"
                .Value = dblBurnedBalance
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTalkTime"
                .Value = dblTalkTime
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblACD"
                .Value = dblACD
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblASR"
                .Value = dblASR
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intTotalCalls"
                .Value = intTotalCalls
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function AddSimsToDeviceSlot(lDeviceSlotID As Long, intNoOfSims As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "AddSimsToDeviceSlot"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceSlotID"
                .Value = lDeviceSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intNoOfSims"
                .Value = intNoOfSims
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetOnHoldDevices_UsedCards() As ColDevice
        ds = New DataSet
        Dim ocolDevice As New ColDevice
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetOnHoldDevices_UsedCards"


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                ocolDevice.FillProperties(ds)
            End If

            Return ocolDevice
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetSlotsReport(oSlotInfoSearch As SlotInfoSearch) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetSlotsReport"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = oSlotInfoSearch.lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "enumHumanBehaviour"
                .Value = oSlotInfoSearch.enumHumanBehaviour
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperator"
                .Value = oSlotInfoSearch.lOperator
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOwner"
                .Value = oSlotInfoSearch.lOwner
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = oSlotInfoSearch.lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSlotID"
                .Value = oSlotInfoSearch.lSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolTraficType"
                .Value = oSlotInfoSearch.boolTraficType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lTrafficType"
                .Value = oSlotInfoSearch.lTrafficType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolTotalSims"
                .Value = oSlotInfoSearch.boolTotalSims
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intTotalSimsFrom"
                .Value = oSlotInfoSearch.intTotalSimsFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intTotalSimsTo"
                .Value = oSlotInfoSearch.intTotalSimsTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolBalance"
                .Value = oSlotInfoSearch.boolBalance
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblBalanceFrom"
                .Value = oSlotInfoSearch.dblBalanceFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblBalanceTo"
                .Value = oSlotInfoSearch.dblBalanceTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDuration"
                .Value = oSlotInfoSearch.boolDuration
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblDurationFrom"
                .Value = oSlotInfoSearch.dblDurationFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblDurationTo"
                .Value = oSlotInfoSearch.dblDurationTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolACD"
                .Value = oSlotInfoSearch.boolACD
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblACDFrom"
                .Value = oSlotInfoSearch.dblACDFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblACDTo"
                .Value = oSlotInfoSearch.dblACDTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolASR"
                .Value = oSlotInfoSearch.boolASR
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblASRFrom"
                .Value = oSlotInfoSearch.dblASRFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblASRTo"
                .Value = oSlotInfoSearch.dblASRTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = oSlotInfoSearch.boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDateFrom"
                .Value = oSlotInfoSearch.dDateFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDateTo"
                .Value = oSlotInfoSearch.dDateTo.AddDays(1)
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDifference"
                .Value = oSlotInfoSearch.boolDifference
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblDifferenceFrom"
                .Value = oSlotInfoSearch.dblDifferenceFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblDifferenceTo"
                .Value = oSlotInfoSearch.dblDifferenceTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCardsResources() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCardsResources"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetLocations() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetLocations"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetSlotDetailsReport(oSlotInfoSearch As SlotInfoSearch) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetSlotDetailsReport"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = oSlotInfoSearch.lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperator"
                .Value = oSlotInfoSearch.lOperator
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = oSlotInfoSearch.lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSlotID"
                .Value = oSlotInfoSearch.lSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = oSlotInfoSearch.boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDateFrom"
                .Value = oSlotInfoSearch.dDateFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDateTo"
                .Value = oSlotInfoSearch.dDateTo.AddDays(1)
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCreatedBy"
                .Value = oSlotInfoSearch.lCreatedBy
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lChargedBy"
                .Value = oSlotInfoSearch.lChargedBy
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    'Public Function GetDevices() As DataSet
    '    ds = New DataSet
    '    Try
    '        'ByVal lLocationID As Integer
    '        oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
    '        oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
    '        oSelectCommand.CommandText = "GetDevices"

    '        'oParam = New MySql.Data.MySqlClient.MySqlParameter
    '        'With oParam
    '        '    .ParameterName = "lLocationID"
    '        '    .Value = lLocationID
    '        'End With
    '        'oSelectCommand.Parameters.Add(oParam)

    '        oDataAdapter.SelectCommand = oSelectCommand
    '        oSelectCommand.Connection = Me.oConnection
    '        oDataAdapter.Fill(ds)
    '        Return ds
    '    Catch ex As Exception
    '        MsgBox(ex.Message & ex.StackTrace)
    '        Return Nothing
    '    End Try
    'End Function


    Public Function GetSimcardsOrders(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lSimCardType As Integer, ByVal boolCheckDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date, ByVal isCheckIsSentToExpenses As Boolean, ByVal isCheckIsSentToExpensesYes As Boolean) As ColSimcardsOrder
        ds = New DataSet
        Dim ocolExpense As New ColSimcardsOrder
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getSimcardsOrders"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardType"
                .Value = lSimCardType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolCheckDate"
                .Value = boolCheckDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "isCheckIsSentToExpenses"
                .Value = isCheckIsSentToExpenses
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "isCheckIsSentToExpensesYes"
                .Value = isCheckIsSentToExpensesYes
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                ocolExpense.SetProperties(ds)
                Return ocolExpense
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetExpenses(ByVal lExpenseCategory As Integer, ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lSimCardType As Integer, ByVal lInsertedByID As Integer, ByVal boolCheckDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date) As ColExpenses
        ds = New DataSet
        Dim ocolExpense As New ColExpenses
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetExpenses"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lExpenseID"
                .Value = 0
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lExpenseCategory"
                .Value = lExpenseCategory
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardType"
                .Value = lSimCardType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lInsertedByID"
                .Value = lInsertedByID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolCheckDate"
                .Value = boolCheckDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)


            'oParam = New MySql.Data.MySqlClient.MySqlParameter
            'With oParam
            '    .ParameterName = "lUserID"
            '    .Value = gUser.Id
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                ocolExpense.SetProperties(ds)
                Return ocolExpense
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetExpense(ByVal lExpenseID As Integer) As Expenses
        ds = New DataSet
        Dim oExpenses As New Expenses
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetExpenses"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lExpenseID"
                .Value = lExpenseID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oExpenses.SetProperties(ds.Tables(0).Rows(0))
                Return oExpenses
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getExpensesCategories(ByVal boolAll As Boolean) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getExpensesCategories"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolAll"
                .Value = boolAll
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUserDeviceConsumption(ByVal lShiftID As Integer, ByVal dDate As Date) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUserDeviceConsumption"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetShiftReport(lCountry As Integer, ByVal lShiftID As Integer, ByVal dDate As Date) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetShiftReport"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountry
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dShiftDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetSimCardsTypes(ByVal lCountryID As Long) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetSimCardTypes"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCardHistory(ByVal lCardNo As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCardHistory"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCardId"
                .Value = lCardNo
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetProviders(ByVal boolCountry As Boolean, ByVal lCountryID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetProviders"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolCountry"
                .Value = boolCountry
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getPayments(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal boolCheckDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getPayments"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolCheckDate"
                .Value = boolCheckDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function insertProvider(ByVal strProviderName As String, ByVal lCountryID As Integer, ByVal strLocationIDs As String, dblWaivedDeductible As Double) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "insertProvider"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strProviderName"
                .Value = strProviderName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strLocationIDs"
                .Value = strLocationIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblWaivedDeductible"
                .Value = dblWaivedDeductible
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditProvider(ByVal lProviderId As Integer, ByVal strProviderName As String, ByVal lCountryID As Integer, ByVal strLocationIDs As String, dblWaivedDeductible As Double) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditProvider"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderId"
                .Value = lProviderId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strProviderName"
                .Value = strProviderName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strLocationIDs"
                .Value = strLocationIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblWaivedDeductible"
                .Value = dblWaivedDeductible
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteProvider(ByVal lProviderId As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteProvider"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderId"
                .Value = lProviderId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetOperators(ByVal boolCountry As Boolean, ByVal lCountryID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetOperators"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolCountry"
                .Value = boolCountry
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function insertOperator(ByVal strOperatorName As String, ByVal lCountryID As Integer, ByVal lLimit As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "insertOperator"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strOperatorName"
                .Value = strOperatorName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLimit"
                .Value = lLimit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditOperator(ByVal lOperatorId As Integer, ByVal strOperatorName As String, ByVal lCountryID As Integer, ByVal lLimit As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditOperator"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorId"
                .Value = lOperatorId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strOperatorName"
                .Value = strOperatorName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLimit"
                .Value = lLimit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteOperator(ByVal lOperatorId As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteOperator"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorId"
                .Value = lOperatorId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function insertSimType(ByVal strSimType As String, ByVal lCountryID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertSimCardType"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strSimType"
                .Value = strSimType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditSimType(ByVal lSimTypeId As Integer, ByVal strSimType As String, ByVal lCountryID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditSimCardType"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimTypeId"
                .Value = lSimTypeId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strSimType"
                .Value = strSimType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteSimCardType(ByVal lSimTypeId As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteSimCardType"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardTypeId"
                .Value = lSimTypeId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetDevices(ByVal lLocationID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetDevices"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLocationID"
                .Value = lLocationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function insertDevice(ByVal strDeviceName As String, ByVal lLocationID As Integer, strPrefix As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "insertDevice"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDeviceName"
                .Value = strDeviceName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLocationID"
                .Value = lLocationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strPrefix"
                .Value = strPrefix
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditDevice(ByVal lDeviceId As Integer, ByVal strDeviceName As String, ByVal lLocationID As Integer, strPrefix As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditDevice"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceId"
                .Value = lDeviceId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDeviceName"
                .Value = strDeviceName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLocationID"
                .Value = lLocationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strPrefix"
                .Value = strPrefix
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteDevice(ByVal lDeviceId As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteDevice"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceId"
                .Value = lDeviceId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetCategories(ByVal lCountryID As Integer, ByVal lOperatorID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCategories"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetAuditShifts() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetAuditShifts"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function EditWrongCard(ByVal strCardNo As String, ByVal lCardID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditWrongCard"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardNo"
                .Value = strCardNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCardID"
                .Value = lCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditWrongValue(ByVal lCardID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditWrongValue"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCardID"
                .Value = lCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetWrongCards(ByVal lWrongType As Integer, ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lReturnedByID As Integer, ByVal lLocationID As Integer, ByVal strCardNo As String, ByVal boolCheckDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date, boolWrongDate As Boolean, WrongDateFrom As Date, WrongDateTo As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetWrongCards"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lWrongType"
                .Value = lWrongType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lReturnedByID"
                .Value = lReturnedByID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLocationID"
                .Value = lLocationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardNo"
                .Value = strCardNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolCheckDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolWrongDate"
                .Value = boolWrongDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dWrongDateFrom"
                .Value = WrongDateFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dWrongDateTo"
                .Value = WrongDateTo
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function insertCategory(ByVal strCategoryName As String, ByVal lCountryID As Integer, ByVal lOperatorID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "insertCategory"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCategory"
                .Value = strCategoryName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditCategory(ByVal lCategoryId As Integer, ByVal strCategoryName As String, ByVal lCountryID As Integer, ByVal lOperatorID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditCategory"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryId"
                .Value = lCategoryId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCategory"
                .Value = strCategoryName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteCategory(ByVal lCategoryId As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteCategory"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryId"
                .Value = lCategoryId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteCard(ByVal strCardIDs As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteCards"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardIDs"
                .Value = strCardIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function ChangeFromWrongCardToUsedCard(ByVal strCardIDs As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "ChangeCardsFromWrongCardToUsedCard"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardIDs"
                .Value = strCardIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function ChangeCardsFromUsedCardToWrongCard(ByVal strCardIDs As String, lWrongCardType As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "ChangeCardsFromUsedCardToWrongCard"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardIDs"
                .Value = strCardIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lWrongCardType"
                .Value = lWrongCardType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetCountriesDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCountriesDS"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function LogOut() As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "LogOut"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            '   MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try
    End Function

    Public Function InsertHistory(ByVal strNote As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertHistory"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function CheckLogin(ByVal strUserName As String, ByVal strPassword As String) As DataSet
        ds = New DataSet
        Try
            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            '(  "set net_write_timeout=99999; set net_read_timeout=99999", oConnection)

            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CheckLogin"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strUserName"
                .Value = strUserName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = strPassword
            End With
            oSelectCommand.Parameters.Add(oParam)

            'oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As MySql.Data.MySqlClient.MySqlException
            If ex.Message.EndsWith("Reading from the stream has failed.") Then
                Return CheckLogin(strUserName, strPassword)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function ChangePassword(ByVal lUserID As Long, ByVal strPassword As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "ChangePassword"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lUserID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = strPassword
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try

    End Function

    Public Function InsertCards(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lGetCardFrom As Integer, ByVal strCards As String, ByVal strLastCard As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertCards"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lGetCardFrom"
                .Value = lGetCardFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCards"
                .Value = strCards
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            If ex.Message = "Fatal error encountered during command execution." Then
                'todo : check if the cards were instered
                If odbaccess.checkCardExists(strLastCard) Then
                    Return True
                Else
                    Return False
                End If
            Else
                MsgBox(ex.Message & ex.StackTrace)
                oConnection.Close()
                Return False
            End If
        End Try
    End Function

    Public Function InsertCards(sql As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.Text
            oSelectCommand.CommandText = sql
            oSelectCommand.Connection = oConnection


            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            'If ex.Message = "Fatal error encountered during command execution." Then
            '    'todo : check if the cards were instered
            '    If odbaccess.checkCardExists(strLastCard) Then
            '        Return True
            '    Else
            '        Return False
            '    End If
            'Else
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
            '  End If
        End Try
    End Function

    Public Function InsertSimCardOrder(ByVal oSimcardOrder As SimcardsOrder) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertSimCardOrder"
            oSelectCommand.Connection = oConnection

            'oParam = New MySql.Data.MySqlClient.MySqlParameter
            'With oParam
            '    .ParameterName = "lSimCardOrderID"
            '    .Value = oSimcardOrder.SimCardOrderID
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = oSimcardOrder.CountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = oSimcardOrder.ProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardType"
                .Value = oSimcardOrder.SimCardTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNoOfCards"
                .Value = oSimcardOrder.NoOfCards
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblCardValue"
                .Value = oSimcardOrder.CardValue
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTotalAmount"
                .Value = oSimcardOrder.TotalAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dSimsOrderDate"
                .Value = oSimcardOrder.SimcardOrderDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditSimCardOrder(ByVal oSimcardOrder As SimcardsOrder) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditSimCardOrder"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardOrderID"
                .Value = oSimcardOrder.SimCardOrderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = oSimcardOrder.CountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = oSimcardOrder.ProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardType"
                .Value = oSimcardOrder.SimCardTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNoOfCards"
                .Value = oSimcardOrder.NoOfCards
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblCardValue"
                .Value = oSimcardOrder.CardValue
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTotalAmount"
                .Value = oSimcardOrder.TotalAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dSimsOrderDate"
                .Value = oSimcardOrder.SimcardOrderDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertExpense(ByVal oExpenses As Expenses) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertExpense"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = oExpenses.CountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = oExpenses.ProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = oExpenses.OperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = oExpenses.CategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "enumExpenseType"
                .Value = oExpenses.enumExpenseType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lExpenseCategory"
                .Value = oExpenses.ExpenseCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardType"
                .Value = oExpenses.SimCardTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardID"
                .Value = 0
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNoOfCards"
                .Value = oExpenses.NoOfCards
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblCardValue"
                .Value = oExpenses.CardValue
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTotalAmount"
                .Value = oExpenses.TotalAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dExpenseDate"
                .Value = oExpenses.ExpenseDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditExpense(ByVal oExpenses As Expenses) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditExpense"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lExpenseID"
                .Value = oExpenses.ExpenseID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = oExpenses.CountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = oExpenses.ProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = oExpenses.OperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = oExpenses.CategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "enumExpenseType"
                .Value = oExpenses.enumExpenseType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lExpenseCategory"
                .Value = oExpenses.ExpenseCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardType"
                .Value = oExpenses.SimCardType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSimCardID"
                .Value = 0
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNoOfCards"
                .Value = oExpenses.NoOfCards
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblCardValue"
                .Value = oExpenses.CardValue
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTotalAmount"
                .Value = oExpenses.TotalAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dExpenseDate"
                .Value = oExpenses.ExpenseDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try
    End Function

    Public Function checkCardExists(ByVal strLastCard As String) As Boolean
        Dim lID As Integer
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "checkCardExists"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strLastCard"
                .Value = strLastCard
            End With
            oSelectCommand.Parameters.Add(oParam)


            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            lID = CInt(oSelectCommand.ExecuteScalar)
            oConnection.Close()

            If lID > 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditCards(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lGetCardFrom As Integer, ByVal strCardIDs As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditCards"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lGetCardFrom"
                .Value = lGetCardFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardIDs"
                .Value = strCardIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetUsers(ByVal lUserType As Integer) As ColUser
        Dim oColUser As New ColUser
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUsers"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserType"
                .Value = lUserType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oColUser.SetProperties(ds)
                Return oColUser
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCardsReport(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCardsReport"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCardsInsertedByProviderReport(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCardsInsertedByProviderReport"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetProvicersBalancesReport(lCountryID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetProvidersBalancesReport"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function InsertPayment(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal dblTotalAmount As Decimal, ByVal dPaymentDate As Date) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertPayment"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTotalAmount"
                .Value = dblTotalAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dPaymentDate"
                .Value = dPaymentDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try
    End Function

    Public Function EditPayment(ByVal lPaymentID As Integer, ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal dblTotalAmount As Decimal, ByVal dPaymentDate As Date) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditPayment"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lPaymentID"
                .Value = lPaymentID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dblTotalAmount"
                .Value = dblTotalAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dPaymentDate"
                .Value = dPaymentDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try
    End Function

    Public Function CheckNotDistributedCardsLimit() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CheckNotDistributedCardsLimit"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetProvidersDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetProvidersDS"


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetDistributedCards(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lSenttoID As Integer, ByVal boolUsedStatus As Boolean, ByVal boolUsed As Boolean, ByVal boolUsedDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date, ByVal strCardNo As String, ByVal boolDistDate As Boolean, ByVal DistFromDate As Date, ByVal DistToDate As Date, ByVal lDeviceID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetDistributedCards"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSenttoID"
                .Value = lSenttoID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolUsedStatus"
                .Value = boolUsedStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolUsed"
                .Value = boolUsed
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolUsedDate"
                .Value = boolUsedDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardNo"
                .Value = strCardNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDistributedDate"
                .Value = boolDistDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "ddFromDate"
                .Value = DistFromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "ddToDate"
                .Value = DistToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetNewCards(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal boolCheckDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date, ByVal strCardNo As String, ByVal lLocationID As Integer, ByVal boolDeviceSet As Boolean, ByVal boolDeviceSetYes As Boolean) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetNewCards"


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLocationID"
                .Value = lLocationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolCheckDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardNo"
                .Value = strCardNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDeviceSet"
                .Value = boolDeviceSet
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDeviceSetYes"
                .Value = boolDeviceSetYes
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetEndUserCardstoDistribute(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lEndUserId As Integer, ByVal lDeviceID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetEndUserCardstoDistribute"


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lEndUserId"
                .Value = lEndUserId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUsersToSendCardsForm(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lDeviceID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUsersToSendCardsForm"


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCorrectedCards(ByVal lCountryID As Integer, ByVal lProviderID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lLocationID As Integer, lDeviceID As Integer, ByVal strCardNo As String, ByVal boolCheckDate As Boolean, ByVal FromDate As Date, ByVal ToDate As Date, ByVal boolDeviceSet As Boolean, ByVal boolDeviceSetYes As Boolean) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCorrectedCards"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = lProviderID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lLocationID"
                .Value = lLocationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardNo"
                .Value = strCardNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolCheckDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = FromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = ToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDeviceSet"
                .Value = boolDeviceSet
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDeviceSetYes"
                .Value = boolDeviceSetYes
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCardsStatus(oCard As Card) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCardsStatus"
            With oCard
                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "lCategoryID"
                    .Value = oCard.lCategoryID
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "lOperatorID"
                    .Value = oCard.lOperatorID
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "lCountryID"
                    .Value = oCard.lCountryID
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "lProviderID"
                    .Value = oCard.lProviderID
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "strCardNo"
                    .Value = oCard.strCardNo
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolDeleted"
                    .Value = oCard.boolDeleted
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolWrongCard"
                    .Value = oCard.boolWrongCard
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolCorrected"
                    .Value = oCard.boolCorrected
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolCheckUsed"
                    .Value = oCard.boolCheckUsed
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolUsed"
                    .Value = oCard.boolUsed
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolCheckDistribute"
                    .Value = oCard.boolCheckDistribute
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolDistribute"
                    .Value = oCard.boolDistribute
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolInsertDate"
                    .Value = oCard.boolInsertDate
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "dInstFromDate"
                    .Value = oCard.dInstFromDate
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "dInstToDate"
                    .Value = oCard.dInstToDate
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "boolUsedDate"
                    .Value = oCard.boolUsedDate
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "dUsedFromDate"
                    .Value = oCard.dUsedFromDate
                End With
                oSelectCommand.Parameters.Add(oParam)

                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "dUsedToDate"
                    .Value = oCard.dUsedToDate
                End With
                oSelectCommand.Parameters.Add(oParam)


                oParam = New MySql.Data.MySqlClient.MySqlParameter
                With oParam
                    .ParameterName = "lUserID"
                    .Value = gUser.Id
                End With
                oSelectCommand.Parameters.Add(oParam)
            End With
            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function ReturnCards(ByVal strCardID As String) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "ReturnCards"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardID"
                .Value = strCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function ReturnCardsFromCardUser() As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "ReturnCardsFromCardUser"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function SendCards(ByVal lSendToID As Integer, ByVal strCardID As String) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SendCards"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lSendToID"
                .Value = lSendToID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardID"
                .Value = strCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function SetCardsDevice(ByVal lDeviceID As Integer, ByVal strCardID As String) As Boolean
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SetCardsDevice"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCardID"
                .Value = strCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try
    End Function

    Public Function UseCard(ByVal lCardID As Integer, ByVal lShiftID As Integer, lCurrentDeviceSlotID As Long) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "UseCard"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCardID"
                .Value = lCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCurrentDeviceSlotID"
                .Value = lCurrentDeviceSlotID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function SetAsWrongCard(ByVal lCardID As Integer, ByVal enumWrongType As Enumerators.WrongCardTypes, ByVal lNewCategoryID As Long) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SetAsWrongCard"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCardID"
                .Value = lCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "enumWrongType"
                .Value = enumWrongType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNewCategoryID"
                .Value = lNewCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditWrongCardType(ByVal lCardID As Long, ByVal enumWrongType As Enumerators.WrongCardTypes, ByVal lNewCategoryID As Long) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditWrongCardType"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCardID"
                .Value = lCardID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "enumWrongType"
                .Value = enumWrongType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNewCategoryID"
                .Value = lNewCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetUsersCards(ByVal lCountryID As Integer, ByVal lOperatorID As Integer, ByVal lCategoryID As Integer, ByVal lDeviceID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUsersCards"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lOperatorID"
                .Value = lOperatorID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCategoryID"
                .Value = lCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lDeviceID"
                .Value = lDeviceID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCardUsersCategories() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCardUsersCategories"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function DeleteUser(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteUser"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertUser(ByVal oUser As User) As Integer
        Dim lid As Integer = 0
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertUser"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strUserName"
                .Value = oUser.UserName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = oUser.Password
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lType"
                .Value = oUser.type
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = oUser.Provider
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            lid = oSelectCommand.ExecuteScalar
            oConnection.Close()

            Return lid
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditUser(ByVal oUser As User) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditUser"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lId"
                .Value = oUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strUserName"
                .Value = oUser.UserName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = oUser.Password
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lType"
                .Value = oUser.type
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lProviderID"
                .Value = oUser.Provider
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function SaveShiftEndUsers(ByVal strUserIDs As String, ByVal dDate As Date, ByVal lShiftLockupID As Integer) As Integer
        Dim lShiftID As Integer
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SaveShiftEndUsers"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strUserIDs"
                .Value = strUserIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftLockupID"
                .Value = lShiftLockupID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            lShiftID = oSelectCommand.ExecuteScalar
            oConnection.Close()

            Return lShiftID
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return -1

        End Try
    End Function

    Public Function SaveShiftUsersOperatorsLimits(ByVal strOperationsLimits As String, ByVal lShiftID As Integer, ByVal lEndUserID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SaveShiftUsersOperatorsLimits"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strOperationsLimits"
                .Value = strOperationsLimits
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lEndUserID"
                .Value = lEndUserID
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function SaveShiftUsersDevices(ByVal strDevicesIDs As String, ByVal lShiftID As Integer, ByVal lEndUserID As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SaveShiftUsersDevices"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDevicesIDs"
                .Value = strDevicesIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lEndUserID"
                .Value = lEndUserID
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetShiftEndusersFull(ByVal dDate As Date, ByVal lShiftID As Integer) As Shift
        ds = New DataSet
        Dim oShift As New Shift
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetShiftEndusersFull"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftLockupID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            oShift.SetProperties(ds)
            Return oShift
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetShiftEndusers_Devices(ByVal dDate As Date, ByVal lShiftID As Integer) As Shift
        ds = New DataSet
        Dim oShift As New Shift
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetShiftEndusers_Devices"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftLockupID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            oShift.SetProperties_Devices(ds)
            Return oShift
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUserShiftOperatorsLimits(ByVal lShiftID As Integer) As ColOperators
        ds = New DataSet
        Dim oColOperators As New ColOperators
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUserShiftOperatorsLimits"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            oColOperators.SetProperties(ds)
            Return oColOperators
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUserShiftAlreadyUsedOperators(ByVal lShiftID As Integer) As ColOperators
        ds = New DataSet
        Dim oColOperators As New ColOperators
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUserShiftAlreadyUsedOperators"

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            oColOperators.SetProperties(ds)
            Return oColOperators
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getShiftID(ByVal dDate As Date, ByVal lShiftLockupId As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "getShiftID"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftLockupId"
                .Value = lShiftLockupId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try

    End Function

    Public Function SaveShiftReport(strData As String, dDate As Date, lShiftID As Integer, lCountry As Integer) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SaveShiftReport"
            oSelectCommand.Connection = oConnection

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strData"
                .Value = strData
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dShiftDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lShiftID"
                .Value = lShiftID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lCountryID"
                .Value = lCountry
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function
End Class
