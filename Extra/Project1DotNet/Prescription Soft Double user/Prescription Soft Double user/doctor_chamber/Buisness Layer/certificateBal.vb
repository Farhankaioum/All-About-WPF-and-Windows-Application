Imports System.Data.SqlClient
Public Class certificateBal
    Public name, gender, age, Dear_name, disease_name, suggestion, bed_rest_duration As String
    Public Address, Hospital_name As String

    Public date_print, fromDate, todate, restfromdate, resttodate As Date

    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter

    Dim ObjDALcertificate As New certificateDAL

    Public Sub insert_data()


        cmd.Parameters.AddWithValue("@date_print", date_print)

        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@gender", gender)
        cmd.Parameters.AddWithValue("@age", age)
        cmd.Parameters.AddWithValue("@Dear_name", Dear_name)
        'cmd.Parameters.AddWithValue("@address", Address)
        cmd.Parameters.AddWithValue("@fromDate", fromDate)
        cmd.Parameters.AddWithValue("@todate", todate)
        cmd.Parameters.AddWithValue("@disease_name", disease_name)
        cmd.Parameters.AddWithValue("@suggestion", suggestion)
        cmd.Parameters.AddWithValue("@bed_rest_duration", bed_rest_duration)

        ObjDALcertificate.Insert_Data(cmd)
        cmd.Parameters.Clear()

    End Sub


    Public Sub insert_dataItMayConcern()


        cmd.Parameters.AddWithValue("@date_print", date_print)

        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@gender", gender)
        cmd.Parameters.AddWithValue("@age", age)

        cmd.Parameters.AddWithValue("@fromDate", fromDate)
        cmd.Parameters.AddWithValue("@todate", todate)

        cmd.Parameters.AddWithValue("@bed_rest_duration", bed_rest_duration)
        cmd.Parameters.AddWithValue("@address", Address)
        cmd.Parameters.AddWithValue("@Hospital_name", Hospital_name)

        cmd.Parameters.AddWithValue("@restfromdate", restfromdate)

        cmd.Parameters.AddWithValue("@resttodate", resttodate)
        ObjDALcertificate.Insert_DatatowhomItMayConcern(cmd)
        cmd.Parameters.Clear()

    End Sub



    Public Sub report()
      

        'Return ObjDALcertificate. 
    End Sub


End Class
