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
Public Class frmAlertaVentas
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGKardex(dgvAlertaVentas)
        getVentasObservadas()
    End Sub

    Private Sub ConfirmarAlertaVenta(intIdDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA

        ventaSA.GetConfirmarAlertaventa(New documentoventaAbarrotes With {.idDocumento = intIdDocumento})
        MessageBox.Show("Alerta resuelta con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GetVentasObservadas()
    End Sub

    Sub GridCFGKardex(GGC As GridGroupingControl)
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
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Function GetChildtable() As DataTable
        Dim ventaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Detalle de la venta")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("precioMN", GetType(Decimal)))


        For Each i In ventaSA.ListadoventasObservadasChild(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .notificacionAsiento = "S"})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.nombreItem
            dr(2) = i.importeMN
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function


    Private Function GetParentTable() As DataTable
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDocumento")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("numeroDocNormal")
        dt.Columns.Add("ImporteNacional")
        dt.Columns.Add("ImporteExtranjero")

        For Each i In ventaSA.ListadoventasObservadas(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .notificacionAsiento = "S"})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDocumento
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.numeroDocNormal
            dr(6) = i.ImporteNacional
            dr(7) = i.ImporteExtranjero
            dt.Rows.Add(dr)
        Next

        Return dt
        'dgvAlertaVentas.DataSource = ventaSA.ListadoventasObservadas(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .notificacionAsiento = "S"})

    End Function
    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable
    Private Sub GetVentasObservadas()
        Dim dSet As New DataSet()
        parentTable = GetParentTable()
        ChildTable = GetChildtable()
        dSet.Tables.Clear()
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = ChildTable.Columns("idDocumento")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvAlertaVentas.DataSource = parentTable
        Me.dgvAlertaVentas.Engine.BindToCurrencyManager = False

        Me.dgvAlertaVentas.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvAlertaVentas.TopLevelGroupOptions.ShowCaption = False
    End Sub

    Private Sub frmAlertaVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAlertaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        GetVentasObservadas()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvAlertaVentas.Table.CurrentRecord) Then
            If MessageBox.Show("Desea resolver la venta seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ConfirmarAlertaVenta(dgvAlertaVentas.Table.CurrentRecord.GetValue("idDocumento"))
            End If
        Else
            MessageBox.Show("Debe seleccionar una venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class