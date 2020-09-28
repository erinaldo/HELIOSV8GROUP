Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMantenimientoVentaDirecta
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = PeriodoGeneral ' String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        ListaVentas(PeriodoGeneral)
    End Sub

#Region "Métodos"

    Public Sub EliminarVenta(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(IntIdDocumento)
            If Not IsNothing(i.idAlmacenOrigen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvListaPedidos.SelectedItems(0).SubItems(3).Text

                        objNuevo.importeSoles = i.salidaCostoMN * -1
                        objNuevo.importeDolares = i.salidaCostoME * -1
                        'Select Case lsvListaPedidos.SelectedItems(0).SubItems(3).Text
                        '    Case "03", "02"
                        '        objNuevo.importeSoles = i.importeMN * -1
                        '        objNuevo.importeDolares = i.importeME * -1
                        '    Case Else
                        '        Select Case i.destino
                        '            Case "1"
                        '                objNuevo.importeSoles = i.montokardex * -1
                        '                objNuevo.importeDolares = i.montokardexUS * -1
                        '            Case Else
                        '                objNuevo.importeSoles = i.importeMN * -1
                        '                objNuevo.importeDolares = i.importeME * -1
                        '        End Select
                        'End Select

                        objNuevo.cantidad = i.monto1 * -1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc * -1
                        objNuevo.montoIscUS = i.montoIscUS * -1

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteVentaTicket(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarVentaCobrada(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .tipoDoc = TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
        End With
        For Each i In documentoDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(IntIdDocumento)
            If Not IsNothing(i.idAlmacenOrigen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvListaPedidos.SelectedItems(0).SubItems(3).Text

                        objNuevo.importeSoles = i.salidaCostoMN * -1
                        objNuevo.importeDolares = i.salidaCostoME * -1
                        'Select Case lsvListaPedidos.SelectedItems(0).SubItems(3).Text
                        '    Case "03", "02"
                        '        objNuevo.importeSoles = i.importeMN * -1
                        '        objNuevo.importeDolares = i.importeME * -1
                        '    Case Else
                        '        Select Case i.destino
                        '            Case "1"
                        '                objNuevo.importeSoles = i.montokardex * -1
                        '                objNuevo.importeDolares = i.montokardexUS * -1
                        '            Case Else
                        '                objNuevo.importeSoles = i.importeMN * -1
                        '                objNuevo.importeDolares = i.importeME * -1
                        '        End Select
                        'End Select

                        objNuevo.cantidad = i.monto1 * -1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc * -1
                        objNuevo.montoIscUS = i.montoIscUS * -1

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteVentaTicketCobrado(objDocumento, ListaTotales)
    End Sub

    Public Sub ListaVentas(strPeriodo As String)
        Dim documentoventaSA As New documentoVentaAbarrotesSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            lsvListaPedidos.Columns.Clear()
            lsvListaPedidos.Items.Clear()
            lsvListaPedidos.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvListaPedidos.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvListaPedidos.Columns.Add("Fecha emisión/pago", 90, HorizontalAlignment.Left) '2
            lsvListaPedidos.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvListaPedidos.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvListaPedidos.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvListaPedidos.Columns.Add("T/D/P", 0, HorizontalAlignment.Left) '6
            lsvListaPedidos.Columns.Add("N° Documento", 0, HorizontalAlignment.Center) '7
            lsvListaPedidos.Columns.Add("Cliente", 237, HorizontalAlignment.Left) '8
            lsvListaPedidos.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvListaPedidos.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvListaPedidos.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvListaPedidos.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvListaPedidos.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvListaPedidos.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvListaPedidos.Columns.Add("Docs/Sust.", 50, HorizontalAlignment.Center) '15

            Select Case ModuloAppx

                Case ModuloSistema.PLANEAMIENTO
                    For Each i As documentoventaAbarrotes In documentoventaSA.GetListarVentasPorPeriodo(GProyectos.IdProyectoActividad, strPeriodo, TIPO_VENTA.VENTA_AL_TICKET_DIRECTA)

                        Dim n As New ListViewItem(i.idDocumento)
                        n.UseItemStyleForSubItems = False
                        With n.SubItems.Add(i.tipoOperacion)
                            If i.estadoCobro = TIPO_VENTA.VENTA_ANULADA Then
                                .BackColor = Color.Red
                            Else
                                .BackColor = Color.LavenderBlush
                            End If
                        End With
                        '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                        n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.ShortDate))
                        n.SubItems.Add(i.tipoDocumento)
                        n.SubItems.Add(i.serie)
                        n.SubItems.Add(String.Format("{0:00000}", Convert.ToInt32(i.numeroDoc)))
                        n.SubItems.Add(i.tipoDocEntidad)
                        n.SubItems.Add(i.NroDocEntidad)
                        n.SubItems.Add(i.nombrePedido)
                        n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                        n.SubItems.Add(FormatNumber(i.ImporteNacional, 2))
                        n.SubItems.Add(FormatNumber(i.tipoCambio, 2))
                        n.SubItems.Add(FormatNumber(i.ImporteExtranjero, 2))
                        n.SubItems.Add(i.moneda)
                        n.SubItems.Add(i.tipoVenta)
                        With n.SubItems.Add(i.estadoCobro)
                            .BackColor = Color.Yellow
                            .ForeColor = Color.Red
                        End With
                        '    n.Group = g
                        lsvListaPedidos.Items.Add(n)
                    Next
                Case Else
                    For Each i As documentoventaAbarrotes In documentoventaSA.GetListarVentasPorPeriodo_CONT(strPeriodo, TIPO_VENTA.VENTA_AL_TICKET_DIRECTA)

                        Dim n As New ListViewItem(i.idDocumento)
                        n.UseItemStyleForSubItems = False
                        With n.SubItems.Add(i.tipoOperacion)
                            If i.estadoCobro = TIPO_VENTA.VENTA_ANULADA Then
                                .BackColor = Color.Red
                            Else
                                .BackColor = Color.LavenderBlush
                            End If
                        End With
                        '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                        n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.ShortDate))
                        n.SubItems.Add(i.tipoDocumento)
                        n.SubItems.Add(i.serie)
                        n.SubItems.Add(String.Format("{0:00000}", Convert.ToInt32(i.numeroDoc)))
                        n.SubItems.Add(i.tipoDocEntidad)
                        n.SubItems.Add(i.NroDocEntidad)
                        n.SubItems.Add(i.nombrePedido)
                        n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                        n.SubItems.Add(FormatNumber(i.ImporteNacional, 2))
                        n.SubItems.Add(FormatNumber(i.tipoCambio, 2))
                        n.SubItems.Add(FormatNumber(i.ImporteExtranjero, 2))
                        n.SubItems.Add(i.moneda)
                        n.SubItems.Add(i.tipoVenta)
                        With n.SubItems.Add(i.estadoCobro)
                            .BackColor = Color.Yellow
                            .ForeColor = Color.Red
                        End With
                        '    n.Group = g
                        lsvListaPedidos.Items.Add(n)
                    Next
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPerido.Text = "01" & "/2014"
            Case "FEBRERO"
                lblPerido.Text = "02" & "/2014"
            Case "MARZO"
                lblPerido.Text = "03" & "/2014"
            Case "ABRIL"
                lblPerido.Text = "04" & "/2014"
            Case "MAYO"
                lblPerido.Text = "05" & "/2014"
            Case "JUNIO"
                lblPerido.Text = "06" & "/2014"
            Case "JULIO"
                lblPerido.Text = "07" & "/2014"
            Case "AGOSTO"
                lblPerido.Text = "08" & "/2014"
            Case "SETIEMBRE"
                lblPerido.Text = "09" & "/2014"
            Case "OCTUBRE"
                lblPerido.Text = "10" & "/2014"
            Case "NOVIEMBRE"
                lblPerido.Text = "11" & "/2014"
            Case "DICIEMBRE"
                lblPerido.Text = "12" & "/2014"
        End Select
        ListaVentas(lblPerido.Text)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        'Me.Cursor = Cursors.WaitCursor
        'GConfiguracion = New GConfiguracionModulo
        'With frmVentaDirecta
        '    .QRibbonApplicationButton2.Visible = True
        '    .Width = 925
        '    .Height = 521
        '    '.ObtenerNmeracionAnclada("03")
        '    '.ObtenerEFPredeterminada()
        '    Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
        '    .txtFechaComprobante.Text = New Date(cfecha.Year, cfecha.Month, cfecha.Day)
        '    .lblPeriodo.Text = lblPerido.Text
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
        '    .ShowDialog()
        'End With
        'Me.Cursor = Cursors.Arrow
        Me.Cursor = Cursors.WaitCursor
        With frmVentaTicketDirecta
            .btGrabar.Enabled = True
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'If .TieneCuentaFinanciera = True Then
            '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '    .lblPerido.Text = lblPerido.Text
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'Else
            '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
            'End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        With frmVentaTicketDirecta
            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE

            If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA Then
                .btGrabar.Enabled = False
                lblEstado.Text = "El documento está anulado!!"
                lblEstado.Image = My.Resources.ok4
            Else
                'If .TieneCuentaFinanciera(CInt(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)) = True Then
                '    .btGrabar.Enabled = True
                '    .txtFechaComprobante.ShowUpDown = True
                '    .UbicarDocumento(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'Else
                '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                'End If
            End If
        End With

        'If lsvListaPedidos.SelectedItems.Count > 0 Then
        '    With frmVentaDirecta
        '        If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA Then
        '            .QRibbonApplicationButton2.Visible = False
        '            lblEstado.Text = "El documento está anulado!!"
        '            lblEstado.Image = My.Resources.ok4
        '        Else
        '            .QRibbonApplicationButton2.Visible = True
        '            .Width = 925
        '            .Height = 521
        '            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '            .UbicarDocumento(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)
        '            .StartPosition = FormStartPosition.CenterParent
        '            .ShowDialog()
        '        End If
        '    End With
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvListaPedidos.SelectedItems.Count > 0 Then
            If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA Then
                lblEstado.Image = My.Resources.ok4
                lblEstado.Text = "El documento ya está anulado.!"

            Else
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = "DC" Then
                        EliminarVentaCobrada(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)
                    End If
                    lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "venta eliminada!"
                End If
            End If


        End If
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        '  frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub lblPerido_Click_1(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip1.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub frmMantenimientoVentaDirecta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMantenimientoVentaDirecta_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      
    End Sub
End Class