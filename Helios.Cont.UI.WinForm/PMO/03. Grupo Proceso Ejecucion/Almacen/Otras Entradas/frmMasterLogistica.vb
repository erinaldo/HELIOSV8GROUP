Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmMasterLogistica
    Inherits frmMaster
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel
    Dim filter As GridDynamicFilter = New GridDynamicFilter()


    Private Sub CierrePeriodoHabilitado()
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            'Select Case cierre.estado
            '    Case "C"
            '        ToolStripEx1.Enabled = False

            '    Case "A"
            '        ToolStripEx1.Enabled = True
            'End Select
        Else
            ToolStripEx1.Enabled = True
        End If
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
        '    Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ConfiguracionInicio()
        ' Add any initialization after the InitializeComponent() call.
        CierrePeriodoHabilitado()
    End Sub

#Region "Print"
    Private Sub pd_DrawGridPrintHeader(sender As Object, e As Syncfusion.GridHelperClasses.GridPrintHeaderFooterTemplateArgs)
        ' Get the rectangle area to draw
        Dim header As Rectangle = e.DrawRectangle

        'IMAGE
        'scale the image
        Dim imageSize As New SizeF(header.Width / 3, header.Height * 0.8F)
        'Locating the logo on the right corner of the Drawing Surface
        Dim imageLocation As New PointF(e.DrawRectangle.Width - imageSize.Width - 20, header.Y + 5)
        Dim img As New Bitmap("..\..\Data\logo.png")
        'Draw the image in the Header.
        e.Graphics.DrawImage(img, New RectangleF(imageLocation, imageSize))

        'TITLE
        Dim activeColor As Color = Color.FromArgb(44, 71, 120)
        Dim brush As New SolidBrush(activeColor)
        Dim font As New Font("Helvetica", 20, FontStyle.Bold)
        'Set formattings for the text
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Near
        format.LineAlignment = StringAlignment.Near
        'Draw the title
        e.Graphics.DrawString("Customers Order Report", font, brush, New RectangleF(header.Location.X + 20, header.Location.Y + 20, e.DrawRectangle.Width, e.DrawRectangle.Height), format)

        '  '''BORDER LINES - Draw some lines in the header
        Dim pen As New Pen(Color.DarkBlue, 0.8F)
        e.Graphics.DrawLine(pen, New Point(header.Left, header.Top + 2), New Point(header.Right, header.Top + 2))
        e.Graphics.DrawLine(pen, New Point(header.Left, header.Top + 5), New Point(header.Right, header.Top + 5))
        e.Graphics.DrawLine(pen, New Point(header.Left, header.Bottom - 8), New Point(header.Right, header.Bottom - 8))
        e.Graphics.DrawLine(pen, New Point(header.Left, header.Bottom - 5), New Point(header.Right, header.Bottom - 5))

        'Dispose drawing resources
        font.Dispose()
        format.Dispose()
        pen.Dispose()
    End Sub

    Private Sub pd_DrawGridPrintFooter(sender As Object, e As Syncfusion.GridHelperClasses.GridPrintHeaderFooterTemplateArgs)
        'Get the rectangle area to draw
        Dim footer As Rectangle = e.DrawRectangle

        'Draw copy right
        Dim format As New StringFormat()
        format.LineAlignment = StringAlignment.Center
        format.Alignment = StringAlignment.Center
        Dim font As New Font("Helvetica", 8)
        Dim brush As New SolidBrush(Color.Red)
        e.Graphics.DrawString("@copyright", font, brush, GridUtil.CenterPoint(footer), format)

        'Draw page number
        format.LineAlignment = StringAlignment.Far
        format.Alignment = StringAlignment.Far
        e.Graphics.DrawString(String.Format("page {0} of {1}", e.PageNumber, e.PageCount), font, brush, New Point(footer.Right - 100, footer.Bottom - 20), format)

        'Dispose resources
        format.Dispose()
        font.Dispose()
        brush.Dispose()
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
        'For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
        '    If Not IsNothing(i.almacenRef) Then
        '        almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
        '        If Not IsNothing(almacen) Then
        '            If Not almacen.tipo = "AV" Then
        '                objNuevo = New totalesAlmacen
        '                objNuevo.SecuenciaDetalle = i.secuencia
        '                objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
        '                objNuevo.idEstablecimiento = almacen.idEstablecimiento
        '                objNuevo.idAlmacen = almacen.idAlmacen
        '                objNuevo.origenRecaudo = i.destino
        '                objNuevo.idItem = i.idItem
        '                objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

        '                objNuevo.importeSoles = i.importe
        '                objNuevo.importeDolares = i.importeUS

        '                objNuevo.cantidad = i.monto1
        '                objNuevo.precioUnitarioCompra = i.precioUnitario

        '                objNuevo.montoIsc = i.montoIsc
        '                objNuevo.montoIscUS = i.montoIscUS

        '                ListaOrigen.Add(objNuevo)
        '            End If
        '            almacen = almacenSA.GetUbicar_almacenPorID(i.almacenDestino)
        '            objDestino = New totalesAlmacen
        '            objDestino.SecuenciaDetalle = i.secuencia
        '            objDestino.idEmpresa = Gempresas.IdEmpresaRuc
        '            objDestino.idEstablecimiento = almacen.idEstablecimiento
        '            objDestino.idAlmacen = almacen.idAlmacen
        '            objDestino.origenRecaudo = i.destino
        '            objDestino.idItem = i.idItem
        '            objDestino.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

        '            objDestino.importeSoles = i.importe
        '            objDestino.importeDolares = i.importeUS

        '            objDestino.cantidad = i.monto1
        '            objDestino.precioUnitarioCompra = i.precioUnitario

        '            objDestino.montoIsc = i.montoIsc
        '            objDestino.montoIscUS = i.montoIscUS
        '            ListaDestino.Add(objDestino)
        '        End If

        '    End If

        'Next
        documentoSA.DeleteOtrasTransAlmacenOESL(objDocumento)
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
                        objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

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

    Public Sub EliminarOtrasSalidas(IntIdDocumento As Integer)
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
                        objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

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
        documentoSA.DeleteOtrasSalidasDeAlmacen(objDocumento, ListaTotales)
    End Sub

    Private Function getParentTableComprasPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradas(intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.destino
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableComprasPorDia(intIdEstablecimiento As Integer) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - del día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarMvimientosAlmacenPorDia(intIdEstablecimiento, TIPO_COMPRA.OTRAS_ENTRADAS)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.destino
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Public Sub ListaEntradas(strPeriodo As String)
        Try

            Dim parentTable As DataTable = getParentTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, strPeriodo)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()

            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos período: - " & PeriodoGeneral
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaEntradasPorDia()
        Try

            Dim parentTable As DataTable = getParentTableComprasPorDia(GEstableciento.IdEstablecimiento)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()

            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos del día: - " & DateTime.Now.Date
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If Me.dgvCompra.Table.CurrentRecord.GetValue("destino") = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTransferenciaAlmacen(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    Me.dgvCompra.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    lblEstado.Text = "entrada eliminada!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("destino") = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RemoveCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    Me.dgvCompra.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    lblEstado.Text = "entrada eliminada!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("destino") = TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarOtrasSalidas(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    Me.dgvCompra.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    lblEstado.Text = "Registro eliminado!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            End If

        End If
    End Sub
    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If Me.dgvCompra.Table.CurrentRecord.GetValue("destino") = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                With frmMovimientoAlmacen
                    .ToolStripButton1.Enabled = False
                    .GuardarToolStripButton.Enabled = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                With frmMovOtrasEntradas
                    .GuardarToolStripButton.Enabled = True
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .WindowState = FormWindowState.Maximized
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraDirectaConRecepciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDirectaConRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovimientoAlmacen
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '.cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmMasterLogistica_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If filter IsNot Nothing Then
            filter.SaveCompareOperator()
        End If
        Dispose()
    End Sub

    Private Sub frmMasterLogistica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If



        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Ver asiento contable")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Ver asiento contable" Then
                If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                    With frmAsientoContable
                        .UbicarAsientoContableXidDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        ListaEntradas(PeriodoGeneral)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraDirectaSinRecepciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDirectaSinRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        ListaEntradasPorDia()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub chFilter1_Click(sender As Object, e As EventArgs) Handles chFilter1.Click
        If chFilter1.Checked = True Then
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
                dgvCompra.TableDescriptor.Columns(i).AllowFilter = True
            Next
        Else
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub chFilter2_Click(sender As Object, e As EventArgs) Handles chFilter2.Click
        If chFilter2.Checked Then
            filter.WireGrid(dgvCompra)
        Else
            filter.UnWireGrid(dgvCompra)
        End If
    End Sub

    Private Sub chAgrupa_Click(sender As Object, e As EventArgs) Handles chAgrupa.Click
        If chAgrupa.Checked Then
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = True
        Else
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = False
        End If
    End Sub

    Private Sub RegistroComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroComprasToolStripMenuItem.Click
        Try
            Me.dgvCompra.TableModel.Properties.PrintFrame = False

            Dim pd As New Syncfusion.GridHelperClasses.GridPrintDocumentAdv(Me.dgvCompra.TableControl)
            pd.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)

            'Set header and footer height
            'If Me.ShowHeaderFooter.Checked Then
            '    pd.HeaderHeight = 70
            '    pd.FooterHeight = 50
            'Else
            pd.HeaderHeight = 0
            pd.HeaderHeight = 0
            '    End If

            'Whether scale columns to fit
            pd.ScaleColumnsToFitPage = True ' Me.ScaleColumnsToFit.Checked

            'Handle the events to draw the header / footer
            'pd.DrawGridPrintHeader += New Syncfusion.GridHelperClasses.GridPrintDocumentAdv.DrawGridHeaderFooterEventHandler(AddressOf pd_DrawGridPrintHeader)
            'pd.DrawGridPrintFooter += New Syncfusion.GridHelperClasses.GridPrintDocumentAdv.DrawGridHeaderFooterEventHandler(AddressOf pd_DrawGridPrintFooter)
            AddHandler pd.DrawGridPrintHeader, AddressOf pd_DrawGridPrintHeader
            AddHandler pd.DrawGridPrintFooter, AddressOf pd_DrawGridPrintFooter
            Dim previewDialog As New PrintPreviewDialog()
            previewDialog.Document = pd
            previewDialog.Show()
        Catch ex As Exception
            MessageBox.Show("Error while print preview" + ex.ToString())
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovAlmacenPorPeriodo
            .ConsultaReporteTotalesPorPeriodo(lblPeriodo.Text)
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovAlmacenPorPeriodo
            .ConsultaReporteTotalesPorDia(TIPO_COMPRA.OTRAS_ENTRADAS)
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtrasSalidasDeAlmacénToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrasSalidasDeAlmacénToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            '    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class