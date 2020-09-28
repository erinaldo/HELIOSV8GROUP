Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmMasterCompras
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
        configDockingManger()
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

#Region "Métodos Listas"

    Private Sub EliminarNotasPorCompra(intIdDocumentoCompra As Integer)
        Dim documentoSA As New DocumentoCompraSA
        documentoSA.EliminarDocNotasRef(intIdDocumentoCompra)

    End Sub

    Private Function getParentTableComprasPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
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
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT(intIdEstablecimiento, strPeriodo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
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
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableComprasPorDia(intIdEstablecimiento As Integer) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras del día " & DateTime.Now)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
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
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasPorDia_CONT(intIdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
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
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub UbicarNotasPorIdPadre(intIdDocumentoPadre As Integer)
        Dim documentocompraSA As New DocumentoCompraSA
        Dim movimientostr As String = Nothing
        lsvNotas.Items.Clear()

        For Each i In documentocompraSA.GetListarNotasPorIdCompraPadre(intIdDocumentoPadre, TIPO_COMPRA.NOTA_CREDITO)
            Select Case i.destino
                Case "9913"
                    movimientostr = "DISMINUIR CANTIDAD"
                Case "9914"
                    movimientostr = "DISMINUIR IMPORTE"
                Case "9915"
                    movimientostr = "DISMINUIR CANTIDAD E IMPORTE"
                Case "9916"
                    movimientostr = "DEVOLUCION DE EXISTENCIAS"
                Case "9917"
                    movimientostr = "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                Case "9918"
                    movimientostr = "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
            End Select

            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add(TIPO_COMPRA.NOTA_CREDITO)
            n.SubItems.Add(movimientostr)
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.numeroDoc)
            n.SubItems.Add(i.importeTotal)
            n.SubItems.Add(i.importeUS)
            n.SubItems.Add(i.idPadre)
            lsvNotas.Items.Add(n)

        Next

        For Each i In documentocompraSA.GetListarNotasPorIdCompraPadre(intIdDocumentoPadre, TIPO_COMPRA.NOTA_DEBITO)
            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add(TIPO_COMPRA.NOTA_DEBITO)
            n.SubItems.Add("INCREMENTO DEL COSTO")
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.numeroDoc)
            n.SubItems.Add(i.importeTotal)
            n.SubItems.Add(i.importeUS)
            n.SubItems.Add(i.idPadre)
            lsvNotas.Items.Add(n)
        Next



        '  ggNotacRedito.TableDescriptor.Columns.Add("")
    End Sub

    Private Sub ObtenerObligaciones(intIdDocCompra As Integer)
        Dim docObligacionSA As New DocumentoObligacionTributariaSA
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        lsvTributos.Items.Clear()
        For Each i As documentoObligacionTributaria In docObligacionSA.ListadoTributoPorIdDocumentoOrigen(intIdDocCompra)
            Dim n As New ListViewItem(i.idDocumento)
            If i.tipoTributo = "D" Then
                n.SubItems.Add("Detracción")
            Else
                n.SubItems.Add(i.tipoTributo)
            End If
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add(i.serieDoc)
            n.SubItems.Add(i.numeroDoc)
            n.SubItems.Add(i.NomProveedor)
            n.SubItems.Add(i.moneda)
            n.SubItems.Add(i.porcTributario)
            totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("importeTotal") * (Math.Round(CDec(i.porcTributario) / 100, 2))
            totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("importeUS") * (Math.Round(CDec(i.porcTributario) / 100, 2))
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            lsvTributos.Items.Add(n)
            'dgvObligacion.Rows.Add(i.idDocumento, i.tipoTributo, i.fechaDoc, i.serieDoc, i.numeroDoc, i.NomProveedor, i.moneda, i.porcTributario,
            '                       0, 0)
        Next

        If lsvTributos.Items.Count > 0 Then
            CALCULO_TRIBUTOS(Me.dgvCompra.Table.CurrentRecord.GetValue("importeTotal"), Me.dgvCompra.Table.CurrentRecord.GetValue("importeUS"))
        End If
    End Sub

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

    Public Sub ListaComprasPorDia()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTableComprasPorDia(GEstableciento.IdEstablecimiento)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
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
            .ManipulacionEstado = ENTITY_ACTIONS.DELETE
            .StartPosition = FormStartPosition.CenterParent
            '.UbicarUsuarioCaja(intIdDocumento, "COMPRA")
            .ShowDialog()
            If IsNothing(GFichaUsuarios.NombrePersona) Then
                Return False
            Else
                Return True
            End If
        End With

        Return True

    End Function

    Public Sub ListaCompras(strPeriodo As String)
        'Dim documentoCompraSA As New DocumentoCompraSA
        'Dim grupoActual As String = String.Empty
        'Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()

            'lsvProduccion.Columns.Clear()
            'lsvProduccion.Items.Clear()
            'lsvProduccion.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            'lsvProduccion.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            'lsvProduccion.Columns.Add("Fecha emisión/pago", 155, HorizontalAlignment.Left) '2
            'lsvProduccion.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            'lsvProduccion.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            'lsvProduccion.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            'lsvProduccion.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            'lsvProduccion.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            'lsvProduccion.Columns.Add("Proveedor", 237, HorizontalAlignment.Left) '8
            'lsvProduccion.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            'lsvProduccion.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            'lsvProduccion.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            'lsvProduccion.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            'lsvProduccion.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            'lsvProduccion.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            'lsvProduccion.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            'lsvProduccion.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16

            'Select Case ModuloAppx
            '    Case ModuloSistema.PLANEAMIENTO
            '        For Each i As documentocompra In documentoCompraSA.GetListarComprasPorPeriodoGeneral(GProyectos.IdProyectoActividad, strPeriodo)

            '            Dim n As New ListViewItem(i.idDocumento)
            '            n.UseItemStyleForSubItems = False
            '            If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
            '            ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
            '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
            '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
            '            End If

            '            '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
            '            n.SubItems.Add(FormatDateTime(i.fechaDoc, "dd/MM/yyyy hh:mm:ss"))
            '            n.SubItems.Add(i.tipoDoc)
            '            n.SubItems.Add(i.serie)
            '            n.SubItems.Add(i.numeroDoc)
            '            n.SubItems.Add(i.tipoDocEntidad)
            '            n.SubItems.Add(i.NroDocEntidad)
            '            n.SubItems.Add(i.NombreEntidad)
            '            n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
            '            n.SubItems.Add(FormatNumber(i.importeTotal, 2))
            '            n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
            '            n.SubItems.Add(FormatNumber(i.importeUS, 2))
            '            n.SubItems.Add(i.monedaDoc)
            '            n.SubItems.Add(i.tipoCompra)
            '            n.SubItems.Add(i.idPadre)
            '            If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
            '                n.SubItems.Add("Pagado")
            '            ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
            '                n.SubItems.Add("En trámite")
            '            End If
            '            lsvProduccion.Items.Add(n)

            '        Next
            '    Case Else

            '        For Each i As documentocompra In documentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT(strPeriodo)

            '            Dim n As New ListViewItem(i.idDocumento)
            '            n.UseItemStyleForSubItems = False
            '            If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
            '            ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
            '            ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
            '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
            '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
            '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
            '            End If

            '            '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
            '            n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.GeneralDate))
            '            n.SubItems.Add(i.tipoDoc)
            '            n.SubItems.Add(i.serie)
            '            n.SubItems.Add(i.numeroDoc)
            '            n.SubItems.Add(i.tipoDocEntidad)
            '            n.SubItems.Add(i.NroDocEntidad)
            '            n.SubItems.Add(i.NombreEntidad)
            '            n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
            '            n.SubItems.Add(FormatNumber(i.importeTotal, 2))
            '            n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
            '            n.SubItems.Add(FormatNumber(i.importeUS, 2))
            '            n.SubItems.Add(i.monedaDoc)
            '            n.SubItems.Add(i.tipoCompra)
            '            n.SubItems.Add(IIf(IsNothing(i.idPadre), String.Empty, i.idPadre))
            '            If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
            '                n.SubItems.Add("Pagado")
            '            ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
            '                n.SubItems.Add("En trámite")
            '            End If
            '            lsvProduccion.Items.Add(n)

            '        Next
            'End Select

            'If lsvProduccion.Items.Count > 0 Then
            '    lsvProduccion.Focus()
            '    lsvProduccion.Items(0).Selected = True
            '    lsvProduccion.Items(0).Focused = True

            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RemoveCompraCredito(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Jiuni"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompra.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.DeleteDocumentoSL(objDocumento, ListaTotales)
    End Sub

    Public Sub RemoveCompraCreditoSingle(IntIdDocumento As Integer)

        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

                        Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)
                    End If
                End If
            End If
        Next
        documentoSA.DeleteDocumento(objDocumento, ListaTotales)
    End Sub

    Public Sub RemoveCompraSimpleRetSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento
            .idDocumento = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompra.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With

        documentoSA.DeleteDocumentoPagadoAlCredito(objDocumento)

    End Sub

    Public Sub RemoveCompraSL(IntIdDocumento As Integer)

        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento
            .idDocumento = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompra.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.DeleteDocumentoPagadoSL(objDocumento)
    End Sub

    Public Sub EliminarCompraDirectaSinRecepcionSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .tipoDoc = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        End With

        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

                        Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)
                    End If
                End If
            End If
        Next

        documentoSA.DeleteCompraDirectaSinRecepcionSL(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarCompraDirectaSinRecepcionRecepSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Jiuni"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompra.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.DeleteDocumentoSL(objDocumento, ListaTotales)
    End Sub


    'Sub ElimnarDocRadial()
    '    GFichaUsuarios = New GFichaUsuario
    '    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
    '        If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_AL_CREDITO Then
    '            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                If Me.dgvCompra.Table.CurrentRecord.GetValue("situacion") = TIPO_SITUACION.ALMACEN_TRANSITO Then
    '                    RemoveCompraCreditoSingle(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    '                ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("situacion") = TIPO_SITUACION.ALMACEN_TRANSITO_FISICO Then
    '                    RemoveCompraCredito(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    '                    With frmMasterpmo
    '                        .ObtenerConteoNotificacion()
    '                        .Refresh()
    '                    End With
    '                End If

    '                Me.dgvCompra.Table.CurrentRecord.Delete()
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '                '    lblEstado.Image = My.Resources.ok4
    '                lblEstado.Text = "Compra eliminada!"


    '            End If

    '        ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION Then
    '            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                RemoveCompraSimpleRetSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    '                Me.dgvCompra.Table.CurrentRecord.Delete()
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '                '    lblEstado.Image = My.Resources.ok4
    '                lblEstado.Text = "Compra eliminada!"
    '                With frmMasterpmo
    '                    .ObtenerConteoNotificacion()
    '                    .Refresh()
    '                End With
    '            End If

    '        ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
    '            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                If TieneCuentaFinanciera(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
    '                    RemoveCompraSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    '                    Me.dgvCompra.Table.CurrentRecord.Delete()
    '                    PanelError.Visible = True
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)
    '                    '   lblEstado.Image = My.Resources.ok4
    '                    lblEstado.Text = "Compra eliminada!"
    '                    With frmMasterpmo
    '                        .ObtenerConteoNotificacion()
    '                        .Refresh()
    '                    End With
    '                Else
    '                    PanelError.Visible = True
    '                    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)
    '                End If
    '            End If



    '        ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
    '            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                If TieneCuentaFinanciera(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
    '                    If Me.dgvCompra.Table.CurrentRecord.GetValue("situacion") = TIPO_SITUACION.ALMACEN_TRANSITO Then
    '                        EliminarCompraDirectaSinRecepcionSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    '                    ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("situacion") = TIPO_SITUACION.ALMACEN_TRANSITO_FISICO Then
    '                        EliminarCompraDirectaSinRecepcionRecepSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    '                        With frmMasterpmo
    '                            .ObtenerConteoNotificacion()
    '                            .Refresh()
    '                        End With
    '                    End If

    '                    Me.dgvCompra.Table.CurrentRecord.Delete()
    '                    ' lblEstado.Image = My.Resources.ok4
    '                    'lblEstado.Text = "Compra eliminada!"
    '                    PanelError.Visible = True
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)

    '                Else
    '                    PanelError.Visible = True
    '                    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)
    '                End If
    '            End If

    '        End If
    '    End If
    'End Sub

    Sub ElimnarDocRadial()
        GFichaUsuarios = New GFichaUsuario
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RemoveCompraCredito(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    With frmMasterpmo
                        .ObtenerConteoNotificacion()
                        .Refresh()
                    End With
                    'End If

                    Me.dgvCompra.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    lblEstado.Text = "Compra eliminada!"


                End If

            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RemoveCompraSimpleRetSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    Me.dgvCompra.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    '    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "Compra eliminada!"
                    With frmMasterpmo
                        .ObtenerConteoNotificacion()
                        .Refresh()
                    End With
                End If

            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If TieneCuentaFinanciera(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                        RemoveCompraSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        Me.dgvCompra.Table.CurrentRecord.Delete()
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        '   lblEstado.Image = My.Resources.ok4
                        lblEstado.Text = "Compra eliminada!"
                        With frmMasterpmo
                            .ObtenerConteoNotificacion()
                            .Refresh()
                        End With
                    Else
                        PanelError.Visible = True
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                End If



            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If TieneCuentaFinanciera(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                        'If Me.dgvCompra.Table.CurrentRecord.GetValue("situacion") = TIPO_SITUACION.ALMACEN_TRANSITO Then
                        '    EliminarCompraDirectaSinRecepcionSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        'ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("situacion") = TIPO_SITUACION.ALMACEN_TRANSITO_FISICO Then
                        EliminarCompraDirectaSinRecepcionRecepSL(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        With frmMasterpmo
                            .ObtenerConteoNotificacion()
                            .Refresh()
                        End With
                        'End If

                        Me.dgvCompra.Table.CurrentRecord.Delete()
                        ' lblEstado.Image = My.Resources.ok4
                        'lblEstado.Text = "Compra eliminada!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)

                    Else
                        PanelError.Visible = True
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                End If

            End If
        End If
    End Sub
#End Region

#Region "Manipulación Data"
    Public Sub EliminarNota(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA

        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim DOcumentoCompraSA As New DocumentoCompraSA
        Dim DOcumentoCompra As New documentocompra
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .IdDocumentoAfectado = lsvNotas.SelectedItems(0).SubItems(8).Text
            .idDocumento = IntIdDocumento
        End With
        DOcumentoCompra = DOcumentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
        objDocumento.documentocompra = DOcumentoCompra
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

                        Select Case lsvNotas.SelectedItems(0).SubItems(3).Text
                            Case "DISMINUIR CANTIDAD"
                                objNuevo.cantidad = i.monto1
                                objNuevo.importeSoles = 0
                                objNuevo.importeDolares = 0
                                objDocumento.documentocompra.destino = "NC-DISMINUIR CANTIDAD"
                            Case "DISMINUIR IMPORTE"
                                objNuevo.cantidad = 0
                                objNuevo.importeSoles = i.montokardex
                                objNuevo.importeDolares = i.montokardexUS
                                objDocumento.documentocompra.destino = "NC-DISMINUIR IMPORTE"
                            Case "DISMINUIR CANTIDAD E IMPORTE"

                            Case "DEVOLUCION DE EXISTENCIAS"
                                objNuevo.cantidad = i.monto1
                                objNuevo.importeSoles = i.montokardex
                                objNuevo.importeDolares = i.montokardexUS
                                objDocumento.documentocompra.destino = "NC-DEVOLUCION DE EXISTENCIAS"
                            Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                                objNuevo.cantidad = i.monto1 * -1
                                objNuevo.importeSoles = i.montokardex * -1
                                objNuevo.importeDolares = i.montokardexUS * -1
                                objDocumento.documentocompra.destino = "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                            Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                                If i.monto1 > 0 Then
                                    objNuevo.cantidad = i.monto1
                                Else
                                    objNuevo.cantidad = 0
                                End If

                                If i.montokardex > 0 Then
                                    objNuevo.importeSoles = i.montokardex
                                Else
                                    objNuevo.importeSoles = 0
                                End If

                                If i.montokardexUS > 0 Then
                                    objNuevo.importeDolares = i.montokardexUS
                                Else
                                    objNuevo.importeDolares = 0
                                End If

                                objDocumento.documentocompra.destino = "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                        End Select


                        objNuevo.precioUnitarioCompra = i.precioUnitario
                        objNuevo.montoIsc = 0 ' i.montoIsc
                        objNuevo.montoIscUS = 0 ' i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteNotas(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarNotaDebito(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA

        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim DOcumentoCompraSA As New DocumentoCompraSA
        Dim DOcumentoCompra As New documentocompra
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .IdDocumentoAfectado = lsvNotas.SelectedItems(0).SubItems(8).Text
            .idDocumento = IntIdDocumento
        End With
        DOcumentoCompra = DOcumentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
        objDocumento.documentocompra = DOcumentoCompra
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
                        objNuevo.cantidad = 0
                        objNuevo.importeSoles = i.montokardex
                        objNuevo.importeDolares = i.montokardexUS
                        objNuevo.precioUnitarioCompra = i.precioUnitario
                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteNotasDebito(objDocumento, ListaTotales)
    End Sub

    Private Sub EliminarTributo(intIdDocumento As Integer)
        Dim docTributoSA As New DocumentoObligacionTributariaSA

        docTributoSA.EliminarObligacion(intIdDocumento)
        lsvTributos.SelectedItems(0).Remove()
        PanelError.Visible = True
        lblEstado.Text = "Tributo eliminado correctamente!"
        '  lblEstado.Image = My.Resources.ok4
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub

    Private Sub EliminarTributoPercepcion(intIdDocumento As Integer, intIdDocumentoTributo As Integer)
        Dim docTributoSA As New DocumentoObligacionTributariaSA

        docTributoSA.EliminarObligacionPercepcion(intIdDocumento, intIdDocumentoTributo)
        lsvTributos.SelectedItems(0).Remove()
        PanelError.Visible = True
        lblEstado.Text = "Tributo eliminado correctamente!"
        '   lblEstado.Image = My.Resources.ok4
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub
#End Region

    Private Sub frmMasterCompras_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If filter IsNot Nothing Then
            '   filter.SaveCompareOperator()
        End If
        Dispose()
    End Sub

    Private Sub frmMasterCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub CompraDirectaConRecepciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompraDirectaConRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            'Select Case cierre.estado
            '    Case "C"
            '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
            '        PanelError.Visible = True
            '        Timer1.Enabled = True
            '        TiempoEjecutar(10)
            '    Case "A"
            '        With frmCompraDirectaRecepcion
            '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '            If .TieneCuentaFinanciera = True Then
            '                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            '                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '                .lblPerido.Text = lblPeriodo.Text
            '                .StartPosition = FormStartPosition.CenterParent
            '                .WindowState = FormWindowState.Maximized
            '                .ShowDialog()
            '            Else
            '                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
            '                PanelError.Visible = True
            '                Timer1.Enabled = True
            '                TiempoEjecutar(5)
            '            End If
            '        End With
            'End Select
        Else
            ' MsgBox("")
            With frmCompraDirectaRecepcion
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                If .TieneCuentaFinanciera = True Then
                    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    .lblPerido.Text = lblPeriodo.Text
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Maximized
                    .ShowDialog()
                Else
                    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                End If
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraDirectaSinRecepciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompraDirectaSinRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            '    Select cierre.estado
            '        Case "C"
            '            lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
            '            PanelError.Visible = True
            '            Timer1.Enabled = True
            '            TiempoEjecutar(10)
            '        Case "A"
            '            With frmCompraPagadaSinRecepcion
            '                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '                If .TieneCuentaFinanciera = True Then
            '                    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            '                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '                    .lblPerido.Text = lblPeriodo.Text

            '                    .StartPosition = FormStartPosition.CenterParent
            '                    '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
            '                    .WindowState = FormWindowState.Maximized
            '                    .ShowDialog()
            '                Else
            '                    PanelError.Visible = True
            '                    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
            '                    Timer1.Enabled = True
            '                    TiempoEjecutar(5)
            '                End If
            '            End With

            '    End Select
            'Else
            '    With frmCompraPagadaSinRecepcion
            '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '        If .TieneCuentaFinanciera = True Then
            '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '            .lblPerido.Text = lblPeriodo.Text

            '            .StartPosition = FormStartPosition.CenterParent
            '            '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
            '            .WindowState = FormWindowState.Maximized
            '            .ShowDialog()
            '        Else
            '            PanelError.Visible = True
            '            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
            '            Timer1.Enabled = True
            '            TiempoEjecutar(5)
            '        End If
            '    End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompraToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            'Select cierre.estado
            '    Case "C"
            '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
            '        PanelError.Visible = True
            '        Timer1.Enabled = True
            '        TiempoEjecutar(10)
            '    Case "A"
            '        With frmCompraCreditoSinRecepcion
            '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '            .lblPerido.Text = PeriodoGeneral
            '            .StartPosition = FormStartPosition.CenterParent
            '            .WindowState = FormWindowState.Maximized
            '            .ShowDialog()
            '        End With

            'End Select
        Else
            With frmCompraCreditoSinRecepcion
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                .lblPerido.Text = PeriodoGeneral
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnComprasPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles btnComprasPeriodo.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaCompras(PeriodoGeneral)
        lblEstado.Text = "Lista de compras período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEditCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        GConfiguracion = New GConfiguracionModulo
        GFichaUsuarios = New GFichaUsuario

        SelecIDEstable = Nothing
        SelecNombreEstable = Nothing
        SelectIdAlmacen = Nothing
        SelectNombreAlmacen = Nothing
        IdAlmacenBack = Nothing

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                With frmCompraCreditoSinRecepcion
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .txtFechaComprobante.ShowUpDown = True
                    .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Maximized
                    .ShowDialog()
                End With
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
                With frmCompraDirectaRecepcion
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    If .TieneCuentaFinanciera(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                        .txtFechaComprobante.ShowUpDown = True
                        .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))

                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    Else
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If
                End With

            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                With frmCompraPagadaSinRecepcion
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    If .TieneCuentaFinanciera(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                        .txtFechaComprobante.ShowUpDown = True
                        .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    Else
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If
                End With
                'ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_CREDITO Then
                '    With frmNotaCredito
                '        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '        .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                'ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_DEBITO Then
                '    With frmNotaDebito
                '        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '        .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDia
            ElseIf Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION Then
                With frmCompraCreditoConRecepcion
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .txtFechaComprobante.ShowUpDown = True
                    .colModifiPrecio.Visible = False
                    .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Maximized
                    .ShowDialog()
                End With
            End If
            'lsvProduccion.SelectedItems(0).Selected = True
            'lsvProduccion.SelectedItems(0).Focused = True
            'lsvProduccion.FocusedItem.EnsureVisible()
            'If ExpandCollapsePanel1.IsExpanded Then
            '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            'End If
            'If EXGuias.IsExpanded = True Then
            '    ObtenerListaGuias(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            'End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCompra.Click
        ElimnarDocRadial()
    End Sub

    Private Sub ToolStripPanelItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripPanelItem2.Click

    End Sub

    Private Sub btnComprasDia_Click(sender As System.Object, e As System.EventArgs) Handles btnComprasDia.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaComprasPorDia()
        lblEstado.Text = "Lista de compras del día: " & DateTime.Now.Date
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
            PanelError.Visible = True
            lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        Else
            With frmCredito ' frmNotaCredito
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                .IdCompraOrigen = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
                .Moneda = Me.dgvCompra.Table.CurrentRecord.GetValue("monedaDoc")
                .UbicarDetalle(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                '     .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '.WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NDébitoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
            PanelError.Visible = True
            lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        Else
            With frmNotaDebito
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .UbicarCabeceraCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                '.WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = PeriodoGeneral
                .cboOT.Text = "DETRACCION"
                .UbicarCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                'If ExpandCollapsePanel1.IsExpanded = True Then
                '    lsvProduccion.SelectedItems(0).Selected = True
                '    lsvProduccion.SelectedItems(0).Focused = True
                '    lsvProduccion.FocusedItem.EnsureVisible()
                '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                'End If

            End With
        Else
            PanelError.Visible = True
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = PeriodoGeneral
                .cboOT.Text = "RETENCION"
                .UbicarCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                'If ExpandCollapsePanel1.IsExpanded = True Then
                '    lsvProduccion.SelectedItems(0).Selected = True
                '    lsvProduccion.SelectedItems(0).Focused = True
                '    lsvProduccion.FocusedItem.EnsureVisible()
                '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                'End If

            End With
        Else
            PanelError.Visible = True
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = PeriodoGeneral
                .cboOT.Text = "PERCEPCION"
                .UbicarCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                'If ExpandCollapsePanel1.IsExpanded = True Then
                '    lsvProduccion.SelectedItems(0).Selected = True
                '    lsvProduccion.SelectedItems(0).Focused = True
                '    lsvProduccion.FocusedItem.EnsureVisible()
                '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                'End If

            End With
        Else
            PanelError.Visible = True
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnVerGuia_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub VerNotasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerNotasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
            dockingManager1.SetDockVisibility(PanelNotas, True)
            dockingManager1.SetDockVisibility(PanelTributo, False)
            UbicarNotasPorIdPadre(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
            '   ObtenerObligaciones(CInt(lsvProduccion.SelectedItems(0).SubItems(0).Text))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevaNotaCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaNotaCréditoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Dim documentoCompraSA As New DocumentoCompraDetalleSA
        '    If documentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
        '        PanelError.Visible = True
        '        lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        Me.Cursor = Cursors.Arrow
        '    Else
        With frmCredito ' frmNotaCredito
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
        '    End If
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VerGuíaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerGuíaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            dockingManager1.SetDockVisibility(PanelGuiaRemision, True)
            dockingManager1.SetDockVisibility(PanelNotas, False)
            dockingManager1.SetDockVisibility(PanelTributo, False)
            ObtenerListaGuias(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevaNotaDébitoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaNotaDébitoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Dim documentoCompraSA As New DocumentoCompraDetalleSA
        '    If documentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
        '        PanelError.Visible = True
        '        lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        Me.Cursor = Cursors.Arrow
        '    Else
        With frmDebito
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.IdCompraOrigen = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
            '.Moneda = Me.dgvCompra.Table.CurrentRecord.GetValue("monedaDoc")
            '.StartPosition = FormStartPosition.CenterParent
            '.UbicarDetalle(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            '.WindowState = FormWindowState.Maximized
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        '    End If
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoDetracciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoDetracciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
            If docObligacionDetalleSA.ComprobanteTieneTributo(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = False Then
                With frmTributoRegistro
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .txtPeriodo.Text = PeriodoGeneral
                    .cboTributo.Text = "DETRACCION"
                    .UbicarCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    .txtFechaComprobante.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
                        dockingManager1.SetDockVisibility(PanelNotas, False)
                        dockingManager1.SetDockVisibility(PanelTributo, True)
                        ObtenerObligaciones(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
                    End If
                    'If ExpandCollapsePanel1.IsExpanded = True Then
                    '    lsvProduccion.SelectedItems(0).Selected = True
                    '    lsvProduccion.SelectedItems(0).Focused = True
                    '    lsvProduccion.FocusedItem.EnsureVisible()
                    '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    'End If

                End With
            Else
                PanelError.Visible = True
                lblEstado.Text = "El comprobante ya tiene asignado un tributo"
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VerTributosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerTributosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
            dockingManager1.SetDockVisibility(PanelNotas, False)
            dockingManager1.SetDockVisibility(PanelTributo, True)
            ObtenerObligaciones(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevaRetenciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaRetenciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
            If docObligacionDetalleSA.ComprobanteTieneTributo(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = False Then
                With frmTributoRegistro
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .txtPeriodo.Text = PeriodoGeneral
                    .cboTributo.Text = "RETENCION"
                    .UbicarCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    .txtFechaComprobante.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'If ExpandCollapsePanel1.IsExpanded = True Then
                    '    lsvProduccion.SelectedItems(0).Selected = True
                    '    lsvProduccion.SelectedItems(0).Focused = True
                    '    lsvProduccion.FocusedItem.EnsureVisible()
                    '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    'End If

                End With
            Else
                PanelError.Visible = True
                lblEstado.Text = "El comprobante ya tiene asignado un tributo"
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevaPercepciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaPercepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
            If docObligacionDetalleSA.ComprobanteTieneTributo(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = False Then
                With frmTributoRegistro
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .txtPeriodo.Text = PeriodoGeneral
                    .cboTributo.Text = "PERCEPCION"
                    .UbicarCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    .txtFechaComprobante.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'If ExpandCollapsePanel1.IsExpanded = True Then
                    '    lsvProduccion.SelectedItems(0).Selected = True
                    '    lsvProduccion.SelectedItems(0).Focused = True
                    '    lsvProduccion.FocusedItem.EnsureVisible()
                    '    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    'End If

                End With
            Else
                PanelError.Visible = True
                lblEstado.Text = "El comprobante ya tiene asignado un tributo"
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvTributos_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvTributos.MouseClick
        If lsvTributos.SelectedItems.Count > 0 Then
            If e.Button = MouseButtons.Right Then
                If lsvTributos.FocusedItem.Bounds.Contains(e.Location) = True Then
                    cmMenu.Show(Cursor.Position)
                End If
            End If
        End If
    End Sub

    Private Sub EliminarFilaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        If lsvTributos.SelectedItems.Count > 0 Then
            If lsvTributos.SelectedItems(0).SubItems(1).Text <> "P" Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTributo(lsvTributos.SelectedItems(0).SubItems(0).Text)
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
                        dockingManager1.SetDockVisibility(PanelNotas, False)
                        dockingManager1.SetDockVisibility(PanelTributo, True)
                        ObtenerObligaciones(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
                    End If
                End If
            Else
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTributoPercepcion(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")), CInt(lsvTributos.SelectedItems(0).SubItems(0).Text))
                End If
            End If
        End If
    End Sub

    Private Sub VerDetalleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerDetalleToolStripMenuItem.Click
        If lsvTributos.SelectedItems.Count > 0 Then
            If lsvTributos.SelectedItems(0).SubItems(1).Text = "P" Then
                With frmCanastaTributo
                    .UbicarDetalleTributo(lsvTributos.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If
    End Sub
    Sub CALCULO_TRIBUTOS(impMN As Decimal, impME As Decimal)
        Dim valPorcentaje As Decimal = 0
        valPorcentaje = CDec(lsvTributos.Items(0).SubItems(7).Text) / 100

        If valPorcentaje > 0 Then
            '      If txtImportemnCompra.Text.Trim.Length > 0 Then
            'If CDec(txtImportemnCompra.Text) > 0 Then
            lsvTributos.Items(0).SubItems(8).Text = Math.Round(CDec(impMN) * valPorcentaje, 2)
            lsvTributos.Items(0).SubItems(9).Text = Math.Round(CDec(impME) * valPorcentaje, 2)
            'End If
            '   End If
        Else
            lsvTributos.Items(0).SubItems(8).Text = 0
            lsvTributos.Items(0).SubItems(9).Text = 0
        End If

    End Sub
    Private Sub VerComprobanteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerComprobanteToolStripMenuItem.Click
        If lsvTributos.SelectedItems.Count > 0 Then
            If lsvTributos.SelectedItems(0).SubItems(1).Text <> "P" Then
                With frmTributoRegistro
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .txtFechaComprobante.ShowUpDown = True
                    .UbicarDOcumentoTirbuto(lsvTributos.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
                        dockingManager1.SetDockVisibility(PanelNotas, False)
                        dockingManager1.SetDockVisibility(PanelTributo, True)
                        ObtenerObligaciones(CInt(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")))
                    End If
                    'If lsvTributos.Items.Count > 0 Then
                    '    CALCULO_TRIBUTOS(Me.dgvCompra.Table.CurrentRecord.GetValue("importeTotal"), Me.dgvCompra.Table.CurrentRecord.GetValue("importeUS"))
                    'End If

                End With
            End If
        End If
    End Sub

    Private Sub lsvProduccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        lsvGuia.Items.Clear()
        lsvNotas.Items.Clear()
        lsvTributos.Items.Clear()
    End Sub

    Private Sub lsvNotas_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvNotas.MouseClick
        If lsvNotas.SelectedItems.Count > 0 Then
            If e.Button = MouseButtons.Right Then
                If lsvNotas.FocusedItem.Bounds.Contains(e.Location) = True Then
                    cMenuNotas.Show(Cursor.Position)
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim notasSA As New DocumentoCompraSA
        If lsvNotas.SelectedItems.Count > 0 Then

            Select Case notasSA.TieneNotasCD(lsvNotas.SelectedItems(0).SubItems(8).Text)
                Case True '> 1
                    lblEstado.Text = "No se puede eliminar!!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Case False
                    Select Case lsvNotas.SelectedItems(0).SubItems(2).Text
                        Case TIPO_COMPRA.NOTA_CREDITO
                            If MessageBox.Show("Desea eliminar la nota de crédito?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                EliminarNota(CInt(lsvNotas.SelectedItems(0).SubItems(0).Text))
                                lsvNotas.SelectedItems(0).Remove()
                                PanelError.Visible = True
                                lblEstado.Text = "nota de crédito eliminada!"
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            End If
                        Case TIPO_COMPRA.NOTA_DEBITO
                            If MessageBox.Show("Desea eliminar la nota de crédito?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                EliminarNotaDebito(CInt(lsvNotas.SelectedItems(0).SubItems(0).Text))
                                lsvNotas.SelectedItems(0).Remove()
                                PanelError.Visible = True
                                lblEstado.Text = "nota de débito eliminada!"
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            End If
                    End Select
            End Select

        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If lsvNotas.SelectedItems.Count > 0 Then
            With frmCanastaCompraDetalle
                .UbicarDetalle(CInt(lsvNotas.SelectedItems(0).SubItems(0).Text))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

 
    Private Sub ToolStripMenuItem3_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click

    End Sub

    Private Sub ToolStripButton2_ButtonClick(sender As Object, e As EventArgs)

    End Sub

    'Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
    '    Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
    '    'Enable the filter for each columns 
    '    For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
    '        dgvCompra.TableDescriptor.Columns(i).AllowFilter = True
    '    Next
    'End Sub

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

    Private Sub chFilter2_Click_1(sender As Object, e As EventArgs) Handles chFilter2.Click
        If chFilter2.Checked Then
            Filter.WireGrid(dgvCompra)
        Else
            Filter.UnWireGrid(dgvCompra)
        End If
    End Sub

    Private Sub chAgrupa_Click_1(sender As Object, e As EventArgs) Handles chAgrupa.Click
        If chAgrupa.Checked Then
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = True
        Else
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = False
        End If
    End Sub

    Private Sub EliminarNotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarNotasToolStripMenuItem.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            EliminarNotasPorCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        End If
    End Sub

    Private Sub lsvNotas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvNotas.SelectedIndexChanged

    End Sub
    Public Enum Asegurable 'Los códigos son los que están asignados en la BD
        Seguridad = 1
        AltaUsuario = 2
        UsuarioEnRol = 3
    End Enum
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If AutorizacionRolSA.TienePermiso(Asegurable.Seguridad, AutorizacionRolList) Then
            MessageBox.Show("Usuario autorizado")
        Else
            MessageBox.Show("Usuario no autorizado")
        End If
    End Sub

    Private Sub btnVerOrden_Click(sender As Object, e As EventArgs) Handles btnVerOrden.Click
        With frmCrearUsuarioEmpresa
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteDocumentoCompra
            .lblPerido.Text = Date.Now.Date
            .ConsultaReporteTotalesPorDia()
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteDocumentoCompra
            .lblPerido.Text = lblPeriodo.Text
            .ConsultaReporteTotalesPorPeriodo(lblPeriodo.Text)
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvGuia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvGuia.SelectedIndexChanged

    End Sub

    Private Sub CompCreditCRecepExistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompCreditCRecepExistToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            'Select Case cierre.estado
            '    Case "C"
            '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
            '        PanelError.Visible = True
            '        Timer1.Enabled = True
            '        TiempoEjecutar(10)
            '    Case "A"
            '        With frmCompraCreditoConRecepcion
            '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '            .lblPerido.Text = PeriodoGeneral
            '            .StartPosition = FormStartPosition.CenterParent
            '            .WindowState = FormWindowState.Maximized
            '            .ShowDialog()
            '        End With

            'End Select
        Else
            With frmCompraCreditoConRecepcion
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                .lblPerido.Text = PeriodoGeneral
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem2_CheckStateChanged(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.CheckStateChanged

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub
End Class