Public Class User

    Private lId As Long
    Private strUserName As String
    Private strPassword As String
    Public IsAccountManager As Boolean
    Private lProvider As Integer
    Private lProviderCountry As Integer
    Public oColRoles As New ColRole
    Public type As New Enumerators.UsersTypes



    Public Property Id() As Long
        Get
            Return lId
        End Get
        Set(ByVal value As Long)
            lId = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return strPassword
        End Get
        Set(ByVal value As String)
            strPassword = value
        End Set
    End Property

    Public Property Provider() As Integer
        Get
            Return lProvider
        End Get
        Set(ByVal value As Integer)
            lProvider = value
        End Set
    End Property

    Public Property ProviderCountry() As Integer
        Get
            Return lProviderCountry
        End Get
        Set(ByVal value As Integer)
            lProviderCountry = value
        End Set
    End Property

    Public Sub setProperties(ByVal dr As DataRow, ByVal dt As DataTable)
        Dim oRol As Role

        Try
            Me.oColRoles.Clear()
            Me.Id = CLng(dr.Item("id"))
            If Not dr.Item("UserName") Is DBNull.Value Then
                Me.UserName = dr.Item("UserName").ToString
            End If
            If Not dr.Item("Password") Is DBNull.Value Then
                Me.Password = dr.Item("Password").ToString
            End If
            If Not dr.Item("fk_Provider") Is DBNull.Value Then
                Me.Provider = CInt(dr.Item("fk_Provider"))
            End If
            If Not dr.Item("type") Is DBNull.Value Then
                Me.type = CType(dr.Item("type"), Enumerators.UsersTypes)
            End If
            If Not dr.Item("fk_country") Is DBNull.Value Then
                Me.ProviderCountry = CInt(dr.Item("fk_country"))
            End If
            'fill roles
            'If dt.Rows.Count > 0 Then
            '    For Each dr2 As DataRow In dt.Rows
            '        If CLng(dr2.Item("fk_User")) = Me.Id Then
            '            oRol = New Role
            '            oRol.ID = CLng(dr2.Item("fk_role"))
            '            Me.oColRoles.Add(oRol)
            '        End If
            '    Next
            'End If
        Catch ex As Exception

        End Try

    End Sub
    '    Public Sub setProperties(ByVal dr As DataRow)
    '        Try
    '            For Each dr In ds.Tables(0).Rows
    '                Me.Id = CLng(dr.Item("id"))
    '                If Not dr.Item("UserName") Is DBNull.Value Then
    '                    Me.UserName = dr.Item("UserName").ToString
    '                End If
    '                If Not dr.Item("Password") Is DBNull.Value Then
    '                    Me.Password = dr.Item("Password").ToString
    '                End If

    '                fill(roles)
    '                If ds.Tables.Count = 2 AndAlso ds.Tables(1).Rows.Count > 0 Then
    '                    For Each dr2 In ds.Tables(1).Rows
    '                        If CLng(dr2.Item("fk_User")) = Me.Id Then
    '                            oRol = New Role
    '                            oRol.ID = CLng(dr2.Item("fk_role"))
    '                            Me.oColRoles.Add(oRol)
    '                        End If
    '                    Next
    '                End If
    '            Next

    '        Catch ex As Exception

    '        End Try
    '    End Sub

End Class

Public Class ColUser
    Inherits CollectionBase

    Public Sub Add(ByVal oUser As User)
        List.Add(oUser)
    End Sub

    Public Sub RemoveUser(ByVal lUserId As Long)
        Dim lIndex As Integer
        For i As Integer = 0 To Me.List.Count
            If List(i).id = lUserId Then
                lIndex = i
                Exit For
            End If
        Next
        Me.RemoveAt(lIndex)
    End Sub

    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oUser As User
        Try
            For Each dr In ds.Tables(0).Rows
                oUser = New User
                oUser.setProperties(dr, ds.Tables(1))
                Me.Add(oUser)
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class