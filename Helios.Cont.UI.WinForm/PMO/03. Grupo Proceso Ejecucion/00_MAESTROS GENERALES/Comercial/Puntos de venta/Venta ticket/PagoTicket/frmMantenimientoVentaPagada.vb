Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMantenimientoVentaPagada
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = PeriodoGeneral
        ListaVentas(PeriodoGeneral)
        InitializeRAdial()
    End Sub

#Region "RAdial Menu"
    Private Sub setRadialMenuLocation()
        Dim locationX As Integer = 0
        Dim locationY As Integer = 0
        locationX = (Cursor.Position.X + Me.rmCompra.Width / 8)
        If locationX + Me.rmCompra.Width > Screen.PrimaryScreen.Bounds.Width Then
            locationX = Screen.PrimaryScreen.Bounds.Width - Me.rmCompra.Width
        End If
        locationY = Cursor.Position.Y - Me.rmCompra.Height / 2
        If locationY + Me.rmCompra.Height > Screen.PrimaryScreen.Bounds.Height Then
            locationY = Screen.PrimaryScreen.Bounds.Height - Me.rmCompra.Height
        End If
        Dim location As New Point(locationX, locationY)
        Me.rmCompra.ShowRadialMenu(location)
        Me.rmCompra.PopupHost.Location = location
        If Me.rmCompra.PopupHost.Location.Y < 0 Then
            Me.rmCompra.PopupHost.Location = New Point(Me.rmCompra.PopupHost.Location.X, 0)
        End If
    End Sub

    Sub InitializeRAdial()
        rmCompra.Icon = My.Resources.configuration_13194
        rmCompra.MenuIcon = My.Resources.configuration_13194

        Me.rmCompra.ParentControl = lsvListaPedidos
        Me.rmCompra.MenuVisibility = True
        Me.rmCompra.OuterRimThickness = 20
        '  Me.MinimumSize = Me.Size
        Me.rmCompra.DisplayStyle = Syncfusion.Windows.Forms.Tools.DisplayStyle.TextAboveImage

        Dim myImageNuevoCompra As System.Drawing.Image = My.Resources.icono_new_documento
        ImageList1.Images.Add(myImageNuevoCompra) '0

        Dim myImageEditCompra As System.Drawing.Image = My.Resources.icono_editar_compra
        ImageList1.Images.Add(myImageEditCompra) '01

        Dim myImageElminarDoc As System.Drawing.Image = My.Resources.icono_eliminar_compra
        ImageList1.Images.Add(myImageElminarDoc) '02

        Dim myImageNotasDoc As System.Drawing.Image = My.Resources.icono_Sel_nota
        ImageList1.Images.Add(myImageNotasDoc) '03

        Dim myImageTributo As System.Drawing.Image = My.Resources.icono_tributo
        ImageList1.Images.Add(myImageTributo) '04

        Dim myImageGuia As System.Drawing.Image = My.Resources.icono_guia2
        ImageList1.Images.Add(myImageGuia) '05

        Dim myImageCompraAlCredito As System.Drawing.Image = My.Resources.icono_compra_credito
        ImageList1.Images.Add(myImageCompraAlCredito) '06

        Dim myImageCompraAlContado As System.Drawing.Image = My.Resources.icono_compra_contado
        ImageList1.Images.Add(myImageCompraAlContado) '07

        'Dim myImageNotacredito As System.Drawing.Image = My.Resources.icono_tributo3
        'ImageList1.Images.Add(myImageNotacredito) '08



        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(50, 50)


        rmCompra.ImageList = ImageList1
        rmNuevaCompra.ImageIndex = 0
        rmEditarCompra.ImageIndex = 1
        rmEliminarDoc.ImageIndex = 2
        rmNotas.ImageIndex = 3
        rmTributos.ImageIndex = 4
        rmRemision.ImageIndex = 5
        'rmiCompraAlcredito.ImageIndex = 6
        'rmiCompraAlContado.ImageIndex = 7

        Me.rmCompra.RimBackground = Color.FromArgb(177, 245, 247) '("#FFFFD2")
        '   Me.rmCompra.OuterArcColor = Color.FromArgb(229, 229, 236) '("#FFFFD2")
    End Sub
#End Region


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
            .tipoDoc = TIPO_VENTA.VENTA_AL_TICKET
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
                    For Each i As documentoventaAbarrotes In documentoventaSA.GetListarVentasPorPeriodo(GProyectos.IdProyectoActividad, strPeriodo, TIPO_VENTA.VENTA_AL_TICKET)

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
                    For Each i As documentoventaAbarrotes In documentoventaSA.GetListarVentasPorPeriodo_CONT(strPeriodo, TIPO_VENTA.VENTA_AL_TICKET)

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

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        'With frmVentaTicketCredito
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .lblPerido.Text = lblPerido.Text
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        'With frmVentasAlCredito
        '    .QRibbonApplicationButton2.Visible = True
        '    .Width = 925
        '    .Height = 521
        '    '   .ObtenerNmeracionAnclada("03")
        '    Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
        '    .txtFechaComprobante.Text = New Date(cfecha.Year, cfecha.Month, cfecha.Day)
        '    .lblPeriodo.Text = lblPerido.Text
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
        '    .ShowDialog()
        'End With
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

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvListaPedidos.SelectedItems.Count > 0 Then
            If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA Then
                lblEstado.Image = My.Resources.ok4
                lblEstado.Text = "El documento ya está anulado.!"
            Else
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = "PN" Then
                        EliminarVenta(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)
                    ElseIf lsvListaPedidos.SelectedItems(0).SubItems(15).Text = "DC" Then
                        EliminarVentaCobrada(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)
                    End If
                    lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "venta eliminada!"
                End If

            End If


        End If
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor

        If lsvListaPedidos.SelectedItems.Count > 0 Then
            'With frmVentaTicketCredito
            '    .txtComprobante = Nothing
            '    .txtIdComprobante = Nothing
            '    .NumeroComprobante = Nothing
            '    .txtSerie = Nothing
            '    If lsvListaPedidos.SelectedItems(0).SubItems(15).Text = "PN" Then
            '        .GuardarToolStripButton.Visible = True
            '    ElseIf lsvListaPedidos.SelectedItems(0).SubItems(15).Text = "DC" Then
            '        .GuardarToolStripButton.Visible = False
            '    ElseIf lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA Then
            '        .GuardarToolStripButton.Visible = False
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            '    .txtFechaComprobante.ShowUpDown = True
            '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            '    .UbicarDocumento(lsvListaPedidos.SelectedItems(0).SubItems(0).Text)
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        '   frmPMO.Panel3.Width = 249
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

    Private Sub rmCompra_BeforeCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles rmCompra.BeforeCloseUp
        If Me.rmCompra.MenuVisibility Then
            Me.rmCompra.MenuVisibility = False
            Me.rmCompra.ItemOnLoad = Nothing
            Me.rmCompra.Refresh()
        End If
    End Sub

    Private Sub rmCompra_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles rmCompra.Paint

    End Sub

    Private Sub lsvListaPedidos_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListaPedidos.MouseClick

    End Sub

    Private Sub lsvListaPedidos_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListaPedidos.MouseDown
        Me.rmCompra.Hide()
        Me.rmCompra.HidePopup()
        Me.rmCompra.ItemOnLoad = Nothing
        rmCompra.ResetInnerCircleRadius()
        Me.rmCompra.MenuVisibility = False
        Me.rmCompra.Refresh()
    End Sub

    Private Sub lsvListaPedidos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvListaPedidos.SelectedIndexChanged

    End Sub

    Private Sub frmMantenimientoVentaPagada_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub frmMantenimientoVentaPagada_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class