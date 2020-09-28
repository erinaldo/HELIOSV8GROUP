Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.Data.Entity.DbFunctions
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class TabLG_RegistroCompras
    Private periodoSel As String
    Private empresaPeriodoSA As New empresaCierreMensualSA
    Private anioSel As String
    Private mesSel As String
    Dim CompraSA As New DocumentoCompraSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property fso As New FeedbackForm
    Dim Alert As Alert

    Public Sub New(periodo As String, anio As Integer, mes As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGrid(dgvCompras)
        periodoSel = periodo
        anioSel = anio
        mesSel = mes
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, periodo)))
        thread.Start()
    End Sub

    ''' <summary>
    ''' Compras por día
    ''' </summary>
    ''' <param name="periodo"></param>
    Public Sub New(periodo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGrid(dgvCompras)
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() getComprasdia(GEstableciento.IdEstablecimiento, periodo)))
        thread.Start()
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

    Private Sub GetModalWait()
        fso = New FeedbackForm
        fso.StartPosition = FormStartPosition.CenterScreen
        fso.TopMost = True
        fso.Show()
        Me.ResumeLayout(True)
        fso.Refresh()
    End Sub

    Private Sub EliminarCompraGeneral()
        Dim compraSA As New DocumentoCompraSA
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            compraSA.AnularCompra(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Compra eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            dgvCompras.Refresh()
        End If
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
        dt.Columns.Add("relacionado")
        DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo).Where(Function(o) o.tipoCompra <> TIPO_COMPRA.COMPRA_ANULADA).ToList

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
            If i.idPadre IsNot Nothing Then
                dr(20) = "SI"
            Else
                dr(20) = "NO"
            End If
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub getComprasdia(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período: " & strPeriodo & " ")
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

        DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo).Where(Function(o) o.fechaDoc.Value.Year = DateTime.Now.Date.Year And
                                                                                                                                       o.fechaDoc.Value.Month = DateTime.Now.Date.Month And
                                                                                                                                       o.fechaDoc.Value.Day = DateTime.Now.Date.Day).ToList

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

    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvCompras.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Cursor = Cursors.WaitCursor
        Try
            'Dim fechaAnt = New Date(anioSel, mesSel, 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    LoadingAnimator.UnWire(dgvCompras.TableControl)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = anioSel, .mes = CInt(mesSel)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        LoadingAnimator.UnWire(dgvCompras.TableControl)
            '        Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_NOTA_DE_CREDITO_Botón___, AutorizacionRolList) Then
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
                                    Dim f As New frmCreditoCompra(CInt(r.GetValue("idDocumento")))
                                    f.Size = New Size(1105, 670)
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.lblPerido.Text = mesSel & "/" & anioSel
                                    f.ShowDialog()
                                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                                End If
                            Else
                                LoadingAnimator.Wire(dgvCompras.TableControl)
                                Dim f As New frmCreditoCompra(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = mesSel & "/" & anioSel
                                f.ShowDialog()
                                LoadingAnimator.UnWire(dgvCompras.TableControl)
                            End If
                            'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                    End Select
                Else
                    MessageBox.Show("Seleccionar una compra para realizar esta operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Cursor = Cursors.WaitCursor
        Try

            'Dim fechaAnt = New Date(anioSel, (mesSel), 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    LoadingAnimator.UnWire(dgvCompras.TableControl)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = anioSel, .mes = CInt(mesSel)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        LoadingAnimator.UnWire(dgvCompras.TableControl)
            '        Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_NOTA_DE_DEBITO_Botón___, AutorizacionRolList) Then
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
                                    Dim f As New frmNotasDebito(CInt(r.GetValue("idDocumento")))
                                    f.Size = New Size(1105, 670)
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.lblPerido.Text = mesSel & "/" & anioSel
                                    f.ShowDialog()
                                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                                End If
                            Else
                                LoadingAnimator.Wire(dgvCompras.TableControl)
                                Dim f As New frmNotasDebito(CInt(r.GetValue("idDocumento")))
                                f.Size = New Size(1105, 670)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.lblPerido.Text = mesSel & "/" & anioSel
                                f.ShowDialog()
                                LoadingAnimator.UnWire(dgvCompras.TableControl)
                            End If
                            'Dim f As New frmNotaCreditoEspecial(CInt(r.GetValue("idDocumento")))
                    End Select
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        '    LoadingAnimator.Wire(dgvCompras.TableControl)
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_Botón___, AutorizacionRolList) Then
            If dgvCompras.Table.Records.Count > 0 Then
                If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                    GetModalWait()
                    Select Case Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_COMPRA.COMPRA, TIPO_COMPRA.COMPRA_PAGADA
                            Dim f As New FormCompras(Integer.Parse(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))) 'frmEditcompra(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
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
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR_ANULAR_Botón___, AutorizacionRolList) Then
                If dgvCompras.Table.Records.Count > 0 Then
                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar el registro seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDoc()
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
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
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvCompras)
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = False
        End If

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NOTA_DE_CREDITO_Formulario___, AutorizacionRolList) Then
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If r IsNot Nothing Then
                If r.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA Then
                    Dim FormComprasRelacionadas As New FormComprasRelacionadas(Integer.Parse(r.GetValue("idDocumento")))
                    FormComprasRelacionadas.StartPosition = FormStartPosition.CenterScreen
                    FormComprasRelacionadas.Show(Me)
                End If
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.COMPRA_VINCULADA_Botón___, AutorizacionRolList) Then
            Dim r As Record = dgvCompras.Table.CurrentRecord
            Dim CompraDetSA As New DocumentoCompraDetalleSA
            If Not IsNothing(r) Then
                ClipBoardDocumento = New documento
                ClipBoardDocumento.documentocompra = CompraSA.UbicarDocumentoCompra(Val(r.GetValue("idDocumento")))
                'Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
                Dim listaDetalle = CompraDetSA.GetUbicarDetalleCompraLote(Val(r.GetValue("idDocumento")))
                ClipBoardDocumento.documentocompra.documentocompradetalle = listaDetalle
                MessageBox.Show("Comprobante copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
