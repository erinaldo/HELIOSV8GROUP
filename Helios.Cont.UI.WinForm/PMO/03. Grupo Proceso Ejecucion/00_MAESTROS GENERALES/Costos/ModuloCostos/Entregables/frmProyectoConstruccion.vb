Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmProyectoConstruccion
    Inherits frmMaster

#Region "Atributos"
    Public Property Manipulacion As String
    Public Property Creacion As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "PROYECTOS", Me.Text, GEstableciento.IdEstablecimiento)
        GridCFGDetetail(dgvEntregables)
        GridCFGDetetail(dgvSubProductos)
        GetItems()
        GetItemsSubProductos()
        LoadControles()
        ' Add any initialization after the InitializeComponent() call.
        'CargarTrabajadores()
        txtInicio.Value = DateTime.Now
        txtFinaliza.Value = DateTime.Now
        txtFechaInicio.Value = DateTime.Now
        txtFechaEntrega.Value = DateTime.Now
        txtiniciosub.Value = DateTime.Now
        txtfinsub.Value = DateTime.Now

        

    End Sub
#End Region

#Region "Metodos"


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
    '                        'GConfiguracion.TipoComprobante = .tipo
    '                        'GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        ' GConfiguracion.Serie = .serie
    '                        'GConfiguracion.ValorActual = .valorInicial

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


    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            '   n.SubItems.Add(i.codigo & "   " & "-" & "   " & i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(i.codigo)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub


    Private Sub LoadControles()
        Dim categoriaSA As New itemSA
        Dim tablaSA As New tablaDetalleSA
        Dim dtUM As New DataTable

        Try

            cboTipoExistencia.DisplayMember = "descripcion"
            cboTipoExistencia.ValueMember = "codigoDetalle"
            cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")


            Me.cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            Me.cboUnidades.DisplayMember = "descripcion"
            Me.cboUnidades.ValueMember = "codigoDetalle2"

            Me.cboPresentacion.DataSource = tablaSA.GetListaTablaDetalle(21, "1")
            Me.cboPresentacion.DisplayMember = "descripcion"
            Me.cboPresentacion.ValueMember = "codigoDetalle"




            cboTipoExistencia.SelectedValue = "02"

        Catch ex As Exception

        End Try

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
    'Sub GridCFGDetetail(grid As GridGroupingControl)
    '    grid.TableOptions.ShowRowHeader = False
    '    grid.TopLevelGroupOptions.ShowCaption = False

    '    Dim colorx As New GridMetroColors()
    '    colorx = New GridMetroColors()
    '    colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
    '    colorx.HeaderTextColor.HoverTextColor = Color.Gray
    '    colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
    '    grid.SetMetroStyle(colorx)
    '    grid.BorderStyle = System.Windows.Forms.BorderStyle.None

    '    'Me.gridGroupingControl1.BrowseOnly = true
    '    'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
    '    'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
    '    'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    grid.TableOptions.SelectionBackColor = Color.Gray
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

    '    'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
    '    grid.AllowProportionalColumnSizing = False
    '    grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
    '    'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

    '    grid.Table.DefaultColumnHeaderRowHeight = 25
    '    grid.Table.DefaultRecordRowHeight = 20
    '    grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    'End Sub



    Private Sub GrabarSubProyectoConstruccion()

        Dim proceso As New recursoCosto
        Dim entregables As New List(Of recursoCosto)
        Dim detalles As New recursoCosto
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim idProyecto As Integer
        Dim item As New cuentaplanContableEmpresa

        Try

            '////////////////////////////////////PROYECTO GENERAL//////////////////////////////////////7

            idProyecto = txtIdProyecto.Text
            '///////////////////////////////////////////SUB PROYECTO GENERAL ///////////////////////////////////////////
            proceso = New recursoCosto
            ' costo.idpadre = IdProyectoGeneral
            '  costo.tipo = If(cboTipo.Text = "HOJA DE COSTO", "HC", "HG")

            proceso.nombreCosto = TextBoxExt1.Text.Trim
            ' costo.codigo = txtCodigo.Text.Trim
            'proceso.detalle = txtDetalle.Text.Trim
            ' costo.subdetalle = txtSubdetalle.Text.Trim
            proceso.inicio = txtiniciosub.Value
            proceso.finaliza = txtfinsub.Value
            'proceso.director = 0
            proceso.procesado = "N"
            proceso.tipo = "HC"
            'detalles.status = "0"
            'proceso.subtipo = "OP1"
            proceso.status = "0"
            '
            proceso.jerarquia = String.Empty
            '
            proceso.usuarioActualizacion = usuario.IDUsuario
            proceso.fechaActualizacion = DateTime.Now








            '/////////////////////////////////////////////////////////////////LISTA DE ENTREGABLES //////////////////////////////////////////7

            For Each r As Record In dgvEntregables.Table.Records
                detalles = New recursoCosto


                detalles.nombreCosto = r.GetValue("Entregable")
                detalles.inicio = r.GetValue("FechaIni")
                detalles.finaliza = CDate(r.GetValue("Fecha"))
                detalles.detalle = r.GetValue("Detalle")
                detalles.cantidad = 0

                detalles.tipo = "PT"


                'detalles.codigocuenta = r.GetValue("codigo")
                'detalles.mdp = r.GetValue("mdp")
                'detalles.mod1 = r.GetValue("mod")
                'detalles.ocd = r.GetValue("ocd")
                'detalles.gpi = r.GetValue("gpi")
                'detalles.gpimpi = r.GetValue("gpimpi")
                'detalles.gpimoi = r.GetValue("gpimoi")
                'detalles.gpiogi = r.GetValue("gpiogi")
                detalles.contrato = r.GetValue("Contrato")

                detalles.codigo = r.GetValue("iditem")
                detalles.tipoExistencia = r.GetValue("tipoExistencia")
                detalles.unidad = r.GetValue("unidad")
                detalles.presentacion = r.GetValue("presentacion")
                detalles.cantidad = CDec(r.GetValue("cantidad"))




                Select Case r.GetValue("Contrato")

                    Case "HC - COSTOS POR VALORACION"
                        detalles.subtipo = TipoCosto.COSTOS_POR_VALORACION
                        detalles.status = StatusCosto.Avance_Obra_Cartera
                    Case "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS"
                        detalles.subtipo = TipoCosto.COSTOS_POR_PROCESOS_PROD
                        detalles.status = StatusCosto.Avance_Obra_Cartera
                    Case "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR"
                        detalles.subtipo = TipoCosto.COSTOS_POR_PROCESO_ESTIMADO
                        detalles.status = StatusCosto.Avance_Obra_Cartera
                        'Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES"
                        '    detalles.subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera
                        'Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS"
                        '    detalles.subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera

                        'Case "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        '    detalles.subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera

                        'Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION"
                        '    detalles.subtipo = TipoCosto.OP_CONTINUA_DE_BIENES
                        '    detalles.status = StatusProductosTerminados.Pendiente '  StatusCosto.Avance_Obra_Cartera

                        'Case "OP. DE BIENES - CONTROL INDEPENDIENTE" 'RETIRAR OBSERVADO
                        '    detalles.subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera

                        'Case "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT"
                        '    detalles.subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera

                        'Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP"
                        '    detalles.subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera

                        'Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        '    detalles.subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera
                        '    '
                        'Case "ACTIVO FIJO"
                        '    detalles.subtipo = TipoCosto.ActivoFijo
                        '    detalles.status = StatusCosto.Avance_Obra_Cartera
                        'Case "GASTO ADMINISTRATIVO"
                        '    detalles.subtipo = TipoCosto.GastoAdministrativo
                        '    detalles.status = StatusCosto.Proceso
                        'Case "GASTO DE VENTAS"
                        '    detalles.subtipo = TipoCosto.GastoVentas
                        '    detalles.status = StatusCosto.Proceso
                        'Case "GASTO FINANCIERO"
                        '    detalles.subtipo = TipoCosto.GastoFinanciero
                        '    detalles.status = StatusCosto.Proceso

                        'Case "HC - MERCADERIA"
                        '    detalles.subtipo = TipoCosto.HC_Mercaderia
                        '    detalles.status = StatusCosto.Proceso
                End Select

                detalles.jerarquia = String.Empty
                detalles.usuarioActualizacion = usuario.IDUsuario
                detalles.fechaActualizacion = DateTime.Now
                entregables.Add(detalles)





            Next


            recursoSA.GrabarSubProyectoConstruccion(idProyecto, proceso, entregables)

            MessageBoxAdv.Show("Proyecto Guardado")
            Close()

        Catch ex As Exception


            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GrabarProyectoConstruccion()
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim entregables As New List(Of recursoCosto)
        Dim detalles As New recursoCosto
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of cuentaplanContableEmpresa)

        Dim item As New cuentaplanContableEmpresa

        Try

            '////////////////////////////////////PROYECTO GENERAL//////////////////////////////////////7
            costo = New recursoCosto
            costo.tipo = "HC"
            costo.subtipo = TipoCosto.Proyecto
            costo.status = StatusCosto.Proceso
            costo.nombreCosto = txtNuevoCosto.Text.Trim
            costo.codigo = "00"
            costo.detalle = Nothing
            costo.subdetalle = Nothing
            costo.inicio = txtInicio.Value
            costo.finaliza = txtFinaliza.Value
            costo.procesado = "N"
            costo.usuarioActualizacion = usuario.IDUsuario
            costo.fechaActualizacion = DateTime.Now
            costo.idNumeracion = GConfiguracion.ConfigComprobante

            '///////////////////////////////////////////SUB PROYECTO GENERAL ///////////////////////////////////////////
            proceso = New recursoCosto
            proceso.nombreCosto = TextBoxExt1.Text.Trim
            proceso.inicio = txtiniciosub.Value
            proceso.finaliza = txtfinsub.Value
            proceso.procesado = "N"
            proceso.tipo = "HC"
            proceso.status = "0"
            proceso.jerarquia = String.Empty
            proceso.usuarioActualizacion = usuario.IDUsuario
            proceso.fechaActualizacion = DateTime.Now

            '/////////////////////////////////////////////////////////////////LISTA DE ENTREGABLES //////////////////////////////////////////7

            For Each r As Record In dgvEntregables.Table.Records
                detalles = New recursoCosto


                detalles.nombreCosto = r.GetValue("Entregable")
                detalles.nombreCuenta = txtNuevoCosto.Text & "-" & TextBoxExt1.Text & "-" & r.GetValue("Entregable")
                detalles.inicio = CDate(r.GetValue("FechaIni"))
                detalles.finaliza = CDate(r.GetValue("Fecha"))
                detalles.detalle = r.GetValue("Detalle")
                detalles.cantidad = 0
                'detalles.finaliza = DateTime.Now



                'detalles.codigocuenta = r.GetValue("codigo")
                'detalles.mdp = r.GetValue("mdp")
                'detalles.mod1 = r.GetValue("mod")
                'detalles.ocd = r.GetValue("ocd")
                'detalles.gpi = r.GetValue("gpi")
                'detalles.gpimpi = r.GetValue("gpimpi")
                'detalles.gpimoi = r.GetValue("gpimoi")
                'detalles.gpiogi = r.GetValue("gpiogi")
                detalles.contrato = r.GetValue("Contrato")

                detalles.codigo = r.GetValue("iditem")
                detalles.tipoExistencia = r.GetValue("tipoExistencia")
                detalles.unidad = r.GetValue("unidad")
                detalles.presentacion = r.GetValue("presentacion")
                detalles.cantidad = CDec(r.GetValue("cantidad"))




                Select Case r.GetValue("Contrato")
                    Case "HC - COSTOS POR VALORACION"
                        detalles.subtipo = TipoCosto.COSTOS_POR_VALORACION
                        detalles.status = StatusCosto.Avance_Obra_Cartera
                    Case "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS"
                        detalles.subtipo = TipoCosto.COSTOS_POR_PROCESOS_PROD
                        detalles.status = StatusCosto.Avance_Obra_Cartera
                    Case "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR"
                        detalles.subtipo = TipoCosto.COSTOS_POR_PROCESO_ESTIMADO
                        detalles.status = StatusCosto.Avance_Obra_Cartera


                End Select

                detalles.jerarquia = String.Empty
                detalles.usuarioActualizacion = usuario.IDUsuario
                detalles.fechaActualizacion = DateTime.Now
                'estado del entregable
                detalles.estado = "PRO"

                detalles.jerarquia = r.GetValue("tipoEntregable")
                detalles.nroEntregable = r.GetValue("idPadreTemp")

                If r.GetValue("tipoEntregable") = "EP" Then
                    detalles.tipo = "PT"
                ElseIf r.GetValue("tipoEntregable") = "ESP" Then
                    detalles.tipo = "SP"
                End If

                detalles.precUnit = CDec(r.GetValue("costoUnit"))

                'Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "ESP")
                'Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)


                entregables.Add(detalles)

            Next

            recursoSA.GrabarProyectoGeneral(costo, proceso, entregables)

            MessageBoxAdv.Show("Proyecto Guardado")
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub












    Public Sub GetItems()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idEntregable")
        dt.Columns.Add("Entregable")
        dt.Columns.Add("Detalle")
        dt.Columns.Add("FechaIni")
        dt.Columns.Add("Fecha")
        dt.Columns.Add("Contrato")
        dt.Columns.Add("codigo")
        dt.Columns.Add("mdp")
        dt.Columns.Add("mod")
        dt.Columns.Add("ocd")
        dt.Columns.Add("gpi")
        dt.Columns.Add("gpimpi")
        dt.Columns.Add("gpimoi")
        dt.Columns.Add("gpiogi")

        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("unidad")
        dt.Columns.Add("presentacion")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("iditem")

        dt.Columns.Add("tipoEntregable")
        dt.Columns.Add("idPadreTemp")

        dt.Columns.Add("costoUnit")

        dgvEntregables.DataSource = dt

    End Sub


    Public Sub GetItemsSubProductos()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("presentacion")

        dgvSubProductos.DataSource = dt

    End Sub

#End Region

    Private Sub frmProyectoConstruccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmProyectoConstruccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim recursoSA As New recursoCostoSA
        Dim conteoExistente As Integer = 0
        Dim conteoEntregables As Integer = 0

        If cboSubtipo.Text = "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR" Then
            If Not nudCostoUnitario.Value > 0 Then
                MessageBox.Show("El Costo Unitario Debe ser mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Cursor = Cursors.Arrow
                nudCostoUnitario.Select()
            End If
        End If



        If Not nudCant.Value > 0 Then
            MessageBox.Show("La Cantidad debe ser Mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Arrow

            nudCant.Focus()

            Exit Sub
        End If

        If cboSubtipo.Text = "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Or cboSubtipo.Text = "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR" Then
            Dim ConteoSub As Integer = 0
            For Each r As Record In dgvSubProductos.Table.Records
                ConteoSub = ConteoSub + 1
            Next
            If ConteoSub = 0 Then
                If MessageBoxAdv.Show("¿Ingresar Sin Sub Productos?" + vbCrLf + vbCrLf + Space(15), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                    If txtNuevoCosto.Text.Trim.Length > 0 Then

                        If TextBoxExt1.Text.Trim.Length > 0 Then

                            If txtDetalleItem.Text.Trim.Length > 0 Then

                                Me.dgvEntregables.Table.AddNewRecord.SetCurrent()
                                Me.dgvEntregables.Table.AddNewRecord.BeginEdit()
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Entregable", txtDetalleItem.Text)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Detalle", txtDetalle.Text)

                                Me.dgvEntregables.Table.CurrentRecord.SetValue("FechaIni", txtFechaInicio.Value)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Fecha", txtFechaEntrega.Value)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Contrato", cboSubtipo.Text)

                                Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoExistencia", cboTipoExistencia.SelectedValue)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("unidad", cboUnidades.SelectedValue)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("presentacion", cboPresentacion.SelectedValue)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("cantidad", nudCant.Value)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("iditem", txtIdItem.Text)

                                Me.dgvEntregables.Table.CurrentRecord.SetValue("costoUnit", nudCostoUnitario.Value)

                                'SOLO PARA BVER PADRE ENTEGABLE Y CODIGO TEMPORAL

                                For Each r As Record In dgvEntregables.Table.Records
                                    If r.GetValue("tipoEntregable") = "EP" Then
                                        conteoEntregables = conteoEntregables + 1


                                        If txtIdItem.Text = r.GetValue("iditem") Then
                                            MessageBox.Show("El Entregable ya fue agregado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Me.Cursor = Cursors.Arrow


                                            txtDetalleItem.Focus()
                                            Exit Sub
                                        End If
                                    End If
                                Next

                                If conteoEntregables = 0 Then
                                    conteoEntregables = 1
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "EP")
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)

                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("idEntregable", conteoEntregables)
                                Else

                                    conteoEntregables = conteoEntregables + 1
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "EP")
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("idEntregable", conteoEntregables)
                                End If

                                Me.dgvEntregables.Table.AddNewRecord.EndEdit()

                                txtDetalleItem.Text = ""
                                txtIdItem.Text = ""

                                'llenar los sub productos

                                For Each r As Record In dgvSubProductos.Table.Records

                                    Me.dgvEntregables.Table.AddNewRecord.SetCurrent()
                                    Me.dgvEntregables.Table.AddNewRecord.BeginEdit()
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("Entregable", r.GetValue("descripcion"))
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("Detalle", "SUB PRODUCTO")
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("FechaIni", txtFechaInicio.Value)
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("Fecha", txtFechaEntrega.Value)
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("Contrato", cboSubtipo.Text)
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoExistencia", r.GetValue("tipoExistencia"))
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("presentacion", r.GetValue("presentacion"))
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("cantidad", nudCant.Value)
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "ESP")
                                    Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                                    Me.dgvEntregables.Table.AddNewRecord.EndEdit()

                                Next

                                Me.dgvSubProductos.Table.Records.DeleteAll()

                            Else
                                MessageBox.Show("Definir el Nombre del Entregable", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.Cursor = Cursors.Arrow
                                txtDetalleItem.Focus()
                            End If

                        Else
                            MessageBox.Show("Definir el nombe del sub proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Cursor = Cursors.Arrow
                            TextBoxExt1.Focus()
                        End If

                    Else
                        MessageBox.Show("Definir el nombe del proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Cursor = Cursors.Arrow
                        txtNuevoCosto.Focus()

                    End If


                Else
                    Dim f As New frmBusquedaExistencia
                    f.cboTipoExistencia.SelectedValue = TipoExistencia.SubProductosDesechos
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, detalleitems)

                        Me.dgvSubProductos.Table.AddNewRecord.SetCurrent()
                        Me.dgvSubProductos.Table.AddNewRecord.BeginEdit()
                        Me.dgvSubProductos.Table.CurrentRecord.SetValue("idItem", c.codigodetalle)
                        Me.dgvSubProductos.Table.CurrentRecord.SetValue("descripcion", c.descripcionItem)
                        Me.dgvSubProductos.Table.CurrentRecord.SetValue("unidad", c.unidad1)
                        Me.dgvSubProductos.Table.CurrentRecord.SetValue("tipoExistencia", c.tipoExistencia)
                        Me.dgvSubProductos.Table.CurrentRecord.SetValue("presentacion", c.presentacion)

                        Me.dgvSubProductos.Table.AddNewRecord.EndEdit()
                        Me.Cursor = Cursors.Arrow
                    Else

                    End If

                    Exit Sub
                End If
            Else
                If txtNuevoCosto.Text.Trim.Length > 0 Then

                    If TextBoxExt1.Text.Trim.Length > 0 Then

                        If txtDetalleItem.Text.Trim.Length > 0 Then


                            Me.dgvEntregables.Table.AddNewRecord.SetCurrent()
                            Me.dgvEntregables.Table.AddNewRecord.BeginEdit()
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("Entregable", txtDetalleItem.Text)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("Detalle", txtDetalle.Text)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("FechaIni", txtFechaInicio.Value)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("Fecha", txtFechaEntrega.Value)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("Contrato", cboSubtipo.Text)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoExistencia", cboTipoExistencia.SelectedValue)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("unidad", cboUnidades.SelectedValue)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("presentacion", cboPresentacion.SelectedValue)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("cantidad", nudCant.Value)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("iditem", txtIdItem.Text)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("costoUnit", nudCostoUnitario.Value)

                            'SOLO PARA BVER PADRE ENTEGABLE Y CODIGO TEMPORAL

                            For Each r As Record In dgvEntregables.Table.Records
                                If r.GetValue("tipoEntregable") = "EP" Then
                                    conteoEntregables = conteoEntregables + 1
                                    If txtIdItem.Text = r.GetValue("iditem") Then
                                        MessageBox.Show("El Entregable ya fue agregado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Me.Cursor = Cursors.Arrow
                                        txtDetalleItem.Focus()
                                        Exit Sub
                                    End If
                                End If
                            Next

                            If conteoEntregables = 0 Then
                                conteoEntregables = 1
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "EP")
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("idEntregable", conteoEntregables)
                            Else

                                conteoEntregables = conteoEntregables + 1
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "EP")
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("idEntregable", conteoEntregables)
                            End If

                            Me.dgvEntregables.Table.AddNewRecord.EndEdit()

                            txtDetalleItem.Text = ""
                            txtIdItem.Text = ""


                            'llenar los sub productos


                            For Each r As Record In dgvSubProductos.Table.Records


                                Me.dgvEntregables.Table.AddNewRecord.SetCurrent()
                                Me.dgvEntregables.Table.AddNewRecord.BeginEdit()
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Entregable", r.GetValue("descripcion"))
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Detalle", "SUB PRODUCTO")
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("FechaIni", txtFechaInicio.Value)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Fecha", txtFechaEntrega.Value)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("Contrato", cboSubtipo.Text)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoExistencia", r.GetValue("tipoExistencia"))
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("presentacion", r.GetValue("presentacion"))
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("cantidad", nudCant.Value)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "ESP")
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                                Me.dgvEntregables.Table.CurrentRecord.SetValue("costoUnit", nudCostoUnitario.Value)
                                Me.dgvEntregables.Table.AddNewRecord.EndEdit()

                            Next

                            Me.dgvSubProductos.Table.Records.DeleteAll()

                        Else
                            MessageBox.Show("Definir el Nombre del Entregable", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Cursor = Cursors.Arrow
                            txtDetalleItem.Focus()
                        End If

                    Else
                        MessageBox.Show("Definir el nombe del sub proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Cursor = Cursors.Arrow

                        TextBoxExt1.Focus()

                    End If

                Else
                    MessageBox.Show("Definir el nombe del proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Arrow
                    txtNuevoCosto.Focus()

                End If
            End If


        ElseIf cboSubtipo.Text = "HC - COSTOS POR VALORACION" Then

            If txtNuevoCosto.Text.Trim.Length > 0 Then

                If TextBoxExt1.Text.Trim.Length > 0 Then

                    If txtDetalleItem.Text.Trim.Length > 0 Then


                        Me.dgvEntregables.Table.AddNewRecord.SetCurrent()
                        Me.dgvEntregables.Table.AddNewRecord.BeginEdit()
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("Entregable", txtDetalleItem.Text)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("Detalle", txtDetalle.Text)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("FechaIni", txtFechaInicio.Value)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("Fecha", txtFechaEntrega.Value)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("Contrato", cboSubtipo.Text)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoExistencia", cboTipoExistencia.SelectedValue)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("unidad", cboUnidades.SelectedValue)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("presentacion", cboPresentacion.SelectedValue)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("cantidad", nudCant.Value)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("iditem", txtIdItem.Text)
                        Me.dgvEntregables.Table.CurrentRecord.SetValue("costoUnit", nudCostoUnitario.Value)

                        'SOLO PARA BVER PADRE ENTEGABLE Y CODIGO TEMPORAL

                        For Each r As Record In dgvEntregables.Table.Records
                            If r.GetValue("tipoEntregable") = "EP" Then
                                conteoEntregables = conteoEntregables + 1
                            End If
                        Next

                        If conteoEntregables = 0 Then
                            conteoEntregables = 1
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "EP")
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("idEntregable", conteoEntregables)
                        Else

                            conteoEntregables = conteoEntregables + 1
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("tipoEntregable", "EP")
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("idPadreTemp", conteoEntregables)
                            Me.dgvEntregables.Table.CurrentRecord.SetValue("idEntregable", conteoEntregables)
                        End If

                        Me.dgvEntregables.Table.AddNewRecord.EndEdit()

                        txtDetalleItem.Text = ""
                        txtIdItem.Text = ""

                    Else
                        Me.Cursor = Cursors.Arrow
                        MessageBox.Show("Definir el Nombre del Entregable", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtDetalleItem.Focus()

                    End If

                Else
                    Me.Cursor = Cursors.Arrow
                    MessageBox.Show("Definir el nombe del sub proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBoxExt1.Focus()
                End If

            Else
                Me.Cursor = Cursors.Arrow
                MessageBox.Show("Definir el nombe del proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNuevoCosto.Focus()
            End If

        End If

        nudCostoUnitario.Value = 0

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        If txtNuevoCosto.Text.Trim.Length > 0 Then

            If TextBoxExt1.Text.Trim.Length > 0 Then


                If dgvEntregables.Table.Records.Count > 0 Then

                    If Creacion = "SUBPROYECTO" Then
                        GrabarSubProyectoConstruccion()
                    ElseIf Creacion = "PROYECTO" Then

                        GrabarProyectoConstruccion()

                    End If
                Else
                    MessageBox.Show("No hay Entregables!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDetalleItem.Select()
                    Me.Cursor = Cursors.Arrow
                End If
            Else
                MessageBox.Show("Escriba El Nombre del Sub Proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBoxExt1.Select()
                Me.Cursor = Cursors.Arrow
            End If
        Else
            MessageBox.Show("Escriba El Nombre del Proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNuevoCosto.Select()
            Me.Cursor = Cursors.Arrow
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
    '    'If cboProductos.Text.Trim.Length > 0 Then
    '    Dim almacen As New List(Of almacen)
    '    Dim almacenSA As New almacenSA
    '    Dim objInsumo As New detalleitemsSA
    '    Dim tablaSA As New tablaDetalleSA

    '    Dim cat As New item
    '    Dim ITEMSA As New itemSA
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()

    '    With frmNuevaExistencia
    '        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
    '            .cboTipoExistencia.Enabled = False
    '            .cboUnidades.SelectedIndex = -1
    '            .cboUnidades.Enabled = True
    '        Else

    '        End If



    '        .chClasificacion.Checked = False
    '        .cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
    '        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then

    '            If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '                If datos(0).Cuenta = "Grabado" Then
    '                    '  If lsvListadoItems.SelectedItems.Count > 0 Then

    '                    With objInsumo.InvocarProductoID(CInt(datos(0).ID))

    '                        'Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
    '                        txtIdItem.Text = .codigodetalle
    '                        txtDetalleItem.Text = .descripcionItem

    '                        cboUnidades.SelectedValue = .unidad1
    '                        cboTipoExistencia.SelectedValue = .tipoExistencia
    '                        cboPresentacion.SelectedValue = .presentacion


    '                    End With
    '                    ' End If
    '                End If
    '            End If


    '        End If
    '    End With


    '    Me.Cursor = Cursors.Arrow



    'End Sub





    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Try
            popupControlContainer1.HidePopup(PopupCloseType.Done)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then

            If lsvListadoItems.SelectedItems.Count > 0 Then
                Dim selFila As ListViewItem = lsvListadoItems.SelectedItems(0)

                'With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))


                'Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", CStr(selFila.SubItems(4).Text))
                txtIdItem.Text = selFila.SubItems(0).Text
                txtDetalleItem.Text = CStr(selFila.SubItems(1).Text)
                cboUnidades.SelectedValue = CStr(selFila.SubItems(2).Text)

                cboTipoExistencia.SelectedValue = CStr(selFila.SubItems(3).Text)



                cboPresentacion.SelectedValue = CStr(selFila.SubItems(8).Text)



            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtDetalleItem.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If cboSubtipo.Text = "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Or cboSubtipo.Text = "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR" Then
            Dim f As New frmBusquedaExistencia
            f.cboTipoExistencia.SelectedValue = TipoExistencia.ProductoTerminado
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, detalleitems)
                'txtEntregable.Text = c.descripcionItem
                txtDetalleItem.Text = c.descripcionItem
                'txtDetalleItem.Tag = c.codigodetalle
                txtIdItem.Text = c.codigodetalle
                cboUnidades.SelectedValue = c.unidad1
                cboTipoExistencia.SelectedValue = c.tipoExistencia
                cboPresentacion.SelectedValue = c.presentacion
            Else

            End If
        End If
    End Sub

    Private Sub cboSubtipo_Click(sender As Object, e As EventArgs) Handles cboSubtipo.Click

    End Sub

    Private Sub cboSubtipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubtipo.SelectedIndexChanged

        '        HC -COSTOS POR VALORACION
        'HC -PROCESOS PRODUCTIVOS A VALORES HISTORICOS
        'HC -PROCESO PRODUCTIVO A VALORES ESTANDAR
        'HC -ACTIVOS INMOVILIZADOS
        'HC -MERCADERIA

        Me.dgvEntregables.Table.Records.DeleteAll()
        Me.dgvSubProductos.Table.Records.DeleteAll()
        nudCostoUnitario.Value = 0


        txtDetalleItem.Text = ""
        txtIdItem.Text = ""
        If cboSubtipo.Text = "HC - COSTOS POR VALORACION" Then
            LinkLabel1.Visible = False
            txtDetalleItem.ReadOnly = False
            cboTipoExistencia.ReadOnly = False
            cboUnidades.ReadOnly = False
            cboPresentacion.ReadOnly = False
            GroupBox3.Visible = False
            GroupBox4.Visible = True
            cboTipoExistencia.SelectedValue = "02"
            Label17.Visible = False
            nudCostoUnitario.Visible = False

        ElseIf cboSubtipo.Text = "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Or cboSubtipo.Text = "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR" Then
            LinkLabel1.Visible = True
            txtDetalleItem.ReadOnly = True
            cboTipoExistencia.ReadOnly = True
            cboUnidades.ReadOnly = True
            cboPresentacion.ReadOnly = True
            GroupBox3.Visible = True
            GroupBox4.Visible = False
            txtDetalleItem.Text = ""
            txtIdItem.Text = ""
            cboTipoExistencia.SelectedValue = "02"

            If cboSubtipo.Text = "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR" Then


                Label17.Visible = True
                nudCostoUnitario.Visible = True
            Else
                Label17.Visible = False
                nudCostoUnitario.Visible = False

            End If


            Dim f As New frmBusquedaExistencia
                f.cboTipoExistencia.SelectedValue = TipoExistencia.ProductoTerminado
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, detalleitems)
                    'txtEntregable.Text = c.descripcionItem
                    txtDetalleItem.Text = c.descripcionItem
                    'txtDetalleItem.Tag = c.codigodetalle
                    txtIdItem.Text = c.codigodetalle
                    cboUnidades.SelectedValue = c.unidad1
                    cboTipoExistencia.SelectedValue = c.tipoExistencia
                    cboPresentacion.SelectedValue = c.presentacion
                Else

                End If





            ElseIf cboSubtipo.Text = "HC - MERCADERIA" Then
                LinkLabel1.Visible = False
                txtDetalleItem.ReadOnly = False
                cboTipoExistencia.ReadOnly = False
                cboUnidades.ReadOnly = False
                cboPresentacion.ReadOnly = False
                txtDetalleItem.Text = ""
                txtIdItem.Text = ""
                cboTipoExistencia.SelectedValue = "01"
            Else
                LinkLabel1.Visible = False
            txtDetalleItem.ReadOnly = False
            cboTipoExistencia.ReadOnly = False
            cboUnidades.ReadOnly = False
            cboPresentacion.ReadOnly = False
            txtDetalleItem.Text = ""
            txtIdItem.Text = ""
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If cboSubtipo.Text = "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Or cboSubtipo.Text = "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR" Then
            Dim f As New frmBusquedaExistencia
            f.cboTipoExistencia.SelectedValue = TipoExistencia.SubProductosDesechos
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, detalleitems)

                'txtDetalleItem.Text = c.descripcionItem
                'txtIdItem.Text = c.codigodetalle
                'cboUnidades.SelectedValue = c.unidad1
                'cboTipoExistencia.SelectedValue = c.tipoExistencia
                'cboPresentacion.SelectedValue = c.presentacion


                Me.dgvSubProductos.Table.AddNewRecord.SetCurrent()
                Me.dgvSubProductos.Table.AddNewRecord.BeginEdit()
                Me.dgvSubProductos.Table.CurrentRecord.SetValue("idItem", c.codigodetalle)
                Me.dgvSubProductos.Table.CurrentRecord.SetValue("descripcion", c.descripcionItem)
                Me.dgvSubProductos.Table.CurrentRecord.SetValue("unidad", c.unidad1)
                Me.dgvSubProductos.Table.CurrentRecord.SetValue("tipoExistencia", c.tipoExistencia)
                Me.dgvSubProductos.Table.CurrentRecord.SetValue("presentacion", c.presentacion)





                Me.dgvSubProductos.Table.AddNewRecord.EndEdit()


            Else

            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If cboSubtipo.Text = "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS" Then

            Me.dgvEntregables.Table.Records.DeleteAll()
        Else

            If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then
                Me.dgvEntregables.Table.CurrentRecord.Delete()
            End If

        End If
    End Sub





    Private Sub txtInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtInicio.ValueChanged

    End Sub

    Private Sub txtInicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInicio.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtFinaliza.Focus()
        End If
    End Sub

    Private Sub txtFinaliza_ValueChanged(sender As Object, e As EventArgs) Handles txtFinaliza.ValueChanged

    End Sub

    Private Sub txtFinaliza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFinaliza.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TextBoxExt1.Focus()
        End If
    End Sub





    Private Sub txtiniciosub_ValueChanged(sender As Object, e As EventArgs) Handles txtiniciosub.ValueChanged

    End Sub

    Private Sub txtiniciosub_KeyDown(sender As Object, e As KeyEventArgs) Handles txtiniciosub.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtfinsub.Focus()
        End If
    End Sub

    Private Sub txtfinsub_ValueChanged(sender As Object, e As EventArgs) Handles txtfinsub.ValueChanged

    End Sub

    Private Sub txtfinsub_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfinsub.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            cboSubtipo.Focus()
        End If
    End Sub

    Private Sub cboSubtipo_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSubtipo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtDetalleItem.Focus()
        End If
    End Sub

    Private Sub nudCant_ValueChanged(sender As Object, e As EventArgs) Handles nudCant.ValueChanged

    End Sub

    Private Sub nudCant_KeyDown(sender As Object, e As KeyEventArgs) Handles nudCant.KeyDown
        'If e.KeyData = Keys.Tab Then
        '    txtDetalle.Focus()
        'End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtDetalle.Select()
        End If

    End Sub









    Private Sub txtDetalle_TextChanged(sender As Object, e As EventArgs) Handles txtDetalle.TextChanged

    End Sub

    Private Sub txtDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDetalle.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtNuevoCosto.Select()
        End If
    End Sub

    Private Sub txtFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicio.ValueChanged

    End Sub

    Private Sub txtFechaInicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaInicio.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtFechaEntrega.Select()
        End If
    End Sub

    Private Sub txtFechaEntrega_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaEntrega.ValueChanged

    End Sub

    Private Sub txtFechaEntrega_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaEntrega.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtNuevoCosto.Select()
        End If
    End Sub

    Private Sub txtNuevoCosto_TextChanged(sender As Object, e As EventArgs) Handles txtNuevoCosto.TextChanged

    End Sub

    Private Sub txtNuevoCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNuevoCosto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            TextBoxExt1.Focus()
        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtDetalleItem.Select()
        End If
    End Sub

    Private Sub txtDetalleItem_TextChanged(sender As Object, e As EventArgs) Handles txtDetalleItem.TextChanged

    End Sub

    Private Sub txtDetalleItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDetalleItem.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtDetalle.Focus()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class