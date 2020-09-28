Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalExistencia

#Region "Métodos"
    Public Sub CargarGastoCuentaPAdreLIke()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Try
            lsvServicios.Columns.Clear()
            lsvServicios.Items.Clear()
            lsvServicios.Columns.Add("Cuenta", 75)
            lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As cuentaplanContableEmpresa In cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "18")
                Dim n As New ListViewItem(i.cuenta)
                n.SubItems.Add(i.descripcion)
                lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = "Error al obtener Cuentas." & vbCrLf & ex.Message
        End Try
    End Sub


    Public Sub CargarListaGasto()
        Dim cuentaSA As New mascaraGastosEmpresaSA
        Try
            lsvServicios.Columns.Clear()
            lsvServicios.Items.Clear()
            lsvServicios.Columns.Add("Cuenta", 75)
            lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As mascaraGastosEmpresa In cuentaSA.ObtenerMascaraGastos(Gempresas.IdEmpresaRuc, txtServicio.Text)
                Dim n As New ListViewItem(i.cuentaCompra)
                n.SubItems.Add(i.descripcionCompra)
                lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub CargarCMBGastos()
        Dim planContableSA As New cuentaplanContableEmpresaSA
        Try
            cboCuentas.DataSource = Nothing
            cboCuentas.DisplayMember = "descripcion"
            cboCuentas.ValueMember = "cuenta"
            cboCuentas.DataSource = planContableSA.LoadCuentasGastos(Gempresas.IdEmpresaRuc)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub


    Private Sub NuevaEX()
        With frmNuevoMaterial
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "601111"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Protected Overrides Function ProcessCmdKey( _
     ByRef msg As System.Windows.Forms.Message, _
     ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If (keyData <> Keys.Control + Keys.N) And (keyData <> Keys.F2) And (keyData <> Keys.Control + Keys.S) Then _
            Return MyBase.ProcessCmdKey(msg, keyData)


        If Keys.Control + Keys.N Then

            Me.Cursor = Cursors.WaitCursor
            NuevaEX()
            Me.Cursor = Cursors.Arrow
        ElseIf Keys.Control + Keys.S Then
            Me.Cursor = Cursors.WaitCursor
            Call ComprobanteShows(Tablas.Clasificacion)
            Me.Cursor = Cursors.Arrow
        End If

        Return True

    End Function

    Private Sub ListadoProductosPorCategoria(strCategoria As String)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.ListaProductosClasificados(GEstableciento.IdEstablecimiento, strCategoria)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ListaInsumos(tiporec As String)
        Dim actividadSA As New actividadRecursoSA
        lsvListadoItems.Items.Clear()
        For Each i In actividadSA.GetListaInsumosPorProyecto(GProyectos.IdProyectoActividad, tiporec)
            Dim n As New ListViewItem(i.idItem)
            n.SubItems.Add(i.Descripcion)
            n.SubItems.Add(i.unidadMedida)
            n.SubItems.Add(i.Tipo)
            n.SubItems.Add(i.CantRequerida)
            n.SubItems.Add(i.ValorMercadoPu)
            n.SubItems.Add(i.TotalCosto)
            n.SubItems.Add(i.idActividadRecurso)
            n.SubItems.Add(i.cuentaContable)
            lsvListadoItems.Items.Add(n)
        Next
    End Sub
#End Region

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub frmModalExistencia_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TabPage2.Parent = Nothing
        TabPage1.Parent = Nothing
        rbCodigo.Checked = True
        ToolStripLabel7.Select()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub lsvListadoItems_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListadoItems.MouseClick
        If e.Button = MouseButtons.Right Then
            If lsvListadoItems.FocusedItem.Bounds.Contains(e.Location) = True Then
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim nInsumoSA As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim ItemSA As New itemSA
        If lsvListadoItems.Items.Count > 0 Then
            If rbCodigo.Checked = True Then ' existencia

                Dim n As New GInsumo()
                Dim objInsumo As GInsumo = GInsumo.InstanceSingle
                objInsumo.Clear()
                objInsumo.IdActividadRecurso = Nothing ' lsvListadoItems.SelectedItems(0).SubItems(7).Text
                objInsumo.IdInsumo = lsvListadoItems.SelectedItems(0).SubItems(0).Text
                objInsumo.idClasificacion = txtClasID.Text
                objInsumo.NomClasificacion = ItemSA.UbicarCategoriaPorID(txtClasID.Text.Trim).descripcion
                objInsumo.Cantidad = 0
                objInsumo.PU = 0
                objInsumo.Total = 0
                With nInsumoSA.InvocarProductoID(lsvListadoItems.SelectedItems(0).SubItems(0).Text)
                    objInsumo.descripcionItem = .descripcionItem
                    objInsumo.tipoExistencia = .tipoExistencia
                    objInsumo.unidad1 = .unidad1
                    objInsumo.unidadNombre = tablaSA.GetUbicarTablaID(6, .unidad1).descripcion
                    objInsumo.origenProducto = .origenProducto
                    objInsumo.cuenta = .cuenta
                    objInsumo.presentacion = .presentacion
                    objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                End With
                Dispose()
            ElseIf rbNombre.Checked = True Then ' gasto

                Dim n As New GInsumo()
                Dim objInsumo As GInsumo = GInsumo.InstanceSingle
                objInsumo.Clear()
                objInsumo.IdActividadRecurso = lsvListadoItems.SelectedItems(0).SubItems(7).Text
                objInsumo.IdInsumo = lsvListadoItems.SelectedItems(0).SubItems(0).Text
                objInsumo.descripcionItem = lsvListadoItems.SelectedItems(0).SubItems(1).Text
                objInsumo.tipoExistencia = TipoRecurso.SERVICIO
                objInsumo.unidad1 = lsvListadoItems.SelectedItems(0).SubItems(2).Text
                objInsumo.Cantidad = lsvListadoItems.SelectedItems(0).SubItems(4).Text
                objInsumo.PU = lsvListadoItems.SelectedItems(0).SubItems(5).Text
                objInsumo.Total = lsvListadoItems.SelectedItems(0).SubItems(6).Text
                objInsumo.cuenta = lsvListadoItems.SelectedItems(0).SubItems(8).Text
                Dispose()

            End If


        End If
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub rbNombre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbNombre.CheckedChanged
        If rbNombre.Checked = True Then
            txtFiltro.Visible = False
            txtServicio.Visible = True
            cboCuentas.Visible = True
            ColDescrip.Text = "Gasto/Servicio"
            colUM.Text = "D.Extra"
            '  ListaInsumos(TipoRecurso.SERVICIO)
            CargarCMBGastos()
            TabPage1.Parent = TabControl
            TabPage2.Parent = Nothing
        End If
    End Sub

    Private Sub rbCodigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCodigo.CheckedChanged
        If rbCodigo.Checked = True Then
            txtFiltro.Visible = True
            ColDescrip.Text = "Insumo-existencia"
            txtServicio.Visible = False
            cboCuentas.Visible = False
            TabPage2.Parent = TabControl
            TabPage1.Parent = Nothing
            '  colUM.Text = "U.M."
            '   ListaInsumos(TipoRecurso.EXISTENCIA)
        End If
    End Sub

    Private Sub QRibbonApplicationButton2_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton2.ItemActivating
   
    End Sub

    Private Sub btnNuevaEx_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles btnNuevaEx.ItemActivating
        With frmNuevoMaterial
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "601111"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub
    'GetProductoClasificado
    Private Sub ToolStripLabel7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripLabel7.Click
        Me.Cursor = Cursors.WaitCursor
        Call ComprobanteShows(Tablas.Clasificacion)
        Me.Cursor = Cursors.Arrow
    End Sub
    Enum Tablas
        TipoExistencia = 5
        Clasificacion = 0
        UnidadMedidad = 6
        Presentacion = 21
        Cuenta = 3
    End Enum
    Sub ComprobanteShows(caso As Tablas)
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .Text = "Clasificación de existencias"
        '    .x_Establecimiento = GEstableciento.IdEstablecimiento
        '    .lblTipo.Text = caso
        '    Select Case caso
        '        Case Tablas.Clasificacion
        '            .ToolStrip1.Enabled = True
        '            .Tablax = frmModalComprobantesTabla.Tablas.Clasificacion
        '    End Select
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtClasID.Text = datos(0).ID
        '        txtClas.Text = datos(0).NombreCampo
        '        Me.lblEstado.Image = My.Resources.ok4
        '        Me.lblEstado.Text = "Done!: Clasificación." ' String.Empty
        '        Me.lblEstado.ForeColor = Color.Black
        '        ListadoProductosPorCategoria(datos(0).ID)
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EditarExistenciaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditarExistenciaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoMaterial
            .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
            .ObtenerPorCodigoExistencia(lsvListadoItems.SelectedItems(0).SubItems(0).Text)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCuentas.SelectedIndexChanged
        If String.IsNullOrEmpty(cboCuentas.ValueMember.ToString) Then
            Exit Sub
        Else
            If cboCuentas.Text = "" Then
                cboCuentas.Text = ""
                txtServicio.Text = ""
            Else
                txtServicio.Text = cboCuentas.SelectedValue
                Select Case txtServicio.Text
                    Case "18"
                        CargarGastoCuentaPAdreLIke()
                    Case Else
                        CargarListaGasto()
                End Select
            End If
        End If
    End Sub

    Private Sub lsvServicios_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvServicios.MouseDoubleClick
        If lsvServicios.SelectedItems.Count > 0 Then
            Dim n As New GInsumo()
            Dim objInsumo As GInsumo = GInsumo.InstanceSingle
            objInsumo.Clear()
            objInsumo.origenProducto = "1"
            objInsumo.IdActividadRecurso = Nothing ' lsvListadoItems.SelectedItems(0).SubItems(7).Text
            objInsumo.IdInsumo = lsvServicios.SelectedItems(0).SubItems(0).Text
            objInsumo.descripcionItem = lsvServicios.SelectedItems(0).SubItems(1).Text
            objInsumo.tipoExistencia = TipoRecurso.SERVICIO
            objInsumo.unidad1 = 0.0
            objInsumo.Cantidad = 0.0
            objInsumo.PU = 0.0
            objInsumo.Total = 0.0
            objInsumo.cuenta = lsvServicios.SelectedItems(0).SubItems(0).Text
            Dispose()
        End If
    End Sub

    Private Sub lsvServicios_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvServicios.SelectedIndexChanged

    End Sub
End Class