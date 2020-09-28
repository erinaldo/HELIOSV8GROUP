Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.GroupingGridExcelConverter

Public Class frmGenerarSalidaProduccion
    Inherits frmMaster

    Public Sub New(dgv As GridGroupingControl, intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetGridProduccion(dgv)
        CargarCombosCosto(intIdProyecto)
        txtTipoCosto.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = intIdProyecto}).subtipo
    End Sub

#Region "Métodos"


    Sub CargarCombosCosto(intIdProyecto As Integer)
        Dim recursoSA As New recursoCostoSA

        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("elementocosto").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = intIdProyecto})
        ggcStyle.ValueMember = "idCosto"
        ggcStyle.DisplayMember = "subtipo"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMov.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvMov.ShowRowHeaders = False

        ComboProcesos(intIdProyecto)
    End Sub

    Sub ComboProcesos(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA


        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("proceso").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
        ggcStyle.ValueMember = "idCosto"
        ggcStyle.DisplayMember = "nombreCosto"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMov.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvMov.ShowRowHeaders = False

        'cboProceso.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        'cboProceso.ValueMember = "idCosto"
        'cboProceso.DisplayMember = "nombreCosto"
    End Sub


    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub lsvProveedor_MouseDoubleClick_1(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub
    Public Sub UbicarEntidadPorRuc(strNro As String, strTipoEntidad As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, strTipoEntidad, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '     txtCuenta = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            txtProveedor.Clear()

            txtRuc.Clear()
        End If
    End Sub

    Public Sub UbicarTrabPorDNI(strNumero As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, strNumero)
        If Not IsNothing(persona) Then
            With persona
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idPersona
                '    txtCuenta = "TR"
                txtRuc.Text = .idPersona
            End With
        End If
    End Sub


    Sub GrabarDefault()
        Dim costoSA As New recursoCostoSA
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim obj As New recursoCostoDetalle

        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        'ListaAsientonTransito = New List(Of asiento)

        ListaAsiento = New List(Of asiento)

        dgvMov.TableControl.CurrentCell.EndEdit()
        dgvMov.TableControl.Table.TableDirty = True
        dgvMov.TableControl.Table.EndEdit()

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "99"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "10.01"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = 0 'lblIdDocumento.Text
            .situacion = "10.01"
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text

            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            Else
                .idPersona = CInt(txtProveedor.Tag)
            End If

            .nombreProveedor = txtProveedor.Text
            '.monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .monedaDoc = "1"
            .tasaIgv = 0  ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = TmpTipoCambio
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = 0
            .importeUS = 0

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_VENTA.OTRAS_SALIDAS
            ' .DocumentoSustentado = "S"
            .aprobado = "N"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)

        'If GroupBox2.Visible Then
        ndocumento.documentocompra.aprobado = "S"

        'ASIENTOS CONTABLES
        nAsiento = New asiento With {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCostos = GEstableciento.IdEstablecimiento,
        .idDocumentoRef = Nothing,
        .idAlmacen = 0,
        .nombreAlmacen = String.Empty,
        .idEntidad = txtProveedor.Tag,
        .nombreEntidad = txtProveedor.Text,
        .tipoEntidad = String.Empty,
        .fechaProceso = txtFechaComprobante.Value,
        .codigoLibro = "13",
        .tipo = "D",
        .tipoAsiento = "ACCA",
        .importeMN = 0,
        .importeME = 0,
        .glosa = txtGlosa.Text.Trim,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
            }
        'Else
        '    ndocumento.documentocompra.aprobado = "N"
        'End If



        Dim almacenSA As New almacenSA
        Dim prodSA As New TotalesAlmacenSA
        Dim prod As New totalesAlmacen
        Dim pmMN As Decimal = 0
        Dim pmME As Decimal = 0
        Dim costoMN As Decimal = 0
        Dim costoME As Decimal = 0
        Dim PUmn As Decimal = 0
        Dim PUme As Decimal = 0
        costoMN = 0
        costoME = 0
        If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
            For Each r As Record In dgvMov.Table.Records


                prod = prodSA.GetUbicar_totalesAlmacenPorID(r.GetValue("id"))

                pmMN = prod.importeSoles / prod.cantidad
                pmME = prod.importeDolares / prod.cantidad

                costoMN = CDec(r.GetValue("cantidad")) * pmMN
                costoME = CDec(r.GetValue("cantidad")) * pmME

                PUmn = costoMN / CDec(r.GetValue("cantidad"))
                PUme = costoME / CDec(r.GetValue("cantidad"))

                sumaMN += costoMN
                sumaME += costoME

                objDocumentoCompraDet = New documentocompradetalle
                objDocumentoCompraDet.idProyecto = (txtProyecto.Tag)
                objDocumentoCompraDet.SecuenciaCosto = r.GetValue("costoSec")
                objDocumentoCompraDet.tipoCosto = txtTipoCosto.Text
                Dim element = r.GetValue("elementocosto")
                If Not element.ToString.Trim.Length > 0 Then
                    MessageBox.Show("Debe indicar el elmento del costo del artículo: " & r.GetValue("item"))
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                Dim proce = r.GetValue("proceso")
                If Not proce.ToString.Trim.Length > 0 Then
                    MessageBox.Show("Debe indicar el proceso del costo del artículo: " & r.GetValue("item"))
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                objDocumentoCompraDet.idCosto = Val(r.GetValue("elementocosto"))
                objDocumentoCompraDet.idProceso = Val(r.GetValue("proceso"))

                objDocumentoCompraDet.TipoOperacion = "10.01"
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"
                objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
                objDocumentoCompraDet.TipoDoc = "99"
                objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
                objDocumentoCompraDet.Serie = txtSerie.Text.Trim
                objDocumentoCompraDet.destino = prod.origenRecaudo
                objDocumentoCompraDet.CuentaItem = String.Empty ' r.GetValue("cuenta")
                objDocumentoCompraDet.idItem = Val(r.GetValue("idItem"))
                objDocumentoCompraDet.tipoExistencia = prod.tipoExistencia
                objDocumentoCompraDet.descripcionItem = prod.descripcion
                objDocumentoCompraDet.unidad1 = prod.idUnidad

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) < 0 Then
                        MessageBox.Show("El valor de la cantidad no puede ser negativo", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If IsNumeric(r.GetValue("importeMN")) Then
                    If CDec(r.GetValue("importeMN")) < 0 Then
                        MessageBox.Show("El valor del importe no puede ser negativo", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If Not CDec(r.GetValue("cantidad")) > 0 Then
                    Throw New Exception("Debe ingresar una cantidad mayor cero.")
                End If

                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))

                objDocumentoCompraDet.unidad2 = String.Empty ' r.GetValue("idPrese") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = String.Empty ' r.GetValue("nomPrese") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = PUmn
                objDocumentoCompraDet.precioUnitarioUS = PUme
                objDocumentoCompraDet.importe = costoMN
                objDocumentoCompraDet.importeUS = costoMN
                objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(prod.idAlmacen).idEstablecimiento
                objDocumentoCompraDet.almacenRef = prod.idAlmacen
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoCompraDet)

                'If GroupBox2.Visible Then
                ndocumento.documentocompra.tipoOperacion = "10.01"
                Select Case txtTipoCosto.Text
                    Case TipoCosto.Proyecto, _
                        TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                        TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS, _
                        TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES

                        Select Case prod.tipoExistencia
                            Case TipoExistencia.MateriaPrima

                                nMovimiento = New movimiento With {
                                .cuenta = "6121",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "241",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = r.GetValue("elementocosto")}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                            Case TipoExistencia.MaterialAuxiliar_SuministroRepuesto

                                nMovimiento = New movimiento With {
                                .cuenta = "6131",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "251",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = r.GetValue("elementocosto")}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.EnvasesEmbalajes

                                nMovimiento = New movimiento With {
                               .cuenta = "6141",
                               .descripcion = prod.descripcion,
                               .tipo = "D",
                               .monto = costoMN,
                               .montoUSD = costoME,
                               .usuarioActualizacion = usuario.IDUsuario,
                               .fechaActualizacion = DateTime.Now
                           }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "261",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = r.GetValue("elementocosto")}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                        End Select

                    Case TipoCosto.OrdenProduccion, _
                        TipoCosto.OP_CONTINUA_DE_BIENES, _
                        TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                        TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                        TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES, _
                        TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE

                        Select Case prod.tipoExistencia
                            Case TipoExistencia.MateriaPrima


                                nMovimiento = New movimiento With {
                                .cuenta = "6121",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "241",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = "231",
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "7111",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.MaterialAuxiliar_SuministroRepuesto



                                nMovimiento = New movimiento With {
                                .cuenta = "6131",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "251",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = "231",
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "7111",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.EnvasesEmbalajes


                                nMovimiento = New movimiento With {
                                .cuenta = "6141",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "261",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = "231",
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "7111",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                        End Select


                    Case TipoCosto.ActivoFijo
                        Select Case prod.tipoExistencia
                            Case TipoExistencia.MateriaPrima

                                nMovimiento = New movimiento With {
                                .cuenta = "6121",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "241",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = r.GetValue("elementocosto")}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "7225",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.MaterialAuxiliar_SuministroRepuesto

                                nMovimiento = New movimiento With {
                                .cuenta = "6131",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "251",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = r.GetValue("elementocosto")}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "7225",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.EnvasesEmbalajes

                                nMovimiento = New movimiento With {
                                .cuenta = "6141",
                                .descripcion = prod.descripcion,
                                .tipo = "D",
                                .monto = costoMN,
                                .montoUSD = costoME,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                                nAsiento.movimiento.Add(nMovimiento)


                                nMovimiento = New movimiento With {
                                    .cuenta = "261",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '--------------------------------------------------------------------
                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = r.GetValue("elementocosto")}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "7225",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                        End Select


                    Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero

                        Select Case prod.tipoExistencia
                            Case TipoExistencia.Mercaderia
                                nMovimiento = New movimiento With {
                                 .cuenta = "6111",
                                 .descripcion = prod.descripcion,
                                 .tipo = "D",
                                 .monto = costoMN,
                                 .montoUSD = costoME,
                                 .usuarioActualizacion = usuario.IDUsuario,
                                 .fechaActualizacion = DateTime.Now
                             }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "20111",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)




                            Case TipoExistencia.ProductoTerminado


                                nMovimiento = New movimiento With {
                             .cuenta = "7111",
                             .descripcion = prod.descripcion,
                             .tipo = "D",
                             .monto = costoMN,
                             .montoUSD = costoME,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "211",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.SubProductosDesechos

                                nMovimiento = New movimiento With {
                             .cuenta = "7121",
                             .descripcion = prod.descripcion,
                             .tipo = "D",
                             .monto = costoMN,
                             .montoUSD = costoME,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "221",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                            Case TipoExistencia.ProductosEnProceso

                                nMovimiento = New movimiento With {
                             .cuenta = "7111",
                             .descripcion = prod.descripcion,
                             .tipo = "D",
                             .monto = costoMN,
                             .montoUSD = costoME,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "231",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.MateriaPrima

                                nMovimiento = New movimiento With {
                             .cuenta = "6121",
                             .descripcion = prod.descripcion,
                             .tipo = "D",
                             .monto = costoMN,
                             .montoUSD = costoME,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "241",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                            Case TipoExistencia.MaterialAuxiliar_SuministroRepuesto


                                nMovimiento = New movimiento With {
                             .cuenta = "6131",
                             .descripcion = prod.descripcion,
                             .tipo = "D",
                             .monto = costoMN,
                             .montoUSD = costoME,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "251",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                            Case TipoExistencia.EnvasesEmbalajes

                                nMovimiento = New movimiento With {
                             .cuenta = "6141",
                             .descripcion = prod.descripcion,
                             .tipo = "D",
                             .monto = costoMN,
                             .montoUSD = costoME,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "261",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)


                                '------------------------------------------------------------------------

                                nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)}).codigo,
                                    .descripcion = prod.descripcion,
                                    .tipo = "D",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                                nMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = prod.descripcion,
                                    .tipo = "H",
                                    .monto = costoMN,
                                    .montoUSD = costoME,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                nAsiento.movimiento.Add(nMovimiento)

                        End Select


                End Select
                'End If
            Next
        End If
        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME

        '   If GroupBox2.Visible Then
        nAsiento.importeMN = sumaMN
        nAsiento.importeME = sumaME
        ListaAsiento.Add(nAsiento)
        '  End If

        'TOTALES ALMACEN
        'ListaTotales = ListaTotalesAlmacen() '+positivo

        ndocumento.asiento = ListaAsiento
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        Dim xcod As Integer = CompraSA.GrabarProduccion(ndocumento)
        Me.Tag = "Grabado"
        lblEstado.Text = "entrada registrada!"
        Dispose()
    End Sub

#End Region

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Public Sub GetGridProduccion(dgv As GridGroupingControl)
        Dim dt As New DataTable()
        Dim invSA As New TotalesAlmacenSA
        Dim inv As New totalesAlmacen

        dt.Columns.Add("id")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("grav")
        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("idUM")
        dt.Columns.Add("nomUM")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("almacenDestino")
        dt.Columns.Add("elementocosto")
        dt.Columns.Add("proceso")
        dt.Columns.Add("disponible")
        dt.Columns.Add("costoSec")

        For Each i As Record In dgv.Table.Records
            Dim dr As DataRow = dt.NewRow
            inv = invSA.GetUbicar_totalesAlmacenPorID(Val(i.GetValue("id")))
            dr(0) = i.GetValue("id")
            dr(1) = inv.tipoExistencia
            dr(2) = inv.origenRecaudo
            dr(3) = inv.idItem
            dr(4) = inv.descripcion
            dr(5) = inv.idUnidad
            dr(6) = "-"
            dr(7) = CDec(i.GetValue("cantidad"))
            dr(8) = i.GetValue("almacen")
            dr(9) = String.Empty
            dr(10) = CInt(i.GetValue("proceso"))
            dr(11) = CDec(i.GetValue("cantDisponible"))
            dr(12) = Val(i.GetValue("costoSec"))
            dt.Rows.Add(dr)
        Next
        dgvMov.DataSource = dt

    End Sub

    Private Sub frmGenerarSalidaProduccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmGenerarSalidaProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaComprobante.Value = DateTime.Now
        lblPerido.Text = PeriodoGeneral
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chCli.Checked = False
        chTrab.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.PopupControlContainer1.ParentControl = Me.txtProveedor
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel(TIPO_ENTIDAD.PERSONA_GENERAL, txtProveedor.Text.Trim)

            ElseIf chCli.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If chProv.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarEntidadPorRuc(txtRuc.Text.Trim, TIPO_ENTIDAD.PROVEEDOR)
                End If
            End If
        ElseIf chTrab.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarTrabPorDNI(txtRuc.Text.Trim)
                End If
            End If
        ElseIf chCli.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarEntidadPorRuc(txtRuc.Text.Trim, TIPO_ENTIDAD.CLIENTE)
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        If txtNumero.Text.Trim.Length > 0 Then
            txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub

    Private Sub dgvMov_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvMov.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            If Not txtGlosa.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el detalle de la operación!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                txtGlosa.Select()
                Exit Sub
            End If

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de serie!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

                Exit Sub
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de guía de remisión!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

                Exit Sub
            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Identifique a la persona responsable!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

                Exit Sub
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
                If MessageBox.Show("Desea realizar la operación de sálida con fecha: " & vbCrLf & _
                                           txtFechaComprobante.Value, "Verifique la fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    GrabarDefault()
                End If

            Else
                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese items a la canasta!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If

            'Else

            '    UpdateCompra()

            'End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            TiempoEjecutar(10)
            Timer1.Enabled = True
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PopupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub
End Class