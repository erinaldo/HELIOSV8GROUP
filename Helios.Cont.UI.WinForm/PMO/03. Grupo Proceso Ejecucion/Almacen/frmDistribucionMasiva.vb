Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmDistribucionMasiva
    Inherits frmMaster

    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()
            ToolStrip1.Visible = True
            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Black
            '      Dispose()
            ToolStrip1.Visible = False
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
        Timer1.Interval = 850

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Métodos: Manipulación Data"

    Dim ListaAsientonTransito As New List(Of asiento)

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal, strIdEntidad As String, strEntidad As String, strFecha As DateTime, strGlosa As String, strIdDocumento As Integer) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = strIdDocumento
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = strIdEntidad
        nAsiento.nombreEntidad = strEntidad
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = strGlosa
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String,
                                 strIdEntidad As String, strEntidad As String, strFecha As DateTime, strGlosa As String, intIdDocumento As Integer)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMascaraExistencias As New mascaraContableExistencia
        Dim nMovimiento As New movimiento

        asientoTransitod = New asiento
        asientoTransitod = AsientoTransito(cMonto, cMontoUS, strIdEntidad, strEntidad, strFecha, strGlosa, intIdDocumento) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento

        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "08"
                nMovimiento.cuenta = "33"
        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento

        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "08"
                nMovimiento.cuenta = "28"
        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub contarMontos()
        Dim CimporteMN As Decimal = 0
        Dim CimporteMe As Decimal = 0
        For Each i As DataGridViewRow In dgvDistribucion.Rows
            CimporteMN += CDec(i.Cells(16).Value)
            CimporteMe += CDec(i.Cells(18).Value)
        Next
        lblImporteMN.Text = CimporteMN.ToString("N2")
        lblImporteME.Text = CimporteMe.ToString("N2")
    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        Dim itemSA As New detalleitemsSA
        'REGISTRANDO LA GUIA DE REMISION

        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text.Trim
            .idEntidad = Nothing ' docCompra.idProveedor
            .monedaDoc = Nothing ' docCompra.monedaDoc
            .tasaIgv = Nothing ' docCompra.tasaIgv
            .tipoCambio = Nothing ' docCompra.tcDolLoc
            .importeMN = CDec(lblImporteMN.Text)
            .importeME = CDec(lblImporteME.Text)
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each i As DataGridViewRow In dgvDistribucion.Rows
            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = CInt(i.Cells(21).Value)
            documentoguiaDetalle.idItem = i.Cells(10).Value
            documentoguiaDetalle.descripcionItem = i.Cells(11).Value
            documentoguiaDetalle.destino = i.Cells(4).Value
            With itemSA.InvocarProductoID(i.Cells(10).Value)
                documentoguiaDetalle.unidadMedida = .unidad1
            End With
            documentoguiaDetalle.cantidad = CDec(i.Cells(12).Value)
            documentoguiaDetalle.precioUnitario = CDec(i.Cells(15).Value)
            documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(17).Value)
            documentoguiaDetalle.importeMN = CDec(i.Cells(16).Value)
            documentoguiaDetalle.importeME = CDec(i.Cells(18).Value)
            documentoguiaDetalle.idDocumentoPadre = CInt(i.Cells(21).Value)
            documentoguiaDetalle.almacenRef = txtAlmacen.ValueMember

            documentoguiaDetalle.secuencia = CInt(i.Cells(30).Value)

            documentoguiaDetalle.usuarioModificacion = "Jiuni"
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    'Function listaPrecioConIVA() As List(Of listadoPrecios)
    '    Dim PreciosConIVABE As New listadoPrecios
    '    Dim PreciosSINIVABE As New listadoPrecios
    '    Dim listadoPreciosBE As New List(Of listadoPrecios)

    '    Dim PrecioUnitarioMN As Decimal = 0.0
    '    Dim SIVA As Decimal = 0.0
    '    Dim IGV As Decimal
    '    Dim TC As Decimal
    '    Dim SIVAvalorVentaMN As Decimal
    '    Dim NIVAvalorVentaMN As Decimal
    '    Dim xMenor As Decimal
    '    Dim xMayor As Decimal
    '    Dim xGMayor As Decimal

    '    For Each i As DataGridViewRow In dgvDistribucion.Rows
    '        If dgvDistribucion.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
    '            SIVA = Math.Round(CDec(tmpIGV / 100) + 1, 2)
    '            IGV = CDec(TmpIGV / 100)
    '            TC = CDec(TmpTipoCambio)
    '            PrecioUnitarioMN = CDec(i.Cells(15).Value)
    '            xMenor = (2 / 100)
    '            xMayor = (4 / 100)
    '            xGMayor = (6 / 100)
    '            '18.64

    '            PreciosConIVABE = New listadoPrecios
    '            With PreciosConIVABE

    '                .idEmpresa = Gempresas.IdEmpresaRuc
    '                .idEstablecimiento = GEstableciento.IdEstablecimiento
    '                .idAlmacen = txtAlmacen.ValueMember
    '                .fecha = Date.Now
    '                .tipoExistencia = (i.Cells(14).Value)
    '                .destinoGravado = 1
    '                .idItem = CDec(i.Cells(10).Value)
    '                .descripcion = (i.Cells(11).Value)
    '                .presentacion = Nothing
    '                .unidad = Nothing

    '                '16.95
    '                SIVAvalorVentaMN = ((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (TmpPorcGanacia / 100)))
    '                .valcompraIgvMN = Math.Round((PrecioUnitarioMN / SIVA), 2)
    '                .valcompraIgvME = Math.Round((PrecioUnitarioMN / SIVA) / TC, 2)
    '                .tipoConfiguracion = "SI"

    '                .montoUtilidad = Math.Round((TmpPorcGanacia / 100) * (PrecioUnitarioMN / SIVA), 2)
    '                .montoUtilidadME = Math.Round(((TmpPorcGanacia / 100) * (PrecioUnitarioMN / SIVA)) / TC, 2)
    '                .utilidadsinIgvMN = 0.0
    '                .utilidadsinIgvME = 0.0

    '                .valorVentaMN = Math.Round(SIVAvalorVentaMN, 2)
    '                .valorVentaME = Math.Round(SIVAvalorVentaMN / TC, 2)

    '                .igvMN = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
    '                .igvME = Math.Round(CDec((SIVAvalorVentaMN) * IGV) / TC, 2)
    '                .iscMN = 0.0
    '                .otcMN = 0.0
    '                .iscME = 0.0
    '                .otcME = 0.0
    '                .precioVentaMN = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)
    '                .precioVentaME = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) / TC, 2)
    '                '.utilidadsinIgvME = Math.Round(CDec(PrecioUnitarioMN * (TmpPorcGanacia / 100)) / CDec(TCe), 2)

    '                .PorDsctounitMenor = 2
    '                .montoDsctounitMenorMN = Math.Round((PrecioUnitarioMN / SIVA) * xMenor, 2)
    '                .montoDsctounitMenorME = Math.Round(((PrecioUnitarioMN / SIVA) * xMenor) / TC, 2)
    '                .precioVentaFinalMenorMN = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMenor), 2)
    '                .precioVentaFinalMenorME = Math.Round(((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMenor)) / TC, 2)

    '                .PorDsctounitMayor = 4
    '                .montoDsctounitMayorMN = Math.Round((PrecioUnitarioMN / SIVA) * xMayor, 2)
    '                .montoDsctounitMayorME = Math.Round(((PrecioUnitarioMN / SIVA) * xMayor) / TC, 2)
    '                .precioVentaFinalMayorMN = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMayor), 2)
    '                .precioVentaFinalMayorME = Math.Round(((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMayor)) / TC, 2)

    '                .PorDsctounitGMayor = 6
    '                .montoDsctounitGMayorMN = Math.Round((PrecioUnitarioMN / SIVA) * xGMayor, 2)
    '                .montoDsctounitGMayorME = Math.Round(((PrecioUnitarioMN / SIVA) * xGMayor) / TC, 2)
    '                .precioVentaFinalGMayorMN = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xGMayor), 2)
    '                .precioVentaFinalGMayorME = Math.Round(((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xGMayor)) / TC, 2)

    '                .cantidadMenor = 0
    '                .cantidadMayor = 0
    '                .cantidadGMayor = 0
    '                .usuarioActualizacion = "Jiuni"
    '                .fechaActualizacion = Date.Now
    '                listadoPreciosBE.Add(PreciosConIVABE)
    '            End With

    '            PreciosSINIVABE = New listadoPrecios
    '            With PreciosSINIVABE

    '                .idEmpresa = Gempresas.IdEmpresaRuc
    '                .idEstablecimiento = GEstableciento.IdEstablecimiento
    '                .idAlmacen = txtAlmacen.ValueMember
    '                .fecha = Date.Now
    '                .tipoExistencia = (i.Cells(14).Value)
    '                .destinoGravado = 1
    '                .idItem = CDec(i.Cells(10).Value)
    '                .descripcion = (i.Cells(11).Value)
    '                .presentacion = Nothing
    '                .unidad = Nothing

    '                NIVAvalorVentaMN = ((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (TmpPorcGanacia / 100)))
    '                .valcompraSinIgvMN = Math.Round(PrecioUnitarioMN, 2)
    '                .valcompraSinIgvME = Math.Round((PrecioUnitarioMN) / TC, 2)
    '                .tipoConfiguracion = "NO"

    '                .montoUtilidad = 0.0
    '                .montoUtilidadME = 0.0
    '                .utilidadsinIgvMN = Math.Round((TmpPorcGanacia / 100) * (PrecioUnitarioMN), 2)
    '                .utilidadsinIgvME = Math.Round(((TmpPorcGanacia / 100) * (PrecioUnitarioMN)) / TC, 2)

    '                .valorVentaMN = Math.Round(NIVAvalorVentaMN, 2)
    '                .valorVentaME = Math.Round(NIVAvalorVentaMN / TC, 2)

    '                .igvMN = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
    '                .igvME = Math.Round(CDec((NIVAvalorVentaMN) * IGV) / TC, 2)
    '                .iscMN = 0.0
    '                .otcMN = 0.0
    '                .iscME = 0.0
    '                .otcME = 0.0
    '                .precioVentaMN = Math.Round(NIVAvalorVentaMN, 2)
    '                .precioVentaME = Math.Round((NIVAvalorVentaMN) / TC, 2)

    '                .PorDsctounitMenor = 2
    '                .montoDsctounitMenorMN = Math.Round((PrecioUnitarioMN) * xMenor, 2)
    '                .montoDsctounitMenorME = Math.Round(((PrecioUnitarioMN) * xMenor) / TC, 2)
    '                .precioVentaFinalMenorMN = Math.Round((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMenor), 2)
    '                .precioVentaFinalMenorME = Math.Round(((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMenor)) / TC, 2)

    '                .PorDsctounitMayor = 4
    '                .montoDsctounitMayorMN = Math.Round((PrecioUnitarioMN) * xMayor, 2)
    '                .montoDsctounitMayorME = Math.Round(((PrecioUnitarioMN) * xMayor) / TC, 2)
    '                .precioVentaFinalMayorMN = Math.Round((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMayor), 2)
    '                .precioVentaFinalMayorME = Math.Round(((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMayor)) / TC, 2)

    '                .PorDsctounitGMayor = 6
    '                .montoDsctounitGMayorMN = Math.Round((PrecioUnitarioMN) * xGMayor, 2)
    '                .montoDsctounitGMayorME = Math.Round(((PrecioUnitarioMN) * xGMayor) / TC, 2)
    '                .precioVentaFinalGMayorMN = Math.Round((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xGMayor), 2)
    '                .precioVentaFinalGMayorME = Math.Round(((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xGMayor)) / TC, 2)

    '                .cantidadMenor = 0
    '                .cantidadMayor = 0
    '                .cantidadGMayor = 0
    '                .usuarioActualizacion = "Jiuni"
    '                .fechaActualizacion = Date.Now

    '                listadoPreciosBE.Add(PreciosSINIVABE)
    '            End With
    '        End If
    '    Next

    '    Return listadoPreciosBE
    'End Function

    Private Sub SaveMovimentosES()

        Dim InventarioSA As New inventarioMovimientoSA

        Dim objSalida As New InventarioMovimiento
        Dim ListaSalida As New List(Of InventarioMovimiento)

        Dim objDistribucionDet As New InventarioMovimiento
        Dim ListaEntrada As New List(Of InventarioMovimiento)

        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim objTotalesAV As New totalesAlmacen
        Dim ListaTotalesAV As New List(Of totalesAlmacen)
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        Dim n As New RecolectarDatos()
        Dim documento As New documento
        Dim listaprecios As New List(Of listadoPrecios)

        Dim PreciosConIVABE As New listadoPrecios
        Dim PreciosSINIVABE As New listadoPrecios
        Dim listaPrecioSA As New ListadoPrecioSA
        'Dim listadoPreciosBE As New List(Of listadoPrecios)

        Dim PrecioUnitarioMN As Decimal = 0.0
        Dim SIVA As Decimal = 0.0


        Try
            datos.Clear()
            GuiaRemision(documento)

            ListaAsientonTransito = New List(Of asiento)
            For Each i As DataGridViewRow In dgvDistribucion.Rows
                objSalida = New InventarioMovimiento
                objSalida.idInventario = i.Cells(22).Value()
                objSalida.idEmpresa = Gempresas.IdEmpresaRuc  ' frmInventarioAlmacen.lblIdEmpresa.Text
                objSalida.idEstablecimiento = CInt(i.Cells(0).Value())
                objSalida.idAlmacen = i.Cells(23).Value()
                objSalida.tipoOperacion = "02"
                objSalida.tipoDocAlmacen = txtTipoDoc.ValueMember 'i.Cells(6).Value()
                objSalida.serie = txtSerie.Text.Trim ' i.Cells(7).Value()
                objSalida.numero = txtNumero.Text.Trim ' i.Cells(8).Value()
                objSalida.idDocumento = CInt(i.Cells(21).Value())
                objSalida.idDocumentoRef = CInt(i.Cells(21).Value())
                objSalida.descripcion = String.Concat(i.Cells(3).Value(), " SALIDA DE ITEMS: ", i.Cells(11).Value())
                objSalida.fecha = txtFecha.Value ' i.Cells(5).Value()
                objSalida.tipoRegistro = "D"
                objSalida.destinoGravadoItem = i.Cells(4).Value()
                objSalida.tipoProducto = i.Cells(14).Value()
                objSalida.OrigentipoProducto = IIf(i.Cells(9).Value() = "NACIONAL", "N", "E")
                'objSalida.cuentaOrigen = i.Cells(20).Value()
                objSalida.idItem = i.Cells(10).Value()
                objSalida.presentacion = i.Cells(26).Value()
                'If IsNothing(i.Cells(27).Value()) Then
                '    objSalida.fechavcto = Nothing
                'Else
                '    objSalida.fechavcto = Nothing ' CDate(i.Cells(27).Value())
                'End If
                objSalida.cantidad = CDec(i.Cells(12).Value()) * -1
                objSalida.unidad = i.Cells(13).Value()
                objSalida.cantidad2 = 0
                'objDistribucionDet.unidad2 = dgvDistribucion.Rows(p).Cells(4).Value()
                objSalida.precUnite = CDec(i.Cells(15).Value())
                objSalida.precUniteUSD = CDec(i.Cells(17).Value())
                objSalida.monto = CDec(i.Cells(16).Value()) * -1
                objSalida.montoUSD = CDec(i.Cells(18).Value()) * -1
                objSalida.montoOther = 0
                'objDistribucionDet.monedaOther = dgvDistribucion.Rows(p).Cells(3).Value()
                objSalida.disponible = 0 ' dgvDistribucion.Rows(p).Cells(10).Value() ' CANTIDAD SOLES
                objSalida.disponible2 = 0 ' dgvDistribucion.Rows(p).Cells(12).Value() 
                objSalida.saldoMonto = 0 'dgvDistribucion.Rows(p).Cells(13).Value()
                objSalida.saldoMontoUsd = 0
                objSalida.status = "A" ' dgvDistribucion.Rows(p).Cells(15).Value()
                objSalida.entragado = "SI"
                'objSalida.preEvento = IIf(i.Cells(24).Value() = "", Nothing, i.Cells(24).Value())
                objSalida.usuarioActualizacion = "Jiuni"
                objSalida.fechaActualizacion = Date.Now
                ListaSalida.Add(objSalida)
            Next

            For Each i As DataGridViewRow In dgvDistribucion.Rows

                MV_Item_Transito(i.Cells(11).Value(),
                                 i.Cells(16).Value(),
                                 i.Cells(18).Value(),
                                 i.Cells(14).Value(),
                                   i.Cells(28).Value(), i.Cells(29).Value(), i.Cells(5).Value(),
                                 String.Concat(i.Cells(3).Value(), " ENTRADA DE ITEMS: ", i.Cells(11).Value()), i.Cells(21).Value())

                objDistribucionDet = New InventarioMovimiento
                objDistribucionDet.idInventario = i.Cells(22).Value() '0
                objDistribucionDet.idEmpresa = Gempresas.IdEmpresaRuc  ' frmInventarioAlmacen.lblIdEmpresa.Text
                objDistribucionDet.idEstablecimiento = txtEstablecimiento.ValueMember ' CDec(i.Cells(0).Value())
                If Not txtAlmacen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Debe indicar el almacén de destino"
                    lblEstado.Image = My.Resources.warning2
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    Exit Sub
                Else
                    objDistribucionDet.idAlmacen = txtAlmacen.ValueMember
                End If

                objDistribucionDet.NombreAlmacen = txtAlmacen.ValueMember
                objDistribucionDet.IdProveedor = i.Cells(28).Value()
                objDistribucionDet.nombreProveedor = i.Cells(29).Value()
                objDistribucionDet.tipoOperacion = "02"
                objDistribucionDet.tipoDocAlmacen = txtTipoDoc.ValueMember  ' i.Cells(6).Value()
                objDistribucionDet.serie = txtSerie.Text.Trim  ' i.Cells(7).Value()
                objDistribucionDet.numero = txtNumero.Text.Trim ' i.Cells(8).Value()
                objDistribucionDet.idDocumento = CDec(i.Cells(21).Value())
                objDistribucionDet.idDocumentoRef = CDec(i.Cells(21).Value())
                objDistribucionDet.descripcion = String.Concat(i.Cells(3).Value(), " ENTRADA DE ITEMS: ", i.Cells(11).Value())
                objDistribucionDet.fecha = txtFecha.Value ' i.Cells(5).Value()
                objDistribucionDet.tipoRegistro = "EA"
                objDistribucionDet.destinoGravadoItem = i.Cells(4).Value()
                objDistribucionDet.tipoProducto = i.Cells(14).Value()
                objDistribucionDet.OrigentipoProducto = IIf(i.Cells(9).Value() = "NACIONAL", "N", "E")
                'objDistribucionDet.cuentaOrigen = i.Cells(20).Value()
                objDistribucionDet.idItem = i.Cells(10).Value()
                objDistribucionDet.presentacion = i.Cells(26).Value()
                '  objDistribucionDet.FechaVcto = IIf(IsNothing(dgvDistribucion.Rows(p).Cells(27).Value()), Nothing, CDate(dgvDistribucion.Rows(p).Cells(27).Value()))
                'If IsNothing(i.Cells(27).Value()) Then
                '    objDistribucionDet.fechavcto = Nothing
                'Else
                '    objDistribucionDet.fechavcto = CDate(i.Cells(27).Value())
                'End If
                objDistribucionDet.nombreItem = i.Cells(11).Value()
                objDistribucionDet.cantidad = CType(i.Cells(12).Value(), Decimal)
                objDistribucionDet.unidad = i.Cells(13).Value()
                objDistribucionDet.cantidad2 = 0
                'objDistribucionDet.unidad2 = dgvDistribucion.Rows(p).Cells(4).Value()
                objDistribucionDet.precUnite = CType(i.Cells(15).Value(), Decimal)
                objDistribucionDet.precUniteUSD = CType(i.Cells(17).Value(), Decimal)
                objDistribucionDet.monto = CType(i.Cells(16).Value(), Decimal)
                objDistribucionDet.montoUSD = CType(i.Cells(18).Value(), Decimal)
                objDistribucionDet.montoOther = 0
                'objDistribucionDet.monedaOther = dgvDistribucion.Rows(p).Cells(3).Value()
                objDistribucionDet.disponible = CType(i.Cells(12).Value(), Decimal) ' CANTIDAD SOLES
                objDistribucionDet.disponible2 = 0 ' dgvDistribucion.Rows(p).Cells(12).Value() 
                objDistribucionDet.saldoMonto = CType(i.Cells(16).Value(), Decimal)
                objDistribucionDet.saldoMontoUsd = CType(i.Cells(18).Value(), Decimal)
                objDistribucionDet.status = "D" ' dgvDistribucion.Rows(p).Cells(15).Value()
                objDistribucionDet.entragado = "SI"
                'objDistribucionDet.preEvento = IIf(i.Cells(24).Value() = "", Nothing, i.Cells(24).Value())
                objDistribucionDet.usuarioActualizacion = "Jiuni"
                objDistribucionDet.fechaActualizacion = DateTime.Now
                ListaEntrada.Add(objDistribucionDet)
            Next

            For Each i As DataGridViewRow In dgvDistribucion.Rows
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = i.Cells(30).Value()
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = txtEstablecimiento.ValueMember ' CDec(i.Cells(0).Value())
                objTotalesDet.idAlmacen = txtAlmacen.ValueMember  ' i.Cells(1).Value()
                objTotalesDet.origenRecaudo = i.Cells(4).Value()
                objTotalesDet.tipoCambio = "2.77"
                objTotalesDet.tipoExistencia = i.Cells(14).Value()
                objTotalesDet.idItem = i.Cells(10).Value()
                objTotalesDet.descripcion = i.Cells(11).Value()
                objTotalesDet.idUnidad = i.Cells(13).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(i.Cells(12).Value(), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(i.Cells(15).Value(), Decimal)
                objTotalesDet.importeSoles = CType(i.Cells(16).Value(), Decimal)
                objTotalesDet.importeDolares = CType(i.Cells(18).Value(), Decimal)
                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = "NN"
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
            Next
            'QUITANDO IMPORTES DEL ALMACEN VIRTUAL
            Dim almacenSA As New almacenSA
            For Each i As DataGridViewRow In dgvDistribucion.Rows
                objTotalesAV = New totalesAlmacen
                objTotalesAV.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesAV.SecuenciaDetalle = i.Cells(30).Value()
                objTotalesAV.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesAV.Modulo = "N"
                objTotalesAV.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(i.Cells(23).Value()).idEstablecimiento
                ' txtEstablecimiento.ValueMember ' CDec(i.Cells(0).Value())
                objTotalesAV.idAlmacen = i.Cells(23).Value() ' txtAlmacen.ValueMember ' i.Cells(1).Value()
                objTotalesAV.origenRecaudo = i.Cells(4).Value()
                objTotalesAV.tipoCambio = "2.77"
                objTotalesAV.tipoExistencia = i.Cells(14).Value()
                objTotalesAV.idItem = i.Cells(10).Value()
                objTotalesAV.descripcion = i.Cells(11).Value()
                objTotalesAV.idUnidad = i.Cells(13).Value()
                objTotalesAV.unidadMedida = Nothing
                objTotalesAV.cantidad = CType(i.Cells(12).Value(), Decimal)
                objTotalesAV.precioUnitarioCompra = CType(i.Cells(15).Value(), Decimal)
                objTotalesAV.importeSoles = CType(i.Cells(16).Value(), Decimal)
                objTotalesAV.importeDolares = CType(i.Cells(18).Value(), Decimal)
                objTotalesAV.montoIsc = 0
                objTotalesAV.montoIscUS = 0
                objTotalesAV.Otros = 0
                objTotalesAV.OtrosUS = 0
                objTotalesAV.porcentajeUtilidad = 0
                objTotalesAV.importePorcentaje = 0
                objTotalesAV.importePorcentajeUS = 0
                objTotalesAV.precioVenta = 0
                objTotalesAV.precioVentaUS = 0
                objTotalesAV.usuarioActualizacion = "NN"
                objTotalesAV.fechaActualizacion = Date.Now
                ListaTotalesAV.Add(objTotalesAV)

                ''------------------------------- lista de precio -----------------------------------------
                ''-----------------------------------------------------------------------------------------
                'If (dgvDistribucion.Rows(i.Index).Cells(31).Value() <> listaPrecioSA.UbicarPrecioNuevo(txtAlmacen.ValueMember, dgvDistribucion.Rows(i.Index).Cells(10).Value(), "SIVA")) Then
                '    'If dgvDistribucion.Rows(i.Index).Cells(19).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                '    SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                '    IGV = CDec(TmpIGV / 100)
                '    TC = CDec(TmpTipoCambio)
                '    PrecioUnitarioMN = CDec(i.Cells(15).Value)
                '    utilidad = i.Cells(31).Value
                '    xMenor = (2 / 100)
                '    xMayor = (4 / 100)
                '    xGMayor = (6 / 100)
                '    '18.64

                '    PreciosConIVABE = New listadoPrecios
                '    With PreciosConIVABE

                '        .idEmpresa = Gempresas.IdEmpresaRuc
                '        .idEstablecimiento = GEstableciento.IdEstablecimiento
                '        .idAlmacen = txtAlmacen.ValueMember
                '        .fecha = Date.Now
                '        .tipoExistencia = (i.Cells(14).Value)
                '        .destinoGravado = 1
                '        .idItem = CDec(i.Cells(10).Value)
                '        .descripcion = (i.Cells(11).Value)
                '        .presentacion = Nothing
                '        .unidad = (i.Cells(13).Value)

                '        '16.95
                '        SIVAvalorVentaMN = ((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (utilidad / 100)))
                '        .valcompraIgvMN = Math.Round((PrecioUnitarioMN / SIVA), 2)
                '        .valcompraIgvME = Math.Round((PrecioUnitarioMN / SIVA) / TC, 2)
                '        .valcompraSinIgvMN = 0
                '        .valcompraSinIgvME = 0

                '        .tipoConfiguracion = "SIVA"

                '        .montoUtilidad = Math.Round((utilidad / 100) * (PrecioUnitarioMN / SIVA), 2)
                '        .montoUtilidadME = Math.Round(((utilidad / 100) * (PrecioUnitarioMN / SIVA)) / TC, 2)
                '        .utilidadsinIgvMN = 0.0
                '        .utilidadsinIgvME = 0.0

                '        .valorVentaMN = Math.Round(SIVAvalorVentaMN, 2)
                '        .valorVentaME = Math.Round(SIVAvalorVentaMN / TC, 2)

                '        .igvMN = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
                '        .igvME = Math.Round(CDec((SIVAvalorVentaMN) * IGV) / TC, 2)
                '        .iscMN = 0.0
                '        .otcMN = 0.0
                '        .iscME = 0.0
                '        .otcME = 0.0
                '        .precioVentaMN = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)
                '        .precioVentaME = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) / TC, 2)

                '        .PorDsctounitMenor = 2
                '        .montoDsctounitMenorMN = Math.Round((PrecioUnitarioMN / SIVA) * xMenor, 2)
                '        .montoDsctounitMenorME = Math.Round(((PrecioUnitarioMN / SIVA) * xMenor) / TC, 2)
                '        .precioVentaFinalMenorMN = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMenor), 2)
                '        .precioVentaFinalMenorME = Math.Round(((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMenor)) / TC, 2)

                '        .PorDsctounitMayor = 4
                '        .montoDsctounitMayorMN = Math.Round((PrecioUnitarioMN / SIVA) * xMayor, 2)
                '        .montoDsctounitMayorME = Math.Round(((PrecioUnitarioMN / SIVA) * xMayor) / TC, 2)
                '        .precioVentaFinalMayorMN = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMayor), 2)
                '        .precioVentaFinalMayorME = Math.Round(((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xMayor)) / TC, 2)

                '        .PorDsctounitGMayor = 6
                '        .montoDsctounitGMayorMN = Math.Round((PrecioUnitarioMN / SIVA) * xGMayor, 2)
                '        .montoDsctounitGMayorME = Math.Round(((PrecioUnitarioMN / SIVA) * xGMayor) / TC, 2)
                '        .precioVentaFinalGMayorMN = Math.Round((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xGMayor), 2)
                '        .precioVentaFinalGMayorME = Math.Round(((SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - ((PrecioUnitarioMN / SIVA) * xGMayor)) / TC, 2)

                '        .cantidadMenor = 0
                '        .cantidadMayor = 0
                '        .cantidadGMayor = 0
                '        .usuarioActualizacion = "Jiuni"
                '        .fechaActualizacion = Date.Now
                '        listaprecios.Add(PreciosConIVABE)
                '    End With

                '    PreciosSINIVABE = New listadoPrecios
                '    With PreciosSINIVABE

                '        .idEmpresa = Gempresas.IdEmpresaRuc
                '        .idEstablecimiento = GEstableciento.IdEstablecimiento
                '        .idAlmacen = txtAlmacen.ValueMember
                '        .fecha = Date.Now
                '        .tipoExistencia = (i.Cells(14).Value)
                '        .destinoGravado = 1
                '        .idItem = CDec(i.Cells(10).Value)
                '        .descripcion = (i.Cells(11).Value)
                '        .presentacion = Nothing
                '        .unidad = (i.Cells(13).Value)

                '        NIVAvalorVentaMN = ((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (utilidad / 100)))

                '        .valcompraIgvMN = 0
                '        .valcompraIgvME = 0
                '        .valcompraSinIgvMN = Math.Round(PrecioUnitarioMN, 2)
                '        .valcompraSinIgvME = Math.Round(PrecioUnitarioMN / TC, 2)
                '        .tipoConfiguracion = "NIVA"

                '        .montoUtilidad = 0.0
                '        .montoUtilidadME = 0.0
                '        .utilidadsinIgvMN = Math.Round((utilidad / 100) * (PrecioUnitarioMN), 2)
                '        .utilidadsinIgvME = Math.Round(((utilidad / 100) * (PrecioUnitarioMN)) / TC, 2)

                '        .valorVentaMN = Math.Round(NIVAvalorVentaMN, 2)
                '        .valorVentaME = Math.Round(NIVAvalorVentaMN / TC, 2)

                '        .igvMN = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
                '        .igvME = Math.Round(CDec((NIVAvalorVentaMN) * IGV) / TC, 2)
                '        .iscMN = 0.0
                '        .otcMN = 0.0
                '        .iscME = 0.0
                '        .otcME = 0.0
                '        .precioVentaMN = Math.Round(NIVAvalorVentaMN, 2)
                '        .precioVentaME = Math.Round((NIVAvalorVentaMN) / TC, 2)

                '        .PorDsctounitMenor = 2
                '        .montoDsctounitMenorMN = Math.Round((PrecioUnitarioMN) * xMenor, 2)
                '        .montoDsctounitMenorME = Math.Round(((PrecioUnitarioMN) * xMenor) / TC, 2)
                '        .precioVentaFinalMenorMN = Math.Round((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMenor), 2)
                '        .precioVentaFinalMenorME = Math.Round(((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMenor)) / TC, 2)

                '        .PorDsctounitMayor = 4
                '        .montoDsctounitMayorMN = Math.Round((PrecioUnitarioMN) * xMayor, 2)
                '        .montoDsctounitMayorME = Math.Round(((PrecioUnitarioMN) * xMayor) / TC, 2)
                '        .precioVentaFinalMayorMN = Math.Round((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMayor), 2)
                '        .precioVentaFinalMayorME = Math.Round(((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xMayor)) / TC, 2)

                '        .PorDsctounitGMayor = 6
                '        .montoDsctounitGMayorMN = Math.Round((PrecioUnitarioMN) * xGMayor, 2)
                '        .montoDsctounitGMayorME = Math.Round(((PrecioUnitarioMN) * xGMayor) / TC, 2)
                '        .precioVentaFinalGMayorMN = Math.Round((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xGMayor), 2)
                '        .precioVentaFinalGMayorME = Math.Round(((NIVAvalorVentaMN) - ((PrecioUnitarioMN) * xGMayor)) / TC, 2)

                '        .cantidadMenor = 0
                '        .cantidadMayor = 0
                '        .cantidadGMayor = 0
                '        .usuarioActualizacion = "Jiuni"
                '        .fechaActualizacion = Date.Now

                '        listaprecios.Add(PreciosSINIVABE)
                '    End With
                '    'End If
                'End If

                '-----------------------------------------------------------------------------------------
            Next
            'listaprecios = listaPrecioConIVA()
            InventarioSA.InsertItemsEnTransitoSL(ListaSalida, ListaEntrada, ListaAsientonTransito, ListaTotales, documento, ListaTotalesAV, listaprecios)
            n.Estado = "Grabado"
            datos.Add(n)
            lblEstado.Text = "Items procesados a almacén"
            lblEstado.Image = My.Resources.ok4
            'For Each i In frmInventarioTransito.lsvDistribucion.CheckedItems
            '    'frmInventarioTransito.lsvDistribucion.Items(i).Remove()
            '    frmInventarioTransito.lsvDistribucion.Items.Remove(i)
            'Next
            Dispose()
        Catch ex As Exception
            MsgBox("No se pudo grabar la información " + vbCrLf + ex.Message)
            n.Estado = "Cancel"
            datos.Add(n)
        End Try
    End Sub

#End Region

#Region "CLASES"
    Public Sub ObtenerValidacionAsientos()
        Dim solesH As Decimal = 0
        Dim solesD As Decimal = 0
        Dim usdH As Decimal = 0
        Dim usdD As Decimal = 0
        For Each i As DataGridViewRow In dgvAsiento.Rows
            If i.Cells(2).Value = "D" Then
                solesD += i.Cells(3).Value
                usdD += i.Cells(4).Value
            ElseIf i.Cells(2).Value = "H" Then
                solesH += i.Cells(3).Value
                usdH += i.Cells(4).Value
            End If
        Next
        '  nudSolesDebe.Value = solesD
        '  nudSolesHaber.Value = solesH
        '  nudDolaresDebe.Value = usdD
        ' nudDolaresHaber.Value = usdH
    End Sub

    Private Sub ObtenerCabeceraCuentaDestino(ByVal ALMACEN As String, ByVal CONTADOR As Short, ByVal Establecimiento As String, ByVal strIDDocumento As String, ByVal strDoRef As String, ByVal strDate As Date)
        Try
            dgvCabeceraAsientos.Rows.Add(CONTADOR, ALMACEN, Establecimiento, strIDDocumento, strDoRef, strDate.ToShortDateString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCuentaDestino(ByVal ALMACEN As String, ByVal MONTOSOLES As Decimal, ByVal MONTOUSD As Decimal, ByVal CONTADOR As Short, ByVal cuentaContable As String, ByVal strTipoExistencia As String)
        Dim objLista As New mascaraContable2SA
        Dim mascaraContable As New mascaraContable2
        Dim objListaExistencia As New mascaraContableExistenciaSA
        Dim mascaraExistencia As mascaraContableExistencia
        Try

            Select Case strTipoExistencia

                Case "01"
                    mascaraContable = objLista.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cuentaContable)
                    If Not IsNothing(mascaraContable) Then

                        dgvAsiento.Rows.Add(mascaraContable.cuentaDestinoKardex, ALMACEN, mascaraContable.asientoDestinoKardex, MONTOSOLES.ToString("N2"), "0.00", MONTOUSD.ToString("N2"), "0.00", CONTADOR)
                        dgvAsiento.Rows.Add(mascaraContable.cuentaDestinoKardex2, ALMACEN, mascaraContable.asientoDestinoKardex2, "0.00", MONTOSOLES.ToString("N2"), "0.00", MONTOUSD.ToString("N2"), CONTADOR)
                        '    dgvDistribucion.EndEdit()
                    End If

                Case Else
                    mascaraExistencia = objListaExistencia.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cuentaContable, strTipoExistencia)
                    If Not IsNothing(mascaraExistencia) Then
                        dgvAsiento.Rows.Add(mascaraExistencia.cuentaIngAlmacen, ALMACEN, mascaraExistencia.asientoIngAlmacen, MONTOSOLES.ToString("N2"), "0.00", MONTOUSD.ToString("N2"), "0.00", CONTADOR)
                        dgvAsiento.Rows.Add(mascaraExistencia.cuentaIngAlmacen2, ALMACEN, mascaraExistencia.asientoIngAlmacen2, "0.00", MONTOSOLES.ToString("N2"), "0.00", MONTOUSD.ToString("N2"), CONTADOR)
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ObetenerAsientosContablesFull()
        dgvCabeceraAsientos.Rows.Clear()
        dgvAsiento.Rows.Clear()
        Dim contador As Short = 0
        For Each i As DataGridViewRow In dgvDistribucion.Rows
            contador += 1
            ObtenerCabeceraCuentaDestino(String.Concat("AST. ", i.Cells(3).Value), contador, i.Cells(0).Value, i.Cells(21).Value, i.Cells(21).Value, i.Cells(5).Value)
            ObtenerCuentaDestino(String.Concat(i.Cells(11).Value), i.Cells(16).Value, i.Cells(18).Value, contador, i.Cells(20).Value, i.Cells(14).Value)
        Next
    End Sub
#End Region

#Region "Métodos"

    Public Sub ObtenerAlmacenes(intIdEstablecimiento As Integer)
        Dim almacenSA As New almacenSA

        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = intIdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Public Sub cargarCombos(ByVal caso As String)
        Dim objLista As New tablaDetalleSA
        '   Dim ObjListaCuentas() As HeliosService.CuentaplancontableBO
        Dim objEstablecimiento As New establecimientoSA
        Dim dtRecaudo As New DataTable()
        Dim dtEstab As New DataTable()
        Try
            Select Case caso
                Case "All"

                    dtEstab.Columns.Add("idCentroCosto")
                    dtEstab.Columns.Add("Empresa")
                    dtEstab.Columns.Add("Nombre")
                    dtEstab.Columns.Add("Tipo")
                    dtEstab.Rows.Add("", "", "", "")
                    For Each i In objEstablecimiento.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
                        dtEstab.Rows.Add(i.idCentroCosto, i.idEmpresa, i.nombre, i.TipoEstab)
                    Next

                    cboComprobante.DisplayMember = "descripcion"
                    cboComprobante.ValueMember = "codigoDetalle"
                    cboComprobante.DataSource = objLista.GetListaTablaDetalle(10, "1")


                Case "ESTB"
                    dtEstab.Columns.Add("idCentroCosto")
                    dtEstab.Columns.Add("Empresa")
                    dtEstab.Columns.Add("Nombre")
                    dtEstab.Columns.Add("Tipo")
                    dtEstab.Rows.Add("", "", "", "")
                    For Each i In objEstablecimiento.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
                        dtEstab.Rows.Add(i.idCentroCosto, i.idEmpresa, i.nombre, i.TipoEstab)
                    Next


                Case "ALM"


            End Select



        Catch ex As Exception
            MsgBox("No se puedo cargar la información para los combos", +vbCrLf + ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmDistribucionMasiva_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmDistribucionMasiva_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub dgvDistribucion_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDistribucion.CellBeginEdit

    End Sub

    Private Sub dgvDistribucion_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDistribucion.CellContentClick

    End Sub

    Private Sub dgvDistribucion_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDistribucion.CellMouseDoubleClick
        If dgvDistribucion.Columns(e.ColumnIndex).Name = "Establecimiento" Or dgvDistribucion.Columns(e.ColumnIndex).Name = "Almacen" Then
            ' If e.Clicks = 2 Or e.Clicks = 1 Then
            With frmMenuDistribucion
                .ObtenerEstablecimientos()
                .StartPosition = FormStartPosition.CenterParent
                .txtDia.Text = Mid(dgvDistribucion.Item(5, dgvDistribucion.CurrentRow.Index).Value, 1, 2)
                .txtMes.Text = Mid(dgvDistribucion.Item(5, dgvDistribucion.CurrentRow.Index).Value, 4, 2)
                .txtAnio.Text = Mid(dgvDistribucion.Item(5, dgvDistribucion.CurrentRow.Index).Value, 7, 4)
                .Tag = 2
                '.destino = frmInventarioAlmacen.lsvDistribucion.SelectedItems(0).SubItems(0).Text
                .ShowDialog()
                ObetenerAsientosContablesFull()
                '  CalcularDistribucion()
            End With
            ' End If
        ElseIf dgvDistribucion.Columns(e.ColumnIndex).Name = "Serie" Then

        End If
    End Sub

    Private Sub dgvCabeceraAsientos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCabeceraAsientos.CellContentClick

    End Sub

    Private Sub dgvCabeceraAsientos_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCabeceraAsientos.CellMouseClick
        'Dim value As DataGridViewSelectedRowCollection
        'value = dgvAsiento.SelectedRows
        'For Each vfila As DataGridViewRow In value
        '    dgvAsiento.SelectedRows(vfila)
        'Next

        '    Private Sub dgDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDatos.KeyDown
        '        If e.KeyCode = Keys.Delete Then
        '            Dim value As DataGridViewSelectedRowCollection
        '            value = dgDatos.SelectedRows

        '            For Each vfila As DataGridViewRow In value
        '                dgDatos.Rows.Remove(vfila)
        'End If
        'Next
        'End If
        '    End Sub
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Dispose()
    End Sub

    Private Sub dgvDistribucion_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDistribucion.DataError
        Dim ex As Exception = e.Exception
        MessageBox.Show(ex.Message)
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
     
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalEstablecimientoCaja
        '    .StrParametroCarga = "ET"
        '    .ObtenerEstablecimientos()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtEstablecimiento.ValueMember = datos(0).ID
        '        txtEstablecimiento.Text = datos(0).NombreCampo
        '        ObtenerAlmacenes(txtEstablecimiento.ValueMember)
        '    Else

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'datos.Clear()
        'With frmModalAlmacen
        '    .ObtenerAlmacenes(txtEstablecimiento.ValueMember)
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtAlmacen.ValueMember = datos(0).ID
        '        txtAlmacen.Text = datos(0).NombreEntidad
        '    End If

        'End With
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumero.Select()
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        Try
            Select Case txtTipoDoc.ValueMember
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtAlmacen.Select()
            txtAlmacen.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        Try
            Select Case txtTipoDoc.ValueMember
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtNumero.Text = "" Or Not String.IsNullOrEmpty(txtNumero.Text) Then
                        If IsNumeric(txtNumero.Text) Then
                            If txtNumero.Text.Length = 20 Then

                            Else
                                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumero.Clear()
                            txtNumero.Focus()
                            txtNumero.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtNumero.Text = "" Or Not String.IsNullOrEmpty(txtNumero.Text) Then
                        If IsNumeric(txtNumero.Text) Then
                            If txtNumero.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumero.Clear()
                            txtNumero.Focus()
                            txtNumero.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"
                    If Not txtNumero.Text = "" Or Not String.IsNullOrEmpty(txtNumero.Text) Then
                        If IsNumeric(txtNumero.Text) Then
                            If txtNumero.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumero.Clear()
                            txtNumero.Focus()
                            txtNumero.SelectAll()
                        End If
                    End If
                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        Dispose()
    End Sub

    Private Sub txtTipoDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoDoc.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcAlmacen_Popup(sender As Object, e As EventArgs) Handles pcAlmacen.Popup
        lstAlmacen.Focus()
    End Sub

    Private Sub txtAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.pcAlmacen.IsShowing() Then
                ' Let the popup align around the source textBox.
                pcAlmacen.Font = New Font("Segoe UI", 8)
                pcAlmacen.Size = New Size(260, 110)
                Me.pcAlmacen.ParentControl = Me.txtAlmacen
                Me.pcAlmacen.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.pcAlmacen.IsShowing() Then
                Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtAlmacen_TextChanged(sender As Object, e As EventArgs) Handles txtAlmacen.TextChanged

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click


        If MessageBoxAdv.Show("¿ Desea Guardar con está fecha ?" + vbCrLf + vbCrLf + Space(15) + txtFecha.Text, txtFecha.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


            Me.Cursor = Cursors.WaitCursor

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un número de serie válido"
                lblEstado.Image = My.Resources.warning2
                TiempoEjecutar(5)
                txtSerie.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un número de guía válido"
                lblEstado.Image = My.Resources.warning2
                TiempoEjecutar(5)
                txtNumero.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If dgvDistribucion.Rows.Count > 0 Then
                SaveMovimentosES()
            Else
                lblEstado.Text = "Debe indicar items a procesar"
                lblEstado.Image = My.Resources.warning2
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
            End If
            Me.Cursor = Cursors.Arrow

        Else


        End If


    End Sub



End Class