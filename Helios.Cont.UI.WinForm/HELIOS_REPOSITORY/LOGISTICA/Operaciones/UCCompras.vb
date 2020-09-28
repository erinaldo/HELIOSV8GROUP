Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter

Public Class UCCompras

#Region "Attributes"
    Dim filter As New GridExcelFilter()
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property Logistica As UCLogisticaCompra
    Dim Alert As Alert
    Public Property CompraSA As New DocumentoCompraSA
    Private entidadSA As New entidadSA
#End Region

#Region "Constructors"
    Public Sub New(UCLogisticaCompra As UCLogisticaCompra)

        ' This call is required by the designer.
        InitializeComponent()
        Logistica = UCLogisticaCompra
        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Enabled = True
        txtFecha.Value = Date.Now
        FormatoGridAvanzado(dgvCompras, True, False, 9.0F, SelectionMode.MultiExtended)
        OrdenamientoGrid(dgvCompras, False)
        dgvCompras.GridGroupDropArea.DragColumnHeaderText = "Arrastre un encabezado de columna aquí para agrupar por esa columna."
    End Sub
#End Region

#Region "Entidad"
    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim consulta = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, txtFiltrar.Text)

            If consulta.Count > 0 Then
                'consulta.AddRange(consulta)
                FillLSVClientes(consulta)
                Me.pcLikeCategoria.Size = New Size(282, 128)
                Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                e.Handled = True
            End If

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then

                txtFiltrar.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                txtFiltrar.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtFiltrar.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, txtFiltrar.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub
#End Region


#Region "Methods"
    Private Sub GetComprasPorCriterio(PeriodoSel As String, intIdEstable As Integer, serie As String, numero As String, idproveedor As String, Opcion As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim ListaCompras As List(Of documentocompra)
        Dim obj As documentocompra = Nothing

        Dim dt As New DataTable("Búsqueda por criterio")
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


        Select Case Opcion
            Case "PROVEEDOR"
                obj = New documentocompra With
                {
                .idCentroCosto = intIdEstable,
                .fechaContable = PeriodoSel,
                .idProveedor = idproveedor,
                .terminos = Opcion
                }

            Case "COMPROBANTE"
                Dim tipodoc As String
                If ToggleComprobante.ToggleState = ToggleButton2.ToggleButtonState.ON Then 'factura
                    tipodoc = "01"
                Else
                    tipodoc = "03"
                End If

                obj = New documentocompra With
                {
                .idCentroCosto = intIdEstable,
                .fechaContable = PeriodoSel,
                .tipoDoc = tipodoc,
                .serie = serie,
                .numeroDoc = numero,
                .terminos = Opcion
                }
        End Select

        ListaCompras = DocumentoCompraSA.GetComprasCriterio(obj).Where(Function(o) o.tipoCompra <> TIPO_COMPRA.COMPRA_ANULADA).ToList

        Dim str As String
        For Each i As documentocompra In ListaCompras
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
        SetDatasourceCompra(dt)
    End Sub

    Private Sub FiltrarCompras(text As String)
        'Select Case text
        '    Case "CLIENTE"
        Dim numero = textNumCompra.DecimalValue
        Dim serie = textSerieCompra.DecimalValue
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetComprasPorCriterio(GetPeriodo(txtFecha.Value, True), GEstableciento.IdEstablecimiento, serie, numero, txtFiltrar.Tag, text)))
        thread.Start()
        '    Case "COMPROBANTE"

        'End Select
    End Sub

    Public Sub SetDatasourceCompra(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf SetDatasourceCompra)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompras.DataSource = table
            dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            dgvCompras.TopLevelGroupOptions.ShowCaption = True
            PictureLoad.Visible = False
            PictureLoad2.Visible = False
            BunifuFlatButton5.Enabled = True
        End If
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

    Sub ElimnarDoc()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            If dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA Then
                EliminarCompraGeneral()
            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS Then
                '  EliminarReciboHonorario(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO Then
                '  EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO Then
                ' EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA Then
                ' EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_CREDITO Then
                ' EliminarNota(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_DEBITO Then
                ' EliminarDebito(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS Then
                '      EliminarNotaCreditoBonificacion(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            End If
        End If
    End Sub

    Private Sub GetComprasPorMes(PeriodoSel As String, intIdEstable As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim ListaCompras As List(Of documentocompra)

        Dim dt As New DataTable("Período: " & PeriodoSel & " ")
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

        dt.Columns.Add("bi01")
        dt.Columns.Add("bi02")
        dt.Columns.Add("igv")

        ListaCompras = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO((New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = intIdEstable, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}), PeriodoSel).Where(Function(o) o.tipoCompra <> TIPO_COMPRA.COMPRA_ANULADA).ToList

        Dim str As String
        For Each i As documentocompra In ListaCompras
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

            dr(21) = i.bi01
            dr(22) = i.bi02
            dr(23) = i.igv01

            dt.Rows.Add(dr)
        Next
        SetDatasourceCompra(dt)
    End Sub

    Private Sub GetComprasPorDia(fechaSel As Date?, idEstablecimiento As Integer?)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim ListaCompras As List(Of documentocompra)

        Dim dt As New DataTable("Día: " & fechaSel & " ")
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

        ListaCompras = DocumentoCompraSA.GetListarComprasPorDia_CONT(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = idEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA, .fechaDoc = fechaSel}).Where(Function(o) o.tipoCompra <> TIPO_COMPRA.COMPRA_ANULADA).ToList

        Dim str As String
        For Each i As documentocompra In ListaCompras
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
        SetDatasourceCompra(dt)
    End Sub

#End Region

#Region "Events"
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetComprasPorMes(GetPeriodo(periodoSel, True), GEstableciento.IdEstablecimiento)))
            thread.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR_ANULAR_Botón___, AutorizacionRolList) Then
            If dgvCompras.Table.Records.Count > 0 Then
                If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea eliminar el registro seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        ElimnarDoc()
                    End If
                End If
            End If
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If

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



    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        ' If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.COMPRA_VINCULADA_Botón___, AutorizacionRolList) Then
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
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim FechaSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetComprasPorDia(FechaSel, GEstableciento.IdEstablecimiento)))
            thread.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormCrearCompra(Integer.Parse(r.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
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
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NOTA_DE_CREDITO_Formulario___, AutorizacionRolList) Then
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            Try
                ' If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_NOTA_DE_CREDITO_Botón___, AutorizacionRolList) Then
                ' Dim r As Record = dgvCompras.Table.CurrentRecord
                '  If Not IsNothing(r) Then
                Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                If TieneExistenciasEntransito = True Then
                    MessageBox.Show("La compra tiene existencias en tránsito" & vbCrLf &
                                               "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(dgvCompras.TableControl)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                Select Case compra.tipoDoc
                    Case "07", "08", "87", "88"
                        MessageBox.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Case Else

                        Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                        If ListadoReferencias.Count > 0 Then
                            Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                            frm.StartPosition = FormStartPosition.CenterParent
                            frm.ShowDialog()
                            Dim result = CType(frm.Tag, InfoNotas)
                            If result.seguirOperaion = "SI" Then

                                Dim f As New FormNotaCreditoCompras(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog()

                            End If
                        Else



                            Dim f As New FormNotaCreditoCompras(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                            'Dim f As New FrmPurchaseCreditNote(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                            'f.StartPosition = FormStartPosition.CenterParent
                            'f.ShowDialog()

                        End If

                End Select

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Try
            PictureLoad2.Visible = True
            FiltrarCompras(ComboBoxAdv1.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
            PictureLoad2.Visible = False
            PictureLoad.Visible = False
        End Try
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub

    Private Sub ComboBoxAdv1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedValueChanged
        If ComboBoxAdv1.Text = "PROVEEDOR" Then
            txtFecha.Visible = True
            RadioButton1.Visible = True
            RadioButton2.Visible = True
            LabelNumeroventa.Visible = False
            textNumCompra.Visible = False
            textSerieCompra.Visible = False
            ToggleComprobante.Visible = False
            Label2.Visible = False
            '    TextImporte.Visible = False
            Label3.Visible = False
            txtFiltrar.Visible = True
        ElseIf ComboBoxAdv1.Text = "COMPROBANTE" Then
            txtFecha.Visible = False
            RadioButton1.Visible = False
            RadioButton2.Visible = False

            LabelNumeroventa.Visible = True
            textNumCompra.Visible = True
            textSerieCompra.Visible = True
            ToggleComprobante.Visible = True
            '    TextImporte.Visible = True
            Label3.Visible = False
            Label2.Visible = True
            txtFiltrar.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormCompraAfecto(Integer.Parse(r.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvCompras, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Exportar Registro de Ventas a un archivo excel ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub


#End Region

End Class
