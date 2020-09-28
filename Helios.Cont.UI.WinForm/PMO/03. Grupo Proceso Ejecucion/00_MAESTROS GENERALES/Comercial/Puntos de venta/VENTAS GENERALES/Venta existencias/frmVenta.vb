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
Public Class frmVenta
    Inherits frmMaster

#Region "Attributes"
    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Dim ListadocajaDelUsuario As New List(Of cajaUsuario)
    Dim idCajaUsuario As Integer
    Dim cajausuario As New List(Of cajaUsuario)
    Dim saldoMN As Decimal
    Dim precioSA As New ListadoPrecioSA
    Dim precio As New listadoPrecios
    Dim gridCaja As New GridGroupingControl
#End Region

#Region "Constructors"

    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        FormatoGridPequeño(dgvServicios, False)
        UbicarDocumento(IdDocumento)
        ToolStripLabel10.Text = Gempresas.NomEmpresa
        ToolStripLabel12.Text = GEstableciento.NombreEstablecimiento
        ConfiguracionColumnsGridArticulos()
        UbicarServicios()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Docking()
        FormatoGridPequeño(GridGroupingControl2, False)
        FormatoGridPequeño(dgvServicios, False)
        Loadcontroles()
        ConfiguracionInicio()
        GetTableGrid()
        ToolStripLabel10.Text = Gempresas.NomEmpresa
        ToolStripLabel12.Text = GEstableciento.NombreEstablecimiento
        'Panel7.Visible = False
        UbicarServicios()
        Me.Size = New Size(1205, 565)

        ConfiguracionColumnsGridArticulos()
        ToolStripComboBox2.Text = "TOTAL"
        ToolStripComboBox1.Text = "CREDITO"
    End Sub
#End Region

#Region "Methods"

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
        GridDataBoundGrid1.GridBoundColumns("cantidad").HeaderText = "Cant."
        GridDataBoundGrid1.GridBoundColumns("unidad").HeaderText = "U.M."
        GridDataBoundGrid1.GridBoundColumns("descripcion").Width = 220

        GridDataBoundGrid1.GridBoundColumns("btn").HeaderText = "Action"

        Dim style As GridStyleInfo = GridDataBoundGrid1.GridBoundColumns(14).StyleInfo
        style.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
        style.TextAlign = GridTextAlign.Default
        style.CellType = "PushButton"
        style.Description = "agregar"
        style.HorizontalAlignment = GridHorizontalAlignment.Center
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
        Dim idCajaUsuario As Integer
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

    Public Sub CargarTipoDeVenta(strTipoVenta As String)

        If (TIPO_VENTA.VENTA_CONTADO_PARCIAL = strTipoVenta) Then
            'GConfiguracion2 = New GConfiguracionModulo
            'configuracionModulo2(Gempresas.IdEmpresaRuc, "VT2", Me.Text)
            ToolStripComboBox2.Text = "POR ENTREGAR/PARCIAL"
            ToolStripComboBox1.Text = "CONTADO"
            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False
            'Me.btGrabar.Visible = False
            'ToolStripButton4.Visible = True
        ElseIf (TIPO_VENTA.VENTA_CONTADO_TOTAL = strTipoVenta) Then
            'GConfiguracion2 = New GConfiguracionModulo
            'configuracionModulo2(Gempresas.IdEmpresaRuc, "VT2", Me.Text)
            'Panel6.Visible = True
            'Me.Size = New Size(1163, 730)
            ToolStripComboBox2.Text = "TOTAL"
            ToolStripComboBox1.Text = "CONTADO"
            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False

            'Me.btGrabar.Visible = False
            'ToolStripButton4.Visible = True
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

            ToolStripComboBox1.Enabled = False
            ToolStripComboBox2.Enabled = False
            ToolStripComboBox2.Text = "TOTAL"
            ToolStripComboBox1.Text = "CREDITO"

            'Me.btGrabar.Visible = True
            'ToolStripButton4.Visible = False
        Else
            'GConfiguracion2 = New GConfiguracionModulo
            'configuracionModulo2(Gempresas.IdEmpresaRuc, "VT2", Me.Text)
            'Panel6.Visible = False
            'Me.Size = New Size(1163, 527)
            ToolStripComboBox2.Text = "TOTAL"
            ToolStripComboBox1.Text = "CREDITO"
            'Me.btGrabar.Visible = True
            'ToolStripButton4.Visible = False
        End If


    
    End Sub

    Private Sub Docking()

        ' Me.dockingManager1.DockControl(Me.PanelMontos, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 152)

        Me.dockingManager1.DockControl(Me.PanelCanasta, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
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

        If Not IsNothing(GFichaUsuarios) Then
            ToolStripButton1.Image = ImageListAdv1.Images(1)
            dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        Else
            dgvCompra.TableDescriptor.Columns("chPago").Width = 0
            ToolStripButton1.Image = ImageListAdv1.Images(0)
            GFichaUsuarios = Nothing
        End If

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1

        'confgiurando variables generales
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        '   lblPerido.Text = PeriodoGeneral
        txtTipoCambio.DecimalValue = TmpTipoCambio
        'txtAlmacen.Tag = TmpIdAlmacen
        'txtAlmacen.Text = TmpNombreAlmacen
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()


        'COMPROBANTE TIPO DOCUMENTOS

        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA

        'Dim list As New List(Of String)
        'list.Add("07")
        'list.Add("08")
        'list.Add("02")
        'listatabla = New List(Of tabladetalle)
        'listatabla = TablaSA.GetListaTablaDetalle(10, "1")

        'TIPO DE EXISTENCIA
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")
        Dim listaNoExistencias As New List(Of String)
        listaNoExistencias.Add("07")
        listaNoExistencias.Add("03")
        listaNoExistencias.Add("04")
        listaNoExistencias.Add("05")
        listaNoExistencias.Add("08")

        Dim consultaExistencia = (From n In listatabla _
                                 Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = consultaExistencia



    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtCliente.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtCliente.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function

    Dim colorx As New GridMetroColors()

    Public Sub UbicarServicios()
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("idServicio")

        For Each i In servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
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

    Public Sub llenarGrid(grid As GridGroupingControl, tag As Integer)
        If (tag = 1) Then

            gridCaja = grid
            CalculoPagos()
            Me.Cursor = Cursors.WaitCursor
            Try
                If Not Me.txtSerie.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de serie válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done serie"
                End If


                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de comprobante válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done número comprobante"

                End If


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
                    If Not txtCliente.Text.Trim.Length > 0 Then

                        MessageBox.Show("Ingrese el cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCliente.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    If txtCliente.Text.Trim.Length > 0 Then
                        If txtCliente.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtCliente.Select()
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

                '***********************************************************************
                If dgvCompra.Table.Records.Count > 0 Then
                    Me.lblEstado.Text = "Done!"
                    'If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    '    Grabar()
                    'Else
                    '    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    '    'If Filas > 0 Then
                    '    '    UpdateCompra()
                    '    'Else

                    '    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    '    '    Timer1.Enabled = True
                    '    '    PanelError.Visible = True
                    '    '    TiempoEjecutar(10)

                    '    'End If


                    'End If

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
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            '    GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                            txtSerie.Text = .serie
    '                            '    txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If

    '                        If cboTipoDoc.Text = "TICKET FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = .tipo1
    '                            '   GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
    '                            GConfiguracion2.Serie = .serie1
    '                            GConfiguracion2.ValorActual = .valorInicial1
    '                            txtSerie.Text = .serie1
    '                            '  txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
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

    '            '        'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '            '        'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '            '        'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            '        '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '            '        '    'txtEstableAlmacen.Text = .nombre
    '            '        'End With
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
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub


    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "TICKET BOLETA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    '    GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                    txtSerie.Text = RecuperacionNumeracion.serie
                    '    txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
                End If

                If cboTipoDoc.Text = "TICKET FACTURA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo1
                    '   GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie1
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial1
                    txtSerie.Text = RecuperacionNumeracion.serie1
                    '  txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

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

    Public Sub CargarPrecios()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New List(Of configuracionPrecio)
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("cboprecio").Appearance.AnyRecordFieldCell

        precio.AddRange(precioSA.ListadoPrecios())
        precio.Add(New configuracionPrecio With {.idPrecio = 0, .precio = "-Todos-"})

        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = precio ' precioSA.ListadoPrecios()
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

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
            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                txtFecha.Value = .fechaDoc
                lblPerido.Text = .fechaPeriodo
                cboTipoDoc.SelectedValue = .tipoDocumento
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc

                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

                        cboMoneda.SelectedValue = 1
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                        cboMoneda.SelectedValue = 2
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCliente.Tag = nEntidad.idEntidad
                txtCliente.Text = nEntidad.nombreCompleto

                txtTipoCambio.DecimalValue = .tipoCambio
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            'PanelCanasta.Visible = False
            Panel5.Visible = False
            For Each i In objDocCompraDet.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

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

                Select Case i.estadoPago
                    Case TIPO_VENTA.PAGO.COBRADO
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                End Select

                'Select Case i.bonificacion
                '    Case "S"
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
                '    Case "N"
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                'End Select

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

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim entidadSA As New entidadSA
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0


        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetUbicarTablaexistencia

        'ListadoProveedores = New List(Of entidad)
        'ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)
        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacen

        Dim lista As New List(Of String)
        lista.Add("01")
        lista.Add("03")
        tabla = tablaSA.GetListaTablaDetalle(10, "1")
        Dim tablaConsulta As List(Of tabladetalle) = (From i In tabla
                                                      Where lista.Contains(i.codigoDetalle) And i.idtabla = 10).ToList

        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = tablaConsulta
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

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

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
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("pagado", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("cantEntregar", GetType(Integer))
        dt.Columns.Add("cantPendiente", GetType(Integer))
        dt.Columns.Add("cboprecio")
        dgvCompra.DataSource = dt
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


            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosByAlmacen(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = "", .idEmpresa = Gempresas.IdEmpresaRuc}).OrderBy(Function(o) o.descripcion).ToList
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
            GridGroupingControl2.Table.Records.DeleteAll()
            If GridDataBoundGrid1.Model.RowCount > 0 Then
                UbicarUltimosPreciosXproducto()
            End If
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

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
                txtCliente.Text = .nombreCompleto
                txtCliente.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtCliente.Clear()
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
            txtTotalPagar.DecimalValue = total
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN
            DigitalGauge2.Value = total.ToString("N2")
        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            DigitalGauge2.Value = totalme.ToString("N2")
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


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

        'If gridGroupingControl1.Table.Records.Count > 0 Then
        '    gridGroupingControl1.Table.Records(0).SetCurrent()
        '    gridGroupingControl1.Table.Records(0).SetSelected(True)


        '    Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, gridGroupingControl1.Table.Records(0).GetValue("idItem"))

        '    If listaPrecios.Count > 0 Then
        '        AgregarAcanastaCodigoBarra(gridGroupingControl1.Table.CurrentRecord, listaPrecios(0))
        '    Else
        '        MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End If



    End Sub

    'Public Sub UbicarUltimosPreciosXproducto(r As Record)
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim dt As New DataTable("Historial de últimas entradas ")
    '    dt.Columns.Add("fecha")
    '    dt.Columns.Add("idPrecio")
    '    dt.Columns.Add("Precio")
    '    dt.Columns.Add("tipoConfig")
    '    dt.Columns.Add("tasa")
    '    dt.Columns.Add("Preciomn")
    '    dt.Columns.Add("Preciome")

    '    For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.fecha
    '        dr(1) = i.idPrecio
    '        dr(2) = i.descripcion
    '        dr(3) = IIf(i.tipo = "P", "%", "Fijo")
    '        dr(4) = i.valPorcentaje
    '        dr(5) = i.precioMN
    '        dr(6) = i.precioME
    '        dt.Rows.Add(dr)
    '    Next
    '    GridGroupingControl2.DataSource = dt
    '    GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    'End Sub


    'Sub Calculos()
    '    Dim colcantidad As Decimal = 0
    '    Dim cantidadDisponible As Decimal = 0
    '    Dim Igv As Decimal = 0
    '    Dim IgvME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    Dim colBI As Decimal = 0
    '    Dim colBIme As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colPrecUnitme As Decimal = 0
    '    Dim colDestinoGravado As Integer
    '    Dim colBonifica As String = Nothing

    '    Dim valPercepMN As Decimal = 0
    '    Dim valPercepME As Decimal = 0

    '    Dim colCostoMN As Decimal = 0
    '    Dim colCostoME As Decimal = 0
    '    Dim colPrecUnitAlmacen As Decimal = 0
    '    Dim colPrecUnitUSAlmacen As Decimal = 0

    '    Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
    '    Select Case strTipoExistencia
    '        Case "GS"
    '            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '            cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '            colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '            colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '            colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
    '            colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
    '            colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '            colCostoMN = 0 ' Math.Round(colcantidad * colPrecUnitAlmacen, 2)
    '            colCostoME = 0 ' Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

    '            totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' Math.Round(colcantidad * colPrecUnit, 2)
    '            totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' Math.Round(colcantidad * colPrecUnitme, 2)

    '            If colDestinoGravado = 1 Then
    '                Dim iva As Decimal = TmpIGV / 100
    '                colBI = (totalMN / (iva + 1))
    '                colBIme = (totalME / (iva + 1))

    '                Dim iv As Decimal = 0
    '                Dim iv2 As Decimal = 0
    '                iv = totalMN / (iva + 1)
    '                iv2 = totalME / (iva + 1)

    '                Igv = iv * (iva)
    '                IgvME = iv2 * (iva)
    '            Else

    '                colBI = 0
    '                colBIme = 0
    '                Igv = 0
    '                IgvME = 0

    '            End If

    '            '****************************************************************

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '            If colcantidad > 0 Then



    '                'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
    '                'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

    '            Else

    '            End If

    '            If (ToolStripComboBox2.Text = "TOTAL") Then
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", colcantidad)
    '            Else
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
    '            End If



    '            Select Case colDestinoGravado
    '                Case 1
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                Case 2
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '            End Select
    '            TotalTalesXcolumna()
    '        Case Else
    '            If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") > 0) Then
    '                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

    '                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
    '                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
    '                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '                    colCostoMN = (colcantidad * colPrecUnitAlmacen)
    '                    colCostoME = (colcantidad * colPrecUnitUSAlmacen)

    '                    totalMN = (colcantidad * colPrecUnit)
    '                    totalME = (colcantidad * colPrecUnitme)

    '                    If colDestinoGravado = 1 Then
    '                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
    '                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
    '                    Else
    '                        valPercepMN = 0
    '                        valPercepME = 0
    '                    End If

    '                    '****************************************************************
    '                    Dim iva As Decimal = TmpIGV / 100

    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '                    If colcantidad > 0 Then

    '                        colBI = (totalMN / (iva + 1))
    '                        colBIme = (totalME / (iva + 1))

    '                        Dim iv As Decimal = 0
    '                        Dim iv2 As Decimal = 0
    '                        iv = totalMN / (iva + 1)
    '                        iv2 = totalME / (iva + 1)

    '                        Igv = iv * (iva)
    '                        IgvME = iv2 * (iva)

    '                        'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
    '                        'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

    '                    Else
    '                        colBI = 0
    '                        colBIme = 0
    '                        Igv = 0
    '                        IgvME = 0
    '                    End If

    '                    Select Case colDestinoGravado
    '                        Case 1
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                        Case 2
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                    End Select
    '                    TotalTalesXcolumna()
    '                Else
    '                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
    '                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)

    '                    If (ToolStripComboBox2.Text = "TOTAL") Then
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", colcantidad)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", colcantidad)
    '                    Else
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
    '                    End If

    '                    txtTotalBase.Text = 0.0
    '                    txtTotalBase2.Text = 0.0
    '                    txtTotalIva.Text = 0.0
    '                    lblTotalPercepcion.Text = 0.0
    '                    txtTotalPagar.Text = 0.0
    '                    PanelError.Visible = True
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)
    '                End If
    '            Else
    '                lblEstado.Text = "La cantidad debe ser mayor a cero"
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '            End If

    '    End Select
    'End Sub

    'Sub tratamientoPagosDefautl()
    '    Dim total As Decimal = 0
    '    dgvPagos.Table.Records.DeleteAll()
    '    lsvPagosRegistrados.Items.Clear()
    '    Dim cajaBE = (From a In cajausuario).FirstOrDefault
    '    If Not IsNothing(cajaBE) Then
    '        GridPago(cajaBE)
    '    End If

    '    For Each r As Record In dgvCompra.Table.Records
    '        total = r.GetValue("totalmn")
    '        r.SetValue("pagado", total)
    '        r.SetValue("estado", "NO")
    '    Next

    'End Sub

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


                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                'colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                'colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                'colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                'cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                'colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                'colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                'colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                'colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                'colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = 0 ' Math.Round(colcantidad * colPrecUnitAlmacen, 2)
                colCostoME = 0 ' Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

                totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' Math.Round(colcantidad * colPrecUnit, 2)
                totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' Math.Round(colcantidad * colPrecUnitme, 2)

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

                'If colDestinoGravado = 1 Then
                '    Dim iva As Decimal = TmpIGV / 100
                '    colBI = (totalMN / (iva + 1))
                '    colBIme = (totalME / (iva + 1))

                '    Dim iv As Decimal = 0
                '    Dim iv2 As Decimal = 0
                '    iv = totalMN / (iva + 1)
                '    iv2 = totalME / (iva + 1)

                '    Igv = iv * (iva)
                '    IgvME = iv2 * (iva)
                'Else

                '    colBI = 0
                '    colBIme = 0
                '    Igv = 0
                '    IgvME = 0

                'End If

                '****************************************************************

                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                If colcantidad > 0 Then



                    'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                    'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                Else

                End If

                If (ToolStripComboBox2.Text = "TOTAL") Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", colcantidad)
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
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

                'Select Case colDestinoGravado
                '    Case 1
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                '    Case 2
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
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
                        txtTotalPagar.Text = 0.0
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

    Sub ConteoLabelVentas()
        lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
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

            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


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

    Sub CalculosNacional()
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

        If ((Me.dgvCompra.Table.Records.Count > 0)) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex") / txtTipoCambio.DecimalValue)
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("pume"))
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = CDec(colcantidad * colPrecUnitAlmacen)
                    colCostoME = CDec(CDec((colcantidad * colPrecUnitAlmacen) / txtTipoCambio.DecimalValue))

                    totalMN = CDec(colcantidad * colPrecUnit)
                    totalME = (CDec((colcantidad * colPrecUnit) / txtTipoCambio.DecimalValue))

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN") / txtTipoCambio.DecimalValue)
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then

                        colBI = CDec(totalMN / 1.18)
                        colBIme = CDec(CDec((totalMN / 1.18) / txtTipoCambio.DecimalValue))

                        Igv = CDec(colBI * (TmpIGV / 100))
                        IgvME = CDec((colBI * (TmpIGV / 100)) / txtTipoCambio.DecimalValue)

                        'colIGV = ((colMN / 1.18) * 0.18) ' (colBI * 0.18)
                        'colIGV_ME = ((colME / 1.18) * 0.18) ' (colBI_ME * 0.18)

                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then
                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex") / txtTipoCambio.DecimalValue)
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("pume"))
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")


                        colCostoMN = CDec(colcantidad * colPrecUnitAlmacen)
                        colCostoME = CDec((colcantidad * colPrecUnitAlmacen) / txtTipoCambio.DecimalValue)

                        totalMN = CDec(colcantidad * colPrecUnit)
                        totalME = (CDec((colcantidad * colPrecUnit) / txtTipoCambio.DecimalValue))

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN") / txtTipoCambio.DecimalValue)
                        Else
                            valPercepMN = 0
                            valPercepME = 0

                        End If

                        '****************************************************************
                        colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = CDec(totalMN / 1.18)
                            colBIme = (CDec((totalMN / 1.18) / txtTipoCambio.DecimalValue))

                            Igv = CDec(colBI * (TmpIGV / 100))
                            IgvME = (CDec((colBI * (TmpIGV / 100)) / txtTipoCambio.DecimalValue))

                            'colIGV = ((colMN / 1.18) * 0.18) ' (colBI * 0.18)
                            'colIGV_ME = ((colME / 1.18) * 0.18) ' (colBI_ME * 0.18)

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
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
                        txtTotalBase.Text = 0.0
                        '    txtBonifica.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar.Text = 0.0

                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
            End Select
        End If


    End Sub

    Public Sub AgregarAcanastaCodigoBarra(r As Record, precio As configuracionPrecioProducto)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        'If rbMenor.Checked = True Then
        '    valTipoVenta = "MN"
        valPUmn = precio.precioMN
        valPUme = precio.precioME
        'ElseIf rbMayor.Checked = True Then
        '    valTipoVenta = "MY"
        '    valPUmn = lblMayor.Value ' .Cells(14).Value
        '    valPUme = lblMayorME.Value ' .Cells(15).Value
        'ElseIf rbgmayor.Checked = True Then
        '    valTipoVenta = "GMY"
        '    valPUmn = lblGMayor.Value ' .Cells(14).Value
        '    valPUme = lblGMayorME.Value '.Cells(15).Value
        'End If
        With productoSA.InvocarProductoID(r.GetValue("idItem"))
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", r.GetValue("destino"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", r.GetValue("idItem"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", r.GetValue("unidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", r.GetValue("cantidad"))
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

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", r.GetValue("puKardexmn"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", r.GetValue("puKardexme"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", r.GetValue("idalmacen"))
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", r.GetValue("almacen"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")

            'Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", gridGroupingControl1.Table.CurrentRecord.GetValue("idEmpresa"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)

            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


    End Sub

    Sub CalculosExtranjera()
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
        '  Dim tipo As String

        'tipo = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

        If (dgvCompra.Table.Records.Count > 0) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex"))
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("pumn"))
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = (CDec((colcantidad * colPrecUnitUSAlmacen) * txtTipoCambio.DecimalValue))
                    colCostoME = (colcantidad * colPrecUnitUSAlmacen)

                    totalMN = (CDec((colcantidad * colPrecUnitme) * txtTipoCambio.DecimalValue))
                    totalME = (colcantidad * colPrecUnitme)

                    If colDestinoGravado = 1 Then
                        valPercepMN = (Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME") * txtTipoCambio.DecimalValue)
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then

                        colBI = (CDec((totalME / 1.18) * txtTipoCambio.DecimalValue))
                        colBIme = (totalME / 1.18)

                        Igv = (CDec((colBIme * (TmpIGV / 100)) * txtTipoCambio.DecimalValue))
                        IgvME = (colBIme * (TmpIGV / 100))

                        'colIGV = ((colMN / 1.18) * 0.18) ' (colBI * 0.18)
                        'colIGV_ME = ((colME / 1.18) * 0.18) ' (colBI_ME * 0.18)

                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex"))
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("pumn"))
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")


                        colCostoMN = (colcantidad * colPrecUnitAlmacen)
                        colCostoME = (colcantidad * colPrecUnitUSAlmacen)


                        totalMN = (CDec((colcantidad * colPrecUnitme) * txtTipoCambio.DecimalValue))
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


                        'If (Not IsNothing(Me.dgvCompra.Table.CurrentRecord)) Then
                        '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        'End If


                        If colcantidad > 0 Then


                            colBI = (CDec((totalME / 1.18) * txtTipoCambio.DecimalValue))
                            colBIme = (totalME / 1.18)

                            Igv = (CDec((colBIme * (TmpIGV / 100)) * txtTipoCambio.DecimalValue))
                            IgvME = (colBIme * (TmpIGV / 100))

                            'colIGV = ((colMN / 1.18) * 0.18) ' (colBI * 0.18)
                            'colIGV_ME = ((colME / 1.18) * 0.18) ' (colBI_ME * 0.18)

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
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
                        txtTotalBase.Text = 0.0
                        '    txtBonifica.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar.Text = 0.0

                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
            End Select
        Else

        End If


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
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = (VC / txtTipoCambio.DecimalValue)

                'totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                'totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme")
                'Igv = Me.dgvCompra.Table.CurrentRecord.GetValue("igvmn")
                'IgvME = Me.dgvCompra.Table.CurrentRecord.GetValue("igvme")

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
                    Case 2
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
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
                End Select
                TotalTalesXcolumna()
            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                    VCme = (VC / txtTipoCambio.DecimalValue)

                    'totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    'totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme")
                    'Igv = Me.dgvCompra.Table.CurrentRecord.GetValue("igvmn")
                    'IgvME = Me.dgvCompra.Table.CurrentRecord.GetValue("igvme")

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
                        Case 2
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
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
                    txtTotalBase.Text = 0.0
                    '  txtBonifica.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select

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

    '        'GetListadoProductosParaVentaXproductoEmpresa anterior por tipo de existencia esta en todo asi las bventas ojo

    '        For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproductoEmpresaFull(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
    '            If CDec(i.cantidad) > 0 Then
    '                Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
    '                Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

    '                'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


    '                'If Not IsNothing(lista) Then
    '                '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
    '                '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
    '                '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
    '                '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
    '                '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
    '                '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
    '                '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
    '                '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
    '                '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
    '                '        'cdetalleMenor = .detalleMenor
    '                '        'cdetalleMayor = .detalleMayor
    '                '        'cdetalleGMayor = .detalleGMayor
    '                '    End With
    '                'Else
    '                '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
    '                '    lblEstado.Image = My.Resources.warning2
    '                'End If

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
    '        'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
    '        Me.gridGroupingControl1.TableDescriptor.Columns("idEmpresa").Width = 0
    '        Me.gridGroupingControl1.TableDescriptor.Columns("tipoExistencia").Width = 40
    '        gridGroupingControl1.GroupDropPanel.Visible = True
    '        gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
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

    '        For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproductoXAlmacenFull(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
    '            'For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproductoXAlmacen(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
    '            If CDec(i.cantidad) > 0 Then
    '                Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
    '                Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

    '                'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


    '                'If Not IsNothing(lista) Then
    '                '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
    '                '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
    '                '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
    '                '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
    '                '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
    '                '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
    '                '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
    '                '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
    '                '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
    '                '        'cdetalleMenor = .detalleMenor
    '                '        'cdetalleMayor = .detalleMayor
    '                '        'cdetalleGMayor = .detalleGMayor
    '                '    End With
    '                'Else
    '                '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
    '                '    lblEstado.Image = My.Resources.warning2
    '                'End If

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
    '        'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
    '        Me.gridGroupingControl1.TableDescriptor.Columns("idEmpresa").Width = 0
    '        Me.gridGroupingControl1.TableDescriptor.Columns("tipoExistencia").Width = 40
    '        gridGroupingControl1.GroupDropPanel.Visible = True
    '        gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)


    '    End Try
    'End Sub


    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = GFichaUsuarios.IdCajaDestino,
              .descripcion = GFichaUsuarios.NomCajaDestinb,
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
        nAsiento.periodo = lblPerido.Text
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtCliente.Tag)
        nAsiento.nombreEntidad = txtCliente.Text
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
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "20111"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
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
        nAsiento.periodo = lblPerido.Text
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = CInt(txtCliente.Tag)
        nAsiento.nombreEntidad = txtCliente.Text
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
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = usuario.idusuario
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next

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
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = CInt(txtCliente.Tag) ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
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
            nMovimiento.cuenta = "7041"
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
        'For Each r As Record In dgvCompra.Table.Records
      

    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = txtCliente.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    'Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
    '    Dim nMovimiento As New movimiento
    '    nMovimiento = New movimiento With {
    '          .cuenta = "1212",
    '          .descripcion = txtCliente.Text,
    '          .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
    '          .monto = cMonto,
    '          .montoUSD = cMontoUS,
    '          .fechaActualizacion = DateTime.Now,
    '          .usuarioActualizacion = "Jiuni"}

    '    Return nMovimiento
    'End Function

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
                nDocumentoCaja.tipoDoc = cboTipoDoc.SelectedValue 'GConfiguracion2.TipoComprobante
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.nroDoc = txtSerie.Text 'GConfiguracion2.Serie
                nDocumentoCaja.idOrden = Nothing
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        nDocumentoCaja.moneda = 1

                    Case "EXTRANJERO"
                        nDocumentoCaja.moneda = 2
                End Select
                nDocumentoCaja.idEntidad = Val(txtCliente.Tag)
                nDocumentoCaja.entidad = txtCliente.Text
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                nDocumentoCaja.nrodocEntidad = txtRuc.Text
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = lblPerido.Text
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = txtCliente.Tag
                End If
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtCliente.Tag
                End If
                objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                objCaja.NumeroDocumento = txtSerie.Text ' GConfiguracion2.Serie
                objCaja.numeroOperacion = i.GetValue("numOper")
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_GENERAL
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

        'OJO LA CUENTA CONTABLE
        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = txtCliente.Text
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
                obj.fecha = txtFecha.Value
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = FormatNumber(Decimal.Parse(i.SubItems(4).Text), 2) 'CDbl(i.SubItems(4).Text)'CDbl(i.SubItems(4).Text)
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

    Sub Grabar()
        Dim FichaEFSaldo As New GFichaUsuario
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
        Dim TipoCobro As String
        Dim TipoEntrega As String
        Dim tipoEstado As String
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim listacondicion As New List(Of documentoguiaDetalleCondicion)

        Dim proveedor As String
        Dim idProveedor As Integer
        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = cboTipoDoc.SelectedValue
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
        ndocumento.idEntidad = Val(txtCliente.Tag)
        ndocumento.entidad = txtCliente.Text
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.nrodocEntidad = txtRuc.Text
        ndocumento.tipoOperacion = "01"
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
            proveedor = txtCliente.Text
            idProveedor = CInt(txtCliente.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
                  .TipoDocNumeracion = Nothing,
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = cboTipoDoc.SelectedValue,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .fechaConfirmacion = txtFecha.Value,
                  .serie = txtSerie.Text.Trim,
                  .serieVenta = txtSerie.Text,
                  .numeroDoc = txtNumero.Text.Trim,
                  .numeroVenta = CInt(txtNumero.Text),
                  .numeroDocNormal = txtNumero.Text.Trim,
                    .idCliente = CInt(idProveedor),
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
                  .tipoVenta = TIPO_VENTA.VENTA_GENERAL,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .glosa = txtGlosa.Text.Trim,
                  .terminos = ToolStripComboBox1.Text,
                  .fechaVcto = dptFechaVencimiento.Value,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta
        'tipoEstado,

        For Each r As Record In dgvCompra.Table.Records

            'If CDec(r.GetValue("cantidad")) <= 0 Then
            '    MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
            '    Exit Sub
            'End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            objDocumentoVentaDet = New documentoventaAbarrotesDet
            Select Case ToolStripComboBox1.Text
                Case "CONTADO"
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = txtSerie.Text.Trim
            objDocumentoVentaDet.NumDoc = txtNumero.Text.Trim
            objDocumentoVentaDet.TipoDoc = cboTipoDoc.SelectedValue
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = 0
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")


            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) < 0 Then
                    lblEstado.Text = "La cantidad debe ser mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If


                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                    'objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoVentaDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If
            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0
            objDocumentoVentaDet.estadoEntrega = TipoEntrega

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

            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' (CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()))
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) '(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()))


            If (ToolStripComboBox2.Text = "TOTAL") Then
                objDocumentoVentaDet.stock = 1
            End If
            'Dim cat = r.GetValue("cat")

            'If cat.ToString.Trim.Length > 0 Then
            '    objDocumentoVentaDet.categoria = r.GetValue("cat")
            'Else


            'If (ToolStripComboBox1.Text = "CONTADO") Then
            '    ndocumento.ListaCustomDocumento = ListaDocumentoCaja()
            'End If


            'If (ToolStripComboBox2.Text = "ENTREGAR") Then
            '    'GuiaRemision(ndocumento)
            'Else
            '    Dim condicion As New documentoguiaDetalleCondicion

            '    condicion = New documentoguiaDetalleCondicion
            '    With condicion
            '        '.idDocumento = r.GetValue("idDocumento")
            '        '.secuencia = r.GetValue("secuencia")
            '        .cantConforme = r.GetValue("cantidad")
            '        .descripcionCondicion = r.GetValue("item")
            '        .cantObservado = 0
            '        .estadoCondcion = r.GetValue("cantidad")
            '        .usuarioActualizacion = "MAYKOL"
            '        .nombreRececpcion = ""
            '        .dniRecepcion = ""
            '        .status = 1
            '        .fechaActualizacion = Date.Now
            '    End With
            '    listacondicion.Add(condicion)

            'End If


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
            objDocumentoVentaDet.tipoCambio = txtTipoCambio.Text

            'End If
            'objDocumentoVentaDet.idAlmacenOrigen = txtAlmacen.Tag
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now
            'objDocumentoVentaDet.estadoMovimiento = Date.Now
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle


        'Dim consultaPagados = (From n In ListaDetalle
        '                 Where n.estadoPago = TIPO_VENTA.PAGO.COBRADO).Count

        If (ToolStripComboBox1.Text = "CONTADO") Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCaja()
        End If


        If (ToolStripComboBox2.Text = "TOTAL") Then
            GuiaRemision(ndocumento)
        End If


        'If consultaPagados > 0 Then
        '    AsientoItemPagado()
        'End If

        Dim consultaNoPagados = (From n In ListaDetalle
                       Where n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count

        If consultaNoPagados > 0 Then
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        End If

        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle _
                                                                       Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias)
        End If

        Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle _
                                                                       Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        If listaServicios.Count > 0 Then
            AsientoVentaServicios(listaServicios)
        End If

        ndocumento.asiento = ListaAsientonTransito

        Dim listaTotalAlmacen As Integer = 0
        Dim SinlistaTotalAlmacen As Integer = 0

        If (ToolStripComboBox1.Text = "CONTADO") Then
            listaTotalAlmacen = VentaSA.SaveVentaCobradaContado(ndocumento)
        Else

            Dim documentoOriginal As Integer

            documentoOriginal = VentaSA.GrabarVentaGeneralCredito(ndocumento)




            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

            Else
                If tmpConfigInicio IsNot Nothing Then
                    If tmpConfigInicio.cronogramaPagos = True Then
                        ' If Not ComboBoxAdv2.Text = "DE CONTADO" Then
                        If MessageBoxAdv.Show("¿Desea Negociar?" + vbCrLf + vbCrLf + Space(15) + txtFecha.Text, txtFecha.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


                            With frmNegociacionCobross
                                .lblIdDocumento.Text = documentoOriginal
                                .txtImporteCompramn.Value = TotalesXcanbeceras.TotalMN
                                .txtImporteComprame.Value = TotalesXcanbeceras.TotalME
                                .txttipocambio.Value = txtTipoCambio.DecimalValue
                                ' .txtMoneda.Text = IIf(cboMoneda.SelectedValue = 1, "1", "2")
                                If cboMoneda.SelectedValue = "1" Then
                                    .txtMoneda.Text = "NAC"
                                ElseIf cboMoneda.SelectedValue = "2" Then
                                    .txtMoneda.Text = "EXT"
                                End If
                                .txtSerie.Text = txtSerie.Text.Trim
                                .txtNumero.Text = txtNumero.Text
                                .txtCliente.Text = txtCliente.Text
                                .txtCliente.Tag = CInt(txtCliente.Tag)
                                .txtRuc.Text = txtRuc.Text
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With

                        Else

                        End If

                        'End If
                    End If
                End If

            End If

        End If

        If (listaTotalAlmacen <> 0 And SinlistaTotalAlmacen = 0) Then
            lblEstado.Text = "venta registrada!"
            Dispose()

        ElseIf (listaTotalAlmacen = 0 And SinlistaTotalAlmacen = 0) Then
            lblEstado.Text = "venta registrada!"
            Dispose()

        Else
            lblEstado.Text = "Excedio la cantidad de venta"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        End If
    End Sub

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
            nAsiento.idEntidad = CInt(txtCliente.Tag)
            nAsiento.nombreEntidad = txtCliente.Text
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
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "1212"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
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
            .idEntidad = CInt(txtCliente.Tag)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .estado = TipoGuia.Entregado
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
                If txtSerie.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.serie = txtSerie.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                End If
                If txtNumero.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
                Else
                    Throw New Exception("Ingrese el nùmero de la guía!")
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idProducto")
                documentoguiaDetalle.descripcionItem = r.GetValue("item")
                documentoguiaDetalle.destino = r.GetValue("gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("cantidad"))
                documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                documentoguiaDetalle.importeMN = CDec(r.GetValue("totalmn"))
                documentoguiaDetalle.importeME = CDec(r.GetValue("totalme"))
                documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                documentoguiaDetalle.nombreRecepcion = txtCliente.Text
                documentoguiaDetalle.dniRecepcion = txtRuc.Text
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

    Public Sub CargarCajasTipo(idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA
        Try

            If (Not IsNothing(idpersona) And (idCajaUsuario) > 0) Then
                cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona})
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub cargarDatosCuentas()
        Dim cuentaUsuarioDetalleSA As New cajaUsuarioSA

        Dim objCuenta As New cajaUsuario

        objCuenta = cuentaUsuarioDetalleSA.UbicarUsuarioAbierto(usuario.IDUsuario)

        If (Not IsNothing(objCuenta)) Then
            idCajaUsuario = objCuenta.idcajaUsuario
        End If


    End Sub
#End Region

#Region "Events"

    'Private Sub frmVenta_Load(sender As Object, e As EventArgs)
    '    dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    '    dgvCompra.ShowRowHeaders = False

    '    'dgvPagos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    '    'dgvPagos.ShowRowHeaders = False
    '    CargarPrecios()
    'End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del cliente " & txtCliente.Text.Trim
                End If
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del cliente " & txtCliente.Text.Trim
        End If

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del cliente " & txtCliente.Text.Trim
                End If
                'cboMoneda.Select()
                txtCliente.Select()
                'txtProveedor.Focus()
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
                f.CaptionLabels(0).Text = "Cliente"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = DirectCast(f.Tag, entidad)
                    'Dim c = CType(f.Tag, entidad)
                    txtCliente.Text = c.nombreCompleto
                    txtCliente.Tag = c.idEntidad
                    txtRuc.Text = c.nrodoc
                    txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus


        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del cliente " & txtCliente.Text.Trim
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

    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs)
        If Not IsNothing(TotalesXcanbeceras) Then
            If cboMoneda.SelectedValue = 2 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                cboMoneda.SelectedValue = 2
            Else
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                cboMoneda.SelectedValue = 1

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
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = False
                End Select
            End If


        End If

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        '    Dim precioSA As New ConfiguracionPrecioProductoSA
        '    Dim precio As New configuracionPrecioProducto
        '    Select Case ColIndex

        '        Case 1 ' seleccionar precios de venta: Mayo,r menor, gran mayor
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

        '        Case 5 ' cantidad

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

        '            End Select


        '            Calculos()
        '            'tratamientoPagosDefautl()

        '            'Select Case strTipoEx
        '            '    Case "GS"
        '            '        Dim r As Record = dgvCompra.Table.CurrentRecord
        '            '        Dim cantida = r.GetValue("cantidad")
        '            '        If Not IsNothing(r) Then
        '            '            r.SetValue("cantPendiente", cantida)
        '            '            r.SetValue("cantEntregar", cantida)
        '            '            r.SetValue("canDisponible", cantida)
        '            '        End If

        '            '        If (ToolStripComboBox2.Text = "TOTAL") Then
        '            '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
        '            '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
        '            '        Else
        '            '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
        '            '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
        '            '            'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
        '            '        End If

        '            '        Select Case cboMoneda.SelectedValue
        '            '            Case 1
        '            '                CalculosNacional()
        '            '            Case 2
        '            '                CalculosExtranjera()
        '            '        End Select

        '            '    Case Else

        '            '        Select Case cboMoneda.SelectedValue
        '            '            Case 1
        '            '                CalculosNacional()
        '            '            Case 2
        '            '                CalculosExtranjera()
        '            '        End Select

        '            '        'Calculos()
        '            'End Select

        '        Case 6 'VALOR DE VENTA
        '            Select Case strTipoEx
        '                Case "GS"
        '                    CalculosGasto()
        '                Case Else

        '            End Select

        '    End Select
        'End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If


            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If


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
                If Not txtCliente.Text.Trim.Length > 0 Then

                    MessageBox.Show("Ingrese el cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCliente.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                If txtCliente.Text.Trim.Length > 0 Then
                    If txtCliente.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCliente.Select()
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

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                'If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                '    Grabar()
                'Else
                '    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                '    'If Filas > 0 Then
                '    '    UpdateCompra()
                '    'Else

                '    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                '    '    Timer1.Enabled = True
                '    '    PanelError.Visible = True
                '    '    TiempoEjecutar(10)

                '    'End If


                'End If

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

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
        '    UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If IsNothing(GFichaUsuarios) Then
            If TieneCuentaFinanciera() = True Then
                ToolStripButton1.Image = ImageListAdv1.Images(1)
                dgvCompra.TableDescriptor.Columns("chPago").Width = 0
                MessageBoxAdv.Show("Usuario iniciado!")
            Else

            End If
        Else

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

                            Me.dgvCompra.TableModel(RowIndex, 20).CellValue = "No Pagado"

                        Else
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 20).CellValue = "Pagado"



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

    Private Sub cboMoneda_SelectedIndexChanging(sender As Object, e As Tools.SelectedIndexChangingArgs) Handles cboMoneda.SelectedIndexChanging
        If Not IsNothing(TotalesXcanbeceras) Then
            If cboMoneda.SelectedValue = 2 Then
                'txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                'txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                'txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                'lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                CalculosExtranjera()

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                'cboMoneda.SelectedValue = 2
            Else
                'txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                'txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                'txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                'lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                CalculosNacional()

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                'cboMoneda.SelectedValue = 1

            End If
        End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If (ToolStripComboBox1.Text = "CONTADO") Then
            Dim ef As New EstadosFinancierosSA
            Dim cajaUsuario As New cajaUsuario
            Dim cajaUsuarioSA As New cajaUsuarioSA
            Dim usuarioSA As New UsuarioSA
            Dim usuarioxls As New Usuario
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                Me.btGrabar.Visible = False
                ToolStripButton4.Visible = True
                GConfiguracion = New GConfiguracionModulo
                configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
            Else
                ToolStripComboBox1.Text = "CREDITO"
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf (ToolStripComboBox1.Text = "CREDITO") Then
            Me.btGrabar.Visible = True
            ToolStripButton4.Visible = False
        End If
    End Sub

    'Private Sub PictureBox7_Click(sender As Object, e As EventArgs)
    '    Dim total As Decimal
    '    dgvPagos.Table.Records.DeleteAll()
    '    'lsvPagosRegistrados.Items.Clear()
    '    For Each r As Record In dgvCompra.Table.Records
    '        total = r.GetValue("totalmn")
    '        r.SetValue("pagado", total)
    '        r.SetValue("estado", "NO")
    '    Next
    '    'ObtenerDetallePedido()
    '    saldoMN = DigitalGauge2.Value
    'End Sub

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

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            txtCliente.Text = c.nombreCompleto
            txtRuc.Text = c.nrodoc
            txtCliente.Tag = c.idEntidad
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    'Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim totalSA As New TotalesAlmacenSA
    '    Try

    '        Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))

    '        If listaPrecios.Count > 0 Then
    '            ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
    '            AgregarAcanastaCodigoBarra(gridGroupingControl1.Table.CurrentRecord, listaPrecios(0))
    '        Else
    '            MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If


    '        'If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
    '        '    lblProducto.Text = String.Empty

    '        '    ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
    '        '    lblProducto.Text = String.Empty

    '        '    AgregarAcanastaCodigoBarra(gridGroupingControl1.Table.CurrentRecord, listaPrecios(0))

    '        '    'AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))

    '        'End If
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End Try

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
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

    Private Sub chIdentificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chIdentificacion.CheckedChanged
        If chIdentificacion.Checked = True Then
            txtCliente.Visible = False
            txtRuc.Visible = False
            PictureBox8.Visible = False
            Label3.Visible = False
            TXTcOMPRADOR.Visible = True
        Else
            GradientPanel3.Enabled = True
            txtCliente.Visible = True
            txtCliente.Enabled = True
            txtCliente.ReadOnly = False
            txtRuc.Visible = True
            PictureBox8.Visible = True
            Label3.Visible = False
            TXTcOMPRADOR.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

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
                If txtRuc.Text.Trim.Length > 0 Then
                    If txtRuc.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCliente.Select()
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

            With frmCajasXusuario
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = txtFecha.Value
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtNumero.Text
                .txtCliente.Text = txtCliente.Text
                .tipoVenta = TIPO_VENTA.VENTA_GENERAL
                .txtRuc.Text = txtRuc.Text
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

    Private Sub frmVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.F6) ' mayúsculas y minúsculas

                Me.Cursor = Cursors.WaitCursor
                Try

                    If Not txtSerie.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingresar un número de serie válido"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        lblEstado.Text = "Done serie"
                    End If

                    If Not txtNumero.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingresar un número de comprobante válido"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)

                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        lblEstado.Text = "Done número comprobante"

                    End If

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
                        If txtRuc.Text.Trim.Length > 0 Then
                            If txtRuc.ForeColor = Color.Black Then
                                MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txtCliente.Select()
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

                    With frmCajasXusuario
                        .DigitalGauge2.Value = DigitalGauge2.Value
                        .txtFecha.Value = txtFecha.Value
                        .txtTipoDoc.Text = cboTipoDoc.Text
                        .txtSerie.Text = txtSerie.Text
                        .txtNumero.Text = txtNumero.Text
                        .txtCliente.Text = txtCliente.Text
                        .txtRuc.Text = txtRuc.Text
                        .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
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

    Private Sub frmVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then

            Me.Cursor = Cursors.WaitCursor
            Try

                If Not txtSerie.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de serie válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done serie"
                End If

                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de comprobante válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done número comprobante"

                End If

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
                    If txtRuc.Text.Trim.Length > 0 Then
                        If txtRuc.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtCliente.Select()
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

                With frmCajasXusuario
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = txtFecha.Value
                    .txtTipoDoc.Text = cboTipoDoc.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtNumero.Text
                    .txtCliente.Text = txtCliente.Text
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
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


        ElseIf e.KeyCode = Keys.F6 Then
        End If
    End Sub

    Private Sub frmVenta_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F6 Then
            Me.Cursor = Cursors.WaitCursor
            Try

                If Not txtSerie.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de serie válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done serie"
                End If

                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un número de comprobante válido"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done número comprobante"

                End If

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
                    If txtRuc.Text.Trim.Length > 0 Then
                        If txtRuc.ForeColor = Color.Black Then
                            MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtCliente.Select()
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

                With frmCajasXusuario
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = txtFecha.Value
                    .txtTipoDoc.Text = cboTipoDoc.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtNumero.Text
                    .txtCliente.Text = txtCliente.Text
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_VENTA.VENTA_ANTICIPADA
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


        ElseIf e.KeyCode = Keys.F6 Then
        End If

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
            txtCliente.Text = c.nombreCompleto
            txtCliente.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        '  If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex ' ColIndex

                Case 1 ' seleccionar precios de venta: Mayo,r menor, gran mayor
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

                Case 5 ' cantidad

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

                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()

                    'Select Case strTipoEx
                    '    Case "GS"
                    '        Dim r As Record = dgvCompra.Table.CurrentRecord
                    '        Dim cantida = r.GetValue("cantidad")
                    '        If Not IsNothing(r) Then
                    '            r.SetValue("cantPendiente", cantida)
                    '            r.SetValue("cantEntregar", cantida)
                    '            r.SetValue("canDisponible", cantida)
                    '        End If

                    '        If (ToolStripComboBox2.Text = "TOTAL") Then
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        Else
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        End If

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '    Case Else

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '        'Calculos()
                    'End Select

                Case 6 'VALOR DE VENTA
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                        Case Else

                    End Select

            End Select
        End If


        '     End If
    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        '  If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex ' ColIndex

                Case 1 ' seleccionar precios de venta: Mayo,r menor, gran mayor
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

                Case 5 ' cantidad

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

                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()

                    'Select Case strTipoEx
                    '    Case "GS"
                    '        Dim r As Record = dgvCompra.Table.CurrentRecord
                    '        Dim cantida = r.GetValue("cantidad")
                    '        If Not IsNothing(r) Then
                    '            r.SetValue("cantPendiente", cantida)
                    '            r.SetValue("cantEntregar", cantida)
                    '            r.SetValue("canDisponible", cantida)
                    '        End If

                    '        If (ToolStripComboBox2.Text = "TOTAL") Then
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        Else
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        End If

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '    Case Else

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '        'Calculos()
                    'End Select

                Case 6 'VALOR DE VENTA
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                        Case Else

                    End Select

            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        '  If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex ' ColIndex

                Case 1 ' seleccionar precios de venta: Mayo,r menor, gran mayor
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

                Case 5 ' cantidad

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

                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()

                    'Select Case strTipoEx
                    '    Case "GS"
                    '        Dim r As Record = dgvCompra.Table.CurrentRecord
                    '        Dim cantida = r.GetValue("cantidad")
                    '        If Not IsNothing(r) Then
                    '            r.SetValue("cantPendiente", cantida)
                    '            r.SetValue("cantEntregar", cantida)
                    '            r.SetValue("canDisponible", cantida)
                    '        End If

                    '        If (ToolStripComboBox2.Text = "TOTAL") Then
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        Else
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        End If

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '    Case Else

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '        'Calculos()
                    'End Select

                Case 6 'VALOR DE VENTA
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                        Case Else

                    End Select

            End Select
        End If
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged
        Select Case cboTipoDoc.SelectedValue
            Case "23", "25", "34", "35", "48"
                txtSerie.MaxLength = 4

            Case "01", "03", "04", "06", "07", "08", "36"
                txtSerie.MaxLength = 4

            Case "05", "55"
                txtSerie.MaxLength = 1

            Case "56"
                txtSerie.MaxLength = 4

            Case "11"
                txtSerie.MaxLength = 20

            Case "12.1", "12" To "19"
                txtSerie.MaxLength = 20

            Case "21", "24", "26", "27", "28", "29", "30", "32", "37", "42", "43", "44", "45", "49", "87", "88"
                txtSerie.MaxLength = 20

        End Select
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged
        Select Case cboTipoDoc.SelectedValue
            Case "23", "25", "34", "35", "48"
                txtNumero.MaxLength = 7

            Case "01", "03", "04", "06", "07", "08", "36"
                txtNumero.MaxLength = 8

            Case "05", "55"
                txtNumero.MaxLength = 11

            Case "56"
                txtNumero.MaxLength = 11

            Case "11"
                txtNumero.MaxLength = 15

            Case "12.1", "12" To "19"
                txtNumero.MaxLength = 20

            Case "21", "24", "26", "27", "28", "29", "30", "32", "37", "42", "43", "44", "45", "49", "87", "88"
                txtNumero.MaxLength = 20

        End Select
    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        '  If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex ' ColIndex

                Case 1 ' seleccionar precios de venta: Mayo,r menor, gran mayor
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

                Case 5 ' cantidad

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

                    End Select


                    Calculos()
                    'tratamientoPagosDefautl()

                    'Select Case strTipoEx
                    '    Case "GS"
                    '        Dim r As Record = dgvCompra.Table.CurrentRecord
                    '        Dim cantida = r.GetValue("cantidad")
                    '        If Not IsNothing(r) Then
                    '            r.SetValue("cantPendiente", cantida)
                    '            r.SetValue("cantEntregar", cantida)
                    '            r.SetValue("canDisponible", cantida)
                    '        End If

                    '        If (ToolStripComboBox2.Text = "TOTAL") Then
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        Else
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 0)
                    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", pendiente)
                    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", pendiente)
                    '        End If

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '    Case Else

                    '        Select Case cboMoneda.SelectedValue
                    '            Case 1
                    '                CalculosNacional()
                    '            Case 2
                    '                CalculosExtranjera()
                    '        End Select

                    '        'Calculos()
                    'End Select

                Case 6 'VALOR DE VENTA
                    Select Case strTipoEx
                        Case "GS"
                            'CalculosGasto()
                        Case Else

                    End Select

            End Select
        End If
    End Sub

    Private Sub txtFiltrar_Click(sender As Object, e As EventArgs) Handles txtFiltrar.Click
        txtFiltrar.SelectAll()
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

    Private Sub txtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarCode.KeyPress
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

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        If GridDataBoundGrid1.Binder.RecordCount > 0 Then
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    Dim f As New frmNuevoPrecio
                    f.txtProducto.Tag = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem")
                    f.txtProducto.Text = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion")
                    f.txtGrav.Text = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case Else
                    MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        End If
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

#End Region

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

 
    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        chIdentificacion.Checked = False
        'chIdentificacion.Visible = True
        ToolStripLabel10.Text = Gempresas.NomEmpresa
        ToolStripLabel12.Text = GEstableciento.NombreEstablecimiento
        lblConteo.Visible = True

        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Agregar nuevo precio")
        ContextMenuStrip.Items.Add("Ver tabla de precios")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

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

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

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

    Private Sub frmVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
End Class