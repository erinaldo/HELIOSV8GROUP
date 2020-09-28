Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmCosteoCompras

#Region "Constructors"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'Me.WindowState = FormWindowState.Maximized
        GridCFGDetetail(dgvItemsNoasignados)
        ' GetProyectosGeneralesCMB()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

#Region "Metodos"

  





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

    Function ValidaNotaByReferencia(intIdDocumentoPadre As Integer) As documentocompradetalle
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim compra As New documentocompradetalle
        compra = compraSA.GetUbicar_documentocompradetallePorID(intIdDocumentoPadre)

        Return compra
    End Function

    Public Sub RegistrarItemsAsignadosAll()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA

        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Dim tipoDeCosteo As String = ""
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)


            For Each i As Record In dgvItemsNoasignados.Table.Records
                If CDec(i.GetValue("montouso")) > 0 Then

                    Select Case txtTipoCosteo.Text
                        Case "HC"

                            If CDec(i.GetValue("montosaldo")) = 0 Then
                                tipoDeCosteo = "HC"
                            Else
                                tipoDeCosteo = "PC"
                            End If

                            'validando edt seleccionado
                            'Dim valEdt = i.GetValue("edt")
                            'If IsNothing(valEdt) Then
                            '    MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            '    Exit Sub
                            'End If

                            'If valEdt.ToString.Trim.Length <= 0 Then
                            '    MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            '    Exit Sub
                            'End If


                            'If i.Record.GetValue("abrev") = "HC" Then ' rbHojaCosto.Checked = True Then
                            '    codigoCosto = i.Record.GetValue("idElemento") ' cboElemento.SelectedValue
                            'Else 'If rbHojaGasto.Checked = True Then
                            '    codigoCosto = i.Record.GetValue("idSubProyecto") 'i.record.getvalue("idSubProyecto")
                            'End If

                            objDetalleCompra = New documentocompradetalle

                            Select Case i.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO
                                    objDetalleCompra = ValidaNotaByReferencia(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra"))

                                    If IsNothing(obj) Then
                                        Throw New Exception("Debe asignar primero el comprobante padre!")
                                    End If

                                Case Else

                            End Select


                            Select Case i.GetValue("TipoDoc")
                                Case "07" 'NOTA DE CREDITO

                                    obj = New recursoCostoDetalle With {
                                        .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                        .idCosto = CInt(txtidEntregable.Text),
                                        .iditem = Val(i.GetValue("idItem")),
                                        .destino = i.GetValue("destino"),
                                        .descripcion = i.GetValue("descripcionItem"),
                                        .um = i.GetValue("unidad1"),
                                        .cant = CDec(i.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montouso")) * -1,
                                        .montoME = CDec(0.0),
                                        .documentoRef = CInt(i.GetValue("idDocumento")),
                                        .itemRef = CInt(i.GetValue("secuencia")),
                                        .operacion = i.GetValue("TipoOperacion"),
                                        .idProceso = CInt(txtidEntregable.Text),
                                        .procesado = "N",
                                         .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                        .elementoCosto = "CIFoci",
                                        .tipoCosto = tipoDeCosteo
                                    }
                                    Lista.Add(obj)

                                Case Else


                                    obj = New recursoCostoDetalle With {
                                        .idCosto = CInt(txtidEntregable.Text),
                                        .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                        .iditem = Val(i.GetValue("idItem")),
                                        .destino = i.GetValue("destino"),
                                        .descripcion = i.GetValue("descripcionItem"),
                                        .um = i.GetValue("unidad1"),
                                        .cant = CDec(i.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montouso")),
                                        .montoME = CDec(0.0),
                                        .documentoRef = CInt(i.GetValue("idDocumento")),
                                        .itemRef = CInt(i.GetValue("secuencia")),
                                        .operacion = i.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = CInt(txtidEntregable.Text),
                                        .Periodo = PeriodoGeneral,
                                        .elementoCosto = "CIFoci",
                                         .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                    .tipoCosto = tipoDeCosteo
                                    }
                                    Lista.Add(obj)
                            End Select

                            ''asientos segun tipo
                            If lblTipoProyecto.Text = "CPV" Then
                                objAsiento = New asiento
                                objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                                objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                                objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                                objAsiento.idEntidad = 0
                                objAsiento.nombreEntidad = "SIN IDENTIDAD"
                                objAsiento.tipoEntidad = "OT"
                                objAsiento.fechaProceso = DateTime.Now
                                objAsiento.periodo = txtPeriodo.Text
                                objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                                objAsiento.tipo = "D"
                                objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                                objAsiento.importeMN = CDec(i.GetValue("montouso"))
                                objAsiento.importeME = CDec(0.0)
                                objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                                objAsiento.usuarioActualizacion = usuario.IDUsuario
                                objAsiento.fechaActualizacion = Date.Now
                                listaAsiento.Add(objAsiento)

                                objMovimiento = New movimiento
                                objMovimiento.cuenta = "231"
                                objMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                                objMovimiento.tipo = "D"
                                objMovimiento.monto = CDec(i.GetValue("montouso"))
                                objMovimiento.montoUSD = CDec(0.0)
                                objMovimiento.usuarioActualizacion = usuario.IDUsuario
                                objMovimiento.fechaActualizacion = Date.Now
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento
                                objMovimiento.cuenta = "189"
                                objMovimiento.descripcion = "OTROS GASTOS CONTRATADOS POR ANTICIPADO"
                                objMovimiento.tipo = "H"
                                objMovimiento.monto = CDec(i.GetValue("montouso"))
                                objMovimiento.montoUSD = CDec(0.0)
                                objMovimiento.usuarioActualizacion = usuario.IDUsuario
                                objMovimiento.fechaActualizacion = Date.Now
                                objAsiento.movimiento.Add(objMovimiento)


                            ElseIf lblTipoProyecto.Text = "CPP" Then
                                objAsiento = New asiento
                                objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                                objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                                objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                                objAsiento.idEntidad = 0
                                objAsiento.nombreEntidad = "SIN IDENTIDAD"
                                objAsiento.tipoEntidad = "OT"
                                objAsiento.fechaProceso = DateTime.Now
                                objAsiento.periodo = txtPeriodo.Text
                                objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                                objAsiento.tipo = "D"
                                objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                                objAsiento.importeMN = CDec(i.GetValue("montouso"))
                                objAsiento.importeME = CDec(0.0)
                                objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                                objAsiento.usuarioActualizacion = usuario.IDUsuario
                                objAsiento.fechaActualizacion = Date.Now
                                listaAsiento.Add(objAsiento)

                                objMovimiento = New movimiento
                                objMovimiento.cuenta = "231"
                                objMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                                objMovimiento.tipo = "D"
                                objMovimiento.monto = CDec(i.GetValue("montouso"))
                                objMovimiento.montoUSD = CDec(0.0)
                                objMovimiento.usuarioActualizacion = usuario.IDUsuario
                                objMovimiento.fechaActualizacion = Date.Now
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento
                                objMovimiento.cuenta = "189"
                                objMovimiento.descripcion = "OTROS GASTOS CONTRATADOS POR ANTICIPADO"
                                objMovimiento.tipo = "H"
                                objMovimiento.monto = CDec(i.GetValue("montouso"))
                                objMovimiento.montoUSD = CDec(0.0)
                                objMovimiento.usuarioActualizacion = usuario.IDUsuario
                                objMovimiento.fechaActualizacion = Date.Now
                                objAsiento.movimiento.Add(objMovimiento)
                            ElseIf lblTipoProyecto.Text = "CPE" Then
                            End If
                           




                        Case "HG"

                            If CDec(i.GetValue("montosaldo")) = 0 Then
                                tipoDeCosteo = "HG"
                            Else
                                tipoDeCosteo = "PG"
                            End If

                            'martin
                            Select Case i.GetValue("TipoDoc")
                                Case "07"
                                    'martin
                                    'objAsiento = New asiento
                                    'objAsiento.periodo = PeriodoGeneral
                                    'objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                                    'objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                                    'objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                                    'objAsiento.idDocumentoRef = Nothing
                                    'objAsiento.idAlmacen = 0
                                    'objAsiento.nombreAlmacen = String.Empty
                                    'objAsiento.idEntidad = String.Empty
                                    'objAsiento.nombreEntidad = String.Empty
                                    'objAsiento.tipoEntidad = String.Empty
                                    'objAsiento.fechaProceso = DateTime.Now
                                    'objAsiento.codigoLibro = "8"
                                    'objAsiento.tipo = "D"
                                    'objAsiento.tipoAsiento = "ACCA"
                                    'objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                                    'objAsiento.importeME = CDec(i.GetValue("montokardexUS"))


                                    'objAsiento.glosa = "Ingreso a centro de costo"
                                    'objAsiento.usuarioActualizacion = usuario.IDUsuario
                                    'objAsiento.fechaActualizacion = DateTime.Now

                                    'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.GetValue("idEDT")})

                                    'objMovimiento = New movimiento With {
                                    '      .cuenta = i.GetValue("cuentaCosteo"),
                                    '      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                    '      .tipo = "H",
                                    '      .monto = CDec(i.GetValue("montokardex")),
                                    '      .montoUSD = CDec(i.GetValue("montokardexUS")),
                                    '      .usuarioActualizacion = usuario.IDUsuario,
                                    '      .fechaActualizacion = DateTime.Now
                                    '  }
                                    'objAsiento.movimiento.Add(objMovimiento)


                                    'objMovimiento = New movimiento With {
                                    '        .cuenta = "791",
                                    '        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    '        .tipo = "D",
                                    '        .monto = CDec(i.GetValue("montokardex")),
                                    '        .montoUSD = CDec(i.GetValue("montokardexUS")),
                                    '        .usuarioActualizacion = usuario.IDUsuario,
                                    '        .fechaActualizacion = DateTime.Now
                                    '    }
                                    'objAsiento.movimiento.Add(objMovimiento)

                                    'listaAsiento.Add(objAsiento)

                                    obj = New recursoCostoDetalle With {
                                                .idCosto = CInt(i.GetValue("idEDT")),
                                                .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                                .iditem = Val(i.GetValue("idItem")),
                                                .destino = i.GetValue("destino"),
                                                .descripcion = i.GetValue("descripcionItem"),
                                                .um = i.GetValue("unidad1"),
                                                .cant = CDec(i.GetValue("monto1")),
                                                .puMN = 0,
                                                .puME = 0,
                                                .montoMN = CDec(i.GetValue("montouso")) * -1,
                                                .montoME = CDec(0.0),
                                                .documentoRef = CInt(i.GetValue("idDocumento")),
                                                .itemRef = CInt(i.GetValue("secuencia")),
                                                .operacion = i.GetValue("TipoOperacion"),
                                                .procesado = "N",
                                                .idProceso = CInt(i.GetValue("idEDT")),
                                                .elementoCosto = "CIFoci",
                                        .Periodo = PeriodoGeneral,
                                         .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                    .tipoCosto = tipoDeCosteo
                                    }
                                    Lista.Add(obj)

                                    '////
                                Case Else

                                    'objAsiento = New asiento
                                    'objAsiento.periodo = PeriodoGeneral
                                    'objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                                    'objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                                    'objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                                    'objAsiento.idDocumentoRef = Nothing
                                    'objAsiento.idAlmacen = 0
                                    'objAsiento.nombreAlmacen = String.Empty
                                    'objAsiento.idEntidad = String.Empty
                                    'objAsiento.nombreEntidad = String.Empty
                                    'objAsiento.tipoEntidad = String.Empty
                                    'objAsiento.fechaProceso = DateTime.Now
                                    'objAsiento.codigoLibro = "8"
                                    'objAsiento.tipo = "D"
                                    'objAsiento.tipoAsiento = "ACCA"
                                    'objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                                    'objAsiento.importeME = CDec(i.GetValue("montokardexUS"))


                                    'objAsiento.glosa = "Ingreso a centro de costo"
                                    'objAsiento.usuarioActualizacion = usuario.IDUsuario
                                    'objAsiento.fechaActualizacion = DateTime.Now

                                    'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.GetValue("idEDT")})

                                    'objMovimiento = New movimiento With {
                                    '      .cuenta = i.GetValue("cuentaCosteo"),
                                    '      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                    '      .tipo = "H",
                                    '      .monto = CDec(i.GetValue("montokardex")),
                                    '      .montoUSD = CDec(i.GetValue("montokardexUS")),
                                    '      .usuarioActualizacion = usuario.IDUsuario,
                                    '      .fechaActualizacion = DateTime.Now
                                    '  }
                                    'objAsiento.movimiento.Add(objMovimiento)


                                    'objMovimiento = New movimiento With {
                                    '        .cuenta = "791",
                                    '        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    '        .tipo = "D",
                                    '        .monto = CDec(i.GetValue("montokardex")),
                                    '        .montoUSD = CDec(i.GetValue("montokardexUS")),
                                    '        .usuarioActualizacion = usuario.IDUsuario,
                                    '        .fechaActualizacion = DateTime.Now
                                    '    }
                                    'objAsiento.movimiento.Add(objMovimiento)

                                    'listaAsiento.Add(objAsiento)

                                    'obj = New recursoCostoDetalle With {
                                    '            .idCosto = CInt(i.GetValue("idEDT")),
                                    '            .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                    '            .iditem = Val(i.GetValue("idItem")),
                                    '            .destino = i.GetValue("destino"),
                                    '            .descripcion = i.GetValue("descripcionItem"),
                                    '            .um = i.GetValue("unidad1"),
                                    '            .cant = CDec(i.GetValue("monto1")),
                                    '            .puMN = 0,
                                    '            .puME = 0,
                                    '            .montoMN = CDec(i.GetValue("montokardex")) * -1,
                                    '            .montoME = CDec(i.GetValue("montokardexUS")) * -1,
                                    '            .documentoRef = CInt(i.GetValue("idDocumento")),
                                    '            .itemRef = CInt(i.GetValue("secuencia")),
                                    '            .operacion = i.GetValue("TipoOperacion"),
                                    '            .procesado = "N",
                                    '            .idProceso = CInt(i.GetValue("idEDT")),
                                    '    .Periodo = PeriodoGeneral,
                                    '     .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                    '.tipoCosto = "HG"
                                    '}
                                    'Lista.Add(obj)

                                    obj = New recursoCostoDetalle With {
                                                .idCosto = CInt(txtidEntregable.Text),
                                        .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                        .iditem = Val(i.GetValue("idItem")),
                                        .destino = i.GetValue("destino"),
                                        .descripcion = i.GetValue("descripcionItem"),
                                        .um = i.GetValue("unidad1"),
                                        .cant = CDec(i.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montouso")),
                                        .montoME = CDec(0.0),
                                        .documentoRef = CInt(i.GetValue("idDocumento")),
                                        .itemRef = CInt(i.GetValue("secuencia")),
                                        .operacion = i.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = CInt(txtidEntregable.Text),
                                        .Periodo = PeriodoGeneral,
                                        .elementoCosto = "CIFoci",
                                         .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                    .tipoCosto = tipoDeCosteo
                                    }
                                    Lista.Add(obj)
                            End Select
                            'hasta aqui
                    End Select
                End If
            Next




            costoSA.GrabarDetalleRecursos(Lista, listaAsiento)
            If txtTipoCosteo.Text = "HC" Then
                'GetItemsNoAsignadosEntregable(txtidEntregable.Text)
                ListaCompraDeServicios("PC")
            ElseIf txtTipoCosteo.Text = "HG" Then
                'ListaRecursosGastoEntregable(txtidEntregable.Text)
                ListaCompraDeServicios("PG")
            End If
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RegistrarItemsAsignados()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA

        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)


            'For Each i As SelectedRecord In dgvItemsNoasignados.Table.SelectedRecords

            '    Select Case i.Record.GetValue("abrev")
            '        Case "HC"
            '            'validando edt seleccionado
            '            Dim valEdt = i.Record.GetValue("edt")
            '            If IsNothing(valEdt) Then
            '                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                Exit Sub
            '            End If

            '            If valEdt.ToString.Trim.Length <= 0 Then
            '                MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                Exit Sub
            '            End If

            '            objDetalleCompra = New documentocompradetalle

            '            Select Case i.Record.GetValue("TipoDoc")
            '                Case "07" 'NOTA DE CREDITO
            '                    objDetalleCompra = ValidaNotaByReferencia(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra"))

            '                    If IsNothing(obj) Then
            '                        Throw New Exception("Debe asignar primero el comprobante padre!")
            '                    End If

            '                Case Else

            '            End Select


            '            Select Case i.Record.GetValue("TipoDoc")
            '                Case "07" 'NOTA DE CREDITO
            '                    obj = New recursoCostoDetalle With {
            '                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
            '                        .idCosto = CInt(i.Record.GetValue("idEDT")),
            '                        .iditem = Val(i.Record.GetValue("idItem")),
            '                        .destino = i.Record.GetValue("destino"),
            '                        .descripcion = i.Record.GetValue("descripcionItem"),
            '                        .um = i.Record.GetValue("unidad1"),
            '                        .cant = CDec(i.Record.GetValue("monto1")),
            '                        .puMN = 0,
            '                        .puME = 0,
            '                        .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
            '                        .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
            '                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
            '                        .itemRef = CInt(i.Record.GetValue("secuencia")),
            '                        .operacion = i.Record.GetValue("TipoOperacion"),
            '                        .idProceso = CInt(i.Record.GetValue("idEDT")),
            '                        .procesado = "N",
            '                         .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
            '                        .tipoCosto = "HC"
            '                    }
            '                    Lista.Add(obj)

            '                Case Else


            '                    obj = New recursoCostoDetalle With {
            '                        .idCosto = CInt(i.Record.GetValue("idEDT")),
            '                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
            '                        .iditem = Val(i.Record.GetValue("idItem")),
            '                        .destino = i.Record.GetValue("destino"),
            '                        .descripcion = i.Record.GetValue("descripcionItem"),
            '                        .um = i.Record.GetValue("unidad1"),
            '                        .cant = CDec(i.Record.GetValue("monto1")),
            '                        .puMN = 0,
            '                        .puME = 0,
            '                        .montoMN = CDec(i.Record.GetValue("montokardex")),
            '                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
            '                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
            '                        .itemRef = CInt(i.Record.GetValue("secuencia")),
            '                        .operacion = i.Record.GetValue("TipoOperacion"),
            '                        .procesado = "N",
            '                        .idProceso = CInt(i.Record.GetValue("idEDT")),
            '                        .Periodo = PeriodoGeneral,
            '                         .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
            '                    .tipoCosto = "HC"
            '                    }
            '                    Lista.Add(obj)
            '            End Select

            '            ' asientpo por tipo

            '            objAsiento = New asiento
            '            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            '            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            '            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
            '            objAsiento.idEntidad = 0
            '            objAsiento.nombreEntidad = "SIN IDENTIDAD"
            '            objAsiento.tipoEntidad = "OT"
            '            objAsiento.fechaProceso = DateTime.Now
            '            objAsiento.periodo = txtPeriodo.Text
            '            objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
            '            objAsiento.tipo = "D"
            '            objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
            '            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
            '            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))
            '            objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
            '            objAsiento.usuarioActualizacion = usuario.IDUsuario
            '            objAsiento.fechaActualizacion = Date.Now
            '            listaAsiento.Add(objAsiento)

            '            objMovimiento = New movimiento
            '            objMovimiento.cuenta = i.Record.GetValue("cuentaCosteo")
            '            objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
            '            objMovimiento.tipo = "D"
            '            objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
            '            objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
            '            objMovimiento.usuarioActualizacion = usuario.IDUsuario
            '            objMovimiento.fechaActualizacion = Date.Now
            '            objAsiento.movimiento.Add(objMovimiento)

            '            objMovimiento = New movimiento
            '            objMovimiento.cuenta = "791"
            '            objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
            '            objMovimiento.tipo = "H"
            '            objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
            '            objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
            '            objMovimiento.usuarioActualizacion = usuario.IDUsuario
            '            objMovimiento.fechaActualizacion = Date.Now
            '            objAsiento.movimiento.Add(objMovimiento)

            '            ''2
            '            objAsiento = New asiento
            '            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            '            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
            '            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            '            objAsiento.idEntidad = 0
            '            objAsiento.nombreEntidad = "SIN IDENTIDAD"
            '            objAsiento.tipoEntidad = "OT"
            '            objAsiento.fechaProceso = DateTime.Now
            '            objAsiento.periodo = txtPeriodo.Text
            '            objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
            '            objAsiento.tipo = "D"
            '            objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
            '            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
            '            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))
            '            objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
            '            objAsiento.usuarioActualizacion = usuario.IDUsuario
            '            objAsiento.fechaActualizacion = Date.Now
            '            listaAsiento.Add(objAsiento)

            '            objMovimiento = New movimiento
            '            objMovimiento.cuenta = "211"
            '            objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
            '            objMovimiento.tipo = "D"
            '            objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
            '            objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
            '            objMovimiento.usuarioActualizacion = usuario.IDUsuario
            '            objMovimiento.fechaActualizacion = Date.Now
            '            objAsiento.movimiento.Add(objMovimiento)

            '            objMovimiento = New movimiento
            '            objMovimiento.cuenta = "711"
            '            objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
            '            objMovimiento.tipo = "H"
            '            objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
            '            objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
            '            objMovimiento.usuarioActualizacion = usuario.IDUsuario
            '            objMovimiento.fechaActualizacion = Date.Now
            '            objAsiento.movimiento.Add(objMovimiento)

            '            ''3
            '            objAsiento = New asiento
            '            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            '            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            '            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
            '            objAsiento.idEntidad = 0
            '            objAsiento.nombreEntidad = "SIN IDENTIDAD"
            '            objAsiento.tipoEntidad = "OT"
            '            objAsiento.fechaProceso = DateTime.Now
            '            objAsiento.periodo = txtPeriodo.Text
            '            objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
            '            objAsiento.tipo = "D"
            '            objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
            '            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
            '            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))
            '            objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
            '            objAsiento.usuarioActualizacion = usuario.IDUsuario
            '            objAsiento.fechaActualizacion = Date.Now
            '            listaAsiento.Add(objAsiento)

            '            objMovimiento = New movimiento
            '            objMovimiento.cuenta = "694"
            '            objMovimiento.descripcion = "SERVICIOS"
            '            objMovimiento.tipo = "D"
            '            objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
            '            objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
            '            objMovimiento.usuarioActualizacion = usuario.IDUsuario
            '            objMovimiento.fechaActualizacion = Date.Now
            '            objAsiento.movimiento.Add(objMovimiento)

            '            objMovimiento = New movimiento
            '            objMovimiento.cuenta = "211"
            '            objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
            '            objMovimiento.tipo = "H"
            '            objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
            '            objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
            '            objMovimiento.usuarioActualizacion = usuario.IDUsuario
            '            objMovimiento.fechaActualizacion = Date.Now
            '            objAsiento.movimiento.Add(objMovimiento)



            '        Case "HG"

            '            'martin
            '            Select Case i.Record.GetValue("TipoDoc")
            '                Case "07"
            '                    'martin
            '                    objAsiento = New asiento
            '                    objAsiento.periodo = PeriodoGeneral
            '                    objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            '                    objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
            '                    objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            '                    objAsiento.idDocumentoRef = Nothing
            '                    objAsiento.idAlmacen = 0
            '                    objAsiento.nombreAlmacen = String.Empty
            '                    objAsiento.idEntidad = String.Empty
            '                    objAsiento.nombreEntidad = String.Empty
            '                    objAsiento.tipoEntidad = String.Empty
            '                    objAsiento.fechaProceso = DateTime.Now
            '                    objAsiento.codigoLibro = "8"
            '                    objAsiento.tipo = "D"
            '                    objAsiento.tipoAsiento = "ACCA"
            '                    objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
            '                    objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


            '                    objAsiento.glosa = "Ingreso a centro de costo"
            '                    objAsiento.usuarioActualizacion = usuario.IDUsuario
            '                    objAsiento.fechaActualizacion = DateTime.Now

            '                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

            '                    objMovimiento = New movimiento With {
            '                          .cuenta = i.Record.GetValue("cuentaCosteo"),
            '                          .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
            '                          .tipo = "H",
            '                          .monto = CDec(i.Record.GetValue("montokardex")),
            '                          .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
            '                          .usuarioActualizacion = usuario.IDUsuario,
            '                          .fechaActualizacion = DateTime.Now
            '                      }
            '                    objAsiento.movimiento.Add(objMovimiento)


            '                    objMovimiento = New movimiento With {
            '                            .cuenta = "791",
            '                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
            '                            .tipo = "D",
            '                            .monto = CDec(i.Record.GetValue("montokardex")),
            '                            .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
            '                            .usuarioActualizacion = usuario.IDUsuario,
            '                            .fechaActualizacion = DateTime.Now
            '                        }
            '                    objAsiento.movimiento.Add(objMovimiento)

            '                    listaAsiento.Add(objAsiento)

            '                    obj = New recursoCostoDetalle With {
            '                                    .idCosto = CInt(i.Record.GetValue("idEDT")),
            '                                    .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
            '                                    .iditem = Val(i.Record.GetValue("idItem")),
            '                                    .destino = i.Record.GetValue("destino"),
            '                                    .descripcion = i.Record.GetValue("descripcionItem"),
            '                                    .um = i.Record.GetValue("unidad1"),
            '                                    .cant = CDec(i.Record.GetValue("monto1")),
            '                                    .puMN = 0,
            '                                    .puME = 0,
            '                                    .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
            '                                    .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
            '                                    .documentoRef = CInt(i.Record.GetValue("idDocumento")),
            '                                    .itemRef = CInt(i.Record.GetValue("secuencia")),
            '                                    .operacion = i.Record.GetValue("TipoOperacion"),
            '                                    .procesado = "N",
            '                                    .idProceso = CInt(i.Record.GetValue("idEDT")),
            '                                    .Periodo = PeriodoGeneral,
            '                                    .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
            '                                    .tipoCosto = "HG"}
            '                    Lista.Add(obj)

            '                    '////
            '                Case Else
            '                    objAsiento = New asiento
            '                    objAsiento.periodo = PeriodoGeneral
            '                    objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            '                    objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            '                    objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
            '                    objAsiento.idDocumentoRef = Nothing
            '                    objAsiento.idAlmacen = 0
            '                    objAsiento.nombreAlmacen = String.Empty
            '                    objAsiento.idEntidad = String.Empty
            '                    objAsiento.nombreEntidad = String.Empty
            '                    objAsiento.tipoEntidad = String.Empty
            '                    objAsiento.fechaProceso = DateTime.Now
            '                    objAsiento.codigoLibro = "8"
            '                    objAsiento.tipo = "D"
            '                    objAsiento.tipoAsiento = "ACCA"
            '                    objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
            '                    objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


            '                    objAsiento.glosa = "Ingreso a centro de costo"
            '                    objAsiento.usuarioActualizacion = usuario.IDUsuario
            '                    objAsiento.fechaActualizacion = DateTime.Now

            '                    'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

            '                    objMovimiento = New movimiento With {
            '                          .cuenta = i.Record.GetValue("cuentaCosteo"),
            '                          .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
            '                          .tipo = "D",
            '                          .monto = CDec(i.Record.GetValue("montokardex")),
            '                          .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
            '                          .usuarioActualizacion = usuario.IDUsuario,
            '                          .fechaActualizacion = DateTime.Now
            '                      }
            '                    objAsiento.movimiento.Add(objMovimiento)


            '                    objMovimiento = New movimiento With {
            '                            .cuenta = "791",
            '                            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
            '                            .tipo = "H",
            '                            .monto = CDec(i.Record.GetValue("montokardex")),
            '                            .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
            '                            .usuarioActualizacion = usuario.IDUsuario,
            '                            .fechaActualizacion = DateTime.Now
            '                        }
            '                    objAsiento.movimiento.Add(objMovimiento)

            '                    listaAsiento.Add(objAsiento)

            '                    obj = New recursoCostoDetalle With {
            '                                    .idCosto = CInt(i.Record.GetValue("idEDT")),
            '                                    .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
            '                                    .iditem = Val(i.Record.GetValue("idItem")),
            '                                    .destino = i.Record.GetValue("destino"),
            '                                    .descripcion = i.Record.GetValue("descripcionItem"),
            '                                    .um = i.Record.GetValue("unidad1"),
            '                                    .cant = CDec(i.Record.GetValue("monto1")),
            '                                    .puMN = 0,
            '                                    .puME = 0,
            '                                    .montoMN = CDec(i.Record.GetValue("montokardex")),
            '                                    .montoME = CDec(i.Record.GetValue("montokardexUS")),
            '                                    .documentoRef = CInt(i.Record.GetValue("idDocumento")),
            '                                    .itemRef = CInt(i.Record.GetValue("secuencia")),
            '                                    .operacion = i.Record.GetValue("TipoOperacion"),
            '                                    .procesado = "N",
            '                                    .idProceso = CInt(i.Record.GetValue("idEDT")),
            '                                    .Periodo = PeriodoGeneral,
            '                                      .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
            '                                    .tipoCosto = "HG"}
            '                    Lista.Add(obj)
            '            End Select
            '            'hasta aqui


            '    End Select


            'Next


            costoSA.GrabarDetalleRecursos(Lista, listaAsiento)
            ' GetItemsNoAsignadosEntregable(txtidEntregable.Text)

            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub ListaRecursosGastoEntregable(idEntregable As Integer)
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
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("cuentaCosteo")

        For Each i In compraSA.ListaRecursosGastoEntregable(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral}, idEntregable)
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
            dr(17) = Nothing
            dr(18) = Nothing
            dr(19) = Nothing
            dr(20) = Nothing
            dr(21) = i.idCosto
            dr(22) = i.NombreProyectoGeneral
            dr(23) = Nothing
            dr(24) = Nothing
            dr(25) = Nothing
            If i.tipoCosto = "PC" Then
                dr(26) = "HC"
            ElseIf i.tipoCosto = "PG" Then
                dr(26) = "HG"
            End If
            dr(27) = DateTime.Now
            dr(28) = i.CuentaItem
            dt.Rows.Add(dr)
        Next

        dgvItemsNoasignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvItemsNoasignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub



    Public Sub ListaCompraDeServicios(tipoCosteo As String)
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

        dt.Columns.Add("fechaTrabajo")

        dt.Columns.Add("montouso")
        dt.Columns.Add("montosaldo")


        For Each i In compraSA.ListaCompraDeServicios(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral}, tipoCosteo)
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

            dr(17) = DateTime.Now

            dr(18) = CDec(0.0)
            dr(19) = CDec(0.0)

            dt.Rows.Add(dr)
        Next

        dgvItemsNoasignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvItemsNoasignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Public Sub GetItemsNoAsignadosEntregable(idEntregable As Integer)
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
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("cuentaCosteo")

        For Each i In compraSA.ListaRecursosCostoEntregable(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral}, idEntregable)
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
            dr(17) = Nothing
            dr(18) = Nothing
            dr(19) = Nothing
            dr(20) = Nothing
            dr(21) = i.idCosto
            dr(22) = i.NombreProyectoGeneral
            dr(23) = Nothing
            dr(24) = Nothing
            dr(25) = Nothing
            If i.tipoCosto = "PC" Then
                dr(26) = "HC"
            ElseIf i.tipoCosto = "PG" Then
                dr(26) = "HG"
            End If
            dr(27) = DateTime.Now
            dr(28) = i.CuentaItem
            dt.Rows.Add(dr)
        Next

        dgvItemsNoasignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvItemsNoasignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

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
    Private Sub frmCosteoCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtTipoCosteo.Text = "HC" Then
            'GetItemsNoAsignadosEntregable(txtidEntregable.Text)
            ListaCompraDeServicios("PC")
        ElseIf txtTipoCosteo.Text = "HG" Then
            'ListaRecursosGastoEntregable(txtidEntregable.Text)
            ListaCompraDeServicios("PG")
        End If
        txtPeriodo.Text = PeriodoGeneral
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If dgvItemsNoasignados.Table.Records.Count > 0 Then
            If dgvItemsNoasignados.Table.SelectedRecords.Count > 0 Then

                RegistrarItemsAsignados()

            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If dgvItemsNoasignados.Table.Records.Count > 0 Then



            RegistrarItemsAsignadosAll()


        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub dgvItemsNoasignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvItemsNoasignados.TableControlCellClick

    End Sub

    Private Sub dgvItemsNoasignados_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvItemsNoasignados.TableControlKeyDown
        Dim cc As GridCurrentCell = dgvItemsNoasignados.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvItemsNoasignados.Table.CurrentRecord) Then

                    If cc.ColIndex = 19 Then
                        If CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")) > 0 Then


                            If CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montokardex")) >= CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")) Then

                                Dim importeTotal = Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montokardex") - Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", importeTotal)
                            Else
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montouso", 0)
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", 0)
                                ' Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        Else
                            Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montouso", 0)
                            Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", 0)
                            ' Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                        End If

                    ElseIf cc.ColIndex = 13 Then

                        'If Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("precio") > 0 Then




                        '    Dim importeTotal = Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("cantidad") * Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("precio")
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("importe", importeTotal)


                        'Else
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("importe", 0)
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                        'End If


                    End If

                End If
            End If

            ' calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvItemsNoasignados_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvItemsNoasignados.TableControlKeyPress
        Dim cc As GridCurrentCell = dgvItemsNoasignados.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvItemsNoasignados.Table.CurrentRecord) Then

                    If cc.ColIndex = 19 Then
                        If CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")) > 0 Then


                            If CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montokardex")) >= CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")) Then

                                Dim importeTotal = Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montokardex") - Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", importeTotal)
                            Else
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montouso", 0)
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", 0)
                                ' Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        Else
                            Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montouso", 0)
                            Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", 0)
                            ' Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                        End If

                    ElseIf cc.ColIndex = 13 Then

                        'If Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("precio") > 0 Then




                        '    Dim importeTotal = Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("cantidad") * Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("precio")
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("importe", importeTotal)


                        'Else
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("importe", 0)
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                        'End If


                    End If

                End If
            End If

            ' calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub


    Private Sub dgvItemsNoasignados_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvItemsNoasignados.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvItemsNoasignados.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvItemsNoasignados.Table.CurrentRecord) Then

                    If cc.ColIndex = 19 Then
                        If CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")) > 0 Then


                            If CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montokardex")) >= CDec(Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")) Then

                                Dim importeTotal = Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montokardex") - Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("montouso")
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", importeTotal)
                            Else
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montouso", 0)
                                Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", 0)
                                ' Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                            End If

                        Else
                            Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montouso", 0)
                            Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("montosaldo", 0)
                            ' Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                        End If

                    ElseIf cc.ColIndex = 13 Then

                        'If Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("precio") > 0 Then




                        '    Dim importeTotal = Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("cantidad") * Me.dgvItemsNoasignados.Table.CurrentRecord.GetValue("precio")
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("importe", importeTotal)


                        'Else
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("importe", 0)
                        '    Me.dgvItemsNoasignados.Table.CurrentRecord.SetValue("cantidad", 0)
                        'End If


                    End If

                End If
            End If

            ' calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub




    
End Class