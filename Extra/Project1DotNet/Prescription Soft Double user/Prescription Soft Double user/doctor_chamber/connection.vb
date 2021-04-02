Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Module connection
    Public readymadeprescription As Integer
    Public loadprescription As Integer

    Public conn As New SqlConnection
    Public da As New SqlDataAdapter

    Public DT As New DataTable
    Dim dtable As New DataTable

    Public fromPres As Integer = 0
    Public fromEdit As Integer = 0
    Public ForPrescription As Integer = 0
    Public ForRedymade As Integer = 0

    Public EditForRedymade As Integer = 0
    ' ''Public Sub pass()
    '    frmlogin.ShowDialog()
    'End Sub

    Public Sub connectDB()
        Dim NTL_payroll_con As String = ConfigurationManager.ConnectionStrings("Paroll_HRM_Connection").ConnectionString
        conn = New SqlConnection(NTL_payroll_con)
        'conn = New SqlConnection("user id=sa;password=noboit;initial catalog=Payroll_HRM;data source=noboit")
        'conn = New SqlConnection("initial catalog=Payroll_HRM;data source=ERP-1\SQLEXPRESS; integrated security=yes")

    End Sub

    Public Sub queryEx(ByVal insAdd As String)
        Try

        
            Dim INS As New SqlCommand("INS", conn)
            ' Dim rowcount As Integer
            conn.Open()
            INS.CommandText = insAdd
            INS.CommandTimeout = 0
            INS.ExecuteNonQuery()
            INS.CommandTimeout = 0
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function dt_Execute(ByVal SqlString As String) As DataTable
        Try
            conn.Open()
            ''Dim sql As String = "select order_no from order_sheet Where complet_running='" + run_order + "'order by order_no ASC "

            dtable = New DataTable()
            da = New SqlDataAdapter(SqlString, conn)
            'da.SelectCommand .
            da.SelectCommand.CommandTimeout = 0
            da.Fill(dtable)
            da.SelectCommand.CommandTimeout = 0
            conn.Close()
            Return dtable

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function


    'Public Function dt_CheckUserMenuPermission(ByVal strUserId As String, ByVal strMenuName As String) As DataTable

    '    conn.Open()
    '    Dim SqlString As String = "SELECT     UserInfo.UserId, UserInfo.UserName, UserPermissionInfo.UserAccessId, UserPermissionInfo.User_SLNo, UserPermissionInfo.FormAccess, " + _
    '                                    "UserPermissionInfo.UpdateAccess, UserPermissionInfo.DeleteAccess, MenuInfo.MenuName, MenuInfo.MenuType " + _
    '                        "FROM         UserPermissionInfo INNER JOIN " + _
    '                                              "UserInfo ON UserPermissionInfo.User_SLNo = UserInfo.SL_No INNER JOIN " + _
    '                                              "MenuInfo ON UserPermissionInfo.MenuId = MenuInfo.MenuId " + _
    '                        "where UserInfo.UserId='" + strUserId + "' and MenuInfo.MenuName='" + strMenuName + "' and UserPermissionInfo.FormAccess='1'"

    '    dtable = New DataTable()
    '    da = New SqlDataAdapter(SqlString, conn)
    '    da.Fill(dtable)
    '    conn.Close()
    '    Return dtable

    'End Function

    'Public Function dt_CheckUpdatePermission(ByVal strUserId As String, ByVal strMenuName As String) As DataTable

    '    conn.Open()
    '    Dim SqlString As String = "SELECT     UserInfo.UserId, UserInfo.UserName, UserPermissionInfo.UserAccessId, UserPermissionInfo.User_SLNo, UserPermissionInfo.FormAccess, " + _
    '                                    "UserPermissionInfo.UpdateAccess, UserPermissionInfo.DeleteAccess, MenuInfo.MenuName, MenuInfo.MenuType " + _
    '                            "FROM         UserPermissionInfo INNER JOIN " + _
    '                                                  "UserInfo ON UserPermissionInfo.User_SLNo = UserInfo.SL_No INNER JOIN " + _
    '                                                  "MenuInfo ON UserPermissionInfo.MenuId = MenuInfo.MenuId " + _
    '                            "where UserInfo.UserId='" + strUserId + "' and MenuInfo.MenuName='" + strMenuName + "' and UserPermissionInfo.UpdateAccess='1'"

    '    dtable = New DataTable()
    '    da = New SqlDataAdapter(SqlString, conn)
    '    da.Fill(dtable)
    '    conn.Close()
    '    Return dtable

    'End Function

    'Public Function dt_CheckDeletePermission(ByVal strUserId As String, ByVal strMenuName As String) As DataTable

    '    conn.Open()
    '    Dim SqlString As String = "SELECT     UserInfo.UserId, UserInfo.UserName, UserPermissionInfo.UserAccessId, UserPermissionInfo.User_SLNo, UserPermissionInfo.FormAccess, " + _
    '                                    "UserPermissionInfo.UpdateAccess, UserPermissionInfo.DeleteAccess, MenuInfo.MenuName, MenuInfo.MenuType " + _
    '                            "FROM         UserPermissionInfo INNER JOIN " + _
    '                                                  "UserInfo ON UserPermissionInfo.User_SLNo = UserInfo.SL_No INNER JOIN " + _
    '                                                  "MenuInfo ON UserPermissionInfo.MenuId = MenuInfo.MenuId " + _
    '                            "where UserInfo.UserId='" + strUserId + "' and MenuInfo.MenuName='" + strMenuName + "' and UserPermissionInfo.DeleteAccess='1'"

    '    dtable = New DataTable()
    '    da = New SqlDataAdapter(SqlString, conn)
    '    da.Fill(dtable)
    '    conn.Close()
    '    Return dtable

    'End Function
    'Public Sub ins_status_user(ByVal strUserId As String, ByVal strDate As String, ByVal strTime As String, ByVal strSections As String, ByVal strStatus As String, ByVal strLocation As String, ByVal strPc_name As String)
    '    insAdd = "Insert into dbo.user_status_log(user_name, C_Date, C_time, sections, status, location, pc_name) " & "values('" + strUserId + "','" + strDate + "','" + strTime + "','" + strSections + "','" + strStatus + "','" + strLocation + "','" + strPc_name + "')"
    '    queryEx(insAdd)

    'End Sub


    'Public Sub admin_rept()
    '    If fl4 = 1 Then
    '        If fl2 = 0 Or f = 0 Then
    '            If MessageBox.Show("Again Login as Administrator", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
    '                ed_del = 1
    '                Call pass()

    '                If inq = 1 Then
    '                    inq = 0
    '                    'frmquery_by_order_no.ShowDialog()
    '                End If

    '                If qty = 1 Then
    '                    qty = 0
    '                    'frmquery_by_order_no.ShowDialog()
    '                End If

    '                'If cost = 1 Then
    '                '    cost = 0
    '                '    'frmquery_by_order_no.ShowDialog()
    '                'End If
    '            End If
    '        End If
    '    Else
    '        If MessageBox.Show("Login as Administrator", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
    '            ed_del = 1
    '            Call pass()

    '            If inq = 1 Then

    '                'frmquery_by_order_no.ShowDialog()
    '                inq = 0

    '            End If

    '            If qty = 1 Then

    '                'frmquery_by_order_no.ShowDialog()
    '                qty = 0
    '            End If
    '        End If
    '    End If

    'End Sub

    'Public Sub admin()
    '    If fl4 = 1 Then
    '        If fl2 = 0 Or f = 0 Then
    '            If MessageBox.Show("Again Login as Administrator", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
    '                ed_del = 1
    '                Call pass()

    '                If inq = 1 Then
    '                    'inq = 0
    '                    frmholiday_gen.ShowDialog()
    '                End If

    '                If qty = 1 Then
    '                    'qty = 0
    '                    'frmquotation.ShowDialog()
    '                End If

    '                'If cost = 1 Then
    '                '    'cost = 0
    '                '    'Dim frmcost_rep As New frmquery_by_order_no()
    '                '    'frmcost_rep.Text = "Query by Qtn Id."
    '                '    'frmcost_rep.ShowDialog()
    '                'End If

    '                'If buyer_inq_qtn_order = 1 Then
    '                '    'qty = 0
    '                '    'frmyarn_store_rep.ShowDialog()
    '                'End If

    '            End If
    '        End If
    '    Else
    '        If MessageBox.Show("Login as Administrator", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
    '            ed_del = 1
    '            Call pass()

    '            If inq = 1 Then
    '                'frmInquiry_entry.ShowDialog()
    '                'inq = 0
    '                frmholiday_gen.ShowDialog()
    '            End If

    '            If qty = 1 Then
    '                'frmquotation.ShowDialog()
    '                'qty = 0
    '            End If

    '            'If cost = 1 Then
    '            '    'cost = 0
    '            '    'Dim frmcost_rep As New frmquery_by_order_no()
    '            '    'frmcost_rep.Text = "Query by Qtn Id."
    '            '    'frmcost_rep.ShowDialog()
    '            'End If

    '            'If buyer_inq_qtn_order = 1 Then
    '            '    'qty = 0
    '            '    'frmyarn_store_rep.ShowDialog()
    '            'End If

    '        End If
    '    End If
    'End Sub

    'Public Sub info_login()
    '    cn = My.Computer.Name
    '    dt = Format(Now, "MM / dd / yy")
    '    dt_t = Format(Now, "hh:mm:ss - tt")
    '    dsc = "Login"

    '    If ed_del = 1 Then
    '        dsc = ""
    '        ed_del = 0
    '    Else
    '        xx = 1
    '    End If

    '    If fl2 = 1 Then
    '        end_us = "End User"
    '        If xx = 1 Then
    '            xx1 = "End User"
    '            xx = 0
    '        End If
    '    End If

    '    If f = 1 Then
    '        super = "Supervisor"
    '        If xx = 1 Then
    '            xx1 = "Supervisor"
    '            xx = 0
    '        End If
    '    End If
    '    If fl4 = 1 Then
    '        admi = "Administrator"
    '        If xx = 1 Then
    '            xx1 = "Administrator"
    '            xx = 0
    '        End If
    '    End If


    '    Try


    '        If fl2 = 1 Then
    '            Dim insAdd As New SqlCommand("insAdd", conn)
    '            insAdd.CommandText = "insert into log (user_name,date,dsc,time,login_out_as) " & "values('" + cn + "','" + dt + "','" + dsc + "','" + dt_t + "','" + end_us + "')"
    '            conn.Open()
    '            insAdd.ExecuteNonQuery()
    '            conn.Close()
    '        End If

    '        If f = 1 Then
    '            Dim insAdd As New SqlCommand("insAdd", conn)
    '            insAdd.CommandText = "insert into log (user_name,date,dsc,time,login_out_as) " & "values('" + cn + "','" + dt + "','" + dsc + "','" + dt_t + "','" + super + "')"
    '            conn.Open()
    '            insAdd.ExecuteNonQuery()
    '            conn.Close()
    '        End If
    '        If fl4 = 1 Then
    '            Dim insAdd As New SqlCommand("insAdd", conn)
    '            insAdd.CommandText = "insert into log (user_name,date,dsc,time,login_out_as) " & "values('" + cn + "','" + dt + "','" + dsc + "','" + dt_t + "','" + admi + "')"
    '            conn.Open()
    '            insAdd.ExecuteNonQuery()
    '            conn.Close()
    '        End If


    '    Catch ex As Exception

    '        frmfail.ShowDialog()
    '    End Try
    'End Sub
    'Public Sub info_logout()
    '    cn = My.Computer.Name
    '    dt = Format(Now, "MM / dd / yy")

    '    dt_t = Format(Now, "hh:mm:ss - tt")
    '    dsc = "LogOut"

    '    Try
    '        Dim insAdd As New SqlCommand("insAdd", conn)
    '        insAdd.CommandText = "insert into log (user_name,date,dsc,time,login_out_as) " & "values('" + cn + "','" + dt + "','" + dsc + "','" + dt_t + "','" + xx1 + "')"
    '        conn.Open()
    '        insAdd.ExecuteNonQuery()
    '        conn.Close()

    '        Dim insAdd2 As New SqlCommand("insAdd2", conn)
    '        insAdd2.CommandText = "Insert into dbo.user_status_log(user_name, C_Date, C_time, sections, status, location, pc_name) " & "values('" + UserName + "','" + dt + "','" + dt_t + "','','logout','logout','" + cn + "')"
    '        conn.Open()
    '        insAdd2.ExecuteNonQuery()
    '        conn.Close()
    '    Catch ex As Exception
    '        frmfail.ShowDialog()
    '    End Try
    'End Sub
End Module
