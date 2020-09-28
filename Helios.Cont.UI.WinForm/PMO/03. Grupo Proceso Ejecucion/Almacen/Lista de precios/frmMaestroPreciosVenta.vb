Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.ComponentModel

Public Class frmMaestroPreciosVenta
    Inherits frmMaster

    'Private bgWorker As BackgroundWorker
    Private IsExpanded As Boolean
    Private result As Double = 0.0


    'Public Property IdAlmacen() As Integer
    'Public Property NombreAlmacen() As String
    Public Property intIdAlmacen2() As Integer
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        intIdAlmacen2 = TmpIdAlmacen
        ' Add any initialization after the InitializeComponent() call.
        '  ListadoItems(intIdAlmacen)
        lblPerido.Text = PeriodoGeneral
        filters()
    End Sub

#Region "Métodos"

    Public Sub ListadoItems(intIdAlmacen As Integer)
        Dim listadoPreciosSA As New ListadoPrecioSA
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoExistencia", GetType(String))

        dt.Columns.Add("vc", GetType(Decimal))
        dt.Columns.Add("porcUtimenor", GetType(Decimal))
        dt.Columns.Add("montoUtimenor", GetType(Decimal))
        dt.Columns.Add("pvmenor", GetType(Decimal))

        dt.Columns.Add("vc2", GetType(Decimal))
        dt.Columns.Add("porcUtimayor", GetType(Decimal))
        dt.Columns.Add("montoUtimayor", GetType(Decimal))
        dt.Columns.Add("pvmayor", GetType(Decimal))

        dt.Columns.Add("vc3", GetType(Decimal))
        dt.Columns.Add("porcUtigranmayor", GetType(Decimal))
        dt.Columns.Add("montoUtigranmayor", GetType(Decimal))
        dt.Columns.Add("pvgranmayor", GetType(Decimal))

        dt.Columns.Add("Stock", GetType(Decimal))

        dt.Columns.Add("colnuevo", GetType(String))
        dt.Columns.Add("colEditar", GetType(String))

        Dim str As String
        For Each i In listadoPreciosSA.UbicarPVxListadoItems(intIdAlmacen)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            If Not IsNothing(i.fecha) Then
                str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            End If

            dr(0) = i.autoCodigo
            dr(1) = str
            dr(2) = i.destinoGravado
            dr(3) = i.idItem
            dr(4) = i.descripcion
            dr(5) = i.tipoExistencia

            dr(6) = i.vcmenor.GetValueOrDefault
            dr(7) = i.porcUtimenor.GetValueOrDefault
            dr(8) = i.montoUtimenor.GetValueOrDefault
            dr(9) = i.pvmenor.GetValueOrDefault

            dr(10) = i.vcmayor.GetValueOrDefault
            dr(11) = i.porcUtimayor.GetValueOrDefault
            dr(12) = i.montoUtimayor.GetValueOrDefault
            dr(13) = i.pvmayor.GetValueOrDefault

            dr(14) = i.vcgranmayor.GetValueOrDefault
            dr(15) = i.porcUtigranmayor.GetValueOrDefault
            dr(16) = i.montoUtigranmayor.GetValueOrDefault
            dr(17) = i.pvgranmayor.GetValueOrDefault

            dr(18) = i.stock.GetValueOrDefault

            dr(19) = "nuevo"
            dr(20) = "editar"

            'dr(18) = "nuevo"
            'dr(19) = "editar"
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
        Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'dgvCompra.RecordNavigationControl.MinRecord = 0
        'dgvCompra.RecordNavigationControl.ResetMinRecord()
        'dgvCompra.RecordNavigationControl.ResetMaxRecord()
        ' dgvCompra.RecordNavigationBar.MoveFirst()
        'Dim pager = New Pager
        'pager.PageSize = 1

        'pager.Wire(dgvCompra, dt)
        'dgvCompra.RecordNavigationBar.MoveFirst()
        'dgvCompra.RecordNavigationBar.ResetText()
        '   dgvCompra.RecordNavigationControl.NavigationBar.ResetText()
        'dgvCompra.RecordNavigationControl.NavigationBar.()
    End Sub
#End Region

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

    Private Sub frmMaestroPreciosVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMaestroPreciosVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblEmpresa.Text = Gempresas.NomEmpresa
        lblestablecimiento.Text = GEstableciento.NombreEstablecimiento
        lblalmacen.Text = TmpNombreAlmacen
        'martin

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 9
                    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 13, GridSetCurrentCellOptions.SetFocus)

                Case 13
                    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 17, GridSetCurrentCellOptions.SetFocus)
                    'Case 16
                    '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 16, GridSetCurrentCellOptions.SetFocus)
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvCompra.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 19 Then
                e.Inner.Style.Description = "btMuevo"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
            If e.Inner.ColIndex = 20 Then
                e.Inner.Style.Description = "btEditar"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(4), irect)
            End If

            If e.Inner.ColIndex = 21 Then
                e.Inner.Style.Description = "btElimi"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(2), irect)
            End If

            If e.Inner.ColIndex = 22 Then
                e.Inner.Style.Description = "btRefresh"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(3), irect)
            End If

        End If

    End Sub

    Private Sub EliminarPV(intIdCodigo As Integer)
        Dim listadoSA As New ListadoPrecioSA

        Dim nLista As New listadoPrecios With {
            .autoCodigo = intIdCodigo}

        listadoSA.EliminarListadoPrecio(nLista)
        ' Me..Table.CurrentRecord.Delete()
        'lblEstado.Text = "Registro eliminado!"
        'lblEstado.Image = My.Resources.ok4
    End Sub

    Sub filters()
        Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
        'Enable the filter for each columns 
        '   For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
        dgvCompra.TableDescriptor.Columns("descripcion").AllowFilter = True
        '   Next
        filter.WireGrid(dgvCompra)
    End Sub

    Private Sub dgvCompra_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles dgvCompra.TableControlPrepareViewStyleInfo
        If (e.Inner.ColIndex > 0) AndAlso (e.Inner.ColIndex < 7) Then
            e.Inner.Style.CellTipText = e.Inner.Style.Text
        End If
    End Sub

    'Public Sub MostrarUltimoPrecioItem(ByVal intIdAlmacen As Integer, ByVal intIdItem As Integer)

    '    Dim listadoSA As New ListadoPrecioSA
    '    Dim items As New listadoPrecios
    '    items = listadoSA.UbicarPVxItem(intIdAlmacen, intIdItem)

    '    If (Not IsNothing(items.fecha)) Then

    '        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '        'Me.dgvCompra.Table.Records(0).SetValue("codigo", items.autoCodigo)
    '        'Me.dgvCompra.Table.Records(0).SetValue("fecha", items.fecha)



    '        Me.dgvCompra.Table.Records(0).SetValue("vc", items.vcmenor)
    '        Me.dgvCompra.Table.Records(0).SetValue("porcUtimenor", items.porcUtimenor)
    '        Me.dgvCompra.Table.Records(0).SetValue("montoUtimenor", items.montoUtimenor)
    '        Me.dgvCompra.Table.Records(0).SetValue("precVenta", items.pvmenor)

    '        Me.dgvCompra.Table.Records(0).SetValue("vc2", items.vcmenor)
    '        Me.dgvCompra.Table.Records(0).SetValue("porcUtimayor", items.porcUtimayor)
    '        Me.dgvCompra.Table.Records(0).SetValue("montoUtimayor", items.montoUtimayor)
    '        Me.dgvCompra.Table.Records(0).SetValue("pvmayor", items.pvmayor)

    '        Me.dgvCompra.Table.Records(0).SetValue("vc3", items.vcmenor)
    '        Me.dgvCompra.Table.Records(0).SetValue("porcUtigranmayor", items.porcUtigranmayor)
    '        Me.dgvCompra.Table.Records(0).SetValue("montoUtigranmayor", items.montoUtigranmayor)
    '        Me.dgvCompra.Table.Records(0).SetValue("pvgranmayor", items.pvgranmayor)

    '        Me.dgvCompra.Table.AddNewRecord.EndEdit()

    '    End If


    'End Sub

    Private Sub dgvCompra_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvCompra.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor

        Dim TC As Decimal = TmpTipoCambio
        Dim objConfiEO As New listadoPrecios
        Dim ListadoSA As New ListadoPrecioSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim ListaPrecioFull As New List(Of listadoPrecios)

        Dim tipoExistencia As String
        Dim destinoGravado As String
        Dim presentacion As String
        Dim unidad As String

        Dim items As New listadoPrecios
        Try
            If e.Inner.ColIndex = 19 Then
                'Dim f As New frmTablaPrecios
                'f.txtAlmacenDestino.ValueMember = IdAlmacen
                'f.txtAlmacenDestino.Text = NombreAlmacen
                'f.txtDestino.Text = Me.dgvCompra.TableModel(e.Inner.RowIndex, 2).CellValue ' Me.dgvCompra.Table.Records(e.Inner.RowIndex).GetValue("gravado")
                'f.txtProducto.Text = Me.dgvCompra.TableModel(e.Inner.RowIndex, 4).CellValue
                'f.txtProducto.ValueMember = Me.dgvCompra.TableModel(e.Inner.RowIndex, 3).CellValue
                'f.txtTipoCambio.Value = TmpTipoCambio
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
                If CDec(Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue) > 0 Then
                    With totalesAlmacenSA.GetUbicarProductoTAlmacen(TmpIdAlmacen, Me.dgvCompra.TableModel(e.Inner.RowIndex, 3).CellValue)
                        tipoExistencia = .tipoExistencia
                        destinoGravado = .origenRecaudo
                        presentacion = .Presentacion
                        unidad = Nothing ' lblUnidad.Text
                    End With

                    objConfiEO = New listadoPrecios
                    With objConfiEO
                        .idEmpresa = Gempresas.IdEmpresaRuc
                        .idEstablecimiento = GEstableciento.IdEstablecimiento
                        .tipoExistencia = tipoExistencia
                        .destinoGravado = destinoGravado
                        .idItem = Me.dgvCompra.TableModel(e.Inner.RowIndex, 3).CellValue
                        .descripcion = Me.dgvCompra.TableModel(e.Inner.RowIndex, 4).CellValue
                        .presentacion = presentacion
                        .unidad = Nothing ' lblUnidad.Text
                        .fecha = DateTime.Now
                        .tipoConfiguracion = "F"
                        .porcUtimenor = 0
                        .porcUtimayor = 0
                        .porcUtigranmayor = 0

                        .vcmenor = 0
                        .vcmenorme = 0

                        .vcmayor = 0
                        .vcmayorme = 0

                        .vcgranmayor = 0
                        .vcgranmayorme = 0

                        .montoUtimenor = 0
                        .montoUtimenorme = 0

                        .montoUtimayor = 0
                        .montoUtimayorme = 0

                        .montoUtigranmayor = 0
                        .montoUtigranmayorme = 0

                        .vvmenor = 0
                        .vvmenorme = 0

                        .vvmayor = 0
                        .vvmayorme = 0

                        .vvgranmayor = 0
                        .vvgranmayorme = 0

                        .igvmenor = 0
                        .igvmenormeme = 0

                        .igvmayor = 0
                        .igvmayormeme = 0

                        .igvgranmayor = 0
                        .igvgranmayorme = 0

                        .pvmenor = Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue
                        .pvmenorme = Math.Round(Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue / TmpTipoCambio, 2)

                        .pvmayor = Me.dgvCompra.TableModel(e.Inner.RowIndex, 13).CellValue
                        .pvmayorme = Math.Round(Me.dgvCompra.TableModel(e.Inner.RowIndex, 13).CellValue / TmpTipoCambio, 2)

                        .pvgranmayor = Me.dgvCompra.TableModel(e.Inner.RowIndex, 17).CellValue
                        .pvgranmayorme = Math.Round(Me.dgvCompra.TableModel(e.Inner.RowIndex, 17).CellValue / TmpTipoCambio, 2)
                    End With

                    Dim cod = ListadoSA.InsertarPrecioVV(objConfiEO)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", cod)
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 1).CellValue = DateTime.Now.ToString("dd-MMM-yy HH:mm tt ")
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue = Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 13).CellValue = Me.dgvCompra.TableModel(e.Inner.RowIndex, 13).CellValue
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 17).CellValue = Me.dgvCompra.TableModel(e.Inner.RowIndex, 17).CellValue
                Else
                    MessageBox.Show("Debe ingresar un precio de venta mayor a cero", "Atención", Nothing, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If



            ElseIf e.Inner.ColIndex = 20 Then


                With frmHistorialPrecioVenta
                    '.txtProducto.Text = txtFiltro.Text ' lsvListado.SelectedItems(0).SubItems(6).Text
                    '.txtAlamcen.Text = txtAlmacen.Text
                    '.txtAlamcen.ValueMember = txtAlmacen.ValueMember
                    '.txtDestino.Text = lsvListado.SelectedItems(0).SubItems(3).Text



                    .txtProducto.Text = Me.dgvCompra.TableModel(e.Inner.RowIndex, 4).CellValue

                    Dim almacen As New almacenSA
                    Dim namealm As almacen

                    namealm = almacen.GetUbicar_almacenPorID(TmpIdAlmacen)

                    .txtAlamcen.Text = namealm.descripcionAlmacen

                    .txtDestino.Visible = False
                    .ObtenerListaPorAlmacenPorProducto(TmpIdAlmacen, Me.dgvCompra.TableModel(e.Inner.RowIndex, 3).CellValue, "SIVA")
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Maximized
                    .ShowDialog()
                End With

                'MsgBox("editar")
            ElseIf e.Inner.ColIndex = 21 Then
                If CDec(Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue) > 0 Then
                    If Me.dgvCompra.TableModel(e.Inner.RowIndex, 23).CellValue > 0 Then
                        If MessageBoxAdv.Show("Desea eliminar el precio configurado actual?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            EliminarPV(Me.dgvCompra.TableModel(e.Inner.RowIndex, 23).CellValue)
                            'cambiamdo
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 1).CellValue = Nothing
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 6).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 7).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 8).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue = 0

                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 10).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 11).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 12).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 13).CellValue = 0

                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 14).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 15).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 17).CellValue = 0
                            Me.dgvCompra.TableModel(e.Inner.RowIndex, 23).CellValue = 0
                        End If
                    End If
                End If
            ElseIf e.Inner.ColIndex = 22 Then
                items = ListadoSA.UbicarPVxItem(TmpIdAlmacen, Me.dgvCompra.TableModel(e.Inner.RowIndex, 3).CellValue)

                If (Not IsNothing(items.fecha)) Then
                    Dim fec As String = Nothing
                    fec = CDate(items.fecha).ToString("dd-MMM-yy hh:mm tt ")
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 1).CellValue = fec
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 6).CellValue = items.vcmenor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 7).CellValue = items.porcUtimenor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 8).CellValue = items.montoUtimenor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue = items.pvmenor

                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 10).CellValue = items.vcmayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 11).CellValue = items.porcUtimayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 12).CellValue = items.montoUtimayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 13).CellValue = items.pvmayor

                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 14).CellValue = items.vcmayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 15).CellValue = items.porcUtigranmayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = items.montoUtigranmayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 17).CellValue = items.pvgranmayor
                    Me.dgvCompra.TableModel(e.Inner.RowIndex, 23).CellValue = items.autoCodigo
                End If
            ElseIf e.Inner.ColIndex = 23 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStrip3_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    'Private Class packageFormatGrid
    '    Public dt As DataTable 'Data to set to the grid
    '    Public dgv1 As GridGroupingControl  'Data grid
    'End Class

    'Private Sub CallFormat(ByRef dt As DataTable)
    '    Dim package As New packageFormatGrid
    '    package.dt = dt
    '    package.dgv1 = dgvCompra
    '    BackgroundWorker1.RunWorkerAsync(package)
    'End Sub

    Sub LoadDT(dt As DataTable)
        Dim listadoPreciosSA As New ListadoPrecioSA

        dt.Columns.Add("codigo", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoExistencia", GetType(String))

        dt.Columns.Add("vc", GetType(Decimal))
        dt.Columns.Add("porcUtimenor", GetType(Decimal))
        dt.Columns.Add("montoUtimenor", GetType(Decimal))
        dt.Columns.Add("pvmenor", GetType(Decimal))

        dt.Columns.Add("vc2", GetType(Decimal))
        dt.Columns.Add("porcUtimayor", GetType(Decimal))
        dt.Columns.Add("montoUtimayor", GetType(Decimal))
        dt.Columns.Add("pvmayor", GetType(Decimal))

        dt.Columns.Add("vc3", GetType(Decimal))
        dt.Columns.Add("porcUtigranmayor", GetType(Decimal))
        dt.Columns.Add("montoUtigranmayor", GetType(Decimal))
        dt.Columns.Add("pvgranmayor", GetType(Decimal))
        dt.Columns.Add("colnuevo", GetType(String))
        dt.Columns.Add("colEditar", GetType(String))

        Dim str As String
        For Each i In listadoPreciosSA.UbicarPVxListadoItems(TmpIdAlmacen)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            If Not IsNothing(i.fecha) Then
                str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            End If

            dr(0) = i.autoCodigo
            dr(1) = str
            dr(2) = i.destinoGravado
            dr(3) = i.idItem
            dr(4) = i.descripcion
            dr(5) = i.tipoExistencia

            dr(6) = i.vcmenor.GetValueOrDefault
            dr(7) = i.porcUtimenor.GetValueOrDefault
            dr(8) = i.montoUtimenor.GetValueOrDefault
            dr(9) = i.pvmenor.GetValueOrDefault

            dr(10) = i.vcmayor.GetValueOrDefault
            dr(11) = i.porcUtimayor.GetValueOrDefault
            dr(12) = i.montoUtimayor.GetValueOrDefault
            dr(13) = i.pvmayor.GetValueOrDefault

            dr(14) = i.vcgranmayor.GetValueOrDefault
            dr(15) = i.porcUtigranmayor.GetValueOrDefault
            dr(16) = i.montoUtigranmayor.GetValueOrDefault
            dr(17) = i.pvgranmayor.GetValueOrDefault
            dr(18) = "nuevo"
            dr(19) = "editar"
            dt.Rows.Add(dr)
        Next
    End Sub


    Private Sub frmMaestroPreciosVenta_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Cursor = Cursors.WaitCursor
        Dim statusForm As New FeedbackForm()
        statusForm.Tag = "CEX"
        'statusForm.Show("PROCESANDO ITEMS...!")
        ListadoItems(TmpIdAlmacen)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim detalleItem As New detalleitems
        Dim detalleItemSA As New detalleitemsSA
        Try
            If MessageBoxAdv.Show("Desea eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
                    detalleItem = New detalleitems
                    detalleItem.idEmpresa = Gempresas.IdEmpresaRuc
                    detalleItem.idEstablecimiento = GEstableciento.IdEstablecimiento
                    detalleItem.codigodetalle = Me.dgvCompra.Table.CurrentRecord.GetValue("idItem")
                    detalleItemSA.DeleteProductoAllReferences(detalleItem)
                    Me.dgvCompra.Table.CurrentRecord.Delete()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", Nothing, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim statusForm As New FeedbackForm()
        statusForm.Tag = "CEX"
        'statusForm.Show("PROCESANDO ITEMS...!")
        ListadoItems(TmpIdAlmacen)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim detalleItemSA As New detalleitemsSA
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            With frmNuevaExistencia
                .EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                '.cboTipoExistencia.SelectedValue = "01"
                .Precios = True
                .IdAlmacenPrecio = TmpIdAlmacen
                ' .cboTipoExistencia.Text = cboTipoExistencia.Text
                .UCNuenExistencia.UbicarProducto(Me.dgvCompra.Table.CurrentRecord.GetValue("idItem"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If datos.Count > 0 Then
                    If datos(0).Cuenta = "Grabado" Then
                        With detalleItemSA.InvocarProductoID(datos(0).ID)
                            'Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                            'Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
                            '     Me.dgvCompra.Table.AddNewRecord.EndEdit()
                        End With
                    End If
                End If

            End With
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                If datos(0).Cuenta = "Grabado" Then
                    With detalleItemSA.InvocarProductoID(datos(0).ID)
                        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
                        Me.dgvCompra.Table.AddNewRecord.EndEdit()
                    End With
                End If
            End If

        End With
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblEmpresa_Click(sender As Object, e As EventArgs) Handles lblEmpresa.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub
End Class