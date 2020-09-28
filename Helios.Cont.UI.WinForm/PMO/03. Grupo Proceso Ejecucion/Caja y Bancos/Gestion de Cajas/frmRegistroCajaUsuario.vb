Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmRegistroCajaUsuario

    Sub GrabarButton()
        Try
            If Not txtEstablecimiento.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un establecimiento!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            If Not txtCaja.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una caja válida!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            If Not txtPersona.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un personal!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If

            If Not txtFondoMN.Value > 0 Then
                lblEstado.Text = "Ingrese un fondo mayor a cero!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            lblEstado.Text = "Proceso normal"
            lblEstado.Image = My.Resources.ok4
            Grabar()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey( _
     ByRef msg As System.Windows.Forms.Message, _
     ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If (keyData <> Keys.Control + Keys.G) And (keyData <> Keys.F2) Then _
            Return MyBase.ProcessCmdKey(msg, keyData)


        If Keys.Control + Keys.G Then

            Me.Cursor = Cursors.WaitCursor
            GrabarButton()
            Me.Cursor = Cursors.Arrow
        End If

        Return True

    End Function

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

#Region "Métodos"
    Public Function Glosa() As String
        Return "Por Apertura de caja a Usuario " & txtPersona.Text.Trim
    End Function

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

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9903"
            .fechaProceso = txtFechaApertura.Value
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text
            .periodo = lblPeriodo.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = "VOCJ"
            .codigoProveedor = txtPersona.ValueMember
            .fechaProceso = txtFechaApertura.Value
            .fechaCobro = txtFechaApertura.Value
            .tipoDocPago = "9903"
            .numeroDoc = 0 ' txtNumeroComp.Text
            .moneda = IIf(rbNac.Checked = True, "1", "2")
            .entidadFinanciera = txtCaja.ValueMember
            .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .numeroOperacion = "00001" 'txtNumeroComp.Text
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value
          
            .glosa = Glosa()
            .entregado = "SI"
            .usuarioModificacion = "Jiuni"
            .fechaModificacion = DateTime.Now
        End With
        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = txtFechaApertura.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "POR APERTURA DE CAJA"
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
        
        ndocumentoCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
      
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        With objCaja
            .periodo = lblPeriodo.Text
            .idPersona = txtPersona.ValueMember
            .idCajaOrigen = txtCaja.ValueMember
            .idCajaDestino = txtCajaDestino.ValueMember
            .moneda = IIf(rbNac.Checked = True, "1", "2")
            .tipoCambio = txtTipoCambio.Value
            .fechaRegistro = txtFechaApertura.Value
            .fondoMN = txtFondoMN.Value
            .fondoME = txtFondoME.Value
            .claveIngreso = txtClave.Text.Trim
            .ingresoAdicMN = 0
            .ingresoAdicME = 0
            .otrosIngresosMN = 0
            .otrosIngresosME = 0
            .otrosEgresosMN = 0
            .otrosEgresosME = 0
            .estadoCaja = "A"
            .enUso = "N"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        'documentoCajaSA.SaveGroupCajaApertura(ndocumento, objCaja)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

       

        Dispose()
    End Sub
#End Region

    Public Sub UbicarCAja(IntIDCaja As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA

        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        With estadoF.GetUbicar_estadosFinancierosPorID(IntIDCaja)
            txtCaja.ValueMember = .idestado
            Select Case .tipo
                Case "BC"
                    cboTipo.Text = "BANCO"
                Case Else
                    cboTipo.Text = "EFECTIVO"
            End Select

            txtCaja.Text = .descripcion
            txtCuenta.Text = .cuenta
        End With
    End Sub

    Sub CajaSelecionadaShowed()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        'With frmModalEstadosFinancieros
        '    .ObtenerEstadosFinancieros(txtEstablecimiento.ValueMember, IIf(cboTipo.Text = "EFECTIVO", "EF", "BC"), IIf(rbNac.Checked = True, "1", "2"))
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtCaja.ValueMember = datos(0).ID
        '        txtCaja.Text = datos(0).NombreCampo
        '        txtCuenta.Text = datos(0).Codigo
        '        '   glosa()
        '        'txtNumCaja.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub CajaSelecionadaDestino()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        'With frmModalEstadosFinancieros
        '    .ObtenerEstadosFinancieros(txtEstablecimiento.ValueMember, IIf(cboTipoCajaDestino.Text = "EFECTIVO", "EF", "BC"), IIf(rbNac.Checked = True, "1", "2"))
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        If txtCaja.ValueMember = datos(0).ID Then
        '            lblEstado.Text = "Ingrese una cuenta diferente a la de origen!"
        '            lblEstado.Image = My.Resources.warning2
        '            Timer1.Enabled = True
        '            TiempoEjecutar(5)
        '        Else
        '            txtCajaDestino.ValueMember = datos(0).ID
        '            txtCajaDestino.Text = datos(0).NombreCampo
        '            txtCuentaCajaDestino.Text = datos(0).Codigo
        '            lblEstado.Text = "Cuenta seleccionada!"
        '            lblEstado.Image = My.Resources.ok4
        '            txtPersona.Select()
        '        End If

        '        '   glosa()
        '        'txtNumCaja.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalEstablecimientoCaja
        '    .StrParametroCarga = "ET"
        '    .ObtenerEstablecimientos()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then

        '        txtEstablecimiento.ValueMember = datos(0).ID
        '        txtEstablecimiento.Text = datos(0).NombreCampo
        '    Else

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.TextChanged

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        CajaSelecionadaShowed()
    End Sub
    Sub TrabajadoresShow()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalPersonas
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtPersona.ValueMember = datos(0).ID
                txtPersona.Text = datos(0).NombreEntidad
            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        TrabajadoresShow()
    End Sub

    Private Sub frmRegistroCajaUsuario_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    End Sub

    Private Sub QRibbonApplicationButton2_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton2.ItemActivating
        Try
            If Not txtEstablecimiento.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un establecimiento!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            If Not txtCaja.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una caja válida!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            If Not txtPersona.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un personal!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If

            If Not txtFondoMN.Value > 0 Then
                lblEstado.Text = "Ingrese un fondo mayor a cero!"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Exit Sub
            End If
            lblEstado.Text = "Proceso normal"
            lblEstado.Image = My.Resources.ok4
            Grabar()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End Try
     
    End Sub

    Private Sub frmRegistroCajaUsuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub cboTipoCajaDestino_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoCajaDestino.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTipoCajaDestino_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoCajaDestino.TextChanged

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        CajaSelecionadaDestino()
    End Sub


    Private Sub txtPersona_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPersona.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtClave.Select()
        End If
    End Sub

    Private Sub txtPersona_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPersona.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtFechaApertura.Select()
        End If
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub txtFechaApertura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaApertura.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtFondoMN.Select()
        End If
    End Sub

    Private Sub txtFechaApertura_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaApertura.ValueChanged

    End Sub
    Sub calculos()
      
        If txtTipoCambio.Value > 0 Then
            txtFondoME.Value = Math.Round(txtFondoMN.Value / txtTipoCambio.Value, 2)
        Else

        End If


    End Sub
    Private Sub txtFondoMN_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFondoMN.ValueChanged
        calculos()
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        calculos()
    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub
End Class