Public Class Card

    Public lCountryID, lProviderID, lOperatorID, lCategoryID As Integer
    Public boolCheckUsed, boolUsed, boolUsedDate, boolInsertDate As Boolean
    Public boolDeleted, boolCorrected, boolWrongCard, boolCheckDistribute, boolDistribute As Boolean

    Public dUsedFromDate, dUsedToDate, dInstFromDate, dInstToDate As Date
    Public strCardNo As String

End Class
