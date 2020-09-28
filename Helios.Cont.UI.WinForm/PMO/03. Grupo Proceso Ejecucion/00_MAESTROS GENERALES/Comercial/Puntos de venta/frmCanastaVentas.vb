Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCanastaVentas
    Public Property IgvVal() As Decimal

#Region "GENERAL"

#Region "Datagridview"


#End Region

#Region "Métodos Canasta"



    'Public Sub CalcularTodo()
    '    Dim valor As Decimal = 0
    '    Dim NUDIGV_VALUE As Decimal = 0
    '    If frmPedidoAbarrote.nudTipoCambio.Value > 0 Then
    '        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
    '            If frmPedidoAbarrote.rbNacional.Checked Then
    '                Select Case i.Cells(1).Value
    '                    Case 1
    '                        NUDIGV_VALUE = Math.Round((frmPedidoAbarrote.nudIgv.Value / 100) + 1, 2)
    '                        '    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

    '                        If Not IsNothing(i.Cells(10).Value) Then
    '                            valor = Math.Round(CDec(i.Cells(5).Value) * CDec(i.Cells(8).Value), 2)
    '                            i.Cells(10).Value = valor
    '                            i.Cells(11).Value = Math.Round(CDec(i.Cells(10).Value / CDec(frmPedidoAbarrote.nudTipoCambio.Value)), 2).ToString("N2") ' MONTO TOTAL DOLARES
    '                            i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex
    '                            i.Cells(16).Value = Math.Round(CDec(i.Cells(10).Value - CDec(i.Cells(12).Value)), 2).ToString("N2") ' monto igv del item
    '                            i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex USD
    '                            i.Cells(9).Value = Math.Round(CDec(i.Cells(8).Value) / frmPedidoAbarrote.nudTipoCambio.Value, 2).ToString("N2") 'prec unit usd
    '                        End If
    '                        ' End If
    '                        totales()
    '                        subTotales("All")
    '                    Case 2
    '                        NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
    '                        '   If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

    '                        If Not IsNothing(i.Cells(10).Value) Then
    '                            valor = Math.Round(CDec(i.Cells(5).Value) * CDec(i.Cells(8).Value), 2)
    '                            i.Cells(10).Value = valor.ToString("N2")
    '                            i.Cells(11).Value = Math.Round(CDec(i.Cells(10).Value / CDec(frmPedidoAbarrote.nudTipoCambio.Value)), 2).ToString("N2") ' MONTO TOTAL DOLARES
    '                            i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value)) ' / CDec(NUDIGV_VALUE)), 2).ToString("N2")  monto para el kardex
    '                            i.Cells(16).Value = Math.Round(CDec(i.Cells(10).Value - CDec(i.Cells(12).Value)), 2).ToString("N2") ' monto igv del item
    '                            i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value)) ' / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex USD
    '                            i.Cells(9).Value = Math.Round(CDec(i.Cells(8).Value) / frmPedidoAbarrote.nudTipoCambio.Value, 2).ToString("N2") 'prec unit usd
    '                            ' End If
    '                        End If
    '                        totales()
    '                        subTotales("All")
    '                End Select
    '            Else


    '                Select Case i.Cells(1).Value
    '                    Case 1
    '                        NUDIGV_VALUE = Math.Round((frmPedidoAbarrote.nudIgv.Value / 100) + 1, 2)
    '                        '    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

    '                        If Not IsNothing(i.Cells(10).Value) Then
    '                            valor = Math.Round(i.Cells(5).Value * i.Cells(9).Value, 2)
    '                            i.Cells(11).Value = valor.ToString("N2")
    '                            i.Cells(10).Value = Math.Round(CDec(i.Cells(11).Value * CDec(frmPedidoAbarrote.nudTipoCambio.Value)), 2).ToString("N2") ' MONTO TOTAL SOLES
    '                            i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex usd
    '                            i.Cells(20).Value = Math.Round(CDec(i.Cells(11).Value - CDec(i.Cells(16).Value)), 2).ToString("N2") ' monto igv del item USD
    '                            i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex SOLES
    '                            i.Cells(8).Value = Math.Round(CDec(i.Cells(9).Value) * frmPedidoAbarrote.nudTipoCambio.Value, 2).ToString("N2") 'prec unit SOLES
    '                        End If

    '                        totales()
    '                        subTotales("All")

    '                    Case 2
    '                        NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
    '                        '  If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

    '                        If Not IsNothing(i.Cells(10).Value) Then
    '                            valor = Math.Round(i.Cells(5).Value * i.Cells(9).Value, 2)
    '                            i.Cells(11).Value = valor.ToString("N2")
    '                            i.Cells(10).Value = Math.Round(CDec(i.Cells(11).Value * CDec(frmPedidoAbarrote.nudTipoCambio.Value)), 2).ToString("N2") ' MONTO TOTAL SOLES
    '                            i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value)) ' / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex usd
    '                            i.Cells(20).Value = Math.Round(CDec(i.Cells(11).Value - CDec(i.Cells(16).Value)), 2).ToString("N2") ' monto igv del item USD
    '                            i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value)) ' / CDec(NUDIGV_VALUE)), 2).ToString("N2") ' monto para el kardex SOLES
    '                            i.Cells(8).Value = Math.Round(CDec(i.Cells(9).Value) * frmPedidoAbarrote.nudTipoCambio.Value, 2).ToString("N2") 'prec unit SOLES
    '                        End If

    '                        totales()
    '                        subTotales("All")
    '                        ' End If
    '                End Select
    '            End If
    '        Next
    '        Dim cmn As Decimal = 0
    '        Dim cme As Decimal = 0

    '        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
    '            cmn += CDec(i.Cells(5).Value * i.Cells(6).Value)
    '            cme += CDec(i.Cells(5).Value * i.Cells(28).Value)
    '        Next
    '        lblCostoMN.Text = cmn.ToString("N2")
    '        lblCostoME.Text = cme.ToString("N2")
    '    End If
    'End Sub


#End Region

    Public Sub CalcularTodo()
        Dim valor As Decimal = 0
        Dim NUDIGV_VALUE As Decimal = 0
        If CDec(lblTipoCambio.Text) > 0 Then
            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If lblMoneda.Text = "1" Then
                    Select Case i.Cells(1).Value
                        Case 1
                            NUDIGV_VALUE = Math.Round((CDec(lblIgv.Text) / 100) + 1, 2)
                            '    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                            If Not IsNothing(i.Cells(10).Value) Then
                                valor = Math.Round(CDec(i.Cells(5).Value) * CDec(i.Cells(8).Value), 2)
                                i.Cells(10).Value = valor
                                i.Cells(11).Value = Math.Round(CDec(i.Cells(10).Value / CDec(lblTipoCambio.Text)), 2) ' MONTO TOTAL DOLARES
                                i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex
                                i.Cells(16).Value = Math.Round(CDec(i.Cells(10).Value - CDec(i.Cells(12).Value)), 2) ' monto igv del item
                                i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex USD
                                i.Cells(9).Value = Math.Round(CDec(i.Cells(8).Value) / CDec(lblTipoCambio.Text), 2) 'prec unit usd
                            End If
                            ' End If
                            'totales()
                            'subTotales("All")
                        Case 2
                            NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
                            '   If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                            If Not IsNothing(i.Cells(10).Value) Then
                                valor = Math.Round(CDec(i.Cells(5).Value) * CDec(i.Cells(8).Value), 2)
                                i.Cells(10).Value = valor
                                i.Cells(11).Value = Math.Round(CDec(i.Cells(10).Value / CDec(lblTipoCambio.Text)), 2) ' MONTO TOTAL DOLARES
                                i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value)) ' / CDec(NUDIGV_VALUE)), 2)  monto para el kardex
                                i.Cells(16).Value = Math.Round(CDec(i.Cells(10).Value - CDec(i.Cells(12).Value)), 2) ' monto igv del item
                                i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value)) ' / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex USD
                                i.Cells(9).Value = Math.Round(CDec(i.Cells(8).Value) / lblTipoCambio.Text, 2) 'prec unit usd
                                ' End If
                            End If
                            'totales()
                            'subTotales("All")
                    End Select
                Else


                    Select Case i.Cells(1).Value
                        Case 1
                            NUDIGV_VALUE = Math.Round((CDec(lblIgv.Text) / 100) + 1, 2)
                            '    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                            If Not IsNothing(i.Cells(10).Value) Then
                                valor = Math.Round(i.Cells(5).Value * i.Cells(9).Value, 2)
                                i.Cells(11).Value = valor
                                i.Cells(10).Value = Math.Round(CDec(i.Cells(11).Value * CDec(lblTipoCambio.Text)), 2) ' MONTO TOTAL SOLES
                                i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex usd
                                i.Cells(20).Value = Math.Round(CDec(i.Cells(11).Value - CDec(i.Cells(16).Value)), 2) ' monto igv del item USD
                                i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex SOLES
                                i.Cells(8).Value = Math.Round(CDec(i.Cells(9).Value) * CDec(lblTipoCambio.Text), 2) 'prec unit SOLES
                            End If

                            'totales()
                            'subTotales("All")

                        Case 2
                            NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
                            '  If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                            If Not IsNothing(i.Cells(10).Value) Then
                                valor = Math.Round(i.Cells(5).Value * i.Cells(9).Value, 2)
                                i.Cells(11).Value = valor
                                i.Cells(10).Value = Math.Round(CDec(i.Cells(11).Value * CDec(lblTipoCambio.Text)), 2) ' MONTO TOTAL SOLES
                                i.Cells(18).Value = Math.Round(CDec(i.Cells(11).Value)) ' / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex usd
                                i.Cells(20).Value = Math.Round(CDec(i.Cells(11).Value - CDec(i.Cells(16).Value)), 2) ' monto igv del item USD
                                i.Cells(14).Value = Math.Round(CDec(i.Cells(10).Value)) ' / CDec(NUDIGV_VALUE)), 2) ' monto para el kardex SOLES
                                i.Cells(8).Value = Math.Round(CDec(i.Cells(9).Value) * CDec(lblTipoCambio.Text), 2) 'prec unit SOLES
                            End If

                            'totales()
                            'subTotales("All")
                            ' End If
                    End Select
                End If
            Next
            Dim cmn As Decimal = 0
            Dim cme As Decimal = 0
            Dim cImporteSol As Decimal = 0
            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                cmn += CDec(i.Cells(5).Value * i.Cells(6).Value)
                cme += CDec(i.Cells(5).Value * i.Cells(28).Value)
                cImporteSol += CDec(i.Cells(10).Value)
            Next
            lblCostoMN.Text = FormatNumber(cmn, 2)
            lblCostoME.Text = FormatNumber(cme, 2)
            lblImporte.Text = "Total: " & FormatNumber(cImporteSol, 2)
        End If
    End Sub

#Region "Métodos"
    'Public Function ObtenerAlmacenPred(ByVal intIdEstable As Integer) As String
    '    Dim almacenSA As New almacenSA
    '    Dim almacen As New almacen
    '    Dim dato As String = Nothing
    '    Try
    '        almacen = almacenSA.GetUbicar_almacenPredeterminado(intIdEstable)
    '        If Not IsNothing(almacen) Then
    '            dato = almacen.descripcionAlmacen
    '            txtIDAlmacen.Text = almacen.idAlmacen
    '            txtAlmacen.Text = almacen.descripcionAlmacen
    '        Else
    '            dato = Nothing
    '            txtIDAlmacen.Text = String.Empty
    '            txtAlmacen.Text = String.Empty
    '        End If
    '    Catch ex As Exception
    '        MsgBox("No se pudo ubicar almacen" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
    '    End Try
    '    Return dato
    'End Function

    'Private Sub ObtenerListaPorItem(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer,
    '                                        ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String,
    '                                        ByVal strDestinoGrav As String, ByVal intItem As Integer,
    '                                        ByVal strPresentacion As String, ByVal strUnidad As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.ListadoPrecioBO
    '    Dim CONF As String = Nothing
    '    Try
    '        objLista = objService.GetObtenerListaPorItemMAX(strIdEmpresa, intIdEstablecimiento, intIdAlmacen, strTipoExistencia, strDestinoGrav, intItem, strPresentacion, strUnidad)
    '        lsvDetalle.Columns.Clear()
    '        lsvDetalle.Items.Clear()
    '        lsvDetalle.Columns.Add("Modalidad", 50) '0
    '        lsvDetalle.Columns.Add("Pr Unit.", 55, HorizontalAlignment.Left) '1
    '        'MENOR
    '        lsvDetalle.Columns.Add("Dscto importe", 62, HorizontalAlignment.Right) '2
    '        lsvDetalle.Columns.Add("Dscto importeME", 0, HorizontalAlignment.Right) '3
    '        lsvDetalle.Columns.Add("P.Final", 62, HorizontalAlignment.Right) '4
    '        lsvDetalle.Columns.Add("P.FinalME", 0, HorizontalAlignment.Right) '5
    '        'MAYOR
    '        lsvDetalle.Columns.Add("Dscto importe", 62, HorizontalAlignment.Right) '6
    '        lsvDetalle.Columns.Add("Dscto importeME", 0, HorizontalAlignment.Right) '7
    '        lsvDetalle.Columns.Add("P.Final", 62, HorizontalAlignment.Right) '8
    '        lsvDetalle.Columns.Add("P.FinalME", 0, HorizontalAlignment.Right) '9
    '        'GRAN MAYOR MENOR
    '        lsvDetalle.Columns.Add("Dscto importe", 62, HorizontalAlignment.Right) '10
    '        lsvDetalle.Columns.Add("Dscto importeME", 0, HorizontalAlignment.Right) '11
    '        lsvDetalle.Columns.Add("P.Final", 62, HorizontalAlignment.Right) '12
    '        lsvDetalle.Columns.Add("P.FinalME", 0, HorizontalAlignment.Right) '13

    '        lsvDetalle.Columns.Add("Detalle Menor", 20, HorizontalAlignment.Right) '14
    '        lsvDetalle.Columns.Add("Detalle Mayor", 20, HorizontalAlignment.Right) '15
    '        lsvDetalle.Columns.Add("Detalle Gmayor", 20, HorizontalAlignment.Right) '16

    '        For Each i As HeliosService.ListadoPrecioBO In objLista
    '            If i.tipoConfiguracion = "PC" Then
    '                CONF = "%"
    '            Else
    '                CONF = "FIJO"
    '            End If
    '            Dim n As New ListViewItem(CONF)
    '            n.SubItems.Add(i.precioVentaMN)

    '            n.SubItems.Add(i.montoDsctounitMenorMN)
    '            n.SubItems.Add(i.montoDsctounitMenorME)
    '            n.SubItems.Add(i.precioVentaFinalMenorMN)
    '            n.SubItems.Add(i.precioVentaFinalMenorME)

    '            n.SubItems.Add(i.montoDsctounitMayorMN)
    '            n.SubItems.Add(i.montoDsctounitMayorME)
    '            n.SubItems.Add(i.precioVentaFinalMayorMN)
    '            n.SubItems.Add(i.precioVentaFinalMayorME)

    '            n.SubItems.Add(i.montoDsctounitGMayorMN)
    '            n.SubItems.Add(i.montoDsctounitGMayorME)
    '            n.SubItems.Add(i.precioVentaFinalGMayorMN)
    '            n.SubItems.Add(i.precioVentaFinalGMayorME)

    '            n.SubItems.Add(i.DetalleMenor)
    '            n.SubItems.Add(i.DetalleMayor)
    '            n.SubItems.Add(i.DetalleGMayor)
    '            lsvDetalle.Items.Add(n)
    '        Next

    '    Catch ex As Exception
    '        MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
    '    End Try
    'End Sub

    'Private Sub OBTENERALMACENES(ByVal strEmpresa As String, ByVal strTipo As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS
    '    Dim objLista() As HeliosService.AlmacenBO
    '    Dim dt, dt2 As New DataTable()
    '    Try
    '        objLista = objService.ObtenerAlmacenesxTipo(strEmpresa, strTipo)
    '        dt.Columns.Add("Almacen", GetType([String]))
    '        dt.Columns.Add("Empresa", GetType([String]))
    '        dt.Columns.Add("IDEstablecimiento", GetType([String]))
    '        dt.Columns.Add("NombreEstab", GetType([String]))
    '        dt.Columns.Add("Descripcion", GetType([String]))
    '        dt.Columns.Add("Tipo", GetType([String]))
    '        dt.Columns.Add("Porcentaje", GetType(Decimal))
    '        dt.Rows.Add("", "", "", "", "", "")
    '        For x = 0 To objLista.Count - 1
    '            dt.Rows.Add(objLista(x).IdAlmacen, objLista(x).IdEmpresa,
    '                        objLista(x).IdEstablecimiento,
    '                            objLista(x).NombreEstablecimiento,
    '                            objLista(x).DescripcionAlmacen,
    '                            objLista(x).Tipo,
    '                            objLista(x).PorcentajeUtilidad)
    '        Next
    '        cboAlmacen.Data = dt

    '        cboAlmacen.ViewColumn = 4
    '        'cboProveedor.DisplayMember = "nrodoc"
    '        'cboProveedor.ValueMember = "idEntidad"
    '        cboAlmacen.Columns(0).Display = False
    '        cboAlmacen.Columns(1).Display = False
    '        cboAlmacen.Columns(2).Display = False
    '        cboAlmacen.Columns(3).Display = False
    '        cboAlmacen.Columns(5).Display = False
    '        cboAlmacen.Columns(6).Display = False
    '        '  cboALV.Columns(4).Display = False
    '        cboAlmacen.Text = ""
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información para los combos" & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Private Sub OBTENER_DISTRIBUCION(ByVal IntIdAlmacen As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS
    '    Dim objLista() As HeliosService.InventarioMovimientoBO
    '    Dim n As New Productos()
    '    Dim datos As List(Of Productos) = Productos.Instance()
    '    Try
    '        datos.Clear()
    '        objLista = objService.GetObtenerProductosParaMateriaPrima(IntIdAlmacen, cboTipoExistencia.SelectedValue)
    '        For Each i As HeliosService.InventarioMovimientoBO In objLista
    '            If CDec(i.cantidad) > 0 Then
    '                n = New Productos()
    '                n.m_IdAlmace = i.idAlmacen
    '                n.m_TipoExistencia = i.tipoProducto
    '                n.m_Origen = i.destinoGravadoItem
    '                n.m_IdItem = i.idItem
    '                n.m_Descripcion = String.Concat(i.nombreItem, " - ", i.NombrePresentacion)
    '                n.m_UM = i.unidad
    '                n.m_CanDisponible = CDec(i.cantidad)
    '                n.m_PrecioUnit = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
    '                n.m_MontoMN = CDec(i.monto)
    '                n.m_PrecioUnitME = Math.Round(CDec(i.montoUSD) / CDec(i.cantidad), 2)
    '                n.m_MontoME = CDec(i.montoUSD)
    '                n.m_Cuenta = i.CuentaOrigenItem
    '                n.m_Establecimiento = i.idEstablecimiento
    '                n.m_Evento = i.PreEvento
    '                n.m_PVMN = "0"
    '                n.m_PVME = "0"
    '                n.m_DsctoMN = "0"
    '                n.m_DsctoME = "0"
    '                n.m_Presentacion = i.Presentacion
    '                n.m_FechaVcto = i.FechaVcto
    '                n.m_NamePresentacion = i.NombrePresentacion
    '                n.m_Catnidad = "0"
    '                n.m_tipoVenta = "MN"
    '                n.m_DetMenor = ""
    '                n.m_DetMayor = ""
    '                n.m_DetGMayor = ""
    '                datos.Add(n)
    '            End If
    '        Next
    '        '   DataGridView1.DataSource = datos
    '        'dgvItems.DataSource = Nothing
    '        'dgvItems.Rows.Clear()
    '        'For Each i As Productos In datos
    '        '    If CDec(i.m_Catnidad) > 0 Then
    '        '        dgvItems.Rows.Add(i.m_IdAlmace,
    '        '                              i.m_TipoExistencia,
    '        '                              i.m_Origen,
    '        '                              i.m_IdItem,
    '        '                              i.m_Descripcion,
    '        '                              i.m_UM,
    '        '                              i.m_Catnidad,
    '        '                              i.m_PrecioUnit,
    '        '                              i.m_MontoMN,
    '        '                              i.m_PrecioUnitME,
    '        '                              i.m_MontoME,
    '        '                              i.m_Cuenta,
    '        '                              i.m_Establecimiento,
    '        '                              i.m_Evento,
    '        '                              "0.00", "0.00",
    '        '                              "0.00", "0.00",
    '        '                              i.m_Presentacion, i.m_FechaVcto, i.m_NamePresentacion)
    '        '    End If
    '        'Next
    '        'operaciones()
    '        lblConteoProductos.Text = "PRODUCTOS ENCONTRADOS: " & dgvItems.Rows.Count
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Private Sub ObtenerCanastaVenta(IntIdAlmacen As Integer, strTipoExistencia As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Try
            dgvItems.Rows.Clear()
            For Each i As totalesAlmacen In CanastaSA.ObtenerCanastaDeVenta(IntIdAlmacen, strTipoExistencia)
                Dim valPrecUnitario As Decimal = Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2)
                Dim valPrecUnitarioUS As Decimal = Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2)
                dgvItems.Rows.Add(IntIdAlmacen,
                                      i.tipoExistencia,
                                      i.origenRecaudo,
                                      i.idItem,
                                      String.Concat(i.descripcion, " - ", i.NombrePresentacion),
                                      i.unidadMedida,
                                      FormatNumber(i.cantidad, 2),
                                      valPrecUnitario,
                                      FormatNumber(i.importeSoles, 2),
                                      valPrecUnitarioUS,
                                      FormatNumber(i.importeDolares, 2),
                                      i.CuentaContable,
                                      i.idEstablecimiento,
                                      Nothing,
                                      i.precioVentaFinalMenorMN,
                                      i.precioVentaFinalMenorME,
                                      i.montoDsctounitMenorMN,
                                      i.montoDsctounitMenorME,
                                      i.Presentacion,
                                      i.fechaVcto,
                                      i.NombrePresentacion,
                                      Nothing,
                                      "PM",
                                      i.detalleMenor,
                                      i.detalleMayor,
                                      i.detalleGMayor,
                                      i.precioVentaFinalMayorMN,
                                      i.precioVentaFinalGMayorMN,
                                      i.precioVentaFinalMayorME,
                                      i.precioVentaFinalGMayorME)

            Next
            '   operaciones()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        Dim lista As New listadoPrecios
        Try
            dgvItems.Rows.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing
            For Each i As totalesAlmacen In CanastaSA.ObtenerCanastaDeVentaPorProducto(IntIdAlmacen, strTipoExistencia, strProducto)
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2)
                    Dim valPrecUnitarioUS As Decimal = Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2)

                    lista = listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                    If Not IsNothing(lista) Then
                        With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                            cprecioVentaFinalMenorMN = IIf(IsNothing(.precioVentaFinalMenorMN), 0, .precioVentaFinalMenorMN)
                            cprecioVentaFinalMenorME = IIf(IsNothing(.precioVentaFinalMenorME), 0, .precioVentaFinalMenorME)
                            cmontoDsctounitMenorMN = IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                            cmontoDsctounitMenorME = IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                            cprecioVentaFinalMayorMN = IIf(IsNothing(.precioVentaFinalMayorMN), 0, .precioVentaFinalMayorMN)
                            cprecioVentaFinalGMayorMN = IIf(IsNothing(.precioVentaFinalGMayorMN), 0, .precioVentaFinalGMayorMN)
                            cprecioVentaFinalMayorME = IIf(IsNothing(.precioVentaFinalMayorME), 0, .precioVentaFinalMayorME)
                            cprecioVentaFinalGMayorME = IIf(IsNothing(.precioVentaFinalGMayorME), 0, .precioVentaFinalGMayorME)
                            cdetalleMenor = .detalleMenor
                            cdetalleMayor = .detalleMayor
                            cdetalleGMayor = .detalleGMayor
                        End With
                    Else
                        lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                        lblEstado.Image = My.Resources.warning2
                    End If


                    dgvItems.Rows.Add(IntIdAlmacen,
                                          i.tipoExistencia,
                                          i.origenRecaudo,
                                          i.idItem,
                                          String.Concat(i.descripcion, " - ", i.NombrePresentacion),
                                          i.unidadMedida,
                                          FormatNumber(i.cantidad, 2),
                                          valPrecUnitario,
                                          FormatNumber(i.importeSoles, 2),
                                          valPrecUnitarioUS,
                                          FormatNumber(i.importeDolares, 2),
                                          i.CuentaContable,
                                          i.idEstablecimiento,
                                          Nothing,
                                          cprecioVentaFinalMenorMN,
                                          cprecioVentaFinalMenorME,
                                          cmontoDsctounitMenorMN,
                                          cmontoDsctounitMenorME,
                                          i.Presentacion,
                                          i.fechaVcto,
                                          i.NombrePresentacion,
                                          Nothing,
                                          "PM",
                                          cdetalleMenor,
                                          cdetalleMayor,
                                          cdetalleGMayor,
                                          cprecioVentaFinalMayorMN,
                                          cprecioVentaFinalGMayorMN,
                                          cprecioVentaFinalMayorME,
                                          cprecioVentaFinalGMayorME)
                End If
              

            Next
            '   operaciones()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub operaciones()
        '     Dim valIGV As Decimal = CDec(FrmRegistroVenta.nudIgv.Value) / 100
        If dgvItems.Rows.Count > 0 Then
            For Each i As DataGridViewRow In dgvItems.Rows
                '  i.Cells(9).Value = nudPorcentaje.Value
                i.Cells(7).Value = Math.Round(CDec(i.Cells(8).Value) / CDec(i.Cells(6).Value), 2)  ' PREC UNIT
                i.Cells(9).Value = Math.Round(CDec(i.Cells(10).Value) / CDec(i.Cells(6).Value), 2)  ' PREC UNIT usd
            Next
        End If
    End Sub


    'Private Sub ContextMenuHandler(ByVal Sender As Object, ByVal e As EventArgs)
    '    Dim mi As MenuItem = DirectCast(Sender, MenuItem)

    '    Select Case mi.Text()
    '        Case "Precio x Menor"
    '            'Your add functionality here
    '            dgvItems.Item(16, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(2).Text
    '            dgvItems.Item(17, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(3).Text
    '            dgvItems.Item(14, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(4).Text
    '            dgvItems.Item(15, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(5).Text
    '            dgvItems.Item(22, dgvItems.CurrentRow.Index).Value = "PM"
    '        Case "Precio x Mayor"
    '            'Your edit functionality here
    '            dgvItems.Item(16, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(6).Text
    '            dgvItems.Item(17, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(7).Text
    '            dgvItems.Item(14, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(8).Text
    '            dgvItems.Item(15, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(9).Text
    '            dgvItems.Item(22, dgvItems.CurrentRow.Index).Value = "PMY"

    '        Case "Precio al Gran Mayor"
    '            'Your delete functionality here
    '            dgvItems.Item(16, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(10).Text
    '            dgvItems.Item(17, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(11).Text
    '            dgvItems.Item(14, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(12).Text
    '            dgvItems.Item(15, dgvItems.CurrentRow.Index).Value = lsvDetalle.SelectedItems(0).SubItems(13).Text
    '            dgvItems.Item(22, dgvItems.CurrentRow.Index).Value = "PGM"
    '    End Select
    'End Sub
#End Region

#End Region


    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub Panel6_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        If dgvNuevoDoc.Rows.Count > 0 Then

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
                        dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad
                    End If
            End Select
            Dim valor As Decimal = 0
            Dim NUDIGV_VALUE As Decimal = 0
            '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
            If lblMoneda.Text = "1" Then
                Select Case colDestinoGravado
                    Case 1
                        NUDIGV_VALUE = Math.Round((IgvVal / 100) + 1, 2)
                        If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                            If Not IsNothing(colMN) Then
                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit 'prec unit usd
                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD 'prec unit usd

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN
                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colBI ' monto para el kardex
                                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV ' monto igv del item
                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME   ' monto para el kardex USD

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME
                            End If
                            '  totales()
                            '    subTotales("All")
                            'GenerarAsientos()
                            'ObetenerAsientosContablesFull()
                        ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit 'prec unit usd
                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD 'prec unit usd

                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN
                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME ' MONTO TOTAL DOLARES
                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colBI ' monto para el kardex
                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV ' monto igv del item
                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME  ' monto para el kardex USD
                            dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME   ' monto para el kardex USD

                            dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN
                            dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME

                            'GenerarAsientos()
                            'ObetenerAsientosContablesFull()
                        End If


                    Case 2
                        NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
                        If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                            If Not IsNothing(colMN) Then
                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit 'prec unit usd
                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD 'prec unit usd

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN
                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colMN
                                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colME  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME

                            End If
                            '   totales()
                            '   subTotales("All")
                            'GenerarAsientos()
                            'ObetenerAsientosContablesFull()

                        ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit 'prec unit usd
                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD 'prec unit usd

                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN
                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME ' MONTO TOTAL DOLARES
                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colMN
                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colME  ' monto para el kardex USD
                            dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"

                            dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN
                            dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME
                            '   subTotales("All")
                            'GenerarAsientos()
                            'ObetenerAsientosContablesFull()
                        End If

                End Select
                'totales_xx()
                'TotalesCabeceras()
            Else
                'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
            End If

        Else
            MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
            'nudTipoCambio.Focus()
            'nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
        End If

        '  End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalAlmacen
            .ObtenerAlmacenes(txtEstablecimiento.ValueMember)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtAlmacen.ValueMember = datos(0).ID
                txtAlmacen.Text = datos(0).NombreEntidad

                '       ObtenerCanastaVenta(txtIDAlmacen.Text, "03")
            End If

        End With
        Me.Cursor = Cursors.Arrow
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
        '    Else

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub dgvItems_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellContentClick

    End Sub

    Private Sub dgvItems_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick

      
      
    End Sub

    Private Sub dgvItems_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvItems.CellMouseDoubleClick
        If dgvItems.SelectedRows.Count > 0 Then
            If dgvItems.Item(14, dgvItems.CurrentRow.Index).Value = 0 Then
                lblEstado.Text = "El producto no tiene configurado un precio.!!"
                lblEstado.Image = My.Resources.warning2
            Else
                With frmModalCanasta
                    .LOadDatos(txtAlmacen.ValueMember, dgvItems.Item(3, dgvItems.CurrentRow.Index).Value)
                    .IdItemval = dgvItems.Item(3, dgvItems.CurrentRow.Index).Value
                    .lblDetaMenor.Text = .UbicarTablas(dgvItems.Item(23, dgvItems.CurrentRow.Index).Value, 104)
                    .lblDetaMayor.Text = .UbicarTablas(dgvItems.Item(24, dgvItems.CurrentRow.Index).Value, 104)
                    .lblDetaGMayor.Text = .UbicarTablas(dgvItems.Item(25, dgvItems.CurrentRow.Index).Value, 104)
                    .lblproducto.Text = Convert.ToString(dgvItems.Item(4, dgvItems.CurrentRow.Index).Value)
                    .lblDisponible.Text = CDec(dgvItems.Item(6, dgvItems.CurrentRow.Index).Value)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'CalcularTodo()
                    'lblCanasta.Text = "CANASTA DE VENTAS: " & dgvNuevoDoc.Rows.Count & " " & " PRODUCTOS"
                    '  dgvItems.Rows.Clear()
                    txtFiltrar.Clear()
                    txtFiltrar.Focus()
                End With
            End If
        End If
    
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()

        For Each I As DataGridViewRow In dgvNuevoDoc.Rows
            n = New RecolectarDatos()
            n.Secuencia = datos.Count + 1 '0
            n.Gravado = I.Cells(1).Value
            n.IdArticulo = I.Cells(2).Value
            n.NameArticulo = I.Cells(3).Value
            n.UM = I.Cells(4).Value
            n.Cantidad = I.Cells(5).Value
            n.PrecUnitKardexMN = I.Cells(6).Value
            n.CantDisponible = I.Cells(7).Value
            n.PUmn = I.Cells(8).Value
            n.PUme = I.Cells(9).Value
            n.ImporteMN = I.Cells(10).Value
            n.ImporteME = I.Cells(11).Value
            n.DsctoMN = I.Cells(12).Value
            n.DsctoME = I.Cells(13).Value
            n.KardexMN = I.Cells(14).Value
            n.IscMN = I.Cells(15).Value
            n.IgvMN = I.Cells(16).Value
            n.OtcMN = I.Cells(17).Value
            n.KardexME = I.Cells(18).Value
            n.IscME = I.Cells(19).Value
            n.IgvME = I.Cells(20).Value
            n.OtcME = I.Cells(21).Value
            n.Estado = I.Cells(22).Value
            n.TipoExistencia = I.Cells(23).Value
            n.IdAlmacen = I.Cells(24).Value
            n.Cuenta = I.Cells(25).Value
            n.Establecimiento = I.Cells(26).Value
            n.PreEvento = I.Cells(27).Value
            n.PrecUnitKardexME = I.Cells(28).Value
            n.Presentacion = I.Cells(29).Value
            n.FechaVcto = I.Cells(30).Value
            n.NamePresentacion = I.Cells(31).Value
            n.TipoVenta = I.Cells(32).Value
            datos.Add(n)
        Next
        '        frmPedidoAbarrote.obtenerDatas()
        Me.Cursor = Cursors.Arrow
        Dispose()
    End Sub
    Sub AlmacenModConf()
        Dim almacenSA As New almacenSA
        Dim estableSA As New establecimientoSA
        With almacenSA.GetUbicar_almacenPorID(GConfiguracion.IdAlmacen)
            txtAlmacen.ValueMember = GConfiguracion.IdAlmacen
            txtAlmacen.Text = GConfiguracion.NombreAlmacen
            With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
                txtEstablecimiento.ValueMember = .idCentroCosto
                txtEstablecimiento.Text = .nombre
            End With
        End With
    End Sub
    Private Sub frmCanastaVentas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        'txtIDEstablecimiento.Text = GEstableciento.IdEstablecimiento
        'ObtenerAlmacenPred(txtIDEstablecimiento.Text)
        AlmacenModConf()

    End Sub

  

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        Dispose()
    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)
                ObtenerCanastaVentaFiltro(txtAlmacen.ValueMember, txtExistencia.ValueMember, txtFiltrar.Text.Trim)
                lblEstado.Text = "productos encontrados: " & dgvItems.Rows.Count
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Digitar un producto válido!"
                lblEstado.Image = My.Resources.warning2
            End If
        End If
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

    End Sub
End Class