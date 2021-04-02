

Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class add_advice
    Dim buisnesslayerobject As New BuisnessLayer

    Dim modelHMSObj As New modelHMS
    Dim dt As DataTable
    Dim RowCount As Integer
    Dim cmd As New SqlCommand
    'Dim RowCount As Integer
    Private Sub add_advice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectAdviceName()
        SelectQuereyForGrid(" sl_no, Advice_group_id'Advice Group Id' , Advice ", "dbo.GetAdvice", DataGridView1)
        orderby()
    End Sub
    Public Sub selectAdviceName()
        Try


            Dim dt As DataTable
            Advice_group_id_lab.DataBindings.Clear()
            dt = (buisnesslayerobject.selectAdviceGroupHead())
            'Advice_group_id_lab.DataBindings.Add("text", dt, "Advice_group_id")


            Advice_group_headCmb.ValueMember = "Advice_group_name"
            Advice_group_headCmb.DisplayMember = "Advice_group_name"

            Advice_group_headCmb.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message)

        End Try
    End Sub




    Public Sub InsertGetAdvice()
        buisnesslayerobject.Advice_group_id = Advice_group_id_lab.Text
        buisnesslayerobject.advice = AdviceTxt.Text
        buisnesslayerobject.InsertGetAdvice()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        InsertGetAdvice()
        AdviceTxt.Text = ""
        AdviceTxt.Focus()

        SelectQuereyForGrid("sl_no,  Advice_group_id'Advice Group Id' , Advice ", "dbo.GetAdvice", DataGridView1)
        orderby()
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Advice_group_id", Advice_group_id_lab.Text)

        dt = (datalayer.BlindGrid(cmd, "selectAdviceGroup"))
        DataGridView1.DataSource = dt
    End Sub
    Public Sub SelectQuereyForGrid(ByVal field_name, ByVal tableName, ByVal datagridName)
        Try


            modelHMSObj.field_name = field_name

            modelHMSObj.tableName = tableName
            dt = buisnesslayerobject.SelectALLPatientIdForGrid(modelHMSObj)

            datagridName.DataSource = dt


            dt.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub orderby()


        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Descending)

    End Sub
    Dim datalayer As New DataAccwssLayerCls

    Private Sub Advice_group_headCmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Advice_group_headCmb.SelectedIndexChanged

        selectAdviceById()
        loadGrid()
    End Sub
    Public Sub selectAdviceById()
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Advice_group_name", Advice_group_headCmb.Text)

        dt = (datalayer.BlindGrid(cmd, "selectAdviceByGroupName"))
        Advice_group_id_lab.DataBindings.Clear()
        Advice_group_id_lab.DataBindings.Add("Text", dt, "Advice_group_id")
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        delete_by_sl("GetAdvice", DataGridView1.CurrentRow.Cells(0).Value)
        SelectQuereyForGrid(" sl_no, Advice_group_id'Advice Group Id' , Advice ", "dbo.GetAdvice", DataGridView1)

    End Sub
    Public Sub delete_by_sl(ByVal tablename, ByVal rowsl)
        Try

            If IsNumeric(rowsl) Then
                modelHMSObj.tableName = tablename
                modelHMSObj.sl_no = rowsl
                RowCount = (buisnesslayerobject.delete(modelHMSObj))
                If RowCount = 1 Then
                    ' MessageBox.Show("Delete successfully")

                Else


                End If
            Else
                MessageBox.Show("Select the row you want to delete.")
            End If



        Catch ex As Exception
            MessageBox.Show("Select the row you want to delete.")
        End Try
    End Sub
    Public Sub StripMenuItem()
        DeleteToolStripMenuItem.Visible = False

    End Sub
    Private rowIndex As Integer = 0
    Private Sub DataGridView1_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            StripMenuItem()
            DeleteToolStripMenuItem.Visible = True

            Me.DataGridView1.Rows(e.RowIndex).Selected = True
            Me.rowIndex = e.RowIndex
            Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
            ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
        End If
    End Sub



    Private Sub Advice_group_headCmb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Advice_group_headCmb.KeyDown
        
        loadGrid()
    End Sub

    Public Sub loadGrid()
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Advice_group_id", Advice_group_id_lab.Text)

        dt = (datalayer.BlindGrid(cmd, "selectAdviceGroup"))
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class