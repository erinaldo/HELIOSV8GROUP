Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General

Public Class FormAsignarPreciosArticulos
    'Public Property ListaPrecios As List(Of configuracionPrecioProducto)
    Public Property precioSA As New ConfiguracionPrecioProductoSA

    Public Sub New(grid As GridGroupingControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False)
        LLenarGrid(grid)
    End Sub

    Private Sub LLenarGrid(grid As GridGroupingControl)
        Dim dt As New DataTable
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("marca")
        dt.Columns.Add("menor")
        dt.Columns.Add("mayor")
        dt.Columns.Add("gmayor")
        For Each r In grid.Table.Records
            If r.GetValue("sel") = True Then
                dt.Rows.Add(r.GetValue("idItem"),
                        r.GetValue("descripcion"),
                        "NIU",
                        r.GetValue("marca"), 0, 0, 0)
            End If

        Next
        dgvCompra.DataSource = dt
    End Sub

    Private Sub ActualizarPrecios()
        Dim precio As New configuracionPrecioProducto
        Dim lista As New List(Of configuracionPrecioProducto)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            For Each r In dgvCompra.Table.Records

                precio = New configuracionPrecioProducto
                    precio.idPrecio = 1
                    precio.idproducto = Val(r.GetValue("idProducto"))
                    precio.fecha = DateTime.Now
                    precio.tipo = 1
                    precio.valPorcentaje = 0
                    precio.descripcion = "precio x menor"
                    precio.precioMN = CDec(r.GetValue("menor"))
                    precio.precioME = 0
                    lista.Add(precio)
                    'End If

                    'If CDec(r.GetValue("venta")) > 0 Then
                    precio = New configuracionPrecioProducto
                    precio.idPrecio = 2
                    precio.idproducto = Val(r.GetValue("idProducto"))
                    precio.fecha = DateTime.Now
                    precio.tipo = 1
                    precio.valPorcentaje = 0
                    precio.descripcion = "precio x mayor"
                    precio.precioMN = CDec(r.GetValue("mayor"))
                    precio.precioME = 0
                    lista.Add(precio)
                    'End If

                    precio = New configuracionPrecioProducto
                    precio.idPrecio = 3
                    precio.idproducto = Val(r.GetValue("idProducto"))
                    precio.fecha = DateTime.Now
                    precio.tipo = 1
                    precio.valPorcentaje = 0
                    precio.descripcion = "precio x gran mayor"
                    precio.precioMN = CDec(r.GetValue("gmayor"))
                    precio.precioME = 0
                    lista.Add(precio)

                'If CDec(r.GetValue("alquiler")) > 0 Then

            Next

            precioSA.GrabarListadoPrecios(lista)
            MessageBox.Show("Precios actualizados", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Cursor = Cursors.WaitCursor
        If MessageBox.Show("Desea registrar los precios ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ActualizarPrecios()
        End If
        '  precioSA.GrabarListadoPrecios(ListaPrecios)
        'MessageBox.Show("Precios registrados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        For Each i In dgvCompra.Table.Records
            i.SetValue("menor", TextMenor.DecimalValue)
            i.SetValue("mayor", TextMayor.DecimalValue)
            i.SetValue("gmayor", TextGranMayor.DecimalValue)
        Next
    End Sub
End Class