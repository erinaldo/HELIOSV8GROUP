Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports ExtendedListBoxControl.ExtendedListBoxItemClasses
Public Class frmPrueba

    Public idExistencia As Integer
    Public idAlmacen As Integer

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Select Case LinkLabel1.Text
            Case "1. Compra al credito c/recep. exist."

                Dim cierreSA As New CierreContableSA
                Dim cierre As New cierrecontable
                cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                If Not IsNothing(cierre) Then
                    'Select Case cierre.estado
                    '    Case "C"
                    '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                    '        PanelError.Visible = True
                    '        Timer1.Enabled = True
                    '        TiempoEjecutar(10)
                    '    Case "A"
                    '        With frmCompraCreditoConRecepcion
                    '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                    '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    '            .lblPerido.Text = PeriodoGeneral
                    '            .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                    '            .StartPosition = FormStartPosition.CenterParent
                    '            .WindowState = FormWindowState.Maximized
                    '            .ShowDialog()
                    '            Dispose()
                    '        End With

                    'End Select
                Else

                    With frmCompraCreditoConRecepcion
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                        Dispose()
                    End With
                End If
        End Select
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Select Case LinkLabel2.Text
            Case "2. Compra al credito c/exist. transit."

                Dim cierreSA As New CierreContableSA
                Dim cierre As New cierrecontable
                cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                If Not IsNothing(cierre) Then
                    'Select Case cierre.estado
                    '    Case "C"
                    '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                    '        PanelError.Visible = True
                    '        Timer1.Enabled = True
                    '        TiempoEjecutar(10)
                    '    Case "A"
                    '        With frmCompraCreditoSinRecepcion
                    '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                    '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    '            .lblPerido.Text = PeriodoGeneral
                    '            .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                    '            .StartPosition = FormStartPosition.CenterParent
                    '            .WindowState = FormWindowState.Maximized
                    '            .ShowDialog()
                    '            Dispose()
                    '        End With

                    'End Select
                Else
                    With frmCompraCreditoSinRecepcion
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .lblPerido.Text = PeriodoGeneral
                        .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                        Dispose()
                    End With
                End If
        End Select
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Select Case LinkLabel4.Text
            Case "3. Compra al contado c/exist. transit."

                Dim cierreSA As New CierreContableSA
                Dim cierre As New cierrecontable
                cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                If Not IsNothing(cierre) Then
                    'Select Case cierre.estado
                    '    Case "C"
                    '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                    '        PanelError.Visible = True
                    '        Timer1.Enabled = True
                    '        TiempoEjecutar(10)
                    '    Case "A"
                    '        With frmCompraPagadaSinRecepcion
                    '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '            If .TieneCuentaFinanciera = True Then

                    '                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                    '                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    '                .lblPerido.Text = PeriodoGeneral
                    '                .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                    '                .StartPosition = FormStartPosition.CenterParent
                    '                '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                    '                .WindowState = FormWindowState.Maximized
                    '                .ShowDialog()
                    '                Dispose()
                    '            Else
                    '                PanelError.Visible = True
                    '                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                    '                Timer1.Enabled = True
                    '                TiempoEjecutar(5)
                    '            End If
                    '        End With

                    'End Select
                Else
                    With frmCompraPagadaSinRecepcion
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        If .TieneCuentaFinanciera = True Then
                            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            .lblPerido.Text = PeriodoGeneral
                            .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                            .StartPosition = FormStartPosition.CenterParent
                            '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                            .WindowState = FormWindowState.Maximized
                            .ShowDialog()
                            Dispose()
                        Else
                            PanelError.Visible = True
                            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        End If
                    End With
                End If
        End Select
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Select Case LinkLabel3.Text
            Case "4. Compra al contado c/recep. exist."

                Dim cierreSA As New CierreContableSA
                Dim cierre As New cierrecontable
                cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                If Not IsNothing(cierre) Then
                    'Select Case cierre.estado
                    '    Case "C"
                    '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                    '        PanelError.Visible = True
                    '        Timer1.Enabled = True
                    '        TiempoEjecutar(10)
                    '    Case "A"
                    '        With frmCompraDirectaRecepcion
                    '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '            If .TieneCuentaFinanciera = True Then
                    '                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                    '                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    '                .lblPerido.Text = PeriodoGeneral
                    '                .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                    '                .StartPosition = FormStartPosition.CenterParent
                    '                .WindowState = FormWindowState.Maximized
                    '                .ShowDialog()
                    '                Dispose()
                    '            Else
                    '                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                    '                PanelError.Visible = True
                    '                Timer1.Enabled = True
                    '                TiempoEjecutar(5)
                    '            End If
                    '        End With
                    'End Select
                Else
                    ' MsgBox("")
                    With frmCompraDirectaRecepcion
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        If .TieneCuentaFinanciera = True Then
                            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            .lblPerido.Text = PeriodoGeneral
                            .ExistenciaPorNotificacion(idExistencia, idAlmacen)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .ShowDialog()
                            Dispose()
                        Else
                            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        End If
                    End With
                End If
        End Select
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

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked

    End Sub
End Class