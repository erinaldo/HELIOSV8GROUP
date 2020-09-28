Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports System.ComponentModel
Public Class frmInicioEmpresa
    Inherits frmMaster

    Dim fedd As New FeedbackForm
    Dim empresa2 As New empresa
    Dim empresasa As New empresaSA

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GradientPanel14.Enabled = False
        ' Add any initialization after the InitializeComponent() call.
        'ObtenerConfiguracionPorEmpresa(Gempresas.IdEmpresaRuc)
        fedd.StartPosition = FormStartPosition.CenterScreen
        fedd.TopMost = True
        fedd.Show()



        bgGeneral.RunWorkerAsync()

    End Sub
    Dim empresa As New List(Of empresa)
    Sub Hilo()

        Dim empresaSA As New empresaSA


        empresa = empresaSA.ObtenerListaEmpresas()
       
    End Sub

#Region "Config Inicio"
    Sub getEstablecimiento(strIdEmpresa As String)
        Dim estableSA As New establecimientoSA
        cboEstablecimiento.DataSource = estableSA.ObtenerListaEstablecimientos(strIdEmpresa)
        cboEstablecimiento.DisplayMember = "nombre"
        cboEstablecimiento.ValueMember = "idCentroCosto"
    End Sub
    Sub CajaInicioSaldo()
        Dim EfSA As New EstadosFinancierosSA
        Dim Ef As New estadosFinancieros
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        Ef = EfSA.GetUbicar_estadosFinancierosPorID(TmpIdEntidadFinanciera)
        If Not IsNothing(Ef) Then
            GFichaUsuarios = New GFichaUsuario
            GFichaUsuarios.IdCajaUsuario = usuario.IDUsuario
            GFichaUsuarios.IdPersona = usuario.IDUsuario
            GFichaUsuarios.NombrePersona = usuario.CustomUsuario.Nombres & ", " & usuario.CustomUsuario.ApellidoPaterno & " " & usuario.CustomUsuario.ApellidoMaterno
            GFichaUsuarios.ClaveUsuario = String.Empty
            GFichaUsuarios.IdCajaOrigen = TmpIdEntidadFinanciera
            GFichaUsuarios.IdCajaDestino = TmpIdEntidadFinanciera
            GFichaUsuarios.cuentaDestino = Ef.cuenta
            GFichaUsuarios.NomCajaDestinb = Ef.descripcion
            GFichaUsuarios.FechaApertura = DateTime.Now
            GFichaUsuarios.Moneda = Ef.codigo

            GFichaUsuarios.TipoCambio = Ef.tipocambio
            GFichaUsuarios.FondoMN = Ef.importeBalanceMN
            GFichaUsuarios.FondoME = Ef.importeBalanceME
            GFichaUsuarios.EstadoCaja = "A"
            GFichaUsuarios.EnUso = ""
            UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        End If
    End Sub

    Private Sub Grabar()
        Dim cierreSA As New empresaCierreMensualSA
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        Dim tipcambsa As New TipoCambioSunatV2
        Dim tipcambsaSA As New tipoCambioSA
        Dim existe2 As New TipoCambioSunatV2


        'validar cierre

        Dim fechaAnt = New Date(txtFechaInicio.Value.Year, CInt(Me.txtFechaInicio.Value.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Dim f As New frmselectCierre("No Cerrado")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag = "No Cerrado" Then
                Exit Sub
            End If
            If IsNothing(f.Tag) Then
                Exit Sub
            End If
        End If

        'Dim TotaldiasMes = DateTime.DaysInMonth(txtFechaInicio.Value.Year, txtFechaInicio.Value.Month)

        'If TotaldiasMes = txtFechaInicio.Value.Day Then
        '    MessageBox.Show("Debe cerrar el período actual", "Verificar Cierre", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Dim f As New frmselectCierre("No Cerrado")
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()

        'End If


        With config
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = cboEstablecimiento.SelectedValue
            .idalmacenVenta = CboAlmacen.SelectedValue
            .montoMaximo = txtmontomaximo.Value
            .anio = Me.txtFechaInicio.Value.Year
            .mes = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month))
            .dia = txtFechaInicio.Value

            .periodo = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month)) & "/" & Me.txtFechaInicio.Value.Year
            .tipocambio = nudTipoCambioVenta.DecimalValue
            .iva = txtIva.Value
            '.tipoCambioTransacCompra = nupTipoCambioTransacCompra.Value
            '.tipoCambioTransacVenta = nupTipoCambioTransacVenta.Value


            '.retencion4ta = nudRenta.Value
            'agremarti

            'With tipcambsa
            '    .fechaIgv = txtFechaIgv.Value

            '    .idRegulador = CInt(100)
            '    .compra = nudTipoCambioCompra.Value
            '    .venta = nudTipoCambio.Value

            '    .usuarioModificacion = "jiuni"
            '    .fechaModificacion = DateTime.Now
            'End With

            existe = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            ''''''''''
            'existe2 = tipcambsaSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, txtFechaTC.Value)
            '''''''''''

            If Not IsNothing(existe) Then
                configsa.EditarConfigInicio(config)
                ' tipcambsaSA.InsertTC(tipcambsa)
            Else
                configsa.InsertConfigInicio(config)
                'tipcambsaSA.InsertTC(tipcambsa)
            End If

            '''''''''''
            'If Not IsNothing(existe2) Then

            '    tipcambsaSA.EditartTC(tipcambsa)
            'Else

            '    tipcambsaSA.InsertTC(tipcambsa)
            'End If

            ''''''''''
            GEstableciento = New GEstablecimiento
            GEstableciento.IdEstablecimiento = cboEstablecimiento.SelectedValue
            GEstableciento.NombreEstablecimiento = cboEstablecimiento.Text
            TmpIdAlmacen = CboAlmacen.SelectedValue
            TmpNombreAlmacen = CboAlmacen.Text
            ' TmpIdEntidadFinanciera = cboentidadFinanciera.SelectedValue
            ' TmpNombreEntidadFinanciera = cboentidadFinanciera.Text
            AnioGeneral = cboAnio.Text
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month))
            DiaLaboral = txtFechaInicio.Value
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month)) & "/" & Me.txtFechaInicio.Value.Year

            TmpTipoCambio = nudTipoCambioVenta.DecimalValue
            'TmpTipoCambioTransaccionCompra = nupTipoCambioTransacCompra.Value
            'TmpTipoCambioTransaccionVenta = nupTipoCambioTransacVenta.Value
            TmpIGV = txtIva.Value
            MontoMaximoCliente = txtmontomaximo.Value



            'TmpRetencion4 = nudRenta.Valuew
            'agre
            Close()

        End With
    End Sub

    Sub CBOall(intIdEstablecimiento As Integer)
        CMBAlmacen(intIdEstablecimiento)
        CMBEF(intIdEstablecimiento)
    End Sub

    Public Sub ObtenerConfiguracionPorEmpresa(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almacenSA As New almacenSA

        '  CMBEstablecimientos()
        config = configSA.ObtenerConfigXempresa(strIdEmpresa, GEstableciento.IdEstablecimiento)
        If Not IsNothing(config) Then
            tmpConfigInicio = config
            With config
                cboEstablecimiento.SelectedValue = .idCentroCosto
                'CBOall(.idEstablecimiento)
                'CboAlmacen.SelectedValue = .idalmacenVenta
                'If Not IsNothing(.entidadFinanciera) Then
                '    cboentidadFinanciera.SelectedValue = .entidadFinanciera
                'Else

                'End If

                cboAnio.Text = .anio
                'Me.txtFechaInicio.Value = New Date(.anio, .mes, .dia.Value.Day)
                nudTipoCambioVenta.DecimalValue = .tipocambio
                txtIva.Value = .iva
                'nupTipoCambioTransacCompra.Value = .tipoCambioTransacCompra.GetValueOrDefault
                'nupTipoCambioTransacVenta.Value = .tipoCambioTransacVenta.GetValueOrDefault

                '------------------------------------------------------------------------------

                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = .idCentroCosto
                GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idCentroCosto).nombre

                'TmpIdEntidadFinanciera = cboentidadFinanciera.SelectedValue
                'TmpNombreEntidadFinanciera = cboentidadFinanciera.Text

                'TmpIdAlmacen = .idalmacenVenta
                'TmpNombreAlmacen = almacenSA.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
                AnioGeneral = .anio
                MesGeneral = .mes
                DiaLaboral = .dia
                PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
                TmpTipoCambio = .tipocambio
                TmpIGV = .iva
                TmpTipoIVA = .tipoIva
                TmpRetencion4 = .retencion4ta.GetValueOrDefault
                MontoMaximoCliente = .montoMaximo
                txtmontomaximo.Value = .montoMaximo
                TmpTipoCambioTransaccionCompra = .tipoCambioTransacCompra.GetValueOrDefault
                TmpTipoCambioTransaccionVenta = .tipoCambioTransacVenta.GetValueOrDefault

                TmpCronogramaPagos = .cronogramaPagos.GetValueOrDefault
                TmpProduccionPorLotes = .produccionLotes.GetValueOrDefault

                If .proyecto = "S" Then
                    rbProyecto.Checked = True
                    TmpProyecto = True
                Else
                    rbProyecto.Checked = False
                    TmpProyecto = False
                End If

                If .ordenProduccion = "S" Then
                    rbProduccion.Checked = True
                    TmpOrdenProduccion = True
                Else
                    rbProduccion.Checked = False
                    TmpOrdenProduccion = False
                End If

                If .activo = "S" Then
                    rbActivo.Checked = True
                    TmpActivo = True
                Else
                    rbActivo.Checked = False
                    TmpActivo = False
                End If

                If .gastoAdmin = "S" Then
                    rbAdmin.Checked = True
                    TmpGastoAdmin = True
                Else
                    rbAdmin.Checked = False
                    TmpGastoAdmin = False
                End If

                If .gastoVentas = "S" Then
                    rbVentas.Checked = True
                    TmpGastoVentas = True
                Else
                    rbVentas.Checked = False
                    TmpGastoVentas = False
                End If

                If .gastoFinanciero = "S" Then
                    rbFinanciero.Checked = True
                    TmpGastoFinanciero = True
                Else
                    rbFinanciero.Checked = False
                    TmpGastoFinanciero = False
                End If

            End With
        Else
            '   MessageBoxAdv.Show("No hay una configuración existente!", "Atención!", MessageBoxButtons.OK)
        End If
    End Sub

    Sub Anios(codEmpresa As String)
        Dim AniosSA As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
    End Sub

    'Sub CMBEstablecimientos()
    '    Dim estableSA As New establecimientoSA

    '    cboEstablecimiento.DisplayMember = "nombre"
    '    cboEstablecimiento.ValueMember = "idCentroCosto"
    '    cboEstablecimiento.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
    'End Sub

    Sub CMBAlmacen(intIdEstable As Integer)
        Dim almacenSA As New almacenSA

        CboAlmacen.DisplayMember = "descripcionAlmacen"
        CboAlmacen.ValueMember = "idAlmacen"
        CboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = intIdEstable, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

    Sub CMBEF(intIdEstable As Integer)
        Dim efSA As New EstadosFinancierosSA

        'cboentidadFinanciera.DisplayMember = "descripcion"
        'cboentidadFinanciera.ValueMember = "idestado"
        'cboentidadFinanciera.DataSource = efSA.ObtenerEstadosFinancierosPorEstablecimiento(intIdEstable)
    End Sub

    Private Sub GrabarEstablecimiento()
        Dim estableSA As New establecimientoSA
        Dim estable As New centrocosto
        With estable
            .idEmpresa = Gempresas.IdEmpresaRuc
            .nombre = txtNewEstable.Text.Trim
            .TipoEstab = cboTipoEstable.SelectedValue
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        Dim codx As Integer = estableSA.InsertEstablecimiento(estable)

        GEstableciento.IdEstablecimiento = codx
        GEstableciento.NombreEstablecimiento = txtNewEstable.Text.Trim
    End Sub

    Private Sub ObtenerTipoCambioMax()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambio As New tipoCambio

        tipoCambio = tipoCambioSA.GetListaTipoCambioMaxFecha(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        If (tipoCambio.compra.GetValueOrDefault > 0) Then
            With tipoCambio
                txtFechaTC.Value = .fechaIgv
                'txtFechaIgv.Value = DateTime.Now
                nudTipoCambioCompra.DecimalValue = .compra
                nudTipoCambioVenta.DecimalValue = .venta
            End With
        Else
            txtFechaTC.IsNullDate = True
            'txtFechaTC.Value = DateTime.Now
            nudTipoCambioCompra.DecimalValue = 0
            nudTipoCambioVenta.DecimalValue = 0
        End If
    End Sub

    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA

        lsvTipoCambio.Items.Clear()
        Dim anio = (txtFechaInicio.Value.Year)
        Dim mes = (txtFechaInicio.Value.Month)
        For Each t In tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, mes, anio, GEstableciento.IdEstablecimiento)
            Dim n As New ListViewItem
            n.UseItemStyleForSubItems = False
            n.Text = 100
            n.SubItems.Add(CDate(t.fechaIgv).Date)
            n.SubItems.Add(t.compra)
            With n.SubItems.Add(t.venta)
                .ForeColor = Color.DarkRed
            End With
            lsvTipoCambio.Items.Add(n)
        Next
        lsvTipoCambio.Refresh()
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

    Private Sub frmInicioEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '     Dispose()
    End Sub
    Sub UbicarTC()
        Dim tipocambioSA As New tipoCambioSA
        Dim tipocambio As New tipoCambio

        'Dim b = MonthPeriodo.SelectedDates(0).Date
        Dim FechaActual = New Date(Integer.Parse(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day)
        tipocambio = tipocambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, FechaActual, GEstableciento.IdEstablecimiento)

        If Not IsNothing(tipocambio) Then
            txtFechaTC.Value = tipocambio.fechaIgv
            nudTipoCambioCompra.DecimalValue = tipocambio.compra
            nudTipoCambioVenta.DecimalValue = tipocambio.venta
        Else
            txtFechaTC.IsNullDate = True
            nudTipoCambioCompra.DecimalValue = 0
            nudTipoCambioVenta.DecimalValue = 0
            '  MessageBox.Show("Falta ingresar el t/c para esta fecha.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PictureBox17.Select()
        End If
    End Sub
    Private Sub frmInicioEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Cursor = Cursors.WaitCursor

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        ObtenerTipoCambioMax()
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        With frmTipoCambio
            .txtFechaIgv.Value = New DateTime(Val(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day)
            .txtFechaIgv.MaxValue = New DateTime(Val(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day)
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = nudTipoCambioCompra.DecimalValue
            .nudTipoCambio.Value = nudTipoCambioVenta.DecimalValue
            .ShowDialog()
            UbicarTC()
        End With
    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        'pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
        'pcNuevoEstablecimiento.Size = New Size(322, 148)
        'Me.pcNuevoEstablecimiento.ParentControl = Me.cboEstablecimiento
        'Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
        'txtNewEstable.Clear()
        'txtNewEstable.Select()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.pcNuevoEstablecimiento.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If Not txtNewEstable.Text.Trim.Length > 0 Then
            ' lblEstado.Text = "Ingrese el nombre de la clasificación"
            pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
            pcNuevoEstablecimiento.Size = New Size(318, 102)
            Me.pcNuevoEstablecimiento.ParentControl = Me.cboEstablecimiento
            Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
            txtNewEstable.Select()
            Exit Sub
        End If
        'ButtonAdv1.Tag = "G"
        Me.pcNuevoEstablecimiento.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcNuevoEstablecimiento_BeforePopup(sender As Object, e As CancelEventArgs) Handles pcNuevoEstablecimiento.BeforePopup
        Me.pcNuevoEstablecimiento.BackColor = Color.White
    End Sub

    Private Sub pcNuevoEstablecimiento_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcNuevoEstablecimiento.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtNewEstable.Text.Trim.Length > 0 Then
                '  lblEstado.Text = "Ingrese el nombre de la clasificación"
                pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
                pcNuevoEstablecimiento.Size = New Size(322, 148)
                Me.pcNuevoEstablecimiento.ParentControl = Me.cboEstablecimiento
                Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
                txtNewEstable.Select()
                Exit Sub
            End If


            '  If ButtonAdv1.Tag = "G" Then
            GrabarEstablecimiento()
            'ButtonAdv1.Tag = "N"
        Else
            pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
            pcNuevoEstablecimiento.Size = New Size(322, 148)
            Me.pcNuevoEstablecimiento.ParentControl = Me.cboEstablecimiento
            Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
        End If

        ' End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.cboEstablecimiento.Focus()
        End If
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs)
        'With frmNuevoAlmacen
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        '    .txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        '    .txtEmpresa.Text = Gempresas.NomEmpresa
        '    .txtEmpresa.ValueMember = Gempresas.IdEmpresaRuc
        '    .StartPosition = FormStartPosition.CenterParent
        '    '.WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub cboEstablecimiento_Click(sender As Object, e As EventArgs) Handles cboEstablecimiento.Click

    End Sub

    'Private Sub cboEstablecimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstablecimiento.SelectedIndexChanged
    '    If cboEstablecimiento.SelectedIndex > -1 Then
    '        CMBAlmacen(cboEstablecimiento.SelectedValue)
    '        CMBEF(cboEstablecimiento.SelectedValue)
    '    End If
    'End Sub

    Private Sub PictureBox19_Click_1(sender As Object, e As EventArgs) Handles PictureBox19.Click
        Me.Cursor = Cursors.WaitCursor
        Dim empresaPeriodoSA As New empresaPeriodoSA
        Dim nuevoAnio = InputBox("Agregar nuevo año de trabajo", "Periodo empresa", "")

        If IsNumeric((nuevoAnio)) Then
            empresaPeriodoSA.InsertarPeriodo(New empresaPeriodo With
                                              {
                                                  .idEmpresa = cboEmpresa.SelectedValue,
                                                  .periodo = nuevoAnio,
                                                  .usuarioActualizacion = usuario.IDUsuario,
                                                  .fechaActualizacion = Date.Now
                                             })

            Anios(cboEmpresa.SelectedValue)
            cboAnio.SelectedValue = nuevoAnio
        Else
            MessageBox.Show("Formato incorrecto", "Validar año", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'With frmModalCaja
        '    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        '    .ObtenerMascaraMercaderia()
        '    .txtCuentaID.Text = "101"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    CMBAlmacen(cboEstablecimiento.SelectedValue)
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboAnio_Click(sender As Object, e As EventArgs) Handles cboAnio.Click

    End Sub

    Private Sub cboAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedIndexChanged
        If Not IsNothing(MesGeneral) Then
            If cboAnio.Text.Trim.Length > 0 Then
                txtFechaInicio.Value = New Date(CInt(cboAnio.Text), MesGeneral, DiaLaboral.Day)
            End If
        End If
    End Sub

    Private Sub lsvTipoCambio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvTipoCambio.SelectedIndexChanged
        If lsvTipoCambio.SelectedItems.Count > 0 Then
            txtFechaTC.Value = CDate(lsvTipoCambio.SelectedItems(0).SubItems(2).Text)
            nudTipoCambioCompra.DecimalValue = CDec(lsvTipoCambio.SelectedItems(0).SubItems(2).Text)
            nudTipoCambioVenta.DecimalValue = CDec(lsvTipoCambio.SelectedItems(0).SubItems(3).Text)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If lsvTipoCambio.Visible = True Then
            lsvTipoCambio.Visible = False
        Else
            LoadTipoCambio()
            lsvTipoCambio.Visible = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim tipocambioSA As New tipoCambioSA
        If txtFechaTC.IsNullDate = False Then
            If MessageBox.Show("Esta seguro de eliminar el t/c" & vbCrLf & "de la fecha: " & txtFechaTC.Value.Date, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                tipocambioSA.DeleteTC(New tipoCambio With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaIgv = txtFechaTC.Value.Date, .idRegulador = 100})
                MessageBox.Show("t/c eliminado correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFechaTC.IsNullDate = True
                nudTipoCambioCompra.DecimalValue = 0
                nudTipoCambioVenta.DecimalValue = 0
            End If
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Try
            If empresa2.estado = "0" Then
                MessageBox.Show("Debe terminar la configuración de su empresa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim FechaActual = New Date(Integer.Parse(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day)

            If txtFechaTC.Value.Date = FechaActual.Date Then

            Else
                MessageBox.Show("Debe ingresar un t/c para la fecha de trabajo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            'If MonthPeriodo.Value.Date > Date.Now.Date Then
            '    If MessageBoxAdv.Show("Desea guardar con una fecha posterior a la actual?" + MonthPeriodo.Value, "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            '    Else

            '        If MessageBoxAdv.Show("Desea guarda con la fecha  actual?" + DateTime.Now.Date, "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            '            MonthPeriodo.Value = DateTime.Now
            '        Else

            '            Exit Sub
            '        End If


            '    End If
            'ElseIf MonthPeriodo.Value.Date < Date.Now.Date Then
            '    If MessageBoxAdv.Show("Desea guardar con una fecha anterior a la actual?" + MonthPeriodo.Value, "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            '    Else

            '        If MessageBoxAdv.Show("Desea guarda con la fecha  actual?" + DateTime.Now.Date, "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            '            MonthPeriodo.Value = DateTime.Now
            '        Else

            '            Exit Sub
            '        End If


            '    End If
            'ElseIf MonthPeriodo.Value.Date = Date.Now.Date Then
            '    If MessageBoxAdv.Show("Desea guardar con la fecha actual?" + MonthPeriodo.Value, "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            '    Else
            '        Exit Sub
            '    End If
            'End If



            If cboEstablecimiento.Text.Trim.Length > 0 Then
                'If CboAlmacen.Text.Trim.Length > 0 Then
                'If cboentidadFinanciera.Text.Trim.Length > 0 Then
                If cboAnio.Text.Trim.Length > 0 Then
                    'If txtIva.Value > 0 Then
                    If nudTipoCambioCompra.DecimalValue > 0 Then
                        If nudTipoCambioVenta.DecimalValue > 0 Then
                            '  If nupTipoCambioTransacCompra.Value > 0 Then
                            '  If nupTipoCambioTransacVenta.Value > 0 Then

                            If MessageBoxAdv.Show("Desea guardar la configuración con fecha" & vbCrLf & vbCrLf &
                                                  Space(25) & New Date(Integer.Parse(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day), "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                Grabar()
                            Else
                                Exit Sub
                            End If

                            'Else
                            '    lblEstado.Text = "Ingresar un tipo de cambio mayor a 0"
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)

                            'End If

                            '    Else
                            '    lblEstado.Text = "Ingresar un tipo de cambio mayor a 0"
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            'End If
                        Else
                            lblEstado.Text = "Ingresar un tipo de cambio mayor a 0"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                    Else
                        lblEstado.Text = "Ingresar un tipo de cambio de compra mayor a 0"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                    'Else
                    '    lblEstado.Text = "Ingresar un Iva mayor a 0"
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)
                    'End If
                Else
                    lblEstado.Text = "Ingresar un año"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
                'Else

                '    lblEstado.Text = "Ingresar una entidad finaciera"
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                'End If
                'Else
                '    lblEstado.Text = "Ingresar un almacen"
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                'End If
            Else
                lblEstado.Text = "Ingresar un establecimineto"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PanelError.Visible = False
    End Sub

    Private Sub cboEmpresa_Click(sender As Object, e As EventArgs) Handles cboEmpresa.Click

    End Sub

    Private Sub cboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedIndexChanged

        Me.Cursor = Cursors.WaitCursor
        Dim codEmpresa = cboEmpresa.SelectedValue

        If Not IsNothing(codEmpresa) Then
            If codEmpresa.ToString.Trim.Length > 0 Then
                empresa2 = empresasa.UbicarEmpresaRuc(cboEmpresa.SelectedValue)

                Gempresas = New GEmpresa
                Gempresas.IdEmpresaRuc = cboEmpresa.SelectedValue
                Gempresas.NomEmpresa = cboEmpresa.Text
                Gempresas.InicioOpeaciones = empresa2.inicioOperacion
                Gempresas.Ruc = empresa2.ruc

                getEstablecimiento(codEmpresa)
                ObtenerConfiguracionPorEmpresa(codEmpresa)
                Anios(codEmpresa)
                lblempresaNom.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                '           ObtenerTipoCambioMax()
            End If
        End If
        txtFechaInicio.Value = DateTime.Now
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MonthPeriodo_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub MonthPeriodo_SelectionChanged(sender As Object, e As EventArgs)
        UbicarTC()
    End Sub

    Private Sub bgGeneral_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgGeneral.DoWork
        Hilo()
    End Sub

    Private Sub bgGeneral_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgGeneral.RunWorkerCompleted
        cboEmpresa.DisplayMember = "razonSocial"
        cboEmpresa.ValueMember = "idEmpresa"
        cboEmpresa.DataSource = empresa
        ObtenerTipoCambioMax()
        GradientPanel14.Enabled = True
        fedd.Hide()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim f As New frmEmpresaNumeracionInicio(cboEmpresa.SelectedValue)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Try
            Gempresas = New GEmpresa
            Gempresas.IdEmpresaRuc = cboEmpresa.SelectedValue
            Gempresas.NomEmpresa = cboEmpresa.Text

            GEstableciento = New GEstablecimiento
            GEstableciento.IdEstablecimiento = cboEstablecimiento.SelectedValue
            GEstableciento.NombreEstablecimiento = cboEstablecimiento.Text

            AnioGeneral = cboAnio.Text
            MesGeneral = String.Format("{0:00}", txtFechaInicio.Value.Month)
            DiaLaboral = txtFechaInicio.Value

            Dim f As New frmInicioTrabajoEmpresa(cboEmpresa.SelectedValue)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            cboEmpresa_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim f As New frmDetalleEmpresa
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim objEmpresa = CType(f.Tag, empresa)
            Dim f1 As New frmEmpresaNumeracionInicio(objEmpresa.idEmpresa)
            f1.StartPosition = FormStartPosition.CenterParent
            f1.ShowDialog()
            Hilo()
            cboEmpresa.DisplayMember = "razonSocial"
            cboEmpresa.ValueMember = "idEmpresa"
            cboEmpresa.DataSource = empresa
            cboEmpresa.SelectedValue = objEmpresa.idEmpresa

            getEstablecimiento(objEmpresa.idEmpresa)
            ObtenerConfiguracionPorEmpresa(objEmpresa.idEmpresa)
            Anios(objEmpresa.idEmpresa)

            Dim f2 As New frmInicioTrabajoEmpresa(objEmpresa.idEmpresa)
            f2.StartPosition = FormStartPosition.CenterParent
            f2.ShowDialog()

            ObtenerTipoCambioMax()
        End If

    End Sub

    Private Sub txtFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicio.ValueChanged
        If cboEmpresa.Text.Trim.Length > 0 Then
            Dim FechaActual = New Date(Integer.Parse(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day)
            If Gempresas IsNot Nothing Then
                OntenerTCxFecha(FechaActual)
            End If
        End If
    End Sub

    Private Sub OntenerTCxFecha(fecha As Date)
        Dim tipoCambioSA As New tipoCambioSA
        Dim TC = tipoCambioSA.GeTipoCambioXfecha(Gempresas.IdEmpresaRuc, fecha, GEstableciento.IdEstablecimiento)
        If TC IsNot Nothing Then
            txtFechaTC.Value = TC.fechaIgv
            nudTipoCambioCompra.DecimalValue = TC.compra
            nudTipoCambioVenta.DecimalValue = TC.venta
        Else
            txtFechaTC.IsNullDate = True
            nudTipoCambioCompra.DecimalValue = 0
            nudTipoCambioVenta.DecimalValue = 0
        End If
    End Sub
End Class