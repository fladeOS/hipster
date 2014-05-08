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

        

    End Module

End Namespace
