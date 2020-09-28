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
Public Class frmSeleccionArticulosVenta
    Inherits frmMaster

    Public Sub New(lista As List(Of totalesAlmacen), codbarra As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG2(gridGroupingControl1)

        Dim articulo As New detalleitems
        Dim articuloSA As New detalleitemsSA

        articulo = articuloSA.GetExistenciaByCodeBar(codbarra)
        txtCodigo.Text = articulo.codigo
        txtArticulo.Text = articulo.descripcionItem
        txtArticulo.Tag = articulo.codigodetalle

        GetListaProductosEmpresaByCodigoBarra(lista)
    End Sub
#Region "Métodos"
    Sub GridCFG2(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx = New GridMetroColors()
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

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub GetListaProductosEmpresaByCodigoBarra(lista As List(Of totalesAlmacen))
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))
            dt.Columns.Add("estable")

            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing

            For Each i As totalesAlmacen In lista
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares

                    dr(12) = cprecioVentaFinalMenorMN
                    dr(13) = cprecioVentaFinalMenorME
                    dr(14) = cprecioVentaFinalMayorMN
                    dr(15) = cprecioVentaFinalMayorME
                    dr(16) = cprecioVentaFinalGMayorMN
                    dr(17) = cprecioVentaFinalGMayorME
                    dr(18) = i.idAlmacen
                    dr(19) = i.NomAlmacen
                    dr(20) = i.idEstablecimiento
                    dt.Rows.Add(dr)
                End If
            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellDoubleClick
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim totalSA As New TotalesAlmacenSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance
        Dim n As New RecuperarCarteras
        datos.Clear()
        Try
            If gridGroupingControl1.Table.Records.Count > 0 Then
                Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))

                If listaPrecios.Count > 0 Then
                    Me.Tag = gridGroupingControl1.Table.CurrentRecord
                    n.Precio = listaPrecios(0)
                    datos.Add(n)
                    Close()
                Else
                    MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmSeleccionArticulosVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class