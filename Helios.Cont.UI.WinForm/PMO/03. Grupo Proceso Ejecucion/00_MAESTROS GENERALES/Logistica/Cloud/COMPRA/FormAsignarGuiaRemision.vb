Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class FormAsignarGuiaRemision

    Public Property UCDistribucion As UCDistribucionAlmacen
    Public Property UCEnvioProducto As UCEnvioProductoPendienteRecepcion

#Region "Constructors"
    Public Sub New(UCDistribucionAlmacen As UCDistribucionAlmacen)

        ' This call is required by the designer.
        InitializeComponent()
        UCDistribucion = UCDistribucionAlmacen
        ' Add any initialization after the InitializeComponent() call.
        txtFechaGuia.Value = Date.Now
    End Sub

    Public Sub New(UCEnvioProductoPendienteRecepcion As UCEnvioProductoPendienteRecepcion)

        ' This call is required by the designer.
        InitializeComponent()
        UCEnvioProducto = UCEnvioProductoPendienteRecepcion
        ' Add any initialization after the InitializeComponent() call.
        txtFechaGuia.Value = Date.Now
    End Sub
#End Region

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        If TextCodigousuario.Text.Trim.Length > 0 Then
            Dim codigoUser = UsuariosList.Where(Function(o) o.codigo = TextCodigousuario.Text.Trim).FirstOrDefault

            'If codigoUser IsNot Nothing Then
            'Dim obj As New EstructuraGuiaRemision
            'obj.TipoDoc = "99"
            'obj.Serie = txtSerie.Text.Trim
            'obj.numero = txtNumero.Text.Trim
            'obj.Matricula = Textmatricula.Text.Trim
            'obj.Chofer = "-"
            'obj.IdUsuario = codigoUser.IDUsuario
            'obj.NameUsuario = codigoUser.Full_Name
            'obj.Codigousuario = codigoUser.codigo


            Dim doc = AddGuiaRemisionV2()
            doc.documentoGuia.usuarioActualizacion = codigoUser.IDUsuario
            Tag = doc
            Close()
        Else
            MessageBox.Show("No se encontraron usuarios con este código", "Verificar código", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        ' Else

        '  End If
    End Sub

    Private Sub AddGuiaRemision()
        Dim documento As New documento

        Dim numeroGuia = $"{txtSerie.Text.Trim}-{txtNumero.Text.Trim}"
        Dim serieGuia = txtSerie.Text.Trim
        Dim numoGuia = txtNumero.Text.Trim

        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "99"
        documento.fechaProceso = txtFechaGuia.Value
        documento.moneda = "1"
        documento.idEntidad = VarClienteGeneral.idEntidad
        documento.entidad = "VARIOS"
        documento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        documento.nrodocEntidad = "-"
        documento.nroDoc = numeroGuia
        documento.idOrden = 0
        documento.tipoOperacion = StatusTipoOperacion.COMPRA
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = Date.Now

        documento.documentoGuia = New documentoGuia With
        {
        .codigoLibro = "",
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaDoc = txtFechaGuia.Value,
        .fechaTraslado = txtFechaGuia.Value,
        .periodo = GetPeriodo(txtFechaGuia.Value, True),
        .tipoDoc = "99",
        .serie = serieGuia,
        .numeroDoc = numoGuia,
        .idEntidad = VarClienteGeneral.idEntidad,
        .monedaDoc = "1",
        .tasaIgv = 0.18,
        .tipoCambio = 1,
        .importeMN = 0,
        .importeME = 0,
        .direccionPartida = String.Empty,
        .glosa = "Guía de remision",
        .idUnidad = 0,
        .estado = "1",
        .ubigeo = String.Empty,
        .puntoPartida = TextPuntoPartida.Text.Trim,
        .puntoLlegada = TextPuntoLlegada.Text.Trim,
        .tipoMovimiento = CheckedListBox1.SelectedItems.ToString(),
        .motivoTraslado = CheckedListBox1.SelectedItems.ToString(),
        .tipoVehiculo = If(ComboModalidadTransporte.Text = "TRANSPORTE PRIVADO", "PV", "PU"),
        .marcaVehiculo = TextMarca.Text,
        .placaVehiculo = Textmatricula.Text,
        .placaRemolque = Nothing,
        .idEntidadTransporte = 0,
        .nroBrevete = TextLicencia.Text.Trim,
        .estadoGuia = "1",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
        .documentoguiaDetalle = New List(Of documentoguiaDetalle)
        }

        For Each i In UCDistribucion.GridCompra.Table.Records
            If i.GetValue("seleccionar") = True Then

                Dim codigoitemCompra = i.GetValue("idItemCompra")
                Dim itemCompra = UCDistribucion.UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                documento.documentoGuia.documentoguiaDetalle.Add(New documentoguiaDetalle With
                {
                .idItem = itemCompra.CustomProducto.codigodetalle,
                .tipoExistencia = itemCompra.CustomProducto.tipoExistencia,
                .descripcionItem = itemCompra.CustomProducto.descripcionItem,
                .destino = itemCompra.CustomProducto.origenProducto,
                .unidadMedida = itemCompra.CustomProducto.unidad1,
                .cantidad = Decimal.Parse(i.GetValue("cantidad")),
                .estado = "1"
                })
            End If
        Next
    End Sub

    Private Function AddGuiaRemisionV2() As documento
        Dim documento As New documento

        Dim numeroGuia = $"{txtSerie.Text.Trim}-{txtNumero.Text.Trim}"
        Dim serieGuia = txtSerie.Text.Trim
        Dim numoGuia = txtNumero.Text.Trim

        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "99"
        documento.fechaProceso = txtFechaGuia.Value
        documento.moneda = "1"
        documento.idEntidad = VarClienteGeneral.idEntidad
        documento.entidad = "VARIOS"
        documento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        documento.nrodocEntidad = "-"
        documento.nroDoc = numeroGuia
        documento.idOrden = 0
        documento.tipoOperacion = StatusTipoOperacion.COMPRA
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = Date.Now

        documento.documentoGuia = New documentoGuia With
        {
        .codigoLibro = "11",
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaDoc = txtFechaGuia.Value,
        .fechaTraslado = txtFechaGuia.Value,
        .periodo = GetPeriodo(txtFechaGuia.Value, True),
        .tipoDoc = "99",
        .serie = serieGuia,
        .numeroDoc = numoGuia,
        .idEntidad = VarClienteGeneral.idEntidad,
        .monedaDoc = "1",
        .tasaIgv = 0.18,
        .tipoCambio = 1,
        .importeMN = 0,
        .importeME = 0,
        .direccionPartida = String.Empty,
        .glosa = "Guía de remision",
        .idUnidad = 0,
        .estado = "1",
        .ubigeo = String.Empty,
        .puntoPartida = TextPuntoPartida.Text.Trim,
        .puntoLlegada = TextPuntoLlegada.Text.Trim,
        .tipoMovimiento = CheckedListBox1.SelectedIndex.ToString(),
        .motivoTraslado = CheckedListBox1.SelectedItem.ToString(),
        .tipoVehiculo = If(ComboModalidadTransporte.Text = "TRANSPORTE PRIVADO", "PV", "PU"),
        .marcaVehiculo = TextMarca.Text,
        .placaVehiculo = Textmatricula.Text,
        .placaRemolque = Nothing,
        .idEntidadTransporte = 0,
        .nroBrevete = TextLicencia.Text.Trim,
        .estadoGuia = "1",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
        .documentoguiaDetalle = New List(Of documentoguiaDetalle)
        }

        For Each i In UCEnvioProducto.GridCompra.Table.Records
            If i.GetValue("status") = True Then

                Dim IDinv = i.GetValue("codigo")
                Dim inventarioTransito = UCEnvioProducto.listaProductos.Where(Function(o) o.idInventario = IDinv).SingleOrDefault

                inventarioTransito.status = 0

                documento.documentoGuia.documentoguiaDetalle.Add(New documentoguiaDetalle With
                {
                .CustomInventarioTransito = inventarioTransito,
                .idItem = inventarioTransito.CustomProducto.codigodetalle,
                .tipoExistencia = inventarioTransito.CustomProducto.tipoExistencia,
                .descripcionItem = inventarioTransito.CustomProducto.descripcionItem,
                .destino = inventarioTransito.CustomProducto.origenProducto,
                .unidadMedida = inventarioTransito.CustomProducto.unidad1,
                .cantidad = inventarioTransito.cantidad,
                .estado = "1"
                })
            End If
        Next

        AddGuiaRemisionV2 = documento
    End Function

    Private Sub TextCodigousuario_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigousuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextCodigousuario.Text.Trim.Length > 0 Then
                Dim usuario = UsuariosList.Where(Function(o) o.codigo = TextCodigousuario.Text.Trim).FirstOrDefault
                If usuario IsNot Nothing Then
                    TextCodigousuario.Text = usuario.codigo
                    TextUsuario.Text = usuario.Full_Name
                    TextUsuario.Tag = usuario.IDUsuario
                Else
                    TextCodigousuario.Clear()
                    TextUsuario.Text = String.Empty
                    TextUsuario.Tag = String.Empty
                End If
            End If
        End If
    End Sub

    Private Sub TextCodigousuario_TextChanged(sender As Object, e As EventArgs) Handles TextCodigousuario.TextChanged

    End Sub
End Class