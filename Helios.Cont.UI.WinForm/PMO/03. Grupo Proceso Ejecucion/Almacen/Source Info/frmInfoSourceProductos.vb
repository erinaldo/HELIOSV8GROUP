Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmInfoSourceProductos
    Inherits frmMaster
    Dim card As New GridCardView()

    Public Sub New(intIdAlmacen As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        UbicarProductoXAlmacen(intIdAlmacen)



        Me.comboBoxAdv2.SelectedIndex = 1
        Me.ComboBoxAdv1.SelectedIndex = 0
        ' Add any initialization after the InitializeComponent() call.

        card.CaptionField = "descripcion"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()

    End Sub

    Private Sub Settings()
        card.ShowCardCellBorders = If(checkBox1.Checked, True, False)
        card.ApplyRoundedCorner = If(checkBox3.Checked, True, False)
        card.BrowseOnly = If(checkBox4.Checked, True, False)
        card.ShowCaption = If(checkBox2.Checked, True, False)
        AutoFit()
    End Sub

    Private Sub AutoFit()
        Me.GDBSource.Model.ColWidths.ResizeToFit(GridRangeInfo.Table())
        Me.GDBSource.Refresh()
    End Sub

#Region "Métodos"
    Private Sub UbicarProductoXAlmacen(intIdAlmacen As Integer)

        Dim dt As New DataTable
        Dim tabla As New tablaDetalleSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim tablaSA As New tablaDetalleSA

        dt.Columns.Add(New DataColumn("idEstablecimiento", GetType(Integer)))
        'lower case p
        dt.Columns.Add(New DataColumn("NomAlmacen", GetType(String)))
        'dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String))) '
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))

        dt.Columns.Add(New DataColumn("idUnidad", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Presentacion", GetType(String)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetListaProductosPorAlmacen(intIdAlmacen)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEstablecimiento
            dr(1) = i.NomAlmacen
            'dr(2) = i.idItem
            dr(2) = strGravado
            dr(3) = tablaSA.GetUbicarTablaID(5, i.tipoExistencia).descripcion
            dr(4) = i.descripcion
            dr(5) = i.idUnidad
            dr(6) = i.unidadMedida
            dr(7) = i.cantidad
            dr(8) = i.importeSoles
            dr(9) = i.Presentacion
            dt.Rows.Add(dr)

            'Me.GDBSource.DataSource = dt
            'Me.StartPosition = FormStartPosition.CenterScreen
            'Me.GDBSource.BackColor = Color.White
        Next

        Me.GDBSource.DataSource = dt
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.GDBSource.BackColor = Color.White

    End Sub
#End Region

    Private Sub frmInfoSourceProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         Me.GDBSource.Model.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
    End Sub

    Private Sub comboBoxAdv2_Click(sender As Object, e As EventArgs) Handles comboBoxAdv2.Click

    End Sub

    Private Sub comboBoxAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxAdv2.SelectedIndexChanged
        Select Case Me.comboBoxAdv2.SelectedItem.ToString()
            Case "MergedLabels"
                card.CardStyle = CardStyle.MergedLabels
                Exit Select
            Case "StandardLabels"
                card.CardStyle = CardStyle.StandardLabels
                Me.GDBSource.Model.ColWidths(2) = 25
                Exit Select
        End Select
        AutoFit()
    End Sub

    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedIndexChanged
        Select Case Me.ComboBoxAdv1.SelectedItem.ToString()
            Case "Office2010Blue"
                card.VisualStyle = CardVisualStyles.Office2010Blue
                Exit Select
            Case "Office2010Black"
                card.VisualStyle = CardVisualStyles.Office2010Black
                Exit Select
            Case "Office2010Silver"
                card.VisualStyle = CardVisualStyles.Office2010Silver
                Exit Select
            Case "Office2007Blue"
                card.VisualStyle = CardVisualStyles.Office2007Blue
                Exit Select
            Case "Office2007Black"
                card.VisualStyle = CardVisualStyles.Office2007Black
                Exit Select
            Case "Office2007Silver"
                card.VisualStyle = CardVisualStyles.Office2007Silver
                Exit Select
            Case "Metro"
                card.VisualStyle = CardVisualStyles.Metro
                Exit Select
            Case "System"
                card.VisualStyle = CardVisualStyles.System
                Exit Select
            Case Else
                card.VisualStyle = CardVisualStyles.None
                Exit Select
        End Select
        AutoFit()
    End Sub

    Private Sub checkBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckStateChanged
        Settings()
    End Sub

    Private Sub checkBox2_CheckStateChanged(sender As Object, e As EventArgs) Handles checkBox2.CheckStateChanged
        Settings()
    End Sub

    Private Sub checkBox3_CheckStateChanged(sender As Object, e As EventArgs) Handles checkBox3.CheckStateChanged
        Settings()
    End Sub

    Private Sub checkBox4_CheckStateChanged(sender As Object, e As EventArgs) Handles checkBox4.CheckStateChanged
        Settings()
    End Sub
End Class