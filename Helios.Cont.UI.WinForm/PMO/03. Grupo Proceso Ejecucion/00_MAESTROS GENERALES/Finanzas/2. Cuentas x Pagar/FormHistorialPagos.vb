Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Windows.Forms.Grid

Public Class FormHistorialPagos

#Region "Variables"
    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private anioSel As String
    Private mesSel As String
    Dim ventaSA As New documentoVentaAbarrotesSA
    Private Const FormatoFecha As String = "yyyy-MM-dd"
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGrid(GridPagos)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos"

    Public Sub CargarHistorial(idDoc As Integer)

        Dim documentoSA = New DocumentoCompraSA
        Dim montoReclamacion As Decimal = 0
        Dim Lista = documentoSA.HistorialDePagos(idDoc)

        Lista = (From i In Lista Order By i.fechaDoc Ascending).ToList

        For Each i In Lista
            Me.GridPagos.Table.AddNewRecord.SetCurrent()
            Me.GridPagos.Table.AddNewRecord.BeginEdit()
            Me.GridPagos.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.GridPagos.Table.CurrentRecord.SetValue("fecha", i.fechaDoc)
            Me.GridPagos.Table.CurrentRecord.SetValue("tipoDocumento", i.tipoDoc)
            Me.GridPagos.Table.CurrentRecord.SetValue("nombreDoc", i.terminos)
            Me.GridPagos.Table.CurrentRecord.SetValue("numeroVenta", i.numeroDoc)
            Me.GridPagos.Table.CurrentRecord.SetValue("tipoOperacion", i.tipoOperacion)
            Me.GridPagos.Table.CurrentRecord.SetValue("operacion", i.modulo)
            Me.GridPagos.Table.CurrentRecord.SetValue("ImporteNacional", i.importeTotal)
            'Me.GridPagos.Table.CurrentRecord.SetValue("ImporteExtranjero", i.importeUS)
            If (i.monedaDoc = "1") Then
                Me.GridPagos.Table.CurrentRecord.SetValue("ImporteExtranjero", 0)
            Else
                Me.GridPagos.Table.CurrentRecord.SetValue("ImporteExtranjero", i.ImportePagoME)
            End If
            Me.GridPagos.Table.CurrentRecord.SetValue("moneda", If(i.monedaDoc = "1", "Nacional", "Extranjero"))
            Me.GridPagos.Table.AddNewRecord.EndEdit()

            If i.tipoCompra = "EXD" Then
                montoReclamacion = montoReclamacion - i.importeTotal
            End If

        Next
        lblReclamacion.Text = montoReclamacion

    End Sub


    Sub GetTableGrid()
        Dim dt As New DataTable()
        'dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoDocumento")
        dt.Columns.Add("nombreDoc")
        dt.Columns.Add("numeroVenta")
        dt.Columns.Add("tipoOperacion")
        dt.Columns.Add("operacion")
        dt.Columns.Add("ImporteNacional")
        dt.Columns.Add("ImporteExtranjero")
        dt.Columns.Add("moneda")



        GridPagos.DataSource = dt
    End Sub

    Public Sub FormatoGrid(GGC As GridGroupingControl)
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
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub




#End Region

    Private Sub FormHistorialPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class