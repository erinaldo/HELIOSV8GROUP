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

Public Class frmHojaDeCosto

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        GetProyectosGeneralesCMB()
        GridCFG(dgvCostos)


        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral



        txtAnioCompra.Text = AnioGeneral

    End Sub
#End Region

#Region "Methods"
    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial

    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen

    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)

    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre

    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        'lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"

    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")

    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub


    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    'Private Sub GetDetalleRecursos()
    '    Dim costoSA As New recursoCostoDetalleSA
    '    dgvCompra.TableDescriptor.GroupedColumns.Clear()
    '    dgvCompra.DataSource = costoSA.GetListadoRecursosPorProyectoGeneral(New recursoCosto With {.idCosto = cboTipo.SelectedValue})
    '    dgvCompra.ShowGroupDropArea = True
    'End Sub

    'tipoconstrucciones
    'Private Sub GetDetalleRecursosTipoCostos(tipoCosto As String)
    '    Dim costoSA As New recursoCostoDetalleSA
    '    dgvCompra.TableDescriptor.GroupedColumns.Clear()
    '    dgvCompra.DataSource = costoSA.GetListadoRecursosPorProyectoGeneralTipoCosto(cboTipo.SelectedValue, tipoCosto)
    '    dgvCompra.ShowGroupDropArea = True
    'End Sub


    Private Sub GetListadoRecursosPorEntregable(idEntregable As Integer, fechaPeriodo As DateTime)
        Dim costoSA As New recursoCostoDetalleSA
        dgvCostos.TableDescriptor.GroupedColumns.Clear()
        'dgvCostos.DataSource = costoSA.GetListadoRecursosPorEntregable(idEntregable)
        'dgvCostos.ShowGroupDropArea = True
        '/////////////////

        Dim dt As New DataTable


        dt.Columns.Add("secuencia")
        dt.Columns.Add("fechaRegistro")
        dt.Columns.Add("iditem")
        dt.Columns.Add("destino")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("documentoRef")
        dt.Columns.Add("operacion")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("Periodo")
        dt.Columns.Add("motivo")
        dt.Columns.Add("elementoCosto")

        For Each i In costoSA.GetListadoRecursosPorEntregableCosteado(idEntregable, fechaPeriodo)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.fechaRegistro
            dr(2) = i.iditem
            dr(3) = i.destino
            dr(4) = i.descripcion
            dr(5) = i.um
            dr(6) = i.cant

            dr(7) = i.montoMN
            dr(8) = i.montoME
            dr(9) = i.documentoRef
            dr(10) = i.operacion
            dr(11) = i.fechaTrabajo
            dr(12) = i.Periodo
            dr(13) = i.motivoCosto
            dr(14) = i.elementoCosto

            dt.Rows.Add(dr)
        Next
        dgvCostos.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '.fechaContable = PeriodoGeneral})
        'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended


        'GridGroupingControl1.TableDescriptor.Columns("idPadreDTCompra").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("idCosto").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("NombreProyectoGeneral").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("idSubProyecto").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("Subproyecto").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("idEDT").Width = 70


        'GridGroupingControl1.TableDescriptor.Columns("tipoCosto").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("idElemento").Width = 0
        'GridGroupingControl1.TableDescriptor.Columns("Elemento").Width = 0

    End Sub

#End Region

#Region "Events"

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
    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        'GetDetalleRecursos()
        ' GetDetalleRecursosTipoCostos("RL")
        Dim fechaActual As DateTime = Format(Now, txtAnioCompra.Text & "-" & cboMesCompra.SelectedValue & "-" & "01")

        If cboEntregable.Text.Trim.Length > 0 Then


            GetListadoRecursosPorEntregable(cboEntregable.SelectedValue, fechaActual)

        Else
            MessageBox.Show("Seleccione un Entregable")
        End If
        'Select Case cboSubtipo.Text
        '    Case "HC - COSTOS POR VALORACION"

        '        GetDetalleRecursosTipoCostos(TipoCosto.CONTRATOS_DE_CONSTRUCCION)

        '    Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS"

        '        GetDetalleRecursosTipoCostos(TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES)

        '    Case "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"

        '        GetDetalleRecursosTipoCostos(TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS)

        '    Case "HC - PROCESOS PRODUCTIVOS"

        '        GetDetalleRecursosTipoCostos(TipoCosto.OP_CONTINUA_DE_BIENES)

        '    Case "OP. DE BIENES - CONTROL INDEPENDIENTE" 'retirar

        '        GetDetalleRecursosTipoCostos(TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE)

        '    Case "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT"

        '        GetDetalleRecursosTipoCostos(TipoCosto.OP_CONTINUA_DE_SERVICIOS)

        '    Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP"

        '        GetDetalleRecursosTipoCostos(TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE)

        '    Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"

        '        GetDetalleRecursosTipoCostos(TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES)

        'End Select

        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim asientoSA As New AsientoSA

        If Not IsNothing(dgvCostos.Table.CurrentRecord) Then
            If MessageBox.Show("Va quitar la asignación del recurso seleccionado." & vbCrLf &
                           "Nota: Se eliminarán todos los servicios asignados del comprobante", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                asientoSA.EliminarAsientoCostos(New asiento With {.idDocumento = Val(dgvCostos.Table.CurrentRecord.GetValue("documentoRef")),
                                                                  .codigoLibro = dgvCostos.Table.CurrentRecord.GetValue("operacion")})

                MessageBox.Show("Recursos liberados de asignación!." & vbCrLf &
                                "Puede verificar en contabilidad, alertas de recursos x asignar.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'GetDetalleRecursos()

            End If
        Else
            MessageBox.Show("Debe seleccionar un recurso válido!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmCentroCostosV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        cboSubProyecto.DataSource = Nothing
        cboEntregable.DataSource = Nothing
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboTipo.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

End Class