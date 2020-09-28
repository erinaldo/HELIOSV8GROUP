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

Public Class frmNuevoCosto

    Public Property Manipulacion As String
    Public Property IdProyectoGeneral() As Integer
#Region "Métodos"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvProductosTerminados)
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "PROYECTOS", Me.Text, GEstableciento.IdEstablecimiento)
        Almacenes()
        CargarTrabajadores()
        CMBJerarquia()
        'GetComboTipoCostos()
        txtInicio.Value = DateTime.Now
        txtFinaliza.Value = DateTime.Now
    End Sub

    Private Sub GetComboTipoCostos()
        cboSubtipo.Items.Clear()

        '-----------------------------------------------------
        If tmpConfigInicio.HC_CONSTRUCC = True Then
            cboSubtipo.Items.Add("HC - CONSTRUC. Y SIMILARES")
        End If

        If tmpConfigInicio.HC_SERV_VARIOS = True Then
            cboSubtipo.Items.Add("HC - SERV.VARIOS")
        End If

        If tmpConfigInicio.HC_ARRENDAMIENTO = True Then
            cboSubtipo.Items.Add("HC - ARRENDAMIENTO")
        End If

        If tmpConfigInicio.HC_PRODUCCION = True Then
            cboSubtipo.Items.Add("HC - PRODUCCION")
        End If

        If tmpConfigInicio.HC_SERV_EDUCAT = True Then
            cboSubtipo.Items.Add("HC - SERV.EDUCAT")
        End If

        If tmpConfigInicio.HC_SERV_TRANSP = True Then
            cboSubtipo.Items.Add("HC - SERV.TRANSP")
        End If

        If tmpConfigInicio.HC_CONS_INMED = True Then
            cboSubtipo.Items.Add("HC - CONSUMO INMEDIATO")
        End If

        If tmpConfigInicio.HC_VENTA_MERCADERIA = True Then
            cboSubtipo.Items.Add("HC - MERCADERIA")
        End If

    End Sub

    Dim listaPersonas As New List(Of Persona)

    Public Sub CargarTrabajadores()
        Dim personaSA As New PersonaSA


        listaPersonas = personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList


    End Sub

    Sub CMBJerarquia()
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = "0"
        dr(1) = "EDT"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow
        dr2(0) = "1"
        dr2(1) = "Actividad"
        dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow
        dr3(0) = "2"
        dr3(1) = "Tarea"
        dt.Rows.Add(dr3)


        cboJerarquia.DisplayMember = "Name"
        cboJerarquia.DataSource = dt

    End Sub

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

    Private Sub Almacenes()
        Dim dt As New DataTable()

        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pu")
        dt.Columns.Add("costo")
        dt.Columns.Add("almacen")

        dgvProductosTerminados.DataSource = dt

        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        CBOalmacenDestino.DataSource = almacen
        CBOalmacenDestino.DisplayMember = "descripcionAlmacen"
        CBOalmacenDestino.ValueMember = "idAlmacen"
        CBOalmacenDestino.Enabled = True

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        Dim ggcStyle As GridTableCellStyleInfo = dgvProductosTerminados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = almacen
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvProductosTerminados.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvProductosTerminados.ShowRowHeaders = False

    End Sub

    Public Sub GetCuentaMax(be As cuentaplanContableEmpresa)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim recursoSA As New recursoCostoSA

        Select Case cboSubtipo.Text
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES"
                Dim count = recursoSA.GetCostoCount(TipoCosto.CONTRATOS_DE_CONSTRUCCION)
                Dim suma = count + 1

                'txtCodigo.Text = "921" & TipoCosto.CONTRATOS_DE_CONSTRUCCION & suma
                txtCodigo.Text = "92" & TipoCosto.CONTRATOS_DE_CONSTRUCCION & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

                TabPage3.Parent = Nothing

            Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS"
                Dim count = recursoSA.GetCostoCount(TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES)
                Dim suma = count + 1

                txtCodigo.Text = "92" & TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

                TabPage3.Parent = Nothing

            Case "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"

                Dim count = recursoSA.GetCostoCount(TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS)
                Dim suma = count + 1

                txtCodigo.Text = "92" & TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

                TabPage3.Parent = Nothing

            Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION"
                Dim count = recursoSA.GetCostoCount(TipoCosto.OP_CONTINUA_DE_BIENES)
                Dim suma = count + 1

                'txtCodigo.Text = "922" & TipoCosto.OP_CONTINUA_DE_BIENES & suma
                txtCodigo.Text = "92" & TipoCosto.OP_CONTINUA_DE_BIENES & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

            Case "OP. DE BIENES - CONTROL INDEPENDIENTE" 'retirar
                Dim count = recursoSA.GetCostoCount(TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE)
                Dim suma = count + 1

                txtCodigo.Text = "92" & TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

            Case "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT"
                Dim count = recursoSA.GetCostoCount(TipoCosto.OP_CONTINUA_DE_SERVICIOS)
                Dim suma = count + 1

                txtCodigo.Text = "92" & TipoCosto.OP_CONTINUA_DE_SERVICIOS & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

            Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP"
                Dim count = recursoSA.GetCostoCount(TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE)
                Dim suma = count + 1

                txtCodigo.Text = "92" & TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

            Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"

                Dim count = recursoSA.GetCostoCount(TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES)
                Dim suma = count + 1

                txtCodigo.Text = "92" & TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"



            Case "ACTIVO FIJO"
                Dim count = recursoSA.GetCostoCount(TipoCosto.ActivoFijo)
                Dim suma = count + 1

                txtCodigo.Text = "923" & suma
                txtmdp.Text = txtCodigo.Text & "MDP"
                txtMod.Text = txtCodigo.Text & "MOD"
                txtCif.Text = txtCodigo.Text & "OCD"
                txtGpi.Text = txtCodigo.Text & "GPI"
                txtGpiMpi.Text = txtCodigo.Text & "GPI-MPI"
                txtGpiMoi.Text = txtCodigo.Text & "GPI-MOI"
                txtGpiOgi.Text = txtCodigo.Text & "GPI-OGI"

                TabPage3.Parent = Nothing
            Case "GASTO ADMINISTRATIVO"
                Dim count = recursoSA.GetCostoCount(TipoCosto.GastoAdministrativo)
                Dim suma = count + 1

                txtCodigo.Text = "94" & String.Format("{0:000}", CInt(suma))
                txtmdp.Text = String.Empty
                txtMod.Text = String.Empty
                txtCif.Text = String.Empty

                TabPage3.Parent = Nothing
                TabPage2.Parent = Nothing
            Case "GASTO DE VENTAS"
                Dim count = recursoSA.GetCostoCount(TipoCosto.GastoVentas)
                Dim suma = count + 1

                txtCodigo.Text = "95" & String.Format("{0:000}", CInt(suma))
                txtmdp.Text = String.Empty
                txtMod.Text = String.Empty
                txtCif.Text = String.Empty

                TabPage3.Parent = Nothing
                TabPage2.Parent = Nothing
            Case "GASTO FINANCIERO"

                Dim count = recursoSA.GetCostoCount(TipoCosto.GastoFinanciero)
                Dim suma = count + 1

                txtCodigo.Text = "97" & String.Format("{0:000}", CInt(suma))
                txtmdp.Text = String.Empty
                txtMod.Text = String.Empty
                txtCif.Text = String.Empty

                TabPage3.Parent = Nothing
                TabPage2.Parent = Nothing
        End Select


    End Sub

    Public Sub UbicarCostoById(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        GetComboTipoCostos()

        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = be.idCosto})
        Me.Tag = recurso.idCosto
        Select Case recurso.tipo
            Case "HC"
                cboTipo.Text = "HOJA DE COSTO"
            Case "HG"
                cboTipo.Text = "HOJA DE GASTO"
        End Select

        Select Case recurso.subtipo
            Case TipoCosto.CONTRATOS_DE_CONSTRUCCION
                cboSubtipo.Text = "HC - CONSTRUC. Y SIMILARES" '"CONTRATOS DE CONSTRUCCION",

            Case TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                cboSubtipo.Text = "HC - ARRENDAMIENTO" '"CONTRATOS DE ARRENDAMIENTOS"

            Case TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                cboSubtipo.Text = "HC - SERV. VARIOS" ' "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"


            Case (TipoCosto.OP_CONTINUA_DE_BIENES)
                cboSubtipo.Text = "HC - PRODUCCION" ' "OP. CONTINUA DE BIENES"

            Case (TipoCosto.OP_CONTINUA_DE_SERVICIOS)
                cboSubtipo.Text = "HC - SERV. EDUCAT" ' "OP. CONTINUA DE SERVICIOS"

            Case (TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE)
                '  cboSubtipo.Text = ""'"OP. DE BIENES - CONTROL INDEPENDIENTE"

            Case (TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES)
                cboSubtipo.Text = "HC - CONSUMO INMEDIATO" ' "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"

            Case (TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE)
                cboSubtipo.Text = "HC - SERV. TRANSP" '"OP. DE SERVICIOS - CONTROL INDEPENDIENTE"

            Case TipoCosto.ActivoFijo
                cboSubtipo.Text = "ACTIVO FIJO"
            Case TipoCosto.GastoAdministrativo
                cboSubtipo.Text = "GASTO ADMINISTRATIVO"
            Case TipoCosto.GastoVentas
                cboSubtipo.Text = "GASTO DE VENTAS"
            Case TipoCosto.GastoFinanciero
                cboSubtipo.Text = "GASTO FINANCIERO"
        End Select


        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, recurso.director)
        txtDirector.Text = persona.nombreCompleto
        txtDirector.Tag = persona.idPersona
        txtDirector.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

        txtNuevoCosto.Text = recurso.nombreCosto
        txtCodigo.Text = recurso.codigo
        txtdetalle.Text = recurso.detalle
        txtSubdetalle.Text = recurso.subdetalle
        txtInicio.Value = recurso.inicio
        txtFinaliza.Value = recurso.finaliza
    End Sub

    Private Sub Grabar()
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa
        Dim listaProcesos As New List(Of recursoCosto)


        listaProcesos = New List(Of recursoCosto)


        dgvProductosTerminados.TableControl.CurrentCell.EndEdit()
        dgvProductosTerminados.TableControl.Table.TableDirty = True
        dgvProductosTerminados.TableControl.Table.EndEdit()



        Dim listaEntera As New List(Of Integer)

        costo = New recursoCosto
        costo.idpadre = IdProyectoGeneral
        costo.tipo = If(cboTipo.Text = "HOJA DE COSTO", "HC", "HG")
        Select Case cboSubtipo.Text
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES"
                costo.subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS"
                costo.subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                costo.subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION"
                costo.subtipo = TipoCosto.OP_CONTINUA_DE_BIENES
                costo.status = StatusProductosTerminados.Pendiente '  StatusCosto.Avance_Obra_Cartera

            Case "OP. DE BIENES - CONTROL INDEPENDIENTE" 'RETIRAR OBSERVADO
                costo.subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT"
                costo.subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP"
                costo.subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                costo.subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES
                costo.status = StatusCosto.Avance_Obra_Cartera
                'Case "ORDEN DE PRODUCCION"
                '    costo.subtipo = TipoCosto.OrdenProduccion
                '    costo.status = StatusCosto.Proceso
            Case "ACTIVO FIJO"
                costo.subtipo = TipoCosto.ActivoFijo
                costo.status = StatusCosto.Avance_Obra_Cartera
            Case "GASTO ADMINISTRATIVO"
                costo.subtipo = TipoCosto.GastoAdministrativo
                costo.status = StatusCosto.Proceso
            Case "GASTO DE VENTAS"
                costo.subtipo = TipoCosto.GastoVentas
                costo.status = StatusCosto.Proceso
            Case "GASTO FINANCIERO"
                costo.subtipo = TipoCosto.GastoFinanciero
                costo.status = StatusCosto.Proceso

            Case "HC - MERCADERIA"
                costo.subtipo = TipoCosto.HC_Mercaderia
                costo.status = StatusCosto.Proceso
        End Select
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = txtCodigo.Text.Trim
        costo.detalle = txtdetalle.Text.Trim
        costo.subdetalle = txtSubdetalle.Text.Trim
        costo.inicio = txtInicio.Value
        costo.finaliza = txtFinaliza.Value
        costo.director = Val(txtDirector.Tag)
        costo.procesado = "N"

        'listaEntera = New List(Of Integer)
        'For Each i In cboJerarquia.SelectedItems
        '    Select Case i.ToString
        '        Case "EDT"
        '            listaEntera.Add(0)
        '        Case "Actividad"
        '            listaEntera.Add(1)
        '        Case "Tarea"
        '            listaEntera.Add(2)
        '    End Select
        'Next
        'Dim listJerarquia = listaEntera.OrderBy(Function(o) o).ToList
        costo.jerarquia = String.Empty
        'For Each i In listJerarquia
        '    costo.jerarquia += i.ToString
        'Next
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now
        costo.idNumeracion = GConfiguracion.ConfigComprobante

        item = New cuentaplanContableEmpresa
        item.NomCosto = txtNuevoCosto.Text.Trim
        item.idEmpresa = Gempresas.IdEmpresaRuc
        item.cuenta = txtCodigo.Text
        item.descripcion = txtNuevoCosto.Text.Trim
        item.Observaciones = Nothing
        Select Case cboSubtipo.Text
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                item.cuentaPadre = "92"

            Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"

                item.cuentaPadre = "92"

            Case "ACTIVO FIJO"
                item.cuentaPadre = "92"

            Case "GASTO ADMINISTRATIVO"
                item.cuentaPadre = "94"

            Case "GASTO DE VENTAS"
                item.cuentaPadre = "95"

            Case "GASTO FINANCIERO"
                item.cuentaPadre = "97"

        End Select
        item.usuarioModificacion = usuario.IDUsuario
        item.fechaModificacion = DateTime.Now
        lista.Add(item)

        'ELEMENTOS DEL COSTO

        Select Case cboSubtipo.Text
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO", _
                "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO", _
                "ACTIVO FIJO"

                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtmdp.Text
                item.descripcion = "MATERIA PRIMA DIRECTA"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "MPD"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)

                'Elementos del costo
                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtMod.Text
                item.descripcion = "MANO DE OBRA DIRECTA"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "MOD"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)


                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtCif.Text
                item.descripcion = "OTROS COSTOS DIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "OCD"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                          "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                          "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                          "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)

                '04 Gastos de produccion indirectos
                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtGpi.Text
                item.descripcion = "GASTOS DE PRODUCCION INDIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                         "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                         "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                          "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                          "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                          "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)

                '041 GPI-Materiales y suministros indirectos
                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtGpiMpi.Text
                item.descripcion = "GPI-MATERIALES Y SUMINISTROS INDIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI-MPI"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                      "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                      "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                          "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                          "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                          "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)


                '042 GPI-mano de obra indirecto
                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtGpiMoi.Text
                item.descripcion = "GPI-MANO DE OBRA INDIRECTO"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI-MOI"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)


                '043 GPI-OTROS GASTOS DE PRODUCCION INDIRECTOS
                item = New cuentaplanContableEmpresa
                item.NomCosto = txtNuevoCosto.Text.Trim
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = txtGpiOgi.Text
                item.descripcion = "GPI-OTROS GASTOS DE PRODUCCION INDIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI-OGI"
                Select Case cboSubtipo.Text
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = usuario.IDUsuario
                item.fechaModificacion = DateTime.Now
                lista.Add(item)
            Case Else

        End Select

        recursoSA.GrabarCosto(costo, lista, listaProcesos)
        Dispose()
    End Sub

    Private Sub Editar()
        Dim costo As New recursoCosto
        Dim recursoSA As New recursoCostoSA


        costo = New recursoCosto
        costo.idCosto = Val(Me.Tag)
        costo.tipo = If(cboTipo.Text = "HOJA DE COSTO", "HC", "HG")
        Select Case cboSubtipo.Text
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES"
                costo.subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS"
                costo.subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                costo.subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION"
                costo.subtipo = TipoCosto.OP_CONTINUA_DE_BIENES
                costo.status = StatusProductosTerminados.Pendiente ' StatusCosto.Avance_Obra_Cartera

            Case "OP. DE BIENES - CONTROL INDEPENDIENTE" 'RETIRAR
                costo.subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT"
                costo.subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP"
                costo.subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                costo.status = StatusCosto.Avance_Obra_Cartera

            Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                costo.subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES
                costo.status = StatusCosto.Avance_Obra_Cartera
                'Case "ORDEN DE PRODUCCION"
                '    costo.subtipo = TipoCosto.OrdenProduccion
                '    costo.status = StatusCosto.Proceso
            Case "ACTIVO FIJO"
                costo.subtipo = TipoCosto.ActivoFijo
                costo.status = StatusCosto.Avance_Obra_Cartera
            Case "GASTO ADMINISTRATIVO"
                costo.subtipo = TipoCosto.GastoAdministrativo
                costo.status = StatusCosto.Proceso
            Case "GASTO DE VENTAS"
                costo.subtipo = TipoCosto.GastoVentas
                costo.status = StatusCosto.Proceso
            Case "GASTO FINANCIERO"
                costo.subtipo = TipoCosto.GastoFinanciero
                costo.status = StatusCosto.Proceso
        End Select
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = txtCodigo.Text.Trim
        costo.detalle = txtdetalle.Text.Trim
        costo.subdetalle = txtSubdetalle.Text.Trim
        costo.inicio = txtInicio.Value
        costo.finaliza = txtFinaliza.Value
        costo.procesado = "N"
        costo.director = Val(txtDirector.Tag)
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now

        recursoSA.EditarCosto(costo)
        Dispose()
    End Sub
#End Region

    Private Sub frmNuevoCosto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub


    Private Sub frmNuevoCosto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevoCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        txtNuevoCosto.Select()
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click
        'If cboTipo.Text = "HOJA DE COSTO" Then
        '    cboSubtipo.Items.Clear()
        '    cboSubtipo.Items.Add("CONTRATOS DE CONSTRUCCION")
        '    cboSubtipo.Items.Add("ORDEN DE PRODUCCION")
        '    cboSubtipo.Items.Add("ACTIVO FIJO")
        'Else
        '    cboSubtipo.Items.Clear()
        '    cboSubtipo.Items.Add("GASTO ADMINISTRATIVO")
        '    cboSubtipo.Items.Add("GASTO DE VENTAS")
        '    cboSubtipo.Items.Add("GASTO FINANCIERO")
        'End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor

        'If Not txtDirector.Text.Trim.Length > 0 Then

        '    MessageBox.Show("Ingrese el director del proyecto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If
        'If txtDirector.Text.Trim.Length > 0 Then
        '    If txtDirector.ForeColor = Color.Black Then
        '        MessageBox.Show("Verificar el ingreso correcto del director del proyecto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        txtDirector.Select()
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    End If
        'End If

        If Manipulacion = ENTITY_ACTIONS.INSERT Then
            Select Case cboSubtipo.Text
                Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION", _
                "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT", _
                "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                    'If lsvProcesos.Items.Count > 0 Then
                    If txtNuevoCosto.Text.Trim.Length > 0 Then
                        'If dgvProductosTerminados.Table.Records.Count > 0 Then
                        Grabar()
                        'Else
                        '    MessageBox.Show("Debe ingresar al menos un producto terminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Me.Cursor = Cursors.Arrow
                        '    Exit Sub
                        'End If

                    Else
                        MessageBox.Show("Debe indicar el campo nombre del costo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    'Else
                    '    MessageBox.Show("Debe ingresar al menos un proceso.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    TabControl1.SelectTab(1)
                    '    Me.Cursor = Cursors.Arrow
                    '    Exit Sub
                    'End If


                Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES", _
                    "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS", _
                    "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO",
                    "ACTIVO FIJO"

                    'If lsvProcesos.Items.Count > 0 Then
                    If txtNuevoCosto.Text.Trim.Length > 0 Then
                        Grabar()
                    Else
                        MessageBox.Show("Debe indicar el campo nombre del costo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    'Else
                    'MessageBox.Show("Debe ingresar al menos un proceso.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'TabControl1.SelectTab(1)
                    'Me.Cursor = Cursors.Arrow
                    'Exit Sub
                    'End If

                Case Else
                    If txtNuevoCosto.Text.Trim.Length > 0 Then
                        Grabar()
                    Else
                        MessageBox.Show("Debe indicar el campo nombre del costo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

            End Select

        Else
            Editar()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboSubtipo_Click(sender As Object, e As EventArgs) Handles cboSubtipo.Click

    End Sub

    Private Sub cboSubtipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubtipo.SelectedIndexChanged
        Dim cod = cboSubtipo.Text

        Select Case cod
            Case "GASTO ADMINISTRATIVO"
                GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "94"})
            Case "GASTO DE VENTAS"
                GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "95"})
            Case "GASTO FINANCIERO"
                GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "97"})
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                TabPage3.Parent = Nothing
            Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION", _
                "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT", _
                "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"

                GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                'TabPage3.Parent = TabControl1
            Case "ACTIVO FIJO"
                GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                TabPage3.Parent = Nothing
        End Select

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If txtProcesos.Text.Trim.Length > 0 Then
            Dim n As New ListViewItem("0")
            n.SubItems.Add(txtProcesos.Text.Trim)
            n.SubItems.Add("PN")
            lsvProcesos.Items.Add(n)
            txtProcesos.Clear()
        Else
            MessageBox.Show("Describir en la caja de texto un proceso válido", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProcesos.Select()
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If lsvProcesos.SelectedItems.Count > 0 Then
            lsvProcesos.Items.Remove(lsvProcesos.SelectedItems(0))
        Else
            MessageBox.Show("No existen procesos en la lista", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'Dim f As New frmBusquedaExistencia
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        With frmBusquedaExistencia
            .cboTipoExistencia.SelectedValue = TipoExistencia.ProductoTerminado
            .cboTipoExistencia.Enabled = False
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With

    End Sub

    Private Sub dgvProductosTerminados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProductosTerminados.TableControlCellClick

    End Sub

    Private Sub dgvProductosTerminados_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvProductosTerminados.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvProductosTerminados_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvProductosTerminados.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvProductosTerminados.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4 ' cantidad
                    Dim colCantidad As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("cantidad")
                    Dim colCosto As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("costo")
                    If colCantidad > 0 Then
                        Dim colPU As Decimal = colCosto / colCantidad
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("pu", colPU)
                    Else
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("costo", 0)
                    End If
                Case 6, 10 'Valor de compra
                    Dim colCantidad As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("cantidad")
                    Dim colCosto As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("costo")
                    If colCantidad > 0 Then
                        Dim colPU As Decimal = colCosto / colCantidad
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("pu", colPU)
                    Else
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("costo", 0)
                    End If


            End Select
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Not IsNothing(dgvProductosTerminados.Table.CurrentRecord) Then
            dgvProductosTerminados.Table.CurrentRecord.Delete()
        Else
            MessageBox.Show("Debe seleccionar un item válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If lsvProcesos.SelectedItems.Count > 0 Then
            Dim ind As Integer = lsvProcesos.SelectedItems(0).Index

            If ind = 0 Then

            Else
                Dim litem As ListViewItem = lsvProcesos.Items(ind)
                lsvProcesos.Items.RemoveAt(ind)
                lsvProcesos.Items.Insert(ind - 1, litem)
            End If
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If lsvProcesos.SelectedItems.Count > 0 Then
            Dim ultimaFila = lsvProcesos.Items.Count - 1

            Dim ind As Integer = lsvProcesos.SelectedItems(0).Index

            If ind = ultimaFila Then

            Else
                Dim litem As ListViewItem = lsvProcesos.Items(ind)
                lsvProcesos.Items.RemoveAt(ind)
                lsvProcesos.Items.Insert(ind + 1, litem)
            End If
        End If
    End Sub

    Private Sub txtDirector_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDirector.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(271, 110)
            Me.popupControlContainer1.ParentControl = Me.txtDirector
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaPersonas _
                     Where n.nombreCompleto.StartsWith(txtDirector.Text)).ToList

            lsvPersona.DataSource = consulta
            lsvPersona.DisplayMember = "nombreCompleto"
            lsvPersona.ValueMember = "idPersona"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(271, 110)
            Me.popupControlContainer1.ParentControl = Me.txtDirector
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            lsvPersona.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtDirector_TextChanged(sender As Object, e As EventArgs) Handles txtDirector.TextChanged
        txtDirector.ForeColor = Color.Black
        txtDirector.Tag = Nothing
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvPersona.SelectedItems.Count > 0 Then
                txtDirector.Text = lsvPersona.Text
                txtDirector.Tag = lsvPersona.SelectedValue
                '  txtDirector.Clear()
                txtDirector.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtDirector.Focus()
        End If
    End Sub

    Private Sub lsvPersona_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvPersona.MouseDoubleClick
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvPersona.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        With FrmNuevaPersona
            .StartPosition = FormStartPosition.CenterParent
            '.Label9.Visible = False
            .cboCuenta.Visible = False
            .ShowDialog()
            CargarTrabajadores()
        End With
    End Sub
End Class