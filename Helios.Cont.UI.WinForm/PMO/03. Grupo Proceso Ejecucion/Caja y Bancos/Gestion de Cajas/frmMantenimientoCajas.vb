Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMantenimientoCajas
    Inherits frmMaster

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

#Region "mÉTODOS"


    Public Sub EliminarTransferencia(intIdCajaUsuario As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajausuarioBE As New cajaUsuario

        With cajaUsuarioSA.UbicarCajaUsuarioPorID(intIdCajaUsuario)
            cajausuarioBE.idcajaUsuario = .idcajaUsuario
            cajausuarioBE.documentoApertura = .documentoApertura
            cajausuarioBE.documentoCierre = .documentoCierre
        End With

        cajaUsuarioSA.EliminarCajaUsuarioFull(cajausuarioBE)
        lsvCajaUsuario.SelectedItems(0).Remove()
        lblEstado.Text = "caja eliminada!"
    End Sub

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

    Public Sub ObtenerObtenerCajaUsuarios(intIdCaja As Integer)
        Dim cajaSa As New cajaUsuarioSA
        Dim personaSA As New PersonaSA
        Dim efSA As New EstadosFinancierosSA
        lsvCajaUsuario.Items.Clear()

        For Each i In cajaSa.ListarPorCajaPorPeriodo(intIdCaja, lblPerido.Text)
            Dim n As New ListViewItem(i.idcajaUsuario)
            n.UseItemStyleForSubItems = False
            n.SubItems.Add(i.fechaRegistro)
            If IsNothing(i.fechaCierre) Then
                n.SubItems.Add(String.Empty)
            Else
                n.SubItems.Add(i.fechaCierre)
            End If
            n.SubItems.Add(personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, i.idPersona).nombreCompleto)
            n.SubItems.Add(efSA.GetUbicar_estadosFinancierosPorID(i.idCajaDestino).descripcion)
            n.SubItems.Add(i.fondoMN)
            n.SubItems.Add(i.fondoME)
            n.SubItems.Add(i.ingresoAdicMN)
            n.SubItems.Add(i.ingresoAdicME)
            If i.estadoCaja = "N" Then
                n.SubItems.Add("En espera").BackColor = Color.LavenderBlush
            ElseIf i.estadoCaja = "A" Then
                n.SubItems.Add("Abierto").BackColor = Color.Yellow
            ElseIf i.estadoCaja = "C" Then
                With n.SubItems.Add("Cerrado")
                    .BackColor = Color.Crimson
                    .ForeColor = Color.White
                End With
            End If
            n.SubItems.Add(IIf(i.enUso = "S", "Si", "No"))
            lsvCajaUsuario.Items.Add(n)
        Next
        lblEstado.Text = "Proceso correcto"
        lblEstado.Image = My.Resources.ok4
    End Sub
#End Region

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub frmMantenimientoCajas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        'With frmModalCaja
        '    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        '    .ObtenerMascaraMercaderia()
        '    .txtCuentaID.Text = "101"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub frmMantenimientoCajas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        ObtenerListaCajas()
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
            .ObtenerMascaraMercaderia()
            .UbicarPorID(lsvCajas.SelectedItems(0).SubItems(0).Text)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvCajas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCajas.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If lsvCajas.SelectedItems.Count > 0 Then
            ObtenerObtenerCajaUsuarios(lsvCajas.SelectedItems(0).SubItems(0).Text)
            lsvCajas.SelectedItems(0).Selected = True
            lsvCajas.SelectedItems(0).Focused = True
            lsvCajas.FocusedItem.EnsureVisible()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If lsvCajas.SelectedItems.Count > 0 Then
            lsvCajas.FocusedItem.EnsureVisible()
            lsvCajas.SelectedItems(0).Selected = True
            lsvCajas.SelectedItems(0).Focused = True
            With frmRegistroCajaUsuario
                Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
                .txtFechaApertura.Text = New Date(PeriodoGeneral, cfecha.Month, cfecha.Day)
                .lblPeriodo.Text = lblPerido.Text
                .UbicarCAja(lsvCajas.SelectedItems(0).SubItems(0).Text)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                ObtenerObtenerCajaUsuarios(lsvCajas.SelectedItems(0).SubItems(0).Text)
                lsvCajas.SelectedItems(0).Selected = True
                lsvCajas.SelectedItems(0).Focused = True
                lsvCajas.FocusedItem.EnsureVisible()
            End With
        Else
            lblEstado.Text = "Debe seleccionar una cuenta!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If lsvCajaUsuario.SelectedItems.Count > 0 Then
            If lsvCajaUsuario.SelectedItems(0).SubItems(9).Text = "Cerrado" Then
                lblEstado.Text = "La caja esta cerrada"
                lblEstado.Image = My.Resources.warning2
                Timer1.Enabled = True
                TiempoEjecutar(5)
            Else
                With frmCerrarCaja
                    '  .UbicarCaja(lsvCajaUsuario.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    ObtenerObtenerCajaUsuarios(lsvCajas.SelectedItems(0).SubItems(0).Text)
                    lsvCajas.SelectedItems(0).Selected = True
                    lsvCajas.SelectedItems(0).Focused = True
                    lsvCajas.FocusedItem.EnsureVisible()
                End With
            End If

        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If lsvCajaUsuario.SelectedItems.Count > 0 Then
            With frmArqueoCaja
                .ConsultaReporte(lsvCajaUsuario.SelectedItems(0).SubItems(0).Text)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            lblEstado.Text = "Seleccionar una caja activa!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Private Sub btnEliminarCaja_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCaja.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvCajaUsuario.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarTransferencia(lsvCajaUsuario.SelectedItems(0).SubItems(0).Text)
                ObtenerObtenerCajaUsuarios(lsvCajas.SelectedItems(0).SubItems(0).Text)
                lsvCajas.SelectedItems(0).Selected = True
                lsvCajas.SelectedItems(0).Focused = True
                lsvCajas.FocusedItem.EnsureVisible()
            End If
        Else
            lblEstado.Text = "Debe seleccionar un registro a eliminar?"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPerido.Text = "01" & "/" & PeriodoGeneral
            Case "FEBRERO"
                lblPerido.Text = "02" & "/" & PeriodoGeneral
            Case "MARZO"
                lblPerido.Text = "03" & "/" & PeriodoGeneral
            Case "ABRIL"
                lblPerido.Text = "04" & "/" & PeriodoGeneral
            Case "MAYO"
                lblPerido.Text = "05" & "/" & PeriodoGeneral
            Case "JUNIO"
                lblPerido.Text = "06" & "/" & PeriodoGeneral
            Case "JULIO"
                lblPerido.Text = "07" & "/" & PeriodoGeneral
            Case "AGOSTO"
                lblPerido.Text = "08" & "/" & PeriodoGeneral
            Case "SETIEMBRE"
                lblPerido.Text = "09" & "/" & PeriodoGeneral
            Case "OCTUBRE"
                lblPerido.Text = "10" & "/" & PeriodoGeneral
            Case "NOVIEMBRE"
                lblPerido.Text = "11" & "/" & PeriodoGeneral
            Case "DICIEMBRE"
                lblPerido.Text = "12" & "/" & PeriodoGeneral
        End Select
        If lsvCajas.SelectedItems.Count > 0 Then
            ObtenerObtenerCajaUsuarios(lsvCajas.SelectedItems(0).SubItems(0).Text)
            lblEstado.Text = "Proceso correcto!"
            lblEstado.Image = My.Resources.ok4
        Else
            lblEstado.Text = "Seleccione una cuenta válida!"
            lblEstado.Image = My.Resources.warning2
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip1.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub
End Class