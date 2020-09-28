Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Tools

Public Class frmnuevoLibroDiario
    Inherits frmMaster
    Public Property fecha() As DateTime
    Dim SumaTotalDebeMN As Decimal = 0
    Dim SumaTotalHaberMN As Decimal = 0
    Public Property AsientoNotificado As String

    Dim SumaTotalDebeME As Decimal = 0
    Dim SumaTotalHaberME As Decimal = 0
    Public Property valorNode() As String
    Public Property ManipulacionEstado() As String
    Public Property GConfiguracion As New GConfiguracionModulo
    Dim colorx As New GridMetroColors()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        CombosLoad()
        dgvCompra.DataSource = GetTableGrid()
        GridCFG(dgvCompra)
        txtPeriodo.Text = PeriodoGeneral
        txtFechaComprobante.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        GroupBox2.Visible = False

        ListaTipoCambio = New List(Of tipoCambio)
        LoadTipoCambio()
    End Sub
    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA

        ListaTipoCambio = tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, CInt(MesGeneral), CInt(AnioGeneral), GEstableciento.IdEstablecimiento)
        Dim consulta = (From n In ListaTipoCambio _
                        Where n.fechaIgv.Year = txtFechaComprobante.Value.Year _
                        And n.fechaIgv.Month = txtFechaComprobante.Value.Month _
                        And n.fechaIgv.Day = txtFechaComprobante.Value.Day).FirstOrDefault

        If Not IsNothing(consulta) Then
            txtTipoCambio.Value = consulta.venta
        Else
            txtTipoCambio.Value = 0
        End If
    End Sub
    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CombosLoad()
        dgvCompra.DataSource = GetTableGrid()
        GridCFG(dgvCompra)
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)
        ListaTipoCambio = New List(Of tipoCambio)
        LoadTipoCambio()
        UbicarDocumentoLibro(intIdDocumento)
     
    End Sub

#Region "Costos"

    Private Sub GetItemsCosto(strCosto As String)
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("name")
        Select Case strCosto
            Case "HC"

                If TmpProyecto = True Then
                    Dim dr As DataRow = dt.NewRow
                    dr(0) = TipoCosto.Proyecto
                    dr(1) = "PROYECTO"
                    dt.Rows.Add(dr)
                End If

                If TmpOrdenProduccion = True Then
                    Dim dr1 As DataRow = dt.NewRow
                    dr1(0) = TipoCosto.OrdenProduccion
                    dr1(1) = "ORDEN DE PRODUCCION"
                    dt.Rows.Add(dr1)
                End If

                If TmpActivo = True Then
                    Dim dr2 As DataRow = dt.NewRow
                    dr2(0) = TipoCosto.ActivoFijo
                    dr2(1) = "ACTIVO FIJO"
                    dt.Rows.Add(dr2)
                End If

                'cboTipoCosto.DataSource = dt
                'cboTipoCosto.DisplayMember = "name"
                'cboTipoCosto.ValueMember = "id"
            Case "HG"

                If TmpGastoAdmin = True Then
                    Dim dr As DataRow = dt.NewRow
                    dr(0) = TipoCosto.GastoAdministrativo
                    dr(1) = "GASTO ADMINISTRATIVO"
                    dt.Rows.Add(dr)
                End If

                If TmpGastoVentas = True Then
                    Dim dr1 As DataRow = dt.NewRow
                    dr1(0) = TipoCosto.GastoVentas
                    dr1(1) = "GASTO DE VENTAS"
                    dt.Rows.Add(dr1)
                End If

                If TmpGastoFinanciero = True Then
                    Dim dr2 As DataRow = dt.NewRow
                    dr2(0) = TipoCosto.GastoFinanciero
                    dr2(1) = "GASTO FINANCIERO"
                    dt.Rows.Add(dr2)
                End If

                'cboTipoCosto.DataSource = dt
                'cboTipoCosto.DisplayMember = "name"
                'cboTipoCosto.ValueMember = "id"
        End Select
    End Sub

    Public Sub GetCostoByTipoCMB(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCosto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
    End Sub
#End Region

    Sub CombosLoad()
        Dim tablaSA As New tablaDetalleSA

        cboTipoOperacion.DisplayMember = "descripcion"
        cboTipoOperacion.ValueMember = "codigoDetalle"
        'cboTipoOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1").OrderBy(Function(o) o.descripcion).ToList
        cboTipoOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1").ToList

        Dim cuentaSA As New cuentaplanContableEmpresaSA
        ListadoCuentasContables = cuentaSA.ObtenerCuentasPorEmpresaEscalable(Gempresas.IdEmpresaRuc)
    End Sub

    Sub GridCFG2(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = False

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))

        documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.importeTotal
                dr(9) = i.importeUS
                dt.Rows.Add(dr)
            Next
            'dgvComprasL.DataSource = dt

        Else

        End If
    End Sub

    '#Region "asiento"

    '    Public Property ListaMovimientos As New List(Of movimiento)
    '    Public Property ListaAsientonTransito As New List(Of asiento)



    '    Sub updateMovimientoLista(r As Record)
    '        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '        Try
    '            Dim consulta = (From n In ListaMovimientos _
    '                       Where n.idmovimiento = r.GetValue("id")).ToList

    '            For Each i In consulta
    '                If Not IsNothing(consulta) Then
    '                    i.cuenta = r.GetValue("cuenta")
    '                    Dim md = r.GetValue("Modulo").ToString
    '                    If md.Trim.Length > 0 Then
    '                        i.nombreEntidad = r.GetValue("Modulo")
    '                    Else
    '                        i.nombreEntidad = String.Empty
    '                    End If

    '                    Dim des = r.GetValue("descripcion").ToString
    '                    If des.Trim.Length > 0 Then
    '                        i.descripcion = r.GetValue("descripcion")
    '                    Else
    '                        i.descripcion = String.Empty
    '                    End If
    '                    i.tipo = r.GetValue("tipoAsiento")
    '                    i.Cant = r.GetValue("cant")
    '                    i.PUmn = r.GetValue("pumn")
    '                    i.PUme = r.GetValue("pume")
    '                    i.monto = r.GetValue("importeMN")
    '                    i.montoUSD = r.GetValue("importeME")
    '                End If
    '            Next

    '            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '        Catch ex As Exception
    '            MessageBoxAdv.Show(ex.Message)
    '        End Try
    '    End Sub



    '    Sub updateMovimiento(r As Record)
    '        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '        Try
    '            Dim consulta = (From n In ListaMovimientos _
    '                       Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

    '            If Not IsNothing(consulta) Then
    '                consulta.cuenta = r.GetValue("cuenta")
    '                Dim md = r.GetValue("Modulo").ToString
    '                If md.Trim.Length > 0 Then
    '                    consulta.nombreEntidad = r.GetValue("Modulo")
    '                Else
    '                    consulta.nombreEntidad = String.Empty
    '                End If

    '                Dim des = r.GetValue("descripcion").ToString
    '                If des.Trim.Length > 0 Then
    '                    consulta.descripcion = r.GetValue("descripcion")
    '                Else
    '                    consulta.descripcion = String.Empty
    '                End If
    '                consulta.tipo = r.GetValue("tipoAsiento")
    '                consulta.Cant = r.GetValue("cant")
    '                consulta.PUmn = r.GetValue("pumn")
    '                consulta.PUme = r.GetValue("pume")
    '                consulta.monto = r.GetValue("importeMN")
    '                consulta.montoUSD = r.GetValue("importeME")
    '            End If

    '            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '        Catch ex As Exception
    '            MessageBoxAdv.Show(ex.Message)
    '        End Try
    '    End Sub

    '    Sub UbicarAsientoPorId(asiento As asiento)
    '        Dim consulta = (From n In ListaAsientonTransito _
    '                Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '        If Not IsNothing(consulta) Then
    '            'txtGlosaAsiento.Text = consulta.glosa
    '        End If
    '    End Sub

    '    Sub updateGlosaAsiento(asiento As asiento)
    '        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '        Try
    '            Dim consulta = (From n In ListaAsientonTransito _
    '                       Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '            If Not IsNothing(consulta) Then
    '                'consulta.glosa = txtGlosaAsiento.Text.Trim
    '            End If

    '            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '        Catch ex As Exception
    '            MessageBoxAdv.Show(ex.Message)
    '        End Try
    '    End Sub

    '    Sub RegistrarMovimiento(nAsiento As asiento)

    '        Dim cuentaSA As New cuentaplanContableEmpresaSA

    '        Dim dt As New DataTable
    '        dt.Columns.Add("id", GetType(Integer))
    '        dt.Columns.Add("Modulo", GetType(String))
    '        dt.Columns.Add("cuenta", GetType(String))
    '        dt.Columns.Add("tipoAsiento", GetType(String))
    '        dt.Columns.Add("cant", GetType(Decimal))
    '        dt.Columns.Add("pumn", GetType(Decimal))
    '        dt.Columns.Add("importeMN", GetType(Decimal))
    '        dt.Columns.Add("pume", GetType(Decimal))
    '        dt.Columns.Add("importeME", GetType(Decimal))
    '        dt.Columns.Add("descripcion", GetType(String))

    '        Dim cosnulta = (From i In ListaMovimientos _
    '                       Where i.idAsiento = nAsiento.idAsiento).ToList

    '        '   For x As Integer = 0 To cosnulta.Count - 1

    '        'dt.Rows.Add(dt.NewRow())
    '        'dt.Rows(x)(0) = CInt(cosnulta(x).idmovimiento)
    '        'If Not IsNothing(cosnulta(x).cuenta) Then
    '        '    dt.Rows(x)(1) = cosnulta(x).nombreEntidad
    '        'Else
    '        '    dt.Rows(x)(1) = String.Empty
    '        'End If
    '        'dt.Rows(x)(2) = cosnulta(x).cuenta
    '        'dt.Rows(x)(3) = cosnulta(x).tipo
    '        'dt.Rows(x)(4) = cosnulta(x).Cant
    '        'dt.Rows(x)(5) = cosnulta(x).PUmn
    '        'dt.Rows(x)(6) = cosnulta(x).monto
    '        'dt.Rows(x)(7) = cosnulta(x).PUme
    '        'dt.Rows(x)(8) = cosnulta(x).montoUSD
    '        'dt.Rows(x)(9) = cosnulta(x).descripcion
    '        For Each x In cosnulta
    '            Dim dr As DataRow = dt.NewRow
    '            dr(0) = x.idmovimiento
    '            If Not IsNothing(x.cuenta) Then
    '                dr(1) = x.nombreEntidad
    '            Else
    '                dr(1) = String.Empty
    '            End If
    '            dr(2) = x.cuenta
    '            dr(3) = x.tipo
    '            dr(4) = x.Cant
    '            dr(5) = x.PUmn
    '            dr(6) = x.monto
    '            dr(7) = x.PUme
    '            dr(8) = x.montoUSD
    '            dr(9) = x.descripcion
    '            dt.Rows.Add(dr)
    '        Next

    '        dgvCompra.DataSource = dt
    '    End Sub

    '    Sub GetasientosListbox()
    '        Dim dt As New DataTable()
    '        dt.Columns.Add("id")
    '        dt.Columns.Add("nombre")

    '        For Each i In ListaAsientonTransito
    '            Dim dr As DataRow = dt.NewRow
    '            dr(0) = i.idAsiento
    '            dr(1) = i.Descripcion
    '            dt.Rows.Add(dr)
    '        Next

    '        lstAsiento.DisplayMember = "nombre"
    '        lstAsiento.ValueMember = "id"
    '        lstAsiento.DataSource = dt
    '    End Sub

    '    Function GetMaxIDAsiento() As Integer
    '        If ListaAsientonTransito.Count > 0 Then
    '            Return ListaAsientonTransito.Max(Function(o) o.idAsiento)

    '        Else
    '            Return 0
    '        End If
    '    End Function

    '    Function GetMaxIDMovimiento() As Integer
    '        If ListaMovimientos.Count > 0 Then
    '            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
    '        Else
    '            Return 0
    '        End If
    '    End Function

    '    Sub RegistrarAsientos()
    '        Dim nAsiento As New asiento

    '        If ListaAsientonTransito.Count > 0 Then
    '            nAsiento.idAsiento = GetMaxIDAsiento() + 1
    '        Else
    '            nAsiento.idAsiento = 1
    '        End If
    '        nAsiento.Descripcion = "Asiento Nro. " & GetMaxIDAsiento() + 1
    '        ListaAsientonTransito.Add(nAsiento)

    '        GetasientosListbox()
    '    End Sub

    '    Sub RegsitarMovimiento(nAsiento As asiento)
    '        Dim n As New movimiento
    '        n.cuenta = "10"
    '        n.idAsiento = nAsiento.idAsiento
    '        n.idmovimiento = GetMaxIDMovimiento() + 1
    '        n.tipo = "D"
    '        n.Cant = 1
    '        n.PUmn = 0
    '        n.PUme = 0
    '        n.monto = 0
    '        n.montoUSD = 0
    '        ListaMovimientos.Add(n)
    '    End Sub
    '#End Region

#Region "Asientos"
    Public Property ListaAsientos As New List(Of asiento)
    Public Property ListaMovimiento As New List(Of movimiento)

    Public Property ListadoCuentasContables As New List(Of cuentaplanContableEmpresa)
    Public Property ListadoOperaciones As New List(Of tabladetalle)

    Private Sub EliminarAsientoByCodigo(be As asiento)

        Dim con1 = (From n In ListaMovimiento _
                   Where n.idAsiento = be.idAsiento).ToList

        For Each i In con1
            ListaMovimiento.Remove(i)
        Next

        Dim con2 = (From n In ListaAsientos _
                   Where n.idAsiento = be.idAsiento).FirstOrDefault

        ListaAsientos.Remove(con2)

        GetListadoAsientos()

        If lstAsientos.SelectedItems.Count > 0 Then
            GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        Else
            dgvCompra.DataSource = New List(Of movimiento)
        End If
    End Sub

    Private Sub AddAsiento()
        Dim n As New asiento
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = 0
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now
        n.codigoLibro = "5"
        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = "Asiento manual"
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        GetListadoAsientos()
    End Sub
    Private Sub EliminarFilaMovimiento(mov As movimiento)
        Dim consulta = (From n In ListaMovimiento _
                       Where n.idmovimiento = mov.idmovimiento).FirstOrDefault

        ListaMovimiento.Remove(consulta)
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub
    Private Sub AddMovimiento()
        Dim n As New movimiento
        n.idAsiento = lstAsientos.SelectedValue
        If ListaMovimiento.Count > 0 Then
            n.idmovimiento = ListaMovimiento.Count + 1
        Else
            n.idmovimiento = 1
        End If
        n.cuenta = txtCuentaSel.Tag
        n.descripcion = txtCuentaSel.Text
        n.tipo = "D"
        n.monto = 0
        n.montoUSD = 0

        ListaMovimiento.Add(n)

        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub

    Private Sub GetListadoAsientos()
        Dim con = (From n In ListaAsientos).ToList

        lstAsientos.DataSource = con
        lstAsientos.ValueMember = "idAsiento"
        lstAsientos.DisplayMember = "Descripcion"
    End Sub

    Private Sub GetListadoMovimientoByAsiento(be As asiento)
        Dim con = (From n In ListaMovimiento _
                  Where n.idAsiento = be.idAsiento).ToList

        dgvCompra.DataSource = con
    End Sub
#End Region

#Region "persona"
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

#Region "Métodos"

    'Public Sub GrabarPersonaCliente()
    '    Dim personaSA As New PersonaSA
    '    Dim personaBE As New Persona

    '    With personaBE
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idPersona = txtDniTrab.Text.Trim
    '        .nombres = txtNombreTrab.Text.Trim
    '        .appat = txtAppatTrab.Text.Trim
    '        .apmat = txtApmatTrab.Text.Trim
    '        .nivel = "CL"
    '        .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
    '    End With
    '    personaSA.InsertPersona(personaBE)
    '    txtProveedor.Tag = personaBE.idPersona
    '    txtProveedor.Text = personaBE.nombreCompleto
    '    txtRuc.Text = personaBE.idPersona
    '    txtCuenta = "TR"

    '    lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    'End Sub

    'Public Sub GrabarPersona()
    '    Dim personaSA As New PersonaSA
    '    Dim personaBE As New Persona

    '    With personaBE
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idPersona = txtDniTrab.Text.Trim
    '        .nombres = txtNombreTrab.Text.Trim
    '        .appat = txtAppatTrab.Text.Trim
    '        .apmat = txtApmatTrab.Text.Trim
    '        .nivel = "TR"
    '        .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
    '    End With
    '    personaSA.InsertPersona(personaBE)
    '    txtProveedor.Tag = personaBE.idPersona
    '    txtProveedor.Text = personaBE.nombreCompleto
    '    txtRuc.Text = personaBE.idPersona
    '    txtCuenta = "TR"

    '    lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    'End Sub


    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
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
    '                        txtSerie.Text = .serie
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
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Public Sub UbicarDocumentoLibro(intIdDocumento As Integer)

        Dim movimientoSA As New documentoLibroDiarioSA
        Dim dt As New DataTable
        Dim documentoSA As New documentoLibroDiarioSA
        Dim documento As New documentoLibroDiario
        Dim entidadSa As New entidadSA
        Dim entidad As New entidad
        Dim personaSA As New PersonaSA
        Dim asientoSA As New AsientoSA
        Dim listaAsiento As New List(Of movimiento)
        Dim listaAst As New List(Of asiento)
        Dim recursoBL As New recursoCostoSA
        Dim recurso As New recursoCosto


        documento = documentoSA.UbicarDocumentoLibroDiario(intIdDocumento)
        With documento
            txtPeriodo.Text = .fechaPeriodo
            txtFechaComprobante.Value = .fecha
            txtFechaComprobante.Tag = .idDocumento
            txtglosa.Text = .infoReferencial
            If .tieneCosto = "S" Then
                chCosto.Checked = True
            Else
                chCosto.Checked = False
                GroupBox2.Visible = False
            End If


            Dim codperson = .razonSocial.ToString
            Dim tipo = .tipoRazonSocial

            If tipo = "PR" Then
                entidad = entidadSa.UbicarEntidadPorID(.razonSocial).FirstOrDefault
                txtProveedor.Text = entidad.nombreCompleto
                txtRuc.Text = entidad.nrodoc
                chProv.Checked = True
                chClie.Checked = False
                chTrab.Checked = False
            ElseIf tipo = "CL" Then
                entidad = entidadSa.UbicarEntidadPorID(.razonSocial).FirstOrDefault
                txtProveedor.Text = entidad.nombreCompleto
                txtRuc.Text = entidad.nrodoc
                chProv.Checked = False
                chClie.Checked = True
                chTrab.Checked = False
            ElseIf tipo = "TR" Then
                txtProveedor.Text = personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, codperson, tipo).nombreCompleto
                txtRuc.Text = codperson
                chProv.Checked = False
                chClie.Checked = False
                chTrab.Checked = True
            End If

            txtProveedor.Tag = codperson

            txtnumero.Text = .nroDoc
            Select Case .moneda
                Case "1"
                    rbnac.Checked = True
                Case Else
                    rbExt.Checked = True
            End Select
            txtTipoCambio.Value = .tipoCambio
            cboTipoOperacion.SelectedValue = .tipoOperacion

        End With


        If Not IsNothing(documento.idCosto) Then
            recurso = recursoBL.GetCostoById(New recursoCosto With {.idCosto = documento.idCosto})

            Select Case recurso.subtipo
                Case TipoCosto.Proyecto
                    rbCosto.Checked = True
                Case TipoCosto.OrdenProduccion
                    rbCosto.Checked = True
                Case TipoCosto.ActivoFijo
                    rbCosto.Checked = True
                Case TipoCosto.GastoAdministrativo
                    rbGasto.Checked = True
                Case TipoCosto.GastoVentas
                    rbGasto.Checked = True
                Case TipoCosto.GastoFinanciero
                    rbGasto.Checked = True

            End Select

            txtTipoCosto.Text = recurso.subtipo
            cboCosto.SelectedValue = recurso.idCosto

        End If


        Dim movimientosSA As New MovimientoSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        listaAst = asientoSA.UbicarAsientoPorDocumento(intIdDocumento)

        Dim recuperaASTCosto = (From n In listaAst _
                               Where n.tipoAsiento = "ACCA").ToList

        For Each i In recuperaASTCosto
            listaAst.Remove(i)
        Next

        'If listaAst.Count >= 2 Then
        '    listaAst.RemoveAt(listaAst.Count - 1)
        'End If

        For Each i In listaAst
            Dim n As New asiento
            n.Action = Business.Entity.BaseBE.EntityAction.INSERT
            n.idDocumento = 0
            n.idEmpresa = Gempresas.IdEmpresaRuc
            n.idCentroCostos = GEstableciento.IdEstablecimiento
            n.fechaProceso = DateTime.Now
            n.codigoLibro = "5"
            n.tipo = "D"
            n.tipoAsiento = "AS-M"
            n.glosa = i.glosa
            If ListaAsientos.Count > 0 Then
                n.idAsiento = ListaAsientos.Count + 1
                n.Descripcion = "Asiento " & ListaAsientos.Count + 1
            Else
                n.idAsiento = 1
                n.Descripcion = "Asiento " & 1
            End If
            n.usuarioActualizacion = usuario.IDUsuario
            n.fechaActualizacion = DateTime.Now
            ListaAsientos.Add(n)

            listaAsiento = movimientosSA.UbicarMovimientoPorAsiento(i.idAsiento)
            For Each mov In listaAsiento
                Dim n1 As New movimiento
                n1.idAsiento = n.idAsiento
                If ListaMovimiento.Count > 0 Then
                    n1.idmovimiento = ListaMovimiento.Count + 1
                Else
                    n1.idmovimiento = 1
                End If
                n1.cuenta = mov.cuenta
                n1.descripcion = mov.descripcion
                n1.tipo = mov.tipo
                n1.monto = mov.monto
                n1.montoUSD = 0

                ListaMovimiento.Add(n1)
            Next
        Next
        'GetasientosListbox()
        GetListadoAsientos()
        If lstAsientos.SelectedItems.Count > 0 Then
            GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        End If




    End Sub

    Private Function GetTableGrid() As DataTable
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
    Public Sub GrabarAsiento()
        Dim costoSA As New recursoCostoSA
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = fecha
        documento.nroDoc = "1"
        documento.tipoOperacion = cboTipoOperacion.SelectedValue  'INGRESO CUENTAS MANUALES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        If Not IsNothing(AsientoNotificado) Then
            documentoLibroDiario.AsientoNotificado = AsientoNotificado
        End If

        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = valorNode
        documentoLibroDiario.fecha = fecha
        documentoLibroDiario.fechaPeriodo = txtPeriodo.Text

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If chProv.Checked = True Then
            documentoLibroDiario.tipoRazonSocial = "PR"
        End If
        If chTrab.Checked = True Then
            documentoLibroDiario.tipoRazonSocial = "TR"
        End If
        If chClie.Checked = True Then
            documentoLibroDiario.tipoRazonSocial = "CL"
        End If



        documentoLibroDiario.razonSocial = CInt(txtProveedor.Tag)

        documentoLibroDiario.infoReferencial = "Por Asientos Manuales"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = cboTipoOperacion.SelectedValue
        documentoLibroDiario.moneda = IIf(rbnac.Checked = True, "1", "2")
        documentoLibroDiario.tipoCambio = txtTipoCambio.Value
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now

        If chCosto.Checked = True Then

            If rbCosto.Checked = True Then
                documentoLibroDiario.tieneCosto = "S"
                documentoLibroDiario.idCosto = cboElementoCosto.SelectedValue
            Else
                documentoLibroDiario.tieneCosto = "S"
                documentoLibroDiario.idCosto = cboCosto.SelectedValue
            End If

            
        Else
            documentoLibroDiario.tieneCosto = "N"
            documentoLibroDiario.idCosto = Nothing
        End If

        'documentoLibroDiario.importeMN = 0
        'documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario
        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0


        If chCosto.Checked = True Then
            'ASIENTOS CONTABLES
            nAsiento = New asiento With {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCostos = GEstableciento.IdEstablecimiento,
            .idDocumentoRef = Nothing,
            .idAlmacen = 0,
            .nombreAlmacen = String.Empty,
            .idEntidad = String.Empty,
            .nombreEntidad = String.Empty,
            .tipoEntidad = String.Empty,
            .fechaProceso = txtFechaComprobante.Value,
            .codigoLibro = "5",
            .tipo = "D",
            .tipoAsiento = "ACCA",
            .importeMN = 0,
            .importeME = 0,
            .glosa = txtglosa.Text.Trim,
            .IdProceso = cboProceso.SelectedValue,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now}
        End If

        Dim sumaCostoMN As Decimal = 0
        Dim sumaCostoME As Decimal = 0

        For Each obj In ListaMovimiento

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = obj.cuenta
            documentoLibroDiarioDet.FechaDoc = txtFechaComprobante.Value
            If chCosto.Checked = True Then
                documentoLibroDiarioDet.idCosto = cboElementoCosto.SelectedValue
                documentoLibroDiarioDet.idProceso = cboProceso.SelectedValue
                Dim cuentaMid = Mid(obj.cuenta, 1, 2)
                Select Case Val(cuentaMid)
                    Case 62 To 68
                        sumaCostoMN += CDec(obj.monto)
                        sumaCostoME += CDec(obj.monto / txtTipoCambio.Value)
                End Select

            End If

            documentoLibroDiarioDet.descripcion = obj.descripcion
            documentoLibroDiarioDet.tipoAsiento = obj.tipo
            documentoLibroDiarioDet.importeMN = obj.monto
            documentoLibroDiarioDet.importeME = CDec(obj.monto / txtTipoCambio.Value)
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

        Next

        If chCosto.Checked = True Then
            Select Case txtTipoCosto.Text
                Case TipoCosto.Proyecto, _
                    TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES, _
                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                    nMovimiento = New movimiento With {
                        .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                        .descripcion = "MATERIALES AUXILIARES",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "791",
                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)

                Case TipoCosto.OrdenProduccion, _
                    TipoCosto.OP_CONTINUA_DE_BIENES, _
                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                    TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE, _
                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                    nMovimiento = New movimiento With {
                        .cuenta = "231",
                        .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "7111",
                    .descripcion = "PRODUCTOS MANUFACTURADOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)


                Case TipoCosto.ActivoFijo

                    nMovimiento = New movimiento With {
                        .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                        .descripcion = "CONSTRUCCIONES Y OBRAS EN CURSO",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "7225",
                    .descripcion = "EQUIPOS DIVERSOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)


                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero

                    nMovimiento = New movimiento With {
                        .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboCosto.SelectedValue}).codigo,
                        .descripcion = "GASTOS ADMINISTRATIVOS.",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "79",
                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)


            End Select

            nAsiento.importeMN = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
            nAsiento.importeME = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        End If

        documento.documentoLibroDiario.importeMN = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
        documento.documentoLibroDiario.importeME = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)


        documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle
        '   End If


        For Each i In ListaAsientos
            Dim consultaMov = (From n In ListaMovimiento _
                              Where n.idAsiento = i.idAsiento).ToList


            i.idEmpresa = Gempresas.IdEmpresaRuc
            i.idCentroCostos = GEstableciento.IdEstablecimiento
            i.idEntidad = Nothing
            i.nombreEntidad = Nothing
            i.tipoEntidad = Nothing
            i.fechaProceso = txtFechaComprobante.Value
            i.codigoLibro = "5"
            i.tipo = "D"
            i.tipoAsiento = "AS-M"
            i.importeMN = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
            i.importeME = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
            i.glosa = i.glosa
            i.usuarioActualizacion = usuario.IDUsuario
            i.fechaActualizacion = DateTime.Now
            i.Action = Business.Entity.BaseBE.EntityAction.INSERT

            For Each mov In consultaMov
                '    i.Descripcion = mov.nombreEntidad
                i.movimiento.Add(mov)
            Next
        Next

        If chCosto.Checked = True Then
            ListaAsientos.Add(nAsiento)
        End If
        documento.asiento = ListaAsientos
        Dim xcod As Integer = documentoLibroDiarioSA.GrabarLibro(documento)
        lblEstado.Text = "compra registrada!"
        Dispose()
    End Sub

    Public Sub EditarAsiento()
        Dim costoSA As New recursoCostoSA
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        documento = New documento
        documento.idDocumento = CInt(txtFechaComprobante.Tag)
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = txtFechaComprobante.Value
        documento.nroDoc = "1"
        documento.tipoOperacion = cboTipoOperacion.SelectedValue  'INGRESO CUENTAS MANUALES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now


        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.idDocumento = CInt(txtFechaComprobante.Tag)
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = valorNode
        documentoLibroDiario.fecha = txtFechaComprobante.Value
        documentoLibroDiario.fechaPeriodo = txtPeriodo.Text
        documentoLibroDiario.infoReferencial = txtglosa.Text
        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = cboTipoOperacion.SelectedValue
        documentoLibroDiario.moneda = IIf(rbnac.Checked = True, "1", "2")
        documentoLibroDiario.tipoCambio = txtTipoCambio.Value
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now

        If chCosto.Checked = True Then
            If rbCosto.Checked = True Then
                documentoLibroDiario.tieneCosto = "S"
                documentoLibroDiario.idCosto = cboElementoCosto.SelectedValue
            Else
                documentoLibroDiario.tieneCosto = "S"
                documentoLibroDiario.idCosto = cboCosto.SelectedValue
            End If
        Else
            documentoLibroDiario.tieneCosto = "N"
            documentoLibroDiario.idCosto = Nothing
        End If

        'documentoLibroDiario.importeMN = 0
        'documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario
        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0

        If chCosto.Checked = True Then
            'ASIENTOS CONTABLES
            nAsiento = New asiento With {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCostos = GEstableciento.IdEstablecimiento,
            .idDocumentoRef = Nothing,
            .idAlmacen = 0,
            .nombreAlmacen = String.Empty,
            .idEntidad = String.Empty,
            .nombreEntidad = String.Empty,
            .tipoEntidad = String.Empty,
            .fechaProceso = txtFechaComprobante.Value,
            .codigoLibro = "5",
            .tipo = "D",
            .tipoAsiento = "ACCA",
            .importeMN = 0,
            .importeME = 0,
            .glosa = txtglosa.Text.Trim,
            .IdProceso = cboProceso.SelectedValue,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now}
        End If



        Dim sumaCostoMN As Decimal = 0
        Dim sumaCostoME As Decimal = 0

        For Each obj In ListaMovimiento
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.idItem = obj.cuenta
            documentoLibroDiarioDet.FechaDoc = txtFechaComprobante.Value
            If chCosto.Checked = True Then
                documentoLibroDiarioDet.idCosto = cboElementoCosto.SelectedValue
                documentoLibroDiarioDet.idProceso = cboProceso.SelectedValue
                Dim cuentaMid = Mid(obj.cuenta, 1, 2)
                Select Case Val(cuentaMid)
                    Case 62 To 68
                        sumaCostoMN += CDec(obj.monto)
                        sumaCostoME += CDec(obj.monto / txtTipoCambio.Value)
                End Select
            End If
            documentoLibroDiarioDet.cuenta = obj.cuenta
            documentoLibroDiarioDet.descripcion = obj.descripcion
            documentoLibroDiarioDet.tipoAsiento = obj.tipo
            documentoLibroDiarioDet.importeMN = obj.monto
            documentoLibroDiarioDet.importeME = CDec(obj.monto / txtTipoCambio.Value)
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
        Next

        If chCosto.Checked = True Then
            Select Case txtTipoCosto.Text
                Case TipoCosto.Proyecto, _
                    TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES, _
                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                    nMovimiento = New movimiento With {
                        .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                        .descripcion = "MATERIALES AUXILIARES",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "791",
                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)

                Case TipoCosto.OrdenProduccion, _
                    TipoCosto.OP_CONTINUA_DE_BIENES, _
                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                    TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE, _
                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                    nMovimiento = New movimiento With {
                        .cuenta = "231",
                        .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "7111",
                    .descripcion = "PRODUCTOS MANUFACTURADOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)


                Case TipoCosto.ActivoFijo

                    nMovimiento = New movimiento With {
                        .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                        .descripcion = "CONSTRUCCIONES Y OBRAS EN CURSO",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "7225",
                    .descripcion = "EQUIPOS DIVERSOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)


                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero

                    nMovimiento = New movimiento With {
                        .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboCosto.SelectedValue}).codigo,
                        .descripcion = "GASTOS ADMINISTRATIVOS.",
                        .tipo = "D",
                        .monto = sumaCostoMN,
                        .montoUSD = sumaCostoME,
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento With {
                    .cuenta = "79",
                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                    .tipo = "H",
                    .monto = sumaCostoMN,
                    .montoUSD = sumaCostoME,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                    nAsiento.movimiento.Add(nMovimiento)
            End Select

            nAsiento.importeMN = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
            nAsiento.importeME = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        End If
        documento.documentoLibroDiario.importeMN = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
        documento.documentoLibroDiario.importeME = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle

        For Each i In ListaAsientos
            Dim consultaMov = (From n In ListaMovimiento _
                              Where n.idAsiento = i.idAsiento).ToList


            i.idEmpresa = Gempresas.IdEmpresaRuc
            i.idCentroCostos = GEstableciento.IdEstablecimiento
            i.idEntidad = Nothing
            i.nombreEntidad = Nothing
            i.tipoEntidad = Nothing
            i.fechaProceso = txtFechaComprobante.Value
            i.codigoLibro = "5"
            i.tipo = "D"
            i.tipoAsiento = "AS-M"
            i.importeMN = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
            i.importeME = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
            i.glosa = i.glosa
            i.usuarioActualizacion = usuario.IDUsuario
            i.fechaActualizacion = DateTime.Now
            i.Action = Business.Entity.BaseBE.EntityAction.INSERT

            For Each mov In consultaMov
                '    i.Descripcion = mov.nombreEntidad
                i.movimiento.Add(mov)
            Next
        Next

        If chCosto.Checked = True Then
            ListaAsientos.Add(nAsiento)
        End If
        documento.asiento = ListaAsientos
        documentoLibroDiarioSA.ActualizarDocumentoLibroDiario(documento)
        lblEstado.Text = "compra registrada!"
        Dispose()
    End Sub

#End Region

    Private Sub frmnuevoLibroDiario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Dim comboTable As New DataTable

    Public Sub GetTableAlmacen()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTable = New DataTable("Cuentas")
        comboTable.Columns.Add("idCuenta")
        comboTable.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTable.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

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


    Private Sub frmnuevoLibroDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtProveedor.Text = "OTROS"
        txtProveedor.Tag = "00000000"
        txtRuc.Text = "00000000"

        'GetTableAlmacen()
        'Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        'ggcStyle.CellType = "ComboBox"
        'ggcStyle.DataSource = Me.comboTable
        'ggcStyle.ValueMember = "idCuenta"
        'ggcStyle.DisplayMember = "descripcionCuenta"
        'ggcStyle.DropDownStyle = GridDropDownStyle.AutoComplete


        'Dim ggcStyle2 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        'ggcStyle2.CellType = "ComboBox"
        'ggcStyle2.DataSource = Me.GetTableAsientos
        'ggcStyle2.ValueMember = "id"
        'ggcStyle2.DisplayMember = "name"
        'ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'dgvCompra.ShowRowHeaders = False

        If Tag = "editar" Then
        Else
            'RegistrarAsientos()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmNuevoitemTabladetalle
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        CombosLoad()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            'If ColIndex = 1 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
            'If ColIndex = 3 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 3 Then
                'updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub

    Private Sub dgvCompra_SizeChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            'If ColIndex = 2 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
            'If ColIndex = 4 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
            'If ColIndex = 7 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
            'If ColIndex = 1 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If

        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs)


    End Sub

    'Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs)
    '    Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell

    '    'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

    '    If cc.ColIndex = 1 Then
    '        cc.ConfirmChanges()
    '        ' Me.dgvCompra.TableModel(cc.RowIndex, cc.ColIndex + 1).CellValue = "Hai"
    '        '  updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        Dim str = Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue
    '        If str = "H" Then
    '            Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "D"
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        Else
    '            Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "H"
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '    End If
    '    If cc.ColIndex = 3 Then

    '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

    '    End If
    '    If cc.ColIndex = 2 Then

    '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

    '    End If

    '    'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

    '    '    If ColIndex = 1 Then
    '    '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '    '    End If
    '    '    If ColIndex = 3 Then
    '    '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '    '    End If
    '    'End If
    'End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs)
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    'Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
    '    Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell

    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

    '    If cc.ColIndex = 1 Then
    '        cc.ConfirmChanges()
    '        Me.dgvCompra.TableModel(cc.RowIndex, cc.ColIndex + 1).CellValue = "Hai"
    '    End If

    '    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

    '        If ColIndex = 1 Then
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '        If ColIndex = 3 Then
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '    End If
    'End Sub

    'Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs)
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
    '        'Select Case ColIndex
    '        '    Case 4
    '        '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

    '        '        'Case 7
    '        '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
    '        'End Select

    '        If ColIndex = 1 Then
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '        If ColIndex = 3 Then
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '        If ColIndex = 2 Then

    '            Dim cuentaSA As New cuentaplanContableEmpresaSA

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)

    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta"))
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '        If ColIndex = 4 Then
    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '        If ColIndex = 7 Then

    '            Dim colMN As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")
    '            Dim cant As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("cant")
    '            Dim colPUMN As Decimal = Math.Round(colMN / cant, 2).ToString("N2")

    '            Dim colPUME As Decimal = Math.Round(colMN / txtTipoCambio.Value, 2).ToString("N2")
    '            Dim colME As Decimal = Math.Round(colPUME / cant, 2).ToString("N2")

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", colME)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPUME)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPUMN)


    '            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
    '        End If
    '        'If ColIndex = 3 Then
    '        '    Dim importeDebeME As Decimal = 0

    '        '    If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
    '        '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
    '        '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
    '        '        importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
    '        '        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
    '        '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
    '        '    End If

    '        'End If
    '        'If ColIndex = 4 Then
    '        '    Dim importeHaberME As Decimal = 0

    '        '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
    '        '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
    '        '    importeHaberME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
    '        '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
    '        '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")

    '        'End If
    '    End If
    'End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
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

    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress


    End Sub




    Private Sub txtnumero_TextChanged(sender As Object, e As EventArgs) Handles txtnumero.TextChanged

    End Sub

    'Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        Me.popupControlContainer1.ParentControl = Me.txtProveedor
    '        Me.popupControlContainer1.ShowPopup(Point.Empty)
    '        CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
    '    End If
    'End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lsvProveedor.SelectedItems.Count > 0 Then
        '        Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
        '        txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
        '        txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
        '        ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

        '        UbicarCompraXProveedorNroSerie(txtRuc.Text, PeriodoGeneral)

        '        txtSerieGuia.Select()
        '        txtSerieGuia.SelectAll()
        '    End If
        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.txtProveedor.Focus()
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
    '    If lsvProveedor.SelectedItems.Count > 0 Then
    '        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    '    End If
    'End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '            e.SuppressKeyPress = True
    '            'cboMoneda.Select()
    '            txtSerieGuia.Select()
    '            'txtProveedor.Focus()
    '        End If
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        txtNumeroGuia.Clear()
    '    End Try
    'End Sub

    'Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs)
    '    Try
    '        If txtNumeroGuia.Text.Trim.Length > 0 Then
    '            '    If chFormato.Checked = True Then
    '            txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

    '            'End If
    '        End If
    '    Catch ex As Exception
    '        'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
    '        txtNumeroGuia.Select()
    '        txtNumeroGuia.Focus()
    '        txtNumeroGuia.Clear()
    '        lblEstado.Text = "Error de formato verifique el ingreso!"
    '    End Try
    'End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '            e.SuppressKeyPress = True
    '            txtNumeroGuia.Select()
    '        End If
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        txtSerieGuia.Clear()
    '    End Try
    'End Sub

    'Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs)
    '    Try
    '        If txtSerieGuia.Text.Trim.Length > 0 Then
    '            '  If chFormato.Checked = True Then
    '            txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
    '            'End If
    '        End If

    '    Catch ex As Exception

    '        If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

    '            If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

    '                If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

    '                    If Len(txtSerieGuia.Text) <= 2 Then

    '                        txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

    '                    ElseIf Len(txtSerieGuia.Text) <= 3 Then

    '                        txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

    '                    ElseIf Len(txtSerieGuia.Text) <= 4 Then

    '                        txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

    '                    ElseIf Len(txtSerieGuia.Text) <= 5 Then

    '                        txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

    '                    End If
    '                End If
    '            Else

    '                txtSerieGuia.Select()
    '                txtSerieGuia.Focus()
    '                txtSerieGuia.Clear()
    '                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
    '                Timer1.Enabled = True
    '                PanelError.Visible = True
    '                TiempoEjecutar(10)

    '            End If

    '        Else

    '            txtSerieGuia.Select()
    '            txtSerieGuia.Focus()
    '            txtSerieGuia.Clear()
    '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '        End If

    '    End Try
    'End Sub

    Private Sub txtSerieGuia_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvComprasL_MouseDoubleClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub dgvComprasL_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    'Private Sub dgvComprasL_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs)
    '    If Not IsNothing(Me.dgvComprasL.Table.CurrentRecord) Then

    '        txtIdDocumento.Text = Me.dgvComprasL.Table.CurrentRecord.GetValue("idDocumento")
    '        txtSerieGuia.Text = Me.dgvComprasL.Table.CurrentRecord.GetValue("Serie")
    '        txtNumeroGuia.Text = Me.dgvComprasL.Table.CurrentRecord.GetValue("Numero")



    '    End If
    'End Sub

    Private Sub dgvComprasL_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs)

    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub

    Private Sub EliminarMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EliminarAsientoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AgregrarMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AgregarAsientoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AgregrarMovimientoToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        If lstAsientos.SelectedItems.Count > 0 Then
            'RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            'RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub AgregarAsientoToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        'RegistrarAsientos()
    End Sub

    'Private Sub EliminarAsientoToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
    '    Dim consulta = (From n In ListaAsientonTransito _
    '                Where n.idAsiento = lstAsiento.SelectedValue).FirstOrDefault


    '    If Not IsNothing(consulta) Then
    '        Dim listaMov = (From i In ListaMovimientos _
    '                       Where i.idAsiento = lstAsiento.SelectedValue).ToList

    '        For Each obj In listaMov
    '            ListaMovimientos.Remove(obj)
    '        Next
    '        ListaAsientonTransito.Remove(consulta)
    '        GetasientosListbox()
    '        lstAsiento_SelectedIndexChanged(sender, e)
    '    End If
    'End Sub

    Private Sub EliminarMovimientoToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
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

    Private Sub lstAsiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsientos.SelectedIndexChanged
        If lstAsientos.SelectedItems.Count > 0 Then

            Dim cod = lstAsientos.SelectedValue
            If IsNumeric(cod) Then
                GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})

                Dim consulta = (From n In ListaAsientos _
                               Where n.idAsiento = lstAsientos.SelectedValue).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtGlosaAsiento.Text = consulta.glosa
                End If

            End If

            'RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            'UbicarAsientoPorId(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        'If lstAsientos.SelectedItems.Count > 0 Then
        '    Dim consulta = (From n In ListaMovimientos _
        '                   Where n.idAsiento = lstAsiento.SelectedValue).ToList

        '    If consulta.Count > 0 Then

        '        Dim f As New frmViewAsiento(consulta)
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        'RegistrarAsientos()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
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

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
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

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        If lstAsientos.SelectedItems.Count > 0 Then
            'RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            'RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub txtGlosaAsiento_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        If lstAsientos.SelectedItems.Count > 0 Then
            'If txtGlosaAsiento.Text.Trim.Length > 0 Then
            '    updateGlosaAsiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            '    lstAsiento_SelectedIndexChanged(sender, e)
            'End If
        Else
            lblEstado.Text = "Debe seleccionar un asiento!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub



    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            'If ColIndex = 1 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
            'If ColIndex = 3 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
            'If ColIndex = 6 Then
            '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            'End If
        End If

    End Sub
    Private cr As GridComboBoxCellRenderer


    Private Sub ListBoxPart_SelectedValueChanged(sender As Object, e As EventArgs)
        cr.TextBox.Text = cr.ListBoxPart.SelectedItem.ToString()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellStartEditing(sender As Object, e As GridTableControlCancelEventArgs)

    End Sub


    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)
            ElseIf chClie.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub
    Public Property txtCuenta As String
    Private Sub PopupControlContainer1_CloseUp_1(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
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

    Private Sub lsvProveedor_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chProv_Click_1(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chClie.Checked = False

        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chClie_Click(sender As Object, e As EventArgs) Handles chClie.Click
        chProv.Checked = False
        chTrab.Checked = False
        chClie.Checked = True

        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click_1(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chTrab.Checked = True
        chClie.Checked = False

        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chTrab.Checked = True Then
            With FrmNuevaPersona
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If

        If chClie.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo Cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        If lstPersonas.SelectedItems.Count > 0 Then
            Me.pcPersonas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub pcPersonas_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcPersonas.BeforePopup
        Me.pcPersonas.BackColor = Color.White
    End Sub

    Private Sub pcPersonas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcPersonas.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstPersonas.SelectedItems.Count > 0 Then
                txtProveedor.Tag = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
                txtProveedor.Text = lstPersonas.Text
                txtCuenta = "TR"
                txtRuc.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub pcCuentas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcCuentas.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
                txtCuentaSel.Text = lsvCuentasEncontradas.Text
                txtCuentaSel.Tag = lsvCuentasEncontradas.SelectedValue


                If lstAsientos.SelectedItems.Count > 0 Then
                    If txtCuentaSel.Text.Trim.Length > 0 Then
                        AddMovimiento()
                    End If
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCodigoCuentaBuscar.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvCuentasEncontradas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCuentasEncontradas.MouseDoubleClick
        If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
            Me.pcCuentas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtCodigoCuentaBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCuentaBuscar.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoCuentasContables _
                     Where n.cuenta.StartsWith(txtCodigoCuentaBuscar.Text)).ToList

            lsvCuentasEncontradas.DataSource = consulta
            lsvCuentasEncontradas.DisplayMember = "descripcion"
            lsvCuentasEncontradas.ValueMember = "cuenta"

            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            lsvCuentasEncontradas.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcCuentas.IsShowing() Then
                Me.pcCuentas.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtCodigoCuentaBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoCuentaBuscar.TextChanged

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        AddAsiento()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            EliminarAsientoByCodigo(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            If txtCuentaSel.Text.Trim.Length > 0 Then
                AddMovimiento()
            End If
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            EliminarFilaMovimiento(New movimiento With {.idmovimiento = Val(dgvCompra.Table.CurrentRecord.GetValue("idmovimiento"))})
        End If
    End Sub

    Private Sub btnGrabar_Click_1(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        If ListaAsientos.Count > 0 Then
            For Each i In ListaAsientos

                Dim conteoMov = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento).Count

                If conteoMov > 0 Then

                    For Each mov In ListaMovimiento
                        If i.idAsiento = mov.idAsiento Then

                            Dim sumaDebe As Decimal = 0
                            sumaDebe = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento And o.tipo = "D").Sum(Function(o) o.monto)

                            If sumaDebe <= 0 Then
                                MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El monto de la columna del debe es cero, verifique.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If


                            Dim sumaHaber As Decimal = 0
                            sumaHaber = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento And o.tipo = "H").Sum(Function(o) o.monto)


                            If sumaHaber <= 0 Then
                                MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El monto de la columna del haber es cero, verifique.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If

                            If sumaDebe <> sumaHaber Then
                                MessageBoxAdv.Show("El " & i.Descripcion & vbCrLf & vbCrLf & "Deben cuadrar los asientos del debe y haber.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If

                            i.movimiento.Add(mov)
                        End If
                    Next
                Else
                    MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El asiento no contiene movimientos!", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

            Next
        Else
            Me.Cursor = Cursors.Arrow
            MessageBoxAdv.Show("Debe ingresar al menos un asiento a la canasta", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            GrabarAsiento()
        Else
            EditarAsiento()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtGlosaAsiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGlosaAsiento.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

        End If
    End Sub

    Private Sub txtGlosaAsiento_TextChanged_1(sender As Object, e As EventArgs) Handles txtGlosaAsiento.TextChanged

    End Sub

    Private Sub ButtonAdv1_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If txtGlosaAsiento.Text.Trim.Length > 0 Then
            Dim consulta = (From n In ListaAsientos _
                       Where n.idAsiento = lstAsientos.SelectedValue).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.glosa = txtGlosaAsiento.Text.Trim
            End If
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub chCosto_CheckStateChanged(sender As Object, e As EventArgs) Handles chCosto.CheckStateChanged
        If chCosto.Checked = True Then
            rbCosto.Checked = True
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub
    Public Sub GetCostoByTipoCMBServicios1(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCosto.DataSource = recursoSA.GetListaPryectosEnCarteraFull(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})


        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
    End Sub
    Private Sub rbCosto_CheckChanged(sender As Object, e As EventArgs) Handles rbCosto.CheckChanged
        If rbCosto.Checked = True Then
            'Label3.Text = "Asignar recursos (Elmento del costo)"
            cboElementoCosto.Visible = True

            GetCostoByTipoCMBServicios1(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
            cboCosto.SelectedIndex = -1
        End If
    End Sub

    Private Sub rbGasto_CheckChanged(sender As Object, e As EventArgs) Handles rbGasto.CheckChanged
       If rbGasto.Checked = True Then
            'Label3.Text = "Asignar recursos"
            cboElementoCosto.Visible = False

        End If
    End Sub

    'Private Sub cboTipoCosto_Click(sender As Object, e As EventArgs) Handles cboTipoCosto.Click

    'End Sub

    'Private Sub cboTipoCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCosto.SelectedIndexChanged
    '    Dim codValue = cboTipoCosto.Text.ToString

    '    Select Case codValue
    '        Case "PROYECTO"
    '            GetCostoByTipoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
    '        Case "ORDEN DE PRODUCCION"
    '            GetCostoByTipoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
    '        Case "ACTIVO FIJO"
    '            GetCostoByTipoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
    '        Case "GASTO ADMINISTRATIVO"
    '            GetCostoByTipoCMB(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
    '        Case "GASTO DE VENTAS"
    '            GetCostoByTipoCMB(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
    '        Case "GASTO FINANCIERO"
    '            GetCostoByTipoCMB(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
    '    End Select
    'End Sub

    Private Sub cboCosto_Click(sender As Object, e As EventArgs) Handles cboCosto.Click

    End Sub

    Sub ComboProcesos(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboProceso.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboProceso.ValueMember = "idCosto"
        cboProceso.DisplayMember = "nombreCosto"
    End Sub
    Sub ComboProcesos1(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboProceso.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboProceso.ValueMember = "idCosto"
        cboProceso.DisplayMember = "nombreCosto"
    End Sub
    Private Sub cboCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCosto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboElementoCosto.DataSource = Nothing
        cboProceso.DataSource = Nothing
        If cboCosto.SelectedIndex > -1 Then
            If rbCosto.Checked = True Then
                Dim recursoSA As New recursoCostoSA

                Dim codValue = cboCosto.SelectedValue


                If IsNumeric(codValue) Then
                    codValue = Val(codValue)
                    txtTipoCosto.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = codValue}).subtipo

                    cboElementoCosto.Visible = True

                    cboElementoCosto.DisplayMember = "nombreCosto"
                    cboElementoCosto.ValueMember = "idCosto"
                    cboElementoCosto.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

                    ComboProcesos1(codValue)

                End If
            End If
        End If
        cboElementoCosto.SelectedIndex = -1
        cboProceso.SelectedIndex = -1
    End Sub
    Public Property ListaTipoCambio As New List(Of tipoCambio)
    Private Sub txtFechaComprobante_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaComprobante.ValueChanged
        If IsDate(txtFechaComprobante.Value) Then

            If rbExt.Checked = True Then
                txtTipoCambio.Value = 0
            Else
                Dim consulta = (From n In ListaTipoCambio _
                           Where n.fechaIgv.Year = txtFechaComprobante.Value.Year _
                           And n.fechaIgv.Month = txtFechaComprobante.Value.Month _
                           And n.fechaIgv.Day = txtFechaComprobante.Value.Day).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtTipoCambio.Value = consulta.venta
                Else
                    txtTipoCambio.Value = 0
                End If
            End If

        End If
    End Sub
End Class