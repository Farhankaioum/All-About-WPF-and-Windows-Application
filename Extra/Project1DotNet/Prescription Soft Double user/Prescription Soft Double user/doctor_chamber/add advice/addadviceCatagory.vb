Public Class addadviceCatagory
    Dim buisnesslayerobject As New BuisnessLayer
    Dim modelHMSObj As New modelHMS
    Dim dt As DataTable
    Dim RowCount As Integer
    Dim datalayer As New DataAccwssLayerCls
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        buisnesslayerobject.Advice_group_name_catagory = AdviceCatagoryTxt.Text

        buisnesslayerobject.InsertAdvice_group_name()
        AdviceCatagoryTxt.Text = ""
        AdviceCatagoryTxt.Focus()
        SelectQuereyForGrid("Advice_group_id AdviceID, Advice_group_name as 'Advice Group Name'", "dbo.Advice_group_name", DataGridView1)
        orderby()
    End Sub
    Public Function deletegroupid(ByVal objModelPatiant) As Integer
        RowCount = datalayer.deletegroupid(objModelPatiant)
        Return RowCount
    End Function
    Public Sub orderby()


        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Public Sub SelectQuereyForGrid(ByVal field_name, ByVal tableName, ByVal datagridName)
        Try


            modelHMSObj.field_name = field_name

            modelHMSObj.tableName = tableName
            modelHMSObj.AdmissionId = AdviceCatagoryTxt.Text
            dt = buisnesslayerobject.SelectALLPatientIdForGrid(modelHMSObj)

            datagridName.DataSource = dt


            dt.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub addadvice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectQuereyForGrid("Advice_group_id AdviceID, Advice_group_name as 'Advice Group Name'", "dbo.Advice_group_name", DataGridView1)
        orderby()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        delete_by_sl("dbo.Advice_group_name", DataGridView1.CurrentRow.Cells(0).Value)
        SelectQuereyForGrid("Advice_group_id AdviceID, Advice_group_name as 'Advice Group Name'", "dbo.Advice_group_name", DataGridView1)
        orderby()
    End Sub
    Public Sub delete_by_sl(ByVal tablename, ByVal rowsl)
        Try

            If IsNumeric(rowsl) Then
                modelHMSObj.tableName = tablename
                modelHMSObj.sl_no = rowsl
                RowCount = (buisnesslayerobject.deletegroupid(modelHMSObj))
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
