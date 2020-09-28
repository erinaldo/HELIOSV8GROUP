Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class FormCompras
    Implements IServicio, IExistencias


#Region "Attributes"
    Public fecha As DateTime
    Dim Alert As Alert
    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property listaProveedores As List(Of entidad)
    Public Property ListaAlmacenes As List(Of almacen)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))

    Friend Delegate Sub SetDataSourceDelegateInicio(ByVal Comprobantes As List(Of tabladetalle),
                          listaAnios As List(Of empresaPeriodo))
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    'Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of tipoCambio)
    Private sToolTip As SuperToolTip
    Public Property listaMeses As New List(Of MesesAnio)
    Private conteoListaServicio As Integer = 0
    Private ServicioHijo As New List(Of servicio)
    Private Property LoteDecompraexistente = False
    Public Property listaAnios As List(Of empresaPeriodo)
    Private ventanaSel As FormMaestroLogistica
    Public Property CodigoComprobante As Integer

#End Region

#Region "Constructors"
    Public Sub New(ventana As FormMaestroLogistica)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ventanaSel = ventana
        GridCFG(dgvCompra)
        ConfiguracionInicio()
        GetTableGrid()
        threadCombos()
        threadProveedores()

        If ClipBoardDocumento IsNot Nothing Then
            If Not IsNothing(ClipBoardDocumento.documentocompra) Then
                btnPegadoEspecial.Visible = True
            End If
        End If
        Me.KeyPreview = True
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
        ConfiguracionInicio()
        GetTableGrid()
        threadCombos()
        threadProveedores()

        If ClipBoardDocumento IsNot Nothing Then
            If Not IsNothing(ClipBoardDocumento.documentocompra) Then
                btnPegadoEspecial.Visible = True
            End If
        End If
        Me.KeyPreview = True
    End Sub

    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CodigoComprobante = IdDocumento
        GetTableGrid()
        ConfiguracionInicio()
        threadCombos()
        threadProveedores()

        Me.KeyPreview = True
    End Sub
#End Region

#Region "Thread Combos"
    Dim thread2 As System.Threading.Thread
    Private Sub threadCombos()
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        thread2 = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetSource()))
        thread2.Start()
    End Sub

    Private Sub GetSource()
        Dim servicioSA As New servicioSA
        Dim empresaPeriodoSA As New empresaPeriodoSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        ListaComprobantes = New List(Of tabladetalle)
        ListaComprobantes = tablaDetalleSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In ListaComprobantes
                            Where Not list.Contains(n.codigoDetalle)).ToList


        ListaComprobantes = Comprobantes
        '-------------------------------------------------------------------
        ListaAlmacenes = almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "AV")
        '------------------------------------------------------------------------------------------
        listaAnios = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

        ServicioHijo.Clear()
        ServicioHijo = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = 4053})
        setCombos(ListaComprobantes, listaAnios)
    End Sub

    Private Sub setCombos(ByVal Comprobantes As List(Of tabladetalle),
                          listaAnios As List(Of empresaPeriodo))

        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateInicio(AddressOf setCombos)
            Invoke(deleg, New Object() {Comprobantes, listaAnios})
        Else
            cboTipoDoc.DisplayMember = "descripcion"
            cboTipoDoc.ValueMember = "codigoDetalle"
            cboTipoDoc.DataSource = Comprobantes

            If listaAnios.Count > 0 Then
                cboAnio.DisplayMember = "periodo"
                cboAnio.ValueMember = "periodo"
                cboAnio.DataSource = listaAnios
                cboAnio.Text = AnioGeneral
            End If

            Dim listMeses = New List(Of MesesAnio)
            Dim obj As New MesesAnio
            For x = 1 To 12
                obj = New MesesAnio
                obj.Codigo = String.Format("{0:00}", CInt(x))
                obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
                listMeses.Add(obj)
            Next x

            If listMeses.Count > 0 Then
                cboMesCompra.DisplayMember = "Mes"
                cboMesCompra.ValueMember = "Codigo"
                cboMesCompra.DataSource = listMeses
                cboMesCompra.SelectedValue = MesGeneral
            End If

            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Rows.Add(1, "NACIONAL")
            dt.Rows.Add(2, "EXTRANJERA")

            cboMoneda.ValueMember = "id"
            cboMoneda.DisplayMember = "name"
            cboMoneda.DataSource = dt
            cboMoneda.SelectedIndex = 0
            LoadTipoCambio()
            ToolStrip5.Enabled = True
            lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            ProgressBar2.Visible = False
        End If
    End Sub
#End Region

#Region "Background Controls"
    Public Sub GetCombos()
        Dim servicioSA As New servicioSA
        Dim empresaPeriodoSA As New empresaPeriodoSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        ListaComprobantes = New List(Of tabladetalle)
        ListaComprobantes = tablaDetalleSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In ListaComprobantes
                            Where Not list.Contains(n.codigoDetalle)).ToList


        ListaComprobantes = Comprobantes
        '-------------------------------------------------------------------
        ListaAlmacenes = almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "AV")
        '------------------------------------------------------------------------------------------
        listaAnios = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

        ServicioHijo.Clear()
        ServicioHijo = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = 4053})
    End Sub
#End Region

#Region "Proveedores"
    Private Sub FillLSVProveedores(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub threadProveedores()
        Dim tipo = TIPO_ENTIDAD.PROVEEDOR
        Dim empresa = Gempresas.IdEmpresaRuc
        Dim establecimiento = GEstableciento.IdEstablecimiento
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa, establecimiento)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String, estable As Integer)
        Dim entidadSA As New entidadSA
        Dim lista = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaProveedores = New List(Of entidad)
            listaProveedores = lista
            If ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                UbicarDocumento(CodigoComprobante)
            End If

            ProgressBar2.Visible = False
        End If
    End Sub
#End Region

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

#Region "Métodos"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F7
                BtnCanastaCompra.PerformClick()

            Case Keys.F9
                BtnCanastaCompra.PerformClick()

            Case Keys.F10
                ToolStripButton1.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
    '    Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

    '    If keyData = Keys.Tab AndAlso txtProveedor.Focused Then
    '        '  MessageBox.Show("Tab pressed")
    '        Return True
    '    End If

    '    If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtProveedor.Focused Then
    '        '  MessageBox.Show("Shift-Tab pressed")
    '        Return True
    '    End If

    '    Return baseResult
    'End Function

    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            ComboBoxAdv2.Visible = False
        Else
            ComboBoxAdv2.Visible = True
        End If
        dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1

        'confgiurando variables generales
        txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        txtFechaGuia.Value = New DateTime(CInt(DateTime.Now.Year), CInt(DateTime.Now.Month), DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecVence.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
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
        grid.Table.DefaultRecordRowHeight = 25
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 11.4F

    End Sub

    ''' <summary>
    ''' Cargar Combos de año y mes
    ''' </summary>
    Private Sub Meses()
        If listaAnios.Count > 0 Then
            cboAnio.DisplayMember = "periodo"
            cboAnio.ValueMember = "periodo"
            cboAnio.DataSource = listaAnios
            cboAnio.Text = AnioGeneral
        End If


        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        If listaMeses.Count > 0 Then
            cboMesCompra.DisplayMember = "Mes"
            cboMesCompra.ValueMember = "Codigo"
            cboMesCompra.DataSource = listaMeses
            cboMesCompra.SelectedValue = MesGeneral
        End If

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
        dgvCompra.TableDescriptor.Columns("fechaProd").Width = 0 '100
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

    'Dim precUnit As Decimal = 0
    'Dim pmAcumnulado As Decimal = 0
    'Dim saldoCantidadAnual As Decimal = 0
    'Dim saldoImporteAnual As Decimal = 0
    'Dim ImporteSaldo As Decimal = 0
    'Dim canSaldo As Decimal = 0
    'Public Property ListaCurar As List(Of totalesAlmacen)


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

    Sub TipoCambioBaseImponible()
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


    Sub TipoCambio()
        For Each r As Record In dgvCompra.Table.Records
            Dim cantidad As Decimal = 0
            Dim VC As Decimal = 0
            Dim VCme As Decimal = 0
            Dim Igv As Decimal = 0
            Dim IgvME As Decimal = 0
            Dim totalMN As Decimal = 0
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
            r.SetValue("cantidad", cantidad.ToString("N2"))
            Select Case cboMoneda.SelectedValue
                Case 1 'MONEDA NACIONAL
                    VC = CalculoBaseImponible(CDec(r.GetValue("totalmn")), 1.18)
                    VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                    r.SetValue("totalme", Math.Round(r.GetValue("totalmn") / txtTipoCambio.DecimalValue, 2))
                Case 2 'MONEDA EXTRANJERA
                    VCme = CalculoBaseImponible(CDec(r.GetValue("totalme")), 1.18)
                    VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
                    r.SetValue("totalmn", Math.Round(r.GetValue("totalme") * txtTipoCambio.DecimalValue, 2))
            End Select


            'Select Case cboMoneda.SelectedValue
            '    Case 1 'MONEDA NACIONAL
            '        'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
            '        r.SetValue("cantidad", cantidad.ToString("N2"))

            '        VC = r.GetValue("vcmn")
            '        VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

            '    Case 2 'MONEDA EXTRANJERA

            '        ' Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
            '        r.SetValue("cantidad", cantidad.ToString("N2"))
            '        VCme = r.GetValue("vcme") ' 
            '        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

            'End Select
            'calculo Compratido por ambas monedas(Nacional y extranjera)
            If cantidad > 0 AndAlso VC > 0 Then
                Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                colPrecUnit = Math.Round(VC / cantidad, 2)
                colPrecUnitme = Math.Round(VCme / cantidad, 2)
            ElseIf cantidad = 0 AndAlso VC > 0 Then
                Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                colPrecUnit = 0
                colPrecUnitme = 0
            ElseIf cantidad = 0 Then
                Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                colPrecUnit = 0
                colPrecUnitme = 0
            Else
                colPrecUnit = 0
                colPrecUnitme = 0

                Igv = 0
                IgvME = 0
            End If

            ValidandoMontoTotalCuadre(r, VC, VCme, Igv, IgvME, valPercepMN, valPercepME)

            ''calculo Compratido por ambas monedas(Nacional y extranjera)
            'If cantidad > 0 AndAlso VC > 0 Then
            '    Igv = Math.Round(VC * (TmpIGV / 100), 2)
            '    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            '    colBI = VC + Igv + valPercepMN
            '    colBIme = VCme + IgvME + valPercepME

            '    colPrecUnit = Math.Round(VC / cantidad, 2)
            '    colPrecUnitme = Math.Round(VCme / cantidad, 2)
            'ElseIf cantidad = 0 AndAlso VC > 0 Then
            '    Igv = Math.Round(VC * (TmpIGV / 100), 2)
            '    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            '    colBI = VC + Igv + valPercepMN
            '    colBIme = VCme + IgvME + valPercepME

            '    colPrecUnit = 0
            '    colPrecUnitme = 0
            'ElseIf cantidad = 0 Then
            '    Igv = Math.Round(VC * (TmpIGV / 100), 2)
            '    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
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

            Select Case cboTipoDoc.SelectedValue
                Case "08"

                Case "03", "02"
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                    r.SetValue("vcmn", 0) 'VC.ToString("N2"))
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                    r.SetValue("vcme", 0) 'VCme.ToString("N2"))
                    ' Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                    r.SetValue("pumn", colPrecUnit.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                    r.SetValue("pume", colPrecUnitme.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                    '      r.SetValue("totalmn", VC.ToString("N2"))
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                    '     r.SetValue("totalme", VCme.ToString("N2"))
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

                            r.SetValue("vcmn", 0) 'VC.ToString("N2"))
                            r.SetValue("vcme", 0) ' VCme.ToString("N2"))
                            r.SetValue("pumn", colPrecUnit.ToString("N2"))
                            r.SetValue("pume", colPrecUnitme.ToString("N2"))
                            'r.SetValue("totalmn", VC.ToString("N2"))
                            'r.SetValue("totalme", VCme.ToString("N2"))
                            r.SetValue("igvmn", 0)
                            r.SetValue("igvme", 0)
                            r.SetValue("percepcionMN", 0)
                            r.SetValue("percepcionME", 0)

                        Case Else
                            If r.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                r.SetValue("vcmn", 0) 'VC.ToString("N2"))
                                r.SetValue("vcme", 0) 'VCme.ToString("N2"))
                                r.SetValue("pumn", colPrecUnit.ToString("N2"))
                                r.SetValue("pume", colPrecUnitme.ToString("N2"))
                                'r.SetValue("totalmn", VC.ToString("N2"))
                                'r.SetValue("totalme", VCme.ToString("N2"))
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
                                    'r.SetValue("totalmn", colBI.ToString("N2"))
                                    'r.SetValue("totalme", colBIme.ToString("N2"))
                                    r.SetValue("igvmn", Igv.ToString("N2"))
                                    r.SetValue("igvme", IgvME.ToString("N2"))

                                Else

                                    r.SetValue("vcmn", VC.ToString("N2"))
                                    r.SetValue("vcme", VCme.ToString("N2"))
                                    r.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    r.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    'r.SetValue("totalmn", colBI.ToString("N2"))
                                    'r.SetValue("totalme", colBIme.ToString("N2"))
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
                txtruc.Text = .nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR, txtruc.Text)
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                txtProveedor.Clear()
                txtruc.Clear()
                entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
                If Not IsNothing(entidad) Then
                    With entidad
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idEntidad
                        '   txtCuenta.Text = .cuentaAsiento
                        txtruc.Text = .nrodoc
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End With
                End If

            End If
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
                TxtDia.Text = .fechaDoc.Value.Day
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
                txtruc.Text = nEntidad.nrodoc
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
                    txtFechaGuia.Value = New DateTime(.fecha.Year, .fecha.Month, .fecha.Day, .fecha.Hour, .fecha.Minute, .fecha.Second)
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If



            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                Tag = .idDocumento
                If Not IsNothing(.fechaConstancia) Then
                    txtFecDetraccion.Value = .fechaConstancia
                End If
                txtNroConstancia.Text = .nroConstancia
                cboMesCompra.SelectedValue = String.Format("{0:00}", .fechaDoc.Value.Month)
                TxtDia.Text = .fechaDoc.Value.Day
                cboAnio.Text = .fechaDoc.Value.Year
                'lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                cboTipoDoc.SelectedValue = .tipoDoc
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc
                txtTipoCambio.DecimalValue = .tcDolLoc



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
                txtruc.Text = nEntidad.nrodoc
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
            For Each i In objDocCompraDet.GetUbicarDetalleCompraLote(intIdDocumento)

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

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME.GetValueOrDefault)

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

                dgvCompra.Table.CurrentRecord.SetValue("codigoLote", i.CustomRecursoCostoLote.codigoLote)
                Me.dgvCompra.Table.CurrentRecord.SetValue("lote", i.CustomRecursoCostoLote.nroLote)
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaProd", i.CustomRecursoCostoLote.fechaProduccion.GetValueOrDefault)
                If i.CustomRecursoCostoLote.fechaVcto.HasValue Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", i.CustomRecursoCostoLote.fechaVcto.GetValueOrDefault)
                End If
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            ToolStripButton3.Visible = False
            btGrabar.Enabled = False
            TotalTalesXcolumna()

            dgvCompra.TableDescriptor.Columns("codigoLote").ReadOnly = True
            dgvCompra.TableDescriptor.Columns("lote").ReadOnly = True
            dgvCompra.TableDescriptor.Columns("fechaProd").ReadOnly = True
            dgvCompra.TableDescriptor.Columns("fechaVcto").ReadOnly = True
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub UbicarDocumentoPegado()

        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Try

            txtSerieGuia.Text = ClipBoardDocumento.documentocompra.serie
            txtNumeroGuia.Text = ClipBoardDocumento.documentocompra.numeroDoc

            'CABECERA COMPROBANT
            cboMesCompra.SelectedValue = String.Format("{0:00}", ClipBoardDocumento.documentocompra.fechaDoc.Value.Month)
            TxtDia.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Day
            cboAnio.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Year
            txtFechaGuia.Value = ClipBoardDocumento.documentocompra.fechaDoc
            cboTipoDoc.SelectedValue = ClipBoardDocumento.documentocompra.tipoDoc
            txtSerie.Text = ClipBoardDocumento.documentocompra.serie
            txtNumero.Text = ClipBoardDocumento.documentocompra.numeroDoc
            cboMoneda.SelectedValue = ClipBoardDocumento.documentocompra.monedaDoc

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

            nEntidad = objEntidad.UbicarEntidadPorID(ClipBoardDocumento.documentocompra.idProveedor).First()
            txtruc.Text = nEntidad.nrodoc
            txtProveedor.Text = nEntidad.nombreCompleto

            txtTipoCambio.DecimalValue = ClipBoardDocumento.documentocompra.tcDolLoc
            txtIva.DoubleValue = ClipBoardDocumento.documentocompra.tasaIgv
            txtGlosa.Text = ClipBoardDocumento.documentocompra.glosa


            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()

            For Each i In ClipBoardDocumento.documentocompra.documentocompradetalle.ToList

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
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN.GetValueOrDefault)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME.GetValueOrDefault)

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
                        Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega.GetValueOrDefault)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
                    Case "08"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

                End Select



                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", DateTime.Now)


                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            TotalTalesXcolumna()
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtProveedor.Tag = nEntidad.idEntidad
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
            If chCambioPeriodo.Checked Then
                .periodo = txtPeriodoCambio.Text
            Else
                .periodo = lblPerido.Text
            End If
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
                        'If r.GetValue("almacen") <> idAlmacenVirtual Then ' almacen en transito
                        '    documentoguiaDetalle = New documentoguiaDetalle
                        '    If txtSerieGuia.Text.Trim.Length > 0 Then
                        '        'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                        '        objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                        '    Else
                        '        '   MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                        '        Throw New Exception("Ingrese número de serie de la guía!")
                        '        '   Exit Sub
                        '    End If
                        '    If txtNumeroGuia.Text.Trim.Length > 0 Then
                        '        objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                        '    Else
                        '        ' MessageBoxAdv.Show("Ingrese número de la guía!")
                        '        Throw New Exception("Ingrese el nùmero de la guía!")
                        '        '  Exit Sub
                        '    End If
                        '    documentoguiaDetalle.idDocumento = 0
                        '    documentoguiaDetalle.idItem = r.GetValue("idProducto")
                        '    documentoguiaDetalle.descripcionItem = r.GetValue("item")
                        '    documentoguiaDetalle.destino = r.GetValue("gravado")
                        '    documentoguiaDetalle.unidadMedida = r.GetValue("um")
                        '    documentoguiaDetalle.cantidad = CDec(r.GetValue("cantidad"))
                        '    documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                        '    documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                        '    documentoguiaDetalle.importeMN = CDec(r.GetValue("vcmn"))
                        '    documentoguiaDetalle.importeME = CDec(r.GetValue("vcme"))
                        '    documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                        '    documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                        '    documentoguiaDetalle.fechaModificacion = DateTime.Now
                        '    ListaGuiaDetalle.Add(documentoguiaDetalle)
                        'End If
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
        If chCambioPeriodo.Checked Then
            nAsiento.periodo = txtPeriodoCambio.Text
        Else
            nAsiento.periodo = lblPerido.Text
        End If
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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

    'Function MovAsientoCosto(R As Record) As List(Of movimiento)
    '    Dim lista As New List(Of movimiento)
    '    Dim nMovimiento As New movimiento

    '    lista = New List(Of movimiento)

    '    'asiento del costo x entregar
    '    nMovimiento = New movimiento
    '    nMovimiento.cuenta = "91"
    '    nMovimiento.descripcion = r.GetValue("item")
    '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
    '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
    '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
    '    nMovimiento.fechaActualizacion = DateTime.Now
    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
    '    lista.Add(nMovimiento)

    '    nMovimiento = New movimiento
    '    nMovimiento.cuenta = "791"
    '    nMovimiento.descripcion = r.GetValue("item")
    '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
    '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
    '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
    '    nMovimiento.fechaActualizacion = DateTime.Now
    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
    '    lista.Add(nMovimiento)

    '    Return lista
    'End Function

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
                        'For Each i In MovAsientoCosto(r)
                        '    asientoTransitod.movimiento.Add(i)
                        'Next
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
        If chCambioPeriodo.Checked Then
            nAsiento.periodo = txtPeriodoCambio.Text
        Else
            nAsiento.periodo = lblPerido.Text
        End If
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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
        '  If r.GetValue("almacen") = idAlmacenVirtual Then
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
        'Else
        '    Select Case r.GetValue("tipoExistencia")
        '        Case "01"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ALM", "BONIF01.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "03"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ALM", "BONIF03.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "04"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ALM", "BONIF04.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "05"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ALM", "BONIF05.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    End Select
        '   End If

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

    Private Sub Grabar()
        Dim precios As List(Of configuracionPrecioProducto)
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
        Dim PrecioUnitarioMN As Decimal = 0.0

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        ListaAsientonTransito = New List(Of asiento)

        ndocumento = New documento
        With ndocumento
            .idDocumento = Tag
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtruc.Text
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        nDocumentoCompra = New documentocompra
        With nDocumentoCompra
            .apruebaPago = StatusAprobacionPagos.Pendiente
            .idPadre = Nothing ' IdDocumentoOrden
            .codigoLibro = "8"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .fechaVcto = txtFecVence.Value
            If chCambioPeriodo.Checked Then
                .fechaContable = txtPeriodoCambio.Text
            Else
                .fechaContable = lblPerido.Text
            End If

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

            .percepcion = TotalesXcanbeceras.PercepcionMN


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me

            .percepcionus = TotalesXcanbeceras.PercepcionME
            '****************************************************************************************************************
            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME
            .destino = TIPO_COMPRA.COMPRA
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA
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
        precios = New List(Of configuracionPrecioProducto)
        For Each r As Record In dgvCompra.Table.Records
            If ChPrecios.Checked = True Then
                If r.GetValue("menor").ToString.Trim.Length > 0 Then

                    If Decimal.Parse(r.GetValue("menor")) > 0 Then
                        precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idProducto")),
                            .idPrecio = 1,
                            .descripcion = "Precio por Menor",
                            .tipoModalidad = r.GetValue("tipoExistencia"),
                            .precioMN = Decimal.Parse(r.GetValue("menor")),
                            .precioME = 0
                            })
                    End If
                End If
                If r.GetValue("mayor").ToString.Trim.Length > 0 Then
                    If Decimal.Parse(r.GetValue("mayor")) > 0 Then
                        precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idProducto")),
                            .idPrecio = 2,
                            .descripcion = "Precio por Mayor",
                            .tipoModalidad = r.GetValue("tipoExistencia"),
                            .precioMN = Decimal.Parse(r.GetValue("mayor")),
                            .precioME = 0
                            })
                    End If
                End If

                If r.GetValue("gmayor").ToString.Trim.Length > 0 Then
                    If Decimal.Parse(r.GetValue("gmayor")) > 0 Then
                        precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idProducto")),
                            .idPrecio = 3,
                            .descripcion = "Precio por Gran Mayor",
                            .tipoModalidad = r.GetValue("tipoExistencia"),
                            .precioMN = Decimal.Parse(r.GetValue("gmayor")),
                            .precioME = 0
                            })
                    End If
                End If


                If precios.Count = 0 Then
                    Throw New Exception("Debe ingresar al menos un precio de venta")
                End If
            End If


            objDocumentoCompraDet = New documentocompradetalle

            If ChPrecios.Checked = True Then
                objDocumentoCompraDet.CustomPrecios = precios
            End If

            objDocumentoCompraDet.fechaEntrega = ndocumento.documentocompra.fechaDoc
            'Validando el nro de lote
            '    If TmpProduccionPorLotes = True Then
            If r.GetValue("tipoExistencia") <> TipoRecurso.SERVICIO Then
                Select Case cboAsignacion.Text
                    Case "POR LOTES"
                        ndocumento.documentocompra.AsigancionDeLotes = "POR LOTES"

                        Dim nroLotex = r.GetValue("lote").ToString

                        If nroLotex.ToString.Trim.Length > 0 Then
                            objDocumentoCompraDet.nrolote = nroLotex
                            objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                            objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = nroLotex
                            objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = Date.Now ' CDate(r.GetValue("fechaProd"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                        Else
                            objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                            objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
                            objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = Date.Now 'CDate(r.GetValue("fechaProd"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                        End If
                    Case "LOTE EXISTENTE"
                        ndocumento.documentocompra.AsigancionDeLotes = "LOTE EXISTENTE"

                        objDocumentoCompraDet.nrolote = r.GetValue("lote")
                        objDocumentoCompraDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))

                        objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                        objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                        objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
                        objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = r.GetValue("lote")
                        objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                        objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                    Case "CONTROL POR COMPROBANTE"
                        ndocumento.documentocompra.AsigancionDeLotes = "CONTROL POR COMPROBANTE"

                        Dim nroLotex = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
                        objDocumentoCompraDet.nrolote = nroLotex
                        objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                        objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                        objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
                        objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                        objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                        'objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = Nothing
                        'objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = Nothing

                End Select
            End If



            '   End If

            'If tmpConfigInicio.proyecto = "S" Then
            '    objDocumentoCompraDet.idCosto = CInt(r.GetValue("proyecto"))
            '    objDocumentoCompraDet.tipoCosto = "PY"
            'Else
            '    objDocumentoCompraDet.tipoCosto = Nothing
            'End If
            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            If r.GetValue("valBonif") = "S" Then
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                objDocumentoCompraDet.TipoOperacion = "9917"

                Select Case r.GetValue("tipoExistencia")
                    Case "GS"

                    Case "08"

                    Case Else
                        AsientoBONIF(r)
                End Select
            Else
                objDocumentoCompraDet.TipoOperacion = "02"
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Select Case r.GetValue("tipoExistencia")

                    Case "08"

                    Case "GS"

                    Case Else
                        MV_Item_Transito(r)
                End Select
            End If
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA
            Select Case r.GetValue("tipoExistencia")

                Case "08"
                    objDocumentoCompraDet.FechaDoc = txtFechaGuia.Value ' r.GetValue("fecEntrega")
                Case "GS"
                    objDocumentoCompraDet.FechaDoc = Nothing



                    'objDocumentoCompraDet.idCosto = r.GetValue("idCosto")
                    'objDocumentoCompraDet.tipoCosto = r.GetValue("TipoCosto")

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
                    objDocumentoCompraDet.unidad2 = Nothing 'r.GetValue("presentacion")  'IDPRESENTACION
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

                    objDocumentoCompraDet.fechaEntrega = txtFechaGuia.Value ' CDate(r.GetValue("fecEntrega"))

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
                'If r.GetValue("almacen") = idAlmacenVirtual Then
                objDocumentoCompraDet.situacion = statusComprobantes.Normal
                objDocumentoCompraDet.entregable = "NO"
                'Else
                '    objDocumentoCompraDet.situacion = statusComprobantes.Normal
                '    objDocumentoCompraDet.entregable = "SI"
                'End If
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
        'If consultaPagados > 0 Then
        '    AsientoItemPagado()
        'End If

        'Dim consultaNoPagados = (From n In ListaDetalle
        '                         Where n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

        'If consultaNoPagados > 0 Then
        '    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        'Else
        '    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        'End If

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        'DocCaja = ComprobanteCaja()


        'Dim comprobante = CompraSA.CompraEsvalida(ndocumento.documentocompra)
        'If comprobante = True Then
        Dim xcod As Integer = CompraSA.SaveCompraNuevoMetodo(ndocumento)
        Alert = New Alert("Compra guardada", alertType.success) With {
            .TopMost = True
        }
        Alert.Show()
        If ventanaSel IsNot Nothing Then
            ventanaSel.ThreadTransito()
        End If
        With FormCanastaCompras
            .GridItems.Table.Records.DeleteAll()
            .txtFiltrar.Clear()
        End With
        LimpiarCompra()

        '   Close()


        'If CompraSA.GetExistenComprasSuperiores(ndocumento.documentocompra) > 0 Then
        '    sdfdsf()
        'End If



        'If tmpConfigInicio IsNot Nothing Then
        '    If tmpConfigInicio.cronogramaPagos = True Then
        '        If Not ComboBoxAdv2.Text = "DE CONTADO" Then
        '            Dim fechaVal = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        '            If MessageBoxAdv.Show("¿Desea Negociar?" + vbCrLf + vbCrLf + Space(15) + fechaVal.ToString(), fechaVal.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
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


        'Close()
        'Else

        'If MessageBox.Show("El número de comprobante ya existe en la base de datos!, desea seguir?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '    Dim xcod As Integer = CompraSA.SaveCompraNuevoMetodo(ndocumento)
        '    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

        '    Else
        '        If tmpConfigInicio.cronogramaPagos = True Then
        '            If Not ComboBoxAdv2.Text = "DE CONTADO" Then
        '                If MessageBoxAdv.Show("¿Desea Negociar?" + vbCrLf + vbCrLf + Space(15) + txtFecha.Text, txtFecha.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '                    With frmNegociacionPagos
        '                        .lblIdDocumento.Text = xcod
        '                        .txtImporteCompramn.Value = TotalesXcanbeceras.TotalMN
        '                        .txtImporteComprame.Value = TotalesXcanbeceras.TotalME
        '                        .txttipocambio.Value = txtTipoCambio.DecimalValue
        '                        ' .txtMoneda.Text = IIf(cboMoneda.SelectedValue = 1, "1", "2")
        '                        If cboMoneda.SelectedValue = "1" Then
        '                            .txtMoneda.Text = "NAC"
        '                        ElseIf cboMoneda.SelectedValue = "2" Then
        '                            .txtMoneda.Text = "EXT"
        '                        End If
        '                        .txtSerie.Text = txtSerie.Text.Trim
        '                        .txtNumero.Text = txtNumero.Text
        '                        .txtCliente.Text = txtProveedor.Text
        '                        .txtCliente.Tag = CInt(txtProveedor.Tag)
        '                        .txtRuc.Text = txtRuc.Text
        '                        .StartPosition = FormStartPosition.CenterParent
        '                        .ShowDialog()
        '                    End With
        '                Else

        '                End If

        '            End If
        '        End If
        '    End If
        '    Close()
        'Else
        '    'objPleaseWait.Close()
        'End If

        'End If



        'Else
        '    With objDocotrasDatos
        '        .idDocumento = IdDocumentoOrden
        '        'Select Case txtOrden.Text
        '        '    Case "ORDEN DE COMPRA"
        '        '        .condicionPago = TIPO_SITUACION.ORDEN_COMPRA_RECEPCION
        '        '    Case "ORDEN DE SERVICIO"
        '        '        .condicionPago = TIPO_SITUACION.ORDEN_SERVICIO_RECEPCION
        '        'End Select
        '    End With
        '    Dim xcod As Integer = CompraSA.SaveCompraNuevoMetodoOrden(ndocumento, ListaTotales, objDocotrasDatos)

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
        '  lblEstado.Text = "compra registrada!"

        'Dim f As New frmModalPreciosVenta(xcod)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()


    End Sub

    Private Sub LimpiarCompra()
        txtProveedor.Clear()
        txtProveedor.Tag = String.Empty
        txtruc.Clear()
        txtGlosa.Clear()
        TxtDia.Clear()
        txtSerie.Clear()
        txtSerieGuia.Clear()
        txtNumero.Clear()
        txtNumeroGuia.Clear()
        dgvCompra.Table.Records.DeleteAll()
        txtTotalPagar.DecimalValue = 0
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        lblTotalPercepcion.DecimalValue = 0
        txtBonifica.DecimalValue = 0
        ToolStrip5.Focus()
        BtnCanastaCompra.Select()
    End Sub

    Private Sub Editar()
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
        Dim PrecioUnitarioMN As Decimal = 0.0

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        ListaAsientonTransito = New List(Of asiento)

        With ndocumento
            .idDocumento = Tag
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtruc.Text
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
            .fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .fechaVcto = txtFecVence.Value
            If chCambioPeriodo.Checked Then
                .fechaContable = txtPeriodoCambio.Text
            Else
                .fechaContable = lblPerido.Text
            End If

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
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA
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
            'objDocumentoCompraDet.fechaEntrega = ndocumento.documentocompra.fechaDoc
            If r.GetValue("tipoExistencia") <> TipoRecurso.SERVICIO Then
                objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                Dim coxLotex = r.GetValue("lote")
                If coxLotex.ToString.Trim.Length > 0 Then
                    objDocumentoCompraDet.nrolote = r.GetValue("codigoLote")
                    objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = r.GetValue("lote")
                    objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = r.GetValue("codigoLote")
                    objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
                Else
                    objDocumentoCompraDet.nrolote = 0
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                    objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
                    objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = 0
                    objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))

                End If
            End If

            'objDocumentoCompraDet.nrolote = r.GetValue("codigoLote")
            'objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
            'objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = r.GetValue("codigoLote")
            'objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = r.GetValue("fechaVcto")
            'objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = r.GetValue("fechaProd")

            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            If r.GetValue("valBonif") = "S" Then
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                objDocumentoCompraDet.TipoOperacion = "9917"

                Select Case r.GetValue("tipoExistencia")
                    Case "GS"

                    Case "08"

                    Case Else
                        AsientoBONIF(r)
                End Select
            Else
                objDocumentoCompraDet.TipoOperacion = "02"
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Select Case r.GetValue("tipoExistencia")

                    Case "08"

                    Case "GS"

                    Case Else
                        MV_Item_Transito(r)
                End Select
            End If
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA
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
                    objDocumentoCompraDet.unidad2 = Nothing 'r.GetValue("presentacion")  'IDPRESENTACION
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

                    objDocumentoCompraDet.fechaEntrega = txtFechaGuia.Value ' CDate(r.GetValue("fecEntrega"))

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
                'If r.GetValue("almacen") = idAlmacenVirtual Then
                objDocumentoCompraDet.situacion = statusComprobantes.Normal
                objDocumentoCompraDet.entregable = "NO"
                'Else
                '    objDocumentoCompraDet.situacion = statusComprobantes.Normal
                '    objDocumentoCompraDet.entregable = "SI"
                'End If
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
        'If consultaPagados > 0 Then
        '    AsientoItemPagado()
        'End If

        'Dim consultaNoPagados = (From n In ListaDetalle
        '                         Where n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

        'If consultaNoPagados > 0 Then
        '    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        'Else
        '    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        'End If

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        'DocCaja = ComprobanteCaja()


        'Dim comprobante = CompraSA.CompraEsvalida(ndocumento.documentocompra)
        'If comprobante = True Then
        CompraSA.EditarCompra(ndocumento)
        Alert = New Alert("Compra guardada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        Close()
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
        If chCambioPeriodo.Checked Then
            nAsiento.periodo = txtPeriodoCambio.Text
        Else
            nAsiento.periodo = lblPerido.Text
        End If
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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
            nAsiento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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
        '   If i.GetValue("almacen") = idAlmacenVirtual Then
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
        'Else
        '    Select Case i.GetValue("tipoExistencia")
        '        Case "01"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "03"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "04"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "05"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.1")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    End Select
        'End If

        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        '  If i.GetValue("almacen") = idAlmacenVirtual Then

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

        'Else
        '    Select Case i.GetValue("tipoExistencia")
        '        Case "01"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.2")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "03"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.2")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "04"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.2")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '        Case "05"
        '            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.2")
        '            nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    End Select
        'End If

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

                        If ChImporteEditing.Checked = False Then  'cambio
                            bs2 += CDec(r.GetValue("vcmn"))
                            bs2me += CDec(r.GetValue("vcme"))
                        ElseIf ChImporteEditing.Checked = True Then
                            bs2 += CDec(r.GetValue("totalmn"))
                            bs2me += CDec(r.GetValue("totalme"))
                        End If      'end cambio

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

                        If ChImporteEditing.Checked = False Then  'cambio
                            totalVC2 += CDec(r.GetValue("vcmn"))
                            totalVCme2 += CDec(r.GetValue("vcme"))
                        ElseIf ChImporteEditing.Checked = True Then

                            totalVC2 += CDec(r.GetValue("totalmn"))
                            totalVCme2 += CDec(r.GetValue("totalme"))

                        End If   'end cambio

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
        ListaTipoCambio = New List(Of tipoCambio)
        Dim tipocambioSA As New tipoCambioSA
        If cboAnio.Text.Trim.Length > 0 Then

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
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
            End If



        End If
    End Sub

    Public Sub Loadcontroles()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")
        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = ListaComprobantes

        '-------------------------------------------------------------------

        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(14).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = ListaAlmacenes
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompra.ShowRowHeaders = False
    End Sub

    'Sub clasificacion()
    '    Dim categoriaSA As New itemSA
    '    CboClasificacion.DisplayMember = "descripcion"
    '    CboClasificacion.ValueMember = "idItem"
    '    CboClasificacion.DataSource = categoriaSA.GetListaPadre()

    '    CboClasificacion1.DisplayMember = "descripcion"
    '    CboClasificacion1.ValueMember = "idItem"
    '    CboClasificacion1.DataSource = categoriaSA.GetListaPadre()

    'End Sub


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


    'Public Function GetTableAlmacen() As DataTable
    '    gdfgdf
    '    Dim almacenSA As New almacenSA
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idAlmacen", GetType(Integer))
    '    dt.Columns.Add("descripcionAlmacen", GetType(String))



    '    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

    '        For Each i In almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento).OrderByDescending(Function(o) o.tipo).ToList

    '            Dim dr As DataRow = dt.NewRow()
    '            dr(0) = i.idAlmacen
    '            dr(1) = i.descripcionAlmacen
    '            dt.Rows.Add(dr)
    '        Next

    '    Else
    '        For Each i In almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

    '            Dim dr As DataRow = dt.NewRow()
    '            dr(0) = i.idAlmacen
    '            dr(1) = i.descripcionAlmacen
    '            dt.Rows.Add(dr)
    '        Next
    '    End If


    '    Return dt
    'End Function

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

#Region "Events"
    'update2

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)

            'Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()

            'lsvProveedor.DataSource = con
            'lsvProveedor.DisplayMember = "nombreCompleto"
            'lsvProveedor.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            txtProveedor.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
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
                txtNumero.Focus()
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

                Select Case cboTipoDoc.SelectedValue
                    Case "05", "55" ' NUMERO DE DIGITOS : 1
                        '       txtSerie.Text = String.Format("{0:0}", Convert.ToInt32(txtSerie.Text))
                        '      txtSerieGuia.Text = txtSerie.Text

                    Case "50", "51", "52", "53" ' NUMERO DE DIGITOS : 3
                        '      txtSerie.Text = String.Format("{0:000}", Convert.ToInt32(txtSerie.Text))
                        '    txtSerieGuia.Text = txtSerie.Text

                    Case "54" ' NUMERO DE DIGITOS : 3
                        '    txtSerie.Text = String.Format("{0:000}", Convert.ToInt32(txtSerie.Text))
                        '     txtSerieGuia.Text = txtSerie.Text

                    Case "02", "23", "25", "34", "35", "48", "89" ' NUMERO DE DIGITOS : 4
                        '     txtSerie.Text = String.Format("{0:0000}", Convert.ToInt32(txtSerie.Text))
                        '     txtSerieGuia.Text = txtSerie.Text

                    Case "36", "01", "03", "04", "06", "07", "08",
                        "56", "10", "22", "46" ' NUMERO DE DIGITOS : 4
                        '    txtSerie.Text = String.Format("{0:0000}", Convert.ToInt32(txtSerie.Text))
                        '      txtSerieGuia.Text = txtSerie.Text

                    Case "11" To "19",
                        "21", "24", "26", "27", "28", "29", "30", "32", "37",
                        "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20


                End Select

                'txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'txtSerieGuia.Text = txtSerie.Text
                'End If
                txtSerieGuia.Text = txtSerie.Text
            End If

        Catch ex As Exception

            'If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

            '    If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

            '        If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

            '            If Len(txtSerie.Text) <= 2 Then

            '                txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

            '            ElseIf Len(txtSerie.Text) <= 3 Then

            '                txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

            '            ElseIf Len(txtSerie.Text) <= 4 Then

            '                txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

            '            ElseIf Len(txtSerie.Text) <= 5 Then

            '                txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

            '            End If
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

            'Else

            '    txtSerie.Select()
            '    txtSerie.Focus()
            '    txtSerie.Clear()
            '    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)
            'End If

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
                'txtruc.Select()
                'Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
                'f.CaptionLabels(0).Text = "Proveedor"
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
                'If Not IsNothing(f.Tag) Then
                '    Dim c = DirectCast(f.Tag, entidad)
                '    'Dim c = CType(f.Tag, entidad)
                '    txtProveedor.Text = c.nombreCompleto
                '    txtProveedor.Tag = c.idEntidad
                '    txtruc.Text = c.nrodoc
                '    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'End If
                txtProveedor.Select()
                txtProveedor.Focus()
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
        txtNumeroGuia.Text = txtNumero.Text
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

    'Private Sub pcClasificacion_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    Me.pcClasificacion.BackColor = Color.White
    'End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()
        'If TmpProduccionPorLotes = True Then
        AddColumnLotes()
        'End If
        If tmpConfigInicio IsNot Nothing Then
            If tmpConfigInicio.proyecto = "S" Then
                '    AddColumnProyecto()
            End If
        End If

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

        dt.Columns.Add("codigoLote")

        'costeo gasto  en el caso de servicios
        dt.Columns.Add("idCosto", GetType(Integer))
        dt.Columns.Add("TipoCosto", GetType(String))
        dt.Columns.Add("menor")
        dt.Columns.Add("mayor")
        dt.Columns.Add("gmayor")

        ' dt.Columns.Add("cuentaAct", GetType(String))
        dgvCompra.DataSource = dt

        'Dim dtLista As New DataTable()

        'dtLista.Columns.Add("codigo", GetType(String))
        'dtLista.Columns.Add("gravado", GetType(String))
        'dtLista.Columns.Add("idProducto", GetType(Integer))
        'dtLista.Columns.Add("item", GetType(String))
        'dtLista.Columns.Add("um", GetType(String))
        'dtLista.Columns.Add("cantidad", GetType(Decimal))
        'dtLista.Columns.Add("vcmn", GetType(Decimal))
        'dtLista.Columns.Add("totalmn", GetType(Decimal))
        'dtLista.Columns.Add("vcme", GetType(Decimal))
        'dtLista.Columns.Add("totalme", GetType(Decimal))
        'dtLista.Columns.Add("igvmn", GetType(Decimal))
        'dtLista.Columns.Add("igvme", GetType(Decimal))

        'dgvListaServicio.DataSource = dtLista

        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 50


    End Sub

    Sub GetTableGridLote(item As List(Of documentocompradetalle))
        Dim dt As New DataTable()
        AddColumnLotes()
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
        dt.Columns.Add("codigoLote")
        dgvCompra.DataSource = dt
        dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
        dgvCompra.TableDescriptor.Columns("almacen").ReadOnly = True
        dgvCompra.TableDescriptor.Columns("fechaProd").ReadOnly = True
        dgvCompra.TableDescriptor.Columns("fechaVcto").ReadOnly = True
        dgvCompra.TableDescriptor.Columns("lote").ReadOnly = True
        AgregarItemCompra(item)
    End Sub

    Private Sub AgregarItemCompra(Lista As List(Of documentocompradetalle))
        Dim loteSA As New recursoCostoLoteSA
        For Each item In Lista
            Dim lote = loteSA.GetLoteByID(item.codigoLote)

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", item.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", item.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", item.descripcionItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", item.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", item.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", item.almacenRef)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", DateTime.Now)
            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("lote", lote.nroLote)
            If lote.fechaProduccion.HasValue Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaProd", lote.fechaProduccion)
            End If

            If lote.fechaVcto.HasValue Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", lote.fechaVcto)
            End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", item.codigoLote)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        ToolStripButton3.Enabled = True
        cboAsignacion.Items.Clear()
        cboAsignacion.Items.Add("LOTE EXISTENTE")
        cboAsignacion.Text = "LOTE EXISTENTE"
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
            '   Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            '   Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
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

        Dim colTolPercMN As Decimal = 0
        Dim colTolPercME As Decimal = 0

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
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N3"))
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

                    If CDec(dgvCompra.Table.CurrentRecord.GetValue("totalmn")) > 0 Then
                        'colPrecUnit = Math.Round(dgvCompra.Table.CurrentRecord.GetValue("totalmn") / cantidad, 2)
                        colPrecUnit = Math.Round(colBI / cantidad, 2)
                    Else
                        colPrecUnit = 0
                    End If

                    If CDec(dgvCompra.Table.CurrentRecord.GetValue("totalme")) > 0 Then
                        'colPrecUnitme = Math.Round(dgvCompra.Table.CurrentRecord.GetValue("totalme") / cantidad, 2)
                        colPrecUnitme = Math.Round(colBIme / cantidad, 2)
                    Else
                        colPrecUnitme = 0
                    End If


                    'colPrecUnit = Math.Round(VC / cantidad, 2)
                    'colPrecUnitme = Math.Round(VCme / cantidad, 2)
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

                colTolPercMN = VC + valPercepMN
                colTolPercME = VCme + valPercepME

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

    Sub CalculosByMontoTotal()
        Dim r As Record = dgvCompra.Table.CurrentRecord
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

        Dim colTolPercMN As Decimal = 0
        Dim colTolPercME As Decimal = 0

        Dim valorIvaConCero = TmpIGV / 100
        Dim valorIvaMasUno = (TmpIGV / 100) + 1

        Try
            If txtTipoCambio.DecimalValue > 0 Then
                colDestinoGravado = r.GetValue("gravado")

                If colDestinoGravado = 1 Then
                    valPercepMN = r.GetValue("percepcionMN")
                    valPercepME = r.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0
                End If


                cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N3"))
                Select Case cboMoneda.SelectedValue
                    Case 1 'MONEDA NACIONAL
                        VC = CalculoBaseImponible(CDec(r.GetValue("totalmn") - valPercepMN), valorIvaMasUno)
                        VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                        r.SetValue("totalme", Math.Round((r.GetValue("totalmn")) / txtTipoCambio.DecimalValue, 2))
                    Case 2 'MONEDA EXTRANJERA
                        VCme = CalculoBaseImponible(CDec(r.GetValue("totalme") - valPercepME), valorIvaMasUno)
                        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
                        r.SetValue("totalmn", Math.Round((r.GetValue("totalme")) * txtTipoCambio.DecimalValue, 2))
                End Select

                'calculo Compratido por ambas monedas(Nacional y extranjera)
                If cantidad > 0 AndAlso VC > 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, valorIvaConCero)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, valorIvaConCero)), 2)

                    colPrecUnit = Math.Round(r.GetValue("totalmn") / cantidad, 2)
                    colPrecUnitme = Math.Round(r.GetValue("totalme") / cantidad, 2)
                ElseIf cantidad = 0 AndAlso VC > 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, valorIvaConCero)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, valorIvaConCero)), 2)

                    colPrecUnit = 0
                    colPrecUnitme = 0
                ElseIf cantidad = 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, valorIvaConCero)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, valorIvaConCero)), 2)

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

                ValidandoMontoTotalCuadre(r, VC, VCme, Igv, IgvME, valPercepMN, valPercepME)

                Select Case cboTipoDoc.SelectedValue
                    Case "08"'NOTA DE DEBITO

                    Case "03", "02" 'bolerta de venta, RECIBO POR HONORARIOS
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) 'VC.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) 'VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)



                    Case Else
                        'If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES

                        Select Case colDestinoGravado
                            Case "2", "3", "4"

                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) ' VC.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) ' VCme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)

                            Case Else
                                If Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) ' VC.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) 'VCme.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
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
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                                    Else

                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
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

    Sub CalculosByPrecioUnitario()
        Dim r As Record = dgvCompra.Table.CurrentRecord
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
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
        Try
            If txtTipoCambio.DecimalValue > 0 Then
                colDestinoGravado = r.GetValue("gravado")

                If colDestinoGravado = 1 Then
                    valPercepMN = r.GetValue("percepcionMN")
                    valPercepME = r.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0
                End If

                cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                'calculo Compratido por ambas monedas(Nacional y extranjera)
                If cantidad > 0 AndAlso colPrecUnit > 0 Then

                    totalMN = Math.Round(colPrecUnit * cantidad, 2)
                    'totalME = Math.Round((colPrecUnit * cantidad) / txtTipoCambio.DecimalValue, 2)
                    r.SetValue("totalmn", totalMN)
                    r.SetValue("pume", Math.Round(colPrecUnit / txtTipoCambio.Text, 2))
                    colPrecUnitme = Math.Round(colPrecUnit / txtTipoCambio.Text, 2)
                ElseIf cantidad = 0 AndAlso colPrecUnit > 0 Then

                    totalMN = 0
                    totalME = 0
                    r.SetValue("totalmn", totalMN)
                    r.SetValue("pume", 0)
                    colPrecUnitme = 0
                ElseIf cantidad = 0 Then

                    totalMN = 0
                    totalME = 0
                    r.SetValue("totalmn", totalMN)
                    r.SetValue("pume", 0)
                    colPrecUnitme = 0
                Else
                    totalMN = 0
                    totalME = 0
                    r.SetValue("totalmn", totalMN)
                    r.SetValue("pume", 0)
                    colPrecUnitme = 0

                End If

                Select Case cboMoneda.SelectedValue
                    Case 1 'MONEDA NACIONAL
                        VC = CalculoBaseImponible(CDec(r.GetValue("totalmn")), 1.18)
                        VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                        r.SetValue("totalme", Math.Round(r.GetValue("totalmn") / txtTipoCambio.DecimalValue, 2))
                    Case 2 'MONEDA EXTRANJERA
                        VCme = CalculoBaseImponible(CDec(r.GetValue("totalme")), 1.18)
                        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
                        r.SetValue("totalmn", Math.Round(r.GetValue("totalme") * txtTipoCambio.DecimalValue, 2))
                End Select

                If cantidad > 0 AndAlso VC > 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)


                ElseIf cantidad = 0 AndAlso VC > 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)


                ElseIf cantidad = 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                Else

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0
                End If


                ValidandoMontoTotalCuadre(r, VC, VCme, Igv, IgvME, valPercepMN, valPercepME)

                Select Case cboTipoDoc.SelectedValue
                    Case "08"'NOTA DE DEBITO

                    Case "03", "02" 'bolerta de venta, RECIBO POR HONORARIOS
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) 'VC.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) 'VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)



                    Case Else
                        'If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES

                        Select Case colDestinoGravado
                            Case "2", "3", "4"

                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) ' VC.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) ' VCme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)

                            Case Else
                                If Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) ' VC.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) 'VCme.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
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
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                                    Else

                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
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

    Sub CalculosByPrecioUnitarioME()
        Dim r As Record = dgvCompra.Table.CurrentRecord
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
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
        Try
            If txtTipoCambio.DecimalValue > 0 Then
                colDestinoGravado = r.GetValue("gravado")

                If colDestinoGravado = 1 Then
                    valPercepMN = r.GetValue("percepcionMN")
                    valPercepME = r.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0
                End If

                cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                'calculo Compratido por ambas monedas(Nacional y extranjera)
                If cantidad > 0 AndAlso colPrecUnitme > 0 Then

                    'totalMN = Math.Round(colPrecUnit * cantidad, 2)
                    totalME = Math.Round((colPrecUnitme * cantidad), 2)
                    r.SetValue("totalme", totalME)
                    r.SetValue("pumn", Math.Round(colPrecUnitme * txtTipoCambio.Text, 2))
                    colPrecUnit = Math.Round(colPrecUnitme * txtTipoCambio.Text, 2)
                ElseIf cantidad = 0 AndAlso colPrecUnitme > 0 Then

                    totalMN = 0
                    totalME = 0
                    colPrecUnit = 0
                    r.SetValue("totalme", totalME)
                    r.SetValue("pumn", 0)
                ElseIf cantidad = 0 Then

                    totalMN = 0
                    totalME = 0
                    r.SetValue("totalme", totalME)
                    r.SetValue("pumn", 0)
                Else
                    totalMN = 0
                    totalME = 0
                    colPrecUnit = 0
                    r.SetValue("totalme", totalME)
                    r.SetValue("pumn", 0)

                End If

                Select Case cboMoneda.SelectedValue
                    Case 1 'MONEDA NACIONAL
                        VC = CalculoBaseImponible(CDec(r.GetValue("totalmn")), 1.18)
                        VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                        r.SetValue("totalme", Math.Round(r.GetValue("totalmn") / txtTipoCambio.DecimalValue, 2))
                    Case 2 'MONEDA EXTRANJERA
                        VCme = CalculoBaseImponible(CDec(r.GetValue("totalme")), 1.18)
                        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
                        r.SetValue("totalmn", Math.Round(r.GetValue("totalme") * txtTipoCambio.DecimalValue, 2))
                End Select

                If cantidad > 0 AndAlso VC > 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)


                ElseIf cantidad = 0 AndAlso VC > 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)


                ElseIf cantidad = 0 Then
                    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                Else

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0
                End If


                ValidandoMontoTotalCuadre(r, VC, VCme, Igv, IgvME, valPercepMN, valPercepME)

                Select Case cboTipoDoc.SelectedValue
                    Case "08"'NOTA DE DEBITO

                    Case "03", "02" 'bolerta de venta, RECIBO POR HONORARIOS
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) 'VC.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) 'VCme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)



                    Case Else
                        'If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES

                        Select Case colDestinoGravado
                            Case "2", "3", "4"

                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) ' VC.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) ' VCme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)

                            Case Else
                                If Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0) ' VC.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0) 'VCme.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
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
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                                    Else

                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
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

    Private Sub ValidandoMontoTotalCuadre(r As Record, ByRef VC As Decimal, ByRef VCme As Decimal, Igv As Decimal, IgvME As Decimal, Per As Decimal, PerME As Decimal)
        Select Case cboMoneda.SelectedValue
            Case 1 'cuando el moneda nacional
                Dim ColTotalRecord As Decimal = CalculoTotal(VC, Igv)
                ColTotalRecord = Math.Round(ColTotalRecord, 2)
                If ColTotalRecord > CDec(r.GetValue("totalmn") - Per) Then
                    Dim diferenciaMayor = Math.Round(ColTotalRecord - CDec(r.GetValue("totalmn")), 2)
                    'se debe restar la diferencia a la base imponible
                    VC = VC - diferenciaMayor
                End If

                If ColTotalRecord < CDec(r.GetValue("totalmn") - Per) Then
                    Dim diferenciaMayor = Math.Round(CDec(r.GetValue("totalmn") - ColTotalRecord), 2)
                    'se debe sumar la diferencia a la base imponible
                    VC = VC + diferenciaMayor
                End If
            Case 2 'cuando el moneda extranjera
                Dim ColTotalRecord As Decimal = CalculoTotal(VCme, IgvME)
                ColTotalRecord = Math.Round(ColTotalRecord, 2)
                If ColTotalRecord > CDec(r.GetValue("totalme") - PerME) Then
                    Dim diferenciaMayor = Math.Round(ColTotalRecord - CDec(r.GetValue("totalme")), 2)
                    'se debe restar la diferencia a la base imponible
                    VCme = VCme - diferenciaMayor
                End If

                If ColTotalRecord < CDec(r.GetValue("totalme") - PerME) Then
                    Dim diferenciaMayor = Math.Round(CDec(r.GetValue("totalme") - ColTotalRecord), 2)
                    'se debe sumar la diferencia a la base imponible
                    VCme = VCme + diferenciaMayor
                End If
        End Select
    End Sub

    'Sub CalculosBonificacion()
    '    Dim cantidad As Decimal = 0
    '    Dim VC As Decimal = 0
    '    Dim VCme As Decimal = 0
    '    Dim Igv As Decimal = 0
    '    Dim IgvME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim colBI As Decimal = 0
    '    Dim colBIme As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colPrecUnitme As Decimal = 0
    '    Dim colDestinoGravado As Decimal = 0
    '    '****************************************************************
    '    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")
    '    cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
    '    VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
    '    VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
    '    If cantidad > 0 AndAlso VC > 0 Then
    '        Igv = Math.Round(VC * (TmpIGV / 100), 2)
    '        IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

    '        colBI = VC + Igv
    '        colBIme = VCme + IgvME

    '        colPrecUnit = Math.Round(VC / cantidad, 2)
    '        colPrecUnitme = Math.Round(VCme / cantidad, 2)
    '    ElseIf cantidad = 0 Then
    '        Igv = Math.Round(VC * (TmpIGV / 100), 2)
    '        IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
    '        colBI = VC + Igv
    '        colBIme = VCme + IgvME
    '        colPrecUnit = 0
    '        colPrecUnitme = 0
    '    Else
    '        colPrecUnit = 0
    '        colPrecUnitme = 0

    '        colBI = 0
    '        colBIme = 0
    '        Igv = 0
    '        IgvME = 0
    '    End If


    '    Select Case cboTipoDoc.SelectedValue
    '        Case "08"

    '        Case "03", "02"

    '        Case Else
    '            If cboMoneda.SelectedValue = 1 Then
    '                ' DATOS SOLES

    '                Select Case colDestinoGravado
    '                    Case "2", "3", "4"


    '                    Case Else
    '                        'If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then ' BOnIFICACIOn
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)

    '                        'Else
    '                        'If cantidad > 0 Then



    '                        'Else


    '                        'End If

    '                        'End If
    '                End Select

    '            ElseIf cboMoneda.SelectedValue = 2 Then

    '                Select Case colDestinoGravado
    '                    Case "4"

    '                    Case Else


    '                End Select

    '            End If
    '    End Select

    'End Sub

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
                                dgvCompra.TableModel(RowIndex, 21).CellValue = "N" ' curStatus

                                '******************************************************************
                                If ChImporteEditing.Checked Then
                                    GetManaipulacionXimporte(RowIndex)
                                Else
                                    GetManipulacionXBase(RowIndex)
                                End If


                            Else ' si es check de bonificacion esta en False: Entonces ->
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S"

                                '******************************************************************
                                If ChImporteEditing.Checked Then
                                    GetManaipulacionXimporte(RowIndex)
                                Else
                                    GetManipulacionXBase(RowIndex)
                                End If

                                '''''Dim cantidad As Decimal = 0
                                '''''Dim VC As Decimal = 0
                                '''''Dim VCme As Decimal = 0
                                '''''Dim Igv As Decimal = 0
                                '''''Dim IgvME As Decimal = 0
                                '''''Dim totalMN As Decimal = 0
                                '''''Dim colBI As Decimal = 0
                                '''''Dim colBIme As Decimal = 0
                                '''''Dim colPrecUnit As Decimal = 0
                                '''''Dim colPrecUnitme As Decimal = 0
                                '''''Dim colDestinoGravado As Integer
                                '''''Dim colBonifica As String = Nothing
                                ''''''****************************************************************


                                '''''Dim valPercepMN As Decimal = 0
                                '''''Dim valPercepME As Decimal = 0


                                '''''colDestinoGravado = Me.dgvCompra.TableModel(RowIndex, 1).CellValue

                                '''''If colDestinoGravado = 1 Then
                                '''''    valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
                                '''''    valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
                                '''''Else
                                '''''    valPercepMN = 0
                                '''''    valPercepME = 0
                                '''''End If

                                ''''''      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                                '''''cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
                                '''''Me.dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                                ''''''VC = Me.dgvCompra.TableModel(RowIndex, 5).CellValue
                                ''''''VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                                '''''Select Case cboMoneda.SelectedValue
                                '''''    Case 1 'MONEDA NACIONAL
                                '''''        VC = CalculoBaseImponible(CDec(dgvCompra.TableModel(RowIndex, 9).CellValue), 1.18)
                                '''''        VCme = Math.Round(VC / (txtTipoCambio.DecimalValue), 2)
                                '''''        Me.dgvCompra.TableModel(RowIndex, 14).CellValue =
                                '''''            Math.Round(CDec(dgvCompra.TableModel(RowIndex, 9).CellValue) / txtTipoCambio.DecimalValue, 2)
                                '''''    Case 2 'MONEDA EXTRANJERA
                                '''''        VCme = CalculoBaseImponible(CDec(dgvCompra.TableModel(RowIndex, 14).CellValue), 1.18)
                                '''''        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
                                '''''        Me.dgvCompra.TableModel(RowIndex, 9).CellValue =
                                '''''          Math.Round(CDec(dgvCompra.TableModel(RowIndex, 14).CellValue) * txtTipoCambio.DecimalValue, 2)
                                '''''End Select

                                '''''If cantidad > 0 AndAlso VC > 0 Then
                                '''''    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                                '''''    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                                '''''    colPrecUnit = Math.Round(VC / cantidad, 2)
                                '''''    colPrecUnitme = Math.Round(VCme / cantidad, 2)

                                '''''ElseIf cantidad = 0 Then

                                '''''    Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
                                '''''    IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

                                '''''    colPrecUnit = 0
                                '''''    colPrecUnitme = 0

                                '''''Else
                                '''''    colPrecUnit = 0
                                '''''    colPrecUnitme = 0

                                '''''    colBI = 0
                                '''''    colBIme = 0
                                '''''    Igv = 0
                                '''''    IgvME = 0
                                '''''End If


                                '''''Select Case cboTipoDoc.SelectedValue
                                '''''    Case "08"

                                '''''    Case "03", "02"

                                '''''        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 'VC.ToString("N2")
                                '''''        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 'VCme.ToString("N2")
                                '''''        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                '''''        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                '''''        'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                '''''        'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                '''''        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                '''''        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                                '''''        Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                '''''        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


                                '''''    Case Else
                                '''''        If cboMoneda.SelectedValue = 1 Then
                                '''''            ' DATOS SOLES

                                '''''            Select Case colDestinoGravado
                                '''''                Case "2", "3", "4"

                                '''''                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 'VC.ToString("N2")
                                '''''                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 'VCme.ToString("N2")
                                '''''                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                '''''                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                '''''                    'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                '''''                    'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                '''''                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                '''''                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0
                                '''''                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                '''''                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0

                                '''''                Case Else
                                '''''                    If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                '''''                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 ' VC.ToString("N2")
                                '''''                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 ' VCme.ToString("N2")
                                '''''                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                '''''                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                '''''                        'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                '''''                        'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                '''''                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                                '''''                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                                '''''                        Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                                '''''                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0
                                '''''                    Else
                                '''''                        If cantidad > 0 Then


                                '''''                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                '''''                            'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                                '''''                            'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                                '''''                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                '''''                        Else

                                '''''                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                '''''                            'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                '''''                            'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                '''''                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                '''''                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                '''''                        End If

                                '''''                    End If
                                '''''            End Select

                                '''''        ElseIf cboMoneda.SelectedValue = 2 Then
                                '''''            GetCalculoRowDolaresCH(RowIndex, colDestinoGravado)
                                '''''            'Select Case colDestinoGravado
                                '''''            '    Case "4"

                                '''''            '    Case Else


                                '''''            'End Select

                                '''''        End If
                                '''''End Select


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

    Private Sub GetManipulacionXBase(rowIndex As Integer)
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


        colDestinoGravado = Me.dgvCompra.TableModel(rowIndex, 1).CellValue

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.TableModel(rowIndex, 8).CellValue
            valPercepME = Me.dgvCompra.TableModel(rowIndex, 13).CellValue
        Else
            valPercepMN = 0
            valPercepME = 0
        End If

        '****************************************************************
        '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")

        cantidad = Me.dgvCompra.TableModel(rowIndex, 4).CellValue
        Me.dgvCompra.TableModel(rowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
        VC = Me.dgvCompra.TableModel(rowIndex, 5).CellValue
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

            Case "03", "02" 'exonerados

                Me.dgvCompra.TableModel(rowIndex, 5).CellValue = VC.ToString("N2")
                Me.dgvCompra.TableModel(rowIndex, 10).CellValue = VCme.ToString("N2")
                Me.dgvCompra.TableModel(rowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                Me.dgvCompra.TableModel(rowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                Me.dgvCompra.TableModel(rowIndex, 9).CellValue = VC.ToString("N2") 'importe total
                Me.dgvCompra.TableModel(rowIndex, 14).CellValue = VCme.ToString("N2") 'importe total me

                Me.dgvCompra.TableModel(rowIndex, 7).CellValue = 0 'igvmn
                Me.dgvCompra.TableModel(rowIndex, 12).CellValue = 0 'igvme

                Me.dgvCompra.TableModel(rowIndex, 8).CellValue = 0 'percepcion
                Me.dgvCompra.TableModel(rowIndex, 13).CellValue = 0 'percepcion me


            Case Else
                If cboMoneda.SelectedValue = 1 Then
                    ' DATOS SOLES
                    Select Case colDestinoGravado
                        Case "2", "3", "4"

                            Me.dgvCompra.TableModel(rowIndex, 5).CellValue = VC.ToString("N2")
                            Me.dgvCompra.TableModel(rowIndex, 10).CellValue = VCme.ToString("N2")
                            Me.dgvCompra.TableModel(rowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                            Me.dgvCompra.TableModel(rowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                            Me.dgvCompra.TableModel(rowIndex, 9).CellValue = VC.ToString("N2")
                            Me.dgvCompra.TableModel(rowIndex, 14).CellValue = VCme.ToString("N2")

                            Me.dgvCompra.TableModel(rowIndex, 7).CellValue = 0
                            Me.dgvCompra.TableModel(rowIndex, 12).CellValue = 0

                            Me.dgvCompra.TableModel(rowIndex, 8).CellValue = 0
                            Me.dgvCompra.TableModel(rowIndex, 13).CellValue = 0


                        Case Else
                            If Me.dgvCompra.TableModel(rowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                Me.dgvCompra.TableModel(rowIndex, 5).CellValue = VC.ToString("N2")
                                Me.dgvCompra.TableModel(rowIndex, 10).CellValue = VCme.ToString("N2")
                                Me.dgvCompra.TableModel(rowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                Me.dgvCompra.TableModel(rowIndex, 11).CellValue = colPrecUnitme.ToString("N2")
                                Me.dgvCompra.TableModel(rowIndex, 9).CellValue = VC.ToString("N2")
                                Me.dgvCompra.TableModel(rowIndex, 14).CellValue = VCme.ToString("N2")

                                Me.dgvCompra.TableModel(rowIndex, 7).CellValue = 0
                                Me.dgvCompra.TableModel(rowIndex, 12).CellValue = 0

                                Me.dgvCompra.TableModel(rowIndex, 8).CellValue = 0
                                Me.dgvCompra.TableModel(rowIndex, 13).CellValue = 0

                            Else
                                If cantidad > 0 Then


                                    Me.dgvCompra.TableModel(rowIndex, 5).CellValue = VC.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 10).CellValue = VCme.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                    Me.dgvCompra.TableModel(rowIndex, 9).CellValue = colBI.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 14).CellValue = colBIme.ToString("N2")

                                    Me.dgvCompra.TableModel(rowIndex, 7).CellValue = Igv.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 12).CellValue = IgvME.ToString("N2")


                                Else

                                    Me.dgvCompra.TableModel(rowIndex, 5).CellValue = VC.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 10).CellValue = VCme.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                    Me.dgvCompra.TableModel(rowIndex, 9).CellValue = VC.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 14).CellValue = VCme.ToString("N2")

                                    Me.dgvCompra.TableModel(rowIndex, 7).CellValue = Igv.ToString("N2")
                                    Me.dgvCompra.TableModel(rowIndex, 12).CellValue = IgvME.ToString("N2")


                                End If

                            End If
                    End Select

                ElseIf cboMoneda.SelectedValue = 2 Then

                    If ChImporteEditing.Checked Then
                        GetCalculoRowDolaresCH(rowIndex, colDestinoGravado)
                    Else
                        GetCalculoRowDolaresCH_BaseImponible(rowIndex, colDestinoGravado)
                    End If

                End If
        End Select

    End Sub

    Private Sub GetManaipulacionXimporte(RowIndex As Integer)
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
        cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
        dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  
        Select Case cboMoneda.SelectedValue
            Case 1 'MONEDA NACIONAL
                VC = CalculoBaseImponible(CDec(dgvCompra.TableModel(RowIndex, 9).CellValue), 1.18)
                VCme = Math.Round(VC / (txtTipoCambio.DecimalValue), 2)

                Me.dgvCompra.TableModel(RowIndex, 14).CellValue =
                    Math.Round(CDec(dgvCompra.TableModel(RowIndex, 9).CellValue) / txtTipoCambio.DecimalValue, 2) 'importe total me
            Case 2 'MONEDA EXTRANJERA
                VCme = CalculoBaseImponible(CDec(dgvCompra.TableModel(RowIndex, 14).CellValue), 1.18)
                VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

                Me.dgvCompra.TableModel(RowIndex, 9).CellValue =
                   Math.Round(CDec(dgvCompra.TableModel(RowIndex, 14).CellValue) * txtTipoCambio.DecimalValue, 2)
        End Select


        If cantidad > 0 AndAlso VC > 0 Then
            Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
            IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)

        ElseIf cantidad = 0 Then

            Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
            IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

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

            Case "03", "02" 'exonerados

                Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 'VC.ToString("N2")
                Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 'VCme.ToString("N2")
                Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2") 'importe total
                'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2") 'importe total me

                Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0 'igvmn
                Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0 'igvme

                Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0 'percepcion
                Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0 'percepcion me


            Case Else
                If cboMoneda.SelectedValue = 1 Then
                    ' DATOS SOLES
                    Select Case colDestinoGravado
                        Case "2", "3", "4"

                            Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 'VC.ToString("N2")
                            Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 ' VCme.ToString("N2")
                            Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                            Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                            'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                            'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                            Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                            Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                            Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                            Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


                        Case Else
                            If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 ' VC.ToString("N2")
                                Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 ' VCme.ToString("N2")
                                Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")
                                'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

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

                                    'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                                    'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                Else

                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                    'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                    'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                End If

                            End If
                    End Select

                ElseIf cboMoneda.SelectedValue = 2 Then
                    If ChImporteEditing.Checked Then
                        GetCalculoRowDolaresCH(RowIndex, colDestinoGravado)
                    Else
                        GetCalculoRowDolaresCH_BaseImponible(RowIndex, colDestinoGravado)
                    End If


                    'Select Case colDestinoGravado
                    '    Case "4"

                    '    Case Else


                    'End Select

                End If
        End Select
    End Sub

    Private Sub GetCalculoRowDolaresCH_BaseImponible(RowIndex As Integer, colDestinoGravado As String)
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
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
            valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
        Else
            valPercepMN = 0
            valPercepME = 0
        End If

        '****************************************************************
        cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
        dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue
        VCme = Me.dgvCompra.TableModel(RowIndex, 10).CellValue
        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
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


        Select Case colDestinoGravado
            Case "2", "3", "4" ' inafectos o exonerados

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


            Case Else ' items gravados tienen IVA
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

    End Sub

    Private Sub GetCalculoRowDolaresCH(RowIndex As Integer, colDestinoGravado As String)

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
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
            valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
        Else
            valPercepMN = 0
            valPercepME = 0
        End If

        '****************************************************************
        cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
        dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue
        Select Case cboMoneda.SelectedValue
            Case 1 'MONEDA NACIONAL
                VC = CalculoBaseImponible(CDec(dgvCompra.TableModel(RowIndex, 9).CellValue), 1.18)
                VCme = Math.Round(VC / (txtTipoCambio.DecimalValue), 2)
                Me.dgvCompra.TableModel(RowIndex, 14).CellValue =
                                            Math.Round(CDec(dgvCompra.TableModel(RowIndex, 9).CellValue) / txtTipoCambio.DecimalValue, 2)

            Case 2 'MONEDA EXTRANJERA
                VCme = CalculoBaseImponible(CDec(dgvCompra.TableModel(RowIndex, 14).CellValue), 1.18)
                VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)
                Me.dgvCompra.TableModel(RowIndex, 9).CellValue =
                                          Math.Round(CDec(dgvCompra.TableModel(RowIndex, 14).CellValue) * txtTipoCambio.DecimalValue, 2)
        End Select
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
            IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)


            'Igv = Math.Round(VC * (TmpIGV / 100), 2)
            'IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

            'colBI = VC + Igv + valPercepMN
            'colBIme = VCme + IgvME + valPercepME

            'colPrecUnit = Math.Round(VC / cantidad, 2)
            'colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 AndAlso VC > 0 Then
            Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
            IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

            colPrecUnit = 0
            colPrecUnitme = 0
        ElseIf cantidad = 0 Then
            Igv = Math.Round(CDec(CalculoIva(VC, 0.18)), 2)
            IgvME = Math.Round(CDec(CalculoIva(VCme, 0.18)), 2)

            colPrecUnit = 0
            colPrecUnitme = 0

            'ElseIf cantidad = 0 Then
            '    Igv = Math.Round(VC * (TmpIGV / 100), 2)
            '    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
            '    colBI = VC + Igv + valPercepMN
            '    colBIme = VCme + IgvME + valPercepME
            '    colPrecUnit = 0
            '    colPrecUnitme = 0
        Else
            colPrecUnit = 0
            colPrecUnitme = 0

            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If


        Select Case colDestinoGravado
            Case "2", "3", "4" ' inafectos o exonerados

                Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 'VC.ToString("N2")
                Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 'VCme.ToString("N2")
                Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
                Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

                Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
                Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


            Case Else ' items gravados tienen IVA
                If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = 0 ' VC.ToString("N2")
                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = 0 ' VCme.ToString("N2")
                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")
                    'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                    'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

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

                        'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                        'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                    Else

                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                        'Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                        'Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                    End If

                End If
        End Select
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
                    If ChImporteEditing.Checked Then
                        CalculosByMontoTotal()
                    Else
                        Calculos()
                    End If
                Case 9, 14
                    CalculosByMontoTotal()
                Case 5, 10 'Valor de compra
                    If ChImporteEditing.Checked Then
                        CalculosByMontoTotal()
                    Else
                        Calculos()
                    End If
                Case 6
                    If ChImporteEditing.Checked Then
                        CalculosByPrecioUnitario()
                    Else
                        Calculos()
                    End If
                Case 8
                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / txtTipoCambio.DecimalValue, 2)
                    dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    '   Calculos()
                    If ChImporteEditing.Checked Then
                        CalculosByMontoTotal()
                    Else
                        Calculos()
                    End If
                Case 11
                    If ChImporteEditing.Checked Then
                        CalculosByPrecioUnitarioME()
                    Else
                        Calculos()
                    End If
                Case 13
                    Dim colPercepcionMN As Decimal = 0
                    colPercepcionMN = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")) * txtTipoCambio.DecimalValue, 2)
                    dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", colPercepcionMN)
                    If ChImporteEditing.Checked Then
                        CalculosByMontoTotal()
                    Else
                        Calculos()
                    End If
                Case 14
                    If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
                        dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
                    End If

                Case 1
                    If ChImporteEditing.Checked Then
                        CalculosByMontoTotal()
                    Else
                        Calculos()
                    End If

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
        Dim objPleaseWait As New FeedbackForm()
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Dim compraSA As New DocumentoCompraSA
        Me.Cursor = Cursors.WaitCursor
        Try

            If TxtDia.Text.Trim.Length = 0 Then
                lblEstado.Text = "Debe ingresar la fecha de compra"
                PanelError.Visible = True
                TiempoEjecutar(10)
                TxtDia.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


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

                objPleaseWait = New FeedbackForm()
                objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                objPleaseWait.Show()
                Application.DoEvents()
                'Dim fechaCierreAnt = txtFechaGuia.Value.AddMonths(-1)
                'Dim validaCierreAnterior As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaCierreAnt.Year, .mes = fechaCierreAnt.Month})
                'If validaCierreAnterior = False Then
                '    MessageBox.Show("No puede realizar está operación" & vbCrLf & "debe cerrar el período anterior, " & fechaCierreAnt.Month & "-" & fechaCierreAnt.Year, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Cursor = Cursors.Default
                '    objPleaseWait.Close()
                '    Exit Sub
                'End If


                'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtFechaGuia.Value.Year, .mes = txtFechaGuia.Value.Month})
                'If Not IsNothing(valida) Then
                '    If valida = True Then

                '        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Cursor = Cursors.Default
                '        objPleaseWait.Close()
                '        Exit Sub
                '    End If
                'End If

                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    Dim comprobante = compraSA.CompraEsvalida(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                                            .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                            .serie = txtSerie.Text.Trim,
                                                                                                            .numeroDoc = txtNumero.Text.Trim,
                                                                                                            .tipoDoc = cboTipoDoc.SelectedValue,
                                                                                                            .idProveedor = Integer.Parse(txtProveedor.Tag)})

                    If comprobante = True Then ' si la compra es unica
                        Grabar()
                        ' Close()
                    Else
                        If MessageBox.Show("El número de comprobante ya existe en la base de datos!, desea seguir?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Grabar()
                            '    Close()
                        End If
                    End If
                ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    Editar()
                End If
                objPleaseWait.Close()

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
            objPleaseWait.Close()
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
        If e.Inner.KeyCode = Keys.Delete Then
            If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
                Me.dgvCompra.Table.CurrentRecord.Delete()
                TotalTalesXcolumna()
            End If
        End If
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

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtruc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtruc.Text.Trim)
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
            txtruc.Text = c.nrodoc
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

            Case "36", "01", "03", "04", "06", "07", "08",
                "56", "10", "22", "46" ' NUMERO DE DIGITOS : 4
                txtSerie.MaxLength = 4

            Case "11" To "19",
                "21", "24", "26", "27", "28", "29", "30", "32", "37",
                "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20
                txtSerie.MaxLength = 20

        End Select
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

    Private Sub ComboBoxAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv2.SelectedIndexChanged
        If ComboBoxAdv2.Text = "DE CONTADO" Then
            txtFecVence.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        ElseIf ComboBoxAdv2.Text = "7 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(7)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "10 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(10)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "15 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(15)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "30 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(30)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "33 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(33)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "45 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(45)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "55 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(55)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "60 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            fecha = fecha.AddDays(60)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "90 DIAS" Then
            Dim fecha As DateTime = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If txtTipoCambio.Text > 0 Then
                    If ChImporteEditing.Checked Then
                        TipoCambio()
                    Else
                        TipoCambioBaseImponible()
                    End If

                End If
            End If

        End If

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


    'Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs)
    '    If IsDate(txtFecha.Value) Then
    '        If txtFecha.Value.Date > DiaLaboral.Date Then
    '            txtFecha.Value = DiaLaboral
    '            MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '        If cboMoneda.SelectedValue = 2 Then
    '            txtTipoCambio.DecimalValue = 0
    '        Else
    '            Dim consulta = (From n In ListaTipoCambio _
    '                       Where n.fechaIgv.Year = txtFecha.Value.Year _
    '                       And n.fechaIgv.Month = txtFecha.Value.Month _
    '                       And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

    '            If Not IsNothing(consulta) Then
    '                txtTipoCambio.DecimalValue = consulta.venta
    '            Else
    '                'txtTipoCambio.DecimalValue = 0
    '            End If
    '        End If

    '        txtFechaGuia.Value = txtFecha.Value

    '        If dgvCompra.Table.Records.Count > 0 Then
    '            For Each r As Record In dgvCompra.Table.Records
    '                r.SetValue("fecEntrega", txtFecha.Value)
    '            Next
    '        End If
    '    End If
    'End Sub

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
                If TxtDia.Text.Trim.Length > 0 Then
                    If cboAnio.Text.Trim.Length > 0 Then
                        Dim consulta = (From n In ListaTipoCambio
                                        Where n.fechaIgv.Year = CInt(cboAnio.Text) _
                                 And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                                 And n.fechaIgv.Day = TxtDia.Text).FirstOrDefault

                        If Not IsNothing(consulta) Then
                            txtTipoCambio.DecimalValue = consulta.venta
                        Else
                            'txtTipoCambio.DecimalValue = 0
                        End If
                    End If
                Else
                    'MessageBox.Show("El campo día es obligatorio, para definir el tipo de cambio!", "Verificar tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtDia.SelectAll()
                End If

            End If
            ChImporteEditing_OnChange(sender, e)
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

            Case "12" To "19",
                "21", "24", "26", "27", "28", "29", "30", "32", "37",
                "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

        End Select
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
            txtruc.Text = c.nrodoc
            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            'txtSerie.Clear()
            'txtNumero.Clear()
            'txtSerieGuia.Clear()
            'txtNumeroGuia.Clear()
        End If
    End Sub

    Private Sub btnPegadoEspecial_Click(sender As Object, e As EventArgs) Handles btnPegadoEspecial.Click
        If Not IsNothing(ClipBoardDocumento) Then
            UbicarDocumentoPegado()
        End If
    End Sub

    Private Sub cboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click
        '    txtDia.Value = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
    End Sub

    Private Sub cboMesCompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedIndexChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            'txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)

            'txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        End If
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            'txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            'txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
            Else
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                TxtDia.Clear()
            End If

            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                If TxtDia.Text.Trim.Length > 0 Then
                    Dim consulta = (From n In ListaTipoCambio
                                    Where n.fechaIgv.Year = cboAnio.Text _
                               And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                               And n.fechaIgv.Day = TxtDia.Text).FirstOrDefault

                    If Not IsNothing(consulta) Then
                        txtTipoCambio.DecimalValue = consulta.venta
                    Else
                        'txtTipoCambio.DecimalValue = 0
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub chCambioPeriodo_CheckStateChanged(sender As Object, e As EventArgs) Handles chCambioPeriodo.CheckStateChanged
        If chCambioPeriodo.Checked = True Then
            txtPeriodoCambio.Visible = True
            txtPeriodoCambio.Select()
        Else
            txtPeriodoCambio.Visible = False
        End If
    End Sub

    Private Sub cboAnio_Click(sender As Object, e As EventArgs) Handles cboAnio.Click

    End Sub

    'Private Sub txtDia_ValueChanged(sender As Object, e As EventArgs) Handles txtDia.ValueChanged
    '    If cboMesCompra.Text.Trim.Length > 0 Then
    '        If txtDia.IsNullDate = False Then
    '            txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
    '        End If

    '        If cboMoneda.SelectedValue = 2 Then
    '            txtTipoCambio.DecimalValue = 0
    '        Else
    '            If txtDia.IsNullDate = False Then
    '                Dim consulta = (From n In ListaTipoCambio
    '                                Where n.fechaIgv.Year = cboAnio.Text _
    '                           And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
    '                           And n.fechaIgv.Day = txtDia.Value.Day).FirstOrDefault

    '                If Not IsNothing(consulta) Then
    '                    txtTipoCambio.DecimalValue = consulta.venta
    '                Else
    '                    'txtTipoCambio.DecimalValue = 0
    '                End If
    '            End If

    '        End If
    '    End If

    'End Sub

    Private Sub cboAsignacion_Click(sender As Object, e As EventArgs) Handles cboAsignacion.Click

    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            If IsNumeric(cboAnio.Text) AndAlso IsNumeric(cboMesCompra.SelectedValue) Then
                TxtDia_TextChanged(sender, e)
                lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            End If
        End If
    End Sub

    Private Sub GradientPanel3_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel3.Paint

    End Sub

    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        If txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub cboAsignacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAsignacion.SelectedValueChanged
        If dgvCompra.Table.Records.Count > 0 Then
            Select Case cboAsignacion.Text
                Case "POR LOTES"
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Add("lote")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Add("fechaProd")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Add("fechaVcto")
                Case "LOTE EXISTENTE"

                Case "CONTROL POR COMPROBANTE"

                    Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("lote")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("fechaProd")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("fechaVcto")
            End Select
        End If

    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            listaProveedores.Add(c)
            txtProveedor.Text = c.nombreCompleto
            txtruc.Text = c.nrodoc
            txtruc.Visible = True
            txtProveedor.Tag = c.idEntidad
            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                If lsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        txtProveedor.Text = c.nombreCompleto
                        txtProveedor.Tag = c.idEntidad
                        txtruc.Visible = True
                        txtruc.Text = c.nrodoc
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        listaProveedores.Add(c)
                    End If
                Else
                    txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        PopupControlContainer4.HidePopup(PopupCloseType.Done)
    End Sub

    'Private Sub bgCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
    '    If bgCombos.CancellationPending Then
    '        ' MessageBox.Show("Up to here? ...")
    '        e.Cancel = True
    '    Else
    '        GetCombos()
    '    End If
    'End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            Dim consulta2 = (From n In listaProveedores
                             Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList

            consulta.AddRange(consulta2)
            FillLSVProveedores(consulta)
            If consulta.Count <= 1 Then
                If MessageBox.Show("El proveedor ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim f As New frmCrearENtidades(txtProveedor.Text)
                    f.CaptionLabels(0).Text = "Nuevo proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        txtProveedor.Text = c.nombreCompleto
                        txtProveedor.Tag = c.idEntidad
                        txtruc.Visible = True
                        txtruc.Text = c.nrodoc
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        listaProveedores.Add(c)
                    End If

                End If

            End If

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            Dim consulta2 = (From n In listaProveedores
                             Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList

            consulta.AddRange(consulta2)
            FillLSVProveedores(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            lsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then
            'If TxtDia.IsNullDate = False Then
            '    txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            'End If

            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                If TxtDia.Text.Trim.Length > 0 Then
                    Dim consulta = (From n In ListaTipoCambio
                                    Where n.fechaIgv.Year = cboAnio.Text _
                               And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                               And n.fechaIgv.Day = TxtDia.Text).FirstOrDefault

                    If Not IsNothing(consulta) Then
                        txtTipoCambio.DecimalValue = consulta.venta
                    Else
                        'txtTipoCambio.DecimalValue = 0
                    End If
                End If

            End If
        End If
    End Sub


    'Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

    '    If e.Cancelled Then

    '    Else
    '        Loadcontroles()
    '        LoadTipoCambio()
    '        ToolStrip5.Enabled = True
    '        lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
    '        Meses()
    '    End If
    'End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frmCanastaInventary = New FormCanastaServicios()
        frmCanastaInventary.StartPosition = FormStartPosition.CenterParent
        frmCanastaInventary.ShowDialog(Me)
    End Sub

    Private Sub txtIva_TextChanged(sender As Object, e As EventArgs) Handles txtIva.TextChanged

    End Sub

    Private Sub ChImporteEditing_OnChange(sender As Object, e As EventArgs) Handles ChImporteEditing.OnChange
        If ChImporteEditing.Checked = True Then
            Select Case cboMoneda.SelectedValue
                Case 1
                    dgvCompra.TableDescriptor.Columns("vcmn").ReadOnly = True
                    dgvCompra.TableDescriptor.Columns("totalmn").ReadOnly = False

                    dgvCompra.TableDescriptor.Columns("vcmn").Appearance.AnyRecordFieldCell.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
                    dgvCompra.TableDescriptor.Columns("vcmn").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.White

                    dgvCompra.TableDescriptor.Columns("totalmn").Appearance.AnyRecordFieldCell.BackColor = Color.Yellow
                    dgvCompra.TableDescriptor.Columns("totalmn").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromKnownColor(KnownColor.HotTrack)
                Case 2
                    dgvCompra.TableDescriptor.Columns("vcme").ReadOnly = True
                    dgvCompra.TableDescriptor.Columns("totalme").ReadOnly = False

                    dgvCompra.TableDescriptor.Columns("vcme").Appearance.AnyRecordFieldCell.BackColor = Color.FromArgb(92, 184, 92)
                    dgvCompra.TableDescriptor.Columns("vcme").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.White

                    dgvCompra.TableDescriptor.Columns("totalme").Appearance.AnyRecordFieldCell.BackColor = Color.Yellow
                    dgvCompra.TableDescriptor.Columns("totalme").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromKnownColor(KnownColor.HotTrack)
            End Select

        ElseIf ChImporteEditing.Checked = False Then
            Select Case cboMoneda.SelectedValue
                Case 1
                    dgvCompra.TableDescriptor.Columns("vcmn").ReadOnly = False
                    dgvCompra.TableDescriptor.Columns("totalmn").ReadOnly = True

                    dgvCompra.TableDescriptor.Columns("vcmn").Appearance.AnyRecordFieldCell.BackColor = Color.Yellow
                    dgvCompra.TableDescriptor.Columns("vcmn").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromKnownColor(KnownColor.HotTrack)

                    dgvCompra.TableDescriptor.Columns("totalmn").Appearance.AnyRecordFieldCell.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
                    dgvCompra.TableDescriptor.Columns("totalmn").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromKnownColor(KnownColor.White)
                Case 2
                    dgvCompra.TableDescriptor.Columns("vcme").ReadOnly = False
                    dgvCompra.TableDescriptor.Columns("totalme").ReadOnly = True


                    dgvCompra.TableDescriptor.Columns("vcme").Appearance.AnyRecordFieldCell.BackColor = Color.Yellow
                    dgvCompra.TableDescriptor.Columns("vcme").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromKnownColor(KnownColor.HotTrack)

                    dgvCompra.TableDescriptor.Columns("totalme").Appearance.AnyRecordFieldCell.BackColor = Color.FromArgb(92, 184, 92)
                    dgvCompra.TableDescriptor.Columns("totalme").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.White


            End Select
        End If
    End Sub

    Private Sub ChPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles ChPrecios.CheckedChanged
        If ChPrecios.Checked = True Then

            dgvCompra.TableDescriptor.Columns("menor").Width = 75
            dgvCompra.TableDescriptor.Columns("mayor").Width = 75
            dgvCompra.TableDescriptor.Columns("gmayor").Width = 75

        Else
            dgvCompra.TableDescriptor.Columns("menor").Width = 0
            dgvCompra.TableDescriptor.Columns("mayor").Width = 0
            dgvCompra.TableDescriptor.Columns("gmayor").Width = 0
        End If
    End Sub

    Public Sub EnviarServicio(ServicioBE As servicio) Implements IServicio.EnviarServicio
        If ServicioBE IsNot Nothing Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            If Gempresas.Regimen = "1" Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
            Else
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 2)
            End If

            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", ServicioBE.cuenta)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", ServicioBE.descripcion)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", "UND")
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

            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", ServicioBE.idPadre)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "S")

            ' si costea o gasto
            'If GbCostoGasto.Visible = True Then
            '    If rbCosto.Checked = True Then
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("idCosto", txtidEntregable.Text)
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("TipoCosto", "PC")
            '    ElseIf rbGasto.Checked = True Then
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("idCosto", txtidEntregable.Text)
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("TipoCosto", "PG")
            '    End If
            'End If


            Me.dgvCompra.Table.AddNewRecord.EndEdit()

            If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim

            End If
        End If
    End Sub

    Private Sub FormCompras_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  bgCombos.RunWorkerAsync()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles BtnCanastaCompra.Click
        With FormCanastaCompras
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog(Me)
            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Focus()
                Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 4, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
                Me.ActiveControl = Me.dgvCompra.TableControl
                dgvCompra.WantTabKey = True

                'Dim colIndex As Integer = Me.dgvCompra.TableDescriptor.FieldToColIndex(0)
                'Dim rowIndex As Integer = Me.dgvCompra.Table.Records(0).GetRowIndex()
                'Me.dgvCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                'Me.dgvCompra.Focus()
            End If

        End With
    End Sub

    Private Sub FormCompras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'ListaAlmacenes.Clear()
        'bgCombos.CancelAsync()

        'With FormCanastaCompras
        '    .GridItems.Table.Records.DeleteAll()
        '    .txtFiltrar.Clear()
        'End With
        If dgvCompra.Table.Records.Count > 0 Then
            If MessageBox.Show("¿Desea salir de la compra?", "Salir de la ventana", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If listaAnios IsNot Nothing Then
                    listaAnios.Clear()
                End If
                If listaMeses IsNot Nothing Then
                    listaMeses.Clear()
                End If

                If ListaAlmacenes IsNot Nothing Then
                    ListaAlmacenes.Clear()
                End If
                If thread2 IsNot Nothing Then
                    thread2.Abort()
                End If

                With FormCanastaCompras
                    .GridItems.Table.Records.DeleteAll()
                    .txtFiltrar.Clear()
                End With
            Else
                e.Cancel = True
            End If
        Else
            If listaAnios IsNot Nothing Then
                listaAnios.Clear()
            End If
            If listaMeses IsNot Nothing Then
                listaMeses.Clear()
            End If

            If ListaAlmacenes IsNot Nothing Then
                ListaAlmacenes.Clear()
            End If

            If thread2 IsNot Nothing Then
                thread2.Abort()
            End If

            With FormCanastaCompras
                .GridItems.Table.Records.DeleteAll()
                .txtFiltrar.Clear()
            End With
        End If
    End Sub

    Public Sub EnviarItem(be As detalleitems) Implements IExistencias.EnviarItem
        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", be.origenProducto)
        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", be.codigodetalle)
        Me.dgvCompra.Table.CurrentRecord.SetValue("item", be.descripcionItem)
        Me.dgvCompra.Table.CurrentRecord.SetValue("um", be.unidad1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", be.tipoExistencia)
        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        If be.tipoExistencia = "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
        Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", ListaAlmacenes(0).idAlmacen)
        End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", be.unidad2)
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)
        If TxtDia.Text.Trim.Length > 0 Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second))
        Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1, Date.Now.Hour, Date.Now.Minute, Date.Now.Second))
        End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", be.codigo)
        Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", Date.Now)
        Me.dgvCompra.Table.CurrentRecord.SetValue("fechaProd", Date.Now)
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", 0)
        Me.dgvCompra.Table.AddNewRecord.EndEdit()

        Dim colIndex As Integer = Me.dgvCompra.TableDescriptor.FieldToColIndex(0)
        Dim rowIndex As Integer = Me.dgvCompra.Table.Records(0).GetRowIndex()
        'Me.dgvCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)

        'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
        'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
        dgvCompra.Focus()

        Me.dgvCompra.TableControl.CurrentCell.MoveTo(rowIndex, 2)
        Me.dgvCompra.TableControl.CurrentCell.Activate(rowIndex, 2)
        Me.dgvCompra.TableControl.CurrentCell.BeginEdit()
    End Sub

    Private Sub FormCompras_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub FormCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtDia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtSerie.Select()
            txtSerie.Focus()
        End If
    End Sub
#End Region

End Class