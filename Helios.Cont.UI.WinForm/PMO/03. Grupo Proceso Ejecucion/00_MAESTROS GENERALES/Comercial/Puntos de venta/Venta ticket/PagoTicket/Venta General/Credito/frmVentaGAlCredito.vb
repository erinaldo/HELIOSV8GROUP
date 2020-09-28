Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmVentaGAlCredito
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadTree()
        TabPage1.Parent = Nothing

        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

#Region "Métodos"
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
            lblEstado.BackColor = Color.White
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
    Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante venta")
    '   Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
    ' Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
    '   Dim newNodePago As TreeNode = New TreeNode("Información del pago")
    Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la venta")
    Private Sub LoadTree()
        ' TODO: Agregar código a elementos en la vista de árbol
        With tvDatos
            '  Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & cIDUsuario)
            tvDatos.Nodes.Add(newNodeUsuario)

            '  Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante compra")
            newNodeComprobante.Tag = "IF"
            tvDatos.Nodes.Add(newNodeComprobante)

            '  Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
            'newNodeProveedor.Tag = "DP"
            'tvDatos.Nodes.Add(newNodeProveedor)

            '  Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
            'newNodeCosto.Tag = "DC"
            'tvDatos.Nodes.Add(newNodeCosto)

            '   Dim newNodePago As TreeNode = New TreeNode("Información del pago")
            'newNodePago.Tag = "IP"
            'tvDatos.Nodes.Add(newNodePago)

            '   Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la compra")
            newNodeDetalle.Tag = "DT"
            tvDatos.Nodes.Add(newNodeDetalle)
        End With
    End Sub
#End Region

    Sub ClientesShows()
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
        '        txtidCliente.Text = datos(0).ID
        '        txtCliente.Text = datos(0).NombreEntidad

        '        txtCliente.Focus()
        '    Else
        '        txtRuc.Text = String.Empty
        '        txtCuenta.Text = String.Empty
        '        txtidCliente.Text = String.Empty
        '        txtCliente.Text = String.Empty

        '        txtCliente.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA

        Dim inventarioBL As New inventarioMovimientoSA
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen

        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim documentoGuiSA As New DocumentoGuiaSA
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                txtFechaComprobante.Value = .fechaProceso
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    txtIdComprobante.Text = .codigoDetalle
                    txtComprobante.Text = .descripcion
                End With
            End With


            With documentoGuiSA.UbicarGuiaPorIdDocumento(intIdDocumento)
                txtSerieGuia.Text = .serie
                txtNumGuia.Text = .numeroDoc
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)

                txtIdComprobante.Text = .tipoDocumento
                txtGlosa.Text = .glosa
                With objTabla.GetUbicarTablaID(10, .tipoDocumento)
                    txtComprobante.Text = .descripcion
                End With

                lblIdDocumento.Text = .idDocumento
                lblPeriodo.Text = .fechaPeriodo
                txtSerieComp.Text = .serie

                txtNumeroComp.Text = .numeroDocNormal

                'DATOS DEL CLIENTE
                If Not IsNothing(.idCliente) Then
                    nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).First()
                    txtRuc.Text = nEntidad.nrodoc
                    txtCuenta.Text = nEntidad.cuentaAsiento
                    txtidCliente.Text = nEntidad.idEntidad
                    txtCliente.Text = nEntidad.nombreCompleto
                End If


                '_::::::::::::::::::        :::::::::::::::::::
                nudTipoCambio.Value = .tipoCambio

            End With

            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            'Dim cCantidadValida As Decimal = 0
            'Dim cPMKardex As Decimal = 0
            'Dim cPMKardexME As Decimal = 0
            For Each i In objDocCompraDet.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

                'With totalesAlmacenSA.GetUbicarProductoTAlmacen(i.idAlmacenOrigen, i.idItem)


                'End With

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
                                    i.destino,
                                    i.idItem,
                                    i.nombreItem,
                                    i.unidad1,
                                    i.monto1,
                                   i.importeMNK, totalesAlmacenSA.GetUbicarProductoTAlmacen(i.idAlmacenOrigen, i.idItem).cantidad,
                                    i.precioUnitario,
                                    i.precioUnitarioUS,
                                    i.importeMN,
                                    i.importeME,
                                    i.descuentoMN,
                                    i.descuentoME,
                                    i.montokardex,
                                    i.montoIsc,
                                    i.montoIgv,
                                    i.otrosTributos,
                                    i.montokardexUS,
                                    i.montoIscUS,
                                    i.montoIgvUS,
                                    i.otrosTributosUS, Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE,
                                    i.tipoExistencia,
                                    i.idAlmacenOrigen,
                                    i.cuentaOrigen,
                                    i.establecimientoOrigen,
                                    i.preEvento,
                                    i.importeMEK, i.unidad2,
                                    i.fechaVcto,
                                    i.monto2,
                                    i.tipoVenta,
                                    i.salidaCostoMN,
                                    i.salidaCostoME)

            Next
            '     lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count
            totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function AS_CLIENTE(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = txtCuenta.Text,
              .descripcion = txtCliente.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .cuentaKardex
                End With
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
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .cuentaKardex2
                End With

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

    Public Function RecuperaCuentaVenta(cCuenta As String, strTipoExistencia As String) As String
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim strCuenta As String = Nothing

        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    strCuenta = .cuentaVenta
                End With
        End Select
        Return strCuenta
    End Function

    Sub deletefila()
        Dim fila As Byte
        Try
            If dgvNuevoDoc.Rows.Count > 0 Then
                fila = dgvNuevoDoc.CurrentCell.RowIndex
                dgvNuevoDoc.Rows.RemoveAt(fila)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Public Sub Bonificacion()
        '    Dim i As Integer
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0
        Dim base3 As Decimal = 0
        Dim base4 As Decimal = 0
        Dim baseus1 As Decimal = 0
        Dim baseus2 As Decimal = 0
        Dim baseus3 As Decimal = 0
        Dim baseus4 As Decimal = 0
        Dim otc1 As Decimal = 0
        Dim otc2 As Decimal = 0
        Dim otc3 As Decimal = 0
        Dim otc4 As Decimal = 0
        Dim otc1US As Decimal = 0
        Dim otc2US As Decimal = 0
        Dim otc3US As Decimal = 0
        Dim otc4US As Decimal = 0
        Dim total As Decimal = 0
        Dim totalbase2 As Decimal = 0
        Dim totalbase3 As Decimal = 0
        Dim totalbase4 As Decimal = 0
        Dim igv As Decimal = 0
        Dim IGVUS As Decimal = 0
        Dim tus1 As Decimal = 0
        Dim tus2 As Decimal = 0
        Dim tus3 As Decimal = 0
        Dim tus4 As Decimal = 0


        'COLUMNAS
        Dim colCantidad As Decimal = 0
        Dim colPU As Decimal = 0
        Dim colPU_ME As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            colCantidad = i.Cells(7).Value
            colMN = i.Cells(10).Value
            colME = Math.Round(CDec(i.Cells(10).Value) / CDec(nudTipoCambio.Value), 2)
            colPU = Math.Round(CDec(i.Cells(10).Value) / colCantidad, 2)
            colPU_ME = Math.Round(colME / colCantidad, 2)
            '  If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
            If colCantidad > 0 Then

                If i.Cells(27).Value = "S" Then
                    totalbase4 += CDec(i.Cells(10).Value())
                    tus4 += CDec(i.Cells(11).Value()) ' total base 01
                    If rbNac.Checked = True Then
                        ' DATOS SOLES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                i.Cells(10).Value = colMN

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(10).Value = colMN
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES


                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select

                    Else 'If 'txtMoneda.Text = "2" Then
                        ' DATOS DOLARES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")  ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select
                    End If
                End If
            End If
        Next

        Dim NUDVALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)

        '*********************** SOLES ***********************************************
        '****************IMPUESTO 4*******************
        base4 = totalbase4
        '   nudBase4.Value = Math.Round(base4, NumDigitos)
        nudBase1.Value = 0
        nudBase2.Value = 0
        '  nudBase3.Value = 0

        nudMontoIgv1.Value = 0
        nudMontoIgv2.Value = 0
        ' nudMontoIgv3.Value = 0

        '        nudBaseus4.Value = Math.Round(tus4, NumDigitos)
        nudBaseus1.Value = 0
        nudBaseus2.Value = 0
        '       nudBaseus3.Value = 0

        nudMontoIgvus1.Value = 0
        nudMontoIgvus2.Value = 0
        ' nudMontoIgvus3.Value = 0
        '***********IMPORTE GRAVADO******************
        'subTotales("All")

        '  totales()
        totales_xx()
        TotalesCabeceras()

    End Sub

    Private Sub MyMethodOnCheckBoxes()
        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            '  MsgBox(True)
            Bonificacion()
            dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            CellEndEditRefresh()
            dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "N"

        End If
    End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalCosto As Decimal = 0
        Dim cTotalCostoME As Decimal = 0


        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If i.Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(11).Value)

                cTotalBI += CDec(i.Cells(14).Value)
                cTotalBI_ME += CDec(i.Cells(18).Value)

                cTotalIGV += CDec(i.Cells(16).Value)
                cTotalIGV_ME += CDec(i.Cells(20).Value)

                cTotalIsc += CDec(i.Cells(15).Value)
                cTotalIsc_ME += CDec(i.Cells(19).Value)

                cTotalOTC += CDec(i.Cells(17).Value)
                cTotalOTC_ME += CDec(i.Cells(21).Value)

                cTotalCosto += CDec(i.Cells(33).Value)
                cTotalCostoME += CDec(i.Cells(34).Value)
            End If
        Next
        lblTotalBase.Text = cTotalBI.ToString("N2")
        lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        lblTotalISc.Text = cTotalIsc.ToString("N2")
        lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        Select Case txtIdComprobante.Text
            Case "02", "03"
                lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
                lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")
                lblCostoMN.Text = cTotalCosto
                lblCostoME.Text = cTotalCostoME
            Case "08"
                'Instrucciones
            Case Else
                lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
                lblCostoMN.Text = cTotalCosto
                lblCostoME.Text = cTotalCostoME
        End Select

    End Sub

    Public Sub totales_xx()
        Dim i As Integer

        Dim bi1, bi2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim bi1me, bi2me As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)
        For i = 0 To dgvNuevoDoc.Rows.Count - 1
            'total += carrito.Rows(i)(5)
            If dgvNuevoDoc.Rows(i).Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                    If dgvNuevoDoc.Rows(i).Cells(1).Value() = "1" Then

                        bi1 += dgvNuevoDoc.Rows(i).Cells(14).Value() ' total base 01 soles
                        bi1me += dgvNuevoDoc.Rows(i).Cells(18).Value() ' total base 01 dolares
                        totalIgv1 += dgvNuevoDoc.Rows(i).Cells(16).Value()
                        totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

                    ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

                        bi2 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                        bi2me += dgvNuevoDoc.Rows(i).Cells(18).Value() ' total base 01
                        totalIgv2 += dgvNuevoDoc.Rows(i).Cells(16).Value()
                        totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

                    End If
                End If
            End If

        Next
        nudBase1.Value = bi1.ToString("N2")
        nudBaseus1.Value = bi1me.ToString("N2")
        nudBase2.Value = bi2.ToString("N2")
        nudBaseus2.Value = bi2me.ToString("N2")

        nudMontoIgv1.Value = totalIgv1.ToString("N2")
        nudMontoIgvus1.Value = totalIgv1_ME.ToString("N2")
        nudMontoIgv2.Value = totalIgv2.ToString("N2")
        nudMontoIgvus2.Value = totalIgv2_ME.ToString("N2")

    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If i.Cells(22).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    If nudTipoCambio.Value > 0 Then
                        'DECLARANDO VARIABLES
                        Dim colPrecUnitAlmacen As Decimal = 0 '
                        Dim colPrecUnitUSAlmacen As Decimal = 0 '

                        colPrecUnitAlmacen = i.Cells(6).Value '
                        colPrecUnitUSAlmacen = i.Cells(28).Value '


                        Dim colPrecUnit As Decimal = 0 '
                        Dim colPrecUnitUSD As Decimal = 0 '
                        Dim colDestinoGravado As Decimal = 0 '

                        colPrecUnit = i.Cells(8).Value '
                        colPrecUnitUSD = i.Cells(9).Value '
                        colDestinoGravado = i.Cells(1).Value '

                        Dim colCantidad As Decimal = i.Cells(5).Value '
                        Dim colCantidadDisponible As Decimal = i.Cells(7).Value '

                        Dim colBI As Decimal = 0
                        Dim colBI_ME As Decimal = 0
                        Dim colIGV_ME As Decimal = 0
                        Dim colIGV As Decimal = 0
                        Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnit, 2)
                        Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)


                        Dim colCostoMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                        Dim colCostoME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)

                        If colCantidad > 0 AndAlso colMN > 0 Then

                            colBI = Math.Round(colMN / 1.18, 2)
                            colBI_ME = Math.Round(colME / 1.18, 2)
                            colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                            colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                        Else
                            colBI = 0
                            colBI_ME = 0
                            colIGV = 0
                            colIGV_ME = 0
                        End If

                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            i.Cells(5).Value = 0
                            Exit Sub
                        Else
                            i.Cells(5).Value = colCantidad.ToString("N2")
                        End If

                        Dim valor As Decimal = 0
                        Dim NUDIGV_VALUE As Decimal = 0
                        '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                        If rbNac.Checked = True Then
                            Select Case colDestinoGravado
                                Case 1
                                    NUDIGV_VALUE = Math.Round((nudIgv.Value / 100) + 1, 2)
                                    i.Cells(8).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    i.Cells(9).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    i.Cells(10).Value() = colMN.ToString("N2")
                                    i.Cells(11).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(14).Value() = colBI.ToString("N2") ' monto para el kardex
                                    i.Cells(16).Value() = colIGV.ToString("N2") ' monto igv del item
                                    i.Cells(18).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                    i.Cells(20).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                    i.Cells(33).Value() = colCostoMN.ToString("N2")
                                    i.Cells(34).Value() = colCostoME.ToString("N2")

                                Case 2
                                    NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)

                                    i.Cells(8).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    i.Cells(9).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    i.Cells(10).Value() = colMN.ToString("N2")
                                    i.Cells(11).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(14).Value() = colMN.ToString("N2")
                                    i.Cells(16).Value() = "0.00" ' monto igv del item
                                    i.Cells(18).Value() = colME.ToString("N2")  ' monto para el kardex USD
                                    i.Cells(20).Value() = "0.00"

                                    i.Cells(33).Value() = colCostoMN.ToString("N2")
                                    i.Cells(34).Value() = colCostoME.ToString("N2")

                            End Select
                            totales_xx()
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

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = 0
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
                objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(24).Value()
                objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = nudTipoCambio.Value
                objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
                objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(4).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(5).Value() * -1, Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)
                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(33).Value() * -1, Decimal)
                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(34).Value() * -1, Decimal)
                'Select Case txtIdComprobante.Text
                '    Case "03", "02"

                '        objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(10).Value() * -1, Decimal)
                '        objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                '    Case Else
                '        Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                '            Case "1"
                '                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(14).Value() * -1, Decimal)
                '                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(18).Value() * -1, Decimal)
                '            Case Else
                '                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(10).Value() * -1, Decimal)
                '                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value() * -1, Decimal)
                '        End Select

                'End Select
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
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
              dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then

                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = txtIdComprobante.Text
                objActividadDeleteEO.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                '  almacenFS = almacenSA.GetUbicar_almacenPorID(CInt(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))
                'If Not IsNothing(almacenFS) Then
                objActividadDeleteEO.idEstablecimiento = dgvNuevoDoc.Rows(i.Index).Cells(26).Value()
                objActividadDeleteEO.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(24).Value()
                'Else
                '    almacenVR = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
                '    If Not IsNothing(almacenVR) Then
                '        objActividadDeleteEO.idEstablecimiento = almacenVR.idEstablecimiento
                '        objActividadDeleteEO.idAlmacen = almacenVR.idAlmacen
                '    End If

                'End If
                objActividadDeleteEO.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = "2.77"
                objActividadDeleteEO.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
                objActividadDeleteEO.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objActividadDeleteEO.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If
        Next

        Return ListaDeleteEO
    End Function

    Sub AsientoVenta()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento.idAsiento = 0
        nAsiento.idDocumento = lblIdDocumento.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = lblIdDocumento.Text
        nAsiento.fechaProceso = fecha
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA AL CREDITO"
        nAsiento.importeMN = lblTotalAdquisiones.Text
        nAsiento.importeME = lblTotalUS.Text
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = "Jiuni"
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_CLIENTE(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                Select Case txtIdComprobante.Text

                    Case "03", "02"
                        MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                    Case Else

                        Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value
                            Case "1"
                                MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                            Case Else
                                MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)

                        End Select
                End Select


                nMovimiento = New movimiento
                nMovimiento.cuenta = RecuperaCuentaVenta(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                'Select Case lblTipoDoc.Text
                '    Case "03", "02"
                '        nMovimiento.monto = CDec(i.SubItems(5).Text)
                '        nMovimiento.montoUSD = CDec(i.SubItems(6).Text)
                '    Case Else
                Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value
                    Case "1"
                        nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value)
                        nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value)
                    Case Else
                        nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value)
                        nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value)
                        'End Select
                End Select
                'nMovimiento.monto = CDec(i.SubItems(13).Text)
                'nMovimiento.montoUSD = CDec(i.SubItems(14).Text)
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"


                nAsiento.movimiento.Add(nMovimiento)
            End If




        Next
        nAsiento.movimiento.Add(AS_IGV(CDec(lblTotalMontoIgv.Text), CDec(lblTotalMontoIgvUS.Text)))
        '   Return nAsiento
    End Sub

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
            .serie = txtSerieGuia.Text.Trim
            .numeroDoc = txtNumGuia.Text.Trim
            .idEntidad = txtidCliente.Text
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
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                documentoguiaDetalle = New documentoguiaDetalle
                documentoguiaDetalle.idDocumento = lblIdDocumento.Text
                documentoguiaDetalle.idItem = i.Cells(2).Value
                documentoguiaDetalle.descripcionItem = i.Cells(3).Value
                documentoguiaDetalle.destino = i.Cells(1).Value
                documentoguiaDetalle.unidadMedida = i.Cells(4).Value
                documentoguiaDetalle.cantidad = CDec(i.Cells(5).Value)
                documentoguiaDetalle.precioUnitario = CDec(i.Cells(8).Value)
                documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(9).Value)
                documentoguiaDetalle.importeMN = CDec(i.Cells(10).Value)
                documentoguiaDetalle.importeME = CDec(i.Cells(11).Value)

                documentoguiaDetalle.almacenRef = CInt(i.Cells(24).Value)
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub Grabar()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
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
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = fecha
            .nroDoc = txtSerieComp.Text.Trim & "-" & txtNumeroComp.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoVenta
            If IsNothing(GProyectos) Then
            Else
                .idPadre = GProyectos.IdProyectoActividad
            End If
            .TipoDocNumeracion = txtIdComprobante.Text
            .codigoLibro = "8"
            .tipoDocumento = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaPeriodo = lblPeriodo.Text
            .serie = txtSerieComp.Text.Trim
            .numeroDocNormal = txtNumeroComp.Text
            .idCliente = txtidCliente.Text
            .nombrePedido = txtCliente.Text
            .moneda = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1.Value = 0 Or nudBase1.Value = "0.00", CDec(0.0), CDec(nudBase1.Value))
            .bi02 = IIf(nudBase2.Value = 0 Or nudBase2.Value = "0.00", CDec(0.0), CDec(nudBase2.Value))

            .isc01 = IIf(nudIsc1.Value = 0 Or nudIsc1.Value = "0.00", CDec(0.0), CDec(nudIsc1.Value))
            .isc02 = IIf(nudIsc2.Value = 0 Or nudIsc2.Value = "0.00", CDec(0.0), CDec(nudIsc2.Value))

            .igv01 = IIf(nudMontoIgv1.Value = 0 Or nudMontoIgv1.Value = "0.00", CDec(0.0), CDec(nudMontoIgv1.Value))
            .igv02 = IIf(nudMontoIgv2.Value = 0 Or nudMontoIgv2.Value = "0.00", CDec(0.0), CDec(nudMontoIgv2.Value))

            .otc01 = IIf(nudOtrosTributos1.Value = 0 Or nudOtrosTributos1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos1.Value))
            .otc02 = IIf(nudOtrosTributos2.Value = 0 Or nudOtrosTributos2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos2.Value))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1.Value = 0 Or nudBaseus1.Value = "0.00", CDec(0.0), CDec(nudBaseus1.Value))
            .bi02us = IIf(nudBaseus2.Value = 0 Or nudBaseus2.Value = "0.00", CDec(0.0), CDec(nudBaseus2.Value))

            .isc01us = IIf(nudIscus1.Value = 0 Or nudIscus1.Value = "0.00", CDec(0.0), CDec(nudIscus1.Value))
            .isc02us = IIf(nudIscus2.Value = 0 Or nudIscus2.Value = "0.00", CDec(0.0), CDec(nudIscus2.Value))

            .igv01us = IIf(nudMontoIgvus1.Value = 0 Or nudMontoIgvus1.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus1.Value))
            .igv02us = IIf(nudMontoIgvus2.Value = 0 Or nudMontoIgvus2.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus2.Value))

            .otc01us = IIf(nudOtrosTributosus1.Value = 0 Or nudOtrosTributosus1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus1.Value))
            .otc02us = IIf(nudOtrosTributosus2.Value = 0 Or nudOtrosTributosus2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus2.Value))

            '****************************************************************************************************************
            .ImporteNacional = IIf(lblTotalAdquisiones.Text = 0 Or lblTotalAdquisiones.Text = "0.00", CDec(0.0), CDec(lblTotalAdquisiones.Text))
            .ImporteExtranjero = IIf(lblTotalUS.Text = 0 Or lblTotalUS.Text = "0.00", CDec(0.0), CDec(lblTotalUS.Text))

            .tipoVenta = TIPO_VENTA.VENTA_AL_CREDITO
            .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            .glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))

            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        GuiaRemision(ndocumento)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = txtIdComprobante.Text
            objDocumentoVentaDet.idAlmacenOrigen = CDec(i.Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = i.Cells(25).Value()
            objDocumentoVentaDet.idItem = i.Cells(2).Value()
            objDocumentoVentaDet.DetalleItem = i.Cells(3).Value()
            objDocumentoVentaDet.tipoExistencia = i.Cells(23).Value()
            objDocumentoVentaDet.destino = i.Cells(1).Value()
            objDocumentoVentaDet.unidad1 = i.Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(i.Cells(5).Value())
            objDocumentoVentaDet.unidad2 = i.Cells(29).Value()
            objDocumentoVentaDet.monto2 = i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(i.Cells(10).Value())
            objDocumentoVentaDet.importeME = CDec(i.Cells(11).Value())
            objDocumentoVentaDet.descuentoMN = CDec(i.Cells(12).Value())
            objDocumentoVentaDet.descuentoME = CDec(i.Cells(13).Value())

            objDocumentoVentaDet.montokardex = CDec(i.Cells(14).Value())
            objDocumentoVentaDet.montoIsc = CDec(i.Cells(15).Value())
            objDocumentoVentaDet.montoIgv = CDec(i.Cells(16).Value())
            objDocumentoVentaDet.otrosTributos = CDec(i.Cells(17).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(i.Cells(18).Value())
            objDocumentoVentaDet.montoIscUS = CDec(i.Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(i.Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(i.Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(i.Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(i.Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(i.Cells(30).Value()), Nothing, CDate(i.Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(i.Cells(33).Value()) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(i.Cells(34).Value()) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(i.Cells(27).Value()), Nothing, i.Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = "Jiuni"
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = i.Cells(32).Value()
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)

        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()
        'ASIENTO DE VENTA
        AsientoVenta()
        ndocumento.asiento = ListaAsientonTransito
        Dim xcod As Integer = VentaSA.SaveVentaALCredito(ndocumento, ListaTotales)
        lblEstado.Text = "venta registrada!"
        lblEstado.Image = My.Resources.ok4

        Dim n As New ListViewItem(xcod)
        n.SubItems.Add("01")
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.fechaDoc)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.tipoDocumento)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.serie)
        n.SubItems.Add(ndocumento.documentoventaAbarrotes.numeroDocNormal)

        entidad = entidadSA.UbicarEntidadPorID(txtidCliente.Text).First()
        n.SubItems.Add("")
        n.SubItems.Add("")
        n.SubItems.Add(entidad.nombreCompleto)
        n.SubItems.Add("")

        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.ImporteNacional, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.tipoCambio, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.ImporteExtranjero, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentoventaAbarrotes.moneda, 2))
        n.SubItems.Add(TIPO_VENTA.VENTA_AL_CREDITO)
        n.SubItems.Add(TIPO_VENTA.PAGO.PENDIENTE_PAGO)
        ' n.Group = g

        With frmMasterVentaGeneral
            '  Dim strNom = .lsvProduccion.Groups(g.Name.First)
            '   n.Group = .lsvProduccion.Groups(txtProveedor.Text)
            .lsvListaPedidos.Items.Add(n)
        End With
        Dispose()
    End Sub

    Sub UpdateVenta()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = txtIdComprobante.Text
            .fechaProceso = fecha
            .nroDoc = txtSerieComp.Text.Trim & "-" & txtNumeroComp.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoVenta
            .idDocumento = lblIdDocumento.Text
            If IsNothing(GProyectos) Then
            Else
                .idPadre = GProyectos.IdProyectoActividad
            End If
            .TipoDocNumeracion = txtIdComprobante.Text
            .codigoLibro = "8"
            .tipoDocumento = txtIdComprobante.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaPeriodo = lblPeriodo.Text
            .serie = txtSerieComp.Text.Trim
            .numeroDocNormal = txtNumeroComp.Text
            .nombrePedido = txtCliente.Text
            .idCliente = txtidCliente.Text
            ' .nombrePedido = txtPedidoRef.Text
            .moneda = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1.Value = 0 Or nudBase1.Value = "0.00", CDec(0.0), CDec(nudBase1.Value))
            .bi02 = IIf(nudBase2.Value = 0 Or nudBase2.Value = "0.00", CDec(0.0), CDec(nudBase2.Value))

            .isc01 = IIf(nudIsc1.Value = 0 Or nudIsc1.Value = "0.00", CDec(0.0), CDec(nudIsc1.Value))
            .isc02 = IIf(nudIsc2.Value = 0 Or nudIsc2.Value = "0.00", CDec(0.0), CDec(nudIsc2.Value))

            .igv01 = IIf(nudMontoIgv1.Value = 0 Or nudMontoIgv1.Value = "0.00", CDec(0.0), CDec(nudMontoIgv1.Value))
            .igv02 = IIf(nudMontoIgv2.Value = 0 Or nudMontoIgv2.Value = "0.00", CDec(0.0), CDec(nudMontoIgv2.Value))

            .otc01 = IIf(nudOtrosTributos1.Value = 0 Or nudOtrosTributos1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos1.Value))
            .otc02 = IIf(nudOtrosTributos2.Value = 0 Or nudOtrosTributos2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos2.Value))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1.Value = 0 Or nudBaseus1.Value = "0.00", CDec(0.0), CDec(nudBaseus1.Value))
            .bi02us = IIf(nudBaseus2.Value = 0 Or nudBaseus2.Value = "0.00", CDec(0.0), CDec(nudBaseus2.Value))

            .isc01us = IIf(nudIscus1.Value = 0 Or nudIscus1.Value = "0.00", CDec(0.0), CDec(nudIscus1.Value))
            .isc02us = IIf(nudIscus2.Value = 0 Or nudIscus2.Value = "0.00", CDec(0.0), CDec(nudIscus2.Value))

            .igv01us = IIf(nudMontoIgvus1.Value = 0 Or nudMontoIgvus1.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus1.Value))
            .igv02us = IIf(nudMontoIgvus2.Value = 0 Or nudMontoIgvus2.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus2.Value))

            .otc01us = IIf(nudOtrosTributosus1.Value = 0 Or nudOtrosTributosus1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus1.Value))
            .otc02us = IIf(nudOtrosTributosus2.Value = 0 Or nudOtrosTributosus2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus2.Value))

            '****************************************************************************************************************
            .ImporteNacional = IIf(lblTotalAdquisiones.Text = 0 Or lblTotalAdquisiones.Text = "0.00", CDec(0.0), CDec(lblTotalAdquisiones.Text))
            .ImporteExtranjero = IIf(lblTotalUS.Text = 0 Or lblTotalUS.Text = "0.00", CDec(0.0), CDec(lblTotalUS.Text))

            .tipoVenta = TIPO_VENTA.VENTA_AL_CREDITO
            '  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            .glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        GuiaRemision(ndocumento)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.idDocumento = lblIdDocumento.Text
            objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = txtIdComprobante.Text
            objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
            objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
            objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
            objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
            objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
            objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
            objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())

            objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
            objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())
            objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
            objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
            objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = "Jiuni"
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim

            ListaDetalle.Add(objDocumentoVentaDet)
            '   End If
        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()
        ListaDeleteEO = ListaDeleteTotales()
        'ASIENTO DE VENTA
        AsientoVenta()
        ndocumento.asiento = ListaAsientonTransito
        Dim xcod As Integer = VentaSA.UpdateVentaALCredito(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "venta modificada!"
        lblEstado.Image = My.Resources.ok4


        With frmMasterVentaGeneral.lsvListaPedidos
            .SelectedItems(0).SubItems(0).Text = (lblIdDocumento.Text)
            .SelectedItems(0).SubItems(1).Text = ("01")
            .SelectedItems(0).SubItems(2).Text = (ndocumento.documentoventaAbarrotes.fechaDoc)
            .SelectedItems(0).SubItems(3).Text = (ndocumento.documentoventaAbarrotes.tipoDocumento)
            .SelectedItems(0).SubItems(4).Text = (ndocumento.documentoventaAbarrotes.serie)
            .SelectedItems(0).SubItems(5).Text = (ndocumento.documentoventaAbarrotes.numeroDocNormal)
            entidad = entidadSA.UbicarEntidadPorID(txtidCliente.Text).First()
            .SelectedItems(0).SubItems(6).Text = ("")
            .SelectedItems(0).SubItems(7).Text = ("")
            .SelectedItems(0).SubItems(8).Text = (entidad.nombreCompleto)
            .SelectedItems(0).SubItems(9).Text = ("")

            .SelectedItems(0).SubItems(10).Text = (FormatNumber(ndocumento.documentoventaAbarrotes.ImporteNacional, 2))
            .SelectedItems(0).SubItems(11).Text = (FormatNumber(ndocumento.documentoventaAbarrotes.tipoCambio, 2))
            .SelectedItems(0).SubItems(12).Text = (FormatNumber(ndocumento.documentoventaAbarrotes.ImporteExtranjero, 2))
            .SelectedItems(0).SubItems(13).Text = (FormatNumber(ndocumento.documentoventaAbarrotes.moneda, 2))
            '     .SelectedItems(0).SubItems(14).Text = (TIPO_VENTA.VENTA_AL_TICKET)
        End With
        Dispose()
    End Sub
#End Region

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub txtSerieComp_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieComp.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroComp.Focus()
            txtNumeroComp.Select(0, txtSerieComp.Text.Length)
        End If
    End Sub

    Private Sub txtSerieComp_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieComp.LostFocus
        Try
            Select Case txtIdComprobante.Text
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerieComp.Text = "" Or Not String.IsNullOrEmpty(txtSerieComp.Text) Then
                        If IsNumeric(txtSerieComp.Text) Then
                            txtSerieComp.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieComp.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieComp.Clear()
                            txtSerieComp.Focus()
                            txtSerieComp.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerieComp.Text = "" Or Not String.IsNullOrEmpty(txtSerieComp.Text) Then
                        If IsNumeric(txtSerieComp.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieComp.Clear()
                            txtSerieComp.Focus()
                            txtSerieComp.SelectAll()
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

    Private Sub txtSerieComp_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieComp.TextChanged

    End Sub
    Private Sub glosa()
        If Not String.IsNullOrEmpty(txtSerieComp.Text) And Not String.IsNullOrEmpty(txtNumeroComp.Text) And _
        Not String.IsNullOrEmpty(txtidCliente.Text) Then
            txtGlosa.Text = String.Concat("Por ventas", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), "Nro.", Space(1), txtSerieComp.Text, "-", txtNumeroComp.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
        End If
    End Sub
    Private Sub txtNumeroComp_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroComp.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumeroComp_LostFocus(sender, e)
            txtCliente.Focus()
            txtCliente.Select()
            If txtCliente.Text.Trim.Length > 0 Then

            Else
                ClientesShows()
                tvDatos.SelectedNode = newNodeDetalle
            End If
        End If
    End Sub

    Private Sub txtNumeroComp_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumeroComp.LostFocus
        Try
            Select Case txtIdComprobante.Text
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtNumeroComp.Text = "" Or Not String.IsNullOrEmpty(txtNumeroComp.Text) Then
                        If IsNumeric(txtNumeroComp.Text) Then
                            If txtNumeroComp.Text.Length = 20 Then

                            Else
                                txtNumeroComp.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroComp.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroComp.Clear()
                            txtNumeroComp.Focus()
                            txtNumeroComp.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtNumeroComp.Text = "" Or Not String.IsNullOrEmpty(txtNumeroComp.Text) Then
                        If IsNumeric(txtNumeroComp.Text) Then
                            If txtNumeroComp.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroComp.Clear()
                            txtNumeroComp.Focus()
                            txtNumeroComp.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"
                    If Not txtNumeroComp.Text = "" Or Not String.IsNullOrEmpty(txtNumeroComp.Text) Then
                        If IsNumeric(txtNumeroComp.Text) Then
                            If txtNumeroComp.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroComp.Clear()
                            txtNumeroComp.Focus()
                            txtNumeroComp.SelectAll()
                        End If
                    End If
                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumeroComp.Clear()
        End Try
    End Sub

    Private Sub txtNumeroComp_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroComp.TextChanged

    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        ClientesShows()
    End Sub

    Private Sub txtComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerieComp.Focus()
            txtSerieComp.Select(0, txtSerieComp.Text.Length)
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub

    'Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
    '    Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
    '    datos.Clear()
    '    With frmCanastaVentas
    '        .lblMoneda.Text = IIf(rbNac.Checked = True, "1", "2")
    '        .lblTipoCambio.Text = nudTipoCambio.Value
    '        .lblIgv.Text = nudIgv.Value
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        For i As Integer = 0 To datos.Count - 1
    '            dgvNuevoDoc.Rows.Add(datos(i).Secuencia,
    '                                 datos(i).Gravado,
    '                                 datos(i).IdArticulo,
    '                                 datos(i).NameArticulo,
    '                                 datos(i).UM,
    '                                 datos(i).Cantidad,
    '                                 datos(i).PrecUnitKardexMN,
    '                                 datos(i).CantDisponible,
    '                                 datos(i).PUmn,
    '                                 datos(i).PUme,
    '                                 datos(i).ImporteMN,
    '                                 datos(i).ImporteME,
    '                                 datos(i).DsctoMN,
    '                                 datos(i).DsctoME,
    '                                 datos(i).KardexMN,
    '                                 datos(i).IscMN,
    '                                 datos(i).IgvMN,
    '                                 datos(i).OtcMN,
    '                                 datos(i).KardexME,
    '                                 datos(i).IscME,
    '                                 datos(i).IgvME,
    '                                 datos(i).OtcME,
    '                                 Business.Entity.BaseBE.EntityAction.INSERT,
    '                                 datos(i).TipoExistencia,
    '                                 datos(i).IdAlmacen,
    '                                 datos(i).Cuenta,
    '                                 datos(i).Establecimiento,
    '                                 datos(i).PreEvento,
    '                                 datos(i).PrecUnitKardexME,
    '                                 datos(i).Presentacion,
    '                                 datos(i).FechaVcto,
    '                                 datos(i).NamePresentacion,
    '                                 datos(i).TipoVenta,
    '                                 0,
    '                                 0)
    '        Next
    '        '  Label13.Text = "Nro. Productos: " & dgvNuevoDoc.Rows.Count

    '        If dgvNuevoDoc.Rows.Count > 0 Then
    '            CellEndEditRefresh()
    '        End If
    '    End With
    'End Sub

    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If dgvNuevoDoc.Rows.Count > 0 Then

            If Not IsNothing(dgvNuevoDoc.CurrentRow) Then

                If dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    deletefila()
                    If dgvNuevoDoc.Rows.Count > 0 Then
                        CellEndEditRefresh()
                    Else
                        nudBase1.Value = 0.0
                        nudBaseus1.Value = 0.0
                        nudBase2.Value = 0.0
                        nudBaseus2.Value = 0.0

                        nudMontoIgv1.Value = 0.0
                        nudMontoIgvus1.Value = 0.0
                        nudMontoIgv2.Value = 0.0
                        nudMontoIgvus2.Value = 0.0

                        lblTotalBase.Text = 0.0
                        lblTotalBaseUS.Text = 0.0

                        lblTotalISc.Text = 0.0
                        lblTotalIScUS.Text = 0.0

                        lblTotalMontoIgv.Text = 0.0
                        lblTotalMontoIgvUS.Text = 0.0

                        lblOtrostribTotal.Text = 0.0
                        lblOtrostribTotalUS.Text = 0.0

                        lblTotalAdquisiones.Text = 0.0
                        lblTotalUS.Text = 0.0
                    End If
                ElseIf dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    '   DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
                    dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index

                    dgvNuevoDoc.CurrentCell = Nothing
                    Me.dgvNuevoDoc.Rows(pos).Visible = False

                    '     deletefila()

                End If
                If dgvNuevoDoc.Rows.Count > 0 Then
                    CellEndEditRefresh()
                End If
            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        If dgvNuevoDoc.Rows.Count > 0 Then
            If nudTipoCambio.Value > 0 Then
                'DECLARANDO VARIABLES
                Dim colPrecUnitAlmacen As Decimal = 0 '
                Dim colPrecUnitUSAlmacen As Decimal = 0 '

                colPrecUnitAlmacen = dgvNuevoDoc.Item(6, dgvNuevoDoc.CurrentRow.Index).Value '
                colPrecUnitUSAlmacen = dgvNuevoDoc.Item(28, dgvNuevoDoc.CurrentRow.Index).Value '


                Dim colPrecUnit As Decimal = 0 '
                Dim colPrecUnitUSD As Decimal = 0 '
                Dim colDestinoGravado As Decimal = 0 '

                colPrecUnit = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value '
                colPrecUnitUSD = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value '
                colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value '

                Dim colCantidad As Decimal = dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value '
                Dim colCantidadDisponible As Decimal = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value '

                Dim colBI As Decimal = 0
                Dim colBI_ME As Decimal = 0
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnit, 2)
                Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)


                Dim colCostoMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                Dim colCostoME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)

                If colCantidad > 0 AndAlso colMN > 0 Then

                    colBI = Math.Round(colMN / 1.18, 2)
                    colBI_ME = Math.Round(colME / 1.18, 2)
                    colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                    colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                Else
                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0
                End If

                Select Case dgvNuevoDoc.Columns(e.ColumnIndex).Name
                    Case "Can1"
                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = 0
                            Exit Sub
                        Else
                            dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad.ToString("N2")
                        End If
                End Select
                Dim valor As Decimal = 0
                Dim NUDIGV_VALUE As Decimal = 0
                '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                If rbNac.Checked = True Then
                    Select Case colDestinoGravado
                        Case 1
                            NUDIGV_VALUE = Math.Round((nudIgv.Value / 100) + 1, 2)
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                                If Not IsNothing(colMN) Then
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' monto para el kardex
                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' monto igv del item
                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                    dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                    dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                    dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")
                                End If
                                '  totales()
                                '    subTotales("All")
                                'GenerarAsientos()
                                'ObetenerAsientosContablesFull()
                            ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' monto para el kardex
                                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' monto igv del item
                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")

                                'GenerarAsientos()
                                'ObetenerAsientosContablesFull()
                            End If


                        Case 2
                            NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                                If Not IsNothing(colMN) Then
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")  ' monto para el kardex USD
                                    dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"

                                    dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                    dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")

                                End If
                                '   totales()
                                '   subTotales("All")
                                'GenerarAsientos()
                                'ObetenerAsientosContablesFull()

                            ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")
                                '   subTotales("All")
                                'GenerarAsientos()
                                'ObetenerAsientosContablesFull()
                            End If

                    End Select
                    totales_xx()
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
                    .ToolTipText = "1: ADQ. AFECTOS AL I.G.V."
                ElseIf e.Value.Equals("2") Then
                    .ToolTipText = "2: ADQ. NO AFECTOS AL I.G.V."
                End If

            End With

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
                    Case 5
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
                        'Case 3
                        '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(0, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                        'Case 10 Or 11
                        '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(23, Me.dgvNuevoDoc.CurrentCell.RowIndex)
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

    Private Sub tvDatos_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvDatos.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case tvDatos.SelectedNode.Tag
            Case "IF"
                TabPage1.Parent = TabCompra
                '      TabPage3.Parent = Nothing
                ' TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing
                TabCompra.Focus()
                txtFechaComprobante.Select()
                txtFechaComprobante.Focus()
            Case "DP"
                TabPage1.Parent = Nothing
                '    TabPage3.Parent = Nothing
                '  TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing


            Case "DC"
                '       TabPage3.Parent = TabCompra

                TabPage1.Parent = Nothing

                TabPage5.Parent = Nothing


            Case "IP"
                '  TabPage4.Parent = TabCompra

                TabPage1.Parent = Nothing

                TabPage5.Parent = Nothing

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

    Private Sub GuardarToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton2.Click
        Try
            If txtSerieComp.Text.Trim.Length > 0 Then
                Me.lblEstado.Image = My.Resources.ok4
                Me.lblEstado.Text = "Done Serie!"
            Else
                Me.lblEstado.Image = My.Resources.warning2
                Me.lblEstado.Text = "Indicar el número de serie!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If

            If txtNumeroComp.Text.Trim.Length > 0 Then
                Me.lblEstado.Image = My.Resources.ok4
                Me.lblEstado.Text = "Done Número!"
            Else
                Me.lblEstado.Image = My.Resources.warning2
                Me.lblEstado.Text = "Indicar el número de comprobante!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If

            If txtCliente.Text.Trim.Length > 0 Then
                Me.lblEstado.Image = My.Resources.ok4  ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Done Cliente!"
            Else
                Me.lblEstado.Image = My.Resources.warning2   ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese el nombre del cliente!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If

            If dgvNuevoDoc.Rows.Count > 0 Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    Grabar()
                Else
                    Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                    If Filas > 0 Then
                        UpdateVenta()
                    Else
                        Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                        Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If
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
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End Try
    End Sub

    Private Sub nudTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudTipoCambio.ValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then
            If nudTipoCambio.Value > 0 Then
                CellEndEditRefresh()
            End If

        End If
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
    '            txtSerieComp.Focus()
    '            txtSerieComp.Select(0, txtSerieComp.Text.Length)
    '            If dgvNuevoDoc.Rows.Count > 0 Then
    '                CellEndEditRefresh()
    '            End If
    '        Else
    '            txtIdComprobante.Text = String.Empty
    '            txtComprobante.Text = String.Empty
    '            lblEstado.Text = "Debe ingresar un comprobante."
    '            lblEstado.Image = My.Resources.warning2
    '            Timer1.Enabled = True
    '            TiempoEjecutar(5)
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub frmVentaGAlCredito_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
      

        tvDatos.SelectedNode = newNodeComprobante
        txtFechaComprobante.Select()
        txtFechaComprobante.Focus()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFechaComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtComprobante.Focus()
        End If
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
            txtSerieGuia.Select()
            txtSerieGuia.Focus()
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
End Class