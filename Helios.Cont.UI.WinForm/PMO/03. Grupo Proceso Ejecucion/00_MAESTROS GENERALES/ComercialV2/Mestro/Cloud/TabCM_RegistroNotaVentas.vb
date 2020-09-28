Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabCM_RegistroNotaVentas
#Region "Attributes"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim filter As New GridExcelFilter()
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

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGridAvanzado(dgPedidos, True, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
    End Sub

    Public Sub New(be As documentoventaAbarrotes, opcion As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgPedidos, True, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
        GetNotasPorFecha(be, opcion)
    End Sub
#End Region

#Region "Methods"
    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.AnularNotaVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub GetCombos()
        Dim anioSA As New empresaPeriodoSA

        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboAnio.DataSource = anioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.Text = DateTime.Now.Year.ToString
    End Sub

    Private Sub GetListaVentasPorPeriodo(estable As Integer, period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Nota de venta - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("sustentado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarNotaDeVentasPeriodo(estable, period)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = "NOTA DE VENTA"
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            Select Case i.estadoCobro
                Case "DC"
                    dr(14) = "Cobrado"
                Case "ANU"
                    dr(14) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(14) = "Anulado x NC."
                Case Else
                    dr(14) = "Pendiente"
            End Select
            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            dr(17) = If(i.estado = StatusNotaDeVentas.Sustentado, "Sustentado", "No Sustentado")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub


    Private Sub GetNotasPorFecha(be As documentoventaAbarrotes, opcion As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Notas de venta")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("sustentado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetNotaVentasPorFecha(be, opcion)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = "NOTA DE VENTA"
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            Select Case i.estadoCobro
                Case "DC"
                    dr(14) = "Cobrado"
                Case "ANU"
                    dr(14) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(14) = "Anulado x NC."
                Case Else
                    dr(14) = "Pendiente"
            End Select
            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            dr(17) = If(i.estado = StatusNotaDeVentas.Sustentado, "Sustentado", "No Sustentado")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub threadResumenNotas()
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim estable = GEstableciento.IdEstablecimiento
        Dim periodo = GetPeriodo(New Date(cboAnio.Text, cboMesCompra.SelectedValue, 1), True)
        Dim thread As System.Threading.Thread =
            New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(estable, periodo)))
        thread.Start()
    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        threadResumenNotas()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgPedidos.TopLevelGroupOptions.ShowFilterBar = True
            dgPedidos.NestedTableGroupOptions.ShowFilterBar = True
            dgPedidos.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgPedidos.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgPedidos.OptimizeFilterPerformance = True
            dgPedidos.ShowNavigationBar = True
            filter.WireGrid(dgPedidos)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgPedidos)
            dgPedidos.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            'Dim f As New frmVentaNuevoFormato(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
            'Dim f As New FormVentaGeneral(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
            'f.btGrabar.Enabled = False
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
            Dim f As New FormViewVentaGeneral(dgPedidos.Table.CurrentRecord.GetValue("idDocumento")) '
            ' f.GroupBarMKT.Visible = True
            f.btGrabar.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim r As Record = dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim statusSustentado = r.GetValue("sustentado")
            If statusSustentado = "No Sustentado" Then

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                    Dim FormGenerarComprobanteVenta As New FormGenerarComprobanteVenta(GetDocumentoNotaID(r.GetValue("idDocumento")), Me)
                    FormGenerarComprobanteVenta.StartPosition = FormStartPosition.CenterParent
                    FormGenerarComprobanteVenta.ShowDialog(Me)
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("La nota de venta ya fue sustentada", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Public Function GetDocumentoNotaID(ID As Integer) As documento
        Dim documentoSA As New DocumentoSA
        Dim documentoventaSA As New documentoVentaAbarrotesSA
        Dim documentoventaDetSA As New documentoVentaAbarrotesDetSA

        Dim documento = documentoSA.UbicarDocumento(ID)
        Dim documentoventaNota = documentoventaSA.GetUbicar_documentoventaAbarrotesPorID(ID)

        GetDocumentoNotaID = New documento
        GetDocumentoNotaID = documento
        GetDocumentoNotaID.documentoventaAbarrotes = documentoventaNota
        'GetDocumentoNotaID.documentoventaAbarrotes.documentoventaAbarrotesDet = documentoventaDetSA.usp_EditarDetalleVenta(ID)
        GetDocumentoNotaID.documentoventaAbarrotes.documentoventaAbarrotesDet = documentoventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(ID)
    End Function

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            'f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")
            'f.StartPosition = FormStartPosition.CenterScreen
            '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.Show(Me)
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    End Sub
#End Region
End Class
