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

Public Class frmBuscarVentas
    Inherits frmMaster
    Dim colorx As GridMetroColors
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Sub GridCFG()
        Me.gridGroupingControl1.TableOptions.ShowRowHeader = False
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        Me.gridGroupingControl1.SetMetroStyle(colorx)
        Me.gridGroupingControl1.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        Me.gridGroupingControl1.AllowProportionalColumnSizing = False
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        Me.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 25
        Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 20
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Public Property RucProveedor() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG()
        filters()
    End Sub

#Region "Métodos"
    Sub filters()
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = True
        'Enable the filter for each columns 
        '   For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
        gridGroupingControl1.TableDescriptor.Columns("numero").AllowFilter = True
        '   Next
        filter.WireGrid(gridGroupingControl1)
    End Sub
    Private Sub UbicarCompraNroSerie()
        Dim documentoCompraSA As New documentoVentaAbarrotesSA
        Dim documentoCompra As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("fecha", GetType(String))

        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("comprador", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMn", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))

        documentoCompra = documentoCompraSA.GetListarVentasPorPeriodoCobrados(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_VENTA.VENTA_AL_TICKET)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoVenta
                dr(2) = str
                dr(3) = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion '.Substring(0, 3)
                dr(4) = i.nombrePedido
                dr(5) = i.serieVenta
                dr(6) = i.numeroVenta
                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.ImporteNacional
                dr(9) = i.ImporteExtranjero
                dt.Rows.Add(dr)
            Next
            gridGroupingControl1.DataSource = dt
            '   Me.GDB.DataSource = dt

            '    Me.GDB.ListBoxSelectionMode = SelectionMode.One

        Else

        End If
    End Sub
#End Region

    Private Sub frmBuscarVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmBuscarVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            UbicarCompraNroSerie()

        End If
    End Sub

    Private Sub txtPeriodo_TextChanged(sender As Object, e As EventArgs) Handles txtPeriodo.TextChanged

    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub gridGroupingControl1_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles gridGroupingControl1.TableControlCurrentCellControlDoubleClick
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim n As New RecuperarCarteras

        'Dim documentoCompraSA As New DocumentoCompraDetalleSA
        'If documentoCompraSA.TieneItemsEnAV(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento")) = True Then
        '    '     PanelError.Visible = True
        '    lblEstado.Text = "El comprobante posee items en tránsito," & "necesita realizar la distribución, para seguir el proceso!"
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        '    Me.Cursor = Cursors.Arrow
        'Else
        n.ID = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento")
        n.Cuenta = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("tipoDoc")
        n.Apmat = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("Serie")
        n.Appat = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("numero")
        n.NomProceso = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("tipoVenta")
        n.NomEvento = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("moneda")
        datos.Add(n)
        Dispose()
        '   End If
    End Sub
End Class