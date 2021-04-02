Imports System.Data.SqlClient
Public Class BuisnessLayer
    Dim dt As DataTable
    Dim datalayer As New DataAccwssLayerCls
    Dim cmd As New SqlCommand
    Public name As String = ""
    Public sl_no As Integer
    Public pathImage As String = ""
    Public Gender As String = ""
    Public NID As String = ""
    Public Mobile As String = ""
    Public Religion As String = ""
    Public Occupation As String = ""
    Public FatherName As String = ""
    Public Address As String = ""
    Public village As String = ""
    Public dis As String = ""
    Public division As String = ""
    Public EntryPerson As String = ""
    Public Post As String = ""
    Public PatientImage As Array
    Public Age As Double = 0.0

    Public investigation_group_id As String = ""
    Public InvestigationDate As Date
    Public PatientId As Integer = 0
    Public investigation_name As String = ""
    Public AdmissionDate As Date
    Public RegDate As Date
    Public AdmissionTime As String
    Public AdmissionUnder As String = ""

    Public Ward As String = ""

    Public Bed As String = ""

    Public AdmissionId As String = ""

    Public complain As String = ""
    Public since_duration As String = ""
    Public diagnosis As String = ""
    Public AdmissionDischargeDate As Date
    Public PastHistory As String = ""
    Public drugHistory As String = ""
    Dim m As New modelHMS
    Public temp, bloodPress, bloodPressLow, pulse, weight, other, Anaemia, jaundice, Oedema, dehydration As String
    Public ExamName, Value, Unit, Note As String
    Public LocalEXamDate As Date

    Public ExamDate, ResultDate, AdviceDate As Date
    Public Lab, Result As String
    Public docId, action, insideOutside, statas, bedfor, degree1, degree2, leftheader, rightheader As String
    Dim RowCount As Integer
    Public advice, Advice_group_name_catagory, Advice_group_id As String
    Public DoctorDept, Designation, investigation_group_name As String


    Dim objModelPatiant As New modelHMS

    Public Function SelectALLDoctorIdForGrid(ByVal modelHMSObj) As DataTable



        dt = datalayer.SelectALLDoctorIdForGrid(modelHMSObj)
        Return dt

    End Function
    Public Function deletegroupid(ByVal objModelPatiant) As Integer
        RowCount = datalayer.deletegroupid(objModelPatiant)
        Return RowCount
    End Function
    Public Function BlindPatientPatientRegistation()

        Return datalayer.BlindPatientPatientRegistation

    End Function

    Public Function selectGetWard()

        Return datalayer.selectGetWard

    End Function
    Public Function SelectPatientByAdmissionId()
        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.SelectPatientByAdmissionId()

    End Function

    Public Function SelectPatientByALLAdmission()
        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.SelectPatientByALLAdmission()

    End Function

    Public Function selectAdmission(ByVal modelHMSObj) As DataTable
        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.selectAdmission(modelHMSObj)

    End Function
    Public Function BlindInvestigation_group_name()

        Return datalayer.BlindInvestigation_group_name

    End Function

    Public Function InsertGetInvestigationTest()
        cmd.Parameters.AddWithValue("@investigation_group_id", investigation_group_id)
        cmd.Parameters.AddWithValue("@investigation_name", investigation_name)

        datalayer.InsertGetInvestigationTest(cmd)
        cmd.Parameters.Clear()
 
    End Function



    Public Function InsertGetAdvice()
        cmd.Parameters.AddWithValue("@Advice_group_id", Advice_group_id)
        cmd.Parameters.AddWithValue("@Advice", advice)

        datalayer.InsertGetAdvice(cmd)
        cmd.Parameters.Clear()

    End Function

    Public Function InsertAdvice_group_name()
        cmd.Parameters.AddWithValue("@Advice_group_name", Advice_group_name_catagory)
       
        datalayer.InsertAdvice_group_name(cmd)
        cmd.Parameters.Clear()

    End Function
    Public Function BlindDocId()

        Return datalayer.BlindDocId

    End Function

    Public Function MaxAdmissionID()

        Return datalayer.MaxAdmissionID()

    End Function
    Public Function GetInvestigationNameByPId(ByVal investigation_group_id) As DataTable
        dt = datalayer.GetInvestigationNameByPId(Me.investigation_group_id)
        Return dt

    End Function
    Public Function Advice_group_name() As DataTable
        dt = datalayer.Advice_group_name()
        Return dt

    End Function


    Public Function selectAdviceGroupHead() As DataTable
        dt = datalayer.selectAdviceGroupHead()
        Return dt

    End Function
    Public Function GetAdvice(ByVal Advice) As DataTable
        dt = datalayer.GetAdvice(Advice)
        Return dt

    End Function

    Public Function InsertPatientRegistation() As Integer

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Name", name)
        cmd.Parameters.AddWithValue("@RegDate", RegDate)
        cmd.Parameters.AddWithValue("@Age", Age)
        cmd.Parameters.AddWithValue("@Gender", Gender)
        cmd.Parameters.AddWithValue("@NID ", NID)
        cmd.Parameters.AddWithValue("@Mobile", Mobile)
        cmd.Parameters.AddWithValue("@Religion", Religion)
        cmd.Parameters.AddWithValue("@Occupation", Occupation)
        cmd.Parameters.AddWithValue("@FatherName", FatherName)

        cmd.Parameters.AddWithValue("@Address", Address)
        cmd.Parameters.AddWithValue("@village ", village)
        cmd.Parameters.AddWithValue("@post ", Post)

        cmd.Parameters.AddWithValue("@dis", dis)
        cmd.Parameters.AddWithValue("@division", division)
        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)
        cmd.Parameters.AddWithValue("@image", PatientImage)

        RowCount = datalayer.InsertPatientRegistation(cmd)

        cmd.Parameters.Clear()

        Return RowCount
    End Function

    Public Function UpdatePatientRegistration(ByVal buisnesslayerobject) As Integer
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@PatientId", PatientId)
        cmd.Parameters.AddWithValue("@Name", name)
        cmd.Parameters.AddWithValue("@RegDate", RegDate)
        cmd.Parameters.AddWithValue("@Age", Age)
        cmd.Parameters.AddWithValue("@Gender", Gender)
        cmd.Parameters.AddWithValue("@NID ", NID)
        cmd.Parameters.AddWithValue("@Mobile", Mobile)
        cmd.Parameters.AddWithValue("@Religion", Religion)
        cmd.Parameters.AddWithValue("@Occupation", Occupation)
        cmd.Parameters.AddWithValue("@FatherName", FatherName)

        cmd.Parameters.AddWithValue("@Address", Address)
        cmd.Parameters.AddWithValue("@village ", village)
        cmd.Parameters.AddWithValue("@post ", Post)

        cmd.Parameters.AddWithValue("@dis", dis)
        cmd.Parameters.AddWithValue("@division", division)
        ''cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)
        ''cmd.Parameters.AddWithValue("@image", PatientImage)

        RowCount = datalayer.UpdatePatientRegistration(cmd)
        cmd.Parameters.Clear()
        Return RowCount

    End Function

     Public Sub InsertInvestigation_group_name()



        cmd.Parameters.AddWithValue("@investigation_group_name", investigation_group_name)

        datalayer.InsertInvestigation_group_name(cmd)
        cmd.Parameters.Clear()


    End Sub

    Public Sub InsertAdmission()


        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@PatientId", PatientId)
        cmd.Parameters.AddWithValue("@AdmissionDate", AdmissionDate)
        cmd.Parameters.AddWithValue("@AdmissionTime", AdmissionTime)

        cmd.Parameters.AddWithValue("@AdmissionUnder ", AdmissionUnder)
        cmd.Parameters.AddWithValue("@Word", Ward)
        cmd.Parameters.AddWithValue("@Bed", Bed)
        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertAdmission(cmd)
        cmd.Parameters.Clear()


    End Sub
    Public Function GetBed() As DataTable
        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.GetBed(Ward)

    End Function
    Public Sub DoctorRegistration()
        cmd.Parameters.AddWithValue("@DoctorName", name)
        cmd.Parameters.AddWithValue("@DoctorDept", DoctorDept)
        cmd.Parameters.AddWithValue("@Mobile", Mobile)
        cmd.Parameters.AddWithValue("@Designation", Designation)

        cmd.Parameters.AddWithValue("@status", statas)
        cmd.Parameters.AddWithValue("@Degree1", degree1)
        cmd.Parameters.AddWithValue("@Degree2", degree2)
        cmd.Parameters.AddWithValue("@LeftHeader", leftheader)
        cmd.Parameters.AddWithValue("@RightHeader", rightheader)
        datalayer.DoctorRegistration(cmd)
        cmd.Parameters.Clear()
    End Sub

    Public Function selectDiagnosis() As DataTable
        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.selectDiagnosis()

    End Function
    Public Sub InsertAdmissionDischarge()


        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@AdmissionDischargeDate", AdmissionDischargeDate)

        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertAdmissionDischarge(cmd)
        cmd.Parameters.Clear()


    End Sub
    Public Sub UpdatePatientInvesStatus()
        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@sl_no", sl_no)


        datalayer.UpdatePatientInvesStatus(cmd)
        cmd.Parameters.Clear()
    End Sub
    Public Sub InsertGetDiagnosis()


        cmd.Parameters.AddWithValue("@diagnosis", diagnosis)


        datalayer.InsertGetDiagnosis(cmd)
        cmd.Parameters.Clear()


    End Sub


    Public Sub InsertGetWard()


        cmd.Parameters.AddWithValue("@ward", Ward)


        datalayer.InsertGetWard(cmd)
        cmd.Parameters.Clear()


    End Sub


    Public Sub InsertComplaints()


 

        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@complain", complain)
         cmd.Parameters.AddWithValue("@since_duration", since_duration)
          cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertComplaints(cmd)
        cmd.Parameters.Clear()


    End Sub

    Public Function SelectComplainForGrid(ByVal modelHMSObj) As DataTable



        dt = datalayer.SelectComplainForGrid(modelHMSObj)
        Return dt

    End Function

    Public Function SelectByPatientIdForGrid(ByVal modelHMSObj) As DataTable



        dt = datalayer.SelectByPatientIdForGrid(modelHMSObj)
        Return dt

    End Function

    Public Function SelectALLPatientIdForGrid(ByVal modelHMSObj) As DataTable



        dt = datalayer.SelectALLPatientIdForGrid(modelHMSObj)
        Return dt

    End Function
    Public Function delete(ByVal objModelPatiant) As Integer
        RowCount = datalayer.delete(objModelPatiant)
        Return RowCount
    End Function

    Public Sub InsertInvestigationResult()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@investigationName", investigation_name)
        cmd.Parameters.AddWithValue("@ResultDate", ResultDate)

        cmd.Parameters.AddWithValue("@Lab", Lab)
        cmd.Parameters.AddWithValue("@Result", Result)
        cmd.Parameters.AddWithValue("@unit", Unit)

        cmd.Parameters.AddWithValue("@note", Note)

        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertInvestigationResult(cmd)
        cmd.Parameters.Clear()


    End Sub


    Public Sub InsertWardBed()




        cmd.Parameters.AddWithValue("@Ward", Ward)
        cmd.Parameters.AddWithValue("@insideOutside", insideOutside)
        cmd.Parameters.AddWithValue("@MaleorFemale", bedfor)

        cmd.Parameters.AddWithValue("@status", statas)
        cmd.Parameters.AddWithValue("@bed", Bed)

        datalayer.InsertWardBed(cmd)
        cmd.Parameters.Clear()


    End Sub

    Public Sub InsertPastHistory()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@Past_history", PastHistory)
        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertPastHistory(cmd)
        cmd.Parameters.Clear()


    End Sub

    Public Sub InsertDrugHistory()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@drugHistory", drugHistory)
        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertDrugHistory(cmd)
        cmd.Parameters.Clear()


    End Sub

    Public Sub InsertLocalExam()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@ExamName", ExamName)
        cmd.Parameters.AddWithValue("@LocalEXamDate", LocalEXamDate)

        cmd.Parameters.AddWithValue("@Value", Value)
        cmd.Parameters.AddWithValue("@Unit", Unit)

        cmd.Parameters.AddWithValue("@Note", Note)


        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)



        datalayer.InsertLocalExam(cmd)
        cmd.Parameters.Clear()


    End Sub


    Public Sub InsertExamination()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@ExamDate", ExamDate)
        cmd.Parameters.AddWithValue("@temp", temp)

        cmd.Parameters.AddWithValue("@bloodPress", bloodPress)

        cmd.Parameters.AddWithValue("@bloodPressLow", bloodPressLow)

        cmd.Parameters.AddWithValue("@pulse", pulse)
        cmd.Parameters.AddWithValue("@weight", weight)
        cmd.Parameters.AddWithValue("@other", other)

        cmd.Parameters.AddWithValue("@Anaemia", Anaemia)
        cmd.Parameters.AddWithValue("@jaundice", jaundice)
        cmd.Parameters.AddWithValue("@Oedema", Oedema)
        cmd.Parameters.AddWithValue("@dehydration", dehydration)
        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)



        datalayer.InsertExamination(cmd)
        cmd.Parameters.Clear()


    End Sub

    Public Sub InsertDiagnosis()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@Diagnosis", diagnosis)
        cmd.Parameters.AddWithValue("@EntryPerson", EntryPerson)

        datalayer.InsertDiagnosis(cmd)
        cmd.Parameters.Clear()


    End Sub


    Public Sub DischargeCertificate()




        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)

        datalayer.DischargeCertificate(cmd)
        cmd.Parameters.Clear()


    End Sub



    Public Sub InsertPatientInvestigation()


        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@InvestigationDate", InvestigationDate)
        cmd.Parameters.AddWithValue("@investigationName", investigation_name)
        cmd.Parameters.AddWithValue("@EntryPerson ", EntryPerson)

        datalayer.InsertPatientInvestigation(cmd)
        cmd.Parameters.Clear()


    End Sub



    Public Sub InsertPatientAdvice()


        cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)
        cmd.Parameters.AddWithValue("@AdviceDate", AdviceDate)
        cmd.Parameters.AddWithValue("@advice", advice)
        cmd.Parameters.AddWithValue("@EntryPerson ", EntryPerson)

        datalayer.InsertPatientAdvice(cmd)
        cmd.Parameters.Clear()


    End Sub
    Public Sub InsertDoctorDept()


        cmd.Parameters.AddWithValue("@docId", docId)
        cmd.Parameters.AddWithValue("@action", action)


        datalayer.InsertDoctorDept(cmd)
        cmd.Parameters.Clear()


    End Sub
    Public Function getInformationBycondition(ByVal objModelPatiant, ByVal a) As DataTable
        dt = datalayer.getInformationBycondition(objModelPatiant, a)
        Return dt
    End Function

    Public Function InsertGetMedicine(ByVal objModelPatiant) As Integer
        RowCount = datalayer.InsertGetMedicine(objModelPatiant)
        Return RowCount
    End Function

    Public Sub InsertMedicine(ByVal objModelPatiant)

        cmd.Parameters.AddWithValue("@AdmissionID", objModelPatiant.AdmissionId)
        cmd.Parameters.AddWithValue("@medicine_doses", objModelPatiant.dosageName)
        cmd.Parameters.AddWithValue("@medicine_name", objModelPatiant.medicine_name)
        cmd.Parameters.AddWithValue("@strength", objModelPatiant.strength)
        cmd.Parameters.AddWithValue("@medicine_feeding_rules", objModelPatiant.medicine_feeding_rules)

        cmd.Parameters.AddWithValue("@medicine_period", objModelPatiant.medicine_period)

        cmd.Parameters.AddWithValue("@Date", objModelPatiant.date_of_medicine)
        cmd.Parameters.AddWithValue("@EntryPerson", objModelPatiant.EntryPerson)



        datalayer.InsertMedicine(cmd)
        cmd.Parameters.Clear()


    End Sub
    Public Function SelectPatientPendingInves() As DataTable
        'cmd.Parameters.AddWithValue("@AdmissionID", AdmissionId)

        dt = datalayer.SelectPatientPendingInves(AdmissionId)
        Return dt
    End Function
    Public Function GetAllInformation(ByVal objModelPatiant) As DataTable
        dt = datalayer.GetAllInformation(objModelPatiant)
        Return dt
    End Function
    Public Function updateBedStatus() As Integer
        datalayer.updateBedStatus(Bed)
        Return RowCount
    End Function


    Public Function updateBedStatusAvailable() As Integer
        datalayer.updateBedStatusAvailable(Bed)
        Return RowCount
    End Function
    Public Function selectInvestigation_groupId(ByVal cm) As DataTable
        cmd.Parameters.AddWithValue("@investigation_group_name", investigation_group_name)

        dt = datalayer.selectInvestigation_groupId(cmd)
        cmd.Parameters.Clear()
        Return dt
    End Function
    Public Function Show_Report(ByVal objModelPatiant) As DataTable
        dt = datalayer.Show_Report(objModelPatiant)
        Return dt
    End Function
    Public Function SelectGetDate(ByVal ProcedureName)
        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.SelectGetDate(ProcedureName)

    End Function

    Public Function selectPatientRegistationByMobileAndRegDate(ByVal obj) As DataTable
        cmd.Parameters.AddWithValue("@RegDate", RegDate.ToString)
        cmd.Parameters.AddWithValue("@Mobile", Mobile)


        'cmd.Parameters.AddWithValue("@AdmissionId", m.AdmissionId)

        Return datalayer.selectPatientRegistationByMobileAndRegDate(cmd)
        cmd.Parameters.Clear()
    End Function
    Public Function Get_Patient_Name_ID_From_Admission(ByVal objModelPatiant) As DataTable
        dt = datalayer.Get_Patient_Name_ID_From_Admission(objModelPatiant)
        Return dt
    End Function
    Public Function deleteBYpid(ByVal objModelPatiant) As Integer
        datalayer.deleteBYpid(objModelPatiant)
        Return RowCount
    End Function

    'sumon --------------------
    Public Function Only_Patient_Registration_View(ByVal objModelPatiant) As DataTable
        dt = datalayer.Only_Patient_Registration_View(objModelPatiant)
        Return dt
    End Function
    Public Function Only_PatientId(ByVal objModelPatiant) As DataTable
        dt = datalayer.Only_PatientId(objModelPatiant)
        Return dt
    End Function
    'end  sumon---------------

    Public Function Login(ByVal objModelPatiant) As DataTable
        dt = datalayer.login(objModelPatiant)
        Return dt
    End Function

End Class
