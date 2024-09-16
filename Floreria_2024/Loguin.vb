Imports System.Data.SQLite
Public Class Loguin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'verifico si los cuadros de texto estan vacios
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Ingrese usuario y contraseña")
            Exit Sub
        End If
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña", conexion)
        comando.Parameters.AddWithValue("@Email", TextBox1.Text)
        'encriptar la contraseña
        Dim sha As New Security.Cryptography.SHA256Managed
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox2.Text)
        Dim hash As Byte() = sha.ComputeHash(bytes)
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 0 To hash.Length - 1
            sb.Append(hash(i).ToString("X2"))
        Next
        TextBox2.Text = sb.ToString
        comando.Parameters.AddWithValue("@Contraseña", TextBox2.Text)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()
        If lector.Read() Then
            MsgBox("Bienvenido")
            'abro el formulario principal
            Floreria_isiv.NuevoToolStripMenuItem.Enabled = True
            lector.Close()
            conexion.Close()
            Floreria_isiv.Show()
            Me.Close()
        Else
            MsgBox("Usuario o contraseña incorrectos")
            TextBox1.SelectAll()
        End If
        lector.Close()
        conexion.Close()



    End Sub
End Class