Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmExistenciasEnTransito
#Region "Attributes"
    Public Property invSA As New inventarioMovimientoSA
    Dim tablaSA As New tablaDetalleSA
    Dim almacenSA As New almacenSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvTransito, True)
        FormatoGridPequeño(dgvEnvioAlmacen, False)
        FormatoGridAvanzado(GridProveedores, True, False)
        FormatoGridAvanzado(GridComprobantes, True, False)
        FormatoColumnasGrid()
        LoadCombosInicio()
        GetProveedoresEnTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                   .tipoCompra = TIPO_COMPRA.COMPRA})
    End Sub
#End Region

#Region "Methods"
    Function ValidarExistenciaDisponible(column As String, idProducto As Integer, codigoLote As Integer) As Decimal
        Dim sumaMN As Decimal = 0
        For Each i As Record In dgvEnvioAlmacen.Table.Records
            If i.GetValue("iditem") = idProducto AndAlso i.GetValue("codigoLote") = codigoLote Then
                sumaMN += CDec(i.GetValue(column))
            End If
        Next

        Return sumaMN
    End Function

    Function ItemEsCorrecto(r As Record) As Boolean
        dgvEnvioAlmacen.TableControl.CurrentCell.EndEdit()
        dgvEnvioAlmacen.TableControl.Table.TableDirty = True
        dgvEnvioAlmacen.TableControl.Table.EndEdit()
        For Each i As Record In dgvEnvioAlmacen.Table.Records
            If i.GetValue("iditem") = Val(r.GetValue("idItem")) AndAlso i.GetValue("almacenEnvio") = cboAlmacenDestino.SelectedValue Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub AsiganarItem(intNumero As Integer)
        Dim compraDetSA As New DocumentoCompraDetalleSA
        If ItemEsCorrecto(dgvTransito.Table.CurrentRecord) = True Then
            For x = 0 To intNumero - 1
                Dim r As Record = dgvTransito.Table.CurrentRecord
                Dim cantidad As Decimal = Math.Round(CDec(r.GetValue("cantidad")) / intNumero, 2)
                Dim montoMN As Decimal = Math.Round(CDec(r.GetValue("importeMN")) / intNumero, 2)
                Dim montoME As Decimal = Math.Round(CDec(r.GetValue("importeME")) / intNumero, 2)
                Dim precunitMN As Decimal = CDec(r.GetValue("saldoMontoMN")) / CDec(r.GetValue("saldoCan"))
                Dim precunitME As Decimal = CDec(r.GetValue("saldoMontoME")) / CDec(r.GetValue("saldoCan"))


                Dim obj = compraDetSA.GetUbicar_documentocompradetallePorID(Integer.Parse(r.GetValue("secCompra")))

                Me.dgvEnvioAlmacen.Table.AddNewRecord.SetCurrent()
                Me.dgvEnvioAlmacen.Table.AddNewRecord.BeginEdit()
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("idDocumento", r.GetValue("idDocumento"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("secuencia", r.GetValue("secCompra"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("fecha", r.GetValue("fechaCompra"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipodoc", r.GetValue("comprobanteCompra"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("serie", 1)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("numero", 1)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("gravado", r.GetValue("origen"))

                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipoEx", r.GetValue("tipoExistencia"))
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", 0) ' cantidad)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", 0) 'montoMN)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", 0) ' montoME)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("puMN", precunitMN) ' montoME)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("puME", precunitME) ' montoME)almacenEnvio
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("almacenEnvio", cboAlmacenDestino.SelectedValue)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("codigoLote", obj.codigoLote)
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("nroLote", "-")
                Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantMaxima", CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")))

                Me.dgvEnvioAlmacen.Table.AddNewRecord.EndEdit()
            Next
        Else
            MessageBox.Show("El item ingresado ya esta en la canasta, ingreser otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Public Sub GetInventarioTransitoByIdDocumento(idProveedor As Integer, idDocumentoCompra As Integer)
        Dim compra As New documentocompra
        Dim dt As New DataTable()
        Dim str As String

        dt.Columns.Add("origen") ' 0
        dt.Columns.Add("tipoExistencia") ' 1
        dt.Columns.Add("idAlmacen") ' 2
        dt.Columns.Add("almacen") ' 3
        dt.Columns.Add("idDocumento") ' 4

        dt.Columns.Add("idProveedor") ' 5
        dt.Columns.Add("Razon") ' 6

        dt.Columns.Add("idItem") ' 7
        dt.Columns.Add("descripcion") ' 8
        dt.Columns.Add("cantidad") ' 9
        dt.Columns.Add("unidad") ' 10
        dt.Columns.Add("precUnit") '11
        dt.Columns.Add("importeMN") ' 12
        dt.Columns.Add("importeME") ' 13
        dt.Columns.Add("idInventario") ' 14
        dt.Columns.Add("cuenta") ' 15
        dt.Columns.Add("fechaCompra") ' 16

        dt.Columns.Add("comprobanteCompra") ' 17
        dt.Columns.Add("nroCompra") ' 18
        dt.Columns.Add("tipoCambio") ' 19
        dt.Columns.Add("precUnitME") ' 20
        dt.Columns.Add("origen2") ' 21
        dt.Columns.Add("docRef") ' 22
        dt.Columns.Add("evento") ' 23
        dt.Columns.Add("origen3") ' 24
        dt.Columns.Add("bonifica") ' 25
        dt.Columns.Add("empaque") ' 26
        dt.Columns.Add("fecVcto") ' 27
        dt.Columns.Add("proveedor") ' 28
        dt.Columns.Add("secCompra") ' 29
        dt.Columns.Add("tp") ' 29

        dt.Columns.Add("guiaCan") ' 29
        dt.Columns.Add("guiaMontoMN") ' 29
        dt.Columns.Add("guiaMontoME") ' 29
        dt.Columns.Add("saldoCan") ' 29
        dt.Columns.Add("saldoMontoMN") ' 29
        dt.Columns.Add("saldoMontoME") ' 29
        'dt.Columns.Add("fechaEnvio")
        compra = New documentocompra With {.idDocumento = idDocumentoCompra, .idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                          .tipoCompra = TIPO_COMPRA.COMPRA, .idProveedor = idProveedor, .TipoExistencia = cboTipoExistenciaTransito.SelectedValue}
        For Each i In invSA.GetExistenciaTransitoByCompra(compra)

            If i.SaldoCantidad > 0 Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = (i.destino)
                dr(1) = (i.tipoExistencia)
                dr(2) = (i.almacenRef)
                dr(3) = ("ALM. VIRT") 'i.NombreAlmacen)
                dr(4) = (i.idDocumento)
                dr(5) = (i.idEntidad)
                dr(6) = i.NombreProveedor
                dr(7) = i.idItem
                dr(8) = i.descripcionItem
                dr(9) = (i.monto1)
                dr(10) = (i.unidad1)
                If (CDec(i.monto1) > 0) Then
                    dr(11) = Math.Round(CDec(i.montokardex) / CDec(i.monto1), 2)
                    dr(20) = Math.Round(CDec(i.montokardexUS) / CDec(i.monto1), 2)
                End If
                dr(12) = (FormatNumber(i.montokardex, 2))
                dr(13) = (FormatNumber(i.montokardexUS, 2))
                dr(14) = String.Empty
                dr(15) = String.Empty
                dr(16) = (FormatDateTime(i.FechaDoc, DateFormat.GeneralDate))

                dr(17) = (i.TipoDoc)
                dr(18) = i.Serie & "-" & i.NumDoc
                dr(19) = (i.tipoCambio)
                dr(21) = (i.destino)
                dr(22) = (i.idDocumento)
                dr(23) = Nothing
                dr(24) = ("INTERNO")
                dr(25) = (i.Glosa)
                dr(26) = String.Empty
                dr(27) = ""
                dr(28) = (i.NombreProveedor)
                dr(29) = (i.secuencia)
                dr(30) = String.Empty

                dr(31) = i.GuiaCantidad
                dr(32) = i.GuiaMontoMN
                dr(33) = i.GuiaMontoME
                dr(34) = i.SaldoCantidad
                dr(35) = i.SaldoMontoMN
                dr(36) = i.SaldoMontoME
                'dr(37) = i.FechaDoc
                dt.Rows.Add(dr)
            End If


        Next
        dgvTransito.DataSource = dt
        dgvTransito.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        'dgvPersonal.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub FormatoColumnasGrid()
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("iditem")
        dt.Columns.Add("gravado")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("almacenEnvio")
        dt.Columns.Add("puMN")
        dt.Columns.Add("puME")
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("nroLote")
        dt.Columns.Add("cantMaxima")

        dgvEnvioAlmacen.DataSource = dt
    End Sub

    Public Sub LoadCombosInicio()
        Dim lista As New List(Of tabladetalle)
        lista = New List(Of tabladetalle)
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})
        lista.AddRange(tablaSA.GetListaTablaDetalle(5, "1"))


        cboTipoExistenciaTransito.DisplayMember = "descripcion"
        cboTipoExistenciaTransito.ValueMember = "codigoDetalle"
        cboTipoExistenciaTransito.DataSource = lista

        Dim lstAlmacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacenDestino.DataSource = lstAlmacen
        cboAlmacenDestino.DisplayMember = "descripcionAlmacen"
        cboAlmacenDestino.ValueMember = "idAlmacen"
    End Sub

    Public Sub GetComprobantesEnCola(idProveedor As Integer)
        Dim compra As New documentocompra
        Dim dt As New DataTable

        With dt.Columns
            .Add("idDoc")
            .Add("TipoDoc")
            .Add("NroDoc")
            .Add("Costo")
            .Add("fecha")
        End With

        compra = New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                           .tipoCompra = TIPO_COMPRA.COMPRA, .idProveedor = idProveedor, .TipoExistencia = cboTipoExistenciaTransito.SelectedValue}

        For Each i In invSA.GetComprobantesEnTransito(compra)
            dt.Rows.Add(i.idDocumento, i.tipoDoc, i.numeroDoc, i.importeTotal, i.fechaDoc)
        Next
        GridComprobantes.DataSource = dt
    End Sub

    Public Sub GetProveedoresEnTransito(be As documentocompra)
        Dim dt As New DataTable

        With dt.Columns
            .Add("idProv")
            .Add("Prov")
            .Add("Ruc")
        End With
        For Each i In invSA.GetProveedoresEnTransito(be)
            dt.Rows.Add(i.idEntidad, i.nombreCompleto, i.nrodoc)
        Next
        GridProveedores.DataSource = dt
        'cboproveedor.DisplayMember = "nombreCompleto"
        'cboproveedor.ValueMember = "idEntidad"
        'cboproveedor.DataSource = invSA.GetProveedoresEnTransito(be)
    End Sub

    Private Sub GrabarEnvioMasivo(envio As EnvioExistencia)
        Dim invSA As New inventarioMovimientoSA
        Dim documento As New documento
        Dim obj As New InventarioMovimiento()
        Dim listaExistencias As New List(Of InventarioMovimiento)
        Dim almacenSA As New almacenSA
        Dim almacenTransito As New almacen

        Try
            dgvTransito.TableControl.CurrentCell.EndEdit()
            dgvTransito.TableControl.Table.TableDirty = True
            dgvTransito.TableControl.Table.EndEdit()

            listaExistencias = New List(Of InventarioMovimiento)

            GuiaRemision(documento, envio)
            ' CType(envio.FechaEnvio, DateTime)

            almacenTransito = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)

            Dim lote As New recursoCostoLote
            For Each i As SelectedRecord In dgvTransito.Table.SelectedRecords
                lote = New recursoCostoLote
                lote.nroLote = envio.nroLote
                lote.detalle = i.Record.GetValue("descripcion")
                lote.fechaProduccion = Date.Now ' CDate(r.GetValue("fechaProd"))
                If envio.fechaVcto.HasValue Then
                    lote.fechaVcto = envio.fechaVcto
                Else
                    lote.fechaVcto = Nothing
                End If

                obj = New InventarioMovimiento With
                      {
                      .idorigenDetalle = Val(i.Record.GetValue("secCompra")),
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                           .idAlmacen = envio.Almacen,
                           .TipoAlmacen = TipoAlmacen.Deposito,
                           .tipoOperacion = "02",
                           .tipoDocAlmacen = envio.TipoDoc,
                           .serie = envio.Serie,
                           .numero = envio.Numero,
                           .idDocumento = Val(i.Record.GetValue("idDocumento")),
                           .idDocumentoRef = Val(i.Record.GetValue("idDocumento")),
                           .idItem = Val(i.Record.GetValue("idItem")),
                           .descripcion = i.Record.GetValue("descripcion"),
                           .fecha = envio.FechaEnvio,
                           .tipoRegistro = Status.Entrada_almacen,
                           .destinoGravadoItem = i.Record.GetValue("origen"),
                           .tipoProducto = i.Record.GetValue("tipoExistencia"),
                           .cantidad = CType(i.Record.GetValue("saldoCan"), Decimal),
                           .unidad = i.Record.GetValue("unidad"),
                           .cantidad2 = 0,
                           .unidad2 = 0,
                           .precUnite = 0,
                           .precUniteUSD = 0,
                           .monto = CDec(i.Record.GetValue("saldoMontoMN")),
                           .montoUSD = CDec(i.Record.GetValue("saldoMontoME")),
                           .status = Status.Distribuido,
                           .entragado = Status.Entrada_almacen,
                           .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
                    }
                listaExistencias.Add(obj)


                'Registro de la Salida

                obj = New InventarioMovimiento With
                     {
                          .idorigenDetalle = Val(i.Record.GetValue("secCompra")),
                          .idEmpresa = Gempresas.IdEmpresaRuc,
                          .idEstablecimiento = almacenTransito.idEstablecimiento,
                          .idAlmacen = almacenTransito.idAlmacen,
                          .TipoAlmacen = TipoAlmacen.transito,
                          .tipoOperacion = "02",
                          .tipoDocAlmacen = envio.TipoDoc,
                          .serie = envio.Serie,
                          .numero = envio.Numero,
                          .idDocumento = Val(i.Record.GetValue("idDocumento")),
                          .idDocumentoRef = Val(i.Record.GetValue("idDocumento")),
                          .idItem = Val(i.Record.GetValue("idItem")),
                          .descripcion = i.Record.GetValue("descripcion"),
                          .fecha = envio.FechaEnvio,
                          .tipoRegistro = Status.Salida_almacen,
                          .destinoGravadoItem = i.Record.GetValue("origen"),
                          .tipoProducto = i.Record.GetValue("tipoExistencia"),
                          .cantidad = CDec(i.Record.GetValue("saldoCan")) * -1,
                          .unidad = i.Record.GetValue("unidad"),
                          .cantidad2 = 0,
                          .unidad2 = 0,
                          .precUnite = 0,
                          .precUniteUSD = 0,
                          .monto = CDec(i.Record.GetValue("saldoMontoMN")) * -1,
                          .montoUSD = CDec(i.Record.GetValue("saldoMontoME")) * -1,
                          .status = Status.Distribuido,
                          .entragado = Status.Entrada_almacen,
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now
                   }
                listaExistencias.Add(obj)
            Next
            documento.InventarioMovimiento = listaExistencias

            If rbParcial.Checked = True Then
                documento.TipoEnvio = "PARCIAL"
            ElseIf rbCompleta.Checked = True Then
                documento.TipoEnvio = "MASIVO"
            End If

            invSA.GrabarEnvioTransito(documento)
            MessageBox.Show("Existencia enviada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Verificar artículos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Dispose()
    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento, envio As EnvioExistencia)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        Dim itemSA As New detalleitemsSA
        Dim entidadSA As New entidadSA
        'REGISTRANDO LA GUIA DE REMISION
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0

        Dim ent = entidadSA.UbicarEntidadPorID(GridProveedores.Table.CurrentRecord.GetValue("idProv")).FirstOrDefault

        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = envio.FechaEnvio
            .nroDoc = envio.Serie & "-" & envio.Numero
            .idOrden = Nothing
            .moneda = "1"
            .idEntidad = ent.idEntidad
            .entidad = ent.nombreCompleto
            .nrodocEntidad = ent.nrodoc
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = envio.FechaEnvio
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .serie = envio.Serie
            .numeroDoc = envio.Numero
            .idEntidad = ent.idEntidad ' docCompra.idProveedor
            .monedaDoc = "1" ' docCompra.monedaDoc
            .tasaIgv = 0 ' docCompra.tasaIgv
            .tipoCambio = 0 ' docCompra.tcDolLoc
            .importeMN = 0
            .importeME = 0
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE
        sumaMN = 0
        sumaME = 0
        For Each i As SelectedRecord In dgvTransito.Table.SelectedRecords
            sumaMN += CDec(i.Record.GetValue("saldoMontoMN"))
            sumaME += CDec(i.Record.GetValue("saldoMontoME"))

            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = 0
            documentoguiaDetalle.secuenciaRef = Val(i.Record.GetValue("secCompra"))
            documentoguiaDetalle.idItem = Val(i.Record.GetValue("idItem"))
            documentoguiaDetalle.descripcionItem = i.Record.GetValue("descripcion")
            documentoguiaDetalle.destino = i.Record.GetValue("origen")
            documentoguiaDetalle.unidadMedida = i.Record.GetValue("unidad")
            documentoguiaDetalle.cantidad = CDec(i.Record.GetValue("saldoCan"))
            documentoguiaDetalle.precioUnitario = 0
            documentoguiaDetalle.precioUnitarioUS = 0
            documentoguiaDetalle.importeMN = CDec(i.Record.GetValue("saldoMontoMN"))
            documentoguiaDetalle.importeME = CDec(i.Record.GetValue("saldoMontoME"))
            documentoguiaDetalle.idDocumentoPadre = Val(i.Record.GetValue("idDocumento"))
            documentoguiaDetalle.almacenRef = envio.Almacen

            documentoguiaDetalle.secuencia = Val(i.Record.GetValue("secCompra"))

            documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next
        objDocumentoCompra.documentoGuia.importeMN = sumaMN
        objDocumentoCompra.documentoGuia.importeME = sumaME
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub GuiaRemisionParcial(objDocumentoCompra As documento, envio As EnvioExistencia)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        Dim entidadSA As New entidadSA

        Dim ent = entidadSA.UbicarEntidadPorID(GridProveedores.Table.CurrentRecord.GetValue("idProv")).FirstOrDefault

        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = CType(envio.FechaEnvio, DateTime)
            .nroDoc = envio.Serie & "-" & envio.Numero
            .idOrden = Nothing
            .moneda = "-"
            .idEntidad = ent.idEntidad
            .entidad = ent.nombreCompleto
            .nrodocEntidad = ent.nrodoc
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = CType(envio.FechaEnvio, DateTime)
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .serie = envio.Serie
            .numeroDoc = envio.Numero
            .idEntidad = Nothing ' docCompra.idProveedor
            .monedaDoc = Nothing ' docCompra.monedaDoc
            .tasaIgv = Nothing ' docCompra.tasaIgv
            .tipoCambio = Nothing ' docCompra.tcDolLoc
            .importeMN = 0
            .importeME = 0
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE
        sumaMN = 0
        sumaME = 0

        For Each i As Record In dgvEnvioAlmacen.Table.Records
            sumaMN += CDec(i.GetValue("montoMN"))
            sumaME += CDec(i.GetValue("montoME"))

            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = 0
            documentoguiaDetalle.secuenciaRef = Val(i.GetValue("secuencia")) 'secuencia
            documentoguiaDetalle.idItem = Val(i.GetValue("iditem"))
            documentoguiaDetalle.descripcionItem = i.GetValue("item")
            documentoguiaDetalle.destino = i.GetValue("gravado")
            documentoguiaDetalle.unidadMedida = i.GetValue("unidad")
            If Not CDec(i.GetValue("cantidad")) > 0 Then
                Throw New Exception("La cantidad Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If
            documentoguiaDetalle.cantidad = CDec(i.GetValue("cantidad"))
            documentoguiaDetalle.precioUnitario = 0
            documentoguiaDetalle.precioUnitarioUS = 0

            If Not CDec(i.GetValue("montoMN")) > 0 Then
                Throw New Exception("El costo (MN.) Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If

            If Not CDec(i.GetValue("montoME")) > 0 Then
                Throw New Exception("El costo (ME.) Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If

            documentoguiaDetalle.importeMN = CDec(i.GetValue("montoMN"))
            documentoguiaDetalle.importeME = CDec(i.GetValue("montoME"))
            documentoguiaDetalle.idDocumentoPadre = Val(i.GetValue("idDocumento"))

            Dim codAlmacen = i.GetValue("almacenEnvio")
            If Not codAlmacen.ToString.Trim.Length > 0 Then
                Throw New Exception("Debe seleccionar un almacén." & vbCrLf & "Item: " & i.GetValue("item"))
            End If
            documentoguiaDetalle.almacenRef = Val(i.GetValue("almacenEnvio"))

            documentoguiaDetalle.secuencia = Val(i.GetValue("secuencia"))

            documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next

        objDocumentoCompra.documentoGuia.importeMN = sumaMN
        objDocumentoCompra.documentoGuia.importeME = sumaME
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Sub GrabarEnvioParcial(envio As EnvioExistencia)
        Dim invSA As New inventarioMovimientoSA
        Dim documento As New documento
        Dim obj As New InventarioMovimiento()
        Dim listaExistencias As New List(Of InventarioMovimiento)
        Dim almacenSA As New almacenSA
        Dim almacenTransito As New almacen
        Try
            dgvEnvioAlmacen.TableControl.CurrentCell.EndEdit()
            dgvEnvioAlmacen.TableControl.Table.TableDirty = True
            dgvEnvioAlmacen.TableControl.Table.EndEdit()


            listaExistencias = New List(Of InventarioMovimiento)

            GuiaRemisionParcial(documento, envio)

            almacenTransito = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
            For Each i As Record In dgvEnvioAlmacen.Table.Records

                Dim cantidadEnvio = Decimal.Parse(i.GetValue("cantidad"))
                If cantidadEnvio <= 0 Then
                    MessageBox.Show("Debe indicar una cantidad mayor a cero." & vbCrLf & "item: " & i.GetValue("item"))
                    Exit Sub
                End If

                Dim codAlmacen = i.GetValue("almacenEnvio")
                If Not codAlmacen.ToString.Trim.Length > 0 Then
                    MessageBox.Show("Debe seleccionar un almacén." & vbCrLf & "item: " & i.GetValue("item"))
                    Exit Sub
                End If

                obj = New InventarioMovimiento With
                      {
                           .idorigenDetalle = Val(i.GetValue("secuencia")),
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                           .idAlmacen = Val(i.GetValue("almacenEnvio")),
                           .TipoAlmacen = TipoAlmacen.Deposito,
                           .tipoOperacion = "02",
                           .tipoDocAlmacen = envio.TipoDoc,
                           .serie = envio.Serie,
                           .numero = envio.Numero,
                           .idDocumento = Val(i.GetValue("idDocumento")),
                           .idDocumentoRef = Val(i.GetValue("idDocumento")),
                           .idItem = Val(i.GetValue("iditem")),
                           .descripcion = i.GetValue("item"),
                           .fecha = CType(envio.FechaEnvio, DateTime),
                           .tipoRegistro = Status.Entrada_almacen,
                           .destinoGravadoItem = i.GetValue("gravado"),
                           .tipoProducto = i.GetValue("tipoEx"),
                           .cantidad = CType(i.GetValue("cantidad"), Decimal),
                           .unidad = i.GetValue("unidad"),
                           .cantidad2 = 0,
                           .unidad2 = 0,
                           .precUnite = 0,
                           .precUniteUSD = 0,
                           .monto = CDec(i.GetValue("montoMN")),
                           .montoUSD = CDec(i.GetValue("montoME")),
                           .status = Status.Distribuido,
                           .entragado = Status.Entrada_almacen,
                           .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
                    }
                listaExistencias.Add(obj)


                'Registro de la Salida

                obj = New InventarioMovimiento With
                     {
                          .idorigenDetalle = Val(i.GetValue("secuencia")),
                          .idEmpresa = Gempresas.IdEmpresaRuc,
                          .idEstablecimiento = almacenTransito.idEstablecimiento,
                          .idAlmacen = almacenTransito.idAlmacen,
                          .TipoAlmacen = TipoAlmacen.transito,
                          .tipoOperacion = "02",
                          .tipoDocAlmacen = envio.TipoDoc,
                          .serie = envio.Serie,
                          .numero = envio.Numero,
                          .idDocumento = Val(i.GetValue("idDocumento")),
                          .idDocumentoRef = Val(i.GetValue("idDocumento")),
                          .idItem = Val(i.GetValue("iditem")),
                          .descripcion = i.GetValue("item"),
                          .fecha = CType(envio.FechaEnvio, DateTime),
                          .tipoRegistro = Status.Salida_almacen,
                          .destinoGravadoItem = i.GetValue("gravado"),
                          .tipoProducto = i.GetValue("tipoEx"),
                          .cantidad = CDec(i.GetValue("cantidad")) * -1,
                          .unidad = i.GetValue("unidad"),
                          .cantidad2 = 0,
                          .unidad2 = 0,
                          .precUnite = 0,
                          .precUniteUSD = 0,
                          .monto = CDec(i.GetValue("montoMN")) * -1,
                          .montoUSD = CDec(i.GetValue("montoME")) * -1,
                          .status = Status.Distribuido,
                          .entragado = Status.Entrada_almacen,
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now
                   }
                listaExistencias.Add(obj)
            Next
            documento.InventarioMovimiento = listaExistencias

            If rbParcial.Checked = True Then
                documento.TipoEnvio = "PARCIAL"
            ElseIf rbCompleta.Checked = True Then
                documento.TipoEnvio = "MASIVO"
            End If

            invSA.GrabarEnvioTransito(documento)
            MessageBox.Show("Existencia enviada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Verificar artículos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub dgvEnvioAlmacen_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvEnvioAlmacen.SelectedRecordsChanged
        If e.SelectedRecord IsNot Nothing Then
            If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
                txtCanDisponible.Text = e.SelectedRecord.Record.GetValue("cantMaxima")
                If (CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan") > 0)) Then
                    rbCompleta.Enabled = True
                    rbParcial.Enabled = True
                    txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                    txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
                Else
                    btSelecAll.Visible = True
                    rbCompleta.Checked = True
                    Panel14.Visible = False
                    rbCompleta.Enabled = True
                    rbParcial.Enabled = False
                    txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                    txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
                End If
            End If
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEnvioAlmacen.TableControlCellClick
        If dgvEnvioAlmacen.Table.CurrentRecord IsNot Nothing Then
            txtCanDisponible.Text = dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantMaxima")
            If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
                If (CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan") > 0)) Then
                    rbCompleta.Enabled = True
                    rbParcial.Enabled = True
                    '        txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                    '       txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
                Else
                    btSelecAll.Visible = True
                    rbCompleta.Checked = True
                    Panel14.Visible = False
                    rbCompleta.Enabled = True
                    rbParcial.Enabled = False
                    '      txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                    '         txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
                End If

            End If
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvEnvioAlmacen.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        Dim PUmn As Decimal = 0
        Dim PUme As Decimal = 0
        Dim r As Record = dgvEnvioAlmacen.Table.CurrentRecord
        If r IsNot Nothing Then
            ' If Not IsNothing(Me.dgvTransito.Table.CurrentRecord) Then
            Select Case ColIndex
                    Case 9
                        Dim colCan = ValidarExistenciaDisponible("cantidad", Integer.Parse(r.GetValue("iditem")), Integer.Parse(r.GetValue("codigoLote")))
                        If colCan <= 0 Then
                            MessageBox.Show("La cantidad debe ser mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        If CDec(r.GetValue("cantMaxima")) < colCan Then ' CDec(txtCanDisponible.Text) < colCan Then
                            MessageBox.Show("La cantidad disponible no debe exceder!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", 0)
                            Exit Sub
                        Else
                            PUmn = CType(dgvEnvioAlmacen.Table.CurrentRecord.GetValue("puMN"), Decimal)
                            PUme = CType(dgvEnvioAlmacen.Table.CurrentRecord.GetValue("puME"), Decimal)

                            colMN = PUmn * Val(Me.dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantidad"))
                            colME = PUme * Val(Me.dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantidad"))
                            dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", colMN)
                            dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", colME)
                        End If
                        'Case 10
                        '    Dim colMonto = ValidarExistenciaDisponible("montoMN")
                        '    If CDec(txtMontoDisponible.Text) < colMonto Then
                        '        MessageBox.Show("El monto disponible no debe exceder!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", 0)
                        '        Exit Sub
                        '    End If
                End Select
                '  End If
            End If

    End Sub

    Private Sub dgvTransito_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvTransito.SelectedRecordsChanged
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            '    dgvEnvioAlmacen.Table.Records.DeleteAll()
            If Not IsNothing(e.SelectedRecord) Then
                txtCanDisponible.Text = CDec(e.SelectedRecord.Record.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(e.SelectedRecord.Record.GetValue("saldoMontoMN")).ToString("N2")
            End If
        End If
    End Sub

    Private Sub ButtonAdv20_Click(sender As Object, e As EventArgs) Handles ButtonAdv20.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = GridProveedores.Table.CurrentRecord
        If r IsNot Nothing Then
            GetComprobantesEnCola(Integer.Parse(r.GetValue("idProv")))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = GridProveedores.Table.CurrentRecord
        Dim compra As Record = GridComprobantes.Table.CurrentRecord
        If compra IsNot Nothing Then
            If r IsNot Nothing Then
                If cboTipoExistenciaTransito.SelectedIndex > -1 Then
                    GetInventarioTransitoByIdDocumento(Integer.Parse(r.GetValue("idProv")), Integer.Parse(compra.GetValue("idDoc")))
                End If
            Else
                MessageBox.Show("Debe seleccionar un proveedor válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub Panel16_Click(sender As Object, e As EventArgs) Handles Panel16.Click
        Try
            If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
                ' dgvEnvioAlmacen.Table.Records.DeleteAll()
                Dim sel = cboAlmacenDestino.SelectedValue
                If Not IsNothing(sel) Then
                    If sel.ToString.Trim.Length > 0 Then
                        AsiganarItem(txtNumero.Value)
                    Else
                        MessageBox.Show("Debe seleccionar un almacén de destino", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar un almacén de destino", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btSelecAll_Click(sender As Object, e As EventArgs) Handles btSelecAll.Click
        dgvTransito.Table.SelectedRecords.Clear()
        dgvTransito.Table.Records.SelectAll()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If dgvTransito.Table.SelectedRecords.Count > 0 Then
                If rbParcial.Checked = True Then

                    If dgvEnvioAlmacen.Table.Records.Count > 0 Then
                        Dim f As New frmEnvioExistencia
                        '    f.txtFecha.Value = CType(dgvTransito.Table.CurrentRecord.GetValue("fechaCompra"), DateTime)
                        f.Movimiento = "Parcial"
                        f.Label6.Visible = False
                        f.Label2.Visible = False
                        f.cboAlmacen.Visible = False
                        f.cboAlmacen.Visible = False
                        f.cboEstable.Visible = False
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim envio = CType(f.Tag, EnvioExistencia)
                            GrabarEnvioParcial(envio)
                        End If
                    Else
                        MessageBox.Show("Debe ingresar items a la canasta de distribución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                Else
                    Dim f As New frmEnvioExistencia
                    '    Dim d = dgvTransferencia.Table.SelectedRecords(0).Record.GetValue("fechaCompra")
                    '     f.txtFecha.Value = CType(dgvTransito.Table.Records(0).GetValue("fechaCompra"), DateTime)
                    f.Movimiento = "Masivo"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Label6.Visible = True
                    f.Label2.Visible = True
                    f.cboAlmacen.Visible = True
                    f.cboAlmacen.Visible = True
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim envio = CType(f.Tag, EnvioExistencia)
                        GrabarEnvioMasivo(envio)
                    End If
                End If
                dgvEnvioAlmacen.Table.Records.DeleteAll()
                dgvTransito.Table.Records.DeleteAll()
                ButtonAdv15_Click(sender, e)
                '   ButtonAdv20_Click(sender, e)
                '   GetCountExistenciaTransito()
            Else
                MessageBox.Show("Debe seleccionar items para el envio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub rbCompleta_CheckChanged(sender As Object, e As EventArgs) Handles rbCompleta.CheckChanged
        If rbCompleta.Checked = True Then
            btSelecAll.Visible = True
            'ToolStripButton16.Visible = True
            Panel14.Visible = False
        End If
    End Sub

    Private Sub rbParcial_CheckChanged(sender As Object, e As EventArgs) Handles rbParcial.CheckChanged
        If rbParcial.Checked = True Then
            btSelecAll.Visible = False
            'ToolStripButton16.Visible = False
            Panel14.Visible = True
        End If
    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        GridComprobantes.Table.Records.DeleteAll()
        dgvTransito.Table.Records.DeleteAll()
        GetProveedoresEnTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                  .tipoCompra = TIPO_COMPRA.COMPRA})
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel15_Paint(sender As Object, e As PaintEventArgs) Handles Panel15.Paint

    End Sub

    Private Sub Panel15_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles Panel15.ChangeUICues

    End Sub

    Private Sub Panel15_Click(sender As Object, e As EventArgs) Handles Panel15.Click
        If dgvEnvioAlmacen.Table.Records.Count > 0 Then
            If Not IsNothing(dgvEnvioAlmacen.Table.CurrentRecord) Then
                dgvEnvioAlmacen.Table.CurrentRecord.Delete()
            End If
        End If
    End Sub

    Private Sub GridProveedores_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProveedores.TableControlCellClick
        Dim r As Record = GridProveedores.Table.CurrentRecord
        If r IsNot Nothing Then
            dgvEnvioAlmacen.Table.Records.DeleteAll()
            dgvTransito.Table.Records.DeleteAll()
            GetComprobantesEnCola(Integer.Parse(r.GetValue("idProv")))
        Else
            dgvEnvioAlmacen.Table.Records.DeleteAll()
            dgvTransito.Table.Records.DeleteAll()
            GridComprobantes.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub GridProveedores_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridProveedores.SelectedRecordsChanged
        If e.SelectedRecord IsNot Nothing Then
            dgvEnvioAlmacen.Table.Records.DeleteAll()
            dgvTransito.Table.Records.DeleteAll()
            GetComprobantesEnCola(Integer.Parse(e.SelectedRecord.Record.GetValue("idProv")))
        Else
            dgvEnvioAlmacen.Table.Records.DeleteAll()
            dgvTransito.Table.Records.DeleteAll()
            GridComprobantes.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub GridComprobantes_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridComprobantes.TableControlCellClick

    End Sub

    Private Sub GridComprobantes_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridComprobantes.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        If e.SelectedRecord IsNot Nothing Then
            Dim r As Record = GridProveedores.Table.CurrentRecord
            If r IsNot Nothing Then
                If cboTipoExistenciaTransito.SelectedIndex > -1 Then
                    GetInventarioTransitoByIdDocumento(Integer.Parse(r.GetValue("idProv")), Integer.Parse(e.SelectedRecord.Record.GetValue("idDoc")))
                End If
            Else
                MessageBox.Show("Debe seleccionar un proveedor válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub dgvEnvioAlmacen_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvEnvioAlmacen.TableControlKeyDown
        If dgvEnvioAlmacen.Table.CurrentRecord IsNot Nothing Then
            txtCanDisponible.Text = dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantMaxima")
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvEnvioAlmacen.TableControlKeyPress
        If dgvEnvioAlmacen.Table.CurrentRecord IsNot Nothing Then
            txtCanDisponible.Text = dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantMaxima")
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvEnvioAlmacen.TableControlKeyUp
        If dgvEnvioAlmacen.Table.CurrentRecord IsNot Nothing Then
            txtCanDisponible.Text = dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantMaxima")
        End If
    End Sub

    Private Sub dgvTransito_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTransito.TableControlCellClick

    End Sub

#End Region
End Class