Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conectar()
        mostrardatos()
    End Sub
    Sub mostrardatos()
        Dim da As New SqlDataAdapter("select * from proveedor01", con)
        Dim ds As New DataSet
        da.Fill(ds, "proveedor01")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("Codigo").HeaderText = "Código"
        DataGridView1.Columns("Nombre").HeaderText = "Nombre"
        DataGridView1.Columns("Apellido").HeaderText = "Apellido"
        DataGridView1.Columns("Direccion").HeaderText = "Dirección"
        DataGridView1.Columns("Telefono").HeaderText = "Teléfono"
    End Sub

    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "insert into proveedor01 ( nombre, apellido, dirección, teléfono ) Values ( '" & TxtNombre.Text & "', '" & TxtApellidos.Text & "','" & TxtDireccion.Text & "'," & TxtTelefono.Text & ")"
            cmd.Parameters.AddWithValue("@Nombre", TxtNombre.Text)
            cmd.Parameters.AddWithValue("@Apellidos", TxtApellidos.Text)
            cmd.Parameters.AddWithValue("@Direccion", TxtDireccion.Text)
            cmd.Parameters.AddWithValue("@Telefono", TxtTelefono.Text)
            cmd.ExecuteNonQuery()
            Dim filas As Integer
            If filas > 0 Then
                MessageBox.Show("Datos guardados", "Guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        If DataGridView1.Rows.Count > 0 Then
            If DataGridView1.SelectedRows.Count > 0 Then
                textcodigo.Text = DataGridView1.SelectedRows(0).Cells("Codigo").Value
                TxtNombre.Text = DataGridView1.SelectedRows(0).Cells("Nombre").Value
                TxtApellidos.Text = DataGridView1.SelectedRows(0).Cells("Apellido").Value
                TxtDireccion.Text = DataGridView1.SelectedRows(0).Cells("Direccion").Value
                TxtTelefono.Text = DataGridView1.SelectedRows(0).Cells("Telefono").Value

            End If
        End If
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "update proveedor01 set Nombre ='" & TxtNombre.Text & "', Apellido ='" & TxtApellidos.Text & "',dirección ='" & TxtDireccion.Text & "', teléfono = '" & TxtTelefono.Text & "' where código ='" & TxtCodigo.Text & "'"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Datos actualizados")
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from proveedor01 where código = '" & textcodigo.Text & "'"
        cmd.ExecuteNonQuery()
        MessageBox.Show("datos eliminados")
        mostrardatos()
    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        limpiar()
    End Sub
    Sub limpiar()
        textcodigo.Clear()
        txtNombre.Clear()
        TxtApellidos.Clear()
        TxtDireccion.Clear()
        TxtTelefono.Clear()
    End Sub
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

End Class
