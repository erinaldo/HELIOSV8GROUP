Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Public Class frmConsumoDeProduccion

    Public Property listaAsientoEnvio As New List(Of asiento)
    Public Property ListaContable As New List(Of cuentaplanContableEmpresa)

#Region "Atributos"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text, GEstableciento.IdEstablecimiento)



        '  GridCFGDetetail(dgvCostos)
        'GridCFGDetetail(dgvCostos)
        GridCFG(dgvCostos)
        GetItems()
        LoadComboFechas()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

#Region "Metodos"


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

    Sub GridCFGK(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
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
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub



    Private Sub LoadComboFechas()
        Dim empresaAnioSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral

    End Sub

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
    '        'lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"

    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")

    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

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


    Public Sub AsientosCosteo921()

        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        'If lblMontoDeficit.Text > 0 Then
        '    'asiento()
        '    nAsiento = New asiento
        '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '    ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        '    nAsiento.idEntidad = 0
        '    nAsiento.nombreEntidad = "SIN IDENTIDAD"
        '    nAsiento.tipoEntidad = "OT"
        '    nAsiento.fechaProceso = DateTime.Now
        '    nAsiento.periodo = PeriodoGeneral
        '    nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        '    nAsiento.tipo = "D"
        '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        '    nAsiento.importeMN = CDec(lblMontoDeficit.Text)
        '    nAsiento.importeME = CDec(0.0)
        '    nAsiento.glosa = "Por Costeo Final"
        '    nAsiento.usuarioActualizacion = usuario.IDUsuario
        '    nAsiento.fechaActualizacion = Date.Now


        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "713"
        '    nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
        '    nMovimiento.tipo = "D"
        '    nMovimiento.monto = CDec(lblMontoDeficit.Text)
        '    nMovimiento.montoUSD = CDec(0.0)
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    nMovimiento.fechaActualizacion = Date.Now
        '    nAsiento.movimiento.Add(nMovimiento)

        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "231"
        '    nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
        '    nMovimiento.tipo = "H"
        '    nMovimiento.monto = CDec(lblMontoDeficit.Text)
        '    nMovimiento.montoUSD = CDec(0.0)
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    nMovimiento.fechaActualizacion = Date.Now
        '    nAsiento.movimiento.Add(nMovimiento)

        '    listaAsientoEnvio.Add(nAsiento)


        '    ''2
        nAsiento = New asiento
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        'nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        If chProv.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chCli.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ElseIf chTrab.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        End If
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
        nAsiento.tipo = "D"
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        nAsiento.importeMN = CDec(lblMontoDeficit.Text)
        nAsiento.importeME = CDec(0.0)
        nAsiento.glosa = "Por Costeo Final"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "791"
        nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = lblCuentaProyecto.Text
        nMovimiento.descripcion = txtEntregable.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        listaAsientoEnvio.Add(nAsiento)

        'End If    'fin del deficit

        'ASIENTOS POR COSTO REAL

        ''3
        'nAsiento = New asiento
        'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        'nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = txtProveedor.Text
        'If chProv.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        'ElseIf chCli.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        'ElseIf chTrab.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        'End If
        'nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        'nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        'nAsiento.tipo = "D"
        'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        'nAsiento.importeMN = CDec(lblMontoReal.Text)
        'nAsiento.importeME = CDec(0.0)
        'nAsiento.glosa = "Por Costeo Final"
        'nAsiento.usuarioActualizacion = usuario.IDUsuario
        'nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "713"
        'nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
        'nMovimiento.tipo = "D"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        'nAsiento.movimiento.Add(nMovimiento)

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "231"
        'nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
        'nMovimiento.tipo = "H"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        'nAsiento.movimiento.Add(nMovimiento)

        'listaAsientoEnvio.Add(nAsiento)
        '4

        nAsiento = New asiento
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        If chProv.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chCli.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ElseIf chTrab.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        End If
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
        nAsiento.tipo = "D"
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        nAsiento.importeMN = CDec(lblMontoReal.Text)
        nAsiento.importeME = CDec(0.0)
        nAsiento.glosa = "Por Costeo Final"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "211"
        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "711"
        nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        listaAsientoEnvio.Add(nAsiento)


        '5


        nAsiento = New asiento
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        If chProv.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chCli.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ElseIf chTrab.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        End If
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
        nAsiento.tipo = "D"
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        nAsiento.importeMN = CDec(lblMontoReal.Text)
        nAsiento.importeME = CDec(0.0)
        nAsiento.glosa = "Por Costeo Final"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "694"
        nMovimiento.descripcion = "SERVICIOS"
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "211"
        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        listaAsientoEnvio.Add(nAsiento)


        'nAsiento = New asiento
        'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        'nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = txtProveedor.Text
        'If chProv.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        'ElseIf chCli.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        'ElseIf chTrab.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        'End If
        'nAsiento.fechaProceso = DateTime.Now
        'nAsiento.periodo = PeriodoGeneral
        'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        'nAsiento.tipo = "D"
        'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        'nAsiento.importeMN = CDec(lblMontoReal.Text)
        'nAsiento.importeME = CDec(0.0)
        'nAsiento.glosa = "Por Costeo Final"
        'nAsiento.usuarioActualizacion = usuario.IDUsuario
        'nAsiento.fechaActualizacion = Date.Now


        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "694"
        'nMovimiento.descripcion = "SERVICIOS"
        'nMovimiento.tipo = "D"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = Date.Now
        'nAsiento.movimiento.Add(nMovimiento)

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "211"
        'nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        'nMovimiento.tipo = "H"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = Date.Now
        'nAsiento.movimiento.Add(nMovimiento)

        'listaAsientoEnvio.Add(nAsiento)
        'Final POR AISENTOS DEL COSTO REAL
    End Sub

    Public Sub AsientosCosteo922()

        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento


        nAsiento = New asiento
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        'nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        If chProv.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chCli.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ElseIf chTrab.Checked = True Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        End If
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
        nAsiento.tipo = "D"
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        nAsiento.importeMN = CDec(lblMontoDeficit.Text)
        nAsiento.importeME = CDec(0.0)
        nAsiento.glosa = "Por Costeo Final"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "791"
        nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = lblCuentaProyecto.Text
        nMovimiento.descripcion = txtEntregable.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(lblMontoReal.Text)
        nMovimiento.montoUSD = CDec(0.0)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.movimiento.Add(nMovimiento)

        listaAsientoEnvio.Add(nAsiento)

        'End If    'fin del deficit

        'ASIENTOS POR COSTO REAL

        ''3
        'nAsiento = New asiento
        'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        'nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = txtProveedor.Text
        'If chProv.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        'ElseIf chCli.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        'ElseIf chTrab.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        'End If
        'nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        'nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        'nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
        'nAsiento.tipo = "D"
        'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        'nAsiento.importeMN = CDec(lblMontoReal.Text)
        'nAsiento.importeME = CDec(0.0)
        'nAsiento.glosa = "Por Costeo Final"
        'nAsiento.usuarioActualizacion = usuario.IDUsuario
        'nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "713"
        'nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
        'nMovimiento.tipo = "D"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        'nAsiento.movimiento.Add(nMovimiento)

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "231"
        'nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
        'nMovimiento.tipo = "H"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        'nAsiento.movimiento.Add(nMovimiento)

        'listaAsientoEnvio.Add(nAsiento)


        'If lblMontoDeficit.Text > 0 Then

        '    ''2
        '    nAsiento = New asiento
        '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        '    'nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '    nAsiento.idEntidad = txtProveedor.Tag
        '    nAsiento.nombreEntidad = txtProveedor.Text
        '    If chProv.Checked = True Then
        '        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        '    ElseIf chCli.Checked = True Then
        '        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        '    ElseIf chTrab.Checked = True Then
        '        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        '    End If
        '    nAsiento.fechaProceso = DateTime.Now
        '    nAsiento.periodo = PeriodoGeneral
        '    nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        '    nAsiento.tipo = "D"
        '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        '    nAsiento.importeMN = CDec(lblMontoDeficit.Text)
        '    nAsiento.importeME = CDec(0.0)
        '    nAsiento.glosa = "Por Costeo Final"
        '    nAsiento.usuarioActualizacion = usuario.IDUsuario
        '    nAsiento.fechaActualizacion = Date.Now


        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "791"
        '    nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
        '    nMovimiento.tipo = "D"
        '    nMovimiento.monto = CDec(lblMontoDeficit.Text)
        '    nMovimiento.montoUSD = CDec(0.0)
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    nMovimiento.fechaActualizacion = Date.Now
        '    nAsiento.movimiento.Add(nMovimiento)

        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = lblCuentaProyecto.Text
        '    nMovimiento.descripcion = txtEntregable.Text
        '    nMovimiento.tipo = "H"
        '    nMovimiento.monto = CDec(lblMontoDeficit.Text)
        '    nMovimiento.montoUSD = CDec(0.0)
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    nMovimiento.fechaActualizacion = Date.Now
        '    nAsiento.movimiento.Add(nMovimiento)

        '    listaAsientoEnvio.Add(nAsiento)

        'End If    'fin del deficit

        ''ASIENTOS POR COSTO REAL

        ' ''3
        'nAsiento = New asiento
        'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        'nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = txtProveedor.Text
        'If chProv.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        'ElseIf chCli.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        'ElseIf chTrab.Checked = True Then
        '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        'End If
        'nAsiento.fechaProceso = DateTime.Now
        'nAsiento.periodo = PeriodoGeneral
        'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        'nAsiento.tipo = "D"
        'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        'nAsiento.importeMN = CDec(lblMontoReal.Text)
        'nAsiento.importeME = CDec(0.0)
        'nAsiento.glosa = "Por Costeo Final"
        'nAsiento.usuarioActualizacion = usuario.IDUsuario
        'nAsiento.fechaActualizacion = Date.Now


        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "713"
        'nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
        'nMovimiento.tipo = "D"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = Date.Now
        'nAsiento.movimiento.Add(nMovimiento)

        'nMovimiento = New movimiento
        'nMovimiento.cuenta = "231"
        'nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
        'nMovimiento.tipo = "H"
        'nMovimiento.monto = CDec(lblMontoReal.Text)
        'nMovimiento.montoUSD = CDec(0.0)
        'nMovimiento.usuarioActualizacion = usuario.IDUsuario
        'nMovimiento.fechaActualizacion = Date.Now
        'nAsiento.movimiento.Add(nMovimiento)

        'listaAsientoEnvio.Add(nAsiento)

    End Sub

    Sub AsientoCosteoReal922()
        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        For Each r As Record In dgvCostos.Table.Records



            If r.GetValue("operacion") = "02" Then
                nAsiento = New asiento
                nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                nAsiento.idEntidad = txtProveedor.Tag
                nAsiento.nombreEntidad = txtProveedor.Text
                If chProv.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                ElseIf chCli.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                ElseIf chTrab.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                End If
                nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
                nAsiento.tipo = "D"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                nAsiento.importeMN = CDec(r.GetValue("importe"))
                nAsiento.importeME = CDec(0.0)
                nAsiento.glosa = "Por Costeo Final"
                nAsiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


                nMovimiento = New movimiento
                nMovimiento.cuenta = r.GetValue("iditem")
                nMovimiento.descripcion = r.GetValue("descripcion")
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(r.GetValue("importe"))
                nMovimiento.montoUSD = CDec(0.0)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "231"
                nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(r.GetValue("importe"))
                nMovimiento.montoUSD = CDec(0.0)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.movimiento.Add(nMovimiento)

                listaAsientoEnvio.Add(nAsiento)

            ElseIf r.GetValue("operacion") = "10.01" Then
                'nAsiento = New asiento
                'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                'nAsiento.idEntidad = txtProveedor.Tag
                'nAsiento.nombreEntidad = txtProveedor.Text
                'If chProv.Checked = True Then
                '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                'ElseIf chCli.Checked = True Then
                '    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                'ElseIf chTrab.Checked = True Then
                '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                'End If
                'nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                'nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                'nAsiento.tipo = "D"
                'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                'nAsiento.importeMN = CDec(r.GetValue("importe"))
                'nAsiento.importeME = CDec(0.0)
                'nAsiento.glosa = "Por Costeo Final"
                'nAsiento.usuarioActualizacion = usuario.IDUsuario
                'nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


                'nMovimiento = New movimiento
                'nMovimiento.cuenta = r.GetValue("iditem")
                'nMovimiento.descripcion = r.GetValue("descripcion")
                'nMovimiento.tipo = "D"
                'nMovimiento.monto = CDec(r.GetValue("importe"))
                'nMovimiento.montoUSD = CDec(0.0)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                'nAsiento.movimiento.Add(nMovimiento)

                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "235"
                'nMovimiento.descripcion = "EXISTENCIAS DE SERVICIOS EN PROCESO"
                'nMovimiento.tipo = "H"
                'nMovimiento.monto = CDec(r.GetValue("importe"))
                'nMovimiento.montoUSD = CDec(0.0)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                'nAsiento.movimiento.Add(nMovimiento)

                'listaAsientoEnvio.Add(nAsiento)

            End If

        Next


    End Sub

    Sub AsientoCosteoReal921()
        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        For Each r As Record In dgvCostos.Table.Records



            If r.GetValue("operacion") = "02" Or r.GetValue("operacion") = "9919" Then
                nAsiento = New asiento
                nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                nAsiento.idEntidad = txtProveedor.Tag
                nAsiento.nombreEntidad = txtProveedor.Text
                If chProv.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                ElseIf chCli.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                ElseIf chTrab.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                End If
                nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
                nAsiento.tipo = "D"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                nAsiento.importeMN = CDec(r.GetValue("importe"))
                nAsiento.importeME = CDec(0.0)
                nAsiento.glosa = "Por Costeo Final"
                nAsiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


                nMovimiento = New movimiento
                'nMovimiento.cuenta = r.GetValue("iditem")
                nMovimiento.cuenta = r.GetValue("cuenta")
                nMovimiento.descripcion = r.GetValue("descripcion")
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(r.GetValue("importe"))
                nMovimiento.montoUSD = CDec(0.0)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "231"
                nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(r.GetValue("importe"))
                nMovimiento.montoUSD = CDec(0.0)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.movimiento.Add(nMovimiento)

                listaAsientoEnvio.Add(nAsiento)

            ElseIf r.GetValue("operacion") = "10.01" Then
                nAsiento = New asiento
                nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                nAsiento.idEntidad = txtProveedor.Tag
                nAsiento.nombreEntidad = txtProveedor.Text
                If chProv.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                ElseIf chCli.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                ElseIf chTrab.Checked = True Then
                    nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                End If
                nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                nAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
                nAsiento.tipo = "D"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                nAsiento.importeMN = CDec(r.GetValue("importe"))
                nAsiento.importeME = CDec(0.0)
                nAsiento.glosa = "Por Costeo Final"
                nAsiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


                nMovimiento = New movimiento
                nMovimiento.cuenta = "713"
                nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(r.GetValue("importe"))
                nMovimiento.montoUSD = CDec(0.0)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "231"
                nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(r.GetValue("importe"))
                nMovimiento.montoUSD = CDec(0.0)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.movimiento.Add(nMovimiento)

                listaAsientoEnvio.Add(nAsiento)

            End If

        Next


    End Sub



    Sub Grabar()
        Dim LibroSA As New documentoLibroDiarioSA
        Dim ndocumento As New documento()
        Dim nDocumentoLibro As New documentoLibroDiario()
        Dim objDocumentoLibroDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim objeto As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim estadoProy As String = ""
        Try

            If dgvCostos.Table.Records IsNot Nothing AndAlso dgvCostos.Table.Records.Count > 0 Then
                With ndocumento
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idEmpresa = Gempresas.IdEmpresaRuc
                    .idCentroCosto = GEstableciento.IdEstablecimiento
                    If IsNothing(GProyectos) Then
                    Else
                        .idProyecto = GProyectos.IdProyectoActividad
                    End If
                    .tipoDoc = GConfiguracion.TipoComprobante
                    .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .moneda = "1"
                    .idOrden = Nothing ' Me.IdOrden
                    .idEntidad = Val(txtProveedor.Tag)
                    .entidad = txtProveedor.Text
                    .nrodocEntidad = txtRuc.Text
                    If chProv.Checked = True Then
                        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf chCli.Checked = True Then
                        .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                    ElseIf chTrab.Checked = True Then
                        .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                    End If
                    .nroDoc = GConfiguracion.ConfigComprobante
                    .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With

                With nDocumentoLibro
                    .idEmpresa = Gempresas.IdEmpresaRuc
                    .idEstablecimiento = GEstableciento.IdEstablecimiento
                    .tipoRegistro = ""
                    .fecha = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaVct = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaPeriodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                    .idCosto = lblIdEntregable.Text
                    .tieneCosto = "P"
                    'si va ser identificado
                    .razonSocial = CInt(txtProveedor.Tag)
                    'If CheckBox2.Checked = True Then
                    If txtProveedor.Text.Trim.Length > 0 Then
                        If chProv.Checked = True Then
                            .tipoRazonSocial = TIPO_ENTIDAD.PROVEEDOR
                        ElseIf chTrab.Checked = True Then
                            .tipoRazonSocial = "TR"
                        ElseIf chCli.Checked = True Then
                            .tipoRazonSocial = TIPO_ENTIDAD.CLIENTE
                        End If

                    End If

                    'End If


                    .infoReferencial = "CIERRE DE CONSUMO POR ENTREGABLE"
                    .estado = "PREC"
                    '.tipoRazonSocial = "PR"
                    '.razonSocial = CInt(45876583)
                    .tipoDoc = GConfiguracion.TipoComprobante
                    '.nroDoc = GConfiguracion.NombreComprobante
                    .IdNumeracion = GConfiguracion.ConfigComprobante
                    .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                    .moneda = "1"
                    .tipoCambio = TmpTipoCambio
                    .importeMN = lblMontoReal.Text
                    .importeME = CDec(0.0)
                    .idReferencia = CInt(1)
                    '.tieneCosto = "N"
                    '.idCosto = idCostoGeneral
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now

                End With
                ndocumento.documentoLibroDiario = nDocumentoLibro


                'recurso real
                For Each r As Record In dgvCostos.Table.Records
                    objeto = New recursoCostoDetalle
                    If r.GetValue("operacion") = "9919" Or r.GetValue("operacion") = "02" Then  'para asientos manuales

                        Dim cuenta = r.GetValue("cuenta")

                        Dim nombreCuenta = (From cue In ListaContable
                                                                       Where cue.cuenta = cuenta
                                                                       Select cue.descripcion).FirstOrDefault


                        objeto.idCosto = lblIdEntregable.Text
                        objeto.secuencia = r.GetValue("secuencia")
                        objeto.fechaRegistro = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        'objeto.iditem = CInt(r.GetValue("iditem"))
                        'objeto.descripcion = r.GetValue("descripcion")
                        objeto.iditem = CInt(r.GetValue("cuenta"))
                        objeto.descripcion = CStr(nombreCuenta)
                        objeto.Periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                        objeto.cant = CDec(r.GetValue("cantidad"))
                        objeto.montoMN = CDec(r.GetValue("importe"))
                        objeto.montoME = CDec(0.0)
                        objeto.operacion = r.GetValue("operacion")
                        objeto.elementoCosto = r.GetValue("elementoCosto")
                        objeto.motivoCosto = cboMotivoCosto.Text
                        objeto.procesado = "S"
                        objeto.tipoCosto = "RC"
                        objeto.idProceso = lblIdEntregable.Text
                        objeto.fechaTrabajo = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        lista.Add(objeto)


                    Else

                        objeto.idCosto = lblIdEntregable.Text
                        objeto.secuencia = r.GetValue("secuencia")
                        objeto.fechaRegistro = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        objeto.iditem = CInt(r.GetValue("iditem"))
                        objeto.destino = r.GetValue("destino")
                        objeto.Periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                        objeto.descripcion = r.GetValue("descripcion")
                        objeto.um = r.GetValue("um")
                        objeto.cant = CDec(r.GetValue("cantidad"))
                        objeto.puMN = CDec(r.GetValue("precio"))
                        objeto.puME = CDec(0.0)
                        objeto.montoMN = CDec(r.GetValue("importe"))
                        objeto.montoME = CDec(0.0)
                        objeto.operacion = r.GetValue("operacion")
                        objeto.elementoCosto = r.GetValue("elementoCosto")
                        objeto.motivoCosto = cboMotivoCosto.Text

                        objeto.procesado = "S"
                        objeto.tipoCosto = "RC"
                        objeto.idProceso = lblIdEntregable.Text
                        objeto.fechaTrabajo = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        lista.Add(objeto)
                    End If
                Next

                If lblTipoProyecto.Text = "HC -PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Then
                    AsientosCosteo922()
                    'AsientoCosteoReal922()
                    AsientoCosteoReal921()
                    estadoProy = "COS"
                ElseIf lblTipoProyecto.Text = "HC -COSTOS POR VALORACION" Then
                    AsientosCosteo921()
                    AsientoCosteoReal921()

                    If cboestadovalorizado.Text = "VALORIZAR" Then
                        estadoProy = "VAL"
                    ElseIf cboestadovalorizado.Text = "VALORIZAR Y CONCLUIR PROYECTO" Then
                        estadoProy = "EJE"
                    End If


                ElseIf lblTipoProyecto.Text = "HC -PROCESO PRODUCTIVO A VALORES ESTANDAR" Then


                End If




                ndocumento.asiento = listaAsientoEnvio


                LibroSA.GrabarDocumentoProyecto(ndocumento, lblIdEntregable.Text, lista, estadoProy)


                Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar")
        End Try
    End Sub




    Public Sub GrabarAregloCosto()
        Dim objeto As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim recursocostoSA As New recursoCostoDetalleSA

        Try

            If dgvCostos.Table.Records IsNot Nothing AndAlso dgvCostos.Table.Records.Count > 0 Then
                For Each r As Record In dgvCostos.Table.Records
                    objeto = New recursoCostoDetalle

                    objeto.idCosto = lblIdEntregable.Text
                    objeto.secuencia = r.GetValue("secuencia")
                    objeto.fechaRegistro = DateTime.Now
                    objeto.iditem = CInt(r.GetValue("iditem"))
                    objeto.destino = r.GetValue("destino")

                    objeto.descripcion = r.GetValue("descripcion")
                    objeto.um = r.GetValue("um")
                    objeto.cant = CDec(r.GetValue("cantidad"))
                    objeto.puMN = CDec(r.GetValue("precio"))
                    objeto.puME = CDec(0.0)
                    objeto.montoMN = CDec(r.GetValue("importe"))
                    objeto.montoME = CDec(0.0)
                    objeto.operacion = r.GetValue("operacion")

                    objeto.procesado = "S"
                    objeto.tipoCosto = "RC"
                    objeto.idProceso = lblIdEntregable.Text
                    objeto.fechaTrabajo = DateTime.Now
                    objeto.Periodo = PeriodoGeneral





                    lista.Add(objeto)
                Next

                recursocostoSA.GrabarDetalleCosteoReal(lista, lblIdEntregable.Text, lblIdDocumento.Text, lblidSecuencia.Text)

                Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar")
        End Try
    End Sub


    Private Sub GetListadoRecursosPorEntregable(idEntregable As Integer, fechaPeriodo As DateTime)
        Dim costoSA As New recursoCostoDetalleSA
        Dim montoCostoProduccion As Decimal = CDec(0.0)
        dgvCostos.TableDescriptor.GroupedColumns.Clear()


        Dim dt As New DataTable


        dt.Columns.Add("documentoRef")
        dt.Columns.Add("iditem")
        dt.Columns.Add("destino")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        dt.Columns.Add("operacion")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("Periodo")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("precio")
        dt.Columns.Add("importe")

        dt.Columns.Add("secuencia")

        dt.Columns.Add("cuenta", GetType(String))


        dt.Columns.Add("elementoCosto")


        For Each i In costoSA.GetListadoRecursosPorEntregable(idEntregable, fechaPeriodo)
            Dim dr As DataRow = dt.NewRow

            dr(0) = i.documentoRef
            dr(1) = i.iditem
            dr(2) = i.destino
            dr(3) = i.descripcion
            dr(4) = i.um
            dr(5) = i.cant - i.cantidadCosto

            dr(6) = i.montoMN - i.montoCosto
            dr(7) = CDec(0.0)

            dr(8) = i.operacion
            dr(9) = i.fechaTrabajo
            dr(10) = i.Periodo
            dr(11) = CDec(0.0)




            If (i.cant - i.cantidadCosto) > 0 Then
                dr(12) = i.montoMN / i.cant
            Else

                dr(12) = CDec(0.0)
            End If



            dr(13) = CDec(0.0)

            dr(14) = i.secuencia

            dr(16) = i.elementoCosto

            If (i.montoMN - i.montoCosto) > 0 Then

                dt.Rows.Add(dr)

            End If

            montoCostoProduccion += CDec(i.montoMN)
            montoCostoProduccion -= CDec(i.montoCosto)

        Next
        dgvCostos.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,

        lblmontoCosteado.Text = montoCostoProduccion



    End Sub


    Public Sub GetItems()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable

        dt.Columns.Add("documentoRef")
        dt.Columns.Add("iditem")
        dt.Columns.Add("destino")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        dt.Columns.Add("operacion")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("Periodo")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("precio")
        dt.Columns.Add("importe")

        dt.Columns.Add("secuencia")
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("elementoCosto")

        dgvCostos.DataSource = dt

    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
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
#End Region
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmConsumoDeProduccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA



        Dim dt As New DataTable()
        dt.Columns.Add("cuenta", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))



        'If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
        ListaContable = cuentaSA.CuentasServicios(Gempresas.IdEmpresaRuc).ToList
        'For Each i In cuentaSA.CuentasServicios(Gempresas.IdEmpresaRuc).ToList
        For Each i In ListaContable

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta & "-" & i.descripcion
            dt.Rows.Add(dr)
        Next

        'Else
        'For Each i In almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idAlmacen
        '    dr(1) = i.descripcionAlmacen
        '    dt.Rows.Add(dr)
        'Next
        'End If


        Return dt
    End Function


    Dim comboTableP As New DataTable
    Private Sub frmConsumoDeProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If lblTipoProyecto.Text = "HC -COSTOS POR VALORACION" Then
            Label11.Visible = True

            cboestadovalorizado.Visible = True
        End If

        'ComboBoxAdv1.SelectedIndex = -1
        comboTableP = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvCostos.TableDescriptor.Columns(15).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTableP
        ggcStyle.ValueMember = "cuenta"
        ggcStyle.DisplayMember = "descripcion"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCostos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCostos.ShowRowHeaders = False

        GetListadoRecursosPorEntregable(lblIdEntregable.Text, DateTime.Now)
    End Sub

    Private Sub dgvCostos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCostos.QueryCellStyleInfo

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then

                'Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 8).CellValue
                'Select Case str
                '    Case "GS"
                '        e.Style.[ReadOnly] = False
                '        e.Style.BackColor = Color.AliceBlue
                '        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                '        If IsNumeric(e.Style.CellValue) Then
                '            If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                '                e.Style.CellValue = 1
                '            End If
                '        Else
                '            e.Style.CellValue = 1
                '        End If

                '    Case "08"
                '        e.Style.[ReadOnly] = False
                '        e.Style.BackColor = Color.AliceBlue
                '        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing

                '        If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                '            e.Style.CellValue = 1
                '        End If

                '    Case Else
                '        e.Style.[ReadOnly] = True
                '        e.Style.BackColor = Color.AliceBlue
                'End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 9).CellValue
                Select Case str
                    Case "02"
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case "10.01"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1

                    Case "9919"
                        e.Style.[ReadOnly] = True
                    Case Else
                        'e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.Yellow
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importe")) Then
                Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 9).CellValue
                Select Case str
                    Case "02"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case "10.01"
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1
                    Case "9919"
                        e.Style.[ReadOnly] = False

                    Case Else
                        'e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.Yellow
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cuenta")) Then
                Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 9).CellValue
                Select Case str
                    Case "02"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case "10.01"
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1
                    Case "9919"
                        e.Style.[ReadOnly] = False

                    Case Else
                        'e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.Yellow
                End Select
            Else
                'e.Style.[ReadOnly] = False
            End If


        End If



        'If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
        '    'Checks for the column name when the cellvalue is greater than 5.
        '    'ENTRADAS A ALMACEN
        '    If e.TableCellIdentity.Column.MappingName = "operacion" AndAlso CDbl(Fix(e.Style.CellValue)) > "10.1" Then
        '        If e.TableCellIdentity.Column.MappingName = "cantidad" Then
        '            e.Style.ReadOnly = True
        '        End If
        '        If e.TableCellIdentity.Column.MappingName = "importe" Then
        '            e.Style.ReadOnly = False
        '        End If


        '    ElseIf e.TableCellIdentity.Column.MappingName = "operacion" AndAlso CDbl(Fix(e.Style.CellValue)) > "02" Then
        '        If e.TableCellIdentity.Column.MappingName = "cantidad" Then
        '            e.Style.ReadOnly = False
        '        End If
        '        If e.TableCellIdentity.Column.MappingName = "importe" Then
        '            e.Style.ReadOnly = True
        '        End If
        '    End If


        '    'SALIDAS A ALMACEN


        'End If
    End Sub

    Private Sub dgvCostos_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCostos.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCostos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCostos.TableControlCellClick

    End Sub


    Public Sub calculardeficit()
        Dim monntoCosteado As Decimal = CDec(0.0)


        For Each r As Record In dgvCostos.Table.Records

            monntoCosteado += r.GetValue("importe")
        Next

        lblMontoReal.Text = monntoCosteado

        lblMontoDeficit.Text = lblmontoCosteado.Text - lblMontoReal.Text

    End Sub

    Private Sub dgvCostos_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCostos.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCostos_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCostos.TableControlKeyDown
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 12 Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                            If Me.dgvCostos.Table.CurrentRecord.GetValue("cant") > 0 Then


                                If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cant")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad")) Then

                                    Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                                Else
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                                End If

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        End If
                    ElseIf cc.ColIndex = 14 Then
                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        ElseIf Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "9919" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        End If
                    End If

                End If
            End If

            calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCostos_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCostos.TableControlKeyPress
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 12 Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                            If Me.dgvCostos.Table.CurrentRecord.GetValue("cant") > 0 Then


                                If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cant")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad")) Then

                                    Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                                Else
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                                End If

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        End If
                    ElseIf cc.ColIndex = 14 Then
                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        ElseIf Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "9919" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        End If
                    End If

                End If
            End If

            calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCostos_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCostos.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 12 Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                            If Me.dgvCostos.Table.CurrentRecord.GetValue("cant") > 0 Then


                                If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cant")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad")) Then

                                    Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                                Else
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                                End If

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        End If
                    ElseIf cc.ColIndex = 14 Then
                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        ElseIf Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "9919" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        End If
                    End If

                End If
            End If

            calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ' GrabarAregloCosto()


        For Each r As Record In dgvCostos.Table.Records
            If CStr(r.GetValue("operacion")) = "02" Or CStr(r.GetValue("operacion")) = "9919" Then

                If r.GetValue("importe") > 0 Then

                    Dim alm = r.GetValue("cuenta")
                    If alm.ToString.Trim.Length > 0 Then
                        'objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacen"))
                    Else


                        MessageBox.Show("Inghre una Cuenta para el servicio")
                        Exit Sub
                    End If

                End If
            End If
        Next


        Me.Cursor = Cursors.WaitCursor
        Dim codProv = txtProveedor.Tag
        If IsNothing(codProv) Then
            MessageBox.Show("Ingrese una Identificación")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not codProv.ToString.Trim.Length > 0 Then
            MessageBox.Show("Ingrese una Identificación")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If


        If Not lblMontoReal.Text > 0 Then
            MessageBox.Show("El costeo debe ser mayor a 0")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Grabar()
        Me.Cursor = Cursors.Arrow
    End Sub

    

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub txtProveedor_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel(TIPO_ENTIDAD.PERSONA_GENERAL, txtProveedor.Text.Trim)
            ElseIf chCli.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()

    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chCli.Checked = False
        chTrab.Checked = True
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing

        txtRuc.Clear()
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Tag = Nothing
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                'txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub cboAnio_Click(sender As Object, e As EventArgs) Handles cboAnio.Click

    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            If cboMesCompra.Text.Trim.Length > 0 Then
                ' lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                txtPeriodo.Value = GetPeriodoConvertirToDate(cboMesCompra.SelectedValue & "/" & cboAnio.Text)
            End If
        End If
    End Sub

    Private Sub cboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        cboAnio_SelectedValueChanged(sender, e)
    End Sub
End Class