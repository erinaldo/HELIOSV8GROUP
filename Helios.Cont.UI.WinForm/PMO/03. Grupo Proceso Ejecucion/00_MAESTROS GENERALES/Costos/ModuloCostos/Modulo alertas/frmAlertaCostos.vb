Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmAlertaCostos
    Inherits frmMaster

#Region "Attributes"
    Public Property documentocajaSA As New DocumentoCajaSA
#End Region
    Dim oper As Object
#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        GridCFG(dgvItemsNoasignados)
        GridCFG(GridGroupingControl1)
        GridCFG(dgFinanzas)
        GridCFG(dgvAsientosNoAsignados)
        GetItemsNoAsignados()
        GetItemsNoAsignadosInventario()
        GetItemsNoAsignadosFinanzas()
        GetItemsAsientosNoAsignados()
        ''rbHojaCosto.Checked = True

    End Sub
#End Region

#Region "Proyectos"
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

    Public Sub GetItemsNoAsignados()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("Serie")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad1")
        dt.Columns.Add("monto1")
        dt.Columns.Add("montokardex")
        dt.Columns.Add("montokardexUS")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idPadreDTCompra")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")

        For Each i In compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.FechaDoc
            dr(3) = i.TipoDoc
            dr(4) = i.Serie
            dr(5) = i.NumDoc
            dr(6) = i.Moneda
            dr(7) = i.idItem
            dr(8) = i.descripcionItem
            dr(9) = i.tipoExistencia

            dr(10) = i.destino
            dr(11) = "UND" 'i.unidad1
            dr(12) = i.monto1
            dr(13) = i.montokardex
            dr(14) = i.montokardexUS
            dr(15) = i.TipoOperacion
            dr(16) = i.idPadreDTCompra
            dr(17) = i.idCosto
            dr(18) = i.NombreProyectoGeneral
            dr(19) = Nothing
            dr(20) = Nothing
            dr(21) = Nothing
            dr(22) = Nothing
            dr(23) = Nothing
            dr(24) = Nothing
            dr(25) = Nothing
            dr(26) = Nothing
            dt.Rows.Add(dr)
        Next

        'Dim dt As New DataTable
        'dt.Columns.Add("idDocumento")
        'dt.Columns.Add("secuencia")
        'dt.Columns.Add("FechaDoc")
        'dt.Columns.Add("TipoDoc")
        'dt.Columns.Add("Serie")
        'dt.Columns.Add("NumDoc")
        'dt.Columns.Add("Moneda")
        'dt.Columns.Add("idItem")
        'dt.Columns.Add("descripcionItem")
        'dt.Columns.Add("tipoExistencia")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("unidad1")
        'dt.Columns.Add("monto1")
        'dt.Columns.Add("montokardex")
        'dt.Columns.Add("montokardexUS")

        'dt.Columns.Add("TipoOperacion")
        'dt.Columns.Add("idPadreDTCompra")
        'dt.Columns.Add("proceso")

        'For Each i In compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                            .fechaContable = PeriodoGeneral})

        '    Dim dr As DataRow = dt.NewRow
        '    dr(0) = i.idDocumento
        '    dr(1) = i.secuencia
        '    dr(2) = i.FechaDoc
        '    dr(3) = i.TipoDoc
        '    dr(4) = i.Serie
        '    dr(5) = i.NumDoc
        '    dr(6) = i.Moneda
        '    dr(7) = i.idItem
        '    dr(8) = i.descripcionItem
        '    dr(9) = i.tipoExistencia
        '    dr(10) = i.destino
        '    dr(11) = i.unidad1
        '    dr(12) = i.monto1
        '    dr(13) = i.montokardex
        '    dr(14) = i.montokardexUS
        '    dr(15) = i.TipoOperacion
        '    dr(16) = i.idPadreDTCompra
        '    dr(17) = String.Empty
        '    dt.Rows.Add(dr)
        'Next

        dgvItemsNoasignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvItemsNoasignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Public Sub GetItemsNoAsignadosInventario()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("Serie")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad1")
        dt.Columns.Add("monto1")
        dt.Columns.Add("montokardex")
        dt.Columns.Add("montokardexUS")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idPadreDTCompra")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")
        For Each i In compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                   .fechaContable = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.FechaDoc
            dr(3) = i.TipoDoc
            dr(4) = i.Serie
            dr(5) = i.NumDoc
            dr(6) = i.Moneda
            dr(7) = i.idItem
            dr(8) = i.descripcionItem
            dr(9) = i.tipoExistencia

            dr(10) = i.destino
            dr(11) = i.unidad1
            dr(12) = i.monto1
            dr(13) = i.montokardex
            dr(14) = i.montokardexUS
            dr(15) = i.TipoOperacion
            dr(16) = i.idPadreDTCompra
            dr(17) = i.idCosto
            dr(18) = i.NombreProyectoGeneral
            dr(19) = Nothing
            dr(20) = Nothing
            dr(21) = Nothing
            dr(22) = Nothing
            dr(23) = Nothing
            dr(24) = Nothing
            dr(25) = Nothing
            dr(26) = Nothing
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '.fechaContable = PeriodoGeneral})
        GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Public Sub GetItemsAsientosNoAsignados()
        Dim libroSA As New documentoLibroDiarioSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")

        For Each i In libroSA.ListaRecursosCostoLibro(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                                .fechaPeriodo = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.fecha
            dr(3) = i.tipoDocumento
            dr(4) = i.nroDoc
            dr(5) = i.moneda
            dr(6) = i.cuenta
            dr(7) = i.descripcion

            If i.tipoAsiento = "D" Then
                dr(8) = i.importeMN
                dr(9) = i.importeME
            Else
                dr(8) = (i.importeMN) * -1
                dr(9) = (i.importeME) * -1
            End If


            dr(10) = i.operacion
            dr(11) = 0
            dr(12) = ""
            dr(13) = Nothing
            dr(14) = Nothing
            dr(15) = Nothing
            dr(16) = Nothing
            dr(17) = Nothing
            dr(18) = Nothing
            dr(19) = Nothing
            dr(20) = Nothing
            dt.Rows.Add(dr)
        Next



        dgvAsientosNoAsignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvAsientosNoAsignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Private Sub GetItemsNoAsignadosFinanzas()
        documentocajaSA = New DocumentoCajaSA()
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("movimientoCaja")
        dt.Columns.Add("fechaCobro")
        dt.Columns.Add("entidadFinanciera")
        dt.Columns.Add("tipoDocPago")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("moneda")
        dt.Columns.Add("montoSoles")
        dt.Columns.Add("montoUsd")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")
        dt.Columns.Add("glosa")

        Dim lista = documentocajaSA.GetItemsNoAsignadosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                            .asientoCosto = StatusAsientoCosto.AsientoPorConfirmar})


        For Each i In lista
            dt.Rows.Add(i.idDocumento,
                        i.movimientoCaja,
                        i.fechaCobro,
                        i.entidadFinanciera,
                        i.tipoDocPago,
                        i.numeroDoc,
                        i.moneda, i.montoSoles, i.montoUsd,
                        Nothing, Nothing, Nothing, Nothing, Nothing,
                        Nothing, Nothing, Nothing, Nothing, Nothing,
                        i.glosa)
        Next

        dgFinanzas.DataSource = dt ' documentocajaSA.GetItemsNoAsignadosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '.asientoCosto = StatusAsientoCosto.AsientoPorConfirmar})
    End Sub

    Function ValidaNotaByReferencia(intIdDocumentoPadre As Integer) As documentocompradetalle
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim compra As New documentocompradetalle
        compra = compraSA.GetUbicar_documentocompradetallePorID(intIdDocumentoPadre)

        Return compra
    End Function

    Public Sub RegistrarFinanzas()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA
        Dim codigoCosto As Integer
        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        ' Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)

            'FINANZAS
            '--------------------------------------------------------------------------------------------
            For Each i As SelectedRecord In dgFinanzas.Table.SelectedRecords

                Select Case i.Record.GetValue("abrev")
                    Case "HC"
                        'validando edt seleccionado
                        Dim valEdt = i.Record.GetValue("edt")
                        If IsNothing(valEdt) Then
                            MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        If valEdt.ToString.Trim.Length <= 0 Then
                            MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If


                        If i.Record.GetValue("abrev") = "HC" Then ' rbHojaCosto.Checked = True Then
                            codigoCosto = i.Record.GetValue("idElemento") ' cboElemento.SelectedValue
                        Else 'If rbHojaGasto.Checked = True Then
                            codigoCosto = i.Record.GetValue("idSubProyecto") 'i.record.getvalue("idSubProyecto")
                        End If

                        objAsiento = New asiento
                        objAsiento.periodo = PeriodoGeneral
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idDocumentoRef = Nothing
                        objAsiento.idAlmacen = 0
                        objAsiento.nombreAlmacen = String.Empty
                        objAsiento.idEntidad = String.Empty
                        objAsiento.nombreEntidad = String.Empty
                        objAsiento.tipoEntidad = String.Empty
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.codigoLibro = "8"
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = "ACCA"
                        objAsiento.importeMN = CDec(i.Record.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montoUsd"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        Select Case i.Record.GetValue("tipoCosto") 'i.record.getvalue("tipoCosto")
                            Case TipoCosto.Proyecto,
                                    TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES,
                                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS

                                recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})



                                objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "COSTOS POR DISTRIBUIR.",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)


                                listaAsiento.Add(objAsiento)

                            Case TipoCosto.OrdenProduccion,
                                    TipoCosto.OP_CONTINUA_DE_BIENES,
                                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES


                                'objMovimiento = New movimiento With {
                                '                .cuenta = "791",
                                '                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                '                .tipo = "D",
                                '                .monto = CDec(i.Record.GetValue("montoSoles")),
                                '                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                '                .usuarioActualizacion = usuario.IDUsuario,
                                '                .fechaActualizacion = DateTime.Now
                                '            }
                                'objAsiento.movimiento.Add(objMovimiento)


                                'objMovimiento = New movimiento With {
                                '               .cuenta = "91",
                                '               .descripcion = "COSTOS POR DISTRIBUIR.",
                                '               .tipo = "H",
                                '               .monto = CDec(i.Record.GetValue("montoSoles")),
                                '               .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                '               .usuarioActualizacion = usuario.IDUsuario,
                                '               .fechaActualizacion = DateTime.Now
                                '           }
                                'objAsiento.movimiento.Add(objMovimiento)

                                '----------------------------------------------------------------------


                                objMovimiento = New movimiento With {
                                                .cuenta = "231",
                                                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                                .cuenta = "7111",
                                                .descripcion = "PRODUCTOS MANUFACTURADOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)



                                listaAsiento.Add(objAsiento)

                            Case TipoCosto.ActivoFijo
                                recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})

                                objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                                .cuenta = "7225",
                                                .descripcion = "EQUIPOS DIVERSOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)

                                listaAsiento.Add(objAsiento)

                            Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
                                recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                                objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)

                                '.cuenta = "791",
                                '.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                objMovimiento = New movimiento With {
                                              .cuenta = "791",
                                                .descripcion = "COSTOS POR DISTRIBUIR.",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                objAsiento.movimiento.Add(objMovimiento)

                                listaAsiento.Add(objAsiento)
                        End Select

                        Select Case i.Record.GetValue("movimientoCaja")
                            Case MovimientoCaja.Otras_Entradas
                                oper = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            Case MovimientoCaja.Otras_Saliadas
                                oper = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            Case MovimientoCaja.TrasferenciaEntreCajas
                                oper = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
                        End Select

                        obj = New recursoCostoDetalle With {
                                         .idCosto = codigoCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("fechaCobro")),
                                        .iditem = Val(i.Record.GetValue("entidadFinanciera")),
                                        .destino = "1",
                                        .descripcion = i.Record.GetValue("glosa"),
                                        .um = "UND",
                                        .cant = 1,
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montoSoles")),
                                        .montoME = CDec(i.Record.GetValue("montoUsd")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = 0,
                                        .operacion = oper,
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                        Lista.Add(obj)

                    Case "HG"
                        objAsiento = New asiento
                        objAsiento.periodo = PeriodoGeneral
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idDocumentoRef = Nothing
                        objAsiento.idAlmacen = 0
                        objAsiento.nombreAlmacen = String.Empty
                        objAsiento.idEntidad = String.Empty
                        objAsiento.nombreEntidad = String.Empty
                        objAsiento.tipoEntidad = String.Empty
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.codigoLibro = "8"
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = "ACCA"
                        objAsiento.importeMN = CDec(i.Record.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montoUsd"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                        objMovimiento = New movimiento With {
                              .cuenta = recurso.codigo,
                              .descripcion = recurso.nombreCosto,
                              .tipo = "D",
                              .monto = CDec(i.Record.GetValue("montoSoles")),
                              .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                              .usuarioActualizacion = usuario.IDUsuario,
                              .fechaActualizacion = DateTime.Now
                          }
                        objAsiento.movimiento.Add(objMovimiento)


                        objMovimiento = New movimiento With {
                                .cuenta = "791",
                                .descripcion = "COSTOS POR DISTRIBUIR.",
                                .tipo = "H",
                                .monto = CDec(i.Record.GetValue("montoSoles")),
                                .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                        objAsiento.movimiento.Add(objMovimiento)

                        listaAsiento.Add(objAsiento)

                        Select Case i.Record.GetValue("movimientoCaja")
                            Case MovimientoCaja.Otras_Entradas
                                oper = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            Case MovimientoCaja.Otras_Saliadas
                                oper = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            Case MovimientoCaja.TrasferenciaEntreCajas
                                oper = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
                        End Select

                        obj = New recursoCostoDetalle With {
                                         .idCosto = codigoCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("fechaCobro")),
                                        .iditem = Val(i.Record.GetValue("entidadFinanciera")),
                                        .destino = "1",
                                        .descripcion = i.Record.GetValue("glosa"),
                                        .um = "UND",
                                        .cant = 1,
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montoSoles")),
                                        .montoME = CDec(i.Record.GetValue("montoUsd")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = 0,
                                        .operacion = oper,
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                        Lista.Add(obj)

                End Select
            Next

            costoSA.GrabarDetalleRecursoFinanza(Lista, listaAsiento)
            GetItemsNoAsignadosFinanzas()
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RegistrarItemsAsignadosLibro()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA
        Dim codigoCosto As Integer
        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)


            'ASIENTO MANUALES LIBRO DIARIO
            If TabControlAdv1.SelectedTab Is TabPageAdv4 Then
                For Each i As SelectedRecord In dgvAsientosNoAsignados.Table.SelectedRecords

                    Select Case i.Record.GetValue("abrev")
                        Case "HC"
                            'validando edt seleccionado
                            Dim valEdt = i.Record.GetValue("edt")
                            If IsNothing(valEdt) Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            If valEdt.ToString.Trim.Length <= 0 Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If


                            If i.Record.GetValue("abrev") = "HC" Then ' rbHojaCosto.Checked = True Then
                                codigoCosto = i.Record.GetValue("idElemento") ' cboElemento.SelectedValue
                            Else 'If rbHojaGasto.Checked = True Then
                                codigoCosto = i.Record.GetValue("idSubProyecto") 'i.record.getvalue("idSubProyecto")
                            End If

                            'objDetalleCompra = New documentocompradetalle

                            'Select Case i.Record.GetValue("TipoDoc")
                            '    Case "07" 'NOTA DE CREDITO
                            '        objDetalleCompra = ValidaNotaByReferencia(dgvAsientosNoAsignados.Table.CurrentRecord.GetValue("idPadreDTCompra"))

                            '        If IsNothing(obj) Then
                            '            Throw New Exception("Debe asignar primero el comprobante padre!")
                            '        End If

                            '    Case Else

                            'End Select


                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"

                            If i.Record.GetValue("importeMN") < 0 Then
                                objAsiento.importeMN = CDec(i.Record.GetValue("importeMN")) * -1
                                objAsiento.importeME = CDec(i.Record.GetValue("importeME")) * -1
                            Else
                                objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                                objAsiento.importeME = CDec(i.Record.GetValue("importeME"))
                            End If


                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            Select Case i.Record.GetValue("tipoCosto") 'i.record.getvalue("tipoCosto")
                                Case TipoCosto.Proyecto,
                                    TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES,
                                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS

                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})

                                    'Select Case i.Record.GetValue("TipoDoc")
                                    '    Case "07" 'NOTA DE CREDITO

                                    '        objMovimiento = New movimiento With {
                                    '            .cuenta = "791",
                                    '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    '            .tipo = "D",
                                    '            .monto = CDec(i.Record.GetValue("montokardex")),
                                    '            .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    '            .usuarioActualizacion = usuario.IDUsuario,
                                    '            .fechaActualizacion = DateTime.Now
                                    '        }
                                    '        objAsiento.movimiento.Add(objMovimiento)

                                    '        objMovimiento = New movimiento With {
                                    '          .cuenta = recurso.codigo,
                                    '          .descripcion = recurso.nombreCosto,
                                    '          .tipo = "H",
                                    '          .monto = CDec(i.Record.GetValue("montokardex")),
                                    '          .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    '          .usuarioActualizacion = usuario.IDUsuario,
                                    '          .fechaActualizacion = DateTime.Now
                                    '      }
                                    '        objAsiento.movimiento.Add(objMovimiento)


                                    '    Case Else
                                    If i.Record.GetValue("importeMN") > 0 Then
                                        objMovimiento = New movimiento With {
                                            .cuenta = recurso.codigo,
                                            .descripcion = recurso.nombreCosto,
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        objMovimiento = New movimiento With {
                                            .cuenta = "791",
                                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                        'SI ES NEGATIVO
                                    Else
                                        objMovimiento = New movimiento With {
                                         .cuenta = recurso.codigo,
                                         .descripcion = recurso.nombreCosto,
                                         .tipo = "D",
                                         .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                         .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                         .usuarioActualizacion = usuario.IDUsuario,
                                     .fechaActualizacion = DateTime.Now
                                     }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        objMovimiento = New movimiento With {
                                            .cuenta = "791",
                                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                    End If
                                    'End Select
                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.OrdenProduccion,
                                        TipoCosto.OP_CONTINUA_DE_BIENES,
                                        TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                                        TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                                        TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE,
                                        TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                                    'Select Case i.Record.GetValue("TipoDoc")
                                    '    Case "07" 'NOTA DE CREDITO



                                    '        objMovimiento = New movimiento With {
                                    '          .cuenta = "7111",
                                    '          .descripcion = "PRODUCTOS MANUFACTURADOS",
                                    '          .tipo = "D",
                                    '          .monto = CDec(i.Record.GetValue("importeMN")),
                                    '          .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    '          .usuarioActualizacion = usuario.IDUsuario,
                                    '          .fechaActualizacion = DateTime.Now
                                    '      }
                                    '        objAsiento.movimiento.Add(objMovimiento)

                                    '        objMovimiento = New movimiento With {
                                    '           .cuenta = "231",
                                    '           .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                    '           .tipo = "H",
                                    '           .monto = CDec(i.Record.GetValue("importeMN")),
                                    '           .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    '           .usuarioActualizacion = usuario.IDUsuario,
                                    '           .fechaActualizacion = DateTime.Now
                                    '       }
                                    '        objAsiento.movimiento.Add(objMovimiento)


                                    '    Case Else

                                    If i.Record.GetValue("importeMN") > 0 Then
                                        objMovimiento = New movimiento With {
                                            .cuenta = "231",
                                            .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        objMovimiento = New movimiento With {
                                            .cuenta = "7131",
                                            .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                        'SI ES NEGATIVO
                                    Else
                                        objMovimiento = New movimiento With {
                                            .cuenta = "231",
                                            .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        objMovimiento = New movimiento With {
                                            .cuenta = "7131",
                                            .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                    End If
                                    ' End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.ActivoFijo
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})
                                    'Select Case i.Record.GetValue("TipoDoc")
                                    '    Case "07" 'NOTA DE CREDITO

                                    '        objMovimiento = New movimiento With {
                                    '            .cuenta = "7225",
                                    '            .descripcion = "EQUIPOS DIVERSOS",
                                    '            .tipo = "D",
                                    '            .monto = CDec(i.Record.GetValue("importeMN")),
                                    '            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    '            .usuarioActualizacion = usuario.IDUsuario,
                                    '            .fechaActualizacion = DateTime.Now
                                    '        }
                                    '        objAsiento.movimiento.Add(objMovimiento)

                                    '        objMovimiento = New movimiento With {
                                    '            .cuenta = recurso.codigo,
                                    '            .descripcion = recurso.nombreCosto,
                                    '            .tipo = "H",
                                    '            .monto = CDec(i.Record.GetValue("importeMN")),
                                    '            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    '            .usuarioActualizacion = usuario.IDUsuario,
                                    '            .fechaActualizacion = DateTime.Now
                                    '        }
                                    '        objAsiento.movimiento.Add(objMovimiento)


                                    '    Case Else
                                    If i.Record.GetValue("importeMN") > 0 Then
                                        objMovimiento = New movimiento With {
                                            .cuenta = recurso.codigo,
                                            .descripcion = recurso.nombreCosto,
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        objMovimiento = New movimiento With {
                                            .cuenta = "7225",
                                            .descripcion = "EQUIPOS DIVERSOS",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                        'SI ES NEGATIVO
                                    Else
                                        objMovimiento = New movimiento With {
                                            .cuenta = recurso.codigo,
                                            .descripcion = recurso.nombreCosto,
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        objMovimiento = New movimiento With {
                                            .cuenta = "7225",
                                            .descripcion = "EQUIPOS DIVERSOS",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                    End If
                                    ' End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})


                                    'Select Case i.Record.GetValue("TipoDoc")
                                    '    Case "07" 'NOTA DE CREDITO
                                    '        objMovimiento = New movimiento With {
                                    '            .cuenta = "791",
                                    '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    '            .tipo = "D",
                                    '            .monto = CDec(i.Record.GetValue("importeMN")),
                                    '            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    '            .usuarioActualizacion = usuario.IDUsuario,
                                    '            .fechaActualizacion = DateTime.Now
                                    '        }
                                    '        objAsiento.movimiento.Add(objMovimiento)


                                    '        objMovimiento = New movimiento With {
                                    '            .cuenta = recurso.codigo,
                                    '            .descripcion = recurso.nombreCosto,
                                    '            .tipo = "H",
                                    '            .monto = CDec(i.Record.GetValue("importeMN")),
                                    '            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    '            .usuarioActualizacion = usuario.IDUsuario,
                                    '            .fechaActualizacion = DateTime.Now
                                    '        }
                                    '        objAsiento.movimiento.Add(objMovimiento)

                                    '    Case Else
                                    If i.Record.GetValue("importeMN") > 0 Then
                                        objMovimiento = New movimiento With {
                                            .cuenta = recurso.codigo,
                                            .descripcion = recurso.nombreCosto,
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        '.cuenta = "791",
                                        '.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        objMovimiento = New movimiento With {
                                          .cuenta = "791",
                                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")),
                                            .montoUSD = CDec(i.Record.GetValue("importeME")),
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                        'End Select
                                        'SI ES NEGATIVO
                                    Else

                                        objMovimiento = New movimiento With {
                                            .cuenta = recurso.codigo,
                                            .descripcion = recurso.nombreCosto,
                                            .tipo = "D",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)

                                        '.cuenta = "791",
                                        '.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        objMovimiento = New movimiento With {
                                          .cuenta = "791",
                                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            .tipo = "H",
                                            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                            .usuarioActualizacion = usuario.IDUsuario,
                                            .fechaActualizacion = DateTime.Now
                                        }
                                        objAsiento.movimiento.Add(objMovimiento)
                                    End If

                                    listaAsiento.Add(objAsiento)
                            End Select



                            'Select Case i.Record.GetValue("TipoDoc")
                            '    Case "07" 'NOTA DE CREDITO
                            '        obj = New recursoCostoDetalle With {
                            '            .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                            '            .idCosto = codigoCosto,
                            '            .iditem = Val(i.Record.GetValue("idItem")),
                            '            .destino = i.Record.GetValue("destino"),
                            '            .descripcion = i.Record.GetValue("descripcionItem"),
                            '            .um = i.Record.GetValue("unidad1"),
                            '            .cant = CDec(i.Record.GetValue("monto1")),
                            '            .puMN = 0,
                            '            .puME = 0,
                            '            .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
                            '            .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
                            '            .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                            '            .itemRef = CInt(i.Record.GetValue("secuencia")),
                            '            .operacion = i.Record.GetValue("TipoOperacion"),
                            '            .idProceso = CInt(i.Record.GetValue("idEDT")),
                            '            .procesado = "N",
                            '            .recursoCosto = New recursoCosto With
                            '                            {
                            '                                .subtipo = i.Record.GetValue("tipoCosto")
                            '                            }
                            '        }
                            '        Lista.Add(obj)

                            '    Case Else


                            obj = New recursoCostoDetalle With {
                                .idCosto = codigoCosto,
                                .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                .iditem = Val(i.Record.GetValue("cuenta")),
                                .descripcion = i.Record.GetValue("descripcionItem"),
                                .montoMN = CDec(i.Record.GetValue("importeMN")),
                                .montoME = CDec(i.Record.GetValue("importeME")),
                                .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                .itemRef = CInt(i.Record.GetValue("secuencia")),
                                .operacion = i.Record.GetValue("TipoOperacion"),
                                .procesado = "N",
                                .idProceso = CInt(i.Record.GetValue("idEDT")),
                            .recursoCosto = New recursoCosto With
                                            {
                            .subtipo = i.Record.GetValue("tipoCosto")
                                            }
                            }
                            Lista.Add(obj)
                            'End Select


                        Case "HG"
                            'martin
                            'Select Case i.Record.GetValue("TipoDoc")
                            '    Case "07"
                            '        'martin
                            '        objAsiento = New asiento
                            '        objAsiento.periodo = PeriodoGeneral
                            '        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            '        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            '        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            '        objAsiento.idDocumentoRef = Nothing
                            '        objAsiento.idAlmacen = 0
                            '        objAsiento.nombreAlmacen = String.Empty
                            '        objAsiento.idEntidad = String.Empty
                            '        objAsiento.nombreEntidad = String.Empty
                            '        objAsiento.tipoEntidad = String.Empty
                            '        objAsiento.fechaProceso = DateTime.Now
                            '        objAsiento.codigoLibro = "8"
                            '        objAsiento.tipo = "D"
                            '        objAsiento.tipoAsiento = "ACCA"
                            '        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                            '        objAsiento.importeME = CDec(i.Record.GetValue("importeME"))


                            '        objAsiento.glosa = "Ingreso a centro de costo"
                            '        objAsiento.usuarioActualizacion = usuario.IDUsuario
                            '        objAsiento.fechaActualizacion = DateTime.Now

                            '        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                            '        objMovimiento = New movimiento With {
                            '          .cuenta = recurso.codigo,
                            '          .descripcion = recurso.nombreCosto,
                            '          .tipo = "H",
                            '          .monto = CDec(i.Record.GetValue("importeMN")),
                            '          .montoUSD = CDec(i.Record.GetValue("importeME")),
                            '          .usuarioActualizacion = usuario.IDUsuario,
                            '          .fechaActualizacion = DateTime.Now
                            '      }
                            '        objAsiento.movimiento.Add(objMovimiento)


                            '        objMovimiento = New movimiento With {
                            '            .cuenta = "791",
                            '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                            '            .tipo = "D",
                            '            .monto = CDec(i.Record.GetValue("importeMN")),
                            '            .montoUSD = CDec(i.Record.GetValue("importeME")),
                            '            .usuarioActualizacion = usuario.IDUsuario,
                            '            .fechaActualizacion = DateTime.Now
                            '        }
                            '        objAsiento.movimiento.Add(objMovimiento)

                            '        listaAsiento.Add(objAsiento)

                            '        obj = New recursoCostoDetalle With {
                            '                    .idCosto = recurso.idCosto,
                            '                    .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                            '                    .iditem = Val(i.Record.GetValue("idItem")),
                            '                    .descripcion = i.Record.GetValue("descripcionItem"),
                            '                    .montoMN = CDec(i.Record.GetValue("importeMN")) * -1,
                            '                    .montoME = CDec(i.Record.GetValue("importeME")) * -1,
                            '                    .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                            '                    .itemRef = CInt(i.Record.GetValue("secuencia")),
                            '                    .operacion = i.Record.GetValue("TipoOperacion"),
                            '                    .procesado = "N",
                            '                    .idProceso = Nothing,
                            '                .recursoCosto = New recursoCosto With
                            '                                {
                            '        .subtipo = i.Record.GetValue("tipoCosto")
                            '                                }
                            '                }
                            '        Lista.Add(obj)

                            '        '////
                            '    Case Else
                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"

                            If i.Record.GetValue("importeMN") < 0 Then
                                objAsiento.importeMN = CDec(i.Record.GetValue("importeMN")) * -1
                                objAsiento.importeME = CDec(i.Record.GetValue("importeME")) * -1
                            Else
                                objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                                objAsiento.importeME = CDec(i.Record.GetValue("importeME"))
                            End If


                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                            If i.Record.GetValue("importeMN") > 0 Then
                                objMovimiento = New movimiento With {
                                  .cuenta = recurso.codigo,
                                  .descripcion = recurso.nombreCosto,
                                  .tipo = "D",
                                  .monto = CDec(i.Record.GetValue("importeMN")),
                                  .montoUSD = CDec(i.Record.GetValue("importeME")),
                                  .usuarioActualizacion = usuario.IDUsuario,
                                  .fechaActualizacion = DateTime.Now
                              }
                                objAsiento.movimiento.Add(objMovimiento)


                                objMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("importeMN")),
                                    .montoUSD = CDec(i.Record.GetValue("importeME")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)
                                'SI ES NEGATIVO
                            Else
                                objMovimiento = New movimiento With {
                                 .cuenta = recurso.codigo,
                                 .descripcion = recurso.nombreCosto,
                                 .tipo = "D",
                                 .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                 .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                 .usuarioActualizacion = usuario.IDUsuario,
                                 .fechaActualizacion = DateTime.Now
                             }
                                objAsiento.movimiento.Add(objMovimiento)


                                objMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                                    .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)
                            End If
                            listaAsiento.Add(objAsiento)

                            obj = New recursoCostoDetalle With {
                                        .idCosto = recurso.idCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("cuenta")),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .montoMN = CDec(i.Record.GetValue("importeMN")),
                                        .montoME = CDec(i.Record.GetValue("importeME")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = Nothing,
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                            Lista.Add(obj)
                    End Select
                    'hasta aqui


                    'End Select


                Next





            End If


            costoSA.GrabarDetalleRecursosLibro(Lista, listaAsiento)
            'GetItemsNoAsignados()
            'GetItemsNoAsignadosInventario()
            'GetItemsNoAsignadosFinanzas()
            GetItemsAsientosNoAsignados()
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RegistrarItemsAsignados()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA
        Dim codigoCosto As Integer
        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)



            If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
                For Each i As SelectedRecord In dgvItemsNoasignados.Table.SelectedRecords

                    Select Case i.Record.GetValue("abrev")
                        Case "HC"
                            'validando edt seleccionado
                            Dim valEdt = i.Record.GetValue("edt")
                            If IsNothing(valEdt) Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            If valEdt.ToString.Trim.Length <= 0 Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If


                            If i.Record.GetValue("abrev") = "HC" Then ' rbHojaCosto.Checked = True Then
                                codigoCosto = i.Record.GetValue("idElemento") ' cboElemento.SelectedValue
                            Else 'If rbHojaGasto.Checked = True Then
                                codigoCosto = i.Record.GetValue("idSubProyecto") 'i.record.getvalue("idSubProyecto")
                            End If

                            objDetalleCompra = New documentocompradetalle

                            Select Case i.Record.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO
                                    objDetalleCompra = ValidaNotaByReferencia(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra"))

                                    If IsNothing(obj) Then
                                        Throw New Exception("Debe asignar primero el comprobante padre!")
                                    End If

                                Case Else

                            End Select


                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"
                            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            Select Case i.Record.GetValue("tipoCosto") 'i.record.getvalue("tipoCosto")
                                Case TipoCosto.Proyecto,
                                    TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES,
                                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS

                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})

                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                            '  objMovimiento = New movimiento With {
                                            '     .cuenta = "91",
                                            '     .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '     .tipo = "D",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            '  objAsiento.movimiento.Add(objMovimiento)

                                            '  objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            '  objAsiento.movimiento.Add(objMovimiento)

                                            '-----------------------------------------------------------------------------


                                            objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                              .cuenta = recurso.codigo,
                                              .descripcion = recurso.nombreCosto,
                                              .tipo = "H",
                                              .monto = CDec(i.Record.GetValue("montokardex")),
                                              .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                              .usuarioActualizacion = usuario.IDUsuario,
                                              .fechaActualizacion = DateTime.Now
                                          }
                                            objAsiento.movimiento.Add(objMovimiento)


                                        Case Else

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select
                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.OrdenProduccion,
                                    TipoCosto.OP_CONTINUA_DE_BIENES,
                                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                            '   objMovimiento = New movimiento With {
                                            '    .cuenta = "79",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            '   objAsiento.movimiento.Add(objMovimiento)

                                            '   objMovimiento = New movimiento With {
                                            '     .cuenta = "91",
                                            '     .descripcion = recurso.nombreCosto,
                                            '     .tipo = "H",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            '   objAsiento.movimiento.Add(objMovimiento)

                                            '-----------------------------------------------------------------------------


                                            objMovimiento = New movimiento With {
                                              .cuenta = "7131",
                                              .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                              .tipo = "D",
                                              .monto = CDec(i.Record.GetValue("montokardex")),
                                              .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                              .usuarioActualizacion = usuario.IDUsuario,
                                              .fechaActualizacion = DateTime.Now
                                          }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                               .cuenta = "231",
                                               .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                               .tipo = "H",
                                               .monto = CDec(i.Record.GetValue("montokardex")),
                                               .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                               .usuarioActualizacion = usuario.IDUsuario,
                                               .fechaActualizacion = DateTime.Now
                                           }
                                            objAsiento.movimiento.Add(objMovimiento)


                                        Case Else

                                            ' objMovimiento = New movimiento With {
                                            '     .cuenta = "791",
                                            '     .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            '     .tipo = "D",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            ' objAsiento.movimiento.Add(objMovimiento)


                                            ' objMovimiento = New movimiento With {
                                            '    .cuenta = "91",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            ' objAsiento.movimiento.Add(objMovimiento)

                                            '----------------------------------------------------------------------


                                            objMovimiento = New movimiento With {
                                                .cuenta = "231",
                                                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7131",
                                                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.ActivoFijo
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})
                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7225",
                                                .descripcion = "EQUIPOS DIVERSOS",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)


                                        Case Else

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7225",
                                                .descripcion = "EQUIPOS DIVERSOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})


                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO
                                            objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)


                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                        Case Else

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            '.cuenta = "791",
                                            '.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            objMovimiento = New movimiento With {
                                              .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)
                                    End Select



                                    listaAsiento.Add(objAsiento)
                            End Select



                            Select Case i.Record.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO
                                    obj = New recursoCostoDetalle With {
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .idCosto = codigoCosto,
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                        .procesado = "N",
                                        .recursoCosto = New recursoCosto With
                                                        {
                                                            .subtipo = i.Record.GetValue("tipoCosto")
                                                        }
                                    }
                                    Lista.Add(obj)

                                Case Else


                                    obj = New recursoCostoDetalle With {
                                        .idCosto = codigoCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                                    Lista.Add(obj)
                            End Select


                        Case "HG"
                            'martin
                            Select Case i.Record.GetValue("TipoDoc")
                                Case "07"
                                    'martin
                                    objAsiento = New asiento
                                    objAsiento.periodo = PeriodoGeneral
                                    objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                                    objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                                    objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                                    objAsiento.idDocumentoRef = Nothing
                                    objAsiento.idAlmacen = 0
                                    objAsiento.nombreAlmacen = String.Empty
                                    objAsiento.idEntidad = String.Empty
                                    objAsiento.nombreEntidad = String.Empty
                                    objAsiento.tipoEntidad = String.Empty
                                    objAsiento.fechaProceso = DateTime.Now
                                    objAsiento.codigoLibro = "8"
                                    objAsiento.tipo = "D"
                                    objAsiento.tipoAsiento = "ACCA"
                                    objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                                    objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                                    objAsiento.glosa = "Ingreso a centro de costo"
                                    objAsiento.usuarioActualizacion = usuario.IDUsuario
                                    objAsiento.fechaActualizacion = DateTime.Now

                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                                    objMovimiento = New movimiento With {
                                      .cuenta = recurso.codigo,
                                      .descripcion = recurso.nombreCosto,
                                      .tipo = "H",
                                      .monto = CDec(i.Record.GetValue("montokardex")),
                                      .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                                    objAsiento.movimiento.Add(objMovimiento)


                                    objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "D",
                                        .monto = CDec(i.Record.GetValue("montokardex")),
                                        .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    objAsiento.movimiento.Add(objMovimiento)

                                    listaAsiento.Add(objAsiento)

                                    obj = New recursoCostoDetalle With {
                                                .idCosto = recurso.idCosto,
                                                .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                                .iditem = Val(i.Record.GetValue("idItem")),
                                                .destino = i.Record.GetValue("destino"),
                                                .descripcion = i.Record.GetValue("descripcionItem"),
                                                .um = i.Record.GetValue("unidad1"),
                                                .cant = CDec(i.Record.GetValue("monto1")),
                                                .puMN = 0,
                                                .puME = 0,
                                                .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
                                                .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
                                                .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                                .itemRef = CInt(i.Record.GetValue("secuencia")),
                                                .operacion = i.Record.GetValue("TipoOperacion"),
                                                .procesado = "N",
                                                .idProceso = Nothing,
                                            .recursoCosto = New recursoCosto With
                                                            {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                            }
                                            }
                                    Lista.Add(obj)

                                    '////
                                Case Else
                                    objAsiento = New asiento
                                    objAsiento.periodo = PeriodoGeneral
                                    objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                                    objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                                    objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                                    objAsiento.idDocumentoRef = Nothing
                                    objAsiento.idAlmacen = 0
                                    objAsiento.nombreAlmacen = String.Empty
                                    objAsiento.idEntidad = String.Empty
                                    objAsiento.nombreEntidad = String.Empty
                                    objAsiento.tipoEntidad = String.Empty
                                    objAsiento.fechaProceso = DateTime.Now
                                    objAsiento.codigoLibro = "8"
                                    objAsiento.tipo = "D"
                                    objAsiento.tipoAsiento = "ACCA"
                                    objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                                    objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                                    objAsiento.glosa = "Ingreso a centro de costo"
                                    objAsiento.usuarioActualizacion = usuario.IDUsuario
                                    objAsiento.fechaActualizacion = DateTime.Now

                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                                    objMovimiento = New movimiento With {
                                      .cuenta = recurso.codigo,
                                      .descripcion = recurso.nombreCosto,
                                      .tipo = "D",
                                      .monto = CDec(i.Record.GetValue("montokardex")),
                                      .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                                    objAsiento.movimiento.Add(objMovimiento)


                                    objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "H",
                                        .monto = CDec(i.Record.GetValue("montokardex")),
                                        .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    objAsiento.movimiento.Add(objMovimiento)

                                    listaAsiento.Add(objAsiento)

                                    obj = New recursoCostoDetalle With {
                                                .idCosto = recurso.idCosto,
                                                .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                                .iditem = Val(i.Record.GetValue("idItem")),
                                                .destino = i.Record.GetValue("destino"),
                                                .descripcion = i.Record.GetValue("descripcionItem"),
                                                .um = i.Record.GetValue("unidad1"),
                                                .cant = CDec(i.Record.GetValue("monto1")),
                                                .puMN = 0,
                                                .puME = 0,
                                                .montoMN = CDec(i.Record.GetValue("montokardex")),
                                                .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                                .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                                .itemRef = CInt(i.Record.GetValue("secuencia")),
                                                .operacion = i.Record.GetValue("TipoOperacion"),
                                                .procesado = "N",
                                                .idProceso = Nothing,
                                            .recursoCosto = New recursoCosto With
                                                            {
                                            .subtipo = i.Record.GetValue("tipoCosto")
                                                            }
                                            }
                                    Lista.Add(obj)
                            End Select
                            'hasta aqui


                    End Select


                Next

            ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then
                'FINANZAS
                '--------------------------------------------------------------------------------------------
                For Each i As SelectedRecord In dgFinanzas.Table.SelectedRecords

                    Select Case i.Record.GetValue("abrev")
                        Case "HC"
                            'validando edt seleccionado
                            Dim valEdt = i.Record.GetValue("edt")
                            If IsNothing(valEdt) Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            If valEdt.ToString.Trim.Length <= 0 Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If


                            If i.Record.GetValue("abrev") = "HC" Then ' rbHojaCosto.Checked = True Then
                                codigoCosto = i.Record.GetValue("idElemento") ' cboElemento.SelectedValue
                            Else 'If rbHojaGasto.Checked = True Then
                                codigoCosto = i.Record.GetValue("idSubProyecto") 'i.record.getvalue("idSubProyecto")
                            End If

                            objDetalleCompra = New documentocompradetalle

                            Select Case i.Record.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO
                                    objDetalleCompra = ValidaNotaByReferencia(dgFinanzas.Table.CurrentRecord.GetValue("idPadreDTCompra"))

                                    If IsNothing(obj) Then
                                        Throw New Exception("Debe asignar primero el comprobante padre!")
                                    End If

                                Case Else

                            End Select


                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"
                            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            Select Case i.Record.GetValue("tipoCosto") 'i.record.getvalue("tipoCosto")
                                Case TipoCosto.Proyecto,
                                    TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES,
                                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS

                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})

                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                            '  objMovimiento = New movimiento With {
                                            '     .cuenta = "91",
                                            '     .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '     .tipo = "D",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            '  objAsiento.movimiento.Add(objMovimiento)

                                            '  objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            '  objAsiento.movimiento.Add(objMovimiento)

                                            '  '-----------------------------------------------------------------------------


                                            '  objMovimiento = New movimiento With {
                                            '      .cuenta = "791",
                                            '      .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            '      .tipo = "D",
                                            '      .monto = CDec(i.Record.GetValue("montokardex")),
                                            '      .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '      .usuarioActualizacion = usuario.IDUsuario,
                                            '      .fechaActualizacion = DateTime.Now
                                            '  }
                                            '  objAsiento.movimiento.Add(objMovimiento)

                                            '  objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            '  objAsiento.movimiento.Add(objMovimiento)


                                        Case Else

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select
                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.OrdenProduccion,
                                    TipoCosto.OP_CONTINUA_DE_BIENES,
                                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                            '  objMovimiento = New movimiento With {
                                            '    .cuenta = "7111",
                                            '    .descripcion = "PRODUCTOS MANUFACTURADOS",
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            '  objAsiento.movimiento.Add(objMovimiento)

                                            '  objMovimiento = New movimiento With {
                                            '     .cuenta = "231",
                                            '     .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                            '     .tipo = "H",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            '  objAsiento.movimiento.Add(objMovimiento)


                                        Case Else

                                            ' objMovimiento = New movimiento With {
                                            '     .cuenta = "791",
                                            '     .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            '     .tipo = "D",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            ' objAsiento.movimiento.Add(objMovimiento)


                                            ' objMovimiento = New movimiento With {
                                            '    .cuenta = "91",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            ' objAsiento.movimiento.Add(objMovimiento)

                                            '----------------------------------------------------------------------


                                            objMovimiento = New movimiento With {
                                                .cuenta = "231",
                                                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7111",
                                                .descripcion = "PRODUCTOS MANUFACTURADOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.ActivoFijo
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")})
                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = "7225",
                                            '    .descripcion = "EQUIPOS DIVERSOS",
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)


                                        Case Else

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7225",
                                                .descripcion = "EQUIPOS DIVERSOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})


                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO
                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = "791",
                                            '    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)


                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                        Case Else

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            '.cuenta = "791",
                                            '.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            objMovimiento = New movimiento With {
                                              .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)
                                    End Select



                                    listaAsiento.Add(objAsiento)
                            End Select



                            Select Case i.Record.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO
                                    'obj = New recursoCostoDetalle With {
                                    '    .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                    '    .idCosto = codigoCosto,
                                    '    .iditem = Val(i.Record.GetValue("idItem")),
                                    '    .destino = i.Record.GetValue("destino"),
                                    '    .descripcion = i.Record.GetValue("descripcionItem"),
                                    '    .um = i.Record.GetValue("unidad1"),
                                    '    .cant = CDec(i.Record.GetValue("monto1")),
                                    '    .puMN = 0,
                                    '    .puME = 0,
                                    '    .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
                                    '    .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
                                    '    .documentoRef = i.Record.GetValue("idDocumento"),
                                    '    .itemRef = i.Record.GetValue("secuencia"),
                                    '    .operacion = i.Record.GetValue("TipoOperacion"),
                                    '    .idProceso = i.Record.GetValue("idEDT"),
                                    '    .procesado = "N",
                                    '    .recursoCosto = New recursoCosto With
                                    '                    {
                                    '                        .subtipo = i.Record.GetValue("tipoCosto")
                                    '                    }
                                    '}
                                    'Lista.Add(obj)

                                Case Else


                                    obj = New recursoCostoDetalle With {
                                        .idCosto = codigoCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                                    Lista.Add(obj)
                            End Select


                        Case "HG"
                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"
                            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                            objMovimiento = New movimiento With {
                              .cuenta = recurso.codigo,
                              .descripcion = recurso.nombreCosto,
                              .tipo = "D",
                              .monto = CDec(i.Record.GetValue("montokardex")),
                              .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                              .usuarioActualizacion = usuario.IDUsuario,
                              .fechaActualizacion = DateTime.Now
                          }
                            objAsiento.movimiento.Add(objMovimiento)


                            objMovimiento = New movimiento With {
                                .cuenta = "791",
                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                .tipo = "H",
                                .monto = CDec(i.Record.GetValue("montokardex")),
                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                            objAsiento.movimiento.Add(objMovimiento)

                            listaAsiento.Add(objAsiento)

                            obj = New recursoCostoDetalle With {
                                        .idCosto = recurso.idCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = Nothing,
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                            Lista.Add(obj)

                    End Select


                Next

            Else
                'INVENTARIO PENDIENTE DE ENVIO
                '-----------------------------------------------------------

                For Each i As SelectedRecord In GridGroupingControl1.Table.SelectedRecords
                    Select Case i.Record.GetValue("abrev")
                        Case "HC"
                            'validando edt seleccionado
                            Dim valEdt = i.Record.GetValue("edt")
                            If IsNothing(valEdt) Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            If valEdt.ToString.Trim.Length <= 0 Then
                                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"
                            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))

                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            Select Case i.Record.GetValue("tipoCosto") 'i.record.getvalue("tipoCosto")
                                Case TipoCosto.Proyecto,
                                    TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES,
                                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS

                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")}) ' cboElemento.SelectedValue

                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO


                                        Case Else

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = "791",
                                            '    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            '------------------------------------------------------------------------------

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select
                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.OrdenProduccion,
                                    TipoCosto.OP_CONTINUA_DE_BIENES,
                                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE,
                                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO


                                        Case Else

                                            ' objMovimiento = New movimiento With {
                                            '     .cuenta = "791",
                                            '     .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                            '     .tipo = "D",
                                            '     .monto = CDec(i.Record.GetValue("montokardex")),
                                            '     .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '     .usuarioActualizacion = usuario.IDUsuario,
                                            '     .fechaActualizacion = DateTime.Now
                                            ' }
                                            ' objAsiento.movimiento.Add(objMovimiento)


                                            ' objMovimiento = New movimiento With {
                                            '    .cuenta = "91",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            ' objAsiento.movimiento.Add(objMovimiento)

                                            '----------------------------------------------------------------------

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = "91",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            ''---------------------------------------------------------------


                                            objMovimiento = New movimiento With {
                                                .cuenta = "231",
                                                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7111",
                                                .descripcion = "PRODUCTOS MANUFACTURADOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.ActivoFijo
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idElemento")}) 'cboElemento.SelectedValue})
                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO



                                        Case Else

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = "91",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            '------------------------------------------------------------------

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "7225",
                                                .descripcion = "EQUIPOS DIVERSOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                    End Select

                                    listaAsiento.Add(objAsiento)

                                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
                                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")}) ' i.record.getvalue("idSubProyecto")})


                                    Select Case i.Record.GetValue("TipoDoc")
                                        Case "07" 'NOTA DE CREDITO

                                        Case Else

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = recurso.codigo,
                                            '    .descripcion = recurso.nombreCosto,
                                            '    .tipo = "D",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            'objMovimiento = New movimiento With {
                                            '    .cuenta = "91",
                                            '    .descripcion = "COSTOS POR DISTRIBUIR.",
                                            '    .tipo = "H",
                                            '    .monto = CDec(i.Record.GetValue("montokardex")),
                                            '    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                            '    .usuarioActualizacion = usuario.IDUsuario,
                                            '    .fechaActualizacion = DateTime.Now
                                            '}
                                            'objAsiento.movimiento.Add(objMovimiento)

                                            '-------------------------------------------------------------

                                            objMovimiento = New movimiento With {
                                                .cuenta = recurso.codigo,
                                                .descripcion = recurso.nombreCosto,
                                                .tipo = "D",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)

                                            objMovimiento = New movimiento With {
                                                .cuenta = "791",
                                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                                .tipo = "H",
                                                .monto = CDec(i.Record.GetValue("montokardex")),
                                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                                .usuarioActualizacion = usuario.IDUsuario,
                                                .fechaActualizacion = DateTime.Now
                                            }
                                            objAsiento.movimiento.Add(objMovimiento)
                                    End Select



                                    listaAsiento.Add(objAsiento)
                            End Select



                            Select Case i.Record.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO
                                    'obj = New recursoCostoDetalle With {
                                    '    .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                    '    .idCosto = codigoCosto,
                                    '    .iditem = Val(i.Record.GetValue("idItem")),
                                    '    .destino = i.Record.GetValue("destino"),
                                    '    .descripcion = i.Record.GetValue("descripcionItem"),
                                    '    .um = i.Record.GetValue("unidad1"),
                                    '    .cant = CDec(i.Record.GetValue("monto1")),
                                    '    .puMN = 0,
                                    '    .puME = 0,
                                    '    .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
                                    '    .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
                                    '    .documentoRef = i.Record.GetValue("idDocumento"),
                                    '    .itemRef = i.Record.GetValue("secuencia"),
                                    '    .operacion = i.Record.GetValue("TipoOperacion"),
                                    '    .idProceso = i.record.getvalue("idEDT"),
                                    '    .procesado = "N",
                                    '    .recursoCosto = New recursoCosto With
                                    '                    {
                                    '                        .subtipo =i.record.getvalue("tipoCosto")
                                    '                    }
                                    '}
                                    'Lista.Add(obj)

                                Case Else
                                    If i.Record.GetValue("abrev") = "HC" Then
                                        codigoCosto = i.Record.GetValue("idElemento") ' cboElemento.SelectedValue
                                    Else 'If rbHojaGasto.Checked = True Then
                                        codigoCosto = i.Record.GetValue("idSubProyecto") '  i.record.getvalue("idSubProyecto")
                                    End If

                                    obj = New recursoCostoDetalle With {
                                        .idCosto = codigoCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                                    Lista.Add(obj)
                            End Select


                        Case "HG"


                            objAsiento = New asiento
                            objAsiento.periodo = PeriodoGeneral
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                            objAsiento.idDocumentoRef = Nothing
                            objAsiento.idAlmacen = 0
                            objAsiento.nombreAlmacen = String.Empty
                            objAsiento.idEntidad = String.Empty
                            objAsiento.nombreEntidad = String.Empty
                            objAsiento.tipoEntidad = String.Empty
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.codigoLibro = "8"
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = "ACCA"
                            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                            objAsiento.glosa = "Ingreso a centro de costo"
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = DateTime.Now

                            recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idSubProyecto")})

                            objMovimiento = New movimiento With {
                              .cuenta = recurso.codigo,
                              .descripcion = recurso.nombreCosto,
                              .tipo = "D",
                              .monto = CDec(i.Record.GetValue("montokardex")),
                              .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                              .usuarioActualizacion = usuario.IDUsuario,
                              .fechaActualizacion = DateTime.Now
                          }
                            objAsiento.movimiento.Add(objMovimiento)


                            objMovimiento = New movimiento With {
                                .cuenta = "791",
                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                .tipo = "H",
                                .monto = CDec(i.Record.GetValue("montokardex")),
                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now
                            }
                            objAsiento.movimiento.Add(objMovimiento)

                            listaAsiento.Add(objAsiento)

                            obj = New recursoCostoDetalle With {
                                        .idCosto = recurso.idCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = Nothing,
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                            Lista.Add(obj)

                    End Select

                Next


            End If


            costoSA.GrabarDetalleRecursos(Lista, listaAsiento)
            GetItemsNoAsignados()
            GetItemsNoAsignadosInventario()
            GetItemsNoAsignadosFinanzas()
            GetItemsAsientosNoAsignados()
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



#End Region

    Private Sub frmAlertaCostos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAlertaCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboCostoDestino_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvItemsNoasignados) Then
            Select Case dgvItemsNoasignados.Table.CurrentRecord.GetValue("TipoDoc")
                Case "07", "08"
                    Dim f As New frmInfoCosto(Val(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case Else

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If dgvItemsNoasignados.Table.Records.Count > 0 Then
                If dgvItemsNoasignados.Table.SelectedRecords.Count > 0 Then

                    '    If cboCostoDestino.Text.Trim.Length > 0 Then
                    ' If cboProceso.Text.Trim.Length > 0 Then
                    RegistrarItemsAsignados()

                    '  GetCountItemsNoAsignados()
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el EDT de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                Else
                    MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else


            If GridGroupingControl1.Table.Records.Count > 0 Then
                If GridGroupingControl1.Table.SelectedRecords.Count > 0 Then

                    '    If cboCostoDestino.Text.Trim.Length > 0 Then
                    '     If cboProceso.Text.Trim.Length > 0 Then
                    RegistrarItemsAsignados()

                    '  GetCountItemsNoAsignados()
                    'Else
                    '    MessageBox.Show("Debe seleccionar el EDT de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'End If
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                Else
                    MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim r As Record = GridGroupingControl1.Table.CurrentRecord
        If Not IsNothing(r) Then

            Select Case GridGroupingControl1.Table.SelectedRecords.Count
                Case 1
                    Dim codProy = r.GetValue("idCosto")

                    If Not IsNothing(codProy) Then
                        If codProy.ToString.Trim.Length > 0 Then
                            Dim f As New frmSeleccionarEDT(CInt(r.GetValue("idCosto")))
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        Else

                            Dim f As New frmSeleccionarEDT()
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        End If
                    Else
                        Dim f As New frmSeleccionarEDT()
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, SeleccionCosto)
                            r.SetValue("idSubProyecto", c.idSubProyecto)
                            r.SetValue("Subproyecto", c.SubProyecto)
                            r.SetValue("idEDT", c.idEntregable)
                            r.SetValue("edt", c.Entregable)
                            r.SetValue("idCosto", c.idProyectoGeneral)
                            r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            r.SetValue("tipoCosto", c.TipoCosto)
                            r.SetValue("idElemento", c.idElemento)
                            r.SetValue("Elemento", c.ElementoCosto)
                            r.SetValue("abrev", c.Abreviatura)
                        End If
                    End If



                Case Else
                    Dim f As New frmSeleccionarEDT()
                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, SeleccionCosto)
                        For Each rec As SelectedRecord In GridGroupingControl1.Table.SelectedRecords
                            rec.Record.SetValue("idSubProyecto", c.idSubProyecto)
                            rec.Record.SetValue("Subproyecto", c.SubProyecto)
                            rec.Record.SetValue("idEDT", c.idEntregable)
                            rec.Record.SetValue("edt", c.Entregable)
                            rec.Record.SetValue("idCosto", c.idProyectoGeneral)
                            rec.Record.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            rec.Record.SetValue("tipoCosto", c.TipoCosto)
                            rec.Record.SetValue("idElemento", c.idElemento)
                            rec.Record.SetValue("Elemento", c.ElementoCosto)
                            rec.Record.SetValue("abrev", c.Abreviatura)
                        Next
                    End If
            End Select


        End If

    End Sub

    Private Sub Panel19_Paint(sender As Object, e As PaintEventArgs) Handles Panel19.Paint

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click

    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim r As Record = dgvItemsNoasignados.Table.CurrentRecord
        If Not IsNothing(r) Then

            Select Case dgvItemsNoasignados.Table.SelectedRecords.Count
                Case 1
                    Dim codProy = r.GetValue("idCosto")

                    If Not IsNothing(codProy) Then
                        If codProy.ToString.Trim.Length > 0 Then
                            Dim f As New frmSeleccionarEDT(CInt(r.GetValue("idCosto")))
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        Else

                            Dim f As New frmSeleccionarEDT()
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        End If
                    Else
                        Dim f As New frmSeleccionarEDT()
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, SeleccionCosto)
                            r.SetValue("idSubProyecto", c.idSubProyecto)
                            r.SetValue("Subproyecto", c.SubProyecto)
                            r.SetValue("idEDT", c.idEntregable)
                            r.SetValue("edt", c.Entregable)
                            r.SetValue("idCosto", c.idProyectoGeneral)
                            r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            r.SetValue("tipoCosto", c.TipoCosto)
                            r.SetValue("idElemento", c.idElemento)
                            r.SetValue("Elemento", c.ElementoCosto)
                            r.SetValue("abrev", c.Abreviatura)
                        End If
                    End If



                Case Else
                    Dim f As New frmSeleccionarEDT()
                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, SeleccionCosto)
                        For Each rec As SelectedRecord In dgvItemsNoasignados.Table.SelectedRecords
                            rec.Record.SetValue("idSubProyecto", c.idSubProyecto)
                            rec.Record.SetValue("Subproyecto", c.SubProyecto)
                            rec.Record.SetValue("idEDT", c.idEntregable)
                            rec.Record.SetValue("edt", c.Entregable)
                            rec.Record.SetValue("idCosto", c.idProyectoGeneral)
                            rec.Record.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            rec.Record.SetValue("tipoCosto", c.TipoCosto)
                            rec.Record.SetValue("idElemento", c.idElemento)
                            rec.Record.SetValue("Elemento", c.ElementoCosto)
                            rec.Record.SetValue("abrev", c.Abreviatura)
                        Next
                    End If
            End Select


        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If dgvItemsNoasignados.Table.Records.Count > 0 Then
                If dgvItemsNoasignados.Table.SelectedRecords.Count > 0 Then

                    '    If cboCostoDestino.Text.Trim.Length > 0 Then
                    ' If cboProceso.Text.Trim.Length > 0 Then
                    RegistrarItemsAsignados()

                    '  GetCountItemsNoAsignados()
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el EDT de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                Else
                    MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then
            If dgFinanzas.Table.Records.Count > 0 Then
                If dgFinanzas.Table.SelectedRecords.Count > 0 Then

                    '    If cboCostoDestino.Text.Trim.Length > 0 Then
                    ' If cboProceso.Text.Trim.Length > 0 Then
                    RegistrarItemsAsignados()

                    '  GetCountItemsNoAsignados()
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el EDT de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                Else
                    MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else


            If GridGroupingControl1.Table.Records.Count > 0 Then
                If GridGroupingControl1.Table.SelectedRecords.Count > 0 Then

                    '    If cboCostoDestino.Text.Trim.Length > 0 Then
                    '     If cboProceso.Text.Trim.Length > 0 Then
                    RegistrarItemsAsignados()

                    '  GetCountItemsNoAsignados()
                    'Else
                    '    MessageBox.Show("Debe seleccionar el EDT de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'End If
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                Else
                    MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim r As Record = dgvItemsNoasignados.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmSeleccionGasto()
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, SeleccionCosto)
                For Each rec As SelectedRecord In dgvItemsNoasignados.Table.SelectedRecords
                    rec.Record.SetValue("idSubProyecto", c.idGastoHijo)
                    rec.Record.SetValue("Subproyecto", c.GastoHijo)
                    rec.Record.SetValue("idEDT", Nothing)
                    rec.Record.SetValue("edt", Nothing)
                    rec.Record.SetValue("idCosto", Nothing)
                    rec.Record.SetValue("NombreProyectoGeneral", c.GastoPadre)
                    rec.Record.SetValue("tipoCosto", c.TipoCosto)
                    rec.Record.SetValue("idElemento", Nothing)
                    rec.Record.SetValue("Elemento", Nothing)
                    rec.Record.SetValue("abrev", c.Abreviatura)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Dim r As Record = dgFinanzas.Table.CurrentRecord
        If Not IsNothing(r) Then

            Select Case dgFinanzas.Table.SelectedRecords.Count
                Case 1
                    Dim codProy = r.GetValue("idCosto")

                    If Not IsNothing(codProy) Then
                        If codProy.ToString.Trim.Length > 0 Then
                            Dim f As New frmSeleccionarEDT(CInt(r.GetValue("idCosto")))
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        Else

                            Dim f As New frmSeleccionarEDT()
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        End If
                    Else
                        Dim f As New frmSeleccionarEDT()
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, SeleccionCosto)
                            r.SetValue("idSubProyecto", c.idSubProyecto)
                            r.SetValue("Subproyecto", c.SubProyecto)
                            r.SetValue("idEDT", c.idEntregable)
                            r.SetValue("edt", c.Entregable)
                            r.SetValue("idCosto", c.idProyectoGeneral)
                            r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            r.SetValue("tipoCosto", c.TipoCosto)
                            r.SetValue("idElemento", c.idElemento)
                            r.SetValue("Elemento", c.ElementoCosto)
                            r.SetValue("abrev", c.Abreviatura)
                        End If
                    End If



                Case Else
                    Dim f As New frmSeleccionarEDT()
                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, SeleccionCosto)
                        For Each rec As SelectedRecord In dgFinanzas.Table.SelectedRecords
                            rec.Record.SetValue("idSubProyecto", c.idSubProyecto)
                            rec.Record.SetValue("Subproyecto", c.SubProyecto)
                            rec.Record.SetValue("idEDT", c.idEntregable)
                            rec.Record.SetValue("edt", c.Entregable)
                            rec.Record.SetValue("idCosto", c.idProyectoGeneral)
                            rec.Record.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            rec.Record.SetValue("tipoCosto", c.TipoCosto)
                            rec.Record.SetValue("idElemento", c.idElemento)
                            rec.Record.SetValue("Elemento", c.ElementoCosto)
                            rec.Record.SetValue("abrev", c.Abreviatura)
                        Next
                    End If
            End Select


        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim r As Record = dgFinanzas.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmSeleccionGasto()
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, SeleccionCosto)
                For Each rec As SelectedRecord In dgFinanzas.Table.SelectedRecords
                    rec.Record.SetValue("idSubProyecto", c.idGastoHijo)
                    rec.Record.SetValue("Subproyecto", c.GastoHijo)
                    rec.Record.SetValue("idEDT", Nothing)
                    rec.Record.SetValue("edt", Nothing)
                    rec.Record.SetValue("idCosto", Nothing)
                    rec.Record.SetValue("NombreProyectoGeneral", c.GastoPadre)
                    rec.Record.SetValue("tipoCosto", c.TipoCosto)
                    rec.Record.SetValue("idElemento", Nothing)
                    rec.Record.SetValue("Elemento", Nothing)
                    rec.Record.SetValue("abrev", c.Abreviatura)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Cursor = Cursors.WaitCursor
        If dgFinanzas.Table.Records.Count > 0 Then
            If dgFinanzas.Table.SelectedRecords.Count > 0 Then
                RegistrarFinanzas()
            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        Dim r As Record = dgvAsientosNoAsignados.Table.CurrentRecord
        If Not IsNothing(r) Then

            Select Case dgvAsientosNoAsignados.Table.SelectedRecords.Count
                Case 1
                    Dim codProy = r.GetValue("idCosto")

                    If Not IsNothing(codProy) Then
                        If codProy.ToString.Trim.Length > 0 Then
                            Dim f As New frmSeleccionarEDT(CInt(r.GetValue("idCosto")))
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        Else

                            Dim f As New frmSeleccionarEDT()
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, SeleccionCosto)
                                r.SetValue("idSubProyecto", c.idSubProyecto)
                                r.SetValue("Subproyecto", c.SubProyecto)
                                r.SetValue("idEDT", c.idEntregable)
                                r.SetValue("edt", c.Entregable)
                                r.SetValue("idCosto", c.idProyectoGeneral)
                                r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                                r.SetValue("tipoCosto", c.TipoCosto)
                                r.SetValue("idElemento", c.idElemento)
                                r.SetValue("Elemento", c.ElementoCosto)
                                r.SetValue("abrev", c.Abreviatura)
                            End If

                        End If
                    Else
                        Dim f As New frmSeleccionarEDT()
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, SeleccionCosto)
                            r.SetValue("idSubProyecto", c.idSubProyecto)
                            r.SetValue("Subproyecto", c.SubProyecto)
                            r.SetValue("idEDT", c.idEntregable)
                            r.SetValue("edt", c.Entregable)
                            r.SetValue("idCosto", c.idProyectoGeneral)
                            r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            r.SetValue("tipoCosto", c.TipoCosto)
                            r.SetValue("idElemento", c.idElemento)
                            r.SetValue("Elemento", c.ElementoCosto)
                            r.SetValue("abrev", c.Abreviatura)
                        End If
                    End If



                Case Else
                    Dim f As New frmSeleccionarEDT()
                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, SeleccionCosto)
                        For Each rec As SelectedRecord In dgvAsientosNoAsignados.Table.SelectedRecords
                            rec.Record.SetValue("idSubProyecto", c.idSubProyecto)
                            rec.Record.SetValue("Subproyecto", c.SubProyecto)
                            rec.Record.SetValue("idEDT", c.idEntregable)
                            rec.Record.SetValue("edt", c.Entregable)
                            rec.Record.SetValue("idCosto", c.idProyectoGeneral)
                            rec.Record.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                            rec.Record.SetValue("tipoCosto", c.TipoCosto)
                            rec.Record.SetValue("idElemento", c.idElemento)
                            rec.Record.SetValue("Elemento", c.ElementoCosto)
                            rec.Record.SetValue("abrev", c.Abreviatura)
                        Next
                    End If
            End Select


        End If
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Dim r As Record = dgvAsientosNoAsignados.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmSeleccionGasto()
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, SeleccionCosto)
                For Each rec As SelectedRecord In dgvAsientosNoAsignados.Table.SelectedRecords
                    rec.Record.SetValue("idSubProyecto", c.idGastoHijo)
                    rec.Record.SetValue("Subproyecto", c.GastoHijo)
                    rec.Record.SetValue("idEDT", Nothing)
                    rec.Record.SetValue("edt", Nothing)
                    rec.Record.SetValue("idCosto", Nothing)
                    rec.Record.SetValue("NombreProyectoGeneral", c.GastoPadre)
                    rec.Record.SetValue("tipoCosto", c.TipoCosto)
                    rec.Record.SetValue("idElemento", Nothing)
                    rec.Record.SetValue("Elemento", Nothing)
                    rec.Record.SetValue("abrev", c.Abreviatura)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv4 Then
            If dgvAsientosNoAsignados.Table.Records.Count > 0 Then
                If dgvAsientosNoAsignados.Table.SelectedRecords.Count > 0 Then

                    '    If cboCostoDestino.Text.Trim.Length > 0 Then
                    ' If cboProceso.Text.Trim.Length > 0 Then
                    RegistrarItemsAsignadosLibro()

                    '  GetCountItemsNoAsignados()
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el EDT de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                    ''Else
                    ''    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''End If
                Else
                    MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click
        Dim r As Record = GridGroupingControl1.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmSeleccionGasto()
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, SeleccionCosto)
                For Each rec As SelectedRecord In GridGroupingControl1.Table.SelectedRecords
                    rec.Record.SetValue("idSubProyecto", c.idGastoHijo)
                    rec.Record.SetValue("Subproyecto", c.GastoHijo)
                    rec.Record.SetValue("idEDT", Nothing)
                    rec.Record.SetValue("edt", Nothing)
                    rec.Record.SetValue("idCosto", Nothing)
                    rec.Record.SetValue("NombreProyectoGeneral", c.GastoPadre)
                    rec.Record.SetValue("tipoCosto", c.TipoCosto)
                    rec.Record.SetValue("idElemento", Nothing)
                    rec.Record.SetValue("Elemento", Nothing)
                    rec.Record.SetValue("abrev", c.Abreviatura)
                Next
            End If
        End If
    End Sub
End Class