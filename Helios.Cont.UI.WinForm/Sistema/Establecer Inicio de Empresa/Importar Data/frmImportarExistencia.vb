Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmImportarExistencia
    Inherits frmMaster

    Public Property ListaUnidadesMedida As New List(Of tabladetalle)
    Public Property strEmpresa As String

    Public Sub New(idEmpresa As String)

        ' This call is required by the designer.
        InitializeComponent()
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(idEmpresa, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        strEmpresa = idEmpresa
        GridCFG(dgvExistencias)
        GetGridColumn()
        LoadUNidades()

        'ImportarExcel()
    End Sub

    Sub LoadUNidades()
        Dim tablaSA As New tablaDetalleSA
        ListaUnidadesMedida = New List(Of tabladetalle)

        ListaUnidadesMedida = tablaSA.GetListaTablaDetalle(6, "1")

    End Sub

#Region "Métodos"
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
    '                        '  GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtSerie.Text = .serie
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            'If Not IsNothing(.configAlmacen) Then
    '            '    Dim estableSA As New establecimientoSA
    '            '    With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '            '        GConfiguracion.IdAlmacen = .idAlmacen
    '            '        GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '            '        'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '            '        'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '            '        With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            '            'txtIdEstableAlmacen.Text = .idCentroCosto
    '            '            'txtEstableAlmacen.Text = .nombre
    '            '        End With
    '            '    End With
    '            'End If
    '            'If Not IsNothing(.ConfigentidadFinanciera) Then
    '            '    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '            '        GConfiguracion.IDCaja = .idestado
    '            '        GConfiguracion.NomCaja = .descripcion
    '            '    End With
    '            'End If

    '        End With
    '    Else
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Sub GetGridColumn()
        Dim dt As New DataTable()
        dt.Columns.Add("codigodetalle")
        dt.Columns.Add("idEmpresa")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("presentacion")
        dt.Columns.Add("unidad1")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("origenProducto")
        dt.Columns.Add("tipoProducto")
        dt.Columns.Add("stock")
        dt.Columns.Add("cantMinima")
        dt.Columns.Add("cantMaxima")
        dt.Columns.Add("costoMN")
        dt.Columns.Add("costoME")
        dt.Columns.Add("almacen")
        dt.Columns.Add("precio_menor")
        dt.Columns.Add("precio_mayor")
        dt.Columns.Add("precio_granmayor")
        dt.Columns.Add("nroLote")
        dt.Columns.Add("fechaVcto")

        dgvExistencias.DataSource = dt
    End Sub
    Dim colorx As New GridMetroColors()
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

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


    Public Sub ImportarExcel()
        Dim strDestination As String = Nothing

        Dim dlgResult As DialogResult
        Dim icount As Integer = 1
        Try


            'Show dialog
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                lblruta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> DialogResult.Cancel Then
                Dim hoja As String = ComboBox1.Text ' "Aporte_adic_2" ' "aporte_adic_1" ' "Aporte_ini"
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = (From x In book.Worksheet(Of ExistenciaBE)(hoja)
                             Select x).ToList

                For Each i In users
                    'Dim unidad = ListaUnidadesMedida.Where(Function(o) o.codigoDetalle = String.Format("{0:00}", CInt(i.unidad1))).FirstOrDefault

                    Me.dgvExistencias.Table.AddNewRecord.SetCurrent()
                    Me.dgvExistencias.Table.AddNewRecord.BeginEdit()
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("codigodetalle", i.codigodetalle)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("idEmpresa", Gempresas.IdEmpresaRuc)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("descripcionItem", i.descripcionItem)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("presentacion", i.presentacion)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("unidad1", i.unidad1)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("tipoExistencia", "01")
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("origenProducto", i.origenProducto)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("tipoProducto", "N")
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("stock", i.stock)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("cantMinima", i.cantMinima)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("cantMaxima", i.cantMaxima)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("costoMN", i.costoMN)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("costoME", i.costoME)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("almacen", String.Empty)

                    Me.dgvExistencias.Table.CurrentRecord.SetValue("precio_menor", i.precio_menor)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("precio_mayor", i.precio_mayor)
                    Me.dgvExistencias.Table.CurrentRecord.SetValue("precio_granmayor", i.precio_granmayor)

                    Me.dgvExistencias.Table.CurrentRecord.SetValue("nroLote", i.codigoLote)
                    If i.FechaVcto.HasValue Then
                        Me.dgvExistencias.Table.CurrentRecord.SetValue("fechaVcto", i.FechaVcto)
                    Else

                    End If


                    Me.dgvExistencias.Table.AddNewRecord.EndEdit()
                    icount += 1
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "names.xls")


    End Sub
#End Region

#Region "Manipulación Data"

    Private Sub GrabarFrom()
        Dim Inventarios = GetDetalleInventario.ToList()
        Dim rows = GetDetalleInventario.ToList.Count
        Dim paginado = 400
        Dim numeroPaginas = rows / paginado
        Dim ParteEntera = Int(numeroPaginas)
        Dim ParteDecimal = numeroPaginas - ParteEntera
        If ParteDecimal > 0 Then
            ParteDecimal = 1
        End If
        Dim SumSkips = 0
        '---------------------------------------------------------
        For i = 1 To ParteEntera
            If i = 1 Then
                Dim t = Inventarios.Take(paginado).ToList
                SumSkips += paginado
                GrabarSolo(t)
            Else
                Dim t = Inventarios.Skip(SumSkips).Take(paginado).ToList
                SumSkips += paginado
                GrabarSolo(t)
            End If
        Next

        For i = 1 To ParteDecimal
            Dim t = Inventarios.Skip(SumSkips).ToList
            GrabarSolo(t)
        Next

    End Sub

    Function GetDetalleInventario() As List(Of detalleitems)
        Dim precio As configuracionPrecioProducto
        Dim item As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim listaItems As New List(Of detalleitems)

        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        For Each r As Record In dgvExistencias.Table.Records

            Dim codalmacen = r.GetValue("almacen")

            If Not codalmacen.ToString.Trim.Length > 0 Then
                MessageBoxAdv.Show("Falta asignar el almacén al item " & r.GetValue("descripcionItem"), "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            sumaMN += CDec(r.GetValue("costoMN"))
            sumaME += CDec(r.GetValue("costoME"))

            '---------------------------------------------------------------------------------
            item = New detalleitems
            item.idEmpresa = Gempresas.IdEmpresaRuc
            item.idEstablecimiento = GEstableciento.IdEstablecimiento
            item.descripcionItem = r.GetValue("descripcionItem")
            '   item.presentacion = r.GetValue("presentacion")
            item.unidad1 = r.GetValue("unidad1")
            item.unidad2 = r.GetValue("presentacion")
            item.tipoExistencia = r.GetValue("tipoExistencia")
            item.origenProducto = r.GetValue("origenProducto")
            item.tipoProducto = r.GetValue("tipoProducto")
            item.codigo = r.GetValue("codigodetalle")
            item.estado = "A"
            item.usuarioActualizacion = usuario.IDUsuario
            item.fechaActualizacion = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            item.CustomTotalAlmacen = New totalesAlmacen

            item.customLote = New recursoCostoLote
            item.customLote.nroLote = r.GetValue("nroLote")
            item.customLote.detalle = r.GetValue("descripcionItem")
            item.customLote.productoSustentado = True

            Dim fechaDBX = r.GetValue("fechaVcto")
            If fechaDBX.ToString.Trim.Length > 0 Then
                item.customLote.fechaProduccion = CDate(r.GetValue("fechaVcto"))
                item.customLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
            Else
                item.customLote.fechaProduccion = Nothing
                item.customLote.fechaVcto = Nothing
            End If

            With item.CustomTotalAlmacen
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idAlmacen = CInt(r.GetValue("almacen"))
                .origenRecaudo = r.GetValue("origenProducto")
                .tipoCambio = 0
                .tipoExistencia = r.GetValue("tipoExistencia")
                .descripcion = r.GetValue("descripcionItem")
                .idUnidad = r.GetValue("unidad1")
                .unidadMedida = r.GetValue("unidad1")
                .cantidad = CDec(r.GetValue("stock"))
                .precioUnitarioCompra = 0
                .importeSoles = CDec(r.GetValue("costoMN"))
                .importeDolares = CDec(r.GetValue("costoME"))
                .montoIsc = 0
                .montoIscUS = 0
                .Otros =
                .OtrosUS = 0
                .porcentajeUtilidad = Nothing
                .importePorcentaje = Nothing
                .importePorcentajeUS = Nothing
                .precioVenta = Nothing
                .precioVentaUS = Nothing
                .cantidadMaxima = CDec(r.GetValue("cantMaxima"))
                .cantidadMinima = CDec(r.GetValue("cantMinima"))
                .status = 1
                .fechaVcto = Nothing
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            item.CustomCierreInventario = New cierreinventario

            With item.CustomCierreInventario
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .periodo = String.Format("{0:00}", txtMes.Value.Month) & "/" & txtAnio.Value.Year
                .idAlmacen = CInt(r.GetValue("almacen"))
                .anio = txtAnio.Value.Year
                .mes = txtMes.Value.Month
                .dia = 1
                .cantidad = CDec(r.GetValue("stock"))
                .importe = CDec(r.GetValue("costoMN"))
                .importeUS = CDec(r.GetValue("costoME"))
                .unidad = r.GetValue("unidad1")
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = DateTime.Now
            End With

            '-------- AGREGANDO PRECIOS GENERALES ------------------------

            item.CustomPrecios = New List(Of configuracionPrecioProducto)

            'X menor
            precio = New configuracionPrecioProducto
            precio.idPrecio = 1
            ' precio.idAlmacen = CInt(r.GetValue("almacen"))
            'precio.idproducto = CInt(txtProducto.Tag)
            precio.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            precio.tipo = 1
            precio.valPorcentaje = 0
            precio.nroLote = Nothing
            precio.descripcion = "Precio por Menor"
            precio.precioMN = CDec(r.GetValue("precio_menor"))
            precio.precioME = 0
            item.CustomPrecios.Add(precio)

            'X mayor
            precio = New configuracionPrecioProducto
            precio.idPrecio = 2
            '      precio.idAlmacen = CInt(r.GetValue("almacen"))
            'precio.idproducto = CInt(txtProducto.Tag)
            precio.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            precio.tipo = 1
            precio.valPorcentaje = 0
            precio.nroLote = Nothing
            precio.descripcion = "Precio por Mayor"
            precio.precioMN = CDec(r.GetValue("precio_mayor"))
            precio.precioME = 0
            item.CustomPrecios.Add(precio)

            'X gran mayor
            precio = New configuracionPrecioProducto
            precio.idPrecio = 3
            '    precio.idAlmacen = CInt(r.GetValue("almacen"))
            'precio.idproducto = CInt(txtProducto.Tag)
            precio.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            precio.tipo = 1
            precio.valPorcentaje = 0
            precio.nroLote = Nothing
            precio.descripcion = "Precio por Gran Mayor"
            precio.precioMN = CDec(r.GetValue("precio_granmayor"))
            precio.precioME = 0
            item.CustomPrecios.Add(precio)

            listaItems.Add(item)
        Next
        Return listaItems
    End Function

    Sub Grabar()
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim item As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim listaItems As New List(Of detalleitems)
        Dim precio As New configuracionPrecioProducto

        dgvExistencias.TableControl.CurrentCell.EndEdit()
        dgvExistencias.TableControl.Table.TableDirty = True
        dgvExistencias.TableControl.Table.EndEdit()


        documento = New documento
        If CheckBox1.Checked = True Then
            documento.IsInicio = True
        Else
            documento.IsInicio = False
        End If
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
        documento.idEntidad = usuario.IDUsuario
        documento.entidad = usuario.CustomUsuario.Full_Name
        documento.nrodocEntidad = usuario.CustomUsuario.NroDocumento
        documento.tipoEntidad = "US"
        documento.nroDoc = "1"
        documento.tipoOperacion = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "APT_EXT"
        documentoLibroDiario.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
        documentoLibroDiario.fechaPeriodo = String.Format("{0:00}", txtMes.Value.Month) & "/" & txtAnio.Value.Year
        documentoLibroDiario.tipoRazonSocial = "OT"
        documentoLibroDiario.razonSocial = Nothing
        If CheckBox1.Checked = True Then
            documentoLibroDiario.infoReferencial = "Por ingreso de existencias por apertura"
        Else
            documentoLibroDiario.infoReferencial = "Por aporte de existencias"
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "105"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = TmpTipoCambio
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
        documentoLibroDiario.tieneCosto = "N"
        documentoLibroDiario.idCosto = Nothing
        documentoLibroDiario.importeMN = 0
        documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario

        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        '  Dim fechaDB As DateTime?
        For Each r As Record In dgvExistencias.Table.Records

            Dim codalmacen = r.GetValue("almacen")

            If Not codalmacen.ToString.Trim.Length > 0 Then
                MessageBoxAdv.Show("Falta asignar el almacén al item " & r.GetValue("descripcionItem"), "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            sumaMN += CDec(r.GetValue("costoMN"))
            sumaME += CDec(r.GetValue("costoME"))

            '---------------------------------------------------------------------------------
            item = New detalleitems
            item.idEmpresa = Gempresas.IdEmpresaRuc
            item.idEstablecimiento = GEstableciento.IdEstablecimiento
            item.descripcionItem = r.GetValue("descripcionItem")
            item.presentacion = r.GetValue("presentacion")
            item.unidad1 = r.GetValue("unidad1")
            item.tipoExistencia = r.GetValue("tipoExistencia")
            item.origenProducto = r.GetValue("origenProducto")
            item.tipoProducto = r.GetValue("tipoProducto")
            item.codigo = r.GetValue("codigodetalle")
            item.estado = "A"
            item.usuarioActualizacion = usuario.IDUsuario
            item.fechaActualizacion = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            item.CustomTotalAlmacen = New totalesAlmacen

            item.customLote = New recursoCostoLote
            item.customLote.nroLote = r.GetValue("nroLote")
            item.customLote.detalle = r.GetValue("descripcionItem")
            item.customLote.productoSustentado = True

            Dim fechaDBX = r.GetValue("fechaVcto")
            If fechaDBX.ToString.Trim.Length > 0 Then
                item.customLote.fechaProduccion = CDate(r.GetValue("fechaVcto"))
                item.customLote.fechaVcto = CDate(r.GetValue("fechaVcto"))
            Else
                item.customLote.fechaProduccion = Nothing
                item.customLote.fechaVcto = Nothing
            End If

            With item.CustomTotalAlmacen
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idAlmacen = CInt(r.GetValue("almacen"))
                .origenRecaudo = r.GetValue("origenProducto")
                .tipoCambio = 0
                .tipoExistencia = r.GetValue("tipoExistencia")
                .descripcion = r.GetValue("descripcionItem")
                .idUnidad = r.GetValue("unidad1")
                .unidadMedida = r.GetValue("unidad1")
                .cantidad = CDec(r.GetValue("stock"))
                .precioUnitarioCompra = 0
                .importeSoles = CDec(r.GetValue("costoMN"))
                .importeDolares = CDec(r.GetValue("costoME"))
                .montoIsc = 0
                .montoIscUS = 0
                .Otros =
                .OtrosUS = 0
                .porcentajeUtilidad = Nothing
                .importePorcentaje = Nothing
                .importePorcentajeUS = Nothing
                .precioVenta = Nothing
                .precioVentaUS = Nothing
                .cantidadMaxima = CDec(r.GetValue("cantMaxima"))
                .cantidadMinima = CDec(r.GetValue("cantMinima"))
                .status = 1
                .fechaVcto = Nothing
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            item.CustomCierreInventario = New cierreinventario

            With item.CustomCierreInventario
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .periodo = String.Format("{0:00}", txtMes.Value.Month) & "/" & txtAnio.Value.Year
                .idAlmacen = CInt(r.GetValue("almacen"))
                .anio = txtAnio.Value.Year
                .mes = txtMes.Value.Month
                .dia = 1
                .cantidad = CDec(r.GetValue("stock"))
                .importe = CDec(r.GetValue("costoMN"))
                .importeUS = CDec(r.GetValue("costoME"))
                .unidad = r.GetValue("unidad1")
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = DateTime.Now
            End With

            '-------- AGREGANDO PRECIOS GENERALES ------------------------

            item.CustomPrecios = New List(Of configuracionPrecioProducto)

            'X menor
            precio = New configuracionPrecioProducto
            precio.idPrecio = 1
            ' precio.idAlmacen = CInt(r.GetValue("almacen"))
            'precio.idproducto = CInt(txtProducto.Tag)
            precio.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            precio.tipo = 1
            precio.valPorcentaje = 0
            precio.nroLote = Nothing
            precio.descripcion = "Precio por Menor"
            precio.precioMN = CDec(r.GetValue("precio_menor"))
            precio.precioME = 0
            item.CustomPrecios.Add(precio)

            'X mayor
            precio = New configuracionPrecioProducto
            precio.idPrecio = 2
            '      precio.idAlmacen = CInt(r.GetValue("almacen"))
            'precio.idproducto = CInt(txtProducto.Tag)
            precio.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            precio.tipo = 1
            precio.valPorcentaje = 0
            precio.nroLote = Nothing
            precio.descripcion = "Precio por Mayor"
            precio.precioMN = CDec(r.GetValue("precio_mayor"))
            precio.precioME = 0
            item.CustomPrecios.Add(precio)

            'X gran mayor
            precio = New configuracionPrecioProducto
            precio.idPrecio = 3
            '    precio.idAlmacen = CInt(r.GetValue("almacen"))
            'precio.idproducto = CInt(txtProducto.Tag)
            precio.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
            precio.tipo = 1
            precio.valPorcentaje = 0
            precio.nroLote = Nothing
            precio.descripcion = "Precio por Gran Mayor"
            precio.precioMN = CDec(r.GetValue("precio_granmayor"))
            precio.precioME = 0
            item.CustomPrecios.Add(precio)

            listaItems.Add(item)
        Next
        documento.documentoLibroDiario.importeMN = sumaMN
        documento.documentoLibroDiario.importeME = sumaME
        itemSA.ListadoItemsDeInicio(listaItems, documento)
        Dispose()
    End Sub

    Sub GrabarSolo(lista As List(Of detalleitems))
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim item As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim precio As New configuracionPrecioProducto

        dgvExistencias.TableControl.CurrentCell.EndEdit()
        dgvExistencias.TableControl.Table.TableDirty = True
        dgvExistencias.TableControl.Table.EndEdit()


        documento = New documento
        If CheckBox1.Checked = True Then
            documento.IsInicio = True
        Else
            documento.IsInicio = False
        End If
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
        documento.idEntidad = usuario.IDUsuario
        documento.entidad = usuario.CustomUsuario.Full_Name
        documento.nrodocEntidad = usuario.CustomUsuario.NroDocumento
        documento.tipoEntidad = "US"
        documento.nroDoc = "1"
        documento.tipoOperacion = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "APT_EXT"
        documentoLibroDiario.fecha = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
        documentoLibroDiario.fechaPeriodo = String.Format("{0:00}", txtMes.Value.Month) & "/" & txtAnio.Value.Year
        documentoLibroDiario.tipoRazonSocial = "OT"
        documentoLibroDiario.razonSocial = Nothing
        If CheckBox1.Checked = True Then
            documentoLibroDiario.infoReferencial = "Por ingreso de existencias por apertura"
        Else
            documentoLibroDiario.infoReferencial = "Por aporte de existencias"
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "105"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = TmpTipoCambio
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = New Date(txtAnio.Value.Year, txtMes.Value.Month, 1)
        documentoLibroDiario.tieneCosto = "N"
        documentoLibroDiario.idCosto = Nothing
        documentoLibroDiario.importeMN = 0
        documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario

        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        '  Dim fechaDB As DateTime?

        documento.documentoLibroDiario.importeMN = sumaMN
        documento.documentoLibroDiario.importeME = sumaME
        itemSA.ListadoItemsDeInicio(lista, documento)
    End Sub

    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        If Not IsNothing(GEstableciento) Then
            For Each i In almacenSA.GetListar_almacenExceptAVEmpresa(strEmpresa, GEstableciento.IdEstablecimiento)
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next
            cboAlmacen.DisplayMember = "descripcionAlmacen"
            cboAlmacen.ValueMember = "idAlmacen"
            cboAlmacen.DataSource = dt
        End If



        Return dt
    End Function

    Sub CambiarAlmacenAll()
        For Each r As Record In dgvExistencias.Table.Records
            r.SetValue("almacen", cboAlmacen.SelectedValue)
        Next
    End Sub
#End Region
    Dim comboTable As New DataTable
    Private Sub frmImportarExistencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmImportarExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTable = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvExistencias.TableDescriptor.Columns(13).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            'Grabar()
            GrabarFrom()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If rbSeleccion.Checked = True Then
            If Not IsNothing(dgvExistencias.Table.CurrentRecord) Then
                dgvExistencias.Table.CurrentRecord.SetValue("almacen", cboAlmacen.SelectedValue)
            End If
        ElseIf rbTodos.Checked = True Then
            CambiarAlmacenAll()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvExistencias_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvExistencias.TableControlCellClick

    End Sub

    Private Sub dgvExistencias_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvExistencias.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If ComboBox1.Text.Trim.Length > 0 Then
            ImportarExcel()
        Else
            MessageBox.Show("Seleccionar un aporte o inicio")
            ComboBox1.Select()
            ComboBox1.DroppedDown = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hoajadd = InputBox("Ingrese nombre de la hoja", "")
        ComboBox1.Items.Add(hoajadd)
    End Sub
End Class