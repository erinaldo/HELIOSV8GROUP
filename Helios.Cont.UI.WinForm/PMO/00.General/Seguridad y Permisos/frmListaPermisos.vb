Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Public Class frmListaPermisos
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim AutorizacionRolSA As New AutorizacionRolSA
    Public AutorizacionRolListado As List(Of AutorizacionRol)

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
        GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Public Sub ObtenerListaSeriesPorModulo(strModulo As String)
        Dim numeracionSA As New NumeracionBoletaSA
        lsvSeriesModulo.Items.Clear()
        For Each i In numeracionSA.ObtenerSeriesPorModulo(GEstableciento.IdEstablecimiento, strModulo)
            Dim n As New ListViewItem(i.IdEnumeracion)
            n.SubItems.Add(i.tipo)
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.valorInicial)
            n.SubItems.Add(i.incremento)
            lsvSeriesModulo.Items.Add(n)

            If Not IsNothing(i.tipo1) Then
                Dim n1 As New ListViewItem(i.IdEnumeracion)
                n1.SubItems.Add(i.tipo1)
                n1.SubItems.Add(i.serie1)
                n1.SubItems.Add(i.valorInicial1)
                n1.SubItems.Add(i.incremento1)
                lsvSeriesModulo.Items.Add(n1)
            End If

        Next

    End Sub
    Private Sub GetTablas()
        Dim tablaSA As New TablaSA
        cboTabla.DataSource = tablaSA.GetListaTabla()
        cboTabla.DisplayMember = "descripcion"
        cboTabla.ValueMember = "idtabla"


        Dim moduloSA As New ModuloConfiguracionSA
        cboModulo.DisplayMember = "descripcionModulo"
        cboModulo.ValueMember = "idModulo"
        cboModulo.DataSource = moduloSA.ListaModulos()
    End Sub

    Public Sub ListaUsuarios()
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Try
            Dim lista2 As List(Of Usuario) = usuarioSA.GetListaUsuarios()
            Dim dt As New DataTable

            dt.Columns.Add("ident", GetType(String))
            dt.Columns.Add("nomUser", GetType(String))

            For Each i In lista2
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.NroDocumento
                dr(1) = i.Nombres & ", " & i.ApellidoPaterno & ", " & i.ApellidoMaterno
                dt.Rows.Add(dr)
            Next
            GridGroupingControl1.DataSource = dt
            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Catch ex As Exception

        End Try

    End Sub

    Private Function GetParentTable() As DataTable
        Dim dt As New DataTable("ParentTable")
        Dim servicioSA As New servicioSA

        dt = New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("id", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))


        Dim Str As String = Nothing
        'For Each i As servicio In servicioSA.ListadoServiciosPadre()
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idServicio
        '    dr(1) = i.cuenta
        '    dr(2) = i.descripcion
        '    dr(3) = i.observaciones
        '    dr(4) = i.estado
        '    dr(5) = i.codigo
        '    dt.Rows.Add(dr)
        'Next

        Return dt
    End Function
#Region "MET"

    Public Sub EditarServicioPadre(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA
        Try
            objitem.idServicio = idservicio
            servicioSA.EditarServicioPadre(objitem)
            Dispose()
        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub



    Public Sub EliminarServicioPadreHijo(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA
        Try
            objitem.idServicio = idservicio
            servicioSA.EliminarServicioPadreHijo(objitem)
            'Dispose()
        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    Public Sub EliminarServicioHijo(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA

        Try

            objitem.idServicio = idservicio
            servicioSA.EliminarServicio(objitem)
            'Dispose()
        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

#End Region

    Private Function GetChildTable() As DataTable
        Dim dt As New DataTable("ChildTable")
        Dim servicioSA As New servicioSA

        dt = New DataTable("ChildTable")

        dt.Columns.Add(New DataColumn("id", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idhijo", GetType(Integer)))

        Dim Str As String = Nothing
        For Each i As servicio In servicioSA.ListadoServiciosHijos()
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idPadre
            dr(1) = i.cuenta
            Select Case i.codigo
                Case "CM"
                    dr(2) = "Compra"
                Case "VT"
                    dr(2) = "Venta"
            End Select
            dr(3) = i.descripcion
            dr(4) = i.observaciones
            dr(5) = i.estado
            dr(6) = i.idServicio
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Sub GetTablaDetalleByTabla(intIdTabla As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable()

        dt.Columns.Add("codigoDetalle")
        dt.Columns.Add("codigoDetalle2")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("estado")

        For Each i In tablaSA.GetListaTablaDetalle(intIdTabla, "1")
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigoDetalle
            dr(1) = i.codigoDetalle2
            dr(2) = i.descripcion
            dr(3) = i.estadodetalle
            dt.Rows.Add(dr)
        Next
        GridGroupingControl3.DataSource = dt
    End Sub

    Dim parentTable As New DataTable
    Dim childTable As New DataTable
    Private Sub LoadServicios()

        parentTable = New DataTable
        childTable = New DataTable
        Dim dSet As New DataSet()
        parentTable = GetParentTable()
        childTable = GetChildTable()
        dSet.Tables.AddRange(New DataTable() {parentTable, childTable})

        'setup the relations
        If childTable.Rows.Count > 0 Then

        End If

        Dim parentColumn As DataColumn = parentTable.Columns("id")
        Dim childColumn As DataColumn = childTable.Columns("id")
        'dSet.Relations.Clear()
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvServicios.DataSource = parentTable
        Me.dgvServicios.Engine.BindToCurrencyManager = False

        'Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
        'Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.dgvServicios.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvServicios.TopLevelGroupOptions.ShowCaption = False

        dgvServicios.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add GridCFGany initialization after the InitializeComponent() call.
        GridCFG(GridGroupingControl1)
        GridCFG(GridGroupingControl3)
        GridCFG(dgvServicios)
        GridGroupingControl1.ShowColumnHeaders = False
        GridGroupingControl1.ShowRowHeaders = False
        GridGroupingControl1.BorderStyle = BorderStyle.None
        GridGroupingControl1.DefaultGridBorderStyle = GridBorderStyle.None
        GridGroupingControl1.GridLineColor = Color.White
        GetTablas()
    End Sub

    Private Sub ListaPredeterminados(NModulo As String)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        Select Case NModulo
            Case 0
                'For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
                '    dt.Rows.Add(i.IdEnumeracion, TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                'Next
                'lstTipoDoc.DisplayMember = "Name"
                'lstTipoDoc.ValueMember = "ID"
                'lstTipoDoc.DataSource = dt 'numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
            Case 1
                'For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
                '    dt.Rows.Add(i.IdEnumeracion, TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                'Next
                'lstTipoDoc.DisplayMember = "Name"
                'lstTipoDoc.ValueMember = "ID"
                'lstTipoDoc.DataSource = dt  ' numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
        End Select
    End Sub
    Public Property TipoModulo() As String
    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    Dim numeracion As New numeracionBoletas

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    Select Case cboModulo.SelectedValue
    '        Case "C2", "C3"
    '            'tbAlmacen.ToggleState = ToggleButtonState.Inactive
    '            'tbAlmacen.Visible = False
    '            TipoModulo = "0"

    '        Case "C1"
    '            TipoModulo = "0"
    '        Case Else
    '            TipoModulo = "1"
    '    End Select

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            txtConfig.Text = IIf(.tipoConfiguracion = "P", "Automático", "Manual")
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            'Select Case .idModulo
    '            '    Case "C1", "C3"
    '            '        tbAlmacen.Visible = False
    '            '    Case Else
    '            '        tbAlmacen.Visible = True
    '            'End Select


    '            Select Case .tipoConfiguracion


    '                Case "P"
    '                    numeracion = numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                    If Not IsNothing(numeracion) Then
    '                        With numeracion
    '                            GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                            GConfiguracion.TipoComprobante = .tipo
    '                            GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial
    '                            txtComprobante.Text = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            txtIdComprobante.Text = .IdEnumeracion
    '                            txtSerie.Text = .serie
    '                            txtNumImpresiones.Text = .valorInicial
    '                            'If PanelVisibleFac.Visible = True Then
    '                            '    If Not IsNothing(.tipo1) Then
    '                            '        txtDocCF2.Text = "FACTURA"
    '                            '        txtSerieCF2.Text = .serie1
    '                            '        TextBoxExt1.Text = .valorInicial1
    '                            '    End If
    '                            'End If

    '                        End With
    '                    End If

    '                Case "M"
    '                    txtComprobante.Clear()
    '                    txtSerie.Clear()
    '                    txtNumImpresiones.Clear()

    '                    'txtDocCF2.Clear()
    '                    'txtSerieCF2.Clear()
    '                    'TextBoxExt1.Clear()
    '            End Select
    '        End With
    '    Else

    '        txtConfig.Text = "No tiene configuración"
    '        txtComprobante.Clear()
    '        txtSerie.Clear()
    '        txtNumImpresiones.Clear()
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Private Sub frmListaPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        GroupBar1.HeaderBackColor = Color.WhiteSmoke
        GroupBar1.ForeColor = Color.DimGray

        Label6.Visible = True
        'lstTipoDoc.Visible = True
        'txtSerieConf.Visible = True
        ListaPredeterminados(TipoModulo)

        If TmpProduccionPorLotes = True Then
            tbLotes.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            tbLotes.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If TmpCronogramaPagos = True Then
            tbCronograma.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            tbCronograma.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.proyecto = "S" Then
            tbControlProyectos.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            tbControlProyectos.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If


        If tmpConfigInicio.HC_ARRENDAMIENTO = True Then
            HC_ARRENDAMIENTO_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_ARRENDAMIENTO_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HC_CONS_INMED = True Then
            HC_CONS_INMED_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_CONS_INMED_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF

        End If

        If tmpConfigInicio.HC_CONSTRUCC = True Then
            HC_CONSTRUCC_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_CONSTRUCC_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        'If tmpConfigInicio.HC_OTROS = True Then
        '    HC_OTROS.ToggleState = ToggleButton2.ToggleButtonState.ON
        'Else
        '    HC_OTROS_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        'End If

        If tmpConfigInicio.HC_PRODUCCION = True Then
            HC_PRODUCCION_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_PRODUCCION_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HC_SERV_EDUCAT = True Then
            HC_SERV_EDUCAT_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_SERV_EDUCAT_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HC_SERV_HOTELERIA = True Then
            HC_SERV_HOTELERIA_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_SERV_HOTELERIA_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HC_SERV_TRANSP = True Then
            HC_SERV_TRANSP_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_SERV_TRANSP_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HC_SERV_VARIOS = True Then
            HC_SERV_VARIOS_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_SERV_VARIOS_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HC_VENTA_MERCADERIA = True Then
            HC_VENTA_MERCADERIA_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HC_VENTA_MERCADERIA_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HG_ACTIVOS = True Then
            HG_ACTIVOS_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HG_ACTIVOS_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HG_ADMIN = True Then
            HG_ADMIN_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HG_ADMIN_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        If tmpConfigInicio.HG_GASTO_VENTAS = True Then
            HG_GASTO_VENTAS_btn.ToggleState = ToggleButton2.ToggleButtonState.ON
        Else
            HG_GASTO_VENTAS_btn.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

    End Sub

    Private Sub Panel1_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        GridCFG(GridGroupingControl3)
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
    End Sub


    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        GridCFG(GridGroupingControl3)
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
    End Sub

    Private Sub Panel2_MouseEnter(sender As Object, e As EventArgs) Handles Panel2.MouseEnter
        Label2.ForeColor = Color.FromArgb(66, 139, 202)
        Label4.ForeColor = Color.FromKnownColor(KnownColor.MenuHighlight)
    End Sub

    Private Sub Panel2_MouseLeave(sender As Object, e As EventArgs) Handles Panel2.MouseLeave
        Label2.ForeColor = Color.Gray
        Label4.ForeColor = Color.DarkGray
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = TabControlAdv1
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
    End Sub

    Private Sub Panel3_MouseEnter(sender As Object, e As EventArgs) Handles Panel3.MouseEnter
        Label6.ForeColor = Color.FromArgb(66, 139, 202)
        Label5.ForeColor = Color.FromKnownColor(KnownColor.MenuHighlight)
    End Sub

    Private Sub Panel3_MouseLeave(sender As Object, e As EventArgs) Handles Panel3.MouseLeave
        Label6.ForeColor = Color.Gray
        Label5.ForeColor = Color.DarkGray
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv4.Parent = TabControlAdv1
    End Sub

    Private Sub Panel4_MouseEnter(sender As Object, e As EventArgs) Handles Panel4.MouseEnter
        Label8.ForeColor = Color.FromArgb(66, 139, 202)
        Label7.ForeColor = Color.FromKnownColor(KnownColor.MenuHighlight)
    End Sub

    Private Sub Panel4_MouseLeave(sender As Object, e As EventArgs) Handles Panel4.MouseLeave
        Label8.ForeColor = Color.Gray
        Label7.ForeColor = Color.DarkGray
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv4.Parent = TabControlAdv1
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        AutorizacionRolListado = New List(Of AutorizacionRol)
        Select Case cboMoneda.Text
            Case "Administrador"
                AutorizacionRolListado = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IDRol = 1})

                For Each i In AutorizacionRolListado
                    Select Case i.IDAsegurable
                        Case 19
                            If i.EstaAutorizado Then
                                tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 20
                            If i.EstaAutorizado Then
                                tb20.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 21
                            If i.EstaAutorizado Then
                                tb21.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb21.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 22
                            If i.EstaAutorizado Then
                                tb22.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb22.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 23
                            If i.EstaAutorizado Then
                                tb23.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb23.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 24
                            If i.EstaAutorizado Then
                                tb24.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb24.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 25
                            If i.EstaAutorizado Then
                                tb25.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb25.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 26
                            If i.EstaAutorizado Then
                                tb26.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb26.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 27
                            If i.EstaAutorizado Then
                                tb27.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb27.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 28
                            If i.EstaAutorizado Then
                                tb28.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb28.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                    End Select
                Next

            Case "Usuario básico"
                AutorizacionRolListado = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IDRol = 2})

                For Each i In AutorizacionRolListado
                    Select Case i.IDAsegurable
                        Case 19
                            If i.EstaAutorizado Then
                                tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 20
                            If i.EstaAutorizado Then
                                tb20.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 21
                            If i.EstaAutorizado Then
                                tb21.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb21.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 22
                            If i.EstaAutorizado Then
                                tb22.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb22.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 23
                            If i.EstaAutorizado Then
                                tb23.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb23.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 24
                            If i.EstaAutorizado Then
                                tb24.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb24.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 25
                            If i.EstaAutorizado Then
                                tb25.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb25.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 26
                            If i.EstaAutorizado Then
                                tb26.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb26.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                        Case 27
                            If i.EstaAutorizado Then
                                tb27.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb27.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If
                        Case 28
                            If i.EstaAutorizado Then
                                tb28.ToggleState = ToggleButton2.ToggleButtonState.ON
                            Else
                                tb28.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End If

                    End Select
                Next
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PanelGastos_MouseClick(sender As Object, e As MouseEventArgs) Handles PanelGastos.MouseClick
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = TabControlAdv1
        LoadServicios()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PanelGastos_Paint(sender As Object, e As PaintEventArgs) Handles PanelGastos.Paint

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f As New frmNuevoServicio
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
        LoadServicios()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        LoadServicios()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GroupBar1_GroupBarItemSelected(sender As Object, e As EventArgs) Handles GroupBar1.GroupBarItemSelected

    End Sub


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

        If dgvServicios.Table.Records.Count > 0 Then

            Dim el As Element = Me.dgvServicios.Table.GetInnerMostCurrentElement()
            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvServicios.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then



                    If IsNothing(Me.dgvServicios.Table.CurrentRecord) Then

                        If rec.GetValue("tipo") = "PC" Then
                            EliminarServicioPadreHijo(CInt(rec.GetValue("id")))
                            LoadServicios()
                            ''''''''M
                        ElseIf rec.GetValue("tipo") = "PV" Then
                            EliminarServicioPadreHijo(CInt(rec.GetValue("id")))
                            LoadServicios()

                            '''''''M
                        Else

                            EliminarServicioHijo(CInt(rec.GetValue("idhijo")))
                            LoadServicios()
                        End If
                        ''''''''''''''''''''

                    Else
                        If Me.dgvServicios.Table.CurrentRecord.GetValue("tipo") = "PC" Then
                            EliminarServicioPadreHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                            LoadServicios()
                            'LoadServicios()

                            ''''''M
                        ElseIf Me.dgvServicios.Table.CurrentRecord.GetValue("tipo") = "PV" Then
                            EliminarServicioPadreHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                            LoadServicios()
                            ''''M
                        Else

                            EliminarServicioHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("idhijo")))
                            LoadServicios()
                            'LoadServicios()
                        End If


                    End If

                    'If Me.dgvServicios.Table.CurrentRecord.GetValue("codigo") Is Nothing Then
                    '    EliminarServicioHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                    '    LoadServicios()
                    'Else
                    '    EliminarServicioPadreHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                    '    LoadServicios()
                    'End If



                    'Dim str = Me.dgvServicios.Table.CurrentRecord.GetValue("codigo").ToString
                    'If str.Trim.Length > 0 Then
                    '    EliminarServicioPadreHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                    '    LoadServicios()
                    'Else
                    '    EliminarServicioHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                    '    LoadServicios()
                    'End If
                End If


                'If Me.dgvServicios.Table.CurrentRecord.GetValue("codigo") = "P" Then
                '    EliminarServicioPadreHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                '    LoadServicios()

                'End If

                'If Me.dgvServicios.Table.CurrentRecord.GetValue("tipo") = "VT" Then
                '    EliminarServicioHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                '    LoadServicios()
                'End If

                'If Me.dgvServicios.Table.CurrentRecord.GetValue("tipo") = "CM" Then
                '    EliminarServicioHijo(CInt(Me.dgvServicios.Table.CurrentRecord.GetValue("id")))
                '    LoadServicios()
                'End If

            End If
        End If
        'End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        If dgvServicios.Table.Records.Count > 0 Then

            Dim el As Element = Me.dgvServicios.Table.GetInnerMostCurrentElement()
            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvServicios.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)

                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then

                    'Dim strDescrip = Me.dgvServicios.Table.CurrentRecord.GetValue("descripcion").ToString
                    'If strDescrip.Trim.Length > 0 Then
                    'Dim tipo As String
                    'If rec.GetValue("tipo") = "PC" Then
                    '    tipo = "P"
                    'ElseIf rec.GetValue("tipo") = "PC" Then
                    '    tipo = "P"
                    'End If

                    If IsNothing(Me.dgvServicios.Table.CurrentRecord) Then

                        'If rec.GetValue("tipo") = "P" Then
                        '    ' If tipo = "P" Then
                        '    Dim f As New FrmAddServicio
                        '    f.Tag = "editar"
                        '    f.txtidservicio.Text = rec.GetValue("id")
                        '    f.txtServicioNew.Text = rec.GetValue("descripcion")


                        '    Dim str = rec.GetValue("observaciones").ToString
                        '    If str.Trim.Length > 0 Then
                        '        f.txtObservaciones.Text = rec.GetValue("observaciones")
                        '    End If

                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ShowDialog()


                        'ElseIf rec.GetValue("tipo") = "P" Then
                        If rec.GetValue("tipo") = "PC" Then
                            Dim f As New FrmAddServicio
                            f.Tag = "editar"
                            f.txtidservicio.Text = rec.GetValue("id")
                            f.txtServicioNew.Text = rec.GetValue("descripcion")


                            Dim str = rec.GetValue("observaciones").ToString
                            If str.Trim.Length > 0 Then
                                f.txtObservaciones.Text = rec.GetValue("observaciones")
                            End If

                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                            ''''''''''''''''''''
                        ElseIf rec.GetValue("tipo") = "PV" Then
                            Dim f As New FrmAddServicio
                            f.Tag = "editar"
                            f.txtidservicio.Text = rec.GetValue("id")
                            f.txtServicioNew.Text = rec.GetValue("descripcion")


                            Dim str = rec.GetValue("observaciones").ToString
                            If str.Trim.Length > 0 Then
                                f.txtObservaciones.Text = rec.GetValue("observaciones")
                            End If

                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                            ''''''''''''''''''''''''''
                        Else

                            Dim f As New FrmAddServicio
                            f.Tag = "editar"
                            f.txtidservicio.Text = rec.GetValue("idhijo")
                            f.txtServicioNew.Text = rec.GetValue("descripcion")


                            Dim str = rec.GetValue("observaciones").ToString
                            If str.Trim.Length > 0 Then
                                f.txtObservaciones.Text = rec.GetValue("observaciones")
                            End If

                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()


                        End If

                    Else
                        If Me.dgvServicios.Table.CurrentRecord.GetValue("tipo") = "PC" Then

                            'metodo para editar padre
                            Dim f As New FrmAddServicio
                            f.Tag = "editar"
                            f.txtidservicio.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("id")
                            f.txtServicioNew.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("descripcion")


                            Dim str = Me.dgvServicios.Table.CurrentRecord.GetValue("observaciones").ToString
                            If str.Trim.Length > 0 Then
                                f.txtObservaciones.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("observaciones")
                            End If

                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                            ''''''''''''''
                        ElseIf Me.dgvServicios.Table.CurrentRecord.GetValue("tipo") = "PV" Then

                            'metodo para editar padre
                            Dim f As New FrmAddServicio
                            f.Tag = "editar"
                            f.txtidservicio.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("id")
                            f.txtServicioNew.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("descripcion")


                            Dim str = Me.dgvServicios.Table.CurrentRecord.GetValue("observaciones").ToString
                            If str.Trim.Length > 0 Then
                                f.txtObservaciones.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("observaciones")
                            End If

                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()


                            ''''''''''
                        Else
                            Dim f As New FrmAddServicio
                            f.Tag = "editar"
                            f.txtidservicio.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("idhijo")
                            f.txtServicioNew.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("descripcion")


                            Dim str = Me.dgvServicios.Table.CurrentRecord.GetValue("observaciones").ToString
                            If str.Trim.Length > 0 Then
                                f.txtObservaciones.Text = Me.dgvServicios.Table.CurrentRecord.GetValue("observaciones")
                            End If

                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                        End If
                    End If

                    Me.Cursor = Cursors.WaitCursor


                    LoadServicios()
                    Me.Cursor = Cursors.Arrow


                    'End If

                End If
            End If

        End If

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        GetTablaDetalleByTabla(cboTabla.SelectedValue)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel14_Paint(sender As Object, e As PaintEventArgs) Handles Panel14.Paint

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        'configuracionModuloV2(Gempresas.IdEmpresaRuc, cboModulo.SelectedValue, cboModulo.Text, GEstableciento.IdEstablecimiento)
        ObtenerListaSeriesPorModulo(cboModulo.SelectedValue)
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dim f As New frmAddNumeracion
        f.CodModulo = cboModulo.SelectedValue
        If cboModulo.SelectedValue = "VT2" Then
            f.cboTipoDoc.SelectedValue = "03"
            f.Panel1.Visible = True
            f.Size = New Size(447, 332)
        ElseIf cboModulo.SelectedValue = "VT1" Then
            f.cboTipoDoc.SelectedValue = "9907"
            f.Size = New Size(447, 238)
            f.Panel1.Visible = False
        End If
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        ObtenerListaSeriesPorModulo(cboModulo.SelectedValue)
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv4.Parent = TabControlAdv1
    End Sub

    Private Sub Label2_MouseClick(sender As Object, e As MouseEventArgs) Handles Label2.MouseClick
        GridCFG(GridGroupingControl3)
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
    End Sub

    Private Sub TabPageAdv1_Click(sender As Object, e As EventArgs) Handles TabPageAdv1.Click

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio

        config = New configuracionInicio
        config.idEmpresa = Gempresas.IdEmpresaRuc
        If tbLotes.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.produccionLotes = True
            TmpProduccionPorLotes = True
        Else
            config.produccionLotes = False
            TmpProduccionPorLotes = False
        End If

        If tbCronograma.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.cronogramaPagos = True
            TmpCronogramaPagos = True
            tmpConfigInicio.cronogramaPagos = True
        Else
            config.cronogramaPagos = False
            TmpCronogramaPagos = False
            tmpConfigInicio.cronogramaPagos = False
        End If
        '------------------------------------------------------------------

        If tbControlProyectos.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.proyecto = "S"
            tmpConfigInicio.proyecto = "S"
        Else
            config.proyecto = "N"
            tmpConfigInicio.proyecto = "N"
        End If


        If HC_SERV_EDUCAT_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_SERV_EDUCAT = True
            tmpConfigInicio.HC_SERV_EDUCAT = True
        Else
            config.HC_SERV_EDUCAT = False
            tmpConfigInicio.HC_SERV_EDUCAT = False
        End If

        If HC_VENTA_MERCADERIA_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_VENTA_MERCADERIA = True
            tmpConfigInicio.HC_VENTA_MERCADERIA = True
        Else
            config.HC_VENTA_MERCADERIA = False
            tmpConfigInicio.HC_VENTA_MERCADERIA = False
        End If

        If HC_PRODUCCION_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_PRODUCCION = True
            tmpConfigInicio.HC_PRODUCCION = True
        Else
            config.HC_PRODUCCION = False
            tmpConfigInicio.HC_PRODUCCION = False
        End If


        If HC_CONS_INMED_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_CONS_INMED = True
            tmpConfigInicio.HC_CONS_INMED = True
        Else
            config.HC_CONS_INMED = False
            tmpConfigInicio.HC_CONS_INMED = False
        End If


        If HC_CONSTRUCC_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_CONSTRUCC = True
            tmpConfigInicio.HC_CONSTRUCC = True
        Else
            config.HC_CONSTRUCC = False
            tmpConfigInicio.HC_CONSTRUCC = False
        End If


        If HC_SERV_VARIOS_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_SERV_VARIOS = True
            tmpConfigInicio.HC_SERV_VARIOS = True
        Else
            config.HC_SERV_VARIOS = False
            tmpConfigInicio.HC_SERV_VARIOS = False
        End If

        If HC_SERV_TRANSP_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_SERV_TRANSP = True
            tmpConfigInicio.HC_SERV_TRANSP = True
        Else
            config.HC_SERV_TRANSP = False
            tmpConfigInicio.HC_SERV_TRANSP = False
        End If


        If HC_SERV_HOTELERIA_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_SERV_HOTELERIA = True
            tmpConfigInicio.HC_SERV_HOTELERIA = True
        Else
            config.HC_SERV_HOTELERIA = False
            tmpConfigInicio.HC_SERV_HOTELERIA = False
        End If

        If HC_ARRENDAMIENTO_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HC_ARRENDAMIENTO = True
            tmpConfigInicio.HC_ARRENDAMIENTO = True
        Else
            config.HC_ARRENDAMIENTO = False
            tmpConfigInicio.HC_ARRENDAMIENTO = False
        End If

        If HG_ADMIN_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HG_ADMIN = True
            tmpConfigInicio.HG_ADMIN = True
        Else
            config.HG_ADMIN = False
            tmpConfigInicio.HG_ADMIN = False
        End If

        If HG_GASTO_VENTAS_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HG_GASTO_VENTAS = True
            tmpConfigInicio.HG_GASTO_VENTAS = True
        Else
            config.HG_GASTO_VENTAS = False
            tmpConfigInicio.HG_GASTO_VENTAS = False
        End If

        If HG_ACTIVOS_btn.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            config.HG_ACTIVOS = True
            tmpConfigInicio.HG_ACTIVOS = True
        Else
            config.HG_ACTIVOS = False
            tmpConfigInicio.HG_ACTIVOS = False
        End If

        configSA.EditarConfiguracionGeneral(config)


    End Sub

End Class