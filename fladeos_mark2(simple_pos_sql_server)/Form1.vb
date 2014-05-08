Imports System.Data.SqlClient
Public Class Form1

    Friend itemName, quantity, price, count As String
    Friend totalHarga As Int32 = 0

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        itemName = cbbItem.Text
        quantity = tbQuantity.Text
        price = tbPrice.Text
        count = tbCount.Text
        If itemName = vbNullString Then
            MessageBox.Show("Silahkan isi Item Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        ElseIf quantity = vbNullString Then
            MessageBox.Show("Silahkan isi Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        ElseIf price = vbNullString Then
            MessageBox.Show("Silahkan isi Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        ElseIf count = vbNullString Then
            MessageBox.Show("Silahkan isi Count", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else
            Try
                DB.Database.InsertTransaction()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error")
            End Try
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DB.Koneksi.Ambilkoneksi()
        DB.Database.FillDataGrid()
        DB.Database.GetMenu()
    End Sub


    

End Class
