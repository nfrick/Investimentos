Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms

Namespace VBControls
    Public Class DataGridViewWithButtons : Inherits DataGridView

        Event CellButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)

        Private Sub CellContentClicked(sender As System.Object, e As DataGridViewCellEventArgs) Handles Me.CellContentClick
            If TypeOf Me.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
                RaiseEvent CellButtonClick(Me, e)
            End If
        End Sub

        Dim savedRow As Integer

        Public Sub SaveCurrentRow()
            If SelectedRows.Count = 0 Then 
                savedRow = -1
            Else
                savedRow = SelectedRows(0).Index
            End If
        End Sub

        Public Sub RestoreCurrentRow(col As integer)
            If RowCount > 0 And savedRow > RowCount - 1 Then savedRow -= 1
            If savedRow > -1 Then CurrentCell = Rows(savedRow).Cells(col)
        End Sub

    End Class
End Namespace

