Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection
    Public Sub Conectar()
        Try
            con.ConnectionString = "Data Source=ADMIN-PC\SQL23;Initial Catalog=prueba3003;Integrated Security=True"
            con.Open()
            MessageBox.Show(con.State.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Module
