Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Drawing.Printing

Public Class frmVentaPVdirecta
    Inherits frmMaster

  #Region "Attributes"
    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Dim time As Integer = 0
    Public Property TieneCotizacionInfo() As Boolean
    Public Property IdDocumentoCotizacion() As Integer?
    Dim colorx As New GridMetroColors()
    Dim idCajaUsuario As Integer
    Dim cajausuario As New List(Of cajaUsuario)
    Dim saldoMN As Decimal
    Public Property listaServicio As New List(Of servicio)
    Dim gridCaja As New GridGroupingControl
    Dim ListadocajaDelUsuario As New List(Of cajaUsuario)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Docking()
        FormatoGridPequeño(dgvCompra, False)
        FormatoGridPequeño(dgvServicios, False)
        FormatoGridPequeño(GridGroupingControl2, True)
        Loadcontroles()
        ConfiguracionInicio()
        GetTableGrid()
        IdDocumentoCotizacion = Nothing
        'If (chIdentificacion.Checked = True) Then
        '    cboTipoDoc.Text = "TICKET BOLETA"
        'ElseIf (chIdentificacion.Checked = False) Then
        '    cboTipoDoc.Text = "TICKET FACTURA"
        'End If

        ConfiguracionColumnsGridArticulos()
        '  chIdentificacion.Checked = True
    End Sub

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        UbicarDocumento(intIdDocumento)
        ToolStripComboBox2.Text = "TOTAL"
        ToolStripComboBox1.Text = "CREDITO"
        ConfiguracionColumnsGridArticulos()
    End Sub

    Public Sub New(TieneCotizacion As Boolean, intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Docking()
        FormatoGrid(dgvCompra)
        Loadcontroles()
        ConfiguracionInicio()
        GetTableGrid()
        ConfiguracionColumnsGridArticulos()
        UbicarDocumentoCotizacionDetails(intIdDocumento)
        TieneCotizacion = TieneCotizacion
        TieneCotizacionInfo = intIdDocumento
    End Sub
#End Region

#Region "Métodos"

    Public Sub ConfiguracionColumnsGridArticulos()
        GridDataBoundGrid1.GridBoundColumns("idEmpresa").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("destino").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("idItem").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("idPres").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("presentacion").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("puKardexmn").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("puKardexme").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("idalmacen").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("almacen").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("importeME").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("importeMn").Hidden = True

        'Tamaño de encabezado

        GridDataBoundGrid1.GridBoundColumns("descripcion").HeaderText = "Artículos"
        GridDataBoundGrid1.GridBoundColumns("descripcion").ReadOnly = True
        GridDataBoundGrid1.GridBoundColumns("cantidad").HeaderText = "Cant."
        GridDataBoundGrid1.GridBoundColumns("cantidad").ReadOnly = True
        GridDataBoundGrid1.GridBoundColumns("unidad").HeaderText = "U.M."
        GridDataBoundGrid1.GridBoundColumns("unidad").ReadOnly = True
        GridDataBoundGrid1.GridBoundColumns("descripcion").Width = 220

        GridDataBoundGrid1.GridBoundColumns("unidad").Width = 50
        GridDataBoundGrid1.GridBoundColumns("cantidad").Width = 60
        GridDataBoundGrid1.GridBoundColumns("fechaVcto").Width = 75

        GridDataBoundGrid1.GridBoundColumns("btn").HeaderText = "Action"

        Dim style As GridStyleInfo = GridDataBoundGrid1.GridBoundColumns(17).StyleInfo
        style.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
        style.TextAlign = GridTextAlign.Default
        style.CellType = "PushButton"
        style.Description = "agregar"
        style.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub GetListaProductosEmpresaByCodigoBarra(lista As List(Of totalesAlmacen))
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))


            For Each i As totalesAlmacen In lista
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen
                    dt.Rows.Add(dr)
                End If
            Next
            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Filtro(busqueda As String)
        Dim dt As New DataTable
        Dim da = (From a In listaServicio Where a.descripcion.Contains(busqueda)).ToList
        UbicarServiciosXFiltro(da)
    End Sub

    Public Sub UbicarServiciosXFiltro(lista As List(Of servicio))
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("idServicio")

        For Each i In lista
            Dim dr As DataRow = dt.NewRow
            dr(0) = "GS"
            dr(1) = i.cuenta
            dr(2) = i.descripcion
            dr(3) = i.idServicio
            dt.Rows.Add(dr)
        Next
        dgvServicios.DataSource = dt
        dgvServicios.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub


    Public Sub AgregarAcanastaServicvioCodigoBarra(r As Record, precio As configuracionPrecioProducto)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        'If rbMenor.Checked = True Then
        '    valTipoVenta = "MN"
        valPUmn = precio.precioMN
        valPUme = precio.precioME


        Me.Cursor = Cursors.WaitCursor
        'Dim valTipoVenta As String = Nothing
        'Dim valPUmn As Decimal = 0
        'Dim valPUme As Decimal = 0
        Dim tasaIva As Decimal = TmpIGV / 100
        'Dim productoSA As New detalleitemsSA

        'valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
        'valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        If cboDestino.Text = "2-Exonerado" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
        Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
        End If

        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", r.GetValue("idServicio"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 1)
        If cboDestino.Text = "2-Exonerado" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", (valPUmn / (tasaIva + 1)))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

            Dim iv As Decimal = 0
            iv = valPUmn / (tasaIva + 1)

            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", (iv * tasaIva))
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", iv * tasaIva)
        End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", valPUmn)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", valPUme)

        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

        Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '   If .tipoExistencia <> "GS" Then
        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", 0)
        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
        '   End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", r.GetValue("idServicio"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 1)

        Me.dgvCompra.Table.AddNewRecord.EndEdit()

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        TotalTalesXcolumna()

    End Sub

    Public Sub CMBCajasDelUsuarioPV()
        Dim cajausuariosa As New cajaUsuarioSA
        Dim cajausuario As New cajaUsuario
        Try
            ListadocajaDelUsuario = New List(Of cajaUsuario)
            cajausuario = cajausuariosa.UbicarUsuarioAbierto(usuario.IDUsuario)
            If Not IsNothing(cajausuario) Then
                ListadocajaDelUsuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = cajausuario.idcajaUsuario, .idPersona = usuario.IDUsuario})
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub CargarPrecios()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New List(Of configuracionPrecio)
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("cboprecio").Appearance.AnyRecordFieldCell

        precio.AddRange(precioSA.ListadoPrecios())
        precio.Add(New configuracionPrecio With {.idPrecio = 0, .precio = "-Ver tabla de precios-"})

        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = precio ' precioSA.ListadoPrecios()
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Sub ImprimirTicket(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro("DISTRIBUCIONES LUPITA")
        ticket.TextoCentro("ERM NEGOCIOS SAC.")
        ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro("R.U.C: 20601923042")
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
        End Select


        ticket.lineasHorizontales()
        'Sub cabecera.
        ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        For Each i In comprobanteDetalle

            Select Case i.destino
                Case OperacionGravada.Grabado
                    gravMN += CDec(i.montokardex)
                    gravME += CDec(i.montokardexUS)

                Case OperacionGravada.Exonerado
                    ExoMN += CDec(i.montokardex)
                    ExoME += CDec(i.montokardexUS)

                Case OperacionGravada.Inafecto
                    InaMN += CDec(i.montokardex)
                    InaME += CDec(i.montokardexUS)
            End Select

            ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        ticket.TextoIzquierda("")
        ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        ticket.TextoIzquierda("")
        ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()
        ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    Public Sub CargarTipoDeVenta(strTipoVenta As String)

        If (TIPO_VENTA.VENTA_CONTADO_PARCIAL = strTipoVenta) Then
            'GConfiguracion2 = New GConfiguracionModulo
            'configuracionModulo2(Gempresas.IdEmpresaRuc, "VT2", Me.Text)
            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
            ToolStripComboBox1.Text = "CONTADO"
            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False
        ElseIf (TIPO_VENTA.VENTA_CONTADO_TOTAL = strTipoVenta) Then
            'GConfiguracion2 = New GConfiguracionModulo
            'configuracionModulo2(Gempresas.IdEmpresaRuc, "VT2", Me.Text)
            'Panel6.Visible = True
            'Me.Size = New Size(1163, 730)
            ToolStripComboBox2.Text = "TOTAL"
            ToolStripComboBox1.Text = "CONTADO"
            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False
        ElseIf (TIPO_VENTA.VENTA_CREDITO_PARCIAL = strTipoVenta) Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
            'Panel6.Visible = False
            'Me.Size = New Size(1163, 527)
            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
            ToolStripComboBox1.Text = "CREDITO"
            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False
          
        ElseIf (TIPO_VENTA.VENTA_CREDITO_TOTAL = strTipoVenta) Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
            'Panel6.Visible = False
            'Me.Size = New Size(1163, 527)
            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False
            ToolStripComboBox2.Text = "TOTAL"
            ToolStripComboBox1.Text = "CREDITO"
          
        Else
            ToolStripComboBox2.Text = "TOTAL"
            ToolStripComboBox1.Text = "CREDITO"
        End If


    End Sub

    Public Sub llenarGrid(grid As GridGroupingControl, tag As Integer)
        If (tag = 1) Then

            gridCaja = grid
            CalculoPagos()
            Me.Cursor = Cursors.WaitCursor
            Try
                If (chIdentificacion.Checked = True) Then
                    If Not TXTcOMPRADOR.Text.Length > 0 Then
                        lblEstado.Text = "Ingresar el nombre de comprador"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)

                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        lblEstado.Text = "Done comprador"
                    End If
                Else
                    If Not txtProveedor.Text.Length > 0 Then

                        MessageBox.Show("Ingrese el cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtProveedor.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    If txtProveedor.Text.Length > 0 Then
                        If txtProveedor.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtProveedor.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If

                    If txtRuc.Text.Length > 0 Then
                        If txtRuc.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtRuc.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If

                End If

                Dim CONTEO As Integer = 0
                For Each item In dgvCompra.Table.Records
                    If (item.GetValue("cantPendiente") > 0) Then
                        CONTEO += 1
                    End If
                Next

                If (CONTEO > 0) Then
                    ToolStripButton2.Text = "TOTAL"
                ElseIf (CONTEO = 0) Then
                    ToolStripButton2.Text = "POR ENTREGAR/PARCIAL"
                End If

                'If Not cboCuentas.Text.Trim.Length > 1 Then
                '    lblEstado.Text = "Indicar la cuenta financiera"
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)

                '    Me.Cursor = Cursors.Arrow
                '    Exit Sub
                'End If

                '***********************************************************************
                If dgvCompra.Table.Records.Count > 0 Then
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

                        Select Case ToolStripComboBox1.Text
                            Case "CONTADO"
                                Dim sumaPagos As Decimal = 0
                                Dim totalPago As Decimal = 0
                                For Each i In grid.Table.Records
                                    sumaPagos += CDec(i.GetValue("montoMN"))
                                    If (i.GetValue("moneda") = "EXTRANJERO") Then
                                        If (i.GetValue("montoME") = 0) Then
                                            Throw New Exception("Debe Ingresar importe extranjero!")
                                        End If

                                    End If
                                Next

                                If (sumaPagos) = DigitalGauge2.Value Then

                                    'If MessageBoxAdv.Show("Desea imprimir la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                    '    If dgvPagos.Table.Records.Count > 0 Then
                                    '        llenarDatos()
                                    '        imprimir(True)
                                    '    End If
                                    'End If
                                    Grabar()
                                    'Dispose()

                                Else
                                    MessageBoxAdv.Show("Debe realizar el cobro en su integridad, no parcial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            Case Else
                                Grabar()
                                'Dispose()
                        End Select

                    Else

                    End If
                Else

                    Me.lblEstado.Text = "Ingrese items a la canasta de venta!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If
            Catch ex As Exception
                lblEstado.Text = ex.Message
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                ListaAsientonTransito = New List(Of asiento)

            End Try
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Public Sub UbicarDocumentoCotizacionDetails(intIdDocumento As Integer)
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0

        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA

        For Each i In objDocCompraDet.usp_EditarDetalleVenta(intIdDocumento)
            colBI = 0
            colBIme = 0

            Igv = 0
            IgvME = 0

            Select Case i.destino
                Case "1"
                    colBI = (CDec(i.importeMN) / 1.18)
                    colBIme = (CDec(i.importeME) / 1.18)

                    Igv = (colBI * (TmpIGV / 100))
                    IgvME = (colBIme * (TmpIGV / 100))

                Case "2"
                    colBI = i.importeMN
                    colBIme = i.importeME

                    Igv = 0
                    IgvME = 0
            End Select



            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        TotalTalesXcolumna()
    End Sub

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Public Sub UbicarUltimosPreciosXproducto()
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub GetExistenciaByCodigoBar(CodigoBarra As String)
        Dim totalSA As New TotalesAlmacenSA
        Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim existenciaSA As New detalleitemsSA
        'Dim existencia As New detalleitems

        'existencia = existenciaSA.GetExistenciaByCodeBar(CodigoBarra)
        Dim lista = totalSA.GetProductosByAlmacenCodigo(0, CodigoBarra)


        GetListaProductosEmpresaByCodigoBarra(lista)
        If GridDataBoundGrid1.Model.RowCount > 0 Then

        End If

    End Sub

    Private Sub ObtenerCanastaVentaFiltroEmpresa(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))

            dt.Columns.Add("codigoLote", GetType(String))
            dt.Columns.Add("fechaVcto", GetType(String))
            dt.Columns.Add("nrolote", GetType(String))

            'ListView1.Items.Clear()
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


            'For Each i As totalesAlmacen In CanastaSA.GetListadoProductosByAlmacen(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = "", .idEmpresa = Gempresas.IdEmpresaRuc}).OrderBy(Function(o) o.descripcion).ToList
            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosByAlmacen(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = "", .idEmpresa = Gempresas.IdEmpresaRuc}).ToList
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen

                    dr(14) = i.CustomLote.codigoLote
                    If i.CustomLote.fechaVcto.HasValue Then
                        dr(15) = i.CustomLote.fechaVcto.Value.ToString("MMM yyyy")
                    End If
                    dr(16) = i.CustomLote.nroLote
                    dt.Rows.Add(dr)
                End If
            Next
            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
            GridGroupingControl2.Table.Records.DeleteAll()
            If GridDataBoundGrid1.Model.RowCount > 0 Then
                UbicarUltimosPreciosXproducto()
            End If
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub ConteoLabelVentas()
        lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
    End Sub

    Public Function TieneCuentaFinanciera() As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA
        Dim valBool As Boolean = False

        GFichaUsuarios = New GFichaUsuario

        If IsNothing(GFichaUsuarios.NombrePersona) Then
            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Timer1.Enabled = True
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    valBool = False
                    '   Return False
                Else
                    valBool = True
                    '   Return True
                End If
            End With
        End If
        Return valBool
    End Function

    Private Sub Docking()
        Me.dockingManager1.DockControl(Me.PanelCanasta, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 465)
        'dockingManager1.DockControlInAutoHideMode(PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        Me.dockingManager1.DockControl(Me.Panel5, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        DockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        dockingManager1.SetDockLabel(PanelCanasta, "Canasta de Inventario")
        dockingManager1.SetDockLabel(Panel5, "Servicios")
        '    dockingManager1.SetDockLabel(PanelMontos, "Importes del Comprobante")
        dockingManager1.CloseEnabled = False
    End Sub

    Sub ConfiguracionInicio()
        'Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen

        'confgiurando variables generales
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        '    periodo = PeriodoGeneral
        txtTipoCambio.DecimalValue = TmpTipoCambio
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()

        lblEmpresa.Text = Gempresas.NomEmpresa
        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        'Try

        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

            'End Try

        End Try
    End Sub


#Region "Métodos"

    Public Sub UbicarServicios()
        Dim servicioSA As New servicioSA

        listaServicio.Clear()
        listaServicio = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})


        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("idServicio")

        For Each i In listaServicio
            Dim dr As DataRow = dt.NewRow
            dr(0) = "GS"
            dr(1) = i.cuenta
            dr(2) = i.descripcion
            dr(3) = i.idServicio
            dt.Rows.Add(dr)

        Next
        dgvServicios.DataSource = dt
        dgvServicios.TableOptions.ListBoxSelectionMode = SelectionMode.One

        'cboServicio.DisplayMember = "descripcion"
        'cboServicio.ValueMember = "idServicio"
        'cboServicio.DataSource = listaServicio

    End Sub


    Public Function UbicarCajasHijas() As DataTable

        Dim dt As New DataTable
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("ef")
        dt.Columns.Add("pago")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("montoMN", GetType(Double))
        dt.Columns.Add("montoME", GetType(Double))
        dt.Columns.Add("total", GetType(Double))
        dt.Columns.Add("importePendiente", GetType(Decimal))
        dt.Columns.Add("vueltoMN", GetType(Decimal))
        dt.Columns.Add("vueltoME", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("idempresa", GetType(String))

        Return dt
    End Function

    Public Sub CargarCajasTipo(idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA
        Try

            cajaUsuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona})

        Catch ex As Exception

        End Try
    End Sub

    Sub cargarDatosCuentas()
        Dim cuentaUsuarioDetalleSA As New cajaUsuarioSA
        Dim objUsuario As New cajaUsuario

        objUsuario = cuentaUsuarioDetalleSA.UbicarUsuarioAbierto(usuario.IDUsuario)

        If (Not IsNothing(objUsuario)) Then
            idCajaUsuario = objUsuario.idcajaUsuario
        End If
    End Sub


    Public Sub AgregarAcanastaCodigoBarra_Index(precio As configuracionPrecioProducto, index As Integer)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = precio.precioMN
        valPUme = precio.precioME

        With productoSA.InvocarProductoID(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", index))
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "unidad", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexmn", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexme", index))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen", index))
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "almacen", index))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idEmpresa", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)

            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "codigoLote", index))
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


    End Sub

    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))

            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproducto(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen
                    dt.Rows.Add(dr)
                End If
            Next
            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try
            'DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtSerieGuia.Text = .Serie
            '        txtNumeroGuia.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                txtFecha.Value = .fechaDoc
                lblPerido.Text = .fechaPeriodo
                cboTipoDoc.SelectedValue = .tipoDocumento
                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

                        cboMoneda.SelectedValue = 1
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        cboMoneda.SelectedValue = 2
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).FirstOrDefault
                If Not IsNothing(nEntidad) Then
                    txtRuc.Text = nEntidad.nrodoc
                    txtProveedor.Tag = nEntidad.idEntidad
                    txtProveedor.Text = nEntidad.nombreCompleto
                End If

                TXTcOMPRADOR.Text = .nombrePedido

                txtTipoCambio.DecimalValue = .tipoCambio
                txtIva.DoubleValue = .tasaIgv / 100
                txtGlosa.Text = .glosa
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            PanelCanasta.Visible = False
            Panel5.Visible = False
            For Each i In objDocCompraDet.usp_EditarDetalleVenta(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG2(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub



    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim AlmacenSA As New almacenSA
        Dim entidadSA As New entidadSA
        Dim servicioSA As New servicioSA

        Dim almacen As New List(Of almacen)

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0


        UbicarServicios()

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetUbicarTablaexistencia

        'ListadoProveedores = New List(Of entidad)
        'ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)
        'cboAlmacen.DisplayMember = "descripcionAlmacen"
        'cboAlmacen.ValueMember = "idAlmacen"
        'cboAlmacen.DataSource = AlmacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)

        almacen = AlmacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacen

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("puKardex", GetType(Decimal))
        dt.Columns.Add("pukardeme", GetType(Decimal))
        dt.Columns.Add("canDisponible", GetType(Decimal))
        dt.Columns.Add("costoMN", GetType(Decimal))
        dt.Columns.Add("costoME", GetType(Decimal))
        dt.Columns.Add("tipoPrecio", GetType(String))
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("pagado", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("cantEntregar", GetType(Integer))
        dt.Columns.Add("cantPendiente", GetType(Integer))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cboprecio")
        dt.Columns.Add("codigoLote")
        dgvCompra.DataSource = dt
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
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

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
            End With
        Else
            txtProveedor.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub
    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else

            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    totalVC += CDec(r.GetValue("vcmn"))
                    totalVCme += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Exonerado
                    totalVC2 += CDec(r.GetValue("vcmn"))
                    totalVCme2 += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Inafecto
                    totalVC3 += CDec(r.GetValue("vcmn"))
                    totalVCme3 += CDec(r.GetValue("vcme"))
            End Select



            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select




        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************
        If cboMoneda.SelectedValue = 1 Then
            txtTotalBase3.DecimalValue = totalVC3
            txtTotalBase2.DecimalValue = totalVC2
            txtTotalBase.DecimalValue = totalVC
            txtTotalIva.DecimalValue = totalIVA
            txtTotalPagar2.DecimalValue = total
            DigitalGauge2.Value = total
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar2.DecimalValue = totalme
            DigitalGauge2.Value = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


    End Sub

    Public Sub UbicarUltimosPreciosServicio(intIdServicio As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdServicio)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)

        Next
        'dgvPreciosServicio.DataSource = dt
        'dgvPreciosServicio.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub Calculos()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") > 0) Then
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        colCostoMN = (colcantidad * colPrecUnitAlmacen)
                        colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                        totalMN = (colcantidad * colPrecUnit)
                        totalME = (colcantidad * colPrecUnitme)

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                        Else
                            valPercepMN = 0
                            valPercepME = 0
                        End If

                        '****************************************************************
                        Dim iva As Decimal = TmpIGV / 100

                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                            'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        End Select
                        TotalTalesXcolumna()
                    Else
                        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)

                        If (ToolStripComboBox2.Text = "TOTAL") Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", colcantidad)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", colcantidad)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                        End If

                        txtTotalBase.Text = 0.0
                        txtTotalBase2.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar2.Text = 0.0
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                Else
                    lblEstado.Text = "La cantidad debe ser mayor a cero"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If

                'colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                'cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                ''colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                ''colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                'colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                'colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                'colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")


                'colCostoMN = 0 ' Math.Round(colcantidad * colPrecUnitAlmacen, 2)
                'colCostoME = 0 ' Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

                'totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' Math.Round(colcantidad * colPrecUnit, 2)
                'totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' Math.Round(colcantidad * colPrecUnitme, 2)

                'colCostoMN = (colcantidad * colPrecUnitAlmacen)
                'colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                'totalMN = (colcantidad * colPrecUnit)
                'totalME = (colcantidad * colPrecUnitme)

                'If colDestinoGravado = 1 Then
                '    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                '    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                'Else
                '    valPercepMN = 0
                '    valPercepME = 0
                'End If

                ''****************************************************************
                'Dim iva As Decimal = TmpIGV / 100

                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                'If colcantidad > 0 Then

                '    colBI = (totalMN / (iva + 1))
                '    colBIme = (totalME / (iva + 1))

                '    Dim iv As Decimal = 0
                '    Dim iv2 As Decimal = 0
                '    iv = totalMN / (iva + 1)
                '    iv2 = totalME / (iva + 1)

                '    Igv = iv * (iva)
                '    IgvME = iv2 * (iva)

                '    'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                '    'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                'Else
                '    colBI = 0
                '    colBIme = 0
                '    Igv = 0
                '    IgvME = 0
                'End If


                ''****************************************************************

                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                'If colcantidad > 0 Then



                '    'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                '    'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                'Else

                'End If

                'If (ToolStripComboBox2.Text = "TOTAL") Then
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", colcantidad)
                'Else
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                'End If


                'Select Case colDestinoGravado
                '    Case 1
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                '    Case 2
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                'End Select
                'TotalTalesXcolumna()

            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") > 0) Then
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        colCostoMN = (colcantidad * colPrecUnitAlmacen)
                        colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                        totalMN = (colcantidad * colPrecUnit)
                        totalME = (colcantidad * colPrecUnitme)

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                        Else
                            valPercepMN = 0
                            valPercepME = 0
                        End If

                        '****************************************************************
                        Dim iva As Decimal = TmpIGV / 100

                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                            'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        End Select
                        TotalTalesXcolumna()
                    Else
                        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)

                        If (ToolStripComboBox2.Text = "TOTAL") Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", colcantidad)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", colcantidad)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                        End If

                        txtTotalBase.Text = 0.0
                        txtTotalBase2.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar2.Text = 0.0
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                Else
                    lblEstado.Text = "La cantidad debe ser mayor a cero"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If

        End Select
    End Sub

    Sub CalculosGasto()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0

        Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                'VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                'VCme = (VC / txtTipoCambio.DecimalValue)

                'colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                'cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                'colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                'colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                'colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                'colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                'colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                'colCostoMN = (colcantidad * colPrecUnitAlmacen)
                'colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                'totalMN = (colcantidad * colPrecUnit)
                'totalME = (colcantidad * colPrecUnitme)

                'If colDestinoGravado = 1 Then
                '    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                '    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                'Else
                '    valPercepMN = 0
                '    valPercepME = 0

                'End If

                ''****************************************************************
                'colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                'If colcantidad > 0 AndAlso VC > 0 Then
                '    Igv = (VC * (TmpIGV / 100))
                '    IgvME = (VCme * (TmpIGV / 100))

                '    colBI = VC + Igv + valPercepMN
                '    colBIme = VCme + IgvME + valPercepMN

                '    colPrecUnit = (VC / colcantidad)
                '    colPrecUnitme = (VCme / colcantidad)
                'ElseIf colcantidad = 0 Then
                '    Igv = (VC * (TmpIGV / 100))
                '    IgvME = (VCme * (TmpIGV / 100))
                '    colBI = VC + Igv + valPercepMN
                '    colBIme = VCme + IgvME + valPercepME
                '    colPrecUnit = 0
                '    colPrecUnitme = 0
                'Else
                '    colPrecUnit = 0
                '    colPrecUnitme = 0

                '    colBI = 0
                '    colBIme = 0
                '    Igv = 0
                '    IgvME = 0
                'End If

                'Select Case colDestinoGravado
                '    Case 1
                '        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", colBI)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                '    Case 2
                '        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", colBI)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                'End Select
                'TotalTalesXcolumna()

                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                    VCme = (VC / txtTipoCambio.DecimalValue)

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = (colcantidad * colPrecUnitAlmacen)
                    colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                    totalMN = (colcantidad * colPrecUnit)
                    totalME = (colcantidad * colPrecUnitme)

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 AndAlso VC > 0 Then
                        Igv = (VC * (TmpIGV / 100))
                        IgvME = (VCme * (TmpIGV / 100))

                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepMN

                        colPrecUnit = (VC / colcantidad)
                        colPrecUnitme = (VCme / colcantidad)
                    ElseIf colcantidad = 0 Then
                        Igv = (VC * (TmpIGV / 100))
                        IgvME = (VCme * (TmpIGV / 100))
                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepME
                        colPrecUnit = 0
                        colPrecUnitme = 0
                    Else
                        colPrecUnit = 0
                        colPrecUnitme = 0

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                    End Select
                    TotalTalesXcolumna()
                Else
                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                    txtTotalBase.Text = 0.0
                    txtTotalBase2.Text = 0.0
                    txtTotalBase3.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar2.Text = 0.0
                    DigitalGauge2.Value = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                    VCme = (VC / txtTipoCambio.DecimalValue)

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = (colcantidad * colPrecUnitAlmacen)
                    colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                    totalMN = (colcantidad * colPrecUnit)
                    totalME = (colcantidad * colPrecUnitme)

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 AndAlso VC > 0 Then
                        Igv = (VC * (TmpIGV / 100))
                        IgvME = (VCme * (TmpIGV / 100))

                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepMN

                        colPrecUnit = (VC / colcantidad)
                        colPrecUnitme = (VCme / colcantidad)
                    ElseIf colcantidad = 0 Then
                        Igv = (VC * (TmpIGV / 100))
                        IgvME = (VCme * (TmpIGV / 100))
                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepME
                        colPrecUnit = 0
                        colPrecUnitme = 0
                    Else
                        colPrecUnit = 0
                        colPrecUnitme = 0

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                    End Select
                    TotalTalesXcolumna()
                Else
                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                    txtTotalBase.Text = 0.0
                    txtTotalBase2.Text = 0.0
                    txtTotalBase3.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar2.Text = 0.0
                    DigitalGauge2.Value = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
    End Sub


    Dim precioSA As New ListadoPrecioSA
    Dim precio As New listadoPrecios

    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = GFichaUsuarios.IdCajaDestino,
              .descripcion = GFichaUsuarios.NomCajaDestinb,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

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
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If (chIdentificacion.Checked = True) Then
            nAsiento.idEntidad = Integer.Parse(0)
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        Else
            nAsiento.idEntidad = Integer.Parse(txtProveedor.Tag)
            nAsiento.nombreEntidad = txtProveedor.Text
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        nMovimiento.cuenta = "69112"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "20111"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias _
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        If (chIdentificacion.Checked = True) Then
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(0)
        Else
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.idEntidad = Integer.Parse(txtProveedor.Tag)
        End If

        ' txtIdCliente.Text

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias _
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            'MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nMovimiento = New movimiento
            nMovimiento.cuenta = "70111"
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Sub AsientoVentaServicios(listadoServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoServicios _
                    Into totalMN = Sum(n.importeMN),
                    TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.periodo = lblPerido.Text
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        If (chIdentificacion.Checked = True) Then
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(0)
        Else
            nAsiento.idEntidad = Integer.Parse(txtProveedor.Tag) ' txtIdCliente.Text
            nAsiento.nombreEntidad = txtProveedor.Text
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoServicios _
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoServicios
            nMovimiento = New movimiento
            nMovimiento.cuenta = "7041" 'i.idItem
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
       
    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Dim tipoEstado As String
    Dim TipoEntrega As String
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

        Dim TipoCobro As String

        Dim proveedor As String
        Dim idProveedor As Integer
        Dim conteoCantidad As Integer
        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.TieneCotizacion = TieneCotizacionInfo
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")

        If (chIdentificacion.Checked = True) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        Else
            ndocumento.entidad = txtProveedor.Text
            ndocumento.nrodocEntidad = txtRuc.Text
            ndocumento.idEntidad = Val(txtProveedor.Tag)
        End If

        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE

        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        Select Case ToolStripComboBox1.Text
            Case "CONTADO"
                TipoCobro = TIPO_VENTA.PAGO.COBRADO
            Case Else
                TipoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        End Select

        Select Case ToolStripComboBox2.Text
            Case "TOTAL"
                TipoEntrega = TipoEntregado.Entregado
                tipoEstado = TipoGuia.Entregado
            Case Else
                TipoEntrega = TipoEntregado.PorEntregar
                tipoEstado = TipoGuia.Pendiente
        End Select

        If (chIdentificacion.Checked = False) Then
            proveedor = txtProveedor.Text
            idProveedor = CInt(txtProveedor.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If


        nDocumentoVenta = New documentoventaAbarrotes With {
            .CajaSeleccionada = Nothing,
            .IdDocumentoCotizacion = IdDocumentoCotizacion,
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                   .terminos = ToolStripComboBox1.Text,
                  .glosa = txtGlosa.Text.Trim,
                  .fechaVcto = dptFechaVencimiento.Value,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                'Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
                '  MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                '  Exit Sub
            End If


            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
            Select Case ToolStripComboBox1.Text
                Case "CONTADO"
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End Select
            'objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = GConfiguracion.Serie
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = dptFechaVencimiento.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            If (TipoEntrega = TipoEntregado.PorEntregar) Then
                conteoCantidad = CDec(r.GetValue("cantEntregar"))
            End If


            Dim cat = r.GetValue("cat")
            If Not IsNothing(cat) Then
                If cat.ToString.Trim.Length > 0 Then
                    objDocumentoVentaDet.categoria = r.GetValue("cat")
                Else
                    objDocumentoVentaDet.categoria = Nothing
                End If
            Else
                objDocumentoVentaDet.categoria = Nothing
            End If

            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now

            'If (ToolStripComboBox2.Text = "TOTAL") Then
            '    objDocumentoVentaDet.stock = 1
            'End If

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                       Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias)
        End If

        Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle _
                                                                      Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        If listaServicios.Count > 0 Then
            AsientoVentaServicios(listaServicios)
        End If


        If (ToolStripComboBox1.Text = "CONTADO") Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCaja()
        End If

        If (ToolStripComboBox2.Text = "TOTAL" Or conteoCantidad > 0) Then
            GuiaRemision(ndocumento)
        End If

        'AsientoCobrocaja()
        Dim idDocuentoGrabado As Integer
        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            ndocumento.asiento = ListaAsientonTransito
            If (ToolStripComboBox1.Text = "CONTADO") Then
                idDocuentoGrabado = VentaSA.SaveVentaCobradaContado(ndocumento)
            Else
                idDocuentoGrabado = VentaSA.GrabarVentaGeneralCredito(ndocumento)
            End If
            If MessageBox.Show("Desea imprimir ticket", "Impresión comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ImprimirTicket(idDocuentoGrabado)
            End If
            LimpiarControles()
        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If
    End Sub

    Private Sub LimpiarControles()
        txtProveedor.Clear()
        txtRuc.Clear()
        txtSerieGuia.Clear()
        txtNumeroGuia.Clear()
        DigitalGauge2.Value = 0
        DigitalGauge2.Text = "0.00"
        txtFiltrar.Clear()
        TextBoxExt3.Clear()
        dgvCompra.DataSource = New DataTable
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        lblTotalPercepcion.DecimalValue = 0
        txtTotalPagar2.DecimalValue = 0
        TXTcOMPRADOR.Clear()
        frmCajasXusuario.txtTipoDoc.Clear()
        frmCajasXusuario.txtSerie.Clear()
        frmCajasXusuario.txtNumero.Clear()
        frmCajasXusuario.txtCliente.Clear()
        frmCajasXusuario.txtRuc.Clear()
        frmCajasXusuario.DigitalGauge2.Value = 0
        frmCajasXusuario.DigitalGauge2.Text = "0.00"
        frmCajasXusuario.dgvPagos.DataSource = New DataTable
        frmCajasXusuario.txtTotalBase.DecimalValue = 0
        frmCajasXusuario.txtRetencion.DecimalValue = 0
        frmCajasXusuario.txtTotalIva.DecimalValue = 0
        GridGroupingControl2.DataSource = New DataTable
        GetTableGrid()
    End Sub

    Function ListaDocumentoCaja() As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In gridCaja.Table.Records
            If CDbl(i.GetValue("montoMN") > 0) Then
                nDocumentoCaja = New documento
                'DOCUMENTO
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.nroDoc = GConfiguracion.Serie
                nDocumentoCaja.idOrden = Nothing
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        nDocumentoCaja.moneda = 1
                    Case "EXTRANJERO"
                        nDocumentoCaja.moneda = 2
                End Select

                If (chIdentificacion.Checked = True) Then
                    nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                    nDocumentoCaja.nrodocEntidad = 0
                    nDocumentoCaja.idEntidad = Val(0)
                Else
                    nDocumentoCaja.idEntidad = Val(txtProveedor.Tag)
                    nDocumentoCaja.entidad = txtProveedor.Text
                    nDocumentoCaja.nrodocEntidad = txtRuc.Text
                End If


                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE

                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = lblPerido.Text
                If txtProveedor.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = lblNumeroDoc
                End If
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                If txtProveedor.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtProveedor.Tag
                End If
                objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                objCaja.NumeroDocumento = GConfiguracion.Serie
                objCaja.numeroOperacion = i.GetValue("numOper")
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
                objCaja.montoSoles = Decimal.Parse(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                        objCaja.tipoCambio = TmpTipoCambio
                        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles * TmpTipoCambio)
                    Case "EXTRANJERO"
                        objCaja.moneda = 2
                        objCaja.tipoCambio = i.GetValue("tipocambio")
                        objCaja.montoUsd = Decimal.Parse(i.GetValue("montoME"))
                End Select


                objCaja.estado = "P"
                objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = usuario.IDUsuario
                objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                objCaja.NombreEntidad = (i.GetValue("ef"))
                objCaja.fechaModificacion = DateTime.Now

                'vuelto ticket
                'vueltoMN = CDec(i.GetValue("vueltoMN"))
                'vueltoME = CDec(i.GetValue("vueltoME"))

                nDocumentoCaja.documentoCaja = objCaja
                ListaDoc.Add(nDocumentoCaja)
                ListaDetalleCaja(nDocumentoCaja.documentoCaja)
                asientoDocumento(nDocumentoCaja.documentoCaja)
            End If
        Next

        Return ListaDoc
    End Function


    Sub asientoDocumento(doc As documentoCaja)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransito(doc.montoSoles, doc.montoUsd)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = TXTcOMPRADOR.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub


    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If doc.NombreEntidad = i.SubItems(1).Text Then
                obj = New documentoCajaDetalle
                obj.fecha = Date.Now
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = FormatNumber(Decimal.Parse(i.SubItems(4).Text), 2) 'CDbl(i.SubItems(4).Text)
                obj.montoUsd = FormatNumber(Decimal.Parse(i.SubItems(5).Text), 2) ' CDbl(i.SubItems(5).Text)

                Select Case doc.moneda
                    Case 1
                        obj.diferTipoCambio = TmpTipoCambio
                        obj.tipoCambioTransacc = TmpTipoCambio
                    Case 2
                        obj.diferTipoCambio = doc.tipoCambio
                        obj.tipoCambioTransacc = doc.tipoCambio
                End Select


                obj.entregado = "SI"
                obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                obj.usuarioModificacion = usuario.IDUsuario
                obj.documentoAfectado = CInt(Me.Tag)
                obj.fechaModificacion = DateTime.Now
                lista.Add(obj)
            End If
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Sub AddSubitemPago(i As Record, valMN As Double, venta As Record)
        Dim oreg As New ListViewItem
        Dim tipoCambio As Decimal

        oreg = lsvPagosRegistrados.Items.Add(i.GetValue("pago"))
        oreg.SubItems.Add(i.GetValue("ef"))
        oreg.SubItems.Add(venta.GetValue("idProducto"))
        oreg.SubItems.Add(venta.GetValue("item"))
        oreg.SubItems.Add(valMN)
        tipoCambio = i.GetValue("tipocambio")
        'total = valMN / tipoCambi
        If (tipoCambio = 0) Then
            oreg.SubItems.Add((CDec(valMN / TmpTipoCambio)))
        Else

            oreg.SubItems.Add((CDec(valMN / tipoCambio)))
        End If

    End Sub


    Sub CalculosSubpago(r As Record) 'row de pagos de cuentas financieras
        Dim pago As Decimal = CType((r.GetValue("montoMN")), Decimal)
        'Dim pagoME As Double = CType(r.GetValue("montoME"), Double)
        'Dim pagoME As Double
        'Dim valVenta As Double = 0
        Dim saldo As Double = 0
        'Dim saldoME As Double = 0

        Dim saldoPago As Double = 0
        'Dim saldoPagoME As Double = 0

        For Each i In dgvCompra.Table.Records
            Dim saldoGeneral As Double = i.GetValue("pagado") '+ saldoPago
            'Dim saldoGeneralME As Double = i.GetValue("pagadoME") '+ saldoPago

            If i.GetValue("estado") = "NO" Then

                If pago <= 0 Then
                    i.SetValue("estado", "NO")
                    i.SetValue("pagado", CType(i.GetValue("totalmn"), Double))
                    'i.SetValue("pagadoME", CType(i.GetValue("totalme"), Double))
                    Exit For
                End If

                If saldoGeneral >= pago Then
                    AddSubitemPago(r, pago, i)
                Else
                    AddSubitemPago(r, saldoGeneral, i)
                End If

                If pago >= saldoGeneral Then
                    i.SetValue("estado", "SI")
                    'pago = pago - saldoGeneral
                Else
                    i.SetValue("estado", "NO")
                    'pago = pago - saldoGeneral
                End If

                saldoPago = saldoGeneral - pago
                'saldoPagoME = saldoGeneralME - pagoME

                saldo = saldoGeneral - pago
                'saldoME = saldoGeneralME - pagoME

                If saldo <= 0 Then
                    'i.SetValue("estado", "SI")
                    i.SetValue("pagado", 0)
                    'i.SetValue("pagadoME", 0)
                Else
                    'i.SetValue("estado", "NO")
                    If saldo.ToString.Length > 3 Then
                        i.SetValue("pagado", (saldo))
                        'i.SetValue("pagadoME", Math.Round(saldoME, 2))
                    Else
                        i.SetValue("pagado", saldo)
                        'i.SetValue("pagadoME", saldoME)
                    End If
                End If

                pago = pago - saldoGeneral
                'pagoME = (pago * txtTipoCambio.Value)
            End If
        Next
    End Sub

    'Sub UpdateVenta()
    '    Dim VentaSA As New documentoVentaAbarrotesSA
    '    Dim ndocumento As New documento()
    '    Dim DocCaja As New documento

    '    Dim ListaTotales As New List(Of totalesAlmacen)
    '    Dim ListaDeleteEO As New List(Of totalesAlmacen)

    '    Dim nDocumentoVenta As New documentoventaAbarrotes()
    '    Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    Dim asientoSA As New AsientoSA
    '    ' Dim ListaAsiento As New List(Of asiento)
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento

    '    Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
    '    With ndocumento
    '        .Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        .idDocumento = lblIdDocumento.Text
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idProyecto = GProyectos.IdProyectoActividad
    '        End If
    '        .tipoDoc = GConfiguracion.TipoComprobante
    '        .fechaProceso = fecha
    '        .nroDoc = txtSerie & "-" & NumeroComprobante
    '        .idOrden = Nothing ' Me.IdOrden
    '        .tipoOperacion = "01"
    '        .usuarioActualizacion = "NN"
    '        .fechaActualizacion = DateTime.Now
    '    End With

    '    With nDocumentoVenta
    '        .idDocumento = lblIdDocumento.Text
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idPadre = GProyectos.IdProyectoActividad
    '        End If
    '        .TipoDocNumeracion = Nothing
    '        .codigoLibro = "8"
    '        .tipoDocumento = txtIdComprobante
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idEstablecimiento = GEstableciento.IdEstablecimiento
    '        .fechaDoc = fecha ' PERIODO
    '        .fechaPeriodo = PeriodoGeneral
    '        .serie = txtSerie
    '        .numeroDoc = NumeroComprobante
    '        .nombrePedido = txtCliente.Text
    '        ' .nombrePedido = txtPedidoRef.Text
    '        .moneda = IIf(cboMoneda.SelectedValue, "1", "2")
    '        .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
    '        .tipoCambio = txtTipoCambio.Value

    '        '****************** DESTINO EN SOLES ************************************************************************
    '        .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
    '        .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

    '        .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
    '        .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

    '        .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
    '        .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

    '        .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
    '        .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

    '        '****************************************************************************************************************

    '        '****************** DESTINO EN DOLARES ************************************************************************
    '        .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
    '        .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

    '        .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
    '        .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

    '        .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
    '        .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

    '        .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
    '        .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

    '        '****************************************************************************************************************
    '        .ImporteNacional = IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
    '        .ImporteExtranjero = IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

    '        .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET
    '        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
    '        .glosa = GlosaVenta()
    '        '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
    '        ' = TIPO_VENTA.VENTA_PAGADA
    '        ' .DocumentoSustentado = "S"
    '        .usuarioActualizacion = usuario.idusuario
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    ndocumento.documentoventaAbarrotes = nDocumentoVenta

    '    For Each i As DataGridViewRow In dgvNuevoDoc.Rows

    '        Dim almacenSA As New almacenSA
    '        objDocumentoVentaDet = New documentoventaAbarrotesDet
    '        objDocumentoVentaDet.idDocumento = lblIdDocumento.Text
    '        objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
    '        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.FechaDoc = fecha

    '        objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
    '        objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
    '        objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
    '        objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
    '        objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
    '        objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
    '        objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
    '        objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
    '        objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
    '        objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
    '        objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
    '        objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
    '        objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
    '        objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
    '        objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
    '        objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
    '        objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())

    '        objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
    '        objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())
    '        objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
    '        objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
    '        '**********************************************************************************
    '        objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
    '        objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
    '        objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
    '        objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
    '        '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
    '        objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
    '        '**********************************************************************************
    '        objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
    '        objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
    '        objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

    '        objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)
    '        objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)

    '        objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
    '        objDocumentoVentaDet.usuarioModificacion = usuario.idusuario
    '        objDocumentoVentaDet.fechaModificacion = Date.Now
    '        objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
    '        If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
    '        ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
    '        End If

    '        objDocumentoVentaDet.Glosa = GlosaVenta()

    '        ListaDetalle.Add(objDocumentoVentaDet)
    '        '   End If
    '    Next

    '    ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
    '    'TOTALES ALMACEN
    '    ListaTotales = ListaTotalesAlmacen()
    '    ListaDeleteEO = ListaDeleteTotales()
    '    'DocCaja = ComprobanteCaja()

    '    VentaSA.UpdateVentaTicket(ndocumento, ListaTotales, ListaDeleteEO)
    '    lblEstado.Text = "venta modificada!"
    '    lblEstado.Image = My.Resources.ok4

    '    Dispose()
    'End Sub

    Private Sub AsientoItemPagado()
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaSa As New EstadosFinancierosSA
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.periodo = lblPerido.Text
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(txtProveedor.Tag)
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "14"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "1213"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)
            Next
            ListaAsientonTransito.Add(nAsiento)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(txtProveedor.Tag)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .estado = tipoEstado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                '     If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                'If txtSerie.Text.Trim.Length > 0 Then
                objDocumentoCompra.documentoGuia.serie = GConfiguracion.Serie
                'Else
                '    Throw New Exception("Ingrese número de serie de la guía!")
                'End If
                'If txtSerie.Text.Trim.Length > 0 Then
                objDocumentoCompra.documentoGuia.numeroDoc = GConfiguracion.Serie
                'Else
                '    Throw New Exception("Ingrese el nùmero de la guía!")
                'End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idProducto")
                documentoguiaDetalle.descripcionItem = r.GetValue("item")
                documentoguiaDetalle.destino = r.GetValue("gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("cantEntregar"))

                documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                documentoguiaDetalle.nombreRecepcion = txtProveedor.Text
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

#End Region

    Private Sub frmVentaPVdirecta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub frmVentaPVdirecta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarPrecios()
        chIdentificacion.Checked = True
        'chIdentificacion.Visible = True
        lblEmpresa.Text = Gempresas.NomEmpresa
        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        lblConteo.Visible = True

        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Agregar nuevo precio")
        ContextMenuStrip.Items.Add("Ver tabla de precios")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

#End Region

#Region "Events"

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu

        Else
            dgvCompra.ContextMenuStrip = ContextMenuStrip
            'If it is not column header cell
            'dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim nuevoprecio As New configuracionPrecioProducto
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then

            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    If e.ClickedItem.Text = "Agregar nuevo precio" Then
                        Dim f As New frmNuevoPrecio
                        f.txtProducto.Tag = dgvCompra.Table.CurrentRecord.GetValue("idProducto")
                        f.txtProducto.Text = dgvCompra.Table.CurrentRecord.GetValue("item")
                        f.txtGrav.Text = dgvCompra.Table.CurrentRecord.GetValue("gravado")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                        nuevoprecio = precioSA.GetPreciosproductoMaxFecha(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idProducto")), Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("cboprecio")))

                        If Not IsNothing(precio) Then
                            dgvCompra.Table.CurrentRecord.SetValue("pumn", nuevoprecio.precioMN)
                            dgvCompra.Table.CurrentRecord.SetValue("pume", nuevoprecio.precioME)
                            Calculos()

                        Else
                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                            dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                            Calculos()
                        End If
                    ElseIf e.ClickedItem.Text = "Ver tabla de precios" Then
                        Dim f As New frmPreciosByArticulos(New detalleitems With {.codigodetalle = dgvCompra.Table.CurrentRecord.GetValue("idProducto"),
                                                           .descripcionItem = dgvCompra.Table.CurrentRecord.GetValue("item")})
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    End If

                Case Else
                    MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select

        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub gridGroupingControl1_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'GridGroupingControl2.Table.Records.DeleteAll()
        'Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            'tratamientoPago()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        Try
            If txtSerieGuia.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

                        If Len(txtSerieGuia.Text) <= 2 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

                        ElseIf Len(txtSerieGuia.Text) <= 3 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

                        ElseIf Len(txtSerieGuia.Text) <= 4 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

                        ElseIf Len(txtSerieGuia.Text) <= 5 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

                        End If
                    End If
                Else

                    txtSerieGuia.Select()
                    txtSerieGuia.Focus()
                    txtSerieGuia.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerieGuia.Select()
                txtSerieGuia.Focus()
                txtSerieGuia.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        Try
            If txtNumeroGuia.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumeroGuia.Select()
            txtNumeroGuia.Focus()
            txtNumeroGuia.Clear()
            lblEstado.Text = "Error de formato verifique el ingreso!"
        End Try
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs)
        If Not IsNothing(TotalesXcanbeceras) Then
            If cboMoneda.SelectedValue = 2 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar2.DecimalValue = TotalesXcanbeceras.TotalME
                DigitalGauge2.Value = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
            ElseIf cboMoneda.SelectedValue = 1 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar2.DecimalValue = TotalesXcanbeceras.TotalMN
                DigitalGauge2.Value = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
            End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown

        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub ObtenerCanastaVentaFiltroEmpresa(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
    '    Dim CanastaSA As New TotalesAlmacenSA
    '    Dim listaSA As New ListadoPrecioSA
    '    'Dim lista As New listadoPrecios

    '    Dim dt As New DataTable()
    '    Try



    '        dt.Columns.Add("idEmpresa", GetType(String))
    '        dt.Columns.Add("destino", GetType(String))
    '        dt.Columns.Add("idItem", GetType(Integer))
    '        dt.Columns.Add("descripcion", GetType(String))
    '        dt.Columns.Add("unidad", GetType(String))
    '        dt.Columns.Add("idPres", GetType(String))
    '        dt.Columns.Add("presentacion", GetType(String))
    '        dt.Columns.Add("cantidad", GetType(Decimal))
    '        dt.Columns.Add("puKardexmn", GetType(Decimal))
    '        dt.Columns.Add("puKardexme", GetType(Decimal))
    '        dt.Columns.Add("importeMn", GetType(Decimal))
    '        dt.Columns.Add("importeME", GetType(Decimal))
    '        dt.Columns.Add("pvmenor", GetType(Decimal))
    '        dt.Columns.Add("pvmenorme", GetType(Decimal))
    '        dt.Columns.Add("pvmayor", GetType(Decimal))
    '        dt.Columns.Add("pvmayorme", GetType(Decimal))
    '        dt.Columns.Add("pvGmayor", GetType(Decimal))
    '        dt.Columns.Add("pvGmayorme", GetType(Decimal))

    '        dt.Columns.Add("idalmacen", GetType(Integer))
    '        dt.Columns.Add("almacen", GetType(String))
    '        dt.Columns.Add("tipoExistencia", GetType(String))



    '        'ListView1.Items.Clear()
    '        Dim cprecioVentaFinalMenorMN As Decimal = 0
    '        Dim cprecioVentaFinalMenorME As Decimal = 0
    '        Dim cmontoDsctounitMenorMN As Decimal = 0
    '        Dim cmontoDsctounitMenorME As Decimal = 0
    '        Dim cprecioVentaFinalMayorMN As Decimal = 0
    '        Dim cprecioVentaFinalGMayorMN As Decimal = 0
    '        Dim cprecioVentaFinalMayorME As Decimal = 0
    '        Dim cprecioVentaFinalGMayorME As Decimal = 0
    '        Dim cdetalleMenor As String = Nothing
    '        Dim cdetalleMayor As String = Nothing
    '        Dim cdetalleGMayor As String = Nothing

    '        'se comento la bsqueda inicial de canasta de ventas
    '        'For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproductoEmpresa(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
    '        For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproductoEmpresaFull(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
    '            If CDec(i.cantidad) > 0 Then
    '                Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
    '                Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

    '                'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


    '                Dim dr As DataRow = dt.NewRow()

    '                dr(0) = i.idEmpresa

    '                dr(1) = i.origenRecaudo
    '                dr(2) = i.idItem
    '                dr(3) = i.descripcion
    '                dr(4) = i.unidadMedida
    '                dr(5) = i.Presentacion
    '                dr(6) = i.NombrePresentacion
    '                dr(7) = i.cantidad
    '                dr(8) = valPrecUnitario
    '                dr(9) = valPrecUnitarioUS
    '                dr(10) = i.importeSoles
    '                dr(11) = i.importeDolares

    '                dr(12) = cprecioVentaFinalMenorMN
    '                dr(13) = cprecioVentaFinalMenorME
    '                dr(14) = cprecioVentaFinalMayorMN
    '                dr(15) = cprecioVentaFinalMayorME
    '                dr(16) = cprecioVentaFinalGMayorMN
    '                dr(17) = cprecioVentaFinalGMayorME
    '                dr(18) = i.idAlmacen
    '                dr(19) = i.NomAlmacen
    '                dr(20) = i.tipoExistencia
    '                dt.Rows.Add(dr)
    '            End If
    '        Next
    '        gridGroupingControl1.DataSource = dt
    '        gridGroupingControl1.TableDescriptor.Relations.Clear()
    '        gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '        gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        Me.gridGroupingControl1.TableDescriptor.Columns("idEmpresa").Width = 0
    '        Me.gridGroupingControl1.TableDescriptor.Columns("tipoExistencia").Width = 40
    '        'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
    '        gridGroupingControl1.GroupDropPanel.Visible = True
    '        gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub


    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 19).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 19).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 19).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 19).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                End Select
            End If
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

        '    Select Case ColIndex
        '        Case 1 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                    Case 0
        '                        'Dim f As New frmPreciosByArticulos(r)
        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                    Case Else
        '                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                        If Not IsNothing(precio) Then
        '                            r.SetValue("pumn", precio.precioMN)
        '                            r.SetValue("pume", precio.precioME)
        '                            Calculos()
        '                        Else
        '                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            r.SetValue("pumn", 0)
        '                            r.SetValue("pume", 0)
        '                            Calculos()
        '                        End If
        '                End Select

        '            Else

        '            End If



        '        Case 7 ' cantidad
        '            'Select Case strTipoEx
        '            'Case "GS"

        '            'Case Else
        '            Dim pendiente As Integer
        '            Dim cantEntregado As Integer
        '            Select Case strTipoEx
        '                Case "GS"
        '                    Dim r As Record = dgvCompra.Table.CurrentRecord
        '                    Dim cantida = r.GetValue("cantidad")
        '                    pendiente = r.GetValue("cantidad")
        '                    cantEntregado = r.GetValue("cantEntregar")
        '                    If Not IsNothing(r) Then
        '                        r.SetValue("cantPendiente", cantida)
        '                        r.SetValue("cantEntregar", cantida)
        '                        r.SetValue("canDisponible", cantida)
        '                    End If
        '                    If (ToolStripComboBox2.Text = "TOTAL") Then
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
        '                    Else
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
        '                        'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
        '                    End If
        '                Case Else


        '                    pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
        '                    cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

        '                    If (ToolStripComboBox2.Text = "TOTAL") Then
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
        '                    Else
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
        '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
        '                        'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
        '                    End If
        '            End Select


        '            Calculos()
        '            'tratamientoPagosDefautl()


        '        Case 8
        '            Select Case strTipoEx
        '                Case "GS"
        '                    CalculosGasto()
        '                    'tratamientoPagosDefautl()
        '                Case Else

        '            End Select

        '        Case 26
        '            If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '                Dim pendiente As Integer
        '                Dim cantEntregado As Integer

        '                pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
        '                cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

        '                If (Int(pendiente > cantEntregado)) Then
        '                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente - cantEntregado)
        '                Else
        '                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
        '                    lblEstado.Text = "no debe exceder la cantidad permitido"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(10)
        '                End If

        '                If (Int(pendiente <> cantEntregado)) Then
        '                    ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
        '                End If
        '            End If
        '    End Select
        'End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If (chIdentificacion.Checked = True) Then
                If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar el nombre de comprador"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done comprador"
                End If
            Else
                If Not txtProveedor.Text.Trim.Length > 0 Then

                    MessageBox.Show("Ingrese el cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProveedor.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                If txtProveedor.Text.Trim.Length > 0 Then
                    If txtProveedor.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtProveedor.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If txtRuc.Text.Trim.Length > 0 Then
                    If txtRuc.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtRuc.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

            End If

            Dim CONTEO As Integer = 0
            For Each item In dgvCompra.Table.Records
                If (item.GetValue("cantPendiente") > 0) Then
                    CONTEO += 1
                End If
            Next

            If (CONTEO > 0) Then
                ToolStripButton2.Text = "TOTAL"
            ElseIf (CONTEO = 0) Then
                ToolStripButton2.Text = "POR ENTREGAR/PARCIAL"
            End If

            'If Not cboCuentas.Text.Trim.Length > 1 Then
            '    lblEstado.Text = "Indicar la cuenta financiera"
            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)

            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    Select Case ToolStripComboBox1.Text
                        Case "CONTADO"
                            Dim sumaPagos As Decimal = 0
                            Dim totalPago As Decimal = 0
                            For Each i In gridCaja.Table.Records
                                sumaPagos += CDec(i.GetValue("montoMN"))
                                If (i.GetValue("moneda") = "EXTRANJERO") Then
                                    If (i.GetValue("montoME") = 0) Then
                                        Throw New Exception("Debe Ingresar importe extranjero!")
                                    End If

                                End If
                            Next

                            If (sumaPagos) = DigitalGauge2.Value Then

                                'If MessageBoxAdv.Show("Desea imprimir la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                '    If dgvPagos.Table.Records.Count > 0 Then
                                '        llenarDatos()
                                '        imprimir(True)
                                '    End If
                                'End If
                                Grabar()
                                'Dispose()

                            Else
                                MessageBoxAdv.Show("Debe realizar el cobro en su integridad, no parcial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Case Else
                            Grabar()
                            'Dispose()
                    End Select

                Else
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()
                    'Else

                    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)

                    'End If

                End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de venta!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex
        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            If IsNothing(GFichaUsuarios) Then
                lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
                Exit Sub
            Else
                If style.Enabled Then
                    Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chPago")
                    ' Console.WriteLine("CheckBoxClicked")
                    '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                    If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                        chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                        e.TableControl.BeginUpdate()

                        e.TableControl.EndUpdate(True)
                    End If
                    If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                        Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        Dim curStatus As Boolean = Boolean.Parse(style.Text)
                        e.TableControl.BeginUpdate()

                        If curStatus Then
                            '   CheckBoxValue = False
                        End If
                        If curStatus = True Then
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "No Pagado"

                        Else
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "Pagado"



                        End If
                        e.TableControl.EndUpdate()
                        If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                        ElseIf Not ht.Contains(curStatus) Then
                        End If
                        ht.Clear()
                    End If
                End If
            End If


            Me.dgvCompra.TableControl.Refresh()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.Text = "TICKET BOLETA" Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
        Else
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT3", Me.Text, GEstableciento.IdEstablecimiento)
        End If
    End Sub

    'Public Sub configuracionModulo2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.NomModulo = strNomModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "TICKET BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            'GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                            txtSerie.Text = .serie
    '                            '    txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If


    '                        If cboTipoDoc.Text = "TICKET FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                            '   GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                            txtSerie.Text = .serie
    '                            '  txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If

    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            'If Not IsNothing(.configAlmacen) Then
    '            '    Dim estableSA As New establecimientoSA
    '            '    With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '            '        GConfiguracion2.IdAlmacen = .idAlmacen
    '            '        GConfiguracion2.NombreAlmacen = .descripcionAlmacen

    '            '    End With
    '            'End If
    '            'If Not IsNothing(.ConfigentidadFinanciera) Then
    '            '    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '            '        GConfiguracion2.IDCaja = .idestado
    '            '        GConfiguracion2.NomCaja = .descripcion
    '            '    End With
    '            'End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chIdentificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chIdentificacion.CheckedChanged
        If chIdentificacion.Checked = True Then
            GradientPanel7.Visible = False
            txtProveedor.Visible = False
            txtRuc.Visible = False
            PictureBox1.Visible = False
            '   Label3.Visible = False
            TXTcOMPRADOR.Visible = True
        Else
            GradientPanel7.Visible = True
            GradientPanel3.Enabled = True
            txtProveedor.Visible = True
            txtProveedor.Enabled = True
            txtProveedor.ReadOnly = False
            txtRuc.Visible = True
            PictureBox1.Visible = True
            '    Label3.Visible = False
            TXTcOMPRADOR.Visible = False
        End If
    End Sub


#Region "PRINT"
    Public Título As String = ""
    Private prtSettings As PrinterSettings
    Private prtDoc As PrintDocument
    Private ppc As New PrintPreviewControl
    Private prtFont As System.Drawing.Font
    Dim conteo As Integer = 0
    Dim datosEst As Integer = 0
    Private lineaActual As Integer
    Public fontNCabecera As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    Dim X1, X2, X3, X4, X5 As Integer
    Dim W1, W2, W3, W4, W5 As Integer
    Dim Y As Integer
    Public NCliente As String
    Dim lblIdDocreferenciaAnticipo As Integer
    Dim lblNumeroDoc As Integer
    Dim ImporteSobranteMN As Decimal
    Dim ImporteTotalMN As Decimal
    Dim ImporteTotalME As Decimal
    Dim estadoImpresion As Integer


    Sub llenarDatos()

        PrintPreviewDialogTicket.Document = PrintTikect

        'PrintPreviewDialog1.ShowDialog()

        ' La fuente a usar en la impresión
        prtFont = New System.Drawing.Font("Courier New", 11)
        '
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings

    End Sub

    Private Sub imprimir(ByVal esPreview As Boolean)

        ' imprimir o mostrar el PrintPreview
        '
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If
        '
        'If chkSelAntes.Checked Then
        If seleccionarImpresora() = False Then Return
        'End If
        '
        If prtDoc Is Nothing Then
            prtDoc = New PrintDocument
            AddHandler prtDoc.PrintPage, AddressOf prt_PrintPageSinRuc

        End If
        '
        ' resetear la línea actual
        lineaActual = 0
        '
        ' la configuración a usar en la impresión
        prtDoc.PrinterSettings = prtSettings
        '
        If esPreview Then
            Dim prtPrev As New PrintPreviewDialog
            prtPrev.PrintPreviewControl.Zoom = 1.0
            prtPrev.Document = prtDoc
            prtPrev.Text = "Previsualizar datos de Ticket" & Título
            DirectCast(prtPrev, Form).WindowState = FormWindowState.Maximized
            prtPrev.ShowDialog()
        Else
            prtDoc.Print()
        End If
    End Sub

    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        'SELECCION DE IMPRESORA
        'With prtDialog
        '    .AllowPrintToFile = False
        '    .AllowSelection = False
        '    .AllowSomePages = False
        '    .PrintToFile = False
        '    .ShowHelp = False
        '    .ShowNetwork = True

        '    .PrinterSettings = prtSettings

        '    If .ShowDialog() = DialogResult.OK Then
        '        prtSettings = .PrinterSettings
        '    Else
        '        Return False
        '    End If

        'End With
        Return (True)
    End Function
    'Public Sub prt_PrintPageSinRuc(ByVal sender As Object, _
    '                        ByVal e As PrintPageEventArgs)
    '    'mostrar si existe ruc o no
    '    Dim Ruc As String = ""
    '    ' Este evento se produce cada vez que se va a imprimir una página
    '    Dim pageWidth As Integer
    '    Dim lineHeight As Single
    '    Dim yPos As Single = e.MarginBounds.Top
    '    Dim leftMargin As Single = e.MarginBounds.Left

    '    Dim printFont As System.Drawing.Font

    '    ' Asignar el tipo de letra
    '    printFont = prtFont
    '    lineHeight = printFont.GetHeight(e.Graphics)

    '    If (lineaActual < 37 And lineaActual = 0) Then

    '        '--------------------------------------------- Encabezado del reporte -------------------------------------------
    '        Dim NEmpresa As String = Gempresas.NomEmpresa & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
    '        e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
    '                               Brushes.Black, leftMargin - 80, yPos - 100)

    '        Dim EmpresaRUC As String = "RUC  " & Gempresas.IdEmpresaRuc & vbLf
    '        Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
    '                               Brushes.Black, leftMargin - 35, yPos - 84)

    '        Dim NEstablecimiento As String = GEstableciento.NombreEstablecimiento & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEstablecimiento As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NEstablecimiento, fontNEstablecimiento, _
    '                               Brushes.Black, leftMargin - 40, yPos - 70)

    '        Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        e.Graphics.DrawString(NLinea, fontNLinea, _
    '                               Brushes.Black, leftMargin - 100, yPos - 60)

    '        '-----------------------------------------------------------------------------------------------------------------
    '        '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
    '        ' titulo 2 ubicacion de la hoja
    '        '10 masrgen a la izquierda
    '        ' ypos ubicacion hacia abajo del titulo primero

    '        If chIdentificacion.Checked = False Then

    '            Select Case estadoImpresion
    '                Case 1
    '                    NCliente = vbCrLf & vbCrLf & "Comprador: " & TXTcOMPRADOR.Text.Trim & _
    '                       vbCrLf & "ID: " & Me.Tag & "                         Nro Doc: " & String.Concat(txtSerie.Text, "-", "1") & _
    '                       vbCrLf & "RUC: " & txtRuc.Text & _
    '                       vbCrLf & "Razón Social: " & txtCliente.Text & _
    '                       vbCrLf & "Código máquina registradora: " & "MAQ-41-4" & _
    '                       vbCrLf & "Caja: " & Nothing & _
    '                       vbCrLf & "Fecha: " & txtFecha.Value & _
    '                       vbCrLf & "------------------------------------------------------------"
    '                Case Else
    '                    NCliente = vbCrLf & vbCrLf & "Comprador: " & TXTcOMPRADOR.Text & _
    '                  vbCrLf & "ID: " & Me.Tag & "                         Nro Doc: " & String.Concat(txtSerie.Text, "-", "1") & _
    '                  vbCrLf & "RUC: " & txtRuc.Text & _
    '                  vbCrLf & "Razón Social: " & txtCliente.Text & _
    '                  vbCrLf & "Código máquina registradora: " & _
    '                  vbCrLf & "Caja: " & String.Empty & _
    '                  vbCrLf & "Fecha: " & Date.Now & _
    '                  vbCrLf & "------------------------------------------------------------"

    '            End Select


    '            Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '            e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 77)

    '            'margen a la derecha de toda la lista
    '            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '            With PrintTikect.DefaultPageSettings
    '                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '                If .Landscape Then
    '                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '                End If
    '            End With
    '            'tamaño de la primera celda cantidad
    '            X2 = X1 + 17
    '            'tamaño de la segunda celda
    '            X3 = CInt(X2 + pageWidth * 3)

    '            X4 = X1 + 5
    '            X5 = X1 + 20

    '            W1 = (X2 - X1)
    '            W2 = (X3 - X2)
    '            W4 = (X3 - X2)
    '            W5 = (X3 - X2)
    '            W3 = pageWidth - W1 - W2

    '            'If itm < lsvDetalle.Items.Count Then
    '            'ubicacion para abajo
    '            Y = PrintTikect.DefaultPageSettings.Margins.Top + 50
    '            Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '            ' Draw the column headers at the top of the page
    '            'ubicacion de las columnas para la izquierda
    '            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '            ' Advance the Y coordinate for the first text line on the printout
    '            Y = Y + 20
    '            'End If
    '            Dim ii As Integer = 0
    '            Dim ultimaFila As Integer = 0

    '            For Each i As Record In dgvCompra.Table.Records

    '                ' extract each item's text into the str variable
    '                Dim str As String
    '                str = (CDbl(i.GetValue("cantidad")))

    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '                str = i.GetValue("item")
    '                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '                Dim lines, cols As Integer
    '                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '                Dim subitm As Integer, Yc As Integer
    '                Yc = Y

    '                str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '                Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '                str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '                Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '                Dim conteo As Integer

    '                For subitm = 1 To 1
    '                    str = i.GetValue("idProducto")
    '                    'str = i.SubItems(subitm).Text
    '                    'conteo = 0
    '                    conteo = (str.Length / 2)
    '                    Dim strformat As New StringFormat
    '                    strformat.Trimming = StringTrimming.EllipsisCharacter
    '                    Yc = Yc + fontNCabecera.Height + 2
    '                Next
    '                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '                Y = Math.Max(Y, Yc)

    '                With PrintTikect.DefaultPageSettings
    '                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '                        e.HasMorePages = True
    '                        ii += 1
    '                        Exit Sub
    '                    Else
    '                        ii += 1
    '                        e.HasMorePages = False
    '                    End If
    '                End With

    '            Next
    '            Dim sumaPagos As Double = 0
    '            Dim NIgv As String = vbCrLf & vbCrLf & "IGV:   " & TotalesXcanbeceras.IgvMN
    '            Dim fontNIgv As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 75, Y - 20)

    '            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
    '            Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

    '            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total a Pagar S/: " & TotalesXcanbeceras.TotalMN
    '            Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 32, Y)

    '            'For Each i In dgvPagos.Table.Records
    '            'sumaPagos += CDbl(i.GetValue("montoMN"))
    '            sumaPagos = TotalesXcanbeceras.TotalMN
    '            'Next

    '            Dim NTotalImpPagar As String = vbCrLf & vbCrLf & "Importe Pagado S/: " & sumaPagos
    '            Dim fontNTotalImpPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalImpPagar, fontNTotalImpPagar, Brushes.Black, leftMargin + 20, Y + 10)

    '            Dim NTotalVuelto As String = vbCrLf & vbCrLf & "Vuelto S/: " & ""
    '            Dim fontNNTotalVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalVuelto, fontNNTotalVuelto, Brushes.Black, leftMargin + 62, Y + 20)

    '            Dim NLinea2 As String = "----------------------------------------------------------------"
    '            Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)


    '            Select Case estadoImpresion
    '                Case 1
    '                    Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & usuario.CustomUsuario.Nombres
    '                    Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
    '                Case Else
    '                    Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & usuario.CustomUsuario.Nombres
    '                    Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
    '            End Select

    '            'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
    '            'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
    '            'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

    '            e.HasMorePages = False

    '        ElseIf chIdentificacion.Checked = True Then

    '            Select Case estadoImpresion
    '                Case 1
    '                    NCliente = vbCrLf & vbCrLf & "Cliente: " & TXTcOMPRADOR.Text & _
    '                  vbCrLf & "ID: " & Me.Tag & "                         Nro Doc: " & String.Concat(txtSerie.Text, "-", "1") & _
    '                  vbCrLf & "Código máquina registradora: " & "MX7S-4154" & _
    '                  vbCrLf & "Caja: " & Nothing & _
    '                  vbCrLf & "Fecha: " & txtFecha.Value & _
    '                  vbCrLf & "------------------------------------------------------------"
    '                Case Else
    '                    NCliente = vbCrLf & vbCrLf & "Cliente: " & TXTcOMPRADOR.Text & _
    '                     vbCrLf & "ID: " & Me.Tag & "                         Nro Doc: " & String.Concat(txtSerie.Text, "-", "1") & _
    '                     vbCrLf & "Código máquina registradora: " & _
    '                     vbCrLf & "Caja: " & String.Empty & _
    '                     vbCrLf & "Fecha: " & Date.Now & _
    '                     vbCrLf & "------------------------------------------------------------"
    '            End Select

    '            Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '            e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 77)

    '            'margen a la derecha de toda la lista
    '            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '            With PrintTikect.DefaultPageSettings
    '                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '                If .Landscape Then
    '                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '                End If
    '            End With
    '            'tamaño de la primera celda cantidad
    '            X2 = X1 + 17
    '            'tamaño de la segunda celda
    '            X3 = CInt(X2 + pageWidth * 3)

    '            X4 = X1 + 5
    '            X5 = X1 + 20

    '            W1 = (X2 - X1)
    '            W2 = (X3 - X2)
    '            W4 = (X3 - X2)
    '            W5 = (X3 - X2)
    '            W3 = pageWidth - W1 - W2

    '            'If itm < lsvDetalle.Items.Count Then
    '            'ubicacion para abajo
    '            Y = PrintTikect.DefaultPageSettings.Margins.Top + 25
    '            Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '            ' Draw the column headers at the top of the page
    '            'ubicacion de las columnas para la izquierda
    '            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '            ' Advance the Y coordinate for the first text line on the printout
    '            Y = Y + 20
    '            'End If
    '            Dim ii As Integer = 0
    '            Dim ultimaFila As Integer = 0
    '            For Each i As Record In dgvCompra.Table.Records

    '                ' extract each item's text into the str variable
    '                Dim str As String
    '                str = (CDbl(i.GetValue("cantidad")))

    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '                str = i.GetValue("item")
    '                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '                Dim lines, cols As Integer
    '                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '                Dim subitm As Integer, Yc As Integer
    '                Yc = Y

    '                str = Math.Round(CDbl(i.GetValue("totalmn") / (i.GetValue("cantidad"))), 2)
    '                Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '                str = Math.Round(CDbl(i.GetValue("totalmn")), 2)
    '                Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '                e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '                Dim conteo As Integer

    '                For subitm = 1 To 1
    '                    str = i.GetValue("idProducto")
    '                    'conteo = 0
    '                    conteo = (str.Length / 2)
    '                    Dim strformat As New StringFormat
    '                    strformat.Trimming = StringTrimming.EllipsisCharacter
    '                    Yc = Yc + fontNCabecera.Height + 2
    '                Next
    '                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '                Y = Math.Max(Y, Yc)

    '                With PrintTikect.DefaultPageSettings
    '                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '                        e.HasMorePages = True
    '                        ii += 1
    '                        Exit Sub
    '                    Else
    '                        ii += 1
    '                        e.HasMorePages = False
    '                    End If
    '                End With

    '            Next

    '            Dim sumaPagos As Double = 0
    '            Dim NIgv As String = vbCrLf & vbCrLf & "IGV:   " & TotalesXcanbeceras.IgvMN
    '            Dim fontNIgv As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 75, Y - 20)

    '            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
    '            Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

    '            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total a Pagar S/: " & TotalesXcanbeceras.TotalMN
    '            Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 32, Y)

    '            'For Each i In dgvPagos.Table.Records
    '            '    sumaPagos += CDbl(i.GetValue("montoMN"))
    '            'Next
    '            sumaPagos = TotalesXcanbeceras.TotalMN

    '            Dim NTotalImpPagar As String = vbCrLf & vbCrLf & "Importe Pagado S/: " & sumaPagos
    '            Dim fontNTotalImpPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalImpPagar, fontNTotalImpPagar, Brushes.Black, leftMargin + 20, Y + 10)

    '            Dim NTotalVuelto As String = vbCrLf & vbCrLf & "Vuelto S/: " & ""
    '            Dim fontNNTotalVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NTotalVuelto, fontNNTotalVuelto, Brushes.Black, leftMargin + 62, Y + 20)

    '            Dim NLinea2 As String = "----------------------------------------------------------------"
    '            Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)

    '            Select Case estadoImpresion
    '                Case 1
    '                    Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & usuario.CustomUsuario.Nombres
    '                    Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
    '                Case Else
    '                    Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & "Maykol sanchez coris"
    '                    Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                    e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
    '            End Select

    '            'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
    '            'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
    '            'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '            'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

    '            e.HasMorePages = False

    '        End If

    '    End If

    'End Sub

    'Public Sub prt_PrintPageSinRuc(ByVal sender As Object, _
    '                    ByVal e As PrintPageEventArgs)

    '    'mostrar si existe ruc o no
    '    Dim Ruc As String = ""
    '    ' Este evento se produce cada vez que se va a imprimir una página
    '    Dim pageWidth As Integer
    '    Dim lineHeight As Single
    '    Dim yPos As Single = e.MarginBounds.Top
    '    Dim leftMargin As Single = e.MarginBounds.Left

    '    Dim printFont As System.Drawing.Font

    '    ' Asignar el tipo de letra
    '    printFont = prtFont
    '    lineHeight = printFont.GetHeight(e.Graphics)

    '    If (lineaActual < 37 And lineaActual = 0) Then

    '        '--------------------------------------------- Encabezado del reporte -------------------------------------------
    '        Dim NEmpresa As String = Gempresas.NomEmpresa & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
    '        e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
    '                               Brushes.Black, leftMargin - 60, yPos - 100)

    '        Dim EmpresaRUC As String = "RUC  " & Gempresas.IdEmpresaRuc & vbLf
    '        Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
    '                               Brushes.Black, leftMargin - 50, yPos - 85)

    '        Dim NDireccion As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NDireccion, fontNDireccion, _
    '                               Brushes.Black, leftMargin - 100, yPos - 70)

    '        Dim NNumeroComprobante As String = "3159000 - 3142020" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNNumeroComprobante As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NNumeroComprobante, fontNNumeroComprobante, _
    '                               Brushes.Black, leftMargin - 50, yPos - 55)


    '        Dim NBoletaElectronica As String = "BOLETA ELECTRONICA" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica, _
    '                               Brushes.Black, leftMargin - 60, yPos - 40)

    '        Dim NNumeroBoleta As String = "B625 - 0238791" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNNumeroBoleta As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NNumeroBoleta, fontNNumeroBoleta, _
    '                               Brushes.Black, leftMargin - 40, yPos - 25)


    '        Dim NEstablecimiento As String = GEstableciento.NombreEstablecimiento & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEstablecimiento As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NEstablecimiento, fontNEstablecimiento, _
    '                               Brushes.Black, leftMargin - 100, yPos + 0)


    '        Dim NDireccionEstab As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNDireccionEstab As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NDireccionEstab, fontNDireccionEstab, _
    '                               Brushes.Black, leftMargin - 100, yPos + 12)

    '        Dim NLugar As String = "CHILCA - HUANCAYO" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNLugar As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(NLugar, fontNLugar, _
    '                               Brushes.Black, leftMargin - 100, yPos + 25)


    '        '-----------------------------------------------------------------------------------------------------------------
    '        '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
    '        ' titulo 2 ubicacion de la hoja
    '        '10 masrgen a la izquierda
    '        ' ypos ubicacion hacia abajo del titulo primero

    '        'If (TipoTicket = "ConRUC") Then

    '        Dim moneda As String = ""

    '        Select Case cboMoneda.SelectedValue
    '            Case 2
    '                moneda = "EXTRANJERA"
    '            Case 1
    '                moneda = "NACIONAL"
    '        End Select

    '        Select Case estadoImpresion
    '            Case 1
    '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                   vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '                   vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                   vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
    '                   vbCrLf & "------------------------------------------------------------"
    '            Case Else
    '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '                vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                vbCrLf & "TIPO MONEDA: " & moneda & _
    '                vbCrLf & "------------------------------------------------------------"

    '        End Select


    '        Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '        e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos + 20)


    '        'Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        'e.Graphics.DrawString(NLinea, fontNLinea, _
    '        '                       Brushes.Black, leftMargin - 100, yPos + 10)

    '        'margen a la derecha de toda la lista
    '        X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '        With PrintTikect.DefaultPageSettings
    '            pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '            If .Landscape Then
    '                pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '            End If
    '        End With
    '        'tamaño de la primera celda cantidad
    '        X2 = X1 + 17
    '        'tamaño de la segunda celda
    '        X3 = CInt(X2 + pageWidth * 3)

    '        X4 = X1 + 5
    '        X5 = X1 + 20

    '        W1 = (X2 - X1)
    '        W2 = (X3 - X2)
    '        W4 = (X3 - X2)
    '        W5 = (X3 - X2)
    '        W3 = pageWidth - W1 - W2

    '        'If itm < lsvDetalle.Items.Count Then
    '        'ubicacion para abajo
    '        Y = PrintTikect.DefaultPageSettings.Margins.Top + 115
    '        Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        ' Draw the column headers at the top of the page
    '        'ubicacion de las columnas para la izquierda
    '        e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '        e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '        e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '        e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '        ' Advance the Y coordinate for the first text line on the printout
    '        Y = Y + 20
    '        'End If
    '        Dim ii As Integer = 0
    '        Dim ultimaFila As Integer = 0

    '        For Each i As Record In dgvCompra.Table.Records

    '            ' extract each item's text into the str variable
    '            Dim str As String
    '            str = (CDbl(i.GetValue("cantidad")))

    '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '            str = i.GetValue("item")
    '            Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '            Dim lines, cols As Integer
    '            e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '            Dim subitm As Integer, Yc As Integer
    '            Yc = Y

    '            str = Math.Round(CDec(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '            Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '            str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '            Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '            Dim conteo As Integer

    '            For subitm = 1 To 1
    '                str = i.GetValue("idProducto")
    '                'str = i.SubItems(subitm).Text
    '                'conteo = 0
    '                conteo = (str.Length / 2)
    '                Dim strformat As New StringFormat
    '                strformat.Trimming = StringTrimming.EllipsisCharacter
    '                Yc = Yc + fontNCabecera.Height + 2
    '            Next
    '            Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '            Y = Math.Max(Y, Yc)

    '            With PrintTikect.DefaultPageSettings
    '                If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '                 (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '                    e.HasMorePages = True
    '                    ii += 1
    '                    Exit Sub
    '                Else
    '                    ii += 1
    '                    e.HasMorePages = False
    '                End If
    '            End With

    '        Next

    '        Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
    '        Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


    '        'Dim sumaPagos As String
    '        'Dim NIgv As String = vbCrLf & vbCrLf & "Redo S/.           " & CDec(0.0)
    '        'Dim fontNIgv As New System.Drawing.Font("Tahoma", 4, FontStyle.Regular)
    '        'e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 40, Y - 0)

    '        'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
    '        'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

    '        Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total    S/.       " & DigitalGauge2.Value
    '        Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y - 0)

    '        'For Each i In dgvPagos.Table.Records
    '        '    sumaPagos += CDbl(i.GetValue("montoMN"))
    '        'Next

    '        Dim cobroMn As Decimal
    '        Dim cobroME As Decimal
    '        Dim vueltoMN As Decimal
    '        Dim vueltoME As Decimal

    '        For Each item As Record In dgvPagos.Table.Records
    '            cobroMn += item.GetValue("importePendiente")
    '            vueltoMN += item.GetValue("vueltoMN")
    '            vueltoME += item.GetValue("vueltoME")
    '        Next


    '        Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(txtTotalBase.DecimalValue)
    '        Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '        Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(txtTotalBase2.DecimalValue)
    '        Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '        Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(txtTotalBase3.DecimalValue)
    '        Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '        Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                          " & CDec(txtTotalIva.DecimalValue)
    '        Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '        Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                                     " & CDec(lblTotalPercepcion.DecimalValue)
    '        Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 95)

    '        Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                                      " & CDec(0.0)
    '        Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 110)

    '        Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(DigitalGauge2.Value)
    '        Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 125)

    '        Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                           " & CDec(cobroMn)
    '        Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 140)

    '        Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                          " & CDec(vueltoMN)
    '        Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 155)


    '        'Dim NLinea2 As String = "----------------------------------------------------------------"
    '        'Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        'e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)



    '        Select Case estadoImpresion
    '            Case 1
    '                'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & DigitalGauge2.Value & " CON 00/100 Soles"
    '                'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '                'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & cobroMn & " (Soles)"
    '                'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '                'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '                'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '                'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "Maykol"
    '                'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '                Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 170)
    '            Case Else
    '                'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & DigitalGauge2.Value & " CON 00/100 Soles"
    '                'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '                'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & cobroMn & " (Soles)"
    '                'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '                'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '                'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '                'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '                'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '                Dim NVendedor As String = vbCrLf & vbCrLf & "COMPRADOR: " & TXTcOMPRADOR.Text
    '                Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 170)
    '        End Select

    '        'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
    '        'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
    '        'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

    '        e.HasMorePages = False

    '        '    ElseIf (TipoTicket = "SinRUC") Then

    '        '        Select Case estadoImpresion
    '        '            Case 1
    '        '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '        '                   vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '        '                   vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '        '                   vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
    '        '                   vbCrLf & "------------------------------------------------------------"
    '        '            Case Else
    '        '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '        '                vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '        '                vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '        '                vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
    '        '                vbCrLf & "------------------------------------------------------------"

    '        '        End Select


    '        '        Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos + 20)


    '        '        'Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '        '        ''separacion del primer titulo con la segunda linea
    '        '        'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        '        'e.Graphics.DrawString(NLinea, fontNLinea, _
    '        '        '                       Brushes.Black, leftMargin - 100, yPos + 10)

    '        '        'margen a la derecha de toda la lista
    '        '        X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '        '        With PrintTikect.DefaultPageSettings
    '        '            pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '        '            If .Landscape Then
    '        '                pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '        '            End If
    '        '        End With
    '        '        'tamaño de la primera celda cantidad
    '        '        X2 = X1 + 17
    '        '        'tamaño de la segunda celda
    '        '        X3 = CInt(X2 + pageWidth * 3)

    '        '        X4 = X1 + 5
    '        '        X5 = X1 + 20

    '        '        W1 = (X2 - X1)
    '        '        W2 = (X3 - X2)
    '        '        W4 = (X3 - X2)
    '        '        W5 = (X3 - X2)
    '        '        W3 = pageWidth - W1 - W2

    '        '        'If itm < lsvDetalle.Items.Count Then
    '        '        'ubicacion para abajo
    '        '        Y = PrintTikect.DefaultPageSettings.Margins.Top + 115
    '        '        Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        '        ' Draw the column headers at the top of the page
    '        '        'ubicacion de las columnas para la izquierda
    '        '        e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '        '        e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '        '        e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '        '        e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '        '        ' Advance the Y coordinate for the first text line on the printout
    '        '        Y = Y + 20
    '        '        'End If
    '        '        Dim ii As Integer = 0
    '        '        Dim ultimaFila As Integer = 0

    '        '        For Each i As Record In dgvPagos.Table.Records

    '        '            ' extract each item's text into the str variable
    '        '            Dim str As String
    '        '            str = (CDbl(i.GetValue("cantidad")))

    '        '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '        '            str = i.GetValue("item")
    '        '            Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '        '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '        '            Dim lines, cols As Integer
    '        '            e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '        '            Dim subitm As Integer, Yc As Integer
    '        '            Yc = Y

    '        '            str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '        '            Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '        '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '        '            str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '        '            Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '        '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '        '            Dim conteo As Integer

    '        '            For subitm = 1 To 1
    '        '                str = i.GetValue("idProducto")
    '        '                'str = i.SubItems(subitm).Text
    '        '                'conteo = 0
    '        '                conteo = (str.Length / 2)
    '        '                Dim strformat As New StringFormat
    '        '                strformat.Trimming = StringTrimming.EllipsisCharacter
    '        '                Yc = Yc + fontNCabecera.Height + 2
    '        '            Next
    '        '            Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '        '            Y = Math.Max(Y, Yc)

    '        '            With PrintTikect.DefaultPageSettings
    '        '                If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '        '                 (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '        '                    e.HasMorePages = True
    '        '                    ii += 1
    '        '                    Exit Sub
    '        '                Else
    '        '                    ii += 1
    '        '                    e.HasMorePages = False
    '        '                End If
    '        '            End With

    '        '        Next

    '        '        Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
    '        '        Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


    '        '        'Dim sumaPagos As String
    '        '        Dim NIgv As String = vbCrLf & vbCrLf & "Redo S/.           " & CDec(0.0)
    '        '        Dim fontNIgv As New System.Drawing.Font("Tahoma", 4, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 40, Y - 0)

    '        '        'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
    '        '        'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

    '        '        Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total    S/.       " & txtTotalPagar.DecimalValue
    '        '        Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y + 20)

    '        '        'For Each i In dgvPagos.Table.Records
    '        '        '    sumaPagos += CDbl(i.GetValue("montoMN"))
    '        '        'Next

    '        '        Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(txtTotalBase.DecimalValue)
    '        '        Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '        '        Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(txtTotalBase2.DecimalValue)
    '        '        Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '        '        Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(txtTotalBase3.DecimalValue)
    '        '        Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '        '        Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V.                S/.                                            " & CDec(txtTotalIva.DecimalValue)
    '        '        Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '        '        Dim NTotal As String = vbCrLf & vbCrLf & "Importe Total     S/.                                            " & CDec(txtTotalPagar.DecimalValue)
    '        '        Dim fontNTotal As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NTotal, fontNTotal, Brushes.Black, leftMargin - 100, Y + 95)
    '        '        Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo          S/.                                            " & CDec(lblTotalPercepcion.DecimalValue)
    '        '        Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 110)

    '        '        Dim NDonacion As String = vbCrLf & vbCrLf & "Donación           S/.                                            " & 0.0
    '        '        Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 125)

    '        '        Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(txtTotalPagar.DecimalValue)
    '        '        Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 140)

    '        '        'Dim NLinea2 As String = "----------------------------------------------------------------"
    '        '        'Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        'e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)


    '        '        Select Case estadoImpresion
    '        '            Case 1
    '        '                Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
    '        '                Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '        '                Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
    '        '                Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '        '                Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '        '                Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '        '                Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '        '                Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '        '                Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '        '                Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
    '        '            Case Else
    '        '                Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
    '        '                Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

    '        '                Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
    '        '                Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

    '        '                Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
    '        '                Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

    '        '                Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
    '        '                Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

    '        '                Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '        '                Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '                e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
    '        '        End Select

    '        '        'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
    '        '        'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
    '        '        'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '        'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

    '        '        e.HasMorePages = False

    '        '    End If

    '    End If



    'End Sub


    Public Sub prt_PrintPageSinRuc(ByVal sender As Object, _
                        ByVal e As PrintPageEventArgs)

        'mostrar si existe ruc o no
        Dim Ruc As String = ""
        ' Este evento se produce cada vez que se va a imprimir una página
        Dim pageWidth As Integer
        Dim lineHeight As Single
        Dim yPos As Single = e.MarginBounds.Top
        Dim leftMargin As Single = e.MarginBounds.Left

        Dim printFont As System.Drawing.Font

        ' Asignar el tipo de letra
        printFont = prtFont
        lineHeight = printFont.GetHeight(e.Graphics)

        If (lineaActual < 37 And lineaActual = 0) Then

            '--------------------------------------------- Encabezado del reporte -------------------------------------------

            Dim NEmpresa As String = "NOTA DE VENTA" & vbLf
            'separacion del primer titulo con la segunda linea
            Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
                                   Brushes.Black, leftMargin - 40, yPos - 100)

            Dim EmpresaRUC As String = "TAMBO - HUANCAYO" & vbLf
            Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
                                   Brushes.Black, leftMargin - 50, yPos - 85)

            'Dim NEmpresa As String = Gempresas.NomEmpresa & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            'e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
            '                       Brushes.Black, leftMargin - 60, yPos - 100)

            'Dim EmpresaRUC As String = "RUC  " & Gempresas.IdEmpresaRuc & vbLf
            'Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
            '                       Brushes.Black, leftMargin - 50, yPos - 85)

            'Dim NDireccion As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NDireccion, fontNDireccion, _
            '                       Brushes.Black, leftMargin - 100, yPos - 70)

            'Dim NNumeroComprobante As String = "3159000 - 3142020" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNNumeroComprobante As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NNumeroComprobante, fontNNumeroComprobante, _
            '                       Brushes.Black, leftMargin - 50, yPos - 55)


            'Dim NBoletaElectronica As String = "BOLETA ELECTRONICA" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica, _
            '                       Brushes.Black, leftMargin - 60, yPos - 40)

            'Dim NNumeroBoleta As String = "B625 - 0238791" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNNumeroBoleta As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NNumeroBoleta, fontNNumeroBoleta, _
            '                       Brushes.Black, leftMargin - 40, yPos - 25)


            'Dim NEstablecimiento As String = GEstableciento.NombreEstablecimiento & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNEstablecimiento As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NEstablecimiento, fontNEstablecimiento, _
            '                       Brushes.Black, leftMargin - 100, yPos + 0)


            'Dim NDireccionEstab As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNDireccionEstab As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NDireccionEstab, fontNDireccionEstab, _
            '                       Brushes.Black, leftMargin - 100, yPos + 12)

            'Dim NLugar As String = "CHILCA - HUANCAYO" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNLugar As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            'e.Graphics.DrawString(NLugar, fontNLugar, _
            '                       Brushes.Black, leftMargin - 100, yPos + 25)


            '-----------------------------------------------------------------------------------------------------------------
            '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
            ' titulo 2 ubicacion de la hoja
            '10 masrgen a la izquierda
            ' ypos ubicacion hacia abajo del titulo primero

            'If (TipoTicket = "ConRUC") Then

            Dim moneda As String = ""

            Select Case cboMoneda.SelectedValue
                Case 2
                    moneda = "EXTRANJERA"
                Case 1
                    moneda = "NACIONAL"
            End Select

            Select Case estadoImpresion
                Case 1
                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
                       vbCrLf & "CORRELATIVO: " & "000004440320" & _
                       vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
                       vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
                       vbCrLf & "------------------------------------------------------------"
                Case Else
                    NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
                    vbCrLf & "CORRELATIVO: " & "000004440320" & _
                    vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
                    vbCrLf & "TIPO MONEDA: " & moneda & _
                    vbCrLf & "------------------------------------------------------------"

            End Select


            Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 80)


            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            'e.Graphics.DrawString(NLinea, fontNLinea, _
            '                       Brushes.Black, leftMargin - 100, yPos + 10)

            'margen a la derecha de toda la lista
            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
            With PrintTikect.DefaultPageSettings
                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
                If .Landscape Then
                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
                End If
            End With
            'tamaño de la primera celda cantidad
            X2 = X1 + 17
            'tamaño de la segunda celda
            X3 = CInt(X2 + pageWidth * 3)

            X4 = X1 + 5
            X5 = X1 + 20

            W1 = (X2 - X1)
            W2 = (X3 - X2)
            W4 = (X3 - X2)
            W5 = (X3 - X2)
            W3 = pageWidth - W1 - W2

            'If itm < lsvDetalle.Items.Count Then
            'ubicacion para abajo
            Y = PrintTikect.DefaultPageSettings.Margins.Top + 10
            Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            ' Draw the column headers at the top of the page
            'ubicacion de las columnas para la izquierda
            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            ' Advance the Y coordinate for the first text line on the printout
            Y = Y + 20
            'End If
            Dim ii As Integer = 0
            Dim ultimaFila As Integer = 0

            For Each i As Record In dgvCompra.Table.Records

                ' extract each item's text into the str variable
                Dim str As String
                str = (CDbl(i.GetValue("cantidad")))

                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

                str = i.GetValue("item")
                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

                Dim lines, cols As Integer
                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
                Dim subitm As Integer, Yc As Integer
                Yc = Y

                str = Math.Round(CDec(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
                Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

                str = Math.Round(CDec(i.GetValue("totalmn")), 2)
                Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

                Dim conteo As Integer

                For subitm = 1 To 1
                    str = i.GetValue("idProducto")
                    'str = i.SubItems(subitm).Text
                    'conteo = 0
                    conteo = (str.Length / 2)
                    Dim strformat As New StringFormat
                    strformat.Trimming = StringTrimming.EllipsisCharacter
                    Yc = Yc + fontNCabecera.Height + 2
                Next
                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
                Y = Math.Max(Y, Yc)

                With PrintTikect.DefaultPageSettings
                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
                        e.HasMorePages = True
                        ii += 1
                        Exit Sub
                    Else
                        ii += 1
                        e.HasMorePages = False
                    End If
                End With

            Next

            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
            Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


            'Dim sumaPagos As String
            'Dim NIgv As String = vbCrLf & vbCrLf & "Redo S/.           " & CDec(0.0)
            'Dim fontNIgv As New System.Drawing.Font("Tahoma", 4, FontStyle.Regular)
            'e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 40, Y - 0)

            'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
            'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total    S/.       " & DigitalGauge2.Value
            Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y - 0)

            'For Each i In dgvPagos.Table.Records
            '    sumaPagos += CDbl(i.GetValue("montoMN"))
            'Next

            Dim cobroMn As Decimal
            'Dim cobroME As Decimal
            Dim vueltoMN As Decimal
            Dim vueltoME As Decimal

            For Each item As Record In gridCaja.Table.Records
                cobroMn += item.GetValue("importePendiente")
                vueltoMN += item.GetValue("vueltoMN")
                vueltoME += item.GetValue("vueltoME")
            Next


            Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(txtTotalBase.DecimalValue)
            Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

            Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(txtTotalBase2.DecimalValue)
            Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

            Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(txtTotalBase3.DecimalValue)
            Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

            Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                          " & CDec(txtTotalIva.DecimalValue)
            Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

            Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                                     " & CDec(lblTotalPercepcion.DecimalValue)
            Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 95)

            Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                                      " & CDec(0.0)
            Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 110)

            Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(DigitalGauge2.Value)
            Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 125)

            Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                           " & CDec(cobroMn)
            Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 140)

            Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                          " & CDec(vueltoMN)
            Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 155)


            'Dim NLinea2 As String = "----------------------------------------------------------------"
            'Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)



            Select Case estadoImpresion
                Case 1
                    'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & DigitalGauge2.Value & " CON 00/100 Soles"
                    'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

                    'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & cobroMn & " (Soles)"
                    'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

                    'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
                    'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

                    'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "Maykol"
                    'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

                    Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
                    Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 170)
                Case Else
                    'Dim NSon As String = vbCrLf & vbCrLf & "SON: " & DigitalGauge2.Value & " CON 00/100 Soles"
                    'Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

                    'Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & cobroMn & " (Soles)"
                    'Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

                    'Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
                    'Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

                    'Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
                    'Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    'e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

                    Dim NVendedor As String = vbCrLf & vbCrLf & "COMPRADOR: " & TXTcOMPRADOR.Text
                    Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                    e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 170)
            End Select

            'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
            'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
            'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

            e.HasMorePages = False

            '    ElseIf (TipoTicket = "SinRUC") Then

            '        Select Case estadoImpresion
            '            Case 1
            '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
            '                   vbCrLf & "CORRELATIVO: " & "000004440320" & _
            '                   vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
            '                   vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
            '                   vbCrLf & "------------------------------------------------------------"
            '            Case Else
            '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
            '                vbCrLf & "CORRELATIVO: " & "000004440320" & _
            '                vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
            '                vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
            '                vbCrLf & "------------------------------------------------------------"

            '        End Select


            '        Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            '        e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos + 20)


            '        'Dim NLinea As String = "----------------------------------------------------------" & vbLf
            '        ''separacion del primer titulo con la segunda linea
            '        'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            '        'e.Graphics.DrawString(NLinea, fontNLinea, _
            '        '                       Brushes.Black, leftMargin - 100, yPos + 10)

            '        'margen a la derecha de toda la lista
            '        X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
            '        With PrintTikect.DefaultPageSettings
            '            pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
            '            If .Landscape Then
            '                pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
            '            End If
            '        End With
            '        'tamaño de la primera celda cantidad
            '        X2 = X1 + 17
            '        'tamaño de la segunda celda
            '        X3 = CInt(X2 + pageWidth * 3)

            '        X4 = X1 + 5
            '        X5 = X1 + 20

            '        W1 = (X2 - X1)
            '        W2 = (X3 - X2)
            '        W4 = (X3 - X2)
            '        W5 = (X3 - X2)
            '        W3 = pageWidth - W1 - W2

            '        'If itm < lsvDetalle.Items.Count Then
            '        'ubicacion para abajo
            '        Y = PrintTikect.DefaultPageSettings.Margins.Top + 115
            '        Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            '        ' Draw the column headers at the top of the page
            '        'ubicacion de las columnas para la izquierda
            '        e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            '        e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            '        e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            '        e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            '        ' Advance the Y coordinate for the first text line on the printout
            '        Y = Y + 20
            '        'End If
            '        Dim ii As Integer = 0
            '        Dim ultimaFila As Integer = 0

            '        For Each i As Record In dgvPagos.Table.Records

            '            ' extract each item's text into the str variable
            '            Dim str As String
            '            str = (CDbl(i.GetValue("cantidad")))

            '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

            '            str = i.GetValue("item")
            '            Dim R As New RectangleF(X2 - 175, Y, W2, 80)
            '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

            '            Dim lines, cols As Integer
            '            e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
            '            Dim subitm As Integer, Yc As Integer
            '            Yc = Y

            '            str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
            '            Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
            '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

            '            str = Math.Round(CDec(i.GetValue("totalmn")), 2)
            '            Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
            '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

            '            Dim conteo As Integer

            '            For subitm = 1 To 1
            '                str = i.GetValue("idProducto")
            '                'str = i.SubItems(subitm).Text
            '                'conteo = 0
            '                conteo = (str.Length / 2)
            '                Dim strformat As New StringFormat
            '                strformat.Trimming = StringTrimming.EllipsisCharacter
            '                Yc = Yc + fontNCabecera.Height + 2
            '            Next
            '            Y = Y + lines * fontNCabecera.Height + (conteo + 2)
            '            Y = Math.Max(Y, Yc)

            '            With PrintTikect.DefaultPageSettings
            '                If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
            '                 (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
            '                    e.HasMorePages = True
            '                    ii += 1
            '                    Exit Sub
            '                Else
            '                    ii += 1
            '                    e.HasMorePages = False
            '                End If
            '            End With

            '        Next

            '        Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
            '        Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


            '        'Dim sumaPagos As String
            '        Dim NIgv As String = vbCrLf & vbCrLf & "Redo S/.           " & CDec(0.0)
            '        Dim fontNIgv As New System.Drawing.Font("Tahoma", 4, FontStyle.Regular)
            '        e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 40, Y - 0)

            '        'Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
            '        'Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        'e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

            '        Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total    S/.       " & txtTotalPagar.DecimalValue
            '        Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y + 20)

            '        'For Each i In dgvPagos.Table.Records
            '        '    sumaPagos += CDbl(i.GetValue("montoMN"))
            '        'Next

            '        Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(txtTotalBase.DecimalValue)
            '        Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

            '        Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(txtTotalBase2.DecimalValue)
            '        Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

            '        Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(txtTotalBase3.DecimalValue)
            '        Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

            '        Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V.                S/.                                            " & CDec(txtTotalIva.DecimalValue)
            '        Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

            '        Dim NTotal As String = vbCrLf & vbCrLf & "Importe Total     S/.                                            " & CDec(txtTotalPagar.DecimalValue)
            '        Dim fontNTotal As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NTotal, fontNTotal, Brushes.Black, leftMargin - 100, Y + 95)
            '        Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo          S/.                                            " & CDec(lblTotalPercepcion.DecimalValue)
            '        Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 110)

            '        Dim NDonacion As String = vbCrLf & vbCrLf & "Donación           S/.                                            " & 0.0
            '        Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 125)

            '        Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(txtTotalPagar.DecimalValue)
            '        Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 140)

            '        'Dim NLinea2 As String = "----------------------------------------------------------------"
            '        'Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        'e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)


            '        Select Case estadoImpresion
            '            Case 1
            '                Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
            '                Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

            '                Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
            '                Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

            '                Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
            '                Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

            '                Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
            '                Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

            '                Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
            '                Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
            '            Case Else
            '                Dim NSon As String = vbCrLf & vbCrLf & "SON: " & txtCobroMN.DecimalValue & " CON 00/100 Soles"
            '                Dim fontNSon As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NSon, fontNSon, Brushes.Black, leftMargin - 100, Y + 170)

            '                Dim NEfectivo As String = vbCrLf & vbCrLf & "EFECTIVO SOLES: " & txtCobroMN.DecimalValue & " (Soles)"
            '                Dim fontNEfectivo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NEfectivo, fontNEfectivo, Brushes.Black, leftMargin - 100, Y + 185)

            '                Dim NVuelto As String = vbCrLf & vbCrLf & "VUELTO:  S/. " & vueltoMN
            '                Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 200)

            '                Dim NCAjero As String = vbCrLf & vbCrLf & "CAJERO: " & "MAYKOL"
            '                Dim fontNCAjero As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NCAjero, fontNCAjero, Brushes.Black, leftMargin - 100, Y + 215)

            '                Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
            '                Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '                e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 230)
            '        End Select

            '        'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
            '        'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
            '        'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            '        'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

            '        e.HasMorePages = False

            '    End If

        End If



    End Sub


    'Public Sub prt_PrintPageSinRuc(ByVal sender As Object, _
    '                      ByVal e As PrintPageEventArgs)

    '    'mostrar si existe ruc o no
    '    Dim Ruc As String = ""
    '    ' Este evento se produce cada vez que se va a imprimir una página
    '    Dim pageWidth As Integer
    '    Dim lineHeight As Single
    '    Dim yPos As Single = e.MarginBounds.Top
    '    Dim leftMargin As Single = e.MarginBounds.Left

    '    Dim printFont As System.Drawing.Font

    '    ' Asignar el tipo de letra
    '    printFont = prtFont
    '    lineHeight = printFont.GetHeight(e.Graphics)

    '    If (lineaActual < 37 And lineaActual = 0) Then

    '        '--------------------------------------------- Encabezado del reporte -------------------------------------------
    '        Dim NEmpresa As String = "NOTA DE VENTA" & vbLf
    '        'separacion del primer titulo con la segunda linea
    '        Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
    '        e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
    '                               Brushes.Black, leftMargin - 40, yPos - 100)

    '        Dim EmpresaRUC As String = "TAMBO - HUANCAYO" & vbLf
    '        Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
    '                               Brushes.Black, leftMargin - 50, yPos - 85)

    '        'Dim NDireccion As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NDireccion, fontNDireccion, _
    '        '                       Brushes.Black, leftMargin - 100, yPos - 70)

    '        'Dim NNumeroComprobante As String = "3159000 - 3142020" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNNumeroComprobante As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NNumeroComprobante, fontNNumeroComprobante, _
    '        '                       Brushes.Black, leftMargin - 50, yPos - 55)


    '        'Dim NBoletaElectronica As String = "BOLETA ELECTRONICA" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNBoletaElectronica As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NBoletaElectronica, fontNBoletaElectronica, _
    '        '                       Brushes.Black, leftMargin - 60, yPos - 40)

    '        'Dim NNumeroBoleta As String = "B625 - 0238791" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNNumeroBoleta As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NNumeroBoleta, fontNNumeroBoleta, _
    '        '                       Brushes.Black, leftMargin - 40, yPos - 25)


    '        'Dim NEstablecimiento As String = GEstableciento.NombreEstablecimiento & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNEstablecimiento As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NEstablecimiento, fontNEstablecimiento, _
    '        '                       Brushes.Black, leftMargin - 100, yPos + 0)


    '        'Dim NDireccionEstab As String = "Jr. Ricardo Palma #881 - Chilca" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNDireccionEstab As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NDireccionEstab, fontNDireccionEstab, _
    '        '                       Brushes.Black, leftMargin - 100, yPos + 12)

    '        'Dim NLugar As String = "CHILCA - HUANCAYO" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNLugar As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
    '        'e.Graphics.DrawString(NLugar, fontNLugar, _
    '        '                       Brushes.Black, leftMargin - 100, yPos + 25)


    '        '-----------------------------------------------------------------------------------------------------------------
    '        '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
    '        ' titulo 2 ubicacion de la hoja
    '        '10 masrgen a la izquierda
    '        ' ypos ubicacion hacia abajo del titulo primero

    '        Dim moneda As String = ""

    '        Select Case cboMoneda.SelectedValue
    '            Case 2
    '                moneda = "EXTRANJERA"
    '            Case 1
    '                moneda = "NACIONAL"
    '        End Select

    '        Dim cobroMn As Decimal
    '        Dim cobroME As Decimal
    '        Dim vueltoMN As Decimal
    '        Dim vueltoME As Decimal

    '        For Each item As Record In dgvPagos.Table.Records
    '            cobroMn += item.GetValue("importePendiente")
    '            vueltoMN += item.GetValue("vueltoMN")
    '            vueltoME += item.GetValue("vueltoME")
    '        Next

    '        'If (TipoTicket = "ConRUC") Then

    '        '    Select Case estadoImpresion
    '        '        Case 1
    '        'NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '        '   vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
    '        '   vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '        '   vbCrLf & "TIPO MONEDA: " & moneda & _
    '        '   vbCrLf & "------------------------------------------------------------"
    '        '        Case Else
    '        'NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '        'vbCrLf & "CORRELATIVO: " & txtNumeroPedido.Text & _
    '        'vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '        'vbCrLf & "TIPO MONEDA: " & moneda & _
    '        'vbCrLf & "------------------------------------------------------------"

    '        'End Select

    '        Select Case estadoImpresion
    '            Case 1
    '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                   vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '                   vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                   vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
    '                   vbCrLf & "------------------------------------------------------------"
    '            Case Else
    '                NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '                vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '                vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '                vbCrLf & "TIPO MONEDA: " & moneda & _
    '                vbCrLf & "------------------------------------------------------------"

    '        End Select


    '        Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '        e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 80) '+20


    '        'Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '        ''separacion del primer titulo con la segunda linea
    '        'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        'e.Graphics.DrawString(NLinea, fontNLinea, _
    '        '                       Brushes.Black, leftMargin - 100, yPos + 10)

    '        'margen a la derecha de toda la lista
    '        X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '        With PrintTikect.DefaultPageSettings
    '            pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '            If .Landscape Then
    '                pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '            End If
    '        End With
    '        'tamaño de la primera celda cantidad
    '        X2 = X1 + 17
    '        'tamaño de la segunda celda
    '        X3 = CInt(X2 + pageWidth * 3)

    '        X4 = X1 + 5
    '        X5 = X1 + 20

    '        W1 = (X2 - X1)
    '        W2 = (X3 - X2)
    '        W4 = (X3 - X2)
    '        W5 = (X3 - X2)
    '        W3 = pageWidth - W1 - W2

    '        'If itm < lsvDetalle.Items.Count Then
    '        'ubicacion para abajo
    '        Y = PrintTikect.DefaultPageSettings.Margins.Top + 10
    '        Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        ' Draw the column headers at the top of the page
    '        'ubicacion de las columnas para la izquierda
    '        e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '        e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '        e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '        e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '        ' Advance the Y coordinate for the first text line on the printout
    '        Y = Y + 20
    '        'End If
    '        Dim ii As Integer = 0
    '        Dim ultimaFila As Integer = 0

    '        For Each i As Record In dgvPagos.Table.Records

    '            ' extract each item's text into the str variable
    '            Dim str As String
    '            str = (CDbl(i.GetValue("cantidad")))

    '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '            str = i.GetValue("item")
    '            Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '            e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '            Dim lines, cols As Integer
    '            e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '            Dim subitm As Integer, Yc As Integer
    '            Yc = Y

    '            str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '            Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '            str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '            Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '            e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '            Dim conteo As Integer

    '            For subitm = 1 To 1
    '                str = i.GetValue("idProducto")
    '                'str = i.SubItems(subitm).Text
    '                'conteo = 0
    '                conteo = (str.Length / 2)
    '                Dim strformat As New StringFormat
    '                strformat.Trimming = StringTrimming.EllipsisCharacter
    '                Yc = Yc + fontNCabecera.Height + 2
    '            Next
    '            Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '            Y = Math.Max(Y, Yc)

    '            With PrintTikect.DefaultPageSettings
    '                If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '                 (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '                    e.HasMorePages = True
    '                    ii += 1
    '                    Exit Sub
    '                Else
    '                    ii += 1
    '                    e.HasMorePages = False
    '                End If
    '            End With

    '        Next

    '        Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
    '        Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)

    '        Dim NTotalPagar As String = vbCrLf & vbCrLf & "Sub Total S/. " & lblTotalMN.Text
    '        Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y - 0)

    '        Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(TotalesXcanbeceras.BaseMN).ToString("N2")
    '        Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '        Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(TotalesXcanbeceras.BaseMN2).ToString("N2")
    '        Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '        Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(TotalesXcanbeceras.BaseMN3).ToString("N2")
    '        Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '        Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                          " & CDec(TotalesXcanbeceras.IgvMN).ToString("N2")
    '        Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '        Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                                     " & CDec(TotalesXcanbeceras.PercepcionMN).ToString("N2")
    '        Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 95)

    '        Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                                      " & CDec(0.0).ToString("N2")
    '        Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 110)

    '        Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(DigitalGauge2.Value).ToString("N2")
    '        Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 125)

    '        Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                           " & CDec(cobroMn).ToString("N2")
    '        Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 140)

    '        Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                          " & CDec(vueltoMN).ToString("N2")
    '        Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 155)


    '        Select Case estadoImpresion
    '            Case 1

    '                'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)
    '            Case Else
    '                'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '                'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '                'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)

    '        End Select

    '        e.HasMorePages = False

    '        'ElseIf (TipoTicket = "SinRUC") Then

    '        '    Select Case estadoImpresion
    '        '        Case 1
    '        '            NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '        '               vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '        '               vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '        '               vbCrLf & "TIPO MONEDA: " & cboMoneda.SelectedValue & _
    '        '               vbCrLf & "------------------------------------------------------------"
    '        '        Case Else
    '        '            NCliente = vbCrLf & vbCrLf & "FECHA DE EMISION: " & DateTime.Now & _
    '        '            vbCrLf & "CORRELATIVO: " & "000004440320" & _
    '        '            vbCrLf & "CAJA/TURNO: " & idCajaUsuario & _
    '        '            vbCrLf & "TIPO MONEDA: " & moneda & _
    '        '            vbCrLf & "------------------------------------------------------------"

    '        '    End Select


    '        '    Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 80)


    '        '    'Dim NLinea As String = "----------------------------------------------------------" & vbLf
    '        '    ''separacion del primer titulo con la segunda linea
    '        '    'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        '    'e.Graphics.DrawString(NLinea, fontNLinea, _
    '        '    '                       Brushes.Black, leftMargin - 100, yPos + 10)

    '        '    'margen a la derecha de toda la lista
    '        '    X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
    '        '    With PrintTikect.DefaultPageSettings
    '        '        pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
    '        '        If .Landscape Then
    '        '            pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
    '        '        End If
    '        '    End With
    '        '    'tamaño de la primera celda cantidad
    '        '    X2 = X1 + 17
    '        '    'tamaño de la segunda celda
    '        '    X3 = CInt(X2 + pageWidth * 3)

    '        '    X4 = X1 + 5
    '        '    X5 = X1 + 20

    '        '    W1 = (X2 - X1)
    '        '    W2 = (X3 - X2)
    '        '    W4 = (X3 - X2)
    '        '    W5 = (X3 - X2)
    '        '    W3 = pageWidth - W1 - W2

    '        '    'If itm < lsvDetalle.Items.Count Then
    '        '    'ubicacion para abajo
    '        '    Y = PrintTikect.DefaultPageSettings.Margins.Top + 10
    '        '    Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
    '        '    ' Draw the column headers at the top of the page
    '        '    'ubicacion de las columnas para la izquierda
    '        '    e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
    '        '    e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
    '        '    e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
    '        '    e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
    '        '    ' Advance the Y coordinate for the first text line on the printout
    '        '    Y = Y + 20
    '        '    'End If
    '        '    Dim ii As Integer = 0
    '        '    Dim ultimaFila As Integer = 0

    '        '    For Each i As Record In dgvPagos.Table.Records

    '        '        ' extract each item's text into the str variable
    '        '        Dim str As String
    '        '        str = (CDbl(i.GetValue("cantidad")))

    '        '        e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

    '        '        str = i.GetValue("item")
    '        '        Dim R As New RectangleF(X2 - 175, Y, W2, 80)
    '        '        e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

    '        '        Dim lines, cols As Integer
    '        '        e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
    '        '        Dim subitm As Integer, Yc As Integer
    '        '        Yc = Y

    '        '        str = Math.Round(CDbl(i.GetValue("totalmn")) / CDbl(i.GetValue("cantidad")), 2)
    '        '        Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
    '        '        e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

    '        '        str = Math.Round(CDec(i.GetValue("totalmn")), 2)
    '        '        Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
    '        '        e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

    '        '        Dim conteo As Integer

    '        '        For subitm = 1 To 1
    '        '            str = i.GetValue("idProducto")
    '        '            'str = i.SubItems(subitm).Text
    '        '            'conteo = 0
    '        '            conteo = (str.Length / 2)
    '        '            Dim strformat As New StringFormat
    '        '            strformat.Trimming = StringTrimming.EllipsisCharacter
    '        '            Yc = Yc + fontNCabecera.Height + 2
    '        '        Next
    '        '        Y = Y + lines * fontNCabecera.Height + (conteo + 2)
    '        '        Y = Math.Max(Y, Yc)

    '        '        With PrintTikect.DefaultPageSettings
    '        '            If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
    '        '             (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
    '        '                e.HasMorePages = True
    '        '                ii += 1
    '        '                Exit Sub
    '        '            Else
    '        '                ii += 1
    '        '                e.HasMorePages = False
    '        '            End If
    '        '        End With

    '        '    Next

    '        '    Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------------------------------------------"
    '        '    Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin - 100, Y - 20)


    '        '    Dim NTotalPagar As String = vbCrLf & vbCrLf & "Sub Total S/. " & txtCobroMN.DecimalValue
    '        '    Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 40, Y - 0)


    '        '    Dim NExonerada As String = vbCrLf & vbCrLf & "Op. Exonerada                                                   " & CDec(TotalesXcanbeceras.BaseMN3).ToString("N2")
    '        '    Dim fontNExonerada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NExonerada, fontNExonerada, Brushes.Black, leftMargin - 100, Y + 35)

    '        '    Dim NIanfecta As String = vbCrLf & vbCrLf & "Op. Inafecta                                                      " & CDec(TotalesXcanbeceras.BaseMN2).ToString("N2")
    '        '    Dim fontNIanfecta As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NIanfecta, fontNIanfecta, Brushes.Black, leftMargin - 100, Y + 50)

    '        '    Dim NGravada As String = vbCrLf & vbCrLf & "Op. Gravada                                                      " & CDec(TotalesXcanbeceras.BaseMN).ToString("N2")
    '        '    Dim fontNGravada As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NGravada, fontNGravada, Brushes.Black, leftMargin - 100, Y + 65)

    '        '    Dim NIGVE As String = vbCrLf & vbCrLf & "I.G.V. S/.                                                          " & CDec(TotalesXcanbeceras.IgvMN).ToString("N2")
    '        '    Dim fontNIGVE As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NIGVE, fontNIGVE, Brushes.Black, leftMargin - 100, Y + 80)

    '        '    Dim NREdondedo As String = vbCrLf & vbCrLf & "Redondeo S/.                                                     " & CDec(TotalesXcanbeceras.PercepcionMN).ToString("N2")
    '        '    Dim fontNREdondedo As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NREdondedo, fontNREdondedo, Brushes.Black, leftMargin - 100, Y + 95)

    '        '    Dim NDonacion As String = vbCrLf & vbCrLf & "Donación S/.                                                      " & CDec(0.0).ToString("N2")
    '        '    Dim fontNDonacion As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NDonacion, fontNDonacion, Brushes.Black, leftMargin - 100, Y + 110)

    '        '    Dim NDImporPagar As String = vbCrLf & vbCrLf & "Importa a Pagar S/.                                            " & CDec(DigitalGauge2.Value).ToString("N2")
    '        '    Dim fontNDImporPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NDImporPagar, fontNDImporPagar, Brushes.Black, leftMargin - 100, Y + 125)

    '        '    Dim NImporteRecibido As String = vbCrLf & vbCrLf & "Importe Recibido S/.                                           " & CDec(cobroMn).ToString("N2")
    '        '    Dim fontNImporteRecibido As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NImporteRecibido, fontNImporteRecibido, Brushes.Black, leftMargin - 100, Y + 140)

    '        '    Dim NVuelto As String = vbCrLf & vbCrLf & "Vuelto S/.                                                          " & CDec(vueltoMN).ToString("N2")
    '        '    Dim fontNVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '    e.Graphics.DrawString(NVuelto, fontNVuelto, Brushes.Black, leftMargin - 100, Y + 155)


    '        '    Select Case estadoImpresion
    '        '        Case 1
    '        '            'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '        '            'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '            'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)

    '        '        Case Else
    '        '            'Dim NVendedor As String = vbCrLf & vbCrLf & "VENDEDOR: " & "MAYKOL"
    '        '            'Dim fontNVendedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    '        '            'e.Graphics.DrawString(NVendedor, fontNVendedor, Brushes.Black, leftMargin - 100, Y + 180)

    '        '    End Select



    '        '    e.HasMorePages = False

    '        'End If

    '    End If



    'End Sub

#End Region

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If MessageBoxAdv.Show("Desea imprimir la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If dgvCompra.Table.Records.Count > 0 Then
                llenarDatos()
                imprimir(True)
            End If
        End If
    End Sub

    Sub CalculoPagos()
        For Each i In dgvCompra.Table.Records
            i.SetValue("estado", "NO")
            i.SetValue("pagado", i.GetValue("totalmn"))
        Next

        For Each i As Record In gridCaja.Table.Records
            If CDbl(i.GetValue("montoMN")) > 0 Then
                CalculosSubpago(i)
            End If
        Next

    End Sub


    Private Sub dgvPreciosServicio_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            'If Not IsNothing(Me.dgvPreciosServicio.Table.CurrentRecord) Then

            '    ' ValidarItemsDuplicados(Val(dgvPreciosServicio.Table.CurrentRecord.GetValue("idItem")))
            '    txtServicio.Text = String.Empty
            '    AgregarAcanastaServicio()
            'End If
            '    txtBarCode.Select()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs)
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        txtRuc.ForeColor = Color.Black
        txtRuc.Tag = Nothing
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        'Else
        '    Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
        '    Me.popupControlContainer1.Size = New Size(241, 110)
        '    Me.popupControlContainer1.ParentControl = Me.txtProveedor
        '    Me.popupControlContainer1.ShowPopup(Point.Empty)

        '    Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()

        '    lsvProveedor.DataSource = con
        '    lsvProveedor.DisplayMember = "nombreCompleto"
        '    lsvProveedor.ValueMember = "idEntidad"
        'End If
        'If e.KeyCode = Keys.Down Then
        '    Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
        '    Me.popupControlContainer1.Size = New Size(241, 110)
        '    Me.popupControlContainer1.ParentControl = Me.txtProveedor
        '    Me.popupControlContainer1.ShowPopup(Point.Empty)
        '    txtProveedor.Focus()
        'End If

        'If e.KeyCode = Keys.Escape Then
        '    If Me.popupControlContainer1.IsShowing() Then
        '        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick_1(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Dim colIdItem As Integer

        colIdItem = intIdItem

        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
            End If
        Next
    End Sub

 

    Private Sub dgvPagos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        '************************** use usa para cambiar todo la fila el color *******************************

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Or e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement
            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record) Then
                Dim r As Record = el.GetRecord
                Dim value As Object = r.GetValue("pago")
                Dim moneda As Object = r.GetValue("moneda")

                Select Case value

                    Case "EFECTIVO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF2E8B57")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "BANCO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF212121")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF484747")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "TARJETA CREDITO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD28306")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFB67208")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select

                End Select

            End If

        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
            'If (Not IsNothing(str)) Then

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importePendiente")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("importePendiente")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If


            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "saldo")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("saldo")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoMN")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoMN")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoME")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoME")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipocambio")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("tipocambio")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
                    'e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    'e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If
        End If

        'End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If (ToolStripComboBox1.Text = "CONTADO") Then
            Dim ef As New EstadosFinancierosSA
            Dim cajaUsuario As New cajaUsuario
            Dim cajaUsuarioSA As New cajaUsuarioSA
            Dim usuarioSA As New UsuarioSA
            Dim usuarioxls As New Usuario
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            'CargarCajasTipo(usuario.IDUsuario)
            If Not IsNothing(cajaUsuario) Then
                Me.btGrabar.Visible = False
                ToolStripButton4.Visible = True
                GConfiguracion = New GConfiguracionModulo
                configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
                cboTipoDoc.Text = "TICKET BOLETA"
            Else

                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            Me.btGrabar.Visible = True
            ToolStripButton4.Visible = False
            'Panel6.Visible = False
            'Me.Size = New Size(1163, 527)
            'ToolStripComboBox1.Text = "CREDITO"
        End If

    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        If (Not IsNothing(dgvCompra.DataSource)) Then
            If (ToolStripComboBox2.Text = "TOTAL") Then
                Me.dgvCompra.TableDescriptor.Columns("cantEntregar").Width = 90
                Me.dgvCompra.TableDescriptor.Columns("cantPendiente").Width = 0
                Me.dgvCompra.TableDescriptor.Columns("cantPendiente").ReadOnly = True
                Me.dgvCompra.TableDescriptor.Columns("cantEntregar").ReadOnly = True
            ElseIf (ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL") Then
                Me.dgvCompra.TableDescriptor.Columns("cantPendiente").ReadOnly = True
                Me.dgvCompra.TableDescriptor.Columns("cantEntregar").ReadOnly = False
                Me.dgvCompra.TableDescriptor.Columns("cantEntregar").Width = 90
                Me.dgvCompra.TableDescriptor.Columns("cantPendiente").Width = 90
            End If
        End If

        For Each item In dgvCompra.Table.Records
            If (ToolStripComboBox2.Text = "TOTAL") Then
                item.SetValue("cantEntregar", item.GetValue("cantidad"))
                item.SetValue("cantPendiente", 0)
            ElseIf (ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL") Then
                item.SetValue("cantEntregar", 0)
                item.SetValue("cantPendiente", item.GetValue("cantidad"))
            End If
        Next

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Clientes"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtProveedor.Text = c.nombreCompleto
            txtProveedor.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtFiltrar_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            '  ListadoProveedores.Add(c)
            txtProveedor.Text = c.nombreCompleto
            txtRuc.Text = c.nrodoc
            txtProveedor.Tag = c.idEntidad
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub dgvServicios_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicios.TableControlCellDoubleClick
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim totalSA As New TotalesAlmacenSA
        Try


            '   If gridGroupingControl1.Table.Records.Count > 0 Then
            Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, dgvServicios.Table.CurrentRecord.GetValue("idServicio"))

            If listaPrecios.Count > 0 Then
                'ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                AgregarAcanastaServicvioCodigoBarra(dgvServicios.Table.CurrentRecord, listaPrecios(0))
            Else
                MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        Try
            If (chIdentificacion.Checked = True) Then
                If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar el nombre de comprador"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done comprador"
                End If
            Else
                If txtProveedor.Text.Length > 0 Then
                    If txtProveedor.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtProveedor.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If txtRuc.Text.Length > 0 Then
                    If txtRuc.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtRuc.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If
            End If

            With frmCajasXusuario
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtSerie.Text
                If (chIdentificacion.Checked = False) Then
                    .txtCliente.Text = txtProveedor.Text
                    .txtCliente.Tag = txtProveedor.Tag
                    .txtRuc.Text = txtRuc.Text
                Else
                    .txtCliente.Text = TXTcOMPRADOR.Text
                End If

                .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub frmVentaPVdirecta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.F7) ' mayúsculas y minúsculas

                Me.Cursor = Cursors.WaitCursor
                Try

                    If (chIdentificacion.Checked = True) Then
                        If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                            lblEstado.Text = "Ingresar el nombre de comprador"
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)

                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            lblEstado.Text = "Done comprador"
                        End If
                    Else
                        If txtProveedor.Text.Length > 0 Then
                            If txtProveedor.ForeColor = Color.Black Then
                                MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txtProveedor.Select()
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If
                        End If

                        If txtRuc.Text.Length > 0 Then
                            If txtRuc.ForeColor = Color.Black Then
                                MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txtRuc.Select()
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If
                        End If
                    End If

                    With frmCajasXusuario
                        .DigitalGauge2.Value = DigitalGauge2.Value
                        .txtFecha.Value = txtFecha.Value
                        .txtTipoDoc.Text = cboTipoDoc.Text
                        .txtSerie.Text = txtSerie.Text
                        .txtNumero.Text = txtSerie.Text
                        .txtCliente.Text = txtProveedor.Text
                        .txtCliente.Tag = txtProveedor.Tag
                        .txtRuc.Text = txtRuc.Text
                        .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With

                Catch ex As Exception
                    lblEstado.Text = ex.Message
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End Try
                Me.Cursor = Cursors.Arrow


        End Select
    End Sub

    Private Sub frmVentaPVdirecta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.F7 Then
                If (chIdentificacion.Checked = True) Then
                    If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingresar el nombre de comprador"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)

                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        lblEstado.Text = "Done comprador"
                    End If
                Else
                    If txtProveedor.Text.Length > 0 Then
                        If txtProveedor.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtProveedor.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If

                    If txtRuc.Text.Length > 0 Then
                        If txtRuc.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtRuc.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If
                End If


                With frmCajasXusuario
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = txtFecha.Value
                    .txtTipoDoc.Text = cboTipoDoc.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtSerie.Text
                    .txtCliente.Text = txtProveedor.Text
                    .txtCliente.Tag = txtProveedor.Tag
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf e.KeyCode = Keys.F6 Then
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmVentaPVdirecta_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.F7 Then
                If (chIdentificacion.Checked = True) Then
                    If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingresar el nombre de comprador"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)

                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        lblEstado.Text = "Done comprador"
                    End If
                Else
                    If txtProveedor.Text.Length > 0 Then
                        If txtProveedor.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtProveedor.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If

                    If txtRuc.Text.Length > 0 Then
                        If txtRuc.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtRuc.Select()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If
                End If


                With frmCajasXusuario
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = txtFecha.Value
                    .txtTipoDoc.Text = cboTipoDoc.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtSerie.Text
                    .txtCliente.Text = txtProveedor.Text
                    .txtCliente.Tag = txtProveedor.Tag
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf e.KeyCode = Keys.F6 Then
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case cc.ColIndex ' ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"

                    'Case Else
                    Dim pendiente As Integer
                    Dim cantEntregado As Integer
                    Select Case strTipoEx
                        Case "GS"
                            Dim r As Record = dgvCompra.Table.CurrentRecord
                            Dim cantida = r.GetValue("cantidad")
                            pendiente = r.GetValue("cantidad")
                            cantEntregado = r.GetValue("cantEntregar")
                            If Not IsNothing(r) Then
                                r.SetValue("cantPendiente", cantida)
                                r.SetValue("cantEntregar", cantida)
                                r.SetValue("canDisponible", cantida)
                            End If
                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                        Case Else


                            pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                            cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()


                Case 8
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                            'tratamientoPagosDefautl()
                        Case Else

                    End Select

                Case 26
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

                        Dim pendiente As Integer
                        Dim cantEntregado As Integer

                        pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                        If (Int(pendiente > cantEntregado)) Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente - cantEntregado)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                            lblEstado.Text = "no debe exceder la cantidad permitido"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If

                        If (Int(pendiente <> cantEntregado)) Then
                            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case cc.ColIndex ' ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"

                    'Case Else
                    Dim pendiente As Integer
                    Dim cantEntregado As Integer
                    Select Case strTipoEx
                        Case "GS"
                            Dim r As Record = dgvCompra.Table.CurrentRecord
                            Dim cantida = r.GetValue("cantidad")
                            pendiente = r.GetValue("cantidad")
                            cantEntregado = r.GetValue("cantEntregar")
                            If Not IsNothing(r) Then
                                r.SetValue("cantPendiente", cantida)
                                r.SetValue("cantEntregar", cantida)
                                r.SetValue("canDisponible", cantida)
                            End If
                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                        Case Else


                            pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                            cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()


                Case 8
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                            'tratamientoPagosDefautl()
                        Case Else

                    End Select

                Case 26
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

                        Dim pendiente As Integer
                        Dim cantEntregado As Integer

                        pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                        If (Int(pendiente > cantEntregado)) Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente - cantEntregado)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                            lblEstado.Text = "no debe exceder la cantidad permitido"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If

                        If (Int(pendiente <> cantEntregado)) Then
                            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case cc.ColIndex ' ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"

                    'Case Else
                    Dim pendiente As Integer
                    Dim cantEntregado As Integer
                    Select Case strTipoEx
                        Case "GS"
                            Dim r As Record = dgvCompra.Table.CurrentRecord
                            Dim cantida = r.GetValue("cantidad")
                            pendiente = r.GetValue("cantidad")
                            cantEntregado = r.GetValue("cantEntregar")
                            If Not IsNothing(r) Then
                                r.SetValue("cantPendiente", cantida)
                                r.SetValue("cantEntregar", cantida)
                                r.SetValue("canDisponible", cantida)
                            End If
                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                        Case Else


                            pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                            cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()


                Case 8
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                            'tratamientoPagosDefautl()
                        Case Else

                    End Select

                Case 26
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

                        Dim pendiente As Integer
                        Dim cantEntregado As Integer

                        pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                        If (Int(pendiente > cantEntregado)) Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente - cantEntregado)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                            lblEstado.Text = "no debe exceder la cantidad permitido"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If

                        If (Int(pendiente <> cantEntregado)) Then
                            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged
        Filtro(TextBoxExt1.Text)
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case cc.ColIndex ' ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"

                    'Case Else
                    Dim pendiente As Integer
                    Dim cantEntregado As Integer
                    Select Case strTipoEx
                        Case "GS"
                            Dim r As Record = dgvCompra.Table.CurrentRecord
                            Dim cantida = r.GetValue("cantidad")
                            pendiente = r.GetValue("cantidad")
                            cantEntregado = r.GetValue("cantEntregar")
                            If Not IsNothing(r) Then
                                r.SetValue("cantPendiente", cantida)
                                r.SetValue("cantEntregar", cantida)
                                r.SetValue("canDisponible", cantida)
                            End If
                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                        Case Else


                            pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                            cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                            If (ToolStripComboBox2.Text = "TOTAL") Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            Else
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                            End If
                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()


                Case 8
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                            'tratamientoPagosDefautl()
                        Case Else

                    End Select

                Case 26
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

                        Dim pendiente As Integer
                        Dim cantEntregado As Integer

                        pendiente = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantEntregado = Me.dgvCompra.Table.CurrentRecord.GetValue("cantEntregar")

                        If (Int(pendiente > cantEntregado)) Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente - cantEntregado)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                            lblEstado.Text = "no debe exceder la cantidad permitido"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If

                        If (Int(pendiente <> cantEntregado)) Then
                            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        'If GridDataBoundGrid1.Binder.RecordCount > 0 Then
        '    Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
        '        Case 1
        Dim f As New frmNuevoPrecio
        f.txtProducto.Tag = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem")
        f.txtProducto.Text = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion")
        f.txtGrav.Text = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino")
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GridGroupingControl2.Table.Records.DeleteAll()
        UbicarUltimosPreciosXproducto()
        '        Case Else
        '            MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End Select
        'End If
    End Sub

   
    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)


                If chempresa.Checked = True Then
                    ObtenerCanastaVentaFiltro(0, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)

                ElseIf chempresa.Checked = False Then

                    ObtenerCanastaVentaFiltroEmpresa(cboAlmacen.SelectedValue, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)
                End If

                lblEstado.Text = "productos encontrados: " & GridDataBoundGrid1.Model.RowCount
            Else
                lblEstado.Text = "Digitar un producto válido!"
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltrar_Click(sender As Object, e As EventArgs) Handles txtFiltrar.Click
        txtFiltrar.SelectAll()
    End Sub

    Private Sub TextBoxExt3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxExt3.KeyPress
        Me.Cursor = Cursors.WaitCursor
        If Char.IsDigit(e.KeyChar) Then
            txtBarCode.Select(txtBarCode.Text.Length, 0)
            e.Handled = False
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            'Como se sabe los lectores de barra al final mandan un {ENTER}
            'por eso una vez que lo envía aqui se haces la función que deseas realizar
            If txtBarCode.Text.Trim.Length > 0 Then
                GetExistenciaByCodigoBar(txtBarCode.Text.Trim)

            End If
        Else
            '  e.Handled = True

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridDataBoundGrid1_CellButtonClicked(sender As Object, e As GridCellButtonClickedEventArgs) Handles GridDataBoundGrid1.CellButtonClicked
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim intSelectedRow = GridDataBoundGrid1.Selections.Ranges.ActiveRange.Top
        'Dim s As String = String.Format("You clicked ({0},{1}).", e.RowIndex, e.ColIndex)
        'Dim s As String = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion", e.RowIndex)
        If e.RowIndex <> 0 Then
            Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", e.RowIndex))
            If listaPrecios.Count > 0 Then
                Dim cantidad = InputBox("Ingrese cantidad a vender", "Stock disponible: " & MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", e.RowIndex), "")
                If IsNumeric(cantidad) Then

                    If cantidad <= 0 Then
                        MessageBox.Show("La cantidad ingresada debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                        Cursor = Cursors.Default
                    End If

                    If (CDec(cantidad) > CDec(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", e.RowIndex))) Then
                        MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                        Cursor = Cursors.Default
                    End If

                    '    ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                    AgregarAcanastaCodigoBarra_Index(listaPrecios(0), e.RowIndex)
                    GridDataBoundGrid1.Focus()
                    GridDataBoundGrid1.Model.Rows.MoveRange(intSelectedRow, e.RowIndex, e.RowIndex)

                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent("cantidad")
                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetValue("cantidad", CDec(cantidad))

                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent("cantEntregar")
                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetValue("cantEntregar", CDec(cantidad))

                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent("cantPendiente")
                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetValue("cantPendiente", 0)

                    Calculos()
                    ConteoLabelVentas()
                    txtFiltrar.Select()
                    txtFiltrar.Focus()
                    txtFiltrar.SelectAll()
                Else
                    MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Else
                MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        'MessageBox.Show(s)
    End Sub

    Private Sub GridDataBoundGrid1_CellClick(sender As Object, e As GridCellClickEventArgs) Handles GridDataBoundGrid1.CellClick
        Cursor = Cursors.WaitCursor
        If e.RowIndex <> 0 Then
            GridGroupingControl2.Table.Records.DeleteAll()
            UbicarUltimosPreciosXproducto()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridDataBoundGrid1_CurrentCellKeyUp(sender As Object, e As KeyEventArgs) Handles GridDataBoundGrid1.CurrentCellKeyUp
        Cursor = Cursors.WaitCursor
        If e.KeyData = Keys.Down Or e.KeyData = Keys.Up Then
            GridGroupingControl2.Table.Records.DeleteAll()
            UbicarUltimosPreciosXproducto()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvServicios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicios.TableControlCellClick
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim totalSA As New TotalesAlmacenSA
        Try


            '   If gridGroupingControl1.Table.Records.Count > 0 Then
            Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, dgvServicios.Table.CurrentRecord.GetValue("idServicio"))

            If listaPrecios.Count > 0 Then
                'ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                AgregarAcanastaServicvioCodigoBarra(dgvServicios.Table.CurrentRecord, listaPrecios(0))
            Else
                MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

#End Region
End Class