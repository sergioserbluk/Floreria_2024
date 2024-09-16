Imports System.Data.SQLite

Public Class EliminarUsuarios
    Dim ID_Usuario As Integer = 0



    Private Sub cargarGrilla()
        'limpio la grilla
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("SELECT * FROM Usuarios", conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()
        'agregamos las columanas al datagrid
        DataGridView1.Columns.Add("Nombre", "Nombre")
        DataGridView1.Columns.Add("Apellido", "Apellido")
        DataGridView1.Columns.Add("Email", "Email")
        DataGridView1.Columns.Add("Contraseña", "Contraseña")
        DataGridView1.Columns.Add("Teléfono", "Teléfono")
        DataGridView1.Columns.Add("Dirección", "Dirección")
        DataGridView1.Columns.Add("ID_Usuario", "ID_Usuario")
        While lector.Read()
            DataGridView1.Rows.Add(lector("Nombre"), lector(2), lector(3), lector(4), lector(5), lector(6), lector(0))
        End While
        conexion.Close()
    End Sub
    Private Sub EliminarUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrilla()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'si ID_Usuario es 0 no se selecciono ningun usuario salgo de la funcion
        If ID_Usuario = 0 Then
            MsgBox("Seleccione un usuario")
            Exit Sub
        End If
        Dim respuesta As Integer = MsgBox("¿Está seguro que desea eliminar el usuario?", MsgBoxStyle.YesNo)
        If respuesta = vbNo Then
            Exit Sub
        End If

        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("DELETE FROM Usuarios WHERE ID_Usuario = @ID_Usuario", conexion)
        comando.Parameters.AddWithValue("@ID_Usuario", ID_Usuario)
        comando.ExecuteNonQuery()
        conexion.Close()
        MsgBox("Usuario eliminado correctamente")
        cargarGrilla()
        ID_Usuario = 0
        'limpio los textbox
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        Button2.Enabled = False



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'cuando se hace click en una celda de la grilla se cargan los datos en los textbox
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value
        TextBox5.Text = DataGridView1.CurrentRow.Cells(4).Value
        TextBox6.Text = DataGridView1.CurrentRow.Cells(5).Value
        ID_Usuario = DataGridView1.CurrentRow.Cells(6).Value
        Button2.Enabled = True



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Floreria_isiv.Show()

    End Sub
End Class