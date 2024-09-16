Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.SQLite

Public Class productos
    'tabla Productos:
    'ID_Producto (int, PK, Auto Increment): Identificador único para cada producto.
    'Nombre_Producto (varchar(100)): Nombre del producto (ej: Rosa, Maceta).
    'Categoría (varchar(50)): Tipo de producto (ej: Flor, Planta, Maceta, Herramienta, Químico).
    'Precio (decimal(10, 2)): Precio del producto.
    'Stock (int): Cantidad disponible en inventario.
    'Descripción (varchar(255)): Breve descripción del producto.
    Dim id_producto As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'guardo el producto en la base de datos
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("INSERT INTO Productos (Nombre_Producto, Categoría, Precio, Stock, Descripción) VALUES (@Nombre_Producto, @Categoria, @Precio, @Stock, @Descripcion)", conexion)
        comando.Parameters.AddWithValue("@Nombre_Producto", TextBox1.Text)
        comando.Parameters.AddWithValue("@Categoria", ComboBox1.SelectedValue)
        comando.Parameters.AddWithValue("@Precio", TextBox2.Text)
        comando.Parameters.AddWithValue("@Stock", TextBox3.Text)
        comando.Parameters.AddWithValue("@Descripcion", TextBox4.Text)
        comando.ExecuteNonQuery()
        conexion.Close()
        MsgBox("Producto agregado correctamente")
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click



    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' pido los datos para agregar una nueva categoria
        Dim categoria As String = InputBox("Ingrese el nombre de la nueva categoria", "Nueva Categoria")
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("INSERT INTO Categorias (Nombre_Categoria) VALUES (@Nombre_Categoria)", conexion)
        comando.Parameters.AddWithValue("@Nombre_Categoria", categoria)
        comando.ExecuteNonQuery()
        conexion.Close()
        MsgBox("Categoria agregada correctamente")
    End Sub

    Private Sub TabPage2_GotFocus(sender As Object, e As EventArgs) Handles TabPage2.GotFocus

    End Sub

    Private Sub productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'limpio el listview
        ListView1.Clear()

        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("SELECT Productos.Nombre_Producto,Categorias.Nombre_Categoria,Productos.Precio,Productos.Stock,Productos.Descripción FROM Productos INNER JOIN Categorias ON Productos.Categoría = Categorias.ID_Categoria;", conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()
        'agregamos las columanas al listview
        ListView1.Columns.Add("Nombre", 100)
        ListView1.Columns.Add("Categoria", 100)
        ListView1.Columns.Add("Precio", 100)
        ListView1.Columns.Add("Stock", 100)
        ListView1.Columns.Add("Descripcion", 1000)
        While lector.Read()
            Dim item As New ListViewItem(lector("Nombre_Producto").ToString)
            item.SubItems.Add(lector("Nombre_Categoria").ToString)
            item.SubItems.Add(lector("Precio").ToString)
            item.SubItems.Add(lector("Stock").ToString)
            item.SubItems.Add(lector("Descripción").ToString)
            ListView1.Items.Add(item)
        End While
        conexion.Close()

    End Sub

    Private Sub productos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '        Tabla Categorias

        'ID_Categoria(Int, PK, Auto Increment) : Identificador unico de cada categoria.
        'Nombre_Categoria(varchar(50)) : Nombre de la categoria (ej: Flor, Planta, Maceta, etc.).
        'limpio el combo box
        'ComboBox1.Items.Clear()
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta y traer las categorias a l combo box, en la propiedad text se muestra la columna Nombre_Producto, en la propiedad value se muestra la columna ID_Producto
        Dim comando As New SQLiteCommand("SELECT * FROM Categorias", conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(lector)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "Nombre_Categoria"
        ComboBox1.ValueMember = "ID_Categoria"
        conexion.Close()





    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Verificar si RadioButton1 está chequeado para buscar por nombre
        If RadioButton1.Checked = True Then
            Try
                ' Crear la conexión
                Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
                conexion.Open()

                ' Crear el comando con la consulta correcta
                Dim comando As New SQLiteCommand("SELECT Productos.Nombre_Producto, Categorias.Nombre_Categoria, Productos.Precio, Productos.Stock, Productos.Descripción FROM Productos INNER JOIN Categorias ON Productos.Categoría = Categorias.ID_Categoria WHERE Productos.Nombre_Producto LIKE @nombre", conexion)

                ' Asignar el parámetro con los comodines para LIKE
                comando.Parameters.AddWithValue("@nombre", "%" & TextBox5.Text & "%")

                ' Ejecutar el lector de datos
                Dim lector As SQLiteDataReader = comando.ExecuteReader()
                ' Limpiar el ListView antes de agregar nuevos elementos
                ListView1.Clear()
                'agregamos las columanas al listview
                ListView1.Columns.Add("Nombre", 100)
                ListView1.Columns.Add("Categoria", 100)
                ListView1.Columns.Add("Precio", 100)
                ListView1.Columns.Add("Stock", 100)
                ListView1.Columns.Add("Descripcion", 1000)
                ' Leer los datos y agregarlos al ListView
                While lector.Read()
                    Dim item As New ListViewItem(lector("Nombre_Producto").ToString)
                    item.SubItems.Add(lector("Nombre_Categoria").ToString)
                    item.SubItems.Add(lector("Precio").ToString)
                    item.SubItems.Add(lector("Stock").ToString)
                    item.SubItems.Add(lector("Descripción").ToString)
                    ListView1.Items.Add(item)
                End While

                ' Cerrar el lector y la conexión
                lector.Close()
                conexion.Close()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Floreria_isiv.Show()
        Me.Close()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub TabPage3_GotFocus(sender As Object, e As EventArgs) Handles TabPage3.GotFocus

    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        'cargo los productos ordenados por nombre en el datagrid a través de un enlace de datos
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("SELECT Productos.ID_Producto, Productos.Nombre_Producto,Categorias.Nombre_Categoria,Productos.Precio,Productos.Stock,Productos.Descripción FROM Productos INNER JOIN Categorias ON Productos.Categoría = Categorias.ID_Categoria ORDER BY Productos.Nombre_Producto;", conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()
        'limpio la grilla
        DataGridView1.Rows.Clear()
        'limpio las columnas
        DataGridView1.Columns.Clear()

        'agregamos las columanas al datagrid
        DataGridView1.Columns.Add("ID_Producto", "ID_Producto")
        DataGridView1.Columns.Add("Nombre", "Nombre")
        DataGridView1.Columns.Add("Categoria", "Categoria")
        DataGridView1.Columns.Add("Precio", "Precio")
        DataGridView1.Columns.Add("Stock", "Stock")
        DataGridView1.Columns.Add("Descripcion", "Descripcion")
        'agregamos las filas al datagrid
        While lector.Read()
            DataGridView1.Rows.Add(lector("ID_Producto"), lector("Nombre_Producto"), lector("Nombre_Categoria"), lector("Precio"), lector("Stock"), lector("Descripción"))
        End While
        conexion.Close()
        'cargo las categorias en el combo box2
        'crear una coneccion a la base de datos
        conexion.Open()
        'crear un comando para ejecutar una consulta y traer las categorias a l combo box, en la propiedad text se muestra la columna Nombre_Producto, en la propiedad value se muestra la columna ID_Producto
        Dim comando2 As New SQLiteCommand("SELECT * FROM Categorias", conexion)
        Dim lector2 As SQLiteDataReader = comando2.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(lector2)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "Nombre_Categoria"
        ComboBox2.ValueMember = "ID_Categoria"
        conexion.Close()
        'recargo el tabpage3
        TabPage3_Enter(sender, e)




    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'cargo los datos del producto seleccionado en los textbox y el id en una variable
        Dim id As Integer = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox9.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' si se selecciono un producto, pregunto si lo quiere eliminar
        If id_producto <> 0 Then
            Dim respuesta As MsgBoxResult = MsgBox("¿Está seguro que desea eliminar el producto?", MsgBoxStyle.YesNo)
            If respuesta = MsgBoxResult.Yes Then
                'crear una coneccion a la base de datos
                Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
                conexion.Open()
                'crear un comando para ejecutar una consulta
                Dim comando As New SQLiteCommand("DELETE FROM Productos WHERE ID_Producto = @ID_Producto", conexion)
                comando.Parameters.AddWithValue("@ID_Producto", id_producto)
                comando.ExecuteNonQuery()
                conexion.Close()
                'limpio la grilla y la vuelvo a cargar
                TabPage4_Enter(sender, e) ' llamo al evento enter de la pestaña 3
                MsgBox("Producto eliminado correctamente")
            End If
        Else
            MsgBox("Seleccione un producto para eliminar")
        End If


    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        'cargo la grilla con los productos ordenados por nombre
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("SELECT Productos.ID_Producto, Productos.Nombre_Producto,Categorias.Nombre_Categoria,Productos.Precio,Productos.Stock,Productos.Descripción FROM Productos INNER JOIN Categorias ON Productos.Categoría = Categorias.ID_Categoria ORDER BY Productos.Nombre_Producto;", conexion)
        Dim lector As SQLiteDataReader = comando.ExecuteReader()
        'limpio la grilla
        DataGridView2.Rows.Clear()
        'limpio las columnas
        DataGridView2.Columns.Clear()

        'agregamos las columanas al datagrid
        DataGridView2.Columns.Add("ID_Producto", "ID_Producto")
        DataGridView2.Columns.Add("Nombre", "Nombre")
        DataGridView2.Columns.Add("Categoria", "Categoria")
        DataGridView2.Columns.Add("Precio", "Precio")
        DataGridView2.Columns.Add("Stock", "Stock")
        DataGridView2.Columns.Add("Descripcion", "Descripcion")
        'agregamos las filas al datagrid
        While lector.Read()
            DataGridView2.Rows.Add(lector("ID_Producto"), lector("Nombre_Producto"), lector("Nombre_Categoria"), lector("Precio"), lector("Stock"), lector("Descripción"))
        End While
        conexion.Close()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        ' al hacer click en una celda cargo el id en una variable global y selecciono la linea
        id_producto = DataGridView2.Rows(e.RowIndex).Cells(0).Value
        DataGridView2.Rows(e.RowIndex).Selected = True

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' pido los datos para agregar una nueva categoria
        Dim categoria As String = InputBox("Ingrese el nombre de la nueva categoria", "Nueva Categoria")
        'crear una coneccion a la base de datos
        Dim conexion As New SQLiteConnection("Data Source=c:\base_de_datos\floreria.db;Version=3;")
        conexion.Open()
        'crear un comando para ejecutar una consulta
        Dim comando As New SQLiteCommand("INSERT INTO Categorias (Nombre_Categoria) VALUES (@Nombre_Categoria)", conexion)
        comando.Parameters.AddWithValue("@Nombre_Categoria", categoria)
        comando.ExecuteNonQuery()
        conexion.Close()
        MsgBox("Categoria agregada correctamente")
    End Sub
End Class