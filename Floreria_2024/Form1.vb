Imports System.Data.sqlite

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        While lector.Read()
            DataGridView1.Rows.Add(lector("Nombre"), lector(2), lector(3), lector(4), lector(5), lector(6))
        End While
        conexion.Close()




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("INSERT INTO Usuarios (Nombre, Apellido, Email, Contraseña, Teléfono, Dirección) VALUES (@Nombre, @Apellido, @Email, @Contraseña, @Teléfono, @Dirección)", conexion)
        comando.Parameters.AddWithValue("@Nombre", TextBox1.Text)
        comando.Parameters.AddWithValue("@Apellido", TextBox2.Text)
        comando.Parameters.AddWithValue("@Email", TextBox3.Text)
        'encriptar la contraseña
        Dim sha As New Security.Cryptography.SHA256Managed
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox4.Text)
        Dim hash As Byte() = sha.ComputeHash(bytes)
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 0 To hash.Length - 1
            sb.Append(hash(i).ToString("X2"))
        Next
        TextBox4.Text = sb.ToString
        comando.Parameters.AddWithValue("@Contraseña", TextBox4.Text)
        comando.Parameters.AddWithValue("@Teléfono", TextBox5.Text)
        comando.Parameters.AddWithValue("@Dirección", TextBox6.Text)
        comando.ExecuteNonQuery()
        conexion.Close()
        MsgBox("Usuario agregado correctamente")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Floreria_isiv.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class