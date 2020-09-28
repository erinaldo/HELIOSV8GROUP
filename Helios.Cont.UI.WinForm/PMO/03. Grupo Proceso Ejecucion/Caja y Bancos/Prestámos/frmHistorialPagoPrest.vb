Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmHistorialPagoPrest

    Public Property IdDocumentoCompra As Integer
    Dim colorx As New GridMetroColors()
    Dim tipoanticipo As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompras)

    End Sub

#Region "metodos"


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



    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable
    Public Sub LoadHistorialCajasXcompra()

        Dim dSet As New DataSet()
        parentTable = getParentCaja(IdDocumentoCompra)
        ChildTable = getChildCaja(IdDocumentoCompra)
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = ChildTable.Columns("idDocumento")

        'Dim parentColumn As DataColumn = parentTable.Columns("fecha")
        'Dim childColumn As DataColumn = ChildTable.Columns("fecha")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvCompras.DataSource = parentTable
        Me.dgvCompras.Engine.BindToCurrencyManager = False

        Me.dgvCompras.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCompras.TopLevelGroupOptions.ShowCaption = False


    End Sub



    Private Function getParentCaja(intIdCompra As Integer) As DataTable
        Dim objLista As New DocumentoCajaSA()
        Dim objLista2 As New documentoAnticipoSA()

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("operacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In objLista.ListadoComprobantesPagoPrestamos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocPago
            dr(3) = i.numeroDoc
            dr(4) = i.moneda
            dr(5) = i.tipoCambio
            dr(6) = i.montoSoles
            dr(7) = i.montoUsd
            dr(8) = i.tipoOperacion
            dr(9) = "EFECTIVO"
            dt.Rows.Add(dr)
        Next
      
        Return dt
    End Function



    Private Function getChildCaja(intIdDocume As Integer) As DataTable
        Dim objLista As New DocumentoCajaSA()
        Dim objLista2 As New documentoAnticipoSA()

        Dim dt As New DataTable("ChildTable")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DetalleItems", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        Dim str As String
        For Each i As documentoCajaDetalle In objLista.ListadoCajaDetallePagoPrestamo(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.montoSoles
            dr(3) = i.montoUsd
            dr(4) = str
            dt.Rows.Add(dr)
        Next


        Return dt
    End Function
#End Region


    Private Sub frmHistorialPagoPrest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class