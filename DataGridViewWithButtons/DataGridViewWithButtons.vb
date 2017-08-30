Imports System.Windows.Forms

Namespace VBControls
    Public Class DataGridViewWithButtons : Inherits DataGridView

        Event CellButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)

        Private Sub CellContentClicked(sender As System.Object, e As DataGridViewCellEventArgs) Handles Me.CellContentClick
            If TypeOf Me.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
                RaiseEvent CellButtonClick(Me, e)
            End If
        End Sub

    End Class
End Namespace

