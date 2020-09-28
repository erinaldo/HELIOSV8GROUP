Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmSalidasAlConsumoCosto
    Inherits frmMaster


    Public Property Alert As Alert
    Public Property listaAsientoEnvio As New List(Of asiento)
    Public Property ListaMovimientos As New List(Of movimiento)
    Dim listatabla As New List(Of tabladetalle)

#Region "Variables"
    Dim srtNomAlmacen As String = Nothing
    Dim strUM As String = Nothing
    Dim strTipoEx As String = Nothing
    Dim strCuenta As String = Nothing
    Dim intIdEstableAlm As Integer
    Dim strIdPresentacion As String = Nothing
    Dim selAlmacenPC As String

    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ManipulacionEstado() As String
    Private cantidaExistente As New List(Of Integer)
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable
    Public Property sumaMN() As Decimal
    Public Property sumaME() As Decimal
#End Region
    Dim colorx As New GridMetroColors()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Add any initialization after the InitializeComponent() call.

        'dockingManager1.DockControl(PanelGlosa, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 70)
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        dockingManager1.DockControlInAutoHideMode(Panel2, Tools.DockingStyle.Left, 382)
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Canasta existencias")


        'INICIO PERIODO
        '   lblPerido.Text = PeriodoGeneral
        dockingManager1.CloseEnabled = False
        CargarListas()

        'dgvCompra.DataSource = GetTableGrid2()
        GridCFG(dgvMov)
        'GridCFG(dgvCompra)


        SetRenderer()
        'If cboOperacion.SelectedValue = "10.01" Then
        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

        Else
            If tmpConfigInicio IsNot Nothing Then
                If tmpConfigInicio.proyecto IsNot Nothing Then
                    If tmpConfigInicio.proyecto = "S" Then
                        AddColumnProyecto()
                    End If
                End If
            End If
        End If


        '   End If

        dgvMov.DataSource = GetTableGrid()
        'txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
        'txtFechaComprobante.Select()
        txtTipoCambio.DecimalValue = TmpTipoCambio
        'dockingManager1.SetDockVisibility(Panel2, False)

       LoadComboFechas()


        GroupBox2.Visible = False
    End Sub








    Public Sub AddColumnProyecto()
        Dim costoSA As New recursoCostoSA
        dgvMov.TableDescriptor.Columns.Add("proyecto")
        dgvMov.TableDescriptor.VisibleColumns.Add("proyecto")
        dgvMov.TableDescriptor.Columns("proyecto").MappingName = "proyecto"
        dgvMov.TableDescriptor.Columns("proyecto").HeaderText = "Proyecto"
        dgvMov.TableDescriptor.Columns("proyecto").Name = "proyecto"
        dgvMov.TableDescriptor.Columns("proyecto").Width = 100
        dgvMov.TableDescriptor.Columns("proyecto").ReadOnly = False
        dgvMov.TableDescriptor.Columns("proyecto").AllowSort = False

        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("proyecto").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
        ggcStyle.ValueMember = "idCosto"
        ggcStyle.DisplayMember = "nombreCosto"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Dim colIdItem As Integer

        colIdItem = intIdItem

        For Each i In dgvMov.Table.Records
            If colIdItem = i.GetValue("idItem") Then
                Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
            End If
        Next
    End Sub

    Private Sub ValidarCantidadDisponible(r As Record)
        Dim colCantMov As Decimal = 0
        Dim colIdItem As Integer

        colIdItem = r.GetValue("idItem")

        For Each i In dgvMov.Table.Records
            If colIdItem = i.GetValue("idItem") Then
                colCantMov += CDec(i.GetValue("cantidad"))
            End If
        Next

        If colCantMov > CDec(r.GetValue("cantDisponible")) Then
            r.SetValue("cantidad", 0)
            Throw New Exception("Debe verificar el stock disponible")
        End If
    End Sub

    Private Sub LoadComboFechas()
        Dim empresaAnioSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral

    End Sub


    Public Function asientoSalida()

        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        nAsiento = New asiento With {
                        .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year,
                       .idEmpresa = Gempresas.IdEmpresaRuc,
                       .idCentroCostos = GEstableciento.IdEstablecimiento,
                       .idDocumentoRef = Nothing,
                       .idAlmacen = 0,
                       .nombreAlmacen = cboAlmacen.Text,
                       .idEntidad = txtProveedor.Tag,
                       .nombreEntidad = txtProveedor.Text,
                       .tipoEntidad = String.Empty,
                       .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second),
                       .codigoLibro = "13",
                       .tipo = "D",
                       .tipoAsiento = "AC_BL",
                       .importeMN = 0,
                       .importeME = 0,
                       .glosa = txtGlosa.Text.Trim,
                       .usuarioActualizacion = usuario.IDUsuario,
                       .fechaActualizacion = DateTime.Now
                           }


        For Each r As Record In dgvMov.Table.Records

            If r.GetValue("tipoEx") = "01" Then   'mercarderia

                nMovimiento = New movimiento With {
                         .cuenta = "6111",
                         .descripcion = r.GetValue("item"),
                         .tipo = "D",
                         .monto = CDec(r.GetValue("importeMN")),
                         .montoUSD = CDec(r.GetValue("importeMN")),
                         .usuarioActualizacion = usuario.IDUsuario,
                         .fechaActualizacion = DateTime.Now
                     }
                nAsiento.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento With {
                    .cuenta = "20111",
                    .descripcion = r.GetValue("item"),
                    .tipo = "H",
                    .monto = CDec(r.GetValue("importeMN")),
                    .montoUSD = CDec(r.GetValue("importeMN")),
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                nAsiento.movimiento.Add(nMovimiento)



            ElseIf r.GetValue("tipoEx") = "03" Then    'materia prima


                nMovimiento = New movimiento With {
                         .cuenta = "6121",
                         .descripcion = r.GetValue("item"),
                         .tipo = "D",
                         .monto = CDec(r.GetValue("importeMN")),
                         .montoUSD = CDec(r.GetValue("importeMN")),
                         .usuarioActualizacion = usuario.IDUsuario,
                         .fechaActualizacion = DateTime.Now
                     }
                nAsiento.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento With {
                    .cuenta = "241",
                    .descripcion = r.GetValue("item"),
                    .tipo = "H",
                    .monto = CDec(r.GetValue("importeMN")),
                    .montoUSD = CDec(r.GetValue("importeMN")),
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                nAsiento.movimiento.Add(nMovimiento)

            ElseIf r.GetValue("tipoEx") = "04" Then     ' envases y enbalajes

                nMovimiento = New movimiento With {
                         .cuenta = "6131",
                         .descripcion = r.GetValue("item"),
                         .tipo = "D",
                         .monto = CDec(r.GetValue("importeMN")),
                         .montoUSD = CDec(r.GetValue("importeMN")),
                         .usuarioActualizacion = usuario.IDUsuario,
                         .fechaActualizacion = DateTime.Now
                     }
                nAsiento.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento With {
                    .cuenta = "251",
                    .descripcion = r.GetValue("item"),
                    .tipo = "H",
                    .monto = CDec(r.GetValue("importeMN")),
                    .montoUSD = CDec(r.GetValue("importeMN")),
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                nAsiento.movimiento.Add(nMovimiento)


            ElseIf r.GetValue("tipoEx") = "05" Then      'suministros diversos

                nMovimiento = New movimiento With {
                         .cuenta = "6141",
                         .descripcion = r.GetValue("item"),
                         .tipo = "D",
                         .monto = CDec(r.GetValue("importeMN")),
                         .montoUSD = CDec(r.GetValue("importeMN")),
                         .usuarioActualizacion = usuario.IDUsuario,
                         .fechaActualizacion = DateTime.Now
                     }
                nAsiento.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento With {
                    .cuenta = "261",
                    .descripcion = r.GetValue("item"),
                    .tipo = "H",
                    .monto = CDec(r.GetValue("importeMN")),
                    .montoUSD = CDec(r.GetValue("importeMN")),
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                nAsiento.movimiento.Add(nMovimiento)

            End If
        Next

        Return nAsiento
    End Function

    Public Sub ListaMercaderiasXIdHijo(intIdAlmacen As Integer, strtipoEx As String, idItem As Integer)
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenItem(intIdAlmacen, strtipoEx, idItem)
                If i.cantidad > 0 Then
                    Dim n As New ListViewItem(i.idEstablecimiento)
                    n.SubItems.Add(i.origenRecaudo)
                    n.SubItems.Add(i.idItem)
                    n.SubItems.Add(i.descripcion)
                    n.SubItems.Add(i.unidadMedida)
                    n.SubItems.Add(tablaSA.GetUbicarTablaID(21, i.Presentacion).descripcion)
                    n.SubItems.Add(FormatNumber(i.cantidad, 2))
                    n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                    n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2).ToString("N2"))
                    Else
                        n.SubItems.Add(0)
                    End If

                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2).ToString("N2"))
                    Else
                        n.SubItems.Add(0)
                    End If
                    lsvExistencias.Items.Add(n)
                End If

            Next
            For Each item As ListViewItem In lsvExistencias.Items
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


#Region "asiento"

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

    Private Function GetTableGrid2() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cant", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("descripcion", GetType(String))

        Return dt
    End Function

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function



    'Sub GetasientosListbox()
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("id")
    '    dt.Columns.Add("nombre")

    '    For Each i In ListaAsientonTransito
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idAsiento
    '        dr(1) = i.Descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    lstAsiento.DisplayMember = "nombre"
    '    lstAsiento.ValueMember = "id"
    '    lstAsiento.DataSource = dt
    'End Sub

    'Sub RegistrarAsientos()
    '    Dim nAsiento As New asiento

    '    If ListaAsientonTransito.Count > 0 Then
    '        nAsiento.idAsiento = ListaAsientonTransito.Count + 1
    '    Else
    '        nAsiento.idAsiento = 1
    '    End If
    '    nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
    '    ListaAsientonTransito.Add(nAsiento)

    '    GetasientosListbox()
    'End Sub






    Sub updateMovimiento(r As Record)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaMovimientos
                            Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub GetTipoExistenciaByCosto()
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
        Dim lista As New List(Of tabladetalle)

        lista = tablaSA.GetListaTablaDetalle(5, "1")

        Select Case txtTipoCosto.Text

            Case TipoCosto.Proyecto,
                TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS,
                TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES

                Dim listaExec As New List(Of String)
                listaExec.Add(TipoExistencia.MateriaPrima)
                listaExec.Add(TipoExistencia.MaterialAuxiliar_SuministroRepuesto)
                listaExec.Add(TipoExistencia.EnvasesEmbalajes)

                Dim con = (From n In lista
                           Where listaExec.Contains(n.codigoDetalle)).ToList

                cboTipoExistencia.DisplayMember = "descripcion"
                cboTipoExistencia.ValueMember = "codigoDetalle"
                cboTipoExistencia.DataSource = con

            Case TipoCosto.OrdenProduccion,
                TipoCosto.OP_CONTINUA_DE_BIENES,
                TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES,
                TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE

                Dim listaExec As New List(Of String)
                listaExec.Add(TipoExistencia.MateriaPrima)
                listaExec.Add(TipoExistencia.MaterialAuxiliar_SuministroRepuesto)
                listaExec.Add(TipoExistencia.EnvasesEmbalajes)

                Dim con = (From n In lista
                           Where listaExec.Contains(n.codigoDetalle)).ToList

                cboTipoExistencia.DisplayMember = "descripcion"
                cboTipoExistencia.ValueMember = "codigoDetalle"
                cboTipoExistencia.DataSource = con

            Case TipoCosto.ActivoFijo

                Dim listaExec As New List(Of String)
                listaExec.Add(TipoExistencia.MateriaPrima)
                listaExec.Add(TipoExistencia.MaterialAuxiliar_SuministroRepuesto)
                listaExec.Add(TipoExistencia.EnvasesEmbalajes)

                Dim con = (From n In lista
                           Where listaExec.Contains(n.codigoDetalle)).ToList

                cboTipoExistencia.DisplayMember = "descripcion"
                cboTipoExistencia.ValueMember = "codigoDetalle"
                cboTipoExistencia.DataSource = con


            Case TipoCosto.GastoAdministrativo

                Dim listaExec As New List(Of String)
                listaExec.Add(TipoExistencia.Mercaderia)
                listaExec.Add(TipoExistencia.ProductoTerminado)
                listaExec.Add(TipoExistencia.SubProductosDesechos)
                listaExec.Add(TipoExistencia.ProductosEnProceso)
                listaExec.Add(TipoExistencia.MateriaPrima)
                listaExec.Add(TipoExistencia.MaterialAuxiliar_SuministroRepuesto)
                listaExec.Add(TipoExistencia.EnvasesEmbalajes)

                Dim con = (From n In lista
                           Where listaExec.Contains(n.codigoDetalle)).ToList

                cboTipoExistencia.DisplayMember = "descripcion"
                cboTipoExistencia.ValueMember = "codigoDetalle"
                cboTipoExistencia.DataSource = con

        End Select
        cboTipoExistencia.SelectedIndex = -1
    End Sub



    'Sub UbicarAsientoPorId(asiento As asiento)
    '    Dim consulta = (From n In ListaAsientonTransito _
    '            Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '    If Not IsNothing(consulta) Then
    '        txtGlosaAsiento.Text = consulta.glosa
    '    End If
    'End Sub


    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    'Sub RegistrarMovimiento(nAsiento As asiento)

    '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '    Dim dt As New DataTable
    '    dt.Columns.Add("id", GetType(Integer))
    '    dt.Columns.Add("Modulo", GetType(String))
    '    dt.Columns.Add("cuenta", GetType(String))
    '    dt.Columns.Add("tipoAsiento", GetType(String))
    '    dt.Columns.Add("cant", GetType(Decimal))
    '    dt.Columns.Add("pumn", GetType(Decimal))
    '    dt.Columns.Add("importeMN", GetType(Decimal))
    '    dt.Columns.Add("pume", GetType(Decimal))
    '    dt.Columns.Add("importeME", GetType(Decimal))
    '    dt.Columns.Add("descripcion", GetType(String))

    '    Dim cosnulta = (From i In ListaMovimientos _
    '                   Where i.idAsiento = nAsiento.idAsiento).ToList


    '    For Each x In cosnulta
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = x.idmovimiento
    '        If Not IsNothing(x.cuenta) Then
    '            dr(1) = x.nombreEntidad
    '        Else
    '            dr(1) = String.Empty
    '        End If
    '        dr(2) = x.cuenta
    '        dr(3) = x.tipo
    '        dr(4) = x.Cant
    '        dr(5) = x.PUmn
    '        dr(6) = x.monto
    '        dr(7) = x.PUme
    '        dr(8) = x.montoUSD
    '        dr(9) = x.descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    dgvCompra.DataSource = dt
    'End Sub


#Region "Metodos Varios"

    Private Function GetTableGrid() As DataTable
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Correccion", GetType(String))
        dt.Columns.Add("grav", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("idPrese", GetType(String))
        dt.Columns.Add("nomPrese", GetType(String))
        dt.Columns.Add("idUM", GetType(String))
        dt.Columns.Add("nomUM", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("precMN", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("precME", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("almacenDestino", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("almacenBack", GetType(Integer))
        dt.Columns.Add("cuentaHaber", GetType(String))
        dt.Columns.Add("cantDisponible", GetType(Decimal))
        dt.Columns.Add("elementocosto", GetType(String))
        dt.Columns.Add("proceso", GetType(String))
        '     If cboOperacion.SelectedValue = "10.01" Then
        dt.Columns.Add("proyecto")
        dt.Columns.Add("codigoLote")
        'End If

        Return dt
    End Function

    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function GetTableCuentas() As DataTable
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(String))
        dt.Columns.Add("nombre", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function
#End Region


#Region "PERSONAS"
    Public Class Personal

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class
#End Region

#Region "PROVEEDOR"
    Public Sub InsertProveedor()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR

            If btnRuc.Checked = True Then
                objCliente.tipoDoc = "6"
            ElseIf btnDni.Checked = True Then
                objCliente.tipoDoc = "1"
            ElseIf btnPassport.Checked = True Then
                objCliente.tipoDoc = "7"
            ElseIf btnCarnetEx.Checked = True Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.cuentaAsiento = "4212"
            objCliente.estado = "A"
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            Dim codx As Integer = entidadSA.GrabarEntidad(objCliente)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            'lblEstado.Image = My.Resources.ok4

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.Tag = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "PERSONA"
    Public Sub GrabarPersona()
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        With personaBE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idPersona = txtDniTrab.Text.Trim
            .nombres = txtNombreTrab.Text.Trim
            .appat = txtAppatTrab.Text.Trim
            .apmat = txtApmatTrab.Text.Trim
            .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
        End With
        personaSA.InsertPersona(personaBE)
        txtProveedor.Tag = personaBE.idPersona
        txtProveedor.Text = personaBE.nombreCompleto
        txtRuc.Text = personaBE.idPersona
        txtCuenta = "TR"

        lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    End Sub

    Private Sub ObtenerPersonaPorNombre(strPersona As String)
        Dim PersonaSA As New PersonaSA
        lstPersonas.Items.Clear()
        For Each i In PersonaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, strPersona)
            lstPersonas.Items.Add(New Personal(i.nombreCompleto, i.idPersona))
        Next
        lstPersonas.DisplayMember = "Name"
        lstPersonas.ValueMember = "Id"
    End Sub
#End Region

#Region "Métodos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As ListViewItem)
    Public Sub setDatasource(ByVal table As ListViewItem)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            If table Is Nothing Then

            Else
                lsvExistencias.Items.Add(table)
            End If

            'For Each item As ListViewItem In lsvExistencias.Items
            '    Dim i As Short
            '    If i Mod 2 = 0 Then
            '        item.BackColor = Color.Transparent
            '        item.ForeColor = Color.Gray
            '    Else
            '        item.BackColor = Color.WhiteSmoke
            '        item.ForeColor = Color.Gray
            '    End If
            '    i = i + 1
            'Next
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub ObtenerListadoPreciosLiked(intIdAlmacen As Integer, strtipoEx As String, strBusqueda As String)
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            '     lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strtipoEx, strBusqueda)
                If i.cantidad > 0 Then
                    Dim n As New ListViewItem(i.idEstablecimiento)
                    n.SubItems.Add(i.origenRecaudo)
                    n.SubItems.Add(i.idItem)
                    n.SubItems.Add(i.descripcion)
                    n.SubItems.Add(i.unidadMedida)
                    n.SubItems.Add(String.Empty)
                    n.SubItems.Add(FormatNumber(i.cantidad, 2))
                    n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                    n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(CDec(i.importeSoles) / CDec(i.cantidad))
                    Else
                        n.SubItems.Add(0)
                    End If

                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(CDec(i.importeDolares) / CDec(i.cantidad))
                    Else
                        n.SubItems.Add(0)
                    End If




                    n.SubItems.Add(i.CustomLote.codigoLote)
                    n.SubItems.Add(i.CustomLote.nroLote)
                    n.SubItems.Add(i.CustomLote.fechaVcto.GetValueOrDefault)
                    'lsvExistencias.Items.Add(n)
                    setDatasource(n)
                End If

            Next
            setDatasource(Nothing)
            'For Each item As ListViewItem In lsvExistencias.Items
            '    Dim i As Short
            '    If i Mod 2 = 0 Then
            '        item.BackColor = Color.Transparent
            '        item.ForeColor = Color.Gray
            '    Else
            '        item.BackColor = Color.WhiteSmoke
            '        item.ForeColor = Color.Gray
            '    End If
            '    i = i + 1
            'Next

        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        '   Dim personaSA As New PersonaSA
        Dim personalSA As New PersonalSA

        Try
            lsvProveedor.Items.Clear()
            For Each i In personalSA.PersonalSelStartwithNombres(New Helios.Planilla.Business.Entity.Personal With {.Nombre = strBusqueda})
                Dim n As New ListViewItem(i.IDPersonal)
                n.SubItems.Add(i.FullName)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.Numerodocumento)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                txtCuenta = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            txtProveedor.Clear()

            txtRuc.Clear()
        End If
    End Sub

    Public Sub UbicarTrabPorDNI(strNumero As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, strNumero)
        If Not IsNothing(persona) Then
            With persona
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idPersona
                txtCuenta = "TR"
                txtRuc.Text = .idPersona
            End With
        End If
    End Sub

    Public Sub CargarListas()
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
        Dim almacenSA As New almacenSA
        '   Dim entidadSA As New entidadSA
        Dim almacen As New List(Of almacen)
        Dim categoriaSA As New itemSA

        almacen = almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "AF")
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacen

        'cboTipoExistencia.ValueMember = "codigoDetalle"
        'cboTipoExistencia.DisplayMember = "descripcion"
        'cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        'TIPO DE EXISTENCIA
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")

        'Dim listaNoExistencias As New List(Of String)

        'listaNoExistencias.Add("06")
        'listaNoExistencias.Add("07")
        'listaNoExistencias.Add("08")
        'listaNoExistencias.Add("02")
        'listaNoExistencias.Add("01")

        'Dim consultaExistencia = (From n In listatabla
        '                          Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        'cboTipoExistencia .DataSource = consultaExistencia
        cboTipoExistencia.DataSource = listatabla

        '''''

        Dim tabla As New List(Of tabladetalle)
        'Dim lista As New List(Of String)

        'lista.Add("04.01")
        'lista.Add("04.02")
        'lista.Add("06")
        'lista.Add("07.02")
        'lista.Add("08.02")
        'lista.Add("09.02")
        'lista.Add("10.01")
        'lista.Add("10.05")
        'lista.Add("11")
        'lista.Add("12")
        'lista.Add("13")
        'lista.Add("14")
        'lista.Add("15")
        'lista.Add("99.02")
        'lista.Add("99.09")


        'lista.Add("0001")
        'lista.Add("01")
        'lista.Add("02")
        'lista.Add("04.01")
        'lista.Add("04.02")
        'lista.Add("06")
        'lista.Add("07.02")
        'lista.Add("08.02")
        'lista.Add("09.02")
        'lista.Add("10.01")
        'lista.Add("10.05")
        'lista.Add("11")
        'lista.Add("12")
        'lista.Add("13")
        'lista.Add("14")
        'lista.Add("15")
        'lista.Add("99.02")
        'lista.Add("99.09")

        tabla = tablaSA.GetListaTablaDetalle(12, "1")

        'Dim con = (From n In tabla _
        '           Where lista.Contains(n.codigoDetalle) _
        '          Select n).ToList

        cboOperacion.ValueMember = "codigoDetalle"
        cboOperacion.DisplayMember = "descripcion"
        cboOperacion.DataSource = tabla ' tablaSA.Ge

        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        'lsvProveedor.Items.Clear()
        'For Each i As entidad In entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.PROVEEDOR, Gempresas.IdEmpresaRuc)
        '    Dim n As New ListViewItem(i.idEntidad)
        '    n.SubItems.Add(i.nombreCompleto)
        '    n.SubItems.Add(i.cuentaAsiento)
        '    n.SubItems.Add(i.nrodoc)
        '    lsvProveedor.Items.Add(n)
        'Next


        Dim dtUM As New DataTable
        dtUM.Columns.Add("ID")
        dtUM.Columns.Add("Name")

        'For Each i In tablaSA.GetListaTablaDetalle(6, "1")
        '    dtUM.Rows.Add(i.codigoDetalle, i.descripcion)
        'Next
        'Me.AutoComplete1.DataSource = dtUM
        'Me.AutoComplete1.SetAutoComplete(Me.txtUm, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)

        Dim dtPresentacion As New DataTable
        dtPresentacion.Columns.Add("IDPres")
        dtPresentacion.Columns.Add("NamePres")

        'For Each i In tablaSA.GetListaTablaDetalle(21, "1")
        '    dtPresentacion.Rows.Add(i.codigoDetalle, i.descripcion)
        'Next
        'Me.AutoComplete2.DataSource = dtPresentacion
        'Me.AutoComplete2.SetAutoComplete(Me.txtCodPresentacion, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)


        '    lstCategoria.DataSource = categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)

        'Select Case cboTipoExistencia.SelectedValue
        '    Case "01"
        '        txtCuentaName.Text = "Costo"
        '        txtCuentaCodigo.Text = "601111"
        '    Case "03"
        '        txtCuentaName.Text = "Costo"
        '        txtCuentaCodigo.Text = "602111"
        '    Case "04"
        '        txtCuentaName.Text = "Costo"
        '        txtCuentaCodigo.Text = "604111"
        '    Case "05"
        '        txtCuentaName.Text = "Costo"
        '        txtCuentaCodigo.Text = "603111"
        'End Select
    End Sub

#Region "Clases Asientos"

    Private Shared datos As List(Of Asientos_MN)
    Private Shared datosMov As List(Of Movimientos)
    ' Asiento contable Class.
    Private Class Asientos_MN
        Public Property AsientoID As Integer
        Public Property NombreAsiento As String
        Public Property Tipo As String
        'Public Property Country As String

        Public Shared Function GetAsientos() As List(Of Asientos_MN)

            If datos Is Nothing Then
                datos = New List(Of Asientos_MN)
            End If

            Return datos
        End Function



        Private Sub AddAsiento(objAsiento As Asientos_MN)
            datos.Add(objAsiento)
        End Sub



    End Class
    Public Class Movimientos

        Public Property IdMovimiento As Integer
        Public Property AsientoID As Integer
        Public Property Cuenta As String
        Public Property Descripcion As String
        Public Property Tipo As String
        Public Property Importemn As Decimal
        Public Property Importeme As Decimal


        Public Shared Function GetMovimientos() As List(Of Movimientos)

            If datosMov Is Nothing Then
                datosMov = New List(Of Movimientos)
            End If

            Return datosMov
        End Function

        Public Sub AddMovimiento(nMovimiento As Movimientos)
            datosMov.Add(nMovimiento)
        End Sub
    End Class
    ' Detalle movimientos del asiento Class.


    Private Sub DeletePorID(id As Integer)

        Dim queryResults = (From cust In datos
                            Where cust.AsientoID = id).First
        datos.Remove(queryResults)

        Dim ListaMov = (From n In datosMov
                        Where n.AsientoID = id).ToList

        For Each i In ListaMov
            datosMov.Remove(i)
        Next

        'lstAsientos.DataSource = Nothing
        'lstAsientos.DisplayMember = "NombreAsiento"
        'lstAsientos.ValueMember = "AsientoID"
        'lstAsientos.DataSource = datos

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub DeleteMovimientoID(id As Integer)

        Dim queryResults = (From cust In datosMov
                            Where cust.IdMovimiento = id).First
        datosMov.Remove(queryResults)

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub ubicarMovimientoporID(id As Integer)

        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = id).ToList

        'If queryResults.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        '    For Each I As Movimientos In queryResults
        '        If I.Tipo = "D" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, I.Importemn, I.Importeme, "0.00", "0.00", I.IdMovimiento)
        '        ElseIf I.Tipo = "H" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, "0.00", "0.00", I.Importemn, I.Importeme, I.IdMovimiento)
        '        End If

        '    Next
        '    lblEstado.Text = "Listado de movimientos"
        'Else
        '    dgvMovimiento.Rows.Clear()
        'End If


    End Sub


    Private Function ListarMovimientoporAsiento(id As Integer) As List(Of Movimientos)

        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = id).ToList


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosMN(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = idAsiento _
                            And cust.Tipo = strTipo
                            Select cust.Importemn).Sum


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosME(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov
                            Where cust.AsientoID = idAsiento _
                            And cust.Tipo = strTipo
                            Select cust.Importeme).Sum


        Return queryResults
    End Function
#End Region

#Region "ASIENTOS"
    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvMov.Table.Records
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(r.GetValue("almacenDestino")).idEstablecimiento
            objTotalesDet.idAlmacen = r.GetValue("almacenDestino")
            objTotalesDet.origenRecaudo = r.GetValue("grav")
            objTotalesDet.tipoCambio = txtTipoCambio.DecimalValue
            objTotalesDet.tipoExistencia = r.GetValue("tipoEx")
            objTotalesDet.idItem = r.GetValue("idItem")
            objTotalesDet.descripcion = r.GetValue("item")
            objTotalesDet.idUnidad = r.GetValue("idUM")
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(r.GetValue("cantidad") * -1, Decimal)
            objTotalesDet.precioUnitarioCompra = CType(r.GetValue("precMN"), Decimal)
            objTotalesDet.importeSoles = CType(r.GetValue("importeMN") * -1, Decimal)
            objTotalesDet.importeDolares = CType(r.GetValue("importeME") * -1, Decimal)
            objTotalesDet.montoIsc = 0
            objTotalesDet.montoIscUS = 0
            objTotalesDet.Otros = 0
            objTotalesDet.OtrosUS = 0
            objTotalesDet.porcentajeUtilidad = 0
            objTotalesDet.importePorcentaje = 0
            objTotalesDet.importePorcentajeUS = 0
            objTotalesDet.precioVenta = 0
            objTotalesDet.precioVentaUS = 0
            objTotalesDet.usuarioActualizacion = "NN"
            objTotalesDet.fechaActualizacion = Date.Now
            ListaTotales.Add(objTotalesDet)
        Next

        Return ListaTotales
    End Function

    Private Function ListaTotalesAlmacenOrigen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvMov.Table.Records
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(r.GetValue("almacenDestino"))).idEstablecimiento
            objTotalesDet.idAlmacen = r.GetValue("almacenDestino")
            objTotalesDet.origenRecaudo = r.GetValue("grav")
            objTotalesDet.tipoCambio = txtTipoCambio.DecimalValue
            objTotalesDet.tipoExistencia = r.GetValue("tipoEx")
            objTotalesDet.idItem = r.GetValue("idItem")
            objTotalesDet.descripcion = r.GetValue("item")
            objTotalesDet.idUnidad = r.GetValue("idUM")
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(r.GetValue("cantidad"), Decimal) * -1
            objTotalesDet.precioUnitarioCompra = CType(r.GetValue("precMN"), Decimal) * -1
            objTotalesDet.importeSoles = CType(r.GetValue("importeMN"), Decimal) * -1
            objTotalesDet.importeDolares = CType(r.GetValue("importeME"), Decimal) * -1
            objTotalesDet.montoIsc = 0
            objTotalesDet.montoIscUS = 0
            objTotalesDet.Otros = 0
            objTotalesDet.OtrosUS = 0
            objTotalesDet.porcentajeUtilidad = 0
            objTotalesDet.importePorcentaje = 0
            objTotalesDet.importePorcentajeUS = 0
            objTotalesDet.precioVenta = 0
            objTotalesDet.precioVentaUS = 0
            objTotalesDet.usuarioActualizacion = "NN"
            objTotalesDet.fechaActualizacion = Date.Now
            ListaTotales.Add(objTotalesDet)
        Next

        Return ListaTotales
    End Function

    'Sub AsientoTransferenciaEntreAlmacenes()
    '    Dim listaMovimiento As New List(Of Movimientos)
    '    Dim asientoBL As New asiento
    '    Dim nMovimiento As New movimiento
    '    Dim mascaraSA As New mascaraContable2SA
    '    Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
    '    Try
    '        asientoBL = New asiento
    '        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
    '        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
    '        asientoBL.idEntidad = txtProveedor.ValueMember
    '        asientoBL.nombreEntidad = txtProveedor.Text
    '        asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '        asientoBL.fechaProceso = fecha
    '        asientoBL.codigoLibro = "13"
    '        asientoBL.tipo = "D"
    '        asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
    '        asientoBL.importeMN = CDec(lblTotalAdquisiones.Text)
    '        asientoBL.importeME = CDec(lblTotalUS.Text)
    '        asientoBL.glosa = Glosa()

    '        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
    '            nMovimiento = New movimiento
    '            If i.Cells(13).Value = "01" Then
    '                nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, i.Cells(14).Value).cuentaDestinoKardex
    '            Else
    '                nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, i.Cells(14).Value, i.Cells(13).Value).cuentaIngAlmacen
    '            End If
    '            nMovimiento.descripcion = i.Cells(3).Value
    '            nMovimiento.tipo = "D"
    '            nMovimiento.monto = CDec(i.Cells(10).Value)
    '            nMovimiento.montoUSD = CDec(i.Cells(11).Value)
    '            nMovimiento.usuarioActualizacion = "Jiuni"
    '            nMovimiento.fechaActualizacion = DateTime.Now
    '            asientoBL.movimiento.Add(nMovimiento)
    '            asientoBL.movimiento.Add(HaberTransferenciaMOv(i))
    '        Next
    '        ListaAsientonTransito.Add(asientoBL)
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '    End Try
    'End Sub

    Function HaberTransferenciaMOv(i As DataGridViewRow) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        If i.Cells(13).Value = "01" Then
            nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, i.Cells(14).Value).cuentaDestinoKardex
        Else
            nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, i.Cells(14).Value, i.Cells(13).Value).cuentaIngAlmacen
        End If
        nMovimiento.descripcion = i.Cells(3).Value
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(i.Cells(10).Value)
        nMovimiento.montoUSD = CDec(i.Cells(11).Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Function HaberOtrasExistenciasMOv(r As Record) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        nMovimiento.cuenta = r.GetValue("cuentaHaber")
        nMovimiento.descripcion = r.GetValue("item")
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(r.GetValue("importeMN"))
        nMovimiento.montoUSD = CDec(r.GetValue("importeME"))
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Sub AsientoEntrada()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim TLmn As Decimal = 0
        Dim TLme As Decimal = 0
        For Each i In datos
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.glosa = i.NombreAsiento
            listaMovimiento = ListarMovimientoporAsiento(i.AsientoID)
            For Each x In listaMovimiento
                nMovimiento = New movimiento
                nMovimiento.cuenta = x.Cuenta
                nMovimiento.idAsiento = x.AsientoID
                nMovimiento.descripcion = x.Descripcion
                nMovimiento.tipo = x.Tipo
                nMovimiento.monto = x.Importemn
                nMovimiento.montoUSD = x.Importeme
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Next
            asientoBL.importeMN = SumatoriaMovimientosMN(i.AsientoID, "D")
            asientoBL.importeME = SumatoriaMovimientosME(i.AsientoID, "D")
            ListaAsientonTransito.Add(asientoBL)
        Next
    End Sub

    Sub AsientoEntradaExistencia()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            asientoBL = New asiento
            asientoBL.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            If chProv.Checked = True Then
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            Else
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
            End If
            asientoBL.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = sumaMN
            asientoBL.importeME = sumaME
            asientoBL.glosa = Glosa()

            If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
                For Each r As Record In dgvMov.Table.Records
                    If r.GetValue("estado") <> Business.Entity.BaseBE.EntityAction.DELETE Then
                        nMovimiento = New movimiento
                        Select Case r.GetValue("tipoEx")
                            Case "01"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "02"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS02.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "03"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS03.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "04"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS04.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "05"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS05.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "06"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS06.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "07"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS07.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            Case "08"
                                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS08.1")
                                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                        End Select
                        nMovimiento.descripcion = r.GetValue("item")
                        nMovimiento.tipo = "H"
                        nMovimiento.monto = CDec(r.GetValue("importeMN"))
                        nMovimiento.montoUSD = CDec(r.GetValue("importeME"))
                        nMovimiento.usuarioActualizacion = "Jiuni"
                        nMovimiento.fechaActualizacion = DateTime.Now
                        asientoBL.movimiento.Add(HaberOtrasExistenciasMOv(r))
                        asientoBL.movimiento.Add(nMovimiento)
                    End If
                Next
            End If
            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

#End Region

    'Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
    '    Dim asientoSA As New AsientoSA
    '    Dim movimientoSA As New MovimientoSA

    '    Dim objDoc As New DocumentoSA
    '    Dim objDocCompra As New DocumentoCompraSA
    '    Dim compraBE As New documentocompra
    '    Dim objDocCompraDet As New DocumentoCompraDetalleSA
    '    Dim CompraDet As New List(Of documentocompradetalle)
    '    Dim objTabla As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
    '    Dim objEntidad As New entidadSA
    '    Dim nEntidad As New entidad
    '    Dim VALUEDES As String = ""
    '    Dim insumosSA As New detalleitemsSA
    '    Dim almacenSA As New almacenSA
    '    Dim personaSA As New Planilla.WCFService.ServiceAccess.PersonalSA
    '    Dim persona As New Planilla.Business.Entity.Personal
    '    Dim recursoBL As New recursoCostoSA
    '    Dim recurso As New recursoCosto
    '    Try
    '        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)

    '        With objDoc.UbicarDocumento(intIdDocumento)
    '            txtFechaComprobante.Value = .fechaProceso
    '            cboOperacion.SelectedValue = .tipoOperacion
    '            'COMPROBANTE
    '            txtIdComprobante.Text = "99 - GUIA DE REMISION"

    '        End With

    '        'CABECERA COMPROBANTE
    '        compraBE = New documentocompra
    '        compraBE = objDocCompra.UbicarDocumentoCompra(intIdDocumento)

    '        Select Case compraBE.destino
    '            Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
    '                lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
    '                '  ToolStripLabel1.Text = "TRANSFERENCIA ENTRE ALMACENES"
    '            Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
    '                lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
    '                ' ToolStripLabel1.Text = "OTRAS ENTRADAS DE EXISTENCIAS"


    '        End Select

    '        lblIdDocumento.Text = compraBE.idDocumento
    '        txtFechaComprobante.Value = compraBE.fechaDoc
    '        lblPerido.Text = compraBE.fechaContable
    '        txtSerie.Text = compraBE.serie
    '        txtNumero.Text = compraBE.numeroDoc

    '        If Not IsNothing(compraBE.idProveedor) Then
    '            chProv.Checked = True
    '            chTrab.Checked = False

    '            'PROVEEDOR
    '            nEntidad = objEntidad.UbicarEntidadPorID(compraBE.idProveedor).First()
    '            txtRuc.Text = nEntidad.nrodoc
    '            txtCuenta = nEntidad.cuentaAsiento
    '            txtProveedor.Tag = nEntidad.idEntidad
    '            txtProveedor.Text = nEntidad.nombreCompleto

    '        Else
    '            chTrab.Checked = True
    '            chProv.Checked = False
    '            persona = personaSA.PersonalSelxID(New Planilla.Business.Entity.Personal With {.IDPersonal = compraBE.idPersona})
    '            If Not IsNothing(persona) Then
    '                txtRuc.Text = persona.Numerodocumento
    '                txtCuenta = "TR"
    '                txtProveedor.Tag = persona.IDPersonal
    '                txtProveedor.Text = persona.FullName
    '            End If
    '        End If

    '        txtGlosa.Text = compraBE.glosa
    '        txtTipoCambio.DecimalValue = compraBE.tcDolLoc

    '        'DETALLE DE LA COMPRA
    '        CompraDet = New List(Of documentocompradetalle)
    '        CompraDet = objDocCompraDet.GetUbicarDetalleCompraLote(intIdDocumento)
    '        For Each i In CompraDet
    '            '   almacenDestino = i.almacenRef
    '            Me.dgvMov.Table.AddNewRecord.SetCurrent()
    '            Me.dgvMov.Table.AddNewRecord.BeginEdit()
    '            Me.dgvMov.Table.CurrentRecord.SetValue("id", i.secuencia)

    '            Me.dgvMov.Table.CurrentRecord.SetValue("grav", i.destino)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("idItem", i.idItem)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("item", i.descripcionItem)

    '            If (i.unidad2.ToString.Trim.Length > 0) Then
    '                Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", i.unidad2)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", i.unidad2)
    '            Else
    '                Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", String.Empty)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", String.Empty)
    '            End If

    '            Me.dgvMov.Table.CurrentRecord.SetValue("idUM", i.unidad1)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", i.unidad1)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", i.monto1)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", i.precioUnitario)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", i.importe)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", i.precioUnitarioUS)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", i.importeUS)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", i.CuentaItem)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("almacenDestino", i.almacenRef)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", i.tipoExistencia)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("estado", 1)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("almacenBack", i.almacenRef)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("Correccion", "3")

    '            dgvMov.Table.CurrentRecord.SetValue("codigoLote", i.CustomRecursoCostoLote.codigoLote)
    '            Me.dgvMov.Table.AddNewRecord.EndEdit()
    '        Next
    '        ToolStripButton3.Visible = False
    '        'If Not IsNothing(CompraDet(0).idCosto) Then
    '        '    recurso = recursoBL.GetCostoById(New recursoCosto With {.idCosto = CompraDet(0).idCosto})

    '        '    If Not IsNothing(recurso) Then
    '        '        Select Case recurso.subtipo
    '        '            Case TipoCosto.Proyecto,
    '        '                TipoCosto.CONTRATOS_DE_CONSTRUCCION,
    '        '                TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS,
    '        '                TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES

    '        '                rbCosto.Checked = True
    '        '            Case TipoCosto.OrdenProduccion,
    '        '                TipoCosto.OP_CONTINUA_DE_BIENES,
    '        '                TipoCosto.OP_CONTINUA_DE_SERVICIOS,
    '        '                TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
    '        '                TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES,
    '        '                TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE

    '        '                rbCosto.Checked = True
    '        '            Case TipoCosto.ActivoFijo
    '        '                rbCosto.Checked = True
    '        '            Case TipoCosto.GastoAdministrativo
    '        '                rbGasto.Checked = True
    '        '            Case TipoCosto.GastoVentas
    '        '                rbGasto.Checked = True
    '        '            Case TipoCosto.GastoFinanciero
    '        '                rbGasto.Checked = True

    '        '        End Select
    '        '        txtTipoCosto.Text = recurso.subtipo
    '        '        cboCosto.SelectedValue = recurso.idCosto
    '        '    End If
    '        'End If


    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    Public Function Glosa() As String
        Dim str As String = Nothing
        If txtGlosa.Text.Trim.Length > 0 Then
            str = txtGlosa.Text.Trim()
        Else
            str = "Por movimientos de almacén-" & lblMovimiento.Text & ", con fecha: " & New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        End If
        Return str
    End Function

    Sub GrabarDefault()
        Dim costoSA As New recursoCostoSA
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim obj As New recursoCostoDetalle

        sumaMN = 0
        sumaME = 0
        'ListaAsientonTransito = New List(Of asiento)

        ListaAsiento = New List(Of asiento)

        dgvMov.TableControl.CurrentCell.EndEdit()
        dgvMov.TableControl.Table.TableDirty = True
        dgvMov.TableControl.Table.EndEdit()

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "99"
            .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .moneda = "1"
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            If chProv.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf chCli.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf chTrab.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = cboOperacion.SelectedValue
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .situacion = cboOperacion.SelectedValue
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaDoc = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .fechaContable = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text

            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)

            ElseIf chCli.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            ElseIf chTrab.Checked = True Then
                .idPersona = CInt(txtProveedor.Tag)
            End If

            .nombreProveedor = txtProveedor.Text
            '.monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .monedaDoc = "1"
            .tasaIgv = 0  ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = sumaMN
            .importeUS = sumaME

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text
            '.glosa = Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_VENTA.OTRAS_SALIDAS_PRODUCCION
            ' .DocumentoSustentado = "S"
            .aprobado = "N"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)

        If GroupBox2.Visible Then
            ndocumento.documentocompra.aprobado = "S"

            'ASIENTOS CONTABLES
            nAsiento = New asiento With {
                .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year,
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idCentroCostos = GEstableciento.IdEstablecimiento,
                .idDocumentoRef = Nothing,
                .idAlmacen = 0,
                .nombreAlmacen = cboAlmacen.Text,
                .idEntidad = txtProveedor.Tag,
                .nombreEntidad = txtProveedor.Text,
                .tipoEntidad = String.Empty,
                .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second),
                .codigoLibro = "13",
                .tipo = "D",
                .tipoAsiento = "AC_BL",
                .importeMN = 0,
                .importeME = 0,
                .glosa = txtGlosa.Text.Trim,
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
            }
        Else
            ndocumento.documentocompra.aprobado = "N"
        End If



        Dim almacenSA As New almacenSA

        If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
            For Each r As Record In dgvMov.Table.Records

                objDocumentoCompraDet = New documentocompradetalle
                objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = CInt(r.GetValue("codigoLote"))

                'If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

                'Else
                '    If tmpConfigInicio IsNot Nothing Then
                '        If tmpConfigInicio.proyecto = "S" Then
                '            objDocumentoCompraDet.idCosto = CInt(r.GetValue("proyecto"))
                '            objDocumentoCompraDet.tipoCosto = "PY"
                '        Else
                '            objDocumentoCompraDet.tipoCosto = Nothing
                '        End If
                '    Else
                '        objDocumentoCompraDet.tipoCosto = Nothing
                '    End If
                'End If


                objDocumentoCompraDet.TipoOperacion = cboOperacion.SelectedValue
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.FechaDoc = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                objDocumentoCompraDet.CuentaProvedor = txtCuenta
                objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
                objDocumentoCompraDet.TipoDoc = "99"
                objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
                objDocumentoCompraDet.Serie = txtSerie.Text.Trim
                objDocumentoCompraDet.destino = r.GetValue("grav")
                objDocumentoCompraDet.CuentaItem = String.Empty ' r.GetValue("cuenta")
                objDocumentoCompraDet.idItem = Val(r.GetValue("idItem"))
                objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("idUM")

                'If IsNumeric(r.GetValue("cantidad")) Then
                '    If CDec(r.GetValue("cantidad")) < 0 Then
                '        MessageBox.Show("El valor de la cantidad no puede ser negativo", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        Me.Cursor = Cursors.Arrow
                '        Exit Sub
                '    End If
                'End If

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                'If IsNumeric(r.GetValue("importeMN")) Then
                '    If CDec(r.GetValue("importeMN")) < 0 Then
                '        MessageBox.Show("El valor del importe no puede ser negativo", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        Me.Cursor = Cursors.Arrow
                '        Exit Sub
                '    End If
                'End If


                If IsNumeric(r.GetValue("importeMN")) Then
                    If CDec(r.GetValue("importeMN")) <= 0 Then
                        MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If Not CDec(r.GetValue("cantidad")) > 0 Then
                    Throw New Exception("Debe ingresar una cantidad mayor cero.")
                End If

                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))

                objDocumentoCompraDet.unidad2 = r.GetValue("idPrese") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = r.GetValue("nomPrese") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("precMN"))
                objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("precME"))
                objDocumentoCompraDet.importe = r.GetValue("importeMN")
                objDocumentoCompraDet.importeUS = r.GetValue("importeME")
                sumaMN += CDec(r.GetValue("importeMN"))
                sumaME += CDec(r.GetValue("importeME"))

                objDocumentoCompraDet.idCosto = txtidEntregable.Text
                objDocumentoCompraDet.idProceso = txtidEntregable.Text
                objDocumentoCompraDet.tipoCosto = txtTipoCosto.Text

                If txtTipoCosto.Text = "HC" Then
                    objDocumentoCompraDet.motivoCosto = "OTROS"
                ElseIf txtTipoCosto.Text = "HG" Then
                    objDocumentoCompraDet.motivoCosto = cboMotivoCosto.Text
                End If
                objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                Dim s1 As String = r.GetValue("almacenDestino").ToString
                If s1.Trim.Length > 0 Then
                    objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(r.GetValue("almacenDestino")).idEstablecimiento
                    objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacenDestino"))
                Else
                    lblEstado.Text = "Debe indicar un almacén de destino!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    Exit Sub
                End If
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))

                'objDocumentoCompraDet.Glosa = Glosa()
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoCompraDet)


            Next
        End If
        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME

        'nAsiento = asientoSalida()
        asientoSalidayCosteo()
        'ListaAsiento.Add(nAsiento)
        ' listaAsientoEnvio.Add(nAsiento)


        'ndocumento.asiento = ListaAsiento
        ndocumento.asiento = listaAsientoEnvio
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN



        Dim xcod As Integer = CompraSA.SaveOtrasSalidasProduccion(ndocumento)

        Alert = New Alert("Salida guardada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        Dispose()
    End Sub


    Public Sub asientoSalidayCosteo()

        Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim montototal As Decimal = CDec(0.0)
        Dim montototalme As Decimal = CDec(0.0)


        nAsiento = New asiento With {
                        .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year,
                       .idEmpresa = Gempresas.IdEmpresaRuc,
                       .idCentroCostos = GEstableciento.IdEstablecimiento,
                       .idDocumentoRef = Nothing,
                       .idAlmacen = 0,
                       .nombreAlmacen = cboAlmacen.Text,
                       .idEntidad = txtProveedor.Tag,
                       .nombreEntidad = txtProveedor.Text,
                       .tipoEntidad = String.Empty,
                       .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second),
                       .codigoLibro = "13",
                       .tipo = "D",
                       .tipoAsiento = "AC_BL",
                       .importeMN = 0,
                       .importeME = 0,
                       .glosa = txtGlosa.Text.Trim,
                       .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
                           }


        For Each r As Record In dgvMov.Table.Records

            If r.GetValue("tipoEx") = "01" Then   'mercarderia

                nMovimiento = New movimiento With {
                         .cuenta = "6111",
                         .descripcion = r.GetValue("item"),
                         .tipo = "D",
                         .monto = CDec(r.GetValue("importeMN")),
                         .montoUSD = CDec(r.GetValue("importeME")),
                         .usuarioActualizacion = usuario.IDUsuario,
                         .fechaActualizacion = DateTime.Now
                     }
                nAsiento.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento With {
                    .cuenta = "20111",
                    .descripcion = r.GetValue("item"),
                    .tipo = "H",
                    .monto = CDec(r.GetValue("importeMN")),
                    .montoUSD = CDec(r.GetValue("importeME")),
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                nAsiento.movimiento.Add(nMovimiento)



            ElseIf r.GetValue("tipoEx") = "03" Then    'materia prima
                If txtTipoCosto.Text = "HC" Then

                    nMovimiento = New movimiento With {
                             .cuenta = "6121",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDec(r.GetValue("importeMN")),
                             .montoUSD = CDec(r.GetValue("importeME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                    nAsiento.movimiento.Add(nMovimiento)

                ElseIf txtTipoCosto.Text = "HG" Then

                    nMovimiento = New movimiento With {
                            .cuenta = "659",
                            .descripcion = "OTROS GASTOS DE GESTION",
                            .tipo = "D",
                            .monto = CDec(r.GetValue("importeMN")),
                            .montoUSD = CDec(r.GetValue("importeME")),
                            .usuarioActualizacion = usuario.IDUsuario,
                            .fechaActualizacion = DateTime.Now
                        }
                    nAsiento.movimiento.Add(nMovimiento)

                End If
                nMovimiento = New movimiento With {
                    .cuenta = "241",
                    .descripcion = r.GetValue("item"),
                    .tipo = "H",
                    .monto = CDec(r.GetValue("importeMN")),
                    .montoUSD = CDec(r.GetValue("importeME")),
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }
                nAsiento.movimiento.Add(nMovimiento)

                ElseIf r.GetValue("tipoEx") = "04" Then     ' envases y enbalajes

                    nMovimiento = New movimiento With {
                             .cuenta = "6131",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDec(r.GetValue("importeMN")),
                             .montoUSD = CDec(r.GetValue("importeME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                    nAsiento.movimiento.Add(nMovimiento)


                    nMovimiento = New movimiento With {
                        .cuenta = "251",
                        .descripcion = r.GetValue("item"),
                        .tipo = "H",
                        .monto = CDec(r.GetValue("importeMN")),
                        .montoUSD = CDec(r.GetValue("importeME")),
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)


                ElseIf r.GetValue("tipoEx") = "05" Then      'suministros diversos

                    nMovimiento = New movimiento With {
                             .cuenta = "6141",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDec(r.GetValue("importeMN")),
                             .montoUSD = CDec(r.GetValue("importeME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                    nAsiento.movimiento.Add(nMovimiento)


                    nMovimiento = New movimiento With {
                        .cuenta = "261",
                        .descripcion = r.GetValue("item"),
                        .tipo = "H",
                        .monto = CDec(r.GetValue("importeMN")),
                        .montoUSD = CDec(r.GetValue("importeME")),
                        .usuarioActualizacion = usuario.IDUsuario,
                        .fechaActualizacion = DateTime.Now
                    }
                    nAsiento.movimiento.Add(nMovimiento)


                ElseIf r.GetValue("tipoEx") = "02" Then      'producto terminado

                    'nMovimiento = New movimiento With {
                    '         .cuenta = "211",
                    '         .descripcion = r.GetValue("item"),
                    '         .tipo = "D",
                    '         .monto = CDec(r.GetValue("importeMN")),
                    '         .montoUSD = CDec(r.GetValue("importeME")),
                    '         .usuarioActualizacion = usuario.IDUsuario,
                    '         .fechaActualizacion = DateTime.Now
                    '     }
                    'nAsiento.movimiento.Add(nMovimiento)


                    'nMovimiento = New movimiento With {
                    '    .cuenta = "711",
                    '    .descripcion = r.GetValue("item"),
                    '    .tipo = "H",
                    '    .monto = CDec(r.GetValue("importeMN")),
                    '    .montoUSD = CDec(r.GetValue("importeME")),
                    '    .usuarioActualizacion = usuario.IDUsuario,
                    '    .fechaActualizacion = DateTime.Now
                    '}
                    'nAsiento.movimiento.Add(nMovimiento)

                ElseIf r.GetValue("tipoEx") = "06" Then      'subproducto

                    'nMovimiento = New movimiento With {
                    '         .cuenta = "221",
                    '         .descripcion = r.GetValue("item"),
                    '         .tipo = "D",
                    '         .monto = CDec(r.GetValue("importeMN")),
                    '         .montoUSD = CDec(r.GetValue("importeME")),
                    '         .usuarioActualizacion = usuario.IDUsuario,
                    '         .fechaActualizacion = DateTime.Now
                    '     }
                    'nAsiento.movimiento.Add(nMovimiento)


                    'nMovimiento = New movimiento With {
                    '    .cuenta = "712",
                    '    .descripcion = r.GetValue("item"),
                    '    .tipo = "H",
                    '    .monto = CDec(r.GetValue("importeMN")),
                    '    .montoUSD = CDec(r.GetValue("importeME")),
                    '    .usuarioActualizacion = usuario.IDUsuario,
                    '    .fechaActualizacion = DateTime.Now
                    '}
                    'nAsiento.movimiento.Add(nMovimiento)


                End If


                montototal += CDec(r.GetValue("importeMN"))
                montototalme += CDec(r.GetValue("importeME"))
        Next

        listaAsientoEnvio.Add(nAsiento)
        ' costeoooo



        If txtTipoCosto.Text = "HC" Then
            If lbltipoentregable.Text = TipoCosto.COSTOS_POR_VALORACION Then

                'ASIENTO
                'nAsiento = New asiento
                'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                'nAsiento.idEntidad = 0
                'nAsiento.nombreEntidad = "SIN IDENTIDAD"
                'nAsiento.tipoEntidad = "OT"
                'nAsiento.fechaProceso = DateTime.Now
                'nAsiento.periodo = lblPerido.Text
                'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                'nAsiento.tipo = "D"
                'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                'nAsiento.importeMN = CDec(montototal)
                'nAsiento.importeME = CDec(montototalme)
                'nAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                'nAsiento.usuarioActualizacion = usuario.IDUsuario
                'nAsiento.fechaActualizacion = Date.Now


                'nMovimiento = New movimiento
                'nMovimiento.cuenta = txtCuentaCosto.Text
                'nMovimiento.descripcion = txtEntregable.Text
                'nMovimiento.tipo = "D"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "791"
                'nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                'nMovimiento.tipo = "H"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'listaAsientoEnvio.Add(nAsiento)
                ''2
                nAsiento = New asiento
                nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                'nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                nAsiento.idEntidad = 0
                nAsiento.nombreEntidad = "SIN IDENTIDAD"
                nAsiento.tipoEntidad = "OT"
                nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                nAsiento.tipo = "D"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                nAsiento.importeMN = CDec(montototal)
                nAsiento.importeME = CDec(montototalme)
                nAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                nAsiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.fechaActualizacion = Date.Now


                nMovimiento = New movimiento
                nMovimiento.cuenta = "231"
                nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(montototal)
                nMovimiento.montoUSD = CDec(montototalme)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = Date.Now
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "713"
                nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(montototal)
                nMovimiento.montoUSD = CDec(montototalme)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = Date.Now
                nAsiento.movimiento.Add(nMovimiento)

                listaAsientoEnvio.Add(nAsiento)
                ''3
                'nAsiento = New asiento
                'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                'nAsiento.idEntidad = 0
                'nAsiento.nombreEntidad = "SIN IDENTIDAD"
                'nAsiento.tipoEntidad = "OT"
                'nAsiento.fechaProceso = DateTime.Now
                'nAsiento.periodo = lblPerido.Text
                'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                'nAsiento.tipo = "D"
                'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                'nAsiento.importeMN = CDec(montototal)
                'nAsiento.importeME = CDec(montototalme)
                'nAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtidEntregable.Text
                'nAsiento.usuarioActualizacion = usuario.IDUsuario
                'nAsiento.fechaActualizacion = Date.Now


                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "694"
                'nMovimiento.descripcion = "SERVICIOS"
                'nMovimiento.tipo = "D"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "211"
                'nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                'nMovimiento.tipo = "H"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'listaAsientoEnvio.Add(nAsiento)

            ElseIf lbltipoentregable.Text = TipoCosto.COSTOS_POR_PROCESOS_PROD Then

                nAsiento = New asiento
                nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                'nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                nAsiento.idEntidad = 0
                nAsiento.nombreEntidad = "SIN IDENTIDAD"
                nAsiento.tipoEntidad = "OT"
                nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                nAsiento.tipo = "D"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                nAsiento.importeMN = CDec(montototal)
                nAsiento.importeME = CDec(montototalme)
                nAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                nAsiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.fechaActualizacion = Date.Now


                nMovimiento = New movimiento
                nMovimiento.cuenta = "231"
                nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(montototal)
                nMovimiento.montoUSD = CDec(montototalme)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = Date.Now
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "713"
                nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(montototal)
                nMovimiento.montoUSD = CDec(montototalme)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = Date.Now
                nAsiento.movimiento.Add(nMovimiento)

                listaAsientoEnvio.Add(nAsiento)

                ''ASIENTO
                'nAsiento = New asiento
                'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                '' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                'nAsiento.idEntidad = 0
                'nAsiento.nombreEntidad = "SIN IDENTIDAD"
                'nAsiento.tipoEntidad = "OT"
                'nAsiento.fechaProceso = DateTime.Now
                'nAsiento.periodo = lblPerido.Text
                'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                'nAsiento.tipo = "D"
                'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                'nAsiento.importeMN = CDec(montototal)
                'nAsiento.importeME = CDec(montototalme)
                'nAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                'nAsiento.usuarioActualizacion = usuario.IDUsuario
                'nAsiento.fechaActualizacion = Date.Now


                'nMovimiento = New movimiento
                'nMovimiento.cuenta = txtCuentaCosto.Text
                'nMovimiento.descripcion = txtEntregable.Text
                'nMovimiento.tipo = "D"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "791"
                'nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                'nMovimiento.tipo = "H"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'listaAsientoEnvio.Add(nAsiento)


                ''2
                'nAsiento = New asiento
                'nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                ''nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                'nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                'nAsiento.idEntidad = 0
                'nAsiento.nombreEntidad = "SIN IDENTIDAD"
                'nAsiento.tipoEntidad = "OT"
                'nAsiento.fechaProceso = DateTime.Now
                'nAsiento.periodo = lblPerido.Text
                'nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                'nAsiento.tipo = "D"
                'nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                'nAsiento.importeMN = CDec(montototal)
                'nAsiento.importeME = CDec(montototalme)
                'nAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                'nAsiento.usuarioActualizacion = usuario.IDUsuario
                'nAsiento.fechaActualizacion = Date.Now


                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "231"
                'nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                'nMovimiento.tipo = "D"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'nMovimiento = New movimiento
                'nMovimiento.cuenta = "713"
                'nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS EN PROCESO"
                'nMovimiento.tipo = "H"
                'nMovimiento.monto = CDec(montototal)
                'nMovimiento.montoUSD = CDec(montototalme)
                'nMovimiento.usuarioActualizacion = usuario.IDUsuario
                'nMovimiento.fechaActualizacion = Date.Now
                'nAsiento.movimiento.Add(nMovimiento)

                'listaAsientoEnvio.Add(nAsiento)



            ElseIf lbltipoentregable.Text = TipoCosto.COSTOS_POR_PROCESO_ESTIMADO Then
            End If
        ElseIf txtTipoCosto.Text = "HG" Then


            nAsiento = New asiento

            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            ' nAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idDocumentoRef = Nothing
            nAsiento.idAlmacen = 0
            nAsiento.nombreAlmacen = String.Empty
            nAsiento.idEntidad = String.Empty
            nAsiento.nombreEntidad = String.Empty
            nAsiento.tipoEntidad = String.Empty
            nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            nAsiento.codigoLibro = "8"
            nAsiento.tipo = "D"
            nAsiento.tipoAsiento = "ACCA"
            nAsiento.importeMN = CDec(montototal)
            nAsiento.importeME = CDec(montototalme)


            nAsiento.glosa = "Ingreso a centro de costo"
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now

            'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

            nMovimiento = New movimiento With {
                          .cuenta = txtCuentaCosto.Text,
                          .descripcion = txtEntregable.Text,
                              .tipo = "D",
                          .monto = CDec(montototal),
                          .montoUSD = CDec(montototalme),
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now
                      }
            nAsiento.movimiento.Add(nMovimiento)


            nMovimiento = New movimiento With {
                            .cuenta = "791",
                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                            .tipo = "H",
                            .monto = CDec(montototal),
                            .montoUSD = CDec(montototalme),
                            .usuarioActualizacion = usuario.IDUsuario,
                            .fechaActualizacion = DateTime.Now
                        }
            nAsiento.movimiento.Add(nMovimiento)

            listaAsientoEnvio.Add(nAsiento)
        End If



        'agregando asiento de costeo
        'For Each j In listaRecursos


        '    If j.tipoCosto = "HC" Or j.tipoCosto = "PC" Then
        '        'ASIENTO
        '        nAsiento = New asiento
        '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '        ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        '        nAsiento.idEntidad = 0
        '        nAsiento.nombreEntidad = "SIN IDENTIDAD"
        '        nAsiento.tipoEntidad = "OT"
        '        nAsiento.fechaProceso = DateTime.Now
        '        nAsiento.periodo = lblPerido.Text
        '        nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        '        nAsiento.tipo = "D"
        '        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        '        nAsiento.importeMN = j.montoMN
        '        nAsiento.importeME = j.montoME
        '        nAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & j.NombreProceso
        '        nAsiento.usuarioActualizacion = usuario.IDUsuario
        '        nAsiento.fechaActualizacion = Date.Now


        '        nMovimiento = New movimiento
        '        nMovimiento.cuenta = j.cuenta
        '        nMovimiento.descripcion = j.NombreProceso
        '        nMovimiento.tipo = "D"
        '        nMovimiento.monto = j.montoMN
        '        nMovimiento.montoUSD = j.montoME
        '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '        nMovimiento.fechaActualizacion = Date.Now
        '        nAsiento.movimiento.Add(nMovimiento)

        '        nMovimiento = New movimiento
        '        nMovimiento.cuenta = "791"
        '        nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
        '        nMovimiento.tipo = "H"
        '        nMovimiento.monto = j.montoMN
        '        nMovimiento.montoUSD = j.montoME
        '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '        nMovimiento.fechaActualizacion = Date.Now
        '        nAsiento.movimiento.Add(nMovimiento)

        '        listaAsientoEnvio.Add(nAsiento)
        '        ''2
        '        nAsiento = New asiento
        '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        '        'nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '        nAsiento.idEntidad = 0
        '        nAsiento.nombreEntidad = "SIN IDENTIDAD"
        '        nAsiento.tipoEntidad = "OT"
        '        nAsiento.fechaProceso = DateTime.Now
        '        nAsiento.periodo = lblPerido.Text
        '        nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        '        nAsiento.tipo = "D"
        '        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        '        nAsiento.importeMN = j.montoMN
        '        nAsiento.importeME = j.montoME
        '        nAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & j.NombreProceso
        '        nAsiento.usuarioActualizacion = usuario.IDUsuario
        '        nAsiento.fechaActualizacion = Date.Now


        '        nMovimiento = New movimiento
        '        nMovimiento.cuenta = "211"
        '        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        '        nMovimiento.tipo = "D"
        '        nMovimiento.monto = j.montoMN
        '        nMovimiento.montoUSD = j.montoME
        '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '        nMovimiento.fechaActualizacion = Date.Now
        '        nAsiento.movimiento.Add(nMovimiento)

        '        nMovimiento = New movimiento
        '        nMovimiento.cuenta = "711"
        '        nMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
        '        nMovimiento.tipo = "H"
        '        nMovimiento.monto = j.montoMN
        '        nMovimiento.montoUSD = j.montoME
        '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '        nMovimiento.fechaActualizacion = Date.Now
        '        nAsiento.movimiento.Add(nMovimiento)

        '        listaAsientoEnvio.Add(nAsiento)
        '        ''3
        '        nAsiento = New asiento
        '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '        ' nAsiento.idDocumento = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        '        nAsiento.idEntidad = 0
        '        nAsiento.nombreEntidad = "SIN IDENTIDAD"
        '        nAsiento.tipoEntidad = "OT"
        '        nAsiento.fechaProceso = DateTime.Now
        '        nAsiento.periodo = lblPerido.Text
        '        nAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        '        nAsiento.tipo = "D"
        '        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
        '        nAsiento.importeMN = j.montoMN
        '        nAsiento.importeME = j.montoME
        '        nAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & j.NombreProceso
        '        nAsiento.usuarioActualizacion = usuario.IDUsuario
        '        nAsiento.fechaActualizacion = Date.Now


        '        nMovimiento = New movimiento
        '        nMovimiento.cuenta = "694"
        '        nMovimiento.descripcion = "SERVICIOS"
        '        nMovimiento.tipo = "D"
        '        nMovimiento.monto = j.montoMN
        '        nMovimiento.montoUSD = j.montoME
        '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '        nMovimiento.fechaActualizacion = Date.Now
        '        nAsiento.movimiento.Add(nMovimiento)

        '        nMovimiento = New movimiento
        '        nMovimiento.cuenta = "211"
        '        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        '        nMovimiento.tipo = "H"
        '        nMovimiento.monto = j.montoMN
        '        nMovimiento.montoUSD = j.montoME
        '        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '        nMovimiento.fechaActualizacion = Date.Now
        '        nAsiento.movimiento.Add(nMovimiento)

        '        listaAsientoEnvio.Add(nAsiento)

        '    ElseIf j.tipoCosto = "HG" Or j.tipoCosto = "PG" Then


        '        nAsiento = New asiento
        '        nAsiento.periodo = PeriodoGeneral
        '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        '        ' nAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
        '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        '        nAsiento.idDocumentoRef = Nothing
        '        nAsiento.idAlmacen = 0
        '        nAsiento.nombreAlmacen = String.Empty
        '        nAsiento.idEntidad = String.Empty
        '        nAsiento.nombreEntidad = String.Empty
        '        nAsiento.tipoEntidad = String.Empty
        '        nAsiento.fechaProceso = DateTime.Now
        '        nAsiento.codigoLibro = "8"
        '        nAsiento.tipo = "D"
        '        nAsiento.tipoAsiento = "ACCA"
        '        nAsiento.importeMN = j.montoMN
        '        nAsiento.importeME = j.montoME


        '        nAsiento.glosa = "Ingreso a centro de costo"
        '        nAsiento.usuarioActualizacion = usuario.IDUsuario
        '        nAsiento.fechaActualizacion = DateTime.Now

        '        'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

        '        nMovimiento = New movimiento With {
        '                      .cuenta = j.cuenta,
        '                      .descripcion = j.NombreProceso,
        '                      .tipo = "H",
        '                      .monto = j.montoMN,
        '                      .montoUSD = j.montoME,
        '                      .usuarioActualizacion = usuario.IDUsuario,
        '                      .fechaActualizacion = DateTime.Now
        '                  }
        '        nAsiento.movimiento.Add(nMovimiento)


        '        nMovimiento = New movimiento With {
        '                        .cuenta = "791",
        '                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
        '                        .tipo = "D",
        '                        .monto = j.montoMN,
        '                        .montoUSD = j.montoME,
        '                        .usuarioActualizacion = usuario.IDUsuario,
        '                        .fechaActualizacion = DateTime.Now
        '                    }
        '        nAsiento.movimiento.Add(nMovimiento)

        '        listaAsientoEnvio.Add(nAsiento)
        '    End If
        'Next
        '///////////////


    End Sub

    'Sub EditarSalida()
    '    Dim CompraSA As New DocumentoCompraSA
    '    Dim DocCaja As New documento

    '    Dim ndocumento As New documento()
    '    Dim nDocumentoCompra As New documentocompra()
    '    Dim objDocumentoCompraDet As New documentocompradetalle

    '    Dim asientoSA As New AsientoSA
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento

    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    Dim ListaAsiento As New List(Of asiento)
    '    Dim objTotalesDet As New totalesAlmacen()
    '    Dim objActividadDeleteEO As New totalesAlmacen()
    '    Dim ListaTotales As New List(Of totalesAlmacen)
    '    Dim ListaDeleteEO As New List(Of totalesAlmacen)
    '    Dim almacensa As New almacenSA

    '    Dim ListaDetalle As New List(Of documentocompradetalle)

    '    sumaMN = 0
    '    sumaME = 0

    '    ListaAsiento = New List(Of asiento)

    '    dgvMov.TableControl.CurrentCell.EndEdit()
    '    dgvMov.TableControl.Table.TableDirty = True
    '    dgvMov.TableControl.Table.EndEdit()

    '    With ndocumento
    '        .Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        .idDocumento = lblIdDocumento.Text
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        If Not IsNothing(GProyectos) Then
    '            .idProyecto = GProyectos.IdProyectoActividad
    '        End If

    '        .tipoDoc = "99"
    '        .fechaProceso = txtFechaComprobante.Value
    '        .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
    '        .moneda = "1"
    '        .idEntidad = Val(txtProveedor.Tag)
    '        .entidad = txtProveedor.Text
    '        .nrodocEntidad = txtRuc.Text
    '        If chProv.Checked = True Then
    '            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '        ElseIf chCli.Checked = True Then
    '            .tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '        ElseIf chTrab.Checked = True Then
    '            .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
    '        End If
    '        .idOrden = Nothing ' Me.IdOrden
    '        .tipoOperacion = cboOperacion.SelectedValue
    '        .usuarioActualizacion = usuario.IDUsuario
    '        .fechaActualizacion = DateTime.Now
    '    End With

    '    With nDocumentoCompra
    '        .idDocumento = lblIdDocumento.Text
    '        .idPadre = lblIdDocumento.Text
    '        .situacion = cboOperacion.SelectedValue
    '        .codigoLibro = "13"
    '        .tipoDoc = "99"
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    '        .fechaDoc = txtFechaComprobante.Value ' PERIODO
    '        .fechaContable = lblPerido.Text
    '        .serie = txtSerie.Text.Trim
    '        .numeroDoc = txtNumero.Text

    '        If chProv.Checked = True Then
    '            .idProveedor = CInt(txtProveedor.Tag)

    '        ElseIf chCli.Checked = True Then
    '            .idProveedor = CInt(txtProveedor.Tag)
    '        ElseIf chTrab.Checked = True Then
    '            .idPersona = CInt(txtProveedor.Tag)
    '        End If

    '        .nombreProveedor = txtProveedor.Text
    '        '.monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
    '        .monedaDoc = "1"
    '        .tasaIgv = 0  ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
    '        .tcDolLoc = txtTipoCambio.DecimalValue
    '        .tipoRecaudo = Nothing
    '        .regimen = Nothing
    '        .tasaRegimen = 0
    '        .nroRegimen = Nothing

    '        .importeTotal = sumaMN
    '        .importeUS = sumaME

    '        .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
    '        .estadoPago = TIPO_COMPRA.PAGO.PAGADO
    '        .glosa = txtGlosa.Text
    '        '.glosa = Glosa()
    '        .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
    '        .tipoCompra = TIPO_VENTA.OTRAS_SALIDAS
    '        ' .DocumentoSustentado = "S"
    '        .aprobado = "N"
    '        .usuarioActualizacion = usuario.IDUsuario
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    ndocumento.documentocompra = nDocumentoCompra

    '    '   GuiaRemision(ndocumento)

    '    If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
    '        For Each r As Record In dgvMov.Table.Records
    '            objDocumentoCompraDet = New documentocompradetalle
    '            objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
    '            objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = CInt(r.GetValue("codigoLote"))
    '            objDocumentoCompraDet.codigoLote = CInt(r.GetValue("codigoLote"))
    '            objDocumentoCompraDet.tipoCosto = Nothing
    '            objDocumentoCompraDet.TipoOperacion = cboOperacion.SelectedValue
    '            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    '            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
    '            objDocumentoCompraDet.CuentaProvedor = txtCuenta
    '            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
    '            objDocumentoCompraDet.TipoDoc = "99"
    '            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
    '            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
    '            objDocumentoCompraDet.destino = r.GetValue("grav")
    '            objDocumentoCompraDet.CuentaItem = String.Empty ' r.GetValue("cuenta")
    '            objDocumentoCompraDet.idItem = Val(r.GetValue("idItem"))
    '            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
    '            objDocumentoCompraDet.descripcionItem = r.GetValue("item")
    '            objDocumentoCompraDet.unidad1 = r.GetValue("idUM")

    '            If IsNumeric(r.GetValue("cantidad")) Then
    '                If CDec(r.GetValue("cantidad")) <= 0 Then
    '                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Me.Cursor = Cursors.Arrow
    '                    Exit Sub
    '                End If
    '            End If


    '            If IsNumeric(r.GetValue("importeMN")) Then
    '                If CDec(r.GetValue("importeMN")) <= 0 Then
    '                    MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Me.Cursor = Cursors.Arrow
    '                    Exit Sub
    '                End If
    '            End If

    '            If Not CDec(r.GetValue("cantidad")) > 0 Then
    '                Throw New Exception("Debe ingresar una cantidad mayor cero.")
    '            End If

    '            objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))
    '            objDocumentoCompraDet.unidad2 = r.GetValue("idPrese") 'IDPRESENTACION
    '            objDocumentoCompraDet.monto2 = r.GetValue("nomPrese") ' PRESENTACION
    '            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("precMN"))
    '            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("precME"))
    '            objDocumentoCompraDet.importe = r.GetValue("importeMN")
    '            objDocumentoCompraDet.importeUS = r.GetValue("importeME")
    '            sumaMN += CDec(r.GetValue("importeMN"))
    '            sumaME += CDec(r.GetValue("importeME"))

    '            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
    '            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
    '            Dim s1 As String = r.GetValue("almacenDestino").ToString
    '            If s1.Trim.Length > 0 Then
    '                objDocumentoCompraDet.IdEstablecimiento = almacensa.GetUbicar_almacenPorID(r.GetValue("almacenDestino")).idEstablecimiento
    '                objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacenDestino"))
    '            Else
    '                lblEstado.Text = "Debe indicar un almacén de destino!"
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(5)
    '                Exit Sub
    '            End If
    '            objDocumentoCompraDet.fechaModificacion = DateTime.Now
    '            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))

    '            'objDocumentoCompraDet.Glosa = Glosa()
    '            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
    '            ListaDetalle.Add(objDocumentoCompraDet)
    '        Next
    '    End If
    '    ndocumento.documentocompra.importeTotal = sumaMN
    '    ndocumento.documentocompra.importeUS = sumaME


    '    nAsiento = asientoSalida()
    '    ListaAsiento.Add(nAsiento)

    '    ndocumento.asiento = ListaAsiento
    '    ndocumento.documentocompra.documentocompradetalle = ListaDetalle

    '    CompraSA.EditarOtraSalida(ndocumento)
    '    Alert = New Alert("Salida modificada", alertType.success)
    '    Alert.TopMost = True
    '    Alert.Show()
    '    Dispose()
    'End Sub

#End Region

#Region "PRODUCTOS"
    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        tbIGV.Renderer = styleRenderer1
        'Dim styleRenderer2 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        ' Panel2.Visible = False
    End Sub

    'Public Sub EditarItemEstablec(ByVal mat As ItemDS)
    '    Dim objitem As New detalleitems
    '    Dim itemSA As New detalleitemsSA
    '    Try
    '        'Se asigna cada uno de los datos registrados
    '        objitem.codigodetalle = txtCodigo.Text
    '        objitem.idItem = mat.Clasificacion   ' Trim(txtCodigoDocumento.Text)
    '        objitem.idEmpresa = Gempresas.IdEmpresaRuc
    '        objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
    '        objitem.cuenta = mat.Cuenta
    '        objitem.descripcionItem = mat.DescripcionItem
    '        objitem.presentacion = mat.Presentacion
    '        objitem.unidad1 = mat.UnidadMedida
    '        ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
    '        objitem.tipoExistencia = mat.TipoEx
    '        objitem.origenProducto = IIf(rbAfecta.Checked = True, "1", "2")
    '        objitem.tipoProducto = "I"

    '        objitem.usuarioActualizacion = "Jiuni"
    '        objitem.fechaActualizacion = DateTime.Now

    '        itemSA.UpdateProducto(objitem)
    '        Me.lblEstado.Image = My.Resources.ok4
    '        Me.lblEstado.Text = "Item actualizado!"
    '    Catch ex As Exception
    '        'Manejo de errores
    '        MsgBox("No se pudo grabar el Producto." & vbCrLf & ex.Message)
    '    End Try
    'End Sub
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

    Private Sub frmOtrasSalidasDeAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub


    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

    Private Function comboTableCO() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "CORREGIR IMPORTE"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "CORREGIR CANTIDAD"
        dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow()
        dr3(0) = "3"
        dr3(1) = "CORREGIR IMPORTE CANTIDAD"
        dt.Rows.Add(dr3)

        Return dt
    End Function
    '/ddd
    Dim comboTable2 As New DataTable
    Dim comboTableh As New DataTable
    Private comboTableCOR As DataTable
    Private Sub frmOtrasSalidasDeAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblEmpresa.Text = Gempresas.NomEmpresa
        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        Me.dgvMov.TableDescriptor.VisibleColumns.Add("cantDisponible")
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").Width = 100
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").HeaderText = "Stock disponible"
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").Appearance.AnyRecordFieldCell.BackColor = Color.MistyRose
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").Appearance.AnyRecordFieldCell.TextColor = Color.Black

        Me.dgvMov.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.BackColor = Color.LightYellow
        Me.dgvMov.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.TextColor = Color.Black

        GetTableAlmacen2()

        Me.dgvMov.Engine.CounterLogic = EngineCounters.FilteredRecords
        comboTableCuentas = Me.GetTableCuentas
        comboTable = Me.GetTableAlmacen

        comboTableCOR = Me.comboTableCO
        Dim ggcStylec As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("Correccion").Appearance.AnyRecordFieldCell
        ggcStylec.CellType = "ComboBox"
        ggcStylec.DataSource = Me.comboTableCOR
        ggcStylec.ValueMember = "id"
        ggcStylec.DisplayMember = "name"

        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("almacenDestino").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"

        Dim ggcStyle1 As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("cuentaHaber").Appearance.AnyRecordFieldCell
        ggcStyle1.CellType = "ComboBox"
        ggcStyle1.DataSource = Me.comboTableCuentas
        ggcStyle1.ValueMember = "idCuenta"
        ggcStyle1.DisplayMember = "nombre"

        'ContextMenuStrip = New ContextMenuStrip()
        'ContextMenuStrip.Items.Add("Ver últimas entradas", My.Resources.b_docsql)
        'ContextMenuStrip.Items.Add("Eliminar item", My.Resources.b_drop)
        'AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        'AddHandler Me.dgvMov.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Ver últimas entradas" Then
                '   Me.dgvCompra.Table.CurrentRecord.Delete()
                Dim a As New frmUltimasOtrasSalidasAlmacen()
                'a.txtAlmacen.Text = Me.dgvMov.Table.CurrentRecord.GetValue("almacenDestino")
                a.ObtenerAlmacen(Me.dgvMov.Table.CurrentRecord.GetValue("almacenDestino"))
                a.idItem = Me.dgvMov.Table.CurrentRecord.GetValue("idItem")
                a.StartPosition = FormStartPosition.CenterParent
                a.ShowDialog()
            ElseIf e.ClickedItem.Text = "Eliminar item" Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.dgvMov.Table.CurrentRecord.Delete()
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvMov.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvMov.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvMov.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs)
        If chProv.Checked = True Then
            Me.PopupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer1.ParentControl = Me.txtProveedor
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
        End If
        If chTrab.Checked = True Then
            Me.pcPersonas.Font = New Font("Segoe UI", 8)
            Me.pcPersonas.ParentControl = Me.txtProveedor
            Me.pcPersonas.ShowPopup(Point.Empty)
        End If

    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs)
        Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs)
        Me.PopupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Me.PopupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub


    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
    End Sub


    Private Sub txtAlmacenDestino_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Focus()
        End If
    End Sub

    Private Sub cboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged

    End Sub

    'Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs)
    '    Dim objInsumo As New detalleitemsSA
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    If lsvListadoItems.SelectedItems.Count > 0 Then
    '        With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))

    '            Me.dgvMov.Table.AddNewRecord.SetCurrent()
    '            Me.dgvMov.Table.AddNewRecord.BeginEdit()
    '            Me.dgvMov.Table.CurrentRecord.SetValue("id", 0)

    '            Me.dgvMov.Table.CurrentRecord.SetValue("grav", .origenProducto)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("item", .descripcionItem)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", .presentacion)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", tablaSA.GetUbicarTablaID(21, .presentacion).descripcion)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("idUM", .unidad1)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", tablaSA.GetUbicarTablaID(6, .unidad1).descripcion)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0.0)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0.0)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0.0)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0.0)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0.0)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", .cuenta)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", .tipoExistencia)
    '            Me.dgvMov.Table.CurrentRecord.SetValue("estado", 0)
    '            Me.dgvMov.Table.AddNewRecord.EndEdit()
    '        End With
    '    End If
    'End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs)
        'If dgvNuevoDoc.Rows.Count > 0 Then
        '    CellEndEditRefresh()
        'End If
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
    End Sub


    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtApePat.Select()
                Exit Sub
            End If
        End If
        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelarProv_Click(sender As Object, e As EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            Label30.Text = "Nombres:"

            If btnRuc.Checked = True Then
                If rbNatural.Checked = True Then
                    txtDocProveedor.Text = "10"
                    txtDocProveedor.Select()
                End If
            End If
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            Label30.Text = "Nombre o Razón Social:"

            If btnRuc.Checked = True Then
                If rbJuridico.Checked = True Then
                    txtDocProveedor.Text = "20"
                    txtDocProveedor.Select()
                End If
            End If
        End If
    End Sub

    Private Sub btnRuc_Click(sender As Object, e As EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As Object, e As EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnPassport_Click(sender As Object, e As EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As Object, e As EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        If chProv.Checked = True Then
            txtDocProveedor.Clear()
            txtNomProv.Clear()
            txtApePat.Clear()
            pcProveedor.Font = New Font("Segoe UI", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
        End If

        If chTrab.Checked = True Then
            txtDniTrab.Clear()
            txtNombreTrab.Clear()
            txtAppatTrab.Clear()
            txtApmatTrab.Clear()
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        dockingManager1.SetDockVisibility(PanelNuevoItem, False)
        dockingManager1.SetDockVisibility(Panel2, True)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnGrabTRab_Click(sender As Object, e As EventArgs) Handles btnGrabTRab.Click
        If Not txtDniTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtDniTrab.Select()
            Exit Sub
        End If

        If Not txtNombreTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtNombreTrab.Select()
            Exit Sub
        End If

        If Not txtAppatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtAppatTrab.Select()
            Exit Sub
        End If

        If Not txtApmatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtApmatTrab.Select()
            Exit Sub
        End If

        btnGrabTRab.Tag = "G"
        Me.pcTrabajador.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcTrabajador.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del proveedor"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(327, 259)
                    Me.pcProveedor.ParentControl = Me.txtProveedor
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtApePat.Select()
                    Exit Sub
                End If
            End If
            If btnGRabarProv.Tag = "G" Then
                InsertProveedor()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub pcTrabajador_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcTrabajador.BeforePopup
        Me.pcTrabajador.BackColor = Color.White
    End Sub

    Private Sub pcTrabajador_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcTrabajador.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDniTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtDniTrab.Select()
                Exit Sub
            End If

            If Not txtNombreTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtNombreTrab.Select()
                Exit Sub
            End If

            If Not txtAppatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtAppatTrab.Select()
                Exit Sub
            End If

            If Not txtApmatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtApmatTrab.Select()
                Exit Sub
            End If

            If btnGrabTRab.Tag = "G" Then
                GrabarPersona()
                btnGrabTRab.Tag = "N"
            Else
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub pcPersonas_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcPersonas.BeforePopup
        Me.pcPersonas.BackColor = Color.White
    End Sub

    Private Sub pcPersonas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcPersonas.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstPersonas.SelectedItems.Count > 0 Then
                txtProveedor.Tag = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
                txtProveedor.Text = lstPersonas.Text
                txtCuenta = "TR"
                txtRuc.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        If lstPersonas.SelectedItems.Count > 0 Then
            Me.pcPersonas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstPersonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPersonas.SelectedIndexChanged

    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs)
        chProv.Checked = True
        chTrab.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()

    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs)
        chProv.Checked = False
        chTrab.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub txtFiltroTrab_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltroTrab.KeyDown

    End Sub

    Private Sub txtFiltroTrab_TextChanged(sender As Object, e As EventArgs) Handles txtFiltroTrab.TextChanged

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        If txtFiltroTrab.Text.Trim.Length > 0 Then
            ObtenerPersonaPorNombre(txtFiltroTrab.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub PopupControlContainer2_Popup(sender As Object, e As EventArgs) Handles PopupControlContainer2.Popup
        lstCategoria.Focus()
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub

    Private Sub dgvMov_TableControlCurrentCellEditingComplete(sender As Object, e As Grid.Grouping.GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If ColIndex > -1 Then
        '        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then


        '            'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
        '            '''''''''''

        '            If ColIndex = 7 Or ColIndex = 9 Then
        '                ''''''''
        '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then



        '                    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
        '                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

        '                    'ValidarCantidadDisponible(Me.dgvMov.Table.CurrentRecord)
        '                    'If colCantidad = 0 Then
        '                    If colCantidad <= 0 Then
        '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " debe ser mayor a cero"
        '                        PanelError.Visible = True
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                        Timer1.Enabled = True
        '                        TiempoEjecutar(10)
        '                        Exit Sub
        '                    End If

        '                    If colCantidad > colCantidadDisponible Then
        '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
        '                        PanelError.Visible = True
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                        Timer1.Enabled = True
        '                        TiempoEjecutar(10)
        '                        Exit Sub
        '                    End If
        '                    Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
        '                    Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

        '                    Dim colImporteMN = colCantidad * colPUmn
        '                    Dim colImporteME = colCantidad * colPUme
        '                    If colImporteMN > 0 AndAlso colCantidad > 0 Then

        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


        '                    End If

        '                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

        '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
        '                    '    Dim decg As Decimal
        '                    '    Dim tipocam = txtTipoCambio.Text
        '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
        '                    'Else
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                    'End If
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    ''''
        '                End If
        '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '            ElseIf ColIndex = 8 Then
        '                ''''''
        '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then


        '                    '''''
        '                    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
        '                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

        '                    If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
        '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                        Timer1.Enabled = True
        '                        TiempoEjecutar(10)
        '                        Exit Sub
        '                    End If


        '                    Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
        '                    Dim colPUme As Decimal = 0

        '                    Dim colImporteMN = colCantidad * colPUmn
        '                    Dim colImporteME = 0
        '                    If colImporteMN > 0 AndAlso colCantidad > 0 Then

        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)

        '                        If Me.dgvMov.Table.CurrentRecord.GetValue("precME") = 0 Then
        '                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme)
        '                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)
        '                        End If

        '                    End If


        '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


        '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
        '                    '    Dim decg As Decimal
        '                    '    Dim tipocam = txtTipoCambio.Text
        '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
        '                    'Else
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                    'End If
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


        '                End If
        '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 1, GridSetCurrentCellOptions.SetFocus)
        '            ElseIf ColIndex = 10 Then ' precio unit dolares
        '                '''''
        '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
        '                    '''''
        '                    Dim montoME As Decimal = 0
        '                    montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
        '                    '''''''''''''''''''''''''''''''''''''''''''

        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

        '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
        '                    '    Dim decg As Decimal
        '                    '    Dim tipocam = txtTipoCambio.Text
        '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
        '                    'Else
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                    'End If
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


        '                End If
        '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '            ElseIf ColIndex = 2 Then


        '                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


        '            ElseIf ColIndex = 11 Then


        '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
        '                    '''''
        '                    'Dim montoME As Decimal = 0
        '                    'montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
        '                    'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
        '                    '''''''''''''''''''''''''''''''''''''''''''

        '                    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
        '                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

        '                    If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
        '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                        Timer1.Enabled = True
        '                        TiempoEjecutar(10)
        '                        Exit Sub
        '                    End If
        '                    Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
        '                    Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

        '                    Dim colImporteMN = colCantidad * colPUmn
        '                    Dim colImporteME = colCantidad * colPUme
        '                    If colImporteMN > 0 AndAlso colCantidad > 0 Then

        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


        '                    End If


        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


        '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

        '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
        '                    '    Dim decg As Decimal
        '                    '    Dim tipocam = txtTipoCambio.Text
        '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
        '                    'Else
        '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                    'End If
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


        '                End If


        '            End If

        '            Select Case ColIndex
        '                Case 7
        '                    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)

        '                Case 7
        '                    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 12, GridSetCurrentCellOptions.SetFocus)
        '            End Select





        '        End If
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = "Error: " & ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try
    End Sub

    Private Sub dgvMov_QueryCellStyleInfo(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.LightYellow
                e.Style.Format = "##.00"
            End If
            If e.TableCellIdentity.Column.MappingName = "importeMN" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.LightYellow
                e.Style.Format = "S/.##.00"
            End If
            If e.TableCellIdentity.Column.MappingName = "almacenDestino" Then
                e.Style.BackColor = Color.LightYellow
            End If
            If e.TableCellIdentity.Column.MappingName = "Correccion" Then
                e.Style.BackColor = Color.LightYellow
            End If

        End If


        '''''''''''''''''''

        'If Not IsNothing(e.TableCellIdentity.Column) Then
        '    Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then

        '        Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
        '        If Not IsNothing(str) Then
        '            Select Case str
        '                Case "3" '  "DEVOLUCION DE EXISTENCIAS"
        '                    e.Style.[ReadOnly] = False
        '                    'e.Style.BackColor = Color.AliceBlue
        '                    'Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
        '                Case "1" ' "DISMINUIR CANTIDAD"
        '                    e.Style.[ReadOnly] = True
        '                    'e.Style.BackColor = Color.AliceBlue
        '                Case "2" '"DISMINUIR IMPORTE"
        '                    e.Style.[ReadOnly] = False

        '                    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then

        '                        '  Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

        '                    End If

        '            End Select
        '        End If


        '    ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importeMN")) Then
        '        Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
        '        If Not IsNothing(str) Then
        '            Select Case str
        '                Case "3" '  "DEVOLUCION DE EXISTENCIAS"
        '                    e.Style.[ReadOnly] = False
        '                    'e.Style.BackColor = Color.AliceBlue
        '                    '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
        '                Case "1" ' "DISMINUIR CANTIDAD"
        '                    e.Style.[ReadOnly] = False
        '                    'e.Style.BackColor = Color.AliceBlue

        '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
        '                    'Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

        '                Case "2" '"DISMINUIR IMPORTE"
        '                    e.Style.[ReadOnly] = True
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
        '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
        '                    'e.Style.BackColor = Color.AliceBlue
        '            End Select
        '        End If


        '    End If



        'End If


        ''''''''''''''''''''''''







    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown

        Me.Cursor = Cursors.WaitCursor

        Dim idalmacen As Integer = cboAlmacen.SelectedValue
        Dim tipoExist As String = cboTipoExistencia.SelectedValue
        Dim itemBusqueda As String = txtBuscarProducto.Text.Trim


        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtBuscarProducto.Text.Trim.Length > 0 Then


                idalmacen = cboAlmacen.SelectedValue
                tipoExist = cboTipoExistencia.SelectedValue
                itemBusqueda = txtBuscarProducto.Text.Trim

                lsvExistencias.Items.Clear()
                ProgressBar1.Visible = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() ObtenerListadoPreciosLiked(idalmacen, tipoExist, itemBusqueda)))
                thread.Start()

                'ObtenerListadoPreciosLiked(cboAlmacen.SelectedValue, cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
            Else

                lblEstado.Text = "Escriba una Deacripcion!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvExistencias_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvExistencias.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        Dim itemsSA As New detalleitemsSA
        Dim almacenSA As New almacenSA
        Dim boollExiste As Boolean = False
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
        Try
            If lsvExistencias.SelectedItems.Count > 0 Then

                'ValidarItemsDuplicados(Val(lsvExistencias.SelectedItems(0).SubItems(2).Text))


                With itemsSA.InvocarProductoID(lsvExistencias.SelectedItems(0).SubItems(2).Text)
                    strUM = .unidad1
                    strTipoEx = .tipoExistencia
                    strCuenta = .cuenta
                    strIdPresentacion = .presentacion
                End With

                With almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue)
                    srtNomAlmacen = .descripcionAlmacen
                    intIdEstableAlm = .idEstablecimiento
                End With


                With itemsSA.InvocarProductoID(CInt(lsvExistencias.SelectedItems(0).SubItems(2).Text))

                    Me.dgvMov.Table.AddNewRecord.SetCurrent()
                    Me.dgvMov.Table.AddNewRecord.BeginEdit()
                    Me.dgvMov.Table.CurrentRecord.SetValue("id", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Correccion", "3")
                    Me.dgvMov.Table.CurrentRecord.SetValue("grav", .origenProducto)
                    Me.dgvMov.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                    Me.dgvMov.Table.CurrentRecord.SetValue("item", .descripcionItem)
                    Me.dgvMov.Table.CurrentRecord.SetValue("idPrese", .presentacion)
                    Me.dgvMov.Table.CurrentRecord.SetValue("nomPrese", String.Empty)
                    Me.dgvMov.Table.CurrentRecord.SetValue("idUM", .unidad1)
                    Me.dgvMov.Table.CurrentRecord.SetValue("nomUM", .unidad1)
                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("cantDisponible", CDec(lsvExistencias.SelectedItems(0).SubItems(6).Text))
                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", CDec(lsvExistencias.SelectedItems(0).SubItems(9).Text))
                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", CDec(lsvExistencias.SelectedItems(0).SubItems(10).Text))
                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0.0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("cuenta", .cuenta)
                    Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", .tipoExistencia)
                    Me.dgvMov.Table.CurrentRecord.SetValue("almacenDestino", cboAlmacen.SelectedValue)
                    Me.dgvMov.Table.CurrentRecord.SetValue("estado", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("codigoLote", CInt(lsvExistencias.SelectedItems(0).SubItems(11).Text))
                    Me.dgvMov.Table.AddNewRecord.EndEdit()
                End With


            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvExistencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvExistencias.SelectedIndexChanged

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Me.Cursor = Cursors.WaitCursor

        Try
            If Not txtGlosa.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el detalle de la operación!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                txtGlosa.Select()
                Exit Sub
            End If

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de serie!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

                Exit Sub
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de guía de remisión!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

                Exit Sub
            End If
            Dim codProv = txtProveedor.Tag
            If IsNothing(codProv) Then
                lblEstado.Text = "Ingrese el personal!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not codProv.ToString.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el personal!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow

                Exit Sub
            End If

            'If cboOperacion.Text = "SALIDA DE INVENTARIOS PARA PRODUCCION" Then
            '    If Not cboElementoCosto.Text.Trim.Length > 0 Then
            '        Me.lblEstado.Text = "Debe seleccionar el destino del costo"
            '        PanelError.Visible = True
            '        Timer1.Enabled = True
            '        TiempoEjecutar(5)
            '        Me.Cursor = Cursors.Arrow
            '        Exit Sub
            '    End If
            'End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = cboMesCompra.SelectedValue})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
                If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
                    If MessageBox.Show("Desea realizar la operación de sálida con fecha: " & vbCrLf &
                                               New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second), "Verifique la fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        GrabarDefault()
                    End If

                Else
                    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                End If

            Else
                Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = cboMesCompra.SelectedValue})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then


                Else
                    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            TiempoEjecutar(10)
            Timer1.Enabled = True
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub dgvAsiento_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub





    Private Sub lstAsiento_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lstAsiento_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then


        '    RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        '    UbicarAsientoPorId(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        'End If
    End Sub

    Private Sub ToolStrip4_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then
        '    Dim consulta = (From n In ListaMovimientos _
        '                   Where n.idAsiento = lstAsiento.SelectedValue).ToList

        '    If consulta.Count > 0 Then

        '        Dim f As New frmViewAsiento(consulta)
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        'updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        'RegistrarAsientos()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs)
        'Dim consulta = (From n In ListaAsientonTransito _
        '        Where n.idAsiento = lstAsiento.SelectedValue).FirstOrDefault


        'If Not IsNothing(consulta) Then
        '    Dim listaMov = (From i In ListaMovimientos _
        '                   Where i.idAsiento = lstAsiento.SelectedValue).ToList

        '    For Each obj In listaMov
        '        ListaMovimientos.Remove(obj)
        '    Next
        '    ListaAsientonTransito.Remove(consulta)
        '    GetasientosListbox()
        '    lstAsiento_SelectedIndexChanged(sender, e)
        'End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then
        '    RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        '    RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        'End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)
        'If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
        '    Dim rec As Record = dgvCompra.Table.CurrentRecord
        '    Dim consulta = (From n In ListaMovimientos _
        '                   Where n.idmovimiento = rec.GetValue("id")).First

        '    If Not IsNothing(consulta) Then
        '        ListaMovimientos.Remove(consulta)
        '        Me.dgvCompra.Table.CurrentRecord.Delete()
        '    End If
        'End If
        'lstAsiento_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    'Select Case ColIndex
        '    '    Case 4
        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

        '    '        'Case 7
        '    '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
        '    'End Select

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 2 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 4 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 7 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If

        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs)
        'Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell

        ''Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        'If cc.ColIndex = 1 Then
        '    cc.ConfirmChanges()
        '    ' Me.dgvCompra.TableModel(cc.RowIndex, cc.ColIndex + 1).CellValue = "Hai"
        '    '  updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    Dim str = Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue
        '    If str = "H" Then
        '        Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "D"
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    Else
        '        Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "H"
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
        'If cc.ColIndex = 3 Then

        '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        'End If
        'If cc.ColIndex = 2 Then

        '    updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        'End If

        ''Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        ''If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        ''    If ColIndex = 1 Then
        ''        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        ''    End If
        ''    If ColIndex = 3 Then
        ''        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        ''    End If
        ''End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    'Select Case ColIndex
        '    '    Case 4
        '    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

        '    '        'Case 7
        '    '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
        '    'End Select

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 2 Then

        '        Dim cuentaSA As New cuentaplanContableEmpresaSA

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)

        '        'Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta"))
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 4 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 7 Then

        '        Dim colMN As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")
        '        Dim cant As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("cant")
        '        Dim colPUMN As Decimal = Math.Round(colMN / cant, 2).ToString("N2")

        '        Dim colPUME As Decimal = Math.Round(colMN / txtTipoCambio.DecimalValue, 2).ToString("N2")
        '        Dim colME As Decimal = Math.Round(colPUME / cant, 2).ToString("N2")

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", colME)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPUME)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPUMN)


        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    'If ColIndex = 3 Then
        '    '    Dim importeDebeME As Decimal = 0

        '    '    If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
        '    '        importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
        '    '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        '    '    End If

        '    'End If
        '    'If ColIndex = 4 Then
        '    '    Dim importeHaberME As Decimal = 0

        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
        '    '    importeHaberME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
        '    '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")

        '    'End If
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs)
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 6 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus

    End Sub

    Private Sub txtNumero_KeyDown1(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtProveedor.Select()
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus1(sender As Object, e As EventArgs)
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try
    End Sub
    Public Property txtCuenta As String
    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.PopupControlContainer1.ParentControl = Me.txtProveedor
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel(TIPO_ENTIDAD.PERSONA_GENERAL, txtProveedor.Text.Trim)

            ElseIf chCli.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick_1(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub chProv_Click_1(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click_1(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chCli.Checked = False
        chTrab.Checked = True
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If chProv.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarEntidadPorRuc(txtRuc.Text.Trim)
                End If
            End If
        ElseIf chTrab.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarTrabPorDNI(txtRuc.Text.Trim)
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Sub updateGlosaAsiento(asiento As asiento)
    '    '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '    Try
    '        Dim consulta = (From n In ListaAsientonTransito _
    '                   Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '        If Not IsNothing(consulta) Then
    '            consulta.glosa = txtGlosaAsiento.Text.Trim
    '        End If

    '        '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '    Catch ex As Exception
    '        MessageBoxAdv.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs)
        'If lstAsiento.SelectedItems.Count > 0 Then
        '    If txtGlosaAsiento.Text.Trim.Length > 0 Then
        '        updateGlosaAsiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        '        lstAsiento_SelectedIndexChanged(sender, e)
        '    End If
        'Else
        '    lblEstado.Text = "Debe seleccionar un asiento!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then

            dgvMov.TableDescriptor.Columns("Correccion").Width = 200


        ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then

            dgvMov.TableDescriptor.Columns("Correccion").Width = 0

        End If
    End Sub

    Private Sub tb19_Click(sender As Object, e As EventArgs) Handles tb19.Click

    End Sub









    'Private Sub cboOperacion_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If cboOperacion.SelectedValue = "10.01" Then
    '        GroupBox2.Visible = True
    '        ToolStripButton4.Enabled = False

    '    Else
    '        GroupBox2.Visible = False
    '        ToolStripButton4.Enabled = True
    '    End If
    'End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If cboOperacion.SelectedValue = "10.01" Then

        Else
            dockingManager1.SetDockVisibility(Panel2, True)
        End If
    End Sub



    Sub ComboProcesos(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA


        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns("proceso").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
        ggcStyle.ValueMember = "idCosto"
        ggcStyle.DisplayMember = "nombreCosto"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMov.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvMov.ShowRowHeaders = False

        'cboProceso.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        'cboProceso.ValueMember = "idCosto"
        'cboProceso.DisplayMember = "nombreCosto"
    End Sub



    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click

    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedIndexChanged
        lsvExistencias.Items.Clear()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub

    Private Sub dgvMov_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvMov.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub cboOperacion_Click_1(sender As Object, e As EventArgs) Handles cboOperacion.Click

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chCli.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo Cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chTrab.Checked = True Then
            Dim f As New frmNuevoTrabajador
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    'Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
    '    Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
    '    cc.ConfirmChanges()
    '    If Not IsNothing(cc) Then
    '        Select Case cc.ColIndex

    '            Case 7, 9

    '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then



    '                    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
    '                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

    '                    'ValidarCantidadDisponible(Me.dgvMov.Table.CurrentRecord)
    '                    'If colCantidad = 0 Then
    '                    If colCantidad <= 0 Then
    '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " debe ser mayor a cero"
    '                        PanelError.Visible = True
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                        Timer1.Enabled = True
    '                        TiempoEjecutar(10)
    '                        Exit Sub
    '                    End If

    '                    If colCantidad > colCantidadDisponible Then
    '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
    '                        PanelError.Visible = True
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                        Timer1.Enabled = True
    '                        TiempoEjecutar(10)
    '                        Exit Sub
    '                    End If
    '                    Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
    '                    Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

    '                    Dim colImporteMN = colCantidad * colPUmn
    '                    Dim colImporteME = colCantidad * colPUme
    '                    If colImporteMN > 0 AndAlso colCantidad > 0 Then

    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


    '                    End If

    '                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

    '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '                    '    Dim decg As Decimal
    '                    '    Dim tipocam = txtTipoCambio.Text
    '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '                    'Else
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                    'End If
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '                    ''''
    '                End If
    '                e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
    '            Case 8
    '                ''''''
    '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then


    '                    '''''
    '                    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
    '                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

    '                    If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
    '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                        Timer1.Enabled = True
    '                        TiempoEjecutar(10)
    '                        Exit Sub
    '                    End If


    '                    Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
    '                    Dim colPUme As Decimal = 0

    '                    Dim colImporteMN = colCantidad * colPUmn
    '                    Dim colImporteME = 0
    '                    If colImporteMN > 0 AndAlso colCantidad > 0 Then

    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)

    '                        If Me.dgvMov.Table.CurrentRecord.GetValue("precME") = 0 Then
    '                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme)
    '                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)
    '                        End If

    '                    End If


    '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


    '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '                    '    Dim decg As Decimal
    '                    '    Dim tipocam = txtTipoCambio.Text
    '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '                    'Else
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                    'End If
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


    '                End If
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 1, GridSetCurrentCellOptions.SetFocus)
    '            Case 10  ' precio unit dolares
    '                '''''
    '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
    '                    '''''
    '                    Dim montoME As Decimal = 0
    '                    montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
    '                    '''''''''''''''''''''''''''''''''''''''''''

    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

    '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '                    '    Dim decg As Decimal
    '                    '    Dim tipocam = txtTipoCambio.Text
    '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '                    'Else
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                    'End If
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


    '                End If
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            Case 2


    '                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


    '            Case 11


    '                If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
    '                    '''''
    '                    'Dim montoME As Decimal = 0
    '                    'montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
    '                    'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
    '                    '''''''''''''''''''''''''''''''''''''''''''

    '                    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
    '                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

    '                    If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
    '                        lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                        Timer1.Enabled = True
    '                        TiempoEjecutar(10)
    '                        Exit Sub
    '                    End If
    '                    Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
    '                    Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

    '                    Dim colImporteMN = colCantidad * colPUmn
    '                    Dim colImporteME = colCantidad * colPUme
    '                    If colImporteMN > 0 AndAlso colCantidad > 0 Then

    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


    '                    End If


    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


    '                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

    '                    'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
    '                    '    Dim decg As Decimal
    '                    '    Dim tipocam = txtTipoCambio.Text
    '                    '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
    '                    'Else
    '                    '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
    '                    'End If
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


    '                End If
    '        End Select
    '    End If

    'End Sub

    'Private Sub txtFechaComprobante_ValueChanged(sender As Object, e As EventArgs)
    '    If IsDate(txtFechaComprobante.Value) Then
    '        If txtFechaComprobante.Value.Date > DiaLaboral.Date Then
    '            txtFechaComprobante.Value = DiaLaboral
    '            MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End If
    'End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 7 Or cc.ColIndex = 9 Then
                        ''''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then



                            'Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            'ValidarCantidadDisponible(Me.dgvMov.Table.CurrentRecord)
                            'If colCantidad = 0 Then
                            If colCantidad <= 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " debe ser mayor a cero"
                                PanelError.Visible = True
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If

                            'If colCantidad > colCantidadDisponible Then
                            '    lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                            '    PanelError.Visible = True
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            '    Exit Sub
                            'End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            ''''
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 8 Then
                        ''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then


                            '''''
                            'Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue
                            'If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
                            If colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If


                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = 0

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = 0
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)

                                If Me.dgvMov.Table.CurrentRecord.GetValue("precME") = 0 Then
                                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme)
                                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)
                                End If

                            End If


                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 1, GridSetCurrentCellOptions.SetFocus)
                    ElseIf cc.ColIndex = 10 Then ' precio unit dolares
                        '''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            Dim montoME As Decimal = 0
                            montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 2 Then


                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                    ElseIf cc.ColIndex = 11 Then


                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            'Dim montoME As Decimal = 0
                            'montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                            Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If


                    End If

                    'Select Case ColIndex
                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)

                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 12, GridSetCurrentCellOptions.SetFocus)
                    'End Select





                End If
            End If
        Catch ex As Exception
            lblEstado.Text = "Error: " & ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvMov_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvMov.TableControlKeyDown
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 7 Or cc.ColIndex = 9 Then
                        ''''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then



                            '    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            'ValidarCantidadDisponible(Me.dgvMov.Table.CurrentRecord)
                            'If colCantidad = 0 Then
                            If colCantidad <= 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " debe ser mayor a cero"
                                PanelError.Visible = True
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If

                            'If colCantidad > colCantidadDisponible Then
                            '    lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                            '    PanelError.Visible = True
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            '    Exit Sub
                            'End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            ''''
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 8 Then
                        ''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then


                            '''''
                            '     Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue
                            If colCantidad = 0 Then
                                'If colCantidad > colCantidadDisponible Or colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If


                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = 0

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = 0
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)

                                If Me.dgvMov.Table.CurrentRecord.GetValue("precME") = 0 Then
                                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme)
                                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)
                                End If

                            End If


                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 1, GridSetCurrentCellOptions.SetFocus)
                    ElseIf cc.ColIndex = 10 Then ' precio unit dolares
                        '''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            Dim montoME As Decimal = 0
                            montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 2 Then


                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                    ElseIf cc.ColIndex = 11 Then


                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            'Dim montoME As Decimal = 0
                            'montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                            '   Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            If colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If


                    End If

                    'Select Case ColIndex
                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)

                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 12, GridSetCurrentCellOptions.SetFocus)
                    'End Select





                End If
            End If
        Catch ex As Exception
            lblEstado.Text = "Error: " & ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvMov_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvMov.TableControlKeyPress
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 7 Or cc.ColIndex = 9 Then
                        ''''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then



                            '   Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            'ValidarCantidadDisponible(Me.dgvMov.Table.CurrentRecord)
                            'If colCantidad = 0 Then
                            If colCantidad <= 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " debe ser mayor a cero"
                                PanelError.Visible = True
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If

                            'If colCantidad > colCantidadDisponible Then
                            '    lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                            '    PanelError.Visible = True
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            '    Exit Sub
                            'End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            ''''
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 8 Then
                        ''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then


                            '''''
                            '   Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            If colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If


                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = 0

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = 0
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)

                                If Me.dgvMov.Table.CurrentRecord.GetValue("precME") = 0 Then
                                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme)
                                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)
                                End If

                            End If


                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 1, GridSetCurrentCellOptions.SetFocus)
                    ElseIf cc.ColIndex = 10 Then ' precio unit dolares
                        '''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            Dim montoME As Decimal = 0
                            montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 2 Then


                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                    ElseIf cc.ColIndex = 11 Then


                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            'Dim montoME As Decimal = 0
                            'montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                            '    Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            If colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If


                    End If

                    'Select Case ColIndex
                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)

                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 12, GridSetCurrentCellOptions.SetFocus)
                    'End Select





                End If
            End If
        Catch ex As Exception
            lblEstado.Text = "Error: " & ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvMov_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvMov.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 7 Or cc.ColIndex = 9 Then
                        ''''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then



                            '   Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            'ValidarCantidadDisponible(Me.dgvMov.Table.CurrentRecord)
                            'If colCantidad = 0 Then
                            If colCantidad <= 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " debe ser mayor a cero"
                                PanelError.Visible = True
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If

                            'If colCantidad > colCantidadDisponible Then
                            '    lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                            '    PanelError.Visible = True
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            '    Exit Sub
                            'End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            ''''
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 8 Then
                        ''''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then


                            '''''
                            '       Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            If colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If


                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = 0

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = 0
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)

                                If Me.dgvMov.Table.CurrentRecord.GetValue("precME") = 0 Then
                                    Me.dgvMov.Table.CurrentRecord.SetValue("precME", colPUme)
                                    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)
                                End If

                            End If


                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then

                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then


                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 1, GridSetCurrentCellOptions.SetFocus)
                    ElseIf cc.ColIndex = 10 Then ' precio unit dolares
                        '''''
                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            Dim montoME As Decimal = 0
                            montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf cc.ColIndex = 2 Then


                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                    ElseIf cc.ColIndex = 11 Then


                        If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                            '''''
                            'Dim montoME As Decimal = 0
                            'montoME = CDec(Me.dgvMov.Table.CurrentRecord.GetValue("cantidad")) * CDec(Me.dgvMov.Table.CurrentRecord.GetValue("precME"))
                            'Me.dgvMov.Table.CurrentRecord.SetValue("importeME", FormatNumber(montoME, 2))
                            '''''''''''''''''''''''''''''''''''''''''''

                            '      Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue

                            If colCantidad = 0 Then
                                lblEstado.Text = "La cantidad del item: " & Me.dgvMov.Table.CurrentRecord.GetValue("item") & " no debe exceder a la permitida!!"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            End If
                            Dim colPUmn As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precMN")
                            Dim colPUme As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("precME")

                            Dim colImporteMN = colCantidad * colPUmn
                            Dim colImporteME = colCantidad * colPUme
                            If colImporteMN > 0 AndAlso colCantidad > 0 Then

                                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", colImporteMN)
                                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", colImporteME)


                            End If


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "2" Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)


                        ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "1" Then

                            'If Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") > 0 Then
                            '    Dim decg As Decimal
                            '    Dim tipocam = txtTipoCambio.Text
                            '    decg = Me.dgvMov.Table.CurrentRecord.GetValue("importeMN") / CDec(tipocam)
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", decg)
                            'Else
                            '    Me.dgvMov.Table.CurrentRecord.SetValue("importeME", 0)
                            'End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)


                        End If


                    End If

                    'Select Case ColIndex
                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)

                    '    Case 7
                    '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 12, GridSetCurrentCellOptions.SetFocus)
                    'End Select





                End If
            End If
        Catch ex As Exception
            lblEstado.Text = "Error: " & ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub cboAnio_Click(sender As Object, e As EventArgs) Handles cboAnio.Click

    End Sub



    Private Sub cboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub


    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        cboAnio_SelectedValueChanged(sender, e)
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            If cboMesCompra.Text.Trim.Length > 0 Then
                lblPerido.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                txtPeriodo.Value = GetPeriodoConvertirToDate(cboMesCompra.SelectedValue & "/" & cboAnio.Text)
            End If
        End If
    End Sub
End Class