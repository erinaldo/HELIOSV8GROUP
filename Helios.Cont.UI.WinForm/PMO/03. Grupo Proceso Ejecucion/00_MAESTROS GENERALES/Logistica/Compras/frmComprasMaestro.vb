Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GridHelperClasses
Public Class frmComprasMaestro

#Region "Attributes"
    Dim Alert As Alert
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Public Property CompraSA As New DocumentoCompraSA
    Public Property CompraDetSA As New DocumentoCompraDetalleSA
    Dim listaMeses As New List(Of MesesAnio)
    Dim cajaUsuario As New cajaUsuario
    Dim cajaUsuarioSA As New cajaUsuarioSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property empresaAnioSA As New empresaPeriodoSA
    Public Property fso As New FeedbackForm
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvCompras)
        Meses()
        ValidandoModulos()
        ClipBoardDocumento = New documento
    End Sub


#End Region

#Region "Methods"
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
    Private Sub ValidandoModulos()
        If Gempresas.IDProducto = "23" Then ' PosV00
            btCompraCredito.Visible = False
            ComprasAlContadoToolStripMenuItem.Visible = False
            DevolucionDeExistenciasErrorEnCostoOtrosToolStripMenuItem.Visible = True
            BonificacionesRecibidasToolStripMenuItem.Visible = False
            AnulaciònDeGastoFinancierosToolStripMenuItem.Visible = True
            ToolStripButton13.Visible = False
            ToolStripDropDownButton2.Visible = False
            ToolStripDropDownButton1.Visible = False

            RegistroDeHonorariosToolStripMenuItem1.Visible = False
            ImportacionesToolStripMenuItem1.Visible = False
            CompraDeServiciosPúblicosToolStripMenuItem1.Visible = False
        Else
            btCompraCredito.Visible = True

            menuCompraCredito.Visible = False
            ToolStripButton11.Visible = True
            ComprasAlContadoToolStripMenuItem.Visible = False
        End If
        ToolStripButton11.Visible = False
    End Sub
    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompras.DataSource = table
            dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            dgvCompras.TopLevelGroupOptions.ShowCaption = True
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Private Sub getTableComprasPorPeriodoContado(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período: " & strPeriodo & " ")
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

        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add("detraccion")

        If usuario.TieneCaja Then
            DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        Else
            DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo)
        End If

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
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

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = CDec(i.importeTotal).ToString("N2")
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso
            dr(19) = If(i.tieneDetraccion = "S", "Si", "No")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub EliminarReciboHonorario(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
        End With
        documentoSA.DeleteReciboHonorario(objDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        Alert = New Alert("Compra eliminada", alertType.info)
        Alert.TopMost = True
        Alert.Show()
        dgvCompras.Refresh()
    End Sub

    Public Sub EliminarServicioPublico(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
        End With
        documentoSA.DeleteReciboHonorario(objDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        Alert = New Alert("Compra eliminada", alertType.info)
        Alert.TopMost = True
        Alert.Show()
        dgvCompras.Refresh()
    End Sub

    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        Dim notaCredito As documentocompra
        Try
            notaCredito = compraSA.UbicarDocumentoCompra(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' Compra
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoNuevo(objDocumento)
            Me.dgvCompras.Table.CurrentRecord.Delete()
            Alert = New Alert("Nota credito eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            dgvCompras.Refresh()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarNotaCreditoBonificacion(intIdDocumentoNota As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        Dim notaCredito As documentocompra
        Try
            notaCredito = compraSA.UbicarDocumentoCompra(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                ' .IdDocumentoAfectado = notaCredito.idPadre ' Compra
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoBonificacion(objDocumento)
            Me.dgvCompras.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
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

    Public Sub EliminarDebito(intIdDocumentoNota As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        Dim notaDebito As documentocompra
        Try
            notaDebito = compraSA.UbicarDocumentoCompra(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaDebito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
                .ImporteMN = dgvCompras.Table.CurrentRecord.GetValue("importeTotal")
                .ImporteME = dgvCompras.Table.CurrentRecord.GetValue("importeUS")
            End With
            compraSA.EliminarNotaDebitoMetodoNuevo(objDocumento)
            Me.dgvCompras.Table.CurrentRecord.Delete()
            Alert = New Alert("Nota debito eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            dgvCompras.Refresh()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub Meses()

        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral
    End Sub

    Sub ElimnarDoc()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            If dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA Then
                EliminarCompraGeneral()
            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS Then
                EliminarReciboHonorario(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO Then
                EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO Then
                EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA Then
                EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_CREDITO Then
                EliminarNota(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_DEBITO Then
                EliminarDebito(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS Then
                '      EliminarNotaCreditoBonificacion(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            End If
        End If
    End Sub

    Private Sub EliminarCompraGeneral()
        Dim compraSA As New DocumentoCompraSA
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            compraSA.EliminarCompra(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Compra eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            dgvCompras.Refresh()
        End If
    End Sub

#End Region

#Region "Events"
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        Dim CompraDetSA As New DocumentoCompraDetalleSA
        If Not IsNothing(r) Then
            ClipBoardDocumento = New documento
            ClipBoardDocumento.documentocompra = CompraSA.UbicarDocumentoCompra(Val(r.GetValue("idDocumento")))
            Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
            ClipBoardDocumento.documentocompra.documentocompradetalle = listaDetalle
            MessageBox.Show("Comprobante copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
            dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
            dgvCompras.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCompras.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCompras.OptimizeFilterPerformance = True
            dgvCompras.ShowNavigationBar = True
            filter.WireGrid(dgvCompras)
        Else
            filter.ClearFilters(dgvCompras)
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasServiciosToolStripMenuItem1.Click

    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem1.Click

    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem1.Click

    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasServiciosToolStripMenuItem2.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If cboMesCompra.Text.Trim.Length > 0 Then
                'Dim valida = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboanio.text, .mes = CInt(cboMesCompra.SelectedValue)})

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmComprasContado
                        .CaptionLabels(0).Text = "Compra al contado"
                        .Label40.Visible = False
                        .ComboBoxAdv2.Visible = False
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                        .cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
                        .cboMesCompra.Enabled = True
                        .txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Normal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        ButtonAdv6_Click(sender, e)
                    End With
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem2.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmServicioPublicoContado
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                        .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        .WindowState = FormWindowState.Normal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        ButtonAdv6_Click(sender, e)
                    End With
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem2.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmReciboHonorariosContado
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                        .WindowState = FormWindowState.Normal
                        .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        ButtonAdv6_Click(sender, e)
                    End With
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub CompraAnticipadaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompraAnticipadaToolStripMenuItem1.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmCompraAnticipada
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                        .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        .WindowState = FormWindowState.Normal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        ButtonAdv6_Click(sender, e)
                    End With
                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub DevolucionDeExistenciasErrorEnCostoOtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionDeExistenciasErrorEnCostoOtrosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                If TieneExistenciasEntransito = True Then
                    MessageBoxAdv.Show("La compra tiene existencias en tránsito" & vbCrLf & _
                                       "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBoxAdv.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then
                                LoadingAnimator.Wire(dgvCompras.TableControl)
                                Dim f As New frmCreditoCompra(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                                f.ShowDialog()
                                ButtonAdv6_Click(sender, e)
                                LoadingAnimator.UnWire(dgvCompras.TableControl)
                            End If
                        Else
                            LoadingAnimator.Wire(dgvCompras.TableControl)
                            Dim f As New frmCreditoCompra(CInt(r.GetValue("idDocumento")))
                            f.Size = New Size(1105, 670)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                            f.ShowDialog()
                            ButtonAdv6_Click(sender, e)
                            LoadingAnimator.UnWire(dgvCompras.TableControl)
                        End If
                        'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                End Select
            Else
                MessageBox.Show("Seleccionar una compra para realizar esta operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BonificacionesRecibidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonificacionesRecibidasToolStripMenuItem.Click
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                MessageBox.Show("Seleccionar una compra para realizar esta operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmNotaCreditoBonificaciones
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub NotaDeCréditoEspecialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCréditoEspecialToolStripMenuItem.Click
        'Cursor = Cursors.WaitCursor
        Try
            GetModalWait()

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                '   LoadingAnimator.UnWire(dgvCompras.TableControl)
                '  Cursor = Cursors.Default
                fso.Dispose()
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '  LoadingAnimator.UnWire(dgvCompras.TableControl)
                    '     Cursor = Cursors.Default
                    fso.Dispose()
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                If TieneExistenciasEntransito = True Then
                    MessageBoxAdv.Show("La compra tiene existencias en tránsito" & vbCrLf & _
                                       "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '  LoadingAnimator.UnWire(dgvCompras.TableControl)
                    '   Cursor = Cursors.Default
                    fso.Dispose()
                    Exit Sub
                End If
                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBoxAdv.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        fso.Dispose()
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            fso.Dispose()
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then
                                GetModalWait()
                                Dim f As New frmCreditoCompraEspecial(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                                fso.Dispose()
                                f.ShowDialog()
                                ButtonAdv6_Click(sender, e)
                                '      LoadingAnimator.UnWire(dgvCompras.TableControl)
                            End If
                        Else
                            '    GetModalWait()
                            Dim f As New frmCreditoCompraEspecial(CInt(r.GetValue("idDocumento")))
                            f.Size = New Size(1105, 670)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                            fso.Dispose()
                            f.ShowDialog()
                            ButtonAdv6_Click(sender, e)
                            'LoadingAnimator.UnWire(dgvCompras.TableControl)
                        End If
                        'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                End Select
            Else
                MessageBox.Show("Seleccionar una compra para realizar esta operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        '      Cursor = Cursors.Default
    End Sub

    Private Sub NotaDeDébitoEspecialNuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeDébitoEspecialNuevoToolStripMenuItem.Click
        GetModalWait()
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                '    LoadingAnimator.UnWire(dgvCompras.TableControl)
                '    Cursor = Cursors.Default
                fso.Dispose()
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '       LoadingAnimator.UnWire(dgvCompras.TableControl)
                    '      Cursor = Cursors.Default
                    fso.Dispose()
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                If TieneExistenciasEntransito = True Then
                    MessageBoxAdv.Show("La compra tiene existencias en tránsito" & vbCrLf &
                                       "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    fso.Dispose()
                    '    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBoxAdv.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        fso.Dispose()
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            fso.Dispose()
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then
                                GetModalWait()
                                Dim f As New frmNotaDebitoEspecial(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                                fso.Dispose()
                                f.ShowDialog()
                                ButtonAdv6_Click(sender, e)

                            End If
                        Else
                            '   GetModalWait()
                            Dim f As New frmNotaDebitoEspecial(CInt(r.GetValue("idDocumento")))
                            f.Size = New Size(1105, 670)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                            fso.Dispose()
                            f.ShowDialog()
                            ButtonAdv6_Click(sender, e)
                            '   LoadingAnimator.UnWire(dgvCompras.TableControl)
                        End If
                        'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                End Select
            Else
                MessageBox.Show("Seleccionar una compra para realizar esta operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        '   Cursor = Cursors.Default
    End Sub

    Private Sub AnulaciònDeGastoFinancierosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnulaciònDeGastoFinancierosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBoxAdv.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then
                                If result.tieneGasto = "SI" Then
                                    LoadingAnimator.Wire(dgvCompras.TableControl)
                                    Dim f As New frmDevolucionDebito(CInt(r.GetValue("idDocumento")))
                                    f.Size = New Size(1105, 670)
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                                    f.ShowDialog()
                                    ButtonAdv6_Click(sender, e)
                                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                                End If
                            End If
                        Else
                            LoadingAnimator.Wire(dgvCompras.TableControl)
                            Dim f As New frmDevolucionDebito(CInt(r.GetValue("idDocumento")))
                            f.Size = New Size(1105, 670)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                            f.ShowDialog()
                            ButtonAdv6_Click(sender, e)
                            LoadingAnimator.UnWire(dgvCompras.TableControl)
                        End If
                        'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                End Select
            Else
                MessageBox.Show("Seleccionar una compra para realizar esta operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                If TieneExistenciasEntransito = True Then
                    MessageBoxAdv.Show("La compra tiene existencias en tránsito" & vbCrLf & _
                                       "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBoxAdv.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then
                                LoadingAnimator.Wire(dgvCompras.TableControl)
                                Dim f As New frmNotasDebito(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                                f.ShowDialog()
                                ButtonAdv6_Click(sender, e)
                                LoadingAnimator.UnWire(dgvCompras.TableControl)
                            End If
                        Else
                            LoadingAnimator.Wire(dgvCompras.TableControl)
                            Dim f As New frmNotasDebito(CInt(r.GetValue("idDocumento")))
                            f.Size = New Size(1105, 670)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                            f.ShowDialog()
                            ButtonAdv6_Click(sender, e)
                            LoadingAnimator.UnWire(dgvCompras.TableControl)
                        End If
                        'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        With frmCrearENtidades
            .CaptionLabels(0).Text = "Nuevo proveedor"
            .strTipo = TIPO_ENTIDAD.PROVEEDOR
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.intIdEntidad = Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
            '.UbicarEntidad(Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        '    LoadingAnimator.Wire(dgvCompras.TableControl)
        If dgvCompras.Table.Records.Count > 0 Then
            If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                GetModalWait()
                Select Case Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.COMPRA, TIPO_COMPRA.COMPRA_PAGADA
                        Dim f As New frmCompras(Integer.Parse(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))) 'frmEditcompra(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.StartPosition = FormStartPosition.CenterParent
                        fso.Dispose()
                        f.ShowDialog()
                    Case TIPO_COMPRA.NOTA_DEBITO
                        Dim f As New frmViewNotaDebito(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.StartPosition = FormStartPosition.CenterParent
                        fso.Dispose()
                        f.ShowDialog()

                    Case TIPO_COMPRA.NOTA_CREDITO
                        Dim f As New frmViewNota(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    Case TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
                        Dim f As New frmNotaCreditoBonificaciones(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        fso.Dispose()
                        f.ShowDialog()
                    Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                        Dim f As New frmReciboHonorarios(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        fso.Dispose()
                        f.ShowDialog()
                    Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
                        Dim f As New frmServicioPublico(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        fso.Dispose()
                        f.ShowDialog()

                    Case TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO 'FALTA METODO ELIMINAR
                        Dim f As New frmCompraAnticipada(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        fso.Dispose()
                        f.ShowDialog()

                    Case TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA  'FALTA METODO ELIMINAR
                        Dim f As New frmCompraAnticipada(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        fso.Dispose()
                        f.ShowDialog()
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        '    LoadingAnimator.UnWire(dgvCompras.TableControl)

    End Sub

    Private Sub GetModalWait()
        fso = New FeedbackForm
        fso.StartPosition = FormStartPosition.CenterScreen
        fso.TopMost = True
        fso.Show()
        Me.ResumeLayout(True)
        fso.Refresh()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
        Try
            If dgvCompras.Table.Records.Count > 0 Then
                If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea eliminar la compra seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        ElimnarDoc()
                    End If
                End If
            End If
        Catch ex As Exception
            If ex.Message = "ETEA" Then
                '        Alert = New Alert("Tiene produtos relacionados a otros almacenes", alertType.Errors)
                MsgBox("Tiene productos relacionados a otros almacenes", MsgBoxStyle.Critical, "Verificar documentos")
            Else
                Alert = New Alert(ex.Message, alertType.Errors)
                Alert.TopMost = True
                Alert.Show()
            End If

        End Try
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, periodo)))
        thread.Start()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Try
            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim f As New frmCambiarPeriodo2(New documentocompra With {.idDocumento = Val(r.GetValue("idDocumento"))})
                f.operacion = StatusTipoOperacion.COMPRA
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                ButtonAdv6_Click(sender, e)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            'Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvCompras.TableControl.Selections.Clear()
        End If

        If Not IsNothing(e.TableCellIdentity.Column) Then
            'Dim el As Element = e.TableCellIdentity.DisplayElement

            'If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipoCompra")) Then
            '    If Not IsNothing(dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue) Then
            '        Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            '        Select Case str
            '            Case TIPO_COMPRA.COMPRA
            '                e.Style.CellValue = "Compra"
            '            Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
            '                e.Style.CellValue = "Servicio público"
            '            Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
            '                e.Style.CellValue = "Recibo honorario"
            '            Case TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO
            '                e.Style.CellValue = "Anticipo"
            '            Case TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
            '                e.Style.CellValue = "Anticipo"
            '            Case TIPO_COMPRA.NOTA_CREDITO
            '                e.Style.CellValue = "Nota credito"
            '            Case TIPO_COMPRA.NOTA_DEBITO
            '                e.Style.CellValue = "Nota debito"
            '            Case TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
            '                e.Style.CellValue = "Bonificación"
            '        End Select
            '    End If
            'Else
            '    'e.Style.[ReadOnly] = False
            'End If
        End If

    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                CompraSA.GetChangeState(New documentocompra With {.idDocumento = dgvCompras.Table.CurrentRecord.GetValue("idDocumento"), .situacion = statusComprobantes.Observado})
                ButtonAdv6_Click(sender, e)
            Else
                MessageBox.Show("Debe seleccionar un comprobante valido", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                CompraSA.GetChangeState(New documentocompra With {.idDocumento = dgvCompras.Table.CurrentRecord.GetValue("idDocumento"), .situacion = statusComprobantes.Normal})
            Else
                MessageBox.Show("Debe seleccionar un comprobante valido", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub ImportacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImportacionesToolStripMenuItem1.Click

    End Sub

    Private Sub AsignarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            CompraSA = New DocumentoCompraSA
            Dim codigoDocumento As Integer = Integer.Parse(r.GetValue("idDocumento"))
            CompraSA.GetDetraccionChangeStateByDocumento(New documentocompra With {
                                                         .idDocumento = codigoDocumento,
                                                         .tieneDetraccion = "S"})
            dgvCompras.Table.CurrentRecord.Delete()
        Else
            MessageBoxAdv.Show("Debe seleccionar un fila", "Validar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub menuCompraCredito_Click(sender As Object, e As EventArgs) Handles menuCompraCredito.Click

        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim f As New frmCompras
            f.ComboBoxAdv2.Visible = False
            'f.CaptionLabels(0).Text = "Compra al crédito"
            f.CaptionLabels(0).Text = "Compra"
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
            f.cboMesCompra.Enabled = True
            'f.txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()
            ButtonAdv6_Click(sender, e)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub CompraDeExistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasToolStripMenuItem.Click
        'LoadingAnimator.Wire(dgvCompras.TableControl)
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim f As New frmCompras
            f.ComboBoxAdv2.Visible = False
            f.CaptionLabels(0).Text = "Compra al crédito"
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
            f.cboMesCompra.Enabled = True
            'f.txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()
            ButtonAdv6_Click(sender, e)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        '   LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim f As New frmServicioPublico
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv6_Click(sender, e)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        Try
            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim f As New frmReciboHonorarios
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
            f.WindowState = FormWindowState.Normal
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()
            ButtonAdv6_Click(sender, e)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles btAsignarGasto.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then

            Select Case r.GetValue("tipoCompra")
                Case TIPO_COMPRA.COMPRA
                    Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
                    fechaAnt = fechaAnt.AddMonths(-1)
                    Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                    If periodoAnteriorEstaCerrado = False Then
                        MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If

                    Dim ListaCompra = CompraDetSA.GetUbicarDetalleCompraLote(Integer.Parse(r.GetValue("idDocumento")))
                    Dim f As New frmCompras(0, ListaCompra)
                    f.ComboBoxAdv2.Visible = False
                    f.CaptionLabels(0).Text = "Compra al crédito"
                    f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                    f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
                    f.cboMesCompra.Enabled = True
                    'f.txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.ShowDialog()

                Case Else

            End Select


        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub dgvCompras_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompras.SelectedRecordsChanging
        If e.SelectedRecord IsNot Nothing Then
            btAsignarGasto.Enabled = True
        Else
            btAsignarGasto.Enabled = False
        End If
    End Sub

    Private Sub PercepciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PercepciónToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                LoadingAnimator.UnWire(dgvCompras.TableControl)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                If TieneExistenciasEntransito = True Then
                    MessageBoxAdv.Show("La compra tiene existencias en tránsito" & vbCrLf &
                                       "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBoxAdv.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then
                                LoadingAnimator.Wire(dgvCompras.TableControl)
                                Dim f As New frmPercepcionNew(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                                f.ShowDialog()
                                ButtonAdv6_Click(sender, e)
                                LoadingAnimator.UnWire(dgvCompras.TableControl)
                            End If
                        Else
                            LoadingAnimator.Wire(dgvCompras.TableControl)
                            Dim f As New frmPercepcionNew(CInt(r.GetValue("idDocumento")))
                            f.Size = New Size(1105, 670)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                            f.ShowDialog()
                            ButtonAdv6_Click(sender, e)
                            LoadingAnimator.UnWire(dgvCompras.TableControl)
                        End If
                        'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub


#End Region

End Class