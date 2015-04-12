Public Class ClassFormValidation

    'define instance of class
    Dim valid As New ClassValidation
    Dim db As New ClassCustomersDB

    'define module level variable
    Dim maryError As New ArrayList
    Dim mstrErrorMessage = ""

    Public ReadOnly Property IsValid() As Boolean
        'return false if there is at least one error
        Get
            'if error count > 0
            If maryError.Count <> 0 Then
                'return false
                Return False
            End If

            'otherwise return true
            Return True
        End Get
    End Property

    Public ReadOnly Property ErrorMessage()
        'return a paragraph of all error messages, ready to put into label
        Get
            'loop through each error message
            For Each strMessage In maryError
                'add error message to string variable
                mstrErrorMessage = mstrErrorMessage & strMessage & "<br/>"
            Next

            'return string
            Return mstrErrorMessage
        End Get
    End Property

    Public Sub CheckFirstName(strIn As String, strErrorMessage As String)
        'check if strIn is blank
        If strIn = "" Then
            'if blank, add error
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckLastName(strIn As String, strErrorMessage As String)
        'check if strIn is blank
        If strIn = "" Then
            'if blank, add error
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckAddress(strIn As String, strErrorMessage As String)
        'check if strIn is blank
        If strIn = "" Then
            'if blank, add error
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckEmail(strIn As String, strErrorMessage As String)
        'check if email is valid
        If valid.CheckEmail(strIn) = False Then
            'if not add error
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckPhone(strIn As String, strErrorMessage As String)
        'check if phone is valid
        If valid.CheckPhone(strIn) = False Then
            'if not add error
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckZip(strIn As String, strErrorMessage As String)
        'check if zip is valid
        If db.CheckZip(strIn) = False Then
            'if not add error
            maryError.Add(strErrorMessage)
        End If
    End Sub

    Public Sub CheckChangePassword(intID As Integer, strOldPassword As String, strNewPassword As String, strNewPasswordRepeat As String, strWrongOldPassword As String, strBlankPasswordError As String, strWrongNewPassword As String)
        'check if password match what is in the database
        If db.CheckCustomerLoginWithID(intID, strOldPassword) = False Then
            'if not add error
            maryError.Add(strWrongOldPassword)
        End If

        'check if new password and repeat password is not blank, and match
        CheckNewPasswordMatchRepeatPassword(strNewPassword, strNewPasswordRepeat, strBlankPasswordError, strWrongNewPassword)
    End Sub

    Public Sub CheckNewPasswordMatchRepeatPassword(strNewPassword As String, strNewPasswordRepeat As String, strBlankPasswordError As String, strWrongNewPassword As String)
        'check if new password and repeat password is not blank, and match
        If strNewPassword & strNewPasswordRepeat = "" Then
            'add error if blank
            maryError.Add(strBlankPasswordError)
        ElseIf strNewPassword <> strNewPasswordRepeat Then
            'add error if not match
            maryError.Add(strWrongNewPassword)
        End If
    End Sub
End Class
