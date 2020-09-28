Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmAportesGeneral
    Inherits frmMaster

    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub CierrePeriodoHabilitado()
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        'If Not IsNothing(cierre) Then
        '    Select Case cierre.estado
        '        Case "C"
        '            ToolStripEx1.Enabled = False

        '        Case "A"
        '            ToolStripEx1.Enabled = True
        '    End Select
        'Else
        '    ToolStripEx1.Enabled = True
        'End If
    End Sub

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
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
        CierrePeriodoHabilitado()
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
    Public Sub ListaAportesPorDia()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            lsvAportes.Columns.Clear()
            lsvAportes.Items.Clear()
            lsvAportes.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvAportes.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvAportes.Columns.Add("Fecha emisión/pago", 90, HorizontalAlignment.Left) '2
            lsvAportes.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvAportes.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvAportes.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvAportes.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            lsvAportes.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            lsvAportes.Columns.Add("Accionista", 237, HorizontalAlignment.Left) '8
            lsvAportes.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvAportes.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvAportes.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvAportes.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvAportes.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvAportes.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvAportes.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            lsvAportes.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16

            For Each i As documentocompra In documentoCompraSA.GetListarAportesPorDia(GEstableciento.IdEstablecimiento)

                Dim n As New ListViewItem(i.idDocumento)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightSteelBlue
                '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.ShortDate))
                n.SubItems.Add(i.tipoDoc)
                n.SubItems.Add(i.serie)
                n.SubItems.Add(i.numeroDoc)
                n.SubItems.Add(i.tipoDocEntidad)
                n.SubItems.Add(i.NroDocEntidad)
                n.SubItems.Add(i.NombreEntidad)
                n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                n.SubItems.Add(FormatNumber(i.importeTotal, 2))
                n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
                n.SubItems.Add(FormatNumber(i.importeUS, 2))
                n.SubItems.Add(i.monedaDoc)
                n.SubItems.Add(i.tipoCompra)
                n.SubItems.Add("")
                If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                    n.SubItems.Add("Pagado")
                ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
                    n.SubItems.Add("En trámite")
                End If
                lsvAportes.Items.Add(n)
            Next

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ListaAportesPorMes(ByVal strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            lsvAportes.Columns.Clear()
            lsvAportes.Items.Clear()
            lsvAportes.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvAportes.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvAportes.Columns.Add("Fecha emisión/pago", 90, HorizontalAlignment.Left) '2
            lsvAportes.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvAportes.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvAportes.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvAportes.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            lsvAportes.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            lsvAportes.Columns.Add("Accionista", 237, HorizontalAlignment.Left) '8
            lsvAportes.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvAportes.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvAportes.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvAportes.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvAportes.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvAportes.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvAportes.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            lsvAportes.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16

            For Each i As documentocompra In documentoCompraSA.GetListarAportesPorMes(GEstableciento.IdEstablecimiento, strPeriodo)

                Dim n As New ListViewItem(i.idDocumento)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightSteelBlue
                '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.ShortDate))
                n.SubItems.Add(i.tipoDoc)
                n.SubItems.Add(i.serie)
                n.SubItems.Add(i.numeroDoc)
                n.SubItems.Add(i.tipoDocEntidad)
                n.SubItems.Add(i.NroDocEntidad)
                n.SubItems.Add(i.NombreEntidad)
                n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                n.SubItems.Add(FormatNumber(i.importeTotal, 2))
                n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
                n.SubItems.Add(FormatNumber(i.importeUS, 2))
                n.SubItems.Add(i.monedaDoc)
                n.SubItems.Add(i.tipoCompra)
                n.SubItems.Add("")
                If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                    n.SubItems.Add("Pagado")
                ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
                    n.SubItems.Add("En trámite")
                End If
                lsvAportes.Items.Add(n)
            Next

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub EliminarAporte(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvAportes.SelectedItems(0).SubItems(3).Text

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If




            End If

        Next
        documentoSA.DeleteAporte(objDocumento, ListaTotales)
    End Sub
#End Region

    Private Sub frmAportesGeneral_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CompraDirectaConRecepciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompraDirectaConRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        GConfiguracion = New GConfiguracionModulo
        With frmAportesExistencia
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEditCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvAportes.SelectedItems.Count > 0 Then
            If lsvAportes.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.APORTE_EXISTENCIAS Then
                With frmAportesExistencia
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .txtFechaComprobante.ShowUpDown = True
                    .UbicarDocumento(lsvAportes.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCompra.Click
        If lsvAportes.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarAporte(lsvAportes.SelectedItems(0).SubItems(0).Text)
                lsvAportes.SelectedItems(0).Remove()
                lblEstado.Image = My.Resources.ok4
                lblEstado.Text = "Aporte eliminado!"
            End If
        End If
    End Sub

    Private Sub btnComprasPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles btnComprasPeriodo.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaAportesPorMes(PeriodoGeneral)
        lblEstado.Text = "Lista de aportes período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnComprasDia_Click(sender As Object, e As System.EventArgs) Handles btnComprasDia.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaAportesPorDia()
        lblEstado.Text = "Lista de aportes del día: " & DateTime.Now.Date
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripEx5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteAporteGeneral
            .ConsultaReporteTotalesPorPeriodo(lblPeriodo.Text)
            .lblPerido.Text = lblPeriodo.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteAporteGeneral
            .ConsultaReporteTotalesPorDia()
            .lblPerido.Text = lblPeriodo.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class