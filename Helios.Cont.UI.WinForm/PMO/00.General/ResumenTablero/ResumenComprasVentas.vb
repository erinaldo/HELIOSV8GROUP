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
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing
Imports System.Drawing.Drawing2D
Public Class ResumenComprasVentas
    Inherits frmMaster

    Dim listaDetalleGeneral As New List(Of documentocompradetalle)
    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable

    Public Sub New(dia As DateTime)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgCompras)
        GetTransacciones(dia)
        Label2.Text = "Resumen de Compras: " & dia.Date
        listaDetalleGeneral = New List(Of documentocompradetalle)
    End Sub

#Region "Métodos"
    

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


    Public Function GetListaDetalle(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim objLista As New DocumentoCompraDetalleSA()
        Dim obj As New documentocompradetalle


        For Each i As documentocompradetalle In objLista.UbicarDocumentoCompraDetalle(intIdDocumento)
            obj = New documentocompradetalle
            obj.idDocumento = i.idDocumento
            obj.descripcionItem = i.descripcionItem
            obj.unidad1 = i.unidad1
            obj.monto1 = i.monto1
            obj.importe = i.importe
            obj.importeUS = i.importeUS
            listaDetalleGeneral.Add(obj)
        Next
        Return listaDetalleGeneral
    End Function

    Private Function getChildDetalle() As DataTable
        Dim objLista As New DocumentoCompraDetalleSA()

        Dim dt As New DataTable("Detalle de la compra ")
        dt.Columns.Add(New DataColumn("Articulo", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad"))
        dt.Columns.Add(New DataColumn("U.M.", GetType(String)))
        dt.Columns.Add(New DataColumn("PUmn"))
        dt.Columns.Add(New DataColumn("Monto MN."))
        dt.Columns.Add(New DataColumn("PUme"))
        dt.Columns.Add(New DataColumn("Monto ME."))
        dt.Columns.Add(New DataColumn("iddoc", GetType(Integer)))

        For Each i As documentocompradetalle In listaDetalleGeneral
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.descripcionItem
            dr(1) = CDec(i.monto1).ToString("N2")
            dr(2) = i.unidad1
            If i.monto1 > 0 Then
                dr(3) = CDec(i.importe / i.monto1).ToString("N2")
            Else
                dr(3) = 0
            End If
            dr(4) = CDec(i.importe).ToString("N2")
            If i.monto1 > 0 Then
                dr(5) = CDec(i.importeUS / i.monto1).ToString("N2")
            Else
                dr(5) = 0
            End If
            dr(6) = CDec(i.importeUS).ToString("N2")
            dr(7) = i.idDocumento
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Sub GetTransacciones(dia As DateTime)

        Dim dSet As New DataSet()
        parentTable = GetComprasDia(dia)
        ChildTable = getChildDetalle()
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("iddoc")
        Dim childColumn As DataColumn = ChildTable.Columns("iddoc")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgCompras.DataSource = parentTable
        Me.dgCompras.Engine.BindToCurrencyManager = False

        Me.dgCompras.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgCompras.TopLevelGroupOptions.ShowCaption = False
        dgCompras.TableDescriptor.Columns("comprante").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

    End Sub

    Public Function GetComprasDia(dia As DateTime) As DataTable
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("iddoc", GetType(Integer))
        dt.Columns.Add("fecha")
        dt.Columns.Add("comprante")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipocambio")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("usuario")
        dt.Columns.Add("proveedor")

        Dim sumaCompras As Decimal = 0
        Dim sumaCredito As Decimal = 0
        Dim sumaDebito As Decimal = 0
        Dim valueMonto As Decimal = 0
        Dim valueMontoME As Decimal = 0
        For Each i In compraSA.GetListAllComprasxDia(GEstableciento.IdEstablecimiento, dia)
            Select Case i.tipoDoc
                Case "NOTA DE CREDITO"
                    sumaCredito += CDec(i.importeTotal)
                    valueMonto = CDec(i.importeTotal) * -1
                    valueMontoME = CDec(i.importeUS) * -1
                Case "NOTA DE DEBITO"
                    sumaDebito += CDec(i.importeTotal)
                    valueMonto = CDec(i.importeTotal)
                    valueMontoME = CDec(i.importeUS)
                Case Else
                    sumaCompras += CDec(i.importeTotal)
                    valueMonto = CDec(i.importeTotal)
                    valueMontoME = CDec(i.importeUS)
            End Select
            dt.Rows.Add(i.idDocumento, i.fechaDoc, String.Concat(i.tipoDoc, ": ", CInt(i.serie), "-", CInt(i.numeroDoc)),
                        i.monedaDoc, i.tcDolLoc, CDec(valueMonto).ToString("N2"),
                           CDec(valueMontoME).ToString("N2"), i.usuarioActualizacion, i.NombreEntidad)


            GetListaDetalle(i.idDocumento)
        Next

        lblComprasDelDia.Text = sumaCompras.ToString("N2")
        Label8.Text = sumaCredito.ToString("N2")
        Label10.Text = sumaDebito.ToString("N2")
        Return dt
    End Function
#End Region

    Private Sub ResumenComprasVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ResumenComprasVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblEstablecimiento.Text = "Establecimiento: " & GEstableciento.NombreEstablecimiento

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class