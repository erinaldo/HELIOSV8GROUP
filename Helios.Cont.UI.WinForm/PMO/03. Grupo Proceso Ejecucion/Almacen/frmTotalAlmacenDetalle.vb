Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmTotalAlmacenDetalle
    Inherits frmMaster
    Public Property ManipulacionEstado() As String

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "metodos"
    Private Function getParentTableTotalAlmacen(idItem As Integer) As DataTable
        Dim DocumentoCompraDetalleSA As New DocumentoCompraDetalleSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de proveedores")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("NombreProveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))
        'lower case p
        dt.Columns.Add(New DataColumn("importe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("precioUnitario", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precioUnitarioUS", GetType(Decimal)))

        For Each i As documentocompradetalle In DocumentoCompraDetalleSA.GetUbicar_proveedorPorIdItem(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idItem)
            Dim strGravado As String = (i.idDocumento)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreProveedor
            dr(1) = i.tipoExistencia
            dr(2) = i.monto1
            dr(3) = i.importe
            dr(4) = i.importeUS
            dr(5) = i.precioUnitario
            dr(6) = i.precioUnitarioUS
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub BuscarProductoPorDescripcion(idItem As Integer)
        Dim parentTable As DataTable = getParentTableTotalAlmacen(idItem)
        Me.dgvTotalesDetalle.DataSource = parentTable
        dgvTotalesDetalle.TableDescriptor.Relations.Clear()
        dgvTotalesDetalle.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvTotalesDetalle.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvTotalesDetalle.Appearance.AnyRecordFieldCell.Enabled = False
        dgvTotalesDetalle.GroupDropPanel.Visible = True
        dgvTotalesDetalle.TableDescriptor.GroupedColumns.Clear()
        'dgvTotalesDetalle.TableDescriptor.GroupedColumns.Add("Clasificicacion")
        '    Me.dgvTotales.TableDescriptor.VisibleColumns.Remove("Clasificicacion")
    End Sub

#End Region

    Private Sub frmTotalAlmacenDetalle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmTotalAlmacenDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class