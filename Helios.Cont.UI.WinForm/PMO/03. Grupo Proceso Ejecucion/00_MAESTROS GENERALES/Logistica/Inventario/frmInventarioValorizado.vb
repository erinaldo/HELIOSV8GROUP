Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter

Public Class frmInventarioValorizado

#Region "Attributes"
    Public Property lista As New List(Of tabladetalle)
    Public Property tablaSA As New tablaDetalleSA
    Public Property almacenSA As New almacenSA
    Public Property totalesAlmacenSA As New TotalesAlmacenSA
    Public Property ListaProductosConexos As List(Of totalesAlmacen)
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListaProductosConexos = New List(Of totalesAlmacen)
        FormatoGridPequeño(dgvKardexVal, False)
        LoadCombos()
        ComboStatus()
    End Sub
#End Region

#Region "Methods"

    'Private Sub loadTable()
    '    Dim table As DataTable = New DataTable()
    '    Dim SDA As SqlDataAdapter = New SqlDataAdapter()
    '    SDA.Fill(table)
    '    setDataSource(table)
    'End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvKardexVal.DataSource = table
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            ProgressBar1.Visible = False

            Dim conditionalDescriptor As New GridConditionalFormatDescriptor()

            'object for data bar rule
            'Dim conditionDataBarRule1 As New ConditionalFormatDataBarRule()

            ''Assigning column for data bar
            'conditionDataBarRule1.ColumnName = "Profit"

            ''Adding the rule to rules collection
            'conditionalDescriptor.Rules.Add(conditionDataBarRule1)

            ''Adding descriptor.
            'Me.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(conditionalDescriptor)

        End If
    End Sub

    Sub ComboStatus()
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("name")

        dt.Rows.Add(StatusArticulo.Activo, "Activo")
        dt.Rows.Add(StatusArticulo.Inactivo, "Inactivo")
        dt.Rows.Add(StatusArticulo.Retenido, "Retenido")
        dt.Rows.Add(StatusArticulo.Vencido, "Vencido")

        Dim ggcStyle As GridTableCellStyleInfo = dgvKardexVal.TableDescriptor.Columns("status").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub GetInventarioValorizadoCodigo(intIdAlmacen As Integer, codigobarra As String)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("codigoLote")
        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductosByAlmacenCodigo(intIdAlmacen, codigobarra)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            dr(14) = i.fechaLote
            dr(15) = i.NroLote
            dr(16) = i.codigoLote
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
        'dgvKardexVal.DataSource = dt
        'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        'If Not dt.Rows.Count > 0 Then
        '    MessageBox.Show("El Codigo Ingresado no existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub GetInventarioValorizado(idAlmacen As Integer, tipoex As String)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("codigoLote")


        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductosByAlmacen(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                               .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA,
                                                                               .idAlmacen = idAlmacen}, tipoex).OrderBy(Function(o) o.descripcion).ToList
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            If i.fechaLote.HasValue Then
                dr(14) = i.fechaLote.Value.ToString("dd-MM-yyyy")
            End If

            dr(15) = i.NroLote
            dr(16) = i.codigoLote
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub GetInventarioValorizadoXvencer(idAlmacen As Integer, tipoex As String, anio As Integer, mes As Integer)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductosXvencerMes(Gempresas.IdEmpresaRuc, anio, mes, tipoex, idAlmacen).OrderBy(Function(o) o.descripcion).ToList
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            If i.fechaLote.HasValue Then
                dr(14) = i.fechaLote.Value.ToString("dd-MM-yyyy")
            End If

            dr(15) = i.NroLote
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub GetInventarioValorizadoFiltro(be As totalesAlmacen)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("codigoLote")
        For Each i As totalesAlmacen In totalesAlmacenSA.GetFilterArticulosStartWith(be).OrderBy(Function(o) o.descripcion).ToList

            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            dr(14) = i.fechaLote
            dr(15) = i.NroLote
            dr(16) = i.codigoLote
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
        'dgvKardexVal.DataSource = dt
        'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub LoadCombos()
        lista = New List(Of tabladetalle)
        lista = tablaSA.GetListaTablaDetalle(5, "1")
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        cboMes.DataSource = ListaDeMeses()
        cboMes.ValueMember = "Codigo"
        cboMes.DisplayMember = "Mes"
        cboMes.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub

#End Region

#Region "Events"
    Private Sub txtCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoBarra.KeyDown
        'Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtCodigoBarra.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese un Codigo para Buscar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If cboAlmacen.SelectedIndex > -1 Then
                Dim codAlmacen = cboAlmacen.SelectedValue
                If IsNumeric(codAlmacen) Then
                    GetInventarioValorizadoCodigo(codAlmacen, txtCodigoBarra.Text)
                    ProgressBar1.Visible = True
                    ProgressBar1.Style = ProgressBarStyle.Marquee
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioValorizadoCodigo(codAlmacen, txtCodigoBarra.Text)))
                    thread.Start()
                End If
            Else
                MessageBox.Show("Seleccione un Almancen", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        '  Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        '  LoadingAnimator.Wire(Me.dgvKardexVal.TableControl)
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            Dim tipoExistencia = cboTipoExistencia.SelectedValue
            If IsNumeric(codAlmacen) Then
                ProgressBar1.Visible = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioValorizado(codAlmacen, tipoExistencia)))
                thread.Start()
            End If
        End If
        '   LoadingAnimator.UnWire(Me.dgvKardexVal.TableControl)
    End Sub

    Private Sub txtBuscarDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If cboAlmacen.SelectedIndex > -1 Then
                Dim codAlmacen = cboAlmacen.SelectedValue
                If IsNumeric(codAlmacen) Then
                    If txtBuscarDetalle.Text.Trim.Length > 0 Then
                        Dim t As New totalesAlmacen With {.idAlmacen = cboAlmacen.SelectedValue,
                                                          .tipoExistencia = cboTipoExistencia.SelectedValue,
                                                          .descripcion = txtBuscarDetalle.Text}
                        ProgressBar1.Visible = True
                        ProgressBar1.Style = ProgressBarStyle.Marquee
                        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioValorizadoFiltro(t)))
                        thread.Start()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvKardexVal.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambioProductoDetalleV1(New totalesAlmacen With {.idItem = r.GetValue("idItem"), .idMovimiento = r.GetValue("idmovimiento")})
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar una artículo", "Cambiar desripción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvKardexVal_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvKardexVal.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim r As Record = e.TableControl.Table.CurrentRecord
        If Not IsNothing(r) Then
            totalesAlmacenSA.GetChangeStatusArticulo(New totalesAlmacen With {.idMovimiento = CInt(r.GetValue("idmovimiento")), .status = CInt(r.GetValue("status"))})
        End If
    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvKardexVal, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Do you wish to open the xls file now?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub

    Private Sub cboAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedValueChanged
        dgvKardexVal.Table.Records.DeleteAll()
    End Sub

    Private Sub cboTipoExistencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedValueChanged
        dgvKardexVal.Table.Records.DeleteAll()
    End Sub

    Private Sub frmInventarioValorizado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAnio.Value = DateTime.Now
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            Dim tipoExistencia = cboTipoExistencia.SelectedValue
            Dim mes = cboMes.SelectedValue
            Dim anio = txtAnio.Value.Year
            If IsNumeric(codAlmacen) Then
                ProgressBar1.Visible = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioValorizadoXvencer(codAlmacen, tipoExistencia, anio, mes)))
                thread.Start()
            End If
        End If
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvKardexVal.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New frmEditarArticuloLote(r.GetValue("idItem"), r.GetValue("codigoLote"), cboAlmacen.SelectedValue)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv1_Click(sender, e)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Cursor = Cursors.WaitCursor
        Dim compraDeTSA As New DocumentoCompraDetalleSA
        Dim empresaPeriodoSA As New empresaCierreMensualSA

        Dim fechaAnt = New Date(txtPeriodoCompra.Value.Year, CInt(txtPeriodoCompra.Value.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodoCompra.Value.Year, .mes = txtPeriodoCompra.Value.Month})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Dim r As Record = dgvKardexVal.Table.CurrentRecord
        'If r IsNot Nothing Then
        '    Dim item = compraDeTSA.GeDetalleCompraItemLote(Integer.Parse(r.GetValue("codigoLote")))
        '    Dim ListaCompra = compraDeTSA.GetUbicarDetalleCompraLote(Integer.Parse(r.GetValue("codigoLote")))
        '    Dim f As New frmCompras(Integer.Parse(r.GetValue("codigoLote")), item)
        '    f.Label40.Visible = False
        '    f.ComboBoxAdv2.Visible = False
        '    f.CaptionLabels(0).Text = "Compra al crédito"
        '    f.lblPerido.Text = String.Format("{0:00}", txtPeriodoCompra.Value.Month) & "/" & txtPeriodoCompra.Value.Year
        '    f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        '    f.cboMesCompra.Enabled = True
        '    f.txtDia.Value = DateTime.Now
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.WindowState = FormWindowState.Normal
        '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    f.ShowDialog()
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvKardexVal.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 3 Then
                e.Inner.Style.Description = e.Inner.Style.CellValue
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvKardexVal.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 3 Then
                Dim iditem = Integer.Parse(dgvKardexVal.TableModel(e.Inner.RowIndex, 15).CellValue)
                Dim codigLote = Integer.Parse(dgvKardexVal.TableModel(e.Inner.RowIndex, 14).CellValue)

                Dim f As New frmGestionarLotes(iditem, codigLote, cboAlmacen.SelectedValue)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            ElseIf e.Inner.ColIndex = 21 Then

            ElseIf e.Inner.ColIndex = 22 Then

            ElseIf e.Inner.ColIndex = 23 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        If dgvKardexVal.Table.CurrentRecord IsNot Nothing Then
            ListaProductosConexos.Add(New totalesAlmacen With
                                      {
                                      .idMovimiento = dgvKardexVal.Table.CurrentRecord.GetValue("idmovimiento"),
                                      .descripcion = dgvKardexVal.Table.CurrentRecord.GetValue("descripcion"),
                                      .unidadMedida = dgvKardexVal.Table.CurrentRecord.GetValue("unidadMedida"),
                                      .tipoExistencia = dgvKardexVal.Table.CurrentRecord.GetValue("tipoExistencia")
                                      })
        End If
        Label3.Text = "Productos Agregados: " & ListaProductosConexos.Count
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        '       If dgvKardexVal.Table.SelectedRecords.Count > 0 Then
        Dim f As New FrmProductosConexos(ListaProductosConexos)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            Label3.Text = "Productos Agregados: " & ListaProductosConexos.Count
        '     End If
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        ListaProductosConexos = New List(Of totalesAlmacen)
        Label3.Text = "Productos Agregados: " & ListaProductosConexos.Count
    End Sub
#End Region
End Class