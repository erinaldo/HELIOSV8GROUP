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
Public Class frmInfoSourceAlmacen
    Inherits frmMaster
    Dim card As New GridCardView()

    Public Sub New(strTipoMov As String, intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        UbicarDocumentoXIdDocumento(strTipoMov, intIdDocumento)
        Me.comboBoxAdv2.SelectedIndex = 1
        Me.ComboBoxAdv1.SelectedIndex = 0
        ' Add any initialization after the InitializeComponent() call.

        card.CaptionField = "tipoDoc"
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
    Private Sub UbicarDocumentoXIdDocumento(strTipoMov As String, intIdDocumento As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim saldoSA As New saldoInicioSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim personaSA As New PersonaSA
        Try
            Select Case strTipoMov
                Case "COMPRA", "OTRAS ENTRADAS A ALMACEN",
                    "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN",
                    "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE",
                    "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS"

                    dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("fechaContable", GetType(String)))
                    'lower case p
                    dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("serie", GetType(String)))
                    dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("Proveedor", GetType(String))) '
                    dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

                    dt.Columns.Add(New DataColumn("tasaIgv", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("Glosa", GetType(String)))

                    Dim str As String
                    With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(.fechaDoc).ToString("dd-MMM hh:mm tt ")
                        dr(0) = str
                        dr(1) = .fechaContable
                        dr(2) = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
                        dr(3) = .serie
                        dr(4) = .numeroDoc
                        If Not IsNothing(.idProveedor) Then
                            entidad = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault
                            dr(5) = entidad.nombreCompleto
                        ElseIf Not IsNothing(.idPersona) Then
                            With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona)
                                dr(5) = .nombreCompleto
                            End With
                        End If
                        Select Case .monedaDoc
                            Case 1
                                dr(6) = "NACIONAL"
                            Case Else
                                dr(6) = "EXTRANJERA"
                        End Select

                        dr(7) = .tasaIgv
                        dr(8) = .tcDolLoc
                        dr(9) = .importeTotal
                        dr(10) = .importeUS
                        dr(11) = .glosa
                        dt.Rows.Add(dr)
                    End With
                    Me.GDBSource.DataSource = dt
                    Me.StartPosition = FormStartPosition.CenterScreen
                    Me.GDBSource.BackColor = Color.White


                Case "VENTA"

                    dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("fechaContable", GetType(String)))
                    'lower case p
                    dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("serie", GetType(String)))
                    dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("Proveedor", GetType(String))) '
                    dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

                    dt.Columns.Add(New DataColumn("tasaIgv", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("Glosa", GetType(String)))

                    Dim str As String
                    With documentoVentaSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(.fechaDoc).ToString("dd-MMM hh:mm tt ")
                        dr(0) = str
                        dr(1) = .fechaDoc
                        dr(2) = tablaSA.GetUbicarTablaID(10, .tipoDocumento).descripcion
                        dr(3) = .serie
                        dr(4) = .numeroDoc
                        dr(5) = entidadSA.UbicarEntidadPorID(.idCliente).FirstOrDefault.nombreCompleto
                        Select Case .moneda
                            Case 1
                                dr(6) = "NACIONAL"
                            Case Else
                                dr(6) = "EXTRANJERA"
                        End Select

                        dr(7) = .tasaIgv
                        dr(8) = .tipoCambio
                        dr(9) = .ImporteNacional
                        dr(10) = .ImporteExtranjero
                        dr(11) = .glosa
                        dt.Rows.Add(dr)



                    End With
                    Me.GDBSource.DataSource = dt
                    Me.StartPosition = FormStartPosition.CenterScreen
                    Me.GDBSource.BackColor = Color.White


                Case "APORTES"

                    dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("fechaContable", GetType(String)))
                    'lower case p
                    dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("serie", GetType(String)))
                    dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
                    dt.Columns.Add(New DataColumn("Proveedor", GetType(String))) '
                    dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

                    dt.Columns.Add(New DataColumn("tasaIgv", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("Glosa", GetType(String)))

                    Dim str As String
                    With saldoSA.UbicarSaldoXidDocumento(intIdDocumento)
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(.fechaDoc).ToString("dd-MMM hh:mm tt ")
                        dr(0) = str
                        dr(1) = .fechaDoc
                        dr(2) = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
                        dr(3) = .serie
                        dr(4) = .numeroDoc
                        dr(5) = "VARIOS"
                        Select Case .monedaDoc
                            Case 1
                                dr(6) = "NACIONAL"
                            Case Else
                                dr(6) = "EXTRANJERA"
                        End Select

                        dr(7) = 0 ' .tasaIgv
                        dr(8) = 0
                        dr(9) = .importeTotal
                        dr(10) = .importeUS
                        dr(11) = .glosa
                        dt.Rows.Add(dr)



                    End With
                    Me.GDBSource.DataSource = dt
                    Me.StartPosition = FormStartPosition.CenterScreen
                    Me.GDBSource.BackColor = Color.White
                Case Else


            End Select
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmInfoSourceAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub



    Private Sub frmInfoSourceAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GDBSource.Model.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

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

    Private Sub ComboBoxAdv1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedValueChanged
     
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