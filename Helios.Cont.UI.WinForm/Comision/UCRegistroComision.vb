Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Imports Syncfusion.Grouping
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools

Public Class UCRegistroComision
    Dim lbl As Label
    Dim lblAutorizados As Label
    Dim lblEliminados As Label
    Public Property listaComisiones As List(Of registrocomision_usuarios_detalle)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid2(GridProducts)
        DateConsulta.Value = Date.Now
        GetComisiones(StatusComisionRegistro.Pendiente)
        FormatoLabels()
    End Sub

    Private Sub FormatoGrid2(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = ColorTranslator.FromHtml("#FF97F4BB")
        grid.TableOptions.SelectionTextColor = Color.Black
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub FormatoGrid(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub FormatoLabels()
        lbl = New Label
        lbl.Text = If(listaComisiones IsNot Nothing, listaComisiones.Where(Function(o) o.estadoComision = StatusComisionRegistro.Pendiente).Count, "0")
        lbl.ForeColor = Color.DeepSkyBlue
        lbl.AutoSize = True
        lbl.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lbl.BackColor = Color.Transparent

        lblAutorizados = New Label
        lblAutorizados.Text = If(listaComisiones IsNot Nothing, listaComisiones.Where(Function(o) o.estadoComision = StatusComisionRegistro.PagoAutorizado).Count, "0")
        lblAutorizados.ForeColor = Color.DeepSkyBlue
        lblAutorizados.AutoSize = True
        lblAutorizados.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblAutorizados.BackColor = Color.Transparent

        lblEliminados = New Label
        lblEliminados.Text = If(listaComisiones IsNot Nothing, listaComisiones.Where(Function(o) o.estadoComision = StatusComisionRegistro.ComisionBaja).Count, "0")
        lblEliminados.ForeColor = Color.DeepSkyBlue
        lblEliminados.AutoSize = True
        lblEliminados.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblEliminados.BackColor = Color.Transparent

        'Me.treeViewAdv2.Nodes(0).Nodes(0).CustomControl = lbl

        'Me.treeViewAdv2.Nodes(0).Nodes(1).CustomControl = lblAutorizados

        'Me.treeViewAdv2.Nodes(0).Nodes(3).CustomControl = lblEliminados

        Me.treeViewAdv2.Nodes(0).CustomControl = lbl

        Me.treeViewAdv2.Nodes(1).CustomControl = lblAutorizados

        Me.treeViewAdv2.Nodes(3).CustomControl = lblEliminados
    End Sub

    Private Sub FormatoLabelsV2()
        lbl.Text = If(listaComisiones IsNot Nothing, listaComisiones.Where(Function(o) o.estadoComision = StatusComisionRegistro.Pendiente).Count, "0")

        lblAutorizados.Text = If(listaComisiones IsNot Nothing, listaComisiones.Where(Function(o) o.estadoComision = StatusComisionRegistro.PagoAutorizado).Count, "0")

        lblEliminados.Text = If(listaComisiones IsNot Nothing, listaComisiones.Where(Function(o) o.estadoComision = StatusComisionRegistro.ComisionBaja).Count, "0")

    End Sub

    'Private Sub GetComisiones()
    '    Dim strUsuario As String = String.Empty
    '    Dim comisionSA As New registrocomision_usuarios_detalleSA
    '    listaComisiones = comisionSA.registrocomision_usuarios_detalleJoinList(New Business.Entity.registrocomision_usuarios With
    '                                                                     {
    '                                                                     .idEmpresa = Gempresas.IdEmpresaRuc, .unidadNegocio = GEstableciento.IdEstablecimiento,
    '                                                                     .fechaRegistro = New Date(DateConsulta.Value.Year, DateConsulta.Value.Month, 1)
    '                                                                     })
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("usuario")
    '    dt.Columns.Add("usuariocode")
    '    dt.Columns.Add("fechaventa")
    '    dt.Columns.Add("tipodoc")
    '    dt.Columns.Add("nroventa")
    '    dt.Columns.Add("moneda")
    '    dt.Columns.Add("producto")
    '    dt.Columns.Add("unidadcomercial")
    '    dt.Columns.Add("catalogo")
    '    dt.Columns.Add("importeventa")
    '    dt.Columns.Add("importecomision")
    '    dt.Columns.Add("estadoventa")
    '    dt.Columns.Add("estadocomision")
    '    dt.Columns.Add("comision", GetType(registrocomision_usuarios_detalle))
    '    dt.Columns.Add("selec", GetType(Boolean))

    '    For Each i In listaComisiones

    '        Dim Usuario = UsuariosList.Where(Function(o) o.IDUsuario = i.IdUsuario).SingleOrDefault
    '        If Usuario IsNot Nothing Then
    '            strUsuario = Usuario.Full_Name
    '        End If

    '        dt.Rows.Add(
    '            strUsuario,
    '            "00",
    '            i.customDocumentoVenta.fechaDoc,
    '            i.customDocumentoVenta.tipoDocumento,
    '            $"{i.customDocumentoVenta.serieVenta}-{i.customDocumentoVenta.numeroVenta}",
    '            i.customDocumentoVenta.moneda,
    '            i.customProducto.descripcionItem,
    '            i.customUnidadComercial.unidadComercial,
    '            i.customCatalogoPrecio.nombre_corto,
    '            i.customDocumentoVenta.ImporteNacional,
    '            i.precioComision,
    '            If(i.customDocumentoVenta.estadoCobro = "DC", "Saldado", "Pendiente"),
    '            i.estadoComision,
    '            i, True)
    '    Next
    '    GridProducts.DataSource = dt
    'End Sub

    Private Sub GetComisiones(status As String)
        Dim strUsuario As String = String.Empty
        Dim comisionSA As New registrocomision_usuarios_detalleSA
        listaComisiones = comisionSA.registrocomision_usuarios_detalleJoinList(New Business.Entity.registrocomision_usuarios With
                                                                         {
                                                                         .idEmpresa = Gempresas.IdEmpresaRuc, .unidadNegocio = GEstableciento.IdEstablecimiento,
                                                                         .fechaRegistro = New Date(DateConsulta.Value.Year, DateConsulta.Value.Month, 1)
                                                                         })
        Dim dt As New DataTable()
        dt.Columns.Add("usuario")
        dt.Columns.Add("usuariocode")
        dt.Columns.Add("fechaventa")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nroventa")
        dt.Columns.Add("moneda")
        dt.Columns.Add("producto")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("catalogo")
        dt.Columns.Add("importeventa")
        dt.Columns.Add("importecomision")
        dt.Columns.Add("estadoventa")
        dt.Columns.Add("estadocomision")
        dt.Columns.Add("comision", GetType(registrocomision_usuarios_detalle))
        dt.Columns.Add("selec", GetType(Boolean))

        For Each i In listaComisiones.Where(Function(o) o.estadoComision = status)

            Dim Usuario = UsuariosList.Where(Function(o) o.IDUsuario = i.IdUsuario).SingleOrDefault
            If Usuario IsNot Nothing Then
                strUsuario = Usuario.Full_Name
            End If

            dt.Rows.Add(
                strUsuario,
                "00",
                i.customDocumentoVenta.fechaDoc,
                i.customDocumentoVenta.tipoDocumento,
                $"{i.customDocumentoVenta.serieVenta}-{i.customDocumentoVenta.numeroVenta}",
                i.customDocumentoVenta.moneda,
                i.customProducto.descripcionItem,
                i.customUnidadComercial.unidadComercial,
                i.customCatalogoPrecio.nombre_corto,
                i.customDocumentoVenta.ImporteNacional,
                i.precioComision,
                If(i.customDocumentoVenta.estadoCobro = "DC", "Saldado", "Pendiente"),
                i.estadoComision,
                i, True)
        Next

        GridProducts.DataSource = dt
        Select Case status
            Case StatusComisionRegistro.Pendiente
                GridProducts.TableDescriptor.Name = "Pendientes de autorización"
            Case StatusComisionRegistro.PagoAutorizado
                GridProducts.TableDescriptor.Name = "Comisiones autorizadas"
            Case StatusComisionRegistro.ComisionBaja
                GridProducts.TableDescriptor.Name = "Comisiones en baja"
        End Select
    End Sub

    Private col2Check As Boolean = True
    Private Sub GridProducts_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProducts.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)

        If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "selec" Then
            Me.col2Check = Not Me.col2Check

            For Each i In GridProducts.Table.Records
                i.SetValue("selec", Me.col2Check)
            Next

            e.Inner.Cancel = True
        End If
    End Sub

    Private Sub GridProducts_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridProducts.QueryCellStyleInfo
        If e.TableCellIdentity IsNot Nothing Then
            If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "selec" Then
                e.Style.CellType = "CheckBox"
                e.Style.Description = e.Style.Text
                e.Style.CellValue = Me.col2Check
                e.Style.Enabled = True
            End If
        End If
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles bunifuFlatButton6.Click
        GetComisiones(StatusComisionRegistro.Pendiente)
        FormatoLabelsV2()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        AutorizarPagos()
    End Sub

    Private Sub AutorizarPagos()
        Dim comisionSA As New registrocomision_autorizacionSA
        Dim lista As New List(Of registrocomision_autorizacion)
        For Each i In GridProducts.Table.Records
            If i.GetValue("selec") = True Then
                Dim obj = CType(i.GetValue("comision"), registrocomision_usuarios_detalle)

                lista.Add(New registrocomision_autorizacion With
                          {
                          .idseguimiento = obj.idseguimiento,
                          .idseguimientoDetalle = obj.idseguimientoDetalle,
                          .idDocumentoRef = obj.idDocumentoRef,
                          .fechaPedido = DateTime.Now,
                          .bloqueado = False,
                          .idProducto = obj.idProducto,
                          .item = obj.customProducto.descripcionItem,
                          .tipoProducto = obj.customProducto.tipoExistencia,
                          .importeAutorizado = obj.precioComision,
                          .importeAutorizadoME = 0,
                          .desembolsoAutorizado = False,
                          .estado = 0
                          })
            End If

        Next


        If lista.Count = 0 Then
            MessageBox.Show("Debe seleccionar al menos un registro!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If lista.Count > 0 Then
            comisionSA.registrocomision_autorizacionSaveList(lista)
            MessageBox.Show("Comisiones autorizadas!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GetComisiones(StatusComisionRegistro.Pendiente)
            FormatoLabelsV2()
        End If

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim comisionSA As New registrocomision_usuarios_detalleSA
        Dim R As Record = GridProducts.Table.CurrentRecord
        If R IsNot Nothing Then
            Dim obj = CType(R.GetValue("comision"), registrocomision_usuarios_detalle)
            If obj IsNot Nothing Then
                comisionSA.ChangeStatusComisionRegistro(New registrocomision_usuarios_detalle With
                                                        {
                                                        .idseguimiento = obj.idseguimiento,
                                                        .idseguimientoDetalle = obj.idseguimientoDetalle,
                                                        .estadoComision = StatusComisionRegistro.ComisionBaja
                                                        })
                MessageBox.Show("Comisión en baja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetComisiones(StatusComisionRegistro.Pendiente)
                FormatoLabelsV2()
                'R.Delete()
            End If
        End If
    End Sub

    Private Sub TreeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect


    End Sub

    Private Sub BtActivar_Click(sender As Object, e As EventArgs) Handles BtActivar.Click
        Dim comisionSA As New registrocomision_usuarios_detalleSA
        Dim R As Record = GridProducts.Table.CurrentRecord
        If R IsNot Nothing Then
            Dim obj = CType(R.GetValue("comision"), registrocomision_usuarios_detalle)
            If obj IsNot Nothing Then
                comisionSA.ChangeStatusComisionRegistro(New registrocomision_usuarios_detalle With
                                                        {
                                                        .idseguimiento = obj.idseguimiento,
                                                        .idseguimientoDetalle = obj.idseguimientoDetalle,
                                                        .estadoComision = StatusComisionRegistro.Pendiente
                                                        })
                MessageBox.Show("Comisión en baja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetComisiones(StatusComisionRegistro.ComisionBaja)
                FormatoLabelsV2()
                'R.Delete()
            End If
        End If
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Cursor = Cursors.WaitCursor
        Select Case Me.treeViewAdv2.SelectedNode.Text
            Case "Repositorio"
                BtActivar.Visible = False
                BunifuFlatButton1.Visible = True
                BunifuFlatButton4.Visible = True
                GetComisiones(StatusComisionRegistro.Pendiente)
            Case "Items autorizados"
                BtActivar.Visible = False
                BunifuFlatButton1.Visible = False
                BunifuFlatButton4.Visible = False
                GetComisiones(StatusComisionRegistro.PagoAutorizado)
            Case "Reciclados"

            Case "Items eliminados"
                BtActivar.Visible = True
                BunifuFlatButton1.Visible = False
                BunifuFlatButton4.Visible = False
                GetComisiones(StatusComisionRegistro.ComisionBaja)
        End Select
        Cursor = Cursors.Default
    End Sub
End Class
