Public Class ClassFormat
    'Author: Tien Bui
    'Assignment: ASP4
    'Date: 02-26-2015
    'Program Description: Different formating functions

    'define instance of object
    Dim valid As New ClassValidation

    Public Function FormatPhoneNumber(strIn As String) As String
        ' purpose: to return a string in phone number format
        ' inputs: string of 10 phone number digits
        ' outputs: string of formatted phone number
        ' author: Tien Bui
        ' date: 02-06-2015

        'declare variables
        Dim dblPhone As Double
        Dim strResult As String

        'check phone number
        If valid.CheckPhone(strIn) = False Then
            Return ""
        End If

        'convert strIn to double
        dblPhone = Convert.ToDouble(strIn)
        'convert double back to string in phone number format
        strResult = dblPhone.ToString("(###) ###-####")
        'return string
        Return strResult
    End Function

    Public Function FormatCreditCard(strIn As String) As String
        ' purpose: to return a string in phone number format
        ' inputs: string of 10 phone number digits
        ' outputs: string of formatted phone number
        ' author: Tien Bui
        ' date: 02-06-2015

        'declare variables
        Dim strResult As String

        'check credit card
        If valid.CheckCreditCardType(strIn) = "invalid" Then
            'if invalid then return blank
            Return ""
        End If

        'if amex then format for amex
        If valid.CheckCreditCardType(strIn) = "amex" Then
            strResult = "xxxx-xxxxxx-x" & strIn.Substring(strIn.Length - 4, 4)
        Else
            'else format for other cards
            strResult = "xxxx-xxxx-xxxx-" & strIn.Substring(strIn.Length - 4, 4)
        End If

        'return string
        Return strResult
    End Function
End Class
