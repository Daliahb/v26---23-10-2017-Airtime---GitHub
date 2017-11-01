Public Class Enumerators

    Public Enum EditAdd
        Edit
        Add
    End Enum

    Public Enum UsersTypes
        'Distributer = 1
        Audit = 1
        CardsUser = 2
        Provider = 3
        Admin = 4
        Supervisor = 5
    End Enum

    Public Enum WrongCardTypes
        WrongValue = 1
        WrongScratchNo = 2
        AlreadyUsedCard = 3
    End Enum

    Public Enum historyType
        UsedCard = 1
        SetAsWrongCard = 2
        ReturnAsNewCard = 3
        DeletedCard = 4
        EditedCard = 5
        CorrectedCard = 6
        InsertedCard = 7
        CardSentToEndUser = 8
        CardSetToDevice = 9
    End Enum

    Public Enum EspenseType
        AirtimeCards = 1
        SimCards = 2
        Others = 3
    End Enum

    Public Enum DeviceSlots
        A = 1
        B = 2
        C = 3
        D = 4
    End Enum

    Public Enum HoldOldCut
        Hold = 1
        Old = 2
        Cut = 3
    End Enum

    Public Enum Humanbehaviour
        SendLocalCalls = 1
        SendInternationalCalls = 2
        RecieveLocalCalls = 3
        RecieveInternationalCalls = 4
        None = 5
    End Enum
End Class
