Imports System.IO
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabPedidoPiscina_EP
    Implements IForm2

    Public InfraestructuraID As Integer
    Protected Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property documentoVenta As documentoventaAbarrotes
    Public Property documentoVentaDetalle As List(Of documentoPedidoDet)
    Public Alert As Alert
    Dim lis As New ListBox
    Dim lvitem As ListViewItem
    Private Const FormatoFecha As String = "hh-mm-ss"
    Dim listaInfraestructura As New List(Of infraestructura)
    Public Property listaClientes As New List(Of entidad)
    Dim thread As System.Threading.Thread
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))
    Private chk As Boolean, check As Boolean = False
    Public Property documentoPedidoXconfirmar As List(Of documentoPedidoDet)
    Public Property TipoEntregaPedido As String = String.Empty
    Private ht As New ArrayList()
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvPedidoDetalle, False, False, 11.5F)

        GetTableGridPedido()
        threadClientes()
    End Sub


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
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

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        Dispose()
    End Sub
#End Region

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

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        'Dim varios = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty)
        ''Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        'lista.Add(varios)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateEntidad(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista

            'txtruc.Text = lista(0).nrodoc
            'TXTcOMPRADOR.Tag = lista(0).idEntidad
            'TXTcOMPRADOR.Text = lista(0).nombreCompleto
            'TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            'txtruc.Visible = True

            'ProgressBar1.Visible = False
        End If
    End Sub

    Sub GetTableGridPedido()
        Dim dt As New DataTable()
        FormatoGridAvanzado(dgvPedidoDetalle, False, False, 9.0F)
        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("puKardex", GetType(Decimal))
        dt.Columns.Add("pukardeme", GetType(Decimal))
        dt.Columns.Add("canDisponible", GetType(Decimal))
        dt.Columns.Add("costoMN", GetType(Decimal))
        dt.Columns.Add("costoME", GetType(Decimal))
        dt.Columns.Add("tipoPrecio", GetType(String))
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cboprecio", GetType(String))
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("MontoPago")
        dt.Columns.Add("MontoSaldo")
        dt.Columns.Add("tipoventa")
        dt.Columns.Add("cantidad2")
        dt.Columns.Add("menor")
        dt.Columns.Add("mayor")
        dt.Columns.Add("gmayor")
        dt.Columns.Add("tipobeneficio")
        dt.Columns.Add("valorbase")
        dt.Columns.Add("valorafecto")
        dt.Columns.Add("totalpagar")
        dt.Columns.Add("chVenta", GetType(String))
        dt.Columns.Add("nroPedido", GetType(String))
        dt.Columns.Add("estado", GetType(String))

        dgvPedidoDetalle.DataSource = dt
    End Sub

    Private Sub AnularItem(secuencia As Integer, iddocumento As Integer)
        Dim documentopedidoSA As New documentoPedidoDetSA
        Dim docPedidoDet As New documentoPedidoDet

        docPedidoDet.idDocumento = iddocumento
        docPedidoDet.IdEmpresa = Gempresas.IdEmpresaRuc
        docPedidoDet.secuencia = secuencia
        docPedidoDet.estadoEntrega = "AN"
        'docPedidoDet.IDInfraestructura = lblInfraestructura.Tag

        'documentopedidoSA.EditarEstadoPedidoXAnulacion(docPedidoDet)

        Alert = New Alert("Anulado", alertType.success)
        Alert.TopMost = True
        Alert.Show()

    End Sub

    Private Sub ActualizarPedidoPendiente()
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet
            documentopedidoBE.listaSecuencia = New List(Of Integer)
            For Each item In dgvPedidoDetalle.Table.Records
                If (item.GetValue("chVenta") = False) Then
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.estadoEntrega = "CT"
                    documentopedidoBE.listaSecuencia.Add(item.GetValue("codigo"))
                    documentopedidoBE.monto1 = item.GetValue("cantidad")
                    documentopedidoBE.idAlmacenOrigen = CInt(item.GetValue("almacen"))
                    documentopedidoBE.DetalleItem = item.GetValue("item")
                    documentopedidoBE.idItem = item.GetValue("idProducto")
                    documentopedidoBE.nombreArea = "I"
                    dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PENDIENTE")
                End If
            Next
            'documentopedidodetSA.EditarEstadoXCambioInv(documentopedidoBE)


            'GetDocumentoPedidoID(txtInfra.Tag)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarPedidoConfirmado()
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet
            documentopedidoBE.listaSecuencia = New List(Of Integer)
            For Each item In dgvPedidoDetalle.Table.Records
                If (item.GetValue("chVenta") = True) Then
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.estadoEntrega = "AT"
                    documentopedidoBE.listaSecuencia.Add(item.GetValue("codigo"))
                    documentopedidoBE.monto1 = item.GetValue("cantidad")
                    documentopedidoBE.idAlmacenOrigen = CInt(item.GetValue("almacen"))
                    documentopedidoBE.DetalleItem = item.GetValue("item")
                    documentopedidoBE.idItem = item.GetValue("idProducto")
                    documentopedidoBE.nombreArea = "D"
                    dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "CONFIRMADO")
                End If
            Next
            'documentopedidodetSA.EditarEstadoXCambioInv(documentopedidoBE)


            'GetDocumentoPedidoID(txtInfra.Tag)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub updateInfraestructuraXMesa(btnMesa1 As Integer, estado As String)
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestrucuturaBE As New infraestructura

        infraestrucuturaBE.idEmpresa = Gempresas.IdEmpresaRuc
        infraestrucuturaBE.idInfraestructura = btnMesa1
        infraestrucuturaBE.estado = estado

        infraestructuraSA.EditarInfraestructuraEstado(infraestrucuturaBE)

    End Sub

    Private Sub ToolImportar_Click(sender As Object, e As EventArgs) Handles ToolImportar.Click
        Try
            dgvPedidoDetalle.Table.Records.DeleteAll()
            TXTcOMPRADOR.Clear()
            TXTcOMPRADOR.Tag = Nothing
            txtmesa.Clear()
            txtmesa.Tag = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Dim pedidoBE As New documentoPedido
        Dim pedidoSA As New documentoPedidoSA

        Try
            If (InfraestructuraID > 0) Then
                If MessageBox.Show("Desea eliminar?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'pedidoBE.idDistribucion = InfraestructuraID
                    pedidoBE.idEmpresa = Gempresas.IdEmpresaRuc
                    pedidoBE.estadoEntrega = "AN"
                    pedidoBE.tipoVenta = "AN"

                    'pedidoSA.UpdatePedidoXInfraestructura(pedidoBE)

                    dgvPedidoDetalle.Table.Records.DeleteAll()
                    If (dgvPedidoDetalle.Table.Records.Count = 0) Then
                        'updateInfraestructuraXMesa(InfraestructuraID, "A")

                    End If


                    'actualizarMesas()
                End If
            Else
                MessageBox.Show("Debe seleccionar una mesa!", "Atención")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Try
            If (InfraestructuraID > 0) Then
                'Dim f As New frmCambiarInfraestructura(InfraestructuraID, cboPiso.SelectedValue, cboBloque.SelectedValue)
                'f.StartPosition = FormStartPosition.CenterScreen
                'f.ShowDialog(Me)
                ''actualizarMesas()

                'lblInfraestructura.Text = ""
                dgvPedidoDetalle.Table.Records.DeleteAll()

            Else
                MessageBox.Show("Debe seleccionar una mesa!", "Atención")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura

        'Dim listaInfraestructuraPiso As New List(Of infraestructura)

        Try
            infraestructuraBE = New infraestructura
            'infraestructuraBE.tipo = "B"
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraFullPedido(infraestructuraBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            Me.pcLikeCategoria.Size = New Size(319, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            'Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})


            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList

            'consulta.AddRange(consulta2)
            FillLSVClientes(consulta2)
            'If consulta.Count <= 1 Then
            '    If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '        Dim f As New frmCrearENtidades(TXTcOMPRADOR.Text)
            '        f.CaptionLabels(0).Text = "Nuevo proveedor"
            '        f.strTipo = TIPO_ENTIDAD.CLIENTE
            '        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog()
            '        If f.Tag IsNot Nothing Then
            '            Dim c = CType(f.Tag, entidad)
            '            TXTcOMPRADOR.Text = c.nombreCompleto
            '            TXTcOMPRADOR.Tag = c.idEntidad
            '            txtruc.Visible = True
            '            txtruc.Text = c.nrodoc
            '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            '            TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            '            listaClientes.Add(c)
            '        End If

            '    End If

            'End If

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})


            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList


            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
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

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    'If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    '    Dim f As New frmCrearENtidades
                    '    f.CaptionLabels(0).Text = "Nuevo cliente"
                    '    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                    '    f.StartPosition = FormStartPosition.CenterParent
                    '    f.ShowDialog()
                    '    If Not IsNothing(f.Tag) Then
                    '        Dim c = CType(f.Tag, entidad)
                    '        listaClientes.Add(c)
                    '        'txtTipoDocClie.Text = c.tipoDoc
                    '        TXTcOMPRADOR.Text = c.nombreCompleto
                    '        txtruc.Text = c.nrodoc
                    '        TXTcOMPRADOR.Tag = c.idEntidad
                    '        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '        txtruc.Visible = True
                    '        TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '    End If
                    'Else
                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                    'txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                    txtruc.Visible = True

                    Select Case TipoEntregaPedido
                        Case "PN"
                            GetDocumentoPedidoXConfirmarID(TXTcOMPRADOR.Tag, "PN")
                        Case "AT"
                            GetDocumentoPedidoXConfirmarID(TXTcOMPRADOR.Tag, "AT")
                    End Select



                    'End If

                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TXTcOMPRADOR.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub GetDocumentoPedidoXConfirmarID(ID As Integer, TipoEntrega As String)
        Dim objDocCompra As New documentoPedidoSA
        Dim objDocCompraDet As New documentoPedidoDetSA
        Dim conteoNumeracio As Integer = 1
        Dim idDocumentoAnt As Integer = 0
        Dim documentoBE As New documentoPedido
        Dim ListaTipoExistencia As New List(Of String)
        'documentoventa = New documentoventaAbarrotes
        documentoVentaDetalle = New List(Of documentoPedidoDet)
        'documentoBE.idDistribucion = ID
        documentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoBE.tipoVenta = "VP"
        documentoBE.estadoEntrega = TipoEntrega
        documentoBE.idCliente = ID

        documentoBE.ListaEstado = New List(Of String)

        documentoBE.ListaEstado.Add(TipoExistencia.ActivoInmovilizado)


        'documentoVentaDetalle = objDocCompraDet.GetUbicar_documentoPedidoxCliente(documentoBE)  ' objDocCompraDet.usp_EditarDetalleVenta(ID)
        If (documentoVentaDetalle.Count > 0) Then
            idDocumentoAnt = documentoVentaDetalle(0).idDocumento
        End If

        'DETALLE DE LA COMPRA
        dgvPedidoDetalle.Table.Records.DeleteAll()
        'GridBeneficios.Table.Records.DeleteAll()
        For Each i In documentoVentaDetalle

            Me.dgvPedidoDetalle.Table.AddNewRecord.SetCurrent()
            Me.dgvPedidoDetalle.Table.AddNewRecord.BeginEdit()
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chPago", True)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("codigo", i.secuencia)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("canDisponible", i.monto1)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("totalmn", i.importeMN)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("totalpagar", i.importeMN)

            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("tipobeneficio", i.tipobeneficio)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("valorbase", i.beneficiobase)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("valorafecto", i.descuentoMN.GetValueOrDefault)


            If (i.estadoEntrega = "PN") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PENDIENTE")
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chVenta", False)
            ElseIf (i.estadoEntrega = "AN") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "ANULADO")
            ElseIf (i.estadoEntrega = "PR") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PREPARANDO")
            ElseIf (i.estadoEntrega = "AT") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "POR CONFIRMAR")
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chVenta", True)
            ElseIf (i.estadoEntrega = "CF") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "CONFIRMADO")
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chVenta", True)
            ElseIf (i.estadoEntrega = "DC") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PRE VENTA")
            End If

            If (idDocumentoAnt <> i.idDocumento) Then
                conteoNumeracio = conteoNumeracio + 1
                idDocumentoAnt = i.idDocumento
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("nroPedido", "Pedido" & conteoNumeracio)
            Else
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("nroPedido", "Pedido" & conteoNumeracio)
            End If


            Me.dgvPedidoDetalle.Table.AddNewRecord.EndEdit()

        Next
        ' btGrabar.Enabled = False


    End Sub

    Public Sub GetDocumentoPedidoXConfirmarXMesa(ID As Integer, TipoEntrega As String)
        Dim objDocCompra As New documentoPedidoSA
        Dim objDocCompraDet As New documentoPedidoDetSA
        Dim conteoNumeracio As Integer = 1
        Dim idDocumentoAnt As Integer = 0
        Dim documentoBE As New documentoPedido
        Dim ListaTipoExistencia As New List(Of String)
        'documentoventa = New documentoventaAbarrotes
        documentoVentaDetalle = New List(Of documentoPedidoDet)
        'documentoBE.idDistribucion = ID
        documentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoBE.tipoVenta = "VP"
        documentoBE.estadoEntrega = TipoEntrega
        'documentoBE.idDistribucion = ID

        documentoBE.ListaEstado = New List(Of String)

        documentoBE.ListaEstado.Add(TipoExistencia.ActivoInmovilizado)


        'documentoVentaDetalle = objDocCompraDet.GetUbicar_documentoPedidoxIdDistribucion(documentoBE)  ' objDocCompraDet.usp_EditarDetalleVenta(ID)
        If (documentoVentaDetalle.Count > 0) Then
            idDocumentoAnt = documentoVentaDetalle(0).idDocumento
        End If

        'DETALLE DE LA COMPRA
        dgvPedidoDetalle.Table.Records.DeleteAll()
        'GridBeneficios.Table.Records.DeleteAll()
        For Each i In documentoVentaDetalle

            Me.dgvPedidoDetalle.Table.AddNewRecord.SetCurrent()
            Me.dgvPedidoDetalle.Table.AddNewRecord.BeginEdit()
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chPago", True)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("codigo", i.secuencia)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("canDisponible", i.monto1)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("totalmn", i.importeMN)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("totalpagar", i.importeMN)

            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("tipobeneficio", i.tipobeneficio)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("valorbase", i.beneficiobase)
            Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("valorafecto", i.descuentoMN.GetValueOrDefault)


            If (i.estadoEntrega = "PN") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PENDIENTE")
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chVenta", False)
            ElseIf (i.estadoEntrega = "AN") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "ANULADO")
            ElseIf (i.estadoEntrega = "PR") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PREPARANDO")
            ElseIf (i.estadoEntrega = "AT") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "POR CONFIRMAR")
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chVenta", True)
            ElseIf (i.estadoEntrega = "CF") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "CONFIRMADO")
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("chVenta", True)
            ElseIf (i.estadoEntrega = "DC") Then
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("estado", "PRE VENTA")
            End If

            If (idDocumentoAnt <> i.idDocumento) Then
                conteoNumeracio = conteoNumeracio + 1
                idDocumentoAnt = i.idDocumento
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("nroPedido", "Pedido" & conteoNumeracio)
            Else
                Me.dgvPedidoDetalle.Table.CurrentRecord.SetValue("nroPedido", "Pedido" & conteoNumeracio)
            End If


            Me.dgvPedidoDetalle.Table.AddNewRecord.EndEdit()

        Next
        ' btGrabar.Enabled = False


    End Sub

    Private Sub DgvPedidoDetalle_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPedidoDetalle.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvPedidoDetalle.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal

                Case 7

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvPedidoDetalle.TableModel.NameToColIndex("chVenta")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvPedidoDetalle.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chVenta" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                'dgvCompra.TableModel(RowIndex, 21).CellValue = "N" ' curStatus

                                '******************************************************************
                                'If ChImporteEditing.Checked Then
                                '    GetManaipulacionXimporte(RowIndex)
                                'Else
                                '    GetManipulacionXBase(RowIndex)
                                'End If

                                Me.dgvPedidoDetalle.TableModel(RowIndex, 7).CellValue = False
                                ActualizarPedidoPendiente()
                                'ConteoLabelVentasXCheck()
                                'TotalTalesXcolumnaXCheck()
                                Me.dgvPedidoDetalle.TableModel(RowIndex, 7).CellValue = True
                            Else ' si es check de bonificacion esta en False: Entonces ->
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                'Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S"

                                '******************************************************************
                                'If ChImporteEditing.Checked Then
                                '    GetManaipulacionXimporte(RowIndex)
                                'Else
                                '    GetManipulacionXBase(RowIndex)
                                'End If
                                Me.dgvPedidoDetalle.TableModel(RowIndex, 7).CellValue = True
                                ActualizarPedidoConfirmado()

                                'ConteoLabelVentasXCheck()
                                'TotalTalesXcolumnaXCheck()
                                Me.dgvPedidoDetalle.TableModel(RowIndex, 7).CellValue = False
                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.dgvPedidoDetalle.TableControl.Refresh()
            'TotalTalesXcolumna()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        txtmesa.Clear()
        TXTcOMPRADOR.Clear()
        pncliente.Dock = DockStyle.Fill
        pncliente.Visible = True
        pnMesa.Dock = DockStyle.None
        pnMesa.Visible = False

        'Dim f As New Form_ListaClientes()
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'If f.Tag IsNot Nothing Then
        '    Dim c = CType(f.Tag, entidad)
        '    TXTcOMPRADOR.Text = c.nombreCompleto
        '    TXTcOMPRADOR.Tag = c.idEntidad
        '    txtruc.Visible = True
        '    txtruc.Text = c.nrodoc
        '    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    listaClientes.Add(c)
        'End If

    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        txtmesa.Clear()
        TXTcOMPRADOR.Clear()
        pncliente.Dock = DockStyle.None
        pncliente.Visible = False
        pnMesa.Dock = DockStyle.Fill
        pnMesa.Visible = True
        'With Form_GestionNegocio
        '    .Panel3.Visible = False
        '    .llamarMesas("U")
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .ShowDialog(Me)
        'End With
    End Sub

    Private Sub DgvPedidoDetalle_TableControlDrawCell_1(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvPedidoDetalle.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True
            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 7 Then
                'e.Inner.Style.ImageList = ImageList1
                'e.Inner.Style.ImageIndex = 0
                e.Inner.Style.Description = "Confirmar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                'e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If
        End If
    End Sub

    Private Sub DgvPedidoDetalle_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvPedidoDetalle.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim documentoPedidoDetSA As New documentoPedidoDetSA
        Dim documentopedidoBE As New documentoPedidoDet
        Try

            If e.Inner.ColIndex = 7 Then

                Me.dgvPedidoDetalle.TableControl.CurrentCell.MoveTo(e.Inner.RowIndex, e.Inner.ColIndex)
                documentopedidoBE = New documentoPedidoDet
                documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                documentopedidoBE.estadoEntrega = "AT"
                documentopedidoBE.listaSecuencia = New List(Of Integer)
                documentopedidoBE.listaSecuencia.Add(Me.dgvPedidoDetalle.Table.CurrentRecord.GetValue("codigo"))
                documentopedidoBE.monto1 = Me.dgvPedidoDetalle.Table.CurrentRecord.GetValue("cantidad")
                documentopedidoBE.idAlmacenOrigen = CInt(Me.dgvPedidoDetalle.Table.CurrentRecord.GetValue("almacen"))
                documentopedidoBE.DetalleItem = Me.dgvPedidoDetalle.Table.CurrentRecord.GetValue("item")
                documentopedidoBE.idItem = Me.dgvPedidoDetalle.Table.CurrentRecord.GetValue("idProducto")
                documentopedidoBE.nombreArea = "D"

                'documentoPedidoDetSA.EditarEstadoXCambioInv(documentopedidoBE)
                dgvPedidoDetalle.Table.CurrentRecord.Delete()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub EnviarDocumento(productoBE As documentoventaAbarrotes) Implements IForm2.EnviarDocumento

        Try
            'lblMesa = productoBE.idDocumento
            txtmesa.Text = productoBE.nombrePedido
            txtmesa.Tag = productoBE.idDocumento

            GetDocumentoPedidoXConfirmarXMesa(txtmesa.Tag, "PN")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class
