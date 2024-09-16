Imports System.Data.SQLite

Public Class listadosdeventas
    Private Sub CargarVentas()
        ' Crear la conexión a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()

        ' Consulta SQL para obtener el listado de ventas con detalles
        Dim query As String = "SELECT Ventas.ID_Venta, Usuarios.Nombre || ' ' || Usuarios.Apellido  AS Nombre_Usuario, Ventas.Fecha_Venta,  Ventas.Total_Venta  FROM Ventas INNER JOIN Usuarios ON Ventas.ID_Usuario = Usuarios.ID_Usuario" 'las plecas || son para concatenar en sql

        ' Crear el comando
        Dim comando As New SQLiteCommand(query, conexion) ' Crear un DataTable para almacenar los datos

        ' Crear un DataTable para almacenar los datos
        Dim dt As New DataTable()


        Dim adapter As New SQLiteDataAdapter(comando)
        adapter.Fill(dt)

        ' Asignar los datos al DataGridView
        DataGridViewVentas.DataSource = dt '

        ' Cerrar la conexión
        conexion.Close()
    End Sub
    Private Sub PersonalizarColumnasDataGridView()
        DataGridViewVentas.Columns(0).HeaderText = "ID de Venta"
        DataGridViewVentas.Columns(1).HeaderText = "Usuario"
        DataGridViewVentas.Columns(2).HeaderText = "Fecha de Venta"
        DataGridViewVentas.Columns(3).HeaderText = "Total de Venta"
    End Sub


    Private Sub ButtonActualizar_Click(sender As Object, e As EventArgs) Handles ButtonActualizar.Click
        CargarVentas()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Floreria_isiv.Show()

    End Sub

    Private Sub listadosdeventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarVentas()

    End Sub

    Private Sub DataGridViewVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVentas.CellContentClick

    End Sub
End Class