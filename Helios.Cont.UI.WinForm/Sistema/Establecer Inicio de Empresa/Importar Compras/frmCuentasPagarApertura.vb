Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Public Class frmCuentasPagarApertura
    Inherits frmMaster

    Public Property ListadoProveedores As New List(Of entidad)


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        GridCFG(dgvCompras)
        GetTableGridColumn()
        LoadCombos()
        CMBproveedores()
    End Sub

#Region "Métodos"

    Private Sub LoadCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim dt As New DataTable()

        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = "1"
        dr(1) = "NACIONAL"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "2"
        dr1(1) = "EXTRANJERA"
        dt.Rows.Add(dr1)

        Dim ggcStyle As GridTableCellStyleInfo = dgvCompras.TableDescriptor.Columns("moneda").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        '-----------------------------------------------------------------
        'COMPROBANTE TIPO DOCUMENTOS
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In listatabla _
                           Where Not list.Contains(n.codigoDetalle)).ToList



        Dim ggcStyle2 As GridTableCellStyleInfo = dgvCompras.TableDescriptor.Columns("tipodoc").Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = Comprobantes
        ggcStyle2.ValueMember = "codigoDetalle"
        ggcStyle2.DisplayMember = "descripcion"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

        dgvCompras.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub CMBproveedores()
        Dim entidadSA As New entidadSA

        ListadoProveedores = New List(Of entidad)
        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Public Sub GrabarComprasApertura()
        Dim compraSA As New DocumentoCompraSA
        Dim documentoBE As New documento
        Dim obj As New documentocompra
        Dim objDetalle As New documentocompradetalle
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim listaCompras As New List(Of documento)

        'Dim nAsiento As New asiento
        'Dim nMovimiento As New movimiento
        'Dim listaAsiento As New List(Of asiento)
        Try
            documentoBE = New documento
            obj = New documentocompra
            objDetalle = New documentocompradetalle
            listaCompras = New List(Of documento)
            ListaDetalle = New List(Of documentocompradetalle)

            'nAsiento = New asiento
            'nMovimiento = New movimiento
            'listaAsiento = New List(Of asiento)

            For Each i As Record In dgvCompras.Table.Records
                ListaDetalle = New List(Of documentocompradetalle)
                'nAsiento = New asiento With
                '           {
                '               .idEmpresa = Gempresas.IdEmpresaRuc,
                '               .idCentroCostos = GEstableciento.IdEstablecimiento,
                '               .fechaProceso = CType(i.GetValue("fecha"), DateTime),
                '               .codigoLibro = "5",
                '               .tipo = "D",
                '               .tipoAsiento = "AS-M",
                '               .importeMN = CDec(i.GetValue("montoMN")),
                '               .importeME = CDec(i.GetValue("montoME")),
                '               .glosa = "Cuentas por pagara de apertura",
                '               .usuarioActualizacion = usuario.IDUsuario,
                '               .fechaActualizacion = DateTime.Now
                '               }

                'nMovimiento = New movimiento With
                '           {
                '               .cuenta = "4212",
                '               .descripcion = i.GetValue("proveedor"),
                '               .tipo = "D",
                '               .monto = CDec(i.GetValue("montoMN")),
                '               .montoUSD = CDec(i.GetValue("montoME")),
                '               .usuarioActualizacion = usuario.IDUsuario,
                '               .fechaActualizacion = DateTime.Now
                '               }

                'nAsiento.movimiento.Add(nMovimiento)
                'listaAsiento.Add(nAsiento)

                documentoBE = New documento With {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idCentroCosto = GEstableciento.IdEstablecimiento,
                    .tipoDoc = i.GetValue("tipodoc"),
                    .idEntidad = usuario.IDUsuario,
                    .entidad = usuario.CustomUsuario.Full_Name,
                    .tipoEntidad = "US",
                    .nrodocEntidad = usuario.CustomUsuario.NroDocumento,
                    .fechaProceso = CType(i.GetValue("fecha"), DateTime),
                    .nroDoc = i.GetValue("serie") & "-" & i.GetValue("numero"),
                    .tipoOperacion = "02",
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }

                obj = New documentocompra
                obj.fechaContable = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                obj.fechaDoc = CType(i.GetValue("fecha"), DateTime)
                obj.tipoDoc = i.GetValue("tipodoc")
                obj.codigoLibro = "5"
                obj.idEmpresa = Gempresas.IdEmpresaRuc
                obj.idCentroCosto = GEstableciento.IdEstablecimiento
                obj.serie = i.GetValue("serie")
                obj.numeroDoc = i.GetValue("numero")
                obj.monedaDoc = i.GetValue("moneda")
                obj.tcDolLoc = CDec(i.GetValue("tipocambio"))
                obj.idProveedor = Val(i.GetValue("idproveedor"))
                obj.nombreProveedor = i.GetValue("proveedor")
                obj.importeTotal = CDec(i.GetValue("montoMN"))
                obj.importeUS = CDec(i.GetValue("montoME"))
                obj.tipoCompra = "APT"
                obj.glosa = "Cuentas por pagara de apertura"
                obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                obj.usuarioActualizacion = usuario.IDUsuario
                obj.fechaActualizacion = DateTime.Now

                documentoBE.documentocompra = obj

                objDetalle = New documentocompradetalle With
                             {
                                 .idItem = 0,
                                 .descripcionItem = "Saldos",
                                 .importe = CDec(i.GetValue("montoMN")),
                                 .importeUS = CDec(i.GetValue("montoME")),
                                 .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
                                 .usuarioModificacion = usuario.IDUsuario,
                                 .fechaModificacion = DateTime.Now
                                 }


                ListaDetalle.Add(objDetalle)
                'documentoBE.asiento = listaAsiento
                documentoBE.documentocompra.documentocompradetalle = ListaDetalle
                listaCompras.Add(documentoBE)
            Next

            compraSA.GrabarCuetasPorPagarApertura(listaCompras)
            MessageBox.Show("Elementos registrados!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetTableGridColumn()
        Dim dt As New DataTable()
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipocambio")
        dt.Columns.Add("idproveedor")
        dt.Columns.Add("proveedor")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        dgvCompras.DataSource = dt


    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

    Private Sub frmCuentasPagarApertura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCuentasPagarApertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvCompras.Table.Records.Count > 0 Then
            GrabarComprasApertura()
        Else
            MessageBox.Show("Debe ingresar al menos un comprobante a la canasta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcProveedor.Font = New Font("Segoe UI", 8)
            Me.pcProveedor.Size = New Size(301, 148)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoProveedores _
                     Where n.nombreCompleto.StartsWith(txtProveedor.Text)).ToList

            lstProveedor.DataSource = consulta
            lstProveedor.DisplayMember = "nombreCompleto"
            lstProveedor.ValueMember = "idEntidad"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcProveedor.Font = New Font("Segoe UI", 8)
            Me.pcProveedor.Size = New Size(301, 148)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            lstProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcProveedor.IsShowing() Then
                Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstProveedor.SelectedItems.Count > 0 Then
                txtProveedor.Text = lstProveedor.Text
                txtProveedor.Tag = lstProveedor.SelectedValue
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstProveedor.MouseDoubleClick
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProveedor.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If Not IsNothing(txtProveedor.Tag) Then
            If txtProveedor.Tag.ToString.Trim.Length > 0 Then
                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                Me.dgvCompras.Table.CurrentRecord.SetValue("fecha", DateTime.Now)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipodoc", "01")
                Me.dgvCompras.Table.CurrentRecord.SetValue("serie", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("numero", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("moneda", "1")
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
                Me.dgvCompras.Table.CurrentRecord.SetValue("idproveedor", Val(txtProveedor.Tag))
                Me.dgvCompras.Table.CurrentRecord.SetValue("proveedor", txtProveedor.Text.Trim)

                Me.dgvCompras.Table.CurrentRecord.SetValue("montoMN", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("montoME", 0.0)
                Me.dgvCompras.Table.AddNewRecord.EndEdit()
            Else
                MessageBox.Show("Debe seleccionar un proveedor!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe seleccionar un proveedor!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        If Not IsNothing(f.Tag) Then
            Dim newEntidad = CType(f.Tag, entidad)
            txtProveedor.Text = newEntidad.nombreCompleto
            txtProveedor.Tag = newEntidad.idEntidad
            ListadoProveedores.Add(newEntidad)
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
            dgvCompras.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub dgvCompras_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompras.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompras_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompras.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 9
                    Select Case dgvCompras.Table.CurrentRecord.GetValue("moneda")
                        Case "1"
                            Dim colDolares As Decimal = 0
                            colDolares = Math.Round(CDec(dgvCompras.Table.CurrentRecord.GetValue("montoMN")) / CDec(dgvCompras.Table.CurrentRecord.GetValue("tipocambio")), 2)
                            dgvCompras.Table.CurrentRecord.SetValue("montoME", colDolares)
                        Case "2"

                    End Select

                Case 10
                    Select Case dgvCompras.Table.CurrentRecord.GetValue("moneda")
                        Case "1"

                        Case "2"
                            Dim colSoles As Decimal = 0
                            colSoles = Math.Round(CDec(dgvCompras.Table.CurrentRecord.GetValue("montoME")) * CDec(dgvCompras.Table.CurrentRecord.GetValue("tipocambio")), 2)
                            dgvCompras.Table.CurrentRecord.SetValue("montoMN", colSoles)
                    End Select
            End Select
        End If
    End Sub
End Class