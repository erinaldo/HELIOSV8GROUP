Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMantenimientoOtrasEntradas
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        ListaEntradas(lblPerido.Text)
    End Sub

#Region "Métodos"

    '

    Public Sub EliminarTransferenciaAlmacen(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        Dim objDestino As New totalesAlmacen
        Dim ListaOrigen As New List(Of totalesAlmacen)
        Dim ListaDestino As New List(Of totalesAlmacen)

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
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaOrigen.Add(objNuevo)

                    End If

                    almacen = almacenSA.GetUbicar_almacenPorID(i.almacenDestino)
                    objDestino = New totalesAlmacen
                    objDestino.SecuenciaDetalle = i.secuencia
                    objDestino.idEmpresa = Gempresas.IdEmpresaRuc
                    objDestino.idEstablecimiento = almacen.idEstablecimiento
                    objDestino.idAlmacen = almacen.idAlmacen
                    objDestino.origenRecaudo = i.destino
                    objDestino.idItem = i.idItem
                    objDestino.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                    objDestino.importeSoles = i.importe
                    objDestino.importeDolares = i.importeUS

                    objDestino.cantidad = i.monto1
                    objDestino.precioUnitarioCompra = i.precioUnitario

                    objDestino.montoIsc = i.montoIsc
                    objDestino.montoIscUS = i.montoIscUS
                    ListaDestino.Add(objDestino)


                End If

            End If

        Next
        documentoSA.DeleteOtrasTransAlmacenOE(objDocumento, ListaOrigen, ListaDestino)
    End Sub

    Public Sub RemoveCompra(IntIdDocumento As Integer)
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
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

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
        documentoSA.DeleteOtrasEntradas(objDocumento, ListaTotales)
    End Sub

    Public Sub ListaEntradas(strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try
            lsvProduccion.Columns.Clear()
            lsvProduccion.Items.Clear()
            lsvProduccion.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvProduccion.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvProduccion.Columns.Add("Fecha emisión/pago", 90, HorizontalAlignment.Left) '2
            lsvProduccion.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvProduccion.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvProduccion.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvProduccion.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            lsvProduccion.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            lsvProduccion.Columns.Add("Proveedor", 237, HorizontalAlignment.Left) '8
            lsvProduccion.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvProduccion.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvProduccion.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvProduccion.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvProduccion.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvProduccion.Columns.Add("TIPO", 0, HorizontalAlignment.Center) '14
            lsvProduccion.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            lsvProduccion.Columns.Add("Movimiento", 220, HorizontalAlignment.Left) '16

            For Each i As documentocompra In documentoCompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA)

                Dim n As New ListViewItem(i.idDocumento)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow

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
                n.SubItems.Add(i.destino)
                n.SubItems.Add("")
                If i.destino = "TEA" Then
                    n.SubItems.Add("TRANSFERENCIA ENTRE ALMACENES").ForeColor = Color.SteelBlue
                ElseIf i.destino = "EEX" Then
                    n.SubItems.Add("OTRAS ENTRADAS A ALMACEN").ForeColor = Color.SteelBlue
                End If
                lsvProduccion.Items.Add(n)

            Next

        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        ''''''frmPMO.Panel3.Width = 249
        'Dispose()
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
        ListaEntradas(lblPerido.Text)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        With frmOtrasEntradasAlmacen
            .Width = 925
            .Height = 521
            .TabCompra.Visible = False
            .Panel3.Visible = False
            Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
            .txtFechaComprobante.Text = New Date(cfecha.Year, cfecha.Month, cfecha.Day)
            .lblPeriodo.Text = lblPerido.Text
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvProduccion.SelectedItems.Count > 0 Then
            If lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                With frmOtrasEntradasAlmacen
                    .QRibbonApplicationButton1.Visible = False
                    .cboModulo.Visible = False
                    .Width = 925
                    .Height = 521
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                With frmOtrasEntradasAlmacen
                    .QRibbonApplicationButton1.Visible = True
                    .cboModulo.Visible = False
                    .Width = 925
                    .Height = 521
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvProduccion.SelectedItems.Count > 0 Then
            If lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTransferenciaAlmacen(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    lsvProduccion.SelectedItems(0).Remove()
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "entrada eliminada!"
                End If
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RemoveCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    lsvProduccion.SelectedItems(0).Remove()
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "entrada eliminada!"
                End If
            End If

        End If
    End Sub

    Private Sub frmMantenimientoOtrasEntradas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMantenimientoOtrasEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class