
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMaestroCajas
    Inherits frmMaster

    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25)
        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = PeriodoGeneral
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)

        'Private Sub RibbonPanel1_SelectedTabItemChanged(sender As System.Object, e As Syncfusion.Windows.Forms.Tools.SelectedTabChangedEventArgs) Handles RibbonControlAdv1.SelectedTabItemChanged
        '    Me.Cursor = Cursors.WaitCursor
        '    If RibbonControlAdv1.SelectedTab.Name = "ToolStripTabItem2" Then
        '        TabPageAdv1.Parent = Nothing
        '        TabPageAdv2.Parent = tabCajas
        '        TabPageAdv3.Parent = Nothing
        '    ElseIf RibbonControlAdv1.SelectedTab.Name = "ToolStripTabItem1" Then
        '        TabPageAdv1.Parent = tabCajas
        '        TabPageAdv2.Parent = Nothing
        '        TabPageAdv3.Parent = Nothing
        '    ElseIf RibbonControlAdv1.SelectedTab.Name = "ToolStripTabItem3" Then
        '        TabPageAdv1.Parent = Nothing
        '        TabPageAdv2.Parent = Nothing
        '        TabPageAdv3.Parent = tabCajas
        '    End If
        '    Me.Cursor = Cursors.Arrow
        'End Sub
        'Select Case idModulo
        '    Case 26
        '        'ObtenerObtenerCajaUsuarios()
        '        ToolStripTabItem1.Visible = True
        '        ToolStripTabItem3.Visible = False
        '        ToolStripTabItem2.Visible = False
        '        TabPageAdv1.Parent = tabCajas
        '        TabPageAdv2.Parent = Nothing
        '        TabPageAdv3.Parent = Nothing
        '    Case 27
        '        ToolStripTabItem1.Visible = False
        '        ToolStripTabItem3.Visible = False
        '        ToolStripTabItem2.Visible = True
        '        TabPageAdv1.Parent = Nothing
        '        TabPageAdv2.Parent = tabCajas
        '        TabPageAdv3.Parent = Nothing
        '    Case 28
        '        ToolStripTabItem1.Visible = False
        '        ToolStripTabItem3.Visible = True
        '        ToolStripTabItem2.Visible = False
        '        TabPageAdv1.Parent = Nothing
        '        TabPageAdv2.Parent = Nothing
        '        TabPageAdv3.Parent = tabCajas
        'End Select


    End Sub


    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
        '  configDockingManger()
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

    'Private Function getParentCierreModulos(intIdUser As Integer) As DataTable
    '    Dim cajaSa As New DocumentoCajaSA

    '    Dim dt As New DataTable("Modulos")
    '    dt.Columns.Add(New DataColumn("codigoLibro", GetType(String)))
    '    'lower case p
    '    dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

    '    For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, intIdUser)
    '        Dim dr As DataRow = dt.NewRow()
    '        Select Case i.codigoLibro
    '            Case 8
    '                dr(0) = "Compras"
    '            Case Else
    '                dr(0) = i.codigoLibro
    '        End Select

    '        dr(1) = i.montoSoles
    '        dr(2) = i.montoUsd
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt

    'End Function

    'Public Sub ListaCierresPorModulo(intIdUser As Integer)
    '    'GetObtenerCierreCajasModulos
    '    dgvCierres.TableOptions.ClearCache()
    '    '    dgvCuentasFinanzas.DataSource = Nothing
    '    dgvCierres.DataSource = getParentCierreModulos(intIdUser) ' cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
    '    dgvCierres.TableDescriptor.Relations.Clear()
    '    dgvCierres.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '    dgvCierres.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    dgvCierres.TableOptions.ShowRowHeader = False
    '    dgvCierres.Appearance.AnyRecordFieldCell.Enabled = False
    '    Me.dgvCierres.TableDescriptor.GroupedColumns.Clear()
    'End Sub

    Public Sub ObtenerListaCajas()
        Dim entidadSA As New EstadosFinancierosSA
        lsvCajas.Items.Clear()
        For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idestado)
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add(IIf(i.tipo = "BC", "BANCO", "EFECTIVO"))
            n.SubItems.Add(i.cuenta)
            If i.codigo = 1 Then
                n.SubItems.Add("Moneda nacional").ForeColor = Color.SteelBlue
            Else
                n.SubItems.Add("Moneda extranjera").ForeColor = Color.LightYellow
            End If

            lsvCajas.Items.Add(n)
        Next
        If lsvCajas.Items.Count > 0 Then
            lsvCajas.Focus()
            lsvCajas.Items(0).Selected = True
            lsvCajas.Items(0).Focused = True
            lsvCajas.FocusedItem.EnsureVisible()
        End If

    End Sub
    Private Function getParentTableUsuariosEstablecimiento() As DataTable
        Dim cajaSa As New cajaUsuarioSA

        Dim dt As New DataTable("Usuarios")
        dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("NombreCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NombrePersona", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estadoCaja", GetType(String)))

        Dim str As String
        For Each i As cajaUsuario In cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaRegistro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idcajaUsuario
            dr(1) = str
            dr(2) = i.NombreCajaOrigen
            dr(3) = i.NombrePersona
            dr(4) = i.NombreCajaDestino
            dr(5) = i.fondoMN
            dr(6) = i.fondoME
            dr(7) = i.estadoCaja
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Sub ObtenerObtenerCajaUsuarios()
        Dim cajaSa As New cajaUsuarioSA
        dgvCuentasFinanzas.TableOptions.ClearCache()
        '    dgvCuentasFinanzas.DataSource = Nothing
        dgvCuentasFinanzas.DataSource = getParentTableUsuariosEstablecimiento() ' cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        dgvCuentasFinanzas.TableDescriptor.Relations.Clear()
        dgvCuentasFinanzas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCuentasFinanzas.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCuentasFinanzas.TableOptions.ShowRowHeader = False
        dgvCuentasFinanzas.Appearance.AnyRecordFieldCell.Enabled = False
        Me.dgvCuentasFinanzas.TableDescriptor.GroupedColumns.Clear()
        '    Me.dgvCuentasFinanzas.TableDescriptor.VisibleColumns.Remove("idcajaUsuario")
        'dgvCuentasFinanzas.TableOptions.ShowRecordPlusMinus = False
        'dgvCuentasFinanzas.TableOptions.ShowRecordPreviewRow = False
        'dgvCuentasFinanzas.TableOptions.ShowTableIndent = False
        'dgvCuentasFinanzas.TableDescriptor.Relations.Clear()
        'dgvCuentasFinanzas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        'dgvCuentasFinanzas.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Function getParentTableUsuarioCajas() As DataTable
        Dim PersonaSA As New PersonaSA

        Dim dt As New DataTable("Usuarios")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombres", GetType(String)))
        dt.Columns.Add(New DataColumn("appat", GetType(String)))
        dt.Columns.Add(New DataColumn("apmat", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaActualizacion", GetType(String)))

        Dim str As String
        For Each i As Persona In PersonaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            '  str = CDate(i.fechaActualizacion).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idPersona
            dr(1) = i.nombres
            dr(2) = i.appat
            dr(3) = i.apmat
            dr(4) = str
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    'Private Sub ObtenerCuentasFinancierasPorMoneda(strIdMoneda As String)
    '    Dim cFinancieraSA As New EstadosFinancierosSA
    '    gridGroupingControl1.DataSource = cFinancieraSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, strIdMoneda)
    '    gridGroupingControl1.TableDescriptor.GroupedColumns.Add("codigo")
    'End Sub
#End Region

#Region "CONFIGURACION DOCKING CONTROL"
    'Sub configDockingManger()
    '    Me.dockingManager1.DockControl(Me.PanelEstadosFinancieros, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 318)

    '    dockingManager1.SetDockLabel(PanelEstadosFinancieros, "Cuentas")
    'End Sub
#End Region

#Region "Manipulación Data"
    Dim USer As New cajaUsuario
    Dim utilidadMN As Decimal = 0
    Dim utilidadME As Decimal = 0

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle


        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento   'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.tipoDoc = "9903"
        nDocumentoCaja.fechaProceso = DateTime.Now
        nDocumentoCaja.nroDoc = "EFECTIVO"
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9906"
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.TipoDocumentoPago = "VOCJ"
        objCaja.codigoLibro = "9906" ' TIPO OPERACION
        objCaja.periodo = PeriodoGeneral
        objCaja.codigoProveedor = USer.idPersona
        objCaja.fechaProceso = DateTime.Now
        objCaja.fechaCobro = DateTime.Now
        objCaja.tipoDocPago = "9903"
        objCaja.numeroDoc = 0 ' txtNumeroComp.Text
        objCaja.moneda = USer.moneda
        objCaja.entidadFinanciera = USer.idCajaDestino
        objCaja.numeroOperacion = "00001" 'txtNumeroComp.Text
        objCaja.tipoCambio = USer.tipoCambio

        utilidadMN = USer.fondoMN + USer.ingresoAdicMN - USer.otrosEgresosMN
        utilidadME = USer.fondoME + USer.ingresoAdicME - USer.otrosEgresosME

        objCaja.montoSoles = utilidadMN
        objCaja.montoUsd = utilidadME
      
        objCaja.glosa = "Apertura de caja"
        objCaja.entregado = "SI"
        objCaja.usuarioModificacion = USer.idcajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.fecha = DateTime.Now
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "POR CIERRE DE CAJA"
        objCajaDetalle.montoSoles = utilidadMN
        objCajaDetalle.montoUsd = utilidadME
       
        objCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
      
        objCajaDetalle.documentoAfectado = 0
        objCajaDetalle.usuarioModificacion = USer.idcajaUsuario
        objCajaDetalle.fechaModificacion = Date.Now
        nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)

        Return nDocumentoCaja
    End Function

    Public Function AS_CAJA_ORIGEN() As movimiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros

        ef = efSA.GetUbicar_estadosFinancierosPorID(USer.idCajaCierre)

        nMovimiento = New movimiento With {
              .cuenta = ef.cuenta,
              .descripcion = ef.descripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = utilidadMN,
              .montoUSD = utilidadME,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_CAJA_DESTINO() As movimiento
        Dim nMovimiento As New movimiento

        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros

        ef = efSA.GetUbicar_estadosFinancierosPorID(USer.idCajaDestino)

        nMovimiento = New movimiento With {
       .cuenta = ef.cuenta,
       .descripcion = ef.descripcion,
       .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
       .monto = utilidadMN,
       .montoUSD = utilidadME,
       .fechaActualizacion = DateTime.Now,
       .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Function asientoCaja() As asiento
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento

        utilidadMN = USer.fondoMN + USer.ingresoAdicMN - USer.otrosEgresosMN
        utilidadME = USer.fondoME + USer.ingresoAdicME - USer.otrosEgresosME

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = USer.idPersona
        nAsiento.nombreEntidad = Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("NombrePersona")
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
        nAsiento.fechaProceso = DateTime.Now
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.CIERRE_CAJA_USUARIO
        nAsiento.importeMN = utilidadMN
        nAsiento.importeME = utilidadME
        nAsiento.glosa = "Apertura caja"
        nAsiento.usuarioActualizacion = USer.idcajaUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        nAsiento.movimiento.Add(AS_CAJA_ORIGEN)
        nAsiento.movimiento.Add(AS_CAJA_DESTINO)

        Return nAsiento
    End Function

    Public Sub AperturarCajaUsuario(intIdUSer As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario

        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            USer = cajaUsuarioSA.UbicarCajaUsuarioPorID(intIdUSer)
            With cajaUsuario
                .idcajaUsuario = USer.idcajaUsuario
                .fechaCierre = DateTime.Now
                .enUso = "N"
                .estadoCaja = "A"
                .otrosEgresosMN = USer.otrosEgresosMN
                .otrosEgresosME = USer.otrosEgresosME
                .ingresoAdicMN = USer.ingresoAdicMN
                .ingresoAdicME = USer.ingresoAdicME
                .idCajaCierre = Nothing
            End With
            nDocumento = ComprobanteCaja()
            asiento = asientoCaja()
            ListaAsiento.Add(asiento)
            nDocumento.asiento = ListaAsiento
            cajaUsuarioSA.AperturarCajaUsuario(cajaUsuario, nDocumento)
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub EliminarTransferencia(intIdCajaUsuario As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajausuarioBE As New cajaUsuario

        With cajaUsuarioSA.UbicarCajaUsuarioPorID(intIdCajaUsuario)
            cajausuarioBE.idcajaUsuario = .idcajaUsuario
            cajausuarioBE.documentoApertura = .documentoApertura
            cajausuarioBE.documentoCierre = .documentoCierre
        End With

        cajaUsuarioSA.EliminarCajaUsuarioFull(cajausuarioBE)
        PanelError.Visible = True
        lblEstado.Text = "Caja eliminada"
        Timer1.Enabled = True
        TiempoEjecutar(10)
        'lsvCajaUsuario.SelectedItems(0).Remove()
        'lblEstado.Text = "caja eliminada!"
    End Sub

    Public Sub EliminarPersona(intIdPersona As Integer)
        Dim PersonaSA As New PersonaSA
        Dim PersonaBE As New Persona

        PersonaBE.idPersona = intIdPersona

        PersonaSA.EliminarPersona(PersonaBE)
        PanelError.Visible = True
        lblEstado.Text = "Usuario eliminado"
    End Sub
#End Region

    Private Sub frmMaestroCajas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    'Private Sub rbBanco_CheckChanged(sender As System.Object, e As System.EventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    If rbBanco.Checked = True Then
    '        ObtenerCuentasFinancierasPorMoneda("1")
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    'Private Sub rbEfectivo_CheckChanged(sender As System.Object, e As System.EventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    If rbEfectivo.Checked = True Then
    '        ObtenerCuentasFinancierasPorMoneda("2")
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        With frmAsignaCajaUser
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuarioSA As New cajaUsuarioSA
        If Not IsNothing(Me.dgvCuentasFinanzas.Table.CurrentRecord) Then
            If cajaUsuarioSA.UbicarCajaUsuarioPorID(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario")).estadoCaja = "A" Then
                With frmCierreCaja
                    .IDCajaUser = Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario")
                    .ListaCierresPorModulo(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario"))
                    .UbicarCaja(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                lblEstado.Text = "La caja se encuentra cerrada!!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCuentasFinanzas.Table.CurrentRecord) Then
            With frmArqueoCaja
                .ConsultaReporte(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            lblEstado.Text = "Seleccionar una caja activa!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnComprasPeriodo_Click(sender As Object, e As EventArgs) Handles btnComprasPeriodo.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerObtenerCajaUsuarios()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "101"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEditEF_Click(sender As Object, e As EventArgs) Handles btnEditEF.Click, ToolStripButton12.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoUsuario
            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            .UbicarporDNI(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton8.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerListaCajas()
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub RibbonPanel1_SelectedTabItemChanged(sender As System.Object, e As Syncfusion.Windows.Forms.Tools.SelectedTabChangedEventArgs) Handles RibbonControlAdv1.SelectedTabItemChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    If RibbonControlAdv1.SelectedTab.Name = "ToolStripTabItem2" Then
    '        TabPageAdv1.Parent = Nothing
    '        TabPageAdv2.Parent = tabCajas
    '        TabPageAdv3.Parent = Nothing
    '    ElseIf RibbonControlAdv1.SelectedTab.Name = "ToolStripTabItem1" Then
    '        TabPageAdv1.Parent = tabCajas
    '        TabPageAdv2.Parent = Nothing
    '        TabPageAdv3.Parent = Nothing
    '    ElseIf RibbonControlAdv1.SelectedTab.Name = "ToolStripTabItem3" Then
    '        TabPageAdv1.Parent = Nothing
    '        TabPageAdv2.Parent = Nothing
    '        TabPageAdv3.Parent = tabCajas
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCuentasFinanzas.Table.CurrentRecord) Then
            With frmCierreCajasModulo
                .xIdCajaUser = Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario")
                .lblNomUser.Text = Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("NombrePersona")
                .ListaCierresPorModulo(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        If Not IsNothing(Me.dgvCuentasFinanzas.Table.CurrentRecord) Then
            If cajaUsuarioSA.UbicarCajaUsuarioPorID(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario")).estadoCaja = "C" Then
                AperturarCajaUsuario(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario"))
            End If
        End If
    End Sub

    'Cuentas de Usuario


    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        With frmAsignaCajaUser
            .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
            .ConfigModulo()

            .ObtenerCajaUser(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario"))
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub ListaEntradas(strPeriodo As String)
        Try
            Dim parentTable As DataTable = getParentTableUsuarioCajas()
            Me.dgvUsuarios.DataSource = parentTable
            dgvUsuarios.TableDescriptor.Relations.Clear()
            dgvUsuarios.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvUsuarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvUsuarios.Appearance.AnyRecordFieldCell.Enabled = False
            dgvUsuarios.GroupDropPanel.Visible = True
            dgvUsuarios.TableDescriptor.GroupedColumns.Clear()

            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos período: - " & PeriodoGeneral
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                Me.dgvUsuarios.Table.CurrentRecord.Delete()
            End If
        Else
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Me.Cursor = Cursors.WaitCursor
        ListaEntradas(PeriodoGeneral)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmMaestroCajas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If TmpSelModulo = 1 Then
            '     ToolStripTabItem1.Enabled = False
            ToolStripTabItem1.Visible = False
            ToolStripTabItem2.Visible = True
            ToolStripTabItem3.Visible = False

            TabPageAdv1.Parent = Nothing
            TabPageAdv2.Parent = tabCajas
            TabPageAdv3.Parent = Nothing
            ObtenerListaCajas()
        ElseIf TmpSelModulo = 3 Then
            ToolStripTabItem1.Visible = True
            ToolStripTabItem2.Visible = False
            ToolStripTabItem3.Visible = False

            TabPageAdv1.Parent = tabCajas
            TabPageAdv2.Parent = Nothing
            TabPageAdv3.Parent = Nothing

            ObtenerObtenerCajaUsuarios()
        ElseIf TmpSelModulo = 2 Then
            ToolStripTabItem1.Visible = False
            ToolStripTabItem2.Visible = False
            ToolStripTabItem3.Visible = True

            TabPageAdv1.Parent = Nothing
            TabPageAdv2.Parent = Nothing
            TabPageAdv3.Parent = tabCajas
            ListaEntradas(PeriodoGeneral)
        End If
    End Sub

    Private Sub ToolStripButton11_Click_2(sender As System.Object, e As System.EventArgs) Handles ToolStripButton11.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoUsuario
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Dim ventaSA As New documentoVentaAbarrotesSA
        Try
            If Not IsNothing(Me.dgvCuentasFinanzas.Table.CurrentRecord) Then

                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RemoveCajaSL(CInt(Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario")))
                End If

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub


    Public Sub RemoveCajaSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento

            .tipoDoc = 9901
            .idDocumento = Me.dgvCuentasFinanzas.Table.CurrentRecord.GetValue("idcajaUsuario")
        End With

        If (documentoSA.DeleteUsuarioCajaSL(objDocumento).Length > 0) Then

            lblEstado.Text = documentoSA.DeleteUsuarioCajaSL(objDocumento)
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Else
            Me.dgvCuentasFinanzas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


    End Sub
End Class