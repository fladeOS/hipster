Imports System.Data.SqlClient
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
        DB.Koneksi.Ambilkoneksi()
        FillDataGrid()
    End Sub


    Public Sub FillDataGrid()
        ''Buat query SQL untuk menampilkan
        'Dim myQuery As String = "Select * from dbo.tb_transaksi"
        ''Buat sebuah dataAdapter
        'Dim adapter As New SqlDataAdapter(myQuery, DB.Koneksi.conn)
        ''Buat sebuah dataset
        'Dim myDataSet As New DataSet()
        ''Isi dataSet dengan dataAdapter
        'adapter.Fill(myDataSet, "dbo.tb_transaksi")
        ''Isi dataSource
        'dtg1.DataSource = myDataSet

        DB.Koneksi.Ambilkoneksi()
        Dim data As New DataSet
        Dim tabel As String = "select * from dbo.tb_transaksi"
        Dim adapter As New SqlDataAdapter(tabel, DB.Koneksi.conn)
        'Dim gridview As New MySql.Data.MySqlClient.MySqlDataAdapter(tabel, Database)
        adapter.Fill(data, "dbo.tb_transaksi")
        Dim DataGridView As New DataView(data.Tables("dbo.tb_transaksi"))
        dtg1.DataSource = DataGridView
        'Me.gridAdd.Columns(0).HeaderText = "ID Item"
        'Me.gridAdd.Columns(1).HeaderText = "Nama Item"
        'Me.gridAdd.Columns(2).HeaderText = "Harga Satuan"
        'Me.btnEditAdd.Enabled = False
        'Me.btnHapusAdd.Enabled = False

    End Sub

End Class
