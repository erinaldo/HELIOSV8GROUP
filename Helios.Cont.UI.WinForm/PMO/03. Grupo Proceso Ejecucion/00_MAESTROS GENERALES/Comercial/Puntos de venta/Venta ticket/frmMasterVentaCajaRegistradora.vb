Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmMasterVentaCajaRegistradora
    Inherits frmMaster
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub CierrePeriodoHabilitado()
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            'Select Case cierre.estado
            '    Case "C"
            '        ToolStripEx1.Enabled = False
            '        ToolStripEx4.Enabled = False
            '        ToolStripEx5.Enabled = False
            '    Case "A"
            '        ToolStripEx1.Enabled = True
            '        ToolStripEx4.Enabled = True
            '        ToolStripEx5.Enabled = True
            'End Select
        Else
            ToolStripEx1.Enabled = True
            ToolStripEx4.Enabled = True
            ToolStripEx5.Enabled = True
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
        '   Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        configDockingManger()
        CierrePeriodoHabilitado()
    End Sub

#Region "CONFIGURACION DOCKING CONTROL"
    Sub configDockingManger()
        Me.dockingManager1.DockControl(Me.PanelGuiaRemision, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 100)
        Me.dockingManager1.DockControl(Me.PanelNotas, Me.PanelGuiaRemision, Syncfusion.Windows.Forms.Tools.DockingStyle.Tabbed, 100)
        Me.dockingManager1.DockControl(Me.PanelTributo, Me.PanelGuiaRemision, Syncfusion.Windows.Forms.Tools.DockingStyle.Tabbed, 100)

        dockingManager1.SetDockLabel(PanelGuiaRemision, "Guía de remisión")
        dockingManager1.SetDockLabel(PanelNotas, "Notas interactivas")
        dockingManager1.SetDockLabel(PanelTributo, "Tributos")

        dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
        dockingManager1.SetDockVisibility(PanelNotas, False)
        dockingManager1.SetDockVisibility(PanelTributo, False)

        dockingManager1.CloseEnabled = False
    End Sub
#End Region

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

    Private Sub ObtenerListaGuias(intIDDOcumentoCompra As Integer)
        Dim documentoGuiaSA As New DocumentoGuiaSA
        Dim tablaSA As New tablaDetalleSA
        lsvGuia.Items.Clear()
        For Each i In documentoGuiaSA.ListaGuiasPorCompra(intIDDOcumentoCompra)
            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add(tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion)
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.numeroDoc)
            lsvGuia.Items.Add(n)
        Next
    End Sub

    Private Sub UbicarNotasPorIdPadre(intIdDocumentoPadre As Integer)
        Dim documentocompraSA As New documentoVentaAbarrotesSA
        Dim movimientostr As String = Nothing
        lsvNotas.Items.Clear()

        For Each i In documentocompraSA.GetListarNotasPorIdVentaPadre(intIdDocumentoPadre, TIPO_COMPRA.NOTA_CREDITO)

            'Select Case i.sustentado
            '    Case Notas_Credito.DEV_EXISTENCIA
            '        movimientostr = "DEVOLUCION DE EXISTENCIA"

            '    Case Notas_Credito.DR_REDUCCION_COSTOS
            '        movimientostr = "REDUCCION DE COSTOS"

            '    Case Notas_Credito.DR_BENEFICIO
            '        movimientostr = "BENEFICIO"

            '    Case Notas_Credito.ERR_PRECIO
            '        movimientostr = "ERROR EN PRECIO"

            '    Case Notas_Credito.ERR_CANTIDAD
            '        movimientostr = "ERROR EN CANTIDAD"

            '    Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
            '        movimientostr = "BONIF.: REDUCCION DE COSTO IGUAL AL COMPRADO"

            '    Case Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA
            '        movimientostr = "BONIF.: REDUCCION DE COSTO DISTINTO AL COMPRADO"

            '    Case Notas_Credito.BOF_BENEFICIO_TERCEROS
            '        movimientostr = "BONIF.: BENFICIO DE TERCEROS"
            'End Select
            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add("DEVOLUCION DE EXISTENCIA")
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.numeroDoc)
            n.SubItems.Add(i.ImporteNacional)
            n.SubItems.Add(i.ImporteExtranjero)
            lsvNotas.Items.Add(n)

        Next

        For Each i In documentocompraSA.GetListarNotasPorIdVentaPadre(intIdDocumentoPadre, TIPO_COMPRA.NOTA_DEBITO)
            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add("INCREMENTO DEL COSTO")
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.numeroDoc)
            n.SubItems.Add(i.ImporteNacional)
            n.SubItems.Add(i.ImporteExtranjero)
            lsvNotas.Items.Add(n)
        Next



        '  ggNotacRedito.TableDescriptor.Columns.Add("")
    End Sub

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
                        objNuevo.TipoDoc = Me.dgvVenta.Table.CurrentRecord.GetValue("tipoDocumento")

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

    Public Sub EliminarVentaCobrada(IntIdDocumento As Integer, varIdCajaUser As Integer, strTipoVenta As String)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = varIdCajaUser
            .tipoDoc = strTipoVenta ' TIPO_VENTA.VENTA_AL_TICKET
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
                        objNuevo.TipoDoc = Me.dgvVenta.Table.CurrentRecord.GetValue("tipoDocumento")

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
    '
    Private Function getParentTableVentasPorPeriodo() As DataTable
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas ticket - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("nombrePedido", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_VENTA.VENTA_AL_TICKET)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.nombrePedido
            dr(10) = i.ImporteNacional
            dr(11) = i.tipoCambio
            dr(12) = i.ImporteExtranjero
            dr(13) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(14) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(14) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(14) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(14) = "(VA) Anulado"
            End Select
            'Select Case i.estadoCobro
            '    Case "PN"
            '        dr(14) = "PEDIDO"
            '    Case Else
            '        dr(14) = "VENTA"
            'End Select
            dr(15) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Function getParentTableVentasPorDia() As DataTable
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas ticket - día " & DateTime.Now & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("nombrePedido", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorDiaEstablecimiento(GEstableciento.IdEstablecimiento, TIPO_VENTA.VENTA_AL_TICKET)
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.idDocumento
        '    dr(1) = i.tipoVenta
        '    dr(2) = str
        '    dr(3) = i.tipoDocumento
        '    dr(4) = i.serie
        '    dr(5) = i.numeroDoc
        '    dr(6) = i.tipoDocEntidad
        '    dr(7) = i.NroDocEntidad
        '    dr(8) = i.NombreEntidad
        '    dr(9) = i.nombrePedido
        '    dr(10) = i.ImporteNacional
        '    dr(11) = i.tipoCambio
        '    dr(12) = i.ImporteExtranjero
        '    dr(13) = i.moneda
        '    Select Case i.estadoCobro
        '        Case TIPO_VENTA.PAGO.COBRADO
        '            dr(14) = "Venta"
        '        Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
        '            dr(14) = "Pedido"
        '        Case TIPO_VENTA.VENTA_NOTA_CREDITO
        '            dr(14) = "(DA) nota crédito"
        '        Case TIPO_VENTA.VENTA_ANULADA
        '            dr(14) = "(VA) Anulado"
        '    End Select

        '    'Select Case i.estadoCobro
        '    '    Case "PN"
        '    '        dr(14) = "PEDIDO"
        '    '    Case Else
        '    '        dr(14) = "VENTA"
        '    'End Select
        '    dr(15) = i.usuarioActualizacion
        '    dt.Rows.Add(dr)
        'Next
        Return dt

    End Function

    Public Sub ListaVentas()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTableVentasPorPeriodo()
            Me.dgvVenta.DataSource = parentTable
            dgvVenta.TableDescriptor.Relations.Clear()
            dgvVenta.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvVenta.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvVenta.Appearance.AnyRecordFieldCell.Enabled = False
            dgvVenta.GroupDropPanel.Visible = True
            dgvVenta.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaVentasDelDia()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTableVentasPorDia()
            Me.dgvVenta.DataSource = parentTable
            dgvVenta.TableDescriptor.Relations.Clear()
            dgvVenta.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvVenta.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvVenta.Appearance.AnyRecordFieldCell.Enabled = False
            dgvVenta.GroupDropPanel.Visible = True
            dgvVenta.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub frmMasterVentaCajaRegistradora_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If filter IsNot Nothing Then
        '    filter.SaveCompareOperator()
        'End If
        Dispose()
    End Sub

    Private Sub frmMasterVentaCajaRegistradora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub VentasDelEstablecimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasDelEstablecimientoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaVentas()
        lblEstado.Text = "Lista de ventas período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
     
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaVentasDelDia()
        lblEstado.Text = "Ventas de día: " & DateTime.Now.Date
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chFilter1_Click(sender As Object, e As EventArgs) Handles chFilter1.Click
        If chFilter1.Checked = True Then
            Me.dgvVenta.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvVenta.TableDescriptor.Columns.Count - 1
                dgvVenta.TableDescriptor.Columns(i).AllowFilter = True
            Next
        Else
            Me.dgvVenta.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub chFilter2_Click(sender As Object, e As EventArgs) Handles chFilter2.Click
        If chFilter2.Checked Then
            filter.WireGrid(dgvVenta)
        Else
            filter.UnWireGrid(dgvVenta)
        End If
    End Sub

    Private Sub RegistroComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroComprasToolStripMenuItem.Click
        Try
            Me.dgvVenta.TableModel.Properties.PrintFrame = False

            Dim pd As New Syncfusion.GridHelperClasses.GridPrintDocumentAdv(Me.dgvVenta.TableControl)
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

    Private Sub btnEditCompra_Click_1(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ventaSA As New documentoVentaAbarrotesSA
        If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then
            Select Case Me.dgvVenta.Table.CurrentRecord.GetValue("tipoVenta")

                Case TIPO_VENTA.VENTA_AL_TICKET
                    'With frmVentaTicketCredito
                    '    .txtComprobante = Nothing
                    '    .txtIdComprobante = Nothing
                    '    .NumeroComprobante = Nothing
                    '    .txtSerie = Nothing

                    '    Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                    '        Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    '            .GuardarToolStripButton.Visible = True

                    '        Case TIPO_VENTA.PAGO.COBRADO
                    '            .GuardarToolStripButton.Visible = False

                    '        Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                    '            .GuardarToolStripButton.Visible = False
                    '    End Select

                    '    'If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "PN" Then
                    '    '    .GuardarToolStripButton.Visible = True
                    '    'ElseIf Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "DC" Then
                    '    '    .GuardarToolStripButton.Visible = False
                    '    'ElseIf Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = TIPO_VENTA.VENTA_ANULADA Then
                    '    '    .GuardarToolStripButton.Visible = False
                    '    '    Me.Cursor = Cursors.Arrow
                    '    '    Exit Sub
                    '    'End If
                    '    .txtFechaComprobante.ShowUpDown = True
                    '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    '    .UbicarDocumento(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                    '    .StartPosition = FormStartPosition.CenterParent
                    '    .ShowDialog()
                    'End With

                Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA

                    With frmVentaTicketDirecta
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                        Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                            Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                                '.GuardarToolStripButton.Enabled = False
                                'lblEstado.Text = "El documento está anulado!!"
                                'PanelError.Visible = True
                                'Timer1.Enabled = True
                                'TiempoEjecutar(10)

                                'If .TieneCuentaFinanciera(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                                '    .btGrabar.Enabled = False
                                '    .lblEstado.Text = "VENTA ANULADA!"
                                '    .txtFechaComprobante.ShowUpDown = True
                                '    .UbicarDocumento(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                                '    .StartPosition = FormStartPosition.CenterParent
                                '    .ShowDialog()
                                '    'Else
                                '    '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                                '    '    PanelError.Visible = True
                                '    '    Timer1.Enabled = True
                                '    '    TiempoEjecutar(10)
                                'End If

                            Case Else
                                'If .TieneCuentaFinanciera(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                                '    .btGrabar.Enabled = False
                                '    .txtFechaComprobante.ShowUpDown = True
                                '    .UbicarDocumento(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                                '    .StartPosition = FormStartPosition.CenterParent
                                '    .ShowDialog()
                                'Else
                                '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                                '    PanelError.Visible = True
                                '    Timer1.Enabled = True
                                '    TiempoEjecutar(10)
                                'End If

                        End Select

                        If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = TIPO_VENTA.VENTA_ANULADA Then
                            .btGrabar.Enabled = False
                            lblEstado.Text = "El documento está anulado!!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            '     lblEstado.Image = My.Resources.ok4
                        Else
                          
                        End If
                    End With

            End Select


        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        With frmFichaUsuarioCaja
            ModuloAppx = ModuloSistema.CAJA
            .lblNivel.Text = "Caja"
            .lblEstadoCaja.Visible = True
            '.GroupBox1.Visible = True
            '.GroupBox2.Visible = True
            '.GroupBox4.Visible = True
            '.cboMoneda.Visible = True
            .Timer1.Enabled = False
            .StartPosition = FormStartPosition.CenterParent
            '.UbicarUsuarioCaja(intIdDocumento, "VENTA")
            .ShowDialog()
            If IsNothing(GFichaUsuarios.NombrePersona) Then
                Return False
            Else
                Return True
            End If
        End With

        Return True

    End Function

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Dim ventaSA As New documentoVentaAbarrotesSA

        Try
            If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then

                Select Case Me.dgvVenta.Table.CurrentRecord.GetValue("tipoVenta")

                    Case TIPO_VENTA.VENTA_AL_TICKET
                        Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                            Case Nothing
                                lblEstado.Text = "La venta ya fue eliminada!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                            Case TIPO_VENTA.PAGO.COBRADO
                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    'If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "PN" Then
                                    '    EliminarVenta(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                                    'ElseIf Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "DC" Then
                                    EliminarVentaCobrada(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")), Me.dgvVenta.Table.CurrentRecord.GetValue("usuarioActualizacion"), TIPO_VENTA.VENTA_AL_TICKET)
                                    '  End If
                                    '      lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA
                                    lblEstado.Text = "Venta anulada!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    '   If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "PN" Then
                                    EliminarVenta(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                                    Me.dgvVenta.Table.CurrentRecord.Delete()
                                    'ElseIf Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "DC" Then
                                    '    EliminarVentaCobrada(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                                    'End If
                                    '      lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA
                                    lblEstado.Text = "Pedido eliminado!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                                lblEstado.Text = "El documento ya está anulado.!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                        End Select

                    Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
                        Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                            Case TIPO_VENTA.PAGO.COBRADO
                                If TieneCuentaFinanciera(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                                    EliminarVentaCobrada(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")), GFichaUsuarios.IdCajaUsuario, TIPO_VENTA.VENTA_AL_TICKET_DIRECTA)
                                End If
                                lblEstado.Text = "Venta anulada!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            Case TIPO_VENTA.PAGO.PENDIENTE_PAGO

                            Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                                lblEstado.Text = "El documento ya está anulado.!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                        End Select

                        'If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = TIPO_VENTA.VENTA_ANULADA Then
                        '    '     lblEstado.Image = My.Resources.ok4
                        '    lblEstado.Text = "El documento ya está anulado.!"
                        '    PanelError.Visible = True
                        '    Timer1.Enabled = True
                        '    TiempoEjecutar(10)
                        'Else
                        '    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        '        '      lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA


                        '        If TieneCuentaFinanciera(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                        '            If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "DC" Then
                        '                EliminarVentaCobrada(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
                        '                Me.dgvVenta.TableModel(Me.dgvVenta.Table.CurrentRecord.GetRowIndex, 15).CellValue = TIPO_VENTA.VENTA_ANULADA
                        '            End If
                        '            lblEstado.Text = "Venta anulada!"
                        '            PanelError.Visible = True
                        '            Timer1.Enabled = True
                        '            TiempoEjecutar(10)

                        '        Else
                        '            PanelError.Visible = True
                        '            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        '            Timer1.Enabled = True
                        '            TiempoEjecutar(10)
                        '        End If

                        '        '   lblEstado.Image = My.Resources.ok4
                        '        '   lblEstado.Text = "venta eliminada!"
                        '    End If
                        'End If
                End Select


            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub PedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        'With frmVentaTicketCredito
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PedidoDirectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidoDirectoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmVentaTicketDirecta
            .btGrabar.Enabled = True
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'If .TieneCuentaFinanciera = True Then
            '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '    .lblPerido.Text = PeriodoGeneral
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'Else
            '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
            'End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chAgrupa_Click(sender As Object, e As EventArgs) Handles chAgrupa.Click
        If chAgrupa.Checked Then
            dgvVenta.TableDescriptor.GroupedColumns.Clear()
            dgvVenta.ShowGroupDropArea = True
        Else
            dgvVenta.TableDescriptor.GroupedColumns.Clear()
            dgvVenta.ShowGroupDropArea = False
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        With frmCajaTicket
            If .TieneCuentaFinanciera = True Then
                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                .lblPerido.Text = lblPeriodo.Text
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            Else
                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevaNotaCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaNotaCréditoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmCreditoVenta  ' frmNotaCredito
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
            '.IdUsuarioCaja = Me.dgvCompra.Table.CurrentRecord.GetValue("usuarioActualizacion")
            '.TipoCompra = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
            '.IdCompraOrigen = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
            '.Moneda = Me.dgvCompra.Table.CurrentRecord.GetValue("monedaDoc")
            '.UbicarDetalle(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            '     .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            '.WindowState = FormWindowState.Maximized
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        'Dim ventaSA As New documentoVentaAbarrotesSA
        'If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then
        '    '  Dim documentoCompraSA As New DocumentoCompraDetalleSA
        '    'If documentoCompraSA.TieneItemsEnAV(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")) = True Then
        '    '    PanelError.Visible = True
        '    '    lblEstado.Text = "El comprobante posee items en el almacén virtual," & "necesita realizar la distribución, para seguir el proceso!"
        '    '    Timer1.Enabled = True
        '    '    TiempoEjecutar(10)
        '    '    Me.Cursor = Cursors.Arrow
        '    'Else
        '    Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
        '        Case TIPO_VENTA.PAGO.COBRADO
        '            With frmNotaCreditoVenta  ' frmNotaCredito
        '                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '                .StartPosition = FormStartPosition.CenterParent
        '                '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
        '                .IdCompraOrigen = Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")
        '                .Moneda = Me.dgvVenta.Table.CurrentRecord.GetValue("moneda")
        '                .UbicarDetalle(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento"))
        '                '     .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
        '                '.WindowState = FormWindowState.Maximized
        '                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '                .ShowDialog()
        '            End With
        '    End Select


        'End If
        '   End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VerNotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerNotasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then
            dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
            dockingManager1.SetDockVisibility(PanelNotas, True)
            dockingManager1.SetDockVisibility(PanelTributo, False)
            UbicarNotasPorIdPadre(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
            '   ObtenerObligaciones(CInt(lsvProduccion.SelectedItems(0).SubItems(0).Text))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VerGuíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerGuíaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then
            dockingManager1.SetDockVisibility(PanelGuiaRemision, True)
            dockingManager1.SetDockVisibility(PanelNotas, False)
            dockingManager1.SetDockVisibility(PanelTributo, False)
            ObtenerListaGuias(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

   
    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteDocumentoVentas
            .ConsultaReporteTotalesPorPeriodo(PeriodoGeneral)
            .lblPerido.Text = lblPeriodo.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteDocumentoVentas
            .ConsultaReporteTotalesPorDia(TIPO_VENTA.VENTA_AL_TICKET)
            .lblPerido.Text = lblPeriodo.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class