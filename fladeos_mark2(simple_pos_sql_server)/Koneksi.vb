Imports System.Data.SqlClient
Namespace DB
    Module Koneksi
        Public conn As SqlConnection
        Public cmd As SqlCommand
        Public ds As DataSet
        'Public adapter As SqlDataAdapter
        Public rd As SqlDataReader
        Public lokasidb As String

        Public Sub Ambilkoneksi()
            lokasidb = "Data Source=ELIZABETH\SQLEXPRESS;Initial Catalog=fladeos_mark2;Persist Security Info=True;User ID=sa; password=root"
            conn = New SqlConnection(lokasidb)
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
            Catch ex As Exception
                MessageBox.Show(Err.Description, "Results", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Sub
    End Module

    Module Database

        Public Sub FillDataGrid()
            'Panggil method untuk hubungkan ke Database
            DB.Koneksi.Ambilkoneksi()
            'Buat sebuah dataset baru
            Dim data As New DataSet
            'buat query SQL untuk menampilkan
            Dim myQuery As String = "select * from tb_transaksi"
            'Buat sebuah dataAdapter
            Dim adapter As New SqlDataAdapter(myQuery, DB.Koneksi.conn)
            'gunakan adapter untuk mengisi dataSet dengan method FILL
            adapter.Fill(data, "transaksi")
            'Buat dataview yang berisi data dari dataSet yang dipindah dalam format tabel
            Dim DataGridView As New DataView(data.Tables("transaksi"))
            'Isi source datagridview
            Form1.dtg1.DataSource = DataGridView
            'Set Properties datagridview
            Form1.dtg1.Columns(0).HeaderText = "Item Name"
            Form1.dtg1.Columns(1).HeaderText = "Quantity"
            Form1.dtg1.Columns(2).HeaderText = "Price"
            Form1.dtg1.Columns(3).HeaderText = "Count"
            Form1.dtg1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form1.dtg1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form1.dtg1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form1.dtg1.Columns(2).DefaultCellStyle.Format = "C"
            Form1.dtg1.Columns(3).DefaultCellStyle.Format = "C"
            Form1.dtg1.Columns(1).Width = 70
            Form1.dtg1.Columns(2).Width = 80
            Form1.dtg1.Columns(3).Width = 80
            Form1.dtg1.Columns(4).Visible = False
        End Sub

        Public Sub InsertTransaction()
            Dim myQuery As String = "insert into dbo.tb_transaksi values ('" & Form1.itemName & "', '" & Form1.quantity & "', '" & Form1.price & "', '" & Form1.count & "', '" & "')"
            cmd = New SqlClient.SqlCommand(myQuery, conn)
            cmd.ExecuteNonQuery()
            Form1.totalHarga += Form1.count
            MessageBox.Show("Berhasil insert")
            Form1.tbTotal.Text = FormatCurrency(Form1.totalHarga)
        End Sub

        Public Sub GetMenu()
            'Panggil method untuk hubungkan ke Database
            DB.Koneksi.Ambilkoneksi()
            'Buat sebuah dataset baru
            Dim data As New DataSet
            'buat query SQL untuk menampilkan
            Dim myQuery As String = "select nama_item from tb_item"
            'Buat sebuah dataAdapter
            Dim adapter As New SqlDataAdapter(myQuery, DB.Koneksi.conn)
            'gunakan adapter untuk mengisi dataSet dengan method FILL
            adapter.Fill(data, "menu")
            'Isi source datagridview
            Form1.cbbItem.DataSource = data.Tables("menu")
            Form1.cbbItem.ValueMember = "nama_item"
            Form1.cbbItem.DisplayMember = "nama_item"
        End Sub

    End Module

End Namespace
