Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmListaPreciosExistencias
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        load_almacen()
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

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
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
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

#Region "Métodos"
    Private Sub EliminarLIsta()
        Dim listadoSA As New ListadoPrecioSA

        Dim nLista As New listadoPrecios With {
            .autoCodigo = lsvDetalle.SelectedItems(0).SubItems(26).Text}

        listadoSA.EliminarListadoPrecio(nLista)
        lsvDetalle.SelectedItems(0).Remove()
        lblEstado.Text = "Registro eliminado!"
        lblEstado.Image = My.Resources.ok4
    End Sub


    Private Sub load_almacen()
        Dim AlmacenSA As New almacenSA
        Try
            lstAlmacen.DataSource = AlmacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            lstAlmacen.DisplayMember = "descripcionAlmacen"
            lstAlmacen.ValueMember = "idAlmacen"
            lstAlmacen.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("No se puedo cargar la información para los combos" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerListaPorItem(intIdAlmacen As Integer, intItem As Integer)

        Dim objLista As New List(Of listadoPrecios)
        Dim listadoSA As New ListadoPrecioSA
        Dim objTablaSA As New tablaDetalleSA
        Dim objTabla As New tabladetalle
        Try
            objLista = listadoSA.ObtenerPrecioPorItem(intIdAlmacen, intItem)
            lsvDetalle.Columns.Clear()
            lsvDetalle.Items.Clear()

            lsvDetalle.Columns.Add("Tipo/ex", 0)
            lsvDetalle.Columns.Add("Destino", 0, HorizontalAlignment.Left)
            lsvDetalle.Columns.Add("IdItem", 0, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Descripcion", 0, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Presentación", 0, HorizontalAlignment.Center)
            lsvDetalle.Columns.Add("U.M.", 0, HorizontalAlignment.Center)

            lsvDetalle.Columns.Add("Fecha", 65, HorizontalAlignment.Center)
            lsvDetalle.Columns.Add("T/Conf", 30, HorizontalAlignment.Center)
            lsvDetalle.Columns.Add("Val.compra C/IGV", 60, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Val.compra sin/IGV", 60, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Utilidad", 38, HorizontalAlignment.Right)

            lsvDetalle.Columns.Add("Utilidad sin/IGV", 60, HorizontalAlignment.Right)

            lsvDetalle.Columns.Add("Valor de venta", 58, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("IGV 18%", 40, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("ISC", 38, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("OTC", 35, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Precio venta", 51, HorizontalAlignment.Right)
            'PRECIO X MENOR
            lsvDetalle.Columns.Add("Dscto %", 38, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Dscto Importe", 49, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Precio Vtafinal", 47, HorizontalAlignment.Right)
            'PRECIO X MAYOR
            lsvDetalle.Columns.Add("Dscto %", 38, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Dscto Importe", 49, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Precio Vtafinal", 47, HorizontalAlignment.Right)
            'PRECIO AL GRAN MAYOR
            lsvDetalle.Columns.Add("Dscto %", 38, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Dscto Importe", 49, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("Precio Vtafinal", 53, HorizontalAlignment.Right)
            lsvDetalle.Columns.Add("id", 2, HorizontalAlignment.Right)

            If objLista.Count > 0 Then
                If Not IsNothing(objLista(0).cantidadMenor) Then
                    lblCanMenor.Text = objLista(0).cantidadMenor
                End If
                If Not IsNothing(objLista(0).cantidadMayor) Then
                    lblCanMayor.Text = objLista(0).cantidadMayor
                End If
                If Not IsNothing(objLista(0).cantidadGMayor) Then
                    lblCanGmayor.Text = objLista(0).cantidadGMayor
                End If

                If Not IsNothing(objLista(0).detalleMenor) Then
                    objTabla = objTablaSA.GetUbicarTablaID(104, objLista(0).detalleMenor)
                    lblDetalleMenor.Text = objTabla.descripcion ' objLista(0).DetalleMenorels
                    lblIdMenor.Text = objLista(0).detalleMenor
                Else
                    lblDetalleMenor.Text = String.Empty
                    lblIdMenor.Text = String.Empty
                End If
                If Not IsNothing(objLista(0).detalleMayor) Then
                    objTabla = objTablaSA.GetUbicarTablaID(104, objLista(0).detalleMayor)
                    lblDetalleMayor.Text = objTabla.descripcion 'objLista(0).DetalleMayor
                    lblIdMayor.Text = objLista(0).detalleMayor
                Else
                    lblDetalleMayor.Text = String.Empty
                    lblIdMayor.Text = String.Empty
                End If
                If Not IsNothing(objLista(0).detalleGMayor) Then
                    objTabla = objTablaSA.GetUbicarTablaID(104, objLista(0).detalleGMayor)
                    lblDetalleGmayor.Text = objTabla.descripcion 'objLista(0).DetalleGMayor
                    lblIdGMayor.Text = objLista(0).detalleGMayor
                Else
                    lblDetalleGmayor.Text = String.Empty
                    lblIdGMayor.Text = String.Empty
                End If
            Else
                lblDetalleMenor.Text = String.Empty
                lblDetalleMayor.Text = String.Empty
                lblDetalleGmayor.Text = String.Empty

                lblIdMenor.Text = String.Empty
                lblIdMayor.Text = String.Empty
                lblIdGMayor.Text = String.Empty
            End If
            For Each i As listadoPrecios In objLista
                Dim n As New ListViewItem(i.tipoExistencia)
                n.SubItems.Add(i.destinoGravado)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.presentacion)
                n.SubItems.Add(i.unidad)
                n.SubItems.Add(i.fecha)
                n.SubItems.Add(IIf(i.tipoConfiguracion = "PC", "%", "Fijo"))
                n.SubItems.Add(i.valcompraIgvMN)
                n.SubItems.Add(i.valcompraSinIgvMN)
                n.SubItems.Add(i.montoUtilidad)
                n.SubItems.Add(i.utilidadsinIgvMN)
                n.SubItems.Add(i.valorVentaMN)
                n.SubItems.Add(i.igvMN)
                n.SubItems.Add(i.iscMN)
                n.SubItems.Add(i.otcMN)
                n.SubItems.Add(i.precioVentaMN)
                'PRECIOS AL POR MENOR
                n.SubItems.Add(i.PorDsctounitMenor)
                n.SubItems.Add(i.montoDsctounitMenorMN)
                n.SubItems.Add(i.precioVentaFinalMenorMN)
                'PRECIOS AL POR MAYOR
                n.SubItems.Add(i.PorDsctounitMayor)
                n.SubItems.Add(i.montoDsctounitMayorMN)
                n.SubItems.Add(i.precioVentaFinalMayorMN)
                'PRECIOS AL GRAN MAYOR
                n.SubItems.Add(i.PorDsctounitGMayor)
                n.SubItems.Add(i.montoDsctounitGMayorMN)
                n.SubItems.Add(i.precioVentaFinalGMayorMN)
                n.SubItems.Add(i.autoCodigo)
                lsvDetalle.Items.Add(n)
            Next

        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub ObtenerListadoPrecios(intIdAlmacen As Integer)

        Dim totalesSA As New TotalesAlmacenSA
        Try
            lsvListado.Columns.Clear()
            lsvListado.Items.Clear()
            lsvListado.Columns.Add("IdEmpresa", 0) '0
            lsvListado.Columns.Add("IdEstablecimiento", 0) '1
            lsvListado.Columns.Add("Almacén", 0) '2
            lsvListado.Columns.Add("Destino", 40) '3
            lsvListado.Columns.Add("Tipo Existencia", 70, HorizontalAlignment.Center) '4
            lsvListado.Columns.Add("ID Item", 0) '5
            lsvListado.Columns.Add("Descripcion", 200, HorizontalAlignment.Left) '6
            lsvListado.Columns.Add("Presentación", 70, HorizontalAlignment.Center) '7
            lsvListado.Columns.Add("U.M.", 70, HorizontalAlignment.Center) '8
            lsvListado.Columns.Add("Cant.", 85, HorizontalAlignment.Center) '9
            lsvListado.Columns.Add("Impórte", 85, HorizontalAlignment.Center) '10
            lsvListado.Columns.Add("P.M.", 70, HorizontalAlignment.Center) '11

            For Each i As totalesAlmacen In totalesSA.GetListaProductosPorAlmacen(intIdAlmacen)
                Dim n As New ListViewItem(i.idEmpresa)
                n.SubItems.Add(i.idEstablecimiento)
                n.SubItems.Add(i.idAlmacen)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.Presentacion)
                n.SubItems.Add(i.unidadMedida)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2))
                Else
                    n.SubItems.Add(0)
                End If
                lsvListado.Items.Add(n)
            Next
            For Each item As ListViewItem In lsvListado.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub ObtenerListadoPreciosLiked(intIdAlmacen As Integer, strBusqueda As String)

        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvListado.Columns.Clear()
            lsvListado.Items.Clear()
            lsvListado.Columns.Add("IdEmpresa", 0) '0
            lsvListado.Columns.Add("IdEstablecimiento", 0) '1
            lsvListado.Columns.Add("Almacén", 0) '2
            lsvListado.Columns.Add("Destino", 40) '3
            lsvListado.Columns.Add("Tipo Existencia", 70, HorizontalAlignment.Center) '4
            lsvListado.Columns.Add("ID Item", 0) '5
            lsvListado.Columns.Add("Descripcion", 200, HorizontalAlignment.Left) '6
            lsvListado.Columns.Add("Presentación", 70, HorizontalAlignment.Center) '7
            lsvListado.Columns.Add("U.M.", 70, HorizontalAlignment.Center) '8
            lsvListado.Columns.Add("Cant.", 85, HorizontalAlignment.Center) '9
            lsvListado.Columns.Add("Impórte", 85, HorizontalAlignment.Center) '10
            lsvListado.Columns.Add("P.M.", 70, HorizontalAlignment.Center) '11

            For Each i As totalesAlmacen In totalSA.GetListaProductosTAPorProducto(intIdAlmacen, strBusqueda)
                Dim n As New ListViewItem(i.idEmpresa)
                n.SubItems.Add(i.idEstablecimiento)
                n.SubItems.Add(i.idAlmacen)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.Presentacion)
                n.SubItems.Add(i.unidadMedida)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2))
                Else
                    n.SubItems.Add(0)
                End If
                lsvListado.Items.Add(n)
            Next
            For Each item As ListViewItem In lsvListado.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

#End Region

#Region "SORTED LISTVIEW"
    Public Class NomedaClasse

        Implements IComparer

        Public Enum SortOrder

            Ascending
            Descending

        End Enum

        Private mSortColumn As Integer

        Private mSortOrder As SortOrder

        Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)

            mSortColumn = sortColumn
            mSortOrder = sortOrder

        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim Result As Integer
            Dim ItemX As ListViewItem
            Dim ItemY As ListViewItem

            ItemX = CType(x, ListViewItem)
            ItemY = CType(y, ListViewItem)

            If mSortColumn = 0 Then
                Result = DateTime.Compare(CType(ItemX.Text, DateTime), CType(ItemY.Text, DateTime))
            Else
                Result = DateTime.Compare(CType(ItemX.SubItems(mSortColumn).Text, DateTime), CType(ItemY.SubItems(mSortColumn).Text, DateTime))
            End If

            If mSortOrder = SortOrder.Descending Then
                Result = -Result
            End If

            Return Result

        End Function

    End Class

    Public Class ListViewStringSort

        Implements IComparer

        Private mSortColumn As Integer
        Private mSortOrder As SortOrder

        Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)

            mSortColumn = sortColumn
            mSortOrder = sortOrder

        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim Result As Integer
            Dim ItemX As ListViewItem
            Dim ItemY As ListViewItem

            ItemX = CType(x, ListViewItem)
            ItemY = CType(y, ListViewItem)

            If mSortColumn = 0 Then
                Result = ItemX.Text.CompareTo(ItemY.Text)
            Else
                Result = ItemX.SubItems(mSortColumn).Text.CompareTo(ItemY.SubItems(mSortColumn).Text)
            End If

            If mSortOrder = SortOrder.Descending Then
                Result = -Result
            End If

            Return Result

        End Function

    End Class

    Public Class ListViewNumericSort

        Implements IComparer

        Private mSortColumn As Integer

        Private mSortOrder As SortOrder

        Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)

            mSortColumn = sortColumn
            mSortOrder = sortOrder

        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim Result As Integer
            Dim ItemX As ListViewItem
            Dim ItemY As ListViewItem

            ItemX = CType(x, ListViewItem)
            ItemY = CType(y, ListViewItem)

            If mSortColumn = 0 Then
                Result = Decimal.Compare(CType(ItemX.Text, Decimal), CType(ItemY.Text, Decimal))
            Else
                Result = Decimal.Compare(CType(ItemX.SubItems(mSortColumn).Text, Decimal), CType(ItemY.SubItems(mSortColumn).Text, Decimal))
            End If

            If mSortOrder = SortOrder.Descending Then
                Result = -Result
            End If

            Return Result

        End Function

    End Class

    Public Class ListViewDateSort

        Implements IComparer

        Private mSortColumn As Integer
        Private mSortOrder As SortOrder

        Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)

            mSortColumn = sortColumn
            mSortOrder = sortOrder

        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim Result As Integer
            Dim ItemX As ListViewItem
            Dim ItemY As ListViewItem

            ItemX = CType(x, ListViewItem)
            ItemY = CType(y, ListViewItem)

            If mSortColumn = 0 Then
                Result = DateTime.Compare(CType(ItemX.Text, DateTime), CType(ItemY.Text, DateTime))
            Else
                Result = DateTime.Compare(CType(ItemX.SubItems(mSortColumn).Text, DateTime), CType(ItemY.SubItems(mSortColumn).Text, DateTime))
            End If

            If mSortOrder = SortOrder.Descending Then
                Result = -Result
            End If

            Return Result

        End Function

    End Class

    Friend Sub SortMyListView(ByVal ListViewToSort As ListView, ByVal ColumnNumber As Integer, Optional ByVal Resort As Boolean = False, Optional ByVal ForceSort As Boolean = False)

        Dim SortOrder As SortOrder
        Static LastSortColumn As Integer = -1
        Static LastSortOrder As SortOrder = SortOrder.Ascending

        If Resort = True Then
            SortOrder = LastSortOrder
        Else
            If LastSortColumn = ColumnNumber Then
                If LastSortOrder = SortOrder.Ascending Then
                    SortOrder = SortOrder.Descending
                Else
                    SortOrder = SortOrder.Ascending
                End If
            Else
                SortOrder = SortOrder.Ascending
            End If
        End If
        If String.IsNullOrEmpty(CStr(ListViewToSort.Columns(ColumnNumber).Tag)) Then
            If ForceSort = True Then
                ListViewToSort.Columns(ColumnNumber).Tag = "String"
            Else
                Exit Sub
            End If

        End If

        Select Case ListViewToSort.Columns(ColumnNumber).Tag.ToString
            Case "Numeric"
                ListViewToSort.ListViewItemSorter = New ListViewNumericSort(ColumnNumber, SortOrder)
            Case "Date"
                ListViewToSort.ListViewItemSorter = New ListViewDateSort(ColumnNumber, SortOrder)
            Case "String"
                ListViewToSort.ListViewItemSorter = New ListViewStringSort(ColumnNumber, SortOrder)
        End Select

        LastSortColumn = ColumnNumber
        LastSortOrder = SortOrder
        ListViewToSort.ListViewItemSorter = Nothing

    End Sub
#End Region

    Private Sub frmListaPreciosExistencias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmListaPreciosExistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cboGravado.SelectedItem = "1"
        'lblIdEmpresa.Text = CEmpresa
        'lblNameEmpresa.Text = CNombreEmpresa
        'lblIdEstable.Text = CEstablecimiento
        'lblNameEstable.Text = CNombreEstablecimiento

    End Sub

    Private Sub NuevoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub lsvListado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvListado.ColumnClick
        SortMyListView(Me.lsvListado, e.Column, , True)
    End Sub

    Public Sub lsvListado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvListado.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If lsvListado.SelectedItems.Count > 0 Then
            ObtenerListaPorItem(txtAlmacen.ValueMember, lsvListado.SelectedItems(0).SubItems(5).Text)
        Else

            lsvDetalle.Items.Clear()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs)
        ''''''frmPMO.Panel3.Width = 249
        'Dispose()
    End Sub

    Private Sub AyudaToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AyudaToolStripButton.Click
        If lsvDetalle.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarLIsta()
            End If
        End If
    End Sub

    Private Sub NuevoToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvListado.SelectedItems.Count > 0 Then
            lsvListado.FocusedItem.EnsureVisible()
            With frmTablaPrecios
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
            'With (frmNuevaListaPrecio)
            '    .CargraCombos()
            '    If lsvDetalle.Items.Count > 0 Then
            '        .cbomenor.Enabled = False
            '        .cboMayor.Enabled = False
            '        .cboGranMayor.Enabled = False
            '        .cbomenor.SelectedValue = lblIdMenor.Text
            '        .cboMayor.SelectedValue = lblIdMayor.Text
            '        .cboGranMayor.SelectedValue = lblIdGMayor.Text
            '        .nudMenor.Value = lblCanMenor.Text
            '        .nudMayor.Value = lblCanMayor.Text
            '        .nudGMayor.Value = lblCanGmayor.Text
            '        .nudMenor.Enabled = False
            '        .nudMayor.Enabled = False
            '        .nudGMayor.Enabled = False
            '    Else
            '        .cbomenor.Enabled = True
            '        .cboMayor.Enabled = True
            '        .cboGranMayor.Enabled = True
            '        .nudMenor.Enabled = True
            '        .nudMayor.Enabled = True
            '        .nudGMayor.Enabled = True
            '    End If
            '    .lblDestino.Text = lsvListado.SelectedItems(0).SubItems(3).Text
            '    .lblNombreItem.Text = lsvListado.SelectedItems(0).SubItems(6).Text
            '    .lblPresentacion.Text = lsvListado.SelectedItems(0).SubItems(7).Text
            '    .lblUnidad.Text = lsvListado.SelectedItems(0).SubItems(8).Text
            '    .lbltipoEx.Text = lsvListado.SelectedItems(0).SubItems(4).Text
            '    .nudVCsinIGVMN.Value = lsvListado.SelectedItems(0).SubItems(11).Text
            '    .IdAlmacen = txtAlmacen.ValueMember
            '    .IdItem = lsvListado.SelectedItems(0).SubItems(5).Text
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            '    lsvListado_SelectedIndexChanged(sender, e)
            'End With
        Else
            lblEstado.Text = "Por favor, Seleccione un item"
            lblEstado.Image = My.Resources.warning2
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If txtAlmacen.Text.Trim.Length > 0 Then
                If txtFiltro.Text.Trim.Length > 0 Then
                    ObtenerListadoPreciosLiked(txtAlmacen.ValueMember, txtFiltro.Text.Trim)
                Else
                    lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                End If
            Else
                lblEstado.Text = "Debe elegir un alamacen"
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If

        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
                ObtenerListadoPrecios(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub
End Class