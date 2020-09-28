Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid

Public Class frmInfoMovimientoDia
    Inherits frmMaster


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGKardex(dgvUsuarios)
        GetMovimientos()
        Label1.Text = "Movimientos del día:  " & DateTime.Now.Date
        Me.CaptionLabels(0).Text = "Usuario: " & usuario.CustomUsuario.Full_Name
    End Sub

#Region "Métodos"
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


    Private Function GetChildCaja() As DataTable
        Dim objLista As New DocumentoCajaSA()

        Dim dt As New DataTable("Detalle de caja")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Item", GetType(String)))
        dt.Columns.Add(New DataColumn("MontoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("MontoME", GetType(Decimal)))

        For Each i As documentoCajaDetalle In objLista.GetMovimientoXusuarioInfoDetalle(usuario.IDUsuario, DateTime.Now.Date)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.montoSoles
            dr(3) = i.montoUsd
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Function GetMovimeintoPadre() As DataTable
        Dim cajaSA As New DocumentoCajaSA

        Dim dt As New DataTable("ParentTable")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodoc", GetType(String)))
        dt.Columns.Add(New DataColumn("nro", GetType(String)))
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        For Each i In cajaSA.GetMovimientoXusuarioInfo(usuario.IDUsuario, DateTime.Now.Date)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = If(i.tipoMovimiento = "DC", "Entrada", "Sálida")
            dr(2) = i.fechaCobro
            dr(3) = i.tipoDocPago
            dr(4) = i.numeroDoc
            If (i.tipoMovimiento = "DC") Then
                dr(5) = i.montoSoles
                dr(6) = i.montoUsd
            Else
                dr(5) = i.montoSoles * -1
                dr(6) = i.montoUsd * -1
            End If

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable
    Public Sub GetMovimientos()

        Dim dSet As New DataSet()
        parentTable = GetMovimeintoPadre()
        ChildTable = GetChildCaja()
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = ChildTable.Columns("idDocumento")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvUsuarios.DataSource = parentTable
        Me.dgvUsuarios.Engine.BindToCurrencyManager = False

        Me.dgvUsuarios.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvUsuarios.TopLevelGroupOptions.ShowCaption = False


    End Sub

#End Region

    Private Sub frmInfoMovimientoDia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmInfoMovimientoDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class