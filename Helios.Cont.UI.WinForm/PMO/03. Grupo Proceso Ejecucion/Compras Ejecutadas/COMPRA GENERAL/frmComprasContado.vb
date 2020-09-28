Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmComprasContado
    Inherits frmMaster

    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of tipoCambio)
    Private sToolTip As SuperToolTip
    'Private IdDocumentoOrden As Integer
    Public Property listaMeses As New List(Of MesesAnio)
    Private conteoListaServicio As Integer = 0

    Private ServicioHijo As New List(Of servicio)
    'Public Property ListadoProveedores As New List(Of entidad)
    Dim gridCaja As New GridGroupingControl
    Dim saldoMN As Decimal

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

    Private Sub AddColumnLotes()
        Dim costoSA As New recursoCostoLoteSA
        Dim lista As New List(Of recursoCostoLote)
        dgvCompra.TableDescriptor.Columns.Add("lote")
        dgvCompra.TableDescriptor.VisibleColumns.Add("lote")
        dgvCompra.TableDescriptor.Columns("lote").MappingName = "lote"
        dgvCompra.TableDescriptor.Columns("lote").HeaderText = "Nro.Lote"
        dgvCompra.TableDescriptor.Columns("lote").Name = "lote"
        dgvCompra.TableDescriptor.Columns("lote").Width = 100
        dgvCompra.TableDescriptor.Columns("lote").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("lote").AllowSort = False

        dgvCompra.TableDescriptor.Columns.Add("fechaProd")
        dgvCompra.TableDescriptor.VisibleColumns.Add("fechaProd")
        dgvCompra.TableDescriptor.Columns("fechaProd").MappingName = "fechaProd"
        dgvCompra.TableDescriptor.Columns("fechaProd").HeaderText = "Fec. Prod."
        dgvCompra.TableDescriptor.Columns("fechaProd").Name = "fechaProd"
        dgvCompra.TableDescriptor.Columns("fechaProd").Width = 100
        dgvCompra.TableDescriptor.Columns("fechaProd").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("fechaProd").Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        dgvCompra.TableDescriptor.Columns("fechaProd").AllowSort = False

        dgvCompra.TableDescriptor.Columns.Add("fechaVcto")
        dgvCompra.TableDescriptor.VisibleColumns.Add("fechaVcto")
        dgvCompra.TableDescriptor.Columns("fechaVcto").MappingName = "fechaVcto"
        dgvCompra.TableDescriptor.Columns("fechaVcto").HeaderText = "Fec. Vcto."
        dgvCompra.TableDescriptor.Columns("fechaVcto").Name = "fechaVcto"
        dgvCompra.TableDescriptor.Columns("fechaVcto").Width = 100
        dgvCompra.TableDescriptor.Columns("fechaVcto").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("fechaVcto").Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        dgvCompra.TableDescriptor.Columns("fechaVcto").AllowSort = False
        'lista = costoSA.GetLotes()
        'lista.Add(New recursoCostoLote With {.nroLote = "Nuevo Lote"})
        'Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("lote").Appearance.AnyRecordFieldCell
        'ggcStyle.CellType = "ComboBox"
        'ggcStyle.DataSource = lista
        'ggcStyle.ValueMember = "nroLote"
        'ggcStyle.DisplayMember = "nroLote"
        'ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        GridCFG(dgvCompra)
        ConfiguracionInicio()
        Loadcontroles()
        Meses()
        GetTableGrid()
        ListaTipoCambio = New List(Of tipoCambio)
        LoadTipoCambio()
        saldoMN = DigitalGauge2.Value
        Me.KeyPreview = True
        'txtTipoCambio.DecimalValue = TmpTipoCambio
        '      Recomendacion()

    End Sub

    Sub Recomendacion()
        lblEstado.Text = "Indicaciones: Identifique la fecha y el tipo de documento de la compra y luego identifique al proveedor!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(20)
    End Sub

    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        GridCFG(dgvCompra)
        Loadcontroles()
        GetTableGrid()
        Meses()
        ListaTipoCambio = New List(Of tipoCambio)
        LoadTipoCambio()
        UbicarDocumento(IdDocumento)
        saldoMN = DigitalGauge2.Value
        Me.KeyPreview = True
    End Sub

    Private Sub Meses()
        Dim empresaPeriodoSA As New empresaPeriodoSA
        listaMeses = New List(Of MesesAnio)
        Dim listaAnios = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = listaAnios
        cboAnio.Text = AnioGeneral

        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x


        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    'Public Sub New(IdDocumento As Integer, strTipoCompra As String, nroOrden As Integer)

    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    GridCFG(dgvCompra)
    '    Loadcontroles()
    '    GetTableGrid()
    '    ConfiguracionInicio()
    '    btGrabar.Enabled = True
    '    UbicarDocumentoOrdenCompra(IdDocumento, strTipoCompra, nroOrden)
    '    'listaOrdenServicio(IdDocumentoOrden)
    '    lblConteo.Text = "(" & conteoListaServicio & ")"
    '    'txtOrden.Visible = True
    '    'lblRefOrden.Visible = True
    '    'lblNroOrden.Visible = True
    '    'txtNroOrden.Visible = True
    '    'PictureBox5.Visible = True
    '    lblConteo.Visible = True
    '    'Label4.Visible = True
    'End Sub

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

    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager

        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
            'dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
            Panel5.Visible = False

            'Label40.Visible = False
            'ComboBoxAdv2.Visible = False
            cboTipoExistencia.Enabled = False
        Else
            cboTipoExistencia.Enabled = True
            'Label40.Visible = True
            'ComboBoxAdv2.Visible = True
            If TmpProduccionPorLotes = True Then
                dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
                dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)

                dockingManager1.SetDockLabel(Panel2, "Existencias")
                dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
                dockingManager1.SetDockVisibility(Panel5, False)
            Else
                dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
                dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)

                dockingManager1.SetDockLabel(Panel2, "Existencias")
                dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
            End If

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
        'lblPerido.Text = PeriodoGeneral
        '   txtTipoCambio.DecimalValue = TmpTipoCambio
        '    txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFechaGuia.Value = New DateTime(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecVence.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        '   txtFecha.Select()
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



    'Public Sub GrabarMarca(iditem As Integer)

    '    Dim itemSA As New itemSA
    '    Dim item As New item
    '    Try
    '        With item
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idEstablecimiento = GEstableciento.IdEstablecimiento
    '            '.idPadre = CboClasificacion.SelectedValue
    '            .idPadre = iditem
    '            .descripcion = txtmarca.Text.Trim
    '            .fechaIngreso = DateTime.Now
    '            .utilidad = 0
    '            .utilidadmayor = 0
    '            .utilidadgranmayor = 0
    '            .usuarioActualizacion = "Jiuni"
    '            .fechaActualizacion = DateTime.Now
    '        End With

    '        Dim codx As Integer = itemSA.InsertarMarcaHijo(item)
    '        'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
    '        'Me.txtCategoria.Tag = CStr(codx)
    '        'txtCategoria.Text = txtNewClasificacion.Text.Trim
    '        Productoshijos()
    '        'Productoshijos2()
    '        'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
    '    Catch ex As Exception
    '        lblEstado.Text = (ex.Message)
    '    End Try
    'End Sub


#End Region

#Region "CESTO SERVICIOS"



#End Region

#Region "Métodos"

    Public Sub llenarGrid(grid As GridGroupingControl, tag As Integer)
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Dim compraSA As New DocumentoCompraSA
        If (tag = 1) Then
            Me.Cursor = Cursors.WaitCursor

            gridCaja = grid

            CalculoPagos()

            Try
                If IsNothing(txtFecVence) Then
                    lblEstado.Text = "Ingresar la fecha de vencimiento"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

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

                'If txtFecha.IsNullDate Then
                '    lblEstado.Text = "Ingrese una fecha de vcto. válida"
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)

                '    Me.Cursor = Cursors.Arrow
                'End If

                '***********************************************************************
                If dgvCompra.Table.Records.Count > 0 Then
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        Dim fechaCierreAnt = txtFechaGuia.Value.AddMonths(-1)
                        Dim validaCierreAnterior As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaCierreAnt.Year, .mes = fechaCierreAnt.Month})
                        If validaCierreAnterior = False Then
                            MessageBox.Show("No puede realizar está operación" & vbCrLf & "debe cerrar el período anterior, " & fechaCierreAnt.Month & "-" & fechaCierreAnt.Year, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If


                        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtFechaGuia.Value.Year, .mes = txtFechaGuia.Value.Month})
                        If Not IsNothing(valida) Then
                            If valida = True Then
                                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If

                        Dim comprobante = compraSA.CompraEsvalida(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                        .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                        .serie = txtSerie.Text.Trim,
                                                                                        .numeroDoc = txtNumero.Text.Trim,
                                                                                        .tipoDoc = cboTipoDoc.SelectedValue,
                                                                                        .idProveedor = txtProveedor.Tag})

                        If comprobante = True Then ' si la compra es unica
                            Grabar()
                            Close()
                        Else
                            If MessageBox.Show("El número de comprobante ya existe en la base de datos!, desea seguir?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Grabar()
                                Close()
                            End If
                        End If
                    ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                        'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                        'If Filas > 0 Then
                        '    UpdateCompra()

                        'UpdateServicioPublico()
                    End If
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

    'Public Sub GrabarCategoria()
    '    Dim itemSA As New itemSA
    '    Dim item As New item
    '    Try
    '        With item
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idEstablecimiento = GEstableciento.IdEstablecimiento
    '            .descripcion = txtNewClasificacion.Text.Trim
    '            .fechaIngreso = DateTime.Now
    '            .utilidad = 0
    '            .utilidadmayor = 0
    '            .utilidadgranmayor = 0
    '            .usuarioActualizacion = "Jiuni"
    '            .fechaActualizacion = DateTime.Now
    '        End With

    '        Dim codx As Integer = itemSA.SaveCategoria(item)
    '        'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
    '        'Me.txtCategoria.Tag = CStr(codx)
    '        'txtCategoria.Text = txtNewClasificacion.Text.Trim

    '        'Productoshijos()
    '        CMBClasificacion()
    '        'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
    '    Catch ex As Exception
    '        lblEstado.Text = (ex.Message)
    '    End Try
    'End Sub


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
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR, txtRuc.Text)
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                txtProveedor.Clear()
                txtRuc.Clear()
                entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
                If Not IsNothing(entidad) Then
                    With entidad
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idEntidad
                        '   txtCuenta.Text = .cuentaAsiento
                        txtRuc.Text = .nrodoc
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End With
                End If

            End If
        End If
    End Sub

    Public Sub UbicarCuentaHijo(strNro As String)


        Dim consulta = (From a In ServicioHijo Where a.cuenta = strNro).FirstOrDefault

        If Not IsNothing(consulta) Then

            txtCuenta.Text = consulta.cuenta
            cboServicio.SelectedValue = consulta.idServicio

        Else
            txtCuenta.Clear()
            '  txtCuenta.Clear()
            cboServicio.SelectedValue = -1

        End If
    End Sub

    Public Sub UbicarDocumentoOrdenCompra(ByVal intIdDocumento As Integer, strTipoCompra As String, nroOrden As Integer)
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
            'DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtSerieGuia.Text = .Serie
            '        txtNumeroGuia.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE

            'IdDocumentoOrden = intIdDocumento
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                If Not IsNothing(.fechaConstancia) Then
                    txtFecDetraccion.Value = .fechaConstancia
                End If
                txtNroConstancia.Text = .nroConstancia
                cboMesCompra.SelectedValue = String.Format("0:00", .fechaDoc.Value.Month)
                txtDia.Value = New Date(.fechaDoc.Value.Year, .fechaDoc.Value.Month, .fechaDoc.Value.Day)
                cboAnio.Text = .fechaDoc.Value.Year
                'lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                'cboTipoDoc.SelectedValue = .tipoDoc
                'txtSerie.Text = .serie
                'txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                'Select Case strTipoCompra
                '    Case TIPO_COMPRA.ORDEN_APROBADO
                '        txtOrden.Text = "ORDEN DE COMPRA"
                '    Case TIPO_COMPRA.ORDEN_SERVICIO_APROBADO
                '        txtOrden.Text = "ORDEN DE SERVICIO"
                'End Select

                'txtNroOrden.Text = nroOrden


                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
                        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

                        cboMoneda.SelectedValue = 1
                        '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
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
                        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
                        cboMoneda.SelectedValue = 2
                        '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

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
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalleSituacion(intIdDocumento, TIPO_COMPRA.ORDEN_COMPRA)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
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


                Select Case i.tipoExistencia
                    Case "GS"

                    Case "01"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
                    Case "08"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

                End Select



                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)

                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            'btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    'Public Sub listaOrdenServicio(ByVal intIdDocumento As Integer) ' As List(Of documentocompradetalle)
    '    Dim objDoc As New DocumentoSA
    '    Dim objDocCompra As New DocumentoCompraSA
    '    Dim objDocCompraDet As New DocumentoCompraDetalleSA
    '    Dim objEntidad As New entidadSA
    '    Dim nEntidad As New entidad
    '    Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
    '    Dim documentoCajaSA As New DocumentoCajaSA
    '    Dim objDocCaja As New DocumentoSA
    '    Dim establecSA As New establecimientoSA
    '    Dim inventarioBL As New inventarioMovimientoSA
    '    Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
    '    Dim DocumentoGuia As New documentoguiaDetalle

    '    Try


    '        Select Case cboMoneda.SelectedValue
    '            Case 1


    '                dgvListaServicio.TableDescriptor.Columns("vcmn").Width = 65
    '                dgvListaServicio.TableDescriptor.Columns("igvmn").Width = 65
    '                dgvListaServicio.TableDescriptor.Columns("totalmn").Width = 70

    '                dgvListaServicio.TableDescriptor.Columns("vcme").Width = 0
    '                dgvListaServicio.TableDescriptor.Columns("igvme").Width = 0
    '                dgvListaServicio.TableDescriptor.Columns("totalme").Width = 0


    '                cboMoneda.SelectedValue = 1
    '                '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
    '            Case 2

    '                dgvListaServicio.TableDescriptor.Columns("vcmn").Width = 0
    '                dgvListaServicio.TableDescriptor.Columns("igvmn").Width = 0
    '                dgvListaServicio.TableDescriptor.Columns("totalmn").Width = 0

    '                dgvListaServicio.TableDescriptor.Columns("vcme").Width = 65
    '                dgvListaServicio.TableDescriptor.Columns("igvme").Width = 65
    '                dgvListaServicio.TableDescriptor.Columns("totalme").Width = 70

    '                cboMoneda.SelectedValue = 2

    '        End Select


    '        'DETALLE DE LA COMPRA
    '        dgvListaServicio.Table.Records.DeleteAll()

    '        For Each i In objDocCompraDet.UbicarDocumentoCompraDetalleSituacion(intIdDocumento, TIPO_COMPRA.ORDEN_SERVICIO)

    '            Me.dgvListaServicio.Table.AddNewRecord.SetCurrent()
    '            Me.dgvListaServicio.Table.AddNewRecord.BeginEdit()
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("codigo", 0)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("gravado", i.destino)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("idProducto", i.idItem)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("item", i.descripcionItem)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("um", i.unidad1)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("cantidad", i.monto1)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("totalmn", i.importe)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("totalme", i.importeUS)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
    '            Me.dgvListaServicio.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
    '            Me.dgvListaServicio.Table.AddNewRecord.EndEdit()

    '            conteoListaServicio += 1
    '        Next
    '        'btGrabar.Enabled = False
    '        'TotalTalesXcolumna()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try

    'End Sub


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
                If Not IsNothing(.fechaConstancia) Then
                    txtFecDetraccion.Value = .fechaConstancia
                End If
                txtNroConstancia.Text = .nroConstancia
                cboMesCompra.SelectedValue = String.Format("0:00", .fechaDoc.Value.Month)
                txtDia.Value = New Date(.fechaDoc.Value.Year, .fechaDoc.Value.Month, .fechaDoc.Value.Day)
                cboAnio.Text = .fechaDoc.Value.Year
                'lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
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
                        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

                        cboMoneda.SelectedValue = 1
                        '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
                        cboMoneda.SelectedValue = 2
                        '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

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
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
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


                Select Case i.tipoExistencia
                    Case "GS"

                    Case "01"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
                    Case "08"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

                End Select



                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)



                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaGuia.Value
            .periodo = lblPerido.Text
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

        For Each r As Record In dgvCompra.Table.Records

            If r.GetValue("tipoExistencia") <> "GS" Then

                If r.GetValue("tipoExistencia") <> "08" Then

                    Dim alm = r.GetValue("almacen")
                    If alm.ToString.Trim.Length > 0 Then
                        If r.GetValue("almacen") <> idAlmacenVirtual Then
                            documentoguiaDetalle = New documentoguiaDetalle
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
                    Else
                        Throw New Exception("Debe ingresar un almacén valido.")
                    End If




                End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Public Function AsientoCabeceraCompra(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        'ASIENTO POR LA COMPRA
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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

    Function MovAsientoCosto(R As Record) As List(Of movimiento)
        Dim lista As New List(Of movimiento)
        Dim nMovimiento As New movimiento

        lista = New List(Of movimiento)

        'asiento del costo x entregar
        nMovimiento = New movimiento
        nMovimiento.cuenta = "91"
        nMovimiento.descripcion = R.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = CDec(R.GetValue("vcmn"))
        nMovimiento.montoUSD = CDec(R.GetValue("vcme"))
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        lista.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "791"
        nMovimiento.descripcion = R.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = CDec(R.GetValue("vcmn"))
        nMovimiento.montoUSD = CDec(R.GetValue("vcme"))
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        lista.Add(nMovimiento)

        Return lista
    End Function

    Public Sub AsientoCompra()
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        '  Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoCabeceraCompra(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME) ' CABECERA ASIENTO

        '---------------------------------------------------------------------------------------------
        'DETALLE DEL ASIENTO DE COMPRA
        'MOVIMIENTOS
        For Each r As Record In dgvCompra.Table.Records

            '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
            If r.GetValue("valBonif") <> "S" Then

                nMovimiento = New movimiento
                If Not r.GetValue("tipoExistencia") = "GS" Then
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, r.GetValue("tipoExistencia"), "ITEM", "COMPRA")
                    Select Case r.GetValue("tipoExistencia")
                        Case "08"

                            nMovimiento.cuenta = "338"
                            ' nMovimiento.cuenta = r.GetValue("cuentaAct")


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
                            nMovimiento.usuarioActualizacion = usuario.IDUsuario
                            asientoTransitod.movimiento.Add(nMovimiento)
                    End Select
                Else
                    'GASTOS Y SERVICIOS

                    Dim cuentaServicio = r.GetValue("idProducto")

                    If cuentaServicio.ToString().StartsWith("11") Then

                    ElseIf cuentaServicio.ToString().StartsWith("18") Then

                    ElseIf cuentaServicio.ToString().StartsWith("3") Then

                    Else
                        For Each i In MovAsientoCosto(r)
                            asientoTransitod.movimiento.Add(i)
                        Next
                    End If

                    nMovimiento.cuenta = r.GetValue("idProducto")
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
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    asientoTransitod.movimiento.Add(nMovimiento)
                End If

                If CDec(r.GetValue("percepcionMN")) > 0 Then
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = "40113"
                    nMovimiento.descripcion = r.GetValue("item")
                    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                    nMovimiento.monto = CDec(r.GetValue("percepcionMN"))
                    nMovimiento.montoUSD = CDec(r.GetValue("percepcionME"))
                    nMovimiento.fechaActualizacion = DateTime.Now
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
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
              .usuarioActualizacion = usuario.IDUsuario}

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
              .usuarioActualizacion = usuario.IDUsuario}

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
        nAsiento.periodo = lblPerido.Text
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
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
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
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
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
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

        '---------------------------orden situacion ------------
        Dim objDocotrasDatos As New documentoOtrosDatos


        '------------------------------------------ lista de Precio ------------------------------------
        Dim PreciosConIVABE As New listadoPrecios
        Dim PreciosSINIVABE As New listadoPrecios
        Dim listaPrecioSA As New ListadoPrecioSA

        Dim PrecioUnitarioMN As Decimal = 0.0

        Dim FichaEFSaldo As New GFichaUsuario


        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        ListaAsientonTransito = New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtRuc.Text
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = Nothing ' IdDocumentoOrden
            .codigoLibro = "8"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaDoc = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .fechaVcto = txtFecVence.Value
            .fechaContable = lblPerido.Text
            '.fechaConstancia = txtFecDetraccion.Value
            '.nroConstancia = txtNroConstancia.Text
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
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA_PAGADA
            .situacion = statusComprobantes.Normal

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
        GuiaRemision(ndocumento)

        If CDec(txtTotalPagar.DecimalValue) > 0 Then
            AsientoCompra()
        End If
        'ASIENTOS CONTABLES
        Dim costoSA As New recursoCostoLoteSA
        For Each r As Record In dgvCompra.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            'Validando el nro de lote
            If TmpProduccionPorLotes = True Then
                Dim nroLotex = r.GetValue("lote").ToString

                If nroLotex.ToString.Trim.Length > 0 Then
                    If costoSA.ExisteCodigoLote(r.GetValue("lote")) = True Then
                        lblEstado.Text = "El número de lote ingresado ya existe, ingrese otro porfavor."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    Else
                        objDocumentoCompraDet.nrolote = nroLotex

                        objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                        objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = nroLotex
                        objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                        objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
                        objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))


                    End If
                Else
                    lblEstado.Text = "Debe ingresar el nro de lote para el artículo, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            End If

            'If tmpConfigInicio.proyecto = "S" Then
            '    objDocumentoCompraDet.idCosto = CInt(r.GetValue("proyecto"))
            '    objDocumentoCompraDet.tipoCosto = "PY"
            'Else
            '    objDocumentoCompraDet.tipoCosto = Nothing
            'End If

            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            If r.GetValue("valBonif") = "S" Then
                ' objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                objDocumentoCompraDet.TipoOperacion = "9917"

                Select Case r.GetValue("tipoExistencia")
                    Case "GS"

                    Case "08"

                    Case Else
                        AsientoBONIF(r)
                End Select
            Else
                '   objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                objDocumentoCompraDet.TipoOperacion = "02"
                Select Case r.GetValue("tipoExistencia")

                    Case "08"

                    Case "GS"

                    Case Else
                        MV_Item_Transito(r)
                End Select
            End If

            objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_PAGADA
            Select Case r.GetValue("tipoExistencia")

                Case "08"
                    objDocumentoCompraDet.FechaDoc = txtFechaGuia.Value ' r.GetValue("fecEntrega")
                Case "GS"
                    objDocumentoCompraDet.FechaDoc = Nothing
                Case Else
                    objDocumentoCompraDet.FechaDoc = txtFechaGuia.Value 'r.GetValue("fecEntrega")
            End Select

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
                    Dim alm = r.GetValue("almacen")
                    If alm.ToString.Trim.Length > 0 Then
                        objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacen"))
                    Else
                        lblEstado.Text = "Ingrese un almacén valido para el item: " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                    End If

                    objDocumentoCompraDet.fechaEntrega = CDate(r.GetValue("fecEntrega"))

                    If almacenSA.GetEsAlmacenVirtual(objDocumentoCompraDet.almacenRef) = True Then
                        objDocumentoCompraDet.ItemEntregadototal = "N"
                    Else
                        objDocumentoCompraDet.ItemEntregadototal = "S"
                    End If

            End Select
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
                    objDocumentoCompraDet.situacion = statusComprobantes.Normal
                    objDocumentoCompraDet.entregable = "NO"
                Else
                    objDocumentoCompraDet.situacion = statusComprobantes.Normal
                    objDocumentoCompraDet.entregable = "SI"
                End If
            End If

            ' Dim montopagado As Decimal
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario

            Dim marcaVal = IIf(IsDBNull(r.GetValue("marca")), Nothing, r.GetValue("marca"))
            objDocumentoCompraDet.marcaRef = marcaVal
            Dim clas = (r.GetValue("cat"))
            If clas.ToString.Trim.Length > 0 Then
                objDocumentoCompraDet.categoria = clas
            Else
                objDocumentoCompraDet.categoria = Nothing
            End If
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        AsientoItemPagado()
        ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'DocCaja = ComprobanteCaja()
        ndocumento.ListaCustomDocumento = ListaDocumentoCaja()

        Dim xcod As Integer = CompraSA.SaveCompraNuevoMetodoContado(ndocumento, ListaTotales)
        'If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

        'Else
        '    If tmpConfigInicio.cronogramaPagos = True Then
        '        If Not ComboBoxAdv2.Text = "DE CONTADO" Then
        '            If MessageBoxAdv.Show("¿Desea Negociar?" + vbCrLf + vbCrLf + Space(15) + txtFecha.Text, txtFecha.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


        '                With frmNegociacionPagos
        '                    .lblIdDocumento.Text = xcod
        '                    .txtImporteCompramn.Value = TotalesXcanbeceras.TotalMN
        '                    .txtImporteComprame.Value = TotalesXcanbeceras.TotalME
        '                    .txttipocambio.Value = txtTipoCambio.DecimalValue
        '                    ' .txtMoneda.Text = IIf(cboMoneda.SelectedValue = 1, "1", "2")
        '                    If cboMoneda.SelectedValue = "1" Then
        '                        .txtMoneda.Text = "NAC"
        '                    ElseIf cboMoneda.SelectedValue = "2" Then
        '                        .txtMoneda.Text = "EXT"
        '                    End If
        '                    .txtSerie.Text = txtSerie.Text.Trim
        '                    .txtNumero.Text = txtNumero.Text
        '                    .txtCliente.Text = txtProveedor.Text
        '                    .txtCliente.Tag = CInt(txtProveedor.Tag)
        '                    .txtRuc.Text = txtRuc.Text
        '                    .StartPosition = FormStartPosition.CenterParent
        '                    .ShowDialog()
        '                End With

        '            Else

        '            End If

        '        End If
        '    End If
        'End If


        '  Close()

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
                nDocumentoCaja.tipoDoc = cboTipoDoc.SelectedValue
                nDocumentoCaja.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nDocumentoCaja.nroDoc = txtNumero.Text
                nDocumentoCaja.idOrden = Nothing
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        nDocumentoCaja.moneda = 1
                    Case "EXTRANJERO"
                        nDocumentoCaja.moneda = 2
                End Select
                nDocumentoCaja.idEntidad = Val(txtProveedor.Tag)
                nDocumentoCaja.entidad = txtProveedor.Text
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                nDocumentoCaja.nrodocEntidad = txtRuc.Text
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES
                objCaja.idDocumento = 0
                objCaja.periodo = lblPerido.Text
                If txtProveedor.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = txtProveedor.Tag
                End If
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                objCaja.fechaCobro = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                If txtProveedor.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtProveedor.Tag
                End If
                objCaja.TipoDocumentoPago = "14"
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = "14"
                objCaja.NumeroDocumento = txtNumero.Text
                objCaja.numeroOperacion = i.GetValue("numOper")

                objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                        objCaja.tipoCambio = TmpTipoCambio
                        objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                    Case "EXTRANJERO"
                        objCaja.moneda = 2
                        objCaja.tipoCambio = i.GetValue("tipocambio")
                        objCaja.montoUsd = CDec(i.GetValue("montoME"))
                End Select


                objCaja.estado = "P"
                objCaja.glosa = "Por compra directa " & "nro. " & "-" & txtNumero.Text & " fecha: " & New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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

        asiento = AsientoTransito2(doc.montoSoles, doc.montoUsd)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd

        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "4212"
        nMovimiento.descripcion = "Compra al contado"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asiento.movimiento.Add(nMovimiento)

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "1213"
        'nMovimiento.descripcion = txtProveedor.Text
        'nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        'nMovimiento.monto = doc.montoSoles
        'nMovimiento.montoUSD = doc.montoUsd
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = DateTime.Now
        'asiento.movimiento.Add(nMovimiento)

    End Sub

    Public Function AsientoTransito2(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If doc.NombreEntidad = i.SubItems(1).Text Then
                obj = New documentoCajaDetalle
                obj.fecha = Date.Now
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = CDbl(i.SubItems(4).Text)
                obj.montoUsd = CDbl(i.SubItems(5).Text)

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

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvCompra.Table.Records
            If Not r.GetValue("tipoExistencia") = "GS" Then

                If Not r.GetValue("tipoExistencia") = "08" Then

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
                    objTotalesDet.usuarioActualizacion = usuario.IDUsuario
                    objTotalesDet.fechaActualizacion = Date.Now
                    ListaTotales.Add(objTotalesDet)
                    'End If
                End If
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
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.periodo = lblPerido.Text
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
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
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(txtProveedor.Tag)
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            nAsiento.periodo = lblPerido.Text
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
                'nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta


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
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
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
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
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
                    If r.GetValue("valBonif") <> "S" Then
                        bs1 += CDec(r.GetValue("vcmn"))
                        bs1me += CDec(r.GetValue("vcme"))

                        igv1 += CDec(r.GetValue("igvmn"))
                        igv1me += CDec(r.GetValue("igvme"))
                    End If



                Case "2"
                    If r.GetValue("valBonif") <> "S" Then
                        bs2 += CDec(r.GetValue("vcmn"))
                        bs2me += CDec(r.GetValue("vcme"))

                        igv2 += CDec(r.GetValue("igvmn"))
                        igv2me += CDec(r.GetValue("igvme"))
                    End If

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
            DigitalGauge2.Value = total
        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
            DigitalGauge2.Value = totalme
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


    Public Sub AddCodigoEncontrado()
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim ITEMSA As New itemSA
        Dim ITEM As New item

        If txtTipoCambio.DecimalValue > 0 Then
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

                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second))
                Me.dgvCompra.Table.AddNewRecord.EndEdit()

            End If

        Else
            MessageBox.Show("Ingrese un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub ProductoXcodigoBarra(codigobarra As String)
        Dim existenciaSA As New detalleitemsSA
        Dim objeto As New detalleitems
        lsvListadoItems.Items.Clear()
        Try
            objeto = existenciaSA.GetUbicarProductoXcodigoBarra(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, codigobarra)

            If Not IsNothing(objeto) Then


                'If MessageBoxAdv.Show("Desea agregar el producto encontrado a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", objeto.origenProducto)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", objeto.codigodetalle)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("item", (objeto.codigo & "/" & objeto.descripcionItem))
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("um", objeto.unidad1)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", objeto.tipoExistencia)

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                '    If CStr(objeto.tipoExistencia) <> "GS" Then
                '        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
                '        Else
                '            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                '        End If
                '    End If

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", objeto.presentacion)

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)

                '    Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)
                '    Me.dgvCompra.Table.AddNewRecord.EndEdit()



                'Else
                Dim n As New ListViewItem(objeto.codigodetalle)
                n.SubItems.Add((objeto.descripcionItem))
                'n.SubItems.Add((objeto.codigo & "   " & "-" & "   " & objeto.descripcionItem))
                n.SubItems.Add(objeto.unidad1)
                n.SubItems.Add(objeto.tipoExistencia)
                n.SubItems.Add(objeto.origenProducto)
                n.SubItems.Add(objeto.codigo)
                n.SubItems.Add(0)
                n.SubItems.Add(objeto.cuenta)
                n.SubItems.Add(objeto.presentacion)
                lsvListadoItems.Items.Add(n)

                ' End If
            Else

            End If
        Catch ex As Exception

            MessageBox.Show("No se encontro el producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub



    Private Sub ListaMercaderiasXIdHijo(iditem As Integer, tipo As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXIdHijo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, iditem, tipo)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.codigo & "   " & "-" & "   " & i.descripcionItem)
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

    'Private Sub ListaMercaderiasXIdHijo2(iditem As Integer, tipo As String)
    '    Dim existenciaSA As New detalleitemsSA
    '    ListView1.Items.Clear()
    '    For Each i In existenciaSA.GetUbicarProductoXIdHijo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, iditem, tipo)
    '        Dim n As New ListViewItem(i.codigodetalle)
    '        n.SubItems.Add(i.descripcionItem)
    '        n.SubItems.Add(i.unidad1)
    '        n.SubItems.Add(i.tipoExistencia)
    '        n.SubItems.Add(0)
    '        n.SubItems.Add(0)
    '        n.SubItems.Add(0)
    '        n.SubItems.Add(i.cuenta)
    '        n.SubItems.Add(i.presentacion)
    '        ListView1.Items.Add(n)
    '    Next

    'End Sub



    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            '   n.SubItems.Add(i.codigo & "   " & "-" & "   " & i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(i.codigo)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub


    'Private Sub ListaMercaderias08(strTipoEx As String, strBusqueda As String)
    '    Dim existenciaSA As New detalleitemsSA
    '    ListView1.Items.Clear()
    '    For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
    '        Dim n As New ListViewItem(i.codigodetalle)
    '        n.SubItems.Add(i.descripcionItem)
    '        n.SubItems.Add(i.unidad1)
    '        n.SubItems.Add(i.tipoExistencia)
    '        n.SubItems.Add(0)
    '        n.SubItems.Add(0)
    '        n.SubItems.Add(0)
    '        n.SubItems.Add(i.cuenta)
    '        n.SubItems.Add(i.presentacion)
    '        ListView1.Items.Add(n)
    '    Next

    'End Sub


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


    Public Sub GetServiviosPadre()
        Dim servicioSA As New servicioSA
        For Each I In servicioSA.ListadoServiciosPadreTipo("PC")
            Dim n As New ListViewItem()
            n.Text = I.cuenta
            n.SubItems.Add(I.descripcion)
            n.SubItems.Add(I.idServicio)
            lsvServicios.Items.Add(n)
        Next

    End Sub

    Public Sub GetServiviosHijo(idservicio As Integer)
        Dim servicioSA As New servicioSA

        ServicioHijo.Clear()
        cboServicio.DisplayMember = "descripcion"
        cboServicio.ValueMember = "idServicio"
        ServicioHijo = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = idservicio})
        cboServicio.DataSource = ServicioHijo

    End Sub

    Public Sub GetServiviosHijoActivos(cuentaPadre As String)
        Dim servicioSA As New cuentaplanContableEmpresaSA


        cboServicio.DisplayMember = "descripcion"
        cboServicio.ValueMember = "cuenta"
        cboServicio.DataSource = servicioSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, cuentaPadre)

    End Sub

    'Private Sub CMBClasificacionActivo()
    '    Dim categoriaSA As New itemSA
    '    Dim eNtidad As New List(Of item)
    '    Dim eNtidad2 As New List(Of item)
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idItem")
    '    dt.Columns.Add("descripcion")
    '    'Dim objENtidad As New item With {.idItem = 0, .descripcion = "Seleccione un Item"}


    '    For Each i In categoriaSA.GetListaPadre()
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idItem
    '        dr(1) = i.descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    Dim view As DataView = New DataView(dt)
    '    CboClasificacion1.DisplayMember = "descripcion"
    '    CboClasificacion1.ValueMember = "idItem"
    '    CboClasificacion1.DataSource = view
    '    CboClasificacion1.SelectedValue = 0
    'End Sub

    Dim listaCategoria As New List(Of item)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA
        'Dim objItem As New item With {.idItem = 0, .descripcion = "Seleccione un Item"}
        listaCategoria = New List(Of item)

        'Dim dt As New DataTable()
        'dt.Columns.Add("idItem")
        'dt.Columns.Add("descripcion")

        listaCategoria = categoriaSA.GetListaPadre()
        Label42.Text = listaCategoria.Count & " items"

        'For Each i In categoriaSA.GetListaPadre()
        '    '    Dim dr As DataRow = dt.NewRow
        '    '    dr(0) = i.idItem
        '    '    dr(1) = i.descripcion
        '    '    dt.Rows.Add(dr)
        'Next
        'CboClasificacion.HighlightBorderOnMouseEvents = True
        'CboClasificacion.GridLineHorizontal = True
        'CboClasificacion.GridLineVertical = True
        'CboClasificacion.ColumnNum = 2
        'CboClasificacion.SelectedIndex = -1
        'CboClasificacion.Items.Clear()
        'CboClasificacion.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        'CboClasificacion.SourceDataString = New String(1) {"descripcion", "idItem"}
        'CboClasificacion.SourceDataTable = dt

    End Sub

    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA

        ListaTipoCambio = tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, CInt(cboMesCompra.SelectedValue), CInt(cboAnio.Text), GEstableciento.IdEstablecimiento)
        Dim consulta = (From n In ListaTipoCambio
                        Where n.fechaIgv.Year = cboAnio.Text _
                       And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                       And n.fechaIgv.Day = DiaLaboral.Day).FirstOrDefault

        If Not IsNothing(consulta) Then
            txtTipoCambio.DecimalValue = consulta.venta
        Else
            'txtTipoCambio.DecimalValue = 0
        End If
    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0



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
        '-------------------------------------------------------------------
        txtBuscarProducto.Visible = True
        btnNuevoProd.Visible = True

        Label16.Text = "Buscar item"
        txtCategoria.Visible = False
        PictureBox2.Visible = False
        Label42.Visible = False
        Label43.Visible = False

        Label35.Visible = False
        txtSubCategoria.Visible = False
        PictureBox6.Visible = False

        'TextBoxExt3.Visible = True
        'PictureBox5.Visible = True

        'Label31.Text = "Buscar activo"
        'CboClasificacion1.Visible = False
        'PictureBox4.Visible = False
        ''------------------------------------

        'Label39.Visible = False
        'cboProductos2.Visible = False
        'PictureBox7.Visible = False

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            cboDestino.Enabled = False
        Else
            cboDestino.Enabled = True
        End If

        'ListadoProveedores = New List(Of entidad)
        'ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.PROVEEDOR, Gempresas.IdEmpresaRuc)


    End Sub


    Public Function GetTablePuntoUbicacion2() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        For Each i In almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "PU")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function



    Public Function GetTablePuntoUbicacion() As DataTable
        'Dim almacenSA As New almacenSA
        'Dim dt As New DataTable()
        'dt.Columns.Add("idAlmacen", GetType(Integer))
        'dt.Columns.Add("descripcionAlmacen", GetType(String))

        'For Each i In almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "PU")
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idAlmacen
        '    dr(1) = i.descripcionAlmacen
        '    dt.Rows.Add(dr)
        'Next
        'Return dt

        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "A"
        dr(1) = "ALMACEN"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "T"
        dr1(1) = "PUNTO UBICACION"
        dt.Rows.Add(dr1)

        Return dt

    End Function



    Public Function GetTableAlmacenPuntoUbi() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        For Each i In almacenSA.GetListar_almaUbiPunto(GEstableciento.IdEstablecimiento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


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
    Dim comboTable As New DataTable
    Dim comboTable1 As New DataTable
    Dim comboTable3 As New DataTable
    Dim comboTableP As New DataTable
    Private Sub frmCompras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    'update2
    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxAdv1.SelectedIndex = -1
        comboTableP = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(14).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTableP
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompra.ShowRowHeaders = False
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
        'Try
        '    If txtSerie.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        '        txtSerieGuia.Text = txtSerie.Text
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

        '                If Len(txtSerie.Text) <= 2 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

        '                ElseIf Len(txtSerie.Text) <= 3 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

        '                ElseIf Len(txtSerie.Text) <= 4 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

        '                ElseIf Len(txtSerie.Text) <= 5 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerie.Select()
        '            txtSerie.Focus()
        '            txtSerie.Clear()
        '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '            Timer1.Enabled = True
        '            PanelError.Visible = True
        '            TiempoEjecutar(10)

        '        End If

        '    Else

        '        txtSerie.Select()
        '        txtSerie.Focus()
        '        txtSerie.Clear()
        '        lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '    End If

        'End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
        txtSerieGuia.Text = txtSerie.Text
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
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
                f.CaptionLabels(0).Text = "Proveedor"
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
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        'Try
        '    If txtNumero.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
        '    txtNumero.Select()
        '    txtNumero.Focus()
        '    txtNumero.Clear()
        '    lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        'End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
        txtNumeroGuia.Text = txtNumero.Text
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    'Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
    '    Me.Cursor = Cursors.WaitCursor
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        If lstCategoria.SelectedItems.Count > 0 Then
    '            Me.txtCategoria.Tag = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id)
    '            'txtCategoria.PasswordChar = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad)
    '            txtCategoria.Text = lstCategoria.Text
    '            ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id, cboTipoExistencia.SelectedValue, DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
    '        End If
    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.txtCategoria.Focus()
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click


        Dim f As New frmNuevaClasificacion
        f.StartPosition = FormStartPosition.CenterParent

        f.ShowDialog()
        CMBClasificacion()


        'Me.Cursor = Cursors.WaitCursor
        'pcClasificacion.Font = New Font("Tahoma", 8)
        'pcClasificacion.Size = New Size(337, 150)
        'Me.pcClasificacion.ParentControl = Me.txtCategoria
        'Me.pcClasificacion.ShowPopup(Point.Empty)
        'lbltipoexist.Text = "C"
        'txtNewClasificacion.Clear()
        'txtNewClasificacion.Select()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        'Me.Cursor = Cursors.WaitCursor
        'If txtCategoria.Text.Trim.Length > 0 Then
        '    ListadoProductosPorCategoriaTipoExistencia(txtCategoria.Tag, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        'If cboTipoExistencia.SelectedIndex > -1 Then
        '    If txtCategoria.Text.Trim.Length > 0 Then
        '        ListadoProductosPorCategoriaTipoExistencia(txtCategoria.Tag, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        '    End If
        'End If
    End Sub

    'Private Sub pcClasificacion_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    Me.pcClasificacion.BackColor = Color.White
    'End Sub



    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)
        Dim ITEMSA As New itemSA
        Dim ITEM As New item

        If txtTipoCambio.DecimalValue > 0 Then
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
                If CStr(selFila.SubItems(3).Text) = "GS" Then

                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
                Else
                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacen(0).idAlmacen)
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



                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second))
                Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", (selFila.SubItems(5).Text))
                If TmpProduccionPorLotes = True Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", DiaLaboral)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("fechaProd", DiaLaboral)
                End If
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
                'End With
            End If

        Else
            MessageBox.Show("Ingrese un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipoCambio.Select()
        End If


    End Sub
    Sub GetTableGrid()

        If TmpProduccionPorLotes = True Then
            AddColumnLotes()
        End If

        If tmpConfigInicio.proyecto = "S" Then
            '    AddColumnProyecto()
        End If

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
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("lote", GetType(String))
        dt.Columns.Add("fechaProd", GetType(DateTime))
        dt.Columns.Add("fechaVcto", GetType(DateTime))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("pagado", GetType(Decimal))
        ' dt.Columns.Add("cuentaAct", GetType(String))

        dgvCompra.DataSource = dt

        Dim dtLista As New DataTable()

        dtLista.Columns.Add("codigo", GetType(String))
        dtLista.Columns.Add("gravado", GetType(String))
        dtLista.Columns.Add("idProducto", GetType(Integer))
        dtLista.Columns.Add("item", GetType(String))
        dtLista.Columns.Add("um", GetType(String))
        dtLista.Columns.Add("cantidad", GetType(Decimal))
        dtLista.Columns.Add("vcmn", GetType(Decimal))
        dtLista.Columns.Add("totalmn", GetType(Decimal))
        dtLista.Columns.Add("vcme", GetType(Decimal))
        dtLista.Columns.Add("totalme", GetType(Decimal))
        dtLista.Columns.Add("igvmn", GetType(Decimal))
        dtLista.Columns.Add("igvme", GetType(Decimal))

        'dgvListaServicio.DataSource = dtLista

        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50



    End Sub

    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click

        'If cboProductos.Text.Trim.Length > 0 Then
        Dim almacen As New List(Of almacen)
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'If txtCategoria.Text.Trim.Length > 0 Then
        'If Not IsNothing(txtCategoria.Tag) Then
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                If txtTipoCambio.DecimalValue > 0 Then
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
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)



                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                                'If .tipoExistencia <> "GS" Then
                                '    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                                '        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
                                '    Else
                                '        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                                '    End If
                                '    'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                                '    sdfsf()
                                'End If

                                If .tipoExistencia = "GS" Then

                                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
                                Else
                                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                                        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacen(0).idAlmacen)
                                    Else
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                                    End If
                                End If

                                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
                                Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)

                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second))

                                Dim imItem = .idItem

                                If (Not IsNothing(imItem)) Then
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cat", ITEMSA.UbicarCategoriaPorID(.idItem).idPadre)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", CStr(imItem))
                                Else
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)
                                End If
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")

                                Me.dgvCompra.Table.AddNewRecord.EndEdit()
                            End With
                            ' End If


                        End If
                    End If
                Else
                    MessageBox.Show("Debe ingresar un t/c mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTipoCambio.Select()
                End If

            End If
        End With
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

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then

                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                        If IsNumeric(e.Style.CellValue) Then
                            If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                                e.Style.CellValue = 1
                            End If
                        Else
                            e.Style.CellValue = 1
                        End If

                    Case "08"
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
                        e.Style.BackColor = Color.Yellow
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "almacen")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                        e.Style.CellValue = 1
                    Case "08"
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

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "fechaVcto" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                e.Handled = True
            End If

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "fechaProd" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                e.Handled = True
            End If

            'If e.TableCellIdentity.Column.Name = "gravado" Then
            '    If e.Style.CellValue.Equals("1") Then



            '        e.Style.BackColor = Color.LightYellow
            '    End If
            'End If
            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                e.Style.CellTipText = "Ingresar cantidad"
            End If


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

    Private Sub dgvCompra_QueryCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.QueryCellText

    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged
        Dim s1 As GridRangeInfoList = dgvCompra.TableModel.Selections.GetSelectedRows(True, True)
        For Each info As GridRangeInfo In s1
            Dim el As Element = dgvCompra.TableModel.GetDisplayElementAt(info.Top)
            Dim str As String = el.GetRecord().GetValue("cantidad")
        Next

    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanging

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
        Try
            If txtTipoCambio.DecimalValue > 0 Then
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                If colDestinoGravado = 1 Then
                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0
                End If

                '****************************************************************
                '    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
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

            Else
                txtTipoCambio.Select()
                Throw New Exception("Debe indicar un tipo de cambio")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

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

                    'If IsNothing(GFichaUsuarios) Then
                    '    lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
                    '    PanelError.Visible = True
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    '    'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
                    '    Exit Sub
                    'Else
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
                    'End If




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

    Private Sub dgvCompra_TableControlCurrentCellActivated(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellActivated
        'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        ''  Dim ColIndex As Integer = e.Inner.ColIndex

        'Dim q = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellActivating(sender As Object, e As GridTableControlCurrentCellActivatingEventArgs) Handles dgvCompra.TableControlCurrentCellActivating
        'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        ''  Dim ColIndex As Integer = e.Inner.ColIndex

        'Dim q = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4 ' cantidad
                    Calculos()
                Case 5, 10 'Valor de compra
                    Calculos()
                Case 6
                    Calculos()
                Case 8
                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / txtTipoCambio.DecimalValue, 2)
                    dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    Calculos()

                Case 13
                    Dim colPercepcionMN As Decimal = 0
                    colPercepcionMN = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")) * txtTipoCambio.DecimalValue, 2)
                    dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", colPercepcionMN)
                    Calculos()

                Case 14
                    If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
                        dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
                    End If

                Case 1
                    Calculos()

            End Select
        End If


        '    Dim q = dgvCompra.TableModel(cc.RowIndex, cc.ColIndex).CellValue

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellChanging
        'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        ''  Dim ColIndex As Integer = e.Inner.ColIndex

        'Dim q = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 4 ' cantidad
        '            Calculos()
        '        Case 5, 10 'Valor de compra
        '            Calculos()
        '        Case 6
        '            Calculos()
        '        Case 8
        '            Dim colPercepcionME As Decimal = 0
        '            colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / txtTipoCambio.DecimalValue, 2)
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
        '            Calculos()

        '        Case 13
        '            Dim colPercepcionMN As Decimal = 0
        '            colPercepcionMN = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")) * txtTipoCambio.DecimalValue, 2)
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", colPercepcionMN)
        '            Calculos()

        '        Case 14
        '            If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
        '            End If

        '        Case 1
        '            Calculos()
        '    End Select
        'End If

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
        'If IsNothing(GFichaUsuarios) Then
        '    If TieneCuentaFinanciera() = True Then
        '        ToolStripButton1.Image = ImageListAdv1.Images(1)
        '        dgvCompra.TableDescriptor.Columns("chPago").Width = 50
        '        MessageBoxAdv.Show("Usuario iniciado!")
        '    Else

        '    End If
        'Else

        'End If
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

                MessageBox.Show("Ingrese el proveedor de la compra", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProveedor.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If txtProveedor.Text.Trim.Length > 0 Then
                If txtProveedor.ForeColor = Color.Black Then
                    MessageBox.Show("Verificar el ingreso correcto del proveedor", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProveedor.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
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

            If Not txtTipoCambio.DecimalValue > 0 Then
                lblEstado.Text = "Ingresar un tipo de cambio mayor a cero!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtTipoCambio.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
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


    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs)
        'If Not IsNothing(TotalesXcanbeceras) Then
        '    If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
        '        txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
        '        txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
        '        txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
        '        lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

        '        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
        '        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
        '        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
        '        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
        '        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

        '        dgvCompra.TableDescriptor.Columns("pume").Width = 60
        '        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
        '        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
        '        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
        '        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
        '        cboMoneda.SelectedValue = 2

        '        txtTipoCambio.DecimalValue = 0.0

        '    ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
        '        txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
        '        txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
        '        txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
        '        lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        '        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        '        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        '        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        '        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
        '        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

        '        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        '        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        '        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        '        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        '        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        '        cboMoneda.SelectedValue = 1

        '        Dim consulta = (From n In ListaTipoCambio _
        '                     Where n.fechaIgv.Year = txtFecha.Value.Year _
        '                     And n.fechaIgv.Month = txtFecha.Value.Month _
        '                     And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

        '        If Not IsNothing(consulta) Then
        '            txtTipoCambio.DecimalValue = consulta.venta
        '        Else
        '            txtTipoCambio.DecimalValue = 0
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        ''  Dim ColIndex As Integer = e.Inner.ColIndex
        'Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(RowIndex, ColIndex), GridTableCellStyleInfo)
        'Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        'Dim colindexVal As Integer = style.CellIdentity.ColIndex
        'Dim q = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlCurrentCellKeyPress
        'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        ''  Dim ColIndex As Integer = e.Inner.ColIndex

        'Dim q = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyUp
        'Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        ''  Dim ColIndex As Integer = e.Inner.ColIndex

        'Dim q = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles dgvCompra.TableControlCurrentCellShowingDropDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 24 Then

            ElseIf ColIndex = 16 Then

                If Me.dgvCompra.Table.CurrentRecord.GetValue("tipo") = "T" Then

                    'comboTable3 = Me.GetTablePuntoUbicacion2
                    'Dim cc As GridCurrentCell = e.TableControl.CurrentCell
                    'Dim cr As GridComboBoxCellRenderer = CType(cc.Renderer, GridComboBoxCellRenderer)
                    'If (Not (cr) Is Nothing) Then
                    '    'Dim obj As Object = e.TableControl.Table.CurrentRecord.GetValue("parentID")
                    '    'If (TypeOf obj Is Int32) Then
                    '    'Dim ComboList As StringCollection = New StringCollection
                    '    'ComboList.Add(obj.ToString)
                    '    'ComboList.Add("Modified")
                    '    cr.ListBoxPart.DataSource = comboTable3
                    '    cr.ListBoxPart.ValueMember = "idAlmacen"
                    '    cr.ListBoxPart.DisplayMember = "descripcionAlmacen"
                    '    'End If

                    '    'dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
                    '    'dgvCompra.ShowRowHeaders = False

                End If

                'ElseIf e.TableControl.Table.CurrentRecord.GetValue("tipo") = "A" Then
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipo") = "A" Then

                'comboTable = Me.GetTableAlmacen
                'Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(14).Appearance.AnyRecordFieldCell
                ''Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.Table.CurrentRecord.GetValue("almacen").Appearance.AnyRecordFieldCell
                'ggcStyle.CellType = "ComboBox"
                'ggcStyle.DataSource = Me.comboTable
                'ggcStyle.ValueMember = "idAlmacen"
                'ggcStyle.DisplayMember = "descripcionAlmacen"
                'ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
                'dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
                'dgvCompra.ShowRowHeaders = False

                '////////////////////////
                'comboTable = Me.GetTableAlmacen
                'Dim cc As GridCurrentCell = e.TableControl.CurrentCell
                'Dim cr As GridComboBoxCellRenderer = CType(cc.Renderer, GridComboBoxCellRenderer)
                'If (Not (cr) Is Nothing) Then
                '    'Dim obj As Object = e.TableControl.Table.CurrentRecord.GetValue("parentID")
                '    'If (TypeOf obj Is Int32) Then
                '    'Dim ComboList As StringCollection = New StringCollection
                '    'ComboList.Add(obj.ToString)
                '    'ComboList.Add("Modified")
                '    cr.ListBoxPart.DataSource = comboTable
                '    cr.ListBoxPart.ValueMember = "idAlmacen"
                '    cr.ListBoxPart.DisplayMember = "descripcionAlmacen"
                '    'End If

                'End If



            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipo") = "S" Then



            End If
        End If

        'End If
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
        'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            'ListadoProveedores.Add(c)
            txtProveedor.Text = c.nombreCompleto
            txtProveedor.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress

    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged
        Select Case cboTipoDoc.SelectedValue
            Case "05", "55" ' NUMERO DE DIGITOS : 1
                txtSerie.MaxLength = 1

            Case "50", "51", "52", "53" ' NUMERO DE DIGITOS : 3
                txtSerie.MaxLength = 3

            Case "54" ' NUMERO DE DIGITOS : 3
                txtSerie.MaxLength = 3

            Case "02", "23", "25", "34", "35", "48", "89" ' NUMERO DE DIGITOS : 4
                txtSerie.MaxLength = 4

            Case "36", "01", "03", "04", "06", "07", "08", _
                "56", "10", "22", "46" ' NUMERO DE DIGITOS : 4
                txtSerie.MaxLength = 4

            Case "11" To "19", _
                "21", "24", "26", "27", "28", "29", "30", "32", "37", _
                "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20
                txtSerie.MaxLength = 20

        End Select
    End Sub

    Private Sub cboServicio_Click(sender As Object, e As EventArgs) Handles cboServicio.Click

    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicio.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim servicioSA As New servicioSA
        Dim servicio As New servicio
        If cboServicio.SelectedIndex > -1 Then
            If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
                servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
                txtCuenta.Text = servicio.cuenta
            ElseIf ComboBoxAdv1.Text = "ACTIVO INMOVILIZADO" Then
                txtCuenta.Text = cboServicio.SelectedValue
            End If
        End If
        txtServicio.Clear()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If txtTipoCambio.DecimalValue > 0 Then
            If txtServicio.Text.Trim.Length > 0 Then
                If cboServicio.Text.Trim.Length > 0 Then
                    If txtCuenta.Text.Trim.Length > 0 Then

                        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta.Text.Trim)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
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
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "S")
                        Me.dgvCompra.Table.AddNewRecord.EndEdit()

                        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                            txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim

                        End If

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


            Else
                lblEstado.Text = "Ingrese un Detalle"
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        Else
            MessageBox.Show("Debe ingresar un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipoCambio.Select()
        End If


    End Sub

    Private Sub cboServicioPadre_SelectedValueChanged(sender As Object, e As EventArgs)


    End Sub

    'Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt3.KeyDown
    '    Me.Cursor = Cursors.WaitCursor
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        ListaMercaderias08("08", TextBoxExt3.Text.Trim)
    '        '   End If
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub



    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria2.KeyDown
    '    Dim categoriaSA As New itemSA
    '    If e.KeyCode = Keys.Down Then
    '        If Not Me.PopupControlContainer3.IsShowing() Then
    '            ' Let the popup align around the source textBox.
    '            Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
    '            Me.PopupControlContainer3.Size = New Size(238, 110)
    '            Me.PopupControlContainer3.ParentControl = Me.txtCategoria2
    '            Me.PopupControlContainer3.ShowPopup(Point.Empty)


    '            e.Handled = True
    '        End If
    '    End If
    '    '  End If
    '    ' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.PopupControlContainer3.IsShowing() Then
    '            Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        If txtCategoria2.Text.Trim.Length > 0 Then
    '            ListBox1.Items.Clear()
    '            For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, txtCategoria.Text.Trim)
    '                ListBox1.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
    '            Next
    '            ListBox1.DisplayMember = "Name"
    '            ListBox1.ValueMember = "Id"
    '            Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
    '            Me.PopupControlContainer3.Size = New Size(238, 110)
    '            Me.PopupControlContainer3.ParentControl = Me.txtCategoria2
    '            Me.PopupControlContainer3.ShowPopup(Point.Empty)
    '        End If
    '    End If
    'End Sub


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
                '   Me.TextBoxExt1.Tag = CStr(DirectCast(Me.ListBox1.SelectedItem, Categoria).Id)
                'txtCategoria.PasswordChar = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad)
                '   TextBoxExt1.Text = ListBox1.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.ListBox1.SelectedItem, Categoria).Id, "08", DirectCast(Me.ListBox1.SelectedItem, Categoria).Utilidad, DirectCast(Me.ListBox1.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.ListBox1.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            '  Me.TextBoxExt1.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
    '    Dim objInsumo As New detalleitemsSA
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim entidadSA As New entidadSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    Dim almacenSA As New almacenSA
    '    Dim itemSA As New itemSA
    '    If ListView1.SelectedItems.Count > 0 Then
    '        Dim selFila As ListViewItem = ListView1.SelectedItems(0)

    '        With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))

    '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)

    '            Dim Imtem = .idItem

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", CStr(Imtem))

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '            If .tipoExistencia = "GS" Then

    '                ' Me.dgvCompra.Table.CurrentRecord.SetValue("puntoubicacion", almacenSA.GetUbicar_PuntoUbicacion(GEstableciento.IdEstablecimiento).idAlmacen)
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
    '            End If

    '            'If .tipoExistencia = "08" Then
    '            '    Me.dgvCompra.Table.CurrentRecord.SetValue("cuentaAct", .cuenta)
    '            'End If

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", itemSA.UbicarCategoriaPorID(.idItem).idPadre)



    '            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)
    '            Me.dgvCompra.Table.AddNewRecord.EndEdit()
    '        End With
    '    End If
    'End Sub

    Private Sub tb19_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    'Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    'End Sub

    'Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
    '    Dim entidadSA As New entidadSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    Dim almacenSA As New almacenSA
    '    Dim objInsumo As New detalleitemsSA
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim catSA As New itemSA
    '    Dim cat As New item
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    If txtCategoria2.Text.Trim.Length > 0 Then
    '        If Not IsNothing(txtCategoria2.Tag) Then
    '            With FrmNuevoActivoInmovilizado
    '                .EstadoManipulacion = ENTITY_ACTIONS.INSERT
    '                .txtCategoria.Tag = txtCategoria2.Tag
    '                .txtCategoria.Text = txtCategoria2.Text
    '                ' .cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
    '                ' .cboTipoExistencia.Text = cboTipoExistencia.Text
    '                .EstadoManipulacion = ENTITY_ACTIONS.INSERT
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then
    '                    If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '                        If datos(0).Cuenta = "Grabado" Then
    '                            '  If lsvListadoItems.SelectedItems.Count > 0 Then

    '                            With objInsumo.InvocarProductoID(CInt(datos(0).ID))
    '                                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '                                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)

    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '                                If .tipoExistencia <> "GS" Then
    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
    '                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
    '                                End If
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
    '                                Me.dgvCompra.Table.AddNewRecord.EndEdit()
    '                            End With
    '                            ' End If


    '                        End If
    '                    End If
    '                End If
    '            End With
    '        Else

    '            lblEstado.Text = "Debe elegir una clasificacion"
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '        End If
    '    Else
    '        lblEstado.Text = "Debe elegir una clasificacion"
    '        Timer1.Enabled = True
    '        PanelError.Visible = True
    '        TiempoEjecutar(10)
    '    End If

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    'Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click


    '    Dim entidadSA As New entidadSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    Dim almacenSA As New almacenSA
    '    Dim objInsumo As New detalleitemsSA
    '    Dim tablaSA As New tablaDetalleSA
    '    'Dim catSA As New itemSA
    '    Dim itemSA As New itemSA
    '    Dim cat As New item
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    'If TextBoxExt1.Text.Trim.Length > 0 Then
    '    '    If Not IsNothing(TextBoxExt1.Tag) Then
    '    With FrmNuevoActivoInmovilizado
    '        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
    '        '.txtCategoria.Tag = TextBoxExt1.Tag
    '        '.txtCategoria.Text = TextBoxExt1.Text

    '        '.cboProductos.SelectedValue = cboProductos2.SelectedValue
    '        '   .CboClasificacion.SelectedValue = CboClasificacion1.SelectedValue
    '        '.cboProductos.SelectedValue = cboProductos2.SelectedValue

    '        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '                If datos(0).Cuenta = "Grabado" Then
    '                    '  If lsvListadoItems.SelectedItems.Count > 0 Then

    '                    With objInsumo.InvocarProductoID(CInt(datos(0).ID))
    '                        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '                        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)

    '                        Dim imItem = .idItem

    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", CStr(imItem))

    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '                        If .tipoExistencia <> "GS" Then
    '                            'Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
    '                            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
    '                        End If
    '                        'If .tipoExistencia = "08" Then
    '                        '    Me.dgvCompra.Table.CurrentRecord.SetValue("cuentaAct", .cuenta)
    '                        'End If
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)

    '                        '  Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", itemSA.UbicarCategoriaPorID(.idItem).idPadre)


    '                        Me.dgvCompra.Table.AddNewRecord.EndEdit()
    '                    End With
    '                    ' End If


    '                End If
    '            End If
    '        End If
    '    End With
    '    '    Else

    '    'lblEstado.Text = "Debe elegir una clasificacion"
    '    'Timer1.Enabled = True
    '    'PanelError.Visible = True
    '    'TiempoEjecutar(10)
    '    '    End If
    '    'Else
    '    'lblEstado.Text = "Debe elegir una clasificacion"
    '    'Timer1.Enabled = True
    '    'PanelError.Visible = True
    '    'TiempoEjecutar(10)
    '    'End If

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    'Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
    '    'Me.Cursor = Cursors.WaitCursor
    '    'pcClasificacion.Font = New Font("Tahoma", 8)
    '    'pcClasificacion.Size = New Size(337, 150)
    '    'Me.pcClasificacion.ParentControl = Me.CboClasificacion1
    '    'lbltipoexist.Text = "E"
    '    'Me.pcClasificacion.ShowPopup(Point.Empty)
    '    'txtNewClasificacion.Clear()
    '    'txtNewClasificacion.Select()
    '    'Me.Cursor = Cursors.Arrow
    '    Dim f As New frmNuevaClasificacion
    '    f.StartPosition = FormStartPosition.CenterParent

    '    f.ShowDialog()
    '    CMBClasificacionActivo()


    'End Sub

    'Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
    '    Dim categoriaSA As New itemSA
    '    If e.KeyCode = Keys.Down Then
    '        If Not Me.PopupControlContainer3.IsShowing() Then
    '            ' Let the popup align around the source textBox.
    '            Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
    '            Me.PopupControlContainer3.Size = New Size(238, 110)
    '            Me.PopupControlContainer3.ParentControl = Me.TextBoxExt1
    '            Me.PopupControlContainer3.ShowPopup(Point.Empty)

    '            e.Handled = True
    '        End If
    '    End If
    '    '  End If
    '    ' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.PopupControlContainer3.IsShowing() Then
    '            Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        If TextBoxExt1.Text.Trim.Length > 0 Then
    '            ListBox1.Items.Clear()
    '            For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, TextBoxExt1.Text.Trim)
    '                ListBox1.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
    '            Next
    '            ListBox1.DisplayMember = "Name"
    '            ListBox1.ValueMember = "Id"
    '            Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
    '            Me.PopupControlContainer3.Size = New Size(238, 110)
    '            Me.PopupControlContainer3.ParentControl = Me.TextBoxExt1
    '            Me.PopupControlContainer3.ShowPopup(Point.Empty)
    '        End If
    '    End If
    'End Sub


    Private Sub CboClasificacion_Click(sender As Object, e As EventArgs)

    End Sub

    Dim listaSubCategoria As New List(Of item)

    Sub Productoshijos()
        Dim categoriaSA As New itemSA
        'Dim dt As New DataTable()
        'dt.Columns.Add("idItem")
        'dt.Columns.Add("descripcion")

        listaSubCategoria = categoriaSA.GetListaMarcaPadre(Val(txtCategoria.Tag))
        Label43.Text = listaSubCategoria.Count & " items"
        'For Each i In categoriaSA.GetListaMarcaPadre(txtCategoria.Tag)
        '    Dim dr As DataRow = dt.NewRow
        '    dr(0) = i.idItem
        '    dr(1) = i.descripcion
        '    dt.Rows.Add(dr)
        'Next

        'Dim view As DataView = New DataView(dt)
        'cboProductos.DisplayMember = "descripcion"
        'cboProductos.ValueMember = "idItem"
        'cboProductos.DataSource = view
        'cboProductos.SelectedValue = 0
    End Sub
    'Sub Productoshijos2()
    '    Dim categoriaSA As New itemSA


    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idItem")
    '    dt.Columns.Add("descripcion")
    '    For Each i In categoriaSA.GetListaMarcaPadre(CboClasificacion1.SelectedValue)
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idItem
    '        dr(1) = i.descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    Dim view As DataView = New DataView(dt)
    '    cboProductos2.DisplayMember = "descripcion"
    '    cboProductos2.ValueMember = "idItem"
    '    cboProductos2.DataSource = view
    '    cboProductos2.SelectedValue = 0



    '    'cboProductos2.DisplayMember = "descripcion"
    '    'cboProductos2.ValueMember = "idItem"
    '    'cboProductos2.DataSource = categoriaSA.GetListaMarcaPadre(CboClasificacion1.SelectedValue)
    'End Sub



    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim f As New frmNuevaMarca
        f.StartPosition = FormStartPosition.CenterParent
        f.txtCodigo.Tag = txtCategoria.Tag
        f.txtCodigo.Text = txtCategoria.Tag
        f.ShowDialog()
        Productoshijos()
        'If Not IsNothing(f.Tag) Then
        '    Dim variable = CType(f.Tag, tabladetalle)
        '    variable.usuarioModificacion = "Grabado"

        'End If


    End Sub

    'Private Sub PopupControlContainer4_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    Me.PopupControlContainer4.BackColor = Color.White
    'End Sub




    'Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
    '    Dim f As New frmNuevaMarca
    '    f.StartPosition = FormStartPosition.CenterParent

    '    f.txtCodigo.Tag = CboClasificacion1.SelectedValue
    '    f.txtCodigo.Text = CboClasificacion1.SelectedValue
    '    f.ShowDialog()
    '    Productoshijos2()
    'End Sub

    Private Sub ComboBoxAdv2_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv2.Click

    End Sub

    Private Sub ComboBoxAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv2.SelectedIndexChanged
        If ComboBoxAdv2.Text = "DE CONTADO" Then
            txtFecVence.Value = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        ElseIf ComboBoxAdv2.Text = "7 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(7)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "10 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(10)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "15 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(15)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "30 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(30)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "33 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(33)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "45 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(45)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "55 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(55)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "60 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(60)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "90 DIAS" Then
            Dim fecha As DateTime = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(90)
            txtFecVence.Value = fecha

        End If
    End Sub

    Private Sub txtTipoCambio_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtTipoCambio.MouseDoubleClick
        txtTipoCambio.Enabled = True
        txtTipoCambio.Select()
    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged

        If IsNumeric(txtTipoCambio.Text) Then
            If txtTipoCambio.Text > 0 Then
                TipoCambio()
            End If
        End If

    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        Me.Cursor = Cursors.WaitCursor
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            txtBuscarProducto.Visible = False
            btnNuevoProd.Visible = False

            Label16.Text = "Clasificación"
            txtCategoria.Visible = True
            PictureBox2.Visible = True
            Label42.Visible = True
            Label43.Visible = True

            Label35.Visible = True
            txtSubCategoria.Visible = True
            PictureBox6.Visible = True

            CMBClasificacion()

        Else
            txtBuscarProducto.Visible = True
            btnNuevoProd.Visible = True

            Label16.Text = "Buscar item"
            txtCategoria.Visible = False
            PictureBox2.Visible = False
            Label42.Visible = False
            Label43.Visible = False

            Label35.Visible = False
            txtSubCategoria.Visible = False
            PictureBox6.Visible = False

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToggleButton21_Click(sender As Object, e As EventArgs) Handles ToggleButton21.Click

    End Sub

    'Private Sub ToggleButton22_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton22.ButtonStateChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    If ToggleButton22.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
    '        TextBoxExt3.Visible = False
    '        PictureBox5.Visible = False

    '        Label31.Text = "Clasificación"
    '        CboClasificacion1.Visible = True
    '        PictureBox4.Visible = True
    '        '------------------------------------

    '        Label39.Visible = True
    '        cboProductos2.Visible = True
    '        PictureBox7.Visible = True

    '        CMBClasificacionActivo()
    '    Else
    '        TextBoxExt3.Visible = True
    '        PictureBox5.Visible = True

    '        Label31.Text = "Buscar activo"
    '        CboClasificacion1.Visible = False
    '        PictureBox4.Visible = False
    '        '------------------------------------

    '        Label39.Visible = False
    '        cboProductos2.Visible = False
    '        PictureBox7.Visible = False

    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub CboClasificacion1_KeyDown(sender As Object, e As KeyEventArgs)
        'Dim value As Object = CboClasificacion1.SelectedValue

        'If (TypeOf value Is String) Then
        '    ' Lo pasamos a la función únicamente si es
        '    ' del tipo Integer.
        '    '
        '    CboClasificacion1.Tag = CboClasificacion1.SelectedValue
        '    Productoshijos2()
        'End If
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria
                            Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            lsvCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If

        '     End If

    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtSubCategoria.Clear()
                Label43.Text = "0 items"
                Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCategoria.SelectedIndexChanged

    End Sub

    Private Sub pcLikeCategoria_Popup(sender As Object, e As EventArgs) Handles pcLikeCategoria.Popup

    End Sub

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvSubCategoria.SelectedItems.Count > 0 Then
                txtSubCategoria.Text = lsvSubCategoria.Text
                txtSubCategoria.Tag = lsvSubCategoria.SelectedValue

                ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtSubCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubCategoria.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaSubCategoria
                            Where n.descripcion.StartsWith(txtSubCategoria.Text)).ToList

            lsvSubCategoria.DataSource = consulta
            lsvSubCategoria.DisplayMember = "descripcion"
            lsvSubCategoria.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            lsvSubCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcSubCategoria.IsShowing() Then
                Me.pcSubCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub



    'Private Sub pcClasificacion_CloseUp(sender As Object, e As PopupClosedEventArgs)
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        If Not txtNewClasificacion.Text.Trim.Length > 0 Then
    '            lblEstado.Text = "Ingrese el nombre de la clasificación"
    '            pcClasificacion.Font = New Font("Tahoma", 8)
    '            pcClasificacion.Size = New Size(337, 150)
    '            Me.pcClasificacion.ParentControl = Me.txtCategoria
    '            Me.pcClasificacion.ShowPopup(Point.Empty)
    '            txtNewClasificacion.Select()
    '            Exit Sub
    '        End If

    '        If btmGrabarClasificacion.Tag = "G" Then
    '            GrabarCategoria()
    '            btmGrabarClasificacion.Tag = "N"
    '        Else
    '            pcClasificacion.Font = New Font("Tahoma", 8)
    '            pcClasificacion.Size = New Size(337, 150)
    '            Me.pcClasificacion.ParentControl = Me.txtCategoria
    '            Me.pcClasificacion.ShowPopup(Point.Empty)
    '        End If

    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.txtCategoria.Focus()
    '    End If
    'End Sub

    Private Sub txtCategoria_TextChanged_1(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged

    End Sub



    Private Sub txtSubCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtSubCategoria.TextChanged

    End Sub

    Private Sub lsvSubCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSubCategoria.SelectedIndexChanged

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click

        If txtActivo.Text.Trim.Length > 0 Then




            Dim objInsumo As New detalleitemsSA
            Dim tablaSA As New tablaDetalleSA
            Dim entidadSA As New entidadSA
            Dim cajaSA As New EstadosFinancierosSA
            Dim almacenSA As New almacenSA
            Dim itemSA As New itemSA
            'If ListView1.SelectedItems.Count > 0 Then
            '    Dim selFila As ListViewItem = ListView1.SelectedItems(0)

            '    With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta2.Text.Trim)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtActivo.Text.Trim)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "08")

            'Dim Imtem = .idItem

            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")

            ' Me.dgvCompra.Table.CurrentRecord.SetValue("cuentaAct", "338")

            Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

            'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second))
            Me.dgvCompra.Table.AddNewRecord.EndEdit()

            '    End With
            'End If
        Else
            lblEstado.Text = "Ingrese un Detalle"
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

        'txtProveedor.ForeColor = Color.Black
        'txtProveedor.Tag = Nothing
    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now.Date
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = 0
            .nudTipoCambio.Value = 0
            .ShowDialog()
            LoadTipoCambio()
        End With
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

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
                dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
                '   cboMoneda.SelectedValue = 2

                If dgvCompra.Table.Records.Count > 0 Then

                Else
                    'txtTipoCambio.DecimalValue = 0.0
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
                dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                '    cboMoneda.SelectedValue = 1

                Dim consulta = (From n In ListaTipoCambio
                                Where n.fechaIgv.Year = CInt(cboAnio.Text) _
                             And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                             And n.fechaIgv.Day = txtDia.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    'txtTipoCambio.DecimalValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged
        Select Case cboTipoDoc.SelectedValue
            Case "05", "55" ' NUMERO DE DIGITOS : 1
                txtNumero.MaxLength = 1

            Case "50", "51", "52", "53" ' NUMERO DE DIGITOS : 6
                txtNumero.MaxLength = 6

            Case "54" ' NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

            Case "02", "23", "25", "34", "35", "48", "89" ' NUMERO DE DIGITOS : 7
                txtNumero.MaxLength = 7

            Case "36", "01", "03", "04", "06", "07", "08" ' NUMERO DE DIGITOS : 8
                txtNumero.MaxLength = 8

            Case "56" ' NUMERO DE DIGITOS : 11
                txtNumero.MaxLength = 11

            Case "10", "22", "46" ' NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

            Case "11" ' 15 dig
                txtNumero.MaxLength = 15

            Case "12" To "19", _
                "21", "24", "26", "27", "28", "29", "30", "32", "37", _
                "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

        End Select
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            txtSerie.Clear()
            txtNumero.Clear()
            txtSerieGuia.Clear()
            txtNumeroGuia.Clear()
        End If
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub

    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedIndexChanged
        Dim n As New ListViewItem
        lsvServicios.Items.Clear()
        If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
            GetServiviosPadre()

        ElseIf ComboBoxAdv1.Text = "ACTIVO INMOVILIZADO" Then

            n = New ListViewItem
            n.Text = "30"
            n.SubItems.Add("INVERSIONES MOVILIZARIAS")
            lsvServicios.Items.Add(n)

            n = New ListViewItem
            n.Text = "31"
            n.SubItems.Add("INVERSIONES INMOBILIARIAS")
            lsvServicios.Items.Add(n)

            n = New ListViewItem
            n.Text = "32"
            n.SubItems.Add("ACTIVOS ADQUIRIDOS EN ARRENDAMIENTO FINANCIERO")
            lsvServicios.Items.Add(n)

            n = New ListViewItem
            n.Text = "33"
            n.SubItems.Add("INMUEBLES MAQUINARIA Y EQUIPO")
            lsvServicios.Items.Add(n)

            n = New ListViewItem
            n.Text = "34"
            n.SubItems.Add("INTANGIBLES")
            lsvServicios.Items.Add(n)

            n = New ListViewItem
            n.Text = "35"
            n.SubItems.Add("ACTIVOS BIOLOGICOS")
            lsvServicios.Items.Add(n)

            n = New ListViewItem
            n.Text = "38"
            n.SubItems.Add("OTROS ACTIVOS")
            lsvServicios.Items.Add(n)

            txtServicio.Clear()
            txtCuenta.Clear()
            cboServicio.SelectedValue = -1

        Else
            ComboBoxAdv1.Items.Clear()
            ComboBoxAdv1.Items.Add("SERVICIOS & GASTOS")
            ComboBoxAdv1.Items.Add("ACTIVO INMOVILIZADO")
        End If
    End Sub

    Private Sub cboServicioPadre_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lsvServicios_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lsvServicios.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtCuenta.Text = ""

        If lsvServicios.SelectedItems.Count > 0 Then

            'If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
            '    GetServiviosHijo(lsvServicios.SelectedItems(0).SubItems(0).Text)
            'Else
            '    GetServiviosHijoActivos(lsvServicios.SelectedItems(0).SubItems(0).Text)
            'End If

            If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
                GetServiviosHijo(lsvServicios.SelectedItems(0).SubItems(2).Text)
            Else
                GetServiviosHijoActivos(lsvServicios.SelectedItems(0).SubItems(2).Text)
            End If
            txtServicio.Clear()
        Else
            lblEstado.Text = "Seleccione un Servicio Padre"
        End If
        'SDSSD()
        If lsvServicios.SelectedItems.Count > 0 Then
            If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
                Dim servicioSA As New servicioSA
                Dim servicio As New servicio
                If cboServicio.SelectedIndex > -1 Then
                    servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
                    txtCuenta.Text = servicio.cuenta
                End If
            ElseIf (ComboBoxAdv1.Text = "ACTIVO INMOVILIZADO") Then
                If cboServicio.SelectedIndex > -1 Then
                    txtCuenta.Text = cboServicio.SelectedValue
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

        'pnLsitaServicio.Visible = True

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
        'pnLsitaServicio.Visible = False
    End Sub

    Private Sub txtCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuenta.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCuenta.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarCuentaHijo(txtCuenta.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
        f.CaptionLabels(0).Text = "Proveedor"
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

    Private Sub txtCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoBarra.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtCodigoBarra.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese un Codigo para Buscar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Arrow
                Exit Sub
            End If
            ProductoXcodigoBarra(txtCodigoBarra.Text)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
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
            'If (chIdentificacion.Checked = True) Then
            '    If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
            '        lblEstado.Text = "Ingresar el nombre de comprador"
            '        Timer1.Enabled = True
            '        PanelError.Visible = True
            '        TiempoEjecutar(10)

            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    Else
            '        lblEstado.Text = "Done comprador"
            '    End If
            'Else
            'If txtRuc.Text.Trim.Length > 0 Then
            '    If txtRuc.ForeColor = Color.Black Then
            '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        txtCliente.Select()
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If

            'If txtRuc.Text.Trim.Length > 0 Then
            '    If txtRuc.ForeColor = Color.Black Then
            '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        txtRuc.Select()
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If
            'End If


            With frmCajasXusuarioCompras
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtNumero.Text
                .txtCliente.Text = txtProveedor.Text
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_COMPRA.COMPRA_PAGADA
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

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
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
            'If (chIdentificacion.Checked = True) Then
            '    If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
            '        lblEstado.Text = "Ingresar el nombre de comprador"
            '        Timer1.Enabled = True
            '        PanelError.Visible = True
            '        TiempoEjecutar(10)

            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    Else
            '        lblEstado.Text = "Done comprador"
            '    End If
            'Else
            'If txtRuc.Text.Trim.Length > 0 Then
            '    If txtRuc.ForeColor = Color.Black Then
            '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        txtCliente.Select()
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If

            'If txtRuc.Text.Trim.Length > 0 Then
            '    If txtRuc.ForeColor = Color.Black Then
            '        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        txtRuc.Select()
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If
            'End If

            With frmCajasXusuarioCompras
                .DigitalGauge2.Value = DigitalGauge2.Value
                .txtFecha.Value = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .txtTipoDoc.Text = cboTipoDoc.Text
                .txtSerie.Text = txtSerie.Text
                .txtNumero.Text = txtNumero.Text
                .txtCliente.Text = txtProveedor.Text
                .txtRuc.Text = txtRuc.Text
                .tipoVenta = TIPO_COMPRA.COMPRA_PAGADA
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


    Private Sub frmComprasContado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.F7 Then


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

                If Not txtSerie.Text.Length > 0 Then
                    MessageBox.Show("Verificar el ingreso de la serie", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtRuc.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtNumero.Text.Length > 0 Then
                    MessageBox.Show("Verificar el ingreso del numero", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtRuc.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                With frmCajasXusuarioCompras
                    .DigitalGauge2.Value = DigitalGauge2.Value
                    .txtFecha.Value = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .txtTipoDoc.Text = TextBoxExt2.Text
                    .txtSerie.Text = txtSerie.Text
                    .txtNumero.Text = txtSerie.Text
                    .txtCliente.Text = txtProveedor.Text
                    .txtCliente.Tag = txtProveedor.Tag
                    .txtRuc.Text = txtRuc.Text
                    .tipoVenta = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
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

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub cboMesCompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedIndexChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                Dim consulta = (From n In ListaTipoCambio
                                Where n.fechaIgv.Year = cboAnio.Text _
                           And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                           And n.fechaIgv.Day = txtDia.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    'txtTipoCambio.DecimalValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedIndexChanged

    End Sub

    Private Sub txtDia_ValueChanged(sender As Object, e As EventArgs) Handles txtDia.ValueChanged
        If cboMesCompra.Text.Trim.Length > 0 Then
            txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                Dim consulta = (From n In ListaTipoCambio
                                Where n.fechaIgv.Year = CInt(cboAnio.Text) _
                           And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                           And n.fechaIgv.Day = txtDia.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.DecimalValue = consulta.venta
                Else
                    'txtTipoCambio.DecimalValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            txtDia_ValueChanged(sender, e)
            lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
        End If
    End Sub
End Class