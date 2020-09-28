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
Public Class frmDetalleOrdenServicio
    Inherits frmMaster

    Public Property Flag() As String
    Dim UserControl1 As New ucConfiguracion
    Dim toolTip As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public idDocumento As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime
    Public lblIdDocumento As Integer
    Public secuencia As Integer

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        limpiarCaja()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        fechainicio.Value = Date.Now.Date
        fechafin.Value = Date.Now.Date

        GridCFG(dgvServicio)
        txtFecha.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
    End Sub

    Private Sub txtContra_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            cboObjetoContratacion.Select()
            cboObjetoContratacion.SelectedIndex = -1
        End If
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

#Region "metodo"

    Sub actualizaDataGridEstado()
        Dim n As New RecuperarCarteras()
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Dim conteo As Integer = 0

        For Each r As Record In dgvServicio.Table.Records
            If (r.GetValue("estado") = False) Then
                conteo += 1
            End If
        Next

        If (conteo = 0) Then
            datos.Clear()
            n.IdProceso = 1
            datos.Add(n)
            ToolStripButton1.Visible = True
        Else
            ToolStripButton1.Visible = False
            'limpiarCaja()
            'PanelError.Visible = True
            'Me.lblEstado.Text = "Existe entregables pendiente."
            'Timer1.Enabled = True
            'TiempoEjecutar(10)

        End If
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub UpdateDoc(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Public Sub UbicarDocumentoServicio(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
      
        Dim dt As DataTable
        dt = New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("descripcionItem", GetType(String))
        dt.Columns.Add("descripcionEstado", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeUS", GetType(Decimal))

        For Each row In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.secuencia
            dr(2) = row.descripcionItem
            If row.situacion = TIPO_COMPRA.ORDEN_SERVICIO Then
                dr(3) = "PENDIENTE"
                dr(4) = False
            Else
                dr(3) = "EXITO EN INGRESO"
                dr(4) = True
            End If
            dr(5) = row.importe
            dr(6) = row.importeUS
            dt.Rows.Add(dr)


        Next
        Me.dgvServicio.DataSource = dt
        Me.dgvServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
    End Sub

    Sub UpdateOtros()
        Dim nRecursoSA As New DocumentoOtrosDatosSA
        Dim nRecurso As New documentoOtrosDatos
        nRecurso = New documentoOtrosDatos With {
            .idDocumento = CInt(lblIdDocumento),
            .fechaInicio = fechainicio.Value,
            .fechaFin = fechafin.Value,
             .estado = "P",
             .objetoContratacion = txtContra.Text,
              .periodoValorizacion = cboObjetoContratacion.SelectedItem,
              .penalidades = txtPenalidades.Text,
            .importeContratacionMN = txtImporteContratacion.Value,
             .importeContratacionME = txtImporteContratacionME.Value,
            .adelantoMN = txtAdelanto.Value,
            .adelantoME = txtAdelantoME.Value,
            .detraccionesMN = nudDetraccion.Value,
            .detraccionesME = nudDetraccionME.Value,
            .fondoGarantiaMN = txtFondoGarantia.Value,
             .fondoGarantiaME = txtFondoGarantiaME.Value,
               .idReferencia = secuencia,
            .usuarioActualizacion = "Jiuni",
            .fechaActualizacion = DateTime.Now}


        If (nRecursoSA.UpdateOtros(nRecurso)) Then

            PanelError.Visible = True
            lblEstado.Text = " editado!"
            Timer1.Enabled = True
            TiempoEjecutar(10)

        Else
            PanelError.Visible = True
            lblEstado.Text = "Error al grabar Cadena!"
            Timer1.Enabled = True
            TiempoEjecutar(10)

        End If
    End Sub

    Public Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoOtrosDatosSA
        Dim docOtros As New DocumentoOtrosDatosSA
       
        With docOtros.UbicarDocumentoOtrosReferencia(intIdDocumento)
            fechainicio.Value = .fechaInicio
            fechafin.Value = .fechaFin

            txtContra.Text = .objetoContratacion
            cboObjetoContratacion.SelectedItem = .periodoValorizacion
            txtPenalidades.Text = .penalidades

            txtImporteContratacion.Value = .importeContratacionMN
            txtImporteContratacionME.Value = .importeContratacionME
            If (.detraccionesMN <> 0) Then
                nudDetraccion.Value = .detraccionesMN
                nudDetraccionME.Value = .detraccionesME
                tbDetraccion.ToggleState = ToggleButtonState.Active
            Else
                nudDetraccion.Value = 0
                nudDetraccionME.Value = 0
                tbDetraccion.ToggleState = ToggleButtonState.Inactive
            End If

            txtAdelanto.Value = .adelantoMN
            txtAdelantoME.Value = .adelantoME
            txtFondoGarantia.Value = .fondoGarantiaMN
            txtFondoGarantiaME.Value = .fondoGarantiaME

        End With

    End Sub

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
            .penalidades = txtPenalidades.Text
            .importeContratacionMN = txtImporteContratacion.Value
            .importeContratacionME = txtImporteContratacionME.Value
            .adelantoMN = txtAdelanto.Value
            .adelantoME = txtAdelantoME.Value
            .detraccionesMN = nudDetraccion.Value
            .detraccionesME = nudDetraccionME.Value
            .fondoGarantiaMN = txtFondoGarantia.Value
            .fondoGarantiaME = txtFondoGarantiaME.Value
            .idReferencia = secuencia
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        CompraSA.GrabarDatosEntregaOrdenes(ndocumentoOtros, ndocumentoCompraDetalle)

    End Sub

    Private Sub fechafin_ValueChanged(sender As Object, e As EventArgs)
        Try
            If (fechafin.Value < fechainicio.Value) Then
                PanelError.Visible = True
                lblEstado.Text = "Debe Ingresar una fecha correcta"
                fechafin.Value = Date.Now
                Timer1.Enabled = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

#End Region

    'Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs)
    '    Dim n As New RecuperarCarteras()
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()

    '    datos.Clear()
    '    n.NombreEntidad = txtContra.Text
    '    n.ID = txtImporteContratacion.Value
    '    n.IdResponsable = txtPeriodoValorizacion.Text
    '    n.Apmat = txtAdelanto.Value
    '    n.Appat = txtFondoGarantia.Value
    '    n.Cuenta = txtPenalidades.Text
    '    n.IDEstable = nudDetraccion.Value
    '    n.NomEvento = fechainicio.Value
    '    n.NomProceso = fechafin.Value
    '    datos.Add(n)
    '    Dispose()

    'End Sub

    Private Sub txtPenalidades_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtImporteContratacion.Focus()
            txtImporteContratacion.Select(0, txtImporteContratacion.Text.Length)
        End If
    End Sub

    Private Sub tbDetraccion_KeyDown(sender As Object, e As KeyEventArgs) Handles tbDetraccion.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If tbDetraccion.ToggleState = ToggleButtonState.Active Then
                nudDetraccion.Visible = True
                nudDetraccion.Select()
                nudDetraccion.Select(txtImporteContratacion.Text.Length, 0)
            ElseIf tbDetraccion.ToggleState = ToggleButtonState.Inactive Then
                nudDetraccion.Visible = False
            End If
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

    Private Sub btGrabar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvServicio_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvServicio.TableControlCellClick
        If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
            If (Me.dgvServicio.Table.CurrentRecord.GetValue("estado") = True) Then
                limpiarCaja()
                GroupBox3.Enabled = True
                txtContra.Select()
                txtNombreEntregable.Text = Me.dgvServicio.Table.CurrentRecord.GetValue("descripcionItem")
                UbicarDocumentos(Me.dgvServicio.Table.CurrentRecord.GetValue("secuencia"))
                secuencia = Me.dgvServicio.Table.CurrentRecord.GetValue("secuencia")
                lblIdDocumento = Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento")
                txtImporteContratacion.Value = Me.dgvServicio.Table.CurrentRecord.GetValue("importe")
                txtImporteContratacionME.Value = Me.dgvServicio.Table.CurrentRecord.GetValue("importeUS")
            Else
                limpiarCaja()
                GroupBox3.Enabled = True
                txtContra.Select()
                txtNombreEntregable.Text = Me.dgvServicio.Table.CurrentRecord.GetValue("descripcionItem")
                secuencia = Me.dgvServicio.Table.CurrentRecord.GetValue("secuencia")
                lblIdDocumento = Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento")
                txtImporteContratacion.Value = Me.dgvServicio.Table.CurrentRecord.GetValue("importe")
                txtImporteContratacionME.Value = Me.dgvServicio.Table.CurrentRecord.GetValue("importeUS")
            End If
        End If

    End Sub

    Private Sub limpiarCaja()
        txtContra.Text = String.Empty
        cboObjetoContratacion.SelectedIndex = -1
        txtImporteContratacion.Value = 0.0
        txtAdelanto.Value = 0.0
        txtFondoGarantia.Text = 0.0
        nudDetraccion.Value = 0.0
        txtImporteContratacionME.Value = 0.0
        txtAdelantoME.Value = 0.0
        txtFondoGarantiaME.Text = 0.0
        nudDetraccionME.Value = 0.0
        txtPenalidades.Text = String.Empty
        fechainicio.Value = Date.Now
        fechafin.Value = Date.Now
        tbDetraccion.ToggleState = ToggleButtonState.Inactive
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtImporteContratacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteContratacion.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtImporteContratacionME.Value = CDec(txtImporteContratacion.Value / TmpIGV)
            txtAdelanto.Focus()
            txtAdelanto.Select(0, txtImporteContratacion.Text.Length)
        End If

    End Sub

    Private Sub txtAdelanto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAdelanto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtAdelantoME.Value = CDec(txtAdelanto.Value / TmpIGV)
            txtFondoGarantia.Select()
            txtFondoGarantia.Select(0, txtImporteContratacion.Text.Length)
        End If

    End Sub

    Private Sub txtFondoGarantia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFondoGarantia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtFondoGarantiaME.Value = CDec(txtFondoGarantia.Value / TmpIGV)
            tbDetraccion.Select()
        End If

    End Sub

    Private Sub nudDetraccion_KeyDown(sender As Object, e As KeyEventArgs) Handles nudDetraccion.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudDetraccionME.Value = CDec(nudDetraccion.Value / TmpIGV)
            fechainicio.Select()
        End If

    End Sub

    Private Sub cboObjetoContratacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cboObjetoContratacion.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtPenalidades.Select()
        End If
    End Sub

    Private Sub fechafin_ValueChanged_1(sender As Object, e As EventArgs) Handles fechafin.ValueChanged
        If (fechafin.Value < fechainicio.Value) Then
            fechafin.Value = Date.Now
        End If
    End Sub


    'Me.Cursor = Cursors.WaitCursor
    '   Try
    '       If Not txtContra.Text.Trim.Length > 0 Then
    '           PanelError.Visible = True
    '           lblEstado.Text = "Ingresar un objeto de contratación"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)
    '           Me.Cursor = Cursors.Arrow
    '           Exit Sub
    '       End If

    '       If Not txtImporteContratacion.Text.Trim.Length > 0 Then
    '           PanelError.Visible = True
    '           lblEstado.Text = "Ingresar importe de contratación"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)
    '           Me.Cursor = Cursors.Arrow
    '           Exit Sub
    '       End If

    '       If Not cboObjetoContratacion.Text.Trim.Length > 0 Then
    '           PanelError.Visible = True
    '           lblEstado.Text = "Ingresar un periodo de contratacíon"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)
    '           Me.Cursor = Cursors.Arrow
    '           Exit Sub
    '       End If

    '       If Not txtAdelanto.Text.Trim.Length > 0 Then
    '           PanelError.Visible = True
    '           lblEstado.Text = "Ingresar un adelanto"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)
    '           Me.Cursor = Cursors.Arrow
    '           Exit Sub
    '       End If

    '       If Not txtFondoGarantia.Text.Trim.Length > 0 Then
    '           PanelError.Visible = True
    '           lblEstado.Text = "Ingresar un fondo de garantia"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)
    '           Me.Cursor = Cursors.Arrow
    '           Exit Sub
    '       End If

    '       If Not txtPenalidades.Text.Trim.Length > 0 Then
    '           PanelError.Visible = True
    '           lblEstado.Text = "Ingresar la penalidad"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)
    '           Me.Cursor = Cursors.Arrow
    '           Exit Sub
    '       End If

    '       If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
    '           If Me.dgvServicio.Table.CurrentRecord.GetValue("estado") = False Then
    '               GrabarSolicitud()
    '               If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
    '                   limpiarCaja()
    '                   GroupBox3.Enabled = False
    '                   Me.dgvServicio.Table.CurrentRecord.SetValue("estado", True)
    '                   Me.dgvServicio.Table.CurrentRecord.SetValue("descripcionEstado", "Listo")
    '               End If
    '           Else
    '               UpdateOtros()
    '           End If
    '       Else
    '           PanelError.Visible = True
    '           Me.lblEstado.Text = "Debe seleccionar un entregable!"
    '           Timer1.Enabled = True
    '           TiempoEjecutar(10)

    '       End If
    '   Catch ex As Exception
    '       PanelError.Visible = True
    '       lblEstado.Text = ex.Message
    '       Timer1.Enabled = True
    '       TiempoEjecutar(5)
    '   End Try
    '   Me.Cursor = Cursors.Arrow


    Private Sub frmDetalleOrdenServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Dispose()
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

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
            Dim f As New frmModalHistorialOS
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.txtNombreEntregable.Text = Me.dgvServicio.Table.CurrentRecord.GetValue("descripcionItem")
            f.lblIdDocumento = Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento")
            f.secuencia = Me.dgvServicio.Table.CurrentRecord.GetValue("secuencia")
            f.GroupBox3.Enabled = True
            f.txtImporteContratacion.Value = Me.dgvServicio.Table.CurrentRecord.GetValue("importe")
            f.txtImporteContratacionME.Value = Me.dgvServicio.Table.CurrentRecord.GetValue("importeUS")
            f.ShowDialog()
            UbicarDocumentoServicio(idDocumento)
            actualizaDataGridEstado()

        Else
            limpiarCaja()
            PanelError.Visible = True
            Me.lblEstado.Text = "Debe seleecionar un item."
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If MessageBox.Show("Desea aprobar la orden seleccionada?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UpdateDoc(idDocumento)
            Dispose()
        End If
    End Sub
End Class