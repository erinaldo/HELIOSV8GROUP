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

Public Class frmReconocimientoIngreso
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text, GEstableciento.IdEstablecimiento)
        GridCFG(dgvCompra)
        GetTableGrid()
        Conceptos()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "METODOS"


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


    Public Sub LlenarReconocimiento(objeto As documentoLibroDiario)
        Dim documentoSA As New documentoLibroDiarioSA
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad


        lblidDocReferencia.Text = objeto.idDocReferencia
        entidad = entidadSA.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, objeto.tipoRazonSocial, objeto.razonSocial)
        '  Dim Lista As New List(Of documentoLibroDiario)

        Me.dgvCompra.Table.Records.DeleteAll()

        Try
            'Lista = documentoSA.HistorialCosteo(idEntregle)


            ' For Each i In Lista

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("idReferencia", objeto.idDocReferencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", objeto.idDocReferencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", "COSTO")
            Me.dgvCompra.Table.CurrentRecord.SetValue("monto", objeto.importeMN)
            Me.dgvCompra.Table.CurrentRecord.SetValue("importe", CDec(0.0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "COS")

            lblIdCliente.Text = objeto.razonSocial
            lbltipocliente.Text = objeto.tipoRazonSocial
            lblnombre.Text = entidad.nombreCompleto
            lblnrodoc.Text = entidad.nrodoc

            lblmontotal.Text = objeto.importeMN

            Me.dgvCompra.Table.AddNewRecord.EndEdit()


            '  Next

        Catch ex As Exception

        End Try
    End Sub


    Sub Conceptos()
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim Lista As New List(Of tabladetalle)

        Lista = tablaDetalleSA.GetListaTablaDetalle(23, "1")

        cboConceptos.DisplayMember = "descripcion"
        cboConceptos.ValueMember = "codigoDetalle"
        cboConceptos.DataSource = Lista


    End Sub

    Sub calcular()
        Dim montoTotal As Integer = 0



        For Each r As Record In dgvCompra.Table.Records




            montoTotal += CDec(r.GetValue("monto"))
        Next

        lblmontotal.Text = montoTotal
    End Sub


    Sub Grabar()
        Dim LibroSA As New documentoLibroDiarioSA
        Dim ndocumento As New documento()
        Dim nDocumentoLibro As New documentoLibroDiario()
        Dim objDocumentoLibroDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim objeto As New documentoLibroDiarioDetalle
        Dim lista As New List(Of documentoLibroDiarioDetalle)
        Dim estadoProy As String = ""
        Try

            If dgvCompra.Table.Records IsNot Nothing AndAlso dgvCompra.Table.Records.Count > 0 Then
                With ndocumento
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idEmpresa = Gempresas.IdEmpresaRuc
                    .idCentroCosto = GEstableciento.IdEstablecimiento
                    If IsNothing(GProyectos) Then

                    Else
                        .idProyecto = GProyectos.IdProyectoActividad
                    End If
                    .tipoDoc = GConfiguracion.TipoComprobante
                    .fechaProceso = DateTime.Now
                    .moneda = "1"
                    .idOrden = Nothing ' Me.IdOrden
                    .idEntidad = lblIdCliente.Text
                    .tipoEntidad = lbltipocliente.Text
                    .entidad = lblnombre.Text
                    .nrodocEntidad = lblnrodoc.Text


                    'If chProv.Checked = True Then
                    '    .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                    'ElseIf chCli.Checked = True Then
                    '    .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                    'ElseIf chTrab.Checked = True Then
                    '    .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
                    'End If
                    .nroDoc = GConfiguracion.ConfigComprobante
                    .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With

                With nDocumentoLibro
                    .idEmpresa = Gempresas.IdEmpresaRuc
                    .idEstablecimiento = GEstableciento.IdEstablecimiento

                    .idDocReferencia = lblidDocReferencia.Text

                    .tipoRegistro = ""
                    .fecha = DateTime.Now
                    .fechaVct = DateTime.Now
                    .fechaPeriodo = PeriodoGeneral
                    '.idCosto = lblIdEntregable.Text
                    .tieneCosto = "P"
                    .razonSocial = CInt(lblIdCliente.Text)
                    .tipoRazonSocial = lbltipocliente.Text

                    .idCosto = lblidCosto.Text

                    'si va ser identificado
                    ' .razonSocial = CInt(txtProveedor.Tag)
                    'If CheckBox2.Checked = True Then
                    'If txtProveedor.Text.Trim.Length > 0 Then
                    '    If chProv.Checked = True Then
                    '        .tipoRazonSocial = TIPO_ENTIDAD.PROVEEDOR
                    '    ElseIf chTrab.Checked = True Then
                    '        .tipoRazonSocial = "TR"
                    '    ElseIf chCli.Checked = True Then
                    '        .tipoRazonSocial = TIPO_ENTIDAD.CLIENTE
                    '    End If

                    'End If

                    'End If


                    .infoReferencial = "CIERRE DE CONSUMO POR ENTREGABLE"
                    '.tipoRazonSocial = "PR"
                    '.razonSocial = CInt(45876583)
                    .tipoDoc = GConfiguracion.TipoComprobante
                    '.nroDoc = GConfiguracion.NombreComprobante
                    .IdNumeracion = GConfiguracion.ConfigComprobante
                    .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                    .moneda = "1"
                    .tipoCambio = TmpTipoCambio
                    .importeMN = CDec(lblmontotal.Text)
                    .importeME = CDec((CDec(lblmontotal.Text) / TmpTipoCambio))
                    .idReferencia = CInt(1)
                    '.tieneCosto = "N"
                    '.idCosto = idCostoGeneral
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now

                End With
                ndocumento.documentoLibroDiario = nDocumentoLibro


                'recurso real
                For Each r As Record In dgvCompra.Table.Records
                    objeto = New documentoLibroDiarioDetalle


                    objeto.idItem = CInt(r.GetValue("idItem"))
                    objeto.descripcion = r.GetValue("descripcion")
                    objeto.importeMN = CDec(r.GetValue("importe"))
                    objeto.importeME = CDec(0.0)

                    lista.Add(objeto)

                Next


                ndocumento.documentoLibroDiario.documentoLibroDiarioDetalle = lista

                'If lblTipoProyecto.Text = "HC -PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Then
                '    AsientosCosteo922()
                '    'AsientoCosteoReal922()
                '    AsientoCosteoReal921()
                '    estadoProy = "COS"
                'ElseIf lblTipoProyecto.Text = "HC -COSTOS POR VALORACION" Then
                '    AsientosCosteo921()
                '    AsientoCosteoReal921()

                '    If cboestadovalorizado.Text = "VALORIZAR" Then
                '        estadoProy = "VAL"
                '    ElseIf cboestadovalorizado.Text = "VALORIZAR Y CONCLUIR PROYECTO" Then
                '        estadoProy = "EJE"
                '    End If


                'ElseIf lblTipoProyecto.Text = "HC -PROCESO PRODUCTIVO A VALORES ESTANDAR" Then


                'End If




                'ndocumento.asiento = listaAsientoEnvio


                LibroSA.GrabarReconocmientoIngreso(ndocumento)


                Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar")
        End Try
    End Sub


    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idReferencia")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("monto")
        dt.Columns.Add("utilidad")
        dt.Columns.Add("importe")
        dt.Columns.Add("tipo")

        dgvCompra.DataSource = dt
    End Sub
#End Region

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub frmReconocimientoIngreso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmReconocimientoIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnReconocimiento_Click(sender As Object, e As EventArgs) Handles btnReconocimiento.Click
        Grabar()
    End Sub

    Private Sub cboConceptos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConceptos.SelectedIndexChanged

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("idReferencia", "")
        Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", cboConceptos.SelectedValue)
        Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", cboConceptos.Text)
        Me.dgvCompra.Table.CurrentRecord.SetValue("monto", CDec(0.0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("importe", CDec(0.0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "CON")

        Me.dgvCompra.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub gradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles gradientPanel2.Paint

    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then

                'Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 8).CellValue
                'Select Case str
                '    Case "GS"
                '        e.Style.[ReadOnly] = False
                '        e.Style.BackColor = Color.AliceBlue
                '        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                '        If IsNumeric(e.Style.CellValue) Then
                '            If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                '                e.Style.CellValue = 1
                '            End If
                '        Else
                '            e.Style.CellValue = 1
                '        End If

                '    Case "08"
                '        e.Style.[ReadOnly] = False
                '        e.Style.BackColor = Color.AliceBlue
                '        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing

                '        If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                '            e.Style.CellValue = 1
                '        End If

                '    Case Else
                '        e.Style.[ReadOnly] = True
                '        e.Style.BackColor = Color.AliceBlue
                'End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "monto")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 6).CellValue
                Select Case str
                    Case "CON"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue
                        'e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                        'Case "10.01"
                        '    e.Style.[ReadOnly] = False
                        '    'e.Style.BackColor = Color.AliceBlue
                        '    'e.Style.CellValue = 1

                        'Case "9919"
                        '    e.Style.[ReadOnly] = True
                    Case Else
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.Yellow
                End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importe")) Then
                '    Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 9).CellValue
                '    Select Case str
                '        Case "02"
                '            e.Style.[ReadOnly] = False
                '            'e.Style.BackColor = Color.AliceBlue
                '            'e.Style.CellValue = 1
                '            '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                '        Case "10.01"
                '            e.Style.[ReadOnly] = True
                '            'e.Style.BackColor = Color.AliceBlue
                '            'e.Style.CellValue = 1
                '        Case "9919"
                '            e.Style.[ReadOnly] = False

                '        Case Else
                '            'e.Style.[ReadOnly] = False
                '            'e.Style.BackColor = Color.Yellow
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cuenta")) Then
                '    Dim str = Me.dgvCostos.TableModel(e.TableCellIdentity.RowIndex, 9).CellValue
                '    Select Case str
                '        Case "02"
                '            e.Style.[ReadOnly] = False
                '            'e.Style.BackColor = Color.AliceBlue
                '            'e.Style.CellValue = 1
                '            '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                '        Case "10.01"
                '            e.Style.[ReadOnly] = True
                '            'e.Style.BackColor = Color.AliceBlue
                '            'e.Style.CellValue = 1
                '        Case "9919"
                '            e.Style.[ReadOnly] = False

                '        Case Else
                '            'e.Style.[ReadOnly] = False
                '            'e.Style.BackColor = Color.Yellow
                '    End Select
            Else
                'e.Style.[ReadOnly] = False
            End If


        End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        calcular()
    End Sub

    Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
        calcular()
    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        calcular()
    End Sub
End Class