Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel

Public Class frmMasterLibro
    Inherits frmMaster
    Public fecha As DateTime
    Public Property ManipulacionEstado() As String
    Dim SumaTotalDebeMN As Decimal = 0
    Dim SumaTotalHaberMN As Decimal = 0
    Dim SumaTotalDebeME As Decimal = 0
    Dim SumaTotalHaberME As Decimal = 0
    Public GConfiguracion As GConfiguracionModulo
    Dim colorx As GridMetroColors
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(gridGroupingControl1)
        GridCFG(GridGroupingControl2)
        GridCFG(GridGroupingControl3)
        GridCFG(GridGroupingControl4)
        GridCFG(GridGroupingControl5)
        GridCFG(GridGroupingControl6)
        GridCFG(dgvAportes)
        GridCabe(GridGroupingControl7)



        '  Me.WindowState = FormWindowState.Maximized
        'InitializeRAdial()
    End Sub


    Private Function GetTableGrid2() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("Entidad", GetType(String))
        dt.Columns.Add("Num", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("Num2", GetType(String))
        Return dt
    End Function

    Private Sub OptimizeGrid(gridGroupingControl As GridGroupingControl)
        ' Couple settings to perform better:
        gridGroupingControl.Engine.CounterLogic = EngineCounters.FilteredRecords
        gridGroupingControl.Engine.AllowedOptimizations = EngineOptimizations.DisableCounters Or EngineOptimizations.RecordsAsDisplayElements Or EngineOptimizations.VirtualMode
        gridGroupingControl.TableOptions.VerticalPixelScroll = False
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.FirstNRecords
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthFirstNRecords = 100
    End Sub

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

#Region "Aportes"


    Private Sub EliminarSaldoAporte(intIdDocumento As Integer)
        Dim documentoBL As New documento
        Dim DocumentoSA As New saldoInicioSA
        Dim almacen As New almacen
        Dim almacenSA As New almacenSA
        Dim saldoDetalleSA As New saldoInicioDetalleSA
        Dim objNuevo As New totalesAlmacen
        Dim ProductoSA As New detalleitemsSA
        Dim Producto As New detalleitems
        Dim ListaTotales As New List(Of totalesAlmacen)

        With documentoBL
            .idDocumento = intIdDocumento
        End With
        For Each i In saldoDetalleSA.ListadoMercaderiaXidDocumento(intIdDocumento)
            If Not IsNothing(i.almacen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacen)
                Producto = ProductoSA.InvocarProductoID(i.idModulo)
                If Not IsNothing(almacen) Then
                    objNuevo = New totalesAlmacen
                    objNuevo.SecuenciaDetalle = i.secuencia
                    objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                    objNuevo.idEstablecimiento = almacen.idEstablecimiento
                    objNuevo.idAlmacen = almacen.idAlmacen
                    objNuevo.origenRecaudo = Producto.origenProducto
                    objNuevo.idItem = Producto.codigodetalle
                    objNuevo.TipoDoc = "03" ' Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")
                    objNuevo.importeSoles = i.importe
                    objNuevo.importeDolares = i.importeUS

                    objNuevo.cantidad = i.cantidad
                    objNuevo.precioUnitarioCompra = i.precioUnitario

                    objNuevo.montoIsc = 0
                    objNuevo.montoIscUS = 0

                    ListaTotales.Add(objNuevo)
                End If
            End If
        Next
        DocumentoSA.DeleteSaldoAporte(documentoBL, ListaTotales)
    End Sub

    Private Function getTableSaldoPorPeriodo() As DataTable
        Dim DocumentoCompraSA As New saldoInicioSA

        Dim dt As New DataTable("Aportes saldos - período " & PeriodoGeneral & " ")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

        Dim str As String
        For Each i As saldoInicio In DocumentoCompraSA.ListadoSaldosXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.importeTotal
            dr(7) = 0
            dr(8) = i.importeUS
            dr(9) = i.monedaDoc
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Function getDetalle(strAprobado As String) As DataTable
        Dim asientoSA As New AsientoSA '
        Dim movimientoSA As New MovimientoSA '
        Dim dt As New DataTable("Libro " & PeriodoGeneral & " ")
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Debemn", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Habermn", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Debeme", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Haberme", GetType(Decimal)))

        For Each i As asiento In asientoSA.UbicarAsientoPorPeriodo(New DateTime(DateTime.Now.Year, MesGeneral, 1), New DateTime(AnioGeneral, MesGeneral, 1), strAprobado)


            For Each x As movimiento In movimientoSA.UbicarMovimientosXidDocumento(i.idAsiento)
                Dim dr As DataRow = dt.NewRow()
                Select Case x.tipo


                    Case "D"
                        dr(0) = x.cuenta
                        dr(1) = x.descripcion
                        dr(2) = CDec(x.monto).ToString("N2")
                        dr(3) = CDec(0.0)
                        dr(4) = CDec(x.montoUSD).ToString("N2")
                        dr(5) = CDec(0.0)

                    Case Else
                        dr(0) = x.cuenta
                        dr(1) = x.descripcion
                        dr(2) = CDec(0.0)
                        dr(3) = CDec(x.monto).ToString("N2")
                        dr(4) = CDec(0.0)
                        dr(5) = CDec(x.montoUSD).ToString("N2")
                End Select
                dt.Rows.Add(dr)
            Next
        Next

        Return dt
    End Function


    Public Sub ListaSaldoAporteXperiodo()
        Try

            Dim parentTable As DataTable = getTableSaldoPorPeriodo()
            Me.dgvAportes.DataSource = parentTable
            dgvAportes.TableDescriptor.Relations.Clear()
            dgvAportes.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvAportes.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvAportes.Appearance.AnyRecordFieldCell.Enabled = False
            dgvAportes.GroupDropPanel.Visible = True
            dgvAportes.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaDetalle(strAprobado As String)
        Try

            Dim parentTable As DataTable = getDetalle(strAprobado)
            Me.GridGroupingControl7.DataSource = parentTable
            GridGroupingControl7.TableDescriptor.Relations.Clear()
            GridGroupingControl7.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl7.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl7.Appearance.AnyRecordFieldCell.Enabled = False
            GridGroupingControl7.GroupDropPanel.Visible = True
            GridGroupingControl7.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    'Sub InitializeRAdial()
    '    rmCompra.Icon = ImageListAdv1.Images(9)
    '    rmCompra.MenuIcon = ImageListAdv1.Images(9)

    '    Me.rmCompra.ParentControl = TabControlAdv1
    '    Me.rmCompra.MenuVisibility = True
    '    Me.rmCompra.OuterRimThickness = 20
    '    '     Me.MinimumSize = Me.Size
    '    Me.rmCompra.DisplayStyle = Syncfusion.Windows.Forms.Tools.DisplayStyle.TextAboveImage

    '    'Dim myImageNuevoCompra As System.Drawing.Image = My.Resources.icono_new_documento
    '    'ImageList1.Images.Add(myImageNuevoCompra) '0

    '    'Dim myImageEditCompra As System.Drawing.Image = My.Resources.icono_editar_compra
    '    'ImageList1.Images.Add(myImageEditCompra) '01

    '    'Dim myImageElminarDoc As System.Drawing.Image = My.Resources.icono_eliminar_compra
    '    'ImageList1.Images.Add(myImageElminarDoc) '02

    '    'Dim myImageNotasDoc As System.Drawing.Image = My.Resources.icono_Sel_nota
    '    'ImageList1.Images.Add(myImageNotasDoc) '03

    '    'Dim myImageTributo As System.Drawing.Image = My.Resources.icono_tributo
    '    'ImageList1.Images.Add(myImageTributo) '04

    '    'Dim myImageGuia As System.Drawing.Image = My.Resources.icono_guia2
    '    'ImageList1.Images.Add(myImageGuia) '05

    '    'Dim myImageCompraAlCredito As System.Drawing.Image = My.Resources.icono_compra_credito
    '    'ImageList1.Images.Add(myImageCompraAlCredito) '06

    '    'Dim myImageCompraAlContado As System.Drawing.Image = My.Resources.icono_compra_contado
    '    'ImageList1.Images.Add(myImageCompraAlContado) '07

    '    'Dim myImageNotacredito As System.Drawing.Image = My.Resources.icono_tributo3
    '    'ImageList1.Images.Add(myImageNotacredito) '08



    '    'ImageList1.ColorDepth = ColorDepth.Depth32Bit
    '    'ImageList1.ImageSize = New Size(50, 50)


    '    'rmCompra.ImageList = ImageList1
    '    'rmNuevaCompra.ImageIndex = 0
    '    'rmEditarCompra.ImageIndex = 1
    '    'rmEliminarDoc.ImageIndex = 2
    '    'rmNotas.ImageIndex = 3
    '    'rmTributos.ImageIndex = 4
    '    'rmRemision.ImageIndex = 5
    '    'rmiCompraAlcredito.ImageIndex = 6
    '    'rmiCompraAlContado.ImageIndex = 7

    '    Me.rmCompra.RimBackground = Color.FromArgb(177, 245, 247) '("#FFFFD2")
    '    '   Me.rmCompra.OuterArcColor = Color.FromArgb(229, 229, 236) '("#FFFFD2")
    'End Sub

#Region "Métodos"
    Public Class Data
        Public Sub New()
            Me.New("", "", 0, 0, 0, 0)
        End Sub

        Public Sub New(cuenta As String, descrip As String, debesoles As Decimal, habersoles As Decimal, debedolares As Decimal, haberdolares As Decimal)
            Me.CuentaCtble = cuenta
            Me.Descripcion = descrip
            Me.Debemn = debesoles
            Me.Habermn = habersoles
            Me.Debeme = debedolares
            Me.Haberme = haberdolares
        End Sub
        Private cuenta As String
        Public Property CuentaCtble() As String
            Get
                Return Me.cuenta
            End Get
            Set(value As String)
                Me.cuenta = value
            End Set
        End Property
        Private desc As String
        Public Property Descripcion() As String
            Get
                Return Me.desc
            End Get
            Set(value As String)
                Me.desc = value
            End Set
        End Property

        Private dbmn As Decimal
        Public Property Debemn() As Decimal
            Get
                Return dbmn
            End Get
            Set(ByVal value As Decimal)
                dbmn = value
            End Set
        End Property

        Private hbmn As Decimal
        Public Property Habermn() As Decimal
            Get
                Return hbmn
            End Get
            Set(ByVal value As Decimal)
                hbmn = value
            End Set
        End Property

        Private dbme As Decimal
        Public Property Debeme() As Decimal
            Get
                Return dbme
            End Get
            Set(ByVal value As Decimal)
                dbme = value
            End Set
        End Property

        Private hbme As Decimal
        Public Property Haberme() As Decimal
            Get
                Return hbme
            End Get
            Set(ByVal value As Decimal)
                hbme = value
            End Set
        End Property

    End Class

    Public Class ChildList
        Inherits ArrayList
        Implements ITypedList

#Region "ITypedList Members"

        Public Function GetItemProperties(listAccessors As PropertyDescriptor()) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            Return TypeDescriptor.GetProperties(GetType(Data))
        End Function

        Public Function GetListName(listAccessors As PropertyDescriptor()) As String Implements ITypedList.GetListName
            Return "Data"
        End Function

#End Region

    End Class

    Public Class ParentItem
        Private idDoc As String, tipo_compra As String, fec As String, tdoc As String, serie_doc As String, num As String, impmn As Decimal, tipo_cambio As Decimal, impme As Decimal
        Private m_child As ChildList
        Public Property idDocumento() As String
            Get
                Return idDoc
            End Get
            Set(value As String)
                idDoc = value
            End Set
        End Property
        Public Property tipoCompra() As String
            Get
                Return tipo_compra
            End Get
            Set(value As String)
                tipo_compra = value
            End Set
        End Property
        Public Property fecha() As String
            Get
                Return fec
            End Get
            Set(value As String)
                fec = value
            End Set
        End Property

        Public Property doc() As String
            Get
                Return tdoc
            End Get
            Set(value As String)
                tdoc = value
            End Set
        End Property

        Public Property serie() As String
            Get
                Return serie_doc
            End Get
            Set(value As String)
                serie_doc = value
            End Set
        End Property

        Public Property numero() As String
            Get
                Return num
            End Get
            Set(value As String)
                num = value
            End Set
        End Property

        Public Property importeMN() As Decimal
            Get
                Return impmn
            End Get
            Set(value As Decimal)
                impmn = value
            End Set
        End Property

        Public Property tipoCambio() As Decimal
            Get
                Return tipo_cambio
            End Get
            Set(value As Decimal)
                tipo_cambio = value
            End Set
        End Property

        Public Property importeME() As Decimal
            Get
                Return impme
            End Get
            Set(value As Decimal)
                impme = value
            End Set
        End Property

        Public Property Child() As ChildList
            Get
                Return m_child
            End Get
            Set(value As ChildList)
                m_child = value
            End Set
        End Property

        'Public Sub New()
        '    Me.New("", "", "", "", "", "", 0, 0, 0)
        'End Sub
        Public Sub New(iddoc As String, tipocom As String, fecha As String, tipodoc As String, serie As String, num As String, soles As Decimal, dolares As Decimal, tc As Decimal, dt As ChildList)
            Me.IdDocumento = iddoc
            Me.Tipo_Compra = tipocom
            Me.Fecha = fecha
            Me.doc = tipodoc
            Me.serie = serie
            Me.numero = num
            Me.importeMN = soles
            Me.importeME = dolares
            Me.tipoCambio = tc
            Me.m_child = dt
        End Sub
    End Class

    Sub GridCabe(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = True
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub



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

        GGC.BrowseOnly = True
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

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Public Sub CargarListaXtipoRegistro(strTipoRegistro As String)
        Dim documentoLibroSA As New documentoLibroDiarioSA
        Dim dt As New DataTable()
        Dim libroBE As New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoRegistro = strTipoRegistro, .fechaPeriodo = PeriodoGeneral}

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fecha")
        dt.Columns.Add("doc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("importeME")

        Dim str As String
        For Each i As documentoLibroDiario In documentoLibroSA.ListaLibroContable(libroBE)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoRegistro
            dr(2) = str
            dr(3) = "Voucher contable"
            dr(4) = i.nroDoc
            dr(5) = i.infoReferencial
            dr(6) = i.importeMN
            dr(7) = i.tipoCambio
            dr(8) = i.importeME
            dt.Rows.Add(dr)
        Next
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Aportes"
                gridGroupingControl1.DataSource = dt
            Case "Compras"
                GridGroupingControl2.DataSource = dt
            Case "Ventas"
                GridGroupingControl3.DataSource = dt
            Case "Finanzas"
                GridGroupingControl4.DataSource = dt
            Case "Movimientos almacén"
                GridGroupingControl5.DataSource = dt
        End Select



    End Sub

    Public Sub CargarListaXtipoRegistro2(strTipoRegistro As String, GGC As GridGroupingControl)
        Dim documentoLibroSA As New documentoLibroDiarioSA '
        Dim libroBE As New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoRegistro = strTipoRegistro, .fechaPeriodo = PeriodoGeneral}
        Dim str As String
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()
        For Each i As documentoLibroDiario In documentoLibroSA.ListaLibroContable(libroBE)

            cl1 = New ChildList()
            For Each x As documentoLibroDiarioDetalle In documentoLibroSA.GetUbicar_documentoLibroDiarioDetallePorIDDocumento(i.idDocumento)
                Select Case x.tipoAsiento
                    Case "D"
                        cl1.Add(New Data(x.cuenta, x.descripcion, CDec(x.importeMN).ToString("N2"), 0, CDec(x.importeME).ToString("N2"), 0))
                    Case Else
                        cl1.Add(New Data(x.cuenta, x.descripcion, 0, CDec(x.importeMN).ToString("N2"), 0, CDec(x.importeME).ToString("N2")))
                End Select

            Next
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM HH:mm tt ")
            al.Add(New ParentItem(i.idDocumento, i.tipoRegistro, str, "Voucher contable", i.nroDoc, i.infoReferencial, CDec(i.importeMN).ToString("N2"), CDec(i.importeME).ToString("N2"), i.tipoCambio, cl1))
        Next

        GGC.DataSource = al
        GGC.Engine.SetSourceList(al)
        GGC.TableDescriptor.Columns.Clear()
        GGC.TableDescriptor.Columns.Add("idDocumento")
        GGC.TableDescriptor.Columns.Add("tipoCompra")
        GGC.TableDescriptor.Columns.Add("fecha")
        GGC.TableDescriptor.Columns.Add("doc")
        GGC.TableDescriptor.Columns.Add("serie")
        GGC.TableDescriptor.Columns.Add("numero")
        GGC.TableDescriptor.Columns.Add("importeMN")
        GGC.TableDescriptor.Columns.Add("tipoCambio")
        GGC.TableDescriptor.Columns.Add("importeME")
        Dim grd As New GridRelationDescriptor()
        grd.RelationKind = RelationKind.UniformChildList
        grd.MappingName = "Child"
        'name of  property with child arraylist
        GGC.Engine.SourceListSet.Clear()
        GGC.TableDescriptor.Relations.Add(grd)
        For Each td As GridTableDescriptor In GGC.Engine.EnumerateTableDescriptor()
            td.Appearance.AnyCell.[ReadOnly] = True
            td.AllowNew = False
        Next

    End Sub

    Public Sub CargarListaAsientosPendientesXcodigoOper(GGC As GridGroupingControl, strAprobado As String)
        Dim asientoSA As New AsientoSA '
        Dim movimientoSA As New MovimientoSA '
        Dim tabla As New tablaDetalleSA
        Dim tab As tabladetalle
        Dim str As String
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()
        For Each i As asiento In asientoSA.UbicarAsientoPorPeriodo(New DateTime(DateTime.Now.Year, MesGeneral, 1), New DateTime(AnioGeneral, MesGeneral, 1), strAprobado)

            cl1 = New ChildList()
            For Each x As movimiento In movimientoSA.UbicarMovimientosXidDocumento(i.idAsiento)
                Select Case x.tipo
                    Case "D"
                        cl1.Add(New Data(x.cuenta, x.descripcion, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2"), 0))
                    Case Else
                        cl1.Add(New Data(x.cuenta, x.descripcion, 0, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2")))
                End Select

            Next
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM HH:mm tt ")

            Dim libro As String

            tab = tabla.GetUbicarTablaID(CInt(8), CInt(i.codigoLibro))
            libro = tab.descripcion



            al.Add(New ParentItem(i.idAsiento, libro, str, i.nombreEntidad, "Sistema", i.glosa, CDec(i.importeMN).ToString("N2"), CDec(i.importeME).ToString("N2"), 0, cl1))
        Next




        GGC.DataSource = GetTableGrid2()


        GGC.DataSource = al
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        GGC.Engine.SetSourceList(al)

        Dim grd As New GridRelationDescriptor()
        grd.RelationKind = RelationKind.UniformChildList
        grd.MappingName = "Child"
        'name of  property with child arraylist
        GGC.Engine.SourceListSet.Clear()
        GGC.TableDescriptor.Relations.Add(grd)
        For Each td As GridTableDescriptor In GGC.Engine.EnumerateTableDescriptor()
            td.Appearance.AnyCell.[ReadOnly] = True
            td.AllowNew = False
        Next

    End Sub


    Dim parentTable As New DataTable
    Dim childTable As New DataTable
    'Private Sub LoadServicios()

    '    Dim dSet As New DataSet()
    '    parentTable = GetParentTable()
    '    childTable = GetChildTable()
    '    dSet.Tables.AddRange(New DataTable() {parentTable, childTable})

    '    'setup the relations
    '    Dim parentColumn As DataColumn = parentTable.Columns("id")
    '    Dim childColumn As DataColumn = childTable.Columns("id")
    '    dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

    '    Me.GridGroupingControl6.DataSource = parentTable
    '    Me.GridGroupingControl6.Engine.BindToCurrencyManager = False

    '    'Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
    '    'Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
    '    Me.GridGroupingControl6.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
    '    Me.GridGroupingControl6.TopLevelGroupOptions.ShowCaption = False

    '    GridGroupingControl6.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)

    'End Sub

    'Private Function GetParentTable() As DataTable
    '    Dim dt As New DataTable("ParentTable")
    '    Dim asientoSA As New AsientoSA
    '    dt = New DataTable("ParentTable")

    '    dt.Columns.Add(New DataColumn("idAsiento", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("libro", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("entidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("glosa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("montomn", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montome", GetType(Decimal)))


    '    For Each i As asiento In asientoSA.UbicarAsientoPorPeriodo(New DateTime(DateTime.Now.Year, MesGeneral, 1), New DateTime(AnioGeneral, MesGeneral, 1), "D")
    '        Dim dr As DataRow = dt.NewRow()
    '        Dim tabla As New tablaDetalleSA


    '        dr(0) = i.idAsiento
    '        dr(1) = tabla.GetUbicarTablaID(CInt(8), i.codigoLibro).descripcion
    '        dr(2) = i.fechaProceso
    '        dr(3) = i.glosa
    '        dr(4) = i.importeMN
    '        dr(5) = i.importeME
    '        dt.Rows.Add(dr)



    '    Next

    '    Return dt
    'End Function




    Public Sub CargarListaAsientosPendientesXcodigoDetalle(GGC As GridGroupingControl, strAprobado As String, strCodigo As String)
        Dim asientoSA As New AsientoSA '
        Dim movimientoSA As New MovimientoSA '
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()
        For Each i As asiento In asientoSA.UbicarAsientoPorPeriodoXcodigo(New DateTime(DateTime.Now.Year, MesGeneral, 1), New DateTime(AnioGeneral, MesGeneral, 1), strAprobado, strCodigo)

            cl1 = New ChildList()
            For Each x As movimiento In movimientoSA.UbicarMovimientosXidDocumento(i.idAsiento)
                Select Case x.tipo
                    Case "D"
                        cl1.Add(New Data(x.cuenta, x.descripcion, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2"), 0))
                    Case Else
                        cl1.Add(New Data(x.cuenta, x.descripcion, 0, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2")))
                End Select

            Next
            'str = Nothing
            'str = CDate(i.fechaProceso).ToString("dd-MMM HH:mm tt ")
            'al.Add(New ParentItem(i.idAsiento, i.codigoLibro, str, i.nombreEntidad, 0, i.glosa, CDec(i.importeMN).ToString("N2"), CDec(i.importeME).ToString("N2"), 0, cl1))
        Next

        GGC.DataSource = cl1
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        GGC.Engine.SetSourceList(cl1)

        Dim grd As New GridRelationDescriptor()
        grd.RelationKind = RelationKind.UniformChildList
        grd.MappingName = "Child"
        'name of  property with child arraylist
        GGC.Engine.SourceListSet.Clear()
        GGC.TableDescriptor.Relations.Add(grd)
        For Each td As GridTableDescriptor In GGC.Engine.EnumerateTableDescriptor()
            td.Appearance.AnyCell.[ReadOnly] = True
            td.AllowNew = False
        Next

    End Sub


    'Public Sub CargarListaAsientosPendientesXperiodoCompra(GGC As GridGroupingControl, strAprobado As String)
    '    Dim asientoSA As New AsientoSA '
    '    Dim movimientoSA As New MovimientoSA '
    '    Dim str As String
    '    Dim cl1 As New ChildList()
    '    Dim al As New ArrayList()
    '    For Each i As asiento In asientoSA.UbicarAsientoPorPeriodoCompra(New DateTime(DateTime.Now.Year, MesGeneral, 1), New DateTime(AnioGeneral, MesGeneral, 1), strAprobado)

    '        cl1 = New ChildList()
    '        For Each x As movimiento In movimientoSA.UbicarMovimientosXidDocumento(i.idAsiento)
    '            Select Case x.tipo
    '                Case "D"
    '                    cl1.Add(New Data(x.cuenta, x.descripcion, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2"), 0))
    '                Case Else
    '                    cl1.Add(New Data(x.cuenta, x.descripcion, 0, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2")))
    '            End Select

    '        Next
    '        str = Nothing
    '        str = CDate(i.fechaProceso).ToString("dd-MMM HH:mm tt ")
    '        al.Add(New ParentItem(i.idAsiento, i.codigoLibro, str, i.nombreEntidad, 0, i.glosa, CDec(i.importeMN).ToString("N2"), CDec(i.importeME).ToString("N2"), 0, cl1))
    '    Next

    '    GGC.DataSource = al
    '    GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    '    GGC.Engine.SetSourceList(al)

    '    Dim grd As New GridRelationDescriptor()
    '    grd.RelationKind = RelationKind.UniformChildList
    '    grd.MappingName = "Child"
    '    'name of  property with child arraylist
    '    GGC.Engine.SourceListSet.Clear()
    '    GGC.TableDescriptor.Relations.Add(grd)
    '    For Each td As GridTableDescriptor In GGC.Engine.EnumerateTableDescriptor()
    '        td.Appearance.AnyCell.[ReadOnly] = True
    '        td.AllowNew = False
    '    Next

    'End Sub


    Public Sub CargarListaAsientosPendientesXperiodo(GGC As GridGroupingControl, strAprobado As String)
        Dim asientoSA As New AsientoSA '
        Dim movimientoSA As New MovimientoSA '
        Dim str As String
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()
        For Each i As asiento In asientoSA.UbicarAsientoPorPeriodo(New DateTime(DateTime.Now.Year, MesGeneral, 1), New DateTime(AnioGeneral, MesGeneral, 1), strAprobado)

            cl1 = New ChildList()
            For Each x As movimiento In movimientoSA.UbicarMovimientosXidDocumento(i.idAsiento)
                Select Case x.tipo
                    Case "D"
                        cl1.Add(New Data(x.cuenta, x.descripcion, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2"), 0))
                    Case Else
                        cl1.Add(New Data(x.cuenta, x.descripcion, 0, CDec(x.monto).ToString("N2"), 0, CDec(x.montoUSD).ToString("N2")))
                End Select

            Next
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM HH:mm tt ")
            al.Add(New ParentItem(i.idAsiento, i.codigoLibro, str, i.nombreEntidad, 0, i.glosa, CDec(i.importeMN).ToString("N2"), CDec(i.importeME).ToString("N2"), 0, cl1))
        Next

        GGC.DataSource = al
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        GGC.Engine.SetSourceList(al)

        Dim grd As New GridRelationDescriptor()
        grd.RelationKind = RelationKind.UniformChildList
        grd.MappingName = "Child"
        'name of  property with child arraylist
        GGC.Engine.SourceListSet.Clear()
        GGC.TableDescriptor.Relations.Add(grd)
        For Each td As GridTableDescriptor In GGC.Engine.EnumerateTableDescriptor()
            td.Appearance.AnyCell.[ReadOnly] = True
            td.AllowNew = False
        Next

    End Sub

    Public Sub EliminarAsiento(intIdAsiento As Integer)
        Dim asientoSA As New AsientoSA
        asientoSA.DeletePorIdAsiento(intIdAsiento)
    End Sub

    Public Sub EliminarLibroDiario(intIdDocumento As Integer)
        Dim asientoSA As New documentoLibroDiarioSA
        asientoSA.DeleteLibroDiario(intIdDocumento)
    End Sub

#End Region

    Private Sub frmMasterLibro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    'Private Sub setRadialMenuLocation()
    '    Dim locationX As Integer = 0
    '    Dim locationY As Integer = 0
    '    locationX = (Cursor.Position.X + Me.rmCompra.Width / 8)
    '    If locationX + Me.rmCompra.Width > Screen.PrimaryScreen.Bounds.Width Then
    '        locationX = Screen.PrimaryScreen.Bounds.Width - Me.rmCompra.Width
    '    End If
    '    locationY = Cursor.Position.Y - Me.rmCompra.Height / 2
    '    If locationY + Me.rmCompra.Height > Screen.PrimaryScreen.Bounds.Height Then
    '        locationY = Screen.PrimaryScreen.Bounds.Height - Me.rmCompra.Height
    '    End If
    '    Dim location As New Point(locationX, locationY)
    '    Me.rmCompra.ShowRadialMenu(location)
    '    Me.rmCompra.PopupHost.Location = location
    '    If Me.rmCompra.PopupHost.Location.Y < 0 Then
    '        Me.rmCompra.PopupHost.Location = New Point(Me.rmCompra.PopupHost.Location.X, 0)
    '    End If
    'End Sub

    'Private Sub rmCompra_BeforeCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    If Me.rmCompra.MenuVisibility Then
    '        Me.rmCompra.MenuVisibility = False
    '        Me.rmCompra.ItemOnLoad = Nothing
    '        Me.rmCompra.Refresh()
    '    End If
    'End Sub
    Private Sub frmMasterLibro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = TabControlAdv1
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv9.Parent = Nothing
        TabPageAdv6.Parent = Nothing
        TabPageAdv11.Parent = Nothing
        TabPageAdv16.Parent = Nothing

        CargarListaXtipoRegistro2("AS-M", GridGroupingControl3)
        btnAprobar.Visible = False
        btEditar.Visible = True
        ToolStripButton1.Visible = True
        ToolStripButton2.Visible = False


        ToolStripLabel2.Text = "Período: " & PeriodoGeneral
        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Eliminar comprobante", ImageListAdv1.Images(10))
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.gridGroupingControl1.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown

        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked2
        AddHandler Me.GridGroupingControl2.TableControlMouseDown, AddressOf gridGroupingControl2_TableControlMouseDown

        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked3
        AddHandler Me.GridGroupingControl2.TableControlMouseDown, AddressOf gridGroupingControl3_TableControlMouseDown

        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked4
        AddHandler Me.GridGroupingControl2.TableControlMouseDown, AddressOf gridGroupingControl4_TableControlMouseDown

        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked5
        AddHandler Me.GridGroupingControl2.TableControlMouseDown, AddressOf gridGroupingControl5_TableControlMouseDown

        'AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked6
        'AddHandler Me.GridGroupingControl6.TableControlMouseDown, AddressOf gridGroupingControl6_TableControlMouseDown

    End Sub

    'Private Sub contextMenuStrip_ItemClicked6(sender As Object, e As ToolStripItemClickedEventArgs)
    '    If Not IsNothing(Me.GridGroupingControl6.Table.CurrentRecord) Then
    '        If e.ClickedItem.Text = "Aprobar cuentas seleccionadas" Then
    '            If Not IsNothing(Me.GridGroupingControl6.Table.CurrentRecord) Then

    '            End If
    '        End If
    '    End If
    'End Sub


    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Eliminar comprobante" Then
                If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                    Me.gridGroupingControl1.Table.CurrentRecord.Delete()
                End If
            End If
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked2(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.GridGroupingControl2.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Eliminar comprobante" Then
                If Not IsNothing(Me.GridGroupingControl2.Table.CurrentRecord) Then
                    Me.GridGroupingControl2.Table.CurrentRecord.Delete()
                End If
            End If
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked3(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.GridGroupingControl3.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Eliminar comprobante" Then
                If Not IsNothing(Me.GridGroupingControl3.Table.CurrentRecord) Then
                    Me.GridGroupingControl3.Table.CurrentRecord.Delete()
                End If
            End If
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked4(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.GridGroupingControl4.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Eliminar comprobante" Then
                If Not IsNothing(Me.GridGroupingControl4.Table.CurrentRecord) Then
                    Me.GridGroupingControl4.Table.CurrentRecord.Delete()
                End If
            End If
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked5(sender As Object, e As ToolStripItemClickedEventArgs)
        If Not IsNothing(Me.GridGroupingControl5.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Eliminar comprobante" Then
                If Not IsNothing(Me.GridGroupingControl5.Table.CurrentRecord) Then
                    Me.GridGroupingControl5.Table.CurrentRecord.Delete()
                End If
            End If
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.gridGroupingControl1.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.gridGroupingControl1.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            gridGroupingControl1.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub gridGroupingControl2_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.GridGroupingControl2.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.GridGroupingControl2.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            GridGroupingControl2.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub gridGroupingControl3_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.GridGroupingControl3.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.GridGroupingControl3.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            GridGroupingControl3.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub gridGroupingControl4_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.GridGroupingControl4.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.GridGroupingControl4.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            GridGroupingControl4.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub gridGroupingControl5_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.GridGroupingControl5.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.GridGroupingControl5.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            GridGroupingControl5.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    'Private Sub gridGroupingControl6_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
    '    Dim row As Integer = 0, col As Integer = 0
    '    Me.GridGroupingControl6.TableControl.PointToRowCol(e.Inner.Location, row, col)
    '    Dim style As GridTableCellStyleInfo = Me.GridGroupingControl6.TableControl.GetTableViewStyleInfo(row, col)
    '    'To check whether it is columnheadercell
    '    If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
    '        '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
    '    Else
    '        'If it is not column header cell
    '        GridGroupingControl6.ContextMenuStrip = ContextMenuStrip
    '    End If
    'End Sub

    Private Sub TabControlAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlAdv2.SelectedIndexChanged

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Select Case treeViewAdv2.SelectedNode.Text

            Case "Registro de aportes"



            Case "Compras"
                With frmnuevoLibroDiario

                    .valorNode = treeViewAdv2.SelectedNode.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                    'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                    'Me.pcProveedor.ShowPopup(Point.Empty)
                End With
            Case "Ventas"
                With frmnuevoLibroDiario

                    .valorNode = treeViewAdv2.SelectedNode.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                    'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                    'Me.pcProveedor.ShowPopup(Point.Empty)
                End With
            Case "Crear cuenta manual"
                With frmnuevoLibroDiario
                    .valorNode = treeViewAdv2.SelectedNode.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                    'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                    'Me.pcProveedor.ShowPopup(Point.Empty)
                End With
            Case "Movimientos almacén"
                With frmnuevoLibroDiario
                    .valorNode = treeViewAdv2.SelectedNode.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                    'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                    'Me.pcProveedor.ShowPopup(Point.Empty)
                End With
            Case "Asientos pendientes"
                With frmnuevoLibroDiario
                    .valorNode = treeViewAdv2.SelectedNode.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                    'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                    'Me.pcProveedor.ShowPopup(Point.Empty)
                End With
            Case "Asientos aprobados"
                With frmnuevoLibroDiario
                    .valorNode = treeViewAdv2.SelectedNode.Text
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                    'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                    'Me.pcProveedor.ShowPopup(Point.Empty)
                End With
                'Case "Finanzas"

                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '        'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                '        'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                '        'Me.pcProveedor.ShowPopup(Point.Empty)
                '    End With
                'Case "Registro de aportes"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear aporte"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '        'Me.pcProveedor.ParentControl = Me.TabControlAdv1
                '        'Me.pcProveedor.Font = New Font("Segoe UI", 8)
                '        'Me.pcProveedor.ShowPopup(Point.Empty)
                '    End With
            Case "Aportes"



            Case "Compras Pr."
            Case "Ventas Pr."



            Case "Ver Asientos manuales"
                With frmnuevoLibroDiario
                    'btOperacion.Text = "Crear cuenta manual"
                    .valorNode = "AS-M"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With

                'Case "Cuentas Por Pagar"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                'Case "Anticipos Otorgados"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                'Case "Prestamos Otorgados"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                'Case "Cuentas Por Cobrar"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                'Case "Anticipos Recibidos"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                'Case "Prestamos Recibidos"
                '    With frmnuevoLibroDiario
                '        'btOperacion.Text = "Crear cuenta manual"
                '        .valorNode = treeViewAdv2.SelectedNode.Text
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With


        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Asientos Programados"
                btEditar.Visible = False
                ToolStripButton2.Visible = True
                ToolStripButton1.Visible = False
                btnAprobar.Visible = False
            Case "Ver Asientos manuales"
                btEditar.Visible = True
                ToolStripButton2.Visible = True
                ToolStripButton1.Visible = True
                btnAprobar.Visible = False
            Case "Hoja de Trabajo", "Plan Contable"
                btEditar.Visible = False
                ToolStripButton2.Visible = False
                ToolStripButton1.Visible = False
                btnAprobar.Visible = False
            Case "Registro de aportes"
                btEditar.Visible = True
                ToolStripButton2.Visible = True
                ToolStripButton1.Visible = True
                btnAprobar.Visible = False
        End Select
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ver Asientos manuales"
                'btOperacion.Visible = True
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv16.Parent = Nothing

                CargarListaXtipoRegistro2("AS-M", GridGroupingControl3)

            Case "Hoja de Trabajo"
                Dim f As New FrmHojaTrabajo
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            Case "Asientos pendientes"

                'btOperacion.Visible = True
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv16.Parent = Nothing
                ToolStripButton2.Visible = False
                TabPageAdv6.Parent = TabControlAdv1
                CargarListaAsientosPendientesXperiodo(GridGroupingControl6, "D")
                TabPageAdv6.Text = "Asientos pendientes (" & GridGroupingControl6.Table.Records.Count & ")"


            Case "Asientos Programados"

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                ToolStripButton2.Visible = False
                TabPageAdv6.Parent = TabControlAdv1
                TabPageAdv16.Parent = TabControlAdv5

                CargarListaAsientosPendientesXcodigoOper(GridGroupingControl6, "D")
                'ListaDetalle("D")

                TabPageAdv6.Text = "Asientos pendientes (" & GridGroupingControl6.Table.Records.Count & ")"

            Case "Asientos aprobados"
                'btOperacion.Visible = True
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv6.Parent = TabControlAdv1
                TabPageAdv16.Parent = Nothing
                CargarListaAsientosPendientesXperiodo(GridGroupingControl6, "A")
                TabPageAdv6.Text = "Asientos aprobados (" & GridGroupingControl6.Table.Records.Count & ")"
         
            Case "Registro de aportes"
                'btOperacion.Visible = True
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv16.Parent = Nothing
                TabPageAdv11.Parent = TabControlAdv1
                ListaSaldoAporteXperiodo()


            Case "Plan Contable"
                Dim f As New frmcatalogoCuentas
                f.ShowDialog()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub gridGroupingControl1_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles gridGroupingControl1.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.gridGroupingControl1.TableControl.Selections.Clear()
        End If
    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub
    Private Sub gridGroupingControl1_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, gridGroupingControl1)
    End Sub

    Private Sub GridGroupingControl2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridGroupingControl2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.gridGroupingControl1.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub GridGroupingControl2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles GridGroupingControl2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, GridGroupingControl2)
    End Sub

    Private Sub gridGroupingControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles gridGroupingControl1.MouseDown
        'Me.rmCompra.Hide()
        'Me.rmCompra.HidePopup()
        'Me.rmCompra.ItemOnLoad = Nothing
        'rmCompra.ResetInnerCircleRadius()
        'Me.rmCompra.MenuVisibility = False
        'Me.rmCompra.Refresh()
    End Sub

    Private Sub gridGroupingControl1_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles gridGroupingControl1.SelectedRecordsChanged
        'Me.rmCompra.ParentControl = Me.TabControlAdv1
        'setRadialMenuLocation()
        ''Me.rmCompra.CenterCircleRadiusFactor = New System.Drawing.Size(34, 34)
        ''Me.rmCompra.Hide()
        ''Me.rmCompra.HidePopup()
        'Me.rmCompra.ItemOnLoad = Nothing
        'rmCompra.ResetInnerCircleRadius()
        'Me.rmCompra.MenuVisibility = False
        'Me.rmCompra.Refresh()
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim asientoBE As New asiento
        Dim ListaAsientoBE As New List(Of asiento)
        Dim asientoSA As New AsientoSA

        If GridGroupingControl6.Table.SelectedRecords.Count > 0 Then
            If MessageBox.Show("Desea aprobar los asientos seleccionados", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For Each rec As SelectedRecord In GridGroupingControl6.Table.SelectedRecords
                    asientoBE = New asiento
                    asientoBE.idAsiento = rec.Record.GetValue("idDocumento")
                    asientoBE.tipo = "A"
                    ListaAsientoBE.Add(asientoBE)
                Next
                asientoSA.ActualizarEstadoAprobado(ListaAsientoBE)
                MessageBox.Show("Asientos aprobados correctamente", "Done!", Nothing, MessageBoxIcon.Information)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridGroupingControl6_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If
            Me.GridGroupingControl6.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub GridGroupingControl6_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub GridGroupingControl6_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs)
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, GridGroupingControl6)
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor


        Select Case treeViewAdv2.SelectedNode.Text
            Case "Registro de aportes"
                If Not IsNothing(Me.dgvAportes.Table.CurrentRecord) Then
                    With frmAportesInicio
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .txtFechaComprobante.ShowUpDown = True
                        .UbicarSaldoPorIdDocumento(Me.dgvAportes.Table.CurrentRecord.GetValue("idDocumento"))
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With
                End If

            Case Else
                If Not IsNothing(GridGroupingControl3.Table.CurrentRecord) Then
                    Dim frm As New frmnuevoLibroDiario(GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento"))
                    frm.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    frm.Tag = "editar"
                    frm.StartPosition = FormStartPosition.CenterParent
                    frm.ShowDialog()
                End If
        End Select

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Registro de aportes"
                If Not IsNothing(Me.dgvAportes.Table.CurrentRecord) Then

                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarSaldoAporte(Me.dgvAportes.Table.CurrentRecord.GetValue("idDocumento"))
                        Me.dgvAportes.Table.CurrentRecord.Delete()
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        '    lblEstado.Image = My.Resources.ok4
                        lblEstado.Text = "Registro eliminado!"
                    End If

                End If

            Case Else
                If Not IsNothing(GridGroupingControl6.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el asiento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        EliminarAsiento(GridGroupingControl6.Table.CurrentRecord.GetValue("idDocumento"))
                    End If
                End If


                If Not IsNothing(GridGroupingControl2.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el asiento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        EliminarLibroDiario(GridGroupingControl2.Table.CurrentRecord.GetValue("idDocumento"))
                    End If
                End If

                If Not IsNothing(GridGroupingControl3.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el asiento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        EliminarLibroDiario(GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento"))
                    End If
                End If

                If Not IsNothing(GridGroupingControl4.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el asiento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        EliminarLibroDiario(GridGroupingControl4.Table.CurrentRecord.GetValue("idDocumento"))
                    End If
                End If

                If Not IsNothing(GridGroupingControl5.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el asiento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        EliminarLibroDiario(GridGroupingControl5.Table.CurrentRecord.GetValue("idDocumento"))
                    End If
                End If

        End Select

    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click

        'Me.GridGroupingControl6.Table.SelectedRecords.DeleteAll()
        'For Each tbl As Table In Me.GridGroupingControl6.Table.RelatedTables
        '    tbl.SelectedRecords.DeleteAll()
        'Next

        'Dim cc As GridCurrentCell = Me.GridGroupingControl6.TableControl.CurrentCell
        'Dim nt As NestedTable = Me.GridGroupingControl6.Table.Records(cc.RowIndex).NestedTables(0)
        'Dim ct As ChildTable = nt.ChildTable
        ''To get access to a specific record in that child table
        ' ''Dim recordInNestedTable As Record = ct.Records(3)
        ''To get access to all records in that child table
        'For Each rec As Record In ct.Records
        '    ' this.richTextBox1.Text += rec.ToString();
        '    '[or]
        '    GridGroupingControl6.Table.Records.DeleteRecords(rec)
        '    Me.GridGroupingControl6.Table.Records.DeleteRecords(rec)
        '    rec.Delete()
        '    '  MsgBox(rec.GetValue("idDocume"))
        '    'Me.richTextBox1.Text += rec.GetValue("childID") + Constants.vbTab + rec.GetValue("Name").ToString() & Constants.vbLf
        'Next rec
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub dgvAportes_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvAportes.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvAportes.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvAportes_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvAportes.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvAportes)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Aportes"

                CargarListaXtipoRegistro2("AP", gridGroupingControl1)
                'btOperacion.Text = "Crear cuenta manual"
            Case "Compras"

                CargarListaXtipoRegistro2("CM", GridGroupingControl2)
                'btOperacion.Text = "Crear cuenta manual"
            Case "Ventas"
                CargarListaXtipoRegistro2("VT", GridGroupingControl3)
                'btOperacion.Text = "Crear cuenta manual"
            Case "Finanzas"

                CargarListaXtipoRegistro2("FI", GridGroupingControl4)
                'btOperacion.Text = "Crear cuenta manual"
            Case "Movimientos almacén"

                CargarListaXtipoRegistro2("AL", GridGroupingControl5)
                'btOperacion.Text = "Crear cuenta manual"
            Case "Asientos pendientes"

                CargarListaAsientosPendientesXperiodo(GridGroupingControl6, "D")
                TabPageAdv6.Text = "Asientos pendientes (" & GridGroupingControl6.Table.Records.Count & ")"
                'btOperacion.Text = "Crear cuenta manual"
            Case "Asientos aprobados"
                CargarListaAsientosPendientesXperiodo(GridGroupingControl6, "A")
                TabPageAdv6.Text = "Asientos aprobados (" & GridGroupingControl6.Table.Records.Count & ")"
                'btOperacion.Text = "Crear cuenta manual"
            Case "Registro de aportes"
                ListaSaldoAporteXperiodo()
                'btOperacion.Text = "Crear aporte"
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridGroupingControl7_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl7.TableControlCellClick

    End Sub

    Private Sub CuentasXPagarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasXPagarToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        With frmnuevoLibroDiario
            .valorNode = "AS-M"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        With frmAportesInicio
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        Me.Cursor = Cursors.WaitCursor

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Registro de aportes"
                If Not IsNothing(Me.dgvAportes.Table.CurrentRecord) Then
                    With frmAportesInicio
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .txtFechaComprobante.ShowUpDown = True
                        .UbicarSaldoPorIdDocumento(Me.dgvAportes.Table.CurrentRecord.GetValue("idDocumento"))
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With
                End If

            Case Else
                If Not IsNothing(GridGroupingControl3.Table.CurrentRecord) Then
                    Dim frm As New frmnuevoLibroDiario(GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento"))
                    frm.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    frm.Tag = "editar"
                    frm.StartPosition = FormStartPosition.CenterParent
                    frm.ShowDialog()
                End If
        End Select

        Me.Cursor = Cursors.Arrow
    End Sub
End Class