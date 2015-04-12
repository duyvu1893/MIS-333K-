Imports System.Data
Imports System.Data.SqlClient

Public Class ClassEmployeeDB
    'Author: Tien Bui
    'Assignment: ASP5
    'Date: 03-03-2015
    'Program Description: Access and display data in database


    ' these module variables are internal to object
    Dim mDatasetEmployee As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_team06;user id=msbcr885;password=MISsqlpas789"

    ' define instance of class
    Dim valid As New ClassValidation

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property EmpDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetEmployee
        End Get
    End Property

    ' define a public sub that will handle running any select query
    ' in class I had this as private, but said you might want to make it public, so you 
    ' could just send it any query and have it run it.  This avoids having more subs for 
    ' each type of query you want to run.

    'Public Sub SelectQuery(ByVal strQuery As String)

    '    ' purpose: run any select query and fill dataset

    '    Try
    '        ' define data connection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

    '        ' open the connection and dataset 
    '        mdbConn.Open()

    '        ' clear the dataset before filling
    '        mDatasetEmployee.Clear()

    '        ' fill the dataset
    '        mdbDataAdapter.Fill(mDatasetEmployee, "tblEmployee")

    '        ' close the connection
    '        mdbConn.Close()
    '    Catch ex As Exception
    '        Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
    '    End Try

    'End Sub

    'Public Sub UpdateDB(ByVal strQuery As String)
    '    ' purpose: update database
    '    ' inputs: EmpID string
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-12-2015

    '    Try
    '        ' define data connection and data command
    '        mdbConn = New SqlConnection(mstrConnection)
    '        Dim dbCommand As New SqlCommand(strQuery, mdbConn)

    '        ' open the connection
    '        mdbConn.Open()

    '        ' run the query
    '        dbCommand.ExecuteNonQuery()

    '        ' close the connection
    '        mdbConn.Close()
    '    Catch ex As Exception
    '        Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
    '    End Try

    'End Sub

    'Public Sub GetAllEmployee()
    '    ' purpose: to return all Employee records
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the dataset
    '    '          with all the records in tblEmployee

    '    ' to Get all Employee use Select
    '    mstrQuery = "select * from tblEmployee order by lastname, firstname"
    '    ' run the query
    '    SelectQuery(mstrQuery)
    'End Sub

    'Public Sub GetEmployeeWithID(strIn As String)
    '    ' purpose: get records of one EmpID
    '    ' inputs: EmpID string
    '    ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblEmployee
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' to get one Employee using select
    '    mstrQuery = "select * from tblEmployee where EmpID='" & strIn & "'"
    '    ' run the query
    '    SelectQuery(mstrQuery)
    'End Sub

    Public Sub RunProcedure(ByVal strName As String)
        ' CREATES INSTANCES OF THE CONNECTION AND COMMAND OBJECT
        Dim objConnection As New SqlConnection(mstrConnection)
        ' Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strName, objConnection)
        Try
            ' SETS THE COMMAND TYPE TO "STORED PROCEDURE"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            ' clear dataset
            Me.mDatasetEmployee.Clear()
            ' OPEN CONNECTION AND FILL DATASET
            mdbDataAdapter.Fill(mDatasetEmployee, "tblEmployee")
            ' copy dataset to dataview
            mMyView.Table = mDatasetEmployee.Tables("tblEmployee")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try
    End Sub


    Public Sub RunSPwithOneParam(ByVal strSPName As String, ByVal strParamName As String, ByVal strParamValue As String)
        ' purpose to run a stored procedure with one parameter
        ' inputs:  stored procedure name, parameter name, parameter value
        ' returns: dataset filled with correct records

        ' CREATES INSTANCES OF THE CONNECTION AND COMMAND OBJECT
        Dim objConnection As New SqlConnection(mstrConnection)
        ' Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strSPName, objConnection)
        Try
            ' SETS THE COMMAND TYPE TO "STORED PROCEDURE"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ' ADD PARAMETER(S) TO SPROC
            mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(strParamName, strParamValue))
            ' clear dataset
            Me.mDatasetEmployee.Clear()

            ' OPEN CONNECTION AND FILL DATASET
            mdbDataAdapter.Fill(mDatasetEmployee, "tblEmployee")

            ' copy dataset to dataview
            mMyView.Table = mDatasetEmployee.Tables("tblEmployee")

        Catch ex As Exception
            Throw New Exception("params are " & strSPName.ToString & " " & strParamName.ToString & " " & strParamValue.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetEmployeeWithID(strIn As String)
        ' purpose: get records of one EmpID
        ' inputs: EmpID string
        ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblEmployee
        ' author: Tien Bui
        ' date: 02-06-2015

        ' check integer
        If valid.CheckAllDigits(strIn) = False Then
            'give strIn a value, that would return no record
            strIn = "-1"
        End If

        ' to get one Employee using sp
        RunSPwithOneParam("usp_employee_get_by_id", "id", strIn)
    End Sub

    Public Function CheckIDPassword(strEmpID As String, strPassword As String) As Boolean
        ' purpose: check if ID and password are valid
        ' inputs: EmpID string and Password string
        ' outputs: true/false
        ' author: Tien Bui
        ' date: 02-06-2015

        'get this one Employee with ID
        GetEmployeeWithID(strEmpID)

        'check number of record in Employee dataset
        If mDatasetEmployee.Tables("tblEmployee").Rows.Count = 0 Then
            ' if no record, return false
            Return False
        End If

        'check password
        If mDatasetEmployee.Tables("tblEmployee").Rows(0).Item("Password") <> strPassword Then
            'if not match, return false
            Return False
        End If

        'if pass all test, return true
        Return True

    End Function

    'Public Sub GetAllEmployeeWithFullName()
    '    ' purpose: to return all Employee records
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the dataset
    '    '          with all the records in tblEmployee

    '    ' to Get all Employee use Select
    '    mstrQuery = "select *, lastname + ', ' + firstname AS fullname from tblEmployee order by lastname, firstname"
    '    ' run the query
    '    SelectQuery(mstrQuery)
    'End Sub

    'Public Function CheckID(Optional strNewEmpID As String = "") As Boolean
    '    ' purpose: check if Employee recors with given EmpID exist after running GetEmployeeWithEmpID
    '    ' inputs: optional EmpID string
    '    ' outputs: true/false
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' check number of record in Employee dataset
    '    If mDatasetEmployee.Tables("tblEmployee").Rows.Count = 0 Then
    '        ' if no record, return false
    '        Return False
    '    ElseIf strNewEmpID = mDatasetEmployee.Tables("tblEmployee").Rows(0).Item("EmpID").ToString Then
    '        ' if has record, but EmpID not changed, return false
    '        Return False
    '    End If

    '    ' otherwise, return true
    '    Return True

    'End Function

    'Public Function CheckPassword(strIn As String) As Boolean
    '    ' purpose: check if Employee enter the correct password after running GetEmployeeWithEmpID
    '    ' inputs: password string
    '    ' outputs: true/false
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' check if password match
    '    If mDatasetEmployee.Tables("tblEmployee").Rows(0).Item("Password") <> strIn Then
    '        'if not match, return false
    '        Return False
    '    Else
    '        'if match, return true
    '        Return True
    '    End If
    'End Function

    'Public Sub AddEmployee(strEmpID As String, strPassword As String, strLastName As String, strFirstName As String, strMI As String, strAddress As String, strCity As String, strState As String, strZip As String, strPhone As String, strEmail As String)
    '    ' purpose: add new Employee to database
    '    ' inputs: EmpID, password, lastname, firstname, initial, address, city, state, zip, phone, email
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-12-2015

    '    'declare variables
    '    Dim strQueryString As String = "INSERT INTO tblEmployee (EmpID, Password, LastName, FirstName, MI, Address, City, State, ZipCode, Phone, EmailAddr) VALUES (" & _
    '        "'" & strEmpID & "', " & _
    '        "'" & strPassword & "', " & _
    '        "'" & strLastName & "', " & _
    '        "'" & strFirstName & "', " & _
    '        "'" & strMI & "', " & _
    '        "'" & strAddress & "', " & _
    '        "'" & strCity & "', " & _
    '        "'" & strState & "', " & _
    '        "'" & strZip & "', " & _
    '        "'" & strPhone & "', " & _
    '        "'" & strEmail & "')"
    '    'update database with insert command
    '    UpdateDB(strQueryString)
    'End Sub

    'Public Sub UpdateEmployee(strEmpID As String, strPassword As String, strLastName As String, strFirstName As String, strMI As String, strAddress As String, strCity As String, strState As String, strZip As String, strPhone As String, strEmail As String, strID As String)
    '    ' purpose: update Employee information
    '    ' inputs: EmpID, password, lastname, firstname, initial, address, city, state, zip, phone, email, ID
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-22-2015

    '    'declare variables
    '    Dim strQueryString As String = "UPDATE tblEmployee SET " & _
    '        "EmpID = '" & strEmpID & "', " & _
    '        "Password = '" & strPassword & "', " & _
    '        "LastName = '" & strLastName & "', " & _
    '        "FirstName = '" & strFirstName & "', " & _
    '        "MI = '" & strMI & "', " & _
    '        "Address = '" & strAddress & "', " & _
    '        "City = '" & strCity & "', " & _
    '        "State = '" & strState & "', " & _
    '        "Zipcode = '" & strZip & "', " & _
    '        "Phone = '" & strPhone & "', " & _
    '        "EmailAddr = '" & strEmail & "' " & _
    '        "WHERE RecordID = " & strID

    '    'update database with insert command
    '    UpdateDB(strQueryString)
    'End Sub

    'Public Sub DeleteEmployee(intID As Integer)
    '    ' purpose: add new Employee to database
    '    ' inputs: EmpID, password, lastname, firstname, initial, address, city, state, zip, phone, email
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-12-2015

    '    'declare variables
    '    Dim strQueryString As String = "DELETE FROM tblEmployee WHERE RecordID=" & intID
    '    'update database with insert command
    '    UpdateDB(strQueryString)
    'End Sub
End Class
