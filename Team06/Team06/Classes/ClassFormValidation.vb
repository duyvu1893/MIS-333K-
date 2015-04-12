Public Class ClassFormValidation

    'define instance of class
    Dim valid As New ClassValidation
    Dim db As New ClassCustomersDB

    'define module level variable
    Dim maryError As New ArrayList
    Dim mstrErrorMessage As String = ""

    Public ReadOnly Property IsValid() As Boolean
        Get
            If maryError.Count <> 0 Then
                Return False
            End If
            Return True
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            For Each strMessage As String In maryError
                mstrErrorMessage = mstrErrorMessage & strMessage & "<br/>"
            Next
            Return mstrErrorMessage
        End Get
    End Property

    Public Sub CheckEmail(strIn As String, strErrorMessage As String)
        If valid.CheckEmail(strIn) = False Then
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckPhone(strIn As String, strErrorMessage As String)
        If valid.CheckPhone(strIn) = False Then
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckZip(strIn As String, strErrorMessage As String)
        If db.CheckZip(strIn) = False Then
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckChangePassword(intID As Integer, strOldPassword As String, strNewPassword As String, strNewPasswordRepeat As String, strWrongOldPassword As String, strBlankPasswordError As String, strWrongNewPassword As String)
        If db.CheckCustomerLoginWithID(intID, strOldPassword) = False Then
            maryError.Add(strWrongOldPassword)
        End If

        If strNewPassword & strNewPasswordRepeat = "" Then
            maryError.Add(strBlankPasswordError)
        ElseIf strNewPassword <> strNewPasswordRepeat Then
            maryError.Add(strWrongNewPassword)
        End If
    End Sub
End Class
