Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmSaldos
    Inherits frmMaster
    Private dataSource As DataTable
    Public Property fecha() As DateTime
    Public Property ManipulacionEstado() As String

    Private gGCFilter As GroupingGridFilterBarExt
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        GConfiguracion = New GConfiguracionModulo
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        Dim syncProducts As New StringCollection()
        syncProducts.Add("DEBE")
        syncProducts.Add("HABER")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dgvCompra.TableDescriptor.Columns(5).Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox
        Me.dgvCompra.TableDescriptor.Columns(5).Appearance.AnyRecordFieldCell.ChoiceList = syncProducts
        Me.dgvCompra.TableDescriptor.Columns(5).Appearance.AnyRecordFieldCell.CellValue = "Trial1"
        dgvCompra.DataSource = GetTableGrid()
        ManipulacionEstado = ENTITY_ACTIONS.INSERT
        lblPerido.Text = PeriodoGeneral
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "SI", Me.Text, GEstableciento.IdEstablecimiento)
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

#Region "Métodos"
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

    Public Function GetTableCuentas() As DataTable
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(Integer))
        dt.Columns.Add("nombre", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            Me.lstEntidades.DisplayMember = "nombreCompleto"
            Me.lstEntidades.ValueMember = "idEntidad"

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajas(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            Me.lstEntidades.DataSource = estadoSA.ObtenerEstadosFinancierosPorMonedaXdescripcion(GEstableciento.IdEstablecimiento, Nothing, strBusqueda)
            Me.lstEntidades.DisplayMember = "descripcion"
            Me.lstEntidades.ValueMember = "idestado"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            Me.lstEntidades.DataSource = personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
            Me.lstEntidades.DisplayMember = "nombreCompleto"
            Me.lstEntidades.ValueMember = "idPersona"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvMercaderia.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.presentacion)
            n.SubItems.Add(i.origenProducto)
            lsvMercaderia.Items.Add(n)
        Next

    End Sub

    Private Function GetTableGrid() As DataTable
        Dim tablaSA As New tablaDetalleSA

        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("idModulo", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("HaberMN", GetType(Decimal))
        dt.Columns.Add("HaberME", GetType(Decimal))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("idAlmacen", GetType(String))
        Return dt
    End Function
#End Region

#Region "Métodos Manipulación Data"
    Private Function AsientoSaldos() As asiento
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtProveedor.ValueMember
        nAsiento.nombreEntidad = Nothing ' txtProveedor.Text
        nAsiento.tipoEntidad = Nothing ' TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = "AS-SAI" 'ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = ConteoMN
        nAsiento.importeME = ConteoME
        nAsiento.glosa = "Saldo de inicio"
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now

        For Each r As Record In dgvCompra.Table.Records
            nMovimiento = New movimiento
            nMovimiento.cuenta = r.GetValue("cuenta")
            nMovimiento.descripcion = r.GetValue("Modulo")
            Select Case r.GetValue("tipoAsiento")
                Case "DEBE"
                    nMovimiento.tipo = "D"
                Case Else
                    nMovimiento.tipo = "H"
            End Select
            nMovimiento.monto = r.GetValue("importeMN")
            nMovimiento.montoUSD = r.GetValue("importeME")
            nMovimiento.usuarioActualizacion = "Jiuni"
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next

        Return nAsiento
    End Function
    Dim ConteoMN As Integer = 0
    Dim ConteoME As Integer = 0
    Sub Grabar()
        Dim CompraSA As New saldoInicioSA
        Dim ndocumento As New documento()
        Dim almacenSA As New almacenSA

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New saldoInicio()
        Dim objDocumentoCompraDet As New saldoInicioDetalle
        Dim entidadSA As New entidadSA
        Dim listaAsiento As New List(Of asiento)
        Dim entidad As New entidad

        Dim nMovimiento As New movimiento
        Dim ListaDetalle As New List(Of saldoInicioDetalle)
        Dim asientoBE As New asiento

        ConteoMN = 0
        ConteoME = 0

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "9901"
            .fechaProceso = fecha
            ' .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "8"
            .tipoDoc = "9901"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .periodo = PeriodoGeneral
            .serie = GConfiguracion.Serie
            .numeroDoc = Nothing
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")


            .importeTotal = 0
            .importeUS = 0
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = "Por saldo de inicio"
            .tipoCompra = TIPO_COMPRA.SALDO_INICIAL
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.saldoInicio = nDocumentoCompra

        If dgvCompra.Table.Records IsNot Nothing AndAlso dgvCompra.Table.Records.Count > 0 Then
            For Each r As Record In dgvCompra.Table.Records
                objDocumentoCompraDet = New saldoInicioDetalle
                objDocumentoCompraDet.modulo = r.GetValue("tipoEx")
                objDocumentoCompraDet.idModulo = r.GetValue("idModulo")
                objDocumentoCompraDet.descripcionItem = r.GetValue("cuenta")
                '  objDocumentoCompraDet.descripcionItem = r.GetValue("Modulo")
                '  objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                Dim s As String = r.GetValue("tipoAsiento").ToString
                If s.Trim.Length > 0 Then
                    Select Case r.GetValue("tipoAsiento")
                        Case "DEBE"
                            objDocumentoCompraDet.tipoAsiento = "D"
                        Case Else
                            objDocumentoCompraDet.tipoAsiento = "H"
                    End Select
                Else
                    lblEstado.Text = "Debe indicar la ubicación del asiento!"
                    Exit Sub
                End If
                objDocumentoCompraDet.importe = r.GetValue("importeMN")
                objDocumentoCompraDet.importeUS = r.GetValue("importeME")
                ConteoMN += CDec(r.GetValue("importeMN"))
                ConteoME += CDec(r.GetValue("importeME"))
                Select Case r.GetValue("tipoEx")
                    Case "MR"
                        Dim s1 As String = r.GetValue("idAlmacen").ToString
                        If s1.Trim.Length > 0 Then
                            objDocumentoCompraDet.almacen = CInt(r.GetValue("idAlmacen"))
                        Else
                            lblEstado.Text = "Debe indicar un almacén de destino!"
                            Exit Sub
                        End If
                End Select
                objDocumentoCompraDet.usuarioModificacion = "Jiuni"
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objDocumentoCompraDet)
            Next r
        End If
        ndocumento.saldoInicio.importeTotal = ConteoMN
        ndocumento.saldoInicio.importeUS = ConteoME
        listaAsiento = New List(Of asiento)
        listaAsiento.Add(AsientoSaldos)
        ndocumento.asiento = listaAsiento
        ndocumento.saldoInicio.saldoInicioDetalle = ListaDetalle

        Dim xcod As Integer = CompraSA.InsertarSaldos(ndocumento)
        lblEstado.Text = "compra registrada!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub
#End Region

    Private Sub frmSaldos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmSaldos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        comboTable = Me.GetTableAlmacen
        comboTableCuentas = Me.GetTableCuentas
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(10).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"

        Dim ggcStyle1 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell
        ggcStyle1.CellType = "ComboBox"
        ggcStyle1.DataSource = Me.comboTableCuentas
        ggcStyle1.ValueMember = "idCuenta"
        ggcStyle1.DisplayMember = "nombre"


        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Quitar item")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Quitar item" Then
                Me.dgvCompra.Table.CurrentRecord.Delete()
            End If
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                pcEntidad.Font = New Font("Segoe UI", 8)
                Me.pcEntidad.ParentControl = Me.txtRuc
                Me.pcEntidad.ShowPopup(Point.Empty)
                Select Case cboTipoEntidad.Text
                    Case "PROVEEDOR"
                        CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtRuc.Text.Trim)
                    Case "CLIENTE"
                        CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtRuc.Text.Trim)
                    Case "CAJA"
                        CargarCajas(txtRuc.Text.Trim)
                    Case "PRESTAMOS OTORGADOS", "PRESTAMOS RECIBIDOS"
                        Select Case cboPrestamos.Text
                            Case "Proveedor"
                                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtRuc.Text.Trim)
                            Case "Cliente"
                                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtRuc.Text.Trim)
                            Case "Personal"
                                CargarTrabajadoresXnivel("TR", txtRuc.Text.Trim)
                            Case "Otros"
                                CargarTrabajadoresXnivel("OT", txtRuc.Text.Trim)
                        End Select
                End Select
            End If
        End If
    End Sub

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged

    End Sub

    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.pcEntidad.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstEntidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEntidades.SelectedIndexChanged

    End Sub

    Private Sub pcEntidad_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcEntidad.BeforePopup
        Me.pcEntidad.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcEntidad.CloseUp
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstEntidades.SelectedItems.Count > 0 Then
                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)

                Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", lstEntidades.SelectedValue)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lstEntidades.Text)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                Select Case cboTipoEntidad.Text
                    Case "CLIENTE"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "CL")
                        With entidadSA.UbicarEntidadPorID(lstEntidades.SelectedValue).First
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", .cuentaAsiento)
                        End With

                    Case "PROVEEDOR"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "PR")
                        With entidadSA.UbicarEntidadPorID(lstEntidades.SelectedValue).First
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", .cuentaAsiento)
                        End With
                    Case "CAJA"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "CA")
                        With cajaSA.GetUbicar_estadosFinancierosPorID(lstEntidades.SelectedValue)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", .cuenta)
                        End With
                    Case "PRESTAMOS OTORGADOS"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "POT")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 0)

                    Case "PRESTAMOS RECIBIDOS"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "PRE")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 0)
                End Select
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtRuc.Focus()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Grabar()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub txtFiltroMercaderia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltroMercaderia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            pcMercaderia.Font = New Font("Segoe UI", 8)
            Me.pcMercaderia.ParentControl = Me.txtFiltroMercaderia
            Me.pcMercaderia.ShowPopup(Point.Empty)
            lsvMercaderia.FullRowSelect = True
            If txtFiltroMercaderia.Text.Trim.Length > 0 Then
                ListaMercaderias(cboTipoExistencia.SelectedValue, txtFiltroMercaderia.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtFiltroMercaderia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltroMercaderia.TextChanged

    End Sub

    Private Sub pcMercaderia_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcMercaderia.BeforePopup
        Me.pcMercaderia.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcMercaderia_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcMercaderia.CloseUp
        Dim entidadSA As New entidadSA
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvMercaderia.SelectedItems.Count > 0 Then
                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", lsvMercaderia.SelectedItems(0).SubItems(0).Text)
                Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lsvMercaderia.SelectedItems(0).SubItems(1).Text)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "MR")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "21") '
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtFiltroMercaderia.Focus()
        End If
    End Sub

    Private Sub lsvMercaderia_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvMercaderia.MouseDoubleClick
        If lsvMercaderia.SelectedItems.Count > 0 Then
            Me.pcMercaderia.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        'If e.TableCellIdentity.Column IsNot Nothing Then
        '    If e.TableCellIdentity.Column.Name = "importeMN" Then
        '        e.Style.BackColor = Color.Aqua
        '        e.Style.ReadOnly = True
        '        If e.tabl Then

        '        End If
        '    End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim col1 = Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 6).CellValue
            Select Case col1
                Case "DEBE"
                    Me.dgvCompra.TableDescriptor.Columns("importeMN").Appearance.AnyRecordFieldCell.[ReadOnly] = False
                    Me.dgvCompra.TableDescriptor.Columns("importeME").Appearance.AnyRecordFieldCell.[ReadOnly] = False

                    Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 9).CellValue = 0
                    Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 10).CellValue = 0

                    Me.dgvCompra.TableDescriptor.Columns("HaberMN").Appearance.AnyRecordFieldCell.[ReadOnly] = True
                    Me.dgvCompra.TableDescriptor.Columns("HaberME").Appearance.AnyRecordFieldCell.[ReadOnly] = True



                Case "HABER"
                    Me.dgvCompra.TableDescriptor.Columns("HaberMN").Appearance.AnyRecordFieldCell.[ReadOnly] = False
                    Me.dgvCompra.TableDescriptor.Columns("HaberME").Appearance.AnyRecordFieldCell.[ReadOnly] = False

                    Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 7).CellValue = 0
                    Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 8).CellValue = 0

                    Me.dgvCompra.TableDescriptor.Columns("importeMN").Appearance.AnyRecordFieldCell.[ReadOnly] = True
                    Me.dgvCompra.TableDescriptor.Columns("importeME").Appearance.AnyRecordFieldCell.[ReadOnly] = True


            End Select

        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellStartEditing(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellStartEditing

    End Sub

    Private Sub dgvCompra_TextChanged(sender As Object, e As EventArgs) Handles dgvCompra.TextChanged

    End Sub

    Private Sub cboTipoEntidad_Click(sender As Object, e As EventArgs) Handles cboTipoEntidad.Click

    End Sub

    Private Sub cboTipoEntidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoEntidad.SelectedIndexChanged
        If cboTipoEntidad.Text = "OTRO" Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", "asignar una descripción")
            Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "OT")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            cboPrestamos.Visible = False
        ElseIf cboTipoEntidad.Text = "PRESTAMOS OTORGADOS" Or cboTipoEntidad.Text = "PRESTAMOS RECIBIDOS" Then
            cboPrestamos.Visible = True
        Else
            cboPrestamos.Visible = False
        End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub
End Class