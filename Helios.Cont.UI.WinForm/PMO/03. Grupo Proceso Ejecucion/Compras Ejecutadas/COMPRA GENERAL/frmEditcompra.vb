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
Public Class frmEditcompra
    Inherits frmMaster

    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String

    Public Property ListaItemsEliminado As New List(Of documentocompradetalle)
    Public Property iventorySA As TotalesAlmacenSA

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

    Public fecha As DateTime

    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
        GridCFG(dgvGuia)
        Loadcontroles()
        GetTableGrid()
        GridGuia()
        ConfiguracionInicio()
        UbicarDocumento(IdDocumento)
        SetDocking()
        ListaItemsEliminado = New List(Of documentocompradetalle)
        Tag = IdDocumento
        'Me.Enabled = False
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
        GridCFG(dgvGuia)
        Loadcontroles()
        GetTableGrid()
        GridGuia()
        ConfiguracionInicio()
        SetDocking()
        ListaItemsEliminado = New List(Of documentocompradetalle)
        'Tag = IdDocumento
        'Me.Enabled = False
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
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("fecEntrega", GetType(DateTime))
        dt.Columns.Add("pagos", GetType(Integer))
        dt.Columns.Add("notas", GetType(Integer))
        dt.Columns.Add("ultimaventa", GetType(DateTime))
        dt.Columns.Add("Editable", GetType(String))
        dt.Columns.Add("Action", GetType(String))

        dgvCompra.DataSource = dt
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
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

    Sub SetDocking()
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Existencias")
        dockingManager1.SetDockLabel(Panel5, "Servicios")
        dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        dockingManager1.CloseEnabled = False
    End Sub

    Private Sub GetBloquearArticulos(idDocumento As Integer, estado As StatusArticulo)
        Dim listaInventario As New List(Of totalesAlmacen)
        iventorySA = New TotalesAlmacenSA

        listaInventario = New List(Of totalesAlmacen)
        For Each i In dgvCompra.Table.Records
            listaInventario.Add(New totalesAlmacen With {.idItem = Integer.Parse(i.GetValue("idProducto")), .status = estado})
        Next
        iventorySA.GetChangeStatusArticuloRange(listaInventario)
        MessageBox.Show("Artículos cambiados de estado", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        'dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
            'dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
            Panel5.Visible = False
        Else
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
            dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
        End If


        
        'dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        dockingManager1.CloseEnabled = False

        'If Not IsNothing(GFichaUsuarios) Then
        ' ToolStripButton1.Image = ImageListAdv1.Images(1)
        dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'Else
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'ToolStripButton1.Image = ImageListAdv1.Images(0)
        'GFichaUsuarios = Nothing
        'End If
        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1


        'confgiurando variables generales
        txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        lblPerido.Text = PeriodoGeneral

        ListaTipoCambio = New List(Of tipoCambio)
        LoadTipoCambio()

        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA

        ListaTipoCambio = tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, CInt(MesGeneral), CInt(AnioGeneral), GEstableciento.IdEstablecimiento)

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

#Region "CATEGORIA"
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As Decimal
        Private _UtilidadMayor As Decimal
        Private _UtilidadGranMayor As Decimal
        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal utilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
            _name = name
            _id = id
            _Utilidad = utilidad
            _UtilidadMayor = utiMayor
            _UtilidadGranMayor = utiGranMayor
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Utilidad() As Decimal
            Get
                Return _Utilidad
            End Get
            Set(ByVal value As Decimal)
                _Utilidad = value
            End Set
        End Property

        Public Property UtilidadMayor() As Decimal
            Get
                Return _UtilidadMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadMayor = value
            End Set
        End Property

        Public Property UtilidadGranMayor() As Decimal
            Get
                Return _UtilidadGranMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadGranMayor = value
            End Set
        End Property
    End Class

#End Region

#Region "CESTO SERVICIOS"



#End Region

#Region "Métodos"

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
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
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                Me.Tag = .idDocumento
                'If Not IsNothing(.fechaConstancia) Then
                '    txtFecDetraccion.Value = .fechaConstancia
                'End If
                'txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                'lblIdDocumento.Text = .idDocumento
                PeriodoGeneral = .fechaContable
                cboTipoDoc.SelectedValue = .tipoDoc
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

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
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70

                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa

                Select Case .tieneDetraccion
                    Case "S"
                        chDetraccion.Checked = True
                    Case Else
                        chDetraccion.Checked = False
                End Select
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            Panel2.Visible = False
            Panel5.Visible = False
            Panel4.Visible = False
            For Each i In objDocCompraDet.UbicarDetalleCompraEval(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)


                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                End Select

                Select Case i.bonificacion
                    Case "S"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
                    Case "N"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                End Select

                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)

                Select Case i.tipoExistencia
                    Case "GS"
                    Case "08"

                    Case Else
                        Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
                End Select

                Me.dgvCompra.Table.CurrentRecord.SetValue("pagos", i.NumPagos)
                Me.dgvCompra.Table.CurrentRecord.SetValue("notas", i.NumNotas)
                Me.dgvCompra.Table.CurrentRecord.SetValue("ultimaventa", i.UltimaVenta)

              

                'Dim FECHA_VENTA As DateTime? = i.UltimaVenta
                If i.NumPagos > 0 Or i.NumNotas > 0 Then ' Or IsDate(FECHA_VENTA) Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                    'If FECHA_VENTA >= i.fechaEntrega Then
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                    'End If
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                End If

                'If i.NumNotas > 0 Then
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                'Else
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                'End If


                'If IsDate(FECHA_VENTA) Then
                '    If FECHA_VENTA >= i.fechaEntrega Then
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                '    Else
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                '    End If
                'Else
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                'End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", i.categoria)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", ENTITY_ACTIONS.UPDATE)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = True
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub UbicarDocumentoTransito(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
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
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                Me.Tag = .idDocumento
                'If Not IsNothing(.fechaConstancia) Then
                '    txtFecDetraccion.Value = .fechaConstancia
                'End If
                'txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                'lblIdDocumento.Text = .idDocumento
                PeriodoGeneral = .fechaContable
                cboTipoDoc.SelectedValue = .tipoDoc
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

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
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70

                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa

                Select Case .tieneDetraccion
                    Case "S"
                        chDetraccion.Checked = True
                    Case Else
                        chDetraccion.Checked = False
                End Select
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            Panel2.Visible = False
            Panel5.Visible = False
            Panel4.Visible = False
            For Each i In objDocCompraDet.UbicarDetalleCompraEval(intIdDocumento)

                If (i.almacenRef = idAlmacenVirtual) Then
                    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)


                    Select Case i.estadoPago
                        Case TIPO_COMPRA.PAGO.PAGADO
                            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
                        Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                    End Select

                    Select Case i.bonificacion
                        Case "S"
                            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
                        Case "N"
                            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                    End Select

                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)

                    Select Case i.tipoExistencia
                        Case "GS"
                        Case "08"

                        Case Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
                    End Select

                    Me.dgvCompra.Table.CurrentRecord.SetValue("pagos", i.NumPagos)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("notas", i.NumNotas)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("ultimaventa", i.UltimaVenta)



                    'Dim FECHA_VENTA As DateTime? = i.UltimaVenta
                    If i.NumPagos > 0 Or i.NumNotas > 0 Then ' Or IsDate(FECHA_VENTA) Then
                        Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                        'If FECHA_VENTA >= i.fechaEntrega Then
                        '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                        'End If
                    Else
                        Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                    End If

                    'If i.NumNotas > 0 Then
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                    'Else
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                    'End If


                    'If IsDate(FECHA_VENTA) Then
                    '    If FECHA_VENTA >= i.fechaEntrega Then
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "NO")
                    '    Else
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                    '    End If
                    'Else
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                    'End If
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cat", i.categoria)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("Action", ENTITY_ACTIONS.UPDATE)
                    Me.dgvCompra.Table.AddNewRecord.EndEdit()
                End If
            Next
            btGrabar.Enabled = True
            TotalTalesXcolumna()

        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Sub GrabarGuiaRemision(objDocumentoCompra As documento)
        Dim guiaSA As New DocumentoGuiaSA
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)

        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = CInt(Me.Tag)
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .idEntidad = CInt(txtProveedor.Tag)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalME
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE


        'Dim rf As New RecordFilterDescriptor("Editable", New FilterCondition(FilterCompareOperator.Equals, "SI"))
        'Me.dgvCompra.TableDescriptor.RecordFilters.Add(rf)
        For Each r As Record In dgvCompra.Table.Records

            If r.GetValue("tipoExistencia") <> "GS" Then

                'If r.GetValue("tipoExistencia") <> "08" Then

                If idAlmacenVirtual = Val(r.GetValue("almacen")) Then

                Else
                    documentoguiaDetalle = New documentoguiaDetalle
                    objDocumentoCompra.idDocumento = CInt(Tag)
                    If txtSerieGuia.Text.Trim.Length > 0 Then
                        'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                        objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                    Else
                        '   MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                        Throw New Exception("Ingrese número de serie de la guía!")
                        '   Exit Sub
                    End If
                    If txtNumeroGuia.Text.Trim.Length > 0 Then
                        objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                    Else
                        ' MessageBoxAdv.Show("Ingrese número de la guía!")
                        Throw New Exception("Ingrese el nùmero de la guía!")
                        '  Exit Sub
                    End If
                    documentoguiaDetalle.idDocumento = 0
                    documentoguiaDetalle.idItem = r.GetValue("idProducto")
                    documentoguiaDetalle.descripcionItem = r.GetValue("item")
                    documentoguiaDetalle.destino = r.GetValue("gravado")
                    documentoguiaDetalle.unidadMedida = r.GetValue("um")
                    documentoguiaDetalle.cantidad = CDec(r.GetValue("cantidad"))
                    documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                    documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                    documentoguiaDetalle.importeMN = CDec(r.GetValue("vcmn"))
                    documentoguiaDetalle.importeME = CDec(r.GetValue("vcme"))
                    documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                    documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                    documentoguiaDetalle.fechaModificacion = DateTime.Now
                    ListaGuiaDetalle.Add(documentoguiaDetalle)
                End If
                'End If
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle

        ' guiaSA.ActualizarGuiaRemision(objDocumentoCompra.documentoGuia)
    End Sub

    Public Function AsientoCabeceraCompra(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        'ASIENTO POR LA COMPRA
        nAsiento = New asiento
        nAsiento.periodo = lblPerido.Text
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = TotalesXcanbeceras.TotalMN
        nAsiento.importeME = TotalesXcanbeceras.TotalME
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Public Sub AsientoCompra()
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoCabeceraCompra(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME) ' CABECERA ASIENTO

        '---------------------------------------------------------------------------------------------
        'DETALLE DEL ASIENTO DE COMPRA
        'MOVIMIENTOS
        'Dim rf As New RecordFilterDescriptor("Editable", New FilterCondition(FilterCompareOperator.Equals, "SI"))
        'Me.dgvCompra.TableDescriptor.RecordFilters.Add(rf)
        For Each r As Record In dgvCompra.Table.Records

            '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
            If r.GetValue("valBonif") <> "S" Then

                nMovimiento = New movimiento
                If Not r.GetValue("tipoExistencia") = "GS" Then
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, r.GetValue("tipoExistencia"), "ITEM", "COMPRA")
                    Select Case r.GetValue("tipoExistencia")
                        Case "08"
                            nMovimiento.cuenta = "338"
                        Case Else
                            Select Case cuentaMascara.parametro
                                Case "01"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "03"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "04"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "05"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            End Select
                            '    nMovimiento.cuenta = dgvCompra.Rows(i.Index).Cells(22).Value()
                    End Select
                Else
                    nMovimiento.cuenta = r.GetValue("idProducto")
                End If

                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                Select Case cboTipoDoc.SelectedValue
                    Case "03", "02"
                        nMovimiento.monto = CDec(r.GetValue("totalmn"))
                        nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
                    Case Else
                        Select Case r.GetValue("gravado")
                            Case "1"
                                nMovimiento.monto = CDec(r.GetValue("vcmn"))
                                nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
                            Case Else
                                nMovimiento.monto = CDec(r.GetValue("totalmn"))
                                nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
                        End Select

                End Select

                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                asientoTransitod.movimiento.Add(nMovimiento)


                If CDec(r.GetValue("percepcionMN")) > 0 Then
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = "40113"
                    nMovimiento.descripcion = r.GetValue("item")
                    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                    nMovimiento.monto = CDec(r.GetValue("percepcionMN"))
                    nMovimiento.montoUSD = CDec(r.GetValue("percepcionME"))
                    nMovimiento.fechaActualizacion = DateTime.Now
                    nMovimiento.usuarioActualizacion = "Jiuni"
                    asientoTransitod.movimiento.Add(nMovimiento)
                End If

            End If
            '     End If
        Next

        Select Case cboTipoDoc.SelectedValue
            Case "03", "02"
                'NO TIENE ASIENTO DE IGV
            Case Else
                asientoTransitod.movimiento.Add(AS_IGV(TotalesXcanbeceras.IgvMN, TotalesXcanbeceras.IgvME))
        End Select
        asientoTransitod.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "PROV", "COMPRA")

        nMovimiento = New movimiento With {
              .cuenta = cuentaMascara.cuentaEspecifica,
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "IGV", "COMPRA")
        nMovimiento = New movimiento With {
              .cuenta = cuentaMascara.cuentaEspecifica,
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function ASBOF(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.BONIFICACION
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub AsientoBONIF(r As Record)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = ASBOF(CDec(r.GetValue("vcmn")), CDec(r.GetValue("vcme"))) ' CABECERA ASIENTO
        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        If r.GetValue("almacen") = idAlmacenVirtual Then
            Select Case r.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        Else
            Select Case r.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ALM", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ALM", "BONIF03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ALM", "BONIF04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ALM", "BONIF05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If

        nMovimiento.descripcion = r.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = CDec(r.GetValue("vcmn"))
        nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento

        'Select Case r.GetValue("tipoExistencia")
        '    Case "01"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ALM", "BONIF01.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    Case "03"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ALM", "BONIF03.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    Case "04"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ALM", "BONIF04.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    Case "05"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ALM", "BONIF05.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        'End Select
        'End If

        nMovimiento.cuenta = "7311"
        nMovimiento.descripcion = "Bonif. obtenidas, descuentos rebajas-terceros"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = CDec(r.GetValue("vcmn"))
        nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim almacenSA As New almacenSA

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)

        Dim guiaRemisionBE As New documentoGuia
        Dim guiaREmisionDetaellBE As New documentoguiaDetalle

        Dim documentoTributo As New documento
        Dim listadoDePrecios As New List(Of listadoPrecios)

        '------------------------------------------ lista de Precio ------------------------------------
        Dim PreciosConIVABE As New listadoPrecios
        Dim PreciosSINIVABE As New listadoPrecios
        Dim listaPrecioSA As New ListadoPrecioSA

        Dim PrecioUnitarioMN As Decimal = 0.0

        ListaAsientonTransito = New List(Of asiento)

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        With ndocumento
            .idDocumento = CInt(Me.Tag)
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = CInt(Me.Tag)
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = Nothing
            .codigoLibro = "8"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaContable = PeriodoGeneral
            .fechaConstancia = Nothing
            .nroConstancia = Nothing
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tcDolLoc = txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1
            .bi02 = TotalesXcanbeceras.base2

            .igv01 = TotalesXcanbeceras.MontoIgv1
            .igv02 = TotalesXcanbeceras.MontoIgv2


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me

            '****************************************************************************************************************
            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME
            .destino = TIPO_COMPRA.COMPRA
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA
            .situacion = TIPO_SITUACION.ALMACEN_FISICO
            Select Case chDetraccion.Checked
                Case True
                    .tieneDetraccion = "S"
                Case False
                    .tieneDetraccion = "N"
            End Select
            .aprobado = "N"

            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'REGISTRANDO LA GUIA DE REMISION
        GrabarGuiaRemision(ndocumento)

        If CDec(txtTotalPagar.DecimalValue) > 0 Then
            AsientoCompra()
        End If
        'ASIENTOS CONTABLES

        'Dim rf As New RecordFilterDescriptor("Editable", New FilterCondition(FilterCompareOperator.Equals, "SI"))
        'Me.dgvCompra.TableDescriptor.RecordFilters.Add(rf)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idDocumento = CInt(Me.Tag)
            Select Case r.GetValue("Editable")
                Case "SI"
                    objDocumentoCompraDet.Editable = "SI"
                Case "NO"
                    objDocumentoCompraDet.Editable = "NO"
            End Select

            Select Case r.GetValue("Action")
                Case ENTITY_ACTIONS.INSERT
                    objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT

                Case ENTITY_ACTIONS.UPDATE
                    objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE

            End Select

            objDocumentoCompraDet.secuencia = r.GetValue("codigo")
            If r.GetValue("valBonif") = "S" Then
                objDocumentoCompraDet.TipoOperacion = "9917"
                Select Case r.GetValue("tipoExistencia")
                    Case "GS"

                    Case "08"

                    Case Else
                        AsientoBONIF(r)
                End Select
                'objDocumentoCompraDet.FechaDoc = r.GetValue("fecEntrega")
            Else

                objDocumentoCompraDet.TipoOperacion = "02"

                Select Case r.GetValue("tipoExistencia")

                    Case "08"

                    Case "GS"

                    Case Else
                        MV_Item_Transito(r)
                        '  objDocumentoCompraDet.FechaDoc = r.GetValue("fecEntrega")
                End Select
            End If

            Select Case r.GetValue("tipoExistencia")

                Case "08"
                    objDocumentoCompraDet.FechaDoc = r.GetValue("fecEntrega")
                Case "GS"
                    objDocumentoCompraDet.FechaDoc = Nothing
                Case Else
                    objDocumentoCompraDet.FechaDoc = r.GetValue("fecEntrega")
            End Select

            objDocumentoCompraDet.estadoPago = r.GetValue("valPago")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA
            'If Not r.GetValue("tipoExistencia") = "08" Then
            '    If Not r.GetValue("tipoExistencia") = "GS" Then
            '        objDocumentoCompraDet.FechaDoc = r.GetValue("fecEntrega")
            '    End If
            'End If

            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("item")

            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) < 0 Then
                    lblEstado.Text = "La cantidad debe ser mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
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
            Select Case r.GetValue("tipoExistencia")
                Case "GS"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")

                Case "08"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")

                Case Else
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")
                    objDocumentoCompraDet.unidad2 = r.GetValue("presentacion")  'IDPRESENTACION
                    objDocumentoCompraDet.monto2 = Nothing  ' PRESENTACION
                    objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacen"))
                    objDocumentoCompraDet.fechaEntrega = CDate(r.GetValue("fecEntrega"))
            End Select

            If almacenSA.GetEsAlmacenVirtual(objDocumentoCompraDet.almacenRef) = True Then
                objDocumentoCompraDet.ItemEntregadototal = "N"
            Else
                objDocumentoCompraDet.ItemEntregadototal = "S"
            End If

            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            If IsNumeric(r.GetValue("totalmn")) Then
                If CDec(r.GetValue("totalmn")) < 0 Then
                    lblEstado.Text = "El importe debe ser mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                If CDec(r.GetValue("totalmn")) > 0 Then
                    objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
                Else
                    lblEstado.Text = "Ingrese un importe mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            Else
                lblEstado.Text = "Ingrese un importe válido del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If


            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))

            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            Dim s = r.GetValue("almacen")
            If s.ToString.Trim.Length > 0 Then
                If r.GetValue("almacen") = idAlmacenVirtual Then
                    objDocumentoCompraDet.situacion = TIPO_SITUACION.ALMACEN_TRANSITO
                    objDocumentoCompraDet.entregable = "NO"
                Else
                    objDocumentoCompraDet.situacion = TIPO_SITUACION.ALMACEN_FISICO
                    objDocumentoCompraDet.entregable = "SI"
                End If
            End If


            If r.GetValue("estadoPago") = "Pagado" Then
                objDocumentoCompraDet.usuarioCaja = usuario.IDUsuario
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            Else
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            End If


            'objDocumentoCompraDet.porcUtimenor = i.Cells(33).Value()
            'objDocumentoCompraDet.porcUtimayor = i.Cells(34).Value()
            'objDocumentoCompraDet.porcUtigranMayor = i.Cells(35).Value()
            'objDocumentoCompraDet.FlagModificaPrecioVenta = i.Cells(36).Value()
            'Dim marcaVal = IIf(IsDBNull(r.GetValue("marca")), Nothing, r.GetValue("marca"))
            objDocumentoCompraDet.marcaRef = Nothing

            objDocumentoCompraDet.categoria = Nothing '(r.GetValue("cat"))

            ListaDetalle.Add(objDocumentoCompraDet)

        Next



        For Each i In ListaItemsEliminado
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            objDocumentoCompraDet.Editable = "SI"
            objDocumentoCompraDet.secuencia = i.secuencia
            objDocumentoCompraDet.idDocumento = CInt(Me.Tag)
            objDocumentoCompraDet.idItem = i.idItem
            objDocumentoCompraDet.descripcionItem = i.descripcionItem
            objDocumentoCompraDet.tipoExistencia = i.tipoExistencia
            objDocumentoCompraDet.almacenRef = i.almacenRef
            objDocumentoCompraDet.destino = i.destino
            objDocumentoCompraDet.monto1 = i.monto1
            objDocumentoCompraDet.monto2 = i.monto2
            objDocumentoCompraDet.unidad1 = i.unidad1
            objDocumentoCompraDet.unidad2 = i.unidad2
            objDocumentoCompraDet.precioUnitario = i.precioUnitario
            objDocumentoCompraDet.precioUnitarioUS = i.precioUnitarioUS
            objDocumentoCompraDet.montokardex = i.montokardex
            objDocumentoCompraDet.montokardexUS = i.montokardexUS
            objDocumentoCompraDet.montoIgv = i.montoIgv
            objDocumentoCompraDet.montoIgvUS = i.montoIgvUS
            objDocumentoCompraDet.importe = i.importe
            objDocumentoCompraDet.importeUS = i.importeUS
            ListaDetalle.Add(objDocumentoCompraDet)
        Next

        Dim consultaPagados = (From n In ListaDetalle
                              Where n.estadoPago = "Pagado").Count

        If consultaPagados > 0 Then
            'Dim SaldoCaja As New UsuarioEstadoCaja
            'SaldoCaja.GetSaldoActual(GFichaUsuarios)

            'Dim SumaItemsPagados = (From n In ListaDetalle
            '                  Where n.estadoPago = "Pagado" _
            '                  Select n.importe).Sum

            'If SumaItemsPagados > GFichaUsuarios.SaldoMN Then
            '    Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
            'End If
        End If

        If consultaPagados > 0 Then
            AsientoItemPagado()
        End If

        Dim consultaNoPagados = (From n In ListaDetalle
                         Where n.estadoPago = "No Pagado").Count

        If consultaNoPagados > 0 Then
            ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        Else
            ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        End If


        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle


        'validando proceso antes de grabar proceso
        Dim ItemsNOEditables = (From n In ListaDetalle _
                     Where n.Editable = "NO").Count


        If ListaDetalle.Count = ItemsNOEditables Then
            Throw New Exception("No puede modificar el comprobante!")
        End If

        If ListaDetalle.Count > ItemsNOEditables Then
            CompraSA.ActualualizarCompraSingle(ndocumento)
            lblEstado.Text = "Compra modificada!"
            MessageBoxAdv.Show("Compra modificada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Throw New Exception("No puede modificar el comprobante!")
        End If
    End Sub



    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvCompra.Table.Records
            If Not r.GetValue("tipoExistencia") = "GS" Then
                'If r.GetValue("almacen") <> idAlmacenVirtual Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = 0
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                'With almacenSA.GetUbicar_almacenPorID(CInt(r.GetValue("almacen")))
                objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                objTotalesDet.idAlmacen = CInt(r.GetValue("almacen"))
                'End With
                objTotalesDet.origenRecaudo = r.GetValue("gravado")
                objTotalesDet.tipoCambio = txtTipoCambio.DecimalValue
                objTotalesDet.tipoExistencia = r.GetValue("tipoExistencia")
                objTotalesDet.idItem = r.GetValue("idProducto")
                objTotalesDet.descripcion = r.GetValue("item")
                objTotalesDet.idUnidad = r.GetValue("um")
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(r.GetValue("cantidad"), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(r.GetValue("pumn"), Decimal)

                objTotalesDet.importeSoles = CType(r.GetValue("vcmn"), Decimal)
                objTotalesDet.importeDolares = CType(r.GetValue("vcme"), Decimal)


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
                'End If
            End If
        Next

        Return ListaTotales
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

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
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "8"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = "4212"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta
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

    Public Sub MV_Item_Transito(i As Record)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(CDec(i.GetValue("vcmn")), CDec(i.GetValue("vcme"))) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        If i.GetValue("almacen") = idAlmacenVirtual Then
            Select Case i.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        Else
            Select Case i.GetValue("tipoExistencia")
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
            End Select

        End If



        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        If i.GetValue("almacen") = idAlmacenVirtual Then

            Select Case i.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select

        Else
            Select Case i.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If


        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
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

            If r.GetValue("valBonif") = "S" Then
                totalDesc += CDec(r.GetValue("igvmn"))
                totalDescme += CDec(r.GetValue("igvme"))
            Else
                'totalVC += CDec(r.GetValue("vcmn"))
                'totalVCme += CDec(r.GetValue("vcme"))

                totalIVA += CDec(r.GetValue("igvmn"))
                totalIVAme += CDec(r.GetValue("igvme"))

                total += CDec(r.GetValue("totalmn"))
                totalme += CDec(r.GetValue("totalme"))
            End If

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


            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    If r.GetValue("valBonif") <> "S" Then
                        totalVC += CDec(r.GetValue("vcmn"))
                        totalVCme += CDec(r.GetValue("vcme"))
                    End If


                Case OperacionGravada.Exonerado
                    If r.GetValue("valBonif") <> "S" Then
                        totalVC2 += CDec(r.GetValue("vcmn"))
                        totalVCme2 += CDec(r.GetValue("vcme"))
                    End If

                Case OperacionGravada.Inafecto
                    If r.GetValue("valBonif") <> "S" Then
                        totalVC3 += CDec(r.GetValue("vcmn"))
                        totalVCme3 += CDec(r.GetValue("vcme"))
                    End If
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

        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If

        'Select Case cboMoneda.SelectedValue
        '    Case 1
        '        txtBonifica.DecimalValue = totalDesc
        '        txtTotalBase.DecimalValue = totalVC
        '        txtTotalIva.DecimalValue = totalIVA
        '        txtTotalPagar.DecimalValue = total
        '        lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        '    Case 2
        '        txtBonifica.DecimalValue = totalDescme
        '        txtTotalBase.DecimalValue = totalVCme
        '        txtTotalIva.DecimalValue = totalIVAme
        '        txtTotalPagar.DecimalValue = totalme
        '        lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

        'End Select


    End Sub

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub


    Private Sub ListaMercaderias08(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        ListView1.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            ListView1.Items.Add(n)
        Next

    End Sub


    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String, intUtilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(intUtilidad)
                n.SubItems.Add(utiMayor)
                n.SubItems.Add(utiGranMayor)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub HIJOS(idservicio As Integer)
        Dim servicioSA As New servicioSA
        cboServicio.DisplayMember = "descripcion"
        cboServicio.ValueMember = "idServicio"
        cboServicio.DataSource = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = idservicio})
    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0



        cboServicioPadre.DisplayMember = "descripcion"
        cboServicioPadre.ValueMember = "idServicio"
        cboServicioPadre.DataSource = servicioSA.ListadoServiciosPadreTipo("PC")



        'COMPROBANTE TIPO DOCUMENTOS
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In listatabla _
                           Where Not list.Contains(n.codigoDetalle)).ToList


        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = Comprobantes

        'TIPO DE EXISTENCIA
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")
        Dim listaNoExistencias As New List(Of String)
        listaNoExistencias.Add("06")
        listaNoExistencias.Add("07")
        listaNoExistencias.Add("08")
        listaNoExistencias.Add("02")

        Dim consultaExistencia = (From n In listatabla _
                                 Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = consultaExistencia




    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))



        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

            For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next

        Else
            For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next
        End If


        Return dt
    End Function

    Public Function GetTableCombos() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "SI"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "NO"
        dt.Rows.Add(dr2)

        Return dt
    End Function

#End Region


    Private Sub frmEditcompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Dim comboTable As New DataTable
    Private Sub frmEditcompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        comboTable = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(14).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompra.ShowRowHeaders = False


        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtProveedor
                    Me.popupControlContainer1.Size = New Size(279, 147)
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
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtProveedor
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text

                txtProveedorGuia.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRucGuia.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If

                txtSerieGuia.Select()
                txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.Tag = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id)
                'txtCategoria.PasswordChar = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad)
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id, cboTipoExistencia.SelectedValue, DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCategoria.Text.Trim.Length > 0 Then
            ListadoProductosPorCategoriaTipoExistencia(txtCategoria.Tag, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If cboTipoExistencia.SelectedIndex > -1 Then
            If txtCategoria.Text.Trim.Length > 0 Then
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.Tag, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        Dim categoriaSA As New itemSA
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer2.IsShowing() Then
                ' Let the popup align around the source textBox.
                Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer2.Size = New Size(238, 110)
                Me.PopupControlContainer2.ParentControl = Me.txtCategoria
                Me.PopupControlContainer2.ShowPopup(Point.Empty)

                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer2.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCategoria.Text.Trim.Length > 0 Then
                lstCategoria.Items.Clear()
                For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, txtCategoria.Text.Trim)
                    lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
                Next
                lstCategoria.DisplayMember = "Name"
                lstCategoria.ValueMember = "Id"
                Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer2.Size = New Size(238, 110)
                Me.PopupControlContainer2.ParentControl = Me.txtCategoria
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
            End If
        End If
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
            '   End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        If lsvListadoItems.SelectedItems.Count > 0 Then
            Dim selFila As ListViewItem = lsvListadoItems.SelectedItems(0)

            'With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", CStr(selFila.SubItems(4).Text))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", CInt(selFila.SubItems(0).Text))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", CStr(selFila.SubItems(1).Text))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", CStr(selFila.SubItems(2).Text))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", CStr(selFila.SubItems(3).Text))

            'Dim imItem = .idItem
            'If Not IsNothing(imItem) Then
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", CStr(imItem))
            'Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)
            'End If


            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            If CStr(selFila.SubItems(3).Text) <> "GS" Then
                If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                End If
            End If

            Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")

            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", CStr(selFila.SubItems(8).Text))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

            'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            'Dim codCat = .idItem

            'If Not IsNothing(codCat) Then
            '    ITEM = ITEMSA.UbicarCategoriaPorID(.idItem)
            '    If Not IsNothing(ITEM) Then
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", ITEM.idPadre)
            '    Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)
            'End If
            '    End If



            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)
            Me.dgvCompra.Table.CurrentRecord.SetValue("Action", ENTITY_ACTIONS.INSERT)
            Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            '    End With
        End If
    End Sub
    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim catSA As New itemSA
        Dim cat As New item
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        If txtCategoria.Text.Trim.Length > 0 Then
            If Not IsNothing(txtCategoria.Tag) Then
                With frmNuevaExistencia
                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                        '.cboIgv.Enabled = False
                        '.cboIgv.Text = "2 - EXONERADO"
                        .UCNuenExistencia.cboTipoExistencia.Enabled = False
                        .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                        .UCNuenExistencia.cboUnidades.Enabled = True
                    Else

                    End If

                    '.txtCategoria.Tag = txtCategoria.Tag
                    '.txtCategoria.Text = txtCategoria.Text
                    ' .CboClasificacion.SelectedValue = CboClasificacion.SelectedValue
                    '.cboProductos.SelectedValue = cboProductos.SelectedValue
                    '  .cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue

                    .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
                    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If datos.Count > 0 Then
                        If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            If datos(0).Cuenta = "Grabado" Then
                                '  If lsvListadoItems.SelectedItems.Count > 0 Then

                                With objInsumo.InvocarProductoID(CInt(datos(0).ID))
                                    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                                    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)

                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                                    Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                                    If .tipoExistencia <> "GS" Then
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
                                        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                                    End If
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)
                                    Me.dgvCompra.Table.AddNewRecord.EndEdit()
                                End With
                                ' End If


                            End If
                        End If
                    End If
                End With
            Else

                lblEstado.Text = "Debe elegir una clasificacion"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If
        Else
            lblEstado.Text = "Debe elegir una clasificacion"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoItems.SelectedIndexChanged

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

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then

                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing

                        If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                            e.Style.CellValue = 1
                        End If

                    Case Else
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                        e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "almacen")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                        e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "fecEntrega")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                        e.Style.CellValue = String.Empty
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue

                End Select

            Else
                'e.Style.[ReadOnly] = False
            End If

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "fecEntrega" Then
                    e.Style.Format = "dd/MM/yyyy h:mm:ss tt"
                End If
                e.Handled = True
            End If

            Dim rec As GridRecordRow = TryCast(Me.dgvCompra.Table.DisplayElements(e.TableCellIdentity.RowIndex), GridRecordRow)
            If rec IsNot Nothing Then
                ' Applies format by checking the value Row1
                Dim dr As DataRowView = TryCast(rec.GetData(), DataRowView)
                If dr IsNot Nothing AndAlso dr("Editable").Equals("NO") Then

                    'dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.TextColor = Color.Black

                    e.Style.Enabled = False
                    e.Style.BackColor = Color.Azure
                End If
            End If

            'If e.TableCellIdentity.Column.Name = "gravado" Then
            '    If e.Style.CellValue.Equals("1") Then



            '        e.Style.BackColor = Color.LightYellow
            '    End If
            'End If

            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                'If IsNumeric(e.Style.CellValue) Then
                '    If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '        ' e.Style.BackColor = Color.LightYellow
                '        e.Style.BackColor = Color.Yellow
                '        '     e.Style.Format = "##.00"
                '    End If
                'End If
                'If e.TableCellIdentity.Column.MappingName = "vcmn" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    'e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacen" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
                '    End If
                '    'If e.TableCellIdentity.Column.Name = "importeMN" Then
                '    '    If IsNumeric(e.Style.CellValue) Then
                '    '        '        If Fix(e.Style.CellValue) > 0 Then
                '    '        '    e.Style.ReadOnly = True
                '    '        e.TableCellIdentity.Table.CurrentRecord.SetValue("HaberMN", 0)
                '    '        'End If
                '    '    End If

            End If
        End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged

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
    Sub Calculosxxx()

        TotalTalesXcolumna()
    End Sub


    Sub Calculos()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0


        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
        Else
            valPercepMN = 0
            valPercepME = 0

        End If

        '****************************************************************
        colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
        cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")

        Select Case cboMoneda.SelectedValue
            Case 1 'MONEDA NACIONAL
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

            Case 2 'MONEDA EXTRANJERA

                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                VCme = Me.dgvCompra.Table.CurrentRecord.GetValue("vcme") ' 
                VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

        End Select

        'calculo Compratido por ambas monedas(Nacional y extranjera)
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            colBI = VC + Igv + valPercepMN
            colBIme = VCme + IgvME + valPercepME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 AndAlso VC > 0 Then
            Igv = Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            colBI = VC + Igv + valPercepMN
            colBIme = VCme + IgvME + valPercepME

            colPrecUnit = 0
            colPrecUnitme = 0
        ElseIf cantidad = 0 Then
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

        Select Case cboTipoDoc.SelectedValue
            Case "08"

            Case "03", "02"
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Case Else
                'If cboMoneda.SelectedValue = 1 Then
                ' DATOS SOLES

                Select Case colDestinoGravado
                    Case "2", "3", "4"

                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)

                    Case Else
                        If Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Else
                            If cantidad > 0 Then

                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                            Else

                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                            End If

                        End If
                End Select

                'ElseIf cboMoneda.SelectedValue = 2 Then

                '    Select Case colDestinoGravado
                '        Case "4"

                '        Case Else


                '    End Select

                'End If
        End Select
        TotalTalesXcolumna()
    End Sub


    Sub CalculosBonificacion()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Decimal = 0
        '****************************************************************
        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")
        cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
        VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
        VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            colBI = VC + Igv
            colBIme = VCme + IgvME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
            colBI = VC + Igv
            colBIme = VCme + IgvME
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


        Select Case cboTipoDoc.SelectedValue
            Case "08"

            Case "03", "02"

            Case Else
                If cboMoneda.SelectedValue = 1 Then
                    ' DATOS SOLES

                    Select Case colDestinoGravado
                        Case "2", "3", "4"


                        Case Else
                            'If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then ' BOnIFICACIOn
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)

                            'Else
                            'If cantidad > 0 Then



                            'Else


                            'End If

                            'End If
                    End Select

                ElseIf cboMoneda.SelectedValue = 2 Then

                    Select Case colDestinoGravado
                        Case "4"

                        Case Else


                    End Select

                End If
        End Select

    End Sub

    'Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick

    'End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                Case 18

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




                Case 20

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chBonif")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "N" ' curStatus

                                '******************************************************************

                                Dim cantidad As Decimal = 0
                                Dim VC As Decimal = 0
                                Dim VCme As Decimal = 0
                                Dim Igv As Decimal = 0
                                Dim IgvME As Decimal = 0
                                Dim totalMN As Decimal = 0
                                Dim colBI As Decimal = 0
                                Dim colBIme As Decimal = 0
                                Dim colPrecUnit As Decimal = 0
                                Dim colPrecUnitme As Decimal = 0
                                Dim colDestinoGravado As Integer
                                Dim colBonifica As String = Nothing

                                Dim valPercepMN As Decimal = 0
                                Dim valPercepME As Decimal = 0


                                colDestinoGravado = Me.dgvCompra.TableModel(RowIndex, 1).CellValue

                                If colDestinoGravado = 1 Then
                                    valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
                                    valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
                                Else
                                    valPercepMN = 0
                                    valPercepME = 0
                                End If

                                '****************************************************************
                                '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")

                                cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
                                Me.dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                                VC = Me.dgvCompra.TableModel(RowIndex, 5).CellValue
                                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                                If cantidad > 0 AndAlso VC > 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                                    colBI = VC + Igv + valPercepMN
                                    colBIme = VCme + IgvME + valPercepME

                                    colPrecUnit = Math.Round(VC / cantidad, 2)
                                    colPrecUnitme = Math.Round(VCme / cantidad, 2)
                                ElseIf cantidad = 0 Then
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


                                Select Case cboTipoDoc.SelectedValue
                                    Case "08"

                                    Case "03", "02"

                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2") 'importe total
                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2") 'importe total me

                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0 'igvmn
                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0 'igvme

                                        Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0 'percepcion
                                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0 'percepcion me


                                    Case Else
                                        If cboMoneda.SelectedValue = 1 Then
                                            ' DATOS SOLES

                                            Select Case colDestinoGravado
                                                Case "2", "3", "4"

                                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                    Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                                                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


                                                Case Else
                                                    If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                                                        Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0

                                                    Else
                                                        If cantidad > 0 Then


                                                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        Else

                                                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        End If

                                                    End If
                                            End Select

                                        ElseIf cboMoneda.SelectedValue = 2 Then

                                            Select Case colDestinoGravado
                                                Case "4"

                                                Case Else


                                            End Select

                                        End If
                                End Select

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S"

                                '******************************************************************

                                Dim cantidad As Decimal = 0
                                Dim VC As Decimal = 0
                                Dim VCme As Decimal = 0
                                Dim Igv As Decimal = 0
                                Dim IgvME As Decimal = 0
                                Dim totalMN As Decimal = 0
                                Dim colBI As Decimal = 0
                                Dim colBIme As Decimal = 0
                                Dim colPrecUnit As Decimal = 0
                                Dim colPrecUnitme As Decimal = 0
                                Dim colDestinoGravado As Integer
                                Dim colBonifica As String = Nothing
                                '****************************************************************


                                Dim valPercepMN As Decimal = 0
                                Dim valPercepME As Decimal = 0


                                colDestinoGravado = Me.dgvCompra.TableModel(RowIndex, 1).CellValue

                                If colDestinoGravado = 1 Then
                                    valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
                                    valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
                                Else
                                    valPercepMN = 0
                                    valPercepME = 0
                                End If

                                '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                                cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
                                Me.dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                                VC = Me.dgvCompra.TableModel(RowIndex, 5).CellValue
                                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                                If cantidad > 0 AndAlso VC > 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                                    colBI = VC + Igv
                                    colBIme = VCme + IgvME

                                    colPrecUnit = Math.Round(VC / cantidad, 2)
                                    colPrecUnitme = Math.Round(VCme / cantidad, 2)
                                ElseIf cantidad = 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
                                    colBI = VC + Igv
                                    colBIme = VCme + IgvME
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


                                Select Case cboTipoDoc.SelectedValue
                                    Case "08"

                                    Case "03", "02"

                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                                        Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


                                    Case Else
                                        If cboMoneda.SelectedValue = 1 Then
                                            ' DATOS SOLES

                                            Select Case colDestinoGravado
                                                Case "2", "3", "4"

                                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                    Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                    Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0
                                                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0

                                                Case Else
                                                    If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                                                        Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0
                                                    Else
                                                        If cantidad > 0 Then


                                                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        Else

                                                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        End If

                                                    End If
                                            End Select

                                        ElseIf cboMoneda.SelectedValue = 2 Then

                                            Select Case colDestinoGravado
                                                Case "4"

                                                Case Else


                                            End Select

                                        End If
                                End Select


                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.dgvCompra.TableControl.Refresh()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4 ' cantidad
                    Calculos()
                Case 5, 10 'Valor de compra
                    Calculos()
                Case 6
                    Calculos()
                Case 8
                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    Calculos()

                Case 13
                    Dim colPercepcionMN As Decimal = 0
                    colPercepcionMN = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")) * txtTipoCambio.DecimalValue, 2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", colPercepcionMN)
                    Calculos()

                Case 14
                    If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
                    End If

                Case 1
                    Calculos()
            End Select
        End If

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
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                PanelError.Visible = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

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

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                '    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                Grabar()
                'Else
                'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                'If Filas > 0 Then
                '    UpdateCompra()
                'Else

                '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)

                'End If


                'End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim r As Record = dgvCompra.Table.CurrentRecord
            Dim objDocumentoCompraDet As New documentocompradetalle
            objDocumentoCompraDet.idDocumento = CInt(Me.Tag)
            objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            objDocumentoCompraDet.secuencia = r.GetValue("codigo")
            'objDocumentoCompraDet.estadoPago = r.GetValue("valPago")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("item")
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
            Select Case r.GetValue("tipoExistencia")
                Case "GS"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing

                Case Else
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")
                    objDocumentoCompraDet.unidad2 = r.GetValue("presentacion")  'IDPRESENTACION
                    objDocumentoCompraDet.monto2 = Nothing  ' PRESENTACION
                    objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacen"))
                    objDocumentoCompraDet.fechaEntrega = CDate(r.GetValue("fecEntrega"))
            End Select
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))

            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ListaItemsEliminado.Add(objDocumentoCompraDet)

            'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
            'Dim n As Integer = Me.dgvCompra.TableControl.TopRowIndex
            'Dim hiddden As New GridRowHidden With {.RowIndex = RowIndex}
            ''Dim hiddenrows(0) As GridRowHidden
            'hiddden = New GridRowHidden(n)
            ' ''Hide the first row
            ''Me.dgvCompra.TableControl.Model.RowHiddenEntries.AddRange(hiddenrows)
            'Me.dgvCompra.TableControl.Model.RowHiddenEntries.Add(hiddden)
            Me.dgvCompra.Table.CurrentRecord.Delete()
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

    Private Sub lsvServicios_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlCurrentCellKeyPress

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellStartEditing(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellStartEditing
        'Dim cc As GridCurrentCell = e.TableControl.CurrentCell
        'Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        'If style.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record AndAlso style.TableCellIdentity.Column.Name = "gravado" Then
        '    Dim str = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        '    Select Case str
        '        Case "GS"
        '            Me.dgvCompra.TableModel(cc.RowIndex, 1).ReadOnly = True
        '            e.Inner.Cancel = True
        '        Case Else
        '            Me.dgvCompra.TableModel(cc.RowIndex, 1).ReadOnly = True
        '    End Select


        'End If
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress

    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub cboServicio_Click(sender As Object, e As EventArgs) Handles cboServicio.Click

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

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If cboServicio.Text.Trim.Length > 0 Then
            If txtCuenta.Text.Trim.Length > 0 Then

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta.Text.Trim)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", Nothing)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", TipoRecurso.SERVICIO)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", Nothing)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Action", ENTITY_ACTIONS.INSERT)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Editable", "SI")
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Else
                lblEstado.Text = "Seleccione un Servicio hijo"
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Else
            lblEstado.Text = "Seleccione un Servicio hijo"
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub CboEntidadFinanciera_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub gradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles gradientPanel2.Paint

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub cboServicioPadre_Click(sender As Object, e As EventArgs) Handles cboServicioPadre.Click

    End Sub

    Private Sub cboServicioPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicioPadre.SelectedIndexChanged

    End Sub

    Private Sub cboServicioPadre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboServicioPadre.SelectedValueChanged

        txtCuenta.Text = ""

        If cboServicioPadre.Text.Trim.Length > 0 Then
            HIJOS(cboServicioPadre.SelectedValue)
        Else
            lblEstado.Text = "Seleccione un Servicio Padre"
        End If

        If cboServicio.Text.Trim.Length > 0 Then
            Dim servicioSA As New servicioSA
            Dim servicio As New servicio
            If cboServicio.SelectedIndex > -1 Then
                servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
                txtCuenta.Text = servicio.cuenta
            End If
        End If
    End Sub

    Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt3.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias08("08", TextBoxExt3.Text.Trim)
            '   End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt3.TextChanged

    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged

    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        Dim categoriaSA As New itemSA
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer3.IsShowing() Then
                ' Let the popup align around the source textBox.
                Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer3.Size = New Size(238, 110)
                Me.PopupControlContainer3.ParentControl = Me.TextBoxExt1
                Me.PopupControlContainer3.ShowPopup(Point.Empty)


                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer3.IsShowing() Then
                Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt1.Text.Trim.Length > 0 Then
                ListBox1.Items.Clear()
                For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, txtCategoria.Text.Trim)
                    ListBox1.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
                Next
                ListBox1.DisplayMember = "Name"
                ListBox1.ValueMember = "Id"
                Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer3.Size = New Size(238, 110)
                Me.PopupControlContainer3.ParentControl = Me.TextBoxExt1
                Me.PopupControlContainer3.ShowPopup(Point.Empty)
            End If
        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If ListBox1.SelectedItems.Count > 0 Then
            Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub PopupControlContainer3_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer3.BeforePopup
        Me.PopupControlContainer3.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListBox1.SelectedItems.Count > 0 Then
                Me.TextBoxExt1.Tag = CStr(DirectCast(Me.ListBox1.SelectedItem, Categoria).Id)
                'txtCategoria.PasswordChar = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad)
                TextBoxExt1.Text = ListBox1.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.ListBox1.SelectedItem, Categoria).Id, "08", DirectCast(Me.ListBox1.SelectedItem, Categoria).Utilidad, DirectCast(Me.ListBox1.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.ListBox1.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextBoxExt1.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        If ListView1.SelectedItems.Count > 0 Then
            Dim selFila As ListViewItem = ListView1.SelectedItems(0)

            With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                If .tipoExistencia <> "GS" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            End With
        End If
    End Sub
    Sub GridGuia()
        Dim dt As New DataTable()
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("vcmn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("vcme")
        dt.Columns.Add("totalme")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("marca")
        dt.Columns.Add("almacen")
        dt.Columns.Add("pumn")
        dt.Columns.Add("pume")
        dt.Columns.Add("fechaEntrega")

        dgvGuia.DataSource = dt
    End Sub
    Private Sub TabControlAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlAdv1.SelectedIndexChanged
        'If TabControlAdv1.SelectedTab Is TabPageAdv2 Then
        '    Dim dt As New DataTable()
        '    dt.Columns.Add("codigo")
        '    dt.Columns.Add("gravado")
        '    dt.Columns.Add("idProducto")
        '    dt.Columns.Add("item")
        '    dt.Columns.Add("um")
        '    dt.Columns.Add("cantidad")
        '    dt.Columns.Add("vcmn")
        '    dt.Columns.Add("totalmn")
        '    dt.Columns.Add("vcme")
        '    dt.Columns.Add("totalme")
        '    dt.Columns.Add("tipoExistencia")
        '    dt.Columns.Add("marca")
        '    dt.Columns.Add("almacen")
        '    dt.Columns.Add("pumn")
        '    dt.Columns.Add("pume")
        '    dt.Columns.Add("fechaEntrega")
        '    Dim rf As New RecordFilterDescriptor("Editable", New FilterCondition(FilterCompareOperator.Equals, "SI"))
        '    Me.dgvCompra.TableDescriptor.RecordFilters.Add(rf)

        '    For Each r As Record In dgvCompra.Table.FilteredRecords
        '        Dim dr As DataRow = dt.NewRow
        '        dr(0) = r.GetValue("codigo")
        '        dr(1) = r.GetValue("gravado")
        '        dr(2) = r.GetValue("idProducto")
        '        dr(3) = r.GetValue("item")
        '        dr(4) = r.GetValue("um")
        '        dr(5) = r.GetValue("cantidad")
        '        dr(6) = r.GetValue("vcmn")
        '        dr(7) = r.GetValue("totalmn")
        '        dr(8) = r.GetValue("vcme")
        '        dr(9) = r.GetValue("totalme")
        '        dr(10) = r.GetValue("tipoExistencia")
        '        dr(11) = r.GetValue("marca")
        '        dr(12) = r.GetValue("almacen")
        '        dr(13) = r.GetValue("pumn")
        '        dr(14) = r.GetValue("pume")
        '        dr(15) = r.GetValue("fecEntrega")
        '        dt.Rows.Add(dr)
        '    Next
        '    dgvGuia.DataSource = dt
        'End If


    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        Dim r As Record = dgvCompra.Table.CurrentRecord

        Me.dgvGuia.Table.AddNewRecord.SetCurrent()
        Me.dgvGuia.Table.AddNewRecord.BeginEdit()
        Me.dgvGuia.Table.CurrentRecord.SetValue("codigo", r.GetValue("codigo"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("gravado", r.GetValue("gravado"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("idProducto", r.GetValue("idProducto"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("item", r.GetValue("item"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("um", r.GetValue("um"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("cantidad", r.GetValue("cantidad"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("vcmn", r.GetValue("vcmn"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("totalmn", r.GetValue("totalmn"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("vcme", r.GetValue("vcme"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("totalme", r.GetValue("totalme"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("tipoExistencia", r.GetValue("tipoExistencia"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("marca", r.GetValue("marca"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("almacen", r.GetValue("almacen"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("pumn", r.GetValue("pumn"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("pume", r.GetValue("pume"))
        Me.dgvGuia.Table.CurrentRecord.SetValue("fecEntrega", r.GetValue("fecEntrega"))

        Me.dgvGuia.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub tbNotify_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tbNotify.ButtonStateChanged
        If tbNotify.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            MessageBoxAdv.Show("ON")
        Else
            MessageBoxAdv.Show("OFF")
        End If

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmNotificacionVenta(Val(Me.Tag))
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tb19_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        If IsNumeric(txtTipoCambio.Text) Then
            If txtTipoCambio.Text > 0 Then
                tipoCambio()
            End If
        End If
    End Sub

    Sub TipoCambio()


        For Each r As Record In dgvCompra.Table.Records
            Dim cantidad As Decimal = 0
            Dim VC As Decimal = 0
            Dim VCme As Decimal = 0
            Dim Igv As Decimal = 0
            Dim IgvME As Decimal = 0
            Dim totalMN As Decimal = 0
            Dim colBI As Decimal = 0
            Dim colBIme As Decimal = 0
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitme As Decimal = 0
            Dim colDestinoGravado As Integer
            Dim colBonifica As String = Nothing

            Dim valPercepMN As Decimal = 0
            Dim valPercepME As Decimal = 0




            colDestinoGravado = r.GetValue("gravado")

            If colDestinoGravado = 1 Then
                valPercepMN = r.GetValue("percepcionMN")
                valPercepME = r.GetValue("percepcionME")
            Else
                valPercepMN = 0
                valPercepME = 0

            End If

            '****************************************************************
            colBonifica = r.GetValue("chBonif")
            cantidad = r.GetValue("cantidad")

            Select Case cboMoneda.SelectedValue
                Case 1 'MONEDA NACIONAL
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                    r.SetValue("cantidad", cantidad.ToString("N2"))

                    VC = r.GetValue("vcmn")
                    VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

                Case 2 'MONEDA EXTRANJERA

                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                    r.SetValue("cantidad", cantidad.ToString("N2"))
                    VCme = r.GetValue("vcme") ' 
                    VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

            End Select

            'calculo Compratido por ambas monedas(Nacional y extranjera)
            If cantidad > 0 AndAlso VC > 0 Then
                Igv = Math.Round(VC * (TmpIGV / 100), 2)
                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                colBI = VC + Igv + valPercepMN
                colBIme = VCme + IgvME + valPercepME

                colPrecUnit = Math.Round(VC / cantidad, 2)
                colPrecUnitme = Math.Round(VCme / cantidad, 2)
            ElseIf cantidad = 0 AndAlso VC > 0 Then
                Igv = Math.Round(VC * (TmpIGV / 100), 2)
                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                colBI = VC + Igv + valPercepMN
                colBIme = VCme + IgvME + valPercepME

                colPrecUnit = 0
                colPrecUnitme = 0
            ElseIf cantidad = 0 Then
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

            Select Case cboTipoDoc.SelectedValue
                Case "08"

                Case "03", "02"
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                    r.SetValue("vcmn", VC.ToString("N2"))
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                    r.SetValue("vcme", VCme.ToString("N2"))
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                    r.SetValue("pumn", colPrecUnit.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                    r.SetValue("pume", colPrecUnitme.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                    r.SetValue("totalmn", VC.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                    r.SetValue("totalme", VCme.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    r.SetValue("igvmn", 0)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    r.SetValue("igvme", 0)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    r.SetValue("percepcionMN", 0)
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    r.SetValue("percepcionME", 0)
                Case Else
                    'If cboMoneda.SelectedValue = 1 Then
                    ' DATOS SOLES

                    Select Case colDestinoGravado
                        Case "2", "3", "4"

                            r.SetValue("vcmn", VC.ToString("N2"))
                            r.SetValue("vcme", VCme.ToString("N2"))
                            r.SetValue("pumn", colPrecUnit.ToString("N2"))
                            r.SetValue("pume", colPrecUnitme.ToString("N2"))
                            r.SetValue("totalmn", VC.ToString("N2"))
                            r.SetValue("totalme", VCme.ToString("N2"))
                            r.SetValue("igvmn", 0)
                            r.SetValue("igvme", 0)
                            r.SetValue("percepcionMN", 0)
                            r.SetValue("percepcionME", 0)

                        Case Else
                            If r.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                r.SetValue("vcmn", VC.ToString("N2"))
                                r.SetValue("vcme", VCme.ToString("N2"))
                                r.SetValue("pumn", colPrecUnit.ToString("N2"))
                                r.SetValue("pume", colPrecUnitme.ToString("N2"))
                                r.SetValue("totalmn", VC.ToString("N2"))
                                r.SetValue("totalme", VCme.ToString("N2"))
                                r.SetValue("igvmn", 0)
                                r.SetValue("igvme", 0)
                                r.SetValue("percepcionMN", 0)
                                r.SetValue("percepcionME", 0)
                            Else
                                If cantidad > 0 Then

                                    r.SetValue("vcmn", VC.ToString("N2"))
                                    r.SetValue("vcme", VCme.ToString("N2"))
                                    r.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    r.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    r.SetValue("totalmn", colBI.ToString("N2"))
                                    r.SetValue("totalme", colBIme.ToString("N2"))
                                    r.SetValue("igvmn", Igv.ToString("N2"))
                                    r.SetValue("igvme", IgvME.ToString("N2"))

                                Else

                                    r.SetValue("vcmn", VC.ToString("N2"))
                                    r.SetValue("vcme", VCme.ToString("N2"))
                                    r.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    r.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    r.SetValue("totalmn", colBI.ToString("N2"))
                                    r.SetValue("totalme", colBIme.ToString("N2"))
                                    r.SetValue("igvmn", Igv.ToString("N2"))
                                    r.SetValue("igvme", IgvME.ToString("N2"))

                                End If

                            End If
                    End Select


            End Select

        Next
        TotalTalesXcolumna()

    End Sub
    Public Property ListaTipoCambio As New List(Of tipoCambio)
    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        If IsDate(txtFecha.Value) Then

            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                Dim consulta = (From n In ListaTipoCambio _
                           Where n.fechaIgv.Year = txtFecha.Value.Year _
                           And n.fechaIgv.Month = txtFecha.Value.Month _
                           And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    txtTipoCambio.DecimalValue = 0
                End If
            End If


            If dgvCompra.Table.Records.Count > 0 Then
                For Each r As Record In dgvCompra.Table.Records
                    r.SetValue("fecEntrega", txtFecha.Value)
                Next
            End If
        End If
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now.Date
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = 0
            .nudTipoCambio.Value = 0
            .ShowDialog()
            LoadTipoCambio()
        End With
    End Sub

    Private Sub DesactivarArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesactivarArticulosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        GetBloquearArticulos(Integer.Parse(Tag), StatusArticulo.Inactivo)
        Cursor = Cursors.Default
    End Sub

    Private Sub ActicarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActicarArtículosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        GetBloquearArticulos(Integer.Parse(Tag), StatusArticulo.Activo)
        Cursor = Cursors.Default
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
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
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                '   cboMoneda.SelectedValue = 2

                If dgvCompra.Table.Records.Count > 0 Then

                Else
                    txtTipoCambio.DecimalValue = 0.0
                End If

            ElseIf cboMoneda.SelectedValue = 1 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                '    cboMoneda.SelectedValue = 1

                Dim consulta = (From n In ListaTipoCambio
                                Where n.fechaIgv.Year = txtFecha.Value.Year _
                             And n.fechaIgv.Month = txtFecha.Value.Month _
                             And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    txtTipoCambio.DecimalValue = 0
                End If
            End If
        End If
    End Sub
End Class