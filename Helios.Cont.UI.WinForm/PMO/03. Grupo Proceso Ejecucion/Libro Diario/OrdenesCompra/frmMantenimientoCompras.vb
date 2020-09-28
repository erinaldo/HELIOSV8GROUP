Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMantenimientoCompras


    'VARIABLES DE PAGINADO
    Public currentPage As Integer = 0
    Public currentSize As Integer = 10
    Public xConteo As Integer = 0
    Public xxConteo As Integer = 0
    Public numero As String
    Public numero2 As String
    Dim conteoPaginado As Integer


#Region "Métodos"

    Public Sub RemoveCompra(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        With objDocumento
            .idDocumento = IntIdDocumento
        End With

        documentoSA.DeleteDocumento(objDocumento, Nothing)

    End Sub

    Public Sub ListaOrdenes(strPeriodo As String)
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
            lsvProduccion.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvProduccion.Columns.Add("Docs/Sust.", 50, HorizontalAlignment.Center) '15

            For Each i As documentocompra In documentoCompraSA.GetListarComprasPorPeriodo(GProyectos.IdProyectoActividad, strPeriodo, TIPO_COMPRA.ORDEN_COMPRA)
                'If i.NombreEntidad <> grupoActual Then
                '    g = New ListViewGroup(i.NombreEntidad)

                '    grupoActual = i.NombreEntidad
                '    lsvProduccion.Groups.Add(g)

                'End If

                Dim n As New ListViewItem(i.idDocumento)
                n.SubItems.Add(i.tipoOperacion)
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
                ' n.SubItems.Add(i.DocumentoSustentado)
                '    n.Group = g
                lsvProduccion.Items.Add(n)

                '               lsvProduccion.Groups.Add(New ListViewGroup(i.tipoCompra, _
                'HorizontalAlignment.Left))

                '               lsvProduccion.Items.Item(0).Group = lsvProduccion.Groups(0)
            Next

            '   lblConteo.Text = "Nro. Registros. " & lsvProduccion.Items.Count
            ' colorearColumnas_Distribucion(lsvProduccion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub frmMantenimientoCompras_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMantenimientoCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListaOrdenes(lblPerido.Text)

    End Sub

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor

        'Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        'datos.Clear()
        'With frmModalPeriodos
        '    .ObtenerAniosPorEmpresa(CEmpresa)
        '    .StartPosition = FormStartPosition.WindowsDefaultLocation
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        lblPeriodo.Text = datos(0).NombreCampo
        '        lblPeriodo.Text = datos(0).NombreCampo
        '        cAnioPeriodo = datos(0).NombreCampo
        '        Select Case lblCodigo.Text
        '            Case TipoCompra.EXISTENCIAS
        '                Conteos()
        '                UbicarCompra_cc(currentPage, currentSize)
        '            Case TipoCompra.SERVICIOS
        '                ConteosSC()
        '                UbicarCompra_sc(currentPage, currentSize)
        '        End Select

        '    Else
        '        '   MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '        '   btnAgregarProv_Click(sender, e)
        '    End If
        'End With
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If lblCodigo.Text = TipoCompra.EXISTENCIAS Then
        '    With frmMenuCompraExistencia
        '        .Tag = "CICC"
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '        Conteos()
        '        UbicarCompra_cc(currentPage, currentSize)
        '    End With
        'ElseIf lblCodigo.Text = TipoCompra.SERVICIOS Then
        '    With frmCompraGastos ' FrmRegistroCompra
        '        .ManipulacionEstado = Manipulacion.Nuevo
        '        .lblPeriodo.Text = lblPeriodo.Text
        '        .txtFechaComprobante.Value = String.Concat(Date.Now.Day, "/", cAnioPeriodo)
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '        UbicarCompra_sc(currentPage, currentSize)
        '    End With
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If lsvProduccion.SelectedItems.Count > 0 Then
        '    Select Case lsvProduccion.SelectedItems(0).SubItems(1).Text
        '        Case "CDI" 'TipoCompra_.conControlSinPago
        '            UbicarDocumento_(Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text))
        '            Conteos()
        '            UbicarCompra_cc(currentPage, currentSize)
        '        Case "CI"
        '            UbicarDocumento_NRML(Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text))
        '            Conteos()
        '            UbicarCompra_cc(currentPage, currentSize)
        '        Case "CIS" ' TipoCompra_.sinControlSinPago
        '            UbicarCompraSinControl_gastos(Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text))
        '            ConteosSC()
        '            UbicarCompra_sc(currentPage, currentSize)
        '        Case "CDIS"
        '            UbicarCompraSinControl_gastosDirectos(Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text))
        '            ConteosSC()
        '            UbicarCompra_sc(currentPage, currentSize)
        '    End Select

        'Else
        '    MsgBox("Seleccione un registro válido.", MsgBoxStyle.Information, "Atención!")
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If lsvProduccion.SelectedItems.Count > 0 Then
        '    Dim result = MsgBox("Está seguro de eliminar el registro?.", MsgBoxStyle.YesNo, "Aviso del Sistema")
        '    If result = MsgBoxResult.Yes Then

        '        Select Case lsvProduccion.SelectedItems(0).SubItems(1).Text
        '            Case "CI"
        '                RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CIC")
        '                Conteos()
        '                UbicarCompra_cc(currentPage, currentSize)
        '            Case "CDI"
        '                RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CDI")
        '                Conteos()
        '                UbicarCompra_cc(currentPage, currentSize)

        '            Case "CIS"
        '                RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CIS")
        '                ConteosSC()
        '                UbicarCompra_sc(currentPage, currentSize)

        '            Case "CDIS"
        '                RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CISD")
        '                ConteosSC()
        '                UbicarCompra_sc(currentPage, currentSize)
        '        End Select

        '        'Select Case lsvProduccion.SelectedItems(0).SubItems(1).Text   ' lblCodigo.Text
        '        '    Case TipoCompra_.conControlSinPago
        '        '        RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CIC")
        '        '        Conteos()
        '        '        UbicarCompra_cc(currentPage, currentSize)
        '        '    Case TipoCompra_.sinControlSinPago
        '        '        RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CIS")
        '        '        ConteosSC()
        '        '        UbicarCompra_sc(currentPage, currentSize)
        '        '    Case TipoCompra_.conControlConPago
        '        '        RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CDI")
        '        '        Conteos()
        '        '        UbicarCompra_cc(currentPage, currentSize)
        '        '    Case TipoCompra_.sinControlConPago
        '        '        RemoveCompra(CEmpresa, Convert.ToString(lsvProduccion.SelectedItems(0).SubItems(0).Text), "CISD")
        '        '        ConteosSC()
        '        '        UbicarCompra_sc(currentPage, currentSize)
        '        'End Select

        '    End If
        'Else
        '    MsgBox("Seleccione un registro válido.", MsgBoxStyle.Information, "Atención!")
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim miServicio = HeliosSEProxy.CrearProxyHELIOS()
        'Dim objTicket As List(Of HeliosService.rptCompraccBO)
        'objTicket = miServicio.rptGetComprascc(CEmpresa, MDIPrincipal.cboEstablecimiento.SelectedValue, lblPeriodo.Text).ToList

        'Dim form = New rptComprascc
        'With form
        '    '.reportName = "HeliosUI.Example.rdlc"
        '    .reportName = "HeliosUI.RegistroCompra.rdlc"
        '    .reportData = objTicket
        '    '     .subreportData = miLista2
        '    .hasSubReport = True
        '    '.nombreMainDS = "ExampleRPTds"
        '    .nombreMainDS = "ExampleRPTDS"
        '    .Show()
        'End With
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        'If (lsvProduccion.Items.Count > 0) Then

        '    If (lblDescripcion.Text = "LISTADO COMPRAS EXISTENCIAS") Then
        '        currentPage = (conteoPaginado - conteoPaginado)
        '        UbicarCompra_cc(currentPage, currentSize)
        '    Else
        '        currentPage = (conteoPaginado - conteoPaginado)
        '        UbicarCompra_sc(currentPage, currentSize)
        '    End If
        'Else
        '    MessageBox.Show("No existe datos")
        'End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        'If (lsvProduccion.Items.Count > 0) Then
        '    If (txtIndice.Text > 1) Then

        '        If (lblDescripcion.Text = "LISTADO COMPRAS EXISTENCIAS") Then
        '            currentPage = (currentPage - 1)
        '            UbicarCompra_cc(currentPage, currentSize)
        '        Else
        '            currentPage = (currentPage - 1)
        '            UbicarCompra_sc(currentPage, currentSize)
        '        End If

        '    End If
        'Else
        '    MessageBox.Show("No existe datos")
        'End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs)
        'If (lsvProduccion.Items.Count > 0) Then

        '    If (lblDescripcion.Text = "LISTADO COMPRAS EXISTENCIAS") Then
        '        currentPage = If(((currentPage + 1) * currentSize) < xConteo, (currentPage + 1), currentPage)
        '        UbicarCompra_cc(currentPage, currentSize)
        '    Else
        '        currentPage = If(((currentPage + 1) * currentSize) < xConteo, (currentPage + 1), currentPage)
        '        UbicarCompra_sc(currentPage, currentSize)
        '    End If
        'Else
        '    MessageBox.Show("No existe datos")
        'End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs)
        'If (lsvProduccion.Items.Count > 0) Then

        '    If (lblDescripcion.Text = "LISTADO COMPRAS EXISTENCIAS") Then
        '        currentPage = conteoPaginado - 1
        '        UbicarCompra_cc(currentPage, currentSize)
        '    Else
        '        currentPage = conteoPaginado - 1
        '        UbicarCompra_sc(currentPage, currentSize)
        '    End If
        'Else
        '    MessageBox.Show("No existe datos")
        'End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        '   frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub NuevoToolStripButton_Click_1(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        With frmComprasExistencias
            .Width = 925
            .Height = 521
            Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
            .txtFechaComprobante.Text = New Date(cfecha.Year, cfecha.Month, cfecha.Day)
            .lblPeriodo.Text = lblPerido.Text
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub AbrirToolStripButton_Click_1(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvProduccion.SelectedItems.Count > 0 Then
            With frmComprasExistencias
                .Width = 925
                .Height = 521
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click_1(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvProduccion.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                RemoveCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                lsvProduccion.SelectedItems(0).Remove()
                lblEstado.Image = My.Resources.ok4
                lblEstado.Text = "orden de compra eliminada!"
            End If

        End If

    End Sub

    Private Sub lblPerido_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

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
        ListaOrdenes(lblPerido.Text)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub
End Class