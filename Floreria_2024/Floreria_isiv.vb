Public Class Floreria_isiv
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cierro la aplicacion
        Me.Close()

    End Sub

    Private Sub IngresarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarToolStripMenuItem.Click
        Loguin.ShowDialog()

    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        Form1.ShowDialog()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        FrmModificarUsuarios.ShowDialog()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        EliminarUsuarios.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        productos.ShowDialog()

    End Sub

    Private Sub VenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem.Click
        Ventas.ShowDialog()
    End Sub

    Private Sub ListadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadosToolStripMenuItem.Click
        listadosdeventas.ShowDialog()
    End Sub
End Class