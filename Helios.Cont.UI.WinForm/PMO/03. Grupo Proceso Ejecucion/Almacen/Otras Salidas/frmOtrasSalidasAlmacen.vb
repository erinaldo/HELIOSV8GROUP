Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Linq
Public Class frmOtrasSalidasAlmacen
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)

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
    Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
    ' Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
    Dim newNodeCuenta As TreeNode = New TreeNode("Asiento Contable")
    Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la Entrada")
    Private Sub LoadTree()
        ' TODO: Agregar código a elementos en la vista de árbol
        With tvDatos
            '  Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & cIDUsuario)
            tvDatos.Nodes.Add(newNodeUsuario)

            '  Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante compra")
            newNodeComprobante.Tag = "IF"
            tvDatos.Nodes.Add(newNodeComprobante)

            '  Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
            newNodeProveedor.Tag = "DP"
            tvDatos.Nodes.Add(newNodeProveedor)

            '  Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
            'newNodeCosto.Tag = "DC"
            'tvDatos.Nodes.Add(newNodeCosto)



            '   Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la compra")
            newNodeDetalle.Tag = "DT"
            tvDatos.Nodes.Add(newNodeDetalle)

            newNodeCuenta.Tag = "IP"
            tvDatos.Nodes.Add(newNodeCuenta)
        End With
    End Sub
#End Region


#Region "Métodos"
    

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim asientoSA As New AsientoSA
        Dim movimientoSA As New MovimientoSA

        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                txtFechaComprobante.Text = .fechaProceso
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    txtIdComprobante.Text = .codigoDetalle
                    txtComprobante.Text = .descripcion
                End With
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                txtFechaComprobante.Text = .fechaDoc
                lblPeriodo.Text = .fechaPeriodo
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDocNormal
                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCuenta.Text = nEntidad.cuentaAsiento
                txtidProveedor.Text = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                nudTipoCambio.Value = .tipoCambio
            End With


            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            Dim almacenSA As New almacenSA
            For Each i In objDocCompraDet.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
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
                                     i.nombreItem,
                                     i.unidad2,
                                     i.monto2,
                                     i.unidad1,
                                     FormatNumber(i.monto1, 2), FormatNumber(TotalesAlmacenSA.GetUbicarProductoTAlmacen(i.idAlmacenOrigen, i.idItem).cantidad, 2),
                                     FormatNumber(i.precioUnitario, 2),
                                     FormatNumber(i.precioUnitarioUS, 2),
                                     FormatNumber(i.importeMN, 2),
                                     FormatNumber(i.importeME, 2),
                                     Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                     insumosSA.InvocarProductoID(i.idItem).cuenta,
                                     i.preEvento, Nothing, i.idAlmacenOrigen, almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen).descripcionAlmacen,
                                     Nothing, i.idAlmacenOrigen)
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
            If dgvNuevoDoc.Rows(i.Index).Cells(13).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = 0
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(18).Value()).idEstablecimiento
                objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(18).Value()
                objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = nudTipoCambio.Value
                objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(14).Value()
                objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(4).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value() * -1, Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(9).Value(), Decimal)

                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(12).Value() * -1, Decimal)

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

        Next

        Return ListaTotales
    End Function

    Function ListaDeleteTotales() As List(Of totalesAlmacen)
        Dim objActividadDeleteEO As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim ListaDeleteEO As New List(Of totalesAlmacen)
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(13).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
              dgvNuevoDoc.Rows(i.Index).Cells(13).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then

                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = txtComprobante.Text
                objActividadDeleteEO.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                objActividadDeleteEO.idEstablecimiento = dgvNuevoDoc.Rows(i.Index).Cells(20).Value()
                objActividadDeleteEO.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(18).Value()
                objActividadDeleteEO.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = "2.77"
                objActividadDeleteEO.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(14).Value()
                objActividadDeleteEO.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objActividadDeleteEO.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If
        Next

        Return ListaDeleteEO
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
            asientoBL.fechaProceso = txtFechaComprobante.Value
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

    Sub Grabar()
        Dim CompraSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentoventaAbarrotes()
        Dim objDocumentoCompraDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDocumento = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaPeriodo = lblPeriodo.Text
            .serie = txtSerie.Text.Trim
            .numeroDocNormal = txtNumero.Text
            .idCliente = txtidProveedor.Text
            .NombreEntidad = txtProveedor.Text
            .moneda = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))

            .ImporteNacional = CDec(lblTotalAdquisiones.Text)
            .ImporteExtranjero = CDec(lblTotalUS.Text)

            .tipoVenta = TIPO_VENTA.OTRAS_SALIDAS
            .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            .glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoCompra

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentoventaAbarrotesDet
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc

            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = txtIdComprobante.Text
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim

            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.cuentaOrigen = i.Cells(15).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(14).Value()
            objDocumentoCompraDet.DetalleItem = i.Cells(3).Value()
            objDocumentoCompraDet.nombreItem = i.Cells(3).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value()) 'CANTIDAD SALIDA
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION

            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeMN = CDec(i.Cells(11).Value())
            objDocumentoCompraDet.importeME = CDec(i.Cells(12).Value())

            objDocumentoCompraDet.preEvento = i.Cells(16).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())

            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.IdEstablecimiento = CInt(i.Cells(20).Value())
            objDocumentoCompraDet.establecimientoOrigen = CInt(i.Cells(20).Value())
            objDocumentoCompraDet.idAlmacenOrigen = CDec(i.Cells(18).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.fechaVcto = Nothing
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoCompraDet)

        Next
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()
        AsientoEntrada()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN

        Dim xcod As Integer = CompraSA.SaveOtrasSalidas(ndocumento, ListaTotales)
        lblEstado.Text = "Sálida registrada!"
        lblEstado.Image = My.Resources.ok4

        Dim n As New ListViewItem(xcod)
        n.UseItemStyleForSubItems = False
        n.SubItems.Add("13").BackColor = Color.FromArgb(225, 240, 190)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.fechaDoc)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.tipoDocumento)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.serie)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.numeroDoc)

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        n.SubItems.Add(entidad.tipoDoc)
        n.SubItems.Add(txtRuc.Text)
        n.SubItems.Add(txtProveedor.Text)
        n.SubItems.Add(txtTipoEntidad.Text)

        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.ImporteNacional, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.tipoCambio, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.ImporteExtranjero, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.moneda, 2))
        n.SubItems.Add(TIPO_VENTA.OTRAS_SALIDAS)
        ' n.Group = g

        With frmMantenimientoOtrasSalidas
            '  Dim strNom = .lsvProduccion.Groups(g.Name.First)
            '   n.Group = .lsvProduccion.Groups(txtProveedor.Text)
            .lsvProduccion.Items.Add(n)
        End With
        Dispose()
    End Sub

    Sub UpdateSalida()
        Dim CompraSA As New documentoVentaAbarrotesSA
        Dim DocCaja As New documento

        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentoventaAbarrotes()
        Dim objDocumentoCompraDet As New documentoventaAbarrotesDet

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

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = txtFechaComprobante.Value
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
            .tipoDocumento = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaPeriodo = lblPeriodo.Text
            .serie = txtSerie.Text.Trim
            .numeroDocNormal = txtNumero.Text
            .idCliente = txtidProveedor.Text
            .nombrePedido = txtProveedor.Text
            .moneda = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))
          
            '****************************************************************************************************************
            .ImporteNacional = CDec(lblTotalAdquisiones.Text)
            .ImporteExtranjero = CDec(lblTotalUS.Text)

            .tipoVenta = TIPO_VENTA.OTRAS_SALIDAS
            .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            .glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoCompra

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentoventaAbarrotesDet
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoCompraDet.TipoDoc = txtIdComprobante.Text
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
            objDocumentoCompraDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(15).Value()
            objDocumentoCompraDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(14).Value()
            objDocumentoCompraDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoCompraDet.nombreItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()

            objDocumentoCompraDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
            objDocumentoCompraDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(7).Value())
            objDocumentoCompraDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoCompraDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
            objDocumentoCompraDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())

            objDocumentoCompraDet.preEvento = dgvNuevoDoc.Rows(i.Index).Cells(16).Value()

            If dgvNuevoDoc.Rows(i.Index).Cells(13).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(13).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(13).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            '**********************************************************************************
            objDocumentoCompraDet.IdEstablecimiento = dgvNuevoDoc.Rows(i.Index).Cells(20).Value()
            objDocumentoCompraDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value()) ' almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoCompraDet)

        Next
        ListaTotales = ListaTotalesAlmacen()
        ListaDeleteEO = ListaDeleteTotales()
        AsientoEntrada()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        CompraSA.UpdateOtrasSalidas(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "Sálida modificada!"
        lblEstado.Image = My.Resources.ok4

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First

        With frmMantenimientoOtrasSalidas
            .lsvProduccion.SelectedItems(0).SubItems(1).Text = "02"
            .lsvProduccion.SelectedItems(0).SubItems(1).BackColor = Color.FromArgb(225, 240, 190)
            .lsvProduccion.SelectedItems(0).SubItems(2).Text = ndocumento.documentoventaAbarrotes.fechaDoc
            .lsvProduccion.SelectedItems(0).SubItems(3).Text = ndocumento.documentoventaAbarrotes.tipoDocumento
            .lsvProduccion.SelectedItems(0).SubItems(4).Text = ndocumento.documentoventaAbarrotes.serie
            .lsvProduccion.SelectedItems(0).SubItems(5).Text = ndocumento.documentoventaAbarrotes.numeroDoc
            .lsvProduccion.SelectedItems(0).SubItems(6).Text = entidad.tipoDoc
            .lsvProduccion.SelectedItems(0).SubItems(7).Text = txtRuc.Text
            .lsvProduccion.SelectedItems(0).SubItems(8).Text = txtProveedor.Text
            .lsvProduccion.SelectedItems(0).SubItems(9).Text = txtTipoEntidad.Text
            .lsvProduccion.SelectedItems(0).SubItems(10).Text = FormatNumber(ndocumento.documentoventaAbarrotes.ImporteNacional, 2)
            .lsvProduccion.SelectedItems(0).SubItems(11).Text = FormatNumber(ndocumento.documentoventaAbarrotes.tipoCambio, 2)
            .lsvProduccion.SelectedItems(0).SubItems(12).Text = FormatNumber(ndocumento.documentoventaAbarrotes.ImporteExtranjero, 2)
            .lsvProduccion.SelectedItems(0).SubItems(13).Text = ndocumento.documentoventaAbarrotes.moneda
            .lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_VENTA.OTRAS_SALIDAS
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

    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = TIPO_ENTIDAD.CLIENTE
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtRuc.Text = datos(0).NroDoc
        '        txtCuenta.Text = datos(0).Cuenta
        '        txtidProveedor.Text = datos(0).ID
        '        txtProveedor.Text = datos(0).NombreEntidad

        '        txtProveedor.Focus()
        '    Else
        '        'txtRuc.Text = String.Empty
        '        'txtCuenta.Text = String.Empty
        '        'txtidProveedor.Text = String.Empty
        '        'txtProveedor.Text = String.Empty

        '        txtProveedor.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

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
            If i.Cells(13).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(11).Value)
                cTotalME += CDec(i.Cells(12).Value)
            End If
        Next
        lblTotalAdquisiones.Text = cTotalMN.ToString("N2")
        lblTotalUS.Text = cTotalME.ToString("N2")

    End Sub


    Private Sub glosa()
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(txtidProveedor.Text) Then
            txtGlosa.Text = String.Concat("Por otras sálidas de almacén", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
        End If
    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If i.Cells(13).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    If nudTipoCambio.Value > 0 Then
                        'DECLARANDO VARIABLES
                        Dim colPrecUnitAlmacen As Decimal = 0 '
                        Dim colPrecUnitUSAlmacen As Decimal = 0 '

                        colPrecUnitAlmacen = i.Cells(9).Value '
                        colPrecUnitUSAlmacen = i.Cells(10).Value '


                        Dim colDestinoGravado As Decimal = 0 '

                        colDestinoGravado = i.Cells(1).Value '

                        Dim colCantidad As Decimal = i.Cells(7).Value '
                        Dim colCantidadDisponible As Decimal = i.Cells(8).Value '

                        Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                        Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)



                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            i.Cells(7).Value = 0
                            Exit Sub
                        Else
                            i.Cells(7).Value = colCantidad.ToString("N2")
                        End If

                        Dim valor As Decimal = 0
                        Dim NUDIGV_VALUE As Decimal = 0
                        '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                        If rbNac.Checked = True Then
                            i.Cells(9).Value() = colPrecUnitAlmacen.ToString("N2") 'prec unit usd
                            i.Cells(10).Value() = colPrecUnitUSAlmacen.ToString("N2") 'prec unit usd

                            i.Cells(11).Value() = colMN.ToString("N2")
                            i.Cells(12).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES

                            TotalesCabeceras()
                        Else
                            'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
                        End If

                    Else
                        MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
                        nudTipoCambio.Focus()
                        nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
                    End If
                End If

            Next
        End If

    End Sub
#End Region

    Private Sub frmOtrasSalidasAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmOtrasSalidasAlmacen_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadTree()
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        '  TabPage3.Parent = Nothing
        ' TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
        TabPage9.Parent = Nothing
        '        TabPage10.Parent = Nothing

        tvDatos.SelectedNode = newNodeComprobante
        txtFechaComprobante.Select()
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            Dim datos As List(Of Asientos_MN) = Asientos_MN.GetAsientos()
            Dim datosMov As List(Of Movimientos) = Movimientos.GetMovimientos()
            datos.Clear()
            datosMov.Clear()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "10"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '        glosa()
        '        txtSerie.Focus()
        '        txtSerie.Select(0, txtSerie.Text.Length)
        '        If dgvNuevoDoc.Rows.Count > 0 Then
        '            CellEndEditRefresh()
        '        End If
        '    Else
        '        txtIdComprobante.Text = String.Empty
        '        txtComprobante.Text = String.Empty
        '        MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Focus()
            txtNumero.Select(0, txtNumero.Text.Length)
        End If
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
            tvDatos.SelectedNode = newNodeProveedor
            txtProveedor.Focus()
            txtProveedor.Select()
            If txtProveedor.Text.Trim.Length > 0 Then

            Else
                ProveedoresShows()
            End If
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
        Call ProveedoresShows()
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

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        glosa()
    End Sub

    Private Sub tvDatos_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvDatos.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case tvDatos.SelectedNode.Tag
            Case "IF"
                TabPage9.Parent = Nothing
                TabPage1.Parent = TabCompra
                TabPage2.Parent = Nothing
                '      TabPage3.Parent = Nothing
                ' TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing
                TabCompra.Focus()
                txtFechaComprobante.Select()
                txtFechaComprobante.Focus()
            Case "DP"
                TabPage2.Parent = TabCompra
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
                TabPage2.Parent = Nothing
                '  TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing
                TabPage9.Parent = Nothing
                'cboEstableCosto.Focus()
                'cboEstableCosto.Select()
            Case "IP"
                '  TabPage4.Parent = TabCompra

                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                '    TabPage3.Parent = Nothing
                TabPage5.Parent = Nothing
                TabPage9.Parent = TabCompra
                '   txtFechaPago.Select()
                '  txtFechaPago.Focus()
            Case "DT"
                TabPage5.Parent = TabCompra
                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                TabPage9.Parent = Nothing
                '    TabPage3.Parent = Nothing
                ' TabPage4.Parent = Nothing

                nudTipoCambio.Select()
                nudTipoCambio.Focus()
                nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
     If dgvNuevoDoc.Rows.Count > 0 Then
            If nudTipoCambio.Value > 0 Then
                'DECLARANDO VARIABLES
                Dim colPrecUnitAlmacen As Decimal = 0 '
                Dim colPrecUnitUSAlmacen As Decimal = 0 '

                colPrecUnitAlmacen = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value '
                colPrecUnitUSAlmacen = dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value '

            
                Dim colDestinoGravado As Decimal = 0 '

             
                colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value '

                Dim colCantidad As Decimal = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value '
                Dim colCantidadDisponible As Decimal = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value '

              
                Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)


                Select Case dgvNuevoDoc.Columns(e.ColumnIndex).Name
                    Case "Can1"
                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = 0
                            Exit Sub
                        Else
                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad.ToString("N2")
                        End If
                End Select
                Dim valor As Decimal = 0
                Dim NUDIGV_VALUE As Decimal = 0
                '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                If rbNac.Checked = True Then

                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                                If Not IsNothing(colMN) Then
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitAlmacen.ToString("N2") 'prec unit usd
                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSAlmacen.ToString("N2")

                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                End If
                        
                            ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitAlmacen.ToString("N2") 'prec unit usd
                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSAlmacen.ToString("N2")

                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                            End If

                    TotalesCabeceras()
                Else
                    'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
                End If

            Else
                MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
                nudTipoCambio.Focus()
                nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
            End If

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

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        Dim almacenSA As New almacenSA
        Dim srtNomAlmacen As String = Nothing
        datos.Clear()
        With frmCanastaVentas
            .lblMoneda.Text = IIf(rbNac.Checked = True, "1", "2")
            .lblTipoCambio.Text = nudTipoCambio.Value
            .lblIgv.Text = nudIgv.Value
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            For i As Integer = 0 To datos.Count - 1

                srtNomAlmacen = almacenSA.GetUbicar_almacenPorID(datos(i).IdAlmacen).descripcionAlmacen

                dgvNuevoDoc.Rows.Add(datos(i).Secuencia,
                                     datos(i).Gravado,
                                     datos(i).IdArticulo,
                                     datos(i).NameArticulo,
                                      datos(i).Presentacion,
                                      datos(i).NamePresentacion,
                                     datos(i).UM,
                                     datos(i).Cantidad,
                                     datos(i).CantDisponible,
                                     datos(i).PrecUnitKardexMN,
                                     datos(i).PrecUnitKardexME,
                                     0,
                                     0,
                                      Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT,
                                      datos(i).TipoExistencia,
                                      datos(i).Cuenta,
                                      datos(i).PreEvento, Nothing,
                                      datos(i).IdAlmacen,
                                      srtNomAlmacen,
                                      datos(i).Establecimiento)
            Next
            '  Label13.Text = "Nro. Productos: " & dgvNuevoDoc.Rows.Count

            If dgvNuevoDoc.Rows.Count > 0 Then
                CellEndEditRefresh()
            End If
        End With
    End Sub

    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If dgvNuevoDoc.Rows.Count > 0 Then

            If Not IsNothing(dgvNuevoDoc.CurrentRow) Then



                If dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    deletefila()
                ElseIf dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    '   DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
                    dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index

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

    Private Sub txtComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerie.Focus()
            txtSerie.Select(0, txtSerie.Text.Length)
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub

    Private Sub txtFechaComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtComprobante.Select()
            txtComprobante.Focus()
            If txtComprobante.Text.Trim.Length > 0 Then

            Else
                Comprobantes()
            End If
        End If
    End Sub
    Sub Comprobantes()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "10"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '        glosa()
        '        txtSerie.Focus()
        '        txtSerie.Select(0, txtSerie.Text.Length)
        '        If dgvNuevoDoc.Rows.Count > 0 Then
        '            CellEndEditRefresh()
        '        End If
        '    Else
        '        'txtIdComprobante.Text = String.Empty
        '        'txtComprobante.Text = String.Empty
        '        'MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub txtFechaComprobante_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaComprobante.ValueChanged

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

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvMovimiento.Rows.Count > 0 Then
            DeleteMovimientoID(dgvMovimiento.Item(8, dgvMovimiento.CurrentRow.Index).Value)
            ubicarMovimientoporID(lstAsientos.SelectedValue)
        End If
    End Sub

    Private Sub lstAsientos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstAsientos.SelectedIndexChanged
        If lstAsientos.SelectedItems.Count > 0 Then
            ubicarMovimientoporID(lstAsientos.SelectedValue)
        End If
    End Sub

    Private Sub QRibbonApplicationButton2_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton2.ItemActivating
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim validadoComp As Boolean = ValidarCajas(gbxComp)
            Dim validadoProv As Boolean = ValidarCajas(gbxProveedor)
            'Dim validadoCosto As Boolean = ValidarCajas(gbxCosto)
            '   Dim validadoPago As Boolean = ValidarCajas(gbxPago)
            Dim validadetalle As Boolean = ValidarCajas(TabPage5)


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

            If validadoProv = True Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done Proveedores!"
            Else
                Me.lblEstado.Image = My.Resources.cross ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Complete todos los campos: Datos del Proveedor!"
                tvDatos.SelectedNode = newNodeProveedor
                Me.Cursor = Cursors.Arrow
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If

            If validadetalle = True Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done Detalle de la compra!"
            Else
                Me.lblEstado.Image = My.Resources.cross ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Complete todos los campos: Detalle de la compra!"
                tvDatos.SelectedNode = newNodeDetalle
                Me.Cursor = Cursors.Arrow
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            '***********************************************************************
            If dgvNuevoDoc.Rows.Count > 0 Then
                If lstAsientos.Items.Count > 0 Then
                    Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        Grabar()
                    Else
                        Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                        If Filas > 0 Then
                            UpdateSalida()
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


            Else
                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub

    Private Sub QRibbonApplicationButton2_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonApplicationButton2.ItemActivated

    End Sub
End Class