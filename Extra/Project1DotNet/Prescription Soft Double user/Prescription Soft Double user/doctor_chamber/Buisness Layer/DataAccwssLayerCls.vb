Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class DataAccwssLayerCls
    Dim RowCount As Integer
    Dim insAdd As String

    Public Sub startPoint(ByVal frmname)
        frmname.Left = 400
        frmname.Top = 10
    End Sub
    'Public conn As New SqlConnection
    Public Function BlindPatientPatientRegistation()
        connectDB()
        Dim da As New SqlDataAdapter("selectPatientRegistation", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function
    Public Function deletegroupid(ByVal objModelPatiant) As Integer
        Try
            Dim SqlString As String = "delete from " + objModelPatiant.tableName + "  where Advice_group_id= " + objModelPatiant.sl_no.ToString + ""

            Dim cmd As SqlCommand = New SqlCommand(SqlString, conn)
            'If conn.State = 0 Then '0 means open
            '    conn.Open()
            'Else

            'End If


            conn.Open()

            cmd.CommandType = CommandType.Text
            RowCount = cmd.ExecuteNonQuery()

            conn.Close()
            Return RowCount

            '  MsgBox("Not stored in database")



        Catch ex As Exception
            conn.Close()

            Return 0

        End Try




    End Function
    Public Function SelectALLDoctorIdForGrid(ByVal modelHMSObj) As DataTable
        connectDB()
        'Dim modelHMSobj As New modelHMS
        Dim SqlString As String = "select     " + modelHMSObj.field_name + " from " + modelHMSObj.tableName + " order by DocId desc"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function selectGetWard()
        connectDB()
        Dim da As New SqlDataAdapter("selectGetWard", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function

    Public Function selectAdviceGroupHead()
        connectDB()
        Dim da As New SqlDataAdapter("selectAdviceGroupHead", conn)
        Dim dt As New DataTable

        da.Fill(dt)
        Return dt

    End Function

    Public Function SelectPatientByAdmissionId()
        connectDB()
        Dim da As New SqlDataAdapter("SelectPatientByAdmissionId", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function

    Public Function SelectPatientByALLAdmission()
        connectDB()
        Dim da As New SqlDataAdapter("SelectPatientByALLAdmission", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds


    End Function
    Public Function selectDiagnosis()
        connectDB()
        Dim da As New SqlDataAdapter("selectDiagnosis", conn)
        Dim ds As New DataTable

        da.Fill(ds)
        Return ds

    End Function




    Public Function selectAdmission(ByVal modelHMSObj) As DataTable

        'Dim modelHMSobj As New modelHMS
        Dim SqlString As String = "select     PatientId, AdmissionDate,  AdmissionUnder, Word, Bed from dbo.Admission where AdmissionID='" + modelHMSObj.AdmissionId.ToString + "' "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function SelectComplainForGrid(ByVal modelHMSObj) As DataTable

        'Dim modelHMSobj As New modelHMS
        Dim SqlString As String = "select     " + modelHMSObj.field_name + " from " + modelHMSObj.tableName + " where patient_ID='" + modelHMSObj.PatientId.ToString + "'and visit_count='" + modelHMSObj.visit_count.ToString + "' "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function SelectByPatientIdForGrid(ByVal modelHMSObj) As DataTable
        connectDB()
        'Dim modelHMSobj As New modelHMS
        Dim SqlString As String = "select     " + modelHMSObj.field_name + "from " + modelHMSObj.tableName + " where PatientId='" + modelHMSObj.PatientId.ToString + "' "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function


    Public Function SelectALLPatientIdForGrid(ByVal modelHMSObj) As DataTable
        connectDB()
        'Dim modelHMSobj As New modelHMS
        Dim SqlString As String = "select     " + modelHMSObj.field_name + " from " + modelHMSObj.tableName + " "
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function delete(ByVal objModelPatiant) As Integer
        Try
  
            Dim SqlString As String = "delete from " + objModelPatiant.tableName + "  where sl_no= " + objModelPatiant.sl_no.ToString + ""

            Dim cmd As SqlCommand = New SqlCommand(SqlString, conn)
            
            conn.Open()

            cmd.CommandType = CommandType.Text
            RowCount = cmd.ExecuteNonQuery()

            conn.Close()
            Return RowCount

           

        Catch ex As Exception
            conn.Close()

            Return 0

        End Try




    End Function
    'max
    Public Function MaxAdmissionID()
        connectDB()
        Dim da As New SqlDataAdapter("MaxAdmissionID", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function
    Public Sub InsertGetInvestigationTest(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertGetInvestigationTest"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try

    End Sub


    Public Sub InsertGetAdvice(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertGetAdvice"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try

    End Sub
    Public Sub InsertAdvice_group_name(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertAdvice_group_name"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

 
    Public Function BlindInvestigation_group_name()
        connectDB()
        Dim da As New SqlDataAdapter("selectinvestigation_group_name", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function


    Public Function BlindDocId()
        connectDB()
        Dim da As New SqlDataAdapter("selectBlindDocId", conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function
    'get
    Public Function selectInvestigation_name(ByVal cmd) As DataTable
        Try



            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "selectInvestigation_name"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Function
    Public Function GetInvestigationNameByPId(ByVal investigation_group_id) As DataTable

        Dim SqlString As String = "select distinct investigation_name from dbo.GetInvestigationTest where investigation_group_id=" + investigation_group_id.ToString + " order by investigation_name"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function GetBed(ByVal Ward) As DataTable

        Dim SqlString As String = "select distinct Bed from dbo.wardbed where status='Available'and ward='" + Ward + "'"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function Advice_group_name() As DataTable
        connectDB()
        Dim SqlString As String = "select distinct Advice_group_name from   Advice_group_name  order by Advice_group_name"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    Public Function getadvice(ByVal advice) As DataTable

        Dim SqlString As String = "select distinct Advice from  getAdvice where getAdvice. Advice_group_id in(select Advice_group_id from dbo.Advice_group_name  where Advice_group_name.Advice_group_name='" + advice.ToString + "') order by getAdvice.advice"

        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function

    '-----------------
    Public Function InsertPatientRegistation(ByVal cmd) As Integer
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertPatientRegistation"

            conn.Open()
            RowCount = cmd.ExecuteNonQuery()
            conn.Close()
            Return RowCount
        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Function

    Public Function UpdatePatientRegistration(ByVal cmd) As Integer


        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "UpdatePatientRegistration"

            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try

    End Function


    Public Sub InsertInvestigation_group_name(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertInvestigation_group_name"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub


    Public Sub InsertAdmission(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertAdmission"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub DoctorRegistration(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertDoctorRegistration"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub InsertAdmissionDischarge(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertAdmissionDischarge"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub


    Public Sub InsertGetDiagnosis(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertGetDiagnosis"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub InsertGetWard(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertGetWard"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub
    Public Sub InsertComplaints(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertComplaints"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub


    Public Sub InsertPastHistory(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertPastHistory"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub InsertDrugHistory(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertDrugHistory"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub


    Public Sub InsertWardBed(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertWardBed"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub InsertMedicine(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertMedicine"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub
    Public Sub InsertLocalExam(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertLocalExam"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub InsertExamination(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertExamination"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub
    Public Sub InsertDiagnosis(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertDiagnosis"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub InsertInvestigationResult(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertInvestigationResult"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub
    Public Sub DischargeCertificate(ByVal cmd)
        Try
            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "DischargeCertificate"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub InsertPatientInvestigation(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertPatientInvestigation"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub InsertPatientAdvice(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertPatientAdvice"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub


    Public Sub InsertDoctorDept(ByVal cmd)
        Try

            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsertDoctorDept"

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Sub
    'Public Function getInformationBycondition(ByVal objModelPatiant, ByVal t) As DataTable
    '    If t = 1 Then

    '        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and status='Available'"
    '        Dim dt As New DataTable()
    '        da = New SqlDataAdapter(SqlString, conn)
    '        da.Fill(dt)
    '        Return dt

    '    ElseIf t = 2 Then
    '        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "'and status='Available'"

    '        Dim dt As New DataTable()
    '        da = New SqlDataAdapter(SqlString, conn)
    '        da.Fill(dt)
    '        Return dt
    '    ElseIf t = 3 Then
    '        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "'and " + objModelPatiant.condition_field3 + " =  '" + objModelPatiant.condition3.ToString + "'and status='Available'"

    '        Dim dt As New DataTable()
    '        da = New SqlDataAdapter(SqlString, conn)
    '        da.Fill(dt)
    '        Return dt
    '    ElseIf t = 4 Then 'like condition
    '        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + " like '" + objModelPatiant.condition.ToString + "%'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "' "
    '        Dim dt As New DataTable()
    '        da = New SqlDataAdapter(SqlString, conn)
    '        da.Fill(dt)
    '        Return dt

    '    ElseIf t = 5 Then

    '        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + "" ' where " + objModelPatiant.condition_field + " like '" + objModelPatiant.condition.ToString + "%'"
    '        Dim dt As New DataTable()
    '        da = New SqlDataAdapter(SqlString, conn)
    '        da.Fill(dt)
    '        Return dt
    '    End If

    'End Function
    Public Function getInformationBycondition(ByVal objModelPatiant, ByVal t) As DataTable
        If t = 1 Then

            Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "' "
            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)
            Return dt

        ElseIf t = 2 Then
            Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "' "

            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)
            Return dt
        ElseIf t = 3 Then
            Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + "= '" + objModelPatiant.condition.ToString + "'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "'and " + objModelPatiant.condition_field3 + " =  '" + objModelPatiant.condition3.ToString + "' "

            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)
            Return dt
        ElseIf t = 4 Then 'like condition
            Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where " + objModelPatiant.condition_field + " like '" + objModelPatiant.condition.ToString + "%'and " + objModelPatiant.condition_field2 + " =  '" + objModelPatiant.condition2.ToString + "' "
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
        End Try
    End Function


    Public Function UpdatePatientInvesStatus(ByVal cmd) As Integer
        Try



            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "UpdatePatientInvesStatus"

            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Function

    Public Function SelectPatientPendingInves(ByVal AdmissionId) As DataTable
        Try



            connectDB()
            Dim SqlString As String = " select sl_no, investigationName    from  dbo.PatientInvestigation where status='pending'and AdmissionID='" + AdmissionId + "' "
            Dim dt As New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            da.Fill(dt)
            Return dt


        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Function
    Public Function GetAllInformation(ByVal objModelPatiant) As DataTable
        connectDB()
        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " order by " + objModelPatiant.field_name + ""
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function updateBedStatus(ByVal bed) As Integer



        Try
            Dim insAdd As New SqlCommand("insAdd", conn)
            insAdd.CommandText = "update wardbed set status='Booked' where bed= '" + bed.ToString + "'"

            conn.Open()
            Dim l As Integer = insAdd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            conn.Close()
        End Try
    End Function
    Public Function updateBedStatusAvailable(ByVal bed) As Integer


        Try
            Dim insAdd As New SqlCommand("insAdd", conn)
            insAdd.CommandText = "update wardbed set status='Available' where bed= '" + bed.ToString + "'"

            conn.Open()
            Dim l As Integer = insAdd.ExecuteNonQuery()
            conn.Close()
            Return l
        Catch ex As Exception
            conn.Close()
        End Try

    End Function





    Public Function selectInvestigation_groupId(ByVal cmd) As DataTable
        Try



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
            MessageBox.Show("Error")
        End Try
    End Function


    Public Function selectPatientRegistationByMobileAndRegDate(ByVal cmd) As DataTable
        Try



            connectDB()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "selectPatientRegistationByMobileAndRegDate"
            da = New SqlDataAdapter(cmd)
            DT.Clear()
            da.Fill(DT)


            conn.Close()
            Return DT
        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error")
        End Try
    End Function
    Public Function deleteBYpid(ByVal objModelPatiant) As Integer
        Try


            Dim SqlString As String = "delete from " + objModelPatiant.tableName + "  where AdmissionID= '" + objModelPatiant.rows_serial.ToString + "'"

            Dim cmd As SqlCommand = New SqlCommand(SqlString, conn)


            '  Dim command As SqlCommand = New SqlCommand(SqlString, conn)
            conn.Open()
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            conn.Close()



        Catch ex As Exception
            conn.Close()

            Return 0

        End Try




    End Function


    Public Function SelectGetDate(ByVal ProcedureName)
        connectDB()
        Dim da As New SqlDataAdapter(ProcedureName, conn)
        Dim ds As New DataSet

        da.Fill(ds)
        Return ds

    End Function


    Public Function Get_Patient_Name_ID_From_Admission(ByVal objModelPatiant) As DataTable
        connectDB()
        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Admission_Info') drop view View_Admission_Info"
        queryEx(insAdd)
        'insAdd = "create view View_Admission_Info as select distinct AdmissionID, PatientId, AdmissionDate,  AdmissionUnder from Admission"
        insAdd = "create view View_Admission_Info as select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + ""
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_PatientInvestigation_Info') drop view View_PatientInvestigation_Info"
        queryEx(insAdd)
        insAdd = "create view View_PatientInvestigation_Info as select distinct " + objModelPatiant.field_name2 + " from " + objModelPatiant.tableName2 + ""
        queryEx(insAdd)
        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Admission_And_Investigation_Left_join') drop view View_Admission_And_Investigation_Left_join"
        queryEx(insAdd)
        insAdd = "create view View_Admission_And_Investigation_Left_join as select distinct View_Admission_Info.AdmissionDate,View_Admission_Info.AdmissionID,View_Admission_Info.PatientId,View_Admission_Info.AdmissionUnder,View_Admission_Info.AdmissionTime,View_Admission_Info.Word, View_Admission_Info.Bed,View_Admission_Info.EntryPerson,View_PatientInvestigation_Info.InvestigationDate,View_PatientInvestigation_Info.investigationName,View_PatientInvestigation_Info.status from View_Admission_Info left outer join View_PatientInvestigation_Info on View_PatientInvestigation_Info.AdmissionID=View_Admission_Info.AdmissionID where View_PatientInvestigation_Info.investigationName is not null"
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_PatientRegistation_Info') drop view View_PatientRegistation_Info"
        queryEx(insAdd)
        insAdd = "create view View_PatientRegistation_Info as select  " + objModelPatiant.field_name3 + " from " + objModelPatiant.tableName3 + ""
        queryEx(insAdd)


        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_All_Union') drop view View_All_Union"
        queryEx(insAdd)
        insAdd = "create view View_All_Union as select PatientId from View_PatientRegistation_Info union select PatientId from View_Admission_And_Investigation_Left_join"
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Admission_And_Investigation_And_Regi_Left_join') drop view View_Admission_And_Investigation_And_Regi_Left_join"
        queryEx(insAdd)
        insAdd = "create view View_Admission_And_Investigation_And_Regi_Left_join as select View_All_Union.PatientId,View_PatientRegistation_Info.Name, View_PatientRegistation_Info.RegDate, View_PatientRegistation_Info.Age, View_PatientRegistation_Info.Gender, View_PatientRegistation_Info.NID, View_PatientRegistation_Info.Mobile, View_PatientRegistation_Info.Religion, View_PatientRegistation_Info.Occupation, View_PatientRegistation_Info.FatherName, View_PatientRegistation_Info.Address, View_PatientRegistation_Info.Village, View_PatientRegistation_Info.Post, View_PatientRegistation_Info.Dis, View_PatientRegistation_Info.Division,View_PatientRegistation_Info.Image ,View_Admission_And_Investigation_Left_join.AdmissionDate,View_Admission_And_Investigation_Left_join.AdmissionID,View_Admission_And_Investigation_Left_join.AdmissionUnder,View_Admission_And_Investigation_Left_join.AdmissionTime,View_Admission_And_Investigation_Left_join.Word, View_Admission_And_Investigation_Left_join.Bed,View_Admission_And_Investigation_Left_join.EntryPerson,View_Admission_And_Investigation_Left_join.InvestigationDate,View_Admission_And_Investigation_Left_join.investigationName,View_Admission_And_Investigation_Left_join.status from View_All_Union left outer join View_Admission_And_Investigation_Left_join on View_All_Union.PatientId=View_Admission_And_Investigation_Left_join.PatientId left outer join View_PatientRegistation_Info on View_All_Union.PatientId=View_PatientRegistation_Info.PatientId where View_PatientRegistation_Info.RegDate is not null"
        queryEx(insAdd)



        Dim SqlString As String = "select  distinct Name,PatientId from  View_Admission_And_Investigation_And_Regi_Left_join where AdmissionID='" + objModelPatiant.AdmissionId + "'"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)
        Return dt
    End Function

    Public Function Show_Report(ByVal objModelPatiant) As DataTable
        connectDB()
        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Admission_Info') drop view View_Admission_Info"
        queryEx(insAdd)
        'insAdd = "create view View_Admission_Info as select distinct AdmissionID, PatientId, AdmissionDate,  AdmissionUnder from Admission"
        insAdd = "create view View_Admission_Info as select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + ""
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_PatientInvestigation_Info') drop view View_PatientInvestigation_Info"
        queryEx(insAdd)
        insAdd = "create view View_PatientInvestigation_Info as select distinct " + objModelPatiant.field_name2 + " from " + objModelPatiant.tableName2 + ""
        queryEx(insAdd)
        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Admission_And_Investigation_Left_join') drop view View_Admission_And_Investigation_Left_join"
        queryEx(insAdd)
        insAdd = "create view View_Admission_And_Investigation_Left_join as select distinct View_Admission_Info.AdmissionDate,View_Admission_Info.AdmissionID,View_Admission_Info.PatientId,View_Admission_Info.AdmissionUnder,View_Admission_Info.AdmissionTime,View_Admission_Info.Word, View_Admission_Info.Bed,View_Admission_Info.EntryPerson,View_PatientInvestigation_Info.InvestigationDate,View_PatientInvestigation_Info.investigationName,View_PatientInvestigation_Info.status from View_Admission_Info left outer join View_PatientInvestigation_Info on View_PatientInvestigation_Info.AdmissionID=View_Admission_Info.AdmissionID where View_PatientInvestigation_Info.investigationName is not null"
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_PatientRegistation_Info') drop view View_PatientRegistation_Info"
        queryEx(insAdd)
        insAdd = "create view View_PatientRegistation_Info as select  " + objModelPatiant.field_name3 + " from " + objModelPatiant.tableName3 + ""
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_All_Union') drop view View_All_Union"
        queryEx(insAdd)
        insAdd = "create view View_All_Union as select PatientId from View_PatientRegistation_Info union select PatientId from View_Admission_And_Investigation_Left_join"
        queryEx(insAdd)

        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Admission_And_Investigation_And_Regi_Left_join') drop view View_Admission_And_Investigation_And_Regi_Left_join"
        queryEx(insAdd)
        insAdd = "create view View_Admission_And_Investigation_And_Regi_Left_join as select View_All_Union.PatientId,View_PatientRegistation_Info.Name, View_PatientRegistation_Info.RegDate, View_PatientRegistation_Info.Age, View_PatientRegistation_Info.Gender, View_PatientRegistation_Info.NID, View_PatientRegistation_Info.Mobile, View_PatientRegistation_Info.Religion, View_PatientRegistation_Info.Occupation, View_PatientRegistation_Info.FatherName, View_PatientRegistation_Info.Address, View_PatientRegistation_Info.Village, View_PatientRegistation_Info.Post, View_PatientRegistation_Info.Dis, View_PatientRegistation_Info.Division,View_PatientRegistation_Info.Image ,View_Admission_And_Investigation_Left_join.AdmissionDate,View_Admission_And_Investigation_Left_join.AdmissionID,View_Admission_And_Investigation_Left_join.AdmissionUnder,View_Admission_And_Investigation_Left_join.AdmissionTime,View_Admission_And_Investigation_Left_join.Word, View_Admission_And_Investigation_Left_join.Bed,View_Admission_And_Investigation_Left_join.EntryPerson,View_Admission_And_Investigation_Left_join.InvestigationDate,View_Admission_And_Investigation_Left_join.investigationName,View_Admission_And_Investigation_Left_join.status from View_All_Union left outer join View_Admission_And_Investigation_Left_join on View_All_Union.PatientId=View_Admission_And_Investigation_Left_join.PatientId left outer join View_PatientRegistation_Info on View_All_Union.PatientId=View_PatientRegistation_Info.PatientId where View_PatientRegistation_Info.RegDate is not null"
        queryEx(insAdd)

    End Function


    'sumon------------------------
    Public Function Only_Patient_Registration_View(ByVal objModelPatiant) As DataTable
        connectDB()
        insAdd = "if exists(select table_name from information_schema.views" & " where table_name='View_Only_PatientRegistation_Info') drop view View_Only_PatientRegistation_Info"
        queryEx(insAdd)
        insAdd = "create view View_Only_PatientRegistation_Info as select  " + objModelPatiant.field_name3 + " from " + objModelPatiant.tableName3 + ""
        queryEx(insAdd)
    End Function

    Public Function Only_PatientId(ByVal objModelPatiant) As DataTable
        connectDB()

        Dim SqlString As String = "select  distinct " + objModelPatiant.field_name3 + " from  " + objModelPatiant.tableName3 + " order by PatientId"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)
        Return dt

    End Function

    'end sumon0000000000000000
    Public Function login(ByVal objModelPatiant) As DataTable

        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + " where UserName= '" + objModelPatiant.username.ToString + "' and UserPassword ='" + objModelPatiant.UserPassword.ToString + "'"
        Dim dt As New DataTable()
        da = New SqlDataAdapter(SqlString, conn)
        da.Fill(dt)

        Return dt
    End Function
    Public Function InsertData(ByVal cmd, ByVal ProcedureName) As Integer
        Try



            connectDB()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = ProcedureName

            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            'MessageBox.Show("Save Successfully ", "Save")
            conn.Close()
            Return i
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Function

    Public Function GetFromOwnTable(ByVal objModelPatiant)


        Dim SqlString As String = "select distinct " + objModelPatiant.field_name + " from " + objModelPatiant.tableName + "  "
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
            MessageBox.Show("Error")
        End Try
    End Function

    Public Function Delete(ByVal cmd, ByVal ProcedureName) As DataTable
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
            MessageBox.Show("Error")
        End Try
    End Function

End Class
