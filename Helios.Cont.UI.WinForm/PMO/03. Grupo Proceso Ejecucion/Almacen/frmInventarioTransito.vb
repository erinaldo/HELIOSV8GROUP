Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmInventarioTransito
    Inherits frmMaster
    Dim savedCursor As Windows.Forms.Cursor

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        LoadEstablecimientos()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = PeriodoGeneral

        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        btnDistriNromal.Enabled = False
        LoadTipoExistencia()
    End Sub


#Region "Métodos"
    Private Sub LoadEstablecimientos()
        Dim estableSA As New establecimientoSA
        lstEstables.DisplayMember = "nombre"
        lstEstables.ValueMember = "idCentroCosto"
        lstEstables.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
    End Sub

    Sub LoadTipoExistencia()
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim lista As New List(Of String)
        lista.Add("PRODUCTO TERMINADO")
        lista.Add("ENVASES Y EMBALAJES")
        lista.Add("MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS")
        lista.Add("PRODUCTOS EN PROCESO")
        tabla = tablaSA.GetListaTablaDetalle(5, "1")

        Dim con = (From n In tabla _
                   Where Not lista.Contains(n.descripcion) _
                  Select n).ToList

        lstTipoExistencia.ValueMember = "codigoDetalle"
        lstTipoExistencia.DisplayMember = "descripcion"
        lstTipoExistencia.DataSource = con ' tablaSA.GetListaTablaDetalle(5, "1").Except(tabla)
    End Sub

    Private Sub colorearColumnas_Distribucion(ByVal listview1 As System.Windows.Forms.ListView)

        For i As Integer = 0 To listview1.Items.Count - 1

            listview1.Items(i).UseItemStyleForSubItems = False

            If listview1.Items(i).SubItems.Count > 1 Then
                listview1.Items(i).Checked = True
                listview1.Items(i).SubItems(0).BackColor = Color.WhiteSmoke

                listview1.Items(i).SubItems(1).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(1).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(2).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(2).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(3).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(3).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(4).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(4).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(7).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(7).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(8).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(8).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(9).BackColor = Color.DarkGoldenrod
                listview1.Items(i).SubItems(9).ForeColor = Color.White
                listview1.Items(i).SubItems(10).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(10).ForeColor = Color.DimGray

                listview1.Items(i).SubItems(11).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(11).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(12).BackColor = Color.SteelBlue
                listview1.Items(i).SubItems(12).ForeColor = Color.White
                listview1.Items(i).SubItems(13).BackColor = Color.Olive
                listview1.Items(i).SubItems(13).ForeColor = Color.White
                listview1.Items(i).SubItems(16).BackColor = Color.DimGray
                listview1.Items(i).SubItems(16).ForeColor = Color.LavenderBlush

                listview1.Items(i).SubItems(9).Font = New Font(listview1.Items(i).SubItems(8).Font.Size, 7.5, FontStyle.Bold, GraphicsUnit.Point)
                listview1.Items(i).SubItems(3).Font = New Font(listview1.Items(i).SubItems(6).Font.Size, 7.5, FontStyle.Italic, GraphicsUnit.Point)
                listview1.Items(i).SubItems(8).Font = New Font(listview1.Items(i).SubItems(6).Font.Size, 7.5, FontStyle.Italic, GraphicsUnit.Point)
                listview1.Items(i).SubItems(12).Font = New Font(listview1.Items(i).SubItems(10).Font.Size, 8, FontStyle.Regular, GraphicsUnit.Point)
                listview1.Items(i).SubItems(13).Font = New Font(listview1.Items(i).SubItems(11).Font.Size, 8, FontStyle.Regular, GraphicsUnit.Point)
                listview1.Items(i).SubItems(16).Font = New Font(listview1.Items(i).SubItems(12).Font.Size, 8, FontStyle.Regular, GraphicsUnit.Point)
                ', FontStyle.Bold)
                ' listview1.GridLines = True

            End If

        Next
    End Sub

    Public Sub ListadoItemsEnTransito(strMes As String, strAnio As String, strTipoEx As String)
        Dim inventarioBL As New inventarioMovimientoSA
        Dim totalesBL As New TotalesAlmacenSA

        lsvDistribucion.Columns.Clear()

        lsvDistribucion.Columns.Add("Origen", 50) ' 0
        lsvDistribucion.Columns.Add("Tipo Existencia", 0) ' 1
        lsvDistribucion.Columns.Add("IDAlmacen", 0) ' 2
        lsvDistribucion.Columns.Add("Almacen", 70, HorizontalAlignment.Left) ' 3
        lsvDistribucion.Columns.Add("IDDocumento", 0) ' 4

        lsvDistribucion.Columns.Add("IDProveedor", 0) ' 5
        lsvDistribucion.Columns.Add("Nombre/Razón Social", 360) ' 6

        lsvDistribucion.Columns.Add("IdItem", 0) ' 7
        lsvDistribucion.Columns.Add("Descripción Item", 229, HorizontalAlignment.Left) ' 8
        lsvDistribucion.Columns.Add("Cantidad", 60, HorizontalAlignment.Center) ' 9
        lsvDistribucion.Columns.Add("U.M.", 50, HorizontalAlignment.Center) ' 10
        lsvDistribucion.Columns.Add("Prec Unit.", 0) '11
        lsvDistribucion.Columns.Add("Importe soles", 100, HorizontalAlignment.Right) ' 12
        lsvDistribucion.Columns.Add("Importe Doláres", 100, HorizontalAlignment.Right) ' 13
        lsvDistribucion.Columns.Add("ID Inventario", 0) ' 14
        lsvDistribucion.Columns.Add("Cuenta", 0) ' 15
        lsvDistribucion.Columns.Add("Fecha compra", 90, HorizontalAlignment.Center) ' 16

        lsvDistribucion.Columns.Add("ComprobanteCompra", 0) ' 17
        lsvDistribucion.Columns.Add("Numero Comprobante", 0) ' 18
        lsvDistribucion.Columns.Add("TipoCambio", 0) ' 19
        lsvDistribucion.Columns.Add("Pr Unit USD", 0) ' 20
        lsvDistribucion.Columns.Add("Origen2", 0) ' 21
        lsvDistribucion.Columns.Add("Documento de referencia", 0) ' 22
        lsvDistribucion.Columns.Add("Evento", 50, HorizontalAlignment.Center) ' 23
        lsvDistribucion.Columns.Add("Origen", 70) ' 24
        lsvDistribucion.Columns.Add("Bonificacion", 140) ' 25
        lsvDistribucion.Columns.Add("Empaque", 0, HorizontalAlignment.Center) ' 26
        lsvDistribucion.Columns.Add("Fec Vcto", 40) ' 27
        lsvDistribucion.Columns.Add("NMB PRov", 0) ' 28
        lsvDistribucion.Columns.Add("Sec detalle", 30) ' 29
        lsvDistribucion.Columns.Add("TP", 50) ' 29

        lsvDistribucion.Items.Clear()
        For Each i In inventarioBL.ObtenerProductosEnTransito(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "AV", strMes, strAnio, strTipoEx)
            Dim n As New ListViewItem(i.destinoGravadoItem)
            n.SubItems.Add(i.tipoProducto)
            n.SubItems.Add(i.idAlmacen)
            n.SubItems.Add("ALM. VIRT") 'i.NombreAlmacen)
            n.SubItems.Add(i.idDocumento)
            n.SubItems.Add(i.IdProveedor)
            n.SubItems.Add(String.Concat(i.nombreProveedor, " | t/c: ", i.ComprobanteCompra, " | Nro: ", i.NumDocCompra))
            n.SubItems.Add(i.idItem)
            n.SubItems.Add(String.Concat(i.descripcion, " - ", i.NombrePresentacion))
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.unidad)
            n.SubItems.Add(FormatNumber(i.precUnite, 2))
            n.SubItems.Add(FormatNumber(i.monto, 2))
            n.SubItems.Add(FormatNumber(i.montoUSD, 2))
            n.SubItems.Add(i.idInventario)
            n.SubItems.Add(i.cuentaOrigen)
            n.SubItems.Add(FormatDateTime(i.fecha, DateFormat.GeneralDate))

            n.SubItems.Add(i.ComprobanteCompra)
            n.SubItems.Add(i.NumDocCompra)
            n.SubItems.Add(i.TipoCambio)
            n.SubItems.Add(FormatNumber(i.precUniteUSD, 2))
            n.SubItems.Add(i.destinoGravadoItem)
            n.SubItems.Add(i.idDocumentoRef)
            n.SubItems.Add(i.preEvento)
            n.SubItems.Add("INTERNO")
            n.SubItems.Add(i.glosa)
            n.SubItems.Add(i.presentacion)
            If IsNothing(i.fechavcto) Then
                n.SubItems.Add("N")
            Else
                n.SubItems.Add(i.fechavcto)
            End If
            n.SubItems.Add(i.nombreProveedor)
            n.SubItems.Add(i.Secuencia)
            n.SubItems.Add(i.tipoRegistro)
            lsvDistribucion.Items.Add(n)
        Next
        lblEstado.Text = "Registros Encontrados: " & Space(1) & lsvDistribucion.Items.Count
        colorearColumnas_Distribucion(lsvDistribucion)

    End Sub

    Public Sub ListadoItemsEnTransitoPorDocumento(strMes As String, strAnio As String, strTipoEx As String, strNumDoc As String)
        Dim inventarioBL As New inventarioMovimientoSA
        lsvDistribucion.Columns.Clear()

        lsvDistribucion.Columns.Add("Origen", 50) ' 0
        lsvDistribucion.Columns.Add("Tipo Existencia", 0) ' 1
        lsvDistribucion.Columns.Add("IDAlmacen", 0) ' 2
        lsvDistribucion.Columns.Add("Almacen", 70, HorizontalAlignment.Left) ' 3
        lsvDistribucion.Columns.Add("IDDocumento", 0) ' 4

        lsvDistribucion.Columns.Add("IDProveedor", 0) ' 5
        lsvDistribucion.Columns.Add("Nombre/Razón Social", 360) ' 6

        lsvDistribucion.Columns.Add("IdItem", 0) ' 7
        lsvDistribucion.Columns.Add("Descripción Item", 229, HorizontalAlignment.Left) ' 8
        lsvDistribucion.Columns.Add("Cantidad", 60, HorizontalAlignment.Center) ' 9
        lsvDistribucion.Columns.Add("U.M.", 50, HorizontalAlignment.Center) ' 10
        lsvDistribucion.Columns.Add("Prec Unit.", 0) '11
        lsvDistribucion.Columns.Add("Importe soles", 100, HorizontalAlignment.Right) ' 12
        lsvDistribucion.Columns.Add("Importe Doláres", 100, HorizontalAlignment.Right) ' 13
        lsvDistribucion.Columns.Add("ID Inventario", 0) ' 14
        lsvDistribucion.Columns.Add("Cuenta", 0) ' 15
        lsvDistribucion.Columns.Add("Fecha compra", 90, HorizontalAlignment.Center) ' 16

        lsvDistribucion.Columns.Add("ComprobanteCompra", 0) ' 17
        lsvDistribucion.Columns.Add("Numero Comprobante", 0) ' 18
        lsvDistribucion.Columns.Add("TipoCambio", 0) ' 19
        lsvDistribucion.Columns.Add("Pr Unit USD", 0) ' 20
        lsvDistribucion.Columns.Add("Origen2", 0) ' 21
        lsvDistribucion.Columns.Add("Documento de referencia", 0) ' 22
        lsvDistribucion.Columns.Add("Evento", 50, HorizontalAlignment.Center) ' 23
        lsvDistribucion.Columns.Add("Origen", 70) ' 24
        lsvDistribucion.Columns.Add("Bonificacion", 140) ' 25
        lsvDistribucion.Columns.Add("Empaque", 0, HorizontalAlignment.Center) ' 26
        lsvDistribucion.Columns.Add("Fec Vcto", 40) ' 27
        lsvDistribucion.Columns.Add("NMB PRov", 0) ' 28
        lsvDistribucion.Columns.Add("Sec detalle", 30) ' 29

        lsvDistribucion.Items.Clear()
        For Each i In inventarioBL.ObtenerProductosEnTransitoPorDocumento(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "AV", strMes, strAnio, strTipoEx, strNumDoc)
            Dim n As New ListViewItem(i.destinoGravadoItem)
            n.SubItems.Add(i.tipoProducto)
            n.SubItems.Add(i.idAlmacen)
            n.SubItems.Add("ALM. VIRT") 'i.NombreAlmacen)
            n.SubItems.Add(i.idDocumento)
            n.SubItems.Add(i.IdProveedor)
            n.SubItems.Add(String.Concat(i.nombreProveedor, " | t/c: ", i.ComprobanteCompra, " | Nro: ", i.NumDocCompra))
            n.SubItems.Add(i.idItem)
            n.SubItems.Add(String.Concat(i.descripcion, " - ", i.NombrePresentacion))
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.unidad)
            n.SubItems.Add(FormatNumber(i.precUnite, 2))
            n.SubItems.Add(FormatNumber(i.monto, 2))
            n.SubItems.Add(FormatNumber(i.montoUSD, 2))
            n.SubItems.Add(i.idInventario)
            n.SubItems.Add(i.cuentaOrigen)
            n.SubItems.Add(FormatDateTime(i.fecha, DateFormat.GeneralDate))

            n.SubItems.Add(i.ComprobanteCompra)
            n.SubItems.Add(i.NumDocCompra)
            n.SubItems.Add(i.TipoCambio)
            n.SubItems.Add(FormatNumber(i.precUniteUSD, 2))
            n.SubItems.Add(i.destinoGravadoItem)
            n.SubItems.Add(i.idDocumentoRef)
            n.SubItems.Add(i.preEvento)
            n.SubItems.Add("INTERNO")
            n.SubItems.Add(i.glosa)
            n.SubItems.Add(i.presentacion)
            If IsNothing(i.fechavcto) Then
                n.SubItems.Add("N")
            Else
                n.SubItems.Add(i.fechavcto)
            End If
            n.SubItems.Add(i.nombreProveedor)
            n.SubItems.Add(i.Secuencia)
            lsvDistribucion.Items.Add(n)
        Next
        lblEstado.Text = "Registros Encontrados: " & Space(1) & lsvDistribucion.Items.Count
        colorearColumnas_Distribucion(lsvDistribucion)

    End Sub
#End Region


    Private Sub btnDistriNromal_MouseEnter(sender As Object, e As System.EventArgs) Handles btnDistriNromal.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub btnDistriNromal_MouseLeave(sender As Object, e As System.EventArgs) Handles btnDistriNromal.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub btnDistribucionMasiva_Click(sender As System.Object, e As System.EventArgs) Handles btnDistribucionMasiva.Click
        Dim itemsBL As New itemSA
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        With frmDistribucionMasiva
            .lblPerido.Text = lblPerido.Text
            .cargarCombos("All")
            .StartPosition = FormStartPosition.CenterParent
            .dgvDistribucion.Rows.Clear()
            For Each item As ListViewItem In Me.lsvDistribucion.Items
                If item.Checked = True Then
                    .dgvDistribucion.Rows.Add(GEstableciento.IdEstablecimiento,
                                              "",
                                              GEstableciento.NombreEstablecimiento,
                                              "",
                                              item.SubItems(0).Text,
                                              item.SubItems(16).Text,
                                              "99",
                                              "0",
                                              "0",
                                              "NACIONAL",
                                              item.SubItems(7).Text,
                                              item.SubItems(8).Text,
                                              item.SubItems(9).Text,
                                              item.SubItems(10).Text,
                                              item.SubItems(1).Text,
                                              item.SubItems(11).Text,
                                              item.SubItems(12).Text,
                                              item.SubItems(20).Text,
                                              item.SubItems(13).Text,
                                              "D",
                                              item.SubItems(15).Text,
                                              item.SubItems(4).Text,
                                              item.SubItems(14).Text,
                                              item.SubItems(2).Text,
                                              item.SubItems(23).Text,
                                              IIf(Mid(item.SubItems(25).Text, 1, 1) = "B", "1", "0"),
                                              item.SubItems(26).Text,
                                              IIf(item.SubItems(27).Text = "N", Nothing, item.SubItems(27).Text),
                                              item.SubItems(5).Text,
                                              item.SubItems(6).Text,
                                              item.SubItems(29).Text,
                                              itemsBL.GetUbicaCategoriaItem_Utilidad(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, item.SubItems(7).Text))
                End If
                .contarMontos()
            Next
            .ShowDialog()
        End With
        If datos.Count > 0 Then
            If datos(0).Estado = "Grabado" Then
                lsvDistribucion.Items.Clear()
            End If
        End If
    End Sub

    Private Sub btnDistribucionMasiva_MouseEnter(sender As Object, e As System.EventArgs) Handles btnDistribucionMasiva.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub btnDistribucionMasiva_MouseLeave(sender As Object, e As System.EventArgs) Handles btnDistribucionMasiva.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub frmInventarioTransito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ''''''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    'Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
    '    Select Case cboPeriodo.Text
    '        Case "ENERO"
    '            lblPerido.Text = "01" & "/" & PeriodoGeneral
    '        Case "FEBRERO"
    '            lblPerido.Text = "02" & "/" & PeriodoGeneral
    '        Case "MARZO"
    '            lblPerido.Text = "03" & "/" & PeriodoGeneral
    '        Case "ABRIL"
    '            lblPerido.Text = "04" & "/" & PeriodoGeneral
    '        Case "MAYO"
    '            lblPerido.Text = "05" & "/" & PeriodoGeneral
    '        Case "JUNIO"
    '            lblPerido.Text = "06" & "/" & PeriodoGeneral
    '        Case "JULIO"
    '            lblPerido.Text = "07" & "/" & PeriodoGeneral
    '        Case "AGOSTO"
    '            lblPerido.Text = "08" & "/" & PeriodoGeneral
    '        Case "SETIEMBRE"
    '            lblPerido.Text = "09" & "/" & PeriodoGeneral
    '        Case "OCTUBRE"
    '            lblPerido.Text = "10" & "/" & PeriodoGeneral
    '        Case "NOVIEMBRE"
    '            lblPerido.Text = "11" & "/" & PeriodoGeneral
    '        Case "DICIEMBRE"
    '            lblPerido.Text = "12" & "/" & PeriodoGeneral
    '    End Select
    '    ContextMenuStrip1.Hide()
    '    Dim cfecha As Date = "01/" & lblPerido.Text
    '    ListadoItemsEnTransito(cfecha.Month, cfecha.Year, txtExistencia.ValueMember)

    'End Sub

    Private Sub frmInventarioTransito_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lsvDistribucion_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvDistribucion.MouseClick
        If e.Button = MouseButtons.Right Then
            If lsvDistribucion.FocusedItem.Bounds.Contains(e.Location) = True Then
                ContextMenuStrip3.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub lsvDistribucion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvDistribucion.SelectedIndexChanged

    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        For Each i As ListViewItem In lsvDistribucion.Items
            i.Checked = True
        Next
    End Sub

    Private Sub txtFiltroDoc_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtFiltroDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    If txtFiltroDoc.Text.Trim.Length > 0 Then
        '        Dim cfecha As Date = "01/" & lblPerido.Text
        '        ListadoItemsEnTransitoPorDocumento(cfecha.Month, cfecha.Year, lblIdTipoEx.Text, txtFiltroDoc.Text.Trim)
        '    End If
        'End If

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblEstablecimiento_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        ''''''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub lblPerido_Click_1(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblPerido_MouseUp1(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        'Dim p As Point = e.Location
        'p.Offset(lblPerido.Bounds.Location)
        'ContextMenuStrip1.Show(ToolStrip5.PointToScreen(p))
        'cboPeriodo.DroppedDown = True
    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv3.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstEstables.SelectedItems.Count > 0 Then
                Me.txtEstablecimiento.ValueMember = lstEstables.SelectedValue
                txtEstablecimiento.Text = lstEstables.Text
                '  ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtEstablecimiento.Focus()
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstTipoExistencia.SelectedItems.Count > 0 Then
                Me.txtExistencia.ValueMember = lstTipoExistencia.SelectedValue
                txtExistencia.Text = lstTipoExistencia.Text
                ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtExistencia.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        popupControlContainer1.Font = New Font("Segoe UI", 8)
        popupControlContainer1.Size = New Size(264, 109)
        Me.popupControlContainer1.ParentControl = Me.txtEstablecimiento
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        PopupControlContainer2.Font = New Font("Segoe UI", 8)
        PopupControlContainer2.Size = New Size(256, 109)
        Me.PopupControlContainer2.ParentControl = Me.txtExistencia
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub lstEstables_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEstables.MouseDoubleClick
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstEstables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEstables.SelectedIndexChanged

    End Sub

    Private Sub lstTipoExistencia_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstTipoExistencia.MouseDoubleClick
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub txtExistencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtExistencia.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer2.IsShowing() Then
                ' Let the popup align around the source textBox.
                PopupControlContainer2.Font = New Font("Segoe UI", 8)
                PopupControlContainer2.Size = New Size(256, 109)
                Me.PopupControlContainer2.ParentControl = Me.txtExistencia
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer2.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtExistencia_TextChanged(sender As Object, e As EventArgs) Handles txtExistencia.TextChanged

    End Sub

    Private Sub PopupControlContainer2_Popup(sender As Object, e As EventArgs) Handles PopupControlContainer2.Popup
        lstTipoExistencia.Focus()
    End Sub

    Private Sub txtEstablecimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEstablecimiento.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.popupControlContainer1.IsShowing() Then
                ' Let the popup align around the source textBox.
                popupControlContainer1.Font = New Font("Segoe UI", 8)
                popupControlContainer1.Size = New Size(264, 109)
                Me.popupControlContainer1.ParentControl = Me.txtEstablecimiento
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtEstablecimiento_TextChanged(sender As Object, e As EventArgs) Handles txtEstablecimiento.TextChanged

    End Sub

    Private Sub popupControlContainer1_Popup(sender As Object, e As EventArgs) Handles popupControlContainer1.Popup
        lstEstables.Focus()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Me.Cursor = Cursors.WaitCursor
        If txtExistencia.ValueMember.Trim.Length > 0 Then
            If lstTipoExistencia.SelectedItems.Count > 0 Then
                'Me.txtExistencia.ValueMember = lstTipoExistencia.SelectedValue
                'txtExistencia.Text = lstTipoExistencia.Text
                ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.ValueMember)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class