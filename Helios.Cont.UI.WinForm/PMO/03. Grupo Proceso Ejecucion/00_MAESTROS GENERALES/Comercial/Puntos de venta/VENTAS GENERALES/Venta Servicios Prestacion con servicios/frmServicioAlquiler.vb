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
Public Class frmServicioAlquiler
    Inherits frmMaster
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Dim time As Integer = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Docking()
        GridCFG(gridGroupingControl1)
        GridCFG(GridGroupingControl2)
        GridCFG(dgvCompra)
        Loadcontroles()
        ConfiguracionInicio()
        GetTableGrid()

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
    End Sub

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        UbicarDocumento(intIdDocumento)
    End Sub


    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal
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

    Private Sub Docking()
        Me.dockingManager1.DockControl(Me.PanelCanasta, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        dockingManager1.DockControlInAutoHideMode(PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        Me.dockingManager1.DockControl(Me.Panel5, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        dockingManager1.DockControlInAutoHideMode(PanelGarantia, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 377)

        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        dockingManager1.SetDockLabel(PanelCanasta, "Canasta de Existencias")
        dockingManager1.SetDockLabel(Panel5, "Servicios")
        dockingManager1.SetDockLabel(PanelGarantia, "Garantías")
        dockingManager1.SetDockVisibility(PanelGarantia, False)
        dockingManager1.CloseEnabled = False
    End Sub

    Sub ConfiguracionInicio()
        Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen

        'If Not IsNothing(GFichaUsuarios) Then
        '    ToolStripButton1.Image = ImageListAdv1.Images(1)
        '    dgvCompra.TableDescriptor.Columns("chPago").Width = 50
        'Else
        '    dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        '    ToolStripButton1.Image = ImageListAdv1.Images(0)
        '    GFichaUsuarios = Nothing
        'End If

        'confgiurando variables generales
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        lblPerido.Text = PeriodoGeneral
        txtTipoCambio.DecimalValue = TmpTipoCambio
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
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

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim colorx As New GridMetroColors()

#Region "Métodos"
    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(cboAlmacen.SelectedValue, r.GetValue("idItem"))
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
                PeriodoGeneral = .fechaPeriodo
                cboTipoDoc.SelectedValue = .tipoDocumento
                Select Case .moneda
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70

                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCliente.Tag = nEntidad.idEntidad
                txtCliente.Text = nEntidad.nombreCompleto

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

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim almacenSA As New almacenSA
        Dim servicioSA As New servicioSA


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        cboServicio.DisplayMember = "descripcion"
        cboServicio.ValueMember = "idServicio"
        cboServicio.DataSource = servicioSA.ListadoServiciosHijosXtipo(New servicio With {.codigo = "VT"})

        'cboCuenta.DisplayMember = "cuenta"
        'cboCuenta.ValueMember = "cuenta"
        'cboCuenta.DataSource = cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "70")

        'Dim dtPresentacion As New DataTable
        'dtPresentacion.Columns.Add("IDPres")
        'dtPresentacion.Columns.Add("NamePres")

        'For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)
        '    lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
        'Next
        'lstCategoria.DisplayMember = "Name"
        'lstCategoria.ValueMember = "Id"


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
                txtCliente.Text = .nombreCompleto
                txtCliente.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
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

        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

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
            totalVC += CDec(r.GetValue("vcmn"))
            totalVCme += CDec(r.GetValue("vcme"))

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
        If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            txtBonifica.DecimalValue = totalDesc
            txtTotalBase.DecimalValue = totalVC
            txtTotalIva.DecimalValue = totalIVA
            txtTotalPagar.DecimalValue = total
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        Else

            txtBonifica.DecimalValue = totalDescme
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


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
                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = Math.Round(colcantidad * colPrecUnitAlmacen, 2)
                colCostoME = Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

                totalMN = Math.Round(colcantidad * colPrecUnit, 2)
                totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                If colDestinoGravado = 1 Then
                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0

                End If

                '****************************************************************
                colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad.ToString("N2"))
                If colcantidad > 0 Then

                    colBI = Math.Round(totalMN / 1.18, 2)
                    colBIme = Math.Round(totalME / 1.18, 2)

                    Igv = Math.Round(colBI * (TmpIGV / 100), 2)
                    IgvME = Math.Round(colBIme * (TmpIGV / 100), 2)

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
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    Case 2
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME.ToString("N2"))
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
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = Math.Round(colcantidad * colPrecUnitAlmacen, 2)
                    colCostoME = Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

                    totalMN = Math.Round(colcantidad * colPrecUnit, 2)
                    totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad.ToString("N2"))
                    If colcantidad > 0 Then

                        colBI = Math.Round(totalMN / 1.18, 2)
                        colBIme = Math.Round(totalME / 1.18, 2)

                        Igv = Math.Round(colBI * (TmpIGV / 100), 2)
                        IgvME = Math.Round(colBIme * (TmpIGV / 100), 2)

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
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME.ToString("N2"))
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
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    txtTotalBase.Text = 0.0
                    txtBonifica.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
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
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = Math.Round(VC / txtTipoCambio.DecimalValue, 2)

                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = Math.Round(colcantidad * colPrecUnitAlmacen, 2)
                colCostoME = Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

                totalMN = Math.Round(colcantidad * colPrecUnit, 2)
                totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                If colDestinoGravado = 1 Then
                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0

                End If

                '****************************************************************
                colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad.ToString("N2"))
                If colcantidad > 0 AndAlso VC > 0 Then
                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepMN

                    colPrecUnit = Math.Round(VC / colcantidad, 2)
                    colPrecUnitme = Math.Round(VCme / colcantidad, 2)
                ElseIf colcantidad = 0 Then
                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
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
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                    Case 2
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
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
                    VCme = Math.Round(VC / txtTipoCambio.DecimalValue, 2)

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = Math.Round(colcantidad * colPrecUnitAlmacen, 2)
                    colCostoME = Math.Round(colcantidad * colPrecUnitUSAlmacen, 2)

                    totalMN = Math.Round(colcantidad * colPrecUnit, 2)
                    totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad.ToString("N2"))
                    If colcantidad > 0 AndAlso VC > 0 Then
                        Igv = Math.Round(VC * (TmpIGV / 100), 2)
                        IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepMN

                        colPrecUnit = Math.Round(VC / colcantidad, 2)
                        colPrecUnitme = Math.Round(VCme / colcantidad, 2)
                    ElseIf colcantidad = 0 Then
                        Igv = Math.Round(VC * (TmpIGV / 100), 2)
                        IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
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
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                        Case 2
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
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
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME.ToString("N2"))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    txtTotalBase.Text = 0.0
                    txtBonifica.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
    End Sub

    Dim precioSA As New ListadoPrecioSA
    Dim precio As New listadoPrecios

    Public Sub AgregarAcanasta(r As Record)
        Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
        valPUme = Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciome")

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
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "01")
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
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", cboAlmacen.SelectedValue)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idPrecio"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With

    End Sub

    Private Sub AceptarPrecioProducto(intDisponible As Decimal)
        AgregarAcanasta(gridGroupingControl1.Table.CurrentRecord)

    End Sub

    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
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
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

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

            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproducto(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = cboAlmacen.Text})
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2)
                    Dim valPrecUnitarioUS As Decimal = Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2)

                    'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


                    'If Not IsNothing(lista) Then
                    '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                    '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
                    '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
                    '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                    '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                    '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
                    '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
                    '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
                    '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
                    '        'cdetalleMenor = .detalleMenor
                    '        'cdetalleMayor = .detalleMayor
                    '        'cdetalleGMayor = .detalleGMayor
                    '    End With
                    'Else
                    '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                    '    lblEstado.Image = My.Resources.warning2
                    'End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.origenRecaudo
                    dr(1) = i.idItem
                    dr(2) = i.descripcion
                    dr(3) = i.unidadMedida
                    dr(4) = i.Presentacion
                    dr(5) = i.NombrePresentacion
                    dr(6) = i.cantidad
                    dr(7) = valPrecUnitario
                    dr(8) = valPrecUnitarioUS
                    dr(9) = i.importeSoles
                    dr(10) = i.importeDolares

                    dr(11) = cprecioVentaFinalMenorMN
                    dr(12) = cprecioVentaFinalMenorME
                    dr(13) = cprecioVentaFinalMayorMN
                    dr(14) = cprecioVentaFinalMayorME
                    dr(15) = cprecioVentaFinalGMayorMN
                    dr(16) = cprecioVentaFinalGMayorME
                    dt.Rows.Add(dr)
                End If
            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
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
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
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


        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
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
        ndocumento.tipoOperacion = "01"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = PeriodoGeneral,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = Nothing,
                  .nombrePedido = TXTcOMPRADOR.Text.Trim,
                  .moneda = "1",
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
                  .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = txtGlosa.Text.Trim,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            Select Case r.GetValue("valPago")
                Case "Pagado"
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = Nothing
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = Nothing
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
            objDocumentoVentaDet.fechaVcto = Nothing

            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.categoria = r.GetValue("cat")
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            Dim listaTotalAlmacen As Integer = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

            If (Not IsNothing(listaTotalAlmacen)) Then
                lblEstado.Text = "venta registrada!"
                ' statusForm.lblMensaje.Text = "..estableciendo..."
                '   Dim strNumDoc As String = String.Format("{0:00000}", Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(xcod).numeroDoc))
                Dim strNumDoc As String = Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(listaTotalAlmacen).numeroDoc)
                'TimerCustom.Enabled = True
                'TimerCustom.Start()
                Dim statusForm As New frmMensajeCodigoVenta
                statusForm.StartPosition = FormStartPosition.CenterScreen
                statusForm.lblMensaje.Text = strNumDoc '.Replace("0", "")
                statusForm.ShowDialog()

                ' statusForm.Dispose()
                Dispose()
            Else
                lblEstado.Text = "Excedio la cantidad de venta"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                limpiarCajas()
            End If
        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If

    End Sub
    Sub limpiarCajas()
        txtFiltrar.Clear()
        gridGroupingControl1.Table.Records.DeleteAll()
        GridGroupingControl2.Table.Records.DeleteAll()
        dgvCompra.Table.Records.DeleteAll()
    End Sub

#End Region

    Private Sub frmServicioAlquiler_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmServicioAlquiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim N As New ListViewItem()
        N.Text = cboGarantia.Text
        N.SubItems.Add(txtDetalle.Text)
        lavGarantia.Items.Add(N)
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If lavGarantia.SelectedItems.Count > 0 Then
            lavGarantia.SelectedItems(0).Remove()
        End If
    End Sub

    Private Sub gridGroupingControl1_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles gridGroupingControl1.SelectedRecordsChanged
        Me.Cursor = Cursors.WaitCursor
        GridGroupingControl2.Table.Records.DeleteAll()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                    lblProducto.Text = String.Empty
                    AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))
                    If dgvCompra.Table.Records.Count > 0 Then
                        ' CalculosRecorrido()
                    End If
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtCliente.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtCliente.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                If TXTcOMPRADOR.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por " & cboTipoDoc.Text & Space(1) & Space(1) & "del comprador " & TXTcOMPRADOR.Text.Trim
                End If
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente.Focus()
        End If
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70

            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
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


    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtCliente
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCliente.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtCliente
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
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

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)
                ObtenerCanastaVentaFiltro(cboAlmacen.SelectedValue, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)
                lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            Else
                lblEstado.Text = "Digitar un producto válido!"
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
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = True
                    Case Else
                        e.Style.[ReadOnly] = False
                End Select
            End If


        End If

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case ColIndex
                Case 4 ' cantidad
                    Select Case strTipoEx
                        Case "GS"

                        Case Else
                            Calculos()
                    End Select

                Case 5 'VALOR DE VENTA
                    Select Case strTipoEx
                        Case "GS"
                            CalculosGasto()
                        Case Else

                    End Select

            End Select
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)

        'If gridGroupingControl1.Table.SelectedRecords.Count > 0 Then
        '    Dim f As New frmInsertarPrecio
        '    f.txtid.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))
        '    f.txtDescripcion.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion"))
        '    f.txtxmenor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor"))
        '    f.txtxmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayor"))
        '    f.txtxgranmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayor"))
        '    f.txtalmacen.Text = txtAlmacen.Tag
        '    f.txtxmenorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenorme"))
        '    f.txtxmayorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayorme"))
        '    f.txtxgranmayorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayorme"))
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            'If Not txtCliente.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingresar un cliente válido"

            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)

            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'Else
            '    lblEstado.Text = "Done cliente"

            'End If

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

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    Grabar()
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

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
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

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        Select Case cboDestino.Text
            Case "1-Gravado"
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
            Case "2-No Gravado"
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
        End Select

        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta.Text.Trim)
        Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
        Me.dgvCompra.Table.CurrentRecord.SetValue("um", "09")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '   If .tipoExistencia <> "GS" Then
        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
        '   End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", FormatNumber(0, 2))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", FormatNumber(0, 2))
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
        Me.dgvCompra.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicio.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim servicioSA As New servicioSA
        Dim servicio As New servicio
        If cboServicio.SelectedIndex > -1 Then
            servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
            txtCuenta.Text = servicio.cuenta
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridGroupingControl2_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles GridGroupingControl2.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                lblProducto.Text = String.Empty
                AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TimerCustom_Tick(sender As Object, e As EventArgs) Handles TimerCustom.Tick
        time += 1000
        If time = 1000 Then

        End If

        If time >= 4000 Then
            '  Timer3.Stop()
            'statusForm.Dispose()
            'Dispose()
            TimerMesj.Enabled = False
            PanelError.Visible = False
        Else

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub chGarantia_CheckedChanged(sender As Object, e As EventArgs) Handles chGarantia.CheckedChanged
        If chGarantia.Checked = True Then
            dockingManager1.SetDockVisibility(PanelGarantia, True)
        Else
            dockingManager1.SetDockVisibility(PanelGarantia, False)
        End If
    End Sub
End Class