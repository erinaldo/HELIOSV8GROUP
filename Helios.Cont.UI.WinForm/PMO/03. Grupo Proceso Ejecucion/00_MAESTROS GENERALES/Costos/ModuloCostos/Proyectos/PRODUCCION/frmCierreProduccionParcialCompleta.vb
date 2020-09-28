Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmCierreProduccionParcialCompleta


    Public Sub New(be As recursoCosto)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GridCFGDetetail(dgvCierres)
        GetLSVProductosEntregados(be)
        GetStatus()
        txtInicio.Value = New DateTime(AnioGeneral, MesGeneral, DiaLaboral.Day)
    End Sub



#Region "Mètodos"

    Sub CulminarOrden()
        Dim costo As recursoCosto
        Dim documento As documento
        Dim asiento As asiento
        Dim mov As movimiento
        Dim listaAsientos As List(Of asiento)
        Dim recursoSA As New recursoCostoSA

        documento = New documento With
        {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .idProyecto = Val(txtEntregable.Tag),
            .tipoDoc = "1",
            .fechaProceso = txtInicio.Value,
            .nroDoc = "0",
            .idOrden = 0,
            .tipoOperacion = "0",
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
            }

        costo = New recursoCosto
        costo.idCosto = Val(txtEntregable.Tag)
        costo.status = CInt(cboStatus.SelectedValue)

        listaAsientos = New List(Of asiento)

        asiento = New asiento
        asiento.idEmpresa = Gempresas.IdEmpresaRuc
        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
        asiento.fechaProceso = txtInicio.Value
        asiento.codigoLibro = "13"
        asiento.tipo = "D"
        asiento.tipoAsiento = "AS.D"
        asiento.importeMN = CDec(txtResumenTotal.Text)
        asiento.importeME = 0
        asiento.glosa = "Cierre de producción"
        asiento.usuarioActualizacion = usuario.IDUsuario
        asiento.fechaActualizacion = Date.Now
        listaAsientos.Add(asiento)

        If CDec(txtResumenTotal.Text) > 0 Then
            '1 Asiento
            mov = New movimiento
            mov.cuenta = "713"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "D"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

            mov = New movimiento
            mov.cuenta = "231"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "H"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

            '2º Asiento
            mov = New movimiento
            mov.cuenta = "92"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "D"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

            mov = New movimiento
            mov.cuenta = "791"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "H"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

            '3º Asiento
            mov = New movimiento
            mov.cuenta = "211"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "D"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

            mov = New movimiento
            mov.cuenta = "711"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "H"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

        ElseIf CDec(txtResumenTotal.Text) = 0 Then


        Else

            '1 Asiento
            mov = New movimiento
            mov.cuenta = "231"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "D"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)


            mov = New movimiento
            mov.cuenta = "713"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "H"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)


            '2º Asiento
            mov = New movimiento
            mov.cuenta = "791"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "D"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

            mov = New movimiento
            mov.cuenta = "92"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "H"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)


            '3º Asiento
            mov = New movimiento
            mov.cuenta = "711"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "D"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)


            mov = New movimiento
            mov.cuenta = "211"
            mov.descripcion = txtEntregable.Text.Trim
            mov.tipo = "H"
            mov.monto = CDec(txtResumenTotal.Text)
            mov.montoUSD = 0
            mov.usuarioActualizacion = usuario.IDUsuario
            mov.fechaActualizacion = Date.Now
            asiento.movimiento.Add(mov)

        End If


        documento.asiento = listaAsientos
        costo.CustomDocumento = documento

        recursoSA.CulminarOrdenProduccionParcial(costo)
        MessageBox.Show("Orden de producción culminada!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()

    End Sub

    Sub GetStatus()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(CInt(StatusProductosTerminados.Entregado), "Entrega normal")
        dt.Rows.Add(CInt(StatusProductosTerminados.Erroneo), "Entrega con Errores")
        dt.Rows.Add(CInt(StatusProductosTerminados.Observado), "Entrega con observaciones")

        cboStatus.ValueMember = "id"
        cboStatus.DisplayMember = "name"
        cboStatus.DataSource = dt
    End Sub

    Public Sub GetLSVProductosEntregados(be As recursoCosto)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)
        Dim dt As New DataTable
        Dim suma As Decimal = 0

        dt.Columns.Add("idcosto")
        dt.Columns.Add("fecha")
        dt.Columns.Add("detalle")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("costo")

        costo = costoSA.GetProductosProducidosEnPlanta(be)

        For Each i In costo
            suma += i.costo
            dt.Rows.Add(i.idCosto, i.inicio, i.detalle, i.cantidad, i.costo)
        Next
        txtEntregados.Text = suma.ToString("N2")
        dgvCierres.DataSource = dt

    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        CulminarOrden()
    End Sub

    Private Sub frmCierreProduccionParcialCompleta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtResumenTotal.Text = CDec(txtPlaneado.Text) - CDec(txtEntregados.Text)
    End Sub
End Class