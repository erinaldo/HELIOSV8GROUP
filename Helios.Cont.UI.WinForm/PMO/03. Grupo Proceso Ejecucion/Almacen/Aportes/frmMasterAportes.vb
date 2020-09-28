Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMasterAportes
    Inherits frmMaster

#Region "Docking"
    'Sub LoadBusquedaDoc()
    '    frmTabbBusqueda.MdiParent = Me
    '    frmTabbBusqueda.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft
    '    'SideForm1.TabText = "Side1"     'Title of the docked form.
    '    frmTabbBusqueda.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft    'Dock state when first opened.
    '    frmTabbBusqueda.Show(DockPanel1)
    '    ''Same for SideForm2:
    '    'frmTabbBusqueda.MdiParent = Me
    '    'frmTabbBusqueda.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft
    '    'frmTabbBusqueda.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft    'Dock state when first opened.
    '    'frmTabbBusqueda.Show(DockPanel1)
    '    '
    '    frmTabbBusqueda.Activate()        'Activate/Focus "SideForm1.
    ' End Sub
#End Region


#Region "Métodos"

    Public Sub ListaAportesPorRango(desde As Date, hasta As Date)
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

            For Each i As documentocompra In documentoCompraSA.GetListarAportesPorRango(desde, hasta)

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

    Public Sub ListaAportes(strPeriodo As String)
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

            For Each i As documentocompra In documentoCompraSA.GetListarAportesPorPeriodo(strPeriodo)

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
#End Region

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = PeriodoGeneral
        ListaAportesPorMes(PeriodoGeneral)
    End Sub

    Private Sub frmMasterAportes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


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
        If CheckBox1.Checked = True Then
            ListaAportes(lblPerido.Text)
            CheckBox1.Checked = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        ElseIf CheckBox2.Checked = True Then
            ListaAportesPorMes(PeriodoGeneral)
            CheckBox1.Checked = False
            CheckBox2.Checked = True
            CheckBox3.Checked = False
        ElseIf CheckBox3.Checked = True Then
            ListaAportesPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = True
        End If
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub lblPerido_Click_1(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp1(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
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

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If lsvAportes.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarAporte(lsvAportes.SelectedItems(0).SubItems(0).Text)
                lsvAportes.SelectedItems(0).Remove()
                lblEstado.Image = My.Resources.ok4
                lblEstado.Text = "Aporte eliminado!"
            End If
        End If
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            ListaAportes(lblPerido.Text)
            CheckBox1.Checked = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False
            lbldesde.Visible = False
            lblhasta.Visible = False

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            ListaAportesPorMes(PeriodoGeneral)
            CheckBox1.Checked = False
            CheckBox2.Checked = True
            CheckBox3.Checked = False

            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False
            lbldesde.Visible = False
            lblhasta.Visible = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            ListaAportesPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = True
            DateTimePicker1.Visible = True
            DateTimePicker2.Visible = True
            lbldesde.Visible = True
            lblhasta.Visible = True
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If CheckBox3.Checked = True Then
            ListaAportesPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If CheckBox3.Checked = True Then
            ListaAportesPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
        End If
    End Sub

    Private Sub ToolStripSplitButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripSplitButton1.Click
        Me.Cursor = Cursors.WaitCursor
        GConfiguracion = New GConfiguracionModulo
        With frmAportesExistencia
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmMasterAportes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class