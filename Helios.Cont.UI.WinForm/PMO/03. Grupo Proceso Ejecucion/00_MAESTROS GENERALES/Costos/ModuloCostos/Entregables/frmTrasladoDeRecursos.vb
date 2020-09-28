Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmTrasladoDeRecursos

#Region "Atributos"

#End Region


#Region "Constructor"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        GridCFGDetetail(dgvCostos)

        GetItems()

        LoadComboFechas()

        GetProyectosGeneralesCMB()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Metodos"

    Sub Grabar()
        Dim LibroSA As New recursoCostoDetalleSA
        Dim ndocumento As New documento()
        Dim nDocumentoLibro As New documentoLibroDiario()
        Dim objDocumentoLibroDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim objeto As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim estadoProy As String = ""
        Try

            If dgvCostos.Table.Records IsNot Nothing AndAlso dgvCostos.Table.Records.Count > 0 Then


                'With ndocumento
                '    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                '    .idEmpresa = Gempresas.IdEmpresaRuc
                '    .idCentroCosto = GEstableciento.IdEstablecimiento
                '    If IsNothing(GProyectos) Then
                '    Else
                '        .idProyecto = GProyectos.IdProyectoActividad
                '    End If
                '    .tipoDoc = GConfiguracion.TipoComprobante
                '    .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '    .moneda = "1"
                '    .idOrden = Nothing ' Me.IdOrden
                '    .idEntidad = Val(txtProveedor.Tag)
                '    .entidad = txtProveedor.Text
                '    .nrodocEntidad = txtRuc.Text
                '    If chProv.Checked = True Then
                '        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                '    ElseIf chCli.Checked = True Then
                '        .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                '    ElseIf chTrab.Checked = True Then
                '        .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                '    End If
                '    .nroDoc = GConfiguracion.ConfigComprobante
                '    .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                '    .usuarioActualizacion = usuario.IDUsuario
                '    .fechaActualizacion = DateTime.Now
                'End With

                'With nDocumentoLibro
                '    .idEmpresa = Gempresas.IdEmpresaRuc
                '    .idEstablecimiento = GEstableciento.IdEstablecimiento
                '    .tipoRegistro = ""
                '    .fecha = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '    .fechaVct = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '    .fechaPeriodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                '    .idCosto = lblIdEntregable.Text
                '    .tieneCosto = "P"
                '    'si va ser identificado
                '    .razonSocial = CInt(txtProveedor.Tag)
                '    'If CheckBox2.Checked = True Then
                '    If txtProveedor.Text.Trim.Length > 0 Then
                '        If chProv.Checked = True Then
                '            .tipoRazonSocial = TIPO_ENTIDAD.PROVEEDOR
                '        ElseIf chTrab.Checked = True Then
                '            .tipoRazonSocial = "TR"
                '        ElseIf chCli.Checked = True Then
                '            .tipoRazonSocial = TIPO_ENTIDAD.CLIENTE
                '        End If

                '    End If

                '    'End If


                '    .infoReferencial = "CIERRE DE CONSUMO POR ENTREGABLE"
                '    '.tipoRazonSocial = "PR"
                '    '.razonSocial = CInt(45876583)
                '    .tipoDoc = GConfiguracion.TipoComprobante
                '    '.nroDoc = GConfiguracion.NombreComprobante
                '    .IdNumeracion = GConfiguracion.ConfigComprobante
                '    .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                '    .moneda = "1"
                '    .tipoCambio = TmpTipoCambio
                '    .importeMN = lblMontoReal.Text
                '    .importeME = CDec(0.0)
                '    .idReferencia = CInt(1)
                '    '.tieneCosto = "N"
                '    '.idCosto = idCostoGeneral
                '    .usuarioActualizacion = usuario.IDUsuario
                '    .fechaActualizacion = DateTime.Now

                'End With
                'ndocumento.documentoLibroDiario = nDocumentoLibro


                'recurso real
                For Each r As Record In dgvCostos.Table.Records

                    If CDec(r.GetValue("importe")) > 0 Then
                        objeto = New recursoCostoDetalle
                        'origenn
                        objeto.idCosto = lblIdEntregable.Text
                        objeto.secuencia = r.GetValue("secuencia")
                        objeto.fechaRegistro = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        objeto.iditem = CInt(r.GetValue("iditem"))
                        objeto.destino = r.GetValue("destino")
                        objeto.Periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                        objeto.descripcion = r.GetValue("descripcion")
                        objeto.um = r.GetValue("um")
                        objeto.cant = CDec(r.GetValue("cantidad"))
                        objeto.puMN = CDec(r.GetValue("precio"))
                        objeto.puME = CDec(0.0)
                        objeto.montoMN = CDec(r.GetValue("importe"))
                        objeto.montoME = CDec(0.0)
                        objeto.operacion = r.GetValue("operacion")

                        objeto.procesado = "S"
                        objeto.tipoCosto = "RM"
                        objeto.idProceso = lblIdEntregable.Text
                        objeto.fechaTrabajo = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


                        lista.Add(objeto)



                        ' destino

                        objeto = New recursoCostoDetalle
                        'origenn
                        objeto.idCosto = cboEntregable.SelectedValue
                        objeto.secuencia = CInt(r.GetValue("secuencia"))
                        objeto.fechaRegistro = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        objeto.iditem = CInt(r.GetValue("iditem"))
                        objeto.destino = r.GetValue("destino")
                        objeto.Periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                        objeto.descripcion = r.GetValue("descripcion")
                        objeto.um = r.GetValue("um")
                        objeto.cant = CDec(r.GetValue("cantidad"))
                        objeto.puMN = CDec(r.GetValue("precio"))
                        objeto.puME = CDec(0.0)
                        objeto.montoMN = CDec(r.GetValue("importe"))
                        objeto.montoME = CDec(0.0)
                        objeto.operacion = r.GetValue("operacion")

                        objeto.procesado = "S"
                        objeto.tipoCosto = "RP"
                        objeto.idProceso = lblIdEntregable.Text
                        objeto.fechaTrabajo = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)


                        lista.Add(objeto)

                    Else
                        MessageBox.Show("Ingrese Un Monto Mayor a 0")
                        Exit Sub
                    End If

                Next

                'If lblTipoProyecto.Text = "HC -PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Then
                '    AsientosCosteo922()
                '    estadoProy = "COS"
                'ElseIf lblTipoProyecto.Text = "HC -COSTOS POR VALORACION" Then
                '    AsientosCosteo921()
                '    If cboestadovalorizado.Text = "VALORIZAR" Then
                '        estadoProy = "VAL"
                '    ElseIf cboestadovalorizado.Text = "VALORIZAR Y CONCLUIR PROYECTO" Then
                '        estadoProy = "EJE"
                '    End If


                'ElseIf lblTipoProyecto.Text = "HC -PROCESO PRODUCTIVO A VALORES ESTANDAR" Then


                'End If
                ' ndocumento.asiento = listaAsientoEnvio


                LibroSA.GrabarRecursoProduccion(lista)


                Dispose()
            
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar")
        End Try
    End Sub



    Public Sub GetCargarRecurso(recurso As recursoCostoDetalle)

        Dim montoCostoProduccion As Decimal = CDec(0.0)
        dgvCostos.TableDescriptor.GroupedColumns.Clear()


        Dim dt As New DataTable


        dt.Columns.Add("documentoRef")
        dt.Columns.Add("iditem")
        dt.Columns.Add("destino")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        dt.Columns.Add("operacion")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("Periodo")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("precio")
        dt.Columns.Add("importe")

        dt.Columns.Add("secuencia")



        Dim dr As DataRow = dt.NewRow

        dr(0) = recurso.documentoRef
        dr(1) = recurso.iditem
        dr(2) = recurso.destino
        dr(3) = recurso.descripcion
        dr(4) = recurso.um
        dr(5) = recurso.cant

        dr(6) = recurso.montoMN
        dr(7) = CDec(0.0)

        dr(8) = recurso.operacion
        dr(9) = recurso.fechaTrabajo
        dr(10) = recurso.Periodo
        dr(11) = CDec(0.0)




        If (recurso.cant) > 0 Then
            dr(12) = recurso.montoMN / recurso.cant
        Else

            dr(12) = CDec(0.0)
        End If



        dr(13) = CDec(0.0)

        dr(14) = recurso.secuencia

        ' If recurso.montoMN <= 0 Then

        dt.Rows.Add(dr)

        ' End If


        'montoCostoProduccion += CDec(recurso.montoMN)
        'montoCostoProduccion -= CDec(recurso.montoCosto)





        dgvCostos.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,

        'lblmontoCosteado.Text = montoCostoProduccion



    End Sub



    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of recursoCosto)
        lista = recursoSA.GetListaSubProyectos(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .status = StatusProductosTerminados.Pendiente})
        'lista = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
        Dim query = lista.Where(Function(o) o.subtipo <> TipoCosto.HC_Mercaderia).ToList
        cboSubProyecto.DataSource = query
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
    End Sub

    Sub GetEntregables(idSubproyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then

        costo = costoSA.GetOrdenesDeProduccionInfo(New recursoCosto With {.idCosto = idSubproyecto, .status = StatusProductosTerminados.Pendiente})
        cboEntregable.DisplayMember = "nombreCosto"
        cboEntregable.ValueMember = "idCosto"
        cboEntregable.DataSource = costo

        cboEntregable.SelectedIndex = -1
        '   End If
    End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboTipo.DisplayMember = "nombreCosto"
        cboTipo.ValueMember = "idCosto"
        cboTipo.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})

        'cboGastoGeneral.Items.Clear()
        'cboGastoGeneral.Items.Add("GASTO ADMINISTRATIVO")
        'cboGastoGeneral.Items.Add("GASTO DE VENTAS")
        'cboGastoGeneral.Items.Add("GASTO FINANCIERO")
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

    Public Sub GetItems()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable

        dt.Columns.Add("documentoRef")
        dt.Columns.Add("iditem")
        dt.Columns.Add("destino")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        dt.Columns.Add("operacion")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("Periodo")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("precio")
        dt.Columns.Add("importe")

        dt.Columns.Add("secuencia")

        dgvCostos.DataSource = dt

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

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
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
#End Region



    Private Sub frmTrasladoDeRecursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboTipo.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboEntregable.DataSource = Nothing
        'cboEdt.DataSource = Nothing
        If cboSubProyecto.SelectedIndex > -1 Then

            Dim recursoSA As New recursoCostoSA

            Dim codValue = cboSubProyecto.SelectedValue


            If IsNumeric(codValue) Then

                GetEntregables(codValue)

            End If
        End If
    End Sub

    Private Sub dgvCostos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCostos.TableControlCellClick

    End Sub

    Private Sub dgvCostos_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCostos.TableControlKeyDown
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 12 Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                            If Me.dgvCostos.Table.CurrentRecord.GetValue("cant") > 0 Then


                                If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cant")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad")) Then

                                    Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                                Else
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                                End If

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        End If
                    ElseIf cc.ColIndex = 14 Then
                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        End If
                    End If

                End If
            End If



        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCostos_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCostos.TableControlKeyPress
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 12 Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                            If Me.dgvCostos.Table.CurrentRecord.GetValue("cant") > 0 Then


                                If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cant")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad")) Then

                                    Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                                Else
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                                End If

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        End If
                    ElseIf cc.ColIndex = 14 Then
                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        End If
                    End If

                End If
            End If



        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCostos_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCostos.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 12 Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                            If Me.dgvCostos.Table.CurrentRecord.GetValue("cant") > 0 Then


                                If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cant")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad")) Then

                                    Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                                Else
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                    Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                                End If

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If
                        End If
                    ElseIf cc.ColIndex = 14 Then
                        If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        End If
                    End If

                End If
            End If



        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Grabar()
    End Sub
End Class