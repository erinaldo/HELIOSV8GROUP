Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmModalHistorialOS

    Public lblIdDocumento As Integer
    Public secuencia As Integer
    Public ManipulacionEstado As String

    Public Sub New()
        InitializeComponent()
        fechainicio.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        fechafin.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)

    End Sub

#Region "Metodos"
    Sub GrabarSolicitud()
        Dim CompraSA As New DocumentoOtrosDatosSA
        Dim ndocumentoOtros As New documentoOtrosDatos()
        Dim ndocumentoCompraDetalle As New documentocompradetalle()

        With ndocumentoCompraDetalle
            .secuencia = secuencia
            .situacion = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO
        End With

        With ndocumentoOtros
            .idDocumento = lblIdDocumento
            .CentroCostos = GEstableciento.IdEstablecimiento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .moneda = Nothing
            .fechaInicio = fechainicio.Value
            .fechaFin = fechafin.Value
            .condicionPago = Nothing
            .Vcto = Nothing
            .Modalidad = Nothing
            .ctaDeposito = Nothing
            .institucionFinanciera = Nothing
            .estado = "P"
            .objetoContratacion = txtContra.Text
            .periodoValorizacion = cboObjetoContratacion.SelectedItem
            .penalidades = Nothing
            .importeContratacionMN = txtImporteContratacion.Value
            .importeContratacionME = txtImporteContratacionME.Value
            .adelantoMN = Nothing
            .adelantoME = Nothing
            If (txtDetracciones.Text.Length > 0) Then
                .detraccionesMN = txtDetracciones.Text
            Else
                .detraccionesMN = Nothing
            End If

            If (txtFGarantia.Text.Length > 0) Then
                .fondoGarantiaMN = txtFGarantia.Text
            Else
                .fondoGarantiaMN = Nothing
            End If

            .detraccionesME = Nothing

            .fondoGarantiaME = Nothing
            .idReferencia = secuencia
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        CompraSA.GrabarDatosEntregaOrdenes(ndocumentoOtros, ndocumentoCompraDetalle)

    End Sub
#End Region

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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim n As New RecuperarEntregables()
        Dim datos As List(Of RecuperarEntregables) = RecuperarEntregables.Instance()
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtContra.Text.Trim.Length > 0 Then
                PanelError.Visible = True
                lblEstado.Text = "Ingresar un objeto de contratación"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtImporteContratacion.Text.Trim.Length > 0 Then
                PanelError.Visible = True
                lblEstado.Text = "Ingresar importe de contratación"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not cboObjetoContratacion.Text.Trim.Length > 0 Then
                PanelError.Visible = True
                lblEstado.Text = "Ingresar un periodo de contratacíon"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            'If Not txtAdelanto.Text.Trim.Length > 0 Then
            '    PanelError.Visible = True
            '    lblEstado.Text = "Ingresar un adelanto"
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If

            'If Not txtFondoGarantia.Text.Trim.Length > 0 Then
            '    PanelError.Visible = True
            '    lblEstado.Text = "Ingresar un fondo de garantia"
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If

            'If Not txtPenalidades.Text.Trim.Length > 0 Then
            '    PanelError.Visible = True
            '    lblEstado.Text = "Ingresar la penalidad"
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If

            datos.Clear()
            n.nombreItem = txtContra.Text
            n.objetoContratacion = txtNombreEntregable.Text
            n.periodoValorizacion = cboObjetoContratacion.Text
            n.importeMN = txtImporteContratacion.Value
            n.importeME = txtImporteContratacionME.Value
            n.fechaIncio = fechainicio.Value
            n.fechaFin = fechafin.Value
            datos.Add(n)

            'GrabarSolicitud()
            Dispose()
            'If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
            '    limpiarCaja()
            '    GroupBox3.Enabled = False
            '    Me.dgvServicio.Table.CurrentRecord.SetValue("estado", True)
            '    Me.dgvServicio.Table.CurrentRecord.SetValue("descripcionEstado", "Listo")
            'End If
            'Else
            'UpdateOtros()
            'End If
            'Else
            'PanelError.Visible = True
            'Me.lblEstado.Text = "Debe seleccionar un entregable!"
            'Timer1.Enabled = True
            'TiempoEjecutar(10)

            'End If
        Catch ex As Exception
            PanelError.Visible = True
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToggleButton1_ToggleStateChanged(sender As Object, e As ToggleStateChangedEventArgs) Handles ToggleButton1.ToggleStateChanged
        If ToggleButton1.ToggleState = ToggleButtonState.Active Then
            txtFGarantia.Visible = True
            txtFGarantia.Select()
            lblFGarantia.Visible = True
        ElseIf ToggleButton1.ToggleState = ToggleButtonState.Inactive Then
            txtFGarantia.Visible = False
            txtFGarantia.Select()
            lblFGarantia.Visible = False
        End If
    End Sub

    Private Sub tbDetraccion_ToggleStateChanged(sender As Object, e As ToggleStateChangedEventArgs) Handles tbDetraccion.ToggleStateChanged
       If tbDetraccion.ToggleState = ToggleButtonState.Active Then
            txtDetracciones.Visible = True
            txtDetracciones.Select()
            lblDetracciones.Visible = True
        ElseIf tbDetraccion.ToggleState = ToggleButtonState.Inactive Then
            txtDetracciones.Visible = False
            txtDetracciones.Select()
            lblDetracciones.Visible = False
        End If
    End Sub
End Class