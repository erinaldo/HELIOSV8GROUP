Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Public Class frmCostoVenta
    Inherits frmMaster

    Public Sub New(grid As GridGroupingControl)

        ' This call is required by the designer.
        InitializeComponent()
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        GridCFGKardex(dgvCompra)
        GridCFGKardex(GridGroupingControl1)
        ObtenerListado(grid)
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
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
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

    Sub GridCFGKardex(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
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
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Public Sub GrabarAsiento()
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        documento.nroDoc = "1"
        documento.tipoOperacion = "9924"  'INGRESO CUENTAS MANUALES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = "Jiuni"
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "AS-CVT"
        documentoLibroDiario.fecha = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        documentoLibroDiario.fechaPeriodo = AnioGeneral & "/" & MesGeneral

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If chProv.Checked = True Then
        '    documentoLibroDiario.tipoRazonSocial = "PR"
        'End If
        'If chTrab.Checked = True Then
        '    documentoLibroDiario.tipoRazonSocial = "TR"
        'End If
        'If chClie.Checked = True Then
        '    documentoLibroDiario.tipoRazonSocial = "CL"
        'End If

        documentoLibroDiario.razonSocial = Nothing

        documentoLibroDiario.infoReferencial = "Por Cierre Costo de ventas"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "9924"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = 0
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now


        'documentoLibroDiario.importeMN = 0
        'documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario
     

        For Each obj As Record In GridGroupingControl1.Table.Records
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = obj.GetValue("cuenta")
            documentoLibroDiarioDet.descripcion = obj.GetValue("descripcion")
            documentoLibroDiarioDet.tipoAsiento = obj.GetValue("tipo")
            documentoLibroDiarioDet.importeMN = CDbl(obj.GetValue("monto"))
            documentoLibroDiarioDet.importeME = CDbl(obj.GetValue("montoUS"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
        Next



        documento.documentoLibroDiario.importeMN = ListaDetalle.Where(Function(o) o.tipoAsiento = "D").Sum(Function(o) o.importeMN)
        documento.documentoLibroDiario.importeME = ListaDetalle.Where(Function(o) o.tipoAsiento = "H").Sum(Function(o) o.importeMN)

        documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle
        '   End If
        Dim asiento As New asiento
        'documentoLibroDiario.CustomAsiento = New asiento

        Dim ListaAsientonTransito As New List(Of asiento)

        With asiento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idAlmacen = Nothing
            .nombreAlmacen = Nothing
            .idEntidad = Nothing
            .nombreEntidad = Nothing
            .tipoEntidad = Nothing
            .fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .codigoLibro = "1"
            .tipo = "E"
            .tipoAsiento = "AS-M"
            .importeMN = ListaDetalle.Where(Function(o) o.tipoAsiento = "D").Sum(Function(o) o.importeMN)
            .importeME = ListaDetalle.Where(Function(o) o.tipoAsiento = "H").Sum(Function(o) o.importeMN)
            .glosa = "Por Cierre Costo de ventas"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ListaAsientonTransito.Add(asiento)

        Dim n As New movimiento
        '  Dim listaAsiento As New List(Of movimiento)
        For Each i In ListaDetalle
            n = New movimiento
            n.cuenta = i.cuenta
            n.descripcion = i.descripcion
            n.tipo = i.tipoAsiento
            n.monto = i.importeMN
            n.montoUSD = i.importeME
            n.usuarioActualizacion = usuario.IDUsuario
            n.fechaActualizacion = DateTime.Now
            asiento.movimiento.Add(n)
        Next
        documento.asiento = ListaAsientonTransito
        Dim xcod As Integer = documentoLibroDiarioSA.GrabarLibro(documento)
        Dispose()
    End Sub

    Public Sub ObtenerListado(grid As GridGroupingControl)
        Dim dt As New DataTable
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipo")
        dt.Columns.Add("monto")
        dt.Columns.Add("montoUS")
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Try
            For Each i As Record In grid.Table.FilteredRecords
                totalMN += CDec(i.GetValue("monto1"))
                totalME += 0
                Dim dr As DataRow = dt.NewRow
                dr(0) = "69112"
                dr(1) = i.GetValue("nombreItem")
                dr(2) = "D"
                dr(3) = i.GetValue("monto1")
                dr(4) = 0
                dt.Rows.Add(dr)

                Dim dr1 As DataRow = dt.NewRow
                dr1(0) = "20111"
                dr1(1) = i.GetValue("nombreItem")
                dr1(2) = "H"
                dr1(3) = i.GetValue("monto1")
                dr1(4) = 0
                dt.Rows.Add(dr1)
            Next
            dgvCompra.DataSource = dt

            Dim dt2 As New DataTable()
            dt2.Columns.Add("cuenta")
            dt2.Columns.Add("descripcion")
            dt2.Columns.Add("tipo")
            dt2.Columns.Add("monto")
            dt2.Columns.Add("montoUS")

            Dim dr3 As DataRow = dt2.NewRow
            dr3(0) = "69112"
            dr3(1) = ""
            dr3(2) = "D"
            dr3(3) = totalMN
            dr3(4) = 0
            dt2.Rows.Add(dr3)

            Dim dr4 As DataRow = dt2.NewRow
            dr4(0) = "20111"
            dr4(1) = ""
            dr4(2) = "H"
            dr4(3) = totalMN
            dr4(4) = 0
            dt2.Rows.Add(dr4)
            GridGroupingControl1.DataSource = dt2
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmCostoVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCostoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarAsiento()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class