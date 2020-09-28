Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Linq
Public Class frmOtrasEntradasAlmacen
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime
    'Existencia Atual del almacen por articulo a trasnsferir
    Private cantidaExistente As New List(Of Integer)

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        cboModulo.SelectedIndex = 0
        cambioMovimiento()
        ObtenerAlmacenes(txtEstablecimiento.ValueMember)
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

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
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
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

#Region "Arbol"
    Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & "Jiuni")
    Dim newNodeComprobante As TreeNode = New TreeNode("Comp. Otras entradas")
    '  Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
    ' Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
    Dim newNodeCuenta As TreeNode = New TreeNode("Asiento Contable")
    Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la Entrada")
    Private Sub LoadTree(ByVal caso As Byte)
        ' TODO: Agregar código a elementos en la vista de árbol
        With tvDatos
            '  Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & cIDUsuario)
            tvDatos.Nodes.Add(newNodeUsuario)

            '  Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante compra")
            newNodeComprobante.Tag = "IF"
            tvDatos.Nodes.Add(newNodeComprobante)

            '  Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
         '

            '  Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
            'newNodeCosto.Tag = "DC"
            'tvDatos.Nodes.Add(newNodeCosto)



            '   Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la compra")
            newNodeDetalle.Tag = "DT"
            tvDatos.Nodes.Add(newNodeDetalle)
            Select Case caso
                Case 1
                    newNodeCuenta.Tag = "IP"
                    tvDatos.Nodes.Add(newNodeCuenta)
                Case 0

            End Select

   
        End With
    End Sub
#End Region

#Region "Métodos"

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = lblIdDocumento.Text
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .periodo = lblPeriodo.Text
            .tipoDoc = "99"
            .serie = txtSerieGuia.Text
            .numeroDoc = txtNumGuia.Text
            .idEntidad = txtidProveedor.Text
            .monedaDoc = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value
            .tipoCambio = nudTipoCambio.Value
            .importeMN = CDec(lblTotalAdquisiones.Text)
            .importeME = CDec(lblTotalUS.Text)
            .glosa = txtGlosa.Text
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                documentoguiaDetalle = New documentoguiaDetalle
                documentoguiaDetalle.idDocumento = lblIdDocumento.Text
                documentoguiaDetalle.idItem = i.Cells(2).Value
                documentoguiaDetalle.descripcionItem = i.Cells(3).Value
                documentoguiaDetalle.destino = i.Cells(1).Value
                documentoguiaDetalle.unidadMedida = i.Cells(6).Value
                documentoguiaDetalle.cantidad = CDec(i.Cells(7).Value)

                documentoguiaDetalle.precioUnitario = CDec(i.Cells(8).Value)
                documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(9).Value)
                documentoguiaDetalle.importeMN = CDec(i.Cells(10).Value)
                documentoguiaDetalle.importeME = CDec(i.Cells(11).Value)

                documentoguiaDetalle.almacenRef = CInt(i.Cells(17).Value)

                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim asientoSA As New AsientoSA
        Dim movimientoSA As New MovimientoSA

        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                txtFechaComprobante.Value = .fechaProceso
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    txtIdComprobante.Text = .codigoDetalle
                    txtComprobante.Text = .descripcion
                End With
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                Select Case .destino
                    Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
                        cboModulo.Text = "TRANSFERENCIA ENTRE ALMACENES"
                        ToolStripLabel1.Text = "TRANSFERENCIA ENTRE ALMACENES"
                    Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
                        cboModulo.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                        ToolStripLabel1.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                End Select

                lblIdDocumento.Text = .idDocumento
                txtFechaComprobante.Text = .fechaDoc
                lblPeriodo.Text = .fechaContable
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCuenta.Text = nEntidad.cuentaAsiento
                txtidProveedor.Text = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                nudTipoCambio.Value = .tcDolLoc
            End With


            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            Dim almacenSA As New almacenSA
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If

                dgvNuevoDoc.Rows.Add(i.secuencia,
                                     VALUEDES,
                                     i.idItem,
                                     i.descripcionItem,
                                     i.unidad2,
                                     i.monto2,
                                     i.unidad1,
                                     FormatNumber(i.monto1, 2),
                                     FormatNumber(i.precioUnitario, 2),
                                     FormatNumber(i.precioUnitarioUS, 2),
                                     FormatNumber(i.importe, 2),
                                     FormatNumber(i.importeUS, 2),
                                     Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                     insumosSA.InvocarProductoID(i.idItem).cuenta,
                                     i.preEvento, Nothing, i.almacenRef, almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen,
                                     Nothing, i.almacenRef)
            Next
            'datos.Clear()
            'datosMov.Clear()
            Dim datos As List(Of Asientos_MN) = Asientos_MN.GetAsientos()
            Dim datosMov As List(Of Movimientos) = Movimientos.GetMovimientos()
            Dim asiento_mn As New Asientos_MN
            Dim movimiento_mn As New Movimientos
            Dim conteoAs As Short = 0
            Dim conteoMV As Short = 0
            datos.Clear()
            datosMov.Clear()
            For Each i In asientoSA.UbicarAsientoPorDocumento(intIdDocumento)
                asiento_mn = New Asientos_MN
                conteoAs += 1
                asiento_mn.AsientoID = conteoAs
                asiento_mn.NombreAsiento = i.glosa
                asiento_mn.Tipo = i.tipoAsiento
                datos.Add(asiento_mn)

                For Each ix In movimientoSA.UbicarMovimientoPorAsiento(i.idAsiento)
                    conteoMV += 1
                    movimiento_mn = New Movimientos
                    movimiento_mn.AsientoID = conteoAs
                    movimiento_mn.IdMovimiento = conteoMV
                    movimiento_mn.Cuenta = ix.cuenta
                    movimiento_mn.Descripcion = ix.descripcion
                    movimiento_mn.Tipo = ix.tipo
                    movimiento_mn.Importemn = ix.monto
                    movimiento_mn.Importeme = ix.montoUSD
                    datosMov.Add(movimiento_mn)
                Next
            Next
            lstAsientos.DataSource = Nothing
            lstAsientos.DisplayMember = "NombreAsiento"
            lstAsientos.ValueMember = "AsientoID"
            lstAsientos.DataSource = datos


            lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(i.Cells(17).Value())).idEstablecimiento
            objTotalesDet.idAlmacen = i.Cells(17).Value()
            objTotalesDet.origenRecaudo = i.Cells(1).Value()
            objTotalesDet.tipoCambio = nudTipoCambio.Value
            objTotalesDet.tipoExistencia = i.Cells(13).Value()
            objTotalesDet.idItem = i.Cells(2).Value()
            objTotalesDet.descripcion = i.Cells(3).Value()
            objTotalesDet.idUnidad = i.Cells(6).Value()
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal)
            objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal)
            objTotalesDet.importeSoles = CType(i.Cells(10).Value(), Decimal)
            objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
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

        Return ListaTotales
    End Function

    Private Function ListaTotalesAlmacenOrigen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(i.Cells(21).Value())).idEstablecimiento
            objTotalesDet.idAlmacen = i.Cells(21).Value()
            objTotalesDet.origenRecaudo = i.Cells(1).Value()
            objTotalesDet.tipoCambio = nudTipoCambio.Value
            objTotalesDet.tipoExistencia = i.Cells(13).Value()
            objTotalesDet.idItem = i.Cells(2).Value()
            objTotalesDet.descripcion = i.Cells(3).Value()
            objTotalesDet.idUnidad = i.Cells(6).Value()
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal) * -1
            objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal) * -1
            objTotalesDet.importeSoles = CType(i.Cells(10).Value(), Decimal) * -1
            objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal) * -1
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

        Return ListaTotales
    End Function

    Sub AsientoTransferenciaEntreAlmacenes()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = txtidProveedor.Text
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = fecha
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(lblTotalAdquisiones.Text)
            asientoBL.importeME = CDec(lblTotalUS.Text)
            asientoBL.glosa = txtGlosa.Text

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                nMovimiento = New movimiento
                If i.Cells(13).Value = "01" Then
                    nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, i.Cells(14).Value).cuentaDestinoKardex
                Else
                    nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, i.Cells(14).Value, i.Cells(13).Value).cuentaIngAlmacen
                End If
                nMovimiento.descripcion = i.Cells(3).Value
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(i.Cells(10).Value)
                nMovimiento.montoUSD = CDec(i.Cells(11).Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
                asientoBL.movimiento.Add(HaberTransferenciaMOv(i))
            Next
            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Function HaberTransferenciaMOv(i As DataGridViewRow) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        If i.Cells(13).Value = "01" Then
            nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, i.Cells(14).Value).cuentaDestinoKardex
        Else
            nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, i.Cells(14).Value, i.Cells(13).Value).cuentaIngAlmacen
        End If
        nMovimiento.descripcion = i.Cells(3).Value
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(i.Cells(10).Value)
        nMovimiento.montoUSD = CDec(i.Cells(11).Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Function HaberOtrasExistenciasMOv(i As DataGridViewRow) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1000"
        nMovimiento.descripcion = i.Cells(3).Value
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(i.Cells(10).Value)
        nMovimiento.montoUSD = CDec(i.Cells(11).Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Sub AsientoEntrada()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim TLmn As Decimal = 0
        Dim TLme As Decimal = 0
        For Each i In datos
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = txtidProveedor.Text
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = fecha
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.glosa = i.NombreAsiento
            listaMovimiento = ListarMovimientoporAsiento(i.AsientoID)
            For Each x In listaMovimiento
                nMovimiento = New movimiento
                nMovimiento.cuenta = x.Cuenta
                nMovimiento.idAsiento = x.AsientoID
                nMovimiento.descripcion = x.Descripcion
                nMovimiento.tipo = x.Tipo
                nMovimiento.monto = x.Importemn
                nMovimiento.montoUSD = x.Importeme
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Next
            asientoBL.importeMN = SumatoriaMovimientosMN(i.AsientoID, "D")
            asientoBL.importeME = SumatoriaMovimientosME(i.AsientoID, "D")
            ListaAsientonTransito.Add(asientoBL)
        Next
    End Sub

    Sub AsientoEntradaExistencia()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = txtidProveedor.Text
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = fecha
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(lblTotalAdquisiones.Text)
            asientoBL.importeME = CDec(lblTotalUS.Text)
            asientoBL.glosa = txtGlosa.Text

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                    nMovimiento = New movimiento
                    If dgvNuevoDoc.Rows(i.Index).Cells(13).Value = "01" Then
                        nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, dgvNuevoDoc.Rows(i.Index).Cells(14).Value).cuentaDestinoKardex
                    Else
                        nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, dgvNuevoDoc.Rows(i.Index).Cells(14).Value, dgvNuevoDoc.Rows(i.Index).Cells(13).Value).cuentaIngAlmacen
                    End If
                    nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                    nMovimiento.tipo = "D"
                    nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value)
                    nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value)
                    nMovimiento.usuarioActualizacion = "Jiuni"
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)
                    asientoBL.movimiento.Add(HaberOtrasExistenciasMOv(i))
                End If
            Next
            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = txtidProveedor.Text
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            
            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = IIf(IsNothing(QRibbonInputBox3.Text) Or String.IsNullOrEmpty(QRibbonInputBox3.Text) Or String.IsNullOrWhiteSpace(QRibbonInputBox3.Text), Nothing, Trim(QRibbonInputBox3.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra


        GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = i.Cells(19).Value()
            objDocumentoCompraDet.FechaDoc = fecha
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = txtIdComprobante.Text
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = i.Cells(14).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(13).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
            'objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
            'objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
            'objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
            'objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
            ''**********************************************************************************
            'objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
            'objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
            'objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
            'objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())
            objDocumentoCompraDet.preEvento = i.Cells(15).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            'objDocumentoCompraDet.bonificacion = i.Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.almacenRef = CDec(i.Cells(21).Value())
            objDocumentoCompraDet.almacenDestino = CDec(i.Cells(17).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = QRibbonInputBox3.Text.Trim
            ' objDocumentoCompraDet.BonificacionMN =
            ValidarCantidad(dgvNuevoDoc.CurrentRow.Index)

            If i.Cells(18).Value() = "Asignar almacén" Then
                lblEstado.Text = "Debe asignar un almacén en la celda!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If


            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen() '+positivo

        Select Case cboModulo.Text
            Case "TRANSFERENCIA ENTRE ALMACENES"
                AsientoTransferenciaEntreAlmacenes()
                ListaTotalesOrigen = ListaTotalesAlmacenOrigen() 'negativo
            Case Else
                AsientoEntrada()
        End Select

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        Dim xcod As Integer = CompraSA.SaveOtrasEntradas(ndocumento, ListaTotales, ListaTotalesOrigen)
        lblEstado.Text = "entrada registrada!"
        lblEstado.Image = My.Resources.ok4

        Dim n As New ListViewItem(xcod)
        n.UseItemStyleForSubItems = False
        n.SubItems.Add("13").BackColor = Color.FromArgb(225, 240, 190)
        n.SubItems.Add(ndocumento.documentocompra.fechaDoc)
        n.SubItems.Add(ndocumento.documentocompra.tipoDoc)
        n.SubItems.Add(ndocumento.documentocompra.serie)
        n.SubItems.Add(ndocumento.documentocompra.numeroDoc)

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        n.SubItems.Add(entidad.tipoDoc)
        n.SubItems.Add(txtRuc.Text)
        n.SubItems.Add(txtProveedor.Text)
        n.SubItems.Add(txtTipoEntidad.Text)

        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeTotal, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.tcDolLoc, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeUS, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.monedaDoc, 2))
        n.SubItems.Add("TEA")
        ' n.Group = g

        With frmMantenimientoOtrasEntradas
            '  Dim strNom = .lsvProduccion.Groups(g.Name.First)
            '   n.Group = .lsvProduccion.Groups(txtProveedor.Text)
            .lsvProduccion.Items.Add(n)
        End With
        Dispose()
    End Sub

    Sub GrabarDefault()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = txtidProveedor.Text
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = IIf(IsNothing(QRibbonInputBox3.Text) Or String.IsNullOrEmpty(QRibbonInputBox3.Text) Or String.IsNullOrWhiteSpace(QRibbonInputBox3.Text), Nothing, Trim(QRibbonInputBox3.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = i.Cells(19).Value()
            objDocumentoCompraDet.FechaDoc = fecha
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = txtIdComprobante.Text
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = i.Cells(14).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(13).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
            'objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
            'objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
            'objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
            'objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
            ''**********************************************************************************
            'objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
            'objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
            'objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
            'objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())
            objDocumentoCompraDet.preEvento = i.Cells(15).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            'objDocumentoCompraDet.bonificacion = i.Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            If i.Cells(18).Value() = "Asignar almacén" Then
                lblEstado.Enabled = "Debe asignar un almacén en la celda!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            objDocumentoCompraDet.almacenRef = CDec(i.Cells(17).Value())
            '   objDocumentoCompraDet.almacenDestino = CDec(i.Cells(17).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = QRibbonInputBox3.Text.Trim
            ' objDocumentoCompraDet.BonificacionMN =



            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen() '+positivo
        AsientoEntradaExistencia()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        Dim xcod As Integer = CompraSA.SaveOtrasEntradasDefault(ndocumento, ListaTotales)
        lblEstado.Text = "entrada registrada!"
        lblEstado.Image = My.Resources.ok4

        Dim n As New ListViewItem(xcod)
        n.UseItemStyleForSubItems = False
        n.SubItems.Add("13").BackColor = Color.FromArgb(225, 240, 190)
        n.SubItems.Add(ndocumento.documentocompra.fechaDoc)
        n.SubItems.Add(ndocumento.documentocompra.tipoDoc)
        n.SubItems.Add(ndocumento.documentocompra.serie)
        n.SubItems.Add(ndocumento.documentocompra.numeroDoc)

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        n.SubItems.Add(entidad.tipoDoc)
        n.SubItems.Add(txtRuc.Text)
        n.SubItems.Add(txtProveedor.Text)
        n.SubItems.Add(txtTipoEntidad.Text)

        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeTotal, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.tcDolLoc, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeUS, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.monedaDoc, 2))
        n.SubItems.Add(ndocumento.documentocompra.destino)
        With frmMantenimientoOtrasEntradas
            .lsvProduccion.Items.Add(n)
        End With
        Dispose()
    End Sub


    Sub UpdateCompra()
        Dim CompraSA As New DocumentoCompraSA
        Dim DocCaja As New documento

        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim objTotalesDet As New totalesAlmacen()
        Dim objActividadDeleteEO As New totalesAlmacen()
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)
        Dim almacensa As New almacenSA

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = txtidProveedor.Text
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            '****************************************************************************************************************
            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = IIf(IsNothing(QRibbonInputBox3.Text) Or String.IsNullOrEmpty(QRibbonInputBox3.Text) Or String.IsNullOrWhiteSpace(QRibbonInputBox3.Text), Nothing, Trim(QRibbonInputBox3.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        GuiaRemision(ndocumento)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = txtEstablecimiento.ValueMember
            objDocumentoCompraDet.FechaDoc = fecha
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoCompraDet.TipoDoc = txtIdComprobante.Text
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim

            objDocumentoCompraDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()

            objDocumentoCompraDet.CuentaItem = dgvNuevoDoc.Rows(i.Index).Cells(14).Value()
            objDocumentoCompraDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(13).Value()
            objDocumentoCompraDet.descripcionItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoCompraDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
            objDocumentoCompraDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(7).Value())
            objDocumentoCompraDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())

            objDocumentoCompraDet.preEvento = dgvNuevoDoc.Rows(i.Index).Cells(15).Value()

            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            '**********************************************************************************
            If dgvNuevoDoc.Rows(i.Index).Cells(18).Value() = "Asignar almacén" Then
                lblEstado.Text = "Debe asignar un almacén en la celda!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            objDocumentoCompraDet.almacenRef = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value()) ' almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            objDocumentoCompraDet.Glosa = QRibbonInputBox3.Text.Trim
            ListaDetalle.Add(objDocumentoCompraDet)


            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.TipoDoc = txtComprobante.Text
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = almacensa.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(17).Value()).idEstablecimiento   ' almacensa.GetUbicar_almacenPorID(CInt(i.Cells(30).Value())).idEstablecimiento
                objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(17).Value() ' almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
                objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = "2.77"
                objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(13).Value()
                objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value(), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)

                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(10).Value(), Decimal)
                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value(), Decimal)

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
            End If

            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
                dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim almacenVR As New almacen
                Dim almacenFS As New almacen
                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = txtComprobante.Text
                objActividadDeleteEO.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                'almacenFS = almacensa.GetUbicar_almacenPorID(CInt(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))
                'If Not IsNothing(almacenFS) Then
                objActividadDeleteEO.idEstablecimiento = almacensa.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(20).Value()).idEstablecimiento '   txtIdEstableAlmacen.Text
                objActividadDeleteEO.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(20).Value() ' txtIdAlmacen.Text ' almacenFS.idAlmacen ' dgvNuevoDoc.Rows(i.Index).Cells(30).Value()
                'Else
                '    almacenVR = almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
                '    If Not IsNothing(almacenVR) Then
                '        objActividadDeleteEO.idEstablecimiento = almacenVR.idEstablecimiento
                '        objActividadDeleteEO.idAlmacen = almacenVR.idAlmacen
                '    End If

                ' End If
                objActividadDeleteEO.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = "2.77"
                objActividadDeleteEO.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(13).Value()
                objActividadDeleteEO.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objActividadDeleteEO.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If



        Next
        AsientoEntradaExistencia()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        CompraSA.UpdateOtrasEntradas(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "entrada modificada!"
        lblEstado.Image = My.Resources.ok4

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First

        With frmMantenimientoOtrasEntradas
            .lsvProduccion.SelectedItems(0).SubItems(1).Text = "02"
            .lsvProduccion.SelectedItems(0).SubItems(1).BackColor = Color.FromArgb(225, 240, 190)
            .lsvProduccion.SelectedItems(0).SubItems(2).Text = ndocumento.documentocompra.fechaDoc
            .lsvProduccion.SelectedItems(0).SubItems(3).Text = ndocumento.documentocompra.tipoDoc
            .lsvProduccion.SelectedItems(0).SubItems(4).Text = ndocumento.documentocompra.serie
            .lsvProduccion.SelectedItems(0).SubItems(5).Text = ndocumento.documentocompra.numeroDoc
            .lsvProduccion.SelectedItems(0).SubItems(6).Text = entidad.tipoDoc
            .lsvProduccion.SelectedItems(0).SubItems(7).Text = txtRuc.Text
            .lsvProduccion.SelectedItems(0).SubItems(8).Text = txtProveedor.Text
            .lsvProduccion.SelectedItems(0).SubItems(9).Text = txtTipoEntidad.Text
            .lsvProduccion.SelectedItems(0).SubItems(10).Text = FormatNumber(ndocumento.documentocompra.importeTotal, 2)
            .lsvProduccion.SelectedItems(0).SubItems(11).Text = FormatNumber(ndocumento.documentocompra.tcDolLoc, 2)
            .lsvProduccion.SelectedItems(0).SubItems(12).Text = FormatNumber(ndocumento.documentocompra.importeUS, 2)
            .lsvProduccion.SelectedItems(0).SubItems(13).Text = ndocumento.documentocompra.monedaDoc
            .lsvProduccion.SelectedItems(0).SubItems(14).Text = ndocumento.documentocompra.destino
        End With

        Dispose()
    End Sub

    Sub deletefila()
        Dim fila As Byte
        Try
            fila = dgvNuevoDoc.CurrentCell.RowIndex
            If fila > -1 And dgvNuevoDoc.Rows.Count > 0 Then
                '  total -= Single.Parse(dgvCentroCostos.Item(0, fila).Value)
                dgvNuevoDoc.Rows.RemoveAt(fila)
                Dim i As Integer
                For i = 0 To dgvNuevoDoc.Rows.Count - 1
                    dgvNuevoDoc.BeginEdit(True)
                    ' dgvNuevoDoc.Rows(i).BeginEdit()
                    '      dgvCentroCostos.Rows(i).Cells(0).Value() = i + 1
                    dgvNuevoDoc.EndEdit()
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub MostrarDetalle()
        Me.Cursor = Cursors.WaitCursor
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle()
        Dim strAlmacen As String = Nothing
        objInsumo.Clear()
        With frmModalExistencia
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count

            Select Case ManipulacionEstado
                Case ENTITY_ACTIONS.INSERT
                    If Not IsNothing(objInsumo.descripcionItem) Then
                        dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
                                             objInsumo.presentacion,
                                                 objInsumo.Nombrepresentacion,
                                                 objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU,
                                                 objInsumo.PU, objInsumo.Total, objInsumo.Total,
                                                 Business.Entity.BaseBE.EntityAction.INSERT,
                                              objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                              cboAlmacen.ValueMember, cboAlmacen.Text, txtEstablecimiento.ValueMember)
                    End If
                Case ENTITY_ACTIONS.UPDATE
                    If Not IsNothing(objInsumo.descripcionItem) Then
                        dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
                                             objInsumo.presentacion,
                                                 objInsumo.Nombrepresentacion,
                                                 objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU,
                                                 objInsumo.PU, objInsumo.Total, objInsumo.Total,
                                                 Business.Entity.BaseBE.EntityAction.INSERT,
                                              objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
                                              Nothing, "Asignar almacén", txtEstablecimiento.ValueMember)
                    End If
            End Select


            If dgvNuevoDoc.Rows.Count > 0 Then
                CellEndEditRefresh()
            End If

            If dgvNuevoDoc.Visible Then
                If dgvNuevoDoc.Rows.Count > 0 Then
                    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(dgvNuevoDoc.Rows.Count - 1).Cells(5)
                    Me.dgvNuevoDoc.BeginEdit(True)
                End If
            Else
                'If dgvSinControl.Rows.Count > 0 Then
                '    Me.dgvSinControl.CurrentCell = Me.dgvSinControl.Rows(dgvSinControl.Rows.Count - 1).Cells(10)
                '    Me.dgvSinControl.BeginEdit(True)
                'End If
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    'Sub ProveedoresShows()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    With frmModalEntidades
    '        .lblTipo.Text = "PR"
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            txtRuc.Text = datos(0).NroDoc
    '            txtCuenta.Text = datos(0).Cuenta
    '            txtidProveedor.Text = datos(0).ID
    '            txtProveedor.Text = datos(0).NombreEntidad

    '            txtProveedor.Focus()
    '        Else
    '            'txtRuc.Text = String.Empty
    '            'txtCuenta.Text = String.Empty
    '            'txtidProveedor.Text = String.Empty
    '            'txtProveedor.Text = String.Empty

    '            txtProveedor.Focus()
    '        End If
    '    End With

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub MyMethodOnCheckBoxes()
        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            '  MsgBox(True)

            dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            CellEndEditRefresh()
            dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "N"

        End If
    End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0


        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If i.Cells(12).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(11).Value)
            End If
        Next
        lblTotalAdquisiones.Text = cTotalMN.ToString("N2")
        lblTotalUS.Text = cTotalME.ToString("N2")

    End Sub


    Private Sub glosa()
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(txtidProveedor.Text) Then
            QRibbonInputBox3.Text = String.Concat("Por otras entradas de almacén", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
            txtGlosa.Text = String.Concat("Por otras entradas de almacén", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
        End If
    End Sub

    Private Sub CellEndEditRefresh()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0

        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If i.Cells(12).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then

                    colDestinoGravado = i.Cells(1).Value
                    'DECLARANDO VARIABLES
                    colPrecUnit = i.Cells(8).Value
                    colPrecUnitUSD = i.Cells(9).Value

                    If Not CStr(i.Cells(7).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        lblEstado.Image = My.Resources.warning2
                        Exit Sub
                    Else
                        colCantidad = i.Cells(7).Value
                    End If

                    Dim colMN As Decimal = 0
                    colMN = Math.Round(colCantidad * colPrecUnit, 2)

                    Dim colME As Decimal = 0
                    colME = Math.Round(colCantidad * colPrecUnitUSD, 2)

                    i.Cells(10).Value = colMN.ToString("N2")
                    i.Cells(11).Value = colME.ToString("N2")

                End If

            Next
            TotalesCabeceras()
        End If

    End Sub
#End Region

    Private Sub frmOtrasEntradasAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmOtrasEntradasAlmacen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        'TabPage1.Parent = Nothing
        'TabPage2.Parent = Nothing

        'TabPage5.Parent = Nothing
        'TabPage6.Parent = Nothing
        'TabPage9.Parent = Nothing

     


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click

    End Sub

    'Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '    datos.Clear()
    '    With frmModalComprobantesTabla
    '        .lblTipo.Text = "10"
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            txtIdComprobante.Text = datos(0).ID
    '            txtComprobante.Text = datos(0).NombreCampo
    '            glosa()
    '            txtSerie.Focus()
    '            txtSerie.Select(0, txtSerie.Text.Length)
    '            If dgvNuevoDoc.Rows.Count > 0 Then
    '                CellEndEditRefresh()
    '            End If
    '        Else
    '            txtIdComprobante.Text = String.Empty
    '            txtComprobante.Text = String.Empty
    '            MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub
    'Sub Comprobantes()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '    datos.Clear()
    '    With frmModalComprobantesTabla
    '        .lblTipo.Text = "10"
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            txtIdComprobante.Text = datos(0).ID
    '            txtComprobante.Text = datos(0).NombreCampo
    '            glosa()
    '            txtSerie.Focus()
    '            txtSerie.Select(0, txtSerie.Text.Length)
    '            If dgvNuevoDoc.Rows.Count > 0 Then
    '                CellEndEditRefresh()
    '            End If
    '        Else
    '            'txtIdComprobante.Text = String.Empty
    '            'txtComprobante.Text = String.Empty
    '            'MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub
    Private Sub txtFechaComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtComprobante.Select()
            txtComprobante.Focus()
            If txtComprobante.Text.Trim.Length > 0 Then

            Else
                'Comprobantes()
            End If
        End If
    End Sub

    Private Sub txtComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerie.Focus()
            txtSerie.Select(0, txtSerie.Text.Length)
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Focus()
            txtNumero.Select(0, txtNumero.Text.Length)
        End If
    End Sub

    Private Sub txtSerie_Leave(sender As Object, e As EventArgs) Handles txtSerie.Leave

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        Try
            Select Case txtIdComprobante.Text
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
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumero_LostFocus(sender, e)
            '   tvDatos.SelectedNode = newNodeProveedor
            txtNumGuia.Focus()
            txtNumGuia.Select()
            'If txtProveedor.Text.Trim.Length > 0 Then

            'Else
            '    ProveedoresShows()
            'End If
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        Try
            Select Case txtIdComprobante.Text
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
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        'Call ProveedoresShows()
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            tvDatos.SelectedNode = newNodeDetalle
            '            TabPage2.Parent = TabCompra
            nudTipoCambio.Focus()
            nudTipoCambio.Select()
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub nudTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudTipoCambio.ValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        Dim almacenSA As New almacenSA
        Dim itemsSA As New detalleitemsSA
        Dim srtNomAlmacen As String = Nothing
        Dim strUM As String = Nothing
        Dim strTipoEx As String = Nothing
        Dim strCuenta As String = Nothing
        Dim intIdEstableAlm As Integer
        Dim strIdPresentacion As String = Nothing
        'variable ausiliar para conocer si ya el artticulo esta en la lista de transferemcias.
        Dim boollExiste As Boolean = False

        '  If txtAlmacen.Text.Trim.Length > 0 Then
        Select Case cboModulo.Text
            Case "TRANSFERENCIA ENTRE ALMACENES"
                If cboAlmacen.Text.Trim.Length > 0 Then
                    datos.Clear()
                    With frmCanastaAlmacen
                        .txtAlmacenOrigen.Text = cboAlmacen.Text
                        .txtAlmacenOrigen.ValueMember = cboAlmacen.SelectedValue
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If datos.Count > 0 Then
                            With itemsSA.InvocarProductoID(datos(0).IdArticulo)
                                strUM = .unidad1
                                strTipoEx = .tipoExistencia
                                strCuenta = .cuenta
                                strIdPresentacion = .presentacion
                            End With
                            With almacenSA.GetUbicar_almacenPorID(datos(0).IdAlmacen)
                                srtNomAlmacen = .descripcionAlmacen
                                intIdEstableAlm = .idEstablecimiento
                            End With

                            'se valida que el articulo seleccionado para transferir no se duplique
                            If dgvNuevoDoc.RowCount > 0 Then

                                For i As Integer = 0 To dgvNuevoDoc.RowCount - 1
                                    If dgvNuevoDoc.Item(2, i).Value = datos(0).IdArticulo Then
                                        boollExiste = True
                                        Exit For
                                    End If
                                Next
                            End If

                            If Not boollExiste Then
                                cantidaExistente.Add(datos(0).Cantidad)

                                dgvNuevoDoc.Rows.Add(datos(0).Secuencia,
                                                     datos(0).Gravado,
                                                     datos(0).IdArticulo,
                                                     datos(0).NameArticulo,
                                                      strIdPresentacion,
                                                      datos(0).NamePresentacion,
                                                     strUM,
                                                     datos(0).Cantidad,
                                                     datos(0).PrecUnitKardexMN,
                                                     datos(0).PrecUnitKardexME,
                                                     0,
                                                     0,
                                                      Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT,
                                                      strTipoEx,
                                                      strCuenta,
                                                     Nothing, Nothing,
                                                      Nothing,
                                                      "Asignar almacén",
                                                      intIdEstableAlm, Nothing,
                                                      datos(0).IdAlmacen, srtNomAlmacen)
                            Else
                                boollExiste = False
                                lblEstado.Text = "El articulo ya existe en la lista!"
                                lblEstado.Image = My.Resources.warning2
                                Timer1.Enabled = True
                                TiempoEjecutar(5)

                            End If
                        End If

                    End With
                Else
                    lblEstado.Text = "Seleccionar un almacén!!"
                    lblEstado.Image = My.Resources.warning2
                End If
               
            Case Else
                Call MostrarDetalle()

        End Select
        If dgvNuevoDoc.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
        'Else
        '    lblEstado.Text = "Seleccionar un almacén!!"
        '    lblEstado.Image = My.Resources.warning2
        'End If

    End Sub

    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If dgvNuevoDoc.Rows.Count > 0 Then

            If Not IsNothing(dgvNuevoDoc.CurrentRow) Then



                If dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    deletefila()
                ElseIf dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    '   DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index
                    cantidaExistente.RemoveAt(pos)
                    dgvNuevoDoc.CurrentCell = Nothing
                    Me.dgvNuevoDoc.Rows(pos).Visible = False

                    '     deletefila()

                End If
                lblTotalItems.Text = dgvNuevoDoc.DisplayedRowCount(True) & " Filas"
                If dgvNuevoDoc.Rows.Count > 0 Then
                    CellEndEditRefresh()
                End If
            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.ColumnIndex = 18 Then
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                With frmModalAlmacen
                    .ObtenerAlmacenes(txtEstablecimiento.ValueMember, cboAlmacen.SelectedValue)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If datos.Count > 0 Then
                        dgvNuevoDoc.Item(17, e.RowIndex).Value = datos(0).ID
                        dgvNuevoDoc.Item(18, e.RowIndex).Value = datos(0).NombreEntidad
                    End If

                End With

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0
        Dim headerText As String = _
     dgvNuevoDoc.Columns(e.ColumnIndex).Name

        ' Abort validation if cell is not in the CompanyName column.

        dgvNuevoDoc.Rows(e.RowIndex).ErrorText = String.Empty
        If dgvNuevoDoc.Rows.Count > 0 Then
            colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value
            Select Case cboModulo.Text
                Case "TRANSFERENCIA ENTRE ALMACENES"
                    'DECLARANDO VARIABLES
                    colPrecUnit = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value
                    colPrecUnitUSD = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value

                    ValidarCantidad(dgvNuevoDoc.CurrentRow.Index)
                    ''Valida que la cantidad no este vacia
                    'If Not CStr(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                    '    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = cantidaExistente.Item(dgvNuevoDoc.CurrentRow.Index)
                    '    lblEstado.Text = "Ingrese una cantidad válida!"
                    '    lblEstado.Image = My.Resources.warning2
                    '    Exit Sub
                    'End If
                    ''Valida que la cantidad sea mayor que cero
                    'If dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value <= 0 Then
                    '    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = cantidaExistente.Item(dgvNuevoDoc.CurrentRow.Index)
                    '    lblEstado.Text = "Ingrese una cantidad mayor que 0!"
                    '    lblEstado.Image = My.Resources.warning2
                    '    Exit Sub
                    'End If
                    ''Se valida que no se transfiera una cantidad mayor a la existente
                    'If dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value > cantidaExistente.Item(dgvNuevoDoc.CurrentRow.Index) Then
                    '    Dim title = "Cantidad Incorrecta"
                    '    Dim msg = "La cantidad a transferir debe ser menor o igual a la cantidad exitente en el almacén"
                    '    MsgBox(msg, , title)
                    '    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = cantidaExistente.Item(dgvNuevoDoc.CurrentRow.Index)
                    '    Exit Sub
                    'End If

                Case "OTRAS ENTRADAS DE EXISTENCIAS"
                    'DECLARANDO VARIABLES
                    colPrecUnit = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value
                    colPrecUnitUSD = Math.Round(colPrecUnit / nudTipoCambio.Value, 2)
                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = colPrecUnitUSD.ToString("N2")
            End Select


          

            If Not CStr(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una cantidad válida!"
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            Else
                colCantidad = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value
            End If

            Dim colMN As Decimal = 0
            colMN = Math.Round(colCantidad * colPrecUnit, 2)

            Dim colME As Decimal = 0
            colME = Math.Round(colCantidad * colPrecUnitUSD, 2)

            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value = colME.ToString("N2")

        End If
        TotalesCabeceras()
    End Sub


    Private Sub ValidarCantidad(pos As Integer)
        If Not CStr(dgvNuevoDoc.Item(7, pos).Value).Trim.Length > 0 Then
            dgvNuevoDoc.Item(7, pos).Value = cantidaExistente.Item(pos)
            lblEstado.Text = "Ingrese una cantidad válida!"
            lblEstado.Image = My.Resources.warning2
            Exit Sub
        End If
        'Valida que la cantidad sea mayor que cero
        If dgvNuevoDoc.Item(7, pos).Value <= 0 Then
            dgvNuevoDoc.Item(7, pos).Value = cantidaExistente.Item(pos)
            lblEstado.Text = "Ingrese una cantidad mayor que 0!"
            lblEstado.Image = My.Resources.warning2
            Exit Sub
        End If
        'Se valida que no se transfiera una cantidad mayor a la existente
        If dgvNuevoDoc.Item(7, pos).Value > cantidaExistente.Item(pos) Then
            Dim title = "Cantidad Incorrecta"
            Dim msg = "La cantidad a transferir debe ser menor o igual a la cantidad exitente en el almacén"
            MsgBox(msg, , title)
            dgvNuevoDoc.Item(7, pos).Value = cantidaExistente.Item(pos)
            Exit Sub
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNuevoDoc.CellFormatting
        If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Gravado").Index _
AndAlso (e.Value IsNot Nothing) Then

            With Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If e.Value.Equals("1") Then
                    .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                ElseIf e.Value.Equals("2") Then
                    .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                ElseIf e.Value.Equals("3") Then
                    .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                ElseIf e.Value.Equals("4") Then
                    .ToolTipText = "4: ADQUISICIONES NO GRAVADAS"
                End If

            End With

        End If
    End Sub

    Private Sub dgvNuevoDoc_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then

            If e.ColumnIndex = 27 Then
                If (Me.dgvNuevoDoc.Rows(e.RowIndex).Cells("colBonif").Value) = "S" Then
                    CheckBoxClicked = True
                    '      dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "S"
                Else
                    CheckBoxClicked = False
                    '  dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "N"
                End If
                'Call the method to do when selected checkbox changes its state:
                MyMethodOnCheckBoxes()
            ElseIf e.ColumnIndex = 12 Then
                '    ValidaMontosBase()
            ElseIf e.ColumnIndex = 16 Then
                '      ValidaMontosBase()
            End If
        End If
    End Sub
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 10 Or Celda.ColumnIndex = 11 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub dgvNuevoDoc_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvNuevoDoc.CurrentCellDirtyStateChanged
        Try
            If dgvNuevoDoc.IsCurrentCellDirty Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvNuevoDoc.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If


        Catch
        End Try
    End Sub

    Private Sub dgvNuevoDoc_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvNuevoDoc.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvNuevoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvNuevoDoc.KeyDown
        Dim conteo As Integer = dgvNuevoDoc.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvNuevoDoc.CurrentCell.ColumnIndex)
                    Case 7
                        If rbNac.Checked = True Then
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(0, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(23, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        glosa()
        fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs)
    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub tvDatos_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvDatos.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case tvDatos.SelectedNode.Tag
            Case "IF"
                TabPage9.Parent = Nothing
                TabPage1.Parent = TabCompra

                TabPage5.Parent = Nothing
                TabCompra.Focus()
                txtFechaComprobante.Select()
                txtFechaComprobante.Focus()
            Case "DP"
                TabPage9.Parent = Nothing
                TabPage1.Parent = Nothing
                '    TabPage3.Parent = Nothing
                '  TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing

                txtProveedor.Select()
                txtProveedor.Focus()
            Case "DC"
                '       TabPage3.Parent = TabCompra

                TabPage1.Parent = Nothing
                TabPage5.Parent = Nothing
                TabPage9.Parent = Nothing
                'cboEstableCosto.Focus()
                'cboEstableCosto.Select()
            Case "IP"
                '  TabPage4.Parent = TabCompra

                TabPage1.Parent = Nothing
                TabPage5.Parent = Nothing
                TabPage9.Parent = TabCompra
                '   txtFechaPago.Select()
                '  txtFechaPago.Focus()
            Case "DT"
                TabPage5.Parent = TabCompra
                TabPage1.Parent = Nothing

                nudTipoCambio.Select()
                nudTipoCambio.Focus()
                nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtEstablecimiento_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtEstablecimiento.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        cboAlmacen.Text = ""
        'With frmModalEstablecimientoCaja
        '    .StrParametroCarga = "ET"
        '    .ObtenerEstablecimientos()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtEstablecimiento.ValueMember = datos(0).ID
        '        txtEstablecimiento.Text = datos(0).NombreCampo
        '    Else

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtEstablecimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEstablecimiento.TextChanged

    End Sub



    Private Sub txtAlmacen_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivating_1(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton1.ItemActivating
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim validadoComp As Boolean = ValidarCajas(gbxComp)

            If validadoComp = True Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done Comprobantes!"
            Else
                Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Complete todos los campos: Datos del comprobante!"
                tvDatos.SelectedNode = newNodeComprobante
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


            '***********************************************************************
            Select Case cboModulo.Text
                Case "TRANSFERENCIA ENTRE ALMACENES"
                    Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        If dgvNuevoDoc.Rows.Count > 0 Then
                            Grabar()
                        Else
                            Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        End If

                    Else
                        Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                        If Filas > 0 Then
                            UpdateCompra()
                        Else
                            Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        End If


                    End If
                Case "OTRAS ENTRADAS DE EXISTENCIAS"
                    Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        If dgvNuevoDoc.Rows.Count > 0 Then
                            GrabarDefault()
                        Else
                            Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        End If

                    Else
                        Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                        If Filas > 0 Then
                            UpdateCompra()
                        Else
                            Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        End If


                    End If
                Case Else
                    If lstAsientos.Items.Count > 0 Then
                        Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                        Me.lblEstado.Text = "Done!"
                        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                            If dgvNuevoDoc.Rows.Count > 0 Then
                                GrabarDefault()
                            Else
                                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                                Timer1.Enabled = True
                                TiempoEjecutar(5)
                            End If

                        Else
                            Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                            If Filas > 0 Then
                                UpdateCompra()
                            Else
                                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                                Timer1.Enabled = True
                                TiempoEjecutar(5)
                            End If


                        End If
                    Else
                        Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                        Me.lblEstado.Text = "Ingrese los asientos contables del comprobante!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If

            End Select



        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton1.Click
        Try
            Dim datos As List(Of Asientos_MN) = Asientos_MN.GetAsientos()
            Dim datosMov As List(Of Movimientos) = Movimientos.GetMovimientos()
            If rbAsiento.Checked = True Then
                If txtDescripcion.Text.Trim.Length > 0 Then
                    Dim Asiento As New Asientos_MN With {.AsientoID = datos.Count + 1,
                                              .NombreAsiento = txtDescripcion.Text.Trim,
                                              .Tipo = ASIENTO_CONTABLE.OTRAS_ENTRADAS}

                    datos.Add(Asiento)
                    lstAsientos.DataSource = Nothing
                    lstAsientos.DisplayMember = "NombreAsiento"
                    lstAsientos.ValueMember = "AsientoID"
                    lstAsientos.DataSource = datos
                    lblEstado.Text = "asiento agregado"

                    txtCuentas.Clear()
                    txtDescripcion.Clear()
                Else
                    lblEstado.Text = "debe asignar una descripción para el asiento!"
                    lblEstado.Image = My.Resources.warning2
                End If

            End If
            If rbMovimiento.Checked = True Then

                If lstAsientos.SelectedItems.Count > 0 Then
                    If txtCuentas.Text.Trim.Length > 0 AndAlso txtDescripcion.Text.Trim.Length > 0 Then
                        Dim Mov As New Movimientos With {.IdMovimiento = datosMov.Count + 1, .AsientoID = lstAsientos.SelectedValue,
                                              .Cuenta = txtCuentas.Text.Trim,
                                              .Descripcion = txtDescripcion.Text.Trim,
                                              .Tipo = IIf(cboTipo.Text = "DEBE", "D", "H"), .Importemn = nudImporteMN.NumericValue, .Importeme = nudImporteME.NumericValue}

                        datosMov.Add(Mov)
                        ubicarMovimientoporID(lstAsientos.SelectedValue)
                        'dgvMovimiento.Rows.Clear()
                        'For Each I As Movimientos In datosMov
                        '    dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion)
                        'Next
                        'lblEstado.Text = "movimiento agregado"
                        txtCuentas.Clear()
                        txtDescripcion.Clear()
                    Else
                        lblEstado.Text = "Completar los campos necesarios!"
                        lblEstado.Image = My.Resources.warning2
                    End If

                Else
                    lblEstado.Text = "debe indicar un movimiento válido!"
                    lblEstado.Image = My.Resources.warning2
                End If


            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub



    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            DeletePorID(lstAsientos.SelectedValue)
        End If
    End Sub

    Private Sub lstAsientos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstAsientos.SelectedIndexChanged
        If lstAsientos.SelectedItems.Count > 0 Then
            ubicarMovimientoporID(lstAsientos.SelectedValue)
        End If
    End Sub

    Private Sub rbAsiento_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAsiento.CheckedChanged
        If rbAsiento.Checked = True Then
            txtCuentas.Visible = False
            GroupBox5.Visible = False
        End If
    End Sub

    Private Sub rbMovimiento_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbMovimiento.CheckedChanged
        If rbMovimiento.Checked = True Then
            txtCuentas.Visible = True
            GroupBox5.Visible = True
        End If
    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.TextChanged

    End Sub

    Private Sub dgvMovimiento_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovimiento.CellContentClick

    End Sub

    Private Sub dgvMovimiento_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvMovimiento.CellFormatting

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvMovimiento.Rows.Count > 0 Then
            DeleteMovimientoID(dgvMovimiento.Item(8, dgvMovimiento.CurrentRow.Index).Value)
            ubicarMovimientoporID(lstAsientos.SelectedValue)
        End If
    End Sub


#Region "Clases Asientos"

    Private Shared datos As List(Of Asientos_MN)
    Private Shared datosMov As List(Of Movimientos)
    ' Asiento contable Class.
    Private Class Asientos_MN
        Public Property AsientoID As Integer
        Public Property NombreAsiento As String
        Public Property Tipo As String
        'Public Property Country As String

        Public Shared Function GetAsientos() As List(Of Asientos_MN)

            If datos Is Nothing Then
                datos = New List(Of Asientos_MN)
            End If

            Return datos
        End Function



        Private Sub AddAsiento(objAsiento As Asientos_MN)
            datos.Add(objAsiento)
        End Sub



    End Class
    Public Class Movimientos

        Public Property IdMovimiento As Integer
        Public Property AsientoID As Integer
        Public Property Cuenta As String
        Public Property Descripcion As String
        Public Property Tipo As String
        Public Property Importemn As Decimal
        Public Property Importeme As Decimal


        Public Shared Function GetMovimientos() As List(Of Movimientos)

            If datosMov Is Nothing Then
                datosMov = New List(Of Movimientos)
            End If

            Return datosMov
        End Function

        Public Sub AddMovimiento(nMovimiento As Movimientos)
            datosMov.Add(nMovimiento)
        End Sub
    End Class
    ' Detalle movimientos del asiento Class.


    Private Sub DeletePorID(id As Integer)

        Dim queryResults = (From cust In datos _
                           Where cust.AsientoID = id).First
        datos.Remove(queryResults)

        Dim ListaMov = (From n In datosMov _
                  Where n.AsientoID = id).ToList

        For Each i In ListaMov
            datosMov.Remove(i)
        Next

        lstAsientos.DataSource = Nothing
        lstAsientos.DisplayMember = "NombreAsiento"
        lstAsientos.ValueMember = "AsientoID"
        lstAsientos.DataSource = datos

        If Not datosMov.Count > 0 Then
            dgvMovimiento.Rows.Clear()
        End If

    End Sub

    Private Sub DeleteMovimientoID(id As Integer)

        Dim queryResults = (From cust In datosMov _
                           Where cust.IdMovimiento = id).First
        datosMov.Remove(queryResults)

        If Not datosMov.Count > 0 Then
            dgvMovimiento.Rows.Clear()
        End If

    End Sub

    Private Sub ubicarMovimientoporID(id As Integer)

        Dim queryResults = (From cust In datosMov _
                           Where cust.AsientoID = id).ToList

        If queryResults.Count > 0 Then
            dgvMovimiento.Rows.Clear()
            For Each I As Movimientos In queryResults
                If I.Tipo = "D" Then
                    dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, I.Importemn, I.Importeme, "0.00", "0.00", I.IdMovimiento)
                ElseIf I.Tipo = "H" Then
                    dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, "0.00", "0.00", I.Importemn, I.Importeme, I.IdMovimiento)
                End If

            Next
            lblEstado.Text = "Listado de movimientos"
        Else
            dgvMovimiento.Rows.Clear()
        End If


    End Sub


    Private Function ListarMovimientoporAsiento(id As Integer) As List(Of Movimientos)

        Dim queryResults = (From cust In datosMov _
                           Where cust.AsientoID = id).ToList


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosMN(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov _
                        Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo _
                        Select cust.Importemn).Sum


        Return queryResults
    End Function
    Private Function SumatoriaMovimientosME(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov _
                        Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo _
                        Select cust.Importeme).Sum


        Return queryResults
    End Function
#End Region


    Private Sub cboModulo_Click(sender As System.Object, e As System.EventArgs) Handles cboModulo.Click

    End Sub

    Private Sub cboModulo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboModulo.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboModulo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboModulo.SelectedIndexChanged
        cambioMovimiento()
    End Sub

    Private Sub cambioMovimiento()
        dgvNuevoDoc.Rows.Clear()
        ListaAsientonTransito.Clear()
        tvDatos.Nodes.Clear()
        Can1.DefaultCellStyle.BackColor = Color.Yellow
        ImporteNeto.DefaultCellStyle.BackColor = Color.White
        ImporteUS.DefaultCellStyle.BackColor = Color.White
        Select Case cboModulo.Text
            Case "TRANSFERENCIA ENTRE ALMACENES"
                TabPage9.Parent = Nothing
                LoadTree(0)

                Label9.Text = "Almacén de origen:"
                'columnas DGV
                Prec.ReadOnly = True
                Prec.DefaultCellStyle.BackColor = Color.White
                PrecUnitUS.ReadOnly = True
            Case "OTRAS ENTRADAS DE EXISTENCIAS"
                TabPage9.Parent = Nothing
                LoadTree(0)
                Label9.Text = "Almacén de destino:"

                'columnas DGV
                Prec.ReadOnly = False
                Prec.DefaultCellStyle.BackColor = Color.Yellow
                PrecUnitUS.ReadOnly = True
            Case "OTROS MOVIMIENTOS"
                TabPage9.Parent = TabCompra
                LoadTree(1)

                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    Dim datos As List(Of Asientos_MN) = Asientos_MN.GetAsientos()
                    Dim datosMov As List(Of Movimientos) = Movimientos.GetMovimientos()
                    datos.Clear()
                    datosMov.Clear()
                End If
                Label9.Text = "Almacén de destino:"
                Prec.ReadOnly = False
                Prec.DefaultCellStyle.BackColor = Color.Yellow
                PrecUnitUS.ReadOnly = True
        End Select
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieGuia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumGuia.Select()
            txtNumGuia.Focus()
        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieGuia.LostFocus
        Try
            Select Case "99"
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerieGuia.Text = "" Or Not String.IsNullOrEmpty(txtSerieGuia.Text) Then
                        If IsNumeric(txtSerieGuia.Text) Then
                            txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieGuia.Clear()
                            txtSerieGuia.Focus()
                            txtSerieGuia.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerieGuia.Text = "" Or Not String.IsNullOrEmpty(txtSerieGuia.Text) Then
                        If IsNumeric(txtSerieGuia.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieGuia.Clear()
                            txtSerieGuia.Focus()
                            txtSerieGuia.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieGuia.TextChanged

    End Sub

    Private Sub txtNumGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumGuia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtProveedor.Text.Trim.Length > 0 Then
                '   Call ProveedoresShows()
            Else
                txtProveedor.Select()
            End If

        End If
    End Sub

    Private Sub txtNumGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumGuia.LostFocus
        Try
            Select Case "99"
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtNumGuia.Text = "" Or Not String.IsNullOrEmpty(txtNumGuia.Text) Then
                        If IsNumeric(txtNumGuia.Text) Then
                            If txtNumGuia.Text.Length = 20 Then

                            Else
                                txtNumGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumGuia.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumGuia.Clear()
                            txtNumGuia.Focus()
                            txtNumGuia.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtNumGuia.Text = "" Or Not String.IsNullOrEmpty(txtNumGuia.Text) Then
                        If IsNumeric(txtNumGuia.Text) Then
                            If txtNumGuia.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumGuia.Clear()
                            txtNumGuia.Focus()
                            txtNumGuia.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"
                    If Not txtNumGuia.Text = "" Or Not String.IsNullOrEmpty(txtNumGuia.Text) Then
                        If IsNumeric(txtNumGuia.Text) Then
                            If txtNumGuia.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumGuia.Clear()
                            txtNumGuia.Focus()
                            txtNumGuia.SelectAll()
                        End If
                    End If
                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumGuia.TextChanged

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtSerieGuia.Select()
            txtSerieGuia.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivated_1(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonApplicationButton1.ItemActivated

    End Sub

    Public Sub ObtenerAlmacenes(intIdEstablecimiento As Integer)
        Dim almacenSA As New almacenSA

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAlmacen.SelectedIndexChanged
        TabCompra.Visible = True
        Panel3.Visible = True
        tvDatos.SelectedNode = newNodeComprobante
        txtFechaComprobante.Select()

    End Sub
End Class