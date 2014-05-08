Public Class Form1

    Dim itemName, quantity, price, count As String

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        itemName = cbbItem.Text
        quantity = tbQuantity.Text
        price = tbPrice.Text
        count = tbCount.Text
        If itemName = vbNullString Then
            MessageBox.Show("Silahkan isi Item Name")
        ElseIf quantity = vbNullString Then
            MessageBox.Show("Silahkan isi Quantity")
        ElseIf price = vbNullString Then
            MessageBox.Show("Silahkan isi Price")
        ElseIf count = vbNullString Then
            MessageBox.Show("Silahkan isi Count")
        Else
            Try
                Dim myQuery As String = "insert into dbo.tb_transaksi values ('" & itemName & "', '" & quantity & "', '" & price & "', '" & count & "', '" & "')"
                DB.Koneksi.cmd = New SqlClient.SqlCommand(myQuery, DB.Koneksi.conn)
                DB.Koneksi.cmd.ExecuteNonQuery()
                MessageBox.Show("Berhasil insert")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DB.Koneksi.ambilkoneksi()
    End Sub
End Class
