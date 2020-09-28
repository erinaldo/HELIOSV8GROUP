Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmModalSistemas

#Region "Attributes"
    Public Property ModulosSA As New AsegurableSA
    Public Property ModulosProductoSA As New ProductoDetalleSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Public Property tipo As String
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgModulos, True)
        GetModulos()
    End Sub

    Public Sub New(tipoProducto As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgModulos, True)
        GetModulosXProducto(tipoProducto)
    End Sub
#End Region

#Region "Methods"
    Public Sub GetModulos()
        Dim asegurableBE As New Asegurable
        asegurableBE.IDEmpresa = Gempresas.IdEmpresaRuc
        dgModulos.DataSource = ModulosSA.GetAsegurableXidCliente(asegurableBE)
        dgModulos.TableDescriptor.Columns("Nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgModulos.TableDescriptor.Columns("Nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Public Sub GetModulosXProducto(ID As Integer)
        Dim asegurableSA As New AsegurableSA
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("Descripcion")

        For Each z In asegurableSA.GetAsegurableXidCliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc})
            'For Each z In asegurableSA.GetAsegurableXidCliente(New Asegurable With {.IDCliente = "VPOS"})
            dt.Rows.Add(z.IDAsegurable, z.Nombre, z.Descripcion)
        Next

        'For Each i In ModulosProductoSA.ListadoAsegurableProducto(ID)
        '    dt.Rows.Add(i.IDAsegurable, i.nombre, i.descripcion)
        'Next
        dgModulos.DataSource = dt

        'dgModulos.DataSource = ModulosProductoSA.ListadoAsegurableProducto(tipoProducto)
        dgModulos.TableDescriptor.Columns("Nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgModulos.TableDescriptor.Columns("Nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub
#End Region

#Region "Events"
    Private Sub dgModulos_QueryCellStyleInfo(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgModulos.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgModulos.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgModulos_TableControlCellMouseHoverEnter(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellMouseEventArgs) Handles dgModulos.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgModulos)
    End Sub

    Private Sub dgModulos_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgModulos.TableControlCellDoubleClick
        Dim r As Record = dgModulos.Table.CurrentRecord
        If Not IsNothing(r) Then
            Select Case tipo
                Case "CLI"
                    Dim n As New AutorizacionRol
                    n.IDAsegurable = r.GetValue("IDAsegurable")
                    n.Nomasegurable = r.GetValue("Nombre")
                    n.EstaAutorizado = True
                    Tag = n
                    Close()
                Case "ADM"
                    Dim n As New ProductoDetalle
                    n.IDAsegurable = r.GetValue("IDAsegurable")
                    n.nombre = r.GetValue("Nombre")
                    n.estadoProducto = True
                    Tag = n
                    Close()

            End Select

        End If
    End Sub

    Private Sub dgModulos_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgModulos.TableControlCurrentCellControlDoubleClick

    End Sub
#End Region

End Class