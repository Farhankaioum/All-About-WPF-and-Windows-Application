Imports System.Data.SqlClient
Public Class certificateDAL

    Public Sub Insert_Data(ByVal cmd)
        Try

        
            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Insertcertificate"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            conn.Close()
        End Try

    End Sub
    'Insertcertificate_towhomItMayConcern
    Public Sub Insert_DatatowhomItMayConcern(ByVal cmd)
        connectDB()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Insertcertificate_towhomItMayConcern"

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    'Public Sub report(ByVal cmd) as DataTable  
    '    connectDB()
    '    Dim ds As DataSet
    '    Dim da As SqlDataAdapter ("select",conn )
    '    ds.Clear()
    '    da = New SqlDataAdapter(Sql, conn)
    '    da.Fill(ds, "sdSD")
    '    Return ds


    'End Sub
End Class
