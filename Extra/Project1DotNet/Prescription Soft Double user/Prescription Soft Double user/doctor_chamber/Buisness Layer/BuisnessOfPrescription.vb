Imports System.Data.SqlClient
Public Class BuisnessOfPrescription
    Dim objDataLayer As New DataOfPrescription
    Dim dt As DataTable
    Dim RowCount As Integer
    Dim cmd As New SqlCommand
    'Dim maxPId As Integer
    Public investigation_group_name, investigation_group_id As String
    Public Function GetAllInformation(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.GetAllInformation(objModelPatiant)
        Return dt
    End Function

    Public Function Getmedicine(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.Getmedicine(objModelPatiant)
        Return dt
    End Function

    Public Function GetChecklistValue(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.GetChecklistValue(objModelPatiant)
        Return dt
    End Function
    Public Function GetAdvice(ByVal Advice) As DataTable
        dt = objDataLayer.getadvice(Advice)
        Return dt

    End Function
    Public Function GetfeedingRulse(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.GetfeedingRulse(objModelPatiant)
        Return dt
    End Function
    Public Function GetAllInformation_status_notseen(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.GetAllInformation_status_notseen(objModelPatiant)
        Return dt
    End Function
    Public Function p_id_Generator(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.p_id_Generator(objModelPatiant)
        Return dt
    End Function
    Public Function R_id_Generator() As Integer
        Dim i As Integer
        i = objDataLayer.R_id_Generator()

        Return i


    End Function

    Public Function p_VisitTime_Generator(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.p_VisitTime_Generator(objModelPatiant)
        Return dt
    End Function

    Public Function getPatient_InfoByPatientID(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.getPatient_InfoByPatientID(objModelPatiant)
        Return dt
    End Function


    Public Function getmaxpVisite(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.getmaxpVisite(objModelPatiant)
        Return dt
    End Function
    Public Function getPatientReadymade_InfoByRID(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.getPatientReadymade_InfoByRID(objModelPatiant)
        Return dt
    End Function
    Public Function getPatientComplainByIdandVisit(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.getPatientComplainByIdandVisit(objModelPatiant)
        Return dt
    End Function

    Public Function InsertPatient_information(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertPatient_information(objModelPatiant)
        Return RowCount
    End Function


    Public Function InsertdrugHistory(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertdrugHistory(objModelPatiant)
        Return RowCount
    End Function
    Public Function deleteBYpid(ByVal objModelPatiant) As Integer
        objDataLayer.deleteBYpid(objModelPatiant)
        Return RowCount
    End Function
    Public Function InsertInsertreferral_by(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertInsertreferral_by(objModelPatiant)
        Return RowCount
    End Function
    Public Function Insertotehrfindings(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.Insertotehrfindings(objModelPatiant)
        Return RowCount
    End Function

    Public Function getInformationBycondition(ByVal objModelPatiant, ByVal a) As DataTable
        dt = objDataLayer.getInformationBycondition(objModelPatiant, a)
        Return dt
    End Function

    Public Function show_Patient_info(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.show_Patient_info(objModelPatiant)
        Return dt
    End Function

    Public Function InsertExamination(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertExamination(objModelPatiant)
        Return RowCount
    End Function


    Public Function InsertMedicine(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertMedicine(objModelPatiant)
        Return RowCount
    End Function

    Public Function InsertReadymadeMedicine(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertReadymadeMedicine(objModelPatiant)
        Return RowCount
    End Function
    Public Function InsertGetMedicine(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertGetMedicine(objModelPatiant)
        Return RowCount
    End Function
    Public Function InsertPatient_Visit(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertPatient_Visit(objModelPatiant)
        Return RowCount
    End Function


    Public Function InsertDiagnsis(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertDiagnsis(objModelPatiant)
        Return RowCount
    End Function

    Public Function InsertTreatment(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertTreatment(objModelPatiant)
        Return RowCount
    End Function

    Public Function InsertComplaints(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertComplaints(objModelPatiant)
        Return RowCount
    End Function
    Public Function InsertInvestigationTest(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertInvestigationTest(objModelPatiant)
        Return RowCount
    End Function

    Public Function InsertPastHistory(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertPastHistory(objModelPatiant)
        Return RowCount
    End Function


    Public Function InsertAbdomenLump(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertAbdomenLump(objModelPatiant)
        Return RowCount
    End Function

    Public Function InsertAdvice(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertAdvice(objModelPatiant)
        Return RowCount
    End Function

    Public Function InsertNextVisit(ByVal objModelPatiant) As Integer
        RowCount = objDataLayer.InsertNextVisit(objModelPatiant)
        Return RowCount
    End Function
    '===========



    Public Function InsertIntoReadymadeTable(ByVal objModelPatiant) As Integer

        RowCount = objDataLayer.InsertIntoReadymadeTable(objModelPatiant)
        Return RowCount
    End Function



    Public Function InsertIntoGetTable(ByVal objModelPatiant) As Boolean
        Dim isinsert As Boolean
        isinsert = objDataLayer.InsertIntoGetTable(objModelPatiant)
        Return isinsert
    End Function
    Public Function getPatient_TestReports(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.getPatient_TestReports(objModelPatiant)
        Return dt
    End Function

    '===========query=
    Public Function GetAllVisitByPId(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.GetAllVisitByPId(objModelPatiant)
        Return dt
    End Function


    Public Function Login(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.login(objModelPatiant)
        Return dt
    End Function

    Public Function GetInfoByVisiteandId(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.GetInfoByVisiteandId(objModelPatiant)
        Return dt
    End Function

    Public Function Update(ByVal objModelPatiant) As Integer
        objDataLayer.update(objModelPatiant)

    End Function


    Public Function update_medicine(ByVal objModelPatiant) As Integer
        objDataLayer.update_medicine(objModelPatiant)

    End Function

    Public Function Update_complaints(ByVal objModelPatiant) As Integer
        objDataLayer.Update_complaints(objModelPatiant)

    End Function
    Public Function Update_patient_Visit_status(ByVal objModelPatiant) As Integer
        objDataLayer.Update_patient_Visit_status(objModelPatiant)

    End Function
    Public Function delete(ByVal objModelPatiant) As Integer
        objDataLayer.delete(objModelPatiant)
        Return RowCount
    End Function

    Public Function deleteBYRid(ByVal objModelPatiant) As Integer
        objDataLayer.deleteBYRid(objModelPatiant)
        Return RowCount
    End Function
    Public Function getPatient_TestReports_Edit(ByVal objModelPatiant) As Integer
        Dim i As Integer = objDataLayer.getPatient_TestReports_Edit(objModelPatiant)
        Return i
    End Function

    Public Function getPatient_TestReports_whereCondition(ByVal objModelPatiant) As DataTable
        dt = objDataLayer.getPatient_TestReports_whereCondition(objModelPatiant)
        Return dt
    End Function
    Public Function backup()
        objDataLayer.backup()
        Return 1
    End Function


    Public Function Advice_group_name() As DataTable
        dt = objDataLayer.Advice_group_name()
        Return dt

    End Function

    Public Function selectInvestigation_groupId(ByVal cm) As DataTable
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@investigation_group_name", investigation_group_name)

        dt = objDataLayer.selectInvestigation_groupId(cmd)
        cmd.Parameters.Clear()
        Return dt
    End Function
    Public Function BlindInvestigation_group_name() As DataTable

        Return objDataLayer.BlindInvestigation_group_name

    End Function
    Public Function GetInvestigationNameByPId(ByVal investigation_group_id) As DataTable
        dt = objDataLayer.GetInvestigationNameByPId(Me.investigation_group_id)
        Return dt

    End Function


End Class
