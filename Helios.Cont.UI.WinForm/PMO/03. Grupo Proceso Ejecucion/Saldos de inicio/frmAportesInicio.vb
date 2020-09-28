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
Public Class frmAportesInicio
    Inherits frmMaster

    Public Property ListaMovimientos As New List(Of movimiento)
    Public Property ListaAsientonTransito As New List(Of asiento)
    Private dataSource As DataTable
    Public Property fecha() As DateTime
    Public Property ManipulacionEstado() As String

    Private gGCFilter As GroupingGridFilterBarExt
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GConfiguracion = New GConfiguracionModulo
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        'Dim syncProducts As New StringCollection()
        'syncProducts.Add("DEBE")
        'syncProducts.Add("HABER")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.dgvCompra.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox
        'Me.dgvCompra.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell.ChoiceList = syncProducts
        'Me.dgvCompra.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell.CellValue = "Trial1"
        dgvCompra.DataSource = GetTableGrid()
        ManipulacionEstado = ENTITY_ACTIONS.INSERT
        lblPerido.Text = PeriodoGeneral
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "SI", Me.Text, GEstableciento.IdEstablecimiento)
        ListaDefaultDeInicio()

        dgvCompra.TableDescriptor.GroupedColumns.Clear()
        dgvCompra.TableDescriptor.GroupedColumns.Add("tipoEx")

        txtTipoCambio.Value = TmpTipoCambio

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtRuc.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtRuc.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function


#Region "metodos"

    Sub CBOCuentas(IntPadre As String)
        Dim asientoSA As New cuentaplanContableEmpresaSA
        Dim DT As New DataTable("Table1")
        DT.Columns.Add("cuenta")
        DT.Columns.Add("descripcion")

        For Each i In asientoSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, IntPadre)
            Dim dr As DataRow = DT.NewRow
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            DT.Rows.Add(dr)
        Next

        Dim view As DataView = New DataView(DT)

        ' DATASOURCE is DATAVIEW

        Me.cboCuenta.DataSource = view

        Me.cboCuenta.DisplayMember = "descripcion"

        Me.cboCuenta.ValueMember = "cuenta"

        cboCuenta.SelectedIndex = -1
    End Sub


    Public Function GetTableAlmacen2() As DataTable


        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(Integer))
        dt.Columns.Add("descripcionCuenta", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = ListaMovimientos.Count + 1
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub


    Sub GetasientosListbox()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")

        For Each i In ListaAsientonTransito
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAsiento
            dr(1) = i.Descripcion
            dt.Rows.Add(dr)
        Next

        lstAsiento.DisplayMember = "nombre"
        lstAsiento.ValueMember = "id"
        lstAsiento.DataSource = dt
    End Sub

    Sub RegistrarAsientos()
        Dim nAsiento As New asiento

        If ListaAsientonTransito.Count > 0 Then
            nAsiento.idAsiento = ListaAsientonTransito.Count + 1
        Else
            nAsiento.idAsiento = 1
        End If
        nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
        ListaAsientonTransito.Add(nAsiento)

        GetasientosListbox()
    End Sub



    Sub updateMovimiento(r As Record)
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaMovimientos _
                       Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                consulta.descripcion = cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, r.GetValue("cuenta")).descripcion
                Dim strTip = r.GetValue("tipoAsiento").ToString
                If CStr(strTip).Trim.Length > 0 Then
                    consulta.tipo = r.GetValue("tipoAsiento")
                Else
                    consulta.tipo = String.Empty
                End If
                Select Case consulta.tipo
                    Case "D"
                        Dim monto = r.GetValue("importeMN").ToString
                        If monto.Trim.Length > 0 Then
                            consulta.monto = CDec(r.GetValue("importeMN"))
                        Else
                            consulta.monto = 0
                        End If

                        Dim montoUSD = r.GetValue("importeME").ToString
                        If montoUSD.Trim.Length > 0 Then
                            consulta.montoUSD = CDec(r.GetValue("importeME"))
                        Else
                            consulta.montoUSD = 0
                        End If
                    Case "H"
                        Dim monto = r.GetValue("HaberMN").ToString
                        If monto.Trim.Length > 0 Then
                            consulta.monto = CDec(r.GetValue("HaberMN"))
                        Else
                            consulta.monto = 0
                        End If

                        Dim montoUSD = r.GetValue("HaberME").ToString
                        If montoUSD.Trim.Length > 0 Then
                            consulta.montoUSD = CDec(r.GetValue("HaberME"))
                        Else
                            consulta.montoUSD = 0
                        End If
                End Select

            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub


#End Region


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

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
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
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

#Region "PROVEEDOR"
    Public Sub InsertCaja()
        Dim caja As New estadosFinancieros
        Dim cajaSA As New EstadosFinancierosSA
        Try
            'Se asigna cada uno de los datos registrados
            With caja
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                If rbEfectivo.Checked = True Then
                    .cuenta = "101"
                    .tipo = "EF"
                    .nroCtaCorriente = Nothing
                Else
                    .cuenta = "104"
                    .tipo = "BC"
                    .nroCtaCorriente = txtNumCuentaBco.Text.Trim
                End If
                If nudMoneda.Text = "NACIONAL" Then
                    .codigo = "1"
                Else
                    .codigo = "2"
                End If
                .descripcion = txtNomCaja.Text.Trim
                .predeterminado = "N"
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = cajaSA.InsertEF(caja)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            'lblEstado.Image = My.Resources.ok4

            'Dim n As New ListViewItem(codx)
            'n.SubItems.Add(objCliente.nombreCompleto)
            'n.SubItems.Add(objCliente.cuentaAsiento)
            'n.SubItems.Add(objCliente.nrodoc)
            'lsvProveedor.Items.Add(n)

            'txtProveedor.ValueMember = codx
            'txtProveedor.Text = objCliente.nombreCompleto
            'txtRuc.Text = objCliente.nrodoc
            'txtCuenta.Text = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ListaDefaultDeInicio()
        Dim tablaSA As New tablaDetalleSA
        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Top, 64)
        dockingManager1.DockControlInAutoHideMode(GradientPanel3, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 245)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(GradientPanel3, "Asiento contable")
        dockingManager1.SetDockLabel(Panel2, "Otros aportes")
        dockingManager1.CloseEnabled = False
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

#Region "Glosa"
    Sub Glosa()
        Dim strAportantes As String = Nothing
        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoEx") = "TR" Then
                strAportantes = strAportantes & " - " & r.GetValue("Modulo")
            End If
        Next
        txtGlosa.Text = "Por los aportes de: " & strAportantes & " de fecha " & txtFechaComprobante.Value
    End Sub

    Public Sub UbicarSaldoPorIdDocumento(IntIdDocumento As Integer)
        Dim saldoInicioSA As New saldoInicioSA
        Dim saldoInicioDetalleSA As New saldoInicioDetalleSA
        Dim productoSA As New detalleitemsSA
        Dim producto As New detalleitems
        Dim EFSA As New EstadosFinancierosSA
        Dim entidadSA As New entidadSA
        Dim person As New PersonaSA
        Try
            With saldoInicioSA.UbicarSaldoXidDocumento(IntIdDocumento)
                fecha = .fechaDoc
                lblPerido.Text = PeriodoGeneral
                cboMoneda.SelectedValue = .monedaDoc
                txtFechaComprobante.Value = .fechaDoc
                txtGlosa.Text = .glosa
                Select Case .tipoCompra
                    Case TIPO_COMPRA.SALDO_INICIAL
                        CBOMovimiento.Text = "SALDO DE INICIO"
                    Case TIPO_COMPRA.APORTE_INICIAL
                        CBOMovimiento.Text = "APORTES"
                End Select

                'With person.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, .idPersona, "TR")
                '    txtPersona.ValueMember = .idPersona
                '    txtPersona.Text = .nombreCompleto
                'End With

            End With

            For Each i In saldoInicioDetalleSA.ListadoDetalleSaldoXidDocumento(IntIdDocumento)
                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("id", i.secuencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", i.idModulo)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.cantidad)
                Select Case i.modulo
                    Case "MR"
                        producto = productoSA.InvocarProductoID(i.idModulo)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idAlmacen", i.almacen)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", producto.descripcionItem)
                    Case "CA"
                        With EFSA.GetUbicar_estadosFinancierosPorID(i.idModulo)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .descripcion)
                        End With
                    Case "PR"
                        With entidadSA.UbicarEntidadPorID(i.idModulo).First
                            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .nombreCompleto)
                        End With
                    Case "CL"
                        With entidadSA.UbicarEntidadPorID(i.idModulo).First
                            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .nombreCompleto)
                        End With
                    Case "TR"
                        With person.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idModulo, "TR")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .nombreCompleto)
                        End With

                    Case Else
                        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", i.modulo)
                End Select
                Select Case i.tipoAsiento
                    Case "D"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", i.importe)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", i.importeUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                    Case "H"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", i.importe)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", i.importeUS)
                End Select


                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", i.modulo)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", i.descripcionItem) '


                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            ToolStrip3.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        dt.Columns.Add("unidad", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("HaberMN", GetType(Decimal))
        dt.Columns.Add("HaberME", GetType(Decimal))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("idAlmacen", GetType(String))
        dt.Columns.Add("utiMenor", GetType(Decimal))
        dt.Columns.Add("utiMayor", GetType(Decimal))
        dt.Columns.Add("utiGranMayor", GetType(Decimal))
        dt.Columns.Add("destino", GetType(String))
        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("colModVenta", GetType(Boolean))
        dt.Columns.Add("valCheck", GetType(String))
        dt.Columns.Add("nomCuenta", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
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
        nAsiento.codigoLibro = "5"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = "AS-SAI" 'ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = SumaTotalDebeMN
        nAsiento.importeME = SumaTotalDebeME
        nAsiento.glosa = "Aportes de inicio"
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now

        For Each r As Record In dgvCompra.Table.Records
            nMovimiento = New movimiento
            nMovimiento.cuenta = r.GetValue("cuenta")
            nMovimiento.descripcion = r.GetValue("Modulo")
            Select Case r.GetValue("tipoAsiento")
                Case "DEBE"
                    nMovimiento.tipo = "D"
                    nMovimiento.monto = r.GetValue("importeMN")
                    nMovimiento.montoUSD = r.GetValue("importeME")
                Case Else
                    nMovimiento.tipo = "H"
                    nMovimiento.monto = r.GetValue("HaberMN")
                    nMovimiento.montoUSD = r.GetValue("HaberME")
            End Select

            nMovimiento.usuarioActualizacion = "Jiuni"
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next

        Return nAsiento
    End Function
    'Dim ConteoMN As Integer = 0
    'Dim ConteoME As Integer = 0



    Sub generarAsientoMuestra(Grid As GridGroupingControl)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("haberMN", GetType(Decimal))
        dt.Columns.Add("haberME", GetType(Decimal))
        'GridGroupingControl1.DataSource = dt

        For Each i As Record In Grid.Table.Records
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.GetValue("cuenta")
            dr(1) = i.GetValue("nomCuenta") ' cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, i.GetValue("cuenta")).descripcion
            dr(2) = i.GetValue("Modulo")
            Select Case i.GetValue("tipoAsiento")
                Case "DEBE"
                    dr(3) = i.GetValue("importeMN")
                    dr(4) = i.GetValue("importeME")
                    dr(5) = 0
                    dr(6) = 0
                Case "HABER"
                    dr(3) = 0
                    dr(4) = 0
                    dr(5) = i.GetValue("HaberMN")
                    dr(6) = i.GetValue("HaberME")
            End Select
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub

    Dim SumaTotalDebeMN As Decimal = 0
    Dim SumaTotalHaberMN As Decimal = 0

    Dim SumaTotalDebeME As Decimal = 0
    Dim SumaTotalHaberME As Decimal = 0
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

        'ConteoMN = 0
        'ConteoME = 0

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
            .tipoOperacion = "17"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPersona = Nothing
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "5"
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
            .tcDolLoc = txtTipoCambio.Value
            .glosa = txtGlosa.Text.Trim
            Select Case CBOMovimiento.Text
                Case "APORTES"
                    .tipoCompra = TIPO_COMPRA.APORTE_INICIAL
                Case "SALDO DE INICIO"
                    .tipoCompra = TIPO_COMPRA.SALDO_INICIAL
            End Select
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.saldoInicio = nDocumentoCompra
        ListaProductosAalmacen = New List(Of totalesAlmacen)
        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0
        If dgvCompra.Table.Records IsNot Nothing AndAlso dgvCompra.Table.Records.Count > 0 Then
            For Each r As Record In dgvCompra.Table.Records
                objDocumentoCompraDet = New saldoInicioDetalle
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
                objDocumentoCompraDet.modulo = r.GetValue("tipoEx")
                objDocumentoCompraDet.idModulo = r.GetValue("idModulo")
                objDocumentoCompraDet.descripcionItem = r.GetValue("cuenta")
                objDocumentoCompraDet.TipoDoc = "9901"
                '  objDocumentoCompraDet.descripcionItem = r.GetValue("Modulo")
                '  objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                objDocumentoCompraDet.NomAporte = r.GetValue("Modulo")
                Dim s As String = r.GetValue("tipoAsiento").ToString
                If s.Trim.Length > 0 Then
                    Select Case r.GetValue("tipoAsiento")
                        Case "DEBE"
                            objDocumentoCompraDet.tipoAsiento = "D"
                            If Not IsNumeric(r.GetValue("importeMN")) Then
                                lblEstado.Text = "Ingrese un formato correcto en importe"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            Else
                                If Not IsDBNull(r.GetValue("importeMN")) Then

                                    If CDec(r.GetValue("importeMN")) > 0 Then
                                        objDocumentoCompraDet.importe = CDec(r.GetValue("importeMN"))
                                    Else
                                        lblEstado.Text = "Ingrese el importe (M.N.)."
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Exit Sub
                                    End If
                                End If
                            End If

                            If Not IsNumeric(r.GetValue("importeME")) Then
                                lblEstado.Text = "Ingrese un formato correcto en el importe"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            Else
                                If Not IsDBNull(r.GetValue("importeME")) Then

                                    If CDec(r.GetValue("importeME")) > 0 Then
                                        objDocumentoCompraDet.importeUS = r.GetValue("importeME")
                                    Else
                                        lblEstado.Text = "Ingrese el importe (M.E.)."
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Exit Sub
                                    End If
                                End If
                            End If

                            'ConteoMN += CDec(r.GetValue("importeMN"))
                            'ConteoME += CDec(r.GetValue("importeME"))
                        Case Else
                            objDocumentoCompraDet.tipoAsiento = "H"

                            If Not IsNumeric(r.GetValue("HaberMN")) Then
                                lblEstado.Text = "Ingrese un formato correcto en importe"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            Else
                                If Not IsDBNull(r.GetValue("HaberMN")) Then

                                    If CDec(r.GetValue("HaberMN")) > 0 Then
                                        objDocumentoCompraDet.importe = CDec(r.GetValue("HaberMN"))
                                    Else
                                        lblEstado.Text = "Ingrese el importe (M.N.)."
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Exit Sub
                                    End If
                                End If
                            End If

                            If Not IsNumeric(r.GetValue("HaberME")) Then
                                lblEstado.Text = "Ingrese un formato correcto en importe"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            Else
                                If Not IsDBNull(r.GetValue("HaberME")) Then

                                    If CDec(r.GetValue("HaberME")) > 0 Then
                                        objDocumentoCompraDet.importeUS = CDec(r.GetValue("HaberME"))
                                    Else
                                        lblEstado.Text = "Ingrese el importe (M.E.)."
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Exit Sub
                                    End If
                                End If
                            End If

                            'ConteoMN += CDec(r.GetValue("importeMN"))
                            'ConteoME += CDec(r.GetValue("importeME"))
                    End Select
                Else
                    lblEstado.Text = "Debe indicar la ubicación del asiento!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If


                Select Case r.GetValue("tipoEx")
                    Case "MR"
                        If Not IsNumeric(r.GetValue("cantidad")) Then
                            lblEstado.Text = "Ingrese un formato correcto en la cantidad"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("cantidad")) Then

                                If CDec(r.GetValue("cantidad")) > 0 Then
                                    objDocumentoCompraDet.cantidad = CDec(r.GetValue("cantidad"))
                                Else
                                    lblEstado.Text = "La cantidad de: " & r.GetValue("Modulo") & ", debe ser mayor a cero."
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If


                        Dim s1 As String = r.GetValue("idAlmacen").ToString
                        If s1.Trim.Length > 0 Then

                            Select Case r.GetValue("tipoAsiento")
                                Case "DEBE"
                                    objDocumentoCompraDet.precioUnitario = Math.Round(CDec(r.GetValue("importeMN")) / CDec(r.GetValue("cantidad")), 2)
                                    objDocumentoCompraDet.precioUnitarioUS = Math.Round(CDec(r.GetValue("importeME")) / CDec(r.GetValue("cantidad")), 2)
                                Case Else
                                    objDocumentoCompraDet.precioUnitario = Math.Round(CDec(r.GetValue("HaberMN")) / CDec(r.GetValue("cantidad")), 2)
                                    objDocumentoCompraDet.precioUnitarioUS = Math.Round(CDec(r.GetValue("HaberME")) / CDec(r.GetValue("cantidad")), 2)
                            End Select
                            objDocumentoCompraDet.FlagModificaPrecioVenta = (r.GetValue("valCheck"))
                            objDocumentoCompraDet.almacen = CInt(r.GetValue("idAlmacen"))
                            objDocumentoCompraDet.utiMenor = r.GetValue("utiMenor")
                            objDocumentoCompraDet.utiMayor = r.GetValue("utiMayor")
                            objDocumentoCompraDet.utiGranMayor = r.GetValue("utiGranMayor")
                            objDocumentoCompraDet.destino = r.GetValue("destino")
                            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoExistencia")
                            ListaDeProductosAalmacen(r)
                        Else
                            lblEstado.Text = "Debe indicar un almacén de destino!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        End If
                    Case "CA"
                        '    ListaDeCajas(r)
                End Select

                SumaTotalDebeMN += CDec(r.GetValue("importeMN"))
                SumaTotalHaberMN += CDec(r.GetValue("HaberMN"))

                SumaTotalDebeME += CDec(r.GetValue("importeME"))
                SumaTotalHaberME += CDec(r.GetValue("HaberME"))

                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objDocumentoCompraDet)
            Next r
        End If
        If Not SumaTotalDebeMN = SumaTotalHaberMN Then
            lblEstado.Text = "Los asientos contables no cuadran, debe validar"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        If Not SumaTotalDebeME = SumaTotalHaberME Then
            lblEstado.Text = "Los asientos contables no cuadran, debe validar"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        ndocumento.saldoInicio.importeTotal = SumaTotalDebeMN
        ndocumento.saldoInicio.importeUS = SumaTotalDebeME
        listaAsiento = New List(Of asiento)
        listaAsiento.Add(AsientoSaldos)
        ndocumento.asiento = listaAsiento
        ndocumento.saldoInicio.saldoInicioDetalle = ListaDetalle

        If ListaDetalle.Where(Function(o) o.modulo = "TR").Count > 0 Then
            Dim xcod As Integer = CompraSA.InsertarAporteInicio(ndocumento, ListaProductosAalmacen)

        Else
            Throw New Exception("Debe seleccionar al menos un aportante")
        End If

        lblEstado.Text = "compra registrada!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub

    Public Property ListaProductosAalmacen As New List(Of totalesAlmacen)
    '    Public Property ListaCajas As New List(Of documentoCaja)
    Public Sub ListaDeProductosAalmacen(r As Record)
        Dim nTotales As New totalesAlmacen
        Dim productoSA As New detalleitemsSA
        Dim producto As New detalleitems

        producto = productoSA.InvocarProductoID(r.GetValue("idModulo"))
        With nTotales
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .idAlmacen = r.GetValue("idAlmacen")
            .origenRecaudo = producto.origenProducto
            .tipoCambio = 3.0
            .tipoExistencia = producto.tipoExistencia
            .idItem = producto.codigodetalle
            .descripcion = producto.descripcionItem
            .idUnidad = producto.unidad1
            .unidadMedida = Nothing
            .Modulo = "N"
            .cantidad = CDec(r.GetValue("cantidad"))
            .precioUnitarioCompra = 0
            Select Case r.GetValue("tipoAsiento")
                Case "DEBE"
                    .importeSoles = r.GetValue("importeMN")
                    .importeDolares = r.GetValue("importeME")
                Case Else
                    .importeSoles = r.GetValue("HaberMN")
                    .importeDolares = r.GetValue("HaberME")
            End Select
            .montoIsc = 0
            .montoIscUS = 0
            .Otros = 0
            .OtrosUS = 0
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ListaProductosAalmacen.Add(nTotales)
    End Sub

    'Public Sub ListaDeCajas(r As Record)
    '    Dim documentoCaja As New documentoCaja
    '    Dim documentoCajaDetalle As New documentoCajaDetalle
    '    Dim listaDetalle As New List(Of documentoCaja)
    '    With documentoCaja
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idEstablecimiento = GEstableciento.IdEstablecimiento
    '        .codigoLibro = "17"
    '        .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
    '        .codigoProveedor = Nothing
    '        .fechaProceso = fecha
    '        .periodo = PeriodoGeneral
    '        .fechaCobro = fecha
    '        .tipoDocPago = "9901"
    '        .numeroDoc = Nothing
    '        .monedaObligacion = cboMoneda.SelectedValue
    '        .moneda = cboMoneda.SelectedValue
    '        .entidadFinanciera = r.GetValue("idModulo")
    '        .entidadFinancieraDestino = Nothing
    '        .numeroOperacion = Nothing
    '        .tipoCambio = 3.0
    '        Select Case r.GetValue("tipoAsiento")
    '            Case "DEBE"
    '                .montoSoles = r.GetValue("importeMN")
    '                .montoUsd = r.GetValue("importeME")
    '            Case Else
    '                .montoSoles = r.GetValue("HaberMN")
    '                .montoUsd = r.GetValue("HaberME")
    '        End Select
    '        .montoItf = 0
    '        .montoItfusd = 0
    '        .glosa = txtGlosa.Text.Trim
    '        .entregado = "SI"
    '        .bancoEntidad = Nothing
    '        .ctaCorrienteDeposito = Nothing
    '        .usuarioModificacion = "Jiuni"
    '        .fechaModificacion = DateTime.Now
    '    End With

    '    documentoCajaDetalle = New documentoCajaDetalle
    '    documentoCajaDetalle.fecha = fecha
    '    documentoCajaDetalle.idItem = r.GetValue("idModulo")
    '    documentoCajaDetalle.DetalleItem = r.GetValue("Modulo")
    '    Select Case r.GetValue("tipoAsiento")
    '        Case "DEBE"
    '            documentoCajaDetalle.montoSoles = r.GetValue("importeMN")
    '            documentoCajaDetalle.montoUsd = r.GetValue("importeME")
    '        Case Else
    '            documentoCajaDetalle.montoSoles = r.GetValue("HaberMN")
    '            documentoCajaDetalle.montoUsd = r.GetValue("HaberME")
    '    End Select
    '    documentoCajaDetalle.montoItf = 0
    '    documentoCajaDetalle.montoItfusd = 0
    '    documentoCajaDetalle.entregado = "SI"
    '    documentoCajaDetalle.diferTipoCambio = 0
    '    documentoCajaDetalle.difME = 0
    '    documentoCajaDetalle.difMN = 0
    '    documentoCajaDetalle.usuarioModificacion = "Jiuni"
    '    documentoCajaDetalle.fechaModificacion = DateTime.Now
    '    documentoCaja.documentoCajaDetalle = listaDetalle
    '    ListaCajas.Add(documentoCaja)
    'End Sub
#End Region

    Private Sub frmAportesInicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Dim comboTable2 As New DataTable
    Private Sub frmAportesInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTable = Me.GetTableAlmacen
        comboTableCuentas = Me.GetTableCuentas
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(11).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"

        Dim ggcStyle1 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(5).Appearance.AnyRecordFieldCell
        ggcStyle1.CellType = "ComboBox"
        ggcStyle1.DataSource = Me.comboTableCuentas
        ggcStyle1.ValueMember = "idCuenta"
        ggcStyle1.DisplayMember = "nombre"
        ggcStyle1.DropDownStyle = GridDropDownStyle.Exclusive

        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Quitar item")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
        CBOMovimiento.Select()

        dgvCompra.Table.ExpandAllRecords()
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Quitar item" Then
                If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                    Me.dgvCompra.Table.CurrentRecord.Delete()
                End If
            End If
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        'Dim row As Integer = 0, col As Integer = 0
        'Me.dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        'Dim style As GridTableCellStyleInfo = Me.dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        ''To check whether it is columnheadercell
        'If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
        '    '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        'Else
        '    'If it is not column header cell
        '    dgvCompra.ContextMenuStrip = ContextMenuStrip
        'End If
    End Sub


    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub cboTipoEntidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoEntidad.SelectedIndexChanged
        If cboTipoEntidad.Text = "OTRO" Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", "asignar una descripción")
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "OT")
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            cboPrestamos.Visible = False
            'GradientPanel2.Visible = False
            'Panel2.Visible = False
            txtRuc.Visible = False
            Label8.Visible = False
        ElseIf cboTipoEntidad.Text = "PRESTAMOS OTORGADOS" Or cboTipoEntidad.Text = "PRESTAMOS RECIBIDOS" Then
            cboPrestamos.Visible = True
            txtRuc.Visible = True
            Label8.Visible = True
        ElseIf cboTipoEntidad.Text = "EXISTENCIAS O ACTIVO INMOVILIZADO" Then
            'GradientPanel2.Visible = True
            'Panel2.Visible = True
            txtRuc.Visible = False
            Label8.Visible = False
        Else
            cboPrestamos.Visible = False
            'GradientPanel2.Visible = False
            'Panel2.Visible = False
            txtRuc.Visible = True
            Label8.Visible = True
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            '   If txtRuc.Text.Trim.Length > 0 Then
            pcEntidad.Font = New Font("Segoe UI", 8)
            Me.pcEntidad.ParentControl = Me.txtRuc
            Me.pcEntidad.ShowPopup(Point.Empty)
            Select Case cboTipoEntidad.Text
                Case "PROVEEDOR"
                    CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtRuc.Text.Trim)
                Case "CLIENTE"
                    CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtRuc.Text.Trim)
                Case "EN EFECTIVO"
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
            '   End If
        End If
    End Sub

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged

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
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
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
                    Case "EN EFECTIVO"

                    Case "PRESTAMOS OTORGADOS"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "POT")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 0)

                    Case "PRESTAMOS RECIBIDOS"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "PRE")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 0)
                End Select
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
                dgvCompra.Table.ExpandAllRecords()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtRuc.Focus()
        End If
    End Sub

    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.pcEntidad.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()

    Private Sub dgvCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvCompra.KeyPress

    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
        'Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("tipoEx")
        '    Case "MR"
        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
            If style.Enabled Then
                Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("colModVenta")
                ' Console.WriteLine("CheckBoxClicked")
                '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                    chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

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
                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = "N" ' curStatus
                        '   Me.dgvMov.Table.CurrentRecord.SetValue("colModVenta", False)
                    Else
                        Dim RowIndex As Integer = e.Inner.RowIndex
                        Dim ColIndex As Integer = e.Inner.ColIndex
                        '     MsgBox(True)
                        Me.dgvCompra.TableModel(RowIndex, 13).CellValue = "S"
                    End If
                    e.TableControl.EndUpdate()
                    If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                    ElseIf Not ht.Contains(curStatus) Then
                    End If
                    ht.Clear()
                End If
            End If

            Me.dgvCompra.TableControl.Refresh()
        End If


        'End Select
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Dim col1 = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoAsiento")
            'Select Case col1
            '    Case "DEBE"
            '        Me.dgvCompra.TableDescriptor.Columns("importeMN").Appearance.AnyRecordFieldCell.[ReadOnly] = False
            '        Me.dgvCompra.TableDescriptor.Columns("importeME").Appearance.AnyRecordFieldCell.[ReadOnly] = False

            '        'Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 9).CellValue = 0
            '        'Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 10).CellValue = 0

            '        Me.dgvCompra.TableDescriptor.Columns("HaberMN").Appearance.AnyRecordFieldCell.[ReadOnly] = True
            '        Me.dgvCompra.TableDescriptor.Columns("HaberME").Appearance.AnyRecordFieldCell.[ReadOnly] = True



            '    Case "HABER"
            '        Me.dgvCompra.TableDescriptor.Columns("HaberMN").Appearance.AnyRecordFieldCell.[ReadOnly] = False
            '        Me.dgvCompra.TableDescriptor.Columns("HaberME").Appearance.AnyRecordFieldCell.[ReadOnly] = False

            '        'Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 7).CellValue = 0
            '        'Me.dgvCompra.TableModel(Me.dgvCompra.Table.CurrentRecord.GetRowIndex, 8).CellValue = 0

            '        Me.dgvCompra.TableDescriptor.Columns("importeMN").Appearance.AnyRecordFieldCell.[ReadOnly] = True
            '        Me.dgvCompra.TableDescriptor.Columns("importeME").Appearance.AnyRecordFieldCell.[ReadOnly] = True


            'End Select
            Select Case ColIndex
                Case 4
                    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

                    'Case 7
                    '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            End Select

            If ColIndex = 8 Or ColIndex = 10 Then

                Dim importeDebeME As Decimal = 0
                Dim importeDebeMN As Decimal = 0
                Dim str = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoEx")
                Select Case str
                    Case "MR", "CA"

                        If Me.dgvCompra.Table.CurrentRecord.GetValue("moneda") = "1" Then
                            If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                                importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")

                            End If

                        ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("moneda") = "M" Then
                            If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                                importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")

                            End If


                        ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("moneda") = "2" Then

                            If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeME")) > 0 Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                                importeDebeMN = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeME")) * txtTipoCambio.Value, 2)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", importeDebeMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")

                            End If


                        End If
                    Case Else

                        If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                            importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                        End If

                End Select
                '           Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)

            End If
            If ColIndex = 9 Then
                Dim importeHaberME As Decimal = 0
                Dim str = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoEx")
                Select Case str
                    Case "MR", "CA"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                    Case Else
                        If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
                            importeHaberME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")
                        End If
                End Select
            End If

            If ColIndex = 5 Then ' CANTIDAD
                Dim str = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoEx")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")).ToString("N2"))
                Select Case str
                    Case "MR"

                    Case "CA"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                    Case "OT"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                End Select
            End If

            'If ColIndex = 6 Then ' CUENTA CONTABLE
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)
            'End If

            If ColIndex = 12 Then 'ALMACEN
                Dim str = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoEx")
                Select Case str
                    Case "CA"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idAlmacen", String.Empty)
                    Case "OT"
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idAlmacen", String.Empty)
                End Select
            End If

        End If

        dgvCompra.Table.ExpandAllRecords()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub dgvCompra_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles dgvCompra.TableControlPrepareViewStyleInfo
        If (e.Inner.ColIndex > 0) AndAlso (e.Inner.ColIndex < 7) Then
            Select Case e.Inner.Style.Text
                Case "MR"
                    e.Inner.Style.CellTipText = "Mercadería"
                Case "CA"
                    e.Inner.Style.CellTipText = "Caja"
                Case "PR"
                    e.Inner.Style.CellTipText = "Proveedor"
                Case "CL"
                    e.Inner.Style.CellTipText = "Cliente"
                Case "POT"
                    e.Inner.Style.CellTipText = "Prestamo otorgado"
                Case "OT"
                    e.Inner.Style.CellTipText = "Otros"
                Case "PRE"
                    e.Inner.Style.CellTipText = "Prestamo Recibido"
                Case Else
                    e.Inner.Style.CellTipText = e.Inner.Style.Text
            End Select

        End If
    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
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


        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cuenta")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
                Select Case str
                    Case "CA"
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.AliceBlue
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing

                        'If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                        '    e.Style.CellValue = 1
                        'End If

                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
                Select Case str
                    Case "CA"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                    Case "TR"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.LightYellow
                End Select

            End If


            If e.TableCellIdentity.Column.Name = "tipoEx" Then
                If e.Style.CellValue.Equals("MR") Then
                    e.Style.BackColor = Color.LightYellow
                End If
            End If

            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                If IsNumeric(e.Style.CellValue) Then
                    If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                        ' e.Style.BackColor = Color.LightYellow
                        e.Style.BackColor = Color.Yellow
                        e.Style.Format = "##.00"
                    End If
                End If

                'If e.TableCellIdentity.Column.MappingName = "importeMN" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacenDestino" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
            End If
            'If e.TableCellIdentity.Column.Name = "importeMN" Then
            '    If IsNumeric(e.Style.CellValue) Then
            '        '        If Fix(e.Style.CellValue) > 0 Then
            '        '    e.Style.ReadOnly = True
            '        e.TableCellIdentity.Table.CurrentRecord.SetValue("HaberMN", 0)
            '        'End If
            '    End If

            'End If
        End If
    End Sub


    Private Sub txtFiltroMercaderia_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "colModVenta" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        Dim importeDebeME As Decimal = 0
        Dim importeHaberME As Decimal = 0
        If dgvCompra.Table.Records IsNot Nothing AndAlso dgvCompra.Table.Records.Count > 0 Then
            For Each r As Record In dgvCompra.Table.Records

                If r.GetValue("moneda") = "1" Or r.GetValue("moneda") = "P" Or r.GetValue("moneda") = "M" Then

                    importeDebeME = 0
                    importeHaberME = 0
                    If CDec(r.GetValue("importeMN")) > 0 Then
                        r.SetValue("HaberMN", 0)
                        r.SetValue("HaberME", 0)
                        If txtTipoCambio.Value > 0 Then
                            importeDebeME = Math.Round(CDec(r.GetValue("importeMN")) / txtTipoCambio.Value, 2)
                        End If
                        r.SetValue("importeME", importeDebeME)
                        r.SetValue("tipoAsiento", "DEBE")
                    End If

                    If CDec(r.GetValue("HaberMN")) > 0 Then
                        r.SetValue("importeME", 0)
                        r.SetValue("importeMN", 0)
                        If txtTipoCambio.Value > 0 Then
                            importeHaberME = Math.Round(CDec(r.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
                        End If
                        r.SetValue("HaberME", importeHaberME)
                        r.SetValue("tipoAsiento", "HABER")
                    End If



                ElseIf r.GetValue("moneda") = "2" Then

                    'importeDebeME = 0
                    importeHaberME = 0
                    If CDec(r.GetValue("importeME")) > 0 Then
                        r.SetValue("HaberMN", 0)
                        r.SetValue("HaberME", 0)
                        If txtTipoCambio.Value > 0 Then
                            importeDebeME = Math.Round(CDec(r.GetValue("importeME")) * txtTipoCambio.Value, 2)
                        End If
                        r.SetValue("importeMN", importeDebeME)
                        r.SetValue("tipoAsiento", "DEBE")
                    End If

                    If CDec(r.GetValue("HaberME")) > 0 Then
                        r.SetValue("importeME", 0)
                        r.SetValue("importeMN", 0)
                        If txtTipoCambio.Value > 0 Then
                            importeHaberME = Math.Round(CDec(r.GetValue("HaberME")) * txtTipoCambio.Value, 2)
                        End If
                        r.SetValue("HaberMN", importeHaberME)
                        r.SetValue("tipoAsiento", "HABER")
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Select Case cboTipoEntidad.Text
            Case "EN EFECTIVO"
                txtNumCuentaBco.Clear()
                txtNomCaja.Clear()
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(323, 187)
                Me.pcProveedor.ParentControl = Me.txtRuc
                Me.pcProveedor.ShowPopup(Point.Empty)
            Case "OTRO"

            Case "EXISTENCIAS O ACTIVO INMOVILIZADO"

        End Select
    End Sub



    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If rbBanco.Checked = True Then
            If Not txtNumCuentaBco.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro cuenta de banco!!!"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(323, 187)
                Me.pcProveedor.ParentControl = Me.txtRuc
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNumCuentaBco.Select()
                Exit Sub
            End If
        End If

        If Not txtNomCaja.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la caja"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(323, 187)
            Me.pcProveedor.ParentControl = Me.txtRuc
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomCaja.Select()
            Exit Sub
        End If


        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub rbEfectivo_CheckChanged(sender As Object, e As EventArgs) Handles rbEfectivo.CheckChanged
        If rbEfectivo.Checked = True Then
            txtNumCuentaBco.Enabled = False
        Else
            txtNumCuentaBco.Enabled = True
        End If
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If rbBanco.Checked = True Then
                If Not txtNumCuentaBco.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el nro de cuenta del banco"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(323, 187)
                    Me.pcProveedor.ParentControl = Me.txtRuc
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtNumCuentaBco.Select()
                    Exit Sub
                End If
            End If


            If Not txtNomCaja.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre de la caja"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(323, 187)
                Me.pcProveedor.ParentControl = Me.txtRuc
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomCaja.Select()
                Exit Sub
            End If

            If btnGRabarProv.Tag = "G" Then
                InsertCaja()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(323, 187)
                Me.pcProveedor.ParentControl = Me.txtRuc
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If
            dgvCompra.Table.ExpandAllRecords()
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtRuc.Focus()
        End If
    End Sub

    Private Sub btnCancelarProv_Click(sender As Object, e As EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        With frmNuevaExistencia
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub


    Private Sub lsvMercaderia_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lstEntidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEntidades.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcTrabajador.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcTrabajador_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcTrabajador.BeforePopup
        Me.pcTrabajador.BackColor = Color.White
    End Sub

#Region "PERSONA"
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

    'Public Sub GrabarPersona()
    '    Dim personaSA As New PersonaSA
    '    Dim personaBE As New Persona

    '    With personaBE
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idPersona = txtDniTrab.Text.Trim
    '        .nombres = txtNombreTrab.Text.Trim
    '        .appat = txtAppatTrab.Text.Trim
    '        .apmat = txtApmatTrab.Text.Trim
    '        .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
    '        .nivel = "TR"
    '    End With
    '    personaSA.InsertPersona(personaBE)
    '    txtPersona.ValueMember = personaBE.idPersona
    '    txtPersona.Text = personaBE.nombreCompleto
    '    'txtRuc.Text = personaBE.idPersona
    '    'txtCuenta.Text = "TR"

    '    ' lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    'End Sub

#End Region


    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If dgvCompra.Table.Records IsNot Nothing AndAlso dgvCompra.Table.Records.Count > 0 Then
                Grabar()
            Else
                lblEstado.Text = "Ingrese items a la canasta"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            Glosa()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub dgvCompra_Move(sender As Object, e As EventArgs) Handles dgvCompra.Move

    End Sub

    Private Sub dgvCompra_QueryCoveredRange(sender As Object, e As GridTableQueryCoveredRangeEventArgs) Handles dgvCompra.QueryCoveredRange

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'datos.Clear()
        Dim f As New frmBusquedaCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'If datos.Count > 0 Then
        '    Dim entidadSA As New entidadSA
        '    Dim cajaSA As New EstadosFinancierosSA

        '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)

        '    Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", datos(0).ID)
        '    '  Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lstEntidades.Text)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "CA")
        '    With cajaSA.GetUbicar_estadosFinancierosPorID(datos(0).ID)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", .cuenta)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .descripcion)
        '    End With

        '    Me.dgvCompra.Table.AddNewRecord.EndEdit()
        '    dgvCompra.Table.ExpandAllRecords()
        'End If



    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'datos.Clear()
        Dim f As New frmBusquedaExistencia
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'If datos.Count > 0 Then
        '    Dim entidadSA As New entidadSA
        '    Dim tablaSA As New tablaDetalleSA
        '    Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        '    Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", datos(0).ID)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", datos(0).NomEvento)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("unidad", tablaSA.GetUbicarTablaID(6, datos(0).NomProceso).descripcion)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "MR")
        '    Select Case cboTipoExistencia.Text
        '        Case "MERCADERIA"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "20") '
        '        Case "ACTIVO INMOVILIZADO"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "33") '
        '        Case "PRODUCTO TERMINADO"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "21") '
        '        Case "MATERIAS PRIMAS"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "24") '
        '        Case "ENVASES Y EMBALAJES"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "26") '

        '        Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "25") '
        '        Case "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "22") '
        '        Case "PRODUCTOS EN PROCESO"
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "23") '

        '    End Select

        '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("utiMenor", 0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("utiMayor", 0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("utiGranMayor", 0)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("destino", datos(0).IDEstable)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", datos(0).NroDoc)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("colModVenta", False)
        '    Me.dgvCompra.Table.CurrentRecord.SetValue("valCheck", "N")
        '    Me.dgvCompra.Table.AddNewRecord.EndEdit()
        '    dgvCompra.Table.ExpandAllRecords()
        'End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", "asignar una descripción")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", 50)
        Me.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", "Capital")
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "OT")
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        cboPrestamos.Visible = False
        'GradientPanel2.Visible = False
        'Panel2.Visible = False
        txtRuc.Visible = False
        Label8.Visible = False
        dgvCompra.Table.ExpandAllRecords()
    End Sub

    Private Sub dgvAsiento_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub EliminarAsientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarAsientoToolStripMenuItem.Click
        Dim consulta = (From n In ListaAsientonTransito _
                      Where n.idAsiento = lstAsiento.SelectedValue).FirstOrDefault


        If Not IsNothing(consulta) Then
            Dim listaMov = (From i In ListaMovimientos _
                           Where i.idAsiento = lstAsiento.SelectedValue).ToList

            For Each obj In listaMov
                ListaMovimientos.Remove(obj)
            Next
            ListaAsientonTransito.Remove(consulta)
            GetasientosListbox()

        End If
    End Sub


    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        generarAsientoMuestra(dgvCompra)
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Dim f As New frmBusquedaPersonas
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Glosa()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellValidating(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellValidating
        'Dim cc As GridCurrentCell = e.TableControl.CurrentCell
        'Dim style As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex)
        'If style.TableCellIdentity.Column IsNot Nothing AndAlso style.TableCellIdentity.Column.Name = "cuenta" AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.AnyRecordFieldCell Then
        '    'new trigger value
        '    Dim s As String = cc.Renderer.ControlText

        '    'get the record
        '    Dim rec As GridRecord = TryCast(style.TableCellIdentity.DisplayElement, GridRecord)
        '    rec.SetValue("nomCuenta", "someValueBasedOnTheValueOf_s_")
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)

        dgvCompra.Table.ExpandAllRecords()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("id", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("idModulo", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", "asignar una descripción")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cuenta", cboCuenta.SelectedValue)
        Me.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cboCuenta.Text)
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "OT")
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        cboPrestamos.Visible = False
        'GradientPanel2.Visible = False
        'Panel2.Visible = False
        txtRuc.Visible = False
        Label8.Visible = False
        dgvCompra.Table.ExpandAllRecords()
    End Sub

    Private Sub cboCuentaPadre_Click(sender As Object, e As EventArgs) Handles cboCuentaPadre.Click

    End Sub

    Private Sub cboCuentaPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentaPadre.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cboCuentaPadre.SelectedIndex > -1 Then
            CBOCuentas(cboCuentaPadre.Text)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick

    End Sub
End Class