Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCompraRapida

    Public Sub New(be As detalleitems)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtProducto.Text = be.descripcionItem
        txtProducto.Tag = be.codigodetalle
        LoadCombos()
    End Sub

    Private Sub LoadCombos()
        Dim almacenSA As New almacenSA
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
    End Sub

    Private Sub Grabar(cantComprada As Decimal)
        Dim articuloSA As New detalleitemsSA
        Dim entidadSA As New entidadSA
        Dim CompraSA As New DocumentoCompraSA
        Dim FormatoFecha = DateTime.Now

        Dim ImporteTotalCompras As Decimal = 0
        Dim prov = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, Nothing, General.GEstableciento.IdEstablecimiento)


        Dim numeroNota = CompraSA.GetNumeracionCompra(New documentocompra With
                                            {
                                            .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                            .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA
                                                      })

        Dim be As New documento With
        {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idEmpresa = General.Gempresas.IdEmpresaRuc,
        .idCentroCosto = General.GEstableciento.IdEstablecimiento,
        .tipoDoc = "9907",
        .fechaProceso = FormatoFecha,
        .moneda = "1",
        .idEntidad = prov.idEntidad,
        .entidad = prov.nombreCompleto,
        .tipoEntidad = General.TIPO_ENTIDAD.PROVEEDOR,
        .nrodocEntidad = "-",
        .nroDoc = numeroNota,
        .tipoOperacion = General.StatusTipoOperacion.COMPRA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra = New documentocompra With
        {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .aprobado = "N",
        .codigoLibro = General.StatusCodigoLibroContable.REGISTRO_DE_COMPRAS,
        .idEmpresa = General.Gempresas.IdEmpresaRuc,
        .idCentroCosto = General.GEstableciento.IdEstablecimiento,
        .fechaLaboral = DateTime.Now,
        .fechaDoc = FormatoFecha,
        .fechaContable = General.GetPeriodo(FormatoFecha, True),
        .tipoDoc = "9907",
        .serie = "NOTE",
        .numeroDoc = numeroNota,
        .idProveedor = prov.idEntidad,
        .monedaDoc = "1",
        .tasaIgv = 0,
        .tcDolLoc = 0,
        .tipocambio = 0,
        .bi01 = ImporteTotalCompras,
        .bi02 = 0,
        .bi03 = 0,
        .bi04 = 0,
        .isc01 = 0,
        .isc02 = 0,
        .isc03 = 0,
        .igv01 = 0,
        .igv02 = 0,
        .igv03 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .otc03 = 0,
        .otc04 = 0,
        .bi01us = 0,
        .bi02us = 0,
        .bi03us = 0,
        .bi04us = 0,
        .isc01us = 0,
        .isc02us = 0,
        .isc03us = 0,
        .igv01us = 0,
        .igv02us = 0,
        .igv03us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .otc03us = 0,
        .otc04us = 0,
        .importeTotal = ImporteTotalCompras,
        .importeUS = 0,
        .destino = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
        .estadoPago = General.TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
        .glosa = "Por la compra según nota de compra",
        .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
        .situacion = General.statusComprobantes.Normal,
        .tieneDetraccion = "N",
        .usuarioActualizacion = usuario.IDUsuario.ToString,
        .fechaActualizacion = DateTime.Now
        }

        Dim art As New detalleitems
        art = articuloSA.InvocarProductoID(Val(txtProducto.Tag))
        be.documentocompra.documentocompradetalle = GetDetalleNota(be, art, cantComprada)

        CompraSA.GrabarNotaCompraDirecta(be)
        MsgBox("Compra realizada", MsgBoxStyle.Information, "Atención")
        'If VentanaSel IsNot Nothing Then
        '    VentanaSel.ThreadTransito()
        'End If

        Dim miInterfaz As IConfirmarCompraRapida = TryCast(Me.Owner, IConfirmarCompraRapida)
        If miInterfaz IsNot Nothing Then miInterfaz.ConfirmaTransaccion(True)
        Close()
    End Sub

    Private Function GetDetalleNota(ndocumento As documento, r As detalleitems, cantidadComprada As Decimal) As List(Of documentocompradetalle)
        GetDetalleNota = New List(Of documentocompradetalle)
        Dim nroLotex = Nothing
        Dim obj As recursoCostoLote = Nothing
        Dim objDetalle As documentocompradetalle
        '  For Each i In dgvCompra.Table.Records
        objDetalle = New documentocompradetalle
        ndocumento.documentocompra.AsigancionDeLotes = "POR LOTES"
        nroLotex = "-"
        obj = New recursoCostoLote With
                            {
                            .fechaentrada = ndocumento.fechaProceso,
                            .nroLote = nroLotex,
                            .detalle = r.descripcionItem,
                            .fechaProduccion = Date.Now,
                            .productoSustentado = False
                            }
        Dim precios As New List(Of configuracionPrecioProducto)


        objDetalle = New documentocompradetalle With
                               {
                               .ItemEntregadototal = "S",
                               .nrolote = nroLotex,
                               .CustomRecursoCostoLote = obj,
                               .IdEmpresa = General.Gempresas.IdEmpresaRuc,
                               .IdEstablecimiento = General.GEstableciento.IdEstablecimiento,
                               .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                               .TipoOperacion = General.StatusTipoOperacion.COMPRA,
                               .FechaDoc = ndocumento.fechaProceso,
                               .FechaLaboral = DateTime.Now,
                               .CuentaProvedor = "4212",
                               .NombreProveedor = "Varios",
                               .Serie = "NT",
                               .NumDoc = ndocumento.nroDoc,
                               .TipoDoc = ndocumento.tipoDoc,
                               .idItem = r.codigodetalle,
                               .descripcionItem = r.descripcionItem,
                               .tipoExistencia = General.TipoExistencia.Mercaderia,
                               .destino = r.origenProducto,
                               .unidad1 = r.unidad1,
                               .monto1 = cantidadComprada,
                               .precioUnitario = 0,
                               .precioUnitarioUS = 0,
                               .importe = 0,
                               .importeUS = 0,
                               .montokardex = 0,
                               .montoIsc = 0,
                               .montoIgv = 0,
                               .otrosTributos = 0,
                               .montokardexUS = 0,
                               .montoIscUS = 0,
                               .montoIgvUS = 0,
                               .otrosTributosUS = 0,
                               .almacenRef = cboAlmacen.SelectedValue,
                               .fechaEntrega = DateTime.Now,
                               .estadoPago = "PN",
                               .usuarioModificacion = usuario.IDUsuario,
                               .fechaModificacion = DateTime.Now
                               }
        'objDetalle.CustomInventarioMovimiento = GetInventario(objDetalle)
        GetDetalleNota.Add(objDetalle)
        '    Next
    End Function

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        If TextCantidad.DecimalValue > 0 Then
            Grabar(TextCantidad.DecimalValue)
        Else
            MessageBox.Show("Debe ingresar una cantidad mayor a cero!", "Validar campo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextCantidad.SelectAll()
            TextCantidad.Select()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormCompraRapida_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class