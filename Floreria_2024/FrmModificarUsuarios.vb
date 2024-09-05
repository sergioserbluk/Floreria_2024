Imports System.Data.SQLite
Public Class FrmModificarUsuarios
    Dim ID_Usuario As Integer
    Dim old_pas As String
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
    Private Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub
    Private Sub desactivar()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub
    Private Sub activar()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub
    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        'cuando recibe el foco el textbox selecciono todo el texto
        TextBox1.SelectAll()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        'cuando presiona enter pasa al siguiente control
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If

    End Sub
    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        TextBox2.SelectAll()
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox3.Focus()
        End If
    End Sub
    Private Sub TextBox3_GotFocus(sender As Object, e As EventArgs) Handles TextBox3.GotFocus
        TextBox3.SelectAll()
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox4.Focus()
        End If
    End Sub
    Private Sub TextBox4_GotFocus(sender As Object, e As EventArgs) Handles TextBox4.GotFocus
        TextBox4.SelectAll()
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox5.Focus()
        End If
    End Sub
    Private Sub TextBox5_GotFocus(sender As Object, e As EventArgs) Handles TextBox5.GotFocus
        TextBox5.SelectAll()
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox6.Focus()
        End If
    End Sub
    Private Sub TextBox6_GotFocus(sender As Object, e As EventArgs) Handles TextBox6.GotFocus
        TextBox6.SelectAll()
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            Button2.Focus()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        desactivar()
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("UPDATE Usuarios SET Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Contraseña=@Contraseña, Teléfono=@Teléfono, Dirección=@Dirección WHERE ID_Usuario=@ID_Usuario", conexion)
        comando.Parameters.AddWithValue("@Nombre", TextBox1.Text)
        comando.Parameters.AddWithValue("@Apellido", TextBox2.Text)
        comando.Parameters.AddWithValue("@Email", TextBox3.Text)
        If old_pas <> TextBox4.Text Then
            'encriptar la contraseña
            Dim sha As New Security.Cryptography.SHA256Managed
            Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox4.Text)
            Dim hash As Byte() = sha.ComputeHash(bytes)
            Dim sb As New System.Text.StringBuilder
            For i As Integer = 0 To hash.Length - 1
                sb.Append(hash(i).ToString("X2"))
            Next
            TextBox4.Text = sb.ToString
        End If
        comando.Parameters.AddWithValue("@Contraseña", TextBox4.Text)
        comando.Parameters.AddWithValue("@Teléfono", TextBox5.Text)
        comando.Parameters.AddWithValue("@Dirección", TextBox6.Text)
        comando.Parameters.AddWithValue("@ID_Usuario", ID_Usuario)
        comando.ExecuteNonQuery()
        conexion.Close()
        MsgBox("Usuario modificado correctamente")
        'limpio los textbox
        limpiar()
        'recargo la grilla
        cargarGrilla()
    End Sub
    Private Sub FrmModificarUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrilla()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button1.Enabled = True
        'cuando se hace click en una celda del datagrid se cargan los datos en los textbox
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        'tomo el codigo de usuario para poder modificarlo y lo guardo en una variable
        ID_Usuario = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        'guardo la contraseña en una variable para poder compararla luego
        old_pas = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        activar()
        TextBox1.Focus()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        activar()
        TextBox1.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class