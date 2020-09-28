Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Public Class frmAbrirCajaUsuario
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim usuarioSA As New UsuarioSA
    Dim usuariobe As New Usuario
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property strEstadoManipulacion() As String
    Public Property tipoCambioME() As Decimal
    Public Property idCajauser() As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(gridGroupingControl1)
        gridGroupingControl1.DataSource = UbicarCajasHijas()
        cboTipo.SelectedIndex = -1
        ListaUsuariosAdmin()
        'ListaUsuarios()
        'usuariobe = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})
        'txtPersona.Text = usuariobe.Nombres & ", " & usuariobe.ApellidoPaterno & " " & usuariobe.ApellidoMaterno
        'txtPersona.Tag = usuario.IDUsuario
        'txtDni.Text = usuariobe.NroDocumento
        LoadEmpresa()
        txtFecHaApertura.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
    End Sub

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

#Region "Métodos"

    Sub LoadEmpresa()
        Dim empresaSA As New empresaSA
        cboEmpresa.DisplayMember = "razonSocial"
        cboEmpresa.ValueMember = "idEmpresa"
        cboEmpresa.DataSource = empresaSA.ObtenerListaEmpresas()
        cboEmpresa.SelectedValue = Gempresas.IdEmpresaRuc
        cboEmpresa.Enabled = False
    End Sub

    Public Sub UbicarCajaUsuario()
        Dim cajausuarioSA As New cajaUsuarioSA
        Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim cajausuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros

        cajausuario = cajausuarioSA.UbicarCajaUsuarioPorID(idCajauser)

        cboPersona.SelectedValue = CInt(cajausuario.idPersona)
        cboPersona.Enabled = False
        txtSaldoResponsableMN.DecimalValue = cajausuario.fondoMN
        txtSaldoResponsableMe.DecimalValue = cajausuario.fondoME
        Me.gridGroupingControl1.Table.Records.DeleteAll()
        For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(idCajauser)
            ef = efSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)


            Me.gridGroupingControl1.Table.AddNewRecord.SetCurrent()
            Me.gridGroupingControl1.Table.AddNewRecord.BeginEdit()
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("codigo", i.secuencia)
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("IdEntidad", i.idEntidad)
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("entidad", ef.descripcion)
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("moneda", IIf(ef.codigo = "1", "NACIONAL", "EXTRANJERA"))
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("tc", TmpTipoCambio)
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", i.importeME)
            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("montoMax", 0)
            Me.gridGroupingControl1.Table.AddNewRecord.EndEdit()
        Next

    End Sub

    Sub ActualizarCajaUsuario()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim UserDetalle = New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
        Try

            cajaUsuario = New cajaUsuario()
            cajaUsuario.idcajaUsuario = idCajauser
            cajaUsuario.idEmpresa = cboEmpresa.SelectedValue.ToString
            cajaUsuario.idEstablecimiento = GEstableciento.IdEstablecimiento
            cajaUsuario.periodo = PeriodoGeneral
            cajaUsuario.idPersona = cboPersona.SelectedValue
            cajaUsuario.idCajaOrigen = cboDepositoHijo.SelectedValue
            cajaUsuario.idCajaDestino = Nothing
            cajaUsuario.moneda = cboMoneda.SelectedValue
            cajaUsuario.tipoCambio = TmpTipoCambio
            cajaUsuario.fechaRegistro = txtFecHaApertura.Value
            cajaUsuario.fondoMN = txtSaldoResponsableMN.DecimalValue
            cajaUsuario.fondoME = txtSaldoResponsableMe.DecimalValue
            cajaUsuario.ingresoAdicMN = 0
            cajaUsuario.ingresoAdicME = 0
            cajaUsuario.otrosIngresosMN = 0
            cajaUsuario.otrosIngresosME = 0
            cajaUsuario.otrosEgresosMN = 0
            cajaUsuario.otrosEgresosME = 0
            cajaUsuario.estadoCaja = "A"
            cajaUsuario.enUso = "N"
            cajaUsuario.usuarioActualizacion = usuario.IDUsuario
            cajaUsuario.fechaActualizacion = DateTime.Now

            For Each i As Record In gridGroupingControl1.Table.Records
                UserDetalle = New cajaUsuariodetalle
                UserDetalle.idcajaUsuario = idCajauser
                UserDetalle.idEntidad = i.GetValue("IdEntidad")
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        UserDetalle.moneda = 1
                    Case Else
                        UserDetalle.moneda = 2
                End Select
                UserDetalle.importeMN = i.GetValue("importeMN")
                UserDetalle.importeME = i.GetValue("importeME")
                UserDetalle.usuarioActualizacion = usuario.IDUsuario
                UserDetalle.fechaActualizacion = DateTime.Now
                ListaUserDetalle.Add(UserDetalle)
            Next
            cajaUsuario.cajaUsuariodetalle = ListaUserDetalle
            cajaUsuarioSA.EditarCajaUsuarioNuevo(cajaUsuario)
            Tag = "Grabado"
            Dispose()
        Catch ex As Exception
            Tag = Nothing
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub cargarCtasFinan()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")

        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")

        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            'Dim lista As New List(Of String)
            'lista.Add("001")

        End If
    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)

        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            'Select Case cboMoneda.SelectedValue
            '    Case 1
            '        txtImporteComprame.Location = New Point(587, 38)
            '        Label6.Location = New Point(32, 42)
            '        Label8.Location = New Point(508, 42)
            '        txtImporteCompramn.Location = New Point(111, 38)
            '        'txtImporteComprame.Enabled = False
            '        'txtImporteCompramn.Enabled = True
            '    Case 2
            '        txtImporteCompramn.Location = New Point(587, 38)
            '        txtImporteComprame.Location = New Point(111, 38)
            '        Label6.Location = New Point(508, 42)
            '        Label8.Location = New Point(32, 42)
            '        'txtImporteCompramn.Enabled = False
            '        'txtImporteComprame.Enabled = True
            'End Select
            GetObtenerSaldoEF()
        End If
    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            'With estadoBL
            '    .idestado = Nothing
            '    .descripcion = Nothing

            'End With

            'ListaestadoBL.Add(estadoBL)

            'For Each items In (estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda))
            '    ListaestadoBL.Add(items)
            'Next

            ''ListaestadoBL = (estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda))
            'Me.cboDepositoHijo.DataSource = ListaestadoBL
            'cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
            'cboDepositoHijo.DisplayMember = "descripcion"

            Dim codEmpresa = cboEmpresa.SelectedValue
            If codEmpresa.ToString.Trim.Length > 0 Then
                Me.cboDepositoHijo.DataSource = estadoSA.GetCuentasFinancierasByEmpresa(cboEmpresa.SelectedValue.ToString, strBusqueda)
                Me.cboDepositoHijo.DisplayMember = "descripcion"
                Me.cboDepositoHijo.ValueMember = "idestado"
            End If
            cboDepositoHijo.SelectedValue = -1
            ' Tag = 0

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

            'estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID()
            'txtMoneda.Tag = estadoBL.codigo
            'txtMoneda.Text = estadoBL.descripcion

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Sub TotalDGV()
        Dim monto As Decimal = 0
        Dim montoUS As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoME As Decimal = 0
        For Each r As Record In gridGroupingControl1.Table.Records

            Select Case r.GetValue("moneda")
                Case "NACIONAL"
                    monto += r.GetValue("importeMN")
                Case "EXTRANJERA"
                    montoUS += r.GetValue("importeME")
            End Select

        Next

        txtSaldoResponsableMN.DecimalValue = monto
        txtSaldoResponsableMe.DecimalValue = montoUS
        'If Not txtFondoMN.DecimalValue >= monto Then
        '    'Else
        '    lblEstado.Text = "Debe ingresar un monto menor o igual al permitido!"
        '    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("ingresoMN", 0)
        '    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("ingresoME", 0)
        '    'Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'Else

        '    txtSaldoResponsableMN.DecimalValue = saldoMN
        '    txtSaldoResponsableMe.DecimalValue = saldoME
        'End If
    End Sub

    Sub GetObtenerSaldoEF()
        Dim EFSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim cajaSA As New cajaUsuarioSA
        Dim cajaBE As New cajaUsuario
        Dim monto As Decimal
        'Dim fondoCajaMN As Decimal
        'Dim fondoCAjaME As Decimal

        'cajaBE = cajaSA.ValidarUsuarioCajaEntidad(cboPersona.SelectedValue, cboDepositoHijo.SelectedValue, cboMoneda.SelectedValue)

        Select Case cboMoneda.SelectedValue
            Case 1

                'fondoCajaMN = cajaBE.fondoMN
                monto = EFSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, txtFecHaApertura.Value).importeBalanceMN
                txtFondoEF.DecimalValue = monto '- fondoCajaMN

            Case 2
                estadoBL = EFSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
                tipoCambioME = estadoBL.tipocambio
                'fondoCAjaME = cajaBE.fondoME
                'monto = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = cboDepositoHijo.SelectedValue}).importeBalanceME
                monto = EFSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, txtFecHaApertura.Value).importeBalanceME
                txtFondoEF.DecimalValue = monto '- fondoCAjaME
                'tipoCambioME = cajaBE.tipoCambio
        End Select


    End Sub

    'Private Function GeneraraAsiento() As asiento
    '    Dim nAsiento As New asiento
    '    Dim movimiento As movimiento
    '    Dim efsa As New EstadosFinancierosSA
    '    Try
    '        nAsiento = New asiento
    '        nAsiento.idDocumento = 0
    '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '        nAsiento.idEntidad = cboPersona.SelectedValue
    '        nAsiento.nombreEntidad = cboPersona.Text
    '        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
    '        nAsiento.fechaProceso = txtFecHaApertura.Value
    '        nAsiento.codigoLibro = "1"
    '        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
    '        nAsiento.importeMN = txtFondoMN.DecimalValue
    '        nAsiento.importeME = txtFondoME.DecimalValue
    '        nAsiento.glosa = Glosa()
    '        nAsiento.usuarioActualizacion = "jiuni"
    '        nAsiento.fechaActualizacion = DateTime.Now


    '        movimiento = New movimiento With {
    '              .cuenta = efsa.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta,
    '              .descripcion = cboDepositoHijo.Text,
    '              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
    '              .monto = txtFondoMN.DecimalValue,
    '              .montoUSD = txtFondoME.DecimalValue,
    '              .fechaActualizacion = DateTime.Now,
    '              .usuarioActualizacion = "Jiuni"}
    '        nAsiento.movimiento.Add(movimiento)

    '        'movimiento = New movimiento With {
    '        '    .cuenta = efsa.GetUbicar_estadosFinancierosPorID(txtDestino.Tag).cuenta,
    '        '    .descripcion = txtDestino.Text,
    '        '    .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
    '        '    .monto = txtFondoMN.DecimalValue,
    '        '    .montoUSD = txtFondoME.DecimalValue,
    '        '    .fechaActualizacion = DateTime.Now,
    '        '    .usuarioActualizacion = "Jiuni"}
    '        'nAsiento.movimiento.Add(movimiento)


    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '    End Try
    '    Return nAsiento
    'End Function

    Public Function Glosa() As String
        Return "Por Apertura de caja al usuario: " & cboPersona.Text.Trim
    End Function
    Dim statusForm As New frmMensajeCodigoVenta
    Public Sub Grabar()
        Dim cajaSA As New cajaUsuarioSA
        Dim objCaja As New cajaUsuario

        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        Dim ListaSubUsers As New List(Of cajaUsuario)
        Dim SubUsers As New cajaUsuario
        Dim UserDetalle As New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)

        ListaAsientonTransito = New List(Of asiento)

        Try
            With objCaja
                .idEmpresa = cboEmpresa.SelectedValue.ToString
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .periodo = PeriodoGeneral
                .idPersona = cboPersona.SelectedValue
                .idCajaOrigen = cboDepositoHijo.SelectedValue
                .idCajaDestino = Nothing ' txtDestino.Tag
                .moneda = cboMoneda.SelectedValue
                .tipoCambio = TmpTipoCambio
                .fechaRegistro = txtFecHaApertura.Value
                .fondoMN = txtSaldoResponsableMN.DecimalValue ' txtFondoMN.DecimalValue
                .fondoME = txtSaldoResponsableMe.DecimalValue ' txtFondoME.DecimalValue
                '.claveIngreso = txtClave.Text.Trim
                .ingresoAdicMN = 0
                .ingresoAdicME = 0
                .otrosIngresosMN = 0
                .otrosIngresosME = 0
                .otrosEgresosMN = 0
                .otrosEgresosME = 0
                .estadoCaja = "A"
                .enUso = "N"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            For Each i As Record In gridGroupingControl1.Table.Records
                UserDetalle = New cajaUsuariodetalle
                UserDetalle.idEntidad = i.GetValue("IdEntidad")
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        UserDetalle.moneda = 1
                    Case Else
                        UserDetalle.moneda = 2
                End Select
                UserDetalle.importeMN = CDec(i.GetValue("importeMN"))
                UserDetalle.importeME = CDec(i.GetValue("importeME"))
                UserDetalle.usuarioActualizacion = usuario.IDUsuario
                UserDetalle.fechaActualizacion = DateTime.Now
                ListaUserDetalle.Add(UserDetalle)
            Next
            objCaja.cajaUsuariodetalle = ListaUserDetalle
            Dim codigoUsuarioClave = documentoCajaSA.SaveGroupCajaApertura(Nothing, objCaja, ListaSubUsers)
            Tag = codigoUsuarioClave
            Dispose()
        Catch ex As Exception
            Tag = Nothing
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub


    Public Function UbicarCajasHijas() As DataTable

        Dim DT As New DataTable()
        DT.Columns.Add("codigo", GetType(String))
        DT.Columns.Add("IdEntidad", GetType(Integer))
        DT.Columns.Add("entidad", GetType(String))
        DT.Columns.Add("moneda", GetType(String))
        DT.Columns.Add("tc", GetType(Decimal))
        DT.Columns.Add("importeMN", GetType(Decimal))
        DT.Columns.Add("importeME", GetType(Decimal))
        DT.Columns.Add("montoMax", GetType(Decimal))
        Return DT
    End Function

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

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
        GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String, tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            Me.lstEntidades.DataSource = estadoSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, tiping, strBusqueda)
            Me.lstEntidades.DisplayMember = "descripcion"
            Me.lstEntidades.ValueMember = "idestado"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ListaUsuariosAdmin()
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim listaUsuario As New List(Of Usuario)
        Dim condicion As New List(Of String)
        condicion.Add("3")
        condicion.Add("4")

        listaUsuario = usuarioSA.GetListaUsuarios()
        Dim nuevaLista = listaUsuario.Where(Function(o) condicion.Contains(o.Rol)).ToList
        '   listaUsuario = usuarioSA.ListadoUsuariosPuntoVenta(New UsuarioRol With {.IDRol = 3})

        cboPersona.DataSource = nuevaLista
        cboPersona.ValueMember = "IDUsuario"
        cboPersona.DisplayMember = "Full_Name"
        cboPersona.SelectedValue = -1
    End Sub

    Public Sub ListaUsuarios()
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim TablaSA As New tablaDetalleSA
        Try
            Dim lista2 As List(Of Usuario) = usuarioSA.ListadoUsuariosPuntoVenta(New UsuarioRol With {.IDRol = 3})
            Dim dt As New DataTable

            dt.Columns.Add("ident", GetType(String))
            dt.Columns.Add("nomUser", GetType(String))
            dt.Columns.Add("idUsuario", GetType(Integer))

            For Each i In lista2
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.NroDocumento
                dr(1) = i.Nombres & " " & i.ApellidoPaterno & ", " & i.ApellidoMaterno
                dr(2) = i.IDUsuario
                dt.Rows.Add(dr)
            Next
            'GridGroupingControl2.DataSource = dt
            'Me.GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = TablaSA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub frmAbrirCajaUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAbrirCajaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridGroupingControl1.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub txtOrigen_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            selCaja = "Origen"

            e.SuppressKeyPress = True
            pcEntidad.Font = New Font("Segoe UI", 8)
            pcEntidad.Size = New Size(249, 147)
            Me.pcEntidad.ParentControl = cboDepositoHijo
            Me.pcEntidad.ShowPopup(Point.Empty)

            If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
                CargarCajasTipo(cboDepositoHijo.SelectedValue, "EF")
            ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
                CargarCajasTipo(cboDepositoHijo.SelectedValue, "BC")
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtOrigen_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub txtDestino_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Dim selCaja As String = Nothing
    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.pcEntidad.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            Me.gridGroupingControl1.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub gridGroupingControl1_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles gridGroupingControl1.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim montoME As Decimal = 0
        Dim montoMN As Decimal = 0
        Dim montoAperturaMN As Decimal
        Dim montoAperturaME As Decimal
        Dim moneda As String
        Dim entidad As String

        If (btnMin.Tag = 0) Then
            If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 6

                        entidad = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("entidad")
                        moneda = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("moneda")
                        montoMN = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("importeMN")

                        If (montoMN > 0) Then

                            If (moneda = "NACIONAL") Then
                                If chSinReferencia.Checked = True Then
                                    Select Case cboMoneda.SelectedValue
                                        Case 1
                                            montoME = 0.0
                                            TotalDGV()
                                        Case 2
                                            montoME = 0.0
                                            TotalDGV()
                                    End Select
                                Else
                                    If (entidad = cboDepositoHijo.Text) Then
                                        montoAperturaMN = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("importeMN")


                                        If (montoAperturaMN <= CDec(txtFondoEF.Text)) Then
                                            Dim disponible As Double = 0

                                            Select Case cboMoneda.SelectedValue
                                                Case 1
                                                    montoME = 0.0
                                                    TotalDGV()
                                                Case 2
                                                    montoME = 0.0
                                                    TotalDGV()
                                            End Select
                                        Else
                                            lblEstado.Text = "El importe ingresado excede al permitido!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0.0)
                                        End If
                                    Else
                                        'If (montoMN > 0) Then
                                        '    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", montoMN)
                                        'Else
                                        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                        'End If

                                        lblEstado.Text = "La entidad selecciona no coincide!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)

                                    End If
                                End If

                            Else
                                Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                lblEstado.Text = "la cuenta seleccionada es Extranjera!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            End If


                        Else

                            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                            TotalDGV()
                            'lblEstado.Text = "El importe no debe ser negativo!"
                            'PanelError.Visible = True
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If

                    Case 7

                        entidad = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("entidad")
                        moneda = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("moneda")
                        montoME = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("importeME")

                        If (montoME > 0) Then

                            If chSinReferencia.Checked = True Then
                                Dim disponible As Double = 0
                                If (moneda = "EXTRANJERA") Then
                                    montoMN = Math.Round(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("importeME") * CDec(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("tc")), 2)
                                    TotalDGV()
                                Else
                                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0.0)
                                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            Else
                                If (moneda = "EXTRANJERA") Then
                                    If (entidad = cboDepositoHijo.Text) Then
                                        montoAperturaME = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("importeME")
                                        If (montoAperturaME <= CDec(txtFondoEF.Text)) Then
                                            Dim disponible As Double = 0

                                            montoMN = Math.Round(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("importeME") * CDec(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("tc")), 2)
                                            TotalDGV()
                                        Else
                                            lblEstado.Text = "El importe ingresado excede al permitido!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0.0)
                                        End If
                                    Else
                                        lblEstado.Text = "La entidad selecciona no coincide!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", montoME)
                                    End If

                                Else
                                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0.0)
                                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            End If

                        Else
                            Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0.0)
                            'lblEstado.Text = "El importe no debe ser negativo!"
                            TotalDGV()
                            'PanelError.Visible = True
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If
                End Select
            End If
        End If


    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtFondoEF.DecimalValue = 0
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue

        If IsNumeric(value) Then
            cargarDatosCuenta(CInt(value))
        Else
            txtFondoEF.DecimalValue = 0
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'If txtFondoEF.DecimalValue > 0 Then
        Dim nombreEntidad As Integer = 0

        For Each i As Record In gridGroupingControl1.Table.Records
            If (i.GetValue("IdEntidad") = cboDepositoHijo.SelectedValue) Then
                nombreEntidad += 1
            End If
        Next

        If (nombreEntidad = 0) Then

            Select Case cboMoneda.Text
                Case "NACIONAL"
                    Me.gridGroupingControl1.Table.AddNewRecord.SetCurrent()
                    Me.gridGroupingControl1.Table.AddNewRecord.BeginEdit()
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("codigo", 0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("IdEntidad", cboDepositoHijo.SelectedValue)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("entidad", cboDepositoHijo.Text)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("moneda", cboMoneda.Text)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("tc", 0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("montoMax", txtFondoEF.DecimalValue)
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeME").ReadOnly = True
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeMN").ReadOnly = False
                    Me.gridGroupingControl1.Table.AddNewRecord.EndEdit()

                Case "EXTRANJERA"
                    Me.gridGroupingControl1.Table.AddNewRecord.SetCurrent()
                    Me.gridGroupingControl1.Table.AddNewRecord.BeginEdit()
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("codigo", 0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("IdEntidad", cboDepositoHijo.SelectedValue)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("entidad", cboDepositoHijo.Text)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("moneda", cboMoneda.Text)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("tc", 0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", 0.0)
                    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("montoMax", txtFondoEF.DecimalValue)
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeME").ReadOnly = False
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeMN").ReadOnly = True
                    Me.gridGroupingControl1.Table.AddNewRecord.EndEdit()


            End Select

        Else
            lblEstado.Text = "Ya existe entidad financiera!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        End If

    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        If gridGroupingControl1.Table.Records.Count > 0 Then
            gridGroupingControl1.Table.Records.Delete(gridGroupingControl1.Table.CurrentRecord)
            gridGroupingControl1.Refresh()
            TotalDGV()
            btnMin.Tag = 0
        End If
    End Sub

    Private Sub cboPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPersona.SelectedIndexChanged
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim Usuario As New Usuario
        Dim CajaUsuario As New cajaUsuario
        Me.Cursor = Cursors.WaitCursor
        Try
            Usuario = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = cboPersona.SelectedValue})



            If (Not IsNothing(cboPersona.SelectedValue)) Then

                CajaUsuario = cajaUsuarioSA.UbicarUsuarioAbierto(cboPersona.SelectedValue)

                Select Case strEstadoManipulacion
                    Case ENTITY_ACTIONS.INSERT
                        If (IsNothing(CajaUsuario)) Then
                            If (Not IsNothing(Usuario)) Then
                                txtDni.Text = Usuario.NroDocumento
                            End If
                        Else
                            lblEstado.Text = "El usuario tiene una caja activa!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            cboPersona.SelectedValue = -1
                            txtDni.Clear()
                            txtSaldoResponsableMN.Clear()
                            txtSaldoResponsableMe.Clear()
                        End If
                    Case ENTITY_ACTIONS.UPDATE
                        If (Not IsNothing(Usuario)) Then
                            txtDni.Text = Usuario.NroDocumento
                        End If

                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not cboPersona.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un personal!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                cboPersona.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not gridGroupingControl1.Table.Records.Count > 0 Then
                lblEstado.Text = "Ingrese cuenta financieras!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If strEstadoManipulacion = ENTITY_ACTIONS.INSERT Then
                lblEstado.Text = "Proceso normal"
                Grabar()
            Else
                ActualizarCajaUsuario()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dispose()
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub cboEmpresa_Click(sender As Object, e As EventArgs) Handles cboEmpresa.Click

    End Sub

    Private Sub cboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedIndexChanged
        cboDepositoHijo.SelectedIndex = -1
        cboTipo_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub
End Class