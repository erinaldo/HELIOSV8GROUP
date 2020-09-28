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
Public Class frmModalHistorialOC

    Public data As New GridGroupingControl
    Public ManipulacionEstado As String
    Public idDocumento As Integer
    Public secuencias As Integer
    Public item As Integer
    Public cantidad As Integer

    Public Sub New()

        InitializeComponent()
        ObtenerListaControlesLoad()

        txtFechaInicioPlazo.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        txtFechaFinPlazo.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        'txtFechaInicioGarantia.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        'txtFechaFinGarantia.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
    End Sub

#Region "Metodos"

    Sub GrabarSolicitud(secuencias As Integer, iditem As Integer)
        Dim CompraSA As New DocumentoOtrosDatosSA
        Dim objDocOtros As New documentoOtrosDatos()
        Dim documentosa As New DocumentoCompraDetalleSA

        Try

            With objDocOtros
                .idAlmacen = cboAlmacen.SelectedValue
                .idReferencia = secuencias
                .fechaInicio = txtFechaInicioPlazo.Value
                .fechaFin = txtFechaFinPlazo.Value
                .FechaIniGarantia = DateTime.Now
                .FechaFinGarantia = DateTime.Now
                .notas = Nothing
                .indicaciones = txtIndicaciones.Text
                .idItem = iditem
                .cantidad = txtCantidad.Text
                .condicionPago = Nothing
                .Vcto = DateTime.Now
                .Modalidad = Nothing
                .ctaDeposito = Nothing
                .institucionFinanciera = Nothing
                .estado = Nothing
                .moneda = Nothing
                .CentroCostos = GEstableciento.IdEstablecimiento
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            CompraSA.GrabarDatosEntregaOrdeneCompra(objDocOtros, idDocumento)

            If (cantidad = txtCantidad.Text) Then
                documentosa.UpdateFullDocOrden(secuencias, TIPO_COMPRA.ORDEN_APROBADO)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Sub GrabarSolicitudFull()
        Dim CompraSA As New DocumentoOtrosDatosSA
        Dim objDocOtros As New documentoOtrosDatos()
        Dim objDocumentoOtroDoc As New documentoOtrosDatos
        Dim ListaDetalle As New List(Of documentoOtrosDatos)
        Dim documentosa As New DocumentoCompraDetalleSA

        Try
            For Each r In data.Table.Records
                objDocumentoOtroDoc = New documentoOtrosDatos
                With objDocumentoOtroDoc
                    .idDocumento = r.GetValue("idDocumento")
                    .idAlmacen = cboAlmacen.SelectedValue
                    .idReferencia = r.GetValue("secuencia")
                    .fechaInicio = txtFechaInicioPlazo.Value
                    .fechaFin = txtFechaFinPlazo.Value
                    .FechaIniGarantia = DateTime.Now
                    .FechaFinGarantia = DateTime.Now
                    .notas = Nothing
                    .indicaciones = txtIndicaciones.Text
                    .idItem = r.GetValue("idItem")
                    .cantidad = CInt(r.GetValue("monto1"))
                    .condicionPago = Nothing
                    .Vcto = DateTime.Now
                    .Modalidad = Nothing
                    .ctaDeposito = Nothing
                    .institucionFinanciera = Nothing
                    .estado = Nothing
                    .moneda = Nothing
                    .CentroCostos = Nothing
                    .usuarioActualizacion = "Jiuni"
                    .fechaActualizacion = DateTime.Now
                End With
                ListaDetalle.Add(objDocumentoOtroDoc)
                documentosa.UpdateFullDocOrden(r.GetValue("secuencia"), TIPO_COMPRA.ORDEN_APROBADO)
            Next
            CompraSA.GrabarDatosEntregaOrdenesFull(ListaDetalle, idDocumento)


        Catch ex As Exception
            lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub ObtenerListaControlesLoad()
        Dim categoriaSA As New itemSA
        Dim almacenSA As New almacenSA

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.SelectedValue = -1
    End Sub


    Public Sub ubicarPorItem(strTipo As Integer, secuencias As Integer, iditems As Integer)

        If (strTipo = 1) Then
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            pnDetallesOC.Enabled = True
            pnExistencia.Visible = False
            pnDetallesOC.Location = New Point(5, 44)
            Tag = "Todo"

        ElseIf (strTipo = 2) Then
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            pnDetallesOC.Enabled = True
            pnExistencia.Visible = True
            pnExistencia.Location = New Point(5, 44)
            pnDetallesOC.Location = New Point(5, 98)
            Tag = "PorItem"
            'secuencias = secuencias
            'item = iditems
        End If

    End Sub

    Public Sub ubicar(strTipo As Integer)

        If (strTipo = 1) Then
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            pnDetallesOC.Enabled = True
            pnExistencia.Visible = False
            pnDetallesOC.Location = New Point(5, 44)
            Tag = "Todo"


        ElseIf (strTipo = 2) Then
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            pnDetallesOC.Enabled = True
            pnExistencia.Visible = True
            pnExistencia.Location = New Point(5, 44)
            pnDetallesOC.Location = New Point(5, 98)
            Tag = "PorItem"

        End If

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
            If Not cboAlmacen.Text.Trim.Length > 0 Then
                PanelError.Visible = True
                lblEstado.Text = "Ingresar un almacén correcto"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done almacén"
            End If

            If Not txtDirAlmacen.Text.Trim.Length > 0 Then
                PanelError.Visible = True
                lblEstado.Text = "Ingresar un dirreccion de almacén correcto"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done almacén"
            End If

            Select Case Tag
                Case "Todo"
                    datos.Clear()
                    n.idAlmacen = cboAlmacen.SelectedValue
                    n.fechaIncio = txtFechaInicioPlazo.Value
                    n.fechaFin = txtFechaFinPlazo.Value
                    n.fechaInicioGarantia = DateTime.Now
                    n.fechaFinGarantia = DateTime.Now
                    n.notas = Nothing
                    n.indicaciones = txtIndicaciones.Text
                    n.nombreAlmacen = cboAlmacen.Text
                    n.direccionAlmacen = txtDirAlmacen.Text
                    datos.Add(n)
                Case "PorItem"
                    datos.Clear()
                    n.idAlmacen = cboAlmacen.SelectedValue
                    n.fechaIncio = txtFechaInicioPlazo.Value
                    n.fechaFin = txtFechaFinPlazo.Value
                    n.fechaInicioGarantia = DateTime.Now
                    n.fechaFinGarantia = DateTime.Now
                    n.notas = Nothing
                    n.indicaciones = txtIndicaciones.Text
                    n.idItem = txtNombreItem.Tag
                    n.nombreItem = txtNombreItem.Text
                    n.cantidad = txtCantidad.Text
                    n.nombreAlmacen = cboAlmacen.Text
                    n.direccionAlmacen = txtDirAlmacen.Text
                    datos.Add(n)
            End Select

            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Arrow



        'Dim documentosa As New DocumentoCompraDetalleSA
        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    If Not cboAlmacen.Text.Trim.Length > 0 Then
        '        PanelError.Visible = True
        '        lblEstado.Text = "Ingresar un almacén correcto"
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    Else
        '        lblEstado.Text = "Done almacén"
        '        'lblEstado.Image = My.Resources.ok4
        '    End If

        '    If Not txtDirAlmacen.Text.Trim.Length > 0 Then
        '        PanelError.Visible = True
        '        lblEstado.Text = "Ingresar un dirreccion de almacén correcto"
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    Else
        '        lblEstado.Text = "Done almacén"
        '        'lblEstado.Image = My.Resources.ok4
        '    End If

        '    Select Case Tag
        '        Case "Todo"


        '            GrabarSolicitudFull()
        '            Dispose()

        '            'For Each item In dgvOrdenCompra.Table.Records
        '            '    item.SetValue("estado", True)
        '            '    item.SetValue("descripcionEstado", "LISTO")
        '            '    documentosa.UpdateFullDocOrden(item.GetValue("secuencia"), TIPO_COMPRA.ORDEN_APROBADO)
        '            'Next

        '        Case "PorItem"
        '            'If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then
        '            '    'Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
        '            '    Dim sumatoria As Integer = 0
        '            '    Me.lblEstado.Text = "Done!"
        '            '    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
        '            GrabarSolicitud(secuencias, item)
        '            Dispose()
        '            '        UbicarDetalleDeEntrega()
        '            '        'sumatoria = txtCantidad.Text
        '            '        LimpiarCajas()
        '            '        pnDetallesOC.Enabled = False
        '            '        rbTodo.Checked = False
        '            '        RbPorExistencia.Checked = False

        '            '        For Each r In dgvHistorialDetalle.Table.Records
        '            '            sumatoria += r.GetValue("cantidad")
        '            '        Next

        '            '        If (Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("monto1") = sumatoria) Then
        '            '            Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("estado", True)
        '            '            Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("descripcionEstado", "LISTO")
        '            '            documentosa.UpdateFullDocOrden(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("secuencia"), TIPO_COMPRA.ORDEN_APROBADO)
        '            '        End If

        '            '    ElseIf (ManipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
        '            '        UpdateSolicitud()
        '            '        UbicarDetalleDeEntrega()
        '            '        LimpiarCajas()
        '            '        pnDetallesOC.Enabled = False
        '            '        rbTodo.Checked = False
        '            '        RbPorExistencia.Checked = False
        '            '    End If
        '            'Else
        '            '    PanelError.Visible = True
        '            '    Me.lblEstado.Text = "Ingrese incorrecto de los datos"
        '            '    Timer1.Enabled = True
        '            '    TiempoEjecutar(10)
        '            'End If
        '    End Select
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        'End Try
        'Me.Cursor = Cursors.Arrow
    End Sub
End Class