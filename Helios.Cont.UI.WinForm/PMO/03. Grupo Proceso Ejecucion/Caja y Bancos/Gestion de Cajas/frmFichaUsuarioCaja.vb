Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmFichaUsuarioCaja
    Inherits frmMaster

    Dim montoMNF As Decimal = 0
    Dim montoMEF As Decimal = 0
    Public ManipulacionEstado As String
    Public Tipo_SituacionCaja As String

#Region "Métodos"
    Public Sub HabilitarUsoCaja()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim NEstadosSA As New estadosFinancieros

        'If Timer1.Enabled = True Then
        '    With cajaUsuario
        '        .idcajaUsuario = txtClave.Tag
        '        .estadoCaja = "A"
        '        .enUso = "S"
        '    End With
        '    cajaUsuarioSA.HabilitarUsoDeCajaUser(cajaUsuario)
        '    lblEstado.Text = "Caja registrada al usuario"
        '    lblEstado.Image = My.Resources.ok4
        'Else
        '    If Not txtDni.Text.Trim.Length > 0 And Not txtClave.Text.Trim.Length > 0 Then
        '        lblEstado.Text = "Complete los campos!"
        '        Exit Sub
        '    Else
        '        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        '        If IsNothing(cajaUsuario) Then
        '            lblEstado.Text = "Usuario/Clave no válidos!"
        '            lblEstado.Image = My.Resources.warning2
        '            Exit Sub
        '        Else
        '            lblEstado.Text = "Datos correctos"
        '            lblEstado.Image = My.Resources.ok4
        '        End If
        '    End If
        'End If
        LoggerUser(txtDni.Text.Trim, txtClave.Text.Trim)
        'GFichaUsuarios = GFichaUsuario.InstanceSingle()
        'GFichaUsuarios.Clear()
        'Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        'With cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        '    NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
        '    GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        '    GFichaUsuarios.IdPersona = .idPersona
        '    GFichaUsuarios.NombrePersona = usuario.Alias
        '    GFichaUsuarios.ClaveUsuario = .claveIngreso
        '    GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        '    GFichaUsuarios.IdCajaDestino = .idCajaOrigen
        '    GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        '    GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        '    GFichaUsuarios.FechaApertura = .fechaRegistro
        '    GFichaUsuarios.Moneda = .moneda
        '    GFichaUsuarios.TipoCambio = .tipoCambio
        '    GFichaUsuarios.FondoMN = .fondoMN
        '    GFichaUsuarios.FondoME = .fondoME
        '    GFichaUsuarios.EstadoCaja = .idcajaUsuario
        '    GFichaUsuarios.EnUso = .idcajaUsuario
        '    UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        'End With
        'With cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        '    NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
        '    GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        '    GFichaUsuarios.IdPersona = .idPersona
        '    GFichaUsuarios.NombrePersona = txtPersona.Text.Trim
        '    GFichaUsuarios.ClaveUsuario = .claveIngreso
        '    GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        '    GFichaUsuarios.IdCajaDestino = .idCajaDestino
        '    GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        '    GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        '    GFichaUsuarios.FechaApertura = .fechaRegistro
        '    GFichaUsuarios.Moneda = .moneda
        '    GFichaUsuarios.TipoCambio = .tipoCambio
        '    GFichaUsuarios.FondoMN = CDec(.fondoMN + (montoMNF))
        '    GFichaUsuarios.FondoME = CDec(.fondoME + (montoMEF))
        '    GFichaUsuarios.EstadoCaja = .idcajaUsuario
        '    GFichaUsuarios.EnUso = .idcajaUsuario
        'End With
        Dispose()
    End Sub

    Public Sub LoggerUser(strNumDoc As String, strClave As String)
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New documentoCaja
        Dim cajaUserSA As New cajaUsuarioSA
        Dim cajaUser As New cajaUsuario
        Dim ingresosMN As Decimal = 0
        Dim ingresosME As Decimal = 0
        Dim egresosMN As Decimal = 0
        Dim egresosME As Decimal = 0

        cajaUser = cajaUserSA.UbicarCajaAsignadaUser(strNumDoc, "A", "N", strClave)
        If Not IsNothing(cajaUser) Then
            caja = cajaSA.ResumenTransaccionesxUsuarioDEP(cajaUser.idcajaUsuario)
            txtBalanceInicial.DecimalValue = cajaUser.fondoMN
            txtBalanceInicialME.DecimalValue = cajaUser.fondoME
            txtTipoCambio.DecimalValue = cajaUser.tipoCambio
            ingresosMN = caja.MontoIngresosMN
            ingresosME = caja.MontoIngresosME

            egresosMN = caja.MontoEgresosMN
            egresosME = caja.MontoEgresosME

            txSaldo.DecimalValue = txtBalanceInicial.DecimalValue + ingresosMN - egresosMN
            txSaldoME.DecimalValue = txtBalanceInicialME.DecimalValue + ingresosME - egresosME
        Else
            MessageBox.Show("La caja no se encuentra activa!")
        End If

    End Sub

    'Public Sub UbicarFicha(strNumDoc As String, strClave As String)
    '    Dim usuarioCajaSA As New cajaUsuarioSA
    '    Dim usuarioCaja As New cajaUsuario
    '    Dim personaSA As New PersonaSA
    '    Dim persona As New Persona
    '    Dim EFSA As New EstadosFinancierosSA
    '    Dim establecSA As New establecimientoSA
    '    Dim cajaSa As New DocumentoCajaSA

    '    Dim compra As Decimal = 0
    '    Dim compraME As Decimal = 0
    '    Dim prestamoOtorgado As Decimal = 0
    '    Dim prestamoOtorgadoME As Decimal = 0
    '    Dim prestamoRecibido As Decimal = 0
    '    Dim prestamoRecibidoME As Decimal = 0
    '    Dim VentasTicket As Decimal = 0
    '    Dim VentasTicketME As Decimal = 0
    '    Dim PagoMN As Decimal = 0
    '    Dim PagoME As Decimal = 0
    '    Dim CobroMN As Decimal = 0
    '    Dim CobroME As Decimal = 0

    '    Dim ingresos As Decimal = 0
    '    Dim ingresosME As Decimal = 0
    '    Dim egresos As Decimal = 0
    '    Dim egresosME As Decimal = 0

    '    Dim AnticipoMN As Decimal = 0
    '    Dim AnticipoME As Decimal = 0
    '    Dim NCDevolucionMN As Decimal = 0
    '    Dim NCDevolucionME As Decimal = 0

    '    usuarioCaja = usuarioCajaSA.UbicarCajaAsignadaUser(strNumDoc, "A", "N", strClave)
    '    If Not IsNothing(usuarioCaja) Then
    '        '   Me.Height = 450

    '        txtClave.Tag = usuarioCaja.idcajaUsuario
    '        txtPersona.Tag = usuarioCaja.idPersona
    '        txtPersona.Text = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, usuarioCaja.idPersona).nombreCompleto
    '        With EFSA.GetUbicar_estadosFinancierosPorID(usuarioCaja.idCajaDestino)
    '            txtEstablecimiento.Tag = .idEstablecimiento
    '            txtEstablecimiento.Text = establecSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
    '            txtCaja.Tag = .idestado
    '            txtCaja.Text = .descripcion
    '        End With
    '        For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, txtClave.Tag)

    '            Select Case i.codigoLibro
    '                Case "02"
    '                    compra = i.montoSoles
    '                    compraME = i.montoUsd
    '                Case "100"
    '                    prestamoOtorgado = i.montoSoles
    '                    prestamoOtorgadoME = i.montoUsd
    '                Case "101"
    '                    prestamoRecibido = i.montoSoles
    '                    prestamoRecibidoME = i.montoUsd
    '                Case "01", "12.1", "12.2"
    '                    VentasTicket += i.montoSoles
    '                    VentasTicketME += i.montoUsd
    '                Case "9907"
    '                    PagoMN = i.montoSoles
    '                    PagoME = i.montoUsd
    '                Case "9908"
    '                    CobroMN = i.montoSoles
    '                    CobroME = i.montoUsd
    '                Case "103"
    '                    AnticipoMN = i.montoSoles
    '                    AnticipoME = i.montoUsd
    '                Case "9912"
    '                    NCDevolucionMN = i.montoSoles
    '                    NCDevolucionME = i.montoUsd
    '            End Select

    '        Next

    '        egresos = CDec(compra + prestamoOtorgado + PagoMN)
    '        egresosME = CDec(compraME + prestamoOtorgadoME + PagoME)

    '        ingresos = CDec(prestamoRecibido + VentasTicket + CobroMN + AnticipoMN)
    '        ingresosME = CDec(prestamoRecibidoME + VentasTicketME + CobroMN + AnticipoME)

    '        montoMNF = ingresos - egresos
    '        montoMEF = ingresosME - egresosME

    '        nupDispMontoMN.Value = CDec(usuarioCaja.fondoMN + (montoMNF))
    '        nupDispMontoME.Value = CDec(usuarioCaja.fondoMN + (montoMNF)) / (CDec(usuarioCaja.tipoCambio))

    '        txtFondoMN.Value = usuarioCaja.fondoMN
    '        txtFondoME.Value = usuarioCaja.fondoME

    '        txtTipoCambio.Value = usuarioCaja.tipoCambio
    '        If usuarioCaja.moneda = "1" Then
    '            cboMoneda.Text = "MONEDA NACIONAL"
    '        Else
    '            cboMoneda.Text = "MONEDA EXTRANJERA"
    '        End If

    '        lblEstado.Text = "Caja habilitada!"
    '        lblEstado.Image = My.Resources.ok4
    '        lblEstadoCaja.Text = "Caja habilitada."
    '        lblEstadoCaja.Tag = "H"

    '    Else
    '        '   Me.Height = 143
    '        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtDni.Text.Trim)
    '        If Not IsNothing(persona) Then
    '            txtFondoMN.Value = 0
    '            txtFondoME.Value = 0
    '            txtPersona.Text = String.Empty
    '            txtEstablecimiento.Text = String.Empty
    '            txtCaja.Text = String.Empty

    '            With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtDni.Text.Trim)
    '                lblEstado.Text = "Usuario encontrado: " & .nombreCompleto
    '                lblEstado.Image = My.Resources.ok4
    '                lblEstado.Tag = "NH"

    '            End With
    '        Else
    '            txtFondoMN.Value = 0
    '            txtFondoME.Value = 0
    '            txtPersona.Text = String.Empty
    '            txtEstablecimiento.Text = String.Empty
    '            txtCaja.Text = String.Empty
    '            lblEstado.Text = "El usuario no tiene una caja habilitada!"
    '            lblEstado.Image = My.Resources.warning2
    '            lblEstadoCaja.Text = "Caja no habilitada."
    '            lblEstadoCaja.Tag = "NH"
    '            nupDispMontoMN.Value = 0
    '            nupDispMontoME.Value = 0
    '        End If
    '    End If

    'End Sub

    'Public Sub UbicarUsuarioCaja(intIdocumento As Integer, strMovimiento As String)
    '    Dim usuarioCajaSA As New cajaUsuarioSA
    '    Dim usuarioCaja As New cajaUsuario
    '    Dim personaSA As New PersonaSA
    '    Dim persona As New Persona
    '    Dim EFSA As New EstadosFinancierosSA
    '    Dim establecSA As New establecimientoSA
    '    Dim documentoCompraSA As New DocumentoCompraSA
    '    Dim documentoVentaSA As New documentoVentaAbarrotesSA
    '    Dim documentoSA As New DocumentoSA
    '    Dim cajaSa As New DocumentoCajaSA

    '    Dim compra As Decimal = 0
    '    Dim compraME As Decimal = 0
    '    Dim prestamoOtorgado As Decimal = 0
    '    Dim prestamoOtorgadoME As Decimal = 0
    '    Dim prestamoRecibido As Decimal = 0
    '    Dim prestamoRecibidoME As Decimal = 0
    '    Dim VentasTicket As Decimal = 0
    '    Dim VentasTicketME As Decimal = 0
    '    Dim PagoMN As Decimal = 0
    '    Dim PagoME As Decimal = 0
    '    Dim CobroMN As Decimal = 0
    '    Dim CobroME As Decimal = 0

    '    Dim ingresos As Decimal = 0
    '    Dim ingresosME As Decimal = 0
    '    Dim egresos As Decimal = 0
    '    Dim egresosME As Decimal = 0

    '    Dim AnticipoMN As Decimal = 0
    '    Dim AnticipoME As Decimal = 0
    '    Dim VentaMN As Decimal = 0
    '    Dim VentaME As Decimal = 0
    '    Dim NCDevolucionMN As Decimal = 0
    '    Dim NCDevolucionME As Decimal = 0

    '    Select Case strMovimiento
    '        Case "COMPRA"
    '            usuarioCaja = usuarioCajaSA.UbicarCajaUsuarioPorID(documentoCompraSA.UbicarDocumentoCompra(intIdocumento).usuarioActualizacion)
    '        Case "VENTA"
    '            usuarioCaja = usuarioCajaSA.UbicarCajaUsuarioPorID(documentoVentaSA.GetUbicar_documentoventaAbarrotesPorID(intIdocumento).usuarioActualizacion)
    '        Case "CUENTAS_POR_PAGAR"
    '            usuarioCaja = usuarioCajaSA.UbicarCajaUsuarioPorID(documentoSA.UbicarDocumento(intIdocumento).usuarioActualizacion)
    '        Case "ANTICIPOS"
    '            usuarioCaja = usuarioCajaSA.UbicarCajaUsuarioPorID(documentoSA.UbicarDocumento(intIdocumento).usuarioActualizacion)
    '    End Select

    '    If Not IsNothing(usuarioCaja) Then
    '        '   Me.Height = 450
    '        txtDni.Text = usuarioCaja.idPersona
    '        txtClave.Tag = usuarioCaja.idcajaUsuario
    '        txtPersona.Tag = usuarioCaja.idPersona
    '        txtPersona.Text = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, usuarioCaja.idPersona).nombreCompleto
    '        With EFSA.GetUbicar_estadosFinancierosPorID(usuarioCaja.idCajaDestino)
    '            txtEstablecimiento.Tag = .idEstablecimiento
    '            txtEstablecimiento.Text = establecSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
    '            txtCaja.Tag = .idestado
    '            txtCaja.Text = .descripcion
    '        End With

    '        For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, usuarioCaja.idcajaUsuario)

    '            Select Case i.codigoLibro
    '                Case "02"
    '                    compra = i.montoSoles
    '                    compraME = i.montoUsd
    '                Case "100"
    '                    prestamoOtorgado = i.montoSoles
    '                    prestamoOtorgadoME = i.montoUsd
    '                Case "101"
    '                    prestamoRecibido = i.montoSoles
    '                    prestamoRecibidoME = i.montoUsd
    '                Case "01"
    '                    VentasTicket = i.montoSoles
    '                    VentasTicketME = i.montoUsd
    '                Case "9907"
    '                    PagoMN = i.montoSoles
    '                    PagoME = i.montoUsd
    '                Case "9908"
    '                    CobroMN = i.montoSoles
    '                    CobroME = i.montoUsd
    '                Case "103"
    '                    AnticipoMN = i.montoSoles
    '                    AnticipoME = i.montoUsd
    '                Case "12.1", "12.2"
    '                    VentaMN += i.montoSoles
    '                    VentaME += i.montoUsd
    '                Case "9912"
    '                    NCDevolucionMN = i.montoSoles
    '                    NCDevolucionME = i.montoUsd
    '            End Select

    '        Next

    '        egresos = CDec(compra + prestamoOtorgado + PagoMN + NCDevolucionMN)
    '        egresosME = CDec(compraME + prestamoOtorgadoME + PagoME + NCDevolucionME)

    '        ingresos = CDec(prestamoRecibido + VentasTicket + CobroMN + AnticipoMN + VentaMN)
    '        ingresosME = CDec(prestamoRecibidoME + VentasTicketME + CobroMN + egresosME + VentaMN)

    '        montoMNF = ingresos - egresos
    '        montoMEF = ingresosME - egresosME

    '        nupDispMontoMN.Value = CDec(usuarioCaja.fondoMN + (montoMNF))
    '        nupDispMontoME.Value = CDec(usuarioCaja.fondoME + (montoMEF))

    '        txtFondoMN.Value = usuarioCaja.fondoMN
    '        txtFondoME.Value = usuarioCaja.fondoME

    '        txtTipoCambio.Value = usuarioCaja.tipoCambio
    '        If usuarioCaja.moneda = "1" Then
    '            cboMoneda.Text = "MONEDA NACIONAL"
    '        Else
    '            cboMoneda.Text = "MONEDA EXTRANJERA"
    '        End If

    '        lblEstado.Text = "Caja habilitada!"
    '        lblEstado.Image = My.Resources.ok4
    '        lblEstadoCaja.Text = "Caja habilitada."
    '        lblEstadoCaja.Tag = "H"

    '    Else
    '        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtDni.Text.Trim)
    '        If Not IsNothing(persona) Then
    '            txtFondoMN.Value = 0
    '            txtFondoME.Value = 0
    '            txtPersona.Text = String.Empty
    '            txtEstablecimiento.Text = String.Empty
    '            txtCaja.Text = String.Empty

    '            With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtDni.Text.Trim)
    '                lblEstado.Text = "Usuario encontrado: " & .nombreCompleto
    '                lblEstado.Image = My.Resources.ok4
    '                lblEstado.Tag = "NH"

    '            End With
    '        Else
    '            txtFondoMN.Value = 0
    '            txtFondoME.Value = 0
    '            txtPersona.Text = String.Empty
    '            txtEstablecimiento.Text = String.Empty
    '            txtCaja.Text = String.Empty
    '            lblEstado.Text = "El usuario no tiene una caja habilitada!"
    '            lblEstado.Image = My.Resources.warning2
    '            lblEstadoCaja.Text = "Caja no habilitada."
    '            lblEstadoCaja.Tag = "NH"
    '            nupDispMontoMN.Value = 0
    '            nupDispMontoME.Value = 0
    '        End If
    '    End If

    'End Sub
#End Region

    Private Sub txtDni_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    If txtDni.Text.Trim.Length > 0 Then
        '        UbicarFicha(txtDni.Text.Trim, txtClave.Text.Trim)
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub frmFichaUsuarioCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'If txtDni.Text.Trim.Length > 0 Then
        '    UbicarFicha(txtDni.Text.Trim, txtClave.Text.Trim)
        'End If
    End Sub

    Private Sub cboMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        'Select Case ModuloAppx
        '    Case ModuloSistema.CAJA
        'If lblEstadoCaja.Tag = "H" Then
        If Not txtDni.Text.Trim.Length > 0 Then
            lblEstado.Text = "Indicar al usuario de la caja"
            '    lblEstado.Image = My.Resources.warning2
            Exit Sub
        End If
        If Not txtClave.Text.Trim.Length > 0 Then
            lblEstado.Text = "Indicar la clave del usuario"
            '   lblEstado.Image = My.Resources.warning2
            Exit Sub
        End If
        '  If (ManipulacionEstado = ENTITY_ACTIONS.INSERT) Then
        If (Tipo_SituacionCaja = TIPO_SITUACION.CAJA_COBRO) Then
            HabilitarUsoCaja()
        Else
            If (txSaldo.DecimalValue > 0.0) Then
                HabilitarUsoCaja()
            Else
                MessageBox.Show("No dispone de fondo")
            End If
        End If

        'ElseIf (ManipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
        '    HabilitarUsoCaja()
        'ElseIf (ManipulacionEstado = ENTITY_ACTIONS.DELETE) Then
        '    HabilitarUsoCaja()
        ' End If
        'Else
        'lblEstado.Text = "verificar datos!!"
        'lblEstado.Image = My.Resources.warning2
        'End If
        ''Case ModuloSistema.PUNTO_DE_VENTA
        '    If Not txtDni.Text.Trim.Length > 0 Then
        '        lblEstado.Text = "Indicar al usuario del punto de venta"
        '        lblEstado.Image = My.Resources.warning2
        '        Exit Sub
        '    End If
        '    Dispose()
        '  frmPMO.LoadPuntoVenta()

        'End Select
    End Sub

    Private Sub frmFichaUsuarioCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDni.Select()
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtDni.Text.Trim.Length > 0 Then
                'UbicarFicha(txtDni.Text.Trim, txtClave.Text.Trim)
                '     UbicarFicha()
                LoggerUser(txtDni.Text.Trim, txtClave.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtClave_TextChanged(sender As Object, e As EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Cursor = Cursors.WaitCursor

        If txtDni.Text.Trim.Length > 0 Then
            If txtClave.Text.Trim.Length > 0 Then
                LoggerUser(txtDni.Text.Trim, txtClave.Text.Trim)
            Else
                MessageBox.Show("Ingrese una clave válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '     UbicarFicha()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
End Class