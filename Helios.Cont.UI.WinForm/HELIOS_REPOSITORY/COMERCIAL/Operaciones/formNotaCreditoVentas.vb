Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class formNotaCreditoVentas
    'Private listaProductosVendido As List(Of documentoventaAbarrotesDet)

#Region "Variables"

    Public Property ListaAsientonTransito As New List(Of asiento)

#End Region

#Region "Constructor"

    Sub New()
        ' This call is required by the designer.

        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(dgvVentas, False, False, 11.5F)
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Sub New(idDocumento As Integer)

        ' This call is required by the designer.

        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(dgvVentas, False, False, 11.5F)

        Dim valor = ConteoNotasVenta(idDocumento)
        CARGARCOMBOS(valor)
        'LoadConfiguracionCeldasEquivalencia()
        UbicarDocumento(idDocumento)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Private Sub LoadConfiguracionCeldasEquivalencia()

    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercialDev").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercialDev").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercialDev").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercialDev").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
    '    Me.dgvVentas.TableDescriptor.Columns("unidadComercialDev").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell

    '    dgvVentas.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    'End Sub

#End Region

#Region "Metodos"

    Public Function ConteoNotasVenta(idDoc As Integer) As Integer

        Dim DocSa As New documentoVentaAbarrotesSA

        Return DocSa.ConteoNotasVenta(idDoc)


    End Function

    Public Function TipoOperacion() As String
        Dim Operacion As String = ""
        Select Case cboOperacionNotaCredito.SelectedValue
            Case "01" '"ANULACION DE LA OPERACION"
                Operacion = "9916"
            Case "05"   '"DESCUENTO POR ITEM"
                Operacion = "9914"
            Case "07" '"DEVOLUCION POR ITEM"
                Operacion = "9913"

        End Select

        Return Operacion
    End Function



    Sub Grabar()
        Dim CompraSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim TipoOperacionNota As String
        ''''''''''' LIMPIANDO VARIABLES---------------------

        ListaAsientonTransito = New List(Of asiento)



        TipoOperacionNota = TipoOperacion()



        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .fechaProceso = DateTime.Now
            .tipoDoc = "07"
            .nroDoc = txtSerieAfectado.Text & "-" & txtNumeroAfectado.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = cboMoneda.SelectedValue
            If txtRazonSocial.Tag = 0 Then
                .idEntidad = 0
                .entidad = "SIN IDENTIDAD"
                .tipoEntidad = "VR"
                .nrodocEntidad = "0"
            Else
                .idEntidad = Val(txtRazonSocial.Tag)
                .entidad = txtRazonSocial.Text
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                .nrodocEntidad = txtDniRuc.Text
            End If
            .tipoOperacion = TipoOperacionNota
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now

        End With

        With nDocumentoVenta
            .tipoOperacion = TipoOperacionNota
            .idPSE = Gempresas.ubigeo
            .idPadre = txtIdDocumento.Text
            .codigoLibro = "14"
            .notaCredito = cboOperacionNotaCredito.SelectedValue
            .tipoDocumento = "07"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .fechaConfirmacion = DateTime.Now
            .fechaPeriodo = PeriodoGeneral
            .TipoDocNota = txtTipoDoc.Text
            .serie = txtSerieAfectado.Text
            .numeroDoc = txtNumeroAfectado.Text

            If txtRazonSocial.Tag = 0 Then
                .idCliente = 0
                .nombrePedido = "SIN IDENTIDAD"
                .NombreEntidad = "SIN IDENTIDAD"
            Else
                .idCliente = CInt(txtRazonSocial.Tag)
                .nombrePedido = txtRazonSocial.Text
                .NombreEntidad = txtRazonSocial.Text
            End If

            .moneda = cboMoneda.SelectedValue
            .tasaIgv = CDec(TmpIGV)
            .tipoCambio = CDec(txtTipoCambio.Text)

            If cboMoneda.SelectedValue = "1" Then
                .bi01 = CDec(lblGravado.Text)
                .bi02 = CDec(lblExonerado.Text)
                .igv01 = CDec(lblIgv.Text)
                .igv02 = 0
                .bi01us = CDec(lblConvGravado.Text)
                .bi02us = CDec(lblConvGravado.Text)
                .igv01us = CDec(lblConvIgv.Text)
                .igv02us = 0
                .ImporteNacional = CDec(lblTotal.Text)
                .ImporteExtranjero = CDec(lblConvTotal.Text)
                .icbper = CDec(lblIcbper.Text)
                .icbperus = CDec(lblConvIcbperMe.Text)
            ElseIf cboMoneda.SelectedValue = "2" Then
                .bi01 = CDec(lblConvGravado.Text)
                .bi02 = CDec(lblConvExonerado.Text)
                .igv01 = CDec(lblConvIgv.Text)
                .igv02 = 0
                .bi01us = CDec(lblGravado.Text)
                .bi02us = CDec(lblExonerado.Text)
                .igv01us = CDec(lblIgv.Text)
                .igv02us = 0
                .ImporteNacional = CDec(lblConvTotal.Text)
                .ImporteExtranjero = CDec(lblTotal.Text)
                .icbper = CDec(lblConvIcbperMe.Text)
                .icbperus = CDec(lblIcbper.Text)
            End If

            .tipoVenta = TIPO_VENTA.NOTA_CREDITO_ELECTRONICA
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01"

            If txtTipoDoc.Text = "01" Then
                .TipoAfectado = "NTC"
            ElseIf txtTipoDoc.Text = "03" Then
                .TipoAfectado = "NTCB"
            End If


            If lblReclamacionDinero.Text > 0 Then
                If cboMoneda.SelectedValue = "1" Then
                    .ImporteDevMN = CDec(lblReclamacionDinero.Text)
                    .ImporteDevME = CDec(lblConvReclamacionDinero.Text)
                    .EstadoPagoDevolucion = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                ElseIf cboMoneda.SelectedValue = "2" Then
                    .ImporteDevME = CDec(lblReclamacionDinero.Text)
                    .ImporteDevMN = CDec(lblConvReclamacionDinero.Text)
                    .EstadoPagoDevolucion = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            End If

        End With

        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        Dim cantidadEquivalencia As Decimal = 0
        Dim cantDocumentario As Decimal = 0


        For Each r As Record In dgvVentas.Table.Records

            objDocumentoVentaDet = New documentoventaAbarrotesDet

            'Select Case ndocumento.documentoventaAbarrotes.notaCredito
            '    Case "01", "02", "06"
            '        objDocumentoCompraDet.TipoOperacion = "9916"
            '        If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '            MessageBox.Show("No hay Montos por devolver o disminuir!")
            '            Exit Sub
            '        End If
            '    Case "05"
            '        objDocumentoCompraDet.TipoOperacion = "9914"
            '        If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '            MessageBox.Show("Ingrese un monto mayor a cero!")
            '            Exit Sub
            '        End If
            '    Case "07"
            '        objDocumentoCompraDet.TipoOperacion = "9913"
            '        If Not CDec(r.GetValue("Devcantidad")) > 0 Then
            '            MessageBox.Show("Ingrese una cantidad mayor a cero!")
            '            Exit Sub
            '        End If
            'End Select
            Select Case TipoOperacionNota
                Case "9916"
                    If Not CDec(r.GetValue("Devtotal")) > 0 Then
                        MessageBox.Show("No hay Montos por devolver o disminuir!")
                        Exit Sub
                    End If
                Case "9914"
                    If Not CDec(r.GetValue("Devtotal")) > 0 Then
                        MessageBox.Show("Ingrese un monto mayor a cero!")
                        Exit Sub
                    End If
                Case "9913"
                    If Not CDec(r.GetValue("Devcantidad")) > 0 Then
                        MessageBox.Show("Ingrese una cantidad mayor a cero!")
                        Exit Sub
                    End If
            End Select
            objDocumentoVentaDet.TipoOperacion = TipoOperacionNota
            objDocumentoVentaDet.ImporteDevolucionmn = CDec(r.GetValue("DevDinero"))
            objDocumentoVentaDet.ImporteDevolucionme = CDec(r.GetValue("DevDinerome"))

            If objDocumentoVentaDet.ImporteDevolucionmn > 0 Then
                objDocumentoVentaDet.TieneExcedente = True
            Else
                objDocumentoVentaDet.TieneExcedente = False
            End If

            objDocumentoVentaDet.secuencia = r.GetValue("secuencia")
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.FechaDoc = DateTime.Now
            objDocumentoVentaDet.unidad1 = r.GetValue("unidad")
            objDocumentoVentaDet.destino = r.GetValue("destino")
            objDocumentoVentaDet.idItem = r.GetValue("idItem")
            objDocumentoVentaDet.nombreItem = CStr(r.GetValue("descripcion"))
            objDocumentoVentaDet.DetalleItem = CStr(r.GetValue("descripcion"))
            objDocumentoVentaDet.tipoExistencia = CStr(r.GetValue("tipoEx"))




            'Dim prod = listaProductosVendido.Where(Function(o) o.secuencia = r.GetValue("secuencia")).SingleOrDefault

            'If CStr(r.GetValue("tipoEx")) = TipoExistencia.ServicioGasto Then
            '    cantidadEquivalencia = CDec(r.GetValue("Devcantidad"))

            'ElseIf TipoOperacionNota = "9916" Then
            '    cantidadEquivalencia = CDec(r.GetValue("Devcantidad"))
            '    objDocumentoVentaDet.equivalencia_id = CInt(r.GetValue("unidadComercial"))
            'Else

            '    Dim codiUnidadComercial = r.GetValue("unidadComercialDev")
            '    Dim Unidades = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault

            '    If CDec(r.GetValue("cantDisponible")) = 1 Then

            '        If r.GetValue("unidadComercialDev") = r.GetValue("unidadComercial") Then

            '            Dim equiv = Unidades.fraccionUnidad
            '            Dim cantidadneta = CDec(r.GetValue("cantIni")) * prod.CustomEquivalencia.contenido_neto
            '            cantidadneta = cantidadneta - 1
            '            Dim dec1 = cantidadneta * FormatNumber(equiv, 3)
            '            Dim cantidadnew = CDec(r.GetValue("cantinvini"))
            '            Dim dec2 = cantidadnew - FormatNumber(dec1, 3)
            '            cantidadEquivalencia = (CDec(r.GetValue("Devcantidad")) * dec2)

            '            'end hoy
            '        Else
            '            Dim equiv = FormatNumber(Unidades.fraccionUnidad, 2)
            '            Dim cantidadneta = CDec(r.GetValue("cantIni")) * prod.CustomEquivalencia.contenido_neto
            '            cantidadneta = cantidadneta - 1
            '            Dim dec1 = cantidadneta * equiv
            '            Dim cantidadnew = CDec(r.GetValue("cantIni")) * FormatNumber(prod.CustomEquivalencia.fraccionUnidad, 2)
            '            Dim dec2 = Math.Round(cantidadnew - FormatNumber(dec1), 2)
            '            cantidadEquivalencia = (CDec(r.GetValue("Devcantidad")) * dec2)
            '        End If

            '    Else

            '        If r.GetValue("unidadComercialDev") = r.GetValue("unidadComercial") Then
            '            Dim fraccion = FormatNumber(Unidades.fraccionUnidad, 3)
            '            cantidadEquivalencia = CDec(r.GetValue("Devcantidad")) * fraccion
            '        Else

            '            Dim fraccion = FormatNumber(Unidades.fraccionUnidad, 2)

            '            cantidadEquivalencia = CDec(r.GetValue("Devcantidad")) * fraccion
            '        End If
            '    End If
            '    objDocumentoVentaDet.equivalencia_id = CInt(r.GetValue("unidadComercial"))

            'End If


            'objDocumentoVentaDet.equivalencia_id = CInt(r.GetValue("unidadComercial"))
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("Devcantidad")) 'cantidadEquivalencia
            'objDocumentoVentaDet.notaCreditoMN = cantidadEquivalencia 'CDec(r.GetValue("Devcantidad"))
            'objDocumentoVentaDet.monto2 = cantidadEquivalencia 'CDec(r.GetValue("Devcantidad"))
            'objDocumentoVentaDet.salidaCostoMN = cantidadEquivalencia 'CDec(r.GetValue("Devcantidad"))
            If CDec(r.GetValue("Devcantidad")) = 0 Then
                objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("Devtotal"))
                objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("Devtotalme"))
            ElseIf CDec(r.GetValue("Devcantidad")) > 0 Then
                objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("Devtotal")) / CDec(r.GetValue("Devcantidad"))
                objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("Devtotalme")) / CDec(r.GetValue("Devcantidad"))
            End If
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("Devtotal"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("Devtotalme"))

            If r.GetValue("destino") = "1" Then
                objDocumentoVentaDet.montokardex = CDec(r.GetValue("Devgravado"))
                objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("Devgravadome"))
                If CDec(r.GetValue("DevDinero")) > 0 Then
                    Dim iva As Decimal = TmpIGV / 100
                    Dim tot As Decimal = CDec(r.GetValue("DevDinero"))
                    Dim bi As Decimal = Math.Round(CDec(CalculoBaseImponible(tot, iva + 1)), 2)
                    Dim igv As Decimal = tot - bi
                    objDocumentoVentaDet.IgvDevolucionmn = igv
                    objDocumentoVentaDet.BiDevolucionmn = bi
                Else
                    objDocumentoVentaDet.IgvDevolucionmn = 0
                    objDocumentoVentaDet.BiDevolucionmn = 0
                End If
            ElseIf r.GetValue("destino") = "2" Then
                objDocumentoVentaDet.montokardex = CDec(r.GetValue("Devexonerado"))
                objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("Devexoneradome"))
                If CDec(r.GetValue("DevDinero")) > 0 Then
                    objDocumentoVentaDet.IgvDevolucionmn = 0
                    objDocumentoVentaDet.BiDevolucionmn = CDec(r.GetValue("DevDinero"))
                End If
            End If

            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("Devigv"))
            objDocumentoVentaDet.otrosTributos = 0

            objDocumentoVentaDet.montoIcbper = CDec(r.GetValue("Devicbper"))
            objDocumentoVentaDet.montoIcbperUS = CDec(r.GetValue("Devicbperme"))
            objDocumentoVentaDet.tasaIcbper = CDec(r.GetValue("Tasaicbper"))
            '**********************************************************************************
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("Devigvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacenRef"))
            objDocumentoVentaDet.codigoLote = CInt(r.GetValue("lote"))
            objDocumentoVentaDet.preEvento = r.GetValue("estadocobro")
            objDocumentoVentaDet.idPadreDTVenta = CInt(r.GetValue("secuencia"))
            '**********************************************************************************
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.fechaVcto = Nothing
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim

            objDocumentoVentaDet.NumDoc = txtNumeroGuia.Text
            objDocumentoVentaDet.Serie = txtSerieGuia.Text
            objDocumentoVentaDet.TipoDoc = "99"
            If r.GetValue("estadocobro") = "Pagado" Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf r.GetValue("estadocobro") = "Pendiente" Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            ListaDetalle.Add(objDocumentoVentaDet)

        Next

        If lblReclamacionDinero.Text > 0 Then

            Dim ItemDev As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                  Where Fix(n.ImporteDevolucionmn) > 0).ToList

            Dim ListadoExistencias = (From n In ItemDev
                                      Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

            'If ListadoExistencias.Count > 0 Then
            '    AsientoNotaCreditoExcedente(ListadoExistencias)
            'End If

            'Dim ListadoServicios = (From n In ItemDev
            '                        Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList
            'If ListadoServicios.Count > 0 Then
            '    AsientoNotaCreditoExcedenteServicios(ListadoServicios)
            'End If
        End If

        Dim documentoSaldo As New documento
        'ndocumento.asiento = ListaAsientonTransito

        Dim listaOp As New List(Of String)
        'listaOp.Add("9913") 'NC-DISMINUIR CANTIDAD
        'listaOp.Add("9916") 'NC-DEVOLUCION DE EXISTENCIAS
        'listaOp.Add("9916")
        'listaOp.Add("9914")
        'listaOp.Add("9913")

        Dim consulta As List(Of documentoventaAbarrotesDet) = (From i In ListaDetalle
                                                               Where listaOp.Contains(i.TipoOperacion)).ToList
        If consulta.Count > 0 Then
            'GuiaRemision(ndocumento, consulta)
        End If

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveNotaCreditoFE(ndocumento, DocCaja, documentoSaldo)

        If My.Computer.Network.IsAvailable = True Then
            If My.Computer.Network.Ping("138.128.171.106") Then
                If Gempresas.ubigeo > 0 Then
                    EnviarNotaCreditoElectronico(xcod)
                End If
            End If
        End If

        Dim f As New FormImpresionEquivalencia(xcod)  ' frmVentaNuevoFormato
        f.TIPOiMPESION = 1
        f.DocumentoID = xcod
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        Me.Close()
    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento, Lista As List(Of documentoventaAbarrotesDet))
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .idEntidad = CInt(txtRazonSocial.Tag)
            .monedaDoc = cboMoneda.SelectedValue
            .tasaIgv = CDec(TmpIGV)
            .tipoCambio = CDec(txtTipoCambio.Text)
            .importeMN = CDec(lblTotal.Text)  'TotalesXcanbeceras.TotalMN
            .importeME = 0 'TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As documentoventaAbarrotesDet In Lista

            If r.tipoExistencia <> "GS" Then
                'If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                    'Exit Sub
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                Else
                    Throw New Exception("Ingrese número de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de la guía!")
                    'Exit Sub
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.nombreItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = Nothing  'r.GetValue("um")
                documentoguiaDetalle.cantidad = r.monto1
                documentoguiaDetalle.precioUnitario = r.precioUnitario
                documentoguiaDetalle.precioUnitarioUS = r.precioUnitarioUS
                documentoguiaDetalle.importeMN = r.importeMN
                documentoguiaDetalle.importeME = r.importeME
                'documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub



    Public Sub EnviarNotaCreditoElectronico(idDocumento As Integer)
        Dim articuloSA As New detalleitemsSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            Dim comprobante = documentoSA.GetUbicar_NotaXID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0
            Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)
            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = Gempresas.ubigeo 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
            Factura.FechaEmision = comprobante.fechaDoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            'Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"

                Factura.TotalIgv = comprobante.igv01
                Factura.TotalVenta = comprobante.ImporteNacional
                Factura.Gravadas = comprobante.bi01
                Factura.Exoneradas = comprobante.bi02
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
                Factura.TotalIgv = comprobante.igv01us
                Factura.TotalVenta = comprobante.ImporteExtranjero
                Factura.Gravadas = comprobante.bi01us
                Factura.Exoneradas = comprobante.bi02us
            End If
            Factura.TipoDocumento = tipoDoc

            Factura.TipoOperacion = "0101"

            Factura.TotalIcbper = comprobante.icbper

            'Cargando el Detalle de la Factura

            For Each i In comprobanteDetalle


                Dim Preciounit = i.importeMN / i.monto1
                Dim PreciounitSinIva = i.montokardex / i.monto1

                conteo += 1

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo


                If comprobante.notaCredito = "05" Then
                    DetalleFactura.Cantidad = 1 'i.monto1
                Else
                    DetalleFactura.Cantidad = i.monto1
                End If


                DetalleFactura.CodigoItem = i.idItem
                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If comprobante.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = Preciounit  'i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = PreciounitSinIva 'CalculoBaseImponible(Preciounit, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = Preciounit
                    End If
                    DetalleFactura.TotalVenta = i.montokardex
                ElseIf comprobante.moneda = "2" Then
                    DetalleFactura.PrecioReferencial = i.precioUnitarioUS
                    DetalleFactura.Impuesto = i.montoIgvUS
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = i.precioUnitarioUS
                    End If
                    DetalleFactura.TotalVenta = i.montokardexUS
                End If

                If i.tasaIcbper > 0 Then
                    DetalleFactura.ImpuestoIcbper = i.tasaIcbper
                    DetalleFactura.TotalIcbper = i.montoIcbper
                    DetalleFactura.CantidadBolsa = i.monto1 'cantidadEquivalencia
                Else
                    DetalleFactura.ImpuestoIcbper = 0
                    DetalleFactura.TotalIcbper = 0
                    DetalleFactura.CantidadBolsa = 0
                End If
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next

            'Datos Adicionales 
            Dim DocRel = New Fact.Sunat.Business.Entity.DocumentoRelacionado()
            DocRel.TipoDocumento = comprobante.TipoDocNota
            DocRel.NroDocumento = comprobante.serie & "-" & numeroafect
            Factura.DocumentoRelacionado.Add(DocRel)

            Dim DocDiscrep = New Fact.Sunat.Business.Entity.Discrepancia()
            DocDiscrep.NroReferencia = comprobante.serie & "-" & numeroafect 'comprobante.numeroDoc
            DocDiscrep.Tipo = comprobante.notaCredito 'comprobante.TipoDocNota

            If comprobante.notaCredito = "01" Then
                DocDiscrep.Descripcion = "ANULACION DE LA OPERACION"  '"POR ANULACION"
            ElseIf comprobante.notaCredito = "05" Then
                DocDiscrep.Descripcion = "DESCUENTO POR ITEM"
            ElseIf comprobante.notaCredito = "07" Then
                DocDiscrep.Descripcion = "DEVOLUCION POR ITEM"
            End If
            Factura.Discrepancia.Add(DocDiscrep)

            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then
                UpdateEnvioSunat(comprobante.idDocumento)
                MessageBox.Show("La Nota de Credito se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub

    Public Sub UpdateEnvioSunat(idDoc As Integer)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateEnvioSunat(idDoc)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try

    End Sub

    Sub CalculosxCantidadDolares(totalDisponible As Decimal)

        Dim igvDev As Decimal = 0
        Dim exoneradoDev As Decimal = 0
        Dim gravadoDev As Decimal = 0
        Dim totalDev As Decimal = 0
        Dim Dinero As Decimal = 0
        Dim DineroXDevolver As Decimal = 0
        Dim cant As Decimal = 0
        Dim cantDev As Decimal = 0
        Dim preciounit As Decimal = 0

        Dim AfectarDinero As Decimal = 0

        Dim Tasaicbper As Decimal = 0
        Dim icbperDev As Decimal = 0

        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvVentas.Table.CurrentRecord.GetValue("destino")
            'totalDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")), 2)


            Tasaicbper = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Tasaicbper")), 2)

            preciounit = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pume")), 2)
            cantDev = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Devcantidad")), 2)

            totalDev = cantDev * preciounit
            totalDev = Math.Round(totalDev, 2)

            If cantDev > 0 And Tasaicbper > 0 Then
                icbperDev = cantDev * Tasaicbper
                icbperDev = Math.Round(icbperDev, 2)
            End If


            If Dinero > 0 Then
                AfectarDinero = totalDisponible - Dinero
                If totalDev > AfectarDinero Then
                    DineroXDevolver = totalDev - AfectarDinero
                ElseIf totalDev = AfectarDinero Then
                    DineroXDevolver = 0
                End If
            End If


            If totalDev > 0 Then
                Select Case destino
                    Case "1"
                        gravadoDev = Math.Round(CDec(CalculoBaseImponible(totalDev, iva + 1)), 2)
                        igvDev = totalDev - gravadoDev

                    Case "2"
                        exoneradoDev = totalDev
                End Select


                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", gravadoDev) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", exoneradoDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", igvDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", DineroXDevolver)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", totalDev)

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", gravadoDev * CDec(txtTipoCambio.Text)) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", exoneradoDev * CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", igvDev * CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", DineroXDevolver * CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", totalDev * CDec(txtTipoCambio.Text))


                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbperme", icbperDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", icbperDev * txtTipoCambio.Text)

            Else
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", 0) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", 0)

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", 0) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", 0)

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbperme", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", 0)
            End If
        End If

        totalesImporte()
    End Sub

    Sub CalculosxCantidad(totalDisponible As Decimal)

        Dim igvDev As Decimal = 0
        Dim exoneradoDev As Decimal = 0
        Dim gravadoDev As Decimal = 0
        Dim totalDev As Decimal = 0
        Dim Dinero As Decimal = 0
        Dim DineroXDevolver As Decimal = 0
        Dim cant As Decimal = 0
        Dim cantDev As Decimal = 0
        Dim preciounit As Decimal = 0

        Dim AfectarDinero As Decimal = 0

        Dim Tasaicbper As Decimal = 0
        Dim icbperDev As Decimal = 0




        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvVentas.Table.CurrentRecord.GetValue("destino")
            'totalDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")), 2)

            'preciounit = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pu")), 2)

            preciounit = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")), 2) / Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("cantidad")), 2)



            cantDev = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Devcantidad")), 2)

            Tasaicbper = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Tasaicbper")), 2)

            If Me.dgvVentas.Table.CurrentRecord.GetValue("tipoEx") = TipoExistencia.ServicioGasto Then
            Else
                'If Me.dgvVentas.Table.CurrentRecord.GetValue("unidadComercialDev") = Me.dgvVentas.Table.CurrentRecord.GetValue("unidadComercial") Then
                'Else
                '    cantDev = cantDev * CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("equivalencia"))
                'End If
            End If

            If cantDev > 0 And Tasaicbper > 0 Then
                icbperDev = cantDev * Tasaicbper
                icbperDev = Math.Round(icbperDev, 2)
            End If


            totalDev = cantDev * preciounit
                totalDev = Math.Round(totalDev, 2)

                If Dinero > 0 Then
                    AfectarDinero = totalDisponible - Dinero
                    If totalDev > AfectarDinero Then
                        DineroXDevolver = totalDev - AfectarDinero
                    ElseIf totalDev = AfectarDinero Then
                        DineroXDevolver = 0
                    End If
                End If



                If totalDev > 0 Then
                    Select Case destino
                        Case "1"
                            gravadoDev = Math.Round(CDec(CalculoBaseImponible(totalDev, iva + 1)), 2)
                            igvDev = totalDev - gravadoDev
                        Case "2"
                            exoneradoDev = totalDev
                    End Select


                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", gravadoDev) 'Math.Round(totalMN, 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", exoneradoDev)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", igvDev)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", DineroXDevolver)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", totalDev)

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", gravadoDev * txtTipoCambio.Text) 'Math.Round(totalMN, 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", exoneradoDev * txtTipoCambio.Text)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", igvDev * txtTipoCambio.Text)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", DineroXDevolver * txtTipoCambio.Text)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", (totalDev * txtTipoCambio.Text))


                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", icbperDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbperme", icbperDev * txtTipoCambio.Text)

            Else
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", 0) 'Math.Round(totalMN, 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", 0)

                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", 0) 'Math.Round(totalMN, 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", 0)

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbperme", 0)
            End If
            End If

            totalesImporte()
    End Sub

    Public Sub LimpiarNotaCredito()
        For Each r As Record In dgvVentas.Table.Records
            r.SetValue("Devcantidad", 0)

            r.SetValue("DevDinero", 0)
            r.SetValue("DevDinerome", 0)
            r.SetValue("Devgravado", 0)
            r.SetValue("Devexonerado", 0)
            r.SetValue("Devgravadome", 0)
            r.SetValue("Devexoneradome", 0)
            r.SetValue("Devigv", 0)
            r.SetValue("Devtotal", 0)
            r.SetValue("Devigvme", 0)
            r.SetValue("Devtotalme", 0)
        Next
        totalesImporte()

    End Sub

    Public Sub RecargarDevolucionSeleccion()
        For Each r As Record In dgvVentas.Table.Records
            r.SetValue("Devcantidad", CDec(r.GetValue("cantidad")))

            r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
            r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))

            If r.GetValue("destino") = "1" Then
                r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
                r.SetValue("Devexonerado", 0)
                r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
                r.SetValue("Devexoneradome", 0)

            ElseIf r.GetValue("destino") = "2" Then
                r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
                r.SetValue("Devexonerado", CDec(r.GetValue("importe")))
                r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
                r.SetValue("Devexoneradome", CDec(r.GetValue("importeme")))
            End If

            r.SetValue("Devigv", CDec(r.GetValue("igv")))
            r.SetValue("Devtotal", CDec(r.GetValue("importe")))

            r.SetValue("Devigvme", CDec(r.GetValue("igvme")))
            r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))
        Next
        totalesImporte()

    End Sub



    Public Sub RecargaConServicios()
        For Each r As Record In dgvVentas.Table.Records

            If r.GetValue("tipoEx") = TipoExistencia.ServicioGasto Then

                r.SetValue("Devcantidad", CDec(r.GetValue("cantidad")))
                r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
                r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))

                If r.GetValue("destino") = "1" Then
                    r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
                    r.SetValue("Devexonerado", 0)
                    r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
                    r.SetValue("Devexoneradome", 0)

                ElseIf r.GetValue("destino") = "2" Then
                    r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
                    r.SetValue("Devexonerado", CDec(r.GetValue("importe")))
                    r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
                    r.SetValue("Devexoneradome", CDec(r.GetValue("importeme")))
                End If

                r.SetValue("Devigv", CDec(r.GetValue("igv")))
                r.SetValue("Devtotal", CDec(r.GetValue("importe")))

                r.SetValue("Devigvme", CDec(r.GetValue("igvme")))
                r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))

            End If
        Next
        totalesImporte()

    End Sub

    Public Sub RecargarAnulacion()



        'Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidad", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("cantidad")))
        'Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")))
        'Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")))

        'If Me.dgvVentas.Table.CurrentRecord.GetValue("destino") = "1" Then
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravado")))
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravadome")))
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)

        'ElseIf Me.dgvVentas.Table.CurrentRecord.GetValue("destino") = "2" Then
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravado")))
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravadome")))
        '    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))
        'End If

        'Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("igv")))
        'Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))

        'Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("igvme")))
        'Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))

        'Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("icbper")))



        For Each r As Record In dgvVentas.Table.Records
            r.SetValue("Devcantidad", CDec(r.GetValue("cantidad")))
            r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
            r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))
            r.SetValue("Devicbper", CDec(r.GetValue("icbper")))


            If r.GetValue("destino") = "1" Then
                r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
                r.SetValue("Devexonerado", 0)
                r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
                r.SetValue("Devexoneradome", 0)

            ElseIf r.GetValue("destino") = "2" Then
                r.SetValue("Devgravado", 0)
                r.SetValue("Devexonerado", CDec(r.GetValue("gravado")))
                r.SetValue("Devgravadome", 0)
                r.SetValue("Devexoneradome", CDec(r.GetValue("gravadome")))
            End If

            r.SetValue("Devigv", CDec(r.GetValue("igv")))
            r.SetValue("Devtotal", CDec(r.GetValue("importe")))

            r.SetValue("Devigvme", CDec(r.GetValue("igvme")))
            r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))
        Next
        totalesImporte()

    End Sub

    Public Sub RecargarDevolucion()



        Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidad", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("cantidad")))
        Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")))
        Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")))

        If Me.dgvVentas.Table.CurrentRecord.GetValue("destino") = "1" Then
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravado")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravadome")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)

        ElseIf Me.dgvVentas.Table.CurrentRecord.GetValue("destino") = "2" Then
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravado")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravadome")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))
        End If

        Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("igv")))
        Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))

        Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("igvme")))
        Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))

        Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("icbper")))



        'For Each r As Record In dgvVentas.Table.Records
        '    r.SetValue("Devcantidad", CDec(r.GetValue("cantidad")))
        '    r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
        '    r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))

        '    If r.GetValue("destino") = "1" Then
        '        r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
        '        r.SetValue("Devexonerado", 0)
        '        r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
        '        r.SetValue("Devexoneradome", 0)

        '    ElseIf r.GetValue("destino") = "2" Then
        '        r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
        '        r.SetValue("Devexonerado", CDec(r.GetValue("importe")))
        '        r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
        '        r.SetValue("Devexoneradome", CDec(r.GetValue("importeme")))
        '    End If

        '    r.SetValue("Devigv", CDec(r.GetValue("igv")))
        '    r.SetValue("Devtotal", CDec(r.GetValue("importe")))

        '    r.SetValue("Devigvme", CDec(r.GetValue("igvme")))
        '    r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))
        'Next
        totalesImporte()

    End Sub

    Sub CalculosDolares(totalDisponible As Decimal)

        Dim igvDev As Decimal = 0
        Dim exoneradoDev As Decimal = 0
        Dim gravadoDev As Decimal = 0
        Dim totalDev As Decimal = 0
        Dim Dinero As Decimal = 0
        Dim DineroXDevolver As Decimal = 0

        Dim AfectarDinero As Decimal = 0

        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvVentas.Table.CurrentRecord.GetValue("destino")
            totalDev = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Devtotalme")), 2)
            Dinero = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")), 2)







            If Dinero > 0 Then
                AfectarDinero = totalDisponible - Dinero


                If totalDev > AfectarDinero Then


                    DineroXDevolver = totalDev - AfectarDinero


                ElseIf totalDev = AfectarDinero Then


                    DineroXDevolver = 0

                End If
            End If


            If totalDev > 0 Then
                Select Case destino
                    Case "1"
                        gravadoDev = Math.Round(CDec(CalculoBaseImponible(totalDev, iva + 1)), 2)
                        igvDev = totalDev - gravadoDev

                    Case "2"
                        exoneradoDev = totalDev
                End Select


                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", gravadoDev) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", exoneradoDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", igvDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", DineroXDevolver)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", totalDev * CDec(txtTipoCambio.Text))

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", gravadoDev * CDec(txtTipoCambio.Text)) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", exoneradoDev * CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", igvDev * CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", DineroXDevolver * CDec(txtTipoCambio.Text))



            Else
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", 0) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", 0) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", 0)
            End If


        End If




        totalesImporte()

    End Sub


    Public Sub RecargarDescuentoTotal()



        If Me.dgvVentas.Table.CurrentRecord.GetValue("destino") = "1" Then

            Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidad", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravado")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("igv")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))

            Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidadme", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("gravadome")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("igvme")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))

        ElseIf Me.dgvVentas.Table.CurrentRecord.GetValue("destino") = "2" Then

            Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidad", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importe")))

            Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidadme", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", CDec(0))
            Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("importeme")))
        End If

        'For Each r As Record In dgvVentas.Table.Records

        '    If r.GetValue("destino") = "1" Then

        '        r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
        '        r.SetValue("Devcantidad", CDec(0))
        '        r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
        '        r.SetValue("Devexonerado", CDec(0))
        '        r.SetValue("Devigv", CDec(r.GetValue("igv")))
        '        r.SetValue("Devtotal", CDec(r.GetValue("importe")))

        '        r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))
        '        r.SetValue("Devcantidadme", CDec(0))
        '        r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
        '        r.SetValue("Devexoneradome", CDec(0))
        '        r.SetValue("Devigvme", CDec(r.GetValue("igvme")))
        '        r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))

        '    ElseIf r.GetValue("destino") = "2" Then

        '        r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
        '        r.SetValue("Devcantidad", CDec(0))
        '        r.SetValue("Devgravado", CDec(0))
        '        r.SetValue("Devexonerado", CDec(r.GetValue("importe")))
        '        r.SetValue("Devigv", CDec(0))
        '        r.SetValue("Devtotal", CDec(r.GetValue("importe")))

        '        r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))
        '        r.SetValue("Devcantidadme", CDec(0))
        '        r.SetValue("Devgravadome", CDec(0))
        '        r.SetValue("Devexoneradome", CDec(r.GetValue("importeme")))
        '        r.SetValue("Devigvme", CDec(0))
        '        r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))
        '    End If

        'Next
        totalesImporte()
    End Sub

    Sub Calculos(totalDisponible As Decimal)

        Dim igvDev As Decimal = 0
        Dim exoneradoDev As Decimal = 0
        Dim gravadoDev As Decimal = 0
        Dim totalDev As Decimal = 0
        Dim Dinero As Decimal = 0
        Dim DineroXDevolver As Decimal = 0

        Dim AfectarDinero As Decimal = 0

        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvVentas.Table.CurrentRecord.GetValue("destino")
            totalDev = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")), 2)







            If Dinero > 0 Then
                AfectarDinero = totalDisponible - Dinero


                If totalDev > AfectarDinero Then


                    DineroXDevolver = totalDev - AfectarDinero


                ElseIf totalDev = AfectarDinero Then


                    DineroXDevolver = 0

                End If
            End If


            If totalDev > 0 Then
                Select Case destino
                    Case "1"
                        gravadoDev = Math.Round(CDec(CalculoBaseImponible(totalDev, iva + 1)), 2)
                        igvDev = totalDev - gravadoDev

                    Case "2"
                        exoneradoDev = totalDev
                End Select


                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", gravadoDev) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", exoneradoDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", igvDev)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", DineroXDevolver)

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", totalDev / CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", gravadoDev / CDec(txtTipoCambio.Text)) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", exoneradoDev / CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", igvDev / CDec(txtTipoCambio.Text))
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", DineroXDevolver / CDec(txtTipoCambio.Text))

            Else
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", 0) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", 0) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", 0)
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", 0)
            End If


        End If




        totalesImporte()
    End Sub

    Public Sub CARGARCOMBOS(cant As Integer)

        Dim ListaMoneda As New List(Of tabladetalle)
        Dim objetoMoneda As tabladetalle

        Dim ListaOperacion As New List(Of tabladetalle)
        Dim objetoNota As tabladetalle

        objetoNota = New tabladetalle
        objetoNota.descripcion = "DESCUENTO POR ITEM"
        objetoNota.codigoDetalle = "05"
        ListaOperacion.Add(objetoNota)

        If cant = 0 Then
            objetoNota = New tabladetalle
            objetoNota.descripcion = "ANULACION DE LA OPERACION"
            objetoNota.codigoDetalle = "01"
            ListaOperacion.Add(objetoNota)
        End If

        objetoNota = New tabladetalle
        objetoNota.descripcion = "DEVOLUCION POR ITEM"
        objetoNota.codigoDetalle = "07"
        ListaOperacion.Add(objetoNota)


        cboOperacionNotaCredito.DisplayMember = "descripcion"
        cboOperacionNotaCredito.ValueMember = "codigoDetalle"
        cboOperacionNotaCredito.DataSource = ListaOperacion


        objetoMoneda = New tabladetalle
        objetoMoneda.descripcion = "NACIONAL"
        objetoMoneda.codigoDetalle = "1"
        ListaMoneda.Add(objetoMoneda)

        objetoMoneda = New tabladetalle
        objetoMoneda.descripcion = "EXTRANJERA"
        objetoMoneda.codigoDetalle = "2"
        ListaMoneda.Add(objetoMoneda)

        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DataSource = ListaMoneda


        cboMoneda.BackColor = Color.White

    End Sub

    Public Sub totalesImporte()
        Dim igv As Decimal = 0
        Dim gravado As Decimal = 0
        Dim exonerado As Decimal = 0
        Dim total As Decimal = 0
        Dim dinero As Decimal = 0

        Dim igvme As Decimal = 0
        Dim gravadome As Decimal = 0
        Dim exoneradome As Decimal = 0
        Dim totalme As Decimal = 0
        Dim dinerome As Decimal = 0

        Dim icbper As Decimal = 0
        Dim icbperme As Decimal = 0



        For Each r As Record In dgvVentas.Table.Records

            igv += CDec(r.GetValue("Devigv"))
            gravado += CDec(r.GetValue("Devgravado"))
            exonerado += CDec(r.GetValue("Devexonerado"))
            total += CDec(r.GetValue("Devtotal"))
            dinero += CDec(r.GetValue("DevDinero"))
            icbper += CDec(r.GetValue("Devicbper"))

            igvme += CDec(r.GetValue("Devigvme"))
            gravadome += CDec(r.GetValue("Devgravadome"))
            exoneradome += CDec(r.GetValue("Devexoneradome"))
            totalme += CDec(r.GetValue("Devtotalme"))
            dinerome += CDec(r.GetValue("DevDinerome"))
            icbperme += CDec(r.GetValue("Devicbperme"))
        Next


        If cboMoneda.Text = "NACIONAL" Then
            lblIgv.Text = Math.Round(igv, 2)
            lblGravado.Text = Math.Round(gravado, 2)
            lblExonerado.Text = Math.Round(exonerado, 2)
            lblTotal.Text = Math.Round(total + icbper, 2)
            lblReclamacionDinero.Text = Math.Round(dinero, 2)
            lblIcbper.Text = Math.Round(icbper, 2)

            'DigitalGauge2.Value = Math.Round(total + icbper, 2)

            lblConvIgv.Text = Math.Round(igvme, 2)
            lblConvGravado.Text = Math.Round(gravadome, 2)
            lblConvExonerado.Text = Math.Round(exoneradome, 2)
            lblConvTotal.Text = Math.Round(totalme + icbperme, 2)
            lblConvReclamacionDinero.Text = Math.Round(dinerome, 2)
            lblConvIcbperMe.Text = Math.Round(icbperme, 2)

        ElseIf cboMoneda.Text = "EXTRANJERA" Then
            lblIgv.Text = Math.Round(igvme, 2)
            lblGravado.Text = Math.Round(gravadome, 2)
            lblExonerado.Text = Math.Round(exoneradome, 2)
            lblTotal.Text = Math.Round(totalme + icbperme, 2)
            lblReclamacionDinero.Text = Math.Round(dinerome, 2)
            lblIcbper.Text = Math.Round(icbperme, 2)

            'DigitalGauge2.Value = Math.Round(totalme + icbperme, 2)

            lblConvIgv.Text = Math.Round(igv, 2)
            lblConvGravado.Text = Math.Round(gravado, 2)
            lblConvExonerado.Text = Math.Round(exonerado, 2)
            lblConvTotal.Text = Math.Round(total + icbper, 2)
            lblConvReclamacionDinero.Text = Math.Round(dinero, 2)
            lblConvIcbperMe.Text = Math.Round(icbper, 2)
        End If


    End Sub

    Public Sub camposmonedas()

        If (cboMoneda.SelectedValue = "1") Then
            dgvVentas.TableDescriptor.Columns("pu").Width = 0
            dgvVentas.TableDescriptor.Columns("pume").Width = 0
            dgvVentas.TableDescriptor.Columns("igv").Width = 0
            dgvVentas.TableDescriptor.Columns("igvme").Width = 0
            dgvVentas.TableDescriptor.Columns("gravado").Width = 0
            dgvVentas.TableDescriptor.Columns("gravadome").Width = 0
            dgvVentas.TableDescriptor.Columns("importe").Width = 70
            dgvVentas.TableDescriptor.Columns("importeme").Width = 0
            dgvVentas.TableDescriptor.Columns("pagos").Width = 70
            dgvVentas.TableDescriptor.Columns("pagosme").Width = 0


            dgvVentas.TableDescriptor.Columns("icbper").Width = 70
            dgvVentas.TableDescriptor.Columns("Devicbper").Width = 70
            dgvVentas.TableDescriptor.Columns("Devicbperme").Width = 0
            dgvVentas.TableDescriptor.Columns("Tasaicbper").Width = 70

            dgvVentas.TableDescriptor.Columns("Devgravado").Width = 70
            dgvVentas.TableDescriptor.Columns("Devgravadome").Width = 0
            dgvVentas.TableDescriptor.Columns("Devexonerado").Width = 70
            dgvVentas.TableDescriptor.Columns("Devexoneradome").Width = 0
            dgvVentas.TableDescriptor.Columns("Devinafecto").Width = 0
            dgvVentas.TableDescriptor.Columns("Devinafectome").Width = 0
            dgvVentas.TableDescriptor.Columns("Devexportacion").Width = 0
            dgvVentas.TableDescriptor.Columns("Devexportacionme").Width = 0
            dgvVentas.TableDescriptor.Columns("Devdescuento").Width = 0
            dgvVentas.TableDescriptor.Columns("Devdescuentome").Width = 0
            dgvVentas.TableDescriptor.Columns("Devigv").Width = 70
            dgvVentas.TableDescriptor.Columns("Devigvme").Width = 0
            dgvVentas.TableDescriptor.Columns("Devtotal").Width = 70
            dgvVentas.TableDescriptor.Columns("Devtotalme").Width = 0
            dgvVentas.TableDescriptor.Columns("DevDinero").Width = 70
            dgvVentas.TableDescriptor.Columns("DevDinerome").Width = 0
        ElseIf (cboMoneda.SelectedValue = "2") Then
            dgvVentas.TableDescriptor.Columns("pu").Width = 0
            dgvVentas.TableDescriptor.Columns("pume").Width = 0
            dgvVentas.TableDescriptor.Columns("igv").Width = 0
            dgvVentas.TableDescriptor.Columns("igvme").Width = 0
            dgvVentas.TableDescriptor.Columns("gravado").Width = 0
            dgvVentas.TableDescriptor.Columns("gravadome").Width = 0
            dgvVentas.TableDescriptor.Columns("importe").Width = 0
            dgvVentas.TableDescriptor.Columns("importeme").Width = 70
            dgvVentas.TableDescriptor.Columns("pagos").Width = 0
            dgvVentas.TableDescriptor.Columns("pagosme").Width = 70

            dgvVentas.TableDescriptor.Columns("Devgravado").Width = 0
            dgvVentas.TableDescriptor.Columns("Devgravadome").Width = 70
            dgvVentas.TableDescriptor.Columns("Devexonerado").Width = 0
            dgvVentas.TableDescriptor.Columns("Devexoneradome").Width = 70
            dgvVentas.TableDescriptor.Columns("Devinafecto").Width = 0
            dgvVentas.TableDescriptor.Columns("Devinafectome").Width = 0
            dgvVentas.TableDescriptor.Columns("Devexportacion").Width = 0
            dgvVentas.TableDescriptor.Columns("Devexportacionme").Width = 0
            dgvVentas.TableDescriptor.Columns("Devdescuento").Width = 0
            dgvVentas.TableDescriptor.Columns("Devdescuentome").Width = 0
            dgvVentas.TableDescriptor.Columns("Devigv").Width = 0
            dgvVentas.TableDescriptor.Columns("Devigvme").Width = 70
            dgvVentas.TableDescriptor.Columns("Devtotal").Width = 0
            dgvVentas.TableDescriptor.Columns("Devtotalme").Width = 70
            dgvVentas.TableDescriptor.Columns("DevDinero").Width = 0
            dgvVentas.TableDescriptor.Columns("DevDinerome").Width = 70

            dgvVentas.TableDescriptor.Columns("icbper").Width = 70
            dgvVentas.TableDescriptor.Columns("Devicbper").Width = 0
            dgvVentas.TableDescriptor.Columns("Devicbperme").Width = 70
            dgvVentas.TableDescriptor.Columns("Tasaicbper").Width = 70

        End If

    End Sub

    Public Sub UbicarDocumento(idDocumento As Integer)
        Dim articuloSA As New detalleitemsSA
        Try

            Dim documentoSA As New documentoVentaAbarrotesSA
            Dim documento = documentoSA.DocumentoAfectadoNC(New documentoventaAbarrotes With {.idDocumento = idDocumento,
                                                            .estadoCobro = "PN"})

            txtSerieAfectado.Text = documento.serieVenta
            txtNumeroAfectado.Text = documento.numeroVenta
            txtTipoDoc.Text = documento.tipoDocumento
            txtRazonSocial.Text = documento.nombreCliente
            txtRazonSocial.Tag = documento.idCliente
            txtDniRuc.Text = documento.rucCliente
            txtTipoCambio.Text = documento.tipoCambio
            txtIdDocumento.Text = documento.idDocumento

            'If documento.moneda = "1" Then
            '    cboMoneda.Text = "NACIONAL"
            'ElseIf documento.moneda = "2" Then
            '    cboMoneda.Text = "EXTRANJERA"
            'End If
            cboMoneda.SelectedValue = documento.moneda

            'listaProductosVendido = documento.documentoventaAbarrotesDet.ToList


            For Each i In documento.documentoventaAbarrotesDet 'documento.documentoventaAbarrotesDet
                If i.monto1 > 0 Then


                    Dim PU = 0.0
                    Dim PUME = 0.0
                    ' If i.CantVenta > 0 Then

                    'PU = (i.importeMN / i.monto1)
                    'PUME = (i.importeME / i.monto1)

                    'Dim ImpVenta = PU * i.CantVenta
                    'Dim ImpVentaME = PUME * i.CantVenta

                    'i.monto1 += i.CantVenta
                    'i.importeMN += ImpVenta
                    'i.importeME += ImpVentaME

                    PU = (i.importeMN / i.monto1)
                        PUME = (i.importeME / i.monto1)

                    'Else
                    '    PU = (i.importeMN / i.monto1)
                    '    PUME = (i.importeME / i.monto1)

                    'End If

                    'Dim prod = articuloSA.GetUbicaProductoID(i.idItem)
                    'i.CustomProducto = prod


                    'Dim equivmin = 0

                    'If i.tipoExistencia = TipoExistencia.ServicioGasto Then

                    'Else

                    '    Dim minimo = (From z In prod.detalleitem_equivalencias
                    '                  Where z.contenido_neto = 1).FirstOrDefault

                    '    equivmin = minimo.equivalencia_id

                    '    Dim valorescero = (From z In prod.detalleitem_equivalencias
                    '                       Where z.contenido_neto = 0).Count

                    '    If valorescero > 0 Then
                    '        MessageBox.Show("Debe configurar el contenido en  : " & i.nombreItem & " " & "y debe ser mayor a 0")
                    '        dgvVentas.Table.Records.DeleteAll()
                    '        Exit Sub
                    '    End If


                    '    If minimo Is Nothing Then
                    '        MessageBox.Show("Debe configurar el contenido en  : " & i.nombreItem & " " & "y debe ser mayor a 0")
                    '        dgvVentas.Table.Records.DeleteAll()
                    '        Exit Sub
                    '    End If


                    'End If




                    Me.dgvVentas.Table.AddNewRecord.SetCurrent()
                    Me.dgvVentas.Table.AddNewRecord.BeginEdit()
                    Me.dgvVentas.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("destino", i.destino)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("lote", i.codigoLote)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("idItem", i.idItem)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("descripcion", i.nombreItem)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("tipoEx", i.tipoExistencia)
                    'Me.dgvVentas.Table.CurrentRecord.SetValue("almacenRef", i.idAlmacenOrigen)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("unidad", i.unidad1)
                    'Me.dgvVentas.Table.CurrentRecord.SetValue("estadocobro", i.estadoPago)
                    Select Case i.estadoPago
                        Case TIPO_VENTA.PAGO.COBRADO
                            Me.dgvVentas.Table.CurrentRecord.SetValue("estadocobro", "Pagado")
                        Case Else
                            Me.dgvVentas.Table.CurrentRecord.SetValue("estadocobro", "Pendiente")
                    End Select

                    Me.dgvVentas.Table.CurrentRecord.SetValue("cantidad", i.monto1) 'i.canDisponible) 

                    If i.tipoExistencia = TipoExistencia.ServicioGasto Then

                        Me.dgvVentas.Table.CurrentRecord.SetValue("pu", i.importeMN)
                        Me.dgvVentas.Table.CurrentRecord.SetValue("pume", i.importeME)

                    Else

                        Me.dgvVentas.Table.CurrentRecord.SetValue("pu", i.importeMN / i.monto1)
                        Me.dgvVentas.Table.CurrentRecord.SetValue("pume", 0)

                    End If


                    Me.dgvVentas.Table.CurrentRecord.SetValue("igv", i.montoIgv)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("gravado", i.montokardex)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("gravadome", i.montokardexUS)

                    Me.dgvVentas.Table.CurrentRecord.SetValue("importe", i.importeMN)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("importeme", i.importeME)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("pagos", i.PagoSumaMN)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("pagosme", i.PagoSumaME)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devcantidad", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravado", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexonerado", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devinafecto", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devinafectome", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexportacion", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexportacionme", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devdescuento", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devdescuentome", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigv", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotal", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinero", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", 0)
                    'Me.dgvVentas.Table.CurrentRecord.SetValue("cantIni", 0)
                    'Me.dgvVentas.Table.CurrentRecord.SetValue("cantinvini", 0)

                    Me.dgvVentas.Table.CurrentRecord.SetValue("icbper", i.montoIcbper)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbper", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devicbperme", 0)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Tasaicbper", i.tasaIcbper)

                    'If i.tipoExistencia = TipoExistencia.ServicioGasto Then

                    'Else
                    '    Me.dgvVentas.Table.CurrentRecord.SetValue("unidadComercial", i.equivalencia_id)
                    '    Me.dgvVentas.Table.CurrentRecord.SetValue("unidadComercialDev", equivmin) 'minimo.equivalencia_id) ' i.equivalencia_id)
                    '    Dim eq = i.CustomProducto.detalleitem_equivalencias.Where(Function(r) r.equivalencia_id = i.equivalencia_id).SingleOrDefault
                    '    i.CustomEquivalencia = eq

                    '    If eq.contenido_neto Is Nothing Then

                    '        MessageBox.Show("El Item : " & i.nombreItem & " " & "Debe Tener Contenido Neto para poder realizar Nota de credito")
                    '        dgvVentas.Table.Records.DeleteAll()
                    '        Exit Sub
                    '    Else

                    '        If eq.contenido_neto > 0 Then


                    '            Me.dgvVentas.Table.CurrentRecord.SetValue("equivalencia", eq.fraccionUnidad.GetValueOrDefault)
                    '            ' Me.dgvVentas.Table.CurrentRecord.SetValue("cantDisponible", i.monto1.GetValueOrDefault * eq.contenido_neto.GetValueOrDefault)
                    '            'martin ultimo

                    '            Dim contenidototal = i.canDisponible * eq.contenido_neto

                    '            Dim newdecimal = (eq.fraccionUnidad * i.canDisponible) / contenidototal 'i.canDisponible / contenidototal

                    '            Dim newdecimal1 = i.canDisponible - FormatNumber(newdecimal, 2)

                    '            Dim toto = contenidototal - 1
                    '            Dim otro = FormatNumber(newdecimal, 2) * toto

                    '            Dim tercer = Math.Round(FormatNumber(i.canDisponible, 2) - FormatNumber(otro, 2), 2)

                    '            If i.monto1 = tercer Then
                    '                Me.dgvVentas.Table.CurrentRecord.SetValue("cantDisponible", 1)

                    '            ElseIf (i.cantidadCredito * eq.contenido) = i.canDisponible Then

                    '                Me.dgvVentas.Table.CurrentRecord.SetValue("cantDisponible", 0)

                    '            ElseIf i.cantidadCredito = 0 Then
                    '                Me.dgvVentas.Table.CurrentRecord.SetValue("cantDisponible", contenidototal)
                    '            Else
                    '                If eq.contenido_neto = 1 Then

                    '                    Dim cant = i.cantidadCredito
                    '                    Dim decimalx = newdecimal
                    '                    Dim otrosss = cant / decimalx

                    '                    Dim nuevo2 = FormatNumber(otrosss, 0)
                    '                    Me.dgvVentas.Table.CurrentRecord.SetValue("cantDisponible", contenidototal - nuevo2)

                    '                Else
                    '                    Dim nuevo2 = FormatNumber(i.cantidadCredito, 2) / FormatNumber(newdecimal, 2)
                    '                    Me.dgvVentas.Table.CurrentRecord.SetValue("cantDisponible", contenidototal - nuevo2)
                    '                End If

                    '            End If


                    '        Else
                    '            MessageBox.Show("Debe configurar el contenido en  : " & i.nombreItem & " " & "debe ser mayor a 0")
                    '            dgvVentas.Table.Records.DeleteAll()
                    '            Exit Sub
                    '        End If


                    '    End If

                    '    End If


                    Me.dgvVentas.Table.AddNewRecord.EndEdit()
                End If
            Next

            camposmonedas()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("secuencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("lote")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("almacenRef")
        dt.Columns.Add("unidad")
        dt.Columns.Add("estadocobro")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pu")
        dt.Columns.Add("pume")

        dt.Columns.Add("igv")
        dt.Columns.Add("igvme")
        dt.Columns.Add("gravado")
        dt.Columns.Add("gravadome")

        dt.Columns.Add("importe")
        dt.Columns.Add("importeme")


        dt.Columns.Add("pagos")
        dt.Columns.Add("pagosme")
        dt.Columns.Add("Devcantidad")
        dt.Columns.Add("Devgravado")
        dt.Columns.Add("Devgravadome")
        dt.Columns.Add("Devexonerado")
        dt.Columns.Add("Devexoneradome")
        dt.Columns.Add("Devinafecto")
        dt.Columns.Add("Devinafectome")
        dt.Columns.Add("Devexportacion")
        dt.Columns.Add("Devexportacionme")
        dt.Columns.Add("Devdescuento")
        dt.Columns.Add("Devdescuentome")
        dt.Columns.Add("Devigv")
        dt.Columns.Add("Devigvme")
        dt.Columns.Add("Devtotal")
        dt.Columns.Add("Devtotalme")
        dt.Columns.Add("DevDinero")
        dt.Columns.Add("DevDinerome")
        'dt.Columns.Add("unidadComercial")
        'dt.Columns.Add("equivalencia")
        'dt.Columns.Add("cantDisponible")
        'dt.Columns.Add("unidadComercialDev")
        'dt.Columns.Add("cantIni")
        'dt.Columns.Add("cantinvini")

        dt.Columns.Add("icbper")
        dt.Columns.Add("Devicbper")
        dt.Columns.Add("Devicbperme")
        dt.Columns.Add("Tasaicbper")



        dgvVentas.DataSource = dt
        dgvVentas.TopLevelGroupOptions.ShowCaption = True
    End Sub

#End Region

    Private Sub formNotaCreditoVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtruc_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedValueChanged

        Dim valor = cboMoneda.Text
        If valor.Length > 0 Then
            Dim valor2 = cboMoneda.SelectedValue
            If valor2.Length > 0 Then
                Select Case cboMoneda.SelectedValue
                    Case "1", "2"
                        camposmonedas()
                End Select
            End If
        End If
    End Sub

    Private Sub dgvVentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentas.TableControlCellClick

    End Sub

    Private Sub dgvVentas_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvVentas.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvVentas.TableControl.CurrentCell
        cc.ConfirmChanges()
        Dim impDisponible As Decimal = 0
        Try
            If Not IsNothing(cc) Then
                Select Case cc.ColIndex


                    Case 21 ' CANTIDAD


                        Dim r As Record = dgvVentas.Table.CurrentRecord
                        Dim text As String = cc.Renderer.ControlText

                        If text.Trim.Length > 0 Then
                            Dim value As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = value


                            'If r.GetValue("unidadComercialDev") = r.GetValue("unidadComercial") Then
                            'impDisponible = r.GetValue("cantidad")
                            'Else
                            impDisponible = r.GetValue("cantidad") 'r.GetValue("cantDisponible") 
                            'End If


                            Dim totalDisponible = r.GetValue("importe")
                            Dim totalDisponibleme = r.GetValue("importeme")

                            If value = impDisponible Then
                                'recargar todo para no recalcular
                                RecargarDevolucion()
                                'If impDisponible = 1 Then
                                '    RecargarDevolucion()
                                'ElseIf impDisponible > 1 Then

                                '    Dim valornew = value

                                '    cc.Renderer.ControlValue = 0
                                '    cc.ConfirmChanges()
                                '    cc.EndEdit()

                                '    If cboMoneda.SelectedValue = 1 Then
                                '        CalculosxCantidad(totalDisponible)
                                '    ElseIf cboMoneda.SelectedValue = 2 Then
                                '        CalculosxCantidadDolares(totalDisponibleme)
                                '    End If
                                '    MessageBox.Show("La devolucion debe ser en dos partes " & value - 1 & " y " & "1")
                                '    Exit Sub

                                'End If

                            ElseIf value > impDisponible Then
                                cc.Renderer.ControlValue = 0
                                cc.ConfirmChanges()
                                cc.EndEdit()

                                If cboMoneda.SelectedValue = 1 Then
                                    CalculosxCantidad(totalDisponible)
                                ElseIf cboMoneda.SelectedValue = 2 Then
                                    CalculosxCantidadDolares(totalDisponibleme)
                                End If
                                MessageBox.Show("La Cantidad disponible es: " & impDisponible)
                                Exit Sub
                            Else
                                If cboMoneda.SelectedValue = 1 Then
                                    CalculosxCantidad(totalDisponible)
                                ElseIf cboMoneda.SelectedValue = 2 Then
                                    CalculosxCantidadDolares(totalDisponibleme)
                                End If
                            End If

                        End If


                    Case 34 ' IMPORTES

                        Dim r As Record = dgvVentas.Table.CurrentRecord
                        Dim text As String = cc.Renderer.ControlText
                        If text.Trim.Length > 0 Then
                            Dim value As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = value

                            impDisponible = r.GetValue("importe")
                            'If value >= impDisponible Then


                            If value = impDisponible Then

                                RecargarDescuentoTotal()

                            ElseIf value > impDisponible Then
                                cc.Renderer.ControlValue = 0
                                cc.ConfirmChanges()
                                cc.EndEdit()
                                Calculos(impDisponible)
                                'lblEstado.Text = "El importe debe ser menor a: " & impDisponible
                                'PanelError.Visible = True
                                'Timer1.Enabled = True
                                'TiempoEjecutar(10)
                                MessageBox.Show("El importe debe ser menor a: " & impDisponible)
                                Exit Sub
                            Else
                                Calculos(impDisponible)
                            End If




                        End If



                    Case 35 ' IMPORTES DOLARES


                        Dim r As Record = dgvVentas.Table.CurrentRecord
                        Dim text As String = cc.Renderer.ControlText
                        If text.Trim.Length > 0 Then
                            Dim value As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = value

                            impDisponible = r.GetValue("importeme")
                            'If value >= impDisponible Then

                            If value = impDisponible Then

                                RecargarDescuentoTotal()

                            ElseIf value > impDisponible Then
                                cc.Renderer.ControlValue = 0
                                cc.ConfirmChanges()
                                cc.EndEdit()
                                CalculosDolares(impDisponible)
                                'lblEstado.Text = "El importe debe ser menor a: " & impDisponible
                                'PanelError.Visible = True
                                'Timer1.Enabled = True
                                'TiempoEjecutar(10)
                                MessageBox.Show("El importe debe ser menor a: " & impDisponible)
                                Exit Sub
                            Else
                                CalculosDolares(impDisponible)
                            End If




                        End If

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub









    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("U.M.")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("fraccion")

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        Dim min = lista.Min(Function(o) o.contenido_neto).GetValueOrDefault
        'Dim max = lista.Max(Function(o) o.contenido_neto).GetValueOrDefault

        Dim itemMin = lista.Find(Function(o) o.contenido_neto = min)
        'Dim itemMax = lista.Find(Function(o) o.contenido_neto = max)

        Dim lista3 As New List(Of detalleitem_equivalencias)

        'lista3.Add(itemMax)
        lista3.Add(itemMin)

        For Each i In lista3
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Function GetEquivalenciasFull(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("U.M.")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("fraccion")

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Sub dgvVentas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvVentas.QueryCellStyleInfo
        'If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "unidadComercial" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

        '    Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("secuencia").ToString()
        '    Dim prod = listaProductosVendido.Where(Function(o) o.secuencia = value).Single
        '    If prod.tipoExistencia = TipoExistencia.ServicioGasto Then

        '    Else
        '        Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

        '        '   If value = "a" Then
        '        e.Style.DataSource = GetEquivalenciasFull(listaEquivalencias)
        '        e.Style.DisplayMember = "unidadComercial"
        '        e.Style.ValueMember = "equivalencia_id"
        '    End If

        '    'ElseIf value = "b" Then
        '    '    e.Style.DataSource = ZipCodes
        '    '    e.Style.DisplayMember = "City"
        '    '    e.Style.ValueMember = "Class"
        '    'ElseIf value = "c" Then
        '    '    e.Style.DataSource = Shippers
        '    '    e.Style.DisplayMember = "Shipper ID"
        '    '    e.Style.ValueMember = "Company Name"
        '    'End If

        'ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "unidadComercialDev" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
        '    Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("secuencia").ToString()
        '    Dim prod = listaProductosVendido.Where(Function(o) o.secuencia = value).Single
        '    If prod.tipoExistencia = TipoExistencia.ServicioGasto Then

        '    Else
        '        Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

        '        Dim unidadComercialVenta = listaEquivalencias.Where(Function(q) q.equivalencia_id = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("unidadComercial").ToString()).SingleOrDefault

        '        'Dim maximo = listaEquivalencias.Where(Function(u) u.contenido_neto <= unidadComercialVenta.contenido_neto.GetValueOrDefault).Max(Function(u) u.contenido_neto).GetValueOrDefault
        '        'Dim minimo = listaEquivalencias.Where(Function(u) u.contenido_neto <= unidadComercialVenta.contenido_neto.GetValueOrDefault).ToList

        '        Dim lista2 = listaEquivalencias.Where(Function(u) u.contenido_neto <= unidadComercialVenta.contenido_neto.GetValueOrDefault).ToList

        '        '   If value = "a" Then
        '        e.Style.DataSource = GetEquivalencias(lista2)
        '        e.Style.DisplayMember = "unidadComercial"
        '        e.Style.ValueMember = "equivalencia_id"


        '    End If


        'End If



        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement



            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "Devcantidad")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("tipoEx").ToString()
                'Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single
                Select Case value
                    Case TipoExistencia.ServicioGasto
                        'e.Style.BackColor = Color.Yellow
                        'e.Style.TextColor = Color.Black
                        e.Style.Enabled = False
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "unidadComercial")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("tipoEx").ToString()

                Select Case value
                    Case TipoExistencia.ServicioGasto
                        e.Style.Enabled = False
                    Case Else
                        e.Style.Enabled = True
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "unidadComercialDev")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("tipoEx").ToString()

                Select Case value
                    Case TipoExistencia.ServicioGasto
                        e.Style.Enabled = False
                    Case Else
                        e.Style.Enabled = True
                End Select

                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                '    Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                '    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single
                '    Select Case prod.tipoExistencia
                '        Case TipoExistencia.ServicioGasto
                '            e.Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder)
                '            e.Style.TextColor = Color.Black
                '            e.Style.Enabled = False
                '            e.Style.Text = 1
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select



            End If


        End If

    End Sub

    Private Sub dgvVentas_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvVentas.TableControlCurrentCellCloseDropDown
        'Dim cc As GridCurrentCell = dgvVentas.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'e.TableControl.CurrentCell.EndEdit()
        'e.TableControl.Table.TableDirty = True
        'e.TableControl.Table.EndEdit()

        'If cc.ColIndex > -1 Then
        '    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


        '    If style.TableCellIdentity.Column.Name = "unidadComercialDev" Then

        '        'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
        '        'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()


        '        '  Dim CodigoEQ As String = cc.Renderer.ControlText
        '        'Dim r As Record = GridTotales.Table.CurrentRecord
        '        If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
        '            cc.EndEdit()
        '            Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("secuencia")

        '            Dim cantidadVenta = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("cantidad"))

        '            Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("unidadComercialDev")

        '            Dim producto = listaProductosVendido.Where(Function(o) o.secuencia = codiProducto).Single

        '            Dim Unidades = producto.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault

        '            'style.TableCellIdentity.Table.CurrentRecord.SetValue("cantDisponible", cantidadVenta * Unidades.contenido_neto.GetValueOrDefault)

        '            style.TableCellIdentity.Table.CurrentRecord.SetValue("equivalencia", Unidades.fraccionUnidad.GetValueOrDefault)
        '            'producto.CustomEquivalencia = Unidades

        '            'If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
        '            '    If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
        '            '        Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

        '            '        If cataPredeterminado IsNot Nothing Then
        '            '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

        '            '        ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
        '            '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
        '            '        End If
        '            '    Else
        '            '        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '        Me.Cursor = Cursors.Default
        '            '        Exit Sub
        '            '    End If
        '            'Else
        '            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '    Me.Cursor = Cursors.Default
        '            '    Exit Sub
        '            'End If

        '            'Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
        '            'Dim cat As detalleitemequivalencia_catalogos = Nothing

        '            'If IsNumeric(idCatalogo) Then
        '            '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
        '            'ElseIf idCatalogo.ToString.Trim.Length > 0 Then
        '            '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault
        '            'Else
        '            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '    Me.Cursor = Cursors.Default
        '            '    Exit Sub
        '            'End If

        '            'If idCatalogo.ToString.Trim.Length > 0 Then
        '            '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
        '            '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
        '            'Else
        '            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '    Me.Cursor = Cursors.Default
        '            '    Exit Sub
        '            'End If

        '            'If cat IsNot Nothing Then
        '            '    style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
        '            'Else

        '            'End If


        '            '    'Agregando Producto
        '            '    '-----------------------------------------------------------------------------------------
        '            '    '*******************************************************************************************

        '            '    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
        '            '    Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
        '            '    '   If inp IsNot Nothing Then
        '            '    If IsNumeric(inp) Then
        '            '        If (inp) > 0 Then

        '            '            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), producto.codigodetalle, Unidades.equivalencia_id, cat.idCatalogo)
        '            '            precioVenta = precioventaFormula

        '            '            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, producto.codigodetalle, precioventaFormula, Unidades, cat.idCatalogo)
        '            '            UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
        '            '            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
        '            '            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
        '            '        Else
        '            '            MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '            Me.Cursor = Cursors.Default
        '            '            Exit Sub
        '            '        End If
        '            '    Else
        '            '        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '        Me.Cursor = Cursors.Default
        '            '        Exit Sub
        '            '    End If

        '            'r.SetValue("cboPrecios", String.Empty)
        '            'r.SetValue("cboEquivalencias", String.Empty)
        '            'r.SetValue("importeMn", 0)
        '            'End If



        '            'Dim r = style.TableCellIdentity.Table.CurrentRecord
        '            'If r IsNot Nothing Then
        '            '    Dim value As String = r.GetValue("idItem").ToString()
        '            '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
        '            '    Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

        '            '    If idEquiva.Trim.Length > 0 Then
        '            '        Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
        '            '        Dim idCat = r.GetValue("cboPrecios").ToString()
        '            '        If idCat.Trim.Length > 0 Then
        '            '            Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

        '            '            UCPreciosCanastaVenta.ListInventario.Items.Clear()

        '            '            If OBJCatalog IsNot Nothing Then
        '            '                Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
        '            '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
        '            '            End If
        '            '        Else
        '            '        End If
        '            '    End If
        '            'End If

        '            'Dim text As String = cc.Renderer.ControlText

        '            'Dim r As Record = GridTotales.Table.CurrentRecord
        '            'If r IsNot Nothing Then
        '            '    Dim value As String = r.GetValue("idItem").ToString()
        '            '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
        '            '    Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

        '            '    If idEquiva.Trim.Length > 0 Then
        '            '        Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single

        '            '        Dim idCat = r.GetValue("cboPrecios").ToString()
        '            '        Dim style2 As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex + 1)
        '            '        If idCat.Trim.Length > 0 Then

        '            '            Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

        '            '            'Dim listaCatalog = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
        '            '            Dim listaPreciosVenta = GetDetallePrecios(OBJCatalog.detalleitemequivalencia_precios.ToList)


        '            '            'style2.DataSource = listaPreciosVenta 'OBJCatalog.detalleitemequivalencia_precios.ToList
        '            '            'style2.DisplayMember = "precio"
        '            '            'style2.ValueMember = "precio_id"

        '            '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        '            '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
        '            '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
        '            '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DataSource = listaPreciosVenta
        '            '            '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        '            '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        '            '        Else
        '            '            'style2.DataSource = Nothing
        '            '            'style2.DisplayMember = "precio"
        '            '            'style2.ValueMember = "precio_id"
        '            '        End If


        '            '    End If
        '            'End If

        '            '  Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
        '            '  Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

        '        End If
        '    ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
        '        'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
        '        'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
        '    ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

        '    End If
        'End If
    End Sub

    Private Sub cboOperacionNotaCredito_Click(sender As Object, e As EventArgs) Handles cboOperacionNotaCredito.Click

    End Sub

    Private Sub cboOperacionNotaCredito_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboOperacionNotaCredito.SelectedValueChanged
        Dim valor = cboOperacionNotaCredito.Text
        If valor.Length > 0 Then

            Dim valor2 = cboOperacionNotaCredito.SelectedValue
            If valor2.Length > 0 Then

                Select Case cboOperacionNotaCredito.SelectedValue
                    Case "01"

                        'For Each i In dgvVentas.Table.Records
                        '    i.SetValue("unidadComercialDev", i.GetValue("unidadComercial"))
                        'Next

                        'dgvVentas.TableDescriptor.Columns("unidadComercialDev").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devtotal").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devcantidad").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devtotalme").ReadOnly = True

                        'RecargarDevolucion()
                        RecargarAnulacion()
                    Case "07"



                        'dgvVentas.TableDescriptor.Columns("unidadComercialDev").ReadOnly = False
                        dgvVentas.TableDescriptor.Columns("Devtotal").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devcantidad").ReadOnly = False

                        dgvVentas.TableDescriptor.Columns("Devtotalme").ReadOnly = True
                        'LimpiarNotaCredito()
                        LimpiarNotaCredito()
                        RecargaConServicios()
                    Case "05"
                        'dgvVentas.TableDescriptor.Columns("unidadComercialDev").ReadOnly = False
                        dgvVentas.TableDescriptor.Columns("Devtotal").ReadOnly = False
                        dgvVentas.TableDescriptor.Columns("Devcantidad").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devtotalme").ReadOnly = False
                        LimpiarNotaCredito()
                End Select
            End If

        End If
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try

            If Not txtGlosa.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingresar una glosa o Información")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not CDec(lblTotal.Text) > 0 Then
                MessageBox.Show("El importe debe ser mayor a 0")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If dgvVentas.Table.Records.Count > 0 Then

                Grabar()

            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Me.dgvVentas.Table.CurrentRecord.Delete()

        End If
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class