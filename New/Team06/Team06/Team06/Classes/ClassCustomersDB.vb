﻿
Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ClassCustomersDB
    'Author: Tien Bui
    'Assignment: ASP5
    'Date: 03-03-2015
    'Program Description: Access and display data in database

    ' these module variables are internal to object
    Dim mDatasetCustomer As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_team06;user id=msbcr885;password=MISsqlpas789"
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property CustDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetCustomer
        End Get
    End Property

    Public ReadOnly Property CustView() As DataView
        Get
            ' return dataset to user
            Return mMyView
        End Get
    End Property

    Protected Sub UseSP(strUSPName As String, strDatasetName As DataSet, strViewName As DataView, strTableName As String, aryParamNames As ArrayList, aryParamValues As ArrayList)
        'Purpose: Run any stored procedure with any number of parameters
        'Arguments: Stored procedure name, tblName, dataset name, dataview name, arraylist of parameter names, and array list of parameter values\
        'Returns: Nothing
        'Author: Xiaoru Chen
        'Date: 3/22/2015

        'Create instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)


        'Tell SQL server the name of the stored procedure
        Dim mdbDataAdapter As New SqlDataAdapter(strUSPName, objConnection)

        Try
            'set the command type to stored procedure
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            'Add Parameters to stored procedure
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                mdbDataAdapter.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'clear dataset
            strDatasetName.Clear()

            'open the connection and fill dataset
            mdbDataAdapter.Fill(strDatasetName, strTableName)

            'fill view
            strViewName.Table = strDatasetName.Tables(strTableName)

            'print out each element of out arraylists if error occured
        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName: " & CStr(aryParamNames(index))
                strError = strError & "ParamValue: " & CStr(aryParamValues(index))
            Next
            Throw New Exception(strError & "error message is " & ex.Message)
        End Try

    End Sub

    Protected Sub UseSPNonQuery(strUSPName As String, aryParamNames As ArrayList, aryParamValues As ArrayList)
        'Purpose: Run any stored procedure with any number of parameters
        'Arguments: Stored procedure name, tblName, dataset name, dataview name, arraylist of parameter names, and array list of parameter values\
        'Returns: Nothing
        'Author: Xiaoru Chen
        'Date: 3/22/2015

        'Create instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)

        'Tell SQL server the name of the stored procedure
        Dim objCommand As New SqlDataAdapter(strUSPName, objConnection)

        Try
            'set the command type to stored procedure
            objCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            'Add Parameters to stored procedure
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                objCommand.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'open the connection and run insert/update query
            objCommand.SelectCommand.Connection = objConnection
            objConnection.Open()
            objCommand.SelectCommand.ExecuteNonQuery()
            objConnection.Close()

            'print out each element of out arraylists if error occured
        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName: " & CStr(aryParamNames(index))
                strError = strError & "ParamValue: " & CStr(aryParamValues(index))
            Next
            Throw New Exception(strError & "error message is " & ex.Message)
        End Try

    End Sub

    Protected Function GetValueFromSP(strUSPName As String) As Object
        'Purpose: Run any stored procedure with any number of parameters
        'Arguments: Stored procedure name, tblName, dataset name, dataview name, arraylist of parameter names, and array list of parameter values\
        'Returns: Nothing
        'Author: Xiaoru Chen
        'Date: 3/22/2015

        'Create instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Dim objReturnValue As Object

        'Tell SQL server the name of the stored procedure
        Dim objCommand As New SqlCommand(strUSPName, objConnection)
        objCommand.CommandType = CommandType.StoredProcedure

        'declare return variable
        Dim objReturnValue As IDbDataParameter = objCommand.CreateParameter()
        objReturnValue.Direction = ParameterDirection.ReturnValue

        'add return parameter
        objCommand.Parameters.Add(objReturnValue)

        'open connection, execute query, close connection
        objConnection.Open()
        objCommand.ExecuteNonQuery()
        objConnection.Close()

        'return value from store procedure
        Return objReturnValue.Value
    End Function

    Public Sub GetAllCustomers()
        ' purpose: to return all customer records
        ' inputs: none
        ' outputs: none directly, but it opens and fills the dataset
        '          with all the records in tblCustomers

        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'run usp to get all customers
        UseSP("usp_customers_get_all", mDatasetCustomer, mMyView, "tblCustomers", maryParamNames, maryParamValues)
    End Sub

    Public Sub GetCustomerWithEmail(strIn As String)
        ' purpose: get records of one EmpID
        ' inputs: EmpID string
        ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblEmployee
        ' author: Tien Bui
        ' date: 02-06-2015

        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'set array value
        maryParamNames.Add("email")
        maryParamValues.Add(strIn)

        ' to get one Employee using sp
        'RunSPwithOneParam(, "email", strIn)
        UseSP("usp_customers_get_customers_by_email", mDatasetCustomer, mMyView, "tblCustomers", maryParamNames, maryParamValues)
    End Sub

    Public Sub GetCustomerWithID(intID As Integer)
        ' purpose: get records of one EmpID
        ' inputs: EmpID string
        ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblEmployee
        ' author: Tien Bui
        ' date: 02-06-2015

        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'set array value
        maryParamNames.Add("ID")
        maryParamValues.Add(intID)

        ' to get one Employee using sp
        'RunSPwithOneParam(, "email", strIn)
        UseSP("usp_customers_get_customers_by_id", mDatasetCustomer, mMyView, "tblCustomers", maryParamNames, maryParamValues)
    End Sub

    Public Function CheckCustomerLogin(strEmail As String, strPassword As String) As Boolean
        ' purpose: check if ID and password are valid
        ' inputs: EmpID string and Password string
        ' outputs: true/false
        ' author: Tien Bui
        ' date: 02-06-2015

        'get this one Employee with ID
        GetCustomerWithEmail(strEmail)

        'check number of record in Employee dataset
        If mDatasetCustomer.Tables("tblCustomers").Rows.Count = 0 Then
            ' if no record, return false
            Return False
        End If

        'check password
        If mDatasetCustomer.Tables("tblCustomers").Rows(0).Item("Password").ToString <> strPassword Then
            'if not match, return false
            Return False
        End If

        'if pass all test, return true
        Return True

    End Function

    Public Function CheckCustomerLoginWithID(intID As Integer, strPassword As String) As Boolean
        ' purpose: check if ID and password are valid
        ' inputs: EmpID string and Password string
        ' outputs: true/false
        ' author: Tien Bui
        ' date: 02-06-2015

        'get this one Employee with ID
        GetCustomerWithID(intID)

        'check number of record in Employee dataset
        If mDatasetCustomer.Tables("tblCustomers").Rows.Count = 0 Then
            ' if no record, return false
            Return False
        End If

        'check password
        If mDatasetCustomer.Tables("tblCustomers").Rows(0).Item("Password").ToString <> strPassword Then
            'if not match, return false
            Return False
        End If

        'if pass all test, return true
        Return True

    End Function

    Public Sub UpdateCustomer(strEmail As String, strLastName As String, strFirstName As String, strAddress As String, strZip As String, strPhone As String, intAccount As Integer)
        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'set array value
        maryParamNames.Add("email")
        maryParamValues.Add(strEmail)
        maryParamNames.Add("lastname")
        maryParamValues.Add(strLastName)
        maryParamNames.Add("firstname")
        maryParamValues.Add(strFirstName)
        maryParamNames.Add("address")
        maryParamValues.Add(strAddress)
        maryParamNames.Add("zip")
        maryParamValues.Add(strZip)
        maryParamNames.Add("phone")
        maryParamValues.Add(strPhone)
        maryParamNames.Add("account")
        maryParamValues.Add(intAccount)

        UseSPNonQuery("usp_customers_update", maryParamNames, maryParamValues)
    End Sub

    Public Sub AddCustomer(strEmail As String, strLastName As String, strMI As String, strFirstName As String, strAddress As String, strZip As String, strPhone As String, strPassword As String, intAccount As Integer)
        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'set array value
        maryParamNames.Add("email")
        maryParamValues.Add(strEmail)
        maryParamNames.Add("lastname")
        maryParamValues.Add(strLastName)
        maryParamNames.Add("mi")
        maryParamValues.Add(strMI)
        maryParamNames.Add("firstname")
        maryParamValues.Add(strFirstName)
        maryParamNames.Add("address")
        maryParamValues.Add(strAddress)
        maryParamNames.Add("zip")
        maryParamValues.Add(strZip)
        maryParamNames.Add("phone")
        maryParamValues.Add(strPhone)
        maryParamNames.Add("password")
        maryParamValues.Add(strPassword)
        maryParamNames.Add("account")
        maryParamValues.Add(intAccount)

        UseSPNonQuery("usp_customers_create_account", maryParamNames, maryParamValues)
    End Sub

    Public Sub UpdatePassword(strPassword As String, intAccount As Integer)
        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'set array value
        maryParamNames.Add("password")
        maryParamValues.Add(strPassword)
        maryParamNames.Add("account")
        maryParamValues.Add(intAccount)

        UseSPNonQuery("usp_customers_update_password", maryParamNames, maryParamValues)
    End Sub

    Public Function GetNewAccountID() As Integer
        'Return Convert.ToInt32(GetValueFromSP("usp_customers_get_new_id"))
        Return Convert.ToInt32(GetValueFromSP("usp_customers_get_new_id"))
    End Function

    Public Sub GetCityStateByZip(strIn As String)
        ' purpose: get records of one EmpID
        ' inputs: EmpID string
        ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblEmployee
        ' author: Tien Bui
        ' date: 02-06-2015

        'declare dummy view
        Dim TempView As New DataView

        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'set array value
        maryParamNames.Add("ZipID")
        maryParamValues.Add(strIn)

        ' to get one Employee using sp
        UseSP("usp_zip_get_city_state", mDatasetCustomer, TempView, "tblZip", maryParamNames, maryParamValues)
    End Sub

    Public Function CheckZip(strIn As String) As Boolean
        'define class
        Dim valid As New ClassValidation

        'check if zip is all digits of length 5
        If valid.CheckAllDigits(strIn, 5) = False Then
            'return false
            Return False
        End If

        'if 5 digits, check if valid zip
        GetCityStateByZip(strIn)
        If mDatasetCustomer.Tables("tblZip").Rows.Count = 0 Then
            'if there is no row from the query, return false
            Return False
        End If

        'otherwise return true
        Return True
    End Function



    'Public Sub Sort(strValue As String)
    '    ' purpose: to return all customer records filtered by state
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the view
    '    '          with all the records in tblCustomers

    '    'set sort condition
    '    If strValue = "name" Then
    '        'sort view
    '        mMyView.Sort = "[Last Name], [First Name]"
    '    End If
    '    'set sort condition
    '    If strValue = "username" Then
    '        'sort view
    '        mMyView.Sort = "[Username]"
    '    End If

    'End Sub

    'Public Sub FilterCustomersByState(strValue As String)
    '    ' purpose: to return all customer records filtered by state
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the view
    '    '          with all the records in tblCustomers

    '    'filter view
    '    mMyView.RowFilter = "[State] = '" & strValue & "'"
    'End Sub

    'Public Sub FilterCustomersByCity(strValue As String)
    '    ' purpose: to return all customer records filtered by state
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the view
    '    '          with all the records in tblCustomers

    '    'if string is not blank, find by wildcard
    '    If strValue <> "" Then
    '        strValue = strValue & "%"
    '    End If
    '    'filter view
    '    mMyView.RowFilter = "[City] like '" & strValue & "'"
    'End Sub

    'Public Sub FilterCustomersByLastname(strValue As String)
    '    ' purpose: to return all customer records filtered by state
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the view
    '    '          with all the records in tblCustomers

    '    'if string is not blank, find by wildcard
    '    If strValue <> "" Then
    '        strValue = strValue & "%"
    '    End If
    '    'filter view
    '    mMyView.RowFilter = "[Last Name] like '" & strValue & "'"
    'End Sub

    'Public Sub FilterCustomersByUsername(strValue As String)
    '    ' purpose: to return all customer records filtered by state
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the view
    '    '          with all the records in tblCustomers

    '    'if string is not blank, find by wildcard
    '    If strValue <> "" Then
    '        strValue = strValue & "%"
    '    End If
    '    'filter view
    '    mMyView.RowFilter = "[Username] like '" & strValue & "'"
    'End Sub

    'Public Sub SelectQuery(ByVal strQuery As String)

    '    ' purpose: run any select query and fill dataset

    '    Try
    '        ' define data connection and data adapter
    '        mdbConn = New SqlConnection(mstrConnection)
    '        mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

    '        ' open the connection and dataset 
    '        mdbConn.Open()

    '        ' clear the dataset before filling
    '        mDatasetCustomer.Clear()

    '        ' fill the dataset
    '        mdbDataAdapter.Fill(mDatasetCustomer, "tblCustomers")

    '        ' close the connection
    '        mdbConn.Close()
    '    Catch ex As Exception
    '        Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
    '    End Try

    'End Sub

    'Public Sub UpdateDB(ByVal strQuery As String)
    '    ' purpose: update database
    '    ' inputs: username string
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

    'Public Sub GetAllCustomersWithFullName()
    '    ' purpose: to return all customer records
    '    ' inputs: none
    '    ' outputs: none directly, but it opens and fills the dataset
    '    '          with all the records in tblCustomers

    '    ' to Get all Customers use Select
    '    mstrQuery = "select *, lastname + ', ' + firstname AS fullname from tblCustomers order by lastname, firstname"
    '    ' run the query
    '    SelectQuery(mstrQuery)
    'End Sub

    'Public Sub GetCustomerWithUsername(strIn As String)
    '    ' purpose: get records of one username
    '    ' inputs: username string
    '    ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblCustomers
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' to get one customer using select
    '    mstrQuery = "select * from tblCustomers where username='" & strIn & "'"
    '    ' run the query
    '    SelectQuery(mstrQuery)
    'End Sub

    'Public Sub GetCustomerWithID(strIn As String)
    '    ' purpose: get records of one ID
    '    ' inputs: username string
    '    ' outputs: none directly, but it opens and fills the dataset with 1 or 0 record in tblCustomers
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' to get one customer using select
    '    mstrQuery = "select * from tblCustomers where RecordID='" & strIn & "'"
    '    ' run the query
    '    SelectQuery(mstrQuery)
    'End Sub

    'Public Function CheckUsername(Optional strNames() As String = Nothing) As Boolean
    '    ' purpose: check if customer recors with given username exist after running GetCustomerWithUsername
    '    ' inputs: optional username string
    '    ' outputs: true/false
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' check if strNewUsername() is provided
    '    If strNames Is Nothing Then
    '        'if not, set default
    '        strNames(0) = "old"
    '        strNames(1) = "new"
    '    End If

    '    ' check if user changed the username or not
    '    If strNames(0).ToUpper = strNames(1).ToUpper Then
    '        'if name didn't change, return false
    '        Return False
    '    End If

    '    ' check number of record in customer dataset
    '    If mDatasetCustomer.Tables("tblCustomers").Rows.Count = 0 Then
    '        ' if no record, return false
    '        Return False
    '    End If

    '    ' otherwise, return true
    '    Return True

    'End Function

    'Public Function CheckPassword(strIn As String) As Boolean
    '    ' purpose: check if customer enter the correct password after running GetCustomerWithUsername
    '    ' inputs: password string
    '    ' outputs: true/false
    '    ' author: Tien Bui
    '    ' date: 02-06-2015

    '    ' check if password match
    '    If mDatasetCustomer.Tables("tblCustomers").Rows(0).Item("Password") <> strIn Then
    '        'if not match, return false
    '        Return False
    '    Else
    '        'if match, return true
    '        Return True
    '    End If
    'End Function

    'Public Sub AddCustomer(strUsername As String, strPassword As String, strLastName As String, strFirstName As String, strMI As String, strAddress As String, strCity As String, strState As String, strZip As String, strPhone As String, strEmail As String)
    '    ' purpose: add new customer to database
    '    ' inputs: username, password, lastname, firstname, initial, address, city, state, zip, phone, email
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-12-2015

    '    'declare variables
    '    Dim strQueryString As String = "INSERT INTO tblCustomers (UserName, Password, LastName, FirstName, MI, Address, City, State, ZipCode, Phone, EmailAddr) VALUES (" & _
    '        "'" & strUsername & "', " & _
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

    'Public Sub UpdateCustomer(strUsername As String, strPassword As String, strLastName As String, strFirstName As String, strMI As String, strAddress As String, strCity As String, strState As String, strZip As String, strPhone As String, strEmail As String, strID As String)
    '    ' purpose: update customer information
    '    ' inputs: username, password, lastname, firstname, initial, address, city, state, zip, phone, email, ID
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-22-2015

    '    'declare variables
    '    Dim strQueryString As String = "UPDATE tblCustomers SET " & _
    '        "UserName = '" & strUsername & "', " & _
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

    'Public Sub DeleteCustomer(intID As Integer)
    '    ' purpose: add new customer to database
    '    ' inputs: username, password, lastname, firstname, initial, address, city, state, zip, phone, email
    '    ' outputs: none directly, update records into database
    '    ' author: Tien Bui
    '    ' date: 02-12-2015

    '    'declare variables
    '    Dim strQueryString As String = "DELETE FROM tblCustomers WHERE RecordID=" & intID
    '    'update database with insert command
    '    UpdateDB(strQueryString)
    'End Sub


End Class
