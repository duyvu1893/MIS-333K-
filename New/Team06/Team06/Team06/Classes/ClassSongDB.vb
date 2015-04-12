
Option Strict On
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ClassSongDB
    'Author: Tien Bui
    'Assignment: ASP5
    'Date: 03-03-2015
    'Program Description: Access and display data in database

    ' these module variables are internal to object
    Dim mDatasetSongs As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=mis333k_20152_team06;user id=msbcr885;password=MISsqlpas789"
    Dim maryParamNames As New ArrayList
    Dim maryParamValues As New ArrayList

    Dim valid As New ClassValidation

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property CustDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetSongs
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

    Public Sub GetAllGenre()
        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'run usp to get all customers
        UseSP("usp_genres_get_all", mDatasetSongs, mMyView, "tblGenres", maryParamNames, maryParamValues)
    End Sub

    Public Sub GetAllSongs()
        'clear arrays
        maryParamNames.Clear()
        maryParamValues.Clear()

        'run usp to get all customers
        UseSP("usp_songs_get_all", mDatasetSongs, mMyView, "tblSongs", maryParamNames, maryParamValues)

    End Sub
End Class
