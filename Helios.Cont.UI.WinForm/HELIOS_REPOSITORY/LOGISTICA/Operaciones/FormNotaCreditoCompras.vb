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

Public Class FormNotaCreditoCompras

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
        CARGARCOMBOS()
        UbicarDocumento(idDocumento)

        txtFechaLaboral.Value = DateTime.Now
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Metodos"

    Public Function TipoOperacion() As String
        Dim Operacion As String = ""
        Select Case cboOperacionNotaCredito.SelectedValue
            Case "01" '"ANULACION DE LA OPERACION"
                Operacion = "9916"
            Case "05"   '"DESCUENTO POR ITEM"
                Operacion = "9943"
            Case "07" '"DEVOLUCION POR ITEM"
                Operacion = "9941"
            Case "04"  '"PRONTO PAGO - VOLUMEN DE COMPRA"
                Operacion = "9939"
            Case "08" '"DISMINUIR CANTIDAD"
                Operacion = "9940"
        End Select

        Return Operacion
    End Function

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentocompradetalle)
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
            .tipoDoc = "07"
            .fechaProceso = txtFechaLaboral.Value
            .nroDoc = txtSerieNota.Text & "-" & txtNumeroNota.Text.Trim
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
                .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                .nrodocEntidad = txtDniRuc.Text
            End If

            .tipoOperacion = TipoOperacionNota
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now

        End With

        With nDocumentoCompra

            .idPadre = txtIdDocumento.Text
            .codigoLibro = "14"
            .notaCredito = cboOperacionNotaCredito.SelectedValue
            .tipoDoc = "07"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaLaboral.Value  'DateTime.Now
            .fechaActualizacion = DateTime.Now
            .fechaContable = PeriodoGeneral
            .situacion = 1
            .tieneDetraccion = "N"
            .TipoDocNota = txtTipoDoc.Text
            .serie = txtSerieNota.Text
            .numeroDoc = txtNumeroNota.Text
            .SerieNota = txtSerieAfectado.Text
            .NumeroNota = txtNumeroAfectado.Text
            .tipoOperacion = TipoOperacionNota

            If txtRazonSocial.Tag = 0 Then
                .idProveedor = 0
                .nombreProveedor = "SIN IDENTIDAD"
                .NombreEntidad = "SIN IDENTIDAD"
            Else
                .idProveedor = CInt(txtRazonSocial.Tag)
                .nombreProveedor = txtRazonSocial.Text
                .NombreEntidad = txtRazonSocial.Text
            End If

            .monedaDoc = cboMoneda.SelectedValue
            .tasaIgv = CDec(TmpIGV)
            .tipocambio = CDec(txtTipoCambio.Text)
            .tcDolLoc = CDec(txtTipoCambio.Text)

            If cboMoneda.SelectedValue = "1" Then
                .bi01 = CDec(lblGravado.Text)
                .bi02 = CDec(lblExonerado.Text)
                .igv01 = CDec(lblIgv.Text)
                .igv02 = 0
                .bi01us = CDec(lblConvGravado.Text)
                .bi02us = CDec(lblConvExonerado.Text)
                .igv01us = CDec(lblConvIgv.Text)
                .igv02us = 0
                .importeTotal = CDec(lblTotal.Text)
                .importeUS = CDec(lblConvTotal.Text)
            ElseIf cboMoneda.SelectedValue = "2" Then
                .bi01 = CDec(lblConvGravado.Text)
                .bi02 = CDec(lblConvExonerado.Text)
                .igv01 = CDec(lblConvIgv.Text)
                .igv02 = 0
                .bi01us = CDec(lblGravado.Text)
                .bi02us = CDec(lblExonerado.Text)
                .igv01us = CDec(lblIgv.Text)
                .igv02us = 0
                .importeTotal = CDec(lblConvTotal.Text)
                .importeUS = CDec(lblTotal.Text)
            End If
            .tipoCompra = TIPO_COMPRA.NOTA_CREDITO 'TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01"
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

        ndocumento.documentocompra = nDocumentoCompra

        For Each r As Record In dgvVentas.Table.Records

            objDocumentoCompraDet = New documentocompradetalle

            'Select Case ndocumento.documentocompra.notaCredito
            '    Case "01", "02", "06"
            '        objDocumentoCompraDet.TipoOperacion = "9916"
            '        If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '            MessageBox.Show("No hay Montos por devolver o disminuir!")
            '            Exit Sub
            '        End If
            '    Case "05"
            '        objDocumentoCompraDet.TipoOperacion = "9943"
            '        If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '            MessageBox.Show("Ingrese un monto mayor a cero!")
            '            Exit Sub
            '        End If
            '    Case "04"
            '        objDocumentoCompraDet.TipoOperacion = "9939"
            '        If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '            MessageBox.Show("Ingrese un monto mayor a cero!")
            '            Exit Sub
            '        End If
            '    Case "07"
            '        objDocumentoCompraDet.TipoOperacion = "9941"
            '        If Not CDec(r.GetValue("Devcantidad")) > 0 Then
            '            MessageBox.Show("Ingrese una cantidad mayor a cero!")
            '            Exit Sub
            '        End If

            '    Case "08"
            '        objDocumentoCompraDet.TipoOperacion = "9940"
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
                Case "9943"
                    If Not CDec(r.GetValue("Devtotal")) > 0 Then
                        MessageBox.Show("Ingrese un monto mayor a cero!")
                        Exit Sub
                    End If
                Case "9939"
                    If Not CDec(r.GetValue("Devtotal")) > 0 Then
                        MessageBox.Show("Ingrese un monto mayor a cero!")
                        Exit Sub
                    End If
                Case "9941"
                    If Not CDec(r.GetValue("Devcantidad")) > 0 Then
                        MessageBox.Show("Ingrese una cantidad mayor a cero!")
                        Exit Sub
                    End If
                Case "9940"
                    objDocumentoCompraDet.TipoOperacion = "9940"
                    If Not CDec(r.GetValue("Devcantidad")) > 0 Then
                        MessageBox.Show("Ingrese una cantidad mayor a cero!")
                        Exit Sub
                    End If
            End Select

            objDocumentoCompraDet.TipoOperacion = TipoOperacion()
            objDocumentoCompraDet.ImporteDevolucionmn = CDec(r.GetValue("DevDinero"))
            objDocumentoCompraDet.ImporteDevolucionme = CDec(r.GetValue("DevDinerome"))
            If objDocumentoCompraDet.ImporteDevolucionmn > 0 Then
                objDocumentoCompraDet.TieneExcedente = True
            Else
                objDocumentoCompraDet.TieneExcedente = False
            End If
            objDocumentoCompraDet.secuenciaOrigen = r.GetValue("secuencia")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = DateTime.Now
            objDocumentoCompraDet.unidad1 = r.GetValue("unidad")
            objDocumentoCompraDet.destino = r.GetValue("destino")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.descripcionItem = CStr(r.GetValue("descripcion"))
            objDocumentoCompraDet.DetalleItem = CStr(r.GetValue("descripcion"))
            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("Devcantidad"))
            If CDec(r.GetValue("Devcantidad")) = 0 Then
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("Devtotal"))
                objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("Devtotalme"))
            ElseIf CDec(r.GetValue("Devcantidad")) > 0 Then
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("Devtotal")) / CDec(r.GetValue("Devcantidad"))
                objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("Devtotalme")) / CDec(r.GetValue("Devcantidad"))
            End If
            objDocumentoCompraDet.importe = CDec(r.GetValue("Devtotal"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("Devtotalme"))

            If r.GetValue("destino") = "1" Then
                objDocumentoCompraDet.montokardex = CDec(r.GetValue("Devgravado"))
                objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("Devgravadome"))

                If CDec(r.GetValue("DevDinero")) > 0 Then
                    Dim iva As Decimal = TmpIGV / 100
                    Dim tot As Decimal = CDec(r.GetValue("DevDinero"))
                    Dim bi As Decimal = Math.Round(CDec(CalculoBaseImponible(tot, iva + 1)), 2)
                    Dim igv As Decimal = tot - bi
                    objDocumentoCompraDet.IgvDevolucionmn = igv
                    objDocumentoCompraDet.BiDevolucionmn = bi
                Else
                    objDocumentoCompraDet.IgvDevolucionmn = 0
                    objDocumentoCompraDet.BiDevolucionmn = 0
                End If

            ElseIf r.GetValue("destino") = "2" Then
                objDocumentoCompraDet.montokardex = CDec(r.GetValue("Devexonerado"))
                objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("Devexoneradome"))

                If CDec(r.GetValue("DevDinero")) > 0 Then
                    objDocumentoCompraDet.IgvDevolucionmn = 0
                    objDocumentoCompraDet.BiDevolucionmn = CDec(r.GetValue("DevDinero"))
                End If

            End If

            objDocumentoCompraDet.montoIsc = 0
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("Devigv"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("Devigvme"))
            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacenRef"))
            objDocumentoCompraDet.codigoLote = CInt(r.GetValue("lote"))
            objDocumentoCompraDet.preEvento = r.GetValue("estadocobro")
            objDocumentoCompraDet.idPadreDTCompra = CInt(r.GetValue("secuencia"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.fechaVcto = Nothing
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumeroGuia.Text
            objDocumentoCompraDet.Serie = txtSerieGuia.Text
            objDocumentoCompraDet.TipoDoc = "99"
            If r.GetValue("estadocobro") = "Pagado" Then
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            ElseIf r.GetValue("estadocobro") = "Pendiente" Then
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            End If
            ListaDetalle.Add(objDocumentoCompraDet)
        Next


        If lblReclamacionDinero.Text > 0 Then

            Dim ItemDev As List(Of documentocompradetalle) = (From n In ListaDetalle
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

        'listaOp.Add("9916")
        'listaOp.Add("9943")
        'listaOp.Add("9941")
        'listaOp.Add("9939")
        'listaOp.Add("9940")

        Dim consulta As List(Of documentocompradetalle) = (From i In ListaDetalle
                                                           Where listaOp.Contains(i.TipoOperacion)).ToList
        If consulta.Count > 0 Then
            'GuiaRemision(ndocumento, consulta)
        End If

        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveNotaCreditoCompraFE(ndocumento, DocCaja, documentoSaldo)


        'Dim f As New FormImpresionNuevo(  ' frmVentaNuevoFormato
        'f.TIPOiMPESION = 1
        'f.DocumentoID = xcod
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)

        Me.Close()
    End Sub

    Public Sub UbicarDocumento(idDocumento As Integer)

        Try

            Dim documentoSA As New DocumentoCompraSA
            Dim documento = documentoSA.DocumentoCompraAfectadoNC(New documentocompra With {.idDocumento = idDocumento,
                                                            .estadoPago = "PN"})

            txtSerieAfectado.Text = documento.serie
            txtNumeroAfectado.Text = documento.numeroDoc
            txtTipoDoc.Text = documento.tipoDoc
            txtRazonSocial.Text = documento.nombreProveedor
            txtRazonSocial.Tag = documento.idProveedor
            txtDniRuc.Text = documento.rucProveedor
            txtTipoCambio.Text = documento.tcDolLoc  'documento.tipocambio.GetValueOrDefault



            txtIdDocumento.Text = documento.idDocumento

            'If documento.moneda = "1" Then
            '    cboMoneda.Text = "NACIONAL"
            'ElseIf documento.moneda = "2" Then
            '    cboMoneda.Text = "EXTRANJERA"
            'End If
            cboMoneda.SelectedValue = documento.monedaDoc


            For Each i In documento.documentocompradetalle
                If i.monto1 > 0 Then
                    Dim PU = 0.0
                    Dim PUME = 0.0
                    If i.CantVenta > 0 Then

                        PU = (i.importe / i.monto1)
                        PUME = (i.importeUS / i.monto1)

                        Dim ImpVenta = PU * i.CantVenta
                        Dim ImpVentaME = PUME * i.CantVenta

                        i.monto1 += i.CantVenta
                        i.importe += ImpVenta
                        i.importeUS += ImpVentaME

                        PU = (i.importe / i.monto1)
                        PUME = (i.importeUS / i.monto1)

                    Else
                        PU = (i.importe / i.monto1)
                        PUME = (i.importeUS / i.monto1)

                    End If


                    Me.dgvVentas.Table.AddNewRecord.SetCurrent()
                    Me.dgvVentas.Table.AddNewRecord.BeginEdit()
                    Me.dgvVentas.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("destino", i.destino)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("lote", i.codigoLote)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("idItem", i.idItem)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("descripcion", i.descripcionItem)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("tipoEx", i.tipoExistencia)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("almacenRef", i.almacenRef)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("unidad", i.unidad1)
                    'Me.dgvVentas.Table.CurrentRecord.SetValue("estadocobro", i.estadoPago)
                    Select Case i.estadoPago
                        Case TIPO_VENTA.PAGO.COBRADO
                            Me.dgvVentas.Table.CurrentRecord.SetValue("estadocobro", "Pagado")
                        Case Else
                            Me.dgvVentas.Table.CurrentRecord.SetValue("estadocobro", "Pendiente")
                    End Select
                    Me.dgvVentas.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("pu", PU) 'i.importe / i.monto1) 'i.precioUnitario)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("pume", PUME) 'i.importeUS / i.monto1) 'i.precioUnitarioUS)

                    Me.dgvVentas.Table.CurrentRecord.SetValue("igv", i.montoIgv)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("gravado", i.montokardex)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("gravadome", i.montokardexUS)

                    Me.dgvVentas.Table.CurrentRecord.SetValue("importe", i.importe)
                    Me.dgvVentas.Table.CurrentRecord.SetValue("importeme", i.importeUS)
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
                    Me.dgvVentas.Table.AddNewRecord.EndEdit()
                End If
            Next

            camposmonedas()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
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

        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvVentas.Table.CurrentRecord.GetValue("destino")
            'totalDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagosme")), 2)

            preciounit = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pume")), 2)
            cantDev = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Devcantidad")), 2)

            If cboOperacionNotaCredito.Text = "DISMINUIR CANTIDAD" Then

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
            Else


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
                End If
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

        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvVentas.Table.CurrentRecord.GetValue("destino")
            'totalDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pagos")), 2)

            preciounit = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("pu")), 2)
            cantDev = Math.Round(CDec(Me.dgvVentas.Table.CurrentRecord.GetValue("Devcantidad")), 2)

            If cboOperacionNotaCredito.Text = "DISMINUIR CANTIDAD" Then

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

            Else


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

                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", Math.Round(gravadoDev / CDec(txtTipoCambio.Text), 2))  'Math.Round(totalMN, 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", Math.Round(exoneradoDev / CDec(txtTipoCambio.Text), 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", Math.Round(igvDev / CDec(txtTipoCambio.Text), 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", Math.Round(DineroXDevolver / CDec(txtTipoCambio.Text), 2))
                    Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", Math.Round(totalDev / CDec(txtTipoCambio.Text), 2))

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
                End If


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


    Public Sub RecargarDevolucion()
        For Each r As Record In dgvVentas.Table.Records

            If cboOperacionNotaCredito.Text = "DISMINUIR CANTIDAD" Then

                r.SetValue("Devcantidad", CDec(r.GetValue("cantidad")))
                r.SetValue("DevDinero", CDec(0.0))
                r.SetValue("DevDinerome", CDec(0.0))
                r.SetValue("Devgravado", CDec(0.0))
                r.SetValue("Devexonerado", CDec(0.0))
                r.SetValue("Devgravadome", CDec(0.0))
                r.SetValue("Devexoneradome", CDec(0.0))
                r.SetValue("Devigv", CDec(0.0))
                r.SetValue("Devtotal", CDec(0.0))
                r.SetValue("Devigvme", CDec(0.0))
                r.SetValue("Devtotalme", CDec(0.0))

            Else
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
        For Each r As Record In dgvVentas.Table.Records

            If r.GetValue("destino") = "1" Then

                r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
                r.SetValue("Devcantidad", CDec(0))
                r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
                r.SetValue("Devexonerado", CDec(0))
                r.SetValue("Devigv", CDec(r.GetValue("igv")))
                r.SetValue("Devtotal", CDec(r.GetValue("importe")))

                r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))
                r.SetValue("Devcantidadme", CDec(0))
                r.SetValue("Devgravadome", CDec(r.GetValue("gravadome")))
                r.SetValue("Devexoneradome", CDec(0))
                r.SetValue("Devigvme", CDec(r.GetValue("igvme")))
                r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))

            ElseIf r.GetValue("destino") = "2" Then

                r.SetValue("DevDinero", CDec(r.GetValue("pagos")))
                r.SetValue("Devcantidad", CDec(0))
                r.SetValue("Devgravado", CDec(0))
                r.SetValue("Devexonerado", CDec(r.GetValue("importe")))
                r.SetValue("Devigv", CDec(0))
                r.SetValue("Devtotal", CDec(r.GetValue("importe")))

                r.SetValue("DevDinerome", CDec(r.GetValue("pagosme")))
                r.SetValue("Devcantidadme", CDec(0))
                r.SetValue("Devgravadome", CDec(0))
                r.SetValue("Devexoneradome", CDec(r.GetValue("importeme")))
                r.SetValue("Devigvme", CDec(0))
                r.SetValue("Devtotalme", CDec(r.GetValue("importeme")))
            End If

        Next
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

                Me.dgvVentas.Table.CurrentRecord.SetValue("Devtotalme", Math.Round(totalDev / CDec(txtTipoCambio.Text), 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devgravadome", Math.Round(gravadoDev / CDec(txtTipoCambio.Text), 2)) 'Math.Round(totalMN, 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devexoneradome", Math.Round(exoneradoDev / CDec(txtTipoCambio.Text), 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("Devigvme", Math.Round(igvDev / CDec(txtTipoCambio.Text), 2))
                Me.dgvVentas.Table.CurrentRecord.SetValue("DevDinerome", Math.Round(DineroXDevolver / CDec(txtTipoCambio.Text), 2))

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

    Public Sub CARGARCOMBOS()

        Dim ListaMoneda As New List(Of tabladetalle)
        Dim objetoMoneda As tabladetalle

        Dim ListaOperacion As New List(Of tabladetalle)
        Dim objetoNota As tabladetalle

        objetoNota = New tabladetalle
        objetoNota.descripcion = "DESCUENTO POR ITEM"
        objetoNota.codigoDetalle = "05"
        ListaOperacion.Add(objetoNota)

        objetoNota = New tabladetalle
        objetoNota.descripcion = "PRONTO PAGO - VOLUMEN DE COMPRA"
        objetoNota.codigoDetalle = "04"
        ListaOperacion.Add(objetoNota)

        objetoNota = New tabladetalle
        objetoNota.descripcion = "ANULACION DE LA OPERACION"
        objetoNota.codigoDetalle = "01"
        ListaOperacion.Add(objetoNota)

        objetoNota = New tabladetalle
        objetoNota.descripcion = "DEVOLUCION POR ITEM"
        objetoNota.codigoDetalle = "07"
        ListaOperacion.Add(objetoNota)

        objetoNota = New tabladetalle
        objetoNota.descripcion = "DISMINUIR CANTIDAD"
        objetoNota.codigoDetalle = "08"
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




        For Each r As Record In dgvVentas.Table.Records

            igv += CDec(r.GetValue("Devigv"))
            gravado += CDec(r.GetValue("Devgravado"))
            exonerado += CDec(r.GetValue("Devexonerado"))
            total += CDec(r.GetValue("Devtotal"))
            dinero += CDec(r.GetValue("DevDinero"))

            igvme += CDec(r.GetValue("Devigvme"))
            gravadome += CDec(r.GetValue("Devgravadome"))
            exoneradome += CDec(r.GetValue("Devexoneradome"))
            totalme += CDec(r.GetValue("Devtotalme"))
            dinerome += CDec(r.GetValue("DevDinerome"))
        Next


        If cboMoneda.Text = "NACIONAL" Then
            lblIgv.Text = Math.Round(igv, 2)
            lblGravado.Text = Math.Round(gravado, 2)
            lblExonerado.Text = Math.Round(exonerado, 2)
            lblTotal.Text = Math.Round(total, 2)
            lblReclamacionDinero.Text = Math.Round(dinero, 2)

            'DigitalGauge2.Value = Math.Round(total, 2)

            lblConvIgv.Text = Math.Round(igvme, 2)
            lblConvGravado.Text = Math.Round(gravadome, 2)
            lblConvExonerado.Text = Math.Round(exoneradome, 2)
            lblConvTotal.Text = Math.Round(totalme, 2)
            lblConvReclamacionDinero.Text = Math.Round(dinerome, 2)


        ElseIf cboMoneda.Text = "EXTRANJERA" Then
            lblIgv.Text = Math.Round(igvme, 2)
            lblGravado.Text = Math.Round(gravadome, 2)
            lblExonerado.Text = Math.Round(exoneradome, 2)
            lblTotal.Text = Math.Round(totalme, 2)
            lblReclamacionDinero.Text = Math.Round(dinerome, 2)

            'DigitalGauge2.Value = Math.Round(totalme, 2)

            lblConvIgv.Text = Math.Round(igv, 2)
            lblConvGravado.Text = Math.Round(gravado, 2)
            lblConvExonerado.Text = Math.Round(exonerado, 2)
            lblConvTotal.Text = Math.Round(total, 2)
            lblConvReclamacionDinero.Text = Math.Round(dinero, 2)

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

        End If

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
        dgvVentas.DataSource = dt
        dgvVentas.TopLevelGroupOptions.ShowCaption = True
    End Sub

#End Region


    Private Sub FormNotaCreditoCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvVentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentas.TableControlCellClick

    End Sub

    Private Sub dgvVentas_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvVentas.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvVentas.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If Not IsNothing(cc) Then
                Select Case cc.ColIndex

                    Case 21 ' CANTIDAD


                        Dim r As Record = dgvVentas.Table.CurrentRecord
                        Dim text As String = cc.Renderer.ControlText
                        If text.Trim.Length > 0 Then

                            Dim value As Decimal = Convert.ToDecimal(text)
                                cc.Renderer.ControlValue = value

                                Dim impDisponible = r.GetValue("cantidad")
                                Dim totalDisponible = r.GetValue("importe")
                                Dim totalDisponibleme = r.GetValue("importeme")

                                If value = impDisponible Then
                                    'recargar todo para no recalcular
                                    RecargarDevolucion()
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

                            Dim impDisponible = r.GetValue("importe")
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

                            Dim impDisponible = r.GetValue("importeme")
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





    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
            Me.dgvVentas.Table.CurrentRecord.Delete()

        End If
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try

            If Not txtGlosa.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingresar una glosa o Información")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtSerieNota.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingresar una Serie del Documento")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtNumeroNota.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese un numero de Documento")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


            If Not cboOperacionNotaCredito.Text = "DISMINUIR CANTIDAD" Then
                'If Not DigitalGauge2.Value > 0 Then

                If Not CDec(lblTotal.Text) > 0 Then
                    MessageBox.Show("El importe debe ser mayor a 0")
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If


            If dgvVentas.Table.Records.Count > 0 Then

                Grabar()

            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
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
                        dgvVentas.TableDescriptor.Columns("Devtotal").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devcantidad").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devtotalme").ReadOnly = True

                        RecargarDevolucion()

                    Case "07", "08" ' DISMINUCION CANTIDAD Y CANT IMPORTE
                        dgvVentas.TableDescriptor.Columns("Devtotal").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devcantidad").ReadOnly = False

                        dgvVentas.TableDescriptor.Columns("Devtotalme").ReadOnly = True
                        LimpiarNotaCredito()
                    Case "05", "04"
                        dgvVentas.TableDescriptor.Columns("Devtotal").ReadOnly = False
                        dgvVentas.TableDescriptor.Columns("Devcantidad").ReadOnly = True
                        dgvVentas.TableDescriptor.Columns("Devtotalme").ReadOnly = False
                        LimpiarNotaCredito()
                End Select
            End If

        End If
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub
End Class