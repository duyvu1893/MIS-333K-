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

        'if strIn is not 10 digits, which in this database is only Null, return blank
        If valid.CheckAllDigits(strIn, 10) = False Then
            Return ""
        End If

        'convert strIn to double
        dblPhone = Convert.ToDouble(strIn)
        'convert double back to string in phone number format
        strResult = dblPhone.ToString("(###) ###-####")
        'return string
        Return strResult
    End Function
End Class
