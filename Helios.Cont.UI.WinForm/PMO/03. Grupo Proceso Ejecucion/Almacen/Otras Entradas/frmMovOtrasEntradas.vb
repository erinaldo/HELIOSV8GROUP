Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMovOtrasEntradas
    Inherits frmMaster

#Region "Fields"
    Private threadEntidades As Thread
    Public Property ListaEntidad As List(Of entidad)
    Public Property ListaTrabajadores As List(Of Persona)
    Dim entidadSA As New entidadSA
    Dim personaSA As New PersonaSA
    Friend Delegate Sub SetDelegateEntidad(ByVal lista As List(Of entidad), tipo As String)
    Friend Delegate Sub SetDelegatePersona(ByVal Persons As List(Of Persona))
#End Region

    Public Property txtCuenta As String
    Public Property ListaMovimientos As New List(Of movimiento)
    Dim Alert As Alert
    Dim srtNomAlmacen As String = Nothing
    Dim strUM As String = Nothing
    Dim strTipoEx As String = Nothing
    Dim strCuenta As String = Nothing
    Dim intIdEstableAlm As Integer
    Dim strIdPresentacion As String = Nothing
    Dim selAlmacenPC As String

    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ManipulacionEstado() As String
    Private cantidaExistente As New List(Of Integer)
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable
    Public Property sumaMN() As Decimal
    Public Property sumaME() As Decimal
    Dim colorx As New GridMetroColors()
    Dim conf As New GConfiguracionModulo
    Private v As Object

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        dockingManager1.DockControlInAutoHideMode(Panel2, Tools.DockingStyle.Left, 390)
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Canasta existencias")

        'INICIO PERIODO
        '     lblPerido.Text = PeriodoGeneral
        dockingManager1.CloseEnabled = False
        CargarListas()
        cargaralmacen()
        GridCFG(dgvMov)
        dgvMov.DataSource = GetTableGrid()
        GetCMBMeses()
        txtTipoCambio.DecimalValue = TmpTipoCambio

        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        lblEmpresa.Text = Gempresas.NomEmpresa ' GEstableciento.NombreEstablecimiento

    End Sub

    Public Sub New(EntradaDet As List(Of documentocompradetalle))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        dockingManager1.DockControlInAutoHideMode(Panel2, Tools.DockingStyle.Left, 390)
        Me.dockingClientPanel1.BorderStyle = BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Canasta existencias")

        'INICIO PERIODO
        '     lblPerido.Text = PeriodoGeneral
        dockingManager1.CloseEnabled = False
        CargarListas()
        cargaralmacen()
        GridCFG(dgvMov)
        dgvMov.DataSource = GetTableGridlote()
        AgregarItem(EntradaDet)
        GetCMBMeses()
        txtTipoCambio.DecimalValue = TmpTipoCambio

        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        lblEmpresa.Text = Gempresas.NomEmpresa ' GEstableciento.NombreEstablecimiento
    End Sub


#Region "metodos"
    Private Sub GetCMBMeses()
        Dim listaAnios As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = listaAnios.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub

    Private Sub AddColumnLotes()
        Dim costoSA As New recursoCostoLoteSA
        Dim lista As New List(Of recursoCostoLote)
        dgvMov.TableDescriptor.Columns.Add("lote")
        dgvMov.TableDescriptor.VisibleColumns.Add("lote")
        dgvMov.TableDescriptor.Columns("lote").MappingName = "lote"
        dgvMov.TableDescriptor.Columns("lote").HeaderText = "Nro.Lote"
        dgvMov.TableDescriptor.Columns("lote").Name = "lote"
        dgvMov.TableDescriptor.Columns("lote").Width = 100
        dgvMov.TableDescriptor.Columns("lote").ReadOnly = False
        dgvMov.TableDescriptor.Columns("lote").AllowSort = False

        dgvMov.TableDescriptor.Columns.Add("fechaProd")
        dgvMov.TableDescriptor.VisibleColumns.Add("fechaProd")
        dgvMov.TableDescriptor.Columns("fechaProd").MappingName = "fechaProd"
        dgvMov.TableDescriptor.Columns("fechaProd").HeaderText = "Fec. Prod."
        dgvMov.TableDescriptor.Columns("fechaProd").Name = "fechaProd"
        dgvMov.TableDescriptor.Columns("fechaProd").Width = 0 '100
        dgvMov.TableDescriptor.Columns("fechaProd").ReadOnly = False
        dgvMov.TableDescriptor.Columns("fechaProd").Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        dgvMov.TableDescriptor.Columns("fechaProd").AllowSort = False

        dgvMov.TableDescriptor.Columns.Add("fechaVcto")
        dgvMov.TableDescriptor.VisibleColumns.Add("fechaVcto")
        dgvMov.TableDescriptor.Columns("fechaVcto").MappingName = "fechaVcto"
        dgvMov.TableDescriptor.Columns("fechaVcto").HeaderText = "Fec. Vcto."
        dgvMov.TableDescriptor.Columns("fechaVcto").Name = "fechaVcto"
        dgvMov.TableDescriptor.Columns("fechaVcto").Width = 100
        dgvMov.TableDescriptor.Columns("fechaVcto").ReadOnly = False
        dgvMov.TableDescriptor.Columns("fechaVcto").Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        dgvMov.TableDescriptor.Columns("fechaVcto").AllowSort = False
        'lista = costoSA.GetLotes()
        'lista.Add(New recursoCostoLote With {.nroLote = "Nuevo Lote"})
        'Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("lote").Appearance.AnyRecordFieldCell
        'ggcStyle.CellType = "ComboBox"
        'ggcStyle.DataSource = lista
        'ggcStyle.ValueMember = "nroLote"
        'ggcStyle.DisplayMember = "nroLote"
        'ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Dim listaCategoria As New List(Of item)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA
        listaCategoria = New List(Of item)
        listaCategoria = categoriaSA.GetListaPadre()
        Label42.Text = listaCategoria.Count & " items"

    End Sub


    Private Sub cargaralmacen()
        Dim almacenSA As New almacenSA
        Dim tablaSA As New tablaDetalleSA

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "AF")
    End Sub
#End Region

#Region "Personal"

    Sub HabilitarControles(tipoEntidad As String, estado As Boolean)
        TextPersona.Enabled = estado
        Select Case tipoEntidad
            Case TIPO_ENTIDAD.CLIENTE
                RBProveedor.Enabled = estado
                '    RBCPlanilla.Enabled = estado
                RBOtros.Enabled = estado
            Case TIPO_ENTIDAD.PROVEEDOR
                RBCliente.Enabled = estado
                '   RBCPlanilla.Enabled = estado
                RBOtros.Enabled = estado
            Case TIPO_ENTIDAD.PERSONA_GENERAL
                RBCliente.Enabled = estado
                RBProveedor.Enabled = estado
             '   RBCPlanilla.Enabled = estado
            Case TIPO_ENTIDAD.PERSONAL_PLANILLA
                RBCliente.Enabled = estado
                RBProveedor.Enabled = estado
                RBOtros.Enabled = estado
        End Select

    End Sub

    Private Sub GetThreadEntidades(strTipo As String)
        'ProgressBar1.Visible = True
        'ProgressBar1.Style = ProgressBarStyle.Marquee
        TextPersona.Clear()
        TextDNI.Clear()
        HabilitarControles(strTipo, False)
        threadEntidades = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetEntidades(strTipo)))
        threadEntidades.Start()
    End Sub

    Private Sub GetEntidades(tipoPerson As String)

        Select Case tipoPerson
            Case TIPO_ENTIDAD.PROVEEDOR, TIPO_ENTIDAD.CLIENTE
                Dim ListaEntidades As New List(Of entidad)
                ListaEntidades = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipoPerson, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                setDataSourceEntidad(ListaEntidades, tipoPerson)
            Case TIPO_ENTIDAD.PERSONA_GENERAL
                Dim listaPersonas As New PersonaSA
                Dim ListaPersons As New List(Of Persona)
                ListaPersons = personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList
                setDataSourcePersona(ListaPersons)
        End Select


    End Sub

    Private Sub setDataSourceEntidad(GetEntidades As List(Of entidad), tipo As String)
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {GetEntidades, tipo})
        Else
            ListaEntidad = New List(Of entidad)
            ListaEntidad = GetEntidades
            '         ProgressBar1.Visible = False
            HabilitarControles(tipo, True)
        End If
    End Sub

    Private Sub setDataSourcePersona(GetPersonas As List(Of Persona))
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegatePersona(AddressOf setDataSourcePersona)
            Invoke(deleg, New Object() {GetPersonas})
        Else
            ListaTrabajadores = New List(Of Persona)
            ListaTrabajadores = GetPersonas
            'ProgressBar1.Visible = False
            HabilitarControles(TIPO_ENTIDAD.PERSONA_GENERAL, True)
        End If
    End Sub

    Private Sub FillLSVPersonas(consulta As List(Of Persona))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idPersona)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub FillLSVEntidades(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub
#End Region

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            lblPerido.Text = (cboMesCompra.SelectedValue & "/" & cboAnio.Text)
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
            Else
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                TxtDia.Clear()
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            lblPerido.Text = (cboMesCompra.SelectedValue & "/" & cboAnio.Text)
            TxtDia_TextChanged(sender, e)
        End If
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

    Private Function GetTableGrid2() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cant", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("descripcion", GetType(String))

        Return dt
    End Function

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

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
#Region "asiento"

    Sub updateMovimiento(r As Record)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaMovimientos
                            Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

    'Sub RegistrarMovimiento(nAsiento As asiento)

    '    Dim dt As New DataTable
    '    dt.Columns.Add("id", GetType(Integer))
    '    dt.Columns.Add("importeMN", GetType(Decimal))
    '    dt.Columns.Add("importeME", GetType(Decimal))
    '    dt.Columns.Add("HaberMN", GetType(Decimal))
    '    dt.Columns.Add("HaberME", GetType(Decimal))
    '    dt.Columns.Add("tipoAsiento", GetType(String))
    '    dt.Columns.Add("cuenta", GetType(String))

    '    Dim cosnulta = (From i In ListaMovimientos _
    '                   Where i.idAsiento = nAsiento.idAsiento).ToList

    '    For Each x In cosnulta
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = x.idmovimiento
    '        Select Case x.tipo
    '            Case "D"
    '                dr(1) = x.monto
    '                dr(2) = x.montoUSD
    '                dr(3) = 0
    '                dr(4) = 0
    '            Case "H"
    '                dr(1) = 0
    '                dr(2) = 0
    '                dr(3) = x.monto
    '                dr(4) = x.montoUSD
    '        End Select
    '        dr(5) = x.tipo
    '        dr(6) = x.cuenta
    '        dt.Rows.Add(dr)
    '    Next
    '    dgvAsiento.DataSource = dt
    'End Sub

    'Sub GetasientosListbox()
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("id")
    '    dt.Columns.Add("nombre")

    '    For Each i In ListaAsientonTransito
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idAsiento
    '        dr(1) = i.Descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    lstAsiento.DisplayMember = "nombre"
    '    lstAsiento.ValueMember = "id"
    '    lstAsiento.DataSource = dt
    'End Sub

    'Sub RegistrarAsientos()
    '    Dim nAsiento As New asiento

    '    If ListaAsientonTransito.Count > 0 Then
    '        nAsiento.idAsiento = ListaAsientonTransito.Count + 1
    '    Else
    '        nAsiento.idAsiento = 1
    '    End If
    '    nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
    '    ListaAsientonTransito.Add(nAsiento)

    '    GetasientosListbox()
    'End Sub

    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    'Sub RegistrarMovimiento(nAsiento As asiento)

    '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '    Dim dt As New DataTable
    '    dt.Columns.Add("id", GetType(Integer))
    '    dt.Columns.Add("Modulo", GetType(String))
    '    dt.Columns.Add("cuenta", GetType(String))
    '    dt.Columns.Add("tipoAsiento", GetType(String))
    '    dt.Columns.Add("cant", GetType(Decimal))
    '    dt.Columns.Add("pumn", GetType(Decimal))
    '    dt.Columns.Add("importeMN", GetType(Decimal))
    '    dt.Columns.Add("pume", GetType(Decimal))
    '    dt.Columns.Add("importeME", GetType(Decimal))
    '    dt.Columns.Add("descripcion", GetType(String))

    '    Dim cosnulta = (From i In ListaMovimientos _
    '                   Where i.idAsiento = nAsiento.idAsiento).ToList

    '    '   For x As Integer = 0 To cosnulta.Count - 1

    '    'dt.Rows.Add(dt.NewRow())
    '    'dt.Rows(x)(0) = CInt(cosnulta(x).idmovimiento)
    '    'If Not IsNothing(cosnulta(x).cuenta) Then
    '    '    dt.Rows(x)(1) = cosnulta(x).nombreEntidad
    '    'Else
    '    '    dt.Rows(x)(1) = String.Empty
    '    'End If
    '    'dt.Rows(x)(2) = cosnulta(x).cuenta
    '    'dt.Rows(x)(3) = cosnulta(x).tipo
    '    'dt.Rows(x)(4) = cosnulta(x).Cant
    '    'dt.Rows(x)(5) = cosnulta(x).PUmn
    '    'dt.Rows(x)(6) = cosnulta(x).monto
    '    'dt.Rows(x)(7) = cosnulta(x).PUme
    '    'dt.Rows(x)(8) = cosnulta(x).montoUSD
    '    'dt.Rows(x)(9) = cosnulta(x).descripcion
    '    For Each x In cosnulta
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = x.idmovimiento
    '        If Not IsNothing(x.cuenta) Then
    '            dr(1) = x.nombreEntidad
    '        Else
    '            dr(1) = String.Empty
    '        End If
    '        dr(2) = x.cuenta
    '        dr(3) = x.tipo
    '        dr(4) = x.Cant
    '        dr(5) = x.PUmn
    '        dr(6) = x.monto
    '        dr(7) = x.PUme
    '        dr(8) = x.montoUSD
    '        dr(9) = x.descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    dgvCompra.DataSource = dt
    'End Sub


    'Sub UbicarAsientoPorId(asiento As asiento)
    '    Dim consulta = (From n In ListaAsientonTransito _
    '            Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '    If Not IsNothing(consulta) Then
    '        txtGlosaAsiento.Text = consulta.glosa
    '    End If
    'End Sub

#End Region


    Private Function GetTableGrid() As DataTable
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable

        AddColumnLotes()

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Correccion", GetType(String))
        dt.Columns.Add("grav", GetType(String))

        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("idPrese", GetType(String))
        dt.Columns.Add("nomPrese", GetType(String))
        dt.Columns.Add("idUM", GetType(String))
        dt.Columns.Add("nomUM", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("precMN", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("precME", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("almacenDestino", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("almacenBack", GetType(Integer))
        dt.Columns.Add("cuentaHaber", GetType(String))
        dt.Columns.Add("utiMenor", GetType(Decimal))
        dt.Columns.Add("utiMayor", GetType(Decimal))
        dt.Columns.Add("utiGranMayor", GetType(Decimal))
        dt.Columns.Add("colModVenta", GetType(Boolean))
        dt.Columns.Add("valCheck", GetType(String))
        dt.Columns.Add("lote", GetType(String))
        dt.Columns.Add("fechaProd", GetType(DateTime))
        dt.Columns.Add("fechaVcto", GetType(DateTime))
        dt.Columns.Add("codigoLote", GetType(Integer))
        dt.Columns.Add("menor", GetType(Decimal))
        dt.Columns.Add("mayor", GetType(Decimal))
        dt.Columns.Add("gmayor", GetType(Decimal))
        dt.Columns.Add("MontoBase", GetType(Decimal))
        dt.Columns.Add("preciounitarioIGV", GetType(Decimal))
        Return dt
    End Function

    Private Function GetTableGridlote() As DataTable
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable

        AddColumnLotes()

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Correccion", GetType(String))
        dt.Columns.Add("grav", GetType(String))

        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("idPrese", GetType(String))
        dt.Columns.Add("nomPrese", GetType(String))
        dt.Columns.Add("idUM", GetType(String))
        dt.Columns.Add("nomUM", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("precMN", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("precME", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("almacenDestino", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("almacenBack", GetType(Integer))
        dt.Columns.Add("cuentaHaber", GetType(String))
        dt.Columns.Add("utiMenor", GetType(Decimal))
        dt.Columns.Add("utiMayor", GetType(Decimal))
        dt.Columns.Add("utiGranMayor", GetType(Decimal))
        dt.Columns.Add("colModVenta", GetType(Boolean))
        dt.Columns.Add("valCheck", GetType(String))
        dt.Columns.Add("lote", GetType(String))
        dt.Columns.Add("fechaProd", GetType(DateTime))
        dt.Columns.Add("fechaVcto", GetType(DateTime))
        dt.Columns.Add("codigoLote", GetType(Integer))
        dt.Columns.Add("preciounitarioIGV", GetType(Decimal))
        Return dt
    End Function

    Private Sub AgregarItem(Lista As List(Of documentocompradetalle))
        Dim loteSA As New recursoCostoLoteSA
        For Each item In Lista
            Dim lote = loteSA.GetLoteByID(item.codigoLote)

            Me.dgvMov.Table.AddNewRecord.SetCurrent()
            Me.dgvMov.Table.AddNewRecord.BeginEdit()
            Me.dgvMov.Table.CurrentRecord.SetValue("id", 0)
            Me.dgvMov.Table.CurrentRecord.SetValue("Correccion", 3)
            Me.dgvMov.Table.CurrentRecord.SetValue("grav", item.destino)


            Me.dgvMov.Table.CurrentRecord.SetValue("idItem", item.idItem)
            Me.dgvMov.Table.CurrentRecord.SetValue("item", item.descripcionItem)
            Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", Nothing)
            Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", Nothing)
            Me.dgvMov.Table.CurrentRecord.SetValue("idUM", item.unidad1)
            Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", item.unidad1)
            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0.0)
            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0.0)
            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0.0)
            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0.0)
            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0.0)
            Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", String.Empty)
            Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", item.tipoExistencia)
            Me.dgvMov.Table.CurrentRecord.SetValue("estado", 0)
            Me.dgvMov.Table.CurrentRecord.SetValue("utiMenor", 0)
            Me.dgvMov.Table.CurrentRecord.SetValue("utiMayor", 0)
            Me.dgvMov.Table.CurrentRecord.SetValue("utiGranMayor", 0)
            Me.dgvMov.Table.CurrentRecord.SetValue("colModVenta", False)
            Me.dgvMov.Table.CurrentRecord.SetValue("valCheck", "N")
            Me.dgvMov.Table.CurrentRecord.SetValue("almacenDestino", item.almacenRef)
            Me.dgvMov.Table.CurrentRecord.SetValue("codigoLote", item.codigoLote)
            Me.dgvMov.Table.CurrentRecord.SetValue("lote", lote.nroLote)
            Me.dgvMov.Table.CurrentRecord.SetValue("preciounitarioIGV", 0)

            If lote.fechaVcto.HasValue Then
                Me.dgvMov.Table.CurrentRecord.SetValue("fechaVcto", lote.fechaVcto)
            End If
            If lote.fechaProduccion.HasValue Then
                Me.dgvMov.Table.CurrentRecord.SetValue("fechaProd", lote.fechaProduccion)
            End If
            Me.dgvMov.Table.AddNewRecord.EndEdit()
        Next
        dgvMov.TableDescriptor.Columns("almacenDestino").ReadOnly = True
        dgvMov.TableDescriptor.Columns("fechaProd").ReadOnly = True
        dgvMov.TableDescriptor.Columns("fechaVcto").ReadOnly = True
        dgvMov.TableDescriptor.Columns("lote").ReadOnly = True


        ToolStripButton3.Enabled = True
        txtBuscarProducto.Enabled = False
        cboAsignacion.Items.Clear()
        cboAsignacion.Items.Add("LOTE EXISTENTE")
        cboAsignacion.Text = "LOTE EXISTENTE"
    End Sub



    Dim listaSubCategoria As New List(Of item)
    Sub Productoshijos()

        Dim categoriaSA As New itemSA
        listaSubCategoria = categoriaSA.GetListaMarcaPadre(Val(txtCategoria.Tag))
        Label43.Text = listaSubCategoria.Count & " items"

        'Dim categoriaSA As New itemSA

        'cboProductos.DisplayMember = "descripcion"
        'cboProductos.ValueMember = "idItem"
        'cboProductos.DataSource = categoriaSA.GetListaMarcaPadre(CboClasificacion.SelectedValue)
    End Sub


    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub


    Private Sub ListaMercaderiasXIdHijo(iditem As Integer, tipo As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXIdHijo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, iditem, tipo)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub

    Public Function GetTableCuentas() As DataTable
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(String))
        dt.Columns.Add("nombre", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso TextPersona.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso TextPersona.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function


#Region "PERSONAS"
    Public Class Personal

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
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
    End Class
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



    'Sub clasificacion()
    '    Dim categoriaSA As New itemSA
    '    CboClasificacion.DisplayMember = "descripcion"
    '    CboClasificacion.ValueMember = "idItem"
    '    CboClasificacion.DataSource = categoriaSA.GetListaPadre()

    '    'CboClasificacion1.DisplayMember = "descripcion"
    '    'CboClasificacion1.ValueMember = "idItem"
    '    'CboClasificacion1.DataSource = categoriaSA.GetListaPadre()

    'End Sub
#End Region

#Region "PERSONA"
    Public Sub GrabarPersona()
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        With personaBE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idPersona = txtDniTrab.Text.Trim
            .nombres = txtNombreTrab.Text.Trim
            .appat = txtAppatTrab.Text.Trim
            .apmat = txtApmatTrab.Text.Trim
            .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
        End With
        personaSA.InsertPersona(personaBE)
        TextPersona.Tag = personaBE.idPersona
        TextPersona.Text = personaBE.nombreCompleto
        TextDNI.Text = personaBE.idPersona
        txtCuenta = "TR"

        lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    End Sub

    Private Sub ObtenerPersonaPorNombre(strPersona As String)
        Dim PersonaSA As New PersonaSA
        lstPersonas.Items.Clear()
        For Each i In PersonaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, strPersona)
            lstPersonas.Items.Add(New Personal(i.nombreCompleto, i.idPersona))
        Next
        lstPersonas.DisplayMember = "Name"
        lstPersonas.ValueMember = "Id"
    End Sub
#End Region

#Region "Métodos"
    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personalSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalSA

        Try
            lsvProveedor.Items.Clear()
            For Each i In personalSA.PersonalSelStartwithNombres(New Helios.Planilla.Business.Entity.Personal With {.Nombre = strBusqueda})
                Dim n As New ListViewItem(i.IDPersonal)
                n.SubItems.Add(i.FullName)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.Numerodocumento)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                TextPersona.Text = .nombreCompleto
                TextPersona.Tag = .idEntidad
                txtCuenta = .cuentaAsiento
                TextDNI.Text = .nrodoc
            End With
        Else
            TextPersona.Clear()
            TextPersona.Clear()
            txtCuenta = String.Empty
            TextDNI.Clear()
        End If
    End Sub

    Public Sub UbicarTrabPorDNI(strNumero As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, strNumero)
        If Not IsNothing(persona) Then
            With persona
                TextPersona.Text = .nombreCompleto
                TextPersona.Tag = .idPersona
                txtCuenta = "TR"
                TextDNI.Text = .idPersona
            End With
        End If
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

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
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

                If cboTipoDocumento.Text = "VOUCHER CONTABLE" Then
                    GConfiguracion.TipoComprobante = "9901" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDocumento.Text = "VOUCHER CONTABLE" Then
    '                            GConfiguracion.TipoComprobante = "9901" ' .tipo
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial

    '                        End If

    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion
    'End Function


    Public Sub CargarListas()
        Dim tablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        '   Dim entidadSA As New entidadSA
        Dim almacen As New List(Of almacen)
        Dim categoriaSA As New itemSA

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacen

        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")


        Dim tabla As New List(Of tabladetalle)
        Dim lista As New List(Of String)
        'lista.Add("0000")
        'lista.Add("01")
        lista.Add("02")

        lista.Add("03.01")
        lista.Add("03.02")
        lista.Add("05")
        lista.Add("07.01")
        lista.Add("08.01")
        lista.Add("09.01")
        lista.Add("10.02")
        lista.Add("10.03")
        lista.Add("10.04")
        lista.Add("10.06")
        lista.Add("10.07")
        lista.Add("16")
        lista.Add("99.01")
        lista.Add("99.07")
        lista.Add("9930")


        'lista.Add("04.01")
        'lista.Add("04.02")
        'lista.Add("06")
        'lista.Add("07.02")
        'lista.Add("08.02")
        'lista.Add("09.02")
        'lista.Add("10.01")
        'lista.Add("10.05")
        'lista.Add("11")
        'lista.Add("12")
        'lista.Add("13")
        'lista.Add("14")
        'lista.Add("15")
        'lista.Add("99.02")
        'lista.Add("99.09")

        tabla = tablaSA.GetListaTablaDetalle(12, "1")

        'Dim con = (From n In tabla _
        '           Where lista.Contains(n.codigoDetalle) _
        '          Select n).ToList

        cboOperacion.ValueMember = "codigoDetalle"
        cboOperacion.DisplayMember = "descripcion"
        cboOperacion.DataSource = tabla ' tablaSA.Ge


        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        'cboMoneda.SelectedValue = 1

        'lsvProveedor.Items.Clear()
        'For Each i As entidad In entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.PROVEEDOR, Gempresas.IdEmpresaRuc)
        '    Dim n As New ListViewItem(i.idEntidad)
        '    n.SubItems.Add(i.nombreCompleto)
        '    n.SubItems.Add(i.cuentaAsiento)
        '    n.SubItems.Add(i.nrodoc)
        '    lsvProveedor.Items.Add(n)
        'Next

        Dim listaTipoDoc As New List(Of String)
        listaTipoDoc.Add("9901")
        listaTipoDoc.Add("99")


        cboTipoDocumento.ValueMember = "codigoDetalle"
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.DataSource = tablaSA.GetListaTablaDetalleXusuario(10, "1", listaTipoDoc)
        cboTipoDocumento.Text = "VOUCHER CONTABLE"

        Dim dtUM As New DataTable
        dtUM.Columns.Add("ID")
        dtUM.Columns.Add("Name")

        Dim dtPresentacion As New DataTable
        dtPresentacion.Columns.Add("IDPres")
        dtPresentacion.Columns.Add("NamePres")

        For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
            'lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
            lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, 0.0, 0.0, 0.0))
        Next
        lstCategoria.DisplayMember = "Name"
        lstCategoria.ValueMember = "Id"
        '    lstCategoria.DataSource = categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)



        txtBuscarProducto.Visible = True
        btnNuevoProd.Visible = True

        Label6.Text = "Buscar item"
        txtCategoria.Visible = False
        PictureBox2.Visible = False
        Label42.Visible = False
        Label43.Visible = False

        Label35.Visible = False
        txtSubCategoria.Visible = False
        PictureBox1.Visible = False

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

        Dim queryResults = (From cust In datos
                            Where cust.AsientoID = id).First
        datos.Remove(queryResults)

        Dim ListaMov = (From n In datosMov
                        Where n.AsientoID = id).ToList

        For Each i In ListaMov
            datosMov.Remove(i)
        Next

        'lstAsientos.DataSource = Nothing
        'lstAsientos.DisplayMember = "NombreAsiento"
        'lstAsientos.ValueMember = "AsientoID"
        'lstAsientos.DataSource = datos

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub DeleteMovimientoID(id As Integer)

        Dim queryResults = (From cust In datosMov
                            Where cust.IdMovimiento = id).First
        datosMov.Remove(queryResults)

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub ubicarMovimientoporID(id As Integer)

        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = id).ToList

        'If queryResults.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        '    For Each I As Movimientos In queryResults
        '        If I.Tipo = "D" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, I.Importemn, I.Importeme, "0.00", "0.00", I.IdMovimiento)
        '        ElseIf I.Tipo = "H" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, "0.00", "0.00", I.Importemn, I.Importeme, I.IdMovimiento)
        '        End If

        '    Next
        '    lblEstado.Text = "Listado de movimientos"
        'Else
        '    dgvMovimiento.Rows.Clear()
        'End If


    End Sub


    Private Function ListarMovimientoporAsiento(id As Integer) As List(Of Movimientos)

        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = id).ToList


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosMN(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo
                            Select cust.Importemn).Sum


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosME(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo
                            Select cust.Importeme).Sum


        Return queryResults
    End Function
#End Region

#Region "ASIENTOS"
    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvMov.Table.Records
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
            objTotalesDet.idAlmacen = cboAlmacen.SelectedValue
            objTotalesDet.origenRecaudo = r.GetValue("grav")
            objTotalesDet.tipoCambio = txtTipoCambio.DecimalValue
            objTotalesDet.tipoExistencia = r.GetValue("tipoEx")
            objTotalesDet.idItem = r.GetValue("idItem")
            objTotalesDet.descripcion = r.GetValue("item")
            objTotalesDet.idUnidad = r.GetValue("idUM")
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(r.GetValue("cantidad"), Decimal)
            objTotalesDet.precioUnitarioCompra = CType(r.GetValue("precMN"), Decimal)
            objTotalesDet.importeSoles = CType(r.GetValue("importeMN"), Decimal)
            objTotalesDet.importeDolares = CType(r.GetValue("importeME"), Decimal)
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
        Next

        Return ListaTotales
    End Function

    Private Function ListaTotalesAlmacenOrigen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvMov.Table.Records
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
            objTotalesDet.idAlmacen = cboAlmacen.SelectedValue
            objTotalesDet.origenRecaudo = r.GetValue("grav")
            objTotalesDet.tipoCambio = txtTipoCambio.DecimalValue
            objTotalesDet.tipoExistencia = r.GetValue("tipoEx")
            objTotalesDet.idItem = r.GetValue("idItem")
            objTotalesDet.descripcion = r.GetValue("item")
            objTotalesDet.idUnidad = r.GetValue("idUM")
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(r.GetValue("cantidad"), Decimal) * -1
            objTotalesDet.precioUnitarioCompra = CType(r.GetValue("precMN"), Decimal) * -1
            objTotalesDet.importeSoles = CType(r.GetValue("importeMN"), Decimal) * -1
            objTotalesDet.importeDolares = CType(r.GetValue("importeME"), Decimal) * -1
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

    'Sub AsientoTransferenciaEntreAlmacenes()
    '    Dim listaMovimiento As New List(Of Movimientos)
    '    Dim asientoBL As New asiento
    '    Dim nMovimiento As New movimiento
    '    Dim mascaraSA As New mascaraContable2SA
    '    Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
    '    Try
    '        asientoBL = New asiento
    '        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
    '        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
    '        asientoBL.idEntidad = txtProveedor.ValueMember
    '        asientoBL.nombreEntidad = txtProveedor.Text
    '        asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '        asientoBL.fechaProceso = fecha
    '        asientoBL.codigoLibro = "13"
    '        asientoBL.tipo = "D"
    '        asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
    '        asientoBL.importeMN = CDec(lblTotalAdquisiones.Text)
    '        asientoBL.importeME = CDec(lblTotalUS.Text)
    '        asientoBL.glosa = Glosa()

    '        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
    '            nMovimiento = New movimiento
    '            If i.Cells(13).Value = "01" Then
    '                nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, i.Cells(14).Value).cuentaDestinoKardex
    '            Else
    '                nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, i.Cells(14).Value, i.Cells(13).Value).cuentaIngAlmacen
    '            End If
    '            nMovimiento.descripcion = i.Cells(3).Value
    '            nMovimiento.tipo = "D"
    '            nMovimiento.monto = CDec(i.Cells(10).Value)
    '            nMovimiento.montoUSD = CDec(i.Cells(11).Value)
    '            nMovimiento.usuarioActualizacion = "Jiuni"
    '            nMovimiento.fechaActualizacion = DateTime.Now
    '            asientoBL.movimiento.Add(nMovimiento)
    '            asientoBL.movimiento.Add(HaberTransferenciaMOv(i))
    '        Next
    '        ListaAsientonTransito.Add(asientoBL)
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '    End Try
    'End Sub

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

    Function HaberOtrasExistenciasMOv(r As Record) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        nMovimiento.cuenta = r.GetValue("cuentaHaber")
        nMovimiento.descripcion = r.GetValue("item")
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(r.GetValue("importeMN"))
        nMovimiento.montoUSD = CDec(r.GetValue("importeME"))
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
            asientoBL.periodo = lblPerido.Text
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(TextPersona.Tag)
            asientoBL.nombreEntidad = TextPersona.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
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
            asientoBL.periodo = lblPerido.Text
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(TextPersona.Tag)
            asientoBL.nombreEntidad = TextPersona.Text
            If RBProveedor.Checked = True Then
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf RBCliente.Checked = True Then
                asientoBL.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf RBOtros.Checked = True Then
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
            End If
            asientoBL.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = sumaMN
            asientoBL.importeME = sumaME
            asientoBL.glosa = txtGlosa.Text.Trim


            If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
                For Each r As Record In dgvMov.Table.Records
                    If r.GetValue("estado") <> Business.Entity.BaseBE.EntityAction.DELETE Then
                        nMovimiento = New movimiento
                        Select Case r.GetValue("tipoEx")
                            Case "01"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "02"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS02.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "03"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS03.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "04"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS04.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "05"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS05.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "06"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS06.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "07"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS07.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "08"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS08.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                        End Select
                        nMovimiento.descripcion = r.GetValue("item")
                        nMovimiento.tipo = "D"
                        nMovimiento.monto = CDec(r.GetValue("importeMN"))
                        nMovimiento.montoUSD = CDec(r.GetValue("importeME"))
                        nMovimiento.usuarioActualizacion = "Jiuni"
                        nMovimiento.fechaActualizacion = DateTime.Now
                        asientoBL.movimiento.Add(nMovimiento)
                        asientoBL.movimiento.Add(HaberOtrasExistenciasMOv(r))
                    End If
                Next
            End If
            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

#End Region

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
        Dim almacenSA As New almacenSA
        Dim personaSA As New PersonaSA
        Dim persona As New Persona
        Try
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)

            With objDoc.UbicarDocumento(intIdDocumento)
                Dim fecha = .fechaProceso
                TxtDia.Text = fecha.Day
                cboMesCompra.SelectedValue = String.Format("{0:00}", fecha.Month)
                cboAnio.Text = fecha.Year
                'txtFechaComprobante.Value = .fechaProceso
                cboOperacion.SelectedValue = .tipoOperacion
                'COMPROBANTE
                txtIdComprobante.Text = "99 - GUIA DE REMISION"
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                '     Dim fecha = .fechaDoc
                lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                lblIdDocumento.Text = .idDocumento
                '   txtFechaComprobante.Value = .fechaDoc
                lblPerido.Text = .fechaContable
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc

                If Not IsNothing(.idProveedor) Then
                    'PROVEEDOR
                    nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                    If nEntidad.tipoEntidad = "PR" Then
                        RBProveedor.Checked = True
                    Else
                        RBCliente.Checked = True
                    End If

                    TextDNI.Text = nEntidad.nrodoc
                    txtCuenta = nEntidad.cuentaAsiento
                    TextPersona.Tag = nEntidad.idEntidad
                    TextPersona.Text = nEntidad.nombreCompleto
                    TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                Else
                    RBOtros.Checked = True
                    Dim codPerson = .idPersona
                    persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, codPerson)
                    If Not IsNothing(persona) Then
                        TextDNI.Text = persona.idPersona
                        txtCuenta = "TR"
                        TextPersona.Tag = persona.idPersona
                        TextPersona.Text = persona.nombreCompleto
                        TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                End If


                txtGlosa.Text = .glosa
                '_::::::::::::::::::        :::::::::::::::::::
                txtTipoCambio.DecimalValue = .tcDolLoc

            End With


            'DETALLE DE LA COMPRA
            '   dgvNuevoDoc.Rows.Clear()
            '   Dim almacenDestino As Integer
            Dim precioUnitarioIva As Decimal = 0
            For Each i In objDocCompraDet.GetUbicarDetalleCompraLote(intIdDocumento)
                '   almacenDestino = i.almacenRef
                Me.dgvMov.Table.AddNewRecord.SetCurrent()
                Me.dgvMov.Table.AddNewRecord.BeginEdit()
                Me.dgvMov.Table.CurrentRecord.SetValue("id", i.secuencia)

                Dim valorCompra = i.importe
                Dim total As Decimal = 0

                If i.destino = 1 Then
                    total = Math.Round(CDec(valorCompra) * 0.18, 2)
                    total = Math.Round(CDec(total) + CDec(i.importe), 2)
                    precioUnitarioIva = Math.Round(total / i.monto1.GetValueOrDefault, 2)
                Else
                    total = valorCompra
                End If



                Me.dgvMov.Table.CurrentRecord.SetValue("grav", i.destino)
                dgvMov.Table.CurrentRecord.SetValue("Correccion", "3")
                Me.dgvMov.Table.CurrentRecord.SetValue("idItem", i.idItem)
                Me.dgvMov.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", i.unidad2)
                Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", String.Empty)
                Me.dgvMov.Table.CurrentRecord.SetValue("idUM", i.unidad1)
                Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", i.unidad1)
                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", i.importe / i.monto1.GetValueOrDefault)

                Me.dgvMov.Table.CurrentRecord.SetValue("preciounitarioIGV", precioUnitarioIva)



                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", total)
                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", i.importe)
                Me.dgvMov.Table.CurrentRecord.SetValue("precME", i.precioUnitarioUS)
                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", i.importeUS)
                Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", i.CuentaItem)
                Me.dgvMov.Table.CurrentRecord.SetValue("almacenDestino", i.almacenRef)
                Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", i.tipoExistencia)
                Me.dgvMov.Table.CurrentRecord.SetValue("estado", 1)
                Me.dgvMov.Table.CurrentRecord.SetValue("almacenBack", i.almacenRef)
                dgvMov.Table.CurrentRecord.SetValue("codigoLote", i.CustomRecursoCostoLote.codigoLote)
                Me.dgvMov.Table.CurrentRecord.SetValue("lote", i.CustomRecursoCostoLote.nroLote)
                Me.dgvMov.Table.CurrentRecord.SetValue("fechaProd", i.CustomRecursoCostoLote.fechaProduccion.GetValueOrDefault)
                If i.CustomRecursoCostoLote.fechaVcto.HasValue Then
                    Me.dgvMov.Table.CurrentRecord.SetValue("fechaVcto", i.CustomRecursoCostoLote.fechaVcto.GetValueOrDefault)
                End If
                Me.dgvMov.Table.AddNewRecord.EndEdit()
            Next
            ToolStripButton3.Visible = False
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

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
        Dim provSel As New entidad
        Dim ListaDetalle As New List(Of documentocompradetalle)

        dgvMov.TableControl.CurrentCell.EndEdit()
        dgvMov.TableControl.Table.TableDirty = True
        dgvMov.TableControl.Table.EndEdit()

        sumaMN = 0
        sumaME = 0

        If PanelIndentificacion.Visible = False Then
            provSel = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, Nothing, GEstableciento.IdEstablecimiento)
        End If

        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = cboTipoDocumento.SelectedValue  ' "99"
        ndocumento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) ' txtFechaComprobante.Value
        ndocumento.nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = "1"
        If PanelIndentificacion.Visible = False Then
            ndocumento.idEntidad = provSel.idEntidad
            ndocumento.entidad = "Varios"
            ndocumento.nrodocEntidad = "-"
            ndocumento.tipoEntidad = provSel.tipoEntidad
        Else
            ndocumento.idEntidad = Val(TextPersona.Tag)
            ndocumento.entidad = TextPersona.Text
            ndocumento.nrodocEntidad = TextDNI.Text

            If RBProveedor.Checked = True Then
                ndocumento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf RBCliente.Checked = True Then
                ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf RBOtros.Checked = True Then
                ndocumento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
        End If
        ndocumento.tipoOperacion = cboOperacion.SelectedValue
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now


        nDocumentoCompra = New documentocompra
        nDocumentoCompra.situacion = cboOperacion.SelectedValue
        nDocumentoCompra.idPadre = lblIdDocumento.Text
        nDocumentoCompra.codigoLibro = "13"
        nDocumentoCompra.tipoDoc = cboTipoDocumento.SelectedValue ' "99"
        nDocumentoCompra.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCompra.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCompra.fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        nDocumentoCompra.fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value ' PERIODO
        nDocumentoCompra.fechaContable = lblPerido.Text
        nDocumentoCompra.serie = txtSerie.Text.Trim
        nDocumentoCompra.numeroDoc = txtNumero.Text
        nDocumentoCompra.aprobado = "N"

        If PanelIndentificacion.Visible = False Then
            nDocumentoCompra.idProveedor = provSel.idEntidad
            nDocumentoCompra.nombreProveedor = "Varios"
        Else
            If RBProveedor.Checked = True Then
                nDocumentoCompra.idProveedor = CInt(TextPersona.Tag)
            ElseIf RBCliente.Checked = True Then
                nDocumentoCompra.idProveedor = CInt(TextPersona.Tag)
            ElseIf RBOtros.Checked = True Then
                nDocumentoCompra.idPersona = CInt(TextPersona.Tag)
            End If
            nDocumentoCompra.nombreProveedor = TextPersona.Text
        End If

        '.monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
        nDocumentoCompra.monedaDoc = "1"

        nDocumentoCompra.tasaIgv = 0 ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
        nDocumentoCompra.tcDolLoc = txtTipoCambio.DecimalValue
        nDocumentoCompra.tipoRecaudo = Nothing
        nDocumentoCompra.regimen = Nothing
        nDocumentoCompra.tasaRegimen = 0
        nDocumentoCompra.nroRegimen = Nothing

        nDocumentoCompra.importeTotal = sumaMN
        nDocumentoCompra.importeUS = sumaME

        nDocumentoCompra.destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
        nDocumentoCompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        nDocumentoCompra.glosa = txtGlosa.Text
        nDocumentoCompra.referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
        nDocumentoCompra.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
        ' .DocumentoSustentado = "S"
        nDocumentoCompra.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCompra.fechaActualizacion = DateTime.Now
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES
        Dim almacenSA As New almacenSA
        Dim costoSA As New recursoCostoLoteSA
        If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
            Dim precios As New List(Of configuracionPrecioProducto)
            For Each r As Record In dgvMov.Table.Records

                If ChPrecios.Checked = True Then
                    If r.GetValue("menor").ToString.Trim.Length > 0 Then

                        If Decimal.Parse(r.GetValue("menor")) > 0 Then
                            precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idItem")),
                            .idPrecio = 1,
                            .descripcion = "Precio por Menor",
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
                            .idproducto = Integer.Parse(r.GetValue("idItem")),
                            .idPrecio = 2,
                            .descripcion = "Precio por Mayor",
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
                            .idproducto = Integer.Parse(r.GetValue("idItem")),
                            .idPrecio = 3,
                            .descripcion = "Precio por Gran Mayor",
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
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                        Else
                            objDocumentoCompraDet.nrolote = CInt(txtSerie.Text.Trim) & "-" & CInt(txtNumero.Text.Trim)

                            objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                            objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = CInt(txtSerie.Text.Trim) & "-" & CInt(txtNumero.Text.Trim)
                            objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
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

                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.Serie = txtSerie.Text
                objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
                objDocumentoCompraDet.TipoDoc = cboTipoDocumento.SelectedValue ' "99"
                objDocumentoCompraDet.FlagModificaPrecioVenta = Nothing ' Me.dgvMov.Table.CurrentRecord.GetValue("valCheck")
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
                objDocumentoCompraDet.porcUtimenor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiMenor")
                objDocumentoCompraDet.porcUtimayor = 0 'Me.dgvMov.Table.CurrentRecord.GetValue("utiMayor")
                objDocumentoCompraDet.porcUtigranMayor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiGranMayor")
                objDocumentoCompraDet.TipoOperacion = cboOperacion.SelectedValue
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"

                If PanelIndentificacion.Visible = False Then
                    objDocumentoCompraDet.NombreProveedor = "Varios"
                Else
                    objDocumentoCompraDet.NombreProveedor = TextPersona.Text.Trim
                End If
                objDocumentoCompraDet.destino = r.GetValue("grav")
                objDocumentoCompraDet.idItem = r.GetValue("idItem")
                objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("idUM")

                'Select Case r.GetValue("Correccion")
                '    Case "1" ' CORREGIR IMPORTE
                '        If IsNumeric(r.GetValue("importeMN")) Then
                '            If CDec(r.GetValue("importeMN")) <= 0 Then
                '                MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                Me.Cursor = Cursors.Arrow
                '                Exit Sub
                '            End If
                '        End If

                '    Case "2" ' CORREGIR CANTIDAD
                '        If IsNumeric(r.GetValue("cantidad")) Then
                '            If CDec(r.GetValue("cantidad")) <= 0 Then
                '                MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                Me.Cursor = Cursors.Arrow
                '                Exit Sub
                '            End If
                '        End If


                '    Case "3" 'CORREGIR IMPORTE Y CANTIDAD
                '        If IsNumeric(r.GetValue("cantidad")) Then
                '            If CDec(r.GetValue("cantidad")) <= 0 Then
                '                MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                Me.Cursor = Cursors.Arrow
                '                Exit Sub
                '            End If
                '        End If

                '        If IsNumeric(r.GetValue("importeMN")) Then
                '            If CDec(r.GetValue("importeMN")) <= 0 Then
                '                MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                Me.Cursor = Cursors.Arrow
                '                Exit Sub
                '            End If
                '        End If

                '    Case Else
                '        If IsNumeric(r.GetValue("cantidad")) Then
                '            If CDec(r.GetValue("cantidad")) <= 0 Then
                '                MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                Me.Cursor = Cursors.Arrow
                '                Exit Sub
                '            End If
                '        End If

                '        If IsNumeric(r.GetValue("importeMN")) Then
                '            If CDec(r.GetValue("importeMN")) <= 0 Then
                '                MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                Me.Cursor = Cursors.Arrow
                '                Exit Sub
                '            End If
                '        End If
                'End Select

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If IsNumeric(r.GetValue("importeMN")) Then
                    If CDec(r.GetValue("importeMN")) <= 0 Then
                        MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If


                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoCompraDet.unidad2 = Nothing 'r.GetValue("idPrese") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = r.GetValue("nomPrese") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("precMN"))
                objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("precME"))

                Select Case r.GetValue("grav")
                    Case 1
                        objDocumentoCompraDet.importe = CType(r.GetValue("MontoBase"), Decimal)
                        objDocumentoCompraDet.importeUS = Math.Round(CDec(r.GetValue("MontoBase")) / TmpTipoCambio, 2)

                    Case Else
                        objDocumentoCompraDet.importe = CType(r.GetValue("importeMN"), Decimal)
                        objDocumentoCompraDet.importeUS = CType(r.GetValue("importeME"), Decimal)
                End Select
                sumaMN += CDec(r.GetValue("importeMN"))
                sumaME += CDec(r.GetValue("importeME"))


                objDocumentoCompraDet.FechaVcto = Nothing
                objDocumentoCompraDet.preEvento = Nothing
                objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
                objDocumentoCompraDet.almacenRef = cboAlmacen.SelectedValue
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoCompraDet)
            Next

        End If
        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveOtrasEntradasDefault(ndocumento, ListaTotales)
        Alert = New Alert("Entrada guardada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        Dispose()
    End Sub

    Sub GrabarVouCher()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim provSel As New entidad
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

        dgvMov.TableControl.CurrentCell.EndEdit()
        dgvMov.TableControl.Table.TableDirty = True
        dgvMov.TableControl.Table.EndEdit()

        sumaMN = 0
        sumaME = 0
        'ListaAsientonTransito = New List(Of asiento)

        If PanelIndentificacion.Visible = False Then
            provSel = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, Nothing, GEstableciento.IdEstablecimiento)
        End If

        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = cboTipoDocumento.SelectedValue  ' "99"
        ndocumento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) ' txtFechaComprobante.Value
        ndocumento.nroDoc = conf.Serie & "-" & conf.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = "1"
        If PanelIndentificacion.Visible = False Then
            ndocumento.idEntidad = provSel.idEntidad
            ndocumento.entidad = "Varios"
            ndocumento.nrodocEntidad = "-"
            ndocumento.tipoEntidad = provSel.tipoEntidad
        Else
            ndocumento.idEntidad = Val(TextPersona.Tag)
            ndocumento.entidad = TextPersona.Text
            ndocumento.nrodocEntidad = TextDNI.Text

            If RBProveedor.Checked = True Then
                ndocumento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf RBCliente.Checked = True Then
                ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf RBOtros.Checked = True Then
                ndocumento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
        End If
        ndocumento.tipoOperacion = cboOperacion.SelectedValue
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now



        nDocumentoCompra = New documentocompra
        nDocumentoCompra.situacion = cboOperacion.SelectedValue
        nDocumentoCompra.idPadre = lblIdDocumento.Text
        nDocumentoCompra.codigoLibro = "13"
        nDocumentoCompra.tipoDoc = cboTipoDocumento.SelectedValue ' "99"
        nDocumentoCompra.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCompra.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCompra.fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        nDocumentoCompra.fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value ' PERIODO
        nDocumentoCompra.fechaContable = lblPerido.Text
        nDocumentoCompra.serie = conf.Serie
        nDocumentoCompra.numeroDoc = conf.Serie
        nDocumentoCompra.aprobado = "N"
        If PanelIndentificacion.Visible = False Then
            nDocumentoCompra.idProveedor = provSel.idEntidad
            nDocumentoCompra.nombreProveedor = "Varios"
        Else
            If RBProveedor.Checked = True Then
                nDocumentoCompra.idProveedor = CInt(TextPersona.Tag)
            ElseIf RBCliente.Checked = True Then
                nDocumentoCompra.idProveedor = CInt(TextPersona.Tag)
            ElseIf RBOtros.Checked = True Then
                nDocumentoCompra.idPersona = CInt(TextPersona.Tag)
            End If
            nDocumentoCompra.nombreProveedor = TextPersona.Text
        End If
        nDocumentoCompra.monedaDoc = "1"
        nDocumentoCompra.tasaIgv = 0
        nDocumentoCompra.tcDolLoc = txtTipoCambio.DecimalValue
        nDocumentoCompra.tipoRecaudo = Nothing
        nDocumentoCompra.regimen = Nothing
        nDocumentoCompra.tasaRegimen = 0
        nDocumentoCompra.nroRegimen = Nothing
        nDocumentoCompra.importeTotal = sumaMN
        nDocumentoCompra.importeUS = sumaME
        nDocumentoCompra.destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
        nDocumentoCompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        nDocumentoCompra.glosa = txtGlosa.Text
        nDocumentoCompra.referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty
        nDocumentoCompra.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
        nDocumentoCompra.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCompra.fechaActualizacion = DateTime.Now
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES
        Dim almacenSA As New almacenSA
        Dim costoSA As New recursoCostoLoteSA
        If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
            Dim precios As New List(Of configuracionPrecioProducto)
            For Each r As Record In dgvMov.Table.Records

                If ChPrecios.Checked = True Then
                    If r.GetValue("menor").ToString.Trim.Length > 0 Then

                        If Decimal.Parse(r.GetValue("menor")) > 0 Then
                            precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idItem")),
                            .idPrecio = 1,
                            .descripcion = "Precio por Menor",
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
                            .idproducto = Integer.Parse(r.GetValue("idItem")),
                            .idPrecio = 2,
                            .descripcion = "Precio por Mayor",
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
                            .idproducto = Integer.Parse(r.GetValue("idItem")),
                            .idPrecio = 3,
                            .descripcion = "Precio por Gran Mayor",
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
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
                            objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                        Else
                            objDocumentoCompraDet.nrolote = CInt(conf.Serie) & "-" & CInt(conf.Serie)

                            objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                            objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = CInt(conf.Serie) & "-" & CInt(conf.Serie)
                            objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                            objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
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

                        Dim nroLotex = conf.Serie & "-" & conf.Serie
                        objDocumentoCompraDet.nrolote = nroLotex
                        objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                        objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                        objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = conf.Serie & "-" & conf.Serie
                        objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                        objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                        'objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = Nothing
                        'objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = Nothing
                End Select

                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.Serie = conf.Serie
                objDocumentoCompraDet.NumDoc = conf.Serie
                objDocumentoCompraDet.TipoDoc = cboTipoDocumento.SelectedValue ' "99"
                objDocumentoCompraDet.FlagModificaPrecioVenta = Nothing ' Me.dgvMov.Table.CurrentRecord.GetValue("valCheck")
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
                objDocumentoCompraDet.porcUtimenor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiMenor")
                objDocumentoCompraDet.porcUtimayor = 0 'Me.dgvMov.Table.CurrentRecord.GetValue("utiMayor")
                objDocumentoCompraDet.porcUtigranMayor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiGranMayor")
                objDocumentoCompraDet.TipoOperacion = cboOperacion.SelectedValue
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"
                If PanelIndentificacion.Visible = False Then
                    objDocumentoCompraDet.NombreProveedor = "Varios"
                Else
                    objDocumentoCompraDet.NombreProveedor = TextPersona.Text.Trim
                End If
                objDocumentoCompraDet.destino = r.GetValue("grav")
                objDocumentoCompraDet.idItem = r.GetValue("idItem")
                objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("idUM")

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If IsNumeric(r.GetValue("importeMN")) Then
                    If CDec(r.GetValue("importeMN")) <= 0 Then
                        MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If


                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoCompraDet.unidad2 = Nothing 'r.GetValue("idPrese") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = r.GetValue("nomPrese") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("precMN"))
                objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("precME"))

                Select Case r.GetValue("grav")
                    Case 1
                        objDocumentoCompraDet.importe = CType(r.GetValue("MontoBase"), Decimal)
                        objDocumentoCompraDet.importeUS = Math.Round(CDec(r.GetValue("MontoBase")) / TmpTipoCambio, 2)

                    Case Else
                        objDocumentoCompraDet.importe = CType(r.GetValue("importeMN"), Decimal)
                        objDocumentoCompraDet.importeUS = CType(r.GetValue("importeME"), Decimal)
                End Select
                sumaMN += CDec(r.GetValue("importeMN"))
                sumaME += CDec(r.GetValue("importeME"))


                objDocumentoCompraDet.FechaVcto = Nothing
                objDocumentoCompraDet.preEvento = Nothing
                objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
                objDocumentoCompraDet.almacenRef = cboAlmacen.SelectedValue
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoCompraDet)
            Next

        End If
        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveOtrasEntradasDefault(ndocumento, ListaTotales)
        Alert = New Alert("Entrada guardada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        Dispose()
    End Sub

    Sub EditarOE()
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

        sumaMN = 0
        sumaME = 0

        With ndocumento
            .idDocumento = Integer.Parse(lblIdDocumento.Text)
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = cboTipoDocumento.SelectedValue ' "99"
            .fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = "1"
            .idEntidad = Val(TextPersona.Tag)
            .entidad = TextPersona.Text
            .nrodocEntidad = TextDNI.Text
            If RBProveedor.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf RBCliente.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf RBOtros.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
            .tipoOperacion = cboOperacion.SelectedValue
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .situacion = cboOperacion.SelectedValue
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = cboTipoDocumento.SelectedValue ' "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value ' PERIODO
            .fechaContable = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .aprobado = "N"

            If RBProveedor.Checked = True Then
                .idProveedor = CInt(TextPersona.Tag)
            ElseIf RBCliente.Checked = True Then
                .idProveedor = CInt(TextPersona.Tag)
            ElseIf RBOtros.Checked = True Then
                .idPersona = CInt(TextPersona.Tag)
            End If

            .nombreProveedor = TextPersona.Text

            '.monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .monedaDoc = "1"

            .tasaIgv = 0 ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = sumaMN
            .importeUS = sumaME

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        '   GuiaRemision(ndocumento)

        If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
            For Each r As Record In dgvMov.Table.Records
                objDocumentoCompraDet = New documentocompradetalle
                objDocumentoCompraDet.idDocumento = lblIdDocumento.Text


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
                    objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
                    objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = 0
                    objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = CDate(r.GetValue("fechaProd"))
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = CDate(r.GetValue("fechaVcto"))

                End If

                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.Serie = txtSerie.Text
                objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
                objDocumentoCompraDet.TipoDoc = cboTipoDocumento.SelectedValue ' "99"
                objDocumentoCompraDet.FlagModificaPrecioVenta = Nothing ' Me.dgvMov.Table.CurrentRecord.GetValue("valCheck")
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
                objDocumentoCompraDet.porcUtimenor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiMenor")
                objDocumentoCompraDet.porcUtimayor = 0 'Me.dgvMov.Table.CurrentRecord.GetValue("utiMayor")
                objDocumentoCompraDet.porcUtigranMayor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiGranMayor")
                objDocumentoCompraDet.TipoOperacion = cboOperacion.SelectedValue
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"
                objDocumentoCompraDet.NombreProveedor = TextPersona.Text.Trim
                objDocumentoCompraDet.destino = r.GetValue("grav")
                objDocumentoCompraDet.idItem = r.GetValue("idItem")
                objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("idUM")

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If IsNumeric(r.GetValue("importeMN")) Then
                    If CDec(r.GetValue("importeMN")) <= 0 Then
                        MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoCompraDet.unidad2 = Nothing 'r.GetValue("idPrese") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = r.GetValue("nomPrese") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("precMN"))
                objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("precME"))
                objDocumentoCompraDet.importe = CType(r.GetValue("importeMN"), Decimal)
                objDocumentoCompraDet.importeUS = CType(r.GetValue("importeME"), Decimal)

                sumaMN += CDec(r.GetValue("importeMN"))
                sumaME += CDec(r.GetValue("importeME"))
                objDocumentoCompraDet.FechaVcto = Nothing
                objDocumentoCompraDet.preEvento = Nothing
                objDocumentoCompraDet.IdEstablecimiento = almacensa.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
                objDocumentoCompraDet.almacenRef = cboAlmacen.SelectedValue
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoCompraDet)

            Next
        End If

        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        CompraSA.EditarOtraEntrada(ndocumento)
        Alert = New Alert("Entrada modificada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        Dispose()
    End Sub

    'Public Sub TotalesCabeceras()
    '    Dim cTotalMN As Decimal = 0
    '    Dim cTotalME As Decimal = 0


    '    For Each r As Record In dgvMov.Table.Records
    '        If r.GetValue("estado") <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
    '            cTotalMN += CDec(r.GetValue("importeMN"))
    '            cTotalME += CDec(r.GetValue("importeME"))
    '        End If
    '    Next
    '    lblTotalAdquisiones.Text = cTotalMN.ToString("N2")
    '    lblTotalUS.Text = cTotalME.ToString("N2")

    'End Sub

    'Private Sub CellEndEditRefresh()
    '    Dim colDestinoGravado As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colCantidad As Decimal = 0
    '    Dim colPrecUnitUSD As Decimal = 0

    '    '**************************************************************
    '    If dgvNuevoDoc.Rows.Count > 0 Then
    '        'DECLARANDO VARIABLES

    '        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
    '            If i.Cells(12).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then

    '                colDestinoGravado = i.Cells(1).Value
    '                'DECLARANDO VARIABLES
    '                colPrecUnit = i.Cells(8).Value
    '                colPrecUnitUSD = i.Cells(9).Value

    '                If Not CStr(i.Cells(7).Value).Trim.Length > 0 Then
    '                    lblEstado.Text = "Ingrese una cantidad válida!"
    '                    lblEstado.Image = My.Resources.warning2
    '                    Exit Sub
    '                Else
    '                    colCantidad = i.Cells(7).Value
    '                End If

    '                Dim colMN As Decimal = 0
    '                colMN = Math.Round(colCantidad * colPrecUnit, 2)

    '                Dim colME As Decimal = 0
    '                colME = Math.Round(colCantidad * colPrecUnitUSD, 2)

    '                i.Cells(10).Value = colMN.ToString("N2")
    '                i.Cells(11).Value = colME.ToString("N2")

    '            End If

    '        Next
    '        TotalesCabeceras()
    '    Else
    '        TotalesCabeceras()
    '    End If


    'End Sub

    'Sub MostrarDetalle()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim objInsumo As GInsumo = GInsumo.InstanceSingle()
    '    Dim strAlmacen As String = Nothing
    '    objInsumo.Clear()
    '    With frmModalExistencia
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        '  lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count

    '        Select Case ManipulacionEstado
    '            Case ENTITY_ACTIONS.INSERT
    '                If Not IsNothing(objInsumo.descripcionItem) Then
    '                    dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
    '                                         objInsumo.presentacion,
    '                                             objInsumo.Nombrepresentacion,
    '                                             objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU,
    '                                             objInsumo.PU, objInsumo.Total, objInsumo.Total,
    '                                             Business.Entity.BaseBE.EntityAction.INSERT,
    '                                          objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
    '                                          cboAlmacen.ValueMember, cboAlmacen.Text, txtEstablecimiento.ValueMember)
    '                End If
    '            Case ENTITY_ACTIONS.UPDATE
    '                If Not IsNothing(objInsumo.descripcionItem) Then
    '                    dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
    '                                         objInsumo.presentacion,
    '                                             objInsumo.Nombrepresentacion,
    '                                             objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU,
    '                                             objInsumo.PU, objInsumo.Total, objInsumo.Total,
    '                                             Business.Entity.BaseBE.EntityAction.INSERT,
    '                                          objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
    '                                          Nothing, "Asignar almacén", txtEstablecimiento.ValueMember)
    '                End If
    '        End Select


    '        If dgvNuevoDoc.Rows.Count > 0 Then
    '            CellEndEditRefresh()
    '        End If

    '        If dgvNuevoDoc.Visible Then
    '            If dgvNuevoDoc.Rows.Count > 0 Then
    '                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(dgvNuevoDoc.Rows.Count - 1).Cells(5)
    '                Me.dgvNuevoDoc.BeginEdit(True)
    '            End If
    '        Else
    '            'If dgvSinControl.Rows.Count > 0 Then
    '            '    Me.dgvSinControl.CurrentCell = Me.dgvSinControl.Rows(dgvSinControl.Rows.Count - 1).Cells(10)
    '            '    Me.dgvSinControl.BeginEdit(True)
    '            'End If
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub
#End Region

#Region "PRODUCTOS"
    'Public Sub EditarItemEstablec(ByVal mat As ItemDS)
    '    Dim objitem As New detalleitems
    '    Dim itemSA As New detalleitemsSA
    '    Try
    '        'Se asigna cada uno de los datos registrados
    '        objitem.codigodetalle = txtCodigo.Text
    '        objitem.idItem = mat.Clasificacion   ' Trim(txtCodigoDocumento.Text)
    '        objitem.idEmpresa = Gempresas.IdEmpresaRuc
    '        objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
    '        objitem.cuenta = mat.Cuenta
    '        objitem.descripcionItem = mat.DescripcionItem
    '        objitem.presentacion = mat.Presentacion
    '        objitem.unidad1 = mat.UnidadMedida
    '        ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
    '        objitem.tipoExistencia = mat.TipoEx
    '        objitem.origenProducto = IIf(rbAfecta.Checked = True, "1", "2")
    '        objitem.tipoProducto = "I"

    '        objitem.usuarioActualizacion = "Jiuni"
    '        objitem.fechaActualizacion = DateTime.Now

    '        itemSA.UpdateProducto(objitem)
    '        Me.lblEstado.Image = My.Resources.ok4
    '        Me.lblEstado.Text = "Item actualizado!"
    '    Catch ex As Exception
    '        'Manejo de errores
    '        MsgBox("No se pudo grabar el Producto." & vbCrLf & ex.Message)
    '    End Try
    'End Sub
#End Region

    Private Sub frmMovOtrasEntradas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        threadEntidades.Abort()
    End Sub

    Dim comboTablec As New DataTable

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function
    Dim comboTableh As New DataTable

    Private Function comboTableCO() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr3 As DataRow = dt.NewRow()
        dr3(0) = "3"
        dr3(1) = "CORREGIR IMPORTE CANTIDAD"
        dt.Rows.Add(dr3)

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "CORREGIR IMPORTE"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "CORREGIR CANTIDAD"
        dt.Rows.Add(dr2)



        Return dt
    End Function




    Private comboTableCOR As DataTable
    Private Sub frmMovOtrasEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTableAlmacen2()

        Me.dgvMov.Engine.CounterLogic = EngineCounters.FilteredRecords
        comboTableCuentas = Me.GetTableCuentas
        comboTable = Me.GetTableAlmacen
        comboTableCOR = Me.comboTableCO

        Dim ggcStylec As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("Correccion").Appearance.AnyRecordFieldCell
        ggcStylec.CellType = "ComboBox"
        ggcStylec.DataSource = Me.comboTableCOR
        ggcStylec.ValueMember = "id"
        ggcStylec.DisplayMember = "name"

        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("almacenDestino").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"

        Dim ggcStyle1 As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("cuentaHaber").Appearance.AnyRecordFieldCell
        ggcStyle1.CellType = "ComboBox"
        ggcStyle1.DataSource = Me.comboTableCuentas
        ggcStyle1.ValueMember = "idCuenta"
        ggcStyle1.DisplayMember = "nombre"
        dgvMov.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        dgvMov.TableDescriptor.Columns("nomPrese").Width = 0
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs)
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
            End If
        Catch ex As Exception
            txtSerie.Clear()
        End Try

    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            TextPersona.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs)
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
            End If
        Catch ex As Exception
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub txtAlmacenDestino_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Focus()
        End If
    End Sub

    Private Sub ButtonCategoria_Click(sender As Object, e As EventArgs) Handles ButtonCategoria.Click
        'Me.PopupControlContainer2.Font = New Font("Tahoma", 8)
        'Me.PopupControlContainer2.Size = New Size(238, 110)
        'Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        'Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Dim colIdItem As Integer

        colIdItem = intIdItem

        For Each i In dgvMov.Table.Records
            If colIdItem = i.GetValue("idItem") Then
                Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
            End If
        Next
    End Sub
    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick

        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        Try
            If lsvListadoItems.SelectedItems.Count > 0 Then
                Dim selFila As ListViewItem = lsvListadoItems.SelectedItems(0)
                ValidarItemsDuplicados(Val(selFila.SubItems(0).Text))


                'With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))

                Me.dgvMov.Table.AddNewRecord.SetCurrent()
                Me.dgvMov.Table.AddNewRecord.BeginEdit()
                Me.dgvMov.Table.CurrentRecord.SetValue("id", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Correccion", 3)
                Me.dgvMov.Table.CurrentRecord.SetValue("grav", CStr(selFila.SubItems(4).Text))


                Me.dgvMov.Table.CurrentRecord.SetValue("idItem", CInt(selFila.SubItems(0).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("item", CStr(selFila.SubItems(1).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", CStr(selFila.SubItems(8).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", CStr(selFila.SubItems(8).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("idUM", CStr(selFila.SubItems(2).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", CStr(selFila.SubItems(2).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0.0)
                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0.0)
                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0.0)
                Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0.0)
                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0.0)
                Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", String.Empty)
                Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", CStr(selFila.SubItems(3).Text))
                Me.dgvMov.Table.CurrentRecord.SetValue("estado", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("utiMenor", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("utiMayor", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("utiGranMayor", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("colModVenta", False)
                Me.dgvMov.Table.CurrentRecord.SetValue("valCheck", "N")
                Me.dgvMov.Table.CurrentRecord.SetValue("almacenDestino", cboAlmacen.SelectedValue)
                Me.dgvMov.Table.CurrentRecord.SetValue("fechaVcto", Date.Now)
                Me.dgvMov.Table.CurrentRecord.SetValue("fechaProd", Date.Now)
                Me.dgvMov.Table.CurrentRecord.SetValue("precioUnitSinIva", 0)

                Me.dgvMov.Table.AddNewRecord.EndEdit()
                'End With
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs)
        'If dgvNuevoDoc.Rows.Count > 0 Then
        '    CellEndEditRefresh()
        'End If
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub btmGrabarClasificacion_Click(sender As Object, e As EventArgs)
        'If Not txtNewClasificacion.Text.Trim.Length > 0 Then
        '    lblEstado.Text = "Ingrese el nombre de la clasificación"
        '    pcClasificacion.Font = New Font("Tahoma", 8)
        '    pcClasificacion.Size = New Size(318, 102)
        '    Me.pcClasificacion.ParentControl = Me.txtCategoria
        '    Me.pcClasificacion.ShowPopup(Point.Empty)
        '    txtNewClasificacion.Select()
        '    Exit Sub
        'End If
        ''If Not nupUtilidad.Value > 0 Then
        ''    lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
        ''    pcClasificacion.Font = New Font("Tahoma", 8)
        ''    pcClasificacion.Size = New Size(318, 102)
        ''    Me.pcClasificacion.ParentControl = Me.txtCategoria
        ''    Me.pcClasificacion.ShowPopup(Point.Empty)
        ''    nupUtilidad.Select()
        ''    Exit Sub
        ''End If
        ''If Not nupUtilidadMayor.Value > 0 Then
        ''    lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
        ''    pcClasificacion.Font = New Font("Tahoma", 8)
        ''    pcClasificacion.Size = New Size(318, 102)
        ''    Me.pcClasificacion.ParentControl = Me.txtCategoria
        ''    Me.pcClasificacion.ShowPopup(Point.Empty)
        ''    nupUtilidadMayor.Select()
        ''    Exit Sub
        ''End If
        ''If Not nupUtilidadGranMayor.Value > 0 Then
        ''    lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
        ''    pcClasificacion.Font = New Font("Tahoma", 8)
        ''    pcClasificacion.Size = New Size(318, 102)
        ''    Me.pcClasificacion.ParentControl = Me.txtCategoria
        ''    Me.pcClasificacion.ShowPopup(Point.Empty)
        ''    nupUtilidadGranMayor.Select()
        ''    Exit Sub
        ''End If
        'btmGrabarClasificacion.Tag = "G"
        'Me.pcClasificacion.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnGrabTRab_Click(sender As Object, e As EventArgs) Handles btnGrabTRab.Click
        If Not txtDniTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.TextPersona
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtDniTrab.Select()
            Exit Sub
        End If

        If Not txtNombreTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.TextPersona
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtNombreTrab.Select()
            Exit Sub
        End If

        If Not txtAppatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.TextPersona
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtAppatTrab.Select()
            Exit Sub
        End If

        If Not txtApmatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.TextPersona
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtApmatTrab.Select()
            Exit Sub
        End If

        btnGrabTRab.Tag = "G"
        Me.pcTrabajador.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcTrabajador.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcTrabajador_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcTrabajador.BeforePopup
        Me.pcTrabajador.BackColor = Color.White
    End Sub

    Private Sub pcTrabajador_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcTrabajador.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDniTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.TextPersona
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtDniTrab.Select()
                Exit Sub
            End If

            If Not txtNombreTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.TextPersona
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtNombreTrab.Select()
                Exit Sub
            End If

            If Not txtAppatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.TextPersona
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtAppatTrab.Select()
                Exit Sub
            End If

            If Not txtApmatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.TextPersona
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtApmatTrab.Select()
                Exit Sub
            End If

            If btnGrabTRab.Tag = "G" Then
                GrabarPersona()
                btnGrabTRab.Tag = "N"
            Else
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.TextPersona
                Me.pcTrabajador.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextPersona.Focus()
        End If
    End Sub

    Private Sub pcPersonas_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcPersonas.BeforePopup
        Me.pcPersonas.BackColor = Color.White
    End Sub

    Private Sub pcPersonas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcPersonas.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstPersonas.SelectedItems.Count > 0 Then
                Me.TextPersona.Tag = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
                TextPersona.Text = lstPersonas.Text
                txtCuenta = "TR"
                TextDNI.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextPersona.Focus()
        End If
    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        If lstPersonas.SelectedItems.Count > 0 Then
            Me.pcPersonas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        If txtFiltroTrab.Text.Trim.Length > 0 Then
            ObtenerPersonaPorNombre(txtFiltroTrab.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub PopupControlContainer2_Popup(sender As Object, e As EventArgs) Handles PopupControlContainer2.Popup
        lstCategoria.Focus()
    End Sub

    Private Sub dgvMov_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvMov.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "colModVenta" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub dgvMov_TableControlCurrentCellEditingComplete(sender As Object, e As Grid.Grouping.GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellEditingComplete

    End Sub

    Private Sub dgvMov_QueryCellStyleInfo(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "colModVenta" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If
        e.Handled = True
        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.LightYellow
                e.Style.Format = "##.00"
            End If
            If e.TableCellIdentity.Column.MappingName = "importeMN" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.LightYellow
                e.Style.Format = "S/.##.00"
            End If
            If e.TableCellIdentity.Column.MappingName = "almacenDestino" Then
                e.Style.BackColor = Color.LightYellow
            End If
            If e.TableCellIdentity.Column.MappingName = "Correccion" Then
                e.Style.BackColor = Color.LightYellow
            End If
        End If


        'If Not IsNothing(e.TableCellIdentity.Column) Then
        '    Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "almacenDestino")) Then
        '        e.Style.Enabled = False
        '    ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "precMN")) Then
        '        Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 8).CellValue
        '        If CInt(str) = 0 Then
        '            e.Style.CellValue = 0
        '        End If
        '    End If
        'End If


        'If Not IsNothing(e.TableCellIdentity.Column) Then
        '    Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then

        '        Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
        '        If Not IsNothing(str) Then
        '            Select Case str
        '                Case "3" '  "DEVOLUCION DE EXISTENCIAS"
        '                    e.Style.[ReadOnly] = False
        '                    ''e.Style.BackColor = Color.AliceBlue
        '                    '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing


        '                Case "1" ' "DISMINUIR CANTIDAD"
        '                    e.Style.[ReadOnly] = True
        '                    'e.Style.BackColor = Color.AliceBlue

        '                    If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
        '                        Dim decg As Decimal
        '                        Dim tipocam = txtTipoCambio.Text
        '                        decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
        '                    Else
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                    End If


        '                Case "2" '"DISMINUIR IMPORTE"
        '                    e.Style.[ReadOnly] = False

        '                    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then

        '                        'Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

        '                    End If

        '            End Select
        '        End If


        '    ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importeMN")) Then
        '        Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
        '        If Not IsNothing(str) Then
        '            Select Case str
        '                Case "3" '  "DEVOLUCION DE EXISTENCIAS"
        '                    e.Style.[ReadOnly] = False
        '                    'e.Style.BackColor = Color.AliceBlue
        '                    '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
        '                Case "1" ' "DISMINUIR CANTIDAD"
        '                    e.Style.[ReadOnly] = False
        '                    'e.Style.BackColor = Color.AliceBlue

        '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                    'Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


        '                Case "2" '"DISMINUIR IMPORTE"
        '                    e.Style.[ReadOnly] = True
        '                    'e.Style.BackColor = Color.AliceBlue
        '            End Select
        '        End If


        '    Else
        '        'e.Style.[ReadOnly] = False
        '    End If
        'End If




    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ProductoXcodigoBarra(codigobarra As String)
        Dim existenciaSA As New detalleitemsSA
        Dim objeto As New detalleitems
        lsvListadoItems.Items.Clear()
        Try
            objeto = existenciaSA.GetUbicarProductoXcodigoBarra(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, codigobarra)

            If Not IsNothing(objeto) Then
                Dim n As New ListViewItem(objeto.codigodetalle)
                n.SubItems.Add((objeto.descripcionItem))
                n.SubItems.Add(objeto.unidad1)
                n.SubItems.Add(objeto.tipoExistencia)
                n.SubItems.Add(objeto.origenProducto)
                n.SubItems.Add(objeto.codigo)
                n.SubItems.Add(0)
                n.SubItems.Add(objeto.cuenta)
                n.SubItems.Add(objeto.presentacion)
                lsvListadoItems.Items.Add(n)
            Else

            End If
        Catch ex As Exception

            MessageBox.Show("No se encontro el producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda).Where(Function(o) o.estado <> "I").ToList
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(String.Format("{0}-{1}", i.descripcionItem, i.NomMarca))
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(i.codigo)
            n.SubItems.Add(i.NomMarca)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub


    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv3_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        'Me.Cursor = Cursors.WaitCursor
        'If txtCategoria.Text.Trim.Length > 0 Then
        '    ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvMov.TableControlCurrentCellChanging
        'Dim cc As GridCurrentCell = e.TableControl.CurrentCell
        'If cc.Renderer.CurrentStyle.CellType = "CheckBox" Then
        '    Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
        '    If s = "True" Then
        '        MsgBox(False)
        '    Else
        '        MsgBox(True)
        '    End If
        '    '   e.TableControl.Table.EndEdit()
        'End If
    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "cantidad" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value

                    ' Dim colCantidad = value 'CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"))
                    Dim precioUnitSinIva = Me.dgvMov.Table.CurrentRecord.GetValue("preciounitarioIGV")
                    If precioUnitSinIva.ToString.Trim.Length > 0 Then

                    Else
                        precioUnitSinIva = 0
                    End If
                    Dim colImporteMN = value * precioUnitSinIva
                    Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18) ' value * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precMN"))

                    Dim colImporteME = Math.Round(CDec(colBaseImp) / txtTipoCambio.DecimalValue, 2)
                    If colImporteMN > 0 AndAlso value > 0 Then
                        Dim colPUmn As Decimal =
                                Math.Round(CDec(colBaseImp) / value, 2)
                        Dim colPUme As Decimal = Math.Round(value / txtTipoCambio.DecimalValue, 2)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
                        Me.dgvMov.Table.CurrentRecord.SetValue("preciounitarioIGV", Math.Round(CDec(colImporteMN) / value, 2))
                    End If
                End If
            ElseIf style.TableCellIdentity.Column.Name = "importeMN" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value

                    Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
                    Dim colImporteMN = value ' Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
                    Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
                    Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
                    Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
                    If colImporteMN > 0 AndAlso colCantidad > 0 Then
                        Dim colPUmn As Decimal =
                                Math.Round(
                                Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
                        Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
                        Me.dgvMov.Table.CurrentRecord.SetValue("preciounitarioIGV", Math.Round(colImporteMN / colCantidad, 2))
                    End If
                End If
            ElseIf style.TableCellIdentity.Column.Name = "preciounitarioIGV" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value

                    Dim colCantidad = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"))
                    Dim colImporteMN = colCantidad * value 'incluiod igv
                    Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18) 'base imponible
                    '        colImporteMN = colImporteMN + colBaseImp
                    Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
                    Dim colImporteME = Math.Round(CDec(colImporteMN) / txtTipoCambio.DecimalValue, 2)
                    If colImporteMN > 0 AndAlso colCantidad > 0 Then
                        Dim precioUnitarioSinIva = Math.Round(CDec(colBaseImp) / colCantidad, 2)
                        Dim colPUme As Decimal = Math.Round(precioUnitarioSinIva / txtTipoCambio.DecimalValue, 2)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", precioUnitarioSinIva.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
                    End If
                End If

            ElseIf style.TableCellIdentity.Column.Name = "precMN" Then

                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value

                    Dim colCantidad = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"))
                    Dim colBaseImp As Decimal? = value * colCantidad ' CalculoBaseImponible(colImporteMN, 1.18)
                    Dim colImporteMN = colBaseImp * 0.18
                    colImporteMN = colImporteMN + colBaseImp
                    Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
                    Dim colImporteME = Math.Round(CDec(colImporteMN) / txtTipoCambio.DecimalValue, 2)
                    If colImporteMN > 0 AndAlso colCantidad > 0 Then
                        'Dim colPUmn As Decimal =
                        '        Math.Round(
                        '        Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
                        Dim colPUme As Decimal = Math.Round(value / txtTipoCambio.DecimalValue, 2)
                        'Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
                    End If
                End If
            End If


            '    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            '    If cc.ColIndex = 6 Or cc.ColIndex = 8 Then

            '        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
            '            Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
            '            Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
            '            Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
            '            Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
            '            If colImporteMN > 0 AndAlso colCantidad > 0 Then
            '                Dim colPUmn As Decimal =
            '                    Math.Round(
            '                    Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
            '                Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
            '                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
            '                Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
            '                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
            '            End If


            '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

            '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

            '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


            '            ''If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
            '            ''    Dim decg As Decimal
            '            ''    Dim tipocam = txtTipoCambio.Text
            '            ''    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
            '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
            '            ''Else
            '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
            '            ''End If


            '            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)

            '        End If

            '    ElseIf cc.ColIndex = 7 Then
            '        Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
            '        Dim colPrecioUnitario = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
            '        Dim colImporteMN = colCantidad * colPrecioUnitario
            '        Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
            '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
            '        Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
            '        If colImporteMN > 0 AndAlso colCantidad > 0 Then
            '            Dim colPUmn As Decimal = colPrecioUnitario
            '            Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
            '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
            '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
            '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
            '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
            '        End If

            '    ElseIf cc.ColIndex = 1 Then

            '        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
            '        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
            '        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
            '        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
            '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
            '        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
            '    End If

            '    'Select Case ColIndex
            '    '    Case 6
            '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 8, GridSetCurrentCellOptions.SetFocus)

            '    '    Case 8
            '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 11, GridSetCurrentCellOptions.SetFocus)
            '    'End Select
            'End If
        End If
    End Sub
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvMov_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCheckBoxClick
        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        Try
            If RowIndex2 > -1 Then
                Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                If style.Enabled Then
                    Dim column As Integer = Me.dgvMov.TableModel.NameToColIndex("colModVenta")
                    ' Console.WriteLine("CheckBoxClicked")
                    '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                    If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                        chk = CBool(Me.dgvMov.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                        e.TableControl.BeginUpdate()

                        e.TableControl.EndUpdate(True)
                    End If
                    If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "colModVenta" Then
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
                            Me.dgvMov.TableModel(RowIndex, 14).CellValue = "N" ' curStatus
                            '   Me.dgvMov.Table.CurrentRecord.SetValue("colModVenta", False)
                        Else
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex
                            '     MsgBox(True)
                            Me.dgvMov.TableModel(RowIndex, 14).CellValue = "S"
                        End If
                        e.TableControl.EndUpdate()
                        If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                        ElseIf Not ht.Contains(curStatus) Then
                        End If
                        ht.Clear()
                    End If
                End If

                Me.dgvMov.TableControl.Refresh()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Try

            If TxtDia.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la fecha de envío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDia.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de serie!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            Select Case cboTipoDocumento.Text
                Case "GUIA DE REMISION - REMITENTE"
                    If Not txtNumero.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de guía de remisión!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Case "VOUCHER CONTABLE"

            End Select

            If PanelIndentificacion.Visible = True Then
                Dim codProv = TextPersona.Tag
                If IsNothing(codProv) Then
                    lblEstado.Text = "Ingrese el personal!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not codProv.ToString.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el personal!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If



            If Not txtGlosa.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el detalle de la operación!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                txtGlosa.Select()
                Exit Sub
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fechaEnvio = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaEnvio.Year, .mes = fechaEnvio.Month})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If


                    If MessageBox.Show("Desea realizar la operación de entrada con fecha: " & vbCrLf &
                                               fechaEnvio, "Verifique la fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Select Case cboTipoDocumento.Text
                            Case "GUIA DE REMISION - REMITENTE"
                                GrabarDefault()
                            Case "VOUCHER CONTABLE"
                                GrabarVouCher()
                        End Select

                    End If


                Else

                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    Me.Cursor = Cursors.Arrow
                End If

            Else

                If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaEnvio.Year, .mes = fechaEnvio.Month})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                    If MessageBox.Show("Desea realizar la operación de entrada con fecha: " & vbCrLf &
                                               fechaEnvio, "Verifique la fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        EditarOE()
                    End If

                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub AgregarAsientoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'RegistrarAsientos()
    End Sub



    Private Sub dgvAsiento_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub




    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then
        '    RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        '    RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        'End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        'If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
        '    Dim rec As Record = dgvCompra.Table.CurrentRecord
        '    Dim consulta = (From n In ListaMovimientos _
        '                   Where n.idmovimiento = rec.GetValue("id")).First

        '    If Not IsNothing(consulta) Then
        '        ListaMovimientos.Remove(consulta)
        '        Me.dgvCompra.Table.CurrentRecord.Delete()
        '    End If
        'End If
        'lstAsiento_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub lstAsiento_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then


        '    RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        '    UbicarAsientoPorId(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        'End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then
        '    Dim consulta = (From n In ListaMovimientos _
        '                   Where n.idAsiento = lstAsiento.SelectedValue).ToList

        '    If consulta.Count > 0 Then

        '        Dim f As New frmViewAsiento(consulta)
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    'Select Case ColIndex
        '    '    Case 4
        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

        '    '        'Case 7
        '    '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
        '    'End Select

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 2 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 4 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 7 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If

        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs)
        'Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell

        ''Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        'If cc.ColIndex = 1 Then
        '    cc.ConfirmChanges()
        '    ' Me.dgvCompra.TableModel(cc.RowIndex, cc.ColIndex + 1).CellValue = "Hai"
        '    '  updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    Dim str = Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue
        '    If str = "H" Then
        '        Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "D"
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    Else
        '        Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "H"
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
        'If cc.ColIndex = 3 Then

        '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        'End If
        'If cc.ColIndex = 2 Then

        '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        'End If

        ''Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        ''If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        ''    If ColIndex = 1 Then
        ''        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        ''    End If
        ''    If ColIndex = 3 Then
        ''        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        ''    End If
        ''End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    'Select Case ColIndex
        '    '    Case 4
        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

        '    '        'Case 7
        '    '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
        '    'End Select

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 2 Then

        '        Dim cuentaSA As New cuentaplanContableEmpresaSA

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)

        '        'Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta"))
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 4 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 7 Then

        '        Dim colMN As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")
        '        Dim cant As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("cant")
        '        Dim colPUMN As Decimal = Math.Round(colMN / cant, 2).ToString("N2")

        '        Dim colPUME As Decimal = Math.Round(colMN / txtTipoCambio.DecimalValue, 2).ToString("N2")
        '        Dim colME As Decimal = Math.Round(colPUME / cant, 2).ToString("N2")

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", colME)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPUME)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPUMN)


        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    'If ColIndex = 3 Then
        '    '    Dim importeDebeME As Decimal = 0

        '    '    If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
        '    '        importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        '    '    End If

        '    'End If
        '    'If ColIndex = 4 Then
        '    '    Dim importeHaberME As Decimal = 0

        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
        '    '    importeHaberME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")

        '    'End If
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 6 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs)
        'updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        'RegistrarAsientos()


    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        'Dim consulta = (From n In ListaAsientonTransito _
        '         Where n.idAsiento = lstAsiento.SelectedValue).FirstOrDefault


        'If Not IsNothing(consulta) Then
        '    Dim listaMov = (From i In ListaMovimientos _
        '                   Where i.idAsiento = lstAsiento.SelectedValue).ToList

        '    For Each obj In listaMov
        '        ListaMovimientos.Remove(obj)
        '    Next
        '    ListaAsientonTransito.Remove(consulta)
        '    GetasientosListbox()
        '    lstAsiento_SelectedIndexChanged(sender, e)
        'End If
    End Sub


    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtNumero_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            TextPersona.Focus()
            TextPersona.SelectAll()
        End If
    End Sub

    Private Sub txtNumero_LostFocus1(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
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
    End Sub

    Private Sub txtNumero_TextChanged_1(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub
    'Sub updateGlosaAsiento(asiento As asiento)
    '    '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '    Try
    '        Dim consulta = (From n In ListaAsientonTransito _
    '                   Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '        If Not IsNothing(consulta) Then
    '            consulta.glosa = txtGlosaAsiento.Text.Trim
    '        End If

    '        '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '    Catch ex As Exception
    '        MessageBoxAdv.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then
        '    If txtGlosaAsiento.Text.Trim.Length > 0 Then
        '        updateGlosaAsiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        '        lstAsiento_SelectedIndexChanged(sender, e)
        '    End If
        'Else
        '    lblEstado.Text = "Debe seleccionar un asiento!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    'Private Sub txtFechaComprobante_ValueChanged(sender As Object, e As EventArgs)
    '    If IsDate(txtFechaComprobante.Value) Then
    '        If txtFechaComprobante.Value.Date > DiaLaboral.Date Then
    '            txtFechaComprobante.Value = DiaLaboral
    '            MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End If
    'End Sub


    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles TextPersona.TextChanged
        TextPersona.ForeColor = Color.Black
        TextPersona.Tag = Nothing
        If TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextDNI.Visible = True
        Else
            TextDNI.Visible = False
        End If
    End Sub

    Sub TipoCambio()
        For Each r As Record In dgvMov.Table.Records
            If r.GetValue("Correccion") = "3" Then
                Dim colCantidad = r.GetValue("cantidad")
                Dim colImporteMN = r.GetValue("importeMN")
                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
                If colImporteMN > 0 AndAlso colCantidad > 0 Then
                    Dim colPUmn As Decimal = Math.Round(colImporteMN / colCantidad, 2)
                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
                    r.SetValue("precMN", colPUmn.ToString("N2"))
                    r.SetValue("precME", colPUme.ToString("N2"))
                    r.SetValue("importeME", FormatNumber(colImporteME, 2))
                End If
            End If
        Next
    End Sub


    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        If IsNumeric(txtTipoCambio.Text) Then
            If txtTipoCambio.Text > 0 Then

                TipoCambio()
            End If


        End If

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        Me.Cursor = Cursors.WaitCursor
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            txtBuscarProducto.Visible = False
            btnNuevoProd.Visible = False

            Label6.Text = "Clasificación"
            txtCategoria.Visible = True
            PictureBox2.Visible = True
            Label42.Visible = True
            Label43.Visible = True

            Label35.Visible = True
            txtSubCategoria.Visible = True
            PictureBox1.Visible = True

            CMBClasificacion()

        Else
            txtBuscarProducto.Visible = True
            btnNuevoProd.Visible = True

            Label6.Text = "Buscar item"
            txtCategoria.Visible = False
            PictureBox2.Visible = False
            Label42.Visible = False
            Label43.Visible = False

            Label35.Visible = False
            txtSubCategoria.Visible = False
            PictureBox1.Visible = False

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToggleButton21_Click(sender As Object, e As EventArgs) Handles ToggleButton21.Click

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

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged

    End Sub

    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If
            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If
            If txtBuscarProducto.Text.Trim.Length > 0 Then
                .UCNuenExistencia.txtProductoNew.Text = txtBuscarProducto.Text
            End If
            '.cboTipoExistencia.SelectedValue = "01"
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                If MessageBoxAdv.Show("Desea agregar el producto a la canasta ?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    If datos(0).Cuenta = "Grabado" Then
                        '  If lsvListadoItems.SelectedItems.Count > 0 Then

                        With objInsumo.InvocarProductoID(CInt(datos(0).ID))

                            Me.dgvMov.Table.AddNewRecord.SetCurrent()
                            Me.dgvMov.Table.AddNewRecord.BeginEdit()
                            Me.dgvMov.Table.CurrentRecord.SetValue("id", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("Correccion", 3)
                            Me.dgvMov.Table.CurrentRecord.SetValue("grav", .origenProducto)
                            Me.dgvMov.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                            Me.dgvMov.Table.CurrentRecord.SetValue("item", String.Format("{0}-{1}", .descripcionItem, datos(0).NomEvento))
                            Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", .presentacion)
                            Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", String.Empty)
                            Me.dgvMov.Table.CurrentRecord.SetValue("idUM", .unidad1)
                            Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", .unidad1)
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0.0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0.0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0.0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0.0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0.0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", .cuenta)
                            Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", .tipoExistencia)
                            Me.dgvMov.Table.CurrentRecord.SetValue("estado", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("utiMenor", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("utiMayor", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("utiGranMayor", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("colModVenta", False)
                            Me.dgvMov.Table.CurrentRecord.SetValue("valCheck", "N")
                            Me.dgvMov.Table.CurrentRecord.SetValue("almacenDestino", cboAlmacen.SelectedValue)
                            Me.dgvMov.Table.CurrentRecord.SetValue("fechaVcto", Date.Now)
                            Me.dgvMov.Table.CurrentRecord.SetValue("fechaProd", Date.Now)
                            Me.dgvMov.Table.CurrentRecord.SetValue("preciounitarioIGV", 0)
                            Me.dgvMov.Table.AddNewRecord.EndEdit()
                        End With

                    End If
                End If
            End If
        End With

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmNuevaClasificacion
        f.StartPosition = FormStartPosition.CenterParent

        f.ShowDialog()
        CMBClasificacion()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmNuevaMarca
        f.StartPosition = FormStartPosition.CenterParent
        f.txtCodigo.Tag = txtCategoria.Tag
        f.txtCodigo.Text = txtCategoria.Tag
        f.ShowDialog()
        Productoshijos()
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

    Private Sub txtSubCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtSubCategoria.TextChanged

    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCategoria.SelectedIndexChanged

    End Sub

    Private Sub GradientPanel4_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel4.Paint

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

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
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

    Private Sub lsvSubCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvSubCategoria.MouseDoubleClick
        Me.pcSubCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvSubCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSubCategoria.SelectedIndexChanged

    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged

        If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then

            dgvMov.TableDescriptor.Columns("Correccion").Width = 200


        ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then

            dgvMov.TableDescriptor.Columns("Correccion").Width = 0


        End If

    End Sub

    'Private Sub dgvMov_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvMov.TableControlKeyDown
    '    Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
    '    cc.ConfirmChanges()
    '    If cc.ColIndex > -1 Then
    '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

    '        If style.TableCellIdentity.Column.Name = "cantidad" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value
    '                Dim colCantidad = value ' Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '                Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    Dim colPUmn As Decimal =
    '                            Math.Round(
    '                            Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If
    '        ElseIf style.TableCellIdentity.Column.Name = "importeMN" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value

    '                Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '                Dim colImporteMN = value ' Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    Dim colPUmn As Decimal =
    '                            Math.Round(
    '                            Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If

    '        ElseIf style.TableCellIdentity.Column.Name = "precMN" Then

    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value

    '                Dim colCantidad = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"))
    '                Dim colImporteMN = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * value
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    'Dim colPUmn As Decimal =
    '                    '        Math.Round(
    '                    '        Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(value / txtTipoCambio.DecimalValue, 2)
    '                    'Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If
    '        End If


    '        '    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
    '        '    If cc.ColIndex = 6 Or cc.ColIndex = 8 Then

    '        '        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
    '        '            Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '        '            Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '        '            Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '        '            Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '        '            If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '        '                Dim colPUmn As Decimal =
    '        '                    Math.Round(
    '        '                    Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '        '                Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '        '            End If


    '        '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

    '        '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


    '        '            ''If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '        '            ''    Dim decg As Decimal
    '        '            ''    Dim tipocam = txtTipoCambio.Text
    '        '            ''    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '        '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '        '            ''Else
    '        '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '        '            ''End If


    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)

    '        '        End If

    '        '    ElseIf cc.ColIndex = 7 Then
    '        '        Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '        '        Dim colPrecioUnitario = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
    '        '        Dim colImporteMN = colCantidad * colPrecioUnitario
    '        '        Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '        '        Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '        '        If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '        '            Dim colPUmn As Decimal = colPrecioUnitario
    '        '            Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '        '        End If

    '        '    ElseIf cc.ColIndex = 1 Then

    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '        '    End If

    '        '    'Select Case ColIndex
    '        '    '    Case 6
    '        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 8, GridSetCurrentCellOptions.SetFocus)

    '        '    '    Case 8
    '        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 11, GridSetCurrentCellOptions.SetFocus)
    '        '    'End Select
    '        'End If
    '    End If
    'End Sub

    'Private Sub dgvMov_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvMov.TableControlKeyPress
    '    Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
    '    cc.ConfirmChanges()
    '    If cc.ColIndex > -1 Then
    '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

    '        If style.TableCellIdentity.Column.Name = "cantidad" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value
    '                Dim colCantidad = value ' Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '                Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    Dim colPUmn As Decimal =
    '                            Math.Round(
    '                            Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If
    '        ElseIf style.TableCellIdentity.Column.Name = "importeMN" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value

    '                Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '                Dim colImporteMN = value ' Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    Dim colPUmn As Decimal =
    '                            Math.Round(
    '                            Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If

    '        ElseIf style.TableCellIdentity.Column.Name = "precMN" Then

    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value

    '                Dim colCantidad = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"))
    '                Dim colImporteMN = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * value
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    'Dim colPUmn As Decimal =
    '                    '        Math.Round(
    '                    '        Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(value / txtTipoCambio.DecimalValue, 2)
    '                    'Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If
    '        End If


    '        '    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
    '        '    If cc.ColIndex = 6 Or cc.ColIndex = 8 Then

    '        '        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
    '        '            Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '        '            Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '        '            Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '        '            Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '        '            If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '        '                Dim colPUmn As Decimal =
    '        '                    Math.Round(
    '        '                    Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '        '                Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '        '            End If


    '        '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

    '        '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


    '        '            ''If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '        '            ''    Dim decg As Decimal
    '        '            ''    Dim tipocam = txtTipoCambio.Text
    '        '            ''    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '        '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '        '            ''Else
    '        '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '        '            ''End If


    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)

    '        '        End If

    '        '    ElseIf cc.ColIndex = 7 Then
    '        '        Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '        '        Dim colPrecioUnitario = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
    '        '        Dim colImporteMN = colCantidad * colPrecioUnitario
    '        '        Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '        '        Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '        '        If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '        '            Dim colPUmn As Decimal = colPrecioUnitario
    '        '            Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '        '        End If

    '        '    ElseIf cc.ColIndex = 1 Then

    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '        '    End If

    '        '    'Select Case ColIndex
    '        '    '    Case 6
    '        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 8, GridSetCurrentCellOptions.SetFocus)

    '        '    '    Case 8
    '        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 11, GridSetCurrentCellOptions.SetFocus)
    '        '    'End Select
    '        'End If
    '    End If
    'End Sub

    Private Sub cboAsignacion_Click(sender As Object, e As EventArgs) Handles cboAsignacion.Click

    End Sub

    'Private Sub dgvMov_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvMov.TableControlKeyUp
    '    Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
    '    cc.ConfirmChanges()
    '    If cc.ColIndex > -1 Then
    '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

    '        If style.TableCellIdentity.Column.Name = "cantidad" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value
    '                Dim colCantidad = value ' Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '                Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    Dim colPUmn As Decimal =
    '                            Math.Round(
    '                            Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If
    '        ElseIf style.TableCellIdentity.Column.Name = "importeMN" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value

    '                Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '                Dim colImporteMN = value ' Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    Dim colPUmn As Decimal =
    '                            Math.Round(
    '                            Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If

    '        ElseIf style.TableCellIdentity.Column.Name = "precMN" Then

    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim value As Decimal = Convert.ToDecimal(text)
    '                cc.Renderer.ControlValue = value

    '                Dim colCantidad = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad"))
    '                Dim colImporteMN = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * value
    '                Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '                Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '                If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '                    'Dim colPUmn As Decimal =
    '                    '        Math.Round(
    '                    '        Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '                    Dim colPUme As Decimal = Math.Round(value / txtTipoCambio.DecimalValue, 2)
    '                    'Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '                End If
    '            End If
    '        End If


    '        '    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
    '        '    If cc.ColIndex = 6 Or cc.ColIndex = 8 Then

    '        '        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
    '        '            Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '        '            Dim colImporteMN = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN")
    '        '            Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '        '            Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '        '            If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '        '                Dim colPUmn As Decimal =
    '        '                    Math.Round(
    '        '                    Me.dgvMov.Table.CurrentRecord.GetValue("MontoBase") / colCantidad, 2)
    '        '                Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '        '                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '        '            End If


    '        '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

    '        '        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


    '        '            ''If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '        '            ''    Dim decg As Decimal
    '        '            ''    Dim tipocam = txtTipoCambio.Text
    '        '            ''    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '        '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '        '            ''Else
    '        '            ''    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '        '            ''End If


    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)

    '        '        End If

    '        '    ElseIf cc.ColIndex = 7 Then
    '        '        Dim colCantidad = Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")
    '        '        Dim colPrecioUnitario = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
    '        '        Dim colImporteMN = colCantidad * colPrecioUnitario
    '        '        Dim colBaseImp As Decimal? = CalculoBaseImponible(colImporteMN, 1.18)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", colBaseImp)
    '        '        Dim colImporteME = Math.Round(colImporteMN / txtTipoCambio.DecimalValue, 2)
    '        '        If colImporteMN > 0 AndAlso colCantidad > 0 Then
    '        '            Dim colPUmn As Decimal = colPrecioUnitario
    '        '            Dim colPUme As Decimal = Math.Round(colPUmn / txtTipoCambio.DecimalValue, 2)
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", colPUmn.ToString("N2"))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme.ToString("N2"))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", FormatNumber(colImporteMN, 2))
    '        '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(colImporteME, 2))
    '        '        End If

    '        '    ElseIf cc.ColIndex = 1 Then

    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("MontoBase", 0)
    '        '        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '        '    End If

    '        '    'Select Case ColIndex
    '        '    '    Case 6
    '        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 8, GridSetCurrentCellOptions.SetFocus)

    '        '    '    Case 8
    '        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 11, GridSetCurrentCellOptions.SetFocus)
    '        '    'End Select
    '        'End If
    '    End If
    'End Sub

    Private Sub cboAsignacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAsignacion.SelectedValueChanged
        If dgvMov.Table.Records.Count > 0 Then
            Select Case cboAsignacion.Text
                Case "POR LOTES"
                    Me.dgvMov.TableDescriptor.VisibleColumns.Add("lote")
                    Me.dgvMov.TableDescriptor.VisibleColumns.Add("fechaProd")
                    Me.dgvMov.TableDescriptor.VisibleColumns.Add("fechaVcto")
                Case "LOTE EXISTENTE"

                Case "CONTROL POR COMPROBANTE"

                    Me.dgvMov.TableDescriptor.VisibleColumns.Remove("lote")
                    Me.dgvMov.TableDescriptor.VisibleColumns.Remove("fechaProd")
                    Me.dgvMov.TableDescriptor.VisibleColumns.Remove("fechaVcto")
            End Select
        End If
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RBCliente.CheckedChanged
        If RBCliente.Checked Then
            GetThreadEntidades(TIPO_ENTIDAD.CLIENTE)
        End If
    End Sub

    Private Sub RBProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles RBProveedor.CheckedChanged
        If RBProveedor.Checked Then
            GetThreadEntidades(TIPO_ENTIDAD.PROVEEDOR)
        End If
    End Sub

    Private Sub RBOtros_CheckedChanged(sender As Object, e As EventArgs) Handles RBOtros.CheckedChanged
        If RBOtros.Checked Then
            GetThreadEntidades(TIPO_ENTIDAD.PERSONA_GENERAL)
        End If
    End Sub

    Private Sub TextPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPersona.KeyDown


        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else

            If RBCliente.Checked Or RBProveedor.Checked Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer4.Size = New Size(319, 128)
                Me.PopupControlContainer4.ParentControl = Me.TextPersona
                Me.PopupControlContainer4.ShowPopup(Point.Empty)
                Dim consulta As New List(Of entidad)
                consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
                Dim consulta2 = (From n In ListaEntidad
                                 Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.nrodoc.StartsWith(TextPersona.Text)).ToList
                consulta.AddRange(consulta2)
                '     consulta.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
                FillLSVEntidades(consulta)
                e.Handled = True
            ElseIf RBOtros.Checked Then
                Me.PopupControlContainer4.Size = New Size(319, 128)
                Me.PopupControlContainer4.ParentControl = Me.TextPersona
                Me.PopupControlContainer4.ShowPopup(Point.Empty)

                Dim consulta As New List(Of Persona)
                consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})
                Dim consulta2 = (From n In ListaTrabajadores
                                 Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.idPersona.StartsWith(TextPersona.Text)).ToList

                consulta.AddRange(consulta2)

                FillLSVPersonas(consulta)
                e.Handled = True
            End If
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.TextPersona
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

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                If lsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    If RBProveedor.Checked Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo proveedor"
                        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, entidad)
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idEntidad
                            TextDNI.Visible = True
                            TextDNI.Text = c.nrodoc
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaEntidad.Add(c)
                        End If
                    ElseIf RBCliente.Checked Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo cliente"
                        f.strTipo = TIPO_ENTIDAD.CLIENTE
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, entidad)
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idEntidad
                            TextDNI.Visible = True
                            TextDNI.Text = c.nrodoc
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaEntidad.Add(c)
                        End If
                    ElseIf RBOtros.Checked Then
                        Dim f As New FrmNuevaPersona()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, Persona)
                            c.idPersona = c.idPersona
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idPersona
                            TextDNI.Visible = True
                            TextDNI.Text = c.idPersona
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaTrabajadores.Add(c)
                        End If
                    End If
                Else
                    TextPersona.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    TextPersona.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    TextDNI.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    TextDNI.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            TextPersona.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ChPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles ChPrecios.CheckedChanged
        If ChPrecios.Checked = True Then
            If cboTipoExistencia.Text = "MERCADERIA" Then
                dgvMov.TableDescriptor.Columns("menor").Width = 75
                dgvMov.TableDescriptor.Columns("mayor").Width = 75
                dgvMov.TableDescriptor.Columns("gmayor").Width = 75
            Else
                dgvMov.TableDescriptor.Columns("menor").Width = 0
                dgvMov.TableDescriptor.Columns("mayor").Width = 0
                dgvMov.TableDescriptor.Columns("gmayor").Width = 0
            End If
        Else
            dgvMov.TableDescriptor.Columns("menor").Width = 0
            dgvMov.TableDescriptor.Columns("mayor").Width = 0
            dgvMov.TableDescriptor.Columns("gmayor").Width = 0
        End If
    End Sub

    Private Sub cboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub

    'Private Sub ChRegimenGen_OnChange(sender As Object, e As EventArgs) Handles ChRegimenGen.OnChange
    '    If ChRegimenGen.Checked = True Then
    '        dgvMov.TableDescriptor.Columns("importeMN").Width = 75
    '        dgvMov.TableDescriptor.Columns("MontoBase").Width = 0
    '    ElseIf ChRegimenGen.Checked = False Then
    '        dgvMov.TableDescriptor.Columns("importeMN").Width = 0
    '        dgvMov.TableDescriptor.Columns("MontoBase").Width = 75
    '    End If
    'End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDocumento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedValueChanged
        If cboTipoDocumento.Text.Trim.Length > 0 Then
            If (cboTipoDocumento.SelectedValue = "99") Then
                txtNumero.Clear()
                txtSerie.Clear()
                txtSerie.Visible = True
                txtSerie.ReadOnly = False
                txtNumero.Visible = True
                txtNumero.ReadOnly = False
            Else
                txtSerie.Clear()
                txtNumero.Clear()
                txtSerie.Visible = True
                txtSerie.ReadOnly = True
                txtNumero.Visible = False
                txtNumero.ReadOnly = True
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim strIdModulo As String = Nothing
        If cboTipoDocumento.Text = "VOUCHER CONTABLE" Then
            strIdModulo = "TEA"
        End If
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtSerie.Text = conf.Serie
        ProgressBar2.Visible = False
    End Sub

    Private Sub cboTipoDocumento_Click(sender As Object, e As EventArgs) Handles cboTipoDocumento.Click

    End Sub

    Private Sub cboTipoExistencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedValueChanged
        If cboTipoExistencia.Text.Trim.Length > 0 Then
            ChPrecios_CheckedChanged(sender, e)
        End If
    End Sub

    Private Sub GradientPanel5_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel5.Paint

    End Sub

    Private Sub lsvListadoItems_KeyDown(sender As Object, e As KeyEventArgs) Handles lsvListadoItems.KeyDown

    End Sub
End Class