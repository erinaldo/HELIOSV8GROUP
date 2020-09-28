Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Public Class frmNotaValidaAlmacen
    Inherits frmMaster

    Public Property CantSolicitada() As Decimal
    Public Property MontoMNSolicitado() As Decimal
    Public Property MontoMESolicitado() As Decimal

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
    End Sub

    Public Sub New(be As totalesAlmacen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
        getStockAlmacenes(be)

        CantSolicitada = be.cantidad
        MontoMNSolicitado = be.importeSoles
        MontoMESolicitado = be.importeDolares
    End Sub

#Region "métodos"
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

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub getStockAlmacenes(be As totalesAlmacen)
        Dim totalesSA As New TotalesAlmacenSA
        Dim dt As New DataTable()


        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("idItem")
        dt.Columns.Add("almacen")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cant")
        dt.Columns.Add("monto")
        dt.Columns.Add("montoME")

        For Each i In totalesSA.GetStockAlmacenesBytem(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.idItem
            dr(2) = i.NomAlmacen
            dr(3) = i.descripcion
            dr(4) = i.idUnidad
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.importeDolares
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
    End Sub
#End Region

    Private Sub frmNotaValidaAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNotaValidaAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellDoubleClick
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            Try
                Dim r As Record = dgvCompra.Table.CurrentRecord
                Dim obj As New totalesAlmacen

                If Not CantSolicitada <= CDec(r.GetValue("cant")) Then
                    MessageBox.Show("No cuenta con stock disponible!")
                End If
                obj = New totalesAlmacen
                obj.idAlmacen = (r.GetValue("idAlmacen"))
                obj.NomAlmacen = r.GetValue("almacen")
                obj.idItem = (r.GetValue("idItem"))
                'Me.Tag = obj
                Dispose()
            Catch ex As Exception
                Me.Tag = Nothing
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Deebe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class