Public Class ClassValidation
    Implements IValidator
    'Author: Tien Bui
    'Assignment: ASP4
    'Date: 02-26-2015
    'Program Description: Different validation functions

    'constructor
    Sub New(Optional strMessage As String = "error")
        ErrorMessage = strMessage
        IsValid = False
    End Sub

    'properties and functions implement from IValidator
    Public Property ErrorMessage As String Implements IValidator.ErrorMessage
    Public Property IsValid As Boolean Implements IValidator.IsValid
    Public Sub Validate() Implements IValidator.Validate
        'no action required
    End Sub

    Public Sub AddError(message As String)
        ' purpose: create a new error message displayed by ValidationSummary
        ' inputs: string error
        ' outputs: nothing
        ' author: Tien Bui
        ' date: 03-06-2015

        ' add error to page validation
        Dim pgCurrentPage As Page = HttpContext.Current.Handler
        pgCurrentPage.Validators.Add(New ClassValidation(message))
    End Sub

    'Public Function CheckNotBlankUsernamePasswordFields(strUsername As String, strPassword As String) As Boolean
    '    ' purpose: check if customer put in either blank username or blank password
    '    ' inputs: username string and password string
    '    ' outputs: true if both are filled/false if either is blank
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' check if either string is blank
    '    If strUsername = "" Or strPassword = "" Then
    '        ' if either blank, return false
    '        Return False
    '    Else
    '        ' if both not blank return true
    '        Return True
    '    End If
    'End Function

    Public Function CheckAllDigits(strIn As String, Optional intLength As Integer = 0) As Boolean
        ' purpose: check if a string of specific length, and is all numbers
        ' inputs: a string, optional length required
        ' outputs: true if string only contains number and of specific length, false otherwise
        ' author: Tien Bui
        ' date: 02-16-2015

        ' if intLength is 0 or left default, then don't check length of strIn
        ' if intLength > 0, check length
        If intLength > 0 And strIn.Length <> intLength Then
            ' if length not equal, return false
            Return False
        End If

        ' check each character in the string
        For i = 0 To strIn.Length - 1
            ' check if character is in which case below
            Select Case strIn.Substring(i, 1)
                Case "0" To "9"
                    ' character is 0-9: do nothing
                Case Else
                    ' not 0-9: return false
                    Return False
            End Select
        Next

        ' if code gets to this point, length and all digits requirement all met, return true
        Return True

    End Function

    'Public Function CheckAllLetters(strIn As String, Optional intLength As Integer = 0, Optional bolCaseSensitive As Boolean = False) As Boolean
    '    ' purpose: check if a string of specific length, and is all letters
    '    ' inputs: a string, optional length, optional case sensitive
    '    ' outputs: true if string only contains letters and of specific length, false otherwise
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' if intLength is <= 0 or left default, then don't check length of strIn
    '    ' if intLength > 0, check length
    '    If intLength > 0 And strIn.Length <> intLength Then
    '        ' if length not equal, return false
    '        Return False
    '    End If

    '    ' if case sensitive is false or left default, convert strIn to lowercase
    '    If bolCaseSensitive = False Then
    '        strIn = strIn.ToLower
    '    End If

    '    ' check each character in the string
    '    For i = 0 To strIn.Length - 1
    '        ' check if character is in which case below
    '        Select Case strIn.Substring(i, 1)
    '            Case "a" To "z"
    '                ' character is a-z: do nothing
    '            Case Else
    '                ' not a-z: return false
    '                Return False
    '        End Select
    '    Next

    '    ' if code gets to this point, length and all letters requirement all met, return true
    '    Return True

    'End Function

    'Public Function CheckAllLettersOrDigits(strIn As String, Optional intLength As Integer = 0, Optional bolCaseSensitive As Boolean = False) As Boolean
    '    ' purpose: check if a string of specific length, and is all letters and numbers
    '    ' inputs: a string, optional length, optional case sensitive
    '    ' outputs: true if string only contains letters and numbers and of specific length, false otherwise
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' if intLength is <= 0 or left default, then don't check length of strIn
    '    ' if intLength > 0, check length
    '    If intLength > 0 And strIn.Length <> intLength Then
    '        ' if length not equal, return false
    '        Return False
    '    End If

    '    ' if case sensitive is false or left default, convert strIn to lowercase
    '    If bolCaseSensitive = False Then
    '        strIn = strIn.ToLower
    '    End If

    '    ' check each character in the string
    '    For i = 0 To strIn.Length - 1
    '        ' check if character is in which case below
    '        Select Case strIn.Substring(i, 1)
    '            Case "a" To "z"
    '                ' character is a-z: do nothing
    '            Case "0" To "9"
    '                ' character is 0-9: do nothing
    '            Case Else
    '                ' not a-z or 0-9: return false
    '                Return False
    '        End Select
    '    Next

    '    ' if code gets to this point, length and all letters requirement all met, return true
    '    Return True

    'End Function

    'Public Function CheckPhone(strIn As String) As Boolean
    '    ' purpose: check if a string is 10 character long, and contains only digits
    '    ' inputs: a string, 
    '    ' outputs: true if 10 digits
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' call CheckAllDigits with length=10
    '    If CheckAllDigits(strIn, 10) = False Then
    '        'if test failed, return false
    '        Return False
    '    End If

    '    'if nothing failed, return true
    '    Return True
    'End Function

    'Public Function CheckState(strIn As String) As Boolean
    '    ' purpose: check if a string is 2 character long, and contains only letters
    '    ' inputs: a string, 
    '    ' outputs: true if 2 letters
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' call CheckAllLetters with length=2, case sensitivity default = false
    '    If CheckAllLetters(strIn, 2) = False Then
    '        'if test failed, return false
    '        Return False
    '    End If

    '    'if nothing failed, return true
    '    Return True
    'End Function

    'Public Function CheckInitial(strIn As String) As Boolean
    '    ' purpose: check if a string is 1 character long, and contains only letters
    '    ' inputs: a string, 
    '    ' outputs: true if 1 letters
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' call CheckAllLetters with length=1, case sensitivity default = false
    '    If CheckAllLetters(strIn, 1) = False Then
    '        'if test failed, return false
    '        Return False
    '    End If

    '    'if nothing failed, return true
    '    Return True
    'End Function

    'Public Function CheckZip(strIn As String) As Boolean
    '    ' purpose: check if a string is 5 or 9 character long, and contains only digits
    '    ' inputs: a string, 
    '    ' outputs: true if 5 or 9 digits
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' check for length
    '    If strIn.Length <> 5 And strIn.Length <> 9 Then
    '        'if not 5 or 9 characters, return false
    '        Return False
    '    End If

    '    ' call CheckAllDigits without length check
    '    If CheckAllDigits(strIn) = False Then
    '        'if test failed, return false
    '        Return False
    '    End If

    '    'if nothing failed, return true
    '    Return True
    'End Function

    'Public Function CheckPassword(strIn As String) As Boolean
    '    ' purpose: check if a string contains only letters and numbers, of length 6-10, and begins with letter, has at least 1 number
    '    ' inputs: a string, 
    '    ' outputs: true if 6-10 letters and numbers, and begin with letter, have at least 1 number
    '    ' author: Tien Bui
    '    ' date: 02-16-2015

    '    ' check length
    '    If strIn.Length < 6 Or strIn.Length > 10 Then
    '        'if not between 6 and 10, return false
    '        Return False
    '    End If

    '    ' check first character
    '    If CheckAllLetters(strIn.Substring(0, 1)) = False Then
    '        'if not letter, return false
    '        Return False
    '    End If

    '    ' declare counter variable
    '    Dim intCount As Integer = 0
    '    ' check the rest of the string
    '    For i = 1 To strIn.Length - 1
    '        ' check if character is in which case below
    '        Select Case strIn.Substring(i, 1)
    '            Case "a" To "z"
    '                ' character is a-z: do nothing
    '            Case "0" To "9"
    '                ' character is 0-9: increase count
    '                intCount = intCount + 1
    '            Case Else
    '                ' not a-z or 0-9: return false
    '                Return False
    '        End Select
    '    Next

    '    ' if count of digits <1, return false
    '    If intCount < 1 Then
    '        Return False
    '    End If

    '    ' if nothing failed, return true
    '    Return True
    'End Function
End Class
