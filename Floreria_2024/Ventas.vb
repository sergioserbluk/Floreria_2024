Imports System.Data.SQLite

Public Class Ventas
    Private Sub CargarUsuarios()
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()

        Dim query As String = "SELECT ID_Usuario, Nombre || ' ' || Apellido AS NombreCompleto FROM Usuarios"
        Dim comando As New SQLiteCommand(query, conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()

        Dim dt As New DataTable()
        dt.Load(lector)

        ComboBoxUsuarios.DataSource = dt
        ComboBoxUsuarios.DisplayMember = "NombreCompleto"
        ComboBoxUsuarios.ValueMember = "ID_Usuario"

        lector.Close()
        conexion.Close()
    End Sub

    Private Sub CargarProductos()
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        Dim query As String = "SELECT ID_Producto, Nombre_Producto, Precio FROM Productos"
        Dim comando As New SQLiteCommand(query, conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()

        While lector.Read()
            ComboBoxProductos.Items.Add(New With {.ID = lector("ID_Producto"), .Nombre = lector("Nombre_Producto"), .Precio = lector("Precio")})
        End While

        ComboBoxProductos.DisplayMember = "Nombre"
        ComboBoxProductos.ValueMember = "ID"
        lector.Close()
        conexion.Close()
    End Sub
    Private Sub AgregarProductoAlCarrito()
        Dim productoSeleccionado = DirectCast(ComboBoxProductos.SelectedItem, Object)
        Dim cantidad As Integer = Convert.ToInt32(TextBoxCantidad.Text)
        Dim precio As Decimal = Convert.ToDecimal(productoSeleccionado.Precio)
        Dim totalProducto As Decimal = cantidad * precio

        Dim item As New ListViewItem(productoSeleccionado.Nombre.ToString())
        item.SubItems.Add(cantidad.ToString())
        item.SubItems.Add(precio.ToString("F2"))
        item.SubItems.Add(totalProducto.ToString("F2"))
        ListViewCarrito.Items.Add(item)

        ' Actualizar el total de la venta
        ActualizarTotalVenta(totalProducto)
    End Sub
    Private Sub FinalizarVenta()
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()

        ' Insertar la venta
        Dim totalVenta As Decimal = Convert.ToDecimal(LabelTotal.Text)
        Dim idUsuario As Integer = Convert.ToInt32(ComboBoxUsuarios.SelectedValue)
        'obtengo el id del usuario seleccionado en el combobox
        Dim queryVenta As String = "INSERT INTO Ventas (ID_Usuario, Fecha_Venta, Total_Venta) VALUES (@ID_Usuario, @Fecha_Venta, @Total_Venta)"
        Dim comandoVenta As New SQLiteCommand(queryVenta, conexion)
        comandoVenta.Parameters.AddWithValue("@ID_Usuario", idUsuario)
        comandoVenta.Parameters.AddWithValue("@Fecha_Venta", DateTime.Now)
        comandoVenta.Parameters.AddWithValue("@Total_Venta", totalVenta)
        comandoVenta.ExecuteNonQuery()

        ' Obtener el ID de la venta recién creada
        Dim idVenta As Long = conexion.LastInsertRowId

        ' Insertar los detalles de la venta
        For Each item As ListViewItem In ListViewCarrito.Items
            Dim nombreProducto As String = item.Text
            Dim cantidad As Integer = Convert.ToInt32(item.SubItems(1).Text)
            Dim precioUnitario As Decimal = Convert.ToDecimal(item.SubItems(2).Text)

            ' Obtener el ID del producto
            Dim queryProducto As String = "SELECT ID_Producto FROM Productos WHERE Nombre_Producto = @Nombre"
            Dim comandoProducto As New SQLiteCommand(queryProducto, conexion)
            comandoProducto.Parameters.AddWithValue("@Nombre", nombreProducto)
            Dim idProducto As Integer = Convert.ToInt32(comandoProducto.ExecuteScalar()) 'executeScalar me devuelve un solo valor de la consulta que es el id del producto

            ' Insertar en la tabla Detalle_Ventas
            Dim queryDetalle As String = "INSERT INTO Detalle_Ventas (ID_Venta, ID_Producto, Cantidad, Precio_Unitario) VALUES (@ID_Venta, @ID_Producto, @Cantidad, @Precio_Unitario)"
            Dim comandoDetalle As New SQLiteCommand(queryDetalle, conexion)
            comandoDetalle.Parameters.AddWithValue("@ID_Venta", idVenta)
            comandoDetalle.Parameters.AddWithValue("@ID_Producto", idProducto)
            comandoDetalle.Parameters.AddWithValue("@Cantidad", cantidad)
            comandoDetalle.Parameters.AddWithValue("@Precio_Unitario", precioUnitario)
            comandoDetalle.ExecuteNonQuery()
        Next

        conexion.Close()
        MessageBox.Show("Venta finalizada correctamente.")
    End Sub


    Private Sub ActualizarTotalVenta(monto As Decimal)
        Dim totalActual As Decimal = Convert.ToDecimal(LabelTotal.Text)
        LabelTotal.Text = (totalActual + monto).ToString("F2") ' en esta linea se suma el total actual con el monto del producto y se muestra en el label, el "F2" es para que muestre solo 2 decimales
    End Sub
    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
        CargarProductos()
        'pongo los encavezados de la lista
        ListViewCarrito.Columns.Add("Producto", 150)
        ListViewCarrito.Columns.Add("Cantidad", 100)
        ListViewCarrito.Columns.Add("Precio Unitario", 100)
        ListViewCarrito.Columns.Add("Total", 100)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FinalizarVenta()
        ComboBoxUsuarios.Text = ""
        ComboBoxProductos.Text = ""
        TextBoxCantidad.Text = ""
        LabelTotal.Text = "0.00"
        ListViewCarrito.Items.Clear()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AgregarProductoAlCarrito()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Floreria_isiv.Show()
    End Sub
End Class