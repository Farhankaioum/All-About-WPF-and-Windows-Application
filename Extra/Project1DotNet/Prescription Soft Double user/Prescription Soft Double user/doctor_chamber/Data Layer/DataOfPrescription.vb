Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DataOfPrescription
    Dim objModelPatiant As New ModelOfPrescription
    Dim RowCount As Integer

    Public Function GetAllInformation(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " order by " + objModelPatiant.field_name + " asc"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function GetChecklistValue(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select   " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where sl_no between 1 and 20 order by  sl_no"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function Getmedicine(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + "   ORDER BY medicine_doses " 'CASE WHEN medicine_doses = 'Tab.' THEN '1'WHEN medicine_doses = 'CAP.THEN'2' WHEN medicine_doses = 'SYR.THEN'3' WHEN medicine_doses = 'INJ.THEN '4'else medicine_doses asc"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function getadvice(ByVal advice) As DataTable

        Dim SqlString As String = "select distinct sl_no, Advice from  getAdvice where getAdvice. Advice_group_id in(select Advice_group_id from dbo.Advice_group_name  where Advice_group_name.Advice_group_name=N'" + advice.ToString + "') order by getAdvice.sl_no"

        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function GetfeedingRulse(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select   " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + "   ORDER BY sl_no  " ' CASE WHEN medicine_doses = 'Tab.' THEN '1'WHEN medicine_doses = 'CAP.THEN'2' WHEN medicine_doses = 'SYR.THEN'3' WHEN medicine_doses = 'INJ.THEN '4'else medicine_doses asc"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function GetAllInformation_status_notseen(ByVal objModelPatiant) As DataTable
        'where status='Waiting'
        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + "  order by " + objModelPatiant.field_name + " desc"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function p_id_Generator(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select isnull(max( " + objModelPatiant.field_name + " ),0)+1 as NewPatient_ID from " + objModelPatiant.tableName + ""
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function R_id_Generator() As Integer

        Dim SqlString As String = "select isnull (max(RID),0)  as RID from  dbo.ReadymadePrescription  "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then


            Dim value As Integer = Integer.Parse(dt.Rows(0)("RID").ToString())    'dt.Item("InstallmentNumber")
            Return value
        Else
            Return 0
        End If
    End Function
    Public Function p_VisitTime_Generator(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select isnull(max( " + objModelPatiant.field_name + " ),0)+1 as Visite_time from " + objModelPatiant.tableName + " where patient_ID=" + objModelPatiant.patient_Id.ToString + ""
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    

    Public Function getPatient_InfoByPatientID(ByVal objModelPatiant) As DataTable
        Try

       
            Dim SqlString As String = "select  " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where patient_ID='" + objModelPatiant.condition.ToString + "' order by sl_no desc "
            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function getmaxpVisite(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select  " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where patient_ID='" + objModelPatiant.condition.ToString + "'and visit_count=(select max(visit_count)from " + objModelPatiant.tableName + " where patient_ID='" + objModelPatiant.condition.ToString + "') order by sl_no desc "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function getPatientReadymade_InfoByRID(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select  " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where rid='" + objModelPatiant.condition.ToString + "' order by sl_no asc "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function




    Public Function getPatientComplainByIdandVisit(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select  " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where patient_ID=" + objModelPatiant.patient_Id.ToString + " and visit_count=" + objModelPatiant.patient_visitCount.ToString + ""
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
        
    End Function
   

    Public Function InsertPatient_Visit(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertPatient_Visit"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("visit_Datetime", objModelPatiant.to_Date)
            insAdd.Parameters.AddWithValue("status", objModelPatiant.other)


            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function




    Public Function InsertExamination(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertExamination"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("temp", objModelPatiant.temp)
            insAdd.Parameters.AddWithValue("bloodPress", objModelPatiant.bloodPress)

            insAdd.Parameters.AddWithValue("bloodPressLow", objModelPatiant.bloodPressLow)
            insAdd.Parameters.AddWithValue("pulse", objModelPatiant.pulse)
            insAdd.Parameters.AddWithValue("weight", objModelPatiant.weight)
            insAdd.Parameters.AddWithValue("other", objModelPatiant.other)
            insAdd.Parameters.AddWithValue("Heart", objModelPatiant.Heart)
            insAdd.Parameters.AddWithValue("Lungs", objModelPatiant.Lungs)
            insAdd.Parameters.AddWithValue("VaricosVein", objModelPatiant.VaricosVein)
            insAdd.Parameters.AddWithValue("carotidBruit", objModelPatiant.carotidBruit)

            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount



        Catch ex As Exception
            conn.Close()
        End Try
    End Function
    Public Function InsertPatient_information(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertPatentInformation"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("P_Name", objModelPatiant.patient_name)
            insAdd.Parameters.AddWithValue("P_Age", objModelPatiant.patient_age)
            insAdd.Parameters.AddWithValue("P_Address", objModelPatiant.P_Address)
            insAdd.Parameters.AddWithValue("P_Mobile", objModelPatiant.P_Mobile)
            insAdd.Parameters.AddWithValue("User_Name_doctor", objModelPatiant.User_Name_doctor)
            insAdd.Parameters.AddWithValue("Sex", objModelPatiant.Sex)
            insAdd.Parameters.AddWithValue("remark", objModelPatiant.remark)

            insAdd.Parameters.AddWithValue("date_of_birth", objModelPatiant.date_of_birth)
            insAdd.Parameters.AddWithValue("marital_status", objModelPatiant.marital_status)
            insAdd.Parameters.AddWithValue("marital_in", objModelPatiant.marital_in)
            insAdd.Parameters.AddWithValue("occupation", objModelPatiant.occupation)
            insAdd.Parameters.AddWithValue("son", objModelPatiant.son)
            insAdd.Parameters.AddWithValue("daughter", objModelPatiant.daughter)
            insAdd.Parameters.AddWithValue("refferred_by", objModelPatiant.refferred_by)
            insAdd.Parameters.AddWithValue("special_alert", objModelPatiant.special_alert)
            insAdd.Parameters.AddWithValue("other_info", objModelPatiant.other_info)


            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function InsertInsertreferral_by(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "Insertreferral_by"
            insAdd.CommandType = CommandType.StoredProcedure

            
            insAdd.Parameters.AddWithValue("Referral_by", objModelPatiant.Referral_by)
            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function InsertdrugHistory(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertdrugHistory"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("drugHistory", objModelPatiant.drugHistory)
            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function Insertotehrfindings(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "Insertotehrfindings"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("otherFindings", objModelPatiant.otherFindings)
            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function InsertDiagnsis(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertDiagnosis"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("Diagnosis", objModelPatiant.Diagnosis)


            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function


    Public Function InsertTreatment(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertTreatment"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("Treatment", objModelPatiant.Treatment)


            conn.Open()


            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()

            Return RowCount



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function



    Public Function InsertInvestigationTest(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertInvestigationTest"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("InvestigationTest", objModelPatiant.InvestigationTest)
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function



    Public Function InsertGetMedicine(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertGetMedicine"
            insAdd.CommandType = CommandType.StoredProcedure

           
            insAdd.Parameters.AddWithValue("medicine_doses", objModelPatiant.DosesType)
            insAdd.Parameters.AddWithValue("medicine_name", objModelPatiant.medicine_name)
            insAdd.Parameters.AddWithValue("strength", objModelPatiant.strength)

            
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function InsertReadymadeMedicine(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "dbo.InsertReadymadeMedicine"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("RID", objModelPatiant.rid)
            'insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("rmedicine_doses", objModelPatiant.DosesType)
            insAdd.Parameters.AddWithValue("rmedicine", objModelPatiant.medicine_name)
            insAdd.Parameters.AddWithValue("rstrength", objModelPatiant.strength)
            insAdd.Parameters.AddWithValue("medicine_feeding_rules", objModelPatiant.medicine_feeding_rules)

            insAdd.Parameters.AddWithValue("medicine_period", objModelPatiant.medicine_period)

             conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function InsertMedicine(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertMedicine"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("medicine_doses", objModelPatiant.DosesType)
            insAdd.Parameters.AddWithValue("medicine_name", objModelPatiant.medicine_name)
            insAdd.Parameters.AddWithValue("strength", objModelPatiant.strength)

            insAdd.Parameters.AddWithValue("medicine_feeding_rules", objModelPatiant.medicine_feeding_rules)
            insAdd.Parameters.AddWithValue("medicine_period", objModelPatiant.medicine_period)
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function InsertComplaints(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertComplaints"
            insAdd.CommandType = CommandType.StoredProcedure


            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("complain", objModelPatiant.Complain)
            insAdd.Parameters.AddWithValue("since_duration", objModelPatiant.Duration)
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function InsertPastHistory(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertPastHistory"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("Past_history", objModelPatiant.Past_history)
              conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
        End Try
    End Function

    Public Function InsertAbdomenLump(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertAbdomenLump"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("Abdomen_Lump", objModelPatiant.AbdomenLump)
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
        End Try
    End Function


    Public Function InsertNextVisit(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertNextVisit"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("NextVisit", objModelPatiant.NextVisit)
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
        End Try
    End Function

    Public Function InsertAdvice(ByVal objModelPatiant) As Integer
        Try

            Dim insAdd As New SqlCommand("insAdd", conn)
            Dim cmd As New SqlCommand()
            insAdd.CommandText = "InsertAdvice"
            insAdd.CommandType = CommandType.StoredProcedure

            insAdd.Parameters.AddWithValue("patient_ID", objModelPatiant.patient_ID)
            insAdd.Parameters.AddWithValue("visit_count", objModelPatiant.patient_visitCount)
            insAdd.Parameters.AddWithValue("Advice", objModelPatiant.Advice)
            conn.Open()
            RowCount = insAdd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
        End Try
    End Function
    Public Function GetAllVisitByPId(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where patient_ID=" + objModelPatiant.condition.ToString + ""
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function getPatient_TestReports(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select sl_no , patient_ID , visit_count , InvestigationTest , Date, Lab, Result, Refrence_Range  from " + objModelPatiant.tableName + " where patient_ID='" + objModelPatiant.condition.ToString + "' order by patient_ID , visit_count "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function getPatient_TestReports_whereCondition(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select sl_no , patient_ID , visit_count , InvestigationTest , Date, Lab, Result  from " + objModelPatiant.tableName + " where patient_ID='" + objModelPatiant.condition.ToString + "' and visit_count='" + objModelPatiant.condition2.ToString + "' order by patient_ID , visit_count "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

   
    Public Function InsertIntoReadymadeTable(ByVal objModelPatiant) As Integer


        Try

       
            Dim insAdd As String = ""
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand()
            Dim SqlString_get As String

            'SqlString_get = "delete     from " + objModelPatiant.tableName + " where RiD=  " + objModelPatiant.rid + " "
            'dt = dt_Execute(SqlString_get)
            'If dt.Rows.Count > 0 Then

            'Else
            Dim SqlString As String = "Insert into " + objModelPatiant.tableName + "( " + objModelPatiant.field_name + ") values ( '" + objModelPatiant.rid + "', N'" + objModelPatiant.GetTableValue + "') "

            Dim command As SqlCommand = New SqlCommand(SqlString, conn)
            command.CommandType = CommandType.Text

            conn.Open()

            If (command.ExecuteNonQuery().Equals(1)) Then
                conn.Close()
                Return 1
            Else
                conn.Close()
                '  MsgBox("Not stored in database")
                Return 0
            End If



            'End If



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Function



    Public Function InsertIntoGetTable(ByVal objModelPatiant) As Boolean
        Try

            Dim insAdd As String = ""
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand()
            Dim SqlString_get As String

            SqlString_get = "select   " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.field_name + "= N'" + objModelPatiant.GetTableValue + "'"
            dt = dt_Execute(SqlString_get)
            If dt.Rows.Count > 0 Then
                Return False

            Else
                Dim SqlString As String = "Insert into " + objModelPatiant.tableName + "( " + objModelPatiant.field_name + ") values (  N'" + objModelPatiant.GetTableValue + "') "

                Dim command As SqlCommand = New SqlCommand(SqlString, conn)
                command.CommandType = CommandType.Text

                conn.Open()

                If (command.ExecuteNonQuery().Equals(1)) Then
                    conn.Close()
                    Return True
                Else
                    conn.Close()

                End If



            End If


        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error to save .")

        End Try



    End Function


    Public Function login(ByVal objModelPatiant) As DataTable



        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where User_Name_doctor= '" + objModelPatiant.username.ToString + "' and User_Password ='" + objModelPatiant.password.ToString + "'"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)



        Return dt
    End Function

    

    Public Function getInformationBycondition(ByVal objModelPatiant, ByVal t) As DataTable
        Try


            If t = 1 Then

                Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'"
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt

            ElseIf t = 2 Then
                Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "'"

                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt
            ElseIf t = 3 Then
                Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "'and " + objModelPatiant.condition_field3 + " =  '" + objModelPatiant.condition3.ToString + "'"

                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt
            ElseIf t = 4 Then 'like condition
                Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + " like '" + objModelPatiant.condition.ToString + "%'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "'"
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt

            ElseIf t = 5 Then

                Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + "" ' where " + objModelPatiant.condition_field + " like '" + objModelPatiant.condition.ToString + "%'"
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt

                ' search by brand_name
            ElseIf t = 6 Then

                Dim SqlString As String = "select  " + objModelPatiant.field_name + "  from dbo.t_drug_brand,dbo.t_drug_generic,t_company_name where dbo.t_drug_generic.generic_id=t_drug_brand.generic_id and dbo.t_company_name.company_id =dbo.t_drug_brand.company_id  and CONVERT(VARCHAR, t_drug_brand.brand_name) =  '" + objModelPatiant.brand_name.ToString + "' "
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt
                'generic name

            ElseIf t = 7 Then

                Dim SqlString As String = "select precaution, indication, contra_indication, dose, side_effect,   mode_of_action, interaction from dbo.t_drug_generic  where convert (varchar , generic_name)= '" + objModelPatiant.genericName.ToString + "' "
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt
            ElseIf t = 8 Then

                Dim SqlString As String = "select  distinct  " + objModelPatiant.field_name + "   from dbo.t_drug_brand,dbo.t_drug_generic,t_company_name where dbo.t_drug_generic.generic_id=t_drug_brand.generic_id and dbo.t_company_name.company_id =dbo.t_drug_brand.company_id  and CONVERT(VARCHAR,  t_drug_generic.generic_name) =  '" + objModelPatiant.genericName.ToString + "' "
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt

                'ElseIf t = 9 Then

                '    Dim SqlString As String = "select  distinct  " + objModelPatiant.field_name + "   from dbo.t_drug_brand,dbo.t_drug_generic,t_company_name where dbo.t_drug_generic.generic_id=t_drug_brand.generic_id and dbo.t_company_name.company_id =dbo.t_drug_brand.company_id  and CONVERT(VARCHAR,  t_drug_generic.generic_name) =  '" + objModelPatiant.genericName.ToString + "'and brand_name= '" + objModelPatiant.brand_name.ToString + "' "
                '    Dim dt As New DataTable()
                '    da = New SqlDataAdapter(SqlString, conn)
                '    da.Fill(dt)
                '    Return dt

            ElseIf t = 10 Then

                Dim SqlString As String = "select  distinct  " + objModelPatiant.field_name + "   from dbo.t_drug_brand,dbo.t_drug_generic,t_company_name where dbo.t_drug_generic.generic_id=t_drug_brand.generic_id and dbo.t_company_name.company_id =dbo.t_drug_brand.company_id  and CONVERT(VARCHAR,  t_drug_generic.generic_name) =  '" + objModelPatiant.genericName.ToString + "'and form= '" + objModelPatiant.dosageName.ToString + "' "
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt
            ElseIf t = 11 Then

                Dim SqlString As String = "select  distinct  " + objModelPatiant.field_name + "   from dbo.t_drug_brand,dbo.t_drug_generic,t_company_name where dbo.t_drug_generic.generic_id=t_drug_brand.generic_id and dbo.t_company_name.company_id =dbo.t_drug_brand.company_id  and CONVERT(VARCHAR,  t_drug_generic.generic_name) =  '" + objModelPatiant.genericName.ToString + "'and form= '" + objModelPatiant.dosageName.ToString + "'and brand_name= '" + objModelPatiant.brand_name.ToString + "'  "
                Dim dt As New DataTable()
                da = New SqlDataAdapter(SqlString, conn)
                da.Fill(dt)
                Return dt

            End If
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Public Function show_Patient_info(ByVal objModelPatiant) As DataTable
        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where patient_ID in  (select distinct patient_ID from dbo.patient_Visit where visit_Datetime between  '" + objModelPatiant.from_date + "' and  '" + objModelPatiant.to_Date + "')"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt

    End Function


    Public Function GetInfoByVisiteandId(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where patient_ID= '" + objModelPatiant.rows_serial.ToString + "'and visit_count= '" + objModelPatiant.rows_serial2 + "'"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function update(ByVal objModelPatiant) As DataTable
        Try

       
            Dim SqlString As String = "update " + objModelPatiant.tableName + " set " + objModelPatiant.field_name + " =N'" + objModelPatiant.condition_field + "' where sl_no= '" + objModelPatiant.rows_serial.ToString + "'"
            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Public Function update_medicine(ByVal objModelPatiant) As DataTable
        Try


            Dim SqlString As String = "update dbo.medicine set  medicine_doses='" + objModelPatiant.DosesType.ToString + "',medicine_name='" + objModelPatiant.medicine_name.ToString + "',strength='" + objModelPatiant.strength.ToString + "',medicine_feeding_rules=N'" + objModelPatiant.medicine_feeding_rules.ToString + "',medicine_period=N'" + objModelPatiant.medicine_period.ToString + "' where sl_no='" + objModelPatiant.rows_serial.ToString + "'"

            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Public Function Update_complaints(ByVal objModelPatiant) As DataTable
        Try


            Dim SqlString As String = "update " + objModelPatiant.tableName + " set " + objModelPatiant.field_name + " =N'" + objModelPatiant.condition_field + "' ,  " + objModelPatiant.field_name1 + " =N'" + objModelPatiant.condition_field1 + "' where sl_no= '" + objModelPatiant.rows_serial.ToString + "'"
            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Public Function Update_patient_Visit_status(ByVal objModelPatiant) As DataTable
        Try


            Dim SqlString As String = "update " + objModelPatiant.tableName + " set " + objModelPatiant.field_name + " ='Seen' where   patient_ID= '" + objModelPatiant.rows_serial.ToString + "' and  visit_count ='" + objModelPatiant.rows_serial2.ToString + "' and status='Waiting'"
            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Public Function getPatient_TestReports_Edit(ByVal objModelPatiant) As Integer
        Try
            Dim insAdd As New SqlCommand("insAdd", conn)
            insAdd.CommandText = "UPDATE " + objModelPatiant.tableName + " SET " + objModelPatiant.ColumName + " ='" + Form1.DGV1.Rows(objModelPatiant.row).Cells(objModelPatiant.ColumName).Value.ToString + "' where sl_no = " + objModelPatiant.rows_serial.ToString + ""

            conn.Open()
            Dim l As Integer = insAdd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function backup()
        connectDB()
        Dim formattedDate As String = Date.Today.ToString("dd_MM_yyyy")
        Dim insAdd As String
        insAdd = "backup  database  PatientMonitor to disk='D:\DB Backup\PatientMonitor_backup_" + formattedDate + ".bak'"


        queryEx(insAdd)
        Return 1
    End Function


    Public Function delete(ByVal objModelPatiant) As Integer
        Try

 
            Dim SqlString As String = "delete from " + objModelPatiant.tableName + "  where sl_no= " + objModelPatiant.rows_serial.ToString + ""

            Dim cmd As SqlCommand = New SqlCommand(SqlString, conn)
            If conn.State = 0 Then '0 means open
                conn.Open()
            Else

            End If
 
            '  Dim command As SqlCommand = New SqlCommand(SqlString, conn)
            cmd.CommandType = CommandType.Text
 
            If (cmd.ExecuteNonQuery().Equals(1)) Then
                conn.Close()
                Return RowCount

            Else
                conn.Close()
                Return RowCount

                '  MsgBox("Not stored in database")
            End If



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
            Return 0

        End Try




    End Function

    Public Function deleteBYRid(ByVal objModelPatiant) As Integer
        Try


            Dim SqlString As String = "delete from " + objModelPatiant.tableName + "  where rid= " + objModelPatiant.rows_serial.ToString + ""

            Dim cmd As SqlCommand = New SqlCommand(SqlString, conn)
            If conn.State = 0 Then '0 means open
                conn.Open()
            Else

            End If

            '  Dim command As SqlCommand = New SqlCommand(SqlString, conn)
            cmd.CommandType = CommandType.Text

            If (cmd.ExecuteNonQuery().Equals(1)) Then
                conn.Close()
                Return RowCount

            Else
                conn.Close()
                Return RowCount

                '  MsgBox("Not stored in database")
            End If



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
            Return 0

        End Try




    End Function


    Public Sub datagrid_edit()

        Try
            'Dim insAdd As New SqlCommand("insAdd", conn)
            'insAdd.CommandText = "UPDATE[knitt_production] SET " + objModelPatiant.ColumName + " ='" + objModelPatiant.DataGridViewkp.Rows(ObjKnittModel.row).Cells(objModelPatiant.col).Value.ToString + "' where sl_no = " + objModelPatiant.rows_serial.ToString + ""

            'conn.Open()
            'insAdd.ExecuteNonQuery()
            'conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
    Public Function deleteBYpid(ByVal objModelPatiant) As Integer
        Try


            Dim SqlString As String = "delete from " + objModelPatiant.tableName + "  where patient_ID= " + objModelPatiant.rows_serial.ToString + ""

            Dim cmd As SqlCommand = New SqlCommand(SqlString, conn)


            '  Dim command As SqlCommand = New SqlCommand(SqlString, conn)
            conn.Open()
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            conn.Close()



        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
            Return 0

        End Try




    End Function

    Public Function Advice_group_name() As DataTable
        connectDB()
        Dim SqlString As String = "select distinct Advice_group_name from   Advice_group_name  order by Advice_group_name"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt


    End Function


    Public Function selectInvestigation_groupId(ByVal cmd) As DataTable
        Try
            Dim DT As New DataTable


            connectDB()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "selectInvestigation_groupId"
            da = New SqlDataAdapter(cmd)
            DT.Clear()
            da.Fill(DT)


            conn.Close()
            Return DT

        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function BlindInvestigation_group_name() As DataTable
        connectDB()
        Dim da As New SqlDataAdapter("selectinvestigation_group_name", conn)
        Dim dt As New DataTable

        da.Fill(dt)
        Return dt

    End Function

    Public Function GetInvestigationNameByPId(ByVal investigation_group_id) As DataTable

        Dim SqlString As String = "select   InvestigationTest from dbo.GetInvestigationTest where investigation_group_id=" + investigation_group_id.ToString + " order by sl_no"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt

    End Function
    Public Function BlindGrid(ByVal cmd, ByVal ProcedureName) As DataTable
        Try


            Dim DT As New DataTable


            connectDB()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = ProcedureName
            da = New SqlDataAdapter(cmd)
            DT.Clear()
            da.Fill(DT)


            conn.Close()
            Return DT
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    'password change
    Public Sub password(ByVal pass)
        Try


            Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
            Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo



            For Each myTable In pass.Database.Tables
                myLogin = myTable.LogOnInfo
                myLogin.ConnectionInfo.UserID = "sa"
                myLogin.ConnectionInfo.ServerName = "."
                'myLogin.ConnectionInfo.Password = "noboit"
                'mannan2017

                myTable.ApplyLogOnInfo(myLogin)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub
End Class
