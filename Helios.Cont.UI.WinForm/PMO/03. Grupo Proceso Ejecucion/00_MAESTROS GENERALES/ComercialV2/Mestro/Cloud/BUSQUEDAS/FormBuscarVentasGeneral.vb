Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormBuscarVentasGeneral

#Region "Variables"
    Public Property listaClientes As New List(Of entidad)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Dim entidadSA As New entidadSA
#End Region

#Region "Entidad Source"
    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        txtFiltrar.ForeColor = Color.Black
        txtFiltrar.Tag = Nothing
        If txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '  txtruc.Visible = True
        Else
            ' txtruc.Visible = False
        End If
    End Sub

    Dim thread As System.Threading.Thread
    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        '   ProgressBar1.Visible = True
        '  ProgressBar1.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        Dim varios = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(varios)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            'ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(txtFiltrar.Text) Or n.nrodoc.StartsWith(txtFiltrar.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
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

    Private Sub FormBusquedaDocXEntidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(GridEscan, True, False, 10.0F)
        txtFechapERIODO.Value = DateTime.Now
        TXTdIA.Value = DateTime.Now
        Label6.Visible = False
        ComboCriterio.Visible = False
        ' Add any initialization after the InitializeComponent() call.
        txtFiltrar.Select()
        threadClientes()
    End Sub

    Public Sub New(be As entidad)

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridAvanzado(GridEscan, True, False, 10.0F)
        txtFechapERIODO.Value = DateTime.Now
        TXTdIA.Value = DateTime.Now
        ' Add any initialization after the InitializeComponent() call.
        threadClientes()
        MappingCliente(be)
    End Sub

#End Region

    Private Sub MappingCliente(be As entidad)
        txtFiltrar.Tag = be.idEntidad
        txtFiltrar.Text = be.nombreCompleto
        txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        ComboFiltros.Text = "CLIENTE"
    End Sub

    Sub centrar()
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridEscan.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ventaSA As New documentoVentaAbarrotesSA
                Dim ventaDetSA As New documentoVentaAbarrotesDetSA
                Dim doc As New documento
                Dim r As Record = GridEscan.Table.CurrentRecord
                If r IsNot Nothing Then
                    doc.documentoventaAbarrotes = ventaSA.GetVentaID(New documento With {.idDocumento = Val(r.GetValue("iddoc"))}) ' GetUbicar_documentoventaAbarrotesPorID(Val(r.GetValue("iddoc")))

                    'doc.documentoventaAbarrotes = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Val(r.GetValue("iddoc")))
                    ''Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
                    'Dim listaDetalle = ventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(r.GetValue("iddoc")))
                    'doc.documentoventaAbarrotes.documentoventaAbarrotesDet = listaDetalle
                    Me.Tag = doc
                    Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar stock!")
        End Try

    End Sub

    Private Sub GridEscan_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEscan.TableControlCellClick

    End Sub

    Private Sub ComboFiltros_Click(sender As Object, e As EventArgs) Handles ComboFiltros.Click

    End Sub

    Private Sub ComboFiltros_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboFiltros.SelectedValueChanged
        ComboCriterio.Items.Clear()
        RoundButton21.Enabled = True
        Select Case ComboFiltros.Text
            Case "COMPROBANTE"
                ComboCriterio.Visible = True
                ComboCriterio.Items.Add("FACTURA")
                ComboCriterio.Items.Add("BOLETA")
                ComboCriterio.Items.Add("PROFORMA")
                ComboCriterio.Items.Add("NOTA")
                txtFiltrar.Clear()
                txtFiltrar.ReadOnly = True
                txtFiltrar.Visible = False
            Case "CLIENTE"
                ComboCriterio.Visible = False
                txtFiltrar.ReadOnly = False
                txtFiltrar.Clear()
                txtFiltrar.Select()
                txtFiltrar.Visible = True
            Case Else
                RoundButton21.Enabled = False
        End Select
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        GridEscan.Table.Records.DeleteAll()
        Dim ventaSA As New documentoVentaAbarrotesSA
        If ComboFiltros.Text = "CLIENTE" Then

            If ChDia.Checked = True Then
                Dim ventas = ventaSA.GetVentasPorCriterio(New documentoventaAbarrotes With
                                                          {
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .fechaPeriodo = GetPeriodo(TXTdIA.Value, True)
                                                          }, ComboFiltros.Text, txtFiltrar.Tag)


                Dim VentasDelDia = ventas.Where(Function(o) o.fechaDoc.Value.Year = TXTdIA.Value.Year And
                    o.fechaDoc.Value.Month = TXTdIA.Value.Month And
                    o.fechaDoc.Value.Day = TXTdIA.Value.Day).ToList()

                GetVentasCriterioCliente(VentasDelDia)
            End If

            If ChMes.Checked = True Then
                Dim ventas = ventaSA.GetVentasPorCriterio(New documentoventaAbarrotes With
                                                          {
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .fechaPeriodo = GetPeriodo(txtFechapERIODO.Value, True)
                                                          }, ComboFiltros.Text, txtFiltrar.Tag)

                GetVentasCriterioCliente(ventas)
            End If







        Else
            If ComboCriterio.Visible Then

                If ChDia.Checked = True Then
                    Dim ventas = ventaSA.GetVentasPorCriterio(New documentoventaAbarrotes With
                                                     {
                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                     .fechaPeriodo = GetPeriodo(txtFechapERIODO.Value, True)
                                                     }, ComboCriterio.Text, String.Empty)

                    Dim ventasDelDia = ventas.Where(Function(o) o.fechaDoc.Value.Year = TXTdIA.Value.Year And
                    o.fechaDoc.Value.Month = TXTdIA.Value.Month And
                    o.fechaDoc.Value.Day = TXTdIA.Value.Day).ToList()

                    GetVentasCriterioComprobante(ventasDelDia)
                End If

                If ChMes.Checked = True Then
                    Dim ventas = ventaSA.GetVentasPorCriterio(New documentoventaAbarrotes With
                                                       {
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .fechaPeriodo = GetPeriodo(txtFechapERIODO.Value, True)
                                                       }, ComboCriterio.Text, String.Empty)

                    GetVentasCriterioComprobante(ventas)
                End If



            End If

        End If
        If GridEscan.Table.Records.Count > 0 Then
            centrar()
        End If
        GridEscan.Focus()
    End Sub

    Private Sub GetVentasCriterioCliente(ventas As List(Of documentoventaAbarrotes))
        Dim dt As New DataTable
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("proveedor")
        dt.Columns.Add("estado")
        dt.Columns.Add("fecha")
        dt.Columns.Add("iddoc")
        dt.Columns.Add("tipodoc")

        For Each i In ventas
            dt.Rows.Add(String.Format("{0}-{1}", i.serieVenta, i.numeroVenta),
                        i.ImporteNacional,
                        i.NombreEntidad,
                        i.estadoCobro,
                        i.fechaDoc,
                        i.idDocumento,
                        i.tipoDocumento)
        Next
        GridEscan.DataSource = dt
        If GridEscan.Table.Records.Count > 0 Then
            Me.Size = New Size(884, 410)
        Else
            Me.Size = New Size(884, 205)

        End If
    End Sub

    Private Sub GetVentasCriterioComprobante(ventas As List(Of documentoventaAbarrotes))
        Dim dt As New DataTable
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("proveedor")
        dt.Columns.Add("estado")
        dt.Columns.Add("fecha")
        dt.Columns.Add("iddoc")
        dt.Columns.Add("tipodoc")

        For Each i In ventas
            dt.Rows.Add(String.Format("{0}-{1}", i.serieVenta, i.numeroVenta),
                        i.ImporteNacional,
                        i.NombreEntidad,
                        i.estadoCobro,
                        i.fechaDoc,
                        i.idDocumento,
                        i.tipoDocumento)
        Next
        GridEscan.DataSource = dt
        If GridEscan.Table.Records.Count > 0 Then
            Me.Size = New Size(884, 410)
        Else
            Me.Size = New Size(884, 205)

        End If
    End Sub

    Private Sub ComboCriterio_Click(sender As Object, e As EventArgs) Handles ComboCriterio.Click

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

    Private Sub GridEscan_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridEscan.TableControlCellDoubleClick
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetSA As New documentoVentaAbarrotesDetSA
        Dim doc As New documento
        Dim r As Record = GridEscan.Table.CurrentRecord
        If r IsNot Nothing Then
            doc.documentoventaAbarrotes = ventaSA.GetVentaID(New documento With {.idDocumento = Val(r.GetValue("iddoc"))}) ' GetUbicar_documentoventaAbarrotesPorID(Val(r.GetValue("iddoc")))
            'Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
            '   Dim listaDetalle = ventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(r.GetValue("iddoc")))
            '     doc.documentoventaAbarrotes.documentoventaAbarrotesDet = listaDetalle
            Me.Tag = doc
            Close()
        End If

    End Sub

    Private Sub ChDia_OnChange(sender As Object, e As EventArgs) Handles ChDia.OnChange
        If ChDia.Checked = True Then
            ChMes.Checked = False
            txtFechapERIODO.Visible = False
            Label7.Text = "DIA"
            TXTdIA.Visible = True
        ElseIf ChDia.Checked = False Then

        End If
    End Sub

    Private Sub ChMes_OnChange(sender As Object, e As EventArgs) Handles ChMes.OnChange
        If ChMes.Checked = True Then
            ChDia.Checked = False
            txtFechapERIODO.Visible = True
            TXTdIA.Visible = False
            Label7.Text = "PERIODO"
        ElseIf ChMes.Checked = False Then

        End If
    End Sub
End Class