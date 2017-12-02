Public Class SlotInfoSearch
    Public lCountryID As Integer
    Public enumHumanBehaviour As New Enumerators.Humanbehaviour
    Public lOperator As Integer
    Public lOwner As Integer
    Public lDeviceID As Integer
    Public lSlotID As Integer
    Public boolTraficType As Boolean
    Public lTrafficType As Integer
    Public boolTotalSims As Boolean
    Public intTotalSimsFrom, intTotalSimsTo As Integer
    Public boolBalance As Boolean
    Public dblBalanceFrom, dblBalanceTo As Double
    Public boolDuration As Boolean
    Public dblDurationFrom, dblDurationTo As Double
    Public boolACD As Boolean
    Public dblACDFrom, dblACDTo As Double
    Public boolASR As Boolean
    Public dblASRFrom, dblASRTo As Double
    Public boolDate As Boolean
    Public dDateFrom, dDateTo As Date
    Public boolDifference As Boolean
    Public dblDifferenceFrom, dblDifferenceTo As Double
    Public boolBurnedBalance As Boolean
    Public dblBurnedFrom, dblBurnedTo As Double
    Public lCreatedBy As Integer
    Public lChargedBy As Integer
    Public lShiftID As Integer
End Class
